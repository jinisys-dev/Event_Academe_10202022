using System.Diagnostics;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
		public class CurrencyCode : DataSet
		{
			
			
			public CurrencyCode()
			{ }

			private string mCurrencyCode;
			public string CurCode
			{
				get
				{
					return this.mCurrencyCode;
				}
				set
				{
					this.mCurrencyCode = value;
				}
			}
			private string mCurrency;
			public string Currency
			{
				get
				{
					return this.mCurrency;
				}
				set
				{
					this.mCurrency = value;
				}
			}
			private decimal mConversionRate;
			public decimal ConversionRate
			{
				get
				{
					return this.mConversionRate;
				}
				set
				{
					this.mConversionRate = value;
				}
			}
			
			private int mgHotelId;
			public int HotelID
			{
				get
				{
					return mgHotelId;
				}
				set
				{
					mgHotelId = value;
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

		}
}
