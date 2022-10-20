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
    public class EventOrderDAO
    {
        public EventOrderDAO()
        { }

        public void saveEventOrderView(string pFolioID, string pHotelID, string pUserID)
        {


            string sql = "call spInsertEventOrderView(" + int.Parse(pHotelID) + ",'" + pFolioID + "','" + pUserID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
              //  cmd.Transaction = pTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //pTrans.Rollback();
                throw new Exception("ERROR: " + ex.Message + " = @ saveEventOrder() ");
            }
        }

        public DataTable getEventOrderView(string pFolioID,string pHotelID )
        {
            string sql = "call spGetEventOrderViewed('" + pFolioID + "','" + pHotelID + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("EventOrder");
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     
    }
}
