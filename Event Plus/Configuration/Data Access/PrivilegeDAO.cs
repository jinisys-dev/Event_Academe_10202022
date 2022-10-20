using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
	
		public class PrivilegeDAO
		{

            public PrivilegeDAO(){}


            public int insertObject(PrivilegeHeader a_PrivilegeHeader)
            {
                MySqlTransaction transaction = GlobalVariables.gPersistentConnection.BeginTransaction();
                try
                {
                    int rowsAffected = 0;
                    MySqlCommand insertCommand = GlobalVariables.gPersistentConnection.CreateCommand();
                    insertCommand.Transaction = transaction;

                    string frmDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PrivilegeHeader.FromDate);
                    string toDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PrivilegeHeader.ToDate);

                    insertCommand.CommandText = "call spInsertPrivilegeHeader(\'" + a_PrivilegeHeader.PrivilegeID + "\',\'" + a_PrivilegeHeader.Description + "\',\'" + frmDate + "\',\'" + toDate + "\',\'" + a_PrivilegeHeader.DaysApplied + "\'," + GlobalVariables.gHotelId + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
                    rowsAffected = insertCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        insertDataRow(a_PrivilegeHeader);
                    }
                    foreach (PrivilegeDetail priv_det in a_PrivilegeHeader.PrivilegeDetails)
                    {
                        insertCommand.CommandText = "call spInsertPrivilegeDetails(\'" + priv_det.PrivilegeID + "\',\'" + priv_det.TransactionCode + "\',\'" + priv_det.Basis + "\'," + priv_det.PercentOff + "," + priv_det.AmountOff + ",\'" + GlobalVariables.gHotelId + "\',\'" + GlobalVariables.gLoggedOnUser + "\')";
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
           
            public int updateObject(ref PrivilegeHeader a_PrivilegeHeader)
            {
                MySqlTransaction transaction = GlobalVariables.gPersistentConnection.BeginTransaction();
                try
                {
                    int rowsAffected = 0;
                    MySqlCommand command = GlobalVariables.gPersistentConnection.CreateCommand();
                    command.Transaction = transaction;

                    string frmDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PrivilegeHeader.FromDate);
                    string toDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", a_PrivilegeHeader.ToDate);

                    command.CommandText = "call spUpdatePrivilegeHeader(\'" + a_PrivilegeHeader.PrivilegeID + "\',\'" + a_PrivilegeHeader.Description + "\',\'" + frmDate + "\',\'" + toDate + "\',\'" + a_PrivilegeHeader.DaysApplied + "\'," + GlobalVariables.gHotelId + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
                    rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        updateDataRow(a_PrivilegeHeader);
                    }

                    command.CommandText = "Call spDeleteAllPrivilegeDetails(\'" + a_PrivilegeHeader.PrivilegeID + "\'," + GlobalVariables.gHotelId + ")";
                    command.ExecuteNonQuery();

                    foreach (PrivilegeDetail priv_det in a_PrivilegeHeader.PrivilegeDetails)
                    {
                     
                        command.CommandText = "call spInsertPrivilegeDetails(\'" + priv_det.PrivilegeID + "\',\'" + priv_det.TransactionCode + "\',\'" + priv_det.Basis + "\'," + priv_det.PercentOff + "," + priv_det.AmountOff + ",\'" + GlobalVariables.gHotelId + "\',\'" + GlobalVariables.gLoggedOnUser + "\')";
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
            
            public int deleteObject(PrivilegeHeader a_PrivilegeHeader)
            {
                try
                {
                    int rowsAffected = 0;
                    MySqlCommand deleteCommand = new MySqlCommand("call spDeletePrivilegeHeader(\'" + a_PrivilegeHeader.PrivilegeID + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                    rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        deleteDataRow(a_PrivilegeHeader);
                    }
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
				PrivilegeHeader oPrivilege = new PrivilegeHeader();
				try
				{
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("CALL spSelectPrivilegeHeader(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(oPrivilege, "PrivilegeHeader");
					dataAdapter.Dispose();
					DataColumn[] primaryKey = new DataColumn[1];
					primaryKey[0] = oPrivilege.Tables["PrivilegeHeader"].Columns["PrivilegeID"];
					oPrivilege.Tables["PrivilegeHeader"].PrimaryKey = primaryKey;
                 
					return oPrivilege;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @:GetAllPrivilege() " + ex.Message);
					return null;
				}
			}
			public DataTable loadPrivilegeDetails(string privilegeId)
			{
				DataTable dTable = new DataTable();
				try
				{
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("CALL spSelectPrivilegeDetails('" + privilegeId + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(dTable);
					dataAdapter.Dispose();
					return dTable;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @:GetPrivilegeDetails() " + ex.Message);
					return null;
				}
			}
			public int deletePrivilegeDetail(string privilegeId, string trancode)
			{
				try
				{
                    int rowsAffected = 0;
					MySqlCommand command = new MySqlCommand("call spDeletePrivilegeDetail(\'" + privilegeId + "\',\'" + trancode + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					rowsAffected=command.ExecuteNonQuery();
					return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @:DeletePrivilegeDetail() " + ex.Message);
					return 0;
				}
			}

            public void insertDataRow(PrivilegeHeader a_PrivilegeHeader)
            {
                try
                {
                    DataRow dRow = a_PrivilegeHeader.Tables["PrivilegeHeader"].NewRow();
                    dRow["PrivilegeID"] = a_PrivilegeHeader.PrivilegeID;
                    dRow["Description"] = a_PrivilegeHeader.Description;
                    dRow["FromDate"] = a_PrivilegeHeader.FromDate;
                    dRow["toDate"] = a_PrivilegeHeader.ToDate;
                    dRow["DaysApplied"] = a_PrivilegeHeader.DaysApplied;
                    a_PrivilegeHeader.Tables["PrivilegeHeader"].Rows.Add(dRow);
                    //a_PrivilegeHeader.Tables["PrivilegeHeader"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Data Row Exception");
                }
            }

            public void deleteDataRow(PrivilegeHeader a_PrivilegeHeader)
            {
                try
                {
                    object primaryKey = new object();
                    primaryKey = a_PrivilegeHeader.PrivilegeID;
                    DataRow row = a_PrivilegeHeader.Tables["PrivilegeHeader"].Rows.Find(primaryKey);
                    a_PrivilegeHeader.Tables["PrivilegeHeader"].Rows.Remove(row);
                    a_PrivilegeHeader.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Data Row Exception");
                }

            }
            public void updateDataRow(PrivilegeHeader a_PrivilegeHeader)
            {
                try
                {
                    DataRow dRow = a_PrivilegeHeader.Tables["PrivilegeHeader"].Rows.Find(a_PrivilegeHeader.PrivilegeID);
                    dRow.BeginEdit();
                    dRow["PrivilegeID"] = a_PrivilegeHeader.PrivilegeID;
                    dRow["Description"] = a_PrivilegeHeader.Description;
                    dRow["FromDate"] = a_PrivilegeHeader.FromDate;
                    dRow["toDate"] = a_PrivilegeHeader.ToDate;
                    dRow["DaysApplied"] = a_PrivilegeHeader.DaysApplied;
                    dRow.EndEdit();
                    dRow.AcceptChanges();
                    a_PrivilegeHeader.Tables["PrivilegeHeader"].AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Data Row Exception");
                }

            }

		}
	}
	

