using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class RecurringChargeCollection : CollectionBase
		{
			
			public RecurringChargeCollection()
			{
			}
			public void Add(Jinisys.Hotel.Reservation.BusinessLayer.RecurringCharge RecurringCharge)
			{
				this.List.Add(RecurringCharge);
			}
			
			public Jinisys.Hotel.Reservation.BusinessLayer.RecurringCharge Item(int index)
			{
				return (RecurringCharge)this.List[index];
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
