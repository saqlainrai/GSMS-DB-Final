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
            promptData();
            button1.Visible = false;
            button2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker1.Value = DateTime.Now;
        }
        void promptData()
        {
            // here we will mark the attendance of employees
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, FName, Email, Contact from Employees", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            guna2DataGridView1.DataSource = dataTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Select Previous Attendance
            button1.Visible = true;
            comboBox1.Visible = true;
            button4.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Choose Attendance Date
            button2.Visible=true;
            dateTimePicker1.Visible=true;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible=false;
            dateTimePicker1.Visible=false;
            comboBox2.Visible = false;
            button4.Visible = true;
            button3.Visible = true;
        }
    }
}
