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
    public partial class frmSupplierList : DevExpress.XtraEditors.XtraForm
    {
        public ESupplier ObjESupplier = null;
        BSupplier ObjBSupplier = null;
        public bool _IsSave = false;
        public frmSupplierList()
        {
            InitializeComponent();
        }

        private void frmSupplierList_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjESupplier == null)
                    ObjESupplier = new ESupplier();
                if (ObjBSupplier == null)
                    ObjBSupplier = new BSupplier();
                BindSupplierData();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void BindSupplierData()
        {
            try
            {
                ObjESupplier = ObjBSupplier.GetSupplier(ObjESupplier);
                if (ObjESupplier.dtSupplier != null)
                {
                    gcSupplier.DataSource = ObjESupplier.dtSupplier;
                    gvSupplier.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjBSupplier == null)
                    ObjBSupplier = new BSupplier();
                if (ObjESupplier == null)
                    ObjESupplier = new ESupplier();
                int IValue = 0;
                if (int.TryParse(Convert.ToString(gvSupplier.GetFocusedRowCellValue("SupplierID")), out IValue))
                {
                    ObjESupplier.SupplierID = IValue;
                    ObjESupplier = ObjBSupplier.CheckSupplierArticle(ObjESupplier);
                    if (!string.IsNullOrEmpty(ObjESupplier.strArticleExists))
                    {
                        var _result = XtraMessageBox.Show("Der Artikel gehört nicht zum ausgewählten Lieferant, wollen Sie ihn dennoch hinzufügen?", "Bestätigen..?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (Convert.ToString(_result).ToLower() == "ok")
                            ObjBSupplier.SaveArticle(ObjESupplier);
                        else
                            return;
                    }
                    if(!string.IsNullOrEmpty(ObjESupplier.strSupplierExists))
                    {
                        var _result = XtraMessageBox.Show("Für diesen Lieferanten existiert bereits ein Preisangebot. Wollen Sie ein weiteres Preisangebot hinzufügen?", "Bestätigen..?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (Convert.ToString(_result).ToLower() != "ok")
                            return;
                    }
                    _IsSave = true;
                    this.Close();
                }
                else
                    throw new Exception("Bitte wählen Sie den Lieferanten, der hinzugefügt werden soll");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ObjESupplier.SupplierID = -1;
            this.Close();
        }

        private void frmSupplierList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnOk_Click(null, null);
            else if (e.KeyChar == (char)Keys.Escape)
                btnCancel_Click(null, null);
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (ObjESupplier == null)
                ObjESupplier = new ESupplier();
            ObjESupplier.SupplierID = -1;
            frmSupplierMaster Obj = new frmSupplierMaster("Supplier");
            Obj.ObjEsupplier = ObjESupplier;
            Obj.ShowDialog();
            BindSupplierData();
            Utility.Setfocus(gvSupplier, "SupplierID", ObjESupplier.SupplierID);
        }
    }
}