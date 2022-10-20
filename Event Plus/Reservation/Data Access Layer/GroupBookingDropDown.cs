using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Data;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    public class GroupBookingDropDownDAO
    {
        public GroupBookingDropDownDAO()
        { }


        public DataTable getGroupFolioDropDown(MySqlConnection dbConnection)
        {
            string sqlStr = "call spGetGroupBookingDropDown(); ";

            DataTable dtGroupFolioDropDown = new DataTable("GroupFolioDropDown");
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlStr, dbConnection);
            adapter.Fill(dtGroupFolioDropDown);

            return dtGroupFolioDropDown;
        }

        public DataTable getGroupBooking(string pFieldName)
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetGroupBooking('" + pFieldName +"')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @GroupBookingDropDown.getGroupBooking\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getSpecificFieldName(string pFieldName)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetSpecificGroupBookingDropDown('" + pFieldName + "')", GlobalVariables.gPersistentConnection);
                try
                {
                    _adapter.Fill(_dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @GroupBookingDropDownDAO.getSpecificFieldName\r\n" + ex.Message);
            }
        }
    }
}
