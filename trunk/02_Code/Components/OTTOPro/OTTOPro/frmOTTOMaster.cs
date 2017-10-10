﻿using System;
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
        /// <summary>
        /// private variables to store temp data
        /// </summary>
        EOTTO ObjEOTTO = null;
        BOTTO ObjBOTTO = null;
        string _type = null;
        private EOTTO _ObjEOTTO = null;
        bool _isValidate = false;

        /// <summary>
        /// to assign the values in different forms
        /// </summary>
 
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
        /// <summary>
        /// default constructor
        /// </summary>
        public frmOTTOMaster()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parametrised constructor to get type and values
        /// </summary>
        /// <param name="_Type"></param>
        /// <param name="ObjEOTTO1"></param>
        public frmOTTOMaster(string _Type, EOTTO ObjEOTTO1)
        {
            InitializeComponent();
            _type = _Type;
            ObjEOTTO = ObjEOTTO1;
        } 
        #endregion

        #region EVENTS

        /// <summary>
        /// form load event
        /// </summary>
        XtraTabPage ObjTabDetails = null;
        private void frmOTTOMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if(Utility.OTTODataAccess == "7")
                {
                    btnSaveContact.Enabled = false;
                    btnSaveOtto.Enabled = false;
                }
                if (_type == "OTTO")
                {
                    this.Text = "OTTO Firmendaten";
                    ObjTabDetails = tbOTTO;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(658, 669);
                }
                if (_type == "Contact")
                {
                    this.Text = "OTTO Kontaktdaten";
                    ObjTabDetails = tbContact;
                    TabChange(ObjTabDetails);
                    this.MinimumSize = new System.Drawing.Size(470, 300);
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

        /// <summary>
        /// form cancel event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelOtto_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// to save OTTO master details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveOtto_Click(object sender, EventArgs e)
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
                //ValidatControls();
                //if (_isValidate == true)
                //{
                    if (ObjEOTTO == null)
                        ObjEOTTO = new EOTTO();
                    ParseOTTODetails();
                    ObjBOTTO = new BOTTO();
                    ObjEOTTO.OTTOID = ObjBOTTO.SaveOTTODetails(ObjEOTTO);
                    _isValidate = true;
                //}                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// to save contact details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtContactPerson.Text.Trim()))
                {
                    _isValidate = false;
                    throw new Exception("Bitte eingeben Name");
                }
                bool isvalidName = dxValidationProviderContName.Validate(txtContactPerson);
                if (!isvalidName)
                { _isValidate = false; }
                else
                {
                    _isValidate = true;
                }
                if (_isValidate == true)
                if (ObjEOTTO == null)
                    ObjEOTTO = new EOTTO();
                ParseOTTOContactsDetails();
                ObjBOTTO = new BOTTO();
                ObjEOTTO.ContactID = ObjBOTTO.SaveOTTOContactDetails(ObjEOTTO);
                _isValidate = true;
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
        private void frmOTTOMaster_FormClosing(object sender, FormClosingEventArgs e)
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
        /// changing the tab according to type
        /// </summary>
        /// <param name="ObjTabDetails"></param>
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

        /// <summary>
        /// assigning the OTTO master details to object
        /// </summary>
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
                ObjEOTTO.Telefon = txtOTTOTelefone.Text;
                ObjEOTTO.Telefax = txtTelefax.Text;
                ObjEOTTO.Website = txtWebsite.Text;
                ObjEOTTO.HotLine = txtHotline.Text;
                ObjEOTTO.IBAN = txtIBAN.Text;
                ObjEOTTO.BIC = txtBIC.Text;
                ObjEOTTO.USTIDNr = txtUSTNr.Text;
                ObjEOTTO.SeatofCompany = txtseatofcompany.Text;
                ObjEOTTO.ManagingDirector = txtMD.Text;
                ObjEOTTO.Complementary = txtComplementary.Text;
                ObjEOTTO.IsBranch = Convert.ToBoolean(checkEditIsBranch.CheckState);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// assigning contact values to object
        /// </summary>
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

        /// <summary>
        /// binding OTTO master values to textboxes
        /// </summary>
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
                txtOTTOTelefone.Text =ObjEOTTO.Telefon;
                txtTelefax.Text=ObjEOTTO.Telefax;
                txtWebsite.Text=ObjEOTTO.Website;
                txtHotline.Text =ObjEOTTO.HotLine;
                txtIBAN.Text =ObjEOTTO.IBAN;
                txtBIC.Text =ObjEOTTO.BIC;
                txtUSTNr.Text =ObjEOTTO.USTIDNr;
                txtseatofcompany.Text =ObjEOTTO.SeatofCompany;
                txtMD.Text =ObjEOTTO.ManagingDirector;
                txtComplementary.Text =ObjEOTTO.Complementary;

                checkEditIsBranch.EditValue = Convert.ToBoolean(ObjEOTTO.IsBranch);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// binding contact values to textboxes
        /// </summary>
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

        /// <summary>
        /// validating the controls
        /// </summary>
        private void ValidatControls()
        {
            try
            {
                bool isValidtFullName = dxValidationProviderFullName.Validate(txtFullName);
                bool isvalidShortName = dxValidationProviderShortName.Validate(txtShortName);
                if (!isValidtFullName || !isvalidShortName)
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





//*******************
    }
}