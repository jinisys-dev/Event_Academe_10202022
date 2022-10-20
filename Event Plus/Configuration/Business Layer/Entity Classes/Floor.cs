using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class Floor : DataSet
		{
			
			
			public Floor()
			{
			}
			
			private string mFloor;
			public string FloorName
			{
				get
				{
					return mFloor;
				}
				set
				{
					mFloor = value;
				}
			}
			
			private string mFloorLayoutImage;
			public string FloorLayoutImage
			{
				get
				{
					return mFloorLayoutImage;
				}
				set
				{
					mFloorLayoutImage = value;
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
