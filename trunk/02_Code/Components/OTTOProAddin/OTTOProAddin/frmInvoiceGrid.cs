using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTTOProAddin
{
    public partial class frmInvoiceGrid : Form
    {
        
        EInvoice ObjEInvoice = new EInvoice();
        BInvoice ObjBInvoice = new BInvoice();
        DataTable _dtinvoice = new DataTable();
        int _ProjectID;
        public frmInvoiceGrid()
        {
            InitializeComponent();
        }

        private void frmInvoiceGrid_Load(object sender, EventArgs e)
        {
            try
            {
                BindProjectDetail();
                cmbProjectNo.DropDownHeight = cmbProjectNo.ItemHeight * 8;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BindProjectDetail()
        {
            try
            {
                ObjBInvoice.GetProjectDetails(ObjEInvoice);
                if (ObjEInvoice.dsProject != null)
                {
                    cmbProjectNo.DataSource = null;
                    cmbProjectNo.DataSource = ObjEInvoice.dsProject.Tables[0].DefaultView;
                    cmbProjectNo.DisplayMember = "ProjectNumber";
                    cmbProjectNo.ValueMember = "ProjectID";
                    cmbProjectNo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbProjectNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbProjectNo.Text != string.Empty)
                {
                    if (int.TryParse(cmbProjectNo.SelectedValue.ToString(), out _ProjectID))

                        if (_ProjectID > 0)
                        {
                            ObjEInvoice.ProjectID = _ProjectID;
                            gvInvoice.DataSource = null;
                            ObjBInvoice.GetInvoiceDetails(ObjEInvoice);
                            if (ObjEInvoice.dsInvoice != null)
                            {
                                DataView dvInvoice = ObjEInvoice.dsInvoice.Tables[1].DefaultView;
                                dvInvoice.RowFilter = "ProjectID = '" + _ProjectID + "'";
                                _dtinvoice = dvInvoice.ToTable();
                                gvInvoice.DataSource = _dtinvoice;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (gvInvoice.CurrentRow.Cells[3].Value.ToString().Length > 0)
            {
                Clipboard.Clear();
                Clipboard.SetText(gvInvoice.CurrentRow.Cells[3].Value.ToString());
                this.Close();
            }
            else
            {
                this.Close();
            }

        }

        private void gvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

//***********************
    }
}
