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
        ESupplier ObjESupplier = null;
        BSupplier ObjBSupplier = null;
        string _SupplierType = null;
        private ESupplier _ObjEsupplier = null;


        #region CONSTRUCTORS

        public frmSupplierMaster()
        {
            InitializeComponent();
        }

        public frmSupplierMaster(string _Type, ESupplier ObjESupplier1)
        {
            InitializeComponent();
            _SupplierType = _Type;
            ObjESupplier = ObjESupplier1;
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
                if (_SupplierType == "Supplier")
                    BindSupplierDetails();
                if (_SupplierType == "Contact")
                    BindContactsDetails();
                if (_SupplierType == "Address")
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
                    if (ObjESupplier == null)
                        ObjESupplier = new ESupplier();
                    ParseSupplierDetails();
                    ObjBSupplier = new BSupplier();
                    ObjESupplier.SupplierID = ObjBSupplier.SaveSupplierDetails(ObjESupplier);
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
                    if (ObjESupplier == null)
                        ObjESupplier = new ESupplier();
                    ParseSupplierContactsDetails();
                    ObjBSupplier = new BSupplier();
                    ObjESupplier.ContactPersonID = ObjBSupplier.SaveSupplierContactDetails(ObjESupplier);
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
                    if (ObjESupplier == null)
                        ObjESupplier = new ESupplier();
                    ParseSupplierAddressDetails();
                    ObjBSupplier = new BSupplier();
                    ObjESupplier.AddressID = ObjBSupplier.SaveSupplierAddressDetails(ObjESupplier);
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
                txtFullName.Text = ObjESupplier.SupplierFullName;
                txtShortName.Text = ObjESupplier.SupplierShortName;
                txtCommentary.Text = ObjESupplier.Commentary;
                txtPaymentCondition.Text = ObjESupplier.PaymentCondition;
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
                cmbSalutation.Text = ObjESupplier.Salutation;
                txtContactName.Text = ObjESupplier.ContactName;
                txtDesignation.Text = ObjESupplier.Designation;
                txtContactemail.Text = ObjESupplier.ContEmailID;
                txtContacttelephone.Text = ObjESupplier.ContTelephone;
                txtContactFax.Text = ObjESupplier.ContFax;
                chkDefaultContact.EditValue = ObjESupplier.DefaultContact;
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
                txtAddrShortName.Text = ObjESupplier.AddressShortName;
                txtAddrStreetNo.Text = ObjESupplier.StreetNo;
                txtAddrPostalCode.Text = ObjESupplier.AddrPostalCode;
                txtAddrcity.Text = ObjESupplier.AddrCity;
                txtAddrCountry.Text = ObjESupplier.AddrCountry;
                chkDefaultAddress.EditValue = ObjESupplier.DefaultAddress;
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
                ObjESupplier.SupplierFullName = txtFullName.Text;
                ObjESupplier.SupplierShortName = txtShortName.Text;
                ObjESupplier.Commentary = txtCommentary.Text;
                ObjESupplier.PaymentCondition = txtPaymentCondition.Text;
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
                ObjESupplier.Salutation = cmbSalutation.Text;
                ObjESupplier.ContactName = txtContactName.Text;
                ObjESupplier.Designation = txtDesignation.Text;
                ObjESupplier.ContEmailID = txtContactemail.Text;
                ObjESupplier.ContTelephone = txtContacttelephone.Text;
                ObjESupplier.ContFax = txtContactFax.Text;
                ObjESupplier.DefaultContact = Convert.ToBoolean(chkDefaultContact.CheckState);
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
                ObjESupplier.AddressShortName = txtAddrShortName.Text;
                ObjESupplier.StreetNo = txtAddrStreetNo.Text;
                ObjESupplier.AddrPostalCode = txtAddrPostalCode.Text;
                ObjESupplier.AddrCity = txtAddrcity.Text;
                ObjESupplier.AddrCountry = txtAddrCountry.Text;
                ObjESupplier.DefaultAddress = Convert.ToBoolean(chkDefaultAddress.CheckState);
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