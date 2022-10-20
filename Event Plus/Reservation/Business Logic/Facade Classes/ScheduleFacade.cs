
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class ScheduleFacade
    {

		ScheduleDAO oScheduleDAO;
        public ScheduleFacade()
        {
			oScheduleDAO = new ScheduleDAO();
        }

        public Schedule GetSchedule(string FolioID)
        {
			Schedule mySched = oScheduleDAO.GetSchedule(FolioID);

			DataTable _tempData = mySched.Tables[0];
			DataRow _dtRow = _tempData.Rows[0];

			mySched.FolioID = _dtRow["FolioId"].ToString();
			mySched.RoomID = _dtRow["RoomID"].ToString();
			mySched.RoomType = _dtRow["RoomType"].ToString();
			mySched.FromDate = DateTime.Parse( _dtRow["FROMDATE"].ToString() );
			mySched.ToDate = DateTime.Parse( _dtRow["TODATE"].ToString() );
			
			mySched.RateType = _dtRow["RATETYPE"].ToString();
			mySched.Rate = decimal.Parse( _dtRow["RATE"].ToString() );
			mySched.BreakFast = _dtRow["BREAKFAST"].ToString();

            //mySched.HasTransfered = int.Parse(_dtRow["hasTransfered"].ToString());

			return mySched;
        }


        public void InsertFolioSchedule(Schedule poSchedule, string _eventType, ref MySqlTransaction poTrans)
        {
			
			try
			{
				// create room events
				RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

				int ctr = 0;
				int loopEnd = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, poSchedule.FromDate, poSchedule.ToDate);
				for (int d = 0; d <= loopEnd; d++)
				{
					RoomEvents _newRoomEvent = new RoomEvents();

					_newRoomEvent.RoomID = poSchedule.RoomID;
					_newRoomEvent.Eventid = poSchedule.FolioID;
					_newRoomEvent.EventType = _eventType;

					if (poSchedule.RateType != "")
					{
						//added to avoid charging in the last date of stay
						if (d == loopEnd)
						{
							_newRoomEvent.RoomRate = 0;
							_newRoomEvent.TransferFlag = 1;
						}
						else
						{
							_newRoomEvent.RoomRate = poSchedule.Rate;
						}
					}
					else
					{
						_newRoomEvent.RoomRate = 0;
					}

					if (poSchedule.StartTime != null)
					{
						_newRoomEvent.StartEventTime = poSchedule.StartTime;
					}
					else
					{
						_newRoomEvent.StartEventTime = DateTime.Parse("00:00:00");
					}

                    if (poSchedule.EndTime != null)
                    {
                        _newRoomEvent.EndEventTime = poSchedule.EndTime;
                    }
                    else
                    {
                        _newRoomEvent.EndEventTime = DateTime.Parse("00:00:00");
                    }

					_newRoomEvent.EventDate = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", poSchedule.FromDate.AddDays(ctr)));
					_oRoomEventFacade.saveRoomEvent(_newRoomEvent, ref poTrans);

					ctr++;
				}


				oScheduleDAO.saveSchedule(poSchedule, ref poTrans);

			}
			catch (Exception ex)
			{
				throw (ex);
			}

        }
        public void DeleteFolioSchedule(Schedule oSchedule)
        {
            oScheduleDAO.DeleteSchedule(oSchedule);
        }

        public void deleteAllFolioSchedules(string pFolioId, ref MySqlTransaction poDBTransaction)
        {

			oScheduleDAO.deleteFolioSchedules(pFolioId, ref poDBTransaction);

			// delete roomevents here
			//RoomEventFacade oRoomEventFacade = new RoomEventFacade();
			//oRoomEventFacade.deleteAllFolioRoomEvents(pFolioId, ref poDBTransaction);

        }

        public void deActivateFolioSchedules(string pFolioId, int pHotelID ,ref MySqlTransaction poDBTransaction)
        {
            oScheduleDAO.deActivateFolioSchedules(pFolioId, pHotelID, ref poDBTransaction);

            RoomEventFacade oRoomEventFacade = new RoomEventFacade();
            oRoomEventFacade.deleteAllFolioRoomEvents(pFolioId, ref poDBTransaction);
        }

        public void SetType(ref Schedule oSchedule)
        {
            oScheduleDAO.SetType(oSchedule);
        }


        public string GetRoomFromSchedules(string folioID)
        {
            return oScheduleDAO.GetRoomFromSchedules(folioID);
        }

        public string GetRoomAndRoomTypeFromSchedules(string folioID)
        {
            return oScheduleDAO.GetRoomAndRoomtypeFromSchedules(folioID);
        }

        public DataTable GetRoomSchedulesForHistory(string folioID)
        {
            return oScheduleDAO.GetRoomSchedulesForHistory(folioID);
        }
        public DataTable GetRoomEventForHistory(string folioID)
        {
            return oScheduleDAO.GetRoomEventForHistory(folioID);
        }
        public int GetNoOfDays(string folioID)
        {
            return (oScheduleDAO.GetNoOfDays(folioID));
        }
        public DateTime GetStartDAy(string folioID)
        {
            return oScheduleDAO.GetStartDay(folioID);
        }

        public DateTime GetEndDay(DateTime Start, string folioID)
        {
            return GetStartDAy(folioID).AddDays( GetNoOfDays(folioID) - 1) ;
        }
        public decimal GetAmountFromSchedule(string folioID)
        {
            return oScheduleDAO.GetAmountFromSchedule(folioID);
        }

        public void UpdateFolioSchedules(Schedule oschedule)
        {
            oScheduleDAO.UpdateFolioSchedules(oschedule);
        }
        public void ReSetFolioSchedule(DateTime checkOutDate, string folioID)
        {
            oScheduleDAO.ReSetFolioSchedule(checkOutDate, folioID);
        }
        public string GetGuest(string AccountID)
        {
            return oScheduleDAO.getGuest(AccountID);
        }

        public bool setScheduleEarlyCheckOut(string a_FolioId, string a_RoomId)
        {
            return oScheduleDAO.setScheduleEarlyCheckOut(a_FolioId, a_RoomId);
        }



		/// <summary>
		/// Gets Folio Schedules
		/// </summary>
		/// <param name="pFolioId">Folio No. to query schedule</param>
		/// <returns>List of Folio Schedules</returns>
		public IList<Schedule> getFolioScheduleList(string pFolioId)
		{
			IList<Schedule> _oScheduleList = new List<Schedule>();
			Schedule _oSchedule = oScheduleDAO.GetSchedule(pFolioId);

			DataTable _tempDtSchedule = _oSchedule.Tables[0];

			foreach (DataRow _dRow in _tempDtSchedule.Rows)
			{
				Schedule _oSched = new Schedule();

				_oSched.HotelID = int.Parse( _dRow["hotelID"].ToString() );
				_oSched.FolioID = _dRow["folioID"].ToString();
				_oSched.RoomID = _dRow["roomID"].ToString();
				_oSched.FromDate = DateTime.Parse( _dRow["fromDate"].ToString() );
				_oSched.ToDate = DateTime.Parse( _dRow["toDate"].ToString() );
				_oSched.RateType = _dRow["rateType"].ToString();
				_oSched.RoomType = _dRow["roomType"].ToString();
				_oSched.Rate = decimal.Parse( _dRow["rate"].ToString() );
				_oSched.BreakFast = _dRow["breakFast"].ToString();
				_oSched.CreateTime = DateTime.Parse( _dRow["createTime"].ToString() );
				_oSched.CreatedBy = _dRow["createdBy"].ToString();
				_oSched.UpdateTime = DateTime.Parse( _dRow["updateTime"].ToString() );
				_oSched.UpdatedBy = _dRow["updatedBy"].ToString();
                _oSched.StartTime = DateTime.Parse(_dRow["startTime"].ToString());
                _oSched.EndTime = DateTime.Parse(_dRow["endTime"].ToString());
                _oSched.Remarks = _dRow["remarks"].ToString();
                _oSched.Activity = _dRow["activity"].ToString();
                _oSched.Venue = _dRow["venue"].ToString();
                _oSched.Setup = _dRow["setup"].ToString();
                //Kevin Oliveros 2014-01-24
                //_oSched.EVENT_SETUP_START = _dRow["SetUpStart"].ToString();
                //_oSched.EVENT_SETUP_END = _dRow["SetUpEnd"].ToString();
                //_oSched.HasTransfered = int.Parse(_dRow["hasTransfered"].ToString());

                /* FP-SCR-00140 #1 [07.23.2010]
                 * added for additional field GuaranteedPax */
                _oSched.GuaranteedPax = _dRow["GuaranteedPax"].ToString();
                _oSched.Id = _dRow["id"].ToString();
				_oScheduleList.Add(_oSched);
			}

			return _oScheduleList;
		}

    }
}