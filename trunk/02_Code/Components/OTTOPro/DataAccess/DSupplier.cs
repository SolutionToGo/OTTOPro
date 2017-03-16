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
    public class DSupplier
    {
        public int SaveSupplierDetails(XmlDocument XmlDoc)
        {
            int SupplierID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Supplier]";
                    SqlParameter param = new SqlParameter("@XMLSupplier", SqlDbType.Xml);
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
                        if (!int.TryParse(returnObj.ToString(), out SupplierID))
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
            return SupplierID;
        }

        public DataSet GetSupplier()
        {
            DataSet dsSupplier = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_Supplier]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsSupplier);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden des Kunden");
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
            return dsSupplier;
        }

        public int SavedsSupplierContactDetails(XmlDocument XmlDoc)
        {
            int ContactPersonID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Supplier_Contact]";
                    SqlParameter param = new SqlParameter("@XMLSupplierContact", SqlDbType.Xml);
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

        public int SaveSupplierAddressDetails(XmlDocument XmlDoc)
        {
            int AddressID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Supplier_Address]";
                    SqlParameter param = new SqlParameter("@XMLSupplierAddress", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (returnObj.ToString().Contains("DefaultAddress"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Diese Standardadresse existiert bereits");
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
