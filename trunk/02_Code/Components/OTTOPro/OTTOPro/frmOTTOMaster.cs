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
using DevExpress.XtraTab;
using EL;
using BL;
using System.Threading;

namespace OTTOPro
{
    public partial class frmOTTOMaster : DevExpress.XtraEditors.XtraForm
    {
        EOTTO ObjEOTTO = null;
        BOTTO ObjBOTTO = null;
        private EOTTO _ObjEOTTO = null;
         
        public EOTTO ObjEOtto
        {
            get{return _ObjEOTTO;}
            set{_ObjEOTTO = value;}
        }

        public frmOTTOMaster(EOTTO ObjEOTTO1)
        {
            InitializeComponent();
            ObjEOTTO = ObjEOTTO1;
        } 

        private void frmOTTOMaster_Load(object sender, EventArgs e)
        {
            try
            {
                if (Utility.OTTODataAccess == "7")
                    btnSaveContact.Enabled = false;
                this.Text = "OTTO Kontaktdaten";
                BindContactsDetails();
            }
            catch (Exception ex){Utility.ShowError(ex);}
        }

        private void btnCancelOtto_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
               if (ObjEOTTO == null)
                    ObjEOTTO = new EOTTO();
                ParseOTTOContactsDetails();
                ObjBOTTO = new BOTTO();
                ObjEOTTO = ObjBOTTO.SaveOTTOContactDetails(ObjEOTTO);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex){Utility.ShowError(ex);}
        }

        private void ParseOTTOContactsDetails()
        {
            try
            {
                ObjEOTTO.ContactPerson = txtContactPerson.Text;
                ObjEOTTO.Cont_Telephone = txtTelephone.Text;
                ObjEOTTO.Fax = txtFax.Text;
                ObjEOTTO.EmailID = txtemail.Text;
                ObjEOTTO.TaxNo = txtTaxNo.Text;
                ObjEOTTO.DefaultContact = Convert.ToBoolean(checkEditDefaultContact.CheckState);
            }
            catch (Exception ex){throw;}
        }

        private void BindContactsDetails()
        {
            try
            {
                if (ObjEOTTO.ContactID > 0)
                {
                    txtContactPerson.Text = ObjEOTTO.ContactPerson;
                    txtTelephone.Text = ObjEOTTO.Cont_Telephone;
                    txtFax.Text = ObjEOTTO.Fax;
                    txtemail.Text = ObjEOTTO.EmailID;
                    txtTaxNo.Text = ObjEOTTO.TaxNo;
                    checkEditDefaultContact.EditValue = ObjEOTTO.DefaultContact;
                }
            }
            catch (Exception ex){throw;}
        }
    }
}