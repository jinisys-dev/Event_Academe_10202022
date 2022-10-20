using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.AccountingInterface.SAP_Interface
{
    public class Folio_GLAccountMappingDAO
    {

      
        public static DataTable getAllFolioGLaccountMapping(int mHotelID, MySqlConnection connection)
        {
            string query = "call spSAP_GetAllGLaccounts('" + mHotelID + "')";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable tempTable = new DataTable("sap_glaccounts");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable getFolioGLMapping(MySqlConnection connection)
        {
            string query = "call spSAP_GetFolioGLMapping()";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable tempTable = new DataTable("GL_FolioMaping");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static DataTable getTransactionCodeMapping(string pTransactionCode, MySqlConnection connection)
        {

            string query = "call spSAP_GetTranCodeGLaccountMapping('" + pTransactionCode + "')";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable tempTable = new DataTable("sap_glaccounts");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void saveFolioMapping(Folio_GLAccountMapping poGLMapping)
        {
            string query = "call spSAP_InsertFolioGLMapping( '"
                                + poGLMapping.TranCode + "', '"
                                + poGLMapping.GLAccountID + "'," 
                                + poGLMapping.LineNo + ", '"
                                + poGLMapping.AmountColumnInFolioTrans + "', '"
                                + poGLMapping.CostCenterCode + "', '"
                                + poGLMapping.StatuFlag + "', '"
                                + poGLMapping.CreatedBy + "') ";

            try
            {
                MySqlCommand command = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                command.ExecuteNonQuery();

                command.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool DeleteGLAccountMapping(string pTransactionCode, string pGLAccountID)
        {
            string query = "call spSAP_DeleteGLaccountMapping( '"
                                    + pTransactionCode + "', '"
                                    + pGLAccountID + "') ";

            try
            {
                MySqlCommand command = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
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
    }

}
