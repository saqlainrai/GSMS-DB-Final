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
                int tupleKey = Convert.ToInt32(selectedRow.Cells["Id"].Value.ToString());

                textBox1.Text = name;
                textBox2.Text = email;
                textBox3.Text = contact;
                richTextBox1.Text = address;
                richTextBox2.Text = description;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillComboBoxes();
        }
    }
}
