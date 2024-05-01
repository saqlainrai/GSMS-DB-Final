using DBMidProject.DataAccess;
using FinalProject.BL;
using FinalProject.DataAccess;
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
           
            LoginCredentials credentials = new LoginCredentials(userName, password,null);
            string Role =  Queries.getRole(credentials);
            if(Role == "Admin")
            {
                Main main = new Main();
                this.Hide();
                main.ShowDialog();
            }
            else if(Role == "Employee")
            {
                EmployeeDashBoard employeeBoard = new EmployeeDashBoard();
                this.Hide();
                employeeBoard.ShowDialog();
            }




            
        }



    }
}
