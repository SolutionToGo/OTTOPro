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
    public partial class frmAddRaster : DevExpress.XtraEditors.XtraForm
    {
        public int _ProjectID = 0;
        bool _isValidate = false;
        private string _NewRaster = string.Empty;
        private BGAEB objBGAEB = null;
        public frmAddRaster()
        {
            InitializeComponent();
        }
        public frmAddRaster(string _Raster)
        {
            InitializeComponent();
            txtOldRaster.Text = _Raster;
        }

        public string NewRaster
        {
            get { return _NewRaster; }
            set { _NewRaster = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;            
            this.Close();
        }

        private void rgRasterNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rgRasterNumbers.SelectedIndex == 0)
                {
                    AddRaster(1);
                }
                if (rgRasterNumbers.SelectedIndex == 1)
                {
                    if (objBGAEB == null)
                        objBGAEB = new BGAEB();
                   txtNewRaster.Text = _NewRaster = objBGAEB.GetOld_Raster(_ProjectID);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void AddRaster(int _Number)
        {
            try
            {
                string[] Levels = txtOldRaster.Text.Split('.');
                int Count = Levels.Length;
                if (Count >= 2)
                {
                    for (int i = 1; i <= _Number; i++)
                    {
                        Levels[0] = '9' + Levels[0];
                        Levels[1] = '9' + Levels[1];
                        Levels[2] = '1' + Levels[2];
                    }
                }
                String result = string.Join(".", Levels);
                txtNewRaster.Text = result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNewRaster.Text))
                {
                    if (Utility._IsGermany == true)
                    {
                        _isValidate = false;
                        throw new Exception("Geben Sie den gültigen Wert ein");
                    }
                    else
                    {
                        _isValidate = false;
                        throw new Exception("Please Enter Valid Value");
                    }
                }
                _NewRaster = txtNewRaster.Text;
                _isValidate = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmAddRaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult != DialogResult.Cancel)
                {
                    if (_isValidate == false)
                        e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmAddRaster_Load(object sender, EventArgs e)
        {
            try
            {
                rgRasterNumbers.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

//****************************
    }
}