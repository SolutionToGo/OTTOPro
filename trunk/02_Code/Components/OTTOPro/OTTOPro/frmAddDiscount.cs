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

namespace OTTOPro
{
    public partial class frmAddDiscount : DevExpress.XtraEditors.XtraForm
    {
        EProject ObjEProject = null;
        public frmAddDiscount(EProject _ObjEProject)
        {
            ObjEProject = _ObjEProject;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFromOZ.Text.Length > 0)
                {
                    char cLastCharacter = txtFromOZ.Text[txtFromOZ.Text.Length - 1];
                    if (cLastCharacter == '.')
                        ObjEProject.FromOZ = txtFromOZ.Text.Replace(",", ".");
                    else
                        ObjEProject.FromOZ = txtFromOZ.Text.Replace(",", ".") + ".";
                }
                if (txtToOZ.Text.Length > 0)
                {
                    char cLastCharacter = txtToOZ.Text[txtFromOZ.Text.Length - 1];
                    if (cLastCharacter == '.')
                        ObjEProject.ToOZ = txtToOZ.Text.Replace(",", ".");
                    else
                        ObjEProject.ToOZ = txtToOZ.Text.Replace(",", ".") + ".";
                }
                decimal dValue = 0;
                if (decimal.TryParse(txtDiscount.Text, out dValue))
                    ObjEProject.Discount = dValue;
                else
                    ObjEProject.Discount = dValue;
                ObjEProject.IsSave = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}