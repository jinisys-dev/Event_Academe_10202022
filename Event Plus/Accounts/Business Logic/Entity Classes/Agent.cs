using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Accounts
{
	namespace BusinessLayer
	{
		public class Agent : DataSet
		{

            private string mAgentID;
            public string AgentID
            {
                get { return mAgentID; }
                set { mAgentID = value; }
            }

            private string mAgency;
            public string Agency
            {
                get { return mAgency; }
                set { mAgency = value; }
            }

            private string mContactPerson;
            public string ContactPerson
            {
                get { return mContactPerson; }
                set { mContactPerson = value; }
            }

            private string mAddress;
            public string Address
            {
                get { return mAddress; }
                set { mAddress = value; }
            }

            private string mContactNumber;
            public string ContactNumber
            {
                get { return mContactNumber; }
                set { mContactNumber = value; }
            }

			private AgentCommissionCollection mAgentcommissions;
			public AgentCommissionCollection Agentcommissions
			{
				get
				{
					return mAgentcommissions;
				}
				set
				{
					mAgentcommissions = value;
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
		}
	}
	
}
