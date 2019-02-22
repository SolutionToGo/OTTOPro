using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace OTTOProAddin
{
    public partial class frmTextModule : Form
    {
        EProposal ObjEProposal = new EProposal();
        BProposal ObjBProposal = new BProposal();
        int _TextAreaID;
        int _CategoryID;
        DataTable _dtContents = new DataTable();

        public frmTextModule()
        {
            InitializeComponent();
        }

        private void frmTextModule_Load(object sender, EventArgs e)
        {
            BindTextModuleAreas();
           // BindTextModuleGrid();
        }

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
                    cmbTextArea.SelectedIndex = -1;
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
                    gvContentDetails.DataSource = ObjEProposal.dsTextModuleAreas.Tables[1];
                    this.gvContentDetails.Columns[4].Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbTextArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbTextArea.Text != string.Empty)
                {
                    if (int.TryParse(cmbTextArea.SelectedValue.ToString(), out _TextAreaID))

                        if (_TextAreaID > 0)
                        {
                            gvContentDetails.DataSource = null;
                            BindCategories();
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    cmbCategory.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.Text != string.Empty)
                {
                    if (int.TryParse(cmbCategory.SelectedValue.ToString(), out _CategoryID))

                        if (_CategoryID > 0)
                        {
                            gvContentDetails.DataSource = null;
                            ObjBProposal.GetTextModuleAreas(ObjEProposal);
                            if (ObjEProposal.dsTextModuleAreas != null)
                            {
                                DataView dvProposalContents = ObjEProposal.dsTextModuleAreas.Tables[1].DefaultView;
                                dvProposalContents.RowFilter = "TextAreaID = " + _TextAreaID + " AND CategoryID = '" + _CategoryID + "'";
                                _dtContents = dvProposalContents.ToTable();
                                gvContentDetails.DataSource = _dtContents;
                                this.gvContentDetails.Columns[4].Visible = false;
                                this.gvContentDetails.Columns[5].Visible = false;
                                this.gvContentDetails.Columns[6].Visible = false;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {

                Word.Application WordApp = new Word.Application();
                Word.Document WordDoc = Globals.ThisAddIn.Application.ActiveDocument;
                if (gvContentDetails.Rows.Count>0)
                {
                    WordDoc.ActiveWindow.Selection.Text = gvContentDetails.CurrentRow.Cells[3].Value.ToString();
                    this.Close(); 
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Word.Document WordDoc = Globals.ThisAddIn.Application.ActiveDocument;
            Export_Data_To_Word(gvContentDetails, WordDoc.Name,WordDoc);
            this.Close();
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename,Word.Document oDoc)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                //Word.Document oDoc = new Word.Document();
                //oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Segoe UI";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;
                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }
                //table style 
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            }
        }

//********************
    }
}
