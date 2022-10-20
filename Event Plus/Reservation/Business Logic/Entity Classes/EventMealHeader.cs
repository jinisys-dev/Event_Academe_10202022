using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

//added by Genny - Apr. 25, 2008
//used for the Sales Module
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class EventMealHeader
        {
            private int mMealID;
            public int MealID
            {
                get { return mMealID; }
                set { mMealID = value; }
            }

            private int mFoodReqID;
            public int FoodReqID
            {
                get { return mFoodReqID; }
                set { mFoodReqID = value; }
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
        }
    }
}
