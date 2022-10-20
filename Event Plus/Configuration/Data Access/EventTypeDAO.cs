using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class EventTypeDAO
    {
        public EventTypeDAO()
        { }

        #region EVENT TYPES

        public string saveEventTypes(EventType poEventType)
        {
            string _type = poEventType.GetType().GetProperty("Event_Type").GetValue(poEventType, null).ToString();
            string _description = poEventType.GetType().GetProperty("Description").GetValue(poEventType, null).ToString();
            int _banquet = int.Parse(poEventType.GetType().GetProperty("BanquetType").GetValue(poEventType, null).ToString());

            string _sql = "call spInsertEventTypes('" + _type + "','" + _description + "','" + GlobalVariables.gLoggedOnUser + "'," + _banquet + ")";
            try
            {
                MySqlCommand _cmdInsert = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                string _lastInsertID = _cmdInsert.ExecuteScalar().ToString();

                return _lastInsertID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateEventTypes(EventType poEventType)
        {
            int _eventID = int.Parse(poEventType.GetType().GetProperty("EventID").GetValue(poEventType, null).ToString());
            string _type = poEventType.GetType().GetProperty("Event_Type").GetValue(poEventType, null).ToString();
            string _description = poEventType.GetType().GetProperty("Description").GetValue(poEventType, null).ToString();
            int _banquet = int.Parse(poEventType.GetType().GetProperty("BanquetType").GetValue(poEventType, null).ToString());

            string _sqlQuery = "call spUpdateEventTypes(" + _eventID + ",'" + _type + "','" + _description + "','" + GlobalVariables.gLoggedOnUser + "'," + _banquet + ")";
            try
            {
                MySqlCommand _cmdUpdate = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEventType(string pEventID)
        {
            string _sqlQuery = "Call spDeleteEventType('" + pEventID + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmdDelete = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdDelete.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventTypes()
        {
            string _sqlQuery = "select * from event_type where `status`='active'";
            try
            {
                MySqlCommand _cmdSelect = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter _daSelect = new MySqlDataAdapter(_cmdSelect);
                DataTable _dtSelect = new DataTable();
                _daSelect.Fill(_dtSelect);

                return _dtSelect;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool isBanquetType(string pEventType)
        {
            string query = "select banquetType from event_type where eventType='" + pEventType + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                int value = int.Parse(cmd.ExecuteScalar().ToString());

                if (value == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion


        #region EVENT ATTRIBUTES

        public void saveEventAttributes(EventType poEventAttributes)
        {
            string _type = poEventAttributes.GetType().GetProperty("EventID").GetValue(poEventAttributes, null).ToString();
            string _key = poEventAttributes.GetType().GetProperty("Key").GetValue(poEventAttributes, null).ToString();

            string _sqlQuery = "call spInsertEventAttributes('" + _type + "','" + _key + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmdInsert = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventAttributes(string pEventType)
        {
            string _sqlSelect = "call spGetAttributesForEventTypes('" + pEventType + "')";
            try
            {
                MySqlCommand _cmdSelect = new MySqlCommand(_sqlSelect, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter _daSelect = new MySqlDataAdapter(_cmdSelect);
                DataTable _dtSelect = new DataTable();
                _daSelect.Fill(_dtSelect);

                return _dtSelect;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEventAttributes(string pEventID)
        {
            string _sqlDelete = "delete from event_attributes where eventID='" + pEventID + "'";
            try
            {
                MySqlCommand _cmdDelete = new MySqlCommand(_sqlDelete, GlobalVariables.gPersistentConnection);
                _cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
