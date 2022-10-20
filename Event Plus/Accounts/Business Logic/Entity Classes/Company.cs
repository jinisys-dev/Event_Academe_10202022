using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using System.Collections.Generic;

namespace Jinisys.Hotel.Accounts
{
	namespace BusinessLayer
	{
		public class Company : DataSet
		{
			
			
			public Company()
			{
			}
			
			private string mCompanyId;
			public string CompanyId
			{
				get
				{
					return mCompanyId;
				}
				set
				{
					mCompanyId = value;
				}
			}
			private string mCompanyCode;
			public string CompanyCode
			{
				get
				{
					return mCompanyCode;
				}
				set
				{
					mCompanyCode = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCompanyName;
			public string CompanyName
			{
				get
				{
					return mCompanyName;
				}
				set
				{
                    mCompanyName = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCompanyURL;
			public string CompanyURL
			{
				get
				{
					return mCompanyURL;
				}
				set
				{
					mCompanyURL = value;
				}
			}
			private string mContactPerson;
			public string ContactPerson
			{
				get
				{
					return mContactPerson;
				}
				set
				{
					mContactPerson = value;
				}
			}
			private string mDesignation;
			public string Designation
			{
				get
				{
					return mDesignation;
				}
				set
				{
                    mDesignation = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mStreet1;
			public string Street1
			{
				get
				{
					return mStreet1;
				}
				set
				{
					mStreet1 = value;
				}
			}
			private string mStreet2;
			public string Street2
			{
				get
				{
					return mStreet2;
				}
				set
				{
                    mStreet2 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mStreet3;
			public string Street3
			{
				get
				{
					return mStreet3;
				}
				set
				{
                    mStreet3 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCity1;
			public string City1
			{
				get
				{
					return mCity1;
				}
				set
				{
                    mCity1 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCity2;
			public string City2
			{
				get
				{
					return mCity2;
				}
				set
				{
                    mCity2 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCity3;
			public string City3
			{
				get
				{
					return mCity3;
				}
				set
				{
                    mCity3 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCountry1;
			public string Country1
			{
				get
				{
					return mCountry1;
				}
				set
				{
                    mCountry1 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCountry2;
			public string Country2
			{
				get
				{
					return mCountry2;
				}
				set
				{
                    mCountry2 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCountry3;
			public string Country3
			{
				get
				{
					return mCountry3;
				}
				set
				{
                    mCountry3 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mZip1;
			public string Zip1
			{
				get
				{
					return mZip1;
				}
				set
				{
                    mZip1 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mZip2;
			public string Zip2
			{
				get
				{
					return mZip2;
				}
				set
				{
                    mZip2 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mZip3;
			public string Zip3
			{
				get
				{
					return mZip3;
				}
				set
				{
                    mZip3 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mEmail1;
			public string Email1
			{
				get
				{
					return mEmail1;
				}
				set
				{
                    mEmail1 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mEmail2;
			public string Email2
			{
				get
				{
					return mEmail2;
				}
				set
				{
                    mEmail2 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mEmail3;
			public string Email3
			{
				get
				{
					return mEmail3;
				}
				set
				{
                    mEmail3 = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mContactNumber1;
			public string ContactNumber1
			{
				get
				{
					return mContactNumber1;
				}
				set
				{
					mContactNumber1 = value;
				}
			}
			private string mContactNumber2;
			public string ContactNumber2
			{
				get
				{
					return mContactNumber2;
				}
				set
				{
					mContactNumber2 = value;
				}
			}
			private string mContactNumber3;
			public string ContactNumber3
			{
				get
				{
					return mContactNumber3;
				}
				set
				{
					mContactNumber3 = value;
				}
			}
			private string mContactType1;
			public string ContactType1
			{
				get
				{
					return mContactType1;
				}
				set
				{
					mContactType1 = value;
				}
			}
			private string mContactType2;
			public string ContactType2
			{
				get
				{
					return mContactType2;
				}
				set
				{
					mContactType2 = value;
				}
			}
			private string mContactType3;
			public string ContactType3
			{
				get
				{
					return mContactType3;
				}
				set
				{
					mContactType3 = value;
				}
			}
			
			//===================================================
			// newly added entities
			//===================================================
			private int mgHotelId;
			public int HotelID
			{
				get
				{
					return mgHotelId;
				}
				set
				{
					mgHotelId = value;
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

			private string mRemarks;
			public string Remarks
			{
				get
				{
					return mRemarks;
				}
				set
				{
                    mRemarks = GlobalFunctions.removeQuotes(value);
				}
			}

			private IList<PrivilegeHeader> mAccountPrivileges;
			public IList<PrivilegeHeader> AccountPrivileges
			{
				get
				{
					return mAccountPrivileges;
				}
				set
				{
					mAccountPrivileges = value;
				}
			}

			private string mACCOUNT_TYPE;
			public string ACCOUNT_TYPE
			{
				get
				{
					return mACCOUNT_TYPE;
				}
				set
				{
					mACCOUNT_TYPE = value;
				}
			}

			private string mCARD_NO;
			public string CARD_NO
			{
				get
				{
					return mCARD_NO;
				}
				set
				{
					mCARD_NO = value;
				}
			}


			private double mTHRESHOLD_VALUE;
			public double THRESHOLD_VALUE
			{
				get
				{
					return mTHRESHOLD_VALUE;
				}
				set
				{
					mTHRESHOLD_VALUE = value;
				}
			}

			private double mTOTAL_SALES_CONTRIBUTION;
			public double TOTAL_SALES_CONTRIBUTION
			{
				get
				{
					return mTOTAL_SALES_CONTRIBUTION;
				}
				set
				{
					mTOTAL_SALES_CONTRIBUTION = value;
				}
			}

			private int mNO_OF_VISIT;
			public int NO_OF_VISIT
			{
				get
				{
					return mNO_OF_VISIT;
				}
				set
				{
					mNO_OF_VISIT = value;
				}
			}

			private double mX_DEAL_AMOUNT;
			public double X_DEAL_AMOUNT
			{
				get
				{
					return mX_DEAL_AMOUNT;
				}
				set
				{
					mX_DEAL_AMOUNT = value;
				}
			}

            private AccountInformation mAccountInformation;
            public AccountInformation AccountInformation
            {
                get { return mAccountInformation; }
                set { mAccountInformation = value; }
            }

            private IList<ContactPerson> mContactPersons;
            public IList<ContactPerson> ContactPersons
            {
                get { return mContactPersons; }
                set { mContactPersons = value; }
            }

            /* Gene
             * 01-Mar-12
             */
            private string mTIN;
            public string TIN
            {
                get
                {
                    return mTIN;
                }
                set
                {
                    mTIN = value;
                }
            }
		}
	}
	
}
