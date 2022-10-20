using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class PrivilegeCollection : CollectionBase
		{
			
			
			public PrivilegeCollection()
			{
			}
			
			public void Add(Jinisys.Hotel.Reservation.BusinessLayer.Privilege oPrivilege)
			{
				this.List.Add(oPrivilege);
			}
			
			public Jinisys.Hotel.Reservation.BusinessLayer.Privilege Item(int Index)
			{
				return (Privilege)this.List[Index];
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
