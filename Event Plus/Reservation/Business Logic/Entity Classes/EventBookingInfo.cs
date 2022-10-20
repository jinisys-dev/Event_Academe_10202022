using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
//added Apr. 24, 2008
//used for the Sales Module
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class EventBookingInfo : DataSet
        {
            public EventBookingInfo()
            { }

            #region "Global"
            //>>
            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
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
            //<<
            #endregion

            #region "Booking Information"
            //>>
            private string mEventName;
            public string EventName
            {
                get { return mEventName; }
                set { mEventName = GlobalFunctions.removeQuotes(value); }
            }

            private string mEventType;
            public string EventType
            {
                get { return mEventType; }
                set { mEventType = GlobalFunctions.removeQuotes(value); }
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

            private string mRoomAssigned;
            public string RoomAssigned
            {
                get { return mRoomAssigned; }
                set { mRoomAssigned = value; }
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

            private int mNoOfPaxGuaranteed;
            public int NumberOfPaxGuaranteed
            {
                get { return mNoOfPaxGuaranteed; }
                set { mNoOfPaxGuaranteed = value; }
            }

            private string mStartEventTime;
            public string StartEventTime
            {
                get { return mStartEventTime; }
                set { mStartEventTime = value; }
            }

            private string mEndEventTime;
            public string EndEventTime
            {
                get { return mEndEventTime; }
                set { mEndEventTime = value; }
            }

            private string mBillingArrangement;
            public string BillingArrangement
            {
                get { return mBillingArrangement; }
                set { mBillingArrangement = value; }
            }

            private string mAuthorizedSignatory;
            public string AuthorizedSignatory
            {
                get { return mAuthorizedSignatory; }
                set { mAuthorizedSignatory = value; }
            }

            private string mLobbyPosting;
            public string LobbyPosting
            {
                get { return mLobbyPosting; }
                set { mLobbyPosting = value; }
            }

            private string mSource;
            public string Source
            {
                get { return mSource; }
                set { mSource = value; }
            }

            private int mEventPackage;
            public int EventPackage
            {
                get { return mEventPackage; }
                set { mEventPackage = value; }
            }

            private decimal mPackageAmount;
            public decimal PackageAmount
            {
                get { return mPackageAmount; }
                set { mPackageAmount = value; }
            }

            private string mRoomVenue;
            public string RoomVenue
            {
                get { return mRoomVenue; }
                set { mRoomVenue = value; }
            }

            private string mContactPerson;
            public string ContactPerson
            {
                get { return mContactPerson; }
                set { mContactPerson = value; }
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

            private string mContactPosition;
            public string ContactPosition
            {
                get { return mContactPosition; }
                set { mContactPosition = value; }
            }

            private decimal mEstimatedTotalCost;
            public decimal EstimatedTotalCost
            {
                get { return mEstimatedTotalCost; }
                set { mEstimatedTotalCost = value; }
            }

            private string mMobileNumber;
            public string MobileNumber
            {
                get { return mMobileNumber; }
                set { mMobileNumber = value; }
            }

            private string mFaxNumber;
            public string FaxNumber
            {
                get { return mFaxNumber; }
                set { mFaxNumber = value; }
            }

            private int mPackagePosted;
            public int PackagePosted
            {
                get { return mPackagePosted; }
                set { mPackagePosted = value; }
            }

            private string mEmailAdd;
            public string EmailAddress
            {
                get { return mEmailAdd; }
                set { mEmailAdd = value; }
            }

            private string mEventOrganizer;
            public string EventOrganizer
            {
                get { return mEventOrganizer; }
                set { mEventOrganizer = value; }
            }

            //<<Booking Info
            #endregion
        }
    }
}
