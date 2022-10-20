

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class RateCodeDAO
    {

        private RateCode oRateCode;

        public RateCodeDAO()
        {
        }

        public decimal getRoomRate(string a_RoomId)
        {
            object obj;
            decimal roomRate = 0;

            MySqlCommand getRoomRate = new MySqlCommand( "call spGetRoomRate('"+ a_RoomId +"','"+ GlobalVariables.gHotelId +"')", GlobalVariables.gPersistentConnection );

            obj = getRoomRate.ExecuteScalar();
            if (obj != null)
            {
                if (decimal.TryParse(obj.ToString(), out roomRate))
                {
                    return roomRate;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        } 

        public object loadObject()
        {
            try
            {
                oRateCode = new RateCode();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRateCodes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );
                dataAdapter.Fill(oRateCode, "RateCodes");

                dataAdapter.Dispose();
                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = oRateCode.Tables["RateCodes"].Columns["ratecode"];
                oRateCode.Tables["RateCodes"].PrimaryKey = primaryKey;

                return oRateCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public DataTable getRateCodes()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spSelectRateCodes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @RateCodeDAO.getRateCode\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

        public int insertObject(ref RateCode a_RateCode)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand insertCommand = new MySqlCommand("call spInsertRateCode('" + a_RateCode.RateCodeName + "','" + a_RateCode.Description + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    insertDataRow(ref a_RateCode);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");

                return 0;
            }
        }

        public int updateObject(ref RateCode a_RateCode)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand( "call spUpdateRateCode('" + a_RateCode.RateCodeName + "','" + a_RateCode.Description + "','" + GlobalVariables.gLoggedOnUser + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );

                rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    updateDataRow(ref a_RateCode);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public int deleteObject(ref RateCode a_RateCode)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand( "call spDeleteRateCode('" + a_RateCode.RateCodeName + "','" + a_RateCode.HotelID + "','" + a_RateCode.UpdatedBy + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    deleteDataRow(ref a_RateCode );
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public void insertDataRow(ref RateCode a_RateCode)
        {
            try
            {
                DataRow DataRow = a_RateCode.Tables[0].NewRow();
                DataRow["RateCode"] = a_RateCode.RateCodeName;
                DataRow["Description"] = a_RateCode.Description;

                a_RateCode.Tables["RateCodes"].Rows.Add(DataRow);
                a_RateCode.Tables["RateCodes"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Data Row Exception");
            }
        }

        public void updateDataRow(ref RateCode a_RateCode)
        {
            try
            {
                DataRow dataRow = a_RateCode.Tables[0].Rows.Find(a_RateCode.RateCodeName);
                dataRow.BeginEdit();
                dataRow["Description"] = a_RateCode.Description;
                dataRow.EndEdit();

                dataRow.AcceptChanges();
                a_RateCode.Tables[0].AcceptChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Row Exception");
            }
        }

        public void deleteDataRow(ref RateCode a_RateCode)
        {
            try
            {
                DataRow dataRow = a_RateCode.Tables[0].Rows.Find(a_RateCode.RateCodeName);
                a_RateCode.Tables[0].Rows.Remove(dataRow);
                a_RateCode.AcceptChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Data Row Exception");
            }
        }
    }
}