using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Utilities.DataAccessLayer;
namespace Jinisys.Hotel.Utilities.BusinessLayer
{
    public class ReferenceTimeFACADE
    {
        public ReferenceTime GetReferenceTime()
        {
           ReferenceTimeDAO refDAO = new ReferenceTimeDAO();
            return refDAO.GetReferenceTime();
        }
        public bool UpdateRefTime(ReferenceTime refTime)
        {
            ReferenceTimeDAO refDAO = new ReferenceTimeDAO();
            return refDAO.UpdateRefTime(refTime);
        }
    }
}
