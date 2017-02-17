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
using System.Threading;

namespace OTTOPro
{
    public partial class frmLoadProject : DevExpress.XtraEditors.XtraForm
    {
        BProject ObjBProject = new BProject();
        EProject ObjEProject = new EProject();
        DataTable dtPRojectList;
        DataTable dtFilteredList;

        public frmLoadProject()
        {
            InitializeComponent();
        }

        private void frmLoadProject_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                ObjBProject.GetProjectList(ObjEProject);
                dtPRojectList = ObjEProject.dtProjectList;
                if(txtKundeName.Text != string.Empty)
                    txtKundeName_EditValueChanged(null,null);
                if(txtProjectNr.Text != string.Empty)
                    txtProjectNr_EditValueChanged(null,null);
                else
                    dgProjectSearch.DataSource = dtPRojectList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retreive the Project List");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProject(false);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            LoadProject(true);
        }

        private void LoadProject(bool IsCopy)
        {
            try
            {
                if (dgProjectSearch != null && dgProjectSearch.CurrentRow != null && dgProjectSearch.CurrentRow.Cells["ProjectId"] != null)
                {
                    int ProjectID = 0;
                    if (int.TryParse(dgProjectSearch.CurrentRow.Cells["ProjectId"].Value.ToString(), out ProjectID))
                    {
                        frmProject Obj = new frmProject();
                        Obj.ProjectID = ProjectID;
                        Obj.IsCopy = IsCopy;
                        Obj.MdiParent = this.MdiParent;
                        this.Close();
                        Obj.Show();
                    }
                    else
                    {
                        throw new Exception("Invalid Project Selected");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void dgProjectSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                int index = e.RowIndex;
                dgProjectSearch.Rows[index].Selected = true;
            }
        }

        private void txtProjectNr_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProjectNr.Text != string.Empty && dtPRojectList != null && dtPRojectList.Rows.Count > 0 && txtKundeName.Text == string.Empty)
            {
                DataView dv = new DataView();
                dv = dtPRojectList.DefaultView;
                dv.RowFilter = "ProjectNumber like '%" + txtProjectNr.Text + "%'";
                dtFilteredList = dv.ToTable();
                dgProjectSearch.DataSource = dv;
            }
            else if (txtProjectNr.Text != string.Empty && dtPRojectList != null && dtPRojectList.Rows.Count > 0 && txtKundeName.Text != string.Empty)
            {
                DataView dv = new DataView();
                dv = dtFilteredList.DefaultView;
                dv.RowFilter = "ProjectNumber like '%" + txtProjectNr.Text + "%'";
                dgProjectSearch.DataSource = dv;
            }
            else if (txtProjectNr.Text == string.Empty)
            {
                BindData();
            }
        }

        private void txtKundeName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtKundeName.Text != string.Empty && dtPRojectList != null && dtPRojectList.Rows.Count > 0 && txtProjectNr.Text == string.Empty)
            {
                DataView dv = new DataView();
                dv = dtPRojectList.DefaultView;
                dv.RowFilter = "CustomerName like '%" + txtKundeName.Text + "%'";
                dtFilteredList = dv.ToTable();
                dgProjectSearch.DataSource = dv;
            }
            else if (txtKundeName.Text != string.Empty && dtPRojectList != null && dtPRojectList.Rows.Count > 0 && txtProjectNr.Text != string.Empty)
            {
                DataView dv = new DataView();
                dv = dtFilteredList.DefaultView;
                dv.RowFilter = "CustomerName like '%" + txtKundeName.Text + "%'";
                dgProjectSearch.DataSource = dv;
            }
            else if (txtKundeName.Text == string.Empty)
            {
                BindData();
            }
        }
       
    }
}