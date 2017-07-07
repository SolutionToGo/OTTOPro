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
                    Utility.RoleID = ObjEUserInfo.dtUserDetails.Rows[0]["RoleID"] == DBNull.Value ? 0 : Convert.ToInt32(ObjEUserInfo.dtUserDetails.Rows[0]["RoleID"]);
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
                if (ObjEUserInfo.dtFeature.Rows.Count > 0)
                {
                   foreach(DataRow dr in ObjEUserInfo.dtFeature.Rows)
                   {
                       if (Convert.ToString(dr["FeatureID"]) == "1")
                           Utility.LVDetailsAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "2")
                           Utility.CalcAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "3")
                           Utility.LVsectionAddAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "4")
                           Utility.LVSectionEditAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "5")
                           Utility.ArticleDataAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "6")
                           Utility.CustomerDataAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "7")
                           Utility.SupplierDataAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "8")
                           Utility.OTTODataAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "9")
                           Utility.KomissionDataAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "10")
                           Utility.DeliveryAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "11")
                           Utility.InvoiceAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "12")
                           Utility.GeneralTextModuleAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "13")
                           Utility.CalculationTextModuleAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "14")
                           Utility.CalculationTextModuleAccessEdit = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "15")
                           Utility.InvoiceTextModuleAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "16")
                           Utility.InvoiceTextModuleAccessEdit = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "17")
                           Utility.UserDataAccess = Convert.ToString(dr["AccessLevel"]);
                       else if (Convert.ToString(dr["FeatureID"]) == "18")
                           Utility.ProjectDataAccess = Convert.ToString(dr["AccessLevel"]);
                   }
                }
                else
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