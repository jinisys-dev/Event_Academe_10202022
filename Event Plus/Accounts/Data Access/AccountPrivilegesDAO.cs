using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.Accounts.DataAccessLayer
{
	
		public class AccountPrivilegesDAO 
		{
	
	        public AccountPrivilegesDAO(){}

			public int saveAccountPrivileges(AccountPrivileges a_Acct_priv)
			{
				
				try
				{
					int rowsAffected=0;
                    MySqlCommand insertCommand = new MySqlCommand("Call spDeleteAccountPrivileges(\'" + a_Acct_priv.AccountId + "\'," + GlobalVariables.gHotelId + ")",GlobalVariables.gPersistentConnection);
					rowsAffected += insertCommand.ExecuteNonQuery();

					for (int i = 0; i <= a_Acct_priv.Count - 1; i++)
					{
						insertCommand.CommandText = "call spInsertAccountPrivilege(" + GlobalVariables.gHotelId + ",\'" + a_Acct_priv.AccountId + "\',\'" + a_Acct_priv.Item(i).PrivilegeID + "\',\'" + a_Acct_priv.Item(i).TransactionCode + "\',\'" + a_Acct_priv.Item(i).Basis + "\'," + a_Acct_priv.Item(i).PercentOff + "," + a_Acct_priv.Item(i).AmountOff + ",\'" + GlobalVariables.gLoggedOnUser + "\')";
						rowsAffected += insertCommand.ExecuteNonQuery();
					}
					
					return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @SaveAccountPrivileges():" + ex.Message);
                    return 0;
				}
			}
			
            public DataTable getPrivileges()
			{
				DataTable dtable = new DataTable();
				try
				{
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("Call spSelectPrivileges(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(dtable);
					dataAdapter.Dispose();
					return dtable;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @GetPrivileges():" + ex.Message);
					return null;
				}
			}

			public DataTable getAccountPrivileges(string a_Accid)
			{
				DataTable dtable = new DataTable();
				try
				{
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("Call spGetAccountPrivileges(\'" + a_Accid + "\'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(dtable);
					dataAdapter.Dispose();
					return dtable;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @getAccountPrivileges():" + ex.Message);
					return null;
				}
			}

			public DataTable getAccounts()
			{
				DataTable dtable = new DataTable();
				try
				{
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter("Call spSelectGuests(" + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
					dataAdapter.Fill(dtable);
					dataAdapter.Dispose();
					return dtable;
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION @GetAccounts():" + ex.Message);
					return null;
				}
			}
			
		
	}
}
