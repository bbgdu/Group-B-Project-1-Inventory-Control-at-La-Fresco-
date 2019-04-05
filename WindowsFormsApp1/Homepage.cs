using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            var m = new GenerateBill();
            m.ShowDialog();
        }
        private void customerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            var m = new ManageCustomers();
            m.ShowDialog();

        }

        private void adminToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            var m = new Manageusers();
            m.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void stockToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var m = new ManageProducts();
            m.ShowDialog();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new BillTransaction();
            m.ShowDialog();
        }

        private void profitCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new Profit();
            m.ShowDialog();
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new GenerateBill();
            m.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var m = new GenerateBill();
            m.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}