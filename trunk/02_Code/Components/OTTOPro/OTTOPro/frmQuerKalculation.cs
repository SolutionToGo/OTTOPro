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

namespace OTTOPro
{
    public partial class frmQuerKalculation : DevExpress.XtraEditors.XtraForm
    {
        int ProjectID = 0;
        public frmQuerKalculation()
        {
            InitializeComponent();
        }

        public frmQuerKalculation(int _PID)
        {
            InitializeComponent();
            ProjectID = _PID;
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
                //if (e.Button == MouseButtons.Right)
                //{
                //    this.contextMenuStrip1.Show(this.gvAddRemovePositions, e.Location);
                //    contextMenuStrip1.Show(Cursor.Position);
                //}
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
               // gvAddRemovePositions.Rows.Add();
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
                //if (this.gvAddRemovePositions.SelectedRows.Count > 0)
                //{
                //    foreach (DataGridViewRow item in this.gvAddRemovePositions.SelectedRows)
                //    {
                //        gvAddRemovePositions.Rows.RemoveAt(item.Index);
                //    }
                //}
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
                   // gvAddRemovePositions.Enabled = false;
                }
                else
                {
                   // gvAddRemovePositions.Enabled = true;
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
                if (radioGroupSelection.SelectedIndex == 0)
                {
                    DataTable dtPos = new DataTable();
                    dtPos.Columns.Add("FromPos");
                    dtPos.Columns.Add("ToPos");

                    this.Hide();
                    rptQuerKalkulation rpt = new rptQuerKalkulation(ProjectID, dtPos, "Complete");
                    ReportPrintTool printTool = new ReportPrintTool(rpt);
                    rpt.Parameters["ProjectID"].Value = ProjectID;
                    printTool.ShowRibbonPreview();
                    this.Close();
                }
                //else
                //{
                //    if (gvAddRemovePositions.RowCount == 0)
                //    {
                //        if (Utility._IsGermany == true)
                //        {
                //            XtraMessageBox.Show("Bitte machen Sie VON / BIS Angaben.");
                //        }
                //        else
                //        {
                //            XtraMessageBox.Show("Please Add From and To values.");
                //        }
                //        return;
                //    }
                //    DataTable dtPos = new DataTable();
                //    dtPos.Columns.Add("FromPos");
                //    dtPos.Columns.Add("ToPos");

                //    string tfrom = null;
                //    string tTo = null;
                //    foreach (DataGridViewRow dr in gvAddRemovePositions.Rows)
                //    {
                //        DataRow drPos = dtPos.NewRow();
                //        tfrom = dr.Cells[0].Value.ToString();
                //        tTo = dr.Cells[1].Value.ToString();
                //        string _fromParent = string.Empty;
                //        string _ToParent = string.Empty;
                //        if (tfrom.Contains("."))
                //            _fromParent = tfrom.Substring(0, tfrom.IndexOf('.'));
                //        if (tTo.Contains("."))
                //            _ToParent = tTo.Substring(0, tTo.IndexOf('.'));
                //        if (_fromParent != _ToParent)
                //        {
                //            if (Utility._IsGermany)
                //                throw new Exception("Bitte geben Sie den gleichen Parent-Level ein..!");
                //            else
                //                throw new Exception("Please enter the same Parent level..!");
                //        }
                //        drPos["fromPos"] = tfrom.Replace(',', '.');
                //        drPos["toPos"] = tTo.Replace(',', '.');
                //        dtPos.Rows.Add(drPos);
                //    }

                //    this.Hide();
                //    rptQuerKalkulation rpt = new rptQuerKalkulation(ProjectID, dtPos, "Title");
                //    ReportPrintTool printTool = new ReportPrintTool(rpt);
                //    rpt.Parameters["ProjectID"].Value = ProjectID;
                //    printTool.ShowRibbonPreview();
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


    }
}