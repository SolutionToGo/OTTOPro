namespace OTTOPro
{
    partial class frmLoadProject
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadProject));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcProjectSearch = new DevExpress.XtraGrid.GridControl();
            this.dgProjectSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProjectNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ComissionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PlannerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProjectDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Created_By = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Created_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProjectSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectSearch)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcProjectSearch);
            this.layoutControl1.Controls.Add(this.tableLayoutPanel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(759, 208, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1050, 547);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcProjectSearch
            // 
            this.gcProjectSearch.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Gray;
            this.gcProjectSearch.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            gridLevelNode1.RelationName = "Level1";
            this.gcProjectSearch.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcProjectSearch.Location = new System.Drawing.Point(163, 64);
            this.gcProjectSearch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.gcProjectSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcProjectSearch.MainView = this.dgProjectSearch;
            this.gcProjectSearch.Name = "gcProjectSearch";
            this.gcProjectSearch.Size = new System.Drawing.Size(708, 328);
            this.gcProjectSearch.TabIndex = 7;
            this.gcProjectSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgProjectSearch});
            // 
            // dgProjectSearch
            // 
            this.dgProjectSearch.Appearance.FocusedCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgProjectSearch.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgProjectSearch.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgProjectSearch.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgProjectSearch.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgProjectSearch.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.dgProjectSearch.Appearance.Row.BackColor = System.Drawing.Color.Gray;
            this.dgProjectSearch.Appearance.Row.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProjectSearch.Appearance.Row.ForeColor = System.Drawing.Color.White;
            this.dgProjectSearch.Appearance.Row.Options.UseBackColor = true;
            this.dgProjectSearch.Appearance.Row.Options.UseFont = true;
            this.dgProjectSearch.Appearance.Row.Options.UseForeColor = true;
            this.dgProjectSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProjectID,
            this.ProjectNumber,
            this.ComissionNumber,
            this.CustomerName,
            this.PlannerName,
            this.ProjectDescription,
            this.Created_By,
            this.Created_Date});
            this.dgProjectSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dgProjectSearch.GridControl = this.gcProjectSearch;
            this.dgProjectSearch.Name = "dgProjectSearch";
            this.dgProjectSearch.OptionsBehavior.ReadOnly = true;
            this.dgProjectSearch.OptionsCustomization.AllowColumnMoving = false;
            this.dgProjectSearch.OptionsCustomization.AllowFilter = false;
            this.dgProjectSearch.OptionsCustomization.AllowSort = false;
            this.dgProjectSearch.OptionsFind.AlwaysVisible = true;
            this.dgProjectSearch.OptionsFind.FindNullPrompt = "Suchtext eingeben...";
            this.dgProjectSearch.OptionsFind.ShowFindButton = false;
            this.dgProjectSearch.OptionsView.ShowFooter = true;
            this.dgProjectSearch.OptionsView.ShowGroupPanel = false;
            // 
            // ProjectID
            // 
            this.ProjectID.Caption = "ProjectID";
            this.ProjectID.FieldName = "ProjectID";
            this.ProjectID.Name = "ProjectID";
            // 
            // ProjectNumber
            // 
            this.ProjectNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNumber.AppearanceHeader.Options.UseFont = true;
            this.ProjectNumber.Caption = "Projekt Nummer";
            this.ProjectNumber.FieldName = "ProjectNumber";
            this.ProjectNumber.Name = "ProjectNumber";
            this.ProjectNumber.Visible = true;
            this.ProjectNumber.VisibleIndex = 0;
            // 
            // ComissionNumber
            // 
            this.ComissionNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComissionNumber.AppearanceHeader.Options.UseFont = true;
            this.ComissionNumber.Caption = "Kommission Nummer";
            this.ComissionNumber.FieldName = "ComissionNumber";
            this.ComissionNumber.Name = "ComissionNumber";
            this.ComissionNumber.Visible = true;
            this.ComissionNumber.VisibleIndex = 1;
            // 
            // CustomerName
            // 
            this.CustomerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerName.AppearanceHeader.Options.UseFont = true;
            this.CustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.CustomerName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CustomerName.Caption = "Kunde Name";
            this.CustomerName.FieldName = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 2;
            // 
            // PlannerName
            // 
            this.PlannerName.Caption = "Planner Name";
            this.PlannerName.FieldName = "PlannerName";
            this.PlannerName.Name = "PlannerName";
            // 
            // ProjectDescription
            // 
            this.ProjectDescription.Caption = "Project Description";
            this.ProjectDescription.FieldName = "ProjectDescription";
            this.ProjectDescription.Name = "ProjectDescription";
            // 
            // Created_By
            // 
            this.Created_By.Caption = "Created_By";
            this.Created_By.FieldName = "Created_By";
            this.Created_By.Name = "Created_By";
            // 
            // Created_Date
            // 
            this.Created_Date.Caption = "Created Date";
            this.Created_Date.FieldName = "Created_Date";
            this.Created_Date.Name = "Created_Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoad, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(163, 396);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 44);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCopy.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Appearance.Options.UseBackColor = true;
            this.btnCopy.Appearance.Options.UseFont = true;
            this.btnCopy.Appearance.Options.UseForeColor = true;
            this.btnCopy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnCopy.Location = new System.Drawing.Point(293, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(122, 39);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "COPY PROJECT";
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Appearance.Options.UseBackColor = true;
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.Appearance.Options.UseForeColor = true;
            this.btnLoad.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnLoad.Location = new System.Drawing.Point(165, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(122, 39);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "PROJEKT LADEN";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnImport
            // 
            this.btnImport.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnImport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnImport.Appearance.Options.UseBackColor = true;
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Appearance.Options.UseForeColor = true;
            this.btnImport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnImport.Location = new System.Drawing.Point(421, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(122, 39);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import GAEB";
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControlGroup1.AppearanceGroup.Options.UseBackColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1050, 547);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcProjectSearch;
            this.layoutControlItem2.Location = new System.Drawing.Point(151, 52);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(712, 332);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tableLayoutPanel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(151, 384);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(712, 48);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(151, 432);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(712, 43);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(863, 52);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(167, 423);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(151, 423);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(1030, 52);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 475);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(1030, 52);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmLoadProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 547);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoadProject";
            this.Text = "Projekt laden";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProjectSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectSearch)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gcProjectSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView dgProjectSearch;
        private DevExpress.XtraGrid.Columns.GridColumn ProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn ProjectNumber;
        private DevExpress.XtraGrid.Columns.GridColumn ComissionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn PlannerName;
        private DevExpress.XtraGrid.Columns.GridColumn ProjectDescription;
        private DevExpress.XtraGrid.Columns.GridColumn Created_By;
        private DevExpress.XtraGrid.Columns.GridColumn Created_Date;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.SimpleButton btnImport;



    }
}