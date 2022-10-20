
using System;
using MySql.Data;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class CalendarDAO
    {

        public CalendarDAO()
        {

        }

        public Calendar getCalendar(int roomid)
        {
            string roomeventCommandStr = "select Guest.Lastname ,roomevents.date ,roomevents.roomid ,roomevents.eventtype from guest, roomevents, folio where guest.accountid = folio.accountid And folio.folioid = roomevents.eventid And roomevents.roomid =" + roomid + " And roomevents.date >= now() and roomevents.eventtype <> 'CLOSED'";
            MySqlCommand roomEventsCommand = new MySqlCommand(roomeventCommandStr, GlobalVariables.gPersistentConnection);

            MySqlDataAdapter roomEventDataAdapter = new MySqlDataAdapter(roomEventsCommand);

            Calendar CalendarDataset = new Calendar();

            try
            {

                roomEventDataAdapter.Fill(CalendarDataset, "RoomEvents");
                return CalendarDataset;
                //					roomEventDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " getCalendar(ByVal roomid As Integer) As Jinisys.Hotel.Reservation.BusinessLayer.Calendar", "Calendar DAO Error");
                return null;
            }

        }

        public DataTable getCurrentDayRoomStatus(string d)
        {
            string CommandStr = "call spSelectCurrentDayRoomStatus('" + d + "'," + GlobalVariables.gHotelId + ")";
            MySqlCommand Command = new MySqlCommand(CommandStr, GlobalVariables.gPersistentConnection);
            Command.CommandType = CommandType.Text;
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable CurrentDayStatusTable = new DataTable("CurrentDayStatus");

            try
            {
                DataAdapter.Fill(CurrentDayStatusTable);
                CleanUpCurrentRoomStatus(CurrentDayStatusTable);
                return CurrentDayStatusTable;
                //					DataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("EXCEPTION: " + ex.Message + " getCurrentDayRoomStatus(ByVal d As String) As DataTable","Calendar DAO Error");
                //return null;
                throw new Exception("EXCEPTION: " + ex.Message + " getCurrentDayRoomStatus(ByVal d As String) As DataTable, Calendar DAO Error");
            }
        }

        public DataTable countOccupiedRooms(string StartDate)
        {

            string CommandStr = "call spCountOccupiedRooms('" + StartDate 
				              + "'," + GlobalVariables.gHotelId 
							  + ")";

            MySqlCommand Command = new MySqlCommand(CommandStr, GlobalVariables.gPersistentConnection);
            Command.CommandType = CommandType.Text;
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable RoomsOccupiedTable = new DataTable("OccupiedRoomsCount");

            try
            {
                DataAdapter.Fill(RoomsOccupiedTable);

                return RoomsOccupiedTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " getCurrentDayRoomStatus(ByVal d As String) As DataTable", "Calendar DAO Error");
                return null;
            }
        }
        public DataTable GetExpectedDepartures(string StartDate)
        {

			string _sqlStr = "call spGetExpectedCheckOuts('" + 
								   StartDate + "'," + 
								   GlobalVariables.gHotelId + ")";

			//string CommandStr = "call spGetExpectedCheckOuts('" + StartDate 
			//                  + "'," + GlobalVariables.gHotelId + ")";

			//MySqlCommand Command = new MySqlCommand(CommandStr, GlobalVariables.gPersistentConnection);
			//Command.CommandType = CommandType.Text;

			MySqlDataAdapter DataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
            DataTable ExpectedCheckOuts = new DataTable("ExpectedCheckOuts");

            try
            {
                DataAdapter.Fill(ExpectedCheckOuts);

                return ExpectedCheckOuts;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetSpectedDepartures(ByVal d As String) As DataTable", "Calendar DAO Error");
                return null;
            }
        }

        public DataTable GetSpectedEndOOO(string StartDate)
        {

            string _sqlStr = "call spGetExpectedEndOOO('" +
                                   StartDate + "'," +
                                   GlobalVariables.gHotelId + ")";

            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
            DataTable ExpectedEndOutOfOrder = new DataTable("ExpectedEndOOO");

            try
            {
                DataAdapter.Fill(ExpectedEndOutOfOrder);

                return ExpectedEndOutOfOrder;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetSpectedDepartures(ByVal d As String) As DataTable", "Calendar DAO Error");
                return null;
            }
        }

        public DataTable GetSpectedArrivals(string StartDate)
        {

            string CommandStr = "call spGetExpectedCheckIn('" + StartDate 
				              + "'," + GlobalVariables.gHotelId 
							  + ")";

            MySqlCommand Command = new MySqlCommand(CommandStr, GlobalVariables.gPersistentConnection);
            Command.CommandType = CommandType.Text;
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable ExpectedCheckIn = new DataTable("ExpectedCheckOuts");

            try
            {
                DataAdapter.Fill(ExpectedCheckIn);

                return ExpectedCheckIn;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetExpectedArrivals(ByVal d As String) As DataTable", "Calendar DAO Error");
                return null;
            }
        }

        private void CleanUpCurrentRoomStatus(DataTable dt)
        {
            if (dt.Rows.Count > 1)
            {
                int i = 1;
                while (i < dt.Rows.Count)
                {
                    if (dt.Rows[i][0].ToString() != dt.Rows[i - 1][0].ToString())
                    {
                        i++;
                    }
                    else
                    {
						string _currentEventType = "";
						_currentEventType = dt.Rows[i]["EventType"].ToString().ToUpper();

						string _previousEventType = "";
						_previousEventType = dt.Rows[i - 1]["EventType"].ToString().ToUpper();


						if (_currentEventType == "RESERVATION" && _previousEventType == "IN HOUSE")
                        {
                            dt.Rows.RemoveAt(i);
                        }
						else if (_currentEventType == "RESERVATION" && _previousEventType == "")
                        {
                            dt.Rows.RemoveAt(i - 1);
                        }
						else if (_currentEventType == "IN HOUSE" && _previousEventType == "RESERVATION")
                        {
                            dt.Rows.RemoveAt(i - 1);
                        }
						else if (_currentEventType == "IN HOUSE" && _previousEventType == "")
                        {
                            dt.Rows.RemoveAt(i - 1);
                        }
						else if (_currentEventType == "" && _previousEventType == "RESERVATION")
                        {
                            dt.Rows.RemoveAt(i);
                        }
						else if (_currentEventType == "" && _previousEventType == "IN HOUSE")
                        {
                            dt.Rows.RemoveAt(i);
                        }

						else if (_currentEventType == "IN HOUSE" && _previousEventType == "ENGINEERING JOB")
						{
							dt.Rows.RemoveAt(i - 1);
						}

						else if (_currentEventType == "ENGINEERING JOB" && _previousEventType == "IN HOUSE")
						{
							dt.Rows.RemoveAt(i);
						}
                        else if (_currentEventType == "RESERVATION" && _previousEventType == "ENGINEERING JOB")
                        {
                            dt.Rows.RemoveAt(i);
                        }
                        else if (_currentEventType == "ENGINEERING JOB" && _previousEventType == "RESERVATION")
                        {
                            dt.Rows.RemoveAt(i);
                        }
                        i++;
                    }
                }
                dt.AcceptChanges();
            }
        }

        public DataTable getYesterDayRoomOccupancy(string a_Date)
        {
			DataTable dtOccupancy = new DataTable("CurrentDayStatus");

            string strSelect = "call spSelectYesterdayRoomOccupancy('" + a_Date + "')";
            MySqlDataAdapter dtaSelect = new MySqlDataAdapter(strSelect, GlobalVariables.gPersistentConnection);
			
            try
            {
				dtaSelect.Fill(dtOccupancy);

                return dtOccupancy;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " getYesterDayRoomOccupancy(ByVal d As String) As DataTable","CalendarDAO Error");
                return null;
            }
        }


        // added by: Jerome April 14, 2008
        // SCR-001, Golden Prince
        // passed RoomTypeCode so we could sort by Room Rate
        public DataTable getRoomEventByRoomForAvailability(string a_Date, string a_RoomId)
        {
            try
            {
                DataTable dtRoomEvents = new DataTable();

                MySqlDataAdapter dtSelect = new MySqlDataAdapter("call spGetRoomEventByRoomForAvailability('" + a_Date + "'," + GlobalVariables.gHotelId + ",'" + a_RoomId + "')", GlobalVariables.gPersistentConnection);
                dtSelect.Fill(dtRoomEvents);

                return dtRoomEvents;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

		public DataTable getRoomEventsForPlotting(string pStartDate, string pEndDate)
		{

			DataTable dtRoomEvents = new DataTable("RoomEvents");
			try
			{
				string _sqlStr = "call spSelectRoomEvent('" +
									   pStartDate + "','" +
									   pEndDate + "')";

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(dtRoomEvents);
				dataAdapter.Dispose();

				return dtRoomEvents;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public DataTable getFunctionStatusAndCleaningSummary()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				string _sqlStr = "call spGetFunctionStatusAndCleaningSummary('" +
									   GlobalVariables.gHotelId + "')";

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(dtRooms);
				dataAdapter.Dispose();


				return dtRooms;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable getRoomStatusAndCleaningSummary()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				string _sqlStr = "call spGetRoomStatusAndCleaningSummary('" +
									   GlobalVariables.gHotelId + "')";

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(dtRooms);
				dataAdapter.Dispose();


				return dtRooms;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getExpectedCheckInRoomCount()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				int _total = 0;
				string _sqlStr = "call spGetExpectedCheckInRoomCount('" +
									   GlobalVariables.gAuditDate + "','" +
									   GlobalVariables.gHotelId + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_total = int.Parse(_selectCommand.ExecuteScalar().ToString()) ;
				}
				catch { }
				


				return _total;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getTotalBlockRoomsCount()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				int _total = 0;
				string _sqlStr = "call spGetTotalBlockRoomsCount('" +
									   GlobalVariables.gAuditDate + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_total = int.Parse(_selectCommand.ExecuteScalar().ToString());
				}
				catch { }

				return _total;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getTotalOutOfOrderRoomsCount()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				int _total = 0;
				string _sqlStr = "call spGetTotalOutOfOrderRoomsCount('" +
									   GlobalVariables.gAuditDate + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_total = int.Parse(_selectCommand.ExecuteScalar().ToString());
				}
				catch { }

				return _total;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		// FUNCTION ROOMS
		public int getExpectedCheckInFunctionCount()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				int _total = 0;
				string _sqlStr = "call spGetExpectedCheckInFunctionCount('" +
									   GlobalVariables.gAuditDate + "','" +
									   GlobalVariables.gHotelId + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_total = int.Parse(_selectCommand.ExecuteScalar().ToString());
				}
				catch { }



				return _total;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getTotalBlockFunctionCount()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				int _total = 0;
				string _sqlStr = "call spGetTotalBlockFunctionCount('" +
									   GlobalVariables.gAuditDate + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_total = int.Parse(_selectCommand.ExecuteScalar().ToString());
				}
				catch { }

				return _total;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getTotalOutOfOrderFunctionCount()
		{
			DataTable dtRooms = new DataTable();
			try
			{
				int _total = 0;
				string _sqlStr = "call spGetTotalOutOfOrderFunctionCount('" +
									   GlobalVariables.gAuditDate + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_total = int.Parse(_selectCommand.ExecuteScalar().ToString());
				}
				catch { }

				return _total;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public decimal getDailyRoomOccupancyRate(string pReportDate, int pHotelId)
		{
			decimal _occupancyRate = 0;
			try
			{

				string _sqlStr = "select fGetDailyRoomOccupancyRate('" +
									   pReportDate + "'," + 
									   pHotelId + ")";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_occupancyRate = decimal.Parse(_selectCommand.ExecuteScalar().ToString());
				}
				catch { }

				return _occupancyRate;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public decimal getDailyFunctionRoomOccupancyRate(string pReportDate, int pHotelId)
		{
			decimal _occupancyRate = 0;
			try
			{

				string _sqlStr = "select fGetDailyFunctionRoomOccupancyRate('" +
									   pReportDate + "'," +
									   pHotelId + ")";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				try
				{
					_occupancyRate = decimal.Parse(_selectCommand.ExecuteScalar().ToString());
				}
				catch { }

				return _occupancyRate;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
        public DataTable getMergeRoomsForPlotting(string pScheduleID, string pRoomID, string pFolioID)
        {

            DataTable _dtMergeRooms = new DataTable("RoomEvents");
            try
            {
                string _sqlStr = "call spSelectMergeRooms('" +
                                       pScheduleID + "','" +
                                       pRoomID + "','" +
                                       pFolioID + "')";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(_dtMergeRooms);
                dataAdapter.Dispose();


                return _dtMergeRooms;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}