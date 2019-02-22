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
    public partial class frmAddSupplier : DevExpress.XtraEditors.XtraForm
    {
        ESupplier ObjESupplier =  null;
        BSupplier ObjBSupplier = new BSupplier();
        public bool _IsContinue = false;
        public frmAddSupplier(ESupplier _ObjESupplier)
        {
            InitializeComponent();
            ObjESupplier = _ObjESupplier;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
                    throw new Exception("Vollständiger Name Cannot be empty");
                if (!dxValidationProvider1.Validate())
                    return;
                ParseSupplierDetails();
                ObjBSupplier = new BSupplier();
                ObjESupplier = ObjBSupplier.SaveSupplierDetails(ObjESupplier);
                _IsContinue = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParseSupplierDetails()
        {
            try
            {
                ObjESupplier.SupplierFullName = txtFullName.Text;
                ObjESupplier.SupplierShortName = txtShortName.Text;
                ObjESupplier.Commentary = txtCommentary.Text;
                ObjESupplier.PaymentCondition = txtPaymentConditions.Text;
                ObjESupplier.SupplierEmailID = txtSupplierEmail.Text;
                ObjESupplier.SupplierStreet = txtSupptreet.Text;
                ObjESupplier.SupplierTelephone = txtSuppTelephone.Text;
                ObjESupplier.SupplierFax = txtSuppFax.Text;
            }
            catch (Exception ex) { throw; }
        }

        private void btnCancelContact_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}