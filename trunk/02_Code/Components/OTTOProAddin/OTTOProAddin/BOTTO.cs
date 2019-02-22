using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTOProAddin
{
    public class BOTTO
    {
        DOTTO ObjDOTTO = new DOTTO();


        public void GetOTTODetails(EOTTO ObjEOTTO)
        {
            try
            {
                if (ObjEOTTO != null)
                {
                    ObjEOTTO.dsOTTO = ObjDOTTO.GetOTTODetails();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
