using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class PackageDetail
		{
			
			private string mPackageID;
			public string PackageID
			{
				get
				{
					return this.mPackageID;
				}
				set
				{
					this.mPackageID = value;
				}
			}
			private string mTransactionCode;
			public string TransactionCode
			{
				get
				{
					return this.mTransactionCode;
				}
				set
				{
					this.mTransactionCode = value;
				}
			}

			private string mMemo;
			public string Memo
			{
				get
				{
					return this.mMemo;
				}
				set
				{
					this.mMemo = value;
				}
			}

			private string mBasis;
			public string Basis
			{
				get
				{
					return this.mBasis;
				}
				set
				{
					this.mBasis = value;
				}
			}
			private decimal mPercentOff;
			public decimal PercentOff
			{
				get
				{
					return this.mPercentOff;
				}
				set
				{
					this.mPercentOff = value;
				}
			}
			private decimal mAmountOff;
			public decimal AmountOff
			{
				get
				{
					return this.mAmountOff;
				}
				set
				{
					this.mAmountOff = value;
				}
			}
			private int mHotelID;
			public int HotelID
			{
				get
				{
					return this.mHotelID;
				}
				set
				{
					this.mHotelID = value;
				}
			}
			private DateTime mCreateTime;
			public DateTime CreateTime
			{
				get
				{
					return this.mCreateTime;
				}
				set
				{
					this.mCreateTime = value;
				}
			}
			private string mCreatedBy;
			public string CreatedBy
			{
				get
				{
					return this.mCreatedBy;
				}
				set
				{
					this.mCreatedBy = value;
				}
			}
			private string mUpdatedby;
			public string Updatedby
			{
				get
				{
					return this.mUpdatedby;
				}
				set
				{
					this.mUpdatedby = value;
				}
			}
			private DateTime mUpdateTime;
			public DateTime UpdateTime
			{
				get
				{
					return this.mUpdateTime;
				}
				set
				{
					this.mUpdateTime = value;
				}
			}
		}
	}
}
