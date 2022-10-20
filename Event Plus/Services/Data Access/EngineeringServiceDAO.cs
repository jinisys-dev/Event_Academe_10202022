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
	    public class EngineeringServiceDAO 
		{
            private DataReaderToDatasetConverter oDataConverter;
            private EngineeringService oEngineeringService;

			public EngineeringServiceDAO()
			{
                oDataConverter = new DataReaderToDatasetConverter();
                oEngineeringService = new EngineeringService();
			}
			
			public EngineeringService getEngineeringServices()
			{
				try
				{
					oEngineeringService = new EngineeringService();
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectEngineeringServices(\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oEngineeringService, "EngineeringServices");
					dataAdapter.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oEngineeringService.Tables["EngineeringServices"].Columns["EnggServiceId"];
					oEngineeringService.Tables["EngineeringServices"].PrimaryKey = primaryKey;
					
					return oEngineeringService;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return null;
				}
				finally
				{
					oEngineeringService.Dispose();
				}
			}
			
			public int insertEngineeringService(EngineeringService oEngineeringService)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand insertCommand = new MySqlCommand("call spInsertEngineeringService(\'" + oEngineeringService.gHotelId + "\',\'" + oEngineeringService.EnggServiceID + "\',\'" + oEngineeringService.ServiceName + "\',\'" + oEngineeringService.Description + "\',\'" + oEngineeringService.CreatedBy + "\')", GlobalVariables.gPersistentConnection);
                    rowsAffected=insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(oEngineeringService);
                    }
					
					return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return 0;
				}
			}
			
			public int updateEngineeringService(EngineeringService oEngineeringService)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand updateCommand = new MySqlCommand("call spUpdateEngineeringService(\'" + oEngineeringService.gHotelId + "\',\'" + oEngineeringService.EnggServiceID + "\',\'" + oEngineeringService.ServiceName + "\',\'" + oEngineeringService.Description + "\',\'" + oEngineeringService.UpdatedBy + "\')", GlobalVariables.gPersistentConnection);
                    rowsAffected=updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        updateDataRow(oEngineeringService);
                    }
				
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION: " + ex.Message);
					return 0;
				}
			}
			
			public int deleteEngineeringService(EngineeringService oEngineeringService)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand deleteCommand = new MySqlCommand("call spDeleteEngineeringService(\'" + oEngineeringService.EnggServiceID + "\',\'" + oEngineeringService.UpdatedBy + "\',\'" + oEngineeringService.gHotelId + "\')", GlobalVariables.gPersistentConnection);
                    rowsAffected=deleteCommand.ExecuteNonQuery();

				    return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("err:" + ex.Message);
					return 0;
				}
			}

            private void insertDataRow(EngineeringService oEngineeringService)
            {
                DataRow oDataRow = oEngineeringService.Tables["EngineeringServices"].NewRow();
                oDataRow["EnggServiceId"] = oEngineeringService.EnggServiceID;
                oDataRow["ServiceName"] = oEngineeringService.ServiceName;
                oDataRow["Description"] = oEngineeringService.Description;

                oEngineeringService.Tables["EngineeringServices"].Rows.Add(oDataRow);
                oEngineeringService.Tables["EngineeringServices"].AcceptChanges();
            }

            private void updateDataRow(EngineeringService oEngineeringService)
            {
                DataRow dtRow = oEngineeringService.Tables["EngineeringServices"].Rows.Find(oEngineeringService.EnggServiceID);
                dtRow.BeginEdit();
                dtRow["ServiceName"] = oEngineeringService.ServiceName;
                dtRow["Description"] = oEngineeringService.Description;
                dtRow.EndEdit();
                dtRow.AcceptChanges();
                oEngineeringService.Tables["EngineeringServices"].AcceptChanges();
            }

            private void deleteDataRow(EngineeringService oEngineeringService)
            {
                DataRow row = oEngineeringService.Tables["EngineeringServices"].Rows.Find(oEngineeringService.EnggServiceID);
                oEngineeringService.Tables["EngineeringServices"].Rows.Remove(row);
                oEngineeringService.AcceptChanges();
            }
	
		}
	}

