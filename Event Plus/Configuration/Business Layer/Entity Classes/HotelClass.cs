using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class HotelClass : DataSet
	{


		public HotelClass()
		{
		}
		private string mHotelID;
		public string HotelID
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
		private string mHotelName;
		public string HotelName
		{
			get
			{
				return this.mHotelName;
			}
			set
			{
				this.mHotelName = value;
			}
		}
		private int mNoOfFloors;
		public int NoOfFloors
		{
			get
			{
				return this.mNoOfFloors;
			}
			set
			{
				this.mNoOfFloors = value;
			}
		}
		private int mNoOfRooms;
		public int NoOfRooms
		{
			get
			{
				return this.mNoOfRooms;
			}
			set
			{
				this.mNoOfRooms = value;
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

		public string mCheckInTime;
		public string CheckInTime
		{
			get
			{
				return this.mCheckInTime;
			}
			set
			{
				this.mCheckInTime = value;
			}
		}



		public string mCheckOutTime;
		public string CheckOutTime
		{
			get
			{
				return this.mCheckOutTime;
			}
			set
			{
				this.mCheckOutTime = value;
			}
		}


	}
}