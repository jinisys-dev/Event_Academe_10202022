using System;
using System.Collections.Generic;
using System.Text;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class SystemConfiguration
	{

		public SystemConfiguration()
		{ }


		private string mKey;
		public string Key
		{
			get { return mKey; }
			set { mKey = value; }
		}


		private string mValue;
		public string Value
		{

			get { return (mValue.Replace("\\","\\\\")); }
			set { mValue = value; }
		}


		private string mDescription;
		public string Description
		{

			get { return mDescription; }
			set { mDescription = value; }
		}


		private string mUpdated_Date;
		public string Updated_Date
		{

			get { return mUpdated_Date; }
			set { mUpdated_Date = value; }
		}


		private string mUpdated_By;
		public string Updated_By
		{

			get { return mUpdated_By; }
			set { mUpdated_By = value; }
		}


	}
}
