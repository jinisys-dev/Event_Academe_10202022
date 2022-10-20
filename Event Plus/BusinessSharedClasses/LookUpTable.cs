using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class LookUpTable
	{
		
		public LookUpTable()
		{
			
		}
		private string connectionString;
		public LookUpTable(string conStr)
		{
			connectionString = conStr;
		}
		public DataTable GetData(string category)
		{
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();
			string CommandStr = "spGetLookupValue";
			MySqlCommand Command = new MySqlCommand(CommandStr, connection);
			Command.CommandType = CommandType.StoredProcedure;
			MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
			DataTable LookUpTable = new DataTable("LookUpTable");
			
			try
			{
				DataAdapter.Fill(LookUpTable);
				return LookUpTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
			finally
			{
				connection.Close();
			}
		}
	}
	
}
