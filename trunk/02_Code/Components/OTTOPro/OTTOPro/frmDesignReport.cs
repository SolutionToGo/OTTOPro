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
using DevExpress.XtraReports.UI;

namespace OTTOPro
{
    public partial class frmDesignReport : DevExpress.XtraEditors.XtraForm
    {
        BReportDesign ObjBReportDesign = new BReportDesign();
        EReportDesign ObjEReportDesign = new EReportDesign();

        string _ViewType;
        int _Projectid;
        int _Customerid;
        public frmDesignReport()
        {
            InitializeComponent();
        }
        public frmDesignReport(string _type, int _Prjid, int _Cutid)
        {
            InitializeComponent();
            _ViewType = _type;
            _Projectid = _Prjid;
            _Customerid = _Cutid;
        }

        public frmDesignReport(int _Prjid)
        {
            InitializeComponent();
            _Projectid = _Prjid;
        }

        private void frmDesignReport_Load(object sender, EventArgs e)
        {
            // BindReportTypes();
        }

        private void BindReportTypes()
        {
            try
            {
                ObjBReportDesign.GetReportDesignTypes(ObjEReportDesign, "");
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
                        if (_ViewType == "Form")
                        {
                            Report_Design.frmProposalCoverPage1 frm = new Report_Design.frmProposalCoverPage1();
                            frm.ShowDialog();
                        }
                        else
                        {
                            Report_Design.rptProposalCoverPage1 rpt = new Report_Design.rptProposalCoverPage1(_Projectid, _Customerid);
                            ReportPrintTool printTool = new ReportPrintTool(rpt);
                            printTool.ShowRibbonPreview();
                        }

                        break;

                    case "Proposal with Price":
                        this.Hide();
                        Report_Design.rptProposalwithprice rptwithPrice = new Report_Design.rptProposalwithprice(_Projectid, "With Price");
                        ReportPrintTool printTool1 = new ReportPrintTool(rptwithPrice);
                        printTool1.ShowRibbonPreview();
                        break;

                    case "Proposal without Price":
                        this.Hide();
                        Report_Design.rptProposalwithprice rptwithoutPrice = new Report_Design.rptProposalwithprice(_Projectid, "Without Price");
                        ReportPrintTool printTool2 = new ReportPrintTool(rptwithoutPrice);
                        printTool2.ShowRibbonPreview();
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