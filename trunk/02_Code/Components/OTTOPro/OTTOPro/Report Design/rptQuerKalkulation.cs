using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace OTTOPro.Report_Design
{
    public partial class rptQuerKalkulation : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtValue;
        int _PID = 0;
        string _Type = string.Empty;

        public rptQuerKalkulation()
        {
            InitializeComponent();
        }
        public rptQuerKalkulation(int _id, DataTable dt, string type)
        {
            InitializeComponent();
            _PID = _id;
            dtValue = dt;
            _Type = type;
        }


        double value = 0;
        private void xrTableCell60_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (double.TryParse(Convert.ToString(xrTableCell36.Summary.GetResult()), out value))
                {
                    xrTableCell60.Text = value.ToString("n2");
                }
                if (DetailReport1.GetCurrentColumnValue("Total") != DBNull.Value)
                {
                    value = Convert.ToDouble(xrTableCell36.Summary.GetResult()) + Convert.ToDouble(DetailReport1.GetCurrentColumnValue("Total"));
                    xrTableCell60.Text = value.ToString("n2");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void rptQuerKalkulation_DataSourceDemanded(object sender, EventArgs e)
        {
            try
            {
                this.p_Rpt_QuerCalculationTableAdapter.Fill(dsQuerKalculation1.P_Rpt_QuerCalculation, dtValue, _PID, _Type);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
//***********************
        
    }
}
