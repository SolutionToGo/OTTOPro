﻿using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class BPosition
    {
        DPosition ObjDPosition = new DPosition();

        public int SavePositionDetails(EPosition ObjEPosition,string strRaster)
        {
            try
            {
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                int PositionID = -1;
                XmlDocument Xdoc = new XmlDocument();
                PrepareOZ(ObjEPosition, strRaster);
                string XPath = "/Nouns/Position";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PositionID", ObjEPosition.PositionID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ProjectID", ObjEPosition.ProjectID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PositionOZ", ObjEPosition.Position_OZ);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ParentOZ", ObjEPosition.Parent_OZ.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Title", ObjEPosition.Title);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ShortDescription", ObjEPosition.ShortDescription);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PositionKZ", ObjEPosition.PositionKZ);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DetailKZ", ObjEPosition.DetailKZ.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LVSection", ObjEPosition.LVSection);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WG", ObjEPosition.WG.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WA", ObjEPosition.WA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WI", ObjEPosition.WI.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Menge", ObjEPosition.Menge.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ME", ObjEPosition.ME.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Fabricate", ObjEPosition.Fabricate);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LiefrantMA", ObjEPosition.LiefrantMA);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Type", ObjEPosition.Type);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LVStatus", ObjEPosition.LVStatus);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ProposalNo", ObjEPosition.ProposalNo.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SurchargeFrom", string.IsNullOrEmpty(ObjEPosition.Surcharge_From) ? "" : 
                    ObjEPosition.Surcharge_From);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SurchargeTO", string.IsNullOrEmpty(ObjEPosition.Surcharge_To)? "" : 
                    ObjEPosition.Surcharge_To);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SurchargePer", Convert.ToString(ObjEPosition.Surcharge_Per));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "surchargePercentageMO", Convert.ToString(ObjEPosition.surchargePercentage_MO));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "UserID", ObjEPosition.UserID.ToString());

                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEPosition.ValidityDate.ToString("MM/dd/yyyy"));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "KalkMenge", ObjEPosition.KalkMenge.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "MECost", ObjEPosition.MECost.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "MA", ObjEPosition.MA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "MO", ObjEPosition.MO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dim1", ObjEPosition.Dim1);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dim2", ObjEPosition.Dim2);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dim3", ObjEPosition.Dim3);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Mins", ObjEPosition.Mins.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Faktor", ObjEPosition.Faktor.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LPMA", ObjEPosition.LPMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LPMO", ObjEPosition.LPMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1MA", ObjEPosition.Multi1MA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1MO", ObjEPosition.Multi1MO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2MA", ObjEPosition.Multi2MA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2MO", ObjEPosition.Multi2MO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3MA", ObjEPosition.Multi3MA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3MO", ObjEPosition.Multi3MO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4MA", ObjEPosition.Multi4MA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4MO", ObjEPosition.Multi4MO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi5MA", ObjEPosition.Multi5MA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi5MO", ObjEPosition.Multi5MO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EinkaufspreisMA", ObjEPosition.EinkaufspreisMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EinkaufspreisMO", ObjEPosition.EinkaufspreisMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenMultiMA", ObjEPosition.SelbstkostenMultiMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenMultiMO", ObjEPosition.SelbstkostenMultiMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenValueMA", ObjEPosition.SelbstkostenValueMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenValueMO", ObjEPosition.SelbstkostenValueMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisMultiMA", ObjEPosition.VerkaufspreisMultiMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisMultiMO", ObjEPosition.VerkaufspreisMultiMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisValueMA", ObjEPosition.VerkaufspreisValueMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisValueMO", ObjEPosition.VerkaufspreisValueMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "StdSatz", ObjEPosition.StdSatz.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PreisText", ObjEPosition.PreisText);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EinkaufspreisLockMA", ObjEPosition.EinkaufspreisLockMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EinkaufspreisLockMO", ObjEPosition.EinkaufspreisLockMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenLockMA", ObjEPosition.SelbstkostenLockMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenLockMO", ObjEPosition.SelbstkostenLockMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisLockMA", ObjEPosition.VerkaufspreisLockMA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisLockMO", ObjEPosition.VerkaufspreisLockMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DocuwareLink1", Convert.ToString(ObjEPosition.DocuwareLink1));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DocuwareLink2", Convert.ToString(ObjEPosition.DocuwareLink2));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DocuwareLink3", Convert.ToString(ObjEPosition.DocuwareLink3));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "GrandTotalME", ObjEPosition.GrandTotalME.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "GrandTotalMO", ObjEPosition.GrandTotalMO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FinalGB", ObjEPosition.FinalGB.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EP", ObjEPosition.EP.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SNO", ObjEPosition.SNO.ToString());

                PositionID = ObjDPosition.SavePositionDetails(Xdoc, ObjEPosition.LongDescription);
                if (PositionID < 0)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        throw new Exception("Fehler beim Speichern der LV Angaben");
                    }
                    else
                    {
                        throw new Exception("Failed to Save LV Details");
                    }
                }
                return PositionID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetPositionList(EPosition ObjEPosition,int ProjectID)
        {
            try
            {
                if (ObjEPosition != null)
                {
                    ObjEPosition.dsPositionList = ObjDPosition.GetPsoitionList(ProjectID);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetLongDescription(int PositionID)
        {
            string LongDescription = string.Empty;
            try
            {
                LongDescription = ObjDPosition.GetLongDescription(PositionID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return LongDescription;
        }

        public void PrepareOZ(EPosition ObjEPosition,string strLVRaster)
        {
            try
            {
                StringBuilder strParentOZ = new StringBuilder();
                StringBuilder strPositionOZ = new StringBuilder();
                if (ObjEPosition.PositionKZ.ToLower() != "h")
                {
                    //Checking stufe existence
                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe1)) //1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe1 + ".");
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe1 + ".");//1
                    }
                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe2))//1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe2 + ".");//1.1
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe2 + ".");//1.1
                        else
                        {
                            strParentOZ.Append(ObjEPosition.Stufe1 + ".");//1
                        }
                    }
                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe3))//1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe3 + ".");//1.1.1
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe3 + ".");//1.1.1
                        else
                        {
                            strParentOZ.Append(ObjEPosition.Stufe2 + ".");//1.1
                        }
                    }
                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe4))//1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe4 + ".");//1.1.1.1
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe4 + ".");//1.1.1.1
                        else
                        {
                            strParentOZ.Append(ObjEPosition.Stufe3 + ".");//1.1.1
                        }
                    }
                    if (!string.IsNullOrEmpty(ObjEPosition.Position))
                    {
                        if (ObjEPosition.Position.Contains('.'))
                            strPositionOZ.Append(ObjEPosition.Position);
                        else
                            strPositionOZ.Append(ObjEPosition.Position + ".");
                        ObjEPosition.Title = string.Empty;
                    }
                    //Assogning the final values to entities
                    ObjEPosition.Parent_OZ = strParentOZ.ToString();
                    ObjEPosition.Position_OZ = strPositionOZ.ToString();
                }
                else
                {
                    ObjEPosition.Position_OZ = "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while preparing OZ");
            }
        }

        public DataTable GetPositionKZ()
        {
            DataTable dt = null;
            try
            {
                dt = ObjDPosition.GetPositionKZ();
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public string GetNewLVSection(string strLVSelection, int ProjectID)
        {
            string strnewLVSection = string.Empty;
            try
            {
                strnewLVSection = ObjDPosition.GetLVSection(strLVSelection, ProjectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strnewLVSection;
        }

        public void InsertNewLVSection(string strNewLVSection, int ProjectID) 
        {
            try
            {
                ObjDPosition.InsertLVSection(strNewLVSection, ProjectID);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        public void GetPositionOZList(EPosition ObjEPosition, int ProjectID, string Position_Type,DataTable dt)
        {
            try
            {
                if (ObjEPosition != null)
                {
                    ObjEPosition.dsPositionOZList = ObjDPosition.GetPsoitionOZList(ProjectID, Position_Type,dt);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetPositionOZListByWGWA(EPosition ObjEPosition, int ProjectID, string Position_Type, double WG, int WA)
        {
            try
            {
                if (ObjEPosition != null)
                {
                    ObjEPosition.dsPositionOZList = ObjDPosition.GetPsoitionOZByWGWA(ProjectID, Position_Type, WG, WA);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateBulkProcess_ActionA(EPosition ObjEPosition, int ProjectID, string Position_Type, decimal MA_Selbstkosten, decimal MO_Selbstkosten, decimal MA_Verkaufspreis, decimal MO_Verkaufspreis, DataTable dt)
        {
            try
            {
                if (ObjEPosition != null)
                {
                    ObjEPosition.dsPositionOZList = ObjDPosition.UpdateBulkProcess_ActionA(ProjectID, Position_Type, MA_Selbstkosten, MO_Selbstkosten, MA_Verkaufspreis, MO_Verkaufspreis,dt);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateBulkProcess_ActionB(EPosition ObjEPosition, int ProjectID, string Position_Type, string Menge, string MA, string MO, string PeriesText, string Fabricat, string Typ, string LieferantMA, string wg, string wa, string wi, string tLVSection, DataTable dt)
        {
            try
            {
                if (ObjEPosition != null)
                {
                    ObjEPosition.dsPositionOZList = ObjDPosition.UpdateBulkProcess_ActionB(ProjectID, Position_Type, Menge, MA,MO,PeriesText,Fabricat, Typ, LieferantMA,wg,wa,wi,tLVSection, dt);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateLongDescription(int PositionID,string LongDescription)
        {
            try
            {
                ObjDPosition.UpdateLongDescription(PositionID, LongDescription);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Deleteposition(int PositionID)
        {
            try
            {
                ObjDPosition.DeletePosition(PositionID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
