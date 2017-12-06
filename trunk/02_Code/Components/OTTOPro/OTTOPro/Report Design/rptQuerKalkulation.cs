using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Configuration;


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
                this.p_Rpt_QuerCalculationTableAdapter.Connection.ConnectionString = SQLCon.ConnectionString();
                this.p_Rpt_QuerCalculationTableAdapter.ClearBeforeFill = true;
                this.p_Rpt_QuerCalculationTableAdapter.Fill(dsQuerKalculation1.P_Rpt_QuerCalculation, dtValue, _PID, _Type);

                this.p_Rpt_QuerCalculation_SurchargePositionTableAdapter.Connection.ConnectionString = SQLCon.ConnectionString();
                this.p_Rpt_QuerCalculation_SurchargePositionTableAdapter.ClearBeforeFill = true;
                this.p_Rpt_QuerCalculation_SurchargePositionTableAdapter.Fill(dsSurchargeCalculation1.P_Rpt_QuerCalculation_SurchargePosition, dtValue, _PID, _Type);

                DataTable dt = new DataTable();
                dt = dsSurchargeCalculation1.P_Rpt_QuerCalculation_SurchargePosition;                
                if (dt != null)
                {                    
                    decimal _result = 0;
                    if (decimal.TryParse(Convert.ToString(dt.Rows[0][0]), out _result))
                        tblSurchargeresult.Text = _result.ToString("n2");
                    else
                        throw new Exception(Convert.ToString(dt.Rows[0][0]));
                }


            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
//***********************
        
    }
}
