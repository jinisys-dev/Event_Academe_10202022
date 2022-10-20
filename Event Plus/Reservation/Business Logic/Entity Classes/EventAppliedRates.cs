using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

//added by Genny - May 9, 2008
//used for the Sales Module
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class EventAppliedRates
        {
            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
            }

            private string mRateType;
            public string RateType
            {
                get { return mRateType; }
                set { mRateType = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = value; }
            }

            private decimal mRateAmount;
            public decimal RateAmount
            {
                get { return mRateAmount; }
                set { mRateAmount = value; }
            }

            private int mNoOfOccupants;
            public int NumberOfOccupants
            {
                get { return mNoOfOccupants; }
                set { mNoOfOccupants = value; }
            }
        }
    }
}
