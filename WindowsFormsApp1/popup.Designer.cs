namespace WindowsFormsApp1
{
    partial class User
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abcdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bcdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteModifyAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(1385, 28);
            this.menuStrip3.TabIndex = 2;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abcdToolStripMenuItem,
            this.bcdToolStripMenuItem,
            this.newCustomerToolStripMenuItem,
            this.editCustomerToolStripMenuItem,
            this.addDeleteModifyAdminToolStripMenuItem,
            this.addNewAdminToolStripMenuItem,
            this.editAdminToolStripMenuItem,
            this.deleteAdminToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // abcdToolStripMenuItem
            // 
            this.abcdToolStripMenuItem.Name = "abcdToolStripMenuItem";
            this.abcdToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.abcdToolStripMenuItem.Text = "Add Product";
            this.abcdToolStripMenuItem.Click += new System.EventHandler(this.abcdToolStripMenuItem_Click);
            // 
            // bcdToolStripMenuItem
            // 
            this.bcdToolStripMenuItem.Name = "bcdToolStripMenuItem";
            this.bcdToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.bcdToolStripMenuItem.Text = "Add Stock";
            this.bcdToolStripMenuItem.Click += new System.EventHandler(this.bcdToolStripMenuItem_Click);
            // 
            // newCustomerToolStripMenuItem
            // 
            this.newCustomerToolStripMenuItem.Name = "newCustomerToolStripMenuItem";
            this.newCustomerToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.newCustomerToolStripMenuItem.Text = "New Customer";
            // 
            // editCustomerToolStripMenuItem
            // 
            this.editCustomerToolStripMenuItem.Name = "editCustomerToolStripMenuItem";
            this.editCustomerToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.editCustomerToolStripMenuItem.Text = "Edit Customer";
            this.editCustomerToolStripMenuItem.Click += new System.EventHandler(this.editCustomerToolStripMenuItem_Click);
            // 
            // addDeleteModifyAdminToolStripMenuItem
            // 
            this.addDeleteModifyAdminToolStripMenuItem.Name = "addDeleteModifyAdminToolStripMenuItem";
            this.addDeleteModifyAdminToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addDeleteModifyAdminToolStripMenuItem.Text = "Delete Customer";
            // 
            // addNewAdminToolStripMenuItem
            // 
            this.addNewAdminToolStripMenuItem.Name = "addNewAdminToolStripMenuItem";
            this.addNewAdminToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addNewAdminToolStripMenuItem.Text = "Add Admin";
            // 
            // editAdminToolStripMenuItem
            // 
            this.editAdminToolStripMenuItem.Name = "editAdminToolStripMenuItem";
            this.editAdminToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.editAdminToolStripMenuItem.Text = "Edit Admin";
            // 
            // deleteAdminToolStripMenuItem
            // 
            this.deleteAdminToolStripMenuItem.Name = "deleteAdminToolStripMenuItem";
            this.deleteAdminToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.deleteAdminToolStripMenuItem.Text = "Delete Admin";
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.billToolStripMenuItem,
            this.billTransactionsToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // billToolStripMenuItem
            // 
            this.billToolStripMenuItem.Name = "billToolStripMenuItem";
            this.billToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.billToolStripMenuItem.Text = "Bill";
            // 
            // billTransactionsToolStripMenuItem
            // 
            this.billTransactionsToolStripMenuItem.Name = "billTransactionsToolStripMenuItem";
            this.billTransactionsToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.billTransactionsToolStripMenuItem.Text = "Bill Transactions";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productDetailToolStripMenuItem,
            this.stockDetailToolStripMenuItem,
            this.customerDetailToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // productDetailToolStripMenuItem
            // 
            this.productDetailToolStripMenuItem.Name = "productDetailToolStripMenuItem";
            this.productDetailToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.productDetailToolStripMenuItem.Text = "Product Detail";
            // 
            // stockDetailToolStripMenuItem
            // 
            this.stockDetailToolStripMenuItem.Name = "stockDetailToolStripMenuItem";
            this.stockDetailToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.stockDetailToolStripMenuItem.Text = "Stock Detail";
            // 
            // customerDetailToolStripMenuItem
            // 
            this.customerDetailToolStripMenuItem.Name = "customerDetailToolStripMenuItem";
            this.customerDetailToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.customerDetailToolStripMenuItem.Text = "Customer Detail";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.addUserToolStripMenuItem.Text = "Add/Delete/Update User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 791);
            this.Controls.Add(this.menuStrip3);
            this.Name = "User";
            this.Text = "Admin Dashboard";
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abcdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bcdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeleteModifyAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
    }
}