using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Security.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Jinisys.Hotel.Security
{
	namespace DataAccessLayer
	{
		
		
		public class SystemRoleDAO
		{
			
			//private MySqlConnection localConnection;
			public SystemRoleDAO()
			{
				//localConnection = connection;
			}
			public DataTable GetRoles()
			{
				DataTable dTable = new DataTable();
				try
				{
					string sql = "Call spSelectRoles(" + GlobalVariables.gHotelId + ")";
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(dTable);
					dataAdapter.Dispose();
					return dTable;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @GetRoles():" + ex.Message);
					return null;
				}
			}
			public DataTable GetMenus(string role)
			{
				DataTable dTable = new DataTable();
				try
				{
					string sql = "Call spSelectRoleMenu('" + role + "'," + GlobalVariables.gHotelId + ")";
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(dTable);
					dataAdapter.Dispose();
					return dTable;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @GetMenus():" + ex.Message);
					return null;
				}
			}
			public bool Is_Menu(string menu)
			{
				DataTable dTable = new DataTable();
				try
				{
					string sql = "call spGetMenus(\'" + menu + "\')";
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(dTable);
					dataAdapter.Dispose();
					if (dTable.Rows.Count > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @GetMenus():" + ex.Message);
					return false;
				}
			}

			public void UpdateMenuRoles(Role pRole, ref MySqlTransaction pDBTrans )
			{
				try
				{
					

					RoleMenuCollection pRoleMenus = pRole.RoleMenuCollection;
					MySqlCommand insertCommand;// = new MySqlCommand();

					foreach (RoleMenu _oRoleMenu in pRoleMenus)
					{
						int _enable = _oRoleMenu.IsEnable == true ? 1 : 0;
						string _strInsert = "call spInsertRoleMenu('" + 
							                     _oRoleMenu.RoleName + "','" + 
												 _oRoleMenu.Menu + "'," + 
												 _enable + "," + 
												 GlobalVariables.gHotelId + ",'" + 
												 GlobalVariables.gLoggedOnUser + "')"; ;

						insertCommand = new MySqlCommand(_strInsert, GlobalVariables.gPersistentConnection);
						insertCommand.Transaction = pDBTrans;

						insertCommand.ExecuteNonQuery();
					}
					
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public void UpdateUIRoles(Role pRole, ref MySqlTransaction pDBTrans)
			{
				try
				{


					IList<RoleUIPrivilege> _RoleUIPrivileges = pRole.RoleUIPrivileges;
					MySqlCommand insertCommand;

					foreach (RoleUIPrivilege _oRoleUIPrivilege in _RoleUIPrivileges)
					{
						string _strInsert = "call spInsertRoleUIPrivilege('" +
												 _oRoleUIPrivilege.RoleName + "','" +
												 _oRoleUIPrivilege.Module + "','" +
												 _oRoleUIPrivilege.FormName + "','" +
												 _oRoleUIPrivilege.ButtonName + "'," +
												 _oRoleUIPrivilege.IsVisible + ",'" +
												 GlobalVariables.gLoggedOnUser + "')"; ;

						insertCommand = new MySqlCommand(_strInsert, GlobalVariables.gPersistentConnection);
						insertCommand.Transaction = pDBTrans;

						insertCommand.ExecuteNonQuery();
					}

				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public void UpdateSystemRolePrivileges(Role pRole, ref MySqlTransaction pDBTrans)
			{
				try
				{


					IList<Role_Privilege> _RolePrivileges = pRole.Privileges;
					MySqlCommand insertCommand;

					foreach (Role_Privilege _oRolePrivilege in _RolePrivileges)
					{
						string _strInsert = "call spInsertRoleSystemPrivilege('" +
												 GlobalVariables.gHotelId + "','" +
												 _oRolePrivilege.RoleName + "','" +
												 _oRolePrivilege.Privilege + "','" +
												 _oRolePrivilege.Allowed + "','" +
												 GlobalVariables.gLoggedOnUser + "')"; ;

						insertCommand = new MySqlCommand(_strInsert, GlobalVariables.gPersistentConnection);
						insertCommand.Transaction = pDBTrans;

						insertCommand.ExecuteNonQuery();
					}

				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


			public bool RemoveMenu(string rolename, string menu)
			{
				try
				{
					string _strRemove = "call spDeleteIndividualRoleMenu('" + 
						                      rolename + "','" + 
											  menu + "'," + 
											  GlobalVariables.gHotelId + ")";

					MySqlCommand command = new MySqlCommand(_strRemove, GlobalVariables.gPersistentConnection);
					command.ExecuteNonQuery();

					return true;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @RemoveMenu():" + ex.Message);
					return false;
				}
			}

			public DataTable getRoleUIPrivileges(string pRoleName)
			{
				DataTable dTable = new DataTable();
				try
				{
					DataTable dtRoleUIPrivileges = new DataTable();

					string _sqlStr = "call spGetRoleUIPrivileges('" + pRoleName + "')";

					MySqlDataAdapter dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
					dtAdapter.Fill(dtRoleUIPrivileges);

					return dtRoleUIPrivileges;

				}
				catch (Exception ex)
				{
					throw ex;
				}

			}

			public DataTable getRoleSystemPrivileges(string pRoleName)
			{
				DataTable dTable = new DataTable();
				try
				{
					DataTable dtRoleSYstemPrivileges = new DataTable();

					string _sqlStr = "call spGetRoleSystemPrivileges('" + pRoleName + "')";

					MySqlDataAdapter dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
					dtAdapter.Fill(dtRoleSYstemPrivileges);

					return dtRoleSYstemPrivileges;

				}
				catch (Exception ex)
				{
					throw ex;
				}

			}
		}
	}
}
