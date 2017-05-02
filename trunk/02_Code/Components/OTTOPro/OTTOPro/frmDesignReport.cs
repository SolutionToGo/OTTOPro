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

                    case "mit Montage und Montagezeiten":
                        this.Hide();
                        Report_Design.rptProposalwithprice rptwithPrice = new Report_Design.rptProposalwithprice();
                        ReportPrintTool printTool1 = new ReportPrintTool(rptwithPrice);
                        rptwithPrice.Parameters["ProjectID"].Value = _Projectid;
                        printTool1.ShowRibbonPreview();
                        break;

                    case "Einzelpreise und Gesamtpreise":
                        this.Hide();
                        Report_Design.rptProposalwithoutprice rptwithoutPrice = new Report_Design.rptProposalwithoutprice();
                        ReportPrintTool printTool2 = new ReportPrintTool(rptwithoutPrice);
                        rptwithoutPrice.Parameters["ProjectID"].Value = _Projectid;
                        printTool2.ShowRibbonPreview();
                        break;

                    case "Muster Langtext Mont Mat getrennt":
                         this.Hide();
                         Report_Design.rptMusterLangtextMontMatgetrennt rptMatgetrennt = new Report_Design.rptMusterLangtextMontMatgetrennt();
                         ReportPrintTool printTool3 = new ReportPrintTool(rptMatgetrennt);
                         rptMatgetrennt.Parameters["ProjectID"].Value = _Projectid;
                         printTool3.ShowRibbonPreview();
                        break;

                    case "Muster Langtext ohne Mengen":
                         this.Hide();
                         Report_Design.rptMusterLangtextohneMengen rptohneMengen = new Report_Design.rptMusterLangtextohneMengen();
                         ReportPrintTool printTool4 = new ReportPrintTool(rptohneMengen);
                         rptohneMengen.Parameters["ProjectID"].Value = _Projectid;
                         printTool4.ShowRibbonPreview();
                        break;

                    case "Muster Langtext":
                         this.Hide();
                         Report_Design.rptMusterLangtext rptMusterLangtext = new Report_Design.rptMusterLangtext();
                         ReportPrintTool printTool5 = new ReportPrintTool(rptMusterLangtext);
                         rptMusterLangtext.Parameters["ProjectID"].Value = _Projectid;
                         printTool5.ShowRibbonPreview();
                        break;

                    case "Muster ohne EPs ohne Mengen":
                         this.Hide();
                         Report_Design.rptMusterohneEPsohneMengen rptEPsohneMengen = new Report_Design.rptMusterohneEPsohneMengen();
                         ReportPrintTool printTool6 = new ReportPrintTool(rptEPsohneMengen);
                         rptEPsohneMengen.Parameters["ProjectID"].Value = _Projectid;
                         printTool6.ShowRibbonPreview();
                        break;

                    case "Muster ohne EPs":
                         this.Hide();
                         Report_Design.rptMusterohneEPs rptMusterohneEPs = new Report_Design.rptMusterohneEPs();
                         ReportPrintTool printTool7 = new ReportPrintTool(rptMusterohneEPs);
                         rptMusterohneEPs.Parameters["ProjectID"].Value = _Projectid;
                         printTool7.ShowRibbonPreview();
                        break;
                        
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}