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
		public class RecurringCharge : DataSet
		{

			public RecurringCharge()
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
			private string mTransactionCode;
			public string TransactionCode
			{
				get
				{
					return mTransactionCode;
				}
				set
				{
					mTransactionCode = value;
				}
			}
			private string mCharge;
			public string Charge
			{
				get
				{
					return mCharge;
				}
				set
				{
					mCharge = value;
				}
			}
			private string mMemo;
			public string Memo
			{
				get
				{
					return mMemo;
				}
				set
				{
                    mMemo = GlobalFunctions.removeQuotes(value);
				}
			}
			private DateTime mFromDate;
			public DateTime FromDate
			{
				get
				{
					return mFromDate;
				}
				set
				{
					mFromDate = value;
				}
			}

			private DateTime mToDate;
			public DateTime ToDate
			{
				get
				{
					return mToDate;
				}
				set
				{
					mToDate = value;
				}
			}
			private decimal mAmount;
			public decimal Amount
			{
				get
				{
					return mAmount;
				}
				set
				{
					mAmount = value;
				}
			}
			//===================================================
			// newly added entities

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

			private int mSummaryFlag;
			public int SummaryFlag
			{
				set { this.mSummaryFlag = value; }
				get { return this.mSummaryFlag; }

			}

            private int mPackageID;
            public int PackageID
            {
                set { mPackageID = value; }
                get { return mPackageID; }
            }

            private string mSubAccount;
            public string SubAccount
            {
                get { return mSubAccount; }
                set { mSubAccount = value; }
            }

            //added for room schedule
            private string mRoomID;
            public string RoomID
            {
                get { return mRoomID; }
                set { mRoomID = value; }
            }

            private int mQtyHrs;
            public int QtyHrs
            {
                get { return mQtyHrs; }
                set { mQtyHrs = value; }
            }

            private decimal mDiscount;
            public decimal Discount
            {
                get { return mDiscount; }
                set { mDiscount = value; }
            }

            private string mRateType;
            public string RateType
            {
                get { return mRateType; }
                set { mRateType = value; }
            }

            private decimal mBaseAmount;
            public decimal BaseAmount
            {
                get { return mBaseAmount; }
                set { mBaseAmount = value; }
            }

            private decimal mTax;
            public decimal Tax
            {
                get { return mTax;  }
                set { mTax = value; }
            }
		}
	}
}
