using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace ApplicationStarter.Data_Access_Layer
{
    class UtilityDAO
    {
        private MySqlConnection localConnection;
        public UtilityDAO(MySqlConnection connection)
        {
            localConnection = connection;
        }

        public DataTable getDatabases()
        {
            DataTable dtDatabaseList = new DataTable();

            try
            {
                MySqlDataAdapter selectAdapter = new MySqlDataAdapter("show databases", localConnection);
                selectAdapter.Fill(dtDatabaseList);

                return dtDatabaseList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
