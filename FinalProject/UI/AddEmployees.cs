using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.BL;
using FinalProject.DL;

namespace FinalProject.UI_Forms
{
    public partial class AddEmployees : Form
    {
        Form parentForm;
        public AddEmployees(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string Name = nameBx.Text;
            string email = mailBx.Text;
            decimal salary = decimal.Parse(salaryBx.Text);
            string FName = fNameBx.Text;
            string AccountNo = (accountBx.Text);
            string address = addressBx.Text;
            string contact = contactBx.Text;
            
            Validatation.ValidationPerson error = Validatation.ValidateEmployees(Name, email, salary, FName, AccountNo, address, contact);
            if (error != Validatation.ValidationPerson.None)
            {
                string errorMessage = GetErrorMessage(error);
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime currentDateTime = DateTime.Now;






            if (YeschkBx.Checked)
            {
                //assign Credentials to employees, Name as UserName and password is last 5 digits of Account#
               string password = Validatation.getPasswordFromAccount(AccountNo);
                Credentials credentials = new Credentials(Name, password,"Employee");
                Queries.AddEmployee(FName,AccountNo,salary,currentDateTime,email,Name,password,contact);
            }

        }
        
        private  string GetErrorMessage(Validatation.ValidationPerson error)
        {
            switch (error)
            {
                case Validatation.ValidationPerson.NameExceed:
                    return "Please enter correct Name and within 50 characters";
                case Validatation.ValidationPerson.EmailExceed:
                    return "Please enter correct Email and within 60 characters";
                case Validatation.ValidationPerson.ContactExceed:
                    return "Please enter correct Contact and within 50 characters";


                default:
                    return "Unknown error occurred.";
            }
        }
    }
}
