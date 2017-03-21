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
        BSupplier ObjBSupplier = null;
        string _SupplierType = null;
        private ESupplier _ObjEsupplier = null;


        #region CONSTRUCTORS

        public frmSupplierMaster()
        {
            InitializeComponent();
        }

        public frmSupplierMaster(string _Type)
        {
            InitializeComponent();
            _SupplierType = _Type;
        } 
        #endregion


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

        XtraTabPage ObjTabDetails = null;
        private void frmSupplierMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if (_SupplierType == "Supplier")
                {
                    this.Text = "Stammdaten Lieferanten";
                    ObjTabDetails = tbSupplier;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(504, 610);

                }
                if (_SupplierType == "Contact")
                {
                    this.Text = "Lieferantenkontact";
                    ObjTabDetails = tbSupplierContact;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(504, 375);
                }
                if (_SupplierType == "Address")
                {
                    this.Text = "Lieferantenaddresse";
                    ObjTabDetails = tbSupplierAddress;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(504, 350);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        bool _isValidate = true;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatControls();
                if (_isValidate == true)
                {
                    if (_ObjEsupplier == null)
                        _ObjEsupplier = new ESupplier();
                    ParseSupplierDetails();
                    ObjBSupplier = new BSupplier();
                    _ObjEsupplier = ObjBSupplier.SaveSupplierDetails(_ObjEsupplier);
                    this.Close();
                }
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
                    this.Close();
                }
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

        private void txtFullName_TextChanged(object sender, EventArgs e)
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

        #endregion


        #region METHODS

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

        private void BindSupplierDetails()
        {
            try
            {
                txtFullName.Text = _ObjEsupplier.SupplierFullName;
                txtShortName.Text = _ObjEsupplier.SupplierShortName;
                txtCommentary.Text = _ObjEsupplier.Commentary;
                txtPaymentCondition.Text = _ObjEsupplier.PaymentCondition;
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

        private void ValidatControls()
        {
            try
            {
                bool isValidSuppFullName = dxValidationProviderSupplierFullName.Validate(txtFullName);
                bool isvalidSuppShortName = dxValidationProviderSupplierSname.Validate(txtShortName);
                if (!isValidSuppFullName || !isvalidSuppShortName)
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

        private void ParseSupplierDetails()
        {
            try
            {
                _ObjEsupplier.SupplierFullName = txtFullName.Text;
                _ObjEsupplier.SupplierShortName = txtShortName.Text;
                _ObjEsupplier.Commentary = txtCommentary.Text;
                _ObjEsupplier.PaymentCondition = txtPaymentCondition.Text;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

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

//***************
    }
}