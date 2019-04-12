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
    public partial class stockout : Form
    {
        public stockout()
        {
            InitializeComponent();
        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrng);

        private void billlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stockout_Load(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = dateTimePicker3.Value;
            string dt1 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + "00:00:00";

            temp = dateTimePicker4.Value;
            string dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + temp.Hour + ":" + temp.Minute + ":" + temp.Second;

           



            String sql = "select BI.product_id as ID,S.name as PRODUCT_NAME,S.companyname AS COMPANY_NAME,S.package,sum(BI.quantity)as STOCK_OUT,S.selling_price as SELLING_PRICE from bill_item BI inner join bill B ON B.bill_id = BI.bill_id inner join Stock S ON S.id = BI.product_id GROUP by BI.product_id,S.name,S.companyname,S.package,S.selling_price";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@datetime3", dt1);
            cmd.Parameters.AddWithValue("@datetime4", dt2);
            conn.Open();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                stockoutlist.DataSource = dt5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = dateTimePicker3.Value;
            string dt1 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + "00:00:00";

            temp = dateTimePicker4.Value;
            string dt2;
            if (temp.Year == DateTime.Now.Year && temp.Month == DateTime.Now.Month && temp.Day == DateTime.Now.Day)
            {
                dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + temp.Hour + ":" + temp.Minute + ":" + temp.Second;
            }
            else
            {
                dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + "23:59:59";
            }

            String sql = "select BI.product_id as ID,S.name as PRODUCT_NAME,S.companyname AS COMPANY_NAME,S.package,sum(BI.quantity)as STOCK_OUT,S.selling_price as SELLING_PRICE from bill_item BI inner join bill B ON B.bill_id = BI.bill_id inner join Stock S ON S.id = BI.product_id WHERE date_time BETWEEN @datetime3 and @datetime4 GROUP by BI.product_id,S.name,S.companyname,S.package,S.selling_price";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@datetime3", dt1);
            cmd.Parameters.AddWithValue("@datetime4", dt2);
            conn.Open();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                stockoutlist.DataSource = dt5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        private void pnamebox_TextChanged(object sender, EventArgs e)
        {
            DateTime temp = new DateTime();
            temp = dateTimePicker3.Value;
            string dt1 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + "00:00:00";

            temp = dateTimePicker4.Value;
            string dt2;
            if (temp.Year == DateTime.Now.Year && temp.Month == DateTime.Now.Month && temp.Day == DateTime.Now.Day)
            {
                dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + temp.Hour + ":" + temp.Minute + ":" + temp.Second;
            }
            else
            {
                dt2 = temp.Year + "-" + temp.Month + "-" + temp.Day + " " + "23:59:59";
            }
            String sql = "select BI.product_id as ID,S.name as PRODUCT_NAME,S.companyname AS COMPANY_NAME,S.package,sum(BI.quantity)as STOCK_OUT,S.selling_price as SELLING_PRICE from bill_item BI inner join bill B ON B.bill_id = BI.bill_id inner join Stock S ON S.id = BI.product_id WHERE date_time BETWEEN @datetime3 and @datetime4 and S.name LIKE @name GROUP by BI.product_id,S.name,S.companyname,S.package,S.selling_price";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@datetime3", dt1);
            cmd.Parameters.AddWithValue("@datetime4", dt2);
            cmd.Parameters.AddWithValue("@name", "%"+pnamebox.Text.Trim()+"%");
            conn.Open();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                stockoutlist.DataSource = dt5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
    }
}
