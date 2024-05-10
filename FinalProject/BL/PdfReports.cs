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
        public static DataTable GetTopCustomers()
        {
            SqlCommand cmd = new SqlCommand("Select * from employees", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable GetTopSaledProducts() 
        {
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable GetLowInStockProducts()
        {
            SqlCommand cmd = new SqlCommand("", con);
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
