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
		
		public class User : DataSet
		{
			
			
			public User()
			{
			}
			
			private string mUserId;
			public string UserId
			{
				get
				{
					return mUserId;
				}
				set
				{
					mUserId = value;
				}
			}
			
			private string mPassword;
			public string Password
			{
				get
				{
					return mPassword;
				}
				set
				{
					mPassword = value;
				}
			}
			
			private string mEmployeeIdNo;
			public string EmployeeIdNo
			{
				get
				{
					return mEmployeeIdNo;
				}
				set
				{
					mEmployeeIdNo = value;
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
			
			private string mDepartment;
			public string Department
			{
				get
				{
					return mDepartment;
				}
				set
				{
					mDepartment = value;
				}
			}
			
			private string mHotelId;
			public string HotelId
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

            private DateTime mLoggedTime;
            public DateTime LoggedTime
            {
                get
                {
                    return mLoggedTime;
                }
                set
                {
                    mLoggedTime = value;
                }
            }
			
			private bool mAuthenticated;
			public bool Authenticated
			{
				get
				{
					return mAuthenticated;
				}
				set
				{
					mAuthenticated = value;
				}
			}
			
			
			private string mDesignation;
			public string Designation
			{
				get
				{
					return mDesignation;
				}
				set
				{
					mDesignation = value;
				}
			}
			
			private RoleCollection mRoles;
			public RoleCollection Roles
			{
				get
				{
					return mRoles;
				}
				set
				{
					mRoles = value;
				}
			}

			
		}
		
	}
}
