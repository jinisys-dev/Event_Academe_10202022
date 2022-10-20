using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class FolioTransactions : CollectionBase
		{
			
			public FolioTransactions()
			{
			}
			public void Add(Jinisys.Hotel.Reservation.BusinessLayer.FolioTransaction tran)
			{
				this.List.Add(tran);
			}
			
			public Jinisys.Hotel.Reservation.BusinessLayer.FolioTransaction Item(int index)
			{
				return (Jinisys.Hotel.Reservation.BusinessLayer.FolioTransaction)this.List[index];
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
