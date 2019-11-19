using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class BPosition
    {
        DPosition ObjDPosition = new DPosition();

        public int SavePositionDetails(EPosition ObjEPosition,string strRaster, int LVSprunge,bool _IsCopy = false)
        {
            try
            {
                CultureInfo CInfo = new CultureInfo("en-US");
                int PositionID = -1;
                XmlDocument Xdoc = new XmlDocument();
                if (!_IsCopy)
                    PrepareOZ(ObjEPosition, strRaster);
                string XPath = "/Nouns/Position";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PositionID", Convert.ToString(ObjEPosition.PositionID));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ProjectID", Convert.ToString(ObjEPosition.ProjectID));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PositionOZ", PrepareOZ(ObjEPosition.Position_OZ, strRaster));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ParentOZ", ObjEPosition.Parent_OZ);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Title", ObjEPosition.Title);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ShortDescription", ObjEPosition.ShortDescription);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PositionKZ", ObjEPosition.PositionKZ);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DetailKZ", ObjEPosition.DetailKZ.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LVSection", ObjEPosition.LVSection);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WG", ObjEPosition.WG.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WA", ObjEPosition.WA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WI", ObjEPosition.WI.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Menge", ObjEPosition.Menge.ToString(CInfo));
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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SurchargePer", ObjEPosition.Surcharge_Per.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "surchargePercentageMO", ObjEPosition.surchargePercentage_MO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "UserID", ObjEPosition.UserID.ToString());

                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEPosition.ValidityDate.ToString("yyyy-MM-dd"));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "KalkMenge", ObjEPosition.KalkMenge.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "MECost", ObjEPosition.MECost.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "MA", ObjEPosition.MA.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "MO", ObjEPosition.MO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dim1", ObjEPosition.Dim1);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dim2", ObjEPosition.Dim2);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dim3", ObjEPosition.Dim3);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dim", ObjEPosition.Dim);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Mins", ObjEPosition.Mins.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Faktor", ObjEPosition.Faktor.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LPMA", ObjEPosition.LPMA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LPMO", ObjEPosition.LPMO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1MA", ObjEPosition.Multi1MA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1MO", ObjEPosition.Multi1MO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2MA", ObjEPosition.Multi2MA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2MO", ObjEPosition.Multi2MO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3MA", ObjEPosition.Multi3MA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3MO", ObjEPosition.Multi3MO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4MA", ObjEPosition.Multi4MA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4MO", ObjEPosition.Multi4MO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi5MA", ObjEPosition.Multi5MA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi5MO", ObjEPosition.Multi5MO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EinkaufspreisMA", ObjEPosition.EinkaufspreisMA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EinkaufspreisMO", ObjEPosition.EinkaufspreisMO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenMultiMA", ObjEPosition.SelbstkostenMultiMA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenMultiMO", ObjEPosition.SelbstkostenMultiMO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenValueMA", ObjEPosition.SelbstkostenValueMA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SelbstkostenValueMO", ObjEPosition.SelbstkostenValueMO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisMultiMA", ObjEPosition.VerkaufspreisMultiMA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisMultiMO", ObjEPosition.VerkaufspreisMultiMO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisValueMA", ObjEPosition.VerkaufspreisValueMA.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "VerkaufspreisValueMO", ObjEPosition.VerkaufspreisValueMO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "StdSatz", ObjEPosition.StdSatz.ToString(CInfo));
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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "GrandTotalME", ObjEPosition.GrandTotalME.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "GrandTotalMO", ObjEPosition.GrandTotalMO.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FinalGB", ObjEPosition.FinalGB.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EP", ObjEPosition.EP.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SNO", ObjEPosition.SNO.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Discount", ObjEPosition.Discount.ToString(CInfo));

                double OZID = 0;
                string stOZChar = "";
                string OZ1 = string.Empty, OZ2 = string.Empty, OZ3 = string.Empty, OZ4 = string.Empty, OZ5 = string.Empty, OZ6 = string.Empty;
                if (!string.IsNullOrEmpty(ObjEPosition.Position_OZ))
                {
                    string[] strOZList = PrepareOZ(ObjEPosition.Position_OZ, strRaster).Split('.');
                    if (strOZList.Count() > 1)
                    {
                        string strOZID = strOZList[strOZList.Count() - 2];
                        string strIndex = strOZList[strOZList.Count() - 1];
                        if (!double.TryParse(strOZID + "." + strIndex, NumberStyles.Float, CultureInfo.GetCultureInfo("en"), out OZID))
                            OZID = 0;
                        char [] OZcharList = strOZID.ToCharArray();
                        int CharCount = OZcharList.Count();
                        if (CharCount > 0)
                        {
                            OZ1 = Convert.ToString(OZcharList[0]);
                            if (CharCount > 1)
                            {
                                OZ2 = Convert.ToString(OZcharList[1]);
                                if (CharCount > 2)
                                {
                                    OZ3 = Convert.ToString(OZcharList[2]);
                                    if (CharCount > 3)
                                    {
                                        OZ4 = Convert.ToString(OZcharList[3]);
                                        if (CharCount > 4)
                                        {
                                            OZ5 = Convert.ToString(OZcharList[4]);
                                            OZ6 = strIndex;
                                        }
                                        else
                                            OZ5 = strIndex;
                                    }
                                    else
                                        OZ4 = strIndex;
                                }
                                else
                                    OZ3 = strIndex;
                            }
                            else
                                OZ2 = strIndex;
                        }
                    }
                }
                PositionID = ObjDPosition.SavePositionDetails(Xdoc,ObjEPosition.ProjectID, ObjEPosition.LongDescription, 
                    OZID, OZ1, OZ2, OZ3, OZ4, OZ5, OZ6, stOZChar,ObjEPosition.MontageEntry);
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
                if (ObjEPosition.PositionKZ.ToLower() != "h" && ObjEPosition.PositionKZ.ToLower() != "vr")
                {
                    //Checking stufe existence
                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe1)) //1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe1 + "."); 
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe1 + ".");//1
                    }

                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe2.Trim()))//1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe2 + ".");//1.1
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe2 + ".");//1.1
                        else
                        {
                            strParentOZ.Append(ObjEPosition.Stufe1 + ".");//1
                        }
                    }
                    else if(ObjEPosition.RasterCount > 2)
                    {
                        if(!string.IsNullOrEmpty(ObjEPosition.Position))
                        {
                            strPositionOZ.Append("  .");
                        }
                    }

                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe3.Trim()))//1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe3 + ".");//1.1.1
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe3 + ".");//1.1.1
                        else
                        {
                            strParentOZ.Append(ObjEPosition.Stufe2 + ".");//1.1
                        }
                    }
                    else if(ObjEPosition.RasterCount > 3)
                    {
                        if(!string.IsNullOrEmpty(ObjEPosition.Position))
                        {
                            strPositionOZ.Append("  .");
                        }
                    }

                    if (!string.IsNullOrEmpty(ObjEPosition.Stufe4.Trim()))//1
                    {
                        strPositionOZ.Append(ObjEPosition.Stufe4 + ".");//1.1.1.1
                        if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                            strParentOZ.Append(ObjEPosition.Stufe4 + ".");//1.1.1.1
                        else
                        {
                            strParentOZ.Append(ObjEPosition.Stufe3 + ".");//1.1.1
                        }
                    }
                    else if(ObjEPosition.RasterCount > 4)
                    {
                        if(!string.IsNullOrEmpty(ObjEPosition.Position))
                        {
                            strPositionOZ.Append("  .");
                        }
                    }

                    if (!string.IsNullOrEmpty(ObjEPosition.Position.Trim()))
                    {
                        if (ObjEPosition.Position.Contains('.'))
                            strPositionOZ.Append(ObjEPosition.Position);
                        else
                            strPositionOZ.Append(ObjEPosition.Position + ".");
                        ObjEPosition.Title = string.Empty;
                    }
                    
                    ObjEPosition.Position_OZ = Convert.ToString(strPositionOZ);
                    ObjEPosition.Parent_OZ = Convert.ToString(strParentOZ);
                }
                else
                {
                    ObjEPosition.Position_OZ = "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler bei der Erstellung der Ordnungskennzahlen (OZ)");
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
                throw;
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

        public void GetPositionOZListByWGWA(EPosition ObjEPosition, int ProjectID, string Position_Type, string WG, string WA)
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

        public void Deleteposition(int PositionID, string _PosKZ)
        {
            try
            {
                ObjDPosition.DeletePosition(PositionID, _PosKZ);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EPosition GetArticleByTyp(EPosition ObjEPositon)
        {
            try
            {
                ObjEPositon = ObjDPosition.GetArticleByTyp(ObjEPositon);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public EPosition GetArticleByWI(EPosition ObjEPositon)
        {
            try
            {
                ObjEPositon = ObjDPosition.GetArticleByWI(ObjEPositon);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public EPosition GetArticleByWGWA(EPosition ObjEPositon)
        {
            try
            {
                ObjEPositon = ObjDPosition.GetArticleByWGWA(ObjEPositon);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public EPosition GetArticleByDimension(EPosition ObjEPositon)
        {
            try
            {
                ObjEPositon = ObjDPosition.GetArticleByDimension(ObjEPositon);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public DataSet GetOldPositionList(int ProjectID)
        {
            DataSet ds = new DataSet();
            try
            {
                 ds = ObjDPosition.GetOldPositionList(ProjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ds;
        }

        public int CopyPosition(EPosition ObjEPosition,string stOZChar)
        {
            int NewPositionID = 0;
            try
            {
                NewPositionID = ObjDPosition.CopyPosition(ObjEPosition, stOZChar);
            }
            catch (Exception ex)
            {
                throw;
            }
            return NewPositionID;
        }

        public EPosition GetArticleByA(EPosition ObjEPositon, string _DimType)
        {
            try
            {
                ObjEPositon = ObjDPosition.GetArticleByA(ObjEPositon, _DimType);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public EPosition GetArticleByB(EPosition ObjEPositon, string _DimType)
        {
            try
            {
                ObjEPositon = ObjDPosition.GetArticleByB(ObjEPositon, _DimType);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEPositon;
        }

        public string PrepareOZ(string strOZ, string strRaster)
        {
            string str = string.Empty;
            try
            {
                string[] strPOZ = strOZ.Split('.');
                string[] strPRaster = strRaster.Split('.');
                int Count = -1;
                int i = -1;
                Count = strPOZ.Count();
                while (Count > 0)
                {
                    i = i + 1;
                    Count = Count - 1;
                    string OZ = string.Empty;
                    int OZLength = 0;
                    int RasterLength = 0;

                    OZ = strPOZ[i].Trim();
                    RasterLength = strPRaster[i].Length;

                    OZLength = OZ.Trim().Length;

                    if (Count == 0)
                    {
                        if (RasterLength == 1 && OZLength > 0)
                        {
                            str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ;
                        }
                        else if (OZLength > 0)
                        {
                            str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ + ".";
                        }
                    }
                    else
                    {
                        if (OZ == "")
                        {
                            str = str + string.Concat(Enumerable.Repeat(" ", RasterLength - OZLength)) + OZ + ".";
                        }
                        else
                        {
                            str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ + ".";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Please enter valid OZ");
            }
            return str;
        }

    }
}
