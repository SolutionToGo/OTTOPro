﻿using System;
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
using DataAccess;

namespace OTTOPro
{
    public partial class frmArticlesData : DevExpress.XtraEditors.XtraForm
    {
        EArticles ObjEArticle = null;
        BArticles ObjBArticle = null;

        DArticles ObjDArticle = null;
        private bool _IsNew = false;
        public frmArticlesData()
        {
            InitializeComponent();
        }
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
            txtDimension.Text = string.Empty;
            cmbME.SelectedIndex = cmbME.Properties.Items.IndexOf("h");
            txtMasseinheit.Text = string.Empty;
            txtTextKZ.Text = string.Empty;
            txtremark.Text = string.Empty;
            txtDatanormNr.Text = string.Empty;
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
                        txtDatanormNr.Text = gvWI.GetFocusedRowCellValue("DataNormNumber") == DBNull.Value ? "" : gvWI.GetFocusedRowCellValue("DataNormNumber").ToString();
                        lblArticle.Text = "Artikelübersicht zu : " + txtWG.Text + "/" + txtWA.Text + "/" + txtWI.Text;
                        BindDimensions(_WIIDValue);
                        DArticles Obj = new DArticles();
                        Obj.GetTypByWIID(ObjEArticle);
                        gcTyp.DataSource = ObjEArticle.dtTyp;
                        gvTyp.BestFitColumns();
                        Utility.Setfocus(gvTyp, "RTID", ObjEArticle.RTID);
                    }
                }
                else
                {
                    gcDimensions.DataSource = null;
                    gcTyp.DataSource = null;
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
                    throw new Exception("Please Enter Valid WG Value");
                else
                    throw new Exception("Bitte geben Sie einen zulässigen Wert an für WG");
            }

            if (!string.IsNullOrEmpty(txtWA.Text.Trim()))
                ObjEArticle.WA = txtWA.Text;
            else
                ObjEArticle.WA = "0";
            ObjEArticle.WI = txtWI.Text.Trim();
            ObjEArticle.WGDescription = txtWGDescription.Text;
            ObjEArticle.WADescription = txtWADescription.Text;
            ObjEArticle.WIDescription = txtWIDescription.Text;
            ObjEArticle.Fabrikate = txtFabrikat.Text;
            ObjEArticle.Dimension = txtDimension.Text;
            ObjEArticle.Menegenheit = cmbME.Text;
            ObjEArticle.Masseinheit = txtMasseinheit.Text;
            ObjEArticle.TextKZ = txtTextKZ.Text;
            ObjEArticle.Remarks = txtremark.Text;
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
                gvWGWA.BestFitColumns();
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
                decimal GMulti = 1;
                ObjEArticle = new EArticles();
                ObjEArticle.DimensionID = -1;
                ObjEArticle.WIID = _WIIDValue;
                ObjEArticle.GMulti = GMulti;
                frmAddDimension frm = new frmAddDimension();
                frm.ObjEArticle = ObjEArticle;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
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

        private void gvDimensions_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if(gvDimensions.GetFocusedRowCellValue("DimensionID") != null)
                {
                    if (ObjEArticle == null)
                        ObjEArticle = new EArticles();
                    if (ObjDArticle == null)
                        ObjDArticle = new DArticles();
                    int IValue = 0;
                    decimal dMins = 0;
                    decimal dListPrice = 0;
                    if (int.TryParse(Convert.ToString(gvDimensions.GetFocusedRowCellValue("DimensionID")), out IValue))
                        ObjEArticle.DimensionID = IValue;
                    if (decimal.TryParse(Convert.ToString(gvDimensions.GetFocusedRowCellValue("Minuten")), out dMins))
                        ObjEArticle.Minuten = dMins;
                    if (decimal.TryParse(Convert.ToString(gvDimensions.GetFocusedRowCellValue("ListPrice")), out dListPrice))
                        ObjEArticle.ListPrice = dListPrice;
                     ObjDArticle.UpdateDimension(ObjEArticle);
                    gvWI_FocusedRowChanged(null, null);
                }
            }
            catch (Exception ex){ Utility.ShowError(ex); }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDimensions.RowCount == 0)
                    return;
                if (_IsSaveDimension)
                    throw new Exception("Bitte speichern Sie die Maße");
                frmSaveDimension Obj = new frmSaveDimension("Dimension","");
                Obj.ObjEArticle = ObjEArticle;
                Obj.ObjBArticle = ObjBArticle;
                Obj.strArticle = "Info's zur Aktuellen Abmessung : " + txtWG.Text + "/" + txtWA.Text + "/" + txtWI.Text;
                Obj.ShowDialog();
                ObjEArticle = Obj.ObjEArticle;
                ObjBArticle = Obj.ObjBArticle;
                BindDimensions(ObjEArticle.WIID);
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
            try
            {
                if (e.KeyData == Keys.Escape)
                    this.Close();
            }
            catch (Exception ex) { }
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

        private void btnValidityDate_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddType frm = new frmAddType(_WIIDValue, "ValidityDate");
                frm.ShowDialog();
                if (frm.Date != null)
                {
                    frm.Hide();
                    frmSaveDimension Objfrm = new frmSaveDimension("ValidityDate", frm.Date, _WIIDValue);
                    Objfrm.ObjEArticle = ObjEArticle;
                    Objfrm.ShowDialog();
                    frm.Close();
                    BindDimensions(ObjEArticle.WIID);
                    gvWI_FocusedRowChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtWG_Enter(object sender, EventArgs e)
        {
            try
            {
                var edit = ((DevExpress.XtraEditors.TextEdit)sender);
                BeginInvoke(new MethodInvoker(() =>
                {
                    edit.SelectionStart = 0;
                    edit.SelectionLength = edit.Text.Length;
                }));
            }
            catch (Exception ex) { }
        }

        private void gvWGWA_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gvDeleteWG_Click));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDeleteWG_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvWGWA.GetFocusedRowCellValue("WGID") != null)
                {
                    int IValue = 0;
                    if (int.TryParse(Convert.ToString(gvWGWA.GetFocusedRowCellValue("WGID")), out IValue))
                    {
                        var dlgResult = XtraMessageBox.Show("Sind Sie sicher, dass Sie den ausgewählten WG/WA Datensatz löschen möchten?", "Frage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Convert.ToString(dlgResult) == "Yes")
                        {
                            if (ObjEArticle == null)
                                ObjEArticle = new EArticles();
                            ObjEArticle.WGID = IValue;
                            if (ObjDArticle == null)
                                ObjDArticle = new DArticles();
                            ObjDArticle.DeleteWG(ObjEArticle);
                            gvWGWA.DeleteSelectedRows();
                            gvWGWA_FocusedRowChanged(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvWI_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gvDeleteWI_Click));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDeleteWI_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvWI.GetFocusedRowCellValue("WIID") != null)
                {
                    int IValue = 0;
                    if (int.TryParse(Convert.ToString(gvWI.GetFocusedRowCellValue("WIID")), out IValue))
                    {
                        var dlgResult = XtraMessageBox.Show("Sind Sie sicher, dass Sie den ausgewählten WI Datensatz löschen möchten?", "Frage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Convert.ToString(dlgResult) == "Yes")
                        {
                            if (ObjEArticle == null)
                                ObjEArticle = new EArticles();
                            ObjEArticle.WIID = IValue;
                            if (ObjDArticle == null)
                                ObjDArticle = new DArticles();
                            ObjDArticle.DeleteWI(ObjEArticle);
                            gvWI.DeleteSelectedRows();
                            gvWI_FocusedRowChanged(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDimensions_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gvDeleteDimension_Click));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDeleteDimension_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDimensions.GetFocusedRowCellValue("DimensionID") != null)
                {
                    int IValue = 0;
                    if (int.TryParse(Convert.ToString(gvDimensions.GetFocusedRowCellValue("DimensionID")), out IValue))
                    {
                        var dlgResult = XtraMessageBox.Show("Sind Sie sicher, dass Sie die ausgewählten Abmessungen löschen möchten?", "Frage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Convert.ToString(dlgResult) == "Yes")
                        {
                            if (ObjEArticle == null)
                                ObjEArticle = new EArticles();
                            ObjEArticle.DimensionID = IValue;
                            if (ObjDArticle == null)
                                ObjDArticle = new DArticles();
                            ObjDArticle.DeleteDimension(ObjEArticle);
                            gvDimensions.DeleteSelectedRows();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcWGWA_Click(object sender, EventArgs e)
        {

        }
    }
}