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
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;

namespace OTTOPro
{
    public partial class frmCustomerMaster : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// private variables to store temp data
        /// </summary>
        ECustomer ObjECustomer =null;
        BCustomer ObjBCustomer = null;
        string _CustomerType = null;
        private ECustomer _ObjEcustomer = null;
        bool _isValidate = false;

        /// <summary>
        /// to assign the values in different forms
        /// </summary>
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

        /// <summary>
        ///parametrised constructor: to get the customer type like we have three type customer,contact, address and to recieve the customer object
        /// </summary>
        /// <param name="_Type"></param>
        /// <param name="ObjECustomer1"></param>
        public frmCustomerMaster(string _Type, ECustomer ObjECustomer1)
        {
            InitializeComponent();
            _CustomerType = _Type;
            ObjECustomer = ObjECustomer1;
        }


        #endregion


        #region EVENTS

        /// <summary>
        /// form load event
        /// </summary>
        XtraTabPage ObjTabDetails = null;
        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if(Utility.CustomerDataAccess == "7")
                {
                    btnSaveCustomer.Enabled = false;
                    btnSaveContact.Enabled = false;
                    btnSaveAddress.Enabled = false;
                }
                if (_CustomerType == "Customer")
                {
                    this.Text = "Stammdaten Kunden";
                    ObjTabDetails = tbCustomerMaster;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(645, 570);

                }
                if (_CustomerType == "Contact")
                {
                    this.Text = "Kundenkontact";
                    ObjTabDetails = tbCustomerContacts;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(500, 310);
                }
                if (_CustomerType == "Address")
                {
                    this.Text = "Kundenaddresse";
                    ObjTabDetails = tbCustomerAddress;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(500, 300);
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

        /// <summary>
        /// form close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// to save the customer data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCustFullName.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben: Vollständiger Name");
                }
                if (string.IsNullOrEmpty(txtCustShortName.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben: Kurzname");
                }
               // ValidatControls();
                //if (_isValidate==true)
                //{
                    if (ObjECustomer == null)
                        ObjECustomer = new ECustomer();
                    ParseCustomerDetails();
                    ObjBCustomer = new BCustomer();
                    ObjECustomer.Customer_CustomerID = ObjBCustomer.SaveCustomerDetails(ObjECustomer);
                    _isValidate = true;
                //}                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// to save contact person data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtContactName.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben: Name");
                }  
                bool isvalidName = dxValidationProviderContactName.Validate(txtContactName);
                if (!isvalidName)
                { _isValidate = false; }
                else
                {
                    _isValidate = true;
                }
                if (_isValidate == true)
                {
                    if (ObjECustomer == null)
                        ObjECustomer = new ECustomer();
                    ParseCustomerContactsDetails();
                    ObjBCustomer = new BCustomer();
                    ObjECustomer.ContactPersonID = ObjBCustomer.SaveCustomerContactDetails(ObjECustomer);
                    _isValidate = true;
                }                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// to save Address data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAddShortName.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben: Name");
                }     

                bool isvalidName = dxValidationProviderAddShortName.Validate(txtAddShortName);
                if (!isvalidName)
                { _isValidate = false; }
                else
                {
                    _isValidate = true;
                }
                if (_isValidate == true)
                {
                    if (ObjECustomer == null)
                        ObjECustomer = new ECustomer();
                    ParseCustomerAddressDetails();
                    ObjBCustomer = new BCustomer();
                    ObjECustomer.AddressID = ObjBCustomer.SaveCustomerAddressDetails(ObjECustomer);
                    _isValidate = true;
                }                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// form close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCustomerMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult != DialogResult.Cancel)
                {
                    if (_isValidate == false)
                        e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        #endregion


        #region METHODS
        /// <summary>
        /// to activate tab according to type
        /// </summary>
        /// <param name="ObjTabDetails"></param>
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

        /// <summary>
        /// assigning the value to Ecustomer object for customer 
        /// </summary>
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

        /// <summary>
        /// assigning the value from DB to textboxes of customer
        /// </summary>
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

        /// <summary>
        /// assigning the value to Ecustomer object for Contact 
        /// </summary>
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

        /// <summary>
        /// assigning the value from DB to textboxes of Contact
        /// </summary>
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

        /// <summary>
        /// assigning the value to Ecustomer object for address
        /// </summary>
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

        /// <summary>
        /// assigning the value from DB to textboxes of Address
        /// </summary>
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

        /// <summary>
        /// for validation
        /// </summary>
        private void ValidatControls()
        {
            try
            {
                bool isValidCustFullName = dxValidationProviderCustFullName.Validate(txtCustFullName);
                bool isvalidCustShortName=dxValidationProviderCustShortName.Validate(txtCustShortName);
                if (!isValidCustFullName || !isvalidCustShortName)
                {
                    _isValidate = false;
                }
                else
                {
                    _isValidate = true;
                }                
            }
            catch (Exception Ex)
            {
                throw;
            }

        }


        #endregion

        /// <summary>
        /// for restriction of characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != ' ' && !Char.IsDigit(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// for accepting only two lines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustStreet_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                RichTextBox txt = (RichTextBox)sender;
                if (e.KeyCode == Keys.Enter && txt.Lines.Length >= 2)
                {
                    e.Handled = true;
                }
                if (e.KeyData == (Keys.Control | Keys.C) || e.KeyData == (Keys.Control | Keys.V))
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
                
        }
    }
}