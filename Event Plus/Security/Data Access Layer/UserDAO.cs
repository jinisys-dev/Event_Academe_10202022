using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Security
{
	namespace DataAccessLayer
	{
		public class UserDAO
        {
            #region ""

            string jinisysKey = "j1n15y5";
            string separatorKey = "*";

            #endregion

            private MySqlConnection localConnection;
			public UserDAO(MySqlConnection connection)
			{
				localConnection = connection;
			}
			
			private string connectionStr;
			public UserDAO(string connectionString)
			{
				connectionStr = connectionString;
			}
			
			private Jinisys.Hotel.Security.BusinessLayer.User oUser = new User();
			private DataReaderToDatasetConverter dataSetConverter = new DataReaderToDatasetConverter();
			public Jinisys.Hotel.Security.BusinessLayer.User GetUsers()
			{
				try
				{
					oUser = new Jinisys.Hotel.Security.BusinessLayer.User();
					
					MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spSelectUsers()", localConnection);
					dtAdapter.Fill(oUser, "Users");
					dtAdapter.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oUser.Tables["Users"].Columns["UserId"];
					oUser.Tables["Users"].PrimaryKey = primaryKey;
					
					return oUser;
				}
				catch (Exception ex)
				{
MessageBox.Show("EXCEPTION: @ GetUsers()" + ex.Message);
					return null;
				}
			}

            public Jinisys.Hotel.Security.BusinessLayer.User GetUserRolesAll()
            {
                try
                {
                    oUser = new Jinisys.Hotel.Security.BusinessLayer.User();

                    MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetUserRolesAll('" + GlobalVariables.gHotelId + "')", localConnection);
                    dtAdapter.Fill(oUser, "Users");
                    dtAdapter.Dispose();

                    DataColumn[] primaryKey = new DataColumn[2];
                    primaryKey[0] = oUser.Tables["Users"].Columns["UserId"];
                    primaryKey[1] = oUser.Tables["Users"].Columns["rolename"];
                    oUser.Tables["Users"].PrimaryKey = primaryKey;

                    return oUser;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION: @ GetUserRolesAll()" + ex.Message);
                    return null;
                }
            }
			
			
			public bool InsertUser(User oUser)
			{
				MySqlTransaction trans = localConnection.BeginTransaction();
				try
				{
					Jinisys.Hotel.Security.BusinessLayer.User with_1 = oUser;
					
					MySqlCommand insertCommand = new MySqlCommand("call spInsertUser(\'" + with_1.UserId + "\',\'" + with_1.Password + "\',\'" + with_1.EmployeeIdNo + "\',\'" + with_1.LastName + "\',\'" + with_1.FirstName + "\',\'" + with_1.Department + "\',\'" + with_1.Designation + "\',\'" + with_1.HotelId + "\',\'" + with_1.CreatedBy + "\')", localConnection);
					
					insertCommand.Transaction = trans;
					insertCommand.ExecuteNonQuery();
					
					Role oRole;
					foreach (Role tempLoopVar_oRole in oUser.Roles)
					{
						oRole = tempLoopVar_oRole;
						MySqlCommand insertRole = new MySqlCommand("call spInsertUserRole(\'" + oUser.UserId + "\',\'" + oRole.RoleName + "\',\'" + oUser.HotelId + "\',\'" + oUser.CreatedBy + "\')", localConnection);
						insertRole.Transaction = trans;
						insertRole.ExecuteNonQuery();
					}
					
					DataRow dataRow = with_1.Tables["Users"].NewRow();
					dataRow["UserId"] = with_1.UserId;
					dataRow["EmployeeIdNo"] = with_1.EmployeeIdNo;
					dataRow["LastName"] = with_1.LastName;
					dataRow["FirstName"] = with_1.FirstName;
					dataRow["Department"] = with_1.Department;
					dataRow["Designation"] = with_1.Designation;
					
					with_1.Tables["Users"].Rows.Add(dataRow);
					with_1.Tables["Users"].AcceptChanges();
					
					
					trans.Commit();
					return true;
				}
				catch (Exception exception)
				{
                    if (exception.ToString().Contains("Duplicate entry"))
                    {
                        UpdateUser(oUser);
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        MessageBox.Show("EXCEPTION :  @ InsertUser() " + exception.Message);
                        return false;
                    }
				}
				
			}
			
			
			public bool DeleteUserRoles(User oUser)
			{
				try
				{
					MySqlCommand deleteCommand = new MySqlCommand("call spDeleteUserRoles(\'" + oUser.UserId + "\',\'" + oUser.HotelId + "\')", localConnection);
					deleteCommand.ExecuteNonQuery();
					return true;
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: @ DeleteUserRoles() " + ex.Message);
					return false;
				}
			}
			
			public bool UpdateUser(User oUser)
			{
				MySqlTransaction trans = localConnection.BeginTransaction();
				try
				{

					string _strDeletRole = "call spDeleteUserRoles('" + 
														  oUser.UserId + "','" + 
														  oUser.HotelId + "')";

					MySqlCommand deleteCommand = new MySqlCommand(_strDeletRole, localConnection);
					deleteCommand.Transaction = trans;
					deleteCommand.ExecuteNonQuery();



					string _strUpdate = "call spUpdateUser('" +
											  oUser.UserId + "','" +
											  oUser.EmployeeIdNo + "','" +
											  oUser.LastName + "','" +
											  oUser.FirstName + "','" +
											  oUser.Department + "','" +
											  oUser.Designation + "','" +
											  oUser.HotelId + "')";

                        MySqlCommand updateCommand = new MySqlCommand(_strUpdate, GlobalVariables.gPersistentConnection);
                        updateCommand.Transaction = trans;
                        updateCommand.ExecuteNonQuery();
                    
					
					foreach (Role oRole in oUser.Roles)
					{
						
						string _strInsertRole = "call spInsertUserRole('" + 
													  oUser.UserId + "','" + 
													  oRole.RoleName + "','" + 
													  oUser.HotelId + "','" + 
													  oUser.CreatedBy + "')";

						MySqlCommand insertRole = new MySqlCommand(_strInsertRole, localConnection);
						insertRole.Transaction = trans;
						insertRole.ExecuteNonQuery();
					}
                    
                    // June 21, 2012
                    // Daniel Balagosa
                    // Edited below statements and added a filter
					DataRow dataRow = oUser.Tables["Users"].Rows.Find(oUser.UserId);
                    if (dataRow != null)
                    {
                        dataRow.BeginEdit();
                        dataRow["UserId"] = oUser.UserId;
                        dataRow["EmployeeIdNo"] = oUser.EmployeeIdNo;
                        dataRow["LastName"] = oUser.LastName;
                        dataRow["FirstName"] = oUser.FirstName;
                        dataRow["Department"] = oUser.Department;
                        dataRow["Designation"] = oUser.Designation;

                        dataRow.EndEdit();
                        dataRow.AcceptChanges();

                        oUser.Tables["Users"].AcceptChanges();
                    }                    
                    trans.Commit();

					return true;
					
				}
				catch (Exception ex)
				{
					trans.Rollback();
					MessageBox.Show("EXCEPTION: @ UpdateUser() " + ex.Message);
					return false;
				}
			}
			
			public void DeleteUser(string UserId, User oUser)
			{
                try
                {
                    MySqlCommand deleteCommand = new MySqlCommand("spDeleteUser", GlobalVariables.gPersistentConnection);
                    deleteCommand.CommandType = CommandType.StoredProcedure;

                    MySqlParameter param = new MySqlParameter();
                    param.ParameterName = "pUserId";
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    param.SourceColumn = "UserId";
                    param.Value = UserId;

                    deleteCommand.Parameters.Add(param);

                    deleteCommand.ExecuteNonQuery();

                    object primaryKey = new object();
                    primaryKey = UserId;
                    DataRow row = oUser.Tables["Users"].Rows.Find(primaryKey);
                    oUser.Tables["Users"].Rows.Remove(row);

                    oUser.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION :  @ InsertUser() " + ex.Message);
                }
			}
			
			public bool RemoveUserRole(string userId, string hotelId, string RoleName)
			{
				try
				{
					MySqlCommand removeCommand = new MySqlCommand("call spRemoveUserRole(\'" + userId + "\',\'" + hotelId + "\',\'" + RoleName + "\',\'" + GlobalVariables.gLoggedOnUser + "\')", localConnection);
					removeCommand.ExecuteNonQuery();
					
					return true;
				}
				catch (Exception ex)
				{
MessageBox.Show("EXCEPTION: @ RemoveUserRole() " + ex.Message);
					return false;
				}
			}
			
			
			public string GetOldPassword(User oUser)
			{
				try
				{
					MySqlCommand getPasswordCommand = new MySqlCommand("call spGetUserOldPass(\'" + oUser.UserId + "\',\'" + oUser.HotelId + "\')", localConnection);
					
					return getPasswordCommand.ExecuteScalar().ToString();
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION : @ GetOldPassword " + ex.Message);
					return null;
				}
			}
          
			
			public User VerifyLogin(string UserId, string Password)
			{
				MySqlConnection CONNECTION = new MySqlConnection(connectionStr);
				try
				{
                    CONNECTION.Open();

					oUser = new Jinisys.Hotel.Security.BusinessLayer.User();
					
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spVerifyLogin('" + UserId + "','" + Password + "')", CONNECTION);
					dataAdapter.Fill(oUser, "LoggedUser");
					dataAdapter.Dispose();
					
					GlobalVariables.gPersistentConnection = CONNECTION;
					
					oUser.UserId = oUser.Tables[0].Rows[0]["UserId"].ToString();
					oUser.Password = oUser.Tables[0].Rows[0]["Password"].ToString();
					oUser.EmployeeIdNo = oUser.Tables[0].Rows[0]["EmployeeIdNo"].ToString();
					oUser.LastName = oUser.Tables[0].Rows[0]["LastName"].ToString();
					oUser.FirstName = oUser.Tables[0].Rows[0]["FirstName"].ToString();
					oUser.Department = oUser.Tables[0].Rows[0]["Department"].ToString();
					oUser.Designation = oUser.Tables[0].Rows[0]["Designation"].ToString();
					oUser.HotelId = oUser.Tables[0].Rows[0]["HotelId"].ToString();
					
					// >> assign Roles
					AssignUserRoles(oUser);
					
					// >> assign Menus
					AssignRoleMenus(oUser);
					
					return oUser;
				}
				catch (Exception)
				{
					GlobalVariables.gPersistentConnection = null;
					return null;
				}
				finally
				{
					CONNECTION.Close();
					oUser.Dispose();
				}
			}
			
			private RolesFacade oRolesFacade;
			private void AssignUserRoles(User oUser)
			{
				oRolesFacade = new RolesFacade(GlobalVariables.gPersistentConnection);
				oUser.Roles = oRolesFacade.getUserRoles(oUser);
			}
			
			private MenuFacade oMenuFacade;
			private void AssignRoleMenus(User ouser)
			{
				oMenuFacade = new MenuFacade(GlobalVariables.gPersistentConnection);
				
				Role oRole;
				foreach (Role tempLoopVar_oRole in ouser.Roles)
				{
					oRole = tempLoopVar_oRole;
					MenuCollection oMenuCollection = new MenuCollection();
					oMenuCollection = oMenuFacade.GetRoleMenus(oRole.RoleName, int.Parse(ouser.HotelId) );
					
					oRole.Menus = oMenuCollection;
				}
			}
			
			public bool AuthenticateUser(User oUser)
			{
				try
				{
					MySqlCommand selectCommand = new MySqlCommand("call spAuthenticateUser('" + oUser.UserId + "','" + oUser.Password + "')", localConnection);
					
					oUser.HotelId = selectCommand.ExecuteScalar().ToString();
					if (oUser.HotelId != "")
					{
						oUser.Authenticated = true;

                        //
                        assignUserPersonalInfo(oUser);

                        // >> assign Roles
                        AssignUserRoles(oUser);

                        // >> assign Menus
                        AssignRoleMenus(oUser);
					}
                    return true;
				}
				catch (Exception ex)
				{
					//MessageBox.Show("ExcEPTION: @ AuthenticateUser() " + ex.Message);
				}
                return false;
				
			}

            public bool assignUserPersonalInfo(User a_User)
            {
                try
                {
                    DataTable dtUser = new DataTable("User");

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetLoggedUserPersonalInfo('" + a_User.UserId + "')", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(dtUser);
                    dataAdapter.Dispose();


                    a_User.UserId = dtUser.Rows[0]["UserId"].ToString();
                    //a_User.Password = dtUser.Rows[0]["Password"].ToString();
                    a_User.EmployeeIdNo = dtUser.Rows[0]["EmployeeIdNo"].ToString();
                    a_User.LastName = dtUser.Rows[0]["LastName"].ToString();
                    a_User.FirstName = dtUser.Rows[0]["FirstName"].ToString();
                    a_User.Department = dtUser.Rows[0]["Department"].ToString();
                    a_User.Designation = dtUser.Rows[0]["Designation"].ToString();
                    a_User.HotelId = dtUser.Rows[0]["HotelId"].ToString();
                    a_User.LoggedTime = DateTime.Now;


                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }


            public bool changeUserPassword(User oUser)
            {
                int affectedRow = 0;

                try
                {
                    MySqlCommand updateCommand = new MySqlCommand("call spChangeUserPassword('" + oUser.UserId + "','" + oUser.Password + "')", localConnection);
                    affectedRow = updateCommand.ExecuteNonQuery();

                    if (affectedRow > 0)
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
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            public DataTable loadSystemConfig()
            {
                DataTable dtSystemConfig = new DataTable();

                try
                {
                    MySqlDataAdapter selectAdapter = new MySqlDataAdapter("call spSelectSystemConfig()", localConnection);
                    selectAdapter.Fill(dtSystemConfig);

                    return dtSystemConfig;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

			public DataTable loadCountryList()
			{
				DataTable dtCountryList = new DataTable();

				try
				{
					MySqlDataAdapter selectAdapter = new MySqlDataAdapter("call spSelectCountries()", localConnection);
					selectAdapter.Fill(dtCountryList);

					return dtCountryList;
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}


			public int resetPassword(string pUserId, string pPassword)
			{
				int _rowsAffected = 0;

				try 
				{
					string _strResetPassword = "call spResetUserPassword('" + 
						                             pUserId + "','" + 
													 pPassword + "','" + 
													 GlobalVariables.gHotelId + "','" + 
													 GlobalVariables.gLoggedOnUser + "')";

					MySqlCommand _resetCommand = new MySqlCommand(_strResetPassword, GlobalVariables.gPersistentConnection);
					_rowsAffected = _resetCommand.ExecuteNonQuery();

					return _rowsAffected;

				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

            public string getExpiryDate()
            {
                string query = "Select aes_decrypt(`Value`,'" + jinisysKey + "') from system_config where `key`='_APP_LICENSE';";

                MySqlCommand command = new MySqlCommand(query, localConnection);
                string expiryDate = command.ExecuteScalar().ToString();
                expiryDate = expiryDate.Replace("*", "/");

                return expiryDate;
            }

            public DataTable getUsersTable()
            {
                // Daniel Balagosa
                // June 20, 2012
                // Populates Event Officer and Marketing Officer in GroupReservationUI
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spSelectUsers()", GlobalVariables.gPersistentConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error @UserDAO.getUsersTable\r\n" + ex.Message);
                }
                finally
                {
                    _adapter.Dispose();
                }
            }

            public bool assignUserInfo(ref User pUser)
            {
                try
                {
                    //DataTable dtUser = new DataTable("User");

                    //MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetLoggedUserPersonalInfo('" + pUser.UserId + "')", GlobalVariables.gPersistentConnection);
                    //dataAdapter.Fill(dtUser);
                    //dataAdapter.Dispose();

                    //pUser.UserId = dtUser.Rows[0]["UserId"].ToString();
                    //pUser.Password = dtUser.Rows[0]["Password"].ToString();
                    //pUser.EmployeeIdNo = dtUser.Rows[0]["EmployeeIdNo"].ToString();
                    //pUser.LastName = dtUser.Rows[0]["Lastname"].ToString();
                    //pUser.FirstName = dtUser.Rows[0]["Firstname"].ToString();
                    //pUser.Department = dtUser.Rows[0]["Department"].ToString();
                    //pUser.Designation = dtUser.Rows[0]["Designation"].ToString();
                    //pUser.HotelId = dtUser.Rows[0]["HotelId"].ToString();
                    //pUser.LoggedTime = DateTime.Now;

                    assignUserPersonalInfo(pUser);
                    AssignUserRoles(pUser);
                    AssignRoleMenus(pUser);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
		}
	}
}
