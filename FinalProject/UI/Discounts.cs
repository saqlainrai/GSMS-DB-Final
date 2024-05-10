using FinalProject.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.UI_Forms
{
    public partial class Discounts : Form
    {
        public Discounts()
        {
            InitializeComponent();
            promptData();
            dataGridView1.ColumnHeadersHeight = 25;
        }
        private void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id, CouponCode, Name, Percentage, Description FROM Discounts", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // delete button
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                    int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete from Discounts Where Id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    promptData();
                    MessageBox.Show("The Data is deleted Successfully!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                string discountId = selectedRow.Cells["Id"].Value.ToString();

                // update button
                string name = txtName.Text;
                string coupon = txtCoupon.Text;
                string description = txtDescription.Text;
                string percentage = intPercentage.Text;

                //desctiption + name can be null
                if (name.Length <= 50)
                {
                    if (description.Length <= 255)
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("SELECT Id, CouponCode FROM Discounts", con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        List<string> columnEntries = new List<string>();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            columnEntries.Add(row["Id"].ToString() + ',' + row["CouponCode"].ToString());
                        }
                        bool flag = false;
                        foreach (string s in columnEntries)
                        {
                            if (s.Split(',')[1] == coupon && s.Split(',')[0] != discountId)
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            // the data is refined
                            var c1 = Configuration.getInstance().getConnection();
                            SqlCommand c2;
                            if (txtName.Text.Length > 0)
                            {
                                if (txtDescription.Text.Length > 0)
                                {
                                    c2 = new SqlCommand("Update Discounts Set CouponCode = @coupon, Percentage = @percentage, Description = @description, Name = @name WHERE Id = @id", con);
                                    c2.Parameters.AddWithValue("@description", description);
                                    c2.Parameters.AddWithValue("@name", name);

                                }
                                else
                                {
                                    c2 = new SqlCommand("Update Discounts Set CouponCode = @coupon, Percentage = @percentage, Description = NULL, Name = @name WHERE Id = @id", con);
                                    c2.Parameters.AddWithValue("@name", name);
                                }
                            }
                            else if (txtDescription.Text.Length > 0)
                            {
                                c2 = new SqlCommand("Update Discounts Set CouponCode = @coupon, Percentage = @percentage, Description = @description, Name = NULL WHERE Id = @id", con);
                                c2.Parameters.AddWithValue("@description", description);
                            }
                            else
                            {
                                c2 = new SqlCommand("Update Discounts Set CouponCode = @coupon, Percentage = @percentage, Description = NULL, Name = NULL WHERE Id = @id", con);
                            }
                            c2.Parameters.AddWithValue("@coupon", coupon);
                            c2.Parameters.AddWithValue("@percentage", percentage);
                            c2.Parameters.AddWithValue("@id", discountId);
                            c2.ExecuteNonQuery();
                            promptData();
                            MessageBox.Show("The data is Successfully Updated!!!");
                            txtName.Clear();
                            txtCoupon.Clear();
                            txtDescription.Clear();
                            intPercentage.Value = 0;
                            txtName.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Please Enter a Unique Coupon Code!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a Address less than 255 characters!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a Name less than 50 characters!!!");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // add button
            string name = txtName.Text;
            string coupon = txtCoupon.Text;
            string description = txtDescription.Text;
            string percentage = intPercentage.Text;

            //desctiption + name can be null
            if (name.Length <= 50)
            {
                if (description.Length <= 255)
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("SELECT Id, CouponCode FROM Discounts", con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    List<string> columnEntries = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        columnEntries.Add(row["CouponCode"].ToString());
                    }
                    bool flag = false;
                    foreach (string s in columnEntries)
                    {
                        if (s == coupon)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        // the data is refined
                        var c1 = Configuration.getInstance().getConnection();
                        SqlCommand c2;
                        if (txtName.Text.Length > 0)
                        {
                            if (txtDescription.Text.Length > 0)
                            {
                                c2 = new SqlCommand("Insert into Discounts values (@coupon, @percentage, @description, @name)", con);
                                c2.Parameters.AddWithValue("@description", description);
                                c2.Parameters.AddWithValue("@name", name);

                            }
                            else
                            {
                                c2 = new SqlCommand("Insert into Discounts values (@coupon, @percentage, NULL, @name)", con);
                                c2.Parameters.AddWithValue("@name", name);
                            }
                        }
                        else if (txtDescription.Text.Length > 0)
                        {
                            c2 = new SqlCommand("Insert into Discounts values (@coupon, @percentage, @description, NULL)", con);
                            c2.Parameters.AddWithValue("@description", description);
                        }
                        else
                        {
                            c2 = new SqlCommand("Insert into Discounts values (@coupon, @percentage, NULL, NULL)", con);
                        }
                        c2.Parameters.AddWithValue("@coupon", coupon);
                        c2.Parameters.AddWithValue("@percentage", percentage);
                        c2.ExecuteNonQuery();
                        promptData();
                        MessageBox.Show("The data is Successfully Saved!!!");
                        txtName.Clear();
                        txtCoupon.Clear();
                        txtDescription.Clear();
                        intPercentage.Value = 0;
                        txtName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a Unique Coupon Code!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a Address less than 255 characters!!!");
                }
            }
            else
            {
                MessageBox.Show("Please Enter a Name less than 50 characters!!!");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }
        private void fillComboBoxes()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                
                string name = selectedRow.Cells["Name"].Value.ToString();
                string coupon = selectedRow.Cells["CouponCode"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                string percentage = selectedRow.Cells["Percentage"].Value.ToString();

                txtName.Text = name;
                txtDescription.Text = description;
                txtCoupon.Text = coupon;
                intPercentage.Value = Convert.ToInt32(float.Parse(percentage));
            }
        }
    }
}
