
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class ScheduleDAO
    {

        private ParameterHelper oParameterHelper;

        public ScheduleDAO()
        {
            oParameterHelper = new ParameterHelper();
        }

        public Schedule GetSchedule(string folioID)
        {
            Schedule oSchedule = new Schedule();
            try
            {
				string _sqlStr = "call spGetSchedule('" + 
									   folioID + "','" + 
									   GlobalVariables.gHotelId + "')";

                MySqlDataAdapter _dtSchedule = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtSchedule.Fill(oSchedule, "FolioEvents");

				return oSchedule;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetSchedule(ByVal folioID As String) As Schedule");
                return null;
            }
        }

        public void SaveSchedule(Schedule a_Schedule)
        {
            try
            {
                if (a_Schedule.Setup == null)
                {
                    a_Schedule.Setup = "";
                }
                else if (a_Schedule.Venue == null)
                {
                    a_Schedule.Venue = "";
                }
                else if (a_Schedule.Remarks == null)
                {
                    a_Schedule.Remarks = "";
                }
                else if (a_Schedule.GuaranteedPax == null)
                {
                    a_Schedule.GuaranteedPax = "";
                }

                string terminalId = GlobalVariables.gTerminalID.ToString();
                string shiftCode = GlobalVariables.gShiftCode.ToString();
                string supervisorId = GlobalVariables.gLoggedSupervisor;
                
                string cmdText = "call spInsertFolioSchedule(";
                cmdText += a_Schedule.HotelID + ",'" + a_Schedule.FolioID + "','" + a_Schedule.RoomID + "',";
                cmdText += "'" + a_Schedule.RoomType + "','" + string.Format("{0:yyyy-MM-dd}", a_Schedule.FromDate) + "','" + string.Format( "{0:yyyy-MM-dd}", a_Schedule.ToDate ) + "',";
                cmdText += a_Schedule.Days + ",'" + a_Schedule.RateType + "'," + a_Schedule.Rate + ",";
                cmdText += "'" + a_Schedule.BreakFast + "','" + a_Schedule.CreatedBy + "','" + a_Schedule.UpdatedBy + "','" + terminalId + "','" + shiftCode + "','" + supervisorId + "','" + 
                    string.Format("{0:HH:mm:ss}", a_Schedule.StartTime) + "','" + string.Format("{0:HH:mm:ss}", a_Schedule.EndTime) + ",'" + a_Schedule.Venue + "','" + a_Schedule.Setup + "','" + a_Schedule.Remarks + "','" + a_Schedule.GuaranteedPax + "')";

                MySqlCommand InsertCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                InsertCommand.CommandType = CommandType.Text;


                InsertCommand.ExecuteNonQuery();
                InsertCommand.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
                //MessageBox.Show("EXCEPTION: " + ex.Message + " SaveSchedule(ByRef _oSchedule As Object)");
            }
        }

        public void DeleteSchedule(Schedule oSchedule)
        {
            try
            {
				string _sqlStr = "call spDeleteFolioSchedules('" +
										oSchedule.FolioID + "','" +
										oSchedule.RoomID + "'," +
										GlobalVariables.gHotelId + ")";

                MySqlCommand deleteCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                deleteCommand.ExecuteNonQuery();

				_sqlStr = "call spUpdateRoomStatus('VACANT','" + 
								oSchedule.RoomID + "')";

                MySqlCommand updateRoomCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                updateRoomCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " DeleteSchedule(ByRef oSchedule As Schedule)");
            }
        }

        public void deleteFolioSchedules(string pFolioId, ref MySqlTransaction poDBTransaction)
        {
            try
            {
				string _sqlStr = "call spDeleteFolioSchedule('" +
									   pFolioId + "'," +
									   GlobalVariables.gHotelId + ")";


                MySqlCommand deleteCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				deleteCommand.Transaction = poDBTransaction;
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
				throw ex;
            }
        }

        public void SetType(Schedule oSchedule)
        {
            try
            {
                MySqlCommand setTYpeCommand = new MySqlCommand("call spSetFolioScheduleType (\'" + oSchedule.FolioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                setTYpeCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " SetType(ByRef oSchedule As Schedule)");
            }
        }

        public string GetRoomFromSchedules(string folioid)
        {
            try
            {
                string rooms = "";

                DataTable dtRooms = new DataTable();
                MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetSchedule(\'" + folioid + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                dtAdapter.Fill(dtRooms);

                DataRow dtrow;
                foreach (DataRow tempLoopVar_dtrow in dtRooms.Rows)
                {
                    dtrow = tempLoopVar_dtrow;
                    if(!rooms.Contains(dtrow["roomId"].ToString()))
                        rooms += dtrow["roomId"] + ", ";
                }

                if (rooms != "")
                {
                    rooms = rooms.Substring(0, rooms.Length - 2);
                }

                return rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetRoomFromSchedules(ByVal folioid As Integer) As String");
                return "";
            }
        }

        public string GetRoomAndRoomtypeFromSchedules(string folioid)
        {
            try
            {
                string rooms = "";

                DataTable dtRooms = new DataTable();
                MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetSchedule(\'" + folioid + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                dtAdapter.Fill(dtRooms);

                DataRow dtrow;
                foreach (DataRow tempLoopVar_dtrow in dtRooms.Rows)
                {
                    dtrow = tempLoopVar_dtrow;
                    rooms += dtrow["roomId"] + "-" + dtrow["roomType"] + ", ";
                }

                return rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetRoomFromSchedules(ByVal folioid As Integer) As String");
                return "";
            }
        }

        public DataTable GetRoomSchedulesForHistory(string folioid)
        {
            try
            {

                DataTable dtRooms = new DataTable();
                MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetSchedule('" + folioid + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                dtAdapter.Fill(dtRooms);

                return dtRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetRoomSchedulesForHistory(ByVal folioid As Integer) As String");
                return null;
            }
        }
        //Kevin Oliveros 2014-03-4
        public DataTable GetRoomEventForHistory(string folioid)
        {
            try
            {

                DataTable dtRooms = new DataTable();
                MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetRoomEventForHistory('" + folioid + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                dtAdapter.Fill(dtRooms);

                return dtRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetRoomSchedulesForHistory(ByVal folioid As Integer) As String");
                return null;
            }
        }


        public string getGuest(string AccountID)
        {

            try
            {
                string name = "";
                MySqlCommand GetGuestNameFromScedulesCommand = new MySqlCommand("call spGetName(\'" + AccountID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                GetGuestNameFromScedulesCommand.CommandType = CommandType.Text;

                MySqlDataReader GetRoomFromScedulesReader = GetGuestNameFromScedulesCommand.ExecuteReader();
                while (GetRoomFromScedulesReader.Read())
                {
                    name = GetRoomFromScedulesReader.GetValue(0).ToString();
                }
                GetRoomFromScedulesReader.Close();
                return name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " getGuest(ByVal AccountID As Integer) As String");
                return "";
            }
        }

        public int GetNoOfDays(string folioId)
        {
            int days = 0;
            try
            {

                MySqlCommand getDayscommand = new MySqlCommand("call spGetSchedule(\'" + folioId + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                MySqlDataReader getDaysReader = getDayscommand.ExecuteReader();
                while (getDaysReader.Read())
                {
                    days += System.Convert.ToInt32(getDaysReader.GetValue(5).ToString());
                }
                getDaysReader.Close();
                return days;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetNoOfDays(ByVal folioId As Integer) As Integer");
                return 0;
            }
        }

        public DateTime GetStartDay(string folioID)
        {
            try
            {
                MySqlCommand getStartDayCommand = new MySqlCommand("call spGetSchedule(\'" + folioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                MySqlDataReader getStartDayReader = getStartDayCommand.ExecuteReader();
                while (getStartDayReader.Read())
                {

                    return DateTime.Parse(getStartDayReader.GetValue(2).ToString());
                }
                getStartDayReader.Close();
                return DateTime.Parse("");

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetStartDay(ByVal folioID As Integer) As Date");
                return DateTime.Parse("");
            }
        }

        public void ReSetFolioSchedule(DateTime checkOutDate, string folioID)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("call spGetSchedule(\'" + folioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                MySqlDataReader checkDateReader = command.ExecuteReader();
                while (checkDateReader.Read())
                {
                    DateTime refstartDate = DateTime.Parse(checkDateReader.GetValue(2).ToString());
                    DateTime endDate = DateTime.Parse(checkDateReader.GetValue(3).ToString());
                    decimal rate = (decimal)checkDateReader.GetValue(4);
                    int promo = (int)checkDateReader.GetValue(6);
                    int days = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, refstartDate, endDate);
                    decimal amount = rate * days;
                    amount -= amount / (100 / promo);
                    if (refstartDate > checkOutDate)
                    {
                        DeleteFolioSchedule(folioID, refstartDate);
                    }
                    else if (endDate >= checkOutDate)
                    {
                        UpdateFolioSchedules(folioID, refstartDate, checkOutDate, days, amount);
                    }
                }
                checkDateReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " ReSetFolioSchedule(ByVal checkOutDate As Date, ByVal folioID As Integer)");
            }

        }

        public DateTime GetEndDay(string folioID)
        {
            try
            {
                MySqlCommand getEndDayCommand = new MySqlCommand("call spGetSchedule(\'" + folioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                MySqlDataReader getStartDayReader = getEndDayCommand.ExecuteReader();
                while (getStartDayReader.Read())
                {
                    return DateTime.Parse(getStartDayReader.GetValue(3).ToString());
                }
                getStartDayReader.Close();
                return DateTime.Parse("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetEndDay(ByVal folioID As Integer) As Date");
                return DateTime.Parse("");
            }
        }

        public decimal GetAmountFromSchedule(string folioID)
        {
            decimal Amount = 0;
            //Dim oConnection As New MySqlConnection(connectionString)
            try
            {
                // oConnection.Open()

                MySqlCommand getDayscommand = new MySqlCommand("call spGetSchedule(\'" + folioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                MySqlDataReader getDaysReader = getDayscommand.ExecuteReader();
                while (getDaysReader.Read())
                {
                    Amount += System.Convert.ToInt32(getDaysReader.GetValue(6).ToString());
                }
                getDaysReader.Close();
                return Amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetAmountFromSchedule(ByVal folioID As Integer) As decimal");
                return 0;
            }
        }

        public void UpdateFolioSchedules(Schedule a_Schedule)
        {
            MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
            {
                string cmdtext;
                if (a_Schedule.Setup == null)
                {
                    a_Schedule.Setup = "";
                }
                else if (a_Schedule.Venue == null)
                {
                    a_Schedule.Venue = "";
                }
                else if (a_Schedule.Remarks == null)
                {
                    a_Schedule.Remarks = "";
                }

                cmdtext = "call spUpdateFolioSchedules('" + a_Schedule.FolioID + "','" + 
														    a_Schedule.RoomID + "','" + 
															a_Schedule.RoomType + "','" + 
															string.Format("{0:yyyy-MM-dd}", a_Schedule.FromDate) + "','" + 
															string.Format("{0:yyyy-MM-dd}", a_Schedule.ToDate) + "'," + 
															a_Schedule.Days + ",'" + 
															a_Schedule.RateType + "'," + 
															a_Schedule.Rate + ",'" + 
															a_Schedule.BreakFast + "','" + 
															a_Schedule.UpdatedBy + "'," + 
															GlobalVariables.gHotelId + ",'" + 
															a_Schedule.StartTime + "','" + 
															a_Schedule.EndTime + "','" +
                                                            a_Schedule.Venue + "','" +
                                                            a_Schedule.Setup + "','" +
                                                            a_Schedule.Remarks + "')";

                MySqlCommand updateScheduleCommand = new MySqlCommand(cmdtext, GlobalVariables.gPersistentConnection);
                updateScheduleCommand.Transaction = trans;
                updateScheduleCommand.ExecuteNonQuery();

                string cmdTextUpdate;
                cmdTextUpdate = "call spUpdateRoomRate(" + GlobalVariables.gHotelId + ",\'" + string.Format("{0:yyyy-MM-dd}", a_Schedule.FromDate) + "\',\'" + string.Format("{0:yyyy-MM-dd}", a_Schedule.ToDate) + "\',\'" + a_Schedule.FolioID + "\',\'" + a_Schedule.RoomID + "\'," + a_Schedule.Rate + ")";

                MySqlCommand updateRoomRates = new MySqlCommand(cmdTextUpdate, GlobalVariables.gPersistentConnection);
                updateRoomRates.Transaction = trans;
                updateRoomRates.ExecuteNonQuery();

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("EXCEPTION: " + ex.Message + " UpdateFolioSchedules(ByVal oschedule As Schedule)");
            }
        }

		public bool UpdateFolioSchedulesEarlyCheckOut(Schedule a_Schedule, ref MySqlTransaction pDBTransaction)
		{
			try
			{
				string cmdtext;
				cmdtext = "call spUpdateFolioSchedulesEarlyCheckOut('" + 
								a_Schedule.FolioID + "','" +
								a_Schedule.RoomID + "','" +
								a_Schedule.RoomType + "','" +
								string.Format("{0:yyyy-MM-dd}", a_Schedule.FromDate) + "','" +
								string.Format("{0:yyyy-MM-dd}", a_Schedule.ToDate) + "'," +
								a_Schedule.Days + ",'" +
								a_Schedule.RateType + "'," +
								a_Schedule.Rate + ",'" +
								a_Schedule.BreakFast + "','" +
								a_Schedule.UpdatedBy + "'," +
								GlobalVariables.gHotelId + ")";


				MySqlCommand updateScheduleCommand = new MySqlCommand(cmdtext, GlobalVariables.gPersistentConnection);
				updateScheduleCommand.Transaction = pDBTransaction;
				int _rowsAffected = updateScheduleCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw new Exception("No rows affected on Update Folioschedule for Early Checkout.");
				}

				string _strUpdateRoomEvents = "call spUpdateRoomEventsForEarlyCheckOut('" + 
					                                a_Schedule.FolioID + "','" + 
													GlobalVariables.gAuditDate + "','" + 
													GlobalVariables.gLoggedOnUser + "','" + 
													GlobalVariables.gHotelId + "')";

				MySqlCommand _updateRoomEvents = new MySqlCommand(_strUpdateRoomEvents, GlobalVariables.gPersistentConnection);
				_updateRoomEvents.Transaction = pDBTransaction;

				_updateRoomEvents.ExecuteNonQuery();

				
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}


        private void UpdateFolioSchedules(string folioid, DateTime refstartdate, DateTime checkoutDate, int days, decimal Amount)
        {
            try
            {
                string cmdtext;

                cmdtext = "call spUpdateFolioSchedules(\'" + folioid + "\', , ,\'" + string.Format("{0:yyyy-MM-dd}", refstartdate) + "\',\'" + string.Format("{0:yyyy-MM-dd}", checkoutDate) + "\'," + days + ",,,,," + GlobalVariables.gHotelId + ",'','')";

                MySqlCommand updateCommand = new MySqlCommand(cmdtext, GlobalVariables.gPersistentConnection);

                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " UpdateFolioSchedules(ByVal folioid As Integer, ByVal refstartdate As Date, ByVal checkoutDate As Date, ByVal days As Integer, ByVal Amount As decimal)");
            }
        }
        
        private void DeleteFolioSchedule(string folioId, DateTime refdate)
        {
            try
            {

                MySqlCommand deleteCommand = new MySqlCommand("call spDeleteFolioScheduleRefArrivalDate(\'" + folioId + "\',\'" + string.Format("{0:yyyy-MM-dd}", refdate) + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                deleteCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " DeleteFolioSchedule(ByVal folioId As Integer, ByVal refdate As Date)");
            }
        }

        public bool setScheduleEarlyCheckOut(string a_FolioId, string a_RoomId)
        {

            try
            {
                MySqlCommand updateCommand = new MySqlCommand("call spUpdateSchedule_EarlyCheckOut('" + a_FolioId + "','" + a_RoomId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

                updateCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " Update Folio Schedule","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public void deActivateFolioSchedules(string pFolioId, int pHotelId , ref MySqlTransaction poDBTransaction)
        {
            MySqlCommand insertCommand = new MySqlCommand("call spDeActivateSchedules('" + pFolioId + "','" + pHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                insertCommand.Transaction = poDBTransaction;
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ScheduleDAO.deActiveFolioSchedules\r\n" + ex.Message);
            }
            finally
            {
                insertCommand.Dispose();        
            }
        }

        public void updateSchedule(Schedule poSchedule, ref MySqlTransaction poTrans)
        {
            try
            {
                if (poSchedule.Setup == null)
                {
                    poSchedule.Setup = "";
                }
                else if (poSchedule.Venue == null)
                {
                    poSchedule.Venue = "";
                }
                else if (poSchedule.Remarks == null)
                {
                    poSchedule.Remarks = "";
                }
                else if (poSchedule.GuaranteedPax == null)
                {
                    poSchedule.GuaranteedPax = "";
                }

                string _sqlStr = "call spUpdateSchedule(" +
                                       poSchedule.HotelID + ",'" +
                                       poSchedule.FolioID + "','" +
                                       poSchedule.RoomID + "','" +
                                       poSchedule.RoomType + "','" +
                                       string.Format("{0:yyyy-MM-dd}", poSchedule.FromDate) + "','" +
                                       string.Format("{0:yyyy-MM-dd}", poSchedule.ToDate) + "'," +
                                       poSchedule.Days + ",'" +
                                       poSchedule.RateType + "'," +
                                       poSchedule.Rate + ",'" +
                                       poSchedule.BreakFast + "','" +
                                       poSchedule.UpdatedBy + "','" +
                                       poSchedule.TerminalId + "','" +
                                       poSchedule.ShiftCode + "','" +
                                       poSchedule.SupervisorId + "','" +
                                       string.Format("{0:HH:mm:ss}", poSchedule.StartTime) + "','" +
                                       string.Format("{0:HH:mm:ss}", poSchedule.EndTime) + "','" +
                                       poSchedule.Venue + "','" +
                                       poSchedule.Setup + "','" +
                                       poSchedule.Remarks + "','" +
                                       poSchedule.GuaranteedPax + "','" +
                                       poSchedule.Activity + "','" +
                                       poSchedule.Id + "')";

                MySqlCommand insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                insertCommand.Transaction = poTrans;

                insertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

		public void saveSchedule(Schedule a_Schedule, ref MySqlTransaction poTrans)
		{
			try
			{
                if (a_Schedule.Setup == null)
                {
                    a_Schedule.Setup = "";
                }
                else if (a_Schedule.Venue == null)
                {
                    a_Schedule.Venue = "";
                }
                else if (a_Schedule.Remarks == null)
                {
                    a_Schedule.Remarks = "";
                }
                else if (a_Schedule.GuaranteedPax == null)
                {
                    a_Schedule.GuaranteedPax = "";
                }
				string _sqlStr = "call spInsertFolioSchedule(" + 
									   a_Schedule.HotelID + ",'" + 
									   a_Schedule.FolioID + "','" + 
									   a_Schedule.RoomID + "','" +
									   a_Schedule.RoomType + "','" + 
									   string.Format("{0:yyyy-MM-dd}", a_Schedule.FromDate) + "','" + 
									   string.Format("{0:yyyy-MM-dd}", a_Schedule.ToDate) + "'," + 
									   a_Schedule.Days + ",'" + 
									   a_Schedule.RateType + "'," + 
									   a_Schedule.Rate + ",'" + 
									   a_Schedule.BreakFast + "','" + 
									   a_Schedule.CreatedBy + "','" + 
									   a_Schedule.UpdatedBy + "','" +
									   a_Schedule.TerminalId + "','" +
									   a_Schedule.ShiftCode + "','" +
									   a_Schedule.SupervisorId + "','" +
                                       string.Format("{0:HH:mm:ss}", a_Schedule.StartTime) + "','" +
                                       string.Format("{0:HH:mm:ss}", a_Schedule.EndTime) + "','" +
                                       a_Schedule.Venue + "','" +
                                       a_Schedule.Setup + "','" +
                                       a_Schedule.Remarks + "','" +
                                       a_Schedule.GuaranteedPax + "','" +
                                       a_Schedule.Activity + "')";

				MySqlCommand insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				insertCommand.Transaction = poTrans;

				insertCommand.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
    }
}