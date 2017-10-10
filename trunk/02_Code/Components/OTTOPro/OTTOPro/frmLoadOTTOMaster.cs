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
using EL;
using BL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace OTTOPro
{
    public partial class frmLoadOTTOMaster : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// private variables to store temp data
        /// </summary>
        EOTTO ObjEOTTO = new EOTTO();
        BOTTO ObjBOTTO = new BOTTO();
        private int _OTTOID = -1;
        private int _ContactID = -1;
        int _IDValue = -1;

        /// <summary>
        /// default constructor
        /// </summary>
        #region CONSTRUCTOR

        public frmLoadOTTOMaster()
        {
            InitializeComponent();
        } 
        #endregion

        #region EVENTS

        /// <summary>
        /// to save OTTO master data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOtto_Click(object sender, EventArgs e)
        {
            try
            {
                ObjEOTTO = new EOTTO();
                ObjEOTTO.OTTOID = -1;
                frmOTTOMaster frm = new frmOTTOMaster("OTTO", ObjEOTTO);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindOTTOData();
                    Setfocus(gvOTTO, "OttoID", ObjEOTTO.OTTOID);
                    if (Utility._IsGermany == true)
                    {
                        frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der OTTO Stammdaten");
                    }
                    else
                    {
                        frmOTTOPro.UpdateStatus("OTTO Data saved successfully");
                    }
                }
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
        private void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (_OTTOID == -1)
                {
                    if (Utility._IsGermany == true)
                    {
                        throw new Exception("Bitte wählen Sie OTTO Detailinformationen");
                    }
                    else
                    {
                        throw new Exception("Please Select the OTTO Details.!");
                    }
                }
                ObjEOTTO = new EOTTO();
                ObjEOTTO.ContactID = -1;
                ObjEOTTO.Cont_OttoID = _OTTOID;
                frmOTTOMaster frm = new frmOTTOMaster("Contact", ObjEOTTO);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindContactData();
                    Setfocus(gvOTTOContact, "ContactID", ObjEOTTO.ContactID);
                    if (Utility._IsGermany == true)
                    {
                        frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der Kontakte zu OTTO Stammdaten");
                    }
                    else
                    {
                        frmOTTOPro.UpdateStatus("OTTO contact saved successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }

        }

        /// <summary>
        /// form load event to bind the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadOTTOMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if(Utility.OTTODataAccess == "7")
                {
                    btnAddContact.Enabled = false;
                    btnAddOtto.Enabled = false;
                }
                BindOTTOData();
                gvOTTO.BestFitColumns();
                gvOTTOContact.BestFitColumns();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// to edit OTTO master data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvOTTO_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);

                if (info.InRow || info.InRowCell)
                {
                    if (gvOTTO.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    ObjEOTTO = new EOTTO();
                    GetOTTODetails();
                    frmOTTOMaster frm = new frmOTTOMaster("OTTO", ObjEOTTO);
                    frm.ObjEOtto = ObjEOTTO;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindOTTOData();
                        Setfocus(gvOTTO, "OttoID", ObjEOTTO.OTTOID);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// to edit contact details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvOTTOContact_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    if (gvOTTOContact.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    ObjEOTTO = new EOTTO();
                    GetContactDetails();
                    frmOTTOMaster frm = new frmOTTOMaster("Contact", ObjEOTTO);
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

        /// <summary>
        /// to bind contact details accoeding to OTTO details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvOTTO_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int _IDValue = -1;
            try
            {
                if (gvOTTO.FocusedColumn != null && gvOTTO.GetFocusedRowCellValue("OttoID") != null)
                {
                    if (int.TryParse(gvOTTO.GetFocusedRowCellValue("OttoID").ToString(), out _IDValue))
                        _OTTOID = _IDValue;
                    ObjBOTTO.GetOTTODetails(ObjEOTTO);

                    DataView dvContact = ObjEOTTO.dsOTTO.Tables["Table1"].DefaultView;
                    dvContact.RowFilter = "OttoID = '" + _OTTOID + "'";
                    gcOTTOContact.DataSource = dvContact;

                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// to bind OTTO master details
        /// </summary>
        public void BindOTTOData()
        {
            try
            {
                ObjBOTTO.GetOTTODetails(ObjEOTTO);
                if (ObjEOTTO.dsOTTO != null)
                {
                    gcOTTO.DataSource = ObjEOTTO.dsOTTO.Tables[0];
                    gvOTTO.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// to bind contact details
        /// </summary>
        public void BindContactData()
        {
            try
            {
                ObjBOTTO.GetOTTODetails(ObjEOTTO);
                if (ObjEOTTO.dsOTTO != null)
                {
                    DataView dvContact = ObjEOTTO.dsOTTO.Tables["Table1"].DefaultView;
                    dvContact.RowFilter = "OttoID = '" + _OTTOID + "'";
                    gcOTTOContact.DataSource = dvContact;
                    gvOTTOContact.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// to set focus on selected row
        /// </summary>
        /// <param name="view"></param>
        /// <param name="_id"></param>
        /// <param name="_IdValue"></param>
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

        /// <summary>
        /// To get otto details for editing existing data
        /// </summary>
        private void GetOTTODetails()
        {
            try
            {
                if (gvOTTO.GetFocusedRowCellValue("OttoID") != DBNull.Value)
                {
                    if (int.TryParse(gvOTTO.GetFocusedRowCellValue("OttoID").ToString(), out _IDValue))
                        ObjEOTTO.OTTOID = _IDValue;
                    ObjEOTTO.ShortName = gvOTTO.GetFocusedRowCellValue("ShortName") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("ShortName").ToString();
                    ObjEOTTO.FullName = gvOTTO.GetFocusedRowCellValue("FullName") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("FullName").ToString();
                    ObjEOTTO.Street = gvOTTO.GetFocusedRowCellValue("Street") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("Street").ToString();
                    ObjEOTTO.PostalCode = gvOTTO.GetFocusedRowCellValue("PostalCode") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("PostalCode").ToString();
                    ObjEOTTO.City = gvOTTO.GetFocusedRowCellValue("City") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("City").ToString();
                    ObjEOTTO.Country = gvOTTO.GetFocusedRowCellValue("Country") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("Country").ToString();
                    ObjEOTTO.ILN = gvOTTO.GetFocusedRowCellValue("ILN") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("ILN").ToString();
                    ObjEOTTO.BankName = gvOTTO.GetFocusedRowCellValue("BankName") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("BankName").ToString();
                    ObjEOTTO.BankPostalCode = gvOTTO.GetFocusedRowCellValue("BankPostalCode") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("BankPostalCode").ToString();
                    ObjEOTTO.BankAccNo = gvOTTO.GetFocusedRowCellValue("BankAccNo") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("BankAccNo").ToString();
                    ObjEOTTO.DVNr = gvOTTO.GetFocusedRowCellValue("DVNr") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("DVNr").ToString();
                    ObjEOTTO.TenderNo = gvOTTO.GetFocusedRowCellValue("TenderNo") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("TenderNo").ToString();
                    ObjEOTTO.DebtorNo = gvOTTO.GetFocusedRowCellValue("DebtorNo") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("DebtorNo").ToString();
                    ObjEOTTO.CountryType = gvOTTO.GetFocusedRowCellValue("CountryType") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("CountryType").ToString();
                    ObjEOTTO.Industry = gvOTTO.GetFocusedRowCellValue("Industry") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("Industry").ToString();
                    ObjEOTTO.ArtBevBew = gvOTTO.GetFocusedRowCellValue("ArtBevBew") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("ArtBevBew").ToString();
                    ObjEOTTO.ArtNU = gvOTTO.GetFocusedRowCellValue("ArtNU") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("ArtNU").ToString();
                    ObjEOTTO.BGBez = gvOTTO.GetFocusedRowCellValue("BGBez") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("BGBez").ToString();
                    ObjEOTTO.BGDatum = gvOTTO.GetFocusedRowCellValue("BGDatum") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("BGDatum").ToString();
                    ObjEOTTO.BGNr = gvOTTO.GetFocusedRowCellValue("BGNr") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("BGNr").ToString();
                    ObjEOTTO.Telefon = gvOTTO.GetFocusedRowCellValue("Telefon") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("Telefon").ToString();
                    ObjEOTTO.Telefax = gvOTTO.GetFocusedRowCellValue("Telefax") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("Telefax").ToString();
                    ObjEOTTO.Website = gvOTTO.GetFocusedRowCellValue("Website") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("Website").ToString();
                    ObjEOTTO.HotLine = gvOTTO.GetFocusedRowCellValue("HotLine") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("HotLine").ToString();
                    ObjEOTTO.IBAN = gvOTTO.GetFocusedRowCellValue("IBAN") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("IBAN").ToString();
                    ObjEOTTO.BIC = gvOTTO.GetFocusedRowCellValue("BIC") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("BIC").ToString();
                    ObjEOTTO.USTIDNr = gvOTTO.GetFocusedRowCellValue("USTIDNr") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("USTIDNr").ToString();
                    ObjEOTTO.SeatofCompany = gvOTTO.GetFocusedRowCellValue("SeatofCompany") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("SeatofCompany").ToString();
                    ObjEOTTO.ManagingDirector = gvOTTO.GetFocusedRowCellValue("ManagingDirector") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("ManagingDirector").ToString();
                    ObjEOTTO.Complementary = gvOTTO.GetFocusedRowCellValue("Complementary") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("Complementary").ToString();
                    ObjEOTTO.IsBranch = Convert.ToBoolean(gvOTTO.GetFocusedRowCellValue("IsBranch") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("IsBranch"));

                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// to get contact details for editing existing data
        /// </summary>
        private void GetContactDetails()
        {
            try
            {
                if (gvOTTOContact.GetFocusedRowCellValue("ContactID") != DBNull.Value)
                {
                    if (int.TryParse(gvOTTOContact.GetFocusedRowCellValue("OttoID").ToString(), out _IDValue))
                        ObjEOTTO.Cont_OttoID = _IDValue;
                    _ContactID = ObjEOTTO.ContactID = Convert.ToInt32(gvOTTOContact.GetFocusedRowCellValue("ContactID") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("ContactID"));
                    ObjEOTTO.ContactPerson = gvOTTOContact.GetFocusedRowCellValue("ContactPerson") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("ContactPerson").ToString();
                    ObjEOTTO.Cont_Telephone = gvOTTOContact.GetFocusedRowCellValue("Telephone") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("Telephone").ToString();
                    ObjEOTTO.Fax = gvOTTOContact.GetFocusedRowCellValue("Fax") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("Fax").ToString();
                    ObjEOTTO.EmailID = gvOTTOContact.GetFocusedRowCellValue("EmailID") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("EmailID").ToString();
                    ObjEOTTO.TaxNo = gvOTTOContact.GetFocusedRowCellValue("TaxNo") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("TaxNo").ToString();
                    ObjEOTTO.DefaultContact = Convert.ToBoolean(gvOTTOContact.GetFocusedRowCellValue("DefaultContact") == DBNull.Value ? "" : gvOTTOContact.GetFocusedRowCellValue("DefaultContact"));
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion

        /// <summary>
        /// form close event to set logo after closing form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoadOTTOMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (frmOTTOPro.Instance.MdiChildren.Count() == 1)
                {
                    frmOTTOPro.Instance.SetPictureBoxVisible(true);
                    frmOTTOPro.Instance.SetLableVisible(true);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


//********************
    }
}