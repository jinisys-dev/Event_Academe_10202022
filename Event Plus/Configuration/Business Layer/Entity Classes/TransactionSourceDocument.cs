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
		public class TransactionSourceDocument : DataSet
		{

			public TransactionSourceDocument()
			{
			}
			
			private string mTransactionSourceId;
			public string TransactionSourceId
			{
				get
				{
					return mTransactionSourceId;
				}
				set
				{
					mTransactionSourceId = value;
				}
			}
			
			private string mDescription;
			public string Description
			{
				get
				{
					return mDescription;
				}
				set
				{
                    mDescription = GlobalFunctions.removeQuotes(value);
				}
			}
			
			private string mAbbreviation;
			public string Abbreviation
			{
				get
				{
					return mAbbreviation;
				}
				set
				{
					mAbbreviation = value;
				}
			}
			
			private string mStatusFlag;
			public string StatusFlag
			{
				get
				{
					return mStatusFlag;
				}
				set
				{
					mStatusFlag = value;
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

			private DateTime mCreatedDate;
			public DateTime CreatedDate
			{
				get
				{
					return mCreatedDate;
				}
				set
				{
					mCreatedDate = value;
				}
			}

			private DateTime mUpdatedDate;
			public DateTime UpdatedDate
			{
				get
				{
					return mUpdatedDate;
				}
				set
				{
					mUpdatedDate = value;
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
