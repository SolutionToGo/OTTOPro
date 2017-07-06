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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace OTTOPro
{
    public partial class frmArticlesData : DevExpress.XtraEditors.XtraForm
    {
        EArticles ObjEArticle = null;
        BArticles ObjBArticle = null;
        private bool _IsNew = false;
        public frmArticlesData()
        {
            InitializeComponent();
        }
        private bool _IsSave;
        private bool _IsSaveDimension = false;
        

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (ObjEArticle == null)
                ObjEArticle = new EArticles();
            _IsNew = true;
            ObjEArticle.WGID = -1;
            ObjEArticle.WIID = -1;
            txtWI.Text = string.Empty;
            txtWIDescription.Text = string.Empty;
            txtFabrikat.Text = string.Empty;
            txtTyp.Text = string.Empty;
            txtLiferent.Text = string.Empty;
            txtRabattgruppe.Text = string.Empty;
            txtDimension.Text = string.Empty;
            cmbME.SelectedIndex = cmbME.Properties.Items.IndexOf("h");
            txtMasseinheit.Text = string.Empty;
            txtTextKZ.Text = string.Empty;
            txtremark.Text = string.Empty;
            txtMulti1.Text = "1";
            txtMulti2.Text = "1";
            txtMulti3.Text = "1";
            txtMulti4.Text = "1";
            txtDatanormNr.Text = string.Empty;
            dateEditGultigkeit.DateTime = DateTime.Now;
            lblArticle.Text = "Artikelübersicht zu : ";
            BindDimensions(ObjEArticle.WIID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int _WGID = 0;
                int _WIID = 0;
                ParsearticleDetails();
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
                ObjBArticle.SaveArticle(ObjEArticle);
                _WGID = ObjEArticle.WGID;
                _WIID = ObjEArticle.WIID;
                BindWGdata();
                Setfocus(gvWGWA, "WGID", _WGID);
                BindWIData(ObjEArticle.WGID);
                Setfocus(gvWI, "WIID", _WIID);
                if (chkIsNew.Checked == true)
                    btnNew_Click(null, null);
                else
                {
                    _IsNew = false;
                    gvWGWA_FocusedRowChanged(null, null);
                }
                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern des Artikels");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("Article saved successfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _IsNew = false;
            chkIsNew.Checked = false;
            gvWGWA_FocusedRowChanged(null, null);
        }

        private void gvWGWA_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (_IsNew)
                    return;
                int _IDValue = 0;
                if (gvWGWA.FocusedColumn != null && gvWGWA.GetFocusedRowCellValue("WGID") != null)
                {
                    if (int.TryParse(gvWGWA.GetFocusedRowCellValue("WGID").ToString(), out _IDValue))
                    {
                        if (ObjEArticle == null)
                            ObjEArticle = new EArticles();
                        ObjEArticle.WGID = _IDValue;
                        txtWG.Text = gvWGWA.GetFocusedRowCellValue("WG") == DBNull.Value ? "" : gvWGWA.GetFocusedRowCellValue("WG").ToString();
                        txtWA.Text = gvWGWA.GetFocusedRowCellValue("WA") == DBNull.Value ? "" : gvWGWA.GetFocusedRowCellValue("WA").ToString();
                        txtWGDescription.Text = gvWGWA.GetFocusedRowCellValue("WGDescription") == DBNull.Value ? "" : gvWGWA.GetFocusedRowCellValue("WGDescription").ToString();
                        txtWADescription.Text = gvWGWA.GetFocusedRowCellValue("WADescription") == DBNull.Value ? "" : gvWGWA.GetFocusedRowCellValue("WADescription").ToString();
                        BindWIData(_IDValue);
                        gvWI_FocusedRowChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        int _WIIDValue = 0;
        private void gvWI_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (_IsNew)
                    return;
                
                if (gvWI.FocusedColumn != null && gvWI.GetFocusedRowCellValue("WIID") != null)
                {
                    if (int.TryParse(gvWI.GetFocusedRowCellValue("WIID").ToString(), out _WIIDValue))
                    {
                        ObjEArticle.WIID = _WIIDValue;
                        txtWI.Text = gvWI.GetFocusedRowCellValue("WI") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("WI").ToString();
                        txtWIDescription.Text = gvWI.GetFocusedRowCellValue("WIDescription") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("WIDescription").ToString();
                        txtFabrikat.Text = gvWI.GetFocusedRowCellValue("Fabrikate") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Fabrikate").ToString();
                        txtMasseinheit.Text = gvWI.GetFocusedRowCellValue("Masseinheit") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Masseinheit").ToString();
                        txtDimension.Text = gvWI.GetFocusedRowCellValue("Dimension") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Dimension").ToString();
                        cmbME.SelectedIndex = cmbME.Properties.Items.IndexOf(gvWI.GetFocusedRowCellValue("Menegenheit") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Menegenheit").ToString());
                        txtremark.Text = gvWI.GetFocusedRowCellValue("Remarks") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Remarks").ToString();
                        txtTextKZ.Text = gvWI.GetFocusedRowCellValue("TextKZ") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("TextKZ").ToString();
                        dateEditGultigkeit.DateTime = gvWI.GetFocusedRowCellValue("ValidityDate") == DBNull.Value ? DateTime.Now : Convert.ToDateTime(gvWI.GetFocusedRowCellValue("ValidityDate"));
                        txtMulti1.Text = gvWI.GetFocusedRowCellValue("Multi1") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Multi1").ToString();
                        txtMulti2.Text = gvWI.GetFocusedRowCellValue("Multi2") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Multi2").ToString();
                        txtMulti3.Text = gvWI.GetFocusedRowCellValue("Multi3") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Multi3").ToString();
                        txtMulti4.Text = gvWI.GetFocusedRowCellValue("Multi4") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Multi4").ToString();
                        txtDatanormNr.Text = gvWI.GetFocusedRowCellValue("DataNormNumber") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("DataNormNumber").ToString();
                        txtTyp.Text = gvWI.GetFocusedRowCellValue("Typ") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Typ").ToString();
                        txtLiferent.Text = gvWI.GetFocusedRowCellValue("FullName") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("FullName").ToString();
                        txtRabattgruppe.Text = gvWI.GetFocusedRowCellValue("Rabatt") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("Rabatt").ToString();
                        lblArticle.Text = "Artikelübersicht zu : " + txtWG.Text + "/" + txtWA.Text + "/" + txtWI.Text;
                        BindDimensions(_WIIDValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParsearticleDetails()
        {
            if (ObjEArticle == null)
                ObjEArticle = new EArticles();
            if (!string.IsNullOrEmpty(txtWG.Text.Trim()) && txtWG.Text != "0")
                ObjEArticle.WG = txtWG.Text;
            else
            {
                if(!Utility._IsGermany)
                {
                    throw new Exception("Please Enter Valid WG Value");
                }
                else
                {
                    throw new Exception("Bitte geben Sie einen zulässig Wert an für WG");
                }
                
            }
                

            if (!string.IsNullOrEmpty(txtWA.Text.Trim()) && txtWA.Text != "0")
                ObjEArticle.WA = txtWA.Text;
            else
            {
                if (!Utility._IsGermany)
                {
                    throw new Exception("Please Enter Valid WA Value");
                }
                else
                {
                    throw new Exception("Bitte geben Sie einen zulässig Wert an für WA");
                }
            }
                
            //if (!string.IsNullOrEmpty(txtWI.Text) && txtWI.Text != "0")
                ObjEArticle.WI = txtWI.Text.Trim();
            //else
            //    throw new Exception("Please Enter Valid WI Value");
        

            ObjEArticle.WGDescription = txtWGDescription.Text;
            ObjEArticle.WADescription = txtWADescription.Text;
            ObjEArticle.WIDescription = txtWIDescription.Text;
            ObjEArticle.Fabrikate = txtFabrikat.Text;
            ObjEArticle.Typ = txtTyp.Text;
            ObjEArticle.Dimension = txtDimension.Text;
            ObjEArticle.Menegenheit = cmbME.Text;
            ObjEArticle.Masseinheit = txtMasseinheit.Text;
            ObjEArticle.TextKZ = txtTextKZ.Text;
            ObjEArticle.Remarks = txtremark.Text;
            ObjEArticle.ValidityDate = dateEditGultigkeit.DateTime;
            decimal dValue = 1;
            if (decimal.TryParse(txtMulti1.Text, out dValue) && dValue != 0)
                ObjEArticle.Multi1 = dValue;                
            else
                ObjEArticle.Multi1 = 1;

            if (decimal.TryParse(txtMulti2.Text, out dValue) && dValue != 0)
                ObjEArticle.Multi2 = dValue;
            else
                ObjEArticle.Multi2 = 1;

            if (decimal.TryParse(txtMulti3.Text, out dValue) && dValue != 0)
                ObjEArticle.Multi3 = dValue;
            else
                ObjEArticle.Multi3 = 1;

            if (decimal.TryParse(txtMulti4.Text, out dValue) && dValue != 0)
                ObjEArticle.Multi4 = dValue;
            else
                ObjEArticle.Multi4 = 1;         
            ObjEArticle.DataNormNumber = txtDatanormNr.Text;
        }

        private void frmArticlesData_Load(object sender, EventArgs e)
        {
            try
            {
                if(Utility.ArticleDataAccess == "7")
                {
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;
                    btnSaveAs.Enabled = false;
                    btnCancel.Enabled = false;
                    btnAddDimension.Enabled = false;
                    chkIsNew.Enabled = false;
                }
                if (ObjEArticle == null)
                    ObjEArticle = new EArticles();
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
                dateEditGultigkeit.DateTime = DateTime.Now;
                cmbME.SelectedIndex = cmbME.Properties.Items.IndexOf("h");
                ObjBArticle.GetArticle(ObjEArticle);
                BindWGdata();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindWGdata()
        {
            try
            {
                gcWGWA.DataSource = ObjEArticle.dtWG;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindWIData(int WGID)
        {
            try
            {
                if (ObjEArticle.dtWI != null)
                {
                    DataView dvWI = ObjEArticle.dtWI.DefaultView;
                    dvWI.RowFilter = "WGID = '" + WGID + "'";
                    gcWI.DataSource = dvWI;
                    gvWI.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindDimensions(int WIID)
        {
            try
            {

                DataView dvDimensions = ObjEArticle.dtDimenstions.DefaultView;
                dvDimensions.RowFilter = "WIID = '" + WIID + "'";
                gcDimensions.DataSource = dvDimensions;
                gvDimensions.BestFitColumns();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Setfocus(GridView view, string _id, int _IdValue)
        {
            try
            {
                if (_IdValue > -1)
                {
                    int rowHandle = view.LocateByValue(_id, _IdValue);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        view.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnAddDimension_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEArticle.WIID < 0)
                {
                    if (!Utility._IsGermany)
                        throw new Exception("Please Select The Article");
                    else
                        throw new Exception("Bitte wählen Sie einen Artikel");
                }
                decimal dValue = 0;
                decimal GMulti = 1;
                if (!decimal.TryParse(txtMulti1.Text, out dValue))
                    GMulti = 1;
                else
                    GMulti = dValue;
                if (!decimal.TryParse(txtMulti2.Text, out dValue))
                    GMulti = GMulti * 1;
                else
                    GMulti = GMulti * dValue;

                if (!decimal.TryParse(txtMulti3.Text, out dValue))
                    GMulti = GMulti * 1;
                else
                    GMulti = GMulti * dValue;

                if (!decimal.TryParse(txtMulti4.Text, out dValue))
                    GMulti = GMulti * 1;
                else
                    GMulti = GMulti * dValue;
                
                ObjEArticle = new EArticles();
                ObjEArticle.DimensionID = -1;
                ObjEArticle.WIID = _WIIDValue;
                ObjEArticle.GMulti = GMulti;
                frmAddDimension frm = new frmAddDimension();
                frm.ObjEArticle = ObjEArticle;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ObjBArticle.GetArticle(ObjEArticle);
                    BindDimensions(ObjEArticle.WIID);
                    Setfocus(gvDimensions, "DimensionID", ObjEArticle.DimensionID);
                    if (Utility._IsGermany == true)
                    {
                        frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der (neuen) Abmessungen");
                    }
                    else
                    {
                        frmOTTOPro.UpdateStatus("Dimension saved successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
            finally
            {
                ObjBArticle.GetArticle(ObjEArticle);
            }
        }

        private void gvDimensions_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //try
            //{
            //    int RowHandle = e.RowHandle;
            //    SaveDimension(RowHandle);
            //}
            //catch (Exception ex)
            //{
            //    Utility.ShowError(ex);
            //}
        }

        private void gvDimensions_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!_IsSave)
                 _IsSave = true;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDimensions.RowCount == 0)
                    return;
                if (_IsSaveDimension)
                    throw new Exception("Bitte Speichern der Maße");
                frmSaveDimension Obj = new frmSaveDimension();
                Obj.ObjEArticle = ObjEArticle;
                Obj.ObjBArticle = ObjBArticle;
                Obj.strArticle = "Info's zur Aktuellen Abmessung : " + txtWG.Text + "/" + txtWA.Text + "/" + txtWI.Text;
                Obj.ShowDialog();
                ObjEArticle = Obj.ObjEArticle;
                ObjBArticle = Obj.ObjBArticle;
                BindDimensions(ObjEArticle.WIID);
                int _iWIID = ObjEArticle.WIID;
                ObjEArticle = ObjBArticle.GetArticle(ObjEArticle);
                BindWIData(ObjEArticle.WGID);
                Setfocus(gvWI, "WIID", _iWIID);
                gvWI_FocusedRowChanged(null, null);
             }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtMulti1_Leave(object sender, EventArgs e)
        {
            TextEdit textbox = (TextEdit)sender;
            decimal dValue = 0;
            if (textbox.Text == string.Empty || decimal.TryParse(textbox.Text, out dValue))
            {
                if (dValue == 0)
                {
                    textbox.Text = "1";
                }
            }
        }

        private void rpDimension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar) != '\b')
                e.Handled = true;
        }

        private void frmArticlesData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(null, null);
            }
        }

        private void gvDimensions_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    GridView view = (GridView)sender;
            //    Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //    GridHitInfo info = view.CalcHitInfo(pt);

            //    if (info.InRow || info.InRowCell)
            //    {
            //        if (gvDimensions.SelectedRowsCount == 0)
            //        {
            //            return;
            //        }
            //        if (ObjEArticle == null)
            //           ObjEArticle = new EArticles();
            //        GetDimensionDetails();
            //        frmAddDimension frm = new frmAddDimension();
            //        frm.ObjEArticle = ObjEArticle;
            //        frm.ShowDialog();
            //        if (frm.DialogResult == DialogResult.OK)
            //        {
            //            ObjBArticle.GetArticle(ObjEArticle);
            //            BindDimensions(ObjEArticle.WIID);
            //            Setfocus(gvDimensions, "DimensionID", ObjEArticle.DimensionID);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Utility.ShowError(ex);
            //}
        }

        private void GetDimensionDetails()
        {
            try
            {
                ObjEArticle.DimensionID = Convert.ToInt32(gvDimensions.GetFocusedRowCellValue("DimensionID"));
                ObjEArticle.A = gvDimensions.GetFocusedRowCellValue("A") == DBNull.Value ? "" : gvDimensions.GetFocusedRowCellValue("A").ToString();
                ObjEArticle.B = gvDimensions.GetFocusedRowCellValue("B") == DBNull.Value ? "" : gvDimensions.GetFocusedRowCellValue("B").ToString();
                ObjEArticle.L = gvDimensions.GetFocusedRowCellValue("L") == DBNull.Value ? "" : gvDimensions.GetFocusedRowCellValue("L").ToString();
                ObjEArticle.ListPrice = Convert.ToDecimal(gvDimensions.GetFocusedRowCellValue("ListPrice") == DBNull.Value ? "" : gvDimensions.GetFocusedRowCellValue("ListPrice"));
                ObjEArticle.Minuten = Convert.ToDecimal(gvDimensions.GetFocusedRowCellValue("Minuten") == DBNull.Value ? "" : gvDimensions.GetFocusedRowCellValue("Minuten"));
                ObjEArticle.GMulti = Convert.ToDecimal(gvDimensions.GetFocusedRowCellValue("GMulti") == DBNull.Value ? "" : gvDimensions.GetFocusedRowCellValue("GMulti"));
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ObjBArticle.GetArticle(ObjEArticle);
                BindDimensions(ObjEArticle.WIID);
                Setfocus(gvDimensions, "DimensionID", ObjEArticle.DimensionID);
            }
        }

        private void frmArticlesData_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (frmOTTOPro.Instance.MdiChildren.Count() == 1)
                {
                    frmOTTOPro.Instance.SetPictureBoxVisible(true);
                    frmOTTOPro.Instance.SetLableVisible(true);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

    }
}