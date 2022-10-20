using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Configuration
{
    namespace BusinessLayer
    {
        public class MealGroup
        {
            private int mGroupID;
            public int GroupID
            {
                get { return mGroupID; }
                set { mGroupID = value; }
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
        }
    }
}
