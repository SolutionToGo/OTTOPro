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
using EL;
using BL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace OTTOPro
{
    public partial class frmLoadOTTOMaster : DevExpress.XtraEditors.XtraForm
    {
        EOTTO ObjEOTTO = new EOTTO();
        BOTTO ObjBOTTO = new BOTTO();

        public frmLoadOTTOMaster()
        {
            InitializeComponent();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEOTTO == null)
                    ObjEOTTO = new EOTTO();
                ObjEOTTO.ContactID = -1;
                frmOTTOMaster frm = new frmOTTOMaster(ObjEOTTO);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindContactData();
                    Setfocus(gvOTTOContact, "ContactID", ObjEOTTO.ContactID);
                    if (Utility._IsGermany == true)
                        frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der Kontakte zu OTTO Stammdaten");
                    else
                        frmOTTOPro.UpdateStatus("OTTO contact saved successfully");
                }
            }
            catch (Exception ex){Utility.ShowError(ex);}
        }

        private void frmLoadOTTOMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utility.OTTODataAccess == "7")
                {
                    btnAddContact.Enabled = false;
                    btnSave.Enabled = false;
                }
                ObjEOTTO = ObjBOTTO.GetOTTODetails(ObjEOTTO);
                BindOTTOData();
                if (ObjEOTTO.dtOTTO != null && ObjEOTTO.dtOTTO.Rows.Count > 0)
                    cmbOTTO.EditValue = ObjEOTTO.dtOTTO.Rows[0][0];
            }
            catch (Exception ex) { Utility.ShowError(ex); }
        }

        private void gvOTTOContact_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    if (ObjEOTTO == null)
                        ObjEOTTO = new EOTTO();
                    GetContactDetails();
                    frmOTTOMaster frm = new frmOTTOMaster(ObjEOTTO);
                    frm.ObjEOtto = ObjEOTTO;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindContactData();
                        Setfocus(gvOTTOContact, "ContactID", ObjEOTTO.ContactID);
                    }
                }
               
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void BindOTTOData()
        {
            try
            {
                if (ObjEOTTO.dtOTTO != null)
                {
                    cmbOTTO.Properties.DataSource = ObjEOTTO.dtOTTO;
                    cmbOTTO.Properties.DisplayMember = "FullName";
                    cmbOTTO.Properties.ValueMember = "OttoID";
                }
            }
            catch (Exception ex){throw;}
        }

        public void BindContactData()
        {
            try
            {
                DataView dvContact = ObjEOTTO.dtContact.DefaultView;
                dvContact.RowFilter = "OttoID = '" + ObjEOTTO.OTTOID + "'";
                gcOTTOContact.DataSource = dvContact;
            }
            catch (Exception ex){throw;}
        }

        private void Setfocus(GridView view, string _id, int _IdValue)
        {
            try
            {
                if (_IdValue > -1)
                {
                    int rowHandle = view.LocateByValue(_id, _IdValue);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        view.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetContactDetails()
        {
            try
            {
                int IValue = 0;
                if (int.TryParse(gvOTTOContact.GetFocusedRowCellValue("ContactID").ToString(), out IValue))
                {
                    ObjEOTTO.ContactID = IValue;
                    ObjEOTTO.ContactPerson = gvOTTOContact.GetFocusedRowCellValue("ContactPerson") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("ContactPerson").ToString();
                    ObjEOTTO.Cont_Telephone = gvOTTOContact.GetFocusedRowCellValue("Telephone") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("Telephone").ToString();
                    ObjEOTTO.Fax = gvOTTOContact.GetFocusedRowCellValue("Fax") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("Fax").ToString();
                    ObjEOTTO.EmailID = gvOTTOContact.GetFocusedRowCellValue("EmailID") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("EmailID").ToString();
                    ObjEOTTO.TaxNo = gvOTTOContact.GetFocusedRowCellValue("TaxNo") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("TaxNo").ToString();
                    ObjEOTTO.DefaultContact = Convert.ToBoolean(gvOTTOContact.GetFocusedRowCellValue("DefaultContact") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("DefaultContact"));
                }
            }
            catch (Exception ex){throw;}
        }

        private void cmbOTTO_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int IValue = 0;
                if(int.TryParse(Convert.ToString(cmbOTTO.EditValue),out IValue))
                {
                    if (ObjEOTTO == null)
                        ObjEOTTO = new EOTTO();
                    DataRow dr = (cmbOTTO.GetSelectedDataRow() as DataRowView).Row;
                    ObjEOTTO.OTTOID = IValue;

                    txtShortName.Text = Convert.ToString(dr["ShortName"]);
                    txtFullName.Text = Convert.ToString(dr["FullName"]);
                    txtStreet.Text = Convert.ToString(dr["Street"]);
                    txtPostalCode.Text = Convert.ToString(dr["PostalCode"]);
                    txtCity.Text = Convert.ToString(dr["City"]);
                    txtCountry.Text = Convert.ToString(dr["Country"]);
                    txtILN.Text = Convert.ToString(dr["ILN"]);
                    txtBankName.Text = Convert.ToString(dr["BankName"]);
                    txtBankPCode.Text = Convert.ToString(dr["BankPostalCode"]);
                    txtBankAccNo.Text = Convert.ToString(dr["BankAccNo"]);
                    txtDVNr.Text = Convert.ToString(dr["DVNr"]);
                    txtTenderNo.Text = Convert.ToString(dr["TenderNo"]);
                    txtDebtorNo.Text = Convert.ToString(dr["DebtorNo"]);
                    txtCountryType.Text = Convert.ToString(dr["CountryType"]);
                    txtIndustry.Text = Convert.ToString(dr["Industry"]);
                    txtArtBevBew.Text = Convert.ToString(dr["ArtBevBew"]);
                    txtArtNU.Text = Convert.ToString(dr["ArtNU"]);
                    txtBGBez.Text = Convert.ToString(dr["BGBez"]);
                    txtBGDatum.Text = Convert.ToString(dr["BGDatum"]);
                    txtBGNr.Text = Convert.ToString(dr["BGNr"]);
                    txtOTTOTelefone.Text = Convert.ToString(dr["Telefon"]);
                    txtTelefax.Text = Convert.ToString(dr["Telefax"]);
                    txtWebsite.Text = Convert.ToString(dr["Website"]);
                    txtHotline.Text = Convert.ToString(dr["HotLine"]);
                    txtIBAN.Text = Convert.ToString(dr["IBAN"]);
                    txtBIC.Text = Convert.ToString(dr["BIC"]);
                    txtUSTNr.Text = Convert.ToString(dr["USTIDNr"]);
                    txtseatofcompany.Text = Convert.ToString(dr["SeatofCompany"]);
                    txtMD.Text = Convert.ToString(dr["ManagingDirector"]);
                    txtComplementary.Text = Convert.ToString(dr["Complementary"]);
                    checkEditIsBranch.EditValue = Convert.ToBoolean(dr["IsBranch"]);
                    BindContactData();
                }
            }
            catch (Exception ex){Utility.ShowError(ex);}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEOTTO == null)
                    ObjEOTTO = new EOTTO();
                if (ObjBOTTO == null)
                    ObjBOTTO = new BOTTO();
                ParseOTTODetails();
                ObjEOTTO = ObjBOTTO.SaveOTTODetails(ObjEOTTO);
                BindOTTOData();
                cmbOTTO.EditValue = ObjEOTTO.OTTOID;
                if (Utility._IsGermany == true)
                    frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der OTTO Stammdaten");
                else
                    frmOTTOPro.UpdateStatus("OTTO Data saved successfully");
            }
            catch (Exception ex) { Utility.ShowError(ex); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (ObjEOTTO == null)
                ObjEOTTO = new EOTTO();
            ObjEOTTO.OTTOID = -1;
            txtShortName.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtILN.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtBankPCode.Text = string.Empty;
            txtBankAccNo.Text = string.Empty;
            txtDVNr.Text = string.Empty;
            txtTenderNo.Text = string.Empty;
            txtDebtorNo.Text = string.Empty;
            txtCountryType.Text = string.Empty;
            txtIndustry.Text = string.Empty;
            txtArtBevBew.Text = string.Empty;
            txtArtNU.Text = string.Empty;
            txtBGBez.Text = string.Empty;
            txtBGDatum.Text = string.Empty;
            txtBGNr.Text = string.Empty;
            txtOTTOTelefone.Text = string.Empty;
            txtTelefax.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtHotline.Text = string.Empty;
            txtIBAN.Text = string.Empty;
            txtBIC.Text = string.Empty;
            txtUSTNr.Text = string.Empty;
            txtseatofcompany.Text = string.Empty;
            txtMD.Text = string.Empty;
            txtComplementary.Text = string.Empty;
            checkEditIsBranch.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbOTTO_EditValueChanged(null, null);
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
            catch (Exception ex){throw;}
        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            try
            {
                var edit = ((DevExpress.XtraEditors.TextEdit)sender);
                BeginInvoke(new MethodInvoker(() =>
                {
                    edit.SelectionStart = 0;
                    edit.SelectionLength = edit.Text.Length;
                }));
            }
            catch (Exception ex) { }
        }
    }
}