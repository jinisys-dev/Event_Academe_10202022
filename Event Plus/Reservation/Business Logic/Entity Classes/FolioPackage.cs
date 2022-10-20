using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
//Imports Jinisys.Hotel.Cashier.BusinessLayer
namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class FolioPackage : DataSet
		{
			
			
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
			
			private string mbasis;
			public string Basis
			{
				get
				{
					return mbasis;
				}
				set
				{
					mbasis = value;
				}
			}
			private string mDaysApplied;
			public string DaysApplied
			{
				get
				{
					return mDaysApplied;
				}
				set
				{
					mDaysApplied = value;
				}
			}
			private decimal mPercentOff;
			public decimal PercentOff
			{
				get
				{
					return mPercentOff;
				}
				set
				{
					mPercentOff = value;
				}
			}
			
			private decimal mAmountOff;
			public decimal AmountOff
			{
				get
				{
					return mAmountOff;
				}
				set
				{
					mAmountOff = value;
				}
			}
			
			private string mPackageID;
			public string PackageID
			{
				get
				{
					return mPackageID;
				}
				set
				{
					mPackageID = value;
				}
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

            private DateTime mDateFrom;
            public DateTime DateFrom
            {
                get { return mDateFrom; }
                set { mDateFrom = value; }
            }

            private DateTime mDateTo;
            public DateTime DateTo
            {
                get { return mDateTo; }
                set { mDateTo = value; }
            }
		}
	}
}
