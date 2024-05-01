using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMidProject.DataAccess
{
    public class Configuration
    {
        private static Configuration _instance;
        private readonly string ConnectionStr = @"Data Source=TABISH-PC;Initial Catalog=GSMS;Integrated Security=True";
        private readonly SqlConnection con;

        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }

        private Configuration()
        {
            try
            {
                con = new SqlConnection(ConnectionStr);
                con.Open();
            }
            catch (SqlException ex)
            {
                // Handle SQL Server-specific exceptions
                MessageBox.Show("SQL Server Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle other general exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { con.Close(); }

        }

        public SqlConnection getConnection()
        {
            return con;
        }
    }
}
