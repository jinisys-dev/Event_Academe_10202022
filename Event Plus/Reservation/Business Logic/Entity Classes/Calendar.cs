using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class Calendar : DataSet
		{
			
			public Calendar()
			{
				
			}
			private int mRoomID;
			public int RoomID
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
			
		}
	}
}
