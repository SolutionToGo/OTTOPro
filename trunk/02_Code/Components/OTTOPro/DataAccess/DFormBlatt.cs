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
    public class DFormBlatt
    {
        public EFormBlatt Get_tbl221_1(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                DataSet ds = new DataSet();
                ObjEFormBlatt.dtBlatt221_1 = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_tbl221_1]";
                    cmd.Parameters.Add("@ProjectID", ObjEFormBlatt.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        ObjEFormBlatt.dtBlatt221_1=ds.Tables[0];
                        ObjEFormBlatt.dtProjectDetails = ds.Tables[1];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                   // throw new Exception("Fehler beim Laden der Generellen Kosten");
                }
                else
                {
                    throw new Exception("Error while retrieving form blatt");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEFormBlatt;
        }

    }
}
