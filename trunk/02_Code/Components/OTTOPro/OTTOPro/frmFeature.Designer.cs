namespace OTTOPro
{
    partial class frmFeature
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSaveFeature = new DevExpress.XtraEditors.SimpleButton();
            this.gcRole = new DevExpress.XtraGrid.GridControl();
            this.gvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSaveRole = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelRole = new DevExpress.XtraEditors.SimpleButton();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.gcFeature = new DevExpress.XtraGrid.GridControl();
            this.gvFeature = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiAccessLevels = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiAccessLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControl1.Controls.Add(this.btnSaveFeature);
            this.layoutControl1.Controls.Add(this.gcRole);
            this.layoutControl1.Controls.Add(this.btnSaveRole);
            this.layoutControl1.Controls.Add(this.btnCancelRole);
            this.layoutControl1.Controls.Add(this.txtRoleName);
            this.layoutControl1.Controls.Add(this.gcFeature);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(824, 377, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(809, 693);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSaveFeature
            // 
            this.btnSaveFeature.Image = global::OTTOPro.Properties.Resources.Save_16x16;
            this.btnSaveFeature.Location = new System.Drawing.Point(713, 659);
            this.btnSaveFeature.Name = "btnSaveFeature";
            this.btnSaveFeature.Size = new System.Drawing.Size(84, 22);
            this.btnSaveFeature.StyleController = this.layoutControl1;
            this.btnSaveFeature.TabIndex = 10;
            this.btnSaveFeature.Text = "Save";
            this.btnSaveFeature.Click += new System.EventHandler(this.btnSaveFeature_Click);
            // 
            // gcRole
            // 
            this.gcRole.Location = new System.Drawing.Point(12, 104);
            this.gcRole.MainView = this.gvRole;
            this.gcRole.Name = "gcRole";
            this.gcRole.Size = new System.Drawing.Size(785, 225);
            this.gcRole.TabIndex = 9;
            this.gcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRole});
            // 
            // gvRole
            // 
            this.gvRole.Appearance.Empty.BackColor = System.Drawing.Color.Silver;
            this.gvRole.Appearance.Empty.Options.UseBackColor = true;
            this.gvRole.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvRole.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvRole.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvRole.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvRole.Appearance.Row.BackColor = System.Drawing.Color.Silver;
            this.gvRole.Appearance.Row.Options.UseBackColor = true;
            this.gvRole.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRole.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5});
            this.gvRole.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvRole.GridControl = this.gcRole;
            this.gvRole.Name = "gvRole";
            this.gvRole.OptionsBehavior.Editable = false;
            this.gvRole.OptionsBehavior.ReadOnly = true;
            this.gvRole.OptionsCustomization.AllowColumnMoving = false;
            this.gvRole.OptionsFilter.AllowFilterEditor = false;
            this.gvRole.OptionsFind.FindNullPrompt = "Suchtext eingeben...";
            this.gvRole.OptionsFind.ShowFindButton = false;
            this.gvRole.OptionsMenu.EnableColumnMenu = false;
            this.gvRole.OptionsMenu.EnableFooterMenu = false;
            this.gvRole.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvRole.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRole.OptionsView.ShowGroupPanel = false;
            this.gvRole.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvRole_FocusedRowChanged);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "ID";
            this.gridColumn4.FieldName = "RoleID";
            this.gridColumn4.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Role Name";
            this.gridColumn5.FieldName = "RoleName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 841;
            // 
            // btnSaveRole
            // 
            this.btnSaveRole.Image = global::OTTOPro.Properties.Resources.Save_16x16;
            this.btnSaveRole.Location = new System.Drawing.Point(216, 66);
            this.btnSaveRole.Name = "btnSaveRole";
            this.btnSaveRole.Size = new System.Drawing.Size(76, 22);
            this.btnSaveRole.StyleController = this.layoutControl1;
            this.btnSaveRole.TabIndex = 8;
            this.btnSaveRole.Text = "Save";
            this.btnSaveRole.Click += new System.EventHandler(this.btnSaveRole_Click);
            // 
            // btnCancelRole
            // 
            this.btnCancelRole.Image = global::OTTOPro.Properties.Resources.Cancel_16x16;
            this.btnCancelRole.Location = new System.Drawing.Point(296, 66);
            this.btnCancelRole.Name = "btnCancelRole";
            this.btnCancelRole.Size = new System.Drawing.Size(76, 22);
            this.btnCancelRole.StyleController = this.layoutControl1;
            this.btnCancelRole.TabIndex = 7;
            this.btnCancelRole.Text = "Cancel";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(99, 42);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(273, 20);
            this.txtRoleName.StyleController = this.layoutControl1;
            this.txtRoleName.TabIndex = 6;
            // 
            // gcFeature
            // 
            this.gcFeature.Location = new System.Drawing.Point(12, 343);
            this.gcFeature.MainView = this.gvFeature;
            this.gcFeature.Name = "gcFeature";
            this.gcFeature.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpiAccessLevels});
            this.gcFeature.Size = new System.Drawing.Size(785, 312);
            this.gcFeature.TabIndex = 5;
            this.gcFeature.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFeature});
            // 
            // gvFeature
            // 
            this.gvFeature.Appearance.Empty.BackColor = System.Drawing.Color.Silver;
            this.gvFeature.Appearance.Empty.Options.UseBackColor = true;
            this.gvFeature.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvFeature.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvFeature.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvFeature.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvFeature.Appearance.Row.BackColor = System.Drawing.Color.Silver;
            this.gvFeature.Appearance.Row.Options.UseBackColor = true;
            this.gvFeature.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvFeature.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gvFeature.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6});
            this.gvFeature.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvFeature.GridControl = this.gcFeature;
            this.gvFeature.Name = "gvFeature";
            this.gvFeature.OptionsCustomization.AllowColumnMoving = false;
            this.gvFeature.OptionsFilter.AllowFilterEditor = false;
            this.gvFeature.OptionsFind.FindNullPrompt = "Suchtext eingeben...";
            this.gvFeature.OptionsFind.ShowFindButton = false;
            this.gvFeature.OptionsMenu.EnableColumnMenu = false;
            this.gvFeature.OptionsMenu.EnableFooterMenu = false;
            this.gvFeature.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvFeature.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvFeature.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "FeatureID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Feature Name";
            this.gridColumn2.FieldName = "FeatureName";
            this.gridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Description";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Access";
            this.gridColumn6.ColumnEdit = this.rpiAccessLevels;
            this.gridColumn6.FieldName = "AccessLevelID";
            this.gridColumn6.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 40;
            // 
            // rpiAccessLevels
            // 
            this.rpiAccessLevels.AutoHeight = false;
            this.rpiAccessLevels.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpiAccessLevels.Name = "rpiAccessLevels";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(809, 693);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcFeature;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 331);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(789, 316);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 321);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(789, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.emptySpaceItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(376, 92);
            this.layoutControlGroup2.Text = "Role Details :";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtRoleName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(352, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(352, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(352, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Role Name :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSaveRole;
            this.layoutControlItem4.Location = new System.Drawing.Point(192, 24);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCancelRole;
            this.layoutControlItem3.Location = new System.Drawing.Point(272, 24);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(192, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(376, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(413, 92);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcRole;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(789, 229);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSaveFeature;
            this.layoutControlItem6.Location = new System.Drawing.Point(701, 647);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(88, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(88, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(88, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 647);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(701, 26);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 693);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmFeature";
            this.Text = "Feature";
            this.Load += new System.EventHandler(this.frmFeature_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiAccessLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcFeature;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFeature;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRole;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnSaveRole;
        private DevExpress.XtraEditors.SimpleButton btnCancelRole;
        private DevExpress.XtraEditors.TextEdit txtRoleName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnSaveFeature;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpiAccessLevels;
    }
}