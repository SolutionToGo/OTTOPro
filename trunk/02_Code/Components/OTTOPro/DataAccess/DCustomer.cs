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
    public class DCustomer
    {
        public int SaveCustomerDetails(XmlDocument XmlDoc)
        {
            int CustomerID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Customer]";
                    SqlParameter param = new SqlParameter("@XMLCustomers", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if(returnObj!=null)
                    {
                        if (returnObj.ToString().Contains("duplicate"))
                        {
                            throw new Exception("ShortName is already exists.!");
                        }
                        if (!int.TryParse(returnObj.ToString(), out CustomerID))
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
            return CustomerID;
        }

        public DataSet GetCustomers()
        {
            DataSet dsCustomer = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_Customer]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                   // throw new Exception("Fehler beim Laden der Positionsliste");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Customer");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsCustomer;
        }

        public int SaveCustomerContactDetails(XmlDocument XmlDoc)
        {
            int ContactPersonID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Customer_Contact]";
                    SqlParameter param = new SqlParameter("@XMLCustomerContact", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (!int.TryParse(returnObj.ToString(), out ContactPersonID))
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
            return ContactPersonID;
        }

        public int SaveCustomerAddressDetails(XmlDocument XmlDoc)
        {
            int AddressID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Customer_Address]";
                    SqlParameter param = new SqlParameter("@XMLCustomerAddress", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (returnObj.ToString().Contains("DefaultAddress"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                               // throw new Exception("Diese Projektnummer existiert bereits");
                            }
                            else
                            {
                                throw new Exception("Default Address is already exists");
                            }
                        }
                        if (!int.TryParse(returnObj.ToString(), out AddressID))
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
            return AddressID;
        }



    }
}
