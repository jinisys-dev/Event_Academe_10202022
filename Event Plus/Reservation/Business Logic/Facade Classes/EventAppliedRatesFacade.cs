using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventAppliedRatesFacade
    {
        public EventAppliedRatesFacade()
        { }

        private EventAppliedRatesDAO ratesDAO;
        public void saveAppliedRates(EventAppliedRates appliedRates, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            ratesDAO = new EventAppliedRatesDAO();
            ratesDAO.saveAppliedRates(appliedRates, ref pTrans);
        }

        public void deleteAppliedRates(string eventID, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            ratesDAO = new EventAppliedRatesDAO();
            ratesDAO.deleteAppliedRates(eventID, ref pTrans);
        }

        public GenericList<EventAppliedRates> getAppliedRatesForEvents(string eventID)
        {
            GenericList<EventAppliedRates> eventAppliedRates = new GenericList<EventAppliedRates>();
            ratesDAO = new EventAppliedRatesDAO();
            DataTable dt = ratesDAO.getAppliedRatesForEvents(eventID);
            foreach (DataRow dr in dt.Rows)
            {
                EventAppliedRates appliedRates = new EventAppliedRates();
                appliedRates.Description = dr["description"].ToString();
                appliedRates.FolioID = dr["folioID"].ToString();
                appliedRates.RateAmount = decimal.Parse(dr["rateAmount"].ToString());
                appliedRates.RateType = dr["rateType"].ToString();
                appliedRates.NumberOfOccupants = int.Parse(dr["noOfOccupants"].ToString());

                eventAppliedRates.Add(appliedRates);
            }
            return eventAppliedRates;
        }
    }
}
