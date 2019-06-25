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
using DataAccess;

namespace OTTOPro
{
    public partial class frmType : DevExpress.XtraEditors.XtraForm
    {
        EArticles ObjEArticle = null;
        BArticles ObjBArticle = null;
        DArticles ObjDArticle = null;
        List<Control> ReqFields = new List<Control>();

        public frmType()
        {
            InitializeComponent();
        }

        private void frmType_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utility.ArticleDataAccess == "7")
                    btnSave.Enabled = false;
                    
                if (ObjEArticle == null)
                    ObjEArticle = new EArticles();
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
                ObjEArticle = ObjBArticle.GetTyp(ObjEArticle);

                ObjEArticle.dtWG.TableName = "WG";
                cmbWGWA.Properties.DataSource = ObjEArticle.dtWG;
                cmbWGWA.Properties.ValueMember = "WGID";
                cmbWGWA.Properties.DisplayMember = "WGWADesc";
                
                cmbWI.Properties.DataSource = ObjEArticle.dtWI;
                cmbWI.Properties.ValueMember = "WIID";
                cmbWI.Properties.DisplayMember = "WI";
                cmbWI.CascadingOwner = cmbWGWA;

                cmbSupplier.Properties.DataSource = ObjEArticle.dtSupplier;
                cmbSupplier.Properties.ValueMember = "SupplierID";
                cmbSupplier.Properties.DisplayMember = "FullName";

                ReqFields.Add(txtTyp);
                ReqFields.Add(cmbWGWA);
                ReqFields.Add(cmbWI);
                ReqFields.Add(cmbSupplier);

                BindTypeData();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindTypeData()
        {
            try
            {
                gcTyp.DataSource = ObjEArticle.dtTyp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate())
                    return;
                int iValue = 0;
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
                if (ObjEArticle == null)
                    ObjEArticle = new EArticles();
                ObjEArticle.Typ = txtTyp.Text;
                if (cmbWI.EditValue != null)
                    ObjEArticle.WIID = Convert.ToInt32(cmbWI.EditValue);
                if (cmbSupplier.EditValue != null)
                    ObjEArticle.SupplierID = Convert.ToInt32(cmbSupplier.EditValue);
                ObjEArticle = ObjBArticle.SaveTyp(ObjEArticle);
                iValue = ObjEArticle.TypID;
                BindTypeData();
                frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern von TYP");
                Utility.Setfocus(gvTyp, "TypID", iValue);
                txtTyp.Text = string.Empty;
                ObjEArticle.TypID = -1;
                txtTyp.Focus();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvTyp_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gvDeleteTyp_Click));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDeleteTyp_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvTyp.GetFocusedRowCellValue("TypID") != null)
                {
                    int IValue = 0;
                    if (int.TryParse(Convert.ToString(gvTyp.GetFocusedRowCellValue("TypID")), out IValue))
                    {
                        var dlgResult = XtraMessageBox.Show("Sind Sie sicher, dass Sie den ausgewählten TYP (Artikelstammdaten) löschen möchten?", "Frage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Convert.ToString(dlgResult) == "Yes")
                        {
                            if (ObjEArticle == null)
                                ObjEArticle = new EArticles();
                            ObjEArticle.TypID = IValue;
                            if (ObjDArticle == null)
                                ObjDArticle = new DArticles();
                            ObjDArticle.DeleteTyp(ObjEArticle);
                            gvTyp.DeleteSelectedRows();
                        }
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