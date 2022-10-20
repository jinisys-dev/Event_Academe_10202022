using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

//added July 2, 2008
//used for the Sales Module
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class EventRoomVenue
        {
            private string mRoomVenue;
            public string RoomVenue
            {
                get { return mRoomVenue; }
                set { mRoomVenue = value; }
            }

            private DateTime mFromDate;
            public DateTime FromDate
            {
                get { return mFromDate; }
                set { mFromDate = value; }
            }

            private DateTime mToDate;
            public DateTime ToDate
            {
                get { return mToDate; }
                set { mToDate = value; }
            }

            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
            }
        }
    }
}
