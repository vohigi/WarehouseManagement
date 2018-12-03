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
    public partial class StockForm : Form
    {
        MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];
        private MySqlDataAdapter adapter1;

        public StockForm()
        {
            InitializeComponent();
        }
        
        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            try
            {
                MySqlCommand command1 = connection.CreateCommand();
                command1.CommandText = "SELECT id_stock as ID, manufacturer as Manufacturer, " +
                    "model_name as Model, count_stock as Count, price as 'Total Price' " +
                    "FROM stock, product_directory " +
                    "WHERE product_directory.id_prod=stock.id_prod";
                adapter1 = new MySqlDataAdapter(command1);
                DataSet dataSet1 = new DataSet();
                adapter1.Fill(dataSet1);
                dataGridView1.DataSource = dataSet1.Tables[0];
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
            catch { }
            connection.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
