using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.Accounts.BusinessLayer
{
    public class ContactPerson
    {
        public ContactPerson()
        {
        }
        private string mContactID;
        public string ContactID
        {
            get
            {
                return mContactID;
            }
            set
            {
                mContactID = value;
            }
        }
        private string mLastName;
        public string LastName
        {
            get
            {
                return mLastName;
            }
            set
            {
                mLastName = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mFirstName;
        public string FirstName
        {
            get
            {
                return mFirstName;
            }
            set
            {
                mFirstName = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mMiddleName;
        public string MiddleName
        {
            get
            {
                return mMiddleName;
            }
            set
            {
                mMiddleName = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mDesignation;
        public string Designation
        {
            get
            {
                return mDesignation;
            }
            set
            {
                mDesignation = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mPersonType;
        public string PersonType
        {
            get
            {
                return mPersonType;
            }
            set
            {
                mPersonType = value;
            }
        }
        private string mAddress;
        public string Address
        {
            get
            {
                return mAddress;
            }
            set
            {
                mAddress = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mTelNo;
        public string TelNo
        {
            get
            {
                return mTelNo;
            }
            set
            {
                mTelNo = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mMobileNo;
        public string MobileNo
        {
            get
            {
                return mMobileNo;
            }
            set
            {
                mMobileNo = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mFaxNo;
        public string FaxNo
        {
            get
            {
                return mFaxNo;
            }
            set
            {
                mFaxNo = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mEmail;
        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mFolioID ="";
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
        private string mAccountID;
        public string AccountID
        {
            get
            {
                return mAccountID;
            }
            set
            {
                mAccountID = value;
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
        private DateTime mBirthDate;
        public DateTime BirthDate
        {
            get
            {
                return mBirthDate;
            }
            set
            {
                mBirthDate = value;
            }
        }
        private ContactPersonDAO oContactPersonDAO;
        public void save(ref MySqlTransaction pTrans)
        {
            oContactPersonDAO = new ContactPersonDAO();
            if (this.ContactID == "AUTO")
            {
                oContactPersonDAO.save(this, ref pTrans);
            }
            else
            {
                oContactPersonDAO.update(this, ref pTrans);
            }
        }

        public DataTable getContactPersons(string pAccountID, int pHotelID)
        {
            oContactPersonDAO = new ContactPersonDAO();
            return oContactPersonDAO.getContactPersons(pAccountID, pHotelID);
        }

        public IList<ContactPerson> getContactPersons(string pFolioID, int pHotelID, string pAccountID)
        {
            oContactPersonDAO = new ContactPersonDAO();
            DataTable _dt = oContactPersonDAO.getContactPersons(pFolioID, pHotelID, pAccountID);
            IList<ContactPerson> _contactPersons = new List<ContactPerson>();
            ContactPerson _oContactPerson;
            foreach (DataRow _dRow in _dt.Rows)
            {
                _oContactPerson = new ContactPerson();
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
                _oContactPerson.FolioID = _dRow["folioID"].ToString();
                _oContactPerson.AccountID = _dRow["accountID"].ToString();
                _oContactPerson.HotelID = _dRow["hotelID"].ToString();
                _oContactPerson.BirthDate = DateTime.Parse(_dRow["birthdate"].ToString());
                _contactPersons.Add(_oContactPerson);
            }
            return _contactPersons;
        }

        public void deleteContactPersons(string pAccountID, string pHotelID, ref MySqlTransaction pTrans)
        {
            oContactPersonDAO = new ContactPersonDAO();
            oContactPersonDAO.deleteContactPersons(pAccountID, pHotelID, ref pTrans);
        }

        public DataTable getPersonType()
        {
            oContactPersonDAO = new ContactPersonDAO();
            return oContactPersonDAO.getPersonType();
        }
    }
}
