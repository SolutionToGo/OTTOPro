using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using BL;
using DevExpress.Utils;
using EL;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Columns;
using System.Drawing.Drawing2D;
using System.Collections;
using DevExpress.XtraLayout;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using OTTOPro.Report_Design;
using DevExpress.XtraBars;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Layout.Modes;
using DevExpress.XtraGrid.Views.Base;
using System.Globalization;
using DevExpress.XtraPrinting;

namespace OTTOPro
{
    public partial class frmProject : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Private variables to store the temporary data
        /// </summary>
        private List<Control> RequiredFields = new List<Control>();
        private List<Control> RequiredPositionFields = new List<Control>();
        private List<Control> RequiredPositionFieldsforTitle = new List<Control>();
        private int _ProjectID = -1;
        private bool _IsCopy = false;
        private string LongDescription = string.Empty;
        private bool _IsEditMode = false;
        public bool _IsNewMode = false;
        public int iSNO = -1;
        public bool _IsAddhoc = false;
        public int iRasterCount = 0;

        private string _DocuwareLink1;
        private string _DocuwareLink2;
        private string _DocuwareLink3;

        public EDeliveryNotes ObjEDeliveryNotes = null;
        public BDeliveryNotes ObjBDeliveryNotes = null;
        GridHitInfo downHitInfo = null;
        private int SNO = 1;
        DataRow _CopyLVDataRow = null;
        private bool _IsValueChanged = true;
        private bool _IsSave = false;
        

        /// <summary>
        /// Instances for Entity layer and business layer
        /// </summary>
        EProject ObjEProject = new EProject();
        EPosition ObjEPosition = new EPosition();
        BProject ObjBProject = new BProject();
        BPosition ObjBPosition = new BPosition();
        BGAEB objBGAEB = new BGAEB();
        EGAEB objEGAEB = new EGAEB();
        EMulti ObjEMulti = null;
        BMulti ObjBMulti = null;
        EUmlage ObjEUmlage = null;
        BUmlage ObjBUmlage = null;
        EInvoice ObjEInvoice = null;
        BInvoice oBJBInvoice = null;

        ESupplier ObjESupplier = new ESupplier();
        BSupplier ObjBSupplier = new BSupplier();
        DataTable _dtSupplier = null;
        bool _Process = false;

        private int _ProposalID = 0;
        string _LvSection;
        string _WGforSupplier = null;
        string _WAforSupplier = null;
        string _pdfpath = null;
        DataTable _dtSuppliermail = new DataTable();

        /// <summary>
        /// Properties to bind the internal variables
        /// </summary>
        public int ProjectID
        { get { return _ProjectID; } set { _ProjectID = value; } }
        public bool IsCopy
        {
            get { return _IsCopy; }
            set { _IsCopy = value; }
        }
        
        /// <summary>
        /// Defualt constructor
        /// </summary>  
        public frmProject()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event to open the project screens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navbar_Linkclicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraTabPage ObjTabDetails = null;
            if (e.Link.ItemName.ToLower() == "nvprojectdetails")
            {
                ObjTabDetails = tbProjectDetails;
            }
            else if (e.Link.ItemName.ToLower() == "nvlvdetails" && ObjEProject.ProjectID > 0)
            {
                ObjTabDetails = tbLVDetails;
                BindPositionData();
            }
            TabChange(ObjTabDetails);
        }

        /// <summary>
        /// Code to change the porjet page
        /// </summary>
        /// <param name="ObjTabDetails"></param>
        private void TabChange(XtraTabPage ObjTabDetails)
        {
            FormatLVFields();
            if (ObjTabDetails != null)
            {
                if (ObjTabDetails.PageVisible == true)
                    tcProjectDetails.SelectedTabPage = ObjTabDetails;
                else
                {
                    ObjTabDetails.PageVisible = true;
                    tcProjectDetails.SelectedTabPage = ObjTabDetails;
                }
            }
        }

        /// <summary>
        /// Code to close the selected tab page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txProjectDetails_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                switch (tcProjectDetails.SelectedTabPage.Name)
                {
                    case "tbProjectDetails":
                        DialogResult dr = XtraMessageBox.Show("Wollen Sie die Angaben speichern?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            btnProjectSave_Click(null, null);
                        }
                        if (dr == DialogResult.Cancel)
                        {
                            return;
                        }
                        break;

                    case "tbLVDetails":
                        DialogResult drLV = XtraMessageBox.Show("Wollen Sie die Angaben speichern?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (drLV == DialogResult.Yes)
                        {
                            btnSaveLVDetails_Click(null, null);
                        }
                        if (drLV == DialogResult.Cancel)
                        {
                            return;
                        }
                        break;

                    case "tbBulkProcess":
                        DialogResult drBP = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drBP == DialogResult.No)
                        {
                            return;
                        }
                        break;

                    case "tbMulti5":
                        DialogResult drM5 = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drM5 == DialogResult.No)
                        {
                            return;
                        }
                        break;

                    case "tbMulti6":
                        DialogResult drM6 = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drM6 == DialogResult.No)
                        {
                            return;
                        }

                        break;

                    case "tbOmlage":
                        DialogResult drOm = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drOm == DialogResult.No)
                        {
                            return;
                        }
                        break;

                    case "tbDeliveryNotes":
                        DialogResult drtest = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drtest == DialogResult.No)
                        {
                            return;
                        }
                        break;

                    case "tbInvoices":
                        DialogResult drIN = MessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drIN == DialogResult.No)
                        {
                            return;
                        }
                        break;

                    case "tbSupplierProposal":
                        DialogResult drSP = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drSP == DialogResult.No)
                        {
                            return;
                        }
                        break;

                    case "tbUpdateSupplier":
                        DialogResult drUS = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drUS == DialogResult.No)
                        {
                            return;
                        }
                        break;

                    case "tbCopyLVs":
                        DialogResult drCLV = XtraMessageBox.Show("Sind Sie sicher, dass Sie diese Seite schließen möchten?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (drCLV == DialogResult.No)
                        {
                            return;
                        }
                        break;
                }
                ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
                (arg.Page as XtraTabPage).PageVisible = false;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProject_Load(object sender, EventArgs e)
        {
            try
            {
                splitContainerControl1.CollapsePanel = SplitCollapsePanel.Panel1;

                tbLVDetails.PageVisible = false;
                tbBulkProcess.PageVisible = false;
                tbMulti5.PageVisible = false;
                tbMulti6.PageVisible = false;
                tbOmlage.PageVisible = false;
                tbDeliveryNotes.PageVisible = false;
                tbInvoices.PageVisible = false;
                tbSupplierProposal.PageVisible = false;
                tbUpdateSupplier.PageVisible = false;
                tbCopyLVs.PageVisible = false;
                tbAufmassReport.PageVisible = false;
                cmbPositionKZ.Text = "N";
                chkCumulated.Checked = true;

                RequiredFields.Add(txtProjectNumber);
                RequiredFields.Add(txtMWST);
                RequiredFields.Add(txtLVSprunge);
                RequiredFields.Add(txtKundeNo);
                RequiredFields.Add(txtInternS);
                RequiredFields.Add(txtInternX);
                dtpSubmitDate.Properties.VistaEditTime = DefaultBoolean.True;
                dtpSubmitDate.Properties.MinValue = DateTime.Now;

                LoadExistingRasters();
                LoadExistingProject();

                if (ProjectID > 0)
                    ChkRaster.Enabled = false;
                if (txtkommissionNumber.Text != string.Empty)
                {
                    DisalbeProjectControls();
                }

                if (Utility.LVDetailsAccess == "9" || Utility.CalcAccess == "9")
                {
                    navBarItemLVDetails.Visible = false;
                    if(Utility.LVDetailsAccess == "9")
                    {
                        navBarItemImport.Visible = false;
                        navBarItemExport.Visible = false;
                        nbCopyLVs.Visible = false;
                    }
                    if (Utility.CalcAccess == "9")
                    {
                        navBarItemBulkProcess.Visible = false;
                        navBarItemMulti5.Visible = false;
                        navBarItemMulti6.Visible = false;
                        navBarItemSupplierProposal.Visible = false;
                        navBarItemUpdateSupplierProposal.Visible = false;
                        navBarItemUmlage.Visible = false;
                    }
                }
                if (Utility.ProjectDataAccess == "9")
                    navBarItemProject.Visible = false;
                if (Utility.DeliveryAccess == "9")
                    nbDeliveryNotes.Visible = false;
                if (Utility.InvoiceAccess == "9")
                    nbInvoices.Visible = false;
                if (Utility.KomissionDataAccess == "9" || Utility.KomissionDataAccess == "7")
                    txtkommissionNumber.Enabled = false;

                if (Utility.RoleID != 14)
                {
                    chkLockHierarchy.Enabled = false;
                    chkLockHierarchy.Enabled = false;
                }
                chkLockHierarchy_CheckedChanged(null,null);
                panelControldoc.Visible = false;
                toggleSwitchType.Visible = false;
                dockPanelArticles.Hide();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        ///  Code to parse the project details to bussiness logic
        /// </summary>
        private void ParseProjectDetails()
        {
            try
            {
                int iValue = 0;
                decimal dValue = 0;
                ObjEProject.ProjectNumber = txtProjectNumber.Text;
                ObjEProject.CommissionNumber = txtkommissionNumber.Text;
                ObjEProject.LVRaster = ChkRaster.Checked == true ? "" : ddlRaster.Text;

                if (int.TryParse(txtLVSprunge.Text, out iValue))
                    ObjEProject.LVSprunge = iValue;
                else
                {
                    if (Utility._IsGermany == true)
                        throw new Exception("Ungültiger LV Sprung");
                    else
                    {
                        throw new Exception("Invalid LV Sprunge");
                    }
                }
                if (decimal.TryParse(txtMWST.Text, out dValue))
                    ObjEProject.Vat = dValue;
                else
                {
                    if (Utility._IsGermany == true)
                        throw new Exception("Ungültige Angabe zur Umsatzsteuer");
                    else
                    {
                        throw new Exception("Invalid Vat");
                    }
                }

                ObjEProject.ProjectDescription = txtBauvorhaben.Text;
                ObjEProject.KundeID = 1;
                ObjEProject.KundeNr = txtKundeNo.Text;
                ObjEProject.KundeName = txtKundeName.Text;
                ObjEProject.PlannedID = 1;
                ObjEProject.PlannerName = txtPlanner.Text;

                if (decimal.TryParse(txtInternX.Text, out dValue))
                    ObjEProject.InternX = dValue;
                else
                {
                    if (Utility._IsGermany == true)
                        throw new Exception("Ungültige Angabe zum internen Verrechnungssatz");
                    else
                    {
                        throw new Exception("Invalid Intern (X)");
                    }
                }

                if (decimal.TryParse(txtInternS.Text, out dValue))
                    ObjEProject.InternS = dValue;
                else
                {
                    if (Utility._IsGermany == true)
                        throw new Exception("Ungültige Angabe zum externen Verrechnungssatz");
                    else
                    {
                        throw new Exception("Invalid Intern (S)");
                    }

                }

                ObjEProject.Submitlocation = txtSubmitLocation.Text;
                ObjEProject.SubmitDate = dtpSubmitDate.DateTime;
                ObjEProject.SubmitTime = dtpSubmitDate.DateTime;

                if (int.TryParse(txtEstimatedLVs.Text, out iValue))
                    ObjEProject.EstimatedLvs = iValue;

                ObjEProject.RoundingPriceID = 1;
                ObjEProject.Remarks = txtRemarks.Text;
                ObjEProject.LockHierarchy = chkLockHierarchy.Checked == true ? true : false;
                ObjEProject.IsCumulated = chkCumulated.Checked == true ? true : false;

                if (int.TryParse(ddlRounding.Text, out iValue))
                    ObjEProject.RoundingPrice = iValue;
                else
                {
                    if (Utility._IsGermany == true)
                        throw new Exception("Ungültige Angabe zur Rundungseinstellung");
                    else
                    {
                        throw new Exception("Invalid Rounding Price");
                    }
                }

                ObjEProject.ProjectStartDate = dtpProjectStartDate.DateTime;
                ObjEProject.ProjectEndDate = dtpProjectEndDate.DateTime;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Code to clear the fields on project screen in order to create a new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewProject_Click(object sender, EventArgs e)
        {
            ObjEProject = new EProject();
            ObjBProject = new BProject();

            txtProjectNumber.Text = string.Empty;
            txtkommissionNumber.Text = string.Empty;
            txtKundeName.Text = string.Empty;
            txtKundeNo.Text = string.Empty;
            txtPlanner.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtSubmitLocation.Text = string.Empty;
            txtEstimatedLVs.Text = string.Empty;
            txtBauvorhaben.Text = string.Empty;
            txtActualLVs.Text = string.Empty;
            ddlRaster.SelectedItem = null;
            ObjEProject.ProjectID = -1;
            txtkommissionNumber.ReadOnly = true;
            txtLVSprunge.Text = "1";
            txtInternS.Text = "1";
            txtInternX.Text = "1";
            txtMWST.Text = "0";
            dtpSubmitDate.DateTime = DateTime.Now;
            ddlRounding.SelectedIndex = ddlRounding.Properties.Items.IndexOf("0");
        }

        /// <summary>
        /// Load existing project in order to show the project details or in case of copy project
        /// </summary>  
        private void LoadExistingProject()
        {
            try
            {
                ObjEProject.ProjectID = ProjectID;
                ObjBProject.GetProjectDetails(ObjEProject);
                if (ObjEProject.dtLVSection != null && ObjEProject.dtLVSection.Rows.Count > 0)
                {
                    cmbLVSection.DataSource = ObjEProject.dtLVSection;
                    cmbLVSection.DisplayMember = "LVSectionName";
                    cmbLVSection.ValueMember = "LVSectionID";
                }

                if (ProjectID > 0)
                {
                    if (_IsCopy)
                    {
                        txtProjectNumber.Text = string.Empty;
                        txtkommissionNumber.Text = string.Empty;
                        txtkommissionNumber.ReadOnly = true;
                        ObjEProject.ProjectID = -1;
                    }
                    else
                    {
                        txtProjectNumber.Text = ObjEProject.ProjectNumber;
                        txtkommissionNumber.Text = ObjEProject.CommissionNumber;
                        txtProjectNumber.ReadOnly = true;
                        if (txtkommissionNumber.Text != string.Empty)
                            txtkommissionNumber.ReadOnly = true;
                        this.Text =ObjEProject.ProjectNumber;
                    }
                    ddlRaster.SelectedIndex = ddlRaster.Properties.Items.IndexOf(ObjEProject.LVRaster);
                    txtLVSprunge.Text = ObjEProject.LVSprunge.ToString();
                    txtMWST.Text = ObjEProject.Vat.ToString();
                    txtBauvorhaben.Text = ObjEProject.ProjectDescription;
                    txtKundeNo.Text = ObjEProject.KundeNr;
                    txtKundeName.Text = ObjEProject.KundeName;
                    txtPlanner.Text = ObjEProject.PlannerName;
                    txtInternX.Text = ObjEProject.InternX.ToString();
                    txtInternS.Text = ObjEProject.InternS.ToString();
                    txtSubmitLocation.Text = ObjEProject.Submitlocation;
                    dtpSubmitDate.DateTime = ObjEProject.SubmitDate;
                    txtEstimatedLVs.Text = ObjEProject.EstimatedLvs.ToString();
                    txtActualLVs.Text = ObjEProject.ActualLvs.ToString();
                    txtRemarks.Text = ObjEProject.Remarks;
                    chkLockHierarchy.Checked = ObjEProject.LockHierarchy;
                    chkCumulated.Checked = ObjEProject.IsCumulated;
                    ddlRounding.SelectedIndex = ddlRounding.Properties.Items.IndexOf(ObjEProject.RoundingPrice.ToString());
                    dtpProjectStartDate.DateTime = ObjEProject.ProjectStartDate;
                    dtpProjectEndDate.DateTime = ObjEProject.ProjectEndDate;
                    if (ObjEProject.IsDisable && !_IsCopy)
                    {
                        ddlRaster.Enabled = false;
                        txtLVSprunge.Enabled = false;
                    }
                    if (!string.IsNullOrEmpty(txtkommissionNumber.Text))
                        btnProjectSave.Enabled = false;
                }
                else
                {
                    txtkommissionNumber.ReadOnly = true;
                    txtLVSprunge.Text = "10";
                    txtInternS.Text = "1";
                    txtInternX.Text = "1";
                    txtMWST.Text = "1";
                    dtpSubmitDate.DateTime = DateTime.Now;
                    dtpProjectStartDate.DateTime = DateTime.Now;
                    dtpProjectEndDate.DateTime = DateTime.Now;
                    ddlRounding.SelectedIndex = ddlRounding.Properties.Items.IndexOf("3");
                    ddlRaster.SelectedIndex = ddlRaster.Properties.Items.IndexOf("99.99.1111.9");
                }
                setMask();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            BaseTabHeaderViewInfo headerInfo = (tcProjectDetails as IXtraTab).ViewInfo.HeaderInfo;
            try
            {
                if (headerInfo.VisiblePages.Count >= 1)
                {
                    var dlgresult = "";
                    if (Utility._IsGermany == true)
                    {
                        dlgresult = XtraMessageBox.Show("möchten sie diese seite wirklich schließen.?", " bestätigung …!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString();
                    }
                    else
                    {
                        dlgresult = XtraMessageBox.Show("Are you sure you want to close the page.?", "confirmation..!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString();

                    }
                    if (dlgresult.ToString().ToLower() == "cancel")
                    {
                        e.Cancel = true;
                    }
                    btnCancel_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
            if (frmOTTOPro.Instance.MdiChildren.Count() == 1)
            {
                frmOTTOPro.Instance.SetPictureBoxVisible(true);
                frmOTTOPro.Instance.SetLableVisible(true);
            }
        }

        private void txtProjectNumber_TextChanged(object sender, EventArgs e)
        {

            //if (txtProjectNumber.Text != string.Empty)
            //    _NeedConfirm = true;
            //else
            //    _NeedConfirm = false;
        }

        private void IntializeLVPositions()
        {
            try
            {
                if (!string.IsNullOrEmpty(ObjEProject.LVRaster))
                {
                    string[] Levels = ObjEProject.LVRaster.Split('.');
                    int Count = Levels.Length;
                    if (Levels[Count - 1].Length == 1)
                        Count -= 1;
                    iRasterCount = Count;
                    if (Count < 3)
                    {
                        txtStufe1Short.Properties.MaxLength = Levels[0].Length;
                        txtPosition.Properties.MaxLength = (Levels[1] + Levels[2]).Length + 1;
                        lciStufe2Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe2Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe3Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe3Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe4Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe4Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                    else if (Count < 4)
                    {
                        txtStufe1Short.Properties.MaxLength = Levels[0].Length;
                        txtStufe2Short.Properties.MaxLength = Levels[1].Length;
                        txtPosition.Properties.MaxLength = (Levels[2] + Levels[3]).Length + 1;
                        lciStufe2Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe2Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe3Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe4Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe4Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                    else if (Count < 5)
                    {
                        txtStufe1Short.Properties.MaxLength = Levels[0].Length;
                        txtStufe2Short.Properties.MaxLength = Levels[1].Length;
                        txtStufe3Short.Properties.MaxLength = Levels[2].Length;
                        txtPosition.Properties.MaxLength = (Levels[3] + Levels[4]).Length + 1;
                        lciStufe2Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe2Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe4Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe4Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                    else
                    {
                        txtStufe1Short.Properties.MaxLength = Levels[0].Length;
                        txtStufe2Short.Properties.MaxLength = Levels[1].Length;
                        txtStufe3Short.Properties.MaxLength = Levels[2].Length;
                        txtStufe4Short.Properties.MaxLength = Levels[3].Length;
                        txtPosition.Properties.MaxLength = (Levels[4] + Levels[5]).Length + 1;
                        lciStufe2Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe2Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe4Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe4Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    }
                }               
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void ParsePositionDetails()
        {
            try
            {
                int iValue = 0;
                decimal dValue = 0;
                DateTime dt = DateTime.Now;
                ObjEPosition.RasterCount = iRasterCount;
                ObjEPosition.ProjectID = ObjEProject.ProjectID;
                ObjEPosition.Stufe1 = txtStufe1Short.Text;
                ObjEPosition.Stufe2 = txtStufe2Short.Text;
                ObjEPosition.Stufe3 = txtStufe3Short.Text;
                ObjEPosition.Stufe4 = txtStufe4Short.Text;
                ObjEPosition.Position = txtPosition.Text;
                ObjEPosition.ShortDescription = txtShortDescription.Rtf;
                if (txtPosition.Text == string.Empty)
                    ObjEPosition.Title = txtShortDescription.Text;
                if (txtPosition.Text != string.Empty)
                    ObjEPosition.PositionKZ = cmbPositionKZ.Text;
                else if (cmbPositionKZ.Text == "H")
                    ObjEPosition.PositionKZ = cmbPositionKZ.Text;
                else
                    ObjEPosition.PositionKZ = "NG";

                if (int.TryParse(txtDetailKZ.Text, out iValue))
                    ObjEPosition.DetailKZ = iValue;

                if (cmbLVSection.Text == string.Empty)
                    ObjEPosition.LVSection = "HA";
                else
                    ObjEPosition.LVSection = cmbLVSection.Text;
                ObjEPosition.WG = txtWG.Text;
                ObjEPosition.WA = txtWA.Text;
                ObjEPosition.WI = txtWI.Text;

                if (decimal.TryParse(txtMenge.Text, out dValue))
                {
                    if (ObjEPosition.PositionKZ == "P")
                        ObjEPosition.Menge = 1;
                    else
                        ObjEPosition.Menge = dValue;
                }

                ObjEPosition.ME = cmbME.Text;
                ObjEPosition.Fabricate = txtFabrikate.Text;
                ObjEPosition.LiefrantMA = txtLiefrantMA.Text;
                ObjEPosition.Type = txtType.Text;
                ObjEPosition.LongDescription = LongDescription;

                ObjEPosition.Surcharge_From = txtSurchargeFrom.Text;
                ObjEPosition.Surcharge_To = txtSurchargeTo.Text;

                if (decimal.TryParse(txtSurchargePerME.Text, out dValue))
                    ObjEPosition.Surcharge_Per = dValue;

                if (decimal.TryParse(txtSurchargePerMO.Text, out dValue))
                    ObjEPosition.surchargePercentage_MO = dValue;

                ObjEPosition.ValidityDate = dtpValidityDate.Value;

                ObjEPosition.MA = txtMa.Text;
                ObjEPosition.MO = txtMo.Text;

                if (decimal.TryParse(txtMin.Text, out dValue))
                    ObjEPosition.Mins = dValue;

                if (decimal.TryParse(txtFaktor.Text, out dValue))
                    ObjEPosition.Faktor = dValue;

                if (decimal.TryParse(txtLPMe.Text, out dValue))
                    ObjEPosition.LPMA = dValue;

                if (decimal.TryParse(txtLPMO.Text, out dValue))
                    ObjEPosition.LPMO = dValue;

                if (decimal.TryParse(txtMulti1ME.Text, out dValue))
                    ObjEPosition.Multi1MA = dValue;

                if (decimal.TryParse(txtMulti2ME.Text, out dValue))
                    ObjEPosition.Multi2MA = dValue;

                if (decimal.TryParse(txtMulti3ME.Text, out dValue))
                    ObjEPosition.Multi3MA = dValue;

                if (decimal.TryParse(txtMulti4ME.Text, out dValue))
                    ObjEPosition.Multi4MA = dValue;

                if (decimal.TryParse(txtMulti1MO.Text, out dValue))
                    ObjEPosition.Multi1MO = dValue;

                if (decimal.TryParse(txtMulti2MO.Text, out dValue))
                    ObjEPosition.Multi2MO = dValue;

                if (decimal.TryParse(txtMulti3MO.Text, out dValue))
                    ObjEPosition.Multi3MO = dValue;

                if (decimal.TryParse(txtMulti4MO.Text, out dValue))
                    ObjEPosition.Multi4MO = dValue;

                if (decimal.TryParse(txtEinkaufspreisME.Text, out dValue))
                    ObjEPosition.EinkaufspreisMA = dValue;

                if (decimal.TryParse(txtEinkaufspreisMO.Text, out dValue))
                    ObjEPosition.EinkaufspreisMO = dValue;

                if (decimal.TryParse(txtSelbstkostenMultiME.Text, out dValue))
                    ObjEPosition.SelbstkostenMultiMA = dValue;

                if (decimal.TryParse(txtSelbstkostenValueME.Text, out dValue))
                    ObjEPosition.SelbstkostenValueMA = dValue;

                if (decimal.TryParse(txtSelbstkostenMultiMO.Text, out dValue))
                    ObjEPosition.SelbstkostenMultiMO = dValue;

                if (decimal.TryParse(txtSelbstkostenValueMO.Text, out dValue))
                    ObjEPosition.SelbstkostenValueMO = dValue;

                if (decimal.TryParse(txtVerkaufspreisMultiME.Text, out dValue))
                    ObjEPosition.VerkaufspreisMultiMA = dValue;

                if (decimal.TryParse(txtVerkaufspreisValueME.Text, out dValue))
                    ObjEPosition.VerkaufspreisValueMA = dValue;

                if (decimal.TryParse(txtVerkaufspreisMultiMO.Text, out dValue))
                    ObjEPosition.VerkaufspreisMultiMO = dValue;

                if (decimal.TryParse(txtVerkaufspreisValueMO.Text, out dValue))
                    ObjEPosition.VerkaufspreisValueMO = dValue;

                if (decimal.TryParse(txtStdSatz.Text, out dValue))
                    ObjEPosition.StdSatz = dValue;

                if (!string.IsNullOrEmpty(txtPreisText.Text))
                    ObjEPosition.PreisText = txtPreisText.Text;

                ObjEPosition.EinkaufspreisLockMA = Convert.ToBoolean(chkEinkaufspreisME.CheckState);
                ObjEPosition.EinkaufspreisLockMO = Convert.ToBoolean(chkEinkaufspreisMO.CheckState);
                ObjEPosition.SelbstkostenLockMA = Convert.ToBoolean(chkSelbstkostenME.CheckState);
                ObjEPosition.SelbstkostenLockMO = Convert.ToBoolean(chkSelbstkostenMO.CheckState);
                ObjEPosition.VerkaufspreisLockMA = Convert.ToBoolean(chkVerkaufspreisME.CheckState);
                ObjEPosition.VerkaufspreisLockMO = Convert.ToBoolean(chkVerkaufspreisMO.CheckState);

                ObjEPosition.Dim1 = txtDim1.Text;
                ObjEPosition.Dim2 = txtDim2.Text;
                ObjEPosition.Dim3 = txtDim3.Text;

                ObjEPosition.DocuwareLink1 = _DocuwareLink1;
                ObjEPosition.DocuwareLink2 = _DocuwareLink2;
                ObjEPosition.DocuwareLink3 = _DocuwareLink3;

                ObjEPosition.LVStatus = cmbLVStatus.Text;

                if (decimal.TryParse(txtGrandTotalME.Text, out dValue))
                    ObjEPosition.GrandTotalME = dValue;

                if (decimal.TryParse(txtGrandTotalMO.Text, out dValue))
                    ObjEPosition.GrandTotalMO = dValue;

                if (decimal.TryParse(txtFinalGB.Text, out dValue))
                    ObjEPosition.FinalGB = dValue;
                if (decimal.TryParse(txtEP.Text, out dValue))
                    ObjEPosition.EP = dValue;
                ObjEPosition.SNO = iSNO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BindPositionData()
        {
            try
            {
                if (ObjEProject.ActualLvs < 1)
                {
                    btnModify.Enabled = false;
                }
                ObjBPosition.GetPositionList(ObjEPosition, ObjEProject.ProjectID);
                if (ObjEPosition.dsPositionList != null)
                {
                    CalculatePositions(ObjEPosition.dsPositionList.Tables[0], "GB");
                    xtraTabPageHierachical.Controls.Add(tlPositions);
                    tlPositions.DataSource = ObjEPosition.dsPositionList;
                    tlPositions.DataMember = "Positions";
                    tlPositions.ParentFieldName = "Parent_OZ";
                    tlPositions.KeyFieldName = "PositionID";
                    tlPositions.ForceInitialize();
                    tlPositions.ExpandAll();
                    CalculateNodes(tlPositions, "GB");                    
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindPositionDataTabular()
        {
            try
            {
                if (ObjEPosition.dsPositionList != null)
                {
                    xtraTabPageTabular.Controls.Add(tlPositions);
                    tlPositions.DataMember = "Positions";
                    tlPositions.ParentFieldName = "Positions";
                    tlPositions.ForceInitialize();
                    tlPositions.ExpandAll();
                    CalculateNodes(tlPositions, "GB");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void tlPositions_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (!_IsNewMode && tlPositions.FocusedNode != null && tlPositions.FocusedNode["PositionID"] != null)
                {
                    string strLVSection = tlPositions.FocusedNode["LVSection"].ToString();
                    if (strLVSection.ToLower() != "ha")
                    {
                        if (Utility.LVSectionEditAccess == "9" || Utility.LVSectionEditAccess == "7")
                        {
                            layoutControl3.Enabled = false;
                            layoutControl6.Enabled = false;
                            tlPositions.OptionsBehavior.Editable = false;
                            btnSaveLVDetails.Enabled = false;
                        }
                    }
                    else
                    {
                        if (!ObjEProject.IsFinalInvoice)
                        {
                            if (Utility.LVDetailsAccess != "7")
                            {
                                layoutControl3.Enabled = true;
                                btnNew.Enabled = true;
                                chkCreateNew.Enabled = true;
                            }
                            if (Utility.CalcAccess != "7")
                            {
                                layoutControl6.Enabled = true;
                                tlPositions.OptionsBehavior.Editable = true;
                            }
                            btnSaveLVDetails.Enabled = true;
                            btnCancel.Enabled = true;
                        }
                    }
                    string strHaveDetailKZ = tlPositions.FocusedNode["HaveDetailkz"] == DBNull.Value ? "" : Convert.ToString(tlPositions.FocusedNode["HaveDetailkz"]);
                    bool HaveDetailKZ = false;
                    if (bool.TryParse(strHaveDetailKZ, out HaveDetailKZ))
                    {
                        if (HaveDetailKZ)
                            layoutControlGroup7.Enabled = false;
                        else
                            layoutControlGroup7.Enabled = true;
                    }
                    LongDescription = string.Empty;
                    string strPositionID = tlPositions.FocusedNode["PositionID"].ToString();
                    ObjEPosition.PositionID = Convert.ToInt32(strPositionID);
                    DataView dvPosition = ObjEPosition.dsPositionList.Tables[0].DefaultView;
                    dvPosition.RowFilter = "PositionID = '" + strPositionID + "'";
                    DataTable dtTemp = dvPosition.ToTable();
                    string strPositionOZ = dtTemp.Rows[0]["Position_OZ"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["Position_OZ"].ToString();

                    if (!string.IsNullOrEmpty(strPositionOZ) && !string.IsNullOrEmpty(ObjEProject.LVRaster))
                    {
                        string[] Titles = strPositionOZ.Split('.');
                        string[] Raster = ObjEProject.LVRaster.Split('.');
                        int TitleCount = Titles.Count();

                        if (Titles != null && Raster != null && TitleCount == Raster.Count())
                        {
                            //if postion 1.1.1.1.10.1
                            TitleCount -= 2;
                            if (TitleCount > 0)
                            {
                                txtStufe1Short.Text = Titles[0];
                                txtStufe1Short_TextChanged(null, null);
                                if (TitleCount > 1)
                                {
                                    txtStufe2Short.Text = Titles[1];
                                    txtStufe2Short_TextChanged(null, null);
                                    if (TitleCount > 2)
                                    {
                                        txtStufe3Short.Text = Titles[2];
                                        txtStufe3Short_TextChanged(null, null);
                                        if (TitleCount > 3)
                                        {
                                            txtStufe4Short.Text = Titles[3];
                                            txtStufe4Short_TextChanged(null, null);
                                        }
                                        else
                                        {
                                            txtStufe4Short.Text = string.Empty;
                                        }
                                    }
                                    else
                                    {
                                        txtStufe3Short.Text = string.Empty;
                                        txtStufe4Short.Text = string.Empty;
                                    }
                                }
                                else
                                {
                                    txtStufe2Short.Text = string.Empty;
                                    txtStufe3Short.Text = string.Empty;
                                    txtStufe4Short.Text = string.Empty;
                                }
                            }
                            else
                            {
                                txtStufe1Short.Text = string.Empty;
                                txtStufe2Short.Text = string.Empty;
                                txtStufe3Short.Text = string.Empty;
                                txtStufe4Short.Text = string.Empty;
                            }
                            txtPosition.Text = Titles[TitleCount] + "." + Titles[TitleCount + 1];
                        }
                        else if (TitleCount <= Raster.Count() - 1)
                        {
                            //if position 1.1.1.1.10
                            TitleCount -= 1;
                            if (TitleCount > 0)
                            {
                                txtStufe1Short.Text = Titles[0];
                                if (TitleCount > 1)
                                {
                                    txtStufe2Short.Text = Titles[1];
                                    if (TitleCount > 2)
                                    {
                                        txtStufe3Short.Text = Titles[2];
                                        if (TitleCount > 3)
                                            txtStufe4Short.Text = Titles[3];
                                        else
                                            txtStufe4Short.Text = string.Empty;
                                    }
                                    else
                                    {
                                        txtStufe3Short.Text = string.Empty;
                                        txtStufe4Short.Text = string.Empty;
                                    }
                                }
                                else
                                {
                                    txtStufe2Short.Text = string.Empty;
                                    txtStufe3Short.Text = string.Empty;
                                    txtStufe4Short.Text = string.Empty;
                                }
                            }
                            else
                            {
                                txtStufe1Short.Text = string.Empty;
                                txtStufe2Short.Text = string.Empty;
                                txtStufe3Short.Text = string.Empty;
                                txtStufe4Short.Text = string.Empty;
                            }
                            txtPosition.Text = Titles[TitleCount];
                        }
                        txtLVPosition.Text = strPositionOZ;
                    }

                    txtWG.Text = tlPositions.FocusedNode["WG"] == DBNull.Value ? "" : tlPositions.FocusedNode["WG"].ToString();// dtTemp.Rows[0]["WG"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["WG"].ToString();
                    txtWI.Text = tlPositions.FocusedNode["WI"] == DBNull.Value ? "" : tlPositions.FocusedNode["WI"].ToString();
                    txtWA.Text = tlPositions.FocusedNode["WA"] == DBNull.Value ? "" : tlPositions.FocusedNode["WA"].ToString();
                    txtType.Text = tlPositions.FocusedNode["Type"] == DBNull.Value ? "" : tlPositions.FocusedNode["Type"].ToString();
                    txtFabrikate.Text = tlPositions.FocusedNode["Fabricate"] == DBNull.Value ? "" : tlPositions.FocusedNode["Fabricate"].ToString();
                    txtLiefrantMA.Text = tlPositions.FocusedNode["LiefrantMA"] == DBNull.Value ? "" : tlPositions.FocusedNode["LiefrantMA"].ToString();
                    txtMenge.Text = tlPositions.FocusedNode["Menge"] == DBNull.Value ? "" : tlPositions.FocusedNode["Menge"].ToString();
                    cmbPositionKZ.Text = tlPositions.FocusedNode["PositionKZ"] == DBNull.Value ? "" : tlPositions.FocusedNode["PositionKZ"].ToString(); //cmbPositionKZ.Properties.Items.IndexOf(dtTemp.Rows[0]["PositionKZ"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["PositionKZ"].ToString());
                    txtDetailKZ.Text = tlPositions.FocusedNode["DetailKZ"] == DBNull.Value ? "" : tlPositions.FocusedNode["DetailKZ"].ToString();
                    txtShortDescription.Rtf = tlPositions.FocusedNode["ShortDescription"] == DBNull.Value ? "" : tlPositions.FocusedNode["ShortDescription"].ToString();
                    cmbME.Text = tlPositions.FocusedNode["ME"] == DBNull.Value ? "" : tlPositions.FocusedNode["ME"].ToString();
                    cmbLVSection.Text = tlPositions.FocusedNode["LVSection"] == DBNull.Value ? "" : tlPositions.FocusedNode["LVSection"].ToString();
                    cmbLVStatus.Text = tlPositions.FocusedNode["LVStatus"] == DBNull.Value ? "" : tlPositions.FocusedNode["LVStatus"].ToString();
                    txtSurchargeFrom.Text = tlPositions.FocusedNode["surchargefrom"] == DBNull.Value ? "" : tlPositions.FocusedNode["surchargefrom"].ToString();
                    txtSurchargeTo.Text = tlPositions.FocusedNode["surchargeto"] == DBNull.Value ? "" : tlPositions.FocusedNode["surchargeto"].ToString();
                    txtSurchargePerME.Text = tlPositions.FocusedNode["surchargePercentage"] == DBNull.Value ? "" : tlPositions.FocusedNode["surchargePercentage"].ToString();
                    txtSurchargePerMO.Text = tlPositions.FocusedNode["surchargePercentage_MO"] == DBNull.Value ? "" : tlPositions.FocusedNode["surchargePercentage_MO"].ToString();
                    dtpValidityDate.Value = tlPositions.FocusedNode["validitydate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(tlPositions.FocusedNode["validitydate"]);
                    txtMa.Text = tlPositions.FocusedNode["MA"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA"].ToString();
                    txtMo.Text = tlPositions.FocusedNode["MO"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO"].ToString();
                    txtMin.Text = tlPositions.FocusedNode["minutes"] == DBNull.Value ? "" : tlPositions.FocusedNode["minutes"].ToString();
                    txtFaktor.Text = tlPositions.FocusedNode["Faktor"] == DBNull.Value ? "" : tlPositions.FocusedNode["Faktor"].ToString();
                    txtLPMe.Text = tlPositions.FocusedNode["MA_listprice"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_listprice"].ToString();
                    txtLPMO.Text = tlPositions.FocusedNode["MO_listprice"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_listprice"].ToString();
                    txtMulti1ME.Text = tlPositions.FocusedNode["MA_Multi1"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_Multi1"].ToString();
                    txtMulti2ME.Text = tlPositions.FocusedNode["MA_multi2"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_multi2"].ToString();
                    txtMulti3ME.Text = tlPositions.FocusedNode["MA_multi3"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_multi3"].ToString();
                    txtMulti4ME.Text = tlPositions.FocusedNode["MA_multi4"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_multi4"].ToString();
                    txtEinkaufspreisME.Text = tlPositions.FocusedNode["MA_einkaufspreis"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_einkaufspreis"].ToString();
                    txtSelbstkostenValueME.Text = tlPositions.FocusedNode["MA_selbstkosten"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_selbstkosten"].ToString();
                    txtSelbstkostenMultiME.Text = tlPositions.FocusedNode["MA_selbstkostenMulti"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_selbstkostenMulti"].ToString();
                    txtVerkaufspreisValueME.Text = tlPositions.FocusedNode["MA_verkaufspreis"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_verkaufspreis"].ToString();
                    txtVerkaufspreisMultiME.Text = tlPositions.FocusedNode["MA_verkaufspreis_Multi"] == DBNull.Value ? "" : tlPositions.FocusedNode["MA_verkaufspreis_Multi"].ToString();
                    txtMulti1MO.Text = tlPositions.FocusedNode["MO_multi1"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_multi1"].ToString();
                    txtMulti2MO.Text = tlPositions.FocusedNode["MO_multi2"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_multi2"].ToString();
                    txtMulti3MO.Text = tlPositions.FocusedNode["MO_multi3"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_multi3"].ToString();
                    txtMulti4MO.Text = tlPositions.FocusedNode["MO_multi4"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_multi4"].ToString();
                    txtEinkaufspreisMO.Text = tlPositions.FocusedNode["MO_Einkaufspreis"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_Einkaufspreis"].ToString();
                    txtSelbstkostenMultiMO.Text = tlPositions.FocusedNode["MO_selbstkostenMulti"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_selbstkostenMulti"].ToString();
                    txtSelbstkostenValueMO.Text = tlPositions.FocusedNode["MO_selbstkosten"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_selbstkosten"].ToString();
                    txtVerkaufspreisMultiMO.Text = tlPositions.FocusedNode["MO_verkaufspreisMulti"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_verkaufspreisMulti"].ToString();
                    txtVerkaufspreisValueMO.Text = tlPositions.FocusedNode["MO_verkaufspreis"] == DBNull.Value ? "" : tlPositions.FocusedNode["MO_verkaufspreis"].ToString();
                    txtStdSatz.Text = tlPositions.FocusedNode["std_satz"] == DBNull.Value ? "" : tlPositions.FocusedNode["std_satz"].ToString();
                    txtPreisText.Text = tlPositions.FocusedNode["PreisText"] == DBNull.Value ? "" : tlPositions.FocusedNode["PreisText"].ToString();
                    chkEinkaufspreisME.EditValue = tlPositions.FocusedNode["MA_einkaufspreis_lck"] == DBNull.Value ? true : Convert.ToBoolean(tlPositions.FocusedNode["MA_einkaufspreis_lck"]);
                    chkSelbstkostenME.EditValue = tlPositions.FocusedNode["MA_selbstkosten_lck"] == DBNull.Value ? true : Convert.ToBoolean(tlPositions.FocusedNode["MA_selbstkosten_lck"]);
                    chkVerkaufspreisME.EditValue = tlPositions.FocusedNode["MA_verkaufspreis_lck"] == DBNull.Value ? true : Convert.ToBoolean(tlPositions.FocusedNode["MA_verkaufspreis_lck"]);
                    chkEinkaufspreisMO.EditValue = tlPositions.FocusedNode["MO_Einkaufspreis_lck"] == DBNull.Value ? true : Convert.ToBoolean(tlPositions.FocusedNode["MO_Einkaufspreis_lck"]);
                    chkSelbstkostenMO.EditValue = tlPositions.FocusedNode["MO_selbstkosten_lck"] == DBNull.Value ? true : Convert.ToBoolean(tlPositions.FocusedNode["MO_selbstkosten_lck"]);
                    chkVerkaufspreisMO.EditValue = tlPositions.FocusedNode["MO_verkaufspreis_lck"] == DBNull.Value ? true : Convert.ToBoolean(tlPositions.FocusedNode["MO_verkaufspreis_lck"]); //dtTemp.Rows[0]["MO_verkaufspreis_lck"] == DBNull.Value ? true : Convert.ToBoolean(dtTemp.Rows[0]["MO_verkaufspreis_lck"]);
                    txtDim1.Text = tlPositions.FocusedNode["A"] == DBNull.Value ? "" : tlPositions.FocusedNode["A"].ToString();
                    txtDim2.Text = tlPositions.FocusedNode["B"] == DBNull.Value ? "" : tlPositions.FocusedNode["B"].ToString();
                    txtDim3.Text = tlPositions.FocusedNode["L"] == DBNull.Value ? "" : tlPositions.FocusedNode["L"].ToString();
                    _DocuwareLink1 = tlPositions.FocusedNode["DocuwareLink1"] == DBNull.Value ? "" : tlPositions.FocusedNode["DocuwareLink1"].ToString();
                    _DocuwareLink2 = tlPositions.FocusedNode["DocuwareLink2"] == DBNull.Value ? "" : tlPositions.FocusedNode["DocuwareLink2"].ToString();
                    _DocuwareLink3 = tlPositions.FocusedNode["DocuwareLink3"] == DBNull.Value ? "" : tlPositions.FocusedNode["DocuwareLink3"].ToString();
                    txtGrandTotalME.Text = tlPositions.FocusedNode["GrandTotalME"] == DBNull.Value ? "" : tlPositions.FocusedNode["GrandTotalME"].ToString();
                    txtGrandTotalMO.Text = tlPositions.FocusedNode["GrandTotalMO"] == DBNull.Value ? "" : tlPositions.FocusedNode["GrandTotalMO"].ToString();
                    txtFinalGB.Text = tlPositions.FocusedNode["GB"] == DBNull.Value ? "" : tlPositions.FocusedNode["GB"].ToString();
                    txtEP.Text = tlPositions.FocusedNode["EP"] == DBNull.Value ? "" : tlPositions.FocusedNode["EP"].ToString();

                    if (tlPositions.Nodes.Count > 0)
                    {
                        string P_value = tlPositions.FocusedNode["PositionKZ"].ToString();
                        if (P_value == "NG")
                        {
                            txtPosition.Enabled = false;
                            btnLongDescription.Enabled = false;
                        }
                        else
                        {
                            txtPosition.Enabled = true;
                            btnLongDescription.Enabled = true;
                        }                        
                    }
                    txtMo_TextChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void SetFocus(int PositionID, TreeList tlPositions)
        {
            try
            {
                TreeListNode Nodetofocus = null;
                Nodetofocus = this.tlPositions.FindNodeByKeyID(PositionID);
                this.tlPositions.SetFocusedNode(Nodetofocus);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnLongDescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (tlPositions.FocusedNode != null)
                {
                    frmViewdescription Obj = new frmViewdescription(_IsNewMode);
                    if (LongDescription == string.Empty && !_IsNewMode)
                        Obj.LongDescription = ObjBPosition.GetLongDescription(Convert.ToInt32(tlPositions.FocusedNode["PositionID"]));
                    else
                        Obj.LongDescription = LongDescription;
                    Obj.ShowDialog();
                    LongDescription = Obj.LongDescription;
                    if (ObjEPosition.PositionID > 0 && Obj._IsSave)
                    {
                        ObjBPosition.UpdateLongDescription(ObjEPosition.PositionID, LongDescription);
                        LongDescription = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //try
            //{
            //    int iValue = 0;
            //    if (tlPositions.FocusedNode != null 
            //        && tlPositions.FocusedNode["PositionID"] != null 
            //        && Int32.TryParse(tlPositions.FocusedNode["PositionID"].ToString(), out iValue) 
            //        && _IsEditMode == false)
            //    {
            //        _IsEditMode = true;
            //        _PositionID = iValue;
            //        txtStufe1Title.Enabled = false;
            //        txtStufe2Title.Enabled = false;
            //        txtStufe3Title.Enabled = false;
            //        txtStufe4Title.Enabled = false;
            //    }
            //    else if(_IsEditMode)
            //    {
            //        XtraMessageBox.Show("Please save the changes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Please select atleast one position", "Inoformation..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

        private void tabNavigationHierarchical_TabIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    tlPositions.ExpandAll();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

        private void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            //if (tabPane1.SelectedPage.Caption == "Hierarchical")
            //{
            //    BindPositionData();
            //}
            //else
            //{
            //    BindPositionDataTabular();
            //}
        }

        private void tlPositions_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                var view = (TreeList)sender;
                var editor = view.ActiveEditor as TextEdit;
                if (editor == null)
                    return;
                editor.ContextMenuStrip = new ContextMenuStrip();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void barButtonItemAddTextPosition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmAddhocPosition frm = new frmAddhocPosition();
            //frm.ShowDialog();

        }

        private void barButtonItemAddSurchange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Get the display text of the focused node's cell 
                string cellText = tlPositions.FocusedNode.GetDisplayText("Position_OZ");

                DataTable dt = ObjEPosition.dsPositionList.Tables[0];

                int Parent_OZ = (from DataRow dr in dt.Rows
                                 where (string)dr["Position_OZ"] == cellText
                                 select (int)dr["Parent_OZ"]).FirstOrDefault();

                object Position_OZ = dt.Compute("MAX(Position_OZ)", "Parent_OZ='" + Parent_OZ + "' and PositionKZ <>'" + "ZS" + "'");
            }
            catch (Exception)
            {
                throw;
            }

        }   

        XtraTabPage ObjTabDetails = null;
        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            //if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPageHierachical")
            //{
            //    BindPositionData();
            //}
            //else
            //{
            //    BindPositionDataTabular();

            //}
        }

        private void CalculateNodes(TreeList Objtreelist, string strField)
        {
            try
            {
                foreach (TreeListNode node in Objtreelist.Nodes)
                {
                    CalculateTitleSum(node, strField);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CalculateTitleSum(TreeListNode Node, string strField)
        {
            try
            {
                if (Node.HasChildren)
                {
                    decimal iValue = 0;
                    foreach (TreeListNode node in Node.Nodes)
                    {
                        CalculateTitleSum(node, strField);
                        decimal lValue = 0;
                        string strPositionKZ = node["PositionKZ"].ToString();

                        if (strPositionKZ != "ZS" && strPositionKZ != "E" && strPositionKZ != "A")
                        {
                            if (node["DetailKZ"].ToString() == "0" &&
                                decimal.TryParse(node[strField].ToString(), out lValue))
                            {
                                iValue += lValue;
                            }
                        }
                    }
                    Node.SetValue(tlPositions.Columns[strField], iValue.ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CalculateDetailKZ(DataTable dt, string strField)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToString(dr["DetailKZ"]) == "1")
                    {
                        string strOZ = Convert.ToString(dr["Position_OZ"]);
                        DataRow[] FilteredRows = dt.Select("Position_OZ = '" + strOZ + "' and DetailKZ > 0");
                        decimal iValue = 0;
                        foreach (DataRow drnew in FilteredRows)
                        {
                            decimal OutValue = 0;
                            if (Convert.ToString(drnew["Position_OZ"]) == strOZ && decimal.TryParse(drnew[strField].ToString(), out OutValue))
                            {
                                iValue += OutValue;
                            }
                        }
                        DataRow[] TargetRow = dt.Select("Position_OZ = '" + strOZ + "' and DetailKZ = 0");
                        if (TargetRow != null && TargetRow.Count() > 0)
                        {
                            TargetRow[0][strField] = iValue.ToString();
                            int Menge = 0;
                            if (int.TryParse(Convert.ToString(TargetRow[0]["Menge"]), out Menge))
                            {
                                TargetRow[0]["GB"] = Menge * iValue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbPositionKZ_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbPositionKZ.Text) && (cmbPositionKZ.Text.ToLower() == "zs" || cmbPositionKZ.Text.ToLower() == "z"))
                {
                    FormatFieldsForSum();
                    if (cmbPositionKZ.Text.ToLower() == "zs")
                    {
                        lblsurchargefrom.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lblsurchargeto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lblsurchargeme.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lblsurchargemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        if (_IsNewMode)
                        {
                            string strParentOZ = PrepareOZ();
                            txtSurchargeFrom.Text = FromOZ(strParentOZ, "ZS");
                            txtSurchargeTo.Text = ToOZ(strParentOZ, "ZS");
                        }
                        lcCostDetails.Enabled = false;
                    }
                    else if (cmbPositionKZ.Text.ToLower() == "z")
                    {
                        if (tlPositions.FocusedNode != null)
                        {
                            lblsurchargefrom.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            lblsurchargeto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            lblsurchargeme.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            lblsurchargemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            txtPosition.Enabled = true;
                            if (_IsNewMode)
                            {
                                string strParentOZ = PrepareOZ();
                                txtSurchargeFrom.Text = FromOZ(strParentOZ, "Z");
                                txtSurchargeTo.Text = ToOZ(strParentOZ, "Z");
                                txtSurchargePerME.Text = "1";
                                txtSurchargePerMO.Text = "1";
                            }
                        }
                        lcCostDetails.Enabled = false;
                    }
                }
                else
                {
                    FormatFieldsForNormal();
                    ClearingValues();
                    lcCostDetails.Enabled = true;
                }

                if (cmbPositionKZ.Text.ToLower() == "h")
                {
                    EnableAndDisableAllControls(false);
                }
                else
                {
                    EnableAndDisableAllControls(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ClearingValues()
        {
            //lblsurchargeme.Visible = false;
            //lblsurchargemo.Visible = false;
            //lblsurchargefrom.Visible = false;
            //lblsurchargeto.Visible = false;
            lblsurchargefrom.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lblsurchargeto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lblsurchargeme.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lblsurchargemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            txtSurchargePerME.Text = "";
            txtSurchargePerMO.Text = "";
            txtSurchargeFrom.Text = "";
            txtSurchargeTo.Text = "";
        }

        private void tlPositions_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                if (Utility.CalcAccess != "7")
                {
                    tlPositions.Columns["MA_Multi1"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisME.CheckState);
                    tlPositions.Columns["MA_multi2"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisME.CheckState);
                    tlPositions.Columns["MA_multi3"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisME.CheckState);
                    tlPositions.Columns["MA_multi4"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisME.CheckState);

                    tlPositions.Columns["MO_multi1"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisMO.CheckState);
                    tlPositions.Columns["MO_multi2"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisMO.CheckState);
                    tlPositions.Columns["MO_multi3"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisMO.CheckState);
                    tlPositions.Columns["MO_multi4"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkEinkaufspreisMO.CheckState);


                    tlPositions.Columns["MA_selbstkostenMulti"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkSelbstkostenME.CheckState);
                    tlPositions.Columns["MO_selbstkostenMulti"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkSelbstkostenMO.CheckState);
                    tlPositions.Columns["MA_verkaufspreis_Multi"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkVerkaufspreisME.CheckState);
                    tlPositions.Columns["MO_verkaufspreisMulti"].ColumnEdit.ReadOnly = Convert.ToBoolean(chkVerkaufspreisMO.CheckState);
                }
                

                string strNodeType = e.Node["PositionKZ"].ToString().ToLower();

                if (strNodeType == "zs" || strNodeType == "z")
                {
                    if (strNodeType == "zs")
                        e.Appearance.BackColor = Color.Orange;
                    else if (strNodeType == "z")
                        e.Appearance.BackColor = Color.YellowGreen;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                int _DetKZ = Convert.ToInt32(e.Node["DetailKZ"]);
                if (_DetKZ > 0)
                {
                    Color _Color = Color.FromArgb(132, 107, 75);
                    e.Appearance.BackColor = _Color;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
                if (e.Column.FieldName == "MA_einkaufspreis" ||
                    e.Column.FieldName == "MA_selbstkosten" ||
                    e.Column.FieldName == "MA_verkaufspreis" ||
                    e.Column.FieldName == "MO_Einkaufspreis" ||
                    e.Column.FieldName == "MO_selbstkosten" ||
                    e.Column.FieldName == "MO_verkaufspreis" ||
                    e.Column.FieldName == "EP" ||
                    e.Column.FieldName == "GB")
                {
                    e.Column.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                    e.Column.Format.FormatString = "n" + ObjEProject.RoundingPrice.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CalculatePositions(DataTable dt, string strField)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string strPosition = Convert.ToString(dr["PositionKZ"]).ToLower();
                    if (strPosition == "z" || strPosition == "zs")
                    {
                        dr[strField] = GetTotalValue(dt, dr, strField, strPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetTotalValue(DataTable dt, DataRow dr, string strField, string strPosition)
        {
            decimal TotalValue = 0;
            try
            {
                string strFromOZ = dr["surchargefrom"] == DBNull.Value ? "" : dr["surchargefrom"].ToString();
                string strToOZ = dr["surchargeto"] == DBNull.Value ? "" : dr["surchargeto"].ToString();
                decimal strPer = Convert.ToDecimal(dr["surchargePercentage"] == DBNull.Value ? 0 : dr["surchargePercentage"]);
                decimal strPerMO = Convert.ToDecimal(dr["surchargePercentage_MO"] == DBNull.Value ? 0 : dr["surchargePercentage_MO"]);

                DataRow[] FilteredFromRow = dt.Select("Position_OZ = '" + strFromOZ + "'");
                DataRow[] FilteredToRow = dt.Select("Position_OZ = '" + strToOZ + "'");

                int ifromValue = 0;
                int itoValue = 0;

                if (FilteredFromRow != null && FilteredFromRow.Count() > 0)
                    ifromValue = Convert.ToInt32(FilteredFromRow[0]["SNO"]);

                if (FilteredToRow != null && FilteredToRow.Count() > 0)
                    itoValue = Convert.ToInt32(FilteredToRow[0]["SNO"]);

                object Obj = null;
                decimal Sum = 0;
                if (strPosition == "z")
                {
                    object ObjMA = null;
                    object ObjMO = null;

                    ObjMA = dt.Compute("SUM(MAWithMulti)", "SNO >=" + ifromValue +
                       "And SNO <=" + itoValue + "And DetailKZ = 0 and (PositionKZ = 'N' OR PositionKZ = 'M' OR PositionKZ = 'P')");

                    ObjMO = dt.Compute("SUM(MOWithMulti)", "SNO >=" + ifromValue +
                       "And SNO <=" + itoValue + "And DetailKZ = 0 and (PositionKZ = 'N' OR PositionKZ = 'M' OR PositionKZ = 'P')");

                    decimal MAPrice = ObjMA == DBNull.Value ? 0 : Convert.ToDecimal(ObjMA);
                    decimal MOPrice = ObjMO == DBNull.Value ? 0 : Convert.ToDecimal(ObjMO);
                    decimal MaSurcharge = (MAPrice * strPer) / 100;
                    decimal MOSurcharge = (MOPrice * strPerMO) / 100;
                    TotalValue = MaSurcharge + MOSurcharge;
                }
                else
                {
                    Obj = dt.Compute("SUM(" + strField + ")", "SNO >=" + ifromValue +
                          "And SNO <=" + itoValue + "And DetailKZ = 0 AND (PositionKZ = 'N' OR PositionKZ = 'Z' OR PositionKZ = 'M' OR PositionKZ = 'P')");
                    Sum = Obj == DBNull.Value ? 0 : Convert.ToDecimal(Obj);
                    TotalValue = Sum;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return TotalValue.ToString("F2");
        }

        private void btnProjectSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utility.ValidateRequiredFields(RequiredFields) == false)
                    return;
                ParseProjectDetails();
                string strConfirmation = "";
                // Confirmation incase of project convert into order
                if (txtkommissionNumber.Text != string.Empty && txtkommissionNumber.ReadOnly == false)
                {
                    if (ObjEProject.ActualLvs > 0)
                    {
                        if (Utility._IsGermany == true)
                        {
                            strConfirmation = XtraMessageBox.Show("Möchten Sie das Projekt in eine Kommission wandeln?", "Bestätigung …!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        }
                        else
                        {
                            strConfirmation = XtraMessageBox.Show("Are you sure you want to convert this Project into Kommission?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        }
                    }
                    else
                    {
                        if (Utility._IsGermany == true)
                        {
                            throw new Exception("Keine LV Positionen.");
                        }
                        else
                        {
                            throw new Exception("No LV Positions to Order.");
                        }
                    }
                }
                else
                {
                    strConfirmation = "Yes";
                }

                if (strConfirmation.ToLower() == "yes")
                {
                    ObjBProject.SaveProjectDetails(ObjEProject);
                    if (!string.IsNullOrEmpty(ObjEProject.CommissionNumber))
                    {
                        btnProjectSave.Enabled = false;
                        DisalbeProjectControls();
                    }
                    if (Utility._IsGermany == true)
                    {
                       this.Text = ObjEProject.ProjectNumber;
                       frmOTTOPro.UpdateStatus("'" + ObjEProject.ProjectNumber + "'" + " Die Projektangabe wurden erfolgreich gespeichert");
                    }
                    else
                    {
                       this.Text = ObjEProject.ProjectNumber;
                       frmOTTOPro.UpdateStatus("'" + ObjEProject.ProjectNumber + "'" + " Project Details Saved Successfully");
                    }
                    BindPositionData();
                    if (ObjEProject.CommissionNumber != string.Empty)
                        txtkommissionNumber.Enabled = false;
                }
                else
                {
                    txtkommissionNumber.Text = string.Empty;
                }
                setMask();
                SetMaskForMaulties();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void DisalbeProjectControls()
        {
            txtMWST.Enabled = false;
            txtBauvorhaben.Enabled = false;
            txtKundeNo.Enabled = false;
            txtKundeName.Enabled = false;
            txtPlanner.Enabled = false;
            dtpProjectStartDate.Enabled = false;
            dtpProjectEndDate.Enabled = false;
            txtInternX.Enabled = false;
            txtInternS.Enabled = false;
            txtSubmitLocation.Enabled = false;
            dtpSubmitDate.Enabled = false;
            txtEstimatedLVs.Enabled = false;
            ddlRounding.Enabled = false;
            btnDiscount.Enabled = false;
            txtActualLVs.Enabled = false;
            chkLockHierarchy.Enabled = false;
            txtRemarks.Enabled = false;
            txtLVSprunge.Enabled = false;
            chkCumulated.Enabled = false;
        }

        private void btnSaveLVDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dxValidationProvider1.Validate() == false)
                {
                    return;
                }
                if (_IsNewMode == false)
                {
                    btnModify_Click(null, null);
                }
                if (cmbLVSection.Text == "NT" || cmbLVSection.Text == "NTM")
                {
                    if (Utility._IsGermany == true)
                    {
                        throw new Exception("Positionen mit NT oder NTM können nicht gespeichert werden");
                    }
                    else
                    {
                        throw new Exception("Cannot Save Positions With NT Or NTM");
                    }
                }
                if (cmbPositionKZ.Text != "H")
                {
                    if (!string.IsNullOrEmpty(txtPosition.Text))
                    {
                        if (Utility.ValidateRequiredFields(RequiredPositionFields) == false)
                            return;
                    }
                    if (!string.IsNullOrEmpty(txtPosition.Text))
                    {
                        if (Utility.ValidateRequiredFields(RequiredPositionFieldsforTitle) == false)
                            return;
                    }
                    if (string.IsNullOrEmpty(txtStufe1Short.Text))
                    {
                        if (Utility._IsGermany == true)
                            throw new Exception("Bitte geben Sie mindestens eine Stufe ein");
                        else
                            throw new Exception("Plesae Enter Atleast One Stufe");
                    }
                    if (cmbPositionKZ.Text == "Z" || cmbPositionKZ.Text == "ZS")
                    {
                        if (string.IsNullOrEmpty(txtSurchargeFrom.Text))
                            if (Utility._IsGermany == true)
                            {
                                throw new Exception("Diese Position kann nicht angelegt werden ohne Angabe fÃ¼r das VON und ZU.");
                            }
                            else
                            {
                                throw new Exception("Position Cannot be created with Empty From and To Fields");
                            }
                    }
                }
                if (string.IsNullOrEmpty(txtPosition.Text))
                    txtDetailKZ.Text = "0";
                if (string.IsNullOrEmpty(cmbPositionKZ.Text))
                    cmbPositionKZ.Text = "N";
                if (ObjEPosition == null)
                    ObjEPosition = new EPosition();
                ParsePositionDetails();
                if (ObjEPosition.PositionKZ.ToLower() == "h")
                {
                    if (tlPositions != null && tlPositions.Nodes.Count > 0 && tlPositions.FocusedNode != null && tlPositions.FocusedNode.ParentNode != null)
                    {
                        ObjEPosition.Parent_OZ = tlPositions.FocusedNode.ParentNode["Position_OZ"].ToString();
                    }
                    else
                    {
                        ObjEPosition.Parent_OZ = "";
                    }
                }
                int NewPositionID = ObjBPosition.SavePositionDetails(ObjEPosition, ObjEProject.LVRaster);
                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("'" + ObjEPosition.Position_OZ + "'" + " Vorgang abgeschlossen: Speichern der OZ");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("'" + ObjEPosition.Position_OZ + "'" + " OZ Saved Successfully");
                }

                BindPositionData();
                SetFocus(NewPositionID,tlPositions);
                if (chkCreateNew.Checked == true)
                {
                    btnNew_Click(null, null);
                }
                else
                {
                    EnableDisableLVAndCostDetails(false, false, false, false);
                    EnableDisableButtons(true, true, false, true, true);
                    tlPositions.OptionsBehavior.ReadOnly = false;

                    Color _Color = Color.FromArgb(0, 158, 224);
                    tlPositions.Appearance.HeaderPanel.BackColor = _Color;
                    LCGLVDetails.AppearanceGroup.BackColor = _Color;
                }
                txtStufe1Short_TextChanged(null, null);
                txtStufe2Short_TextChanged(null, null);
                txtStufe3Short_TextChanged(null, null);
                txtStufe4Short_TextChanged(null, null);
                tlPositions.BestFitColumns();
                if (cmbPositionKZ.Text == "H")
                {
                    tlPositions.MoveNext();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void barButtonItemAddSumPosition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            object tValue = tlPositions.FocusedNode.GetValue("Position_OZ");
            //  btnSaveLVDetails.PerformClick();
        }

        public void CostDetailsDefaultValues()
        {
            txtLPMe.Text = "0";
            txtMulti1ME.Text = "1";
            txtMulti1MO.Text = "1";
            txtMulti2ME.Text = "1";
            txtMulti2MO.Text = "1";
            txtMulti3ME.Text = "1";
            txtMulti3MO.Text = "1";
            txtMulti4ME.Text = "1";
            txtMulti4MO.Text = "1";
            txtMin.Text = "0";
            txtFaktor.Text = "1";
            txtSelbstkostenMultiME.Text = "1";
            txtSelbstkostenMultiMO.Text = "1";
            txtVerkaufspreisMultiME.Text = "1";
            txtVerkaufspreisMultiMO.Text = "1";
            txtStdSatz.Text = ObjEProject.InternX.ToString();
        }

        #region 'Textchanged events for cost details calculations'
        /// <summary>
        /// Text Changes Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtLPMe_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtLPMe.Text) && !string.IsNullOrEmpty(txtMulti1ME.Text))
                {
                    txtValue1ME.Text = RoundValue(GetValue(getDValue(txtLPMe.Text),
                        getDValue(txtMulti1ME.Text))).ToString();
                }
                CalculateGrundMultiME();
                CalculateEinkuafpreisME();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue1ME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMe.Text) && !string.IsNullOrEmpty(txtValue1ME.Text) && !string.IsNullOrEmpty(txtMulti2ME.Text))
                {
                    txtValue2ME.Text = RoundValue(GetValue(getDValue(txtLPMe.Text) +
                        getDValue(txtValue1ME.Text),
                        getDValue(txtMulti2ME.Text))).ToString();
                }
                CalculateGrundMultiME();
                CalculateGrundValueME();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue2ME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMe.Text) &&
                                !string.IsNullOrEmpty(txtValue1ME.Text) &&
                                !string.IsNullOrEmpty(txtValue2ME.Text) &&
                                !string.IsNullOrEmpty(txtMulti3ME.Text))
                {
                    txtValue3ME.Text = RoundValue(
                        GetValue(getDValue(txtLPMe.Text)
                        + getDValue(txtValue1ME.Text)
                        + getDValue(txtValue2ME.Text)
                        , getDValue(txtMulti3ME.Text))).ToString();
                }
                CalculateGrundMultiME();
                CalculateGrundValueME();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue3ME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMe.Text) &&
                !string.IsNullOrEmpty(txtValue1ME.Text) &&
                !string.IsNullOrEmpty(txtValue2ME.Text) &&
                !string.IsNullOrEmpty(txtValue3ME.Text))
                {
                    txtValue4ME.Text = RoundValue(GetValue(
                        getDValue(txtLPMe.Text) +
                        getDValue(txtValue1ME.Text) +
                        getDValue(txtValue2ME.Text) +
                        getDValue(txtValue3ME.Text),
                        getDValue(txtMulti4ME.Text))).ToString();
                }
                CalculateGrundMultiME();
                CalculateGrundValueME();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue4ME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateGrundMultiME();
                CalculateGrundValueME();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue5ME_TextChanged(object sender, EventArgs e)
        {
            CalculateGrundValueME();
        }

        private void txtEinkaufspreisME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEinkaufspreisME.Text) && !string.IsNullOrEmpty(txtSelbstkostenMultiME.Text))
                {
                    decimal dValue = getDValue(txtEinkaufspreisME.Text);
                    txtSelbstkostenValueME.Text =
                        RoundValue(dValue + GetValue(dValue,
                        getDValue(txtSelbstkostenMultiME.Text))).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtSelbstkostenValueME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSelbstkostenValueME.Text) && !string.IsNullOrEmpty(txtVerkaufspreisMultiME.Text))
                {
                    decimal dValue = getDValue(txtSelbstkostenValueME.Text);
                    decimal TotalDValue = RoundValue(dValue + GetValue(dValue,
                        getDValue(txtVerkaufspreisMultiME.Text)));
                    txtVerkaufspreisValueME.Text = TotalDValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtLPMO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMO.Text) && !string.IsNullOrEmpty(txtMulti1MO.Text))
                {
                    txtValue1MO.Text = RoundValue(GetValue(getDValue(txtLPMO.Text),
                        getDValue(txtMulti1MO.Text))).ToString();
                }
                CalculateGrundMultiMO();
                CalculateEinkuafpreisMO();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue1MO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMO.Text) && !string.IsNullOrEmpty(txtValue1MO.Text) && !string.IsNullOrEmpty(txtMulti2MO.Text))
                {
                    txtValue2MO.Text =
                        RoundValue(GetValue(
                        getDValue(txtLPMO.Text) +
                        getDValue(txtValue1MO.Text),
                        getDValue(txtMulti2MO.Text)
                        )).ToString();
                }
                CalculateGrundMultiMO();
                CalculateGrundValueMO();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue2MO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMO.Text)
                                && !string.IsNullOrEmpty(txtValue1MO.Text)
                                && !string.IsNullOrEmpty(txtValue2MO.Text)
                                && !string.IsNullOrEmpty(txtMulti3MO.Text))
                {
                    txtValue3MO.Text =
                        RoundValue(GetValue(
                        getDValue(txtLPMO.Text) +
                        getDValue(txtValue1MO.Text) +
                        getDValue(txtValue2MO.Text),
                        getDValue(txtMulti3MO.Text)
                        )).ToString();
                }
                CalculateGrundMultiMO();
                CalculateGrundValueMO();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue3MO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMO.Text)
                                && !string.IsNullOrEmpty(txtValue1MO.Text)
                                && !string.IsNullOrEmpty(txtValue2MO.Text)
                                && !string.IsNullOrEmpty(txtValue3MO.Text)
                                && !string.IsNullOrEmpty(txtMulti4MO.Text))
                {
                    txtValue4MO.Text =
                        RoundValue(GetValue(
                        getDValue(txtLPMO.Text) +
                        getDValue(txtValue1MO.Text) +
                        getDValue(txtValue2MO.Text) +
                        getDValue(txtValue3MO.Text),
                        getDValue(txtMulti4MO.Text)
                        )).ToString();
                }
                CalculateGrundMultiMO();
                CalculateGrundValueMO();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue4MO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateGrundMultiMO();
                CalculateGrundValueMO();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtValue5MO_TextChanged(object sender, EventArgs e)
        {
            CalculateGrundValueMO();
        }

        private void txtEinkaufspreisMO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEinkaufspreisMO.Text) && !string.IsNullOrEmpty(txtSelbstkostenMultiMO.Text))
                {
                    decimal dValue = getDValue(txtEinkaufspreisMO.Text);
                    txtSelbstkostenValueMO.Text =
                        RoundValue(dValue + GetValue(dValue,
                        getDValue(txtSelbstkostenMultiMO.Text))).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtSelbstkostenValueMO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSelbstkostenValueMO.Text) && !string.IsNullOrEmpty(txtVerkaufspreisMultiMO.Text))
                {
                    decimal dValue = getDValue(txtSelbstkostenValueMO.Text);
                    decimal TotalDValue = RoundValue(dValue + GetValue(dValue,
                        getDValue(txtVerkaufspreisMultiMO.Text)));
                    txtVerkaufspreisValueMO.Text = TotalDValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtGrandTotalME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtGrandTotalME.Text) && !string.IsNullOrEmpty(txtGrandTotalMO.Text))
                {
                    txtFinalGB.Text =
                        RoundValue((getDValue(txtGrandTotalME.Text) + getDValue(txtGrandTotalMO.Text)) * getDValue(txtMenge.Text)).ToString();
                }
                else
                    txtFinalGB.Text = "0";
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHours.Text = RoundValue(getDValue(txtMin.Text)
                    / Convert.ToDecimal(60)).ToString();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtStdSatz_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtHours.Text) && !string.IsNullOrEmpty(txtFaktor.Text) && !string.IsNullOrEmpty(txtStdSatz.Text))
                {
                    txtLPMO.Text = RoundValue(
                        getDValue(txtHours.Text) *
                        getDValue(txtFaktor.Text) *
                        getDValue(txtStdSatz.Text)
                        ).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtGrundMultiME1_TextChanged(object sender, EventArgs e)
        {
            CalculateEinkuafpreisME();
        }

        private void txtGrundMultiMO1_TextChanged(object sender, EventArgs e)
        {
            CalculateEinkuafpreisMO();
        }

        private void CalculateGrundMultiME()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMulti1ME.Text) &&
                                                !string.IsNullOrEmpty(txtMulti2ME.Text) &&
                                                !string.IsNullOrEmpty(txtMulti3ME.Text) &&
                                                !string.IsNullOrEmpty(txtMulti4ME.Text)
                                                )
                {
                    decimal GrundMulti = Math.Round(
                        getDValue(txtMulti1ME.Text) *
                        getDValue(txtMulti2ME.Text) *
                        getDValue(txtMulti3ME.Text) *
                        getDValue(txtMulti4ME.Text),3);
                    txtGrundMultiME.Text = GrundMulti.ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void CalculateGrundValueME()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValue1ME.Text) &&
                                !string.IsNullOrEmpty(txtValue2ME.Text) &&
                                !string.IsNullOrEmpty(txtValue3ME.Text) &&
                                !string.IsNullOrEmpty(txtValue4ME.Text)
                                )
                {
                    decimal GrundMulti = RoundValue(
                        getDValue(txtValue1ME.Text) +
                        getDValue(txtValue2ME.Text) +
                        getDValue(txtValue3ME.Text) +
                        getDValue(txtValue4ME.Text)
                        );
                    txtGrundValueME.Text = GrundMulti.ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void CalculateGrundMultiMO()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMulti1MO.Text) &&
                                !string.IsNullOrEmpty(txtMulti2MO.Text) &&
                                !string.IsNullOrEmpty(txtMulti3MO.Text) &&
                                !string.IsNullOrEmpty(txtMulti4MO.Text)
                                )
                {
                    decimal GrundMulti = Math.Round(
                        getDValue(txtMulti1MO.Text) *
                        getDValue(txtMulti2MO.Text) *
                        getDValue(txtMulti3MO.Text) *
                        getDValue(txtMulti4MO.Text),3);
                    txtGrundMultiMO.Text = GrundMulti.ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void CalculateGrundValueMO()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValue1MO.Text) &&
                                !string.IsNullOrEmpty(txtValue2MO.Text) &&
                                !string.IsNullOrEmpty(txtValue3MO.Text) &&
                                !string.IsNullOrEmpty(txtValue4MO.Text)
                                )
                {
                    decimal GrundMulti = RoundValue(
                        getDValue(txtValue1MO.Text) +
                        getDValue(txtValue2MO.Text) +
                        getDValue(txtValue3MO.Text) +
                        getDValue(txtValue4MO.Text)
                        );
                    txtGrundValueMO.Text = GrundMulti.ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void CalculateEinkuafpreisME()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMe.Text) && !string.IsNullOrEmpty(txtGrundMultiME.Text))
                {
                    decimal LPMe = getDValue(txtLPMe.Text);
                    txtEinkaufspreisME.Text = RoundValue(
                        LPMe
                        + GetValue(LPMe, getDValue(txtGrundMultiME.Text))
                        ).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void CalculateEinkuafpreisMO()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLPMO.Text) && !string.IsNullOrEmpty(txtGrundMultiMO.Text))
                {
                    decimal LPMe = getDValue(txtLPMO.Text);
                    txtEinkaufspreisMO.Text = RoundValue(
                        LPMe
                        + GetValue(LPMe, getDValue(txtGrundMultiMO.Text))
                        ).ToString();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private decimal GetValue(decimal dValue, decimal dMulti)
        {
            decimal dreturnvalue = 0;
            try
            {
                dreturnvalue = (dMulti - 1) * dValue;

            }
            catch (Exception ex)
            {
                throw;
            }
            return dreturnvalue;
        }

        private decimal getDValue(string strValue)
        {
            decimal dValue = 0;
            try
            {
                if (!decimal.TryParse(strValue, out dValue))
                {
                    //throw new Exception("Invalid Value Entered in");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dValue;
        }

        private decimal RoundValue(decimal dValue)
        {
            try
            {
                return Math.Round(dValue, ObjEProject.RoundingPrice);
            }
            catch (Exception ex)
            {
                if (Utility._IsGermany == true)
                {
                    throw new Exception("Fehler bei der Rundungsoperation");
                }
                else
                {
                    throw new Exception("Error in Rounding the Value");
                }
            }
        }

        private void CalculateEP()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValue1ME.Text) &&
                               !string.IsNullOrEmpty(txtValue2ME.Text) &&
                               !string.IsNullOrEmpty(txtValue3ME.Text) &&
                               !string.IsNullOrEmpty(txtValue4ME.Text)
                               )
                {
                    decimal EP = RoundValue(
                        getDValue(txtVerkaufspreisValueME.Text) +
                        getDValue(txtVerkaufspreisValueMO.Text)
                        );
                    txtEP.Text = EP.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        private void tcProjectDetails_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (tcProjectDetails.SelectedTabPage == null)
                {
                    this.Close();
                    return;
                }

                if (tcProjectDetails.SelectedTabPage.Name == "tbLVDetails")
                {
                    BindPositionData();
                    FormatLVFields();
                    setMask();
                    IntializeLVPositions();
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbProjectDetails")
                {
                    FormatLVFields();
                    setMask();
                    if (tlPositions.Nodes.Count > 0)
                    {
                        txtkommissionNumber.ReadOnly = false;
                        ddlRaster.Enabled = false;
                    }
                    else
                    {
                        ddlRaster.Enabled = true;
                    }
                    ObjBProject.GetProjectDetails(ObjEProject);
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbBulkProcess")
                {
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbMulti5")
                {
                    //if (ObjEProject.ProjectID > 0)
                    //{
                    //    if (objBGAEB == null)
                    //        objBGAEB = new BGAEB();
                    //    DataTable dtLVSection = new DataTable();
                    //    cmbLVSectionFilter.Properties.Items.Clear();
                    //    dtLVSection = objBGAEB.GetLVSection(ObjEProject.ProjectID);
                    //    foreach (DataRow dr in dtLVSection.Rows)
                    //        cmbLVSectionFilter.Properties.Items.Add(dr["LVSection"]);
                    //    cmbLVSectionFilter.SetEditValue("HA");                        
                    //}
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbMulti6")
                {
                    //if (objBGAEB == null)
                    //    objBGAEB = new BGAEB();
                    //DataTable dtLVSection = new DataTable();
                    //cmbMulti6LVFilter.Properties.Items.Clear();
                    //gcMulti6.DataSource = null;
                    //dtLVSection = objBGAEB.GetLVSection(ObjEProject.ProjectID);
                    //foreach (DataRow dr in dtLVSection.Rows)
                    //    cmbMulti6LVFilter.Properties.Items.Add(dr["LVSection"]);
                    //cmbMulti6LVFilter.SetEditValue("HA");
                    //cmbType.Text = "Montage";
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbOmlage")
                {
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkCreateNew.Checked == false)
                {
                    Color _Color = Color.FromArgb(255, 135, 0);
                    tlPositions.Appearance.HeaderPanel.BackColor = _Color;
                    LCGLVDetails.AppearanceGroup.BackColor = _Color;
                }
                if (Utility.LVSectionEditAccess == "7")
                {
                    if (Utility.LVDetailsAccess != "7")
                    {
                        layoutControl3.Enabled = true;
                        btnNew.Enabled = true;
                        chkCreateNew.Enabled = true;
                    }
                    if (Utility.CalcAccess != "7")
                    {
                        layoutControl6.Enabled = true;
                        tlPositions.OptionsBehavior.Editable = true;
                    }
                    btnSaveLVDetails.Enabled = true;
                    btnCancel.Enabled = true;
                }
                _IsAddhoc = false;
                CreateNewPosition();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void CreateNewPosition(string strPositiontype = "")
        {
            try
            {
                ObjEPosition.PositionID = -1;
                if (strPositiontype == string.Empty)
                {
                    chkCreateNew.Enabled = true;
                    txtMo.Text = "X";
                    txtMa.Text = "X";
                    _IsNewMode = true;
                    EnableDisableLVAndCostDetails(true, true, true, false);
                    CostDetailsDefaultValues();
                    EnableDisableButtons(true, false, true, false, false);
                    bool _isSuggest = true;
                    if (RequiredPositionFieldsforTitle != null && RequiredPositionFieldsforTitle.Count > 0)
                    {
                        foreach (Control c in RequiredPositionFieldsforTitle)
                        {
                            if (c is TextEdit && string.IsNullOrEmpty(c.Text))
                            {
                                _isSuggest = false;
                                continue;
                            }
                        }
                    }
                    if (_isSuggest)
                        txtPosition.Text = SuggestOZ(PrepareOZ());
                    _DocuwareLink1 = string.Empty;
                    _DocuwareLink2 = string.Empty;
                    _DocuwareLink3 = string.Empty;
                    txtShortDescription.Text = "";
                    txtPreisText.Text = "";
                    txtFabrikate.Text = "";
                    txtLiefrantMA.Text = "";
                    txtType.Text = "";
                    cmbME.Text = "";
                    cmbPositionKZ.Text = "N";
                    txtMenge.Text = "1";
                    txtLVPosition.Text = string.Empty;
                    FormatLVFields();
                    btnLongDescription.Enabled = true;
                    tlPositions.OptionsBehavior.ReadOnly = true;
                    LongDescription = string.Empty;
                    cmbPositionKZ.Enabled = true;
                    cmbPositionKZ_SelectedValueChanged(null, null);
                    if (!_IsAddhoc)
                    {
                        iSNO = -1;
                    }
                    if (!string.IsNullOrEmpty(ObjEProject.CommissionNumber))
                    {
                        cmbLVStatus.Text = "B";
                    }
                }
                else if (strPositiontype.ToLower() == "h")
                {
                    chkCreateNew.Checked = false;
                    chkCreateNew.Enabled = false;
                    txtMo.Text = "";
                    txtMa.Text = "";
                    _IsNewMode = true;
                    EnableDisableLVAndCostDetails(true, true, true, false);
                    CostDetailsDefaultValues();
                    EnableDisableButtons(true, false, true, false, false);
                    _DocuwareLink1 = string.Empty;
                    _DocuwareLink2 = string.Empty;
                    _DocuwareLink3 = string.Empty;
                    txtShortDescription.Text = "";
                    txtPreisText.Text = "";
                    txtFabrikate.Text = "";
                    txtLiefrantMA.Text = "";
                    txtType.Text = "";
                    cmbME.Text = "";
                    cmbPositionKZ.Text = "H";
                    txtMenge.Text = "";
                    txtLVPosition.Text = string.Empty;
                    txtStufe1Short.Text = "";
                    txtStufe2Short.Text = "";
                    txtStufe3Short.Text = "";
                    txtStufe4Short.Text = "";
                    txtPosition.Text = "";
                    FormatLVFields();
                    btnLongDescription.Enabled = true;
                    tlPositions.OptionsBehavior.ReadOnly = true;
                    LongDescription = string.Empty;
                    cmbPositionKZ.Enabled = true;
                    cmbPositionKZ_SelectedValueChanged(null, null);
                    if (tlPositions != null && tlPositions.FocusedNode != null)
                    {
                        string strSNO = tlPositions.FocusedNode["SNO"].ToString();
                        if (!int.TryParse(strSNO, out iSNO))
                        {
                            iSNO = -1;
                        }
                        else
                        {
                            iSNO = iSNO - 1;
                        }
                    }
                }
                else if (strPositiontype.ToLower() == "n")
                {
                    chkCreateNew.Enabled = true;
                    txtMo.Text = "X";
                    txtMa.Text = "X";
                    _IsNewMode = true;
                    EnableDisableLVAndCostDetails(true, true, true, false);
                    CostDetailsDefaultValues();
                    EnableDisableButtons(true, false, true, false, false);
                    bool _isSuggest = true;
                    if (RequiredPositionFieldsforTitle != null && RequiredPositionFieldsforTitle.Count > 0)
                    {
                        foreach (Control c in RequiredPositionFieldsforTitle)
                        {
                            if (c is TextEdit && string.IsNullOrEmpty(c.Text))
                            {
                                _isSuggest = false;
                                continue;
                            }
                        }
                    }
                    if (_isSuggest)
                        txtPosition.Text = SuggestOZ(PrepareOZ());
                    _DocuwareLink1 = string.Empty;
                    _DocuwareLink2 = string.Empty;
                    _DocuwareLink3 = string.Empty;
                    txtShortDescription.Text = "";
                    txtPreisText.Text = "";
                    txtFabrikate.Text = "";
                    txtLiefrantMA.Text = "";
                    txtType.Text = "";
                    cmbME.Text = "";
                    cmbPositionKZ.Text = "N";
                    txtMenge.Text = "1";
                    txtLVPosition.Text = string.Empty;
                    FormatLVFields();
                    btnLongDescription.Enabled = true;
                    tlPositions.OptionsBehavior.ReadOnly = true;
                    LongDescription = string.Empty;
                    cmbPositionKZ.Enabled = true;
                    cmbPositionKZ_SelectedValueChanged(null, null);
                    if (tlPositions != null && tlPositions.FocusedNode != null)
                    {
                        string strSNO = tlPositions.FocusedNode["SNO"].ToString();
                        if (!int.TryParse(strSNO, out iSNO))
                        {
                            iSNO = -1;
                        }
                        else
                        {
                            iSNO = iSNO - 1;
                        }
                    }
                }
                chkVerkaufspreisME.Checked = false;
                chkVerkaufspreisMO.Checked = false;
                txtWG.Text = string.Empty;
                txtWA.Text = string.Empty;
                txtWI.Text = string.Empty;
                txtDim1.Text = string.Empty;
                txtDim2.Text = string.Empty;
                txtDim3.Text = string.Empty;
                txtMin.Text = "0";
                txtLPMe.Text = "0";
                txtDetailKZ.Text = "0";
                txtEP.Text = "0";
                txtFinalGB.Text = "0";
                if (Utility.LVsectionAddAccess == "7")
                    cmbLVSection.Text = "HA";
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

            try
            {
                int iValue = 0;
                if (tlPositions.FocusedNode != null
                    && tlPositions.FocusedNode["PositionID"] != null
                    && Int32.TryParse(tlPositions.FocusedNode["PositionID"].ToString(), out iValue)
                    )
                {
                    ObjEPosition.PositionID = iValue;
                    if (string.IsNullOrEmpty(ObjEProject.CommissionNumber))
                        cmbLVSection.Enabled = false;
                }
                else if (_IsEditMode)
                {
                    if (Utility._IsGermany == true)
                        XtraMessageBox.Show("Bitte speichern Sie die Änderungen", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        XtraMessageBox.Show("Please save the changes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            EnableDisableLVAndCostDetails(true, true, false, true);
            EnableDisableButtons(false, true, true, true, true);
        }

        private void EnableDisableLVAndCostDetails(bool Lcvalue, bool LcCostvalue, bool _IsNew, bool _IsEdit)
        {
            //  lcLVDetails.Enabled = Lcvalue;
            // lcCostDetails.Enabled = LcCostvalue;
            _IsNewMode = _IsNew;
            _IsEditMode = _IsEdit;
        }

        private void EnableDisableButtons(bool tnew, bool tmodify, bool tsave, bool tnext, bool tprev)
        {
            // btnNew.Enabled = tnew;
            btnModify.Enabled = tmodify;
            // btnSaveLVDetails.Enabled = tsave;
            btnNext.Enabled = tnext;
            btnPrevious.Enabled = tprev;
        }

        private void txtLPMe_Leave(object sender, EventArgs e)
        {
            TextEdit textbox = (TextEdit)sender;
            decimal dValue = 0;
            if (textbox.Text == string.Empty || decimal.TryParse(textbox.Text, out dValue))
            {
                if (dValue == 0)
                {
                    textbox.Text = RoundValue(1).ToString();
                }
            }
        }

        private void setMask()
        {
            string strMask = "n" + ObjEProject.RoundingPrice.ToString();
            if (txtLPMe.Properties.Mask.EditMask != strMask)
            {
                txtLPMe.Properties.Mask.EditMask = strMask;
                txtLPMO.Properties.Mask.EditMask = strMask;
                txtValue1ME.Properties.Mask.EditMask = strMask;
                txtValue2ME.Properties.Mask.EditMask = strMask;
                txtValue3ME.Properties.Mask.EditMask = strMask;
                txtValue4ME.Properties.Mask.EditMask = strMask;
                txtValue1MO.Properties.Mask.EditMask = strMask;
                txtValue2MO.Properties.Mask.EditMask = strMask;
                txtValue3MO.Properties.Mask.EditMask = strMask;
                txtValue4MO.Properties.Mask.EditMask = strMask;
                txtGrundValueME.Properties.Mask.EditMask = strMask;
                txtGrundValueMO.Properties.Mask.EditMask = strMask;
                txtEinkaufspreisME.Properties.Mask.EditMask = strMask;
                txtSelbstkostenValueME.Properties.Mask.EditMask = strMask;
                txtVerkaufspreisValueME.Properties.Mask.EditMask = strMask;
                txtEinkaufspreisMO.Properties.Mask.EditMask = strMask;
                txtSelbstkostenValueMO.Properties.Mask.EditMask = strMask;
                txtVerkaufspreisValueMO.Properties.Mask.EditMask = strMask;
                txtGrandTotalME.Properties.Mask.EditMask = strMask;
                txtGrandTotalMO.Properties.Mask.EditMask = strMask;
                txtFinalGB.Properties.Mask.EditMask = strMask;
                txtEP.Properties.Mask.EditMask = strMask;
            }
        }

        private void SetMaskForMaulties()
        {
            rpiMulti1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            rpiMulti1.Mask.EditMask = @"\d{1,2}(\R.\d{0,3})";
            rpiMulti1.Mask.UseMaskAsDisplayFormat = true;
        }

        private void txtMo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMo.Text.ToLower() == "s")
                    txtStdSatz.Text = RoundValue(ObjEProject.InternS).ToString();
                else if (txtMo.Text.ToLower() == "x")
                    txtStdSatz.Text = RoundValue(ObjEProject.InternX).ToString();
                else
                    txtStdSatz.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(null, null);
            }
        }

        private void FormatFieldsForSum()
        {
            txtWG.Enabled = false;
            txtWA.Enabled = false;
            txtWI.Enabled = false;
            txtMenge.Enabled = false;
            txtFabrikate.Enabled = false;
            txtLiefrantMA.Enabled = false;
            txtType.Enabled = false;
            txtDetailKZ.Enabled = false;
            //cmbLVSection.Enabled = false;
            cmbME.Enabled = false;
            txtWG.Text = string.Empty;
            txtWA.Text = string.Empty;
            txtWI.Text = string.Empty;
            txtMenge.Text = string.Empty;
            txtFabrikate.Text = string.Empty;
            txtLiefrantMA.Text = "";
            txtType.Text = string.Empty;
            txtDetailKZ.Text = "0";
            cmbLVSection.Text = string.Empty;
            cmbME.Text = string.Empty;
        }

        private void FormatFieldsForNormal()
        {
            txtPosition.Enabled = true;
            txtWG.Enabled = true;
            txtWA.Enabled = true;
            txtWI.Enabled = true;
            txtMenge.Enabled = true;
            txtFabrikate.Enabled = true;
            txtLiefrantMA.Enabled = true;
            txtType.Enabled = true;
            txtDetailKZ.Enabled = true;
            //cmbLVSection.Enabled = true;
            cmbME.Enabled = true;
            // txtMenge.Text = "1";
        }

        private string PrepareOZ()
        {
            try
            {
                StringBuilder strParentOZ = new StringBuilder();
                //Checking stufe existence
                if (!string.IsNullOrEmpty(txtStufe1Short.Text.Trim())) //1
                {
                    strParentOZ.Append(txtStufe1Short.Text + ".");//1
                    if (!string.IsNullOrEmpty(txtStufe2Short.Text.Trim()))//1
                    {
                        strParentOZ.Append(txtStufe2Short.Text + ".");//1.1
                        if (!string.IsNullOrEmpty(txtStufe3Short.Text.Trim()))//1
                        {
                            strParentOZ.Append(txtStufe3Short.Text + ".");//1.1.1
                            if (!string.IsNullOrEmpty(txtStufe4Short.Text.Trim()))//1
                                strParentOZ.Append(txtStufe4Short.Text + ".");//1.1.1.1
                        }
                    }
                }
                return Utility.PrepareOZ(strParentOZ.ToString(), ObjEProject.LVRaster);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string SuggestOZ(string strParent)
        {
            string strNewOZ = string.Empty;
            try
            {
                if (ObjEPosition.dsPositionList != null)
                {
                    DataTable dt = ObjEPosition.dsPositionList.Tables[0];
                    DataRow[] tPosition_Id = dt.Select("Position_OZ='" + strParent + "'");
                    if (tPosition_Id != null && tPosition_Id.Count() > 0)
                    {
                        string tResult = tPosition_Id[0]["PositionID"] == DBNull.Value ? "" : tPosition_Id[0]["PositionID"].ToString();
                        if (!string.IsNullOrEmpty(tResult))
                        {
                            object Max_Identity = dt.Compute("MAX(SNO)", "Parent_OZ =" + tResult);
                            if (Max_Identity != DBNull.Value)
                            {
                                string MaxValue = dt.Compute("MIN(Position_OZ)", "SNO =" + Max_Identity) == DBNull.Value ? "" : dt.Compute("MIN(Position_OZ)", "SNO =" + Max_Identity).ToString();
                                string[] Raster = ObjEProject.LVRaster.Split('.');
                                string[] NewOZ = MaxValue.Split('.');
                                if (Raster != null && NewOZ != null && NewOZ.Count() > 0)
                                {
                                    int iValue = 0;
                                    if (Raster.Count() == NewOZ.Count())
                                    {
                                        if (int.TryParse(NewOZ[NewOZ.Count() - 2], out iValue))
                                        {
                                            strNewOZ = (((iValue / ObjEProject.LVSprunge) * ObjEProject.LVSprunge) + ObjEProject.LVSprunge).ToString();
                                        }
                                    }
                                    else
                                    {
                                        if (int.TryParse(NewOZ[NewOZ.Count() - 1], out iValue))
                                        {
                                            strNewOZ = (((iValue / ObjEProject.LVSprunge) * ObjEProject.LVSprunge) + ObjEProject.LVSprunge).ToString();
                                        }
                                    }
                                }
                                else
                                    strNewOZ = ObjEProject.LVSprunge.ToString();
                            }
                            else
                            {
                                string[] strArr = ObjEProject.LVRaster.Split('.');
                                int Count = strArr.Count();
                                if (strArr != null)
                                {
                                    if (Count > 3 && string.IsNullOrEmpty(txtStufe2Short.Text))//99.99.1111.9
                                        strNewOZ = "";
                                    else if (Count > 4 && string.IsNullOrEmpty(txtStufe3Short.Text))//99.99.99.1111.9
                                        strNewOZ = "";
                                    else if (Count > 5 && string.IsNullOrEmpty(txtStufe4Short.Text))//99.99.99.99.1111.9
                                        strNewOZ = "";
                                    else
                                        strNewOZ = ObjEProject.LVSprunge.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strNewOZ;
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            IsControlChanged();
        }

        private void IsControlChanged()
        {
            foreach (Control c in this.Controls)
            {
                c.TextChanged += new EventHandler(c_ControlChanged);
            }

        }

        void c_ControlChanged(object sender, EventArgs e)
        {
            // _NeedConfirm = true;
        }

        private void txtMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().ToLower() == "s" || e.KeyChar.ToString().ToLower() == "x" || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmProject_Shown(object sender, EventArgs e)
        {
            dtpProjectStartDate.Properties.MinValue = DateTime.Today;
            dtpProjectEndDate.Properties.MinValue = DateTime.Today;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcProjectDetails.SelectedTabPage == tbLVDetails)
                {
                    EnableDisableLVAndCostDetails(false, false, false, false);
                    EnableDisableButtons(true, true, false, true, true);
                    _IsEditMode = false;
                    chkCreateNew.Checked = false;
                    chkCreateNew.Enabled = false;
                    tlPositions_FocusedNodeChanged(null, null);
                    tlPositions.OptionsBehavior.ReadOnly = false;
                    Color _Color = Color.FromArgb(0, 158, 224);
                    tlPositions.Appearance.HeaderPanel.BackColor = _Color;
                    LCGLVDetails.AppearanceGroup.BackColor = _Color;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtLVSprunge_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void txtLVSprunge_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLVSprunge.Text))
                {
                    if (Convert.ToInt32(txtLVSprunge.Text) == 0)
                    {
                        txtLVSprunge.Text = "10";
                    }
                }
                else
                {
                    txtLVSprunge.Text = "10";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void txtSurchargeFrom_Leave(object sender, EventArgs e)
        {
            TextEdit textbox = (TextEdit)sender;
            try
            {
                DataView dvPosition = ObjEPosition.dsPositionList.Tables[0].DefaultView;
                if(cmbPositionKZ.Text == "Z")
                    dvPosition.RowFilter = "Position_OZ = '" + textbox.Text + "' and (PositionKZ = 'N' OR PositionKZ = 'M')";
                else if(cmbPositionKZ.Text == "ZS")
                    dvPosition.RowFilter = "Position_OZ = '" + textbox.Text + "' and (PositionKZ = 'N' OR PositionKZ = 'M' OR PositionKZ = 'Z')";

                DataTable dtTemp = dvPosition.ToTable();
                if (dtTemp != null && dtTemp.Rows.Count < 1)
                {
                    if (textbox.Text == string.Empty)
                    {
                        if (Utility._IsGermany == true)
                            XtraMessageBox.Show(textbox.Tag.ToString() + " Fehlende Angabe", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show(textbox.Tag.ToString() + " Should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Utility._IsGermany == true)
                            XtraMessageBox.Show("Die gewählte " + textbox.Tag.ToString() + " existiert nicht", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("Selected " + textbox.Tag.ToString() + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (_IsNewMode)
                    {
                        if (textbox == txtSurchargeFrom)
                            textbox.Text = FromOZ(PrepareOZ(), cmbPositionKZ.Text);
                        else
                            textbox.Text = ToOZ(PrepareOZ(), cmbPositionKZ.Text);
                    }
                    else
                    {
                        tlPositions_FocusedNodeChanged(null, null);
                    }
                    textbox.Select(0, 0);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }

        }

        private string FromOZ(string strParentOZ, string strPositionKZ)
        {
            string strFromOZ = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = ObjEPosition.dsPositionList.Tables[0].Copy();
                DataRow[] tPosition_Id = dt.Select("Position_OZ='" + strParentOZ + "'");
                string tResult = tPosition_Id[0]["PositionID"] == DBNull.Value ? "" : tPosition_Id[0]["PositionID"].ToString();
                object Min_Identity = null;
                string MinValue = string.Empty;

                if (strPositionKZ.ToLower() == "zs")
                    Min_Identity = dt.Compute("MIN(SNO)", "Parent_OZ =" + tResult + "And (PositionKZ = 'N' OR PositionKZ = 'M' OR PositionKZ = 'Z' OR PositionKZ = 'P')");
                else if (strPositionKZ.ToLower() == "z")
                    Min_Identity = dt.Compute("MIN(SNO)", "Parent_OZ =" + tResult + "And (PositionKZ = 'N' OR PositionKZ = 'M' OR PositionKZ = 'P')");

                if (Min_Identity != DBNull.Value)
                {
                    strFromOZ = Convert.ToString(dt.Compute("MIN(Position_OZ)", "SNO =" + Min_Identity));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strFromOZ;
        }

        private string ToOZ(string strParentOZ, string strPositionKZ)
        {
            string strToOZ = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = ObjEPosition.dsPositionList.Tables[0];
                DataRow[] tPosition_Id = dt.Select("Position_OZ='" + strParentOZ + "'");
                string tResult = tPosition_Id[0]["PositionID"] == DBNull.Value ? "" : tPosition_Id[0]["PositionID"].ToString();
                object Max_Identity = null;

                if (strPositionKZ.ToLower() == "zs")
                    Max_Identity = dt.Compute("MAX(SNO)", "Parent_OZ =" + tResult + "And (PositionKZ = 'N' OR PositionKZ = 'M' OR PositionKZ = 'Z' OR PositionKZ = 'P')");
                else if (strPositionKZ.ToLower() == "z")
                    Max_Identity = dt.Compute("MAX(SNO)", "Parent_OZ =" + tResult + "And (PositionKZ = 'N' OR PositionKZ = 'M' OR PositionKZ = 'P')");

                if (Max_Identity != DBNull.Value)
                {
                    strToOZ = Convert.ToString(dt.Compute("MIN(Position_OZ)", "SNO =" + Max_Identity));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strToOZ;
        }

        private void btnDocuwareLink_Click(object sender, EventArgs e)
        {
            try
            {
                frmDocuwareLink Obj = new frmDocuwareLink();
                Obj.DocuwareLink1 = _DocuwareLink1;
                Obj.DocuwareLink2 = _DocuwareLink2;
                Obj.DocuwareLink3 = _DocuwareLink3;
                Obj.ShowDialog();
                _DocuwareLink1 = Obj.DocuwareLink1;
                _DocuwareLink2 = Obj.DocuwareLink2;
                _DocuwareLink3 = Obj.DocuwareLink3;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnAddPositionKZ_Click(object sender, EventArgs e)
        {
            try
            {
                string strLVSecction = cmbLVSection.Text;
                if (strLVSecction.ToLower() == "nt" || strLVSecction.ToLower() == "ntm")
                {
                    frmTextDialog Obj = new frmTextDialog();
                    Obj.ShowInTaskbar = false;
                    Obj.NewLVSection = strLVSecction + ObjBPosition.GetNewLVSection(cmbLVSection.Text, ObjEProject.ProjectID);
                    Obj.ShowDialog();
                    DataRow[] tPosition_Id = ObjEProject.dtLVSection.Select("LVSectionName='" + Obj.NewLVSection + "'");
                    if (tPosition_Id.Count() > 0)
                    {
                        if (Utility._IsGermany == true)
                        {
                            throw new Exception("Die gewählte LV Sektion existiert bereits");
                        }
                        else
                        {
                            throw new Exception("Selected LV Section Already Exist");
                        }

                    }
                    else if (!string.IsNullOrEmpty(Obj.NewLVSection.Trim()) && Obj.IsSave)
                    {
                        ObjBPosition.InsertNewLVSection(Obj.NewLVSection, ProjectID);
                        ObjEProject.dtLVSection.Rows.Add("0", Obj.NewLVSection);
                        if (ObjEProject.dtLVSection != null && ObjEProject.dtLVSection.Rows.Count > 0)
                        {
                            cmbLVSection.DataSource = ObjEProject.dtLVSection;
                            cmbLVSection.DisplayMember = "LVSectionName";
                            cmbLVSection.ValueMember = "LVSectionID";
                        }
                        cmbLVSection.Text = Obj.NewLVSection;
                    }
                }
                else
                {
                    if (Utility._IsGermany == true)
                        throw new Exception("Bitte wählen Sie NT oder NTM");
                    else
                    {
                        throw new Exception("Please Select NT or NTM");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtVerkaufspreisValueME_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMenge.Text) && !string.IsNullOrEmpty(txtVerkaufspreisValueME.Text))
                {
                    txtGrandTotalME.Text =
                        RoundValue(getDValue(txtVerkaufspreisValueME.Text)).ToString();
                    CalculateEP();
                }
                else
                {
                    txtGrandTotalME.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtVerkaufspreisValueMO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMenge.Text) && !string.IsNullOrEmpty(txtVerkaufspreisValueMO.Text))
                {
                    txtGrandTotalMO.Text =
                        RoundValue(getDValue(txtVerkaufspreisValueMO.Text)).ToString();
                    CalculateEP();
                }
                else
                {
                    txtGrandTotalMO.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);

            }
        }

        private void txtMenge_TextChanged(object sender, EventArgs e)
        {
            txtGrandTotalME_TextChanged(null, null);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                btnModify_Click(null, null);
                if (_IsEditMode)
                {
                    if (!ObjEProject.IsFinalInvoice)
                        btnSaveLVDetails_Click(null, null);
                    tlPositions.MovePrev();
                    btnModify_Click(null, null);
                }
                else if (!_IsNewMode)
                {
                    tlPositions.MovePrev();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnModify_Click(null, null);
                if (_IsEditMode)
                {
                    if (!ObjEProject.IsFinalInvoice)
                        btnSaveLVDetails_Click(null, null);
                    tlPositions.MoveNext();
                    btnModify_Click(null, null);
                }
                else if (!_IsNewMode)
                {
                    tlPositions.MoveNext();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void splitContainerControl1_SplitGroupPanelCollapsed(object sender, SplitGroupPanelCollapsedEventArgs e)
        {
            // splitContainerControl1.Panel1.Hide();
        }

        private void txtMenge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMulti1ME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void FormatLVFields()
        {
            try
            {
                if (string.IsNullOrEmpty(ObjEProject.CommissionNumber))
                {
                    //cmbLVSection.Enabled = false;
                    cmbLVStatus.Enabled = false;
                    cmbLVStatus.SelectedIndex = cmbLVStatus.Properties.Items.IndexOf("");
                    cmbLVSection.Text = "";
                }
                else
                {
                    if (RequiredPositionFields != null && RequiredPositionFields.Count > 0)
                        RequiredPositionFields.Clear();
                    //cmbLVSection.Enabled = true;
                    cmbLVStatus.Enabled = true;
                    cmbLVStatus.SelectedIndex = cmbLVStatus.Properties.Items.IndexOf("");
                    RequiredPositionFields.Add(cmbLVSection);
                    RequiredPositionFields.Add(cmbLVStatus);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbLVSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtpProjectEndDate_QueryPopUp(object sender, CancelEventArgs e)
        {
            dtpProjectEndDate.Properties.MinValue = Convert.ToDateTime(dtpProjectStartDate.EditValue);
        }

        private void txtValue1ME_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit textbox = (TextEdit)sender;
                if (Convert.ToDouble(textbox.Text) < 0)
                {
                    textbox.ForeColor = Color.Red;
                }
                else
                {
                    textbox.ForeColor = Color.Black;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void dtpProjectStartDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpProjectEndDate.EditValue = dtpProjectStartDate.EditValue;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            if (txtMa.Text.ToLower() == "s")
            {
                txtMo.Text = "S";
                txtMo.Enabled = false;
            }
            else
            {
                txtMo.Enabled = true;
            }
        }

        bool _IsTabPressed = false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F9))
            {
                    if (tcProjectDetails.SelectedTabPage.Name == "tbLVDetails" && Utility.CalcAccess != "7")
                    {
                        if (ObjEProject.IsFinalInvoice)
                            return false;
                        btnSaveLVDetails.PerformClick();
                        return true;
                    }
                if (txtkommissionNumber.Text == string.Empty)
                {
                    if (tcProjectDetails.SelectedTabPage.Name == "tbProjectDetails" && Utility.ProjectDataAccess != "7")
                    {
                        if (ObjEProject.IsFinalInvoice)
                            return false;
                        btnProjectSave_Click(null, null);
                        return true;
                    }
                }
            }
            if (keyData == (Keys.PageDown))
            {
                //txtLPMe_TextChanged(null,null);
                btnNext.PerformClick();
                return true;
            }
            if (keyData == (Keys.PageUp))
            {
                btnPrevious.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtStufe1Short_Leave(object sender, EventArgs e)
        {
            TextEdit textbox = (TextEdit)sender;
            if (textbox.Text == "0")
            {
                textbox.Text = "";
            }
        }

        private void tlPositions_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
                if (tlPositions.FocusedNode != null && tlPositions.FocusedNode["PositionID"] != null)
                {
                    string strColumnName = e.Column.FieldName;
                    switch (strColumnName)
                    {
                        case "MA_Multi1":
                            txtMulti1ME.Text = tlPositions.FocusedNode.GetValue("MA_Multi1").ToString();       
                            break;
                        case "MA_multi2":
                            txtMulti2ME.Text = tlPositions.FocusedNode.GetValue("MA_multi2").ToString();
                            break;
                        case "MA_multi3":
                            txtMulti3ME.Text = tlPositions.FocusedNode.GetValue("MA_multi3").ToString();
                            break;
                        case "MA_multi4":
                            txtMulti4ME.Text = tlPositions.FocusedNode.GetValue("MA_multi4").ToString();
                            break;
                        case "MA_selbstkostenMulti":
                            txtSelbstkostenMultiME.Text = tlPositions.FocusedNode.GetValue("MA_selbstkostenMulti").ToString();
                            break;
                        case "MA_verkaufspreis_Multi":
                            txtVerkaufspreisMultiME.Text = tlPositions.FocusedNode.GetValue("MA_verkaufspreis_Multi").ToString();
                            break;
                        case "MO_multi1":
                            txtMulti1MO.Text = tlPositions.FocusedNode.GetValue("MO_multi1").ToString();
                            break;
                        case "MO_multi2":
                            txtMulti2MO.Text = tlPositions.FocusedNode.GetValue("MO_multi2").ToString();
                            break;
                        case "MO_multi3":
                            txtMulti3MO.Text = tlPositions.FocusedNode.GetValue("MO_multi3").ToString();
                            break;
                        case "MO_multi4":
                            txtMulti4MO.Text = tlPositions.FocusedNode.GetValue("MO_multi4").ToString();
                            break;
                        case "MO_selbstkostenMulti":
                            txtSelbstkostenMultiMO.Text = tlPositions.FocusedNode.GetValue("MO_selbstkostenMulti").ToString();
                            break;
                        case "MO_verkaufspreisMulti":
                            txtVerkaufspreisMultiMO.Text = tlPositions.FocusedNode.GetValue("MO_verkaufspreisMulti").ToString();
                            break;
                        case "WG":
                            txtWG.Text = tlPositions.FocusedNode.GetValue("WG").ToString();
                            txtWI_Leave(null, null);
                            break;
                        case "WA":
                            txtWA.Text = tlPositions.FocusedNode.GetValue("WA").ToString();
                            txtWI_Leave(null, null);
                            break;
                        case "WI":
                            txtWI.Text = tlPositions.FocusedNode.GetValue("WI").ToString();
                            txtWI_Leave(null, null);
                            break;
                        case "Menge":
                            txtMenge.Text = tlPositions.FocusedNode.GetValue("Menge").ToString();
                            break;
                        default:
                            break;
                    }
                        string strcolumnName = tlPositions.FocusedColumn.FieldName;
                        btnSaveLVDetails_Click(null, null);
                        tlPositions.FocusedColumn = tlPositions.Columns[strcolumnName];

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void chkCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCreateNew.Checked == true)
                {
                    tlPositions.OptionsBehavior.ReadOnly = true;
                    Color _Color = Color.FromArgb(255, 183, 0);
                    LCGLVDetails.AppearanceGroup.BackColor = _Color;
                    tlPositions.Appearance.HeaderPanel.BackColor = _Color;
                }
                //else
                //{
                //    tlPositions.OptionsBehavior.ReadOnly = false;
                //    Color _Color = Color.FromArgb(0, 158, 224);
                //    LCGLVDetails.AppearanceGroup.BackColor = _Color;
                //    tlPositions.Appearance.HeaderPanel.BackColor = _Color;
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ObjBProject.GetProjectDetails(ObjEProject);
                BindPositionData();
                if (ObjEProject.ActualLvs == 0)
                {
                    if (Utility._IsGermany == true)
                    {
                        XtraMessageBox.Show("Nein LV Positions to Export.!");
                    }
                    else
                    {
                        XtraMessageBox.Show("No LV Positions to Export.!");
                    }
                    return;
                }
                if (ObjEProject.ProjectID > 0)
                {
                    int raster_count = ddlRaster.Text.Replace(".", string.Empty).Length;

                    frmGAEBExport Obj = new frmGAEBExport(ObjEProject.ProjectNumber, ObjEProject.ProjectID, raster_count,ObjEProject.LVRaster);
                    Obj.KNr = ObjEProject.CommissionNumber;
                    Obj.ShowDialog();
                    if (File.Exists(Obj.OutputFilePath))
                        Process.Start("explorer.exe", "/select, \"" + Obj.OutputFilePath + "\"");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkRaster_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkRaster.Checked == true)
                {
                    ddlRaster.SelectedIndex = ddlRaster.Properties.Items.IndexOf("");
                    ddlRaster.Enabled = false;
                }
                else
                {
                    // ddlRaster.SelectedIndex = ddlRaster.Properties.Items.IndexOf(ObjEProject.LVRaster);
                    ddlRaster.Enabled = true;
                    ddlRaster.SelectedIndex = ddlRaster.Properties.Items.IndexOf("99.99.1111.9");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEProject.ProjectID > 0)
                {
                    frmGAEBImport Obj = new frmGAEBImport();
                    Obj.ProjectID = ObjEProject.ProjectID;
                    Obj.KNr = ObjEProject.CommissionNumber;
                    Obj.ShowDialog();
                    ProjectID = Obj.ProjectID;
                    if (ProjectID > 0 && Obj.isbuild)
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                        SplashScreenManager.Default.SetWaitFormDescription("Laden Projekt...");
                        LoadExistingRasters();
                        LoadExistingProject();
                        BindPositionData();
                        IntializeLVPositions();
                        if (ObjEProject.ActualLvs == 0)
                            ChkRaster.Enabled = true;
                        else
                            ChkRaster.Enabled = false;
                        SplashScreenManager.CloseForm(false);
                    }
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                if (Utility._IsGermany == true)
                {
                    throw new Exception("Das ausgewählte Datei-Raster ist nicht mit dem ausgewählten Projektraster kompatibel!");
                }
                else
                {
                    Utility.ShowError(ex);
                }
            }

        }

        private void DeletePosition()
        {
            string strConfirmation = "";
            try
            {
                if (tlPositions.FocusedNode != null && tlPositions.FocusedNode["PositionID"] != null)
                {
                    int iValue = 0;
                    string Pos = tlPositions.FocusedNode.GetDisplayText("Position_OZ").ToString();
                    if (int.TryParse(tlPositions.FocusedNode["PositionID"].ToString(), out iValue))
                    {
                        if (Utility._IsGermany == true)
                        {
                            strConfirmation = XtraMessageBox.Show("Wollen Sie die LV Position " + Pos + " wirklich löschen.?", "Bestätigung!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        }
                        else
                        {
                            strConfirmation = XtraMessageBox.Show("Do you really want to delete the Position " + Pos + ".?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        }
                        if (strConfirmation.ToLower() == "yes")
                        {
                            ObjBPosition.Deleteposition(iValue);
                            BindPositionData();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void tlPositions_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (ObjEProject.IsFinalInvoice && Utility.LVDetailsAccess == "7")
                    return;
                tlPositions.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                string P_value = tlPositions.FocusedNode["PositionKZ"].ToString();
                if (P_value == "NG" || P_value == "Z" || P_value == "ZS")
                {
                    if (e.Menu is TreeListNodeMenu)
                    {
                        if (P_value == "Z" || P_value == "ZS")
                            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", bbDelete_ItemClick));
                        else if(tlPositions.FocusedNode.Nodes.Count <= 0)
                            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", bbDelete_ItemClick));

                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Textposition hinzufügen", bbAddTextPosition_Click));
                    }
                }
                else if (P_value == "H")
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", bbDelete_ItemClick));
                else
                {
                    if (e.Menu is TreeListNodeMenu)
                    {
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", bbDelete_ItemClick));
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Textposition hinzufügen", bbAddTextPosition_Click));
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Detail KZ hinzufügen", bbAddDetailKZ_Click));
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void bbDelete_ItemClick(object sender, EventArgs e)
        {
            try
            {
                DeletePosition();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void bbAddTextPosition_Click(object sender, EventArgs e)
        {
            try
            {
                CreateNewPosition("h");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void bbAddTitle_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void bbAddDetailKZ_Click(object sender, EventArgs e)
        {
            try
            {
                if (tlPositions.FocusedNode["Position_OZ"] != null)
                {
                    string strPositionOZ = Convert.ToString(tlPositions.FocusedNode["Position_OZ"]);
                    string strParentOZ = Convert.ToString(tlPositions.FocusedNode.ParentNode["Position_OZ"]);
                    if (ObjEPosition.dsPositionList != null && ObjEPosition.dsPositionList.Tables.Count > 0)
                    {
                        object objDetailKZ = ObjEPosition.dsPositionList.Tables[0].Compute("MAX(DetailKZ)", "Position_OZ ='" + strPositionOZ + "'");
                        object ObjSNO = ObjEPosition.dsPositionList.Tables[0].Compute("MAX(SNO)", "Position_OZ ='" + strPositionOZ + "'");
                        int iValue = 0;
                        int iSNOValue = 0;
                        if (objDetailKZ != null && ObjSNO != null && int.TryParse(Convert.ToString(objDetailKZ), out iValue) && int.TryParse(Convert.ToString(ObjSNO), out iSNOValue))
                        {
                            DataRow dataRow = (tlPositions.GetDataRecordByNode(tlPositions.FocusedNode) as DataRowView).Row;
                            if (dataRow == null) return;
                            ParsePositionDetailsfoCopyLV(dataRow, strPositionOZ, strParentOZ, iSNOValue, string.Empty, iValue + 1);
                            int NewPositionID = ObjBPosition.SavePositionDetails(ObjEPosition, ObjEProject.LVRaster, true);
                            BindPositionData();
                            SetFocus(NewPositionID, tlPositions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        #region BULK PROCESS

        string tType = null;
        private void AssignPosition_type()
        {
            if (cmbBulkProcessSelection.SelectedIndex == 0)
            {
                tType = "Parent Position";
            }
            if (cmbBulkProcessSelection.SelectedIndex == 1)
            {
                tType = "LV Position";
            }
            if (cmbBulkProcessSelection.SelectedIndex == 2)
            {
                tType = "WG/WA";
            }
            if (cmbBulkProcessSelection.SelectedIndex == 3)
            {
                tType = "Supplier";
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbBulkProcessSelection.SelectedIndex != 2)
                {
                    if (gvAddRemovePositions.RowCount == 0)
                    {
                        if (Utility._IsGermany == true)
                        {
                            XtraMessageBox.Show("Bitte machen Sie VON / BIS Angaben.");
                        }
                        else
                        {
                            XtraMessageBox.Show("Please Add From and To values.");
                        }
                        return;
                    }
                }
                string Gridvalue = null;
                if (cmbBulkProcessSelection.SelectedIndex != 2)
                {
                    foreach (DataGridViewRow dr in gvAddRemovePositions.Rows)
                    {
                        Gridvalue = Convert.ToString(dr.Cells[1].Value);
                        if (Gridvalue == null || Gridvalue == "")
                        {
                            if (Utility._IsGermany == true)
                            {
                                XtraMessageBox.Show("Bitte machen Sie VON / BIS Angaben.");
                            }
                            else
                            {
                                XtraMessageBox.Show("Please enter From And To values.!");
                            }
                            return;
                        }
                    }

                }

                AssignPosition_type();
                if (cmbBulkProcessSelection.SelectedIndex == 2)
                {
                    if (txtBulkProcessWG.Text == "")
                    {
                        if (Utility._IsGermany == true)
                        {
                            XtraMessageBox.Show("Bitte machen Sie eine Angabe zu WG.");
                        }
                        else
                        {
                            XtraMessageBox.Show("Please Enter WG value.!");
                        }
                        return;
                    }
                    else
                    {
                        if (txtBulkProcessWA.Text == "")
                        {
                            txtBulkProcessWA.Text = "0";
                        }
                        ObjBPosition.GetPositionOZListByWGWA(ObjEPosition, ObjEProject.ProjectID, tType, txtBulkProcessWG.Text, txtBulkProcessWA.Text);
                    }
                }
                else
                {
                    DataTable dtPos = new DataTable();
                    dtPos.Columns.Add("FromPos");
                    dtPos.Columns.Add("ToPos");

                    string tfrom = null;
                    string tTo = null;
                    foreach (DataGridViewRow dr in gvAddRemovePositions.Rows)
                    {
                        DataRow drPos = dtPos.NewRow();
                        tfrom = dr.Cells[0].Value.ToString();
                        tTo = dr.Cells[1].Value.ToString();
                        if (cmbBulkProcessSelection.SelectedIndex == 0)
                        {
                            string _fromParent = string.Empty;
                            string _ToParent = string.Empty;
                            if (tfrom.Contains("."))
                                _fromParent = tfrom.Substring(0, tfrom.IndexOf('.'));
                            if (tTo.Contains("."))
                                _ToParent = tTo.Substring(0, tTo.IndexOf('.'));
                            if (_fromParent != _ToParent)
                            {
                                if (Utility._IsGermany)
                                    throw new Exception("Bitte geben Sie den gleichen Parent-Level ein..!");
                                else
                                    throw new Exception("Please enter the same Parent level..!");
                            }
                        }
                        drPos["fromPos"] = tfrom.Replace(',', '.');
                        drPos["toPos"] = tTo.Replace(',', '.');
                        dtPos.Rows.Add(drPos);
                    }
                    ObjBPosition.GetPositionOZList(ObjEPosition, ObjEProject.ProjectID, tType, dtPos);
                }


                if (ObjEPosition.dsPositionOZList != null)
                {
                    tlBulkProcessPositionDetails.DataSource = ObjEPosition.dsPositionOZList;
                    tlBulkProcessPositionDetails.DataMember = "Positions";
                    tlBulkProcessPositionDetails.ParentFieldName = "Parent_OZ";
                    tlBulkProcessPositionDetails.KeyFieldName = "PositionID";
                    tlBulkProcessPositionDetails.ForceInitialize();
                    tlBulkProcessPositionDetails.ExpandAll();
                }
                tlBulkProcessPositionDetails.BestFitColumns();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void VisibleBulkProcess_SectionA_Controls(CheckEdit tCheckEditEdit, LayoutControlItem tLayoutItem, TextEdit tText)
        {
            try
            {

                if (radioGroupActionA.SelectedIndex == 0)
                {
                    if (tCheckEditEdit.Checked == true)
                    {
                        tLayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        tText.Text = "";
                    }
                    else
                    {
                        tLayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        tText.Text = "";
                    }
                }
                else
                {
                    lciMulti5MA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMulti5MO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMulti6MA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMulti6MO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        private void checkEditSectionAMulti5MA_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionA_Controls(checkEditSectionAMulti5MA, lciMulti5MA, txtMulti5MA);
        }

        private void checkEditSectionAMulti5MO_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionA_Controls(checkEditSectionAMulti5MO, lciMulti5MO, txtMulti5MO);
        }

        private void checkEditSectionAMulti6MA_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionA_Controls(checkEditSectionAMulti6MA, lciMulti6MA, txtMulti6MA);
        }

        private void checkEditSectionAMulti6MO_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionA_Controls(checkEditSectionAMulti6MO, lciMulti6MO, txtMulti6MO);
        }


        private void HideTextBoxes()
        {
            lciPositionKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciPosMenge.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciMaterialKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciMontageKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciPreisErstaztext.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciArtikelnummerWG.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciWarenart.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciWarenident.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciFabrikat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciTyp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciLieferantMA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciNachtragsnummer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;



            //checkEditLVPositionKZ.Checked = false;
            checkEditPositionMenge.Checked = false;
            checkEditMaterialKz.Checked = false;
            checkEditMontageKZ.Checked = false;
            checkEditPreisErstaztext.Checked = false;
            checkEditArtikelnummerWG.Checked = false;
            checkEditFabrikat.Checked = false;
            checkEditTyp.Checked = false;
            checkEditLieferantMA.Checked = false;
            checkEditNachtragsnummer.Checked = false;
            if (GetCommisssionNo() != "")
            {
                checkEditNachtragsnummer.Enabled = false;
                btnSavesectionB.Enabled = false;
            }
            else
            {
                checkEditNachtragsnummer.Enabled = false;
                btnSavesectionB.Enabled = true;
            }

        }
        private void radioGroupActionA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupActionA.SelectedIndex == 1)
                {
                    lciMulti5MA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMulti5MO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMulti6MA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMulti6MO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    txtMulti5MA.Text = "";
                    txtMulti5MO.Text = "";
                    txtMulti6MA.Text = "";
                    txtMulti6MO.Text = "";

                    checkEditSectionAMulti5MA.Checked = false;
                    checkEditSectionAMulti5MO.Checked = false;
                    checkEditSectionAMulti6MA.Checked = false;
                    checkEditSectionAMulti6MO.Checked = false;
                    tType = "Remove";
                }
                else
                {
                    checkEditSectionAMulti5MA.Checked = false;
                    checkEditSectionAMulti5MO.Checked = false;
                    checkEditSectionAMulti6MA.Checked = false;
                    checkEditSectionAMulti6MO.Checked = false;
                    tType = "Set";
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void radioGroupActionB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupActionB.SelectedIndex == 1)
                {
                    HideTextBoxes();
                }
                else
                {
                    //checkEditLVPositionKZ.Checked = false;
                    checkEditPositionMenge.Checked = false;
                    checkEditMaterialKz.Checked = false;
                    checkEditMontageKZ.Checked = false;
                    checkEditPreisErstaztext.Checked = false;
                    checkEditArtikelnummerWG.Checked = false;
                    checkEditFabrikat.Checked = false;
                    checkEditTyp.Checked = false;
                    checkEditLieferantMA.Checked = false;
                    checkEditNachtragsnummer.Checked = false;

                    if (GetCommisssionNo() != "")
                    {
                        checkEditNachtragsnummer.Enabled = true;
                        btnSavesectionB.Enabled = true;
                    }
                    else
                    {
                        checkEditNachtragsnummer.Enabled = false;
                        btnSavesectionB.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSaveActionA_Click(object sender, EventArgs e)
        {
            try
            {
                if (tlBulkProcessPositionDetails.DataSource == null)
                {
                    if (Utility._IsGermany == true)
                    {
                        XtraMessageBox.Show("Bitte machen Sie VON / BIS Angaben.");
                    }
                    else
                    {
                        XtraMessageBox.Show("Please enter From And To values.!");
                    }
                    return;
                }

                DataTable dtPos = new DataTable();
                dtPos.Columns.Add("ID");

                if (tlBulkProcessPositionDetails.DataSource != null)
                {
                    foreach (TreeListNode node in tlBulkProcessPositionDetails.GetNodeList())
                    {
                        string _PosKZ = node["PositionKZ"].ToString();
                        if (_PosKZ != "NG")
                        {
                            DataRow drPos = dtPos.NewRow();
                            string tID = node["PositionID"].ToString();
                            drPos["ID"] = tID;
                            dtPos.Rows.Add(drPos);
                        }
                    }
                }
                if (radioGroupActionA.SelectedIndex == 0)
                {
                    if (txtMulti5MA.Text == "")
                    {
                        txtMulti5MA.Text = "0";
                    }
                    if (txtMulti5MO.Text == "")
                    {
                        txtMulti5MO.Text = "0";
                    }
                    if (txtMulti6MA.Text == "")
                    {
                        txtMulti6MA.Text = "0";
                    }
                    if (txtMulti6MO.Text == "")
                    {
                        txtMulti6MO.Text = "0";
                    }
                }
                if (radioGroupActionA.SelectedIndex == 1)
                {

                    if (checkEditSectionAMulti5MA.Checked == true)
                    {
                        txtMulti5MA.Text = "1";
                    }
                    else
                    {
                        txtMulti5MA.Text = "0";
                    }
                    if (checkEditSectionAMulti5MO.Checked == true)
                    {
                        txtMulti5MO.Text = "1";
                    }
                    else
                    {
                        txtMulti5MO.Text = "0";
                    }
                    if (checkEditSectionAMulti6MA.Checked == true)
                    {
                        txtMulti6MA.Text = "1";
                    }
                    else
                    {
                        txtMulti6MA.Text = "0";
                    }
                    if (checkEditSectionAMulti6MO.Checked == true)
                    {
                        txtMulti6MO.Text = "1";
                    }
                    else
                    {
                        txtMulti6MO.Text = "0";
                    }
                }
                if (radioGroupActionA.SelectedIndex == 1)
                {
                    tType = "Remove";
                }
                else
                {
                    tType = "Set";
                }
                
                ObjBPosition.UpdateBulkProcess_ActionA(ObjEPosition, ObjEProject.ProjectID, tType, 
                    Convert.ToDecimal(txtMulti5MA.Text), 
                    Convert.ToDecimal(txtMulti5MO.Text), 
                    Convert.ToDecimal(txtMulti6MA.Text), 
                    Convert.ToDecimal(txtMulti6MO.Text), 
                    dtPos);

                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der LV Positionen");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("LV Positions Saved Successfully");
                }
                BindPositionData();
                btnApply_Click(null, null);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }

        }

        private void VisibleBulkProcess_SectionB_Controls(CheckEdit tCheckEditEdit, LayoutControlItem tLayoutItem, TextEdit tText)
        {
            try
            {
                if (radioGroupActionB.SelectedIndex == 0)
                {
                    if (tCheckEditEdit.Checked == true)
                    {
                        tLayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        tText.Text = "";
                    }
                    else
                    {
                        tLayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        tText.Text = "";
                    }
                }
                else
                {
                    lciPositionKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciPosMenge.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMaterialKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMontageKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciPreisErstaztext.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciArtikelnummerWG.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciWarenart.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciWarenident.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciFabrikat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciTyp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciLieferantMA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciNachtragsnummer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private string GetCommisssionNo()
        {
            string tKomistnNo = null;
            tKomistnNo = txtkommissionNumber.Text;
            return tKomistnNo;
        }

        private void KommisionNoMessage()
        {
            if (Utility._IsGermany == true)
            {
                XtraMessageBox.Show("Das Projekt ist bereits in eine Kommission gewandelt, diese Operation ist nicht zulässig. ");
            }
            else
            {
                XtraMessageBox.Show("Kommission Number is Generated,you can't do this operation.");
            }
            btnSaveActionA.Enabled = false;
            btnSavesectionB.Enabled = false;
            return;
        }

        private void checkEditLVPositionKZ_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditLVPositionKZ, lciPositionKZ, txtLVPositionKZ);
        }

        private void checkEditPositionMenge_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditPositionMenge, lciPosMenge, txtPositionMenge);
        }

        private void checkEditMaterialKz_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditMaterialKz, lciMaterialKZ, txtMaterialKz);
        }

        private void checkEditMontageKZ_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditMontageKZ, lciMontageKZ, txtMontageKZ);
        }

        private void checkEditPreisErstaztext_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditPreisErstaztext, lciPreisErstaztext, txtPreisErstaztext);
        }

        private void checkEditArtikelnummerWG_CheckedChanged(object sender, EventArgs e)
        {
            //VisibleBulkProcess_SectionB_Controls(checkEditArtikelnummerWG, lciArtikelnummerWG, txtArtikelnummerWG);
            try
            {
                if (radioGroupActionB.SelectedIndex == 0)
                {
                    if (checkEditArtikelnummerWG.Checked == true)
                    {
                        lciArtikelnummerWG.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciWarenart.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciWarenident.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        txtArtikelnummerWG.Text = "";
                        txtArtikelnummerWA.Text = "";
                        txtArtikelnummerWI.Text = "";
                    }
                    else
                    {
                        lciArtikelnummerWG.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciWarenart.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciWarenident.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        txtArtikelnummerWG.Text = "";
                        txtArtikelnummerWA.Text = "";
                        txtArtikelnummerWI.Text = "";
                    }
                }
                else
                {
                    lciPositionKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciPosMenge.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMaterialKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciMontageKZ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciPreisErstaztext.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciArtikelnummerWG.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciWarenart.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciWarenident.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciFabrikat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciTyp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciLieferantMA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciNachtragsnummer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void checkEditWarenart_CheckedChanged(object sender, EventArgs e)
        {
            //VisibleBulkProcess_SectionB_Controls(checkEditWA, lciWarenart, txtArtikelnummerWA);
        }

        private void checkEditWarenident_CheckedChanged(object sender, EventArgs e)
        {
            //VisibleBulkProcess_SectionB_Controls(checkEditWI, lciWarenident, txtArtikelnummerWI);
        }

        private void checkEditFabrikat_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditFabrikat, lciFabrikat, txtFabrikat);
        }

        private void checkEditTyp_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditTyp, lciTyp, txtTyp);
        }

        private void checkEditLieferantMA_CheckedChanged(object sender, EventArgs e)
        {
            VisibleBulkProcess_SectionB_Controls(checkEditLieferantMA, lciLieferantMA, txtBulkLieferantMA);
        }

        private void checkEditNachtragsnummer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditNachtragsnummer.Checked == true)
            {
                btnSavesectionB.Enabled = true;
            }
            VisibleBulkProcess_SectionB_Controls(checkEditNachtragsnummer, lciNachtragsnummer, txtNachtragsnummer);
        }

        private void btnSavesectionB_Click(object sender, EventArgs e)
        {
            try
            {
                if (tlBulkProcessPositionDetails.DataSource == null)
                {
                    if (Utility._IsGermany == true)
                    {
                        XtraMessageBox.Show("Bitte machen Sie VON / BIS Angaben.");
                    }
                    else
                    {
                        XtraMessageBox.Show("Please enter From And To values.!");
                    }
                    return;
                }

                DataTable dtPos = new DataTable();
                dtPos.Columns.Add("ID");

                if (tlBulkProcessPositionDetails.DataSource != null)
                {
                    foreach (TreeListNode node in tlBulkProcessPositionDetails.GetNodeList())
                    {
                        string _PosKZ = node["PositionKZ"].ToString();
                        if (_PosKZ != "NG")
                        {
                            DataRow drPos = dtPos.NewRow();
                            string tID = node["PositionID"].ToString();

                            drPos["ID"] = tID;
                            dtPos.Rows.Add(drPos);
                        }
                    }

                }
                if (radioGroupActionB.SelectedIndex == 0)
                {                    
                    if (checkEditArtikelnummerWG.Checked == true)
                    {
                        if (txtArtikelnummerWG.Text == "")
                        {
                            if (Utility._IsGermany == true)
                            {
                                XtraMessageBox.Show("Bitte machen Sie eine Angabe zu WG.");
                            }
                            else
                            {
                                XtraMessageBox.Show("Please enter WG value");
                            }
                            return;
                        }
                        if (txtArtikelnummerWA.Text == "")
                        {
                            if (Utility._IsGermany == true)
                            {
                                XtraMessageBox.Show("Bitte machen Sie eine Angabe zu WA.");
                            }
                            else
                            {
                                XtraMessageBox.Show("Please enter WA value");
                            }
                            return;
                        }
                    }                   
                }
                else
                {
                    if (checkEditPositionMenge.Checked == true)
                    {
                        txtPositionMenge.Text = "1";
                    }
                    else
                    {
                        txtPositionMenge.Text = "";
                    }
                    if (checkEditMaterialKz.Checked == true)
                    {
                        txtMaterialKz.Text = "X";
                    }
                    else
                    {
                        txtMaterialKz.Text = "";
                    }
                    if (checkEditMontageKZ.Checked == true)
                    {
                        txtMontageKZ.Text = "X";
                    }
                    else
                    {
                        txtMontageKZ.Text = "";
                    }
                    if (checkEditPreisErstaztext.Checked == true)
                    {
                        txtPreisErstaztext.Text = "0";
                    }
                    else
                    {
                        txtPreisErstaztext.Text = "";
                    }
                    if (checkEditFabrikat.Checked == true)
                    {
                        txtFabrikat.Text = "0";
                    }
                    else
                    {
                        txtFabrikat.Text = "";
                    }
                    if (checkEditTyp.Checked == true)
                    {
                        txtTyp.Text = "0";
                    }
                    else
                    {
                        txtTyp.Text = "";
                    }
                    if (checkEditLieferantMA.Checked == true)
                    {
                        txtBulkLieferantMA.Text = "0";
                    }
                    else
                    {
                        txtBulkLieferantMA.Text = "";
                    }
                    if (checkEditArtikelnummerWG.Checked == true)
                    {
                        txtArtikelnummerWG.Text = "0";
                        txtArtikelnummerWA.Text = "0";
                        txtArtikelnummerWI.Text = "0";
                    }
                    else
                    {
                        txtArtikelnummerWG.Text = "";
                        txtArtikelnummerWA.Text = "";
                        txtArtikelnummerWI.Text = "";
                    }

                    if (checkEditNachtragsnummer.Checked == true)
                    {
                        txtNachtragsnummer.Text = "";
                    }
                    else
                    {
                        txtNachtragsnummer.Text = "";
                    }
                }

                ObjBPosition.UpdateBulkProcess_ActionB(ObjEPosition, ObjEProject.ProjectID, tType, txtPositionMenge.Text, 
                    txtMaterialKz.Text, txtMontageKZ.Text,
                    txtPreisErstaztext.Text, txtFabrikat.Text, txtTyp.Text, txtBulkLieferantMA.Text, txtArtikelnummerWG.Text,
                    txtArtikelnummerWA.Text, txtArtikelnummerWI.Text, txtNachtragsnummer.Text, dtPos);

                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der LV Positionen");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("LV Positions Saved Successfully");
                }
                btnApply_Click(null, null);
                ObjBProject.GetProjectDetails(ObjEProject);
                if (ObjEProject.dtLVSection != null && ObjEProject.dtLVSection.Rows.Count > 0)
                {
                    cmbLVSection.DataSource = ObjEProject.dtLVSection;
                    cmbLVSection.DisplayMember = "LVSectionName";
                    cmbLVSection.ValueMember = "LVSectionID";
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        private void txtMaterialKz_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMaterialKz.Text.ToLower() == "s")
                {
                    txtMontageKZ.Text = "";
                    txtMontageKZ.Enabled = false;
                }
                else
                {
                    txtMontageKZ.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        #endregion

        private void gvAddRemovePositions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(DataGrid_KeyPress);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        // user defined event named as DataGrid_KeyPress
        private void DataGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (cmbBulkProcessSelection.SelectedIndex == 0)
                {
                    if ((e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkEinkaufspreisME_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtMulti1ME.Enabled = !chkEinkaufspreisME.Checked;
                txtMulti2ME.Enabled = !chkEinkaufspreisME.Checked;
                txtMulti3ME.Enabled = !chkEinkaufspreisME.Checked;
                txtMulti4ME.Enabled = !chkEinkaufspreisME.Checked;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkEinkaufspreisMO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtMulti1MO.Enabled = !chkEinkaufspreisMO.Checked;
                txtMulti2MO.Enabled = !chkEinkaufspreisMO.Checked;
                txtMulti3MO.Enabled = !chkEinkaufspreisMO.Checked;
                txtMulti4MO.Enabled = !chkEinkaufspreisMO.Checked;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkSelbstkostenME_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelbstkostenME.Checked == true)
                {
                    chkEinkaufspreisME.Checked = true;
                    chkEinkaufspreisME.Enabled = false;
                    txtSelbstkostenMultiME.Enabled = false;
                }
                else
                {
                    chkEinkaufspreisME.Checked = false;
                    chkEinkaufspreisME.Enabled = true;
                    txtSelbstkostenMultiME.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkSelbstkostenMO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelbstkostenMO.Checked == true)
                {
                    chkEinkaufspreisMO.Checked = true;
                    chkEinkaufspreisMO.Enabled = false;
                    txtSelbstkostenMultiMO.Enabled = false;
                }
                else
                {
                    chkEinkaufspreisMO.Checked = false;
                    chkEinkaufspreisMO.Enabled = true;
                    txtSelbstkostenMultiMO.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkVerkaufspreisME_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkVerkaufspreisME.Checked == true)
                {
                    chkEinkaufspreisME.Checked = true;
                    chkSelbstkostenME.Checked = true;
                    chkEinkaufspreisME.Enabled = false;
                    chkSelbstkostenME.Enabled = false;
                    txtSelbstkostenMultiME.Enabled = false;
                    txtVerkaufspreisMultiME.Enabled = false;
                }
                else
                {
                    chkEinkaufspreisME.Checked = false;
                    chkSelbstkostenME.Checked = false;
                    chkEinkaufspreisME.Enabled = true;
                    chkSelbstkostenME.Enabled = true;
                    txtSelbstkostenMultiME.Enabled = true;
                    txtVerkaufspreisMultiME.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkVerkaufspreisMO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkVerkaufspreisMO.Checked == true)
                {
                    chkEinkaufspreisMO.Checked = true;
                    chkSelbstkostenMO.Checked = true;
                    chkEinkaufspreisMO.Enabled = false;
                    chkSelbstkostenMO.Enabled = false;
                    txtSelbstkostenMultiMO.Enabled = false;
                    txtVerkaufspreisMultiMO.Enabled = false;
                }
                else
                {
                    chkEinkaufspreisMO.Checked = false;
                    chkSelbstkostenMO.Checked = false;
                    chkEinkaufspreisMO.Enabled = true;
                    chkSelbstkostenMO.Enabled = true;
                    txtSelbstkostenMultiMO.Enabled = true;
                    txtVerkaufspreisMultiMO.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbSelectGridviewOptions_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            try
            {
                if (cmbSelectGridviewOptions.EditValue.ToString() == "" || cmbSelectGridviewOptions.EditValue == null)
                {
                    cmbSelectGridviewOptions.Text = "Auswahl";
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void LoadExistingRasters()
        {
            try
            {
                objEGAEB.dtLVRaster = objBGAEB.Get_LVRasters();
                if (objEGAEB.dtLVRaster.Rows != null)
                {
                    foreach (DataRow Row in objEGAEB.dtLVRaster.Rows)
                    {
                        ddlRaster.Properties.Items.Add(Row["LVRasterName"]);
                    }
                    ddlRaster.Properties.Sorted = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }

        }

        private void txtSurchargeFrom_Validating(object sender, CancelEventArgs e)
        {
            if (txtSurchargeTo.Text != "")
            {
                dxValidationProvider1.Validate();
            }
        }

        private void dtpSubmitDate_EditValueChanged(object sender, EventArgs e)
        {
            dtpValidityDate.Value = Convert.ToDateTime(dtpSubmitDate.EditValue);
        }

        private void txtLPMe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.Handled = true;
        }

        private void txtStufe1Short_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtStufe1Title.Text = GetTitle(txtStufe1Short.Text + ".");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtStufe2Short_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtStufe2Title.Text = GetTitle(txtStufe1Short.Text + "." +
                txtStufe2Short.Text + ".");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtStufe3Short_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtStufe3Title.Text = GetTitle(txtStufe1Short.Text + "." +
                                txtStufe2Short.Text + "." +
                                txtStufe3Short.Text + ".");
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtStufe4Short_TextChanged(object sender, EventArgs e)
        {
            txtStufe4Title.Text = GetTitle(txtStufe1Short.Text + "." +
                                txtStufe2Short.Text + "." +
                                txtStufe3Short.Text + "." +
                                txtStufe4Short.Text + ".");
        }

        private string GetTitle(string strTitle)
        {
            string strTitleDesc = string.Empty;
            try
            {
                DataRow[] drPosition = ObjEPosition.dsPositionList.Tables[0].Select("Position_OZ='" + strTitle + "'");
                if (drPosition != null && drPosition.Count() > 0)
                {
                    strTitleDesc = drPosition[0]["Title"] == DBNull.Value ? "" : drPosition[0]["Title"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strTitleDesc;
        }

        private void cmbSelectGridviewOptions_Closed(object sender, ClosedEventArgs e)
        {
            bool isFound_MA = false;
            bool isFound_MO = false;
            bool isFound_Einfr = false;
            bool isFound_Seleb = false;
            bool isFound_Verkf = false;
            try
            {
                foreach (var item in cmbSelectGridviewOptions.Text.Split(','))
                {
                    if (item.Trim() == "MA Multies")
                    {
                        isFound_MA = true;
                    }
                    if (item.Trim() == "MO Multies")
                    {
                        isFound_MO = true;
                    }
                    if (item.Trim() == "Einkaufspreis")
                    {
                        isFound_Einfr = true;
                    }
                    if (item.Trim() == "Selbstkosten")
                    {
                        isFound_Seleb = true;
                    }
                    if (item.Trim() == "Verkaufspreis")
                    {
                        isFound_Verkf = true;
                    }
                }
                tlPositions.Columns["MA_Multi1"].VisibleIndex = 8;
                tlPositions.Columns["MA_multi2"].VisibleIndex = 9;
                tlPositions.Columns["MA_multi3"].VisibleIndex = 10;
                tlPositions.Columns["MA_multi4"].VisibleIndex = 11;
                tlPositions.Columns["MA_Multi1"].Visible = isFound_MA;
                tlPositions.Columns["MA_multi2"].Visible = isFound_MA;
                tlPositions.Columns["MA_multi3"].Visible = isFound_MA;
                tlPositions.Columns["MA_multi4"].Visible = isFound_MA;

                tlPositions.Columns["MO_multi1"].VisibleIndex = 12;
                tlPositions.Columns["MO_multi2"].VisibleIndex = 13;
                tlPositions.Columns["MO_multi3"].VisibleIndex = 14;
                tlPositions.Columns["MO_multi4"].VisibleIndex = 15;
                tlPositions.Columns["MO_multi1"].Visible = isFound_MO;
                tlPositions.Columns["MO_multi2"].Visible = isFound_MO;
                tlPositions.Columns["MO_multi3"].Visible = isFound_MO;
                tlPositions.Columns["MO_multi4"].Visible = isFound_MO;

                tlPositions.Columns["MA_einkaufspreis"].VisibleIndex = 16;
                tlPositions.Columns["MO_Einkaufspreis"].VisibleIndex = 17;
                tlPositions.Columns["MA_einkaufspreis"].Visible = isFound_Einfr;
                tlPositions.Columns["MO_Einkaufspreis"].Visible = isFound_Einfr;

                tlPositions.Columns["MA_selbstkostenMulti"].VisibleIndex = 18;
                tlPositions.Columns["MA_selbstkosten"].VisibleIndex = 19;
                tlPositions.Columns["MO_selbstkostenMulti"].VisibleIndex = 20;
                tlPositions.Columns["MO_selbstkosten"].VisibleIndex = 21;
                tlPositions.Columns["MA_selbstkostenMulti"].Visible = isFound_Seleb;
                tlPositions.Columns["MO_selbstkostenMulti"].Visible = isFound_Seleb;
                tlPositions.Columns["MA_selbstkosten"].Visible = isFound_Seleb;
                tlPositions.Columns["MO_selbstkosten"].Visible = isFound_Seleb;

                tlPositions.Columns["MA_verkaufspreis_Multi"].VisibleIndex = 22;
                tlPositions.Columns["MA_verkaufspreis"].VisibleIndex = 23;
                tlPositions.Columns["MO_verkaufspreisMulti"].VisibleIndex = 24;
                tlPositions.Columns["MO_verkaufspreis"].VisibleIndex = 25;
                tlPositions.Columns["MA_verkaufspreis_Multi"].Visible = isFound_Verkf;
                tlPositions.Columns["MO_verkaufspreisMulti"].Visible = isFound_Verkf;
                tlPositions.Columns["MA_verkaufspreis"].Visible = isFound_Verkf;
                tlPositions.Columns["MO_verkaufspreis"].Visible = isFound_Verkf;

                tlPositions.Columns["EP"].VisibleIndex = 26;
                tlPositions.Columns["GB"].VisibleIndex = 27;
                tlPositions.BestFitColumns();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        #region MULTIES


        private void btnMulti5LoadArticles_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEMulti == null)
                    ObjEMulti = new EMulti();
                if (ObjBMulti == null)
                    ObjBMulti = new BMulti();
                ObjEMulti.ProjectID = ObjEProject.ProjectID;
                ObjEMulti.LVSection = cmbLVSectionFilter.Text;
                ObjEMulti = ObjBMulti.GetArticleGroups(ObjEMulti);
                gcMulti5.DataSource = ObjEMulti.dtArticles;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnMulti5UpdateSelbekosten_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEMulti == null)
                    ObjEMulti = new EMulti();
                if (ObjBMulti == null)
                    ObjBMulti = new BMulti();
                ObjEMulti.ProjectID = ObjEProject.ProjectID;
                ObjEMulti.LVSection = cmbLVSectionFilter.Text;
                ObjEMulti = ObjBMulti.UpdateMulti5(ObjEMulti);
                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("Vorgang abgeschlossen:Speichern der Selbstkosten");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("Selbstkosten Saved Successfully");
                }
            }
            catch (Exception EX)
            {
                Utility.ShowError(EX);
            }
        }

        private void btnMulti6LoadArticles_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEMulti == null)
                    ObjEMulti = new EMulti();
                if (ObjBMulti == null)
                    ObjBMulti = new BMulti();
                ObjEMulti.ProjectID = ObjEProject.ProjectID;
                ObjEMulti.LVSection = cmbMulti6LVFilter.Text;
                ObjEMulti.Type = cmbType.Text;
                ObjEMulti = ObjBMulti.GetArticleGroupsForMulti6(ObjEMulti);
                gcMulti6.DataSource = ObjEMulti.dtArticles;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvMulti5_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (ObjEMulti == null)
                    ObjEMulti = new EMulti();

                if (ObjEMulti.dtArticles != null && ObjEMulti.dtArticles.Rows.Count > 0)
                {
                    string strTag = (e.Item as GridSummaryItem).Tag.ToString();
                    if (strTag.ToLower() == "xfactor")
                    {
                        e.TotalValue = GetWeightedPercentage("XValue", strTag);
                    }
                    else if (strTag.ToLower() == "sfactor")
                    {
                        e.TotalValue = GetWeightedPercentage("SValue", strTag);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private decimal GetWeightedPercentage(string strValue, string strFactor)
        {
            decimal newTotalValue = 0;
            decimal OldTotalValue = 0;
            decimal TotalValue = 0;
            try
            {
                foreach (DataRow dr in ObjEMulti.dtArticles.Rows)
                {
                    decimal XValue = 0;
                    decimal xFactor = 0;
                    if (decimal.TryParse(dr[strFactor].ToString(), out xFactor))
                    {
                        if (xFactor == 0)
                        {
                            if (decimal.TryParse(dr[strValue].ToString(), out XValue))
                            {
                                newTotalValue += XValue;
                            }
                        }
                        else
                        {
                            if (decimal.TryParse(dr[strValue].ToString(), out XValue))
                            {
                                newTotalValue += (XValue * xFactor);
                            }
                        }
                    }
                    else
                    {
                        if (decimal.TryParse(dr[strValue].ToString(), out XValue))
                        {
                            newTotalValue += XValue;
                        }
                    }
                    XValue = 0;
                    if (decimal.TryParse(dr[strValue].ToString(), out XValue))
                    {
                        OldTotalValue += XValue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            if (OldTotalValue > 0)
            {
                TotalValue = ((newTotalValue / OldTotalValue) - 1) * 100;
            }
            return TotalValue;
        }

        private void btnMulti6UpdateSelbekosten_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEMulti == null)
                    ObjEMulti = new EMulti();
                if (ObjBMulti == null)
                    ObjBMulti = new BMulti();
                ObjEMulti.ProjectID = ObjEProject.ProjectID;
                ObjEMulti.LVSection = cmbMulti6LVFilter.Text;
                ObjEMulti.Type = cmbType.Text;
                ObjEMulti = ObjBMulti.UpdateMulti6(ObjEMulti);
                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der Verkaufskosten");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("Verkaufskosten Saved Successfully");
                }
            }
            catch (Exception EX)
            {
                Utility.ShowError(EX);
            }
        }

        private void cmbLVSectionFilter_Closed(object sender, ClosedEventArgs e)
        {
            try
            {
                btnMulti5LoadArticles_Click(null, null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        private void EnableAndDisableAllControls(bool result)
        {
            txtStufe1Short.Enabled = result;
            txtStufe2Short.Enabled = result;
            txtStufe3Short.Enabled = result;
            txtStufe4Short.Enabled = result;
            txtPosition.Enabled = result;
            txtWG.Enabled = result;
            txtWA.Enabled = result;
            txtWI.Enabled = result;
            cmbME.Enabled = result;
            txtMenge.Enabled = result;
            txtFabrikate.Enabled = result;
            txtLiefrantMA.Enabled = result;
            cmbPositionKZ.Enabled = result;
            txtType.Enabled = result;
            txtDetailKZ.Enabled = result;
            txtDim1.Enabled = result;
            txtDim2.Enabled = result;
            txtDim3.Enabled = result;
            txtMin.Enabled = result;
            txtFaktor.Enabled = result;
            txtMa.Enabled = result;
            txtMo.Enabled = result;
            txtPreisText.Enabled = result;
            btnDocuwareLink.Enabled = result;
            txtLPMe.Enabled = result;
            txtMulti1ME.Enabled = result;
            txtMulti2ME.Enabled = result;
            txtMulti3ME.Enabled = result;
            txtMulti4ME.Enabled = result;
            txtSelbstkostenMultiME.Enabled = result;
            txtVerkaufspreisMultiME.Enabled = result;
            txtMulti1MO.Enabled = result;
            txtMulti2MO.Enabled = result;
            txtMulti3MO.Enabled = result;
            txtMulti4MO.Enabled = result;
            txtSelbstkostenMultiMO.Enabled = result;
            txtVerkaufspreisMultiMO.Enabled = result;
            chkEinkaufspreisME.Enabled = result;
            chkSelbstkostenME.Enabled = result;
            chkVerkaufspreisME.Enabled = result;
            chkEinkaufspreisMO.Enabled = result;
            chkSelbstkostenMO.Enabled = result;
            chkVerkaufspreisMO.Enabled = result;
        }


        private void btnAddedCost_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEUmlage == null)
                    ObjEUmlage = new EUmlage();
                if (ObjBUmlage == null)
                    ObjBUmlage = new BUmlage();
                ObjEUmlage.ProjectID = ObjEProject.ProjectID;
                if (ObjEUmlage.dtSpecialCost.Rows.Count > 0)
                {
                    btnUmlageSave_Click(null, null);
                    ObjEUmlage = ObjBUmlage.UpdateSpecialCost(ObjEUmlage);
                    if (Utility._IsGermany == true)
                    {
                        frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Aktualisierung der Umlage");
                    }
                    else
                    {
                        frmOTTOPro.UpdateStatus("Umlage Updated Successfully");
                    }
                }
                else
                {
                    if (Utility._IsGermany == true)
                    {
                        throw new Exception("Bitte fügen Sie Generelle Kosten zur Verteilung hinzu");
                    }
                    else
                    {
                        throw new Exception("Add special cost to distribute");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtKundeNo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                frmSelectCustomer frm = new frmSelectCustomer();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    txtKundeNo.Text = frm.CustomerID;
                    txtKundeName.Text = frm.FullName;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cmbBulkProcessSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBulkProcessSelection.SelectedIndex == 2)
                {
                    gvAddRemovePositions.Enabled = false;
                    txtBulkProcessWG.Enabled = true;
                    txtBulkProcessWA.Enabled = true;
                }
                else
                {
                    gvAddRemovePositions.Enabled = true;
                    txtBulkProcessWG.Enabled = false;
                    txtBulkProcessWA.Enabled = false;
                }
                if (ObjEPosition.dsPositionOZList != null)
                {
                    gvAddRemovePositions.Rows.Clear();
                    tlBulkProcessPositionDetails.DataSource = null;
                }

                radioGroupActionA.SelectedIndex = 1;
                radioGroupActionB.SelectedIndex = 1;
                radioGroupActionA_SelectedIndexChanged(null, null);
                radioGroupActionB_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
            txtBulkProcessWG.Text = "";
            txtBulkProcessWA.Text = "";
        }

        private void btnSubmitProposal_Click(object sender, EventArgs e)
        {
            frmDesignReport Obj = new frmDesignReport(ObjEProject.ProjectID);
            Obj.ShowDialog();
        }

        private void txtType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ObjBPosition == null)
                    ObjBPosition = new BPosition();
                if (ObjEPosition == null)
                    ObjEPosition = new EPosition();
                ObjEPosition.Type = txtType.Text;
                ObjEPosition.ValidityDate = ObjEProject.SubmitDate;
                ObjEPosition = ObjBPosition.GetArticleByTyp(ObjEPosition);
                if (ObjEPosition.dtDimensions != null && ObjEPosition.dtDimensions.Rows.Count > 0)
                {
                    if (ObjEPosition.dtDimensions.Rows.Count > 1)
                    {
                        frmSelectDimension Obj = new frmSelectDimension();
                        Obj.ObjEPosition = ObjEPosition;
                        Obj.ShowInTaskbar = false;
                        Obj.ShowDialog();
                    }
                    else
                    {
                        ObjEPosition.Dim1 = ObjEPosition.dtDimensions.Rows[0]["A"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[0]["A"].ToString();
                        ObjEPosition.Dim2 = ObjEPosition.dtDimensions.Rows[0]["B"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[0]["B"].ToString();
                        ObjEPosition.Dim3 = ObjEPosition.dtDimensions.Rows[0]["L"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[0]["L"].ToString();
                        ObjEPosition.LPMA = ObjEPosition.dtDimensions.Rows[0]["ListPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(ObjEPosition.dtDimensions.Rows[0]["ListPrice"]);
                        ObjEPosition.Mins = ObjEPosition.dtDimensions.Rows[0]["Minuten"] == DBNull.Value ? 0 : Convert.ToDecimal(ObjEPosition.dtDimensions.Rows[0]["Minuten"]);
                    }
                }

                txtWG.Text = ObjEPosition.WG;
                txtWA.Text = ObjEPosition.WA;
                txtWI.Text = ObjEPosition.WI;
                txtFabrikate.Text = ObjEPosition.Fabricate;
                txtLiefrantMA.Text = ObjEPosition.LiefrantMA;
                cmbME.SelectedIndex = cmbME.Properties.Items.IndexOf(ObjEPosition.ME);
                txtDim1.Text = ObjEPosition.Dim1;
                txtDim2.Text = ObjEPosition.Dim2;
                txtDim3.Text = ObjEPosition.Dim3;
                txtMin.Text = ObjEPosition.Mins.ToString();
                txtFaktor.Text = ObjEPosition.Faktor.ToString();
                txtLPMe.Text = ObjEPosition.LPMA.ToString(); ;
                txtMulti1ME.Text = ObjEPosition.Multi1MA.ToString();
                txtMulti2ME.Text = ObjEPosition.Multi2MA.ToString();
                txtMulti3ME.Text = ObjEPosition.Multi3MA.ToString();
                txtMulti4ME.Text = ObjEPosition.Multi4MA.ToString();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtType_Leave(null, null);
        }

        private void txtWI_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ObjBPosition == null)
                    ObjBPosition = new BPosition();
                if (ObjEPosition == null)
                    ObjEPosition = new EPosition();

                ObjEPosition.WG = txtWG.Text;
                ObjEPosition.WA = txtWA.Text;
                ObjEPosition.WI = txtWI.Text;
                ObjEPosition.ValidityDate = ObjEProject.SubmitDate;
                ObjEPosition = ObjBPosition.GetArticleByWI(ObjEPosition);
                if (ObjEPosition.dtDimensions != null && ObjEPosition.dtDimensions.Rows.Count > 0)
                {
                    if(ObjEPosition.dtDimensions.Rows.Count > 1)
                    {
                        frmSelectDimension Obj = new frmSelectDimension();
                        Obj.ObjEPosition = ObjEPosition;
                        Obj.ShowInTaskbar = false;
                        Obj.ShowDialog();
                    }
                    else
                    {
                        ObjEPosition.Dim1 = ObjEPosition.dtDimensions.Rows[0]["A"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[0]["A"].ToString();
                        ObjEPosition.Dim2 = ObjEPosition.dtDimensions.Rows[0]["B"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[0]["B"].ToString();
                        ObjEPosition.Dim3 = ObjEPosition.dtDimensions.Rows[0]["L"] == DBNull.Value ? "" : ObjEPosition.dtDimensions.Rows[0]["L"].ToString();
                        ObjEPosition.LPMA = ObjEPosition.dtDimensions.Rows[0]["ListPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(ObjEPosition.dtDimensions.Rows[0]["ListPrice"]);
                        ObjEPosition.Mins = ObjEPosition.dtDimensions.Rows[0]["Minuten"] == DBNull.Value ? 0 : Convert.ToDecimal(ObjEPosition.dtDimensions.Rows[0]["Minuten"]);
                    }
                }
                txtType.Text = ObjEPosition.Type;
                txtFabrikate.Text = ObjEPosition.Fabricate;
                txtLiefrantMA.Text = ObjEPosition.LiefrantMA;
                cmbME.SelectedIndex = cmbME.Properties.Items.IndexOf(ObjEPosition.ME);
                txtMulti1ME.Text = ObjEPosition.Multi1MA.ToString();
                txtMulti2ME.Text = ObjEPosition.Multi2MA.ToString();
                txtMulti3ME.Text = ObjEPosition.Multi3MA.ToString();
                txtMulti4ME.Text = ObjEPosition.Multi4MA.ToString();
                txtFaktor.Text = ObjEPosition.Faktor.ToString();
                txtDim1.Text = ObjEPosition.Dim1;
                txtDim2.Text = ObjEPosition.Dim2;
                txtDim3.Text = ObjEPosition.Dim3;
                txtMin.Text = ObjEPosition.Mins.ToString();
                txtLPMe.Text = ObjEPosition.LPMA.ToString();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtWI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar) != '\b')
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter)
                txtWI_Leave(null, null);
        }

        private void txtDim1_Leave(object sender, EventArgs e)
        {
            if (ObjBPosition == null)
                ObjBPosition = new BPosition();
            if (ObjEPosition == null)
                ObjEPosition = new EPosition();

            ObjEPosition.WG = txtWG.Text;
            ObjEPosition.WA = txtWA.Text;
            ObjEPosition.WI = txtWI.Text;
            ObjEPosition.Dim1 = txtDim1.Text;
            ObjEPosition.Dim2 = txtDim2.Text;
            ObjEPosition.Dim3 = txtDim3.Text;
            ObjEPosition.ValidityDate = ObjEProject.SubmitDate;
            ObjEPosition = ObjBPosition.GetArticleByDimension(ObjEPosition);
            txtMin.Text = ObjEPosition.Mins.ToString();
            txtFaktor.Text = ObjEPosition.Faktor.ToString();
            txtLPMe.Text = ObjEPosition.LPMA.ToString(); ;
        }

        private void txtDim1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar) != '\b')
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter)
                txtDim1_Leave(null, null);
        }

        private void navBarItemConsolidateBlatt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                rptConsolidatedBlatt rpt = new rptConsolidatedBlatt();
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                rpt.Parameters["ProjectID"].Value = ObjEProject.ProjectID;
                printTool.ShowRibbonPreview();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        #region "NavigationBar Events"

        private void navBarItemProject_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (ObjEProject.IsFinalInvoice && Utility.ProjectDataAccess == "7")
                btnProjectSave.Enabled = false;
            ObjTabDetails = tbProjectDetails;
            TabChange(ObjTabDetails);
            ObjBProject.GetProjectDetails(ObjEProject);
        }

        private void navBarItemLVDetails_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tlPositions.Cursor = Cursors.Default;
            if (ObjEProject.ProjectID > 0)
            {
                setMask();
                IntializeLVPositions();
                SetOhnestuffeMask();
                ObjTabDetails = tbLVDetails;
                if (tbLVDetails.PageVisible == false)
                {
                    BindPositionData();
                    tlPositions.BestFitColumns();
                }
                if (tlPositions.Nodes != null && tlPositions.Nodes.Count > 0)
                {
                    tlPositions.SetFocusedNode(tlPositions.MoveLastVisible());
                }
                else
                {
                    btnNext.Enabled = false;
                    btnPrevious.Enabled = false;
                }
                TabChange(ObjTabDetails);
            }
            SetMaskForMaulties();
            if (txtkommissionNumber.Text != "")
            {
                cmbLVSection.Enabled = true;
                btnAddLVSection.Enabled = true;
            }
            else
            {
                cmbLVSection.Enabled = false;
                btnAddLVSection.Enabled = false;
            }
            if (Utility.LVDetailsAccess == "7")
            {
                layoutControl3.Enabled = false;
                btnNew.Enabled = false;
                chkCreateNew.Enabled = false;
                btnSaveLVDetails.Enabled = false;
                btnCancel.Enabled = false;
                LVDetailsColumnReadOnly(true);
            }            
            if (Utility.CalcAccess == "7")
            {
                layoutControl6.Enabled = false;
                LVCalculationColumnReadOnly(true);
                btnSaveLVDetails.Enabled = false;
                btnCancel.Enabled = false;
            }
            if (Utility.LVDetailsAccess == "8")
            {
                LVDetailsColumnReadOnly(false);
            }
            if (Utility.CalcAccess == "8")
            {
                LVCalculationColumnReadOnly(false);
            }
            if(Utility.LVsectionAddAccess == "9" || Utility.LVsectionAddAccess == "7")
            {
                btnAddLVSection.Enabled = false;
                cmbLVSection.Enabled = false;
            }
            if (ObjEProject.IsFinalInvoice)
            {
                btnNew.Enabled = false;
                btnSaveLVDetails.Enabled = false;
                btnCancel.Enabled = false;
                chkCreateNew.Enabled = false;
                tlPositions.OptionsBehavior.Editable = false;
            }    
        }

        private void SetOhnestuffeMask()
        {
            try
            {
                string[] Levels = ObjEProject.LVRaster.Split('.');
                int Count = Levels.Length;
                if (Count >= 2)
                {
                    int _Length = Levels[Count - 2].Length;
                    txtPosition.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    txtPosition.Properties.Mask.EditMask = @"\d{1," + _Length + "}((\\.)\\d{0,1})?";
                    txtPosition.Properties.Mask.UseMaskAsDisplayFormat = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LVDetailsColumnReadOnly(bool _value)
        {
            tlPositions.Columns["WG"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["WA"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["WI"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["Menge"].ColumnEdit.ReadOnly = _value;
        }
        private void LVCalculationColumnReadOnly(bool _value)
        {
            tlPositions.Columns["MA_Multi1"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MA_multi2"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MA_multi3"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MA_multi4"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MA_selbstkostenMulti"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MO_multi1"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MO_multi2"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MO_multi3"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MO_multi4"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MO_selbstkostenMulti"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MA_verkaufspreis_Multi"].ColumnEdit.ReadOnly = _value;
            tlPositions.Columns["MO_verkaufspreisMulti"].ColumnEdit.ReadOnly = _value;
        }

        private void navBarItemBulkProcess_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ObjBProject.GetProjectDetails(ObjEProject);
            if (ObjEProject.ActualLvs == 0)
                return;
            if (GetCommisssionNo() != "")
            {
                checkEditSectionAMulti5MA.Enabled = false;
                checkEditSectionAMulti5MO.Enabled = false;
                checkEditSectionAMulti6MA.Enabled = false;
                checkEditSectionAMulti6MO.Enabled = false;
                btnSaveActionA.Enabled = false;

                //checkEditLVPositionKZ.Enabled = false;
                checkEditPositionMenge.Enabled = false;
                checkEditMaterialKz.Enabled = false;
                checkEditMontageKZ.Enabled = false;
                checkEditPreisErstaztext.Enabled = false;
                checkEditArtikelnummerWG.Enabled = false;
                checkEditFabrikat.Enabled = false;
                checkEditTyp.Enabled = false;
                checkEditLieferantMA.Enabled = false;
                btnSavesectionB.Enabled = false;
                checkEditNachtragsnummer.Enabled = true;
            }
            else
            {
                checkEditSectionAMulti5MA.Enabled = true;
                checkEditSectionAMulti5MO.Enabled = true;
                checkEditSectionAMulti6MA.Enabled = true;
                checkEditSectionAMulti6MO.Enabled = true;
                btnSaveActionA.Enabled = true;

                //checkEditLVPositionKZ.Enabled = true;
                checkEditPositionMenge.Enabled = true;
                checkEditMaterialKz.Enabled = true;
                checkEditMontageKZ.Enabled = true;
                checkEditPreisErstaztext.Enabled = true;
                checkEditArtikelnummerWG.Enabled = true;
                checkEditFabrikat.Enabled = true;
                checkEditTyp.Enabled = true;
                checkEditLieferantMA.Enabled = true;
                btnSavesectionB.Enabled = true;
                checkEditNachtragsnummer.Enabled = false;

            }
            //if (cmbLVStatus.Text == "A")
            //{
            //    if (Utility._IsGermany == true)
            //    {
            //        XtraMessageBox.Show("Die globale LV Bearbeitung wird nicht auf abgelehnte LV Positionen angewandt.");
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Bulk Process should not happend for Rejected LVs.");
            //    }
            //    return;
            //}
            if (ObjEProject.ProjectID > 0)
            {
                tlBulkProcessPositionDetails.Cursor = Cursors.Default;
                ObjTabDetails = tbBulkProcess;
                TabChange(ObjTabDetails);
                tlBulkProcessPositionDetails.BestFitColumns();
            }
            if (Utility.CalcAccess == "7" || ObjEProject.IsFinalInvoice)
                btnApply.Enabled = false;
             if(!string.IsNullOrEmpty(ObjEProject.CommissionNumber))
            { 
                if (Utility.LVsectionAddAccess == "9" || Utility.LVsectionAddAccess == "7"
                     || Utility.LVSectionEditAccess == "9" || Utility.LVSectionEditAccess == "7")
                    btnApply.Enabled = false;
            }
        }

        private void navBarItemMulti5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                ObjBProject.GetProjectDetails(ObjEProject);
                if (ObjEProject.ProjectID > 0 && ObjEProject.ActualLvs > 0)
                {
                    ObjTabDetails = tbMulti5;
                    TabChange(ObjTabDetails);                    

                    if (objBGAEB == null)
                        objBGAEB = new BGAEB();
                    DataTable dtLVSection = new DataTable();
                    cmbLVSectionFilter.Properties.Items.Clear();
                    dtLVSection = objBGAEB.GetLVSection(ObjEProject.ProjectID);
                    foreach (DataRow dr in dtLVSection.Rows)
                    {
                        if (Utility.LVSectionEditAccess == "7")
                        {
                            if (Convert.ToString(dr["LVSection"]).ToLower() == "ha")
                                cmbLVSectionFilter.Properties.Items.Add(dr["LVSection"]);
                        }
                        else
                            cmbLVSectionFilter.Properties.Items.Add(dr["LVSection"]);
                    }
                    cmbLVSectionFilter.SetEditValue("HA");

                    btnMulti5LoadArticles_Click(null, null);
                    gvMulti5.BestFitColumns();
                    if (Utility.CalcAccess == "7" || ObjEProject.IsFinalInvoice)
                        btnMulti5UpdateSelbekosten.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void navBarItemMulti6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                ObjBProject.GetProjectDetails(ObjEProject);
                if (ObjEProject.ProjectID > 0 && ObjEProject.ActualLvs > 0)
                {
                    ObjTabDetails = tbMulti6;
                    TabChange(ObjTabDetails);

                   
                    if (objBGAEB == null)
                        objBGAEB = new BGAEB();
                    DataTable dtLVSection = new DataTable();
                    cmbMulti6LVFilter.Properties.Items.Clear();
                    gcMulti6.DataSource = null;
                    dtLVSection = objBGAEB.GetLVSection(ObjEProject.ProjectID);
                    foreach (DataRow dr in dtLVSection.Rows)
                    {
                        if (Utility.LVSectionEditAccess == "7")
                        {
                            if (Convert.ToString(dr["LVSection"]).ToLower() == "ha")
                                cmbMulti6LVFilter.Properties.Items.Add(dr["LVSection"]);
                        }
                        else
                            cmbMulti6LVFilter.Properties.Items.Add(dr["LVSection"]);
                    }
                    cmbMulti6LVFilter.SetEditValue("HA");
                    cmbType.SelectedIndex = 1;

                    btnMulti6LoadArticles_Click(null, null);
                    gvMulti6.BestFitColumns();
                    if (Utility.CalcAccess == "7" || ObjEProject.IsFinalInvoice)
                        btnMulti6UpdateSelbekosten.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void navBarItemExport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                ObjBProject.GetProjectDetails(ObjEProject);
                if (ObjEProject.IsFinalInvoice)
                    return;
                BindPositionData();
                if (ObjEProject.ActualLvs == 0)
                {
                    if (Utility._IsGermany == true)
                        XtraMessageBox.Show("Es liegen keine LV Positionen für den Export vor!");
                    else
                        XtraMessageBox.Show("No LV Positions to Export.!");
                    return;
                }
                if (ObjEProject.ProjectID > 0)
                {
                    if (objBGAEB == null)
                        objBGAEB = new BGAEB();
                    if (objEGAEB == null)
                        objEGAEB = new EGAEB();
                    string SelectedRaster = ObjEProject.LVRaster;
                    objEGAEB.OldRaster = objBGAEB.GetOld_Raster(ObjEProject.ProjectID);
                    if (objEGAEB.OldRaster != "")
                    {
                        objEGAEB.NewRaster = ObjEProject.LVRaster;
                        frmSelectRaster frm = new frmSelectRaster(objEGAEB);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            SelectedRaster = frm.LVRaster;
                        else
                            return;
                    }
                    int raster_count = SelectedRaster.Replace(".", string.Empty).Length;
                    frmGAEBExport Obj = new frmGAEBExport(ObjEProject.ProjectNumber, ObjEProject.ProjectID, raster_count, SelectedRaster);
                    Obj.KNr = ObjEProject.CommissionNumber;
                    Obj.ShowDialog();
                    if (File.Exists(Obj.OutputFilePath))
                        Process.Start("explorer.exe", "/select, \"" + Obj.OutputFilePath + "\"");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void navBarItemImport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                if (ObjEProject.ProjectID > 0)
                {
                    if (ObjEProject.IsFinalInvoice)
                        return;
                    frmGAEBImport Obj = new frmGAEBImport();
                    Obj.ProjectID = ObjEProject.ProjectID;
                    Obj.KNr = ObjEProject.CommissionNumber;
                    Obj.ShowDialog();
                    ProjectID = Obj.ProjectID;
                    if (ProjectID > 0 && Obj.isbuild)
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                        SplashScreenManager.Default.SetWaitFormDescription("Laden Projekt...");
                        LoadExistingRasters();
                        LoadExistingProject();
                        BindPositionData();
                        IntializeLVPositions();
                        if (ObjEProject.ActualLvs == 0)
                            ChkRaster.Enabled = true;
                        else
                            ChkRaster.Enabled = false;
                        SplashScreenManager.CloseForm(false);
                    }
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                if (Utility._IsGermany == true)
                {
                    throw new Exception("Das ausgewählte Datei-Raster ist nicht mit dem ausgewählten Projektraster kompatibel!");
                }
                else
                {
                    Utility.ShowError(ex);
                }
            }
        }

        private void navBarItemUmlage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                ObjBProject.GetProjectDetails(ObjEProject);
                if (ObjEProject.ProjectID > 0 && ObjEProject.CommissionNumber == string.Empty && ObjEProject.ActualLvs > 0)
                {
                    ObjTabDetails = tbOmlage;
                    TabChange(ObjTabDetails);
                    if (ObjEUmlage == null)
                        ObjEUmlage = new EUmlage();
                    if (ObjBUmlage == null)
                        ObjBUmlage = new BUmlage();
                    ObjEUmlage.ProjectID = ObjEProject.ProjectID;
                    ObjEUmlage = ObjBUmlage.GetSpecialCost(ObjEUmlage);
                    gcOmlage.DataSource = ObjEUmlage.dtSpecialCost;
                    if (Utility.CalcAccess == "7" || ObjEProject.IsFinalInvoice)
                    {
                        btnUmlageSave.Enabled = false;
                        btnAddedCost.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (ObjEProject.ProjectID > 0)
            {
                frmDesignReport Obj = new frmDesignReport(ObjEProject.ProjectID);
                Obj.ShowDialog();
            }           

            //Delivery Notes related report
            //rptDeliveryNotes rpt = new rptDeliveryNotes(ObjEProject.ProjectID, ObjEProject.KundeID);
            //ReportPrintTool printTool = new ReportPrintTool(rpt);
            //// Invoke the Print dialog.
            //printTool.ShowRibbonPreview();
        }

        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                navBarControl1.SelectedLink = e.Link;

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void navBarItemSupplierProposal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                if (ObjEProject.ProjectID > 0)
                {
                    ObjTabDetails = tbSupplierProposal;
                    TabChange(ObjTabDetails);
                    FillLVSection();
                    GetWGWA();

                    ObjESupplier.ProjectID = ObjEProject.ProjectID;
                    ObjESupplier = ObjBSupplier.GetProposalNumber(ObjESupplier);
                    if (Utility.LVSectionEditAccess == "9")
                    {
                        DataView dv = ObjESupplier.dtProposal.DefaultView;
                        dv.RowFilter = "LVSection = 'HA'";
                        gcProposedSupplier.DataSource = dv;
                    }
                    else
                        gcProposedSupplier.DataSource = ObjESupplier.dtProposal;

                    gcDeletedDetails.DataSource=null;
                    gcProposedDetails.DataSource = null;
                    if (Utility.CalcAccess == "7" || ObjEProject.IsFinalInvoice)
                        btnSaveSupplierProposal.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        #endregion

        #region "Delivery Notes Code"
        private void nbDeliveryNotes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                TabChange(tbDeliveryNotes);
                if (ObjEDeliveryNotes == null)
                    ObjEDeliveryNotes = new EDeliveryNotes();
                if (ObjBDeliveryNotes == null)
                    ObjBDeliveryNotes = new BDeliveryNotes();
                chkActiveDelivery.Checked = true;
                ObjEDeliveryNotes.ProjectID = ObjEProject.ProjectID;
                ObjEDeliveryNotes = ObjBDeliveryNotes.GetPositions(ObjEDeliveryNotes);
                gcPositions.DataSource = ObjEDeliveryNotes.dtPositions;
                NewBlattnumber();
                LoadNonActiveDelivery();
                ObjEDeliveryNotes = ObjBDeliveryNotes.GetBlattNumbers(ObjEDeliveryNotes);
                gcDeliveryNumbers.DataSource = ObjEDeliveryNotes.dtBlattNumbers;
                if (Utility.DeliveryAccess == "7" || ObjEProject.IsFinalInvoice)
                    btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcPositions_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(DataRow)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcPositions_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (Utility.DeliveryAccess == "7" && ObjEProject.IsFinalInvoice)
                    return;
                int MaxValue = 0;
                GridControl grid = sender as GridControl;
                DataTable table = grid.DataSource as DataTable;

                foreach (int i in gvPositions.GetSelectedRows())
                {
                    DataRow row = gvPositions.GetDataRow(i);
                    if (row != null && table != null && row.Table != table)
                    {
                        object strPositionID = row["PositionID"].ToString();
                        DataRow[] foundRows = table.Select("PositionID = '" + strPositionID + "'");
                        if (table.Rows.Count > 0)
                        {
                            MaxValue = Convert.ToInt32(table.Compute("MAX([SNO])", string.Empty));
                        }
                        if (foundRows.Count() <= 0)
                        {

                            DataRow drTemp = table.NewRow();
                            drTemp.ItemArray = row.ItemArray.Clone() as object[];
                            drTemp["Menge"] = 0;
                            drTemp["SNO"] = MaxValue + 1;
                            table.Rows.Add(drTemp);
                            Utility.Setfocus(gvDelivery, "PositionID", Convert.ToInt32(strPositionID));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvPositions_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Button == MouseButtons.Left && downHitInfo != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                        downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                        view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                        downHitInfo = null;
                        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvPositions_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                downHitInfo = null;
                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                if (Control.ModifierKeys != Keys.None) return;
                if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                    downHitInfo = hitInfo;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDelivery_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvDelivery.FocusedColumn != null)
                {
                    string strPosition = gvDelivery.GetFocusedRowCellValue("Position_OZ") == DBNull.Value ? "" : gvDelivery.GetFocusedRowCellValue("Position_OZ").ToString();
                    lblSelectedLVPosition.Text = "Ausgewählte LV Positionen  : " + strPosition;
                    txtOrderedQnty.Text = gvDelivery.GetFocusedRowCellValue("OrderedQuantity") == DBNull.Value ? "" : gvDelivery.GetFocusedRowCellValue("OrderedQuantity").ToString();
                    txtDeliveredQnty.Text = gvDelivery.GetFocusedRowCellValue("DeliveredQuantity") == DBNull.Value ? "" : gvDelivery.GetFocusedRowCellValue("DeliveredQuantity").ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBlattNumber.Text))
                    if (!Utility._IsGermany)
                    {
                        throw new Exception("Bitte geben Sie eine BLATT Nummer an");
                    }
                    else
                    {
                        throw new Exception("Please Enter Blatt Number");
                    }
                if (gvDelivery.RowCount == 0)
                {
                    if (!Utility._IsGermany)
                        throw new Exception("Select Positions for Delivery");
                    else
                        throw new Exception("Bitte wählen Sie LV Positionen für das Aufmass");
                }
                if (!chkActiveDelivery.Checked)
                {
                    string strConfirmation = XtraMessageBox.Show("Wollen Sie dies als nicht-aktives Aufmass abspeichern?", "Frage"
                            , MessageBoxButtons.OKCancel, MessageBoxIcon.Question).ToString();
                    if (strConfirmation.ToLower() == "cancel")
                        return;
                }
                if (ObjEDeliveryNotes == null)
                    ObjEDeliveryNotes = new EDeliveryNotes();
                if (ObjBDeliveryNotes == null)
                    ObjBDeliveryNotes = new BDeliveryNotes();
                ObjEDeliveryNotes.BlattName = txtBlattNumber.Text;
                ObjEDeliveryNotes.ISActiveDelivery = chkActiveDelivery.Checked == true ? true : false;
                DataTable table = gcDelivery.DataSource as DataTable;

                DataTable Temp = table.Copy();
                Temp.Columns.Remove("Position_OZ");
                Temp.Columns.Remove("PositionKZ");
                Temp.Columns.Remove("Ordered");
                Temp.Columns.Remove("ShortDescription");
                Temp.Columns.Remove("OrderedQuantity");
                Temp.Columns.Remove("RemainingQuantity");
                Temp.Columns.Remove("DeliveredQuantity");
                Temp.Columns.Remove("LVSection");
                Temp.Columns.Remove("LVStatus");
                ObjEDeliveryNotes.dtDelivery = Temp;

                ObjEDeliveryNotes = ObjBDeliveryNotes.SaveDelivery(ObjEDeliveryNotes);
                frmOTTOPro.UpdateStatus("'" + txtBlattNumber.Text + "'" + " wurde erfolgreich gespeichert");
                if (chkActiveDelivery.Checked == false)
                    LoadNonActiveDelivery();
                else
                {
                    table.Rows.Clear();
                    txtDeliveredQnty.Text = string.Empty;
                    txtOrderedQnty.Text = string.Empty;
                    lblSelectedLVPosition.Text = "Ausgewählte LV Positionen  : ";
                    gcDeliveryNumbers.DataSource = ObjEDeliveryNotes.dtBlattNumbers;
                    gcPositions.DataSource = ObjEDeliveryNotes.dtPositions;
                    Utility.Setfocus(gvDeliveryNumbers, "BlattID", ObjEDeliveryNotes.BlattID);
                    ObjEDeliveryNotes.BlattID = -1;
                    SNO = 1;
                    NewBlattnumber();
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDelivery_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                double dValue = 0;
                double OrderedQuantity = 0;
                double RemainingQuantity = 0;
                double notSavedQnty = 0;
                double AvailedQnty = 0;
                double DeliveredQnty = 0;

                string sPositionID = gvDelivery.GetFocusedRowCellValue("PositionID").ToString();
                if (double.TryParse(gvDelivery.GetFocusedRowCellValue("OrderedQuantity").ToString(), out dValue))
                    OrderedQuantity = dValue;
                if (double.TryParse(gvDelivery.GetFocusedRowCellValue("RemainingQuantity").ToString(), out dValue))
                    RemainingQuantity = dValue;
                if (double.TryParse(gvDelivery.GetFocusedRowCellValue("DeliveredQuantity").ToString(), out dValue))
                    DeliveredQnty = dValue;
                DataTable table = gcDelivery.DataSource as DataTable;
                int i = e.RowHandle;
                string str = table.Rows[i][e.Column.FieldName] == DBNull.Value ? "" : table.Rows[i][e.Column.FieldName].ToString();
                if (string.IsNullOrEmpty(str))
                    table.Rows[i][e.Column.FieldName] = 0;
                notSavedQnty = Convert.ToDouble(table.Compute("SUM(Menge)", "PositionID = " + sPositionID));
                AvailedQnty = RemainingQuantity + (OrderedQuantity * 0.1);
                if (DeliveredQnty + notSavedQnty < 0)
                {
                    table.Rows[i][e.Column.FieldName] = 0;
                    throw new Exception("Total Quantity not matching Delivered Quantity");
                }
                else
                {
                    if (notSavedQnty != 0 && notSavedQnty > AvailedQnty)
                    {
                        if (!Utility._IsGermany)
                            XtraMessageBox.Show("Total Quantity Exceeding Ordered Quantity");
                        else
                            XtraMessageBox.Show("Die Gesamtmenge übersteigt die beauftragte Menge");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void LoadNonActiveDelivery()
        {
            try
            {
                ObjEDeliveryNotes = ObjBDeliveryNotes.GetNonActiveDelivery(ObjEDeliveryNotes);
                if (ObjEDeliveryNotes.dtNonActivedelivery.Rows.Count > 0)
                {
                    txtBlattNumber.Text = ObjEDeliveryNotes.BlattName;
                    chkActiveDelivery.Checked = false;
                    gcDelivery.DataSource = ObjEDeliveryNotes.dtNonActivedelivery;
                    SNO = ObjEDeliveryNotes.dtNonActivedelivery.Rows.Count;
                }
                else
                {
                    gcDelivery.DataSource = ObjEDeliveryNotes.dtPositions.Clone();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvDelivery_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gcDeliveryDelete_ItemClick));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcDeliveryDelete_ItemClick(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = gvDelivery.FocusedRowHandle;
                DataTable table = gcDelivery.DataSource as DataTable;
                table.Rows.RemoveAt(iRowHandle);

                int SNo = 1;
                foreach(DataRow row in table.Rows)
                {                    
                    row["SNO"] = SNo;
                    SNo++;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void NewBlattnumber()
        {
            try
            {
                ObjEDeliveryNotes = ObjBDeliveryNotes.GetNewBlattNumber(ObjEDeliveryNotes);
                txtBlattNumber.Text = ObjEDeliveryNotes.BlattName;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvDeliveryNumbers_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    if(gvDeliveryNumbers.FocusedRowHandle != null)
                    {
                        string str = gvDeliveryNumbers.GetFocusedRowCellValue("IsInvoiced").ToString();
                        if (str.ToLower() != "ja" && gvDelivery.RowCount <= 0)
                        {
                            if (Utility.DeliveryAccess != "7" && !ObjEProject.IsFinalInvoice)
                                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Ã„ndern", gcBlattEdit_Click));
                        }
                    }
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Aufmaß mit Adresskopf", gcBlattViewAddress_Click));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Aufmaß ohne Adresskopf, mit LV Positionsnr", gcBlattViewWithouAddress_Click));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        DXMenuItem CreateItem(string caption)
        {
            return new DXMenuItem(caption);
        }

        DXSubMenuItem CreateSubItem(string caption)
        {
            return new DXSubMenuItem(caption);
        }
        private void gcBlattEdit_Click(object sender, EventArgs e)
        {
            try
            {
               if(gvDeliveryNumbers.FocusedRowHandle != null)
               {
                   int IValue = 0;
                   string strBlattID = gvDeliveryNumbers.GetFocusedRowCellValue("BlattID").ToString();
                   if (int.TryParse(strBlattID, out IValue))
                   {
                       if (ObjEDeliveryNotes == null)
                           ObjEDeliveryNotes = new EDeliveryNotes();
                       if (ObjBDeliveryNotes == null)
                           ObjBDeliveryNotes = new BDeliveryNotes();
                       ObjEDeliveryNotes.BlattID = IValue;
                       ObjEDeliveryNotes.BlattName = gvDeliveryNumbers.GetFocusedRowCellValue("BlattNumber").ToString();
                       txtBlattNumber.Text = ObjEDeliveryNotes.BlattName;
                       ObjEDeliveryNotes = ObjBDeliveryNotes.GetBlattDetails(ObjEDeliveryNotes);
                       gcDelivery.DataSource = ObjEDeliveryNotes.dtNonActivedelivery;
                       SNO = ObjEDeliveryNotes.dtNonActivedelivery.Rows.Count;
                   }
               }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcBlattViewAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDeliveryNumbers.FocusedRowHandle != null && gvDeliveryNumbers.GetFocusedRowCellValue("BlattID") != null)
                {
                    int IValue = 0;
                    string strBlattID = gvDeliveryNumbers.GetFocusedRowCellValue("BlattID").ToString();
                        if (int.TryParse(strBlattID, out IValue))
                        {
                            rptDeliveryNotes Obj = new rptDeliveryNotes();
                            ReportPrintTool printTool = new ReportPrintTool(Obj);
                            Obj.Parameters["ID"].Value = IValue;
                            Obj.Parameters["ProjectID"].Value = ObjEProject.ProjectID;
                            printTool.ShowRibbonPreview();

                        }
                }               
                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcBlattViewWithouAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDeliveryNumbers.FocusedRowHandle != null && gvDeliveryNumbers.GetFocusedRowCellValue("BlattID") != null)
                {
                    int IValue = 0;
                    string strBlattID = gvDeliveryNumbers.GetFocusedRowCellValue("BlattID").ToString();

                    if (int.TryParse(strBlattID, out IValue))
                    {
                        rptDeliveryNotesWithoutAddress Obj = new rptDeliveryNotesWithoutAddress();
                        ReportPrintTool printTool = new ReportPrintTool(Obj);
                        Obj.Parameters["BlattID"].Value = IValue;
                        Obj.Parameters["ProjectID"].Value = ObjEProject.ProjectID;

                        printTool.ShowRibbonPreview();
                    }                   
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }


        #endregion

        #region "Invoice Changes"

        private void nbInvoices_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                TabChange(tbInvoices);
                if (ObjEInvoice == null)
                    ObjEInvoice = new EInvoice();
                if (oBJBInvoice == null)
                    oBJBInvoice = new BInvoice();
                ObjEInvoice.ProjectID = ObjEProject.ProjectID;
                ObjEInvoice = oBJBInvoice.GeTBlattNumbers(ObjEInvoice);
                gcDeliveryNotes.DataSource = ObjEInvoice.dtBlattNumbers;
                ObjEInvoice = oBJBInvoice.GetInvoices(ObjEInvoice);
                gcInvoices.DataSource = ObjEInvoice.dtInvoices;
                if (Utility.InvoiceAccess == "7" || ObjEProject.IsFinalInvoice)
                    btnGenerate.Enabled = false;
                if (ObjEProject.IsFinalInvoice)
                {
                    chkFinalInvoice.Checked = true;
                    if (Utility.RoleID != 14)
                    {
                        chkFinalInvoice.Enabled = false;
                        btnFinalBill.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInvoiceNumber.Text))
                    throw new Exception("Bitte geben Sie eine Rechnungsnummer ein");
                if (ObjEInvoice == null)
                    ObjEInvoice = new EInvoice();
                if (oBJBInvoice == null)
                    oBJBInvoice = new BInvoice();
                ObjEInvoice.InvoiceID = -1;
                ObjEInvoice.ProjectID = ObjEProject.ProjectID;
                ObjEInvoice.InvoiceNumber = txtInvoiceNumber.Text;
                ObjEInvoice.IsFinalInvoice = chkFinalInvoice.Checked == true ? true : false;
                DataTable dtTemp = ObjEInvoice.dtBlattNumbers.Copy();
                dtTemp.Columns.Remove("BlattNumber");
                dtTemp.Columns.Remove("IsActiveDelivery");
                dtTemp.Columns.Remove("IsInvoiced");
                dtTemp.Columns.Remove("CreatedBy");
                dtTemp.Columns.Remove("CreatedDate");
                dtTemp.Columns.Remove("NoOfPositions");
                ObjEInvoice.dtInvoice = dtTemp;
                ObjEInvoice = oBJBInvoice.SaveInvoice(ObjEInvoice);
                gcDeliveryNotes.DataSource = ObjEInvoice.dtBlattNumbers;
                gcInvoices.DataSource = ObjEInvoice.dtInvoices;
                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("'" + txtInvoiceNumber.Text + "' Vorgang abgeschlossen: Speichern der Rechnung");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("'" + txtInvoiceNumber.Text + "' Invoice Saved Successfully");
                }
                txtInvoiceNumber.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private bool IsDisable(GridView view, int row)
        {
            bool result = false;
            try
            {

                string val = Convert.ToString(view.GetRowCellValue(row, "IsInvoiced"));
                if (val == "Ja")
                    result = true;
                else if (val == "Nein")
                    result = false;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private void gvDeliveryNotes_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvDeliveryNotes.FocusedColumn.FieldName == "SELCETED"
                                && IsDisable(gvDeliveryNotes, gvDeliveryNotes.FocusedRowHandle))
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        #endregion

        #region Supplier Proposal


        private void FillLVSection()
        {
            try
            {
                ObjESupplier = ObjBSupplier.GetLVSectionForProposal(ObjESupplier, ObjEProject.ProjectID);
                if (ObjESupplier.Article != null)
                {
                    if (Utility.LVSectionEditAccess == "9")
                    {
                        DataView dv = ObjESupplier.Article.Tables[0].DefaultView;
                        dv.RowFilter = "LVSection = 'HA'";
                        cmbLVSectionforSupplier.DataSource = dv;
                        cmbLVSectionforSupplier.DisplayMember = "LVSection";
                        cmbLVSectionforSupplier.ValueMember = "LVSection";
                    }
                    else
                    {
                        cmbLVSectionforSupplier.DataSource = ObjESupplier.Article.Tables[0];
                        cmbLVSectionforSupplier.DisplayMember = "LVSection";
                        cmbLVSectionforSupplier.ValueMember = "LVSection";
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        public void GetWGWA()
        {
            try
            {
                if (ObjESupplier.Article != null)
                {                    
                    cmbWGWA.DataSource = null;
                    DataView dvWGWA = ObjESupplier.Article.Tables[1].DefaultView;
                    dvWGWA.RowFilter = "LVSection = '" + cmbLVSectionforSupplier.Text + "'";
                    cmbWGWA.DataSource = dvWGWA;
                    cmbWGWA.DisplayMember = "WGWA";
                    cmbWGWA.ValueMember = "WGWA";
                    cmbWGWA.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetLVDetailsAndSupplier()
        {
            try
            {
                string[] strArr = null;
                char[] splitchar = { '-' };
                strArr = cmbWGWA.SelectedValue.ToString().Split(splitchar);
                for (int count = 0; count <= strArr.Length - 1; count++)
                {
                    _WGforSupplier = strArr[0];
                    _WAforSupplier = strArr[1];
                }

                if (_WGforSupplier != null && _WAforSupplier != null)
                {
                    ObjESupplier = ObjBSupplier.GetWGWAForProposal(ObjESupplier, ObjEProject.ProjectID, cmbLVSectionforSupplier.Text, _WGforSupplier, _WAforSupplier);
                    if (ObjESupplier.dsSupplier != null)
                    {
                        gcLVDetailsforSupplier.DataSource = ObjESupplier.dtNewPositions;
                        gcDeletedDetails.DataSource = ObjESupplier.dtDeletedPositions;
                        gcProposedDetails.DataSource = ObjESupplier.dtProposedPositions;

                        gvLVDetailsforSupplier.BestFitColumns();
                        gvDeletedDetails.BestFitColumns();
                        gvProposedDetails.BestFitColumns();

                        chkSupplierLists.DataSource = ObjESupplier.dsSupplier.Tables[3];
                        chkSupplierLists.DisplayMember = "ShortName";
                        chkSupplierLists.ValueMember = "id";
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void StartProcess(string path)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = path;
                process.Start();
                process.WaitForInputIdle();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ParsePositionDelete()
        {
            int _IDValue = -1;
            try
            {
                if (gvLVDetailsforSupplier.FocusedColumn != null && gvLVDetailsforSupplier.GetFocusedRowCellValue("PositionID") != null)
                {
                    if (int.TryParse(gvLVDetailsforSupplier.GetFocusedRowCellValue("PositionID").ToString(), out _IDValue))
                    {
                        ObjESupplier.PositionID = _IDValue;
                    }
                    ObjESupplier.DeletePositionID = -1;
                    ObjESupplier.ProjectID = ObjEProject.ProjectID;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }       

        private void cmbLVSectionforSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Utility.LVSectionEditAccess == "7")
                {
                    if (cmbLVSectionforSupplier.Text.ToLower() != "ha")
                        btnSaveSupplierProposal.Enabled = false;
                    else if (Utility.CalcAccess != "7")
                        btnSaveSupplierProposal.Enabled = true;
                }
                GetWGWA();
                gcLVDetailsforSupplier.DataSource = null;
                chkSupplierLists.DataSource = null;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbWGWA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                GetLVDetailsAndSupplier();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void chkSupplierLists_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (chkSupplierLists.CheckedItems.Count == 9)
                {
                    Int32 checkedItemIndex = chkSupplierLists.CheckedIndices[0];
                    chkSupplierLists.SetItemChecked(checkedItemIndex, false);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {                
                    Report_Design.rptSupplierProposal rpt = new Report_Design.rptSupplierProposal();
                    ReportPrintTool printTool = new ReportPrintTool(rpt);
                    rpt.Parameters["ProposalID"].Value = _ProposalID;
                    rpt.Parameters["ProjectID"].Value = ObjEProject.ProjectID;

                    saveFileDialog1.FileName = ObjEProject.ProjectNumber;

                    saveFileDialog1.Filter = "PDF Files|*.pdf";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        rpt.ExportToPdf(saveFileDialog1.FileName);
                        StartProcess(saveFileDialog1.FileName);
                        _pdfpath = saveFileDialog1.FileName;
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            StringBuilder strArr = new StringBuilder();
            string delimiter = "";
            try
            {               
                Type officeType = Type.GetTypeFromProgID("Outlook.Application");

                if (officeType == null)
                {
                    throw new Exception("Outlook wird konfiguriert / installiert");
                }
                else
                {
                    Report_Design.rptSupplierProposal rpt = new Report_Design.rptSupplierProposal();
                    ReportPrintTool printTool = new ReportPrintTool(rpt);
                    rpt.Parameters["ProposalID"].Value = _ProposalID;
                    rpt.Parameters["ProjectID"].Value = ObjEProject.ProjectID;

                    saveFileDialog1.FileName = ObjEProject.ProjectNumber;

                    saveFileDialog1.Filter = "PDF Files|*.pdf";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        rpt.ExportToPdf(saveFileDialog1.FileName);
                        _pdfpath = saveFileDialog1.FileName;
                    }
                    
                    Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                    Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                    ObjBSupplier.GetSupplierMail(ObjESupplier,_ProposalID,ObjEProject.ProjectID);
                    if (ObjESupplier.dtSupplierMail.Rows.Count > 0)
                    {
                        foreach (DataRow dr in ObjESupplier.dtSupplierMail.Rows)
                        {

                            if (!string.IsNullOrEmpty(Convert.ToString(dr["Suppliermail"]).Trim()))
                            {
                                strArr.Append(delimiter);
                                strArr.Append(dr["Suppliermail"]);
                                delimiter = ";";                                
                            }                           
                        }
                        if(strArr.ToString().Contains('@'))
                        {
                            mailItem.Subject = "Preisanfrage";
                            mailItem.BCC = strArr.ToString();
                            mailItem.Body = "Bitte stellen Sie uns für beigefügte Anfrage Ihr Preisangebot zur Verfügung";

                            mailItem.Attachments.Add(_pdfpath);
                            mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                            mailItem.Display(false);
                        }
                    }
                }               

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvLVDetailsforSupplier_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", gcLVDetailsDeletefoSupplier_ItemClick));
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        DataTable _DeletedRecords = new DataTable();
        private void gcLVDetailsDeletefoSupplier_ItemClick(object sender, EventArgs e)
        {
            
            try
            {
                int iIndex = gvLVDetailsforSupplier.FocusedRowHandle;

                DataRow dr = gvLVDetailsforSupplier.GetDataRow(gvLVDetailsforSupplier.FocusedRowHandle);
                DataTable _dt = gcDeletedDetails.DataSource as DataTable;
                _dt.ImportRow(dr);

                Utility.Setfocus(gvDeletedDetails, "PositionID", Convert.ToInt32(gvLVDetailsforSupplier.GetFocusedRowCellValue("PositionID").ToString()));
                ObjESupplier.dtNewPositions.Rows.RemoveAt(iIndex);

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvLVDetailsforSupplier_RowStyle(object sender, RowStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    if (gvLVDetailsforSupplier.FocusedColumn != null && gvLVDetailsforSupplier.GetFocusedRowCellValue("PositionID") != null)
            //    {
            //        if (View.Columns["PositionsStatus"] != null)
            //        {
            //            string _status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["PositionsStatus"]);
            //            if (_status == "P")
            //            {
            //                e.Appearance.BackColor = Color.LightPink;
            //            }
            //            if (_status == "D")
            //            {
            //                e.Appearance.BackColor = Color.Salmon;
            //            }
            //            if (_status == "N")
            //            {
            //                e.Appearance.BackColor = Color.LightSeaGreen;
            //            }
            //        }
            //    }

           // }
        }

        private void gvLVDetailsforSupplier_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                downHitInfo = null;
                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                if (Control.ModifierKeys != Keys.None) return;
                if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                    downHitInfo = hitInfo;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvLVDetailsforSupplier_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Button == MouseButtons.Left && downHitInfo != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                        downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                        view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                        downHitInfo = null;
                        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcLVDetailsforSupplier_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (Utility.CalcAccess == "7" || ObjEProject.IsFinalInvoice)
                    return;
                GridControl grid = sender as GridControl;
                DataTable table = grid.DataSource as DataTable;
                DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
                if (row != null && table != null && row.Table != table)
                {
                    object strPositionID = row["PositionID"].ToString();
                    DataRow[] foundRows = table.Select("PositionID = '" + strPositionID + "'");
                    if (foundRows.Count() <= 0)
                    {
                        table.ImportRow(row);
                        string _type =Convert.ToString(row["PositionsStatus"]);
                        if(_type=="D")
                        {
                            DataRow[] result = ObjESupplier.dtDeletedPositions.Select("PositionID = '" + strPositionID + "'");
                            foreach (DataRow dr in result)
                            {                                
                                    ObjESupplier.dtDeletedPositions.Rows.Remove(row);
                            }
                        }
                        Utility.Setfocus(gvLVDetailsforSupplier, "PositionID", Convert.ToInt32(strPositionID));
                    }
                    else
                        throw new Exception("Position Already Exists");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        

        #endregion

        #region Update Supplier

        private void navBarItemUpdateSupplierProposal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                if (ObjEProject.ProjectID > 0)
                {
                    ObjTabDetails = tbUpdateSupplier;
                    TabChange(ObjTabDetails);
                    FillProposalNumbers();
                    cmbWGWA.SelectedIndex = -1;
                    gvProposal_FocusedRowChanged(null, null);
                    gcDeletedDetails.DataSource = null;
                    gcProposedDetails.DataSource = null;
                    if (Utility.CalcAccess == "7" || ObjEProject.IsFinalInvoice)
                    {
                        layoutControl16.Enabled = false;
                        btnSubmit.Enabled = false;
                        gvSupplier.OptionsBehavior.Editable = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void FillProposalNumbers()
        {
            try
            {
                ObjESupplier.ProjectID = ObjEProject.ProjectID;
                ObjESupplier = ObjBSupplier.GetProposalNumber(ObjESupplier);
                if (Utility.LVSectionEditAccess == "9")
                {
                    DataView dv = ObjESupplier.dtProposal.DefaultView;
                    dv.RowFilter = "LVSection = 'HA'";
                    gcProposedSupplier.DataSource = dv;
                }
                else
                    gcProposal.DataSource = ObjESupplier.dtProposal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void gvProposal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvProposal != null && gvProposal.GetFocusedRowCellValue("SupplierProposalID") != null)
                {
                    string strLVSection = Convert.ToString(gvProposal.GetFocusedRowCellValue("LVSection"));
                    if (strLVSection.ToLower() != "ha")
                    {
                        if (Utility.LVSectionEditAccess == "7")
                        {
                            layoutControl16.Enabled = false;
                            btnSubmit.Enabled = false;
                            gvSupplier.OptionsBehavior.Editable = false;
                        }
                    }
                    else
                    {
                        if (!ObjEProject.IsFinalInvoice)
                        {
                            if (Utility.CalcAccess != "7")
                            {
                                layoutControl16.Enabled = true;
                                btnSubmit.Enabled = true;
                                gvSupplier.OptionsBehavior.Editable = true;
                            }
                        }
                    }

                    int iValue = 0;
                    if (int.TryParse(gvProposal.GetFocusedRowCellValue("SupplierProposalID").ToString(), out iValue))
                    {
                        gvSupplier.Columns.Clear();
                        ObjESupplier.SupplierProposalID = iValue;
                        if (radioGroup1.SelectedIndex == 0)
                        {
                            ObjESupplier = ObjBSupplier.GetProposalPostions(ObjESupplier);
                            gcSupplier.DataSource = ObjESupplier.dtPositions;
                        }
                        else
                            radioGroup1.SelectedIndex = 0;
                        if (ObjESupplier.dtPositions != null)
                        {
                            int Columncount = ObjESupplier.dtPositions.Columns.Count;
                            gvSupplier.Columns.ColumnByFieldName("PositionID").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("PositionID1").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("ShortDescription").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("Menge").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("A").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("B").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("L").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("ME").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("MA_Multi1").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("MA_multi2").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("MA_multi3").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("MA_multi4").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("LiefrantMA").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("MA_listprice").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("Fabricate").Visible = false;
                            gvSupplier.Columns.ColumnByFieldName("Cheapest").VisibleIndex = Columncount - 1;
                            gvSupplier.Columns.ColumnByFieldName("Position_OZ").VisibleIndex = 0;
                            gvSupplier.Columns.ColumnByFieldName("Cheapest").OptionsColumn.ReadOnly = true;
                            gvSupplier.Columns.ColumnByFieldName("Position_OZ").OptionsColumn.ReadOnly = true;

                            foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((ColumnView)gcSupplier.Views[0]).Columns)
                            {
                                if (col.FieldName.Contains("Multi") || col.FieldName.Contains("Fabricate") || col.FieldName.Contains("SupplierName"))
                                {
                                    col.Visible = false;
                                }
                                else
                                {
                                    if (col.FieldName.Contains("Check"))
                                    {
                                        string strSupplierColumnName = col.FieldName.Replace("Check", "");
                                        int IColumnIndex = gvSupplier.Columns.ColumnByFieldName(strSupplierColumnName).VisibleIndex;
                                        col.VisibleIndex = IColumnIndex + 1;
                                    }
                                }
                            }
                            CalculateSupplierColumns();
                            gvSupplier.BestFitColumns();
                            gvSupplier_FocusedRowChanged(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iIvalue = e.RowHandle;
                string strColumnboolField = e.Column.FieldName + "Check";
                if (gvSupplier.Columns[strColumnboolField] != null)
                {
                    List<decimal> l = new List<decimal>();
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((ColumnView)gvSupplier).Columns)
                    {
                        if (gvSupplier.Columns[col.FieldName + "Check"] != null)
                        {
                            decimal iValue = 0;
                            string str = Convert.ToString(gvSupplier.GetFocusedRowCellValue(col.FieldName));
                            if (decimal.TryParse(str, out iValue) && iValue > 0)
                            {
                                l.Add(iValue);
                            }
                        }
                    }
                    if (l != null && l.Count() > 0)
                        ObjESupplier.dtPositions.Rows[iIvalue]["Cheapest"] = Math.Round(Convert.ToDecimal(l.Min()),3);
                    else
                        ObjESupplier.dtPositions.Rows[iIvalue]["Cheapest"] = 0.000;

                    SaveListPrice(iIvalue, e.Column.FieldName);
                }
                gvSupplier.UpdateTotalSummary();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.ColumnType == typeof(bool))
                {
                    int iIvalue = e.RowHandle;
                    string strFieldName = e.Column.FieldName;
                    ObjESupplier.dtStrings = new DataTable();
                    ObjESupplier.dtStrings.Columns.Add("Item", typeof(string));
                    if (Convert.ToBoolean(e.Value) == true)
                    {
                        foreach (DataColumn dc in ObjESupplier.dtPositions.Columns)
                        {
                            if (dc.DataType == typeof(bool) && dc.ColumnName != strFieldName)
                            {
                                ObjESupplier.dtPositions.Rows[iIvalue][dc.ColumnName] = false;
                                DataRow drNew = ObjESupplier.dtStrings.NewRow();
                                drNew["Item"] = dc.ColumnName;
                                ObjESupplier.dtStrings.Rows.Add(drNew);
                            }
                        }
                        ObjESupplier.IsSelected = true;
                    }
                    else
                        ObjESupplier.IsSelected = false;
                    ObjESupplier.dtPositions.AcceptChanges();
                    ObjESupplier.PositionID = Convert.ToInt32(gvSupplier.GetFocusedRowCellValue("PositionID"));
                    ObjESupplier.SupplierProposalID = Convert.ToInt32(gvProposal.GetFocusedRowCellValue("SupplierProposalID"));
                    ObjESupplier.SelectedColumn = strFieldName;
                    ObjESupplier = ObjBSupplier.SaveSelection(ObjESupplier);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                if (gvSupplier.FocusedColumn != null)
                {
                    _IsValueChanged = false;
                    string strSuppliercolumnName = gvSupplier.FocusedColumn.FieldName;
                    int iIndex = gvSupplier.FocusedRowHandle;
                    string strBoolColumnName = gvSupplier.FocusedColumn.FieldName + "Check";
                    if (gvSupplier.Columns[strBoolColumnName] != null)
                    {
                        string strPositionOZ = ObjESupplier.dtPositions.Rows[iIndex]["Position_OZ"] == DBNull.Value ? "" :
                            ObjESupplier.dtPositions.Rows[iIndex]["Position_OZ"].ToString();
                        gcNewValues.Text = "spezifische Angaben : " + strPositionOZ + "/" + strSuppliercolumnName;
                        gcExistingValues.Text = "Bestehende Angaben je LV  : " + strPositionOZ + "/" + strSuppliercolumnName;

                        txtNewSupplierName.Text = strSuppliercolumnName;
                        txtNewFabrikate.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Fabricate"] == DBNull.Value ? "" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Fabricate"].ToString();
                        txtNewMulti1.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi1"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi1"].ToString();
                        txtNewMulti2.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi2"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi2"].ToString();
                        txtNewMulti3.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi3"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi3"].ToString();
                        txtNewMulti4.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi4"] == DBNull.Value ? "1" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName + "Multi4"].ToString();
                        txtListPreis.Text = ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName] == DBNull.Value ? "0" :
                            ObjESupplier.dtPositions.Rows[iIndex][strSuppliercolumnName].ToString();
                    }
                    else
                    {
                        txtNewFabrikate.Text = "";
                        txtNewSupplierName.Text = "";
                        txtNewMulti1.Text = "1";
                        txtNewMulti2.Text = "1";
                        txtNewMulti3.Text = "1";
                        txtNewMulti4.Text = "1";
                        txtListPreis.Text = "0";
                        gcNewValues.Text = "Lieferantenspezifische Angaben";
                        gcExistingValues.Text = "Bestehende Angaben je LV ";
                    }
                    _IsValueChanged = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                int iRowindex = gvSupplier.FocusedRowHandle;
                if (iRowindex != null)
                {
                    txtListPrice.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_listprice"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_listprice"].ToString();
                    txtUpdatesuppliertext.Rtf = ObjESupplier.dtPositions.Rows[iRowindex]["ShortDescription"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["ShortDescription"].ToString();
                    txtProposalMenge.Text = ObjESupplier.dtPositions.Rows[iRowindex]["Menge"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["Menge"].ToString();
                    txtProposalDim1.Text = ObjESupplier.dtPositions.Rows[iRowindex]["A"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["A"].ToString();
                    txtProposalDim2.Text = ObjESupplier.dtPositions.Rows[iRowindex]["B"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["B"].ToString();
                    txtProposalDim3.Text = ObjESupplier.dtPositions.Rows[iRowindex]["L"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["L"].ToString();
                    txtME.Text = ObjESupplier.dtPositions.Rows[iRowindex]["ME"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["ME"].ToString();
                    txtMulti1.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi1"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_Multi1"].ToString();
                    txtMulti2.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi2"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi2"].ToString();
                    txtMulti3.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi3"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi3"].ToString();
                    txtMulti4.Text = ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi4"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["MA_multi4"].ToString();
                    txtSupplierName.Text = ObjESupplier.dtPositions.Rows[iRowindex]["LiefrantMA"] == DBNull.Value ? ""
                        : ObjESupplier.dtPositions.Rows[iRowindex]["LiefrantMA"].ToString();
                    gvSupplier_FocusedColumnChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvSupplier.RowCount == 0)
                    return;

                if (radioGroup1.SelectedIndex != 0)
                {
                    if (!Utility._IsGermany)
                        throw new Exception("Please Select List Price Per Unit Proposal View");
                    else
                        throw new Exception("Bitte wählen Sie die Ansicht 'Listenpreise pro Einheit'");
                }
                List<string> LBoolColumns = new List<string>();
                foreach (DataColumn dc in ObjESupplier.dtPositions.Columns)
                {
                    if (dc.ColumnName.Contains("Check"))
                        LBoolColumns.Add(dc.ColumnName);
                }
                foreach (DataRow dr in ObjESupplier.dtPositions.Rows)
                {
                    bool _isContinue = false;
                    foreach (string s in LBoolColumns)
                    {
                        if (Convert.ToBoolean(dr[s]))
                            _isContinue = true;
                    }
                    if (!_isContinue)
                    {
                        if (!Utility._IsGermany)
                            throw new Exception("Some positions are not selected to update the prices");
                        else
                            throw new Exception("Für die Datenübernahme muss für alle LV Positionen ein Lieferant ausgewählt sein");
                    }

                }
                ObjESupplier.ProjectID = ObjEProject.ProjectID;
                ObjESupplier = ObjBSupplier.UpdateSupplierPrice(ObjESupplier);
                frmOTTOPro.UpdateStatus("Preisübersicht für Lieferanten wurde erfolgreich aktualisiert");
                gvProposal_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnSaveTemparary_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvSupplier.RowCount == 0)
                    return;
                if (radioGroup1.SelectedIndex != 0)
                {
                    if (!Utility._IsGermany)
                        throw new Exception("Please Select List Price Per Unit Proposal View");
                    else
                        throw new Exception("Bitte wählen Sie die Ansicht 'Listenpreise pro Einheit'");
                }
                string strSupliercolumnName = gvSupplier.FocusedColumn.FieldName;
                string strBoolColumnName = gvSupplier.FocusedColumn.FieldName + "Check";
                if (gvSupplier.Columns[strBoolColumnName] != null)
                {
                    int iRowIndex = gvSupplier.FocusedRowHandle;
                    ObjESupplier.PositionID = Convert.ToInt32(gvSupplier.GetFocusedRowCellValue("PositionID"));
                    ObjESupplier.SupplierProposalID = Convert.ToInt32(gvProposal.GetFocusedRowCellValue("SupplierProposalID"));
                    ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Fabricate"] = ObjESupplier.Fabrikate = txtNewFabrikate.Text;
                    ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "SupplierName"] = ObjESupplier.SupplierName = txtNewSupplierName.Text;

                    decimal dValue = 1;
                    if (decimal.TryParse(txtListPreis.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName] = ObjESupplier.SupplierPrice = dValue;
                    else
                        ObjESupplier.SupplierPrice = 0;

                    if (decimal.TryParse(txtNewMulti1.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi1"] = ObjESupplier.Multi1 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi1"] = ObjESupplier.Multi1 = 1;

                    if (decimal.TryParse(txtNewMulti2.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi2"] = ObjESupplier.Multi2 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi2"] = ObjESupplier.Multi2 = 1;

                    if (decimal.TryParse(txtNewMulti3.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi3"] = ObjESupplier.Multi3 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi3"] = ObjESupplier.Multi3 = 1;

                    if (decimal.TryParse(txtNewMulti4.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi4"] = ObjESupplier.Multi4 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi4"] = ObjESupplier.Multi4 = 1;
                    if (!chkUpdateAll.Checked)
                        ObjESupplier.IsSingle = true;
                    ObjESupplier = ObjBSupplier.SaveProposaleValues(ObjESupplier);

                    if (chkUpdateAll.Checked)
                    {
                        gvProposal_FocusedRowChanged(null, null);
                        gvSupplier.FocusedRowHandle = iRowIndex;
                        gvSupplier.FocusedColumn = gvSupplier.Columns[strSupliercolumnName];
                        ObjESupplier.IsSingle = false;  
                    }                                              
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (gvProposal.RowCount > 0)
                {
                    RadioGroup edit = sender as RadioGroup;
                    ObjESupplier = ObjBSupplier.ChangeProposalView(ObjESupplier, edit.SelectedIndex);
                    gcSupplier.DataSource = ObjESupplier.dtPositions;

                    CalculateSupplierColumns();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void SaveListPrice(int iRowIndex, string strSupliercolumnName)
        {
            try
            {
                if (radioGroup1.SelectedIndex != 0)
                {
                    if (!Utility._IsGermany)
                        throw new Exception("Please Select List Price Per Unit Proposal View");
                    else
                        throw new Exception("Bitte wählen Sie die Ansicht 'Listenpreise pro Einheit'");
                }
                string strBoolColumnName = strSupliercolumnName + "Check";
                if (gvSupplier.Columns[strBoolColumnName] != null)
                {
                    ObjESupplier.PositionID = Convert.ToInt32(ObjESupplier.dtPositions.Rows[iRowIndex]["PositionID"]);
                    ObjESupplier.SupplierProposalID = Convert.ToInt32(gvProposal.GetFocusedRowCellValue("SupplierProposalID"));
                    ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Fabricate"] = ObjESupplier.Fabrikate = txtNewFabrikate.Text;
                    ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "SupplierName"] = ObjESupplier.SupplierName = txtNewSupplierName.Text;

                    decimal dValue = 1;
                    string strName = Convert.ToString(ObjESupplier.dtPositions.Rows[iRowIndex][txtNewSupplierName.Text]);
                    if (decimal.TryParse(strName, out  dValue))
                        ObjESupplier.SupplierPrice = dValue;
                    else
                        ObjESupplier.SupplierPrice = 0;
                    txtListPreis.Text = ObjESupplier.SupplierPrice.ToString();

                    if (decimal.TryParse(txtNewMulti1.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi1"] = ObjESupplier.Multi1 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi1"] = ObjESupplier.Multi1 = 1;

                    if (decimal.TryParse(txtNewMulti2.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi2"] = ObjESupplier.Multi2 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi2"] = ObjESupplier.Multi2 = 1;

                    if (decimal.TryParse(txtNewMulti3.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi3"] = ObjESupplier.Multi3 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi3"] = ObjESupplier.Multi3 = 1;

                    if (decimal.TryParse(txtNewMulti4.Text, out  dValue))
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi4"] = ObjESupplier.Multi4 = dValue;
                    else
                        ObjESupplier.dtPositions.Rows[iRowIndex][strSupliercolumnName + "Multi4"] = ObjESupplier.Multi4 = 1;
                    ObjESupplier.IsSingle = true;
                    ObjESupplier = ObjBSupplier.SaveProposaleValues(ObjESupplier);
                    ObjESupplier.IsSingle = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CalculateSupplierColumns()
        {
            try
            {
                if (gvProposal.FocusedColumn != null && gvProposal.GetFocusedRowCellValue("SupplierProposalID") != null)
                {
                    string strSupplier = gvProposal.GetFocusedRowCellValue("Supplier") == DBNull.Value ? string.Empty : gvProposal.GetFocusedRowCellValue("Supplier").ToString();
                    if (!string.IsNullOrEmpty(strSupplier))
                    {
                        string[] ShortName = strSupplier.Split(',');
                        int TitleCount = ShortName.Count();

                        foreach (string _str in ShortName)
                        {
                            string _strShort = _str.Trim();
                            gvSupplier.Columns[_strShort].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            gvSupplier.Columns[_strShort].SummaryItem.FieldName = _strShort;
                            gvSupplier.Columns[_strShort].SummaryItem.DisplayFormat = "SUMME= {0:n2}";
                        }
                        gvSupplier.Columns["Cheapest"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gvSupplier.Columns["Cheapest"].SummaryItem.FieldName = "Cheapest";
                        gvSupplier.Columns["Cheapest"].SummaryItem.DisplayFormat = "SUMME= {0:n2}";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion

        #region Copy LVs

        private void nbCopyLVs_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                if (ObjEProject.ProjectID > 0)
                {
                    BindPositionData();
                    if(tlPositions.AllNodesCount >= 2)
                    {
                        ObjTabDetails = tbCopyLVs;
                        TabChange(ObjTabDetails);
                        FillProjectNumber();
                    }
                    else
                    {
                        throw new Exception("Atlease one title and subtitle should be there in the project.");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void FillProjectNumber()
        {
            try
            {
                ObjBProject.GetProjectNumber(ObjEProject);
                if (ObjEProject.dtProjecNumber != null)
                {
                    lookUpEditOldProject.Properties.DataSource = null;
                    lookUpEditOldProject.Properties.DataSource = ObjEProject.dtProjecNumber;
                    lookUpEditOldProject.Properties.DisplayMember = "ProjectNumber";
                    lookUpEditOldProject.Properties.ValueMember = "ProjectID";

                    label25.Text = "New Project : " + ObjEProject.ProjectNumber;
                    ObjBPosition.GetPositionList(ObjEPosition, Convert.ToInt32(ObjEProject.ProjectID));
                    if (ObjEPosition.dsPositionList != null && ObjEPosition.dsPositionList.Tables.Count > 0)
                    {
                        tlNewProject.DataSource = ObjEPosition.dsPositionList.Tables[0];
                        tlNewProject.ParentFieldName = "Parent_OZ";
                        tlNewProject.KeyFieldName = "PositionID";
                        tlNewProject.ForceInitialize();
                        tlNewProject.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        DataSet ds_oldPrj;
        private void lookUpEditOldProject_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ds_oldPrj = ObjBPosition.GetOldPositionList(Convert.ToInt32(lookUpEditOldProject.EditValue));
                if (ds_oldPrj != null && ds_oldPrj.Tables.Count > 0)
                {
                    tlOldProject.DataSource = ds_oldPrj.Tables[0];
                    tlOldProject.ParentFieldName = "Parent_OZ";
                    tlOldProject.KeyFieldName = "PositionID";
                    tlOldProject.ForceInitialize();
                    tlOldProject.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void tlNewProject_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void tlNewProject_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (tlNewProject.Nodes.Count() == 0 || Utility.LVDetailsAccess == "7" || ObjEProject.IsFinalInvoice)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
                DXDragEventArgs args = tlNewProject.GetDXDragEventArgs(e);
                DataRow dataRow = (tlOldProject.GetDataRecordByNode(tlOldProject.FocusedNode) as DataRowView).Row;
                if (dataRow == null) return;
                string _OldPosKZ = dataRow["PositionKZ"] == DBNull.Value ? "" : dataRow["PositionKZ"].ToString();
                int IPositionID = dataRow["PositionID"] == DBNull.Value ? -1 : Convert.ToInt32(dataRow["PositionID"]);
                if (_OldPosKZ == "NG")
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
                TreeListNode node = args.TargetNode;
                if (args.TargetNode == null)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
                string _PosKZ = node["PositionKZ"].ToString();
                int I_index = 0;
                string ParentOZ = string.Empty;
                string Position_OZ = string.Empty;
                if (_PosKZ == "NG")
                {
                    if (rgDropMode.SelectedIndex == 2)
                    {
                        if(!Utility._IsGermany)
                        {
                            throw new Exception("Please select different copy mode");
                        }
                        else
                        {
                            throw new Exception("Bitte wählen Sie einen anderen Kopiermodus");
                        }
                    }
                        
                    string[] _Raster = ObjEProject.LVRaster.Split('.');
                    int _Rastercount = _Raster.Count();
                    ParentOZ = node["Position_OZ"].ToString();
                    string[] _OZ = ParentOZ.Split('.');
                    int _OZCount = _OZ.Count();
                    if (_OZCount != _Rastercount - 1)
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                    string strSelectedOZ = "";
                    string strNO = "";
                    if (rgDropMode.SelectedIndex == 0)
                    {
                        if (node.FirstNode != null)
                        {
                            strNO = Convert.ToString(node.FirstNode["SNO"]);
                            strSelectedOZ = Convert.ToString(node.FirstNode["Position_OZ"]);
                        }
                        int iTemp = 0;
                        if (!int.TryParse(strNO, out iTemp))
                            I_index = 0;
                        else
                            I_index = iTemp - 1;
                    }
                    else if (rgDropMode.SelectedIndex == 1)
                    {
                        if (node.LastNode != null)
                        {
                            strNO = Convert.ToString(node.LastNode["SNO"]);
                            strSelectedOZ = Convert.ToString(node.LastNode["Position_OZ"]);
                        }
                        if (!int.TryParse(strNO, out I_index))
                            I_index = 0;
                    }
                    string _Suggested_OZ = SuggestOZForCopy(strSelectedOZ, "", rgDropMode.SelectedIndex);
                    Position_OZ = ParentOZ + _Suggested_OZ;
                }
                else
                {
                    ParentOZ = Convert.ToString(node.ParentNode.GetValue("Position_OZ"));
                    string strSelectedOZ = "";
                    string strnextLV = "";
                    if (rgDropMode.SelectedIndex == 2)
                    {
                        strSelectedOZ = Convert.ToString(node["Position_OZ"]);
                        int INodeIndex = tlNewProject.GetNodeIndex(node);
                        if (INodeIndex != null)
                        {
                            if (node.ParentNode.Nodes.Count > INodeIndex + 1)
                                strnextLV = Convert.ToString(node.ParentNode.Nodes[INodeIndex + 1]["Position_OZ"]);
                        }
                        string strNo = Convert.ToString(node["SNO"]);
                        if (!int.TryParse(strNo, out I_index))
                            I_index = 0;
                    }
                    else if (rgDropMode.SelectedIndex == 1)
                    {
                        string strNO = Convert.ToString(node.ParentNode.LastNode["SNO"]);
                        strSelectedOZ = Convert.ToString(node.ParentNode.LastNode["Position_OZ"]);
                        if (!int.TryParse(strNO, out I_index))
                            I_index = 0;
                    }
                    else
                    {
                        string strNO = Convert.ToString(node.ParentNode.FirstNode["SNO"]);
                        strSelectedOZ = Convert.ToString(node.ParentNode.FirstNode["Position_OZ"]);
                        int iTemp = 0;
                        if (!int.TryParse(strNO, out iTemp))
                            I_index = 0;
                        else
                            I_index = iTemp - 1;
                    }
                    string _Suggested_OZ = SuggestOZForCopy(strSelectedOZ, strnextLV,rgDropMode.SelectedIndex);
                    Position_OZ = ParentOZ + _Suggested_OZ;
                }
                string strLongDescription = ObjBPosition.GetLongDescription(IPositionID);

                string _Selected_OZ = dataRow["Position_OZ"] == DBNull.Value ? "" : dataRow["Position_OZ"].ToString();
                DataTable dtTable = ds_oldPrj.Tables[0].Copy();

                DataView dv = dtTable.DefaultView;
                dv.RowFilter = "Position_OZ= '" + _Selected_OZ + "'";
                DataTable dt = dv.ToTable();
                int NewPositionID = 0;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ParsePositionDetailsfoCopyLV(row, Position_OZ, ParentOZ, I_index, strLongDescription);
                        NewPositionID = ObjBPosition.SavePositionDetails(ObjEPosition, ObjEProject.LVRaster, true);
                        I_index++;
                    }
                }
                else
                {
                    ParsePositionDetailsfoCopyLV(dataRow, Position_OZ, ParentOZ, I_index, strLongDescription);
                    NewPositionID = ObjBPosition.SavePositionDetails(ObjEPosition, ObjEProject.LVRaster, true);
                }

                ObjBPosition.GetPositionList(ObjEPosition, Convert.ToInt32(ObjEProject.ProjectID));
                if (ObjEPosition.dsPositionList != null && ObjEPosition.dsPositionList.Tables.Count > 0)
                {
                    tlNewProject.DataSource = ObjEPosition.dsPositionList.Tables[0];
                    tlNewProject.ParentFieldName = "Parent_OZ";
                    tlNewProject.KeyFieldName = "PositionID";
                    tlNewProject.ForceInitialize();
                    tlNewProject.ExpandAll();
                }
                SetFocus(NewPositionID, tlNewProject);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParsePositionDetailsfoCopyLV(DataRow dr, string strPositionsOZ, string strParetntOZ, int iTempSNO, string strLongDescription, int iDetailKZ = -1)
        {
            try
            {
                int iValue = 0;
                decimal dValue = 0;
                DateTime dt = DateTime.Now;
                ObjEPosition.ProjectID = ObjEProject.ProjectID;
                ObjEPosition.PositionID = -1;
                ObjEPosition.PositionKZ = Convert.ToString(dr["PositionKZ"]);
                ObjEPosition.Position_OZ = strPositionsOZ;
                ObjEPosition.Parent_OZ = strParetntOZ;
                if (iDetailKZ > 0)
                    ObjEPosition.DetailKZ = iDetailKZ;
                else
                {
                    if (int.TryParse(Convert.ToString(dr["DetailKZ"]), out iValue))
                        ObjEPosition.DetailKZ = iValue;
                    else
                        ObjEPosition.DetailKZ = 0;
                }

                ObjEPosition.LVSection = "HA";
                ObjEPosition.WG = Convert.ToString(dr["WG"]);
                ObjEPosition.WA = Convert.ToString(dr["WA"]);
                ObjEPosition.WI = Convert.ToString(dr["WI"]);

                if (decimal.TryParse(Convert.ToString(dr["Menge"]), out dValue))
                    ObjEPosition.Menge = dValue;
                else
                    ObjEPosition.Menge = 1;

                ObjEPosition.ME = Convert.ToString(dr["ME"]);
                ObjEPosition.Fabricate = Convert.ToString(dr["Fabricate"]);
                ObjEPosition.LiefrantMA = Convert.ToString(dr["LiefrantMA"]);
                ObjEPosition.Type = Convert.ToString(dr["Type"]);
                ObjEPosition.LongDescription = strLongDescription;
                ObjEPosition.ShortDescription = Convert.ToString(dr["ShortDescription"]);
                ObjEPosition.Surcharge_From = Convert.ToString(dr["surchargefrom"]);
                ObjEPosition.Surcharge_To = Convert.ToString(dr["surchargeto"]);

                if (decimal.TryParse(Convert.ToString(dr["surchargePercentage"]), out dValue))
                    ObjEPosition.Surcharge_Per = dValue;
                else
                    ObjEPosition.Surcharge_Per = 0;

                if (decimal.TryParse(Convert.ToString(dr["surchargePercentage_MO"]), out dValue))
                    ObjEPosition.surchargePercentage_MO = dValue;
                else
                    ObjEPosition.surchargePercentage_MO = 0;

                if (DateTime.TryParse(Convert.ToString(dr["validitydate"]), out dt))
                    ObjEPosition.ValidityDate = dt;
                else
                    ObjEPosition.ValidityDate = DateTime.Now;

                ObjEPosition.MA = Convert.ToString(dr["MA"]);
                ObjEPosition.MO = Convert.ToString(dr["MO"]);

                if (decimal.TryParse(Convert.ToString(dr["minutes"]), out dValue))
                    ObjEPosition.Mins = dValue;
                else
                    ObjEPosition.Mins = 0;

                if (decimal.TryParse(Convert.ToString(dr["Faktor"]), out dValue))
                    ObjEPosition.Faktor = dValue;
                else
                    ObjEPosition.Faktor = 1;

                if (decimal.TryParse(Convert.ToString(dr["MA_listprice"]), out dValue))
                    ObjEPosition.LPMA = dValue;
                else
                    ObjEPosition.LPMA = 0;

                if (decimal.TryParse(Convert.ToString(dr["MO_listprice"]), out dValue))
                    ObjEPosition.LPMO = dValue;
                else
                    ObjEPosition.LPMO = 0;

                if (decimal.TryParse(Convert.ToString(dr["MA_Multi1"]), out dValue))
                    ObjEPosition.Multi1MA = dValue;
                else
                    ObjEPosition.Multi1MA = 1;

                if (decimal.TryParse(Convert.ToString(dr["MA_multi2"]), out dValue))
                    ObjEPosition.Multi2MA = dValue;
                else
                    ObjEPosition.Multi2MA = 1;

                if (decimal.TryParse(Convert.ToString(dr["MA_multi3"]), out dValue))
                    ObjEPosition.Multi3MA = dValue;
                else
                    ObjEPosition.Multi3MA = 1;

                if (decimal.TryParse(Convert.ToString(dr["MA_multi4"]), out dValue))
                    ObjEPosition.Multi4MA = dValue;
                else
                    ObjEPosition.Multi4MA = 1;

                if (decimal.TryParse(Convert.ToString(dr["MO_multi1"]), out dValue))
                    ObjEPosition.Multi1MO = dValue;
                else
                    ObjEPosition.Multi1MO = 1;

                if (decimal.TryParse(Convert.ToString(dr["MO_multi2"]), out dValue))
                    ObjEPosition.Multi2MO = dValue;
                else
                    ObjEPosition.Multi2MO = 1;

                if (decimal.TryParse(Convert.ToString(dr["MO_multi3"]), out dValue))
                    ObjEPosition.Multi3MO = dValue;
                else
                    ObjEPosition.Multi3MO = 1;

                if (decimal.TryParse(Convert.ToString(dr["MO_multi4"]), out dValue))
                    ObjEPosition.Multi4MO = dValue;
                else
                    ObjEPosition.Multi4MO = 1;
                if (decimal.TryParse(Convert.ToString(dr["MA_einkaufspreis"]), out dValue))
                    ObjEPosition.EinkaufspreisMA = dValue;
                else
                    ObjEPosition.EinkaufspreisMA = 0;

                if (decimal.TryParse(Convert.ToString(dr["MO_Einkaufspreis"]), out dValue))
                    ObjEPosition.EinkaufspreisMO = dValue;
                else
                    ObjEPosition.EinkaufspreisMO = 0;

                if (decimal.TryParse(Convert.ToString(dr["MA_selbstkostenMulti"]), out dValue))
                    ObjEPosition.SelbstkostenMultiMA = dValue;
                else
                    ObjEPosition.SelbstkostenMultiMA = 1;

                if (decimal.TryParse(Convert.ToString(dr["MA_selbstkosten"]), out dValue))
                    ObjEPosition.SelbstkostenValueMA = dValue;
                else
                    ObjEPosition.SelbstkostenValueMA = 0;

                if (decimal.TryParse(Convert.ToString(dr["MO_selbstkostenMulti"]), out dValue))
                    ObjEPosition.SelbstkostenMultiMO = dValue;
                else
                    ObjEPosition.SelbstkostenMultiMO = 1;

                if (decimal.TryParse(Convert.ToString(dr["MO_selbstkosten"]), out dValue))
                    ObjEPosition.SelbstkostenValueMO = dValue;
                else
                    ObjEPosition.SelbstkostenValueMO = 0;

                if (decimal.TryParse(Convert.ToString(dr["MA_verkaufspreis_Multi"]), out dValue))
                    ObjEPosition.VerkaufspreisMultiMA = dValue;
                else
                    ObjEPosition.VerkaufspreisMultiMA = 1;

                if (decimal.TryParse(Convert.ToString(dr["MA_verkaufspreis"]), out dValue))
                    ObjEPosition.VerkaufspreisValueMA = dValue;
                else
                    ObjEPosition.VerkaufspreisValueMA = 0;

                if (decimal.TryParse(Convert.ToString(dr["MO_verkaufspreisMulti"]), out dValue))
                    ObjEPosition.VerkaufspreisMultiMO = dValue;
                else
                    ObjEPosition.VerkaufspreisMultiMO = 1;

                if (decimal.TryParse(Convert.ToString(dr["MO_verkaufspreis"]), out dValue))
                    ObjEPosition.VerkaufspreisValueMO = dValue;
                else
                    ObjEPosition.VerkaufspreisValueMO = 0;
                if (decimal.TryParse(Convert.ToString(dr["std_satz"]), out dValue))
                    ObjEPosition.StdSatz = dValue;
                else
                    ObjEPosition.StdSatz = 0;

                ObjEPosition.PreisText = Convert.ToString(dr["PreisText"]);
                ObjEPosition.EinkaufspreisLockMA = false;
                ObjEPosition.EinkaufspreisLockMO = false;
                ObjEPosition.SelbstkostenLockMA = false;
                ObjEPosition.SelbstkostenLockMO = false;
                ObjEPosition.VerkaufspreisLockMA = false;
                ObjEPosition.VerkaufspreisLockMO = false;
                ObjEPosition.Dim1 = Convert.ToString(dr["A"]);
                ObjEPosition.Dim2 = Convert.ToString(dr["B"]);
                ObjEPosition.Dim3 = Convert.ToString(dr["L"]);
                ObjEPosition.LVStatus = Convert.ToString(dr["LVStatus"]);
                if (decimal.TryParse(Convert.ToString(dr["GrandTotalME"]), out dValue))
                    ObjEPosition.GrandTotalME = dValue;
                else
                    ObjEPosition.GrandTotalME = 0;

                if (decimal.TryParse(Convert.ToString(dr["GrandTotalMO"]), out dValue))
                    ObjEPosition.GrandTotalMO = dValue;
                else
                    ObjEPosition.GrandTotalMO = 0;

                if (decimal.TryParse(Convert.ToString(dr["GB"]), out dValue))
                    ObjEPosition.FinalGB = dValue;
                else
                    ObjEPosition.FinalGB = 0;

                if (decimal.TryParse(Convert.ToString(dr["EP"]), out dValue))
                    ObjEPosition.EP = dValue;
                else
                    ObjEPosition.EP = 0;

                ObjEPosition.SNO = iTempSNO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string SuggestOZForCopy(string PositionOZ, string strNextLV, int Index = 0)
        {
            string strNewOZ = string.Empty;
            try
            {
                if (Index == 0)
                {
                    string[] OZList = PositionOZ.Split('.');
                    if (OZList != null && OZList.Count() > 1)
                    {
                        string OnheStufe = OZList[OZList.Count() - 2];
                        int Ivalue = 0;
                        if (int.TryParse(OnheStufe.Trim(), out Ivalue))
                        {
                            int iNewOZ = Ivalue - ObjEProject.LVSprunge;
                            int iTemp = 0;
                            if (iNewOZ <= 0)
                            {
                                iTemp = Ivalue - 1;
                                if (iTemp <= 0)
                                    throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                else
                                    strNewOZ = iTemp.ToString() + ".";
                            }
                            else
                                strNewOZ = iNewOZ.ToString() + ".";
                        }
                        else
                            throw new Exception("Bitte wählen Sie einen anderen Kopiermodus");
                    }
                    else
                        strNewOZ = ObjEProject.LVSprunge.ToString() + ".";
                }
                else if (Index == 1)
                {
                    string[] OZList = PositionOZ.Split('.');
                    if (OZList != null && OZList.Count() > 1)
                    {
                        string OnheStufe = OZList[OZList.Count() - 2];
                        int Ivalue = 0;
                        if (int.TryParse(OnheStufe.Trim(), out Ivalue))
                        {
                            int iNewOZ = Ivalue + ObjEProject.LVSprunge;
                            strNewOZ = iNewOZ.ToString() + ".";
                        }
                        else
                            if(Utility._IsGermany==true)
                            {
                                throw new Exception("Bitte wählen Sie einen anderen Kopiermodus");
                            }
                             else
                            {
                                throw new Exception("Please select the copy mode OR target location");
                            }
                    }
                    else
                        strNewOZ = ObjEProject.LVSprunge.ToString() + ".";
                }
                else
                {
                    if (string.IsNullOrEmpty(strNextLV))
                    {
                        string[] OZList = PositionOZ.Split('.');
                        if (OZList != null && OZList.Count() > 0)
                        {
                            string OnheStufe = OZList[OZList.Count() - 2];
                            int Ivalue = 0;
                            if (int.TryParse(OnheStufe.Trim(), out Ivalue))
                            {
                                int iNewOZ = Ivalue + ObjEProject.LVSprunge;
                                strNewOZ = iNewOZ.ToString() + ".";
                            }
                            else
                                throw new Exception("Bitte wählen Sie einen anderen Kopiermodus");
                        }
                        else
                            throw new Exception("Bitte wählen Sie einen anderen Kopiermodus");
                    }
                    else
                    {
                        string[] OZList = PositionOZ.Split('.');
                        string[] NextOZList = strNextLV.Split('.');
                        if (OZList != null && OZList.Count() > 0)
                        {
                            string SelectedOnheStufe = OZList[OZList.Count() - 2];
                            string NextOnheStufe = NextOZList[NextOZList.Count() - 2];
                            int ISelectedvalue = 0;
                            int INextLVValue = 0;
                            if (int.TryParse(SelectedOnheStufe.Trim(), out ISelectedvalue))
                            {
                                int iTemp = ISelectedvalue + ObjEProject.LVSprunge;
                                if (int.TryParse(NextOnheStufe.Trim(), out INextLVValue))
                                {
                                    if (iTemp < INextLVValue)
                                    {
                                        strNewOZ = iTemp.ToString() + ".";
                                    }
                                    else if (iTemp >= INextLVValue)
                                    {
                                        int INewValue = ISelectedvalue + 1;
                                        if (INewValue == INextLVValue)
                                        {
                                            string strIndex = "";
                                            int iIndex = 0;
                                            strIndex = OZList[OZList.Count() - 1];
                                            if (int.TryParse(strIndex.Trim(), out iIndex))
                                            {
                                                string strNextIndex = NextOZList[NextOZList.Count() - 1];
                                                int iNextOzIndex = 0;
                                                if (int.TryParse(strNextIndex, out iNextOzIndex))
                                                {
                                                    if (iNextOzIndex != iIndex + 1)
                                                    {
                                                        if (iIndex < 9)
                                                            strNewOZ = ISelectedvalue.ToString() + "." + (iIndex + 1).ToString();
                                                        else
                                                            throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                                    }
                                                    else
                                                        throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                                }
                                                else
                                                {
                                                    if (iIndex < 9)
                                                        strNewOZ = ISelectedvalue.ToString() + "." + (iIndex + 1).ToString();
                                                    else
                                                        throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                                }
                                            }
                                            else
                                            {
                                                string strNextIndex = NextOZList[NextOZList.Count() - 1];
                                                int iNextOzIndex = 0;
                                                if (int.TryParse(strNextIndex, out iNextOzIndex))
                                                {
                                                    if (iNextOzIndex != iIndex + 1)
                                                    {
                                                        if (iIndex < 9)
                                                            strNewOZ = ISelectedvalue.ToString() + "." + (iIndex + 1).ToString();
                                                        else
                                                            throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                                    }
                                                }
                                                else
                                                {
                                                    if (iIndex < 9)
                                                        strNewOZ = ISelectedvalue.ToString() + "." + (iIndex + 1).ToString();
                                                    else
                                                        throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                                }
                                            }
                                        }
                                        else if (INewValue < INextLVValue)
                                            strNewOZ = INewValue.ToString() + ".";
                                        else
                                            throw new Exception("Gemäß LV Sprung kann die Position nicht an den Anfang des Positionsbereichs kopiert werden");
                                    }
                                }
                                else
                                {
                                    strNewOZ = iTemp.ToString();
                                }
                            }
                            else
                                throw new Exception("Bitte wählen Sie einen anderen Kopiermodus");
                        }
                        else
                            throw new Exception("Bitte wählen Sie einen anderen Kopiermodus");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strNewOZ;
        }

        #endregion

        private void btnSaveSupplierProposal_Click(object sender, EventArgs e)
        {
            try
            {
                //if (gvLVDetailsforSupplier.DataRowCount == 0)
                //{
                //    if (!Utility._IsGermany)
                //        throw new Exception("No Positions to generate.");
                //    else
                //        throw new Exception("Es wurden keine LV Positionen ausgewählt");
                //}
                if (chkSupplierLists.CheckedItems.Count == 0)
                {
                    if (!Utility._IsGermany)
                        throw new Exception("Please select atleast one Supplier");
                    else
                        throw new Exception("Bitte wählen Sie mindestens einen Lieferanten aus");
                }
                
                DataTable _dtPosition = ObjESupplier.dtNewPositions.Copy();
                DataTable _dtDeletedPositions = ObjESupplier.dtDeletedPositions.Copy();

                foreach (DataColumn dc in ObjESupplier.dtNewPositions.Columns)
                {
                    if (dc.ColumnName != "PositionID")
                    {
                        _dtPosition.Columns.Remove(dc.ColumnName);
                        _dtDeletedPositions.Columns.Remove(dc.ColumnName);
                    }
                }

                _dtSupplier = new DataTable();
                _dtSupplier.Columns.Add("SupplierID");
                foreach (object item in chkSupplierLists.CheckedItems)
                {
                    DataRowView row = item as DataRowView;
                    DataRow dr = _dtSupplier.NewRow();
                    dr["SupplierID"] = row["id"];
                    _dtSupplier.Rows.Add(dr);
                }
                _ProposalID = ObjBSupplier.SaveSupplierProposal(ObjESupplier, ObjEProject.ProjectID, cmbLVSectionforSupplier.Text, _WGforSupplier, _WAforSupplier, _dtPosition, _dtSupplier, _dtDeletedPositions);

                ObjESupplier = ObjBSupplier.GetWGWAForProposal(ObjESupplier, ObjEProject.ProjectID, cmbLVSectionforSupplier.Text, _WGforSupplier, _WAforSupplier);
                if (ObjESupplier.dsSupplier != null)
                {
                    gcLVDetailsforSupplier.DataSource = ObjESupplier.dtNewPositions;
                    gcDeletedDetails.DataSource = ObjESupplier.dtDeletedPositions;
                    gcProposedDetails.DataSource = ObjESupplier.dtProposedPositions;

                    ObjESupplier.ProjectID = ObjEProject.ProjectID;
                    ObjESupplier = ObjBSupplier.GetProposalNumber(ObjESupplier);
                    gcProposedSupplier.DataSource = ObjESupplier.dtProposal;

                    gvLVDetailsforSupplier.BestFitColumns();
                    gvDeletedDetails.BestFitColumns();
                    gvProposedDetails.BestFitColumns();
                    gvProposedSupplier.BestFitColumns();
                    if(Utility._IsGermany==true)
                    {
                        frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Generierung des Angebots");
                    }
                    else
                    {
                        frmOTTOPro.UpdateStatus("Proposal generated successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvProposedSupplier_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                int _PrID;
                if (e.HitInfo.InRow)
                {
                    if (gvProposedSupplier.FocusedColumn != null && gvProposedSupplier.GetFocusedRowCellValue("ProposalID") != null)
                    {
                        if (int.TryParse(gvProposedSupplier.GetFocusedRowCellValue("ProposalID").ToString(), out _PrID))
                        {
                            _ProposalID = _PrID;
                            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Spezifikationsdokument für Lieferantenanfrage generieren", btnGeneratePDF_Click));
                            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Email für Lieferantenanfrage generieren", btnSendEmail_Click));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void cmbMulti6LVFilter_Closed(object sender, ClosedEventArgs e)
        {
            btnMulti6LoadArticles_Click(null, null);
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            btnMulti6LoadArticles_Click(null, null);
        }

        private void btnUmlageSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEUmlage == null)
                    ObjEUmlage = new EUmlage();
                if (ObjBUmlage == null)
                    ObjBUmlage = new BUmlage();
                ObjEUmlage.ProjectID = ObjEProject.ProjectID;
                if (ObjEUmlage.dtSpecialCost.Rows.Count > 0)
                {
                    ObjEUmlage = ObjBUmlage.SaveSpecialCost(ObjEUmlage);
                    txtUmlageValue.Text = ObjEUmlage.UmlageValue.ToString();
                    txtUmlageFactor.Text = ObjEUmlage.UmlageFactor.ToString();
                    if(Utility._IsGermany==true)
                    {
                        frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern der erfassten Generalkosten");
                    }
                    else
                    {
                        frmOTTOPro.UpdateStatus("Umlage Values Saved Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvInvoices_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Rechnung - Variante Langtext", gcInvoicesLangText_Click));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Rechnung - Variante Kurztext", gcInvoicesKurzText_Click));

                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcInvoicesLangText_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvInvoices.FocusedRowHandle != null && gvInvoices.GetFocusedRowCellValue("InvoiceID") != null)
                {
                    int IValue = 0;
                    string strInvoiceID = gvInvoices.GetFocusedRowCellValue("InvoiceID").ToString();
                    if (int.TryParse(strInvoiceID, out IValue))
                    {
                        rptInvoicewithLangText Obj = new rptInvoicewithLangText();
                        ReportPrintTool printTool = new ReportPrintTool(Obj);
                        Obj.Parameters["InvoiceID"].Value = IValue;
                        Obj.Parameters["ProjectID"].Value = ObjEProject.ProjectID;
                        printTool.ShowRibbonPreview();
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcInvoicesKurzText_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvInvoices.FocusedRowHandle != null && gvInvoices.GetFocusedRowCellValue("InvoiceID") != null)
                {
                    int IValue = 0;
                    string strInvoiceID = gvInvoices.GetFocusedRowCellValue("InvoiceID").ToString();
                    if (int.TryParse(strInvoiceID, out IValue))
                    {
                        rptInvoicewithKurzText Obj = new rptInvoicewithKurzText();
                        ReportPrintTool printTool = new ReportPrintTool(Obj);
                        Obj.Parameters["InvoiceID"].Value = IValue;
                        Obj.Parameters["ProjectID"].Value = ObjEProject.ProjectID;
                        printTool.ShowRibbonPreview();
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvAddRemovePositions_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.contextMenuStrip1.Show(this.gvAddRemovePositions, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                gvAddRemovePositions.Rows.Add();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }

        }

        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvAddRemovePositions.SelectedRows.Count > 0)
                {
                    // gvAddRemovePositions.Rows.RemoveAt(this.gvAddRemovePositions.SelectedRows[0].Index);
                    foreach (DataGridViewRow item in this.gvAddRemovePositions.SelectedRows)
                    {
                        gvAddRemovePositions.Rows.RemoveAt(item.Index);
                    }
                    tlBulkProcessPositionDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtListPreis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtListPreis_Leave(null, null);
        }

        private void txtListPreis_Leave(object sender, EventArgs e)
        {
            if (_IsSave)
            {
                btnSaveTemparary_Click(null, null);
                _IsSave = false;
            }
        }

        private void txtListPreis_EditValueChanged(object sender, EventArgs e)
        {
            if (_IsValueChanged)
                _IsSave = true;
        }

        private void gvMulti5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            view.UpdateTotalSummary();
        }

        private void txtListPreis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.Handled = true;
        }

        private void btnFinalBill_Click(object sender, EventArgs e)
        {
            try
            {
                bool _status = chkFinalInvoice.Checked;
                if (_status == true)
                {
                    ObjEProject.Status = "Completed";
                }
                else
                {
                    ObjEProject.Status = "";
                }
                ObjBProject.UpdateStatus(ObjEProject);
                if(Utility.RoleID != 14 && chkFinalInvoice.Checked == true)
                {
                    btnFinalBill.Enabled = false;
                    chkFinalInvoice.Enabled = false;
                    ObjBProject.GetProjectDetails(ObjEProject);
                }
                if (Utility._IsGermany == true)
                {
                    frmOTTOPro.UpdateStatus("'" + ObjEProject.ProjectNumber + "'" + " Projektstatus erfolgreich gespeichert");
                }
                else
                {
                    frmOTTOPro.UpdateStatus("'" + ObjEProject.ProjectNumber + "'" + " Project Status Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void navBarItemQuerKalkulation_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                rptQuerKalkulation rpt = new rptQuerKalkulation();
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                rpt.Parameters["ProjectID"].Value = ObjEProject.ProjectID;
                printTool.ShowRibbonPreview();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "LVDetails.xlsx";
                XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                tlPositions.ExportToXlsx(filePath, opt);
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnAddAccessories_Click(object sender, EventArgs e)
        {
            
            try
            {
                string strPositionKZ = Convert.ToString(tlPositions.FocusedNode["PositionKZ"]);
                if (strPositionKZ == "N" || strPositionKZ == "E" || strPositionKZ == "A" || strPositionKZ == "M")
                {
                    BArticles ObjBArticles = new BArticles();
                    EArticles ObjEArticles = new EArticles();
                    int SNo = -1;
                    if(ObjEPosition.PositionID > 0)
                    {
                        if (tlPositions.FocusedNode != null && tlPositions.FocusedNode["SNO"] != null)
                        {
                            int IValue = 0;
                            bool _HaveDetailKZ = false;
                            if (int.TryParse(Convert.ToString(tlPositions.FocusedNode["DetailKZ"]), out IValue))
                            {
                                if(IValue >0)
                                    return;
                            }
                            if (bool.TryParse(Convert.ToString(tlPositions.FocusedNode["HaveDetailkz"]), out _HaveDetailKZ))
                            {
                                if (_HaveDetailKZ)
                                    return;
                            }

                            if (int.TryParse(Convert.ToString(tlPositions.FocusedNode["SNO"]), out IValue))
                                SNo = IValue;
                            else
                                SNo = -1;
                        }
                    }

                    ObjEArticles.WG = txtWG.Text;
                    ObjEArticles.WA = txtWA.Text;
                    ObjEArticles.WI = txtWI.Text;
                    ObjEArticles.A = txtDim1.Text;
                    ObjEArticles.B = txtDim2.Text;
                    ObjEArticles.L = txtDim3.Text;
                    ObjEArticles = ObjBArticles.GetAccessoriesForLVs(ObjEArticles);
                    if (ObjEArticles.dtAccessories == null || ObjEArticles.dtAccessories.Rows.Count <= 0)
                        throw new Exception("No Accessories Exists");
                    DataTable dt = ObjEArticles.dtAccessories.Copy();
                    ObjEArticles.dtAccessories = new DataTable();
                    ObjEArticles.dtAccessories = dt.Clone();
                    DataRow drnew = ObjEArticles.dtAccessories.NewRow();
                    drnew["WG"] = ObjEArticles.WG;
                    drnew["WA"] = ObjEArticles.WA;
                    drnew["WI"] = ObjEArticles.WI;
                    drnew["A"] = ObjEArticles.A;
                    drnew["B"] = ObjEArticles.B;
                    drnew["L"] = ObjEArticles.L;
                    drnew["MENGE"] = 0;
                    ObjEArticles.dtAccessories.Rows.Add(drnew);
                    foreach (DataRow dr in dt.Rows)
                        ObjEArticles.dtAccessories.ImportRow(dr);

                    frmSelectAccessories Obj = new frmSelectAccessories();
                    Obj.ObjEArticle = ObjEArticles;
                    Obj.ShowInTaskbar = false;
                    Obj.ShowDialog();
                    if (Obj._ISSave)
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                        SplashScreenManager.Default.SetWaitFormDescription("Adding Accessories...");
                        if (ObjEPosition.PositionID < 0)
                        {
                            btnSaveLVDetails_Click(null, null);
                            btnCancel_Click(null, null);
                        }
                        int NewPositionID = 0;
                        int IDetailKz = 0;

                        DataView dvAccessories = ObjEArticles.dtAccessories.DefaultView;
                        dvAccessories.RowFilter = "MENGE > 0";
                        DataTable dtTemp = dvAccessories.ToTable();
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            if (ObjBPosition == null)
                                ObjBPosition = new BPosition();
                            if (ObjEPosition == null)
                                ObjEPosition = new EPosition();
                            IDetailKz++;
                            ParseAccessories(dr, SNo, IDetailKz, cmbLVSection.SelectedText, txtFaktor.Text, ObjEArticles, ObjBArticles);
                            NewPositionID = ObjBPosition.SavePositionDetails(ObjEPosition, ObjEProject.LVRaster);
                            if (SNo != -1)
                                SNo++;
                        }
                        BindPositionData();
                        SetFocus(NewPositionID, tlPositions);
                    }
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParseAccessories(DataRow dr, int Sno, int DetailKZ, string strLVSection, string FActor, EArticles ObjEArticles, BArticles ObjBArticles)
        {
            try
            {
                decimal dValue = 0;
                DateTime dt = DateTime.Now;
                ObjEPosition.ProjectID = ObjEProject.ProjectID;
                ObjEPosition.RasterCount = iRasterCount;
                ObjEPosition.Stufe1 = txtStufe1Short.Text;
                ObjEPosition.Stufe2 = txtStufe2Short.Text;
                ObjEPosition.Stufe3 = txtStufe3Short.Text;
                ObjEPosition.Stufe4 = txtStufe4Short.Text;
                ObjEPosition.Position = txtPosition.Text;
                ObjEPosition.PositionID = -1;
                ObjEPosition.PositionKZ = "N";
                ObjEPosition.DetailKZ = DetailKZ;
                ObjEPosition.LVSection = strLVSection;
                ObjEPosition.WG = Convert.ToString(dr["WG"]);
                ObjEPosition.WA = Convert.ToString(dr["WA"]);
                ObjEPosition.WI = Convert.ToString(dr["WI"]);
                ObjEPosition.Dim1 = Convert.ToString(dr["A"]);
                ObjEPosition.Dim2 = Convert.ToString(dr["B"]);
                ObjEPosition.Dim3 = Convert.ToString(dr["L"]);
                if (decimal.TryParse(Convert.ToString(dr["Menge"]), out dValue))
                    ObjEPosition.Menge = dValue;
                else
                    ObjEPosition.Menge = 1;
                ObjEArticles.WG = ObjEPosition.WG;
                ObjEArticles.WA = ObjEPosition.WA;
                ObjEArticles.WI = ObjEPosition.WI;
                ObjEArticles.A = ObjEPosition.Dim1;
                ObjEArticles.B = ObjEPosition.Dim2;
                ObjEArticles.L = ObjEPosition.Dim3;
                ObjEArticles.ValidityDate = ObjEProject.SubmitDate;
                ObjEArticles = ObjBArticles.GetArticleDetailsForAccessories(ObjEArticles);

                ObjEPosition.PreisText = string.Empty;
                ObjEPosition.ME = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Menegenheit"]);
                ObjEPosition.Fabricate = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Fabrikate"]);
                ObjEPosition.LiefrantMA = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["ShortName"]);
                ObjEPosition.Type = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Typ"]);
                ObjEPosition.LongDescription = string.Empty;
                ObjEPosition.ShortDescription = string.Empty;
                ObjEPosition.Surcharge_From = string.Empty;
                ObjEPosition.Surcharge_To = string.Empty;
                ObjEPosition.Surcharge_Per = 0;
                ObjEPosition.surchargePercentage_MO = 0;
                ObjEPosition.ValidityDate = DateTime.Now;
                ObjEPosition.MA = "X";
                ObjEPosition.MO = "X";
                if(string.IsNullOrEmpty(ObjEProject.CommissionNumber))
                    ObjEPosition.LVStatus = string.Empty;
                else
                    ObjEPosition.LVStatus = "B";

                if (decimal.TryParse(Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Minuten"]), out dValue))
                    ObjEPosition.Mins = dValue;
                else
                    ObjEPosition.Mins = 0;

                if (decimal.TryParse(FActor, out dValue))
                    ObjEPosition.Faktor = dValue;
                else
                    ObjEPosition.Faktor = 1;

                ObjEPosition.StdSatz = ObjEProject.InternX;

                if (decimal.TryParse(Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["ListPrice"]), out dValue))
                    ObjEPosition.LPMA = dValue;
                else
                    ObjEPosition.LPMA = 0;

                ObjEPosition.LPMO = (ObjEPosition.Mins / 60) * ObjEPosition.StdSatz * ObjEPosition.Faktor;

                if (decimal.TryParse(Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Multi1"]), out dValue))
                    ObjEPosition.Multi1MA = dValue;
                else
                    ObjEPosition.Multi1MA = 1;

                if (decimal.TryParse(Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Multi2"]), out dValue))
                    ObjEPosition.Multi2MA = dValue;
                else
                    ObjEPosition.Multi2MA = 1;

                if (decimal.TryParse(Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Multi3"]), out dValue))
                    ObjEPosition.Multi3MA = dValue;
                else
                    ObjEPosition.Multi3MA = 1;

                if (decimal.TryParse(Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Multi4"]), out dValue))
                    ObjEPosition.Multi4MA = dValue;
                else
                    ObjEPosition.Multi4MA = 1;
                
                ObjEPosition.Multi1MO = 1;
                ObjEPosition.Multi2MO = 1;
                ObjEPosition.Multi3MO = 1;
                ObjEPosition.Multi4MO = 1;
                ObjEPosition.EinkaufspreisMA = RoundValue((ObjEPosition.LPMA) * (ObjEPosition.Multi1MA * ObjEPosition.Multi1MA * ObjEPosition.Multi1MA * ObjEPosition.Multi1MA));
                ObjEPosition.EinkaufspreisMO = ObjEPosition.LPMO;
                ObjEPosition.SelbstkostenMultiMA = 1;
                ObjEPosition.SelbstkostenValueMA = ObjEPosition.EinkaufspreisMA;
                ObjEPosition.SelbstkostenMultiMO = 1;
                ObjEPosition.SelbstkostenValueMO = ObjEPosition.EinkaufspreisMO;
                ObjEPosition.VerkaufspreisMultiMA = 1;
                ObjEPosition.VerkaufspreisValueMA = ObjEPosition.EinkaufspreisMA;
                ObjEPosition.VerkaufspreisMultiMO = 1;
                ObjEPosition.VerkaufspreisValueMO = ObjEPosition.EinkaufspreisMO;

                ObjEPosition.EinkaufspreisLockMA = false;
                ObjEPosition.EinkaufspreisLockMO = false;
                ObjEPosition.SelbstkostenLockMA = false;
                ObjEPosition.SelbstkostenLockMO = false;
                ObjEPosition.VerkaufspreisLockMA = false;
                ObjEPosition.VerkaufspreisLockMO = false;
                ObjEPosition.GrandTotalME = ObjEPosition.EinkaufspreisMA;
                ObjEPosition.GrandTotalMO = ObjEPosition.EinkaufspreisMO;
                ObjEPosition.EP = ObjEPosition.EinkaufspreisMA + ObjEPosition.EinkaufspreisMO;
                ObjEPosition.FinalGB = RoundValue(ObjEPosition.EP * ObjEPosition.Menge);
                ObjEPosition.SNO = Sno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void chkLockHierarchy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkLockHierarchy.Checked == false)
                {
                    if (ddlRaster.Text != "")
                    {
                        frmAddRaster frm = new frmAddRaster(ddlRaster.Text);
                        frm._ProjectID = ObjEProject.ProjectID;
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            ddlRaster.Text = frm.NewRaster;
                        }
                    }
                }
                chkLockHierarchy.Checked = true;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void tlPositions_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tlPositions_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = DragDropEffects.None;
                DXDragEventArgs args = tlPositions.GetDXDragEventArgs(e);
                DataRow dataRow = (tlPositions.GetDataRecordByNode(tlPositions.FocusedNode) as DataRowView).Row;
                if (dataRow == null) return;
                string _OldPosKZ = dataRow["PositionKZ"] == DBNull.Value ? "" : dataRow["PositionKZ"].ToString();
                if (_OldPosKZ == "NG")
                    return;
                TreeListNode Tnode = args.TargetNode;
                if (Tnode == null)
                    return;
                int IValue = 0;
                if (int.TryParse(Convert.ToString(Tnode["DetailKZ"]), out IValue))
                {
                    if (IValue > 0)
                        return;
                }
                else
                    return;

                bool _HaveDetailKZ = false;
                if (bool.TryParse(Convert.ToString(Tnode["HaveDetailkz"]), out _HaveDetailKZ))
                {
                    if (_HaveDetailKZ)
                        return;
                }
                else
                    return;

                string TargetPositionKZ = Convert.ToString(Tnode["PositionKZ"]);
                string SNO = string.Empty;
                string ParentID = string.Empty;
                string ParentOZ = string.Empty;
                string PositionOZ = string.Empty;
                string strnextLV = string.Empty;
                int IIndex = 0;

                if (TargetPositionKZ == "NG")
                {
                    string[] _Raster = ObjEProject.LVRaster.Split('.');
                    int _Rastercount = _Raster.Count();
                    ParentOZ = Tnode["Position_OZ"].ToString();
                    string[] _OZ = ParentOZ.Split('.');
                    int _OZCount = _OZ.Count();
                    if (_OZCount != _Rastercount - 1)
                        return;
                    IIndex = 0;
                    ParentID = Convert.ToString(Tnode["PositionID"]);
                    if (Tnode.FirstNode != null)
                    {
                        SNO = Convert.ToString(Tnode.FirstNode["SNO"]);
                        PositionOZ = Convert.ToString(Tnode.FirstNode["Position_OZ"]);
                    }
                    int iTemp = 0;
                    if (!int.TryParse(SNO, out iTemp))
                        SNO = Convert.ToString(Tnode["SNO"]);
                    else
                        SNO = (iTemp - 2).ToString();
                }
                else
                {
                    SNO = Convert.ToString(Tnode["SNO"]);
                    ParentID = Convert.ToString(Tnode["Parent_OZ"]);
                    ParentOZ = Convert.ToString(Tnode.ParentNode["Position_OZ"]);
                    PositionOZ = Convert.ToString(Tnode["Position_OZ"]);
                    IIndex = 2;
                    int INodeIndex = tlPositions.GetNodeIndex(Tnode);
                    if (INodeIndex != null)
                    {
                        if (Tnode.ParentNode.Nodes.Count > INodeIndex + 1)
                            strnextLV = Convert.ToString(Tnode.ParentNode.Nodes[INodeIndex + 1]["Position_OZ"]);
                    }
                }

                int IPositionID = dataRow["PositionID"] == DBNull.Value ? -1 : Convert.ToInt32(dataRow["PositionID"]);
                string strPositionOZ = Convert.ToString(dataRow["Position_OZ"]);

                if (ObjBPosition == null)
                    ObjBPosition = new BPosition();
                if (ObjEPosition == null)
                    ObjEPosition = new EPosition();

                DataTable dtTemp = ObjEPosition.dsPositionList.Tables[0].Copy();
                DataView dvTemp = dtTemp.DefaultView;
                dvTemp.RowFilter = "Position_OZ = '" + strPositionOZ + "'";
                ObjEPosition.dtCopyPosition = dvTemp.ToTable();
                foreach (DataColumn dc in dtTemp.Columns)
                {
                    if (dc.ColumnName != "PositionID")
                    {
                        if (dc.ColumnName != "SNO")
                            ObjEPosition.dtCopyPosition.Columns.Remove(dc.ColumnName);
                    }
                }
                string _Suggested_OZ = SuggestOZForCopy(PositionOZ, strnextLV, IIndex);
                string strNewOz = ParentOZ + _Suggested_OZ;
                ObjEPosition.ProjectID = ObjEProject.ProjectID;
                ObjEPosition.PositionID = IPositionID;
                ObjEPosition.Position_OZ = strNewOz;
                int IParnetValue = 0;
                if (int.TryParse(ParentID, out IParnetValue))
                    ObjEPosition.ParentID = IParnetValue;
                else
                    throw new Exception("Error While Moving the position");

                if (int.TryParse(SNO, out IValue))
                    ObjEPosition.SNO = IValue;
                else
                    throw new Exception("Error While Moving the position");
                int ITemp = ObjEPosition.SNO;
                foreach (DataRow dr in ObjEPosition.dtCopyPosition.Rows)
                {
                    ITemp++;
                    dr["SNO"] = ITemp;
                }
                int NewPositionID = ObjBPosition.CopyPosition(ObjEPosition);
                BindPositionData();
                SetFocus(NewPositionID, tlPositions);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtWG_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextEdit textBox = (TextEdit)sender;
                if (e.KeyData == Keys.F5)
                {
                    panelControldoc.Visible = true;
                    toggleSwitchType.Visible = true;
                    dockPanelArticles.Show();
                    dockPanelArticles_Click(null,null);
                }                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void dockPanelArticles_Click(object sender, EventArgs e)
        {
            try
            {
                toggleSwitchType.IsOn = true;
                BindCoaprePrice("Project");
                BgvComparePrice.Columns["ProjectNumber"].Visible = false;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }

        }

        private void toggleSwitchType_Toggled(object sender, EventArgs e)
        {
            try
            {
                if (toggleSwitchType.IsOn)
                {
                    BindCoaprePrice("Project");
                    BgvComparePrice.Columns["ProjectNumber"].Visible = false;
                }
                else
                {
                    BindCoaprePrice("Customer");
                    BgvComparePrice.Columns["ProjectNumber"].Visible = true;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindCoaprePrice(string _type)
        {
            try
            {                
                int PosID = 0;
                if (int.TryParse(tlPositions.FocusedNode["PositionID"].ToString(), out PosID))
                {
                    if (_IsNewMode == true || chkCreateNew.Checked == true)
                    {
                        PosID = -1;
                    }
                    ObjBProject.GetComparePrice(ObjEProject, txtWG.Text, txtWA.Text, txtType.Text, _type, PosID);
                    if (ObjEProject.dsComaparePrice != null)
                    {
                        gcComparePrice.DataSource = ObjEProject.dsComaparePrice.Tables[0];
                        BgvComparePrice.BestFitColumns();
                    }
                }                                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyData == Keys.F5)
            //    {
            //        panelControldoc.Visible = true;
            //        toggleSwitchType.Visible = true;
            //        dockPanelArticles.Show();
            //        BindCoaprePrice("Type");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Utility.ShowError(ex);
            //}
        }

        private void navBarItemDeliveryNote_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                TabChange(tbAufmassReport);
                if (ObjEDeliveryNotes == null)
                    ObjEDeliveryNotes = new EDeliveryNotes();
                if (ObjBDeliveryNotes == null)
                    ObjBDeliveryNotes = new BDeliveryNotes();
                ObjEDeliveryNotes.ProjectID = ObjEProject.ProjectID;
                ObjEDeliveryNotes = ObjBDeliveryNotes.GetBlattNumbers(ObjEDeliveryNotes);
                gcDeliveryNoteReport.DataSource = ObjEDeliveryNotes.dtBlattNumbers;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcDeliveryReportAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDeliveryNoteReport.FocusedRowHandle != null && gvDeliveryNoteReport.GetFocusedRowCellValue("BlattID") != null)
                {
                    int IValue = 0;
                    string strBlattID = gvDeliveryNoteReport.GetFocusedRowCellValue("BlattID").ToString();
                    if (int.TryParse(strBlattID, out IValue))
                    {
                        rptDeliveryNotes Obj = new rptDeliveryNotes();
                        ReportPrintTool printTool = new ReportPrintTool(Obj);
                        Obj.Parameters["ID"].Value = IValue;
                        Obj.Parameters["ProjectID"].Value = ObjEProject.ProjectID;
                        printTool.ShowRibbonPreview();

                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gcDeliveryReportWithouAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDeliveryNoteReport.FocusedRowHandle != null && gvDeliveryNoteReport.GetFocusedRowCellValue("BlattID") != null)
                {
                    int IValue = 0;
                    string strBlattID = gvDeliveryNoteReport.GetFocusedRowCellValue("BlattID").ToString();

                    if (int.TryParse(strBlattID, out IValue))
                    {
                        rptDeliveryNotesWithoutAddress Obj = new rptDeliveryNotesWithoutAddress();
                        ReportPrintTool printTool = new ReportPrintTool(Obj);
                        Obj.Parameters["BlattID"].Value = IValue;
                        Obj.Parameters["ProjectID"].Value = ObjEProject.ProjectID;

                        printTool.ShowRibbonPreview();
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvDeliveryNoteReport_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InRow)
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Aufmaß mit Adresskopf", gcDeliveryReportAddress_Click));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Aufmaß ohne Adresskopf, mit LV Positionsnr", gcDeliveryReportWithouAddress_Click));
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnUmlageExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "Umlage.xlsx";
                XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                gvOmlage.ExportToXlsx(filePath, opt);
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void gvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    gvSupplier.MoveNext();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

    }
}
