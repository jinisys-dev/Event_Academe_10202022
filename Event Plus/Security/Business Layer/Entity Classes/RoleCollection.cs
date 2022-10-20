using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;


using System.Collections;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		
		public class RoleCollection : CollectionBase
		{
			
			
			
			public RoleCollection()
			{
			}
			
			public void Add(Role oRole)
			{
				this.List.Add(oRole);
			}
			
			public Role Item(int index)
			{
				return (Role)this.List[index];
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
