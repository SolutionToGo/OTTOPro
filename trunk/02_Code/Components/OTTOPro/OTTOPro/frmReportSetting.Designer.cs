namespace OTTOPro
{
    partial class frmReportSetting
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
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.radioGroupSorting = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.radioGroupShowText = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkSelectOptions = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSorting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupShowText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(158)))), ((int)(((byte)(224)))));
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.chkSelectOptions);
            this.layoutControl1.Controls.Add(this.radioGroupShowText);
            this.layoutControl1.Controls.Add(this.radioGroupSorting);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(720, 269, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(414, 518);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(414, 518);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // radioGroupSorting
            // 
            this.radioGroupSorting.Location = new System.Drawing.Point(12, 29);
            this.radioGroupSorting.Name = "radioGroupSorting";
            this.radioGroupSorting.Properties.AllowMouseWheel = false;
            this.radioGroupSorting.Properties.Columns = 2;
            this.radioGroupSorting.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroupSorting.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "LV Position"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ArtikelNr."),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Lieferant(MA)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Fabrikat")});
            this.radioGroupSorting.Size = new System.Drawing.Size(390, 84);
            this.radioGroupSorting.StyleController = this.layoutControl1;
            this.radioGroupSorting.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.radioGroupSorting;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(394, 105);
            this.layoutControlItem1.Text = "Sorting";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(89, 14);
            // 
            // radioGroupShowText
            // 
            this.radioGroupShowText.Location = new System.Drawing.Point(12, 134);
            this.radioGroupShowText.Name = "radioGroupShowText";
            this.radioGroupShowText.Properties.AllowMouseWheel = false;
            this.radioGroupShowText.Properties.Columns = 2;
            this.radioGroupShowText.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "LangText"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "KurzText")});
            this.radioGroupShowText.Size = new System.Drawing.Size(390, 52);
            this.radioGroupShowText.StyleController = this.layoutControl1;
            this.radioGroupShowText.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.radioGroupShowText;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 105);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(394, 73);
            this.layoutControlItem2.Text = "Show Text";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(89, 14);
            // 
            // chkSelectOptions
            // 
            this.chkSelectOptions.CheckOnClick = true;
            this.chkSelectOptions.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSelectOptions.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("sender", "Print offer without sender"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("menge", "Print positions without menge"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("GB", "Print offer without total price(GB)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("prices", "Print offer without prices"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("EP", "Print individual prices in the text(EP)")});
            this.chkSelectOptions.Location = new System.Drawing.Point(12, 207);
            this.chkSelectOptions.MultiColumn = true;
            this.chkSelectOptions.Name = "chkSelectOptions";
            this.chkSelectOptions.Size = new System.Drawing.Size(390, 273);
            this.chkSelectOptions.StyleController = this.layoutControl1;
            this.chkSelectOptions.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.chkSelectOptions;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 178);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(394, 294);
            this.layoutControlItem3.Text = "Select Options";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(89, 14);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = global::OTTOPro.Properties.Resources.Save_16x16;
            this.btnSave.Location = new System.Drawing.Point(329, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSave;
            this.layoutControlItem4.Location = new System.Drawing.Point(317, 472);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(77, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 472);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(232, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::OTTOPro.Properties.Resources.Cancel_16x16;
            this.btnCancel.Location = new System.Drawing.Point(244, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(232, 472);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(85, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmReportSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 518);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Setting";
            this.Load += new System.EventHandler(this.frmReportSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSorting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupShowText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.RadioGroup radioGroupShowText;
        private DevExpress.XtraEditors.RadioGroup radioGroupSorting;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.CheckedListBoxControl chkSelectOptions;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}