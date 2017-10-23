using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BFormBlatt
    {
        DFormBlatt ObjDFormBlatt = new DFormBlatt();

        public EFormBlatt Get_tbl221_1(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                ObjEFormBlatt = ObjDFormBlatt.Get_tbl221_1(ObjEFormBlatt);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEFormBlatt;
        }
    }
}
