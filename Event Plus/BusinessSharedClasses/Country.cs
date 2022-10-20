
using System;
using System.Data;
using System.Collections;
using System.Diagnostics;

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class Country
	{


		public Country()
		{
		}

		private string mCountryName;
		public string CountryName
		{
			set { this.mCountryName = value; }
			get { return this.mCountryName; }
		}


		private string mNationality;
		public string Nationality
		{
			set { this.mNationality = value; }
			get { return this.mNationality; }
		}

	}
}
