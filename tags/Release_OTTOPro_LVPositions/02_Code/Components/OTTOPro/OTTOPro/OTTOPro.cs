using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;

namespace OTTOPro
{
    public partial class frmOTTOPro : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static frmOTTOPro ObjOTTOPro;

        private frmOTTOPro()
        {
            InitializeComponent();
        }

        static frmOTTOPro()
        {
            frmObject = new frmOTTOPro();
        }

        private static frmOTTOPro frmObject;

        public static frmOTTOPro Instance
        {
            get { return frmObject; }
        }

        private void btnNewProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProject Obj = new frmProject();
            Obj.MdiParent = this;
            Obj.Show();
        }

        private void btnLoadProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoadProject Obj = new frmLoadProject();
            Obj.MdiParent = this;
            label1.Visible = false;
            label2.Visible = false;
            Obj.Show();
        }

        public static void UpdateStatus(string Status)
        {
            frmOTTOPro.Instance.tsStatus.Text = Status;
            frmOTTOPro.Instance.tmrStatus.Start();
        }

        public void tmrStatus_Tick(object sender, EventArgs e)
        {
            frmOTTOPro.Instance.tsStatus.Text = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmOTTOPro_Load(object sender, EventArgs e)
        {
        }
    }
}