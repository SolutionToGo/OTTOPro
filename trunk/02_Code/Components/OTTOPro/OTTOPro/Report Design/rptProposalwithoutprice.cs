using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptProposalwithoutprice : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProposalwithoutprice()
        {
            InitializeComponent();
        }

        private void rptProposalwithoutprice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }     

        double totalUnits = 0;
        private void xrLabel10_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalUnits;
            e.Handled = true;
        }

        private void xrLabel10_SummaryReset(object sender, EventArgs e)
        {
            totalUnits = 0;
        }

        private void xrLabel10_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                    totalUnits += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

    }
}
