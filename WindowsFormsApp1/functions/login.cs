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
    class Login
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public bool loginCheck(Users u)
        {
            bool okay = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "SELECT * FROM admin_login WHERE username = @username and password = @password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0){
                    okay = true;
                }
                else
                {
                    okay = false;
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
            return okay;
        }
    }
}
