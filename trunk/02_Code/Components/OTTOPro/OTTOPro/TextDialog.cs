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

namespace OTTOPro
{
    public partial class frmTextDialog : DevExpress.XtraEditors.XtraForm
    {
        public string strName = string.Empty;
        private string _NewLVSection = string.Empty;
        private bool _IsSave = false;
        private bool _ISUpdated = false;
        private bool _isFirstTime = true;
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
                        throw new Exception("Geben Sie den gültigen Wert ein");
                    }
                    else
                    {
                        throw new Exception("Please Enter Valid Value");
                    }                    
                    _NewLVSection = txtNewLVSection.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
        
    }
}