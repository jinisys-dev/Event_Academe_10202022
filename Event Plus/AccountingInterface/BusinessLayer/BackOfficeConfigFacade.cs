using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Jinisys.Hotel.AccountingInterface.DataAccessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.BusinessLayer
{
	class BackOfficeConfigFacade
	{

		public BackOfficeConfigFacade()
		{ 
		}

		private BackOfficeConfigDAO loBackOfficeConfigDao = null;

		public BackOfficeConfig getBackOfficeConfig()
		{
			loBackOfficeConfigDao = new BackOfficeConfigDAO();
			BackOfficeConfig _oBackOfficeConfig = new BackOfficeConfig();

			try
			{
				DataTable _dtConfig = loBackOfficeConfigDao.getBackOfficeConfig();

				DataRow _dRow = _dtConfig.Rows[0];

				_oBackOfficeConfig.BackOfficeCode = _dRow["BACK_OFFICE_CODE"].ToString();
				_oBackOfficeConfig.BackOfficeName = _dRow["BACK_OFFICE_NAME"].ToString();
				_oBackOfficeConfig.BackOfficeVersion = _dRow["BACK_OFFICE_VERSION"].ToString();
				_oBackOfficeConfig.PostingSchedule = _dRow["POSTING_SCHEDULE"].ToString();
				_oBackOfficeConfig.PostingScheduleYear = int.Parse(_dRow["POSTING_SCHEDULE_YEAR"].ToString());
				_oBackOfficeConfig.PostingScheduleMonth = _dRow["POSTING_SCHEDULE_MONTH"].ToString();
				_oBackOfficeConfig.PostingScheduleDay = int.Parse(_dRow["POSTING_SCHEDULE_DAY"].ToString());
				_oBackOfficeConfig.ConnectionString = _dRow["CONNECTION_STRING"].ToString();
				_oBackOfficeConfig.PostingScheduleTime = _dRow["POSTING_SCHEDULE_TIME"].ToString();

				return _oBackOfficeConfig;

			}
			catch(Exception ex)
			{
				throw (ex);
			}

		}

		public int insertBackOfficeConfig(BackOfficeConfig poBackOfficeConfig)
		{
			loBackOfficeConfigDao = new BackOfficeConfigDAO();
			MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

			try
			{
				
				loBackOfficeConfigDao.deleteBackOfficeConfig(ref _oTrans);
				loBackOfficeConfigDao.insertBackOfficeConfig((object)poBackOfficeConfig, ref _oTrans);


				_oTrans.Commit();
				return 1;
			}
			catch(Exception ex)
			{
				_oTrans.Rollback();
				throw (ex);
			}
		}


		public DataTable getUnpostedFolioTransactions()
		{
			loBackOfficeConfigDao = new BackOfficeConfigDAO();
			return loBackOfficeConfigDao.getUnPostedFolioTransactions(GlobalVariables.gAuditDate);
		}

	}
}
