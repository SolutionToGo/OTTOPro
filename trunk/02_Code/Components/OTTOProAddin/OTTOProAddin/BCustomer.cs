using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTOProAddin
{
    public class BCustomer
    {
        DCustomer ObjDCustomer = new DCustomer();


        public void GetCustomers(ECustomer ObjECustomer)
        {
            try
            {
                if (ObjECustomer != null)
                {
                    ObjECustomer.dsCustomer = ObjDCustomer.GetCustomers();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
               
    }
}
