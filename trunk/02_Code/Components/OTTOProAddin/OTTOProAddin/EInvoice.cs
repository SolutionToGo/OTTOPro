using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTOProAddin
{
    public class EInvoice
    {

        private DataSet _dsProject;
        private DataSet _dsInvoice;
        private int _ProjectID;

        public DataSet dsProject
        {
            get { return _dsProject; }
            set { _dsProject = value; }
        }

        public DataSet dsInvoice
        {
            get { return _dsInvoice; }
            set { _dsInvoice = value; }
        }

        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
    }
}
