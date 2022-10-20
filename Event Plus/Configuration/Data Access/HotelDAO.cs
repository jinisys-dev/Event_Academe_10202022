using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
	    public class HotelDAO 
		{
	    	public HotelDAO(){}

			public int insertObject(HotelClass a_Hotel)
			{
				try
				{
                    int rowsAffected = 0;
                    string sql = "CALL spInsertHotel(" + a_Hotel.HotelID + ",\'" + a_Hotel.HotelName + "\'," + a_Hotel.NoOfFloors + "," + a_Hotel.NoOfRooms + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
					MySqlCommand insertCommand = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                    rowsAffected=insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        insertDataRow(a_Hotel);
                    }
                   
                    return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Database Insert Exception");
                    return 0;
				}
			}
			public int updateObject(HotelClass a_Hotel)
			{
			    try
                {
                    int rowsAffected = 0;
                    string sql = "CALL spupdateHotel(" + a_Hotel.HotelID + ",\'" + a_Hotel.HotelName + "\'," + a_Hotel.NoOfFloors + "," + a_Hotel.NoOfRooms + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
				    MySqlCommand updateCommand = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                    
                    rowsAffected = updateCommand.ExecuteNonQuery();
                    
                    if (rowsAffected > 0)
                    {
                        updateDataRow(a_Hotel);
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
				HotelClass a_Hotel = new HotelClass();
				try
				{
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("Call spSelectHotel()", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(a_Hotel, "Hotel");
					dataAdapter.Dispose();
					DataColumn[] primarykey = new DataColumn[1];
					primarykey[0] = a_Hotel.Tables["Hotel"].Columns["HotelID"];
					a_Hotel.Tables["Hotel"].PrimaryKey = primarykey;

					return a_Hotel;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @GetActiveHotel():" + ex.Message);
					return null;
				}
			}
			public int deleteObject(HotelClass a_Hotel)
			{
				try
                {
                   int rowsAffected = 0;
                   MySqlCommand deleteCommand = new MySqlCommand("CALL spdeleteHotel(" + a_Hotel.HotelID + ")", GlobalVariables.gPersistentConnection);
                   rowsAffected = deleteCommand.ExecuteNonQuery();
                   
                    if (rowsAffected > 0)
                    {
                        deleteDataRow(a_Hotel);
                    }
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Update Exception");
                    return 0;
                }
			}

            public void insertDataRow(HotelClass a_Hotel)
            {
                try
                {
                    DataRow dRow = a_Hotel.Tables["Hotel"].NewRow();
					dRow["HotelID"] = a_Hotel.HotelID;
					dRow["HotelName"] = a_Hotel.HotelName;
					dRow["NoOfFloors"] = a_Hotel.NoOfFloors;
					dRow["NoOfRooms"] = a_Hotel.NoOfRooms;
					a_Hotel.Tables["Hotel"].Rows.Add(dRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Data Row Exception");
                }
             }

            public void deleteDataRow(HotelClass a_Hotel)
            {
                try
                {
                    object primarykey = new object();
                    primarykey = a_Hotel.HotelID;
					
					DataRow row = a_Hotel.Tables["Hotel"].Rows.Find(primarykey);
					a_Hotel.Tables["Hotel"].Rows.Remove(row);
					a_Hotel.Tables["Hotel"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Data Row Exception");
                }

            }
            public void updateDataRow(HotelClass a_Hotel)
            {
                try
                {
                    DataRow dRow = a_Hotel.Tables["Hotel"].Rows.Find(a_Hotel.HotelID);
					dRow.BeginEdit();
					dRow["HotelID"] = a_Hotel.HotelID;
					dRow["HotelName"] = a_Hotel.HotelName;
					dRow["NoOfFloors"] = a_Hotel.NoOfFloors;
					dRow["NoOfRooms"] = a_Hotel.NoOfRooms;
					dRow.EndEdit();
					dRow.AcceptChanges();
					a_Hotel.Tables["Hotel"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Data Row Exception");
                }

            }

		}
	}
	

