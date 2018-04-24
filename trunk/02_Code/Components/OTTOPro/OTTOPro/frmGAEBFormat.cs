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

namespace OTTOPro
{
    public partial class frmGAEBFormat : DevExpress.XtraEditors.XtraForm
    {
        private EGAEB ObjEGAEB = null;
        public frmGAEBFormat()
        {
            InitializeComponent();
        }
        public frmGAEBFormat(EGAEB _ObjEGAEB)
        {
            ObjEGAEB = _ObjEGAEB;
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFilePath.Text = dlg.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFileName.Text))
                    throw new Exception("Bitte machen Sie eine Eingabe zum Dateinamen");
                ObjEGAEB.IsSave = true;
                ObjEGAEB.FileNAme = txtFileName.Text;
                ObjEGAEB.OutputPath = txtFilePath.Text;
                if (rgGAEBVersion.SelectedIndex == 0)
                    ObjEGAEB.FileFormat = "D83";
                else if (rgGAEBVersion.SelectedIndex == 1)
                    ObjEGAEB.FileFormat = "P83";
                else if (rgGAEBVersion.SelectedIndex == 2)
                    ObjEGAEB.FileFormat = "X83";
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ObjEGAEB.IsSave = false;
            this.Close();
        }

        private void frmGAEBFormat_Load(object sender, EventArgs e)
        {
            try
            {
                int IValue = 0;
                IValue = ObjEGAEB.LvRaster.Replace(".",string.Empty).Length;
                if (IValue > 9)
                {
                    rgGAEBVersion.Properties.Items[0].Enabled = false;
                    rgGAEBVersion.SelectedIndex = 1;
                }
                if (!ObjEGAEB.IsMail)
                {
                    txtProjectNumber.Text = ObjEGAEB.ProjectNumber;
                    txtFileName.Text = ObjEGAEB.ProjectNumber;
                    txtFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                else
                {
                    txtProjectNumber.Text = ObjEGAEB.ProjectNumber;
                    txtFileName.Text = ObjEGAEB.FileNAme;
                    txtFilePath.Text = ObjEGAEB.OutputPath;
                    btnBrowse.Enabled = false;
                    txtFilePath.Properties.ReadOnly = true;
                    txtFileName.Properties.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}