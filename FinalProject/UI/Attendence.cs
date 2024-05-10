using FinalProject.BL;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
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

namespace FinalProject.UI_Forms
{
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker1.Value = DateTime.Now;
            comboBox2.SelectedIndex = 0;
            promptData();
        }
        void promptData()
        {
            // here we will mark the attendance of employees
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, FName, Email, Contact from Employees", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            AttendenceDG.DataSource = dataTable;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Select Previous Attendance
            comboBox1.Items.Clear();
            var c = Configuration.getInstance().getConnection();
            SqlCommand cm = new SqlCommand("SELECT Date, Shift FROM Attendances", c);
            SqlDataAdapter d = new SqlDataAdapter(cm);
            DataTable dataTable = new DataTable();
            d.Fill(dataTable);
            //List<string> columnEntries = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime dateValue = (DateTime)row["Date"];
                string dateString = dateValue.ToString("yyyy-MM-dd");
                dateString += "," + row["Shift"];
                comboBox1.Items.Add(dateString);
            }
            comboBox1.SelectedIndex = 0;

            button1.Visible = true;
            comboBox1.Visible = true;
            button4.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Choose Attendance Date
            button2.Visible = true;
            dateTimePicker1.Visible = true;
            comboBox2.Visible = true;
            button4.Visible = false;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            comboBox1.Visible = false;
            button4.Visible = true;
            button3.Visible = true;

            string date = comboBox1.Text;
            int id = returnAttendanceId(date);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT e.Status Stat, m.Id, m.Name, m.FName, m.Email, m.Contact FROM Attendances a JOIN EmployeeAttendances e ON a.Id = e.AttendanceId JOIN Employees m ON m.Id = e.EmployeeId WHERE a.Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Stat"].Visible = false;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                int stat = Convert.ToInt32(dr.Cells["Stat"].Value);

                // Assuming the ComboBox column index is 0
                DataGridViewComboBoxCell comboBoxCell = dr.Cells["Status"] as DataGridViewComboBoxCell;

                // Set the selected item based on the integer value
                comboBoxCell.Value = comboBoxCell.Items[stat - 3]; // Assumes the integer 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            dateTimePicker1.Visible = false;
            comboBox2.Visible = false;
            button4.Visible = true;
            button3.Visible = true;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell comboBoxCell = dr.Cells["Status"] as DataGridViewComboBoxCell;

                comboBoxCell.Value = comboBoxCell.Items[0];
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add Attendance to Database
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string shift = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            if (!validateDateInAttendance(selectedDate, shift) && this.dataGridView1.DataSource != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        MessageBox.Show("Attendance not marked against a Employee", "Alert");
                        return;
                    }
                }
                var con = Configuration.getInstance().getConnection();
                string query = "INSERT INTO Attendances VALUES(@date, @shift)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@date", selectedDate);
                cmd.Parameters.AddWithValue("@shift", shift);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Class Attendance Added SUccessfully!");

                int classID = returnAttendanceId(selectedDate + "," + shift);
                InsertEmployeeAttendaces(classID);
            }
            else
            {
                MessageBox.Show("The Attendance has been already Marked for this date!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool validateDateInAttendance(string date, string shift)      // just date in format
        {
            var c = Configuration.getInstance().getConnection();
            SqlCommand cm = new SqlCommand("SELECT Date, Shift FROM Attendances", c);
            SqlDataAdapter d = new SqlDataAdapter(cm);
            DataTable dataTable = new DataTable();
            d.Fill(dataTable);
            List<string> columnEntries = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime dateValue = (DateTime)row["Date"];
                string dateString = dateValue.ToString("yyyy-MM-dd");
                dateString += "," + row["Shift"];
                columnEntries.Add(dateString);
            }
            bool flag = false;
            foreach (string column in columnEntries)
            {
                if (column == (date + "," + shift))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        private int returnAttendanceId(string selectedDateAndShift)
        {
            string[] data = selectedDateAndShift.Split(',');
            var con = Configuration.getInstance().getConnection();
            string query = "SELECT Id FROM Attendances WHERE CONVERT(DATE, [Date]) = @date AND Shift = @shift";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@date", data[0]);
            cmd.Parameters.AddWithValue("@shift", data[1]);
            return (int)cmd.ExecuteScalar();
        }
        private void InsertEmployeeAttendaces(int attendaceId)
        {
            try
            {
                int eID = 0;
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    eID = (int)row.Cells[1].Value;

                    if (row.Cells[0].Value.ToString() == "PRESENT")
                    {
                        InsertIndividualEmployee(eID, attendaceId, 3);
                    }
                    else if (row.Cells[0].Value.ToString() == "ABSENT")
                    {
                        InsertIndividualEmployee(eID, attendaceId, 4);
                    }
                    else if (row.Cells[0].Value.ToString() == "LATE")
                    {
                        InsertIndividualEmployee(eID, attendaceId, 5);
                    }
                    else if (row.Cells[0].Value.ToString() == "LEAVE")
                    {
                        InsertIndividualEmployee(eID, attendaceId, 6);
                    }
                }
                MessageBox.Show("Attendance has been marked Successfully for the Selected Date.");
                this.dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InsertIndividualEmployee(int employeeId, int classID, int status)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "INSERT INTO EmployeeAttendances (AttendanceID,EmployeeId,Status) VALUES (@attID,@empID,@stat)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@attID", classID);
            cmd.Parameters.AddWithValue("@empID", employeeId);
            cmd.Parameters.AddWithValue("@stat", status);
            cmd.ExecuteNonQuery();
        }
        private void UpdateIndividualEmployee(int employeeId, int classID, int status)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "Update EmployeeAttendances SET Status = @status WHERE AttendanceId = @attID and EmployeeId = @empID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@attID", classID);
            cmd.Parameters.AddWithValue("@empID", employeeId);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string date = comboBox1.Text;
                int attendanceId = returnAttendanceId(date);
                try
                {
                    int eID = 0;
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        eID = (int)row.Cells[2].Value;

                        if (row.Cells[0].Value.ToString() == "PRESENT")
                        {
                            UpdateIndividualEmployee(eID, attendanceId, 3);
                        }
                        else if (row.Cells[0].Value.ToString() == "ABSENT")
                        {
                            UpdateIndividualEmployee(eID, attendanceId, 4);
                        }
                        else if (row.Cells[0].Value.ToString() == "LATE")
                        {
                            UpdateIndividualEmployee(eID, attendanceId, 5);
                        }
                        else if (row.Cells[0].Value.ToString() == "LEAVE")
                        {
                            UpdateIndividualEmployee(eID, attendanceId, 6);
                        }
                    }
                    MessageBox.Show("Attendance has been Updated Successfully for the Selected Date.");
                    this.dataGridView1.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select an Attendace to Update!!!");
            }
        }
    }
}
