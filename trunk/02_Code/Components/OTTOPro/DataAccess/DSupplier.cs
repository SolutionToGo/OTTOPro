using DAL;
using EL;
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
        public ESupplier SaveSupplierDetails(XmlDocument XmlDoc,ESupplier ObjESupplier)
        {
            int SupplierID = -1;
            DataSet ds = new DataSet();
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

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out SupplierID))
                        {
                            ObjESupplier.SupplierID = SupplierID;
                            ObjESupplier.dtSupplier = ds.Tables[1];
                        }
                        else if (str.ToString().Contains("duplicate"))
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
                        else
                            throw new Exception(str);
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
            return ObjESupplier;
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

        public ESupplier SavedsSupplierContactDetails(XmlDocument XmlDoc,ESupplier ObjESupplier)
        {
            DataSet ds = new DataSet();
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

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out ContactPersonID))
                        {
                            ObjESupplier.ContactPersonID = ContactPersonID;
                            ObjESupplier.dtContact = ds.Tables[1];
                        }
                        else
                        {
                            throw new Exception(str);
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
            return ObjESupplier;
        }

        public ESupplier SaveSupplierAddressDetails(XmlDocument XmlDoc, ESupplier ObjESupplier)
        {
            DataSet ds = new DataSet();
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

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out AddressID))
                        {
                            ObjESupplier.AddressID = AddressID;
                            ObjESupplier.dtAddress = ds.Tables[1];
                        }
                        else if (str.ToString().Contains("DefaultAddress"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Diese Standardadresse existiert bereits");
                            }
                            else
                            {
                                throw new Exception("Default Address is already exists.!");
                            }
                        }
                        else
                            throw new Exception(str);
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
            return ObjESupplier;
        }

        public ESupplier SaveArticle(ESupplier ObjESupplier)
        {
             DataSet ds = new DataSet();
            int iArtcleID = -1;
            try
            {
                using ( SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_WGWA]";
                    cmd.Parameters.AddWithValue("@WGWAID", ObjESupplier.WGWAID);
                    cmd.Parameters.AddWithValue("@SupplierID", ObjESupplier.SupplierID);
                    cmd.Parameters.AddWithValue("@WG", ObjESupplier.WG);
                    cmd.Parameters.AddWithValue("@WA", ObjESupplier.WA);
                    cmd.Parameters.AddWithValue("@WGDescription", ObjESupplier.WGDescription);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out iArtcleID))
                        {
                            ObjESupplier.WGWAID = iArtcleID;
                            ObjESupplier.dtArticle = ds.Tables[1];
                        }
                        else if (str.ToString().Contains("UNIQUE"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("");
                            }
                            else
                            {
                                throw new Exception("Article already exists..!");
                            }
                        }
                        else
                            throw new Exception(str);
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
            return ObjESupplier;
        }
    }
}
