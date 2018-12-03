using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WarehouseManagement
{
    public partial class DirectoryForm : Form
    {
        List<string> manufacturerList = new List<string>();

        List<string> modelList = new List<string>();
        MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];
        private MySqlDataAdapter adapter1;

        public DirectoryForm()
        {
            InitializeComponent();
        }

        private void DirectoryForm_Load(object sender, EventArgs e)
        {
            LoadProductDirectoryTable();
            Load_Manufacturer();
        }
        
        private void LoadProductDirectoryTable()
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            try
            {
                MySqlCommand command1 = connection.CreateCommand();
                command1.CommandText = "SELECT id_prod as ID, manufacturer as Manufacturer, model_name as Model, price as Price " +
                    "FROM product_directory";
                adapter1 = new MySqlDataAdapter(command1);
                DataSet dataSet1 = new DataSet();
                adapter1.Fill(dataSet1);
                //dataGridView1.ColumnCount = 5;
                dataGridView1.DataSource = dataSet1.Tables[0];
                foreach(DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;

                } 
            }
            catch { }
            connection.Close();
        }

        private void AddRow()
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            try
            {
                MySqlCommand command1 = connection.CreateCommand();

                string manufacturerText = manufacturerBox.Text.ToUpper();
                string modelText = modelBox.Text.ToUpper();

                decimal price = Convert.ToDecimal(priceBox.Text);

                command1.CommandText = "INSERT INTO product_directory(model_name, manufacturer, price)" +
                    "values(@modelText, @manufacturerText, @price)";
                command1.Parameters.AddWithValue("@modelText", modelText);
                command1.Parameters.AddWithValue("@manufacturerText", manufacturerText);
                command1.Parameters.AddWithValue("@price", price);

                if (command1.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully inserted!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error: unable to parse your data");
            }
            connection.Close();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();

            if (changes != null)
            {
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(adapter1);
                adapter1.UpdateCommand = mcb.GetUpdateCommand();
                adapter1.Update(changes);
                ((DataTable)dataGridView1.DataSource).AcceptChanges();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string emptySpaces = "Please fill following fields:\n";
            bool proceed = false;
            if (manufacturerBox.Text == "")
            {
                emptySpaces += "Manufacturer\n";
            }
            if (modelBox.Text == "")
            {
                emptySpaces += "Model\n";
            }
            if (priceBox.Text == "")
            {
                emptySpaces += "Price\n";
            }
            if (emptySpaces == "Please fill following fields:\n")
            {
                proceed = true;
            }
            if(!proceed && CheckModel())
            {
                MessageBox.Show(emptySpaces);
            } else if(proceed && CheckModel())
            {
                AddRow();
            } else if(!proceed && !CheckModel())
            {
                MessageBox.Show(emptySpaces + "This model already exists.\nPlease add new model");
            } else if(proceed && !CheckModel())
            {
                MessageBox.Show("This model already exists.\nPlease add new model");
            }
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

        // when the manufacturer changes, you'll see list of models of chosen models
        private bool CheckModel() 
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            
            string manufacturerText = manufacturerBox.Text.ToUpper();
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
            
            connection.Close();
            if (modelList.Contains(modelBox.Text.ToUpper()))
                return false;
            else return true;
        }

        private void manufacturerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductDirectoryTable();
        }

        private void modelBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void manufacturerBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void priceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            //if (regex.IsMatch(e.KeyChar.ToString()))
            //{
            //    e.Handled = true;
            //
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }
    }
}
