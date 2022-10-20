using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Security.DataAccessLayer;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		public class RolesFacade
		{
			
			
			private MySqlConnection localConnection;
			private RolesDAO RolesDAO;
			public RolesFacade(MySqlConnection connection)
			{
				localConnection = connection;
			}
			public bool SaveRoles(Role oRoles)
			{
				RolesDAO = new RolesDAO(localConnection);
				return RolesDAO.SaveRoles(oRoles);
			}
			public bool UpdateRoles(Role oRoles)
			{
				RolesDAO = new RolesDAO(localConnection);
				return RolesDAO.UpdateRoles(oRoles);
			}
			public bool DeleteRoles(Role oRoles)
			{
				RolesDAO = new RolesDAO(localConnection);
				return RolesDAO.DeleteRoles(oRoles);
			}
			public Role GetActiveRoles()
			{
				RolesDAO = new RolesDAO(localConnection);
				return RolesDAO.GetActiveRoles();
			}
			
			public RoleCollection getUserRoles(User oUser)
			{
				RolesDAO = new RolesDAO(localConnection);
				return RolesDAO.getUserRoles(oUser);
			}

			public DataTable getSystemPrivileges()
			{
				RolesDAO = new RolesDAO(localConnection);
				return RolesDAO.getSystemPrivileges();
			}
		}
	}
	
}
