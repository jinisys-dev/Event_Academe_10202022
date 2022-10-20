using System;
using MySql.Data;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class EventFoodRequirementsDAO
    {
        public EventFoodRequirementsDAO()
        { }

        #region "Food Requirements"

        public void saveFoodRequirements(EventFoodRequirements foodReq)
        {
            string folioID = foodReq.GetType().GetProperty("FolioID").GetValue(foodReq, null).ToString();
            DateTime eventDate = DateTime.Parse(foodReq.GetType().GetProperty("EventDate").GetValue(foodReq, null).ToString());
            string venue = foodReq.GetType().GetProperty("Venue").GetValue(foodReq, null).ToString();
            int pax = int.Parse(foodReq.GetType().GetProperty("Pax").GetValue(foodReq, null).ToString());
            string startTime = foodReq.GetType().GetProperty("StartTime").GetValue(foodReq, null).ToString();
            string endTime = foodReq.GetType().GetProperty("EndTime").GetValue(foodReq, null).ToString();
            string over = foodReq.GetType().GetProperty("Over").GetValue(foodReq, null).ToString();
            string setup = foodReq.GetType().GetProperty("Setup").GetValue(foodReq, null).ToString();
            string remarks = foodReq.GetType().GetProperty("Remarks").GetValue(foodReq, null).ToString();
            decimal totalCost = decimal.Parse(foodReq.GetType().GetProperty("TotalMealCost").GetValue(foodReq, null).ToString());
            int mealID = int.Parse(foodReq.GetType().GetProperty("MealID").GetValue(foodReq, null).ToString());
            string mealType = foodReq.GetType().GetProperty("MealType").GetValue(foodReq, null).ToString();
            int liveInPax = int.Parse(foodReq.GetType().GetProperty("PaxLiveIn").GetValue(foodReq, null).ToString());
            int liveOutPax = int.Parse(foodReq.GetType().GetProperty("PaxLiveOut").GetValue(foodReq, null).ToString());

            string sql = "call spInsertFoodRequirements('" + folioID + "','" + string.Format("{0:yyyy-MM-dd}", eventDate) +
                "','" + venue + "'," + pax + ",'" + startTime + "','" + endTime + "','" + over + "','" + setup + "','" +
                remarks + "'," + totalCost + ",'" + GlobalVariables.gLoggedOnUser + "'," + mealID + ",'" + mealType + "'," +
                liveInPax + "," + liveOutPax + ")";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateFoodRequirements(EventFoodRequirements foodReq)
        {
            string folioID = foodReq.GetType().GetProperty("FolioID").GetValue(foodReq, null).ToString();
            DateTime eventDate = DateTime.Parse(foodReq.GetType().GetProperty("EventDate").GetValue(foodReq, null).ToString());
            string venue = foodReq.GetType().GetProperty("Venue").GetValue(foodReq, null).ToString();
            int pax = int.Parse(foodReq.GetType().GetProperty("Pax").GetValue(foodReq, null).ToString());
            string startTime = foodReq.GetType().GetProperty("StartTime").GetValue(foodReq, null).ToString();
            string endTime = foodReq.GetType().GetProperty("EndTime").GetValue(foodReq, null).ToString();
            string over = foodReq.GetType().GetProperty("Over").GetValue(foodReq, null).ToString();
            string setup = foodReq.GetType().GetProperty("Setup").GetValue(foodReq, null).ToString();
            string remarks = foodReq.GetType().GetProperty("Remarks").GetValue(foodReq, null).ToString();
            decimal totalCost = decimal.Parse(foodReq.GetType().GetProperty("TotalMealCost").GetValue(foodReq, null).ToString());
            int mealID = int.Parse(foodReq.GetType().GetProperty("MealID").GetValue(foodReq, null).ToString());
            string mealType = foodReq.GetType().GetProperty("MealType").GetValue(foodReq, null).ToString();
            int liveInPax = int.Parse(foodReq.GetType().GetProperty("PaxLiveIn").GetValue(foodReq, null).ToString());
            int liveOutPax = int.Parse(foodReq.GetType().GetProperty("PaxLiveOut").GetValue(foodReq, null).ToString());

            string sql = "call spUpdateFoodRequirements('" + folioID + "','" + string.Format("{0:yyyy-MM-dd}", eventDate) +
                "','" + venue + "'," + pax + ",'" + startTime + "','" + endTime + "','" + over + "','" + setup + "','" +
                remarks + "'," + totalCost + ",'" + GlobalVariables.gLoggedOnUser + "'," + mealID + ",'" + mealType + "'," +
                liveInPax + "," + liveOutPax + ")";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFoodDates(string folioID)
        {
            string sql = "Call spGetFoodDates('" + folioID + "')";
            try
            {
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                DataTable _dataTable = new DataTable("FoodDates");
                _dataAdapter.Fill(_dataTable);

                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMealTypes(string folioID, DateTime eventDate)
        {
            string sql = "call spGetDateMealTypes('" + folioID + "','" + string.Format("{0:yyyy-MM-dd}", eventDate) + "')";
            try
            {
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                DataTable _dataTable = new DataTable("MealTypes");
                _dataAdapter.Fill(_dataTable);

                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFoodRequirements(string folioID)
        {
            string sql = "call spDisplayFoodRequirements('" + folioID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("FoodRequirements");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMealHeader(string folioID, DateTime eventDate)
        {
            string sql = "call spGetMealHeader('" + folioID + "','" + string.Format("{0:yyyy-MM-dd}", eventDate) + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("MealHeader");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFoodRequirement(DateTime eventDate, string folioID)
        {
            string sql = "call spDisplayFoodRequirement('" + string.Format("{0:yyyy-MM-dd}", eventDate) + "','" + folioID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("FoodRequirements");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool eventDateExist(DateTime eventDate, string folioID)
        {
            string sql = "call spGetDatesForEvents('" + folioID + "','" + string.Format("{0:yyyy-MM-dd}", eventDate) + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Events");
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteMainMealHeader(string folioid, string eventDate)
        {
            DateTime date = DateTime.Parse(eventDate);
            string sql = "call spDeleteMainMealHeader('" + folioid + "','" + string.Format("{0:yyyy-MM-dd}", date) + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Event Meal Requirements Header"

        public bool mealHeaderExists(string mealType, DateTime eventDate, string FolioID)
        {
            string sql = "call spCheckMealHeaderExists('" + mealType + "','" + string.Format("{0:yyyy-MM-dd}", eventDate) + "','" + FolioID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Meals");
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteMealHeader(string mealID)
        {
            string sql = "delete from event_meal_requirements where mealID='" + mealID+ "'";
            try
            {
                deleteMealDetails(mealID);
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Event Meal Requirements Details"

        public void saveMealDetails(EventFoodRequirements mealDetails)
        {
            int mealID = int.Parse(mealDetails.GetType().GetProperty("MealID").GetValue(mealDetails, null).ToString());
            string menuCode = mealDetails.GetType().GetProperty("MenuCode").GetValue(mealDetails, null).ToString();
            string menuItemCode = mealDetails.GetType().GetProperty("MenuItemCode").GetValue(mealDetails, null).ToString();
            string description = mealDetails.GetType().GetProperty("Description").GetValue(mealDetails, null).ToString();
            string remarks = mealDetails.GetType().GetProperty("Remarks").GetValue(mealDetails, null).ToString();
            decimal price = decimal.Parse(mealDetails.GetType().GetProperty("Price").GetValue(mealDetails, null).ToString());

            string sql = "call spInsertMealDetails(" + mealID + ",'" + menuCode + "','" + menuItemCode + "','" + description + 
                "','" + remarks + "','" + GlobalVariables.gLoggedOnUser + "'," + price + ")";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteMealDetails(string pMealID)
        {
            string sql = "delete from event_meal_details where mealID='" + pMealID + "'";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMealDetails(string mealID, DateTime mealDate, string folioID)
        {
            string sql = "call spGetMealDetails('" + mealID + "','" + string.Format("{0:yyyy-MM-dd}", mealDate) + "','" + folioID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("MealDetails");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
