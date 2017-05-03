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
    public class BSupplier
    {
        DSupplier ObjDSupplier = new DSupplier();

        public ESupplier SaveSupplierDetails(ESupplier ObjEsupplier)
        {
            try
            {
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Supplier";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SupplierID", ObjEsupplier.SupplierID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FullName", ObjEsupplier.SupplierFullName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ShortName", ObjEsupplier.SupplierShortName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PaymentCondition", ObjEsupplier.PaymentCondition);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Commentary", ObjEsupplier.Commentary.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjEsupplier.SupplierEmailID.ToString());

                ObjEsupplier = ObjDSupplier.SaveSupplierDetails(Xdoc, ObjEsupplier);
                return ObjEsupplier;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ESupplier GetSupplier(ESupplier ObjEsupplier)
        {
            try
            {
                if (ObjEsupplier != null)
                {
                    ObjEsupplier.dtSupplier = ObjDSupplier.GetSupplier().Tables[0];
                    ObjEsupplier.dtContact = ObjDSupplier.GetSupplier().Tables[1];
                    ObjEsupplier.dtAddress = ObjDSupplier.GetSupplier().Tables[2];
                    ObjEsupplier.dtArticle = ObjDSupplier.GetSupplier().Tables[3];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier;
        }

        public ESupplier SaveSupplierContactDetails(ESupplier ObjEsupplier)
        {
            try
            {
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/SupplierContact";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SupplierID", ObjEsupplier.Cont_supplierID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ContactPersonID", ObjEsupplier.ContactPersonID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ContactName", ObjEsupplier.Salutation);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Salutation", ObjEsupplier.ContactName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Designation", ObjEsupplier.Designation);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjEsupplier.ContEmailID);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telephone", ObjEsupplier.ContTelephone);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FAX", ObjEsupplier.ContFax.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DefaultContact", ObjEsupplier.DefaultContact.ToString());
                ObjEsupplier = ObjDSupplier.SavedsSupplierContactDetails(Xdoc, ObjEsupplier);
                return ObjEsupplier;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ESupplier SaveSupplierAddressDetails(ESupplier ObjEsupplier)
        {
            try
            {
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/SupplierAddress";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SupplierID", ObjEsupplier.Addr_supplierID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "AddressID", ObjEsupplier.AddressID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ShortName", ObjEsupplier.AddressShortName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "StreetNo", ObjEsupplier.StreetNo.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PostalCode", ObjEsupplier.AddrPostalCode);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "City", ObjEsupplier.AddrCity);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Country", ObjEsupplier.AddrCountry);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DefaultAddress", ObjEsupplier.DefaultAddress.ToString());
                ObjEsupplier = ObjDSupplier.SaveSupplierAddressDetails(Xdoc, ObjEsupplier);
                return ObjEsupplier;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ESupplier SaveArticle(ESupplier ObjEsupplier)
        {
            try
            {
                ObjEsupplier = ObjDSupplier.SaveArticle(ObjEsupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier;
        }

        public ESupplier GetWGWAForProposal(ESupplier ObjEsupplier,int _Pid,string _LvSection,int wg,int wa)
        {
            try
            {
                if (ObjEsupplier != null)
                {
                    ObjEsupplier.dsSupplier = ObjDSupplier.GetWGWaforProposal(_Pid, _LvSection,wg,wa);
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier;
        }

        public ESupplier GetLVSectionForProposal(ESupplier ObjEsupplier, int _Pid)
        {
            try
            {
                if (ObjEsupplier != null)
                {
                    ObjEsupplier.Article = ObjDSupplier.GetLVSectionforProposal(_Pid);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier;
        }

        public int SaveSupplierProposal(ESupplier ObjEsupplier, int _Pid, string _LvSection, int wg, int wa, DataTable _dtPosition, DataTable _dtSupplier)
        {
            try
            {
                ObjEsupplier.ProposalID = ObjDSupplier.SaveSupplierProposal(_Pid, _LvSection, wg, wa, _dtPosition, _dtSupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier.ProposalID;
        }

        public ESupplier GetProposalNumber(ESupplier ObjEsupplier)
        {
            try
            {
                ObjEsupplier = ObjDSupplier.GetProposalNumber(ObjEsupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier;
        }

        public ESupplier GetProposalPostions(ESupplier ObjESupplier)
        {
            try
            {
                ObjESupplier = ObjDSupplier.GetProposalPostions(ObjESupplier);
                DataTable dtTemp = ObjESupplier.dtPositions.Copy();
                int i = -1;
                foreach (DataColumn c in dtTemp.Columns)
                {
                    if(c.ColumnName != "SupplierProposalID" && c.ColumnName != "PositionID"
                        && c.ColumnName != "Position_OZ" && c.ColumnName != "Cheapest"
                        && c.ColumnName != "MA_listprice" && c.ColumnName != "ShortDescription"
                        && c.ColumnName != "Menge" && c.ColumnName != "A"
                        && c.ColumnName != "B" && c.ColumnName != "L"
                        && c.ColumnName != "ME" && c.ColumnName != "MA_Multi1"
                        && c.ColumnName != "MA_multi2" && c.ColumnName != "MA_multi3"
                        && c.ColumnName != "MA_multi4" && c.ColumnName != "LiefrantMA"
                        && c.ColumnName != "Fabricate" && c.ColumnName != "PID")
                    {
                        int iIndex = 0;
                        i++;
                        iIndex = c.Ordinal + i;
                        DataColumn dc = ObjESupplier.dtPositions.Columns.Add(c.ColumnName + "Check", typeof(bool));
                        dc.SetOrdinal(iIndex + 1);
                        dc.DefaultValue = false;
                        dc.Caption = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        public ESupplier UpdateSupplierPrice(ESupplier ObjESupplier)
        {
            try
            {
                ObjESupplier = ObjDSupplier.UpdateSupplierPrice(ObjESupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }
    }
}
