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
using BL;
using EL;

namespace OTTOPro
{
    public partial class frmSelectTextModuleDetails : DevExpress.XtraEditors.XtraForm
    {
        BReportDesign ObjBReportDesign = new BReportDesign();
        EReportDesign ObjEReportDesign = new EReportDesign();
        string _ReportType;

        private string _TextID = null;
        private string _Contents = null;

        public frmSelectTextModuleDetails()
        {
            InitializeComponent();
        }

        public frmSelectTextModuleDetails(string _Type)
        {
            InitializeComponent();
            _ReportType = _Type;
        }

        public string TextID
        {
            get { return _TextID; }
            set { _TextID = value; }
        }
        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }
        private void frmSelectTextModuleDetails_Load(object sender, EventArgs e)
        {
            BindModuleDataByType();
        }

        
        private void BindReportTypes()
        {
            try
            {                
                if (ObjEReportDesign.dsReportDesign != null)
                {
                    gcContentDetails.DataSource = ObjEReportDesign.dsReportDesign.Tables[0];
                    gvContentDetails.BestFitColumns();
                   
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindModuleDataByType()
        {
            try
            {
                switch (_ReportType)
                {
                    case "Proposal Cover Page 1":
                          ObjBReportDesign.GetReportDesignTypes(ObjEReportDesign, "Proposals");
                          BindReportTypes();
                        break;

                    case "Proposal Cover Page 2":

                        break;

                    case "Proposal Main Page 1":

                        break;

                    case "Proposal Main Page 2":

                        break;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvContentDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvContentDetails.GetFocusedRowCellValue("TextID") != DBNull.Value)
                {
                    _TextID = gvContentDetails.GetFocusedRowCellValue("TextID") == DBNull.Value ? "" : gvContentDetails.GetFocusedRowCellValue("TextID").ToString();
                   _Contents= txtcontents.Text = gvContentDetails.GetFocusedRowCellValue("Contents") == DBNull.Value ? "" : gvContentDetails.GetFocusedRowCellValue("Contents").ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            gvContentDetails_FocusedRowChanged(null,null);
        }
//****************
    }
}