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
    public partial class frmUpdateSupplierProposal : DevExpress.XtraEditors.XtraForm
    {
        ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = new BSupplier();
        private int _ProjectID = 0;

        public frmUpdateSupplierProposal()
        {
            InitializeComponent();
        }

        public frmUpdateSupplierProposal(int ProjectID)
        {
            InitializeComponent();
            _ProjectID = ProjectID;
        }

        private void frmUpdateSupplierProposal_Load(object sender, EventArgs e)
        {
            FillProposalNumbers();
        }

        private void FillProposalNumbers()
        {
            try
            {
                ObjESupplier.ProjectID = _ProjectID;
                ObjESupplier = ObjBSupplier.GetProposalNumber(ObjESupplier);
                gcProposal.DataSource = ObjESupplier.dtProposal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvProposal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvProposal != null && gvProposal.GetFocusedRowCellValue("SupplierProposalID") != null)
                {
                    int iValue = 0;
                    if (int.TryParse(gvProposal.GetFocusedRowCellValue("SupplierProposalID").ToString(), out iValue))
                    {
                        ObjESupplier.SupplierProposalID = iValue;
                        ObjESupplier = ObjBSupplier.GetProposalPostions(ObjESupplier);
                        //gcSupplier.DataSource = ObjESupplier.dtPositions;

                        
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}