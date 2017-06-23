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
using BL;
using EL;

namespace OTTOPro
{
    public partial class frmRabattGroup : DevExpress.XtraEditors.XtraForm
    {
        BArticles ObjBArticle = null;
        EArticles ObjEArticle = null;
        private bool _IsBind = true;
        List<Control> ReqFields = new List<Control>();
        public frmRabattGroup()
        {
            InitializeComponent();
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
                if (ObjEArticle == null)
                    ObjEArticle = new EArticles();
                ParseRabattDetails();
                ObjEArticle = ObjBArticle.SaveRabatt(ObjEArticle);
                iValue = ObjEArticle.RabattID;
                BindRabattData();
                Utility.Setfocus(gvRabatt, "RabattID", iValue);
                frmOTTOPro.UpdateStatus("Rabatt group Saved Successfully");
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

        private void frmRabattGroup_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjEArticle == null)
                    ObjEArticle = new EArticles();
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
                ObjEArticle = ObjBArticle.GetRabatt(ObjEArticle);
                cmbType.DataSource = ObjEArticle.dtTyp;
                cmbType.ValueMember = "TypID";
                cmbType.DisplayMember = "Typ";
                BindRabattData();
                dateEditValidityDate.DateTime = DateTime.Now;
                dateEditValidityDate.Properties.MinValue = DateTime.Now;
                cmbType_SelectedValueChanged(null, null);
                ReqFields.Add(txtRabatt);
                ReqFields.Add(cmbType);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindRabattData()
        {
            try
            {
                if (ObjEArticle == null)
                    ObjEArticle = new EArticles();
                gcRabatt.DataSource = ObjEArticle.dtRabatt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int iValue = 0;
                if (cmbType.SelectedValue != null && int.TryParse(cmbType.SelectedValue.ToString(), out iValue))
                {
                    DataRow[] drTyp = ObjEArticle.dtTyp.Select("TypID = '" + iValue + "'");
                    if (_IsBind)
                    {
                        txtMulti1.Text = drTyp[0]["Multi1"].ToString();
                        txtMulti2.Text = drTyp[0]["Multi2"].ToString();
                        txtMulti3.Text = drTyp[0]["Multi3"].ToString();
                        txtMulti4.Text = drTyp[0]["Multi4"].ToString();
                    }
                    txtArt.Text = drTyp[0]["ArtDesc"].ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParseRabattDetails()
        {
            try
            {
                decimal DValue = 1;
                DateTime dtTime = DateTime.Now;
                ObjEArticle.RabattID = -1;
                ObjEArticle.Rabatt = txtRabatt.Text;
                ObjEArticle.TypID = Convert.ToInt32(cmbType.SelectedValue);
                
                if(decimal.TryParse(txtMulti1.Text,out DValue))
                    ObjEArticle.Multi1 = DValue;
                else
                    ObjEArticle.Multi1 = 1;
                
                if (decimal.TryParse(txtMulti2.Text, out DValue))
                    ObjEArticle.Multi2 = DValue;
                else
                    ObjEArticle.Multi2 = 1;
                
                if (decimal.TryParse(txtMulti3.Text, out DValue))
                    ObjEArticle.Multi3 = DValue;
                else
                    ObjEArticle.Multi3 = 1;
                
                if (decimal.TryParse(txtMulti4.Text, out DValue))
                    ObjEArticle.Multi4 = DValue;
                else
                    ObjEArticle.Multi4 = 1;

                ObjEArticle.ValidityDate = dateEditValidityDate.DateTime;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvRabatt_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int _IDValue = -1;
                if (gvRabatt.FocusedColumn != null && gvRabatt.GetFocusedRowCellValue("RabattID") != null)
                {
                    if (int.TryParse(gvRabatt.GetFocusedRowCellValue("RabattID").ToString(), out _IDValue))
                    {
                        if (ObjEArticle == null)
                            ObjEArticle = new EArticles();
                        _IsBind = false;
                        ObjEArticle.RabattID = _IDValue;
                        txtRabatt.Text = gvRabatt.GetFocusedRowCellValue("Rabatt") == DBNull.Value ? "" : gvRabatt.GetFocusedRowCellValue("Rabatt").ToString();
                        cmbType.SelectedValue = gvRabatt.GetFocusedRowCellValue("TypeID") == DBNull.Value ? "" : gvRabatt.GetFocusedRowCellValue("TypeID");
                        txtMulti1.Text = gvRabatt.GetFocusedRowCellValue("Multi1") == DBNull.Value ? "" : gvRabatt.GetFocusedRowCellValue("Multi1").ToString();
                        txtMulti2.Text = gvRabatt.GetFocusedRowCellValue("Multi2") == DBNull.Value ? "" : gvRabatt.GetFocusedRowCellValue("Multi2").ToString();
                        txtMulti3.Text = gvRabatt.GetFocusedRowCellValue("Multi3") == DBNull.Value ? "" : gvRabatt.GetFocusedRowCellValue("Multi3").ToString();
                        txtMulti4.Text = gvRabatt.GetFocusedRowCellValue("Multi4") == DBNull.Value ? "" : gvRabatt.GetFocusedRowCellValue("Multi4").ToString();
                        dateEditValidityDate.DateTime = gvRabatt.GetFocusedRowCellValue("ValidityDate") == DBNull.Value ?
                            DateTime.Now : Convert.ToDateTime(gvRabatt.GetFocusedRowCellValue("ValidityDate"));
                    }
                }
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
    }
}