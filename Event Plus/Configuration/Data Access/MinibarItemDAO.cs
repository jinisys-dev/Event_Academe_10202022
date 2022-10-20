using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    public class MinibarItemDAO
    {
        public MinibarItem getItems()
        {

			MinibarItem item = new MinibarItem("items");

			string _sqlStr = "call spHK_SelectMinibarItems()";

            MySqlDataAdapter daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);

            daSelect.Fill(item);

            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = item.Columns["itemCode"];
            item.PrimaryKey = primaryKey;

            return item;
        }

        public DataRow getItem(string pItemId)
        {

            DataTable tempTable = new DataTable("items");

            string _sqlStr = "call spHK_SelectMinibarItemPerCode(" 
                                                + pItemId + ")";


            MySqlDataAdapter daSelect = new MySqlDataAdapter(_sqlStr, GlobalVariables.gPersistentConnection);
            daSelect.Fill(tempTable);

            if (tempTable.Rows.Count > 0)
            {
                return tempTable.Rows[0];
            }
            else
            {
                return null;
            }
           
        }


        public bool Save(ref MinibarItem poItem)
        {
            try
            {
                
                string sqlInsert = "call spHK_InsertMinibarItem(" 
										 + poItem.ItemCode + ",'" 
										 + poItem.Description + "'," 
										 + poItem.UnitPrice + "," 
										 + poItem.CategoryId + ",'" 
										 + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, GlobalVariables.gPersistentConnection);
                if (cmdInsert.ExecuteNonQuery() > 0)
                {
                    DataRow row = poItem.NewRow();
                   
                        row["itemCode"] = poItem.ItemCode;
                        row["description"] = poItem.Description;
                        row["categoryId"] = poItem.CategoryId;
                        row["unitPrice"] = poItem.UnitPrice;
                        poItem.Rows.Add(row);
                        poItem.AcceptChanges();
                        return true;
                   
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        public bool Delete(ref MinibarItem item)
        {
            try
            {
                
                string sqlInsert = "call spHK_DeleteMinibarItem(" 
										 + item.ItemCode + ",'" 
										 + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, GlobalVariables.gPersistentConnection);
                if (cmdInsert.ExecuteNonQuery() > 0)
                {
                    DataRow row = item.Rows.Find(item.ItemCode);
                    if (row != null)
                    {
                        item.Rows.Remove(row);
                        item.AcceptChanges();
                        return true;
                    }
                    
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ref MinibarItem item)
        {
            try
            {
                string sqlUpdate = "call spHK_UpdateMinibarItem(" 
										 + item.ItemCode + ",'" 
										 + item.Description + "'," 
										 + item.UnitPrice + "," 
										 + item.CategoryId + ",'" 
										 + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, GlobalVariables.gPersistentConnection);
                if (cmdUpdate.ExecuteNonQuery() > 0)
                {
                   DataRow row = item.Rows.Find(item.ItemCode);
                   if (row != null)
                   {
                       row["itemCode"] = item.ItemCode;
                       row["description"] = item.Description;
                       row["categoryId"] = item.CategoryId;
                       row["unitPrice"] = item.UnitPrice;
                       item.AcceptChanges();
                       return true;
                   }
                    
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public decimal getItemPrice(String item_code)
		{
			try
			{
				MySqlCommand cmd = new MySqlCommand("select fHK_GetUnitPrice(" + item_code + ")", GlobalVariables.gPersistentConnection);

				return decimal.Parse(cmd.ExecuteScalar().ToString());
			}
			catch (Exception)
			{
				return 0;
			}


		}


    }
   
}
