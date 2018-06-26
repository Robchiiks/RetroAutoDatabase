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
    public partial class StartScreen : Form
    {
        public userForm userForm1;
        public password loginform1;
        public StartScreen()
        {
            InitializeComponent();
        }
        private void Admin_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform1 = new password();
            loginform1.ShowDialog();
        }

        private void user_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            userForm1 = new userForm();
            userForm1.ShowDialog();
        }
    }
}
