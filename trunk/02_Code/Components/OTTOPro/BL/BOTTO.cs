using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using System.Xml;
using DataAccess;

namespace BL
{
    public class BOTTO
    {
        DOTTO ObjDOTTO = new DOTTO();

        public int SaveOTTODetails(EOTTO ObjEOTTO)
        {
            try
            {
                int OTTOID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/OTTO";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "OttoID", ObjEOTTO.OTTOID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ShortName", ObjEOTTO.ShortName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FullName", ObjEOTTO.FullName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "IsBranch", ObjEOTTO.IsBranch.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Street", ObjEOTTO.Street);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PostalCode", ObjEOTTO.PostalCode);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "City", ObjEOTTO.City);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Country", ObjEOTTO.Country.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ILN", ObjEOTTO.ILN);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BankName", ObjEOTTO.BankName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BankPostalCode", ObjEOTTO.BankPostalCode.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BankAccNo", ObjEOTTO.BankAccNo.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DVNr", ObjEOTTO.DVNr.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TenderNo", ObjEOTTO.TenderNo.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DebtorNo", ObjEOTTO.DebtorNo);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CountryType", ObjEOTTO.CountryType);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Industry", ObjEOTTO.Industry);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ArtBevBew", ObjEOTTO.ArtBevBew);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ArtNU", ObjEOTTO.ArtNU.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BGBez", ObjEOTTO.BGBez.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BGDatum", ObjEOTTO.BGDatum.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BGNr", ObjEOTTO.BGNr.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telefon", ObjEOTTO.Telefon.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telefax", ObjEOTTO.Telefax.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Website", ObjEOTTO.Website.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "HotLine", ObjEOTTO.HotLine.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "IBAN", ObjEOTTO.IBAN.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BIC", ObjEOTTO.BIC.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "USTIDNr", ObjEOTTO.USTIDNr.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SeatofCompany", ObjEOTTO.SeatofCompany.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ManagingDirector", ObjEOTTO.ManagingDirector.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Complementary", ObjEOTTO.Complementary.ToString());

                OTTOID = ObjDOTTO.SaveOTTODetails(Xdoc);
                if (OTTOID < 0)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        throw new Exception("Fehler beim Speichern von Daten zu OTTO");
                    }
                    else
                    {
                        throw new Exception("Failed to Save OTTO Details");
                    }
                }
                return OTTOID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetOTTODetails(EOTTO ObjEOTTO)
        {
            try
            {
                if (ObjEOTTO != null)
                {
                    ObjEOTTO.dsOTTO = ObjDOTTO.GetOTTODetails();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveOTTOContactDetails(EOTTO ObjEOTTO)
        {
            try
            {
                int ContactID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/OTTOContact";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "OttoID", ObjEOTTO.Cont_OttoID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ContactID", ObjEOTTO.ContactID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ContactPerson", ObjEOTTO.ContactPerson);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telephone", ObjEOTTO.Cont_Telephone.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Fax", ObjEOTTO.Fax);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjEOTTO.EmailID);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TaxNo", ObjEOTTO.TaxNo);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DefaultContact", ObjEOTTO.DefaultContact.ToString());


                ContactID = ObjDOTTO.SaveOTTOContactDetails(Xdoc);
                if (ContactID < 0)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        throw new Exception("Fehler beim Speichern der OTTO Kontaktdaten");
                    }
                    else
                    {
                        throw new Exception("Failed to Save OTTO Contact");
                    }
                }
                return ContactID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
//************
}
