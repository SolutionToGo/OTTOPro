using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class BPosition
    {
        DPosition ObjDPosition = new DPosition();

        public int SavePositionDetails(EPosition ObjEPosition)
        {
            try
            {
                int PositionID = -1;
                XmlDocument Xdoc = new XmlDocument();
                PrepareOZ(ObjEPosition);
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
                PositionID = ObjDPosition.SavePositionDetails(Xdoc, ObjEPosition.LongDescription);
                if (PositionID < 0)
                    throw new Exception("Failed to Save LV Details");
                //else
                //    ObjEPosition.PositionID = PositionID;
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

        public byte[] GetLongDescription(int PositionID)
        {
            byte[] LongDescription = null;
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

        public void PrepareOZ(EPosition ObjEPosition)
        {
            try
            {
                StringBuilder strParentOZ = new StringBuilder();
                StringBuilder strPositionOZ = new StringBuilder();
               
                //Checking stufe existence
                if(!string.IsNullOrEmpty(ObjEPosition.Stufe1)) //1
                {
                    strPositionOZ.Append(ObjEPosition.Stufe1);  //1
                    if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                        strParentOZ.Append(ObjEPosition.Stufe1);//1
                    else
                        ObjEPosition.Title = ObjEPosition.Stufe1Title;
                }
                if(!string.IsNullOrEmpty(ObjEPosition.Stufe2))//1
                {
                    strPositionOZ.Append("." + ObjEPosition.Stufe2);//1.1
                    if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                        strParentOZ.Append("." + ObjEPosition.Stufe2);//1.1
                    else
                    {
                        strParentOZ.Append(ObjEPosition.Stufe1);//1
                        ObjEPosition.Title = ObjEPosition.Stufe2Title;
                    }
                    
                }
                if(!string.IsNullOrEmpty(ObjEPosition.Stufe3))//1
                {
                    strPositionOZ.Append("." + ObjEPosition.Stufe3);//1.1.1
                    if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                        strParentOZ.Append("." + ObjEPosition.Stufe3);//1.1.1
                    else
                    {
                        strParentOZ.Append("." + ObjEPosition.Stufe2);//1.1
                        ObjEPosition.Title = ObjEPosition.Stufe3Title;
                    }
                }
                if(!string.IsNullOrEmpty(ObjEPosition.Stufe4))//1
                {
                    strPositionOZ.Append("." + ObjEPosition.Stufe4);//1.1.1.1
                    if (!string.IsNullOrEmpty(ObjEPosition.Position))//1
                        strParentOZ.Append("." + ObjEPosition.Stufe4);//1.1.1.1
                    else
                    {
                        strParentOZ.Append("." + ObjEPosition.Stufe3);//1.1.1
                        ObjEPosition.Title = ObjEPosition.Stufe4Title;
                    }
                }
                if (!string.IsNullOrEmpty(ObjEPosition.Position))
                {
                    strPositionOZ.Append("." + ObjEPosition.Position);
                    ObjEPosition.Title = string.Empty;
                }
                
                //Assogning the final values to entities
                ObjEPosition.Parent_OZ = strParentOZ.ToString();
                if (ObjEPosition.PositionKZ.ToLower() != "s")
                    ObjEPosition.Position_OZ = strPositionOZ.ToString();
                else
                    ObjEPosition.Position_OZ = strParentOZ + ".ZZZ.Z";
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
    }
}
