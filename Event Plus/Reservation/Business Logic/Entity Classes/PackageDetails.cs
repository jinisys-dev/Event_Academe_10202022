using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

//Imports Jinisys.Hotel.Cashier.BusinessLayer
namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class PackageDetails : DataSet
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
		}
	}
}
