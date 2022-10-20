using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class RoomEvents : DataSet
		{
			
			
			#region " Component Designer generated lCode "
			
			public RoomEvents(System.ComponentModel.IContainer Container) : this()
			{
				
				//Required for Windows.Forms Class Composition Designer support
				Container.Add(this);
			}
			
			public RoomEvents()
			{
				
				//This call is required by the Component Designer.
				InitializeComponent();
				
				//Add any initialization after the InitializeComponent() call
				
			}
			
			//Component overrides dispose to clean up the component list.
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (!(components == null))
					{
						components.Dispose();
					}
				}
				base.Dispose(disposing);
			}
			
			//Required by the Component Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Component Designer
			//It can be modified using the Component Designer.
			//Do not modify it using the lCode editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				components = new System.ComponentModel.Container();
			}
			
			#endregion
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
			
			private int mEventNo;
			public int EventNo
			{
				get
				{
					return mEventNo;
				}
				set
				{
					mEventNo = value;
				}
			}
			
			private string mEventID;
			public string Eventid
			{
				
				get
				{
					return mEventID;
				}
				set
				{
					mEventID = value;
				}
			}
			
			private string mRoomId;
			public string RoomID
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
			
			private DateTime mEventDate;
			public DateTime EventDate
			{
				get
				{
					return mEventDate;
				}
				set
				{
					mEventDate = value;
				}
			}
			
			private string mEventtype;
			public string EventType
			{
				get
				{
					return mEventtype;
				}
				set
				{
					mEventtype = value;
				}
			}
			
			private decimal mRoomRate;
			public decimal RoomRate
			{
				get
				{
					return mRoomRate;
				}
				set
				{
					mRoomRate = value;
				}
			}
			
			private string mChargeFlag;
			public string ChargeFlag
			{
				get
				{
					return mChargeFlag;
				}
				set
				{
					mChargeFlag = value;
				}
			}
			
			//===================================================
			// newly added entities
			//===================================================
			
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

            /*  added by Genny for function rooms
             */
            private DateTime mStartEventTime;
            public DateTime StartEventTime
            {
                get { return mStartEventTime; }
                set { mStartEventTime = value; }
            }

            private DateTime mEndEventTime;
            public DateTime EndEventTime
            {
                get { return mEndEventTime; }
                set { mEndEventTime = value; }
            }

			private int mTransferFlag;
			public int TransferFlag
			{
				get
				{
					return mTransferFlag;
				}
				set
				{
					mTransferFlag = value;
				}
			}
			

		}
	}
}
