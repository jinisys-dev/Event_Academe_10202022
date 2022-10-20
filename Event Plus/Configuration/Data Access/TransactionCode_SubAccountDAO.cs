using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
	class TransactionCode_SubAccountDAO
	{

		private MySqlConnection localConnection;
		private int hotelId;
		public TransactionCode_SubAccountDAO()
		{
			localConnection = GlobalVariables.gPersistentConnection;
			hotelId = GlobalVariables.gHotelId;
		}


		public DataTable loadTransactionCode_SubAccount()
		{
			DataTable dtAccount = new DataTable();
			try
			{


				string strQuery = "call spSelectTransctioncode_SubAccount(" + hotelId + ")";
				MySqlDataAdapter dtaSelect = new MySqlDataAdapter(strQuery, localConnection);
				dtaSelect.Fill(dtAccount);

				return dtAccount;

			}
			catch(Exception ex)
			{
				throw (ex);
			}

		}


		public bool insertNewSubAccount(object poTransactionCode_SubAccount)
		{
			try
			{
				string _transactionCode = poTransactionCode_SubAccount.GetType().GetProperty("TransactionCode").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _subAccountCode = poTransactionCode_SubAccount.GetType().GetProperty("SubAccountCode").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _localTax = poTransactionCode_SubAccount.GetType().GetProperty("LocalTax").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _localTaxInclusive = poTransactionCode_SubAccount.GetType().GetProperty("LocalTaxInclusive").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _govtTax = poTransactionCode_SubAccount.GetType().GetProperty("GovernmentTax").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _govtTaxInclusive = poTransactionCode_SubAccount.GetType().GetProperty("GovernmentTaxInclusive").GetValue(poTransactionCode_SubAccount, null).ToString();

				string _serviceCharge = poTransactionCode_SubAccount.GetType().GetProperty("ServiceCharge").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _serviceChargeInclusive = poTransactionCode_SubAccount.GetType().GetProperty("ServiceChargeInclusive").GetValue(poTransactionCode_SubAccount, null).ToString();


				string strQuery = "call spInsertTransactionCodeSubAccount('" + 
												_transactionCode + "','" + 
												_subAccountCode + "'," + 
												_localTax + "," + 
												_localTaxInclusive + "," + 
												_govtTax + "," +
												_govtTaxInclusive + "," +
												_serviceCharge + "," +
												_serviceChargeInclusive + ",'" +
												GlobalVariables.gLoggedOnUser + "'," + 
												hotelId + ")";

				MySqlCommand insertCommand = new MySqlCommand(strQuery, localConnection);
				insertCommand.ExecuteNonQuery();

				return true;

			}
			catch (Exception ex)
			{
				throw (ex);
			}


		}


		public bool updateSubAccountInfo(object poTransactionCode_SubAccount)
		{
			try
			{
				string _transactionCode = poTransactionCode_SubAccount.GetType().GetProperty("TransactionCode").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _subAccountCode = poTransactionCode_SubAccount.GetType().GetProperty("SubAccountCode").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _localTax = poTransactionCode_SubAccount.GetType().GetProperty("LocalTax").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _localTaxInclusive = poTransactionCode_SubAccount.GetType().GetProperty("LocalTaxInclusive").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _govtTax = poTransactionCode_SubAccount.GetType().GetProperty("GovernmentTax").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _govtTaxInclusive = poTransactionCode_SubAccount.GetType().GetProperty("GovernmentTaxInclusive").GetValue(poTransactionCode_SubAccount, null).ToString();

				string _serviceCharge = poTransactionCode_SubAccount.GetType().GetProperty("ServiceCharge").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _serviceChargeInclusive = poTransactionCode_SubAccount.GetType().GetProperty("ServiceChargeInclusive").GetValue(poTransactionCode_SubAccount, null).ToString();


				string strQuery = "call spUpdateTransactionCodeSubAccount('" +
												_transactionCode + "','" +
												_subAccountCode + "'," +
												_localTax + "," +
												_localTaxInclusive + "," +
												_govtTax + "," +
												_govtTaxInclusive + "," +
												_serviceCharge + "," +
												_serviceChargeInclusive + ",'" +
												GlobalVariables.gLoggedOnUser + "'," +
												hotelId + ")";

				MySqlCommand updateCommand = new MySqlCommand(strQuery, localConnection);
				updateCommand.ExecuteNonQuery();

				return true;

			}
			catch (Exception ex)
			{
				throw (ex);
			}


		}


		public bool deleteSubAccount(object poTransactionCode_SubAccount)
		{
			try
			{
				string _transactionCode = poTransactionCode_SubAccount.GetType().GetProperty("TransactionCode").GetValue(poTransactionCode_SubAccount, null).ToString();
				string _subAccountCode = poTransactionCode_SubAccount.GetType().GetProperty("SubAccountCode").GetValue(poTransactionCode_SubAccount, null).ToString();

				string strQuery = "call spDeleteTransactionCodeSubAccount('" +
												_transactionCode + "','" +
												_subAccountCode + "','" +
												GlobalVariables.gLoggedOnUser + "'," +
												hotelId + ")";

				MySqlCommand updateCommand = new MySqlCommand(strQuery, localConnection);
				updateCommand.ExecuteNonQuery();

				return true;

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

	}

}
