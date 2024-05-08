using FinalProject.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.UI_Forms
{
    public partial class AddCustomers : Form
    {
        Form parentForm;
        public AddCustomers(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            comboProfession.SelectedIndex = 0;
            txtName.Focus();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string fname = txtFName.Text;
            string contact = txtContact.Text;
            string profession = comboProfession.Items[comboProfession.SelectedIndex].ToString();
            string cnic = null;
            string email = txtEmail.Text; ;
            string address = null;
            if (txtCNIC.Text.Length > 0)
                cnic = txtCNIC.Text;
            //if (txtEmail.Text.Length > 0)
            //    email = txtEmail.Text;
            if (txtAddress.Text.Length > 0)
                address = txtAddress.Text;

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
                                SqlCommand cm = new SqlCommand("SELECT Contact FROM Customers", c);
                                SqlDataAdapter d = new SqlDataAdapter(cm);
                                DataTable dataTable = new DataTable();
                                d.Fill(dataTable);
                                List<string> columnEntries = new List<string>();
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    columnEntries.Add(row["Contact"].ToString());
                                }
                                bool flag = false;
                                foreach (string s in columnEntries)
                                {
                                    if (s == contact)
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
                                                cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, @CNIC, @Contact, @Email, @Profession, @Address)", con);
                                                cmd.Parameters.AddWithValue("@CNIC", cnic);
                                                cmd.Parameters.AddWithValue("@Email", email);
                                                cmd.Parameters.AddWithValue("@Address", address);
                                            }
                                            else
                                            {
                                                cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, @CNIC, @Contact, @Email, @Profession, NULL)", con);
                                                cmd.Parameters.AddWithValue("@CNIC", cnic);
                                                cmd.Parameters.AddWithValue("@Email", email);
                                            }
                                        }
                                        else if (txtAddress.Text.Length > 0)
                                        {
                                            cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, NULL, @Contact, @Email, @Profession, @Address)", con);
                                            cmd.Parameters.AddWithValue("@Email", email);
                                            cmd.Parameters.AddWithValue("@Address", address);
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, NULL, @Contact, @Email, @Profession, NULL)", con);
                                            cmd.Parameters.AddWithValue("@Email", email);
                                        }
                                    }
                                    else if (txtCNIC.Text.Length > 0)
                                    {
                                        if (txtAddress.Text.Length > 0)
                                        {
                                            cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, @CNIC, @Contact, NULL, @Profession, @Address)", con);
                                            cmd.Parameters.AddWithValue("@CNIC", cnic);
                                            cmd.Parameters.AddWithValue("@Address", address);
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, @CNIC, @Contact, NULL, @Profession, NULL)", con);
                                            cmd.Parameters.AddWithValue("@CNIC", cnic);
                                            cmd.Parameters.AddWithValue("@Email", email);
                                        }
                                    }
                                    else if (txtAddress.Text.Length > 0)
                                    {
                                        cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, NULL, @Contact, NULL, @Profession, @Address)", con);
                                        cmd.Parameters.AddWithValue("@Address", address);
                                    }
                                    else 
                                    { 
                                        cmd = new SqlCommand("Insert into Customers values (3, @Name, @FName, NULL, @Contact, NULL, @Profession, NULL)", con);
                                    }
                                    cmd.Parameters.AddWithValue("@Name", name);
                                    cmd.Parameters.AddWithValue("@FName", fname);                                    
                                    cmd.Parameters.AddWithValue("@Contact", contact);
                                    cmd.Parameters.AddWithValue("@Profession", profession);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("The data is Successfully Saved!!!");
                                    txtName.Clear();
                                    txtFName.Clear();
                                    txtEmail.Clear();
                                    txtCNIC.Clear();
                                    txtEmail.Clear();
                                    txtContact.Clear();
                                    txtAddress.Clear();
                                    comboProfession.SelectedIndex = 0;
                                    txtName.Focus();
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

        private void comboProfession_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
