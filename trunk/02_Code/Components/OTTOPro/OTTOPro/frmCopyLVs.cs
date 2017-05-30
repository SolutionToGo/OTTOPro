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
    public partial class frmCopyLVs : DevExpress.XtraEditors.XtraForm
    {
        private int _type; 
        public frmCopyLVs()
        {
            InitializeComponent();
        }

        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCopyLVs_Load(object sender, EventArgs e)
        {
            radioGroupType.SelectedIndex = 1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _type = radioGroupType.SelectedIndex;
        }
    }
}