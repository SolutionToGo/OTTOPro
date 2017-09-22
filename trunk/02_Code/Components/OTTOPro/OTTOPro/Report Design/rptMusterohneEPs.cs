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
            try
            {
                e.Result = totalUnits;
                e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void xrLabel18_SummaryReset(object sender, EventArgs e)
        {
            //totalUnits = 0;
        }

        private void xrLabel18_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                xrLblGB.Text = "0.00";
                xrLblMO.Text = "0.00";
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void xrLabel18_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            try
            {
                if (e.PageIndex == e.PageCount - 1)
                {
                    xrLabel22.Visible = false;
                    xrLabel18.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

       
        private void lblTitle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblTitle.Text))
                {
                    string _title = lblTitle.Text;
                    lblTitle.Text = _title.Substring(0, 3);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

    }
}
