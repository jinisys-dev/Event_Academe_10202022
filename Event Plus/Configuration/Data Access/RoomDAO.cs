

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
    public class RoomDAO
    {

        private Room oRoom;

        public RoomDAO()
        {
        }

        public ArrayList getRoomIDs()
        {
            try
            {
                ArrayList RoomIDs = new ArrayList();
                oRoom = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.Room();
                oRoom = (Room)this.loadObject();

                int i;
                for (i = 0; i <= oRoom.Tables[0].Rows.Count - 1; i++)
                {
                    RoomIDs.Add(oRoom.Tables[0].Rows[i][0]);
                }

                return RoomIDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: " + ex.Message);
                return null;
            }
            finally
            {
                oRoom.Dispose();
            }
        }

        // kani sad.. dapat naa sa FACADE
        public ArrayList getRoomsByRoomType(string a_RoomTypeCode)
        {
            try
            {
                ArrayList roomIds = new ArrayList();

                DataTable dtTable = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRoomIDByRoomType('" + a_RoomTypeCode + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

                dataAdapter.Fill(dtTable);
                dataAdapter.Dispose();

                foreach (DataRow dataRow in dtTable.Rows)
                {
                    roomIds.Add( dataRow[0] );
                }


                return roomIds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load ArrayList Exception");
                return null;
            }
        }

        /* FP-SCR-00139 #2
         * get rooms under a super type */
        public ArrayList getRoomsByRoomSuperType(string pRoomSuperType)
        {
            try
            {
                ArrayList roomIds = new ArrayList();

                DataTable dtTable = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRoomIDByRoomSuperType('" + pRoomSuperType + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);

                dataAdapter.Fill(dtTable);
                dataAdapter.Dispose();

                foreach (DataRow dataRow in dtTable.Rows)
                {
                    roomIds.Add(dataRow[0]);
                }


                return roomIds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load ArrayList Exception");
                return null;
            }
        }

        public int updateRoomCoordinates(string a_RoomId, int a_XCoordinate, int a_YCoordinate)
        {
            int rowsAffected = 0;

            try
            {
                MySqlCommand updateCommand = new MySqlCommand("call spUpdateRoomCoordinates('" + a_RoomId + "','" + a_XCoordinate + "','" + a_YCoordinate + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

                updateCommand.Dispose();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public int deleteRoomAmenity(string a_RoomId, string a_AmenityId)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand updateCommand = new MySqlCommand("call spDeleteRoomAmenity('" + a_AmenityId + "','" + a_RoomId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

                updateCommand.Dispose();
               
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Database Update Exception");
                return 0;
            }
        }


		public int deleteRoomAmenities(string a_RoomId)
		{
			try
			{
				int rowsAffected = 0;

				MySqlCommand deleteCommand = new MySqlCommand("call spDeleteRoomAmenities('" + a_RoomId + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				rowsAffected = deleteCommand.ExecuteNonQuery();

				deleteCommand.Dispose();

				return rowsAffected;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Delete Room Amenities Exception");
				return 0;
			}
		}


        public int addRoomAmenity(string a_RoomId, string a_AmenityId)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand insertCommand = new MySqlCommand("call spAddRoomAmenity('" + a_RoomId + "','" + a_AmenityId + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = insertCommand.ExecuteNonQuery();

                insertCommand.Dispose();

                return rowsAffected;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Database Update Exception");
                return 0;
            }
        }

        public int setRoomStatus(string a_RoomID, string a_StateFlag, ref MySqlTransaction _oDBTrans)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand setStatusCommand = new MySqlCommand("call spSetRoomStateFlag(\'" + a_RoomID + "\',\'" + a_StateFlag + "\',\'" + GlobalVariables.gLoggedOnUser + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
				setStatusCommand.Transaction = _oDBTrans;

                rowsAffected = setStatusCommand.ExecuteNonQuery();

				
                setStatusCommand.Dispose();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message,"Database Update Exception");
                //return 0;
                throw ex;
            }
        }

        public Room getRoom(string a_RoomId)
        {
            try
            {
                oRoom = new Room();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetRoom('" + a_RoomId + "'," + GlobalVariables.gHotelId + ")", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(oRoom, "Room");
                dataAdapter.Dispose();

                oRoom.RoomId = (oRoom.Tables[0].Rows[0]["Roomid"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["Roomid"].ToString());
                oRoom.HotelID = (oRoom.Tables[0].Rows[0]["hotelid"].ToString() == null) ? 0 : ((int)oRoom.Tables[0].Rows[0]["hotelid"]);
                oRoom.RoomTypecode = (oRoom.Tables[0].Rows[0]["RoomTypecode"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["RoomTypecode"].ToString());
                oRoom.Floor = (oRoom.Tables[0].Rows[0]["Floor"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["Floor"].ToString());
                oRoom.Windows = (oRoom.Tables[0].Rows[0]["Windows"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["Windows"].ToString());
                oRoom.DirFacing = (oRoom.Tables[0].Rows[0]["DirFacing"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["DirFacing"].ToString());
                oRoom.AdjLeft = (oRoom.Tables[0].Rows[0]["AdjLeft"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["AdjLeft"].ToString());
                oRoom.AdjRight = (oRoom.Tables[0].Rows[0]["AdjRight"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["AdjRight"].ToString());
                oRoom.RoomImage = (oRoom.Tables[0].Rows[0]["RoomImage"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["RoomImage"].ToString());
                oRoom.Stateflag = (oRoom.Tables[0].Rows[0]["Stateflag"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["Stateflag"].ToString());
                oRoom.SmokingType = (oRoom.Tables[0].Rows[0]["SmokingType"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["SmokingType"].ToString());
                oRoom.BedSplittable = (oRoom.Tables[0].Rows[0]["bedsplittable"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["bedsplittable"].ToString());
                oRoom.CleaningStatus = (oRoom.Tables[0].Rows[0]["cleaningstatus"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["cleaningstatus"].ToString());
                oRoom.RoomArea = (oRoom.Tables[0].Rows[0]["roomArea"].ToString() == null) ? 0 : (decimal.Parse(oRoom.Tables[0].Rows[0]["roomArea"].ToString()));
                /* ******************************************
                 * FP-SCR-00139 #1 [07.20.2010]             *
                 * additional field for description of room *
                 * ******************************************/
                oRoom.RoomDescription = (oRoom.Tables[0].Rows[0]["RoomDescription"].ToString() == null) ? "" : (oRoom.Tables[0].Rows[0]["RoomDescription"].ToString());

                return oRoom;
            }
            catch (Exception)
            {
                //MsgBox("EXCEPTION: " & ex.Message)
                return null;
            }
            
        }

		public int setRoomCleaningStatus(string a_RoomId, string a_CleaningStatus,ref MySqlTransaction _oDBTrans)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand updateCommand = new MySqlCommand("call spSetRoomCleaningStatus('" + a_RoomId + "','" + a_CleaningStatus + "','" + GlobalVariables.gLoggedOnUser + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
				updateCommand.Transaction = _oDBTrans;
                rowsAffected = updateCommand.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message,"Database Update Exception");
                //return 0;
                throw ex;
            }
        }

        
        public object loadObject()
        {
            try
            {
                oRoom = new Room();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spSelectRooms('" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(oRoom, "Rooms");
                dataAdapter.Dispose();

                DataColumn[] primaryKey = new DataColumn[1];
                primaryKey[0] = oRoom.Tables["Rooms"].Columns["RoomId"];
                oRoom.Tables["Rooms"].PrimaryKey = primaryKey;

                return oRoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieve Rows Exception");
                return null;
            }
        }

        public int insertObject(ref Room a_Room)
        {
            try
            {
                //added to avoid duplication of room id
                MySqlCommand _command = new MySqlCommand("delete from rooms where roomId = '" + a_Room.RoomId + "'", GlobalVariables.gPersistentConnection);
                _command.ExecuteNonQuery();


                int rowsAffected = 0;
                MySqlCommand insertCommand = new MySqlCommand("call spInsertRoom('" + a_Room.RoomId + "','" + a_Room.HotelID + "','" + a_Room.RoomTypecode + "','" + a_Room.Floor + "','" + a_Room.Windows + "','" + a_Room.DirFacing + "','" + a_Room.AdjLeft + "','" + a_Room.AdjRight + "','" + a_Room.RoomImage.Replace(@"\", @"\\") + "','" + a_Room.SmokingType + "','" + a_Room.TelephoneNo + "','" + a_Room.BedSplittable + "','" + a_Room.CreatedBy + "','" + a_Room.RoomDescription + "','" + a_Room.RoomArea + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = insertCommand.ExecuteNonQuery();

                foreach ( Amenity mAmenity in a_Room.Amenities )
                {
                    this.addRoomAmenity(a_Room.RoomId, mAmenity.AmenityId);
                }


                if (rowsAffected > 0)
                {
                    insertDataRow(ref a_Room);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");

                return 0;
            }
        }

        public int updateObject(ref Room a_Room)
        {
            try
            {
                int rowsAffected = 0;

                MySqlCommand updateCommand = new MySqlCommand("call spUpdateRoom('" + a_Room.RoomId + "','" + a_Room.HotelID + "','" + a_Room.RoomTypecode + "','" + a_Room.Floor + "','" + a_Room.Windows + "','" + a_Room.DirFacing + "','" + a_Room.AdjLeft + "','" + a_Room.AdjRight + "','" + a_Room.RoomImage.Replace(@"\", @"\\") + "','" + a_Room.SmokingType + "','" + a_Room.TelephoneNo + "','" + a_Room.BedSplittable + "','" + a_Room.UpdatedBy + "','" + a_Room.RoomDescription + "','" + a_Room.RoomArea + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

				this.deleteRoomAmenities(a_Room.RoomId);
				foreach (Amenity mAmenity in a_Room.Amenities)
				{
					this.addRoomAmenity(a_Room.RoomId, mAmenity.AmenityId);
				}
				

                if (rowsAffected > 0)
                {
                    updateDataRow(ref a_Room);
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public int deleteObject(ref Room a_Room)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spDeleteRoom('" + a_Room.RoomId + "','" + GlobalVariables.gLoggedOnUser + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    deleteDataRow(ref a_Room);
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Update Exception");
                return 0;
            }
        }

        public void insertDataRow(ref Room a_Room)
        {
            try
            {
                DataRow dataRow = a_Room.Tables["Rooms"].NewRow();

                dataRow["HotelID"] = a_Room.HotelID;
                dataRow["RoomId"] = a_Room.RoomId;
                dataRow["RoomTypecode"] = a_Room.RoomTypecode;
                dataRow["MaxOccupants"] = a_Room.MaxOccupants;
                dataRow["NoOfBeds"] = a_Room.NoOfBeds;
                dataRow["NoOfAdult"] = a_Room.NoOfAdult;
                dataRow["Floor"] = a_Room.Floor;
                dataRow["DirFacing"] = a_Room.DirFacing;
                dataRow["AdjLeft"] = a_Room.AdjLeft;
                dataRow["AdjRight"] = a_Room.AdjRight;
                dataRow["RoomImage"] = a_Room.RoomImage;
                dataRow["TelephoneNo"] = a_Room.TelephoneNo;
                dataRow["BedSplittable"] = a_Room.BedSplittable;
                dataRow["roomArea"] = a_Room.RoomArea;
                /* ***************************************** *
                 * FP-SCR-00139 #1 [07.20.2010]              *
                 * additional field for description of room  *
                 * ***************************************** */
                dataRow["RoomDescription"] = a_Room.RoomDescription;

                a_Room.Tables["Rooms"].Rows.Add(dataRow);
                a_Room.Tables["Rooms"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Data Row Exception");
            }
        }

        public void updateDataRow(ref Room a_Room)
        {
            try
            {
                DataRow dataRow = a_Room.Tables["Rooms"].Rows.Find( a_Room.RoomId );

                dataRow.BeginEdit();
                dataRow["HotelId"] = a_Room.HotelID;
                dataRow["RoomTypeCode"] = a_Room.RoomTypecode;
                dataRow["MaxOccupants"] = a_Room.MaxOccupants;
                dataRow["NoOfBeds"] = a_Room.NoOfBeds;
                dataRow["NoOfAdult"] = a_Room.NoOfAdult;
                dataRow["NoOfChild"] = a_Room.NoOfChild;
                dataRow["Floor"] = a_Room.Floor;
                dataRow["DirFacing"] = a_Room.DirFacing;
                dataRow["AdjLeft"] = a_Room.AdjLeft;
                dataRow["AdjRight"] = a_Room.AdjRight;
                dataRow["RoomImage"] = a_Room.RoomImage;
                dataRow["TelephoneNo"] = a_Room.TelephoneNo;
                dataRow["BedSplittable"] = a_Room.BedSplittable;
                dataRow["roomArea"] = a_Room.RoomArea;
                /* ******************************************
                 * FP-SCR-00139 #1 [07.20.2010]             *
                 * additional field for description of room *
                 * ******************************************/
                dataRow["RoomDescription"] = a_Room.RoomDescription;

                dataRow.EndEdit();
                dataRow.AcceptChanges();
                a_Room.Tables["Rooms"].AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Row Exception");
            }
        }

        public void deleteDataRow(ref Room a_Room)
        {
            try
            {
                DataRow dataRow = a_Room.Tables["Rooms"].Rows.Find(a_Room.RoomId);
                a_Room.Tables["Rooms"].Rows.Remove(dataRow);
                a_Room.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Data Row Exception");
            }
        }

        //Kevin Oliveros
        public bool insertRoomCombination(string pRoomID, string pRoomCombID ,string pRoomCombDescription)
        {
            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spInsertRoomComb('" + pRoomID + "','" + pRoomCombID + "','" + pRoomCombDescription + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                 
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Inse Exception");
            
            }
            return false;
        }
        public DataTable getAllRoomComb(string pRoomID)
        {
            DataTable _dtResult = new DataTable();
            try
            {

                MySqlDataAdapter _command = new MySqlDataAdapter("call spGetRoomComb('" + pRoomID + "','" + GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                _command.Fill(_dtResult);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database GET Exception (spGetRoomComb)");
                return null;
            }
            return _dtResult;
        }
        public bool deleteRoomComb(string pRoomID)
        {

            try
            {
                int rowsAffected = 0;
                MySqlCommand updateCommand = new MySqlCommand("call spDeleteRoomComb('" +pRoomID + "','"+ GlobalVariables.gHotelId + "')", GlobalVariables.gPersistentConnection);
                rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Inse Exception");
               
            }
            return false;
        }
    }
}
