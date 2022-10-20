using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Jinisys.Hotel.ConfigurationHotel.DataAccess;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
	public class DriverFacade
	{

		private DriverDAO oDriverDAO;
		public DriverFacade()
		{
		}

		private DataTable oDriver;
		public IList<Driver> getDrivers()
		{
			oDriverDAO = new DriverDAO();

			oDriver = oDriverDAO.getDrivers();
			IList<Driver> ilDrivers = new List<Driver>();


			foreach (DataRow dRow in oDriver.Rows)
			{
				Driver driver = new Driver();

				driver.DriverId = dRow["DriverId"].ToString();
				driver.LicenseNumber = dRow["LicenseNumber"].ToString();
				driver.LastName = dRow["LastName"].ToString();
				driver.FirstName = dRow["FirstName"].ToString();
				driver.MiddleName = dRow["MiddleName"].ToString();
				driver.TotalCommission = double.Parse(dRow["TotalCommission"].ToString());
				driver.CREATED_DATE = DateTime.Parse(dRow["CREATED_DATE"].ToString());
				driver.CREATED_BY = dRow["CREATED_BY"].ToString();
				driver.UPDATED_DATE = DateTime.Parse(dRow["UPDATED_DATE"].ToString());
				driver.UPDATED_BY = dRow["UPDATED_BY"].ToString();
				driver.HOTEL_ID = int.Parse(dRow["HOTEL_ID"].ToString());
                driver.Brand = dRow["brand"].ToString();
                driver.Car_Model = dRow["carModel"].ToString();
                driver.Company = dRow["company"].ToString();
                driver.Plate_Number = dRow["plateNumber"].ToString();

				ilDrivers.Add(driver);
			}
			return ilDrivers;
		}

		// passes parameters a_Driver = new Driver
		// and a_IlDriver = the List of drivers maintained within this instance
		public void insertNewDriver(Driver a_Driver, ref IList<Driver> a_IlDrivers)
		{
			string driverId = "";

			try
			{
				oDriverDAO = new DriverDAO();
				driverId = oDriverDAO.insertNewDriver((object)a_Driver);

				// add to IList ilDrivers
				a_Driver.DriverId = driverId;
				a_IlDrivers.Add(a_Driver);

			}
			catch(Exception ex)
			{
				throw (ex);
			}
			
		}


		// passes parameters a_Driver = new Driver and
		// a_IlDriver = the List of drivers maintained within this instance
		public void updateDriverInfo(Driver a_Driver, ref IList<Driver> a_IlDrivers)
		{
			try
			{
				oDriverDAO = new DriverDAO();
				oDriverDAO.updateDriverInfo((object)a_Driver);

				// add to IList ilDrivers
				foreach(Driver driver in a_IlDrivers)
				{
					if (driver.DriverId == a_Driver.DriverId)
					{
						driver.LicenseNumber = a_Driver.LicenseNumber;
						driver.LastName = a_Driver.LastName;
						driver.FirstName = a_Driver.FirstName;
						driver.MiddleName = a_Driver.MiddleName;
                        driver.Brand = a_Driver.Brand;
                        driver.Car_Model = a_Driver.Car_Model;
                        driver.Company = a_Driver.Company;
                        driver.Plate_Number = a_Driver.Plate_Number;

						break;
					}
				}

			}
			catch (Exception ex)
			{
				throw (ex);
			}

		}

		public void deleteDriver(string a_DriverId, ref IList<Driver> a_IlDrivers)
		{
			try
			{
				oDriverDAO = new DriverDAO();
				oDriverDAO.deleteDriver(a_DriverId);

				// add to IList ilDrivers
				foreach (Driver driver in a_IlDrivers)
				{
					if (driver.DriverId == a_DriverId)
					{

						a_IlDrivers.Remove(driver);

						break;
					}
				}

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

        public DataTable getDriversGuestFolios(string pDriverID)
        {
            oDriverDAO = new DriverDAO();
            return oDriverDAO.getDriversGuestFolios(pDriverID);
        }
	}
}

