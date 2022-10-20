using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class AppliedRatesFacade
    {
        public AppliedRatesFacade()
        { }

        private AppliedRatesDAO ratesDAO;
        public void saveAppliedRates(EventAppliedRates appliedRates)
        {
            ratesDAO = new AppliedRatesDAO();
            ratesDAO.saveAppliedRates(appliedRates);
        }

        public void deleteAppliedRates(string eventID)
        {
            ratesDAO = new AppliedRatesDAO();
            ratesDAO.deleteAppliedRates(eventID);
        }

        public GenericList<EventAppliedRates> getAppliedRatesForEvents(string eventID)
        {
            GenericList<EventAppliedRates> eventAppliedRates = new GenericList<EventAppliedRates>();
            ratesDAO = new AppliedRatesDAO();
            DataTable dt = ratesDAO.getAppliedRatesForEvents(eventID);
            foreach (DataRow dr in dt.Rows)
            {
                EventAppliedRates appliedRates = new EventAppliedRates();
                appliedRates.Description = dr["description"].ToString();
                appliedRates.FolioID = dr["folioID"].ToString();
                appliedRates.RateAmount = double.Parse(dr["rateAmount"].ToString());
                appliedRates.RateType = dr["rateType"].ToString();

                eventAppliedRates.Add(appliedRates);
            }
            return eventAppliedRates;
        }
    }
}
