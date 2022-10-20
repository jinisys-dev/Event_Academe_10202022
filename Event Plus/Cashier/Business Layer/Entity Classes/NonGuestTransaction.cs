using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.Cashier.BusinessLayer
{
	public class NonGuestTransaction
	{
		public NonGuestTransaction()
		{
		}

		private string mTransactionId;
		public string TransactionId
		{
			set
			{
				this.mTransactionId = value;
			}
			get 
			{
				return this.mTransactionId;
			}
		}

		private int mHotelID;
		public int HotelID
		{
			set
			{
				this.mHotelID = value;
			}
			get
			{
				return this.mHotelID;
			}
		}

		private DateTime mPostingDate;
		public DateTime PostingDate
		{
			set
			{
				this.mPostingDate = value;
			}
			get
			{
				return this.mPostingDate;
			}
		}

		private DateTime mTransactionDate;
		public DateTime TransactionDate
		{
			set
			{
				this.mTransactionDate = value;
			}
			get
			{
				return this.mTransactionDate;
			}
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

		private string mSubAccount;
		public string SubAccount
		{
			set
			{
				this.mSubAccount = value;
			}
			get
			{
				return this.mSubAccount;
			}
		}

		private string mReferenceNo;
		public string ReferenceNo
		{
			set
			{
				this.mReferenceNo = value;
			}
			get
			{
				return this.mReferenceNo;
			}
		}

		private string mTransactionSource;
		public string TransactionSource
		{
			set
			{
				this.mTransactionSource = value;
			}
			get
			{
				return this.mTransactionSource;
			}
		}

		private string mMemo;
		public string Memo
		{
			set
			{
				this.mMemo = value;
			}
			get
			{
				return this.mMemo;
			}
		}

		private string mAcctSide;
		public string AcctSide
		{
			set
			{
				this.mAcctSide = value;
			}
			get
			{
				return this.mAcctSide;
			}
		}

		private string mCurrencyCode;
		public string CurrencyCode
		{
			set
			{
				this.mCurrencyCode = value;
			}
			get
			{
				return this.mCurrencyCode;
			}
		}

		private decimal mConversionRate;
		public decimal ConversionRate
		{
			set
			{
				this.mConversionRate = value;
			}
			get
			{
				return this.mConversionRate;
			}
		}

		private decimal mCurrencyAmount;
		public decimal CurrencyAmount
		{
			set
			{
				this.mCurrencyAmount = value;
			}
			get
			{
				return this.mCurrencyAmount;
			}
		}

		private decimal mBaseAmount;
		public decimal BaseAmount
		{
			set
			{
				this.mBaseAmount = value;
			}
			get
			{
				return this.mBaseAmount;
			}
		}

		private decimal mDiscount;
		public decimal Discount
		{
			set
			{
				this.mDiscount = value;
			}
			get
			{
				return this.mDiscount;
			}
		}

		private decimal mServiceCharge;
		public decimal ServiceCharge
		{
			set
			{
				this.mServiceCharge = value;
			}
			get
			{
				return this.mServiceCharge;
			}
		}

		private int mServiceChargeInclusive;
		public int ServiceChargeInclusive
		{
			set
			{
				this.mServiceChargeInclusive = value;
			}
			get
			{
				return this.mServiceChargeInclusive;
			}
		}


		private decimal mGovernmentTax;
		public decimal GovernmentTax
		{
			set
			{
				this.mGovernmentTax = value;
			}
			get
			{
				return this.mGovernmentTax;
			}
		}

		private int mGovernmentTaxInclusive;
		public int GovernmentTaxInclusive
		{
			set
			{
				this.mGovernmentTaxInclusive = value;
			}
			get
			{
				return this.mGovernmentTaxInclusive;
			}
		}

		private decimal mLocalTax;
		public decimal LocalTax
		{
			set
			{
				this.mLocalTax = value;
			}
			get
			{
				return this.mLocalTax;
			}
		}

		private int mLocalTaxInclusive;
		public int LocalTaxInclusive
		{
			set
			{
				this.mLocalTaxInclusive = value;
			}
			get
			{
				return this.mLocalTaxInclusive;
			}
		}

		private decimal mNetBaseAmount;
		public decimal NetBaseAmount
		{
			set
			{
				this.mNetBaseAmount = value;
			}
			get
			{
				return this.mNetBaseAmount;
			}
		}


		private decimal mGrossAmount;
		public decimal GrossAmount
		{
			set
			{
				this.mGrossAmount = value;
			}
			get
			{
				return this.mGrossAmount;
			}
		}

		private decimal mNetAmount;
		public decimal NetAmount
		{
			set
			{
				this.mNetAmount = value;
			}
			get
			{
				return this.mNetAmount;
			}
		}

		private string mReferenceFolioId;
		public string ReferenceFolioId
		{
			set
			{
				this.mReferenceFolioId = value;
			}
			get
			{
				return this.mReferenceFolioId;
			}
		}

		private string mRoomNumber;
		public string RoomNumber
		{
			set
			{
				this.mRoomNumber = value;
			}
			get
			{
				return this.mRoomNumber;
			}
		}

		private string mAccountId;
		public string AccountId
		{
			set
			{
				this.mAccountId = value;
			}
			get
			{
				return this.mAccountId;
			}
		}

		private string mGuestName;
		public string GuestName
		{
			set
			{
				this.mGuestName = value;
			}
			get
			{
				return this.mGuestName;
			}
		}

		private string mCompanyName;
		public string CompanyName
		{
			set
			{
				this.mCompanyName = value;
			}
			get
			{
				return this.mCompanyName;
			}
		}

		private DateTime mArrivalDate;
		public DateTime ArrivalDate
		{
			set
			{
				this.mArrivalDate = value;
			}
			get
			{
				return this.mArrivalDate;
			}
		}

		private DateTime mDepartureDate;
		public DateTime DepartureDate
		{
			set
			{
				this.mDepartureDate = value;
			}
			get
			{
				return this.mDepartureDate;
			}
		}

		private string mReferenceDriverId;
		public string ReferenceDriverId
		{
			set
			{
				this.mReferenceDriverId = value;
			}
			get
			{
				return this.mReferenceDriverId;
			}
		}

		private string mCarCompany;
		public string CarCompany
		{
			set
			{
				this.mCarCompany = value;
			}
			get
			{
				return this.mCarCompany;
			}
		}

		private string mMakeModel;
		public string MakeModel
		{
			set
			{
				this.mMakeModel = value;
			}
			get
			{
				return this.mMakeModel;
			}
		}

		private string mPlateNumber;
		public string PlateNumber
		{
			set
			{
				this.mPlateNumber = value;
			}
			get
			{
				return this.mPlateNumber;
			}
		}

		
		private string mCreditCardNo;
		public string CreditCardNo
		{
			set
			{
				this.mCreditCardNo = value;
			}
			get
			{
				return this.mCreditCardNo;
			}

		}

		private string mChequeNo;
		public string ChequeNo
		{
			set
			{
				this.mChequeNo = value;
			}
			get
			{
				return this.mChequeNo;
			}

		}

		private string mAccountName;
		public string AccountName
		{
			set
			{
				this.mAccountName = value;
			}
			get
			{
				return this.mAccountName;
			}

		}

		private string mBankName;
		public string BankName
		{
			set
			{
				this.mBankName = value;
			}
			get
			{
				return this.mBankName;
			}

		}

		private DateTime mChequeDate;
		public DateTime ChequeDate
		{
			set
			{
				this.mChequeDate = value;
			}
			get
			{
				return this.mChequeDate;
			}

		}

		private string mFOCGrantedBy;
		public string FOCGrantedBy
		{
			set
			{
				this.mFOCGrantedBy = value;
			}
			get
			{
				return this.mFOCGrantedBy;
			}

		}

		private string mCreditCardType;
		public string CreditCardType
		{
			set
			{
				this.mCreditCardType = value;
			}
			get
			{
				return this.mCreditCardType;
			}

		}

		private string mApprovalSlip;
		public string ApprovalSlip
		{
			set
			{
				this.mApprovalSlip = value;
			}
			get
			{
				return this.mApprovalSlip;
			}

		}

		private DateTime mCreditCardExpiry;
		public DateTime CreditCardExpiry
		{
			set
			{
				this.mCreditCardExpiry = value;
			}
			get
			{
				return this.mCreditCardExpiry;
			}

		}

		
		private string mDriverLastName;
		public string DriverLastName
		{
			set
			{
				this.mDriverLastName = value;
			}
			get
			{
				return this.mDriverLastName;
			}
		}

		private string mDriverFirstName;
		public string DriverFirstName
		{
			set
			{
				this.mDriverFirstName = value;
			}
			get
			{
				return this.mDriverFirstName;
			}

		}


		private string mTerminalID;
		public string TerminalID
		{
			set
			{
				this.mTerminalID = value;
			}
			get
			{
				return this.mTerminalID;
			}
		}


		private int mShiftCode;
		public int ShiftCode
		{
			set
			{
				this.mShiftCode = value;
			}
			get
			{
				return this.mShiftCode;
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

		private int mPostedToLedger;
		public int PostedToLedger
		{
			set
			{
				this.mPostedToLedger = value;
			}
			get
			{
				return this.mPostedToLedger;
			}

		}

		private int mAuditFlag;
		public int AuditFlag
		{
			set
			{
				this.mAuditFlag = value;
			}
			get
			{
				return this.mAuditFlag;
			}

		}


		private DateTime mCreatedDate;
		public DateTime createdDate
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

		private string mCreatedBy;
		public string createdBy
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

		private DateTime mUpdatedDate;
		public DateTime updatedDate
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

		private string mUpdatedBy;
		public string updatedBy
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


	}
}
