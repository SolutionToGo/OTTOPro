using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OTTOProAddin
{
    public class BProposal
    {
        DProposal ObjDProposal = new DProposal();

        public void GetTextModuleAreas(EProposal ObjEProposal)
        {
            try
            {
                if (ObjEProposal != null)
                {
                    ObjEProposal.dsTextModuleAreas = ObjDProposal.GetTextModuleAreas();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetCategories(EProposal ObjEProposal, int _textID)
        {
            try
            {
                if (ObjEProposal != null)
                {
                    ObjEProposal.dsCategory = ObjDProposal.GetCategories(_textID);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
