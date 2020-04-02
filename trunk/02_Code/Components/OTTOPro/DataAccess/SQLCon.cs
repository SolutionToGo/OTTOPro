﻿using log4net;
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
    public static class SQLCon
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static SqlConnection ObjCon = new SqlConnection();
        static SqlConnection ObjCockpitConn = new SqlConnection();

        public static SqlConnection Sqlconn()
        {
            try
            {
                if (ObjCon.State == ConnectionState.Closed)
                {
                    Log.Info("Connection is Closed");
                    ObjCon.ConnectionString = ConfigurationManager.ConnectionStrings["OTTOPro"].ToString();
                    ObjCon.Open();
                    Log.Info("Connection is Open");
                }
            }
            catch (Exception ex){ Log.Error(ex.Message, ex); }
            return ObjCon;
        }

        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["OTTOPro"].ToString();
        }

        public static SqlConnection CockpitConnection()
        {
            if (ObjCockpitConn.State == ConnectionState.Open)
            {
                return ObjCockpitConn;
            }
            else
            {
                ObjCockpitConn.ConnectionString = ConfigurationManager.AppSettings["CockpitConnection"].ToString();
                ObjCockpitConn.Open();
                return ObjCockpitConn;
            }
        }

        public static void Close()
        {
            try
            {
                //if (ObjCon.State == ConnectionState.Open)
                //{
                //    ObjCon.Close();
                //}
            }
            catch (Exception ex) { Log.Error(ex.Message, ex); }
        }

        static SqlConnection ObjCon2 = new SqlConnection();

        public static SqlConnection Sqlconn2()
        {
            try
            {
                if (ObjCon2.State == ConnectionState.Closed)
                {
                    Log.Info("Connection is Closed");
                    ObjCon2.ConnectionString = ConfigurationManager.ConnectionStrings["OTTOPro"].ToString();
                    ObjCon2.Open();
                    Log.Info("Connection is Open");
                }
            }
            catch (Exception ex) { Log.Error(ex.Message, ex); }
            return ObjCon2;
        }

        public static void Close2()
        {
            try
            {
            
            }
            catch (Exception ex) { Log.Error(ex.Message, ex); }
        }
    }
}
