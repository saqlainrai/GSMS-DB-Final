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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace FinalProject.UI_Forms
{
    public partial class AddCategories : Form
    {
        public AddCategories()
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
            // add Categories
            string name = textBox1.Text;
            string description = richTextBox1.Text;
            if (name != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd;
                if (description == "")
                {
                    cmd = new SqlCommand("Insert into Categories values (@name, NULL)", con);
                }
                else
                {
                    cmd = new SqlCommand("Insert into Categories values (@name, @description)", con);
                }
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.ExecuteNonQuery();
                promptData();
                fillComboBox();
                MessageBox.Show("The Category is Added Successfully!!!");
            }
            else
            {
                MessageBox.Show("Please Enter a Valid Name...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // add Subcategories
            string name = textBox2.Text;
            string category = comboBox1.SelectedItem.ToString();
            int categoryid = findCategoryId(category);
            string description = richTextBox2.Text;

            if (name != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd;
                if (description == "")
                {
                    cmd = new SqlCommand("Insert into SubCategories values (@categoryid, @name, NULL)", con);
                }
                else
                {
                    cmd = new SqlCommand("Insert into SubCategories values (@categoryid, @name, @description)", con);
                }
                cmd.Parameters.AddWithValue("@categoryid", categoryid);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.ExecuteNonQuery();
                promptData();
                MessageBox.Show("The SubCategory is Added Successfully!!!");
            }
            else
            {
                MessageBox.Show("Please Enter a Valid Name...");
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
    }
}
