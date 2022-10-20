
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    class MinibarItemCategoryFacade
    {

		MinibarItemCategoryDAO catDAO;
        public MinibarItemCategory getCategories()
        {
			catDAO = new MinibarItemCategoryDAO();
            return catDAO.getCategories();
        }
        public bool Save(ref MinibarItemCategory cat)
        {
			catDAO = new MinibarItemCategoryDAO();
            return catDAO.Save(ref cat);
        }
        public bool Update(ref MinibarItemCategory cat)
        {
			catDAO = new MinibarItemCategoryDAO();
            return catDAO.Update(ref cat);
        }
        public bool Delete(ref MinibarItemCategory cat)
        {
			catDAO = new MinibarItemCategoryDAO();
            return catDAO.Delete(ref cat);
        }
    }
}
