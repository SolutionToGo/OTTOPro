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
using BL;
using EL;

namespace OTTOPro.Report_Design
{
    public partial class frmProposalCoverPage1 : DevExpress.XtraEditors.XtraForm
    {
        BReportDesign ObjBReportDesign = new BReportDesign();
        EReportDesign ObjEReportDesign = new EReportDesign();
        public frmProposalCoverPage1()
        {
            InitializeComponent();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseSubject_Click(object sender, EventArgs e)
        {
            SelectionType(txtSubject);
        }

        private void btnBrowseContent_Click(object sender, EventArgs e)
        {
            SelectionType(txtContents);
        }

        private void SelectionType(RichTextBox text)
        {
            try
            {
                frmSelectTextModuleDetails frm = new frmSelectTextModuleDetails("Proposal Cover Page 1");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    text.Text = frm.Contents;
                    text.Tag = frm.TextID;
                }
               
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnBrowseSignature_Click(object sender, EventArgs e)
        {
            SelectionType(txtSignature);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ObjEReportDesign = new EReportDesign();
                ObjEReportDesign.Col1 = txtSubject.Text.ToString();
                ObjEReportDesign.Col2 = txtContents.Text.ToString();
                ObjEReportDesign.Col3 = txtSignature.Text.ToString();
                ObjBReportDesign = new BReportDesign();
                ObjBReportDesign.SaveReportDesign(ObjEReportDesign, "Proposal Cover Page 1");
                LoadExistingData();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmProposalCoverPage1_Load(object sender, EventArgs e)
        {
            LoadExistingData();
        }

        private void LoadExistingData()
        {
            try
            {
                ObjBReportDesign = new BReportDesign();
                ObjEReportDesign.dsReportDesign = ObjBReportDesign.GetExistingReportDesignData(ObjEReportDesign, "Proposal Cover Page 1");
                if (ObjEReportDesign.dsReportDesign != null)
                {
                    foreach (DataRow dr in ObjEReportDesign.dsReportDesign.Tables[0].Rows)
                    {
                        txtSubject.Text = dr["COL1"].ToString();
                        txtContents.Text = dr["COL2"].ToString();
                        txtSignature.Text = dr["COL3"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
//**************
    }
}