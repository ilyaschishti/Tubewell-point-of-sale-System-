using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tubewell
{
    public partial class Please_Login : Form
    {
        public Please_Login()
        {
            InitializeComponent();
            


        }
        public static class Utility
        {


            public static void FitFormToScreen(Form form, int h, int w)
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






        private void btnLogin_Click(object sender, EventArgs e)

        {
            string user = txtUserName.Text;
            string pwd = txtPassword.Text;
            if (user == "admin" &&  pwd == "c143")
            {

                

                lebel_messgage.Text = "Congratulations You have logged in Successfully! \U0001f970\r\n";
                lebel_messgage.ForeColor = System.Drawing.Color.Green;
                MessageBox.Show("Press Enter key!");
                using (Form1 a = new Form1())

                {
                    
                   
                    a.ShowDialog();
                    
                }
                this.Close();
            }
            else
            {
                lebel_messgage.Text = "The Username or Password is incorrect, try Again! 🙁\r\n";
                lebel_messgage.ForeColor = System.Drawing.Color.DarkRed;
                txtUserName.Clear();
                txtPassword.Clear();
                

            }

        }


      

        private void btnClear_field_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
           
        }

        
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Please_Login_Load(object sender, EventArgs e)
        {
            Utility.FitFormToScreen(this, Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
            this.CenterToScreen();
        }
    }
}
