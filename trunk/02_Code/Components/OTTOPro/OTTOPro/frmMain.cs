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

namespace OTTOPro
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private static frmMain tfrmMain;

        public static frmMain Instance
        {
            get { return tfrmMain; }
        }


        //public static void UpdateStatus(bool Status)
        //{
        //    frmMain.Instance.tableLayoutPanel1.Visible = Status;
        //}
       
        private void pictureEditNewProject_Click(object sender, EventArgs e)
        {
            frmProject Obj = new frmProject();
            Obj.MdiParent = this;
            Obj.Show();
            this.LayoutMdi(MdiLayout.Cascade);

        }

        private void pictureEditLoadProject_EditValueChanged(object sender, EventArgs e)
        {
            frmLoadProject Obj = new frmLoadProject();
            Obj.MdiParent = this;
            Obj.Show();
        }
    }
}