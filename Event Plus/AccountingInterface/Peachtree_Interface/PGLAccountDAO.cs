using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Peachtree_Interface
{
    public class PGLaccountDAO
    {
        
        public PGLaccountDAO()
        {
        }

        private MySqlCommand command;
        private MySqlConnection connection = GlobalVariables.gPersistentConnection;

        public static DataTable getAllPGLaccounts(int mHotelID, MySqlConnection connection)
        {
            string query = "call spPeachtree_GetAllPGLaccounts('" + mHotelID + "')";
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable tempTable = new DataTable("peachtree_glaccounts");
                adapter.Fill(tempTable);

                adapter.Dispose();

                return tempTable;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public bool SaveNewGLaccounts(PGLaccount objGLaccounts)
        //{
        //    string query = "call spPeachtree_InsertPGLaccounts( '"
        //                        + objGLaccounts.pAccountID + "', '"
        //                        + objGLaccounts.pDescription + "', '"
        //                        + objGLaccounts.pCostCenterCode + "', '"
        //                        + objGLaccounts.pAccountNature + "', '"
        //                        + objGLaccounts.pCreatedBy + "') ";

        //    try
        //    {
        //        command = new MySqlCommand(query, connection);
        //        command.ExecuteNonQuery();

        //        command.Dispose();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        //public bool UpdatPGLaccounts(PGLaccount objGLaccounts)
        //{
        //    string query = "call spPeachtree_UpdatePGLaccounts( '"
        //                        + objGLaccounts.pAccountID + "', '"
        //                        + objGLaccounts.pDescription + "', '"
        //                        + objGLaccounts.pCostCenterCode + "', '"
        //                        + objGLaccounts.pAccountNature + "', '"
        //                        + objGLaccounts.pStatusFlag + "', '"
        //                        + objGLaccounts.pCreatedBy + "') ";

        //    try
        //    {
        //        command = new MySqlCommand(query, connection);
        //        int _rowsAffected = command.ExecuteNonQuery();

        //        command.Dispose();

        //        if (_rowsAffected <= 0)
        //        {
        //            throw (new Exception("No rows affected."));
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public bool DeletePGLAccount(string pAccountID)
        //{
        //    string query = "call spPeachtree_DeletePGLaccounts( '"
        //                            + pAccountID + "', '"
        //                            + GlobalVariables.gLoggedOnUser + "') ";

        //    try
        //    {
        //        command = new MySqlCommand(query, connection);
        //        int _rowsAffected = command.ExecuteNonQuery();

        //        command.Dispose();

        //        if (_rowsAffected <= 0)
        //        {
        //            throw (new Exception("No rows affected."));
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
}
