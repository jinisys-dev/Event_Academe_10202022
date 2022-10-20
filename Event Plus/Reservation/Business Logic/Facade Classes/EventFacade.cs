using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;


using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

//added Apr. 25, 2008
namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventFacade
    {
        public EventFacade()
        { }

        #region "Events"
        private EventsDAO eventDAO;
        public void insertEvents(EventBookingInfo oEvent, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            eventDAO = new EventsDAO();
            eventDAO.insertEvent(oEvent, ref pTrans);
        }

        public bool checkEventExists(string folioID)
        {
            eventDAO = new EventsDAO();
            return eventDAO.checkEventExists(folioID);
        }

        public void updateEvents(EventBookingInfo oEvent, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            eventDAO = new EventsDAO();
            eventDAO.updateEvent(oEvent, ref pTrans);
        }

        public void deleteEvents(string eventID)
        {
            eventDAO = new EventsDAO();
            eventDAO.deleteEvent(eventID);
        }

        public GenericList<EventBookingInfo> getEvents()
        {
            GenericList<EventBookingInfo> events = new GenericList<EventBookingInfo>();
            eventDAO = new EventsDAO();
            DataTable dt = eventDAO.getEvents();
            foreach (DataRow dr in dt.Rows)
            {
                EventBookingInfo oEvents = new EventBookingInfo();
                oEvents.FolioID = dr["folioID"].ToString();
                oEvents.BookingDate = DateTime.Parse(dr["bookingDate"].ToString());
                oEvents.EventName = dr["eventName"].ToString();
                oEvents.EventType = dr["eventType"].ToString();
                oEvents.Status = dr["status"].ToString();
                oEvents.StartEventDate = DateTime.Parse(dr["startEventDate"].ToString());
                oEvents.EndEventDate = DateTime.Parse(dr["endEventDate"].ToString());
                oEvents.NumberOfLiveIn = int.Parse(dr["noOfPaxLiveIn"].ToString());
                oEvents.NumberOfLiveOut = int.Parse(dr["noOfPaxLiveOut"].ToString());
                oEvents.NumberOfPaxGuaranteed = int.Parse(dr["noOfPaxGuaranteed"].ToString());
                oEvents.StartEventTime = dr["eventStartTime"].ToString();
                oEvents.EndEventTime = dr["eventEndTime"].ToString();
                oEvents.RoomAssigned = dr["roomAssigned"].ToString();
                oEvents.BillingArrangement = dr["billingArrangement"].ToString();
                oEvents.AuthorizedSignatory = dr["authorizedSignatory"].ToString();
                oEvents.LobbyPosting = dr["lobbyPosting"].ToString();
                oEvents.Source = dr["source"].ToString();
                oEvents.RoomVenue = dr["roomVenue"].ToString();
                oEvents.PackagePosted = int.Parse(dr["packagePosted"].ToString());
                oEvents.EmailAddress = dr["EmailAddress"].ToString();

                events.Add(oEvents);
            }
            return events;
        }

        public GenericList<EventBookingInfo> getEvent(string folioID)
        {
            GenericList<EventBookingInfo> events = new GenericList<EventBookingInfo>();
            eventDAO = new EventsDAO();
            DataTable dt = eventDAO.getEvent(folioID);
            foreach (DataRow dr in dt.Rows)
            {
                EventBookingInfo oEvents = new EventBookingInfo();
                oEvents.FolioID = dr["folioID"].ToString();
                oEvents.BookingDate = DateTime.Parse(dr["bookingDate"].ToString());
                oEvents.EventType = dr["eventType"].ToString();
                oEvents.NumberOfLiveIn = int.Parse(dr["noOfPaxLiveIn"].ToString());
                oEvents.NumberOfLiveOut = int.Parse(dr["noOfPaxLiveOut"].ToString());
                oEvents.NumberOfPaxGuaranteed = int.Parse(dr["noOfPaxGuaranteed"].ToString());
                oEvents.BillingArrangement = dr["billingArrangement"].ToString();
                oEvents.AuthorizedSignatory = dr["authorizedSignatory"].ToString();
                oEvents.LobbyPosting = dr["lobbyPosting"].ToString();
                oEvents.PackageAmount = decimal.Parse(dr["packageAmount"].ToString());
                oEvents.EventPackage = int.Parse(dr["eventPackage"].ToString());
                oEvents.ContactPosition = dr["contactPosition"].ToString();
                oEvents.ContactPerson = dr["contactPerson"].ToString();
                oEvents.ContactNumber = dr["contactNumber"].ToString();
                oEvents.ContactAddress = dr["contactAddress"].ToString();
                oEvents.FaxNumber = dr["faxNumber"].ToString();
                oEvents.MobileNumber = dr["mobileNumber"].ToString();
                oEvents.EstimatedTotalCost = decimal.Parse(dr["totalEstimatedCost"].ToString());
                oEvents.PackagePosted = int.Parse(dr["packagePosted"].ToString());
                oEvents.EmailAddress = dr["EmailAddress"].ToString();
                
                events.Add(oEvents);
            }
            return events;
        }

        public void updateGroupPackage(string pFolioID)
        {
            eventDAO = new EventsDAO();
            eventDAO.updateGroupPackage(pFolioID);
        }

        public bool isGroupPackagePosted(string pFolioID)
        {
            eventDAO = new EventsDAO();
            return eventDAO.isGroupPackagePosted(pFolioID);
        }
        
        #endregion

        #region "Event Details"
        public void saveEventDetails(EventDetails details, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            eventDAO = new EventsDAO();
            eventDAO.saveEventDetails(details, ref pTrans);
        }

        public void deleteEventDetails(string folioID, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            eventDAO = new EventsDAO();
            eventDAO.deleteEventDetails(folioID, ref pTrans);
        }

        public GenericList<EventDetails> getEventDetails(string folioID)
        {
            eventDAO = new EventsDAO();
            DataTable dt = eventDAO.getEventDetails(folioID);
            GenericList<EventDetails> eventDetails = new GenericList<EventDetails>();
            
            foreach (DataRow dr in dt.Rows)
            {
                EventDetails eventDetail = new EventDetails();
                eventDetail.Description = dr["description"].ToString();
                eventDetail.EventDetailHeader = dr["eventDetailHeader"].ToString();

                eventDetails.Add(eventDetail);
            }
            return eventDetails;
        }
        #endregion

        public bool unconfirmEventReservation(string pEventId)
        {
            eventDAO = new EventsDAO();
            return eventDAO.unconfirmEventReservation(pEventId);
        }
        public DataTable getMemoRecipients()
        {
            eventDAO = new EventsDAO();
            return eventDAO.getMemoRecipients();
        }
    }
}
