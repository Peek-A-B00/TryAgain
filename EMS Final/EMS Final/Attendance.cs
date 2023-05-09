using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMS_Final
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
            DisplayAttendance();
            FillEmpId();
        }
        private void FillEmpId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select EmpId from EmployeeTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId");
            dt.Load(rdr);
            EmpIDCb.ValueMember = "EmpId";
            EmpIDCb.DataSource = dt;
            Con.Close();
        }
        private void GetEmpName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select *from EmployeeTbl where EmpID=@EID",Con);
            cmd.Parameters.AddWithValue("@EID",EmpIDCb.SelectedValue.ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                EmpNameTb.Text = dr["EmpName"].ToString();

            }

            Con.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\EMS Final\Data\EMSFinalDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayAttendance()
        {
            //DataGridView
            Con.Open();
            string query = "select *from AttendanceTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AttendanceDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            AttStatusCb.SelectedIndex = -1;
            EmpIDCb.SelectedIndex = -1;
            EmpNameTb.Text = "";
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UserTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
           if(EmpIDCb.Text == "" || EmpNameTb.Text =="" || AttDatePicker.Text=="" || AttStatusCb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
           else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AttendanceTbl values('" + EmpIDCb.SelectedValue.ToString() + "','" + EmpNameTb.Text + "','" + AttDatePicker.Value.Date + "','" + AttStatusCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Taken");
                    Con.Close();
                    DisplayAttendance();
                    Reset();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EmpIDCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetEmpName();
        }
        int Key = 0;
        private void AttendanceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.AttendanceDGV.Rows[e.RowIndex];
                EmpIDCb.Text = row.Cells["EmpID"].Value.ToString();
                EmpNameTb.Text = row.Cells["EmpName"].Value.ToString();
                AttDatePicker.Text = row.Cells["AttDate"].Value.ToString();
                AttStatusCb.Text = row.Cells["AttStatus"].Value.ToString();
                
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (EmpNameTb.Text == "" || AttStatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update AttendanceTbl set EmpName='" + EmpNameTb.Text + "',AttDate='" + AttDatePicker.Value.Date + "',AttStatus = '" + AttStatusCb.SelectedItem.ToString() + "'where EmpID = '"+EmpIDCb.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Updated Successfully");
                    Con.Close();
                    DisplayAttendance();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {

        }
    }     
}
