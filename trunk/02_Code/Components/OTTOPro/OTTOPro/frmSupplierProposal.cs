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
using System.Collections;
using DevExpress.XtraEditors.Controls;

namespace OTTOPro
{
    public partial class frmSupplierProposal : DevExpress.XtraEditors.XtraForm
    {
        private int _ProjectID = 0;
        string _LvSection;
        string _WG = null;
        string _WA = null;
        BGAEB ObjBGAEB = new BGAEB();
        ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = new BSupplier();
        DataTable _dtPosotion = new DataTable();
        DataTable _dtSupplier=null;

        public frmSupplierProposal()
        {
            InitializeComponent();
        }

        public frmSupplierProposal(int ProjectID,string LvSection)
        {
            InitializeComponent();
            _ProjectID = ProjectID;
            _LvSection = LvSection;
        }

        private void frmSupplierProposal_Load(object sender, EventArgs e)
        {
            FillLVSection();
            cmbLVSection.SelectedIndex = -1;
        }

        private void FillLVSection()
        {
            ObjESupplier = ObjBSupplier.GetLVSectionForProposal(ObjESupplier, _ProjectID);            
            if (ObjESupplier.Article != null)
            {
                cmbLVSection.DataSource = ObjESupplier.Article.Tables[0];
                cmbLVSection.DisplayMember = "LVSection";
                cmbLVSection.ValueMember = "LVSection";
            }            
        }

        public void GetWGWA()
        {
            try
            {
                if (ObjESupplier.Article != null)
                {
                    cmbWGWA.DataSource = null;
                    DataView dvWGWA = ObjESupplier.Article.Tables[1].DefaultView;
                    dvWGWA.RowFilter = "LVSection = '" + cmbLVSection.Text + "'";
                    cmbWGWA.DataSource = dvWGWA;
                    cmbWGWA.DisplayMember = "WGWA";
                    cmbWGWA.ValueMember = "WGWA";
                    cmbWGWA.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetLVDetailsAndSupplier()
        {
            try
            {
                string[] strArr = null;
                char[] splitchar = { '-' };                
                strArr = cmbWGWA.SelectedValue.ToString().Split(splitchar);
                for (int count = 0; count <= strArr.Length - 1; count++)
                {
                     _WG = strArr[0];
                     _WA = strArr[1];
                }
                                
                if(_WG!=null && _WA!=null)
                {
                    ObjESupplier = ObjBSupplier.GetWGWAForProposal(ObjESupplier, _ProjectID, cmbLVSection.Text, Convert.ToInt32(_WG), Convert.ToInt32(_WA));
                    if (ObjESupplier.dsSupplier != null)
                    {
                        gcLVDetails.DataSource = ObjESupplier.dsSupplier.Tables[0];
                        gvLVDetails.BestFitColumns();

                        chkSupplierLists.DataSource = ObjESupplier.dsSupplier.Tables[1];
                        chkSupplierLists.DisplayMember = "ShortName";
                        chkSupplierLists.ValueMember = "id";
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbWGWA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetLVDetailsAndSupplier();
        }

        private void cmbLVSection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetWGWA();
            gcLVDetails.DataSource = null;
            chkSupplierLists.DataSource = null;
        }

        private void chkSupplierLists_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (chkSupplierLists.CheckedItems.Count == 9)
            {
                Int32 checkedItemIndex = chkSupplierLists.CheckedIndices[0];
                chkSupplierLists.SetItemChecked(checkedItemIndex, false);
            }
        }

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {               
                for (int i = ObjESupplier.dsSupplier.Tables[0].Columns.Count - 1; i >= 0; i--)
                {
                    string strcolname = ObjESupplier.dsSupplier.Tables[0].Columns[i].ColumnName.ToString();
                    if (strcolname != "PositionID")
                    {
                        ObjESupplier.dsSupplier.Tables[0].Columns.RemoveAt(i);
                    }
                }
                _dtPosotion = ObjESupplier.dsSupplier.Tables[0];

                _dtSupplier = new DataTable();
                _dtSupplier.Columns.Add("SupplierID");
                foreach (object item in chkSupplierLists.CheckedItems)
                {
                    DataRowView row = item as DataRowView;
                    DataRow dr = _dtSupplier.NewRow();
                    dr["SupplierID"] = row["id"];
                    _dtSupplier.Rows.Add(dr);
                }
                ObjESupplier = ObjBSupplier.SaveSupplierProposal(ObjESupplier, _ProjectID, cmbLVSection.Text, Convert.ToInt32(_WG), Convert.ToInt32(_WA), _dtPosotion, _dtSupplier);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }



//************
    }
}