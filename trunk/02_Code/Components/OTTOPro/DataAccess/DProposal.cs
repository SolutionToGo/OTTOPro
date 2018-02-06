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
    public class DProposal
    {
        public int SaveTextModuleDetails(XmlDocument XmlDoc)
        {
            int TextID = -1;
            try
            {
                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_TextModule]";
                    SqlParameter param = new SqlParameter("@XMLTextModule", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (!int.TryParse(returnObj.ToString(), out TextID))
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
            return TextID;
        }


        public int SaveCategory(XmlDocument XmlDoc)
        {
            int CategoryID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Category]";
                    SqlParameter param = new SqlParameter("@XMLCategory", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (!int.TryParse(returnObj.ToString(), out CategoryID))
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
            return CategoryID;
        }

        public DataSet GetTextModuleAreas()
        {
            DataSet dsTextModuleAreas = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_TextModuleAreas]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsTextModuleAreas);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Daten");
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
            return dsTextModuleAreas;
        }

        public DataSet GetCategories(int _textID)
        {
            DataSet dsCategory = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_Category]";
                    cmd.Parameters.AddWithValue("@TextareaID", _textID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Daten");
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
            return dsCategory;
        }

        public DataSet DeleteTextModuleAreas(EProposal ObjEProposal,int ID)
        {
            DataSet dsTextModuleAreas = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Del_TextModule]";
                    cmd.Parameters.AddWithValue("@TextID", ID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Löschen der Daten");
                }
                else
                {
                    throw new Exception("Error Occured While deleting the data");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsTextModuleAreas;
        }
    }
}
