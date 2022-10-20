using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
	public class SystemConfigurationDAO
	{


		public SystemConfigurationDAO()
		{ }


		public DataTable getSystemConfig()
		{
			DataTable _dtTableTemp = new DataTable();

			string _sqlStr = "call spSelectSystemConfiguration()";


			MySqlDataAdapter _dtSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
			_dtSelect.Fill(_dtTableTemp);

			return _dtTableTemp;

		}

		public void updateSystemConfig(string pKey, string pValue, string pDescription)
		{


			string _sqlStr = "call spUpdateSystemConfiguration('" + 
								   pKey + "','" + 
								   pValue + "','" + 
								   pDescription + "','" + 
								   GlobalVariables.gLoggedOnUser + "')";

			MySqlCommand _updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
			_updateCommand.ExecuteNonQuery();

		}


	}
}
