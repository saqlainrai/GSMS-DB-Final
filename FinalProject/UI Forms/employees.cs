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
    public partial class employees : Form
    {
        Form activeForm = null;

        public employees()
        {
            InitializeComponent();
            OpenChildForm(new AddEmployees());
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
            OpenChildForm(new AddEmployees());
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UpdateEmployees());
        }
    }
}
