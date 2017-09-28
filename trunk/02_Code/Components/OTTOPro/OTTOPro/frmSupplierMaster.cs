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
    public partial class frmSupplierMaster : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// private variables to store temp data
        /// </summary>
        BSupplier ObjBSupplier = null;
        string _SupplierType = null;
        private ESupplier _ObjEsupplier = null;
        bool _isValidate = false;



        #region CONSTRUCTORS

        /// <summary>
        /// default constructor
        /// </summary>
        public frmSupplierMaster()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parameterised constructor to get type 
        /// </summary>
        /// <param name="_Type"></param>
        public frmSupplierMaster(string _Type)
        {
            InitializeComponent();
            _SupplierType = _Type;
        } 
        #endregion

        /// <summary>
        /// to assign the values in different forms
        /// </summary>
        #region PROPERTY SETTING

        public ESupplier ObjEsupplier
        {
            get
            {
                return _ObjEsupplier;
            }
            set
            {
                _ObjEsupplier = value;
            }
        }

        #endregion


        #region EVENTS

        /// <summary>
        /// form load event
        /// </summary>
        XtraTabPage ObjTabDetails = null;
        private void frmSupplierMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if(Utility.SupplierDataAccess == "7")
                {
                    btnSave.Enabled = false;
                    btnSaveAddress.Enabled = false;
                    btnSaveContact.Enabled = false;
                }
                if (_SupplierType == "Supplier")
                {
                    this.Text = "Stammdaten Lieferanten";
                    ObjTabDetails = tbSupplier;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(504, 603);
                }
                if (_SupplierType == "Contact")
                {
                    this.Text = "Lieferantenkontact";
                    ObjTabDetails = tbSupplierContact;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(504, 320);
                }
                if (_SupplierType == "Address")
                {
                    this.Text = "Lieferantenaddresse";
                    ObjTabDetails = tbSupplierAddress;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(504, 270);
                }
                if (_SupplierType == "Supplier" && _ObjEsupplier.SupplierID > 0)
                    BindSupplierDetails();
                if (_SupplierType == "Contact" && _ObjEsupplier.ContactPersonID > 0)
                    BindContactsDetails();
                if (_SupplierType == "Address" && _ObjEsupplier.AddressID > 0)
                    BindAddressDetails();

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// form cancel event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// to save supplier data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben Vollständiger Name");
                }
                if (string.IsNullOrEmpty(txtShortName.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben Kurz Name");
                }   
                if (string.IsNullOrEmpty(txtSupplierEmail.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben Email");
                }   
                    if (_ObjEsupplier == null)
                        _ObjEsupplier = new ESupplier();
                    ParseSupplierDetails();
                    ObjBSupplier = new BSupplier();
                    _ObjEsupplier = ObjBSupplier.SaveSupplierDetails(_ObjEsupplier);
                    _isValidate = true;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        /// <summary>
        /// to save contact data
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
                    throw new Exception("Bitte eingeben Name");
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
                    if (_ObjEsupplier == null)
                        _ObjEsupplier = new ESupplier();
                    ParseSupplierContactsDetails();
                    ObjBSupplier = new BSupplier();
                    _ObjEsupplier = ObjBSupplier.SaveSupplierContactDetails(_ObjEsupplier);
                    _isValidate = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// to save address data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAddrShortName.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben Name");
                }                   

                bool isvalidName = dxValidationProviderAddrSName.Validate(txtAddrShortName);
                if (!isvalidName)
                { _isValidate = false; }
                else
                {
                    _isValidate = true;
                }
                if (_isValidate == true)
                {
                    if (_ObjEsupplier == null)
                        _ObjEsupplier = new ESupplier();
                    ParseSupplierAddressDetails();
                    ObjBSupplier = new BSupplier();
                    _ObjEsupplier = ObjBSupplier.SaveSupplierAddressDetails(_ObjEsupplier);
                    this.Close();
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
        private void frmSupplierMaster_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// to restrict characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && !Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }


        #endregion


        #region METHODS

        /// <summary>
        /// to bind supplier data 
        /// </summary>
        private void BindSupplierDetails()
        {
            try
            {
                txtFullName.Text = _ObjEsupplier.SupplierFullName;
                txtShortName.Text = _ObjEsupplier.SupplierShortName;
                txtCommentary.Text = _ObjEsupplier.Commentary;
                txtPaymentCondition.Text = _ObjEsupplier.PaymentCondition;
                txtSupplierEmail.Text = _ObjEsupplier.SupplierEmailID;
                txtSupptreet.Text = _ObjEsupplier.SupplierStreet;
                txtSuppTelephone.Text = _ObjEsupplier.SupplierTelephone;
                txtSuppFax.Text = _ObjEsupplier.SupplierFax;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// to bind contact details
        /// </summary>
        private void BindContactsDetails()
        {
            try
            {
                cmbSalutation.Text = _ObjEsupplier.Salutation;
                txtContactName.Text = _ObjEsupplier.ContactName;
                txtDesignation.Text = _ObjEsupplier.Designation;
                txtContactemail.Text = _ObjEsupplier.ContEmailID;
                txtContacttelephone.Text = _ObjEsupplier.ContTelephone;
                txtContactFax.Text = _ObjEsupplier.ContFax;
                chkDefaultContact.EditValue = _ObjEsupplier.DefaultContact;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// to bind address data            
        /// </summary>
        private void BindAddressDetails()
        {
            try
            {
                txtAddrShortName.Text = _ObjEsupplier.AddressShortName;
                txtAddrStreetNo.Text = _ObjEsupplier.StreetNo;
                txtAddrPostalCode.Text = _ObjEsupplier.AddrPostalCode;
                txtAddrcity.Text = _ObjEsupplier.AddrCity;
                txtAddrCountry.Text = _ObjEsupplier.AddrCountry;
                chkDefaultAddress.EditValue = _ObjEsupplier.DefaultAddress;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// tab change according to type
        /// </summary>
        /// <param name="ObjTabDetails"></param>
        private void TabChange(XtraTabPage ObjTabDetails)
        {
            try
            {
                if (ObjTabDetails != null)
                {
                    if (ObjTabDetails.PageVisible == true)
                        tcSupplier.SelectedTabPage = ObjTabDetails;
                    else
                    {
                        ObjTabDetails.PageVisible = true;
                        tcSupplier.SelectedTabPage = ObjTabDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// to validate controls 
        /// </summary>
        private void ValidatControls()
        {
            try
            {
                bool isValidSuppFullName = dxValidationProviderSupplierFullName.Validate(txtFullName);
                bool isvalidSuppShortName = dxValidationProviderSupplierSname.Validate(txtShortName);
                bool isvalidEmail = dxValidationProviderSupplierEmail.Validate(txtSupplierEmail);
                if (!isValidSuppFullName || !isvalidSuppShortName || !isvalidEmail)
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

        /// <summary>
        /// to assign supplier values to object
        /// </summary>
        private void ParseSupplierDetails()
        {
            try
            {
                _ObjEsupplier.SupplierFullName = txtFullName.Text;
                _ObjEsupplier.SupplierShortName = txtShortName.Text;
                _ObjEsupplier.Commentary = txtCommentary.Text;
                _ObjEsupplier.PaymentCondition = txtPaymentCondition.Text;
                _ObjEsupplier.SupplierEmailID = txtSupplierEmail.Text;
                _ObjEsupplier.SupplierStreet = txtSupptreet.Text;
                _ObjEsupplier.SupplierTelephone = txtSuppTelephone.Text;
                _ObjEsupplier.SupplierFax = txtSuppFax.Text;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// to assign contact values to object
        /// </summary>
        private void ParseSupplierContactsDetails()
        {
            try
            {
                _ObjEsupplier.Salutation = cmbSalutation.Text;
                _ObjEsupplier.ContactName = txtContactName.Text;
                _ObjEsupplier.Designation = txtDesignation.Text;
                _ObjEsupplier.ContEmailID = txtContactemail.Text;
                _ObjEsupplier.ContTelephone = txtContacttelephone.Text;
                _ObjEsupplier.ContFax = txtContactFax.Text;
                _ObjEsupplier.DefaultContact = Convert.ToBoolean(chkDefaultContact.CheckState);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// to assign address values to data
        /// </summary>
        private void ParseSupplierAddressDetails()
        {
            try
            {
                _ObjEsupplier.AddressShortName = txtAddrShortName.Text;
                _ObjEsupplier.StreetNo = txtAddrStreetNo.Text;
                _ObjEsupplier.AddrPostalCode = txtAddrPostalCode.Text;
                _ObjEsupplier.AddrCity = txtAddrcity.Text;
                _ObjEsupplier.AddrCountry = txtAddrCountry.Text;
                _ObjEsupplier.DefaultAddress = Convert.ToBoolean(chkDefaultAddress.CheckState);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion

        /// <summary>
        /// to restrict blank space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSupplierEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ')
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// to show message in german ie: invalid mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSupplierEmail_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "ungültig mail";
        }

        /// <summary>
        /// to restrict only two lines in control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddrStreetNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                RichTextBox txt=(RichTextBox)sender;
                if (e.KeyCode == Keys.Enter && txt.Lines.Length >= 2)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }





//***************
    }
}