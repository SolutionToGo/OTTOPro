using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTOProAddin
{
    public class BInvoice
    {
        DInvoice ObjDInvoice = new DInvoice();


        public void GetProjectDetails(EInvoice ObjEInvoice)
        {
            try
            {
                if (ObjEInvoice != null)
                {
                    ObjEInvoice.dsProject = ObjDInvoice.GetProjectDetails();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetInvoiceDetails(EInvoice ObjEInvoice)
        {
            try
            {
                if (ObjEInvoice != null)
                {
                    ObjEInvoice.dsInvoice = ObjDInvoice.GetInvoiceDetails(ObjEInvoice);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
