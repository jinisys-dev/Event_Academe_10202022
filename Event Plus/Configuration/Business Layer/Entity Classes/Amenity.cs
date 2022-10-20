using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class Amenity : DataSet
		{
			public Amenity()
			{
			}
			
			private string mAmenityID;
			public string AmenityId
			{
				get
				{
					return mAmenityID;
				}
				set
				{
					mAmenityID = value;
				}
			}
			
			private string mName;
			public string Name
			{
				get
				{
					return mName;
				}
				set
				{
					mName = value;
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
