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

namespace WindowsFormsApp1
{
    public partial class Profit : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrng);

        public Profit()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = dateTimePicker3.Value;
            string dt1 = temp.Year+"-"+temp.Month+"-"+temp.Day+" "+"00:00:00";
            
            temp = dateTimePicker4.Value;
            string dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + temp.Hour + ":" + temp.Minute + ":" + temp.Second;

            float netpurchase, netselling;

          

            String sql = "select sum(quantity * cost_price) from (bill inner join bill_item ON bill.bill_id = bill_item.bill_id inner join Stock ON Stock.id = bill_item.product_id) WHERE date_time BETWEEN @datetime3 and @datetime4";
            String sql1 = "select sum(grand_total) from bill WHERE date_time BETWEEN @datetime3 and @datetime4";
            String select_query = "select * from (bill inner join bill_item ON bill.bill_id = bill_item.bill_id inner join Stock ON Stock.id = bill_item.product_id) WHERE date_time BETWEEN @datetime3 and @datetime4";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlCommand cmdselect = new SqlCommand(select_query, conn);
            cmd.Parameters.AddWithValue("@datetime3",dt1);
            cmd.Parameters.AddWithValue("@datetime4", dt2);
            cmd1.Parameters.AddWithValue("@datetime3", dt1);
            cmd1.Parameters.AddWithValue("@datetime4", dt2);
            cmdselect.Parameters.AddWithValue("@datetime3", dt1);
            cmdselect.Parameters.AddWithValue("@datetime4", dt2);

            conn.Open();

            try
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                
                netpurchase = float.Parse(dt5.Rows[0][0].ToString());
                netpurchasebox.Text = netpurchase.ToString();
                
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                DataTable dt6 = new DataTable();
                adapter1.Fill(dt6);
             
                netselling = float.Parse(dt6.Rows[0][0].ToString());
                netsellingbox.Text = netselling.ToString();

                SqlDataAdapter select_adapter = new SqlDataAdapter(cmdselect);
                DataTable dt7 = new DataTable();
                select_adapter.Fill(dt7);
                profitlist.DataSource = dt7;

                profitbox.Text= (netselling - netpurchase).ToString();
                int percent = (int)((netselling - netpurchase) / netpurchase * 100);
                percentlabel.Text = percent.ToString() + " %";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

            conn.Close();

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Profit_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
