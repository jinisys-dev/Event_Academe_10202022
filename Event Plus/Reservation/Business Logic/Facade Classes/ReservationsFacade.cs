
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;


namespace Jinisys.Hotel.Reservation.BusinessLayer
	{
		public class ReservationsFacade //: IDisposable
		{
			
			
			public ReservationsFacade()
			{
			}

            public GenericList<Folio> GetGroupReservationList()
            {
                GenericList<Folio> pFolioList = new GenericList<Folio>();
                DataTable dTable = new DataTable();
                ReservationsDAO reservationsDAO = new ReservationsDAO();
                dTable = reservationsDAO.GetReservationList();

                foreach (DataRow _dataRow in dTable.Rows)
                {
                    Folio _oFolio = new Folio();
                    _oFolio.AccountID = _dataRow["accountid"].ToString();
                    _oFolio.HotelID = int.Parse(_dataRow["hotelID"].ToString());
                    _oFolio.FolioID = _dataRow["folioid"].ToString();
                    _oFolio.FolioType = _dataRow["foliotype"].ToString();
                    _oFolio.GroupName = _dataRow["groupname"].ToString();
                    _oFolio.AccountType = _dataRow["accounttype"].ToString();
                    _oFolio.NoofAdults = int.Parse(_dataRow["noofadults"].ToString());
                    _oFolio.NoOfChild = int.Parse(_dataRow["noofchild"].ToString());
                    _oFolio.MasterFolio = _dataRow["masterfolio"].ToString();
                    _oFolio.CompanyID = _dataRow["companyid"].ToString();
                    _oFolio.AgentID = _dataRow["agentid"].ToString();
                    _oFolio.Source = _dataRow["source"].ToString();
                    _oFolio.FromDate = DateTime.Parse(_dataRow["fromdate"].ToString());
                    _oFolio.Todate = DateTime.Parse(_dataRow["todate"].ToString());
                    _oFolio.ArrivalDate = DateTime.Parse(_dataRow["arrivaldate"].ToString());
                    _oFolio.DepartureDate = DateTime.Parse(_dataRow["departuredate"].ToString());
                    _oFolio.PackageID = _dataRow["packageid"].ToString();
                    _oFolio.Status = _dataRow["status"].ToString();
                    _oFolio.Remarks = _dataRow["remarks"].ToString();

                    pFolioList.Add(_oFolio);
                }
                return pFolioList;
            }
			
			public DataTable GetReservationList()
			{
				ReservationsDAO reservationsDAO = new ReservationsDAO( );
				return reservationsDAO.GetReservationList();
			}


            public bool isConflictWithRoomEvents(string dateFrom, string dateTo, ArrayList rooms)
            {
                RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
                return roomBlockDAO.isConflict(dateFrom, dateTo, rooms);
            }

            public GenericList<Schedule> getRoomsAssignedForMasterFolio(string folioID)
            {
                GenericList<Schedule> roomsAssigned = new GenericList<Schedule>();
                ReservationsDAO reservationDAO = new ReservationsDAO();
                DataTable dt = reservationDAO.getRoomsAssignedForMasterFolio(folioID);

                foreach (DataRow dr in dt.Rows)
                {
                    Schedule rooms = new Schedule();
                    rooms.RoomID = dr["roomid"].ToString();

                    roomsAssigned.Add(rooms);
                }
                return roomsAssigned;
            }


			//added - March 5, 2009
			// to handle slow render of Group Reservation List
			public DataTable getGroupReservationList()
			{
				ReservationsDAO oReservationDAO = new ReservationsDAO();
				return oReservationDAO.getGroupReservationList();
				
			}

            public DataTable getBlockedRooms(string pFolioID)
            {
                ReservationsDAO oReservationDAO = new ReservationsDAO();
                return oReservationDAO.getBlockedRooms(pFolioID);
            }

            public DataTable getGroupList()
            {
                ReservationsDAO oReservationDAO = new ReservationsDAO();
                return oReservationDAO.getGroupList();

            }

			public DataTable GetGuestsList(string whereCondition)
			{
				ReservationsDAO reservationsDAO = new ReservationsDAO();
				return reservationsDAO.GetGuestsList(whereCondition);
			}

			public DataTable GetGuestsListForLegend()
			{
				ReservationsDAO reservationsDAO = new ReservationsDAO();
				return reservationsDAO.GetGuestsListForLegend();
			}

			public DataTable GetGuestListDefaults()
			{
				ReservationsDAO reservationsDAO = new ReservationsDAO();
				return reservationsDAO.GetGuestListDefaults();
			}


    }
}