using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class FolioTransactionLedger
		{
			
			public FolioTransactionLedger()
			{
				
			}
			private int mHotelID;
			public int HotelID
			{
				get
				{
					return mHotelID;
				}
				set
				{
					mHotelID = value;
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
			private decimal mCharges;
			public decimal Charges
			{
				get
				{
					return mCharges;
				}
				set
				{
					mCharges = value;
				}
			}
			private decimal mPayCash;
			public decimal PayCash
			{
				get
				{
					return mPayCash;
				}
				set
				{
					mPayCash = value;
				}
			}
			private decimal mPayCard;
			public decimal PayCard
			{
				get
				{
					return mPayCard;
				}
				set
				{
					mPayCard = value;
				}
			}
			private decimal mPayCheque;
			public decimal PayCheque
			{
				get
				{
					return mPayCheque;
				}
				set
				{
					mPayCheque = value;
				}
			}
			private decimal mPayGiftCheque;
			public decimal PayGiftCheque
			{
				get
				{
					return mPayGiftCheque;
				}
				set
				{
					mPayGiftCheque = value;
				}
			}
			private decimal mBalanceForwarded;
			public decimal BalanceForwarded
			{
				get
				{
					return mBalanceForwarded;
				}
				set
				{
					mBalanceForwarded = value;
				}
			}
			private decimal mBalanceNet;
			public decimal BalanceNet
			{
				get
				{
					return mBalanceNet;
				}
				set
				{
					mBalanceNet = value;
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
			private decimal mAgentComission;
			public decimal AgentComission
			{
				get
				{
					return mAgentComission;
				}
				set
				{
					mAgentComission = value;
				}
			}
			private decimal mTotalNet;
			public decimal TotalNet
			{
				get
				{
					return mTotalNet;
				}
				set
				{
					mTotalNet = value;
				}
			}
			private string mPostToLedger;
			public string PostoTLedger
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
		}
	}
	
}
