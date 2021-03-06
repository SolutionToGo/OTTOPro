﻿using EL;
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
                    cmd.Parameters.AddWithValue("@CustomerID", ObjEProject.KundeID);
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
                    cmd.Parameters.AddWithValue("@CustomerNumber", ObjEProject.KundeNr);
                    cmd.Parameters.AddWithValue("@PlannerName", ObjEProject.PlannerName);
                    cmd.Parameters.AddWithValue("@ProjectStartDate", ObjEProject.ProjectStartDate);
                    cmd.Parameters.AddWithValue("@ProjectEndDate", ObjEProject.ProjectEndDate);
                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (!int.TryParse(returnObj.ToString(), out ProjectID))
                            throw new Exception("Error Occured While Saving the Project Details");
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
                throw new Exception("Error Occured While Retreiving ProjectList");
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
        public DataTable GetProjectDetails(EProject ObjEProject)
        {
            DataTable dtProjectList = new DataTable();
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
                        da.Fill(dtProjectList);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured While Retreiving ProjectList");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dtProjectList;
        }
    }
}
