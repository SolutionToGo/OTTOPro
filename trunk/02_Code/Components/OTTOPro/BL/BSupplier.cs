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

        public int SaveSupplierDetails(ESupplier ObjEsupplier)
        {
            try
            {
                int supplierID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Supplier";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SupplierID", ObjEsupplier.SupplierID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FullName", ObjEsupplier.SupplierFullName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ShortName", ObjEsupplier.SupplierShortName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PaymentCondition", ObjEsupplier.PaymentCondition);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Commentary", ObjEsupplier.Commentary.ToString());


                supplierID = ObjDSupplier.SaveSupplierDetails(Xdoc);
                if (supplierID < 0)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        //  throw new Exception("Fehler beim Speichern der LV Angaben");
                    }
                    else
                    {
                        throw new Exception("Failed to Save Supplier");
                    }
                }
                return supplierID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetSupplier(ESupplier ObjEsupplier)
        {
            try
            {
                if (ObjEsupplier != null)
                {
                    ObjEsupplier.dsSupplier = ObjDSupplier.GetSupplier();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveSupplierContactDetails(ESupplier ObjEsupplier)
        {
            try
            {
                int ContactPersonID = -1;
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


                ContactPersonID = ObjDSupplier.SavedsSupplierContactDetails(Xdoc);
                if (ContactPersonID < 0)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                       // throw new Exception("Fehler beim Speichern der Kundeninformation");
                    }
                    else
                    {
                        throw new Exception("Failed to Save Supplier Contact");
                    }
                }
                return ContactPersonID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveSupplierAddressDetails(ESupplier ObjEsupplier)
        {
            try
            {
                int AddressID = -1;
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


                AddressID = ObjDSupplier.SaveSupplierAddressDetails(Xdoc);
                if (AddressID < 0)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        throw new Exception("Fehler beim Speichern der Kundenaddresse");
                    }
                    else
                    {
                        throw new Exception("Failed to Save Supplier Address");
                    }
                }
                return AddressID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
