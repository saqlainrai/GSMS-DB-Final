using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FinalProject.BL;
using FinalProject.DL;

namespace FinalProject.UI_Forms
{
    public partial class AddEmployees : Form
    {
        Form parentForm;
        public AddEmployees(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // user id and address can be null
            string name = nameBx.Text;
            string fname = fNameBx.Text;
            string email = mailBx.Text;
            float salary = float.Parse(salaryBx.Text);
            string account = accountBx.Text;
            string address = addressBx.Text;
            string contact = contactBx.Text;
            bool userFlag = false;

            if (YeschkBx.Checked)
            {
                userFlag = true;
            }

            if (name != "" && name.Length <= 50)
            {
                if (fname != "" && fname.Length <= 50)
                {
                    if ((email.EndsWith("@gmail.com") && email[0] != '@'))
                    {
                        if (salary >= 15000)
                        {
                            if (addressBx.Text.Length < 255)
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
                                    if (s == account)
                                    {
                                        flag2 = true;
                                    }
                                }
                                if (flag2 == false && contactBx.Text.Length == 11)
                                {
                                    if (flag1 == false && accountBx.Text.Length == 24)
                                    {
                                        // The Information has been verified to be added to database
                                        int id = 0;
                                        string username = name.ToLower();
                                        string password = account.Substring(0, 8);
                                        if (userFlag)
                                        {
                                            var c1 = Configuration.getInstance().getConnection();
                                            SqlCommand cmd1 = new SqlCommand("INSERT into LoginCredentials Values(@user, @pass, 'Employee'); SELECT SCOPE_IDENTITY();", c1);
                                            cmd1.Parameters.AddWithValue("@user", username);
                                            cmd1.Parameters.AddWithValue("@pass", password);
                                            id = Convert.ToInt32(cmd1.ExecuteScalar());
                                        }

                                        var con = Configuration.getInstance().getConnection();
                                        SqlCommand cmd;
                                        if (addressBx.Text.Length > 0)
                                        {
                                            if (userFlag)
                                            {
                                                cmd = new SqlCommand("Insert into Employees values (@Name, @Contact, @Email, @Address, @Account, @Salary, GETDATE(), @id, @FName)", con);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                                cmd.Parameters.AddWithValue("@Id", id);

                                            }
                                            else
                                            {
                                                cmd = new SqlCommand("Insert into Employees values (@Name, @Contact, @Email, @Address, @Account, @Salary, GETDATE(), NULL, @FName)", con);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                            }
                                        }
                                        else if (userFlag)
                                        {
                                            cmd = new SqlCommand("Insert into Employees values (@Name, @Contact, @Email, NULL, @Account, @Salary, GETDATE(), @id, @FName)", con);
                                            cmd.Parameters.AddWithValue("@Id", id);
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("Insert into Employees values (@Name, @Contact, @Email, NULL, @Account, @Salary, GETDATE(), NULL, @FName)", con);
                                        }
                                        cmd.Parameters.AddWithValue("@Name", name);
                                        cmd.Parameters.AddWithValue("@FName", fname);
                                        cmd.Parameters.AddWithValue("@Contact", contact);
                                        cmd.Parameters.AddWithValue("@Email", email);
                                        cmd.Parameters.AddWithValue("@Account", account);
                                        cmd.Parameters.AddWithValue("@Salary", salary);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("The data is Successfully Saved!!!");
                                        nameBx.Clear();
                                        fNameBx.Clear();
                                        accountBx.Clear();
                                        salaryBx.Value = 0;
                                        mailBx.Clear();
                                        contactBx.Clear();
                                        addressBx.Clear();
                                        YeschkBx.Checked = false;
                                        nameBx.Focus();
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
}
