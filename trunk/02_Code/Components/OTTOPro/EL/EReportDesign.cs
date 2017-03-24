using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EReportDesign
    {
        //Report Design 
        private string _Col1;
        private string _Col2;
        private string _Col3;

        private DataSet _dsReportDesign;
        public DataSet dsReportDesign
        {
            get { return _dsReportDesign; }
            set { _dsReportDesign = value; }
        }

        public string Col1
        {
            get { return _Col1; }
            set { _Col1 = value; }
        }
        public string Col2
        {
            get { return _Col2; }
            set { _Col2 = value; }
        }
        public string Col3
        {
            get { return _Col3; }
            set { _Col3 = value; }
        }

    }
}
