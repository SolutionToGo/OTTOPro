﻿namespace OTTOPro
{
    partial class frmQuerKalculation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbLVSection = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gvAddRemovePositions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioGroupSelection = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmbLVSectionFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLVSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAddRemovePositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSelection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLVSectionFilter)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControl1.Controls.Add(this.cmbLVSection);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.gvAddRemovePositions);
            this.layoutControl1.Controls.Add(this.radioGroupSelection);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(578, 168, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(328, 349);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbLVSection
            // 
            this.cmbLVSection.Enabled = false;
            this.cmbLVSection.Location = new System.Drawing.Point(61, 83);
            this.cmbLVSection.Name = "cmbLVSection";
            this.cmbLVSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLVSection.Size = new System.Drawing.Size(255, 20);
            this.cmbLVSection.StyleController = this.layoutControl1;
            this.cmbLVSection.TabIndex = 54;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::OTTOPro.Properties.Resources.Apply_16x16;
            this.simpleButton1.Location = new System.Drawing.Point(235, 315);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(81, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 53;
            this.simpleButton1.Text = "Anwenden";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gvAddRemovePositions
            // 
            this.gvAddRemovePositions.AllowUserToAddRows = false;
            this.gvAddRemovePositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAddRemovePositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAddRemovePositions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gvAddRemovePositions.Enabled = false;
            this.gvAddRemovePositions.Location = new System.Drawing.Point(12, 107);
            this.gvAddRemovePositions.Name = "gvAddRemovePositions";
            this.gvAddRemovePositions.Size = new System.Drawing.Size(304, 204);
            this.gvAddRemovePositions.TabIndex = 51;
            this.gvAddRemovePositions.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvAddRemovePositions_EditingControlShowing);
            this.gvAddRemovePositions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvAddRemovePositions_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "Von";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Bis";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // radioGroupSelection
            // 
            this.radioGroupSelection.Location = new System.Drawing.Point(12, 12);
            this.radioGroupSelection.Name = "radioGroupSelection";
            this.radioGroupSelection.Properties.AllowMouseWheel = false;
            this.radioGroupSelection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Alle LV Positionen"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Titel und Untertitel"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "LV Sektions")});
            this.radioGroupSelection.Size = new System.Drawing.Size(304, 67);
            this.radioGroupSelection.StyleController = this.layoutControl1;
            this.radioGroupSelection.TabIndex = 4;
            this.radioGroupSelection.SelectedIndexChanged += new System.EventHandler(this.radioGroupSelection_SelectedIndexChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.cmbLVSectionFilter});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(328, 349);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.radioGroupSelection;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(308, 71);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gvAddRemovePositions;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 95);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(308, 208);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 303);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(223, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton1;
            this.layoutControlItem4.Location = new System.Drawing.Point(223, 303);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(85, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // cmbLVSectionFilter
            // 
            this.cmbLVSectionFilter.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.cmbLVSectionFilter.AppearanceItemCaption.Options.UseForeColor = true;
            this.cmbLVSectionFilter.Control = this.cmbLVSection;
            this.cmbLVSectionFilter.Location = new System.Drawing.Point(0, 71);
            this.cmbLVSectionFilter.Name = "cmbLVSectionFilter";
            this.cmbLVSectionFilter.Size = new System.Drawing.Size(308, 24);
            this.cmbLVSectionFilter.Text = "LVSection";
            this.cmbLVSectionFilter.TextSize = new System.Drawing.Size(46, 13);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAdd,
            this.ToolStripMenuItemRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 48);
            // 
            // ToolStripMenuItemAdd
            // 
            this.ToolStripMenuItemAdd.Image = global::OTTOPro.Properties.Resources.Add_16x16;
            this.ToolStripMenuItemAdd.Name = "ToolStripMenuItemAdd";
            this.ToolStripMenuItemAdd.Size = new System.Drawing.Size(134, 22);
            this.ToolStripMenuItemAdd.Text = "hinzufügen";
            this.ToolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
            // 
            // ToolStripMenuItemRemove
            // 
            this.ToolStripMenuItemRemove.Image = global::OTTOPro.Properties.Resources.Cancel_16x16;
            this.ToolStripMenuItemRemove.Name = "ToolStripMenuItemRemove";
            this.ToolStripMenuItemRemove.Size = new System.Drawing.Size(134, 22);
            this.ToolStripMenuItemRemove.Text = "Entfernen";
            this.ToolStripMenuItemRemove.Click += new System.EventHandler(this.ToolStripMenuItemRemove_Click);
            // 
            // frmQuerKalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 349);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuerKalculation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auswahl Querkalkulation";
            this.Load += new System.EventHandler(this.frmQuerKalculation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLVSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAddRemovePositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSelection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLVSectionFilter)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.RadioGroup radioGroupSelection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.DataGridView gvAddRemovePositions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRemove;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cmbLVSection;
        private DevExpress.XtraLayout.LayoutControlItem cmbLVSectionFilter;
    }
}