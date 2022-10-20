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
        public class EventMealDetails
        {
            private int mMealID;
            public int MealID
            {
                get { return mMealID; }
                set { mMealID = value; }
            }

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

            private string mRemarks;
            public string Remarks
            {
                get { return mRemarks; }
                set { mRemarks = value; }
            }
        }
    }
}
