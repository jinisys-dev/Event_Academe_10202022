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
    class AppliedRatesDAO
    {
        public AppliedRatesDAO()
        { }

        public string saveAppliedRates(AppliedRates poAppliedRates)
        {
            string _description = poAppliedRates.GetType().GetProperty("Description").GetValue(poAppliedRates, null).ToString();
            int _noOfOccupants = int.Parse(poAppliedRates.GetType().GetProperty("NumberOfOccupants").GetValue(poAppliedRates, null).ToString());
            string rateType = poAppliedRates.GetType().GetProperty("RateType").GetValue(poAppliedRates, null).ToString();

            string _sqlQuery = "call spInsertAppliedRates('" + _description + "'," + _noOfOccupants + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "','" + rateType + "')";
            try
            {
                MySqlCommand _cmd = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                string _lastInsertID = _cmd.ExecuteScalar().ToString();

                return _lastInsertID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateAppliedRates(AppliedRates poAppliedRates)
        {
            int _appliedRateID = int.Parse(poAppliedRates.GetType().GetProperty("AppliedRateID").GetValue(poAppliedRates, null).ToString());
            string _description = poAppliedRates.GetType().GetProperty("Description").GetValue(poAppliedRates, null).ToString();
            int _noOfOccupants = int.Parse(poAppliedRates.GetType().GetProperty("NumberOfOccupants").GetValue(poAppliedRates, null).ToString());
            string rateType = poAppliedRates.GetType().GetProperty("RateType").GetValue(poAppliedRates, null).ToString();

            string _sqlQuery = "Call spUpdateAppliedRates(" + _appliedRateID + ",'" + _description + "'," + _noOfOccupants + "," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "','" + rateType + "')";
            try
            {
                MySqlCommand _cmdUpdate = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAppliedRates()
        {
            string _sqlSelect = "call spSelectAllAppliedRates()";
            try
            {
                MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlSelect, GlobalVariables.gPersistentConnection);
                DataTable _dtSelect=new DataTable("AppliedRates");

                _daSelect.Fill(_dtSelect);
                return _dtSelect;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void deleteAppliedRate(string appliedRateID)
        {
            string _sqlDelete = "call spDeleteAppliedRate('" + appliedRateID + "'," + GlobalVariables.gHotelId + ",'" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand _cmdDelete = new MySqlCommand(_sqlDelete, GlobalVariables.gPersistentConnection);
                _cmdDelete.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
