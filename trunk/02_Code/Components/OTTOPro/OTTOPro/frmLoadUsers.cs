﻿using System;
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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace OTTOPro
{
    public partial class frmLoadUsers : DevExpress.XtraEditors.XtraForm
    {
        EUserInfo ObjEUserInfo = new EUserInfo();
        BUserInfo ObjBUserInfo = new BUserInfo();
        List<Control> RequiredFields = new List<Control>();
        int _IDValue = -1;
        int _RoleID = -1;
        public frmLoadUsers()
        {
            InitializeComponent();
        }


        private void Setfocus(GridView view, string _id, int _IdValue)
        {
            try
            {
                if (_IdValue > -1)
                {
                    int rowHandle = view.LocateByValue(_id, _IdValue);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        view.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void BindUserData()
        {
            try
            {
                ObjBUserInfo.GetUser(ObjEUserInfo);
                if (ObjEUserInfo.dsUserInfo != null)
                {
                    gcUser.DataSource = ObjEUserInfo.dsUserInfo.Tables[0];
                    gvUser.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetUserDetails()
        {
            try
            {
                if (gvUser.GetFocusedRowCellValue("UserID") != DBNull.Value)
                {
                    if (int.TryParse(gvUser.GetFocusedRowCellValue("UserID").ToString(), out _IDValue))
                        ObjEUserInfo.UserID = _IDValue;
                    if (int.TryParse(gvUser.GetFocusedRowCellValue("RoleID").ToString(), out _RoleID))
                        cmbRoleName.SelectedValue = _RoleID;
                    txtUserName.Text = gvUser.GetFocusedRowCellValue("UserName") == DBNull.Value ? "" : gvUser.GetFocusedRowCellValue("UserName").ToString();
                    txtFName.Text = gvUser.GetFocusedRowCellValue("FirstName") == DBNull.Value ? "" : gvUser.GetFocusedRowCellValue("FirstName").ToString();
                    txtLName.Text = gvUser.GetFocusedRowCellValue("LastName") == DBNull.Value ? "" : gvUser.GetFocusedRowCellValue("LastName").ToString();
                    txtMobileNo.Text = gvUser.GetFocusedRowCellValue("MobileNo") == DBNull.Value ? "" : gvUser.GetFocusedRowCellValue("MobileNo").ToString();
                    txtMailId.Text = gvUser.GetFocusedRowCellValue("EmailID") == DBNull.Value ? "" : gvUser.GetFocusedRowCellValue("EmailID").ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmLoadUsers_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utility.UserDataAccess == "7")
                    btnSave.Enabled = false;
                RequiredFields.Add(cmbRoleName);
                RequiredFields.Add(txtUserName);
                RequiredFields.Add(txtFName);
                RequiredFields.Add(txtLName);
                BindUserRoles();
                BindUserData();
                gvUser.BestFitColumns();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utility.ValidateRequiredFields(RequiredFields))
                    return;
                if (ObjEUserInfo == null)
                    ObjEUserInfo = new EUserInfo();
                ParseUserDetails();
                ObjBUserInfo = new BUserInfo();
                ObjEUserInfo.UserID = ObjBUserInfo.SaveUserDetails(ObjEUserInfo);
                BindUserData();
                ClearData();
                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der Nutzerdaten");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("User Data Saved successfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParseUserDetails()
        {
            try
            {
                ObjEUserInfo.RoleID = _RoleID;
                ObjEUserInfo.UserName = txtUserName.Text;
                ObjEUserInfo.FirstName = txtFName.Text;
                ObjEUserInfo.LastName = txtLName.Text;
                ObjEUserInfo.MobileNo = txtMobileNo.Text;
                ObjEUserInfo.EmailID = txtMailId.Text;
                ObjEUserInfo.Password = Utility.Encrypt("Password@1234");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindUserRoles()
        {
            try
            {
                ObjBUserInfo.GetUserRoles(ObjEUserInfo);
                if (ObjEUserInfo.dsUserRole != null)
                {
                    cmbRoleName.DataSource = null;
                    cmbRoleName.DataSource = ObjEUserInfo.dsUserRole.Tables[0];
                    cmbRoleName.DisplayMember = "RoleName";
                    cmbRoleName.ValueMember = "RoleID";
                    cmbRoleName.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbRoleName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoleName.Text != string.Empty)
                {
                    if (int.TryParse(cmbRoleName.SelectedValue.ToString(), out _RoleID))

                        if (_RoleID > 0)
                        {
                            ObjEUserInfo.RoleID = _RoleID;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void rpiEditbutton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (Utility.UserDataAccess == "7")
                    return;
                GetUserDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ClearData()
        {
            ObjEUserInfo.UserID = -1;
            cmbRoleName.SelectedIndex = -1;
            txtUserName.Text=string.Empty;
            txtFName.Text=string.Empty;
            txtLName.Text=string.Empty;
            txtMobileNo.Text=string.Empty;
            txtMailId.Text = string.Empty;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Escape))
                {
                    btnCancel_Click(null, null);
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvUser_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Passwort zurücksetzen", ResetPassword_ItemClick));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ResetPassword_ItemClick(object sender, EventArgs e)
        {
            try
            {
                if (ObjBUserInfo == null)
                    ObjBUserInfo = new BUserInfo();
                if (ObjEUserInfo == null)
                    ObjEUserInfo = new EUserInfo();
                string strUserID = gvUser.GetFocusedRowCellValue("UserID").ToString();
                string strPassword = Utility.Encrypt("Password@1234");
                int IValue = 0;
                if(int.TryParse(strUserID,out IValue))
                {
                    ObjEUserInfo.UserID = IValue;
                    ObjEUserInfo.NewPassword = strPassword;
                    ObjEUserInfo.IsAdmin = true;
                    ObjEUserInfo = ObjBUserInfo.ResetPassword(ObjEUserInfo);
                    if (Utility._IsGermany == true)
                    {
                        Utility.ShowSucces("Rücksetzen des Passwortes erfolgt");
                    }
                    else
                    {
                        Utility.ShowSucces("Password Reset Done successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

    }
}