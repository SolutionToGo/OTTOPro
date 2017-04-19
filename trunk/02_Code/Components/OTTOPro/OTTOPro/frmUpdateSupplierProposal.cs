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
            ObjESupplier = ObjBSupplier.GetProposalNumber(ObjESupplier, _ProjectID);
            if (ObjESupplier.SupplierProposal != null)
            {
                gcProposal.DataSource = ObjESupplier.SupplierProposal.Tables[0].DefaultView;
                gvProposal.BestFitColumns();
            }
        }
//*****************
    }
}