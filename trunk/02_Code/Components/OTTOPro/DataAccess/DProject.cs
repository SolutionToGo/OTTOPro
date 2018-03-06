using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DProject
    {
        
        /// <summary>
        /// Code to save the project details into database
        /// </summary>
        /// <param name="ObjEProject"></param>
        /// <returns></returns>
        public int SaveProjectDetails(EProject ObjEProject)
        {
            int ProjectID = -1;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "P_Ins_Project";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEProject.ProjectID);
                    cmd.Parameters.AddWithValue("@Location", ObjEProject.Location);
                    cmd.Parameters.AddWithValue("@ProjectNumber", ObjEProject.ProjectNumber);
                    cmd.Parameters.AddWithValue("@ComissionNumber", ObjEProject.CommissionNumber);
                    cmd.Parameters.AddWithValue("@CustomerID", ObjEProject.KundeNr);
                    cmd.Parameters.AddWithValue("@ProjectDescription", ObjEProject.ProjectDescription);
                    cmd.Parameters.AddWithValue("@PlannerID", ObjEProject.PlannedID);
                    cmd.Parameters.AddWithValue("@LV_Raster", ObjEProject.LVRaster);
                    cmd.Parameters.AddWithValue("@LV_Raster_GAEB", ObjEProject.LVRaster_GAEB);
                    cmd.Parameters.AddWithValue("@LV_Sprung", ObjEProject.LVSprunge);
                    cmd.Parameters.AddWithValue("@Intern_X", ObjEProject.InternX);
                    cmd.Parameters.AddWithValue("@Intern_S", ObjEProject.InternS);
                    cmd.Parameters.AddWithValue("@Vat", ObjEProject.Vat);
                    cmd.Parameters.AddWithValue("@Submit_Location", ObjEProject.Submitlocation);
                    cmd.Parameters.AddWithValue("@Submit_Date", ObjEProject.SubmitDate);
                    cmd.Parameters.AddWithValue("@Submit_Time", ObjEProject.SubmitTime);
                    cmd.Parameters.AddWithValue("@Estimated_LV", ObjEProject.EstimatedLvs);
                    cmd.Parameters.AddWithValue("@Round_Off", ObjEProject.RoundingPrice);
                    cmd.Parameters.AddWithValue("@Remarks", ObjEProject.Remarks);
                    cmd.Parameters.AddWithValue("@Project_Discount", ObjEProject.Discount);
                    cmd.Parameters.AddWithValue("@Lock_LVHierarchy", ObjEProject.LockHierarchy);
                    cmd.Parameters.AddWithValue("@UserID", ObjEProject.UserID);
                    cmd.Parameters.AddWithValue("@CustomerName", ObjEProject.KundeName);
                    cmd.Parameters.AddWithValue("@PlannerName", ObjEProject.PlannerName);
                    cmd.Parameters.AddWithValue("@ProjectStartDate", ObjEProject.ProjectStartDate);
                    cmd.Parameters.AddWithValue("@ProjectEndDate", ObjEProject.ProjectEndDate);
                    cmd.Parameters.AddWithValue("@IsCummulated", ObjEProject.IsCumulated);
                    cmd.Parameters.AddWithValue("@ISRasterChange", ObjEProject.IsRasterChange);
                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (returnObj.ToString().Contains("ProjectNumber"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                throw new Exception("Diese Projektnummer existiert bereits");
                            else
                                throw new Exception("Project Nr Already Exists");
                        }
                        else if (returnObj.ToString().Contains("ComissionNumber"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                throw new Exception("Die eingegebene Kommissions-Nummer existiert bereits");
                            else
                                throw new Exception("ComissionNumber Already Exists");
                        }
                        else if (returnObj.ToString().Contains("RasterError"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                throw new Exception("Diese Funktion ist nicht möglich mit dem alten Raster");
                            else
                                throw new Exception("Operation not Possible with Old Raster");
                        }
                        else if (!int.TryParse(returnObj.ToString(), out ProjectID))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                throw new Exception("Fehler beim Speichern der Projektangaben");
                            else
                                throw new Exception("Error Occured While Saving the Project Details");
                        }
                    }
                    ObjEProject.IsRasterChange = false;
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

        /// <summary>
        /// Code to retreive the project list to populate on load project screen
        /// </summary>
        /// <returns></returns>
        public DataTable GetProjectList()
        {
            DataTable dtProjectList = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "P_Get_ProjectList";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dtProjectList);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Projektliste");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving ProjectList");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dtProjectList;
        }

        /// <summary>
        /// Code to retreive the existing project details to show on project screen
        /// </summary>
        /// <param name="ObjEProject"></param>
        /// <returns></returns>
        public DataSet GetProjectDetails(EProject ObjEProject)
        {
            DataSet dsProjectList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEProject.ProjectID);
                    cmd.CommandText = "[P_Get_ProjectDetails]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsProjectList, "ProjectDetails");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der generiert werden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving ProjectList");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsProjectList;
        }


        //Copy of LVs
        public EProject GetProjectNumber(EProject ObjEProject)
        {
            DataSet dsProjectNo = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ProjectNumber]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsProjectNo);
                    }
                    if (dsProjectNo != null && dsProjectNo.Tables.Count > 0)
                    {
                        ObjEProject.dtProjecNumber = dsProjectNo.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der generiert werden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Projects");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEProject;
        }

        public EProject UpdateStatus(EProject ObjEProject)
        {
            DataSet dsProjectNo = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_ProjectStatus]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEProject.ProjectID);
                    cmd.Parameters.AddWithValue("@Status", ObjEProject.Status);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsProjectNo);
                    }                    
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Speichern des Projektstatus");
                }
                else
                {
                    throw new Exception("Error Occured While Saving the Project status");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEProject;
        }

        public EProject GetComparePrice(EProject ObjEProject, string _wg, string _wa, string _wi, string _a, string _b, string _l, string _typ, string _Type, int _PosID)
        {
            DataSet dsComnparePrice = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_ComparePrice]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEProject.ProjectID);
                    cmd.Parameters.AddWithValue("@CustomerID", ObjEProject.KundeNr);
                    cmd.Parameters.AddWithValue("@WG", _wg);
                    cmd.Parameters.AddWithValue("@WA", _wa);
                    cmd.Parameters.AddWithValue("@WI", _wi);
                    cmd.Parameters.AddWithValue("@A", _a);
                    cmd.Parameters.AddWithValue("@B", _b);
                    cmd.Parameters.AddWithValue("@L", _l);
                    cmd.Parameters.AddWithValue("@TYP", _typ);
                    cmd.Parameters.AddWithValue("@TYPE", _Type);
                    cmd.Parameters.AddWithValue("@PositionID", _PosID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsComnparePrice);
                    }
                    if (dsComnparePrice.Tables.Count > 0)
                    {
                        ObjEProject.dsComaparePrice = dsComnparePrice;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der generiert werden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Projects");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEProject;
        }

        public EProject SaveDiscount(EProject ObjEProject)
        {
            DataSet dsDiscount = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Discount]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEProject.ProjectID);
                    cmd.Parameters.AddWithValue("@FromOZ", ObjEProject.FromOZ);
                    cmd.Parameters.AddWithValue("@ToOZ", ObjEProject.ToOZ);
                    cmd.Parameters.AddWithValue("@Discount", ObjEProject.Discount);
                    cmd.Parameters.AddWithValue("@UserID", ObjEProject.UserID);
                    cmd.Parameters.AddWithValue("@DiscountPosID", ObjEProject.DiscountPosID);
                    cmd.Parameters.AddWithValue("@dtDiscountList", ObjEProject.dtDiscountList);
                    cmd.Parameters.AddWithValue("@ShortDescription", ObjEProject.ShortDescription);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsDiscount);
                    }
                    if(dsDiscount != null && dsDiscount.Tables.Count > 0)
                    {
                        int IValue = 0;
                        string str = Convert.ToString(dsDiscount.Tables[0].Rows[0][0]);
                        if(int.TryParse(str,out IValue))
                        {
                            ObjEProject.DiscountID = IValue;
                            if (dsDiscount.Tables.Count > 1)
                                ObjEProject.dtDiscount = dsDiscount.Tables[1];
                        }
                        else
                            throw new Exception(str);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("already"))
                    throw new Exception(ex.Message);
                else
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Fehler beim Speichern des Nachlasses");
                    else
                        throw new Exception("Error Occured While Saving Discount");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEProject;
        }

        public EProject DeleteDiscount(EProject ObjEProject)
        {
            DataSet dsDiscount = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Del_Discunt]";
                    cmd.Parameters.AddWithValue("@DiscountID", ObjEProject.DiscountID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsDiscount);
                    }
                    if (dsDiscount != null && dsDiscount.Tables.Count > 0)
                        ObjEProject.dtDiscount = dsDiscount.Tables[0];
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    throw new Exception("Fehler beim Löschen des Nachlasses");
                else
                    throw new Exception("Error Occured While Deleting Discount");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEProject;
        }

        public void SavePath(string strPath)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Path]";
                    cmd.Parameters.AddWithValue("@Path", strPath);
                    cmd.ExecuteNonQuery();
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
        }

        public string GetPath()
        {
            string strPath = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_Path]";
                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                        strPath = Convert.ToString(returnObj);
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
            return strPath;
        }

        public string GetDBVersion()
        {
            string strVersion = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[p_Get_DBVersion]";
                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                        strVersion = Convert.ToString(returnObj);
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
            return strVersion;
        }

        public void DeleteProject(int ProjectID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Del_Project]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    object returnObj = cmd.ExecuteScalar();
                    string strReturn = Convert.ToString(returnObj);
                    if (!string.IsNullOrEmpty(strReturn))
                        throw new Exception("Fehler beim Löschen des Projektes");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EProject CopyProject(EProject ObjEProject)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_CopyProject]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEProject.ProjectID);
                    cmd.Parameters.AddWithValue("@ProjectNumber", ObjEProject.ProjectNumber);
                    cmd.Parameters.AddWithValue("@UserId", ObjEProject.UserID);
                    object returnObj = cmd.ExecuteScalar();
                    string strReturn = Convert.ToString(returnObj);
                    int Ivalue = 0;
                    if (int.TryParse(strReturn, out Ivalue))
                        ObjEProject.ProjectID = Ivalue;
                    else
                    {
                        if (returnObj.ToString().Contains("ProjectNumber"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                throw new Exception("Diese Projektnummer existiert bereits");
                            else
                                throw new Exception("Project Nr Already Exists");
                        }
                        else
                            throw new Exception("Fehler beim Kopieren des Projektes");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public EProject GetCockpitData(EProject ObjEProject)
        {
            try
            {
                ObjEProject.dtCockpitData = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_CockpitData]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEProject.ProjectID);
                    cmd.Parameters.AddWithValue("@dtCockpitData", ObjEProject.dtTemplateData);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ObjEProject.dtCockpitData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public string InssertCockpitData(EProject ObjEProject)
        {
            string strError = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.CockpitConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_InsertOTTOProData]";
                    cmd.Parameters.Add("@dtData", ObjEProject.dtCockpitData);
                    cmd.Parameters.Add("@ProjectNumber", ObjEProject.ProjectNumber);
                    cmd.Parameters.Add("@ProjectDescription", ObjEProject.ProjectDescription);
                    cmd.Parameters.Add("@ProjectStartDate", ObjEProject.ProjectStartDate);
                    cmd.Parameters.Add("@ProjectEndDate", ObjEProject.ProjectEndDate);
                    cmd.Parameters.Add("@UserName", ObjEProject.UserName);
                    object returnObj = cmd.ExecuteScalar();
                    strError = Convert.ToString(returnObj);
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
            return strError;
        }
    }
}
