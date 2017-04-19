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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace OTTOPro
{
    public partial class frmDeliveryNotes : DevExpress.XtraEditors.XtraForm
    {
        public EDeliveryNotes ObjEDeliveryNotes = null;
        public BDeliveryNotes ObjBDeliveryNotes = null;
        GridHitInfo downHitInfo = null;
        private int _ProjectID = -1;
        private int _BlattNumber = 0;
        private string strBlattNumber = string.Empty;
        private int SNO = 1;
        private string strTemp = string.Empty;

        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }

        public frmDeliveryNotes()
        {
            InitializeComponent();
        }

        private void frmDeliveryNotes_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjEDeliveryNotes == null)
                    ObjEDeliveryNotes = new EDeliveryNotes();
                if (ObjBDeliveryNotes == null)
                    ObjBDeliveryNotes = new BDeliveryNotes();
                chkActiveDelivery.Checked = true;
                strTemp = strBlattNumber;
                btnNewBlattNumber_Click(null, null);
                ObjEDeliveryNotes.ProjectID = _ProjectID;
                ObjEDeliveryNotes = ObjBDeliveryNotes.GetPositions(ObjEDeliveryNotes);
                ObjEDeliveryNotes = ObjBDeliveryNotes.GetNonActiveDelivery(ObjEDeliveryNotes);
                gcPositions.DataSource = ObjEDeliveryNotes.dtPositions;
                if (ObjEDeliveryNotes.dtNonActivedelivery.Rows.Count > 0)
                {
                    txtDeliveryNumber.Text = ObjEDeliveryNotes.DeliveryNumber;
                    chkActiveDelivery.Checked = false;
                    _BlattNumber = ObjEDeliveryNotes.BlattNumber;
                    strBlattNumber = ObjEDeliveryNotes.BlattName;
                    gcDelivery.DataSource = ObjEDeliveryNotes.dtNonActivedelivery;
                }
                else
                {
                    gcDelivery.DataSource = ObjEDeliveryNotes.dtPositions.Clone();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcPositions_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcPositions_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (gvDelivery.RowCount == 0)
                {
                    frmTextDialog Obj = new frmTextDialog();
                    Obj.NewLVSection = strBlattNumber;
                    Obj.ShowDialog();
                    if (Obj.IsSave)
                        strBlattNumber = Obj.NewLVSection;
                    else
                        return;
                }
                GridControl grid = sender as GridControl;
                DataTable table = grid.DataSource as DataTable;
                DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
                if (row != null && table != null && row.Table != table)
                {
                    DataRow[] BlattRows = table.Select("BlattNumber = '" + strBlattNumber + "'");
                    if (BlattRows.Count() > 4)
                    {
                        var result1 = MessageBox.Show("Blatt Is Full, Do You Want to Continue..?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1.ToString().ToLower() == "yes")
                        {
                            SNO = 1;
                            btnNewBlattNumber_Click(null, null);
                            frmTextDialog Obj = new frmTextDialog();
                            Obj.NewLVSection = strBlattNumber;
                            Obj.ShowDialog();
                            if (Obj.IsSave)
                                strBlattNumber = Obj.NewLVSection;
                            else
                            {
                                strBlattNumber = strTemp;
                                _BlattNumber--;
                                return;
                            }
                        }
                        else
                            return;
                    }
                    object strPositionID = row["PositionID"].ToString();
                    DataRow[] foundRows = table.Select("PositionID = '" + strPositionID + "' AND BlattNumber = '" + strBlattNumber + "'");
                    if (foundRows.Count() <= 0)
                    {
                        DataRow drTemp = table.NewRow();
                        drTemp.ItemArray = row.ItemArray.Clone() as object[];
                        drTemp["BlattNumber"] = strBlattNumber;
                        drTemp["Menge"] = 0;
                        drTemp["SNO"] = SNO;
                        table.Rows.Add(drTemp);
                        SNO++;
                        Utility.Setfocus(gvDelivery, "PositionID", Convert.ToInt32(strPositionID));
                    }
                    else
                        throw new Exception("Position Already Exists in Blatt");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvPositions_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Button == MouseButtons.Left && downHitInfo != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                        downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                        view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                        downHitInfo = null;
                        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvPositions_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                downHitInfo = null;
                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                if (Control.ModifierKeys != Keys.None) return;
                if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                    downHitInfo = hitInfo;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnNewBlattNumber_Click(object sender, EventArgs e)
        {
            try
            {
                _BlattNumber++;
                strTemp = strBlattNumber;
                string strValue = _BlattNumber.ToString().PadLeft(3, '0');
                strBlattNumber = "Blatt " + strValue;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDelivery_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvDelivery.FocusedColumn != null)
                {
                    string strPosition = gvDelivery.GetFocusedRowCellValue("Position_OZ") == DBNull.Value ? "" : gvDelivery.GetFocusedRowCellValue("Position_OZ").ToString();
                    lblSelectedLVPosition.Text = "Selected LV Position : " + strPosition;
                    txtOrderedQnty.Text = gvDelivery.GetFocusedRowCellValue("OrderedQuantity") == DBNull.Value ? "" : gvDelivery.GetFocusedRowCellValue("OrderedQuantity").ToString();
                    txtDeliveredQnty.Text = gvDelivery.GetFocusedRowCellValue("DeliveredQuantity") == DBNull.Value ? "" : gvDelivery.GetFocusedRowCellValue("DeliveredQuantity").ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDeliveryNumber.Text))
                    throw new Exception("Please Enter Delivery Number");
                if (gvDelivery.RowCount == 0)
                    throw new Exception("Select Positions for Delivery");
                if (!chkActiveDelivery.Checked)
                {
                    string strConfirmation = XtraMessageBox.Show("Do you want to save it as non active delivery..?", "Question"
                        , MessageBoxButtons.OKCancel, MessageBoxIcon.Question).ToString();
                    if(strConfirmation.ToLower() == "cancel")
                    {
                        return;
                    }
                }
                if (ObjEDeliveryNotes == null)
                    ObjEDeliveryNotes = new EDeliveryNotes();
                if (ObjBDeliveryNotes == null)
                    ObjBDeliveryNotes = new BDeliveryNotes();
                ObjEDeliveryNotes.DeliveryNumber = txtDeliveryNumber.Text;
                ObjEDeliveryNotes.ISActiveDelivery = chkActiveDelivery.Checked == true ? true : false;
                DataTable table = gcDelivery.DataSource as DataTable;

                DataTable Temp = table.Copy();
                Temp.Columns.Remove("Position_OZ");
                Temp.Columns.Remove("PositionKZ");
                Temp.Columns.Remove("Ordered");
                Temp.Columns.Remove("ShortDescription");
                Temp.Columns.Remove("OrderedQuantity");
                Temp.Columns.Remove("RemainingQuantity");
                Temp.Columns.Remove("DeliveredQuantity");
                Temp.Columns.Remove("LVSection");
                Temp.Columns.Remove("LVStatus");
                ObjEDeliveryNotes.dtDelivery = Temp;

                ObjEDeliveryNotes = ObjBDeliveryNotes.SaveDelivery(ObjEDeliveryNotes);
                Utility.ShowSucces(ObjEDeliveryNotes.DeliveryNumber + "Saved Successfully");
                this.Close();
            }
            catch (Exception ex) 
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDelivery_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                double dValue = 0;
                double OrderedQuantity = 0;
                double RemainingQuantity = 0;
                double notSavedQnty =0;
                double AvailedQnty = 0;
                string sPositionID = gvDelivery.GetFocusedRowCellValue("PositionID").ToString();
                if(double.TryParse(gvDelivery.GetFocusedRowCellValue("OrderedQuantity").ToString(),out dValue))
                    OrderedQuantity = dValue;
                if(double.TryParse(gvDelivery.GetFocusedRowCellValue("RemainingQuantity").ToString(),out dValue))
                    RemainingQuantity = dValue;
                DataTable table = gcDelivery.DataSource as DataTable;
                notSavedQnty = Convert.ToDouble(table.Compute("SUM(Menge)", "PositionID = " + sPositionID));
                AvailedQnty = RemainingQuantity + (OrderedQuantity * 0.1);
                if (notSavedQnty > AvailedQnty)
                {
                    XtraMessageBox.Show("Total Quantity Exceeding Ordered Quantity");
                    gvDelivery.SetFocusedRowCellValue("Menge", 0);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}