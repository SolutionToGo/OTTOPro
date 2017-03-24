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
    public partial class FrmCategory : DevExpress.XtraEditors.XtraForm
    {
        private EProposal _ObjEProposal = null;
        private BProposal _ObjBProposal = null;
        private string _NewCategory = string.Empty;
        private int _TextID;
        public EProposal ObjEProposal
        {
            get { return _ObjEProposal; }
            set { _ObjEProposal = value; }
        }
        public FrmCategory()
        {
            InitializeComponent();
        }

        public FrmCategory(int _textID, EProposal ObjEP)
        {
            InitializeComponent();
            _TextID = _textID;
            ObjEProposal = ObjEP;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                if (_ObjBProposal == null)
                    _ObjBProposal = new BProposal();
                _ObjBProposal.GetCategories(ObjEProposal, _TextID);
                if (ObjEProposal.dsCategory != null)
                {
                    foreach(DataRow dr in ObjEProposal.dsCategory.Tables[0].Rows)
                    {
                        if(dr["CategoryName"].ToString()==txtCategory.Text.Trim())
                        {
                            throw new Exception("Category already exist.!");
                        }
                    }
                }
                _ObjEProposal.CategoryName = txtCategory.Text;
                _ObjBProposal.SaveCategory(_ObjEProposal, _TextID);
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}