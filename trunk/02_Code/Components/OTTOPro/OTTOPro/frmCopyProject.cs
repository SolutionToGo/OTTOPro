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
    public partial class frmCopyProject : DevExpress.XtraEditors.XtraForm
    {
        private bool _IsSave = false;
        public string _NewProjectNumber = string.Empty;
        
        public frmCopyProject()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProjectNumber.Text.Trim()))
                    throw new Exception("Please Enter Valid Project Number");
                _IsSave = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _IsSave = false;
            this.Close();
        }

        private void frmCopyProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IsSave)
                _NewProjectNumber = txtProjectNumber.Text.Trim();
            else
                _NewProjectNumber = string.Empty;
        }

        private void frmCopyProject_Load(object sender, EventArgs e)
        {

        }
    }
}