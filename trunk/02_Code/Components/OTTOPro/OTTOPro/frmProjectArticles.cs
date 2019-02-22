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
using DataAccess;

namespace OTTOPro
{
    public partial class frmProjectArticles : DevExpress.XtraEditors.XtraForm
    {
        private EPosition ObjEPosition = null;

        public frmProjectArticles(EPosition _ObjEPosition)
        {
            InitializeComponent();
            ObjEPosition = _ObjEPosition;
        }

        private void frmProjectArticles_Load(object sender, EventArgs e)
        {
            try
            {
                DPosition ObjDPosition = new DPosition();
                ObjDPosition.GetProjectArticles(ObjEPosition);
                if (ObjEPosition.dtProjectArticles != null)
                    gcProjectArticles.DataSource = ObjEPosition.dtProjectArticles;
            }
            catch (Exception ex){}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}