using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Services.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.Services.DataAccessLayer
{
	
		public class HouseKeeperDAO
		{
            private HouseKeeper oHouseKeeper;
            private DataReaderToDatasetConverter oDatasetConverter;

    		public HouseKeeperDAO()
            {
                oHouseKeeper = new HouseKeeper();
                oDatasetConverter = new DataReaderToDatasetConverter();
            }

			public HouseKeeper getHouseKeeper()
			{
				try
				{
					oHouseKeeper = new HouseKeeper();
					
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectHouseKeepers('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oHouseKeeper, "Housekeepers");
					dataAdapter.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oHouseKeeper.Tables["HouseKeepers"].Columns["HouseKeeperId"];
					oHouseKeeper.Tables["HouseKeepers"].PrimaryKey = primaryKey;
					
					return oHouseKeeper;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return null;
				}
				finally
				{
					oHouseKeeper.Dispose();
				}
			}
			
			public int insertHouseKeeper(HouseKeeper oHouseKeeper)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand insertCommand = new MySqlCommand("call spInsertHousekeeper(\'" + oHouseKeeper.gHotelId + "\',\'" + oHouseKeeper.HouseKeeperId + "\',\'" + oHouseKeeper.LastName + "\',\'" + oHouseKeeper.FirstName + "\',\'" + oHouseKeeper.MiddleName + "\',\'" + oHouseKeeper.CreatedBy + "\')", GlobalVariables.gPersistentConnection);
					rowsAffected =insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(oHouseKeeper);
                    }
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION:  " + ex.Message);
					return 0;
				}
			}
			
			public int updateHouseKeeper(HouseKeeper oHouseKeeper)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand updateCommand = new MySqlCommand("call spUpdateHouseKeeper(\'" + oHouseKeeper.gHotelId + "\',\'" + oHouseKeeper.HouseKeeperId + "\',\'" + oHouseKeeper.LastName + "\',\'" + oHouseKeeper.FirstName + "\',\'" + oHouseKeeper.MiddleName + "\',\'" + oHouseKeeper.UpdatedBy + "\')", GlobalVariables.gPersistentConnection);
                    rowsAffected=updateCommand.ExecuteNonQuery();
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return 0;
				}
				
			}

			public int deleteHouseKeeper(HouseKeeper oHouseKeeper)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand deleteCommand = new MySqlCommand("call spDeleteHousekeeper(\'" + oHouseKeeper.HouseKeeperId + "\',\'" + oHouseKeeper.UpdatedBy + "\',\'" + oHouseKeeper.gHotelId + "\')", GlobalVariables.gPersistentConnection);
                    rowsAffected=deleteCommand.ExecuteNonQuery();
                    
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return 0;
				}
			}

            private void insertDataRow(HouseKeeper oHouseKeeper)
            {

                DataRow DataRow = oHouseKeeper.Tables["HouseKeepers"].NewRow();

                DataRow["HouseKeeperId"] = oHouseKeeper.HouseKeeperId;
                DataRow["LastName"] = oHouseKeeper.LastName;
                DataRow["FirstName"] = oHouseKeeper.FirstName;
                DataRow["MiddleName"] = oHouseKeeper.MiddleName;

                oHouseKeeper.Tables["HouseKeepers"].Rows.Add(DataRow);
                oHouseKeeper.Tables["HouseKeepers"].AcceptChanges();
            }

            private void updateDataRow(HouseKeeper oHouseKeeper)
            {
                DataRow odRow = oHouseKeeper.Tables["HouseKeepers"].Rows.Find(oHouseKeeper.HouseKeeperId);
                odRow.BeginEdit();
                odRow["FirstName"] = oHouseKeeper.FirstName;
                odRow["LastName"] = oHouseKeeper.LastName;
                odRow["MiddleName"] = oHouseKeeper.MiddleName;
                odRow.EndEdit();
                odRow.AcceptChanges();
                oHouseKeeper.Tables["HouseKeepers"].AcceptChanges();
            }

            private void deleteDataRow(HouseKeeper oHouseKeeper)
            {
                DataRow row = oHouseKeeper.Tables["HouseKeepers"].Rows.Find(oHouseKeeper.HouseKeeperId);
                oHouseKeeper.Tables["HouseKeepers"].Rows.Remove(row);
                oHouseKeeper.AcceptChanges();
            }

			public string getSupervisorFullname(string hkID, string pin)
			{
				try
				{

					string _sqlStr = "call spHK_GetSupervisorFullName('" 
										   + hkID + "','" 
										   + pin + "')";

					MySqlCommand cmdSelect = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

					string name = cmdSelect.ExecuteScalar().ToString();
					return name;
				}
				catch (Exception ex)
				{
					throw new Exception("Exception @" + ex.Message);

				}

			}

			public string getSupervisorFullname(string hkID, string pin, MySqlConnection con)
			{
				try
				{
					GlobalVariables.gPersistentConnection = con;

					string _sqlStr = "call spHK_GetSupervisorFullName('"
										   + hkID + "','"
										   + pin + "')";


					MySqlCommand cmdSelect = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

					string name = cmdSelect.ExecuteScalar().ToString();
					return name;
				}
				catch (Exception ex)
				{
					throw new Exception("Exception @" + ex.Message);

				}

			}
		
		}
	}

