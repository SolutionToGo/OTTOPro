using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptInvoicewithKurzText : DevExpress.XtraReports.UI.XtraReport
    {
        public rptInvoicewithKurzText()
        {
            InitializeComponent();
        }       

        double totalResult = 0;      
        int i = 0;
        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (i++ == 0)
            {
                foreach (XRControl cont in (((TopMarginBand)sender).Controls))
                {
                    cont.PrintOnPage += new PrintOnPageEventHandler(cont_PrintOnPage);
                }
            }
        }
        void cont_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            e.Cancel = e.PageIndex == 0;
        }
        
        private void xrLabel42_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalResult.ToString("n2");
            e.Handled = true;
        }

        private void xrLabel42_SummaryReset(object sender, EventArgs e)
        {
            // totalUnits = 0;
        }

        private void xrLabel42_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                    totalResult += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}
