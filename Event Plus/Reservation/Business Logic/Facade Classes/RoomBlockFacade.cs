
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using MySql.Data.MySqlClient;

using System.Collections.Generic;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class RoomBlockFacade
    {

        public RoomBlockFacade()
        {
        }

		RoomBlockDAO loRoomDAO;

		public RoomBlockCollection getRoomBlocks(string fromDate, string endDate)
		{
			RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
			return roomBlockDAO.getRoomBlocks(fromDate, endDate);
		}
        public DataTable getRoomBlocks(string dateFrom,string dateTo, bool isDataTableReturned)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.getRoomBlocks(dateFrom, dateTo, true);
        }

        public DataTable getBlockedRooms(string dateFrom, string dateTo, bool isDataTableReturned)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.getRoomsBlocked(dateFrom, dateTo, true);
        }

        public int getNextBlockNo()
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.getNextBlockNo();
        }

        public void SaveRoomBlock(Jinisys.Hotel.Reservation.BusinessLayer.RoomBlockCollection RoomBlockColl)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            roomBlockDAO.SaveRoomBlocks(RoomBlockColl);
        }
        public void DeleteRoomBlock(int BlockID, string RoomID)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            roomBlockDAO.DeleteRoomBlock(BlockID, RoomID.ToString());
        }

        public void deleteRoomBlockedByEvent(string roomID, string folioID, ref MySqlTransaction poTrans)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            roomBlockDAO.deleteRoomBlockedByEvent(roomID, folioID, ref poTrans);
        }

        public DataTable GetCurrentBlockRoom()
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.GetCurrentBlockRoom();
        }
        public DataTable CountRoomTypes()
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.CountRoomTypes();
        }
        public DataTable GetRoomAndTypeOccupied(string dateFrom, string dateTo)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.GetRoomAndTypeOccupied(dateFrom, dateTo);
        }
        public DataTable GetRoomTypeDateOccupied(string dateFrom, string dateTo)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.GetRoomTypeDateOccupied(dateFrom, dateTo);
        }
        public DataTable GetRoomAndTypeBlocked(string dateFrom, string dateTo)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.GetRoomAndTypeBlocked(dateFrom, dateTo);
        }
        public void SaveGroupBlocks(DataTable dt, ArrayList Ar)
        {

        }
        public bool isConflictWithRoomEvents(string dateFrom, string dateTo, ArrayList rooms)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.isConflict( dateFrom, dateTo,  rooms);
        }
        public bool CheckIfRoomIsBlock(string roomid, string date, string folioid)
        {
            RoomBlockDAO roomBlockDAO = new RoomBlockDAO();
            return roomBlockDAO.CheckIfRoomIsBlock(roomid, date, folioid);
        }

        //>>by Genny: May 2, 2008
        public GenericList<RoomBlock> getBlockedRoomsForEvent(string eventName)
        {
            RoomBlockDAO roomDAO = new RoomBlockDAO();
            DataTable dt = roomDAO.getBlockedRoomsForEvents(eventName);
            GenericList<RoomBlock> roomBlock = new GenericList<RoomBlock>();
            foreach (DataRow dr in dt.Rows)
            {
                RoomBlock rBlock = new RoomBlock();
                rBlock.RoomID = dr["roomid"].ToString();
                rBlock.BlockFrom = DateTime.Parse(dr["blockfrom"].ToString());
                rBlock.BlockTo = DateTime.Parse(dr["blockto"].ToString());
                rBlock.BlockID = int.Parse(dr["blockid"].ToString());
                roomBlock.Add(rBlock);
            }
            return roomBlock;
        }
		//get BlockedRoomsForEvent by Folio Id
		public GenericList<RoomBlock> getBlockedRoomsForEventByFolioId(string pFolioID)
		{
			RoomBlockDAO roomDAO = new RoomBlockDAO();
			DataTable dt = roomDAO.getBlockedRoomsForEventsByFolioID(pFolioID);
			GenericList<RoomBlock> roomBlock = new GenericList<RoomBlock>();
			foreach (DataRow dr in dt.Rows)
			{
				RoomBlock rBlock = new RoomBlock();
				rBlock.RoomID = dr["roomid"].ToString();
				rBlock.BlockFrom = DateTime.Parse(dr["blockfrom"].ToString());
				rBlock.BlockTo = DateTime.Parse(dr["blockto"].ToString());
				rBlock.BlockID = int.Parse(dr["blockid"].ToString());
				roomBlock.Add(rBlock);
			}
			return roomBlock;
		}


        public void updateBlockedRoomsForEvents(RoomBlock poRoomBlock)
        {
            RoomBlockDAO roomDAO = new RoomBlockDAO();
            roomDAO.updateBlockedRoomsForEvents(poRoomBlock);
        }

		public IList<RoomBlock> getRoomBlockInfoById(string pBlockId)
		{
			
			loRoomDAO = new RoomBlockDAO();
			DataTable _tempData = loRoomDAO.getRoomBlockInfoById(pBlockId);

			if (_tempData.Rows.Count <= 0)
			{
				throw new Exception("Room Block info not found.");
			}

			IList<RoomBlock> _oRoomBlockList = new List<RoomBlock>();
			foreach (DataRow _dRow in _tempData.Rows)
			{
				RoomBlock _oRoomBlock = new RoomBlock();
				_oRoomBlock.BlockID = int.Parse(pBlockId);
				_oRoomBlock.RoomID = _dRow["roomid"].ToString();
				_oRoomBlock.BlockFrom = DateTime.Parse(_dRow["blockfrom"].ToString());
				_oRoomBlock.BlockTo = DateTime.Parse(_dRow["blockto"].ToString());
				_oRoomBlock.Reason = _dRow["reason"].ToString();
				_oRoomBlock.FolioID = _dRow["folioID"].ToString();

				_oRoomBlockList.Add(_oRoomBlock);
			}

			return _oRoomBlockList;

		}

    }
}