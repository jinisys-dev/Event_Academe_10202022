using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace BusinessLayer
	{
		public class PrivilegeDetailsCollection : CollectionBase
		{
			
			
			public PrivilegeDetailsCollection()
			{
			}
			public void Add(PrivilegeDetail priv_det)
			{
				this.List.Add(priv_det);
			}
			public object Item(int index)
			{
				return this.List[index];
			}
			public void Remove(int index)
			{
				if (index >= this.List.Count)
				{
					this.List.Remove(index);
				}
			}
			public void Remove()
			{
				if (this.List.Count > 0)
				{
					this.List.Remove(0);
				}
			}
		}
	}
}
