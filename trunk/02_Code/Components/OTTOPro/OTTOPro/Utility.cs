using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EL;
using GKSRVUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

                    OZ = strPOZ[i].Trim();
                    RasterLength = strPRaster[i].Length;
                    
                    OZLength = OZ.Trim().Length;

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
                        if (OZ=="")
                        {
                            str = str + string.Concat(Enumerable.Repeat(" ", RasterLength - OZLength)) + OZ + ".";
                        }
                        else
                        {
                            str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ + ".";
                        }
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
                    throw new Exception("Fehler beim Datenimport des Langtext");
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
                    throw new Exception("Fehler beim Datenimport des Langtext");
                }
                else
                {
                    throw new Exception("Error while importing langtext");
                }
            }
        }

        public static DataSet CreateDatasetSchema(string strFilePath, string strLVSection, string Raster, EGAEB ObjEGAEB)
        {
            DataSet dsXmlData = new DataSet("Generic");
            try
            {
                DataTable dtV = new DataTable("LVPos");
                dtV.Columns.Add("Art", typeof(string));
                dtV.Columns.Add("OZ", typeof(string));
                dtV.Columns.Add("Menge", typeof(decimal));
                dtV.Columns.Add("Einheit", typeof(string));
                dtV.Columns.Add("Kurztext", typeof(string));
                dtV.Columns.Add("Langtext", typeof(string));
                dtV.Columns.Add("EP", typeof(decimal));
                dtV.Columns.Add("GB", typeof(decimal));
                dtV.Columns.Add("Nachlass", typeof(string));
                dtV.Columns.Add("ParentOz", typeof(string));
                dtV.Columns.Add("Title", typeof(string));
                dtV.Columns.Add("SNO", typeof(int));
                dtV.Columns.Add("BezugBeschr", typeof(string));
                dtV.Columns.Add("BezugAusfNr", typeof(string));
                dtV.Columns.Add("Bedarf", typeof(string));
                dtV.Columns.Add("Nr", typeof(string));
                dtV.Columns.Add("BezugOZ", typeof(string));
                dsXmlData.Tables.Add(dtV);

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strFilePath);
                IDataObject obj = Clipboard.GetDataObject();
                XmlNodeList xnProjectInfo = xDoc.GetElementsByTagName("PrjInfo");
                foreach (XmlNode xn in xnProjectInfo)
                {
                    XmlNode xnPDescription = xn.SelectSingleNode("Bez");
                    if (xnPDescription != null)
                        ObjEGAEB.ProjectDescription = xnPDescription.InnerText;
                    else
                        ObjEGAEB.ProjectDescription = string.Empty;
                }

                XmlNodeList xnAGInfo = xDoc.GetElementsByTagName("AG");
                foreach (XmlNode xn in xnProjectInfo)
                {
                    XmlNode xnCustomerName = xn.SelectSingleNode("Name1");
                    if (xnCustomerName != null)
                        ObjEGAEB.CustomerName = xnCustomerName.InnerText;
                    else
                        ObjEGAEB.CustomerName = string.Empty;
                }

                XmlNodeList xnLVPos = xDoc.GetElementsByTagName("LVPos");
                string strART = string.Empty;
                int iSNO = 0;
                foreach (XmlNode xnPos in xnLVPos)
                {
                    iSNO++;
                    DataRow drLVPos = dtV.NewRow();
                    XmlNode xnArt = xnPos.SelectSingleNode("Art");
                    if (xnArt != null)
                    {
                        drLVPos["Art"] = strART = xnArt.InnerText;
                        if (strART == "Z")
                            continue;
                    }
                    XmlNode xnOZ = xnPos.SelectSingleNode("OZ");
                    if (xnOZ != null)
                    {
                        if (!xnOZ.InnerText.Contains("Z"))
                        {
                            drLVPos["OZ"] = PrepareOZ(xnOZ.InnerText, Raster);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    XmlNode xnMenge = xnPos.SelectSingleNode("Menge");
                    if (xnMenge != null)
                    {
                        decimal dValue = 0;
                        if (decimal.TryParse(xnMenge.InnerText, out dValue))
                            drLVPos["Menge"] = dValue;

                    }
                    XmlNode xnEinheit = xnPos.SelectSingleNode("Einheit");
                    if (xnEinheit != null)
                        drLVPos["Einheit"] = xnEinheit.InnerText;

                    XmlNode xnBezugBeschr = xnPos.SelectSingleNode("BezugBeschr");
                    if (xnEinheit != null)
                        drLVPos["BezugBeschr"] = xnBezugBeschr.InnerText;

                    XmlNode xnBezugAusfNr = xnPos.SelectSingleNode("BezugAusfNr");
                    if (xnEinheit != null)
                        drLVPos["BezugAusfNr"] = xnBezugAusfNr.InnerText;

                    XmlNode xnBedarf = xnPos.SelectSingleNode("Bedarf");
                    if (xnEinheit != null)
                        drLVPos["Bedarf"] = xnBedarf.InnerText;

                    XmlNode xnNr = xnPos.SelectSingleNode("Nr");
                    if (xnEinheit != null)
                        drLVPos["Nr"] = xnNr.InnerText;

                    XmlNode xnBezugOZ = xnPos.SelectSingleNode("BezugOZ");
                    if (xnEinheit != null)
                        drLVPos["BezugOZ"] = xnBezugOZ.InnerText;

                    XmlNode xnKurztext = xnPos.SelectSingleNode("Kurztext");
                    if (xnKurztext != null)
                    {
                        if (IsRtfText(xnKurztext.InnerText))
                        {
                            drLVPos["Kurztext"] = xnKurztext.InnerText;
                            if (strART.ToLower() == "ng")
                                drLVPos["Title"] = GetPlaintext(xnKurztext.InnerText);
                        }
                        else
                        {
                            drLVPos["Kurztext"] = GetRTFFormat(xnKurztext.InnerText);
                            if (strART.ToLower() == "ng")
                                drLVPos["Title"] = xnKurztext.InnerText;
                        }
                    }
                    XmlNode xnLangtext = xnPos.SelectSingleNode("Langtext");
                    if (xnLangtext != null)
                    {
                        string strTemp = string.Empty;
                        if (IsRtfText(xnLangtext.InnerText))
                            strTemp = GetPlaintext(xnLangtext.InnerText);
                        else
                            strTemp = xnLangtext.InnerText;
                        RichTextBox txt = new RichTextBox();
                        if (!string.IsNullOrEmpty(strTemp))
                        {
                            Clipboard.SetText(strTemp);
                            txt.Paste();
                            Clipboard.Clear();
                            //Thread.Sleep(100);
                        }
                        XmlNodeList xnlist = xnPos.SelectNodes("ExtDat/ExtDatName");
                        if (xnlist != null)
                        {
                            foreach (XmlNode xnExtdat in xnlist)
                            {
                                string strImage = xnExtdat.InnerText;
                                Image img = Image.FromFile(strImage);
                                Clipboard.SetImage(img);
                                txt.Paste();
                                Clipboard.Clear();
                            }
                        }
                        drLVPos["Langtext"] = txt.Rtf;
                    }


                    XmlNode xnEP = xnPos.SelectSingleNode("EP");
                    if (xnEP != null)
                    {
                        decimal dValue = 0;
                        if (decimal.TryParse(xnEP.InnerText, out dValue))
                            drLVPos["EP"] = dValue;
                        else
                            drLVPos["EP"] = 0;
                    }
                    XmlNode xnGB = xnPos.SelectSingleNode("GB");
                    if (xnGB != null)
                    {
                        decimal dValueDB = 0;
                        if (decimal.TryParse(xnGB.InnerText, out dValueDB))
                            drLVPos["GB"] = dValueDB;
                        else
                            drLVPos["GB"] = 0;
                    }
                    XmlNode xnNachlass = xnPos.SelectSingleNode("Nachlass");
                    if (strLVSection != string.Empty)
                        drLVPos["Nachlass"] = strLVSection;
                    else if (xnNachlass != null)
                    {
                        string str = xnNachlass.InnerText;
                        if (string.IsNullOrEmpty(str))
                            drLVPos["Nachlass"] = "HA";
                        else
                            drLVPos["Nachlass"] = str;
                    }

                    drLVPos["SNO"] = iSNO.ToString(); ;
                    dtV.Rows.Add(drLVPos);
                }
                Clipboard.SetDataObject(obj);
                foreach (DataRow dr in dsXmlData.Tables[0].Rows)
                {
                    string strPositionOZ = dr["OZ"].ToString();
                    if (strPositionOZ != string.Empty)
                    {
                        dr["ParentOz"] = GetParentOZ(strPositionOZ);
                    }
                    else
                    {
                        string strSNO = dr["SNO"].ToString();
                        string MaxValue = dsXmlData.Tables[0].Compute("MIN(SNO)", "SNO >'" + strSNO + "'AND OZ <> ''").ToString();
                        if (MaxValue != string.Empty)
                        {
                            DataRow[] drNextPosition = dsXmlData.Tables[0].Select("SNO=" + MaxValue);
                            dr["ParentOz"] = GetParentOZ(drNextPosition[0]["OZ"].ToString());
                        }
                        else
                        {
                            string Value = dsXmlData.Tables[0].Compute("MAX(SNO)", "SNO <'" + strSNO + "'AND OZ <> ''").ToString();
                            DataRow[] drNextPosition = dsXmlData.Tables[0].Select("SNO=" + Value);
                            dr["ParentOz"] = GetParentOZ(drNextPosition[0]["OZ"].ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Beim Import der GAEB-Datei ist ein Fehler aufgetreten!");
                }
                else
                {
                    throw new Exception("Error While Importing GAEB File");
                }
            }
            return dsXmlData;
        }

        public static string GetRaster(string strFilePath)
        {
            StringBuilder strRaster = new StringBuilder();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strFilePath);
                XmlNodeList xnLVInfo = xDoc.SelectNodes("/Generic/LVInfo");
                string strNew = string.Empty;
                foreach (XmlNode xn in xnLVInfo)
                {
                    XmlNode xnTyp1 = xn.SelectSingleNode("LVGliedTyp1");
                    if (xnTyp1 != null)
                    {
                        XmlNode xnLng1 = xn.SelectSingleNode("LVGliedLen1");
                        strNew = new string('9', Convert.ToInt32(xnLng1.InnerText));
                        strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp2 = xn.SelectSingleNode("LVGliedTyp2");
                    if (xnTyp2 != null && xnTyp2.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng2 = xn.SelectSingleNode("LVGliedLen2");
                        if (xnTyp2.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng2.InnerText));
                        else if (xnTyp2.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng2.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp3 = xn.SelectSingleNode("LVGliedTyp3");
                    if (xnTyp3 != null && xnTyp3.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng3 = xn.SelectSingleNode("LVGliedLen3");
                        if (xnTyp3.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng3.InnerText));
                        else if (xnTyp3.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng3.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp4 = xn.SelectSingleNode("LVGliedTyp4");
                    if (xnTyp4 != null && xnTyp4.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng4 = xn.SelectSingleNode("LVGliedLen4");
                        if (xnTyp4.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng4.InnerText));
                        else if (xnTyp4.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng4.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp5 = xn.SelectSingleNode("LVGliedTyp5");
                    if (xnTyp5 != null && xnTyp5.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng5 = xn.SelectSingleNode("LVGliedLen5");
                        if (xnTyp5.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng5.InnerText));
                        else if (xnTyp5.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng5.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }
                    strRaster.Append("9");
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Beim Import der GAEB-Datei ist ein Fehler aufgetreten!");
                }
                else
                {
                    throw new Exception("Error While Importing GAEB File");
                }
            }
            return strRaster.ToString();
        }

        public static bool fileIsOpen(string path)
        {
            System.IO.FileStream a = null;
            try
            {
                a = System.IO.File.Open(path,
                System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
                return false;
            }
            catch (System.IO.IOException ex)
            {
                return true;
            }
            finally
            {
                if (a != null)
                {
                    a.Close();
                    a.Dispose();
                }
            }
        }

        public static bool IsRtfText(string text)
        {
            bool _ISRTF = false;
            try
            {
                if (text.TrimStart().StartsWith("{\\rtf1", StringComparison.Ordinal))
                {
                    if (IsValidRtf(text))
                        _ISRTF = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return _ISRTF;
        }
        private static bool IsValidRtf(string text)
        {
            try
            {
                new RichTextBox().Rtf = text;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
        private static string GetParentOZ(string strPositionOZ)
        {
            string[] strOZ = strPositionOZ.Split('.');
            StringBuilder strParentOZ = new StringBuilder();
            try
            {
                if (strOZ != null && strOZ.Count() > 2)
                {
                    if (strOZ.Count() > 2)
                    {
                        strParentOZ.Append(strOZ[0] + ".");
                        if (strOZ.Count() > 3)
                        {
                            if (!string.IsNullOrEmpty(strOZ[1].Trim()))
                                strParentOZ.Append(strOZ[1] + ".");
                            if (strOZ.Count() > 4)
                            {
                                if (!string.IsNullOrEmpty(strOZ[2].Trim()))
                                    strParentOZ.Append(strOZ[2] + ".");
                                if (strOZ.Count() > 5 && !string.IsNullOrEmpty(strOZ[3].Trim()))
                                {
                                    strParentOZ.Append(strOZ[3] + ".");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strParentOZ.ToString();
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
        public static bool Isclose = false;
    }

}
