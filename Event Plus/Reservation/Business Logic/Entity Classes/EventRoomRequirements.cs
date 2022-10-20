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
        public class EventRoomRequirements
        {
            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
            }
            
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

            private string mRemarks;
            public string Remarks
            {
                get { return mRemarks; }
                set { mRemarks = value; }
            }

            private string mRoomVenue;
            public string RoomVenue
            {
                get { return mRoomVenue; }
                set { mRoomVenue = value; }
            }
        }
    }
}