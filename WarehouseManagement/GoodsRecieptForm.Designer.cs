namespace WarehouseManagement
{
    partial class GoodsRecieptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.arrivalDateBox = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.countBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.manufacturerBox = new System.Windows.Forms.ComboBox();
            this.modelBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(336, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 62;
            this.label8.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(336, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 61;
            this.label6.Text = "*";
            // 
            // CloseButton
            // 
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CloseButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(14, 222);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(327, 36);
            this.CloseButton.TabIndex = 60;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddRowButton
            // 
            this.AddRowButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddRowButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddRowButton.Location = new System.Drawing.Point(14, 180);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(327, 36);
            this.AddRowButton.TabIndex = 59;
            this.AddRowButton.Text = "Add Row";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 21);
            this.label5.TabIndex = 58;
            this.label5.Text = "Arrival Date";
            // 
            // arrivalDateBox
            // 
            this.arrivalDateBox.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.arrivalDateBox.Location = new System.Drawing.Point(141, 140);
            this.arrivalDateBox.Name = "arrivalDateBox";
            this.arrivalDateBox.Size = new System.Drawing.Size(192, 20);
            this.arrivalDateBox.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 56;
            this.label3.Text = "Count";
            // 
            // countBox
            // 
            this.countBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.countBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.countBox.FormattingEnabled = true;
            this.countBox.Location = new System.Drawing.Point(141, 100);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(192, 28);
            this.countBox.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(336, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 54;
            this.label4.Text = "*";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(336, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 53;
            this.label7.Text = "*";
            // 
            // manufacturerBox
            // 
            this.manufacturerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manufacturerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.manufacturerBox.FormattingEnabled = true;
            this.manufacturerBox.Location = new System.Drawing.Point(141, 20);
            this.manufacturerBox.Name = "manufacturerBox";
            this.manufacturerBox.Size = new System.Drawing.Size(192, 28);
            this.manufacturerBox.TabIndex = 52;
            this.manufacturerBox.SelectedIndexChanged += new System.EventHandler(this.manufacturerBox_SelectedIndexChanged_1);
            // 
            // modelBox
            // 
            this.modelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.modelBox.FormattingEnabled = true;
            this.modelBox.Location = new System.Drawing.Point(141, 60);
            this.modelBox.Name = "modelBox";
            this.modelBox.Size = new System.Drawing.Size(192, 28);
            this.modelBox.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 49;
            this.label1.Text = "Manufacturer";
            // 
            // GoodsRecieptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 270);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.arrivalDateBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.manufacturerBox);
            this.Controls.Add(this.modelBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GoodsRecieptForm";
            this.Text = "GoodsRecieptForm";
            this.Load += new System.EventHandler(this.GoodsRecieptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker arrivalDateBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox countBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox manufacturerBox;
        private System.Windows.Forms.ComboBox modelBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}