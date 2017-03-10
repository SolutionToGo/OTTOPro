using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EL;
using System.Data;

namespace BL
{
    public class BArticles
    {
        DArticles ObjDArticles = new DArticles();

        public DataSet  GetArticles(EArticles ObjEArticles, int _wgId, int _WiId)
        {
            DataSet dsArticles = new DataSet();
            try
            {
                if (ObjEArticles != null)
                {
                   dsArticles= ObjEArticles.dsArticles = ObjDArticles.GetArticles(_wgId, _WiId);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsArticles;
        }
    }
 
}
