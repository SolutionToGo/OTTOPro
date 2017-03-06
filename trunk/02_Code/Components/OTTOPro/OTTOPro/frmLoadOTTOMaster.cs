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
        EOTTO ObjEOTTO = new EOTTO();
        BOTTO ObjBOTTO = new BOTTO();
        private int _OTTOID = -1;
        private int _ContactID = -1;
        int _IDValue = -1;


        #region CONSTRUCTOR

        public frmLoadOTTOMaster()
        {
            InitializeComponent();
        } 
        #endregion

        #region EVENTS

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
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

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
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }

        }

        private void frmLoadOTTOMaster_Load(object sender, EventArgs e)
        {
            try
            {
                BindOTTOData();
                gvOTTO.BestFitColumns();
                gvOTTOContact.BestFitColumns();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

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
                    ObjEOTTO.IsBranch = Convert.ToBoolean(gvOTTO.GetFocusedRowCellValue("IsBranch") == DBNull.Value ? "" : gvOTTO.GetFocusedRowCellValue("IsBranch"));

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


//********************
    }
}