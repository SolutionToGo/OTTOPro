using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraSplashScreen;
namespace OTTOPro
{
    public partial class frmGAEBExport : Form
    {
        private int _ProjectID = 0;
        private int _Raster = 0;
        private string ProjectNumber = string.Empty;
        public string OutputFilePath = string.Empty;
        public string KNr = string.Empty;
        BGAEB ObjBGAEB = null;

        public frmGAEBExport(string tProjectNo, int ProjectID,int Raster_Count)
        {
            InitializeComponent();
            txtProjectName.Text = tProjectNo;
            txtFileName.Text = tProjectNo;
            _ProjectID = ProjectID;
            ProjectNumber = tProjectNo;
            _Raster = Raster_Count;
        }

        private void frmGAEBExport_Load(object sender, EventArgs e)
        {
            try
            {
                string[] _D_formats = { "D81", "D83", "D84", "D86", "P81", "P83", "P84", "P86", "X81", "X83", "X84", "X86" };
                string[] _P_formats = { "P81", "P83", "P84", "P86", "X81", "X83", "X84", "X86" };
                if (_Raster > 9)
                {
                    foreach (string p in _P_formats)
                    {
                        cmbFormatType.Properties.Items.Add(p);
                    }
                    cmbFormatType.SelectedIndex = cmbFormatType.Properties.Items.IndexOf("P83");
                }
                else
                {
                    foreach (string d in _D_formats)
                    {
                        cmbFormatType.Properties.Items.Add(d);
                    }
                    cmbFormatType.SelectedIndex = cmbFormatType.Properties.Items.IndexOf("D83");
                }
                txtFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (ObjBGAEB == null)
                {
                    ObjBGAEB = new BGAEB();
                }
                cmbLVSection.Enabled = true;
                DataTable dtLVSection = new DataTable();
                dtLVSection = ObjBGAEB.GetLVSection(_ProjectID);
                DataRow dr = dtLVSection.NewRow();
                dr["LVSection"] = "ALL";
                dtLVSection.Rows.Add(dr);
                cmbLVSection.DataSource = dtLVSection;
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
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFilePath.Text = dlg.SelectedPath;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Exportieren...");
                XmlDocument XMLDoc = null;
                if (ObjBGAEB == null)
                {
                    ObjBGAEB = new BGAEB();
                }
                if (cmbFormatType.Text != string.Empty)
                {
                    XMLDoc = ObjBGAEB.Export(_ProjectID, cmbLVSection.Text, cmbFormatType.Text);
                    string strOTTOFilePath = ConfigurationManager.AppSettings["OTTOFilePath"].ToString();
                    if (!Directory.Exists(strOTTOFilePath))
                        Directory.CreateDirectory(strOTTOFilePath);
                    string strOutputFilePath = string.Empty;
                    strOutputFilePath = OutputFilePath = txtFilePath.Text + "\\" + txtFileName.Text + "." + cmbFormatType.Text;
                    string strInputFilePath = strOTTOFilePath + txtFileName.Text + ".tml";
                    XMLDoc.Save(strInputFilePath);
                    Utility.ProcesssFile(strInputFilePath, strOutputFilePath);
                }
                else
                {
                    throw new Exception("Please select the format of GAEB file");
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}
