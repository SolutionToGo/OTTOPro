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

namespace OTTOPro
{
    public partial class frmSelectCustomer : DevExpress.XtraEditors.XtraForm
    {
        ECustomer ObjECustomer = new ECustomer();
        BCustomer ObjBCustomer = new BCustomer();
        private string _CustomerID = null;
        private string _FullName = null;

        public frmSelectCustomer()
        {
            InitializeComponent();
        }

        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        private void frmSelectCustomer_Load(object sender, EventArgs e)
        {
            BindCustomerData();
        }

        public void BindCustomerData()
        {
            try
            {
                ObjBCustomer.GetCustomers(ObjECustomer);
                if (ObjECustomer.dsCustomer != null)
                {
                    gcCustomer.DataSource = ObjECustomer.dsCustomer.Tables[0];
                    gvCustomer.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvCustomer.FocusedColumn != null && gvCustomer.GetFocusedRowCellValue("CustomerID") != null)
                {
                    _CustomerID = gvCustomer.GetFocusedRowCellValue("CustomerID") == DBNull.Value ? "" : gvCustomer.GetFocusedRowCellValue("CustomerID").ToString();
                    _FullName = gvCustomer.GetFocusedRowCellValue("CustomerFullName") == DBNull.Value ? "" : gvCustomer.GetFocusedRowCellValue("CustomerFullName").ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                gvCustomer_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSelectCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                    btnOk_Click(null, null);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
//*****************
    }
}