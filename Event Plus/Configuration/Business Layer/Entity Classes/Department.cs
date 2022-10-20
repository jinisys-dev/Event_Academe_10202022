using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class Department : DataSet
		{
			
			
			public Department()
			{
			}
			private string mdeptId;
			public string DepartmentID
			{
				get
				{
					return this.mdeptId;
				}
				set
				{
					this.mdeptId = value;
				}
			}
			private string mName;
			public string Name
			{
				get
				{
					return this.mName;
				}
				set
				{
					this.mName = value;
				}
			}
			private int mgHotelId;
			public int gHotelId
			{
				get
				{
					return this.mgHotelId;
				}
				set
				{
					this.mgHotelId = value;
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
			private string mCreatedBy;
			public string CreatedBy
			{
				get
				{
					return this.mCreatedBy;
				}
				set
				{
					this.mCreatedBy = value;
				}
			}
			private DateTime mCreateTime;
			public DateTime CreateTime
			{
				get
				{
					return this.mCreateTime;
				}
				set
				{
					this.mCreateTime = value;
				}
			}
			private string mUpdatedBy;
			public string UpdatedBy
			{
				get
				{
					return this.mUpdatedBy;
				}
				set
				{
					this.mUpdatedBy = value;
				}
			}
			private DateTime mUpdateTime;
			public DateTime UpdateTime
			{
				get
				{
					return this.mUpdateTime;
				}
				set
				{
					this.mUpdateTime = value;
				}
			}
		}
	}
}
