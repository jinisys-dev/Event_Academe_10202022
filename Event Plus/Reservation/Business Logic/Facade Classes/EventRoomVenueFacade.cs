using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventRoomVenueFacade
    {
        private EventRoomVenueDAO loRoomVenueDAO;
        public void saveEventRoomVenue(EventRoomVenue poRoomVenue)
        {
            loRoomVenueDAO = new EventRoomVenueDAO();
            loRoomVenueDAO.saveEventRoomVenues(poRoomVenue);
        }

        public void deleteEventRoomVenue(string pFolioID)
        {
            loRoomVenueDAO = new EventRoomVenueDAO();
            loRoomVenueDAO.deleteEventRoomVenues(pFolioID);
        }

        public GenericList<EventRoomVenue> getEventRoomVenues(string pFolioID)
        {
            loRoomVenueDAO = new EventRoomVenueDAO();
            GenericList<EventRoomVenue> _RoomVenueList = new GenericList<EventRoomVenue>();
            DataTable _dataTable = loRoomVenueDAO.getEventRoomVenues(pFolioID);
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventRoomVenue _oEventRoomVenue = new EventRoomVenue();
                _oEventRoomVenue.FolioID = _dataRow["folioID"].ToString();
                _oEventRoomVenue.FromDate = DateTime.Parse(_dataRow["fromDate"].ToString());
                _oEventRoomVenue.RoomVenue = _dataRow["roomVenue"].ToString();
                _oEventRoomVenue.ToDate = DateTime.Parse(_dataRow["toDate"].ToString());

                _RoomVenueList.Add(_oEventRoomVenue);
            }

            return _RoomVenueList;
        }
    }
}
