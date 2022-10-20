using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.Reservation
{
    namespace BusinessLayer
    {
        public class FolioInclusions : DataSet
        {

            public FolioInclusions()
            {
            }

            private int mHotelId;
            public int HotelID
            {
                get
                {
                    return mHotelId;
                }
                set
                {
                    mHotelId = value;
                }
            }

            private string mFolioID;
            public string FolioID
            {
                get
                {
                    return mFolioID;
                }
                set
                {
                    mFolioID = value;
                }
            }

            private string mMemo;
            public string Memo
            {
                get { return mMemo; }
                set { mMemo = GlobalFunctions.removeQuotes(value); }
            }

            private DateTime mCreateTime;
            public DateTime CreateTime
            {
                get
                {
                    return mCreateTime;
                }
                set
                {
                    mCreateTime = value;
                }
            }

            private string mCreatedBy;
            public string CreatedBy
            {
                get
                {
                    return mCreatedBy;
                }
                set
                {
                    mCreatedBy = value;
                }
            }

            private DateTime mUpdateTime;
            public DateTime UpdateTime
            {
                get
                {
                    return mUpdateTime;
                }
                set
                {
                    mUpdateTime = value;
                }
            }

            private string mUpdatedBy;
            public string UpdatedBy
            {
                get
                {
                    return mUpdatedBy;
                }
                set
                {
                    mUpdatedBy = value;
                }
            }
        }
    }
}
