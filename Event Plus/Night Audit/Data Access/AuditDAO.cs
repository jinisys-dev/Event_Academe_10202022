using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.NightAudit.BusinessLayer;

namespace Jinisys.Hotel.NightAudit.DataAccessLayer
{
    class AuditDAO
    {
        private MySqlConnection localConnection;
        public AuditDAO(MySqlConnection con)
        {
            localConnection = con;
        }
        public bool InsertAudit(Audit audit)
        {
         		MySqlTransaction trans = localConnection.BeginTransaction();
				try
				{
										
					MySqlCommand insertCommand = new MySqlCommand("call spInsertAudit(\'" + audit.gAuditDate + "\'," + audit.ShiftCode + ",\'" + audit.Meridian + "\','" + audit.TriggeredBy + "\')", localConnection);
					
					insertCommand.Transaction = trans;
					insertCommand.ExecuteNonQuery();
					
					
					trans.Commit();
					return true;
				}
				catch (Exception exception)
				{
					trans.Rollback();
                    MessageBox.Show("EXCEPTION :  @ InsertAudit() " + exception.Message);
					return false;
				}
				
			}
        public string getServerTime()
        {
            try
            {
                MySqlCommand getTimeCommand = new MySqlCommand("Select curtime()", localConnection);

                return getTimeCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION : @ getTimeCommand " + ex.Message);
                return null;
            }
        }
        public string getServerDateAndTime()
        {
            try
            {
                MySqlCommand getTimeCommand = new MySqlCommand("Select now()", localConnection);

                return getTimeCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION : @ getTimeCommand " + ex.Message);
                return null;
            }
        }

        public bool SetToProcessed(Audit audit)
        {
            MySqlTransaction trans = localConnection.BeginTransaction();
            try
            {
                MySqlCommand updateCommand = new MySqlCommand("call spSetAuditToProcessed('" + GlobalVariables.gAuditDate + "')", localConnection);
                updateCommand.Transaction = trans;
                updateCommand.ExecuteNonQuery();
                MySqlCommand insertCommand = new MySqlCommand("call spInsertAudit('" + audit.gAuditDate + "'," + audit.ShiftCode + ",'" + audit.Meridian + "','" + audit.TriggeredBy + "')", localConnection);
                insertCommand.Transaction = trans;
                insertCommand.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception exception)
            {
                trans.Rollback();
                MessageBox.Show("EXCEPTION :  @ InsertAudit() " + exception.Message);
                return false;
            }

        }
        public string getCurrentAuditDate()
        {
            try
            {
                MySqlCommand getPasswordCommand = new MySqlCommand("call spGetAuditDate()", GlobalVariables.gPersistentConnection);

                return getPasswordCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
//                MessageBox.Show("EXCEPTION : @ GetAuditDate " + ex.Message);
                throw new Exception("EXCEPTION : @ GetAuditDate " + ex.Message);
                //return null;
            }
        }
         public string getLastProcessedAuditDate()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("call spGetLastPocessedAuditDate()", localConnection);

                return cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION : @ spGetLastPocessedAuditDate " + ex.Message);
                return null;
            }
        }
        
        public Audit getCurrentAudit(string date)
        {
            try
            {
                MySqlCommand getAuditCommand = new MySqlCommand("call spGetCurrentAuditDate('" + date + "')", localConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(getAuditCommand);
                Audit audit = new Audit();
                da.Fill(audit, "Audit");

                if (audit.Tables[0].Rows.Count > 0)
                {
                    audit.gAuditDate = audit.Tables[0].Rows[0]["AuditDate"].ToString();
                    audit.ShiftCode = int.Parse(audit.Tables[0].Rows[0]["ShiftCode"].ToString());
                    audit.Meridian = audit.Tables[0].Rows[0]["Meridian"].ToString();
                    audit.SystemDate = DateTime.Parse(audit.Tables[0].Rows[0]["SystemDate"].ToString());
                    audit.TriggeredBy = audit.Tables[0].Rows[0]["TriggeredBy"].ToString();
                }

                return audit;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION : @ getCurrentAudit " + ex.Message);
                return null;
            }
        }

        public int countTodaysExpectedCheckOut()
        {
            try
            {
                int count = 0;
                
                DataTable dtCheckOut = new DataTable();
                
                string pStartDate = GlobalVariables.gAuditDate;
                int pgHotelId = GlobalVariables.gHotelId;

                string strQuery = "call spGetExpectedCheckOuts('" + pStartDate + "'," + pgHotelId + ")";
                
                MySqlDataAdapter dtaExpectedCheckOut = new MySqlDataAdapter(strQuery, GlobalVariables.gPersistentConnection);
                dtaExpectedCheckOut.Fill(dtCheckOut);

                for (int i = 0 ; i < dtCheckOut.Rows.Count ; i++)
                {
                    if (dtCheckOut.Rows[i]["status"].ToString() == "ONGOING")
                    {
                        count++;
                    }
                }
                //count =  dtCheckOut.Rows.Count;

                return count;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int countTodaysExpectedCheckIn()
        {
            try
            {
                int count = 0;

                DataTable dtCheckIn = new DataTable();

                string pStartDate = GlobalVariables.gAuditDate;
                int pgHotelId = GlobalVariables.gHotelId;

                string strQuery = "call spGetExpectedCheckIn('" + pStartDate + "'," + pgHotelId + ")";

                MySqlDataAdapter dtaExpectedCheckIn = new MySqlDataAdapter(strQuery, GlobalVariables.gPersistentConnection);
                dtaExpectedCheckIn.Fill(dtCheckIn);

                for (int i = 0; i < dtCheckIn.Rows.Count; i++)
                {
                    if (dtCheckIn.Rows[i]["status"].ToString() == "CONFIRMED" || dtCheckIn.Rows[i]["status"].ToString() == "WAIT LIST" || dtCheckIn.Rows[i]["status"].ToString() == "TENTATIVE")
                    {
                        count++;
                    }
                }
                //count =  dtCheckOut.Rows.Count;

                return count;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int countTodaysGroupRoomBlocks()
        {
            int count = 0;
            DataTable dtable = new DataTable();
            string date = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(GlobalVariables.gAuditDate));
            string query = "call spGetGroupRoomBlocks('" + date + "')";
            MySqlDataAdapter dAdapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
            dAdapter.Fill(dtable);

            count = dtable.Rows.Count;
            return count;
        }

		public DataTable getDayEndProcessConfig()
		{
			DataTable _DayEndConfig = new DataTable();

			try
			{
				string _strQuery = "call spSelectDayEndProcessConfig(" + GlobalVariables.gHotelId + ")";

				MySqlDataAdapter dtConfig = new MySqlDataAdapter(_strQuery, GlobalVariables.gPersistentConnection);
				dtConfig.Fill(_DayEndConfig);

				
				return _DayEndConfig;
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public bool saveDayEndProcessConfig(object poDayEndProcessConfig)
		{
			
			try
			{
				string _hotelId = GlobalVariables.gHotelId.ToString();
				string _processType = poDayEndProcessConfig.GetType().GetProperty("ProcessType").GetValue(poDayEndProcessConfig, null).ToString();
				string _scheduleTime = poDayEndProcessConfig.GetType().GetProperty("ScheduleTime").GetValue(poDayEndProcessConfig, null).ToString();
				string _terminalNo = poDayEndProcessConfig.GetType().GetProperty("TerminalNo").GetValue(poDayEndProcessConfig, null).ToString();
				string _notifySchedule = poDayEndProcessConfig.GetType().GetProperty("NotifySchedule").GetValue(poDayEndProcessConfig, null).ToString();
				string _reportsToGenerate = poDayEndProcessConfig.GetType().GetProperty("ReportsToGenerate").GetValue(poDayEndProcessConfig, null).ToString();
				string _backupDatabase = poDayEndProcessConfig.GetType().GetProperty("BackupDatabase").GetValue(poDayEndProcessConfig, null).ToString();

				string _strQuery = "call spUpdateDayEndProcessConfig(" + 
										 GlobalVariables.gHotelId + ",'" +
										 _processType + "','" +
										 _scheduleTime + "','" +
										 _terminalNo + "','" +
										 _notifySchedule + "','" +
										 _reportsToGenerate + "','" +
										_backupDatabase + "','" +
										 GlobalVariables.gLoggedOnUser + "')";

				MySqlCommand dtConfig = new MySqlCommand(_strQuery, GlobalVariables.gPersistentConnection);
				dtConfig.ExecuteNonQuery();

				return true;
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
    }
}
