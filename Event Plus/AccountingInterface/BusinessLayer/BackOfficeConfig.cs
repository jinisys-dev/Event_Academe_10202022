using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.AccountingInterface.BusinessLayer
{
	class BackOfficeConfig
	{

		public BackOfficeConfig()
        { }

		private string mBackOfficeCode;
		public string BackOfficeCode
		{
			get
			{
				return this.mBackOfficeCode;
			}
			set
			{
				this.mBackOfficeCode = value;
			}
		}

		private string mBackOfficeName;
		public string BackOfficeName
		{
			get
			{
				return this.mBackOfficeName;
			}
			set
			{
				this.mBackOfficeName = value;
			}
		}

		private string mBackOfficeVersion;
		public string BackOfficeVersion
		{
			get
			{
				return this.mBackOfficeVersion;
			}
			set
			{
				this.mBackOfficeVersion = value;
			}
		}

		private string mPostingSchedule;
		public string PostingSchedule
		{
			get
			{
				return this.mPostingSchedule;
			}
			set
			{
				this.mPostingSchedule = value;
			}
		}

		private int mPostingScheduleYear;
		public int PostingScheduleYear
		{
			get
			{
				return this.mPostingScheduleYear;
			}
			set
			{
				this.mPostingScheduleYear = value;
			}
		}

		private string mPostingScheduleMonth;
		public string PostingScheduleMonth
		{
			get
			{
				return this.mPostingScheduleMonth;
			}
			set
			{
				this.mPostingScheduleMonth = value;
			}
		}

		private int mPostingScheduleDay;
		public int PostingScheduleDay
		{
			get
			{
				return this.mPostingScheduleDay;
			}
			set
			{
				this.mPostingScheduleDay = value;
			}
		}

		private string mPostingScheduleTime;
		public string PostingScheduleTime
		{
			get
			{
				return this.mPostingScheduleTime;
			}
			set
			{
				this.mPostingScheduleTime = value;
			}
		}

		private string mConnectionString;
		public string ConnectionString
		{
			get
			{
				return this.mConnectionString;
			}
			set
			{
				this.mConnectionString = value;
			}
		}

	}
}
