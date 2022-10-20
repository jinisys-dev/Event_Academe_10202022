
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class CalendarFacade
    {
        private CalendarDAO oCalendarDAO;

        public CalendarFacade()
        {
        }

        public Calendar getCalendar(int roomid)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.getCalendar(roomid);
        }
        public DataTable countOccupiedRooms(string StartDate)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.countOccupiedRooms(StartDate);
        }
        public DataTable GetSpectedDepartures(string StartDate)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.GetExpectedDepartures(StartDate);
        }
        public DataTable GetSpectedEndOOO(string StartDate)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.GetSpectedEndOOO(StartDate);
        }
        public DataTable GetSpectedArrivals(string StartDate)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.GetSpectedArrivals(StartDate);
        }

        public DataTable getCurrentDayRoomStatus(string d)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.getCurrentDayRoomStatus(d);
        }

        public DataTable getYesterDayRoomOccupancy(string d)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.getYesterDayRoomOccupancy(d);
        }

        // added by: Jerome April 14, 2008
        // SCR-001, Golden Prince
        // passed RoomTypeCode so we could sort by RoomRate
		public DataTable getRoomEventByRoomForAvailability(string a_Date, string a_RoomId)
		{
			try
			{
				oCalendarDAO = new CalendarDAO();

				DataTable dtRoomEvents = oCalendarDAO.getRoomEventByRoomForAvailability(a_Date, a_RoomId);

				DataTable dtExpectedCheckOut = this.GetSpectedDepartures(a_Date);
				DataTable dtExpectedCheckIn = this.GetSpectedArrivals(a_Date);

				// check if room is blocked
				RoomBlockDAO oRoomBlockDAO = new RoomBlockDAO();

				foreach (DataRow dRow in dtRoomEvents.Rows)
				{
					string _roomId = dRow["roomid"].ToString();
					string _eventType = dRow["eventtype"].ToString();

					switch (_eventType)
					{
						case "":
						case "CLOSED":
						case "CANCELLED":
						case "NO SHOW":

							dRow["eventtype"] = "";

							// checks if ROOM IS BLOCKED
							bool inBlock = oRoomBlockDAO.CheckIfRoomIsBlock(_roomId, a_Date, "");
							if (inBlock)
							{
								dRow["eventtype"] = "BLOCKED";
							}
							

							break;

						// checks if EXPECTED CHECKOUT then count as AVAILABLE
						case "IN HOUSE":
							foreach (DataRow dRowExpectedCO in dtExpectedCheckOut.Rows)
							{
								if (dRowExpectedCO["roomid"].ToString() == _roomId)
								{
									dRow["eventtype"] = "";
									break;
								}
							}
							// checks if ROOM IS BLOCKED
							inBlock = oRoomBlockDAO.CheckIfRoomIsBlock(_roomId, a_Date, "");
							if (inBlock)
							{
								dRow["eventtype"] = "BLOCKED";
							}
							


							break;


						case "RESERVATION":

							dRow["eventtype"] = "RESERVED";
							foreach (DataRow dRowExpectedCO in dtExpectedCheckOut.Rows)
							{
								if (dRowExpectedCO["roomid"].ToString() == _roomId)
								{
									dRow["eventtype"] = "";
									break;
								}
							}
						
							break;
						
					}//end switch

					// check if expected Check In
					foreach (DataRow dRowExpectedCI in dtExpectedCheckIn.Rows)
					{
						if (dRowExpectedCI["roomid"].ToString() == _roomId)
						{
							dRow["eventtype"] = "RESERVED";
							break;
						}
					}

				}

				return dtRoomEvents;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public DataTable getRoomEventsForPlotting(string pStartDate, string pEndDate)
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getRoomEventsForPlotting( pStartDate, pEndDate );

		}

		// for MDI main Current Room Status LEGEND
		public DataTable getFunctionStatusAndCleaningSummary()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getFunctionStatusAndCleaningSummary();

		}

		// for MDI main Current Room Status LEGEND
		public DataTable getRoomStatusAndCleaningSummary()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getRoomStatusAndCleaningSummary();

		}
		
		// for MDI main Current Room Status LEGEND
		public int getExpectedCheckInRoomCount()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getExpectedCheckInRoomCount();
		}

		// for MDI main Current Room Status LEGEND
		public int getTotalBlockRoomsCount()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getTotalBlockRoomsCount();
		}

		// for MDI main Current Room Status LEGEND
		public int getTotalOutOfOrderRoomsCount()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getTotalOutOfOrderRoomsCount();
		}


		// for MDI main Current FUNCTION ROOM Status LEGEND
		public int getExpectedCheckInFunctionCount()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getExpectedCheckInFunctionCount();
		}

		// for MDI main Current FUNCTION ROOM Status LEGEND
		public int getTotalBlockFunctionCount()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getTotalBlockFunctionCount();
		}

		// for MDI main Current FUNCTION ROOM Status LEGEND
		public int getTotalOutOfOrderFunctionCount()
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getTotalOutOfOrderFunctionCount();
		}


		public decimal getDailyRoomOccupancyRate(string pReportDate)
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getDailyRoomOccupancyRate(pReportDate, GlobalVariables.gHotelId);
		}

		public decimal getDailyFunctionRoomOccupancyRate(string pReportDate)
		{
			oCalendarDAO = new CalendarDAO();
			return oCalendarDAO.getDailyFunctionRoomOccupancyRate(pReportDate, GlobalVariables.gHotelId);
		}


        //Kevin Oliveros 2014-05-02
        public DataTable getMergeRoomsForPlotting(string pScheduleID,string pRoomID,string pFolioID)
        {
            oCalendarDAO = new CalendarDAO();
            return oCalendarDAO.getMergeRoomsForPlotting(pScheduleID, pRoomID, pFolioID);

        }


    }

}