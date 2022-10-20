using System;
using MySql.Data;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;

//new - added Apr. 25, 2008
namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class EventRoomRequirementsDAO
    {
        #region "Event Room Requirements"

        public void saveRoomRequirements(EventRoomRequirements oEvent, ref MySqlTransaction pTrans)
        {
            string folioID = oEvent.GetType().GetProperty("FolioID").GetValue(oEvent, null).ToString();
            string roomType = oEvent.GetType().GetProperty("RoomType").GetValue(oEvent, null).ToString();
            int noOfPax = int.Parse(oEvent.GetType().GetProperty("NumberOfPax").GetValue(oEvent, null).ToString());
            int guaranteedPax = int.Parse(oEvent.GetType().GetProperty("GuaranteedPax").GetValue(oEvent, null).ToString());
            int noOfRooms = int.Parse(oEvent.GetType().GetProperty("NumberOfRooms").GetValue(oEvent, null).ToString());
            int guaranteedRooms = int.Parse(oEvent.GetType().GetProperty("GuaranteedRooms").GetValue(oEvent, null).ToString());
            int blockedRooms = int.Parse(oEvent.GetType().GetProperty("BlockedRooms").GetValue(oEvent, null).ToString());
            string remarks = oEvent.GetType().GetProperty("Remarks").GetValue(oEvent, null).ToString();

            string sql = "call spInsertRoomRequirements('" + folioID + "','" + roomType + "'," + noOfPax + "," + guaranteedPax +
                "," + noOfRooms + "," + guaranteedRooms + "," + blockedRooms + ",'" + remarks + "','" + GlobalVariables.gLoggedOnUser + "')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                throw new Exception("ERROR: " + ex.Message + " = @ saveRoomRequirements() ");
            }
        }

        public void deleteRoomRequirements(string folioID, ref MySqlTransaction pTrans)
        {
            string sql = "call spDeleteRoomRequirements('" + folioID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                throw new Exception("ERROR: " + ex.Message + " = @ deleteRoomRequirements() ");
            }
        }

        public DataTable getRoomRequirements(string folioID)
        {
            string sql = "call spDisplayAllRoomRequirements('" + folioID + "')";
            try
            {
                MySqlCommand cmdDisplay = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter daDisplay = new MySqlDataAdapter(cmdDisplay);
                DataTable dt = new DataTable("RoomRequirements");
                daDisplay.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateNumberOfBlockedRooms(string pFolioID, string pRoomType, int pNoOfRooms)
        {
            string _sqlQuery = "call spUpdateNumberOfBlockedRooms('" + pFolioID + "','" + pRoomType + "'," + pNoOfRooms + ")";
            try
            {
                MySqlCommand _mySqlCommand = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		//added to Update Blocked Rooms
		public void updateTotalBlockedRooms(string pFolioID, string pRoomType, int pTotalBlockedRooms)
		{
			string _sqlQuery = "call spUpdateTotalBlockedRooms('" 
									  + pFolioID + "','" 
									  + pRoomType + "'," 
									  + pTotalBlockedRooms + ")";

			try
			{
				MySqlCommand _mySqlCommand = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
				_mySqlCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


        #endregion
    }
}
