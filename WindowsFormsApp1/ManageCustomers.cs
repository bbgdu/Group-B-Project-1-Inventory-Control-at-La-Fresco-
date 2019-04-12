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
    public partial class ManageCustomers : Form
    { 
        public ManageCustomers()
        {
            InitializeComponent();
        }
        Customer c = new Customer();
        CustomerFunctions cf = new CustomerFunctions();

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            DataTable dt = cf.Select();
            customerlist.DataSource = dt;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

                c.name = namebox.Text.Trim();
                c.email = emailbox.Text.Trim();
            if (contactbox.Text != "")
            {
                c.contact = Int64.Parse(contactbox.Text.Trim());
            }
            else
            {
                c.contact = 0;
            }

                c.balance = float.Parse(balancebox.Text.Trim());
                c.type = typebox.Text.Trim();
                c.thumb_impression = thumbbox.Text.Trim();
                c.rollno = rollnobox.Text.Trim();
                    bool ok = cf.Insert(c);
                    if (ok == true)
                    {
                        MessageBox.Show("CUSTOMER ADDED SUCCESSFULLY!");
                        DataTable dt = cf.Select();
                        customerlist.DataSource = dt;
                        idbox.Text = "";
                        namebox.Text = "";
                        emailbox.Text = "";
                        balancebox.Text = "";
                        contactbox.Text = "";
                        rollnobox.Text = "";
                        thumbbox.Text = "";
                        typebox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("FAILED TO ADD!");
                    }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.id = idbox.Text.Trim();
            c.name = namebox.Text.Trim();
            c.email = emailbox.Text.Trim();
              if (contactbox.Text != "")
            {
                c.contact = Int64.Parse(contactbox.Text.Trim());
            }
            else
            {
                c.contact = 0;
            }
            c.balance = float.Parse(balancebox.Text.Trim());
            c.type = typebox.Text.Trim();
            c.thumb_impression = thumbbox.Text.Trim();
            c.rollno = rollnobox.Text.Trim();

            bool ok = cf.Update(c);
                if (ok == true)
                {
                    MessageBox.Show("CUSTOMER UPDATED SUCCESSFULLY!");
                    DataTable dt = cf.Select();
                    customerlist.DataSource = dt;
                    idbox.Text = "";
                    namebox.Text = "";
                    emailbox.Text = "";
                    balancebox.Text = "";
                    contactbox.Text = "";
                    rollnobox.Text = "";
                    typebox.Text = "";
                    thumbbox.Text = "";
                }
                else
                {
                    MessageBox.Show("FAILED TO UPDATE!");
                }

        }

        private void customerlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            idbox.Text = customerlist.Rows[rowindex].Cells[0].Value.ToString();
            namebox.Text = customerlist.Rows[rowindex].Cells[1].Value.ToString();
            emailbox.Text = customerlist.Rows[rowindex].Cells[2].Value.ToString();
            contactbox.Text = customerlist.Rows[rowindex].Cells[3].Value.ToString();
            rollnobox.Text = customerlist.Rows[rowindex].Cells[4].Value.ToString();
            thumbbox.Text = customerlist.Rows[rowindex].Cells[7].Value.ToString();
            typebox.Text = customerlist.Rows[rowindex].Cells[6].Value.ToString();
            balancebox.Text = customerlist.Rows[rowindex].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.id = idbox.Text.Trim();
            bool ok = cf.Delete(c);
            if (ok == true)
                {
                    MessageBox.Show("USER DELETED SUCCESSFULLY!");
                    DataTable dt = cf.Select();
                    customerlist.DataSource = dt;
                    idbox.Text = "";
                    namebox.Text = "";
                    emailbox.Text = "";
                    balancebox.Text = "";
                    contactbox.Text = "";
                    rollnobox.Text = "";
                    typebox.Text = "";
                    thumbbox.Text = "";
            }
            else
                {
                    MessageBox.Show("FAILED TO DELETE!");
                }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if (searchbox.Text.Trim() != "")
            {
                DataTable dt = cf.Search_name(searchbox.Text.Trim());
                customerlist.DataSource = dt;
            }
            else
            {
                DataTable dt = cf.Select();
                customerlist.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void customerlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
