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
    public partial class credentials : Form
    {
        public credentials()
        {
            InitializeComponent();
            promptData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Username, Password, Role from LoginCredentials", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            guna2DataGridView1.DataSource = dataTable;
        }
    }
}
