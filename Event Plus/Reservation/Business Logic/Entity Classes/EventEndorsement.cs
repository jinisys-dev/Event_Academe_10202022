using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventEndorsement
    {
        public EventEndorsement() { }

        public EventEndorsement(string pFolioID, int pHotelID)
        {
            mFolioID = pFolioID;
            mHotelID = pHotelID;
            loadObject();
            mEMDActions = getEMDActions(pFolioID, pHotelID);
        }

        #region "VARIABLES"
        public static string BEING_PROCESSED = "PROCESSED";
        public static string FOR_PICKUP = "PICKUP";
        public static string SENT_TO_CLIENT = "SENT";
        public static string SIGNED_RETURNED_TO_PICC = "RETURNED";
        private EventEndorsementDAO oEventEndorsementDAO = new EventEndorsementDAO();
        #endregion

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

        private string mLetterOfProposal;
        public string LetterOfProposal
        {
            get
            {
                return mLetterOfProposal;
            }
            set
            {
                mLetterOfProposal = GlobalFunctions.removeQuotes(value);
            }
        }

        private decimal mContractAmount;
        public decimal ContractAmount
        {
            get
            {
                return mContractAmount;
            }
            set
            {
                mContractAmount = value;
            }
        }

        private DateTime mDueDate1;
        public DateTime DueDate1
        {
            get
            {
                return mDueDate1;
            }
            set
            {
                mDueDate1 = value;
            }
        }

        private DateTime mDueDate2;
        public DateTime DueDate2
        {
            get
            {
                return mDueDate2;
            }
            set
            {
                mDueDate2 = value;
            }
        }

        private DateTime mDueDate3;
        public DateTime DueDate3
        {
            get
            {
                return mDueDate3;
            }
            set
            {
                mDueDate3 = value;
            }
        }

        private string mLetterOfAgreement;
        public string LetterOfAgreement
        {
            get
            {
                return mLetterOfAgreement;
            }
            set
            {
                mLetterOfAgreement = GlobalFunctions.removeQuotes(value);
            }
        }

        private DateTime mPickupDate;
        public DateTime PickupDate
        {
            get
            {
                return mPickupDate;
            }
            set
            {
                mPickupDate = value;
            }
        }

        private DateTime mSentToClientDate;
        public DateTime SentToClientDate
        {
            get
            {
                return mSentToClientDate;
            }
            set
            {
                mSentToClientDate = value;
            }
        }

        private DateTime mSignedDate;
        public DateTime SignedDate
        {
            get
            {
                return mSignedDate;
            }
            set
            {
                mSignedDate = value;
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

        private string mConcessions = "";
        public string Concessions
        {
            get
            {
                return mConcessions;
            }
            set
            {
                mConcessions = GlobalFunctions.removeQuotes(value);
            }
        }

        private string mGiveaways = "";
        public string Giveaways
        {
            get
            {
                return mGiveaways;
            }
            set
            {
                mGiveaways = GlobalFunctions.removeQuotes(value);
            }
        }
        private string mRemarks = "";
        public string Remarks
        {
            get
            {
                return mRemarks;
            }
            set
            {
                mRemarks = GlobalFunctions.removeQuotes(value);
            }
        }

        public void save(ref MySqlTransaction pTrans)
        {
            oEventEndorsementDAO.save(this, ref pTrans);
            if(mEMDActions.Length > 0)
                // REVIEW how to insert EMDActions
                saveEMDActions(mFolioID, mEMDActions, mHotelID, ref pTrans);
        }

        public void update(ref MySqlTransaction pTrans)
        {
            oEventEndorsementDAO.update(this, ref pTrans);
            deleteEMDActions(mFolioID, mHotelID, ref pTrans);
            if (mEMDActions!=null && mEMDActions.Length > 0)
                saveEMDActions(mFolioID, mEMDActions, mHotelID, ref pTrans);
        }

        public DataTable getEventEndorsement(string pFolioID, string pHotel)
        {
            return oEventEndorsementDAO.getEventEndorsement(pFolioID, pHotel);
        }

        /// <summary>
        /// this will load object attributes to self
        /// </summary>
        private void loadObject()
        {
            DataTable _dt = this.getEventEndorsement(mFolioID, mHotelID.ToString());
            if (_dt.Rows.Count > 0)
            {
                mLetterOfProposal = _dt.Rows[0]["letterOfProposal"].ToString();
                mContractAmount = decimal.Parse(_dt.Rows[0]["contractAmount"].ToString());
                mDueDate1 = DateTime.Parse(_dt.Rows[0]["dueDate1"].ToString());
                mDueDate2 = DateTime.Parse(_dt.Rows[0]["dueDate2"].ToString());
                mDueDate3 = DateTime.Parse(_dt.Rows[0]["dueDate3"].ToString());
                mLetterOfAgreement = _dt.Rows[0]["letterOfAgreement"].ToString();
                mPickupDate = DateTime.Parse(_dt.Rows[0]["pickupDate"].ToString());
                mSentToClientDate = DateTime.Parse(_dt.Rows[0]["sentToClientDate"].ToString());
                mSignedDate = DateTime.Parse(_dt.Rows[0]["signedDate"].ToString());
                mHotelID = int.Parse(_dt.Rows[0]["hotelID"].ToString());
                mConcessions = _dt.Rows[0]["concessions"].ToString();
                mGiveaways = _dt.Rows[0]["giveaways"].ToString();
                //Kevin Oliveros
                mRemarks = _dt.Rows[0]["remarks"].ToString();
            }
        }

        private string[] mEMDActions;
        public string[] EMDActions
        {
            get
            {
                return mEMDActions;
            }
            set
            {
                mEMDActions = value;
            }
        }

        public void saveEMDActions(string pFolioID, string[] pActions, int pHotelID, ref MySqlTransaction pTrans)
        {
            foreach (string _action in pActions)
            {
                oEventEndorsementDAO.saveEMDAction(pFolioID, _action, pHotelID, ref pTrans);
            }
        }

        public void deleteEMDActions(string pFolioID, int pHotelID, ref MySqlTransaction pTrans)
        {
            oEventEndorsementDAO.deleteEMDActions(pFolioID, pHotelID, ref pTrans);
        }

        public string[] getEMDActions(string pFolioID, int pHotelID)
        {
            DataTable _dt = oEventEndorsementDAO.getEMDActions(pFolioID, pHotelID);
            if (_dt.Rows.Count > 0)
            {
                string[] _emdActions = new string[_dt.Rows.Count];
                int i = 0;
                foreach (DataRow _dRow in _dt.Rows)
                {
                    _emdActions[i] = _dRow["action"].ToString();
                    i++;
                }
                return _emdActions;
            }
            return null;
        }
    }
}
