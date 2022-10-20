using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		public class Role : DataSet
		{
			
			
			public Role()
			{
			}
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
			
			private MenuCollection mMenus;
			public MenuCollection Menus
			{
				get
				{
					return mMenus;
				}
				set
				{
					mMenus = value;
				}
			}
			
            private IList<Role_Privilege> mPrivileges;
            public IList<Role_Privilege> Privileges
            {
                set { mPrivileges = value; }
                get { return mPrivileges; }
            }

			private IList<RoleUIPrivilege> mRoleUIPrivileges = new List<RoleUIPrivilege>();
			public IList<RoleUIPrivilege> RoleUIPrivileges
			{
				set { this.mRoleUIPrivileges = value; }
				get { return this.mRoleUIPrivileges; }
			}

		}
	}
}
