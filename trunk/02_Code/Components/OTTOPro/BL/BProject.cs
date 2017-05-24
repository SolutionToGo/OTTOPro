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
                throw;
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
                    if (dsProjectDetails.Tables.Count > 1)
                        ObjEProject.dtLVSection = ObjDAL.GetProjectDetails(ObjEProject).Tables[1];
                    if (dsProjectDetails.Tables.Count > 0)
                    {
                        DataTable dtPRojectDetails = ObjDAL.GetProjectDetails(ObjEProject).Tables[0];
                        if (dtPRojectDetails != null && dtPRojectDetails.Rows.Count > 0)
                        {
                            int iValue = 0;
                            decimal dValue = 0;
                            DateTime SubmitDate = DateTime.Now;
                            bool LockLV = false;

                            if (int.TryParse(dtPRojectDetails.Rows[0]["ProjectID"].ToString(), out iValue))
                                ObjEProject.ProjectID = iValue;
                            else
                                ObjEProject.ProjectID = -1;

                            ObjEProject.ProjectNumber = dtPRojectDetails.Rows[0]["ProjectNumber"].ToString();
                            ObjEProject.Location = dtPRojectDetails.Rows[0]["Location"].ToString();
                            ObjEProject.CommissionNumber = dtPRojectDetails.Rows[0]["ComissionNumber"].ToString();
                            ObjEProject.LVRaster = dtPRojectDetails.Rows[0]["LV_Raster"].ToString();

                            if (int.TryParse(dtPRojectDetails.Rows[0]["LV_Sprung"].ToString(), out iValue))
                                ObjEProject.LVSprunge = iValue;

                            if (decimal.TryParse(dtPRojectDetails.Rows[0]["Vat"].ToString(), out dValue))
                                ObjEProject.Vat = dValue;

                            ObjEProject.ProjectDescription = dtPRojectDetails.Rows[0]["ProjectDescription"].ToString();
                            ObjEProject.KundeID = 1;
                            ObjEProject.KundeNr = dtPRojectDetails.Rows[0]["CustomerID"].ToString();
                            ObjEProject.KundeName = dtPRojectDetails.Rows[0]["CustomerName"].ToString();
                            ObjEProject.PlannedID = 1;
                            ObjEProject.PlannerName = dtPRojectDetails.Rows[0]["PlannerName"].ToString();

                            if (int.TryParse(dtPRojectDetails.Rows[0]["Planned_Duration"].ToString(), out iValue))
                                ObjEProject.ProjectDuration = iValue;

                            if (decimal.TryParse(dtPRojectDetails.Rows[0]["Intern_X"].ToString(), out dValue))
                                ObjEProject.InternX = dValue;

                            if (decimal.TryParse(dtPRojectDetails.Rows[0]["Intern_S"].ToString(), out dValue))
                                ObjEProject.InternS = dValue;

                            ObjEProject.Submitlocation = dtPRojectDetails.Rows[0]["Submit_Location"].ToString();

                            if (DateTime.TryParse(dtPRojectDetails.Rows[0]["Submit_Date"].ToString(), out SubmitDate))
                            {
                                ObjEProject.SubmitTime = SubmitDate;
                                ObjEProject.SubmitDate = SubmitDate;
                            }
                            else
                            {
                                ObjEProject.SubmitTime = SubmitDate;
                                ObjEProject.SubmitDate = SubmitDate;
                            }

                            if (int.TryParse(dtPRojectDetails.Rows[0]["Estimated_LV"].ToString(), out iValue))
                                ObjEProject.EstimatedLvs = iValue;

                            if (int.TryParse(dtPRojectDetails.Rows[0]["Actual_LV"].ToString(), out iValue))
                                ObjEProject.ActualLvs = iValue;

                            ObjEProject.RoundingPriceID = 1;
                            ObjEProject.Remarks = dtPRojectDetails.Rows[0]["Remarks"].ToString();

                            if (bool.TryParse(dtPRojectDetails.Rows[0]["Lock_LVHierarchy"].ToString(), out LockLV))
                                ObjEProject.LockHierarchy = LockLV;

                            if (int.TryParse(dtPRojectDetails.Rows[0]["Round_Off"].ToString(), out iValue))
                                ObjEProject.RoundingPrice = iValue;

                            if (DateTime.TryParse(dtPRojectDetails.Rows[0]["ProjectStartDate"].ToString(), out SubmitDate))
                                ObjEProject.ProjectStartDate = SubmitDate;
                            else
                                ObjEProject.ProjectStartDate = SubmitDate;

                            if (DateTime.TryParse(dtPRojectDetails.Rows[0]["ProjectEndDate"].ToString(), out SubmitDate))
                                ObjEProject.ProjectEndDate = SubmitDate;
                            else
                                ObjEProject.ProjectEndDate = SubmitDate;

                            if (bool.TryParse(dtPRojectDetails.Rows[0]["IsDisable"].ToString(), out LockLV))
                                ObjEProject.IsDisable = LockLV;

                            if (bool.TryParse(dtPRojectDetails.Rows[0]["IsCumulated"].ToString(), out LockLV))
                                ObjEProject.IsCumulated = LockLV;
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

    }
}
    
