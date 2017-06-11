using DAL;
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
    public class DReportDesign
    {
        public DataSet GetReportDesignTypes(string _TYPE)
        {
            DataSet dsReportDesign = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ReportDesignTypes]";
                    cmd.Parameters.AddWithValue("@Type", _TYPE);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsReportDesign);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der daten");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving the data");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsReportDesign;
        }

        public DataSet SaveReportDesignTypes(EReportDesign ObjEReportDesign, string _TYPE)
        {
            DataSet dsReportDesign = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_ReportDesign]";
                    cmd.Parameters.AddWithValue("@Type", _TYPE);
                    cmd.Parameters.AddWithValue("@col1", ObjEReportDesign.Col1);
                    cmd.Parameters.AddWithValue("@col2", ObjEReportDesign.Col2);
                    cmd.Parameters.AddWithValue("@col3", ObjEReportDesign.Col3);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsReportDesign);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der daten");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving the data");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsReportDesign;
        }

        public DataSet GetExistingReportDesignData(EReportDesign ObjEReportDesign, string _TYPE)
        {
            DataSet dsReportDesign = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ReportDesign]";
                    cmd.Parameters.AddWithValue("@Type", _TYPE);                   

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsReportDesign);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der daten");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving the data");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsReportDesign;
        }
    }
}
