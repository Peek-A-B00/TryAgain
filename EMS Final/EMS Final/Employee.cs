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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\EMS Final\Data\EMSFinalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        // Connection String


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Insert
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmailTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "" || NIDTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into EmployeeTbl values('"+EmpIdTb.Text+"','"+EmpNameTb.Text+"','"+EmailTb.Text+"','"+AddressTb.Text+"','"+GenderCb.SelectedItem.ToString()+"','"+PhoneTb.Text+"','"+NIDTb.Text+"','"+DepartmentCb.SelectedItem.ToString()+"','"+EMPPosCb.SelectedItem.ToString()+ "','"+DateTb.Value.Date+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    Con.Close();
                    populate();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Select from DataGridView
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = this.EmpDGV.Rows[e.RowIndex];
                EmpIdTb.Text = row.Cells["EmpId"].Value.ToString();
                EmpNameTb.Text = row.Cells["EmpName"].Value.ToString();
                EmailTb.Text = row.Cells["Email"].Value.ToString();
                AddressTb.Text = row.Cells["Address"].Value.ToString();
                GenderCb.Text = row.Cells["Gender"].Value.ToString();
                PhoneTb.Text = row.Cells["Phone"].Value.ToString();
                NIDTb.Text = row.Cells["NID"].Value.ToString();
                DepartmentCb.Text = row.Cells["Department"].Value.ToString();
                EMPPosCb.Text = row.Cells["EMPPos"].Value.ToString();
                DateTb.Text= row.Cells["Date"].Value.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void populate()
        {
            //DataGridView
            Con.Open();
            string query = "select *from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete
            if(EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter The Employee ID");
            }   
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from EmployeeTbl where EmpId ='" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    Con.Close();
                    populate();

                }catch(Exception Ex)
                { 
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmailTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "" || NIDTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update EmployeeTbl set EmpName='"+EmpNameTb.Text+"',Email='"+EmailTb.Text+ "',Address = '"+AddressTb.Text+"',Gender = '"+GenderCb.SelectedItem.ToString()+"',Phone = '"+PhoneTb.Text+"',NID = '"+NIDTb.Text+"',Department = '"+DepartmentCb.SelectedItem.ToString()+"',EMPPos = '"+EMPPosCb.SelectedItem.ToString()+ "',Date='"+DateTb.Value.Date+"' where EmpId = '"+EmpIdTb.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
                    Con.Close();
                    populate();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmpIdTb.Clear();
            EmpNameTb.Clear();
            EmailTb.Clear();
            AddressTb.Clear();
            GenderCb.Text = string.Empty;
            PhoneTb.Clear();
            NIDTb.Clear();
            DateTb.Text = string.Empty;                          
            DepartmentCb.Text = string.Empty;
            EMPPosCb.Text = string.Empty;

        }

        private void EmpIdTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
