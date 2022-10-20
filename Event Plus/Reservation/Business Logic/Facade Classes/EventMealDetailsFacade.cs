using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventMealDetailsFacade
    {
        public EventMealDetailsFacade()
        { }

        private EventMealDetailsDAO mealDAO;
        public void insertMealDetails(EventMealDetails mealDetails)
        {
            mealDAO = new EventMealDetailsDAO();
            mealDAO.insertMealDetails(mealDetails);
        }

        public GenericList<EventMealDetails> getMealDetails(string mealID)
        {
            GenericList<EventMealDetails> eventMealDetails = new GenericList<EventMealDetails>();
            mealDAO = new EventMealDetailsDAO();
            DataTable dt = mealDAO.getMealDetails(mealID);
            foreach (DataRow dr in dt.Rows)
            {
                EventMealDetails mealDetails = new EventMealDetails();
                mealDetails.MealID = int.Parse(dr["mealID"].ToString());
                mealDetails.MenuCode = dr["menuCode"].ToString();
                mealDetails.MenuItemCode = dr["menuItemCode"].ToString();
                mealDetails.Remarks = dr["remarks"].ToString();

                eventMealDetails.Add(mealDetails);
            }
            return eventMealDetails;
        }
    }
}
