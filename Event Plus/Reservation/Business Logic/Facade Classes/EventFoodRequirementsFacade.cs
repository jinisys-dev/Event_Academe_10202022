using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventFoodRequirementsFacade
    {
        public EventFoodRequirementsFacade()
        { }

        private EventFoodRequirementsDAO oFoodReqDAO;

        #region "Food Requirements"
        public void saveFoodRequirements(EventFoodRequirements oFoodReq)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            oFoodReqDAO.saveFoodRequirements(oFoodReq);
        }

        public void updateFoodRequirements(EventFoodRequirements oFoodReq)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            oFoodReqDAO.updateFoodRequirements(oFoodReq);
        }

        public void deleteMealDetails(string mealID)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            oFoodReqDAO.deleteMealDetails(mealID);
        }

        public void deleteMainMealHeader(string folioID, string eventDate)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            oFoodReqDAO.deleteMainMealHeader(folioID, eventDate);
        }

        public GenericList<EventFoodRequirements> getFoodRequirements(string folioID)
        {
            GenericList<EventFoodRequirements> oFoodReq = new GenericList<EventFoodRequirements>();
            oFoodReqDAO = new EventFoodRequirementsDAO();
            DataTable dt = oFoodReqDAO.getFoodRequirements(folioID);
            foreach (DataRow dr in dt.Rows)
            {
                EventFoodRequirements foodReq = new EventFoodRequirements();
                foodReq.FolioID = dr["folioID"].ToString();
                foodReq.EventDate = DateTime.Parse(dr["eventDate"].ToString());
                foodReq.Venue = dr["venue"].ToString();
                foodReq.Pax = int.Parse(dr["pax"].ToString());
                foodReq.StartTime = dr["startTime"].ToString();
                foodReq.EndTime = dr["endTime"].ToString();
                foodReq.Over = dr["over"].ToString();
                foodReq.Remarks = dr["remarks"].ToString();
                foodReq.Setup = dr["setup"].ToString();
                //Kevin L. Oliveros
                foodReq.MealID = int.Parse(dr["mealID"].ToString());
                foodReq.MealType = dr["mealType"].ToString();
                foodReq.PaxLiveOut = int.Parse(dr["liveOutPax"].ToString());
                

                foodReq.TotalMealCost = decimal.Parse(dr["totalMealCost"].ToString());

                oFoodReq.Add(foodReq);
            }
            return oFoodReq;
        }

        public GenericList<EventFoodRequirements> getFoodRequirement(DateTime eventDate, string folioID)
        {
            GenericList<EventFoodRequirements> oFoodReq = new GenericList<EventFoodRequirements>();
            oFoodReqDAO = new EventFoodRequirementsDAO();
            DataTable dt = oFoodReqDAO.getFoodRequirement(eventDate, folioID);
            foreach (DataRow dr in dt.Rows)
            {
                EventFoodRequirements foodReq = new EventFoodRequirements();
                foodReq.FolioID = dr["folioID"].ToString();
                foodReq.EventDate = DateTime.Parse(dr["eventDate"].ToString());
                foodReq.Venue = dr["venue"].ToString();
                foodReq.Pax = int.Parse(dr["pax"].ToString());
                foodReq.StartTime = dr["startTime"].ToString();
                foodReq.EndTime = dr["endTime"].ToString();
                foodReq.Over = dr["over"].ToString();
                foodReq.Remarks = dr["remarks"].ToString();
                foodReq.Setup = dr["setup"].ToString();
                foodReq.TotalMealCost = decimal.Parse(dr["totalMealCost"].ToString());
                foodReq.MealID = int.Parse(dr["mealID"].ToString());
                foodReq.MealType = dr["mealType"].ToString();
                foodReq.PaxLiveIn = int.Parse(dr["liveInPax"].ToString());
                foodReq.PaxLiveOut = int.Parse(dr["liveOutPax"].ToString());

                oFoodReq.Add(foodReq);
            }
            return oFoodReq;
        }

        public bool eventDateExists(DateTime eventDate, string folioID)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            return oFoodReqDAO.eventDateExist(eventDate, folioID);
        }

        public GenericList<EventFoodRequirements> getFoodDates(string folioID)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            GenericList<EventFoodRequirements> _oEventFoodRequirementList = new GenericList<EventFoodRequirements>();
            DataTable _dataTable = new DataTable();
            _dataTable = oFoodReqDAO.getFoodDates(folioID);

            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventFoodRequirements _oEventFoodRequirement = new EventFoodRequirements();
                _oEventFoodRequirement.EventDate = DateTime.Parse(_dataRow["eventDate"].ToString());

                _oEventFoodRequirementList.Add(_oEventFoodRequirement);
            }

            return _oEventFoodRequirementList;
        }

        public GenericList<EventFoodRequirements> getMealTypes(string folioID, DateTime eventDate)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            GenericList<EventFoodRequirements> _oEventFoodRequirementList = new GenericList<EventFoodRequirements>();
            DataTable _dataTable = new DataTable();
            _dataTable = oFoodReqDAO.getMealTypes(folioID, eventDate);

            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventFoodRequirements _oEventFoodRequirement = new EventFoodRequirements();
                _oEventFoodRequirement.MealType = _dataRow["mealType"].ToString();

                _oEventFoodRequirementList.Add(_oEventFoodRequirement);
            }

            return _oEventFoodRequirementList;
        }

        #endregion

        #region "Event Meal Header"

        public bool mealHeaderExists(string mealType, DateTime eventDate, string folioID)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            return oFoodReqDAO.mealHeaderExists(mealType, eventDate, folioID);
        }

        public void deleteMealHeader(string mealID)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            oFoodReqDAO.deleteMealHeader(mealID);
        }

        #endregion

        #region "Event Meal Details"

        public void saveMealDetails(EventFoodRequirements mealDetails)
        {
            oFoodReqDAO = new EventFoodRequirementsDAO();
            oFoodReqDAO.saveMealDetails(mealDetails);
        }

        public GenericList<EventFoodRequirements> getMealDetails(string mealID, DateTime mealDate, string folioID)
        {
            GenericList<EventFoodRequirements> mealDetails = new GenericList<EventFoodRequirements>();
            oFoodReqDAO = new EventFoodRequirementsDAO();
            DataTable dt = oFoodReqDAO.getMealDetails(mealID, mealDate, folioID);
            foreach (DataRow dr in dt.Rows)
            {
                EventFoodRequirements eventMeal = new EventFoodRequirements();
                eventMeal.MenuCode = dr["menuCode"].ToString();
                eventMeal.MenuItemCode = dr["menuItemCode"].ToString();
                eventMeal.Description = dr["description"].ToString();
                eventMeal.Remarks = dr["remarks"].ToString();
                eventMeal.Price = decimal.Parse(dr["price"].ToString());

                mealDetails.Add(eventMeal);
            }
            return mealDetails;
        }

        #endregion
    }
}
