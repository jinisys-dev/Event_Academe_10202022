using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation
{
	namespace BusinessLayer
	{
		public class FolioPackageCollection : CollectionBase
		{
			
			
			public FolioPackageCollection()
			{
			}
			public void Add(FolioPackage FolioPackage)
			{
				this.List.Add(FolioPackage);
			}
			
			public FolioPackage Item(int index)
			{
				return (FolioPackage)this.List[index];
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
