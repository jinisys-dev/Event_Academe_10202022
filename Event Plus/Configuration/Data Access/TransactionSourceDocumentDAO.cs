using System;
using System.Collections.Generic;
using System.Text;

using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;

using System.Data;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccess
{
	public class TransactionSourceDocumentDAO
	{

		private MySqlConnection localConnection;
		private string loggedUser;
		private int hotelId;

		public TransactionSourceDocumentDAO()
		{
			localConnection = GlobalVariables.gPersistentConnection;
			hotelId = GlobalVariables.gHotelId;
			loggedUser = GlobalVariables.gLoggedOnUser;
		}

		public DataTable getTransactionSourceDocuments()
		{
			DataTable dtTransactionSourceDocuments = new DataTable("TransactionSourceDocuments");
			try
			{
				string strQuery = "call spSelectTransactionSourceDocuments()";

				MySqlDataAdapter dtaSelect = new MySqlDataAdapter(strQuery, localConnection);
				dtaSelect.Fill(dtTransactionSourceDocuments);

				return dtTransactionSourceDocuments;
			}
			catch(Exception ex)
			{
				throw (ex);
			}


			
		}

		public string insertNewTransactionSourceDocument(object pTransactionSourceDocument)
		{
			try
			{
				string TransactionSourceDocumentId = "";
				string abbreviation = pTransactionSourceDocument.GetType().GetProperty("Abbreviation").GetValue(pTransactionSourceDocument, null).ToString();
				string description = pTransactionSourceDocument.GetType().GetProperty("Description").GetValue(pTransactionSourceDocument, null).ToString();

				string strQuery = "call spInsertTransactionSourceDocument('" + 
											description + "','" + 
											abbreviation + "','" +
											GlobalVariables.gLoggedOnUser + "')";

				MySqlCommand insertCommand = new MySqlCommand(strQuery, localConnection);
				object objLastInsertId = insertCommand.ExecuteScalar();

				TransactionSourceDocumentId = objLastInsertId.ToString();

				return TransactionSourceDocumentId;

			}
			catch(Exception ex)
			{
				throw (ex);
			}


		}


		public int updateTransactionSourceDocumentInfo(object a_TransactionSourceDocument)
		{
			int rowsAffected = 0;
			try
			{
				string transdocId = a_TransactionSourceDocument.GetType().GetProperty("TransactionSourceId").GetValue(a_TransactionSourceDocument, null).ToString();
				string description = a_TransactionSourceDocument.GetType().GetProperty("Description").GetValue(a_TransactionSourceDocument, null).ToString();
				string abbreviation = a_TransactionSourceDocument.GetType().GetProperty("Abbreviation").GetValue(a_TransactionSourceDocument, null).ToString();
				string updatedBy = GlobalVariables.gLoggedOnUser;


				string strQuery = "call spUpdateTransactionSourceDocument('" + 
					                    transdocId + "','" + 
										description + "','" + 
										abbreviation + "','" + 
										updatedBy + "')";

				MySqlCommand updateCommand = new MySqlCommand(strQuery, localConnection);
				rowsAffected = updateCommand.ExecuteNonQuery();

				return rowsAffected;
			}
			catch (Exception ex)
			{
				throw (ex);
			}


		}


		public int deleteTransactionSourceDocument(string a_TransactionSourceDocumentId)
		{
			int rowsAffected = 0;
			try
			{

				string strQuery = "call spDeleteTransactionSourceDocument('" + a_TransactionSourceDocumentId 
								  + "','" + loggedUser + "')";

				MySqlCommand deleteCommand = new MySqlCommand(strQuery, localConnection);
				rowsAffected = deleteCommand.ExecuteNonQuery();

				return rowsAffected;

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}
	}
}
