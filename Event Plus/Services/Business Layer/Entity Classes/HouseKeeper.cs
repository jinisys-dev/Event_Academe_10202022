using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Services
{
	namespace BusinessLayer
	{
		public class HouseKeeper : DataSet
		{
			
			
			public HouseKeeper()
			{
			}
			
			private string mHouseKeeperId;
			public string HouseKeeperId
			{
				get
				{
					return mHouseKeeperId;
				}
				set
				{
					mHouseKeeperId = value;
				}
			}
			private string mLastName;
			public string LastName
			{
				get
				{
					return mLastName;
				}
				set
				{
					mLastName = value;
				}
			}
			private string mFirstName;
			public string FirstName
			{
				get
				{
					return mFirstName;
				}
				set
				{
					mFirstName = value;
				}
			}
			private string mMiddleName;
			public string MiddleName
			{
				get
				{
					return mMiddleName;
				}
				set
				{
					mMiddleName = value;
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
			public int gHotelId
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
