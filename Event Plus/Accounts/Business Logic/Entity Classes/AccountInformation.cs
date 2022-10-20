using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.Accounts.BusinessLayer
{
    public class AccountInformation
    {
        public AccountInformation() { }
        public AccountInformation(string pAccountID, int pHotelID)
        {
            mAccountID = pAccountID;
            mHotelID = pHotelID;
            loadObject();
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

        private string mAffiliations = "";
        public string Affiliations
        {
            get
            {
                return mAffiliations;
            }
            set
            {
                mAffiliations = GlobalFunctions.removeQuotes(value);
            }
        }

        private string mOfficeOfficers = "";
        public string OfficeOfficers
        {
            get
            {
                return mOfficeOfficers;
            }
            set
            {
                mOfficeOfficers = value;
            }
        }

        private string mNatureOfBusiness = "";
        public string NatureOfBusiness
        {
            get
            {
                return mNatureOfBusiness;
            }
            set
            {
                mNatureOfBusiness = GlobalFunctions.removeQuotes(value);
            }
        }

        private string mPillarsOfOrganization = "";
        public string PillarsOfOrganization
        {
            get
            {
                return mPillarsOfOrganization;
            }
            set
            {
                mPillarsOfOrganization = GlobalFunctions.removeQuotes(value);
            }
        }

        private DateTime mAnniversary;
        public DateTime Anniversary
        {
            get
            {
                return mAnniversary;
            }
            set
            {
                mAnniversary = value;
            }
        }

        AccountInformationDAO oAccountInformationDAO = new AccountInformationDAO();
        public void save(ref MySqlTransaction pTrans)
        {
            oAccountInformationDAO.save(this, ref pTrans);
        }

        public void update(ref MySqlTransaction pTrans)
        {
            oAccountInformationDAO.update(this, ref pTrans);
        }

        public DataTable getAccountInformation(string pAccountID, int pHotelID)
        {
            return oAccountInformationDAO.getAccountInformation(pAccountID, pHotelID);
        }

        private void loadObject()
        {
            DataTable _dt;
            _dt = getAccountInformation(mAccountID, mHotelID);
            if (_dt.Rows.Count > 0)
            {
                DataRow _dRow = _dt.Rows[0];
                mAffiliations = _dRow["Affiliations"].ToString();
                mOfficeOfficers = _dRow["OfficeOfficers"].ToString();
                mNatureOfBusiness = _dRow["NatureOfBusiness"].ToString();
                mPillarsOfOrganization = _dRow["PillarsOfOrganization"].ToString();
                mAnniversary = DateTime.Parse(_dRow["Anniversary"].ToString());
            }
        }
    }
}
