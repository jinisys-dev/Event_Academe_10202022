using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.Configuration.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.Configuration.DataAccessLayer
{
    public class MealMenuDAO
    {
        public MealMenuDAO()
        { }

        public void saveMealMenu(MealMenu menu)
        {
            string desc = menu.GetType().GetProperty("MenuID").GetValue(menu, null).ToString();
            string status = menu.GetType().GetProperty("Description").GetValue(menu, null).ToString();
            string sql = "call spInsertMealMenu('" + desc + "','" + status + ")";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.PersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        public void updateMealMenu(MealMenu menu)
        {
            string desc = menu.GetType().GetProperty("Description").GetValue(menu, null).ToString();
            string status = menu.GetType().GetProperty("Status").GetValue(menu, null).ToString();
            string sql = "call spUpdateMealMenu('" + desc + "','" + status + ")";
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

        public DataTable getMealMenu()
        {
            string sql = "call spGetMealMenu()";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.PersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("MealMenu");
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
