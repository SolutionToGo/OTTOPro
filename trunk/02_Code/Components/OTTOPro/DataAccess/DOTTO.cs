using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccess
{
    public class DOTTO
    {
        public int SaveOTTODetails(XmlDocument XmlDoc)
        {
            int OTTOID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_OTTODetails]";
                    SqlParameter param = new SqlParameter("@XMLOTTO", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (returnObj.ToString().Contains("duplicate"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Dieser Kurzname ist bereits vergeben");
                            }
                            else
                            {
                                throw new Exception("ShortName is already exists.!");
                            }
                        }
                        if (!int.TryParse(returnObj.ToString(), out OTTOID))
                        {
                            throw new Exception(returnObj.ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return OTTOID;
        }

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
                    throw new Exception("Fehler beim Laden der daten zu OTTO");
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

        public int SaveOTTOContactDetails(XmlDocument XmlDoc)
        {
            int ContactID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_OTTO_Contact]";
                    SqlParameter param = new SqlParameter("@XMLOTTOContact", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (!int.TryParse(returnObj.ToString(), out ContactID))
                        {
                            throw new Exception(returnObj.ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ContactID;
        }

        public void ImportCustomerData(DataTable dt)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[p_upd_customerdata]";
                    cmd.Parameters.AddWithValue("@dtCusotmerData", dt);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

//***************
}
