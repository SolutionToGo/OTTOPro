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

namespace OTTOPro
{
    public partial class frmCoverSheetPath : DevExpress.XtraEditors.XtraForm
    {
        BProject ObjBProject = null;
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
                txtCoverSheetPath.Text = ObjBProject.GetPath();
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
                {
                    if (ObjBProject == null)
                        ObjBProject = new BProject();
                    txtCoverSheetPath.Text = folderDlg.SelectedPath;
                    ObjBProject.SavePath(folderDlg.SelectedPath);
                }
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
    }
}