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
    public class EventPackageDetailDAO
    {
        public EventPackageDetailDAO()
        { }

        public DataTable getEventPackageDetail(string pPackageID)
        {
            string _sqlQuery = "call spSelectEventPackageDetails('" + pPackageID + "')";
            try
            {
                MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _dataTable = new DataTable("PackageDetails");
                _daSelect.Fill(_dataTable);

                return _dataTable;
            }
            catch (Exception pException)
            {
                throw pException;
            }
        }

        public void saveEventPackageDetail(EventPackageDetail poEventPackageDetail)
        {
            int _packageID = int.Parse(poEventPackageDetail.GetType().GetProperty("PackageID").GetValue(poEventPackageDetail, null).ToString());
            int _transactionCode = int.Parse(poEventPackageDetail.GetType().GetProperty("TransactionCode").GetValue(poEventPackageDetail, null).ToString());
            string _description = poEventPackageDetail.GetType().GetProperty("Description").GetValue(poEventPackageDetail, null).ToString();
            double _amount = double.Parse(poEventPackageDetail.GetType().GetProperty("Amount").GetValue(poEventPackageDetail, null).ToString());
            string _subAccount = poEventPackageDetail.GetType().GetProperty("SubAccount").GetValue(poEventPackageDetail, null).ToString();

            try
            {
                string _sqlQuery = "call spInsertEventPackageDetails(" + _packageID + "," + _transactionCode + ",'" + _description + "'," + _amount + ",'" + _subAccount + "')";
                MySqlCommand _cmdInsert = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEventPackageDetail(string pPackageID)
        {
            try
            {
                string _sqlQuery = "call spDeleteEventPackageDetails('" + pPackageID + "')";
                MySqlCommand _cmdDelete = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getEventPackageRequirements(string pPackageID)
        {
            string _sqlQuery = "call spSelectEventPackageRequirements('" + pPackageID + "')";
            try
            {
                MySqlDataAdapter _daSelect = new MySqlDataAdapter(_sqlQuery, GlobalVariables.gPersistentConnection);
                DataTable _dataTable = new DataTable("PackageRequirements");
                _daSelect.Fill(_dataTable);

                return _dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void saveEventPackageRequirements(EventPackageDetail poEventPackageRequirement)
        {
            int _packageID = int.Parse(poEventPackageRequirement.GetType().GetProperty("PackageID").GetValue(poEventPackageRequirement, null).ToString());
            string _requirementHeader = poEventPackageRequirement.GetType().GetProperty("RequirementHeader").GetValue(poEventPackageRequirement, null).ToString();
            string _requirementDetail = poEventPackageRequirement.GetType().GetProperty("RequirementDetail").GetValue(poEventPackageRequirement, null).ToString();

            try
            {
                string _sqlQuery = "Call spInsertEventPackageRequirements(" + _packageID + ",'" + _requirementHeader + "','" + _requirementDetail + "')";
                MySqlCommand _cmdInsert = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEventPackageRequirements(string pPackageID)
        {
            string _sqlQuery = "call spDeleteEventPackageRequirements('" + pPackageID + "')";
            try
            {
                MySqlCommand _cmdDelete = new MySqlCommand(_sqlQuery, GlobalVariables.gPersistentConnection);
                _cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getSubAccountForPackage(string pDescription, string pPackageID)
        {
            string query = "call spGetSubAccountForPackageDetail('" + pDescription + "','" + pPackageID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, GlobalVariables.gPersistentConnection);
                string result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
