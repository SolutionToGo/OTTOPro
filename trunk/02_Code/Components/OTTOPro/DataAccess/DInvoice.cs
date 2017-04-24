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
    public class DInvoice
    {
        public EInvoice GetDeliveryNotes(EInvoice ObjEInvoice)
        {
            try
            {
                DataSet dsInvoices = new DataSet();
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = SQLCon.Sqlconn();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[P_Get_DeliveryNotes]";
                        cmd.Parameters.AddWithValue("@ProjectID", ObjEInvoice.ProjectID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dsInvoices);
                        }
                    }
                    if (dsInvoices != null)
                    {
                        if(dsInvoices.Tables.Count > 0)
                            ObjEInvoice.dtDeliveryNumbers = dsInvoices.Tables[0];
                        if (dsInvoices.Tables.Count > 1)
                            ObjEInvoice.dtInvoices = dsInvoices.Tables[1];
                        
                    }
                }
                catch (Exception ex)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("To Be Updated");
                    else
                        throw new Exception("Error While Retrieving the Delivery Notes");
                }
                finally
                {
                    SQLCon.Sqlconn().Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEInvoice;
        }

        public EInvoice SaveInvoice(EInvoice ObjEInvoice)
        {
            DataSet dsInvoices = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Invoice]";
                    cmd.Parameters.AddWithValue("@InvoiceID", ObjEInvoice.InvoiceID);
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEInvoice.ProjectID);
                    cmd.Parameters.AddWithValue("@InvoiceNumber", ObjEInvoice.InvoiceNumber);
                    cmd.Parameters.AddWithValue("@dtInvoice", ObjEInvoice.dtInvoice);
                    cmd.Parameters.AddWithValue("@IsFinalInvoice", ObjEInvoice.IsFinalInvoice);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsInvoices);
                    }
                }
                if (dsInvoices != null && dsInvoices.Tables.Count > 0)
                {
                    if (dsInvoices.Tables[0].Rows.Count > 0)
                    {
                        string strError = dsInvoices.Tables[0].Rows[0][0].ToString();
                        if (strError.Contains("Atleast"))
                        {
                            throw new Exception(strError);
                        }
                    }
                    ObjEInvoice.dtDeliveryNumbers = dsInvoices.Tables[0];
                    if(dsInvoices.Tables.Count > 1)
                        ObjEInvoice.dtInvoices = dsInvoices.Tables[1];
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Atleast"))
                    throw new Exception(ex.Message);
                else
                    throw new Exception("Error While Saving the Invoice");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEInvoice;
        }
    }
}
