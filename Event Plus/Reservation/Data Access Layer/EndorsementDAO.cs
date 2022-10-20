using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
	public class EndorsementDAO
	{
		public EndorsementDAO()
		{ }

		public DataTable getAllEndorsements()
		{
			try
			{
				DataTable _dtTemp = new DataTable("Endorsements");

				string _sqlStr = "call spSelectAllEndorsements(" + GlobalVariables.gHotelId + ")";
				MySqlDataAdapter _dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

				_dtAdapter.Fill(_dtTemp);


				return _dtTemp;
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public int updateEndorsement(object oEndorsement)
		{

			int _rowsAffected = 0;

			try
			{

				string _id = oEndorsement.GetType().GetProperty("Id").GetValue(oEndorsement, null).ToString();

				//string _logDate = oEndorsement.GetType().GetProperty("Id").GetValue(oEndorsement, null).ToString();
				//string _terminalNo = oEndorsement.GetType().GetProperty("TerminalNo").GetValue(oEndorsement, null).ToString();
				//string _shiftCode = oEndorsement.GetType().GetProperty("ShiftCode").GetValue(oEndorsement, null).ToString();
				string _loggedUser = GlobalVariables.gLoggedOnUser;
				string _endorsementDescription = oEndorsement.GetType().GetProperty("EndorsementDescription").GetValue(oEndorsement, null).ToString();
				//string _statusFlag = oEndorsement.GetType().GetProperty("StatusFlag").GetValue(oEndorsement, null).ToString();
				//string _endorsementRemarks = oEndorsement.GetType().GetProperty("EndorsementRemarks").GetValue(oEndorsement, null).ToString();
				//string _acknowledgedBy = oEndorsement.GetType().GetProperty("AcknowledgedBy").GetValue(oEndorsement, null).ToString();
				//string _acknowledgeAtTerminal = oEndorsement.GetType().GetProperty("AcknowledgeAtTerminal").GetValue(oEndorsement, null).ToString();
				//string _acknowledgeAtShiftCode = oEndorsement.GetType().GetProperty("AcknowledgeAtShiftCode").GetValue(oEndorsement, null).ToString();

				string _sqlStr = "call spUpdateShiftEndorsement(" 
									   + _id + ",'" 
									   + _endorsementDescription + "','" 
									   + _loggedUser + "')";

				MySqlCommand _updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				_rowsAffected = _updateCommand.ExecuteNonQuery();
				//MySqlDataAdapter _dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

				//_dtAdapter.Fill(_dtTemp);


				return _rowsAffected;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public int acknowledgeEndorsement(object oEndorsement)
		{

			int _rowsAffected = 0;

			try
			{

				string _id = oEndorsement.GetType().GetProperty("Id").GetValue(oEndorsement, null).ToString();

				//string _logDate = oEndorsement.GetType().GetProperty("Id").GetValue(oEndorsement, null).ToString();
				//string _terminalNo = oEndorsement.GetType().GetProperty("TerminalNo").GetValue(oEndorsement, null).ToString();
				//string _shiftCode = oEndorsement.GetType().GetProperty("ShiftCode").GetValue(oEndorsement, null).ToString();
				//string _loggedUser = GlobalVariables.gLoggedOnUser;
				//string _endorsementDescription = oEndorsement.GetType().GetProperty("EndorsementDescription").GetValue(oEndorsement, null).ToString();
				//string _statusFlag = oEndorsement.GetType().GetProperty("StatusFlag").GetValue(oEndorsement, null).ToString();
				string _endorsementRemarks = oEndorsement.GetType().GetProperty("EndorsementRemarks").GetValue(oEndorsement, null).ToString();
				string _acknowledgedBy = GlobalVariables.gLoggedOnUser;
				string _acknowledgeAtTerminal = GlobalVariables.gTerminalID.ToString();
				string _acknowledgeAtShiftCode = GlobalVariables.gShiftCode.ToString();

				string _sqlStr = "call spAcknowledgeShiftEndorsement("
									   + _id + ",'"
									   + _endorsementRemarks + "','"
									   + _acknowledgedBy + "','"
									   + _acknowledgeAtTerminal + "','"
									   + _acknowledgeAtShiftCode + "')";

				MySqlCommand _updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				_rowsAffected = _updateCommand.ExecuteNonQuery();
				
				return _rowsAffected;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int insertEndorsement(object oEndorsement)
		{

			int _rowsAffected = 0;

			try
			{

				//string _id = oEndorsement.GetType().GetProperty("Id").GetValue(oEndorsement, null).ToString();

				DateTime _logDate = DateTime.Parse( oEndorsement.GetType().GetProperty("LogDate").GetValue(oEndorsement, null).ToString() );
				string _terminalNo = oEndorsement.GetType().GetProperty("TerminalNo").GetValue(oEndorsement, null).ToString();
				string _shiftCode = oEndorsement.GetType().GetProperty("ShiftCode").GetValue(oEndorsement, null).ToString();
				string _loggedUser = oEndorsement.GetType().GetProperty("LoggedUser").GetValue(oEndorsement, null).ToString();
				string _endorsementDescription = oEndorsement.GetType().GetProperty("EndorsementDescription").GetValue(oEndorsement, null).ToString();
				string _statusFlag = oEndorsement.GetType().GetProperty("StatusFlag").GetValue(oEndorsement, null).ToString();
				string _endorsementRemarks = oEndorsement.GetType().GetProperty("EndorsementRemarks").GetValue(oEndorsement, null).ToString();
				//string _acknowledgedBy = GlobalVariables.gLoggedOnUser;
				//string _acknowledgeAtTerminal = GlobalVariables.gTerminalID.ToString();
				//string _acknowledgeAtShiftCode = GlobalVariables.gShiftCode.ToString();

				string _sqlStr = "call spInsertShiftEndorsement('"
									   + _logDate.ToString("yyyy-MM-dd HH:mm:ss") + "','"
									   + _terminalNo + "','"
									   + _shiftCode + "','"
									   + _loggedUser + "','"
									   + _endorsementDescription + "','"
									   + GlobalVariables.gHotelId + "')";

				MySqlCommand _insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				_rowsAffected = _insertCommand.ExecuteNonQuery();

				return _rowsAffected;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}


}
