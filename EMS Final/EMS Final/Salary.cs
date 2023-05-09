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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\EMS Final\Data\EMSFinalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void EmailTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void EMPPosCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void fatchempData()
        {
            if (EmpIdTb.Text == "")
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
                    //EmpIdTb.Text = dr["EmpId"].ToString();
                    EmpNameTb.Text = dr["EmpName"].ToString();
                    EmailTb.Text = dr["Email"].ToString();
                    EMPPosTb.Text = dr["EMPPos"].ToString();
                }
                Con.Close();
            }
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fatchempData();
        }
        int DailyBase,total;

        private void label23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmpIdTb.Clear();                                                                
            EmpNameTb.Clear();
            EmailTb.Clear();
            EMPPosTb.Clear();
            WorkedTb.Clear();
            SalarySlip.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======= Salary Document =======", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkMagenta, new Point(140));
            e.Graphics.DrawString("Employee ID:     " + EmpIdTb.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 140));
            e.Graphics.DrawString("Employee Name:    " + EmpNameTb.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 180));
            e.Graphics.DrawString("Employee Name: " +EmpNameTb.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 220));
            e.Graphics.DrawString("Employee Position:   " + EMPPosTb.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 260));
            e.Graphics.DrawString("Worked Days:        " + WorkedTb.Text, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 300));
            e.Graphics.DrawString("Salary Per  Day:    " + DailyBase, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 300));
            e.Graphics.DrawString("Total Amount Tk:   " + total, new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Purple, new Point(20, 300));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(EMPPosTb.Text=="")
            {
                MessageBox.Show("Select An Employee");
            }else if(WorkedTb.Text=="" || Convert.ToInt32(WorkedTb.Text)>30) 
            {
                MessageBox.Show("Enter a valid  Number of Days");
            }
            else
            {
                if(EMPPosTb.Text== "Chief Information Officer")
                {
                    DailyBase = 2500;
                }else if(EMPPosTb.Text == "Chief Operating Officer")
                {
                    DailyBase = 2500;
                }
                else if(EMPPosTb.Text== "CTO")
                {
                    DailyBase = 2500;
                }
                else if(EMPPosTb.Text== "Manager")
                {
                    DailyBase = 1500;
                }
                else if(EMPPosTb.Text== "Receptionist")
                {
                    DailyBase = 500;
                }
                else if (EMPPosTb.Text == "Systems Administrator")
                {
                    DailyBase = 3000;
                }
                else if (EMPPosTb.Text == "Software Engineer")
                {
                    DailyBase = 2000;
                }
                else 
                {
                    DailyBase = 2300;
                }
                total = DailyBase * Convert.ToInt32(WorkedTb.Text);
                SalarySlip.Text = "Employee ID:     "+EmpIdTb.Text + "\n\n" +"Employee Name:    " +EmpNameTb.Text +"\n\n"+"Email:           "+EmailTb.Text+"\n\n"+"Employee Position:   "+EMPPosTb.Text+"\n\n"+"Worked Days:        "+WorkedTb.Text+"\n\n"+"Salary Per  Day:    "+DailyBase+"\n\n"+"Total Amount Tk:   "+total ;
            }
        }
    }
}
