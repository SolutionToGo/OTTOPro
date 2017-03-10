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
using DevExpress.XtraGrid.Columns;

namespace OTTOPro
{
    public partial class frmLoadSupplier : System.Windows.Forms.Form
    {
        EArticles ObjEArticles = new EArticles();
        DataTable _dtWI = new DataTable();
        DataTable _dtWG = new DataTable();

        public frmLoadSupplier()
        {
            InitializeComponent();
        }

        private void btnAddArticles_Click(object sender, EventArgs e)
        {
            frmSelectArticle frm = new frmSelectArticle();
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
            {
                if (frm.dsArticles != null)
               {
                  _dtWG= frm.dsArticles.Tables[0];

                  foreach (DataRow row in _dtWG.Rows)
                  {
                      gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WG"], row["WG"]);
                      gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WA"], row["WA"]);
                      gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WGDescription"], row["WGDescription"]);

                  }                      
                   //gcArticles.DataSource = frm.dsArticles.Tables[0];
                   //_dtWI = frm.dsArticles.Tables[1];
                   //foreach (DataRow row in _dtWI.Rows)
                   //{
                   //    gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.Columns["WI"], row["WI"]);
                   //    // gvArticles.SetRowCellValue(gvArticles.FocusedRowHandle, gvArticles.FocusedColumn, row["WIDescription"]);
                   //}                  

                  gcArticles.DataSource = _dtWG;
                   gvArticles.BestFitColumns();
               }

            }
        }

        private void gvArticles_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvArticles.FocusedColumn != null && gvArticles.GetFocusedRowCellValue("WG") != null)
            {
                txtWGDescription.Text = gvArticles.GetFocusedRowCellValue("WGDescription") == DBNull.Value ? "" : gvArticles.GetFocusedRowCellValue("WGDescription").ToString();
              //  txtWIDescription.Text = gvArticles.GetFocusedRowCellValue("WIDescription") == DBNull.Value ? "" : gvArticles.GetFocusedRowCellValue("WIDescription").ToString();
            }
        }



//********************
    }
}