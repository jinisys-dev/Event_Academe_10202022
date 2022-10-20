

using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;


namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class AmenityDAO
    {

        private Amenity oAmenity;

        public AmenityDAO()
        {
        }

        public object loadObject()
        {
            try
            {
                oAmenity = new Amenity();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectAmenities('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

                dataAdapter.Fill(oAmenity, "Amenities");
                dataAdapter.Dispose();

                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = oAmenity.Tables["Amenities"].Columns["amenityid"];
                oAmenity.Tables["Amenities"].PrimaryKey = primaryKey;

                return oAmenity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public Amenity loadUnAssignedAmenities()
        {
            try
            {
                oAmenity = new Amenity();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectAmenitiesForRoom('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );

                dataAdapter.Fill(oAmenity, "Amenities");
                dataAdapter.Dispose();

                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = oAmenity.Tables["Amenities"].Columns["amenityid"];
                oAmenity.Tables["Amenities"].PrimaryKey = primaryKey;

                return oAmenity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public Amenity getRoomAmenities(string a_RoomId)
        {
            try
            {
                oAmenity = new Amenity();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( "call spSelectRoomAmenities('" + a_RoomId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection );

                dataAdapter.Fill(oAmenity, "RoomAmenities");
                dataAdapter.Dispose();

                return oAmenity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public int insertObject(ref Amenity a_Amenity)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand insertCommand = new MySqlCommand( "call spInsertAmenity('" + a_Amenity.AmenityId + "','" + a_Amenity.Name + "','" + a_Amenity.Description + "','" + a_Amenity.HotelID + "','" + a_Amenity.CreatedBy + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    insertDataRow(ref a_Amenity);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction faield.\r\nError message :" + ex.Message, "Folio Pus", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }
        }

        public int insertRoomAmenity(string a_AmenityId, string a_RoomId)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand insertCommand = new MySqlCommand("call spInsertRoomAmenity('" + a_RoomId + "','" + a_AmenityId + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = insertCommand.ExecuteNonQuery();


                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Insert Exception");
                return 0;
            }

        }

        public int updateObject(ref Amenity a_Amenity)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spUpdateAmenity('" + a_Amenity.AmenityId + "','" + a_Amenity.Name + "','" + a_Amenity.Description + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    updateDataRow(ref a_Amenity);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message : " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int deleteObject(ref Amenity a_Amenity)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand( "call spDeleteAmenity('" + a_Amenity.AmenityId + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection );
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    deleteDataRow(ref a_Amenity);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }
        
        public void insertDataRow(ref Amenity a_Amenity)
        {
            try
            {
                DataRow dataRow = a_Amenity.Tables[0].NewRow();
                dataRow["amenityid"] = a_Amenity.AmenityId;
                dataRow["name"] = a_Amenity.Name;
                dataRow["description"] = a_Amenity.Description;

                a_Amenity.Tables[0].Rows.Add(dataRow);
                a_Amenity.Tables[0].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Data Row Exception");
            }
        }

        public void updateDataRow(ref Amenity a_Amenity)
        {
            try
            {
                DataRow dataRow = a_Amenity.Tables["Amenities"].Rows.Find(a_Amenity.AmenityId);
                dataRow.BeginEdit();
                dataRow["name"] = a_Amenity.Name;
                dataRow["description"] = a_Amenity.Description;
                dataRow.EndEdit();
                dataRow.AcceptChanges();

                a_Amenity.Tables["Amenities"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Row Exception");
            }
        }

        public void deleteDataRow(ref Amenity a_Amenity)
        {
            try
            {
                DataRow dataRow = a_Amenity.Tables["Amenities"].Rows.Find( a_Amenity.AmenityId );
                a_Amenity.Tables["Amenities"].Rows.Remove(dataRow);
                a_Amenity.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Data Row Exception");
            }
        }

    }
}