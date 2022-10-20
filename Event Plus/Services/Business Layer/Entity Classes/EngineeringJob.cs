using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Services
{
	namespace BusinessLayer
	{
		public class EngineeringJob : DataSet
		{
			
			
			public EngineeringJob()
			{
			}
			
			private string mEnggJobNo;
			public string EnggJobNo
			{
				get
				{
					return mEnggJobNo;
				}
				set
				{
					mEnggJobNo = value;
				}
			}
			private int mEnggServiceId;
			public int EnggServiceId
			{
				get
				{
					return mEnggServiceId;
				}
				set
				{
					mEnggServiceId = value;
				}
			}
			private string mServiceName;
			public string ServiceName
			{
				get
				{
					return mServiceName;
				}
				set
				{
					mServiceName = value;
				}
			}
			
			private string mAssignedPerson;
			public string AssignedPerson
			{
				get
				{
					return mAssignedPerson;
				}
				set
				{
					mAssignedPerson = value;
				}
			}
			private string mRoomId;
			public string RoomId
			{
				get
				{
					return mRoomId;
				}
				set
				{
					mRoomId = value;
				}
			}
			private string mStartDate;
			public string StartDate
			{
				get
				{
					return mStartDate;
				}
				set
				{
					mStartDate = value;
				}
			}
			private string mEndDate;
			public string EndDate
			{
				get
				{
					return mEndDate;
				}
				set
				{
					mEndDate = value;
				}
			}
			private string mStartTime;
			public string StartTime
			{
				get
				{
					return mStartTime;
				}
				set
				{
					mStartTime = value;
				}
			}
			private string mEndTime;
			public string EndTime
			{
				get
				{
					return mEndTime;
				}
				set
				{
					mEndTime = value;
				}
			}
			private string mStateflag;
			public string State
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
