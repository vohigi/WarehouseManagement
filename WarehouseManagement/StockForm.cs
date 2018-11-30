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

        private void StockForm_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(obj.mySqlConnectionStr);
            connection.Open();
            try
            {
                MySqlCommand command1 = connection.CreateCommand();
                command1.CommandText = "SELECT * FROM stock";
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
