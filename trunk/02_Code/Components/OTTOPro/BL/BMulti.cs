using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BMulti
    {
        DMulti ObjDMulti = new DMulti();

        public EMulti GetArticleGroups(EMulti ObjEMulti)
        {
            try
            {
               ObjEMulti = ObjDMulti.GetArticleGroups(ObjEMulti);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEMulti;
        }

        public EMulti UpdateMulti5(EMulti ObjEMulti)
        {
            try
            {
               ObjEMulti = ObjDMulti.UpdateMulti5(ObjEMulti);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEMulti;
        }

    }
}
