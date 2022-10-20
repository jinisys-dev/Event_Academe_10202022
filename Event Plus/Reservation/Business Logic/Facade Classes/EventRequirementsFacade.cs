using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventRequirementsFacade
    {
        public EventRequirementsFacade()
        { }

        private EventsRequirementsDAO _oRequirementDAO;
        public void saveEventsRequirements(EventRequirements requirements, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            _oRequirementDAO = new EventsRequirementsDAO();
            _oRequirementDAO.saveEventRequirements(requirements, ref pTrans);
        }

        public void deleteEventsRequirements(string folioID, ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            _oRequirementDAO = new EventsRequirementsDAO();
            _oRequirementDAO.deleteEventRequirements(folioID, ref pTrans);
        }

        public GenericList<EventRequirements> getEventRequirements(string folioID)
        {
            GenericList<EventRequirements> eventRequirements = new GenericList<EventRequirements>();
            _oRequirementDAO = new EventsRequirementsDAO();
            DataTable dt = _oRequirementDAO.getEventRequirements(folioID);
            foreach (DataRow dr in dt.Rows)
            {
                EventRequirements eventRequirement = new EventRequirements();
                eventRequirement.Description = dr["description"].ToString();
                eventRequirement.RequirementCode = dr["requirementID"].ToString();
                eventRequirement.Remarks = dr["remarks"].ToString();

                eventRequirements.Add(eventRequirement);
            }
            return eventRequirements;
        }

        public DataTable getEventRequirementsDetails(string pFolioID)
        {
            _oRequirementDAO = new EventsRequirementsDAO();
            return _oRequirementDAO.getEventRequirements(pFolioID);
        }
    }
}
