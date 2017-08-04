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
    }
}
