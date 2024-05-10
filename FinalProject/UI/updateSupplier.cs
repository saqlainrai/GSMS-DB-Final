using FinalProject.BL;
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
    public partial class updateSupplier : Form
    {
        Form parentForm;
        public updateSupplier(Form parentForm)
        {
            InitializeComponent();
            promptData();
            this.parentForm = parentForm;
            dataGridView1.ColumnHeadersHeight = 25;
        }
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Suppliers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Status"].Visible = false;
        }
        private void fillComboBoxes()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                string name = selectedRow.Cells["Name"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string contact = selectedRow.Cells["Contact"].Value.ToString();
                string address = selectedRow.Cells["Address"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                string tupleKey = selectedRow.Cells["Status"].Value.ToString();

                textBox1.Text = name;
                textBox2.Text = email;
                textBox3.Text = contact;
                richTextBox1.Text = address;
                richTextBox2.Text = description;
                if (tupleKey == "1")
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                }
                else
                {
                    radioButton2.Checked = false;
                    radioButton1.Checked = true;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                    int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete from Suppliers Where Id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    promptData();
                    MessageBox.Show("The Data is deleted Successfully!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                string supplierId = selectedRow.Cells["Id"].Value.ToString();
                string status = selectedRow.Cells["Status"].Value.ToString();

                string name = textBox1.Text;
                string email = textBox2.Text;
                string contact = textBox3.Text;
                string address = richTextBox1.Text;
                string description = richTextBox2.Text;
                bool flag = false;

                if (radioButton2.Checked )
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                if (radioButton1.Checked && radioButton2.Checked)
                {
                    MessageBox.Show("Please Select unique criteria for Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Please Select unique criteria for Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (name != "" && name.Length <= 50)
                {
                    if (address.Length <= 255)
                    {
                        if ((email.EndsWith("@gmail.com") && email[0] != '@'))
                        {
                            if (description.Length <= 255)
                            {
                                var c = Configuration.getInstance().getConnection();
                                SqlCommand cm = new SqlCommand("SELECT Contact FROM Suppliers where Id <> @id", c);
                                cm.Parameters.AddWithValue("@id", supplierId);
                                SqlDataAdapter d = new SqlDataAdapter(cm);
                                DataTable dataTable = new DataTable();
                                d.Fill(dataTable);
                                List<string> contactEntries = new List<string>();
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    contactEntries.Add(row["Contact"].ToString());
                                }
                                bool flag1 = false;
                                foreach (string s in contactEntries)
                                {
                                    if (s == contact)
                                    {
                                        flag1 = true;
                                    }
                                }
                                if (flag1 == false && textBox3.Text.Length == 11)
                                {
                                    // The Information has been verified to be added to database
                                    var con = Configuration.getInstance().getConnection();
                                    SqlCommand cmd;
                                    if (richTextBox1.Text.Length > 0)
                                    {
                                        if (richTextBox2.Text.Length > 0)
                                        {
                                            if (flag)
                                            {
                                                cmd = new SqlCommand("Update Suppliers Set Status = 1, Name = @Name, Contact = @Contact, Email = @Email, Address = @Address, Description = @Description Where Id = @id", con);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                                cmd.Parameters.AddWithValue("@Description", description);
                                            }
                                            else
                                            {
                                                cmd = new SqlCommand("Update Suppliers Set Status = 2, Name = @Name, Contact = @Contact, Email = @Email, Address = @Address, Description = @Description Where Id = @id", con);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                                cmd.Parameters.AddWithValue("@Description", description);
                                            }
                                        }
                                        else if (flag)
                                        {
                                            cmd = new SqlCommand("Update Suppliers Set Status = 1, Name = @Name, Contact = @Contact, Email = @Email, Address = @Address, Description = NULL Where Id = @id", con);
                                            cmd.Parameters.AddWithValue("@Address", address);
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("Update Suppliers Set Status = 2, Name = @Name, Contact = @Contact, Email = @Email, Address = @Address, Description = NULL Where Id = @id", con);
                                            cmd.Parameters.AddWithValue("@Address", address);
                                        }
                                    }
                                    else if (richTextBox2.Text.Length > 0)
                                    {
                                        if (flag)
                                        {
                                            cmd = new SqlCommand("Update Suppliers Set Status = 1, Name = @Name, Contact = @Contact, Email = @Email, Address = NULL, Description = @Description Where Id = @id", con);                                            
                                            cmd.Parameters.AddWithValue("@Description", description);
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("Update Suppliers Set Status = 2, Name = @Name, Contact = @Contact, Email = @Email, Address = NULL, Description = @Description Where Id = @id", con);
                                            cmd.Parameters.AddWithValue("@Description", description);
                                        }
                                    }
                                    else if (flag)
                                    {
                                        cmd = new SqlCommand("Update Suppliers Set Status = 1, Name = @Name, Contact = @Contact, Email = @Email, Address = NULL, Description = NULL Where Id = @id", con);
                                    }
                                    else
                                    {
                                        cmd = new SqlCommand("Update Suppliers Set Status = 2, Name = @Name, Contact = @Contact, Email = @Email, Address = NULL, Description = NULL Where Id = @id", con);
                                    }
                                    cmd.Parameters.AddWithValue("@Name", name);
                                    cmd.Parameters.AddWithValue("@Contact", contact);
                                    cmd.Parameters.AddWithValue("@Email", email);
                                    cmd.Parameters.AddWithValue("@Id", supplierId);
                                    cmd.ExecuteNonQuery();
                                    promptData();
                                    MessageBox.Show("The data is Updated Saved!!!");
                                }
                                else
                                {
                                    MessageBox.Show("Please Enter a unique 11-digit Contact Number (including starting 0)");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Enter a description of maximum 255 characters.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter a valid Email!!!\nNote: Only gmail's are accepted.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a valid address of maximum 255 characters");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a valid Name!!!");
                }
            }
        }
    }
}
