using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventFoodReqFacade
    {
        private EventFoodReqDAO eventDAO;
        public EventFoodReqFacade()
        { }

        public void insertFoodRequirements(EventFoodRequirements foodReq)
        {
            eventDAO = new EventFoodReqDAO();
            eventDAO.insertFoodRequirements(foodReq);
        }

        public void updateFoodRequirements(EventFoodRequirements foodReq)
        {
            eventDAO = new EventFoodReqDAO();
            eventDAO.updateFoodRequirements(foodReq);
        }

        public void deleteFoodRequirements(string foodReqID)
        {
            eventDAO = new EventFoodReqDAO();
            eventDAO.deleteFoodRequirements(foodReqID);
        }

        public GenericList<EventFoodRequirements> getFoodRequirements(string eventID)
        {
            GenericList<EventFoodRequirements> foodRequirements = new GenericList<EventFoodRequirements>();
            eventDAO = new EventFoodReqDAO();
            DataTable dt = eventDAO.getFoodRequirements(eventID);
            foreach (DataRow dr in dt.Rows)
            {
                EventFoodRequirements foodReq = new EventFoodRequirements();
                foodReq.EndTime = dr["endTime"].ToString();
                foodReq.EventDate = DateTime.Parse(dr["eventDate"].ToString());
                foodReq.EventID = int.Parse(dr["eventID"].ToString());
                foodReq.FoodRequirementID = int.Parse(dr["foodRequirementID"].ToString());
                foodReq.Over = dr["over"].ToString();
                foodReq.Pax = int.Parse(dr["pax"].ToString());
                foodReq.Remarks = dr["remarks"].ToString();
                foodReq.StartTime = dr["startTime"].ToString();
                foodReq.Venue = dr["venue"].ToString();

                foodRequirements.Add(foodReq);
            }
            return foodRequirements;
        }
    }
}
