﻿namespace OTTOPro
{
    partial class frmAddType
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
            this.gcAddTyp = new DevExpress.XtraGrid.GridControl();
            this.gvAddTyp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAddTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAddTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControl1.Controls.Add(this.gcAddTyp);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(567, 13, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(512, 307);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcAddTyp
            // 
            this.gcAddTyp.Location = new System.Drawing.Point(3, 3);
            this.gcAddTyp.MainView = this.gvAddTyp;
            this.gcAddTyp.Name = "gcAddTyp";
            this.gcAddTyp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gcAddTyp.Size = new System.Drawing.Size(506, 301);
            this.gcAddTyp.TabIndex = 4;
            this.gcAddTyp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAddTyp});
            // 
            // gvAddTyp
            // 
            this.gvAddTyp.Appearance.Empty.BackColor = System.Drawing.Color.Silver;
            this.gvAddTyp.Appearance.Empty.Options.UseBackColor = true;
            this.gvAddTyp.Appearance.FocusedCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvAddTyp.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvAddTyp.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvAddTyp.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvAddTyp.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.gvAddTyp.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvAddTyp.Appearance.Row.BackColor = System.Drawing.Color.Silver;
            this.gvAddTyp.Appearance.Row.Options.UseBackColor = true;
            this.gvAddTyp.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvAddTyp.GridControl = this.gcAddTyp;
            this.gvAddTyp.Name = "gvAddTyp";
            this.gvAddTyp.OptionsBehavior.Editable = false;
            this.gvAddTyp.OptionsBehavior.ReadOnly = true;
            this.gvAddTyp.OptionsCustomization.AllowColumnMoving = false;
            this.gvAddTyp.OptionsCustomization.AllowFilter = false;
            this.gvAddTyp.OptionsCustomization.AllowSort = false;
            this.gvAddTyp.OptionsFilter.AllowFilterEditor = false;
            this.gvAddTyp.OptionsFind.ShowFindButton = false;
            this.gvAddTyp.OptionsMenu.EnableColumnMenu = false;
            this.gvAddTyp.OptionsMenu.EnableFooterMenu = false;
            this.gvAddTyp.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvAddTyp.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvAddTyp.OptionsView.RowAutoHeight = true;
            this.gvAddTyp.OptionsView.ShowGroupPanel = false;
            this.gvAddTyp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvAddTyp_KeyPress);
            this.gvAddTyp.DoubleClick += new System.EventHandler(this.gvAddTyp_DoubleClick);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "y";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "y";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "y";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(512, 307);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcAddTyp;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(510, 305);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmAddType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 307);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Type";
            this.Load += new System.EventHandler(this.frmAddType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAddTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAddTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcAddTyp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAddTyp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}