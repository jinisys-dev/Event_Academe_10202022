using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		
		
		public class RoleMenuCollection : CollectionBase
		{
			
			
			public RoleMenuCollection()
			{
			}
			public void Add(RoleMenu role_menu)
			{
				this.List.Add(role_menu);
			}
			public RoleMenu Item(int index)
			{
				return (RoleMenu)this.List[index];
			}
			public void Remove(int index)
			{
				if (index >= this.List.Count)
				{
					this.List.RemoveAt(index);
				}
			}
			public void Remove()
			{
				if (this.List.Count > 0)
				{
					this.List.RemoveAt(0);
				}
			}
		}
	}
}
