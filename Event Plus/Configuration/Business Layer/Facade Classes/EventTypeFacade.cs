using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class EventTypeFacade
    {
        public EventTypeFacade()
        { }

        private EventTypeDAO loEventTypeDAO;

        #region EVENT TYPE

        public void saveEventType(EventType poEventType, ref GenericList<EventType> pEventTypeList)
        {
            loEventTypeDAO = new EventTypeDAO();
            string _eventID = loEventTypeDAO.saveEventTypes(poEventType);

            poEventType.EventID = int.Parse(_eventID);
            pEventTypeList.Add(poEventType);
        }

        public GenericList<EventType> getEventTypes()
        {
            GenericList<EventType> _eventTypeList = new GenericList<EventType>();
            loEventTypeDAO = new EventTypeDAO();
            DataTable _dataTable = loEventTypeDAO.getEventTypes();
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventType _eventType = new EventType();
                _eventType.Event_Type = _dataRow["eventType"].ToString();
                _eventType.Description = _dataRow["description"].ToString();
                _eventType.EventID = int.Parse(_dataRow["typeID"].ToString());
                _eventType.BanquetType = int.Parse(_dataRow["banquetType"].ToString());

                _eventTypeList.Add(_eventType);
            }
            return _eventTypeList;
        }

        public void deleteEventType(string pEventID, ref GenericList<EventType> pEventTypeList)
        {
            try
            {
                loEventTypeDAO = new EventTypeDAO();
                loEventTypeDAO.deleteEventType(pEventID);

                foreach (EventType _oEventType in pEventTypeList)
                {
                    if (_oEventType.EventID == int.Parse(pEventID))
                    {
                        pEventTypeList.Remove(_oEventType);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateEventType(EventType poEventType, GenericList<EventType> pEventTypeList)
        {
            loEventTypeDAO = new EventTypeDAO();
            loEventTypeDAO.updateEventTypes(poEventType);

            foreach (EventType _oEventType in pEventTypeList)
            {
                if (_oEventType.EventID == poEventType.EventID)
                {
                    _oEventType.Description = poEventType.Description;
                    _oEventType.Event_Type = poEventType.Event_Type;
                    _oEventType.EventID = poEventType.EventID;
                    _oEventType.BanquetType = poEventType.BanquetType;
                    break;
                }
            }
        }

        public bool isBanquetType(string pEventType)
        {
            loEventTypeDAO = new EventTypeDAO();
            return loEventTypeDAO.isBanquetType(pEventType);
        }

        #endregion

        #region EVENT ATTRIBUTES

        public void saveEventAttributes(EventType pEventAttributes)
        {
            loEventTypeDAO = new EventTypeDAO();
            loEventTypeDAO.saveEventAttributes(pEventAttributes);
        }

        public GenericList<EventType> getEventAttributes(string pEventType)
        {
            GenericList<EventType> _eventAttributeList = new GenericList<EventType>();
            loEventTypeDAO = new EventTypeDAO();
            DataTable _dataTable = loEventTypeDAO.getEventAttributes(pEventType);
            foreach (DataRow _dataRow in _dataTable.Rows)
            {
                EventType events = new EventType();
                events.Key = _dataRow["key"].ToString();

                _eventAttributeList.Add(events);
            }
            return _eventAttributeList;
        }

        public void deleteEventAttributes(string _eventType)
        {
            loEventTypeDAO = new EventTypeDAO();
            loEventTypeDAO.deleteEventAttributes(_eventType);
        }

        #endregion
    }
}
