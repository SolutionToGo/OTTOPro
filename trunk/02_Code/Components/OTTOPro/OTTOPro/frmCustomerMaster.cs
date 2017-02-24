using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using EL;
using BL;
using System.Threading;

namespace OTTOPro
{
    public partial class frmCustomerMaster : DevExpress.XtraEditors.XtraForm
    {
        ECustomer ObjECustomer =null;
        BCustomer ObjBCustomer = null;
        string _CustomerType = null;
        private ECustomer _ObjEcustomer = null;

        #region PROPERTY SETTING

        public ECustomer ObjEcustomer
        {
            get
            {
                return _ObjEcustomer;
            }
            set
            {
                _ObjEcustomer = value;
            }
        }

        #endregion


        #region CONSTRUCTOR

        public frmCustomerMaster()
        {
            InitializeComponent();
        }

        public frmCustomerMaster(string _Type, ECustomer ObjECustomer1)
        {
            InitializeComponent();
            _CustomerType = _Type;
            ObjECustomer = ObjECustomer1;
        }


        #endregion


        #region EVENTS

        XtraTabPage ObjTabDetails = null;
        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CustomerType == "Customer")
                {
                    this.Text = "Customer Master";
                    ObjTabDetails = tbCustomerMaster;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(760, 689);

                }
                if (_CustomerType == "Contact")
                {
                    this.Text = "Customer Contact";
                    ObjTabDetails = tbCustomerContacts;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(500, 342);
                }
                if (_CustomerType == "Address")
                {
                    this.Text = "Customer Address";
                    ObjTabDetails = tbCustomerAddress;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(500, 320);
                }
                if (_CustomerType == "Customer")
                    BindCustomerDetails();
                if (_CustomerType == "Contact")
                    BindContactsDetails();
                if (_CustomerType == "Address")
                    BindAddressDetails();
                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjECustomer == null)
                    ObjECustomer = new ECustomer();
                ParseCustomerDetails();
                ObjBCustomer = new BCustomer();
                ObjECustomer.Customer_CustomerID = ObjBCustomer.SaveCustomerDetails(ObjECustomer);
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjECustomer == null)
                    ObjECustomer = new ECustomer();
                ParseCustomerContactsDetails();
                ObjBCustomer = new BCustomer();
                ObjECustomer.ContactPersonID = ObjBCustomer.SaveCustomerContactDetails(ObjECustomer);
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSaveAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjECustomer == null)
                    ObjECustomer = new ECustomer();
                ParseCustomerAddressDetails();
                ObjBCustomer = new BCustomer();
                ObjECustomer.AddressID = ObjBCustomer.SaveCustomerAddressDetails(ObjECustomer);
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtCustFullName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit textbox = (TextEdit)sender;
                textbox.Text = ToTitleCase(textbox.Text);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        #endregion


        #region METHODS

        private void TabChange(XtraTabPage ObjTabDetails)
        {
            try
            {
                if (ObjTabDetails != null)
                {
                    if (ObjTabDetails.PageVisible == true)
                        tcCustomers.SelectedTabPage = ObjTabDetails;
                    else
                    {
                        ObjTabDetails.PageVisible = true;
                        tcCustomers.SelectedTabPage = ObjTabDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ParseCustomerDetails()
        {
            try
            {
                ObjECustomer.CustomerFullName = txtCustFullName.Text;
                ObjECustomer.CustomerShortName = txtCustShortName.Text;
                ObjECustomer.CustStreet = txtCustStreet.Text;
                ObjECustomer.CustPostalCode = txtCustPostalCode.Text;
                ObjECustomer.CustCity = txtCustCity.Text;
                ObjECustomer.CustCountry = txtCustCountry.Text;
                ObjECustomer.ILN = txtILN.Text;
                ObjECustomer.Telephone = txtCustTelephone.Text;
                ObjECustomer.CustFax = txtCustFax.Text;
                ObjECustomer.CustEmailID = txtCustEmail.Text;
                ObjECustomer.CustTaxNumber = txtCustTaxNo.Text;
                ObjECustomer.BankName = txtCustBankName.Text;
                ObjECustomer.BankPostalCode = txtCustBankPCode.Text;
                ObjECustomer.BankAccountNumber = txtCustAccNo.Text;
                ObjECustomer.DVNr = txtDVNr.Text;
                ObjECustomer.TenderNumber = txtCustTenderNo.Text;
                ObjECustomer.DebitorNumber = txtCustDebitorNo.Text;
                ObjECustomer.CountryType = txtCustCountryType.Text;
                ObjECustomer.CountryName = txtCustCountryName.Text;               
                ObjECustomer.Commentary = memoEditCommentary.Text;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void BindCustomerDetails()
        {
            try
            {
                txtCustFullName.Text = ObjECustomer.CustomerFullName;
                txtCustShortName.Text = ObjECustomer.CustomerShortName;
                txtCustStreet.Text = ObjECustomer.CustStreet;
                txtCustPostalCode.Text = ObjECustomer.CustPostalCode;
                txtCustCity.Text = ObjECustomer.CustCity;
                txtCustCountry.Text = ObjECustomer.CustCountry;
                txtILN.Text = ObjECustomer.ILN;
                txtCustTelephone.Text = ObjECustomer.Telephone;
                txtCustFax.Text = ObjECustomer.CustFax;
                txtCustEmail.Text = ObjECustomer.CustEmailID;
                txtCustTaxNo.Text = ObjECustomer.CustTaxNumber;
                txtCustBankName.Text = ObjECustomer.BankName;
                txtCustBankPCode.Text = ObjECustomer.BankPostalCode;
                txtCustAccNo.Text = ObjECustomer.BankAccountNumber;
                txtDVNr.Text = ObjECustomer.DVNr;
                txtCustTenderNo.Text = ObjECustomer.TenderNumber;
                txtCustDebitorNo.Text = ObjECustomer.DebitorNumber;
                txtCustCountryType.Text = ObjECustomer.CountryType;
                txtCustCountryName.Text = ObjECustomer.CountryName;
                memoEditCommentary.Text = ObjECustomer.Commentary;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void ParseCustomerContactsDetails()
        {
            try
            {
                ObjECustomer.Salutation = cmbSalutation.Text;
                ObjECustomer.ContatPersonName = txtContactName.Text;
                ObjECustomer.Designation = txtContDesignation.Text;
                ObjECustomer.ContEmailID = txtContMail.Text;
                ObjECustomer.ContTelephone = txtContTelephone.Text;
                ObjECustomer.ContFax = txtContFax.Text;
                ObjECustomer.DefaultContact = Convert.ToBoolean(chkDefaultContact.CheckState);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void BindContactsDetails()
        {
            try
            {
                cmbSalutation.Text = ObjECustomer.Salutation;
                txtContactName.Text = ObjECustomer.ContatPersonName;
                txtContDesignation.Text = ObjECustomer.Designation;
                txtContMail.Text = ObjECustomer.ContEmailID;
                txtContTelephone.Text = ObjECustomer.ContTelephone;
                txtContFax.Text = ObjECustomer.ContFax;
                chkDefaultContact.EditValue = ObjECustomer.DefaultContact;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void ParseCustomerAddressDetails()
        {
            try
            {
                ObjECustomer.AddressShortName = txtAddShortName.Text;
                ObjECustomer.StreetNo = txtAddStreetNo.Text;
                ObjECustomer.AddrPostalCode = txtAddPostalCode.Text;
                ObjECustomer.AddrCity = txtAddCity.Text;
                ObjECustomer.AddrCountry = txtAddCountry.Text;
                ObjECustomer.DefaultAddress = Convert.ToBoolean(chkDefaultAddress.CheckState);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void BindAddressDetails()
        {
            try
            {
                txtAddShortName.Text = ObjECustomer.AddressShortName;
                txtAddStreetNo.Text = ObjECustomer.StreetNo;
                txtAddPostalCode.Text = ObjECustomer.AddrPostalCode;
                txtAddCity.Text = ObjECustomer.AddrCity;
                txtAddCountry.Text = ObjECustomer.AddrCountry;
                chkDefaultAddress.EditValue = ObjECustomer.DefaultAddress;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static string ToTitleCase(string stringToConvert)
        {
            try
            {
                return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(stringToConvert);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        #endregion




//*******************
    }
}