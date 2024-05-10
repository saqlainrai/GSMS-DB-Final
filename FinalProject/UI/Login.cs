//using DBMidProject.DataAccess;
using FinalProject.BL;
using FinalProject.DL;
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
    public partial class Login : Form
    {
        const string AdminId = "3";
        public Login()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                passwordBx.PasswordChar = '\0';
            }
            if (!checkBox1.Checked)
            {
                passwordBx.PasswordChar = '*';
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string userName = userNameBx.Text;
            string password = passwordBx.Text;

            DL.Credentials credentials = new DL.Credentials(userName, password,null);
            string Role =  Queries.getRole(credentials);
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM LoginCredentials WHERE userName = @Username AND password = @Password", con);
            cmd.Parameters.AddWithValue("@Username", credentials.UserName);
            cmd.Parameters.AddWithValue("@Password", credentials.Password);
            object result = cmd.ExecuteScalar();
            string userid = result != null ? result.ToString() : null;

            if (Role == "Admin")
            {
                Main main = new Main(this, AdminId);
                this.Hide();
                main.Show();
                userNameBx.Clear();
                passwordBx.Clear();
            }
            else if(Role == "Employee")
            {
                EmployeeDashBoard employeeBoard = new EmployeeDashBoard(this, userid);
                this.Hide();
                employeeBoard.ShowDialog();
                userNameBx.Clear();
                passwordBx.Clear();
            }
            else
            {
                MessageBox.Show("The User is Not Found in the Database");
                passwordBx.Clear();
            }
        }
    }
}
