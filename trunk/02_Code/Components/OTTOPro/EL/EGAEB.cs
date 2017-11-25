using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EL
{
    public class EGAEB
    {
        private int _ProjectID = -1;
        private XmlDocument _XMLDoc = null;
        private string _OldRaster = string.Empty;
        private string _NewRaster = string.Empty;
        private DataSet _dsLVData;
        private string _ProjectDescription = string.Empty;
        private string _ProjectNumber = string.Empty;
        private string _LvRaster = string.Empty;
        private int _LVSprunge = 0;
        private string _customerName = string.Empty;
        private int _UserID = 0;
        private DataSet _dsProject = null;
        private bool _IsSave = false;
        private string _DirPath = string.Empty;


        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        public XmlDocument XMLDoc
        {
            get { return _XMLDoc; }
            set { _XMLDoc = value; }
        }

        public string OldRaster
        {
            get { return _OldRaster; }
            set { _OldRaster = value; }
        }

        public string NewRaster
        {
            get { return _NewRaster; }
            set { _NewRaster = value; }
        }
        public  DataTable _dtLVRaster;
        public  DataTable dtLVRaster
        {
            get { return _dtLVRaster; }
            set { _dtLVRaster = value; }
        }
        public DataSet dsLVData
        {
            get { return _dsLVData; }
            set { _dsLVData = value; }
        }
        public string ProjectDescription
        {
            get { return _ProjectDescription; }
            set { _ProjectDescription = value; }
        }
        public string LvRaster
        {
            get { return _LvRaster; }
            set { _LvRaster = value; }
        }
        public int LVSprunge
        {
            get { return _LVSprunge; }
            set { _LVSprunge = value; }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string ProjectNumber
        {
            get { return _ProjectNumber; }
            set { _ProjectNumber = value; }
        }
        public DataSet dsProject
        {
            get { return _dsProject; }
            set { _dsProject = value; }
        }
        public bool IsSave
        {
            get { return _IsSave; }
            set { _IsSave = value; }
        }
        public string DirPath
        {
            get { return _DirPath; }
            set { _DirPath = value; }
        }
    }
}
