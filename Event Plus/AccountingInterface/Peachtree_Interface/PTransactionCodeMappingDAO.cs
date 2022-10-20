using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PTransactionCodeMappingDAO
    {
        public DataTable getFolioTransactions(DateTime pDate, bool includePosted)
        {
            string postToLedger = "";
            if (includePosted)
            {
                postToLedger = "1";
            }
            else
            {
                postToLedger = "0";
            }
            string _sql = "call spPeachtree_getFolioTransactions('" + pDate.ToString("yyyy-MM-dd") + "','" + postToLedger + "')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("FolioTransactions");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getCreditCardAndCityTransfers(DateTime pDate, bool includePosted)
        {
            string postToLedger = "";
            if (includePosted)
            {
                postToLedger = "1";
            }
            else
            {
                postToLedger = "0";
            }
            string _sql = "call spPeachtree_getCityTransfers('" + pDate.ToString("yyyy-MM-dd") + "','" + postToLedger + "')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("FolioTransactions");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getNonGuestTransactions(DateTime pDate, bool includePosted)
        {
            string postToLedger = "";
            if (includePosted)
            {
                postToLedger = "1";
            }
            else
            {
                postToLedger = "0";
            }
            string _sql = "call spPeachtree_getNonGuestTransactions('" + pDate.ToString("yyyy-MM-dd") + "','" + postToLedger +"')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("NonGuestTransactions");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getFolioReceipts(DateTime pDate, bool includePosted)
        {
            string postToLedger = "";
            if (includePosted)
            {
                postToLedger = "1";
            }
            else
            {
                postToLedger = "0";
            }
            string _sql = "call spPeachtree_getFolioPayments('" + pDate.ToString("yyyy-MM-dd") + "','" + postToLedger + "')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("FolioReceipts");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;    
            }
        }

        public DataTable getNonGuestReceipts(DateTime pDate, bool includePosted)
        {
            string postToLedger = "";
            if (includePosted)
            {
                postToLedger = "1";
            }
            else
            {
                postToLedger = "0";
            }

            string _sql = "call spPeachtree_getNonGuestReceipts('" + pDate.ToString("yyyy-MM-dd") + "','" + postToLedger + "')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("NonGuestReceipts");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getHotelTransactions(DateTime pDate, bool includePosted)
        {
            string postToLedger = "";
            if (includePosted)
            {
                postToLedger = "1";
            }
            else
            {
                postToLedger = "0";
            }
            string _sql = "call spPeachtree_getHotelTransactions('" + pDate.ToString("yyyy-MM-dd") + "','" + postToLedger + "')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("HotelTransactions");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getRestoTransactions(DateTime pDate, bool includePosted)
        {
            string postToLedger = "";
            if (includePosted)
            {
                postToLedger = "1";
            }
            else
            {
                postToLedger = "0";
            }
            string _sql = "call spPeachtree_getRestoTransactions('" + pDate.ToString("yyyy-MM-dd") + "','" + postToLedger + "')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("RestoTransactions");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void postFolioTransaction(int pFolioTransactionNo)
        {
            string _sql = "update foliotransactions set postToLedger=1 where folioTransactionNo='" + pFolioTransactionNo + "'";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void postNonGuestTransaction(int pTransactionID)
        {
            string _sql = "update foliotransactions set postedToLedger=1 where transactionId='" + pTransactionID + "'";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //***Customers and Companies are obtained separately through "option"***
        public DataTable getPeachtreeNewClients(DateTime pExportDate, string option)
        {
            try
            {
                DataTable transaction = new DataTable();
                string query = "";

                if (option == "Customers")
                {
                    query = "call spPeachtree_GetNewCustomers('"
                                             + GlobalVariables.gHotelId + "','"
                                             + pExportDate.ToString("yyyy-MM-dd") + "')";
                }
                else if (option == "Companies")
                {
                    query = "call spPeachtree_GetNewCompanies('"
                                             + GlobalVariables.gHotelId + "','"
                                             + pExportDate.ToString("yyyy-MM-dd") + "')";
                }

                MySqlDataAdapter da = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
                da.Fill(transaction);

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
