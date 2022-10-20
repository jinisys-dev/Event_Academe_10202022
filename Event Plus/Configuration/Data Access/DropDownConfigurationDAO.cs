using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    class DropDownConfigurationDAO
    {
        public DataTable getGroupBookingDropDown()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetGroupBookingDropDown()", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @DropDownConfigurationDAO.getGroupBookingDropDown\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public DataTable getFieldNames()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetGroupBookingDropDownFieldNames()", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @DropDownConfigurationDAO.getFieldNames\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public void saveGroupBookingDropDown(string pFieldName, string pValue)
        {
            MySqlCommand _insert = new MySqlCommand("call spInsertGroupBookingDropDown('" + pFieldName + "','" + pValue + "','" + GlobalVariables.goUser.GetType().GetProperty("UserId").GetValue(GlobalVariables.goUser,null).ToString() + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _insert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @DropDownConfigurationDAO.saveGroupBookingDropDown\r\n" + ex.Message);
            }
            finally
            {
                _insert.Dispose();
            }
        }

        public void updateGroupBookingDropDown(string pFieldName, string pValue, int pId)
        {
            MySqlCommand _update = new MySqlCommand("call spUpdateGroupBookingDropDown('" + pFieldName + "','" + pValue + "','" + pId + "','" + GlobalVariables.goUser.GetType().GetProperty("UserId").GetValue(GlobalVariables.goUser, null).ToString() + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @DropDownConfigurationDAO.updateGroupBookingDropDown\r\n" + ex.Message);
            }
            finally
            {
                _update.Dispose();
            }
        }

        public void deleteGroupBookingDropDown(int pId)
        {
            MySqlCommand _delete = new MySqlCommand("call spDeleteGroupBookingDropDown('" + pId + "','" + GlobalVariables.goUser.GetType().GetProperty("UserId").GetValue(GlobalVariables.goUser, null).ToString() + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _delete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error @DropDownConfigurationDAO.deleteGroupBookingDropDown\r\n" + ex.Message);
            }
            finally
            {
                _delete.Dispose();
            }
        }

    }
}
