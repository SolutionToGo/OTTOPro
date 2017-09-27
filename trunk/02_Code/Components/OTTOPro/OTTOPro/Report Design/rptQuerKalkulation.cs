﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace OTTOPro.Report_Design
{
    public partial class rptQuerKalkulation : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQuerKalkulation()
        {
            InitializeComponent();
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
//***********************
        
    }
}
