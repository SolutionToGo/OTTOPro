﻿using System;
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
    public partial class frmSelectDimension : DevExpress.XtraEditors.XtraForm
    {
        public EPosition ObjEPosition = null;
        public frmSelectDimension()
        {
            InitializeComponent();
        }

        private void frmSelectDimension_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjEPosition != null)
                    gcDimensions.DataSource = ObjEPosition.dtDimensions;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int IValue = gvDimensions.FocusedRowHandle;
                ObjEPosition.Dim1 = ObjEPosition.dtDimensions.Rows[IValue]["A"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[IValue]["A"].ToString();
                ObjEPosition.Dim2 = ObjEPosition.dtDimensions.Rows[IValue]["B"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[IValue]["B"].ToString();
                ObjEPosition.Dim3 = ObjEPosition.dtDimensions.Rows[IValue]["L"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[IValue]["L"].ToString();
                ObjEPosition.LPMA = ObjEPosition.dtDimensions.Rows[IValue]["ListPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(ObjEPosition.dtDimensions.Rows[IValue]["ListPrice"]);
                ObjEPosition.Mins = ObjEPosition.dtDimensions.Rows[IValue]["Minuten"] == DBNull.Value ? 0 : Convert.ToDecimal(ObjEPosition.dtDimensions.Rows[IValue]["Minuten"]);
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ObjEPosition.Dim1 = string.Empty;
            ObjEPosition.Dim2 = string.Empty;
            ObjEPosition.Dim3 = string.Empty;
            ObjEPosition.LPMA = 0;
            ObjEPosition.Mins = 0;
            this.Close();
        }

        private void frmSelectDimension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnOk_Click(null, null);
            else if (e.KeyChar == (char)Keys.Escape)
                btnCancel_Click(null, null);
        }
    }
}