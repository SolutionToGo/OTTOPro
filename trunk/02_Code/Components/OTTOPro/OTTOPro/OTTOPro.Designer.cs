namespace OTTOPro
{
    partial class frmOTTOPro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup2 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup3 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOTTOPro));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNewProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoadProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnUsers = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomers = new DevExpress.XtraBars.BarButtonItem();
            this.btnSuppliers = new DevExpress.XtraBars.BarButtonItem();
            this.btnPlanners = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemShortcuts = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btnShortCuts = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExitProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnOTTO = new DevExpress.XtraBars.BarButtonItem();
            this.btnSupplier = new DevExpress.XtraBars.BarButtonItem();
            this.btnArticledata = new DevExpress.XtraBars.BarButtonItem();
            this.btnTextModule = new DevExpress.XtraBars.BarButtonItem();
            this.btnDesignReport = new DevExpress.XtraBars.BarButtonItem();
            this.miHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSupplier = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgArticleMaster = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpSetting = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTextModule = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BarButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::OTTOPro.Properties.Resources.Logo_New;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNewProject,
            this.btnLoadProject,
            this.btnUsers,
            this.btnCustomers,
            this.btnSuppliers,
            this.btnPlanners,
            this.barButtonItemSave,
            this.barButtonItemShortcuts,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.skinRibbonGalleryBarItem1,
            this.barButtonItem5,
            this.btnShortCuts,
            this.barButtonItem6,
            this.barButtonItemExitProject,
            this.btnCustomer,
            this.btnOTTO,
            this.btnSupplier,
            this.btnArticledata,
            this.btnTextModule,
            this.btnDesignReport});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 32;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.miHome,
            this.rpSetting});
            this.ribbon.Size = new System.Drawing.Size(890, 143);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Caption = "Neues Projekt ";
            this.btnNewProject.Id = 1;
            this.btnNewProject.ImageOptions.ImageUri.Uri = "AddItem";
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewProject_ItemClick);
            // 
            // btnLoadProject
            // 
            this.btnLoadProject.Caption = "Projekt laden";
            this.btnLoadProject.Id = 2;
            this.btnLoadProject.ImageOptions.ImageUri.Uri = "Up";
            this.btnLoadProject.Name = "btnLoadProject";
            this.btnLoadProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadProject_ItemClick);
            // 
            // btnUsers
            // 
            this.btnUsers.Caption = "Users";
            this.btnUsers.Id = 4;
            this.btnUsers.ImageOptions.ImageUri.Uri = "Apply";
            this.btnUsers.Name = "btnUsers";
            // 
            // btnCustomers
            // 
            this.btnCustomers.Caption = "Customers";
            this.btnCustomers.Id = 5;
            this.btnCustomers.Name = "btnCustomers";
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Caption = "Suppliers";
            this.btnSuppliers.Id = 6;
            this.btnSuppliers.Name = "btnSuppliers";
            // 
            // btnPlanners
            // 
            this.btnPlanners.Caption = "Planners";
            this.btnPlanners.Id = 7;
            this.btnPlanners.Name = "btnPlanners";
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.Caption = "Projekt speichern";
            this.barButtonItemSave.Id = 10;
            this.barButtonItemSave.Name = "barButtonItemSave";
            this.barButtonItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemShortcuts
            // 
            this.barButtonItemShortcuts.Caption = "Short Cuts";
            this.barButtonItemShortcuts.Id = 14;
            this.barButtonItemShortcuts.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources.Reset_32x32;
            this.barButtonItemShortcuts.Name = "barButtonItemShortcuts";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Save -       Alt + S";
            this.barButtonItem1.Id = 16;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "New -       Alt + N";
            this.barButtonItem2.Id = 17;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Modify -  Alt + M";
            this.barButtonItem3.Id = 18;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Cancel -   Esc";
            this.barButtonItem4.Id = 19;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            // 
            // 
            // 
            galleryItemGroup1.Caption = "Group1";
            galleryItemGroup2.Caption = "Group2";
            galleryItemGroup3.Caption = "Group3";
            this.skinRibbonGalleryBarItem1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1,
            galleryItemGroup2,
            galleryItemGroup3});
            this.skinRibbonGalleryBarItem1.Id = 20;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 21;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // btnShortCuts
            // 
            this.btnShortCuts.Caption = "Abkürzungen";
            this.btnShortCuts.Id = 23;
            this.btnShortCuts.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources.Reset_32x32;
            this.btnShortCuts.Name = "btnShortCuts";
            this.btnShortCuts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShortCuts_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Version 1.1 (24-11-2016)";
            this.barButtonItem6.Id = 24;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItemExitProject
            // 
            this.barButtonItemExitProject.Caption = "Exit Project";
            this.barButtonItemExitProject.Id = 25;
            this.barButtonItemExitProject.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources.Close_32x32;
            this.barButtonItemExitProject.Name = "barButtonItemExitProject";
            this.barButtonItemExitProject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemExitProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExitProject_ItemClick);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Caption = "Kunden";
            this.btnCustomer.Id = 26;
            this.btnCustomer.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources.BOCustomer_32x32;
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomer_ItemClick);
            // 
            // btnOTTO
            // 
            this.btnOTTO.Caption = "OTTO";
            this.btnOTTO.Id = 27;
            this.btnOTTO.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources.BORole_32x32;
            this.btnOTTO.Name = "btnOTTO";
            this.btnOTTO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOTTO_ItemClick);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Caption = "Supplier";
            this.btnSupplier.Id = 28;
            this.btnSupplier.ImageOptions.Image = global::OTTOPro.Properties.Resources._1470736995_User_Customers;
            this.btnSupplier.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources._1470736995_User_Customers;
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSupplier_ItemClick);
            // 
            // btnArticledata
            // 
            this.btnArticledata.Caption = "Article Data";
            this.btnArticledata.Id = 29;
            this.btnArticledata.Name = "btnArticledata";
            this.btnArticledata.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnArticledata_ItemClick);
            // 
            // btnTextModule
            // 
            this.btnTextModule.Caption = "Text Module";
            this.btnTextModule.Id = 30;
            this.btnTextModule.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources.TextBox_32x32;
            this.btnTextModule.Name = "btnTextModule";
            this.btnTextModule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTextModule_ItemClick);
            // 
            // btnDesignReport
            // 
            this.btnDesignReport.Caption = "Design Report";
            this.btnDesignReport.Id = 31;
            this.btnDesignReport.ImageOptions.LargeImage = global::OTTOPro.Properties.Resources.DesignReport_32x32;
            this.btnDesignReport.Name = "btnDesignReport";
            this.btnDesignReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDesignReport_ItemClick);
            // 
            // miHome
            // 
            this.miHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.rpgSupplier,
            this.rpgArticleMaster});
            this.miHome.Name = "miHome";
            this.miHome.Text = "OTTOPro";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewProject);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLoadProject, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCustomer, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOTTO, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnShortCuts, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemSave, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemExitProject, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Project";
            // 
            // rpgSupplier
            // 
            this.rpgSupplier.ItemLinks.Add(this.btnSupplier);
            this.rpgSupplier.Name = "rpgSupplier";
            this.rpgSupplier.Text = "Supplier";
            // 
            // rpgArticleMaster
            // 
            this.rpgArticleMaster.ItemLinks.Add(this.btnArticledata);
            this.rpgArticleMaster.Name = "rpgArticleMaster";
            this.rpgArticleMaster.Text = "Article Master";
            // 
            // rpSetting
            // 
            this.rpSetting.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgTextModule});
            this.rpSetting.Name = "rpSetting";
            this.rpSetting.Text = "Settings";
            // 
            // rpgTextModule
            // 
            this.rpgTextModule.ItemLinks.Add(this.btnTextModule, true);
            this.rpgTextModule.ItemLinks.Add(this.btnDesignReport, true);
            this.rpgTextModule.Name = "rpgTextModule";
            this.rpgTextModule.Text = "Text Module Details";
            // 
            // BarButtonItem10
            // 
            this.BarButtonItem10.Caption = "Users";
            this.BarButtonItem10.Id = 10;
            this.BarButtonItem10.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItem10.ImageOptions.Image")));
            this.BarButtonItem10.Name = "BarButtonItem10";
            this.BarButtonItem10.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipTitleItem1.Text = "Otto Pro";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Maintains Customer Information";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.BarButtonItem10.SuperTip = superToolTip1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 637);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(890, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 5000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 618);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(890, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Powered by www.softwaretogo.de \r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::OTTOPro.Properties.Resources.LogoLatest;
            this.pictureBox1.Location = new System.Drawing.Point(0, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(890, 475);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(733, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Version 1.4 (06-03-2017)";
            // 
            // frmOTTOPro
            // 
            this.ActiveGlowColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 659);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmOTTOPro";
            this.Ribbon = this.ribbon;
            this.Text = "OTTOPro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOTTOPro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage miHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNewProject;
        private DevExpress.XtraBars.BarButtonItem btnLoadProject;
        private DevExpress.XtraBars.BarButtonItem btnUsers;
        private DevExpress.XtraBars.BarButtonItem btnCustomers;
        private DevExpress.XtraBars.BarButtonItem btnSuppliers;
        private DevExpress.XtraBars.BarButtonItem btnPlanners;
        internal DevExpress.XtraBars.BarButtonItem BarButtonItem10;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.Timer tmrStatus;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemShortcuts;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem btnShortCuts;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExitProject;
        private DevExpress.XtraBars.BarButtonItem btnCustomer;
        private DevExpress.XtraBars.BarButtonItem btnOTTO;
        private DevExpress.XtraBars.BarButtonItem btnSupplier;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSupplier;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgArticleMaster;
        private DevExpress.XtraBars.BarButtonItem btnArticledata;
        private DevExpress.XtraBars.BarButtonItem btnTextModule;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSetting;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTextModule;
        private DevExpress.XtraBars.BarButtonItem btnDesignReport;
    }
}