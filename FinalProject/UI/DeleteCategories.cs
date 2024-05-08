using FinalProject.BL;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinalProject.UI_Forms
{
    public partial class DeleteCategories : Form
    {
        public DeleteCategories()
        {
            InitializeComponent();
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
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete from Categories WHERE Id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    promptData();
                    MessageBox.Show("The Category is Deleted Successfully!!!");
                }
                else
                {
                    MessageBox.Show("Please Select a Row...");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0x223)
                {
                    MessageBox.Show("The Category is linked with a Subcategory, Delete it first!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete from SubCategories WHERE Id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    promptData();
                    MessageBox.Show("The SubCategory is Deleted Successfully!!!");
                }
                else
                {
                    MessageBox.Show("Please Select a Row...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
