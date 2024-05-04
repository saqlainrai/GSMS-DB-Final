//using DBMidProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.UI_Forms;
using FinalProject.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Data;

namespace FinalProject.DL
{
    public static class Queries
    {
        // Use the SqlConnection object declared at the class level
        //public static SqlConnection con = Configuration.getInstance().getConnection();

        public static string getRole(Credentials credentials)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Role FROM LoginCredentials WHERE userName = @Username AND password = @Password", con);
            cmd.Parameters.AddWithValue("@Username", credentials.UserName);
            cmd.Parameters.AddWithValue("@Password", credentials.Password);
            object result = cmd.ExecuteScalar();
            string role = result != null ? result.ToString() : null;
            return role;


            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dataTable = new DataTable();
            //da.Fill(dataTable);

            // Previous Code

            //using (SqlConnection con = Configuration.getInstance().getConnection())
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("SELECT Role FROM LoginCredentials WHERE userName = @Username AND password = @Password", con);
            //    cmd.Parameters.AddWithValue("@Username", credentials.UserName);
            //    cmd.Parameters.AddWithValue("@Password", credentials.Password);

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.Read()) // Check if there is a row to read
            //    {
            //        string role = reader["Role"].ToString();
            //        reader.Close();
            //        return role; // Return the role if credentials are correct
            //    }
            //    else
            //    {
            //        //Credentials for Admin in Code
            //        string AdminUserName = "user";
            //        string AdminPassword = "123";
            //        if (credentials.UserName == AdminUserName && credentials.Password == AdminPassword)
            //        {
            //            return "Admin";
            //        }
            //        reader.Close();
            //        return null; // Return null if credentials are incorrect
            //    }
            //}
        }
        public static void AddEmployee(string fName, string AccountNo, decimal salary, DateTime dateTime, string Email, string Name, string password, string Contact)
        {
            Credentials credentials = new Credentials(Name, password, "Employee");
            using (SqlConnection con = Configuration.getInstance().getConnection())
            {
                con.Open();

                // Begin transaction
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Add login credentials
                    SqlCommand credentialsCmd = new SqlCommand("INSERT INTO LoginCredentials (userName, password) VALUES (@Username, @Password); SELECT SCOPE_IDENTITY()", con, transaction);
                    credentialsCmd.Parameters.AddWithValue("@Username", credentials.UserName);
                    credentialsCmd.Parameters.AddWithValue("@Password", credentials.Password);
                    int userId = Convert.ToInt32(credentialsCmd.ExecuteScalar());

                    //add employees
                    string sqlQuery = "INSERT INTO Employees (UserId,FName, AccountNo, Salary, JoiningDate, Email, Name, Contact) VALUES (@UserId,@FName, @AccountNo, @Salary, @JoiningDate, @Email, @Name, @Contact)";

                    SqlCommand employeeCmd = new SqlCommand(sqlQuery, con, transaction);
                    employeeCmd.Parameters.AddWithValue("@FName", fName);
                    employeeCmd.Parameters.AddWithValue("@AccountNo", AccountNo);
                    employeeCmd.Parameters.AddWithValue("@Salary", salary);
                    employeeCmd.Parameters.AddWithValue("@JoiningDate", DateTime.Now);
                    employeeCmd.Parameters.AddWithValue("@Email", Email);
                    employeeCmd.Parameters.AddWithValue("@Name", Name);
                    employeeCmd.Parameters.AddWithValue("@Contact", Contact);
                    employeeCmd.ExecuteNonQuery();



                    // Commit the transaction if all operations are successful
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if any error occurs
                    transaction.Rollback();
                    // Handle the exception (e.g., log it or show an error message)
                    Console.WriteLine("Error occurred: " + ex.Message);
                }
            }
        }


    }
}
