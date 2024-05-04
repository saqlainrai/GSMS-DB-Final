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
    public partial class AddCustomers : Form
    {
        Form parentForm;
        public AddCustomers(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
