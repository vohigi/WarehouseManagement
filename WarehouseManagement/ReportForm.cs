using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using MySql.Data.MySqlClient;


namespace WarehouseManagement
{
    public partial class ReportForm : Form
    {
        List<string> manufacturerList = new List<string>();

        List<string> modelList = new List<string>();
        MainWindow obj = (MainWindow)Application.OpenForms["MainWindow"];

        public ReportForm()
        {
            InitializeComponent();
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }


        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=smartphone_stock;password=root;";

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(Application.StartupPath + @"\Report.pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"C:\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            PdfPTable tab = new PdfPTable(1);
            PdfPTable pdfTableFolder = new PdfPTable(1);

            pdfTableFolder.DefaultCell.BorderWidth = 0;
            pdfTableFolder.WidthPercentage = 100;
            pdfTableFolder.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            Chunk cnkFoolder = new Chunk("REPORT",font);
            cnkFoolder.Font.Size = 30;
            pdfTableFolder.AddCell(new Phrase(cnkFoolder));
            doc.Add(pdfTableFolder);
            doc.Add(tab);

            if (checkedListBox1.GetItemChecked(0))
            {
                string sql = "SELECT id_goods, manufacturer, model_name, goods_receipt.count, date_arrival FROM goods_receipt, product_directory WHERE product_directory.id_prod = goods_receipt.id_prod and date_arrival >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and date_arrival <= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "';";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                PdfPTable table = new PdfPTable(5);
                PdfPCell cell = new PdfPCell(new Phrase("RECEIPT",
                  new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                  iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
                cell.BackgroundColor = new BaseColor(Color.Wheat);
                cell.Padding = 5;
                cell.Colspan = 5;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                table.AddCell("Goods ID");
                table.AddCell("Manufacturer");
                table.AddCell("Model Name");
                table.AddCell("Count");
                table.AddCell("Order Date");

                while (reader.Read())
                {
                    table.AddCell((reader[0].ToString()));
                    table.AddCell((reader[1].ToString()));
                    table.AddCell((reader[2].ToString()));
                    table.AddCell((reader[3].ToString()));
                    table.AddCell(Convert.ToDateTime(reader[4]).ToString("yyyy-MM-dd"));
                }
                doc.Add(table);
                reader.Close();
            }

            if (checkedListBox1.GetItemChecked(1))
            {
                string sql = "SELECT id_stock, manufacturer, model_name, count_stock FROM product_directory, stock WHERE product_directory.id_prod = stock.id_prod; ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                PdfPTable table = new PdfPTable(4);
                PdfPCell cell = new PdfPCell(new Phrase("STOCK",
                  new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                  iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
                cell.BackgroundColor = new BaseColor(Color.Wheat);
                cell.Padding = 5;
                cell.Colspan = 4;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                table.AddCell("Stock ID");
                table.AddCell("Manufacturer");
                table.AddCell("Model Name");
                table.AddCell("Count");

                while (reader.Read())
                {
                    //iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"/images.jpg");
                    //jpg.Alignment = Element.ALIGN_CENTER;
                    //doc.Add(jpg);
                    table.AddCell((reader[0].ToString()));
                    table.AddCell((reader[1].ToString()));
                    table.AddCell((reader[2].ToString()));
                    table.AddCell((reader[3].ToString()));
                    //cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    //cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    //table.AddCell(cell);            
                }
                doc.Add(table);
                reader.Close();
            }


            if (checkedListBox1.GetItemChecked(2))
            {
                string sql = "SELECT id_order, manufacturer, model_name, count, date_order, is_confirmed FROM product_order, product_directory WHERE product_order.id_prod = product_directory.id_prod and date_order >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and date_order <= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "';";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                PdfPTable table = new PdfPTable(6);
                PdfPCell cell = new PdfPCell(new Phrase("ORDER",
                  new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                  iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
                cell.BackgroundColor = new BaseColor(Color.Wheat);
                cell.Padding = 5;
                cell.Colspan = 6;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                table.AddCell("Order ID");
                table.AddCell("Manufacturer");
                table.AddCell("Model Name");
                table.AddCell("Count");
                table.AddCell("Order Date");
                table.AddCell("Confirmed");
                string date = "";
                while (reader.Read())
                {
                    table.AddCell((reader[0].ToString()));
                    table.AddCell((reader[1].ToString()));
                    table.AddCell((reader[2].ToString()));
                    table.AddCell((reader[3].ToString()));
                    table.AddCell(Convert.ToDateTime(reader[4]).ToString("yyyy-MM-dd"));
                    table.AddCell((reader[5].ToString()));
                }
                doc.Add(table);
                reader.Close();
            }

            if (checkedListBox1.GetItemChecked(3))
            {
                string sql = "SELECT id_writeoff, manufacturer, model_name, date_paid FROM product_directory, product_writeoff WHERE product_directory.id_prod = product_writeoff.id_prod and date_paid >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and date_paid <= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "';";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                PdfPTable table = new PdfPTable(4);
                PdfPCell cell = new PdfPCell(new Phrase("WRITEOFF",
                  new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                  iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
                cell.BackgroundColor = new BaseColor(Color.Wheat);
                cell.Padding = 5;
                cell.Colspan = 4;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                table.AddCell("Writeoff ID");
                table.AddCell("Manufacturer");
                table.AddCell("Model Name");
                table.AddCell("Pay Date");

                while (reader.Read())
                {
                    table.AddCell((reader[0].ToString()));
                    table.AddCell((reader[1].ToString()));
                    table.AddCell((reader[2].ToString()));
                    table.AddCell(Convert.ToDateTime(reader[3]).ToString("yyyy-MM-dd"));
                }
                doc.Add(table);
                reader.Close();
            }



            Paragraph paragraph = new Paragraph("PROJECT AUTHOURS:");
            paragraph.Font.Size = 20;
            doc.Add(paragraph);
            Paragraph paragraph1 = new Paragraph("Panasiuk Oleksandr");
            doc.Add(paragraph1);
            Paragraph paragraph2 = new Paragraph("Molchanov Bogdan");
            doc.Add(paragraph2);
            Paragraph paragraph3 = new Paragraph("Sinelnikov Rodion");
            doc.Add(paragraph3);

            doc.Close();
            

            conn.Close();

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}