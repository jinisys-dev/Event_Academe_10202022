
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class RoomTypeFacade
	{

		private RoomTypeDAO oRoomTypeDAO;

		public RoomTypeFacade()
		{
		}

		public object loadObject()
		{
			oRoomTypeDAO = new RoomTypeDAO();
			return oRoomTypeDAO.loadObject();
		}

		//public ArrayList getRoomTypesList()
		//{
		//    try
		//    {
		//        ArrayList roomTypeList = new ArrayList();
		//        RoomType oRoomType = new RoomType();

		//        oRoomTypeDAO = new RoomTypeDAO();
		//        oRoomType = (RoomType)this.loadObject();

		//        foreach (DataRow dRow in oRoomType.Tables[0].Rows)
		//        {
		//            roomTypeList.Add(dRow["RoomTypeCode"]);
		//        }

		//        return roomTypeList;
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show(ex.Message, "Retrieve Room Type List Exception");
		//        return null;
		//    }

		//}

		public string getRoomType(string a_RoomId)
		{
			oRoomTypeDAO = new RoomTypeDAO();
			return oRoomTypeDAO.getRoomType(a_RoomId);
		}

		public int insertObject(ref RoomType a_RoomType)
		{
			int rowsAffected = 0;

			oRoomTypeDAO = new RoomTypeDAO();
			rowsAffected = oRoomTypeDAO.insertObject(ref a_RoomType);

			return rowsAffected;
		}

		public int updateObject(ref RoomType a_RoomType)
		{
			int rowsAffected = 0;
			oRoomTypeDAO = new RoomTypeDAO();
			rowsAffected = oRoomTypeDAO.updateObject(ref a_RoomType);
			return rowsAffected;

		}

		public int deleteObject(ref RoomType a_RoomType)
		{
			oRoomTypeDAO = new RoomTypeDAO();
			return oRoomTypeDAO.deleteObject(ref a_RoomType);
		}

		public IList<RoomType> getRoomTypesList(string pWhereCondition)
		{
			IList<RoomType> _oRoomTypeList = new List<RoomType>();

			RoomType _oRoomType = (RoomType)this.loadObject();
			DataTable _dtRoomType = _oRoomType.Tables[0];

			DataView _dtView = _dtRoomType.DefaultView;
			_dtView.RowStateFilter = DataViewRowState.OriginalRows;
			_dtView.RowFilter = pWhereCondition;

			foreach (DataRowView _dRow in _dtView)
			{
				RoomType _newRoomType = new RoomType();

				_newRoomType.RoomTypeCode = _dRow["RoomTypeCode"].ToString();
				_newRoomType.MaxOccupants = int.Parse( _dRow["MaxOccupants"].ToString() );
				_newRoomType.NoOfBeds = int.Parse( _dRow["NoOfBeds"].ToString() );
				_newRoomType.NoofAdult = int.Parse( _dRow["NoofAdult"].ToString() );
				_newRoomType.NoofChild = int.Parse( _dRow["NoofChild"].ToString() );
				_newRoomType.ShareType = _dRow["ShareType"].ToString();
				_newRoomType.StatusFlag = _dRow["statusFlag"].ToString();
				//_newRoomType.HotelID = _dRow["HotelID"].ToString();
				_newRoomType.CreateTime = DateTime.Parse( _dRow["CreateTime"].ToString() );
				_newRoomType.CreatedBy = _dRow["CreatedBy"].ToString();
				_newRoomType.UpdateTime = DateTime.Parse( _dRow["UpdateTime"].ToString() );
				_newRoomType.UpdatedBy = _dRow["UpdatedBy"].ToString();

                /* FP-SCR-00139 #2 [07.20.2010]
                 * add additional field to get room's super type */
                _newRoomType.RoomSuperType = _dRow["RoomSuperType"].ToString();

				_oRoomTypeList.Add(_newRoomType);

			}

			return _oRoomTypeList;
		}


	}
}