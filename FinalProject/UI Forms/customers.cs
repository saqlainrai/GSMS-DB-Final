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
    public partial class customers : Form
    {
        Form activeForm = null;
        public customers()
        {
            InitializeComponent();
            OpenChildForm(new AddCustomers());
        }
        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            customersPanel.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.Tag = this;
            childForm.BringToFront();
            childForm.Show();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddCustomers());
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new updateCustomers());
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customersPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
