using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;


namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class AppliedRatesDAO
    {
        public AppliedRatesDAO()
        { }

        public void saveAppliedRates(EventAppliedRates appliedRates)
        {
            string folioID = appliedRates.GetType().GetProperty("FolioID").GetValue(appliedRates, null).ToString();
            string rateType = appliedRates.GetType().GetProperty("RateType").GetValue(appliedRates, null).ToString();
            string description = appliedRates.GetType().GetProperty("Description").GetValue(appliedRates, null).ToString();
            double rateAmount = double.Parse(appliedRates.GetType().GetProperty("RateAmount").GetValue(appliedRates, null).ToString());

            string sql = "call spInsertAppliedRates('" + folioID + "','" + rateType + "','" + description + "'," + rateAmount + ",'" + GlobalVariables.gLoggedOnUser + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAppliedRatesForEvents(string folioID)
        {
            string sql = "call spGetAppliedRatesForEvents('" + folioID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("AppliedRates");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteAppliedRates(string folioID)
        {
            string sql = "delete from event_applied_rates where folioID='" + folioID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
