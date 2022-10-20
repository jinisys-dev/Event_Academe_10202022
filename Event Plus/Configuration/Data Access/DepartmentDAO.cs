using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
	
		public class DepartmentDAO 
		{
			public DepartmentDAO(){}

            public int insertObject(Department a_Department)
			{
				try
				{
                    int rowsAffected = 0;
                   string sql = "Call spInsertDepartment(\'" + a_Department.DepartmentID + "\',\'" + a_Department.Name + "\'," + GlobalVariables.gHotelId + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
					MySqlCommand command = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                    rowsAffected=command.ExecuteNonQuery();
                   if (rowsAffected > 0)
                    {
                        insertDataRow(a_Department);
                    }

                    return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Database Insert Exception");
                    return 0;
				}
			}
			public int updateObject(ref Department a_Department)
			{
				    try
                    {
                        int rowsAffected = 0;
                        string sql = "Call spupdateDepartment('" + a_Department.DepartmentID + "','" + a_Department.Name + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
                        MySqlCommand updateCommand = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                        
                        rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            updateDataRow(a_Department);
                        }

                        return rowsAffected;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Database Update Exception");
                        return 0;
                    }
				
			}
			public int deleteObject(Department a_Department)
			{
				try
                {
                    int rowsAffected = 0;
                    string sql = "Call spdeleteDepartment(\'" + a_Department.DepartmentID + "\'," + GlobalVariables.gHotelId + ")";
                    MySqlCommand deleteCommand = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                    
                    rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        deleteDataRow(a_Department);
                    }
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Update Exception");
                    return 0;
                }
			}
			public object loadObject()
			{
				Department new_dep = new Department();
				try
				{
					string sql = "Call spSelectDepartments(" + GlobalVariables.gHotelId + ")";
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);

					dataAdapter.Fill(new_dep, "Department");
					dataAdapter.Dispose();
					
                    DataColumn[] primarykey = new DataColumn[1];
					primarykey[0] = new_dep.Tables["Department"].Columns["DeptId"];
					new_dep.Tables["Department"].PrimaryKey = primarykey;
					
                    return new_dep;
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                    return null;
				}
			}

            public void insertDataRow(Department a_Department)
            {
                try
                {
                    DataRow dRow = a_Department.Tables["Department"].NewRow();
                    dRow["DeptId"] = a_Department.DepartmentID;
                    dRow["Name"] = a_Department.Name;
                    a_Department.Tables["Department"].Rows.Add(dRow);
                    a_Department.Tables["Department"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Data Row Exception");
                }
             }

            public void deleteDataRow(Department a_Department)
            {
                try
                {
                    DataRow dRow = a_Department.Tables["Department"].Rows.Find(a_Department.DepartmentID);
                    a_Department.Tables["Department"].Rows.Remove(dRow);
                    a_Department.Tables["Department"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Data Row Exception");
                }

            }
            public void updateDataRow(Department a_Department)
            {
                try
                {
                    DataRow dRow = a_Department.Tables["Department"].Rows.Find(a_Department.DepartmentID);
                    dRow.BeginEdit();
                    dRow["DeptId"] = a_Department.DepartmentID;
                    dRow["Name"] = a_Department.Name;
                    dRow.EndEdit();
                    dRow.AcceptChanges();
                    a_Department.Tables["Department"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Data Row Exception");
                }

            }

			
		}
	}

