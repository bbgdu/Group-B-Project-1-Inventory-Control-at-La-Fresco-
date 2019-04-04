using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1.functions
{
    class BillFunctions
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert Data in Database
        public bool Insert(bill_item c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO bill_item(bill_id,product_id,quantity,total_price) values(@bill_id,@product_id,@quantity,@total_price)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@bill_id", c.bill_id);
                cmd.Parameters.AddWithValue("@product_id", c.product_id);
                cmd.Parameters.AddWithValue("@quantity", c.quantity);
                cmd.Parameters.AddWithValue("@total_price", c.total_price);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region Insert Data in Database
        public bool bill_insert(Bill c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO Bill(customer_id,amount,final_discount,grand_total,date_time) values(@customer_id,@amount,@final_discount,@grand_total,@date_time)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                //cmd.Parameters.AddWithValue("@bill_id", c.bill_id);
                cmd.Parameters.AddWithValue("@customer_id", c.customer_id);
                cmd.Parameters.AddWithValue("@amount", c.amount);
                cmd.Parameters.AddWithValue("@final_discount", c.final_discount);
                cmd.Parameters.AddWithValue("@grand_total", c.grand_total);
                cmd.Parameters.AddWithValue("@date_time", c.date_time);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

    }
}
