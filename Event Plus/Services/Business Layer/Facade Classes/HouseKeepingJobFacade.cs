using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Services.DataAccessLayer;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.Services.BusinessLayer
{

    public class HouseKeepingJobFacade 
    {


        private HouseKeepingJobDAO oHouseKeepingJobDAO ;
        public HouseKeepingJobFacade()
        {
            oHouseKeepingJobDAO = new HouseKeepingJobDAO(); ;
        }

        public HousekeepingJob GetRoomCleaningStatus()
        {
            oHouseKeepingJobDAO = new HouseKeepingJobDAO();
            return oHouseKeepingJobDAO.getRoomCleaningStatus();
        }

        public HousekeepingJob GetRoomByCleaningStatus(string CleaningStatus)
        {
            oHouseKeepingJobDAO = new HouseKeepingJobDAO();
            return oHouseKeepingJobDAO.getRoomByCleaningStatus(CleaningStatus);
        }

        public void UpdateHouseKeepingJob(ref string RoomId, ref string CleaningStatus)
        {
            oHouseKeepingJobDAO = new HouseKeepingJobDAO();
            oHouseKeepingJobDAO.updateRoomCleaningStatus(System.Convert.ToInt32(RoomId), CleaningStatus);
        }

        public void SetOccupiedRoomsDirty()
        {
            oHouseKeepingJobDAO = new HouseKeepingJobDAO();
            oHouseKeepingJobDAO.setOccupiedRoomsDirty();
        }

        // >> N E W --
        // >> EDITED : 3-8-2006
        // >> jrom
        public bool appendHousekeepingJobs(HousekeepingJobs oHousekeepingJobs)
        {
            bool stat = true;
            oHouseKeepingJobDAO = new HouseKeepingJobDAO();

            HousekeepingJob oHousekeepingJob = new HousekeepingJob();
            foreach (HousekeepingJob tempLoopVar_oHousekeepingJob in oHousekeepingJobs)
            {
                oHousekeepingJob = tempLoopVar_oHousekeepingJob;
                int rowsAffected=oHouseKeepingJobDAO.appendHousekeepingJobs(oHousekeepingJob);
                if (rowsAffected > 0)
                {
                    stat = true;
                }
                else
                {
                    stat = false;
                    return stat;
                }
            }

            return stat;
        }

        //public int verifyHouseKeepingJob(string superVisor, string roomid, string jobtype, bool isFolioPlusIntegrated)
        //{
        //    oHouseKeepingJobDAO = new HouseKeepingJobDAO();
        //    return oHouseKeepingJobDAO.verifyHouseKeepingJob(superVisor, roomid, jobtype, isFolioPlusIntegrated);
        //}
        //public int verifyHouseKeepingJob(string pSupervisor, string pRoomid, bool isFolioPlusIntegrated)
        //{
        //    oHouseKeepingJobDAO = new HouseKeepingJobDAO();
        //    return oHouseKeepingJobDAO.verifyHouseKeepingJob(superVisor, roomid, jobtype, isFolioPlusIntegrated);
        //}

		public int verifyHouseKeepingJob(string pSupervisor, string pRoomId, bool pSetRoomStatusToClean, MySqlConnection pDBconnection)
		{

			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.verifyHouseKeepingJob(pSupervisor, pRoomId, pSetRoomStatusToClean, pDBconnection);

		}

		public bool verifyHouseKeepingJob(string superVisor, int jobno)
		{

			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.verifyHouseKeepingJob(superVisor, jobno);

		}

		public bool updateMemo(int jobid, String memo)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.updateMemo(jobid, memo);
		}

		public String getMemo(int jobid)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.getMemo(jobid);
		}

		//>> from IHS

		public string hasUnfinishedTask(string housekeeperID, string roomid)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.hasUnfinishedTask(housekeeperID, roomid);
		}

		public string hasUnfinishedTask(string housekeeperID, string roomid, MySqlConnection con)
		{

			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.hasUnfinishedTask(housekeeperID, roomid, con);
		}

		public string CheckRoomIfHKJobStarted(string roomid, int hkjobType)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.CheckRoomIfHKJobStarted(roomid, hkjobType);

		}
		public string CheckRoomIfHKJobStarted(string roomid, int hkjobType, MySqlConnection con)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.CheckRoomIfHKJobStarted(roomid, hkjobType, con);

		}


		public DataTable getActiveHouseKeepingJobs(MySqlConnection con)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.getActiveHouseKeepingJobs(con);

		}
		public DataTable getActiveHouseKeepingJobs()
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			return oHouseKeepingJobDAO.getActiveHouseKeepingJobs();

		}

		public void Insert(DataRow row)
		{

			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			oHouseKeepingJobDAO.Insert(row);
		}
		public void Insert(DataRow row, MySqlConnection con)
		{

			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			oHouseKeepingJobDAO.Insert(row, con);
		}

		public void Update(DataRow row)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			oHouseKeepingJobDAO.recordEndCleaningProcess(row);
		}
        //public void recordEndCleanProcess(DataRow dataRow, bool pSetRoomStatusToClean, MySqlConnection dbConnection)
        public void recordEndCleanProcess(string pHotelId, string pRoomId, string pHousekeeperId, bool pSetRoomStatusToClean, MySqlConnection dbConnection)
		{
			oHouseKeepingJobDAO = new HouseKeepingJobDAO();
			oHouseKeepingJobDAO.recordEndCleanProcess(pHotelId, pRoomId, pHousekeeperId,pSetRoomStatusToClean, dbConnection);
		}



        public bool hasStartedCleaningAtRoom(string pPersonnelID, string pRoomID)
        {

            oHouseKeepingJobDAO = new HouseKeepingJobDAO();
            int HKjobNo = oHouseKeepingJobDAO.getHousekeepingJobNoToUpdate("1", pRoomID, pPersonnelID) ;

            if (HKjobNo > 0)
            {
                return true;
            }

            return false;

        }

    }

}
    

