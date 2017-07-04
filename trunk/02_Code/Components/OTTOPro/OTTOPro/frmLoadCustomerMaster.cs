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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing.Drawing2D;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace OTTOPro
{
    public partial class frmLoadCustomerMaster : DevExpress.XtraEditors.XtraForm
    {
        ECustomer ObjECustomer = new ECustomer();
        BCustomer ObjBCustomer = new BCustomer();
        private int _CustomerID =-1;
        private int _ContactID = -1;
        private int _AddressID = -1;
        int _IDValue = -1;


        #region CONSTRUCTORS

        public frmLoadCustomerMaster()
        {
            InitializeComponent();
        } 
        #endregion

        #region EVENTS

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ObjECustomer = new ECustomer();
                ObjECustomer.Customer_CustomerID = -1;
                frmCustomerMaster frm = new frmCustomerMaster("Customer", ObjECustomer);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {                   
                    BindCustomerData();
                    Setfocus(gvCustomers, "CustomerID",ObjECustomer.Customer_CustomerID);
                    frmOTTOPro.UpdateStatus("Customer data saved successfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CustomerID == -1)
                {
                    if (Utility._IsGermany == true)
                    {
                        throw new Exception("Bitte wählen Sie einen Kunden aus");
                    }
                    else
                    {
                        throw new Exception("Please Select the Customer.!");
                    }
                }
                ObjECustomer = new ECustomer();
                ObjECustomer.ContactPersonID = -1;
                ObjECustomer.Cont_CustomerID = _CustomerID;
                frmCustomerMaster frm = new frmCustomerMaster("Contact", ObjECustomer);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindContactData();
                    Setfocus(gvContacts, "ContactPersonID", ObjECustomer.ContactPersonID);
                    frmOTTOPro.UpdateStatus("Customer contact saved successfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnAddressAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CustomerID == -1)
                {
                    if (Utility._IsGermany == true)
                    {
                        throw new Exception("Bitte wählen Sie einen Kunden aus");
                    }
                    else
                    {
                        throw new Exception("Please Select the Customer.!");
                    }
                }
                ObjECustomer = new ECustomer();
                ObjECustomer.AddressID = -1;
                ObjECustomer.Addr_CustomerID = _CustomerID;
                frmCustomerMaster frm = new frmCustomerMaster("Address", ObjECustomer);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindAddressData();
                    Setfocus(gvAddress, "AddressID", ObjECustomer.AddressID);
                    frmOTTOPro.UpdateStatus("Customer address saved successfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmLoadCustomerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                BindCustomerData();
                gvCustomers.BestFitColumns();
                gvContacts.BestFitColumns();
                gvAddress.BestFitColumns();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvCustomers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int _IDValue = -1;
            try
            {
                if (gvCustomers.FocusedColumn != null && gvCustomers.GetFocusedRowCellValue("CustomerID") != null)
                {
                    if (int.TryParse(gvCustomers.GetFocusedRowCellValue("CustomerID").ToString(), out _IDValue))
                        _CustomerID = _IDValue;
                    ObjBCustomer.GetCustomers(ObjECustomer);
                    memoEditCommentary.Text = gvCustomers.GetFocusedRowCellValue("Commentary") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("Commentary").ToString();

                    DataView dvContact = ObjECustomer.dsCustomer.Tables["Table1"].DefaultView;
                    dvContact.RowFilter = "CustomerID = '" + _CustomerID + "'";
                    gcContacts.DataSource = dvContact;

                    DataView dvAddress = ObjECustomer.dsCustomer.Tables["Table2"].DefaultView;
                    dvAddress.RowFilter = "CustomerID = '" + _CustomerID + "'";
                    gcAddress.DataSource = dvAddress;


                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvCustomers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);

                if (info.InRow || info.InRowCell)
                {
                    if (gvCustomers.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    ObjECustomer = new ECustomer();
                    GetCustomerDetails();
                    frmCustomerMaster frm = new frmCustomerMaster("Customer", ObjECustomer);
                    frm.ObjEcustomer = ObjECustomer;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindCustomerData();
                        Setfocus(gvCustomers, "CustomerID", ObjECustomer.Customer_CustomerID);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvContacts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    if (gvContacts.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    ObjECustomer = new ECustomer();
                    GetContactDetails();
                    frmCustomerMaster frm = new frmCustomerMaster("Contact", ObjECustomer);
                    frm.ObjEcustomer = ObjECustomer;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindContactData();
                        Setfocus(gvContacts, "ContactPersonID", ObjECustomer.ContactPersonID);
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
                    ObjECustomer = new ECustomer();
                    GetAddressDetails();
                    frmCustomerMaster frm = new frmCustomerMaster("Address", ObjECustomer);
                    frm.ObjEcustomer = ObjECustomer;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        BindAddressData();
                        Setfocus(gvAddress, "AddressID", ObjECustomer.AddressID);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        #endregion

        #region METHODS

        public void BindCustomerData()
        {
            try
            {
                ObjBCustomer.GetCustomers(ObjECustomer);
                if (ObjECustomer.dsCustomer != null)
                {
                    gcCustomer.DataSource = ObjECustomer.dsCustomer.Tables[0];
                    gvCustomers.BestFitColumns();
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
                ObjBCustomer.GetCustomers(ObjECustomer);
                if (ObjECustomer.dsCustomer != null)
                {
                    DataView dvContact = ObjECustomer.dsCustomer.Tables["Table1"].DefaultView;
                    dvContact.RowFilter = "CustomerID = '" + _CustomerID + "'";
                    gcContacts.DataSource = dvContact;
                    gvAddress.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BindAddressData()
        {
            try
            {
                ObjBCustomer.GetCustomers(ObjECustomer);
                if (ObjECustomer.dsCustomer != null)
                {
                    DataView dvAddress = ObjECustomer.dsCustomer.Tables["Table2"].DefaultView;
                    dvAddress.RowFilter = "CustomerID = '" + _CustomerID + "'";
                    gcAddress.DataSource = dvAddress;
                    gvAddress.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetCustomerDetails()
        {
            try
            {
                if (gvCustomers.GetFocusedRowCellValue("CustomerID") != DBNull.Value)
                {
                    if (int.TryParse(gvCustomers.GetFocusedRowCellValue("CustomerID").ToString(), out _IDValue))
                        ObjECustomer.Customer_CustomerID = _IDValue;
                    ObjECustomer.CustomerFullName = gvCustomers.GetFocusedRowCellValue("CustomerFullName") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("CustomerFullName").ToString();
                    ObjECustomer.CustomerShortName = gvCustomers.GetFocusedRowCellValue("CustomerShortName") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("CustomerShortName").ToString();
                    ObjECustomer.CustStreet = gvCustomers.GetFocusedRowCellValue("Street") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("Street").ToString();
                    ObjECustomer.CustPostalCode = gvCustomers.GetFocusedRowCellValue("PostalCode") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("PostalCode").ToString();
                    ObjECustomer.CustCity = gvCustomers.GetFocusedRowCellValue("City") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("City").ToString();
                    ObjECustomer.CustCountry = gvCustomers.GetFocusedRowCellValue("Country") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("Country").ToString();
                    ObjECustomer.ILN = gvCustomers.GetFocusedRowCellValue("ILN") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("ILN").ToString();
                    ObjECustomer.Telephone = gvCustomers.GetFocusedRowCellValue("Telephone") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("Telephone").ToString();
                    ObjECustomer.CustFax = gvCustomers.GetFocusedRowCellValue("Fax") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("Fax").ToString();
                    ObjECustomer.CustEmailID = gvCustomers.GetFocusedRowCellValue("EmailID") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("EmailID").ToString();
                    ObjECustomer.CustTaxNumber = gvCustomers.GetFocusedRowCellValue("TaxNumber") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("TaxNumber").ToString();
                    ObjECustomer.BankName = gvCustomers.GetFocusedRowCellValue("BankName") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("BankName").ToString();
                    ObjECustomer.BankPostalCode = gvCustomers.GetFocusedRowCellValue("BankPostalCode") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("BankPostalCode").ToString();
                    ObjECustomer.BankAccountNumber = gvCustomers.GetFocusedRowCellValue("BankAccountNumber") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("BankAccountNumber").ToString();
                    ObjECustomer.DVNr = gvCustomers.GetFocusedRowCellValue("DVNr") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("DVNr").ToString();
                    ObjECustomer.TenderNumber = gvCustomers.GetFocusedRowCellValue("TenderNumber") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("TenderNumber").ToString();
                    ObjECustomer.DebitorNumber = gvCustomers.GetFocusedRowCellValue("DebitorNumber") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("DebitorNumber").ToString();
                    ObjECustomer.CountryType = gvCustomers.GetFocusedRowCellValue("CountryType") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("CountryType").ToString();
                    ObjECustomer.CountryName = gvCustomers.GetFocusedRowCellValue("CountryName") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("CountryName").ToString();
                    ObjECustomer.Commentary = gvCustomers.GetFocusedRowCellValue("Commentary") == DBNull.Value ? "" : gvCustomers.GetFocusedRowCellValue("Commentary").ToString();
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
                if(gvContacts.GetFocusedRowCellValue("ContactPersonID") != DBNull.Value)
                {
                    if (int.TryParse(gvContacts.GetFocusedRowCellValue("CustomerID").ToString(), out _IDValue))
                        ObjECustomer.Cont_CustomerID = _IDValue;
                    _ContactID = ObjECustomer.ContactPersonID = Convert.ToInt32(gvContacts.GetFocusedRowCellValue("ContactPersonID") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("ContactPersonID"));
                    ObjECustomer.Salutation = gvContacts.GetFocusedRowCellValue("Salutation") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("Salutation").ToString();
                    ObjECustomer.ContatPersonName = gvContacts.GetFocusedRowCellValue("ContatPersonName") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("ContatPersonName").ToString();
                    ObjECustomer.Designation = gvContacts.GetFocusedRowCellValue("Designation") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("Designation").ToString();
                    ObjECustomer.ContEmailID = gvContacts.GetFocusedRowCellValue("EmailID") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("EmailID").ToString();
                    ObjECustomer.ContTelephone = gvContacts.GetFocusedRowCellValue("Telephone") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("Telephone").ToString();
                    ObjECustomer.ContFax = gvContacts.GetFocusedRowCellValue("FAX") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("FAX").ToString();
                    ObjECustomer.DefaultContact = Convert.ToBoolean(gvContacts.GetFocusedRowCellValue("DefaultContact") == DBNull.Value ? "" : gvContacts.GetFocusedRowCellValue("DefaultContact"));     
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
                if (gvAddress.GetFocusedRowCellValue("AddressID") !=  DBNull.Value)
                {
                    if (int.TryParse(gvAddress.GetFocusedRowCellValue("CustomerID").ToString(), out _IDValue))
                        ObjECustomer.Addr_CustomerID = _IDValue;
                   _AddressID= ObjECustomer.AddressID = Convert.ToInt32(gvAddress.GetFocusedRowCellValue("AddressID") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("AddressID"));
                    ObjECustomer.AddressShortName = gvAddress.GetFocusedRowCellValue("AddressShortName") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("AddressShortName").ToString();
                    ObjECustomer.StreetNo = gvAddress.GetFocusedRowCellValue("StreetNo") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("StreetNo").ToString();
                    ObjECustomer.AddrPostalCode = gvAddress.GetFocusedRowCellValue("PostalCode") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("PostalCode").ToString();
                    ObjECustomer.AddrCity = gvAddress.GetFocusedRowCellValue("City") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("City").ToString();
                    ObjECustomer.AddrCountry = gvAddress.GetFocusedRowCellValue("Country") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("Country").ToString();
                    ObjECustomer.DefaultAddress = Convert.ToBoolean(gvAddress.GetFocusedRowCellValue("DefaultAddress") == DBNull.Value ? "" : gvAddress.GetFocusedRowCellValue("DefaultAddress"));
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void Setfocus(GridView view, string _id,int _IdValue)
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

        #endregion

        private void frmLoadCustomerMaster_FormClosing(object sender, FormClosingEventArgs e)
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





//*******************
    }
}