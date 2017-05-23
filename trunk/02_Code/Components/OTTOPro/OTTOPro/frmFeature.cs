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
                BindRoleData();
                BindAccessLevels();
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

        private void btnSaveRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEUserInfo == null)
                    ObjEUserInfo = new EUserInfo();
                ObjEUserInfo.RoleID = -1;
                ObjEUserInfo.RoleName = txtRoleName.Text;
                ObjBUserInfo = new BUserInfo();
                ObjEUserInfo.RoleID = ObjBUserInfo.SaveUserRoles(ObjEUserInfo);
                txtRoleName.Text = string.Empty;
                BindRoleData();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void BindRoleData()
        {
            try
            {
                ObjBUserInfo.GetUserRoles(ObjEUserInfo);
                if (ObjEUserInfo.dsUserRole != null)
                {
                    gcRole.DataSource = ObjEUserInfo.dsUserRole.Tables[0];
                    gvRole.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvRole_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int _IDValue = -1;
            try
            {
                if (gvRole.FocusedColumn != null && gvRole.GetFocusedRowCellValue("RoleID") != null)
                {
                    if (int.TryParse(gvRole.GetFocusedRowCellValue("RoleID").ToString(), out _IDValue))
                        ObjEUserInfo.RoleID = _IDValue;                    
                    BindFeatureData();
                    
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
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
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        

//*****************
    }
}