using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FullName", ObjEsupplier.SupplierFullName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ShortName", ObjEsupplier.SupplierShortName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PaymentCondition", ObjEsupplier.PaymentCondition);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Commentary", ObjEsupplier.Commentary);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjEsupplier.SupplierEmailID);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Street", ObjEsupplier.SupplierStreet);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telephone", ObjEsupplier.SupplierTelephone);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Fax", ObjEsupplier.SupplierFax);

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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ContactName", ObjEsupplier.ContactName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Salutation", ObjEsupplier.Salutation);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Designation", ObjEsupplier.Designation);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjEsupplier.ContEmailID);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telephone", ObjEsupplier.ContTelephone);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FAX", ObjEsupplier.ContFax);
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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "StreetNo", ObjEsupplier.StreetNo);
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

        public ESupplier GetWGWAForProposal(ESupplier ObjEsupplier, int _Pid, string _LvSection, string wg, string wa)
        {
            try
            {
                if (ObjEsupplier != null)
                {
                    ObjEsupplier.dsSupplier = ObjDSupplier.GetWGWaforProposal(_Pid, _LvSection, wg, wa);
                    if (ObjEsupplier.dsSupplier != null && ObjEsupplier.dsSupplier.Tables.Count > 0)
                    {
                        ObjEsupplier.dtNewPositions = ObjEsupplier.dsSupplier.Tables[0];
                        if (ObjEsupplier.dsSupplier.Tables.Count > 1)
                        {
                            ObjEsupplier.dtDeletedPositions = ObjEsupplier.dsSupplier.Tables[1];
                            if (ObjEsupplier.dsSupplier.Tables.Count > 2)
                            {
                                ObjEsupplier.dtProposedPositions = ObjEsupplier.dsSupplier.Tables[2];
                            }
                        }

                    }
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

        public int SaveSupplierProposal(ESupplier ObjEsupplier, int _Pid, string _LvSection, string wg, string wa, DataTable _dtPosition, DataTable _dtSupplier, DataTable _dtDeletedPositions)
        {
            try
            {
                ObjEsupplier.ProposalID = ObjDSupplier.SaveSupplierProposal(_Pid, _LvSection, wg, wa, _dtPosition, _dtSupplier, _dtDeletedPositions);
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

        public ESupplier SaveDeletePosition(ESupplier ObjEsupplier)
        {
            try
            {
                ObjEsupplier = ObjDSupplier.SaveDeletePosition(ObjEsupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier;
        }

        public ESupplier GetProposalPostions(ESupplier ObjESupplier, bool _IsCalculate = true)
        {
            try
            {
                ObjESupplier = ObjDSupplier.GetProposalPostions(ObjESupplier);
                ObjESupplier.dtPositions.Columns["Cheapest"].Caption = "Niedrigstpreis";
                DataTable dtTemp = ObjESupplier.dtPositions.Clone();
                ChangeCultureInfo(dtTemp);
                foreach (DataColumn dc in dtTemp.Columns)
                {
                    if (dc.ColumnName.Contains("Check"))
                    {
                        dc.DataType = System.Type.GetType("System.Boolean");
                        dc.Caption = "";
                    }
                    else if (dtTemp.Columns[dc.ColumnName + "Check"] != null)
                    {
                        dc.DataType = System.Type.GetType("System.Decimal");
                    }
                    else if (dc.ColumnName.Contains("Multi"))
                    {
                        dc.DataType = System.Type.GetType("System.Decimal");
                    }
                }
                foreach (DataRow dr in ObjESupplier.dtPositions.Rows)
                {
                    dtTemp.ImportRow(dr);
                }
                ObjESupplier.dtPositions = new DataTable();
                ChangeCultureInfo(ObjESupplier.dtPositions);
                ObjESupplier.dtPositions = dtTemp.Copy();
                if (_IsCalculate)
                    ObjESupplier = CalculateCheapestValues(ObjESupplier);
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

        public ESupplier SaveProposaleValues(ESupplier ObjESupplier)
        {
            try
            {
                ObjESupplier = ObjDSupplier.SaveProposaleValues(ObjESupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        public ESupplier SaveSelection(ESupplier ObjESupplier)
        {
            try
            {
                ObjESupplier = ObjDSupplier.SaveSelection(ObjESupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        public ESupplier ChangeProposalView(ESupplier ObjESupplier, int ViewMode)
        {
            try
            {
                if (ViewMode == 0)
                {
                    ObjESupplier = GetProposalPostions(ObjESupplier);
                }
                else
                {
                    ObjESupplier = GetProposalPostions(ObjESupplier, false);
                    List<string> TableColumnNAmes = new List<string>();
                    foreach (DataColumn dc in ObjESupplier.dtPositions.Columns)
                    {
                        if (ObjESupplier.dtPositions.Columns[dc.ColumnName + "Check"] != null)
                        {
                            TableColumnNAmes.Add(dc.ColumnName);
                        }
                    }

                    foreach (DataRow drTemp in ObjESupplier.dtPositions.Rows)
                    {
                        foreach (string s in TableColumnNAmes)
                        {
                            decimal DValue = 0;
                            string strValue = drTemp[s] == DBNull.Value ? "" : drTemp[s].ToString();
                            if (decimal.TryParse(strValue, out DValue))
                            {
                                if (ViewMode == 1 || ViewMode == 3)
                                {
                                    string strMulti1 = drTemp[s + "Multi1"] == DBNull.Value ? "" : drTemp[s + "Multi1"].ToString();
                                    string strMulti2 = drTemp[s + "Multi2"] == DBNull.Value ? "" : drTemp[s + "Multi2"].ToString();
                                    string strMulti3 = drTemp[s + "Multi3"] == DBNull.Value ? "" : drTemp[s + "Multi3"].ToString();
                                    string strMulti4 = drTemp[s + "Multi4"] == DBNull.Value ? "" : drTemp[s + "Multi4"].ToString();
                                    decimal dMulti1 = 1;
                                    decimal dMulti2 = 1;
                                    decimal dMulti3 = 1;
                                    decimal dMulti4 = 1;

                                    if (decimal.TryParse(strMulti1, out dMulti1))
                                        DValue = DValue * dMulti1;
                                    if (decimal.TryParse(strMulti2, out dMulti2))
                                        DValue = DValue * dMulti2;
                                    if (decimal.TryParse(strMulti3, out dMulti3))
                                        DValue = DValue * dMulti3;
                                    if (decimal.TryParse(strMulti4, out dMulti4))
                                        DValue = DValue * dMulti4;
                                }
                                if (ViewMode == 2 || ViewMode == 3)
                                {
                                    decimal dMenge = 0;
                                    string strMenge = drTemp["Menge"] == DBNull.Value ? "" : drTemp["Menge"].ToString();
                                    if (decimal.TryParse(strMenge, out dMenge))
                                        DValue = DValue * dMenge;
                                }
                            }
                            drTemp[s] = Math.Round(DValue, 3);
                        }
                    }
                    ObjESupplier = CalculateCheapestValues(ObjESupplier);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        private ESupplier CalculateCheapestValues(ESupplier ObjESupplier)
        {
            try
            {
                List<string> TableColumnNAmes = new List<string>();
                foreach (DataColumn dc in ObjESupplier.dtPositions.Columns)
                {
                    if (ObjESupplier.dtPositions.Columns[dc.ColumnName + "Check"] != null)
                    {
                        TableColumnNAmes.Add(dc.ColumnName);
                    }
                }

                foreach (DataRow drTemp in ObjESupplier.dtPositions.Rows)
                {
                    List<double> SupplierPirces = new List<double>();
                    foreach (string s in TableColumnNAmes)
                    {
                        double DValue = drTemp[s] == DBNull.Value ? 0 : Math.Round(Convert.ToDouble(drTemp[s]), 3);
                        if (DValue > 0)
                            SupplierPirces.Add(DValue);
                    }
                    if (SupplierPirces != null && SupplierPirces.Count() > 0)
                    {
                        var i = Math.Round(SupplierPirces.Min(), 3);
                        drTemp["Cheapest"] = i;
                    }
                    else
                        drTemp["Cheapest"] = 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        private void ChangeCultureInfo(DataTable table)
        {
            CultureInfo myCultureInfo = new CultureInfo("en-gb");
            table.Locale = myCultureInfo;
        }

        public ESupplier GetSupplierMail(ESupplier ObjEsupplier, int ProposalID, int ProjectID)
        {
            try
            {
                ObjEsupplier = ObjDSupplier.GetSupplierMail(ObjEsupplier, ProposalID, ProjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEsupplier;
        }

        public ESupplier CheckSupplierArticle(ESupplier ObjESupplier)
        {
            try
            {
                ObjESupplier = ObjDSupplier.CheckSupplierArticle(ObjESupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        public ESupplier UpdateSupplierProposal(ESupplier ObjESupplier)
        {
            try
            {
                if (ObjDSupplier == null)
                    ObjDSupplier = new DSupplier();
                ObjESupplier = ObjDSupplier.UpdateSupplierProposal(ObjESupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        public ESupplier DeleteSupplierArticleMap(ESupplier ObjESupplier)
        {
            try
            {
                if (ObjDSupplier == null)
                    ObjDSupplier = new DSupplier();
                ObjESupplier = ObjDSupplier.DeleteSupplierArticleMap(ObjESupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }

        public ESupplier UpdateProposalDate(ESupplier ObjESupplier)
        {
            try
            {
                if (ObjDSupplier == null)
                    ObjDSupplier = new DSupplier();
                ObjESupplier = ObjDSupplier.UpdateProposalDate(ObjESupplier);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjESupplier;
        }
    }
}

