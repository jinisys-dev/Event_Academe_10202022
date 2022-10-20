
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.Configuration.DataAccessLayer;


namespace Jinisys.Hotel.Configuration.BusinessLayer
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

        public ArrayList getRoomTypesList()
        {
            try
            {
                ArrayList roomTypeList = new ArrayList();
                RoomType oRoomType = new RoomType();

                oRoomTypeDAO = new RoomTypeDAO();
                oRoomType = (RoomType)this.loadObject();

                foreach (DataRow dRow in oRoomType.Tables[0].Rows)
                {
                    roomTypeList.Add(dRow["RoomTypeCode"]);
                }

                return roomTypeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Room Type List Exception");
                return null;
            }

        }

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
            
    
    }
}