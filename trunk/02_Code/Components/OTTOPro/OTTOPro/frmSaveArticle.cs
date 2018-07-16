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
        BSupplier ObjBSupplier = null;
        private ESupplier _ObjEsupplier = null;

        public frmSaveArticle()
        {
            InitializeComponent();
        }

        public ESupplier ObjEsupplier
        {
            get{return _ObjEsupplier;}
            set{_ObjEsupplier = value;}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.dxValidationProvider1.Validate())
                    return;
                if (_ObjEsupplier == null)
                    _ObjEsupplier = new ESupplier();
                ParseSupplierDetails();
                ObjBSupplier = new BSupplier();
                ObjBSupplier.SaveArticle(_ObjEsupplier);
                this.Close();
            }
            catch (Exception ex) { Utility.ShowError(ex); }
        }

        private void ParseSupplierDetails()
        {
            try
            {
                _ObjEsupplier.WG = txtWG.Text;
                if (string.IsNullOrEmpty(txtWA.Text))
                    _ObjEsupplier.WA = "0";
                else
                    _ObjEsupplier.WA = txtWA.Text;
                _ObjEsupplier.WGDescription = txtDescription.Text;
            }
            catch (Exception ex){throw;}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindSupplierDetails()
        {
            try
            {
                txtWG.Text = _ObjEsupplier.WG;
                txtWA.Text = _ObjEsupplier.WA;
                txtDescription.Text = _ObjEsupplier.WGDescription;
            }
            catch (Exception ex){throw;}
        }

        private void frmSaveArticle_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utility.SupplierDataAccess == "7")
                    btnSave.Enabled = false;
                if (_ObjEsupplier.WGWAID > 0)
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

    }
}