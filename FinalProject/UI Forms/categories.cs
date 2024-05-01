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
    public partial class categories : Form
    {
        Form activeForm = null;
        public categories()
        {
            InitializeComponent();
            OpenChildForm(new AddCategories());
        }
        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            categoriesPanel.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.Tag = this;
            childForm.BringToFront();
            childForm.Show();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddCategories());
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UpdateCategories());
        }
        private void delBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DeleteCategories());
        }
    }
}
