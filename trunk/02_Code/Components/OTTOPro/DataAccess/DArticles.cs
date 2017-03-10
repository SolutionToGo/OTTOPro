using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class DArticles
    {
        public DataSet GetArticles(int _wgId, int _WiId)
        {
            DataSet dsArticles = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_WGWAWI]";
                    cmd.Parameters.Add("@WGID", _wgId);
                    cmd.Parameters.Add("@WIID", _WiId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsArticles);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                   // throw new Exception("Fehler beim Laden des Kunden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Articles");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsArticles;
        }

    }
}
