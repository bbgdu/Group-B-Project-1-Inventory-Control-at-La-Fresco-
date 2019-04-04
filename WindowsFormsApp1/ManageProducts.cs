using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using WindowsFormsApp1.functions;

namespace WindowsFormsApp1
{
    public partial class ManageProducts : Form
    {
        public ManageProducts()
        {
            InitializeComponent();
        }


        Stock c = new Stock();
        StockFunctions cf = new StockFunctions();

    

        private void emailbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.fname = namebox.Text.Trim();
            c.company = cnamebox.Text.Trim();
            c.amount = packagebox.Text.Trim();
            c.quantity = Int32.Parse(quantitybox.Text.Trim());
            c.cost_price = float.Parse(costbox.Text.Trim());
            c.selling_price = float.Parse(sellingbox.Text.Trim());
            c.barcode = barcodebox.Text.Trim();
            c.exp_date = dateTimePicker1.Value;
            c.mfg_date = dateTimePicker2.Value;
            bool ok = cf.Insert(c);
            if (ok == true)
            {
                MessageBox.Show("PRODUCT ADDED SUCCESSFULLY!");
                DataTable dt = cf.Select();
                productlist.DataSource = dt;
                idbox.Text = "";
                namebox.Text = "";
                cnamebox.Text = "";
                packagebox.Text = "";
                quantitybox.Text = "";
                costbox.Text = "";
                sellingbox.Text = "";
                barcodebox.Text = "";
                DateTime localDate = DateTime.Now;
                dateTimePicker1.Value = localDate;
                dateTimePicker2.Value = localDate;
            }
            else
            {
                MessageBox.Show("FAILED TO ADD!");
            }
        }

        private void ManageProducts_Load(object sender, EventArgs e)
        {
            
                DataTable dt = cf.Select();
                productlist.DataSource = dt;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.id = Int64.Parse(idbox.Text.Trim());
            c.fname = namebox.Text.Trim();
            c.company = cnamebox.Text.Trim();
            c.amount = packagebox.Text.Trim();
            c.quantity = Int32.Parse(quantitybox.Text.Trim());
            c.cost_price = float.Parse(costbox.Text.Trim());
            c.selling_price = float.Parse(sellingbox.Text.Trim());
            c.barcode = barcodebox.Text.Trim();
            c.exp_date = dateTimePicker1.Value;
            c.mfg_date = dateTimePicker2.Value;
            bool ok = cf.Update(c);

            if (ok == true)
            {
                MessageBox.Show("PRODUCT UPDATED SUCCESSFULLY!");
                DataTable dt = cf.Select();
                productlist.DataSource = dt;
                idbox.Text = "";
                namebox.Text = "";
                cnamebox.Text = "";
                packagebox.Text = "";
                quantitybox.Text = "";
                costbox.Text = "";
                sellingbox.Text = "";
                barcodebox.Text = "";
                DateTime localDate = DateTime.Now;
                dateTimePicker1.Value = localDate;
                dateTimePicker2.Value = localDate;
            }
            else
            {
                MessageBox.Show("FAILED TO UPDATE!");
            }
        }

        private void productlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            idbox.Text = productlist.Rows[rowindex].Cells[0].Value.ToString();
            namebox.Text = productlist.Rows[rowindex].Cells[1].Value.ToString();
            cnamebox.Text = productlist.Rows[rowindex].Cells[2].Value.ToString();
            packagebox.Text = productlist.Rows[rowindex].Cells[3].Value.ToString();
            quantitybox.Text = productlist.Rows[rowindex].Cells[4].Value.ToString();
            costbox.Text = productlist.Rows[rowindex].Cells[5].Value.ToString();
            sellingbox.Text = productlist.Rows[rowindex].Cells[6].Value.ToString();
            barcodebox.Text = productlist.Rows[rowindex].Cells[7].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(productlist.Rows[rowindex].Cells[8].Value.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(productlist.Rows[rowindex].Cells[9].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.id = Int32.Parse(idbox.Text.Trim());
            bool ok = cf.Delete(c);

            if (ok == true)
            {
                MessageBox.Show("PRODUCT DELETED SUCCESSFULLY!");
                DataTable dt = cf.Select();
                productlist.DataSource = dt;
                idbox.Text = "";
                namebox.Text = "";
                cnamebox.Text = "";
                packagebox.Text = "";
                quantitybox.Text = "";
                costbox.Text = "";
                sellingbox.Text = "";
                barcodebox.Text = "";
                DateTime localDate = DateTime.Now;
                dateTimePicker1.Value = localDate;
                dateTimePicker2.Value = localDate;
            }
            else
            {
                MessageBox.Show("FAILED TO DELETE!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            String s = searchbox.Text.Trim();
            if (s != "")
            {
                DataTable dt = cf.Search(s);
                productlist.DataSource = dt;
            }
            else
            {
                DataTable dt = cf.Select();
                productlist.DataSource = dt;
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
