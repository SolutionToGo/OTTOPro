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
                xrLblGB.Text = Convert.ToDouble(totalUnits).ToString("n2");
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
                    totalGB2 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
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
                xrLblTotalVat.Text = Convert.ToDouble(_result).ToString("n2");

                if (double.TryParse(xrLblGB.Text, out Value1))
                    GB1 = Value1;
                if (double.TryParse(xrLblTotalVat.Text, out Value2))
                    GBWithVat = Value2;
                double _resultVat = Convert.ToDouble(GB1 + GBWithVat);
                xrLabelFinalResult.Text = Convert.ToDouble(_resultVat).ToString("n2");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        double totalUnits1 = 0;
        private void xrLabel23_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalUnits1;
            e.Handled = true;
        }

        private void xrLabel23_SummaryReset(object sender, EventArgs e)
        {
            totalUnits1 = 0;
        }

        private void xrLabel23_SummaryRowChanged(object sender, EventArgs e)
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


       

//*********************
    }
}
