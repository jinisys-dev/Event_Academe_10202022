using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class Room : DataSet
		{
			public Room()
			{
			}
			
			private string mRoomId;
			public string RoomId
			{
				get
				{
					return mRoomId;
				}
				set
				{
					mRoomId = value;
				}
			}
			private string mRoomTypeCode;
			public string RoomTypecode
			{
				get
				{
					return mRoomTypeCode;
				}
				set
				{
					mRoomTypeCode = value;
				}
			}
			private int mMaxOccupants;
			public int MaxOccupants
			{
				get
				{
					return mMaxOccupants;
				}
				set
				{
					mMaxOccupants = value;
				}
			}
			private int mNoOfBeds;
			public int NoOfBeds
			{
				get
				{
					return mNoOfBeds;
				}
				set
				{
					mNoOfBeds = value;
				}
			}
			private int mNoOfAdult;
			public int NoOfAdult
			{
				get
				{
					return mNoOfAdult;
				}
				set
				{
					mNoOfAdult = value;
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
			private string mShareType;
			public string ShareType
			{
				get
				{
					return mShareType;
				}
				set
				{
					mShareType = value;
				}
			}
			private string mFloor;
			public string Floor
			{
				get
				{
					return mFloor;
				}
				set
				{
					mFloor = value;
				}
			}
			private string mDirFacing;
			public string DirFacing
			{
				get
				{
					return mDirFacing;
				}
				set
				{
					mDirFacing = value;
				}
			}
			private string mWindows;
			public string Windows
			{
				get
				{
					return mWindows;
				}
				set
				{
					mWindows = value;
				}
			}
			private string mAdjLeft;
			public string AdjLeft
			{
				get
				{
					return mAdjLeft;
				}
				set
				{
					mAdjLeft = value;
				}
			}
			private string mAdjRight;
			public string AdjRight
			{
				get
				{
					return mAdjRight;
				}
				set
				{
					mAdjRight = value;
				}
			}
			private string mRoomImage;
			public string RoomImage
			{
				get
				{
					return mRoomImage;
				}
				set
				{
					mRoomImage = value;
				}
			}
			private string mSmokingType;
			public string SmokingType
			{
				get
				{
					return mSmokingType;
				}
				set
				{
					mSmokingType = value;
				}
			}

            private string mBedSplittable;
            public string BedSplittable
            {
                get
                {
                    return mBedSplittable;
                }
                set
                {
                    mBedSplittable = value;
                }
            }

			private string mCleaningStatus;
			public string CleaningStatus
			{
				get
				{
					return mCleaningStatus;
				}
				set
				{
					mCleaningStatus = value;
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
					mTelephoneNo = value;
				}
			}
			
			
			private string mStateflag;
			public string Stateflag
			{
				get
				{
					return mStateflag;
				}
				set
				{
					mStateflag = value;
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

            private AmenityCollection mAmenities;
            public AmenityCollection Amenities
            {
                get {
                    return mAmenities;
                }
                set {
                    this.mAmenities = value;    
                }
            }

            /* FP-SCR-00139 #1 [07.20.2010]
             * additional field for description of room */
            private string mRoomDescription;
            public string RoomDescription
            {
                get { return mRoomDescription; }
                set { mRoomDescription = value; }
            }
            /* end of SCR-00139 */

            private decimal mRoomArea;
            public decimal RoomArea
            {
                get { return mRoomArea; }
                set { mRoomArea = value; }
            }
		}
		
	}
}
