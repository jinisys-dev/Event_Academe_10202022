

using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using Jinisys.Hotel.Configuration.DataAccessLayer;


namespace Jinisys.Hotel.Configuration.BusinessLayer
{
    public class AmenityFacade
    {

        private AmenityDAO oAmenityDAO;

        public AmenityFacade()
        {
        }

        public object loadObject()
        {
            oAmenityDAO = new AmenityDAO();
            return oAmenityDAO.loadObject();
        }

        public Amenity loadUnAssignedAmenities()
        {
            oAmenityDAO = new AmenityDAO();
            return oAmenityDAO.loadUnAssignedAmenities();
        }

        public int insertObject(ref Amenity a_Amenity)
        {
            int rowsAffected = 0;

            oAmenityDAO = new AmenityDAO();
            rowsAffected = oAmenityDAO.insertObject(ref a_Amenity);

            return rowsAffected;
        }

        public int updateObject(ref Amenity a_Amenity)
        {
            int rowsAffected = 0;
            oAmenityDAO = new AmenityDAO();
            rowsAffected = oAmenityDAO.updateObject(ref a_Amenity);
            return rowsAffected;

        }

        // get room amenities for a specific room
        public Amenity getRoomAmenities(string a_RoomId)
        {
            oAmenityDAO = new AmenityDAO();
            return oAmenityDAO.getRoomAmenities(a_RoomId);
        }

        public int deleteObject(ref Amenity a_Amenity)
        {
            oAmenityDAO = new AmenityDAO();
            return oAmenityDAO.deleteObject(ref a_Amenity);
        }

    }
}