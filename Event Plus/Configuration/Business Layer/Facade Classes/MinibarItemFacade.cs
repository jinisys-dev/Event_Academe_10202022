
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class MinibarItemFacade
    {
		MinibarItemDAO loItemDAO;
        public MinibarItem getItems()
        {
			loItemDAO = new MinibarItemDAO();
			return loItemDAO.getItems();
        }

        public MinibarItem getItem(string pItemId)
        {
            loItemDAO = new MinibarItemDAO();
            DataRow row = loItemDAO.getItem(pItemId);

            MinibarItem oItem = new MinibarItem("Temp");
            oItem.ItemCode = row["itemCode"].ToString();
            oItem.Description = row["description"].ToString();
            oItem.UnitPrice = decimal.Parse(row["unitPrice"].ToString());
            oItem.CategoryId = int.Parse(row["categoryId"].ToString());

            return oItem;

        }

        public decimal getItemPrice(String item_code)
        {
			loItemDAO = new MinibarItemDAO();
			return loItemDAO.getItemPrice(item_code);
        }
        public bool Save(ref MinibarItem item)
        {
			loItemDAO = new MinibarItemDAO();
            return loItemDAO.Save(ref item);
        }
        public bool Delete(ref MinibarItem item)
        {
			loItemDAO = new MinibarItemDAO();
            return loItemDAO.Delete(ref item);
        }

        public bool Update(ref MinibarItem item)
        {
            loItemDAO = new MinibarItemDAO();
            return loItemDAO.Update(ref item);
        }
    }
}
