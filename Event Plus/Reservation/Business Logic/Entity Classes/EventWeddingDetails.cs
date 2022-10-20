using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

//added by Genny - Apr. 25, 2008
//for the Sales Module
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class EventWeddingDetails
        {
            private int mEventID;
            public int EventID
            {
                get { return mEventID; }
                set { mEventID = value; }
            }

            private string mGroomName;
            public string GroomName
            {
                get { return mGroomName; }
                set { mGroomName = value; }
            }

            private string mGroomAddress;
            public string GroomAddress
            {
                get { return mGroomAddress; }
                set { mGroomAddress = value; }
            }

            private string mBrideName;
            public string BrideName
            {
                get { return mBrideName; }
                set { mBrideName = value; }
            }

            private string mBrideAddress;
            public string BrideAddress
            {
                get { return mBrideAddress; }
                set { mBrideAddress = value; }
            }

            private int mParents;
            public int Parents
            {
                get { return mParents; }
                set { mParents = value; }
            }

            private int mSponsors;
            public int Sponsors
            {
                get { return mSponsors; }
                set { mSponsors = value; }
            }

            private string mChurch;
            public string Church
            {
                get { return mChurch; }
                set { mChurch = value; }
            }

            private string mChurchAddress;
            public string ChurchAddress
            {
                get { return mChurchAddress; }
                set { mChurchAddress = value; }
            }

            private string mMotif;
            public string Motif
            {
                get { return mMotif; }
                set { mMotif = value; }
            }

            private DateTime mWeddingDate;
            public DateTime WeddingDate
            {
                get { return mWeddingDate; }
                set { mWeddingDate = value; }
            }
        }
    }
}
