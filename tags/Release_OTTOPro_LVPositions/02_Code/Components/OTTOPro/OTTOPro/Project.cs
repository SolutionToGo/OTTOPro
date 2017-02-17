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

namespace OTTOPro
{
    public partial class frmProject : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Private variables to store the temporary data
        /// </summary>
        private List<Control> RequiredFields = new List<Control>();
        private List<Control> RequiredPositionFields = new List<Control>();
        private int _ProjectID = 0;
        private int _PositionID  = -1;
        private bool _IsCopy = false;
        private byte[] LongDescription = null;
        private bool _IsEditMode = false;

        /// <summary>
        /// Instances for Entity layer and business layer
        /// </summary>
        EProject ObjEProject = new EProject();
        EPosition ObjEPosition = new EPosition();
        BProject ObjBProject = new BProject();
        BPosition ObjBPosition = new BPosition();

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
            else if (e.Link.ItemName.ToLower() == "nvcostdetails" && ObjEProject.ProjectID > 0)
            {
                ObjTabDetails = tbCostDetails;
            }
            TabChange(ObjTabDetails);
        }

        /// <summary>
        /// Code to change the porjet page
        /// </summary>
        /// <param name="ObjTabDetails"></param>
        private void TabChange(XtraTabPage ObjTabDetails)
        {
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

                btnProjectDetails.BackColor = Color.DeepSkyBlue;
                tbLVDetails.PageVisible = false;
                tbCostDetails.PageVisible = false;
                cmbPositionKZ.Text = "N";

                RequiredFields.Add(txtProjectNumber);
                RequiredFields.Add(txtMWST);
                RequiredFields.Add(txtLVSprunge);
                RequiredFields.Add(txtKundeNo);
                RequiredFields.Add(txtKundeName);
                RequiredFields.Add(txtInternS);
                RequiredFields.Add(txtInternX);
                RequiredFields.Add(txtSubmitLocation);
                RequiredFields.Add(ddlRaster);

                dtpSubmitDate.Properties.VistaEditTime = DefaultBoolean.True;
                LoadExistingProject();

                
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
                ObjEProject.LVRaster = ddlRaster.Text;

                if (int.TryParse(txtLVSprunge.Text, out iValue))
                    ObjEProject.LVSprunge = iValue;
                else
                    throw new Exception("Invalid LV Sprunge");

                if (decimal.TryParse(txtMWST.Text, out dValue))
                    ObjEProject.Vat = dValue;
                else
                    throw new Exception("Invalid Vat");

                ObjEProject.ProjectDescription = txtBauvorhaben.Text;
                ObjEProject.KundeID = 1;
                ObjEProject.KundeNr = txtKundeNo.Text;
                ObjEProject.KundeName = txtKundeName.Text;
                ObjEProject.PlannedID = 1;
                ObjEProject.PlannerName = txtPlanner.Text;

                if (decimal.TryParse(txtInternX.Text, out dValue))
                    ObjEProject.InternX = dValue;
                else
                    throw new Exception("Invalid Intern (X)");

                if (decimal.TryParse(txtInternS.Text, out dValue))
                    ObjEProject.InternS = dValue;
                else
                    throw new Exception("Invalid Intern (S)");

                ObjEProject.Submitlocation = txtSubmitLocation.Text;
                ObjEProject.SubmitDate = dtpSubmitDate.DateTime;
                ObjEProject.SubmitTime = dtpSubmitDate.DateTime;

                if (int.TryParse(txtEstimatedLVs.Text, out iValue))
                    ObjEProject.EstimatedLvs = iValue;
                else
                    throw new Exception("Invalid Estimated LVs");

                ObjEProject.RoundingPriceID = 1;
                ObjEProject.Remarks = txtRemarks.Text;
                ObjEProject.LockHierarchy = chkLockHierarchy.Checked;

                if (int.TryParse(ddlRounding.Text, out iValue))
                    ObjEProject.RoundingPrice = iValue;
                else
                    throw new Exception("Invalid Rounding Price");

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
                if (ProjectID > 0)
                {
                    ObjEProject.ProjectID = ProjectID;
                    ObjBProject.GetProjectDetails(ObjEProject);
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
                        IntializeLVPositions();
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
                }
                else
                {
                    txtkommissionNumber.ReadOnly = true;
                    txtLVSprunge.Text = "1";
                    txtInternS.Text = "1";
                    txtInternX.Text = "1";
                    txtMWST.Text = "0";
                    dtpSubmitDate.DateTime = DateTime.Now;
                    dtpProjectStartDate.DateTime = DateTime.Now;
                    dtpProjectEndDate.DateTime = DateTime.Now;
                    ddlRounding.SelectedIndex = ddlRounding.Properties.Items.IndexOf("0");
                    cmbPositionKZ.SelectedIndex = cmbPositionKZ.Properties.Items.IndexOf("N");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_NeedConfirm)
            //{
            //   var dlgresult = XtraMessageBox.Show("Are sure want to close the page", "Confirmation..!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    if(dlgresult.ToString().ToLower() == "cancel")
            //    {
            //        e.Cancel = true;
            //    }
            //}
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
            //tsProjectStatus.Text = Status;
            tmrStatus.Start();
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
           // tsProjectStatus.Text = null;
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
                        lblstufe4.Visible = false;
                        txtStufe4Short.Visible = false;
                        txtStufe4Title.Visible = false;
                        if (Count < 4)
                        {
                            lblstufe3.Visible = false;
                            txtStufe3Short.Visible = false;
                            txtStufe3Title.Visible = false;
                        }
                        if (Count < 3)
                        {
                            lblstufe2.Visible = false;
                            txtStufe2Short.Visible = false;
                            txtStufe2Title.Visible = false;
                        }
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
                ObjEPosition.PositionID = _PositionID;
                ObjEPosition.ProjectID = ObjEProject.ProjectID;
                ObjEPosition.Stufe1 = txtStufe1Short.Text.Trim();
                ObjEPosition.Stufe2 = txtStufe2Short.Text.Trim();
                ObjEPosition.Stufe3 = txtStufe3Short.Text.Trim();
                ObjEPosition.Stufe4 = txtStufe4Short.Text.Trim();
                ObjEPosition.Stufe1Title = txtStufe1Title.Text;
                ObjEPosition.Stufe2Title = txtStufe2Title.Text;
                ObjEPosition.Stufe3Title = txtStufe3Title.Text;
                ObjEPosition.Stufe4Title = txtStufe4Title.Text;
                ObjEPosition.Position = txtPosition.Text;
                ObjEPosition.ShortDescription = txtShortDescription.Text;
                if (txtPosition.Text != string.Empty)
                    ObjEPosition.PositionKZ = cmbPositionKZ.Text;
                else
                    ObjEPosition.PositionKZ = "ZZZ";
                
                if(int.TryParse(txtDetailKZ.Text,out iValue))
                ObjEPosition.DetailKZ = iValue;

                ObjEPosition.LVSection = cmbLVSection.Text;

                if (int.TryParse(txtWG.Text, out iValue))
                    ObjEPosition.WG = iValue;
                
                if (int.TryParse(txtWA.Text, out iValue))
                    ObjEPosition.WA = iValue;
                
                if (int.TryParse(txtWI.Text, out iValue))
                    ObjEPosition.WI = iValue;

                if (int.TryParse(txtMenge.Text, out iValue))
                    ObjEPosition.Menge = iValue;

                ObjEPosition.ME = cmbME.Text;
                ObjEPosition.Fabricate = txtFabrikate.Text;
                ObjEPosition.Type = txtType.Text;
                ObjEPosition.LongDescription = LongDescription;

                ObjEPosition.Surcharge_From = txtSurchargeFrom.Text;
                ObjEPosition.Surcharge_To = txtSurchargeTo.Text;
                decimal dValue = 0;
                if(decimal.TryParse(txtSurchargePerME.Text,out dValue))
                    ObjEPosition.Surcharge_Per = dValue;

                if (decimal.TryParse(txtSurchargePerMO.Text, out dValue))
                    ObjEPosition.surchargePercentage_MO = dValue;
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
                ObjBPosition.GetPositionList(ObjEPosition, ObjEProject.ProjectID);
                if (ObjEPosition.dsPositionList != null)
                {
                    CalculateDetailKZ(ObjEPosition.dsPositionList.Tables[0], "GB");
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
                //throw;
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
                    tlPositions.DataSource = ObjEPosition.dsPositionList;
                    tlPositions.DataMember = "Positions";
                    tlPositions.ParentFieldName = "Positions";                   
                    tlPositions.ForceInitialize();
                    tlPositions.ExpandAll();
                    CalculateNodes(tlPositions,"GB");
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
                if (!_IsEditMode)
                {
                    LongDescription = null;
                    string strPositionID = tlPositions.FocusedNode["PositionID"].ToString();
                    DataView dvPosition = ObjEPosition.dsPositionList.Tables[0].DefaultView;
                    dvPosition.RowFilter = "PositionID = '" + strPositionID + "'";
                    DataTable dtTemp = dvPosition.ToTable();
                    string strPositionOZ = dtTemp.Rows[0]["Position_OZ"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["Position_OZ"].ToString();

                    if (!string.IsNullOrEmpty(strPositionOZ))
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
                                if (TitleCount > 1)
                                {
                                    txtStufe2Short.Text = Titles[1];
                                    if (TitleCount > 2)
                                    {
                                        txtStufe3Short.Text = Titles[2];
                                        if (TitleCount > 3)
                                        {
                                            txtStufe4Short.Text = Titles[3];
                                        }
                                        else
                                        {
                                            txtStufe4Short.Text = string.Empty;
                                        }
                                    }
                                    else
                                    {
                                        txtStufe3Short.Text = string.Empty;
                                    }
                                }
                                else
                                {
                                    txtStufe2Short.Text = string.Empty;
                                }
                            }
                            else
                                txtStufe1Short.Text = string.Empty;
                            txtPosition.Text = Titles[TitleCount] + "." + Titles[TitleCount + 1];
                        }
                        else if (TitleCount == Raster.Count() - 1)
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
                                        txtStufe3Short.Text = string.Empty;
                                }
                                else
                                    txtStufe2Short.Text = string.Empty;
                            }
                            else
                                txtStufe1Short.Text = string.Empty;
                            txtPosition.Text = Titles[TitleCount];
                        }
                        else if (TitleCount < Raster.Count() - 1)
                        {
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
                                        txtStufe3Short.Text = string.Empty;
                                }
                                else
                                    txtStufe2Short.Text = string.Empty;

                            }
                            else
                                txtStufe1Short.Text = string.Empty;
                            txtPosition.Text = string.Empty;
                        }
                        txtLVPosition.Text = strPositionOZ;
                    }

                    string strTitle = dtTemp.Rows[0]["GetTitle"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["GetTitle"].ToString();
                    string[] titles = strTitle.Split('~');
                    if (titles != null)
                    {
                        if (titles.Count() > 1)
                            txtStufe1Title.Text = titles[1];
                        else
                            txtStufe1Title.Text = string.Empty;

                        if (titles.Count() > 2)
                            txtStufe2Title.Text = titles[2];
                        else
                            txtStufe2Title.Text = string.Empty;

                        if (titles.Count() > 3)
                            txtStufe3Title.Text = titles[3];
                        else
                            txtStufe3Title.Text = string.Empty;

                        if (titles.Count() > 4)
                            txtStufe4Title.Text = titles[3];
                        else
                            txtStufe4Title.Text = string.Empty;
                    }

                    txtWG.Text = dtTemp.Rows[0]["WG"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["WG"].ToString();
                    txtWI.Text = dtTemp.Rows[0]["WI"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["WI"].ToString();
                    txtWA.Text = dtTemp.Rows[0]["WA"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["WA"].ToString();
                    txtType.Text = dtTemp.Rows[0]["Type"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["Type"].ToString();
                    txtFabrikate.Text = dtTemp.Rows[0]["Fabricate"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["Fabricate"].ToString();
                    txtMenge.Text = dtTemp.Rows[0]["Menge"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["Menge"].ToString();
                    cmbPositionKZ.SelectedIndex = cmbPositionKZ.Properties.Items.IndexOf(dtTemp.Rows[0]["PositionKZ"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["PositionKZ"].ToString());
                    txtDetailKZ.Text = dtTemp.Rows[0]["DetailKZ"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["DetailKZ"].ToString();
                    txtShortDescription.Text = dtTemp.Rows[0]["ShortDescription"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["ShortDescription"].ToString();
                    cmbME.SelectedIndex = cmbME.Properties.Items.IndexOf(dtTemp.Rows[0]["ME"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["ME"].ToString());
                    cmbLVSection.SelectedIndex = cmbLVSection.Properties.Items.IndexOf(dtTemp.Rows[0]["LVSection"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["LVSection"].ToString());
                    txtSurchargeFrom.Text = dtTemp.Rows[0]["surchargefrom"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["surchargefrom"].ToString();
                    txtSurchargeTo.Text = dtTemp.Rows[0]["surchargeto"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["surchargeto"].ToString();
                    txtSurchargePerME.Text = dtTemp.Rows[0]["surchargePercentage"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["surchargePercentage"].ToString();
                    txtSurchargePerMO.Text = dtTemp.Rows[0]["surchargePercentage_MO"] == DBNull.Value ? string.Empty : dtTemp.Rows[0]["surchargePercentage_MO"].ToString();
                }
            }
            catch (Exception ex)
            {

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
                    frmViewdescription Obj = new frmViewdescription();
                    if (LongDescription == null)
                        Obj.LongDescription = ObjBPosition.GetLongDescription(Convert.ToInt32(tlPositions.FocusedNode["PositionID"]));
                    else
                        Obj.LongDescription = LongDescription;
                    Obj.ShowDialog();
                    LongDescription = Obj.LongDescription;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                int iValue = 0;
                if (tlPositions.FocusedNode != null 
                    && tlPositions.FocusedNode["PositionID"] != null 
                    && Int32.TryParse(tlPositions.FocusedNode["PositionID"].ToString(), out iValue) 
                    && _IsEditMode == false)
                {
                    _IsEditMode = true;
                    _PositionID = iValue;
                    txtStufe1Title.Enabled = false;
                    txtStufe2Title.Enabled = false;
                    txtStufe3Title.Enabled = false;
                    txtStufe4Title.Enabled = false;
                }
                else if(_IsEditMode)
                {
                    XtraMessageBox.Show("Please save the changes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Please select atleast one position", "Inoformation..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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


        private void tlPositions_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
           // TreeListHitInfo hitInfo = tlPositions.CalcHitInfo(e.Point);          
        }

        private void tlPositions_ShownEditor(object sender, EventArgs e)
        {
           
            var view = (TreeList)sender;
            var editor = view.ActiveEditor as TextEdit;

            if (editor == null)
                return;

            editor.ContextMenuStrip = new ContextMenuStrip();

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

           DataTable dt= ObjEPosition.dsPositionList.Tables[0];

           int Parent_OZ = (from DataRow dr in dt.Rows
                            where (string)dr["Position_OZ"] == cellText
                            select (int)dr["Parent_OZ"]).FirstOrDefault();

           object Position_OZ = dt.Compute("MAX(Position_OZ)", "Parent_OZ='" + Parent_OZ + "' and PositionKZ <>'" + "S" + "'");

           //MessageBox.Show(Position_OZ.ToString());

           frmAdhocPosition frm = new frmAdhocPosition(Position_OZ.ToString());
           frm.ShowDialog();

        }

        private void tlPositions_CustomDrawColumnHeader(object sender, CustomDrawColumnHeaderEventArgs e)
        {
            if (e.Pressed)
                paintSunkenBackground(e.Graphics, e.Bounds);
            else
                paintRaisedBackground(e.Graphics, e.Bounds);
            if (e.ColumnType == HitInfoType.Column)
                paintHAlignedText(e.Graphics, e.Bounds, e.Column.GetCaption(), StringAlignment.Center);
            e.Handled = true;
        }

        // Custom draw methods:

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
            btnCostDetails.BackColor = Color.Silver;
            ObjTabDetails = tbProjectDetails;
            TabChange(ObjTabDetails);
        }

        private void btnLvdetails_Click(object sender, EventArgs e)
        {
            if (ObjEProject.ProjectID > 0)
            {
                btnProjectDetails.BackColor = Color.Silver;
                btnLvdetails.BackColor = Color.DeepSkyBlue;
                btnCostDetails.BackColor = Color.Silver;
                IntializeLVPositions();
                ObjTabDetails = tbLVDetails;
                BindPositionData();
                TabChange(ObjTabDetails);
            }
        }

        private void btnCostDetails_Click(object sender, EventArgs e)
        {
            if (ObjEProject.ProjectID > 0)
            {
                btnProjectDetails.BackColor = Color.Silver;
                btnLvdetails.BackColor = Color.Silver;
                btnCostDetails.BackColor = Color.DeepSkyBlue;
                ObjTabDetails = tbCostDetails;
                TabChange(ObjTabDetails);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPageHierachical")
            {
                BindPositionData();
            }
            else
            {
                BindPositionDataTabular();

            }
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
            if (Node.HasChildren)
            {
                decimal iValue = 0;
                foreach (TreeListNode node in Node.Nodes)
                {
                    CalculateTitleSum(node, strField);
                    decimal lValue = 0;
                    if (node["PositionKZ"].ToString() != "S" &&
                        node["DetailKZ"].ToString() == "0" &&
                        decimal.TryParse(node[strField].ToString(), out lValue))
                    {
                        iValue += lValue;
                    }
                }
                Node.SetValue(tlPositions.Columns[strField], iValue.ToString());
            }
        }

        private void CalculateDetailKZ(DataTable dt, string strField)
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
                        TargetRow[0][strField] = iValue.ToString();
                }
            }
        }

        private void cmbPositionKZ_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPositionKZ.Text) && (cmbPositionKZ.Text.ToLower() == "s" || cmbPositionKZ.Text.ToLower() == "z"))
            {
                txtPosition.Enabled = false;
                txtLVPosition.Enabled = false;
                txtWG.Enabled = false;
                txtWA.Enabled = false;
                txtWI.Enabled = false;
                txtMenge.Enabled = false;
                txtFabrikate.Enabled = false;
                txtType.Enabled = false;
                txtDetailKZ.Enabled = false;
                cmbLVSection.Enabled = false;
                cmbME.Enabled = false;

                if (cmbPositionKZ.Text.ToLower() == "s")
                {
                    txtPosition.Text = "ZZZ.Z";
                    if (txtSurchargeFrom.Text == "" || txtSurchargeTo.Text == "")
                    {
                        lblsurchargeme.Visible = false;
                        lblsurchargemo.Visible = false;
                        lblsurchargefrom.Visible = true;
                        lblsurchargeto.Visible = true;
                        txtSurchargePerMO.Visible = false;
                        txtSurchargePerME.Visible = false;
                        txtSurchargeFrom.Visible = true;
                        txtSurchargeTo.Visible = true;

                        //int Parentnode = Convert.ToInt32(tlPositions.FocusedNode.ParentNode["Position_OZ"]);
                        string tstufe = txtStufe1Short.Text + "." + txtStufe2Short.Text;

                        DataTable dt = ObjEPosition.dsPositionList.Tables[0];

                        DataRow[] tPosition_Id = dt.Select("Position_OZ='" + tstufe + "'");
                        string tResult = tPosition_Id[0]["PositionID"] == DBNull.Value ? "" : tPosition_Id[0]["PositionID"].ToString();
                        object Min_Identity = dt.Compute("MIN(Indetity_Column)", "Parent_OZ =" + tResult + "And PositionKZ <> 'S'");
                        object Max_Identity = dt.Compute("MAX(Indetity_Column)", "Parent_OZ =" + tResult + "And PositionKZ <> 'S'");

                        string MinValue = dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Min_Identity) == DBNull.Value ? "" : dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Min_Identity).ToString();
                        string MaxValue = dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Max_Identity) == DBNull.Value ? "" : dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Max_Identity).ToString();

                        txtSurchargeFrom.Text = MinValue;
                        txtSurchargeTo.Text = MaxValue;
                    }

                }

                else
                {
                    txtPosition.Enabled = true;
                    ClearingValues();
                }
                txtLVPosition.Text = string.Empty;
                txtWG.Text = string.Empty;
                txtWA.Text = string.Empty;
                txtWI.Text = string.Empty;
                txtMenge.Text = string.Empty;
                txtFabrikate.Text = string.Empty;
                txtType.Text = string.Empty;
                txtDetailKZ.Text = string.Empty;
                cmbLVSection.Text = string.Empty;
                cmbME.Text = string.Empty;

                
                if (cmbPositionKZ.Text.ToLower() == "z")
                {
                   // frmAdhocPosition Obj = new frmAdhocPosition();
                    if (tlPositions.FocusedNode != null)
                    {
                        if (txtSurchargeFrom.Text == "" || txtSurchargeTo.Text == "")
                        {
                            lblsurchargeme.Visible = true;
                            lblsurchargemo.Visible = true;
                            lblsurchargefrom.Visible = true;
                            lblsurchargeto.Visible = true;
                            txtSurchargePerME.Visible = true;
                            txtSurchargePerMO.Visible = true;
                            txtSurchargeFrom.Visible = true;
                            txtSurchargeTo.Visible = true;
                            //txtSurchargePerME.Text = tlPositions.FocusedNode["surchargePercentage"].ToString();
                            //txtSurchargeFrom.Text = tlPositions.FocusedNode["surchargefrom"].ToString();
                            //txtSurchargeTo.Text = tlPositions.FocusedNode["surchargeto"].ToString();
                            string tstufe = txtStufe1Short.Text + "." + txtStufe2Short.Text;

                            DataTable dt = ObjEPosition.dsPositionList.Tables[0];

                            DataRow[] tPosition_Id = dt.Select("Position_OZ='" + tstufe + "'");
                            string tResult = tPosition_Id[0]["PositionID"] == DBNull.Value ? "" : tPosition_Id[0]["PositionID"].ToString();
                            object Min_Identity = dt.Compute("MIN(Indetity_Column)", "Parent_OZ =" + tResult + "And PositionKZ == 'N'");
                            object Max_Identity = dt.Compute("MAX(Indetity_Column)", "Parent_OZ =" + tResult + "And PositionKZ == 'N'");

                            string MinValue = dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Min_Identity) == DBNull.Value ? "" : dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Min_Identity).ToString();
                            string MaxValue = dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Max_Identity) == DBNull.Value ? "" : dt.Compute("MIN(Position_OZ)", "Indetity_Column =" + Max_Identity).ToString();

                            txtSurchargeFrom.Text = MinValue;
                            txtSurchargeTo.Text = MaxValue;
                        }
                    }
                    //Obj.ShowDialog();
                    //_SurchargePer = Obj.SurchargePer;
                    //_SurchargeFrom = Obj.SurchargeFrom;
                    //_SurchargeTo = Obj.SurchargeTo;
                }
                
            }
            else
            {
                txtPosition.Enabled = true;
                txtLVPosition.Enabled = true;
                txtWG.Enabled = true;
                txtWA.Enabled = true;
                txtWI.Enabled = true;
                txtMenge.Enabled = true;
                txtFabrikate.Enabled = true;
                txtType.Enabled = true;
                txtDetailKZ.Enabled = true;
                cmbLVSection.Enabled = true;
                cmbME.Enabled = true;
                ClearingValues();
               
            }
        }

        public void ClearingValues()
        {
            lblsurchargeme.Visible = false;
            lblsurchargemo.Visible = false;
            lblsurchargefrom.Visible = false;
            lblsurchargeto.Visible = false;
                txtSurchargePerME.Visible = false;
                txtSurchargePerMO.Visible = false;
                txtSurchargeFrom.Visible = false;
                txtSurchargeTo.Visible = false;
                txtSurchargePerME.Text = "";
                txtSurchargePerMO.Text = "";
                txtSurchargeFrom.Text = "";
                txtSurchargeTo.Text = "";
        }

        private void tlPositions_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                if (e.Node["PositionKZ"].ToString().ToLower() == "s")
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
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
                    if (strPosition == "z" || strPosition == "s")
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

        private string GetTotalValue(DataTable dt, DataRow dr, string strField,string strPosition)
        {
            decimal TotalValue = 0;
            try
            {
                string strFromOZ = dr["surchargefrom"] == DBNull.Value ? "" : dr["surchargefrom"].ToString();
                string strToOZ = dr["surchargeto"] == DBNull.Value ? "" : dr["surchargeto"].ToString();
                decimal strPer = Convert.ToDecimal(dr["surchargePercentage"] == DBNull.Value ? 0 : dr["surchargePercentage"]);


                        DataRow[] FilteredFromRow = dt.Select("Position_OZ = '" + strFromOZ + "'");
                        DataRow[] FilteredToRow = dt.Select("Position_OZ = '" + strToOZ + "'");

                        int ifromValue = 0;
                        int itoValue = 0;

                        if (FilteredFromRow != null && FilteredFromRow.Count() > 0)
                            ifromValue = Convert.ToInt32(FilteredFromRow[0]["Identity_Column"]);

                        if (FilteredToRow != null && FilteredToRow.Count() > 0)
                            itoValue = Convert.ToInt32(FilteredToRow[0]["Identity_Column"]);

                object Obj = dt.Compute("SUM(" + strField + ")", "Identity_Column >=" + ifromValue +
                    "And Identity_Column <=" + itoValue + "And DetailKZ = 0");
                decimal Sum = Obj == DBNull.Value ? 0 : Convert.ToDecimal(Obj);
                if (strPosition == "z")
                    TotalValue = (strPer * Sum) / 100;
                else
                    TotalValue = Sum;
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
                    strConfirmation = XtraMessageBox.Show("Are you sure want to convert ga   project into kommission..?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                }
                else
                    strConfirmation = "Yes";

                if (strConfirmation.ToLower() == "yes")
                {
                    ObjBProject.SaveProjectDetails(ObjEProject);
                    UpdateStatus(ObjEProject.ProjectNumber + " Details Saved Successfully");
                }
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
                if (Utility.ValidateRequiredFields(RequiredPositionFields) == false)
                    return;
                ObjEPosition = new EPosition();
                ParsePositionDetails();
                int NewPositionID = ObjBPosition.SavePositionDetails(ObjEPosition);
                BindPositionData();
                SetFocus(NewPositionID);
                _IsEditMode = false;
                txtStufe1Title.Enabled = true;
                txtStufe2Title.Enabled = true;
                txtStufe3Title.Enabled = true;
                txtStufe4Title.Enabled = true;
                _PositionID = -1;
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
   }
}
 