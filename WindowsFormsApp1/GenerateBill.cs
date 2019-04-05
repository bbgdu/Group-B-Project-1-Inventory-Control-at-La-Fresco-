using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using WindowsFormsApp1.functions;
using WindowsFormsApp1.Resources;

namespace WindowsFormsApp1
{
    public partial class GenerateBill : Form
    {
        public GenerateBill()
        {
            InitializeComponent();
        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        StockFunctions sf = new StockFunctions();
        TempcartFunctions tcf = new TempcartFunctions();
        Tempcart tc = new Tempcart();
        CustomerFunctions cf = new CustomerFunctions();
        BillFunctions bf = new BillFunctions();

        int quantity = 1;
        int item_id, item_id2;
        float total_amount=0;
        float price;
        float discount = 0;
        int quantity_available;

        private void unregbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (unregbtn.Checked)
            {
                customerlist.DataSource = null;
                textBox1.Text = "";
                cidbox.Text = "";
                contactbox.Text = "";
                balancelabel.Text = "00.00";
            }
            
        }

        private void regbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (regbtn.Checked)
            {
                CustomerFunctions cf = new CustomerFunctions();
                DataTable dt = new DataTable();
                dt = cf.Select();
                customerlist.DataSource = dt;
            }
        }

        private void cnamebox_TextChanged(object sender, EventArgs e)
        {
            if(regbtn.Checked)
            {
                string cname = textbox1.Text.Trim();
                CustomerFunctions cf = new CustomerFunctions();
                DataTable dt = new DataTable();
                dt = cf.Search_name(cname);
                customerlist.DataSource = dt;
            }
        }

        private void customerlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            textBox1.Text = customerlist.Rows[rowindex].Cells[1].Value.ToString();
           
            
                cidbox.Text = customerlist.Rows[rowindex].Cells[0].Value.ToString();
                 
            
            
                contactbox.Text = customerlist.Rows[rowindex].Cells[3].Value.ToString();
            
                balancelabel.Text = customerlist.Rows[rowindex].Cells[5].Value.ToString();
           
          

            if (customerlist.Rows[rowindex].Cells[6].Value.ToString() == "Member") 
            {
                label21.Text = "Member";
                label21.BackColor= Color.FromArgb(172, 255, 0);
            }
            else
            {
                label21.Text = "Non-Member";
                label21.BackColor = Color.FromArgb(255,0, 0);
            }
        }

        private void bidbox_TextChanged(object sender, EventArgs e)
        {

        }

        int billid;

        private void GenerateBill_Load(object sender, EventArgs e)
        {
            tcf.Clear();
            

            discountbox.Text = "0";
            amountbox.Text = "0";

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string query = "select max(bill_id) from bill";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                billid = (int)cmd.ExecuteScalar();
                billid++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bidbox.Text = billid.ToString();

            DataTable dt = new DataTable();
            dt = sf.Select();
            stocklist.DataSource = dt;

            DataTable dt2 = new DataTable();
            dt2 = tcf.Select();
            cartlist.DataSource = dt2;

            //quantitybox;
            quantitybox.Text = quantity.ToString();

        }


        private void pnamebox_TextChanged(object sender, EventArgs e)
        {
            string key = pnamebox.Text.Trim();
            DataTable dt = new DataTable();
            dt = sf.Search(key);
            stocklist.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            quantity = Int32.Parse(quantitybox.Text.Trim());
            if (quantity>1)
            quantity--;
            quantitybox.Text = quantity.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            quantity = Int32.Parse(quantitybox.Text.Trim());
            quantity++;
            quantitybox.Text = quantity.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tc.item_id = item_id;
            tc.price = price;
            quantity = Int32.Parse(quantitybox.Text.Trim());
            tc.quantity = quantity;

            bool ok = tcf.Insert(tc);
            if (ok)
            {
                DataTable dt4 = tcf.Select();
                cartlist.DataSource = dt4;
            }
            else
            {
                MessageBox.Show("Failed!");
            }
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
               
                string query = "select sum(price*quantity) from tempcart";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                // total_amount = dt5.Rows[0].Field<float>(0);
                total_amount = float.Parse(dt5.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            amountbox.Text = total_amount.ToString();
        }

        private void stocklist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            item_id = Int32.Parse(stocklist.Rows[rowindex].Cells[0].Value.ToString());
            price= float.Parse(stocklist.Rows[rowindex].Cells[6].Value.ToString());
            //quantity_available = Int32.Parse(stocklist.Rows[rowindex].Cells[4].Value.ToString());
        }

        private void cartlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            item_id2 = Int32.Parse(cartlist.Rows[rowindex].Cells[3].Value.ToString());
           // MessageBox.Show(item_id2.ToString());
            
        }

        private void quantitybox_TextChanged(object sender, EventArgs e)
        {
            if (quantitybox.Text.Trim() != "")
            {
                quantity = Int32.Parse(quantitybox.Text.Trim());
                if (quantity > quantity_available)
                {
                    quantity = quantity_available;
                }
            }
            else
            {
                quantitybox.Text = "";
                quantity = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool ok = tcf.Clear();
            if (ok)
            {
                DataTable dt4 = tcf.Select();
                cartlist.DataSource = dt4;
            }
            else
            {
                MessageBox.Show("Failed to Clear!");
            }
        }

        private void amountbox_TextChanged(object sender, EventArgs e)
        {
            if (amountbox.Text.Trim() != "")
            {
                total_amount = float.Parse(amountbox.Text.Trim());
                if (discountbox.Text.Trim() != "")
                {
                    discount = float.Parse(discountbox.Text.Trim());

                }
                else
                {
                    discount = 0;
                }
                payablelabel.Text = (total_amount - (discount * total_amount) * 0.01).ToString();
            }
            else
            {
                payablelabel.Text = "0.00";
            }
            
        }

        private void GenerateBill_LocationChanged(object sender, EventArgs e)
        {

        }

        private void discountbox_TextChanged(object sender, EventArgs e)
        {
            if (discountbox.Text.Trim() != "")
            {
                discount = float.Parse(discountbox.Text.Trim());
                
            }
            else
            {
                discount = 0;
            }
            payablelabel.Text = (total_amount - (discount * total_amount) * 0.01).ToString();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (regbtn.Checked)
                {
                    if (float.Parse(balancelabel.Text) <= float.Parse(payablelabel.Text))
                    {
                        MessageBox.Show("Insufficient Balance");
                    }
                    else
                    {
                        float var = float.Parse(balancelabel.Text) - float.Parse(payablelabel.Text);
                        cf.Deduct(Int32.Parse(cidbox.Text.Trim()), var);
                        balancelabel.Text = var.ToString();
                        foreach (DataGridViewRow row in cartlist.Rows)
                        {
                            if (row.Cells[3].Value != null) sf.deduce(Int32.Parse(row.Cells[3].Value.ToString()), Int32.Parse(row.Cells[2].Value.ToString()));
                        }
                        foreach (DataGridViewRow row in cartlist.Rows)
                        {
                            if (row.Cells[3].Value != null)
                            {
                                bill_item bi = new bill_item();
                                bi.bill_id = Int32.Parse(bidbox.Text.Trim());
                                bi.product_id = Int32.Parse(row.Cells[3].Value.ToString());
                                bi.quantity = Int32.Parse(row.Cells[2].Value.ToString());
                                bi.total_price = float.Parse(row.Cells[1].Value.ToString());
                                bf.Insert(bi);
                            }
                        }
                        Bill f = new Bill();
                        f.bill_id = Int32.Parse(bidbox.Text.Trim());
                        f.customer_id = Int32.Parse(cidbox.Text.Trim());
                        f.amount = float.Parse(amountbox.Text.Trim());
                        f.final_discount = float.Parse(discountbox.Text.Trim());
                        f.grand_total = float.Parse(payablelabel.Text);
                        f.date_time = DateTime.Now;
                        bf.bill_insert(f);


                        cartlist.DataSource = tcf.Select();
                        try
                        {
                            var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
                            string path = $"C:\\Users\\LENOVO\\Desktop\\Test.pdf";
                            PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
                            pdfDoc.Open();
                            var spacer = new Paragraph("")
                            {
                                SpacingBefore = 10f,
                                SpacingAfter = 10f,
                            };
                            iTextSharp.text.Font times = FontFactory.GetFont("TIMES_ROMAN", 25, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font normal = FontFactory.GetFont("TIMES_ROMAN", 12);
                            iTextSharp.text.Font normalbold = FontFactory.GetFont("TIMES_ROMAN", 12, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font normalitalic = FontFactory.GetFont("FREESTYLE_SCRIPT", 10, iTextSharp.text.Font.ITALIC);
                            var spacer1 = new Paragraph("LA FRESCO - The IITI Facilitation Center", times)
                            {

                                SpacingBefore = 10f,
                                SpacingAfter = 10f,
                            };
                            pdfDoc.Add(spacer);
                            pdfDoc.Add(spacer);
                            spacer1.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(spacer1);

                            Chunk glue = new Chunk(new VerticalPositionMark());
                            Paragraph P = new Paragraph("BILL ID: " + bidbox.Text.Trim(), normal);
                            P.Add(new Chunk(glue));
                            P.Add("Date: " + DateTime.Now.ToString());
                            pdfDoc.Add(P);



                            //IMAGE

                            //var imagepath = @"C:\Users\Deepu\Desktop\thumb.png";
                            //using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                            //{
                            //   var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                            //  png.ScalePercent(5f);
                            // png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
                            //pdfDoc.Add(png);
                            //}



                            //pdfDoc.Add(spacer);


                            var spacer2 = new Paragraph("NAME: " + textBox1.Text.Trim(), normal)
                            {

                                SpacingBefore = 10f,
                                SpacingAfter = 10f,
                            };

                            pdfDoc.Add(spacer2);
                            pdfDoc.Add(spacer);

                            var columnCount = cartlist.ColumnCount;

                            var columnWidths = new[] { 0.75f, .75f, .75f, 0.75f };

                            var table = new PdfPTable(columnWidths)
                            {
                                HorizontalAlignment = Left,
                                WidthPercentage = 100,
                                DefaultCell = { MinimumHeight = 22f }
                            };

                            var cell = new PdfPCell(new Phrase("Product Details "))
                            {
                                Colspan = columnCount,
                                HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
                                MinimumHeight = 30f
                            };
                            cell.BorderWidthBottom = 1f;
                            cell.BorderWidthLeft = 0f;
                            cell.BorderWidthRight = 0f;
                            cell.BorderWidthTop = 1f;

                            table.AddCell(cell);

                            //Adding Header row
                            foreach (DataGridViewColumn column in cartlist.Columns)
                            {
                                PdfPCell ycell = new PdfPCell(new Phrase(column.HeaderText));
                                ycell.FixedHeight = 25f;
                                ycell.BorderWidthBottom = 1f;
                                ycell.BorderWidthLeft = 0f;
                                ycell.BorderWidthRight = 0f;
                                ycell.BorderWidthTop = 0f;

                                // ycell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                                table.AddCell(ycell);
                            }

                            /*    cartlist.Columns
                                    .OfType<DataGridViewColumn>()
                                    .ToList()
                                    .ForEach(c => 
                                    c.BorderWidthBottom = 1f,
                                c.BorderWidthLeft= 0f,
                                c.BorderWidthRight = 0f,
                                c.BorderWidthTop = 0f,

                                    table.AddCell(c.Name)); */


                            /*    cartlist.Rows
                                   .OfType<DataGridViewRow>()
                                   .ToList()
                                   .ForEach(r =>
                                   {
                                       var cells = r.Cells.OfType<DataGridViewCell>().ToList();
                                       cells.ForEach(c => table.AddCell(c.Value.ToString()));
                                   }); */

                            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            //Adding DataRow
                            foreach (DataGridViewRow row in cartlist.Rows)
                            {
                                foreach (DataGridViewCell cellx in row.Cells)
                                {
                                    if (cellx.Value != null)
                                        table.AddCell(cellx.Value.ToString());
                                }
                            }

                            pdfDoc.Add(table);

                            var spacer3 = new Paragraph("TOTAL AMOUNT PAYABLE: ₹" + payablelabel.Text.Trim(), normalbold)
                            {

                                SpacingBefore = 10f,
                                SpacingAfter = 5f,

                            };
                            int savings;
                            savings = Int32.Parse(amountbox.Text.Trim()) - Int32.Parse(payablelabel.Text.Trim());
                            var spacer4 = new Paragraph("YOUR SAVINGS OVER MRP: ₹" + savings.ToString(), normalbold)
                            {

                                SpacingBefore = 5f,
                                SpacingAfter = 20f,

                            };
                            var spacer5 = new Paragraph("THANK YOU FOR VISITING LAFRESCO! HAVE A NICE DAY!", normalitalic)
                            {

                                SpacingBefore = 10f,
                                SpacingAfter = 10f,

                            };
                            spacer5.Alignment = Element.ALIGN_CENTER;

                            pdfDoc.Add(spacer3);
                            pdfDoc.Add(spacer4);
                            pdfDoc.Add(spacer5);


                            pdfDoc.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if(unregbtn.Checked)
                {
                    try
                    {
                        var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
                        string path = $"C:\\Users\\LENOVO\\Desktop\\Test.pdf";
                        PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
                        pdfDoc.Open();
                        var spacer = new Paragraph("")
                        {
                            SpacingBefore = 10f,
                            SpacingAfter = 10f,
                        };
                        iTextSharp.text.Font times = FontFactory.GetFont("TIMES_ROMAN", 25, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normal = FontFactory.GetFont("TIMES_ROMAN", 12);
                        iTextSharp.text.Font normalbold = FontFactory.GetFont("TIMES_ROMAN", 12, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font normalitalic = FontFactory.GetFont("FREESTYLE_SCRIPT", 10, iTextSharp.text.Font.ITALIC);
                        var spacer1 = new Paragraph("LA FRESCO - The IITI Facilitation Center", times)
                        {

                            SpacingBefore = 10f,
                            SpacingAfter = 10f,
                        };
                        pdfDoc.Add(spacer);
                        pdfDoc.Add(spacer);
                        spacer1.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(spacer1);

                        Chunk glue = new Chunk(new VerticalPositionMark());
                        Paragraph P = new Paragraph("BILL ID: " + bidbox.Text.Trim(), normal);
                        P.Add(new Chunk(glue));
                        P.Add("Date: " + DateTime.Now.ToString());
                        pdfDoc.Add(P);



                        //IMAGE

                        //var imagepath = @"C:\Users\Deepu\Desktop\thumb.png";
                        //using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                        //{
                        //   var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                        //  png.ScalePercent(5f);
                        // png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
                        //pdfDoc.Add(png);
                        //}



                        //pdfDoc.Add(spacer);


                        var spacer2 = new Paragraph("NAME: " + textBox1.Text.Trim(), normal)
                        {

                            SpacingBefore = 10f,
                            SpacingAfter = 10f,
                        };

                        pdfDoc.Add(spacer2);
                        pdfDoc.Add(spacer);

                        var columnCount = cartlist.ColumnCount;

                        var columnWidths = new[] { 0.75f, .75f, .75f, 0.75f };

                        var table = new PdfPTable(columnWidths)
                        {
                            HorizontalAlignment = Left,
                            WidthPercentage = 100,
                            DefaultCell = { MinimumHeight = 22f }
                        };

                        var cell = new PdfPCell(new Phrase("Product Details "))
                        {
                            Colspan = columnCount,
                            HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
                            MinimumHeight = 30f
                        };
                        cell.BorderWidthBottom = 1f;
                        cell.BorderWidthLeft = 0f;
                        cell.BorderWidthRight = 0f;
                        cell.BorderWidthTop = 1f;

                        table.AddCell(cell);

                        //Adding Header row
                        foreach (DataGridViewColumn column in cartlist.Columns)
                        {
                            PdfPCell ycell = new PdfPCell(new Phrase(column.HeaderText));
                            ycell.FixedHeight = 25f;
                            ycell.BorderWidthBottom = 1f;
                            ycell.BorderWidthLeft = 0f;
                            ycell.BorderWidthRight = 0f;
                            ycell.BorderWidthTop = 0f;

                            // ycell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                            table.AddCell(ycell);
                        }

                        /*    cartlist.Columns
                                .OfType<DataGridViewColumn>()
                                .ToList()
                                .ForEach(c => 
                                c.BorderWidthBottom = 1f,
                            c.BorderWidthLeft= 0f,
                            c.BorderWidthRight = 0f,
                            c.BorderWidthTop = 0f,

                                table.AddCell(c.Name)); */


                        /*    cartlist.Rows
                               .OfType<DataGridViewRow>()
                               .ToList()
                               .ForEach(r =>
                               {
                                   var cells = r.Cells.OfType<DataGridViewCell>().ToList();
                                   cells.ForEach(c => table.AddCell(c.Value.ToString()));
                               }); */

                        table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        //Adding DataRow
                        foreach (DataGridViewRow row in cartlist.Rows)
                        {
                            foreach (DataGridViewCell cellx in row.Cells)
                            {
                                if (cellx.Value != null)
                                    table.AddCell(cellx.Value.ToString());
                            }
                        }

                        pdfDoc.Add(table);

                        var spacer3 = new Paragraph("TOTAL AMOUNT PAYABLE: ₹" + payablelabel.Text.Trim(), normalbold)
                        {

                            SpacingBefore = 10f,
                            SpacingAfter = 5f,

                        };
                        int savings;
                        savings = Int32.Parse(amountbox.Text.Trim()) - Int32.Parse(payablelabel.Text.Trim());
                        var spacer4 = new Paragraph("YOUR SAVINGS OVER MRP: ₹" + savings.ToString(), normalbold)
                        {

                            SpacingBefore = 5f,
                            SpacingAfter = 20f,

                        };
                        var spacer5 = new Paragraph("THANK YOU FOR VISITING LAFRESCO! HAVE A NICE DAY!", normalitalic)
                        {

                            SpacingBefore = 10f,
                            SpacingAfter = 10f,

                        };
                        spacer5.Alignment = Element.ALIGN_CENTER;

                        pdfDoc.Add(spacer3);
                        pdfDoc.Add(spacer4);
                        pdfDoc.Add(spacer5);


                        pdfDoc.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            this.Refresh();
        }

        private void label21_Click(object sender, EventArgs e)
        {
        }

        private void customerlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            cartlist.DataSource = tcf.Select();
            try
            {
                var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
                string path = $"C:\\Users\\Deepu\\Desktop\\Test.pdf";
                PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
                pdfDoc.Open();
                var spacer1 = new Paragraph("LaFresco")
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f,
                };
                spacer1.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(spacer1);
                var imagepath = @"C:\Users\Deepu\Desktop\thumb.png";
                using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                {
                    var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                    png.ScalePercent(5f);
                    png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
                    pdfDoc.Add(png);
                }

                var spacer = new Paragraph("")
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f,
                };
                pdfDoc.Add(spacer);

                var headerTable = new PdfPTable(new[] { .75f, .75f })
                {
                    HorizontalAlignment = Left,
                    WidthPercentage = 75,
                    DefaultCell = { MinimumHeight = 22f }
                };

                headerTable.AddCell("Date");
                headerTable.AddCell(DateTime.Now.ToString());
                headerTable.AddCell("Bill Id:");
                headerTable.AddCell(bidbox.Text);
                headerTable.AddCell("Name:");
                headerTable.AddCell(textbox1.Text);
                headerTable.AddCell("Organisation:");
                headerTable.AddCell("IIT Indore");

                pdfDoc.Add(headerTable);
                pdfDoc.Add(spacer);

                var columnCount = cartlist.ColumnCount;
                var columnWidths = new[] { 0.75f, .75f, .75f, 0.75f };

                var table = new PdfPTable(columnWidths)
                {
                    HorizontalAlignment = Left,
                    WidthPercentage = 100,
                    DefaultCell = { MinimumHeight = 22f }
                };

                var cell = new PdfPCell(new Phrase("Bolt Summary"))
                {
                    Colspan = columnCount,
                    HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
                    MinimumHeight = 30f
                };

                table.AddCell(cell);

                /*   //Adding Header row
                   foreach (DataGridViewColumn column in cartlist.Columns)
                   {
                       PdfPCell ycell = new PdfPCell(new Phrase(column.HeaderText));
                      // ycell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                       table.AddCell(ycell);
                   } */

                cartlist.Columns
                    .OfType<DataGridViewColumn>()
                    .ToList()
                    .ForEach(c => table.AddCell(c.Name));


                /*    cartlist.Rows
                       .OfType<DataGridViewRow>()
                       .ToList()
                       .ForEach(r =>
                       {
                           var cells = r.Cells.OfType<DataGridViewCell>().ToList();
                           cells.ForEach(c => table.AddCell(c.Value.ToString()));
                       }); */

                //Adding DataRow
                foreach (DataGridViewRow row in cartlist.Rows)
                {
                    foreach (DataGridViewCell cellx in row.Cells)
                    {
                        if (cellx.Value != null)
                            table.AddCell(cellx.Value.ToString());
                    }
                }

                pdfDoc.Add(table);

                pdfDoc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void payablelabel_Click(object sender, EventArgs e)
        {

        }

        private void cartlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool ok = tcf.Delete(item_id2);
            if (ok)
            {
                DataTable dt4 = tcf.Select();
                cartlist.DataSource = dt4;
            }
            else
            {
                MessageBox.Show("Failed to remove!");
            }

            //copy pasted
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                string query = "select sum(price*quantity) from tempcart";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                DataTable dt5 = new DataTable();
                adapter.Fill(dt5);
                // total_amount = dt5.Rows[0].Field<float>(0);
                total_amount = float.Parse(dt5.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                total_amount = 0;
            }
            finally
            {
                conn.Close();
            }
            
            amountbox.Text = total_amount.ToString();
        }
    }
}
