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
    public partial class frmSelectRaster : DevExpress.XtraEditors.XtraForm
    {
        EGAEB objEGAEB = null;
        private string _LVRaster = string.Empty;
        public frmSelectRaster()
        {
            InitializeComponent();
        }
        public frmSelectRaster(EGAEB _objEGAEB)
        {
            InitializeComponent();
            objEGAEB = _objEGAEB;
        }

        public string LVRaster
        {
            get { return _LVRaster; }
            set { _LVRaster = value; }
        }

        private void frmSelectRaster_Load(object sender, EventArgs e)
        {
            try
            {
                txtOldRaster.Text = objEGAEB.OldRaster;
                txtNewRaster.Text = objEGAEB.NewRaster;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void CLCRasters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CLCRasters.SelectedIndex==0)
            {
                _LVRaster = txtOldRaster.Text;
            }
            else
            {
                _LVRaster = txtNewRaster.Text;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {              
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

       
    }
}