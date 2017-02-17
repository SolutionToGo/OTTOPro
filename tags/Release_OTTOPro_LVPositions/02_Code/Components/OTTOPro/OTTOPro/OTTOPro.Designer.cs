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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOTTOPro));
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNewProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoadProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnUsers = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomers = new DevExpress.XtraBars.BarButtonItem();
            this.btnSuppliers = new DevExpress.XtraBars.BarButtonItem();
            this.btnPlanners = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.miHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BarButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNewProject,
            this.btnLoadProject,
            this.btnUsers,
            this.btnCustomers,
            this.btnSuppliers,
            this.btnPlanners,
            this.barButtonItemSave});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 14;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.miHome});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(890, 143);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Caption = "New Project";
            this.btnNewProject.Id = 1;
            this.btnNewProject.ImageUri.Uri = "AddItem";
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewProject_ItemClick);
            // 
            // btnLoadProject
            // 
            this.btnLoadProject.Caption = "Load Project";
            this.btnLoadProject.Id = 2;
            this.btnLoadProject.ImageUri.Uri = "Up";
            this.btnLoadProject.Name = "btnLoadProject";
            this.btnLoadProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadProject_ItemClick);
            // 
            // btnUsers
            // 
            this.btnUsers.Caption = "Users";
            this.btnUsers.Id = 4;
            this.btnUsers.ImageUri.Uri = "Apply";
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
            this.barButtonItemSave.Caption = "Save Project";
            this.barButtonItemSave.Id = 10;
            this.barButtonItemSave.LargeGlyph = global::OTTOPro.Properties.Resources.SaveAll_32x32;
            this.barButtonItemSave.Name = "barButtonItemSave";
            // 
            // miHome
            // 
            this.miHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.miHome.Name = "miHome";
            this.miHome.Text = "OTTOPro";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewProject);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLoadProject);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemSave);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Project";
            // 
            // BarButtonItem10
            // 
            this.BarButtonItem10.Caption = "Users";
            this.BarButtonItem10.Glyph = ((System.Drawing.Image)(resources.GetObject("BarButtonItem10.Glyph")));
            this.BarButtonItem10.Id = 10;
            this.BarButtonItem10.Name = "BarButtonItem10";
            this.BarButtonItem10.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipTitleItem8.Text = "Otto Pro";
            toolTipItem8.LeftIndent = 6;
            toolTipItem8.Text = "Maintains Customer Information";
            superToolTip8.Items.Add(toolTipTitleItem8);
            superToolTip8.Items.Add(toolTipItem8);
            this.BarButtonItem10.SuperTip = superToolTip8;
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
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightCoral;
            this.label2.Location = new System.Drawing.Point(0, 618);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(890, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Powered by Categis Solutions";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(0, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(890, 494);
            this.label1.TabIndex = 11;
            this.label1.Text = "                     OTTO Pro                  \r\n   Donec Lobortis Lorem Ut Effic" +
    "itur.\r\n\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOTTOPro
            // 
            this.ActiveGlowColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 659);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmOTTOPro";
            this.Ribbon = this.ribbon;
            this.Text = "OTTOPro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOTTOPro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
    }
}