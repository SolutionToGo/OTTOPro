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
    public partial class frmViewcommentory : DevExpress.XtraEditors.XtraForm
    {
        public string LongDescription = string.Empty;
        public bool _IsSave = false;
        public frmViewcommentory()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LongDescription = txtDescription.RtfText;
                _IsSave = true;
                this.Close();
            }
            catch (Exception ex) { }
        }

        private void frmViewcommentory_Load(object sender, EventArgs e)
        {
            try
            {
                txtDescription.RtfText = LongDescription;
            }
            catch (Exception ex){}
        }

        private void frmViewcommentory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F1)
                    btnSave_Click(null, null);
            }
            catch (Exception ex) { }
        }
    }
}