using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;

namespace  Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    class DropDownConfiguration
    {
        #region "VARIABLES"
        DropDownConfigurationDAO oDropDownConfigurationDAO;
        #endregion

        public DropDownConfiguration()
        {
            oDropDownConfigurationDAO = new DropDownConfigurationDAO();
        }

        public DataTable getGroupBookingDropDown()
        {
            return oDropDownConfigurationDAO.getGroupBookingDropDown();
        }

        public DataTable getFieldNames()
        {
            return oDropDownConfigurationDAO.getFieldNames();
        }

        public void saveGroupBookingDropDown(string pFieldName, string pValue)
        {
            oDropDownConfigurationDAO.saveGroupBookingDropDown(pFieldName, pValue);
        }

        public void updateGroupBookingDropDown(string pFieldName, string pValue, int pId)
        {
            oDropDownConfigurationDAO.updateGroupBookingDropDown(pFieldName, pValue, pId);
        }

        public void deleteGroupBookingDropDown(int pId)
        {
            oDropDownConfigurationDAO.deleteGroupBookingDropDown(pId);
        }
    }
}
