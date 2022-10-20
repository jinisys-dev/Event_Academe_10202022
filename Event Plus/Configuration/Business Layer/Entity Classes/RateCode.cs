using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class RateCode : DataSet
		{
			
			public RateCode()
			{
			}
			
			private string mRateCode;
			public string RateCodeName
			{
				get
				{
					return mRateCode;
				}
				set
				{
					mRateCode = value;
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
                    mDescription = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mStateflag;
			public string Stateflag
			{
				get
				{
					return mStateflag;
				}
				set
				{
					mStateflag = value;
				}
			}
			//===================================================
			// newly added entities
			//===================================================
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
}
