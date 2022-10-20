using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.DataAccessLayer
{
	class BackOfficeConfigDAO
	{

		private MySqlConnection lMySqlConnection;
		public BackOfficeConfigDAO()
		{
			lMySqlConnection = GlobalVariables.gPersistentConnection;
		}

		public DataTable getBackOfficeConfig()
		{
			DataTable _configTable = new DataTable();
			try
			{
				string _strQuery = "call spSelectBackofficeConfig(" 
								  + GlobalVariables.gHotelId + ")";

				MySqlDataAdapter _dtAdapter = new MySqlDataAdapter(_strQuery, lMySqlConnection);
				_dtAdapter.Fill(_configTable);

				return _configTable;
			}
			catch(Exception ex)
			{
				throw (ex);
			}
		}

		public int insertBackOfficeConfig(object poBackOfficeConfig, ref MySqlTransaction prTrans)
		{
			
			try
			{
				string BACK_OFFICE_CODE = poBackOfficeConfig.GetType().GetProperty("BackOfficeCode").GetValue(poBackOfficeConfig, null).ToString();

				string BACK_OFFICE_NAME = poBackOfficeConfig.GetType().GetProperty("BackOfficeCode").GetValue(poBackOfficeConfig, null).ToString();
				string BACK_OFFICE_VERSION = poBackOfficeConfig.GetType().GetProperty("BackOfficeVersion").GetValue(poBackOfficeConfig, null).ToString();
				string POSTING_SCHEDULE = poBackOfficeConfig.GetType().GetProperty("PostingSchedule").GetValue(poBackOfficeConfig, null).ToString();
				string POSTING_SCHEDULE_YEAR = poBackOfficeConfig.GetType().GetProperty("PostingScheduleYear").GetValue(poBackOfficeConfig, null).ToString();
				string POSTING_SCHEDULE_MONTH = poBackOfficeConfig.GetType().GetProperty("PostingScheduleMonth").GetValue(poBackOfficeConfig, null).ToString();
				string POSTING_SCHEDULE_DAY = poBackOfficeConfig.GetType().GetProperty("PostingScheduleDay").GetValue(poBackOfficeConfig, null).ToString();
				string CONNECTION_STRING = poBackOfficeConfig.GetType().GetProperty("ConnectionString").GetValue(poBackOfficeConfig, null).ToString();
				string POSTING_SCHEDULE_TIME = poBackOfficeConfig.GetType().GetProperty("PostingScheduleTime").GetValue(poBackOfficeConfig, null).ToString();

				POSTING_SCHEDULE_MONTH = string.Format("{0:yyyy-MM-dd hh:mm:ss}", 
										 DateTime.Parse(POSTING_SCHEDULE_MONTH));

				string strQuery = "call spInsertBackofficeConfig('" + BACK_OFFICE_CODE + "','" 
																	+ BACK_OFFICE_NAME + "','" 
																	+ BACK_OFFICE_VERSION + "','" 
																	+ POSTING_SCHEDULE + "','" 
																	+ POSTING_SCHEDULE_YEAR + "','" 
																	+ POSTING_SCHEDULE_MONTH + "','" 
																	+ POSTING_SCHEDULE_DAY + "','" 
																	+ POSTING_SCHEDULE_TIME + "','" 
																	+ CONNECTION_STRING + "'," 
																	+ GlobalVariables.gHotelId + ",'" 
																	+ GlobalVariables.gLoggedOnUser 
																+ "')";

				MySqlCommand _insertCommand = new MySqlCommand(strQuery, lMySqlConnection);
				_insertCommand.Transaction = prTrans;
				return _insertCommand.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public int deleteBackOfficeConfig(ref MySqlTransaction prTrans)
		{

			try
			{
				
				string strQuery = "call spDeleteBackOfficeConfig(" + GlobalVariables.gHotelId + ")";

				MySqlCommand _deleteCommand = new MySqlCommand(strQuery, lMySqlConnection);
				_deleteCommand.Transaction = prTrans;
				return _deleteCommand.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public DataTable getUnPostedFolioTransactions(string pAuditDate)
		{
			try
			{
				string _sqlStr = "call spGetUnPostedFolioTransactions('" + pAuditDate + "')";

				MySqlDataAdapter _dtAdapter = new MySqlDataAdapter(_sqlStr, lMySqlConnection);
				DataTable dtTable = new DataTable();
				_dtAdapter.Fill(dtTable);

				return dtTable;
			}
			catch (Exception ex)
			{
				throw(ex);
			}
		}


	}
}
