using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using MySql.Data.MySqlClient;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Accounts.BusinessLayer
{
    public class IncumbentOfficer
    {
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
        private int mHotelID;
        public int HotelID
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
        
        private IncumbentOfficerDAO oIncumbentOfficerDAO;
        public void save(ref MySqlTransaction pTrans)
        {
            oIncumbentOfficerDAO = new IncumbentOfficerDAO();
            oIncumbentOfficerDAO.save(this, ref pTrans);
        }
        public IList<IncumbentOfficer> getIncumbentOfficers(string pFolioID, string pHotelID)
        {
            oIncumbentOfficerDAO = new IncumbentOfficerDAO();
            DataTable _dt = oIncumbentOfficerDAO.getIncumbentOfficers(pFolioID, pHotelID);
            IList<IncumbentOfficer> _incumbentOfficers = new List<IncumbentOfficer>();
            IncumbentOfficer _oIncumbentOfficer;
            foreach (DataRow _dRow in _dt.Rows)
            {
                _oIncumbentOfficer = new IncumbentOfficer();
                _oIncumbentOfficer.ContactID = _dRow["contactID"].ToString();
                _oIncumbentOfficer.FirstName = _dRow["firstName"].ToString();
                _oIncumbentOfficer.LastName = _dRow["lastName"].ToString();
                _oIncumbentOfficer.FolioID = _dRow["folioID"].ToString();
                _oIncumbentOfficer.HotelID = int.Parse(_dRow["hotelID"].ToString());
                _oIncumbentOfficer.Designation = _dRow["designation"].ToString();
                _oIncumbentOfficer.Email = _dRow["email"].ToString();
                _oIncumbentOfficer.MobileNo = _dRow["mobileNo"].ToString();
                _oIncumbentOfficer.BirthDate = DateTime.Parse(_dRow["birthDate"].ToString());
                _oIncumbentOfficer.FaxNo = _dRow["faxNo"].ToString();
                _oIncumbentOfficer.TelNo = _dRow["telNo"].ToString();
                _incumbentOfficers.Add(_oIncumbentOfficer);
            }
            return _incumbentOfficers;
        }
        public void deleteIncumbentOfficers(string pFolioID, string pHotelID, ref MySqlTransaction pTrans)
        {
            oIncumbentOfficerDAO = new IncumbentOfficerDAO();
            oIncumbentOfficerDAO.deleteIncumbentOfficers(pFolioID, pHotelID, ref pTrans);
        }
    
    }
}
