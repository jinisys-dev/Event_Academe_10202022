using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class FolioRoutingCollection : CollectionBase
		{
			
			public FolioRoutingCollection()
			{
			}
			public void Add(Jinisys.Hotel.Reservation.BusinessLayer.FolioRouting oFolioRouting)
			{
				this.List.Add(oFolioRouting);
			}
			
			public Jinisys.Hotel.Reservation.BusinessLayer.FolioRouting Item(int index)
			{
				return (FolioRouting)this.List[index];
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
			
			public void RemoveItem(string TransactionCode)
			{
				int i = 0;
				int c = this.List.Count;
				
				while (i < this.Count)
				{
					if (this.Item(i).TransactionCode == TransactionCode)
					{
						this.RemoveAt(i);
						i = 0;
					}
					i++;
				}
			}
			
		}
		
	}
	
}
