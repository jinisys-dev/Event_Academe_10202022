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
        public class EventFoodRequirements
        {
            #region "Event Meal Requirements "
            private int mFoodReqID;
            public int FoodRequirementID
            {
                get { return mFoodReqID; }
                set { mFoodReqID = value; }
            }

            private string mFolioID;
            public string FolioID
            {
                get { return mFolioID; }
                set { mFolioID = value; }
            }

            private DateTime mEventDate;
            public DateTime EventDate
            {
                get { return mEventDate; }
                set { mEventDate = value; }
            }

            private string mVenue;
            public string Venue
            {
                get { return mVenue; }
                set { mVenue = value; }
            }

            private int mPax;
            public int Pax
            {
                get { return mPax; }
                set { mPax = value; }
            }

            private string mStartTime;
            public string StartTime
            {
                get { return mStartTime; }
                set { mStartTime = value; }
            }

            private string mEndTime;
            public string EndTime
            {
                get { return mEndTime; }
                set { mEndTime = value; }
            }

            private string mOver;
            public string Over
            {
                get { return mOver; }
                set { mOver = value; }
            }

            private string mRemarks;
            public string Remarks
            {
                get { return mRemarks; }
                set { mRemarks = value; }
            }

            private string mSetup;
            public string Setup
            {
                get { return mSetup; }
                set { mSetup = value; }
            }

            private decimal mTotalMealCost;
            public decimal TotalMealCost
            {
                get { return mTotalMealCost; }
                set { mTotalMealCost = value; }
            }

            #endregion



            #region "Event Meal Details"

            private string mMenuCode;
            public string MenuCode
            {
                get { return mMenuCode; }
                set { mMenuCode = value; }
            }

            private string mMenuItemCode;
            public string MenuItemCode
            {
                get { return mMenuItemCode; }
                set { mMenuItemCode = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = GlobalFunctions.removeQuotes(value); }
            }

            private decimal mPrice;
            public decimal Price
            {
                get { return mPrice; }
                set { mPrice = value; }
            }

            #endregion



            #region "Meal Header"
            private int mMealID;
            public int MealID
            {
                get { return mMealID; }
                set { mMealID = value; }
            }

            private string mMealType;
            public string MealType
            {
                get { return mMealType; }
                set { mMealType = value; }
            }

            private string mReadyTime;
            public string ReadyTime
            {
                get { return mReadyTime; }
                set { mReadyTime = value; }
            }

            private string mDeliveryTime;
            public string DeliveryTime
            {
                get { return mDeliveryTime; }
                set { mDeliveryTime = value; }
            }

            private decimal mMealCost;
            public decimal MealCost
            {
                get { return mMealCost; }
                set { mMealCost = value; }
            }

            private int mPaxLiveIn;
            public int PaxLiveIn
            {
                get { return mPaxLiveIn; }
                set { mPaxLiveIn = value; }
            }

            private int mPaxLiveOut;
            public int PaxLiveOut
            {
                get { return mPaxLiveOut; }
                set { mPaxLiveOut = value; }
            }
            #endregion
        }
    }
}
