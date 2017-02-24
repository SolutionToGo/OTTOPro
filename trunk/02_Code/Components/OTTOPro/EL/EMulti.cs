using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EMulti
    {
        private string _LVSection = string.Empty;
        private int _ProjectID = -1;
        private DataTable _dtArticles = null;

        public string LVSection
        {
            get { return _LVSection; }
            set { _LVSection = value; }
        }

        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }

        public DataTable dtArticles
        {
            get { return _dtArticles; }
            set { _dtArticles = value; }
        }
    }
}
