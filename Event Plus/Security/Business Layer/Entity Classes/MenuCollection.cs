using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		public class MenuCollection : CollectionBase
		{
			
			
			public MenuCollection()
			{
			}
			
			public void Add(SystemMenu oMenu)
			{
				this.List.Add(oMenu);
			}
			
			public SystemMenu Item(int index)
			{
				return (SystemMenu)this.List[index];
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
