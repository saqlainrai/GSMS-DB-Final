using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayAdminMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayEmployeeMenu();
        }

        void displayAdminMenu()
        {
            Form form = new AdminMenu();
            this.Hide();
            form.Show();
        }

        void displayEmployeeMenu()
        {
            Form form = new EmployeeMenu();
            this.Hide();
            form.Show();
        }
    }
}
