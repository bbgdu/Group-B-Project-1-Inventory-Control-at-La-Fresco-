using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.functions;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Manageusers : Form
    {
        public Manageusers()
        {
            InitializeComponent();
        }

        Users u = new Users();
        UserFunctions uf = new UserFunctions();
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Manageusers_Load(object sender, EventArgs e)
        {
            DataTable dt = uf.Select();
            userlist.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox3.Text.Trim() != textBox2.Text.Trim())
            {
                MessageBox.Show("Passwords don't match.TRY AGAIN!");
            }
            else
            {
                u.username = textBox1.Text.Trim();
                u.name = textBox6.Text.Trim();
                u.email = textBox5.Text.Trim();
                u.password = textBox3.Text.Trim();
                u.contact = Int64.Parse(textBox4.Text.Trim());
                if (u.username != "")
                {
                    bool ok = uf.Insert(u);
                    if (ok == true)
                    {
                        MessageBox.Show("USER ADDED SUCCESSFULLY!");
                        DataTable dt = uf.Select();
                        userlist.DataSource = dt;
                        textBox1.Text = "";
                        textBox6.Text = "";
                        textBox5.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox2.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("FAILED TO ADD!");
                    }

                }
                else
                {
                    MessageBox.Show("USERNAME CAN'T BE EMPTY!");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            u.username = textBox1.Text.Trim();
            u.name = textBox6.Text.Trim();
            u.email = textBox5.Text.Trim();
            u.password = textBox3.Text.Trim();
            u.contact = Int64.Parse(textBox4.Text.Trim());
            if (u.username != "")
            {
                bool ok = uf.Update(u);
                if (ok == true)
                {
                    MessageBox.Show("USER UPDATED SUCCESSFULLY!");
                    DataTable dt = uf.Select();
                    userlist.DataSource = dt;
                    textBox1.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox2.Text = "";

                }
                else
                {
                    MessageBox.Show("FAILED TO UPDATE!");
                }

            }
            else
            {
                MessageBox.Show("USERNAME CAN'T BE EMPTY!");
            }

    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            u.username = textBox1.Text.Trim();
            if (u.username != "")
            {
                bool ok = uf.Delete(u);
                if (ok == true)
                {
                    MessageBox.Show("USER DELETED SUCCESSFULLY!");
                    DataTable dt = uf.Select();
                    userlist.DataSource = dt;
                    textBox1.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox2.Text = "";

                }
                else
                {
                    MessageBox.Show("FAILED TO DELETE!");
                }
            }
        }

        private void userlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            textBox1.Text = userlist.Rows[rowindex].Cells[0].Value.ToString();
            textBox6.Text = userlist.Rows[rowindex].Cells[1].Value.ToString();
            textBox5.Text = userlist.Rows[rowindex].Cells[2].Value.ToString();
            textBox3.Text = userlist.Rows[rowindex].Cells[3].Value.ToString();
            textBox4.Text = userlist.Rows[rowindex].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
