using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BUmlage
    {
        DUmlage ObjDUmlage = new DUmlage();

        public EUmlage UpdateSpecialCost(EUmlage ObjEUmlage)
        {
            try
            {
                ObjEUmlage = ObjDUmlage.UpdateSpecialCost(ObjEUmlage);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUmlage;
        }

        public EUmlage GetSpecialCost(EUmlage ObjEUmlage)
        {
            try
            {
                ObjEUmlage = ObjDUmlage.GetSpecialCost(ObjEUmlage);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUmlage;
        }

        public EUmlage ShowUmlage(EUmlage ObjEUmlage)
        {
            try
            {
                ObjEUmlage = ObjDUmlage.ShowUmlage(ObjEUmlage);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUmlage;
        }

        public EUmlage SaveSpecialCost(EUmlage ObjEUmlage)
        {
            try
            {
                ObjEUmlage = ObjDUmlage.SaveSpecialCost(ObjEUmlage);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUmlage;
        }
    }
}
