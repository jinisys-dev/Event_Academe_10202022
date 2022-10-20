using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class RateTypeDAO
    {
        private RateType oRateType;
        public RateTypeDAO()
        {
        }

        public object loadObject()
        {
            try
            {
                oRateType = new RateType();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( "call spSelectRateTypes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );
                dataAdapter.Fill(oRateType, "RateType");
                dataAdapter.Dispose();

                DataColumn[] primaryKey = new DataColumn[3];
                primaryKey[0] = oRateType.Tables[0].Columns[0];
                primaryKey[1] = oRateType.Tables[0].Columns[1];
                primaryKey[2] = oRateType.Tables[0].Columns[2];
                oRateType.Tables[0].PrimaryKey = primaryKey;
                return oRateType;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public int insertObject(ref RateType a_RateType)
        {
			try
			{
				int rowsAffected = 0;

				string _sqlStr = "call spInsertRateType('" +
									   a_RateType.RoomTypeCode + "','" +
									   a_RateType.RateCode + "','" +
                                       a_RateType.RoomID + "','" +
									   a_RateType.RateAmount + "','" +
									   a_RateType.HasBreakfast + "'," +
									   a_RateType.BreakfastAmount + ",'" +
									   a_RateType.HotelID + "','" +
									   a_RateType.CreatedBy + "')";


				MySqlCommand insertCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

				rowsAffected = insertCommand.ExecuteNonQuery();
				if (rowsAffected > 0)
				{
					insertDataRow(ref a_RateType);
				}
				return rowsAffected;
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("Duplicate"))
				{
					MessageBox.Show("Transaction failed.\r\n\r\nSelected rate type already exists in database.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else
				{
					MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return 0;
			}
        }

        public ArrayList getRateType()
        {
            ArrayList rateTypeCollection = new ArrayList();

            MySqlCommand getRateTypeCommand = new MySqlCommand( "spGetRateTypes", GlobalVariables.gPersistentConnection );
            getRateTypeCommand.CommandType = CommandType.StoredProcedure;
            MySqlDataReader getRateTypeReader = getRateTypeCommand.ExecuteReader();
            while (getRateTypeReader.Read())
            {
                rateTypeCollection.Add(getRateTypeReader.GetValue(0).ToString());
            }
            getRateTypeReader.Close();

            return rateTypeCollection;
        }
        public String getRateType(String pRoomType)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("call spGetRateType('" + pRoomType + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                object obj = command.ExecuteScalar();
                if (obj != null)
                {
                    return obj.ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "getRateType()");
                return "";
            }

        }
        public decimal getRateTypeAmount(string a_RateTypeCode, string a_RoomTypeCode)
        {
            try
            {
                object obj;
                decimal rateAmount = 0;

                MySqlCommand getRateAmountCommand = new MySqlCommand("call spGetRateAmount('" + a_RateTypeCode + "','" + a_RoomTypeCode + "')", GlobalVariables.gPersistentConnection);
                obj = getRateAmountCommand.ExecuteScalar();

                if (obj != null)
                {
                    if (decimal.TryParse(obj.ToString(), out rateAmount))
                    {
                        return rateAmount;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return 0;
            }
        }

        public int updateObject(ref RateType a_RateType)
        {
            try
            {
                int rowsAffected = 0;
				string _sqlStr = "call spUpdateRateType('" + 
					                   a_RateType.RoomTypeCode + "','" + 
									   a_RateType.RateCode + "','" +
                                       a_RateType.RoomID + "'," +
									   a_RateType.RateAmount + ",'" +
										a_RateType.HasBreakfast + "'," +
										a_RateType.BreakfastAmount + ",'" + 
									   a_RateType.HotelID + "','" + 
									   a_RateType.UpdatedBy + "')";

                MySqlCommand updateCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    updateDataRow(ref a_RateType);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public int deleteObject(RateType a_RateType)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spDeleteRateType('" + a_RateType.RoomTypeCode + "','" + a_RateType.RateCode + "','" + a_RateType.HotelID + "','" + a_RateType.UpdatedBy + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    deleteDataRow(ref a_RateType);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public void insertDataRow(ref RateType a_RateType)
        {
            try
            {
                DataRow dRow = a_RateType.Tables[0].NewRow();
                dRow["RoomTypeCode"] = a_RateType.RoomTypeCode;
                dRow["RateCode"] = a_RateType.RateCode;
                dRow["RateAmount"] = a_RateType.RateAmount;
				dRow["HasBreakfast"] = a_RateType.HasBreakfast;
				dRow["BreakfastAmount"] = a_RateType.BreakfastAmount;
                dRow["RoomID"] = a_RateType.RoomID;
                a_RateType.Tables[0].Rows.Add(dRow);
                a_RateType.Tables[0].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Data Row Exception");
            }
        }

        public void updateDataRow(ref RateType a_RateType)
        {
            try
            {
                object[] PrimaryKeyVal = new object[3];
                PrimaryKeyVal[0] = new Object();
                PrimaryKeyVal[1] = new Object();
                PrimaryKeyVal[2] = new Object();

                PrimaryKeyVal[0] = a_RateType.RoomTypeCode;
                PrimaryKeyVal[1] = a_RateType.RateCode;
                PrimaryKeyVal[2] = a_RateType.RoomID;

                DataRow dataRow = a_RateType.Tables[0].Rows.Find(PrimaryKeyVal);
                dataRow.BeginEdit();
                dataRow["RoomTypeCode"] = a_RateType.RoomTypeCode;
                dataRow["RateCode"] = a_RateType.RateCode;
                dataRow["RateAmount"] = a_RateType.RateAmount;
				dataRow["HasBreakfast"] = a_RateType.HasBreakfast;
				dataRow["BreakfastAmount"] = a_RateType.BreakfastAmount;
                dataRow["RoomID"] = a_RateType.RoomID;
                dataRow.EndEdit();
                dataRow.AcceptChanges();
                a_RateType.Tables[0].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Row Exception");
            }
        }

        public void deleteDataRow(ref RateType a_RateType)
        {
            try
            {
                object[] primaryKeyVal = new object[2];
                primaryKeyVal[0] = new Object();
                primaryKeyVal[1] = new Object();

				primaryKeyVal[0] = a_RateType.RoomTypeCode;
				primaryKeyVal[1] = a_RateType.RateCode;


				DataRow row = a_RateType.Tables[0].Rows.Find(primaryKeyVal);
				a_RateType.Tables[0].Rows.Remove(row);
				a_RateType.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Data Row Exception");
            }
        }

        public DataTable getRateTypes()
        {
            DataTable _dt = new DataTable();
            MySqlDataAdapter _adapter = new MySqlDataAdapter("call spSelectRateTypes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
            try
            {
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error @RateTypeDAO.getRateTypes\r\n" + ex.Message);
            }
            finally
            {
                _adapter.Dispose();
            }
        }

    }
}