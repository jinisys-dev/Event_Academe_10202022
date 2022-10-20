using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Security
{
    namespace BusinessLayer
    {
        public class Role_Privilege
        {

            public Role_Privilege()
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

            private string mPrivilege;
            public string Privilege
            {
                get
                {
                    return mPrivilege;
                }
                set
                {
                    mPrivilege = value;
                }
            }

			private int mAllowed;
			public int Allowed
			{
				get
				{
					return mAllowed;
				}
				set
				{
					mAllowed = value;
				}
			}
        }
    }
}
