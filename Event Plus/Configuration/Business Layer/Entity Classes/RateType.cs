using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class RateType : DataSet
		{
			
			public RateType()
			{
			}
			
			private string mRoomTypeCode;
			public string RoomTypeCode
			{
				get
				{
					return mRoomTypeCode;
				}
				set
				{
					mRoomTypeCode = value;
				}
			}
            private string mRoomID;
            public string RoomID
            {
                get
                {
                    return mRoomID;
                }
                set
                {
                    mRoomID = value;
                }
            }
			private string mRateCode;
			public string RateCode
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
			private decimal mRateAmount;
			public decimal RateAmount
			{
				get
				{
					return mRateAmount;
				}
				set
				{
					mRateAmount = value;
				}
			}
			private string mStatusFlag;
			public string StatusFlag
			{
				get
				{
					return mStatusFlag;
				}
				set
				{
					mStatusFlag = value;
				}
			}
			//===================================================
			// newly added entities
			//===================================================
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

			private string mHasBreakfast;
			public string HasBreakfast
			{
				get
				{
					return mHasBreakfast;
				}
				set
				{
					mHasBreakfast = value;
				}
			}

			private decimal mBreakfastAmount;
			public decimal BreakfastAmount
			{
				get
				{
					return mBreakfastAmount;
				}
				set
				{
					mBreakfastAmount = value;
				}
			}
		}
	}
}
