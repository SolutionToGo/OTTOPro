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
using BL;
using EL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace OTTOPro
{
    public partial class frmSelectArticle : DevExpress.XtraEditors.XtraForm
    {
        BArticles ObjBArticles = new BArticles();
        EArticles ObjEArticles = new EArticles();
        private int _WGID = -1;
        private int _WIID = -1;

        int _IDValue = -1;
        int _WG;
        int _WA;

        private DataSet _dtArticles;
        public DataSet dsArticles
        {
            get { return _dtArticles; }
            set { _dtArticles = value; }
        }

        public frmSelectArticle()
        {
            InitializeComponent();
        }

        private void frmSelectArticle_Load(object sender, EventArgs e)
        {
            BindArticleData();
        }

        public void BindArticleData()
        {
            try
            {
                ObjBArticles.GetArticles(ObjEArticles,0,0);
                if (ObjEArticles.dsArticles != null)
                {
                    gcWGWA.DataSource = ObjEArticles.dsArticles.Tables[0];
                    gvWGWA.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvWGWA_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvWGWA.FocusedColumn != null && gvWGWA.GetFocusedRowCellValue("WGID") != null)
                {
                   // GetArticleDetails();
                    if (int.TryParse(gvWGWA.GetFocusedRowCellValue("WGID").ToString(), out _IDValue))
                        _WGID = _IDValue;
                    ObjBArticles.GetArticles(ObjEArticles,0,0);

                    DataView dvWI = ObjEArticles.dsArticles.Tables["Table1"].DefaultView;
                    dvWI.RowFilter = "WGID = '" + _WGID + "'";
                    gcWI.DataSource = dvWI;

                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        private void GetArticleDetails()
        {
            try
            {
                if (gvWGWA.GetFocusedRowCellValue("WGID") != DBNull.Value)
                {
                    if (int.TryParse(gvWGWA.GetFocusedRowCellValue("WG").ToString(), out _WG))
                        ObjEArticles.WG = _WG;
                    if (int.TryParse(gvWGWA.GetFocusedRowCellValue("WA").ToString(), out _WA))
                        ObjEArticles.WG = _WA;
                    ObjEArticles.WGDescription = gvWGWA.GetFocusedRowCellValue("WGDescription") == DBNull.Value ? "" : gvWGWA.GetFocusedRowCellValue("WGDescription").ToString();

                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GetArticleDetails();
            gvWI_FocusedRowChanged(null,null);
          _dtArticles= ObjBArticles.GetArticles(ObjEArticles, _WGID, _WIID);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void gvWI_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvWI.FocusedColumn != null && gvWI.GetFocusedRowCellValue("WIID") != null)
                {
                    if (int.TryParse(gvWI.GetFocusedRowCellValue("WIID").ToString(), out _IDValue))
                        _WIID = _IDValue;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

//****************************
    }
}