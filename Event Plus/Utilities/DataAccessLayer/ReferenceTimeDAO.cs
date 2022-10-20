using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Utilities.BusinessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.Utilities.DataAccessLayer
{
    public class ReferenceTimeDAO
    {
        public ReferenceTime GetReferenceTime()
        {
            if (GlobalVariables.gPersistentConnection.State == System.Data.ConnectionState.Closed)
            {
                GlobalVariables.gPersistentConnection.Open();
            }
            MySqlCommand cmdSelect = new MySqlCommand("call spGetReferenceTime()",GlobalVariables.gPersistentConnection);
            MySqlDataReader reader = cmdSelect.ExecuteReader();
            ReferenceTime refTime=null;
           
            while (reader.Read())
            {
                refTime = new ReferenceTime();
                refTime.RefTime = reader.GetString(0);
                refTime.Minimum = reader.GetInt32(1);
                refTime.Maximum = reader.GetInt32(2);
            }
            reader.Close();
            return refTime;
        }
        public bool UpdateRefTime(ReferenceTime refTime)
        {
            bool success = false;
            if (GlobalVariables.gPersistentConnection.State == System.Data.ConnectionState.Closed)
            {
                GlobalVariables.gPersistentConnection.Open();
            }
            MySqlCommand cmdUpdate = new MySqlCommand("call spUpdateRefTime('" + refTime.RefTime + "'," + refTime.Minimum + "," + refTime .Maximum + ")", GlobalVariables.gPersistentConnection);
            if (cmdUpdate.ExecuteNonQuery() > 0)
            {
                success = true;
            }
            return success;
        }
    }
}
