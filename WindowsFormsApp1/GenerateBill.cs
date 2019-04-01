using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using WindowsFormsApp1.functions;

namespace WindowsFormsApp1
{
    public partial class GenerateBill : Form
    {
        public GenerateBill()
        {
            InitializeComponent();
        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        StockFunctions sf = new StockFunctions();
        TempcartFunctions tcf = new TempcartFunctions();
        Tempcart tc = new Tempcart();

        int quantity = 1;
        int item_id, item_id2;
        float total_amount=0;
        float price;
        float discount = 0;
        int quantity_available;

        private void unregbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (unregbtn.Checked)
            {
                cnamebox.Text = "";
                cidbox.Text = "";
                contactbox.Text = "";
                balancelabel.Text = "00.00";
            }
            
        }

        private void regbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (regbtn.Checked)
            {
                CustomerFunctions cf = new CustomerFunctions();
                DataTable dt = new DataTable();
                dt = cf.Select();
                customerlist.DataSource = dt;
            }
        }

        private void cnamebox_TextChanged(object sender, EventArgs e)
        {
            if(regbtn.Checked)
            {
                string cname = cnamebox.Text.Trim();
                CustomerFunctions cf = new CustomerFunctions();
                DataTable dt = new DataTable();
                dt = cf.Search_name(cname);
                customerlist.DataSource = dt;
            }
        }

        private void customerlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            cnamebox.Text = customerlist.Rows[rowindex].Cells[1].Value.ToString();
            cidbox.Text = customerlist.Rows[rowindex].Cells[0].Value.ToString();
            contactbox.Text = customerlist.Rows[rowindex].Cells[3].Value.ToString();
            balancelabel.Text = customerlist.Rows[rowindex].Cells[5].Value.ToString();
        }

        private void bidbox_TextChanged(object sender, EventArgs e)
        {

        }

        int billid;

        private void GenerateBill_Load(object sender, EventArgs e)
        {
            tcf.Clear();
            

            discountbox.Text = "0";
            amountbox.Text = "0";

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string query = "select max(bill_id) from bill";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                billid = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bidbox.Text = billid.ToString();

            DataTable dt = new DataTable();
            dt = sf.Select();
            stocklist.DataSource = dt;

            DataTable dt2 = new DataTable();
            dt2 = tcf.Select();
            cartlist.DataSource = dt2;

            //quantitybox;
            quantitybox.Text = quantity.ToString();

        }


        private void pnamebox_TextChanged(object sender, EventArgs e)
        {
            string key = pnamebox.Text.Trim();
            DataTable dt = new DataTable();
            dt = sf.Search(key);
            stocklist.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            quantity = Int32.Parse(quantitybox.Text.Trim());
            if (quantity>1)
            quantity--;
            quantitybox.Text = quantity.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            quantity = Int32.Parse(quantitybox.Text.Trim());
            quantity++;
            quantitybox.Text = quantity.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tc.item_id = item_id;
            tc.price = price;
            quantity = Int32.Parse(quantitybox.Text.Trim());
            tc.quantity = quantity;

            bool ok = tcf.Insert(tc);
            if (ok)
            {
                DataTable dt4 = tcf.Select();
                cartlist.DataSource = dt4;
            }
            else
            {
                MessageBox.Show("Failed!");
            }
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
               
                string query = "select sum(price*quantity) from tempcart";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                // total_amount = dt5.Rows[0].Field<float>(0);
                total_amount = float.Parse(dt5.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            amountbox.Text = total_amount.ToString();
        }

        private void stocklist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            item_id = Int32.Parse(stocklist.Rows[rowindex].Cells[0].Value.ToString());
            price= float.Parse(stocklist.Rows[rowindex].Cells[6].Value.ToString());
            //quantity_available = Int32.Parse(stocklist.Rows[rowindex].Cells[4].Value.ToString());
        }

        private void cartlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            item_id2 = Int32.Parse(cartlist.Rows[rowindex].Cells[3].Value.ToString());
           // MessageBox.Show(item_id2.ToString());
            
        }

        private void quantitybox_TextChanged(object sender, EventArgs e)
        {
            if (quantitybox.Text.Trim() != "")
            {
                quantity = Int32.Parse(quantitybox.Text.Trim());
                if (quantity > quantity_available)
                {
                    quantity = quantity_available;
                }
            }
            else
            {
                quantitybox.Text = "";
                quantity = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool ok = tcf.Clear();
            if (ok)
            {
                DataTable dt4 = tcf.Select();
                cartlist.DataSource = dt4;
            }
            else
            {
                MessageBox.Show("Failed to Clear!");
            }
        }

        private void amountbox_TextChanged(object sender, EventArgs e)
        {
            if (amountbox.Text.Trim() != "")
            {
                total_amount = float.Parse(amountbox.Text.Trim());
                if (discountbox.Text.Trim() != "")
                {
                    discount = float.Parse(discountbox.Text.Trim());

                }
                else
                {
                    discount = 0;
                }
                payablelabel.Text = (total_amount - (discount * total_amount) * 0.01).ToString();
            }
            else
            {
                payablelabel.Text = "0.00";
            }
            
        }

        private void GenerateBill_LocationChanged(object sender, EventArgs e)
        {

        }

        private void discountbox_TextChanged(object sender, EventArgs e)
        {
            if (discountbox.Text.Trim() != "")
            {
                discount = float.Parse(discountbox.Text.Trim());
                
            }
            else
            {
                discount = 0;
            }
            payablelabel.Text = (total_amount - (discount * total_amount) * 0.01).ToString();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool ok = tcf.Delete(item_id2);
            if (ok)
            {
                DataTable dt4 = tcf.Select();
                cartlist.DataSource = dt4;
            }
            else
            {
                MessageBox.Show("Failed to remove!");
            }

            //copy pasted
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                string query = "select sum(price*quantity) from tempcart";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                // total_amount = dt5.Rows[0].Field<float>(0);
                total_amount = float.Parse(dt5.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                total_amount = 0;
            }
            finally
            {
                conn.Close();
            }
            
            amountbox.Text = total_amount.ToString();
        }
    }
}
