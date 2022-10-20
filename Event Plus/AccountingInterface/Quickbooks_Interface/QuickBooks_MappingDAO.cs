using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Quickbooks_Interface
{
    public class QuickBooks_MappingDAO
    {
        public void insertMapping(QuickBooks_Mapping pMapping, string pUser)
        {
            string _sql = "call spQuickbooks_insertMapping('" + pMapping.GLACCOUNT + "','" + pMapping.TRANSACTIONCODE + "','" + pMapping.MAPPINGTYPE + "','" + pUser + "')";
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

        public DataTable getMapping()
        {
            string _sql = "call spQuickbooks_getMappingList()";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("MappingList");
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nError Location: " + this.ToString());
            }
        }

        public DataTable getTransactionCodes()
        {
            string _sql = "call spGetTransactionCodes('1')";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(_sql, GlobalVariables.gPersistentConnection);
                DataTable dt = new DataTable("TransactionCodes");
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + "\nError Location: " + this.ToString());
            }
        }
    }
}
