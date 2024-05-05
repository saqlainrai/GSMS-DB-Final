using FinalProject.BL;
using FinalProject.DL;
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
    public partial class updateCustomers : Form
    {
        private Form parentForm;
        private int tupleKey = -1;
        public updateCustomers(Form parentForm)
        {
            InitializeComponent();
            promptData();
            this.parentForm = parentForm;
            dataGridView1.ColumnHeadersHeight = 25;
        }
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                string name = selectedRow.Cells["Username"].Value.ToString();
                string pass = selectedRow.Cells["Password"].Value.ToString();
                //credentialId = Convert.ToInt32(selectedRow.Cells["Id"].Value.ToString());


                //txtUsername.Text = name;
                //txtPassword.Text = pass;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void fillComboBoxes()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                string name = selectedRow.Cells["Name"].Value.ToString();
                string fname = selectedRow.Cells["FName"].Value.ToString();
                string cnic = selectedRow.Cells["CNIC"].Value.ToString();
                string contact = selectedRow.Cells["Contact"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string profession = selectedRow.Cells["Profession"].Value.ToString();
                string address = selectedRow.Cells["Address"].Value.ToString();
                tupleKey = Convert.ToInt32(selectedRow.Cells["Id"].Value.ToString());

                textBox1.Text = name;
                textBox2.Text = fname;
                textBox3.Text = cnic;
                textBox4.Text = contact;
                textBox5.Text = email;
                //comboBox1 /////////////////check how to clear a combo box
                richTextBox1.Text = address;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string name = textBox1.Text;
                string fname = textBox2.Text;
                string cnic = textBox3.Text;
                string contact = textBox4.Text;
                string email = textBox5.Text;
                string profession = comboBox1.Items[comboBox1.SelectedIndex].ToString();    
                string address = richTextBox1.Text;
                tupleKey = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Id"].Value.ToString());

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd;
                if (textBox5.Text.Length > 0)
                {
                    cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, @CNIC, @Contact, @Email, @Profession, @Address)", con);
                }
                else
                {
                    cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, @CNIC, @Contact, NULL, @Profession, @Address)", con);
                }
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FName", fname);
                cmd.Parameters.AddWithValue("@CNIC", cnic);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Profession", profession);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.ExecuteNonQuery();

                promptData();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }
    }
}
