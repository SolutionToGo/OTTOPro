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
    public partial class frmViewdescription : DevExpress.XtraEditors.XtraForm
    {
        private byte[] _LongDescription = null;
        private bool _IsSave = false;
        private bool _ISUpdated = false;
        private bool _isFirstTime = false;
        public frmViewdescription()
        {
            InitializeComponent();
            _isFirstTime = true;
        }
        public byte[] LongDescription
        {
            get { return _LongDescription; }
            set { _LongDescription = value; }
        }

        private void frmViewdescription_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IsSave)
                _LongDescription = System.Text.Encoding.UTF8.GetBytes(txtLongdescription.RtfText);
            else
            {
                if (_ISUpdated)
                {
                    string _dlgResult = XtraMessageBox.Show("Save changes...!", "Confirmation.. ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString();
                    if (!string.IsNullOrEmpty(_dlgResult))
                    {
                        if (_dlgResult.ToLower() == "yes")
                        {
                            _LongDescription = System.Text.Encoding.UTF8.GetBytes(txtLongdescription.RtfText);
                        }
                        else if (_dlgResult.ToLower() == "cancel")
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void frmViewdescription_Load(object sender, EventArgs e)
        {
            if (_LongDescription != null)
            {
                txtLongdescription.RtfText = Encoding.ASCII.GetString(_LongDescription);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this._IsSave = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._IsSave = false;
            this.Close();
        }

        private void txtLongdescription_TextChanged(object sender, EventArgs e)
        {
            if (!_isFirstTime)
            {
                _ISUpdated = true;    
            }
            _isFirstTime = false;
        }
    }
}