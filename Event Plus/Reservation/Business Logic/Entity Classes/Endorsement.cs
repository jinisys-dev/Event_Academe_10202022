using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
	public class Endorsement
	{

		public Endorsement()
		{
		}


		private int mId;
		public int Id
		{
			set { this.mId = value;	}
			get { return this.mId; }
		}

		private DateTime mLogDate;
		public DateTime LogDate
		{
			set { this.mLogDate = value; }
			get { return this.mLogDate; }
		}

		private int mTerminalNo;
		public int TerminalNo
		{
			set { this.mTerminalNo = value; }
			get { return this.mTerminalNo; }
		}

		private int mShiftCode;
		public int ShiftCode
		{
			set { this.mShiftCode = value; }
			get { return this.mShiftCode; }
		}

		private string mLoggedUser;
		public string LoggedUser
		{
			set { this.mLoggedUser = value; }
			get { return this.mLoggedUser; }
		}

		private string mEndorsementDescription;
		public string EndorsementDescription
		{
			set { this.mEndorsementDescription = value; }
			get { return this.mEndorsementDescription; }
		}

		private string mStatusFlag;
		public string StatusFlag
		{
			set { this.mStatusFlag = value; }
			get { return this.mStatusFlag; }
		}

		private string mEndorsementRemarks;
		public string EndorsementRemarks
		{
			set { this.mEndorsementRemarks = value; }
			get { return this.mEndorsementRemarks; }
		}

		private string mAcknowledgedBy;
		public string AcknowledgedBy
		{
			set { this.mAcknowledgedBy = value; }
			get { return this.mAcknowledgedBy; }
		}

		private int mAcknowledgeAtTerminal;
		public int AcknowledgeAtTerminal
		{
			set { this.mAcknowledgeAtTerminal = value; }
			get { return this.mAcknowledgeAtTerminal; }
		}

		private int mAcknowledgeAtShiftCode;
		public int AcknowledgeAtShiftCode
		{
			set { this.mAcknowledgeAtShiftCode = value; }
			get { return this.mAcknowledgeAtShiftCode; }
		}


		//private int mPriorityLevel;


		private string mCreatedBy;
		public string CreatedBy
		{
			set { this.mCreatedBy = value; }
			get { return this.mCreatedBy; }
		}

		private DateTime mCreateTime;
		public DateTime CreateTime
		{
			set { this.mCreateTime = value; }
			get { return this.mCreateTime; }
		}

		private string mUpdatedBy;
		public string UpdatedBy
		{
			set { this.mUpdatedBy = value; }
			get { return this.mUpdatedBy; }
		}

		private DateTime mUpdateTime;
		public DateTime UpdateTime
		{
			set { this.mUpdateTime = value; }
			get { return this.mUpdateTime; }
		}

		private int mHotelId;
		public int HotelId
		{
			set { this.mHotelId = value; }
			get { return this.mHotelId; }
		}

	}
}
