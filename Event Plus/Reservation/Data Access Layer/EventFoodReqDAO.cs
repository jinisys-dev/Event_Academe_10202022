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
    public class EventFoodReqDAO
    {
        public EventFoodReqDAO()
        { }

        public void insertFoodRequirements(EventFoodRequirements foodReq)
        {
            int eventID = int.Parse(foodReq.GetType().GetProperty("EventID").GetValue(foodReq, null).ToString());
            DateTime eventDate = DateTime.Parse(foodReq.GetType().GetProperty("EventDate").GetValue(foodReq, null).ToString());
            string venue = foodReq.GetType().GetProperty("Venue").GetValue(foodReq, null).ToString();
            int pax = int.Parse(foodReq.GetType().GetProperty("Pax").GetValue(foodReq, null).ToString());
            DateTime startTime = DateTime.Parse(foodReq.GetType().GetProperty("StartTime").GetValue(foodReq, null).ToString());
            DateTime endTime = DateTime.Parse(foodReq.GetType().GetProperty("EndTime").GetValue(foodReq, null).ToString());
            string over = foodReq.GetType().GetProperty("Over").GetValue(foodReq, null).ToString();
            string remarks = foodReq.GetType().GetProperty("Remarks").GetValue(foodReq, null).ToString();

            string sql = "call spInsertFoodRequirements(" + eventID + ",'" + string.Format("{0:dd-MM-yyyy}", eventDate) +
                "','" + venue + "'," + pax + ",'" + string.Format("{0:dd-MM-yyyy}", startTime) + "','" + string.Format("{0:dd-MM-yyyy}", endTime) +
                "','" + over + "','" + remarks + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.PersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateFoodRequirements(EventFoodRequirements foodReq)
        {
            int foodReqID = int.Parse(foodReq.GetType().GetProperty("FoodRequirementID").GetValue(foodReq, null).ToString());
            int eventID = int.Parse(foodReq.GetType().GetProperty("EventID").GetValue(foodReq, null).ToString());
            DateTime eventDate = DateTime.Parse(foodReq.GetType().GetProperty("EventDate").GetValue(foodReq, null).ToString());
            string venue = foodReq.GetType().GetProperty("Venue").GetValue(foodReq, null).ToString();
            int pax = int.Parse(foodReq.GetType().GetProperty("Pax").GetValue(foodReq, null).ToString());
            DateTime startTime = DateTime.Parse(foodReq.GetType().GetProperty("StartTime").GetValue(foodReq, null).ToString());
            DateTime endTime = DateTime.Parse(foodReq.GetType().GetProperty("EndTime").GetValue(foodReq, null).ToString());
            string over = foodReq.GetType().GetProperty("Over").GetValue(foodReq, null).ToString();
            string remarks = foodReq.GetType().GetProperty("Remarks").GetValue(foodReq, null).ToString();

            string sql = "call spUpdateFoodRequirements(" + foodReqID + "," + eventID + ",'" + string.Format("{0:dd-MM-yyyy}", eventDate) +
                "','" + venue + "'," + pax + ",'" + string.Format("{0:dd-MM-yyyy}", startTime) + "','" + string.Format("{0:dd-MM-yyyy}", endTime) +
                "','" + over + "','" + remarks + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.PersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteFoodRequirements(string foodReqID)
        {
            string sql = "call spDeleteFoodRequirements('" + foodReqID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.PersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFoodRequirements(string eventID)
        {
            string sql = "Call spGetAllFoodRequirements('" + eventID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.PersistentConnection);
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
    }
}
