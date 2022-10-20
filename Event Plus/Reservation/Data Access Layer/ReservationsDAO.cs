
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class ReservationsDAO
    {

        private ParameterHelper oParameterHelper;
        private FolioFacade oFolioFACADE;
        private CompanyFacade oCompanyFACADE;
        private GuestFacade oGuestFACADE;
        //private AgentFacade oAgentFACADE;

        public ReservationsDAO()
        {
            oParameterHelper = new ParameterHelper();
            oFolioFACADE = new FolioFacade();
            oCompanyFACADE = new CompanyFacade();
            oGuestFACADE = new GuestFacade();
        }

        public DataTable GetRoutingDetails(string folioID, string trancode)
        {
            try
            {
                MySqlCommand getCommand = new MySqlCommand("call spGetRoutingDetails (\'" + folioID + "\'," + GlobalVariables.gHotelId + ",\'" + trancode + "\')", GlobalVariables.gPersistentConnection);
                getCommand.CommandType = CommandType.Text;

                MySqlDataAdapter dtAdapter = new MySqlDataAdapter(getCommand);
                DataTable FolioRouting = new DataTable("FolioRouting");
                dtAdapter.Fill(FolioRouting);
                return FolioRouting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message + " GetRoutingDetails(ByVal folioID As String, ByVal trancode As String) As DataTable");
                return null;
            }
        }
        public DataTable GetReservationList()
        {
            try
            {
                DataTable dtFolioList = new DataTable("Folio");

                MySqlDataAdapter dtaSelect = new MySqlDataAdapter("call spSelectAllFolio()", GlobalVariables.gConnectionForBackGroundWorker);
                dtaSelect.Fill(dtFolioList);

                return dtFolioList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void RemovePackage(string folioid)
        {
            try
            {
                MySqlCommand removeCommand = new MySqlCommand("call spRemovePACKAGE(\'" + folioid + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                removeCommand.CommandType = CommandType.Text;
                removeCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }
        private bool isRoomBlockedInDate(string date, ArrayList rooms)
        {
            try
            {
                MySqlCommand getCurrentBlockCommand = new MySqlCommand("call spGetBlockedRoomInDate(\'" + date + "\')", GlobalVariables.gPersistentConnection);
                getCurrentBlockCommand.CommandType = CommandType.Text;
                MySqlDataAdapter daRoomBlock = new MySqlDataAdapter(getCurrentBlockCommand);
                DataTable CurrentRoomBlockTable = new DataTable("CurrentBlockRooms");
                daRoomBlock.Fill(CurrentRoomBlockTable);
                foreach (DataRow dr in CurrentRoomBlockTable.Rows)
                {
                    if (rooms.IndexOf(dr["roomid"].ToString()) != -1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " isRoomBlockedInDate(string date,ArrayList rooms) at RoomBlockDAO");
                return true;
            }
        }
        public bool isConflict(string dateFrom, string dateTo, ArrayList rooms)
        {
            try
            {
                foreach (string room in rooms)
                {
                    MySqlCommand cmdChkConflict = new MySqlCommand("call spGetRoomBlocksConflict(\'" + dateFrom + "\',\'" + dateTo + "\',\'" + room + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                    cmdChkConflict.CommandType = CommandType.Text;
                    object rm = cmdChkConflict.ExecuteScalar();
                    if (rm != null)
                        return true;
                    long days = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(dateFrom), DateTime.Parse(dateTo));
                    for (long start = 0; start < days; start++)
                    {
                        string dateToCheck = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(dateFrom).AddDays(start));
                        if (isRoomBlockedInDate(dateToCheck, rooms))
                        {
                            return true;
                        }
                    }

                }
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " Function isConflict(string dateFrom, string dateTo,ArrayList rooms) at RoomBlockDAO");
                return true;
            }
        }

        public DataTable getRoomsAssignedForMasterFolio(string folioID)
        {
            try
            {
                string sql = "call spGetRoomsByMasterFolio('" + folioID + "')";
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Rooms");

                da.Fill(dt);
                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataTable getBlockedRooms(string pFolioID)
        {
            try
            {
                DataTable dtTable = new DataTable();
                string _query = "select roomid from blockingdetails, roomblock where " +
                              "roomblock.blockid=blockingdetails.blockid and roomblock.folioid='" + pFolioID +
                              "' union select roomid from folioschedules, folio where " +
                              "folioschedules.folioid=folio.folioid and folio.masterfolio='" + pFolioID + "' and folio.status!='REMOVED' and folio.status!='CANCELLED' and folio.status!='DELETED'";

                MySqlDataAdapter dtAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
                dtAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public DataTable getGroupReservationList()
        {
            try
            {
				DataTable tempTable = new DataTable("Rooms");

                string sql = "call spGetGroupReservationList('" 
								   + GlobalVariables.gHotelId + "')";

                MySqlDataAdapter adapter = new MySqlDataAdapter(
											sql, 
											GlobalVariables.gPersistentConnection);

                

                adapter.Fill(tempTable);

                return tempTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getGroupList()
        {
            try
            {
                DataTable tempTable = new DataTable("Rooms");

                string sql = "call spGetGroupList('"
                                   + GlobalVariables.gHotelId + "')";

                MySqlDataAdapter adapter = new MySqlDataAdapter(
                                            sql,
                                            GlobalVariables.gPersistentConnection);



                adapter.Fill(tempTable);

                return tempTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public DataTable GetGuestsList(string whereCondition)
		{
            // Comment Daniel Balagosa
            // Function called for populating Event Reservation UI
            // END
			try
			{
                
				DataTable dtFolioList = new DataTable("Folio");

				string query = "SELECT \n"
								+ "folio.folioid, \n"
								+ "guests.accountID, \n"
								+ "if(folio.foliotype='GROUP', fGetGuestName(folio.companyid), concat(guests.lastname,', ',guests.firstname)) as guestName, \n"
								+ "guests.concierge, \n"
								+ "guests.remark, \n"
								+ "guests.ACCOUNT_TYPE, \n"
								+ "guests.THRESHOLD_VALUE, \n"
								+ "if(foliotype='JOINER', fGetGroupName(folio.masterfolio), folio.groupname) as groupname, \n"
								+ "company.companyName, \n"
								+ "folio.fromdate, \n"
								+ "folio.todate, \n"
								+ "sum(folioledger.balancenet) as Balance, \n"
								+ "folio.status, \n"
								+ "folio.remarks, \n"
								+ "folio.foliotype, \n"
								+ "folio.masterfolio, \n"
								+ "concat(folio.noofadults,'/',folio.noofchild) as Pax, \n"
								+ "folio.folioETA, \n"
								+ "folio.folioETD, \n"
								+ "folio.REASON_FOR_CANCEL, \n"
								+ "folio.sales_executive, \n"
								+ "folio.createdBy, \n"
								+ "folio.updatedBy, \n"
								+ "folio.updateTime, \n"
								+ "folio.createTime, \n"
                                + "fGetEventTotalRequiredRooms(folio.folioid) as RequiredRooms, \n"
                                + "fGetEventTotalBlockedRooms(folio.folioid) as BlockedRooms, \n"
                                + "(select group_concat(concat(users.firstName, ' ' , users.lastName, ' ')) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioID = folio.folioid and event_officers.status = 'ACTIVE') as eventOfficers, \n"
                                + "folio.referenceNo ,\n"
                            //  + "(select group_concat(concat(DATE_FORMAT(CAST(CONCAT('2012-12-12 ',folioschedules.startTime) AS DATETIME), '%h:%i %p'), '-', DATE_FORMAT(CAST(CONCAT('2012-12-12 ',folioschedules.endTime) AS DATETIME), '%h:%i %p'),' ')) from folioschedules where folioschedules.FolioId = folio.folioID) as TimeOfEvent "
                               // + "concat(DATE_FORMAT(folio.fromdate, '%d %b %y'),' ',DATE_FORMAT(CAST(CONCAT('2012-12-12 ',(select folioschedules.startTime from folioschedules where folioschedules.folioid = folio.folioid order by folioschedules.startTime asc limit 1)) AS DATETIME),'%h:%i %p'),' - ',DATE_FORMAT(folio.fromdate, '%d %b %y'),' ',DATE_FORMAT(CAST(CONCAT('2012-12-12 ',(select folioschedules.endTime from folioschedules where folioschedules.folioid = folio.folioid order by folioschedules.endTime asc limit 1)) AS DATETIME),'%h:%i %p')) as TimeOfEvent \n"
                                + "concat(' ',DATE_FORMAT(CAST(CONCAT('2012-12-12 ',(select folioschedules.startTime from folioschedules where folioschedules.folioid = folio.folioid order by folioschedules.startTime asc limit 1)) AS DATETIME),'%h:%i %p'),' - ',' ',DATE_FORMAT(CAST(CONCAT('2012-12-12 ',(select folioschedules.endTime from folioschedules where folioschedules.folioid = folio.folioid order by folioschedules.endTime asc limit 1)) AS DATETIME),'%h:%i %p')) as TimeOfEvent \n"
                               + "FROM \n"
								+ "folio force index(folioid) \n"
								+ "left join folioledger on \n"
								+ "folioledger.folioid = folio.folioid \n"
								+ "left join company on \n"
								+ "company.companyid = folio.companyid \n"
								+ "left join guests on \n"
								+ "guests.accountid = folio.accountid \n"
							+ "WHERE  \n"
								+ whereCondition + " "
								+ "and folio.hotelid = " + GlobalVariables.gHotelId + " \n"
							+ "GROUP BY \n"
								+ "folio.folioid";

				MySqlDataAdapter dtaSelect = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
				dtaSelect.Fill(dtFolioList);
				dtaSelect.Dispose();
                return dtFolioList;

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable GetGuestsListForLegend()
		{
			try
			{
				DataTable dtFolioList = new DataTable("Folio");

				string query = "call spGetGuestListSummary('" + GlobalVariables.gAuditDate + "')";

				MySqlDataAdapter dtaSelect = new MySqlDataAdapter(query, GlobalVariables.gConnectionForBackGroundWorker);
				dtaSelect.Fill(dtFolioList);
				dtaSelect.Dispose();

				return dtFolioList;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		public DataTable GetGuestListDefaults()
		{
			try
			{
				DataTable dtFolioList = new DataTable("GuestListDefaults");

				string query = "call spGetGuestListDefaults()";

				MySqlDataAdapter dtaSelect = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
				dtaSelect.Fill(dtFolioList);
				dtaSelect.Dispose();

				return dtFolioList;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		

    }
    

}