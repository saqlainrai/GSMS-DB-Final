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
            this.Resize += credentials_Resize;
        }
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Username, Password, Role from LoginCredentials", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            credentialsDG.DataSource = dataTable;
        }

        private void credentialsDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void credentials_Resize(object sender, EventArgs e)
        {
            float newSize = this.Width * 0.02f; // Adjust this multiplier to suit your needs
            Font newFont = new Font("Arial", newSize, FontStyle.Regular);

            fNameBx.Font = newFont;
        }
    }
}
