using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess
{
	public class GLaccountsDAO
	{
		MySqlConnection connection = null;
		MySqlDataAdapter adapter = null;
		MySqlCommand command = null;
		DataTable tempTable = null;

		public GLaccountsDAO(MySqlConnection DBConnection)
		{
			connection = DBConnection;
		}

		public DataTable getAllGLaccounts(int mHotelID)
		{
			string query = "call spEXACT_GetAllGLaccounts('" + mHotelID + "')";
			try
			{
				adapter = new MySqlDataAdapter(query, connection);
				tempTable = new DataTable("exact_glaccounts");
				adapter.Fill(tempTable);

				adapter.Dispose();
				
				return tempTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


		public bool SaveNewGLaccounts(eGLaccounts objGLaccounts)
		{
			string query = "call spEXACT_InsertGLaccounts( '"
								+ objGLaccounts.pAccountID + "', '"
								+ objGLaccounts.pDescription + "', '"
								+ objGLaccounts.pCostCenterCode + "', '"
								+ objGLaccounts.pAccountNature + "', '"
								+ objGLaccounts.pCreatedBy + "') ";

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


		public bool UpdatGLaccounts(eGLaccounts objGLaccounts)
		{
			string query = "call spEXACT_UpdateGLaccounts( '"
								+ objGLaccounts.pAccountID + "', '"
								+ objGLaccounts.pDescription + "', '"
								+ objGLaccounts.pCostCenterCode + "', '"
								+ objGLaccounts.pAccountNature + "', '"
								+ objGLaccounts.pStatusFlag + "', '"
								+ objGLaccounts.pCreatedBy + "') ";

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



		public bool DeleteGLAccount(eGLaccounts oGLaccounts)
		{
			string query = "call spEXACT_DeleteGLaccounts( '"
									+ oGLaccounts.pAccountID + "', '"
									+ oGLaccounts.pUpdatedBy + "') ";

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
