using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace FinalProject.BL
{
    public class validatation
    {
        public enum ValidationPerson
        {
            //For all persons
            None,
            EmptyField,
            NameExceed,
            EmailExceed,
            ContactExceed,
            AddressExceed,
            //for Employees
            AccountNoExceed,
            SalaryExceed,
            FNameExceed,

            //for Customer
            ProfessionExceed,
            RegisteredbByExceed,
            cnicExceed,

            //for Suplier
            statusExceed,
            descriptionExceed
        }
        public static ValidationPerson ValidateEmployees(string Name,string email,decimal salary,string FName,string AccountNo,string address,string contact)
        {
            if (string.IsNullOrEmpty(Name) || Name.Length > 50)
            {
                return ValidationPerson.NameExceed;
            }
            else if (string.IsNullOrEmpty(email) || email.Length > 60 || IsValidEmail(email))
            {
                //return ValidationPerson.EmailExceed;
            }
            else if(string.IsNullOrEmpty(contact) || email.Length > 60)
            {
                return ValidationPerson.ContactExceed;
            }
            else if (String.IsNullOrEmpty(AccountNo) || AccountNo.Length > 24)
            {
                return ValidationPerson.AccountNoExceed;
            }
            else if ( IsDecimalValid(salary) || salary.ToString().Length > 24)
            {
                return ValidationPerson.AccountNoExceed;
            }

            return ValidationPerson.None;
        }
        public static bool IsDecimalValid(decimal? value)
        {
            // Check if the value is not null
            if (value.HasValue)
            {
                // Convert the decimal to a string and split it by the decimal separator
                string[] parts = value.ToString().Split('.');

                // Check if the decimal has more than 2 digits after the decimal point
                if (parts.Length == 2 && parts[1].Length > 2)
                {
                    return false;
                }

                // Check if the total number of digits does not exceed 18
                return value.ToString().Replace(".", "").Length <= 18;
            }
            else
            {
                // If the value is null, return false
                return false;
            }
        }


        public static bool IsValidEmail(string email)
        {
            // Regular expression pattern for validating email addresses
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the email matches the pattern
            return true;
            return Regex.IsMatch(email, pattern);
        }
        public static string getPasswordFromAccount(string AccountNo)
        {
            int length = AccountNo.Length;
            // Assign the last 5 characters to another string variable
            string lastFiveCharacters = length >= 5 ? AccountNo.Substring(length - 5) : AccountNo;
            return lastFiveCharacters;
        }

        public static ValidationPerson ValidateCustomers(string Name,string Email)
        {
            return ValidationPerson.None;
        }
    }
}
