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
    public partial class frmTextDialog : DevExpress.XtraEditors.XtraForm
    {
        private EProposal _ObjEProposal = null;        
        public string strName = string.Empty;
        private string _NewLVSection = string.Empty;
        private bool _IsSave = false;
        private bool _isFirstTime = true;
        private bool _ISUpdated = false;
        private string _FormType;
        bool _isValidate = false;


        public string NewLVSection
        {
            get { return _NewLVSection; }
            set { _NewLVSection = value; }
        }
        public bool IsSave
        {
            get { return _IsSave; }
            set { _IsSave = value; } 
        }
        public frmTextDialog()
        {
            InitializeComponent();
        }       
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this._IsSave = true;
                if (string.IsNullOrEmpty(txtNewLVSection.Text))
                    if(Utility._IsGermany==true)
                    {
                        _isValidate = false;
                        throw new Exception("Bitte machen Sie gültige Angaben");
                    }
                    else
                    {
                        _isValidate = false;
                        throw new Exception("Please Enter Valid Value");
                    }                
                _NewLVSection = txtNewLVSection.Text;
                _isValidate = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this._IsSave = false;
            this.Close();
        }

        private void frmTextDialog_Load(object sender, EventArgs e)
        {
            txtNewLVSection.Text = _NewLVSection;
        }

        private void txtNewLVSection_TextChanged(object sender, EventArgs e)
        {
            if (!_isFirstTime)
            {
                _ISUpdated = true;
            }
            _isFirstTime = false;
        }

        private void frmTextDialog_FormClosing(object sender, FormClosingEventArgs e)
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
        
    }
}