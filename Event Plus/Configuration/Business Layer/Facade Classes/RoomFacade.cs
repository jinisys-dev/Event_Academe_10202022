using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using System.Collections.Generic;

using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class RoomFacade
	{

		private RoomDAO oRoomDAO;

		public RoomFacade()
		{
		}

		public ArrayList getRoomIDs()
		{
			try
			{
				ArrayList roomIDs = new ArrayList();
				Room oRoom = new Room();
				oRoom = (Room)this.loadObject();

				DataView dtV = oRoom.Tables[0].DefaultView;
				dtV.RowStateFilter = DataViewRowState.OriginalRows;
				dtV.Sort = "roomtypecode";

				foreach (DataRowView dataRow in dtV)
				{
					roomIDs.Add(dataRow["RoomId"]);
				}


				return roomIDs;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Load ArrayList Exception");
				return null;
			}
		}

		public ArrayList getRoomsByRoomType(string a_RoomTypeCode)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.getRoomsByRoomType(a_RoomTypeCode);
		}

        /* FP-SCR-00139 #2
         * get rooms under a super type */
        public ArrayList getRoomsByRoomSuperType(string pRoomSuperType)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.getRoomsByRoomSuperType(pRoomSuperType);
        }

		public int updateRoomCoordinates(string a_RoomId, int a_XCoordinate, int a_YCoordinate)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.updateRoomCoordinates(a_RoomId, a_XCoordinate, a_YCoordinate);
		}

		public int deleteRoomAmenity(string a_RoomId, string a_Amenityid)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.deleteRoomAmenity(a_RoomId, a_Amenityid);
		}

		public int addRoomAmenity(string a_RoomId, string a_Amenityid)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.addRoomAmenity(a_RoomId, a_Amenityid);
		}

		public int setRoomStatus(string a_RoomId, string a_StateFlag, ref MySqlTransaction _oDBTrans)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.setRoomStatus(a_RoomId, a_StateFlag, ref _oDBTrans);
		}

		public Room getRoom(string a_Roomid)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.getRoom(a_Roomid);
		}

		public int setRoomCleaningStatus(string a_RoomId, string a_CleaningStatus, ref MySqlTransaction _oDBTrans)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.setRoomCleaningStatus(a_RoomId, a_CleaningStatus, ref _oDBTrans);
		}

		public object loadObject()
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.loadObject();
		}

		public int insertObject(ref Room a_Room)
		{
			int rowsAffected = 0;

			oRoomDAO = new RoomDAO();
			rowsAffected = oRoomDAO.insertObject(ref a_Room);

			return rowsAffected;
		}

		public int updateObject(ref Room a_Room)
		{
			int rowsAffected = 0;
			oRoomDAO = new RoomDAO();
			rowsAffected = oRoomDAO.updateObject(ref a_Room);
			return rowsAffected;
		}

		public int deleteObject(ref Room a_Room)
		{
			oRoomDAO = new RoomDAO();
			return oRoomDAO.deleteObject(ref a_Room);
		}

		public IList<Room> getRoomList(string aWhereCondition)
		{
			IList<Room> _oRoomList = new List<Room>();
			Room _oRoom = (Room)this.loadObject();
			DataTable _dtRoom = _oRoom.Tables[0];

			DataView _dtViewRooms = _dtRoom.DefaultView;
			_dtViewRooms.RowStateFilter = DataViewRowState.OriginalRows;

			_dtViewRooms.RowFilter = aWhereCondition;

			foreach (DataRowView _dRow in _dtViewRooms)
			{
				Room _newRoom = new Room();

				_newRoom.RoomId = _dRow["RoomId"].ToString();
				_newRoom.RoomTypecode = _dRow["RoomTypecode"].ToString();
				//_newRoom.MaxOccupants = int.Parse( _dRow["MaxOccupants"].ToString() );
				//_newRoom.NoOfBeds = int.Parse( _dRow["NoOfBeds"].ToString() );
				//_newRoom.NoOfAdult = int.Parse( _dRow["NoOfAdult"].ToString() );
				//_newRoom.NoOfChild = _dRow["NoOfChild"].ToString();
				//_newRoom.ShareType = _dRow["ShareType"].ToString();
				_newRoom.Floor = _dRow["Floor"].ToString();
				_newRoom.DirFacing = _dRow["DirFacing"].ToString();
				_newRoom.Windows = _dRow["Windows"].ToString();
				_newRoom.AdjLeft = _dRow["AdjLeft"].ToString();
				_newRoom.AdjRight = _dRow["AdjRight"].ToString();
				_newRoom.RoomImage = _dRow["RoomImage"].ToString();
				_newRoom.SmokingType = _dRow["SmokingType"].ToString();
				_newRoom.BedSplittable = _dRow["BedSplittable"].ToString();
				_newRoom.TelephoneNo = _dRow["TelephoneNo"].ToString();
				_newRoom.Stateflag = _dRow["Stateflag"].ToString();
				_newRoom.CleaningStatus = _dRow["CleaningStatus"].ToString();
				_newRoom.CreateTime = DateTime.Parse(_dRow["CreateTime"].ToString());
				_newRoom.CreatedBy = _dRow["CreatedBy"].ToString();
				_newRoom.UpdateTime = DateTime.Parse(_dRow["UpdateTime"].ToString());
				_newRoom.UpdatedBy = _dRow["UpdatedBy"].ToString();
                _newRoom.RoomArea = decimal.Parse(_dRow["roomArea"].ToString());
				//_newRoom.Amenities = _dRow["Amenities"].ToString();
                /* FP-SCR-00139 #1 [07.20.2010]
                 * additional field for description of room */
                _newRoom.RoomDescription = _dRow["RoomDescription"].ToString();

				_oRoomList.Add(_newRoom);
			}

			return _oRoomList;
		}

        //Kevin Oliveros

        public bool insertRoomCombination(string pRoomID ,C1.Win.C1FlexGrid.C1FlexGrid pGrid)
        {
            if (!deleteRoomComb(pRoomID))
            {
                return false;
            }
            try
            {
                foreach (C1.Win.C1FlexGrid.Row _row in pGrid.Rows)
                {
                    if (_row.Index != 0)
                    {
                        oRoomDAO.insertRoomCombination(pRoomID, _row["RoomMergeID"].ToString(), _row["RoomMergeDescription"].ToString());
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable getAllRoomComb(string pRoomID)
        {
           oRoomDAO = new RoomDAO();
           return oRoomDAO.getAllRoomComb(pRoomID);
        }
        public bool deleteRoomComb(string pRoomID)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.deleteRoomComb(pRoomID);
        }
        

	}
}