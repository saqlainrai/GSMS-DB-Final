using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BL
{
    class Configuration
    {
        String ConnectionStr = @"Data Source=(local);Initial Catalog=plag;Integrated Security=True";
        //                             Add the name of database here (^^^) Just and leave the rest, here it is "plag"
        SqlConnection con;
        private static Configuration _instance;
        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }
        private Configuration()
        {
            con = new SqlConnection(ConnectionStr);
            con.Open();
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}
