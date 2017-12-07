using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DAL;
using System.Data;

namespace OTTOPro.Report_Design
{
    public partial class rptProposalCommon : DevExpress.XtraReports.UI.XtraReport
    {
        int _PID=0;
        public rptProposalCommon()
        {
            InitializeComponent();
        }
        public rptProposalCommon(int _ProID)
        {
            InitializeComponent();
            _PID=_ProID;
        }

        double totalGB1 = 0;
        private void xrLabel18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalGB1;
            e.Handled = true;
        }
        private void xrLabel18_SummaryReset(object sender, EventArgs e)
        {
           // totalGB1 = 0;
        }
        private void xrLabel18_SummaryRowChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailReport.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                    totalGB1 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
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
            try
            {
                if (DetailReport.GetCurrentColumnValue("MO_verkaufspreis") != DBNull.Value)
                    totalMAPrice += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MO_verkaufspreis"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
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
            try
            {
                if (DetailReport.GetCurrentColumnValue("MA_verkaufspreis") != DBNull.Value)
                    totalMOPrice += Convert.ToDouble(DetailReport.GetCurrentColumnValue("MA_verkaufspreis"));
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
            try
            {
                if (DetailReport1.GetCurrentColumnValue("GB") != DBNull.Value)
                    totalFinalGB += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("GB"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }      
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
            try
            {
                if (DetailReport1.GetCurrentColumnValue("EP") != DBNull.Value)
                    totalFinalEP += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("EP"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
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
            try
            {
                if (DetailReport1.GetCurrentColumnValue("MoPrice") != DBNull.Value)
                    totalFinalMOPrice += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("MoPrice"));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
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
            try
            {
                if (DetailReport1.GetCurrentColumnValue("MAPrice") != DBNull.Value)
                    totalFinalMAPrice += Convert.ToDouble(DetailReport1.GetCurrentColumnValue("MAPrice"));
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
        private void xrTableCell13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                //if (double.TryParse(value, out GValue))
                    GBValue = value;
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
                    xrlblPageSum.Visible = false;
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
                if(!string.IsNullOrEmpty(lblTitle.Text))
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

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                foreach (XRControl cont in (((TopMarginBand)sender).Controls))
                {
                    cont.PrintOnPage += new PrintOnPageEventHandler(cont_PrintOnPage);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        void cont_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            try
            {
                if (e.PageIndex > 0)
                {
                    xrRichText5.Visible = false;
                    xrRichText6.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        double _Discount = 0;
        private void rptProposalCommon_DataSourceDemanded(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPos = new DataTable();
                dtPos.Columns.Add("FromPos");
                dtPos.Columns.Add("ToPos");
                dsDiscountCalculation ds = new dsDiscountCalculation();
                this.p_Rpt_QuerCalculation_DiscountPositionTableAdapter.Connection.ConnectionString = SQLCon.ConnectionString();
                this.p_Rpt_QuerCalculation_DiscountPositionTableAdapter.ClearBeforeFill = true;
                this.p_Rpt_QuerCalculation_DiscountPositionTableAdapter.Fill(ds.P_Rpt_QuerCalculation_DiscountPosition, dtPos, _PID, "Complete");

                DataTable dtdiscount = new DataTable();
                dtdiscount = ds.P_Rpt_QuerCalculation_DiscountPosition;
                if (dtdiscount != null)
                {
                    decimal _result = 0;
                    if (decimal.TryParse(Convert.ToString(dtdiscount.Rows[0][0]), out _result))
                    {
                        tbDiscount.Text = '-' + _result.ToString("n2");
                        _Discount = Convert.ToDouble(_result);
                    }
                    else
                        throw new Exception(Convert.ToString(dtdiscount.Rows[0][0]));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        double value = 0;
        private void xrLblGB_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {                
                if (DetailReport1.GetCurrentColumnValue("FinalGB") != DBNull.Value)
                {
                    value = Convert.ToDouble(xrLblMA.Summary.GetResult()) + Convert.ToDouble(xrLblMO.Summary.GetResult()) - _Discount;
                    xrLblGB.Text = (value).ToString("n2");
                }

                xrTableCell13_BeforePrint(null,null);
                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

//**********************

    }
}
