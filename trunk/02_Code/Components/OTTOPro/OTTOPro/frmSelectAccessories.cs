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
        private BArticles ObjBArticles = null;
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
                if (ObjBArticles == null)
                    ObjBArticles = new BArticles();
                if (_ObjEArticle == null)
                    _ObjEArticle = new EArticles();
                _ObjEArticle = ObjBArticles.GetAccessoriesForLVs(_ObjEArticle);
                gcArticles.DataSource = _ObjEArticle.dtAccessories;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}