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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace OTTOPro
{
    public partial class frmTextModule : DevExpress.XtraEditors.XtraForm
    {
        EProposal ObjEProposal = new EProposal();
        BProposal ObjBProposal = new BProposal();
        bool _isValidate = true;
        int _IDValue = -1;

        #region CONSTRUCTOR

        public frmTextModule()
        {
            InitializeComponent();
        }      
        #endregion  

        #region EVENTS

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ObjEProposal = new EProposal();
                ObjEProposal.CategoryID = -1;

                FrmCategory frm = new FrmCategory(Convert.ToInt32(_TextAreaID), ObjEProposal);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    BindCategories();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmTextModule_Load(object sender, EventArgs e)
        {
            BindTextModuleAreas();
            BindTextModuleGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.Text == "")
                {
                    throw new Exception("Please select Category");
                }
                if (ObjEProposal == null)
                    ObjEProposal = new EProposal();
                ParseTextModuleDetails();
                ObjBProposal = new BProposal();
                ObjEProposal.TextID = ObjBProposal.SaveTextModule(ObjEProposal);
                BindTextModuleGrid();
                Setfocus(gvContentDetails, "TextID", ObjEProposal.TextID);

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

        private void gvContentDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);

                if (info.InRow || info.InRowCell)
                {
                    if (gvContentDetails.SelectedRowsCount == 0)
                    {
                        return;
                    }
                    ObjEProposal = new EProposal();
                    BindTextModuleAreas();
                    GetTextModuleDetails();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        int _TextAreaID;
        private void cmbTextArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTextArea.Text != string.Empty)
                {
                    if (int.TryParse(cmbTextArea.SelectedValue.ToString(), out _TextAreaID))

                        if (_TextAreaID > 0)
                        {
                            BindCategories();
                            richEditControlContent.Text = "";
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        #endregion

        #region METHODS

        private void BindTextModuleAreas()
        {
            try
            {
                ObjBProposal.GetTextModuleAreas(ObjEProposal);
                if (ObjEProposal.dsTextModuleAreas != null)
                {
                    cmbTextArea.DataSource = null;
                    cmbTextArea.DataSource = ObjEProposal.dsTextModuleAreas.Tables[0];
                    cmbTextArea.DisplayMember = "TextAreas";
                    cmbTextArea.ValueMember = "TextAreaID";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindTextModuleGrid()
        {
            try
            {
                ObjBProposal.GetTextModuleAreas(ObjEProposal);
                if (ObjEProposal.dsTextModuleAreas != null)
                {
                    gcContentDetails.DataSource = ObjEProposal.dsTextModuleAreas.Tables[1];
                    gvContentDetails.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindCategories()
        {
            try
            {
                ObjBProposal.GetCategories(ObjEProposal, Convert.ToInt32(_TextAreaID));
                if (ObjEProposal.dsCategory != null)
                {
                    cmbCategory.DataSource = null;
                    cmbCategory.DataSource = ObjEProposal.dsCategory.Tables[0];
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Setfocus(GridView view, string _id, int _IdValue)
        {
            try
            {
                if (_IdValue > -1)
                {
                    int rowHandle = view.LocateByValue(_id, _IdValue);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        view.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ParseTextModuleDetails()
        {
            try
            {
                ObjEProposal.TextModuleArea = cmbTextArea.Text;
                ObjEProposal.Category = cmbCategory.Text;
                ObjEProposal.Contents = richEditControlContent.Text;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void GetTextModuleDetails()
        {
            try
            {
                if (gvContentDetails.GetFocusedRowCellValue("TextID") != DBNull.Value)
                {
                    if (int.TryParse(gvContentDetails.GetFocusedRowCellValue("TextID").ToString(), out _IDValue))
                        ObjEProposal.TextID = _IDValue;
                    cmbTextArea.Text = ObjEProposal.TextModuleArea = gvContentDetails.GetFocusedRowCellValue("TextModuleArea") == DBNull.Value ? "" : gvContentDetails.GetFocusedRowCellValue("TextModuleArea").ToString();
                    cmbCategory.Text = ObjEProposal.Category = gvContentDetails.GetFocusedRowCellValue("Category") == DBNull.Value ? "" : gvContentDetails.GetFocusedRowCellValue("Category").ToString();
                    richEditControlContent.Text = ObjEProposal.Contents = gvContentDetails.GetFocusedRowCellValue("Contents") == DBNull.Value ? "" : gvContentDetails.GetFocusedRowCellValue("Contents").ToString();

                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion




//****************
    }
}