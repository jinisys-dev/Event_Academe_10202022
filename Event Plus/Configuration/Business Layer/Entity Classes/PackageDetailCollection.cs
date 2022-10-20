using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class PackageDetailCollection : CollectionBase
		{
			
			
			public PackageDetailCollection()
			{
			}
			public void Add(PackageDetail packageDet)
			{
				this.List.Add(packageDet);
			}
			public object Item(int index)
			{
				return this.List[index];
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
