using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Security.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Security
{
	namespace BusinessLayer
	{
		public class SystemRoleFacade
		{
			
			private SystemRoleDAO loSystemRoleDAO;
			
			public SystemRoleFacade()
			{
			}

			public DataTable GetRoles()
			{
				loSystemRoleDAO = new SystemRoleDAO();
				return loSystemRoleDAO.GetRoles();
			}

			public DataTable GetMenus(string role)
			{
				loSystemRoleDAO = new SystemRoleDAO();
				return loSystemRoleDAO.GetMenus(role);
			}

			public DataTable getRoleUIPrivileges(string pRoleName)
			{
				loSystemRoleDAO = new SystemRoleDAO();
				return loSystemRoleDAO.getRoleUIPrivileges(pRoleName);
			}

			public DataTable getRoleSystemPrivileges(string pRoleName)
			{
				loSystemRoleDAO = new SystemRoleDAO();
				return loSystemRoleDAO.getRoleSystemPrivileges(pRoleName);
			}


			public bool UpdateRoles(Role pRole)
			{
				MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

				try
				{
					loSystemRoleDAO = new SystemRoleDAO();
					
					loSystemRoleDAO.UpdateMenuRoles(pRole, ref _oDBTrans);

					// update ui roles
					loSystemRoleDAO.UpdateUIRoles(pRole, ref _oDBTrans);

					// update role's system privilege
					loSystemRoleDAO.UpdateSystemRolePrivileges(pRole, ref _oDBTrans);

					_oDBTrans.Commit();


					return true;
				}
				catch (Exception ex)
				{
					_oDBTrans.Rollback();
					throw ex;
				}


			}
			
			public bool Is_Menu(string menu)
			{
				loSystemRoleDAO = new SystemRoleDAO();
				return loSystemRoleDAO.Is_Menu(menu);
			}
			
			public bool RemoveMenu(string rolename, string menu)
			{
				loSystemRoleDAO = new SystemRoleDAO();
				return loSystemRoleDAO.RemoveMenu(rolename, menu);
			}


			
		}
	}
}
