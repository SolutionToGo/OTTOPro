using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EPosition
    {
        // Private variables to hold the values
        private int _PositionID = -1;
        private int _ProjectID;
        private string _Stufe1;
        private string _Stufe2;
        private string _Stufe3;
        private string _Stufe4;
        private string _Stufe1Title;
        private string _Stufe2Title;
        private string _Stufe3Title;
        private string _Stufe4Title;
        private string _Position;
        private string _Position_OZ;
        private string _Parent_OZ;
        private string _Title;
        private string _ShortDescription;
        private byte[] _LongDescription;
        private string _PositionKZ;
        private int _DetailsKZ = 0;
        private string _LVSection;
        private int _WG;
        private int _WA;
        private int _WI;
        private int _Menge;
        private string _ME;
        private string _Fabricate;
        private string _Type;
        private string _LVStatus;
        private int _ProposalNo;
        private string _Surcharge_From;
        private string _Surcharge_To;
        private decimal _Surcharge_Per;
        private int _UserID;
        private DataSet _dtPositionList;
        private decimal _surchargePercentage_MO;

        // Public Properties to bind the values
        public int PositionID
        {
            get { return _PositionID; }
            set { _PositionID = value; }
        }
        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        public string Stufe1
        {
            get { return _Stufe1; }
            set { _Stufe1 = value; }
        }
        public string Stufe2
        {
            get { return _Stufe2; }
            set { _Stufe2 = value; }
        }
        public string Stufe3
        {
            get { return _Stufe3; }
            set { _Stufe3 = value; }
        }
        public string Stufe4
        {
            get { return _Stufe4; }
            set { _Stufe4 = value; }
        }
        public string Stufe1Title
        {
            get { return _Stufe1Title; }
            set { _Stufe1Title = value; }
        }
        public string Stufe2Title
        {
            get { return _Stufe2Title; }
            set { _Stufe2Title = value; }
        }
        public string Stufe3Title
        {
            get { return _Stufe3Title; }
            set { _Stufe3Title = value; }
        }
        public string Stufe4Title
        {
            get { return _Stufe4Title; }
            set { _Stufe4Title = value; }
        }
        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        public string Position_OZ
        {
            get { return _Position_OZ; }
            set { _Position_OZ = value; }
        }
        public string Parent_OZ
        {
            get { return _Parent_OZ; }
            set { _Parent_OZ = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string ShortDescription 
        {
            get { return _ShortDescription; }
            set { _ShortDescription = value; }
        }
        public byte[] LongDescription
        {
            get { return _LongDescription; }
            set { _LongDescription = value; }
        }
        public string PositionKZ
        {
            get { return _PositionKZ; }
            set { _PositionKZ = value; }
        }
        public int DetailKZ
        {
            get { return _DetailsKZ; }
            set { _DetailsKZ = value; }
        }
        public string LVSection
        {
            get { return _LVSection; }
            set { _LVSection = value; }
        }
        public int WG
        {
            get { return _WG; }
            set { _WG = value; }
        }
        public int WA
        {
            get { return _WA; }
            set { _WA = value; }
        }
        public int WI
        {
            get { return _WI; }
            set { _WI = value; }
        }
        public int Menge
        {
            get { return _Menge; }
            set { _Menge = value; }
        }
        public string ME
        {
            get { return _ME; }
            set { _ME = value; }
        }
        public string Fabricate
        {
            get { return _Fabricate; }
            set { _Fabricate = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string LVStatus
        {
            get { return _LVStatus; }
            set { _LVStatus = value; }
        }
        public int ProposalNo
        {
            get { return _ProposalNo; }
            set { _ProposalNo = value; }
        }
        public string Surcharge_From
        {
            get { return _Surcharge_From; }
            set { _Surcharge_From = value; }
        }
        public string Surcharge_To
        {
            get { return _Surcharge_To; }
            set { _Surcharge_To = value; }
        }
        public decimal Surcharge_Per
        {
            get { return _Surcharge_Per; }
            set { _Surcharge_Per = value; }
        }
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public DataSet dsPositionList
        {
            get { return _dtPositionList; }
            set { _dtPositionList = value; }
        }
        public decimal surchargePercentage_MO
        {
            get { return _surchargePercentage_MO; }
            set { _surchargePercentage_MO = value; }
        }
    }
}