using DAL;
using EL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccess
{
    public class DPosition
    {
        public int SavePositionDetails(XmlDocument XmlDoc,int iProjectID, string LongDescription)
        {
            int ProjectID = -1;
            try
            {
                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Position]";
                    SqlParameter param = new SqlParameter("@XMLPositions", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);
                    cmd.Parameters.AddWithValue("@ProjectID", iProjectID);
                    cmd.Parameters.AddWithValue("@LongDescription", LongDescription);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (returnObj.ToString().Contains("UNIQUE"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Diese Ordnungskennzahl existiert bereits");
                            }
                            else
                            {
                                throw new Exception("OZ Already Exists");
                            }
                        }
                        
                        else if (returnObj.ToString().Contains("Title"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Dieser Titel / Untertitel existiert nicht");
                            }
                            else
                            {
                                throw new Exception(returnObj.ToString());
                            }
                        }
                        else if (returnObj.ToString().Contains("Surcharge"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Eine Surcharge kann nicht mehrfach für die gleichen Positionen angelegt werden");
                           }
                            else
                            {
                                throw new Exception(returnObj.ToString());
                            }
                        }
                        else if (returnObj.ToString().Contains("Sum"))
                        {
                           if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Eine Summe kann nicht mehrfach für die gleichen Positionen angelegt werden");
                            }
                            else
                            {
                                throw new Exception(returnObj.ToString());
                            }
                        }
                        else if (!int.TryParse(returnObj.ToString(), out ProjectID))
                            throw new Exception(returnObj.ToString());
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
            return ProjectID;
        }

        public DataSet GetPsoitionList(int ProjectID)
        {
            DataSet dsPositionsList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionList]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositionsList, "Positions");
                    }                   
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Positionsliste");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Position List");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsPositionsList;
        }

        public string GetLongDescription(int PositionID)
        {
            string LongDescription = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_LongDescription]";
                    cmd.Parameters.AddWithValue("@PositionID", PositionID);
                    Object ObjReturn = cmd.ExecuteScalar();
                    if (ObjReturn != null && ObjReturn != DBNull.Value)
                    {
                        LongDescription = ObjReturn.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Positionsliste");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Position List");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return LongDescription;
        }

        public DataTable GetPositionKZ()
        {
            DataTable dt = null;
            try
            {
                 using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionList]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public string GetLVSection(string strLVSection, int ProjectID)
        {
            string strNewLVSection = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_LVSection]";
                    cmd.Parameters.AddWithValue("@LVSectionName", strLVSection);
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        strNewLVSection = Convert.ToString(returnObj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strNewLVSection;
        }

        public void InsertLVSection(string strNewLVSecction, int ProjectID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_LVSection]";
                    cmd.Parameters.AddWithValue("@LVSection", strNewLVSecction);
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetPsoitionOZList(int ProjectID,string tType,DataTable dt)
        {
            DataSet dsPositionsOZList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionOZ]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@Position_Type", tType);
                    cmd.Parameters.AddWithValue("@WG", "");
                    cmd.Parameters.AddWithValue("@WA", "");
                    cmd.Parameters.AddWithValue("@Position_OZ_Table", dt);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositionsOZList, "Positions");
                    }
                    if(dsPositionsOZList !=null && dsPositionsOZList.Tables.Count > 0 && dsPositionsOZList.Tables[0].Rows.Count > 0)
                    {
                        string strError = dsPositionsOZList.Tables[0].Rows[0][0].ToString();
                        if(strError.Contains("EXISTS"))
                        {
                            throw new Exception(strError);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("EXISTS"))
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        throw new Exception("Diese LV Position existiert nicht für das ausgewählte Projekt.");
                    }
                    else
                    {
                        throw;
                    }
                }
                else
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        throw new Exception("Fehler beim Laden der Positionsliste");
                    }
                    else
                    {
                        throw new Exception("Error Occured While Retreiving Position OZ List");
                    }
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsPositionsOZList;
        }

        public DataSet GetPsoitionOZByWGWA(int ProjectID, string tType, string WG, string WA)
        {
            DataSet dsPositionsOZList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionOZ]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@Position_Type", tType);
                    cmd.Parameters.AddWithValue("@WG", WG);
                    cmd.Parameters.AddWithValue("@WA", WA);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositionsOZList, "Positions");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Positionsliste");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Position OZ List");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsPositionsOZList;
        }

        public DataSet UpdateBulkProcess_ActionA(int ProjectID, string tType, decimal MA_Selbstkosten, decimal MO_Selbstkosten, decimal MA_Verkaufspreis, decimal MO_Verkaufspreis, DataTable dt)
        {
            DataSet dsPositionsOZList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_BulkProcess_ActionA]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@Position_Type", tType);
                    cmd.Parameters.AddWithValue("@MA_selbstkostenMulti", MA_Selbstkosten);
                    cmd.Parameters.AddWithValue("@MO_selbstkostenMulti", MO_Selbstkosten);
                    cmd.Parameters.AddWithValue("@MA_verkaufspreis_Multi", MA_Verkaufspreis);
                    cmd.Parameters.AddWithValue("@MO_verkaufspreisMulti", MO_Verkaufspreis);
                    cmd.Parameters.AddWithValue("@Bulk_Process_ActionA_Table", dt);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositionsOZList, "Positions");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Positionsliste");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Position OZ List");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsPositionsOZList;
        }

        public DataSet UpdateBulkProcess_ActionB(int ProjectID, string tType, string Menge, string MA, string MO, string PeriesText, string Fabricat, string Typ, string LieferantMA, string wg, string wa, string wi, string tLVSection, DataTable dt)
        {
            DataSet dsPositionsOZList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_BulkProcess_ActionB]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@Position_Type", tType);
                    cmd.Parameters.AddWithValue("@Menge",Menge);
                    cmd.Parameters.AddWithValue("@MA", MA);
                    cmd.Parameters.AddWithValue("@MO", MO);
                    cmd.Parameters.AddWithValue("@PreisText", PeriesText);
                    cmd.Parameters.AddWithValue("@Fabricate", Fabricat);
                    cmd.Parameters.AddWithValue("@Type", Typ);
                    cmd.Parameters.AddWithValue("@LiefrantMA", LieferantMA);
                    cmd.Parameters.AddWithValue("@WG",wg);
                    cmd.Parameters.AddWithValue("@WA",wa);
                    cmd.Parameters.AddWithValue("@WI",wi);
                    cmd.Parameters.AddWithValue("@LVSection",tLVSection);
                    cmd.Parameters.AddWithValue("@Bulk_Process_ActionB_Table", dt);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositionsOZList, "Positions");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Positionsliste");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Position OZ List");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsPositionsOZList;
        }

        public void UpdateLongDescription(int PositionID,string strLongDescription)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_LongDescription]";
                    cmd.Parameters.AddWithValue("@PositionID", PositionID);
                    cmd.Parameters.AddWithValue("@LongDescription", strLongDescription);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeletePosition(int PositionID)
        {
            string strError = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Del_Position]";
                    cmd.Parameters.AddWithValue("@PositionID", PositionID);
                    object ObjReturn = cmd.ExecuteScalar();
                    if(!string.IsNullOrEmpty(Convert.ToString(ObjReturn)))
                    {
                        throw new Exception(Convert.ToString(ObjReturn));
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Positions"))
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Selected Position Is Having DetailKZ Positions");
                    else
                        throw new Exception("Selected Position Is Having DetailKZ Positions");
                }
                else
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Fehler beim Löschen der Positionen");
                    else
                        throw new Exception("Error while Deleting Position");
                }
            }
        }

        public EPosition GetArticleByTyp(EPosition ObjEPositon)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ArticleByType]";
                    cmd.Parameters.AddWithValue("@Typ", ObjEPositon.Type); 
                    cmd.Parameters.AddWithValue("@dtSubmitDate", ObjEPositon.ValidityDate);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ObjEPositon.WG = ds.Tables[0].Rows[0]["WG"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["WG"].ToString();
                        ObjEPositon.WA = ds.Tables[0].Rows[0]["WA"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["WA"].ToString();
                        ObjEPositon.WI = ds.Tables[0].Rows[0]["WI"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["WI"].ToString();
                        ObjEPositon.Fabricate = ds.Tables[0].Rows[0]["Fabrikate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Fabrikate"].ToString();
                        ObjEPositon.ME = ds.Tables[0].Rows[0]["Menegenheit"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Menegenheit"].ToString();
                        ObjEPositon.Faktor = ds.Tables[0].Rows[0]["Factor"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Factor"]);
                        ObjEPositon.LiefrantMA = ds.Tables[0].Rows[0]["FullName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["FullName"].ToString();
                        ObjEPositon.Multi1MA = ds.Tables[0].Rows[0]["Multi1"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi1"]);
                        ObjEPositon.Multi2MA = ds.Tables[0].Rows[0]["Multi2"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi2"]);
                        ObjEPositon.Multi3MA = ds.Tables[0].Rows[0]["Multi3"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi3"]);
                        ObjEPositon.Multi4MA = ds.Tables[0].Rows[0]["Multi4"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi4"]);
                        if (ds.Tables.Count > 1)
                            ObjEPositon.dtDimensions = ds.Tables[1];
                    }
                    else
                    {
                        ObjEPositon.dtDimensions = null;
                        ObjEPositon.WG = string.Empty;
                        ObjEPositon.WA = string.Empty;
                        ObjEPositon.WI = string.Empty;
                        ObjEPositon.Fabricate = string.Empty;
                        ObjEPositon.ME = string.Empty;
                        ObjEPositon.Faktor = 1;
                        ObjEPositon.LiefrantMA = string.Empty;
                        ObjEPositon.Multi1MA = 1;
                        ObjEPositon.Multi2MA = 1;
                        ObjEPositon.Multi3MA = 1;
                        ObjEPositon.Multi4MA = 1;
                        ObjEPositon.LPMA = 0;
                        ObjEPositon.Mins = 0;
                        ObjEPositon.Dim1 = "";
                        ObjEPositon.Dim2 = "";
                        ObjEPositon.Dim3 = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public EPosition GetArticleByWI(EPosition ObjEPositon)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ArticleByWG]";
                    cmd.Parameters.AddWithValue("@WG", ObjEPositon.WG);
                    cmd.Parameters.AddWithValue("@WA", ObjEPositon.WA);
                    cmd.Parameters.AddWithValue("@WI", ObjEPositon.WI);
                    cmd.Parameters.AddWithValue("@dtSubmitDate", ObjEPositon.ValidityDate);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    if (ds != null &&  ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ObjEPositon.Type = ds.Tables[0].Rows[0]["Typ"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Typ"].ToString();
                        ObjEPositon.Fabricate = ds.Tables[0].Rows[0]["Fabrikate"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Fabrikate"].ToString();
                        ObjEPositon.ME = ds.Tables[0].Rows[0]["Menegenheit"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Menegenheit"].ToString();
                        ObjEPositon.LiefrantMA = ds.Tables[0].Rows[0]["FullName"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["FullName"].ToString();
                        ObjEPositon.Multi1MA = ds.Tables[0].Rows[0]["Multi1"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi1"]);
                        ObjEPositon.Multi2MA = ds.Tables[0].Rows[0]["Multi2"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi2"]);
                        ObjEPositon.Multi3MA = ds.Tables[0].Rows[0]["Multi3"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi3"]);
                        ObjEPositon.Multi4MA = ds.Tables[0].Rows[0]["Multi4"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Multi4"]);
                        ObjEPositon.Faktor = ds.Tables[0].Rows[0]["Factor"] == DBNull.Value ? 1 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Factor"]);

                        if (ds.Tables.Count > 1)
                            ObjEPositon.dtDimensions = ds.Tables[1];
                    }
                    else
                    {
                        ObjEPositon.dtDimensions = null;
                        ObjEPositon.Type = string.Empty;
                        ObjEPositon.Fabricate = string.Empty;
                        ObjEPositon.ME = string.Empty;
                        ObjEPositon.Dim1 = string.Empty;
                        ObjEPositon.Dim2 = string.Empty;
                        ObjEPositon.Dim3 = string.Empty;
                        ObjEPositon.LPMA = 0;
                        ObjEPositon.Mins = 0;
                        ObjEPositon.Faktor = 1;
                        ObjEPositon.LiefrantMA = string.Empty;
                        ObjEPositon.Multi1MA = 1;
                        ObjEPositon.Multi2MA = 1;
                        ObjEPositon.Multi3MA = 1;
                        ObjEPositon.Multi4MA = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public EPosition GetArticleByDimension(EPosition ObjEPositon)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ArticleByDimension]";
                    cmd.Parameters.AddWithValue("@WG", ObjEPositon.WG);
                    cmd.Parameters.AddWithValue("@WA", ObjEPositon.WA);
                    cmd.Parameters.AddWithValue("@WI", ObjEPositon.WI);
                    cmd.Parameters.AddWithValue("@A", ObjEPositon.Dim1);
                    cmd.Parameters.AddWithValue("@B", ObjEPositon.Dim2);
                    cmd.Parameters.AddWithValue("@L", ObjEPositon.Dim3);
                    cmd.Parameters.AddWithValue("@dtSubmitDate", ObjEPositon.ValidityDate);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ObjEPositon.LPMA = dt.Rows[0]["ListPrice"] == DBNull.Value ? 1 : Convert.ToDecimal(dt.Rows[0]["ListPrice"]);
                        ObjEPositon.Mins = dt.Rows[0]["Minuten"] == DBNull.Value ? 1 : Convert.ToDecimal(dt.Rows[0]["Minuten"]);
                        ObjEPositon.Faktor = dt.Rows[0]["Factor"] == DBNull.Value ? 1 : Convert.ToDecimal(dt.Rows[0]["Factor"]);
                    }
                    else
                    {
                        ObjEPositon.LPMA = 0;
                        ObjEPositon.Mins = 0;
                        ObjEPositon.Faktor = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public DataSet GetOldPositionList(int ProjectID)
        {
            DataSet dsPositionsList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionList_Copy]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositionsList, "Positions");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    throw new Exception("Fehler beim Laden der Positionsliste");
                else
                    throw new Exception("Error Occured While Retreiving Position List");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsPositionsList;
        }
    }
}
    