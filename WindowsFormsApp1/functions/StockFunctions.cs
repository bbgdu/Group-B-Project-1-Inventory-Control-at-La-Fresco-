using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1.functions
{
    class StockFunctions
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select 
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string query = "select *from Stock" +
                    "";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion Select

        #region Insert Data in Database
        public bool Insert(Stock c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO Stock(name,companyname,package,quantity_available,cost_price,selling_price,barcode,expiry_date,mfg_date) values(@name,@companyname,@package,@quantity_available,@cost_price,@selling_price,@barcode,@expiry_date,@mfg_date)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", c.fname);
                cmd.Parameters.AddWithValue("@companyname", c.company);
                cmd.Parameters.AddWithValue("@package", c.amount);
                cmd.Parameters.AddWithValue("@quantity_available", c.quantity);
                cmd.Parameters.AddWithValue("@cost_price", c.cost_price);
                cmd.Parameters.AddWithValue("@selling_price", c.selling_price);
                cmd.Parameters.AddWithValue("@barcode", c.barcode);
                cmd.Parameters.AddWithValue("@expiry_date", c.exp_date);
                cmd.Parameters.AddWithValue("@mfg_date", c.mfg_date);

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

        #region Update data in Database
        public bool Update(Stock c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Stock SET name=@name,companyname=@companyname,package=@package,quantity_available=@quantity,cost_price= @cost_price,selling_price= @selling_price,barcode= @barcode, expiry_date= @expiry_date , mfg_date= @mfg_date where id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", c.fname);
                cmd.Parameters.AddWithValue("@companyname", c.company);
                cmd.Parameters.AddWithValue("@package", c.amount);
                cmd.Parameters.AddWithValue("@quantity_available", c.quantity);
                cmd.Parameters.AddWithValue("@cost_price", c.cost_price);
                cmd.Parameters.AddWithValue("@selling_price", c.selling_price);
                cmd.Parameters.AddWithValue("@barcode", c.barcode);
                cmd.Parameters.AddWithValue("@expiry_date", c.exp_date);
                cmd.Parameters.AddWithValue("@mfg_date", c.mfg_date);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query Successfull
                    isSuccess = true;
                }
                else
                {
                    //Query Failed
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

        #region Delete Data from DAtabase
        public bool Delete(Stock c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM Stock WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //Query Successfull
                    isSuccess = true;
                }
                else
                {
                    //Query Failed
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

        #region Search
        public DataTable Search(string key)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string query = "select * from Stock where companyname LIKE '%" + key + "%' OR name LIKE '%" + key + "%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion Search
    }
}
