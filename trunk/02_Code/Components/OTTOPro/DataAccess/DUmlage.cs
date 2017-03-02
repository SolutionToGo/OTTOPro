﻿using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DUmlage
    {
        public EUmlage UpdateSpecialCost(EUmlage ObjEUmlage)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_SpecialCost]";
                    cmd.Parameters.Add("@ProjectID", ObjEUmlage.ProjectID);
                    cmd.Parameters.Add("@dt", ObjEUmlage.dtSpecialCost);
                    Object Objreturn = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("");
                }
                else
                {
                    throw new Exception("Error while distributing special cost");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEUmlage;
        }

        public EUmlage GetSpecialCost(EUmlage ObjEUmlage)
        {
            try
            {
                ObjEUmlage.dtSpecialCost = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_SpecialCost]";
                    cmd.Parameters.Add("@ProjectID", ObjEUmlage.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ObjEUmlage.dtSpecialCost);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("");
                }
                else
                {
                    throw new Exception("Error while retrieving special cost");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEUmlage;
        }

        public EUmlage ShowUmlage(EUmlage ObjEUmlage)
        {
            try
            {
                ObjEUmlage.dtUmlage = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ShowUmlage]";
                    cmd.Parameters.Add("@ProjectId", ObjEUmlage.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ObjEUmlage.dtUmlage);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("");
                }
                else
                {
                    throw new Exception("Error while retrieving umlage");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEUmlage;
        }
    }
}