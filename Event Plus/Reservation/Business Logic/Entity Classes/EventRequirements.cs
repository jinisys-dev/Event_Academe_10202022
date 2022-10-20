using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
//added by Genny - Apr. 25, 2008
//used for the Sales Module
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class EventRequirements
        {
            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
            }

            private string mRequirementCode;
            public string RequirementCode
            {
                get { return mRequirementCode; }
                set { mRequirementCode = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = GlobalFunctions.removeQuotes(value); }
            }

            private string mRemarks;
            public string Remarks
            {
                get { return mRemarks; }
                set { mRemarks = GlobalFunctions.removeQuotes(value); }
            }

            private DateTime mEventDate;
            public DateTime EventDate
            {
                get { return mEventDate; }
                set { mEventDate = value; }
            }
        }
    }
}
