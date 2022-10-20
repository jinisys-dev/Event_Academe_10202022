using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class Reservations : DataSet
		{
			
			public Reservations()
			{
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
			
			private string mRoomType;
			public string RoomType
			{
				get
				{
					return mRoomType;
				}
				set
				{
					mRoomType = value;
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
			
			private string mEventType;
			public string EventyType
			{
				get
				{
					return mEventType;
				}
				set
				{
					mEventType = value;
				}
			}
			
			private string mAccountType;
			public string AccountType
			{
				get
				{
					return mAccountType;
				}
				set
				{
					mAccountType = value;
				}
			}
			
			private string mStatus;
			public string Status
			{
				get
				{
					return mStatus;
				}
				set
				{
					mStatus = value;
				}
			}
		}
	}
	
	
}
