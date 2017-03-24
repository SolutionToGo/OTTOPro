using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using OTTOPro.Report_Design.dsProposalCoverPage1TableAdapters;

namespace OTTOPro.Report_Design
{
    public partial class rptProposalCoverPage1 : DevExpress.XtraReports.UI.XtraReport
    {
        int _Custid;
        int _Projectid;
        public rptProposalCoverPage1()
        {
            InitializeComponent();
        }
        public rptProposalCoverPage1(int _Prjid, int _Cutid)
        {
            InitializeComponent();
            _Projectid = _Prjid;
            _Custid = _Cutid;
        }

        private void rptProposalCoverPage1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                ReportDesignTableAdapter _taRD = new ReportDesignTableAdapter();
                _taRD.FillByDesignType(dsProposalCoverPage11.ReportDesign, "Proposal Cover Page 1");

                CustomerTableAdapter _tdCustomer = new CustomerTableAdapter();
                _tdCustomer.FillByCustomerID(dsProposalCoverPage11.Customer, _Custid);

                ProjectTableAdapter _tdProject = new ProjectTableAdapter();
                _tdProject.FillByProjectID(dsProposalCoverPage11.Project, _Projectid);

                OTTOMasterTableAdapter _tdOTTOMaster = new OTTOMasterTableAdapter();
                _tdOTTOMaster.FillByBranchAndActive(dsProposalCoverPage11.OTTOMaster, false, true);

                OTTOContactTableAdapter _tdOttoContact = new OTTOContactTableAdapter();
                _tdOttoContact.FillByDefaultcontactAndActive(dsProposalCoverPage11.OTTOContact, true, true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
