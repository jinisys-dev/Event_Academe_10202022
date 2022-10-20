using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class RoomType : DataSet
		{
			
			
			public RoomType()
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
			private int mMaxOccupants;
			public int MaxOccupants
			{
				get
				{
					return mMaxOccupants;
				}
				set
				{
					mMaxOccupants = value;
				}
				
			}
			private int mNoOfBeds;
			public int NoOfBeds
			{
				get
				{
					return mNoOfBeds;
				}
				set
				{
					mNoOfBeds = value;
				}
				
			}
			private int mNoofAdult;
			public int NoofAdult
			{
				get
				{
					return mNoofAdult;
				}
				set
				{
					mNoofAdult = value;
				}
			}
			private int mNoofChild;
			public int NoofChild
			{
				get
				{
					return mNoofChild;
				}
				set
				{
					mNoofChild = value;
				}
			}
			private string mShareType;
			public string ShareType
			{
				get
				{
					return mShareType;
				}
				set
				{
					mShareType = value;
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

            /* FP-SCR-00139 #2 [07.20.2010]
             * add additional field to get the room's super type */
            private string mRoomSuperType;
            public string RoomSuperType
            {
                get { return mRoomSuperType; }
                set { mRoomSuperType = value; }
            }
		}
	}
}
