﻿using System;
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
using System.Threading;
using DevExpress.XtraSplashScreen;
using EL;
using BL;

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

        public static void LoadParentForm()
        {
            Instance.Show();
        }
        public void SetPictureBoxVisible(bool _result)
        {
            this.pictureBox1.Visible = _result;
        }
        public void SetLableVisible(bool _result)
        {
            this.label2.Visible = _result;
        }
        //void InitSkinGallery()
        //{
        //    DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(skinRibbonGalleryBarItem1, true);
        //}
       
        private void btnNewProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (fc != null)
                    {
                        if (frm.Name == "frmLoadProject")
                        {
                            frm.Close();
                            break;
                        }
                    }
                }
                frmProject Obj = new frmProject();
                Obj.MdiParent = this;
                label2.Visible = false;
                pictureBox1.Visible = false;
                Obj.Show();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnLoadProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLoadProject Obj = new frmLoadProject();
                Obj.MdiParent = this;
                label2.Visible = false;
                pictureBox1.Visible = false;
                Obj.Show();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
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

        private void btnShortCuts_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmShortCuts frm = new frmShortCuts();
            frm.ShowDialog();

        }

        private void barButtonItemExitProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }
        private void btnCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "frmLoadCustomerMaster")
                    {
                        form.Activate();
                        return;
                    }
                }
                    frmLoadCustomerMaster Obj = new frmLoadCustomerMaster();
                    Obj.MdiParent = this;
                    label2.Visible = false;
                    pictureBox1.Visible = false;
                    Obj.Show();                    
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnOTTO_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "frmLoadOTTOMaster")
                    {
                        form.Activate();
                        return;
                    }
                }
                frmLoadOTTOMaster Obj = new frmLoadOTTOMaster();
                Obj.MdiParent = this;
                label2.Visible = false;
                pictureBox1.Visible = false;
                Obj.Show();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSupplier_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmLoadSupplier")
                {
                    form.Activate();
                    return;
                }
            }
            frmLoadSupplier Obj = new frmLoadSupplier();
            Obj.MdiParent = this;
            label2.Visible = false;
            pictureBox1.Visible = false;
            Obj.Show();
        }

        private void btnArticledata_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmArticlesData")
                {
                    form.Activate();
                    return;
                }
            }
            frmArticlesData Obj = new frmArticlesData();
            Obj.MdiParent = this;
            label2.Visible = false;
            pictureBox1.Visible = false;
            Obj.Show();
        }

        private void btnTextModule_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTextModule Obj = new frmTextModule();
            Obj.ShowDialog();
        }

        private void btnDesignReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDesignReport Obj = new frmDesignReport("Form", 0, 0);
            Obj.ShowDialog();
        }

        private void btnTyp_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmType")
                {
                    form.Activate();
                    return;
                }
            }
            frmType Obj = new frmType();
            Obj.MdiParent = this;
            label2.Visible = false;
            pictureBox1.Visible = false;
            Obj.Show();
        }

        private void btnRabatt_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "frmRabattGroup")
                {
                    form.Activate();
                    return;
                }
            }
            frmRabattGroup Obj = new frmRabattGroup();
            Obj.MdiParent = this;
            label2.Visible = false;
            pictureBox1.Visible = false;
            Obj.Show();
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            //if (xtraTabbedMdiManager1.Pages.Count > 0)
            //{
            //    BackgroudImageVisibility(false);
            //}
            //else { BackgroudImageVisibility(true); }
        }

        public void BackgroudImageVisibility(bool visibility)
        {
            //if (visibility)
            //{
            //    pictureBox1.Visible = true;
            //    label2.Visible = true;
            //}
            //else
            //{
            //    pictureBox1.Visible = false;
            //    label2.Visible = false;
            //}
        }

        private void frmOTTOPro_MdiChildActivate(object sender, EventArgs e)
        {
          //  BackgroudImageVisibility(false);
        }

        private void btnUserData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "frmLoadUsers")
                    {
                        form.Activate();
                        return;
                    }
                }
                frmLoadUsers Obj = new frmLoadUsers();
                Obj.MdiParent = this;
                label2.Visible = false;
                pictureBox1.Visible = false;
                Obj.Show();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnFeature_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "frmFeature")
                    {
                        form.Activate();
                        return;
                    }
                }
                frmFeature Obj = new frmFeature();
                Obj.MdiParent = this;
                label2.Visible = false;
                pictureBox1.Visible = false;
                Obj.Show();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnImportArticleData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DialogResult result = fdImportFile.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    BArticles ObjBArticle = new BArticles();
                    EArticles ObjEArticle = new EArticles();
                    ObjEArticle = ObjBArticle.ImportExcelXLS(fdImportFile.FileName, ObjEArticle);
                    ObjEArticle = ObjBArticle.ImportArticleData(ObjEArticle);
                    Utility.ShowSucces("Data Imported Sucessfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmResetPassword Obj = new frmResetPassword();
                Obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}