using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptMusterohneEPs : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMusterohneEPs()
        {
            InitializeComponent();
        }

        double totalUnits = 0;
        private void xrLabel18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalUnits;
            e.Handled = true;
        }

        private void xrLabel18_SummaryReset(object sender, EventArgs e)
        {
            totalUnits = 0;
        }

        private void xrLabel18_SummaryRowChanged(object sender, EventArgs e)
        {
            xrLblGB.Text = "0.00";
            xrLblMO.Text = "0.00";
            //if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
            //    totalUnits += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
        }

    }
}
