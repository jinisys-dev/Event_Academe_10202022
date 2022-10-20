using System;
using MySql.Data;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;

//new - added Apr. 25, 2008
namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class EventsDAO
    {
        public EventsDAO()
        { }

        #region "Events"

        public DataTable getEvents()
        {
            string sql = "call spSelectAllEvents()";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Events");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkEventExists(string folioID)
        {
            string sql = "select * from event_booking_info where folioID='" + folioID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Events");
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEvent(string folioID)
        {
            EventBookingInfo oEvent = new EventBookingInfo();
            string sql = "select * from event_booking_info where folioID='" + folioID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Events");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertEvent(EventBookingInfo oEvent, ref MySqlTransaction pTrans)
        {
            string folioID = oEvent.GetType().GetProperty("FolioID").GetValue(oEvent, null).ToString();
            string eventType = oEvent.GetType().GetProperty("EventType").GetValue(oEvent, null).ToString();
            DateTime bookingDate = DateTime.Parse(oEvent.GetType().GetProperty("BookingDate").GetValue(oEvent, null).ToString());
            int noOfLiveIn = int.Parse(oEvent.GetType().GetProperty("NumberOfLiveIn").GetValue(oEvent, null).ToString());
            int noOfLiveOut = int.Parse(oEvent.GetType().GetProperty("NumberOfLiveOut").GetValue(oEvent, null).ToString());
            string noOfGuaranteed = oEvent.GetType().GetProperty("NumberOfPaxGuaranteed").GetValue(oEvent, null).ToString();
            string billingArrangement = oEvent.GetType().GetProperty("BillingArrangement").GetValue(oEvent, null).ToString();
            string authorizedSignatory = oEvent.GetType().GetProperty("AuthorizedSignatory").GetValue(oEvent, null).ToString();
            string lobbyPosting = oEvent.GetType().GetProperty("LobbyPosting").GetValue(oEvent, null).ToString();
            string createdBy = oEvent.GetType().GetProperty("CREATEDBY").GetValue(oEvent, null).ToString();
            int hotelID = int.Parse(oEvent.GetType().GetProperty("HotelID").GetValue(oEvent, null).ToString());
            int eventPackage = int.Parse(oEvent.GetType().GetProperty("EventPackage").GetValue(oEvent, null).ToString());
            decimal packageAmount = decimal.Parse(oEvent.GetType().GetProperty("PackageAmount").GetValue(oEvent, null).ToString());
            string contactPerson = oEvent.GetType().GetProperty("ContactPerson").GetValue(oEvent, null).ToString();
            string contactAddress = oEvent.GetType().GetProperty("ContactAddress").GetValue(oEvent, null).ToString();
            string contactPostion = oEvent.GetType().GetProperty("ContactPosition").GetValue(oEvent, null).ToString();
            string contactNumber = oEvent.GetType().GetProperty("ContactNumber").GetValue(oEvent, null).ToString();
            string mobileNumber = oEvent.GetType().GetProperty("MobileNumber").GetValue(oEvent, null).ToString();
            string faxNumber = oEvent.GetType().GetProperty("FaxNumber").GetValue(oEvent, null).ToString();
            decimal totalCost = decimal.Parse(oEvent.GetType().GetProperty("EstimatedTotalCost").GetValue(oEvent, null).ToString());
            string emailAdd = oEvent.GetType().GetProperty("EmailAddress").GetValue(oEvent, null).ToString();

            string sql = "call spInsertEvent('" + folioID + "','" + eventType + "','" + string.Format("{0:yyyy-MM-dd}", bookingDate) +
                "'," + noOfLiveIn + "," + noOfLiveOut + "," + noOfGuaranteed + ",'" + billingArrangement + "','" + authorizedSignatory + 
                "','" + lobbyPosting + "','" + createdBy + "'," + hotelID + "," + eventPackage + "," + packageAmount + ",'" + contactPerson + 
                "','" + contactAddress + "','" + contactPostion + "','" + contactNumber + "','" + mobileNumber + "','" + faxNumber + "'," + totalCost + ",'" + emailAdd + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                throw new Exception("ERROR: " + ex.Message + " = @ insertEvent() ");
            }
        }

        public void updateEvent(object oEvent, ref MySqlTransaction pTrans)
        {
            string folioID = oEvent.GetType().GetProperty("FolioID").GetValue(oEvent, null).ToString();
            string eventType = oEvent.GetType().GetProperty("EventType").GetValue(oEvent, null).ToString();
            int noOfLiveIn = int.Parse(oEvent.GetType().GetProperty("NumberOfLiveIn").GetValue(oEvent, null).ToString());
            int noOfLiveOut = int.Parse(oEvent.GetType().GetProperty("NumberOfLiveOut").GetValue(oEvent, null).ToString());
            string noOfGuaranteed = oEvent.GetType().GetProperty("NumberOfPaxGuaranteed").GetValue(oEvent, null).ToString();
            string billingArrangement = oEvent.GetType().GetProperty("BillingArrangement").GetValue(oEvent, null).ToString();
            string authorizedSignatory = oEvent.GetType().GetProperty("AuthorizedSignatory").GetValue(oEvent, null).ToString();
            string lobbyPosting = oEvent.GetType().GetProperty("LobbyPosting").GetValue(oEvent, null).ToString();
            string createdBy = oEvent.GetType().GetProperty("CREATEDBY").GetValue(oEvent, null).ToString();
            int hotelID = int.Parse(oEvent.GetType().GetProperty("HotelID").GetValue(oEvent, null).ToString());
            int eventPackage = int.Parse(oEvent.GetType().GetProperty("EventPackage").GetValue(oEvent, null).ToString());
            decimal packageAmount = decimal.Parse(oEvent.GetType().GetProperty("PackageAmount").GetValue(oEvent, null).ToString());
            string contactPerson = oEvent.GetType().GetProperty("ContactPerson").GetValue(oEvent, null).ToString();
            string contactAddress = oEvent.GetType().GetProperty("ContactAddress").GetValue(oEvent, null).ToString();
            string contactPostion = oEvent.GetType().GetProperty("ContactPosition").GetValue(oEvent, null).ToString();
            string contactNumber = oEvent.GetType().GetProperty("ContactNumber").GetValue(oEvent, null).ToString();
            string mobileNumber = oEvent.GetType().GetProperty("MobileNumber").GetValue(oEvent, null).ToString();
            string faxNumber = oEvent.GetType().GetProperty("FaxNumber").GetValue(oEvent, null).ToString();
            decimal totalCost = decimal.Parse(oEvent.GetType().GetProperty("EstimatedTotalCost").GetValue(oEvent, null).ToString());
            string emailAdd = oEvent.GetType().GetProperty("EmailAddress").GetValue(oEvent, null).ToString();

            string sql = "call spUpdateEvent('" + folioID + "','" + eventType + "'," + noOfLiveIn + 
                "," + noOfLiveOut + "," + noOfGuaranteed + ",'" + billingArrangement + "','" + authorizedSignatory +
                "','" + lobbyPosting + "','" + createdBy + "'," + hotelID + "," + eventPackage + "," + packageAmount + ",'" + contactPerson +
                "','" + contactAddress + "','" + contactPostion + "','" + contactNumber + "','" + mobileNumber + "','" + faxNumber + "'," + totalCost + ",'" + emailAdd + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                throw new Exception("ERROR: " + ex.Message + " = @ updateEvent() ");
            }
        }

        public void deleteEvent(string eventID)
        {
            string sql = "Call spDeleteEvent('" + eventID + "')";
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

        public void updateGroupPackage(string pFolioID)
        {
            string sql = "call spPostGroupPackage('" + pFolioID + "')";
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

        public bool isGroupPackagePosted(string pFolioID)
        {
            string sql = "select packagePosted from event_booking_info where folioid='" + pFolioID + "'";
            int posted = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                try
                {
                    posted = int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch
                {
                    posted = 0;
                }

                sql = "select * from foliorecurringcharge where folioid='" + pFolioID + "' and summaryFlag=1 and packageID!=0";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                DataTable dTable = new DataTable();
                dataAdapter.Fill(dTable);

                if (posted == 0 && dTable.Rows.Count > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Event Details"
        public void saveEventDetails(EventDetails details, ref MySqlTransaction pTrans)
        {
            string folioID = details.GetType().GetProperty("FolioID").GetValue(details, null).ToString();
            string header = details.GetType().GetProperty("EventDetailHeader").GetValue(details, null).ToString();
            string value = details.GetType().GetProperty("Description").GetValue(details, null).ToString();

            string sql = "Call spInsertEventDetails('" + folioID + "','" + header + "','" + value + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                throw new Exception("ERROR: " + ex.Message + " = @ saveEventDetails() ");
            }
        }

        public void deleteEventDetails(string folioID, ref MySqlTransaction pTrans)
        {
            string sql = "delete from event_details where folioID='" + folioID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                throw new Exception("ERROR: " + ex.Message + " = @ deleteEventDetails() ");
            }
        }

        public DataTable getEventDetails(string folioID)
        {
            string sql = "select * from event_details where folioID='" + folioID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("EventDetails");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //Clark 10.05.2011
        //unconfirm reservations
        MySqlCommand loMySqlCommand;
        public bool unconfirmEventReservation(string pEventId)
        {
            try
            {
                string _sql = "call spUnconfirmEventReservation('" + pEventId + "','" + GlobalVariables.gLoggedOnUser + "')";

                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                if (loMySqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                loMySqlCommand.Dispose();
            }
        }

        public DataTable getMemoRecipients()
        {
     
            string sql = "call spGetMemoRecipients()";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Recipients");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}