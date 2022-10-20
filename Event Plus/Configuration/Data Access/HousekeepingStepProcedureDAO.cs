using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
	
		public class HousekeepingStepProcedureDAO
		{
            private HousekeepingStepProcedure oStepProcedure;
            private DataReaderToDatasetConverter oDatasetConverter;

    		public HousekeepingStepProcedureDAO()
            {
                oStepProcedure = new HousekeepingStepProcedure();
                oDatasetConverter = new DataReaderToDatasetConverter();
            }

			public HousekeepingStepProcedure getStepProcedure()
			{
				try
				{
					oStepProcedure = new HousekeepingStepProcedure();

					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectStepProcedures()", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oStepProcedure, "StepProcedures");
					dataAdapter.Dispose();
					
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oStepProcedure.Tables["StepProcedures"].Columns["Id"];
					oStepProcedure.Tables["StepProcedures"].PrimaryKey = primaryKey;
					
					return oStepProcedure;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION: " + ex.Message);
				
				}
				finally
				{
					oStepProcedure.Dispose();
				}
			}
            public DataTable getAfterStepProcedures()
            {
                DataTable AfterStepProcedureDataTable = new DataTable("AfterStepProcedures");
                try
                {


					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectAfterStepProcedures()", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(AfterStepProcedureDataTable);
                    dataAdapter.Dispose();

                    DataColumn[] primaryKey = new DataColumn[1];
                    primaryKey[0] = AfterStepProcedureDataTable.Columns["Id"];
                    AfterStepProcedureDataTable.PrimaryKey = primaryKey;

                    return AfterStepProcedureDataTable;
                }
                catch (Exception ex)
                {
                    throw new Exception("EXCEPTION on getAfterStepProcedures: " + ex.Message);
               
                }
                finally
                {
                    AfterStepProcedureDataTable.Dispose();
                }
            }

            public DataTable getVerifyStepProcedures()
            {
                DataTable VerifyStepProcedures = new DataTable("VerifyStepProcedures");
                try
                {


					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectVerifyStepProcedures()", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(VerifyStepProcedures);
                    dataAdapter.Dispose();

                    DataColumn[] primaryKey = new DataColumn[1];
                    primaryKey[0] = VerifyStepProcedures.Columns["Id"];
                    VerifyStepProcedures.PrimaryKey = primaryKey;

                    return VerifyStepProcedures;
                }
                catch (Exception ex)
                {
                    throw new Exception("EXCEPTION on getVerifyStepProcedures: " + ex.Message);
                   
                }
                finally
                {
                    VerifyStepProcedures.Dispose();
                }
            }

            public DataTable getMiniBarSalesStepProcedures()
            {
                DataTable MiniBarSalesStepProcedures = new DataTable("MiniBarSalesStepProcedures");
                try
                {
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectMiniBarSalesStepProcedures()", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(MiniBarSalesStepProcedures);
                    dataAdapter.Dispose();

                    DataColumn[] primaryKey = new DataColumn[1];
                    primaryKey[0] = MiniBarSalesStepProcedures.Columns["Id"];
                    MiniBarSalesStepProcedures.PrimaryKey = primaryKey;

                    return MiniBarSalesStepProcedures;
                }
                catch (Exception ex)
                {
                    throw new Exception("EXCEPTION on getMiniBarSalesStepProcedures: " + ex.Message);

                }
                finally
                {
                    MiniBarSalesStepProcedures.Dispose();
                }
            }

            public DataTable getBeforeStepProcedures()
            {
                DataTable BeforeStepProcedureDataTable = new DataTable("BeforeStepProcedures");
                try
                {


					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectBeforeStepProcedures()", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(BeforeStepProcedureDataTable);
                    dataAdapter.Dispose();

                    DataColumn[] primaryKey = new DataColumn[1];
                    primaryKey[0] = BeforeStepProcedureDataTable.Columns["Id"];
                    BeforeStepProcedureDataTable.PrimaryKey = primaryKey;

                    return BeforeStepProcedureDataTable;
                }
                catch (Exception ex)
                {
                    throw new Exception("EXCEPTION on getAfterStepProcedures: " + ex.Message);
                   
                }
                finally
                {
                    BeforeStepProcedureDataTable.Dispose();
                }
            }

			public int insertStepProcedure(HousekeepingStepProcedure oStepProcedure)
			{
				try
				{
                    int rowsAffected = 0;
                    string var = (oStepProcedure.UseSoundFile == true)? "1" : "0";
                    string var1 = oStepProcedure.isBefore ? "1" : "0";
					MySqlCommand insertCommand = new MySqlCommand("call spHK_InsertStepProcedure('" 
																		+ oStepProcedure.Id + "','" 
																		+ oStepProcedure.Name + "','" 
																		+ var + "','" 
																		+ oStepProcedure.SoundFile + "','" 
																		+ oStepProcedure.TextToSpeak + "','" 
																		+ oStepProcedure.Rank + "','" 
																		+ var1 + "','" 
																		+ oStepProcedure.maxDigit + "','" 
																		+ oStepProcedure.ExpectedDigit + "')", GlobalVariables.gPersistentConnection);
					rowsAffected =insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(oStepProcedure);
                    }
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION:  " + ex.Message);
					
				}
			}

			public int updateStepProcedure(HousekeepingStepProcedure oStepProcedure)
			{
				try
				{
                    int rowsAffected = 0;
                    string var = (oStepProcedure.UseSoundFile)? "1" : "0";
                    string var1 = (oStepProcedure.isBefore) ? "1" : "0";
					MySqlCommand updateCommand = new MySqlCommand("call spHK_UpdateStepProcedure('" 
																		+ oStepProcedure.Id + "','" 
																		+ oStepProcedure.Name + "','" 
																		+ var + "','" 
																		+ oStepProcedure.SoundFile + "','" 
																		+ oStepProcedure.TextToSpeak + "','" 
																		+ oStepProcedure.Rank + "','" 
																		+ var1 + "','" 
																		+ oStepProcedure.maxDigit + "','" 
																		+ oStepProcedure.ExpectedDigit + "')", GlobalVariables.gPersistentConnection);
                    rowsAffected=updateCommand.ExecuteNonQuery();
                    updateDataRow(oStepProcedure);
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION: " + ex.Message);
					
				}
				
			}

			public int deleteStepProcedure(HousekeepingStepProcedure oStepProcedure)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand deleteCommand = new MySqlCommand("call spHK_DeleteStepProcedure('" 
																		+ oStepProcedure.Id + "')", GlobalVariables.gPersistentConnection);
                    rowsAffected=deleteCommand.ExecuteNonQuery();
                    deleteDataRow(oStepProcedure);
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					throw new Exception("EXCEPTION: " + ex.Message);
					
				}
			}

			private void insertDataRow(HousekeepingStepProcedure oStepProcedure)
            {

                DataRow oDataRow = oStepProcedure.Tables["StepProcedures"].NewRow();

                oDataRow["Id"] = oStepProcedure.Id;
                oDataRow["Name"] = oStepProcedure.Name;
                oDataRow["SoundFile"] = oStepProcedure.SoundFile;
                oDataRow["Rank"] = oStepProcedure.Rank;
                oDataRow["isBefore"] = oStepProcedure.isBefore;
                oDataRow["maxDigit"] = oStepProcedure.maxDigit;
                oDataRow["ExpectedDigit"] = oStepProcedure.ExpectedDigit;

                oStepProcedure.Tables["StepProcedures"].Rows.Add(oDataRow);
                oStepProcedure.Tables["StepProcedures"].AcceptChanges();
            }

			private void updateDataRow(HousekeepingStepProcedure oStepProcedure)
            {
                DataRow odRow = oStepProcedure.Tables["StepProcedures"].Rows.Find(oStepProcedure.Id);
                odRow.BeginEdit();

                odRow["Id"] = oStepProcedure.Id;
                odRow["Name"] = oStepProcedure.Name;
                odRow["SoundFile"] = oStepProcedure.SoundFile;
                odRow["Rank"] = oStepProcedure.Rank;
                odRow["isBefore"] = oStepProcedure.isBefore;
                odRow["maxDigit"] = oStepProcedure.maxDigit;
                odRow["ExpectedDigit"] = oStepProcedure.ExpectedDigit;

                odRow.EndEdit();
                odRow.AcceptChanges();
                oStepProcedure.Tables["StepProcedures"].AcceptChanges();
            }

			private void deleteDataRow(HousekeepingStepProcedure oStepProcedure)
            {
                DataRow row = oStepProcedure.Tables["StepProcedures"].Rows.Find(oStepProcedure.Id);
                oStepProcedure.Tables["StepProcedures"].Rows.Remove(row);
                oStepProcedure.AcceptChanges();
            }
			
		
		}
	}

