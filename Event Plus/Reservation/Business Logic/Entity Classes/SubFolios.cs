using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class SubFolios : CollectionBase
		{
			
			public SubFolios()
			{
			}
			public void Add(Jinisys.Hotel.Reservation.BusinessLayer.SubFolio SubFolio)
			{
				this.List.Add(SubFolio);
			}
			public Jinisys.Hotel.Reservation.BusinessLayer.SubFolio Item(int Index)
			{
				return (Jinisys.Hotel.Reservation.BusinessLayer.SubFolio)this.List[Index];
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
