using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static class SQLCon
    {
        /// <summary>
        /// Static SQL Connection to connect with database
        /// </summary>
        static SqlConnection ObjCon = new SqlConnection();
        public static SqlConnection Sqlconn()
        {
            if (ObjCon.State == ConnectionState.Open)
            {
                return ObjCon;
            }
            else
            {
                ObjCon.ConnectionString = ConfigurationManager.ConnectionStrings["OTTOPro"].ToString();
                ObjCon.Open();
                return ObjCon;
            }
        }
    }
}
