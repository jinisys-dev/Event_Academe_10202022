
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

    public class RoomTypeDAO
    {
        
        private RoomType oRoomType;

        public RoomTypeDAO()
        {
        }

        public RoomType getRoomTypes()
        {
            try
            {
                oRoomType = new RoomType();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRoomtypes(\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(oRoomType, "RoomTypes");
                dataAdapter.Dispose();

                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = oRoomType.Tables["RoomTypes"].Columns["RoomTypeCode"];
                oRoomType.Tables["RoomTypes"].PrimaryKey = primaryKey;

                return oRoomType;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION" + ex.Message);
                return null;
            }

        }

        //public ArrayList getRoomTypesList()
        //{
        //    try
        //    {
        //        DataTable dtTable = new DataTable();

        //        MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRoomtypes(\'" + GlobalVariables.gHotelId + "\')", localConnection);
        //        dataAdapter.Fill(dtTable);
        //        dataAdapter.Dispose();

        //        ArrayList roomTypeList = new ArrayList();
        //        int i;
        //        for (i = 0; i <= dtTable.Rows.Count - 1; i++)
        //        {
        //            roomTypeList.Add(dtTable.Rows[i][0]);
        //        }

        //        return roomTypeList;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("EXCEPTION" + ex.Message);
        //        return null;
        //    }

        //}

        //public bool insertRoomType(RoomType oRoomType)
        //{
        //    try
        //    {
                
        //        DataTable dtTable = new DataTable();
        //        MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spInsertRoomType(\'" + a_RoomType.RoomTypeCode + "\',\'" + a_RoomType.MaxOccupants + "\',\'" + a_RoomType.NoOfBeds + "\',\'" + a_RoomType.NoofAdult + "\',\'" + a_RoomType.NoofChild + "\',\'" + a_RoomType.ShareType + "\',\'" + a_RoomType.HotelID + "\',\'" + a_RoomType.CreatedBy + "\')", localConnection);

        //        dataAdapter.Fill(dtTable);
        //        dataAdapter.Dispose();
        //        dtTable.Dispose();

        //        DataRow DataRow = a_RoomType.Tables["RoomTypes"].NewRow();

        //        DataRow["RoomTypeCode"] = a_RoomType.RoomTypeCode;
        //        DataRow["MaxOccupants"] = a_RoomType.MaxOccupants;
        //        DataRow["NoOfBeds"] = a_RoomType.NoOfBeds;
        //        DataRow["NoofAdult"] = a_RoomType.NoofAdult;
        //        DataRow["NoofChild"] = a_RoomType.NoofChild;
        //        DataRow["ShareType"] = a_RoomType.ShareType;

        //        a_RoomType.Tables["RoomTypes"].Rows.Add(DataRow);
        //        a_RoomType.Tables["RoomTypes"].AcceptChanges();

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("SAVE ROOMTYPE... EXCEPTION");
        //        return false;
        //    }

        //}

        //public ArrayList retrieveRoomTypes()
        //{
        //    ArrayList roomTypeCollection = new ArrayList();

        //    DataTable dtTable = new DataTable();
        //    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRoomTypes(\'" + GlobalVariables.gHotelId + "\')", localConnection);
        //    dataAdapter.Fill(dtTable);
        //    dataAdapter.Dispose();

        //    int i;
        //    for (i = 0; i <= dtTable.Rows.Count - 1; i++)
        //    {
        //        roomTypeCollection.Add(dtTable.Rows[i]["RoomTypeCode"]);
        //    }

        //    return roomTypeCollection;
        //}

        //public bool deleteRoomType(RoomType oRoomType)
        //{
        //    try
        //    {
        //        RoomType a_RoomType = oRoomType;
        //        DataTable dtTable = new DataTable();
        //        MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spDeleteRoomType(\'" + a_RoomType.RoomTypeCode + "\',\'" + a_RoomType.UpdatedBy + "\',\'" + a_RoomType.HotelID + "\')", localConnection);

        //        dataAdapter.Fill(dtTable);
        //        dataAdapter.Dispose();
        //        dtTable.Dispose();

        //        object primaryKeyVal = new object();
        //        primaryKeyVal = a_RoomType.RoomTypeCode;
        //        DataRow row = a_RoomType.Tables["RoomTypes"].Rows.Find(primaryKeyVal);
        //        a_RoomType.Tables["RoomTypes"].Rows.Remove(row);
        //        a_RoomType.AcceptChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("EXCEPTION: " + ex.Message);
        //        return false;
        //    }
        //}

        //public bool updateRoomType(Jinisys.Hotel.ConfigurationHotel.BusinessLayer.RoomType oRoomType)
        //{
        //    try
        //    {
        //        Jinisys.Hotel.ConfigurationHotel.BusinessLayer.RoomType a_RoomType = oRoomType;
        //        DataTable dtTable = new DataTable();

        //        MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spUpdateroomType(\'" + a_RoomType.RoomTypeCode + "\',\'" + a_RoomType.MaxOccupants + "\',\'" + a_RoomType.NoOfBeds + "\',\'" + a_RoomType.NoofAdult + "\',\'" + a_RoomType.NoofChild + "\',\'" + a_RoomType.ShareType + "\',\'" + a_RoomType.HotelID + "\',\'" + a_RoomType.UpdatedBy + "\')", localConnection);

        //        dataAdapter.Fill(dtTable);
        //        dataAdapter.Dispose();
        //        dtTable.Dispose();

        //        DataRow D = a_RoomType.Tables["RoomTypes"].Rows.Find(a_RoomType.RoomTypeCode);
        //        D.BeginEdit();
        //        D["RoomTypeCode"] = a_RoomType.RoomTypeCode;
        //        D["MaxOccupants"] = a_RoomType.MaxOccupants;
        //        D["NoOfBeds"] = a_RoomType.NoOfBeds;
        //        D["NoofAdult"] = a_RoomType.NoofAdult;
        //        D["NoofChild"] = a_RoomType.NoofChild;
        //        D["ShareType"] = a_RoomType.ShareType;
        //        D.EndEdit();
        //        D.AcceptChanges();
        //        a_RoomType.Tables["RoomTypes"].AcceptChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("EXCEPTION: " + ex.Message);
        //        return false;
        //    }

        //}


        public string getRoomType(string a_RoomId)
        {
            try
            {
                MySqlCommand getRoomTypeCommand = new MySqlCommand("call spGetRoomType('" + a_RoomId + "')", GlobalVariables.gPersistentConnection );
                string roomType = getRoomTypeCommand.ExecuteScalar().ToString();

                return roomType;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Retrieve Rows Exception");
                return "";
            }
        }

        public object loadObject()
        {
            try
            {
                oRoomType = new RoomType();
                MySqlDataAdapter selectCommand = new MySqlDataAdapter("call spSelectRoomtypes('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );

                selectCommand.Fill(oRoomType, "RoomTypes");
                selectCommand.Dispose();

                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = oRoomType.Tables["RoomTypes"].Columns["RoomTypeCode"];
                oRoomType.Tables["RoomTypes"].PrimaryKey = primaryKey;

                return oRoomType;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public int insertObject(ref RoomType a_RoomType)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand insertCommand = new MySqlCommand("call spInsertRoomType('" + a_RoomType.RoomTypeCode + "','" + a_RoomType.MaxOccupants + "','" + a_RoomType.NoOfBeds + "','" + a_RoomType.NoofAdult + "','" + a_RoomType.NoofChild + "','" + a_RoomType.ShareType + "','" + a_RoomType.HotelID + "','" + a_RoomType.CreatedBy + "','" + a_RoomType.RoomSuperType + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    insertDataRow(ref a_RoomType);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");

                return 0;
            }
        }

        public int updateObject(ref RoomType a_RoomType)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spUpdateroomType('" + a_RoomType.RoomTypeCode + "','" + a_RoomType.MaxOccupants + "','" + a_RoomType.NoOfBeds + "','" + a_RoomType.NoofAdult + "','" + a_RoomType.NoofChild + "','" + a_RoomType.ShareType + "','" + a_RoomType.HotelID + "','" + a_RoomType.UpdatedBy + "','" + a_RoomType.RoomSuperType + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    updateDataRow(ref a_RoomType);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public int deleteObject(ref RoomType a_RoomType)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spDeleteRoomType('" + a_RoomType.RoomTypeCode + "','" + a_RoomType.UpdatedBy + "','" + a_RoomType.HotelID + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    deleteDataRow(ref a_RoomType);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public void insertDataRow(ref RoomType a_RoomType)
        {
            try
            {
                DataRow dataRow = a_RoomType.Tables["RoomTypes"].NewRow();

                dataRow["RoomTypeCode"] = a_RoomType.RoomTypeCode;
                dataRow["MaxOccupants"] = a_RoomType.MaxOccupants;
                dataRow["NoOfBeds"] = a_RoomType.NoOfBeds;
                dataRow["NoofAdult"] = a_RoomType.NoofAdult;
                dataRow["NoofChild"] = a_RoomType.NoofChild;
                dataRow["ShareType"] = a_RoomType.ShareType;

                /* FP-SCR-00139 #2 [07.20.2010]
                 * add additional field to get room's super type */
                dataRow["RoomSuperType"] = a_RoomType.RoomSuperType;

                a_RoomType.Tables["RoomTypes"].Rows.Add(dataRow);
                a_RoomType.Tables["RoomTypes"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Data Row Exception");
            }
        }

        public void updateDataRow(ref RoomType a_RoomType)
        {
            try
            {
                DataRow dataRow = a_RoomType.Tables["RoomTypes"].Rows.Find(a_RoomType.RoomTypeCode);
                dataRow.BeginEdit();
                dataRow["RoomTypeCode"] = a_RoomType.RoomTypeCode;
                dataRow["MaxOccupants"] = a_RoomType.MaxOccupants;
                dataRow["NoOfBeds"] = a_RoomType.NoOfBeds;
                dataRow["NoofAdult"] = a_RoomType.NoofAdult;
                dataRow["NoofChild"] = a_RoomType.NoofChild;
                dataRow["ShareType"] = a_RoomType.ShareType;

                /* FP-SCR-00139 #2 [07.20.2010]
                 * add additional field to get room's super type */
                dataRow["RoomSuperType"] = a_RoomType.RoomSuperType;

                dataRow.EndEdit();
                dataRow.AcceptChanges();
                a_RoomType.Tables["RoomTypes"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Row Exception");
            }
        }

        public void deleteDataRow(ref RoomType a_RoomType)
        {
            try
            {
                DataRow row = a_RoomType.Tables["RoomTypes"].Rows.Find( a_RoomType.RoomTypeCode );
                a_RoomType.Tables["RoomTypes"].Rows.Remove(row);
                a_RoomType.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Data Row Exception");
            }
        }
    }
}