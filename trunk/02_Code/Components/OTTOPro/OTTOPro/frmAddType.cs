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
using DevExpress.XtraEditors.Repository;

namespace OTTOPro
{
    public partial class frmAddType : DevExpress.XtraEditors.XtraForm
    {
        EArticles ObjEArticle = null;
        BArticles ObjBArticle = null;
        private string _Typ = null;
        private string _FullName = null;
        private string _Date = null;
        int _WIID = 0;
        string _FormType = string.Empty;
        private DataTable _dtDates = null;
        public int DimensionID = 0;
        public bool _IsSave = false;

        public frmAddType()
        {
            InitializeComponent();
        }

        public frmAddType(int _id,string _type)
        {
            InitializeComponent();
            _WIID = _id;
            _FormType = _type;
        }

        public string Typ
        {
            get { return _Typ; }
            set { _Typ = value; }
        }

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public DataTable dtDates
        {
            get { return _dtDates; }
            set { _dtDates = value; }
        }

        private void frmAddType_Load(object sender, EventArgs e)
        {
            try
            {
                if(_FormType=="Type")
                {
                    FillTypeData();
                }
                if (_FormType == "ValidityDate")
                {
                    FillValidityDates();       
                    gvAddTyp.Columns["GültigkeitDatum"].ColumnEdit = repositoryItemDateEdit1;
                }
                if (_Typ == "DM")
                {
                    gcAddTyp.DataSource = _dtDates;
                    gvAddTyp.Columns["GültigkeitDatum"].ColumnEdit = repositoryItemDateEdit1;
                    gvAddTyp.Columns["DimensionID"].Visible = false;
                    gvAddTyp.BestFitColumns();
                }
            }
            catch (Exception ex){}
        }

        private void FillTypeData()
        {
            try
            {
                DataTable _dtType = new DataTable();
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
               _dtType= ObjBArticle.GetMultipleTyp(_WIID);
               if (_dtType != null)
                {
                    gcAddTyp.DataSource = _dtType;
                    gvAddTyp.BestFitColumns();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void FillValidityDates()
        {
            try
            {
                DataTable _dtyDates=new DataTable();
                if (ObjBArticle == null)
                    ObjBArticle = new BArticles();
               _dtyDates= ObjBArticle.GetValidityDates(_WIID);
               if (_dtyDates != null)
                {
                    gcAddTyp.DataSource = _dtyDates;
                    gvAddTyp.BestFitColumns();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void gvAddTyp_KeyPress(object sender, KeyPressEventArgs e)
        {
            gvAddTyp_DoubleClick(null, null);
        }

        private void gvAddTyp_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (_FormType == "Type")
                {
                    GetValues();
                }
                if (_FormType == "ValidityDate")
                {
                    GetDates();
                }
                if(_Typ == "DM")
                {
                    if (gvAddTyp.SelectedRowsCount != 0 && int.TryParse(Convert.ToString(gvAddTyp.GetFocusedRowCellValue("DimensionID")), out DimensionID))
                        _IsSave = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void GetValues()
        {
            try
            {
                if (gvAddTyp.FocusedColumn != null && gvAddTyp.GetFocusedRowCellValue("Typ") != null)
                {
                    _Typ = gvAddTyp.GetFocusedRowCellValue("Typ") == DBNull.Value ? "" : gvAddTyp.GetFocusedRowCellValue("Typ").ToString();
                    _FullName = gvAddTyp.GetFocusedRowCellValue("Lieferant") == DBNull.Value ? "" : gvAddTyp.GetFocusedRowCellValue("Lieferant").ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetDates()
        {
            try
            {
                if (gvAddTyp.FocusedColumn != null && gvAddTyp.GetFocusedRowCellValue("GültigkeitDatum") != null)
                {
                    _Date = gvAddTyp.GetFocusedRowCellValue("GültigkeitDatum") == DBNull.Value ? "" : gvAddTyp.GetFocusedRowCellValue("GültigkeitDatum").ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmAddType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Escape)
                    this.Close();
            }
            catch (Exception ex) { }
        }
    }
}