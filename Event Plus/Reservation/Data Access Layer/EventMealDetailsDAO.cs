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
    public class EventMealDetailsDAO
    {
        public EventMealDetailsDAO()
        { }

        public void insertMealDetails(EventMealDetails mealDetails)
        {
            int mealID = int.Parse(mealDetails.GetType().GetProperty("MealID").GetValue(mealDetails, null).ToString());
            string menuCode = mealDetails.GetType().GetProperty("MenuCode").GetValue(mealDetails, null).ToString();
            string menuItemCode = mealDetails.GetType().GetProperty("MenuItemCode").GetValue(mealDetails, null).ToString();
            string remarks = mealDetails.GetType().GetProperty("Remarks").GetValue(mealDetails, null).ToString();

            string sql = "call spInsertMealDetails(" + mealID + ",'" + menuCode + "','" + menuItemCode + "','" + remarks + "')";
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

        public DataTable getMealDetails(string mealID)
        {
            string sql = "call spSelectAllMealDetails('" + mealID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.PersistentConnection);
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
    }
}
