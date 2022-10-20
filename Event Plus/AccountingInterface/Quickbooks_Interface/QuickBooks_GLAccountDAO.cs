using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Quickbooks_Interface
{
    public class QuickBooks_GLAccountDAO
    {
        public void insertGLAccount(object poGLAccount, string pUser)
        {
            string _name = poGLAccount.GetType().GetProperty("NAME").GetValue(poGLAccount, null).ToString();
            string _type = poGLAccount.GetType().GetProperty("TYPE").GetValue(poGLAccount, null).ToString();

            string _sql = "call spQuickbooks_insertGLAccount('" + _name + "','" + _type + "','" + pUser + "')"; 
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sql, GlobalVariables.gPersistentConnection);
                _cmd.ExecuteNonQuery();
                _cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nError Location: " + this.ToString());
            }
        }

        public DataTable getGLAccounts()
        {
            string _sql = "call spQuickbooks_getGLAccounts()";
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
                throw new Exception(ex.Message + "\nError Location: " + this.ToString());
            }
        }
    }
}
