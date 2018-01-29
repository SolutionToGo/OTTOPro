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

namespace OTTOPro
{
    public partial class frmType : DevExpress.XtraEditors.XtraForm
    {
        EArticles ObjEArticle = null;
        BArticles ObjBArticle = null;
        bool _IsNew = false;
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

                cmbWGWA.DataSource = ObjEArticle.dtWG;
                cmbWGWA.ValueMember = "WGID";
                cmbWGWA.DisplayMember = "WGWADesc";
                
                if (cmbWGWA.SelectedValue != null)
                    BindWIData(cmbWGWA.SelectedValue);

                cmbSupplier.DataSource = ObjEArticle.dtSupplier;
                cmbSupplier.ValueMember = "SupplierID";
                cmbSupplier.DisplayMember = "FullName";

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

        private void BindWIData(Object WGID)
        {
            try
            {
                int iValue = 0;
                if (WGID != null && int.TryParse(WGID.ToString(), out iValue))
                {
                    DataView dvWI = ObjEArticle.dtWI.DefaultView;
                    dvWI.RowFilter = "WGID = '" + iValue + "'";
                    cmbWI.DataSource = dvWI;
                    cmbWI.ValueMember = "WIID";
                    cmbWI.DisplayMember = "WIDesc";
                }
            }
            catch (Exception ex)
            {
                throw;
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

        private void cmbWGWA_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbWGWA.SelectedValue != null)
                    BindWIData(cmbWGWA.SelectedValue);
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
                if (Utility.ValidateRequiredFields(ReqFields) == false)
                    return;
                int iValue = 0;
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
                if(ObjEArticle == null)
                    ObjEArticle = new EArticles();
                ObjEArticle.Typ = txtTyp.Text;
                ObjEArticle.WIID = Convert.ToInt32(cmbWI.SelectedValue);
                ObjEArticle.SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
                ObjEArticle = ObjBArticle.SaveTyp(ObjEArticle);
                iValue = ObjEArticle.TypID;
                BindTypeData();
                frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern des Typ");
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
    }
} 