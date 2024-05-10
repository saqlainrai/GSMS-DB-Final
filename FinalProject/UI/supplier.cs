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
    public partial class supplier : Form
    {
        Form activeForm = null;
        public string actorId;
        public supplier(string id)
        {
            InitializeComponent();
            OpenChildForm(new addSupplier(this, id));
            this.actorId = id;
        }
        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            supplierPanel.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.Tag = this;
            childForm.BringToFront();
            childForm.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new addSupplier(this, actorId));
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new updateSupplier(this));
        }
    }
}
