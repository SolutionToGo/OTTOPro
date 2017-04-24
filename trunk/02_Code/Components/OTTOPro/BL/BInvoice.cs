using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EL;

namespace BL
{
    public class BInvoice
    {
        DInvoice ObjDInvoice = new DInvoice();

        public EInvoice GetDeliveryNotes(EInvoice ObjEInvoice)
        {
            try
            {
                ObjEInvoice = ObjDInvoice.GetDeliveryNotes(ObjEInvoice);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEInvoice;
        }

        public EInvoice SaveInvoice(EInvoice ObjEInvoice)
        {
            try
            {
                ObjEInvoice = ObjDInvoice.SaveInvoice(ObjEInvoice);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEInvoice;
        }
    }
}
