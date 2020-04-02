namespace OTTOProAddin
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabOTTOPro = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnOTTOMaster = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.btnCustomer = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btnProjectNumber = this.Factory.CreateRibbonButton();
            this.btnCommissionNr = this.Factory.CreateRibbonButton();
            this.btnProjectDesc = this.Factory.CreateRibbonButton();
            this.btnPlanner = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.btnCustomerName = this.Factory.CreateRibbonButton();
            this.btnCustaddress = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.btnSupplierName = this.Factory.CreateRibbonButton();
            this.btnSupplierAddress = this.Factory.CreateRibbonButton();
            this.btnDeliveryDeadLine = this.Factory.CreateRibbonButton();
            this.tabOTTOPro.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOTTOPro
            // 
            this.tabOTTOPro.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabOTTOPro.Groups.Add(this.group1);
            this.tabOTTOPro.Groups.Add(this.group2);
            this.tabOTTOPro.Groups.Add(this.group3);
            this.tabOTTOPro.Groups.Add(this.group4);
            this.tabOTTOPro.Label = "OTTOPro";
            this.tabOTTOPro.Name = "tabOTTOPro";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnOTTOMaster);
            this.group1.Items.Add(this.button1);
            this.group1.Items.Add(this.btnCustomer);
            this.group1.Label = "Templates";
            this.group1.Name = "group1";
            // 
            // btnOTTOMaster
            // 
            this.btnOTTOMaster.Label = "OTTOMaster";
            this.btnOTTOMaster.Name = "btnOTTOMaster";
            this.btnOTTOMaster.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOTTOMaster_Click);
            // 
            // button1
            // 
            this.button1.Label = "Text Modules";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Label = "Kunde ";
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCustomer_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnProjectNumber);
            this.group2.Items.Add(this.btnCommissionNr);
            this.group2.Items.Add(this.btnProjectDesc);
            this.group2.Items.Add(this.btnPlanner);
            this.group2.Label = "Project";
            this.group2.Name = "group2";
            // 
            // btnProjectNumber
            // 
            this.btnProjectNumber.Label = "Project Nr";
            this.btnProjectNumber.Name = "btnProjectNumber";
            this.btnProjectNumber.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnProjectNumber_Click);
            // 
            // btnCommissionNr
            // 
            this.btnCommissionNr.Label = "Kommission Nr ";
            this.btnCommissionNr.Name = "btnCommissionNr";
            this.btnCommissionNr.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCommissionNr_Click);
            // 
            // btnProjectDesc
            // 
            this.btnProjectDesc.Label = "Bauvorhaben ";
            this.btnProjectDesc.Name = "btnProjectDesc";
            this.btnProjectDesc.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnProjectDesc_Click);
            // 
            // btnPlanner
            // 
            this.btnPlanner.Label = "Planner";
            this.btnPlanner.Name = "btnPlanner";
            this.btnPlanner.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPlanner_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnCustomerName);
            this.group3.Items.Add(this.btnCustaddress);
            this.group3.Label = "Kunde";
            this.group3.Name = "group3";
            // 
            // btnCustomerName
            // 
            this.btnCustomerName.Label = "Kunde Name";
            this.btnCustomerName.Name = "btnCustomerName";
            this.btnCustomerName.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCustomerName_Click);
            // 
            // btnCustaddress
            // 
            this.btnCustaddress.Label = "Kunde Address";
            this.btnCustaddress.Name = "btnCustaddress";
            this.btnCustaddress.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCustaddress_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.btnSupplierName);
            this.group4.Items.Add(this.btnSupplierAddress);
            this.group4.Items.Add(this.btnDeliveryDeadLine);
            this.group4.Label = "Preisanfrage";
            this.group4.Name = "group4";
            // 
            // btnSupplierName
            // 
            this.btnSupplierName.Label = "Lieferant Name";
            this.btnSupplierName.Name = "btnSupplierName";
            this.btnSupplierName.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSupplierName_Click);
            // 
            // btnSupplierAddress
            // 
            this.btnSupplierAddress.Label = "Lieferant Address";
            this.btnSupplierAddress.Name = "btnSupplierAddress";
            this.btnSupplierAddress.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSupplierAddress_Click);
            // 
            // btnDeliveryDeadLine
            // 
            this.btnDeliveryDeadLine.Label = "Delivery Deadline";
            this.btnDeliveryDeadLine.Name = "btnDeliveryDeadLine";
            this.btnDeliveryDeadLine.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDeliveryDeadLine_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabOTTOPro);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tabOTTOPro.ResumeLayout(false);
            this.tabOTTOPro.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabOTTOPro;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOTTOMaster;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCustomer;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCustomerName;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCustaddress;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnProjectNumber;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCommissionNr;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnProjectDesc;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPlanner;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSupplierName;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSupplierAddress;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDeliveryDeadLine;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
