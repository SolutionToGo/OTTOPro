﻿namespace OTTOPro
{
    partial class frmFormBlattarticles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormBlattarticles));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveFormBlattArticles = new DevExpress.XtraEditors.SimpleButton();
            this.cmbFormBlatttypes = new System.Windows.Forms.ComboBox();
            this.gcFormBlattArticles = new DevExpress.XtraGrid.GridControl();
            this.gvFormBlattArticles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn92 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn93 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn94 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn95 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn98 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn99 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFormBlattArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormBlattArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnSaveFormBlattArticles);
            this.layoutControl1.Controls.Add(this.cmbFormBlatttypes);
            this.layoutControl1.Controls.Add(this.gcFormBlattArticles);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(797, 185, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(807, 593);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancel.Location = new System.Drawing.Point(626, 559);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveFormBlattArticles
            // 
            this.btnSaveFormBlattArticles.ImageOptions.Image = global::OTTOPro.Properties.Resources.Save_16x16;
            this.btnSaveFormBlattArticles.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSaveFormBlattArticles.Location = new System.Drawing.Point(713, 559);
            this.btnSaveFormBlattArticles.Name = "btnSaveFormBlattArticles";
            this.btnSaveFormBlattArticles.Size = new System.Drawing.Size(82, 22);
            this.btnSaveFormBlattArticles.StyleController = this.layoutControl1;
            this.btnSaveFormBlattArticles.TabIndex = 12;
            this.btnSaveFormBlattArticles.Text = "Speichern";
            this.btnSaveFormBlattArticles.Click += new System.EventHandler(this.btnSaveFormBlattArticles_Click);
            // 
            // cmbFormBlatttypes
            // 
            this.cmbFormBlatttypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormBlatttypes.FormattingEnabled = true;
            this.cmbFormBlatttypes.Location = new System.Drawing.Point(90, 12);
            this.cmbFormBlatttypes.Name = "cmbFormBlatttypes";
            this.cmbFormBlatttypes.Size = new System.Drawing.Size(315, 21);
            this.cmbFormBlatttypes.TabIndex = 11;
            this.cmbFormBlatttypes.SelectionChangeCommitted += new System.EventHandler(this.cmbFormBlatttypes_SelectionChangeCommitted);
            // 
            // gcFormBlattArticles
            // 
            this.gcFormBlattArticles.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcFormBlattArticles.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcFormBlattArticles.Location = new System.Drawing.Point(12, 37);
            this.gcFormBlattArticles.MainView = this.gvFormBlattArticles;
            this.gcFormBlattArticles.Name = "gcFormBlattArticles";
            this.gcFormBlattArticles.Size = new System.Drawing.Size(783, 518);
            this.gcFormBlattArticles.TabIndex = 10;
            this.gcFormBlattArticles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFormBlattArticles});
            // 
            // gvFormBlattArticles
            // 
            this.gvFormBlattArticles.Appearance.Empty.BackColor = System.Drawing.Color.Silver;
            this.gvFormBlattArticles.Appearance.Empty.Options.UseBackColor = true;
            this.gvFormBlattArticles.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvFormBlattArticles.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvFormBlattArticles.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvFormBlattArticles.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvFormBlattArticles.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvFormBlattArticles.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvFormBlattArticles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn92,
            this.gridColumn93,
            this.gridColumn94,
            this.gridColumn95,
            this.gridColumn98,
            this.gridColumn99,
            this.gridColumn1,
            this.gridColumn2});
            this.gvFormBlattArticles.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvFormBlattArticles.GridControl = this.gcFormBlattArticles;
            this.gvFormBlattArticles.Name = "gvFormBlattArticles";
            this.gvFormBlattArticles.OptionsCustomization.AllowColumnMoving = false;
            this.gvFormBlattArticles.OptionsCustomization.AllowFilter = false;
            this.gvFormBlattArticles.OptionsCustomization.AllowSort = false;
            this.gvFormBlattArticles.OptionsFilter.AllowFilterEditor = false;
            this.gvFormBlattArticles.OptionsMenu.EnableColumnMenu = false;
            this.gvFormBlattArticles.OptionsMenu.EnableFooterMenu = false;
            this.gvFormBlattArticles.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvFormBlattArticles.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn92
            // 
            this.gridColumn92.Caption = "Auswählen";
            this.gridColumn92.FieldName = "IsAssigned";
            this.gridColumn92.Name = "gridColumn92";
            this.gridColumn92.OptionsColumn.FixedWidth = true;
            this.gridColumn92.Visible = true;
            this.gridColumn92.VisibleIndex = 0;
            // 
            // gridColumn93
            // 
            this.gridColumn93.Caption = "WGID";
            this.gridColumn93.FieldName = "WGID";
            this.gridColumn93.Name = "gridColumn93";
            this.gridColumn93.OptionsColumn.AllowEdit = false;
            this.gridColumn93.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn94
            // 
            this.gridColumn94.Caption = "WG";
            this.gridColumn94.FieldName = "WG";
            this.gridColumn94.Name = "gridColumn94";
            this.gridColumn94.OptionsColumn.AllowEdit = false;
            this.gridColumn94.OptionsColumn.ReadOnly = true;
            this.gridColumn94.Visible = true;
            this.gridColumn94.VisibleIndex = 1;
            this.gridColumn94.Width = 73;
            // 
            // gridColumn95
            // 
            this.gridColumn95.Caption = "WA";
            this.gridColumn95.FieldName = "WA";
            this.gridColumn95.Name = "gridColumn95";
            this.gridColumn95.OptionsColumn.AllowEdit = false;
            this.gridColumn95.OptionsColumn.ReadOnly = true;
            this.gridColumn95.Visible = true;
            this.gridColumn95.VisibleIndex = 2;
            this.gridColumn95.Width = 154;
            // 
            // gridColumn98
            // 
            this.gridColumn98.Caption = "WIID";
            this.gridColumn98.FieldName = "WIID";
            this.gridColumn98.Name = "gridColumn98";
            this.gridColumn98.OptionsColumn.AllowEdit = false;
            this.gridColumn98.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn99
            // 
            this.gridColumn99.Caption = "WI";
            this.gridColumn99.FieldName = "WI";
            this.gridColumn99.Name = "gridColumn99";
            this.gridColumn99.OptionsColumn.AllowEdit = false;
            this.gridColumn99.OptionsColumn.ReadOnly = true;
            this.gridColumn99.Visible = true;
            this.gridColumn99.VisibleIndex = 3;
            this.gridColumn99.Width = 154;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "WG Beschreibung";
            this.gridColumn1.FieldName = "WGDescription";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 154;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "WA Beschreibung";
            this.gridColumn2.FieldName = "WADescription";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 155;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(807, 593);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcFormBlattArticles;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(787, 522);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.cmbFormBlatttypes;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(397, 25);
            this.layoutControlItem2.Text = "Auswählen :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(397, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(390, 25);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSaveFormBlattArticles;
            this.layoutControlItem3.Location = new System.Drawing.Point(701, 547);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(86, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 547);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(614, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnCancel;
            this.layoutControlItem4.Location = new System.Drawing.Point(614, 547);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(87, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmFormBlattarticles
            // 
            this.AcceptButton = this.btnSaveFormBlattArticles;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(807, 593);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormBlattarticles";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Formblatt Artikel";
            this.Load += new System.EventHandler(this.frmFormBlattarticles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFormBlattArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormBlattArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcFormBlattArticles;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFormBlattArticles;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn92;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn93;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn94;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn95;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn98;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn99;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.ComboBox cmbFormBlatttypes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnSaveFormBlattArticles;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}