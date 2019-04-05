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
using WindowsFormsApp1.functions;

namespace WindowsFormsApp1
{
    public partial class BillTransaction : Form
    {
        public BillTransaction()
        {
            InitializeComponent();
        }

        CustomerFunctions cf = new CustomerFunctions();

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrng);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = dateTimePicker3.Value;
            string dt1 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + "00:00:00";

            temp = dateTimePicker4.Value;
            string dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + temp.Hour + ":" + temp.Minute + ":" + temp.Second;

            float netpurchase, netselling;



            String sql1 = "select * from bill WHERE date_time BETWEEN @datetime3 and @datetime4";
           
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
          
            cmd1.Parameters.AddWithValue("@datetime3", dt1);
            cmd1.Parameters.AddWithValue("@datetime4", dt2);
   

            conn.Open();

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                billlist.DataSource = dt5;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cnamebox_TextChanged(object sender, EventArgs e)
        {
            string key = cnamebox.Text.Trim();
            clist.DataSource = cf.Search_name(key);
        }

        private void BillTransaction_Load(object sender, EventArgs e)
        {
            clist.DataSource = cf.Select();
        }

        private void clist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int rowindex = e.RowIndex;
            int cid = Int32.Parse(clist.Rows[rowindex].Cells[0].Value.ToString());
            DateTime temp = new DateTime();
            temp = dateTimePicker3.Value;
            string dt1 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + "00:00:00";

            temp = dateTimePicker4.Value;
            string dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + temp.Hour + ":" + temp.Minute + ":" + temp.Second;


            String sql1 = "select * from bill WHERE date_time BETWEEN @datetime3 and @datetime4 AND customer_id=@cid";

            SqlCommand cmd1 = new SqlCommand(sql1, conn);

            cmd1.Parameters.AddWithValue("@datetime3", dt1);
            cmd1.Parameters.AddWithValue("@datetime4", dt2);
            cmd1.Parameters.AddWithValue("@cid", cid);



            conn.Open();

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                DataTable dt6 = new DataTable();
                adapter.Fill(dt6);
                billlist.DataSource = dt6;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
