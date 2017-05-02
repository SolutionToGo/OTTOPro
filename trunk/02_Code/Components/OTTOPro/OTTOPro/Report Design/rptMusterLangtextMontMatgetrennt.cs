using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptMusterLangtextMontMatgetrennt : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMusterLangtextMontMatgetrennt()
        {
            InitializeComponent();
        }

        double totalGB1 = 0;
        private void xrLabel18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalGB1;
            e.Handled = true;
        }
        private void xrLabel18_SummaryReset(object sender, EventArgs e)
        {
            totalGB1 = 0;
        }
        private void xrLabel18_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                totalGB1 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
        }
        

        double totalEP = 0;
        private void xrLabel24_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalEP;
            e.Handled = true;
        }

        private void xrLabel24_SummaryReset(object sender, EventArgs e)
        {
            totalEP = 0;
        }

        private void xrLabel24_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport.GetCurrentColumnValue("EP") != DBNull.Value)
                totalEP += Convert.ToDouble(DetailReport.GetCurrentColumnValue("EP"));
        }

        double totalGB2 = 0;
        private void xrLabel23_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalGB2;
            e.Handled = true;
        }

        private void xrLabel23_SummaryReset(object sender, EventArgs e)
        {
            totalGB2 = 0;
        }

        private void xrLabel23_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                totalGB2 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
        }

        double totalMAPrice = 0;
        private void xrLabel25_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalMAPrice;
            e.Handled = true;
        }

        private void xrLabel25_SummaryReset(object sender, EventArgs e)
        {
            totalMAPrice = 0;
        }

        private void xrLabel25_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport.GetCurrentColumnValue("MO_verkaufspreis") != DBNull.Value)
                totalMAPrice += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MO_verkaufspreis"));
        }

        double totalMOPrice = 0;
        private void xrLabel26_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalMOPrice;

            e.Handled = true;
        }

        private void xrLabel26_SummaryReset(object sender, EventArgs e)
        {
            totalMOPrice = 0;
        }

        private void xrLabel26_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport.GetCurrentColumnValue("MA_verkaufspreis") != DBNull.Value)
                totalMOPrice += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MA_verkaufspreis"));
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
            if (DetailReport.GetCurrentColumnValue("MA_verkaufspreis") != DBNull.Value)
                totalMOPrice1 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MA_verkaufspreis"));
        }

/// <summary>
/// 
/// </summary>
        double totalFinalGB = 0;
        private void xrLabel30_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalFinalGB;
            e.Handled = true;
        }

        private void xrLabel30_SummaryReset(object sender, EventArgs e)
        {
            totalFinalGB = 0;
        }

        private void xrLabel30_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport1.GetCurrentColumnValue("GB") != DBNull.Value)
                totalFinalGB += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("GB"));
            xrLblGB.Text =Convert.ToString(totalFinalGB);            
        }

        double totalFinalEP = 0;
        private void xrLabel29_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalFinalEP;
            e.Handled = true;
        }

        private void xrLabel29_SummaryReset(object sender, EventArgs e)
        {
            totalFinalEP = 0;
        }

        private void xrLabel29_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport1.GetCurrentColumnValue("EP") != DBNull.Value)
                totalFinalEP += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("EP"));
        }

        double totalFinalMOPrice = 0;
        private void xrLabel28_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalFinalMOPrice;
            e.Handled = true;
        }

        private void xrLabel28_SummaryReset(object sender, EventArgs e)
        {
            totalFinalMOPrice = 0;
        }

        
        private void xrLabel28_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport1.GetCurrentColumnValue("MoPrice") != DBNull.Value)
                totalFinalMOPrice += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("MoPrice"));
            xrLblMO.Text = Convert.ToString(totalFinalMOPrice);           
        }

        double totalFinalMAPrice = 0;
        private void xrLabelMA1_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalFinalMAPrice;
            e.Handled = true;
        }

        private void xrLabelMA1_SummaryReset(object sender, EventArgs e)
        {
            totalFinalMAPrice = 0;
        }

        private void xrLabelMA1_SummaryRowChanged(object sender, EventArgs e)
        {
            if (DetailReport1.GetCurrentColumnValue("MAPrice") != DBNull.Value)
                totalFinalMAPrice += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("MAPrice"));
            xrLblMA.Text = Convert.ToString(totalFinalMAPrice);
        }

        Double totalvat = 0;
        Double GBValue = 0;
        Double GB1 = 0;
        Double GBWithVat = 0;
        private void xrTableCell13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Double dValue = 0;
            Double GValue = 0;
            Double Value1 = 0;
            Double Value2 = 0;
            try
            {
                if (double.TryParse(GetCurrentColumnValue("Vat").ToString(), out dValue))
                    totalvat = dValue;
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

       

//**********************

    }
}
