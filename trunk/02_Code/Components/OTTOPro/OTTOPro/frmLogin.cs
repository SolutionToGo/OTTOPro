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
using System.Threading;
using EL;
using BL;

namespace OTTOPro
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                EUserInfo ObjEUserInfo = new EUserInfo();
                BUserInfo ObjBUserInfo = new BUserInfo();
                ObjEUserInfo.UserName = txtUserName.Text.ToLower();
                ObjEUserInfo.Password = Utility.Encrypt(txtPassword.Text);
                ObjEUserInfo = ObjBUserInfo.CheckUserCredentials(ObjEUserInfo);
                
                if(ObjEUserInfo.dtUserDetails.Rows.Count > 0)
                {
                    Utility.UserID = ObjEUserInfo.dtUserDetails.Rows[0]["UserID"] == DBNull.Value ? 0 : Convert.ToInt32(ObjEUserInfo.dtUserDetails.Rows[0]["UserID"]);
                    Utility.UserName = ObjEUserInfo.dtUserDetails.Rows[0]["UserName"] == DBNull.Value ? "" : Convert.ToString(ObjEUserInfo.dtUserDetails.Rows[0]["UserName"]);
                    Utility.FirstName = ObjEUserInfo.dtUserDetails.Rows[0]["FirstName"] == DBNull.Value ? "" : Convert.ToString(ObjEUserInfo.dtUserDetails.Rows[0]["FirstName"]);
                    Utility.LastName = ObjEUserInfo.dtUserDetails.Rows[0]["LastName"] == DBNull.Value ? "" : Convert.ToString(ObjEUserInfo.dtUserDetails.Rows[0]["LastName"]);
                    Utility.IsOTP = ObjEUserInfo.dtUserDetails.Rows[0]["IsOTP"] == DBNull.Value ? false : Convert.ToBoolean(ObjEUserInfo.dtUserDetails.Rows[0]["IsOTP"]);
                }
                if(Utility.IsOTP)
                {
                    frmResetPassword Obj = new frmResetPassword();
                    Obj.ShowDialog();
                    return;
                }
                if (ObjEUserInfo.dtFeature.Rows.Count <= 0)
                    throw new Exception("No Features Assigned For Selected User");
                this.Hide();
                frmOTTOPro.Instance.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnLogin_Click(null, null);
        }
    }
}