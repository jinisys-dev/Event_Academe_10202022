using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class Contact
	{
		public Contact()
		{
		}


		private int mId;
		public int Id
		{
			get { return this.mId; }
			set { this.mId = value; }
		}

		private string mContactNumber;
		public string ContactNumber
		{
			get { return this.mContactNumber; }
			set { this.mContactNumber = value; }
		}

		private string mContactType;
		public string ContactType
		{
			get { return this.mContactType; }
			set { this.mContactType = value; }
		}

		private string mContactName;
		public string ContactName
		{
			get { return this.mContactName; }
			set { this.mContactName = value; }
		}

		private string mFullName;
		public string FullName
		{
			get { return this.mFullName; }
			set { this.mFullName = value; }
		}

		private string mDesignation;
		public string Designation
		{
			get { return this.mDesignation; }
			set { this.mDesignation = value; }
		}

		private string mCompany;
		public string Company
		{
			get { return this.mCompany; }
			set { this.mCompany = value; }
		}

		private string mAddress;
		public string Address
		{
			get { return this.mAddress; }
			set { this.mAddress = value; }

		}

		private string mEmailAddress;
		public string EmailAddress
		{
			get { return this.mEmailAddress; }
			set { this.mEmailAddress = value; }

		}

		private string mStatusFlag;
		public string StatusFlag
		{
			get { return this.mStatusFlag; }
			set { this.mStatusFlag = value; }

		}

		private string mCreatedBy;
		public string CreatedBy
		{
			get { return this.mCreatedBy; }
			set { this.mCreatedBy = value; }

		}

		private DateTime mCreateTime;
		public DateTime CreateTime
		{
			get { return this.mCreateTime; }
			set { this.mCreateTime = value; }

		}

		private string mUpdatedBy;
		public string UpdatedBy
		{
			get { return this.mUpdatedBy; }
			set { this.mUpdatedBy = value; }

		}

		private DateTime mUpdateTime;
		public DateTime UpdateTime
		{
			get { return this.mUpdateTime; }
			set { this.mUpdateTime = value; }

		}


		private string mRemarks;
		public string Remarks
		{
			get { return this.mRemarks; }
			set { this.mRemarks = value; }
		}
	}


}
