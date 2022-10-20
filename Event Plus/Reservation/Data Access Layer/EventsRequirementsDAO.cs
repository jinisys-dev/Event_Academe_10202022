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
    public class EventsRequirementsDAO
    {
        public EventsRequirementsDAO()
        { }

        public void saveEventRequirements(EventRequirements eventReq, ref MySqlTransaction pTrans)
        {
            string folioID = eventReq.GetType().GetProperty("FolioID").GetValue(eventReq, null).ToString();
            string requirementCode = eventReq.GetType().GetProperty("RequirementCode").GetValue(eventReq, null).ToString();
            string description = eventReq.GetType().GetProperty("Description").GetValue(eventReq, null).ToString();
            string remarks = eventReq.GetType().GetProperty("Remarks").GetValue(eventReq, null).ToString();

            string sql = "Call spInsertEventRequirements('" + folioID + "','" + requirementCode + "','" + description + "','" + GlobalVariables.gLoggedOnUser + "','" + remarks + "')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                //MessageBox.Show("ERROR: " + ex.Message + " = @ saveEventRequirements() ");
                throw new Exception("ERROR: " + ex.Message + " = @ deleteEventRequirements() ");
            }
        }

        public void deleteEventRequirements(string folioID, ref MySqlTransaction pTrans)
        {
            string sql = "delete from event_requirements where folioID='" + folioID + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                //MessageBox.Show("ERROR: " + ex.Message + " = @ deleteEventRequirements() ");
                throw new Exception("ERROR: " + ex.Message + " = @ deleteEventRequirements() ");
            }
        }

        public DataTable getEventRequirements(string folioID)
        {
            string sql = "select * from event_requirements where folioID='" + folioID + "' order by remarks, requirementid";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("EventRequirements");
                da.Fill(dt);

                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
