using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GKSRVUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTTOPro
{
    class Utility
    {
        public static bool _IsGermany = false;

        public static bool ValidateRequiredFields(List<Control> requiredFields)
        {
            
            bool IsValid = true;
            Control ctrlToFocus = null;
            StringBuilder sb = new StringBuilder();

             if(Utility._IsGermany == true)
                 sb.AppendLine("Bitte machen Sie folgene Pflichtangaben");
                    else
                        sb.AppendLine("Please enter the following Values");


            
            sb.AppendLine();
            foreach (Control ctrl in requiredFields)
            {
                if (ctrl is TextEdit && ctrl.Text.Trim() == string.Empty)
                {
                    if (ctrl.Tag == "LV-Status")
                    {
                        return IsValid;
                    }
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
                else if (ctrl is System.Windows.Forms.ComboBox && ((System.Windows.Forms.ComboBox)ctrl).SelectedItem == null)
                {
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
                else if (ctrl is System.Windows.Forms.ComboBox && ((System.Windows.Forms.ComboBox)ctrl).SelectedText.ToString() == "Select")
                {
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
            }
            if (!IsValid)
            {
                XtraMessageBox.Show(sb.ToString(), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlToFocus.Focus();
            }
            return IsValid;
        }

        public static void ShowError(Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSucces(string Status)
        {
            XtraMessageBox.Show(Status, "abgeschlossen", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public static string CreateVBSFile(string strInputfile,string strOutPutfile ,string strVBSFilePath)
        {
            string strFilepath = string.Empty;
            try
            {
                string ApplicationPath = ConfigurationManager.AppSettings["ApplicationPath"].ToString();
                string ProductFilePath = ConfigurationManager.AppSettings["ProductFilePath"].ToString();
                string ClientFilePath = ConfigurationManager.AppSettings["ClientFilePath"].ToString();
                string LicenseKey = ConfigurationManager.AppSettings["LicenseKey"].ToString();

                StreamWriter sw = null;
                strFilepath = strVBSFilePath;
                sw = File.CreateText(strFilepath);
                StringBuilder strContent = new StringBuilder();
                strContent.Append("Set objExcel = CreateObject(" + "\"Excel.Application\"" + ")");
                strContent.Append("\n objExcel.Application.Run ");
                strContent.Append("\"'" + ApplicationPath + "'!mMain.RunwithParam\",");
                strContent.Append("\"" + strInputfile + "\",");
                strContent.Append("\"" + strOutPutfile + "\",");
                strContent.Append("\"" + ProductFilePath + "\",");
                strContent.Append("\"" + ClientFilePath + "\",");
                strContent.Append("\"" + LicenseKey + "\"");
                strContent.Append("\n objExcel.DisplayAlerts = False");
                strContent.Append("\n objExcel.Application.Quit");
                strContent.Append("\n Set objExcel = Nothing");
                sw.Write(strContent.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            return strFilepath;
        }

        public static void RunVBSScript(string strOTTOFilePath,string strProjectNumber)
        {
            try
            {
                Process scriptProc = new Process();
                scriptProc.StartInfo.FileName = @"cscript";
                scriptProc.StartInfo.WorkingDirectory = strOTTOFilePath; //<---very important 
                scriptProc.StartInfo.Arguments = "//B //Nologo " + strProjectNumber + ".vbs";
                scriptProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //prevent console window from popping up
                scriptProc.Start();
                scriptProc.WaitForExit(); // <-- Optional if you want program running until your script exit
                scriptProc.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void ProcesssFile(string strInputFile, string strOututFile)
        {
            try
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //string ProductFilePath = appPath + ConfigurationManager.AppSettings["ProductFilePath"].ToString();
                //string ClientFilePath = appPath + ConfigurationManager.AppSettings["ClientFilePath"].ToString();


                string ProductFilePath = appPath + ConfigurationManager.AppSettings["ProductFilePath"].ToString();
                string ClientFilePath = appPath + ConfigurationManager.AppSettings["ClientFilePath"].ToString();
                string LicenseKey = ConfigurationManager.AppSettings["LicenseKey"].ToString();
                GKSRVApp ObjGKSRV = new GKSRVApp();
                ObjGKSRV.ProcessFile(strInputFile, strOututFile, ProductFilePath, ClientFilePath, LicenseKey);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string PrepareOZ(string strOZ, string strRaster)
        {
            string str = string.Empty;
            try
            {
                string[] strPOZ = strOZ.Split('.');
                string[] strPRaster = strRaster.Split('.');
                int Count = -1;
                int i = -1;
                Count = strPOZ.Count();
                while (Count > 0)
                {
                    i = i + 1;
                    Count = Count - 1;
                    string OZ = string.Empty;
                    int OZLength = 0;
                    int RasterLength = 0;

                    OZ = strPOZ[i];
                    RasterLength = strPRaster[i].Length;
                    OZLength = strPOZ[i].Length;


                    if(Count == 0)
                    {
                       if(RasterLength == 1 && OZLength > 0)
                       {
                           str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ;
                       }
                       else if (OZLength > 0)
                       {
                           str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ + ".";
                       }
                    }
                    else
                    {
                        str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return str;
        }

        public static void Setfocus(GridView view, string _id, int _IdValue)
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

        private string EncryptInner(string input)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input)));
        }

        private byte[] Encrypt(byte[] input)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes("CategisOTTO", new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 });
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }

        public static string Decrypt(string input)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(input)));
        }

        private static byte[] Decrypt(byte[] input)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes("CategisOTTO", new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 });
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }

        public static string Encrypt(string input)
        {
            Utility sec = new Utility();
            return sec.EncryptInner(input);
        }

        public static string GetRTFFormat(string Plaintext)
        {
            try
            {
                System.Windows.Forms.RichTextBox rtf = new System.Windows.Forms.RichTextBox();
                rtf.Text = Plaintext;
                return rtf.Rtf;
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Datenimport langtext");
                }
                else
                {
                    throw new Exception("Error while importing langtext");
                }
            }
        }

        public static string GetPlaintext(string RTFText)
        {
            try
            {
                System.Windows.Forms.RichTextBox rtf = new System.Windows.Forms.RichTextBox();
                rtf.Rtf = RTFText;
                return rtf.Text;
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Datenimport langtext");
                }
                else
                {
                    throw new Exception("Error while importing langtext");
                }
            }
        }

        public static int UserID;
        public static string UserName;
        public static string FirstName;
        public static string LastName;
        public static bool IsOTP;
        public static int RoleID;

        public static string LVDetailsAccess = string.Empty;
        public static string CalcAccess = string.Empty;
        public static string ArticleDataAccess = string.Empty;
        public static string CustomerDataAccess = string.Empty;
        public static string OTTODataAccess = string.Empty;
        public static string SupplierDataAccess = string.Empty;
        public static string KomissionDataAccess = string.Empty;
        public static string DeliveryAccess = string.Empty;
        public static string InvoiceAccess = string.Empty;
        public static string LVsectionAddAccess = string.Empty;
        public static string LVSectionEditAccess = string.Empty;
        public static string UserDataAccess = string.Empty;
        public static string ProjectDataAccess = string.Empty;
        public static string GeneralTextModuleAccess = string.Empty;
        public static string CalculationTextModuleAccess = string.Empty;
        public static string CalculationTextModuleAccessEdit = string.Empty;
        public static string InvoiceTextModuleAccess = string.Empty;
        public static string InvoiceTextModuleAccessEdit = string.Empty;
    }

}
