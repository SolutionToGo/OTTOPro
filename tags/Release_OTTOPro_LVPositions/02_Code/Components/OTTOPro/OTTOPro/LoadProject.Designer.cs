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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadProject));
            this.tplLoadProject = new System.Windows.Forms.TableLayoutPanel();
            this.gcSearch = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProjectNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblKundeName = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectNr = new DevExpress.XtraEditors.TextEdit();
            this.txtKundeName = new DevExpress.XtraEditors.TextEdit();
            this.dgProjectSearch = new System.Windows.Forms.DataGridView();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComissionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlannerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tplLoadProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).BeginInit();
            this.gcSearch.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKundeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // tplLoadProject
            // 
            this.tplLoadProject.BackColor = System.Drawing.Color.Transparent;
            this.tplLoadProject.ColumnCount = 2;
            this.tplLoadProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplLoadProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplLoadProject.Controls.Add(this.gcSearch, 0, 0);
            this.tplLoadProject.Controls.Add(this.dgProjectSearch, 1, 0);
            this.tplLoadProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplLoadProject.Location = new System.Drawing.Point(0, 0);
            this.tplLoadProject.Name = "tplLoadProject";
            this.tplLoadProject.RowCount = 1;
            this.tplLoadProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplLoadProject.Size = new System.Drawing.Size(1050, 490);
            this.tplLoadProject.TabIndex = 0;
            // 
            // gcSearch
            // 
            this.gcSearch.Appearance.BackColor = System.Drawing.Color.Gray;
            this.gcSearch.Appearance.Options.UseBackColor = true;
            this.gcSearch.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gcSearch.AppearanceCaption.Options.UseFont = true;
            this.gcSearch.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gcSearch.CaptionImageUri.Uri = "Zoom";
            this.gcSearch.Controls.Add(this.tableLayoutPanel2);
            this.gcSearch.Controls.Add(this.tableLayoutPanel1);
            this.gcSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSearch.Location = new System.Drawing.Point(3, 3);
            this.gcSearch.Name = "gcSearch";
            this.gcSearch.Size = new System.Drawing.Size(283, 484);
            this.gcSearch.TabIndex = 1;
            this.gcSearch.Text = "Search";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCopy, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLoad, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 96);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 38);
            this.tableLayoutPanel2.TabIndex = 3;
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
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopy.Location = new System.Drawing.Point(142, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(114, 35);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "COPY PROJECT";
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
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(22, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(114, 35);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "LOAD PROJECT";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblProjectNumber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKundeName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtProjectNr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKundeName, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(279, 73);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblProjectNumber
            // 
            this.lblProjectNumber.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblProjectNumber.Location = new System.Drawing.Point(3, 3);
            this.lblProjectNumber.Name = "lblProjectNumber";
            this.lblProjectNumber.Size = new System.Drawing.Size(52, 13);
            this.lblProjectNumber.TabIndex = 0;
            this.lblProjectNumber.Text = "Project Nr:";
            // 
            // lblKundeName
            // 
            this.lblKundeName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblKundeName.Location = new System.Drawing.Point(3, 29);
            this.lblKundeName.Name = "lblKundeName";
            this.lblKundeName.Size = new System.Drawing.Size(64, 13);
            this.lblKundeName.TabIndex = 0;
            this.lblKundeName.Text = "Kunde Name:";
            // 
            // txtProjectNr
            // 
            this.txtProjectNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectNr.Location = new System.Drawing.Point(73, 3);
            this.txtProjectNr.Name = "txtProjectNr";
            this.txtProjectNr.Size = new System.Drawing.Size(203, 20);
            this.txtProjectNr.TabIndex = 2;
            this.txtProjectNr.EditValueChanged += new System.EventHandler(this.txtProjectNr_EditValueChanged);
            // 
            // txtKundeName
            // 
            this.txtKundeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKundeName.Location = new System.Drawing.Point(73, 29);
            this.txtKundeName.Name = "txtKundeName";
            this.txtKundeName.Size = new System.Drawing.Size(203, 20);
            this.txtKundeName.TabIndex = 3;
            this.txtKundeName.EditValueChanged += new System.EventHandler(this.txtKundeName_EditValueChanged);
            // 
            // dgProjectSearch
            // 
            this.dgProjectSearch.AllowUserToAddRows = false;
            this.dgProjectSearch.AllowUserToDeleteRows = false;
            this.dgProjectSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProjectSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgProjectSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgProjectSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProjectSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProjectSearch.ColumnHeadersHeight = 40;
            this.dgProjectSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectID,
            this.ProjectNumber,
            this.ComissionNumber,
            this.CustomerName,
            this.PlannerName,
            this.ProjectDescription,
            this.Created_By,
            this.Created_Date});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProjectSearch.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgProjectSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProjectSearch.EnableHeadersVisualStyles = false;
            this.dgProjectSearch.Location = new System.Drawing.Point(292, 3);
            this.dgProjectSearch.Name = "dgProjectSearch";
            this.dgProjectSearch.ReadOnly = true;
            this.dgProjectSearch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProjectSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgProjectSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProjectSearch.Size = new System.Drawing.Size(755, 484);
            this.dgProjectSearch.TabIndex = 6;
            this.dgProjectSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProjectSearch_CellClick);
            // 
            // ProjectID
            // 
            this.ProjectID.DataPropertyName = "ProjectID";
            this.ProjectID.HeaderText = "ProjectID";
            this.ProjectID.Name = "ProjectID";
            this.ProjectID.ReadOnly = true;
            this.ProjectID.Visible = false;
            // 
            // ProjectNumber
            // 
            this.ProjectNumber.DataPropertyName = "ProjectNumber";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.ProjectNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProjectNumber.HeaderText = "Project Number";
            this.ProjectNumber.Name = "ProjectNumber";
            this.ProjectNumber.ReadOnly = true;
            // 
            // ComissionNumber
            // 
            this.ComissionNumber.DataPropertyName = "ComissionNumber";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.ComissionNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.ComissionNumber.HeaderText = "Comission Number";
            this.ComissionNumber.Name = "ComissionNumber";
            this.ComissionNumber.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.CustomerName.DefaultCellStyle = dataGridViewCellStyle4;
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // PlannerName
            // 
            this.PlannerName.DataPropertyName = "PlannerName";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.PlannerName.DefaultCellStyle = dataGridViewCellStyle5;
            this.PlannerName.HeaderText = "Planner Name";
            this.PlannerName.Name = "PlannerName";
            this.PlannerName.ReadOnly = true;
            // 
            // ProjectDescription
            // 
            this.ProjectDescription.DataPropertyName = "ProjectDescription";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            this.ProjectDescription.DefaultCellStyle = dataGridViewCellStyle6;
            this.ProjectDescription.HeaderText = "Project Description";
            this.ProjectDescription.Name = "ProjectDescription";
            this.ProjectDescription.ReadOnly = true;
            // 
            // Created_By
            // 
            this.Created_By.DataPropertyName = "Created_By";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            this.Created_By.DefaultCellStyle = dataGridViewCellStyle7;
            this.Created_By.HeaderText = "Created_By";
            this.Created_By.Name = "Created_By";
            this.Created_By.ReadOnly = true;
            // 
            // Created_Date
            // 
            this.Created_Date.DataPropertyName = "Created_Date";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            this.Created_Date.DefaultCellStyle = dataGridViewCellStyle8;
            this.Created_Date.HeaderText = "Created Date";
            this.Created_Date.Name = "Created_Date";
            this.Created_Date.ReadOnly = true;
            // 
            // frmLoadProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 490);
            this.Controls.Add(this.tplLoadProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoadProject";
            this.Text = "LoadProject";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadProject_Load);
            this.tplLoadProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).EndInit();
            this.gcSearch.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKundeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tplLoadProject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lblProjectNumber;
        private DevExpress.XtraEditors.LabelControl lblKundeName;
        private DevExpress.XtraEditors.TextEdit txtProjectNr;
        private DevExpress.XtraEditors.TextEdit txtKundeName;
        private DevExpress.XtraEditors.GroupControl gcSearch;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgProjectSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComissionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlannerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created_Date;


    }
}