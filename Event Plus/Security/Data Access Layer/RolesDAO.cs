using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
//using AxVSFlex7L;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Security.BusinessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.Security
{
	namespace DataAccessLayer
	{
		public class RolesDAO
		{
			
			
			private MySqlConnection localConnection;
			public RolesDAO(MySqlConnection connection)
			{
				localConnection = connection;
			}

			public bool SaveRoles(Role oRole)
			{
				try
				{
					string sql = "call spInsertRole('"
								  + oRole.RoleName + "','"
								  + oRole.Description + "'," 
								  + GlobalVariables.gHotelId + ",'" 
								  + GlobalVariables.gLoggedOnUser + "')";

					MySqlCommand command = new MySqlCommand(sql, localConnection);
					command.ExecuteNonQuery();
					DataRow dRow = oRole.Tables["Role"].NewRow();
					dRow["RoleName"] = oRole.RoleName;
					dRow["Description"] = oRole.Description;
					oRole.Tables["Role"].Rows.Add(dRow);
					return true;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @SaveRoles():" + ex.Message);
					return false;
				}
				
			}

			public bool UpdateRoles(Role oRole)
			{
				try
				{
					string sql = "call spUpdateRole('"
									   + oRole.RoleName + "','"
									   + oRole.Description + "'," 
									   + GlobalVariables.gHotelId + ",'" 
									   + GlobalVariables.gLoggedOnUser + "')";

					MySqlCommand command = new MySqlCommand(sql, localConnection);
					command.ExecuteNonQuery();
					DataRow dRow = oRole.Tables["Role"].Rows.Find(oRole.RoleName);
					dRow.BeginEdit();
					dRow["RoleName"] = oRole.RoleName;
					dRow["Description"] = oRole.Description;
					dRow.EndEdit();
					dRow.AcceptChanges();
					oRole.Tables["Role"].AcceptChanges();

					return true;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @UpdateRoles():" + ex.Message);
					return false;
				}
			}

			public bool DeleteRoles(Role oRole)
			{
				try
				{
					string sql = "call spDeleteRole('"
									   + oRole.RoleName + "'," 
									   + GlobalVariables.gHotelId + ")";

					MySqlCommand command = new MySqlCommand(sql, localConnection);
					command.ExecuteNonQuery();
					object primarykey = new object();
					primarykey = oRole.RoleName;
					DataRow dRow = oRole.Tables["Role"].Rows.Find(primarykey);
					oRole.Tables["Role"].Rows.Remove(dRow);
					oRole.Tables["Role"].AcceptChanges();
					return true;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @DeleteRoles():" + ex.Message);
					return false;
				}
			}

			public Role GetActiveRoles()
			{
				Role role = new Role();
				try
				{
					string sql = "call spSelectRoles(" 
									   + GlobalVariables.gHotelId + ")";

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, localConnection);
					dataAdapter.Fill(role, "Role");
					dataAdapter.Dispose();
					DataColumn[] primarykey = new DataColumn[1];
					primarykey[0] = role.Tables["Role"].Columns["RoleName"];
					role.Tables["Role"].PrimaryKey = primarykey;
					return role;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @GetActiveRoles():" + ex.Message);
					return null;
				}
			}
			
			public RoleCollection getUserRoles(User oUser)
			{
				RoleCollection oRoleCollection = new RoleCollection();
				try
				{
					DataSet dsRoles = new DataSet();
					string _sqlStr = "call spGetUserRoles('" 
										   + oUser.UserId + "','" 
										   + oUser.HotelId + "')";

					MySqlDataAdapter dtAdapter = new MySqlDataAdapter(_sqlStr, localConnection);
					dtAdapter.Fill(dsRoles, "Roles");
					
					DataRow dtRow;
					foreach (DataRow tempLoopVar_dtRow in dsRoles.Tables[0].Rows)
					{
						dtRow = tempLoopVar_dtRow;
						Role oRole = new Role();
						oRole.RoleName = dtRow["RoleName"].ToString();
						oRole.Description = dtRow["Description"].ToString();
						
                        //get ROle Privileges here
                        //oRole.Privileges
                        IList<Role_Privilege> rolePrivileges = new List<Role_Privilege>();

                        DataTable dtRolePrivileges = new DataTable();
						string _sqlStrRole = "call spGetRolePrivileges('" 
												   + oRole.RoleName + "','" 
												   + oUser.HotelId + "')";

						dtAdapter = new MySqlDataAdapter(_sqlStrRole, localConnection);
                        dtAdapter.Fill(dtRolePrivileges);

                        foreach (DataRow dRow in dtRolePrivileges.Rows)
                        {
                            Role_Privilege mRolePrivilege = new Role_Privilege();
                            mRolePrivilege.RoleName = oRole.RoleName;
							mRolePrivilege.Privilege = dRow["privilegeDescription"].ToString();

							mRolePrivilege.Allowed = int.Parse(dRow["isAllowed"].ToString()); //dRow["isallowed"].ToString() );


                            rolePrivileges.Add(mRolePrivilege);
                        }
                        oRole.Privileges = rolePrivileges;


						// get Role UI privileges
						IList<RoleUIPrivilege> _oRoleUIPrivileges = new List<RoleUIPrivilege>();
						DataTable dtRoleUIPrivileges = new DataTable();
						dtAdapter = new MySqlDataAdapter("call spGetRoleUIPrivileges('" + oRole.RoleName + "')", localConnection);
						dtAdapter.Fill(dtRoleUIPrivileges);

						foreach (DataRow _dRow in dtRoleUIPrivileges.Rows)
						{
							RoleUIPrivilege _newRoleUIPrivilege = new RoleUIPrivilege();
							_newRoleUIPrivilege.RoleName = _dRow["RoleName"].ToString();
							_newRoleUIPrivilege.Module = _dRow["Module"].ToString();
							_newRoleUIPrivilege.FormName = _dRow["FormName"].ToString();
							_newRoleUIPrivilege.ButtonName = _dRow["ButtonName"].ToString();
							_newRoleUIPrivilege.IsVisible = int.Parse( _dRow["IsVisible"].ToString() );


							_oRoleUIPrivileges.Add(_newRoleUIPrivilege);
						}
						oRole.RoleUIPrivileges = _oRoleUIPrivileges;


						oRoleCollection.Add(oRole);
					}
					
					return oRoleCollection;
					
				}
				catch (Exception ex)
				{
                    MessageBox.Show("EXCEPTION: @ getUserRoles() " + ex.Message);
					return null;
				}
			}


			public DataTable getSystemPrivileges()
			{
				try
				{
					DataTable _dtTemp = new DataTable();
					string _sqlStr = "call spGetSystemPrivileges()";


					MySqlDataAdapter _dtAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
					_dtAdapter.Fill(_dtTemp);

					return _dtTemp;

				}
				catch(Exception ex)
				{
					throw ex;
				}

			}

		}
	}
	
}
