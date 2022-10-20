using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.AccountingInterface.DataAccessLayer
{
	public class ExactDAO
	{
		public ExactDAO()
		{ }


		public DataSet getTransactionCodesWithGLAccounts()
		{
			DataTable dtTransactionCodes = new DataTable("TransactionCodes");
			DataTable dtTransactionCodesGLAccounts = new DataTable("GLAccounts");

			DataSet objDataSet = new DataSet();

			string query = "call spGetTransactionCodes('" + GlobalVariables.gHotelId + "')";


			MySqlDataAdapter adapter = new MySqlDataAdapter(query, GlobalVariables.gPersistentConnection);
			adapter.Fill(dtTransactionCodes);

			DataColumn _colTranCode = dtTransactionCodes.Columns["TranCode"];
			
			objDataSet.Tables.Add(dtTransactionCodes);


			string queryGL = "call spGetTransactionCodesGLAccounts('" + GlobalVariables.gHotelId + "')";
			adapter = new MySqlDataAdapter(queryGL, GlobalVariables.gPersistentConnection);
			adapter.Fill(dtTransactionCodesGLAccounts);
			adapter.TableMappings.Add("TransactionCodes", "GLAccounts");

			DataColumn _colTranCodeGL = dtTransactionCodesGLAccounts.Columns["TransactionCode"];
			
			objDataSet.Tables.Add(dtTransactionCodesGLAccounts);

			DataRelation rel = new DataRelation("relation", _colTranCode, _colTranCodeGL);

			objDataSet.Relations.Add(rel);


			return objDataSet;

		}

	}

}
