using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BL
{
    class Employee : Person
    {
        private string fName;
        private int userId;
        private string accountNumber;
        private decimal salary;
        private DateTime joiningDate;

        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public DateTime JoiningDate
        {
            get { return joiningDate; }
            set { joiningDate = value; }
        }

        public Employee(string fName,int UserId,string AccountNo, decimal salary,DateTime dateTime,string Email,string Name,string Contact)
        {
            this.fName = fName;
            this.userId = UserId;
            this.accountNumber = AccountNo;
            this.salary = salary;
            this.joiningDate = dateTime;
            this.Email = Email;
            this.Name = Name;
            this.Contact = Contact;
            
        }
    }
}
