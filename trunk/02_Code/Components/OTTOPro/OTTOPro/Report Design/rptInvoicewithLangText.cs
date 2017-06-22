using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptInvoicewithLangText : DevExpress.XtraReports.UI.XtraReport
    {
        public rptInvoicewithLangText()
        {
            InitializeComponent();
        }
        double totalUnits = 0;
        double totalUnits1 = 0;
        double GrandTotals = 0;
        private void xrLabel25_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalUnits1;
            e.Handled = true;
        }

        private void xrLabel25_SummaryReset(object sender, EventArgs e)
        {
            totalUnits1 = 0;
        }

        private void xrLabel25_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                    totalUnits1 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }         
        }
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
            e.Result = totalUnits.ToString("n2");
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
                    totalUnits += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }      
        }

       
       

    }
}
