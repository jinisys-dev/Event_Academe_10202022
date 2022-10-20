using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class RoomBlock : DataSet
		{
			
			public RoomBlock()
			{
				
			}
			private int mBlockID;
			public int BlockID
			{
				get
				{
					return mBlockID;
				}
				set
				{
					mBlockID = value;
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
			private DateTime mBlockFrom;
			public DateTime BlockFrom
			{
				get
				{
					return mBlockFrom;
				}
				set
				{
					mBlockFrom = value;
				}
			}
			private DateTime mBlockTo;
			public DateTime BlockTo
			{
				get
				{
					return mBlockTo;
				}
				set
				{
					mBlockTo = value;
				}
			}
			private string mReason;
			public string Reason
			{
				get
				{
					return mReason;
				}
				set
				{
					mReason = value;
				}
			}

			//optional
			private string mFolioID;
			public string FolioID
			{
				get
				{
					return mFolioID;
				}
				set
				{
					mFolioID = value;
				}
			}

		}
	}
	
}
