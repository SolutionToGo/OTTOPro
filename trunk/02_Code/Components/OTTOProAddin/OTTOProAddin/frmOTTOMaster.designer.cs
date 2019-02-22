namespace OTTOProAddin
{
    partial class frmOTTOMaster
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbContactEmail = new System.Windows.Forms.RadioButton();
            this.rbContactPerson = new System.Windows.Forms.RadioButton();
            this.rbAddress = new System.Windows.Forms.RadioButton();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.rbShortName = new System.Windows.Forms.RadioButton();
            this.rbFullName = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 304);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbContactEmail);
            this.groupBox1.Controls.Add(this.rbContactPerson);
            this.groupBox1.Controls.Add(this.rbAddress);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.rbShortName);
            this.groupBox1.Controls.Add(this.rbFullName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 240);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbContactEmail
            // 
            this.rbContactEmail.AutoSize = true;
            this.rbContactEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContactEmail.ForeColor = System.Drawing.Color.White;
            this.rbContactEmail.Location = new System.Drawing.Point(18, 192);
            this.rbContactEmail.Name = "rbContactEmail";
            this.rbContactEmail.Size = new System.Drawing.Size(175, 19);
            this.rbContactEmail.TabIndex = 14;
            this.rbContactEmail.TabStop = true;
            this.rbContactEmail.Text = "Primäre Kontakt-E-Mail";
            this.rbContactEmail.UseVisualStyleBackColor = true;
            this.rbContactEmail.CheckedChanged += new System.EventHandler(this.rbContactEmail_CheckedChanged);
            // 
            // rbContactPerson
            // 
            this.rbContactPerson.AutoSize = true;
            this.rbContactPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContactPerson.ForeColor = System.Drawing.Color.White;
            this.rbContactPerson.Location = new System.Drawing.Point(18, 150);
            this.rbContactPerson.Name = "rbContactPerson";
            this.rbContactPerson.Size = new System.Drawing.Size(190, 19);
            this.rbContactPerson.TabIndex = 13;
            this.rbContactPerson.TabStop = true;
            this.rbContactPerson.Text = "Primärer Ansprechpartner";
            this.rbContactPerson.UseVisualStyleBackColor = true;
            this.rbContactPerson.CheckedChanged += new System.EventHandler(this.rbContactPerson_CheckedChanged);
            // 
            // rbAddress
            // 
            this.rbAddress.AutoSize = true;
            this.rbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAddress.ForeColor = System.Drawing.Color.White;
            this.rbAddress.Location = new System.Drawing.Point(18, 108);
            this.rbAddress.Name = "rbAddress";
            this.rbAddress.Size = new System.Drawing.Size(76, 19);
            this.rbAddress.TabIndex = 11;
            this.rbAddress.TabStop = true;
            this.rbAddress.Text = "Adresse";
            this.rbAddress.UseVisualStyleBackColor = true;
            this.rbAddress.CheckedChanged += new System.EventHandler(this.rbAddress_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(252, 17);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(316, 215);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.Text = "";
            // 
            // rbShortName
            // 
            this.rbShortName.AutoSize = true;
            this.rbShortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShortName.ForeColor = System.Drawing.Color.White;
            this.rbShortName.Location = new System.Drawing.Point(18, 69);
            this.rbShortName.Name = "rbShortName";
            this.rbShortName.Size = new System.Drawing.Size(109, 19);
            this.rbShortName.TabIndex = 9;
            this.rbShortName.TabStop = true;
            this.rbShortName.Text = "Kurzer Name";
            this.rbShortName.UseVisualStyleBackColor = true;
            this.rbShortName.CheckedChanged += new System.EventHandler(this.rbShortName_CheckedChanged);
            // 
            // rbFullName
            // 
            this.rbFullName.AutoSize = true;
            this.rbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFullName.ForeColor = System.Drawing.Color.White;
            this.rbFullName.Location = new System.Drawing.Point(18, 33);
            this.rbFullName.Name = "rbFullName";
            this.rbFullName.Size = new System.Drawing.Size(151, 19);
            this.rbFullName.TabIndex = 8;
            this.rbFullName.TabStop = true;
            this.rbFullName.Text = "Vollständiger Name";
            this.rbFullName.UseVisualStyleBackColor = true;
            this.rbFullName.CheckedChanged += new System.EventHandler(this.rbFullName_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(509, 264);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 29);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmOTTOMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 304);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOTTOMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTTO Stammdaten";
            this.Load += new System.EventHandler(this.frmOTTOMaster_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbContactEmail;
        private System.Windows.Forms.RadioButton rbAddress;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.RadioButton rbShortName;
        private System.Windows.Forms.RadioButton rbFullName;
        private System.Windows.Forms.RadioButton rbContactPerson;

    }
}