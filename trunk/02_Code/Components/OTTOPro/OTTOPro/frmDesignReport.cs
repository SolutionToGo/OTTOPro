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
    public partial class frmDesignReport : DevExpress.XtraEditors.XtraForm
    {
        BReportDesign ObjBReportDesign = new BReportDesign();
        EReportDesign ObjEReportDesign = new EReportDesign();

        public frmDesignReport()
        {
            InitializeComponent();
        }

        private void frmDesignReport_Load(object sender, EventArgs e)
        {
            BindReportTypes();
        }

        private void BindReportTypes()
        {
            try
            {
                ObjBReportDesign.GetReportDesignTypes(ObjEReportDesign,"");
                if (ObjEReportDesign.dsReportDesign != null)
                {
                    cmbReportType.DataSource = null;
                    cmbReportType.DataSource = ObjEReportDesign.dsReportDesign.Tables[0];
                    cmbReportType.DisplayMember = "DesignType";
                    cmbReportType.ValueMember = "DesignID";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbReportType.Text)
                {
                    case "Proposal Cover Page 1":
                        this.Hide();
                        Report_Design.frmProposalCoverPage1 frm = new Report_Design.frmProposalCoverPage1();
                        frm.ShowDialog();

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
                Utility.ShowError(ex);
            }
        }

//************
    }
}