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
        public class EventDetails
        {
            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
            }

            private string mEventDetailHeader;
            public string EventDetailHeader
            {
                get { return mEventDetailHeader; }
                set { mEventDetailHeader = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = value; }
            }
        }
    }
}
