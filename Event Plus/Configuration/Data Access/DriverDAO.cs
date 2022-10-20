using System;
using System.Collections.Generic;
using System.Text;

using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;

using System.Data;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccess
{
	class DriverDAO
	{

		private MySqlConnection localConnection;
		private string loggedUser;
		private int hotelId;

		public DriverDAO()
		{
			localConnection = GlobalVariables.gPersistentConnection;
			hotelId = GlobalVariables.gHotelId;
			loggedUser = GlobalVariables.gLoggedOnUser;
		}

		public DataTable getDrivers()
		{
			DataTable dtDrivers = new DataTable("Drivers");
			try
			{
				string strQuery = "call spSelectDrivers('" + hotelId + "')";

				MySqlDataAdapter dtaSelect = new MySqlDataAdapter(strQuery, localConnection);
				dtaSelect.Fill(dtDrivers);

				return dtDrivers;
			}
			catch(Exception ex)
			{
				throw (ex);
			}			
		}

		public string insertNewDriver(object a_Driver)
		{
			try
			{
				string driverId = "";
				string licenseNumber = a_Driver.GetType().GetProperty("LicenseNumber").GetValue(a_Driver, null).ToString();
				string lastName = a_Driver.GetType().GetProperty("LastName").GetValue(a_Driver, null).ToString();
				string firstName = a_Driver.GetType().GetProperty("FirstName").GetValue(a_Driver, null).ToString();
				string middleName = a_Driver.GetType().GetProperty("MiddleName").GetValue(a_Driver, null).ToString();
                string company = a_Driver.GetType().GetProperty("Company").GetValue(a_Driver, null).ToString();
                string carModel = a_Driver.GetType().GetProperty("Car_Model").GetValue(a_Driver, null).ToString();
                string brand = a_Driver.GetType().GetProperty("Brand").GetValue(a_Driver, null).ToString();
                string plateNumber = a_Driver.GetType().GetProperty("Plate_Number").GetValue(a_Driver, null).ToString();

				string strQuery = "call spInsertDriver('" + licenseNumber
								  + "','" + lastName + "','" + firstName
								  + "','" + middleName + "','" + loggedUser 
								  + "','" + hotelId + "','" + company + "','" +
                                  carModel + "','" + brand + "','" + plateNumber + "')";

				MySqlCommand insertCommand = new MySqlCommand(strQuery, localConnection);
				object objLastInsertId = insertCommand.ExecuteScalar();

				driverId = objLastInsertId.ToString();

				return driverId;

			}
			catch(Exception ex)
			{
				throw (ex);
			}


		}


		public int updateDriverInfo(object a_Driver)
		{
			int rowsAffected = 0;
			try
			{
				string driverId = a_Driver.GetType().GetProperty("DriverId").GetValue(a_Driver, null).ToString();
				string licenseNumber = a_Driver.GetType().GetProperty("LicenseNumber").GetValue(a_Driver, null).ToString();
				string lastName = a_Driver.GetType().GetProperty("LastName").GetValue(a_Driver, null).ToString();
				string firstName = a_Driver.GetType().GetProperty("FirstName").GetValue(a_Driver, null).ToString();
				string middleName = a_Driver.GetType().GetProperty("MiddleName").GetValue(a_Driver, null).ToString();
                string company = a_Driver.GetType().GetProperty("Company").GetValue(a_Driver, null).ToString();
                string carModel = a_Driver.GetType().GetProperty("Car_Model").GetValue(a_Driver, null).ToString();
                string brand = a_Driver.GetType().GetProperty("Brand").GetValue(a_Driver, null).ToString();
                string plateNumber = a_Driver.GetType().GetProperty("Plate_Number").GetValue(a_Driver, null).ToString();

				string strQuery = "call spUpdateDriver('" + driverId + "','" + licenseNumber
								  + "','" + lastName + "','" + firstName
								  + "','" + middleName + "','" + loggedUser
                                  + "','" + hotelId + "','" + company + "','" +
                                  carModel + "','" + brand + "','" + plateNumber + "')";

				MySqlCommand updateCommand = new MySqlCommand(strQuery, localConnection);
				rowsAffected = updateCommand.ExecuteNonQuery();

				return rowsAffected;
			}
			catch (Exception ex)
			{
				throw (ex);
			}


		}


		public int deleteDriver(string a_DriverId)
		{
			int rowsAffected = 0;
			try
			{

				string strQuery = "call spDeleteDriver('" + a_DriverId 
								  + "','" + loggedUser
								  + "','" + hotelId + "')";

				MySqlCommand deleteCommand = new MySqlCommand(strQuery, localConnection);
				rowsAffected = deleteCommand.ExecuteNonQuery();

				return rowsAffected;

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

        public DataTable getDriversGuestFolios(string pDriverID)
        {
            try
            {
                string sql = "select referenceFolioID, roomNumber, GuestName, netAmount from nonguesttransaction where referenceDriverID='" + pDriverID + "' and hotelid=" + GlobalVariables.gHotelId + " and statusflag!='VOID'";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                DataTable dTable = new DataTable();

                dataAdapter.Fill(dTable);
                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
