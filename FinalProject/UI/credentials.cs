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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject.UI_Forms
{
    public partial class credentials : Form
    {
        private int credentialId = 0;
        public credentials()
        {
            InitializeComponent();
            promptData();

        }
        void fillTextBoxes()
        {
            if (credentialsDG.SelectedRows.Count > 0)
            {
                int selectedIndex = credentialsDG.SelectedRows[0].Index;

                DataGridViewRow selectedRow = credentialsDG.Rows[selectedIndex];

                string name = selectedRow.Cells["Username"].Value.ToString();
                string pass = selectedRow.Cells["Password"].Value.ToString();
                credentialId = Convert.ToInt32(selectedRow.Cells["Id"].Value.ToString());


                txtUsername.Text = name;
                txtPassword.Text = pass;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Resize += credentials_Resize;
        }
        void promptData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id, Username, Password, Role from LoginCredentials", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            credentialsDG.DataSource = dataTable;
            credentialsDG.Columns["ID"].Visible = false;
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            if (credentialsDG.SelectedRows.Count > 0)
            {
                string name = txtUsername.Text;
                string pass = txtPassword.Text;

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE LoginCredentials SET Username = @user, Password = @pass WHERE Id = @id", con);
                cmd.Parameters.AddWithValue("@user", name);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@id", credentialId);
                cmd.ExecuteNonQuery();
                promptData();
            }
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            fillTextBoxes();

        }

        private void credentials_Resize(object sender, EventArgs e)
        {
            float newSize = this.Width * 0.02f; // Adjust this multiplier to suit your needs
            Font newFont = new Font("Arial", newSize, FontStyle.Regular);
            //fNameBx.Font = newFont;
        }
    }
}
