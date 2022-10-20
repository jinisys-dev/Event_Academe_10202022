using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		
		public class SystemMenu : DataSet
		{
			
			
			
			private string mMenuName;
			public string MenuName
			{
				get
				{
					return mMenuName;
				}
				set
				{
					mMenuName = value;
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
			
			
			// >> TrANSFERED PLEASE CHECKK.. [ di ko sure f sakto...]
			private bool mEnable;
			public bool Enable
			{
				get
				{
					return mEnable;
				}
				set
				{
					mEnable = value;
				}
			}

			private int mHotelId;
			public int HotelId
			{
				get
				{
					return mHotelId;
				}
				set
				{
					mHotelId = value;
				}
			}
			
		}
	}
}
