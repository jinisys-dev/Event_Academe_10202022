using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.SAP_Interface
{
    public class GLaccountDAO
    {
        
        public GLaccountDAO()
        {
        }

        private MySqlCommand command;
        private MySqlConnection connection = GlobalVariables.gPersistentConnection;

        public static DataTable getAllGLaccounts(int mHotelID, MySqlConnection connection)
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

        public bool SaveNewGLaccounts(GLaccount objGLaccounts)
        {
            string query = "call spSAP_InsertGLaccounts( '"
                                + objGLaccounts.pAccountID + "', '"
                                + objGLaccounts.pDescription + "', '"
                                + objGLaccounts.pCostCenterCode + "', '"
                                + objGLaccounts.pAccountNature + "', '"
                                + objGLaccounts.pCreatedBy + "') ";

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


        public bool UpdatGLaccounts(GLaccount objGLaccounts)
        {
            string query = "call spSAP_UpdateGLaccounts( '"
                                + objGLaccounts.pAccountID + "', '"
                                + objGLaccounts.pDescription + "', '"
                                + objGLaccounts.pCostCenterCode + "', '"
                                + objGLaccounts.pAccountNature + "', '"
                                + objGLaccounts.pStatusFlag + "', '"
                                + objGLaccounts.pCreatedBy + "') ";

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

        public bool DeleteGLAccount(string pAccountID)
        {
            string query = "call spSAP_DeleteGLaccounts( '"
                                    + pAccountID + "', '"
                                    + GlobalVariables.gLoggedOnUser + "') ";

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
    }
}
