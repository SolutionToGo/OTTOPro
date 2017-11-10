using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
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

        public EFormBlatt Get_tbl221_2(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                ObjEFormBlatt = ObjDFormBlatt.Get_tbl221_2(ObjEFormBlatt);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt Get_FormBlattTypes(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                ObjEFormBlatt = ObjDFormBlatt.GetFormBlatttype(ObjEFormBlatt);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt Get_FormBlattArticles(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                ObjEFormBlatt = ObjDFormBlatt.Get_FormBlattArticles(ObjEFormBlatt);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt Save_FormBlattArticles(EFormBlatt ObjEFormBlatt,DataTable _dt)
        {
            try
            {
                ObjEFormBlatt = ObjDFormBlatt.Save_FormBlattArticles(ObjEFormBlatt,_dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEFormBlatt;
        }
    }
}
