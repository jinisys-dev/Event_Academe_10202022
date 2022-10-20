using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

//added Apr. 24, 2008
//used for the Sales Module
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class Events : DataSet
        {
            public Events()
            { }

            #region "Global"
            //>>
            private int mEventID;
            public int EventID
            {
                get { return mEventID; }
                set { mEventID = value; }
            }

            private string mCreatedBy;
            public string CREATEDBY
            {
                get { return mCreatedBy; }
                set { mCreatedBy = value; }
            }

            private string mUpdatedBy;
            public string UPDATEDBY
            {
                get { return mUpdatedBy; }
                set { mUpdatedBy = value; }
            }

            private int mHotelID;
            public int HotelID
            {
                get { return mHotelID; }
                set { mHotelID = value; }
            }

            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
            }
            //<<
            #endregion

            #region "Events"
            //>>
            private string mEventName;
            public string EventName
            {
                get { return mEventName; }
                set { mEventName = value; }
            }

            private string mEventType;
            public string EventType
            {
                get { return mEventType; }
                set { mEventType = value; }
            }

            private string mCompanyID;
            public string CompanyID
            {
                get { return mCompanyID; }
                set { mCompanyID = value; }
            }

            private string mStatus;
            public string Status
            {
                get { return mStatus; }
                set { mStatus = value; }
            }

            private DateTime mBookingDate;
            public DateTime BookingDate
            {
                get { return mBookingDate; }
                set { mBookingDate = value; }
            }

            private string mContactPerson;
            public string ContactPerson
            {
                get { return mContactPerson; }
                set { mContactPerson = value; }
            }

            private string mPosition;
            public string Position
            {
                get { return mPosition; }
                set { mPosition = value; }
            }

            private string mRoom;
            public string Room
            {
                get { return mRoom; }
                set { mRoom = value; }
            }

            private string mContactAddress;
            public string ContactAddress
            {
                get { return mContactAddress; }
                set { mContactAddress = value; }
            }

            private string mContactNumber;
            public string ContactNumber
            {
                get { return mContactNumber; }
                set { mContactNumber = value; }
            }

            private int mNoOfLiveIn;
            public int NumberOfLiveIn
            {
                get { return mNoOfLiveIn; }
                set { mNoOfLiveIn = value; }
            }

            private int mNoOfLiveOut;
            public int NumberOfLiveOut
            {
                get { return mNoOfLiveOut; }
                set { mNoOfLiveOut = value; }
            }

            private int mRoomNo;
            public int RoomNumber
            {
                get { return mRoomNo; }
                set { mRoomNo = value; }
            }

            private DateTime mStartEventDate;
            public DateTime StartEventDate
            {
                get { return mStartEventDate; }
                set { mStartEventDate = value; }
            }

            private DateTime mEndEventDate;
            public DateTime EndEventDate
            {
                get { return mEndEventDate; }
                set { mEndEventDate = value; }
            }
            //<<
            #endregion

            #region "Event Room Requirements"
            //>>
            private int mRoomReqID;
            public int RoomRequirementID
            {
                get { return mRoomReqID; }
                set { mRoomReqID = value; }
            }

            private string mRoomType;
            public string RoomType
            {
                get { return mRoomType; }
                set { mRoomType = value; }
            }

            private int mNoOfPax;
            public int NumberOfPax
            {
                get { return mNoOfPax; }
                set { mNoOfPax = value; }
            }

            private int mGuaranteedPax;
            public int GuaranteedPax
            {
                get { return mGuaranteedPax; }
                set { mGuaranteedPax = value; }
            }

            private int mNoOfRooms;
            public int NumberOfRooms
            {
                get { return mNoOfRooms; }
                set { mNoOfRooms = value; }
            }

            private int mGuaranteedRooms;
            public int GuaranteedRooms
            {
                get { return mGuaranteedRooms; }
                set { mGuaranteedRooms = value; }
            }

            private int mBlockedRooms;
            public int BlockedRooms
            {
                get { return mBlockedRooms; }
                set { mBlockedRooms = value; }
            }

            private int mNoOfPullOut;
            public int NumberOfPullOut
            {
                get { return mNoOfPullOut; }
                set { mNoOfPullOut = value; }
            }

            private int mNoOfFolding;
            public int NumberOfFolding
            {
                get { return mNoOfFolding; }
                set { mNoOfFolding = value; }
            }

            private int mNoOfMattress;
            public int NumberOfMattress
            {
                get { return mNoOfMattress; }
                set { mNoOfMattress = value; }
            }

            private string mRemarks;
            public string Remarks
            {
                get { return mRemarks; }
                set { mRemarks = value; }
            }

            private int mRoomPax;
            public int RoomPax
            {
                get { return mRoomPax; }
                set { mRoomPax = value; }
            }

            private double mRoomRate;
            public double RoomRate
            {
                get { return mRoomRate; }
                set { mRoomRate = value; }
            }
            //<<
            #endregion
        }
    }
}
