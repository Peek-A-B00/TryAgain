using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMS_Final
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\EMS Final\Data\EMSFinalDB.mdf"";Integrated Security=True;Connect Timeout=30");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EmpIdTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void fatchempData()
        {
            if(EmpIdTb.Text=="")
            {
                MessageBox.Show("Enter Employee Id");
            }
            else
            {
                Con.Open();
                string query = "select *from EmployeeTbl where EmpId='" + EmpIdTb.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    EmpIdlbl.Text = dr["EmpId"].ToString();
                    EmpNamelbl.Text = dr["EmpName"].ToString();
                    Emaillbl.Text = dr["Email"].ToString();
                    Addresslbl.Text = dr["Address"].ToString();
                    Genderlbl.Text = dr["Gender"].ToString();
                    Phonelbl.Text = dr["Phone"].ToString();
                    NIDlbl.Text = dr["NID"].ToString();
                    Departmentlbl.Text = dr["Department"].ToString();
                    EMPPoslbl.Text = dr["EMPPos"].ToString();
                    Datelbl.Text = dr["Date"].ToString();
                    EmpIdlbl.Visible = true;
                    EmpNamelbl.Visible = true;
                    Emaillbl.Visible = true;
                    Addresslbl.Visible = true;
                    Genderlbl.Visible = true;
                    Phonelbl.Visible = true;
                    NIDlbl.Visible = true;
                    Departmentlbl.Visible = true;
                    EMPPoslbl.Visible = true;
                    Datelbl.Visible = true;
                }
                Con.Close();
            }
            
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Departmentlbl_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Phonelbl_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EmpNamelbl_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            fatchempData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======= EMPLOYEE SUMMERY =======", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkMagenta, new Point(140));
            e.Graphics.DrawString("Employee Id : " + EmpIdlbl.Text +"\t Employee Name :" + EmpNamelbl.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20,140));
            e.Graphics.DrawString("Email : " + Emaillbl.Text + "\t\tAddress :" + Addresslbl.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 180));
            e.Graphics.DrawString("Gender : " + Genderlbl.Text + "\t\tPhone :" + Phonelbl.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 220));
            e.Graphics.DrawString("NID : " + NIDlbl.Text + "\t\tDate OF Birth :" + Datelbl.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 260));
            e.Graphics.DrawString("Department : " + Departmentlbl.Text + "\t Position :" + EMPPoslbl.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 300));
        }
    }
}
