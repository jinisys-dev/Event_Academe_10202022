using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class EventRoomVenueDAO
    {
        public void saveEventRoomVenues(EventRoomVenue poRoomVenue)
        {
            string _folioID = poRoomVenue.GetType().GetProperty("FolioID").GetValue(poRoomVenue, null).ToString();
            string _roomVenue = poRoomVenue.GetType().GetProperty("RoomVenue").GetValue(poRoomVenue, null).ToString();
            DateTime _fromDate = DateTime.Parse(poRoomVenue.GetType().GetProperty("FromDate").GetValue(poRoomVenue, null).ToString());
            DateTime _toDate = DateTime.Parse(poRoomVenue.GetType().GetProperty("ToDate").GetValue(poRoomVenue, null).ToString());

            string _sql = "call spInsertEventRoomVenues('" + _folioID + "','" + _roomVenue + "','" + string.Format("{0:yyyy-MM-dd}", _fromDate) + "','" + string.Format("{0:yyyy-MM-dd}", _toDate) + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEventRoomVenues(string pFolioID)
        {
            string _sql = "delete from event_room_venues where folioid='" + pFolioID + "'";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventRoomVenues(string pFolioID)
        {
            string _sql = "call spGetEventRoomVenues('" + pFolioID + "')";
            try
            {
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable _dataTable = new DataTable("RoomVenue");

                _dataAdapter.Fill(_dataTable);
                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
