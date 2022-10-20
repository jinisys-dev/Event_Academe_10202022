using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		
		
		public class RoleMenu
		{
			
			private string mRoleName;
			public string RoleName
			{
				get
				{
					return mRoleName;
				}
				set
				{
					mRoleName = value;
				}
			}

			private string mMenu;
			public string Menu
			{
				get
				{
					return mMenu;
				}
				set
				{
					mMenu = value;
				}
			}

			private bool mEnable;
			public bool IsEnable
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

			private RoleMenuCollection mRoleMenuCollection;
			public RoleMenuCollection RoleMenuCollection
			{
				get
				{
					return mRoleMenuCollection;
				}
				set
				{
					mRoleMenuCollection = value;
				}
			}

		}
	}
}
