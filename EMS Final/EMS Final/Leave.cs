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
    public partial class Leave : Form
    {
        public Leave()
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
            EmpIdCb.ValueMember = "EmpId";
            EmpIdCb.DataSource = dt;
            Con.Close();
        }
        private void GetEmpName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select *from EmployeeTbl where EmpId=@EID", Con);
            cmd.Parameters.AddWithValue("@EID", EmpIdCb.SelectedValue.ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
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
            string query = "select *from LeaveTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LeaveDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            LeaveCb.SelectedIndex = -1;
            EmpIdCb.SelectedIndex = -1;
            EmpNameTb.Text = "";
        }

        private void EmpIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetEmpName();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if ( EmpNameTb.Text == "" ||LeaveCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into LeaveTbl values('" + EmpIdCb.SelectedValue.ToString() + "','" + EmpNameTb.Text + "','" + LeaveCb.SelectedItem.ToString() + "','" + SDate.Value.Date + "','" + EDate.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Leave Recorded");
                    Con.Close();
                    DisplayAttendance();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void LeaveDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.LeaveDGV.Rows[e.RowIndex];
                EmpIdCb.Text = row.Cells["EmpID"].Value.ToString();
                EmpNameTb.Text = row.Cells["EmpName"].Value.ToString();
                LeaveCb.Text = row.Cells["LeaveType"].Value.ToString();
                SDate.Text = row.Cells["SDate"].Value.ToString();
                EDate.Text = row.Cells["EDate"].Value.ToString();

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (EmpNameTb.Text == "" || LeaveCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update LeaveTbl set EmpName='" + EmpNameTb.Text + "',LeaveType = '" + LeaveCb.SelectedItem.ToString() + "',SDate='" + SDate.Value.Date + "',EDate='" + EDate.Value.Date + "'where EmpId = '" + EmpIdCb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Records Updated Successfully");
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

        private void label6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Leave_Load(object sender, EventArgs e)
        {

        }
    }
}
