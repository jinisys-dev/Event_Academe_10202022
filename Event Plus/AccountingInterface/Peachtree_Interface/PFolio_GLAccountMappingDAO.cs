using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PFolio_GLAccountMappingDAO
    {
        public void insertGLAccount(object poGLAccount)
        {
            string _accountID = poGLAccount.GetType().GetProperty("ACCOUNTID").GetValue(poGLAccount, null).ToString();
            string _description = poGLAccount.GetType().GetProperty("DESCRIPTION").GetValue(poGLAccount, null).ToString();
            string _type = poGLAccount.GetType().GetProperty("TYPE").GetValue(poGLAccount, null).ToString();

            string _sql = "call spPeachtree_insertGLAccount('" + _accountID + "','" + _description + "','" + _type + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public void deleteGLAccount(string pAccountID)
        {
            string _sql = "call spPeachtree_deleteGLAccount('" + pAccountID + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getGLAccounts()
        {
            string _sql = "call spPeachtree_getGLAccounts()";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("GLAccounts");
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getTransactionCodes()
        {
            string _sql = "call spGetTransactionCodes('" + GlobalVariables.gHotelId + "')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("TransactionCodes");
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public void insertAccountMapping(string pAccountID, string pTransactionCode, string pMappingType)
        {
            string _sql = "call spPeachtree_insertAccountMapping('" + pAccountID + "','" + pTransactionCode + "','" + pMappingType + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public DataTable getAccountMapping()
        {
            string _sql = "call spPeachtree_getAccountMapping()";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("AccountMapping");
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }

        public void deleteMapping(string pTransactionCode, string pGLAccount)
        {
            string _sql = "call spPeachtree_deleteMapping('" + pTransactionCode + "','" + pGLAccount + "','" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error Location: " + this.ToString());
            }
        }
    }
}
