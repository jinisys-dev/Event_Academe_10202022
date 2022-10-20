using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Services.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Configuration;

namespace Jinisys.Hotel.Services.DataAccessLayer
{
        public class HouseKeepingJobDAO 
		{

            //private DataReaderToDatasetConverter oDataConverter ;
            private HousekeepingJob oHouseKeeping ;
            //private ParameterHelper oParameterHelper;

			public HouseKeepingJobDAO()
			{
                oHouseKeeping = new HousekeepingJob();
                //oDataConverter = new DataReaderToDatasetConverter();
                //oParameterHelper = new ParameterHelper();
			}
       
		    public HousekeepingJob getRoomCleaningStatus()
			{
                try
                {
                    oHouseKeeping = new HousekeepingJob();

					string _strSelect = "call spSelectRoomCleaningStatus()";

					MySqlDataAdapter dtSelect = new MySqlDataAdapter(_strSelect, GlobalVariables.gPersistentConnection);


                    //MySqlCommand selectHouseKeeping = new MySqlCommand("spSelectRoomCleaningStatus", GlobalVariables.gPersistentConnection);
                    //selectHouseKeeping.CommandType = CommandType.StoredProcedure;
                    //MySqlDataReader dataReaderHouseKeeping = selectHouseKeeping.ExecuteReader();
                    //oDataConverter.convertDataReaderToDataSet(dataReaderHouseKeeping, "HouseKeeping", oHouseKeeping);
					dtSelect.Fill(oHouseKeeping, "HouseKeeping");

                    return oHouseKeeping;
                }
                catch (Exception)
                {
                    return null;
                }
			}
			
			public HousekeepingJob getRoomByCleaningStatus(string a_CleaningStatus)
			{
                try
                {
                    oHouseKeeping = new HousekeepingJob();

					string _sqlStr = "call spSelectRoomByCleaningStatus('" + a_CleaningStatus + "')";
					MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

					_dtSelect.Fill(oHouseKeeping, "RoomCleaningStatus");
					//MySqlCommand selectHouseKeeping = new MySqlCommand("spSelectRoomByCleaningStatus", GlobalVariables.gPersistentConnection);
					//selectHouseKeeping.CommandType = CommandType.StoredProcedure;

					//MySqlParameter param = new MySqlParameter();
					//param.ParameterName = "pCleaningStatus";
					//param.Direction = ParameterDirection.Input;
					//param.DbType = DbType.String;
					//param.SourceColumn = "CleaningStatus";
					//param.Value = a_CleaningStatus;

					//selectHouseKeeping.Parameters.Add(param);

					//MySqlDataReader dataReaderHouseKeeping = selectHouseKeeping.ExecuteReader();
					//oDataConverter.convertDataReaderToDataSet(dataReaderHouseKeeping, "RoomCleaningStatus", oHouseKeeping);

                    return oHouseKeeping;
                }
                catch (Exception)
                {
                    return null;
                }
			}
			
			public void updateRoomCleaningStatus(int RoomId, string a_CleaningStatus)
			{
                try
                {
                    oHouseKeeping = new HousekeepingJob();

					string _sqlStr = "call spUpdateRoomCleaningStatus('" 
										   + a_CleaningStatus + "','" 
										   + RoomId + "')";

					MySqlCommand _updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
					
					_updateCommand.ExecuteNonQuery();
                }
                catch (Exception) { }
				
			}
           
			public int appendHousekeepingJobs(HousekeepingJob oHousekeepingJob)
			{
				try
				{
					
                    int rowsAffected = 0;
					string _sqlStr = "call spInsertHousekeepingJob('" +
										   oHousekeepingJob.HousekeepingDate.ToString("yyyy-MM-dd") + "','" +
										   oHousekeepingJob.HousekeeperId + "','" +
										   oHousekeepingJob.HousekeepingType + "','" +
										   oHousekeepingJob.RoomId + "','" +
										   oHousekeepingJob.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
										   oHousekeepingJob.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
										   oHousekeepingJob.Remarks + "','" + 
										   oHousekeepingJob.VerifiedBy + "','" +
										   oHousekeepingJob.TimeVerified.ToString("yyyy-MM-dd HH:mm:ss") + "','" + 
										   GlobalVariables.gHotelId + "','" + 
										   GlobalVariables.gLoggedOnUser + "')";

					MySqlCommand insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                    rowsAffected=insertCommand.ExecuteNonQuery();

                    return rowsAffected;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			
			public void setOccupiedRoomsDirty()
			{
				try
				{
					MySqlCommand updateRoomCommand = new MySqlCommand("call spSetOccupiedRoomsDirty('" 
																		    + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
					
					updateRoomCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


			public bool verifyHouseKeepingJob(string superVisor, int jobno)
			{
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}

				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				try
				{

					string timeVerified = DateTime.Now.ToString("hh:mm:ss tt");
					string cmdUpdateText = "call spHK_VerifyHouseKeepingJob('" 
												 + superVisor + "'," 
												 + jobno + ", '')";

					MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(cmdUpdateText, GlobalVariables.gPersistentConnection);
					cmdUpdateHouseKeepingjobs.Transaction = trans;
					cmdUpdateHouseKeepingjobs.ExecuteNonQuery();

					trans.Commit();
					return true;
				}
				catch (Exception ex)
				{
					trans.Rollback();
					throw ex;

				}

			}

            //public int verifyHouseKeepingJob(string superVisor, string roomid, string jobtype, bool isFolioPlusIntegrated)
            //{
            //    if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
            //    {
            //        GlobalVariables.gPersistentConnection.Open();
            //    }
            //    MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
            //    //DateTime Time = DateTime.Now;
            //    string _hkType = "CLEANING";
            //    switch (jobtype)
            //    { 
            //        case "1":
            //            _hkType = "CLEANING";
            //    break;
            //        case "2":
            //            _hkType = "MAKE-UP";
            //            break;
            //        case "3":
            //            _hkType = "VERIFICATION";
            //            break;
            //        default:
            //            break;
            //    }

            //    string timeVerified = string.Format("{0:hh}", DateTime.Now) + ":" + string.Format("{0:mm}", DateTime.Now) + ":" + string.Format("{0:ss}", DateTime.Now) + string.Format("{0:tt}", DateTime.Now);

            //    string cmdUpdateText = "call spHK_VerifyHouseKeepingJobByRoomID('" 
            //                                 + superVisor + "','" 
            //                                 + roomid + "','"
            //                                 + _hkType + "')";

            //    MySqlCommand cmdHousekeepingJob = new MySqlCommand(cmdUpdateText, GlobalVariables.gPersistentConnection);

            //    try
            //    {


            //        MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(cmdUpdateText, GlobalVariables.gPersistentConnection);
            //        cmdUpdateHouseKeepingjobs.Transaction = trans;
            //        int rowsAffected = 0;
            //        rowsAffected = cmdUpdateHouseKeepingjobs.ExecuteNonQuery();

            //        //>> update Folio Plus' Room Status
            //        if (isFolioPlusIntegrated)
            //        {

            //            string _strUpdateFolioRoomStatus = "call spUpdateRoomCleaningStatus('CLEAN','" + roomid + "')";

            //            MySqlCommand cmdUpdateRoom = new MySqlCommand(_strUpdateFolioRoomStatus, GlobalVariables.gPersistentConnection);
            //            cmdUpdateRoom.Transaction = trans;
            //            cmdUpdateRoom.ExecuteNonQuery();
            //        }



            //        trans.Commit();
            //        return rowsAffected;
            //    }
            //    catch (Exception ex)
            //    {

            //        trans.Rollback();
            //        throw ex;
            //        //return 0;
            //    }

            //}

            ////public int verifyHouseKeepingJob(string pSupervisor, string pRoomId, string pHousekeepingType, MySqlConnection con)
            //public int verifyHouseKeepingJob(string pSupervisor, string pRoomId, bool pSetRoomStatusToClean, MySqlConnection con)
            //{
            //    GlobalVariables.gPersistentConnection = con;
            //    if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
            //    {
            //        GlobalVariables.gPersistentConnection.Open();
            //    }
            //    MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            //    //string _hkType = "CLEANING";
            //    //switch (pHousekeepingType)
            //    //{
            //    //    case "1":
            //    //        _hkType = "CLEANING";
            //    //        break;
            //    //    case "2":
            //    //        _hkType = "MAKE-UP";
            //    //        break;
            //    //    case "3":
            //    //        _hkType = "VERIFICATION";
            //    //        break;
            //    //    default:
            //    //        break;
            //    //}

            //    //string cmdUpdateText = "call spHK_VerifyHouseKeepingJobByRoomID('"
            //    //                             + pSupervisor + "','"
            //    //                             + pRoomId + "','"
            //    //                             + _hkType + "')";


            //    string cmdUpdateText = "call spHK_VerifyHouseKeepingJobByRoomID('"
            //                                 + pSupervisor + "','"
            //                                 + pRoomId + "',')";


            //    //MySqlCommand cmdHousekeepingJob = new MySqlCommand(cmdUpdateText, GlobalVariables.gPersistentConnection);

            //    try
            //    {


            //        MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(cmdUpdateText, GlobalVariables.gPersistentConnection);
            //        cmdUpdateHouseKeepingjobs.Transaction = trans;

            //        int rowsAffected = 0;
            //        rowsAffected = cmdUpdateHouseKeepingjobs.ExecuteNonQuery();

            //        //>> update Folio Plus' Room Status
            //        if (pSetRoomStatusToClean && rowsAffected > 0)
            //        {

            //            string _strUpdateFolioRoomStatus = "call spUpdateRoomCleaningStatus('CLEAN','" + pRoomId + "')";

            //            MySqlCommand cmdUpdateRoom = new MySqlCommand(_strUpdateFolioRoomStatus, GlobalVariables.gPersistentConnection);
            //            cmdUpdateRoom.Transaction = trans;
            //            cmdUpdateRoom.ExecuteNonQuery();
            //        }


            //        trans.Commit();
            //        return rowsAffected;
            //    }
            //    catch (Exception ex)
            //    {

            //        trans.Rollback();
            //        throw ex;
            //    }

            //}


			//public int verifyHouseKeepingJob(string pSupervisor, string pRoomId, string pHousekeepingType, MySqlConnection con)
            public int verifyHouseKeepingJob(string pSupervisor, string pRoomId, bool pSetRoomStatusToClean, MySqlConnection con)
			{
                GlobalVariables.gPersistentConnection = con;
                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }


				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
			
				string cmdUpdateText = "call spHK_VerifyHouseKeepingJobByRoomID('" 
											 + pSupervisor + "','" 
											 + pRoomId + "')";

				try
				{
					MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(cmdUpdateText, GlobalVariables.gPersistentConnection);
					cmdUpdateHouseKeepingjobs.Transaction = trans;

					int rowsAffected = 0;
					rowsAffected = cmdUpdateHouseKeepingjobs.ExecuteNonQuery();

					//>> update Folio Plus' Room Status
                    if (pSetRoomStatusToClean && rowsAffected > 0)
					{

						string _strUpdateFolioRoomStatus = "call spUpdateRoomCleaningStatus('CLEAN','" + pRoomId + "')";

						MySqlCommand cmdUpdateRoom = new MySqlCommand(_strUpdateFolioRoomStatus, GlobalVariables.gPersistentConnection);
						cmdUpdateRoom.Transaction = trans;
						cmdUpdateRoom.ExecuteNonQuery();
					}


					trans.Commit();
					return rowsAffected;
				}
				catch (Exception ex)
				{

					trans.Rollback();
					throw ex;
				}

			}

			public bool updateMemo(int pJobId, string pMemo)
			{
				try
				{
					if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
					{
						GlobalVariables.gPersistentConnection.Open();
					}
					oHouseKeeping = new HousekeepingJob();

					string _sqlStr = "call spHK_UpdateHousekeepingJobMemo('" 
										   + pJobId + "','" 
										   + pMemo + "')";

					//MySqlCommand updateMemo = new MySqlCommand("Update housekeepingjobs set memo='" + memo + "' where housekeepingjobno=" + jobid, GlobalVariables.gPersistentConnection);
					MySqlCommand updateMemo = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

					int result;
					try
					{
						result = updateMemo.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						throw ex;
					}
					return true;

				}
				catch (Exception)
				{
					return false;
				}
			}

			public string getMemo(int pJobId)
			{
				try
				{
					if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
					{
						GlobalVariables.gPersistentConnection.Open();
					}
					oHouseKeeping = new HousekeepingJob();

					string _sqlStr = "call spHK_GetHousekeepingJobMemo(" 
										   + pJobId + ")";

					//MySqlCommand selectHouseKeeping = new MySqlCommand("Select memo from housekeepingjobs where housekeepingjobno=" + pJobId, GlobalVariables.gPersistentConnection);
					MySqlCommand selectHouseKeeping = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
					string memo = "";

					try
					{
						memo = selectHouseKeeping.ExecuteScalar().ToString();
					}
					catch (Exception)
					{ }
					return memo;

				}
				catch (Exception)
				{
					return null;
				}
			}


			//>> from IHS
			public string hasUnfinishedTask(string housekeeperID, string roomid)
			{
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				string _sqlStr = "call spHK_GetUnfinishedTasks('"
									   + roomid + "','"
									   + housekeeperID + "')";

				//MySqlCommand cmd = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				DataTable dt = new DataTable("PendingHouseKeepingJobs");
				_daSelect.Fill(dt);
				if (dt.Rows.Count != 0)
				{
					return dt.Rows[0]["roomid"].ToString();
				}

				return null;
			}

			public string hasUnfinishedTask(string housekeeperID, string roomid, MySqlConnection con)
			{
				GlobalVariables.gPersistentConnection = con;
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				string _sqlStr = "call spHK_GetUnfinishedTasks('" 
									   + roomid + "','" 
									   + housekeeperID + "')";


				//MySqlCommand cmd = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
				MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				DataTable dt = new DataTable("PendingHouseKeepingJobs");
				_daSelect.Fill(dt);
				if (dt.Rows.Count != 0)
				{
					return dt.Rows[0]["roomid"].ToString();
				}

				return null;
			}

			public string CheckRoomIfHKJobStarted(string pRoomId, int pHKJobType)
			{
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				string _sqlStr = "call spHK_CheckRoomIfHKJobStarted('" 
									   + pRoomId + "'," 
									   + pHKJobType + ")";

				MySqlCommand cmd = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

				string roomNo = "";
				try
				{
					roomNo = cmd.ExecuteScalar().ToString();
					return roomNo;
				}
				catch (Exception)
				{
					return null;
				}

			}

			public string CheckRoomIfHKJobStarted(string pRoomId, int pHKJobType, MySqlConnection con)
			{
				GlobalVariables.gPersistentConnection = con;
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				string _sqlStr = "call spHK_CheckRoomIfHKJobStarted('" 
									   + pRoomId + "'," 
									   + pHKJobType + ")";

				MySqlCommand cmd = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

				try
				{
					string rmid = cmd.ExecuteScalar().ToString();
					return rmid;
				}
				catch (Exception)
				{
					return null;
				}

			}

			public DataTable getActiveHouseKeepingJobs()
			{
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				string _sqlStr = "call spHK_GetActiveHousekeepingJobs()";

				//MySqlCommand cmd = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

				MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				DataTable dt = new DataTable("PendingHouseKeepingJobs");
				_daSelect.Fill(dt);

				return dt;
			}

			public DataTable getActiveHouseKeepingJobs(MySqlConnection con)
			{
				GlobalVariables.gPersistentConnection = con;
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				string _sqlStr = "call spHK_GetActiveHousekeepingJobs()";

				//MySqlCommand cmd = new MySqlCommand("call spHK_GetActiveHousekeepingJobs()", GlobalVariables.gPersistentConnection);
				MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				DataTable dt = new DataTable("PendingHouseKeepingJobs");
				_daSelect.Fill(dt);

				return dt;

			}

			//>> insert for IVRS
			public void Insert(DataRow row)
			{
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}
				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				//string cmdTextInsert = "insert into Housekeepingjobs(roomid,housekeepingdate,starttime,housekeeperid"
				//    + ",hotelid,housekeepingtypecode,isFinished,floorLevelID)"
				//    + " values ('" + row["RoomID"] + "','" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(row["HouseKeepingDate"].ToString()).Date) + "','" + row["StartTime"] + "','" + row["HouseKeeperId"] + "'," + row["Hotelid"]
				//    + ",'" + row["housekeepingtypecode"] + "'," + row["isFinished"] + ",'" + row["floorLevelID"] + "')";
				string cmdTextInsert = "call spHK_InsertHousekeepingJob('" 
											 + DateTime.Parse(row["HouseKeepingDate"].ToString()).ToString("yyyy-MM-dd") + "','"
											 + row["HouseKeeperId"].ToString() + "','"
											 + row["housekeepingType"].ToString() + "','"
											 + row["roomId"].ToString() + "','"
											 + string.Format("{0:yyyy-MM-dd hh:mm:ss}", row["startTime"]) + "','"
											 + row["endTime"].ToString() + "','"
											 + row["remarks"].ToString() + "','"
											 + row["verifiedBy"].ToString() + "','"
											 + row["timeVerified"].ToString() + "','"
											 + row["hotelId"].ToString() + "','"
											 + row["createdBy"].ToString() + "')";

				MySqlCommand cmdInsert = new MySqlCommand(cmdTextInsert, GlobalVariables.gPersistentConnection);
				cmdInsert.Transaction = trans;


				try
				{

					cmdInsert.ExecuteNonQuery();
					trans.Commit();

				}
				catch (Exception ex)
				{

					trans.Rollback();
					throw ex;
				}

			}

			//>> insert for IVRS
			public void Insert(DataRow row, MySqlConnection con)
			{
				GlobalVariables.gPersistentConnection = con;
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}

				MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

				//string cmdTextInsert = "insert into Housekeepingjobs(roomid,housekeepingdate,starttime,housekeeperid"
				//    + ",hotelid,housekeepingtypecode,isFinished,floorLevelID)"
				//    + " values ('" + row["RoomID"] + "','" + string.Format("{0:yyyy-MM-dd}", DateTime.Parse(row["HouseKeepingDate"].ToString()).Date) + "','" + row["StartTime"] + "','" + row["HouseKeeperId"] + "'," + row["Hotelid"]
				//    + ",'" + row["housekeepingtypecode"] + "'," + row["isFinished"] + ",'" + row["floorLevelID"] + "')";

				string cmdTextInsert = "call spHK_InsertHousekeepingJob('"
											 + DateTime.Now.ToString("yyyy-MM-dd") + "','"
											 + row["HouseKeeperId"].ToString() + "','"
											 + row["housekeepingType"].ToString() + "','"
											 + row["roomId"].ToString() + "','"
											 + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"  //start time
											 + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" // end time
											 + row["remarks"].ToString() + "','"
											 + row["verifiedBy"].ToString() + "','"
											 + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" // time verified
											 + row["hotelId"].ToString() + "','"
											 + row["createdBy"].ToString() + "')";


				MySqlCommand cmdInsert = new MySqlCommand(cmdTextInsert, GlobalVariables.gPersistentConnection);
				cmdInsert.Transaction = trans;


				try
				{

					cmdInsert.ExecuteNonQuery();
					trans.Commit();

				}
				catch (Exception ex)
				{

					trans.Rollback();
					throw ex;
				}

			}

			public void recordEndCleaningProcess(DataRow pDataRow)
			{

				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}


                string _hotelId = pDataRow["HotelId"].ToString();
                string _roomId = pDataRow["RoomId"].ToString();
                string _housekeeperId = pDataRow["HouseKeeperID"].ToString();

                int hkJobNoToUpdate = getHousekeepingJobNoToUpdate(_hotelId, _roomId, _housekeeperId);

                if (hkJobNoToUpdate > 0)
				{
                    //MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
                    string _strUpdate = "call spHK_UpdateHousekeepingJobEndTime('"
                                              + hkJobNoToUpdate + "')";

					MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(_strUpdate, GlobalVariables.gPersistentConnection);
					//cmdUpdateHouseKeepingjobs.Transaction = trans;
					cmdUpdateHouseKeepingjobs.ExecuteNonQuery();
					
					//trans.Commit();
				}

				else
				{
					//trans.Rollback();
					throw new Exception(string.Format("Sorry! There was no indication that housekeeper i d {0} has started cleaning in room {1}", _housekeeperId, _roomId));
				}
			}

            public void recordEndCleanProcess(string pHotelId, string pRoomId, string pHousekeeperId, bool pSetRoomStatusToClean, MySqlConnection con)
			{
				GlobalVariables.gPersistentConnection = con;
				if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
				{
					GlobalVariables.gPersistentConnection.Open();
				}

                //string _hotelId = pDataRow["HotelId"].ToString();
                //string _roomId = pDataRow["RoomId"].ToString();
                //string _housekeeperId = pDataRow["HouseKeeperID"].ToString();

                int hkJobNoToUpdate = getHousekeepingJobNoToUpdate(pHotelId, pRoomId, pHousekeeperId);
				//DataRow rowToUpdate = getDataRowToUpdate(pDataRow);


                if (hkJobNoToUpdate > 0)
				{
                    MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

                    try
                    {
                        string _strUpdate = "call spHK_UpdateHousekeepingJobEndTime('"
                                                  + hkJobNoToUpdate + "')";

                        MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(_strUpdate, GlobalVariables.gPersistentConnection);
                        cmdUpdateHouseKeepingjobs.Transaction = trans;

                        cmdUpdateHouseKeepingjobs.ExecuteNonQuery();

                        //>> update Folio Plus' Room Status
                        if (pSetRoomStatusToClean)
                        {

                            string _strUpdateFolioRoomStatus = "call spUpdateRoomCleaningStatus('CLEAN','" + pRoomId + "')";

                            MySqlCommand cmdUpdateRoom = new MySqlCommand(_strUpdateFolioRoomStatus, GlobalVariables.gPersistentConnection);
                            cmdUpdateRoom.Transaction = trans;
                            cmdUpdateRoom.ExecuteNonQuery();
                        }

                        trans.Commit();

                    }
                    catch
                    {
                        trans.Rollback();
                        throw new Exception(string.Format("Sorry! There was no indication that housekeeper i d {0} has started cleaning in room {1}", pHousekeeperId, pRoomId));
                    }
				}

				else
				{
					//trans.Rollback();
                    throw new Exception(string.Format("Sorry! There was no indication that housekeeper i d {0} has started cleaning in room {1}", pHousekeeperId, pRoomId));
				}

			}

            public  int getHousekeepingJobNoToUpdate(string pHotelId, string pRoomId, string pHousekeeperId)
            {

                int HKjobNo = 0;

                if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
                {
                    GlobalVariables.gPersistentConnection.Open();
                }

                string _sqlStr = "call spHK_GetActiveHousekeepingJobPerRoom(" 
                                       + pHotelId + ",'" 
                                       + pRoomId + "', '" 
                                       + pHousekeeperId + "')";

                MySqlCommand selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                object objScalar = selectCommand.ExecuteScalar();

                if (objScalar != null)
                {
                    HKjobNo = int.Parse(objScalar.ToString());
                }

                return HKjobNo;
                
            }

            //public void recordEndCleanProcess(DataRow pDataRow, MySqlConnection con)
            //{
            //    GlobalVariables.gPersistentConnection = con;
            //    if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
            //    {
            //        GlobalVariables.gPersistentConnection.Open();
            //    }

            //    int hkJobNoToUpdate = getHousekeepingJobNoToUpdate(pDataRow);
            //    //DataRow rowToUpdate = getDataRowToUpdate(pDataRow);

            //    MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();


            //    if (rowToUpdate != null)
            //    {

            //        //TimeSpan Duration = new TimeSpan(Math.Abs(DateTime.Parse(pDataRow["EndTime"].ToString()).Ticks - DateTime.Parse(rowToUpdate["StartTime"].ToString()).Ticks));
            //        //string duratn = string.Format("{0:D2}", Duration.Hours) + ":" + string.Format("{0:D2}", Duration.Minutes) + ":" + string.Format("{0:D2}", Duration.Seconds);

            //        string _hkJobNo = rowToUpdate["housekeepingjobno"].ToString();


            //        //string _strUpdate = "Update hk_housekeepingJobs set EndTime ='" + pDataRow["EndTime"] + "',elapsedtime='" + duratn + "',isFinished=1  where housekeepingjobno=" + rowToUpdate["housekeepingjobno"];
            //        string _strUpdate = "call spHK_UpdateHousekeepingJobEndTime('"
            //                                  + _hkJobNo + "')";

            //        MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(_strUpdate, GlobalVariables.gPersistentConnection);
            //        cmdUpdateHouseKeepingjobs.Transaction = trans;
            //        cmdUpdateHouseKeepingjobs.ExecuteNonQuery();

            //        //>> update Folio Plus' Room Status
            //        //if (isFolioPlusIntegrated)
            //        //{
            //        //    string _roomNo = pDataRow["roomId"].ToString();

            //        //    string _strUpdateFolioRoomStatus = "call spUpdateRoomCleaningStatus('CLEAN','" + _roomNo + "')";

            //        //    MySqlCommand cmdUpdateRoom = new MySqlCommand(_strUpdateFolioRoomStatus, GlobalVariables.gPersistentConnection);
            //        //    cmdUpdateRoom.Transaction = trans;
            //        //    cmdUpdateRoom.ExecuteNonQuery();
            //        //}



            //        trans.Commit();
            //    }

            //    else
            //    {
            //        trans.Rollback();
            //        throw new Exception(string.Format("Sorry! There was no indication that housekeeper i d {0} has started cleaning in room {1}", pDataRow["HouseKeeperId"], pDataRow["RoomID"]));
            //    }


            //    //DataRow rowToUpdate = getRowToUpdate(row);
            //    //MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            //    //string sqlStr = "Update rooms set cleaningstatus='CLEAN' where roomid='" + row["RoomID"] + "'";

            //    //// checks wether module is FOLIO_PLUS integrated
            //    //// jrom, March 1,2008, Bethel Guesthouse
            //    //string folioPlusIntegrated = ConfigurationManager.AppSettings.Get("FOLIO_PLUS_INTEGRATED");
            //    //if (folioPlusIntegrated == "YES")
            //    //{
            //    //    string folioPlusDatabase = ConfigurationManager.AppSettings.Get("FOLIO_PLUS_DATABASE");
            //    //    sqlStr += ";Update ";
            //    //    sqlStr += folioPlusDatabase + ".rooms set cleaningstatus='CLEAN' where roomid='" + row["RoomID"] + "';";
            //    //}

            //    //MySqlCommand cmdUpdateRoom = new MySqlCommand(sqlStr, GlobalVariables.gPersistentConnection);

            //    //cmdUpdateRoom.Transaction = trans;
            //    //if (rowToUpdate != null)
            //    //{

            //    //    TimeSpan Duration = new TimeSpan(Math.Abs(DateTime.Parse(row["EndTime"].ToString()).Ticks - DateTime.Parse(rowToUpdate["StartTime"].ToString()).Ticks));
            //    //    String duratn = string.Format("{0:D2}", Duration.Hours) + ":" + string.Format("{0:D2}", Duration.Minutes) + ":" + string.Format("{0:D2}", Duration.Seconds);

            //    //    string cmdUpdateText = "Update hk_housekeepingJobs set EndTime ='" + row["EndTime"] + "',elapsedtime='" + duratn + "',isFinished=1  where housekeepingjobno=" + rowToUpdate["housekeepingjobno"];
            //    //    MySqlCommand cmdUpdateHouseKeepingjobs = new MySqlCommand(cmdUpdateText, GlobalVariables.gPersistentConnection);
            //    //    cmdUpdateHouseKeepingjobs.ExecuteNonQuery();
            //    //    cmdUpdateRoom.ExecuteNonQuery();
            //    //    trans.Commit();
            //    //}

            //    //else
            //    //{
            //    //    trans.Rollback();
            //    //    throw new Exception(string.Format("Sorry! There was no indication that housekeeper i d {0} has started cleaning in room {1}", row["HouseKeeperId"], row["RoomID"]));
            //    //}
            //}


            //private int getHousekeepingJobNoToUpdate(string pHotelId, string pRoomId, string pHousekeeperId)
            //{

            //    int HKjobNo = 0;

            //    if (GlobalVariables.gPersistentConnection.State == ConnectionState.Closed)
            //    {
            //        GlobalVariables.gPersistentConnection.Open();
            //    }

            //    string _sqlStr = "call spHK_GetActiveHousekeepingJobs()";

            //    MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

            //    DataTable dt = new DataTable("PendingHouseKeepingJobs");
            //    _daSelect.Fill(dt);


            //    //foreach (DataRow _dtRow in dt.Rows)
            //    //{

            //    //    if ( row["HotelID"].ToString() == _dtRow["HotelID"].ToString() && 
            //    //         row["RoomID"].ToString() == _dtRow["RoomID"].ToString() && 
            //    //         row["HouseKeeperID"].ToString() == _dtRow["HouseKeeperID"].ToString() )

            //    //        return _dtRow;
            //    //}

            //    //return null;

            //}

		}
	}

