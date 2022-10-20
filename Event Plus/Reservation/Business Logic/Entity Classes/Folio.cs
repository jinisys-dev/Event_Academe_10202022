
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class Folio : DataSet
		{
			
			
			private int mHotelId;
			
			//private string oldtype;
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

            private string mReferenceNo = "";
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

			private string mFolioType;
			public string FolioType
			{
				get
				{
					return mFolioType;
				}
				set
				{
					mFolioType = value;
				}
			}
			
			private string mGroupName = "";
			public string GroupName
			{
				get
				{
					return mGroupName;
				}
				set
				{
                    mGroupName = GlobalFunctions.removeQuotes(value);
				}
			}
			
			private string mAccountType;
			public string AccountType
			{
				get
				{
					return mAccountType;
				}
				set
				{
					mAccountType = value;
				}
			}
			
			private int mNoOfChild;
			public int NoOfChild
			{
				get
				{
                    return mNoOfChild;
				}
				set
				{
                    mNoOfChild = value;
				}
			}
			
			private int mNoofAdult;
			public int NoofAdults
			{
				get
				{
					return mNoofAdult;
				}
				set
				{
					mNoofAdult = value;
				}
			}
			
			private string mMasterFolio = "";
			public string MasterFolio
			{
				get
				{
					return mMasterFolio;
				}
				set
				{
					mMasterFolio = value;
				}
			}
			
			private string mCompanyID;
			public string CompanyID
			{
				get
				{
					return mCompanyID;
				}
				set
				{
					mCompanyID = value;
				}
			}
			
			private string mAgentID;
			public string AgentID
			{
				get
				{
					return mAgentID;
				}
				set
				{
					mAgentID = value;
				}
			}
			
			private string mSource;
			public string Source
			{
				get
				{
					return mSource;
				}
				set
				{
					mSource = value;
				}
			}
			
			private DateTime mFromDate;
			public DateTime FromDate
			{
				get
				{
					return mFromDate;
				}
				set
				{
					mFromDate = value;
				}
			}
			private DateTime mTodate;
			public DateTime Todate
			{
				get
				{
					return mTodate;
				}
				set
				{
					mTodate = value;
				}
			}
			
			private DateTime mArrivalDate;
			public DateTime ArrivalDate
			{
				get
				{
					return mArrivalDate;
				}
				set
				{
					mArrivalDate = value;
				}
			}
			
			private DateTime mDepartureDate;
			public DateTime DepartureDate
			{
				get
				{
					return mDepartureDate;
				}
				set
				{
					mDepartureDate = value;
				}
			}
			
			private string mPackageID;
			public string PackageID
			{
				get
				{
					return mPackageID;
				}
				set
				{
					mPackageID = value;
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

			private ChildFolios mChildFolios;
			public ChildFolios ChildFolios
			{
				get
				{
					return mChildFolios;
				}
				set
				{
					mChildFolios = value;
				}
			}

			private SubFolios mSubFolios;
			public SubFolios SubFolios
			{
				get
				{
					return mSubFolios;
				}
				
			}
			
			public void CreateSubFolio()
			{
				SubFolio subF;
				mSubFolios = new Jinisys.Hotel.Reservation.BusinessLayer.SubFolios();
				switch (this.FolioType.ToUpper())
				{
					case "INDIVIDUAL":
						subF = new SubFolio();
						subF.SubFolio_Renamed = "A";
						subF.Folio = this;
						mSubFolios.Add(subF);
						subF = new SubFolio();
						subF.SubFolio_Renamed = "B";
						subF.Folio = this;
						mSubFolios.Add(subF);
						
						subF = new SubFolio();
						subF.SubFolio_Renamed = "C";
						subF.Folio = this;
						mSubFolios.Add(subF);
						subF = new SubFolio();
						subF.SubFolio_Renamed = "D";
						subF.Folio = this;
						mSubFolios.Add(subF);
						break;
						
						
					case "SHARE":
						
						subF = new SubFolio();
						subF.SubFolio_Renamed = "A";
						subF.Folio = this;
						mSubFolios.Add(subF);
						subF = new SubFolio();
						subF.SubFolio_Renamed = "B";
						subF.Folio = this;
						mSubFolios.Add(subF);
						
						subF = new SubFolio();
						subF.SubFolio_Renamed = "C";
						subF.Folio = this;
						mSubFolios.Add(subF);
						subF = new SubFolio();
						subF.SubFolio_Renamed = "D";
						subF.Folio = this;
						mSubFolios.Add(subF);
						break;
						
					case "DEPENDENT":
						
						subF = new SubFolio();
						subF.SubFolio_Renamed = "A";
						subF.Folio = this;
						mSubFolios.Add(subF);

                        subF = new SubFolio();
                        subF.SubFolio_Renamed = "B";
                        subF.Folio = this;
                        mSubFolios.Add(subF);
						

						subF = new SubFolio();
						
						subF.SubFolio_Renamed = "C";
						subF.Folio = this;
						mSubFolios.Add(subF);
						subF = new SubFolio();
						subF.SubFolio_Renamed = "D";
						subF.Folio = this;
						mSubFolios.Add(subF);
						break;
					case "GROUP":
						
						subF = new SubFolio();
						subF.SubFolio_Renamed = "A";
						subF.Folio = this;
						mSubFolios.Add(subF);
						break;

                    case "JOINER":
                        break;
						
                    default:
                        subF = new SubFolio();
                        subF.SubFolio_Renamed = "A";
                        subF.Folio = this;
                        mSubFolios.Add(subF);
                        subF = new SubFolio();
                        subF.SubFolio_Renamed = "B";
                        subF.Folio = this;
                        mSubFolios.Add(subF);

                        subF = new SubFolio();
                        subF.SubFolio_Renamed = "C";
                        subF.Folio = this;
                        mSubFolios.Add(subF);
                        subF = new SubFolio();
                        subF.SubFolio_Renamed = "D";
                        subF.Folio = this;
                        mSubFolios.Add(subF);
                        break;
				}
			}
			
			private IList<FolioPackage> mPackage;
			public IList<FolioPackage> Package
			{
				get
				{
					return mPackage;
				}
				set
				{
					mPackage = value;
				}
			}
			
			private IList<Privilege> mPrivileges;
			public IList<Privilege> Privileges
			{
				get
				{
					return mPrivileges;
				}
				set
				{
					mPrivileges = value;
				}
			}
			
			private IList<RecurringCharge> mRecurringCharges;
			public IList<RecurringCharge> RecurringCharges
			{
				get
				{
					return mRecurringCharges;
				}
				set
				{
					mRecurringCharges = value;
				}
			}


			//private FolioRoutingCollection mFolioRouting;
			//public FolioRoutingCollection FolioRouting
			//{
			//    get
			//    {
			//        return mFolioRouting;
			//    }
			//    set
			//    {
			//        mFolioRouting = value;
			//    }
			//}


			private IList<FolioRouting> mFolioRouting = new List<FolioRouting>();
			public IList<FolioRouting> FolioRouting
			{
				get
				{
					return mFolioRouting;
				}
				set
				{
					mFolioRouting = value;
				}
			}
			


			// new April 24, 2008
			private string mSales_Executive;
			public string Sales_Executive
			{
				get
				{
					return mSales_Executive;
				}
				set
				{
					mSales_Executive = value;
				}
			}
			
			private string mPayment_Mode;
			public string Payment_Mode
			{
				get
				{
					return mPayment_Mode;
				}
				set
				{
					mPayment_Mode = value;
				}
			}

			private string mPurpose;
			public string Purpose
			{
				get
				{
					return mPurpose;
				}
				set
				{
					mPurpose = value;
				}
			}


			private string mREASON_FOR_CANCEL;
			public string REASON_FOR_CANCEL
			{
				get
				{
					return mREASON_FOR_CANCEL;
				}
				set
				{
					mREASON_FOR_CANCEL = value;
				}
			}

            private string mReasonType;
            public string ReasonType
            {
                get
                {
                    return mReasonType;
                }
                set
                {
                    mReasonType = value;
                }
            }

            private string mCancelBookingType;
            public string CancelBookingType
            {
                get
                {
                    return mCancelBookingType;
                }
                set
                {
                    mCancelBookingType = value;
                }
            }

            private string mFuture_Actions;
            public string Future_Actions
            {
                get
                {
                    return mFuture_Actions;
                }
                set
                {
                    mFuture_Actions = value;
                }
            }

			private Guest mGuest;
			public Guest Guest
			{
				set { this.mGuest = value ; }
				get { return this.mGuest; } // null ang guest
			}

			private Company mCompany;
			public Company Company
			{
				set { this.mCompany = value; }
				get { return this.mCompany; }
			}


			private IList<Folio> mJoinerFolios;
			public IList<Folio> JoinerFolios
			{
				set { this.mJoinerFolios = value; }
				get { return this.mJoinerFolios; }
			}

			private IList<Schedule> mSchedule;
			public IList<Schedule> Schedule
			{
				set { this.mSchedule = value; }
				get { return this.mSchedule; }
			}

			private int mTaxExempted;
			public int TaxExempted
			{
				set { this.mTaxExempted = value; }
				get { return this.mTaxExempted; }
			}

			// to tracer where folio was created
			private string mTerminalId;
			public string TerminalId
			{
				set { this.mTerminalId = value; }
				get { return this.mTerminalId; }
			}

			private string mShiftCode;
			public string ShiftCode
			{
				set { this.mShiftCode = value; }
				get { return this.mShiftCode; }
			}

			private string mSupervisorId;
			public string SupervisorId
			{
				set { this.mSupervisorId = value; }
				get { return this.mSupervisorId; }
			}


			//private DateTime mEstimatedTimeOfArrival;
			//public DateTime EstimatedTimeOfArrival
			//{
			//    set { this.mEstimatedTimeOfArrival = value; }
			//    get 
			//    {
			//        if (this.mEstimatedTimeOfArrival.Date == DateTime.Parse("1/1/0001").Date )
			//            this.mEstimatedTimeOfArrival = DateTime.Parse( "8/8/2008" );

			//        return this.mEstimatedTimeOfArrival; 
			//    }
			//}


			//private DateTime mEstimatedTimeOfDeparture;
			//public DateTime EstimatedTimeOfDeparture
			//{
			//    set { this.mEstimatedTimeOfDeparture = value; }
			//    get
			//    {
			//        if (this.mEstimatedTimeOfDeparture.Date == DateTime.Parse("1/1/0001").Date)
			//            this.mEstimatedTimeOfDeparture = DateTime.Parse("8/8/2008");

			//        return this.mEstimatedTimeOfDeparture;
			//    }
			//}


			private string mRoomNo = "";
			public string RoomNo
			{
				set { this.mRoomNo = value; }
				get { return this.mRoomNo; }
			}

			private string mFolioETA = "";
			public string FolioETA
			{
				set { this.mFolioETA = value; }
				get { return this.mFolioETA; }
			}

			private string mFolioETD = "";
			public string FolioETD
			{
				set { this.mFolioETD = value; }
				get { return this.mFolioETD; }
			}

            //added by Genny : Alpa requirements for folio inclusions
            private IList<FolioInclusions> mInclusions;
            public IList<FolioInclusions> Inclusions
            {
                get { return mInclusions; }
                set { mInclusions = value; }
            }
            private IList<EventContact> mContactPersons;
            public IList<EventContact> ContactPersons
            {
                get
                {
                    return mContactPersons;
                }
                set
                {
                    mContactPersons = value;
                }
            }
            private IList<EventOfficer> mEventOfficers;
            public IList<EventOfficer> EventOfficers
            {
                get
                {
                    return mEventOfficers;
                }
                set
                {
                    mEventOfficers = value;
                }
            }

            private EventEndorsement mEventEndorsement;
            public EventEndorsement EventEndorsement
            {
                get
                {
                    return mEventEndorsement;
                }
                set
                {
                    mEventEndorsement = value;
                }
            }

            private EventAttendance mEventAttendance;
            public EventAttendance EventAttendance
            {
                get
                {
                    return mEventAttendance;
                }
                set
                {
                    mEventAttendance = value;
                }
            }

            private IList<IncumbentOfficer> mIncumbentOfficers;
            public IList<IncumbentOfficer> IncumbentOfficers
            {
                get
                {
                    return mIncumbentOfficers;
                }
                set
                {
                    mIncumbentOfficers = value;
                }
            }
            //Kevin Oliveros 2014-01-23

            private string mSetUpStartTime = "";
            public string EVENT_SETUP_START
            {
                set { this.mSetUpStartTime = value; }
                get { return this.mSetUpStartTime; }
            }

            private string mSetUpEndTime = "";
            public string EVENT_SETUP_END
            {
                set { this.mSetUpEndTime = value; }
                get { return this.mSetUpEndTime; }
            }

		}

	}
}
