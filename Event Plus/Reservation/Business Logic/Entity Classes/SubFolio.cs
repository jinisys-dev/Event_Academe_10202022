using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class SubFolio
		{
			
			public SubFolio()
			{
			}
			private string mSubFolio;
			public string SubFolio_Renamed
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
			private Jinisys.Hotel.Reservation.BusinessLayer.Folio mFolio;
			public Jinisys.Hotel.Reservation.BusinessLayer.Folio Folio
			{
				get
				{
					return mFolio;
				}
				set
				{
					mFolio = value;
				}
			}
			private FolioTransactionLedger mFolioLedger;
			public FolioTransactionLedger Ledger
			{
				get
				{
					return mFolioLedger;
				}
				set
				{
					mFolioLedger = value;
				}
			}

            private FolioTransactions mFolioTransactions;

            public FolioTransactions FolioTransactions
            {
                get
                {
                    return mFolioTransactions;
                }
                set
                {
                    mFolioTransactions = value;
                }
            }


		}
	}
	
}
