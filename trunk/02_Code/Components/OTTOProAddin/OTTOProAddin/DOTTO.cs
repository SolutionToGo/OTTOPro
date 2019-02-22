using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTOProAddin
{
    public class DOTTO
    {
        public DataSet GetOTTODetails()
        {
            DataSet dsOTTO = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_OTTODetails]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsOTTO);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Daten zu OTTO");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving OTTO details");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsOTTO;
        }

    }
}
