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
    public partial class frmSaveDimension : DevExpress.XtraEditors.XtraForm
    {
        public EArticles ObjEArticle = null;
        public BArticles ObjBArticle = null;
        public string strArticle = string.Empty;
        public frmSaveDimension()
        {
            InitializeComponent();
        }

        private void frmSaveDimension_Load(object sender, EventArgs e)
        {
            try
            {
                lblArticle.Text = strArticle;
                dateEditGultigkeit.DateTime = DateTime.Now;
                BindDimensions(ObjEArticle.WIID);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ObjBArticle == null)
                ObjBArticle = new BArticles();
            ObjEArticle.ValidityDate = dateEditGultigkeit.DateTime;
            ObjEArticle = ObjBArticle.SaveDimensionCopy(ObjEArticle);
            MessageBox.Show("Dimensions Saved With New Validity Date : " + string.Format("{0:y}", dateEditGultigkeit.DateTime));
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindDimensions(int WIID)
        {
            try
            {

                DataView dvDimensions = ObjEArticle.dtDimenstions.DefaultView;
                dvDimensions.RowFilter = "WIID = '" + WIID + "'";
                gcDimensions.DataSource = dvDimensions;
                gvDimensions.BestFitColumns();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}