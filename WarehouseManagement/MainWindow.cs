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
            try
            {
                StockForm stockForm = new StockForm();
                
                stockForm.ShowDialog(this);
            }
            catch (Exception stockEx)
            {
                MessageBox.Show(stockEx.Message);
            }
        }

        private void createGoodsReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GoodsRecieptForm goodsRecieptForm = new GoodsRecieptForm();
                goodsRecieptForm.StartPosition = FormStartPosition.CenterScreen;
                goodsRecieptForm.Show(this);
            }
            catch (Exception directoryEx)
            {
                MessageBox.Show(directoryEx.Message);
            }
        }

        private void productDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryForm directoryform = new DirectoryForm();
                directoryform.StartPosition = FormStartPosition.CenterScreen;
                directoryform.Show(this);
            } catch(Exception directoryEx)
            {
                MessageBox.Show(directoryEx.Message);
            }
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OrderForm orderForm = new OrderForm();
                orderForm.StartPosition = FormStartPosition.CenterScreen;
                orderForm.Show();
            }
            catch (Exception orderEx)
            {
                MessageBox.Show(orderEx.Message);
            }
        }

        private void confirmOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OrderConfirmation orderConfirmation = new OrderConfirmation();
            orderConfirmation.StartPosition = FormStartPosition.CenterParent;
            orderConfirmation.Show(this);
        }
    }
}
