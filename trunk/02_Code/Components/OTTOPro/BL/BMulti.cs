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

        public EMulti GetArticleGroupsForMulti6(EMulti ObjEMulti)
        {
            try
            {
                ObjEMulti = ObjDMulti.GetArticleGroupsForMulti6(ObjEMulti);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEMulti;
        }

        public EMulti UpdateMulti6(EMulti ObjEMulti)
        {
            try
            {
                ObjEMulti = ObjDMulti.UpdateMulti6(ObjEMulti);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEMulti;
        }

        public EMulti GetSOldMultis(EMulti ObjEMulti)
        {
            try
            {
                ObjDMulti.GetSOldMultis(ObjEMulti);
            }
            catch (Exception ex){}
            return ObjEMulti;
        }

        public EMulti GetVOldMultis(EMulti ObjEMulti)
        {
            try
            {
                ObjDMulti.GetVOldMultis(ObjEMulti);
            }
            catch (Exception ex) { }
            return ObjEMulti;
        }
    }
}
