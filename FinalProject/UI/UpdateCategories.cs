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
    public partial class UpdateCategories : Form
    {
        public UpdateCategories()
        {
            InitializeComponent();
            fillComboBox();
            promptData();
            dataGridView1.ColumnHeadersHeight = 25;
            dataGridView2.ColumnHeadersHeight = 25;
        }
        private void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            d.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            var c = Configuration.getInstance().getConnection();
            SqlCommand cm = new SqlCommand("SELECT * FROM SubCategories", c);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // update Categories
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                string name = textBox1.Text;
                string description = richTextBox1.Text;
                if (name != "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd;
                    if (description == "")
                    {
                        cmd = new SqlCommand("Update Categories Set Name = @name, Description = NULL WHERE Id = @id", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("Update Categories Set Name = @name, Description = @description WHERE Id = @id", con);
                    }
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    promptData();
                    MessageBox.Show("The Data is Updated Successfully!!!");
                }
                else
                {
                    MessageBox.Show("Please Enter a Valid Name...");
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);
                string name = textBox2.Text;
                string category = comboBox1.SelectedText;
                int categoryid = findCategoryId(category);
                string description = richTextBox2.Text;
                if (name != "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd;
                    if (description == "")
                    {
                        cmd = new SqlCommand("Update Categories Set Name = @name, Description = NULL WHERE Id = @id", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("Update Categories Set Name = @name, Description = @description WHERE Id = @id", con);
                    }
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    promptData();
                    MessageBox.Show("The Data is Updated Successfully!!!");
                }
                else
                {
                    MessageBox.Show("Please Enter a Valid Name...");
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row...");
            }
        }
        private int findCategoryId(string name)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Categories", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            d.Fill(dataTable);
            List<string> columnEntries = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["Id"].ToString();
                string n = row["Name"].ToString();
                columnEntries.Add(id + "," + n);
            }
            int flag = -1;
            foreach (string s in columnEntries)
            {
                if (name == s.Split(',')[1])
                {
                    flag = Convert.ToInt32(s.Split(',')[0]);
                }
            }
            return flag;
        }
        private void fillComboBox()
        {
            comboBox1.Items.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Categories", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            d.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                comboBox1.Items.Add(row["Name"].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                string desc = dataGridView1.SelectedRows[0].Cells["Description"].Value.ToString();

                textBox1.Text = name;
                richTextBox1.Text = desc;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string name = dataGridView2.SelectedRows[0].Cells["Name"].Value.ToString();
                int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["CategoryId"].Value);
                string i = findName(id);
                string desc = dataGridView2.SelectedRows[0].Cells["Description"].Value.ToString();

                textBox2.Text = name;
                richTextBox2.Text = desc;
                comboBox1.SelectedItem = i;
            }
        }
        private string findName(int i)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Categories", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            d.Fill(dataTable);
            List<string> columnEntries = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["Id"].ToString();
                string n = row["Name"].ToString();
                columnEntries.Add(id + "," + n);
            }
            string flag = "";
            foreach (string s in columnEntries)
            {
                if (i == Convert.ToInt32(s.Split(',')[0]))
                {
                    flag = s.Split(',')[1].ToString();
                }
            }
            return flag;
        }
    }
}
