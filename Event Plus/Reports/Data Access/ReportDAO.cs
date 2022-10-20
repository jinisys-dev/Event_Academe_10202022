using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.Reports.DataAccessLayer
{
	public class ReportDAO
	{
		private DataSet oDtReport;
		private MySqlDataAdapter rptAdapter;

		public ReportDAO() { }

		public DataSet getGuestsListByDate()
		{
			try
			{
				DataSet datasetGuests = null;
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetGuestsListByDate()", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(datasetGuests, "GuestList");
				return datasetGuests;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getGuestsListByDate() " + ex.Message);
				return null;
			}
		}

        //jlo
        /// <summary>
        /// Gets the DataTable of roomutilization
        /// </summary>
        /// <param name="pStartDate">start date of report</param>
        /// <param name="pEndDate">end date of report</param>
        /// <returns>datatable of roomutilization</returns>
        public DataTable getRoomUtilization(DateTime pStartDate, DateTime pEndDate)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _queryAdapter = new MySqlDataAdapter("call spGetRangeRoomUtilization('" + string.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                try
                {
                    _queryAdapter.Fill(_dt);
                    return _dt;
                }
                finally
                {
                    _queryAdapter.Dispose();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error @ReportDAO.getRoomUtilization\r\n" + ex.Message);
            }
        }

        //jlo 9-25-10
        /// <summary>
        /// Gets the report datatable for calendar of events
        /// </summary>
        /// <param name="pStartDate"></param>
        /// <param name="pEndDate"></param>
        /// <param name="pHotelID"></param>
        /// <param name="pStatus"></param>
        /// <returns>datatable</returns>
        public DataTable getReportCalenderOfEvents(DateTime pStartDate, DateTime pEndDate, int pHotelID, string pStatus)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportCalendarOfEvents('" + string.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "','" + pHotelID.ToString() + "','" + pStatus + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getReportCalendarOfEvents\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getReportWeeklyScedules(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportWeeklySchedule(" + GlobalVariables.gHotelId + ",'" + string.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getReportWeeklyScedules\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getEventTypes(int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventTypes()", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getEventTypes\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getGroupBooking(string pFieldName, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetGroupBooking('" + pFieldName + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getGroupBooking\r\n" + ex.Message);
            }
        }

        //jlo 9-23-2010
        /// <summary>
        /// Gets the datatable of payments
        /// </summary>
        /// <param name="pFolioID"></param>
        /// <param name="pHotelID"></param>
        /// <returns></returns>
        public DataTable getPayments(string pFolioID, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportEventOrderPayments('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getPayments\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getRoomTypesCalendarEvents(int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRoomTypeCalendarEvents()", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ ReportDAO.getRoomTypes\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getRoomTypes(int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRoomTypes()", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ ReportDAO.getRoomTypes\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        //jlo 9-21-2010
        /// <summary>
        /// Gets the datable of event orders
        /// </summary>
        /// <param name="pFolioID">folio id</param>
        /// <param name="pRemarks">combination of date and room</param>
        /// <param name="pHotelID">hotel id</param>
        /// <returns>datatable of event orders</returns>
        public DataTable getEventOrder(string pFolioID, string pRemarks, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportEventOrder('" + pFolioID + "','" + pRemarks + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getEventOrder\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
        //jlo 9-21-2010
        /// <summary>
        /// gets the data for event order sub report
        /// </summary>
        /// <param name="pFolioID">folio id</param>
        /// <param name="pRoomID">room id</param>
        /// <param name="pDate">date</param>
        /// <param name="pHotelID">hotel id</param>
        /// <returns>datatable</returns>
        public DataTable getEventOrderSubReport(string pFolioID, string pRoomID, DateTime pDate, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportEventOrderSub('" + pFolioID + "','" + pRoomID + "','" + string.Format("{0:yyyy-MM-dd}",pDate) + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getEventOrderSubReport\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getRangeFolioTransactions(string pFrom, string pTo)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _queryAdapter = new MySqlDataAdapter("call spGetRangeTransactions('" + GlobalVariables.gHotelId + "','" + pFrom + "','" + pTo + "')", GlobalVariables.gPersistentConnection);
                try
                {
                    _queryAdapter.Fill(_dt);
                    return _dt;
                }
                finally
                {
                    _queryAdapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioTransactionDAO.getRangeFolioTransactions\r\n" + ex.Message);
            }
        }

		// >> CHECK IN
		public DataTable getGuestInformation(string a_FolioId)
		{
			try
			{
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetGuestInfo('" + a_FolioId + "')", GlobalVariables.gPersistentConnection);
				DataTable dtTable = new DataTable("GuestInfo");
				dataAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getGuestInformation() " + ex.Message);
				return null;
			}

		}

		// >> CHECKOUT
		public DataTable getCashierTransaction(string a_gTerminalID, string a_CashierId, string a_gShiftCode)
		{
			try
			{
				DataTable datatableTransactions = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportCashierPaymentTransaction('" + a_gTerminalID + "','" + a_CashierId + "','" + a_gShiftCode + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(datatableTransactions);

				return datatableTransactions;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCashierTransaction() " + ex.Message);
				return null;
			}

		}

		public DataTable getCashierVoidTransaction(string a_gTerminalID, string a_CashierId, string a_gShiftCode)
		{
			try
			{
				DataTable datatableTransactions = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportCashierVoidTransactions('" + a_gTerminalID + "','" + a_CashierId + "','" + a_gShiftCode + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(datatableTransactions);

				return datatableTransactions;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCashierVoidTransaction() " + ex.Message);
				return null;
			}

		}


		public DataSet getRoomOccupancy(DateTime a_DateFrom, DateTime a_DateTo)
		{
			try
			{
				oDtReport = new DataSet();
				rptAdapter = new MySqlDataAdapter("call spReportRoomOccupancy('" + string.Format("(0:yyyy-MM-dd}", a_DateFrom) + "','" + string.Format("(0:yyyy-MM-dd}", a_DateTo) + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport);

				return oDtReport;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetRoomOccupancy() " + ex.Message);
				return null;
			}
			finally
			{
				rptAdapter.Dispose();
			}
		}

		// >> IN HOUSE GUESTS
		public DataTable getInHouseGuests()
		{
			try
			{
				DataTable dtTable = new DataTable("InHouseGuests");
				rptAdapter = new MySqlDataAdapter("call spReportINHouseGuestList(" + GlobalVariables.gHotelId + ",'" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetInHouseGuests() " + ex.Message);
				return null;
			}
		}

        public DataTable getParamInHouseGuests(DateTime pDate)
        {
            try
            {
                DataTable dtTable = new DataTable("InHouseGuests");
                rptAdapter = new MySqlDataAdapter("call spReportINHouseGuestList(" + GlobalVariables.gHotelId + ",'" + string.Format("{0:yyyy-MM-dd}", pDate) + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetInHouseGuests() " + ex.Message);
                return null;
            }
        }

        // >> IN HOUSE GROUPS
        public DataTable getInHouseGroups()
        {
            try
            {
                DataTable _oDataTable = new DataTable("GroupReservations");
                rptAdapter = new MySqlDataAdapter("call spReportINHouseGroups(" + GlobalVariables.gHotelId + ",'" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ InHouseGroups() " + ex.Message);
                return null;
            }
        }

        public DataTable getParamInHouseGroups(DateTime pDate)
        {
            try
            {
                DataTable dtTable = new DataTable("GroupReservations+");
                rptAdapter = new MySqlDataAdapter("call spReportINHouseGroups(" + GlobalVariables.gHotelId + ",'" + string.Format("{0:yyyy-MM-dd}", pDate) + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupReservations";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ InHouseGroups() " + ex.Message);
                return null;
            }
        }

        // >> Guest Ledger
		public DataTable getGuestLedger(DateTime reportDate)
		{
			try
			{
				string strReportDate = string.Format("{0:yyyy-MM-dd}", reportDate);

				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportGuestsLedger('" + GlobalVariables.gHotelId + "','" + strReportDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getGuestLedger() " + ex.Message);
				return null;
			}
		}

		// >> ROOM AVAILABILITY
		public DataTable getRoomAvailability()
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportRoomAvailability(\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetRoomAvailability() " + ex.Message);
				return null;
			}
		}

		// >> ROOM TRANSFER
		public DataTable getGuestTransfer()
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportRoomTransfer('" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetGuestTransfer() " + ex.Message);
				return null;
			}
		}

		// >> INDIVIDUAL FOLIO BILLING
		public DataSet getFolioTransactions(string a_folioId, string a_subFolio)
		{
			try
			{

				oDtReport = new DataSet();
				rptAdapter = new MySqlDataAdapter("call spReportIndividualGuestBill('" + a_folioId + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "Main");

				rptAdapter = new MySqlDataAdapter("call spReportIndividualGuestBillSubReport('" + a_folioId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "SubReport");

				return oDtReport;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetFolioTransactions() " + ex.Message);
				return null;
			}

		}

		// >> INDIVIDUAL FOLIO BILLING
		public DataTable getAllFolio()
		{
			try
			{

				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportAllIndividualFolio('" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAllFolio() " + ex.Message);
				return null;
			}

		}

		public DataTable getRoomCleaningStatus()
		{
			try
			{
				DataTable dtTable = new DataTable("OutOfOrderRooms");
				rptAdapter = new MySqlDataAdapter("call spReportRoomCleaningStatus('" + GlobalVariables.gAuditDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetRoomCleaningStatus() " + ex.Message);
				return null;
			}

		}

		// >> HOUSEKEEPING JOB
		public DataTable getHousekeepingJobs(DateTime pReportDate)
		{
			try
			{
				DataTable dtTable = new DataTable("HousekeepingJobs");

				rptAdapter = new MySqlDataAdapter("call spReportHousekeepingJobs('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pReportDate) + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetHousekeepingJobs() " + ex.Message);
				return null;
			}
			finally
			{
				rptAdapter.Dispose();
			}
		}

		// >> COMPANY FOLIO BILLING
		public DataSet getGroupBill(string a_folioId)
		{
			try
			{
				oDtReport = new DataSet();
				rptAdapter = new MySqlDataAdapter("call spReportGroupBill(\'" + a_folioId + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "FolioTransactions");

				rptAdapter = new MySqlDataAdapter("call spReportDependentFolios(\'" + a_folioId + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "DependentFolios");

				rptAdapter = new MySqlDataAdapter("call spReportGroupBill2('" + a_folioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "FolioPackages");

				return oDtReport;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetGroupBill() " + ex.Message);
				return null;
			}

		}

        public DataTable getJoiners(string pFolioID)
        {
            try
            {
                DataTable dtTable = new DataTable("Joiners");
                rptAdapter = new MySqlDataAdapter("select * from vwjoinerfolios where masterfolio='" + pFolioID + "' and folioStatus!='REMOVED' and folioStatus!='DELETED' and folioStatus!='CANCELLED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getTransactionRegisterReport() " + ex.Message);
                return null;
            }
        }

        //jlo 7-30-2010
        public DataTable getCompanyBill_PICC(string pFolioId)
        {
            try
            {
                DataTable _dt = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportGroupBillPICC('" + pFolioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getCompanyBill_PICC\r\n" + ex.Message);
            }
        }

        public DataTable getCompanyBill_PICCCharges(string pFolioId)
        {
            try
            {
                DataTable _dt = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportGroupBillPICCCharges('" + pFolioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getCompanyBill_PICC\r\n" + ex.Message);
            }
        }

		public DataSet getCompanyBill(string a_folioId)
		{
			try
			{
				oDtReport = new DataSet();
				rptAdapter = new MySqlDataAdapter("call spReportGroupBill('" + a_folioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "FolioTransactions");

				//rptAdapter = new MySqlDataAdapter("call spReportDependentFolios('" + a_folioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				//rptAdapter.Fill(oDtReport, "DependentFolios");

				rptAdapter = new MySqlDataAdapter("call spReportGroupBill2('" + a_folioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "FolioPackages");

				    return oDtReport;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetGroupBill() " + ex.Message);
				return null;
			}
		}

		public DataTable getTransactionRegisterReport()
		{
			try
			{
				DataTable dtTable = new DataTable("TransactionRegister");
				rptAdapter = new MySqlDataAdapter("call spReportTransactionRegister('" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getTransactionRegisterReport() " + ex.Message);
				return null;
			}
		}

        public DataTable getAdjustmentTransactionsReport()
        {
            try
            {
                DataTable dtTable = new DataTable("AdjustmentTransactions");
                rptAdapter = new MySqlDataAdapter("call spReportAdjustmentTransactions()", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getAdjustmentTransactionsReport() " + ex.Message);
                return null;
            }
        }

		public DataTable getNoOfPax(string a_Date, string pFilter)
		{
			try
			{
				DataTable noOfPax = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spCountNoOfPax('" + a_Date + "','" + GlobalVariables.gHotelId + "','" + pFilter + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(noOfPax);

				return noOfPax;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getNoOfPax() " + ex.Message);
				return null;
			}
		}

		public DataTable getCityTransferTransactions()
		{
			try
			{
				DataTable cityTransfer = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportCityTransferTransactions('" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityTransfer);

				return cityTransfer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCityTransfer() " + ex.Message);
				return null;
			}
		}

		public DataTable getInhouseGuestsForecast(string reportDate)
		{
			try
			{
				DataTable inhouseGuests = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportParamInHouseGuestsForecast('" + GlobalVariables.gHotelId + "','" + reportDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(inhouseGuests);

				return inhouseGuests;
			}
			catch (Exception ex)
			{
                MessageBox.Show("EXCEPTION: @ getInhouseGuestsForecast() " + ex.Message);
				return null;
			}

		}

		public DataTable getAllCashierTransactions(string pgAuditDate)
		{
			try
			{
				DataTable datatableTransactions = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportAllCashierTransaction('" + pgAuditDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(datatableTransactions);

				return datatableTransactions;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCashierTransaction() " + ex.Message);
				return null;
			}
		}

		public DataTable getAllCashierShiftTransaction(string a_gAuditDate, string reportType)
		{
			try
			{
				DataTable datatableTransactions = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportAllCashierTransaction('" + a_gAuditDate + "','" + GlobalVariables.gHotelId + "','" + reportType + "')", GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(datatableTransactions);

				return datatableTransactions;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAllCashierShiftTransaction() " + ex.Message);
				return null;
			}

		}

		public DataTable getAllCashierShiftVoidTransaction(string a_gAuditDate, string reportType)
		{
			try
			{
				DataTable datatableTransactions = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportAllCashierVoidTransaction('" + a_gAuditDate + "','" + GlobalVariables.gHotelId + "','" + reportType + "')", GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(datatableTransactions);

				return datatableTransactions;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAllCashierShiftTransaction() " + ex.Message);
				return null;
			}

		}


		public DataTable getRestaurantLeger(string a_ReportDate)
		{
			try
			{
				DataTable datatableTransactions = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportRestaurantLedger('" + a_ReportDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(datatableTransactions);

				return datatableTransactions;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getVoidedTransactionsReport() " + ex.Message);
				return null;
			}

		}

		#region "CITY LEDGER"
		public DataTable getCityLedger()
		{
			try
			{
				DataTable cityLedger = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spGetCityLedgerSummary()", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityLedger);

				return cityLedger;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCityLedger() " + ex.Message);
				return null;
			}
		}

		public DataTable getCityLedgerDate(string pDate)
		{
			try
			{
				DataTable cityLedger = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportCityLedger('" + GlobalVariables.gHotelId + "','" + pDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityLedger);

				return cityLedger;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCityLedgerDate() " + ex.Message);
				return null;
			}
		}

		#endregion

		#region "TRANSACTION REGISTER"

		public DataTable getParamTransactionRegisterReport(string startDate, string endDate)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportParamTransactionRegister('" + GlobalVariables.gHotelId + "','" + startDate + "','" + endDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getParamTransactionRegisterReport() " + ex.Message);
				return null;
			}
		}

		public DataTable getMonthlyTransactionRegisterReport(int a_Month, int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportMonthlyTransactionRegister('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMontlyTransactionRegisterReport() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualTransactionRegisterReport(int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportAnnualTransactionRegister('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualTransactionRegisterReport() " + ex.Message);
				return null;
			}
		}

		#endregion

		#region "DAILY TRANSACTIONS"

		public DataTable getDailyTransactions()
		{
			try
			{
				DataTable dtTable = new DataTable("DailyTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportDailyTransactions('" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetDailyTransactions() " + ex.Message);
				return null;
			}
			finally
			{
				rptAdapter.Dispose();
			}
		}

		public DataTable getDailyTransactionsDate(string pDate)
		{
			try
			{
				DataTable dtTable = new DataTable("DailyTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportDailyTransactions('" + GlobalVariables.gHotelId + "','" + pDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetDailyTransactions() " + ex.Message);
				return null;
			}
			finally
			{
				rptAdapter.Dispose();
			}
		}

		public DataTable getMonthlyTransactionsReport(int a_Month, int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportMonthlyTransactions('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyTransactionsReport() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualTransactions(int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportAnnualTransactions('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualTransactions() " + ex.Message);
				return null;
			}
		}

		public DataTable getTransactionsDateRange(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportTransactionsDateRange('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getTransactionsDateRange() " + ex.Message);
				return null;
			}
		}



		#endregion

		#region "SALES SUMMARY"

		public DataTable getSalesReport(DateTime a_trandate)
		{
			try
			{
				DataTable dtTable = new DataTable("FolioTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportSales('" + string.Format("{0:yyyy-MM-dd}", a_trandate) + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetSalesReport() " + ex.Message);
				return null;
			}
		}

		public DataTable getDailySalesReport(string a_Date)
		{
			try
			{
				DataTable dtTable = new DataTable("FolioTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportSales('" + a_Date + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetSalesReport() " + ex.Message);
				return null;
			}
		}

		public DataTable getMonthlySalesReport(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("FolioTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlySales('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlySalesReport() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualSalesReport(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("FolioTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualSales('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualSalesReport() " + ex.Message);
				return null;
			}
		}

		public DataTable getDateRangeSalesReport(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("FolioTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeSales('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeSalesReport() " + ex.Message);
				return null;
			}
		}



		public DataTable getSalesSummary(string pDate)
		{
			try
			{
				DataTable dtTable = new DataTable("FolioTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportSalesSummary('" + pDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetSalesSummary() " + ex.Message);
				return null;
			}
		}

        public DataTable getDailyRevenue(string pStartDate)
        {
            try
            {
                DataTable dtTable = new DataTable("FolioTransactions");
                rptAdapter = new MySqlDataAdapter("call spReportSalesSummary1('" + pStartDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetSalesSummary() " + ex.Message);
                return null;
            }
        }

        public DataTable getDailyTotalMealAmount(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtTable = new DataTable("FolioTransactions");
                rptAdapter = new MySqlDataAdapter("call spReportDailyTotalMealAmount('" + pStartDate + "','" + pEndDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getDailyTotalMealAmount() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyTotalMealAmount(int pMonth, int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("FolioTransactions");
                rptAdapter = new MySqlDataAdapter("call spReportMonthlyMealAmount(" + pMonth + "," + pYear + ",'" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getDailyTotalMealAmount() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualTotalMealAmount(int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("FolioTransactions");
                rptAdapter = new MySqlDataAdapter("call spReportAnnualMealAmount(" + pYear + ",'" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getDailyTotalMealAmount() " + ex.Message);
                return null;
            }
        }

        public DataTable getSalesSummaryForRevenue(string pDate)
        {
            try
            {
                DataTable dtTable = new DataTable("FolioTransactions");
                rptAdapter = new MySqlDataAdapter("call spReportSalesSummary1('" + pDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetSalesSummary() " + ex.Message);
                return null;
            }
        }

		public DataTable getMonthlySalesSummary(int a_Month, int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportMonthlySalesSummary('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyTransactionsReport() " + ex.Message);
				return null;
			}
		}

        public DataTable getMonthlySalesRevenue(int a_Month, int a_Year)
        {
            try
            {
                DataTable transaction = new DataTable();

                rptAdapter = new MySqlDataAdapter("call spReportMonthlySalesSummary1('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getMonthlyTransactionsReport() " + ex.Message);
                return null;
            }
        }

		public DataTable getAnnualSalesSummary(int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportAnnualSalesSummary('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualSalesSummary() " + ex.Message);
				return null;
			}
		}

        public DataTable getDateRangeSalesSummary(string a_StartDate, string a_EndDate)
        {
            try
            {
                DataTable transaction = new DataTable();

                rptAdapter = new MySqlDataAdapter("call spReportDateRangeSalesSummary('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ ReportDateRangeSalesSummary() " + ex.Message);
                return null;
            }
        }


		#endregion

		#region "CITY TRANSFER TRANSACTIONS"

		public DataTable getParamCityTransferTransactions(string startDate, string endDate)
		{
			try
			{
				DataTable cityTransfer = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportParamCityTransferTransactions('" + GlobalVariables.gHotelId + "','" + startDate + "','" + endDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityTransfer);

				return cityTransfer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCityTransferTransactions() " + ex.Message);
				return null;
			}

		}

		public DataTable getMonthlyCityTransferTransactions(int a_Month, int a_Year)
		{
			try
			{
				DataTable cityTransfer = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportMonthlyCityTransferTransactions('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityTransfer);

				return cityTransfer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyCityTransferTransactions() " + ex.Message);
				return null;
			}

		}

		public DataTable getAnnualCityTransferTransactions(int a_Year)
		{
			try
			{
				DataTable cityTransfer = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportAnnualCityTransferTransactions('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityTransfer);

				return cityTransfer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualCityTransferTransactions() " + ex.Message);
				return null;
			}

		}

		#endregion

		#region "CASHIER SHIFT REPORTS"


		public DataTable getMonthlyCashierShiftReport(int a_Month, int a_Year)
		{
			try
			{
				DataTable cityTransfer = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportMonthlyCashierTransactions('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityTransfer);

				return cityTransfer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyCashierTransactions() " + ex.Message);
				return null;
			}

		}

		public DataTable getAnnualCashierShiftReport(int a_Year)
		{
			try
			{
				DataTable cityTransfer = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportAnnualCashierTransactions('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityTransfer);

				return cityTransfer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualCashierTransactions() " + ex.Message);
				return null;
			}

		}


		public DataTable getDateRangeCashierShiftReport(string startDate, string endDate)
		{
			try
			{
				DataTable cityTransfer = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportDateRangeCashierTransactions('" + GlobalVariables.gHotelId + "','" + startDate + "','" + endDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(cityTransfer);

				return cityTransfer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeCashierTransactions() " + ex.Message);
				return null;
			}

		}



		#endregion

		#region "ACTUAL GUEST ARRIVAL"

		public DataTable getActualGuestsArrival(string a_ReportDate)
		{
			try
			{
				DataTable dtTable = new DataTable("ActualArrivals");
				rptAdapter = new MySqlDataAdapter("call spReportActualGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_ReportDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
				return null;
			}
		}

        public DataTable getActualGroupArrival(string pReportDate)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualarrival where date(arrivaldate)='" + pReportDate + "'", GlobalVariables.gPersistentConnection);
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualarrival where date(arrival)='" + pReportDate + "'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getGroupGuestsArrival(string pReportDate)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckin where date(blockfrom)='" + pReportDate + "'", GlobalVariables.gPersistentConnection);
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckin where date(blockfrom)='" + pReportDate + "' and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyGroupGuestsArrival(int pMonth, int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckin where month(blockfrom)=" + pMonth + " and year(blockfrom)=" + pYear + "  and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualGroupGuestsArrival(int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckin where year(blockfrom)=" + pYear + "  and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getDateRangeGroupGuestsArrival(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckin where date(blockfrom)>='" + pStartDate + "' and date(blockfrom)<='" + pEndDate + "' and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getGroupGuestsDeparture(string pReportDate)
        {
            try
            {
                DataTable dtTable = new DataTable("Departures");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckout where date(blockto)='" + pReportDate + "' and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyGroupGuestsDeparture(int pMonth, int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("Departures");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckout where month(blockto)=" + pMonth + " and year(blockto)=" + pYear + "  and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualGroupGuestsDeparture(int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("Departures");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckout where year(blockto)=" + pYear + "  and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getDateRangeGroupGuestsDeparture(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualDeparture");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupexpectedcheckout where date(blockto)>='" + pStartDate + "' and date(blockto)<='" + pEndDate + "' and status!='DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

        public DataTable getCancelledGroups(string pReportDate)
        {
            try
            {
                DataTable dtTable = new DataTable("CancelledGroups");
                //rptAdapter = new MySqlDataAdapter("call spGetGroupCancellations('" + pReportDate + "')", GlobalVariables.gPersistentConnection);
                rptAdapter = new MySqlDataAdapter("select * from vwcancelledgroups", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "CancelledGroups";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

		public DataTable getMonthlyActualGuestsArrival(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ActualArrivals");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyActualGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyActualGuestsArrival() " + ex.Message);
				return null;
			}
		}

        public DataTable getActualMonthlyGroupArrival(int pMonth, int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualarrival where month(arrival)=" + pMonth + " and year(arrival)=" + pYear, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

		public DataTable getAnnualActualGuestsArrival(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ActualArrivals");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualActualGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualActualGuestsArrival() " + ex.Message);
				return null;
			}
		}

        public DataTable getActualAnnualGroupArrival(int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualarrival where year(arrival)=" + pYear, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

		public DataTable getDateRangeActualGuestsArrival(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("ActualArrivals");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeActualGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeActualGuestsArrival() " + ex.Message);
				return null;
			}
		}

        public DataTable getActualDateRangeGroupArrival(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualArrivals");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualarrival where date(arrival) between '" + pStartDate + "' and '" + pEndDate + "'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupArrivals";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGuestsArrival() " + ex.Message);
                return null;
            }
        }

		#endregion

		#region "ACTUAL GUEST DEPARTURE"

		public DataTable getActualGuestsDeparture(string a_ReportDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportActualGuestDeparture('" + GlobalVariables.gHotelId + "','" + a_ReportDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetActualGuestsDeparture() " + ex.Message);
				return null;
			}
		}

        public DataTable getActualGroupDeparture(string pReportDate)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualDepartures");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualdeparture where date(departure)='" + pReportDate + "'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetActualGroupDeparture() " + ex.Message);
                return null;
            }
        }

		public DataTable getMonthlyActualGuestsDeparture(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ActualDeparture");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyActualGuestsDeparture('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyActualGuestsDeparture() " + ex.Message);
				return null;
			}
		}

        public DataTable getMonthlyActualGroupDeparture(int a_Month, int a_Year)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualDeparture");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualdeparture where month(departure)=" + a_Month + " and year(departure)=" + a_Year, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getMonthlyActualGuestsDeparture() " + ex.Message);
                return null;
            }
        }

		public DataTable getAnnualActualGuestsDeparture(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ActualDepartures");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualActualGuestsDeparture('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualActualGuestsDeparture() " + ex.Message);
				return null;
			}
		}

        public DataTable getAnnualActualGroupDeparture(int a_Year)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualDeparture");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualdeparture where year(departure)=" + a_Year, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getMonthlyActualGuestsDeparture() " + ex.Message);
                return null;
            }
        }

		public DataTable getDateRangeActualGuestsDeparture(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("ActualDeparture");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeActualGuestsDeparture('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeActualGuestsDeparture() " + ex.Message);
				return null;
			}
		}

        public DataTable getDateRangeActualGroupDeparture(string a_StartDate, string a_EndDate)
        {
            try
            {
                DataTable dtTable = new DataTable("ActualDeparture");
                rptAdapter = new MySqlDataAdapter("select * from vwgroupactualdeparture where date(departure) between '" + a_StartDate + "' and '" + a_EndDate + "'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);
                dtTable.TableName = "GroupDepartures";

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getMonthlyActualGuestsDeparture() " + ex.Message);
                return null;
            }
        }


		#endregion

		#region "EXPECTED GUEST ARRIVAL"

		public DataTable getExpectedGuestsArrival(string a_ReportDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportExpectedGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_ReportDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetExpectedGuestsArrival() " + ex.Message);
				return null;
			}
		}

		public DataTable getMonthlyExpectedGuestsArrival(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ExpectedArrival");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyExpectedGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyExpectedGuestsArrival() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualExpectedGuestsArrival(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ExpectedArrival");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualExpectedGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualExpectedGuestsArrival() " + ex.Message);
				return null;
			}
		}

		public DataTable getDateRangeExpectedGuestsArrival(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("ExpectedArrival");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeExpectedGuestsArrival('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeExpectedGuestsArrival() " + ex.Message);
				return null;
			}
		}


		#endregion

		#region "EXPECTED GUEST DEPARTURE"

		public DataTable getExpectedGuestsDeparture(string a_ReportDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportExpectedGuestsDeparture('" + GlobalVariables.gHotelId + "','" + a_ReportDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetExpectedGuestsDeparture() " + ex.Message);
				return null;
			}
		}

		public DataTable getMonthlyExpectedGuestsDeparture(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ExpectedDepature");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyExpectedGuestsDeparture('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyExpectedGuestsDeparture() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualExpectedGuestsDeparture(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("ExpectedDeparture");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualExpectedGuestsDeparture('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualExpectedGuestsDeparture() " + ex.Message);
				return null;
			}
		}

		public DataTable getDateRangeExpectedGuestsDeparture(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("ExpectedDeparture");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeExpectedGuestsDeparture('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeExpectedGuestsDeparture() " + ex.Message);
				return null;
			}
		}


		#endregion

		#region "CANCELLED RESERVATIONS"

		public DataTable getCancelledReservation(string a_ReportDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportCancelledReservation('" + GlobalVariables.gHotelId + "','" + a_ReportDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getCancelledReservation() " + ex.Message);
				return null;
			}
		}

		public DataTable getMonthlyCancelledReservations(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("CancelledReservations");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyCancelledReservations('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyCancelledReservations() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualCancelledReservations(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("CancelledReservations");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualCancelledReservations('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualCancelledReservations() " + ex.Message);
				return null;
			}
		}

		public DataTable getDateRangeCancelledReservations(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("CancelledReservations");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeCancelledReservations('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeCancelledReservations() " + ex.Message);
				return null;
			}
		}


		#endregion

		#region "VOIDED TRANSACTIONS"


		public DataTable getVoidedTransactionsReport(string a_ReportDate)
		{
			try
			{
				DataTable datatableTransactions = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportVoidedTransactions('" + a_ReportDate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

				dataAdapter.Fill(datatableTransactions);

				return datatableTransactions;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getVoidedTransactionsReport() " + ex.Message);
				return null;
			}

		}

		public DataTable getMonthlyVoidTransactions(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("VoidTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyVoidTransactions('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyVoidTransactions() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualVoidTransactions(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("VoidTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualVoidTransactions('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualVoidTransactions() " + ex.Message);
				return null;
			}
		}

		public DataTable getDateRangeVoidTransactions(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("VoidTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeVoidTransactions('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeVoidTransactions() " + ex.Message);
				return null;
			}
		}


		#endregion

		#region "ROOM OCCUPANCY"

		public DataTable getRoomOccupancy(DateTime pReportDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spRoomOccupancyReport('" + string.Format("{0:yyyy-MM-dd}", pReportDate) + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getRoomOccupancy() " + ex.Message);
				return null;
			}
		}

		public DataTable getRoomOccupancyGraph(string a_Date)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportRoomOccupancyGraph('" + a_Date + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getRoomOccupancyGraph() " + ex.Message);
				return null;
			}
		}

		public DataTable getMonthlyRoomOccupancyGraph(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("RoomOccupancy");
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyRoomOccupancyGraph('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyRoomOccupancyGraph() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualRoomOccupancyGraph(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable("RoomOccupancy");
				rptAdapter = new MySqlDataAdapter("call spReportAnnualRoomOccupancyGraph('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualRoomOccupancyGraph() " + ex.Message);
				return null;
			}
		}

		public DataTable getDateRangeRoomOccupancyGraph(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable("RoomOccupancy");
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeRoomOccupancyGraph('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeRoomOccupancyGraph() " + ex.Message);
				return null;
			}
		}


		#endregion

		#region "ENGINEERING JOB REPORTS"

		public DataTable getOutOfOrderRooms(string pDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportOutOfOrderRooms('" + GlobalVariables.gHotelId + "','" + pDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetOutOfOrderRooms() " + ex.Message);
				return null;
			}
		}

		public DataTable getMonthlyOutOfOrderRooms(int a_Month, int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportMonthlyOutOfOrderRooms('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getMonthlyOutOfOrderRooms() " + ex.Message);
				return null;
			}
		}

		public DataTable getAnnualOutOfOrderRooms(int a_Year)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportAnnualOutOfOrderRooms('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getAnnualOutOfOrderRooms() " + ex.Message);
				return null;
			}
		}

		public DataTable getDateRangeOutOfOrderRooms(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportDateRangeOutOfOrderRooms('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getDateRangeOutOfOrderRooms() " + ex.Message);
				return null;
			}
		}


		#endregion

		#region " CHANGE LOG INQUIRY "

		public DataTable getChangesLog(string startDate, string endDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetChangesLogs('" + startDate + "','" + endDate + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

        public DataTable searchChangesLog(string pSearchText, string pSearchCriteria)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("select * from changes_log where "+ pSearchCriteria + " like '%" + pSearchText + "%'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

		#endregion

		#region "OCCUPANCY FORECAST"

		public DataTable getExpectedArrivalForOccupancyForecast(string date)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetFOExpectedArrival('" + GlobalVariables.gHotelId + "','" + date + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);


				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getExpectedDepartureForOccupancyForecast(string date)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetFOExpectedDeparture('" + GlobalVariables.gHotelId + "','" + date + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getExpectedInHouseForOccupancyForecast(string date)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetFOExpectedInHouse('" + GlobalVariables.gHotelId + "','" + date + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public int getRoomCount()
		{
			int roomCount = 0;
			try
			{

				MySqlCommand selectCommand = new MySqlCommand("call spGetFORoomCount('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				roomCount = int.Parse(selectCommand.ExecuteScalar().ToString());

				return roomCount;
			}
			catch
			{
				return 0;
			}
		}

		#endregion

		#region "NonGuestTransactions"

		public DataTable getDateRangeNonGuestChargesTransactions(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportDateRangeChargesNonGuestTransactions('" + a_StartDate + "','" + a_EndDate + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


		public DataTable getDateRangeNonGuestPaymentsTransactions(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportDateRangePaymentsNonGuestTransactions('" + a_StartDate + "','" + a_EndDate + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


		public DataTable getDateRangeNonGuestPaidOutTransactions(string a_StartDate, string a_EndDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spReportDateRangePaidOutNonGuestTransactions('" + a_StartDate + "','" + a_EndDate + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		#endregion

		#region EVENT MANAGEMENT
		//>> by Genny

		//>> Banquet Event Contract
		public DataSet getBanquetEventContract(string pFolioID)
		{
			try
			{
				oDtReport = new DataSet();
				rptAdapter = new MySqlDataAdapter("call spreportbanqueteventcontractheader('" + pFolioID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(oDtReport, "Main");

				return oDtReport;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetBanquetEventContract() " + ex.Message);
				return null;
			}
		}

        public DataTable getBanquetDetails(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                string banquetQuery = "select * from vwbanquetcontractdetails where folioid = '" + pFolioID + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(banquetQuery, GlobalVariables.gPersistentConnection);
                da.Fill(dt);
                dt.TableName = "ContractDetails";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getBanquetMeals(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                //string mealQuery = "select date(eventDate) as mealDate, fGetLiveInSnacks('" + pFolioID + "',date(eventDate)), fGetLiveOutSnacks('" + pFolioID + "',date(eventDate)), fGetLiveInMeals('" + pFolioID + "',date(eventDate)), fGetLiveOutMeals('" + pFolioID + "',date(eventDate)), " +
                //    "concat(max(liveInPax),' pax') as liveInPax, concat(max(liveOutPax),' pax') as liveOutPax, fGetLiveOutTotal('" + pFolioID + "'), folioid from event_meal_requirements where event_meal_requirements.folioid='" + pFolioID + "' group by mealDate";
                string mealQuery = "select * from vwbanquetcontractmeals where folioid='" + pFolioID + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(mealQuery, GlobalVariables.gPersistentConnection);
                da.Fill(dt);
                dt.TableName = "ContractMeals";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getBanquetRooms(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                //string roomQuery = "select * from vwbanquetcontractrooms where folioid='" + pFolioID + "'";
                string roomQuery = "call spGetBanquetContractRooms('" + pFolioID + "')";
                MySqlDataAdapter da = new MySqlDataAdapter(roomQuery, GlobalVariables.gPersistentConnection);
                da.Fill(dt);
                dt.TableName = "ContractRooms";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public DataTable getBookingSheet(string pFolioID)
		{
			try
			{
                DataTable dt = new DataTable();
				rptAdapter = new MySqlDataAdapter("select * from vwbookingsheetmain where folioid='" + pFolioID + "'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "MainSheet";

				return dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetBookingSheet() " + ex.Message);
				return null;
			}
		}

        public DataTable getContractAmendments(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                rptAdapter = new MySqlDataAdapter("select * from ContractAmmendments where folioid='" + pFolioID + "' and HotelID = " + GlobalVariables.gHotelId + " and StateFlag != 'DELETED'", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "ContractAmendments";

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ GetContractAmendments() " + ex.Message);
                return null;
            }
        }

        public DataTable getFoodBevSheet(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "select * from vwfoodandbevsheet where folioid='" + pFolioID + "'";
                rptAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "FoodBevSheet";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getWeddingDetailsSheet(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "select * from vwbookingsheetweddingdetails where folioid='" + pFolioID + "'";
                rptAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "WeddingDetails";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventTransactions(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from vweventtransactions where folioid='" + pFolioID + "'";

                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "EventTransactions";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFolioEventRequirements(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select requirementid, group_concat(description separator ', ') as description from event_requirements where folioid='" + pFolioID + "' and lcase(requirementid) not like '%inclusions%' group by requirementid";

                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "FolioEventRequirements";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFolioInclusions(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from folioinclusions where folioid='" + pFolioID + "'";

                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "FolioInclusions";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getGroupRequirements(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                //string sql = "select 1, folioid, description as memo, createdby, createtime, updatedby, updatetime from event_requirements where folioid='" + pFolioID + "'";
                string sql = "select * from vwgroupinclusions where folioid='" + pFolioID + "'";

                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "FolioInclusions";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getRoomBlockingRequirements(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();
                //string sql = "call spreportroomrequirements('" + pFolioID + "')";
                //string sql = "select event_rooms.*, max(rate) as rate, days from event_rooms left join folio on (event_rooms.folioid=folio.masterfolio) left join folioschedules on (folioschedules.folioid=folio.folioid and event_rooms.roomtype=folioschedules.roomtype) where event_rooms.folioid='" + pFolioID + "' group by event_rooms.roomtype";
                //string sql = "select * from vwroomrequirements where folioid='" + pFolioID + "'";
                string sql = "select distinct 1 as roomreqid, folio.folioid, roomtype, count(noofadults) as noofpax, count(noofadults) as guaranteedpax, count(roomtype) as noofrooms, count(roomtype) as guaranteedrooms, 0 as blockedrooms, folio.remarks, folio.createdby, folio.createtime, folio.updatedby, folio.updatetime, rate, days, date(folioschedules.fromdate) as fromdate, date(folioschedules.todate) as todate from folio, folioschedules where folio.folioid=folioschedules.folioid" +
                    " and folio.masterfolio='" + pFolioID + "' and folio.status!='CANCELLED' and folio.status!='REMOVED' and folio.status!='DELETED' " +
                    "group by fromdate, roomtype union select distinct roomblock.blockid as roomreqid, roomblock.folioid, (select roomtypecode from rooms where roomid=blockingdetails.roomid) as roomtype, " +
                    "count(roomid) as noofpax, count(roomid) as guaranteedpax, count(roomid) as noofrooms, count(roomid) as guaranteedrooms, count(roomid) as blockedrooms, '' as remarks, " +
                    "roomblock.createdby,now() as createtime, roomblock.updatedby, now() as updatetime, 0 as rate, 0 as days, blockingdetails.blockfrom as fromdate, blockingdetails.blockto as toDate from roomblock, blockingdetails where " +
                    "roomblock.blockid=blockingdetails.blockid and roomblock.folioid='" + pFolioID + "' group by fromdate, roomtype";
                    
                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "Room_Requirements";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventArrangements(string pFolioID, string pHeader)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from vwgroupbookingdropdown where fieldname='" + pHeader + "' and folioid='" + pFolioID + "'";

                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = pHeader;

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMealRequirements(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();

                string sql = "select * from vwbookingsheetfoodandbev where folioid='" + pFolioID + "' group by eventdate, mealtype, menuitemcode order by id";
                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "MealRequirements";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getSummarizedMealRequirements(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();

                string sql = "select * from vwbookingsheetfoodandbev where folioid='" + pFolioID + "' group by eventdate, mealtype";
                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "MealRequirements";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getRoomRequirements(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();

                string sql = "select * from vwbookingsheetrooms where folioid='" + pFolioID + "'";
                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "RoomRequirements";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventRequirements(string pFolioID)
        {
            try
            {
                DataTable dt = new DataTable();

                string sql = "select * from vwbookingsheetmaintenance where folioid='" + pFolioID + "'";
                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "EventRequirements";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventRequirementsForMaintenance(string pFolioID, string pCondition)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from vwbookingsheetmaintenance where folioid='" + pFolioID + "' " + pCondition;
                rptAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dt);
                dt.TableName = "EventRequirements";

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		#endregion

		#region "SALES SUMMARY BY SUB-ACCOUNT"

		public DataTable getSalesSummaryBySubAccount(string a_trandate)
		{
			try
			{
				DataTable dtTable = new DataTable("FolioTransactions");
				rptAdapter = new MySqlDataAdapter("call spReportSalesSummaryBySubAccount('" + a_trandate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable getMonthlySalesSummaryBySubAccount(int a_Month, int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportMonthlySalesSummaryBySubAccount('" + GlobalVariables.gHotelId + "','" + a_Month + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable getAnnualSalesSummaryBySubAccount(int a_Year)
		{
			try
			{
				DataTable transaction = new DataTable();

				rptAdapter = new MySqlDataAdapter("call spReportAnnualSalesSummaryBySubAccount('" + GlobalVariables.gHotelId + "','" + a_Year + "')", GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//public DataTable getDateRangeSalesSummaryBySubAccount(string a_StartDate, string a_EndDate)
		//{
		//    try
		//    {
		//        DataTable transaction = new DataTable();

		//        rptAdapter = new MySqlDataAdapter("call spReportDateRangeSalesSummary('" + GlobalVariables.gHotelId + "','" + a_StartDate + "','" + a_EndDate + "')", GlobalVariables.gPersistentConnection);
		//        rptAdapter.Fill(transaction);

		//        return transaction;
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show("EXCEPTION: @ ReportDateRangeSalesSummary() " + ex.Message);
		//        return null;
		//    }
		//}


		#endregion

		#region " RESERVATIONS REPORT [FOR HOTEL REVENUE] "

        public DataTable getColumnsForHotelRevenue()
        {
            try
            {
                string sql = "select * from hotelrevenuemapping";
                DataTable _oDataTable = new DataTable();
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                _oDataAdapter.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void postHotelRevenue(string pDate)
        {
            MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
            {
                DataTable _oDataTable = new DataTable();
                string query = "select mapColumn, columnName from hotelrevenuemapping";
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                _oDataAdapter.Fill(_oDataTable);

                DataColumn _newColumn = new DataColumn();
                _newColumn.DataType = System.Type.GetType("System.String");
                _newColumn.ColumnName = "value";
                _oDataTable.Columns.Add(_newColumn);

                DataTable _dtReservationSummary = getDailyReservationSummary(pDate);
                DataTable _dtSalesRevenue = getDailyRevenue(pDate);
                DataTable _dtSalesSubAccount = getSalesSummaryBySubAccount(pDate);

                // for reservation summary values
                foreach (DataRow dRowSummary in _dtReservationSummary.Rows)
                {
                    foreach (DataRow dRowTable in _oDataTable.Rows)
                    {
                        if (dRowTable["columnName"].ToString().ToUpper() == dRowSummary["description"].ToString().ToUpper())
                        {
                            dRowTable["value"] = dRowSummary["rooms"].ToString();
                            dRowTable.AcceptChanges();

                            break;
                        }
                    }
                }
                _oDataTable.AcceptChanges();

                // for revenue values
                foreach (DataRow dRowSummary in _dtSalesRevenue.Rows)
                {
                    foreach (DataRow dRowTable in _oDataTable.Rows)
                    {
                        if (dRowTable["columnName"].ToString().ToUpper() == dRowSummary["transactionCode"].ToString().ToUpper())
                        {
                            dRowTable["value"] = dRowSummary["netBaseAmount"].ToString();
                            dRowTable.AcceptChanges();
                            break;
                        }
                    }
                }
                _oDataTable.AcceptChanges();

                // for sales sub account
                foreach (DataRow dRowSummary in _dtSalesSubAccount.Rows)
                {
                    foreach (DataRow dRowTable in _oDataTable.Rows)
                    {
                        if (dRowTable["columnName"].ToString().ToUpper() == dRowSummary["subAccount"].ToString().ToUpper())
                        {
                            dRowTable["value"] = dRowSummary["debit"].ToString();
                            dRowTable.AcceptChanges();
                            break;
                        }
                    }
                }
                _oDataTable.AcceptChanges();

                string postDateQuery = "insert into hotelrevenue(transactiondate) values('" + pDate + "')";

                try
                {
                    MySqlCommand cmdPostDate = new MySqlCommand(postDateQuery, GlobalVariables.gPersistentConnection);
                    cmdPostDate.Transaction = _oDBTrans;
                    cmdPostDate.ExecuteNonQuery();
                }
                catch
                {
                }

                foreach (DataRow dRow in _oDataTable.Rows)
                {
                    if (dRow["mapColumn"].ToString().ToUpper() != "TRANSACTIONDATE")
                    {
                        string postTrans = "update hotelrevenue set " + dRow["mapColumn"].ToString() + "='" + dRow["value"].ToString() + "' where date(transactiondate)='" + pDate + "'";
                        MySqlCommand cmdPostTrans = new MySqlCommand(postTrans, GlobalVariables.gPersistentConnection);
                        cmdPostTrans.Transaction = _oDBTrans;
                        cmdPostTrans.ExecuteNonQuery();
                    }
                }

                _oDBTrans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _oDBTrans.Rollback();
            }
        }

        public DataTable getHotelRevenue(string pStartDate, string pEndDate)
        {
            try
            {
                string query = "select * from hotelrevenue where date(transactiondate)>='" + pStartDate + "' and date(transactiondate)<='" + pEndDate + "'";
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable dTable = new DataTable();
                _dataAdapter.Fill(dTable);

                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getMonthlyHotelRevenue(int pStartMonth, int pEndMonth, int pStartYear, int pEndYear)
        {
            try
            {
                string query = "call spGetMonthlyHotelRevenue(" + pStartMonth+ "," + pEndMonth + "," + pStartYear + "," + pEndYear + ")";
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable dTable = new DataTable();
                _dataAdapter.Fill(dTable);

                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAnnualHotelRevenue(int pStartYear, int pEndYear)
        {
            try
            {
                string query = "call spGetAnnualHotelRevenue(" + pStartYear + "," + pEndYear + ")";
                MySqlDataAdapter _dataAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable dTable = new DataTable();
                _dataAdapter.Fill(dTable);

                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getDailyReservationSummary(string pDate)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spGetDailyFolioComputation(" + GlobalVariables.gHotelId + ",'" + pDate + "')", GlobalVariables.gPersistentConnection);

                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

		public DataTable getDailyCancelledNoShowReservations(DateTime pDate, DateTime pEndDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call getDailyCancelledNoShowReservations('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getMonthlyCancelledNoShowReservations(int pMonth, int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyCancelledNoShowReservations('" + GlobalVariables.gHotelId + "','" + pMonth + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getAnnualCancelledNoShowReservations(int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualCancelledNoShowReservations('" + GlobalVariables.gHotelId + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getDailyReservationsByAccountType(DateTime pDate, DateTime pEndDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetDailyReservationsByAccountType('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getMonthlyReservationsByAccountType(int pMonth, int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyReservationsByAccountType('" + GlobalVariables.gHotelId + "','" + pMonth + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getAnnualReservationsByAccountType(int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualReservationsByAccountType('" + GlobalVariables.gHotelId + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		#endregion

		#region "RESERVATION SOURCE SUMMARY"


		public DataTable getDailyReservationSummaryBySource(DateTime pDate, DateTime pEndDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetDailyReservationSummaryBySource('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		public DataTable getMonthlyReservationSummaryBySource(int pMonth, int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyReservationSummaryBySource('" + GlobalVariables.gHotelId + "','" + pMonth + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		public DataTable getAnnualReservationSummaryBySource(int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualReservationSummaryBySource('" + GlobalVariables.gHotelId + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		#endregion

		#region "WALKIN / PERSONAL & CORPORATE"

		public DataTable getAnnualWalkinPersonalFolio(int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualWalkinPersonalFolio('" + GlobalVariables.gHotelId + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public DataTable getMonthlyWalkinPersonalFolio(int pMonth, int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyWalkinPersonalFolio('" + GlobalVariables.gHotelId + "','" + pMonth + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public DataTable getDailyWalkinPersonalFolio(DateTime pDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetDailyWalkinPersonalFolio('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}



		public DataTable getAnnualWalkinCorporateFolio(int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualWalkinCorporateFolio('" + GlobalVariables.gHotelId + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public DataTable getMonthlyWalkinCorporateFolio(int pMonth, int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyWalkinCorporateFolio('" + GlobalVariables.gHotelId + "','" + pMonth + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public DataTable getDailyWalkinCorporateFolio(DateTime pDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetDailyWalkinCorporateFolio('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		#endregion

		#region "AVERAGE ROOM RATE"

		public DataTable getDailyAverageRoomRate(DateTime pDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetDailyAverageRoomRate('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getMonthlyAverageRoomRate(int pMonth, int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyAverageRoomRate('" + GlobalVariables.gHotelId + "','" + pMonth + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getAnnualAverageRoomRate(int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualAverageRoomRate('" + GlobalVariables.gHotelId + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		#endregion


		#region "AVERAGE ROOM RATE PER GUEST"

		public DataTable getDailyAverageRoomRatePerGuest(DateTime pDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetDailyAverageRoomRatePerGuest('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd}", pDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getMonthlyAverageRoomRatePerGuest(int pMonth, int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyAverageRoomRatePerGuest('" + GlobalVariables.gHotelId + "','" + pMonth + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getAnnualAverageRoomRatePerGuest(int pYear)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualAverageRoomRatePerGuest('" + GlobalVariables.gHotelId + "','" + pYear + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		#endregion

		#region "GUEST A/R"

		public DataTable getDailyGuestAR(DateTime pDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetDailyGuestAR('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getMonthlyGuestAR(DateTime pDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetMonthlyGuestAR('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public DataTable getAnnualGuestAR(DateTime pLastYearDate)
		{
			try
			{
				DataTable dtTable = new DataTable();
				rptAdapter = new MySqlDataAdapter("call spGetAnnualGuestAR('" + GlobalVariables.gHotelId + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pLastYearDate) + "')", GlobalVariables.gPersistentConnection);

				rptAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		#endregion

		#region "Functions Rooms [Total] "

		public int getDailyTotalFunctions(DateTime pDate)
		{
			try
			{
				int _totalFunctions = 0;

				string _sqlStr = "call spGetDailyTotalFunctions('" +
									   GlobalVariables.gHotelId + "','" +
									   string.Format("{0:yyyy-MM-dd}", pDate) + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				object obj = _selectCommand.ExecuteScalar();

				try
				{
					_totalFunctions = int.Parse(obj.ToString());
				}
				catch { }


				return _totalFunctions;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getMonthlyTotalFunctions(int pMonth, int pYear)
		{
			try
			{
				int _totalFunctions = 0;
				string _sqlStr = "call spGetMonthlyTotalFunctions('" +
									   GlobalVariables.gHotelId + "','" +
									   pMonth + "','" +
									   pYear + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				object obj = _selectCommand.ExecuteScalar();

				try
				{
					_totalFunctions = int.Parse(obj.ToString());
				}
				catch { }


				return _totalFunctions;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}


		public int getAnnualTotalFunctions(int pYear)
		{
			try
			{
				int _totalFunctions = 0;
				string _sqlStr = "call spGetAnnualTotalFunctions('" +
									   GlobalVariables.gHotelId + "','" +
									   pYear + "')";


				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				object obj = _selectCommand.ExecuteScalar();

				try
				{
					_totalFunctions = int.Parse(obj.ToString());
				}
				catch { }


				return _totalFunctions;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}


		#endregion

		#region "Room Stay-over"

		public int getDailyTotalRoomStayOver(DateTime pDate)
		{
			try
			{
				int _totalFunctions = 0;

				string _sqlStr = "call spGetDailyTotalRoomStayOver('" +
									   GlobalVariables.gHotelId + "','" +
									   string.Format("{0:yyyy-MM-dd}", pDate) + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				object obj = _selectCommand.ExecuteScalar();

				try
				{
					_totalFunctions = int.Parse(obj.ToString());
				}
				catch { }


				return _totalFunctions;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getMonthlyTotalRoomStayOver(int pMonth, int pYear)
		{
			try
			{
				int _totalFunctions = 0;
				string _sqlStr = "call spGetMonthlyTotalRoomStayOver('" +
									   GlobalVariables.gHotelId + "','" +
									   pMonth + "','" +
									   pYear + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				object obj = _selectCommand.ExecuteScalar();

				try
				{
					_totalFunctions = int.Parse(obj.ToString());
				}
				catch { }


				return _totalFunctions;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public int getAnnualTotalRoomStayOver(int pYear)
		{
			try
			{
				int _totalFunctions = 0;
				string _sqlStr = "call spGetAnnualTotalRoomStayOver('" +
									   GlobalVariables.gHotelId + "','" +
									   pYear + "')";

				MySqlCommand _selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				object obj = _selectCommand.ExecuteScalar();

				try
				{
					_totalFunctions = int.Parse(obj.ToString());
				}
				catch { }


				return _totalFunctions;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}


		#endregion


		public double getExpectedRoomSalesOccupancyForecast(string date)
		{
			double sales = 0;
			try
			{
				DataTable dtTable = new DataTable();
				MySqlCommand selectCommand = new MySqlCommand("call spGetFOExpectedRoomSales('" + GlobalVariables.gHotelId + "','" + date + "')", GlobalVariables.gPersistentConnection);
				string strSales = selectCommand.ExecuteScalar().ToString();

				sales = double.Parse(strSales);

				return sales;
			}
			catch
			{
				return 0;
			}

		}

		public double getActualRoomSalesOccupancyForecast(string date)
		{
			double sales = 0;
			try
			{
				DataTable dtTable = new DataTable();
				MySqlCommand selectCommand = new MySqlCommand("call spGetFOActualRoomSales('" + GlobalVariables.gHotelId + "','" + date + "')", GlobalVariables.gPersistentConnection);
				string strSales = selectCommand.ExecuteScalar().ToString();

				sales = double.Parse(strSales);

				return sales;
			}
			catch
			{
				return 0;
			}

		}


		public DataTable getRooms()
		{
			try
			{
				DataTable dtRooms = new DataTable();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRooms('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(dtRooms);
				dataAdapter.Dispose();

				//DataColumn[] primaryKey = new DataColumn[1];
				//primaryKey[0] = oRoom.Tables["Rooms"].Columns["RoomId"];
				//oRoom.Tables["Rooms"].PrimaryKey = primaryKey;

				return dtRooms;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		#region "Room Revenue"

		public DataTable getRoomRevenuePerDay(string pDate)
		{
			try
			{
				DataTable _dtTemp = new DataTable();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetRoomRevenuePerDay('" + GlobalVariables.gHotelId + "','" + pDate + "')", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(_dtTemp);
				dataAdapter.Dispose();

				return _dtTemp;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public DataTable getRoomRevenuePerMonth(int pMonth, int pYear)
		{
			try
			{
				DataTable _dtTemp = new DataTable();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetRoomRevenuePerMonth('" + GlobalVariables.gHotelId + "'," + pMonth + "," + pYear + ")", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(_dtTemp);
				dataAdapter.Dispose();

				return _dtTemp;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public DataTable getRoomRevenuePerYear(int pYear)
		{
			try
			{
				DataTable _dtTemp = new DataTable();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetRoomRevenuePerYear('" + GlobalVariables.gHotelId + "'," + pYear + ")", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(_dtTemp);
				dataAdapter.Dispose();

				return _dtTemp;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

        public DataTable getRoomRevenuePerDateRange(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable _dtTemp = new DataTable();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetRoomRevenuePerDateRange('" + GlobalVariables.gHotelId + "','" + pStartDate + "','" + pEndDate + "')", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(_dtTemp);
                dataAdapter.Dispose();

                return _dtTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

		#endregion


		#region "FROM HOUSEKEEPING SYSTEM"

		public DataTable HK_GetHousekeepingReport(string fromDate, string toDate)
		{
			DataTable dTable = new DataTable();
			try
			{
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spHK_HousekeepingReport('" + fromDate + "','" + toDate + "')", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				throw new Exception("EXCEPTION @GetHousekeepingReport():" + ex.Message);

			}
		}

		public DataTable HK_GetHousekeepingReportByHousekeepers(string fromDate, string toDate)
		{
			DataTable dTable = new DataTable();
			try
			{
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spHK_HousekeepingReportByHousekeepers('" + fromDate + "','" + toDate + "')", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				throw new Exception("EXCEPTION @GetHousekeepingReportByHousekeepers():" + ex.Message);

			}
		}

		public DataTable HK_GetCategories()
		{
			DataTable dTable = new DataTable();
			try
			{
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spHK_SelectMinibarCategories()", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				throw new Exception("EXCEPTION @spGetCategories():" + ex.Message);

			}
		}

		public DataTable HK_GetMinibarItemsList(int CategoryID)
		{
			DataTable dTable = new DataTable();
			try
			{
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spHK_SelectMinbarItemsList(" + CategoryID + ")", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				throw new Exception("EXCEPTION @spGetCategories():" + ex.Message);

			}
		}

		public DataTable HK_ReportMinibarSalesRange(string fromDate, string toDate)
		{
			DataTable dTable = new DataTable();
			try
			{
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spHK_ReportDateRangeMinibarSales('" + fromDate + "','" + toDate + "')", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				throw new Exception("EXCEPTION @spHK_ReportDateRangeMinibarSales():" + ex.Message);

			}
		}

		public DataTable HK_GetHousekeeperSummary(string fromDate, string toDate)
		{
			DataTable dTable = new DataTable();
			try
			{
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spHK_ReportHousekeepingSummary('" + fromDate + "','" + toDate + "')", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				throw new Exception("EXCEPTION @spHK_ReportHousekeepingSummary():" + ex.Message);

			}
		}

		#endregion


		public DataTable getHighBalanceGuests(DateTime pReportDate)
		{
			try
			{
				DataTable dtGuests = new DataTable();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spReportHighBalanceGuests('" + GlobalVariables.gHotelId + "','" + pReportDate.ToString("yyyy-MM-dd") + "')", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(dtGuests);
				dataAdapter.Dispose();

				return dtGuests;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable getTransactionCodes()
		{
			try
			{
				DataTable tmpTable = new DataTable();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectTransactionCodes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(tmpTable);

				return tmpTable;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataTable getDailyHotelRevenue(DateTime startDate, DateTime endDate)
		{
			try
			{
				string strStartDate = startDate.ToString("yyyy-MM-dd");
				string strEndDate = endDate.ToString("yyyy-MM-dd");

				DataTable transaction = new DataTable();

				string query = "call spReportDailyHotelRevenue('"
									+ GlobalVariables.gHotelId + "','"
									+ strStartDate + "','"
									+ strEndDate + "')";


				rptAdapter = new MySqlDataAdapter(query,
												  GlobalVariables.gPersistentConnection);
				rptAdapter.Fill(transaction);

				return transaction;
			}
			catch
			{
                try
                {

                    string strStartDate = startDate.ToString("yyyy-MM-dd");
                    string strEndDate = endDate.ToString("yyyy-MM-dd");

                    DataTable transaction = new DataTable();

                    string query = "call spReportDailyRevenue('"
                                        + GlobalVariables.gHotelId + "','"
                                        + strStartDate + "','"
                                        + strEndDate + "')";


                    rptAdapter = new MySqlDataAdapter(query,
                                                      GlobalVariables.gPersistentConnection);
                    rptAdapter.Fill(transaction);

                    return transaction;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION: @ getParamTransactionRegisterReport() " + ex.Message);
                    return null;
                }
			}
		}

        public DataTable getRoomingList(string pFolioID)
        {
            try
            {
                string query = "";
                if (pFolioID.StartsWith("F"))
                {
                    query = "call spGetRoomingList('" + pFolioID + "')";
                }
                else
                {
                    query = "call spGetIndividualRoomingList('" + pFolioID + "')";
                }
                DataTable transaction = new DataTable();
                rptAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getRoomingList() " + ex.Message);
                return null;
            }
        }

        public DataTable getGroupedRoomingList()
        {
            try
            {
                string query = "call spGetGroupedRoomingList()";
                DataTable transaction = new DataTable();
                rptAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getRoomingList() " + ex.Message);
                return null;
            }
        }

        public DataTable getDateRangeSalesExecutiveReport(string pStartDate, string pEndDate, string pSalesExecutive)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportDateRangeSalesExecutive('" + pStartDate + "','" + pEndDate + "'," + GlobalVariables.gHotelId + ",'" + pSalesExecutive + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getDateRangeSalesExecutiveReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlySalesExecutiveReport(int pMonth, int pYear, string pSalesExecutive)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportMonthlyExecutive(" + pMonth + "," + pYear + "," + GlobalVariables.gHotelId + ",'" + pSalesExecutive + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getMonthlySalesExecutiveReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualSalesExecutiveReport(int pYear, string pSalesExecutive)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportAnnualSalesExecutive(" + pYear + "," + GlobalVariables.gHotelId + ",'" + pSalesExecutive + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getAnnualSalesExecutiveReport() " + ex.Message);
                return null;
            }
        }

        //>>for Sales Production Report
        public DataTable getDateRangeSalesProductReport(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportDateRangeSalesProduction('" + pStartDate + "','" + pEndDate + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getDateRangeSalesProductionReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlySalesProductionReport(int pMonth, int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportMonthlySalesProduction(" + pMonth + "," + pYear + "," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getMonthlySalesProductionReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualSalesProductionReport(int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportAnnualSalesProduction(" + pYear + "," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getAnnualSalesProductionReport() " + ex.Message);
                return null;
            }
        }

        //>>for Drivers Commission Report
        public DataTable getDateRangeDriversCommissionReport(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportDateRangeDriversSales('" + pStartDate + "','" + pEndDate + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ spReportDateRangeDriversSales() " + ex.Message);
                return null;
            }
        }

        public DataTable getMonthlyDriversCommissionReport(int pMonth, int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportMonthlyDriversSales(" + pMonth + "," + pYear + "," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ spReportMonthlyDriversSales() " + ex.Message);
                return null;
            }
        }

        public DataTable getAnnualDriversCommissionReport(int pYear)
        {
            try
            {
                DataTable dtTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spReportAnnualDriversSales(" + pYear + "," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ spReportAnnualDriversSales() " + ex.Message);
                return null;
            }
        }

        public DataTable getNationalityReport(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spGetDateRangeNationalityReport('" + pStartDate + "','" + pEndDate + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dTable);

                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getNationalityReport() " + ex.Message);
                return null;
            }
        }

        public DataTable getSalesAndMarketingRevenueReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                string strStartDate = startDate.ToString("yyyy-MM-dd");
                string strEndDate = endDate.ToString("yyyy-MM-dd");

                DataTable transaction = new DataTable();

                string query = "call spReportSalesAndMarketingRevenue('"
                                    + strStartDate + "','"
                                    + strEndDate + "')";


                rptAdapter = new MySqlDataAdapter(query,
                                                  GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ spReportSalesAndMarketingRevenue() " + ex.Message);
                return null;
            }
        }

        public DataTable getStatementOfAccount(string pFolioID)
        {
            try
            {
                DataTable dTable = new DataTable();
                rptAdapter = new MySqlDataAdapter("call spGetStatementOfAccount('" + pFolioID + "')", GlobalVariables.gPersistentConnection);
                rptAdapter.Fill(dTable);

                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getStatementOfAccountReport() " + ex.Message);
                return null;
            }
        }

        /* FP - SCR - 00147 #1 [08.02.2010]
         * added for Statistical Reports */
        public DataTable getDailyStatisticalReport(string pDate, string pSortType)
        {
            try
            {
                /* Gene
                 * 28-Feb-12
                 * Used stored procedure instead of "in-code" queries
                 */
                // Old Code
                //string _sqlQuery = "";
                //switch (pSortType.ToUpper())
                //{
                //    case "EVENT TYPE":
                //        _sqlQuery = "select eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and '" + pDate + "' between date(folio.fromdate) and date(folio.todate) group by folio.folioid order by `event type`, `total revenue` desc";
                //        break;

                //    case "CLIENT TYPE":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and '" + pDate + "' between date(folio.fromdate) and date(folio.todate) group by folio.folioid order by `client type`, `total revenue` desc";
                //        break;

                //    case "SOURCE":
                //        _sqlQuery = "select folio.source as `Source`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and '" + pDate + "' between date(folio.fromdate) and date(folio.todate) group by folio.folioid order by `source`, `total revenue` desc";
                //        break;

                //    case "MARKET SEGMENT":
                //        _sqlQuery = "select folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and '" + pDate + "' between date(folio.fromdate) and date(folio.todate) group by folio.folioid order by `market segment`, `total revenue` desc";
                //        break;

                //    case "COMPANY NAME":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and '" + pDate + "' between date(folio.fromdate) and date(folio.todate) group by folio.folioid order by `company name`, `total revenue` desc";
                //        break;
                //}
                
                //MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter _cmd = new MySqlDataAdapter("call spGetDateRangeStatisticalReport('" + pDate + "', '" + pDate + "', '" + pSortType.ToUpper() + "')", GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getDailyStatisticalReport : " + ex.Message);
            }
        }

        public DataTable getMonthlyStatisticalReport(int pMonth, int pYear, string pSortType)
        {
            try
            {
                /* Gene
                 * 28-Feb-12
                 * Used stored procedure instead of "in-code" queries
                 */
                // Old Code
                //string _sqlQuery = "";
                //switch (pSortType.ToUpper())
                //{
                //    case "EVENT TYPE":
                //        _sqlQuery = "select eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate)=" + pMonth + " and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `event type`, `total revenue` desc";
                //        break;

                //    case "CLIENT TYPE":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate)=" + pMonth + " and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `client type`, `total revenue` desc";
                //        break;

                //    case "SOURCE":
                //        _sqlQuery = "select folio.source as `Source`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate)=" + pMonth + " and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `source`, `total revenue` desc";
                //        break;

                //    case "MARKET SEGMENT":
                //        _sqlQuery = "select folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate)=" + pMonth + " and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `market segment`, `total revenue` desc";
                //        break;

                //    case "COMPANY NAME":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate)=" + pMonth + " and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `company name`, `total revenue` desc";
                //        break;
                //}

                //MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter _cmd = new MySqlDataAdapter("call spGetDateRangeStatisticalReport('" + pYear + "-" + pMonth + "-01','" + pYear + "-" + pMonth + "-" + Convert.ToDateTime(pYear + "-" + pMonth + "-01").AddMonths(1).AddDays(-1).ToString("dd") + "', '" + pSortType.ToUpper() + "')", GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getMonthlyStatisticalReport : " + ex.Message);
            }
        }

        public DataTable getAnnualStatisticalReport(int pYear, string pSortType)
        {
            try
            {
                /* Gene
                 * 28-Feb-12
                 * Used stored procedure instead of "in-code" queries
                 */
                // Old Code
                //string _sqlQuery = "";
                //switch (pSortType.ToUpper())
                //{
                //    case "EVENT TYPE":
                //        _sqlQuery = "select eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`,  groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `event type`, `total revenue` desc";
                //        break;

                //    case "CLIENT TYPE":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `client type`, `total revenue` desc";
                //        break;

                //    case "SOURCE":
                //        _sqlQuery = "select folio.source as `Source`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `source`, `total revenue` desc";
                //        break;

                //    case "MARKET SEGMENT":
                //        _sqlQuery = "select folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `market segment`, `total revenue` desc";
                //        break;

                //    case "COMPANY NAME":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and year(folio.fromdate)=" + pYear + " group by folio.folioid order by `company name`, `total revenue` desc";
                //        break;
                //}

                //MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter _cmd = new MySqlDataAdapter("call spGetDateRangeStatisticalReport('" + pYear + "-01-01', '" + pYear + "-12-31', '" + pSortType.ToUpper() + "')", GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getAnnualStatisticalReport : " + ex.Message);
            }
        }
        
        public DataTable getDateRangeStatisticalReport(string pStartDate, string pEndDate, string pSortType)
        {
            try
            {
                /* Gene
                 * 28-Feb-12
                 * Used stored procedure instead of "in-code" queries
                 */
                // Old Code
                //string _sqlQuery = "";
                //switch (pSortType.ToUpper())
                //{
                //    case "EVENT TYPE":
                //        _sqlQuery = "select eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and date(folio.fromdate) between '" + pStartDate + "' and '" + pEndDate + "' group by folio.folioid order by `event type`, `total revenue` desc";
                //        break;

                //    case "CLIENT TYPE":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and date(folio.fromdate) between '" + pStartDate + "' and '" + pEndDate + "' group by folio.folioid order by `client type`, `total revenue` desc";
                //        break;

                //    case "SOURCE":
                //        _sqlQuery = "select folio.source as `Source`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.purpose as `Market Segment`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and date(folio.fromdate) between '" + pStartDate + "' and '" + pEndDate + "' group by folio.folioid order by `source`, `total revenue` desc";
                //        break;

                //    case "MARKET SEGMENT":
                //        _sqlQuery = "select folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and date(folio.fromdate) between '" + pStartDate + "' and '" + pEndDate + "' group by folio.folioid order by `market segment`, `total revenue` desc";
                //        break;

                //    case "COMPANY NAME":
                //        _sqlQuery = "select if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)='G',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, groupname as `Event Name`, folio.source as `Source`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and date(folio.fromdate) between '" + pStartDate + "' and '" + pEndDate + "' group by folio.folioid order by `company name`, `total revenue` desc";
                //        break;

                //}

                //MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter _cmd = new MySqlDataAdapter("call spGetDateRangeStatisticalReport('" + pStartDate + "', '" + pEndDate + "', '" + pSortType.ToUpper() + "')", GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getAnnualStatisticalReport : " + ex.Message);
            }
        }
        /* END OF FP - SCR - 00148 #1 */

        /* FP - SCR - 00148 #2 [08.09.2010]
         * added for Market Segment Query */
        public DataTable getMonthlyRangeMarketSegment(int pStartMonth, int pStartYear, int pEndMonth, int pEndYear)
        {
            try
            {
                /* Gene
                 * 29-Feb-12
                 */
                // Old Code
                //string _sqlQuery = "select folio.purpose as `Market Segment`, (select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, folioschedules.roomid as `Room ID`, date(folio.fromdate) as `Date`, count(distinct folioschedules.roomid) as `Total Count`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), folioschedules where folio.folioid=folioschedules.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate) between " + pStartMonth + " and " + pEndMonth + " and year(folio.fromdate) between +" + pStartYear + " and " + pEndYear + " group by folio.purpose, `Room Type`";
                string _sqlQuery = "call spGetDateRangeMarketSegment('" + pStartYear + "-" + pStartMonth.ToString("D2") + "-01', '" + Convert.ToDateTime(pEndYear + "-" + pEndMonth + "-01").AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + "')";

                MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getMonthlyRangeMarketSegment : " + ex.Message);
            }
        }

        public DataTable getAnnualMarketSegment(int pStartYear)
        {
            try
            {
                string _sqlQuery = "select folio.purpose as `Market Segment`, (select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, folioschedules.roomid as `Room ID`, year(folio.fromdate) as `Date`, count(distinct folioschedules.roomid) as `Total Count`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), folioschedules where folio.folioid=folioschedules.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and year(folio.fromdate) = " + pStartYear + " group by folio.purpose, `Room Type`";

                MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getAnnualMarketSegment : " + ex.Message);
            }
        }

        public DataTable getTotalCountForPreviousYears(int pMonth, int pYear, string pType)
        {
            try
            {
                string _sqlQuery = "select folio.purpose as `Market Segment`, (select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, folioschedules.roomid as `Room ID`, date(folio.fromdate) as `Date`, count(distinct folioschedules.roomid) as `Total Count`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), folioschedules where folio.folioid=folioschedules.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate) = " + pMonth + " and year(folio.fromdate) = " + pYear + " and folio.purpose = '" + pType + "' group by folio.purpose, `Room Type`";

                MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getTotalCountForPreviousYears : " + ex.Message);
            }
        }

        public DataTable getMonthlyRangeMarketSegmentPerRoomType(int pStartMonth, int pStartYear, int pEndMonth, int pEndYear)
        {
            try
            {
                string _sqlQuery = "select distinct folio.purpose as `Market Segment`, (select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, folioschedules.roomid as `Room ID`, date(folio.fromdate) as `Date`, count(distinct folioschedules.roomid) as `Total Count`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), folioschedules where folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate) between " + pStartMonth + " and " + pEndMonth + " and year(folio.fromdate) between +" + pStartYear + " and " + pEndYear + " group by `Room Type`";

                MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getMonthlyRangeMarketSegmentPerRoomType : " + ex.Message);
            }
        }

        public DataTable getAnnualMarketSegmentPerRoomType(int pYear)
        {
            try
            {
                string _sqlQuery = "select distinct folio.purpose as `Market Segment`, (select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, folioschedules.roomid as `Room ID`, year(folio.fromdate) as `Date`, count(distinct folioschedules.roomid) as `Total Count`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), folioschedules where folio.status!='CANCELLED' and folio.status!='NO SHOW' and year(folio.fromdate) = " + pYear + " group by `Room Type`";

                MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getMonthlyRangeMarketSegmentPerRoomType : " + ex.Message);
            }
        }

        public DataTable getTotalCountForPreviousYearsPerRoomType(int pMonth, int pYear, string pType)
        {
            try
            {
                string _sqlQuery = "select distinct folio.purpose as `Market Segment`, (select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, folioschedules.roomid as `Room ID`, date(folio.fromdate) as `Date`, count(distinct folioschedules.roomid) as `Total Count`, sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as `Total Revenue` from folio left join foliotransactions on (folio.folioid=foliotransactions.folioid), folioschedules where folio.status!='CANCELLED' and folio.status!='NO SHOW' and month(folio.fromdate) = " + pMonth + " and year(folio.fromdate) = +" + pYear + " and folioschedules.roomid = '" + pType + "' group by `Room Type`";

                MySqlDataAdapter _cmd = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _cmd.Fill(_oDataTable);

                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception @getTotalCountForPreviousYears : " + ex.Message);
            }
        }
        /* END OF FP-SCR-00148 #2 */

        //jlo 9-4-10 for picc
        public DataTable getGroupReservationForm(string pFolioID, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportGroupReservation('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getGroupReservationForm\r\n" + ex.Message);
            }
        }
        public DataTable getContactPersons(string pFolioID, int pHotelID, string pAccountID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetContactPersons('" + pFolioID + "','" + pHotelID.ToString() + "','" + pAccountID + "')", GlobalVariables.gPersistentConnection);

            try
            {
                _adapter.Fill(_dt);
                 int test = _dt.Rows.Count;
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getContactPersons\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
            return null;

        }

        public DataTable getOtherRequirements(string pFolioID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("select * from event_requirements where folioID='" + pFolioID + "' and requirementid = 'SPECIAL ARRANGEMENTS/OTHER IMPORTANT INFO' order by remarks, requirementid", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getOtherRequirements\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        //jlo 9-30-10
        /// <summary>
        /// Gets Lost Business report datatable
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <param name="pHotelId">hotel id</param>
        /// <returns>datable of lost business</returns>
        public DataTable getLostBusiness(DateTime pStartDate, DateTime pEndDate, int pHotelId)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportLostBusiness('" + string.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "','" + pHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getLostBusiness\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        //jlo 10-1-10
        /// <summary>
        /// Gets the list of bookings and inquiries
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <param name="pHotelId">hotelid</param>
        /// <returns>datatable</returns>
        public DataTable getBookingInquiries(DateTime pStartDate, DateTime pEndDate, int pHotelId)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportBookingsInquiries('" + string.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "','" + pHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getBookingInquiries\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getUser(string pUserId)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetUser('" + pUserId +"')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getUser\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getEventOfficer(string pFolioID, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventOfficers('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getEventOfficer\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        //jlo 9-22-2010
        /// <summary>
        /// Gets the eventendorsement of a folio
        /// </summary>
        /// <param name="pFolioID">folio id</param>
        /// <param name="pHotelID">hotel id</param>
        /// <returns>datatable</returns>
        public DataTable getSummaryOfCharges(string pFolioID, string pHotelID)
        {
            DataTable _dt = new DataTable();

            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetSummaryOfCharges('" + pFolioID + "','" + pHotelID + "','" + ConfigVariables.gContingencyCode + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getSummaryOfCharges\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        //EMP-SCR-00165
        /// <summary>
        /// Gets the Annual Events and Revenue Report
        /// </summary>
        /// <param name="pYear">Sets the year to be retrieved</param>
        /// <returns>DataTable</returns>
        public DataTable getAnnualEventsAndRevenueReport(int pYear)
        {
            try
            {
                DataTable _oReportData = new DataTable();
                string _query = "call spReportAnnualNoOfEventsAndRevenue(" + pYear + ")";
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
                _oDataAdapter.Fill(_oReportData);

                return _oReportData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end of EMP-SCR-00165

        //EMP-SCR-00171
        /// <summary>
        /// Gets the Annual Market Segment Report
        /// </summary>
        /// <param name="pYear">Sets the year to be retrieved</param>
        /// <returns>DataTable</returns>
        public DataTable getAnnualMarketSegmentReport(int pYear)
        {
            try
            {
                DataTable _oReportData = new DataTable();
                string _query = "call spReportAnnualMarketSegment(" + pYear + ")";
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
                _oDataAdapter.Fill(_oReportData);

                return _oReportData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //end of EMP-SCR-00171

        public DataTable getRoomIds()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetRoomIDs('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getRoomIds\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getEvents(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventsFromTo('" + string.Format("{0:yyyy-MM-dd}", pStartDate) + "','" + string.Format("{0:yyyy-MM-dd}", pEndDate) + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getEvents\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getEventAttendance(string pFolioID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportEventAttendance('" + pFolioID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getEventAttendance\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getAccountReport(string pAccountID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportAccount('" + pAccountID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getAccountReport\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getEventOrganized(string pAccountID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportEventsOrganized('" + pAccountID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getEventOrganized\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getAccountEvent(string pFolioID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportAccountEvent('" + pFolioID + "','" + GlobalVariables.gHotelId + "','" + ConfigVariables.gContingencyCode + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getAccountEvent\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getIncumbentOfficers(string pFolioID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetIncumbentOfficers('" + pFolioID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getIncumbentOfficers\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getLOP(string pFolioId)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportLOP('" + pFolioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getLOP\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
           
        }
        public DataTable getReportMemorandum(string pFolioId, string pFromDate, string pToDate, string pData)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportMemorandum('" + pFolioId + "','" + pFromDate + "','" + pToDate + "','" + pData + "')",GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getLOP\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
        public DataTable getReporTopClients(DateTime pFrom, DateTime pTo, string pMarketSegment, int NumList)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportTopClients('" + string.Format("{0:yyyy-MM-dd}",pFrom )+ "','"
                                                                                         + string.Format("{0:yyyy-MM-dd}", pTo) + "','"
                                                                                         + pMarketSegment + "',"
                                                                                         + NumList + ",'"
                                                                                         +GlobalVariables.gHotelId +"')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getLOP\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }

        }
        public DataTable getHistoricalEventsAndRevenue(string pFromDate, string pToDate, string pType)
        {

            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spReportHistoricalEventsAndRevenue('" + pFromDate+"-01-01" + "','"
                                                                                         +  pToDate+"-01-01" + "','"
                                                                                         + pType + "','"
                                                                                         + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getLOP\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getHistoricalReportsCategory()
        {

            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetHistoricalReportCategory("+ GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ReportDAO.getLOP\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
            return null;
        }

        public DataTable getAccoutTypeDetails(string pFrom,string pTo,string pMarketSegment,string pClientType)
        {

            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetAccoutTypeReport('"+pFrom+"','"+pTo+"','"+pMarketSegment+"','"+pClientType+"',"+ GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error spGetAccoutTypeReport" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
            return null;
        }



	}
}

