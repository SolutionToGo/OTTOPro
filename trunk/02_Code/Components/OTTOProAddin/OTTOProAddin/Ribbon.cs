using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using DevExpress.XtraSplashScreen;

namespace OTTOProAddin
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnOTTOMaster_Click(object sender, RibbonControlEventArgs e)
        {
            frmOTTOMaster f = new frmOTTOMaster();
            f.ShowDialog();
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            frmTextModule f = new frmTextModule();
            f.ShowDialog();
        }

        private void btnCustomer_Click(object sender, RibbonControlEventArgs e)
        {
            frmCustomerMaster f = new frmCustomerMaster();
            f.ShowDialog();
        }

        private void btnInvoiceGrid_Click(object sender, RibbonControlEventArgs e)
        {
            frmInvoice f = new frmInvoice();
            f.ShowDialog();

        }

        private void btnCustomerName_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("CustName");
        }

        private void btnCustaddress_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("CustAddress");
        }

        private void btnProjectNumber_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("ProjectNr");
        }

        private void btnCommissionNr_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("KommissionNr");
        }

        private void btnProjectDesc_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("Bauvorhaben");
        }

        private void btnPlanner_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("Planner");
        }

        private void AddMergeField(string stFieldName)
        {
            try
            {
                SplashScreenManager.ShowForm(null, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Bitte warten…");
                Object objType = Word.WdFieldType.wdFieldMergeField;
                Object oMissing = System.Reflection.Missing.Value;
                Object objFieldName = stFieldName;
                Word.Application WordApp = new Word.Application();
                Word.Document WordDoc = Globals.ThisAddIn.Application.ActiveDocument;
                dynamic oRange = WordDoc.Content.Application.Selection.Range;
                Microsoft.Office.Interop.Word.Range rngFieldCode = oRange;
                Word.Field field = rngFieldCode.Fields.Add(rngFieldCode, ref objType, ref objFieldName, ref oMissing);
            }
            catch (Exception ex){}
            finally { SplashScreenManager.CloseForm(false); }
        }

        private void btnSupplierName_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("LieferantName");
        }

        private void btnSupplierAddress_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("LieferantAddress");
        }

        private void btnProposalDate_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("ProposalDate");
        }

        private void btnDeliveryDeadLine_Click(object sender, RibbonControlEventArgs e)
        {
            AddMergeField("DeliveryDeadline");
        }
    }
}
