using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using MySql.Data.MySqlClient;
using System.Data;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventContact : ContactPerson
    {
        private EventContactDAO oEventContactDAO = new EventContactDAO();
        
        public void save(ref MySqlTransaction pTrans)
        {
            oEventContactDAO.save(this, ref pTrans);
        }
        public void update(ref MySqlTransaction pTrans)
        {
            oEventContactDAO.update(this, ref pTrans);
        }

        public void deleteContacts(string pFolioID, ref MySqlTransaction pTrans)
        {
            oEventContactDAO.deleteEventContacts(pFolioID, ref pTrans);
        }

        public IList<EventContact> getEventContacts(string pFolioID, string pAccountID)
        {
            DataTable _dt = oEventContactDAO.getEventContacts(pFolioID, pAccountID);
            IList<EventContact> _contactPersons = new List<EventContact>();
            EventContact _oContactPerson;
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow _dRow in _dt.Rows)
                {
                    _oContactPerson = new EventContact();
                    _oContactPerson.ContactID = _dRow["contactID"].ToString();
                    _oContactPerson.LastName = _dRow["lastName"].ToString();
                    _oContactPerson.FirstName = _dRow["firstName"].ToString();
                    _oContactPerson.MiddleName = _dRow["middleName"].ToString();
                    _oContactPerson.Designation = _dRow["designation"].ToString();
                    _oContactPerson.PersonType = _dRow["personType"].ToString();
                    _oContactPerson.Address = _dRow["address"].ToString();
                    _oContactPerson.TelNo = _dRow["telNo"].ToString();
                    _oContactPerson.MobileNo = _dRow["mobileNo"].ToString();
                    _oContactPerson.FaxNo = _dRow["faxNo"].ToString();
                    _oContactPerson.Email = _dRow["email"].ToString();
                    
                    //_oContactPerson.FolioID = _dRow["folioID"].ToString();
                    //_oContactPerson.AccountID = _dRow["accountID"].ToString();
                    //_oContactPerson.HotelID = _dRow["hotelID"].ToString();

                    try
                    {
                        _oContactPerson.BirthDate = DateTime.Parse(_dRow["birthdate"].ToString());
                    }
                    catch
                    {
                    }
                    _contactPersons.Add(_oContactPerson);
                }
            }
            return _contactPersons;
        }
    }
}
