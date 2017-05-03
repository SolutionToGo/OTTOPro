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

namespace OTTOPro
{
    public partial class frmUpdateSupplierProposal : DevExpress.XtraEditors.XtraForm
    {
        ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = new BSupplier();
        private int _ProjectID = 0;
        DataTable dtTemp = null;

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
                        dtTemp = ObjESupplier.dtPositions.Copy();
                        ObjESupplier.dtUpdateSupplierPrice = ObjESupplier.dtPositions.Copy();
                        foreach (DataColumn c in dtTemp.Columns)
                        {
                            if (c.ColumnName != "PositionID" && c.ColumnName != "Cheapest")
                                ObjESupplier.dtUpdateSupplierPrice.Columns.Remove(c.ColumnName);
                        }
                        ObjESupplier.dtUpdateSupplierPrice.Columns.Add("Fabrikate", typeof(string));
                        ObjESupplier.dtUpdateSupplierPrice.Columns.Add("Supplier", typeof(string));
                        ObjESupplier.dtUpdateSupplierPrice.Columns.Add("Multi1", typeof(decimal));
                        ObjESupplier.dtUpdateSupplierPrice.Columns.Add("Multi2", typeof(decimal));
                        ObjESupplier.dtUpdateSupplierPrice.Columns.Add("Multi3", typeof(decimal));
                        ObjESupplier.dtUpdateSupplierPrice.Columns.Add("Multi4", typeof(decimal));
                        gcSupplier.DataSource = ObjESupplier.dtPositions;
                        int Columncount = ObjESupplier.dtPositions.Columns.Count;
                        gvSupplier.Columns.ColumnByFieldName("SupplierProposalID").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("PositionID").Visible = false;
                        gvSupplier.Columns.ColumnByFieldName("PID").Visible = false;
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
                ObjESupplier = ObjBSupplier.UpdateSupplierPrice(ObjESupplier);
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

                if (ObjESupplier.dtUpdateSupplierPrice != null)
                {
                    txtNewFabrikate.Text = ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Fabrikate"] == DBNull.Value ? ""
                        : ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Fabrikate"].ToString();
                    txtNewSupplierName.Text = ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Supplier"] == DBNull.Value ? ""
                        : ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Supplier"].ToString();
                    txtNewMulti1.Text = ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi1"] == DBNull.Value ?
                            ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi1"].ToString()
                        : ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi1"].ToString();
                    txtNewMulti2.Text = ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi2"] == DBNull.Value ?
                        ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi2"].ToString()
                        : ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi2"].ToString();
                    txtNewMulti3.Text = ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi3"] == DBNull.Value ?
                        ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi3"].ToString()
                        : ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi3"].ToString();
                    txtNewMulti4.Text = ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi4"] == DBNull.Value ?
                        ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi4"].ToString()
                        : ObjESupplier.dtUpdateSupplierPrice.Rows[iRowindex]["Multi4"].ToString();
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
                if (ObjESupplier.dtUpdateSupplierPrice != null)
                {
                    int iRowIndex = gvSupplier.FocusedRowHandle;
                    ObjESupplier.dtUpdateSupplierPrice.Rows[iRowIndex]["Fabrikate"] = txtNewFabrikate.Text;
                    ObjESupplier.dtUpdateSupplierPrice.Rows[iRowIndex]["Supplier"] = txtNewSupplierName.Text;
                    ObjESupplier.dtUpdateSupplierPrice.Rows[iRowIndex]["Multi1"] = txtNewMulti1.Text;
                    ObjESupplier.dtUpdateSupplierPrice.Rows[iRowIndex]["Multi2"] = txtNewMulti2.Text;
                    ObjESupplier.dtUpdateSupplierPrice.Rows[iRowIndex]["Multi3"] = txtNewMulti3.Text;
                    ObjESupplier.dtUpdateSupplierPrice.Rows[iRowIndex]["Multi4"] = txtNewMulti4.Text;
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
                if (e.Column.ColumnType == typeof(bool) && Convert.ToBoolean(e.Value) == true)
                {
                    int iIvalue = e.RowHandle;
                    string strFieldName = e.Column.FieldName;
                    foreach (DataColumn dc in ObjESupplier.dtPositions.Columns)
                    {
                        if (dc.DataType == typeof(bool) && dc.ColumnName != strFieldName)
                        {
                            ObjESupplier.dtPositions.Rows[iIvalue][dc.ColumnName] = false;
                        }
                    }
                    string strNewValue = e.Column.FieldName.Replace("Check", "");
                    txtNewSupplierName.Text = strNewValue;
                    ObjESupplier.dtPositions.Rows[iIvalue]["Cheapest"] = ObjESupplier.dtPositions.Rows[iIvalue][strNewValue] == DBNull.Value ?
                        0 : ObjESupplier.dtPositions.Rows[iIvalue][strNewValue];
                    ObjESupplier.dtUpdateSupplierPrice.Rows[iIvalue]["Cheapest"] = ObjESupplier.dtPositions.Rows[iIvalue][strNewValue] == DBNull.Value ?
                        0 : ObjESupplier.dtPositions.Rows[iIvalue][strNewValue];
                    btnSaveTemparary_Click(null, null);
                    ObjESupplier.dtPositions.AcceptChanges();
                    ObjESupplier.dtUpdateSupplierPrice.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}
