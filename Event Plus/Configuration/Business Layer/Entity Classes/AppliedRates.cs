using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class AppliedRates
    {
        private int mAppliedRateID;
        public int AppliedRateID
        {
            get { return mAppliedRateID; }
            set { mAppliedRateID = value; }
        }

        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        private int mNoOfOccupants;
        public int NumberOfOccupants
        {
            get { return mNoOfOccupants; }
            set { mNoOfOccupants = value; }
        }

        private string mRateType;
        public string RateType
        {
            get { return mRateType; }
            set { mRateType = value; }
        }
    }
}
