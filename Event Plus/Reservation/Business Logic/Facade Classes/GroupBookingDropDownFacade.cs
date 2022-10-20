using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class GroupBookingDropDownFacade
    {
        public GroupBookingDropDownFacade()
        { 
        
        }

        public string[] getByFieldName(string pFieldName)
        {
            GroupBookingDropDownDAO oGroupBookingDropDownDAO = new GroupBookingDropDownDAO();
            DataTable dtDropDown = oGroupBookingDropDownDAO.getGroupFolioDropDown(GlobalVariables.gPersistentConnection);

            DataView dtView = dtDropDown.DefaultView;
            dtView.RowFilter = "FieldName = '" + pFieldName + "'";

            string[] strDropDowns = new string[dtView.Count];

            int i = 0;
            foreach (DataRowView row in dtView)
            {

                strDropDowns[i] = row["Value"].ToString();
                i++;
            }

            return strDropDowns;

        }

        public DataTable getSpecificFieldName(string pFieldName)
        {
            try
            {
                GroupBookingDropDownDAO _oGroupBookingDropDownDAO = new GroupBookingDropDownDAO();
                return _oGroupBookingDropDownDAO.getSpecificFieldName(pFieldName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error @GroupBookingDropDownFacade.getSpecificFieldName\r\n" + ex.Message); 
            }
        }

        public DataTable getDetailsForDropDown()
        {
            GroupBookingDropDownDAO _oGroupBookingDropDownDAO = new GroupBookingDropDownDAO();
            DataTable _oDTDropDown = _oGroupBookingDropDownDAO.getGroupFolioDropDown(GlobalVariables.gPersistentConnection);

            return _oDTDropDown;
        }

        public DataTable getGroupBooking(string pFieldName)
        {
            GroupBookingDropDownDAO _oGroupBookingDropDownDAO = new GroupBookingDropDownDAO();
            DataTable _oDTDropDown = _oGroupBookingDropDownDAO.getGroupBooking(pFieldName);

            return _oDTDropDown;
        }
    }
}
