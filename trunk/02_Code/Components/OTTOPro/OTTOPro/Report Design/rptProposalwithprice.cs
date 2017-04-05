using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using OTTOPro.Report_Design.dsProposalwithpriceTableAdapters;

namespace OTTOPro.Report_Design
{
    public partial class rptProposalwithprice : DevExpress.XtraReports.UI.XtraReport
    {
        int _PID;
        string Type;
        public rptProposalwithprice()
        {
            InitializeComponent();
        }

        public rptProposalwithprice(int _id,string _Type)
        {
            InitializeComponent();
            _PID = _id;
            Type = _Type;
        }       

        private void rptProposalwithprice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if(Type=="Without Price")
            {
                int width = 50;
                xrTable1.DeleteColumn(xrTableCell8, false);
                xrTable1.DeleteColumn(xrTableCell1, false);
                xrTable2.DeleteColumn(xrTableCell13, false);
                xrTable2.DeleteColumn(xrTableCell14, false);
                xrTableCell12.SizeF = new SizeF(xrTableCell12.SizeF.Width + width, xrTableCell12.SizeF.Height);
                xrRichText1.SizeF = new SizeF(xrTableCell12.SizeF.Width + width, xrTableCell12.SizeF.Height);
            }

            PositionTableAdapter _tdPosition = new PositionTableAdapter();
            _tdPosition.FillByPID(dsProposalwithprice1.Position,_PID);

            OTTOMasterTableAdapter _tdOtto = new OTTOMasterTableAdapter();
            _tdOtto.FillByBranchAndIsActive(dsProposalwithprice1.OTTOMaster, false, true);

            ProjectTableAdapter _tdProject = new ProjectTableAdapter();
            _tdProject.FillByProjectID(dsProposalwithprice1.Project,_PID);
        }

        double totalUnits = 0;
        private void xrLabel16_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = totalUnits;
            e.Handled = true;
        }

        private void xrLabel16_SummaryReset(object sender, EventArgs e)
        {
            totalUnits = 0;
        }

        private void xrLabel16_SummaryRowChanged(object sender, EventArgs e)
        {
            if (GetCurrentColumnValue("FinalGB") != DBNull.Value)
                totalUnits += Convert.ToDouble(GetCurrentColumnValue("FinalGB"));
        }
//*********************
    }
}
