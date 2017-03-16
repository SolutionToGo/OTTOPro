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

        DataTable _dtWI = new DataTable();
        DataTable _dtWG = new DataTable();

        public frmLoadSupplier()
        {
            InitializeComponent();
        }

        private void btnAddArticles_Click(object sender, EventArgs e)
        {
            frmSelectArticle frm = new frmSelectArticle();
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
            {
                if (frm.dsArticles != null)
               {
                  _dtWG= frm.dsArticles.Tables[0];

                  foreach (DataRow row in _dtWG.Rows)
                  {
                      gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WG"], row["WG"]);
                      gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WA"], row["WA"]);
                      gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WGDescription"], row["WGDescription"]);

                  }                      
                   //gcArticles.DataSource = frm.dsArticles.Tables[0];
                   //_dtWI = frm.dsArticles.Tables[1];
                   //foreach (DataRow row in _dtWI.Rows)
                   //{
                   //    gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WI"], row["WI"]);
                   //    // gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.FocusedColumn, row["WIDescription"]);
                   //}                  

                  gcArticles.DataSource = _dtWG;
                   gvArticles.BestFitColumns();
               }

            }
        }

        private void gvArticles_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvArticles.FocusedColumn != null && gvArticles.GetFocusedRowCellValue("WG") != null)
            {
                txtWGDescription.Text = gvArticles.GetFocusedRowCellValue("WGDescription") == DBNull.Value ? "" : gvArticles.GetFocusedRowCellValue("WGDescription").ToString();
              //  txtWIDescription.Text = gvArticles.GetFocusedRowCellValue("WIDescription") == DBNull.Value ? "" : gvArticles.GetFocusedRowCellValue("WIDescription").ToString();
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                ObjESupplier = new ESupplier();
                ObjESupplier.SupplierID = -1;
                frmSupplierMaster frm = new frmSupplierMaster("Supplier", ObjESupplier);
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
                ObjBSupplier.GetSupplier(ObjESupplier);
                if (ObjESupplier.dsSupplier != null)
                {
                    gcSupplier.DataSource = ObjESupplier.dsSupplier.Tables[0];
                    gvSupplier.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
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
                ObjESupplier = new ESupplier();
                ObjESupplier.ContactPersonID = -1;
                ObjESupplier.Cont_supplierID = _SupplierID;
                frmSupplierMaster frm = new frmSupplierMaster("Contact", ObjESupplier);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindContactData();
                    Setfocus(gvContact, "ContactPersonID", ObjESupplier.ContactPersonID);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        public void BindContactData()
        {
            try
            {
                ObjBSupplier.GetSupplier(ObjESupplier);
                if (ObjESupplier.dsSupplier != null)
                {
                    DataView dvContact = ObjESupplier.dsSupplier.Tables["Table1"].DefaultView;
                    dvContact.RowFilter = "SupplierID = '" + _SupplierID + "'";
                    gcContact.DataSource = dvContact;
                    gvAddress.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
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
                ObjESupplier = new ESupplier();
                ObjESupplier.AddressID = -1;
                ObjESupplier.Addr_supplierID = _SupplierID;
                frmSupplierMaster frm = new frmSupplierMaster("Address", ObjESupplier);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindAddressData();
                    Setfocus(gvAddress, "AddressID", ObjESupplier.AddressID);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void BindAddressData()
        {
            try
            {
                ObjBSupplier.GetSupplier(ObjESupplier);
                if (ObjESupplier.dsSupplier != null)
                {
                    DataView dvAddress = ObjESupplier.dsSupplier.Tables["Table2"].DefaultView;
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
                    ObjESupplier = new ESupplier();
                    GetSupplierDetails();
                    frmSupplierMaster frm = new frmSupplierMaster("Supplier", ObjESupplier);
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
                    ObjESupplier.AddressShortName = gvAddress.GetFocusedRowCellValue("AddressShortName") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("AddressShortName").ToString();
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
                    ObjESupplier = new ESupplier();
                    GetContactDetails();
                    frmSupplierMaster frm = new frmSupplierMaster("Contact", ObjESupplier);
                    frm.ObjEsupplier = ObjESupplier;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindContactData();
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
                    ObjESupplier = new ESupplier();
                    GetAddressDetails();
                    frmSupplierMaster frm = new frmSupplierMaster("Address", ObjESupplier);
                    frm.ObjEsupplier = ObjESupplier;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindAddressData();
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
                        _SupplierID = _IDValue;
                    ObjBSupplier.GetSupplier(ObjESupplier);
                    memoEditCommentary.Text = gvSupplier.GetFocusedRowCellValue("Commentary") == DBNull.Value ? "" : gvSupplier.GetFocusedRowCellValue("Commentary").ToString();

                    DataView dvContact = ObjESupplier.dsSupplier.Tables["Table1"].DefaultView;
                    dvContact.RowFilter = "SupplierID = '" + _SupplierID + "'";
                    gcContact.DataSource = dvContact;

                    DataView dvAddress = ObjESupplier.dsSupplier.Tables["Table2"].DefaultView;
                    dvAddress.RowFilter = "SupplierID = '" + _SupplierID + "'";
                    gcAddress.DataSource = dvAddress;


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