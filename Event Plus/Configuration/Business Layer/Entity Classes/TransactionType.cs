using System.Diagnostics;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class TransactionType : DataSet
		{
			
			public TransactionType()
			{
			}
			

			private string mTranTypeId;
			public string TranTypeId
			{
				get
				{
					return mTranTypeId;
				}
				set
				{
					mTranTypeId = value;
				}
			}
			
			private string mTranType;
			public string TranType
			{
				get
				{
					return mTranType;
				}
				set
				{
					mTranType = value;
				}
			}
			
			private string mAcctGroup;
			public string AcctGroup
			{
				get
				{
					return mAcctGroup;
				}
				set
				{
					mAcctGroup = value;
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

            private AmenityCollection mAmenities;
            public AmenityCollection Amenities
            {
                get {
                    return mAmenities;
                }
                set {
                    mAmenities = value;
                }
            }


		}
	}
}
