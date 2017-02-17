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
using BL;
using EL;
using System.Threading;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace OTTOPro
{
    public partial class frmLoadProject : DevExpress.XtraEditors.XtraForm
    {
        BProject ObjBProject = new BProject();
        EProject ObjEProject = new EProject();
        DataTable dtPRojectList;

        public frmLoadProject()
        {
            InitializeComponent();
        }

        private void frmLoadProject_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                ObjBProject.GetProjectList(ObjEProject);
                dtPRojectList = ObjEProject.dtProjectList;
                gcProjectSearch.DataSource = dtPRojectList;
            }
            catch (Exception ex)
            {
                if(Utility._IsGermany == true)
                    throw new Exception("Die Projektübersicht konnte nicht generiert werden");
                else
                {
                    throw new Exception("Failed to retreive the Project List");
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProject(false);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            LoadProject(true);
        }

        private void LoadProject(bool IsCopy)
        {
            try
            {
                if (gcProjectSearch != null && dgProjectSearch != null  && dgProjectSearch.GetFocusedDataRow() != null 
                    && dgProjectSearch.GetFocusedDataRow()["ProjectId"] != null)
                {
                    int ProjectID = 0;
                    if (int.TryParse(dgProjectSearch.GetFocusedDataRow()["ProjectId"].ToString(), out ProjectID))
                    {
                        frmProject Obj = new frmProject();
                        Obj.ProjectID = ProjectID;
                        Obj.IsCopy = IsCopy;
                        Obj.MdiParent = this.MdiParent;
                        this.Close();
                        Obj.Show();
                    }
                    else
                    {
                        throw new Exception("Invalid Project Selected");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                int ProjectID = -1;
                string strFilePath = string.Empty;
                BGAEB ObjBGAEB = null;
                if (dgProjectSearch.GetFocusedDataRow() != null)
                {
                    if (int.TryParse(dgProjectSearch.GetFocusedDataRow()["ProjectId"].ToString(), out ProjectID))
                    {
                        if (ObjBGAEB == null)
                        {
                            ObjBGAEB = new BGAEB();
                        }
                        OpenFileDialog dlg = new OpenFileDialog();

                        dlg.InitialDirectory = @"C:\";
                        dlg.Title = "Open";

                        dlg.CheckFileExists = true;
                        dlg.CheckPathExists = true;

                        dlg.Filter = "All files (*.*)|*.*";
                        dlg.RestoreDirectory = true;

                        dlg.ReadOnlyChecked = true;
                        dlg.ShowReadOnly = true;

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                           strFilePath = dlg.FileName;
                           string ProjectNumber = dgProjectSearch.GetFocusedDataRow()["ProjectNumber"].ToString();
                           string ApplicationPath = ConfigurationManager.AppSettings["ApplicationPath"].ToString();
                           string InputFilePath = ConfigurationManager.AppSettings["InputFilePath"].ToString();
                           string OutputFilePath = ConfigurationManager.AppSettings["OutputFilePath"].ToString();
                           string ProductFilePath = ConfigurationManager.AppSettings["ProductFilePath"].ToString();
                           string ClientFilePath = ConfigurationManager.AppSettings["ClientFilePath"].ToString();
                           string LicenseKey = ConfigurationManager.AppSettings["LicenseKey"].ToString();
                           StreamWriter sw = null;
                           sw = File.CreateText(InputFilePath + ProjectNumber + ".vbs");
                           StringBuilder strContent = new StringBuilder();
                           strContent.Append("Set objExcel = CreateObject(" + "\"Excel.Application\"" + ")");
                           strContent.Append("\n objExcel.Application.Run ");
                           strContent.Append("\"'" + ApplicationPath + "'!mMain.RunwithParam\",");
                           strContent.Append("\"" + strFilePath + "\",");
                           strContent.Append("\"" + OutputFilePath + ProjectNumber + ".tml\",");
                           strContent.Append("\"" + ProductFilePath + "\",");
                           strContent.Append("\"" + ClientFilePath + "\",");
                           strContent.Append("\"" + LicenseKey + "\"");
                           strContent.Append("\n objExcel.DisplayAlerts = False");
                           strContent.Append("\n objExcel.Application.Quit");
                           strContent.Append("\n Set objExcel = Nothing");
                           sw.Write(strContent.ToString());
                           sw.Close();

                           Process scriptProc = new Process();
                           scriptProc.StartInfo.FileName = @"cscript";
                           scriptProc.StartInfo.WorkingDirectory = InputFilePath; //<---very important 
                           scriptProc.StartInfo.Arguments = "//B //Nologo " + ProjectNumber + ".vbs";
                           scriptProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //prevent console window from popping up
                           scriptProc.Start();
                           scriptProc.WaitForExit(); // <-- Optional if you want program running until your script exit
                           scriptProc.Close();
                           ProjectID = ObjBGAEB.Import(ProjectID, OutputFilePath + ProjectNumber + ".tml","");
                        }   
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