using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class SystemConfigurationFacade
	{

		public SystemConfigurationFacade()
		{ 
		}

		SystemConfigurationDAO loSystemConfigurationDAO;
		public IList<SystemConfiguration> getSystemConfiguration()
		{
			loSystemConfigurationDAO = new SystemConfigurationDAO();

			IList<SystemConfiguration> _SystemConfigList = new List<SystemConfiguration>();

			DataTable _dtTemp = loSystemConfigurationDAO.getSystemConfig();

			foreach (DataRow _dRow in _dtTemp.Rows)
			{ 
			SystemConfiguration _newSystemConfig = new SystemConfiguration();
				_newSystemConfig.Key = _dRow["KEY"].ToString();
				_newSystemConfig.Value = _dRow["VALUE"].ToString();
				_newSystemConfig.Description = _dRow["DESCRIPTION"].ToString();
				_newSystemConfig.Updated_Date = _dRow["UPDATE_DATE"].ToString();
				_newSystemConfig.Updated_By = _dRow["UPDATED_BY"].ToString();

				_SystemConfigList.Add(_newSystemConfig);
			}

			return _SystemConfigList;
		}


		public void updateSystemConfiguration(IList<SystemConfiguration> pNewSystemConfigList)
		{
			loSystemConfigurationDAO = new SystemConfigurationDAO();

			foreach (SystemConfiguration _newSystemConfig in pNewSystemConfigList)
			{
				loSystemConfigurationDAO.updateSystemConfig(_newSystemConfig.Key, _newSystemConfig.Value, _newSystemConfig.Description);
			}

			
		}
		
	}
}
