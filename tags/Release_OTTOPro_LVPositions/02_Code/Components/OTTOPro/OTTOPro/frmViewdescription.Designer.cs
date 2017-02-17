namespace OTTOPro
{
    partial class frmViewdescription
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
            this.richEditBarController1 = new DevExpress.XtraRichEdit.UI.RichEditBarController();
            this.txtLongdescription = new DevExpress.XtraRichEdit.RichEditControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richEditBarController1
            // 
            this.richEditBarController1.Control = this.txtLongdescription;
            // 
            // txtLongdescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtLongdescription, 3);
            this.txtLongdescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLongdescription.Location = new System.Drawing.Point(3, 3);
            this.txtLongdescription.Name = "txtLongdescription";
            this.txtLongdescription.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txtLongdescription.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.txtLongdescription.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txtLongdescription.Size = new System.Drawing.Size(844, 532);
            this.txtLongdescription.TabIndex = 3;
            this.txtLongdescription.TextChanged += new System.EventHandler(this.txtLongdescription_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLongdescription, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 567);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(772, 541);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(691, 541);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmViewdescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 567);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmViewdescription";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Long Description";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewdescription_FormClosing);
            this.Load += new System.EventHandler(this.frmViewdescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.UI.RichEditBarController richEditBarController1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraRichEdit.RichEditControl txtLongdescription;

    }
}