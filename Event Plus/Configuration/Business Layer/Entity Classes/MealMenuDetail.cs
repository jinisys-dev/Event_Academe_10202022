using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Configuration
{
    namespace BusinessLayer
    {
        public class MealMenuDetail
        {
            private int mMenuID;
            public int MealMenuID
            {
                get { return mMenuID; }
                set { mMenuID = value; }
            }

            private int mItemID;
            public int MealItemID
            {
                get { return mItemID; }
                set { mItemID = value; }
            }

            private double mQuantity;
            public double Quantity
            {
                get { return mQuantity; }
                set { mQuantity = value; }
            }
        }
    }
}