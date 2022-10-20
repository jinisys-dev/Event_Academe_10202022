using System.Windows.Forms;
using System.Diagnostics;

using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
	
		public class PackageDAO
		{
            public PackageDAO(){}

            public int insertObject(PackageHeader a_PackageHeader)
            {
                MySqlTransaction transaction = GlobalVariables.gPersistentConnection.BeginTransaction();
                try
                {
                    int rowsAffected = 0;
                    MySqlCommand insertCommand = GlobalVariables.gPersistentConnection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    
                    string frmDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PackageHeader.FromDate);
                    string toDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PackageHeader.ToDate);

                    insertCommand.CommandText = "call spInsertPackageHeader(\'" + a_PackageHeader.PackageID + "\',\'" + a_PackageHeader.Description + "\',\'" + frmDate + "\',\'" + toDate + "\',\'" + a_PackageHeader.DaysApplied + "\'," + GlobalVariables.gHotelId + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
                    rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(a_PackageHeader);
                    }
                    
                    foreach (PackageDetail package_detail in a_PackageHeader.PackageDetails)
                    {
                        insertCommand.CommandText = "call spInsertPackageDetails(\'" + package_detail.PackageID + "\',\'" + package_detail.TransactionCode + "\',\'" + package_detail.Basis + "\'," + package_detail.PercentOff + "," + package_detail.AmountOff + ",\'" + GlobalVariables.gHotelId + "\',\'" + GlobalVariables.gLoggedOnUser + "\')";
                        insertCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message, "Database Insert Exception");
                    return 0;
                }
            }

            public int updateObject(ref PackageHeader a_PackageHeader)
            {
                MySqlTransaction transaction = GlobalVariables.gPersistentConnection.BeginTransaction();
                try
                {
                    int rowsAffected = 0;
                    MySqlCommand command = GlobalVariables.gPersistentConnection.CreateCommand();
                    command.Transaction = transaction;

                    string frmDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PackageHeader.FromDate);
                    string toDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PackageHeader.ToDate);

                    command.CommandText = "call spupdatePackageHeader(\'" + a_PackageHeader.PackageID + "\',\'" + a_PackageHeader.Description + "\',\'" + frmDate + "\',\'" + toDate + "\',\'" + a_PackageHeader.DaysApplied + "\'," + GlobalVariables.gHotelId + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
                    rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        updateDataRow(a_PackageHeader);
                    }

                    command.CommandText = "Call spDeleteAllPackageDetails('" + a_PackageHeader.PackageID + "'," + GlobalVariables.gHotelId + ")";
                    command.ExecuteNonQuery();

                    foreach (PackageDetail package_detail in a_PackageHeader.PackageDetails)
                    {
                        command.CommandText = "call spInsertPackageDetails('" + package_detail.PackageID + "','" + package_detail.TransactionCode + "','" + package_detail.Basis + "'," + package_detail.PercentOff + "," + package_detail.AmountOff + ",'" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')";
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message, "Database Update Exception");
                    return 0;
                }
            }

            public int deleteObject(PackageHeader a_PackageHeader)
            {
                try
                {
                    int rowsAffected = 0;

                    MySqlCommand deleteCommand = new MySqlCommand("call spDeletePackages(\'" + a_PackageHeader.PackageID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                    rowsAffected=deleteCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
            public Hashtable getTransactionCodes()
			{
				Hashtable hash = new Hashtable();
				try
				{
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("CALL spGetTransactionCodes(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					DataTable dTable = new DataTable();
					dataAdapter.Fill(dTable);
					dataAdapter.Dispose();
					int i;
					for (i = 0; i <= dTable.Rows.Count - 1; i++)
					{
						hash.Add(dTable.Rows[i][0], dTable.Rows[i][3]);
					}
					return hash;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return null;
				}
			}
            public DataTable loadPackageDetails(string a_packageId)
            {
                DataTable dTable = new DataTable();
                try
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("CALL spSelectPackageDetails(\'" + a_packageId + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(dTable);
                    dataAdapter.Dispose();
                    return dTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }

            public int deletePackageDetail(string a_packageId, string a_trancode)
            {
                try
                {
                    int rowsAffected = 0;
                    MySqlCommand insertCommand = new MySqlCommand("call spDeletePackageDetail(\'" + a_packageId + "\',\'" + a_trancode + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                    rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }


            public object loadObject()
            {
                PackageHeader dSet = new PackageHeader();
                try
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("CALL spSelectPackageHeader(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(dSet, "PackageHeader");
                    dataAdapter.Dispose();
                    DataColumn[] primaryKey = new DataColumn[1];
                    primaryKey[0] = dSet.Tables["PackageHeader"].Columns["PackageID"];
                    dSet.Tables["PackageHeader"].PrimaryKey = primaryKey;

                    return dSet;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("EXCEPTION @:GetAllPackage() " + ex.Message);
                    return null;
                }
            }

            public DataTable getApplicablePackages()
            {
                try
                {
                    DataTable package = new DataTable();

					string _sqlStr = "call spGetApplicablePackages('" + 
										   GlobalVariables.gAuditDate + "'," + 
										   GlobalVariables.gHotelId + ")";

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(package);
                    dataAdapter.Dispose();


                    return package;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                    return null;
                }
            }

            public DataTable getApplicablePackages(string pStartDate, string pEndDate)
            {
                try
                {
                    DataTable package = new DataTable();

                    string _sqlStr = "call spGetApplicablePromos('" +
                                           pStartDate + "','" +
                                           pEndDate + "'," +
                                           GlobalVariables.gHotelId + ")";

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
                    dataAdapter.Fill(package);
                    dataAdapter.Dispose();


                    return package;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                    return null;
                }
            }

            public void insertDataRow(PackageHeader a_PackageHeader)
            {
                try
                {
                    DataRow dRow = a_PackageHeader.Tables["PackageHeader"].NewRow();
                    dRow.BeginEdit();
                    dRow["PackageID"] = a_PackageHeader.PackageID;
                    dRow["Description"] = a_PackageHeader.Description;
                    dRow["FromDate"] = a_PackageHeader.FromDate;
                    dRow["toDate"] = a_PackageHeader.ToDate;
                    dRow["DaysApplied"] = a_PackageHeader.DaysApplied;
                    dRow.EndEdit();
                    a_PackageHeader.Tables["PackageHeader"].Rows.Add(dRow);
                    a_PackageHeader.Tables["PackageHeader"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Data Row Exception");
                }
            }

            public void deleteDataRow(PackageHeader a_PackageHeader)
            {
                try
                {
                    object primaryKey = new object();
                    primaryKey = a_PackageHeader.PackageID;
                    DataRow row = a_PackageHeader.Tables["PackageHeader"].Rows.Find(primaryKey);
                    a_PackageHeader.Tables["PackageHeader"].Rows.Remove(row);
                    a_PackageHeader.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Data Row Exception");
                }

            }
            public void updateDataRow(PackageHeader a_PackageHeader)
            {
                try
                {
                    DataRow dRow = a_PackageHeader.Tables["PackageHeader"].Rows.Find(a_PackageHeader.PackageID);

                    dRow.BeginEdit();
                    dRow["PackageID"] = a_PackageHeader.PackageID;
                    dRow["Description"] = a_PackageHeader.Description;
                    dRow["FromDate"] = a_PackageHeader.FromDate;
                    dRow["toDate"] = a_PackageHeader.ToDate;
                    dRow["DaysApplied"] = a_PackageHeader.DaysApplied;
                    dRow.EndEdit();
                    dRow.AcceptChanges();
                    a_PackageHeader.Tables["PackageHeader"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Data Row Exception");
                }

            }

			
		}
	
}
