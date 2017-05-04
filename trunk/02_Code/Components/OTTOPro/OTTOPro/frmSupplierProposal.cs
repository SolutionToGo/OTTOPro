using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BL;
using EL;
using System.Collections;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraPrinting;

namespace OTTOPro
{
    public partial class frmSupplierProposal : DevExpress.XtraEditors.XtraForm
    {
        private int _ProjectID = 0;
        private int _ProposalID = 0;
        string _LvSection;
        string _WG = null;
        string _WA = null;
        string _ProjectName;
        string _pdfpath = null;
        ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = new BSupplier();
        DataTable _dtPosotion = new DataTable();
        DataTable _dtSupplier=null;
        bool _Process = false;

        public frmSupplierProposal()
        {
            InitializeComponent();
        }

        public frmSupplierProposal(int ProjectID,string LvSection,string PrName)
        {
            InitializeComponent();
            _ProjectID = ProjectID;
            _LvSection = LvSection;
            _ProjectName = PrName;
        }

        private void frmSupplierProposal_Load(object sender, EventArgs e)
        {
            try
            {
                FillLVSection();
                cmbLVSection.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void FillLVSection()
        {
            try
            {
                ObjESupplier = ObjBSupplier.GetLVSectionForProposal(ObjESupplier, _ProjectID);
                if (ObjESupplier.Article != null)
                {
                    cmbLVSection.DataSource = ObjESupplier.Article.Tables[0];
                    cmbLVSection.DisplayMember = "LVSection";
                    cmbLVSection.ValueMember = "LVSection";
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void GetWGWA()
        {
            try
            {
                if (ObjESupplier.Article != null)
                {
                    cmbWGWA.DataSource = null;
                    DataView dvWGWA = ObjESupplier.Article.Tables[1].DefaultView;
                    dvWGWA.RowFilter = "LVSection = '" + cmbLVSection.Text + "'";
                    cmbWGWA.DataSource = dvWGWA;
                    cmbWGWA.DisplayMember = "WGWA";
                    cmbWGWA.ValueMember = "WGWA";
                    cmbWGWA.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetLVDetailsAndSupplier()
        {
            try
            {
                string[] strArr = null;
                char[] splitchar = { '-' };                
                strArr = cmbWGWA.SelectedValue.ToString().Split(splitchar);
                for (int count = 0; count <= strArr.Length - 1; count++)
                {
                     _WG = strArr[0];
                     _WA = strArr[1];
                }
                                
                if(_WG!=null && _WA!=null)
                {
                    ObjESupplier = ObjBSupplier.GetWGWAForProposal(ObjESupplier, _ProjectID, cmbLVSection.Text, Convert.ToInt32(_WG), Convert.ToInt32(_WA));
                    if (ObjESupplier.dsSupplier != null)
                    {
                        gcLVDetails.DataSource = ObjESupplier.dsSupplier.Tables[0];
                        gvLVDetails.BestFitColumns();

                        chkSupplierLists.DataSource = ObjESupplier.dsSupplier.Tables[1];
                        chkSupplierLists.DisplayMember = "ShortName";
                        chkSupplierLists.ValueMember = "id";
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbWGWA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                GetLVDetailsAndSupplier();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbLVSection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                GetWGWA();
                gcLVDetails.DataSource = null;
                chkSupplierLists.DataSource = null;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkSupplierLists_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (chkSupplierLists.CheckedItems.Count == 9)
                {
                    Int32 checkedItemIndex = chkSupplierLists.CheckedIndices[0];
                    chkSupplierLists.SetItemChecked(checkedItemIndex, false);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {               
                for (int i = ObjESupplier.dsSupplier.Tables[0].Columns.Count - 1; i >= 0; i--)
                {
                    string strcolname = ObjESupplier.dsSupplier.Tables[0].Columns[i].ColumnName.ToString();
                    if (strcolname != "PositionID")
                    {
                        ObjESupplier.dsSupplier.Tables[0].Columns.RemoveAt(i);
                    }
                }
                _dtPosotion = ObjESupplier.dsSupplier.Tables[0];

                _dtSupplier = new DataTable();
                _dtSupplier.Columns.Add("SupplierID");
                foreach (object item in chkSupplierLists.CheckedItems)
                {
                    DataRowView row = item as DataRowView;
                    DataRow dr = _dtSupplier.NewRow();
                    dr["SupplierID"] = row["id"];
                    _dtSupplier.Rows.Add(dr);
                }
                _ProposalID = ObjBSupplier.SaveSupplierProposal(ObjESupplier, _ProjectID, cmbLVSection.Text, Convert.ToInt32(_WG), Convert.ToInt32(_WA), _dtPosotion, _dtSupplier);
                if(_ProposalID > 0)
                {
                    Report_Design.rptSupplierProposal rpt = new Report_Design.rptSupplierProposal();
                    ReportPrintTool printTool = new ReportPrintTool(rpt);
                    rpt.Parameters["LVSection"].Value = cmbLVSection.Text;
                    rpt.Parameters["WG"].Value = Convert.ToInt32(_WG);
                    rpt.Parameters["WA"].Value = Convert.ToInt32(_WA);
                    rpt.Parameters["ProjectID"].Value = _ProjectID;

                    saveFileDialog1.Filter = "PDF Files|*.pdf";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        rpt.ExportToPdf(saveFileDialog1.FileName);
                        if (_Process != true)
                        {
                            StartProcess(saveFileDialog1.FileName);
                        }
                        _pdfpath = saveFileDialog1.FileName;
                    }                   
                }
                               
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void StartProcess(string path)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = path;
                process.Start();
                process.WaitForInputIdle();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            StringBuilder strArr = new StringBuilder();
            string delimiter = "";
            try
            {
                _Process = true;
                btnGeneratePDF_Click(null,null);
                Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = "This is the subject";

                DataTable _dtSuppliermail = new DataTable();
                _dtSuppliermail.Columns.Add("Suppliermail");
                foreach (object item in chkSupplierLists.CheckedItems)
                {
                    DataRowView row = item as DataRowView;
                    DataRow dr = _dtSuppliermail.NewRow();
                    dr["Suppliermail"] = row["SupplierMail"];
                    _dtSuppliermail.Rows.Add(dr);
                }
                if (_dtSuppliermail.Rows.Count > 0)
                {
                    foreach (DataRow dr in _dtSuppliermail.Rows)
                    {
                        if (dr["Suppliermail"].ToString() != null || dr["Suppliermail"].ToString() != "")
                        {
                            strArr.Append(delimiter);
                            strArr.Append(dr["Suppliermail"]);
                            delimiter = ";";
                        }
                    }
                }                
                mailItem.To = strArr.ToString();
                mailItem.Body = "This is the message.";

                mailItem.Attachments.Add(_pdfpath);
                mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                mailItem.Display(false);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvLVDetails_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gcLVDetailsDelete_ItemClick));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcLVDetailsDelete_ItemClick(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = gvLVDetails.FocusedRowHandle;
                DataTable table = gcLVDetails.DataSource as DataTable;
                table.Rows.RemoveAt(iRowHandle);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}