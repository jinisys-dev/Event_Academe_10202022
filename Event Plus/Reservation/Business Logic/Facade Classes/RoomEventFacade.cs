
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;

using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class RoomEventFacade
    {

        RoomEventDAO oRoomEventDAO;

        public RoomEventFacade()
        {
        }

        public RoomEvents GetRoomEvent(int eventNo)
        {
            oRoomEventDAO = new RoomEventDAO( );
            return oRoomEventDAO.GetRoomEvent(eventNo);
        }

        public bool IsRoomCharged(string roomid, string eventdate, string FolioID)
        {
            oRoomEventDAO = new RoomEventDAO( );
            return oRoomEventDAO.IsRoomCharged(roomid, eventdate, FolioID);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="roomid">Room No to check</param>
		/// <param name="eventdate">Date</param>
		/// <param name="lastRoomEventDate">End Date, this should be excluded in the condition</param>
		/// <param name="_folioId">Folio Id of the guest to update, this should be included in the condition, sameFolio ID on Room Events </param>
		/// <returns></returns>
        public int CheckConflict(string roomid, string eventdate, string lastRoomEventDate, string _folioId)
        {
            oRoomEventDAO = new RoomEventDAO( );
            return oRoomEventDAO.CheckConflict(roomid, eventdate,lastRoomEventDate, _folioId);
        }

        public void DeleteRoomEvents(RoomEvents oRoomEvent, string folioID)
        {
            oRoomEventDAO = new RoomEventDAO( );
            oRoomEventDAO.DeleteRoomEvents(oRoomEvent, folioID);
        }

        public void DeleteRoomsEvents(string folioID, string roomID)
        {
            oRoomEventDAO = new RoomEventDAO();
            oRoomEventDAO.DeleteRoomsEvents(folioID, roomID);
        }

        public void UpdateRoomEvents(string pEventType, string pFolioid, string pRoomid, ref MySqlTransaction pDBTrans)
        {
            oRoomEventDAO = new RoomEventDAO();
			oRoomEventDAO.UpdateRoomEvents(pEventType, pFolioid, pRoomid, ref pDBTrans);
        }

        public int UpdateRoomEventsRate(string Folioid, string Roomid, string DateFrom, string dateTo, decimal newRate)
        {
            oRoomEventDAO = new RoomEventDAO();
            return oRoomEventDAO.UpdateRoomEventsRate(Folioid, Roomid, System.Convert.ToDateTime(DateFrom), System.Convert.ToDateTime(dateTo), newRate);
        }
        
        public int UpdateRoomEventsRate(string Folioid, string Roomid,  string dateTo, decimal newRate)
        {
            oRoomEventDAO = new RoomEventDAO();
            return oRoomEventDAO.UpdateRoomEventsRate(Folioid, Roomid,  System.Convert.ToDateTime(dateTo), newRate);
        }
        
        public void DeleteRoomEvent(RoomEvents oRoomEvent, string folioID)
        {
            oRoomEventDAO = new RoomEventDAO();
            oRoomEventDAO.DeleteRoomEvent(oRoomEvent, folioID);
        }

        public void DeleteRoomEventDynamic(ref RoomEvents oRoomevents, string whrCondition)
        {
            oRoomEventDAO = new RoomEventDAO();
            oRoomEventDAO.DeleteRoomEventsDynamic(oRoomevents, whrCondition);
        }

        public void CancelRoomEvents(string folioID, string eventType, string eventType1)
        {
            oRoomEventDAO = new RoomEventDAO();
            oRoomEventDAO.CancelRoomEvents(folioID, eventType, eventType1);
        }

        public void SetRoomEventType(ref RoomEvents oRoomEvent, string folioID)
        {
            oRoomEventDAO = new RoomEventDAO( );
            oRoomEventDAO.SetEventType(oRoomEvent, folioID);
        }

        public string getRoomEventsFolioId(string a_RoomNo, string pStartDate,string pEndDate, string a_EventType)
        {
            oRoomEventDAO = new RoomEventDAO();
			return oRoomEventDAO.getRoomEventsFolioId(a_RoomNo, pStartDate, pEndDate, a_EventType);
        }

        public GenericList<RoomEvents> getChildFoliosRoomEvents(string pMasterFolio)
        {
            oRoomEventDAO = new RoomEventDAO();
            GenericList<RoomEvents> _oRoomEventsList = new GenericList<RoomEvents>();
            DataTable _dataTable = oRoomEventDAO.getChildFoliosRoomEvents(pMasterFolio);

            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                RoomEvents _oRoomEvent = new RoomEvents();
                _oRoomEvent.RoomRate = decimal.Parse(_dataRow["roomrate"].ToString());
                _oRoomEvent.Eventid = _dataRow["eventid"].ToString();

                _oRoomEventsList.Add(_oRoomEvent);
            }
            return _oRoomEventsList;
        }


		public void saveRoomEvent(RoomEvents oRoomEvent, ref MySqlTransaction poTrans)
		{
			oRoomEventDAO = new RoomEventDAO();
			oRoomEventDAO.saveRoomEvents(oRoomEvent, ref poTrans);
		}

		public void deleteAllFolioRoomEvents(string pFolioID, ref MySqlTransaction poDBTransaction)
		{
			oRoomEventDAO = new RoomEventDAO();
			
			oRoomEventDAO.deleteAllFolioRoomEvents(pFolioID, ref poDBTransaction);

		}


		public void setRoomEventPosted(string pFolioId, string pRoomNo, DateTime pEventDate, ref MySqlTransaction poDBTrans)
		{
			oRoomEventDAO = new RoomEventDAO();
			oRoomEventDAO.setRoomEventPosted(pFolioId, pRoomNo, pEventDate, ref poDBTrans);

		}

    }
}