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
    public partial class MainWindow : Form
    {
        internal string mySqlConnectionStr = "Server=localhost;Database=smartphone_stock;Uid=root;Pwd=root;convert zero datetime=True";

        MySqlConnection connection; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void warehouseStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createGoodsReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
