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
    public partial class frmWGWA : DevExpress.XtraEditors.XtraForm
    {
        private ESupplier _ObjESupplier = null;
        private BSupplier _ObjBSupplier = null;
        public ESupplier ObjESupplier
        {
            get { return _ObjESupplier; }
            set { _ObjESupplier = value; }
        }
        public frmWGWA()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ObjBSupplier == null)
                    _ObjBSupplier = new BSupplier();
                _ObjESupplier.WG = txtWG.Text;
                _ObjESupplier.WA = txtWA.Text;
                _ObjESupplier.WGDescription = txtWGDescription.Text;
                _ObjBSupplier.SaveArticle(_ObjESupplier);
                this.Close();
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

        private void frmWGWA_Load(object sender, EventArgs e)
        {
            try
            {
                if (_ObjESupplier.WGWAID > 0)
                {
                    txtWG.Text = _ObjESupplier.WG;
                    txtWA.Text = _ObjESupplier.WA;
                    txtWGDescription.Text = _ObjESupplier.WGDescription;
                    txtWG.ReadOnly = true;
                    txtWA.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
} 