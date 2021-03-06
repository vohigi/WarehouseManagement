﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WarehouseManagement
{
    public partial class GoodsRecieptForm : Form
    {
        List<string> manufacturerList = new List<string>();

        List<string> modelList = new List<string>();
        MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];
        StockForm obj2 = (StockForm)Application.OpenForms["Stock"];
        public GoodsRecieptForm()
        {
            InitializeComponent();
        }

        private void GoodsRecieptForm_Load(object sender, EventArgs e)
        {
            Load_Manufacturer();
        }

        private void Load_Manufacturer()
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();

            string manufacturerStr = "SELECT manufacturer FROM product_directory";

            MySqlCommand command1 = connection.CreateCommand();

            command1.CommandText = manufacturerStr;
            MySqlDataReader reader = command1.ExecuteReader();

            while (reader.Read())
            {
                manufacturerList.Add(reader["manufacturer"].ToString());
            }
            reader.Close();
            List<string> manufacturerDistinctList = manufacturerList.Distinct().ToList();
            manufacturerBox.DataSource = manufacturerDistinctList;
            connection.Close();
        }
        private void Model_Changed() // when the manufacturer changes, you'll see list of models of chosen models
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();

            if (!manufacturerList.Contains(manufacturerBox.Text))
            {
                Load_Manufacturer();
            }

            List<string> modelList = new List<string>();
            string manufacturerText = manufacturerBox.Text;
            string modelStr = "SELECT model_name FROM product_directory " +
                "WHERE product_directory.manufacturer = @manufacturerText";

            MySqlCommand command1 = connection.CreateCommand();
            command1.Parameters.AddWithValue("@manufacturerText", manufacturerText);
            command1.CommandText = modelStr;
            MySqlDataReader reader = command1.ExecuteReader();

            while (reader.Read())
            {
                modelList.Add(reader["model_name"].ToString());
            }
            reader.Close();



            List<string> modelDistinctList = modelList.Distinct().ToList(); // creates list without duplicates

            modelBox.DataSource = modelDistinctList;
            connection.Close();
        }



        private void AddRowButton_Click(object sender, EventArgs e)
        {
            try
            {


                MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
                connection.Open();

                MySqlCommand command1 = connection.CreateCommand();
                MySqlCommand command2 = connection.CreateCommand();
                MySqlCommand command3 = connection.CreateCommand();

                string manufacturerText = manufacturerBox.Text;
                string modelText = modelBox.Text;
                uint count = Convert.ToUInt32(countBox.Text);

                string arrivalDate = arrivalDateBox.Value.ToString("yyyy-MM-dd");

                command3.CommandText = "SELECT id_prod from product_directory " +
                    "WHERE product_directory.manufacturer = @manufacturerText " +
                    "and product_directory.model_name = @modelText";
                command3.Parameters.AddWithValue("@manufacturerText", manufacturerText);
                command3.Parameters.AddWithValue("@modelText", modelText);
                MySqlDataReader reader = command3.ExecuteReader();
                string id_prod_e = "";
                if (reader.Read())
                {
                    id_prod_e = reader["id_prod"].ToString();
                }
                reader.Close();

                command2.CommandText = "INSERT INTO goods_receipt(id_prod, date_arrival, count)" +
                    "values(@id_prod, @arrivalDate, @count)";
                command2.Parameters.AddWithValue("@id_prod", id_prod_e);
                command2.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                command2.Parameters.AddWithValue("@count", count);

                /*command1.CommandText = "INSERT INTO goods_receipt(id_prod, count_stock " +
                    "values(@id_prod, @count)";
                command1.Parameters.AddWithValue("@id_prod", id_prod_e);
                command1.Parameters.AddWithValue("@count", count);*/ //non working
                if (command2.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully inserted!");
                    AddToStock();
                    try
                    {
                        var stock_form = Application.OpenForms.OfType<StockForm>().Single();
                        stock_form.LoadData();
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("ERROR!");
                }



                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"ERROR"); }
        }

        private void manufacturerBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Model_Changed();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddToStock()
        {
            try
            {
                List<string> stockList = new List<string>();

                MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
                connection.Open();
                MySqlCommand command1 = connection.CreateCommand();
                command1.CommandText = "SELECT * FROM smartphone_stock.goods_receipt order by id_goods Desc limit 1;";
                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "SELECT * FROM smartphone_stock.stock";
                MySqlCommand command3 = connection.CreateCommand();

                MySqlDataReader reader = command1.ExecuteReader();
                string[] lastRow = new string[2];
                if (reader.Read())
                {

                    lastRow[0] = reader["id_prod"].ToString();
                    lastRow[1] = reader["count"].ToString();
                }
                reader.Close();
                MySqlDataReader readerStock = command2.ExecuteReader();
                while (readerStock.Read())
                {

                    stockList.Add(readerStock["id_prod"].ToString());
                }
                readerStock.Close();
              int k = 0;
                if (stockList.Contains(lastRow[0]))
                {
                    command3.CommandText = "update smartphone_stock.stock set count_stock = count_stock + @count where id_prod = " + lastRow[0] + "; ";
                    command3.Parameters.AddWithValue("@count", lastRow[1]);
                    k = command3.ExecuteNonQuery();
                    
                }
                else
                {
                    command3.CommandText = "INSERT INTO smartphone_stock.stock(id_prod, count_stock)" +
                    "values(@id_prod, @count) ";
                    command3.Parameters.AddWithValue("@count", lastRow[1]);
                    command3.Parameters.AddWithValue("@id_prod", lastRow[0]);
                    k = command3.ExecuteNonQuery();
                }
                if(k>0) MessageBox.Show("Successfully added to stock!");
                else MessageBox.Show("Error!!");
                connection.Close();
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
