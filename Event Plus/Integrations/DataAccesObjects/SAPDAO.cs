using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Integrations.DataAccesObjects
{
    public class SAPDAO
    {
        public SAPDAO()
        {
           
        }

        public bool saveTransCodeWithGLAccounts(string pTransactionCode, string pTransactionName,string pGLAccountCode,string pGLCostCentreAcc)
        {
            DataTable _dt = new DataTable();
            try
            {
                string queryGL = "call spInsertTransactionCodesGLAccounts('" + pTransactionCode + "','" + pTransactionName + "','" + pGLAccountCode + "','" + pGLCostCentreAcc + "','" + GlobalVariables.gLoggedOnUser + "','" + string.Format("{0:yyyy-MM-dd hh:mm:ss}",DateTime.Now) + "','" + GlobalVariables.gHotelId + "')";
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryGL, GlobalVariables.gPersistentConnection);
                adapter.Fill(_dt);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        public DataTable getTransCodeWithGLAccounts(string pTransCode)
        {
            DataTable _dt = new DataTable();
            try
            {
                string queryGL = "call spGetSpecificTransactionCodesGLAccounts('"+ pTransCode+ "','" + GlobalVariables.gHotelId + "')";
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryGL, GlobalVariables.gPersistentConnection);
                adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public DataTable getGLAccountsMapping()
        {
            DataTable _dt = new DataTable();
            try
            {
                string queryGL = "call spGetTransactionCodesGLAccounts('" + GlobalVariables.gHotelId + "')";
               	MySqlDataAdapter adapter = new MySqlDataAdapter(queryGL, GlobalVariables.gPersistentConnection);
                adapter.Fill(_dt);
                return _dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void deleteTransaction()
        {
             DataTable _dt = new DataTable();
            try
            {
                string queryGL = "call spDeleteTransactionCodesGLAccounts('" + GlobalVariables.gHotelId + "')";
               	MySqlDataAdapter adapter = new MySqlDataAdapter(queryGL, GlobalVariables.gPersistentConnection);
                adapter.Fill(_dt);
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
    
        }

    }
}
