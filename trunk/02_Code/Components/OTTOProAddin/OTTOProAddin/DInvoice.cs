using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTOProAddin
{
    public class DInvoice
    {
        public DataSet GetProjectDetails()
        {
            DataSet dsOTTO = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ProjectDetailsforOTTOMaster]";
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
                    throw new Exception("Fehler beim Laden der Daten zu Projekt");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Project details");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsOTTO;
        }

        public DataSet GetInvoiceDetails(EInvoice ObjEInvoice)
        {
            DataSet dsOTTO = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ProjectDetailsforOTTOMaster]";
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
                    throw new Exception("Fehler beim Laden der Daten zu Projekt");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Invoice details");

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
