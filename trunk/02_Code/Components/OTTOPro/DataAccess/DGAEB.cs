using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class DGAEB
    {
        public DataSet Export(int ProjectID, string _Raster)
        {
            DataSet dsTMLData = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_TMLFile]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@LVRaster", _Raster);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsTMLData, "TMLData");
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
            return dsTMLData;
        }

        public DataSet GetPositionsDataForTML(int ProjectID, string strLVSection, string _Raster)
        {
            DataSet dsTMLData = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionForTML]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@LVSection", strLVSection);
                    cmd.Parameters.AddWithValue("@LVRaster", _Raster);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsTMLData, "TMLData");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("RasterError"))
                    throw new Exception("Operation not possible with Old Raster");
                else
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Fehler beim Laden der Positionsliste");
                    else
                        throw new Exception("Error Occured While Retreiving Position List");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsTMLData;
        }

        public int Import(int ProjectID,DataSet dsTMLData,string strRaster)
        {
            int iValue = 0;
            try
            {
                if(dsTMLData != null && dsTMLData.Tables.Count > 0)
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Import]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    cmd.Parameters.AddWithValue("@dtImport", dsTMLData.Tables[dsTMLData.Tables.Count - 1]);
                    cmd.Parameters.AddWithValue("@Raster", strRaster);
                    object ObjReturn = cmd.ExecuteScalar();
                    if (ObjReturn != null)
                    {
                        if (!int.TryParse(ObjReturn.ToString(), out iValue))
                        {
                            //throw new Exception(ObjReturn.ToString());
                            if (ObjReturn.ToString().Contains("raster"))
                            {
                                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                    throw new Exception("Das ausgewählte Datei-Raster ist mit dem ausgewählten Projekt-Raster nicht kompatibel.");
                                else
                                    throw new Exception("Selected file raster is incompatible with selected project raster.");
                            }
                            if (ObjReturn.ToString().Contains("already"))
                            {
                                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                    throw new Exception("Die Position ist bereits im ausgewählten Projekt vorhanden!.");
                                else
                                    throw new Exception("Position is already exists under selected project.");
                            }
                            if (ObjReturn.ToString().Contains("titles"))
                            {
                                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                    throw new Exception("Die Position ist bereits im ausgewählten Projekt vorhanden!.");
                                else
                                    throw new Exception("Selected positions titles are not matching");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return iValue;
        }

        public DataTable Get_LVRaster()
        {
            DataTable dtRaster = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_LVRaster]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dtRaster);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Rasters");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Rasters");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dtRaster;
        }

        public DataTable GetLVSection(int ProjectID)
        {
            DataTable dtLVSecton = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_LVSectionForImport]";
                    cmd.Parameters.Add("@ProjectID", ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dtLVSecton);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Sections");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving LV Sections");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dtLVSecton;
        }

        public string GetOld_LVRaster(int _ProjectID)
        {
            string Old_Raster = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_Old_LVRaster]";
                    cmd.Parameters.AddWithValue("@ProjectID", _ProjectID);
                    object _objreturn = cmd.ExecuteScalar();
                    Old_Raster = Convert.ToString(_objreturn);
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Rasters");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Rasters");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return Old_Raster;
        }
    }
}
