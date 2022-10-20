using System.Diagnostics;
using System;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
		public class FloorDAO 
		{
            Floor oFloor; 
            private DataReaderToDatasetConverter DatasetConverter;

			public FloorDAO()
			{
                DatasetConverter = new DataReaderToDatasetConverter();
                oFloor = new Floor();
			}
			
			public Floor getFloors()
			{
				oFloor = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.Floor();
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spGetFloors()", GlobalVariables.gPersistentConnection);
				
				dataAdapter.Fill(oFloor, "Floors");
				
				DataColumn[] primaryKey = new DataColumn[1];
				primaryKey[0] = oFloor.Tables["Floors"].Columns["Floor"];
				oFloor.Tables["Floors"].PrimaryKey = primaryKey;
				
				return oFloor;
			}
			
			public string getFloorLayoutImage(string hotelid, string a_Floor)
			{
				try
				{
					DataTable dtTable = new DataTable();

					string _sqlStr = "call spGetFloorLayoutImage('" + 
						                   hotelid + "','" + 
										   a_Floor + "')";

					MySqlCommand selectCommand = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

					object objRS = selectCommand.ExecuteScalar();

					return objRS.ToString();
					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error loading floor layout image.\r\nError message : " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return null;
				}
			}
			
			public void updateFloorLayoutImage(Jinisys.Hotel.ConfigurationHotel.BusinessLayer.Floor oFloor)
			{
				try
				{
					DataTable dtTable = new DataTable();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spUpdateFloorLayoutImage('" + oFloor.FloorLayoutImage.Replace(@"\", @"\\") + "','" + oFloor.FloorName + "','" + oFloor.HotelID + "','" + oFloor.UpdatedBy + "')", GlobalVariables.gPersistentConnection);
					
					dataAdapter.Fill(dtTable);
					dataAdapter.Dispose();
					dtTable.Dispose();
					
					object primaryKey;
					primaryKey = oFloor.FloorName;
					
					DataRow dataRow = oFloor.Tables[0].Rows.Find(primaryKey);
					
					dataRow.BeginEdit();
                    dataRow["FloorLayoutImage"] = oFloor.FloorLayoutImage;
					dataRow.EndEdit();
					dataRow.AcceptChanges();
					oFloor.AcceptChanges();
				}
				catch (Exception ex)
				{
					MessageBox.Show("EXCEPTION:" + ex.Message);
				}
			}
			
			public int insertFloor(Jinisys.Hotel.ConfigurationHotel.BusinessLayer.Floor a_Floor)
			{
				try
				{
					
                    int rowsAffected = 0;
                    MySqlCommand insertCommand = new MySqlCommand("call spInsertFloor('" + a_Floor.HotelID + "','" + a_Floor.FloorName + "','" + Strings.Replace(a_Floor.FloorLayoutImage, "\\", "\\\\", 1, -1, 0) + "','" + GlobalVariables.gLoggedOnUser + "')", GlobalVariables.gPersistentConnection);
                    rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        insertDataRow(a_Floor);
                    }
                    return rowsAffected;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
                    return 0;
				}
				
			}
			
			public int deleteFloor(Jinisys.Hotel.ConfigurationHotel.BusinessLayer.Floor a_Floor)
			{
				try
				{
                   int rowsAffected = 0;
					MySqlCommand deleteCommand = new MySqlCommand("call spdeleteFloor('" + a_Floor.FloorName + "','" + a_Floor.HotelID + "','" + a_Floor.UpdatedBy + "')", GlobalVariables.gPersistentConnection);
                    rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected;
				}
				catch (Exception ex)
				{
                    MessageBox.Show("EXCEPTION: " + ex.Message);
                    return 0;
				}
				
			}

            private void insertDataRow(Floor a_Floor)
            {
                DataRow datarow = a_Floor.Tables["Floors"].NewRow();
                datarow["gHotelId"] = a_Floor.HotelID;
                datarow["Floor"] = a_Floor.FloorName;
                datarow["FloorLayoutImage"] = a_Floor.FloorLayoutImage;

                a_Floor.Tables["Floors"].Rows.Add(datarow);
                a_Floor.Tables["Floors"].AcceptChanges();
            }

            private void deleteDataRow(Floor a_Floor)
            {
                object primaryKey;
                primaryKey = a_Floor.FloorName;
                DataRow dataRow = a_Floor.Tables["Floors"].Rows.Find(primaryKey);

                a_Floor.Tables["Floors"].Rows.Remove(dataRow);
                a_Floor.AcceptChanges();
            }

			
		}
	
}
