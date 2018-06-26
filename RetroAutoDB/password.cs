using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroAutoDB
{
    public partial class password : Form
    {
        public StartScreen loadingform1;
        public adminForm adminForm1;
        public password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TXT_password.Text == "admin")
            {
                this.Hide();
                adminForm1 = new adminForm();
                adminForm1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect password", "", MessageBoxButtons.OKCancel);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loadingform1 = new StartScreen();
            loadingform1.ShowDialog();
        }
    }
}
