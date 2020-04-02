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
    public partial class frmSelectsupplier : DevExpress.XtraEditors.XtraForm
    {
        private EGAEB ObjEGAEB = null;
        public frmSelectsupplier(EGAEB _ObjEGAEB)
        {
            ObjEGAEB = _ObjEGAEB;
            InitializeComponent();
        }

        private void frmSelectsupplier_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ObjEGAEB.Supplier))
                {
                    string strTemp = string.Empty;
                    string[] strsupplierlist = ObjEGAEB.Supplier.Split(',');
                    if (strsupplierlist != null && strsupplierlist.Count() > 0)
                    {
                        foreach (string str in strsupplierlist)
                        {
                            cmbSupplierList.Properties.Items.Add(str.Trim());
                            strTemp = str.Trim();
                        }
                        cmbSupplierList.SelectedItem = strTemp;
                    }
                }
            }
            catch (Exception ex){}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjEGAEB.SupplierName = Convert.ToString(cmbSupplierList.SelectedItem);
            ObjEGAEB.IsSave = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ObjEGAEB.SupplierName = string.Empty;
            ObjEGAEB.IsSave = false;
            this.Close();
        }
    }
}