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
        private void xrlblPageSum_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _xrGBVlaue;
            e.Handled = true;
        }
        private void xrlblPageSum_SummaryReset(object sender, EventArgs e)
        {
           // totalGB1 = 0;
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

        private void xrlblPageSum_PrintOnPage(object sender, PrintOnPageEventArgs e)
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
                this.p_Rpt_QuerCalculation_DiscountPositionTableAdapter.Fill(ds.P_Rpt_QuerCalculation_DiscountPosition, dtPos, _PID, "Complete","");

                DataTable dtdiscount = new DataTable();
                dtdiscount = ds.P_Rpt_QuerCalculation_DiscountPosition;
                if (dtdiscount != null)
                {
                    decimal _result = 0;
                    if (decimal.TryParse(Convert.ToString(dtdiscount.Rows[0][0]), out _result))
                    {
                        if (_result != 0)
                        {
                            tbDiscount.Text = '-' + _result.ToString("n2");
                            _Discount = Convert.ToDouble(_result);
                        }
                        else
                        {
                            tbDiscount.Text = string.Empty;
                            _Discount = 0;
                            lblDiscount.Visible = false;
                            lblDiscountEuro.Visible = false;
                        }

                    }
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

        double _xrGBVlaue = 0;
        private void xrGB_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Double dValue = 0;
            try
            {
                if (double.TryParse(xrGB.Text, out dValue))
                {
                    if (dValue > 0)
                    {
                        _xrGBVlaue += dValue;
                    }
                }                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        //double _xrGBVlaue = 0;
        private void xrlblPageSum_SummaryRowChanged(object sender, EventArgs e)
        {
            //if (DetailReport1.GetCurrentColumnValue("FinalGB") != DBNull.Value)
            //{
            //    totalGB1 += Convert.ToDouble(DetailReport.GetCurrentColumnValue("FinalGB"));
            //}

            //Double dValue = 0;
            //try
            //{
            //    if (double.TryParse(xrGB.Text, out dValue))
            //    {
            //        if (dValue > 0)
            //        {
            //            _xrGBVlaue += dValue;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Utility.ShowError(ex);
            //}
        }

    }
}
