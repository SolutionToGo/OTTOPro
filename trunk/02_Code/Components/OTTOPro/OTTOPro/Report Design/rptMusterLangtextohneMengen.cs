using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptMusterLangtextohneMengen : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMusterLangtextohneMengen()
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
          //  totalUnits = 0;
        }

        private void xrLabel18_SummaryRowChanged(object sender, EventArgs e)
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

        double totalEP = 0;
        private void xrLabelEP1_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalEP;
            e.Handled = true;
        }

        private void xrLabelEP1_SummaryReset(object sender, EventArgs e)
        {
            totalEP = 0;
        }

        private void xrLabelEP1_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("EP") != DBNull.Value)
                    totalEP += Convert.ToDouble(DetailReport.GetCurrentColumnValue("EP"));
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

        double totalMOPrice = 0;
        private void xrLabelMO1_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalMOPrice;
            e.Handled = true;
        }

        private void xrLabelMO1_SummaryReset(object sender, EventArgs e)
        {
            totalMOPrice = 0;
        }

        private void xrLabelMO1_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("MO_verkaufspreis") != DBNull.Value)
                    totalMOPrice += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MO_verkaufspreis"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        double totalMAPrice = 0;
        private void xrLabelMA1_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalMAPrice;
            e.Handled = true;
        }

        private void xrLabelMA1_SummaryReset(object sender, EventArgs e)
        {
            totalMAPrice = 0;
        }

        private void xrLabelMA1_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("MA_verkaufspreis") != DBNull.Value)
                    totalMAPrice += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MA_verkaufspreis"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        double totalMOPrice1 = 0;
        private void xrLabel27_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalMOPrice1;
            e.Handled = true;
        }

        private void xrLabel27_SummaryReset(object sender, EventArgs e)
        {
            totalMOPrice1 = 0;
        }

        private void xrLabel27_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("MA_verkaufspreis") != DBNull.Value)
                    totalMOPrice1 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MA_verkaufspreis"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        double totalFinalGB3 = 0;
        private void xrLabelGB3_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalFinalGB3;
            e.Handled = true;
        }

        private void xrLabelGB3_SummaryReset(object sender, EventArgs e)
        {
            totalFinalGB3 = 0;
        }

        private void xrLabelGB3_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport1.GetCurrentColumnValue("GB") != DBNull.Value)
                    totalFinalGB3 += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("GB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        double totalEP2 = 0;
        private void xrLabelEP2_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalEP2;
            e.Handled = true;
        }

        private void xrLabelEP2_SummaryReset(object sender, EventArgs e)
        {
            totalEP2 = 0;
        }

        private void xrLabelEP2_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport1.GetCurrentColumnValue("EP") != DBNull.Value)
                    totalEP2 += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("EP"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        double totalMO2Price = 0;
        private void xrLabelMO2_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalMO2Price;
            e.Handled = true;
        }

        private void xrLabelMO2_SummaryReset(object sender, EventArgs e)
        {
            totalMO2Price = 0;
        }

        private void xrLabelMO2_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport1.GetCurrentColumnValue("MoPrice") != DBNull.Value)
                    totalMO2Price += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("MoPrice"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        double totalMA2Price = 0;
        private void xrLabelMA2_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalMA2Price;
            e.Handled = true;
        }

        private void xrLabelMA2_SummaryReset(object sender, EventArgs e)
        {
            totalMA2Price = 0;
        }

        private void xrLabelMA2_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport1.GetCurrentColumnValue("MAPrice") != DBNull.Value)
                    totalMA2Price += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("MAPrice"));
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
        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Double dValue = 0;
            Double GValue = 0;
            Double Value1 = 0;
            Double Value2 = 0;
            try
            {
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


        private void lbltitle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lbltitle.Text))
            {
                string _title = lbltitle.Text;
                lbltitle.Text = _title.Substring(0, 3);
            }       
        }



    
//**********************

    }
}
