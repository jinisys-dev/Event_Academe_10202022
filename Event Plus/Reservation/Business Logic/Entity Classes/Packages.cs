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
		public class Packages : DataSet
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
			private string mDescription;
			public string Description
			{
				get
				{
					return mDescription;
				}
				set
				{
					mDescription = value;
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
			private DateTime mTODate;
			public DateTime Todate
			{
				get
				{
					return mTODate;
				}
				set
				{
					mTODate = value;
				}
			}
		}
	}
}
