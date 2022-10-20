using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class TransactionCode : DataSet
		{
			
			public TransactionCode()
			{
			}
			
			
			private string mTranCode;
			public string TranCode
			{
				get
				{
					return mTranCode;
				}
				set
				{
					mTranCode = value;
				}
			}
			
			private string mTranTypeId;
			public string TranTypeId
			{
				get
				{
					return mTranTypeId;
				}
				set
				{
					mTranTypeId = value;
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
			
			private decimal mGovtTax;
			public decimal GovtTax
			{
				get
				{
					return mGovtTax;
				}
				set
				{
					mGovtTax = value;
				}
			}

			private int mGovtTaxInclusive;
			public int GovtTaxInclusive
			{
				get
				{
					return mGovtTaxInclusive;
				}
				set
				{
					mGovtTaxInclusive = value;
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

			private string mDefaultTransactionSource;
			public string DefaultTransactionSource
			{
				get
				{
					return mDefaultTransactionSource;
				}
				set
				{
					mDefaultTransactionSource = value;
				}
			}
			
			private decimal mDefaultAmount;
			public decimal DefaultAmount
			{
				get
				{
					return mDefaultAmount;
				}
				set
				{
					mDefaultAmount = value;
				}
			}
			
			private decimal mWarningAmount;
			public decimal WarningAmount
			{
				get
				{
					return mWarningAmount;
				}
				set
				{
					mWarningAmount = value;
				}
			}

			private string mDepartmentId;
			public string DepartmentId
			{
				get
				{
					return mDepartmentId;
				}
				set
				{
					mDepartmentId = value;
				}
			}
			

			private string mLedger;
			public string Ledger
			{
				get
				{
					return mLedger;
				}
				set
				{
					mLedger = value;
				}
			}


			private string mDebitSide;
			public string DebitSide
			{
				get
				{
					return mDebitSide;
				}
				set
				{
					mDebitSide = value;
				}
			}

			private string mCreditSide;
			public string CreditSide
			{
				get
				{
					return mCreditSide;
				}
				set
				{
					mCreditSide = value;
				}
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
		

		}
	}
}
