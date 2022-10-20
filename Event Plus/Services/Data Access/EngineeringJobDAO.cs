
using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Services.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.Services.DataAccessLayer
{
		public class EngineeringJobDAO
		{
            private DataReaderToDatasetConverter oDataConverter ;
            private EngineeringJob oEngineeringJob ;

		    public EngineeringJobDAO()
			{
                oDataConverter = new DataReaderToDatasetConverter();
                oEngineeringJob = new EngineeringJob();
			}

            public EngineeringJob getEngineeringJobs()
			{
				try
				{
					oEngineeringJob = new EngineeringJob();
					
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectEngineeringJobs(\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oEngineeringJob, "EngineeringJobs");
					dataAdapter.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oEngineeringJob.Tables["EngineeringJobs"].Columns["EnggJobNo"];
					oEngineeringJob.Tables["EngineeringJobs"].PrimaryKey = primaryKey;
					
					return oEngineeringJob;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return null;
				}
			}
			
			public int insertEngineeringJob(EngineeringJob oEngineeringJob)
			{
				try
				{
                    int rowsAffected = 0;
					
					MySqlCommand insertCommand = new MySqlCommand("Call spInsertEngineeringJob(\'" + oEngineeringJob.EnggJobNo + "\',\'" + oEngineeringJob.EnggServiceId + "\',\'" + oEngineeringJob.AssignedPerson + "\',\'" + oEngineeringJob.RoomId + "\',\'" + oEngineeringJob.StartDate + "\',\'" + oEngineeringJob.EndDate + "\',\'" + oEngineeringJob.StartTime + "\',\'" + oEngineeringJob.EndTime + "\',\'" + oEngineeringJob.gHotelId + "\',\'" + oEngineeringJob.CreatedBy + "\')", GlobalVariables.gPersistentConnection);
					rowsAffected=insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(oEngineeringJob);
                    }

                    return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
                    return 0;
				}
			}
			
			public int updateEngineeringJob(EngineeringJob oEngineeringJob)
			{
				try
				{
                    int rowsAffected = 0;
                    MySqlCommand updateCommand = new MySqlCommand("Call spUpdateEngineeringJob(\'" + oEngineeringJob.EnggJobNo + "\',\'" + oEngineeringJob.EnggServiceId + "\',\'" + oEngineeringJob.AssignedPerson + "\',\'" + oEngineeringJob.RoomId + "\',\'" + oEngineeringJob.StartDate + "\',\'" + oEngineeringJob.EndDate + "\',\'" + oEngineeringJob.StartTime + "\',\'" + oEngineeringJob.EndTime + "\',\'" + oEngineeringJob.gHotelId + "\',\'" + oEngineeringJob.UpdatedBy + "\')", GlobalVariables.gPersistentConnection);
					rowsAffected=updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        updateDataRow(oEngineeringJob);
                    }
					
					return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return 0;
				}
			}
			
			public int deleteEngineeringJobRoomEvent(string a_EnggJobNo)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand deleteCommand = new MySqlCommand("call spDeleteEnggJobRoomEvent(\'" + a_EnggJobNo + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
					rowsAffected=deleteCommand.ExecuteNonQuery();

                    return rowsAffected;
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
                    return 0;
				}
			}
			
			public int deleteEngineeringJob(EngineeringJob oEngineeringJob)
			{
				try
				{
                    int rowsAffected = 0;
                    DateTime endDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    string query = "";
                    if (DateTime.Parse(GlobalVariables.gAuditDate) != DateTime.Parse(oEngineeringJob.StartDate))
                    {
                        query = "delete from engineeringjobs where enggjobno='" + oEngineeringJob.EnggJobNo + "'";
                    }
                    else
                    {
                        query = "call spDeleteEngineeringJob(\'" + oEngineeringJob.EnggJobNo + "\',\'" + oEngineeringJob.gHotelId + "\',\'" + oEngineeringJob.UpdatedBy + "\','" + endDate.ToString("dd-MMM-yyyy") + "','" + DateTime.Now.ToString("hh:mm:ss tt") + "')";
                    }

                    MySqlCommand deleteCommand = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                    MySqlTransaction _oDBTrans = deleteCommand.Transaction;
					rowsAffected=deleteCommand.ExecuteNonQuery();
					
					//>> DELETES ROOM EVENTS
                    if (rowsAffected > 0)
                    {
                        deleteEngineeringJobRoomEvent(oEngineeringJob.EnggJobNo);

                        //>>update room status to Vacant Dirty
                        RoomFacade _oRoomFacade = new RoomFacade();
                        _oRoomFacade.setRoomStatus(oEngineeringJob.RoomId, "VACANT", ref _oDBTrans);
                        _oRoomFacade.setRoomCleaningStatus(oEngineeringJob.RoomId, "DIRTY", ref _oDBTrans);

                    }

                    //_oDBTrans.Commit();
		            return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return 0;
				}
			}

            private void insertDataRow(EngineeringJob oEngineeringJob)
            {
                DataRow oDrow = oEngineeringJob.Tables["EngineeringJobs"].NewRow();
                oDrow["EnggJobNo"] = oEngineeringJob.EnggJobNo;
                oDrow["EnggServiceId"] = oEngineeringJob.EnggServiceId;
                oDrow["AssignedPerson"] = oEngineeringJob.AssignedPerson;
                oDrow["Roomid"] = oEngineeringJob.RoomId;
                oDrow["StartDate"] = oEngineeringJob.StartDate;
                oDrow["EndDate"] = oEngineeringJob.EndDate;
                oDrow["StartTime"] = oEngineeringJob.StartTime;
                oDrow["EndTime"] = oEngineeringJob.EndTime;
                oDrow["ServiceName"] = oEngineeringJob.ServiceName;

                oEngineeringJob.Tables["EngineeringJobs"].Rows.Add(oDrow);
                oEngineeringJob.Tables["EngineeringJobs"].AcceptChanges();
            }

            private void updateDataRow(EngineeringJob oEngineeringJob)
            {
                DataRow dtrow = oEngineeringJob.Tables["EngineeringJobs"].Rows.Find(oEngineeringJob.EnggJobNo);
                dtrow.BeginEdit();
                dtrow["EnggServiceId"] = oEngineeringJob.EnggServiceId;
                dtrow["ServiceName"] = oEngineeringJob.ServiceName;
                dtrow["AssignedPerson"] = oEngineeringJob.AssignedPerson;
                dtrow["RoomId"] = oEngineeringJob.RoomId;
                dtrow["StartDate"] = oEngineeringJob.StartDate;
                dtrow["EndDate"] = oEngineeringJob.EndDate;
                dtrow.EndEdit();
                dtrow.AcceptChanges();
                oEngineeringJob.Tables["EngineeringJobs"].AcceptChanges();
            }

            private void deleteDataRow(EngineeringJob oEngineeringJob)
            {
                DataRow row = oEngineeringJob.Tables["EngineeringJobs"].Rows.Find(oEngineeringJob.EnggJobNo);
                oEngineeringJob.Tables["EngineeringJobs"].Rows.Remove(row);
                oEngineeringJob.AcceptChanges();
            }

            public DataTable getEngineeringJob(string Id)
            {
                try
                {
                    string query = "select *, roomtypecode, servicename, description from engineeringjobs, rooms, engineeringservices" +
                        " where enggjobno='" + Id + "' and engineeringjobs.roomid=rooms.roomid and engineeringjobs.enggserviceid=engineeringservices.enggserviceid";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                    DataTable dTable = new DataTable();
                    da.Fill(dTable);

                    return dTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
	}
	
}
