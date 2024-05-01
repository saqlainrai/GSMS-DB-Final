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
using FinalProject.DataAccess;

namespace FinalProject.UI_Forms
{
    public partial class AddEmployees : Form
    {
        public AddEmployees()
        {
            InitializeComponent();
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
            
            validatation.ValidationPerson error = validatation.ValidateEmployees(Name, email, salary, FName, AccountNo, address, contact);
            if (error != validatation.ValidationPerson.None)
            {
                string errorMessage = GetErrorMessage(error);
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime currentDateTime = DateTime.Now;






            if (YeschkBx.Checked)
            {
                //assign Credentials to employees, Name as UserName and password is last 5 digits of Account#
               string password = validatation.getPasswordFromAccount(AccountNo);
                LoginCredentials credentials = new LoginCredentials(Name, password,"Employee");
                Queries.AddEmployee(FName,AccountNo,salary,currentDateTime,email,Name,password,contact);
            }

        }
        
        private  string GetErrorMessage(validatation.ValidationPerson error)
        {
            switch (error)
            {
                case validatation.ValidationPerson.NameExceed:
                    return "Please enter correct Name and within 50 characters";
                case validatation.ValidationPerson.EmailExceed:
                    return "Please enter correct Email and within 60 characters";
                case validatation.ValidationPerson.ContactExceed:
                    return "Please enter correct Contact and within 50 characters";


                default:
                    return "Unknown error occurred.";
            }
        }
    }
}
