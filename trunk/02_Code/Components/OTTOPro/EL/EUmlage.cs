using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EUmlage
    {
        private int _ProjectID = -1;
        private DataTable _dtSpecialCost = null;
        private DataTable _dtUmlage = null;

        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        public DataTable dtSpecialCost
        {
            get { return _dtSpecialCost; }
            set { _dtSpecialCost = value; }
        }
        public DataTable dtUmlage
        {
            get { return _dtUmlage; }
            set { _dtUmlage = value; }
        }
    }
}
