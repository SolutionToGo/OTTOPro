namespace OTTOProAddin
{
    partial class frmInvoice
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
            this.btnOk = new System.Windows.Forms.Button();
            this.gvInvoice = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(608, 242);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 36);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gvInvoice
            // 
            this.gvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvInvoice.Location = new System.Drawing.Point(0, 0);
            this.gvInvoice.Name = "gvInvoice";
            this.gvInvoice.RowHeadersVisible = false;
            this.gvInvoice.Size = new System.Drawing.Size(718, 236);
            this.gvInvoice.TabIndex = 5;
            this.gvInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInvoice_CellContentClick);
            this.gvInvoice.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInvoice_CellContentDoubleClick);
            this.gvInvoice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInvoice_CellDoubleClick);
            this.gvInvoice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvInvoice_CellFormatting);
            this.gvInvoice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gvInvoice_MouseClick);
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(718, 283);
            this.Controls.Add(this.gvInvoice);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechnungsraster";
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView gvInvoice;
    }
}