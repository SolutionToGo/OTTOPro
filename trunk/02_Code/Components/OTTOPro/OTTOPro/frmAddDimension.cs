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
    public partial class frmAddDimension : DevExpress.XtraEditors.XtraForm
    {

        BArticles ObjBArticle = null;
        private EArticles _ObjEArticle = null;
        bool _isValidate = true;

        public frmAddDimension()
        {
            InitializeComponent();
        }

        #region PROPERTY SETTING

        public EArticles ObjEArticle
        {
            get
            {
                return _ObjEArticle;
            }
            set
            {
                _ObjEArticle = value;
            }
        }

        #endregion

        private void ValidatControls()
        {
            try
            {
                bool isValidA = dxValidationProviderA.Validate(txtA);
                bool isvalidB = dxValidationProviderB.Validate(txtB);
                if (!isValidA || !isvalidB)
                {
                    _isValidate = false;
                }
                else
                {
                    _isValidate = true;
                }
            }
            catch (Exception Ex)
            {
                throw;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatControls();
                if (_isValidate == true)
                {
                    if (ObjBArticle == null)
                        ObjBArticle = new BArticles();
                    ParseSupplierDetails();
                    ObjBArticle = new BArticles();
                    ObjBArticle.SaveDimension(_ObjEArticle);
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        private void ParseSupplierDetails()
        {
            try
            {
                _ObjEArticle.A = txtA.Text;
                _ObjEArticle.B = txtB.Text;
                _ObjEArticle.L = txtL.Text;
                _ObjEArticle.ListPrice =Convert.ToDecimal(txtListenPrice.Text);
                _ObjEArticle.Minuten = Convert.ToDecimal(txtMinuten.Text);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void frmAddDimension_Load(object sender, EventArgs e)
        {
            try
            {
                if (_ObjEArticle.DimensionID > 0)
                    BindDimensionDetails();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindDimensionDetails()
        {
            try
            {
                txtA.Text = _ObjEArticle.A;
                txtB.Text = _ObjEArticle.B;
                txtL.Text = _ObjEArticle.L;
                txtListenPrice.Text = _ObjEArticle.ListPrice.ToString();
                txtMinuten.Text = _ObjEArticle.Minuten.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar) != '\b' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void frmAddDimension_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult != DialogResult.Cancel)
                {
                    if (_isValidate == false)
                        e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

//*************************
    }
}