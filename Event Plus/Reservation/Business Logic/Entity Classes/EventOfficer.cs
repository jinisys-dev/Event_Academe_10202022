using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventOfficer : Jinisys.Hotel.Security.BusinessLayer.User
    {
        private string mID;
        public string ID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
            }
        }

        private string mUserID;
        public string UserID
        {
            get
            {
                return mUserID;
            }
            set
            {
                mUserID = value;
            }
        }

        private string mFolioID;
        public string FolioID
        {
            get
            {
                return mFolioID;
            }
            set
            {
                mFolioID = value;
            }
        }
        private string mHotelID;
        public string HotelID
        {
            get
            {
                return mHotelID;
            }
            set
            {
                mHotelID = value;
            }
        }
        private EventOfficerDAO oEventOfficerDAO;
        public void save(ref MySqlTransaction pTrans)
        {
            oEventOfficerDAO = new EventOfficerDAO();
            oEventOfficerDAO.save(this, ref pTrans);
        }
        public IList<EventOfficer> getEventOfficers(string pFolioID, string pHotelID)
        {
            oEventOfficerDAO = new EventOfficerDAO();
            DataTable _dt = oEventOfficerDAO.getEventOfficers(pFolioID, pHotelID);
            IList<EventOfficer> _eventOfficers = new List<EventOfficer>();
            EventOfficer _oEventOfficer;
            foreach (DataRow _dRow in _dt.Rows)
            {
                _oEventOfficer = new EventOfficer();
                _oEventOfficer.ID = _dRow["ID"].ToString();
                _oEventOfficer.UserID = _dRow["userID"].ToString();
                _oEventOfficer.FirstName = _dRow["firstName"].ToString();
                _oEventOfficer.LastName = _dRow["lastName"].ToString();
                _oEventOfficer.FolioID = _dRow["folioID"].ToString();
                _oEventOfficer.HotelID = _dRow["hotelID"].ToString();
                _eventOfficers.Add(_oEventOfficer);
            }
            return _eventOfficers;
        }
        public void deleteEventOfficers(string pFolioID, string pHotelID, ref MySqlTransaction pTrans)
        {
            oEventOfficerDAO = new EventOfficerDAO();
            oEventOfficerDAO.deleteEventOfficers(pFolioID, pHotelID, ref pTrans);
        }
    }
}

