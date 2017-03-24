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
    public class BReportDesign
    {
        DReportDesign ObjDReportDesign = new DReportDesign();

        public void GetReportDesignTypes(EReportDesign ObjEReportDesign,string _TYPE)
        {
            try
            {
                if (ObjEReportDesign != null)
                {
                    ObjEReportDesign.dsReportDesign = ObjDReportDesign.GetReportDesignTypes(_TYPE);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveReportDesign(EReportDesign ObjEObject,string _type)
        {
            try
            {
                if (ObjEObject != null)
                {
                    ObjDReportDesign.SaveReportDesignTypes(ObjEObject, _type);                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet  GetExistingReportDesignData(EReportDesign ObjEObject, string _type)
        {
            DataSet dsReportDesign = new DataSet();
            try
            {
                if (ObjEObject != null)
                {
                   dsReportDesign= ObjDReportDesign.GetExistingReportDesignData(ObjEObject, _type);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsReportDesign;
        }
    }
}
