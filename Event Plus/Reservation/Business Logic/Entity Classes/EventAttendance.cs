using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.DataAccessLayer;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventAttendance
    {
        #region "VARIABLES"
        EventAttendanceDAO loEventAttendance = new EventAttendanceDAO();
        #endregion

        public EventAttendance()
        {
        }

        public EventAttendance(string pFolioID, int pHotelID)
        {
            mFolioID = pFolioID;
            mHotelID = pHotelID;
            loadObject();
        }

        private void loadObject()
        {
            DataTable _dt = loEventAttendance.getEventAttendance(mFolioID, mHotelID);
            if (_dt.Rows.Count > 0)
            {
                mFolioID = _dt.Rows[0]["FolioID"].ToString();
                mHotelID = int.Parse(_dt.Rows[0]["HotelID"].ToString());
                mGeographicalScope = _dt.Rows[0]["GeographicalScope"].ToString();
                mForeignParticipants = int.Parse(_dt.Rows[0]["ForeignParticipants"].ToString());
                mLocalParticipants = int.Parse(_dt.Rows[0]["LocalParticipants"].ToString());
                mForeignBased = int.Parse(_dt.Rows[0]["ForeignBased"].ToString());
                mLocalBased = int.Parse(_dt.Rows[0]["LocalBased"].ToString());
                mNoOfVisitors = int.Parse(_dt.Rows[0]["NoOfVisitors"].ToString());
                mActualAttendees = int.Parse(_dt.Rows[0]["ActualAttendees"].ToString());
                mRemarks = _dt.Rows[0]["Remarks"].ToString();
            }
        }

        public void save(ref MySqlTransaction pTrans)
        {
            loEventAttendance.save(this, ref pTrans);
        }

        public void update(ref MySqlTransaction pTrans)
        {
            loEventAttendance.update(this, ref pTrans);
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

        private string mGeographicalScope;
        public string GeographicalScope
        {
            get
            {
                return mGeographicalScope;
            }
            set
            {
                mGeographicalScope = GlobalFunctions.removeQuotes(value);
            }
        }

        private int mForeignParticipants;
        public int ForeignParticipants
        {
            get
            {
                return mForeignParticipants;
            }
            set
            {
                mForeignParticipants = value;
            }
        }

        private int mLocalParticipants;
        public int LocalParticipants
        {
            get
            {
                return mLocalParticipants;
            }
            set
            {
                mLocalParticipants = value;
            }
        }

        private int mForeignBased;
        public int ForeignBased
        {
            get
            {
                return mForeignBased;
            }
            set
            {
                mForeignBased = value;
            }
        }

        private int mLocalBased;
        public int LocalBased
        {
            get
            {
                return mLocalBased;
            }
            set
            {
                mLocalBased = value;
            }
        }

        private int mNoOfVisitors;
        public int NoOfVisitors
        {
            get
            {
                return mNoOfVisitors;
            }
            set
            {
                mNoOfVisitors = value;
            }
        }

        private int mActualAttendees;
        public int ActualAttendees
        {
            get
            {
                return mActualAttendees;
            }
            set
            {
                mActualAttendees = value;
            }
        }

        private string mRemarks="";
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

        public DataTable getEventAttendance(string pFolioID, int pHotelID)
        {
            return loEventAttendance.getEventAttendance(pFolioID, pHotelID);
        }
    }
}
