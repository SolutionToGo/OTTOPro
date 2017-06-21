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
    public partial class frmSaveArticle : DevExpress.XtraEditors.XtraForm
    {
       // ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = null;

        private ESupplier _ObjEsupplier = null;

        bool _isValidate = true;
        public frmSaveArticle()
        {
            InitializeComponent();
        }


        #region PROPERTY SETTING

        public ESupplier ObjEsupplier
        {
            get
            {
                return _ObjEsupplier;
            }
            set
            {
                _ObjEsupplier = value;
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatControls();
                if (_isValidate == true)
                {
                    if (_ObjEsupplier == null)
                        _ObjEsupplier = new ESupplier();
                    ParseSupplierDetails();
                    ObjBSupplier = new BSupplier();
                    ObjBSupplier.SaveArticle(_ObjEsupplier);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ValidatControls()
        {
            try
            {
                bool isValidWG = dxValidationProviderWG.Validate(txtWG);
                bool isvalidWA = dxValidationProviderWA.Validate(txtWA);
                if (!isValidWG || !isvalidWA)
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

        private void ParseSupplierDetails()
        {
            try
            {
                _ObjEsupplier.WG = txtWG.Text;
                _ObjEsupplier.WA = txtWA.Text;
                _ObjEsupplier.WGDescription = txtDescription.Text;
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

        private void frmSaveArticle_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BindSupplierDetails()
        {
            try
            {
                txtWG.Text = _ObjEsupplier.WG;
                txtWA.Text = _ObjEsupplier.WA;
                txtDescription.Text = _ObjEsupplier.WGDescription;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void frmSaveArticle_Load(object sender, EventArgs e)
        {
            try
            {
                if (_ObjEsupplier.SupplierID > 0)
                    BindSupplierDetails();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtWG_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && (e.KeyChar) != '\b')
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

//**************************
    }
}