using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class MealMenuItemFacade
    {
        public MealMenuItemFacade()
        { }

        #region Meal Items

        private MealMenuItemDAO lMealMenuItemDAO;
        public GenericList<MealMenu> getMealMenuItems()
        {
            GenericList<MealMenu> _mealItemList = new GenericList<MealMenu>();
            lMealMenuItemDAO = new MealMenuItemDAO();
            DataTable _dataTable = lMealMenuItemDAO.getMealMenuItem();
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                MealMenu _oMealItem = new MealMenu();
                _oMealItem.Description = _dataRow["description"].ToString();
                _oMealItem.GroupID = int.Parse(_dataRow["groupID"].ToString());
                _oMealItem.MealMenuItemID = _dataRow["itemID"].ToString();
                _oMealItem.Unit = _dataRow["unit"].ToString();
                _oMealItem.UnitCost = double.Parse(_dataRow["unit_cost"].ToString());
                _oMealItem.SellingPrice = double.Parse(_dataRow["selling_price"].ToString());
                _oMealItem.Vat = double.Parse(_dataRow["vat"].ToString());

                _mealItemList.Add(_oMealItem);
            }
            return _mealItemList;
        }

        public GenericList<MealMenu> getMealItemsForMenu(string _menuID)
        {
            GenericList<MealMenu> _mealMenuItemList = new GenericList<MealMenu>();
            lMealMenuItemDAO = new MealMenuItemDAO();
            DataTable _dataTable = lMealMenuItemDAO.getMealItemsForMenu(_menuID);
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                MealMenu _oMealMenuItem = new MealMenu();
                _oMealMenuItem.Description = _dataRow["item_description"].ToString();
                _oMealMenuItem.MenuID = _dataRow["menuID"].ToString();
                _oMealMenuItem.MealMenuItemID = _dataRow["itemID"].ToString();

                _mealMenuItemList.Add(_oMealMenuItem);
            }
            return _mealMenuItemList;
        }

        public void saveNewMealItem(MealMenu poMealItem, ref GenericList<MealMenu> pMealItemList)
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                lMealMenuItemDAO.saveMealItem(poMealItem);

                pMealItemList.Add(poMealItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateMealItem(MealMenu poMealItem, ref GenericList<MealMenu> pMealItemList)
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                lMealMenuItemDAO.updateMealItem(poMealItem);

                foreach (MealMenu _oMealItem in pMealItemList)
                {
                    if (_oMealItem.MealMenuItemID == poMealItem.MealMenuItemID)
                    {
                        _oMealItem.Description = poMealItem.Description;
                        _oMealItem.GroupID = poMealItem.GroupID;
                        _oMealItem.MealMenuItemID = poMealItem.MealMenuItemID;
                        _oMealItem.Unit = poMealItem.Unit;
                        _oMealItem.UnitCost = poMealItem.UnitCost;
                        _oMealItem.Vat = poMealItem.Vat;
                        _oMealItem.ServiceCharge = poMealItem.ServiceCharge;
                        _oMealItem.SellingPrice = poMealItem.SellingPrice;

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteMealItem(string pMealItemID, ref GenericList<MealMenu> pMealItemList)
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                lMealMenuItemDAO.deleteMealItem(pMealItemID);

                foreach (MealMenu _oMealItem in pMealItemList)
                {
                    if (_oMealItem.MealMenuItemID == pMealItemID)
                    {
                        pMealItemList.Remove(_oMealItem);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Meal Menu

        public GenericList<MealMenu> getMealMenus()
        {
            GenericList<MealMenu> _MealMenuList = new GenericList<MealMenu>();
            lMealMenuItemDAO = new MealMenuItemDAO();
            DataTable _dataTable = lMealMenuItemDAO.getMealMenu();
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                MealMenu _oMealMenu = new MealMenu();
                _oMealMenu.Description = _dataRow["description"].ToString();
                _oMealMenu.MenuID = _dataRow["menuID"].ToString();
                _oMealMenu.Price = double.Parse(_dataRow["price"].ToString());
                _oMealMenu.Vat = double.Parse(_dataRow["vat"].ToString());
                _oMealMenu.ServiceCharge = double.Parse(_dataRow["service_Charge"].ToString());

                _MealMenuList.Add(_oMealMenu);
            }
            return _MealMenuList;
        }

        public void saveMealMenu(MealMenu poMealMenu, ref GenericList<MealMenu> pMealItemList)
        {
            //string _menuID = "";
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                string _mealMenu = lMealMenuItemDAO.saveMealMenu(poMealMenu);

                poMealMenu.MenuID = _mealMenu;
                pMealItemList.Add(poMealMenu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateMealMenu(MealMenu poMealMenu, ref GenericList<MealMenu> pMealMenuList)
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                lMealMenuItemDAO.updateMealMenu(poMealMenu);

                foreach (MealMenu _oMealMenu in pMealMenuList)
                {
                    if (_oMealMenu.MenuID == poMealMenu.MenuID)
                    {
                        _oMealMenu.Description = poMealMenu.Description;
                        _oMealMenu.MenuID = poMealMenu.MenuID;
                        _oMealMenu.Price = poMealMenu.Price;
                        _oMealMenu.Vat = poMealMenu.Vat;
                        _oMealMenu.ServiceCharge = poMealMenu.ServiceCharge;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteMealMenu(string pMenuID, ref GenericList<MealMenu> pMealMenuList)
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                lMealMenuItemDAO.deleteMealMenu(pMenuID);

                foreach (MealMenu _oMealMenu in pMealMenuList)
                {
                    if (pMenuID == _oMealMenu.MenuID)
                    {
                        pMealMenuList.Remove(_oMealMenu);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Meal Group

        public void saveMealGroup(ref MealMenu poMealGroup, ref GenericList<MealMenu> pMealGroupList)
        {
            string _groupID = "";
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                _groupID = lMealMenuItemDAO.saveMealGroup(poMealGroup);

                poMealGroup.GroupID = int.Parse(_groupID);
                pMealGroupList.Add(poMealGroup);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateMealGroup(ref MealMenu poMealGroup, ref GenericList<MealMenu> pMealGroupList)
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                lMealMenuItemDAO.updateMealGroup(poMealGroup);

                foreach (MealMenu _oMealGroup in pMealGroupList)
                {
                    if (_oMealGroup.GroupID == poMealGroup.GroupID)
                    {
                        _oMealGroup.GroupID = poMealGroup.GroupID;
                        _oMealGroup.Description = poMealGroup.Description;
						_oMealGroup.MainGroupId = poMealGroup.MainGroupId;

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteMealGroup(string pGroupID, ref GenericList<MealMenu> pMealGroupList)
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                lMealMenuItemDAO.deleteMealGroup(pGroupID);

                foreach (MealMenu _oMealGroup in pMealGroupList)
                {
                    if (_oMealGroup.GroupID == int.Parse(pGroupID))
                    {
                        pMealGroupList.Remove(_oMealGroup);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenericList<MealMenu> getMealGroups()
        {
            try
            {
                lMealMenuItemDAO = new MealMenuItemDAO();
                DataTable _dataTable = lMealMenuItemDAO.getMealGroups();
                GenericList<MealMenu> _mealGroupList = new GenericList<MealMenu>();

                foreach (DataRow _dataRow in _dataTable.Rows)
                {
                    MealMenu _oMealGroup = new MealMenu();
                    _oMealGroup.GroupID = int.Parse(_dataRow["groupID"].ToString());
                    _oMealGroup.Description = _dataRow["Description"].ToString();
					_oMealGroup.MainGroupId = _dataRow["mainGroupId"].ToString();

                    _mealGroupList.Add(_oMealGroup);
                }
                return _mealGroupList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenericList<MealMenu> getDetailsForGroup(string _groupID)
        {
            lMealMenuItemDAO = new MealMenuItemDAO();
            DataTable _dataTable = lMealMenuItemDAO.getDetailsForMealGroup(_groupID);
            GenericList<MealMenu> _mealGroupList = new GenericList<MealMenu>();

            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                MealMenu _oMealGroup = new MealMenu();
                _oMealGroup.GroupID = int.Parse(_dataRow["groupID"].ToString());
                _oMealGroup.Description = _dataRow["Description"].ToString();

                _mealGroupList.Add(_oMealGroup);
            }
            return _mealGroupList;
        }

        #endregion

        #region Meal Menu Detail

        public void saveMenuDetail(MealMenu poMealMenuDetail)
        {
            lMealMenuItemDAO = new MealMenuItemDAO();
            lMealMenuItemDAO.saveMealMenuDetail(poMealMenuDetail);
        }

        public void deleteMenuDetail(string pMenuID)
        {
            lMealMenuItemDAO = new MealMenuItemDAO();
            lMealMenuItemDAO.deleteMealMenuDetail(pMenuID);
        }

        #endregion

    }
}
