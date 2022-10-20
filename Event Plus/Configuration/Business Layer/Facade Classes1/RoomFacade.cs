



using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.Configuration.DataAccessLayer;


namespace Jinisys.Hotel.Configuration.BusinessLayer
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

                foreach (DataRow dataRow in oRoom.Tables[0].Rows)
                {
                    roomIDs.Add(dataRow["RoomId"]);
                }

                return roomIDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Load ArrayList Exception");
                return null;
            }
        }

        public ArrayList getRoomsByRoomType(string a_RoomTypeCode)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.getRoomsByRoomType(a_RoomTypeCode);
        }

        public int updateRoomCoordinates(string a_RoomId, int a_XCoordinate, int a_YCoordinate)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.updateRoomCoordinates(a_RoomId, a_XCoordinate, a_YCoordinate);
        }

        public int deleteRoomAmenity(string a_RoomId,string a_Amenityid)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.deleteRoomAmenity(a_RoomId, a_Amenityid);
        }

        public int addRoomAmenity(string a_RoomId, string a_Amenityid)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.addRoomAmenity(a_RoomId, a_Amenityid);
        }

        public int setRoomStatus(string a_RoomId, string a_StateFlag)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.setRoomStatus(a_RoomId, a_StateFlag);
        }

        public Room getRoom(string a_Roomid)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.getRoom(a_Roomid);
        }

        public int setRoomCleaningStatus(string a_RoomId, string a_CleaningStatus)
        {
            oRoomDAO = new RoomDAO();
            return oRoomDAO.setRoomCleaningStatus(a_RoomId, a_CleaningStatus);
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

    }
}