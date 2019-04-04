namespace WindowsFormsApp1.Resources
{
    partial class Confirmation
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
            this.bidlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bidlabel
            // 
            this.bidlabel.AutoSize = true;
            this.bidlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bidlabel.Location = new System.Drawing.Point(28, 33);
            this.bidlabel.Name = "bidlabel";
            this.bidlabel.Size = new System.Drawing.Size(82, 29);
            this.bidlabel.TabIndex = 1;
            this.bidlabel.Text = "Bill ID:";
            this.bidlabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // Confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 669);
            this.Controls.Add(this.bidlabel);
            this.Name = "Confirmation";
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.Confirmation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label bidlabel;
    }
}