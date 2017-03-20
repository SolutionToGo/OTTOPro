using DataAccess;
using EL;
using System;
using System.Collections.Generic;
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
    }
}
