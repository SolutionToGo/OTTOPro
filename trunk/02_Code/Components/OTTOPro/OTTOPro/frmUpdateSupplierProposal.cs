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
using DevExpress.XtraGrid.Views.Base;

namespace OTTOPro
{
    public partial class frmUpdateSupplierProposal : DevExpress.XtraEditors.XtraForm
    {
        ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = new BSupplier();
        private int _ProjectID = 0;

        public frmUpdateSupplierProposal()
        {
            InitializeComponent();
        }

        public frmUpdateSupplierProposal(int ProjectID)
        {
            InitializeComponent();
            _ProjectID = ProjectID;
        }

        private void frmUpdateSupplierProposal_Load(object sender, EventArgs e)
        {
            FillProposalNumbers();
        }

        private void FillProposalNumbers()
        {
            try
            {
                ObjESupplier.ProjectID = _ProjectID;
                ObjESupplier = ObjBSupplier.GetProposalNumber(ObjESupplier);
                gcProposal.DataSource = ObjESupplier.dtProposal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        private void gvProposal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvProposal != null && gvProposal.GetFocusedRowCellValue("SupplierProposalID") != null)
                {
                    int iValue = 0;
                    if (int.TryParse(gvProposal.GetFocusedRowCellValue("SupplierProposalID").ToString(), out iValue))
                    {
                        gvSupplier.Columns.Clear();
                        ObjESupplier.SupplierProposalID = iValue;
                        ObjESupplier = ObjBSupplier.GetProposalPostions(ObjESupplier);
                        gcSupplier.DataSource = ObjESupplier.dtPositions;
                        int Columncount = ObjESupplier.dtPositions.Columns.Count;
                        gvSupplier.Columns.ColumnByFieldName("PositionID").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("PositionID1").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("ShortDescription").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("Menge").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("A").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("B").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("L").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("ME").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("MA_Multi1").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("MA_multi2").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("MA_multi3").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("MA_multi4").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("LiefrantMA").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("MA_listprice").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("Fabricate").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("Cheapest").VisibleIndex = Columncount - 1;
                        gvSupplier.Columns.ColumnByFieldName("Position_OZ").VisibleIndex = 0;

                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((ColumnView)gcSupplier.Views[0]).Columns)
                        {
                            if (col.FieldName.Contains("Multi") || col.FieldName.Contains("Fabricate") || col.FieldName.Contains("SupplierName"))
                            {
                                col.Visible = false;
                            }
                            else
                            {
                                if(col.FieldName.Contains("Check"))
                                {
                                    string strSupplierColumnName = col.FieldName.Replace("Check", "");
                                    int IColumnIndex = gvSupplier.Columns.ColumnByFieldName(strSupplierColumnName).VisibleIndex;
                                    col.VisibleIndex = IColumnIndex + 1;
                                }
                            }
                        }
                        gvSupplier.BestFitColumns();
                        gvSupplier_FocusedRowChanged(null, null);
                    }
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
                List<string> LBoolColumns = new List<string>();
                foreach(DataColumn dc in ObjESupplier.dtPositions.Columns)
                {
                    if (dc.ColumnName.Contains("Check"))
                        LBoolColumns.Add(dc.ColumnName);
                }
                foreach(DataRow dr in ObjESupplier.dtPositions.Rows)
                {
                    bool _isContinue = false;
                    foreach(string s in LBoolColumns)
                    {
                        if (Convert.ToBoolean(dr[s]))
                            _isContinue = true;
                    }
                    if (!_isContinue)
                        throw new Exception("Some positions are not selected to update the prices");
                   
                }
                ObjESupplier = ObjBSupplier.UpdateSupplierPrice(ObjESupplier);
                Utility.ShowSucces("Supplier Prices Updated Sucessfully");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int iRowindex = gvSupplier.FocusedRowHandle;
                if (iRowindex != null)
                {
                    txtListPrice.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_listprice"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_listprice"].ToString();
                    txtText.Rtf = ObjESupplier.dtPositions.Rows[iRowindex]["ShortDescription"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["ShortDescription"].ToString();
                    txtMenge.Text = ObjESupplier.dtPositions.Rows[iRowindex]["Menge"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["Menge"].ToString();
                    txtDim1.Text = ObjESupplier.dtPositions.Rows[iRowindex]["A"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["A"].ToString();
                    txtDim2.Text = ObjESupplier.dtPositions.Rows[iRowindex]["B"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["B"].ToString();
                    txtDim3.Text = ObjESupplier.dtPositions.Rows[iRowindex]["L"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["L"].ToString();
                    txtME.Text = ObjESupplier.dtPositions.Rows[iRowindex]["ME"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["ME"].ToString();
                    txtMulti1.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi1"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi1"].ToString();
                    txtMulti2.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi2"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi2"].ToString();
                    txtMulti3.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi3"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi3"].ToString();
                    txtMulti4.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi4"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi4"].ToString();
                    txtSupplierName.Text = ObjESupplier.dtPositions.Rows[iRowindex]["LiefrantMA"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["LiefrantMA"].ToString();
                    gvSupplier_FocusedColumnChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSaveTemparary_Click(object sender, EventArgs e)
        {
            try
            {
                string strSupliercolumnName = gvSupplier.FocusedColumn.FieldName;
                string strBoolColumnName = gvSupplier.FocusedColumn.FieldName + "Check";
                if (gvSupplier.Columns[strBoolColumnName] != null)
                {
                    int iRowIndex = gvSupplier.FocusedRowHandle;
                    ObjESupplier.PositionID = Convert.ToInt32(gvSupplier.GetFocusedRowCellValue("PositionID"));
                    ObjESupplier.SupplierProposalID = Convert.ToInt32(gvProposal.GetFocusedRowCellValue("SupplierProposalID"));
                    ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Fabricate"] = ObjESupplier.Fabrikate = txtNewFabrikate.Text;
                    ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "SupplierName"] = ObjESupplier.SupplierName = txtNewSupplierName.Text;

                    decimal dValue = 1;
                    string strName = Convert.ToString(gvSupplier.GetFocusedRowCellValue(txtNewSupplierName.Text));
                    if (decimal.TryParse(strName, out  dValue))
                        ObjESupplier.SupplierPrice = dValue;
                    else
                        ObjESupplier.SupplierPrice = 0;

                    if (decimal.TryParse(txtNewMulti1.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi1"] = ObjESupplier.Multi1 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi1"] = ObjESupplier.Multi1 = 1;

                    if (decimal.TryParse(txtNewMulti2.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi2"] = ObjESupplier.Multi2 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi2"] = ObjESupplier.Multi2 = 1;

                    if (decimal.TryParse(txtNewMulti3.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi3"] = ObjESupplier.Multi3 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi3"] = ObjESupplier.Multi3 = 1;

                    if (decimal.TryParse(txtNewMulti4.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi4"] = ObjESupplier.Multi4 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi4"] = ObjESupplier.Multi4 = 1;

                    ObjESupplier = ObjBSupplier.SaveProposaleValues(ObjESupplier);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.ColumnType == typeof(bool))
                {
                    int iIvalue = e.RowHandle;
                    string strFieldName = e.Column.FieldName;
                    ObjESupplier.dtStrings = new DataTable();
                    ObjESupplier.dtStrings.Columns.Add("Item", typeof(string));
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        foreach (DataColumn dc in ObjESupplier.dtPositions.Columns)
                        {
                            if (dc.DataType == typeof(bool) && dc.ColumnName != strFieldName)
                            {
                                ObjESupplier.dtPositions.Rows[iIvalue][dc.ColumnName] = false;
                                DataRow drNew = ObjESupplier.dtStrings.NewRow();
                                drNew["Item"] = dc.ColumnName;
                                ObjESupplier.dtStrings.Rows.Add(drNew);
                                ObjESupplier.IsSelected = true;
                            }
                        }
                    }
                    else
                        ObjESupplier.IsSelected = false;
                    ObjESupplier.dtPositions.AcceptChanges();
                    ObjESupplier.PositionID = Convert.ToInt32(gvSupplier.GetFocusedRowCellValue("PositionID"));
                    ObjESupplier.SupplierProposalID = Convert.ToInt32(gvProposal.GetFocusedRowCellValue("SupplierProposalID"));
                    ObjESupplier.SelectedColumn = strFieldName;
                    ObjESupplier = ObjBSupplier.SaveSelection(ObjESupplier);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            try
            {
                if (gvSupplier.FocusedColumn != null)
                {
                    string strSuppliercolumnName = gvSupplier.FocusedColumn.FieldName;
                    int iIndex = gvSupplier.FocusedRowHandle;
                    string strBoolColumnName = gvSupplier.FocusedColumn.FieldName + "Check";
                    if (gvSupplier.Columns[strBoolColumnName] != null)
                    {
                        string strPositionOZ = ObjESupplier.dtPositions.Rows[iIndex]["Position_OZ"] == DBNull.Value ? "" :
                            ObjESupplier.dtPositions.Rows[iIndex]["Position_OZ"].ToString();
                        gcNewValues.Text = "New Values : " + strPositionOZ + "/" + strSuppliercolumnName;
                        gcExistingValues.Text = "Existing Values : " + strPositionOZ + "/" + strSuppliercolumnName;

                        txtNewSupplierName.Text = strSuppliercolumnName;
                        txtNewFabrikate.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Fabricate"] == DBNull.Value ? "" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Fabricate"].ToString();
                        txtNewMulti1.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi1"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi1"].ToString();
                        txtNewMulti2.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi2"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi2"].ToString();
                        txtNewMulti3.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi3"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi3"].ToString();
                        txtNewMulti4.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi4"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi4"].ToString();
                    }
                    else
                    {
                        txtNewFabrikate.Text = "";
                        txtNewSupplierName.Text = "";
                        txtMulti1.Text = "1";
                        txtMulti2.Text = "1";
                        txtMulti3.Text = "1";
                        txtMulti4.Text = "1";
                        gcNewValues.Text = "New Values For Entry";
                        gcExistingValues.Text = "Existing Values";
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                int iIvalue = e.RowHandle;
                string strColumnboolField = e.Column.FieldName + "Check";
                if (gvSupplier.Columns[strColumnboolField] != null)
                {
                    List<decimal> l = new List<decimal>();
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((ColumnView)gvSupplier).Columns)
                    {
                        if (gvSupplier.Columns[col.FieldName + "Check"] != null)
                        {
                            decimal iValue = 0;
                            string str = Convert.ToString(gvSupplier.GetFocusedRowCellValue(col.FieldName));
                            if (decimal.TryParse(str, out iValue) && iValue > 0)
                            {
                                l.Add(iValue);
                            }
                        }
                    }
                    if (l != null && l.Count() > 0)
                        ObjESupplier.dtPositions.Rows[iIvalue]["Cheapest"] = l.Min();
                    else
                        ObjESupplier.dtPositions.Rows[iIvalue]["Cheapest"] = 0;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}