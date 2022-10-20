using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.Accounts
{
	namespace BusinessLayer
	{
		public class AccountPrivileges : CollectionBase
		{
			
			
			public AccountPrivileges()
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
			public void Add(ConfigurationHotel.BusinessLayer.PrivilegeDetail Privilege)
			{
				List.Add(Privilege);
			}
			
			public Jinisys.Hotel.ConfigurationHotel.BusinessLayer.PrivilegeDetail Item(int index)
			{
                return (PrivilegeDetail)List[index];
			}
			
			public void Remove(int index)
			{
				if (index >= List.Count)
				{
					List.RemoveAt(index);
				}
			}
			
			public void Remove()
			{
				if (List.Count > 0)
				{
					List.RemoveAt(0);
				}
			}
		}
	}
}
