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
        private int _ProjectID = 0;
        private int _PositionID = -1;
        private bool _IsCopy = false;
        private string LongDescription = string.Empty;
        private bool _IsEditMode = false;
        public static bool _IsNewMode = false;
        public int iSNO = -1;
        public bool _IsAddhoc = false;

        private string _DocuwareLink1;
        private string _DocuwareLink2;
        private string _DocuwareLink3;

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
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).PageVisible = false;
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

                btnProjectDetails.BackColor = Color.DeepSkyBlue;
                tbLVDetails.PageVisible = false;
                tbBulkProcess.PageVisible = false;
                tbMulti5.PageVisible = false;
                tbMulti6.PageVisible = false;
                cmbPositionKZ.Text = "N";

                RequiredFields.Add(txtProjectNumber);
                RequiredFields.Add(txtMWST);
                RequiredFields.Add(txtLVSprunge);
                RequiredFields.Add(txtKundeNo);
                RequiredFields.Add(txtInternS);
                RequiredFields.Add(txtInternX);
                dtpSubmitDate.Properties.VistaEditTime = DefaultBoolean.True;

                LoadExistingRasters();
                LoadExistingProject();
                if (ProjectID > 0)
                    ChkRaster.Enabled = false;


            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        /// <summary>
        /// Code to save the project details in case of new and Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (tcProjectDetails.SelectedTabPage == tbProjectDetails)
        //        {
        //            if (Utility.ValidateRequiredFields(RequiredFields) == false)
        //                return;
        //            ParseProjectDetails();
        //            string strConfirmation = "";
        //            // Confirmation incase of project convert into order
        //            if (txtkommissionNumber.Text != string.Empty && txtkommissionNumber.ReadOnly == false)
        //            {
        //                strConfirmation = XtraMessageBox.Show("Are you sure want to convert ga   project into kommission..?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
        //            }
        //            else
        //                strConfirmation = "Yes";

        //            if (strConfirmation.ToLower() == "yes")
        //            {
        //                ObjBProject.SaveProjectDetails(ObjEProject);
        //                UpdateStatus(ObjEProject.ProjectNumber + " Details Saved Successfully");
        //            }
        //        }
        //        else if (tcProjectDetails.SelectedTabPage == tbLVDetails)
        //        {
        //            if (Utility.ValidateRequiredFields(RequiredPositionFields) == false)
        //                return;
        //            ObjEPosition = new EPosition();
        //            ParsePositionDetails();
        //            int NewPositionID = ObjBPosition.SavePositionDetails(ObjEPosition);
        //            BindPositionData();
        //            SetFocus(NewPositionID);
        //            _IsEditMode = false;
        //            txtStufe1Title.Enabled = true;
        //            txtStufe2Title.Enabled = true;
        //            txtStufe3Title.Enabled = true;
        //            txtStufe4Title.Enabled = true;
        //            _PositionID = -1;
        //        }
        //        else if (tcProjectDetails.SelectedTabPage == tbCostDetails)
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.ShowError(ex);
        //    }
        //}

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
                    if(Utility._IsGermany == true)
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
                    if(Utility._IsGermany == true)
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
                    if(Utility._IsGermany == true)
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
                    if(Utility._IsGermany == true)
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
                ObjEProject.LockHierarchy = chkLockHierarchy.Checked;

                if (int.TryParse(ddlRounding.Text, out iValue))
                    ObjEProject.RoundingPrice = iValue;
                else
                {
                    if(Utility._IsGermany == true)
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
                        this.Text = "Project : " + ObjEProject.ProjectNumber;
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
            var dlgresult = "";
            if(Utility._IsGermany == true)
            {
                dlgresult = XtraMessageBox.Show("Möchten Sie diese Seite wirklich schließen.?", " Bestätigung …!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString();
            }
            else
            {
                dlgresult = XtraMessageBox.Show("Are you sure you want to close the page.?", "Confirmation..!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning).ToString();

            }
            if (dlgresult.ToString().ToLower() == "cancel")
            {
                e.Cancel = true;
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

        private void UpdateStatus(string Status)
        {
            tsProjectStatus.Text = Status;

        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            tsProjectStatus.Text = null;
            tmrStatus.Stop();
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
                    if (Count < 5)
                    {
                        //lblstufe4.Visible = false;
                        lciStufe4Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciStufe4Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                        lciStufe3Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe2Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe2Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                        if (Count < 4)
                        {
                            //lblstufe3.Visible = false;
                            lciStufe3Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                            lciStufe3Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                            if (Count < 3)
                            {
                                //lblstufe2.Visible = false;
                                lciStufe2Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                                lciStufe2Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                                RequiredPositionFieldsforTitle.Add(txtStufe1Short);
                            }
                            else
                            {
                                RequiredPositionFieldsforTitle.Add(txtStufe1Short);
                                RequiredPositionFieldsforTitle.Add(txtStufe2Short);
                            }
                        }
                        else
                        {
                            RequiredPositionFieldsforTitle.Add(txtStufe1Short);
                            RequiredPositionFieldsforTitle.Add(txtStufe2Short);
                            RequiredPositionFieldsforTitle.Add(txtStufe3Short);
                        }
                    }
                    else
                    {
                        lciStufe4Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe4Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe3Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe2Short.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciStufe2Title.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                        RequiredPositionFieldsforTitle.Add(txtStufe1Short);
                        RequiredPositionFieldsforTitle.Add(txtStufe2Short);
                        RequiredPositionFieldsforTitle.Add(txtStufe3Short);
                        RequiredPositionFieldsforTitle.Add(txtStufe4Short);
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
                ObjEPosition.PositionID = _PositionID;
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

                ObjEPosition.LVSection = cmbLVSection.Text;

                if (int.TryParse(txtWG.Text, out iValue))
                    ObjEPosition.WG = iValue;

                if (int.TryParse(txtWA.Text, out iValue))
                    ObjEPosition.WA = iValue;

                if (int.TryParse(txtWI.Text, out iValue))
                    ObjEPosition.WI = iValue;

                if (decimal.TryParse(txtMenge.Text, out dValue))
                    ObjEPosition.Menge = dValue;

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

                if (!string.IsNullOrEmpty(txtDim1.Text))
                    ObjEPosition.Dim1 = txtDim1.Text;

                if (!string.IsNullOrEmpty(txtDim2.Text))
                    ObjEPosition.Dim2 = txtDim2.Text;

                if (!string.IsNullOrEmpty(txtDim3.Text))
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
                    CalculateDetailKZ(ObjEPosition.dsPositionList.Tables[0], "EP");
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
                    cmbPositionKZ.Text =  tlPositions.FocusedNode["PositionKZ"] == DBNull.Value ? "" : tlPositions.FocusedNode["PositionKZ"].ToString(); //cmbPositionKZ.Properties.Items.IndexOf(dtTemp.Rows[0]["PositionKZ"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["PositionKZ"].ToString());
                    txtDetailKZ.Text = tlPositions.FocusedNode["DetailKZ"] == DBNull.Value ? "" : tlPositions.FocusedNode["DetailKZ"].ToString();
                    txtShortDescription.Rtf = tlPositions.FocusedNode["ShortDescription"] == DBNull.Value ? "" : tlPositions.FocusedNode["ShortDescription"].ToString();
                    cmbME.Text = tlPositions.FocusedNode["ME"] ==DBNull.Value ? "" : tlPositions.FocusedNode["ME"].ToString();
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
                        if (P_value == "NG" || P_value == "")
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

        private void SetFocus(int PositionID)
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
                    if(ObjEPosition.PositionID > 0 && Obj._IsSave)
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

        private void tlPositions_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
                popupMenu1.ShowPopup(Cursor.Position);
        }

        //private void tlPositions_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        //{
        //   // TreeListHitInfo hitInfo = tlPositions.CalcHitInfo(e.Point);          
        //}

        private void tlPositions_ShownEditor(object sender, EventArgs e)
        {
            try
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
            // Get the display text of the focused node's cell 
            string cellText = tlPositions.FocusedNode.GetDisplayText("Position_OZ");

            DataTable dt = ObjEPosition.dsPositionList.Tables[0];

            int Parent_OZ = (from DataRow dr in dt.Rows
                             where (string)dr["Position_OZ"] == cellText
                             select (int)dr["Parent_OZ"]).FirstOrDefault();

            object Position_OZ = dt.Compute("MAX(Position_OZ)", "Parent_OZ='" + Parent_OZ + "' and PositionKZ <>'" + "ZS" + "'");



        }

        private void tlPositions_CustomDrawColumnHeader(object sender, CustomDrawColumnHeaderEventArgs e)
        {
            try
            {
                if (e.Pressed)
                    paintSunkenBackground(e.Graphics, e.Bounds);
                else
                    paintRaisedBackground(e.Graphics, e.Bounds);
                if (e.ColumnType == HitInfoType.Column)
                    paintHAlignedText(e.Graphics, e.Bounds, e.Column.GetCaption(), StringAlignment.Center);
                e.Handled = true;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        // Paints the background of sunken elements.
        private void paintSunkenBackground(Graphics g, Rectangle bounds)
        {
            LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.DeepSkyBlue, Color.DeepSkyBlue, LinearGradientMode.Vertical);
            g.FillRectangle(brush, bounds);
            ControlPaint.DrawBorder3D(g, bounds, Border3DStyle.SunkenOuter);
        }

        // Paints the background of raised elements.
        private void paintRaisedBackground(Graphics g, Rectangle bounds)
        {
            LinearGradientBrush brush = new LinearGradientBrush(bounds, Color.DeepSkyBlue, Color.DeepSkyBlue, LinearGradientMode.Vertical);
            g.FillRectangle(brush, bounds);
            ControlPaint.DrawBorder3D(g, bounds, Border3DStyle.RaisedInner);
        }

        // Paints the aligned text.
        private void paintHAlignedText(Graphics g, Rectangle bounds, string text, StringAlignment align)
        {
            SolidBrush textBrush = new SolidBrush(Color.Black);

            StringFormat outStringFormat = new StringFormat();
            outStringFormat.Alignment = align;
            outStringFormat.LineAlignment = StringAlignment.Center;
            outStringFormat.FormatFlags = StringFormatFlags.NoWrap;
            outStringFormat.Trimming = StringTrimming.EllipsisCharacter;

            g.DrawString(text, new Font("Verdana", 8), textBrush, bounds, outStringFormat);
        }

        XtraTabPage ObjTabDetails = null;

        private void btnProjectDetails_Click(object sender, EventArgs e)
        {
            btnProjectDetails.BackColor = Color.DeepSkyBlue;
            btnLvdetails.BackColor = Color.Silver;
            btnBulkProcess.BackColor = Color.Silver;
            btnMulti5.BackColor = Color.Silver;
            btnMulti6.BackColor = Color.Silver;
            ObjTabDetails = tbProjectDetails;
            TabChange(ObjTabDetails);
          
        }

        private void btnLvdetails_Click(object sender, EventArgs e)
        {
            try
            {
                tlPositions.Cursor = Cursors.Default;
                if (ObjEProject.ProjectID > 0)
                {
                    setMask();
                    btnProjectDetails.BackColor = Color.Silver;
                    btnBulkProcess.BackColor = Color.Silver;
                    btnLvdetails.BackColor = Color.DeepSkyBlue;
                    IntializeLVPositions();
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
                if(txtkommissionNumber.Text!="")
                {
                    cmbLVSection.Enabled = true;
                    btnAddLVSection.Enabled = true;
                }
                else
                {
                    cmbLVSection.Enabled = false;
                    btnAddLVSection.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

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
                    if (dr["DetailKZ"].ToString() == "1")
                    {
                        string strOZ = dr["Position_OZ"].ToString();
                        DataRow[] FilteredRows = dt.Select("Position_OZ = '" + strOZ + "' and DetailKZ > 0");
                        decimal iValue = 0;
                        foreach (DataRow drnew in FilteredRows)
                        {
                            decimal OutValue = 0;
                            if (drnew["Position_OZ"].ToString() == strOZ && decimal.TryParse(drnew[strField].ToString(), out OutValue))
                            {
                                iValue += OutValue;
                            }
                        }
                        DataRow[] TargetRow = dt.Select("Position_OZ = '" + strOZ + "' and DetailKZ = 0");
                        if (TargetRow != null && TargetRow.Count() > 0)
                        {
                            TargetRow[0][strField] = iValue.ToString();
                            int Menge = 0;
                            if (int.TryParse(TargetRow[0]["Menge"].ToString(), out Menge))
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
                    string strParentOZ = PrepareOZ();
                    if (cmbPositionKZ.Text.ToLower() == "zs")
                    {
                        lblsurchargefrom.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lblsurchargeto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lblsurchargeme.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lblsurchargemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        if (_IsNewMode)
                        {
                            txtSurchargeFrom.Text = FromOZ(strParentOZ, "ZS");
                            txtSurchargeTo.Text = ToOZ(strParentOZ, "ZS");
                        }
                        lcCostDetails.Enabled=false;
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
                
                string strNodeType = e.Node["PositionKZ"].ToString().ToLower();
                if (strNodeType == "zs" || strNodeType == "z")
                {
                    if (strNodeType == "zs")
                        e.Appearance.BackColor = Color.Orange;
                    else if (strNodeType == "z")
                        e.Appearance.BackColor = Color.YellowGreen;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
               
                if (e.Node["DetailKZ"] != null)
                {
                    int tRes = Convert.ToInt32(e.Node["DetailKZ"]);
                    if (tRes > 0)
                    {
                        tlPositions.Columns["Position_OZ"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                    else
                    {
                        tlPositions.Columns["Position_OZ"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                    }
                }

                if (e.Column.FieldName == "MA_Multi1" ||
                    e.Column.FieldName == "MA_multi2" ||
                    e.Column.FieldName == "MA_multi3" ||
                    e.Column.FieldName == "MA_multi4" ||
                    e.Column.FieldName == "MA_einkaufspreis" ||
                    e.Column.FieldName == "MA_selbstkostenMulti" ||
                    e.Column.FieldName == "MA_verkaufspreis_Multi" ||
                    e.Column.FieldName == "MA_selbstkosten" ||
                    e.Column.FieldName == "MA_verkaufspreis" ||
                    e.Column.FieldName == "MO_multi1" ||
                    e.Column.FieldName == "MO_multi2" ||
                    e.Column.FieldName == "MO_multi3" ||
                    e.Column.FieldName == "MO_multi4" ||
                    e.Column.FieldName == "MO_Einkaufspreis" ||
                    e.Column.FieldName == "MO_selbstkostenMulti" ||
                    e.Column.FieldName == "MO_verkaufspreisMulti" ||
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
                    string strPosition = dr["PositionKZ"].ToString().ToLower();
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
                    Obj = dt.Compute("SUM(" + strField + ")", "SNO >=" + ifromValue +
                       "And SNO <=" + itoValue + "And DetailKZ = 0 and (PositionKZ = 'N' OR PositionKZ = 'M')");
                    Sum = Obj == DBNull.Value ? 0 : Convert.ToDecimal(Obj);
                    TotalValue = ((strPer + strPerMO) * Sum) / 100;
                }
                else
                {
                    Obj = dt.Compute("SUM(" + strField + ")", "SNO >=" + ifromValue +
                          "And SNO <=" + itoValue + "And DetailKZ = 0 AND (PositionKZ = 'N' OR PositionKZ = 'Z' OR PositionKZ = 'M')");
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
                        throw new Exception("No LV Positions to Order");
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
                        btnProjectSave.Enabled = false;
                    // tmrStatus.Interval = 5000;
                    tmrStatus.Start();
                    if(Utility._IsGermany == true)
                    {
                        UpdateStatus(ObjEProject.ProjectNumber + "  " + "Die Projektangabe wurden erfolgreich gespeichert");
                    }
                    else
                    {
                        UpdateStatus(ObjEProject.ProjectNumber + "  " + "Project Details Saved Successfully");
                    }
                    BindPositionData();
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
                }
                if (string.IsNullOrEmpty(txtPosition.Text))
                    txtDetailKZ.Text = "0";
                if (txtDetailKZ.Text != "0")
                    txtMenge.Text = "1";
                if (string.IsNullOrEmpty(cmbPositionKZ.Text))
                    cmbPositionKZ.Text = "N";
                if (ObjEPosition == null)
                    ObjEPosition = new EPosition();
                ParsePositionDetails();
                if(ObjEPosition.PositionKZ.ToLower() == "h")
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
                BindPositionData();
                SetFocus(NewPositionID);
                _PositionID = -1;
                if (chkCreateNew.Checked == true)
                {
                    btnNew_Click(null, null);
                }
                else
                {
                    EnableDisableLVAndCostDetails(false, false, false, false);
                    EnableDisableButtons(true, true, false, true, true);
                    tlPositions.OptionsBehavior.ReadOnly = false;
                }
                txtStufe1Short_TextChanged(null, null);
                txtStufe2Short_TextChanged(null, null);
                txtStufe3Short_TextChanged(null, null);
                txtStufe4Short_TextChanged(null, null);
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
            tlPositions.BestFitColumns();
        }

        private void barButtonItemAddSumPosition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            object tValue = tlPositions.FocusedNode.GetValue("Position_OZ");
            //  btnSaveLVDetails.PerformClick();
        }

        public void CostDetailsDefaultValues()
        {
            txtLPMe.Text = "10";
            txtMulti1ME.Text = "1";
            txtMulti1MO.Text = "1";
            txtMulti2ME.Text = "1";
            txtMulti2MO.Text = "1";
            txtMulti3ME.Text = "1";
            txtMulti3MO.Text = "1";
            txtMulti4ME.Text = "1";
            txtMulti4MO.Text = "1";
            txtMin.Text = "100";
            txtFaktor.Text = "1";
            txtSelbstkostenMultiME.Text = "1";
            txtSelbstkostenMultiMO.Text = "1";
            txtVerkaufspreisMultiME.Text = "1";
            txtVerkaufspreisMultiMO.Text = "1";
            txtFaktor.Text = "1";
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
                        RoundValue(getDValue(txtGrandTotalME.Text) + getDValue(txtGrandTotalMO.Text)).ToString();
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
                    decimal GrundMulti = RoundValue(
                        getDValue(txtMulti1ME.Text) *
                        getDValue(txtMulti2ME.Text) *
                        getDValue(txtMulti3ME.Text) *
                        getDValue(txtMulti4ME.Text)
                        );
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
                    decimal GrundMulti = RoundValue(
                        getDValue(txtMulti1MO.Text) *
                        getDValue(txtMulti2MO.Text) *
                        getDValue(txtMulti3MO.Text) *
                        getDValue(txtMulti4MO.Text)
                        );
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
                throw ex;
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
                if(Utility._IsGermany == true)
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
                    btnProjectDetails.BackColor = Color.Silver;
                    btnLvdetails.BackColor = Color.DeepSkyBlue;
                    btnBulkProcess.BackColor = Color.Silver;
                    btnMulti5.BackColor = Color.Silver;
                    btnMulti6.BackColor = Color.Silver;
                    btnLvdetails.Focus();
                    tsProjectStatus.Text = "";
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbProjectDetails")
                {
                    FormatLVFields();
                    setMask();
                    btnProjectDetails.BackColor = Color.DeepSkyBlue;
                    btnLvdetails.BackColor = Color.Silver;
                    btnBulkProcess.BackColor = Color.Silver;
                    btnMulti5.BackColor = Color.Silver;
                    btnMulti6.BackColor = Color.Silver;
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbBulkProcess")
                {
                    btnProjectDetails.BackColor = Color.Silver;
                    btnLvdetails.BackColor = Color.Silver;
                    btnBulkProcess.BackColor = Color.DeepSkyBlue;
                    btnMulti5.BackColor = Color.Silver;
                    btnMulti6.BackColor = Color.Silver;
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbMulti5")
                {
                    btnProjectDetails.BackColor = Color.Silver;
                    btnLvdetails.BackColor = Color.Silver;
                    btnBulkProcess.BackColor = Color.Silver;
                    btnMulti5.BackColor = Color.DeepSkyBlue;
                    btnMulti6.BackColor = Color.Silver;
                }
                else if (tcProjectDetails.SelectedTabPage.Name == "tbMulti6")
                {
                    btnProjectDetails.BackColor = Color.Silver;
                    btnLvdetails.BackColor = Color.Silver;
                    btnBulkProcess.BackColor = Color.Silver;
                    btnMulti5.BackColor = Color.Silver;
                    btnMulti6.BackColor = Color.DeepSkyBlue;
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
                _IsAddhoc = false;
                //if (tlPositions.Nodes != null && tlPositions.Nodes.Count > 0)
                //{
                //    tlPositions.SetFocusedNode(tlPositions.MoveLastVisible());
                //}
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
                if (strPositiontype == string.Empty)
                {
                    ObjEPosition.PositionID = -1;
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
                    txtWG.Text = "0";
                    txtWA.Text = "0";
                    txtWI.Text = "0";
                    txtDim1.Text = "0";
                    txtDim2.Text = "0";
                    txtDim3.Text = "0";
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
                }
                else if (strPositiontype.ToLower() == "h")
                {
                    ObjEPosition.PositionID = -1;
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
                    txtWG.Text = "0";
                    txtWA.Text = "0";
                    txtWI.Text = "0";
                    txtDim1.Text = "0";
                    txtDim2.Text = "0";
                    txtDim3.Text = "0";
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
                    ObjEPosition.PositionID = -1;
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
                    txtWG.Text = "0";
                    txtWA.Text = "0";
                    txtWI.Text = "0";
                    txtDim1.Text = "0";
                    txtDim2.Text = "0";
                    txtDim3.Text = "0";
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
                    _PositionID = iValue;
                    if (string.IsNullOrEmpty(ObjEProject.CommissionNumber))
                        cmbLVSection.Enabled = false;
                }
                else if (_IsEditMode)
                {
                    if(Utility._IsGermany == true)
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
                //txtMulti1ME.Properties.Mask.EditMask = strMask;
                //txtMulti2ME.Properties.Mask.EditMask = strMask;
                //txtMulti3ME.Properties.Mask.EditMask = strMask;
                //txtMulti4ME.Properties.Mask.EditMask = strMask;
                //txtMulti1MO.Properties.Mask.EditMask = strMask;
                //txtMulti2MO.Properties.Mask.EditMask = strMask;
                //txtMulti3MO.Properties.Mask.EditMask = strMask;
                //txtMulti4MO.Properties.Mask.EditMask = strMask;
                txtValue1ME.Properties.Mask.EditMask = strMask;
                txtValue2ME.Properties.Mask.EditMask = strMask;
                txtValue3ME.Properties.Mask.EditMask = strMask;
                txtValue4ME.Properties.Mask.EditMask = strMask;
                txtValue1MO.Properties.Mask.EditMask = strMask;
                txtValue2MO.Properties.Mask.EditMask = strMask;
                txtValue3MO.Properties.Mask.EditMask = strMask;
                txtValue4MO.Properties.Mask.EditMask = strMask;
                //txtGrundMultiME.Properties.Mask.EditMask = strMask;
                //txtGrundMultiMO.Properties.Mask.EditMask = strMask;
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
                //txtSelbstkostenMultiME.Properties.Mask.EditMask = strMask;
                //txtSelbstkostenMultiMO.Properties.Mask.EditMask = strMask;
                //txtVerkaufspreisMultiME.Properties.Mask.EditMask = strMask;
                //txtVerkaufspreisMultiMO.Properties.Mask.EditMask = strMask;

                //txtMulti5MA.Properties.Mask.EditMask = strMask;
                //txtMulti5MO.Properties.Mask.EditMask = strMask;
                //txtMulti6MA.Properties.Mask.EditMask = strMask;
                //txtMulti6MO.Properties.Mask.EditMask = strMask;
                txtMenge.Properties.Mask.EditMask = strMask;
                txtPositionMenge.Properties.Mask.EditMask = strMask;      
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
                //EnableDisableLVAndCostDetails(false, false, false, false);
                //EnableDisableButtons(true, true, false, true, true);
                //ObjEPosition.PositionID = -1;
                //chkCreateNew.Checked = false;
                //tlPositions_FocusedNodeChanged(null, null);
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
                if (!string.IsNullOrEmpty(txtStufe1Short.Text)) //1
                {
                    strParentOZ.Append(txtStufe1Short.Text + ".");//1
                    if (!string.IsNullOrEmpty(txtStufe2Short.Text))//1
                    {
                        strParentOZ.Append(txtStufe2Short.Text + ".");//1.1
                        if (!string.IsNullOrEmpty(txtStufe3Short.Text))//1
                        {
                            strParentOZ.Append(txtStufe3Short.Text + ".");//1.1.1
                            if (!string.IsNullOrEmpty(txtStufe4Short.Text))//1
                                strParentOZ.Append(txtStufe4Short.Text + ".");//1.1.1.1
                        }
                    }
                }
                return strParentOZ.ToString();
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
                                strNewOZ = ObjEProject.LVSprunge.ToString();
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
                EnableDisableLVAndCostDetails(false, false, false, false);
                EnableDisableButtons(true, true, false, true, true);
                ObjEPosition.PositionID = -1;
                _IsEditMode = false;
                chkCreateNew.Checked = false;
                chkCreateNew.Enabled = false;
                tlPositions_FocusedNodeChanged(null, null);
                tlPositions.OptionsBehavior.ReadOnly = false;        
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
                dvPosition.RowFilter = "Position_OZ = '" + textbox.Text + "'";
                DataTable dtTemp = dvPosition.ToTable();
                if (dtTemp != null && dtTemp.Rows.Count < 1)
                {
                    if (textbox.Text != string.Empty)
                    {
                        if(Utility._IsGermany == true)
                        {
                            XtraMessageBox.Show("Die gewählte " + textbox.Tag.ToString() + " existiert nicht", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            XtraMessageBox.Show("Selected " + textbox.Tag.ToString() + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if(Utility._IsGermany == true)
                            XtraMessageBox.Show(textbox.Tag.ToString() + " Fehlende Angabe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            XtraMessageBox.Show(textbox.Tag.ToString() + " Should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (_IsNewMode)
                    {
                        if (textbox == txtSurchargeFrom)
                            textbox.Text = FromOZ(PrepareOZ(), cmbPositionKZ.Text);
                        else
                            textbox.Text = ToOZ(PrepareOZ(), cmbPositionKZ.Text);
                    }
                    else if (_IsEditMode)
                    {
                        DataView dvPositionEdit = ObjEPosition.dsPositionList.Tables[0].DefaultView;
                        dvPositionEdit.RowFilter = "PositionID = '" + _PositionID + "'";
                        DataTable dtTemp1 = dvPositionEdit.ToTable();
                        if (textbox == txtSurchargeFrom)
                            textbox.Text = dtTemp1.Rows[0]["surchargefrom"] == DBNull.Value ? "" : dtTemp1.Rows[0]["surchargefrom"].ToString();
                        else
                            textbox.Text = dtTemp1.Rows[0]["surchargeto"] == DBNull.Value ? "" : dtTemp1.Rows[0]["surchargeto"].ToString();
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
                DataTable dt = ObjEPosition.dsPositionList.Tables[0];
                DataRow[] tPosition_Id = dt.Select("Position_OZ='" + strParentOZ + "'");
                string tResult = tPosition_Id[0]["PositionID"] == DBNull.Value ? "" : tPosition_Id[0]["PositionID"].ToString();
                object Min_Identity = null;
                string MinValue = string.Empty;

                if (strPositionKZ.ToLower() == "zs")
                    Min_Identity = dt.Compute("MIN(SNO)", "Parent_OZ =" + tResult + "And PositionKZ <> 'ZS'");
                else if (strPositionKZ.ToLower() == "z")
                    Min_Identity = dt.Compute("MIN(SNO)", "Parent_OZ =" + tResult + "And PositionKZ = 'N'");

                if (Min_Identity != null)
                    strFromOZ = dt.Compute("MIN(Position_OZ)", "SNO =" + Min_Identity) == DBNull.Value ? "" : dt.Compute("MIN(Position_OZ)", "SNO =" + Min_Identity).ToString();
            }
            catch (Exception ex)
            {
                //throw;
            }
            return strFromOZ;
        }
        
        private string ToOZ(string strParentOZ, string strPositionKZ)
        {
            string strToOZ = string.Empty;
            try
            {
                DataTable dt = ObjEPosition.dsPositionList.Tables[0];
                DataRow[] tPosition_Id = dt.Select("Position_OZ='" + strParentOZ + "'");
                string tResult = tPosition_Id[0]["PositionID"] == DBNull.Value ? "" : tPosition_Id[0]["PositionID"].ToString();
                object Max_Identity = null;

                if (strPositionKZ.ToLower() == "zs")
                    Max_Identity = dt.Compute("MAX(SNO)", "Parent_OZ =" + tResult + "And PositionKZ <> 'ZS'");
                else if (strPositionKZ.ToLower() == "z")
                    Max_Identity = dt.Compute("MAX(SNO)", "Parent_OZ =" + tResult + "And PositionKZ = 'N'");

                if (Max_Identity != null)
                    strToOZ = dt.Compute("MIN(Position_OZ)", "SNO =" + Max_Identity) == DBNull.Value ? "" : dt.Compute("MIN(Position_OZ)", "SNO =" + Max_Identity).ToString();
            }
            catch (Exception ex)
            {
                //throw;
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
                        if(Utility._IsGermany == true)
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
                    if(Utility._IsGermany == true)
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
                        RoundValue(getDValue(txtMenge.Text) * getDValue(txtVerkaufspreisValueME.Text)).ToString();
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
                        RoundValue(getDValue(txtMenge.Text) * getDValue(txtVerkaufspreisValueMO.Text)).ToString();
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
            txtVerkaufspreisValueME_TextChanged(null, null);
            txtVerkaufspreisValueMO_TextChanged(null, null);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                btnModify_Click(null, null);
                if (_IsEditMode)
                {
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F9))
            {
                if (tcProjectDetails.SelectedTabPage.Name == "tbLVDetails")
                {
                    btnSaveLVDetails.PerformClick();
                    return true;
                }
                if (tcProjectDetails.SelectedTabPage.Name == "tbProjectDetails")
                {
                    btnProjectSave_Click(null, null);
                    return true;
                }
            }
            if (keyData == (Keys.PageDown))
            {
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void tlPositions_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSaveLVDetails_Click(null, null);
                    tlPositions.MoveNext();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void tlPositions_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (tlPositions.FocusedNode != null && tlPositions.FocusedNode["PositionID"] != null)
                {
                    txtMulti1ME.Text = tlPositions.FocusedNode.GetValue("MA_Multi1").ToString();
                    txtMulti2ME.Text = tlPositions.FocusedNode.GetValue("MA_multi2").ToString();
                    txtMulti3ME.Text = tlPositions.FocusedNode.GetValue("MA_multi3").ToString();
                    txtMulti4ME.Text = tlPositions.FocusedNode.GetValue("MA_multi4").ToString();
                    txtSelbstkostenMultiME.Text = tlPositions.FocusedNode.GetValue("MA_selbstkostenMulti").ToString();
                    txtVerkaufspreisMultiME.Text = tlPositions.FocusedNode.GetValue("MA_verkaufspreis_Multi").ToString();

                    txtMulti1MO.Text = tlPositions.FocusedNode.GetValue("MO_multi1").ToString();
                    txtMulti2MO.Text = tlPositions.FocusedNode.GetValue("MO_multi2").ToString();
                    txtMulti3MO.Text = tlPositions.FocusedNode.GetValue("MO_multi3").ToString();
                    txtMulti4MO.Text = tlPositions.FocusedNode.GetValue("MO_multi4").ToString();
                    txtSelbstkostenMultiMO.Text = tlPositions.FocusedNode.GetValue("MO_selbstkostenMulti").ToString();
                    txtVerkaufspreisMultiMO.Text = tlPositions.FocusedNode.GetValue("MO_verkaufspreisMulti").ToString();

                    btnSaveLVDetails_Click(null, null);

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
                }
                else
                {
                    tlPositions.OptionsBehavior.ReadOnly = false;
                }
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
                BindPositionData();
                int visibleRowsCount = tlPositions.ViewInfo.RowsInfo.Rows.Count;
                if (visibleRowsCount == 0)
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

                    frmGAEBExport Obj = new frmGAEBExport(ObjEProject.ProjectNumber, ObjEProject.ProjectID, raster_count);
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
                    ddlRaster.SelectedIndex = ddlRaster.Properties.Items.IndexOf(ObjEProject.LVRaster);
                    ddlRaster.Enabled = true;
                    // ddlRaster.SelectedIndex = ddlRaster.Properties.Items.IndexOf("99.99.1111.9");
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
                        int visibleRowsCount = tlPositions.ViewInfo.RowsInfo.Rows.Count;
                        if (visibleRowsCount == 0)
                        {
                            ChkRaster.Enabled = true;
                        }
                        else
                        {
                            ChkRaster.Enabled = false;
                        }
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
                    if (tlPositions.FocusedNode["PositionKZ"] != null && tlPositions.FocusedNode["PositionKZ"].ToString() != "NG" && tlPositions.FocusedNode["PositionKZ"].ToString() != "")
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
            }
            catch (Exception ex)
            {
                if(Utility._IsGermany == true)
                {
                    throw new Exception("Fehler beim Löschen der LV Position");
                }
                else
                {
                    throw new Exception("Error While Deleting Position");
                }
            }
        }

        private void tlPositions_EditorKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    DeletePosition();
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
                tlPositions.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                string P_value = tlPositions.FocusedNode["PositionKZ"].ToString();
                if (P_value != "NG")
                {
                    if (e.Menu is TreeListNodeMenu)
                    {
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Löschen", bbDelete_ItemClick));
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Insert Text Position", bbAddTextPosition_Click));
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Insert Position", bbAddPosition_Click));
                    }
                }
                else
                {
                    if (e.Menu is TreeListNodeMenu)
                    {
                        tlPositions.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Insert Title", bbAddTitle_Click));
                        e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Insert Text Position", bbAddTextPosition_Click));
                    }
                }
            }
            catch (Exception ex)
            {

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

        private void bbAddPosition_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        #region BULK PROCESS

        private void btnBulkProcess_Click(object sender, EventArgs e)
        {
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
            if (cmbLVStatus.Text == "A")
            {
                if(Utility._IsGermany == true)
                {
                    XtraMessageBox.Show("Die globale LV Bearbeitung wird nicht auf abgelehnte LV Positionen angewandt.");
                }
                else
                {
                    XtraMessageBox.Show("Bulk Process should not happend for Rejected LVs.");
                }
                return;
            }
            if (ObjEProject.ProjectID > 0)
            {
                tlBulkProcessPositionDetails.Cursor = Cursors.Default;
                btnProjectDetails.BackColor = Color.Silver;
                btnBulkProcess.BackColor = Color.DeepSkyBlue;
                btnLvdetails.BackColor = Color.Silver;
                ObjTabDetails = tbBulkProcess;
                TabChange(ObjTabDetails);
                tlBulkProcessPositionDetails.BestFitColumns();
            }
        }

        private void radioGroupselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroupselect.SelectedIndex == 2)
                {
                    lciAddLV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciRemoveLV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcgBulkProcessLVGrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcgWGWA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    lciAddLV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciRemoveLV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcgBulkProcessLVGrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcgWGWA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gvAddRemovePositions.Rows.Add();
        }

        private void btnRemove_Click(object sender, EventArgs e)
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

        string tType = null;
        private void AssignPosition_type()
        {
            if (radioGroupselect.SelectedIndex == 0)
            {
                tType = "Parent Position";
            }
            if (radioGroupselect.SelectedIndex == 1)
            {
                tType = "LV Position";
            }
            if (radioGroupselect.SelectedIndex == 2)
            {
                tType = "WG/WA";
            }
            if (radioGroupselect.SelectedIndex == 3)
            {
                tType = "Supplier";
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            try
            {
                if (radioGroupselect.SelectedIndex != 2)
                {
                    if (gvAddRemovePositions.RowCount == 0)
                    {
                        if(Utility._IsGermany == true)
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
                if (radioGroupselect.SelectedIndex != 2)
                {
                    foreach (DataGridViewRow dr in gvAddRemovePositions.Rows)
                    {
                        Gridvalue = Convert.ToString(dr.Cells[1].Value);
                        if (Gridvalue == null || Gridvalue == "")
                        {
                            if(Utility._IsGermany == true)
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
                if (radioGroupselect.SelectedIndex == 2)
                {
                    if (txtBulkProcessWG.Text == "")
                    {
                        if(Utility._IsGermany == true)
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
                        ObjBPosition.GetPositionOZListByWGWA(ObjEPosition, ObjEProject.ProjectID, tType, Convert.ToDouble(txtBulkProcessWG.Text), Convert.ToInt32(txtBulkProcessWA.Text));
                    }
                }
                else
                {
                    DataTable dtPos = new DataTable();
                    dtPos.Columns.Add("FromPos");
                    dtPos.Columns.Add("ToPos");

                    string tfrom=null;
                    string tTo =null;
                    foreach (DataGridViewRow dr in gvAddRemovePositions.Rows)
                    {
                        DataRow drPos = dtPos.NewRow();
                        tfrom = dr.Cells[0].Value.ToString();
                        tTo = dr.Cells[1].Value.ToString();
                        if (radioGroupselect.SelectedIndex == 0)
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
                        drPos["fromPos"] = tfrom.Replace(',','.');
                        drPos["toPos"] = tTo.Replace(',','.');
                        dtPos.Rows.Add(drPos);
                    }
                    ObjBPosition.GetPositionOZList(ObjEPosition, ObjEProject.ProjectID, tType, dtPos);
                }


                if (ObjEPosition.dsPositionOZList != null)
                {
                    tlBulkProcessPositionDetails.DataSource = ObjEPosition.dsPositionOZList;
                    tlBulkProcessPositionDetails.DataMember = "Positions";
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
                if (tlBulkProcessPositionDetails.DataSource==null)
                {
                    if(Utility._IsGermany == true)
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
                dtPos.Columns.Add("MA_Selbstkosten");
                dtPos.Columns.Add("MO_Selbstkosten");
                dtPos.Columns.Add("MA_Verkaufspreis");
                dtPos.Columns.Add("MO_Verkaufspreis");


                if (tlBulkProcessPositionDetails.DataSource != null)
                {
                    foreach (TreeListNode node in tlBulkProcessPositionDetails.Nodes)
                    {
                        DataRow drPos = dtPos.NewRow();
                        string tID = node["PositionID"].ToString();
                        string tMA_Selbstkosten = node["MA_selbstkostenMulti"].ToString();
                        string tMO_Selbstkosten = node["MO_selbstkostenMulti"].ToString();
                        string tMA_Verkaufspreis = node["MA_verkaufspreis_Multi"].ToString();
                        string MO_Verkaufspreis = node["MO_verkaufspreisMulti"].ToString();

                        drPos["ID"] = tID;
                        drPos["MA_Selbstkosten"] = tMA_Selbstkosten.Replace(',','.');
                        drPos["MO_Selbstkosten"] = tMO_Selbstkosten.Replace(',', '.');
                        drPos["MA_Verkaufspreis"] = tMA_Verkaufspreis.Replace(',', '.');
                        drPos["MO_Verkaufspreis"] = MO_Verkaufspreis.Replace(',', '.');

                        dtPos.Rows.Add(drPos);
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
                ObjBPosition.UpdateBulkProcess_ActionA(ObjEPosition, ObjEProject.ProjectID, tType, Convert.ToDecimal(txtMulti5MA.Text), Convert.ToDecimal(txtMulti5MO.Text), Convert.ToDecimal(txtMulti6MA.Text), Convert.ToDecimal(txtMulti6MO.Text), dtPos);

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
            if(Utility._IsGermany == true)
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
                    if(Utility._IsGermany == true)
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
                dtPos.Columns.Add("Menge");
                dtPos.Columns.Add("MA");
                dtPos.Columns.Add("MO");
                dtPos.Columns.Add("PreisText");
                dtPos.Columns.Add("Fabricate");
                dtPos.Columns.Add("Type");
                dtPos.Columns.Add("LiefrantMA");
                dtPos.Columns.Add("WG");
                dtPos.Columns.Add("WA");
                dtPos.Columns.Add("WI");
                dtPos.Columns.Add("LVSection");


                if (tlBulkProcessPositionDetails.DataSource != null)
                {
                    foreach (TreeListNode node in tlBulkProcessPositionDetails.Nodes)
                    {
                        DataRow drPos = dtPos.NewRow();
                        string tID = node["PositionID"].ToString();
                        string tmenge = node["Menge"].ToString();
                        string tMA = node["MA"].ToString();
                        string tMO = node["MO"].ToString();
                        string tperisText = node["PreisText"].ToString();
                        string tFabricat = node["Fabricate"].ToString();
                        string t_Type = node["Type"].ToString();
                        string tLiefrantMA = node["LiefrantMA"].ToString();
                        string tWG = node["WG"].ToString();
                        string tWA = node["WA"].ToString();
                        string tWI = node["WI"].ToString();
                        string tLVSection = node["LVSection"].ToString();

                        drPos["ID"] = tID;
                        drPos["Menge"] = tmenge;
                        drPos["MA"] = tMA;
                        drPos["MO"] = tMO;
                        drPos["PreisText"] = tperisText;
                        drPos["Fabricate"] = tFabricat;
                        drPos["Type"] = t_Type;
                        drPos["LiefrantMA"] = tLiefrantMA;
                        drPos["WG"] = tWG;
                        drPos["WA"] = tWA;
                        drPos["WI"] = tWI;
                        drPos["LVSection"] = tLVSection;

                        dtPos.Rows.Add(drPos);
                    }

                }
                if (radioGroupActionB.SelectedIndex == 0)
                {
                    if (txtPositionMenge.Text == "")
                    {
                        txtPositionMenge.Text = "";
                    }
                    if (txtMaterialKz.Text == "")
                    {
                        txtMaterialKz.Text = "";
                    }
                    if (txtMontageKZ.Text == "")
                    {
                        txtMontageKZ.Text = "";
                    }
                    if (txtPreisErstaztext.Text == "")
                    {
                        txtPreisErstaztext.Text = "";
                    }
                    if (txtTyp.Text == "")
                    {
                        txtTyp.Text = "";
                    }
                    if (txtFabrikat.Text == "")
                    {
                        txtFabrikat.Text = "";
                    }
                    if (txtBulkLieferantMA.Text == "")
                    {
                        txtBulkLieferantMA.Text = "";
                    }
                    if (txtArtikelnummerWG.Text == "")
                    {
                        txtArtikelnummerWG.Text = "";
                    }
                    if (txtArtikelnummerWA.Text == "")
                    {
                        txtArtikelnummerWA.Text = "";
                    }
                    if (txtArtikelnummerWI.Text == "")
                    {
                        txtArtikelnummerWI.Text = "";
                    }
                    if (checkEditArtikelnummerWG.Checked == true)
                    {
                        if (txtArtikelnummerWG.Text == "")
                        {
                            if(Utility._IsGermany == true)
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
                            if(Utility._IsGermany == true)
                            {
                                XtraMessageBox.Show("Bitte machen Sie eine Angabe zu WA.");
                            }
                            else
                            {
                                XtraMessageBox.Show("Please enter WA value");                                
                            }
                            return;
                        }
                        if (txtArtikelnummerWI.Text == "")
                        {
                            if(Utility._IsGermany == true)
                            {
                                XtraMessageBox.Show("Bitte machen Sie eine Angabe zu WI.");
                            }
                            else
                            {
                                XtraMessageBox.Show("Please enter WI value");                                
                            }
                            return;
                        }
                    }                    
                   
                    if (txtNachtragsnummer.Text == "")
                    {
                        txtNachtragsnummer.Text = "";
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

                ObjBPosition.UpdateBulkProcess_ActionB(ObjEPosition, ObjEProject.ProjectID, tType, txtPositionMenge.Text, txtMaterialKz.Text, txtMontageKZ.Text,
                                                      txtPreisErstaztext.Text, txtFabrikat.Text, txtTyp.Text, txtBulkLieferantMA.Text, txtArtikelnummerWG.Text,
                                                      txtArtikelnummerWA.Text,txtArtikelnummerWI.Text, txtNachtragsnummer.Text, dtPos);

                BindPositionData();
                btnApply_Click(null, null);

                ObjEProject.ProjectID = ProjectID;
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

        private void tlBulkProcessPositionDetails_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "MA_Multi1" ||
e.Column.FieldName == "MA_multi2" ||
e.Column.FieldName == "MA_multi3" ||
e.Column.FieldName == "MA_multi4" ||
e.Column.FieldName == "MA_einkaufspreis" ||
e.Column.FieldName == "MA_selbstkostenMulti" ||
e.Column.FieldName == "MA_verkaufspreis_Multi" ||
e.Column.FieldName == "MA_selbstkosten" ||
e.Column.FieldName == "MA_verkaufspreis" ||
e.Column.FieldName == "MO_multi1" ||
e.Column.FieldName == "MO_multi2" ||
e.Column.FieldName == "MO_multi3" ||
e.Column.FieldName == "MO_multi4" ||
e.Column.FieldName == "MO_Einkaufspreis" ||
e.Column.FieldName == "MO_selbstkostenMulti" ||
e.Column.FieldName == "MO_verkaufspreisMulti" ||
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
                Utility.ShowError(ex);
            }
          }

        private void gvAddRemovePositions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                    // e.Control.KeyPress -= new KeyPressEventHandler(DataGrid_KeyPress);
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
                if (radioGroupselect.SelectedIndex == 0)
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

        private void txtProjectNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextEdit textbox = (TextEdit)sender;
            try
            {
                if (textbox.Text.Length == 0 && e.KeyChar == ' ')
                {
                    e.Handled = true;
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

        private void txtSurchargeFrom_Validating(object sender, CancelEventArgs e)
        {
            if(txtSurchargeTo.Text!="")
            {
                dxValidationProvider1.Validate();
            }
        }

        private void dtpSubmitDate_EditValueChanged(object sender, EventArgs e)
        {
            dtpValidityDate.Value =Convert.ToDateTime(dtpSubmitDate.EditValue);
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
                if(drPosition != null && drPosition.Count() > 0)
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

        private void btnMulti5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEProject.ProjectID > 0)
                {
                    if (objBGAEB == null)
                        objBGAEB = new BGAEB();
                    DataTable dtLVSection = new DataTable();
                    cmbLVSectionFilter.Properties.Items.Clear();
                    dtLVSection = objBGAEB.GetLVSection(_ProjectID);
                    foreach(DataRow dr in dtLVSection.Rows)
                    {
                        cmbLVSectionFilter.Properties.Items.Add(dr["LVSection"]);
                    }
                    btnProjectDetails.BackColor = Color.Silver;
                    btnMulti5.BackColor = Color.DeepSkyBlue;
                    btnLvdetails.BackColor = Color.Silver;
                    btnMulti6.BackColor = Color.Silver;
                    btnBulkProcess.BackColor = Color.Silver;
                    ObjTabDetails = tbMulti5;
                    TabChange(ObjTabDetails);
                    gvMulti5.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void btnMulti6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjEProject.ProjectID > 0)
                {
                    if (objBGAEB == null)
                        objBGAEB = new BGAEB();
                    DataTable dtLVSection = new DataTable();
                    cmbLVSectionFilter.Properties.Items.Clear();
                    dtLVSection = objBGAEB.GetLVSection(_ProjectID);
                    foreach (DataRow dr in dtLVSection.Rows)
                    {
                        cmbMulti6LVFilter.Properties.Items.Add(dr["LVSection"]);
                    }
                    btnProjectDetails.BackColor = Color.Silver;
                    btnMulti5.BackColor = Color.Silver;
                    btnLvdetails.BackColor = Color.Silver;
                    btnMulti6.BackColor = Color.DeepSkyBlue;
                    btnBulkProcess.BackColor = Color.Silver;
                    ObjTabDetails = tbMulti6;
                    TabChange(ObjTabDetails);
                    gvMulti6.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
        #endregion

        private void btnMulti5LoadArticles_Click(object sender, EventArgs e)
        {
            try
            {
                if(ObjEMulti == null)
                    ObjEMulti = new EMulti();
                if(ObjBMulti == null)
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
                btnMulti5LoadArticles_Click(null, null);
                BindPositionData();
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
                TotalValue = (newTotalValue / OldTotalValue) - 1;
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
                btnMulti6LoadArticles_Click(null, null);
                BindPositionData();
            }
            catch (Exception EX)
            {
                Utility.ShowError(EX);
            }
        }
    }
}
