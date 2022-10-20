using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Services
{
	namespace BusinessLayer
	{
		public class HousekeepingJob : DataSet
		{


			public HousekeepingJob()
			{
			}


			private int mHousekeepingJobNo;
			public int HousekeepingJobNo
			{
				get { return this.mHousekeepingJobNo; }
				set { this.mHousekeepingJobNo = value; }
			}

			private DateTime mHousekeepingDate;
			public DateTime HousekeepingDate
			{
				get { return this.mHousekeepingDate; }
				set { this.mHousekeepingDate = value; }
			}

			private string mHousekeeperId;
			public string HousekeeperId
			{
				get { return this.mHousekeeperId; }
				set { this.mHousekeeperId = value; }
			}

			private string mHousekeepingType;
			public string HousekeepingType
			{
				get { return this.mHousekeepingType; }
				set { this.mHousekeepingType = value; }
			}

			private string mRoomId;
			public string RoomId
			{
				get { return this.mRoomId; }
				set { this.mRoomId = value; }
			}

			private DateTime mStartTime;
			public DateTime StartTime
			{
				get { return this.mStartTime; }
				set { this.mStartTime = value; }
			}

			private DateTime mEndTime;
			public DateTime EndTime
			{
				get { return this.mEndTime; }
				set { this.mEndTime = value; }
			}

			private string mElapsedTime;
			public string ElapsedTime
			{
				get { return this.mElapsedTime; }
			}

			private string mRemarks;
			public string Remarks
			{
				get { return this.mRemarks; }
				set { this.mRemarks = value; }
			}

			private int mIsFinished;
			public int IsFinished
			{
				get { return this.mIsFinished; }
				set { this.mIsFinished = value; }
			}

			private string mVerifiedBy;
			public string VerifiedBy
			{
				get { return this.mVerifiedBy; }
				set { this.mVerifiedBy = value; }
			}

			private DateTime mTimeVerified;
			public DateTime TimeVerified
			{
				get { return this.mTimeVerified; }
				set { this.mTimeVerified = value; }
			}

			private int mHotelId;
			public int HotelId
			{
				get { return this.mHotelId; }
				set { this.mHotelId = value; }
			}

			private DateTime mCreateTime;
			public DateTime CreateTime
			{
				get { return this.mCreateTime; }
				set { this.mCreateTime = value; }
			}

			private string mCreatedBy;
			public string CreatedBy
			{
				get { return this.mCreatedBy; }
				set { this.mCreatedBy = value; }
			}

			private DateTime mUpdateTime;
			public DateTime UpdateTime
			{
				get { return this.mUpdateTime; }
				set { this.mUpdateTime = value; }
			}

			private string mUpdatedBy;
			public string UpdatedBy
			{
				get { return this.mUpdatedBy; }
				set { this.mUpdatedBy = value; }
			}

			private string mStateFlag;
			public string StateFlag
			{
				get { return this.mStateFlag; }
				set { this.mStateFlag = value; }
			}


		}
	}
}
