using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.UI_Forms
{
    public partial class EmployeeDashBoard : Form
    {
        Form activeForm = null;
        Color defaultButtonColor = Color.FromArgb(33, 11, 97); // Example default color
        Color activeButtonColor = Color.FromArgb(75, 8, 138);  // Example active color
        Form parentForm;
        string userId;
        public EmployeeDashBoard(Form parent, string id)
        {
            InitializeComponent();
            parentForm = parent;
            this.userId = id;
        }
        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            flowPanel.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.Tag = this;
            childForm.BringToFront();
            childForm.Show();
            ResetButtonColors();
        }
        private void ResetButtonColors()
        {
            homeBtn.BackColor = defaultButtonColor;
            customersBtn.BackColor = defaultButtonColor;
            supplierBtn.BackColor = defaultButtonColor;
            orderBtn.BackColor = defaultButtonColor;
            reportsBtn.BackColor = defaultButtonColor;
        }
        private void customersBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new customers(this.userId));
            customersBtn.BackColor = activeButtonColor;
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PlaceOrder());
            orderBtn.BackColor = activeButtonColor;
        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new supplier(this.userId));
            supplierBtn.BackColor = activeButtonColor;  
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new purchaseItems());
            reportsBtn.BackColor = activeButtonColor;   
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            activeForm?.Close();
            homeBtn.BackColor = activeButtonColor;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parentForm.Show();
        }
    }
}
