using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class EventPackageDAO
    {
        public EventPackageDAO()
        { }

        public double getEventPackageAmount(string packageID)
        {
            string sql = "select packageAmount from event_package_header where packageID='" + packageID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                double amount = double.Parse(cmd.ExecuteScalar().ToString());

                return amount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string saveEventPackage(EventPackageHeader poEventPackageHeader)
        {
            string _description = poEventPackageHeader.GetType().GetProperty("Description").GetValue(poEventPackageHeader, null).ToString();
            int _daysApplied = int.Parse(poEventPackageHeader.GetType().GetProperty("DaysApplied").GetValue(poEventPackageHeader, null).ToString());
            string _eventType = poEventPackageHeader.GetType().GetProperty("EventType").GetValue(poEventPackageHeader, null).ToString();
            double _packageAmount = double.Parse(poEventPackageHeader.GetType().GetProperty("PackageAmount").GetValue(poEventPackageHeader, null).ToString());
            int _minimumPax = int.Parse(poEventPackageHeader.GetType().GetProperty("MinimumPax").GetValue(poEventPackageHeader,null).ToString());
            int _maximumPax = int.Parse(poEventPackageHeader.GetType().GetProperty("MaximumPax").GetValue(poEventPackageHeader, null).ToString());

            try
            {
                string _sqlQuery = "call spInsertEventPackage('" + _description + "'," + _daysApplied + ",'" + _eventType + "'," + _packageAmount + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "'," + _minimumPax + "," + _maximumPax + ")";

                MySqlCommand _cmdInsert = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                string _packageID = _cmdInsert.ExecuteScalar().ToString();

                return _packageID;
            }
            catch (Exception pException)
            {
                throw pException;
            }
        }

        public void updateEventPackage(EventPackageHeader poEventPackageHeader)
        {
            int _packageID = int.Parse(poEventPackageHeader.GetType().GetProperty("PackageID").GetValue(poEventPackageHeader, null).ToString());
            string _description = poEventPackageHeader.GetType().GetProperty("Description").GetValue(poEventPackageHeader, null).ToString();
            int _daysApplied = int.Parse(poEventPackageHeader.GetType().GetProperty("DaysApplied").GetValue(poEventPackageHeader, null).ToString());
            string _eventType = poEventPackageHeader.GetType().GetProperty("EventType").GetValue(poEventPackageHeader, null).ToString();
            double _packageAmount = double.Parse(poEventPackageHeader.GetType().GetProperty("PackageAmount").GetValue(poEventPackageHeader, null).ToString());
            int _minimumPax = int.Parse(poEventPackageHeader.GetType().GetProperty("MinimumPax").GetValue(poEventPackageHeader,null).ToString());
            int _maximumPax = int.Parse(poEventPackageHeader.GetType().GetProperty("MaximumPax").GetValue(poEventPackageHeader, null).ToString());

            try
            {
                string _sqlQuery = "call spUpdateEventPackage(" + _packageID + ",'" + _description + "'," + _daysApplied + ",'" + _eventType + "'," + _packageAmount + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "'," + _minimumPax + "," + _maximumPax + ")";
                MySqlCommand _cmdUpdate = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception pException)
            {
                throw pException;
            }
        }

        public void deleteEventPackage(string pPackageID)
        {
            string _sqlQuery = "call spDeleteEventPackage('" + pPackageID + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmdDelete = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdDelete.ExecuteNonQuery();
            }
            catch (Exception pException)
            {
                throw pException;
            }
        }

        public DataTable getEventPackages()
        {
            try
            {
                string _sqlQuery = "call spSelectEventPackages(" + GlobalVariables.gHotelId + ")";
                MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _dtSelect = new DataTable("EventPackages");

                _daSelect.Fill(_dtSelect);
                return _dtSelect;
            }
            catch (Exception pException)
            {
                throw pException;
            }
        }

        public DataTable getEventPackage(string pPackageID)
        {
            try
            {
                string _sqlQuery = "call spSelectEventPackage(" + GlobalVariables.gHotelId + ",'" + pPackageID + "')";
                MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _dtSelect = new DataTable("EventPackages");

                _daSelect.Fill(_dtSelect);
                return _dtSelect;
            }
            catch (Exception pException)
            {
                throw pException;
            }
        }
    }
}
