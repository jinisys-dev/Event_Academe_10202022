using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;
namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    class EventOfficerDAO
    {
        private string lID;
        private string lUserID;
        private string lFolioID;
        private string lHotelID;

        private void loadAttributes(Object poEventOfficer)
        {
            try
            {
                lID = poEventOfficer.GetType().GetProperty("ID").GetValue(poEventOfficer, null).ToString();
                lUserID = poEventOfficer.GetType().GetProperty("UserID").GetValue(poEventOfficer, null).ToString();
                lHotelID = poEventOfficer.GetType().GetProperty("HotelID").GetValue(poEventOfficer, null).ToString();
                lFolioID = poEventOfficer.GetType().GetProperty("FolioID").GetValue(poEventOfficer, null).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventOfficerDAO.loadAttributes\r\n" + ex.Message);
            }
        }

        public void save(Object poEventOfficer, ref MySqlTransaction pTrans)
        {
            // Daniel Balagosa
            // June 20, 2012
            // Populates Event Officer and Marketing Officer in ReservationLostUI
            loadAttributes(poEventOfficer);
            MySqlCommand _command;
            try
            {
                if (lID == "AUTO")
                {
                    _command = new MySqlCommand("call spInsertEventOfficer('" + lUserID + "','" + lFolioID + "','" + lHotelID + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
                    _command.Transaction = pTrans;
                    _command.ExecuteNonQuery();
                }
                _command = new MySqlCommand("call spUpdateEventOfficer('" + lID + "','" + lUserID + "','" + lFolioID + "','" + lHotelID + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
                _command.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventOfficerDAO.saveEventOfficer\r\n" + ex.Message);
            }
        }
        public DataTable getEventOfficers(string pFolioID, string pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventOfficers('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ EventOfficerDAO.getEventOfficers\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }
        public void deleteEventOfficers(string pFolioID, string pHotelID, ref MySqlTransaction pTrans)
        {
            MySqlCommand _command = new MySqlCommand("call spDeleteEventOfficers('" + pFolioID + "','" + pHotelID + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _command.Transaction = pTrans;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @ EventOfficerDAO.deleteEventOfficers\r\n" + ex.Message);
            }
            finally
            {
                _command.Dispose();
            }
        }
    }
}
