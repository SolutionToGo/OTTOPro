﻿using DevExpress.XtraEditors;
using GKSRVUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
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
                if (ctrl is TextEdit && ctrl.Text == string.Empty)
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
                else if (ctrl is ComboBoxEdit && ((ComboBoxEdit)ctrl).SelectedItem == null)
                {
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
                else if (ctrl is ComboBoxEdit && ((ComboBoxEdit)ctrl).SelectedText.ToString() == "Select")
                {
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
            }
            if (!IsValid)
            {
                XtraMessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlToFocus.Focus();
            }
            return IsValid;
        }

        public static void ShowError(Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSucces(string Status)
        {
            XtraMessageBox.Show(Status, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string ProductFilePath = ConfigurationManager.AppSettings["ProductFilePath"].ToString();
                string ClientFilePath = ConfigurationManager.AppSettings["ClientFilePath"].ToString();
                string LicenseKey = ConfigurationManager.AppSettings["LicenseKey"].ToString();
                GKSRVApp ObjGKSRV = new GKSRVApp();
                ObjGKSRV.ProcessFile(strInputFile, strOututFile, ProductFilePath, ClientFilePath, LicenseKey);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
