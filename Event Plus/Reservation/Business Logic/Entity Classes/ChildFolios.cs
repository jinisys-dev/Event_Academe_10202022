using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class ChildFolios : CollectionBase
		{
			
			public ChildFolios()
			{
			}
			public void Add(Jinisys.Hotel.Reservation.BusinessLayer.Folio Folio)
			{
				this.List.Add(Folio);
			}
			
			public Jinisys.Hotel.Reservation.BusinessLayer.Folio Item(int index)
			{
				return (Jinisys.Hotel.Reservation.BusinessLayer.Folio)this.List[index];
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
