using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Collections.Generic;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.Accounts
{
	namespace BusinessLayer
	{
		public class Guest : DataSet
		{


			public Guest()
			{
			}

			private string mAccountId;
			public string AccountId
			{
				get
				{
					return mAccountId;
				}
				set
				{
					mAccountId = value;
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
			private string mTitle;
			public string Title
			{
				get
				{
					return mTitle;
				}
				set
				{
                    mTitle = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mLastName;
			public string LastName
			{
				get
				{
					return mLastName;
				}
				set
				{
					mLastName = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mFirstName;
			public string FirstName
			{
				get
				{
					return mFirstName;
				}
				set
				{
					mFirstName = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mMiddleName;
			public string MiddleName
			{
				get
				{
					return mMiddleName;
				}
				set
				{
					mMiddleName = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mSex;
			public string Sex
			{
				get
				{
					return mSex;
				}
				set
				{
					mSex = value;
				}
			}
			private string mCitizenship;
			public string Citizenship
			{
				get
				{
					return mCitizenship;
				}
				set
				{
					mCitizenship = value;
				}
			}
			private string mPassportId;
			public string PassportId
			{
				get
				{
					return mPassportId;
				}
				set
				{
					mPassportId = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mGuestImage;
			public string GuestImage
			{
				get
				{
					return mGuestImage;
				}
				set
				{
					mGuestImage = value;
				}
			}

			private string mTelephoneNo;
			public string TelephoneNo
			{
				get
				{
					return mTelephoneNo;
				}
				set
				{
					mTelephoneNo = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mMobileNo;
			public string MobileNo
			{
				get
				{
					return mMobileNo;
				}
				set
				{
					mMobileNo = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mFaxNo;
			public string FaxNo
			{
				get
				{
					return mFaxNo;
				}
				set
				{
					mFaxNo = GlobalFunctions.removeQuotes(value);
				}
			}

			private string mStreet;
			public string Street
			{
				get
				{
					return mStreet;
				}
				set
				{
                    mStreet = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCity;
			public string City
			{
				get
				{
					return mCity;
				}
				set
				{
                    mCity = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mCountry;
			public string Country
			{
				get
				{
					return mCountry;
				}
				set
				{
					mCountry = value;
				}
			}
			private string mZip;
			public string Zip
			{
				get
				{
					return mZip;
				}
				set
				{
					mZip = value;
				}
			}
			private string mEmailAddress;
			public string EmailAddress
			{
				get
				{
					return mEmailAddress;
				}
				set
				{
					mEmailAddress = GlobalFunctions.removeQuotes(value);
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
			private string mConcierge;
			public string Concierge
			{
				get
				{
					return mConcierge;
				}
				set
				{
                    mConcierge = GlobalFunctions.removeQuotes(value);
				}
			}
			private string mRemarks;
			public string Remark
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
			private int mNoOfVisits;
			public int NoOfVisits
			{
				get
				{
					return mNoOfVisits;
				}
				set
				{
					mNoOfVisits = value;
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

			private DateTime mBIRTH_DATE;
			public DateTime BIRTH_DATE
			{
				get
				{
					return (mBIRTH_DATE.ToShortDateString() == "01/01/0001" ? DateTime.Parse("01/01/1900") : this.mBIRTH_DATE);
				}
				set
				{
					mBIRTH_DATE = (value == DateTime.Parse("01/01/0001") ? DateTime.Parse("01/01/1900") : value);
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

			private string mCreditCardExpiry = "2001-01-01";
			public string CreditCardExpiry
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


			private int mTaxExempted;
			public int TaxExempted
			{
				set { this.mTaxExempted = value; }
				get { return this.mTaxExempted; }
			}

            private string mCompanyID;
            public string CompanyID
            {
                get { return mCompanyID; }
                set { mCompanyID = value; }
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
		}
	}
}
