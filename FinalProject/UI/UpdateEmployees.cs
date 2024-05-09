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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                string employeeId = selectedRow.Cells["Id"].Value.ToString();
                string employeeUserId = selectedRow.Cells["UserId"].Value.ToString();

                string name = textBox1.Text;
                string fname = textBox2.Text;
                string account = textBox3.Text;
                string contact = textBox4.Text;
                string email = textBox5.Text;
                float salary = float.Parse(textBox6.Text);
                string address = richTextBox1.Text;
                bool flag = assignChkBx.Checked;

                if (assignChkBx.Checked && removeChkBx.Checked)
                {
                    MessageBox.Show("Please Select unique criteria for UserId", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!assignChkBx.Checked && !removeChkBx.Checked)
                {
                    MessageBox.Show("Please Select unique criteria for UserId", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (name != "" && name.Length <= 50)
                {
                    if (fname != "" && fname.Length <= 50)
                    {
                        if ((email.EndsWith("@gmail.com") && email[0] != '@'))
                        {
                            if (salary >= 15000)
                            {
                                if (richTextBox1.Text.Length < 255)
                                {
                                    var c = Configuration.getInstance().getConnection();
                                    SqlCommand cm = new SqlCommand("SELECT AccountNo, Contact FROM Employees", c);
                                    SqlDataAdapter d = new SqlDataAdapter(cm);
                                    DataTable dataTable = new DataTable();
                                    d.Fill(dataTable);
                                    List<string> columnEntries = new List<string>();
                                    List<string> contactEntries = new List<string>();
                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        columnEntries.Add(row["AccountNo"].ToString());
                                        contactEntries.Add(row["Contact"].ToString());
                                    }
                                    bool flag1 = false;
                                    bool flag2 = false;
                                    foreach (string s in columnEntries)
                                    {
                                        if (s == account)
                                        {
                                            flag1 = true;
                                        }
                                    }
                                    foreach (string s in contactEntries)
                                    {
                                        if (s == contact)
                                        {
                                            flag2 = true;
                                        }
                                    }
                                    if (flag2 == false && textBox4.Text.Length == 11)
                                    {
                                        if (flag1 == false && textBox3.Text.Length == 24)
                                        {
                                            // The Information has been verified to be added to database
                                            int id = 0;
                                            string username = name.ToLower();
                                            string password = account.Substring(0, 8);
                                            bool deleteData = false;
                                            if (flag && employeeUserId == "")
                                            {
                                                var c1 = Configuration.getInstance().getConnection();
                                                SqlCommand cmd1 = new SqlCommand("INSERT into LoginCredentials Values(@user, @pass, 'Employee'); SELECT SCOPE_IDENTITY();", c1);
                                                cmd1.Parameters.AddWithValue("@user", username);
                                                cmd1.Parameters.AddWithValue("@pass", password);
                                                id = Convert.ToInt32(cmd1.ExecuteScalar());
                                            }
                                            else if (!flag)
                                            {
                                                deleteData = true;
                                            }

                                            string newUserId = "";
                                            if (employeeUserId == "")
                                            {
                                                newUserId = id.ToString();
                                            }
                                            else
                                            {
                                                newUserId = employeeUserId;
                                            }

                                            var con = Configuration.getInstance().getConnection();
                                            SqlCommand cmd;
                                            if (richTextBox1.Text.Length > 0)
                                            {
                                                if (flag)
                                                {
                                                    cmd = new SqlCommand("Update Employees Set Name = @Name, Contact = @Contact, Email = @Email, Address = @Address, AccountNo = @Account, Salary = @Salary, UserId = @userid, FName = @FName WHERE Id = @id", con);
                                                    cmd.Parameters.AddWithValue("@Address", address);
                                                    cmd.Parameters.AddWithValue("@id", employeeId);
                                                    cmd.Parameters.AddWithValue("@userid", newUserId);
                                                }
                                                else
                                                {
                                                    cmd = new SqlCommand("Update Employees Set Name = @Name, Contact = @Contact, Email = @Email, Address = @Address, AccountNo = @Account, Salary = @Salary, UserId = NULL, FName = @FName WHERE Id = @id", con);
                                                    cmd.Parameters.AddWithValue("@Address", address);
                                                    cmd.Parameters.AddWithValue("@id", employeeId);
                                                    cmd.Parameters.AddWithValue("@userid", newUserId);
                                                }
                                            }
                                            else if (flag)
                                            {
                                                cmd = new SqlCommand("Update Employees Set Name = @Name, Contact = @Contact, Email = @Email, Address = NULL, AccountNo = @Account, Salary = @Salary, UserId = @userid, FName = @FName WHERE Id = @id", con);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                                cmd.Parameters.AddWithValue("@id", employeeId);
                                                cmd.Parameters.AddWithValue("@userid", newUserId);
                                            }
                                            else
                                            {
                                                cmd = new SqlCommand("Update Employees Set Name = @Name, Contact = @Contact, Email = @Email, Address = NULL, AccountNo = @Account, Salary = @Salary, UserId = NULL, FName = @FName WHERE Id = @id", con);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                                cmd.Parameters.AddWithValue("@id", employeeId);
                                                cmd.Parameters.AddWithValue("@userid", newUserId);
                                            }
                                            cmd.Parameters.AddWithValue("@Name", name);
                                            cmd.Parameters.AddWithValue("@FName", fname);
                                            cmd.Parameters.AddWithValue("@Contact", contact);
                                            cmd.Parameters.AddWithValue("@Email", email);
                                            cmd.Parameters.AddWithValue("@Account", account);
                                            cmd.Parameters.AddWithValue("@Salary", salary);
                                            cmd.ExecuteNonQuery();
                                            promptData();

                                            if (deleteData)
                                            {
                                                var c1 = Configuration.getInstance().getConnection();
                                                SqlCommand cmd1 = new SqlCommand("Delete from LoginCredentials Where Id = @id", c1);
                                                cmd1.Parameters.AddWithValue("@id", employeeUserId);
                                                cmd1.ExecuteNonQuery();
                                            }

                                            MessageBox.Show("The data is Successfully Saved!!!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Enter a unique 24-digit Account No. ");
                                        }
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
                                MessageBox.Show("Please Enter a salary greater then this number.");
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
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, FName, Contact, Email, AccountNo, Salary, JoiningDate, Address, UserId from Employees", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["UserId"].Visible = false;
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
                string id = selectedRow.Cells["UserId"].Value.ToString();

                textBox1.Text = name;
                textBox2.Text = fname;
                textBox3.Text = account;
                textBox4.Text = contact;
                textBox5.Text = email;
                textBox6.Text = salary;
                richTextBox1.Text = address;
                bool userid = int.TryParse(id, out _);
                if (userid)
                {
                    removeChkBx.Checked = false;
                    assignChkBx.Checked = true;
                }
                else
                {
                    assignChkBx.Checked = false;
                    removeChkBx.Checked = true;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Delete from Employees Where Id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                promptData();
                MessageBox.Show("The Data is deleted Successfully!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
