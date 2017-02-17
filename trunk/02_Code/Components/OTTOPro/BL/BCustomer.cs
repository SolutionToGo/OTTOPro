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
    public class BCustomer
    {
        DCustomer ObjDCustomer = new DCustomer();

        public int SaveCustomerDetails(ECustomer ObjECustomer)
        {
            try
            {
                int CustomerID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Customer";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CustomerID", ObjECustomer.Customer_CustomerID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CustomerFullName", ObjECustomer.CustomerFullName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CustomerShortName", ObjECustomer.CustomerShortName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Street", ObjECustomer.CustStreet.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PostalCode", ObjECustomer.CustPostalCode);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "City", ObjECustomer.CustCity);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Country", ObjECustomer.CustCountry);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ILN", ObjECustomer.ILN.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telephone", ObjECustomer.Telephone);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Fax", ObjECustomer.CustFax.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjECustomer.CustEmailID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TaxNumber", ObjECustomer.CustTaxNumber.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BankName", ObjECustomer.BankName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BankPostalCode", ObjECustomer.BankPostalCode.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "BankAccountNumber", ObjECustomer.BankAccountNumber);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DVNr", ObjECustomer.DVNr);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TenderNumber", ObjECustomer.TenderNumber);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DebitorNumber", ObjECustomer.DebitorNumber);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CountryType", ObjECustomer.CountryType.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CountryName", ObjECustomer.CountryName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Commentary", ObjECustomer.Commentary.ToString());


               CustomerID= ObjDCustomer.SaveCustomerDetails(Xdoc);
               if (CustomerID < 0)
               {
                   if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   {
                       //  throw new Exception("Fehler beim Speichern der LV Angaben");
                   }
                   else
                   {
                       throw new Exception("Failed to Save Customer");
                   }
               }
                return CustomerID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetCustomers(ECustomer ObjECustomer)
        {
            try
            {
                if (ObjECustomer != null)
                {
                    ObjECustomer.dsCustomer = ObjDCustomer.GetCustomers();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveCustomerContactDetails(ECustomer ObjECustomer)
        {
            try
            {
                int ContactPersonID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/CustomerContact";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CustomerID", ObjECustomer.Cont_CustomerID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ContactPersonID", ObjECustomer.ContactPersonID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Salutation", ObjECustomer.Salutation);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ContatPersonName", ObjECustomer.ContatPersonName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Designation", ObjECustomer.Designation);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjECustomer.ContEmailID);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Telephone", ObjECustomer.ContTelephone);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FAX", ObjECustomer.ContFax.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DefaultContact", ObjECustomer.DefaultContact.ToString());


               ContactPersonID= ObjDCustomer.SaveCustomerContactDetails(Xdoc);
                if (ContactPersonID < 0)
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        //  throw new Exception("Fehler beim Speichern der LV Angaben");
                    }
                    else
                    {
                        throw new Exception("Failed to Save Customer Contact");
                    }
                }
                return ContactPersonID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveCustomerAddressDetails(ECustomer ObjECustomer)
        {
            try
            {
                int AddressID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/CustomerAddress";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CustomerID", ObjECustomer.Addr_CustomerID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "AddressID", ObjECustomer.AddressID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "AddressShortName", ObjECustomer.AddressShortName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "StreetNo", ObjECustomer.StreetNo.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "PostalCode", ObjECustomer.AddrPostalCode);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "City", ObjECustomer.AddrCity);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Country", ObjECustomer.AddrCountry);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DefaultAddress", ObjECustomer.DefaultAddress.ToString());


                AddressID=ObjDCustomer.SaveCustomerAddressDetails(Xdoc);
                 if (AddressID < 0)
                 {
                     if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                     {
                         //  throw new Exception("Fehler beim Speichern der LV Angaben");
                     }
                     else
                     {
                         throw new Exception("Failed to Save Customer Address");
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
