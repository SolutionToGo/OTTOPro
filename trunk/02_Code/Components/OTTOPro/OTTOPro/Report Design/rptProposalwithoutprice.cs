using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using OTTOPro.Report_Design.dsProposalwithpriceTableAdapters;

namespace OTTOPro.Report_Design
{
    public partial class rptProposalwithoutprice : DevExpress.XtraReports.UI.XtraReport
    {
        int _PID;
        public rptProposalwithoutprice()
        {
            InitializeComponent();
        }

        public rptProposalwithoutprice(int _id)
        {
            InitializeComponent();
            _PID = _id;
        }

        private void rptProposalwithoutprice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PositionTableAdapter _tdPosition = new PositionTableAdapter();
            _tdPosition.FillByPID(dsProposalwithprice1.Position, _PID);

            OTTOMasterTableAdapter _tdOtto = new OTTOMasterTableAdapter();
            _tdOtto.FillByBranchAndIsActive(dsProposalwithprice1.OTTOMaster, false, true);

            ProjectTableAdapter _tdProject = new ProjectTableAdapter();
            _tdProject.FillByProjectID(dsProposalwithprice1.Project, _PID);
        }

        double totalUnits = 0;
        private void xrLabel16_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalUnits;
            e.Handled = true;
        }

        private void xrLabel16_SummaryReset(object sender, EventArgs e)
        {
            totalUnits = 0;
        }

        private void xrLabel16_SummaryRowChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("FinalGB") != DBNull.Value)
                totalUnits += Convert.ToDouble(GetCurrentColumnValue("FinalGB"));
        }

    }
}
