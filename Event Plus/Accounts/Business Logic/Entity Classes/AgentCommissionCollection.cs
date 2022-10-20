using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Accounts
{
	namespace BusinessLayer
	{
		public class AgentCommissionCollection : CollectionBase
		{
			
			public AgentCommissionCollection()
			{
			}
			public void Add(AgentCommission tran)
			{
				List.Add(tran);
			}
			
			public AgentCommission Item(int index)
			{
                return (AgentCommission)this.List[index];
			}
			
		}
		
	}
	
	
}
