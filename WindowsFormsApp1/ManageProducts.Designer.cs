namespace WindowsFormsApp1
{
    partial class ManageProducts
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
            this.quantitybox = new System.Windows.Forms.TextBox();
            this.barcodebox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.costbox = new System.Windows.Forms.TextBox();
            this.productlist = new System.Windows.Forms.DataGridView();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.namebox = new System.Windows.Forms.TextBox();
            this.cnamebox = new System.Windows.Forms.TextBox();
            this.packagebox = new System.Windows.Forms.TextBox();
            this.idbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sellingbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productlist)).BeginInit();
            this.SuspendLayout();
            // 
            // quantitybox
            // 
            this.quantitybox.Location = new System.Drawing.Point(117, 329);
            this.quantitybox.Name = "quantitybox";
            this.quantitybox.Size = new System.Drawing.Size(186, 22);
            this.quantitybox.TabIndex = 66;
            // 
            // barcodebox
            // 
            this.barcodebox.Location = new System.Drawing.Point(117, 451);
            this.barcodebox.Name = "barcodebox";
            this.barcodebox.Size = new System.Drawing.Size(186, 22);
            this.barcodebox.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 451);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 64;
            this.label8.Text = "Barcode:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 63;
            this.label7.Text = "Quantity:";
            // 
            // costbox
            // 
            this.costbox.Location = new System.Drawing.Point(117, 369);
            this.costbox.Name = "costbox";
            this.costbox.Size = new System.Drawing.Size(186, 22);
            this.costbox.TabIndex = 62;
            // 
            // productlist
            // 
            this.productlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productlist.Location = new System.Drawing.Point(373, 217);
            this.productlist.Name = "productlist";
            this.productlist.RowTemplate.Height = 24;
            this.productlist.Size = new System.Drawing.Size(784, 299);
            this.productlist.TabIndex = 61;
            this.productlist.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.productlist_RowHeaderMouseClick);
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(393, 171);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(132, 22);
            this.searchbox.TabIndex = 60;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(568, 588);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 45);
            this.button4.TabIndex = 58;
            this.button4.Text = "MODIFY";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(704, 588);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 45);
            this.button2.TabIndex = 57;
            this.button2.Text = "DELETE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(427, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 45);
            this.button1.TabIndex = 56;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(117, 217);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(186, 22);
            this.namebox.TabIndex = 54;
            // 
            // cnamebox
            // 
            this.cnamebox.Location = new System.Drawing.Point(117, 258);
            this.cnamebox.Name = "cnamebox";
            this.cnamebox.Size = new System.Drawing.Size(186, 22);
            this.cnamebox.TabIndex = 53;
            this.cnamebox.TextChanged += new System.EventHandler(this.emailbox_TextChanged);
            // 
            // packagebox
            // 
            this.packagebox.Location = new System.Drawing.Point(117, 293);
            this.packagebox.Name = "packagebox";
            this.packagebox.Size = new System.Drawing.Size(186, 22);
            this.packagebox.TabIndex = 52;
            // 
            // idbox
            // 
            this.idbox.Location = new System.Drawing.Point(117, 171);
            this.idbox.Name = "idbox";
            this.idbox.ReadOnly = true;
            this.idbox.Size = new System.Drawing.Size(186, 22);
            this.idbox.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 50;
            this.label5.Text = "Full Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 49;
            this.label4.Text = "Company:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Cost Price:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Id:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 67;
            this.label6.Text = "M.R.P:";
            // 
            // sellingbox
            // 
            this.sellingbox.Location = new System.Drawing.Point(117, 407);
            this.sellingbox.Name = "sellingbox";
            this.sellingbox.Size = new System.Drawing.Size(186, 22);
            this.sellingbox.TabIndex = 68;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 538);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 71;
            this.label9.Text = "Expiry Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 494);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 72;
            this.label10.Text = "MFG Date:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-mm-dd";
            this.dateTimePicker1.Location = new System.Drawing.Point(119, 494);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 73;
            this.dateTimePicker1.Value = new System.DateTime(2019, 3, 29, 0, 23, 43, 0);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-mm-dd";
            this.dateTimePicker2.Location = new System.Drawing.Point(117, 538);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 74;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_search_48;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(531, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 22);
            this.button3.TabIndex = 59;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ManageProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 683);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sellingbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quantitybox);
            this.Controls.Add(this.barcodebox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.costbox);
            this.Controls.Add(this.productlist);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.cnamebox);
            this.Controls.Add(this.packagebox);
            this.Controls.Add(this.idbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageProducts";
            this.Load += new System.EventHandler(this.ManageProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox quantitybox;
        private System.Windows.Forms.TextBox barcodebox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox costbox;
        private System.Windows.Forms.DataGridView productlist;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.TextBox cnamebox;
        private System.Windows.Forms.TextBox packagebox;
        private System.Windows.Forms.TextBox idbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sellingbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}