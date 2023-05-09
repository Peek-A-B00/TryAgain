using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_Final
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UserTb.Text =="" || PassTb.Text=="")
            {
                MessageBox.Show("Enter User Name and Password");

            }else if(UserTb.Text=="Admin" ||  PassTb.Text=="admin123")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Invalid User Name Or Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(UserTb.Text !="" || PassTb.Text !="")
            {
                UserTb.Clear();
                PassTb.Clear();
            }
        }

        private void ExTb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
