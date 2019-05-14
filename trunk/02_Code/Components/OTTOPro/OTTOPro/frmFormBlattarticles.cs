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
    public partial class frmFormBlattarticles : DevExpress.XtraEditors.XtraForm
    {
        BFormBlatt ObjBFormBlatt = null;
        EFormBlatt ObjEFormBlatt = null;
        int _FormBlattTyPeID = 0;
        EPosition ObjEPosition = null;

        public frmFormBlattarticles(EPosition _ObjEPosition)
        {
            InitializeComponent();
            ObjEPosition = _ObjEPosition;
        }

        private void frmFormBlattarticles_Load(object sender, EventArgs e)
        {
            try
            {
                BindBlattType();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindBlattType()
        {
            try
            {
                if (ObjEFormBlatt == null)
                    ObjEFormBlatt = new EFormBlatt();
                if (ObjBFormBlatt == null)
                    ObjBFormBlatt = new BFormBlatt();
                ObjBFormBlatt.Get_FormBlattTypes(ObjEFormBlatt);
                if (ObjEFormBlatt.dtBlattTypes != null)
                {
                    cmbFormBlatttypes.DataSource = ObjEFormBlatt.dtBlattTypes;
                    cmbFormBlatttypes.ValueMember = "LookupID";
                    cmbFormBlatttypes.DisplayMember = "Value";
                    cmbFormBlatttypes.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbFormBlatttypes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (ObjEFormBlatt == null)
                    ObjEFormBlatt = new EFormBlatt();
                if (ObjBFormBlatt == null)
                    ObjBFormBlatt = new BFormBlatt();
                if (cmbFormBlatttypes.Text != string.Empty)
                {
                    if (int.TryParse(Convert.ToString(cmbFormBlatttypes.SelectedValue), out _FormBlattTyPeID))

                        if (_FormBlattTyPeID > 0)
                        {
                            gcFormBlattArticles.DataSource = null;
                            ObjEFormBlatt.LookUpID = _FormBlattTyPeID;
                            ObjEFormBlatt.ProjectID = ObjEPosition.ProjectID;
                            ObjBFormBlatt.Get_FormBlattArticles(ObjEFormBlatt);
                            if (ObjEFormBlatt.dtBlattArticles != null)
                            {
                                gcFormBlattArticles.DataSource = ObjEFormBlatt.dtBlattArticles;
                                gvFormBlattArticles.BestFitColumns();
                            }
                        }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSaveFormBlattArticles_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dvArticles = null;
                DataTable Temp = ObjEFormBlatt.dtBlattArticles.Copy();
                Temp.Columns.Remove("WGDescription");
                Temp.Columns.Remove("WADescription");
                DataTable dt = Temp;
                if (dt != null)
                {
                    dvArticles = dt.DefaultView;
                    dvArticles.RowFilter = "IsAssigned = '" + true + "'";
                }
                if (ObjEFormBlatt == null)
                    ObjEFormBlatt = new EFormBlatt();
                if (ObjBFormBlatt == null)
                    ObjBFormBlatt = new BFormBlatt();
                ObjEFormBlatt = ObjBFormBlatt.Save_FormBlattArticles(ObjEFormBlatt, dvArticles.ToTable());
                if (Utility._IsGermany == true)
                    frmOTTOPro.UpdateStatus("Artikelangaben für das Formblatt erfolgreich gespeichert");
                else
                    frmOTTOPro.UpdateStatus("FormBlatt Articles Saved Successfully");
            }
            catch (Exception ex){Utility.ShowError(ex);}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}