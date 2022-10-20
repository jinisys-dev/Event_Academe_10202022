using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.DataAccessLayer;


namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		public class MenuFacade
		{
			
			
			private MySqlConnection localConnection;
			public MenuFacade(MySqlConnection connection)
			{
				localConnection = connection;
			}
			
			private MenuDao oMenuDao;
			public MenuCollection GetRoleMenus(string roleName, int hotelId)
			{
				oMenuDao = new MenuDao(localConnection);
				return oMenuDao.GetRoleMenus(roleName, hotelId);
			}
			
		
		}
	}
}
