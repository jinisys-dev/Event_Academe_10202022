using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Configuration
{
    namespace BusinessLayer
    {
        public class MealMenuItem
        {
            private int mMenuItemID;
            public int MealMenuItemID
            {
                get { return mMenuItemID; }
                set { mMenuItemID = value; }
            }

            private int mMealGroupID;
            public int MealGroupID
            {
                get { return mMealGroupID; }
                set { mMealGroupID = value; }
            }

            private string mDescription;
            public string Description
            {
                get { return mDescription; }
                set { mDescription = value; }
            }

            private string mStatus;
            public string Status
            {
                get { return mStatus; }
                set { mStatus = value; }
            }

            private string mUnit;
            public string Unit
            {
                get { return mUnit; }
                set { mUnit = value; }
            }

            private double mUnitCost;
            public double UnitCost
            {
                get { return mUnitCost; }
                set { mUnitCost = value; }
            }

            private double mSellingPrice;
            public double SellingPrice
            {
                get { return mSellingPrice; }
                set { mSellingPrice = value; }
            }

            private double mVat;
            public double Vat
            {
                get { return mVat; }
                set { mVat = value; }
            }

            private double mServiceCharge;
            public double ServiceCharge
            {
                get { return mServiceCharge; }
                set { mServiceCharge = value; }
            }
        }
    }
}