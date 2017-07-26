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
    public partial class frmSelectAccessories : DevExpress.XtraEditors.XtraForm
    {
        private EArticles _ObjEArticle = null;
        public bool _ISSave = false;
        public EArticles ObjEArticle
        {
            get { return _ObjEArticle; }
            set { _ObjEArticle = value; }
        }

        public frmSelectAccessories()
        {
            InitializeComponent();
        }

        private void frmSelectAccessories_Load(object sender, EventArgs e)
        {
            try
            {
                gcArticles.DataSource = _ObjEArticle.dtAccessories;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _ISSave = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}