namespace OTTOProAddin
{
    partial class frmCustomerMaster
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbContactEmail = new System.Windows.Forms.RadioButton();
            this.rbContactPerson = new System.Windows.Forms.RadioButton();
            this.rbAddress = new System.Windows.Forms.RadioButton();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.rbShortName = new System.Windows.Forms.RadioButton();
            this.rbFullName = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 363);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbCustomerName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 56);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Name :";
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(133, 20);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(397, 23);
            this.cmbCustomerName.TabIndex = 0;
            this.cmbCustomerName.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerName_SelectedIndexChanged);
            this.cmbCustomerName.SelectionChangeCommitted += new System.EventHandler(this.cmbCustomerName_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbContactEmail);
            this.groupBox1.Controls.Add(this.rbContactPerson);
            this.groupBox1.Controls.Add(this.rbAddress);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.rbShortName);
            this.groupBox1.Controls.Add(this.rbFullName);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 257);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbContactEmail
            // 
            this.rbContactEmail.AutoSize = true;
            this.rbContactEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContactEmail.ForeColor = System.Drawing.Color.White;
            this.rbContactEmail.Location = new System.Drawing.Point(12, 171);
            this.rbContactEmail.Name = "rbContactEmail";
            this.rbContactEmail.Size = new System.Drawing.Size(167, 19);
            this.rbContactEmail.TabIndex = 14;
            this.rbContactEmail.TabStop = true;
            this.rbContactEmail.Text = "Primary Contact Email";
            this.rbContactEmail.UseVisualStyleBackColor = true;
            this.rbContactEmail.CheckedChanged += new System.EventHandler(this.rbContactEmail_CheckedChanged);
            // 
            // rbContactPerson
            // 
            this.rbContactPerson.AutoSize = true;
            this.rbContactPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContactPerson.ForeColor = System.Drawing.Color.White;
            this.rbContactPerson.Location = new System.Drawing.Point(12, 129);
            this.rbContactPerson.Name = "rbContactPerson";
            this.rbContactPerson.Size = new System.Drawing.Size(175, 19);
            this.rbContactPerson.TabIndex = 13;
            this.rbContactPerson.TabStop = true;
            this.rbContactPerson.Text = "Primary Contact Person";
            this.rbContactPerson.UseVisualStyleBackColor = true;
            this.rbContactPerson.CheckedChanged += new System.EventHandler(this.rbContactPerson_CheckedChanged);
            // 
            // rbAddress
            // 
            this.rbAddress.AutoSize = true;
            this.rbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAddress.ForeColor = System.Drawing.Color.White;
            this.rbAddress.Location = new System.Drawing.Point(12, 87);
            this.rbAddress.Name = "rbAddress";
            this.rbAddress.Size = new System.Drawing.Size(76, 19);
            this.rbAddress.TabIndex = 11;
            this.rbAddress.TabStop = true;
            this.rbAddress.Text = "Address";
            this.rbAddress.UseVisualStyleBackColor = true;
            this.rbAddress.CheckedChanged += new System.EventHandler(this.rbAddress_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(201, 14);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(329, 215);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.Text = "";
            // 
            // rbShortName
            // 
            this.rbShortName.AutoSize = true;
            this.rbShortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShortName.ForeColor = System.Drawing.Color.White;
            this.rbShortName.Location = new System.Drawing.Point(12, 48);
            this.rbShortName.Name = "rbShortName";
            this.rbShortName.Size = new System.Drawing.Size(101, 19);
            this.rbShortName.TabIndex = 9;
            this.rbShortName.TabStop = true;
            this.rbShortName.Text = "Short Name";
            this.rbShortName.UseVisualStyleBackColor = true;
            this.rbShortName.CheckedChanged += new System.EventHandler(this.rbShortName_CheckedChanged);
            // 
            // rbFullName
            // 
            this.rbFullName.AutoSize = true;
            this.rbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFullName.ForeColor = System.Drawing.Color.White;
            this.rbFullName.Location = new System.Drawing.Point(12, 12);
            this.rbFullName.Name = "rbFullName";
            this.rbFullName.Size = new System.Drawing.Size(91, 19);
            this.rbFullName.TabIndex = 8;
            this.rbFullName.TabStop = true;
            this.rbFullName.Text = "Full Name";
            this.rbFullName.UseVisualStyleBackColor = true;
            this.rbFullName.CheckedChanged += new System.EventHandler(this.rbFullName_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(475, 327);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 29);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmCustomerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 363);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerMaster";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Master";
            this.Load += new System.EventHandler(this.frmCustomerMaster_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbContactEmail;
        private System.Windows.Forms.RadioButton rbContactPerson;
        private System.Windows.Forms.RadioButton rbAddress;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.RadioButton rbShortName;
        private System.Windows.Forms.RadioButton rbFullName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomerName;
    }
}