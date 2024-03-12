using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tubewell
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns[0].HeaderCell.Style.Font = new Font("Arial", 20, FontStyle.Bold  ); // Change "Arial" and 14 to your desired font and size
            dataGridView1.Columns[1].HeaderCell.Style.Font = new Font("Arial", 20,FontStyle.Bold); // Change "Arial" and 14 to your desired font and size
            dataGridView1.Columns[2].HeaderCell.Style.Font = new Font("Arial", 20, FontStyle.Bold); // Change "Arial" and 14 to your desired font and size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            

        }

        // for checking




        //this is a utility static class
        public static class Utility
        {


            public static void fitFormToScreen(Form form, int h, int w)
            {

                //scale the form to the current screen resolution
                form.Height = (int)((float)form.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                form.Width = (int)((float)form.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                //here font is scaled like width
               // form.Font = new Font(form.Font.FontFamily, form.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                foreach (Control item in form.Controls)
                {
                    FitControlsToScreen(item, h, w);
                }

                
            }

            static void FitControlsToScreen(Control cntrl, int h, int w)
            {
                if (Screen.PrimaryScreen.Bounds.Size.Height != h)
                {

                    cntrl.Height = (int)((float)cntrl.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                    cntrl.Top = (int)((float)cntrl.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));

                }
                if (Screen.PrimaryScreen.Bounds.Size.Width != w)
                {

                    cntrl.Width = (int)((float)cntrl.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
                    cntrl.Left = (int)((float)cntrl.Left * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                   // cntrl.Font = new Font(cntrl.Font.FontFamily, cntrl.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                }

                foreach (Control item in cntrl.Controls)
                {
                    FitControlsToScreen(item, h, w);
                }
            }
        }


        //inside form load event
        //send the width and height of the screen you designed the form for

        






















        // for checkin

        private string originalText ="                        ❤C҉h҉i҉s҉h҉t҉i҉     W҉e҉l҉l҉     f҉o҉r҉     S҉p҉r҉e҉a҉d҉i҉n҉g҉     G҉r҉e҉e҉n҉e҉r҉y❤️ ";//for making text movement in textbox
        private int currentPosition = 0; // for making text movement in textbox


        public Double Cost_of_items()
        {
            Double sum = 0;
            int i = 0;
            for (i = 0; i < (dataGridView1.Rows.Count);
                i++)
            {
                sum=sum+ Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }
            return sum;
        }
        Double totleAmount;
        private void AddCost()
        {
            Double tax, q;
            tax = 0;
            if(dataGridView1.Rows.Count > 0) 
            {
                Tax.Text = ((Cost_of_items() * tax) / 100).ToString();
                SubTotal.Text = (Cost_of_items()).ToString();
                q = ((Cost_of_items() * tax) / 100);
                //Total.Text= string.Format(Cost_of_items()+q);
                totleAmount = Cost_of_items() + q;
                Total.Text= totleAmount.ToString();


                BarCode1.Text = Convert.ToString(q + (Cost_of_items()));
             
            }
        }
        Double remaingAmount;
        Double recevied_amount;
        private void Change1()
        {

            Double tax, q;
            tax = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                q = ((Cost_of_items() * tax) / 100) + Cost_of_items();
                recevied_amount = Convert.ToInt32(Cash.Text);
                remaingAmount = recevied_amount - q;
                BtnChange.Text = remaingAmount.ToString();

            }
        }

        Bitmap bitmap;
        int data_grid_view;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            customerName = Customer_Name_Textbox.Text;


            // Check if customerName is not empty (you can add additional validation if needed)
            if (!string.IsNullOrWhiteSpace(customerName))
            {
                // Set the flag to true
                entryButtonClicked = true;
            }
            else
            {
                // Display a message or take action to inform the user that customer name is required.
                MessageBox.Show("Customer name is required in textBox");
            }
            data_grid_view = dataGridView1.Rows.Count;
            if(data_grid_view>0&data_grid_view<=5)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 800);
            }
            if (data_grid_view > 5 & data_grid_view <= 10)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 800);
            }
            if (data_grid_view > 10 & data_grid_view <= 15)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1000);
            }
            if (data_grid_view > 15 & data_grid_view <= 20)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1200);
            }
            if (data_grid_view > 20 & data_grid_view <= 30)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1500);
            }
            if (data_grid_view > 30 & data_grid_view <= 40)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1700);
            }
            if (data_grid_view > 40 & data_grid_view <= 50)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1900);
            }
            if (entryButtonClicked )
            {
                try
                {
                    int height = dataGridView1.Height;
                    dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                    bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                    dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                    printPreviewButton.PrintPreviewControl.Zoom = 1;
                    printPreviewButton.ShowDialog();
                    dataGridView1.Height = height;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                entryButtonClicked = false;

               
            }
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Cash.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            Utility.fitFormToScreen(this, Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
            this.CenterToScreen();
            cboPayment.Items.Add("نقد");
           
            cboPayment.Items.Add("ادھار");
            cboPayment.SelectedIndex = 1;
            
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           

            if (cboPayment.Text== "ادھار")
            {
                e.Graphics.DrawString("نقد/ادھار : ادھار ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(228, 42));
            }
            else
            {
                e.Graphics.DrawString("نقد/ادھار : نقد", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(245, 42));
            }
            Graphics g = e.Graphics;
            // Define fonts and brushes
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            // Draw the customer name on the page
            g.DrawString("گاہک کا نام :"+ customerName,new Font("Arial", 18, FontStyle.Bold), brush, 5, 86);


            e.Graphics.DrawString(" تفصیل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(170, 261));
            e.Graphics.DrawString("_________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(-1, 227));
            
            e.Graphics.DrawString("_________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(-1, 90));
            e.Graphics.DrawString("_________________________", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(-1, 45));
            e.Graphics.DrawString("ٹوٹل                      :       " + totleAmount.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(5, 128));
            e.Graphics.DrawString("گاہک سے وصول کردہ :       " + recevied_amount.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(5, 169));
            
            if(remaingAmount>0)
            {
                e.Graphics.DrawString("گاہک کو واپس کردہ رقم   :       " + remaingAmount.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(5, 213));
            }
          
            if(recevied_amount==0)
            {
                e.Graphics.DrawString("گاہک  کے نام           :        " + totleAmount.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(5, 213));
            }
            if(remaingAmount<0)
            {
                e.Graphics.DrawString("گاہک  کے نام           :        " + remaingAmount.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(5, 213));
            }
            e.Graphics.DrawString("_________________________" ,  new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(-1, 6));
            e.Graphics.DrawString("❤C҉h҉i҉s҉h҉t҉i҉ W҉e҉l҉l҉ f҉o҉r҉ S҉p҉r҉e҉a҉d҉i҉n҉g҉ G҉r҉e҉e҉n҉e҉r҉y❤️ ", new Font("Arial", 14, FontStyle.Bold), Brushes.Green, new Point(2, 3));
            e.Graphics.DrawString("Date :" + DateTime.Now.ToShortDateString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(5, 42));
            // Load an image from a file
             Image imageToPrint = Image.FromFile("C:\\Program Files (x86)\\Default Company Name\\tubewell\\new.jpg");
                
            if (data_grid_view > 0 & data_grid_view <= 1)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 380));
                Rectangle imageRect = new Rectangle(0, 415, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 645));
                e.Graphics.DrawString("Developer : M. ilyas  ایک بندہ  ناچیز", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 665));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 695));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 710));

                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
               
            }
            if (data_grid_view > 1 & data_grid_view <= 2)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 400));
                Rectangle imageRect = new Rectangle(0, 445, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 675));
                e.Graphics.DrawString("Developer : M. ilyas ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 695));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 725));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 740));


                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 2 & data_grid_view <= 3)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 438));
                Rectangle imageRect = new Rectangle(0, 475, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 705));
                e.Graphics.DrawString("Developer : M. ilyas ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 725));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 755));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 770));



                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 3 & data_grid_view <= 4)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 480));
                Rectangle imageRect = new Rectangle(0, 515, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 745));
                e.Graphics.DrawString("Developer : M. ilyas ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 765));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 795));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 810));


                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 4 & data_grid_view <= 5)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 530));
                Rectangle imageRect = new Rectangle(0, 575, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 805));
                e.Graphics.DrawString("Developer : M. ilyas ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 825));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 855));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 870));


                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 5 & data_grid_view <= 6)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 590));
                Rectangle imageRect = new Rectangle(0, 635, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 865));
                e.Graphics.DrawString("Developer : M. ilyas ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 885));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 915));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 930));

                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 6 & data_grid_view <= 7)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 640));
                Rectangle imageRect = new Rectangle(0, 685, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 915));
                
                e.Graphics.DrawString("Developer :  M. ilyas ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 935));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 965));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 980));

                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 7 & data_grid_view <= 8)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 690));
                Rectangle imageRect = new Rectangle(0, 735, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 965));
                e.Graphics.DrawString("Developer :  M. ilyas ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 985));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 1015));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 1025));

                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 8 & data_grid_view <= 9)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 740));
                Rectangle imageRect = new Rectangle(0, 785, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 1015));
                e.Graphics.DrawString("Developer : M. ilyas )", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 1035));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 1065));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 1080));


                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            if (data_grid_view > 9 & data_grid_view <= 10)
            {
                e.Graphics.DrawString("تاڈا اپنا ٹیوب ویل ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(150, 760));
                Rectangle imageRect = new Rectangle(0, 835, 400, 230);
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 1065));
                e.Graphics.DrawString("Developer : M. ilyas )", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(1, 1085));
                e.Graphics.DrawString("For Software Development: 03420630163 (OR) 03447032963\r\n", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(1, 1115));
                e.Graphics.DrawString("***********************************", new Font("Arial", 20, FontStyle.Regular), Brushes.Red, new Point(-1, 1130));

                // Draw the image on the page
                e.Graphics.DrawImage(imageToPrint, imageRect);
            }
            try
            {

                 e.Graphics.DrawImage(bitmap, 0, 296);
             }


             catch (Exception ex)
             {

                 MessageBox.Show(ex.Message);
             }
           

        }

        private void btnReset_Click(object sender, EventArgs e)

        {
           

            try {
                BtnChange.Text = "0";
                BarCode1.Text = "";
                Cash.Text = "0";
                SubTotal.Text = "0";
                Tax.Text = "0";
                Total.Text = "0";
                dataGridView1.Rows.Clear();
                cboPayment.Text = "";
                Customer_Name_Textbox.Text="";
                // checked
                remaingAmount = 0;
                recevied_amount = 0;
                Customer_Name_Textbox.Clear();
                BtnChange.Text = "0";
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b =(Button)sender;   
            if(Cash.Text=="0")
            {
                Cash.Text = "0";
                Cash.Text = b.Text;
            }
            else if(Cash.Text==".") 
            {
                if (! b.Text.Contains("."))
                {
                    Cash.Text = Cash.Text + b.Text;

                }
                

            }
            else
                Cash.Text = Cash.Text + b.Text;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
           

            if (cboPayment.Text == "نقد")
            {
                if(Cash.Text != "0")
                {
                    Change1();
                    AddCost();
                }
            }
            else if(cboPayment.Text== "ادھار")
            {
                if (Cash.Text != "0")
                {
                    Change1();
                    AddCost();
                }
            }
            else
            {
                BtnChange.Text = "0";

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();

            if (cboPayment.Text == "Cash")
            {
                Change1();
            }
            else
            {
                BtnChange.Text = "0";
                Cash.Text = "0";

            }
        }

        private void ghanta1_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size
            
            Double ghanta = 1100;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if((bool)(row.Cells[0].Value = "گھنٹہ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value+1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta;
                }
                

            }
            dataGridView1.Rows.Add("گھنٹہ", ghanta); 
            AddCost();

        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AddCost();
        }
         private string customerName = "";
        bool entryButtonClicked = false;

        private void entryButton_Click(object sender, EventArgs e)
        {// Get the customer name from the TextBox
        /*     customerName = Customer_Name_Textbox.Text;

            // Check if customerName is not empty (you can add additional validation if needed)
            if (!string.IsNullOrWhiteSpace(customerName))
            {
                // Set the flag to true
                entryButtonClicked = true;
            }
            else
            {
                // Display a message or take action to inform the user that customer name is required.
                MessageBox.Show("Customer name is required in textBox");
            }
          */ 
        }

        private void printPreviewButton_Load(object sender, EventArgs e)
        {
           
            
            if (data_grid_view > 0 & data_grid_view <= 1)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 720);
            }
            if (data_grid_view > 1 & data_grid_view <= 2)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 750);
            }
            if (data_grid_view > 2 & data_grid_view <= 3)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 780);
            }
            if (data_grid_view > 3 & data_grid_view <= 4)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 820);
            }
            if (data_grid_view > 4 & data_grid_view <= 5)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 880);
            }
            if (data_grid_view > 5 & data_grid_view <= 6)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 940);
            }
            if (data_grid_view > 6 & data_grid_view <= 7)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 990);
            }
            if (data_grid_view > 7 & data_grid_view <= 8)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1035);
            }
            if (data_grid_view >8 & data_grid_view <= 9)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1090);
            }
            if (data_grid_view > 9 & data_grid_view <= 10)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1140);
            }
            if (data_grid_view > 10 & data_grid_view <= 20)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 1500);
            }

           
        }


        private void ghanta2_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta2 = 2200;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "دو گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta2;
                }

            }
            dataGridView1.Rows.Add("دو گھنٹے", ghanta2);
            AddCost();
        }
  private void timer1_Tick(object sender, EventArgs e) // for making text movement in textbox
        {
            if (currentPosition < originalText.Length)
            {
                textBox2.Text = originalText.Substring(currentPosition); // + originalText.Substring(0, currentPosition);
                currentPosition++;
            }
            else
            {
                currentPosition = 0;
                textBox2.Text = originalText;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void previousAmount_MouseHover(object sender, EventArgs e)
        {
            previousAmount.BackColor = System.Drawing.Color.OrangeRed;
           
        }

        private void previousAmount_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Preious_Amount = 0;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "سابقہ بقایا"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Preious_Amount;
                }

            }
            dataGridView1.Rows.Add("سابقہ بقایا", Preious_Amount);
            AddCost();
        }

        private void previousAmount_MouseLeave(object sender, EventArgs e)
        {
            previousAmount.BackColor = SystemColors.Window;
        }

        private void ghanta3_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta3 = 3300;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "تین گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta3;
                }

            }
            dataGridView1.Rows.Add("تین گھنٹے", ghanta3);
            AddCost();
        }

        private void ghanta4_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta4 = 4400;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "چار گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta4;
                }

            }
            dataGridView1.Rows.Add("چار گھنٹے", ghanta4);
            AddCost();

        }

        private void ghanta6_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta6 = 6600;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "چھ گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta6;
                }

            }
            dataGridView1.Rows.Add("چھ گھنٹے", ghanta6);
            AddCost();

        }

        private void ghanta7_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta7 = 7700;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "سات گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta7;
                }

            }
            dataGridView1.Rows.Add("سات گھنٹے", ghanta7);
            AddCost();

        }

        private void ghanta8_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta8 = 8800;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "آٹھ گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta8;
                }

            }
            dataGridView1.Rows.Add("آٹھ گھنٹے", ghanta8);
            AddCost();
        }

        private void ghanta9_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta9 = 9900;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "نو گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta9;
                }

            }
            dataGridView1.Rows.Add("نو گھنٹے", ghanta9);
            AddCost();
        }

        private void ghanta10_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta10 = 11000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "دس گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta10;
                }

            }
            dataGridView1.Rows.Add("دس گھنٹے", ghanta10);
            AddCost();

        }

        private void mint55_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint55 = 1008;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 55 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint55;
                }

            }
            dataGridView1.Rows.Add("55 منٹ ", mint55);
            AddCost();

        }
        
        private void mint50_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint50 = 916;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 50 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint50;
                }

            }
            dataGridView1.Rows.Add("50 منٹ ", mint50);
            AddCost();

        }

        private void mint45_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint45 = 825;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 45 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint45;
                }

            }
            dataGridView1.Rows.Add("45 منٹ ", mint45);
            AddCost();


        }

        private void mint40_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint40 = 733;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 40 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint40;
                }

            }
            dataGridView1.Rows.Add("40 منٹ ", mint40);
            AddCost();

        }

        private void mint35_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint35 = 641;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 35 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint35;
                }

            }
            dataGridView1.Rows.Add("35 منٹ ", mint35);
            AddCost();

        }

        private void mint30_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint30 = 550;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 30 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint30;
                }

            }
            dataGridView1.Rows.Add("30 منٹ ", mint30);
            AddCost();

        }

        private void mint25_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint25 = 458;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 25 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint25;
                }

            }
            dataGridView1.Rows.Add("25 منٹ ", mint25);
            AddCost();

        }

        private void mint20_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint20 = 366;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 20 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint20;
                }

            }
            dataGridView1.Rows.Add("20 منٹ ", mint20);
            AddCost();


        }

        private void mint15_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint15= 275;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 15 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint15;
                }

            }
            dataGridView1.Rows.Add("15 منٹ ", mint15);
            AddCost();

        }

        private void mint10_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint10 = 183;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 10 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint10;
                }

            }
            dataGridView1.Rows.Add("10 منٹ ", mint10);
            AddCost();

        }

        private void mint5_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double mint5 = 91;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " 5 منٹ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * mint5;
                }

            }
            dataGridView1.Rows.Add("5 منٹ ", mint5);
            AddCost();

        }

        private void ghanta1_5_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Ghanta1_5 = 1650;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " ڈیڑھ گھنٹہ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Ghanta1_5;
                }

            }
            dataGridView1.Rows.Add("ڈیڑھ گھنٹہ ", Ghanta1_5);
            AddCost();

        }

        private void ghanta2_5_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Ghanta2_5 = 2750;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " اڑھائی گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Ghanta2_5;
                }

            }
            dataGridView1.Rows.Add("اڑھائی گھنٹے ", Ghanta2_5);
            AddCost();

        }

        private void ghanta3_5_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Ghanta3_5 = 3850;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = " ساڑھے تین گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Ghanta3_5;
                }

            }
            dataGridView1.Rows.Add("ساڑھے تین گھنٹے ", Ghanta3_5);
            AddCost();


        }

        private void ghanta4_5_Click(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Ghanta4_5 = 4950;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ساڑھے چار گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Ghanta4_5;
                }

            }
            dataGridView1.Rows.Add("ساڑھے چار گھنٹے ", Ghanta4_5);
            AddCost();


        }

        private void ghanta5_5_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Ghanta5_5 = 6050;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ساڑھے پانچ گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Ghanta5_5;
                }

            }
            dataGridView1.Rows.Add("ساڑھے پانچ گھنٹے ", Ghanta5_5);
            AddCost();
        }

        
        


        private void ghanta5_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double ghanta5 = 5500;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "پانچ گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * ghanta5;
                }

            }
            dataGridView1.Rows.Add("پانچ گھنٹے", ghanta5);
            AddCost();

        }

        private void ghanta6_5_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Ghanta6_5 = 7150;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ساڑھے چھ گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Ghanta6_5;
                }

            }
            dataGridView1.Rows.Add("ساڑھے چھ گھنٹے ", Ghanta6_5);
            AddCost();
        }

        private void ghanta7_5_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Change "Arial" and 12 to your desired font and size

            Double Ghanta7_5 = 8250;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ساڑھے سات گھنٹے"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * Ghanta7_5;
                }

            }
            dataGridView1.Rows.Add("ساڑھے سات گھنٹے ", Ghanta7_5);
            AddCost();
        }

        private void btnPay_MouseHover(object sender, EventArgs e)
        {
            btnPay.BackColor = System.Drawing.Color.OrangeRed;

        }

        private void btnPay_MouseLeave(object sender, EventArgs e)
        {
            btnPay.BackColor = System.Drawing.Color.White;

        }

        private void btnPrint_MouseHover(object sender, EventArgs e)
        {
            btnPrint.BackColor = System.Drawing.Color.OrangeRed;

        }

        private void btnPrint_MouseLeave(object sender, EventArgs e)
        {
            btnPrint.BackColor = System.Drawing.Color.White;

        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            btnReset.BackColor = System.Drawing.Color.Lime;

        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            btnReset.BackColor = System.Drawing.Color.White;

        }

        private void btnRemove_MouseHover(object sender, EventArgs e)
        {
            btnRemove.BackColor = System.Drawing.Color.Lime;

        }

        private void btnRemove_MouseLeave(object sender, EventArgs e)
        {
            btnRemove.BackColor = System.Drawing.Color.White;

        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnClear.BackColor = System.Drawing.Color.Lime;

        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = System.Drawing.Color.White;

        }

        private void Customer_Name_Textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
