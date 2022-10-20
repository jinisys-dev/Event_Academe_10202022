using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace BusinessLayer
    {
        public class EventType
        {
            public EventType()
            { }

            private string mEventType;
            public string Event_Type
            {
                get { return mEventType; }
                set { mEventType = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = GlobalFunctions.removeQuotes(value); }
            }

            private string mKey;
            public string Key
            {
                get { return mKey; }
                set { mKey = value; }
            }

            private int mEventID;
            public int EventID
            {
                get { return mEventID; }
                set { mEventID = value; }
            }

            private int mBanquetType;
            public int BanquetType
            {
                get { return mBanquetType; }
                set { mBanquetType = value; }
            }
        }
    }
}
