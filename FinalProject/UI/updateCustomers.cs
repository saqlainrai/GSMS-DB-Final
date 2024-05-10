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
            List<string> professions = new List<string> { "Chef", "Engineer", "Doctor", "Teacher", "Artist", "Businessman", "Farmer", "Judge", "Dentist", "Lawyer", "Electrician", "Pharmacist" };
            comboBox1.DataSource = professions;
            comboBox1.SelectedIndex = 0;
        }
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            customersDG.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Delete from Customers Where Id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                promptData();
                MessageBox.Show("The Data is deleted Successfully!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtCNIC.Text = cnic;
                textBox4.Text = contact;
                txtEmail.Text = email;
                comboBox1.SelectedItem = profession;
                txtAddress.Text = address;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string name = textBox1.Text;
                string fname = textBox2.Text;
                string cnic = txtCNIC.Text;
                string contact = textBox4.Text;
                string email = txtEmail.Text;
                string profession = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string address = txtAddress.Text;
                tupleKey = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Id"].Value.ToString());

                if (name != "" && name.Length <= 50)
                {
                    if (fname != "" && fname.Length <= 50)
                    {
                        if ((email.EndsWith("@gmail.com") && email[0] != '@') || txtEmail.Text.Length == 0)
                        {
                            if (txtCNIC.Text.Length == 13 || txtCNIC.Text.Length == 0)
                            {
                                if (txtAddress.Text.Length < 255)
                                {
                                    var c = Configuration.getInstance().getConnection();
                                    SqlCommand cm = new SqlCommand("SELECT Id, Contact FROM Customers", c);
                                    SqlDataAdapter d = new SqlDataAdapter(cm);
                                    DataTable dataTable = new DataTable();
                                    d.Fill(dataTable);
                                    List<string> columnEntries = new List<string>();
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        columnEntries.Add(row["Id"].ToString() + ',' + row["Contact"].ToString());
                                    }
                                    bool flag = false;
                                    foreach (string s in columnEntries)
                                    {
                                        if (s.Split(',')[1] == contact && s.Split(',')[0] != tupleKey.ToString())
                                        {
                                            flag = true;
                                        }
                                    }
                                    if (flag == false && contact.Length == 11)
                                    {
                                        var con = Configuration.getInstance().getConnection();
                                        SqlCommand cmd;
                                        if (txtEmail.Text.Length > 0)
                                        {
                                            if (txtCNIC.Text.Length > 0)
                                            {
                                                if (txtAddress.Text.Length > 0)
                                                {
                                                    cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = @CNIC, Contact = @Contact, Email = @Email, Profession = @Profession, Address = @Address Where Id = @id", con);
                                                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                                                    cmd.Parameters.AddWithValue("@Email", email);
                                                    cmd.Parameters.AddWithValue("@Address", address);
                                                }
                                                else
                                                {
                                                    cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = @CNIC, Contact = @Contact, Email = @Email, Profession = @Profession, Address = NULL Where Id = @id", con);
                                                    cmd.Parameters.AddWithValue("@CNIC", cnic);
                                                    cmd.Parameters.AddWithValue("@Email", email);
                                                }
                                            }
                                            else if (txtAddress.Text.Length > 0)
                                            {
                                                cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = NULL, Contact = @Contact, Email = @Email, Profession = @Profession, Address = @Address Where Id = @id", con);
                                                cmd.Parameters.AddWithValue("@Email", email);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                            }
                                            else
                                            {
                                                cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = NULL, Contact = @Contact, Email = @Email, Profession = @Profession, Address = NULL Where Id = @id", con);
                                                cmd.Parameters.AddWithValue("@Email", email);
                                            }
                                        }
                                        else if (txtCNIC.Text.Length > 0)
                                        {
                                            if (txtAddress.Text.Length > 0)
                                            {
                                                cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = @CNIC, Contact = @Contact, Email = NULL, Profession = @Profession, Address = @Address Where Id = @id", con);
                                                cmd.Parameters.AddWithValue("@CNIC", cnic);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                            }
                                            else
                                            {
                                                cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = @CNIC, Contact = @Contact, Email = @Email, Profession = @Profession, Address = NULL Where Id = @id", con);
                                                cmd.Parameters.AddWithValue("@CNIC", cnic);
                                                cmd.Parameters.AddWithValue("@Email", email);
                                            }
                                        }
                                        else if (txtAddress.Text.Length > 0)
                                        {
                                            cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = NULL, Contact = @Contact, Email = NULL, Profession = @Profession, Address = @Address Where Id = @id", con);
                                            cmd.Parameters.AddWithValue("@Address", address);
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("Update Customers Set Name = @Name, FName = @FName, CNIC = NULL, Contact = @Contact, Email = NULL, Profession = @Profession, Address = NULL Where Id = @id", con);
                                        }
                                        cmd.Parameters.AddWithValue("@Name", name);
                                        cmd.Parameters.AddWithValue("@FName", fname);
                                        cmd.Parameters.AddWithValue("@Contact", contact);
                                        cmd.Parameters.AddWithValue("@Profession", profession);
                                        cmd.Parameters.AddWithValue("@Id", tupleKey);
                                        cmd.ExecuteNonQuery();

                                        promptData();

                                        MessageBox.Show("The Data is Updated Successfully!!!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Enter a unique 11-digit Contact Number (including starting 0)");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Enter a limited Address (255 chars)");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please Enter a valid 13-digit long CNIC (except dashes)");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter a valid Email!!!\nNote: Only gmail's are accepted.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a valid FName");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a valid Name!!!");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }
    }
}
