

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
    public class RoomEventDAO
    {

        private ParameterHelper oParameterHelper;

        public RoomEventDAO()
        {
            oParameterHelper = new ParameterHelper();
        }

        public int UpdateRoomEventsRate(string Folioid, string Roomid, DateTime DateFrom, DateTime dateTo, decimal newRate)
        {
            try
            {
                string cmdText;

                cmdText = "call spUpdateRoomEventsRate('" + 
								Folioid + "','" + 
								Roomid + "','" + 
								string.Format("{0:yyyy-MM-dd}", dateTo) + "'," + 
								newRate + ",'" + 
								GlobalVariables.gLoggedOnUser + "'," + 
								GlobalVariables.gHotelId + ")";

                MySqlCommand saveRoomEventCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                return saveRoomEventCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " Sub UpdateRoomEvents(ByVal eventType As String, ByVal Folioid As String, ByVal Roomid As String)");
                return 0;
            }
        }

        //(02-09-07)this added by jun mar to correct _oAppliedRates applied when _rooms transfer occur
        public int UpdateRoomEventsRate(string Folioid, string Roomid, DateTime dateTo, decimal newRate)
        {
            try
            {
                string cmdText;

                cmdText = "call spUpdateRoomEventsRate1(\'" + Folioid + "\',\'" + Roomid + "\',\'" + string.Format("{0:yyyy-MM-dd}", dateTo) + "\'," + newRate + ",\'" + GlobalVariables.gLoggedOnUser + "\'," + GlobalVariables.gHotelId + ")";
                MySqlCommand saveRoomEventCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                return saveRoomEventCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " UpdateRoomEventsRate(string Folioid, string Roomid, DateTime dateTo, decimal newRate)");
                return 0;
            }
        }

        public void UpdateRoomEvents(string eventType, string Folioid, string Roomid, ref MySqlTransaction pDBTrans)
        {
            try
            {
				string _sqlStr = "call spUpdateRoomEvents('" + 
										eventType + "','" + 
										Folioid + "','" + 
										Roomid + "'," + 
										GlobalVariables.gHotelId + ",'" + 
										GlobalVariables.gLoggedOnUser + 
										"')";

                MySqlCommand _insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				_insertCommand.Transaction = pDBTrans;

                _insertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " Sub UpdateRoomEvents(ByVal eventType As String, ByVal Folioid As String, ByVal Roomid As String)");
            }
        }

        public RoomEvents GetRoomEvent(int eventNo)
        {
            try
            {
                string cmdText;

                cmdText = "call spGetRoomEvent(" + eventNo + "," + GlobalVariables.gHotelId + ")";

                MySqlCommand GetRoomEventCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter daRoomevent = new MySqlDataAdapter(GetRoomEventCommand);
                DataTable dtRoomevent = new DataTable("RoomEvent");
                daRoomevent.Fill(dtRoomevent);
                RoomEvents Roomevent = new RoomEvents();
                Roomevent.Eventid = dtRoomevent.Rows[0]["EventID"].ToString();
                Roomevent.EventNo = int.Parse(dtRoomevent.Rows[0]["EventNo"].ToString());
                Roomevent.EventDate = DateTime.Parse(dtRoomevent.Rows[0]["EventDate"].ToString());
                Roomevent.EventType = dtRoomevent.Rows[0]["EventType"].ToString();
                Roomevent.HotelID = int.Parse(dtRoomevent.Rows[0]["HotelID"].ToString());
                Roomevent.UpdatedBy = dtRoomevent.Rows[0]["UpdatedBy"].ToString();
                Roomevent.CreatedBy = dtRoomevent.Rows[0]["CreatedBy"].ToString();
                return Roomevent;
                //					dtRoomevent.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetRoomEvent(ByVal eventNo As Integer) As RoomEvents");
                return null;
            }
        }

        public int CheckConflict(string roomid, string eventdate, string lastRoomEventDate, string pFolioId)
        {
            try
            {
                string cmdText;
                int returnVal = 0;

                cmdText = "call spCheckConflictRoomEvents('" + 
											roomid + "','" + 
											eventdate + "'," + 
											GlobalVariables.gHotelId + ",'" + 
											pFolioId + "')";

                MySqlCommand saveRoomEventCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);

                returnVal = System.Convert.ToInt32(saveRoomEventCommand.ExecuteScalar());

                // this is to test whether Conflict RoomEvents found
                // is for Expected Checkout

                CalendarFacade oCalendarFacade = new CalendarFacade();
                DataTable dtExpectedCheckouts = oCalendarFacade.GetSpectedDepartures(eventdate);
                DataTable dtExpectedCheckIn = oCalendarFacade.GetSpectedArrivals(eventdate);
                DataTable dtExpectedEndOOO = oCalendarFacade.GetSpectedEndOOO(eventdate);
                
                // check if room is blocked
				RoomBlockDAO oRoomBlockDAO = new RoomBlockDAO();
                DateTime pStartdate = DateTime.Parse(eventdate);
                DateTime pEndDate = DateTime.Parse(lastRoomEventDate);
                int _ctr = 1;
                for (DateTime pDate = pStartdate; pDate < pEndDate; pDate = pDate.AddDays(1))
                {
                    bool inBlock = oRoomBlockDAO.CheckIfRoomIsBlock(roomid, pDate.ToString("yyyy-MM-dd"), pFolioId);
                    if (inBlock)
                    {
                        if (_ctr >= 1)
                            return 1;

                        _ctr++;
                    }
                }


                if (returnVal > 0)
                {

                    /*  this is to check wether room is in expected CI
                        on the date specified 
                        if is in Spected CI then return conflict
                     *  jerome March 24, 2008 , Jinisys
                     */
                    foreach (DataRow expectedCI in dtExpectedCheckIn.Rows)
                    {
                        string _expectedCIRoomId = expectedCI["roomid"].ToString().ToUpper();
                        if (_expectedCIRoomId == roomid.ToUpper())
                        {
                            if (eventdate == lastRoomEventDate)
                            {
                                return 0;
                            }
                            else
                            {
								// check if Expected CheckIn Folio is not the Folio being edited
								if (expectedCI["folioid"].ToString() != pFolioId)
								{
									return returnVal;
								}
                            }
                        }
                    }

                    /*  this is to check wether room is in expected CheckOut
                        on the date specified, if so, then return 0 (no Conflict)
                        since Schedule does not overlap any reservation
                    *  jerome March 28, 2008 , Jinisys
                    */
                    foreach (DataRow expectedCO in dtExpectedCheckouts.Rows)
                    {
                        string _roomNo = expectedCO["roomid"].ToString().ToUpper();

                        if (_roomNo == roomid.ToUpper())
                        {
                            return 0;
                        }
                    }

                    /*  this is to check wether room is in expected to end from out of order status
                        on the date specified, if so, then return 0 (no Conflict)
                        since Schedule does not overlap any reservation
                    */
                    foreach (DataRow expectedCO in dtExpectedEndOOO.Rows)
                    {
                        string _roomNo = expectedCO["roomid"].ToString().ToUpper();

                        if (_roomNo == roomid.ToUpper())
                        {
                            return 0;
                        }
                    }
                }

                
                
                return returnVal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking Room for conflict.\r\nException " + ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }
        public bool IsRoomCharged(string roomid, string eventdate, string folioid)
        {
            try
            {
                string cmdText;

                cmdText = "call spRoomIsCharge('" + roomid + "','" + eventdate + "','" + folioid + "," + GlobalVariables.gHotelId + ")";
                MySqlCommand saveRoomEventCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                string ChrgFlg = saveRoomEventCommand.ExecuteScalar().ToString();
                if (ChrgFlg == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                //MsgBox("EXCEPTION: " & ex.Message & " CheckConflict(ByVal roomid As String, ByVal eventdate As String) As Integers")
            }
        }

        public void DeleteRoomEvents(RoomEvents oRoomEvent, string folioID)
        {
            try
            {
                MySqlCommand deleteRoomEventCommand = new MySqlCommand("call spDeleteRoomEvents('" + oRoomEvent.Eventid + "','" + oRoomEvent.RoomID + "','" + oRoomEvent.EventType + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                deleteRoomEventCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  DeleteRoomEvents(ByVal folioID As Integer, ByVal eventType As String, Optional ByVal Eventtype1 As String = \") As RoomEvents");
            }
        }

        public void DeleteRoomsEvents(string folioID, string roomID)
        {
            try
            {
                MySqlCommand deleteRoomEventCommand = new MySqlCommand("call spDeleteRoomsEvents('" + folioID + "','" + roomID + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                deleteRoomEventCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  DeleteRoomEvents(ByVal folioID As Integer, ByVal eventType As String, Optional ByVal Eventtype1 As String = \") As RoomEvents");
            }
        }

        public void DeleteRoomEvent(RoomEvents oRoomEvent, string folioID)
        {
            try
            {
                MySqlCommand deleteRoomEventCommand = new MySqlCommand("call spDeleteRoomEvent('" + oRoomEvent.Eventid + "','" + oRoomEvent.RoomID + "','" + oRoomEvent.EventType + "'," + GlobalVariables.gHotelId + ",'" + string.Format("{0:yyyy-MM-dd}", oRoomEvent.EventDate) + "')", GlobalVariables.gPersistentConnection);

                deleteRoomEventCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  DeleteRoomEvents(ByVal folioID As Integer, ByVal eventType As String, Optional ByVal Eventtype1 As String = \") As RoomEvents");
            }
        }

        public void DeleteRoomEventsDynamic(RoomEvents oRoomevents, string whrCondition)
        {
            try
            {
                MySqlCommand deleteRoomEventCommand = new MySqlCommand("Delete from Roomevents " + whrCondition, GlobalVariables.gPersistentConnection);

                deleteRoomEventCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  DeleteRoomEvents(ByRef oRoomevents As RoomEvents, ByVal whrCondition As String) As RoomEvents");
            }
        }

        public void CancelRoomEvents(string folioID, string eventType, string Eventtype1)
        {
            try
            {
                MySqlCommand deleteRoomEventCommand = new MySqlCommand("call spCancelRoomEvent(\'" + folioID + "\',\'" + eventType + "\',\'" + Eventtype1 + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

                deleteRoomEventCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  DeleteRoomEvents(ByVal folioID As Integer, ByVal eventType As String, Optional ByVal Eventtype1 As String = \") As RoomEvents");
            }
        }

        public void SetEventType(RoomEvents oRoomEvents, string folioID)
        {
            try
            {
                MySqlCommand setEventTypeCommand = new MySqlCommand("call spSetEventType(\'" + oRoomEvents.EventType + "\',\'" + folioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                setEventTypeCommand.CommandType = CommandType.Text;
                setEventTypeCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  SetEventType(ByRef oRoomEvents As RoomEvents, ByVal folioID As Integer) As RoomEvents");
            }
        }


        public string getRoomEventsFolioId(string a_RoomNo, string pStartDate,string pEndDate, string a_EventType)
        {
            string folioId = "";
            try
            {
                string _sqlStr = "call spGetRoomEventsFolioId('" + a_RoomNo + "','" + pStartDate + "','" + a_EventType + "','" + GlobalVariables.gHotelId + "')";

				//if (pStartDate != pEndDate)
				//{
					DataTable _tempDt = new DataTable();

					MySqlDataAdapter _dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

					_dtAdapter.Fill(_tempDt);

					
						switch (_tempDt.Rows.Count)
						{ 
							case 0:
								folioId = "";
								break;
							case 1:
								folioId = _tempDt.Rows[_tempDt.Rows.Count - 1][0].ToString();
								break;

							default: // if more than one rows are returned
								foreach (DataRow _dRow in _tempDt.Rows)
								{
									DateTime _fromDate = DateTime.Parse(_dRow["fromDate"].ToString());
									DateTime _toDate = DateTime.Parse(_dRow["toDate"].ToString());

									string _strFromDate = string.Format("{0:yyyy-MM-dd}", _fromDate);
									string _strToDate = string.Format("{0:yyyy-MM-dd}", _toDate);

									folioId = _dRow[0].ToString();

									if (_strFromDate == pStartDate && _strToDate == pEndDate)
									{
										return folioId;
									}
								}

								break;

						}
						
			
                return folioId;
            }
            catch
            {
                return folioId;
            }
        }

        //>>for getting the room events of child folios in a group
        public DataTable getChildFoliosRoomEvents(string pMasterFolio)
        {
            try
            {
                string _sqlQuery = "call spGetChildFolioRoomEvents('" + pMasterFolio + "'," + GlobalVariables.gHotelId + ")";
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _dataTable = new DataTable("Schedules");
                _dataAdapter.Fill(_dataTable);

                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public void saveRoomEvents(RoomEvents pRoomEvent, ref MySqlTransaction poTrans)
		{
			try
			{
				string cmdText = "call spInsertRoomEvents('" + 
									   pRoomEvent.Eventid + "','" + 
									   pRoomEvent.RoomID + "','" + 
									   string.Format("{0:yyyy-MM-dd}", pRoomEvent.EventDate) + "','" + 
									   pRoomEvent.EventType + "'," + 
									   pRoomEvent.RoomRate + ",'" + 
									   GlobalVariables.gLoggedOnUser + "'," + 
									   GlobalVariables.gHotelId + ",'" +
									   pRoomEvent.TransferFlag + "','" +
                                       string.Format("{0:HH:mm:ss}", pRoomEvent.StartEventTime) + "','" +
                                       string.Format("{0:HH:mm:ss}", pRoomEvent.EndEventTime) + "')";


				MySqlCommand insertRoomEvent = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
				insertRoomEvent.Transaction = poTrans;

				insertRoomEvent.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void deleteAllFolioRoomEvents(string pFolioID, ref MySqlTransaction poDBTransaction)
		{
			try
			{
				string _sqlStr = "call spDeleteAllFolioRoomEvents('" + 
									   pFolioID + "','" + 
									   GlobalVariables.gHotelId + "')";

				MySqlCommand _deleteCommand = new MySqlCommand( _sqlStr, GlobalVariables.gPersistentConnection );
				_deleteCommand.Transaction = poDBTransaction;

				_deleteCommand.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public void setRoomEventPosted(string pFolioId, string pRoomNo, DateTime pEventDate, ref MySqlTransaction poDBTrans)
		{
			try
			{
				string _sqlStr = "call spSetRoomEventPosted('" +
									   pFolioId + "','" +
									   pRoomNo + "','" + 
									   string.Format("{0:yyyy-MM-dd}",pEventDate) + "','" +
									   GlobalVariables.gHotelId + "')";

				MySqlCommand _updateCommand = new MySqlCommand( _sqlStr, GlobalVariables.gPersistentConnection );
				_updateCommand.Transaction = poDBTrans;

				_updateCommand.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				//throw ex;
				MessageBox.Show(ex.Message);
			}
		}


    }
}