using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Services
{
	namespace BusinessLayer
	{
		public class HousekeepingJobs : CollectionBase
		{
			
			
			public HousekeepingJobs()
			{
			}
			
			public HousekeepingJob Item(int index)
			{
				return (HousekeepingJob)this.List[index];
			}
			
			public void Add(HousekeepingJob housekeepingJob)
			{
				List.Add(housekeepingJob);
			}
		}
		
	}
}
