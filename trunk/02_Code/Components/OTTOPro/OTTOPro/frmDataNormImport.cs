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
using DATANORMUtility;

namespace OTTOPro
{
    public partial class frmDataNormImport : DevExpress.XtraEditors.XtraForm
    {
        public frmDataNormImport()
        {
            InitializeComponent();
        }

        private void gcArtilceData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                xtraOpenFileDialog1.RestoreDirectory = true;
                xtraOpenFileDialog1.Title = "Browse DATANORM Files";
                xtraOpenFileDialog1.Filter = "001 files (*.001)|*.001|All files (*.*)|*.*";
                xtraOpenFileDialog1.FilterIndex = 2;
                xtraOpenFileDialog1.CheckFileExists = true;
                xtraOpenFileDialog1.CheckPathExists = true;
                xtraOpenFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(xtraOpenFileDialog1.FileName))
                {
                  DataSet ds =   DNU.ProccessFile(xtraOpenFileDialog1.FileName, Application.UserAppDataPath);
                }
            }
            catch (Exception ex){}
        }

        private void gcArtilceData_Click(object sender, EventArgs e)
        {
          
        }
    }
}