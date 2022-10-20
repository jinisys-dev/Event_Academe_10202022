using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class EventAttendanceDAO
    {
        private string lFolioID;
        private int lHotelID;
        private string lGeographicalScope;
        private int lForeignParticipants;
        private int lLocalParticipants;
        private int lForeignBased;
        private int lLocalBased;
        private int lNoOfVisitors;
        private int lActualAttendees;
        private string lRemarks;

        private void loadAttributes(Object poEventAttendance)
        {
            try
            {
                lFolioID = poEventAttendance.GetType().GetProperty("FolioID").GetValue(poEventAttendance, null).ToString();
                lHotelID = int.Parse(poEventAttendance.GetType().GetProperty("HotelID").GetValue(poEventAttendance, null).ToString());
                lGeographicalScope = poEventAttendance.GetType().GetProperty("GeographicalScope").GetValue(poEventAttendance, null).ToString();
                lForeignParticipants = int.Parse(poEventAttendance.GetType().GetProperty("ForeignParticipants").GetValue(poEventAttendance, null).ToString());
                lLocalParticipants = int.Parse(poEventAttendance.GetType().GetProperty("LocalParticipants").GetValue(poEventAttendance, null).ToString());
                lForeignBased = int.Parse(poEventAttendance.GetType().GetProperty("ForeignBased").GetValue(poEventAttendance, null).ToString());
                lLocalBased = int.Parse(poEventAttendance.GetType().GetProperty("LocalBased").GetValue(poEventAttendance, null).ToString());
                lNoOfVisitors = int.Parse(poEventAttendance.GetType().GetProperty("NoOfVisitors").GetValue(poEventAttendance, null).ToString());
                lActualAttendees = int.Parse(poEventAttendance.GetType().GetProperty("ActualAttendees").GetValue(poEventAttendance, null).ToString());
                lRemarks = poEventAttendance.GetType().GetProperty("Remarks").GetValue(poEventAttendance, null).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventAttendanceDAO.loadAttributes\r\n" + ex.Message);
            }
        }

        public DataTable getEventAttendance(string pFolioID, int pHotelID)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetEventAttendance('" + pFolioID + "','" + pHotelID + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventAttendanceDAO.getEventAttendance\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public void save(Object poEventAttendance, ref MySqlTransaction pTrans)
        {
            loadAttributes(poEventAttendance);
            MySqlCommand _save = new MySqlCommand("call spInsertEventAttendance('" + 
                                                        lFolioID + "','" +
                                                        lHotelID + "','" +
                                                        lGeographicalScope + "','" +
                                                        lForeignParticipants + "','" +
                                                        lLocalParticipants + "','" +
                                                        lForeignBased + "','" +
                                                        lLocalBased + "','" +
                                                        lNoOfVisitors + "','" +
                                                        lActualAttendees + "','" +
                                                        lRemarks + "','" +
                                                        GlobalVariables.gLoggedOnUser + "')"
                                                        , GlobalVariables.gPersistentConnection);
            try
            {
                _save.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventAttendanceDAO.save\r\n" + ex.Message);
            }
            finally
            {
                _save.Dispose();
            }
        }

        public void update(Object poEventAttendance, ref MySqlTransaction pTrans)
        {
            loadAttributes(poEventAttendance);
            MySqlCommand _update = new MySqlCommand("call spUpdateEventAttendance('" +
                                                        lFolioID + "','" +
                                                        lHotelID + "','" +
                                                        lGeographicalScope + "','" +
                                                        lForeignParticipants + "','" +
                                                        lLocalParticipants + "','" +
                                                        lForeignBased + "','" +
                                                        lLocalBased + "','" +
                                                        lNoOfVisitors + "','" +
                                                        lActualAttendees + "','" +
                                                        lRemarks + "','" +
                                                        GlobalVariables.gLoggedOnUser + "')"
                                                        , GlobalVariables.gPersistentConnection);
            try
            {
                _update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @EventAttendanceDAO.update\r\n" + ex.Message);
            }
            finally
            {
                _update.Dispose();
            }
        }
    }
}
