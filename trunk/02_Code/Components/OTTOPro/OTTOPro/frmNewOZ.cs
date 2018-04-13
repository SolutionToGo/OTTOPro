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
    public partial class frmNewOZ : DevExpress.XtraEditors.XtraForm
    {
        public string strNewOZ = string.Empty;
        public bool IsSave = false;
        public frmNewOZ()
        {
            InitializeComponent();
        }

        private void frmNewOZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
            else if(e.KeyChar == (char)Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }

        private void frmNewOZ_Load(object sender, EventArgs e)
        {
            txtNewOZ.Text = strNewOZ;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IsSave = true;
            strNewOZ = txtNewOZ.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}