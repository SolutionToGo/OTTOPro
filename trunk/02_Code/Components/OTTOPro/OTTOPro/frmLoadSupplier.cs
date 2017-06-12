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
using DevExpress.XtraGrid.Columns;
using BL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace OTTOPro
{
    public partial class frmLoadSupplier : System.Windows.Forms.Form
    {
        EArticles ObjEArticles = new EArticles();
        ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = new BSupplier();
        private int _SupplierID = -1;
        private int _ContactID = -1;
        private int _AddressID = -1;
        int _IDValue = -1;
        private bool _IsSave = false;
        private bool _IsSaveDimension = false;


        #region CONSTRUCTOR

        public frmLoadSupplier()
        {
            InitializeComponent();
        } 
        #endregion

        #region EVENTS
        private void btnAddArticles_Click(object sender, EventArgs e)
        {
            try
            {
                if (_IsSaveDimension)
                    throw new Exception("Bitte Speichern der Maße");

                if (ObjESupplier == null)
                    ObjESupplier = new ESupplier();
                if(_IsSave)
                {
                    int RowHandle = gvArticles.FocusedRowHandle;
                    GetArticleDetails(RowHandle);
                }
                ObjESupplier.WGWAID = -1;
                ObjESupplier.SupplierID = _SupplierID;
                if (ObjESupplier.dtArticle != null)
                {
                    DataView dvArticle = ObjESupplier.dtArticle.DefaultView;
                    dvArticle.RowFilter = "SupplierID = '" + _SupplierID + "'";
                    DataRowView rowView = dvArticle.AddNew();
                    rowView["WGWAID"] = "-1";
                    rowView["SupplierID"] = _SupplierID;
                    rowView["WG"] = "";
                    rowView["WA"] = "";
                    rowView["WGDescription"] = "";
                    rowView.EndEdit();
                    gcArticles.DataSource = dvArticle;
                    gvArticles.BestFitColumns();
                    _IsSaveDimension = true;

                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjESupplier == null)
                    ObjESupplier = new ESupplier();
                ObjESupplier.SupplierID = -1;
                frmSupplierMaster frm = new frmSupplierMaster("Supplier");
                frm.ObjEsupplier = ObjESupplier;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindSupplierData();
                    Setfocus(gvSupplier, "SupplierID", ObjESupplier.SupplierID);
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
                if (_SupplierID == -1)
                {
                    if (Utility._IsGermany == true)
                    {
                        // throw new Exception("Bitte wählen Sie einen Kunden aus");
                    }
                    else
                    {
                        throw new Exception("Please Select the Supplier.!");
                    }
                }
                if (ObjESupplier == null)
                    ObjESupplier = new ESupplier();
                ObjESupplier.ContactPersonID = -1;
                ObjESupplier.Cont_supplierID = _SupplierID;
                frmSupplierMaster frm = new frmSupplierMaster("Contact");
                frm.ObjEsupplier = ObjESupplier;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindContactData(_SupplierID);
                    Setfocus(gvContact, "ContactPersonID", ObjESupplier.ContactPersonID);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SupplierID == -1)
                {
                    if (Utility._IsGermany == true)
                    {
                        // throw new Exception("Bitte wählen Sie einen Kunden aus");
                    }
                    else
                    {
                        throw new Exception("Please Select the Supplier.!");
                    }
                }
                if (ObjESupplier == null)
                    ObjESupplier = new ESupplier();
                ObjESupplier.AddressID = -1;
                ObjESupplier.Addr_supplierID = _SupplierID;
                frmSupplierMaster frm = new frmSupplierMaster("Address");
                frm.ObjEsupplier = ObjESupplier;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindAddressData(_SupplierID);
                    Setfocus(gvAddress, "AddressID", ObjESupplier.AddressID);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);

                if (info.InRow || info.InRowCell)
                {
                    if (gvSupplier.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    if (ObjESupplier == null)
                        ObjESupplier = new ESupplier();
                    GetSupplierDetails();
                    frmSupplierMaster frm = new frmSupplierMaster("Supplier");
                    frm.ObjEsupplier = ObjESupplier;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindSupplierData();
                        Setfocus(gvSupplier, "SupplierID", ObjESupplier.SupplierID);
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvContact_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    if (gvContact.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    if (ObjESupplier == null)
                        ObjESupplier = new ESupplier();
                    GetContactDetails();
                    frmSupplierMaster frm = new frmSupplierMaster("Contact");
                    frm.ObjEsupplier = ObjESupplier;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindContactData(_SupplierID);
                        Setfocus(gvContact, "ContactPersonID", ObjESupplier.ContactPersonID);
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvAddress_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);

                if (info.InRow || info.InRowCell)
                {
                    if (gvAddress.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    if (ObjESupplier == null)
                        ObjESupplier = new ESupplier();
                    GetAddressDetails();
                    frmSupplierMaster frm = new frmSupplierMaster("Address");
                    frm.ObjEsupplier = ObjESupplier;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindAddressData(_SupplierID);
                        Setfocus(gvAddress, "AddressID", ObjESupplier.AddressID);
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int _IDValue = -1;
            try
            {
                if (gvSupplier.FocusedColumn != null && gvSupplier.GetFocusedRowCellValue("SupplierID") != null)
                {
                    if (int.TryParse(gvSupplier.GetFocusedRowCellValue("SupplierID").ToString(), out _IDValue))
                    {
                        _SupplierID = _IDValue;
                        memoEditCommentary.Text = gvSupplier.GetFocusedRowCellValue("Commentary") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("Commentary").ToString();
                        memoEditPaymentConditions.Text = gvSupplier.GetFocusedRowCellValue("PaymentCondition") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("PaymentCondition").ToString();
                        BindContactData(_IDValue);
                        BindAddressData(_IDValue);
                        BindArticleData(_IDValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmLoadSupplier_Load(object sender, EventArgs e)
        {
            ObjESupplier = ObjBSupplier.GetSupplier(ObjESupplier);
            BindSupplierData();
            gvSupplier.BestFitColumns();
            gvContact.BestFitColumns();
            gvAddress.BestFitColumns();
        }

        private void gvArticles_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!_IsSave)
                _IsSave = true;
        }

        private void gvArticles_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //try
            //{
            //    int RowHandle = e.RowHandle;
            //    GetArticleDetails(RowHandle);
            //}
            //catch (Exception ex)
            //{
            //    Utility.ShowError(ex);
            //}
        }

        private void gcArticles_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                GridControl grid = sender as GridControl;
                gvArticles_KeyPress(grid.FocusedView, e);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvArticles_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    int RowHandle = gvArticles.FocusedRowHandle;
                    GetArticleDetails(RowHandle);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        #endregion

        #region METHODS

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

        public void BindSupplierData()
        {
            try
            {
                if (ObjESupplier.dtSupplier != null)
                {
                    gcSupplier.DataSource = ObjESupplier.dtSupplier;
                    gvSupplier.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BindContactData(int SupplierID)
        {
            try
            {
                if (ObjESupplier.dtContact != null)
                {
                    DataView dvContact = ObjESupplier.dtContact.DefaultView;
                    dvContact.RowFilter = "SupplierID = '" + SupplierID + "'";
                    gcContact.DataSource = dvContact;
                    gvContact.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BindAddressData(int SuplierID)
        {
            try
            {
                if (ObjESupplier.dtAddress != null)
                {
                    DataView dvAddress = ObjESupplier.dtAddress.DefaultView;
                    dvAddress.RowFilter = "SupplierID = '" + _SupplierID + "'";
                    gcAddress.DataSource = dvAddress;
                    gvAddress.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindArticleData(int SuplierID)
        {
            try
            {
                if (ObjESupplier.dtArticle != null)
                {
                    DataView dvArticle = ObjESupplier.dtArticle.DefaultView;
                    dvArticle.RowFilter = "SupplierID = '" + SuplierID + "'";
                    gcArticles.DataSource = dvArticle;
                    gvArticles.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetSupplierDetails()
        {
            try
            {
                if (gvSupplier.GetFocusedRowCellValue("SupplierID") != DBNull.Value)
                {
                    if (int.TryParse(gvSupplier.GetFocusedRowCellValue("SupplierID").ToString(), out _IDValue))
                        ObjESupplier.SupplierID = _IDValue;
                    ObjESupplier.SupplierFullName = gvSupplier.GetFocusedRowCellValue("FullName") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("FullName").ToString();
                    ObjESupplier.SupplierShortName = gvSupplier.GetFocusedRowCellValue("ShortName") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("ShortName").ToString();
                    ObjESupplier.Commentary = gvSupplier.GetFocusedRowCellValue("Commentary") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("Commentary").ToString();
                    ObjESupplier.PaymentCondition = gvSupplier.GetFocusedRowCellValue("PaymentCondition") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("PaymentCondition").ToString();
                    ObjESupplier.SupplierEmailID = gvSupplier.GetFocusedRowCellValue("EmailID") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("EmailID").ToString();

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
                if (gvContact.GetFocusedRowCellValue("ContactPersonID") != DBNull.Value)
                {
                    if (int.TryParse(gvContact.GetFocusedRowCellValue("SupplierID").ToString(), out _IDValue))
                        ObjESupplier.Cont_supplierID = _IDValue;
                    _ContactID = ObjESupplier.ContactPersonID = Convert.ToInt32(gvContact.GetFocusedRowCellValue("ContactPersonID") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("ContactPersonID"));
                    ObjESupplier.Salutation = gvContact.GetFocusedRowCellValue("Salutation") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("Salutation").ToString();
                    ObjESupplier.ContactName = gvContact.GetFocusedRowCellValue("ContactName") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("ContactName").ToString();
                    ObjESupplier.Designation = gvContact.GetFocusedRowCellValue("Designation") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("Designation").ToString();
                    ObjESupplier.ContEmailID = gvContact.GetFocusedRowCellValue("EmailID") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("EmailID").ToString();
                    ObjESupplier.ContTelephone = gvContact.GetFocusedRowCellValue("Telephone") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("Telephone").ToString();
                    ObjESupplier.ContFax = gvContact.GetFocusedRowCellValue("FAX") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("FAX").ToString();
                    ObjESupplier.DefaultContact = Convert.ToBoolean(gvContact.GetFocusedRowCellValue("DefaultContact") == DBNull.Value ? "" : gvContact.GetFocusedRowCellValue("DefaultContact"));
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void GetAddressDetails()
        {
            try
            {
                if (gvAddress.GetFocusedRowCellValue("AddressID") != DBNull.Value)
                {
                    if (int.TryParse(gvAddress.GetFocusedRowCellValue("SupplierID").ToString(), out _IDValue))
                        ObjESupplier.Addr_supplierID = _IDValue;
                    _AddressID = ObjESupplier.AddressID = Convert.ToInt32(gvAddress.GetFocusedRowCellValue("AddressID") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("AddressID"));
                    ObjESupplier.AddressShortName = gvAddress.GetFocusedRowCellValue("ShortName") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("ShortName").ToString();
                    ObjESupplier.StreetNo = gvAddress.GetFocusedRowCellValue("StreetNo") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("StreetNo").ToString();
                    ObjESupplier.AddrPostalCode = gvAddress.GetFocusedRowCellValue("PostalCode") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("PostalCode").ToString();
                    ObjESupplier.AddrCity = gvAddress.GetFocusedRowCellValue("City") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("City").ToString();
                    ObjESupplier.AddrCountry = gvAddress.GetFocusedRowCellValue("Country") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("Country").ToString();
                    ObjESupplier.DefaultAddress = Convert.ToBoolean(gvAddress.GetFocusedRowCellValue("DefaultAddress") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("DefaultAddress"));
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void GetArticleDetails(int RowHandle)
        {
            if (!_IsSave)
                return;
            try
            {
                ObjESupplier.WGWAID = Convert.ToInt32(gvArticles.GetRowCellValue(RowHandle, "WGWAID"));
                ObjESupplier.WG = gvArticles.GetRowCellValue(RowHandle,"WG") == DBNull.Value ? "" : gvArticles.GetRowCellValue(RowHandle,"WG").ToString();
                ObjESupplier.WA = gvArticles.GetRowCellValue(RowHandle, "WA") == DBNull.Value ? "" : gvArticles.GetRowCellValue(RowHandle, "WA").ToString();
                ObjESupplier.WGDescription = gvArticles.GetRowCellValue(RowHandle, "WGDescription") == DBNull.Value ? "" : gvArticles.GetRowCellValue(RowHandle, "WGDescription").ToString();
                ObjESupplier.SupplierID = _SupplierID;
                ObjBSupplier.SaveArticle(ObjESupplier);
                _IsSaveDimension = false;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ObjBSupplier.GetSupplier(ObjESupplier);
                BindArticleData(_SupplierID);
                Setfocus(gvArticles, "WGWAID", ObjESupplier.WGWAID);
                _IsSave = false;
            }
        }

        #endregion
    }
}