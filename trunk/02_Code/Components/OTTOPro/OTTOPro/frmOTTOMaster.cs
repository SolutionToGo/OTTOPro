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
    public partial class frmOTTOMaster : DevExpress.XtraEditors.XtraForm
    {
        EOTTO ObjEOTTO = null;
        BOTTO ObjBOTTO = null;
        string _type = null;
        private EOTTO _ObjEOTTO = null;

        #region PROPERTY SETTING

        public EOTTO ObjEOtto
        {
            get
            {
                return _ObjEOTTO;
            }
            set
            {
                _ObjEOTTO = value;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public frmOTTOMaster()
        {
            InitializeComponent();
        }

        public frmOTTOMaster(string _Type, EOTTO ObjEOTTO1)
        {
            InitializeComponent();
            _type = _Type;
            ObjEOTTO = ObjEOTTO1;
        } 
        #endregion

        #region EVENTS

        XtraTabPage ObjTabDetails = null;
        private void frmOTTOMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if (_type == "OTTO")
                {
                    this.Text = "OTTO Master";
                    ObjTabDetails = tbOTTO;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(731, 593);
                }
                if (_type == "Contact")
                {
                    this.Text = "OTTO Contact";
                    ObjTabDetails = tbContact;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(470, 340);
                }
                if (_type == "OTTO")
                    BindOTTODetails();
                if (_type == "Contact")
                    BindContactsDetails();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancelOtto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveOtto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEOTTO == null)
                    ObjEOTTO = new EOTTO();
                ParseOTTODetails();
                ObjBOTTO = new BOTTO();
                ObjEOTTO.OTTOID = ObjBOTTO.SaveOTTODetails(ObjEOTTO);
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
                if (ObjEOTTO == null)
                    ObjEOTTO = new EOTTO();
                ParseOTTOContactsDetails();
                ObjBOTTO = new BOTTO();
                ObjEOTTO.ContactID = ObjBOTTO.SaveOTTOContactDetails(ObjEOTTO);
                this.Close();
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


        #endregion

        #region METHODS

        private void TabChange(XtraTabPage ObjTabDetails)
        {
            try
            {
                if (ObjTabDetails != null)
                {
                    if (ObjTabDetails.PageVisible == true)
                        tcOTTO.SelectedTabPage = ObjTabDetails;
                    else
                    {
                        ObjTabDetails.PageVisible = true;
                        tcOTTO.SelectedTabPage = ObjTabDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ParseOTTODetails()
        {
            try
            {
                ObjEOTTO.ShortName = txtShortName.Text;
                ObjEOTTO.FullName = txtFullName.Text;
                ObjEOTTO.Street = txtStreet.Text;
                ObjEOTTO.PostalCode = txtPostalCode.Text;
                ObjEOTTO.City = txtCity.Text;
                ObjEOTTO.Country = txtCountry.Text;
                ObjEOTTO.ILN = txtILN.Text;
                ObjEOTTO.BankName = txtBankName.Text;
                ObjEOTTO.BankPostalCode = txtBankPCode.Text;
                ObjEOTTO.BankAccNo = txtBankAccNo.Text;
                ObjEOTTO.DVNr = txtDVNr.Text;
                ObjEOTTO.TenderNo = txtTenderNo.Text;
                ObjEOTTO.DebtorNo = txtDebtorNo.Text;
                ObjEOTTO.CountryType = txtCountryType.Text;
                ObjEOTTO.Industry = txtIndustry.Text;
                ObjEOTTO.ArtBevBew = txtArtBevBew.Text;
                ObjEOTTO.ArtNU = txtArtNU.Text;
                ObjEOTTO.BGBez = txtBGBez.Text;
                ObjEOTTO.BGDatum = txtBGDatum.Text;
                ObjEOTTO.BGNr = txtBGNr.Text;
                ObjEOTTO.IsBranch = Convert.ToBoolean(checkEditIsBranch.CheckState);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void ParseOTTOContactsDetails()
        {
            try
            {
                ObjEOTTO.ContactPerson = txtContactPerson.Text;
                ObjEOTTO.Cont_Telephone = txtTelephone.Text;
                ObjEOTTO.Fax = txtFax.Text;
                ObjEOTTO.EmailID = txtemail.Text;
                ObjEOTTO.TaxNo = txtTaxNo.Text;
                ObjEOTTO.DefaultContact = Convert.ToBoolean(checkEditDefaultContact.CheckState);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void BindOTTODetails()
        {
            try
            {
                txtShortName.Text = ObjEOTTO.ShortName;
                txtFullName.Text = ObjEOTTO.FullName;
                txtStreet.Text = ObjEOTTO.Street;
                txtPostalCode.Text = ObjEOTTO.PostalCode;
                txtCity.Text = ObjEOTTO.City;
                txtCountry.Text = ObjEOTTO.Country;
                txtILN.Text = ObjEOTTO.ILN;
                txtBankName.Text = ObjEOTTO.BankName;
                txtBankPCode.Text = ObjEOTTO.BankPostalCode;
                txtBankAccNo.Text = ObjEOTTO.BankAccNo;
                txtDVNr.Text = ObjEOTTO.DVNr;
                txtTenderNo.Text = ObjEOTTO.TenderNo;
                txtDebtorNo.Text = ObjEOTTO.DebtorNo;
                txtCountryType.Text = ObjEOTTO.CountryType;
                txtIndustry.Text = ObjEOTTO.Industry;
                txtArtBevBew.Text = ObjEOTTO.ArtBevBew;
                txtArtNU.Text = ObjEOTTO.ArtNU;
                txtBGBez.Text = ObjEOTTO.BGBez;
                txtBGDatum.Text = ObjEOTTO.BGDatum;
                txtBGNr.Text = ObjEOTTO.BGNr;
                checkEditIsBranch.EditValue = Convert.ToBoolean(ObjEOTTO.IsBranch);
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
                txtContactPerson.Text = ObjEOTTO.ContactPerson;
                txtTelephone.Text = ObjEOTTO.Cont_Telephone;
                txtFax.Text = ObjEOTTO.Fax;
                txtemail.Text = ObjEOTTO.EmailID;
                txtTaxNo.Text = ObjEOTTO.TaxNo;
                checkEditDefaultContact.EditValue = ObjEOTTO.DefaultContact;
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