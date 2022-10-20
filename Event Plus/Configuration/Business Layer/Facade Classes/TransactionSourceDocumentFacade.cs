using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Jinisys.Hotel.ConfigurationHotel.DataAccess;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class TransactionSourceDocumentFacade
	{

		private TransactionSourceDocumentDAO oTransactionSourceDocumentDAO;
		public TransactionSourceDocumentFacade()
		{
		}

		private DataTable oTransactionSourceDocument;
		public IList<TransactionSourceDocument> getTransactionSourceDocuments()
		{
			oTransactionSourceDocumentDAO = new TransactionSourceDocumentDAO();

			oTransactionSourceDocument = oTransactionSourceDocumentDAO.getTransactionSourceDocuments();
			IList<TransactionSourceDocument> ilTransactionSourceDocuments = new List<TransactionSourceDocument>();


			foreach (DataRow dRow in oTransactionSourceDocument.Rows)
			{
				TransactionSourceDocument TransactionSourceDocument = new TransactionSourceDocument();

				TransactionSourceDocument.TransactionSourceId = dRow["transactionSourceId"].ToString();
				TransactionSourceDocument.Description = dRow["description"].ToString();
				TransactionSourceDocument.Abbreviation = dRow["abbreviation"].ToString();
				TransactionSourceDocument.CreatedBy = dRow["createdBy"].ToString();
				TransactionSourceDocument.CreatedDate = DateTime.Parse( dRow["createdDate"].ToString() );
				TransactionSourceDocument.UpdatedBy = dRow["updatedBy"].ToString();
				TransactionSourceDocument.UpdatedDate = DateTime.Parse( dRow["updatedDate"].ToString() );
				
				ilTransactionSourceDocuments.Add(TransactionSourceDocument);
			}
			return ilTransactionSourceDocuments;
		}

		// passes parameters a_TransactionSourceDocument = new TransactionSourceDocument
		// and a_IlTransactionSourceDocument = the List of TransactionSourceDocuments maintained within this instance
		public void insertNewTransactionSourceDocument(TransactionSourceDocument a_TransactionSourceDocument, ref IList<TransactionSourceDocument> a_IlTransactionSourceDocuments)
		{
			string TransactionSourceDocumentId = "";

			try
			{
				oTransactionSourceDocumentDAO = new TransactionSourceDocumentDAO();
				TransactionSourceDocumentId = oTransactionSourceDocumentDAO.insertNewTransactionSourceDocument((object)a_TransactionSourceDocument);

				// add to IList ilTransactionSourceDocuments
				a_TransactionSourceDocument.TransactionSourceId = TransactionSourceDocumentId;
				a_IlTransactionSourceDocuments.Add(a_TransactionSourceDocument);

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}


		// passes parameters a_TransactionSourceDocument = new TransactionSourceDocument and
		// a_IlTransactionSourceDocument = the List of TransactionSourceDocuments maintained within this instance
		public void updateTransactionSourceDocumentInfo(TransactionSourceDocument a_TransactionSourceDocument, ref IList<TransactionSourceDocument> a_IlTransactionSourceDocuments)
		{
			try
			{
				
				oTransactionSourceDocumentDAO = new TransactionSourceDocumentDAO();
				oTransactionSourceDocumentDAO.updateTransactionSourceDocumentInfo((object)a_TransactionSourceDocument);

				// add to IList ilTransactionSourceDocuments
				foreach (TransactionSourceDocument TransactionSourceDocument in a_IlTransactionSourceDocuments)
				{
					if (TransactionSourceDocument.TransactionSourceId == a_TransactionSourceDocument.TransactionSourceId)
					{
						TransactionSourceDocument.Description = a_TransactionSourceDocument.Description;
						TransactionSourceDocument.Abbreviation = a_TransactionSourceDocument.Abbreviation;
						
						break;
					}
				}

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public void deleteTransactionSourceDocument(string a_TransactionSourceDocumentId, ref IList<TransactionSourceDocument> a_IlTransactionSourceDocuments)
		{
			try
			{
				oTransactionSourceDocumentDAO = new TransactionSourceDocumentDAO();
				oTransactionSourceDocumentDAO.deleteTransactionSourceDocument(a_TransactionSourceDocumentId);

				// add to IList ilTransactionSourceDocuments
				foreach (TransactionSourceDocument TransactionSourceDocument in a_IlTransactionSourceDocuments)
				{
					if (TransactionSourceDocument.TransactionSourceId == a_TransactionSourceDocumentId)
					{

						a_IlTransactionSourceDocuments.Remove(TransactionSourceDocument);

						break;
					}
				}

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
	}
}

