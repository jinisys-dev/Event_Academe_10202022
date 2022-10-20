using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Services.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.Services.DataAccessLayer
{
	
		public class HousekeepingTypeDAO
		{
            private HousekeepingType oHousekeepingType;
            private DataReaderToDatasetConverter oDatasetConverter;

    		public HousekeepingTypeDAO()
            {
                oHousekeepingType = new HousekeepingType();
                oDatasetConverter = new DataReaderToDatasetConverter();
            }

			public HousekeepingType getHousekeepingType()
			{
				try
				{
					oHousekeepingType = new HousekeepingType();

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectHousekeepingTypes()", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oHousekeepingType, "HousekeepingTypes");
					dataAdapter.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oHousekeepingType.Tables["HousekeepingTypes"].Columns["Id"];
					oHousekeepingType.Tables["HousekeepingTypes"].PrimaryKey = primaryKey;
					
					return oHousekeepingType;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION: " + ex.Message);
				
				}
				finally
				{
					oHousekeepingType.Dispose();
				}
			}

            public DataTable getHousekeepingTypes()
            {
                DataTable HousekeepingTypeDataTable = new DataTable("HousekeepingTypes");
                try
                {
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectHousekeepingTypes()", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(HousekeepingTypeDataTable);
                    dataAdapter.Dispose();

                    DataColumn[] primaryKey = new DataColumn[1];
                    primaryKey[0] = HousekeepingTypeDataTable.Columns["Id"];
                    HousekeepingTypeDataTable.PrimaryKey = primaryKey;

                    return HousekeepingTypeDataTable;
                }
                catch (Exception ex)
                {
                    throw new Exception("EXCEPTION on getHousekeepingTypes: " + ex.Message);
                   
                }
                finally
                {
                    HousekeepingTypeDataTable.Dispose();
                }
            }
			
			public int insertHousekeepingType(HousekeepingType oHousekeepingType)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand insertCommand = new MySqlCommand("call spHK_InsertHousekeepingType('" 
																		+ oHousekeepingType.Id + "','" 
																		+ oHousekeepingType.Name + "','" 
																		+ oHousekeepingType.Code + "')", GlobalVariables.gPersistentConnection);
					rowsAffected =insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(oHousekeepingType);
                    }
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION:  " + ex.Message);
				
				}
			}
			
			public int updateHousekeepingType(HousekeepingType oHousekeepingType)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand updateCommand = new MySqlCommand("call spHK_UpdateHousekeepingType('" 
																	    + oHousekeepingType.Id + "','" 
																		+ oHousekeepingType.Name + "','" 
																		+ oHousekeepingType.Code + "')", GlobalVariables.gPersistentConnection);
                    rowsAffected=updateCommand.ExecuteNonQuery();
                    updateDataRow(oHousekeepingType);
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION: " + ex.Message);
					
				}
				
			}

			public int deleteHousekeepingType(HousekeepingType oHousekeepingType)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand deleteCommand = new MySqlCommand("call spHK_DeleteHousekeepingType('" 
																		+ oHousekeepingType.Id + "')", GlobalVariables.gPersistentConnection);

                    rowsAffected=deleteCommand.ExecuteNonQuery();
                    DataRow dRow=oHousekeepingType.Tables["HousekeepingTypes"].Rows.Find(oHousekeepingType.Id);
                    oHousekeepingType.Tables["HousekeepingTypes"].Rows.Remove(dRow);
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION: " + ex.Message);
				
				}
			}

            private void insertDataRow(HousekeepingType oHousekeepingType)
            {

                DataRow DataRow = oHousekeepingType.Tables["HousekeepingTypes"].NewRow();

                DataRow["Id"] = oHousekeepingType.Id;
                DataRow["Name"] = oHousekeepingType.Name;
                DataRow["Code"] = oHousekeepingType.Code;
                
                oHousekeepingType.Tables["HousekeepingTypes"].Rows.Add(DataRow);
                oHousekeepingType.Tables["HousekeepingTypes"].AcceptChanges();
            }

            private void updateDataRow(HousekeepingType oHousekeepingType)
            {
                DataRow odRow = oHousekeepingType.Tables["HousekeepingTypes"].Rows.Find(oHousekeepingType.Id);
                odRow.BeginEdit();
                odRow["Id"] = oHousekeepingType.Id;
                odRow["Name"] = oHousekeepingType.Name;
                odRow["Code"] = oHousekeepingType.Code;
                odRow.EndEdit();
                odRow.AcceptChanges();
                oHousekeepingType.Tables["HousekeepingTypes"].AcceptChanges();
            }

            private void deleteDataRow(HousekeepingType oHousekeepingType)
            {
                DataRow row = oHousekeepingType.Tables["HousekeepingTypes"].Rows.Find(oHousekeepingType.Id);
                oHousekeepingType.Tables["HousekeepingTypes"].Rows.Remove(row);
                oHousekeepingType.AcceptChanges();
            }
			
		
		}
	}

