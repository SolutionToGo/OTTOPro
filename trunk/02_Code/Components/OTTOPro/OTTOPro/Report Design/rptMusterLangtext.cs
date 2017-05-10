using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptMusterLangtext : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMusterLangtext()
        {
            InitializeComponent();
        }

        double totalUnits = 0;
        private void xrLabelGB1_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalUnits;
            e.Handled = true;
        }

        private void xrLabelGB1_SummaryReset(object sender, EventArgs e)
        {
            totalUnits = 0;
        }

        private void xrLabelGB1_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport1.GetCurrentColumnValue("GB") != DBNull.Value)
                    totalUnits += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("GB"));
                xrLblGB.Text = Convert.ToString(totalUnits);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }            
        }

        double totalGB2 = 0;
        private void xrLabelGB2_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalGB2;
            e.Handled = true;
        }

        private void xrLabelGB2_SummaryReset(object sender, EventArgs e)
        {
            totalGB2 = 0;
        }

        private void xrLabelGB2_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                    xrLabelGB2.Text += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        Double totalvat = 0;
        Double GBValue = 0;
        Double GB1 = 0;
        Double GBWithVat = 0;
        private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                Double dValue = 0;
                Double GValue = 0;
                Double Value1 = 0;
                Double Value2 = 0;
                if (GetCurrentColumnValue("Vat") != DBNull.Value)
                {
                    if (double.TryParse(Convert.ToString(GetCurrentColumnValue("Vat")), out dValue))
                        totalvat = dValue;
                }                
                if (double.TryParse(xrLblGB.Text, out GValue))
                    GBValue = GValue;
                double _result = Convert.ToDouble((GBValue * totalvat) / 100);
                xrLblTotalVat.Text = Convert.ToString(_result);

                if (double.TryParse(xrLblGB.Text, out Value1))
                    GB1 = Value1;
                if (double.TryParse(xrLblTotalVat.Text, out Value2))
                    GBWithVat = Value2;
                double _resultVat = Convert.ToDouble(GB1 + GBWithVat);
                xrLabelFinalResult.Text = Convert.ToString(_resultVat);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


//*********************
    }
}
