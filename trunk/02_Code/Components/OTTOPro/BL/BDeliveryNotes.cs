using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BDeliveryNotes
    {
        DDeliveryNotes ObjDdeliveryNotes = new DDeliveryNotes();

        public EDeliveryNotes GetPositions(EDeliveryNotes ObjEDeliveryNotes)
        {
            try
            {
                ObjEDeliveryNotes = ObjDdeliveryNotes.GetPositions(ObjEDeliveryNotes);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes SaveDelivery(EDeliveryNotes ObjEDeliveryNotes)
        {
            try
            {
                ObjEDeliveryNotes = ObjDdeliveryNotes.SaveDelivery(ObjEDeliveryNotes);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes GetNonActiveDelivery(EDeliveryNotes ObjEDeliveryNotes)
        {
            try
            {
                ObjEDeliveryNotes = ObjDdeliveryNotes.GetNonActiveDelivery(ObjEDeliveryNotes);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes GetBlattNumbers(EDeliveryNotes ObjEDeliveryNotes)
        {
            try
            {
                ObjEDeliveryNotes = ObjDdeliveryNotes.GetBlattNumbers(ObjEDeliveryNotes);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes GetNewBlattNumber(EDeliveryNotes ObjEDeliveryNotes)
        {
            try
            {
                ObjEDeliveryNotes = ObjDdeliveryNotes.GetNewBlattNumber(ObjEDeliveryNotes);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes GetBlattDetails(EDeliveryNotes ObjEDeliveryNotes)
        {
            try
            {
                ObjEDeliveryNotes = ObjDdeliveryNotes.GetBlattDetails(ObjEDeliveryNotes);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEDeliveryNotes;
        }
    }
}
