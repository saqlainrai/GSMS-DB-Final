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
using FinalProject.BL;

namespace FinalProject.UI_Forms
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
            fillComboBox();
            promptData();
        }
        private void fillComboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id, Name from SubCategories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> strings = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                strings.Add(dr["Name"].ToString());
            }
            comboBox1.Items.Clear();
            comboBox1.DataSource = strings;
            comboBox1.SelectedIndex = 0;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string price = textBox2.Text;
            string subcategory = comboBox1.SelectedItem.ToString();
            int subcategoryId = getSubCategoryId(subcategory);
            if (subcategoryId == -1)
            {
                throw new Exception("Subcategory Not registered");
            }
            DateTime expiry = guna2DateTimePicker1.Value;

            if (name != "" && name.Length <= 50)
            {
                if (float.TryParse(price, out _))
                {
                    if (expiry > DateTime.Now)
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("Insert into Products values(@name, @subcategory, @price, @expirydate)", con);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", float.Parse(price));
                        cmd.Parameters.AddWithValue("@subcategory", subcategoryId);
                        cmd.Parameters.AddWithValue("@expirydate", expiry);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The data is saved successfully!!!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                        comboBox1.SelectedIndex = 0;
                        guna2DateTimePicker1.Value = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("An Expired Product is not allowed to be added");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a valid Price!!!");
                }
            }
            else
            {
                MessageBox.Show("Please Enter a valid Name of Product");
            }
        }
        private int getSubCategoryId(string name)
        {
            int id = -1;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id, Name from SubCategories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> strings = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                strings.Add(dr["Id"].ToString() + ',' + dr["Name"].ToString());
            }
            foreach (string a in strings)
            {
                if (a.Split(',')[1].ToString() == name)
                {
                    id = Convert.ToInt32(a.Split(',')[0]);
                }
            }
            return id;
        }
        private string getSubCategoryName(int id)
        {
            string name = "";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id, Name from SubCategories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> strings = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                strings.Add(dr["Id"].ToString() + ',' + dr["Name"].ToString());
            }
            foreach (string a in strings)
            {
                if (a.Split(',')[0].ToString() == id.ToString())
                {
                    name = a.Split(',')[1].ToString();
                }
            }
            return name;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];

                    int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete from Products Where Id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    promptData();
                    MessageBox.Show("The Data is deleted Successfully!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                string id = selectedRow.Cells["Id"].Value.ToString();

                string name = textBox1.Text;
                string price = textBox2.Text;
                string subcategory = comboBox1.SelectedItem.ToString();
                int subcategoryId = getSubCategoryId(subcategory);
                if (subcategoryId == -1)
                {
                    throw new Exception("Subcategory Not registered");
                }
                DateTime expiry = guna2DateTimePicker1.Value;

                if (name != "" && name.Length <= 50)
                {
                    if (float.TryParse(price, out _))
                    {
                        if (expiry > DateTime.Now)
                        {
                            var con = Configuration.getInstance().getConnection();
                            SqlCommand cmd = new SqlCommand("Update Products Set Name = @name, Price = @price, SubCategoryId = @subcategory, ExpiryDate = @expirydate where Id = @id ", con);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@price", float.Parse(price));
                            cmd.Parameters.AddWithValue("@subcategory", subcategoryId);
                            cmd.Parameters.AddWithValue("@expirydate", expiry);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("The data is updated successfully!!!");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox1.Focus();
                            comboBox1.SelectedIndex = 0;
                            guna2DateTimePicker1.Value = DateTime.Now;
                            //promptData();
                        }
                        else
                        {
                            MessageBox.Show("An Expired Product is not allowed to be added");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a valid Price!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a valid Name of Product");
                }
            }
        }
        void promptData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Products", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["SubCategoryId"].Visible = false;

            DataGridViewColumn subcategoryColumn = new DataGridViewTextBoxColumn();
            subcategoryColumn.HeaderText = "Subcategory";
            subcategoryColumn.Name = "SubCat";
            subcategoryColumn.DisplayIndex = 5;
            dataGridView1.Columns.Add(subcategoryColumn);

            dataGridView1.DataBindingComplete += (sender, e) =>
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int id = Convert.ToInt32(row.Cells["SubCategoryId"].Value);
                    string name = getSubCategoryName(id);
                    row.Cells[subcategoryColumn.Index].Value = name;
                }
            };
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
                int categoryid = Convert.ToInt32(selectedRow.Cells["SubCategoryId"].Value);
                string price = selectedRow.Cells["Price"].Value.ToString();
                DateTime expiry = DateTime.Parse(selectedRow.Cells["ExpiryDate"].Value.ToString());

                textBox1.Text = name;
                textBox2.Text = price;
                comboBox1.SelectedItem = getSubCategoryName(categoryid);
                guna2DateTimePicker1.Value = expiry;
            }
        }
    }
}
