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
        public int SavePositionDetails(XmlDocument XmlDoc,string LongDescription)
        {
            int ProjectID = -1;
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Position]";
                    SqlParameter param = new SqlParameter("@XMLPositions", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);
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
                throw (ex);
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
                    cmd.Parameters.AddWithValue("@WG", 0);
                    cmd.Parameters.AddWithValue("@WA", 0);
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
                        throw ex;
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

        public DataSet GetPsoitionOZByWGWA(int ProjectID, string tType, double WG, int WA)
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
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Del_Position]";
                    cmd.Parameters.AddWithValue("@PositionID", PositionID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Löschen der Positionen");
                }
                else
                {
                    throw new Exception("Error while Deleting Position");
                }
            }
        }
    }
}
