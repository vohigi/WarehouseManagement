using System;
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
    public partial class OrderForm : Form
    {
        List<string> manufacturerList = new List<string>();

        List<string> modelList = new List<string>();
        MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
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

        private void manufacturerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model_Changed();
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                uint count = Convert.ToUInt32(countBox.Text);

                if (count > 0)
                    AddRow();
                else MessageBox.Show("Fill Count field");
            } catch
            {
                MessageBox.Show("Count field must be filled by numeric");
            }
        }

        private void AddRow()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
                connection.Open();

                MySqlCommand command1 = connection.CreateCommand();
                MySqlCommand command2 = connection.CreateCommand();
                MySqlCommand command3 = connection.CreateCommand();
                MySqlCommand command4 = connection.CreateCommand();


                string manufacturerText = manufacturerBox.Text;
                string modelText = modelBox.Text;
                uint count = Convert.ToUInt32(countBox.Text);

                string orderDate = orderDateBox.Value.ToString("yyyy-MM-dd");

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


                command1.CommandText = "SELECT count_stock FROM stock WHERE stock.id_prod = @id_product;";
                command1.Parameters.AddWithValue("@id_product", id_prod_e);
                int stockCount = 0;
                MySqlDataReader readCount = command1.ExecuteReader();
                if (readCount.Read())
                {
                    stockCount = Convert.ToInt32(readCount["count_stock"]);
                }
                readCount.Close();

                if (count <= stockCount)
                {
                    command2.CommandText = "INSERT INTO product_order(id_prod, date_order, count) values(@id_prod, @orderDate, @count)";
                    command2.Parameters.AddWithValue("@id_prod", id_prod_e);
                    command2.Parameters.AddWithValue("@orderDate", orderDate);
                    command2.Parameters.AddWithValue("@count", count);
                }
                else MessageBox.Show("Stock has not enough product on it. Try typing less count");

                /*command2.CommandText = "INSERT INTO product_order(id_prod, date_order, count)" +
                    "values(@id_prod, @arrivalDate, @count)";
                command2.Parameters.AddWithValue("@id_prod", id_prod_e);
                command2.Parameters.AddWithValue("@arrivalDate", orderDate);
                command2.Parameters.AddWithValue("@count", count);*/


                if (command2.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully inserted!");
                    //AddToStock();
                }
                else
                {
                    MessageBox.Show("ERROR!");
                }

                connection.Close();
            }
            catch(Exception exept)
            {
                MessageBox.Show(exept.Message);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
