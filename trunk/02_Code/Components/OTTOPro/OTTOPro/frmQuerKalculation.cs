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
using OTTOPro.Report_Design;
using DevExpress.XtraReports.UI;
using BL;

namespace OTTOPro
{
    public partial class frmQuerKalculation : DevExpress.XtraEditors.XtraForm
    {
        int ProjectID = 0;
        int version = 1;
        BGAEB objBGAEB = null;
        public string stRaster = string.Empty;
        public frmQuerKalculation()
        {
            InitializeComponent();
        }

        public frmQuerKalculation(int _PID ,int _version = 1)
        {
            InitializeComponent();
            ProjectID = _PID;
            version = _version;
        }

        private void gvAddRemovePositions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(DataGrid_KeyPress);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        // user defined event named as DataGrid_KeyPress
        private void DataGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (radioGroupSelection.SelectedIndex == 1)
                {
                    if ((e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = false;
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

        private void radioGroupSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupSelection.SelectedIndex == 0)
                {
                    gvAddRemovePositions.Enabled = false;
                    cmbLVSection.Enabled = false;
                }
                else if (radioGroupSelection.SelectedIndex == 1)
                {
                    gvAddRemovePositions.Enabled = true;
                    cmbLVSection.Enabled = false;
                }
                else if (radioGroupSelection.SelectedIndex == 2)
                {
                    gvAddRemovePositions.Enabled = false;
                    cmbLVSection.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPos = new DataTable();
                dtPos.Columns.Add("FromPos");
                dtPos.Columns.Add("ToPos");
                if (radioGroupSelection.SelectedIndex == 0)
                {
                    this.Hide();
                    if (version == 1)
                    {
                        rptQuerKalkulation rpt = new rptQuerKalkulation(ProjectID, dtPos, "Complete", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = ProjectID;
                        rpt.Parameters["UsrName"].Value = Utility.FirstName;
                        rpt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                        printTool.ShowRibbonPreview();
                    }else
                    {
                        rptQuercalcV2 rpt = new rptQuercalcV2(ProjectID, dtPos, "Complete", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = ProjectID;
                        rpt.Parameters["UsrName"].Value = Utility.FirstName;
                        rpt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
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
                        drPos["fromPos"] = Utility.PrepareOZ(tfrom.Replace(',', '.'),stRaster);
                        drPos["toPos"] = Utility.PrepareOZ(tTo.Replace(',', '.'),stRaster);
                        dtPos.Rows.Add(drPos);
                    }

                    this.Hide();
                    if (version == 1)
                    {
                        rptQuerKalkulation rpt = new rptQuerKalkulation(ProjectID, dtPos, "Title", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = ProjectID;
                        rpt.Parameters["UsrName"].Value = Utility.FirstName;
                        rpt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                        printTool.ShowRibbonPreview();
                    }
                    else
                    {
                        rptQuercalcV2 rpt = new rptQuercalcV2(ProjectID, dtPos, "Title", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = ProjectID;
                        rpt.Parameters["UsrName"].Value = Utility.FirstName;
                        rpt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                        printTool.ShowRibbonPreview();
                    }
                    this.Close();
                }
                else if (radioGroupSelection.SelectedIndex == 2)
                {
                    this.Hide();
                    if (version == 1)
                    {
                        rptQuerKalkulation rpt = new rptQuerKalkulation(ProjectID, dtPos, "LVSection", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = ProjectID;
                        rpt.Parameters["UsrName"].Value = Utility.FirstName;
                        rpt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                        printTool.ShowRibbonPreview();
                    }
                    else
                    {
                        rptQuercalcV2 rpt = new rptQuercalcV2(ProjectID, dtPos, "LVSection", cmbLVSection.Text);
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        rpt.Parameters["ProjectID"].Value = ProjectID;
                        rpt.Parameters["UsrName"].Value = Utility.FirstName;
                        rpt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
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

        private void frmQuerKalculation_Load(object sender, EventArgs e)
        {
            if (objBGAEB == null)
                objBGAEB = new BGAEB();
            DataTable dtLVSection = new DataTable();
            cmbLVSection.Properties.Items.Clear();
            dtLVSection = objBGAEB.GetLVSection(ProjectID);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}