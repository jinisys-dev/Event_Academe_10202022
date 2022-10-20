using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Services
{
	namespace BusinessLayer
	{
		public class EngineeringService : DataSet
		{
			
			
			public EngineeringService()
			{
			}
			
			//Private mgHotelId As Integer
			//Public Property gHotelId() As Integer
			//    Get
			//        Return mgHotelId
			//    End Get
			//    Set(ByVal Value As Integer)
			//        mgHotelId = Value
			//    End Set
			//End Property
			private int mEnggServiceID;
			public int EnggServiceID
			{
				get
				{
					return mEnggServiceID;
				}
				set
				{
					mEnggServiceID = value;
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
