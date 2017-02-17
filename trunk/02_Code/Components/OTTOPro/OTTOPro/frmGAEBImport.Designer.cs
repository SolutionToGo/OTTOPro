namespace OTTOPro
{
    partial class frmGAEBImport
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
            this.cmbLVSection = new System.Windows.Forms.ComboBox();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.txtImportFilePath = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImportFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmbLVSection);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnBrowse);
            this.layoutControl1.Controls.Add(this.txtImportFilePath);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(823, 188, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(368, 74);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbLVSection
            // 
            this.cmbLVSection.Enabled = false;
            this.cmbLVSection.FormattingEnabled = true;
            this.cmbLVSection.Location = new System.Drawing.Point(105, 38);
            this.cmbLVSection.Name = "cmbLVSection";
            this.cmbLVSection.Size = new System.Drawing.Size(112, 21);
            this.cmbLVSection.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::OTTOPro.Properties.Resources.Apply_16x16;
            this.btnOk.Location = new System.Drawing.Point(221, 38);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 24);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Import";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::OTTOPro.Properties.Resources.Cancel_16x16;
            this.btnCancel.Location = new System.Drawing.Point(285, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 24);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(285, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(71, 22);
            this.btnBrowse.StyleController = this.layoutControl1;
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Durchsuchen";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtImportFilePath
            // 
            this.txtImportFilePath.Location = new System.Drawing.Point(105, 12);
            this.txtImportFilePath.Name = "txtImportFilePath";
            this.txtImportFilePath.Properties.ReadOnly = true;
            this.txtImportFilePath.Size = new System.Drawing.Size(176, 20);
            this.txtImportFilePath.StyleController = this.layoutControl1;
            this.txtImportFilePath.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(368, 74);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtImportFilePath;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(273, 26);
            this.layoutControlItem1.Text = "Import-Dateipfad :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnBrowse;
            this.layoutControlItem3.Location = new System.Drawing.Point(273, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(75, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(75, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(75, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(273, 26);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(75, 28);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(75, 28);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(75, 28);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnOk;
            this.layoutControlItem4.Location = new System.Drawing.Point(209, 26);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(64, 28);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(64, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(64, 28);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbLVSection;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(209, 28);
            this.layoutControlItem2.Text = "LV Section :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(90, 13);
            // 
            // frmGAEBImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 74);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGAEBImport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAEB Import";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGAEBImport_FormClosing);
            this.Load += new System.EventHandler(this.frmGAEBImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtImportFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.TextEdit txtImportFilePath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.ComboBox cmbLVSection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}