using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EArticles
    {
        //To hold the WG/WA Details
        private int _WGID = -1;
        private int _WG;
        private int _WA;
        private string _WGDescription;
        private DataSet _dtArticles;

        //To hold WI details
        private int _wi_WGID;
        private int _WIID=-1;
        private int _WI;
        private string _WIDescription;

        // WG/WA Properties
        public DataSet dsArticles
        {
            get { return _dtArticles; }
            set { _dtArticles = value; }
        }
        public int WGID
        {
            get { return _WGID; }
            set { _WGID = value; }
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
        public string WGDescription
        {
            get { return _WGDescription; }
            set { _WGDescription = value; }
        }

        // WI Properties
        public int wi_WGID
        {
            get { return _wi_WGID; }
            set { _wi_WGID = value; }
        }

        public int WIID
        {
            get { return _WIID; }
            set { _WIID = value; }
        }
        public int WI
        {
            get { return _WI; }
            set { _WI = value; }
        }
        public string WIDescription
        {
            get { return _WIDescription; }
            set { _WIDescription = value; }
        }

    }
}
