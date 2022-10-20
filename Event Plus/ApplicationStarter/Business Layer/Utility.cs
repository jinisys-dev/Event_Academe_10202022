using System;
using System.Collections.Generic;
using System.Text;
using ApplicationStarter.Data_Access_Layer;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
namespace ApplicationStarter.Business_Layer
{
    class Utility
    {
        private MySqlConnection myDBCon;
        private static string lConnectionString;
        public Utility(string conStr)
        {
            lConnectionString = conStr;
            connectDatabase();
        }

        private void connectDatabase()
        {
            try
            {
                if (lConnectionString != "")
                {
                    myDBCon = new MySqlConnection(lConnectionString);

                    myDBCon.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't connect to the server. " + "\r\n" + "Error Message: " + ex.Message, "Database Error");
                Process.Start("ConfigLoader.exe");
                Application.Exit();
                
            }
        }
        private UtilityDAO oUtilityDAO;
        public DataTable getDatabases()
        {
            oUtilityDAO = new UtilityDAO(myDBCon);
            return oUtilityDAO.getDatabases();
        }

        public void closeConnection()
        {
            myDBCon.Close();
        }

        
    }
}
