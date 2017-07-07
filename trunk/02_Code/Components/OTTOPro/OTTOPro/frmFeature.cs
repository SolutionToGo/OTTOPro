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
using DevExpress.XtraGrid;

namespace OTTOPro
{
    public partial class frmFeature : DevExpress.XtraEditors.XtraForm
    {
        EUserInfo ObjEUserInfo = new EUserInfo();
        BUserInfo ObjBUserInfo = new BUserInfo();
        public frmFeature()
        {
            InitializeComponent();
        }

        private void frmFeature_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utility.UserDataAccess == "7")
                    btnSaveFeature.Enabled = false;
                BindRoleData();
                BindAccessLevels();
                cmbRole.EditValue = 8;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void BindFeatureData()
        {
            try
            {
                ObjBUserInfo.GetFeatureData(ObjEUserInfo);
                if (ObjEUserInfo.dtFeature != null)
                {
                    gcFeature.DataSource = ObjEUserInfo.dtFeature;
                    gvFeature.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BindRoleData()
        {
            try
            {
                ObjBUserInfo.GetUserRoles(ObjEUserInfo);
                if (ObjEUserInfo.dsUserRole != null)
                {
                    cmbRole.Properties.DataSource = ObjEUserInfo.dsUserRole.Tables[0];
                    cmbRole.Properties.DisplayMember = "RoleName";
                    cmbRole.Properties.ValueMember = "RoleID";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindAccessLevels()
        {
            try
            {
                ObjBUserInfo.GetAceesLevels(ObjEUserInfo);
                if (ObjEUserInfo.dtAccessLevels != null)
                {
                    rpiAccessLevels.DataSource = null;
                    rpiAccessLevels.DataSource=ObjEUserInfo.dtAccessLevels;
                    rpiAccessLevels.DisplayMember = "Value";
                    rpiAccessLevels.ValueMember = "LookupID";
                    rpiAccessLevels.PopulateColumns();
                    rpiAccessLevels.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnSaveFeature_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEUserInfo == null)
                    ObjEUserInfo = new EUserInfo();
                 DataTable _FeatureTable = ObjEUserInfo.dtFeature.Copy();
                 foreach (DataColumn dc in ObjEUserInfo.dtFeature.Columns)
                    {
                        if (dc.ColumnName != "FeatureID" && dc.ColumnName != "AccessLevelID")
                        {
                            _FeatureTable.Columns.Remove(dc.ColumnName);
                        }
                    }

                ObjBUserInfo = new BUserInfo();
                ObjBUserInfo.SaveFeatureMap(ObjEUserInfo, _FeatureTable);
                if(Utility._IsGermany==true)
                {
                    frmOTTOPro.UpdateStatus("Berechtigungen für ausgewählte Rolle wurden gespeichert");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("Features saved successfully for selected role");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbRole_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int _IDValue = -1;
                if (int.TryParse(Convert.ToString(cmbRole.EditValue), out _IDValue))
                {
                    ObjEUserInfo.RoleID = _IDValue;
                    BindFeatureData();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmFeature_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (frmOTTOPro.Instance.MdiChildren.Count() == 1)
                {
                    frmOTTOPro.Instance.SetPictureBoxVisible(true);
                    frmOTTOPro.Instance.SetLableVisible(true);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}