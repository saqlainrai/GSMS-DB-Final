using FinalProject.BL;
using Guna.UI2.WinForms;
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
    public partial class UpdateEmployees : Form
    {
        Form parentForm;
        public UpdateEmployees(Form parentForm)
        {
            InitializeComponent();
            promptData();
            this.parentForm = parentForm;
            dataGridView1.ColumnHeadersHeight = 25;
            label6.Location = new Point(17, 6);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //it is update Btn

        }
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Employees", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void fillComboBoxes()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                string name = selectedRow.Cells["Name"].Value.ToString();
                string fname = selectedRow.Cells["FName"].Value.ToString();
                string account = selectedRow.Cells["AccountNo"].Value.ToString();
                string contact = selectedRow.Cells["Contact"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string salary = selectedRow.Cells["Salary"].Value.ToString();
                string address = selectedRow.Cells["Address"].Value.ToString();
                int tupleKey = Convert.ToInt32(selectedRow.Cells["Id"].Value.ToString());

                textBox1.Text = name;
                textBox2.Text = fname;
                textBox3.Text = account;
                textBox4.Text = contact;
                textBox5.Text = email;
                textBox6.Text = salary;
                richTextBox1.Text = address;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }
    }
}
