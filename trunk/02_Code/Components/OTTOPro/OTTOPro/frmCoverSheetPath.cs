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

namespace OTTOPro
{
    public partial class frmCoverSheetPath : DevExpress.XtraEditors.XtraForm
    {
        BProject ObjBProject = null;
        EProject ObjEProject = null;
        public frmCoverSheetPath()
        {
            InitializeComponent();
        }

        private void frmCoverSheetPath_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                if (ObjEProject == null)
                    ObjEProject = new EProject();
                ObjEProject = ObjBProject.GetPath(ObjEProject);
                txtCoverSheetPath.Text = ObjEProject.CoverSheetPath;
                txtTemplatePath.Text = ObjEProject.TemplatePath;
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
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                    txtCoverSheetPath.Text = folderDlg.SelectedPath;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTemplateBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
                txtTemplatePath.Text = folderDlg.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCoverSheetPath.Text.Trim()))
                    throw new Exception("Please Select Valid Cover Sheet Path");
                if (string.IsNullOrEmpty(txtTemplatePath.Text.Trim()))
                    throw new Exception("Please Select Valid Template Sheet Path");
                if (ObjBProject == null)
                    ObjBProject = new BProject();
                ObjBProject.SavePath(txtCoverSheetPath.Text, txtTemplatePath.Text);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}