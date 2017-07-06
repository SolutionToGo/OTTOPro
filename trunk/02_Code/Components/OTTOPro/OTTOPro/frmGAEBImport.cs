using BL;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTTOPro
{
    public partial class frmGAEBImport : Form
    {
        public string KNr = string.Empty;
        public BGAEB ObjBGAEB = new BGAEB();
        public int ProjectID = 0;
        public bool isbuild = false;
        public frmGAEBImport()
        {
            InitializeComponent();
        }

        private void frmGAEBImport_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utility.LVDetailsAccess == "7")
                    layoutControl1.Enabled = false;
                cmbLVSection.Enabled = true;
                cmbLVSection.DataSource = ObjBGAEB.GetLVSection(ProjectID);
                cmbLVSection.DisplayMember = "LVSection";
                cmbLVSection.ValueMember = "LVSection";
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string strInputFilePath = string.Empty;
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.InitialDirectory = @"C:\";
                dlg.Title = "Dateiauswahl für GAEB Import";

                dlg.CheckFileExists = true;
                dlg.CheckPathExists = true;

                dlg.Filter = "All files (*.*)|*.*";
                dlg.RestoreDirectory = true;

                dlg.ReadOnlyChecked = true;
                dlg.ShowReadOnly = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtImportFilePath.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Importieren...");
                if (txtImportFilePath.Text != string.Empty)
                {
                    string strOutputFilepath = string.Empty;
                    string strOTTOFilePath = ConfigurationManager.AppSettings["OTTOFilePath"].ToString();
                    if (!Directory.Exists(strOTTOFilePath))
                        Directory.CreateDirectory(strOTTOFilePath);
                    string strFileName = Path.GetFileNameWithoutExtension(txtImportFilePath.Text);
                    strOutputFilepath = strOTTOFilePath + strFileName + ".tml";
                    Utility.ProcesssFile(txtImportFilePath.Text, strOutputFilepath);
                    ProjectID = ObjBGAEB.Import(ProjectID, strOutputFilepath, cmbLVSection.Text);
                    isbuild = true;
                    this.Close();
                }
                else
                {
                    if (Utility._IsGermany == true)
                        throw new Exception("Bitte wählen Sie die zu importierende Datei aus");
                    else
                        throw new Exception("Please select the file to import");
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGAEBImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            SplashScreenManager.CloseForm(false);
        }
        
    }
}