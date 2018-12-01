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
    public partial class OrderDisplayForm : Form
    {
        MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];
        private MySqlDataAdapter adapter1;

        public OrderDisplayForm()
        {
            InitializeComponent();
        }
        

        private void OrderDisplayForm_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            try
            {
                MySqlCommand command1 = connection.CreateCommand();
                command1.CommandText = "SELECT id_order, manufacturer, model_name, count, date_order, is_confirmed" +
                    " FROM product_order, product_directory" +
                    " WHERE product_order.id_prod = product_directory.id_prod;";
                adapter1 = new MySqlDataAdapter(command1);
                DataSet dataSet1 = new DataSet();
                adapter1.Fill(dataSet1);
                //dataGridView1.ColumnCount = 5;
                dataGridView1.DataSource = dataSet1.Tables[0];

            }
            catch { }
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
