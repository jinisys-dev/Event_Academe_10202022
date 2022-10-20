using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;


using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

//added Apr. 25, 2008
namespace Jinisys.Hotel.Reservation.BusinessLayer
{
	public class EventRoomRequirementFacade
	{
		#region "Event Room Requirements"

		EventRoomRequirementsDAO lRoomRequirementDAO;
		public void saveRoomRequirements(EventRoomRequirements oEvent, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
		{
			lRoomRequirementDAO = new EventRoomRequirementsDAO();
			lRoomRequirementDAO.saveRoomRequirements(oEvent, ref pTrans);
		}

		public void deleteRoomRequirements(string pEventFolioID, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
		{
			lRoomRequirementDAO = new EventRoomRequirementsDAO();
			lRoomRequirementDAO.deleteRoomRequirements(pEventFolioID, ref pTrans);
		}

		public GenericList<EventRoomRequirements> getRoomRequirements(string pFolioID)
		{
			GenericList<EventRoomRequirements> lRoomRequirementList = new GenericList<EventRoomRequirements>();
			lRoomRequirementDAO = new EventRoomRequirementsDAO();
			DataTable dt = lRoomRequirementDAO.getRoomRequirements(pFolioID);
			foreach (DataRow dr in dt.Rows)
			{
				EventRoomRequirements _oRoomRequirements = new EventRoomRequirements();
				_oRoomRequirements.RoomType = dr["roomType"].ToString();
				_oRoomRequirements.NumberOfPax = int.Parse(dr["noOfPax"].ToString());
				_oRoomRequirements.GuaranteedPax = int.Parse(dr["guaranteedPax"].ToString());
				_oRoomRequirements.NumberOfRooms = int.Parse(dr["noOfRooms"].ToString());
				_oRoomRequirements.GuaranteedRooms = int.Parse(dr["guaranteedRooms"].ToString());
				_oRoomRequirements.Remarks = dr["remarks"].ToString();
				_oRoomRequirements.BlockedRooms = int.Parse(dr["blockedRooms"].ToString());

				lRoomRequirementList.Add(_oRoomRequirements);
			}

			return lRoomRequirementList;
		}

		public void updateNumberOfBlockedRooms(string pFolioID, string pRoomType, int pNoOfRooms)
		{
			lRoomRequirementDAO = new EventRoomRequirementsDAO();
			lRoomRequirementDAO.updateNumberOfBlockedRooms(pFolioID, pRoomType, pNoOfRooms);
		}

		public void updateTotalBlockedRooms(string pFolioID, string pRoomType, int pTotalBlockedRooms)
		{

			lRoomRequirementDAO = new EventRoomRequirementsDAO();
			lRoomRequirementDAO.updateTotalBlockedRooms(pFolioID, pRoomType, pTotalBlockedRooms);

		}

		#endregion
	}
}
 