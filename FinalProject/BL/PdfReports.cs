using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BL
{
    public  class PdfReports
    {
        public static SqlConnection con = Configuration.getInstance().getConnection();
        public static DataTable Attendence()
        {
            SqlCommand cmd = new SqlCommand("SELECT E.Name AS EmployeeName, A.Date AS Date, A.Shift, L.Value FROM Employees E INNER JOIN EmployeeAttendances EA ON E.Id = EA.EmployeeId INNER JOIN Attendances A ON EA.AttendanceId = A.Id JOIN LookUps L ON EA.Status = L.Status ORDER BY E.Name, A.Date;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable GetExpiry() 
        {
            SqlCommand cmd = new SqlCommand("SELECT \r\n    P.Name AS ProductName,\r\n    P.ExpiryDate AS ExpiryDate\r\nFROM \r\n    Products P\r\nWHERE \r\n    P.ExpiryDate <= GETDATE()\r\nORDER BY \r\n    P.ExpiryDate;\r\n", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable OrderHistory()
        {
            SqlCommand cmd = new SqlCommand("SELECT \r\n    O.Id AS OrderId,\r\n    C.Name AS CustomerName,\r\n    E.Name AS EmployeeName,\r\n    O.TotalPrice AS TotalPrice,\r\n    O.DateUpdated AS OrderDate\r\nFROM \r\n    Orders O\r\nINNER JOIN \r\n    Customers C ON O.CustomerId = C.Id\r\nINNER JOIN \r\n    Employees E ON O.EmployeeId = E.Id\r\nORDER BY \r\n    O.DateUpdated DESC;\r\n", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable GetEmployeePerformane()
        {
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
