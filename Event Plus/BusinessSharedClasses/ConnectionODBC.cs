using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.IO;

namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class ConnectionODBC
	{
		
		private System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection();
		private string connectionStringPath;
		
		public ConnectionODBC(string conStringFilePath)
		{
			connectionStringPath = conStringFilePath;
		}
		public ConnectionODBC()
		{
			
		}
		public string ConnectionString
		{
			get
			{
				return ConnectionString;
			}
			set
			{
				ConnectionString = value;
			}
		}
		public System.Data.Odbc.OdbcConnection openConnection(string userName, string passWord)
		{
			
			StreamReader streamReader = new StreamReader(connectionStringPath);
			
			string connectionString = streamReader.ReadLine();
			
			connectionString = connectionString.Replace("UID=", "UID=" + userName);
			connectionString = connectionString.Replace("Password=", "Password=" + passWord);
			try
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				
				return conn;
			}
			catch (Exception)
			{
				return null;
			}
		}
		public string getConnectionString(string userName, string passWord)
		{
			
			StreamReader streamReader = new StreamReader(connectionStringPath);
			
			string connectionString = streamReader.ReadLine();
			
			connectionString = connectionString.Replace("UID=", "UID=" + userName);
			connectionString = connectionString.Replace("Password=", "Password=" + passWord);
			return connectionString;
		}
	}
	
}
