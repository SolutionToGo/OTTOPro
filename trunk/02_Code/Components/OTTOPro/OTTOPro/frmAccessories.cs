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
    public partial class frmAccessories : DevExpress.XtraEditors.XtraForm
    {
        List<Control> Requirefields = new List<Control>();
        EArticles ObjEArticles = null;
        BArticles ObjBArticles = null;

        public frmAccessories()
        {
            InitializeComponent();
        }

        private void frmAccessories_Load(object sender, EventArgs e)
        {
            Requirefields.Add(cmbParentWGWA);
            Requirefields.Add(cmbParentWI);
            Requirefields.Add(cmbParentDimension);
            Requirefields.Add(cmbChildWGWA);
            Requirefields.Add(cmbChildWI);
            Requirefields.Add(cmbChildDimension);

            if (ObjEArticles == null)
                ObjEArticles = new EArticles();
            if (ObjBArticles == null)
                ObjBArticles = new BArticles();

            ObjEArticles = ObjBArticles.GetAticleForMapping(ObjEArticles);

            cmbParentWGWA.DataSource = ObjEArticles.dtWG;
            cmbParentWGWA.ValueMember = "WGID";
            cmbParentWGWA.DisplayMember = "WGWADesc";

            DataTable dtChildWG = ObjEArticles.dtWG.Copy();
            cmbChildWGWA.DataSource = dtChildWG;
            cmbChildWGWA.ValueMember = "WGID";
            cmbChildWGWA.DisplayMember = "WGWADesc";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utility.ValidateRequiredFields(Requirefields))
                    return;
                if (cmbParentDimension.SelectedValue != null)
                    ObjEArticles.ParentID = Convert.ToInt32(cmbParentDimension.SelectedValue);
                if (cmbChildDimension.SelectedValue != null)
                    ObjEArticles.ChildID = Convert.ToInt32(cmbChildDimension.SelectedValue);
                ObjEArticles.UserID = Utility.UserID;
                ObjEArticles = ObjBArticles.SaveArticleMapping(ObjEArticles);
                BindAccessories();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindWIParentData(Object WGID)
        {
            try
            {
                int iValue = 0;
                if (WGID != null && int.TryParse(WGID.ToString(), out iValue))
                {
                    DataView dvWI = ObjEArticles.dtWI.DefaultView;
                    dvWI.RowFilter = "WGID = '" + iValue + "'";
                    cmbParentWI.DataSource = dvWI;
                    cmbParentWI.ValueMember = "WIID";
                    cmbParentWI.DisplayMember = "WIDesc";
                    cmbParentWI_SelectedValueChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindWIChildData(Object WGID)
        {
            try
            {
                int iValue = 0;
                if (WGID != null && int.TryParse(WGID.ToString(), out iValue))
                {
                    DataTable dtChildWI = ObjEArticles.dtWI.Copy();
                    DataView dvWI = dtChildWI.DefaultView;
                    dvWI.RowFilter = "WGID = '" + iValue + "'";
                    cmbChildWI.DataSource = dvWI;
                    cmbChildWI.ValueMember = "WIID";
                    cmbChildWI.DisplayMember = "WIDesc";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindParentDimensionData(Object WIID)
        {
            try
            {
                int iValue = 0;
                if (WIID != null && int.TryParse(WIID.ToString(), out iValue))
                {
                    DataView dvDimension = ObjEArticles.dtDimenstions.DefaultView;
                    dvDimension.RowFilter = "WIID = '" + iValue + "'";
                    cmbParentDimension.DataSource = dvDimension;
                    cmbParentDimension.ValueMember = "DimensionID";
                    cmbParentDimension.DisplayMember = "DimensionDesc";

                    DataTable dtTemp1 = ObjEArticles.dtWI.Copy();
                    DataView dvWI = dtTemp1.DefaultView;
                    dvWI.RowFilter = "WGID = '" + iValue + "'";
                    DataTable dtTemp = dvWI.ToTable();
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        txtParentFabrikate.Text = Convert.ToString(dtTemp.Rows[0]["Fabrikate"]);
                        txtParentTyp.Text = Convert.ToString(dtTemp.Rows[0]["Typ"]);
                        txtParentLifrant.Text = Convert.ToString(dtTemp.Rows[0]["ShortName"]);
                    }
                    else
                    {
                        txtParentFabrikate.Text = string.Empty;
                        txtParentTyp.Text = string.Empty;
                        txtParentLifrant.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindChildDimensionData(Object WIID)
        {
            try
            {
                int iValue = 0;
                if (WIID != null && int.TryParse(WIID.ToString(), out iValue))
                {
                    DataTable dtChildDimension = ObjEArticles.dtDimenstions.Copy();
                    DataView dvDimension = dtChildDimension.DefaultView;
                    dvDimension.RowFilter = "WIID = '" + iValue + "'";
                    cmbChildDimension.DataSource = dvDimension;
                    cmbChildDimension.ValueMember = "DimensionID";
                    cmbChildDimension.DisplayMember = "DimensionDesc";

                    DataTable dt = ObjEArticles.dtWI.Copy();
                    DataView dvWI = dt.DefaultView;
                    dvWI.RowFilter = "WGID = '" + iValue + "'";
                    DataTable dtTemp = dvWI.ToTable();
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        txtChildFabrikate.Text = Convert.ToString(dtTemp.Rows[0]["Fabrikate"]);
                        txtChildTyp.Text = Convert.ToString(dtTemp.Rows[0]["Typ"]);
                        txtChildLifrant.Text = Convert.ToString(dtTemp.Rows[0]["ShortName"]);
                    }
                    else
                    {
                        txtParentFabrikate.Text = string.Empty;
                        txtParentTyp.Text = string.Empty;
                        txtParentLifrant.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbParentWGWA_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindWIParentData(cmbParentWGWA.SelectedValue);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbParentWI_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                BindParentDimensionData(cmbParentWI.SelectedValue);
                BindAccessories();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbChildWGWA_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindWIChildData(cmbChildWGWA.SelectedValue);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbChildWI_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindChildDimensionData(cmbChildWI.SelectedValue);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbParentDimension_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindAccessories();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindAccessories()
        {
            try
            {
                if (ObjBArticles == null)
                    ObjBArticles = new BArticles();
                if (ObjEArticles == null)
                    ObjEArticles = new EArticles();
                int Ivalue = 0;
                if (cmbParentDimension.SelectedValue != null 
                    && int.TryParse(Convert.ToString(cmbParentDimension.SelectedValue),out Ivalue))
                {
                    ObjEArticles.ParentID = Ivalue;
                    ObjEArticles = ObjBArticles.GetAccessories(ObjEArticles);
                    gcArticles.DataSource = ObjEArticles.dtAccessories;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}