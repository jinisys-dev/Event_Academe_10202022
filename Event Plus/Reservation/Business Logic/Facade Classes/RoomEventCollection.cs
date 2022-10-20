using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class RoomEventCollection : CollectionBase
		{
			
			public RoomEventCollection()
			{
			}
			public void Add(RoomEvents RoomEvent)
			{
				this.List.Add(RoomEvent);
			}
			public void Remove(RoomEvents RoomEvent)
			{
				this.List.Remove(RoomEvent);
			}
			public RoomEvents Item(int index)
			{
				if (index <= this.List.Count - 1)
				{
					if (index >= 0)
					{
						return (RoomEvents)this.List[index];
					}
				}
				return null;
			}
			
			public RoomEvents LastItem
			{
				get
				{
					if (this.List.Count > 0)
					{
						return (RoomEvents)this.List[this.List.Count - 1];
					}
					else
					{
						return null;
					}
				}
			}
			
			public void Merge(RoomEventCollection RoomEventColl)
			{
				RoomEvents roomEvent;
				foreach (RoomEvents tempLoopVar_roomEvent in RoomEventColl)
				{
					roomEvent = tempLoopVar_roomEvent;
					roomEvent.EventType = RoomEventColl.EventType;
					this.List.Add(roomEvent);
				}
			}
			private DateTime mFromDate;
			public DateTime FromDate
			{
				get
				{
					return mFromDate;
				}
				set
				{
					mFromDate = value;
				}
			}
			private DateTime mToDate;
			public DateTime ToDate
			{
				get
				{
					return mToDate;
				}
				set
				{
					mToDate = value;
				}
			}
			private string mEventType;
			public string EventType
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
			private string mEventOwner;
			public string EventOwner
			{
				get
				{
					return mEventOwner;
				}
				set
				{
					mEventOwner = value;
				}
			}

			private string mTransferFlag;
			public string TransferFlag
			{
				get
				{
					return mTransferFlag;
				}
				set
				{
					mTransferFlag = value;
				}
			}


			private string mStartTime;
			public string StartTime
			{
				set { this.mStartTime = value; }
				get { return this.mStartTime; }
			}


			private string mEndTime;
			public string EndTime
			{
				set { this.mEndTime = value; }
				get { return this.mEndTime; }
			}

			private string mRoomType;
			public string RoomType
			{
				set { this.mRoomType = value; }
				get { return this.mRoomType; }
			}

			private string mFolioId;
			public string FolioId
			{
				set { this.mFolioId = value; }
				get { return this.mFolioId; }
			}

		}
	}
}
