using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class MealMenuItemDAO
    {
        public MealMenuItemDAO()
        { }

        #region "Meal Items"

        public void saveMealItem(MealMenu mealItem)
        {
            try
            {
                string mealItemID = mealItem.GetType().GetProperty("MealMenuItemID").GetValue(mealItem, null).ToString();
                string description = mealItem.GetType().GetProperty("Description").GetValue(mealItem, null).ToString();
                int groupID = int.Parse(mealItem.GetType().GetProperty("GroupID").GetValue(mealItem, null).ToString());
                string unit = mealItem.GetType().GetProperty("Unit").GetValue(mealItem, null).ToString();
                double unitCost = double.Parse(mealItem.GetType().GetProperty("UnitCost").GetValue(mealItem, null).ToString());
                double sellingPrice = double.Parse(mealItem.GetType().GetProperty("SellingPrice").GetValue(mealItem, null).ToString());
                double vat = double.Parse(mealItem.GetType().GetProperty("Vat").GetValue(mealItem, null).ToString());
                double serviceCharge = double.Parse(mealItem.GetType().GetProperty("ServiceCharge").GetValue(mealItem, null).ToString());

                string sql = "call spInsertMealItems('" + mealItemID + "','" + description + "'," + groupID + ",'" + unit + "'," + unitCost + "," + sellingPrice +
                    "," + vat + "," + serviceCharge + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateMealItem(MealMenu mealItem)
        {
            int rowsAffected = 0;
            try
            {
                string mealItemID = mealItem.GetType().GetProperty("MealMenuItemID").GetValue(mealItem, null).ToString();
                string description = mealItem.GetType().GetProperty("Description").GetValue(mealItem, null).ToString();
                int groupID = int.Parse(mealItem.GetType().GetProperty("GroupID").GetValue(mealItem, null).ToString());
                string unit = mealItem.GetType().GetProperty("Unit").GetValue(mealItem, null).ToString();
                double unitCost = double.Parse(mealItem.GetType().GetProperty("UnitCost").GetValue(mealItem, null).ToString());
                double sellingPrice = double.Parse(mealItem.GetType().GetProperty("SellingPrice").GetValue(mealItem, null).ToString());
                double vat = double.Parse(mealItem.GetType().GetProperty("Vat").GetValue(mealItem, null).ToString());
                double serviceCharge = double.Parse(mealItem.GetType().GetProperty("ServiceCharge").GetValue(mealItem, null).ToString());

                string sql = "call spUpdateMealItems('" + mealItemID + "','" + description + "'," + groupID + ",'" + unit + "'," + unitCost + "," + sellingPrice + "," + vat + "," + serviceCharge + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMealMenuItem()
        {
            string sql = "call spGetMealMenuItem()";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("MealMenuItem");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteMealItem(string itemID)
        {
            try
            {
                string sql = "call spDeleteMealItem('" + itemID + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Meal Groups"

        public string saveMealGroup(MealMenu mealGroup)
        {
            string groupID = "";
            string description = mealGroup.GetType().GetProperty("Description").GetValue(mealGroup, null).ToString();
			string mainGroupId = mealGroup.GetType().GetProperty("MainGroupId").GetValue(mealGroup, null).ToString();

            try
            {
				string sql = "call spInsertMealGroup('" + description + "','" + mainGroupId + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                groupID = cmd.ExecuteNonQuery().ToString();

                return groupID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateMealGroup(MealMenu mealGroup)
        {
            int rowsAffected = 0;
            int groupID = int.Parse(mealGroup.GetType().GetProperty("GroupID").GetValue(mealGroup, null).ToString());
            string description = mealGroup.GetType().GetProperty("Description").GetValue(mealGroup, null).ToString();
			string mainGroupId = mealGroup.GetType().GetProperty("MainGroupId").GetValue(mealGroup, null).ToString();

            try  
            {
                string sql = "Call spUpdateGroup(" + groupID + ",'" + description + "','" + mainGroupId + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMealGroups()
        {
            string sql = "select * from meal_group where `status`='active' order by description";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter daGroups = new MySqlDataAdapter(cmd);
                DataTable dtGroup = new DataTable("MealGroups");

                daGroups.Fill(dtGroup);
                return dtGroup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getDetailsForMealGroup(string groupID)
        {
            string sql = "call spGetDetailsForMealGroup('" + groupID + "')";
            try
            {
                MySqlCommand cmdGroup = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter daGroup = new MySqlDataAdapter(cmdGroup);
                DataTable dtGroup = new DataTable("MealGroups");

                daGroup.Fill(dtGroup);
                return dtGroup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteMealGroup(string groupID)
        {
            int rowsAffected = 0;
            try
            {
                string sql = "call spDeleteMealGroup('" + groupID + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Meal Menu"

        public DataTable getMealMenu()
        {
            string sql = "call spGetMealMenu()";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
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

        public DataTable getMealItemsForMenu(string menuId)
        {
            string sql = "call spgetMealItemsForMenu('" + menuId + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("MealMenuItem");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string saveMealMenu(MealMenu mealMenu)
        {
            string menuID = "";
            try
            {
                string description = mealMenu.GetType().GetProperty("Description").GetValue(mealMenu, null).ToString();
                double price = double.Parse(mealMenu.GetType().GetProperty("Price").GetValue(mealMenu, null).ToString());
                double vat = double.Parse(mealMenu.GetType().GetProperty("Vat").GetValue(mealMenu, null).ToString());
                double serviceCharge = double.Parse(mealMenu.GetType().GetProperty("ServiceCharge").GetValue(mealMenu, null).ToString());

                string sql = "call spInsertMealMenu('" + description + "'," + price + "," + vat + "," + serviceCharge + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                MySqlCommand cmdMealMenu = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                menuID = cmdMealMenu.ExecuteScalar().ToString();

                return menuID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateMealMenu(MealMenu mealMenu)
        {
            int rowsAffected = 0;
            try
            {
                int menuID = int.Parse(mealMenu.GetType().GetProperty("MenuID").GetValue(mealMenu, null).ToString());
                string description = mealMenu.GetType().GetProperty("Description").GetValue(mealMenu, null).ToString();
                double price = double.Parse(mealMenu.GetType().GetProperty("Price").GetValue(mealMenu, null).ToString());
                double vat = double.Parse(mealMenu.GetType().GetProperty("Vat").GetValue(mealMenu, null).ToString());
                double serviceCharge = double.Parse(mealMenu.GetType().GetProperty("ServiceCharge").GetValue(mealMenu, null).ToString());

                string sql = "call spUpdateMealMenu(" + menuID + ",'" + description + "'," + price + "," + vat + "," + serviceCharge + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                MySqlCommand cmdMealMenu = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                rowsAffected = cmdMealMenu.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteMealMenu(string menuID)
        {
            int rowsAffected = 0;
            try
            {
                string sql = "call spDeleteMealMenu('" + menuID + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                MySqlCommand cmdMealMenu = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                rowsAffected = cmdMealMenu.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Meal Menu Detail"

        public void saveMealMenuDetail(MealMenu mealMenu)
        {
            int menuID = int.Parse(mealMenu.GetType().GetProperty("MenuID").GetValue(mealMenu, null).ToString());
            string itemID = mealMenu.GetType().GetProperty("MealMenuItemID").GetValue(mealMenu, null).ToString();

            string sql = "call spInsertMealMenuDetail('" + menuID + "','" + itemID + "')";
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

        public void deleteMealMenuDetail(string menuID)
        {
            string sql = "delete from meal_menu_detail where menuID='" + menuID + "'";
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
    }
}
