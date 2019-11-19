using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System.Threading;
using DevExpress.XtraSplashScreen;
using EL;
using BL;
using System.Configuration;
using System.IO;
using OTTOPro.Report_Design;
using DevExpress.XtraReports.UI;
using System.Data.OleDb;
using DataAccess;
using DevExpress.XtraEditors;

namespace OTTOPro
{
    public partial class frmOTTOPro : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static frmOTTOPro ObjOTTOPro;
        BProject ObjBProject = null;
        EProject ObjEProject = null;

        private frmOTTOPro()
        {
            InitializeComponent();
        }

        static frmOTTOPro()
        {
            frmObject = new frmOTTOPro();
        }

        private static frmOTTOPro frmObject;

        public static frmOTTOPro Instance
        {
            get { return frmObject; }
        }       

        public static void LoadParentForm()
        {
            Instance.Show();
        }

        public void SetPictureBoxVisible(bool _result)
        {
            this.pictureBox1.Visible = _result;
        }

        public void SetLableVisible(bool _result)
        {
            this.label2.Visible = _result;
        }

        public  BarMdiChildrenListItem ChildItems
        {
            get { return barMdiChildrenListItemProject; }
            set { barMdiChildrenListItemProject = value; }
        }

        private void btnNewProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (fc != null)
                    {
                        if (frm.Name == "frmLoadProject")
                        {
                            frm.Close();
                            break;
                        }
                    }
                }
                frmProject Obj = new frmProject();
                Obj.MdiParent = this;
                label2.Visible = false;
                pictureBox1.Visible = false;
                Obj.Show();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnLoadProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (fc != null)
                    {
                        if (frm.Name == "frmLoadProject")
                        {
                            frm.Close();
                            break;
                        }
                    }
                }
                frmLoadProject Obj = new frmLoadProject();
                Obj.MdiParent = this;
                label2.Visible = false;
                pictureBox1.Visible = false;
                Obj.Show();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public static void UpdateStatus(string Status)
        {
            frmOTTOPro.Instance.tsStatus.Text = Status;
            frmOTTOPro.Instance.tmrStatus.Start();
        }

        public void tmrStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                frmOTTOPro.Instance.tsStatus.Text = null;
                tmrStatus.Stop();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmOTTOPro_Load(object sender, EventArgs e)
        {
            try
            {
                chkAutoSave1.EditValue = Utility.AutoSave;
                if (Utility.ArticleDataAccess == "9")
                    rpgArticleMaster.Visible = false;

                if (Utility.CustomerDataAccess == "9")
                    btnCustomer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (Utility.SupplierDataAccess == "9")
                    btnSupplier.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (Utility.OTTODataAccess == "9")
                    btnOTTO.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                if (Utility.CustomerDataAccess == "9" && Utility.SupplierDataAccess == "9" && Utility.SupplierDataAccess == "9")
                    ribbonPageGroup5.Visible = false;
                if (Utility.UserDataAccess == "9")
                    ribbonPageGroup2.Visible = false;
                if (Utility.GeneralTextModuleAccess == "9" &&
                    Utility.CalculationTextModuleAccess == "9" &&
                    Utility.InvoiceTextModuleAccess == "9")
                {
                    btnTextModule.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                if (Utility.RoleID == 8)
                {
                    btnFormBlattarticles.Enabled = true;
                }
                lblUserName.Text = "Nutzername : " + Utility.UserName;
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                string strVersion = ObjBProject.GetDBVersion();
                lblDBVersion.Text = "Version Datenbank: " + strVersion;
            }
            catch (Exception ex){}
        }

        private void btnShortCuts_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmShortCuts frm = new frmShortCuts();
            frm.ShowDialog();

        }

        private void barButtonItemExitProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void btnCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLoadCustomerMaster Obj = new frmLoadCustomerMaster();
                Obj.ShowDialog();
            }
            catch (Exception ex) { Utility.ShowError(ex); }
        }

        private void btnOTTO_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLoadOTTOMaster Obj = new frmLoadOTTOMaster();
                Obj.ShowDialog();
            }
            catch (Exception ex){Utility.ShowError(ex);}
        }

        private void btnSupplier_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoadSupplier Obj = new frmLoadSupplier();
            Obj.ShowDialog();
        }

        private void btnArticledata_ItemClick(object sender, ItemClickEventArgs e)
        {            
            frmArticlesData Obj = new frmArticlesData();
            Obj.ShowDialog();
        }

        private void btnTextModule_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTextModule Obj = new frmTextModule();
            Obj.ShowDialog();
        }

        private void btnTyp_ItemClick(object sender, ItemClickEventArgs e)
        {            
            frmType Obj = new frmType();          
            Obj.ShowDialog();
        }

        private void btnRabatt_ItemClick(object sender, ItemClickEventArgs e)
        {            
            frmRabattGroup Obj = new frmRabattGroup();           
            Obj.ShowDialog();
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            //if (xtraTabbedMdiManager1.Pages.Count > 0)
            //{
            //    BackgroudImageVisibility(false);
            //}
            //else { BackgroudImageVisibility(true); }
        }

        public void BackgroudImageVisibility(bool visibility)
        {
            //if (visibility)
            //{
            //    pictureBox1.Visible = true;
            //    label2.Visible = true;
            //}
            //else
            //{
            //    pictureBox1.Visible = false;
            //    label2.Visible = false;
            //}
        }

        private void btnUserData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {                
                frmLoadUsers Obj = new frmLoadUsers();                
                Obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnFeature_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {                
                frmFeature Obj = new frmFeature();              
                Obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnImportArticleData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DialogResult result = fdImportFile.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    BArticles ObjBArticle = new BArticles();
                    EArticles ObjEArticle = new EArticles();
                    ObjEArticle = ObjBArticle.ImportExcelXLS(fdImportFile.FileName, ObjEArticle);
                    ObjEArticle = ObjBArticle.ImportArticleData(ObjEArticle);
                    Utility.ShowSucces("Data Imported Sucessfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmResetPassword Obj = new frmResetPassword();
                Obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        
        private void btnAddAccessories_ItemClick(object sender, ItemClickEventArgs e)
        {           
            frmAccessories Obj = new frmAccessories();           
            Obj.ShowDialog();
        }

        private void btnProjectImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string strFilePath = string.Empty;
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.InitialDirectory = @"C:\";
                dlg.Title = "Dateiauswahl für GAEB Import";

                dlg.CheckFileExists = true;
                dlg.CheckPathExists = true;

                dlg.Filter = "GAEB Files(*.D81;*.D83;*.D86;*.P81;*.P83;*.P86;*.X81;*.X83;*.X86) | *.D81;*.D83;*.D86;*.P81;*.P83;*.P86;*.X81;*.X83;*.X86";
                dlg.RestoreDirectory = true;

                dlg.ReadOnlyChecked = true;
                dlg.ShowReadOnly = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                    strFilePath = dlg.FileName;
                if (!string.IsNullOrEmpty(strFilePath))
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                    SplashScreenManager.Default.SetWaitFormDescription("Importieren...");
                    string strOutputFilepath = string.Empty;
                    string strOTTOFilePath = Application.UserAppDataPath + "\\";
                    if (!Directory.Exists(strOTTOFilePath))
                        Directory.CreateDirectory(strOTTOFilePath);
                    string strFileName = Path.GetFileNameWithoutExtension(strFilePath);
                    strOutputFilepath = strOTTOFilePath + strFileName + ".tml";
                    Utility.ProcesssFile(strFilePath, strOutputFilepath);
                    BGAEB ObjBGAEB = new BGAEB();
                    EGAEB ObjEGAEB = new EGAEB();
                    ObjEGAEB.UserID = Utility.UserID;
                    string strRaster = Utility.GetRaster(strOutputFilepath);
                    ObjEGAEB.dsLVData = Utility.CreateDatasetSchema(strOutputFilepath, string.Empty, strRaster, ObjEGAEB);
                    ObjEGAEB.LvRaster = strRaster;
                    ObjEGAEB = ObjBGAEB.ProjectImport(ObjEGAEB);
                    SplashScreenManager.CloseForm(false);
                    frmViewProject Obj = new frmViewProject(ObjEGAEB);
                    Obj.ShowDialog();
                    UpdateStatus("Projektdatenimport mit Erfolg abgeschlossen");
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Utility.ShowError(ex);
            }   
        }

        private void btnFormBlattarticles_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //frmFormBlattarticles frm = new frmFormBlattarticles();
                //frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnReportSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmReportSetting frm = new frmReportSetting();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        #region "Title Blatt"
        private void bbCoverSheetPath_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmCoverSheetPath Obj = new frmCoverSheetPath();
                Obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void bbAngebot_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Bitte warten…");

                if (ObjEProject == null)
                    ObjEProject = new EProject();
                if(ObjBProject == null)
                    ObjBProject = new BProject();
                ObjEProject = ObjBProject.GetPath(ObjEProject);
                var FolderPath = new DirectoryInfo(ObjEProject.TemplatePath).GetFiles("V-011*.dotx", SearchOption.AllDirectories).OrderByDescending(d => d.LastWriteTimeUtc).First();
                Object oTemplatePath = ObjEProject.TemplatePath + "\\" + FolderPath;
                if (File.Exists(Convert.ToString(oTemplatePath)))
                {
                    if (!Utility.fileIsOpen(Convert.ToString(oTemplatePath)))
                    {
                        Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                        ap.Documents.Open(oTemplatePath);
                        ap.Visible = true;
                        ap.Activate();
                    }
                    else
                        throw new Exception("Bitte schließen Sie die Angebots-Dokumente aller Projekte");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Sequence contains no elements"))
                    XtraMessageBox.Show("Die erforderliche Dokumentenvorlage ist nicht eingestellt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { SplashScreenManager.CloseForm(false); }
        }

        private void bbAufmass_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Bitte warten…");
                if (ObjEProject == null)
                    ObjEProject = new EProject();
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                ObjEProject = ObjBProject.GetPath(ObjEProject);

                Object oTemplatePath = ObjEProject.TemplatePath + "\\Aufmass_Template.dotx";
                if (File.Exists(Convert.ToString(oTemplatePath)))
                {
                    if (!Utility.fileIsOpen(Convert.ToString(oTemplatePath)))
                    {
                        Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                        ap.Documents.Open(oTemplatePath);
                        ap.Visible = true;
                        ap.Activate();
                    }
                    else
                        throw new Exception("Bitte schließen Sie die Aufmass-Dokumente aller Projekte");

                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Utility.ShowError(ex);
            }
        }

        private void bbRechnung_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Bitte warten…");
                if (ObjEProject == null)
                    ObjEProject = new EProject();
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                ObjEProject = ObjBProject.GetPath(ObjEProject);
                Object oTemplatePath = ObjEProject.TemplatePath + "\\Rechnung_Template.dotx";
                if (File.Exists(Convert.ToString(oTemplatePath)))
                {
                    if (!Utility.fileIsOpen(Convert.ToString(oTemplatePath)))
                    {
                        Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                        ap.Documents.Open(oTemplatePath);
                        ap.Visible = true;
                        ap.Activate();
                    }
                    else
                        throw new Exception("Bitte schließen Sie die Rechnung-Dokumente aller Projekte");

                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Utility.ShowError(ex);
            }
        }

        private void btnAngebot1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Bitte warten…");

                if (ObjEProject == null)
                    ObjEProject = new EProject();
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                ObjEProject = ObjBProject.GetPath(ObjEProject);
                var FolderPath = new DirectoryInfo(ObjEProject.TemplatePath).GetFiles("V-014*.dotx", SearchOption.AllDirectories).OrderByDescending(d => d.LastWriteTimeUtc).First();
                Object oTemplatePath = ObjEProject.TemplatePath + "\\" + FolderPath;
                if (File.Exists(Convert.ToString(oTemplatePath)))
                {
                    if (!Utility.fileIsOpen(Convert.ToString(oTemplatePath)))
                    {
                        Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                        ap.Documents.Open(oTemplatePath);
                        ap.Visible = true;
                        ap.Activate();
                    }
                    else
                        throw new Exception("Bitte schließen Sie die Angebots-Dokumente aller Projekte");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Sequence contains no elements"))
                    XtraMessageBox.Show("Die erforderliche Dokumentenvorlage ist nicht eingestellt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { SplashScreenManager.CloseForm(false); }
        }

        private void btnAngebot2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Bitte warten…");

                if (ObjEProject == null)
                    ObjEProject = new EProject();
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                ObjEProject = ObjBProject.GetPath(ObjEProject);
                var FolderPath = new DirectoryInfo(ObjEProject.TemplatePath).GetFiles("V-012*.dotx", SearchOption.AllDirectories).OrderByDescending(d => d.LastWriteTimeUtc).First();
                Object oTemplatePath = ObjEProject.TemplatePath + "\\"+ FolderPath;
                if (File.Exists(Convert.ToString(oTemplatePath)))
                {
                    if (!Utility.fileIsOpen(Convert.ToString(oTemplatePath)))
                    {
                        Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                        ap.Documents.Open(oTemplatePath);
                        ap.Visible = true;
                        ap.Activate();
                    }
                    else
                        throw new Exception("Bitte schließen Sie die Angebots-Dokumente aller Projekte");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Sequence contains no elements"))
                    XtraMessageBox.Show("Die erforderliche Dokumentenvorlage ist nicht eingestellt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { SplashScreenManager.CloseForm(false); }
        }

        private void btnAngebot3_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Bitte warten…");

                if (ObjEProject == null)
                    ObjEProject = new EProject();
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                ObjEProject = ObjBProject.GetPath(ObjEProject);
                var FolderPath = new DirectoryInfo(ObjEProject.TemplatePath).GetFiles("V-013*.dotx", SearchOption.AllDirectories).OrderByDescending(d => d.LastWriteTimeUtc).First();
                Object oTemplatePath = ObjEProject.TemplatePath + "\\" + FolderPath;
                if (File.Exists(Convert.ToString(oTemplatePath)))
                {
                    if (!Utility.fileIsOpen(Convert.ToString(oTemplatePath)))
                    {
                        Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                        ap.Documents.Open(oTemplatePath);
                        ap.Visible = true;
                        ap.Activate();
                    }
                    else
                        throw new Exception("Bitte schließen Sie die Angebots-Dokumente aller Projekte");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Sequence contains no elements"))
                    XtraMessageBox.Show("Die erforderliche Dokumentenvorlage ist nicht eingestellt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { SplashScreenManager.CloseForm(false); }
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string strFilePath = string.Empty;
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.InitialDirectory = @"C:\";
                dlg.Title = "Dateiauswahl für Data File Import";

                dlg.CheckFileExists = true;
                dlg.CheckPathExists = true;

                dlg.Filter = "All files (*.*)|*.*";
                dlg.RestoreDirectory = true;

                dlg.ReadOnlyChecked = true;
                dlg.ShowReadOnly = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    strFilePath = dlg.FileName;
                    string fileExt = Path.GetExtension(strFilePath);
                    if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = Utility.ReadExcel(strFilePath, fileExt); //read excel file  
                        
                        foreach(DataRow dr in dtExcel.Rows)
                        {
                            string str = Convert.ToString(dr["F2"]);
                            if(str.Substring(0,1) == "\n")
                                str = str.Substring(1);
                            if (str.Contains("\r"))
                                str = str.Replace("\r", "");
                            dr["F2"] = str;
                        }
                        DataTable dt = dtExcel.Copy();
                        BOTTO ObjBOTTO = new BOTTO();
                        ObjBOTTO.ImportCustomerData(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void barEditItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void chkAutoSave1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DUserInfo ObjDUserInfo = new DUserInfo();
                EUserInfo ObjEUserInfo = new EUserInfo();
                ObjEUserInfo.UserID = Utility.UserID;
                ObjEUserInfo.AutoSaveMode = Convert.ToBoolean(chkAutoSave1.EditValue);
                ObjDUserInfo.UpdateAutoSave(ObjEUserInfo);
                Utility.AutoSave = ObjEUserInfo.AutoSaveMode;
            }
            catch (Exception ex) { Utility.ShowError(ex); }
        }

        private void nbDeletePosition_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmProject f = (frmProject)this.ActiveMdiChild;
                f.DeletePosition();
            }
            catch (Exception ex){}
        }

        private void nbCopyPosition_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmProject f = (frmProject)this.ActiveMdiChild;
                f.CopyPosition();
            }
            catch (Exception ex) { }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F5))
            {
                nbDeletePosition_ItemClick(null, null);
                return true;
            }
            else if (keyData == Keys.F4)
            {
                nbCopyPosition_ItemClick(null, null);
                return true;
            }
            else if (keyData == (Keys.F5))
                btnRefreshProject_ItemClick(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmOTTOPro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
               var dlgrslt = XtraMessageBox.Show("Wollen Sie das Programm OTTO PRO jetzt beenden?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Convert.ToString(dlgrslt) == "No")
                    e.Cancel = true;
            }
            catch (Exception ex){}
        }

        private void btnRefreshProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                try
                {
                    frmProject f = (frmProject)this.ActiveMdiChild;
                    f.RefreshProject();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex){}
        }
    }
}