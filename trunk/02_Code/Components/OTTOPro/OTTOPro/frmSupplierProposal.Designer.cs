namespace OTTOPro
{
    partial class frmSupplierProposal
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
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcLVDetails = new DevExpress.XtraGrid.GridControl();
            this.gvLVDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLVDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLVDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton3);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.checkedListBoxControl1);
            this.layoutControl1.Controls.Add(this.comboBoxEdit2);
            this.layoutControl1.Controls.Add(this.comboBoxEdit1);
            this.layoutControl1.Controls.Add(this.gcLVDetails);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1035, 290, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(574, 590);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(456, 36);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(106, 22);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 15;
            this.simpleButton3.Text = "Load LV Positions";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(12, 545);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(170, 33);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "Generate\r\n Supplier Proposal PDF\r\n";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(353, 545);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(209, 33);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Send\r\nSupplier Proposal Email";
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkedListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("FEDCO"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null)});
            this.checkedListBoxControl1.Location = new System.Drawing.Point(12, 360);
            this.checkedListBoxControl1.MultiColumn = true;
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(550, 181);
            this.checkedListBoxControl1.StyleController = this.layoutControl1;
            this.checkedListBoxControl1.TabIndex = 6;
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(257, 36);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Size = new System.Drawing.Size(195, 20);
            this.comboBoxEdit2.StyleController = this.layoutControl1;
            this.comboBoxEdit2.TabIndex = 5;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(257, 12);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(305, 20);
            this.comboBoxEdit1.StyleController = this.layoutControl1;
            this.comboBoxEdit1.TabIndex = 4;
            // 
            // gcLVDetails
            // 
            this.gcLVDetails.Location = new System.Drawing.Point(12, 76);
            this.gcLVDetails.MainView = this.gvLVDetails;
            this.gcLVDetails.Name = "gcLVDetails";
            this.gcLVDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1});
            this.gcLVDetails.Size = new System.Drawing.Size(550, 244);
            this.gcLVDetails.TabIndex = 14;
            this.gcLVDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLVDetails});
            // 
            // gvLVDetails
            // 
            this.gvLVDetails.Appearance.Empty.BackColor = System.Drawing.Color.Silver;
            this.gvLVDetails.Appearance.Empty.Options.UseBackColor = true;
            this.gvLVDetails.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvLVDetails.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvLVDetails.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvLVDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvLVDetails.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvLVDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLVDetails.Appearance.Row.BackColor = System.Drawing.Color.Silver;
            this.gvLVDetails.Appearance.Row.Options.UseBackColor = true;
            this.gvLVDetails.Appearance.SelectedRow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvLVDetails.Appearance.SelectedRow.Options.UseFont = true;
            this.gvLVDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29});
            this.gvLVDetails.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLVDetails.GridControl = this.gcLVDetails;
            this.gvLVDetails.Name = "gvLVDetails";
            this.gvLVDetails.OptionsBehavior.Editable = false;
            this.gvLVDetails.OptionsBehavior.ReadOnly = true;
            this.gvLVDetails.OptionsCustomization.AllowColumnMoving = false;
            this.gvLVDetails.OptionsFilter.AllowFilterEditor = false;
            this.gvLVDetails.OptionsFind.AlwaysVisible = true;
            this.gvLVDetails.OptionsFind.FindNullPrompt = "Suchtext eingeben...";
            this.gvLVDetails.OptionsFind.ShowFindButton = false;
            this.gvLVDetails.OptionsMenu.EnableColumnMenu = false;
            this.gvLVDetails.OptionsMenu.EnableFooterMenu = false;
            this.gvLVDetails.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvLVDetails.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLVDetails.OptionsView.RowAutoHeight = true;
            this.gvLVDetails.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceCell.Options.UseFont = true;
            this.gridColumn26.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceHeader.Options.UseFont = true;
            this.gridColumn26.Caption = "LV Position Nr";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 0;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceCell.Options.UseFont = true;
            this.gridColumn27.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceHeader.Options.UseFont = true;
            this.gridColumn27.Caption = "LV Position Description";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 1;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn28.AppearanceCell.Options.UseFont = true;
            this.gridColumn28.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn28.AppearanceHeader.Options.UseFont = true;
            this.gridColumn28.Caption = "Quantity";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 2;
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn29.AppearanceCell.Options.UseFont = true;
            this.gridColumn29.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn29.AppearanceHeader.Options.UseFont = true;
            this.gridColumn29.Caption = "Type of LV";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 3;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.emptySpaceItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(574, 590);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.comboBoxEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(554, 24);
            this.layoutControlItem1.Text = "LV Section :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(242, 15);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.comboBoxEdit2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(444, 26);
            this.layoutControlItem2.Text = "List of WG/WA :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(242, 15);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gcLVDetails;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(554, 248);
            this.layoutControlItem7.Text = "layoutControlItem1";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.checkedListBoxControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 330);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(554, 203);
            this.layoutControlItem3.Text = "Available Supplier for the selected Articles :";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(242, 15);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton3;
            this.layoutControlItem4.Location = new System.Drawing.Point(444, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(110, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 312);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(554, 18);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(554, 14);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButton2;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 533);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(174, 37);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton1;
            this.layoutControlItem5.Location = new System.Drawing.Point(341, 533);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(213, 37);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(213, 37);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(213, 37);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(174, 533);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(167, 37);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmSupplierProposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 590);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmSupplierProposal";
            this.Text = " Supplier Proposal";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLVDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLVDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl gcLVDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLVDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
    }
}