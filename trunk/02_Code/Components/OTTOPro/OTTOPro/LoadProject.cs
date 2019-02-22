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
using System.Xml;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;

namespace OTTOPro
{
    public partial class frmLoadProject : DevExpress.XtraEditors.XtraForm
    {
        BProject ObjBProject = new BProject();
        EProject ObjEProject = new EProject();
        DataTable dtPRojectList;


        public frmLoadProject()
        {
            InitializeComponent();
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Loading...");
                BindData();
            }
            catch (Exception ex){}
            finally { SplashScreenManager.CloseForm(); }
        }
        
        public void frmLoadProject_Load(object sender, EventArgs e)
        {         
        }       

        public void BindData()
        {
            try
            {
                ObjBProject.GetProjectList(ObjEProject);
                dtPRojectList = ObjEProject.dtProjectList;
                gcProjectSearch.DataSource = dtPRojectList;
            }
            catch (Exception ex)
            {
                if(Utility._IsGermany == true)
                    throw new Exception("Die Projektübersicht konnte nicht generiert werden");
                else
                {
                    throw new Exception("Failed to retreive the Project List");
                }
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
       
                if (gcProjectSearch != null && dgProjectSearch != null  && dgProjectSearch.GetFocusedDataRow() != null 
                    && dgProjectSearch.GetFocusedDataRow()["ProjectId"] != null)
                {
                    int ProjectID = 0;
                    if (int.TryParse(dgProjectSearch.GetFocusedDataRow()["ProjectId"].ToString(), out ProjectID))
                    {
                        string _PrNr = dgProjectSearch.GetFocusedDataRow()["ProjectNumber"].ToString();                       
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.Text == _PrNr)
                            {
                                form.Activate();
                                return;
                            }
                        }
                       frmProject Obj = new frmProject();
                       Obj.ProjectID = ProjectID;
                       Obj.IsCopy = IsCopy;
                       Obj.MdiParent = this.MdiParent;
                       //this.Close();
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

        private void frmLoadProject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnLoad_Click(null, null);
            }
        }

        private void frmLoadProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmOTTOPro.Instance.MdiChildren.Count() == 1)
            {
                frmOTTOPro.Instance.SetPictureBoxVisible(true);
                frmOTTOPro.Instance.SetLableVisible(true);
            }
        }

        private void dgProjectSearch_DoubleClick(object sender, EventArgs e)
        {
            LoadProject(false);
        }

        private void dgProjectSearch_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gvDeleteProject_Click));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Kopieren", gvCopyProject_Click));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDeleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProjectSearch.GetFocusedRowCellValue("ProjectID") != null)
                {
                    int IValue = 0;
                    if(int.TryParse(Convert.ToString(dgProjectSearch.GetFocusedRowCellValue("ProjectID")),out IValue))
                    {
                        string _PrNr = dgProjectSearch.GetFocusedDataRow()["ProjectNumber"].ToString();
                         if(ObjBProject == null)
                             ObjBProject = new BProject();
                        ObjBProject.DeleteProject(IValue);
                        dgProjectSearch.DeleteSelectedRows();
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.Text == _PrNr)
                            {
                                Utility.Isclose = true;
                                form.Close();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvCopyProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProjectSearch.GetFocusedRowCellValue("ProjectID") != null)
                {
                    int IValue = 0;
                    if (int.TryParse(Convert.ToString(dgProjectSearch.GetFocusedRowCellValue("ProjectID")), out IValue))
                    {
                        frmCopyProject Obj = new frmCopyProject();
                        Obj.ShowDialog();
                        if (!string.IsNullOrEmpty(Obj._NewProjectNumber))
                        {
                            if (ObjBProject == null)
                                ObjBProject = new BProject();
                            if (ObjEProject == null)
                                ObjEProject = new EProject();
                            ObjEProject.ProjectID = IValue;
                            ObjEProject.UserID = Utility.UserID;
                            ObjEProject.ProjectNumber = Obj._NewProjectNumber;
                            ObjEProject = ObjBProject.CopyProject(ObjEProject);
                            BindData();
                            Utility.Setfocus(dgProjectSearch, "ProjectID", ObjEProject.ProjectID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}