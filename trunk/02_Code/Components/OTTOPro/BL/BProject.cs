using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BProject
    {
        /// <summary>
        /// Data Access Layer instance to perform the crud operations
        /// </summary>
        DProject ObjDAL = new DProject();

        /// <summary>
        /// Business Logic for Saving the project details
        /// </summary>
        /// <param name="ObjEObject"></param>
        /// <returns></returns>
        public void SaveProjectDetails(EProject ObjEObject)
        {
            int ProjectID = -1;
            try
            {
                if (ObjEObject != null)
                {
                    ProjectID = ObjDAL.SaveProjectDetails(ObjEObject);
                    if (ProjectID < 0)
                    {
                        if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        {
                            throw new Exception("Fehler beim Speichern der Projektangaben");
                        }
                        else
                        {
                            throw new Exception("Failed to Save the Project Details");
                        }
                    }
                    else
                        ObjEObject.ProjectID = ProjectID;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// /// Business Logic for retreiving the project list to show on load project screen
        /// </summary>
        /// <param name="ObjEObject"></param>
        public void GetProjectList(EProject ObjEObject)
        {
            try
            {
                if (ObjEObject != null)
                {
                    ObjEObject.dtProjectList = ObjDAL.GetProjectList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// /// Business Logic for retreiving the existing project details to show on project screen
        /// </summary>
        /// <param name="ObjEProject"></param>
        public void GetProjectDetails(EProject ObjEProject)
        {
            try
            {
                DataSet dsProjectDetails = ObjDAL.GetProjectDetails(ObjEProject);
                if (dsProjectDetails != null)
                {
                    if (dsProjectDetails.Tables.Count > 4)
                        ObjEProject.dtQuerCalc = dsProjectDetails.Tables[4];

                    if (dsProjectDetails.Tables.Count > 3)
                        ObjEProject.dtArticleSettings = dsProjectDetails.Tables[3];

                    if (dsProjectDetails.Tables.Count > 2)
                        ObjEProject.dtDiscount = dsProjectDetails.Tables[2];

                    if (dsProjectDetails.Tables.Count > 1)
                        ObjEProject.dtLVSection = dsProjectDetails.Tables[1];

                    if (dsProjectDetails.Tables.Count > 0)
                    {
                        DataTable dtPRojectDetails = dsProjectDetails.Tables[0];
                        if (dtPRojectDetails != null && dtPRojectDetails.Rows.Count > 0)
                        {
                            int iValue = 0;
                            decimal dValue = 0;
                            DateTime SubmitDate = DateTime.Now;
                            bool LockLV = false;

                            if (int.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["ProjectID"]), out iValue))
                                ObjEProject.ProjectID = iValue;
                            else
                                ObjEProject.ProjectID = -1;

                            ObjEProject.ProjectNumber = Convert.ToString(dtPRojectDetails.Rows[0]["ProjectNumber"]);
                            ObjEProject.ProjectName = Convert.ToString(dtPRojectDetails.Rows[0]["ProjectName"]);
                            ObjEProject.Location = Convert.ToString(dtPRojectDetails.Rows[0]["Location"]);
                            ObjEProject.CommissionNumber = Convert.ToString(dtPRojectDetails.Rows[0]["ComissionNumber"]);
                            ObjEProject.LVRaster = Convert.ToString(dtPRojectDetails.Rows[0]["LV_Raster"]);

                            if (int.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["LV_Sprung"]), out iValue))
                                ObjEProject.LVSprunge = iValue;

                            if (decimal.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Vat"]), out dValue))
                                ObjEProject.Vat = dValue;

                            ObjEProject.ProjectDescription = Convert.ToString(dtPRojectDetails.Rows[0]["ProjectDescription"]);
                            ObjEProject.KundeID = 1;
                            if (int.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["CustomerID"]), out iValue))
                                ObjEProject.KundeNr = iValue;
                            ObjEProject.KundeName = Convert.ToString(dtPRojectDetails.Rows[0]["CustomerName"]);
                            ObjEProject.KundeAddress = Convert.ToString(dtPRojectDetails.Rows[0]["Street"]);
                            ObjEProject.PlannedID = 1;
                            ObjEProject.PlannerName = Convert.ToString(dtPRojectDetails.Rows[0]["PlannerName"]);

                            if (int.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Planned_Duration"]), out iValue))
                                ObjEProject.ProjectDuration = iValue;

                            if (decimal.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Intern_X"]), out dValue))
                                ObjEProject.InternX = dValue;

                            if (decimal.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Intern_S"]), out dValue))
                                ObjEProject.InternS = dValue;

                            ObjEProject.Submitlocation = Convert.ToString(dtPRojectDetails.Rows[0]["Submit_Location"]);

                            if (DateTime.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Submit_Date"]), out SubmitDate))
                            {
                                ObjEProject.SubmitTime = SubmitDate;
                                ObjEProject.SubmitDate = SubmitDate;
                            }
                            else
                            {
                                ObjEProject.SubmitTime = SubmitDate;
                                ObjEProject.SubmitDate = SubmitDate;
                            }

                            if (int.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Estimated_LV"]), out iValue))
                                ObjEProject.EstimatedLvs = iValue;

                            if (int.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Actual_LV"]), out iValue))
                                ObjEProject.ActualLvs = iValue;

                            ObjEProject.RoundingPriceID = 1;
                            ObjEProject.Remarks = Convert.ToString(dtPRojectDetails.Rows[0]["Remarks"]);

                            if (bool.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Lock_LVHierarchy"]), out LockLV))
                                ObjEProject.LockHierarchy = LockLV;

                            if (int.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["Round_Off"]), out iValue))
                                ObjEProject.RoundingPrice = iValue;

                            if (DateTime.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["ProjectStartDate"]), out SubmitDate))
                                ObjEProject.ProjectStartDate = SubmitDate;
                            else
                                ObjEProject.ProjectStartDate = SubmitDate;

                            if (DateTime.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["ProjectEndDate"]), out SubmitDate))
                                ObjEProject.ProjectEndDate = SubmitDate;
                            else
                                ObjEProject.ProjectEndDate = SubmitDate;

                            if (bool.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["IsDisable"]), out LockLV))
                                ObjEProject.IsDisable = LockLV;

                            if (bool.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["IsCumulated"]), out LockLV))
                                ObjEProject.IsCumulated = LockLV;

                            if (bool.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["FinalInvoice"]), out LockLV))
                                ObjEProject.IsFinalInvoice = LockLV;

                            if (bool.TryParse(Convert.ToString(dtPRojectDetails.Rows[0]["ShowVK"]), out LockLV))
                                ObjEProject.ShowVK = LockLV;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden des Projektes");
                }
                else
                {
                    throw new Exception("Error Occured While Loading the Project");

                }
            }
        }

        //Copy of LVs
        public EProject GetProjectNumber(EProject ObjEProject)
        {
            try
            {
                if (ObjEProject != null)
                {
                    ObjEProject = ObjDAL.GetProjectNumber(ObjEProject);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public EProject UpdateStatus(EProject ObjEProject)
        {
            try
            {
                if (ObjEProject != null)
                {
                    ObjEProject = ObjDAL.UpdateStatus(ObjEProject);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public EProject GetComparePrice(EProject ObjEProject, string _wg, string _wa, string _wi, string _a, string _b, string _l,string _typ, string _Type, int _PosID)
        {
            try
            {
                if (ObjEProject != null)
                {
                    ObjEProject = ObjDAL.GetComparePrice(ObjEProject, _wg, _wa,_wi,_a,_b,_l,_typ, _Type,_PosID);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public EProject SaveDiscount(EProject ObjEProject)
        {
            try
            {
                if (ObjDAL == null)
                    ObjDAL = new DProject();
                ObjEProject = ObjDAL.SaveDiscount(ObjEProject);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public EProject DeleteDiscount(EProject ObjEProject)
        {
            try
            {
                ObjEProject = ObjDAL.DeleteDiscount(ObjEProject);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public void SavePath(string strPath,string TemplatePath)
        {
            try
            {
                if (ObjDAL == null)
                    ObjDAL = new DProject();
                ObjDAL.SavePath(strPath, TemplatePath);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EProject GetPath(EProject ObjEProject)
        {
            try
            {
                ObjEProject = ObjDAL.GetPath(ObjEProject);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public string GetDBVersion()
        {
            string strVersion = string.Empty;
            try
            {
                if(ObjDAL == null)
                    ObjDAL = new DProject();
                strVersion = ObjDAL.GetDBVersion();
            }
            catch (Exception ex)
            {
                throw;
            }
            return strVersion;
        }

        public void DeleteProject(int ProjectID)
        {
            try
            {
                if (ObjDAL == null)
                    ObjDAL = new DProject();
                ObjDAL.DeleteProject(ProjectID);
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
                if (ObjDAL == null)
                    ObjDAL = new DProject();
                ObjEProject = ObjDAL.CopyProject(ObjEProject);
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
                ObjEProject = ObjDAL.GetCockpitData(ObjEProject);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEProject;
        }

        public string InssertCockpitData(EProject ObjEProject)
        {
            string str = string.Empty;
            try
            {
                str = ObjDAL.InssertCockpitData(ObjEProject);
            }
            catch (Exception ex)
            {
                throw;
            }
            return str;
        }

        public void SaveProjectCommentary(int ProjectID, string CommentaryDescription)
        {
            try
            {
                ObjDAL.SaveProjectCommentary(ProjectID, CommentaryDescription);
            }
            catch (Exception ex){throw ex;}
        }

        public string GetProjectCommentary(int ProjectID)
        {
            string st = string.Empty;
            try
            {
                st = ObjDAL.GetProjectCommentary(ProjectID);
            }
            catch (Exception ex) { throw ex; }
            return st;
        }

        public void SaveAngebotCommentary(int ProjectID, string CommentaryDescription)
        {
            try
            {
                ObjDAL.SaveAngebotCommentary(ProjectID, CommentaryDescription);
            }
            catch (Exception ex) { throw ex; }
        }

        public string GetAngebotCommentary(int ProjectID)
        {
            string st = string.Empty;
            try
            {
                st = ObjDAL.GetAngebotCommentary(ProjectID);
            }
            catch (Exception ex) { throw ex; }
            return st;
        }
    }
}
    
