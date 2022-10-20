using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;

namespace Jinisys.Hotel.Utilities.DataAccessLayer
{

		public class BackUpDAO
		{
		
			public BackUpDAO(){}

			public ArrayList getDatabases()
			{
                try 
                {
				    ArrayList databases = new ArrayList();
    			
				    MySqlCommand selectCommand = new MySqlCommand("show databases", GlobalVariables.gPersistentConnection);
				    selectCommand.CommandType = CommandType.Text;
				    MySqlDataReader dataReader = selectCommand.ExecuteReader();
    				
				    while (dataReader.Read())
				    {
					    databases.Add(dataReader.GetValue(0));
				    }
				    dataReader.Close();

				    return databases;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot Retrieve Databases");
					return null;
                }
				
			}
		}

	
}
