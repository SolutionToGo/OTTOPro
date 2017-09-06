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
    public partial class frmAddType : DevExpress.XtraEditors.XtraForm
    {
        EArticles ObjEArticle = null;
        BArticles ObjBArticle = null;
        private string _Typ = null;
        private string _FullName = null;
        int _WIID = 0;

        public frmAddType()
        {
            InitializeComponent();
        }
        public frmAddType(int _id)
        {
            InitializeComponent();
            _WIID = _id;
        }

        public string Typ
        {
            get { return _Typ; }
            set { _Typ = value; }
        }
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        private void frmAddType_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjEArticle == null)
                    ObjEArticle = new EArticles();
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
                ObjBArticle.GetMultipleTyp(ObjEArticle, _WIID);
                if (ObjEArticle.dtAddTyp != null)
                {
                    gcAddTyp.DataSource = ObjEArticle.dtAddTyp;
                    gvAddTyp.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvAddTyp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvAddTyp.FocusedColumn != null && gvAddTyp.GetFocusedRowCellValue("TypID") != null)
                {
                    _Typ = gvAddTyp.GetFocusedRowCellValue("Typ") == DBNull.Value ? "" : gvAddTyp.GetFocusedRowCellValue("Typ").ToString();
                    _FullName = gvAddTyp.GetFocusedRowCellValue("FullName") == DBNull.Value ? "" : gvAddTyp.GetFocusedRowCellValue("FullName").ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmAddType_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                    btnOk_Click(null, null);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                gvAddTyp_FocusedRowChanged(null, null);
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


    }
}