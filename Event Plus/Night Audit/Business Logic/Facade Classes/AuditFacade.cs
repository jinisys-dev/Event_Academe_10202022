using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.NightAudit.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using System.Data;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.NightAudit.BusinessLayer
{
    public class AuditFacade
    {
        private MySqlConnection localConnection;
        public AuditFacade(MySqlConnection con)
        {
            localConnection = con;
        }
        public bool InsertAudit(Audit audit)
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.InsertAudit(audit);
        }
        public string getLastProcessedgAuditDate()
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.getLastProcessedAuditDate();
        }

        public string getServerTime()
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.getServerTime();
        }
        public string getServerDateAndTime()
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.getServerDateAndTime();
        }
        public bool SetToProcessed(Audit audit)
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.SetToProcessed(audit);
        }
        public string getCurrentAuditDate()
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.getCurrentAuditDate();
        }
        public Audit getCurrentAudit(string date)
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.getCurrentAudit(date);
        }

        public int countTodaysExpectedCheckOut()
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.countTodaysExpectedCheckOut();
        }

        public int countTodaysExpectedCheckIn()
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.countTodaysExpectedCheckIn();
        }

        public int countTodaysGroupRoomBlocks()
        {
            AuditDAO oAuditDAO = new AuditDAO(localConnection);
            return oAuditDAO.countTodaysGroupRoomBlocks();
        }

		public DayEndProcessConfig getDayEndProcessConfig()
		{
			AuditDAO oAuditDAO = new AuditDAO(localConnection);

			DayEndProcessConfig _oDayEndProcessConfig = new DayEndProcessConfig();
			DataTable _dtTemp = oAuditDAO.getDayEndProcessConfig();
			DataRow _dRow = _dtTemp.Rows[0];
			
			
			_oDayEndProcessConfig.HotelId = int.Parse( _dRow["hotelId"].ToString() );
			_oDayEndProcessConfig.ProcessType = _dRow["processType"].ToString();
			_oDayEndProcessConfig.ScheduleTime = _dRow["scheduleTime"].ToString();
			_oDayEndProcessConfig.TerminalNo = int.Parse( _dRow["terminalNo"].ToString() );
			_oDayEndProcessConfig.NotifySchedule = int.Parse( _dRow["notifySchedule"].ToString() );
			_oDayEndProcessConfig.ReportsToGenerate = _dRow["reportsToGenerate"].ToString();
			_oDayEndProcessConfig.BackupDatabase = int.Parse( _dRow["backupDatabase"].ToString() );

			return _oDayEndProcessConfig;
		}

		public bool saveDayEndProcessConfig(DayEndProcessConfig poDayEndProcessConfig)
		{
			AuditDAO oAuditDAO = new AuditDAO(localConnection);

			object objDayEndProcessConfig = (object)poDayEndProcessConfig;

			return oAuditDAO.saveDayEndProcessConfig(objDayEndProcessConfig);
		}


    }
}
