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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierProposal));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWGWA = new System.Windows.Forms.ComboBox();
            this.cmbLVSection = new System.Windows.Forms.ComboBox();
            this.btnGeneratePDF = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendEmail = new DevExpress.XtraEditors.SimpleButton();
            this.chkSupplierLists = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gcLVDetails = new DevExpress.XtraGrid.GridControl();
            this.gvLVDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiRich = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiText = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSupplierLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLVDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLVDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiRich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Controls.Add(this.cmbWGWA);
            this.layoutControl1.Controls.Add(this.cmbLVSection);
            this.layoutControl1.Controls.Add(this.btnGeneratePDF);
            this.layoutControl1.Controls.Add(this.btnSendEmail);
            this.layoutControl1.Controls.Add(this.chkSupplierLists);
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "(can select only 8 Suppliers)";
            // 
            // cmbWGWA
            // 
            this.cmbWGWA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWGWA.FormattingEnabled = true;
            this.cmbWGWA.Location = new System.Drawing.Point(257, 37);
            this.cmbWGWA.Name = "cmbWGWA";
            this.cmbWGWA.Size = new System.Drawing.Size(200, 21);
            this.cmbWGWA.TabIndex = 17;
            this.cmbWGWA.SelectionChangeCommitted += new System.EventHandler(this.cmbWGWA_SelectionChangeCommitted);
            // 
            // cmbLVSection
            // 
            this.cmbLVSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLVSection.FormattingEnabled = true;
            this.cmbLVSection.Items.AddRange(new object[] {
            ""});
            this.cmbLVSection.Location = new System.Drawing.Point(257, 12);
            this.cmbLVSection.Name = "cmbLVSection";
            this.cmbLVSection.Size = new System.Drawing.Size(200, 21);
            this.cmbLVSection.TabIndex = 16;
            this.cmbLVSection.SelectionChangeCommitted += new System.EventHandler(this.cmbLVSection_SelectionChangeCommitted);
            // 
            // btnGeneratePDF
            // 
            this.btnGeneratePDF.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePDF.Appearance.Options.UseFont = true;
            this.btnGeneratePDF.Image = ((System.Drawing.Image)(resources.GetObject("btnGeneratePDF.Image")));
            this.btnGeneratePDF.Location = new System.Drawing.Point(12, 545);
            this.btnGeneratePDF.Name = "btnGeneratePDF";
            this.btnGeneratePDF.Size = new System.Drawing.Size(192, 33);
            this.btnGeneratePDF.StyleController = this.layoutControl1;
            this.btnGeneratePDF.TabIndex = 9;
            this.btnGeneratePDF.Text = "Generate\r\n Supplier Proposal PDF\r\n";
            this.btnGeneratePDF.Click += new System.EventHandler(this.btnGeneratePDF_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Appearance.Options.UseFont = true;
            this.btnSendEmail.Image = global::OTTOPro.Properties.Resources.Mail_32x32;
            this.btnSendEmail.Location = new System.Drawing.Point(353, 545);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(209, 33);
            this.btnSendEmail.StyleController = this.layoutControl1;
            this.btnSendEmail.TabIndex = 8;
            this.btnSendEmail.Text = "Send\r\nSupplier Proposal Email";
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // chkSupplierLists
            // 
            this.chkSupplierLists.CheckOnClick = true;
            this.chkSupplierLists.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSupplierLists.Location = new System.Drawing.Point(12, 349);
            this.chkSupplierLists.MultiColumn = true;
            this.chkSupplierLists.Name = "chkSupplierLists";
            this.chkSupplierLists.Size = new System.Drawing.Size(550, 168);
            this.chkSupplierLists.StyleController = this.layoutControl1;
            this.chkSupplierLists.TabIndex = 6;
            this.chkSupplierLists.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkSupplierLists_ItemCheck);
            // 
            // gcLVDetails
            // 
            this.gcLVDetails.Location = new System.Drawing.Point(12, 84);
            this.gcLVDetails.MainView = this.gvLVDetails;
            this.gcLVDetails.Name = "gcLVDetails";
            this.gcLVDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpiText,
            this.rpiRich});
            this.gcLVDetails.Size = new System.Drawing.Size(550, 233);
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
            this.gridColumn1,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn2});
            this.gvLVDetails.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLVDetails.GridControl = this.gcLVDetails;
            this.gvLVDetails.Name = "gvLVDetails";
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
            this.gvLVDetails.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvLVDetails_PopupMenuShowing);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "PositionID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceCell.Options.UseFont = true;
            this.gridColumn26.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn26.AppearanceHeader.Options.UseFont = true;
            this.gridColumn26.Caption = "Position_OZ";
            this.gridColumn26.FieldName = "Position_OZ";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.ReadOnly = true;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 0;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceCell.Options.UseFont = true;
            this.gridColumn27.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn27.AppearanceHeader.Options.UseFont = true;
            this.gridColumn27.Caption = "Description";
            this.gridColumn27.ColumnEdit = this.rpiRich;
            this.gridColumn27.FieldName = "ShortDescription";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 1;
            // 
            // rpiRich
            // 
            this.rpiRich.Name = "rpiRich";
            this.rpiRich.ShowCaretInReadOnly = false;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn28.AppearanceCell.Options.UseFont = true;
            this.gridColumn28.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn28.AppearanceHeader.Options.UseFont = true;
            this.gridColumn28.Caption = "Quantity";
            this.gridColumn28.FieldName = "Menge";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.ReadOnly = true;
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
            this.gridColumn29.FieldName = "PositionKZ";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.ReadOnly = true;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "SeqNo";
            this.gridColumn2.FieldName = "sequenceNo";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // rpiText
            // 
            this.rpiText.AutoHeight = false;
            this.rpiText.Name = "rpiText";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControlGroup1.AppearanceGroup.Options.UseBackColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.emptySpaceItem3,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.emptySpaceItem6,
            this.layoutControlItem8,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem4,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(574, 590);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gcLVDetails;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(554, 237);
            this.layoutControlItem7.Text = "layoutControlItem1";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.chkSupplierLists;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 319);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(554, 190);
            this.layoutControlItem3.Text = "Available Supplier for the selected Articles :";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(242, 15);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 309);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(554, 10);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnGeneratePDF;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 533);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(196, 37);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(196, 37);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(196, 37);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnSendEmail;
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
            this.emptySpaceItem6.Location = new System.Drawing.Point(196, 533);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(145, 37);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem8.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem8.Control = this.cmbLVSection;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(449, 25);
            this.layoutControlItem8.Text = "LV Section :";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(242, 15);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.cmbWGWA;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(449, 25);
            this.layoutControlItem1.Text = "List of WG/WA :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(242, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(449, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(105, 50);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(554, 22);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.label1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 509);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(554, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            // 
            // frmSupplierProposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 590);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplierProposal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Supplier Proposal";
            this.Load += new System.EventHandler(this.frmSupplierProposal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSupplierLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLVDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLVDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiRich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkSupplierLists;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnGeneratePDF;
        private DevExpress.XtraEditors.SimpleButton btnSendEmail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl gcLVDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLVDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private System.Windows.Forms.ComboBox cmbWGWA;
        private System.Windows.Forms.ComboBox cmbLVSection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpiText;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit rpiRich;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}