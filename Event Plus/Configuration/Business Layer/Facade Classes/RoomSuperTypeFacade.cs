using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class RoomSuperTypeFacade
    {
        public RoomSuperTypeFacade()
        {}

        private RoomSuperTypeDAO loRoomSuperTypeDAO;
        public DataTable getRoomSuperTypes()
        {
            loRoomSuperTypeDAO = new RoomSuperTypeDAO();
            return loRoomSuperTypeDAO.getRoomSuperTypes();
        }

        public void saveRoomSuperType(object poRoomSuperType)
        {
            loRoomSuperTypeDAO = new RoomSuperTypeDAO();
            loRoomSuperTypeDAO.saveRoomSuperType(poRoomSuperType);
        }

        public void updateRoomSuperType(object poRoomSuperType)
        {
            loRoomSuperTypeDAO = new RoomSuperTypeDAO();
            loRoomSuperTypeDAO.updateRoomSuperType(poRoomSuperType);
        }

        public void deleteRoomSuperType(string pRoomSuperType)
        {
            loRoomSuperTypeDAO = new RoomSuperTypeDAO();
            loRoomSuperTypeDAO.deleteRoomSuperType(pRoomSuperType);
        }
    }
}
