using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseManagement
{
    public partial class OrderConfirmation : Form
    {
        MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];

        private MySqlDataAdapter adapter1;

        int stockCount = 0;

        string id_prod_e = "";

        int orderCount = 0;

        public OrderConfirmation()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    if (CheckStock(textBox1.Text))
                    {
                        //Add to writeoff table

                        MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
                        connection.Open();
                        MySqlCommand command2 = connection.CreateCommand();
                        command2.CommandText = "INSERT INTO product_writeoff(id_prod, id_order, date_paid)" +
                    "values(@id_prod, @id_order, @date_paid)";
                        command2.Parameters.AddWithValue("@id_prod", id_prod_e);
                        command2.Parameters.AddWithValue("@id_order", textBox1.Text);
                        command2.Parameters.AddWithValue("@date_paid", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));

                        //update stock count

                        MySqlCommand command3 = connection.CreateCommand();
                        command3.CommandText = "update smartphone_stock.stock set count_stock = count_stock - @count where id_prod = @id_prod;";
                        command3.Parameters.AddWithValue("@id_prod", id_prod_e);
                        command3.Parameters.AddWithValue("@count", orderCount);


                        //update order status

                        MySqlCommand command1 = connection.CreateCommand();
                        command1.CommandText = "update smartphone_stock.product_order set is_confirmed = 1 WHERE id_order = @id_order;";
                        command1.Parameters.AddWithValue("@id_order", textBox1.Text);
                        if (command2.ExecuteNonQuery() > 0 && command3.ExecuteNonQuery() > 0 && command1.ExecuteNonQuery() > 0) { MessageBox.Show("Order successfully confirmed!"); LoadTable(); }
                        else MessageBox.Show("Error!!!");
                        connection.Close();
                    }


                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OrderConfirmation_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private bool CheckStock(string id_order)
        {

            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "SELECT count, id_prod  FROM product_order WHERE product_order.id_order = @id_order";
            command2.Parameters.AddWithValue("@id_order", id_order);
            MySqlDataReader readCountOrder = command2.ExecuteReader();
            if (readCountOrder.Read())
            {
                orderCount = Convert.ToInt32(readCountOrder["count"]);
                id_prod_e = readCountOrder["id_prod"].ToString();
            }
            readCountOrder.Close();
            MySqlCommand command1 = connection.CreateCommand();
            command1.CommandText = "SELECT count_stock FROM stock WHERE stock.id_prod = @id_product;";
            command1.Parameters.AddWithValue("@id_product", id_prod_e);
            MySqlDataReader readCount = command1.ExecuteReader();
            if (readCount.Read())
            {
                stockCount = Convert.ToInt32(readCount["count_stock"]);
            }
            readCount.Close();
            connection.Close();
            if (orderCount <= stockCount)
            {
                return true;

            }
            else { return false; }
            
        }
        private void LoadTable()
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            try
            {
                MySqlCommand command1 = connection.CreateCommand();
                command1.CommandText = "SELECT id_order, manufacturer, model_name, price, date_order, count FROM product_order, product_directory WHERE product_directory.id_prod=product_order.id_prod AND product_order.is_confirmed=0";
                adapter1 = new MySqlDataAdapter(command1);
                DataSet dataSet1 = new DataSet();
                adapter1.Fill(dataSet1);
                dataGridView1.DataSource = dataSet1.Tables[0];

            }
            catch { }
            connection.Close();
        }
    }
}
