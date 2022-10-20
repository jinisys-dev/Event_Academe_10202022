using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess
{
	public class TransactionCodeMappingDAO
	{
		MySqlConnection connection = null;
		MySqlDataAdapter adapter = null;
		MySqlCommand command = null;
		DataTable tempTable = null;

		public TransactionCodeMappingDAO(MySqlConnection DBConnection)
		{
			connection = DBConnection;
		}

		public DataTable getAllTransactionCodeMapping(int mHotelID)
		{
			string query = "call spGetAllTransactionCodeMapping(" + mHotelID + ")";
			try
			{
				adapter = new MySqlDataAdapter(query, connection);
				tempTable = new DataTable("TransactionCodeMapping");
				adapter.Fill(tempTable);

				adapter.Dispose();

				return tempTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public bool SaveNewTransactionCodeMapping(eTransactionCodeMapping objTransactionCodeMapping)
		{
			string query = "call spEXACT_InsertTransactionCodeMapping( '"
								+ objTransactionCodeMapping.pFolioPlus_TranCode + "', '"
								+ objTransactionCodeMapping.pExact_GLAccountID + "', "
								+ objTransactionCodeMapping.pLineNo + ", '"
								+ objTransactionCodeMapping.pAmountColumnInFolioTrans + "', '"
								+ objTransactionCodeMapping.pCostCenterCode + "', '"
								+ objTransactionCodeMapping.pJournalEntryCode + "', '"
								+ objTransactionCodeMapping.pCreatedBy + "')";

			try
			{
				command = new MySqlCommand(query, connection);
				command.ExecuteNonQuery();

				command.Dispose();

				return true;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public bool UpdateTransactionCodeMapping(eTransactionCodeMapping objTransactionCodeMapping)
		{
			string query = "call spUpdateTransactionCodeMapping( "
									+ " mFolioPlus_TranCode, "
									+ " mExact_GLAccountID, "
									+ " mLineNo, "
									+ " mAmountColumnInFolioTrans, "
									+ " mCostCenterCode, "
									+ " mJournalEntryCode, "
									+ " mStatuFlag, "
									+ " mCreatedBy, "
									+ " mCreatedDate, "
									+ " mUpdatedBy, "
									+ " mUpdatedDate, "
									+ " ) ";

			try
			{
				command = new MySqlCommand(query, connection);
				int _rowsAffected = command.ExecuteNonQuery();

				command.Dispose();

				if (_rowsAffected <= 0)
				{
					throw (new Exception("No rows affected."));
				}
				return true;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public DataTable getTransactionCodeMapping(int pHotelID, string pTranCode)
		{
			string query = "call spEXACT_GetTransactionCodeMapping('" 
									+ pHotelID + "','" 
									+ pTranCode + "')";

			try
			{
				adapter = new MySqlDataAdapter(query, connection);
				tempTable = new DataTable("TransactionCodeMapping");
				adapter.Fill(tempTable);

				adapter.Dispose();

				return tempTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}



        public DataTable getUnpostedDailyHotelRevenueForExact(DateTime startDate, DateTime endDate, bool pIncludePostedTrans)
        {
            try
            {
                string strStartDate = startDate.ToString("yyyy-MM-dd");
                string strEndDate = endDate.ToString("yyyy-MM-dd");

                DataTable transaction = new DataTable();

                string query = "";

                if (pIncludePostedTrans)
                {
                    query = "call spEXACT_ReportPostedAndUnpostedDailyHotelRevenue('"
                                        + GlobalVariables.gHotelId + "','"
                                        + strStartDate + "','"
                                        + strEndDate + "')";
                }
                else
                {
                    query = "call spEXACT_ReportUnpostedDailyHotelRevenue('"
                                        + GlobalVariables.gHotelId + "','"
                                        + strStartDate + "','"
                                        + strEndDate + "')";
                }

                adapter = new MySqlDataAdapter(query, 
                                                  GlobalVariables.gPersistentConnection);
                adapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getUnpostedDailyHotelRevenueForPeachtree(DateTime startDate, DateTime endDate, bool pIncludePostedTrans)
        {
            try
            {
                string strStartDate = startDate.ToString("yyyy-MM-dd");
                string strEndDate = endDate.ToString("yyyy-MM-dd");

                DataTable transaction = new DataTable();

                string query = "";

                if (true)
                {
                    query = "call spPeachtree_ReportPostedAndUnpostedDailyHotelRevenue('"
                                        + GlobalVariables.gHotelId + "','"
                                        + strStartDate + "','"
                                        + strEndDate + "')";
                }
                //else
                //{
                //    query = "call spPeachtree_ReportUnpostedDailyHotelRevenue('"
                //                        + GlobalVariables.gHotelId + "','"
                //                        + strStartDate + "','"
                //                        + strEndDate + "')";
                //}

                adapter = new MySqlDataAdapter(query,
                                                  GlobalVariables.gPersistentConnection);
                adapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool flagTransactionAsPosted(DateTime startDate, DateTime endDate)
        {
            try
            {
                string strStartDate = startDate.ToString("yyyy-MM-dd");
                string strEndDate = endDate.ToString("yyyy-MM-dd");

                DataTable transaction = new DataTable();

                string query = "call spEXACT_SetDailyHotelRevenueAsPosted('"
                                    + GlobalVariables.gHotelId + "','"
                                    + strStartDate + "','"
                                    + strEndDate + "')";


                command = new MySqlCommand(query, 
                                          GlobalVariables.gPersistentConnection);

                int _rowsAffected = command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public DataTable getExactNewGuests(DateTime pExportDate)
        {
            try
            {

                DataTable transaction = new DataTable();

                string query = "call spEXACT_GetNewGuests('"
                                    + GlobalVariables.gHotelId + "','"
                                    + pExportDate.ToString("yyyy-MM-dd") + "')";


                adapter = new MySqlDataAdapter(query,
                                                  GlobalVariables.gPersistentConnection);
                adapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getSAPNewGuests(DateTime pExportDate)
        {
            try
            {

                DataTable transaction = new DataTable();

                string query = "call spSAP_GetNewGuests('"
                                    + GlobalVariables.gHotelId + "','"
                                    + pExportDate.ToString("yyyy-MM-dd") + "')";


                adapter = new MySqlDataAdapter(query,
                                                  GlobalVariables.gPersistentConnection);
                adapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //***Customers and Companies are obtained together***
        //
        //public DataTable getPeachtreeNewGuests(DateTime pExportDate)
        //{
        //    try
        //    {
        //        DataTable transaction = new DataTable();
        //        string query = "call spPeachtree_GetNewGuests('"
        //                                    + GlobalVariables.gHotelId + "','"
        //                                    + pExportDate.ToString("yyyy-MM-dd") + "')";                
        //
        //        adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
        //        adapter.Fill(transaction);
        //
        //        return transaction;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable getRestoDataHeaderForSAP(DateTime startDate, DateTime endDate)
        {
            try
            {
                string strStartDate = startDate.ToString("yyyy-MM-dd");
                string strEndDate = endDate.ToString("yyyy-MM-dd");

                DataTable transaction = new DataTable();
                string query = "call spSAP_RestoDataHeader('" + strStartDate + "','" + strEndDate + "')";
                adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);

                adapter.Fill(transaction);
                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getRestoDataDetailsForSAP(string pOrderID)
        {
            try
            {
                DataTable transaction = new DataTable();
                string query = "call spSAP_RestoDataDetail('" + pOrderID + "')";
                adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);

                adapter.Fill(transaction);
                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getUnpostedDailyHotelPaymentsForSAP(DateTime startDate, DateTime endDate, bool pIncludePostedTrans)
        {
            try
            {
                string strStartDate = startDate.ToString("yyyy-MM-dd");
                string strEndDate = endDate.ToString("yyyy-MM-dd");

                DataTable transaction = new DataTable();

                string query = "";

                if (pIncludePostedTrans)
                {
                    query = "call spSAP_ReportPostedAndUnpostedDailyHotelPayments('"
                                        + GlobalVariables.gHotelId + "','"
                                        + strStartDate + "','"
                                        + strEndDate + "')";
                }
                else
                {
                    query = "call spSAP_ReportUnpostedDailyHotelPayments('"
                                        + GlobalVariables.gHotelId + "','"
                                        + strStartDate + "','"
                                        + strEndDate + "')";
                }

                adapter = new MySqlDataAdapter(query,
                                                  GlobalVariables.gPersistentConnection);
                adapter.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string getSAPGLAccount(string pTransactionCode)
        {
            try
            {
                string query = "select accountid from sap_glaccounts where description like '%" + pTransactionCode + "%'";
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                string acct = cmd.ExecuteScalar().ToString();
                return acct;
            }
            catch
            {
                return "";
            }
        }

	}
}