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
    public partial class addSupplier : Form
    {
        Form parentForm;
        public addSupplier(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // user id and address can be null
            string name = textBox1.Text;
            string email = textBox2.Text;
            string contact = textBox3.Text;
            string address = richTextBox1.Text;
            string description = richTextBox2.Text;

            if (name != "" && name.Length <= 50)
            {
                if (address.Length <= 255)
                {
                    if ((email.EndsWith("@gmail.com") && email[0] != '@'))
                    {
                        if (description.Length <= 255)
                        {
                            var c = Configuration.getInstance().getConnection();
                            SqlCommand cm = new SqlCommand("SELECT Contact FROM Suppliers", c);
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
                                        cmd = new SqlCommand("Insert into Suppliers values (@Name, @Contact, @Email, @Address, 3,  @Description, 1)", con);
                                        cmd.Parameters.AddWithValue("@Address", address);
                                        cmd.Parameters.AddWithValue("@Description", description);

                                    }
                                    else
                                    {
                                        cmd = new SqlCommand("Insert into Suppliers values (@Name, @Contact, @Email, @Address, 3,  NULL, 1)", con);
                                        cmd.Parameters.AddWithValue("@Address", address);                                        
                                    }
                                }
                                else if (richTextBox2.Text.Length > 0)
                                {
                                    cmd = new SqlCommand("Insert into Suppliers values (@Name, @Contact, @Email, NULL, 3,  @Description, 1)", con);
                                    cmd.Parameters.AddWithValue("@Description", description);
                                }
                                else
                                {
                                    cmd = new SqlCommand("Insert into Suppliers values (@Name, @Contact, @Email, NULL, 3,  NULL, 1)", con);                                    
                                }
                                cmd.Parameters.AddWithValue("@Name", name);
                                cmd.Parameters.AddWithValue("@Contact", contact);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("The data is Successfully Saved!!!");
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox3.Clear();
                                richTextBox1.Clear();
                                richTextBox2.Clear();
                                textBox1.Focus();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
