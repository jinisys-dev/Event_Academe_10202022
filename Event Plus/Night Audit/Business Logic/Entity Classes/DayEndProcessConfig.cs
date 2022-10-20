using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.NightAudit.BusinessLayer
{
	public class DayEndProcessConfig
	{
		public DayEndProcessConfig()
		{ }


		private int mHotelId;
		public int HotelId
		{
			set
			{
				this.mHotelId = value;
			}
			get
			{
				return this.mHotelId;
			}
		}

		private string mProcessType;
		public string ProcessType
		{
			set
			{
				this.mProcessType = value;
			}
			get
			{
				return this.mProcessType;
			}
		}

		private string mScheduleTime;
		public string ScheduleTime
		{
			set
			{
				this.mScheduleTime = value;
			}
			get
			{
				return this.mScheduleTime;
			}
		}


		private int mTerminalNo;
		public int TerminalNo
		{
			set
			{
				this.mTerminalNo = value;
			}
			get
			{
				return this.mTerminalNo;
			}
		}


		private int mNotifySchedule;
		public int NotifySchedule
		{
			set
			{
				this.mNotifySchedule = value;
			}
			get
			{
				return this.mNotifySchedule;
			}
		}

		private string mReportsToGenerate;
		public string ReportsToGenerate
		{
			set
			{
				this.mReportsToGenerate = value;
			}
			get
			{
				return this.mReportsToGenerate;
			}
		}

		private string mStatusFlag;
		public string StatusFlag
		{
			set
			{
				this.mStatusFlag = value;
			}
			get
			{
				return this.mStatusFlag;
			}
		}

		private string mCreatedBy;
		public string CreatedBy
		{
			set
			{
				this.mCreatedBy = value;
			}
			get
			{
				return this.mCreatedBy;
			}
		}

		private DateTime mCreatedDate;
		public DateTime CreatedDate
		{
			set
			{
				this.mCreatedDate = value;
			}
			get
			{
				return this.mCreatedDate;
			}
		}

		private string mUpdatedBy;
		public string UpdatedBy
		{
			set
			{
				this.mUpdatedBy = value;
			}
			get
			{
				return this.mUpdatedBy;
			}
		}


		private DateTime mUpdatedDate;
		public DateTime UpdatedDate
		{
			set
			{
				this.mUpdatedDate = value;
			}
			get
			{
				return this.mUpdatedDate;
			}
		}


		private int mBackupDatabase;
		public int BackupDatabase
		{
			set
			{
				this.mBackupDatabase = value;
			}
			get
			{
				return this.mBackupDatabase;
			}
		}

	}
}
