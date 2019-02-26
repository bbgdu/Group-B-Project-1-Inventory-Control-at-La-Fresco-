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
    public partial class Prudhvi : Form
    {
        public Prudhvi()
        {
            InitializeComponent();
        }

        Users u = new Users();
        Login l = new Login();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Prudhvi_Load(object sender, EventArgs e)
        {
            //nothing
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            //nothing
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            u.username = textBox1.Text.Trim();
            u.password = textBox2.Text.Trim();
            bool ok = l.loginCheck(u);
            if(ok == true)
            {
                //MessageBox.Show("Login Success");
                this.Hide();
                var m = new Manageusers();
                m.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            //nothing
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            //nothing
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //nothing
        }
    }
}
