namespace WarehouseManagement
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.warehouseStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodsReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGoodsReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGoodsReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispalyOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmOrderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warehouseStockToolStripMenuItem,
            this.productDirectoryToolStripMenuItem,
            this.goodsReceiptToolStripMenuItem,
            this.ordersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // warehouseStockToolStripMenuItem
            // 
            this.warehouseStockToolStripMenuItem.Name = "warehouseStockToolStripMenuItem";
            this.warehouseStockToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.warehouseStockToolStripMenuItem.Text = "Warehouse Stock";
            this.warehouseStockToolStripMenuItem.Click += new System.EventHandler(this.warehouseStockToolStripMenuItem_Click);
            // 
            // productDirectoryToolStripMenuItem
            // 
            this.productDirectoryToolStripMenuItem.Name = "productDirectoryToolStripMenuItem";
            this.productDirectoryToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.productDirectoryToolStripMenuItem.Text = "Product Directory";
            this.productDirectoryToolStripMenuItem.Click += new System.EventHandler(this.productDirectoryToolStripMenuItem_Click);
            // 
            // goodsReceiptToolStripMenuItem
            // 
            this.goodsReceiptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createGoodsReceiptToolStripMenuItem,
            this.displayGoodsReceiptToolStripMenuItem});
            this.goodsReceiptToolStripMenuItem.Name = "goodsReceiptToolStripMenuItem";
            this.goodsReceiptToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.goodsReceiptToolStripMenuItem.Text = "Goods Receipt";
            // 
            // createGoodsReceiptToolStripMenuItem
            // 
            this.createGoodsReceiptToolStripMenuItem.Name = "createGoodsReceiptToolStripMenuItem";
            this.createGoodsReceiptToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createGoodsReceiptToolStripMenuItem.Text = "Create Goods Receipt";
            this.createGoodsReceiptToolStripMenuItem.Click += new System.EventHandler(this.createGoodsReceiptToolStripMenuItem_Click);
            // 
            // displayGoodsReceiptToolStripMenuItem
            // 
            this.displayGoodsReceiptToolStripMenuItem.Name = "displayGoodsReceiptToolStripMenuItem";
            this.displayGoodsReceiptToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.displayGoodsReceiptToolStripMenuItem.Text = "Display Goods Receipt";
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createOrderToolStripMenuItem,
            this.dispalyOrdersToolStripMenuItem,
            this.confirmOrderToolStripMenuItem1});
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ordersToolStripMenuItem.Text = "Orders";
            // 
            // createOrderToolStripMenuItem
            // 
            this.createOrderToolStripMenuItem.Name = "createOrderToolStripMenuItem";
            this.createOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createOrderToolStripMenuItem.Text = "Create Order";
            this.createOrderToolStripMenuItem.Click += new System.EventHandler(this.createOrderToolStripMenuItem_Click);
            // 
            // dispalyOrdersToolStripMenuItem
            // 
            this.dispalyOrdersToolStripMenuItem.Name = "dispalyOrdersToolStripMenuItem";
            this.dispalyOrdersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dispalyOrdersToolStripMenuItem.Text = "Dispaly Orders";
            this.dispalyOrdersToolStripMenuItem.Click += new System.EventHandler(this.dispalyOrdersToolStripMenuItem_Click);
            // 
            // confirmOrderToolStripMenuItem1
            // 
            this.confirmOrderToolStripMenuItem1.Name = "confirmOrderToolStripMenuItem1";
            this.confirmOrderToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.confirmOrderToolStripMenuItem1.Text = "Confirm Order";
            this.confirmOrderToolStripMenuItem1.Click += new System.EventHandler(this.confirmOrderToolStripMenuItem1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Warehouse Management";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem warehouseStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodsReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispalyOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGoodsReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayGoodsReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmOrderToolStripMenuItem1;
    }
}

