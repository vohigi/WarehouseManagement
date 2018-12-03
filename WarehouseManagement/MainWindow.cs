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
            menuStrip1.Renderer = new MyRenderer();
            menuStrip1.BackColor = Color.Coral;
        }

        private void warehouseStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StockForm stockForm = new StockForm();
                stockForm.Show(this);
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
                goodsRecieptForm.StartPosition = FormStartPosition.CenterParent;
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
                directoryform.StartPosition = FormStartPosition.CenterParent;
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
                orderForm.StartPosition = FormStartPosition.CenterParent;
                orderForm.Show(this);
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

        private void dispalyOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderDisplayForm orderDisplayForm = new OrderDisplayForm();
            orderDisplayForm.StartPosition = FormStartPosition.CenterParent;
            orderDisplayForm.Show(this);
        }

        private void makeAReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm orderReportForm = new ReportForm();
            orderReportForm.StartPosition = FormStartPosition.CenterParent;
            orderReportForm.Show(this);
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Yellow; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Orange; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Yellow; }
            }
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.Show(this);
        }

    }
}
