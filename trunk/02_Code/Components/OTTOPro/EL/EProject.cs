using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EProject
    {
        /// <summary>
        /// Private Variables for Project Modules
        /// </summary>
        private int _ProjectID = -1;
        private string _Location = "Bangalore";
        private string _ProjectNumber;
        private string _CommissionNumber;
        private string _LVRaster;
        private string _LVRaster_GAEB = "fdsfdsafdsa";
        private decimal _Vat;
        private int _LVSprunge;
        private string _ProjectDescription;
        private int _KundeID = 1;
        private int _PlannnerID = 1;
        private int _ProjectDuration;
        private decimal _InternX;
        private decimal _InternS;
        private string _Submitlocation;
        private DateTime _SubmitDateTime;
        private DateTime _SubmitTime;
        private int _EstimatedLVs;
        private int _ActualLvs;
        private int _RoundingPriceID = 1;
        private decimal _Discount;
        private string _Remarks;
        private bool _LockHierarcy;
        private int _UserID = 1;
        private DateTime _ProjectStartDate;
        private DateTime _ProjectEndDate;
        private DataTable _dtProjectList = null;
        private bool _IsDisable = false;
        private bool _IsFinalInvoice = false;
        private string _Status = string.Empty;
        private string _OldRaster;

        /// <summary>
        /// Temparary Private Variables for Project Modules
        /// </summary>
        private string _PlannerName;
        private string _KundeNr;
        private string _KundeName;
        private int _RoundingPrice = 3;
        private DataTable _dtLVSection;
        private bool _IsCumulated = false;

        //Project Copy LVs
        private DataTable _dtProjecNumber = null;

        public DataTable dtProjecNumber
        {
            get { return _dtProjecNumber; }
            set { _dtProjecNumber = value; }
        }

        /// <summary>
        /// Public Properties for Project Module
        /// </summary>
        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        public string Location
        { get { return _Location; } set { _Location = value; } }
        public string ProjectNumber
        {
            get { return _ProjectNumber; }
            set { _ProjectNumber = value; }
        }
        public string CommissionNumber
        {
            get { return _CommissionNumber; }
            set { _CommissionNumber = value; }
        }
        public string LVRaster
        {
            get { return _LVRaster; }
            set { _LVRaster = value; }
        }
        public string LVRaster_GAEB
        { get { return _LVRaster_GAEB; } set { _LVRaster_GAEB = value; } }
        public decimal Vat
        {
            get { return _Vat; }
            set { _Vat = value; }
        }
        public int LVSprunge
        {
            get { return _LVSprunge; }
            set { _LVSprunge = value; }
        }
        public string ProjectDescription
        {
            get { return _ProjectDescription; }
            set { _ProjectDescription = value; }
        }
        public int KundeID
        {
            get { return _KundeID; }
            set { _KundeID = value; }
        }
        public int PlannedID
        {
            get { return _PlannnerID; }
            set { _PlannnerID = value; }
        }
        public int ProjectDuration
        {
            get { return _ProjectDuration; }
            set { _ProjectDuration = value; }
        }
        public decimal InternX
        {
            get { return _InternX; }
            set { _InternX = value; }
        }
        public decimal InternS
        {
            get { return _InternS; }
            set { _InternS = value; }
        }
        public string Submitlocation
        {
            get { return _Submitlocation; }
            set { _Submitlocation = value; }
        }
        public DateTime SubmitDate
        {
            get { return _SubmitDateTime; }
            set { _SubmitDateTime = value; }
        }
        public DateTime SubmitTime
        { get { return _SubmitTime; } set { _SubmitTime = value; } }
        public int EstimatedLvs
        {
            get { return _EstimatedLVs; }
            set { _EstimatedLVs = value; }
        }
        public int RoundingPriceID
        {
            get { return _RoundingPriceID; }
            set { _RoundingPriceID = value; }
        }
        public decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public bool LockHierarchy
        {
            get { return _LockHierarcy; }
            set { _LockHierarcy = value; }
        }
        public int UserID
        {
            get { return _UserID;}
            set { _UserID = value; }
        }
        public DataTable dtProjectList
        {
            get { return _dtProjectList; }
            set { _dtProjectList = value; }
        }
        public int ActualLvs
        {
            get { return _ActualLvs; }
            set { _ActualLvs = value; }
        }
        public DateTime ProjectStartDate
        {
            get { return _ProjectStartDate; }
            set { _ProjectStartDate = value; }
        }
        public DateTime ProjectEndDate
        {
            get { return _ProjectEndDate; }
            set { _ProjectEndDate = value; }
        }

        public string OldRaster
        {
            get { return _OldRaster; }
            set { _OldRaster = value; }
        }

        /// <summary>
        /// Temporary Properties for Project Modiles
        /// </summary>
        public string KundeNr
        {
            get { return _KundeNr; }
            set { _KundeNr = value; }
        }
        public string KundeName
        {
            get { return _KundeName; }
            set { _KundeName = value; }
        }
        public string PlannerName
        {
            get { return _PlannerName; }
            set { _PlannerName = value; }
        }
        public int RoundingPrice
        {
            get { return _RoundingPrice; }
            set { _RoundingPrice = value; }
        }
        public bool IsDisable
        {
            get { return _IsDisable; }
            set { _IsDisable = value; }
        }
        public DataTable dtLVSection
        {
            get { return _dtLVSection; }
            set { _dtLVSection = value; }
        }
        public bool IsCumulated
        {
            get { return _IsCumulated; }
            set { _IsCumulated = value; }
        }
        public bool IsFinalInvoice
        {
            get { return _IsFinalInvoice; }
            set { _IsFinalInvoice = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
