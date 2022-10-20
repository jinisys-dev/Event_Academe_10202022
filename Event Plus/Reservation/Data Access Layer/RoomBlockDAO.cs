
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class RoomBlockDAO
    {

        private ParameterHelper oParameterHelper;
        public RoomBlockDAO()
        {
            oParameterHelper = new ParameterHelper();
        }
        
		public RoomBlockCollection getRoomBlocks(string pStartDate, string pEndDate)
		{
			RoomBlockCollection roomBlockColl = new RoomBlockCollection();
			//DataReaderToDatasetConverter oDatasetConverter = new DataReaderToDatasetConverter();

			RoomBlock oRoomBlock = new RoomBlock();
			try
			{
				string _sqlStr = "call spSelectBlocks('" + pStartDate 
											    + "','" +  pEndDate + "')";

				MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_daSelect.Fill(oRoomBlock, "RoomBlocks");

				//SelectCommand.CommandType = CommandType.StoredProcedure;
				//MySqlParameter param;
				//param = new MySqlParameter();
				//param.ParameterName = "pNow";
				//param.Direction = ParameterDirection.Input;
				//param.DbType = DbType.Date;
				//param.SourceColumn = "datefrom";
				//param.Value = dateFrom;
				//SelectCommand.Parameters.Add(param);

				//MySqlDataReader dataReader = SelectCommand.ExecuteReader();
				//oDatasetConverter.convertDataReaderToDataSet(dataReader, "RoomBlocks", oRoomBlock);
				DataTable dataTableRoomBlocks = oRoomBlock.Tables["RoomBlocks"];
				DataRow dr;

				foreach (DataRow tempLoopVar_dr in dataTableRoomBlocks.Rows)
				{
					dr = tempLoopVar_dr;
					RoomBlock roomblock = new RoomBlock();
					roomblock.BlockID = int.Parse(dr["blockid"].ToString());
					roomblock.RoomID = dr["roomid"].ToString();
					roomblock.BlockFrom = DateTime.Parse(dr["blockfrom"].ToString());
					roomblock.BlockTo = DateTime.Parse(dr["blockto"].ToString());
					roomblock.Reason = dr["reason"].ToString();
					roomBlockColl.Add(roomblock);
				}
				//dataReader.Close();
				return roomBlockColl;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION: " + ex.Message + "  getRoomBlocks(ByVal dateFrom As String) As RoomBlockCollection");
				return null;
			}
		}

        public DataTable getRoomsBlocked(string dateFrom, string dateTo, bool isDataTableReturned)
        {
            try
            {


                MySqlCommand SelectCommand = new MySqlCommand("call spSelectBlockedRooms('" + dateFrom + "','" + dateTo + "')", GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(SelectCommand);
                DataTable dt = new DataTable("RoomBlocks");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  getRoomBlocks(ByVal dateFrom As String) As RoomBlockCollection");
                return null;
            }
        }

        public DataTable getRoomBlocks(string dateFrom,string dateTo ,bool isDataTableReturned)
        {
          try
            {


				MySqlCommand SelectCommand = new MySqlCommand("call spSelectBlocks('" + dateFrom + "','" + dateTo + "')", GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(SelectCommand);
              DataTable dt = new DataTable("RoomBlocks");
                da.Fill(dt);
                
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  getRoomBlocks(ByVal dateFrom As String) As RoomBlockCollection");
                return null;
            }
        }
        public void DeleteRoomBlock(int BlockID, string RoomID)
        {
            MySqlTransaction RoomBlockTrans;

            RoomBlockTrans = GlobalVariables.gPersistentConnection.BeginTransaction();
            MySqlCommand deleteCommand = new MySqlCommand("spDeleteRoomBlock", GlobalVariables.gPersistentConnection);
            deleteCommand.Transaction = RoomBlockTrans;
            deleteCommand.CommandType = CommandType.StoredProcedure;

            MySqlParameter paramBlockID = new MySqlParameter();
            MySqlParameter paramroomId = new MySqlParameter();
            try
            {
                oParameterHelper.AddParameters(paramBlockID, "pBlockID", ParameterDirection.Input, DbType.Int64, BlockID.ToString(), deleteCommand);
                oParameterHelper.AddParameters(paramroomId, "pRoomID", ParameterDirection.Input, DbType.String, RoomID, deleteCommand);

                deleteCommand.ExecuteNonQuery();
                deleteCommand = new MySqlCommand("spDeleteRoomBlockNoDetail", GlobalVariables.gPersistentConnection);
                deleteCommand.CommandType = CommandType.StoredProcedure;
                deleteCommand.ExecuteNonQuery();
                RoomBlockTrans.Commit();
            }
            catch
            {
                RoomBlockTrans.Rollback();
            }
        }

        public void deleteRoomBlockedByEvent(string roomID, string folioID, ref MySqlTransaction poTrans)
        {
            string sql = "call spDeleteRoomBlockedByEvent('" + roomID + "','" + folioID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = poTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getNextBlockNo()
        {

            int folioNo = 0;
            try
            {
                MySqlCommand getFolioNoCommand = new MySqlCommand("spSelectBlockID", GlobalVariables.gPersistentConnection);
                getFolioNoCommand.CommandType = CommandType.StoredProcedure;

                MySqlDataReader blockNoDataReader = getFolioNoCommand.ExecuteReader();

                while (blockNoDataReader.Read())
                {
                    folioNo = int.Parse(blockNoDataReader.GetValue(0).ToString());
                }
                blockNoDataReader.Close();
                return folioNo + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " getNextBlockNo() As Integer");
                return 0;
            }
        }

        public DataTable GetCurrentBlockRoom()
        {
            try
            {
				DataTable CurrentRoomBlockTable = new DataTable("CurrentBlockRooms");

				string strQuery = "call spCurrentBlockRoom('" + GlobalVariables.gAuditDate + "')";
				MySqlDataAdapter getCurrentBlockCommand = new MySqlDataAdapter(strQuery, GlobalVariables.gPersistentConnection);

				getCurrentBlockCommand.Fill(CurrentRoomBlockTable);
                return CurrentRoomBlockTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " GetCurrentBlockRoom() As DataTable");
                return null;
            }
        }
     
        public DataTable GetRoomAndTypeOccupied(string dateFrom, string dateTo)
        {
            try
            {
                MySqlCommand cmdCountRoomOccu = new MySqlCommand("call spGetRoomAndTypeOccupied(\'" + dateFrom + "\',\'" + dateTo + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                cmdCountRoomOccu.CommandType = CommandType.Text;
                MySqlDataAdapter daRoomBlock = new MySqlDataAdapter(cmdCountRoomOccu);
                DataTable dtRoomTypesOcc = new DataTable("CountRoomOccu");
                daRoomBlock.Fill(dtRoomTypesOcc);

                return dtRoomTypesOcc;
                //					daRoomBlock.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " Function GetRoomAndTypeOccupied() As DataTable");
                return null;
            }
        }
        public DataTable GetRoomTypeDateOccupied(string dateFrom, string dateTo)
        {
            try
            {
                MySqlCommand cmdCountRoomOccu = new MySqlCommand("call spGetRoomTypeDateOccupied(\'" + dateFrom + "\',\'" + dateTo + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                cmdCountRoomOccu.CommandType = CommandType.Text;
                MySqlDataAdapter daRoomBlock = new MySqlDataAdapter(cmdCountRoomOccu);
                DataTable dtRoomTypesOcc = new DataTable("CountRoomOccu");
                daRoomBlock.Fill(dtRoomTypesOcc);

                return dtRoomTypesOcc;
                //					daRoomBlock.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " Function GetRoomAndTypeOccupied() As DataTable");
                return null;
            }
        }
        public DataTable CountRoomTypes()
        {
            try
            {

                MySqlCommand cmdCountRoomTypes = new MySqlCommand("call spCountRoomTypes(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                cmdCountRoomTypes.CommandType = CommandType.Text;
                MySqlDataAdapter daRoomBlock = new MySqlDataAdapter(cmdCountRoomTypes);
                DataTable dtCountRoomTypes = new DataTable("CountRoomTypes");
                daRoomBlock.Fill(dtCountRoomTypes);

                return dtCountRoomTypes;

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  CountRoomTypes() As DataTable ");
                return null;
            }
        }
        private bool isRoomBlockedInDate(string date, ArrayList rooms)
        {
            try
            {
                MySqlCommand getCurrentBlockCommand = new MySqlCommand("call spGetBlockedRoomInDate(\'" + date + "\')", GlobalVariables.gPersistentConnection);
                getCurrentBlockCommand.CommandType = CommandType.Text;
                MySqlDataAdapter daRoomBlock = new MySqlDataAdapter(getCurrentBlockCommand);
                DataTable CurrentRoomBlockTable = new DataTable("CurrentBlockRooms");
                daRoomBlock.Fill(CurrentRoomBlockTable);
                foreach (DataRow dr in CurrentRoomBlockTable.Rows)
                {
                    if (rooms.IndexOf(dr["roomid"].ToString()) != -1)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " isRoomBlockedInDate(string date,ArrayList rooms) at RoomBlockDAO");
                return true;
            }
        }
        public bool isConflict(string dateFrom, string dateTo,ArrayList rooms)
        {
            try
            {
                foreach (string room in rooms)
                {
                    MySqlCommand cmdChkConflict = new MySqlCommand("call spGetRoomBlocksConflict(\'" + dateFrom + "\',\'" + dateTo + "\',\'" + room + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                    cmdChkConflict.CommandType = CommandType.Text;
                    object rm = cmdChkConflict.ExecuteScalar();
                    if (rm != null)
                        return true;
                    long days = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(dateFrom), DateTime.Parse(dateTo));
                    for(long start = 0;start<days;start++)
                    {
                        string dateToCheck =string.Format("{0:yyyy-MM-dd}", DateTime.Parse(dateTo).AddDays(start));
                        if (isRoomBlockedInDate(dateToCheck, rooms))
                        {
                            return true;
                        }
                    }
                   
                }
                return false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + " Function isConflict(string dateFrom, string dateTo,ArrayList rooms) at RoomBlockDAO");
                return true;
            }
        }
        public DataTable GetRoomAndTypeBlocked(string dateFrom, string dateTo)
        {
            try
            {
                MySqlCommand cmdGetRoomTypesBlocked = new MySqlCommand("call spGetRoomAndTypeBlocked(\'" + dateFrom + "\',\'" + dateTo + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                cmdGetRoomTypesBlocked.CommandType = CommandType.Text;
                MySqlDataAdapter daRoomBlock = new MySqlDataAdapter(cmdGetRoomTypesBlocked);
                DataTable dtRoomTypesBlocked = new DataTable("RoomTypesBlock");
                daRoomBlock.Fill(dtRoomTypesBlocked);

                return dtRoomTypesBlocked;
                //					daRoomBlock.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message + "  GetRoomAndTypeBlocked(ByVal dateFrom As String, ByVal dateTo As String) As DataTable ");
                return null;
            }
        }

        public void SaveRoomBlocks(RoomBlockCollection RoomBlockColl)
        {
            //Jinisys.Hotel.BusinessSharedClasses.ParameterHelper oParameterhelper = new Jinisys.Hotel.BusinessSharedClasses.ParameterHelper();
			MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

			string queryRoomBlock = "call spInsertRoomBlock('"
										  + RoomBlockColl.Item(0).BlockID + "','"
										  + RoomBlockColl.Item(0).Reason + "','"
										  + RoomBlockColl.Item(0).FolioID + "','" 
										  + GlobalVariables.gHotelId  + "')";


			
            MySqlCommand saveRoomBlockCommand = new MySqlCommand(queryRoomBlock, GlobalVariables.gPersistentConnection);
			saveRoomBlockCommand.Transaction = trans;

			saveRoomBlockCommand.ExecuteNonQuery();

            //saveRoomBlockCommand.CommandType = CommandType.StoredProcedure;
            //saveRoomBlockDetail.CommandType = CommandType.StoredProcedure;

            
            //saveRoomBlockCommand.Transaction = trans;
            //saveRoomBlockDetail.Transaction = trans;
            try
            {
                RoomBlock roomBlock;
                
                foreach (RoomBlock tempLoopVar_roomBlock in RoomBlockColl)
                {
					roomBlock = tempLoopVar_roomBlock;

					string queryRoomBlockDetails = "call spInsertBlockDetails('" 
														 + roomBlock.BlockID + "','" 
														 + roomBlock.RoomID + "','" 
														 + roomBlock.BlockFrom.ToString("yyyy-MM-dd") + "','"
														 + roomBlock.BlockTo.ToString("yyyy-MM-dd") + "')";

					MySqlCommand saveRoomBlockDetail = new MySqlCommand(queryRoomBlockDetails, GlobalVariables.gPersistentConnection);


                   
					//MySqlParameter paramBlockID = new MySqlParameter();
					//MySqlParameter paramRoomId = new MySqlParameter();
					//MySqlParameter paramBlockFrom = new MySqlParameter();
					//MySqlParameter paramBlockTo = new MySqlParameter();
					//MySqlParameter paramReason = new MySqlParameter();
					//MySqlParameter paramHotelID = new MySqlParameter();

					//if (i == 0)
					//{
					//    oParameterhelper.AddParameters(paramRoomId, "pBlockID", ParameterDirection.Input, DbType.String, roomBlock.BlockID.ToString(), saveRoomBlockCommand);
					//    oParameterhelper.AddParameters(paramReason, "pReason", ParameterDirection.Input, DbType.String, roomBlock.Reason, saveRoomBlockCommand);
					//    oParameterhelper.AddParameters(paramHotelID, "pHotelID", ParameterDirection.Input, DbType.Int64, GlobalVariables.gHotelId.ToString(), saveRoomBlockCommand);
					//    saveRoomBlockCommand.ExecuteNonQuery();
					//}

					//oParameterhelper.AddParameters(paramBlockID, "pBlockID", ParameterDirection.Input, DbType.Int64, roomBlock.BlockID.ToString(), saveRoomBlockDetail);
					//oParameterhelper.AddParameters(paramRoomId, "pRoomID", ParameterDirection.Input, DbType.String, roomBlock.RoomID, saveRoomBlockDetail);
					//oParameterhelper.AddParameters(paramBlockFrom, "pBlockFrom", ParameterDirection.Input, DbType.Date, roomBlock.BlockFrom.ToString(), saveRoomBlockDetail);
					//oParameterhelper.AddParameters(paramBlockTo, "pBlockTo", ParameterDirection.Input, DbType.Date, roomBlock.BlockTo.ToString(), saveRoomBlockDetail);
					saveRoomBlockDetail.Transaction = trans;

                    saveRoomBlockDetail.ExecuteNonQuery();

                }

                trans.Commit();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message :" + ex.Message + " @SaveRoomBlocks(ByVal RoomBlockColl As Jinisys.Hotel.Reservation.BusinessLayer.RoomBlockCollection)");
                trans.Rollback();
            }
        }

        public bool CheckIfRoomIsBlock(string roomid, string date, string folioid)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("call spCheckIfRoomIsBlock('" + roomid + "','" + date + "','" + folioid + "')", GlobalVariables.gPersistentConnection);
                object obj = command.ExecuteScalar();
                if (obj != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ CheckIfRoomIsBlock() " + ex.Message);
                return false;
            }
        }

        //>>by Genny: May 2, 2008
        //for getting the _rooms which are blocked for an event
        public DataTable getBlockedRoomsForEvents(string eventName)
        {
            string sql = "Call spGetRoomsBlocked('" + eventName + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("RoomBlock");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		//get by folio id
		public DataTable getBlockedRoomsForEventsByFolioID(string pFolioID)
		{
			string sql = "call spGetRoomsBlockedByFolioID('" + pFolioID + "')";
			try
			{
				MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				DataTable dt = new DataTable("RoomBlock");
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        //<<


        //>>for updating the room's schedule that has been blocked by an event
        public void updateBlockedRoomsForEvents(RoomBlock poRoomBlock)
        {
            string blockid = poRoomBlock.GetType().GetProperty("BlockID").GetValue(poRoomBlock, null).ToString();
            string roomID = poRoomBlock.GetType().GetProperty("RoomID").GetValue(poRoomBlock, null).ToString();
            DateTime blockTo = DateTime.Parse(poRoomBlock.GetType().GetProperty("BlockTo").GetValue(poRoomBlock, null).ToString());
            DateTime blockFrom = DateTime.Parse(poRoomBlock.GetType().GetProperty("BlockFrom").GetValue(poRoomBlock, null).ToString());
            string sql = "call spUpdateRoomBlocked('" + blockid + "','" + roomID + "','" + string.Format("{0:yyyy-MM-dd}", blockFrom) + "','" + string.Format("{0:yyyy-MM-dd}", blockTo) + "')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public DataTable getRoomBlockInfoById(string pBlockId)
		{
			DataTable _tempData = new DataTable();
			string _sqlStr = "call spGetRoomBlockInfoById('" + 
							   pBlockId + "')";

			try
			{
				MySqlDataAdapter _dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
				_dtAdapter.Fill(_tempData);


				return _tempData;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}


    }
}