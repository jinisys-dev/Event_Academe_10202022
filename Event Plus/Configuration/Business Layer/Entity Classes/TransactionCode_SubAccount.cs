using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class TransactionCode_SubAccount
	{
		public TransactionCode_SubAccount()
		{
		}

		private string mTransactionCode;
		public string TransactionCode
		{
			set
			{
				this.mTransactionCode = value;
			}
			get
			{
				return this.mTransactionCode;
			}
		}

		private string mSubAccountCode;
		public string SubAccountCode
		{
			set
			{
				this.mSubAccountCode = value;
			}
			get
			{
				return this.mSubAccountCode;
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


		private decimal mServiceCharge;
		public decimal ServiceCharge
		{
			get
			{
				return mServiceCharge;
			}
			set
			{
				mServiceCharge = value;
			}
		}

		private int mServiceChargeInclusive;
		public int ServiceChargeInclusive
		{
			get
			{
				return mServiceChargeInclusive;
			}
			set
			{
				mServiceChargeInclusive = value;
			}
		}

		private decimal mGovernmentTax;
		public decimal GovernmentTax
		{
			get
			{
				return mGovernmentTax;
			}
			set
			{
				mGovernmentTax = value;
			}
		}

		private int mGovernmentTaxInclusive;
		public int GovernmentTaxInclusive
		{
			get
			{
				return mGovernmentTaxInclusive;
			}
			set
			{
				mGovernmentTaxInclusive = value;
			}
		}


		private decimal mLocalTax;
		public decimal LocalTax
		{
			get
			{
				return mLocalTax;
			}
			set
			{
				mLocalTax = value;
			}
		}


		private int mLocalTaxInclusive;
		public int LocalTaxInclusive
		{
			get
			{
				return mLocalTaxInclusive;
			}
			set
			{
				mLocalTaxInclusive = value;
			}
		}



	}
}
