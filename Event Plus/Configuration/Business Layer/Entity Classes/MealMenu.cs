using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace BusinessLayer
    {
        public class MealMenu
        {
            #region "Meal Menu"
            private string mMenuID;
            public string MenuID
            {
                get { return mMenuID; }
                set { mMenuID = value; }
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

            private double mPrice;
            public double Price
            {
                get { return mPrice; }
                set { mPrice = value; }
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
            #endregion

            #region "Meal Menu Details"
            private double mQuantity;
            public double Quantity
            {
                get { return mQuantity; }
                set { mQuantity = value; }
            }
            #endregion

            #region "Meal Items"
            private string mMenuItemID;
            public string MealMenuItemID
            {
                get { return mMenuItemID; }
                set { mMenuItemID = value; }
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
            #endregion

            #region "Meal Groups"
            private int mGroupID;
            public int GroupID
            {
                get { return mGroupID; }
                set { mGroupID = value; }
            }

			private string mMainGroupId;
			public string MainGroupId
			{
				get { return this.mMainGroupId; }
				set { this.mMainGroupId = value; }
			}
            #endregion
        }
    }
}