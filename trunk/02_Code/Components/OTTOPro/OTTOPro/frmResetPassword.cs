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
    public partial class frmResetPassword : DevExpress.XtraEditors.XtraForm
    {
        public frmResetPassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPassword.Text == txtNewPassword.Text)
                    if(Utility._IsGermany==true)
                    {
                        throw new Exception("Altes und Neues Passwort dürfen nicht übereinstimmen");
                    }
                    else
                    {
                        throw new Exception("Old Password and New Password should not be same");
                    }
                    throw new Exception("Old Password and New Password should not be same");
                if(txtNewPassword.Text != txtConfirmPassword.Text)
                    if (Utility._IsGermany == true)
                    {
                        throw new Exception("Die Passwortangaben stimmen nicht überein");
                    }
                    else
                    {
                        throw new Exception("Passwords do not match.");
                    }
                EUserInfo ObjEUserInfo = new EUserInfo();
                BUserInfo ObjBUserInfo = new BUserInfo();
                ObjEUserInfo.UserID = Utility.UserID;
                ObjEUserInfo.OldPassword = Utility.Encrypt(txtOldPassword.Text);
                ObjEUserInfo.NewPassword = Utility.Encrypt(txtNewPassword.Text);
                ObjEUserInfo.IsAdmin = false;
                ObjEUserInfo = ObjBUserInfo.ResetPassword(ObjEUserInfo);
                this.Close();
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

        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Utility.UserName;
            txtUserName.ReadOnly = true;
        }
    }
}