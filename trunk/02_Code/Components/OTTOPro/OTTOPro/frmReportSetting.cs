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
using EL;
using BL;
using DevExpress.XtraEditors.Controls;
using OTTOPro.Report_Design;
using DevExpress.XtraReports.UI;

namespace OTTOPro
{
    public partial class frmReportSetting : DevExpress.XtraEditors.XtraForm
    {
        EReportDesign ObjEReport = null;
        BReportDesign ObjBReport = null;
        public bool _ISave = false;
        public bool _ISMAMOChecked= false;
        BGAEB objBGAEB = null;
        int _ProjectID = 0;


        public frmReportSetting()
        {
            InitializeComponent();
        }
        public frmReportSetting(int _ProjID)
        {
            InitializeComponent();
            _ProjectID = _ProjID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjBReport == null)
                    ObjBReport = new BReportDesign();
                if (ObjEReport == null)
                    ObjEReport = new EReportDesign();
                ParseReportSettings();
                ObjBReport.SaveReportSetting(ObjEReport);  

                DataTable dtPos = new DataTable();
                dtPos.Columns.Add("FromPos");
                dtPos.Columns.Add("ToPos");
                if (radioGroupSelection.SelectedIndex == 0)
                {
                    this.Hide();
                    if (_ISMAMOChecked)
                    {
                        rptProposalwithoutMAMO rptMA = new rptProposalwithoutMAMO(_ProjectID, dtPos, "Complete", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rptMA);
                        rptMA.Parameters["ProjectID"].Value = _ProjectID;
                        rptMA.Parameters["ReportName"].Value = txtReportName.Text;
                        rptMA.Parameters["ReportDate"].Value = dtpReportDate.DateTime;
                        printTool.ShowRibbonPreview();
                    }
                    else
                    {
                        rptProposalCommon rpt = new rptProposalCommon(_ProjectID, dtPos, "Complete", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = _ProjectID;
                        rpt.Parameters["ReportName"].Value = txtReportName.Text;
                        rpt.Parameters["ReportDate"].Value = dtpReportDate.DateTime;
                        printTool.ShowRibbonPreview();
                    }
                    this.Close();
                }
                else if (radioGroupSelection.SelectedIndex == 1)
                {
                    if (gvAddRemovePositions.RowCount == 0)
                    {
                        if (Utility._IsGermany == true)
                        {
                            XtraMessageBox.Show("Bitte machen Sie VON / BIS Angaben.");
                        }
                        else
                        {
                            XtraMessageBox.Show("Please Add From and To values.");
                        }
                        return;
                    }
                    string tfrom = null;
                    string tTo = null;
                    foreach (DataGridViewRow dr in gvAddRemovePositions.Rows)
                    {
                        DataRow drPos = dtPos.NewRow();
                        tfrom = dr.Cells[0].Value.ToString();
                        tTo = dr.Cells[1].Value.ToString();
                        string _fromParent = string.Empty;
                        string _ToParent = string.Empty;
                        if (tfrom.Contains("."))
                            _fromParent = tfrom.Substring(0, tfrom.IndexOf('.'));
                        if (tTo.Contains("."))
                            _ToParent = tTo.Substring(0, tTo.IndexOf('.'));
                        if (_fromParent != _ToParent)
                        {
                            if (Utility._IsGermany)
                                throw new Exception("Bitte geben Sie den gleichen Parent-Level ein..!");
                            else
                                throw new Exception("Please enter the same Parent level..!");
                        }
                        drPos["fromPos"] = tfrom.Replace(',', '.');
                        drPos["toPos"] = tTo.Replace(',', '.');
                        dtPos.Rows.Add(drPos);
                    }

                    this.Hide();
                    if (_ISMAMOChecked)
                    {
                        rptProposalwithoutMAMO rptMA = new rptProposalwithoutMAMO(_ProjectID, dtPos, "Title", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rptMA);
                        rptMA.Parameters["ProjectID"].Value = _ProjectID;
                        rptMA.Parameters["ReportName"].Value = txtReportName.Text;
                        rptMA.Parameters["ReportDate"].Value = dtpReportDate.DateTime;
                        printTool.ShowRibbonPreview();
                    }
                    else
                    {
                        rptProposalCommon rpt = new rptProposalCommon(_ProjectID, dtPos, "Title", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = _ProjectID;
                        rpt.Parameters["ReportName"].Value = txtReportName.Text;
                        rpt.Parameters["ReportDate"].Value = dtpReportDate.DateTime;
                        printTool.ShowRibbonPreview();
                    }
                    this.Close();
                }
                else if (radioGroupSelection.SelectedIndex == 2)
                {
                    this.Hide();
                    if (_ISMAMOChecked)
                    {
                        rptProposalwithoutMAMO rptMA = new rptProposalwithoutMAMO(_ProjectID, dtPos, "LVSection", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rptMA);
                        rptMA.Parameters["ProjectID"].Value = _ProjectID;
                        rptMA.Parameters["ReportName"].Value = txtReportName.Text;
                        rptMA.Parameters["ReportDate"].Value = dtpReportDate.DateTime;
                        printTool.ShowRibbonPreview();
                    }
                    else
                    {
                        rptProposalCommon rpt = new rptProposalCommon(_ProjectID, dtPos, "LVSection", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = _ProjectID;
                        rpt.Parameters["ReportName"].Value = txtReportName.Text;
                        rpt.Parameters["ReportDate"].Value = dtpReportDate.DateTime;
                        printTool.ShowRibbonPreview();
                    }
                    this.Close();
                }                             
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmReportSetting_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjBReport == null)
                    ObjBReport = new BReportDesign();
                if (ObjEReport == null)
                    ObjEReport = new EReportDesign();
                ObjBReport.GetReportSettings(ObjEReport);
                if (ObjEReport.dtReportSettings.Rows.Count > 0)
                {
                    BindData();
                }
                FillLVSection();
                txtReportName.Text = "ANGEBOT";
                dtpReportDate.DateTime = DateTime.Now;
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
                if (objBGAEB == null)
                    objBGAEB = new BGAEB();
                DataTable dtLVSection = new DataTable();
                cmbLVSection.Properties.Items.Clear();
                dtLVSection = objBGAEB.GetLVSection(_ProjectID);
                foreach (DataRow dr in dtLVSection.Rows)
                {
                    if (Utility.LVSectionEditAccess == "7")
                    {
                        if (Convert.ToString(dr["LVSection"]).ToLower() == "ha")
                            cmbLVSection.Properties.Items.Add(dr["LVSection"]);
                    }
                    else
                        cmbLVSection.Properties.Items.Add(dr["LVSection"]);
                }
                cmbLVSection.SetEditValue("HA");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParseReportSettings()
        {
            try
            {
                if(radioGroupSorting.SelectedIndex==0)
                {
                    ObjEReport.LVPosition = true;
                }
                if (radioGroupSorting.SelectedIndex == 1)
                {
                    ObjEReport.ArticlNr = true;
                }
                if (radioGroupSorting.SelectedIndex == 2)
                {
                    ObjEReport.Lieferant = true;
                }
                if (radioGroupSorting.SelectedIndex == 3)
                {
                    ObjEReport.Fabrikat = true;
                }
                if (radioGroupShowText.SelectedIndex==0)
                {
                    ObjEReport.LangText = true;
                }
                if (radioGroupShowText.SelectedIndex == 1)
                {
                    ObjEReport.KurzText = true;
                }
                if (radioGroupShowText.SelectedIndex == 2)
                {
                    ObjEReport.KurzAnLangText = true;
                }

                foreach (CheckedListBoxItem i in chkSelectOptions.CheckedItems)
                {
                    string _value = i.Value.ToString();

                    if (_value =="sender")
                    {
                        ObjEReport.Sender = true;
                    }
                    if (_value=="menge")
                    {
                        ObjEReport.Menge = true;
                    }
                    if (_value=="GB")
                    {
                        ObjEReport.GB = true;
                    }
                    if (_value=="prices")
                    {
                        ObjEReport.Prices = true;
                    }
                    if (_value=="EP")
                    {
                        ObjEReport.EP = true;
                    }
                    if (_value == "MAMO")
                    {
                        ObjEReport.MAMO = true;
                        _ISMAMOChecked = true;
                    }
                }                
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void BindData()
        {
            try
            {
                bool _values = false;
                foreach (DataRow row in ObjEReport.dtReportSettings.Rows)
                {
                    //Sorting
                    if (bool.TryParse(row["LVPosition"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 0;
                        }
                    }
                    if (bool.TryParse(row["Fabrikat"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 3;
                        }
                    }
                    if (bool.TryParse(row["ArticleNr"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 1;
                        }
                    }
                    if (bool.TryParse(row["LieferantMA"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 2;
                        }
                    }
                    //Select Text
                    if (bool.TryParse(row["LangText"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupShowText.SelectedIndex = 0;
                        }
                    }
                    if (bool.TryParse(row["KurzText"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupShowText.SelectedIndex = 1;
                        }
                    }
                    if (bool.TryParse(row["KurzAndLangText"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupShowText.SelectedIndex = 2;
                        }
                    }
                    //Selection Option
                    if (bool.TryParse(row["Sender"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(0, true);
                        }
                    }
                    if (bool.TryParse(row["Menge"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(1, true);
                        }
                    }
                    if (bool.TryParse(row["GB"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(2, true);
                        }
                    }
                    if (bool.TryParse(row["EP"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(4, true);
                        }
                    }
                    if (bool.TryParse(row["Prices"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(3, true);
                        }
                    }
                    if (bool.TryParse(row["MAMO"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(5, true);                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void radioGroupSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupSelection.SelectedIndex == 0)
                {
                    gvAddRemovePositions.Enabled = false;
                    cmbLVSection.Properties.ReadOnly = true;
                }
                else if (radioGroupSelection.SelectedIndex == 1)
                {
                    gvAddRemovePositions.Enabled = true;
                    cmbLVSection.Properties.ReadOnly = true;
                }
                else if (radioGroupSelection.SelectedIndex == 2)
                {
                    gvAddRemovePositions.Enabled = false;
                    cmbLVSection.Properties.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvAddRemovePositions_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.contextMenuStrip1.Show(this.gvAddRemovePositions, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                gvAddRemovePositions.Rows.Add();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ToolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvAddRemovePositions.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow item in this.gvAddRemovePositions.SelectedRows)
                    {
                        gvAddRemovePositions.Rows.RemoveAt(item.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

    }
}