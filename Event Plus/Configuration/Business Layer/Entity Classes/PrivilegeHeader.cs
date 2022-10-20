using System.Diagnostics;

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class PrivilegeHeader : DataSet
		{
			
			
			public PrivilegeHeader()
			{
			}
			private string mPrivilegeID;
			public string PrivilegeID
			{
				get
				{
					return this.mPrivilegeID;
				}
				set
				{
					this.mPrivilegeID = value;
				}
			}
			private string mDescription;
			public string Description
			{
				get
				{
					return this.mDescription;
				}
				set
				{
					this.mDescription = value;
				}
			}
			private DateTime mFromDate;
			public DateTime FromDate
			{
				get
				{
					return this.mFromDate;
				}
				set
				{
					this.mFromDate = value;
				}
			}
			private DateTime mToDate;
			public DateTime ToDate
			{
				get
				{
					return this.mToDate;
				}
				set
				{
					this.mToDate = value;
				}
			}
			private string mDaysApplied;
			public string DaysApplied
			{
				get
				{
					return this.mDaysApplied;
				}
				set
				{
					this.mDaysApplied = value;
				}
			}
			private string mstateFlag;
			public string stateFlag
			{
				get
				{
					return this.mstateFlag;
				}
				set
				{
					this.mstateFlag = value;
				}
			}
			private int mHotelID;
			public int HotelID
			{
				get
				{
					return this.mHotelID;
				}
				set
				{
					this.mHotelID = value;
				}
			}
			//private PrivilegeDetailsCollection mPrivilegeDetailsCollection;
			//public PrivilegeDetailsCollection PrivilegeDetails
			//{
			//    get
			//    {
			//        return this.mPrivilegeDetailsCollection;
			//    }
			//    set
			//    {
			//        this.mPrivilegeDetailsCollection = value;
			//    }
			//}


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

			private string mCreatedDate;
			public string CreatedDate
			{
				get
				{
					return mCreatedDate;
				}
				set
				{
					mCreatedDate = value;
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

			private string mUpdatedDate;
			public string UpdatedDate
			{
				get
				{
					return mUpdatedDate;
				}
				set
				{
					mUpdatedDate = value;
				}
			}

			private IList<PrivilegeDetail> mPrivilegeDetails;
			public IList<PrivilegeDetail> PrivilegeDetails
			{
				get
				{
					return this.mPrivilegeDetails;
				}
				set
				{
					this.mPrivilegeDetails = value;
				}
			}

		}

	}
	
}
