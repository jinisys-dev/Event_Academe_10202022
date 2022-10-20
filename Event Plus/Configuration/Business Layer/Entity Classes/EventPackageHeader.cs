using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class EventPackageHeader
    {
        private int mPackageID;
        public int PackageID
        {
            get { return mPackageID; }
            set { mPackageID = value; }
        }

        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = GlobalFunctions.removeQuotes(value); }
        }

        private int mDaysApplied;
        public int DaysApplied
        {
            get { return mDaysApplied; }
            set { mDaysApplied = value; }
        }

        private string mEventType;
        public string EventType
        {
            get { return mEventType; }
            set { mEventType = value; }
        }

        private double mPackageAmount;
        public double PackageAmount
        {
            get { return mPackageAmount; }
            set { mPackageAmount = value; }
        }

        private int mMinimumPax;
        public int MinimumPax
        {
            get { return mMinimumPax; }
            set { mMinimumPax = value; }
        }

        private int mMaximumPax;
        public int MaximumPax
        {
            get { return mMaximumPax; }
            set { mMaximumPax = value; }
        }
    }
}
