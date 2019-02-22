using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DAL;
using System.Data;

namespace OTTOPro.Report_Design
{
    public partial class rptProposalwithoutMAMO : DevExpress.XtraReports.UI.XtraReport
    {
        int _PID=0;
        DataTable dtValue;
        string _Type = string.Empty;
        string _LVSection = string.Empty;
        public rptProposalwithoutMAMO()
        {
            InitializeComponent();
        }
        public rptProposalwithoutMAMO(int _ProID, DataTable dt, string type, string LVSection)
        {
            InitializeComponent();
            _PID=_ProID;
            dtValue = dt;
            _Type = type;
            _LVSection = LVSection;
        }

        private void xrlblPageSum_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = _xrGBVlaue;
            e.Handled = true;
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

        private void xrTableCell13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double DVat = 0;
            try
            {
                if (GetCurrentColumnValue("Vat") != DBNull.Value)
                    if (double.TryParse(Convert.ToString(GetCurrentColumnValue("Vat")), out DVat))
                    {
                        double DGBValue = 0;
                        if (double .TryParse(Convert.ToString(xrLblGB.Summary.GetResult()),out DGBValue))
                        {
                            double _result = Convert.ToDouble(((DGBValue - _Discount) * DVat) / 100);
                            xrLblTotalVat.Text = _result.ToString("n2");
                        }
                    }
            }
            catch (Exception ex){}
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
                    xrLabel10.Visible = false;
                    xrLabel11.Visible = false;
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
               
                dsDiscountCalculation ds = new dsDiscountCalculation();
                this.p_Rpt_QuerCalculation_DiscountPositionTableAdapter.Connection.ConnectionString = SQLCon.ConnectionString();
                this.p_Rpt_QuerCalculation_DiscountPositionTableAdapter.ClearBeforeFill = true;
                this.p_Rpt_QuerCalculation_DiscountPositionTableAdapter.Fill(ds.P_Rpt_QuerCalculation_DiscountPosition, dtValue, _PID, _Type, "");

                dsProposalCommon _dsCommon = new dsProposalCommon();
                this.p_Rpt_PositionForProposalPriceForCommonTableAdapter.Connection.ConnectionString = SQLCon.ConnectionString();
                this.p_Rpt_PositionForProposalPriceForCommonTableAdapter.ClearBeforeFill = true;
                this.p_Rpt_PositionForProposalPriceForCommonTableAdapter.Fill(_dsCommon.P_Rpt_PositionForProposalPriceForCommon, dtValue, _PID, _Type, _LVSection);

                dsProposalCommonTotalSummery _dsTotalSum = new dsProposalCommonTotalSummery();
                this.p_Rpt_GetTotalSummeryTableAdapter.Connection.ConnectionString = SQLCon.ConnectionString();
                this.p_Rpt_GetTotalSummeryTableAdapter.ClearBeforeFill = true;
                this.p_Rpt_GetTotalSummeryTableAdapter.Fill(_dsTotalSum.P_Rpt_GetTotalSummery, dtValue, _PID, _Type, _LVSection);

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
                            lblDiscount.Visible = false;
                            lblDiscountEuro.Visible = false;
                            _Discount = 0;
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
            //    if (DetailReport1.GetCurrentColumnValue("FinalGB") != DBNull.Value)
            //    {
            //        value = Convert.ToDouble(xrLabel10.Summary.GetResult()) - _Discount;
            //        xrLblGB.Text = (value).ToString("n2");
            //    }

            //    xrTableCell13_BeforePrint(null,null);
                
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
                if (xrPositionKZ.Text != "Eventualposition")
                {
                    if (double.TryParse(xrGB.Text, out dValue))
                    {
                        if (dValue > 0)
                        {
                            _xrGBVlaue += dValue;
                        }
                    }    
                }                            
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void xrRichText1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRRichText richText = (XRRichText)sender;
                richText.Font = new Font("Trebuchet MS", 10, FontStyle.Bold);
            }
            catch (Exception ex) { }
        }

        private void xrRichText5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRRichText richText = (XRRichText)sender;
                richText.Font = new Font("Trebuchet MS", 10, FontStyle. Regular);
            }
            catch (Exception ex) { }
        }

        private void xrLabelFinalResult_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double DVat = 0;
            try
            {
                if (GetCurrentColumnValue("Vat") != DBNull.Value)
                    if (double.TryParse(Convert.ToString(GetCurrentColumnValue("Vat")), out DVat))
                    {
                        double DGBValue = 0;
                        if (double.TryParse(Convert.ToString(xrLblGB.Summary.GetResult()), out DGBValue))
                        {
                            double _result = Convert.ToDouble(((DGBValue - _Discount) * DVat) / 100);
                            xrLabelFinalResult.Text = ((DGBValue + _result) - _Discount).ToString("n2");
                        }
                    }
            }
            catch (Exception ex) { }
        }
    }
}
