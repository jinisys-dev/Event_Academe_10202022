using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Accounts
{
	namespace BusinessLayer
	{
		public class AgentCommission
		{
			
			public AgentCommission()
			{
				
			}
			public AgentCommission(string acctid, string tCode, double perCom)
			{
				mAccountID = acctid;
				mTranCode = tCode;
				mPercentCommission = System.Convert.ToDouble(tCode);
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
			private string mTranCode;
			public string TranCode
			{
				get
				{
					return mTranCode;
				}
				set
				{
					mTranCode = value;
				}
			}
			private double mPercentCommission;
			public double PercentCommission
			{
				get
				{
					return mPercentCommission;
				}
				set
				{
					mPercentCommission = value;
				}
			}
			
		}
	}
	
}
