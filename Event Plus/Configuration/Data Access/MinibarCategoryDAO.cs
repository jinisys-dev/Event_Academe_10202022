using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    class MinibarItemCategoryDAO
    {

		public MinibarItemCategory getCategories()
        {
			MinibarItemCategory cat = new MinibarItemCategory("categories");
			MySqlDataAdapter dataAdapter = new MySqlDataAdapter("call spHK_SelectMinibarCategories()", GlobalVariables.gPersistentConnection);

            dataAdapter.Fill(cat);

            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = cat.Columns["CategoryID"];
            cat.PrimaryKey = primaryKey;

            return cat;
        }

        public bool Save(ref MinibarItemCategory poCategory)
        {
            try
            {
                
				string _sqlStr = "call spHK_InsertMinibarCategory('" 
									   + poCategory.CategoryName + "','" 
									   + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmdInsert = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

                if (cmdInsert.ExecuteNonQuery() > 0)
                {
					DataRow row = poCategory.NewRow();
					row["CategoryID"] = poCategory.CategoryID;
					row["CategoryName"] = poCategory.CategoryName;
					poCategory.Rows.Add(row);
					poCategory.AcceptChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ref MinibarItemCategory poCategory)
        {
            try
            {

				string _sqlStr = "call spHK_UpdateMinibarItemCategory(" 
									   + poCategory.CategoryID + ",'" 
									   + poCategory.CategoryName + "','" 
									   + GlobalVariables.gLoggedOnUser + "')";

				MySqlCommand cmdUpdate = new MySqlCommand(_sqlStr, GlobalVariables.gPersistentConnection);

                if (cmdUpdate.ExecuteNonQuery() > 0)
                {
                    DataRow row = poCategory.Rows.Find(poCategory.CategoryID);
                    if (row != null)
                    {
                        row["CategoryID"] = poCategory.CategoryID;
                        row["CategoryName"] = poCategory.CategoryName;
                        
                        poCategory.AcceptChanges();
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

        public bool Delete(ref MinibarItemCategory poCategory)
        {
            try
            {
				string sqlDelete = "call spHK_DeleteMinibarItemCategory(" 
									+ poCategory.CategoryID + ",'" 
									+ GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmdInsert = new MySqlCommand(sqlDelete, GlobalVariables.gPersistentConnection);
                if (cmdInsert.ExecuteNonQuery() > 0)
                {
                    DataRow row = poCategory.Rows.Find(poCategory.CategoryID);
                    if (row != null)
                    {
                        poCategory.Rows.Remove(row);
                        poCategory.AcceptChanges();
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

    }
}
