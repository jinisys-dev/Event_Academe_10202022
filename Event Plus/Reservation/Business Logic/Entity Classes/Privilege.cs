using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class Privilege : DataSet
		{
			
			
			public Privilege()
			{
			}
			
			private int mHotelID;
			public int HotelId
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
			
			private string mMemo;
			public string Memo
			{
				get
				{
					return mMemo;
				}
				set
				{
					mMemo = value;
				}
			}
			
			private string mBasis;
			public string Basis
			{
				get
				{
					return mBasis;
				}
				set
				{
					mBasis = value;
				}
			}
			
			private decimal mPercentoff;
			public decimal Percentoff
			{
				get
				{
					return mPercentoff;
				}
				set
				{
					mPercentoff = value;
				}
			}
			
			private decimal mAmountOff;
			public decimal AmountOff
			{
				get
				{
					return mAmountOff;
				}
				set
				{
					mAmountOff = value;
				}
			}
			
		}
	}
}
