using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class Schedule : DataSet
		{

            private string mId = "";
            public string Id
            {
                get { return mId; }
                set { mId = value; }
            }
			private int mHotelId;
			public int HotelID
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
			
			private string mFolioID;
			public string FolioID
			{
				get
				{
					return mFolioID;
				}
				set
				{
					mFolioID = value;
				}
			}
			
			private string mRoomID;
			public string RoomID
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
			
			private DateTime mFromDate;
			public DateTime FromDate
			{
				get
				{
					return mFromDate;
				}
				set
				{
					mFromDate = value;
				}
			}
			
			private DateTime mToDate;
			public DateTime ToDate
			{
				get
				{
					return mToDate;
				}
				set
				{
					mToDate = value;
				}
			}
			
			public int Days
			{
				get
				{
					return (DateAndTime.DateDiff(DateInterval.Day, mFromDate, mToDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1 ) == 0) ? 1 : int.Parse(DateAndTime.DateDiff(DateInterval.Day, mFromDate, mToDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1 ).ToString() );
				}
			}
			
			private string mRateType;
			public string RateType
			{
				get
				{
					return mRateType;
				}
				set
				{
					mRateType = value;
				}
			}
			private string mRoomType;
			public string RoomType
			{
				get
				{
					return mRoomType;
				}
				set
				{
					mRoomType = value;
				}
			}
			private decimal mRate;
			public decimal Rate
			{
				get
				{
					return mRate;
				}
				set
				{
					mRate = value;
				}
			}
			
			private string mBreakFast;
			public string BreakFast
			{
				get
				{
					return mBreakFast;
				}
				set
				{
					mBreakFast = value;
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

			// to tracer where folio was created
			private string mTerminalId;
			public string TerminalId
			{
				set { this.mTerminalId = value; }
				get { return this.mTerminalId; }
			}

			private string mShiftCode;
			public string ShiftCode
			{
				set { this.mShiftCode = value; }
				get { return this.mShiftCode; }
			}

			private string mSupervisorId;
			public string SupervisorId
			{
				set { this.mSupervisorId = value; }
				get { return this.mSupervisorId; }
			}

            //for function rooms start and end time
            private DateTime mStartTime;
            public DateTime StartTime
            {
                get { return mStartTime; }
                set { mStartTime = value; }
            }

            private DateTime mEndtime;
            public DateTime EndTime
            {
                get { return mEndtime; }
                set { mEndtime = value; }
            }

            private string mVenue;
            public string Venue
            {
                get { return mVenue; }
                set { mVenue = GlobalFunctions.removeQuotes(value); }
            }

            private string mSetup;
            public string Setup
            {
                get { return mSetup; }
                set { mSetup = GlobalFunctions.removeQuotes(value); }
            }

            private string mRemarks;
            public string Remarks
            {
                get { return mRemarks; }
                set { mRemarks = GlobalFunctions.removeQuotes(value); }
            }

            //added for multiple scheduling of rooms
            //and setting whether room has been transfered or not
            private int mHasTransfered;
            public int HasTransfered
            {
                get { return mHasTransfered; }
                set { mHasTransfered = value; }
            }

            /* FP-SCR-00140 #1 [07.22.2010]
             * added for guarantee pax */
            private string mGuaranteedPax;
            public string GuaranteedPax
            {
                get { return mGuaranteedPax; }
                set { mGuaranteedPax = value; }
            }

            private string mActivity;
            public string Activity
            {
                get { return mActivity; }
                set { mActivity = GlobalFunctions.removeQuotes(value); }  
            }

            //Kevin Oliveros 2014-01-23

            private string mSetUpStartTime = "";
            public string EVENT_SETUP_START
            {
                set { this.mSetUpStartTime = value; }
                get { return this.mSetUpStartTime; }
            }

            private string mSetUpEndTime = "";
            public string EVENT_SETUP_END
            {
                set { this.mSetUpEndTime = value; }
                get { return this.mSetUpEndTime; }
            }
		}
	}
}
