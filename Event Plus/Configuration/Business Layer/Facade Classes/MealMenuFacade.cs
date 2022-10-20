using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.Configuration.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Configuration.BusinessLayer
{
    public class MealMenuFacade
    {
        public MealMenuFacade()
        { }

        private MealMenuDAO mealDAO;
        public void saveMealMenu(MealMenu meal)
        {
            mealDAO = new MealMenuDAO();
            mealDAO.saveMealMenu(meal);
        }

        public void updateMealMenu(MealMenu meal)
        {
            mealDAO = new MealMenuDAO();
            mealDAO.updateMealMenu(meal);
        }

        public GenericList<MealMenu> getMealMenus()
        {
            GenericList<MealMenu> mealMenu = new GenericList<MealMenu>();
            mealDAO = new MealMenuDAO();
            DataTable dt = mealDAO.getMealMenu();
            foreach (DataRow dr in dt.Rows)
            {
                MealMenu meal = new MealMenu();
                meal.Description = dr["description"].ToString();
                meal.MenuID = dr["menuID"].ToString();

                mealMenu.Add(meal);
            }
            return mealMenu;
        }
    }
}
