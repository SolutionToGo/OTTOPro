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
using BL;

namespace OTTOPro
{
    public partial class frmTextDialog : DevExpress.XtraEditors.XtraForm
    {
        private EProposal _ObjEProposal = null;
        private BGAEB objBGAEB = null;
        public string strName = string.Empty;
        private string _NewLVSection = string.Empty;
        private bool _IsSave = false;
        private bool _ISUpdated = false;
        private bool _isFirstTime = true;
        private string _FormType;
        bool _isValidate = false;


        public string NewLVSection
        {
            get { return _NewLVSection; }
            set { _NewLVSection = value; }
        }
        public bool IsSave
        {
            get { return _IsSave; }
            set { _IsSave = value; } 
        }
        public frmTextDialog()
        {
            InitializeComponent();
        }
        public frmTextDialog(string _Type)
        {
            InitializeComponent();
            _FormType = _Type;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this._IsSave = true;
                if (string.IsNullOrEmpty(txtNewLVSection.Text))
                    if(Utility._IsGermany==true)
                    {
                        _isValidate = false;
                        throw new Exception("Geben Sie den gültigen Wert ein");
                    }
                    else
                    {
                        _isValidate = false;
                        throw new Exception("Please Enter Valid Value");
                    }
                if (_FormType == "Raster")
                {
                    DataTable dt = new DataTable();
                    objBGAEB = new BGAEB();
                    dt = objBGAEB.Get_LVRasters();
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["LVRasterName"].ToString() == txtNewLVSection.Text.Trim())
                            {
                                if (!Utility._IsGermany)
                                {
                                    _isValidate = false;
                                    throw new Exception("Raster already exist.!");
                                }
                                else
                                {
                                    //throw new Exception("Diese Kategorie existiert berets.!");
                                }

                            }
                        }
                    }
                }
                _NewLVSection = txtNewLVSection.Text;
                _isValidate = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this._IsSave = false;
            this.Close();
        }

        private void frmTextDialog_Load(object sender, EventArgs e)
        {
            if(_FormType=="LV Section")
            {
                this.Text = "Neu LV Sektion";
                lcitext.Text = "Neu LV Sektion";
                txtNewLVSection.Text = _NewLVSection;
            }
            if (_FormType == "Raster")
            {
                this.Text = "Neu LV Raster";
                lcitext.Text = "Neu LV Raster";
            }

        }

        private void txtNewLVSection_TextChanged(object sender, EventArgs e)
        {
            if (!_isFirstTime)
            {
                _ISUpdated = true;
            }
            _isFirstTime = false;
        }

        private void frmTextDialog_FormClosing(object sender, FormClosingEventArgs e)
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
        
    }
}