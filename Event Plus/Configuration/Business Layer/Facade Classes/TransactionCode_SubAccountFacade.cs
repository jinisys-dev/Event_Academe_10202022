using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class TransactionCode_SubAccountFacade
	{
		private TransactionCode_SubAccountDAO oTransactionCodeSubAccountDAO;
		public TransactionCode_SubAccountFacade()
		{

		}

		public IList<TransactionCode_SubAccount> loadTransactionCodeSubAccounts(string pTransactionCode)
		{
			IList<TransactionCode_SubAccount> ilSubAccount = new List<TransactionCode_SubAccount>();

			oTransactionCodeSubAccountDAO = new TransactionCode_SubAccountDAO();

			try
			{
				DataTable dtAccount = oTransactionCodeSubAccountDAO.loadTransactionCode_SubAccount();
				DataView _dtView = dtAccount.DefaultView;
				_dtView.RowStateFilter = DataViewRowState.OriginalRows;
				_dtView.RowFilter = "TransactionCode='" + pTransactionCode + "'";

				foreach (DataRowView dRow in _dtView)
				{
					TransactionCode_SubAccount subAccount = new TransactionCode_SubAccount();

					subAccount.TransactionCode = dRow["TransactionCode"].ToString();
					subAccount.SubAccountCode = dRow["subAccountCode"].ToString();
					subAccount.CreatedBy = dRow["createdBy"].ToString();
					subAccount.CreatedDate = DateTime.Parse(dRow["createdDate"].ToString());
					subAccount.UpdatedBy = dRow["updatedBy"].ToString();
					subAccount.UpdatedDate = DateTime.Parse(dRow["updatedDate"].ToString());

					subAccount.LocalTax = decimal.Parse(dRow["localTax"].ToString());
					subAccount.LocalTaxInclusive = int.Parse(dRow["localTaxInclusive"].ToString());

					subAccount.ServiceCharge = decimal.Parse(dRow["serviceCharge"].ToString());
					subAccount.ServiceChargeInclusive = int.Parse(dRow["serviceChargeInclusive"].ToString());

					subAccount.GovernmentTax = decimal.Parse(dRow["governmentTax"].ToString());
					subAccount.GovernmentTaxInclusive = int.Parse(dRow["governmentTaxInclusive"].ToString());

					ilSubAccount.Add(subAccount);
				}

				return ilSubAccount;
			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public TransactionCode_SubAccount getTransactionSubAccount(string pTransactionCode, string pSubAccountCode)
	{
		IList<TransactionCode_SubAccount> subAccountList = this.loadTransactionCodeSubAccounts();

		foreach (TransactionCode_SubAccount oSubAccount in subAccountList)
		{
			if (oSubAccount.TransactionCode == pTransactionCode)
			{
				if (oSubAccount.SubAccountCode == pSubAccountCode)
				{
					return oSubAccount;
				}
			}
		}

		return null;

	}

		public IList<TransactionCode_SubAccount> loadTransactionCodeSubAccounts()
		{
			IList<TransactionCode_SubAccount> ilSubAccount = new List<TransactionCode_SubAccount>();

			oTransactionCodeSubAccountDAO = new TransactionCode_SubAccountDAO();

			try
			{
				DataTable dtAccount = oTransactionCodeSubAccountDAO.loadTransactionCode_SubAccount();

				foreach (DataRow dRow in dtAccount.Rows)
				{
					TransactionCode_SubAccount subAccount = new TransactionCode_SubAccount();

					subAccount.TransactionCode = dRow["TransactionCode"].ToString();
					subAccount.SubAccountCode = dRow["subAccountCode"].ToString();
					subAccount.CreatedBy = dRow["createdBy"].ToString();
					subAccount.CreatedDate = DateTime.Parse(dRow["createdDate"].ToString());
					subAccount.UpdatedBy = dRow["updatedBy"].ToString();
					subAccount.UpdatedDate = DateTime.Parse(dRow["updatedDate"].ToString());

					subAccount.LocalTax = decimal.Parse(dRow["localTax"].ToString());
					subAccount.LocalTaxInclusive = int.Parse(dRow["localTaxInclusive"].ToString());

					subAccount.ServiceCharge = decimal.Parse(dRow["serviceCharge"].ToString());
					subAccount.ServiceChargeInclusive = int.Parse(dRow["serviceChargeInclusive"].ToString());

					subAccount.GovernmentTax = decimal.Parse(dRow["governmentTax"].ToString());
					subAccount.GovernmentTaxInclusive = int.Parse(dRow["governmentTaxInclusive"].ToString());

					ilSubAccount.Add(subAccount);
				}

				return ilSubAccount;
			}
			catch(Exception ex)
			{
				throw (ex);
			}

		}

		/// <summary>
		/// Inserts new Transaction Code Sub-Account to database and
		/// add to local list of Sub Accounts
		/// </summary>
		/// <param name="poTransactionCode_SubAccount">the New Transaction Code Sub-Account to insert</param>
		/// <param name="poTransactionCode_SubAccountList">List of Transaction Code Sub-Accounts</param>
		public void insertNewSubAccount(TransactionCode_SubAccount poTransactionCode_SubAccount, ref IList<TransactionCode_SubAccount> poTransactionCode_SubAccountList)
		{
			
			try
			{
				oTransactionCodeSubAccountDAO = new TransactionCode_SubAccountDAO();
				oTransactionCodeSubAccountDAO.insertNewSubAccount((object)poTransactionCode_SubAccount);

				// add to IList ilDrivers
				poTransactionCode_SubAccountList.Add(poTransactionCode_SubAccount);
				

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		/// <summary>
		/// Updates Transaction Code Sub-Account in database and
		/// update local list of Sub Accounts
		/// </summary>
		/// <param name="poTransactionCode_SubAccount">the New Transaction Code Sub-Account to insert</param>
		/// <param name="poTransactionCode_SubAccountList">List of Transaction Code Sub-Accounts</param>
		public void updateSubAccountInfo(TransactionCode_SubAccount poTransactionCode_SubAccount, ref IList<TransactionCode_SubAccount> poTransactionCode_SubAccountList)
		{
			try
			{
				oTransactionCodeSubAccountDAO = new TransactionCode_SubAccountDAO();
				oTransactionCodeSubAccountDAO.updateSubAccountInfo((object)poTransactionCode_SubAccount);

				// add to IList ilDrivers
				foreach (TransactionCode_SubAccount _oSubAccount in poTransactionCode_SubAccountList)
				{
					if (_oSubAccount.TransactionCode == poTransactionCode_SubAccount.TransactionCode 
						&& _oSubAccount.SubAccountCode == poTransactionCode_SubAccount.SubAccountCode)
					{

						_oSubAccount.LocalTax = poTransactionCode_SubAccount.LocalTax;
						_oSubAccount.LocalTaxInclusive = poTransactionCode_SubAccount.LocalTaxInclusive;
						_oSubAccount.GovernmentTax = poTransactionCode_SubAccount.GovernmentTax;
						_oSubAccount.GovernmentTaxInclusive = poTransactionCode_SubAccount.GovernmentTaxInclusive;

						_oSubAccount.ServiceCharge = poTransactionCode_SubAccount.ServiceCharge;
						_oSubAccount.ServiceChargeInclusive = poTransactionCode_SubAccount.ServiceChargeInclusive;

						break;
					}
				}

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		/// <summary>
		/// Updates Transaction Code Sub-Account in database and
		/// remove from Local List of Sub Accounts (set StatusFlag = DELETED)
		/// </summary>
		/// <param name="poTransactionCode_SubAccount">the New Transaction Code Sub-Account to insert</param>
		/// <param name="poTransactionCode_SubAccountList">List of Transaction Code Sub-Accounts</param>
		public void deleteSubAccountInfo(TransactionCode_SubAccount poTransactionCode_SubAccount, ref IList<TransactionCode_SubAccount> poTransactionCode_SubAccountList)
		{
			try
			{
				oTransactionCodeSubAccountDAO = new TransactionCode_SubAccountDAO();
				oTransactionCodeSubAccountDAO.deleteSubAccount((object)poTransactionCode_SubAccount);

				// add to IList ilDrivers
				foreach (TransactionCode_SubAccount _oSubAccount in poTransactionCode_SubAccountList)
				{
					if (_oSubAccount.TransactionCode == poTransactionCode_SubAccount.TransactionCode
						&& _oSubAccount.SubAccountCode == poTransactionCode_SubAccount.SubAccountCode)
					{

						poTransactionCode_SubAccountList.Remove(_oSubAccount);

						break;
					}
				}

			}
			catch (Exception ex)
			{
				throw (ex);
			}


		}


	}
}
