using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinsiys.Hotel.AccountingInterface.ExactGlobe.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.ExactGlobe.DataAccess
{
	public class CostCenterDAO
	{
		MySqlConnection connection = null;
		MySqlDataAdapter adapter = null;
		MySqlCommand command = null;
		DataTable tempTable = null;

		public CostCenterDAO(MySqlConnection DBConnection)
		{
			connection = DBConnection;
		}

		public DataTable getAllCostCenters(int mHotelID)
		{
			string query = "call spEXACT_GetAllCostCenters(" + mHotelID + ")";
			try
			{
				adapter = new MySqlDataAdapter(query, connection);
				tempTable = new DataTable("exact_costcenter");
				adapter.Fill(tempTable);

				adapter.Dispose();

				return tempTable;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


		public bool SaveNewCostCenter(eCostCenter objCostCenter)
		{
			string query = ""

			+ "call spExact_InsertCostCenter( '"
						 + objCostCenter.pCostCenterCode + "', '"
						 + objCostCenter.pDescription + "', '"
						 + objCostCenter.pCreatedBy + "' ) ";

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


		public bool UpdateCostCenter(eCostCenter objCostCenter)
		{
			string query = "call spExact_UpdateCostCenter( '"
									+ objCostCenter.pCostCenterCode + "', '"
									+ objCostCenter.pDescription + "', '"
									+ objCostCenter.pStatusFlag + "', '"
									+objCostCenter.pUpdatedBy + "') ";

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

		public bool DeleteCostCenter(eCostCenter objCostCenter)
		{
			string query = "call spExact_DeleteCostCenter( '"
									+ objCostCenter.pCostCenterCode + "', '"
									+ objCostCenter.pUpdatedBy + "') ";

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
