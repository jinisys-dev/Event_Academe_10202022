using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class RoomSuperTypeDAO
    {
        public RoomSuperTypeDAO()
        {}

        public DataTable getRoomSuperTypes()
        {
            try
            {
                string _sqlQuery = "call spGetRoomSuperTypes()";
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _oDataTable = new DataTable();

                _oDataAdapter.Fill(_oDataTable);
                return _oDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ getRoomSuperTypes().\nError msg: " + ex.Message);
            }
        }

        public void saveRoomSuperType(object poRoomSuperType)
        {
            try
            {
                string _roomSuperType = poRoomSuperType.GetType().GetProperty("RoomSuperType").GetValue(poRoomSuperType, null).ToString();
                string _description = poRoomSuperType.GetType().GetProperty("Description").GetValue(poRoomSuperType, null).ToString();
                string _sqlQuery = "call spInsertRoomSuperType('" + _roomSuperType + "','" + _description + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand _oCommand = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ saveRoomSuperType().\nError msg: " + ex.Message);
            }
        }

        public void updateRoomSuperType(object poRoomSuperType)
        {
            try
            {
                string _roomSuperType = poRoomSuperType.GetType().GetProperty("RoomSuperType").GetValue(poRoomSuperType, null).ToString();
                string _description = poRoomSuperType.GetType().GetProperty("Description").GetValue(poRoomSuperType, null).ToString();
                string _sqlQuery = "call spUpdateRoomSuperType('" + _roomSuperType + "','" + _description + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand _oCommand = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ updateRoomSuperType().\nError msg: " + ex.Message);
            }
        }

        public void deleteRoomSuperType(string pRoomSuperType)
        {
            try
            {
                string _sqlQuery = "call spDeleteRoomSuperType('" + pRoomSuperType + "','" + GlobalVariables.gLoggedOnUser + "'," + GlobalVariables.gHotelId + ")";
                MySqlCommand _oCommand = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ deleteRoomSuperType().\nError msg: " + ex.Message);
            }
        }
    }
}
