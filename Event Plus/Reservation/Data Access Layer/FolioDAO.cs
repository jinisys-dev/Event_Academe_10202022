
using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
	public class FolioDAO
	{

		//private ParameterHelper oParameterHelper;
		//private DataReaderBinder oDataReaderBinder;

		public FolioDAO()
		{
			//oParameterHelper = new ParameterHelper();
			//oDataReaderBinder = new DataReaderBinder();
		}

        public int getTotalInHouseGuests()
        {
            string mySqlQeury = "select sum(noOfAdults) from folio where `status`='ONGOING' and date('" + GlobalVariables.gAuditDate + 
                "') between date(fromDate) and date(toDate) and foliotype <> 'GROUP' and foliotype <> 'JOINER' and foliotype <> 'SHARE' and foliotype<>'NON-STAYING'";
            MySqlCommand selectCommand = new MySqlCommand(mySqlQeury, GlobalVariables.gPersistentConnection);
            int _total = 0;
            try
            {
                _total = int.Parse(selectCommand.ExecuteScalar().ToString());
            }
            catch
            {
                _total = 0;
            }

            return _total;
        }

        public int getTotalGroupWaitList()
        {
            string mySqlQuery = "call spCountGroupWaitList('" + GlobalVariables.gAuditDate + "')";
            MySqlCommand selectCommand = new MySqlCommand(mySqlQuery, GlobalVariables.gPersistentConnection);
            int _total = 0;
            try
            {
                _total = int.Parse(selectCommand.ExecuteScalar().ToString());
            }
            catch
            {
                _total = 0;
            }

            return _total;
        }
        public DataTable getSetUpTime(string pFolioID)
        {

            try
            {
               MySqlCommand getCommand = new MySqlCommand("call spGetSetUpTime('" + pFolioID+ "')", GlobalVariables.gPersistentConnection);

				getCommand.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter(getCommand);
				DataTable SetUptTime = new DataTable("GuestPrivilege");
				dtAdapter.Fill(SetUptTime);
                return SetUptTime;
            }
            catch
            {
                
            }

            return null;
        }



		public void DeleteFolioRouting(string folioID)
		{
			try
			{
				MySqlCommand deleteCommand = new MySqlCommand("call spDeleteALLFolioRouting(" + GlobalVariables.gHotelId
															+ ",'" + folioID
															+ "')", GlobalVariables.gPersistentConnection);

				deleteCommand.CommandType = CommandType.Text;
				deleteCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT DeleteFolioRouting(ByVal folioID As String)", "Folio DAO Exception");
			}
		}

		public void DeleteFolioRouting(string folioId, string TranCode)
		{
			try
			{
				MySqlCommand deleteCommand = new MySqlCommand("call spDeleteFolioRouting(" + GlobalVariables.gHotelId
															+ ",'" + folioId
															+ "','" + TranCode
															+ "')", GlobalVariables.gPersistentConnection);

				deleteCommand.CommandType = CommandType.Text;

				deleteCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT DeleteFolioRouting (ByVal folioId As String, ByVal TranCode As String)");
			}

		}

        public bool guestIsCheckedIn(string pAccountID, string pRoomNo)
        {
            try
            {
                MySqlCommand searchCommand = new MySqlCommand("call spCheckIfGuestIsCheckedIn('" + pAccountID + "'," + GlobalVariables.gHotelId + ",'" + pRoomNo + "')", GlobalVariables.gPersistentConnection);
                int count = int.Parse(searchCommand.ExecuteScalar().ToString());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public bool RemovePackage(string folioid)
		{
			try
			{
				MySqlCommand removeCommand = new MySqlCommand("call spRemovePACKAGE('" + folioid
															+ "'," + GlobalVariables.gHotelId
															+ ")", GlobalVariables.gPersistentConnection);

				removeCommand.CommandType = CommandType.Text;
				removeCommand.ExecuteNonQuery();

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ RemovePackage() " + ex.Message);
				return false;
			}
		}

		public bool DeleteFolioPackage(string folioid)
		{
			try
			{
				MySqlCommand removeCommand = new MySqlCommand("call spDeleteFolioPackage('" + folioid
															+ "'," + GlobalVariables.gHotelId
															+ ")", GlobalVariables.gPersistentConnection);

				removeCommand.CommandType = CommandType.Text;
				removeCommand.ExecuteNonQuery();

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ RemovePackage() " + ex.Message, "Folio DAO Exception");
				return false;
			}
		}

        //added by Genny : Alpa requirement room inclusions per folio
        public bool DeleteFolioInclusions(string folioid)
        {
            try
            {
                MySqlCommand removeCommand = new MySqlCommand("call spDeleteFolioInclusions('" + folioid
                                                            + "'," + GlobalVariables.gHotelId
                                                            + ")", GlobalVariables.gPersistentConnection);

                removeCommand.CommandType = CommandType.Text;
                removeCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ removeInclusions() " + ex.Message, "Folio DAO Exception");
                return false;
            }
        }

		public DataTable GetCompanyPrivileges(string CompanyID)
		{
			try
			{
				MySqlCommand getCommand = new MySqlCommand("call spGetCompanyPrivilege('" + CompanyID
														 + "'," + GlobalVariables.gHotelId
														 + ")", GlobalVariables.gPersistentConnection);

				getCommand.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter(getCommand);
				DataTable dtcompanyPrivileges = new DataTable("CompanyPrivilege");
				dtAdapter.Fill(dtcompanyPrivileges);
				return dtcompanyPrivileges;
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT GetCompanyPrivileges", "Get Company Privileges Exception");
				return null;
			}
		}

		public DataTable GetGuestPrivileges(string accountid)
		{
			try
			{
				MySqlCommand getCommand = new MySqlCommand("call spGetGuestPrivilege('" + accountid
														 + "'," + GlobalVariables.gHotelId
														 + ")", GlobalVariables.gPersistentConnection);

				getCommand.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter(getCommand);
				DataTable GuestPrivileges = new DataTable("GuestPrivilege");
				dtAdapter.Fill(GuestPrivileges);
				return GuestPrivileges;
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT GetGuestPrivileges", "Get Guest Privileges Exception");
				return null;
			}
		}

		public DataTable GetRoutingDetails(string folioID, string trancode)
		{
			try
			{
				MySqlCommand getCommand = new MySqlCommand("call spGetRoutingDetails ('" + folioID
														 + "'," + GlobalVariables.gHotelId
														 + ",'" + trancode
														 + "')", GlobalVariables.gPersistentConnection);

				getCommand.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter(getCommand);
				DataTable FolioRouting = new DataTable("FolioRouting");
				dtAdapter.Fill(FolioRouting);
				return FolioRouting;
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " GetRoutingDetails(ByVal folioID As String, ByVal trancode As String) As DataTable", "Routing Details Exception");
				return null;
			}
		}

		public string GetFolioIDByRoomID(string RoomId)
		{
			object obj = null;
			if (RoomId.EndsWith("\\"))
				return "";
			try
			{

				MySqlCommand cmd = new MySqlCommand("call spGetFolioId('" + RoomId
												  + "')", GlobalVariables.gPersistentConnection);

				obj = cmd.ExecuteScalar();
				if (obj != null)
					return obj.ToString();
				else
					return "";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Exception GetFolioByRoomIDex: " + ex.Message, "Folio DAO Exception");
				return "";
			}
		}

		public FolioTransactionLedger GetFolioLedger(string FolioID, string SubFolio)
		{

			FolioTransactionLedger oFolioTransactionLedger = new FolioTransactionLedger();
			try
			{
				DataTable tmpDataTable = new DataTable("FolioLedger");

				string query = "call spGetFolioTransactionLedger(" +
									 GlobalVariables.gHotelId
									 + ",'" + FolioID
									 + "','" + SubFolio
									 + "')";

                MySqlDataAdapter tmpDataAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);                
                tmpDataAdapter.Fill(tmpDataTable);

				if (tmpDataTable == null)
				{
					throw new Exception("No associated folioledger for Folio No. " + FolioID + " Subfolio: " + SubFolio);
				}
				if (tmpDataTable.Rows.Count <= 0)
				{
					throw new Exception("No associated folioledger for Folio No. " + FolioID + " Subfolio: " + SubFolio);
				}

				DataRow row = tmpDataTable.Rows[0];

				oFolioTransactionLedger.HotelID = GlobalVariables.gHotelId;
				oFolioTransactionLedger.FolioID = FolioID;
				oFolioTransactionLedger.SubFolio = SubFolio;
				oFolioTransactionLedger.AccountID = row["AccountID"].ToString();
				oFolioTransactionLedger.Charges = decimal.Parse(row["Charges"].ToString());
				oFolioTransactionLedger.PayCash = decimal.Parse(row["PayCash"].ToString());
				oFolioTransactionLedger.PayCard = decimal.Parse(row["PayCard"].ToString());
				oFolioTransactionLedger.PayCheque = decimal.Parse(row["PayCheque"].ToString());
				oFolioTransactionLedger.PayGiftCheque = decimal.Parse(row["PayGiftCheque"].ToString());
				oFolioTransactionLedger.BalanceForwarded = decimal.Parse(row["BalanceForwarded"].ToString());
				oFolioTransactionLedger.BalanceNet = decimal.Parse(row["BalanceNet"].ToString());
				oFolioTransactionLedger.Discount = decimal.Parse(row["Discount"].ToString());
				oFolioTransactionLedger.GovernmentTax = decimal.Parse(row["GovernmentTax"].ToString());
				oFolioTransactionLedger.LocalTax = decimal.Parse(row["LocalTax"].ToString());
				oFolioTransactionLedger.ServiceCharge = decimal.Parse(row["ServiceCharge"].ToString());
				//oFolioTransactionLedger.AgentComission = decimal.Parse(row["AgentComission"].ToString());
				oFolioTransactionLedger.TotalNet = decimal.Parse(row["TotalNet"].ToString());
				oFolioTransactionLedger.PostoTLedger = row["PostToLedger"].ToString();
				oFolioTransactionLedger.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
				oFolioTransactionLedger.CreatedBy = row["CreatedBy"].ToString();
				oFolioTransactionLedger.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
				oFolioTransactionLedger.UpdatedBy = row["UpdatedBy"].ToString();

				return oFolioTransactionLedger;
			}
			catch (Exception ex)
			{
				string errorMessage = "Transaction failed.\r\n\r\nError message: " + ex.Message;

				MessageBox.Show(errorMessage, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
				return null;
			}
		}

		//public FolioTransactionLedger GetFolioLedger(string FolioID, string SubFolio)
		//{

		//    FolioTransactionLedger oFolioTransactionLedger = new FolioTransactionLedger();
		//    try
		//    {
		//        DataTable tempDataTable = new DataTable();

		//        string query = "call spGetFolioTransactionLedger(" +
		//                             GlobalVariables.gHotelId
		//                             + ",'" + FolioID
		//                             + "','" + SubFolio
		//                             + "')";

		//        MySqlCommand oFolioTransactionLedgeractionLedgerCommand = new MySqlCommand(
		//                                                                        query,
		//                                                                        GlobalVariables.gPersistentConnection);

		//        oFolioTransactionLedgeractionLedgerCommand.CommandType = CommandType.Text;
		//        MySqlDataReader getFolioTransLedgerReader = oFolioTransactionLedgeractionLedgerCommand.ExecuteReader();
		//        while (getFolioTransLedgerReader.Read())
		//        {
		//            oFolioTransactionLedger.HotelID = GlobalVariables.gHotelId;
		//            oFolioTransactionLedger.FolioID = FolioID;
		//            oFolioTransactionLedger.SubFolio = SubFolio;
		//            oFolioTransactionLedger.AccountID = (getFolioTransLedgerReader.GetValue(3).ToString() == null) ? "" : (getFolioTransLedgerReader.GetValue(3).ToString());
		//            oFolioTransactionLedger.Charges = (getFolioTransLedgerReader.GetDecimal(4).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(4).ToString());
		//            oFolioTransactionLedger.PayCash = (getFolioTransLedgerReader.GetDecimal(5).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(5).ToString());
		//            oFolioTransactionLedger.PayCard = (getFolioTransLedgerReader.GetDecimal(6).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(6).ToString());
		//            oFolioTransactionLedger.PayCheque = (getFolioTransLedgerReader.GetDecimal(7).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(7).ToString());
		//            oFolioTransactionLedger.PayGiftCheque = (getFolioTransLedgerReader.GetDecimal(8).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(8).ToString());
		//            oFolioTransactionLedger.BalanceForwarded = (getFolioTransLedgerReader.GetDecimal(9).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(9).ToString());
		//            oFolioTransactionLedger.BalanceNet = (getFolioTransLedgerReader.GetDecimal(10).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(10).ToString());
		//            oFolioTransactionLedger.Discount = (getFolioTransLedgerReader.GetDecimal(11).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(11).ToString());
		//            oFolioTransactionLedger.GovernmentTax = (getFolioTransLedgerReader.GetDecimal(12).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(12).ToString());
		//            oFolioTransactionLedger.LocalTax = (getFolioTransLedgerReader.GetDecimal(13).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(13).ToString());
		//            oFolioTransactionLedger.ServiceCharge = (getFolioTransLedgerReader.GetDecimal(14).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(14).ToString());
		//            oFolioTransactionLedger.AgentComission = (getFolioTransLedgerReader.GetDecimal(15).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(15).ToString());
		//            oFolioTransactionLedger.TotalNet = (getFolioTransLedgerReader.GetDecimal(16).ToString() == null) ? 0 : decimal.Parse(getFolioTransLedgerReader.GetDecimal(16).ToString());
		//            oFolioTransactionLedger.PostoTLedger = (getFolioTransLedgerReader.GetString(17).ToString() == null) ? "" : (getFolioTransLedgerReader.GetString(17).ToString());
		//            oFolioTransactionLedger.CreateTime = (getFolioTransLedgerReader.GetDateTime(18).ToString() == null) ? DateTime.Parse("") : DateTime.Parse(getFolioTransLedgerReader.GetDateTime(18).ToString());
		//            oFolioTransactionLedger.CreatedBy = (getFolioTransLedgerReader.GetString(19).ToString() == null) ? "" : (getFolioTransLedgerReader.GetString(19).ToString());
		//            oFolioTransactionLedger.UpdateTime = (getFolioTransLedgerReader.GetDateTime(20).ToString() == null) ? DateTime.Parse("") : DateTime.Parse(getFolioTransLedgerReader.GetDateTime(20).ToString());
		//            oFolioTransactionLedger.UpdatedBy = (getFolioTransLedgerReader.GetString(21).ToString() == null) ? "" : (getFolioTransLedgerReader.GetString(21).ToString());

		//        }
		//        getFolioTransLedgerReader.Close();
		//        return oFolioTransactionLedger;
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show("EXCEPTION: " + ex.Message + " GetFolioLedger(ByVal FolioID As String, ByVal SubFolio As String) As Jinisys.Hotel.Reservation.BusinessLay1er.FolioTransactons");
		//        return null;
		//    }
		//}

		public Folio GetFolio(string pFolioId)
		{
			Folio oFolio = new Folio();
			try
			{

				DataTable tempTable = new DataTable();

				string query = "call spGetFolio('" + pFolioId + "','" + GlobalVariables.gHotelId + "')";
				MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
				adapter.Fill(tempTable);
				adapter.Dispose();
				//MySqlCommand getFolioCommand = new MySqlCommand("call spGetFolio('" + pFolioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				//MySqlDataReader folioDataReader = getFolioCommand.ExecuteReader();


				//Object tmp = oFolio;
				//oDataReaderBinder.BinderReaderToEntity(folioDataReader, ref tmp);

				//folioDataReader.Close();

				DataRow row = tempTable.Rows[0];
				oFolio.HotelID = int.Parse(row["hotelID"].ToString());
				oFolio.FolioID = row["folioID"].ToString();
				oFolio.AccountID = row["accountID"].ToString();
                oFolio.ReferenceNo = row["referenceNo"].ToString();
				oFolio.FolioType = row["folioType"].ToString();
				oFolio.GroupName = row["groupName"].ToString();
				oFolio.AccountType = row["accountType"].ToString();
				oFolio.NoofAdults = int.Parse(row["noOfAdults"].ToString());
				oFolio.NoOfChild = int.Parse(row["noOfChild"].ToString());
				oFolio.MasterFolio = row["masterFolio"].ToString();
				oFolio.CompanyID = row["companyID"].ToString();
				oFolio.AgentID = row["agentID"].ToString();
				oFolio.Source = row["source"].ToString();
				oFolio.FromDate = DateTime.Parse( row["fromDate"].ToString() );
				oFolio.Todate = DateTime.Parse( row["toDate"].ToString() );
				oFolio.ArrivalDate = DateTime.Parse( row["arrivalDate"].ToString() ); 
				oFolio.DepartureDate = DateTime.Parse( row["departureDate"].ToString() );
				oFolio.PackageID = row["packageId"].ToString();
				oFolio.Status = row["Status"].ToString();
				oFolio.Remarks = row["remarks"].ToString();
				oFolio.TerminalId = row["terminal_Id"].ToString();
				oFolio.ShiftCode = row["shift_Code"].ToString();
				oFolio.SupervisorId = row["supervisor_Id"].ToString();
				oFolio.Sales_Executive = row["sales_Executive"].ToString();
				oFolio.Payment_Mode = row["payment_Mode"].ToString();
				oFolio.Purpose = row["purpose"].ToString();
				oFolio.REASON_FOR_CANCEL = row["reason_For_Cancel"].ToString();
				oFolio.TaxExempted = int.Parse( row["taxExempted"].ToString() );
				oFolio.FolioETA = row["folioETA"].ToString();
				oFolio.FolioETD = row["folioETD"].ToString();
                oFolio.CreatedBy = row["createdBy"].ToString();
                oFolio.UpdatedBy = row["updatedBy"].ToString();
                oFolio.UpdateTime = DateTime.Parse( row["updateTime"].ToString());
                oFolio.ReasonType = row["reasonType"].ToString();
                oFolio.CancelBookingType = row["cancelBookingType"].ToString();
                oFolio.Future_Actions = row["future_actions"].ToString();
                oFolio.CreateTime = DateTime.Parse(row["createTime"].ToString());
				return oFolio;

			}
			catch 
			{
                //MessageBox.Show("EXCEPTION: " + ex.Message + " GetFolio(ByVal folioID As Integer) As Folio");
				return null;
			}

		}

		public Folio GetFolio(string folioID, int hotelId)
		{
			Folio oFolio = new Folio();
			try
			{

				//MySqlCommand getFolioCommand = new MySqlCommand("call spGetFolio('" + folioID
				//                                              + "','" + hotelId
				//                                              + "')", GlobalVariables.gPersistentConnection);

				//MySqlDataReader folioDataReader = getFolioCommand.ExecuteReader();

				DataTable tempTable = new DataTable();

				string query = "call spGetFolio('" + folioID + "','" + GlobalVariables.gHotelId + "')";
				MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
				adapter.Fill(tempTable);
				adapter.Dispose();

				//Object tmp = oFolio;
				//oDataReaderBinder.BinderReaderToEntity(folioDataReader, ref tmp);
				//folioDataReader.Close();
				DataRow row = tempTable.Rows[0];
				//oFolio.HotelID = row["hotelID"].ToString();
				oFolio.FolioID = row["folioID"].ToString();
				oFolio.AccountID = row["accountID"].ToString();
				oFolio.FolioType = row["folioType"].ToString();
				oFolio.GroupName = row["groupName"].ToString();
				oFolio.AccountType = row["accountType"].ToString();
				oFolio.NoofAdults = int.Parse(row["noOfAdults"].ToString());
				oFolio.NoOfChild = int.Parse(row["noOfChild"].ToString());
				oFolio.MasterFolio = row["masterFolio"].ToString();
				oFolio.CompanyID = row["companyID"].ToString();
				oFolio.AgentID = row["agentID"].ToString();
				oFolio.Source = row["source"].ToString();
				oFolio.FromDate = DateTime.Parse(row["fromDate"].ToString());
				oFolio.Todate = DateTime.Parse(row["toDate"].ToString());
				oFolio.ArrivalDate = DateTime.Parse(row["arrivalDate"].ToString());
				oFolio.DepartureDate = DateTime.Parse(row["departureDate"].ToString());
				oFolio.PackageID = row["packageId"].ToString();
				oFolio.Status = row["Status"].ToString();
				oFolio.Remarks = row["remarks"].ToString();
				oFolio.TerminalId = row["terminal_Id"].ToString();
				oFolio.ShiftCode = row["shift_Code"].ToString();
				oFolio.SupervisorId = row["supervisor_Id"].ToString();
				oFolio.Sales_Executive = row["sales_Executive"].ToString();
				oFolio.Payment_Mode = row["payment_Mode"].ToString();
				oFolio.Purpose = row["purpose"].ToString();
				oFolio.REASON_FOR_CANCEL = row["reason_For_Cancel"].ToString();
				oFolio.TaxExempted = int.Parse(row["taxExempted"].ToString());
				oFolio.FolioETA = row["folioETA"].ToString();
				oFolio.FolioETD = row["folioETD"].ToString();



				oFolio.Package = GetFolioPackage(oFolio.FolioID);
				oFolio.Privileges = GetFolioPrivileges(oFolio.FolioID);
				oFolio.RecurringCharges = getFolioRecurringCharges(oFolio.FolioID);

				oFolio.FolioRouting = getFolioBillRouting(oFolio.FolioID);

				return oFolio;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " GetFolio(ByVal folioID As Integer) As Folio");
				return null;
			}

		}

		// added by jun mar to getFoliotransaction collecction
		public FolioTransactions GetFolioTransactions(string folioID, string subFolio)
		{
			DataTable dtFolioTrans = new DataTable("FolioTransactions");
			FolioTransactions oFolioTransactions = new FolioTransactions();

			try
			{
				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetFolioTransactions('" + folioID + "','" + subFolio + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(dtFolioTrans);

				foreach (DataRow dtRow in dtFolioTrans.Rows)
				{
					FolioTransaction oFolioTrans = new FolioTransaction();

					oFolioTrans.FolioTransactionNo = int.Parse(dtRow["folioTransactionNo"].ToString());
					oFolioTrans.HotelID = GlobalVariables.gHotelId;
					oFolioTrans.FolioID = folioID;
					oFolioTrans.SubFolio = dtRow["subFolio"].ToString();
					oFolioTrans.TransactionDate = DateTime.Parse(dtRow["transactionDate"].ToString());
					oFolioTrans.PostingDate = DateTime.Parse(dtRow["postingDate"].ToString());
					oFolioTrans.TransactionCode = dtRow["transactionCode"].ToString();
					oFolioTrans.SubAccount = dtRow["subAccount"].ToString();
					oFolioTrans.ReferenceNo = dtRow["referenceNo"].ToString();
					oFolioTrans.TransactionSource = dtRow["transactionSource"].ToString();
					oFolioTrans.Memo = dtRow["memo"].ToString();
					oFolioTrans.AcctSide = dtRow["acctSide"].ToString();
					oFolioTrans.CurrencyCode = dtRow["currencyCode"].ToString();
					oFolioTrans.ConversionRate = decimal.Parse(dtRow["conversionRate"].ToString());
					oFolioTrans.CurrencyAmount = decimal.Parse(dtRow["currencyAmount"].ToString());
					oFolioTrans.BaseAmount = decimal.Parse(dtRow["baseAmount"].ToString());
					oFolioTrans.GrossAmount = decimal.Parse(dtRow["grossAmount"].ToString());
					oFolioTrans.Discount = decimal.Parse(dtRow["discount"].ToString());

					oFolioTrans.ServiceCharge = decimal.Parse(dtRow["serviceCharge"].ToString());
					oFolioTrans.ServiceChargeInclusive = int.Parse(dtRow["serviceChargeInclusive"].ToString());
					oFolioTrans.GovernmentTax = decimal.Parse(dtRow["governmentTax"].ToString());
					oFolioTrans.GovernmentTaxInclusive = int.Parse(dtRow["governmentTaxInclusive"].ToString());
					oFolioTrans.LocalTax = decimal.Parse(dtRow["localTax"].ToString());
					oFolioTrans.LocalTaxInclusive = int.Parse(dtRow["localTaxInclusive"].ToString());

					oFolioTrans.NetBaseAmount = decimal.Parse(dtRow["netBaseAmount"].ToString());
					oFolioTrans.NetAmount = decimal.Parse(dtRow["netAmount"].ToString());

					oFolioTrans.CreditCardNo = dtRow["creditCardNo"].ToString();
					oFolioTrans.ChequeNo = dtRow["chequeNo"].ToString();
					oFolioTrans.AccountName = dtRow["accountName"].ToString();
					oFolioTrans.BankName = dtRow["bankName"].ToString();
					oFolioTrans.ChequeDate = dtRow["chequeDate"].ToString();
					oFolioTrans.FOCGrantedBy = dtRow["FOCGrantedBy"].ToString();
					oFolioTrans.CreditCardType = dtRow["creditCardType"].ToString();
					oFolioTrans.ApprovalSlip = dtRow["approvalSlip"].ToString();
					oFolioTrans.CreditCardExpiry = dtRow["creditCardExpiry"].ToString();
					oFolioTrans.RouteSequence = dtRow["routeSequence"].ToString();
					oFolioTrans.SourceFolio = dtRow["sourceFolio"].ToString();
					oFolioTrans.SourceSubFolio = dtRow["sourceSubFolio"].ToString();
					oFolioTrans.TerminalID = dtRow["terminalId"].ToString();
					oFolioTrans.ShiftCode = dtRow["shiftCode"].ToString();
					oFolioTrans.Status = dtRow["status"].ToString();

					oFolioTrans.PostToLedger = dtRow["postToLedger"].ToString();
					oFolioTrans.CreateTime = DateTime.Parse(dtRow["createTime"].ToString());
					oFolioTrans.CreatedBy = dtRow["createdBy"].ToString();

					oFolioTrans.UpdateTime = DateTime.Parse(dtRow["updateTime"].ToString());
					oFolioTrans.UpdatedBy = dtRow["updatedBy"].ToString();
					oFolioTrans.AuditFlag = dtRow["auditFlag"].ToString();

					oFolioTransactions.Add(oFolioTrans);
				}

				return oFolioTransactions;


			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " GetFolioTransactions(ByVal folioID As Integer) As Jinisys.Hotel.Reservation.BusinessLay1er.FolioTransactons");
				return null;
			}
		}


		private void SetMasterFolioStatus(string masterfolio)
		{
			Folio oFolio = new Folio();
			oFolio.FolioID = masterfolio;
			oFolio.Status = "ONGOING";
			if (CheckChildrenIsTentative(masterfolio) == true)
			{
				UpdateFolioRecord(oFolio, "", "");
			}
		}

		public void UpdateStatus(string status, string folioid, string a_Reason)
		{
			try
			{
				string cmdtext;
				cmdtext = "call spUpdateFolioStatus('" + status + "', '" + folioid + "'," + GlobalVariables.gHotelId + ",'" + a_Reason + "')";
				MySqlCommand updateCommand = new MySqlCommand(cmdtext, GlobalVariables.gPersistentConnection);
				updateCommand.CommandType = CommandType.Text;
				updateCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " UpdateStatus(ByVal folioid As String)");
			}
		}

		public void UpdateStatusAndRemarks(string status, string folioid, string remarks)
		{
			try
			{
				string cmdtext;
				cmdtext = "call spUpdateFolioStatusAndRemarks('" + status + "', '" + folioid + "','" + GlobalFunctions.addSlashes(remarks) + "'," + GlobalVariables.gHotelId + ")";
				MySqlCommand updateCommand = new MySqlCommand(cmdtext, GlobalVariables.gPersistentConnection);
				updateCommand.CommandType = CommandType.Text;
				updateCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " UpdateStatusAndRemarks()");
			}
		}

		public void UpdateFolioRecord(Folio oFolio, string Masterfolio, string a_Reason)
		{
			try
			{
				MySqlCommand updateCommand = new MySqlCommand("call spUpdateFolioStatus('" + oFolio.Status + "','" + oFolio.Status + "'," + GlobalVariables.gHotelId + ",'" + a_Reason + "')", GlobalVariables.gPersistentConnection);
				updateCommand.CommandType = CommandType.Text;

				updateCommand.ExecuteNonQuery();
				if (Masterfolio != "")
				{
					SetMasterFolioStatus(Masterfolio);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " UpdateFolio(ByRef oFolio As Folio, Optional ByVal Masterfolio As String = \")");
			}
		}

		public void SETfolioStatus(string folioID, string status, string a_Reason)
		{
			try
			{
                DateTime _updateTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToLongTimeString());
                MySqlCommand updateCommand = new MySqlCommand("call spUpdateFolioStatus('" + status + "','" + folioID + "'," + GlobalVariables.gHotelId + ",'" + a_Reason + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", _updateTime) + "')", GlobalVariables.gPersistentConnection);

				updateCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Excepton Function SETfolioStatus(ByVal folioID As String, ByVal status As String) " + ex.Message);
			}
		}

        public void setReason(string pFolioID, string pReasonType, string pBookingType)
        {
            MySqlCommand _update = new MySqlCommand("call spUpdateReason('" + pFolioID + "','" + pReasonType + "','" + pBookingType + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioDAO.setReason\r\n" + ex.Message);
            }
            finally
            {
                _update.Dispose();
            }
        }

		public void setActualArrival(string folioID)
		{
			try
			{
				MySqlCommand updateCommand = new MySqlCommand("call spSetActualArrival('" + folioID
															+ "','" + GlobalVariables.gLoggedOnUser
															+ "'," + GlobalVariables.gHotelId
															+ ")", GlobalVariables.gPersistentConnection);

				updateCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Excepton Function SETfolioStatus(ByVal folioID As String) " + ex.Message);
			}
		}

		public void SetMasterFolio(string masterfolio, string folioID)
		{
			try
			{
				MySqlCommand setMasterFolioCommand = new MySqlCommand("call spSetMasterFOlio('" + masterfolio
																	+ "','" + folioID
																	+ "'," + GlobalVariables.gHotelId
																	+ ")", GlobalVariables.gPersistentConnection);

				setMasterFolioCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " SetMasterFolio(ByVal masterfolio As String, ByVal folioID As String)");
			}

		}

		public void SetChildFolioStatus(string masterfolio, string mStatus, string mReason)
		{
			try
			{
				//Dim oConnection As New MySqlConnection(connectionString)
				//oConnection.Open()
                DateTime _cancelledDateTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToLongTimeString());
                MySqlCommand setStatusCommand = new MySqlCommand("call spSetChildFolioStatus('" + masterfolio + "','" + mStatus + "'," + GlobalVariables.gHotelId + ",'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", _cancelledDateTime) + "','" + mReason + "')", GlobalVariables.gPersistentConnection);

				setStatusCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " SetChildFolioStatus(ByVal masterfolio As Integer, ByVal mStatus As String)");
			}
			//oConnection.Close()
		}

		public void SaveGroupFolio(Folio a_Folio)
		{
			//Dim connection As New MySqlConnection(connectionString)

			try
			{
				string cmdtext = "call spInsertFolio(" +
									   GlobalVariables.gHotelId + ",'" +
									   a_Folio.FolioID + "','" +
									   a_Folio.AccountID + "','" +
                                       a_Folio.ReferenceNo + "','" +
									   a_Folio.FolioType + "','" +
									   a_Folio.GroupName + "','" +
									   a_Folio.AccountType + "'," +
									   a_Folio.NoofAdults + "," +
									   a_Folio.NoOfChild + ",'" +
									   a_Folio.MasterFolio + "','" +
									   a_Folio.CompanyID + "','" +
									   a_Folio.AgentID + "','" +
									   a_Folio.Source + "','" +
									   string.Format("{0:yyyy-MM-dd}", a_Folio.FromDate) + "','" +
									   string.Format("{0:yyyy-MM-dd}", a_Folio.Todate) + "','" +
									   string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_Folio.ArrivalDate) + "','" +
									   string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_Folio.DepartureDate) + "','" +
									   a_Folio.PackageID + "','" +
									   a_Folio.Status + "','" +
									   GlobalFunctions.addSlashes(a_Folio.Remarks) + "','" +
									   GlobalVariables.gTerminalID + "','" +
									   GlobalVariables.gShiftCode + "','" +
									   GlobalVariables.gLoggedSupervisor + "','" +
									   GlobalVariables.gLoggedOnUser + "','" +
									   a_Folio.Sales_Executive + "','" +
									   a_Folio.Payment_Mode + "','" +
									   a_Folio.Purpose + "')";

				//.CreatedBy & "','" & _ REMOVED
				// Replaced with TRIGGERS

				MySqlCommand saveFolioCommand = new MySqlCommand(cmdtext, GlobalVariables.gPersistentConnection);
				saveFolioCommand.CommandType = CommandType.Text;
				saveFolioCommand.ExecuteNonQuery();

				// >> to save Folio Recurring Charges
				MySqlCommand saveRecurringCharge;
				if (!(a_Folio.RecurringCharges == null))
				{
					RecurringCharge oRecurringCharge;
					foreach (RecurringCharge tempLoopVar_oRecurringCharge in a_Folio.RecurringCharges)
					{
						oRecurringCharge = tempLoopVar_oRecurringCharge;
						saveRecurringCharge = new MySqlCommand("call spInsertFolioRecurringCharge(\'" + 
                            GlobalVariables.gHotelId + "\',\'" + oRecurringCharge.FolioID + "\',\'" + 
                            oRecurringCharge.TransactionCode + "\',\'" + oRecurringCharge.Memo + "\',\'" + 
                            oRecurringCharge.Amount + "\',\'" + string.Format("{0:yyyy-MM-dd}", oRecurringCharge.FromDate) + 
                            "\',\'" + string.Format("{0:yyyy-MM-dd}", oRecurringCharge.ToDate) + "\',\'" + 
                            GlobalVariables.gLoggedOnUser + "\'," + oRecurringCharge.SummaryFlag + "," +
                            oRecurringCharge.PackageID + ",'" + oRecurringCharge.SubAccount + "','" + oRecurringCharge.RoomID + "')", GlobalVariables.gPersistentConnection);

						//saveRecurringCharge.Transaction = trans;
						saveRecurringCharge.ExecuteNonQuery();
					}
				}

				//**
				// >> to save Folio Routing Details
				MySqlCommand saveFolioRouting;
				string saveRoutingTxt;
				if (!(a_Folio.FolioRouting == null))
				{
					FolioRouting oFolioRouting;
					foreach (FolioRouting tempLoopVar_oFolioRouting in a_Folio.FolioRouting)
					{
						oFolioRouting = tempLoopVar_oFolioRouting;
						saveRoutingTxt = "call spSaveFolioRouting(" + GlobalVariables.gHotelId + ",\'" + a_Folio.FolioID + "\',\'" + oFolioRouting.SubFolio + "\',\'" + oFolioRouting.TransactionCode + "\',\'" + oFolioRouting.Basis + "\'," + oFolioRouting.PercentCharged + "," + oFolioRouting.AmountCharged + ",\'" + GlobalVariables.gLoggedOnUser + "\',\'" + a_Folio.UpdatedBy + "\')";

						saveFolioRouting = new MySqlCommand(saveRoutingTxt, GlobalVariables.gPersistentConnection);
						saveFolioRouting.ExecuteNonQuery();
					}
				}

				// connection.Open()
				//MySqlCommand saveFolioCommand = new MySqlCommand("spInsertFolio", GlobalVariables.PersistentConnection);
				//saveFolioCommand.CommandType = CommandType.StoredProcedure;

				//MySqlParameter paramFolioID = new MySqlParameter();
				//MySqlParameter paramAccountID = new MySqlParameter();
				//MySqlParameter paramFolioType = new MySqlParameter();
				//MySqlParameter paramBreakFast = new MySqlParameter();
				//MySqlParameter parampackageid = new MySqlParameter();
				//MySqlParameter paramAccountType = new MySqlParameter();
				//MySqlParameter paramStatus = new MySqlParameter();
				//MySqlParameter paramSource = new MySqlParameter();
				//MySqlParameter paramNoAdult = new MySqlParameter();
				//MySqlParameter paramNoChild = new MySqlParameter();
				//MySqlParameter paramEventID = new MySqlParameter();
				//MySqlParameter paramGroupName = new MySqlParameter();
				//MySqlParameter pcompanyid = new MySqlParameter();

				//ParameterHelper paramHelper = new ParameterHelper();

				//paramHelper.AddParameters(paramFolioID, "pFolioID", ParameterDirection.Input, DbType.String, loFolio.FolioID, saveFolioCommand);
				//paramHelper.AddParameters(paramAccountID, "pAccountID", ParameterDirection.Input, DbType.Int64, loFolio.AccountID, saveFolioCommand);
				//paramHelper.AddParameters(paramEventID, "pEventID", ParameterDirection.Input, DbType.Int64, "2", saveFolioCommand);
				//paramHelper.AddParameters(paramFolioType, "pFolioType", ParameterDirection.Input, DbType.String, loFolio.FolioType.ToUpper(), saveFolioCommand);
				//paramHelper.AddParameters(paramGroupName, "pOrgname", ParameterDirection.Input, DbType.String, loFolio.GroupName.ToUpper(), saveFolioCommand);
				//paramHelper.AddParameters(pcompanyid, "pcompanyid", ParameterDirection.Input, DbType.String, loFolio.CompanyID.ToUpper(), saveFolioCommand);
				////oParameterHelper.AddParameters(paramBreakFast, "pBreakFast", ParameterDirection.Input, DbType.String, loFolio.BreakFast.ToUpper, saveFolioCommand)
				//paramHelper.AddParameters(parampackageid, "ppackageid", ParameterDirection.Input, DbType.Int64, loFolio.PackageID, saveFolioCommand);
				//paramHelper.AddParameters(paramAccountType, "pAccountType", ParameterDirection.Input, DbType.String, loFolio.AccountType.ToUpper(), saveFolioCommand);
				//paramHelper.AddParameters(paramStatus, "pStatus", ParameterDirection.Input, DbType.String, loFolio.Status.ToUpper(), saveFolioCommand);
				//paramHelper.AddParameters(paramSource, "pSource", ParameterDirection.Input, DbType.String, loFolio.Source, saveFolioCommand);
				//paramHelper.AddParameters(paramNoAdult, "pNoAdult", ParameterDirection.Input, DbType.Int64, loFolio.NoofAdults.ToString(), saveFolioCommand);
				//paramHelper.AddParameters(paramNoChild, "pNoChild", ParameterDirection.Input, DbType.Int64, loFolio.NoOfChild.ToString(), saveFolioCommand);

				//saveFolioCommand.ExecuteNonQuery();
			}
			catch (Exception)
			{
				MessageBox.Show("Masterfolio is Already Saved");
				//Finally
				//   connection.Close()
				//  connection.Dispose()
			}
		}

		public DataTable GetChildFoliosTable(string masterFolio)
		{
			MySqlDataAdapter dtAdapter;
			try
			{
				ScheduleFacade oScheduleFACADE = new ScheduleFacade();
				MySqlCommand getChildFolioCommand = new MySqlCommand(" call spGetChildFolios(\'" + masterFolio + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				getChildFolioCommand.CommandType = CommandType.Text;

				dtAdapter = new MySqlDataAdapter(getChildFolioCommand);
				DataTable getChildData = new DataTable("ChildFolios");
				dtAdapter.Fill(getChildData);
				return getChildData;

			}
			catch (Exception ex)
			{
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				MessageBox.Show("EXCEPTION: " + ex.Message + " GetChildFolios(ByVal masterFolio As Integer) As DataTable");
				return null;
			}
		}

		public ChildFolios GetChildFolios(string masterFolio)
		{

			try
			{
				//oConnection.Open()
				ScheduleFacade oScheduleFACADE = new ScheduleFacade();
				Jinisys.Hotel.Reservation.BusinessLayer.ChildFolios childFolios = new Jinisys.Hotel.Reservation.BusinessLayer.ChildFolios();
				MySqlCommand getChildFolioCommand = new MySqlCommand("call spGetChildFoliosAllFields(\'" + masterFolio + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				getChildFolioCommand.CommandType = CommandType.Text;
				MySqlDataReader getChildDataReader = getChildFolioCommand.ExecuteReader();
				while (getChildDataReader.Read())
				{
					Folio Folio = new Folio();
					Type objType = Folio.GetType();
					PropertyInfo[] pInfos = objType.GetProperties();

					PropertyInfo pInfo;
					foreach (PropertyInfo tempLoopVar_pInfo in pInfos)
					{
						pInfo = tempLoopVar_pInfo;
						try
						{
							pInfo.SetValue(Folio, getChildDataReader[pInfo.Name], null);
						}
						catch (Exception)
						{

						}
					}
					childFolios.Add(Folio);
				}
				getChildDataReader.Close();
				return childFolios;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " GetChildFolios(ByVal masterFolio As String) As Jinisys.Hotel.Reservation.BusinessLayer.ChildFolios");
				return null;

			}
		}

		public bool CheckStatusToCancel(string masterfolio)
		{
			try
			{

				MySqlCommand checkStatusCommand = new MySqlCommand("call spGetChildFolios('" + masterfolio + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

				MySqlDataReader checkStatusReader = checkStatusCommand.ExecuteReader();

				while (checkStatusReader.Read())
				{
					string status = checkStatusReader.GetValue(3).ToString();
					if (status.ToUpper() == "ONGOING")
					{
						checkStatusReader.Close();
						return false;
					}
				}
				checkStatusReader.Close();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " CheckStatusToCancel(ByVal masterfolio As Integer) As Boolean");
				return false;
			}
		}

		public void SetRoomStatusAftertoVacant(string folioid)
		{
			MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

			//Dim oConnection As New MySqlConnection(connectionString)
			try
			{
				//oConnection.Open()
				ConfigurationHotel.BusinessLayer.RoomFacade oRoomFacade = new ConfigurationHotel.BusinessLayer.RoomFacade();
				MySqlCommand setStatusCommand = new MySqlCommand("call spGetSchedule(\'" + folioid + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

				MySqlDataReader setStatusReader = setStatusCommand.ExecuteReader();
				//Dim _status As String = = setStatusReader.GetValue(0).ToString()
				ArrayList roomID = null;
				while (setStatusReader.Read())
				{
					roomID.Add(setStatusReader.GetValue(0).ToString());
				}
				setStatusReader.Close();
				for (int i = 1; i <= roomID.Count; i++)
				{
					string room = roomID[i].ToString();
					oRoomFacade.setRoomStatus(room, "VACANT", ref _oDBTrans);
				}

				_oDBTrans.Commit();
			}
			catch (Exception ex)
			{
				_oDBTrans.Rollback();

				MessageBox.Show("EXCEPTION: " + ex.Message + " SetRoomStatusAftertoVacant(ByRef folioid As Integer)");
			}
		}

		public void DeleteFolio(string folioID)
		{
			//Dim oConnection As New MySqlConnection(connectionString)
			try
			{
				//oConnection.Open()
				MySqlCommand deleteFolioCommand = new MySqlCommand("Delete from folio where folioid =\'" + folioID + "\'", GlobalVariables.gPersistentConnection);
				deleteFolioCommand.CommandType = CommandType.Text;
				deleteFolioCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " DeleteFolio(ByVal folioID As Integer)");

			}
		}

		public DataTable  GetFolioHistory(string AccountID)
		{
			try
			{

				DataTable getHistory = new DataTable("FolioHistory");

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetGuestFolioHistory(\'" + AccountID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(getHistory);
				dtAdapter.Dispose();

				return getHistory;
			}
			catch (Exception)
			{
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				return null;
			}

		}

		private bool CheckChildrenIsTentative(string masterFolio)
		{
			DataTable childData = GetChildFoliosTable(masterFolio);
			DataRow dtRow;
			foreach (DataRow tempLoopVar_dtRow in childData.Rows)
			{
				dtRow = tempLoopVar_dtRow;
				if (dtRow["Status"].ToString() == "TENTATIVE" || dtRow["Status"].ToString() == "CONFIRMED")
				{
					return false;
				}
			}
			return true;

		}

		public string getPackageName(string packageID)
		{
			try
			{
				MySqlCommand getFolioPackageCommand = new MySqlCommand("call spGetPackageHeaderInfo(\'" + packageID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				getFolioPackageCommand.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter(getFolioPackageCommand);
				DataTable dtPackage = new DataTable("Package");
				dtAdapter.Fill(dtPackage);
				DataRow dr;
				string packageName = "";
				foreach (DataRow tempLoopVar_dr in dtPackage.Rows)
				{
					dr = tempLoopVar_dr;
					packageName = dr["Description"].ToString();
				}
				return packageName;
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT getPackageName");
				return "";
			}
		}

		public DataTable GetFolioRecurringCharge(string folioID)
		{
			try
			{
				MySqlCommand GetRecurringCharge = new MySqlCommand("call spGetRecurringCharge(\'" + folioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				GetRecurringCharge.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter(GetRecurringCharge);
				DataTable RecurringChargeTable = new DataTable("RecurringCharge");
				dtAdapter.Fill(RecurringChargeTable);
				return RecurringChargeTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT GetFolioRecurringCharge");
				return null;
			}
		}

		public DataTable GetFolioRouting(string folioID)
		{
			try
			{
				MySqlCommand GetFolioRoutingCommand = new MySqlCommand("call spGetFolioRouting(\'" + folioID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				GetFolioRoutingCommand.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter(GetFolioRoutingCommand);
				DataTable FolioPackageTable = new DataTable("FolioRouting");
				dtAdapter.Fill(FolioPackageTable);
				return FolioPackageTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT GetFolioRouting");
				return null;
			}
		}

		public void SaveFolioRouting(FolioRouting oFolioRouting)
		{
			try
			{
				string cmdText;
				FolioRouting with_1 = oFolioRouting;
				cmdText = "call spSaveFolioRouting(" + GlobalVariables.gHotelId + ",\'" + with_1.FolioID + "\',\'" + with_1.SubFolio + "\',\'" + with_1.TransactionCode + "\',\'" + with_1.Basis + "\'," + with_1.PercentCharged + "," + with_1.AmountCharged + ",\'" + GlobalVariables.gLoggedOnUser + "\',\'" + with_1.UpdatedBy + "\')";

				MySqlCommand saveCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
				saveCommand.CommandType = CommandType.Text;

				saveCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " = AT SaveFolioRouting(ByVal oFolioRouting As FolioRouting)");
			}
		}

		public bool RemoveFolioRouting(Folio oFolio, ref MySqlTransaction pDBTransaction)
		{
			try
			{
				MySqlCommand deleteFolioRouting = new MySqlCommand("call spDeleteFolioRoutings(\'" + oFolio.FolioID + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				deleteFolioRouting.Transaction = pDBTransaction;
				deleteFolioRouting.ExecuteNonQuery();

				return true;
			}
			catch (Exception ex)
			{
                //pDBTransaction.Rollback();
				throw new Exception("ERROR: " + ex.Message + " = @ RemoveFolioRouting() ");
                //return false;
			}
		}

		public void SaveFolioRoutingCollection(FolioRoutingCollection oFolioRoutingCollection)
		{
			try
			{
				string cmdText;
				FolioRouting oFolioRouting;

				foreach (FolioRouting tempLoopVar_oFolioRouting in oFolioRoutingCollection)
				{
					oFolioRouting = tempLoopVar_oFolioRouting;
					cmdText = "call spSaveFolioRouting(" + GlobalVariables.gHotelId + ",\'" + oFolioRouting.FolioID + "\',\'" + oFolioRouting.SubFolio + "\',\'" + oFolioRouting.TransactionCode + "\',\'" + oFolioRouting.Basis + "\'," + oFolioRouting.PercentCharged + "," + oFolioRouting.AmountCharged + ",\'" + GlobalVariables.gLoggedOnUser + "\',\'" + oFolioRouting.UpdatedBy + "\')";

					MySqlCommand saveCommand = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
					saveCommand.CommandType = CommandType.Text;

					saveCommand.ExecuteNonQuery();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " = AT SaveFolioRouting(ByVal oFolioRouting As FolioRouting)");
			}
		}

		public void UpdateFolioPackage(string FolioID, string packageId)
		{
			try
			{
				MySqlCommand updateCommand = new MySqlCommand("call spChangeFolioPackage(\'" + FolioID + "\'," + GlobalVariables.gHotelId + ",\'" + packageId + "\')", GlobalVariables.gPersistentConnection);
				updateCommand.CommandType = CommandType.Text;

				updateCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " = AT UpdateFolioPackage");
			}
		}

		public DataTable GetPackages()
		{
			try
			{
				MySqlCommand getPackageCommand = new MySqlCommand("call spGetPackages(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter();
				dtAdapter = new MySqlDataAdapter(getPackageCommand);
				DataTable getPagckage = new DataTable("Packages");
				dtAdapter.Fill(getPagckage);

				return getPagckage;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message + '\r' + "Public Function GetPackages() as datatable");
				return null;
			}
		}

		public DataTable GetPackageDetails(string packageId)
		{
			try
			{
				MySqlCommand GetPackageDetailCmd = new MySqlCommand("call spGetPackageDetails('" + packageId + "')", GlobalVariables.gPersistentConnection);
				GetPackageDetailCmd.CommandType = CommandType.Text;

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter();
				dtAdapter = new MySqlDataAdapter(GetPackageDetailCmd);

				DataTable getPagckage = new DataTable("PackageDetails");
				dtAdapter.Fill(getPagckage);

				return getPagckage;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message + '\r' + "Public Function GetPackageDetails(ByVal packageId As String) As DataTable");
				return null;
			}
		}

		public void DeleteFolioRecurringCharge(string folioId, string TranCode)
		{
			try
			{
				MySqlCommand deleteCommand = new MySqlCommand("call spDeleteFolioRecurringCharge(" + GlobalVariables.gHotelId + ",\'" + folioId + "\',\'" + TranCode + "\')", GlobalVariables.gPersistentConnection);
				deleteCommand.CommandType = CommandType.Text;

				deleteCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " AT DeleteFolioRecurringCharge");
			}
		}

        public bool DeleteFolioRecurringCharges(string folioId)
        {
            try
            {
                MySqlCommand deleteCommand = new MySqlCommand("call spDeleteFolioRecurringCharges(" + GlobalVariables.gHotelId + ",\'" + folioId + "\')", GlobalVariables.gPersistentConnection);
                deleteCommand.CommandType = CommandType.Text;

                deleteCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message + " AT DeleteFolioRecurringCharge");
                return false;
            }
        }

		public bool SaveFolioPackage(FolioPackage oFolioPackage)
		{
			try
			{
				string cmdtext = "call spInsertFolioPackages('" + GlobalVariables.gHotelId + "','" + oFolioPackage.FolioID + "','" + oFolioPackage.TransactionCode + "','" + oFolioPackage.Basis + "'," + oFolioPackage.PercentOff + "," + oFolioPackage.AmountOff + ",'" + oFolioPackage.DaysApplied + "','" + GlobalVariables.gLoggedOnUser + "','" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateFrom) + "','" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateTo) + "')";
				MySqlCommand savePackageCommand = new MySqlCommand(cmdtext, GlobalVariables.gPersistentConnection);
				savePackageCommand.CommandType = CommandType.Text;
				savePackageCommand.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message + '\r' + "SaveFolioPackage()");
				return false;
			}
		}

		// >> JEROME :: 29-Apr-2006
		// >> used in "FolioLedgersUI.GetIndividualFolios"
        //jlo 8-9-10
        //addedd pType as parameter to return multiple rooms for group checkin
		public string GetCurrentRoomOccupied(string folioID, string pType)
		{
			try
			{
				MySqlCommand getRoom = new MySqlCommand("call spGetCurrentRoomOccupied('" + folioID + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
                string roomid = "";
                if (pType == "GROUP")
                {
                    DataTable _dt = new DataTable();
                    MySqlDataAdapter _adapter = new MySqlDataAdapter(getRoom);
                    _adapter.Fill(_dt);
                    foreach (DataRow _dRow in _dt.Rows)
                    {
                        roomid+= _dRow["RoomID"] + ", ";
                    }
                    roomid = roomid.Substring(0, roomid.Length - 2);
                }
                else
                {
                    roomid = getRoom.ExecuteScalar().ToString();
                }
				return roomid;
			}
			catch (Exception)
			{
				//MessageBox.Show("EXCEPTION: " + ex.Message + " GetCurrentRoomOccupied(ByVal pFolioID As STRING) As Integer");
				return "";
			}
		}

		private Folio oFolio;
		public Folio GetGuestFolioInfo(string folioId)
		{
			//Try
			oFolio = new Folio();

			MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetGuestFolioInfo(\'" + folioId + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
			dataAdapter.Fill(oFolio, "Folio");
			dataAdapter.Dispose();

			oFolio.FolioID = folioId;
			oFolio.AccountID = (oFolio.Tables[0].Rows[0]["AccountId"].ToString() == null) ? "" : (oFolio.Tables[0].Rows[0]["AccountId"].ToString());
			oFolio.CompanyID = (oFolio.Tables[0].Rows[0]["CompanyId"].ToString() == null) ? "" : (oFolio.Tables[0].Rows[0]["CompanyId"].ToString());
			oFolio.FolioType = oFolio.Tables[0].Rows[0]["FolioType"].ToString();
			oFolio.MasterFolio = oFolio.Tables[0].Rows[0]["MasterFolio"].ToString();
            
			oFolio.Remarks = oFolio.Tables[0].Rows[0]["Remarks"].ToString();
			oFolio.Status = oFolio.Tables[0].Rows[0]["Status"].ToString();

			IList<RecurringCharge> oRecurringCharges = new List<RecurringCharge>();
			DataTable dtTable = new DataTable();
			dtTable = GetFolioRecurringCharge(folioId);
			DataRow dtrow;
			foreach (DataRow tempLoopVar_dtrow in dtTable.Rows)
			{
				dtrow = tempLoopVar_dtrow;
				RecurringCharge mRecurringCharge = new RecurringCharge();
				mRecurringCharge.TransactionCode = dtrow["TransactionCode"].ToString();
				mRecurringCharge.Memo = dtrow["Memo"].ToString();
				mRecurringCharge.Amount = decimal.Parse(dtrow["Amount"].ToString());
				mRecurringCharge.FromDate = DateTime.Parse(dtrow["FromDate"].ToString());
				mRecurringCharge.ToDate = DateTime.Parse(dtrow["ToDate"].ToString());
                mRecurringCharge.SummaryFlag = int.Parse(dtrow["summaryFlag"].ToString());
                mRecurringCharge.PackageID = int.Parse(dtrow["packageID"].ToString());
                mRecurringCharge.SubAccount = dtrow["subAccount"].ToString();
                mRecurringCharge.RoomID = dtrow["RoomID"].ToString();
                mRecurringCharge.Discount = decimal.Parse(dtrow["discount"].ToString());
                mRecurringCharge.BaseAmount = decimal.Parse(dtrow["baseAmount"].ToString());
                mRecurringCharge.Tax = decimal.Parse(dtrow["tax"].ToString());
                mRecurringCharge.QtyHrs = int.Parse(dtrow["qtyHrs"].ToString());
				oRecurringCharges.Add(mRecurringCharge);
			}

			oFolio.RecurringCharges = oRecurringCharges;


			return oFolio;
			//Catch ex As Exception
			//MsgBox("EXCEPTION: Function GetFolioInfo(ByVal folioId As String) As Folio" & ex.Message)
			//End Try
		}

		// >> Jerome 03-May-2006
		public FolioPackage GetFolioTransPackage(string FolioID, string TranCode)
		{
			try
			{
				FolioPackage oPackage = new FolioPackage();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetFolioTransPackage(\'" + FolioID + "\',\'" + TranCode + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(oPackage, "FolioPackage");

				if (oPackage.Tables[0].Rows.Count > 0)
				{
					oPackage.TransactionCode = oPackage.Tables["FolioPackage"].Rows[0]["TransactionCode"].ToString();
					oPackage.Basis = oPackage.Tables["FolioPackage"].Rows[0]["Basis"].ToString();
					oPackage.PercentOff = decimal.Parse(oPackage.Tables["FolioPackage"].Rows[0]["PercentOff"].ToString());
					oPackage.AmountOff = decimal.Parse(oPackage.Tables["FolioPackage"].Rows[0]["AmountOff"].ToString());
					oPackage.DaysApplied = oPackage.Tables["FolioPackage"].Rows[0]["DaysApplied"].ToString();
                    oPackage.DateFrom = DateTime.Parse(oPackage.Tables["FolioPackage"].Rows[0]["DateFrom"].ToString());
                    oPackage.DateTo = DateTime.Parse(oPackage.Tables["FolioPackage"].Rows[0]["DateTo"].ToString());

					return oPackage;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION @ GetFolioTransPackage()" + ex.Message);
				return null;
			}
		}

		public FolioRoutingCollection GetFolioTransRouting(string FolioID, string TranCode)
		{
			try
			{
				FolioRoutingCollection oFolioRoutingCollection = new FolioRoutingCollection();
				FolioRouting oFolioRouting = new FolioRouting();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetFolioTransRouting(\'" + FolioID + "\',\'" + TranCode + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(oFolioRouting, "FolioRouting");

				DataRow dtRow;
				foreach (DataRow tempLoopVar_dtRow in oFolioRouting.Tables["FolioRouting"].Rows)
				{
					dtRow = tempLoopVar_dtRow;
					FolioRouting fRouting = new FolioRouting();
					fRouting.SubFolio = dtRow["SubFolio"].ToString();
					fRouting.TransactionCode = dtRow["TransactionCode"].ToString();
					fRouting.Basis = dtRow["Basis"].ToString();
					fRouting.PercentCharged = decimal.Parse(dtRow["PercentCharged"].ToString());
					fRouting.AmountCharged = decimal.Parse(dtRow["AmountCharged"].ToString());

					oFolioRoutingCollection.Add(fRouting);
				}

				return oFolioRoutingCollection;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION @ GetFolioTransRouting()" + ex.Message);
				return null;
			}
		}

		public DataTable GetFolioLedgers(string accountType)
		{
			try
			{
				DataTable dtFolioLedgers = new DataTable();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
				switch (accountType.ToUpper())
				{
					case "PERSONAL":

						dataAdapter = new MySqlDataAdapter("call spGetIndividualFolios(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
						break;
					case "GROUP":

						dataAdapter = new MySqlDataAdapter("call spGetCompanyFolios('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
						break;

				}

				dataAdapter.Fill(dtFolioLedgers);
				dataAdapter.Dispose();

				return dtFolioLedgers;

			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " GetFolioLedgers(ByVal accountType As String) As DataTable");
				return null;
			}
		}

		public DataRow GetFolioTransPrivilege(FolioTransaction oFolioTrans)
		{
			try
			{
				DataTable dtFolioPrivilege = new DataTable();

				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetFolioTransPrivilege(\'" + oFolioTrans.FolioID + "\',\'" + oFolioTrans.TransactionCode + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				dataAdapter.Fill(dtFolioPrivilege);
				dataAdapter.Dispose();

				if (!(dtFolioPrivilege == null))
				{
					return dtFolioPrivilege.Rows[0];
				}
				else
				{
					return null;
				}
			}
			catch (Exception)
			{
				//MsgBox("EXCEPTION: " & ex.Message & " GetFolioPrivilege() As Datarow")
				return null;
			}
		}

		public void UpdateFolioLedger(string folioid, string subFolio, string accountId)
		{
			MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
			try
			{
				string _sqlStr = "call spUpdateFolioLedger('" +
										folioid + "','" +
										subFolio + "','" +
										accountId + "','" +
										GlobalVariables.gHotelId + "','" +
										GlobalVariables.gLoggedOnUser + "')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = trans;
				updateCommand.ExecuteNonQuery();

				trans.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + " @ UpdateFolioLedger()");
				trans.Rollback();
			}
		}

		public IList<FolioPackage> GetFolioPackage(string folioId)
		{
			IList<FolioPackage> oFolioPackageCollection = new List<FolioPackage>();
			DataTable dtPackages = new DataTable();
			try
			{

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetFolioPackage('" + folioId + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(dtPackages);
				dtAdapter.Dispose();

				DataRow dtRow;
				foreach (DataRow tempLoopVar_dtRow in dtPackages.Rows)
				{
					dtRow = tempLoopVar_dtRow;
					FolioPackage oFolioPackage = new FolioPackage();
					oFolioPackage.HotelID = int.Parse(dtRow["HotelId"].ToString());
					oFolioPackage.FolioID = dtRow["FolioId"].ToString();
					oFolioPackage.TransactionCode = dtRow["TransactionCode"].ToString();
					oFolioPackage.Memo = dtRow["Memo"].ToString();
					oFolioPackage.Basis = dtRow["Basis"].ToString();
					oFolioPackage.PercentOff = decimal.Parse(dtRow["PercentOff"].ToString());
					oFolioPackage.AmountOff = decimal.Parse(dtRow["AmountOff"].ToString());
					oFolioPackage.DaysApplied = dtRow["DaysApplied"].ToString();
                    oFolioPackage.DateFrom = DateTime.Parse(dtRow["DateFrom"].ToString());
                    oFolioPackage.DateTo = DateTime.Parse(dtRow["DateTo"].ToString());
					oFolioPackageCollection.Add(oFolioPackage);
				}

				return oFolioPackageCollection;
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message + " @ GetFolioPackage");
				return null;
			}
		}

        //added by Genny : Alpa requirement - folio room inclusion
        public IList<FolioInclusions> GetFolioInclusions(string folioId)
        {
            IList<FolioInclusions> oFolioInclusionsCollection = new List<FolioInclusions>();
            DataTable dtInclusions = new DataTable();
            try
            {

                MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetFolioInclusions('" + folioId + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                dtAdapter.Fill(dtInclusions);
                dtAdapter.Dispose();

                DataRow dtRow;
                foreach (DataRow tempLoopVar_dtRow in dtInclusions.Rows)
                {
                    dtRow = tempLoopVar_dtRow;
                    FolioInclusions oFolioPackage = new FolioInclusions();
                    oFolioPackage.HotelID = int.Parse(dtRow["HotelId"].ToString());
                    oFolioPackage.FolioID = dtRow["FolioId"].ToString();
                    oFolioPackage.Memo = dtRow["Memo"].ToString();
                    oFolioInclusionsCollection.Add(oFolioPackage);
                }

                return oFolioInclusionsCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message + " @ GetFolioPackage");
                return null;
            }
        }

		public IList<RecurringCharge> getFolioRecurringCharges(string folioId)
		{
			IList<RecurringCharge> oRecurringChargeCollection = new List<RecurringCharge>();
			DataTable dtTable = new DataTable();

			try
			{
				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetRecurringCharge('" + folioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(dtTable);
				dtAdapter.Dispose();

				DataRow dtRow;
				foreach (DataRow tempLoopVar_dtRow in dtTable.Rows)
				{
					dtRow = tempLoopVar_dtRow;
					RecurringCharge oRecurringCharge = new RecurringCharge();
					oRecurringCharge.HotelID = int.Parse(dtRow["HotelID"].ToString());
					oRecurringCharge.FolioID = dtRow["FolioID"].ToString();
					oRecurringCharge.TransactionCode = dtRow["TransactionCode"].ToString();
					oRecurringCharge.Memo = dtRow["Memo"].ToString();
					oRecurringCharge.Amount = decimal.Parse(dtRow["Amount"].ToString());
					oRecurringCharge.FromDate = DateTime.Parse(dtRow["FromDate"].ToString());
					oRecurringCharge.ToDate = DateTime.Parse(dtRow["ToDate"].ToString());
                    oRecurringCharge.SummaryFlag = int.Parse(dtRow["summaryFlag"].ToString());
                    oRecurringCharge.PackageID = int.Parse(dtRow["packageID"].ToString());
                    oRecurringCharge.SubAccount = dtRow["subAccount"].ToString();
                    oRecurringCharge.RoomID = dtRow["RoomID"].ToString();
                    oRecurringCharge.QtyHrs = int.Parse(dtRow["qtyHrs"].ToString());
                    oRecurringCharge.Discount = decimal.Parse(dtRow["discount"].ToString());
                    oRecurringCharge.RateType = dtRow["ratetype"].ToString();
                    oRecurringCharge.BaseAmount = decimal.Parse(dtRow["baseAmount"].ToString());
                    oRecurringCharge.Tax = decimal.Parse(dtRow["tax"].ToString());
					oRecurringChargeCollection.Add(oRecurringCharge);
				}

				return oRecurringChargeCollection;

			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getFolioRecurringCharges()" + ex.Message);
				return null;
			}

		}

		public IList<FolioRouting> getFolioBillRouting(string folioId)
		{
			IList<FolioRouting> oFolioRoutingCollection = new List<FolioRouting>();
			DataTable dtTable = new DataTable();

			try
			{
				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetFolioRouting('" +
																			folioId + "','" +
																			GlobalVariables.gHotelId
																			+ "')", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(dtTable);
				dtAdapter.Dispose();

				DataRow dtRow;
				foreach (DataRow tempLoopVar_dtRow in dtTable.Rows)
				{
					dtRow = tempLoopVar_dtRow;
					FolioRouting oFolioRouting = new FolioRouting();
					oFolioRouting.HotelID = int.Parse(dtRow["HotelID"].ToString());
					oFolioRouting.FolioID = dtRow["FolioID"].ToString();
					oFolioRouting.SubFolio = dtRow["SubFolio"].ToString();
					oFolioRouting.TransactionCode = dtRow["TransactionCode"].ToString();
					//.Memo = _dtRow("Memo")
					oFolioRouting.Basis = dtRow["Basis"].ToString();
					oFolioRouting.PercentCharged = decimal.Parse(dtRow["PercentCharged"].ToString());
					oFolioRouting.AmountCharged = decimal.Parse(dtRow["AmountCharged"].ToString());
					//.Amount = _dtRow("Amount")
					//.FromDate = _dtRow("FromDate")
					//.ToDate = _dtRow("ToDate")

					oFolioRoutingCollection.Add(oFolioRouting);
				}

				return oFolioRoutingCollection;

			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getFolioRecurringCharges()" + ex.Message);
				return null;
			}

		}

		public IList<Privilege> GetFolioPrivileges(string folioId)
		{
			IList<Privilege> oPrivilegeCollection = new List<Privilege>();
			DataTable dtTable = new DataTable();

			try
			{
				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetFolioPrivilege(\'" + folioId + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(dtTable);
				dtAdapter.Dispose();

				DataRow dtRow;
				foreach (DataRow tempLoopVar_dtRow in dtTable.Rows)
				{
					dtRow = tempLoopVar_dtRow;
					Privilege oPrivilege = new Privilege();
					oPrivilege.HotelId = int.Parse(dtRow["HotelID"].ToString());
					oPrivilege.FolioID = dtRow["FolioID"].ToString();
					oPrivilege.TransactionCode = dtRow["TransactionCode"].ToString();
					oPrivilege.Memo = dtRow["Memo"].ToString();
					oPrivilege.Basis = dtRow["Basis"].ToString();
					oPrivilege.Percentoff = decimal.Parse(dtRow["PercentOff"].ToString());
					oPrivilege.AmountOff = decimal.Parse(dtRow["AmountOff"].ToString());

					oPrivilegeCollection.Add(oPrivilege);
				}

				return oPrivilegeCollection;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ GetFolioPrivileges()" + ex.Message);
				return null;
			}

		}

		public bool RemoveRecurringCharge(RecurringCharge oRecurringCharge)
		{
			MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

			try
			{
				RecurringCharge with_1 = oRecurringCharge;
				MySqlCommand deleteCommand = new MySqlCommand("call spDeleteFolioRecurringCharge(\'" + GlobalVariables.gHotelId + "\',\'" + with_1.FolioID + "\',\'" + with_1.TransactionCode + "\')", GlobalVariables.gPersistentConnection);
				deleteCommand.Transaction = trans;
				deleteCommand.ExecuteNonQuery();

				trans.Commit();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ RemoveRecurringCharge() " + ex.Message);
				trans.Rollback();
				return false;

			}
		}

		public void SaveFolioRecurringCharges(Folio oFolio)
		{
			MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
			try
			{
				// >> to save Folio Recurring Charges
				MySqlCommand saveRecurringCharge;
				if (!(oFolio.RecurringCharges == null))
				{

					// >> delete all folio recurring lCharge of a given Folio
					saveRecurringCharge = new MySqlCommand("call spDeleteFolioRecurringCharges(\'" + oFolio.FolioID + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);

					saveRecurringCharge.Transaction = trans;
					saveRecurringCharge.ExecuteNonQuery();

					RecurringCharge oRecurringCharge;
                    foreach (RecurringCharge tempLoopVar_oRecurringCharge in oFolio.RecurringCharges)
                    {
                        oRecurringCharge = tempLoopVar_oRecurringCharge;

                        int packageID = 0;
                        try
                        {
                            packageID = oRecurringCharge.PackageID;
                        }
                        catch
                        {
                            packageID = 0;
                        }
                        int summaryFlag = 0;
                        try
                        {
                            summaryFlag = oRecurringCharge.SummaryFlag;
                        }
                        catch
                        {
                            summaryFlag = 0;
                        }

                        saveRecurringCharge = new MySqlCommand("call spInsertFolioRecurringCharge(\'" + GlobalVariables.gHotelId + "\',\'" +
                            oRecurringCharge.FolioID + "\',\'" + oRecurringCharge.TransactionCode + "\',\'" + oRecurringCharge.Memo + "\',\'" +
                            oRecurringCharge.Amount + "\',\'" + string.Format("{0:yyyy-MM-dd}", oRecurringCharge.FromDate) + "\',\'" +
                            string.Format("{0:yyyy-MM-dd}", oRecurringCharge.ToDate) + "\',\'" + GlobalVariables.gLoggedOnUser + "\'," + summaryFlag + "," +
                            packageID + "," + oRecurringCharge.SubAccount + "','" + oRecurringCharge.RoomID + "')", GlobalVariables.gPersistentConnection);

                        saveRecurringCharge.Transaction = trans;
                        saveRecurringCharge.ExecuteNonQuery();
                    }
				}

				trans.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ SaveFolioRecurringCharges()" + ex.Message);
			}

		}

		public void SaveFolioPackage(Folio oFolio)
		{
			try
			{
				// >> to save FolioPackage
				MySqlCommand savePackageCommand;
				FolioPackage oFolioPackage;
				if (!(oFolio.Package == null))
				{
					foreach (FolioPackage tempLoopVar_oFolioPackage in oFolio.Package)
					{
						oFolioPackage = tempLoopVar_oFolioPackage;
						savePackageCommand = new MySqlCommand("call spInsertFolioPackages('" + GlobalVariables.gHotelId + "','" + oFolioPackage.FolioID + "','" + oFolioPackage.TransactionCode + "','" + oFolioPackage.Basis + "','" + oFolioPackage.PercentOff + "','" + oFolioPackage.AmountOff + "','" + oFolioPackage.DaysApplied + "','" + GlobalVariables.gLoggedOnUser + "','" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateFrom) + "','" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateTo) + "')", GlobalVariables.gPersistentConnection);

						savePackageCommand.ExecuteNonQuery();

					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ SaveFolioPackage() " + ex.Message);
			}
		}

        //added by Genny : Alpa requirement room inclusions per folio
        public void SaveFolioInclusions(Folio oFolio)
        {
            try
            {
                // >> to save FolioInclusions
                MySqlCommand savePackageCommand;
                FolioInclusions oFolioInclusions;
                if (!(oFolio.Package == null))
                {
                    foreach (FolioInclusions tempLoopVar_oFolioInclusions in oFolio.Inclusions)
                    {
                        oFolioInclusions = tempLoopVar_oFolioInclusions;
                        savePackageCommand = new MySqlCommand("call spInsertFolioInclusions('" + GlobalVariables.gHotelId + "','" + oFolioInclusions.FolioID + "','" + oFolioInclusions.Memo + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);

                        savePackageCommand.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ SaveFolioPackage() " + ex.Message);
            }
        }

		public DataTable checkAvailableRoom(string roomid, string roomtype, string date)
		{

			try
			{
				DataTable dTable = new DataTable();
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spGetRoomScheduleByDateRange('" + roomid + "','" + roomtype + "','" + date + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ checkAvailableRoom() " + ex.Message);
				return null;
			}
		}

		public DataTable getRoomHistory()
		{

			try
			{
				DataTable dTable = new DataTable();
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spGetRoomHistory()", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: @ getRoomHistory() " + ex.Message);
				return null;
			}
		}

        public DataTable getEngineeringJobsHistory()
        {
            try
            {
                DataTable dTable = new DataTable();
                MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spGetEngineeringJobsHistory()", GlobalVariables.gPersistentConnection);
                dAdapter.Fill(dTable);
                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ getEngineeringHistory() " + ex.Message);
                return null;
            }
        }

		public DataTable getRoomHousekeeperHistory()
		{
			try
			{
				DataTable dTable = new DataTable();
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spReportAllHousekeepingJobs(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				throw (ex);
				//MessageBox.Show("EXCEPTION: @ getRoomHousekeeperHistory() " + ex.Message);
				//return null;
			}
		}

		public DataTable getGuestForToolTip()
		{
			try
			{

				DataTable dTable = new DataTable();

				string _query = "call spSelectGuestForToolTip('" 
							  + GlobalVariables.gHotelId + "','" 
							  + GlobalVariables.gAuditDate + "')";

				MySqlDataAdapter dAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);

				return dTable;
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message));
				//MessageBox.Show("EXCEPTION: @ getGuestForToolTip() " + ex.Message);
				//return null;
			}
		}

		public DataTable getGuestForToolTipCalendar()
		{

			try
			{

				DataTable dTable = new DataTable();

				string _query = "call spSelectGuestForToolTipCalendar('"
							  + GlobalVariables.gHotelId + "')";

				MySqlDataAdapter dAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);

				return dTable;
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message));
			}
		}


		public DataTable getCompanyFoliosForToolTip()
		{

			try
			{
				DataTable dTable = new DataTable();
				MySqlDataAdapter dAdapter = new MySqlDataAdapter("call spSelectCompanyFoliosForToolTip('" + GlobalVariables.gHotelId + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);

				return dTable;
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message));
				//MessageBox.Show("EXCEPTION: @ getGuestForToolTip() " + ex.Message);
				//return null;
			}
		}

		public DataTable getRoomBlocksForToolTip()
		{

			try
			{
				string _sqlStr = "call spSelectRoomBlockForToolTip('" +
									   GlobalVariables.gHotelId + "','" +
									   GlobalVariables.gAuditDate + "')";

				DataTable dTable = new DataTable();
				MySqlDataAdapter dAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);

				return dTable;
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message));
			}
		}

		public string getRoomCleaningStatus(string a_RoomId)
		{

			try
			{
				string roomStatus = "";

				MySqlCommand selectCommand = new MySqlCommand("call spGetRoomCleaningStatus('" + GlobalVariables.gHotelId + "','" + a_RoomId + "')", GlobalVariables.gPersistentConnection);
				roomStatus = selectCommand.ExecuteScalar().ToString();

				return roomStatus;
			}
			catch (Exception)
			{
                return "CLEAN";
			}
		}

        public string getRoomOccupancyStatus(string a_RoomId)
        {

            try
            {
                string occupancyStatus = "";

                MySqlCommand selectCommand = new MySqlCommand("call spGetRoomOccupancyStatus('" + GlobalVariables.gHotelId + "','" + a_RoomId + "')", GlobalVariables.gPersistentConnection);
                occupancyStatus = selectCommand.ExecuteScalar().ToString();

                return occupancyStatus;
            }
            catch (Exception)
            {
                return "VACANT";
            }
        }

        public string getRoomReservationStatus(string a_RoomId, string pDate)
        {

            try
            {
                string occupancyStatus = "";

                MySqlCommand selectCommand = new MySqlCommand("call getRoomReservationStatus('" + GlobalVariables.gHotelId + "','" + a_RoomId + "','" + pDate + "')", GlobalVariables.gPersistentConnection);
                occupancyStatus = selectCommand.ExecuteScalar().ToString();

                return occupancyStatus;
            }
            catch (Exception)
            {
                return "VACANT";
            }
        }

		public DataTable getRateTypesForInquiry()
		{
			DataTable dtRateTypes = new DataTable("RateTypes");
			try
			{

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spSelectRateTypes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(dtRateTypes);

				return dtRateTypes;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public int saveFolioPrivilege(Folio a_Folio, ref MySqlTransaction trans)
		{
			try
			{

				// removes current privilege
				MySqlCommand deletePrivilege = new MySqlCommand("call spDeleteFolioPrivilege('" + a_Folio.FolioID + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
				deletePrivilege.Transaction = trans;

				deletePrivilege.ExecuteNonQuery();

				// >> to save Privilege
				MySqlCommand savePrivilegeCommand;
				if (!(a_Folio.Privileges == null))
				{
					Privilege oPrivilege;
					foreach (Privilege tempLoopVar_oPrivilege in a_Folio.Privileges)
					{
						oPrivilege = tempLoopVar_oPrivilege;
						savePrivilegeCommand = new MySqlCommand("call spInsertFolioPrivilege(\'" + oPrivilege.HotelId + "\',\'" + oPrivilege.FolioID + "\',\'" + oPrivilege.TransactionCode + "\',\'" + oPrivilege.Basis + "\',\'" + oPrivilege.Percentoff + "\',\'" + oPrivilege.AmountOff + "\')", GlobalVariables.gPersistentConnection);

						savePrivilegeCommand.Transaction = trans;
						savePrivilegeCommand.ExecuteNonQuery();
					}
					return 1;
				}

				return 1;
			}
			catch (Exception ex)
			{
                //trans.Rollback();
				throw (ex);
			}

		}

		public DataTable getJoinerFolios(string a_MasterFolioId)
		{
			DataTable dtJoinerFolios = new DataTable("Joiners");
			try
			{

				MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spSelectJoinerFolioByMasterFolioID('" + a_MasterFolioId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				dtAdapter.Fill(dtJoinerFolios);

				return dtJoinerFolios;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


		public void updateJoinerAllFolioStatus(string a_Status, string a_MasterFolioId)
		{
			try
			{
				MySqlCommand updateCommand = new MySqlCommand("call spUpdateAllJoinerFolioStatus('" + a_Status + "','" + a_MasterFolioId + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
				updateCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public void updateJoinerFolioStatus(string a_Status, string a_MasterFolioId, string a_FolioId)
		{
			try
			{
				MySqlCommand updateCommand = new MySqlCommand("call spUpdateJoinerFolioStatus('" + a_Status + "','" + a_MasterFolioId + "','" + a_FolioId + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
				updateCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		/// <summary>
		/// Sets Folio Status to ONGOING
		/// </summary>
		/// <param name="_folioId">Folio Id to ONGOING</param>
		/// <returns>The number of rows affected</returns>
		public int updateFolioStatusToCheckedIn(string _folioId, ref MySqlTransaction pDBTrans)
		{
			int _rowsAffected = 0;
			try
			{
				string _sqlStr = "call spUpdateFolioStatusToCheckedIn('" +
										_folioId + "'," +
										GlobalVariables.gHotelId + ",'" +
										GlobalVariables.gLoggedOnUser +
										"','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", GlobalVariables.gAuditDate + " " + DateTime.Now.ToString("HH:mm:ss")) + "')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = pDBTrans;

				_rowsAffected = updateCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw (new Exception("No rows affected."));
				}

				return _rowsAffected;
			}
			catch (Exception ex)
			{
                //pDBTrans.Rollback();
				throw (ex);
			}
		}


		public int updateJoinerFolioStatusToCheckedIn(string pMasterFolioId, string pFolioId, ref MySqlTransaction pDBTrans)
		{
			int _rowsAffected = 0;
            string _date = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToShortTimeString()).ToString("yyyy-MM-dd HH:mm:ss");

			try
			{
				string _sqlStr = "call spUpdateJoinerFolioStatusToCheckedIn('" +
									   pMasterFolioId + "','" +
									   pFolioId + "','" +
									   GlobalVariables.gHotelId + "','" +
									   GlobalVariables.gLoggedOnUser + "','" +
                                       _date + "')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = pDBTrans;

				_rowsAffected = updateCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw (new Exception("No rows affected."));
				}

				return _rowsAffected;
			}
			catch (Exception ex)
			{
                //pDBTrans.Rollback();
				throw (ex);
			}
		}


		public int updateFolioStatusToCancelled(string pFolioId, string pReasonForCancel, ref MySqlTransaction pDBTrans)
		{
			int _rowsAffected = 0;
            DateTime _cancelledDateTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToShortTimeString());
			try
			{
                string _sqlStr = "call spUpdateFolioStatusToCancelled('" +
                                        pFolioId + "','" +
                                        pReasonForCancel + "'," +
                                        GlobalVariables.gHotelId + ",'" +
                                        GlobalVariables.gLoggedOnUser + "','" +
                                        string.Format("{0:yyyy-MM-dd HH:mm:ss}", _cancelledDateTime) + "')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = pDBTrans;

				_rowsAffected = updateCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw (new Exception("No rows affected."));
				}

				return _rowsAffected;
			}
			catch (Exception ex)
			{
                //pDBTrans.Rollback();
				throw (ex);
			}
		}

		public int updateFolioStatusToNoShow(string pFolioId, ref MySqlTransaction pDBTrans)
		{
			int _rowsAffected = 0;
            DateTime _cancelledDateTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToShortTimeString());
            try
			{
				string _sqlStr = "call spUpdateFolioStatusToNoShow('" +
										pFolioId + "'," +
										GlobalVariables.gHotelId + ",'" +
                                        GlobalVariables.gLoggedOnUser + "','" +
                                        string.Format("{0:yyyy-MM-dd HH:mm:ss}", _cancelledDateTime) + "')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = pDBTrans;

				_rowsAffected = updateCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw (new Exception("No rows affected."));
				}

				return _rowsAffected;
			}
			catch (Exception ex)
			{
                //pDBTrans.Rollback();
				throw (ex);
			}
		}

        public string getReferenceNo(string pFolioId, int pMonth , int pYear, int pHotelID)
        {
            MySqlCommand _command = new MySqlCommand("call spGetLatestReferenceNo('" + pFolioId + "','" + pMonth + "','" + pYear + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                string _ref = "";
                try
                {
                    _ref = _command.ExecuteScalar().ToString();
                }
                catch { }
                if (_ref != null && _ref.Length > 0)
                {
                    string[] _refNo = _ref.Split('.');
                    int i = int.Parse(_refNo[1]);
                    i++;
                    if (i < 10)
                        return "0" + i;
                    else
                        return i.ToString();
                }
                else
                    return "01";

            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioDAO.getReferenceNo\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }

        public void setReferenceNo(string pFolioID, string pReferenceNo , int pHotelID)
        {
            MySqlCommand _command = new MySqlCommand("call spSetReferenceNo('" + pFolioID + "','" + pReferenceNo + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioDAO.setReferenceNo\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }

		public int updateFolioStatusToConfirmed(string pFolioId, ref MySqlTransaction poDBTransaction)
		{
			int _rowsAffected = 0;
			try
			{
				string _sqlStr = "call spUpdateFolioStatusToConfirmed('" +
										pFolioId + "'," +
										GlobalVariables.gHotelId + ",'" +
										GlobalVariables.gLoggedOnUser +
										"')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = poDBTransaction;

				_rowsAffected = updateCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw (new Exception("No rows affected."));
				}

				return _rowsAffected;
			}
			catch (Exception ex)
			{
                //poDBTransaction.Rollback();
				throw (ex);
			}
		}

        public int updateFolioStatusToTentative(string pFolioId, ref MySqlTransaction poDBTransaction)
        {
            int _rowsAffected = 0;
            try
            {
                string _sqlStr = "call spUpdateFolioStatusToTentative('" +
                                        pFolioId + "'," +
                                        GlobalVariables.gHotelId + ",'" +
                                        GlobalVariables.gLoggedOnUser +
                                        "')";
                MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                updateCommand.Transaction = poDBTransaction;

                _rowsAffected = updateCommand.ExecuteNonQuery();

                if (_rowsAffected <= 0)
                {
                    throw (new Exception("No rows affected."));
                }
                return _rowsAffected;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

		public void saveNewFolio(Folio pFolio, ref MySqlTransaction poTrans)
		{
			try
			{
				string _sqlStrFolio = "call spInsertFolio(" +
									   GlobalVariables.gHotelId + ",'" +
									   pFolio.FolioID + "','" +
									   pFolio.AccountID + "','" +
                                       pFolio.ReferenceNo + "','" +
									   pFolio.FolioType + "','" +
									   pFolio.GroupName + "','" +
									   pFolio.AccountType + "'," +
									   pFolio.NoofAdults + "," +
									   pFolio.NoOfChild + ",'" +
									   pFolio.MasterFolio + "','" +
									   pFolio.CompanyID + "','" +
									   pFolio.AgentID + "','" +
									   pFolio.Source + "','" +
									   string.Format("{0:yyyy-MM-dd}", pFolio.FromDate) + "','" +
									   string.Format("{0:yyyy-MM-dd}", pFolio.Todate) + "','" +
									   string.Format("{0:yyyy-MM-dd HH:mm:ss}", pFolio.ArrivalDate) + "','" +
									   string.Format("{0:yyyy-MM-dd HH:mm:ss}", pFolio.DepartureDate) + "','" +
									   pFolio.PackageID + "','" +
									   pFolio.Status + "','" +
									   GlobalFunctions.addSlashes(pFolio.Remarks) + "','" +
									   pFolio.TerminalId + "','" +
									   pFolio.ShiftCode + "','" +
									   pFolio.SupervisorId + "','" +
									   pFolio.Sales_Executive + "','" +
									   pFolio.Payment_Mode + "','" +
									   pFolio.Purpose + "','" +
									   pFolio.REASON_FOR_CANCEL + "'," +
									   pFolio.TaxExempted + ",'" +
									   pFolio.FolioETA + "','" +
									   pFolio.FolioETD + "','" +
									   pFolio.CreatedBy + "')";

				MySqlCommand insertFolio = new MySqlCommand(_sqlStrFolio, GlobalVariables.gPersistentConnection);
				insertFolio.Transaction = poTrans;

				insertFolio.ExecuteNonQuery();

				// save FOLIO LEDGERS [a,b,c,d]
				if (!(pFolio.SubFolios == null || pFolio.SubFolios.Count == 0))
				{
					foreach (SubFolio subF in pFolio.SubFolios)
					{
                        string _sqlStrFolioLedger="";
                        if (pFolio.Guest != null)
                        {
                            _sqlStrFolioLedger = "call spInsertFolioLedger(" +
                                                            GlobalVariables.gHotelId + ",'" +
                                                            subF.Folio.FolioID + "','" +
                                                            subF.SubFolio_Renamed + "','" +
                                                            pFolio.Guest.AccountId + "',0,0,0,0,0,0,0,0,0,0,0,0,0,'0','" +
                                                            pFolio.CreatedBy + "')";
                        }
                        else
                        {
                            _sqlStrFolioLedger = "call spInsertFolioLedger(" +
                                                            GlobalVariables.gHotelId + ",'" +
                                                            subF.Folio.FolioID + "','" +
                                                            subF.SubFolio_Renamed + "','" +
                                                            pFolio.CompanyID + "',0,0,0,0,0,0,0,0,0,0,0,0,0,'0','" +
                                                            pFolio.CreatedBy + "')";
                        }

						MySqlCommand _insertFolioLedger = new MySqlCommand(_sqlStrFolioLedger, GlobalVariables.gPersistentConnection);
						_insertFolioLedger.Transaction = poTrans;
						_insertFolioLedger.ExecuteNonQuery();

					}
				}

				// >> to save FolioPackage
				MySqlCommand savePackageCommand;
				if (!(pFolio.Package == null || pFolio.Package.Count == 0))
				{
					foreach (FolioPackage oFolioPackage in pFolio.Package)
					{
						string _sqlStrFolioPackage = "call spInsertFolioPackages('" +
														   GlobalVariables.gHotelId + "','" +
														   oFolioPackage.FolioID + "','" +
														   oFolioPackage.TransactionCode + "','" +
														   oFolioPackage.Basis + "','" +
														   oFolioPackage.PercentOff + "','" +
														   oFolioPackage.AmountOff + "','" +
														   oFolioPackage.DaysApplied + "','" +
														   GlobalVariables.gLoggedOnUser + "','" +
                                                           string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateFrom) + "','" +
                                                           string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateTo) + "')";

						savePackageCommand = new MySqlCommand(_sqlStrFolioPackage, GlobalVariables.gPersistentConnection);
						savePackageCommand.Transaction = poTrans;

						savePackageCommand.ExecuteNonQuery();

					}
				}

				// >> to save Privilege
				MySqlCommand savePrivilegeCommand;
				if (!(pFolio.Privileges == null || pFolio.Privileges.Count == 0))
				{
					foreach (Privilege oPrivilege in pFolio.Privileges)
					{
						string _sqlStrFolioPrivilege = "call spInsertFolioPrivilege('" +
															 GlobalVariables.gHotelId + "','" +
															 oPrivilege.FolioID + "','" +
															 oPrivilege.TransactionCode + "','" +
															 oPrivilege.Basis + "','" +
															 oPrivilege.Percentoff + "','" +
															 oPrivilege.AmountOff + "')";

						savePrivilegeCommand = new MySqlCommand(_sqlStrFolioPrivilege, GlobalVariables.gPersistentConnection);
						savePrivilegeCommand.Transaction = poTrans;

						savePrivilegeCommand.ExecuteNonQuery();
					}
				}

				// >> to save Folio Recurring Charges
				MySqlCommand saveRecurringCharge;
				if (!(pFolio.RecurringCharges == null || pFolio.RecurringCharges.Count == 0))
				{
					foreach (RecurringCharge oRecurringCharge in pFolio.RecurringCharges)
					{
						string _sqlStr = "call spInsertFolioRecurringCharge('" +
											   GlobalVariables.gHotelId + "','" +
											   oRecurringCharge.FolioID + "','" +
											   oRecurringCharge.TransactionCode + "','" +
											   oRecurringCharge.Memo + "','" +
											   oRecurringCharge.Amount + "','" +
											   string.Format("{0:yyyy-MM-dd}", oRecurringCharge.FromDate) + "','" +
											   string.Format("{0:yyyy-MM-dd}", oRecurringCharge.ToDate) + "','" +
											   GlobalVariables.gLoggedOnUser + "'," +
											   oRecurringCharge.SummaryFlag + "," +
                                               oRecurringCharge.PackageID + ",'" +
                                               oRecurringCharge.SubAccount + "','" +
                                               oRecurringCharge.RoomID + "','" +
                                               oRecurringCharge.QtyHrs + "','" +
                                               oRecurringCharge.Discount + "','" +
                                               oRecurringCharge.RateType + "','" +
                                               oRecurringCharge.BaseAmount + "','" + 
                                               oRecurringCharge.Tax + "')";


						saveRecurringCharge = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
						saveRecurringCharge.Transaction = poTrans;

						saveRecurringCharge.ExecuteNonQuery();
					}
				}

				// >> to save Folio Routing Details
				MySqlCommand saveFolioRouting;
				string saveRoutingTxt;
				if (!(pFolio.FolioRouting == null || pFolio.FolioRouting.Count == 0))
				{
					foreach (FolioRouting oFolioRouting in pFolio.FolioRouting)
					{
						saveRoutingTxt = "call spInsertFolioRouting(" +
											   GlobalVariables.gHotelId + ",'" +
											   pFolio.FolioID + "','" +
											   oFolioRouting.SubFolio + "','" +
											   oFolioRouting.TransactionCode + "','" +
											   oFolioRouting.Basis + "'," +
											   oFolioRouting.PercentCharged + "," +
											   oFolioRouting.AmountCharged + ",'" +
											   GlobalVariables.gLoggedOnUser + "','" +
											   pFolio.UpdatedBy + "')";

						saveFolioRouting = new MySqlCommand(saveRoutingTxt, GlobalVariables.gPersistentConnection);
						saveFolioRouting.Transaction = poTrans;
						saveFolioRouting.ExecuteNonQuery();
					}
				}

                // >> to save FolioInclusions
                MySqlCommand saveInclusionCommand;
                if (!(pFolio.Inclusions == null || pFolio.Inclusions.Count == 0))
                {
                    foreach (FolioInclusions oFolioInclusions in pFolio.Inclusions)
                    {
                        string _sqlStrFolioInclusions = "call spInsertFolioInclusions('" + GlobalVariables.gHotelId + "','" + oFolioInclusions.FolioID + "','" + oFolioInclusions.Memo + "','" + GlobalVariables.gLoggedOnUser + "')";

                        saveInclusionCommand = new MySqlCommand(_sqlStrFolioInclusions, GlobalVariables.gPersistentConnection);
                        saveInclusionCommand.Transaction = poTrans;

                        saveInclusionCommand.ExecuteNonQuery();
                    }
                }
			}
			catch (Exception ex)
			{
                //poTrans.Rollback();
				throw ex;
			}

		}

		public void updateFolio(Folio poFolio, ref MySqlTransaction poDBTransaction)
		{

			try
			{
				string _sqlStrFolio = "call spUpdateFolio(" +
									   GlobalVariables.gHotelId + ",'" +
									   poFolio.FolioID + "','" +
									   poFolio.AccountID + "','" +
                                       poFolio.ReferenceNo + "','" +
									   poFolio.FolioType + "','" +
									   poFolio.GroupName + "','" +
									   poFolio.AccountType + "'," +
									   poFolio.NoofAdults + "," +
									   poFolio.NoOfChild + ",'" +
									   poFolio.MasterFolio + "','" +
									   poFolio.CompanyID + "','" +
									   poFolio.AgentID + "','" +
									   poFolio.Source + "','" +
									   string.Format("{0:yyyy-MM-dd HH:mm:ss}", poFolio.FromDate) + "','" +
									   string.Format("{0:yyyy-MM-dd HH:mm:ss}", poFolio.Todate) + "','" +
									   string.Format("{0:yyyy-MM-dd HH:mm:ss}", poFolio.ArrivalDate) + "','" +
									   string.Format("{0:yyyy-MM-dd HH:mm:ss}", poFolio.DepartureDate) + "','" +
									   poFolio.PackageID + "','" +
									   poFolio.Status + "','" +
									   GlobalFunctions.addSlashes(poFolio.Remarks) + "','" +
									   poFolio.TerminalId + "','" +
									   poFolio.ShiftCode + "','" +
									   poFolio.SupervisorId + "','" +
									   poFolio.Sales_Executive + "','" +
									   poFolio.Payment_Mode + "','" +
									   poFolio.Purpose + "','" +
									   poFolio.REASON_FOR_CANCEL + "','" +
									   poFolio.TaxExempted + "','" +
									   poFolio.FolioETA + "','" +
									   poFolio.FolioETD + "','" +
									   poFolio.UpdatedBy + "')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStrFolio, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = poDBTransaction;
                updateCommand.ExecuteNonQuery();

                //>> for checking if record has been updated
                //if (updateCommand.ExecuteNonQuery() <= 0)
                //{
                //    if (poFolio.FolioType != "JOINER")
                //    {
                //        throw new Exception("Folio is marked as read-only. Other user has updated this Folio.");
                //    }
                //}

				saveFolioPrivilege(poFolio, ref poDBTransaction);

				// >> to save FolioPackage
				MySqlCommand savePackageCommand;
				if (!(poFolio.Package == null))
				{
                    if (DeleteFolioPackage(poFolio.FolioID))
                    {
                        foreach (FolioPackage oFolioPackage in poFolio.Package)
                        {
                            string _sqlStrPackage = "call spInsertFolioPackages('" +
                                                          GlobalVariables.gHotelId + "','" +
                                                          oFolioPackage.FolioID + "','" +
                                                          oFolioPackage.TransactionCode + "','" +
                                                          oFolioPackage.Basis + "','" +
                                                          oFolioPackage.PercentOff + "','" +
                                                          oFolioPackage.AmountOff + "','" +
                                                          oFolioPackage.DaysApplied + "','" +
                                                          GlobalVariables.gLoggedOnUser + "','" +
                                                          string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateFrom) + "','" +
                                                          string.Format("{0:yyyy-MM-dd hh:mm:ss}", oFolioPackage.DateTo) + "')";

                            savePackageCommand = new MySqlCommand(_sqlStrPackage, GlobalVariables.gPersistentConnection);

                            savePackageCommand.Transaction = poDBTransaction;
                            savePackageCommand.ExecuteNonQuery();

                        }
                    }
				}

                // >> to save FolioInclusions
                MySqlCommand saveInclusionsCommand;
                if (!(poFolio.Inclusions == null))
                {
                    if (DeleteFolioInclusions(poFolio.FolioID))
                    {
                        foreach (FolioInclusions oFolioInclusions in poFolio.Inclusions)
                        {
                            string _sqlStrPackage = "call spInsertFolioInclusions('" + GlobalVariables.gHotelId + "','" + oFolioInclusions.FolioID + "','" + oFolioInclusions.Memo + "','" + GlobalVariables.gLoggedOnUser + "')";

                            saveInclusionsCommand = new MySqlCommand(_sqlStrPackage, GlobalVariables.gPersistentConnection);

                            saveInclusionsCommand.Transaction = poDBTransaction;
                            saveInclusionsCommand.ExecuteNonQuery();

                        }
                    }
                }

				// >> to save Privilege
				MySqlCommand savePrivilegeCommand;
				if (!(poFolio.Privileges == null))
				{

					foreach (Privilege oPrivilege in poFolio.Privileges)
					{
						string _sqlStrPrivilege = "call spInsertFolioPrivilege(\'" +
														oPrivilege.HotelId + "','" +
														oPrivilege.FolioID + "','" +
														oPrivilege.TransactionCode + "','" +
														oPrivilege.Basis + "','" +
														oPrivilege.Percentoff + "','" +
														oPrivilege.AmountOff + "')";

						savePrivilegeCommand = new MySqlCommand(_sqlStrPrivilege, GlobalVariables.gPersistentConnection);

						savePrivilegeCommand.Transaction = poDBTransaction;
						savePrivilegeCommand.ExecuteNonQuery();
					}
				}

				// >> to save Folio Recurring Charges
				MySqlCommand saveRecurringCharge;
				if (!(poFolio.RecurringCharges == null))
				{
                    if (DeleteFolioRecurringCharges(poFolio.FolioID))
                    {
                        foreach (RecurringCharge oRecurringCharge in poFolio.RecurringCharges)
                        {
                            string _sqlStr = "call spInsertFolioRecurringCharge('" +
                                                   GlobalVariables.gHotelId + "','" +
                                                   oRecurringCharge.FolioID + "','" +
                                                   oRecurringCharge.TransactionCode + "','" +
                                                   oRecurringCharge.Memo + "','" +
                                                   oRecurringCharge.Amount + "','" +
                                                   string.Format("{0:yyyy-MM-dd}", oRecurringCharge.FromDate) + "','" +
                                                   string.Format("{0:yyyy-MM-dd}", oRecurringCharge.ToDate) + "','" +
                                                   GlobalVariables.gLoggedOnUser + "'," +
                                                   oRecurringCharge.SummaryFlag + "," +
                                                   oRecurringCharge.PackageID + ",'" +
                                                   oRecurringCharge.SubAccount + "','" +
                                                   oRecurringCharge.RoomID + "','" +
                                                   oRecurringCharge.QtyHrs + "','" +
                                                   oRecurringCharge.Discount + "','" +
                                                   oRecurringCharge.RateType + "','" +
                                                   oRecurringCharge.BaseAmount +  "','" +
                                                   oRecurringCharge.Tax + "')";

                            saveRecurringCharge = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

                            saveRecurringCharge.Transaction = poDBTransaction;
                            saveRecurringCharge.ExecuteNonQuery();
                        }
                    }
				}

				// >> to save Folio Routing
				this.RemoveFolioRouting(poFolio, ref poDBTransaction);

				MySqlCommand saveFolioRouting;
				if (!(poFolio.FolioRouting == null))
				{

					foreach (FolioRouting oFolioRouting in poFolio.FolioRouting)
					{
						string _sqlStrRouting = "call spInsertFolioRouting(" +
													  GlobalVariables.gHotelId + ",'" +
													  poFolio.FolioID + "','" +
													  oFolioRouting.SubFolio + "','" +
													  oFolioRouting.TransactionCode + "','" +
													  oFolioRouting.Basis + "'," +
													  oFolioRouting.PercentCharged + "," +
													  oFolioRouting.AmountCharged + ",'" +
													  GlobalVariables.gLoggedOnUser + "','" +
													  poFolio.UpdatedBy + "')";

						saveFolioRouting = new MySqlCommand(_sqlStrRouting, GlobalVariables.gPersistentConnection);
						saveFolioRouting.Transaction = poDBTransaction;
						saveFolioRouting.ExecuteNonQuery();
					}
				}

				//updateCommand.ExecuteNonQuery();

				// save FOLIO LEDGERS [a,b,c,d]
				if (!(poFolio.SubFolios == null || poFolio.SubFolios.Count == 0))
				{
					foreach (SubFolio subF in poFolio.SubFolios)
					{
						string _sqlStrFolioLedger = "";
						if (poFolio.Guest != null)
						{
							_sqlStrFolioLedger = "call spUpdateFolioLedger('" +
														subF.Folio.FolioID + "','" +
														subF.SubFolio_Renamed + "','" +
														poFolio.Guest.AccountId + "','" +
														GlobalVariables.gHotelId + "','" +
														GlobalVariables.gLoggedOnUser + "')";
						}
						else
						{
							_sqlStrFolioLedger = "call spUpdateFolioLedger('" +
														subF.Folio.FolioID + "','" +
														subF.SubFolio_Renamed + "','" +
														poFolio.Company.CompanyId + "','" +
														GlobalVariables.gHotelId + "','" +
														GlobalVariables.gLoggedOnUser + "')";
						}

						MySqlCommand _insertFolioLedger = new MySqlCommand(_sqlStrFolioLedger, GlobalVariables.gPersistentConnection);
						_insertFolioLedger.Transaction = poDBTransaction;
						_insertFolioLedger.ExecuteNonQuery();

					}
				}

                // for updating groupnames and company id of dependents if has been changed
                if (poFolio.FolioType == "GROUP")
                {
                    string _updateCommand="update folio set groupname='" + poFolio.GroupName + "', companyID='" + poFolio.CompanyID + "' where masterfolio='" + poFolio.FolioID + "'";
                    MySqlCommand _updateGroupName = new MySqlCommand(_updateCommand, GlobalVariables.gPersistentConnection);
                    _updateGroupName.Transaction=poDBTransaction;
                    _updateGroupName.ExecuteNonQuery();
                }

			}
			catch (Exception ex)
			{
                //poDBTransaction.Rollback();
				throw ex;
			}

		}

		public DataTable getGroupBookingForExportToExcel()
		{ 
			
			try
			{
				string _sqlStr = "call spGetGroupBookingForExportToExcel()";
				DataTable _tempData = new DataTable();
				MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtSelect.Fill(_tempData);

				return _tempData;
			}

			catch(Exception ex)
			{
			throw ex;
			}
		}

        public int updateFolioStatusToCheckedOut(string pFolioId, string pRemarks, ref MySqlTransaction pDBTrans)
        {

            int _rowsAffected = 0;
            DateTime _checkedOutTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToShortTimeString());
            try
            {
                string _sqlStr = "call spUpdateFolioStatusToCheckedOut('" +
                                        pFolioId + "','" +
                                        GlobalFunctions.addSlashes(pRemarks) + "','" +
                                        GlobalVariables.gAuditDate + "','" +
                                        GlobalVariables.gHotelId + "','" +
                                        GlobalVariables.gLoggedOnUser + "','" +
                                        string.Format("{0:yyyy-MM-dd HH:mm:ss}", _checkedOutTime) + "')";

                MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                updateCommand.Transaction = pDBTrans;

                _rowsAffected = updateCommand.ExecuteNonQuery();

                if (_rowsAffected <= 0)
                {
                    throw (new Exception("No rows affected."));
                }

                return _rowsAffected;
            }
            catch (Exception ex)
            {
                //pDBTrans.Rollback();
                throw (ex);
            }
        }

		public int updateJoinerFolioStatusToCheckedOut(string pMasterFolioId, string pFolioId, ref MySqlTransaction pDBTrans)
		{
			int _rowsAffected = 0;

			try
			{
				string _sqlStr = "call spUpdateJoinerFolioStatusToCheckedOut('" +
									   pMasterFolioId + "','" +
									   pFolioId + "','" +
									   GlobalVariables.gAuditDate + "','" +
									   GlobalVariables.gHotelId + "','" +
									   GlobalVariables.gLoggedOnUser + "')";

				MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = pDBTrans;

				_rowsAffected = updateCommand.ExecuteNonQuery();

				if (_rowsAffected <= 0)
				{
					throw (new Exception("No rows affected."));
				}

				return _rowsAffected;
			}
			catch (Exception ex)
			{
                //pDBTrans.Rollback();
				throw (ex);
			}
		}

        public double getFolioTotalCharges(string pFolioID, string pSubFolio)
        {
            try
            {
                string query = "select sum(netAmount) from foliotransactions, transactioncode, trantypes where folioid='" +
                    pFolioID + "' and foliotransactions.transactioncode=transactioncode.trancode and " +
                    "transactioncode.trantypeid=trantypes.trantypeid and foliotransactions.hotelid=" + GlobalVariables.gHotelId +
                    " and trantypes.trantypeid=1 and foliotransactions.subfolio='" + pSubFolio + "' and foliotransactions.acctside='DEBIT'" +
                    " and foliotransactions.status!='VOID'";
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                double _amount = double.Parse(cmd.ExecuteScalar().ToString());

                return _amount;
            }
            catch
            {
                return 0;
            }
        }

        public double getFolioTotalCreditCharges(string pFolioID, string pSubFolio)
        {
            try
            {
                string query = "select sum(netAmount) from foliotransactions, transactioncode, trantypes where folioid='" +
                    pFolioID + "' and foliotransactions.transactioncode=transactioncode.trancode and " +
                    "transactioncode.trantypeid=trantypes.trantypeid and foliotransactions.hotelid=" + GlobalVariables.gHotelId +
                    " and trantypes.trantypeid=1 and foliotransactions.subfolio='" + pSubFolio + "' and foliotransactions.acctside = 'CREDIT'" +
                    " AND foliotransactions.status!='VOID'";
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                double _amount = double.Parse(cmd.ExecuteScalar().ToString());

                return _amount;
            }
            catch
            {
                return 0;
            }
        }

        public double getFolioTrDBDebitSide(string pFolioID, string pSubFolio)
        {
            try
            {
                string query = "select sum(netAmount) from foliotransactions, transactioncode where foliotransactions.transactioncode=transactioncode.trancode " +
                    "and transactioncode.trancode='4100' and foliotransactions.acctside='DEBIT' and foliotransactions.folioid= '" + pFolioID + 
                    "' and foliotransactions.hotelid=" + GlobalVariables.gHotelId + " and foliotransactions.subfolio='" + pSubFolio + "'" +
                    " and foliotransactions.status!='VOID'";
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                double _amount = double.Parse(cmd.ExecuteScalar().ToString());

                return _amount;
            }
            catch
            {
                return 0;
            }
        }

        public double getFolioTrDBCreditSide(string pFolioID, string pSubFolio)
        {
            try
            {
                string query = "select sum(netAmount) from foliotransactions, transactioncode where foliotransactions.transactioncode=transactioncode.trancode " +
                    "and transactioncode.trancode='4100' and foliotransactions.acctside='CREDIT' and foliotransactions.folioid= '" + pFolioID +
                    "' and foliotransactions.hotelid=" + GlobalVariables.gHotelId + " and foliotransactions.subfolio='" + pSubFolio + "'" +
                    " and foliotransactions.status!='VOID'";
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                double _amount = double.Parse(cmd.ExecuteScalar().ToString());

                return _amount;
            }
            catch
            {
                return 0;
            }
        }

        public double getFolioComplimentaryPayments(string pFolioID, string pSubFolio)
        {
            try
            {
                string query = "select sum(netAmount) from foliotransactions, transactioncode, trantypes where folioid='" +
                    pFolioID + "' and foliotransactions.transactioncode=transactioncode.trancode and " +
                    "transactioncode.trantypeid=trantypes.trantypeid and foliotransactions.hotelid=" + GlobalVariables.gHotelId +
                    " and trantypes.trantypeid=7 and foliotransactions.subfolio='" + pSubFolio + "'" +
                    " and foliotransactions.status!='VOID'";
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                double _amount = double.Parse(cmd.ExecuteScalar().ToString());

                return _amount;
            }
            catch
            {
                return 0;
            }
        }

        public bool functionIsConflict(string pRoom, string pDate, string pTime, string pFolioID)
        {
            try
            {
                //string query = "select * from folioschedules where roomid='" + pRoom + "' and '" + pDate + "' between date(folioschedules.fromdate) and date(folioschedules.todate) and '" +
                //    pTime + "' between time(starttime) and time(endtime) and folioschedules.folioid!='" + pFolioID + "' and fGetFolioStatus(folioid)!='CLOSED' and fGetFolioStatus(folioid)!='CANCELLED' and fGetFolioStatus(folioid)!='NO SHOW' and fGetFolioStatus(folioid)!='WAIT LIST'";
                string query = "call spCheckFunctionIsConflict('" + pRoom + "','" + pDate + "','" + pTime + "','" + pFolioID + "')";
                MySqlDataAdapter da = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public void updateFolioPax(string folioid, decimal pax)
        {
            try
            {
                string query = "update folio set noOfAdults=" + pax + " where folioid='" + folioid + "'";
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getCheckedInGroups(string pDate)
        {
            try
            {
                string query = "call spGetCheckedInGroups('" + pDate + "'," + GlobalVariables.gHotelId + ")";
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                DataTable dTable = new DataTable();
                cmd.Fill(dTable);

                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool checkIfOtherFolioIsCheckedIn(string pFolioID, string pRoomID, string pDate)
        {
            try
            {
                string _query = "select eventid from roomevents where eventtype = 'IN HOUSE' and eventid != '" + pFolioID + "' and roomid = '" + pRoomID + "' and eventdate = '" + pDate + "'";
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter(_query, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();
                _oDataAdapter.Fill(_oDataTable);

                if (_oDataTable.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int updateCancellation(string pFolioID, string pReason, string pReasonType, string pCancelBookingType, string pFutureAction)
        {
            MySqlCommand _update = new MySqlCommand("call spUpdateCancellation('" + pFolioID + "','" + pReason + "','" + pReasonType + "','" + pCancelBookingType + "','" + pFutureAction + "')", GlobalVariables.gPersistentConnection);
            try
            {
                int _rowsAffected = _update.ExecuteNonQuery();
                return _rowsAffected;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioDAO.updateCancellation\r\n" + ex.Message);
            }
            finally
            {
                _update.Dispose();
            }
        }

        public string getFolioStatus(string pFolioID)
        {
            MySqlCommand _query = new MySqlCommand("call spGetFolioStatus('" + pFolioID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                return _query.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                _query.Dispose();
            }
        }

        public DataTable getMarketingOfficers()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetMarketingOfficers('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioDAO.getMarketingOfficers\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getEventOfficers()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventOfficersFullName('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @FolioDAO.getMarketingOfficers\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
	}
}