using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess
{
	public class JournalEntryCodeDAO
	{
		MySqlConnection connection = null;
		MySqlDataAdapter adapter = null;
		MySqlCommand command = null;
		DataTable tempTable = null;

		public JournalEntryCodeDAO(MySqlConnection DBConnection)
		{
			connection = DBConnection;
		}

		public DataTable getAllJournalEntryCodes(int mHotelID)
		{
			string query = "call spEXACT_GetAllJournalEntryCodes(" + mHotelID + ")";
			
			try
			{
				adapter = new MySqlDataAdapter(query, connection);
				tempTable = new DataTable("exact_journalentrycodes");
				adapter.Fill(tempTable);

				adapter.Dispose();

				return tempTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


		public bool SaveNewJournalEntryCode(eJournalEntryCode objJournalEntryCode)
		{
			string query = "call spEXACT_InsertJournalEntryCode( '"
			+ objJournalEntryCode.pJournalEntryCode + "', '"
			+ objJournalEntryCode.pDescription + "', '"
			+ objJournalEntryCode.pCreatedBy + "') ";
			
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


		public bool UpdatJournalEntryCode(eJournalEntryCode objJournalEntryCode)
		{
			string query = "call spEXACT_UpdateJournalEntryCode( '"
			+ objJournalEntryCode.pJournalEntryCode + "', '"
			+ objJournalEntryCode.pDescription + "', '"
			+ objJournalEntryCode.pStatusFlag + "', '"
			+ objJournalEntryCode.pCreatedBy + "') ";

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



		public bool DeleteJournalEntryCode(eJournalEntryCode oJournalEntryCode)
		{

			string query = "call spEXACT_DeleteJournalEntryCode( '"
							+ oJournalEntryCode.pJournalEntryCode + "', '"
							+ oJournalEntryCode.pCreatedBy + "') ";

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
