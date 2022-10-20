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
		public class FolioTransaction : DataSet
		{
			
			public FolioTransaction()
			{
			}

			private int mFolioTransactionNo;
			public int FolioTransactionNo
			{
				get { return mFolioTransactionNo; }
				set { mFolioTransactionNo = value; }
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
			
			private string mSubFolio;
			public string SubFolio
			{
				get
				{
					return mSubFolio;
				}
				set
				{
					mSubFolio = value;
				}
			}
			
			private string mAccountID;
			public string AccountID
			{
				get
				{
					return mAccountID;
				}
				set
				{
					mAccountID = value;
				}
			}
			
			private DateTime mTransactionDate;
			public DateTime TransactionDate
			{
				get
				{
					return mTransactionDate;
				}
				set
				{
					mTransactionDate = value;
				}
			}

			private DateTime mPostingDate;
            public DateTime PostingDate
            {
                get
                {
                    return mPostingDate;
                }
                set
                {
                    mPostingDate=value;
                }
            }

			private string mTransactionCode;
			public string TransactionCode
			{
				get
				{
					return mTransactionCode;
				}
				set
				{
					mTransactionCode = value;
				}
			}

			private string mSubAccount;
			public string SubAccount
			{
				get
				{
					return mSubAccount;
				}
				set
				{
					mSubAccount = value;
				}
			}

			private string mReferenceNo;
			public string ReferenceNo
			{
				get
				{
					return mReferenceNo;
				}
				set
				{
					mReferenceNo = value;
				}
			}

            private string mTransactionSource;
            public string TransactionSource
            {
                get
                {
                    return mTransactionSource;
                }
                set
                {
                    mTransactionSource = value;
                }
            }

			private string mMemo;
			public string Memo
			{
				get
				{
					return mMemo;
				}
				set
				{
                    mMemo = GlobalFunctions.removeQuotes(value);
				}
			}
			
			private string mAcctSide;
			public string AcctSide
			{
				get
				{
					return mAcctSide;
				}
				set
				{
					mAcctSide = value;
				}
			}
			
			private string mCurrencyCode;
			public string CurrencyCode
			{
				get
				{
					return mCurrencyCode;
				}
				set
				{
					mCurrencyCode = value;
				}
			}
			
			private decimal mConversionRate;
			public decimal ConversionRate
			{
				get
				{
					return mConversionRate;
				}
				set
				{
					mConversionRate = value;
				}
			}
			
			private decimal mCurrencyAmount;
			public decimal CurrencyAmount
			{
				get
				{
					return mCurrencyAmount;
				}
				set
				{
					mCurrencyAmount = value;
				}
			}
			
			private decimal mBaseAmount;
			public decimal BaseAmount
			{
				get
				{
					return mBaseAmount;
				}
				set
				{
					mBaseAmount = value;
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

			private decimal mDiscount;
			public decimal Discount
			{
				get
				{
					return mDiscount;
				}
				set
				{
					mDiscount = value;
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
				get
				{
					return mNetBaseAmount;
				}
				set
				{
					mNetBaseAmount = value;
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

			private string mCreditCardNo;
			public string CreditCardNo
			{
				get
				{
					return mCreditCardNo;
				}
				set
				{
					mCreditCardNo = value;
				}
			}

			private string mChequeNo;
			public string ChequeNo
			{
				get
				{
					return mChequeNo;
				}
				set
				{
					mChequeNo = value;
				}
			}

			private string mAccountName;
			public string AccountName
			{
				get
				{
					return mAccountName;
				}
				set
				{
                    mAccountName = GlobalFunctions.removeQuotes(value);
				}
			}

			private string mBankName;
			public string BankName
			{
				get
				{
					return mBankName;
				}
				set
				{
                    mBankName = GlobalFunctions.removeQuotes(value);
				}
			}

			private string mChequeDate;
			public string ChequeDate
			{
				get
				{
					return mChequeDate;
				}
				set
				{
					mChequeDate = value;
				}
			}

			private string mFOCGrantedBy;
			public string FOCGrantedBy
			{
				get
				{
					return mFOCGrantedBy;
				}
				set
				{
					mFOCGrantedBy = value;
				}
			}

			private string mCreditCardType;
			public string CreditCardType
			{
				get
				{
					return mCreditCardType;
				}
				set
				{
                    mCreditCardType = GlobalFunctions.removeQuotes(value);
				}
			}

			private string mApprovalSlip;
			public string ApprovalSlip
			{
				get
				{
					return mApprovalSlip;
				}
				set
				{
					mApprovalSlip = value;
				}
			}

			private string mCreditCardExpiry;
			public string CreditCardExpiry
			{
				get
				{
					return mCreditCardExpiry;
				}
				set
				{
					mCreditCardExpiry = value;
				}
			}

			private string mRouteSequence;
			public string RouteSequence
			{
				get
				{
					return mRouteSequence;
				}
				set
				{
					mRouteSequence = value;
				}
			}
			
			private string mSourceFolio;
			public string SourceFolio
			{
				get
				{
					return mSourceFolio;
				}
				set
				{
					mSourceFolio = value;
				}
			}
			
			private string mSourceSubFolio;
			public string SourceSubFolio
			{
				get
				{
					return mSourceSubFolio;
				}
				set
				{
					mSourceSubFolio = value;
				}
			}
			
			private string mTerminalID;
			public string TerminalID
			{
				get
				{
					return mTerminalID;
				}
				set
				{
					mTerminalID = value;
				}
			}

			private string mShiftCode;
			public string ShiftCode
			{
				get
				{
					return mShiftCode;
				}
				set
				{
					mShiftCode = value;
				}
			}
			
			private string mStatus;
			public string Status
			{
				get
				{
					return mStatus;
				}
				set
				{
					mStatus = value;
				}
			}
			
			private string mPostToLedger;
			public string PostToLedger
			{
				get
				{
					return mPostToLedger;
				}
				set
				{
					mPostToLedger = value;
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

			private string mAuditFlag;
			public string AuditFlag
			{
				get
				{
					return mAuditFlag;
				}
				set
				{
					mAuditFlag = value;
				}
			}

            private int mSummaryFlag;
            public int SummaryFlag
            {
                get { return mSummaryFlag; }
                set { mSummaryFlag = value; }
            }

            private string mPackageName;
            public string PackageName
            {
                get { return mPackageName; }
                set { mPackageName = value; }
            }

			private decimal mMealAmount = 0;
			public decimal MealAmount
			{
				set { this.mMealAmount = value; }
				get { return this.mMealAmount; }
			}

            private string mAdjustmentFlag;
            public string AdjustmentFlag
            {
                get { return mAdjustmentFlag; }
                set { mAdjustmentFlag = value; }
            }

            private string mRoomID;
            public string RoomID
            {
                get { return mRoomID; }
                set { mRoomID = value; }
            }
		}
	}
}
