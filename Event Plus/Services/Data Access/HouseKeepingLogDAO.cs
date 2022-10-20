using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;
namespace Jinisys.Hotel.Services.DataAccessLayer
{
    class HouseKeepingLogDAO
    {

        public HouseKeepingLogDAO() { }

        public DataTable GetHouseKeepingLogs(string status,string date)
        {
            DataTable dTable = new DataTable();
            try
            {
                
                string sql = "call spGetHouseKeeping_Logs('"+ status +"','"+ date +"')";
                MySqlDataAdapter dAdapter = new MySqlDataAdapter(sql,GlobalVariables.gPersistentConnection);
                dAdapter.Fill(dTable);
                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @:GetHouseKeepingLogs()" + ex.Message);
                return null;
            }
        }
        public DataTable GetHouseKeepers()
        {
            DataTable dTable = new DataTable();
            try
            {

                string sql = "call spGetHK_Housekeepers()";
                MySqlDataAdapter dAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                dAdapter.Fill(dTable);
                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @:GetHouseKeepers()" + ex.Message);
                return null;
            }
        }
        public bool UpdateHouseKeepingLog(string roomId,string status,string hk_id,string sTime,string eTime,string duration)
        {
            try
            {
                string sql = "call spUpdateHouseKeepingLog('" + roomId + "','" + status + "','" + hk_id + "','" + sTime + "','" + eTime + "','" + duration + "')";
                MySqlCommand command = new MySqlCommand(sql,GlobalVariables.gPersistentConnection);
                int rowsAffected=command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION @:UpdateHouseKeepingLog()" + ex.Message);
                return false;
            }
        }


		public DataTable GetHouseKeepingLogs(string date)
		{
			DataTable dTable = new DataTable();
			try
			{

				string sql = "call spHK_GetHouseKeepingLogs('" + date + "')";
				MySqlDataAdapter dAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
				dAdapter.Fill(dTable);
				return dTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("EXCEPTION @:GetHouseKeepingLogs()" + ex.Message);
				return null;
			}
		}


    }
    
}
