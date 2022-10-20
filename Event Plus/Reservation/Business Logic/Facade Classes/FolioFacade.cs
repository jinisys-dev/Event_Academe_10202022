
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
	public class FolioFacade
	{

		public FolioFacade()
		{
		}


		private FolioDAO loFolioDAO;

        public int getTotalInHouseGuests()
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getTotalInHouseGuests();
        }

        public int getTotalGroupWaitList()
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getTotalGroupWaitList();
        }

		public DataTable GetCompanyPrivileges(string CompanyID)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetCompanyPrivileges(CompanyID);
		}

		public void DeleteFolioRouting(string folioID)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.DeleteFolioRouting(folioID);
		}

        public bool guestIsCheckedIn(string pAccountID, string pRoomNo)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.guestIsCheckedIn(pAccountID, pRoomNo);
        }

		public string getPackagName(string packageID)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getPackageName(packageID);
		}

		public DataTable GetRoutingDetails(string folioID, string trancode)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetRoutingDetails(folioID, trancode);
		}
		public DataTable GetGuestPrivileges(string accountid)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetGuestPrivileges(accountid);
		}
		public void DeleteFolioRouting(string folioId, string TranCode)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.DeleteFolioRouting(folioId, TranCode);
		}
		public bool RemovePackage(string folioid)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.RemovePackage(folioid);
		}

		public bool DeleteFolioPackage(string folioid)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.DeleteFolioPackage(folioid);
		}


		public Folio GetFolio(string pFolioId)
		{
			GuestFacade _oGuestFacade = new GuestFacade();

			loFolioDAO = new FolioDAO();

			Folio oFolio = loFolioDAO.GetFolio(pFolioId);

            if (oFolio != null)
            {
                oFolio.Guest = _oGuestFacade.getGuestRecord(oFolio.AccountID);

                oFolio.Package = loFolioDAO.GetFolioPackage(oFolio.FolioID);
                oFolio.Privileges = loFolioDAO.GetFolioPrivileges(oFolio.FolioID);
                oFolio.RecurringCharges = loFolioDAO.getFolioRecurringCharges(pFolioId);
                oFolio.FolioRouting = loFolioDAO.getFolioBillRouting(oFolio.FolioID);
                oFolio.Inclusions = loFolioDAO.GetFolioInclusions(oFolio.FolioID);
                //ContactPerson oContactPerson = new ContactPerson();
                //oFolio.ContactPersons = oContactPerson.getContactPersons(oFolio.FolioID, GlobalVariables.gHotelId, oFolio.CompanyID);
                EventContact oContactPerson = new EventContact();
                oFolio.ContactPersons = oContactPerson.getEventContacts(oFolio.FolioID, oFolio.CompanyID);
                EventOfficer oEventOfficer = new EventOfficer();
                oFolio.EventOfficers = oEventOfficer.getEventOfficers(oFolio.FolioID, GlobalVariables.gHotelId.ToString());
                EventEndorsement oEventEndorsement = new EventEndorsement(oFolio.FolioID, GlobalVariables.gHotelId);
                oFolio.EventEndorsement = oEventEndorsement;
                EventAttendance oEventAttendance = new EventAttendance(oFolio.FolioID, GlobalVariables.gHotelId);
                oFolio.EventAttendance = oEventAttendance;
                IncumbentOfficer oIncumbentOfficer = new IncumbentOfficer();
                oFolio.IncumbentOfficers = oIncumbentOfficer.getIncumbentOfficers(oFolio.FolioID, GlobalVariables.gHotelId.ToString());

                oFolio.CreateSubFolio();
                foreach (SubFolio oSubFolio in oFolio.SubFolios)
                {
                    oSubFolio.Ledger = loFolioDAO.GetFolioLedger(oFolio.FolioID, oSubFolio.SubFolio_Renamed);
                    oSubFolio.FolioTransactions = loFolioDAO.GetFolioTransactions(oFolio.FolioID, oSubFolio.SubFolio_Renamed);
                }

                // loads folio schedules
                ScheduleFacade _oScheduleFacade = new ScheduleFacade();
                oFolio.Schedule = _oScheduleFacade.getFolioScheduleList(pFolioId);

                // load dependent Folios
                oFolio.JoinerFolios = this.getJoinerFolios(pFolioId);
            }			
			
			return oFolio;
		}

		public Folio GetFolioBasicInfo(string pFolioId)
		{

			loFolioDAO = new FolioDAO();

			Folio oFolio = loFolioDAO.GetFolio(pFolioId);

			return oFolio;
		}


		public void SetChildFolioStatus(string masterfolio, string mStatus, string mReason)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SetChildFolioStatus(masterfolio, mStatus, mReason);
		}

		public void SaveFolio(Folio poFolio)
		{
			loFolioDAO = new FolioDAO();
			MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction() ;

			try
			{
				// eventtype for ROOM EVENTS table
				string _eventType = "";
				switch (poFolio.Status)
				{
					case "CONFIRMED":
					case "TENTATIVE":
						_eventType = "RESERVATION";
						break;
					case "ONGOING":
						_eventType = "IN HOUSE";
						break;
					default:
						_eventType = "RESERVATION";
						break;
				}

				// create folio ledgers
				poFolio.CreateSubFolio();
				loFolioDAO.saveNewFolio(poFolio, ref _oTrans);

				// extracted here since we will be creating Room Events as per Schedule
				// which is a Business Layer function
                if (!(poFolio.Schedule == null || poFolio.Schedule.Count == 0))
                {
                    //ScheduleFacade oScheduleFacade = new ScheduleFacade();
					ScheduleDAO oScheduleDAO = new ScheduleDAO();

					int _scheduleCtr = 0;
					int _scheduleCount = poFolio.Schedule.Count - 1;
					
                    foreach (Schedule _oSchedule in poFolio.Schedule)
                    {
                        //oScheduleFacade.InsertFolioSchedule(_oSchedule, _eventType, ref _oTrans);

						try
						{
							// create room events
							RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

							int ctr = 0;
							int loopEnd = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oSchedule.FromDate, _oSchedule.ToDate);
							for (int d = 0; d <= loopEnd; d++)
							{
								RoomEvents _newRoomEvent = new RoomEvents();

								_newRoomEvent.RoomID = _oSchedule.RoomID;
								_newRoomEvent.Eventid = _oSchedule.FolioID;
								_newRoomEvent.EventType = _eventType;

								if (_oSchedule.RateType != "")
								{
									//added to avoid charging in the last date of stay
									if (d == loopEnd)
									{
										_newRoomEvent.RoomRate = 0;
										
										// set TRANSFER FLAG = 1 if has more
										// than 1 schedule
										if (_scheduleCount > _scheduleCtr)
										{
											if (_newRoomEvent.RoomID != poFolio.Schedule[_scheduleCtr + 1].RoomID)
											{
                                                if (poFolio.Schedule[_scheduleCtr].ToDate == poFolio.Schedule[_scheduleCtr + 1].FromDate)
												    _newRoomEvent.TransferFlag = 1;
											}
										} // end if

									} // end if
									else
									{
										_newRoomEvent.RoomRate = _oSchedule.Rate;
									} // end else

								}// end if
								else
								{
									_newRoomEvent.RoomRate = 0;
								}// end else

								if (_oSchedule.StartTime != null)
								{
									_newRoomEvent.StartEventTime = _oSchedule.StartTime;
								}
								else
								{
									_newRoomEvent.StartEventTime = DateTime.Parse("00:00:00");
								}

								if (_oSchedule.EndTime != null)
								{
									_newRoomEvent.EndEventTime = _oSchedule.EndTime;
								}
								else
								{
									_newRoomEvent.EndEventTime = DateTime.Parse("00:00:00");
								}

								_newRoomEvent.EventDate = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", _oSchedule.FromDate.AddDays(ctr)));
								_oRoomEventFacade.saveRoomEvent(_newRoomEvent, ref _oTrans);

								ctr++;
							}// end for

                            // remove blocking if dependent
                            if (poFolio.FolioType == "DEPENDENT")
                            {
                                RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();
                                oRoomBlockFacade.deleteRoomBlockedByEvent(_oSchedule.RoomID, poFolio.MasterFolio, ref _oTrans);
                            }

							oScheduleDAO.saveSchedule(_oSchedule, ref _oTrans);


							//if QUICK CHECK-IN
							if (poFolio.Status == "ONGOING")
							{
								if (_scheduleCtr == 0)
								{
									RoomFacade _oRoomFacade = new RoomFacade();
									_oRoomFacade.setRoomStatus(_oSchedule.RoomID, "OCCUPIED", ref _oTrans);
								}
							}

						}// end try
						catch (Exception ex)
						{
							throw (ex);
						} // end catch

						_scheduleCtr++;

                    } // end for each

                } // end if

				// insert all Joiner Folio
                if (!(poFolio.JoinerFolios == null || poFolio.JoinerFolios.Count == 0))
                {
                    foreach (Folio _oJoinerFolio in poFolio.JoinerFolios)
                    {
                        loFolioDAO.saveNewFolio(_oJoinerFolio, ref _oTrans);
                    }
                }

				

				_oTrans.Commit();
			}
			catch (Exception ex)
			{
				_oTrans.Rollback();
				throw ex;
			}
		}

        public void SaveFolio(Folio poFolio, ref MySql.Data.MySqlClient.MySqlTransaction _oTrans)
        {
            loFolioDAO = new FolioDAO();
            try
            {
                // eventtype for ROOM EVENTS table
                string _eventType = "";
                switch (poFolio.Status)
                {
                    case "CONFIRMED":
                    case "TENTATIVE":
                        _eventType = "RESERVATION";
                        break;
                    case "ONGOING":
                        _eventType = "IN HOUSE";
                        break;
                    default:
                        _eventType = "RESERVATION";
                        break;
                }
                // create folio ledgers
                poFolio.CreateSubFolio();
                loFolioDAO.saveNewFolio(poFolio, ref _oTrans);

                // extracted here since we will be creating Room Events as per Schedule
                // which is a Business Layer function
                if (!(poFolio.Schedule == null || poFolio.Schedule.Count == 0))
                {
                    //ScheduleFacade oScheduleFacade = new ScheduleFacade();
                    ScheduleDAO oScheduleDAO = new ScheduleDAO();

                    int _scheduleCtr = 0;
                    int _scheduleCount = poFolio.Schedule.Count - 1;

                    foreach (Schedule _oSchedule in poFolio.Schedule)
                    {
                        //oScheduleFacade.InsertFolioSchedule(_oSchedule, _eventType, ref _oTrans);
                        try
                        {
                            // create room events
                            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

                            int ctr = 0;
                            int loopEnd = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oSchedule.FromDate, _oSchedule.ToDate);
                            for (int d = 0; d <= loopEnd; d++)
                            {
                                RoomEvents _newRoomEvent = new RoomEvents();

                                _newRoomEvent.RoomID = _oSchedule.RoomID;
                                _newRoomEvent.Eventid = _oSchedule.FolioID;
                                _newRoomEvent.EventType = _eventType;

                                if (_oSchedule.RateType != "")
                                {
                                    //added to avoid charging in the last date of stay
                                    if (d == loopEnd)
                                    {
                                        _newRoomEvent.RoomRate = 0;

                                        // set TRANSFER FLAG = 1 if has more
                                        // than 1 schedule
                                        if (_scheduleCount > _scheduleCtr)
                                        {
                                            if (_newRoomEvent.RoomID != poFolio.Schedule[_scheduleCtr + 1].RoomID)
                                            {
                                                if(poFolio.Schedule[_scheduleCtr].ToDate == poFolio.Schedule[_scheduleCtr + 1].FromDate)
                                                    _newRoomEvent.TransferFlag = 1;
                                            }
                                        } // end if

                                    } // end if
                                    else
                                    {
                                        _newRoomEvent.RoomRate = _oSchedule.Rate;
                                    } // end else

                                }// end if
                                else
                                {
                                    _newRoomEvent.RoomRate = 0;
                                }// end else

                                if (_oSchedule.StartTime != null)
                                {
                                    _newRoomEvent.StartEventTime = _oSchedule.StartTime;
                                }
                                else
                                {
                                    _newRoomEvent.StartEventTime = DateTime.Parse("00:00:00");
                                }

                                if (_oSchedule.EndTime != null)
                                {
                                    _newRoomEvent.EndEventTime = _oSchedule.EndTime;
                                }
                                else
                                {
                                    _newRoomEvent.EndEventTime = DateTime.Parse("00:00:00");
                                }

                                _newRoomEvent.EventDate = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", _oSchedule.FromDate.AddDays(ctr)));
                                _oRoomEventFacade.saveRoomEvent(_newRoomEvent, ref _oTrans);

                                ctr++;
                            }// end for
                            
                            // remove blocking if dependent
                            if (poFolio.FolioType == "DEPENDENT")
                            {
                                RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();
                                oRoomBlockFacade.deleteRoomBlockedByEvent(_oSchedule.RoomID, poFolio.MasterFolio, ref _oTrans);
                            }

                            oScheduleDAO.saveSchedule(_oSchedule, ref _oTrans);


                            //if QUICK CHECK-IN
                            if (poFolio.Status == "ONGOING")
                            {
                                if (_scheduleCtr == 0)
                                {
                                    // RECHECK FOR setROOMSTATUS
                                    RoomFacade _oRoomFacade = new RoomFacade();
                                    _oRoomFacade.setRoomStatus(_oSchedule.RoomID, "OCCUPIED", ref _oTrans);
                                }
                            }

                        }// end try
                        catch (Exception ex)
                        {
                            throw (ex);
                        } // end catch

                        _scheduleCtr++;

                    } // end for each

                } // end if

                // insert all Joiner Folio
                if (!(poFolio.JoinerFolios == null || poFolio.JoinerFolios.Count == 0))
                {
                    foreach (Folio _oJoinerFolio in poFolio.JoinerFolios)
                    {
                        loFolioDAO.saveNewFolio(_oJoinerFolio, ref _oTrans);
                    }
                }

                if (poFolio.ContactPersons != null)
                {
                    foreach (EventContact _contactPerson in poFolio.ContactPersons)
                    {
                        if (_contactPerson.ContactID == "AUTO")
                        {
                            _contactPerson.save(ref _oTrans);
                        }
                        else
                        {
                            _contactPerson.update(ref _oTrans);
                        }
                    }
                }
                if (poFolio.EventOfficers != null)
                {
                    foreach (EventOfficer _eventOfficer in poFolio.EventOfficers)
                    {
                        _eventOfficer.save(ref _oTrans);
                    }
                }
                if (poFolio.IncumbentOfficers != null)
                {
                    foreach (IncumbentOfficer _incumbentOfficer in poFolio.IncumbentOfficers)
                    {
                        // RECHECK FOR save
                        _incumbentOfficer.save(ref _oTrans);
                    }
                }

                if (poFolio.EventEndorsement != null)
                {
                    poFolio.EventEndorsement.save(ref _oTrans);
                }
                if (poFolio.EventAttendance != null)
                {
                    poFolio.EventAttendance.save(ref _oTrans);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed.\r\nError in saving folio. Please check details\r\n\r\nError message : " + ex.Message);
            }
        }

		public void setActualArrival(string folioID)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.setActualArrival(folioID);
		}

		public DataTable GetChildFoliosTable(string masterfolio)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetChildFoliosTable(masterfolio);
		}

		public ChildFolios GetChildFolios(string masterfolio)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetChildFolios(masterfolio);
		}

		public void SaveGroupFolio(ref Folio oFolio)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SaveGroupFolio(oFolio);
		}

		public bool CheckStatusToCancel(string masterfolio)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.CheckStatusToCancel(masterfolio);
		}

		public void SetRoomStatusAftertoVacant(ref string folioid)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SetRoomStatusAftertoVacant(folioid);
		}

		public void DeleteFolio(string folioID)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.DeleteFolio(folioID);
		}

		public DataTable GetFolioHistory(string AccountID)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioHistory(AccountID);
		}

		public void SetMasterFolio(string masterfolio, string folioID)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SetMasterFolio(masterfolio, folioID);
		}

		public DataTable GetFolioLedgers(string accounttype)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioLedgers(accounttype);
		}

		public FolioTransactions GetFolioTransactions(string folioID, string subFolio)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioTransactions(folioID, subFolio);
		}

		public void setFolioStatus(string folioID, string status, string a_Reason)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SETfolioStatus(folioID, status, a_Reason);
		}

        public void setFolioStatus(string pFolioID, string pStatus, string pReason, string pReasonType, string pBookingType)
        {
            loFolioDAO = new FolioDAO();
            loFolioDAO.SETfolioStatus(pFolioID, pStatus, pReason);
            loFolioDAO.setReason(pFolioID, pReasonType, pBookingType);
        }

		public Folio GetFolioByRoomID(string RoomId)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolio(loFolioDAO.GetFolioIDByRoomID(RoomId));
		}

		// >> Used in: FolioLedgerUI.getIndividualFolio
		public string GetCurrentRoomOccupied(string folioID, string pType)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetCurrentRoomOccupied(folioID, pType).ToString();
		}

		public Folio GetGuestFolioInfo(string folioId)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetGuestFolioInfo(folioId);
		}

		public DataTable GetFolioRouting(string folioID)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioRouting(folioID);
		}

		public void SaveFolioRouting(FolioRouting oFolioRouting)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SaveFolioRouting(oFolioRouting);
		}

		public void SaveFolioRoutingCollection(FolioRoutingCollection oFolioRoutingCollection)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SaveFolioRoutingCollection(oFolioRoutingCollection);
		}

		public bool RemoveFolioRouting(Folio oFolio, ref MySqlTransaction pDBTransaction)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.RemoveFolioRouting(oFolio, ref pDBTransaction);
		}

		public object SaveFolioPackage(FolioPackage oFolioPackage)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.SaveFolioPackage(oFolioPackage);
		}

		public void DeleteFolioRecurringCharge(string folioId, string TranCode)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.DeleteFolioRecurringCharge(folioId, TranCode);
		}

        public void DeleteFolioRecurringCharges(string folioId)
        {
            loFolioDAO = new FolioDAO();
            loFolioDAO.DeleteFolioRecurringCharges(folioId);
        }

		public DataTable GetFolioRecurringCharge(string folioID)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioRecurringCharge(folioID);
		}

		public FolioTransactionLedger GetFolioLedger(string FolioID, string SubFolio)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioLedger(FolioID, SubFolio);
		}

		public void SaveFolioPackage(Folio oFolio)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SaveFolioPackage(oFolio);
		}

        public void SaveFolioInclusions(Folio oFolio)
        {
            loFolioDAO = new FolioDAO();
            loFolioDAO.SaveFolioInclusions(oFolio);
        }

		public void UpdateFolioPackage(string FolioID, string packageId)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.UpdateFolioPackage(FolioID, packageId);
		}

		public void UpdateStatus(string status, string folioid, string a_Reason)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.UpdateStatus(status, folioid, a_Reason);
		}

		public void UpdateStatusAndRemarks(string status, string folioid, string remarks)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.UpdateStatusAndRemarks(status, folioid, remarks);
		}

		public FolioPackage GetFolioTransPackage(string FolioID, string TranCode)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioTransPackage(FolioID, TranCode);
		}

		public FolioRoutingCollection GetFolioTransRouting(string FolioID, string TranCode)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioTransRouting(FolioID, TranCode);
		}

		public DataRow GetFolioTransPrivilege(ref FolioTransaction oFolioTrans)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.GetFolioTransPrivilege(oFolioTrans);
		}

		public void UpdateFolioLedger(string folioid, string subFolio, string accountId)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.UpdateFolioLedger(folioid, subFolio, accountId);
		}

		public bool RemoveRecurringCharge(RecurringCharge oRecurringCharge)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.RemoveRecurringCharge(oRecurringCharge);
		}

		public void SaveFolioRecurringCharges(Folio oFolio)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.SaveFolioRecurringCharges(oFolio);
		}

		public DataTable checkAvailableRoom(string roomid, string roomtype, string date)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.checkAvailableRoom(roomid, roomtype, date);
		}

		#region "APPLY PACKAGE,ROUTING,PRIVILEGES"

		// >> NEW 12-May-2006
		private FolioFacade oFolioFacade;
		private FolioPackage oPackage;
		public void ApplyFolioPackage(FolioTransaction oFolioTrans, TransactionCode tranCode, decimal baseAmount)
		{
			oPackage = new FolioPackage();
			try
			{
				oFolioFacade = new FolioFacade();
				oPackage = oFolioFacade.GetFolioTransPackage(oFolioTrans.FolioID, oFolioTrans.TransactionCode);

				if (!(oPackage == null))
				{
					FolioTransaction with_1 = oFolioTrans;
					with_1.BaseAmount = baseAmount; // >> changed

					if (oPackage.Basis == "A")
					{
						oFolioTrans.Discount = oPackage.AmountOff;
					}
					else
					{
						oFolioTrans.Discount = with_1.BaseAmount * oPackage.PercentOff;
					}

					with_1.BaseAmount = with_1.BaseAmount - with_1.Discount;

					with_1.GovernmentTax = tranCode.GovtTax;
					if (with_1.GovernmentTax > 0)
					{
						with_1.GovernmentTax = ComputeTaxSrvCharge((decimal)with_1.BaseAmount, (decimal)with_1.GovernmentTax);
					}

					with_1.LocalTax = tranCode.LocalTax;
					if (with_1.LocalTax > 0)
					{
						with_1.LocalTax = ComputeTaxSrvCharge((decimal)(with_1.BaseAmount - with_1.GovernmentTax), (decimal)with_1.LocalTax);
					}

					with_1.ServiceCharge = tranCode.ServiceCharge;
					if (with_1.ServiceCharge > 0)
					{
						with_1.ServiceCharge = ComputeTaxSrvCharge((decimal)(with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax), (decimal)with_1.ServiceCharge);
					}

					with_1.NetBaseAmount = with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax - with_1.ServiceCharge;

				}
			}
			catch (Exception)
			{
				MessageBox.Show("No Package was applied..", "Hotel Package");
			}
		}

		private FolioRoutingCollection oFolioRoutingCollection;
		public FolioTransactions ApplyFolioRouting(FolioTransaction oFTrans, Folio oFolio)
		{
			FolioTransactions oFolioTransCollection = new FolioTransactions();
			oFolioRoutingCollection = new FolioRoutingCollection();
			oFolioRoutingCollection = GetFolioTransRouting(oFTrans.FolioID, oFTrans.TransactionCode);

			FolioRouting oRouting;
			foreach (FolioRouting tempLoopVar_oRouting in oFolioRoutingCollection)
			{
				oRouting = tempLoopVar_oRouting;
				FolioTransaction oFolioTrans = new FolioTransaction();
				oFolioTrans.HotelID = oFTrans.HotelID;
				oFolioTrans.FolioID = oFolio.FolioID;
				oFolioTrans.AccountID = oFolio.AccountID;
				oFolioTrans.TransactionCode = oFTrans.TransactionCode;
				oFolioTrans.ReferenceNo = oFTrans.ReferenceNo;
				oFolioTrans.Memo = oFTrans.Memo;
				oFolioTrans.AcctSide = oFTrans.AcctSide;
				oFolioTrans.CurrencyCode = oFTrans.CurrencyCode;
				oFolioTrans.ConversionRate = oFTrans.ConversionRate;
				oFolioTrans.CurrencyAmount = oFTrans.CurrencyAmount;
				oFolioTrans.BaseAmount = oFTrans.BaseAmount;
				oFolioTrans.Discount = oFTrans.Discount;

				oFolioTrans.GovernmentTax = oFTrans.GovernmentTax;
				oFolioTrans.LocalTax = oFTrans.LocalTax;
				oFolioTrans.ServiceCharge = oFTrans.ServiceCharge;

				oFolioTrans.NetBaseAmount = oFTrans.NetBaseAmount;
				oFolioTrans.TerminalID = oFTrans.TerminalID;
				oFolioTrans.CreatedBy = oFTrans.CreatedBy;

				// -- changed --------------------------
				oFolioTrans.SubFolio = oRouting.SubFolio;
				if (oFolioTrans.SubFolio == "B")
				{
					oFolioTrans.AccountID = oFolio.CompanyID;
					oFolioTrans.FolioID = oFolio.MasterFolio;
					oFolioTrans.SubFolio = "A";
					oFolioTrans.SourceFolio = oFolio.FolioID;
					oFolioTrans.SourceSubFolio = "B";
					oFolioTrans.Discount = oFolioTrans.Discount;
				}
				else
				{
					oFolioTrans.AccountID = oFolio.AccountID;
					if (oFolio.MasterFolio != "")
					{
						oFolioTrans.Discount = 0;
					}
					else
					{
						oFolioTrans.Discount = oFolioTrans.Discount;
					}
				}

				oFolioTrans.CurrencyAmount = oFolioTrans.CurrencyAmount * oRouting.PercentCharged;
				oFolioTrans.BaseAmount = oFolioTrans.BaseAmount * oRouting.PercentCharged;

				oFolioTrans.GovernmentTax = oFolioTrans.GovernmentTax * oRouting.PercentCharged;
				oFolioTrans.LocalTax = oFolioTrans.LocalTax * oRouting.PercentCharged;
				oFolioTrans.ServiceCharge = oFolioTrans.ServiceCharge * oRouting.PercentCharged;
				oFolioTrans.NetBaseAmount = oFolioTrans.NetBaseAmount * oRouting.PercentCharged;

				oFolioTransCollection.Add(oFolioTrans);
			}
			return oFolioTransCollection;
		}

		public void ApplyFolioPrivileges(FolioTransaction oFolioTrans, FolioTransactions oFolioTransCollection, TransactionCode tranCode)
		{

			if (oFolioTransCollection.Count == 0)
			{
				oFolioTransCollection.Add(oFolioTrans);
			}

			FolioTransaction fTrans;
			foreach (FolioTransaction tempLoopVar_fTrans in oFolioTransCollection)
			{
				fTrans = tempLoopVar_fTrans;

				DataRow dtPrivileges; //= IIf(IsNothing(), Nothing, loFolioFacade.GetFolioPrivilege(fTrans))
				dtPrivileges = oFolioFacade.GetFolioTransPrivilege(ref fTrans);

				if (!(dtPrivileges == null))
				{
					if (!(dtPrivileges == null))
					{
						decimal disc;
						if (dtPrivileges["Basis"].ToString() == "A")
						{
							disc = decimal.Parse(dtPrivileges["AmountOff"].ToString());
						}
						else
						{
							disc = (decimal)fTrans.BaseAmount * decimal.Parse(dtPrivileges["PercentOff"].ToString());
						}

						fTrans.BaseAmount = fTrans.BaseAmount - disc;
						fTrans.Discount += disc;

						fTrans.GovernmentTax = tranCode.GovtTax;
						if (fTrans.GovernmentTax > 0)
						{
							fTrans.GovernmentTax = ComputeTaxSrvCharge((decimal)fTrans.BaseAmount, (decimal)fTrans.GovernmentTax);
						}

						fTrans.LocalTax = tranCode.LocalTax;
						if (fTrans.LocalTax > 0)
						{
							fTrans.LocalTax = ComputeTaxSrvCharge((decimal)(fTrans.BaseAmount - fTrans.GovernmentTax), (decimal)fTrans.LocalTax);
						}

						fTrans.ServiceCharge = tranCode.ServiceCharge;
						if (fTrans.ServiceCharge > 0)
						{
							fTrans.ServiceCharge = ComputeTaxSrvCharge((decimal)(fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax), (decimal)fTrans.ServiceCharge);
						}

						fTrans.NetBaseAmount = fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax - fTrans.ServiceCharge;

					}
				}
			}

			//Catch ex As Exception
			//    MsgBox("No Privilege was applied..")
			//End Try
		}

		private decimal ComputeTaxSrvCharge(decimal BaseAmount, decimal Tax)
		{
			decimal TaxAmount;

			TaxAmount = BaseAmount * Tax;

			return TaxAmount;
		}
		#endregion

		public DataTable getRoomHistory()
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getRoomHistory();
		}

        public DataTable getEngineeringJobsHistory()
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getEngineeringJobsHistory();
        }

		// SCR-00101 Page 6, #39
		// ADDED by: Jerome, April 17, 2008
		// Function: Get Housekeeper History
		public DataTable getRoomHousekeeperHistory()
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getRoomHousekeeperHistory();
		}
		//end SCR-00101 Page 6, #39

		public DataTable getGuestForToolTip()
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getGuestForToolTip();
		}


		public DataTable getGuestForToolTipCalendar()
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getGuestForToolTipCalendar();
		}

		public DataTable getCompanyFoliosForToolTip()
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getCompanyFoliosForToolTip();
		}

		public DataTable getRoomBlocksForToolTip()
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getRoomBlocksForToolTip();
		}


		public string getRoomCleaningStatus(string a_RoomId)
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getRoomCleaningStatus(a_RoomId);
		}

        public string getRoomOccupancyStatus(string a_RoomId)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getRoomOccupancyStatus(a_RoomId);
        }

        public string getRoomReservationStatus(string pRoomID, string pDate)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getRoomReservationStatus(pRoomID, pDate);
        }

		public ArrayList getRateTypesForInquiry()
		{
			loFolioDAO = new FolioDAO();
			ArrayList arrRateTypes = new ArrayList();

			DataTable dtRateTypes = loFolioDAO.getRateTypesForInquiry();

			foreach (DataRow dRow in dtRateTypes.Rows)
			{
				arrRateTypes.Add(dRow);
			}

			return arrRateTypes;
		}

		public IList<Folio> getJoinerFolios(string a_MasterFolioId)
		{
			IList<Folio> _oJoinerFolioList = new List<Folio>();

			loFolioDAO = new FolioDAO();
			DataTable _dtJoinerFolio = loFolioDAO.getJoinerFolios(a_MasterFolioId);

			GuestFacade _oGuestFacade = new GuestFacade();

			foreach (DataRow _dRow in _dtJoinerFolio.Rows)
			{
				Folio _oJoinerFolio = new Folio();


				_oJoinerFolio.FolioID = _dRow["FolioID"].ToString();
				_oJoinerFolio.AccountID = _dRow["AccountID"].ToString();
				_oJoinerFolio.FolioType = _dRow["FolioType"].ToString();
				_oJoinerFolio.GroupName = _dRow["GroupName"].ToString();
				_oJoinerFolio.AccountType = _dRow["AccountType"].ToString();
				_oJoinerFolio.NoOfChild = int.Parse( _dRow["NoOfChild"].ToString() );
				_oJoinerFolio.NoofAdults = int.Parse( _dRow["NoofAdults"].ToString() );
				_oJoinerFolio.MasterFolio = _dRow["MasterFolio"].ToString();
				_oJoinerFolio.CompanyID = _dRow["CompanyID"].ToString();
				_oJoinerFolio.AgentID = _dRow["AgentID"].ToString();
				_oJoinerFolio.Source = _dRow["Source"].ToString();
				_oJoinerFolio.FromDate = DateTime.Parse( _dRow["FromDate"].ToString() );
				_oJoinerFolio.Todate = DateTime.Parse( _dRow["Todate"].ToString() );
				_oJoinerFolio.ArrivalDate = DateTime.Parse( _dRow["ArrivalDate"].ToString() );
				_oJoinerFolio.DepartureDate = DateTime.Parse( _dRow["DepartureDate"].ToString() );
				_oJoinerFolio.PackageID = _dRow["PackageID"].ToString();
				_oJoinerFolio.Status = _dRow["Status"].ToString();
				_oJoinerFolio.Remarks = _dRow["Remarks"].ToString();
				_oJoinerFolio.Sales_Executive = _dRow["Sales_Executive"].ToString();
				_oJoinerFolio.Payment_Mode = _dRow["Payment_Mode"].ToString();
				_oJoinerFolio.Purpose = _dRow["Purpose"].ToString();
				_oJoinerFolio.REASON_FOR_CANCEL = _dRow["REASON_FOR_CANCEL"].ToString();
                _oJoinerFolio.UpdateTime = DateTime.Parse(_dRow["updateTime"].ToString());

				_oJoinerFolio.Guest = _oGuestFacade.getGuestRecord(_oJoinerFolio.AccountID);

				//_oJoinerFolio.Company = _dRow["FolioID"].ToString();



				_oJoinerFolioList.Add(_oJoinerFolio);


			}

			return _oJoinerFolioList;
		}

		public void updateJoinerAllFolioStatus(string a_Status, string a_MasterFolioId)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.updateJoinerAllFolioStatus(a_Status, a_MasterFolioId);
		}

		public void updateJoinerFolioStatus(string a_Status, string a_MasterFolioId, string a_FolioId)
		{
			loFolioDAO = new FolioDAO();
			loFolioDAO.updateJoinerFolioStatus(a_Status, a_MasterFolioId, a_FolioId);
		}

		/// <summary>
		/// Sets folio as ONGOING
		/// </summary>
		/// <param name="poFolioId">Folio ID to check in</param>
		/// <returns></returns>
		public bool checkInFolio(string pFolioId, string pRoomNo)
		{
			MySqlTransaction poDBTransaction = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);

			try
			{
				RoomFacade _oRoomFacade = new RoomFacade();
				ScheduleFacade _oScheduleFacade = new ScheduleFacade();
				RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

				loFolioDAO = new FolioDAO();
				Folio _oFolio = new Folio();

				// gets Folio information
				_oFolio = this.GetFolio(pFolioId);

				// check if use default guest
				if (_oFolio.AccountID == ConfigVariables.gDefault_Guest)
				{
					throw new Exception("Invalid Guest Account. Please input a valid guest name.");
				}

                //>> checks if room is vacant or occupied
                //>> throws exception if occupied
                string _roomOccupancyStatus = this.getRoomOccupancyStatus(pRoomNo);
                //if (_roomOccupancyStatus == "OCCUPIED")
                if (_roomOccupancyStatus == "OCCUPIED" && _oFolio.FolioType != "SHARE" && _oFolio.FolioType != "GROUP")
                {
                    throw (new Exception("Room is occupied"));
                }

				// checks Room Cleaning Status [ CLEAN / DIRTY ]
				// throws exception if Dirty
				string _roomCleaningStatus = "";
				_roomCleaningStatus = this.getRoomCleaningStatus(pRoomNo);

                if (_roomCleaningStatus == "DIRTY" && _oFolio.FolioType != "GROUP")
				{
					throw (new Exception("Room is dirty"));
				}

				// updates Folio Status to ONGOING
				loFolioDAO.updateFolioStatusToCheckedIn(_oFolio.FolioID, ref poDBTransaction);

				// updates All Joiner Folios' Status to ONGOING
				//DataTable joinerGuest = this.getJoinerFolios(_oFolio.FolioID);
				//foreach (DataRow joinerRow in joinerGuest.Rows)
				foreach(Folio _oJoinerFolio in _oFolio.JoinerFolios)
				{
					string _joinerFolioId = _oJoinerFolio.FolioID;

					loFolioDAO.updateJoinerFolioStatusToCheckedIn(_oFolio.FolioID, _joinerFolioId, ref poDBTransaction);
				}

				// updates RoomEvents
				foreach (Schedule _oSchedule in _oFolio.Schedule)
				{
					_oRoomEventFacade.UpdateRoomEvents("IN HOUSE", _oFolio.FolioID, _oSchedule.RoomID, ref poDBTransaction);
				}

				// updates Room Status
				_oRoomFacade.setRoomStatus(pRoomNo, "OCCUPIED", ref poDBTransaction);

				poDBTransaction.Commit();

				return true;
			}
			catch (Exception ex)
			{
				poDBTransaction.Rollback();

				throw ex;
			}
		}

		public bool cancelFolio(string pFolioId, string pReasonForCancel)
		{
			MySqlTransaction _oDBTransaction = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable );

			try
			{
				loFolioDAO = new FolioDAO();
				RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
				ScheduleFacade _oScheduleFacade = new ScheduleFacade();

				Folio oFolio = this.GetFolio(pFolioId);

				// checks Folio Balance
				bool hasBalance = false;
				oFolio.CreateSubFolio();
				decimal balance = 0;
				foreach (SubFolio subF in oFolio.SubFolios)
				{
					subF.Ledger = this.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
					balance = subF.Ledger.BalanceNet;
					if (balance != 0)
					{
						hasBalance = true;
					}
				}

				if (hasBalance)
				{
					throw (new Exception("Please settle guest account."));
				}

				//updates Folio Status to CANCELLED
				loFolioDAO.updateFolioStatusToCancelled(oFolio.FolioID, pReasonForCancel, ref _oDBTransaction);

				//updates RoomEvents to CANCELLED per Schedule
				IList<Schedule> _oScheduleList = _oScheduleFacade.getFolioScheduleList(oFolio.FolioID);
				foreach (Schedule _oSched in _oScheduleList)
				{
					_oRoomEventFacade.UpdateRoomEvents("CANCELLED", oFolio.FolioID, _oSched.RoomID, ref _oDBTransaction);
                }

                //>>for those rooms that are blocked by a group
                //>>if under a group, decrement the number of blocked rooms
                if (oFolio.FolioType == "DEPENDENT")
                {
                    try
                    {
                        EventRoomRequirementFacade _oRoomRequirementsFacade = new EventRoomRequirementFacade();
                        string roomType = _oScheduleList[0].RoomType;
                        _oRoomRequirementsFacade.updateNumberOfBlockedRooms(oFolio.MasterFolio, roomType, 1);
                    }
                    catch { }
                }

				// cancel all dependents
				try
				{
					this.updateJoinerAllFolioStatus("CANCELLED", oFolio.FolioID);
				}
				catch(Exception ex)
				{
					throw ex;
				}

				_oDBTransaction.Commit();
				return true;
			}
			catch (Exception ex)
			{
				_oDBTransaction.Rollback();
                MessageBox.Show("Failed to cancel folio. " + ex.Message, "Message", MessageBoxButtons.OK);
                return false;
			}
		}

		public bool noShowFolio(string pFolioId)
		{
			MySqlTransaction _oDBTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
			try
			{
				loFolioDAO = new FolioDAO();
				RoomFacade _oRoomFacade = new RoomFacade();
				RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
				ScheduleFacade _oScheduleFacade = new ScheduleFacade();

				Folio oFolio = this.GetFolio(pFolioId);

				// checks Folio Balance
				bool hasBalance = false;
				oFolio.CreateSubFolio();
				decimal balance = 0;
				foreach (SubFolio subF in oFolio.SubFolios)
				{
					subF.Ledger = this.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
					balance = subF.Ledger.BalanceNet;
					if (balance != 0)
					{
						hasBalance = true;
					}
				}

				if (hasBalance)
				{
					throw (new Exception("Please settle guest account."));
				}

				//updates Folio Status to CANCELLED
				loFolioDAO.updateFolioStatusToNoShow(oFolio.FolioID, ref _oDBTransaction);

				//updates RoomEvents to CANCELLED per Schedule
				IList<Schedule> _oScheduleList = _oScheduleFacade.getFolioScheduleList(oFolio.FolioID);
				foreach (Schedule _oSched in _oScheduleList)
				{
					_oRoomEventFacade.UpdateRoomEvents("NO SHOW", oFolio.FolioID, _oSched.RoomID, ref _oDBTransaction);
				}

				// cancel all dependents
				try
				{
                    oFolioFacade = new FolioFacade();
					oFolioFacade.updateJoinerAllFolioStatus("NO SHOW", oFolio.FolioID);
				}
				catch
				{
				}
				_oDBTransaction.Commit();

				return true;
			}
			catch (Exception ex)
			{
				_oDBTransaction.Rollback();
                MessageBox.Show("Failed to cancel folio. " + ex.Message, "Message", MessageBoxButtons.OK);
                return false;
            }
		}

		public bool confirmFolio(string pFolioId, ref MySqlTransaction poDBTransaction)
		{
			try
			{
				loFolioDAO = new FolioDAO();

                //updates Folio Status to CANCELLED
				loFolioDAO.updateFolioStatusToConfirmed(pFolioId, ref poDBTransaction);

                // update all dependents
				try
				{
					oFolioFacade.updateJoinerAllFolioStatus("CONFIRMED", pFolioId);
				}
				catch
				{
				}

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public bool tentativeFolio(string pFolioId, ref MySqlTransaction poDBTransaction)
        {
            try
            {
                loFolioDAO = new FolioDAO();

                //updates Folio Status to CANCELLED
                loFolioDAO.updateFolioStatusToTentative(pFolioId, ref poDBTransaction);

                // update all dependents
                try
                {
                    oFolioFacade.updateJoinerAllFolioStatus("TENTATIVE", pFolioId);
                }
                catch
                {
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setReferencNo(string pFolioID, int pMonth, int pYear, int pHotelID)
        {
            try
            {
                loFolioDAO = new FolioDAO();
                loFolioDAO.setReferenceNo(pFolioID, pMonth + "." + loFolioDAO.getReferenceNo(pFolioID, pMonth, pYear, pHotelID) + "." + pYear, pHotelID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioFacade.setReferenceNo\r\n" + ex.Message);
            }
        }

		public void updateFolio(Folio poFolio)
		{
			loFolioDAO = new FolioDAO();
			MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

			try
			{
				// eventtype for ROOM EVENTS table
				string _eventType = "";
				switch (poFolio.Status)
				{
					case "CONFIRMED":
					case "TENTATIVE":
						_eventType = "RESERVATION";
						break;
					case "ONGOING":
						_eventType = "IN HOUSE";
						break;
					default:
						_eventType = "RESERVATION";
						break;
				}

				loFolioDAO.updateFolio(poFolio, ref _oTrans);

				// extracted here since we will be creating Room Events as per Schedule
				// which is a Business Layer function
				ScheduleFacade oScheduleFacade = new ScheduleFacade();

                // gets its old schedule and updates the room's status to VACANT DIRTY 
                // IF FOLIO IS ONGOING
                if (poFolio.Status == "ONGOING")
                {
                    IList<Schedule> _oldSchedList;
                    _oldSchedList = oScheduleFacade.getFolioScheduleList(poFolio.FolioID);
                    string _roomID = "";
                    DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    foreach (Schedule _oldSched in _oldSchedList)
                    {
                        DateTime _startDate = _oldSched.FromDate;
                        DateTime _endDate = _oldSched.ToDate;

                        if (_auditDate >= _startDate && _auditDate <= _endDate)
                        {
                            //>>checks if there is another folio occupying the room for the day
                            if (!loFolioDAO.checkIfOtherFolioIsCheckedIn(poFolio.FolioID, _oldSched.RoomID, _auditDate.ToString("yyyy-MM-dd")))
                            {
                                RoomFacade _oRoomFacade = new RoomFacade();
                                _oRoomFacade.setRoomStatus(_oldSched.RoomID, "VACANT", ref _oTrans);
                                _roomID = _oldSched.RoomID;
                                break;
                            }
                        }
                    }

                    try
                    {
                        foreach (Schedule _oSched in poFolio.Schedule)
                        {
                            if (_auditDate >= _oSched.FromDate && _auditDate <= _oSched.ToDate)
                            {
                                if (poFolio.Status == "ONGOING" && _oSched.RoomID != _roomID)
                                {
                                    RoomFacade _oRoomFacade = new RoomFacade();
                                    _oRoomFacade.setRoomCleaningStatus(_roomID, "DIRTY", ref _oTrans);
                                }
                            }
                        }
                    }
                    catch { }
                }

				// delete current folioschedules 
				oScheduleFacade.deleteAllFolioSchedules(poFolio.FolioID, ref _oTrans);

				// extracted here since we will be creating Room Events as per Schedule
				// which is a Business Layer function
				if (!(poFolio.Schedule == null || poFolio.Schedule.Count == 0))
				{
					//ScheduleFacade oScheduleFacade = new ScheduleFacade();
					ScheduleDAO oScheduleDAO = new ScheduleDAO();

					int _scheduleCtr = 0;
					int _scheduleCount = poFolio.Schedule.Count - 1;

					foreach (Schedule _oSchedule in poFolio.Schedule)
					{
						//oScheduleFacade.InsertFolioSchedule(_oSchedule, _eventType, ref _oTrans);

						try
						{
							// create room events
							RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

							int ctr = 0;
							int loopEnd = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oSchedule.FromDate, _oSchedule.ToDate);
							for (int d = 0; d <= loopEnd; d++)
							{
								RoomEvents _newRoomEvent = new RoomEvents();

								_newRoomEvent.RoomID = _oSchedule.RoomID;
								_newRoomEvent.Eventid = _oSchedule.FolioID;
								_newRoomEvent.EventType = _eventType;

								if (_oSchedule.RateType != "")
								{
									//added to avoid charging in the last date of stay
									if (d == loopEnd)
									{
										_newRoomEvent.RoomRate = 0;

										// set TRANSFER FLAG = 1 if has more
										// than 1 schedule
										if ( _scheduleCount > _scheduleCtr )
										{
											if (_newRoomEvent.RoomID != poFolio.Schedule[_scheduleCtr + 1].RoomID)
											{
                                                if (poFolio.Schedule[_scheduleCtr].ToDate == poFolio.Schedule[_scheduleCtr + 1].FromDate)
												    _newRoomEvent.TransferFlag = 1;
											}
										} // end if

									} // end if
									else
									{
										_newRoomEvent.RoomRate = _oSchedule.Rate;
									} // end else

								}// end if
								else
								{
									_newRoomEvent.RoomRate = 0;
								}// end else

								if (_oSchedule.StartTime != null)
								{
									_newRoomEvent.StartEventTime = _oSchedule.StartTime;
								}
								else
								{
									_newRoomEvent.StartEventTime = DateTime.Parse("00:00:00");
								}

								if (_oSchedule.EndTime != null)
								{
									_newRoomEvent.EndEventTime = _oSchedule.EndTime;
								}
								else
								{
									_newRoomEvent.EndEventTime = DateTime.Parse("00:00:00");
								}

								_newRoomEvent.EventDate = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", _oSchedule.FromDate.AddDays(ctr)));
								_oRoomEventFacade.saveRoomEvent(_newRoomEvent, ref _oTrans);

								ctr++;
							}// end for

							oScheduleDAO.saveSchedule(_oSchedule, ref _oTrans);

						}// end try
						catch (Exception ex)
						{
							throw (ex);
						} // end catch

						_scheduleCtr++;
                        //updates room status to OCCUPIED if folio is ONGOING
                        if (poFolio.Status == "ONGOING")
                        {
                            if (_oSchedule.FromDate.Date <= DateTime.Parse(GlobalVariables.gAuditDate).Date && _oSchedule.ToDate.Date > DateTime.Parse(GlobalVariables.gAuditDate).Date)
                            {
                                RoomFacade _oRoomFacade = new RoomFacade();
                                _oRoomFacade.setRoomStatus(_oSchedule.RoomID, "OCCUPIED", ref _oTrans);
                            }
                            else
                            {
                                RoomFacade _oRoomFacade = new RoomFacade();
                                _oRoomFacade.setRoomStatus(_oSchedule.RoomID, "VACANT", ref _oTrans);
                            }
                        }

					} // end for each

				} // end if

				//// insert all Joiner Folio
				// update if existing

				// search From OLD JOINER FOLIOS
				// if not found then set as CANCELLED or CLOSED
				IList<Folio> _oOldJoinerFolios = this.getJoinerFolios(poFolio.FolioID);
				
				// add local copy of new joiner folios
				IList<Folio> _oNewJoinerFolios = new List<Folio>();
				if (poFolio.JoinerFolios != null)
				{
					foreach (Folio _tempFolio in poFolio.JoinerFolios)
					{
						_oNewJoinerFolios.Add(_tempFolio);
					}
				}


				if (_oOldJoinerFolios != null) //for joiner folio(no joiner)
				{
					if (_oOldJoinerFolios != null)
					{
						foreach (Folio temp_oOldFolio in _oOldJoinerFolios)
						{
							Folio _oOldFolio = temp_oOldFolio;

							bool found = false;

							foreach (Folio _oNewFolio in _oNewJoinerFolios)
							{
								if (_oNewFolio.FolioID == _oOldFolio.FolioID)
								{
									found = true;

									// overwrite Old joiner folio info
									_oOldFolio = _oNewFolio;

									// remove from current list since Found in OLD joiners
									_oNewJoinerFolios.Remove(_oNewFolio);
									break;
								}

							}

							if (!found)
							{
                                //if (_oOldFolio.Status == "ONGOING")
                                //{
                                //    _oOldFolio.Status = "CLOSED";
                                //}
                                //else
                                //{
									_oOldFolio.Status = "REMOVED";
                                //}
								//this.updateFolio(_oOldFolio);
							}

							// update folio
							this.updateFolio(_oOldFolio);

						}
					}
				}

				// save 
				if (_oNewJoinerFolios != null)
				{
					foreach (Folio _oJoinerFolio in _oNewJoinerFolios)
					{

						loFolioDAO.saveNewFolio(_oJoinerFolio, ref _oTrans);
					}
				}


				_oTrans.Commit();
			}
			catch (Exception ex)
			{
				_oTrans.Rollback();
				throw ex;
			}

		}


        public DataTable getSetUpTime(string pFolioId)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getSetUpTime(pFolioId);
            
        }


        public void updateFolio(Folio poFolio, ref MySqlTransaction _oTrans)
        {
            loFolioDAO = new FolioDAO();
            try
            {
                // eventtype for ROOM EVENTS table
                string _eventType = "";
                switch (poFolio.Status)
                {
                    case "CONFIRMED":
                    case "TENTATIVE":
                        _eventType = "RESERVATION";
                        break;
                    case "ONGOING":
                        _eventType = "IN HOUSE";
                        break;
                    default:
                        _eventType = "RESERVATION";
                        break;
                }

                loFolioDAO.updateFolio(poFolio, ref _oTrans);

                // extracted here since we will be creating Room Events as per Schedule
                // which is a Business Layer function
                ScheduleFacade oScheduleFacade = new ScheduleFacade();

                // gets its old schedule and updates the room's status to VACANT DIRTY 
                // IF FOLIO IS ONGOING
                if (poFolio.Status == "ONGOING")
                {
                    IList<Schedule> _oldSchedList;
                    _oldSchedList = oScheduleFacade.getFolioScheduleList(poFolio.FolioID);

                    string _roomID = "";
                    DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    foreach (Schedule _oldSched in _oldSchedList)
                    {
                        DateTime _startDate = _oldSched.FromDate;
                        DateTime _endDate = _oldSched.ToDate;

                        if (_auditDate >= _startDate && _auditDate <= _endDate)
                        {
                            RoomFacade _oRoomFacade = new RoomFacade();
                            _oRoomFacade.setRoomStatus(_oldSched.RoomID, "VACANT", ref _oTrans);
                            _roomID = _oldSched.RoomID;
                            break;
                        }
                    }

                    try
                    {
                        foreach (Schedule _oSched in poFolio.Schedule)
                         {
                            if (_auditDate >= _oSched.FromDate && _auditDate <= _oSched.ToDate)
                            {
                                if (poFolio.Status == "ONGOING" && _oSched.RoomID != _roomID)
                                {
                                    RoomFacade _oRoomFacade = new RoomFacade();
                                    _oRoomFacade.setRoomCleaningStatus(_roomID, "DIRTY", ref _oTrans);
                                }
                            }
                        }
                    }
                    catch { }
                }

                // extracted here since we will be creating Room Events as per Schedule
                // which is a Business Layer function
                if (!(poFolio.Schedule == null || poFolio.Schedule.Count == 0))
                {
                    // delete current folioschedules 
                    //oScheduleFacade.deleteAllFolioSchedules(poFolio.FolioID, ref _oTrans);
                    oScheduleFacade.deActivateFolioSchedules(poFolio.FolioID, GlobalVariables.gHotelId,ref _oTrans);
                    //ScheduleFacade oScheduleFacade = new ScheduleFacade();
                    ScheduleDAO oScheduleDAO = new ScheduleDAO();

                    int _scheduleCtr = 0;
                    int _scheduleCount = poFolio.Schedule.Count - 1;

                    foreach (Schedule _oSchedule in poFolio.Schedule)
                    {
                        //oScheduleFacade.InsertFolioSchedule(_oSchedule, _eventType, ref _oTrans);

                        try
                        {
                            // create room events
                            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

                            int ctr = 0;
                            int loopEnd = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _oSchedule.FromDate, _oSchedule.ToDate);
                            for (int d = 0; d <= loopEnd; d++)
                            {
                                RoomEvents _newRoomEvent = new RoomEvents();

                                _newRoomEvent.RoomID = _oSchedule.RoomID;
                                _newRoomEvent.Eventid = _oSchedule.FolioID;
                                _newRoomEvent.EventType = _eventType;

                                if (_oSchedule.RateType != "")
                                {
                                    //added to avoid charging in the last date of stay
                                    if (d == loopEnd)
                                    {
                                        _newRoomEvent.RoomRate = 0;

                                        // set TRANSFER FLAG = 1 if has more
                                        // than 1 schedule
                                        if (_scheduleCount > _scheduleCtr)
                                        {
                                            if (_newRoomEvent.RoomID != poFolio.Schedule[_scheduleCtr + 1].RoomID)
                                            {
                                                if (poFolio.Schedule[_scheduleCtr].ToDate == poFolio.Schedule[_scheduleCtr + 1].FromDate)
                                                    _newRoomEvent.TransferFlag = 1;
                                            }
                                        } // end if

                                    } // end if
                                    else
                                    {
                                        _newRoomEvent.RoomRate = _oSchedule.Rate;
                                    } // end else

                                }// end if
                                else
                                {
                                    _newRoomEvent.RoomRate = 0;
                                }// end else

                                if (_oSchedule.StartTime != null)
                                {
                                    _newRoomEvent.StartEventTime = _oSchedule.StartTime;
                                }
                                else
                                {
                                    _newRoomEvent.StartEventTime = DateTime.Parse("00:00:00");
                                }

                                if (_oSchedule.EndTime != null)
                                {
                                    _newRoomEvent.EndEventTime = _oSchedule.EndTime;
                                }
                                else
                                {
                                    _newRoomEvent.EndEventTime = DateTime.Parse("00:00:00");
                                }

                                _newRoomEvent.EventDate = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", _oSchedule.FromDate.AddDays(ctr)));
                                _oRoomEventFacade.saveRoomEvent(_newRoomEvent, ref _oTrans);

                                ctr++;
                            }// end for
                            if (_oSchedule.Id == "")
                            {
                                oScheduleDAO.saveSchedule(_oSchedule, ref _oTrans);
                            }
                            else
                            {
                                oScheduleDAO.updateSchedule(_oSchedule, ref _oTrans);
                            }
                            
                        }// end try
                        catch (Exception ex)
                        {
                            throw (ex);
                        } // end catch

                        _scheduleCtr++;
                        //updates room status to OCCUPIED if folio is ONGOING
                        if (poFolio.Status == "ONGOING")
                        {
                            RoomFacade _oRoomFacade = new RoomFacade();
                            _oRoomFacade.setRoomStatus(_oSchedule.RoomID, "OCCUPIED", ref _oTrans);
                        }

                    } // end for each

                    oScheduleFacade.deleteAllFolioSchedules(poFolio.FolioID, ref _oTrans);
                } // end if

                //// insert all Joiner Folio
                // update if existing

                // search From OLD JOINER FOLIOS
                // if not found then set as CANCELLED or CLOSED
                IList<Folio> _oOldJoinerFolios = this.getJoinerFolios(poFolio.FolioID);

                // add local copy of new joiner folios
                IList<Folio> _oNewJoinerFolios = new List<Folio>();
                if (poFolio.JoinerFolios != null)
                {
                    foreach (Folio _tempFolio in poFolio.JoinerFolios)
                    {
                        _oNewJoinerFolios.Add(_tempFolio);
                    }
                }


                if (_oOldJoinerFolios != null) //for joiner folio(no joiner)
                {
                    if (_oOldJoinerFolios != null)
                    {
                        foreach (Folio temp_oOldFolio in _oOldJoinerFolios)
                        {
                            Folio _oOldFolio = temp_oOldFolio;

                            bool found = false;

                            foreach (Folio _oNewFolio in _oNewJoinerFolios)
                            {
                                if (_oNewFolio.FolioID == _oOldFolio.FolioID)
                                {
                                    found = true;

                                    // overwrite Old joiner folio info
                                    _oOldFolio = _oNewFolio;

                                    // remove from current list since Found in OLD joiners
                                    _oNewJoinerFolios.Remove(_oNewFolio);
                                    break;
                                }

                            }

                            if (!found)
                            {
                                //if (_oOldFolio.Status == "ONGOING")
                                //{
                                //    _oOldFolio.Status = "CLOSED";
                                //}
                                //else
                                //{
                                _oOldFolio.Status = "REMOVED";
                                //}
                                //this.updateFolio(_oOldFolio);
                            }

                            // update folio
                            this.updateFolio(_oOldFolio);

                        }
                    }
                }

                // save 
                if (_oNewJoinerFolios != null)
                {
                    foreach (Folio _oJoinerFolio in _oNewJoinerFolios)
                    {

                        loFolioDAO.saveNewFolio(_oJoinerFolio, ref _oTrans);
                    }
                }
                EventContact _oContactPerson = new EventContact();
                //_oContactPerson.deleteContactPersons (poFolio.FolioID, GlobalVariables.gHotelId.ToString(), ref _oTrans);
                _oContactPerson.deleteContacts(poFolio.FolioID, ref _oTrans);
                if (poFolio.ContactPersons != null)
                {
                    foreach (EventContact _contactPerson in poFolio.ContactPersons)
                    {
                        if (_contactPerson.ContactID == "AUTO")
                            _contactPerson.save(ref _oTrans);
                        else
                            _contactPerson.update(ref _oTrans);
                    }
                }
                EventOfficer _oEventOfficer = new EventOfficer();
                _oEventOfficer.deleteEventOfficers(poFolio.FolioID, GlobalVariables.gHotelId.ToString(), ref _oTrans);
                if (poFolio.EventOfficers != null)
                {
                    foreach (EventOfficer _eventOfficer in poFolio.EventOfficers)
                    {
                        _eventOfficer.save(ref _oTrans);
                    }
                }

                IncumbentOfficer _oIncumbentOfficer = new IncumbentOfficer();
                _oIncumbentOfficer.deleteIncumbentOfficers(poFolio.FolioID, GlobalVariables.gHotelId.ToString(), ref _oTrans);
                if (poFolio.IncumbentOfficers != null)
                {
                    foreach (IncumbentOfficer _incumbentOfficer in poFolio.IncumbentOfficers)
                    {
                        _incumbentOfficer.save(ref _oTrans);
                    }
                }

                if (poFolio.EventEndorsement != null)
                {
                    try
                    {
                        if (poFolio.EventAttendance.getEventAttendance(poFolio.FolioID, poFolio.HotelID).Rows.Count<1)
                        {
                            poFolio.EventAttendance.save(ref _oTrans);
                        }
                        else
                        {
                            poFolio.EventEndorsement.update(ref _oTrans);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                       // if (!ex.Message.ToUpper().Contains("OBJECT REFERENCE NOT SET TO AN INSTANCE OF AN OBJECT"))
                        //    throw ex;
                    }
                }

                if (poFolio.EventAttendance != null)
                {
                    try
                    {
                        poFolio.EventAttendance.update(ref _oTrans);
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.ToUpper().Contains("OBJECT REFERENCE NOT SET TO AN INSTANCE OF AN OBJECT"))
                            throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction failed @ updateFolio.\r\nException: " + ex.Message);
            }

        }

		public DataTable getGroupBookingForExportToExcel()
		{
			loFolioDAO = new FolioDAO();
			return loFolioDAO.getGroupBookingForExportToExcel();
		}

		public bool checkOutFolio(string pFolioId, string pRoomNo, string pRemarks)
		{
			
			MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

            GuestFacade _oGuestFacade = new GuestFacade();
            loFolioDAO = new FolioDAO();
			RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
			RoomFacade _oRoomFacade = new RoomFacade();

			try 
			{
				// gets Folio information
				Folio _oFolio = this.GetFolio(pFolioId);


				loFolioDAO.updateFolioStatusToCheckedOut(pFolioId, pRemarks, ref _oDBTrans);

				// updates All Joiner Folios' Status to ONGOING
				//DataTable joinerGuest = this.getJoinerFolios(_oFolio.FolioID);
				//foreach (DataRow joinerRow in joinerGuest.Rows)
				foreach (Folio _oJoinerFolio in _oFolio.JoinerFolios)
				{
					string _joinerFolioId = _oJoinerFolio.FolioID;

					loFolioDAO.updateJoinerFolioStatusToCheckedOut(_oFolio.FolioID, _joinerFolioId, ref _oDBTrans);
                    _oGuestFacade.setNoOfVisits(_oJoinerFolio.AccountID);
				}

				// updates RoomEvents
				foreach (Schedule _oSchedule in _oFolio.Schedule)
				{
					_oRoomEventFacade.UpdateRoomEvents("CLOSED", _oFolio.FolioID, _oSchedule.RoomID, ref _oDBTrans);
				}

				// updates Room Status
				_oRoomFacade.setRoomStatus(pRoomNo, "VACANT", ref _oDBTrans);
				_oRoomFacade.setRoomCleaningStatus(pRoomNo, "DIRTY", ref _oDBTrans);


				// if early check in [remove RoomEvents and Update Folio Schedule]
				DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
				long _dateDiff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _auditDate, _oFolio.Todate);
				if (_dateDiff > 0)
				{ 
				
					// update current Schedule [ ToDate == gAuditDate ]
					foreach (Schedule _mySchedule in _oFolio.Schedule)
					{
						long _diffFrom = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _mySchedule.FromDate, _auditDate);
						long _diffTo = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _auditDate, _mySchedule.ToDate);

						if (_diffFrom >= 0 && _diffTo > 0)
						{
							// update Folio Schedules Table		
							ScheduleDAO oScheduleDAO = new ScheduleDAO();
							_mySchedule.ToDate = _auditDate;
							oScheduleDAO.UpdateFolioSchedulesEarlyCheckOut(_mySchedule, ref _oDBTrans);
							break;
						}

						// ISSUE
						// do we need to DELETE Schedules greater than the check-out date ???

					}


				}//end if



                _oFolio.CreateSubFolio();
                
                double totalSalesA = 0;
                double totalSalesB = 0;
                double totalSalesC = 0;
                double totalSalesD = 0;
                double totalCharges = 0;

                CompanyFacade _oCompanyFacade = new CompanyFacade();
                try
				{
                    string _accountid = "";
                    if (_oFolio.FolioType == "GROUP")
                    {
                        _accountid = _oFolio.CompanyID;
                    }
                    else
                    {
                        _accountid = _oFolio.AccountID;
                    }
                    
                    foreach (SubFolio subFolio in _oFolio.SubFolios)
                    {
                        subFolio.Folio.FolioTransactions = this.GetFolioTransactions(_oFolio.FolioID, subFolio.SubFolio_Renamed);
                        subFolio.Ledger = this.GetFolioLedger(_oFolio.FolioID, subFolio.SubFolio_Renamed);

                        //totalSales += (double)(subFolio.Ledger.PayCash + subFolio.Ledger.PayCard + subFolio.Ledger.PayCheque + subFolio.Ledger.PayGiftCheque + subFolio.Ledger.BalanceForwarded);
                        totalCharges += (double)subFolio.Ledger.Charges;

                        switch (subFolio.SubFolio_Renamed)
                        {
                            case "A":
                                totalSalesA = computeTotalSales(_oFolio.FolioID, subFolio.SubFolio_Renamed);
                                _oGuestFacade.updateAccountTotalSales(_oFolio.AccountID, totalSalesA);
                                break;
                            case "B":
                                totalSalesB = computeTotalSales(_oFolio.FolioID, subFolio.SubFolio_Renamed);
                                if (subFolio.Ledger.AccountID.StartsWith("I"))
                                    _oGuestFacade.updateAccountTotalSales(subFolio.Ledger.AccountID, totalSalesB);
                                else
                                    _oCompanyFacade.updateAccountTotalSales(subFolio.Ledger.AccountID, totalSalesB);

                                if (totalSalesB > 0 && _oFolio.FolioType != "DEPENDENT" && _accountid != subFolio.Ledger.AccountID)
                                {
                                    if (subFolio.Ledger.AccountID.StartsWith("I"))
                                        _oGuestFacade.setNoOfVisits(subFolio.Ledger.AccountID);
                                    else
                                        _oCompanyFacade.setNoOfVisits(subFolio.Ledger.AccountID);
                                }
                                break;
                            case "C":
                                totalSalesC = computeTotalSales(_oFolio.FolioID, subFolio.SubFolio_Renamed);
                                if (subFolio.Ledger.AccountID.StartsWith("I"))
                                    _oGuestFacade.updateAccountTotalSales(subFolio.Ledger.AccountID, totalSalesC);
                                else
                                    _oCompanyFacade.updateAccountTotalSales(subFolio.Ledger.AccountID, totalSalesC);

                                if (totalSalesC > 0 && _oFolio.FolioType != "DEPENDENT" && _accountid != subFolio.Ledger.AccountID)
                                {
                                    if (subFolio.Ledger.AccountID.StartsWith("I"))
                                        _oGuestFacade.setNoOfVisits(subFolio.Ledger.AccountID);
                                    else
                                        _oCompanyFacade.setNoOfVisits(subFolio.Ledger.AccountID);
                                }
                                break;
                            case "D":
                                totalSalesD = computeTotalSales(_oFolio.FolioID, subFolio.SubFolio_Renamed);
                                if (subFolio.Ledger.AccountID.StartsWith("I"))
                                    _oGuestFacade.updateAccountTotalSales(subFolio.Ledger.AccountID, totalSalesD);
                                else
                                    _oCompanyFacade.updateAccountTotalSales(subFolio.Ledger.AccountID, totalSalesD);

                                if (totalSalesD > 0 && _oFolio.FolioType != "DEPENDENT" && _accountid != subFolio.Ledger.AccountID)
                                {
                                    if (subFolio.Ledger.AccountID.StartsWith("I"))
                                        _oGuestFacade.setNoOfVisits(subFolio.Ledger.AccountID);
                                    else
                                        _oCompanyFacade.setNoOfVisits(subFolio.Ledger.AccountID);
                                }
                                break;
                        }
                    }

				}
				catch (Exception ex)
				{
                    throw new Exception("Transaction failed @ Check Out Folio.\r\n\r\nError message : " + ex.Message);
				}//end try catch

				switch (_oFolio.AccountType)
				{
					case "PERSONAL":
						try
						{
                            if (_oFolio.FolioType == "GROUP")
                            {
                                _oGuestFacade.setNoOfVisits(_oFolio.CompanyID);
                                _oGuestFacade.updateAccountTotalSales(_oFolio.CompanyID, totalSalesA);
                            }
                            else
                            {
                                _oGuestFacade.setNoOfVisits(_oFolio.AccountID);
                            }
						}
						catch (Exception ex)
						{
							throw new Exception("Transaction failed @ Check Out Folio.\r\n\r\nError message : " + ex.Message);
						}

						break;

					case "CORPORATE":
						try
						{
                            if (_oFolio.FolioType == "GROUP")
                            {
                                if (_oFolio.CompanyID.StartsWith("G"))
                                {
                                    if (_oFolio.Payment_Mode == "EX-DEAL")
                                    {
                                        _oCompanyFacade.deductXDealAmount(_oFolio.CompanyID, totalCharges);
                                    }


                                    _oCompanyFacade.updateAccountTotalSales(_oFolio.CompanyID, totalSalesA);
                                    _oCompanyFacade.setNoOfVisits(_oFolio.CompanyID);
                                }
                                else if (_oFolio.CompanyID.StartsWith("I"))
                                {
                                    _oGuestFacade.setNoOfVisits(_oFolio.AccountID);
                                }
                            }
                            else
                            {
                                _oGuestFacade.setNoOfVisits(_oFolio.AccountID);
                            }
						}
						catch (Exception ex)
						{
							throw new Exception("Transaction failed @ Check Out Folio.\r\nException: " + ex.Message);
						}
						break;


				} // end switch

				_oDBTrans.Commit();

				return true;

			}
			catch(Exception ex)
			{
				_oDBTrans.Rollback();
                MessageBox.Show("Transaction failed.\r\n\r\nError message : " + ex.Message);
                return false;
			}

		}

        public double computeTotalSales(string pFolioID, string pSubFolio)
        {
            loFolioDAO = new FolioDAO();
            double _totalDBCharges = loFolioDAO.getFolioTotalCharges(pFolioID, pSubFolio);
            double _totalCRCharges = loFolioDAO.getFolioTotalCreditCharges(pFolioID, pSubFolio);
            double _totalTrDBDebitSide = loFolioDAO.getFolioTrDBDebitSide(pFolioID, pSubFolio);
            double _totalTrDBCreditSide = loFolioDAO.getFolioTrDBCreditSide(pFolioID, pSubFolio);
            double _totalComplimentaryPayments = loFolioDAO.getFolioComplimentaryPayments(pFolioID, pSubFolio);

            double _totalAmount = 0;
            _totalAmount = (_totalDBCharges + _totalTrDBDebitSide) - (_totalTrDBCreditSide + _totalComplimentaryPayments + _totalCRCharges);

            return _totalAmount;
        }

        // COMMENT Daniel Balagosa
        // August 22, 2012
        // Function below is called when Group Reservation save button is pressed
        // Checks if any of the chosen function rooms has conflicts
        // END
        public bool functionIsConflict(string pRoom, string pDate, string pTime, string pFolioID)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.functionIsConflict(pRoom, pDate, pTime, pFolioID);
        }

        public void updateFolioPax(string pFolioID, decimal pax)
        {
            loFolioDAO = new FolioDAO();
            loFolioDAO.updateFolioPax(pFolioID, pax);
        }

        public DataTable getCheckedInGroups(string pDate)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getCheckedInGroups(pDate);
        }

        public int updateCancellation(string pFolioID, string pReason, string pReasonType, string pCancelBookingType, string pFutureAction)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.updateCancellation(pFolioID, pReason, pReasonType, pCancelBookingType, pFutureAction);
        }

        public string getFolioStatus(string pFolioID)
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getFolioStatus(pFolioID);
        }

        public DataTable getMarketingOfficers()
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getMarketingOfficers();
        }

        public DataTable getEventOfficers()
        {
            loFolioDAO = new FolioDAO();
            return loFolioDAO.getEventOfficers();
        }
	}
}
