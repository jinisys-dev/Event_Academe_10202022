using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.DataAccessLayer
{
    class MinibarSaleDAO
    {

        public bool Save(MinibarSale poSale, ref MySqlTransaction oDBTrans)
        {
            //MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
            {
				string sqlInsert = "call spHK_InsertMiniBarSale('" 
										 + poSale.HouseKeeper_ID + "','" 
										 + poSale.Room_Id + "'," 
										 + poSale.Amount + "," 
										 + poSale.Total_Qty + ")";

                MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, GlobalVariables.gPersistentConnection);
				cmdInsert.Transaction = oDBTrans;
                poSale.Id = int.Parse(cmdInsert.ExecuteScalar().ToString());

                for (int i = 0; i < poSale.Details.Count; i++)
                {
					string sqlInsertDet = "call spHK_InsertMinibarSales_Detail(" 
											    + poSale.Id + "," 
												+ poSale.Details[i].Item_Code + "," 
												+ poSale.Details[i].Qty + ")";

                    MySqlCommand cmdInsertDet = new MySqlCommand(sqlInsertDet, GlobalVariables.gPersistentConnection);
					cmdInsertDet.Transaction = oDBTrans;
                    cmdInsertDet.ExecuteNonQuery();
                }


                //trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                //trans.Rollback();
                throw ex;
            }

        }

        public bool checkPinCode(String pincode)
        {
            try
            {
				string sql = "call spHK_CheckHousekeeperPinCode('" 
								   + pincode + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                string hkID = cmd.ExecuteScalar().ToString();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            

        }

        public bool voidSaleDetail (int transId)
        {
            try
            {
				string sql = "call spHK_VoidMinibarSaleDetail(" 
								   + transId + ",'" 
								   + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                int affctd = cmd.ExecuteNonQuery();

                if (affctd > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
               throw ex ;
            }
        }

        public bool voidSales(int salesID)
        {
            try
            {
				string sql = "call spHK_VoidMinibarSales(" 
								   + salesID + ",'" 
								   + GlobalVariables.gLoggedOnUser + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                int affctd = cmd.ExecuteNonQuery();
                if (affctd > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getSales(DateTime fr, DateTime t)
        {
            DataSet ds = new DataSet("Sales");
            try
            {

                String from = String.Format("{0:yyyy-MM-dd}", fr);
                String to = String.Format("{0:yyyy-MM-dd}", t);
                //---for housekeepers-------------------------
                DataTable dtHouseK = new DataTable("Housekeepers");
				string sqlSelectHK = "call spHK_GetHouseKeepersWithSales('" + from + "','" + to + "')";
                MySqlCommand cmdHK = new MySqlCommand(sqlSelectHK, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter daHk = new MySqlDataAdapter(cmdHK);
                daHk.Fill(dtHouseK);
                //set primary key
                DataColumn[] pri = new DataColumn[1];
                pri[0] = dtHouseK.Columns[0];
                dtHouseK.PrimaryKey = pri;
                //----------------------------------
                //add to dataset
                ds.Tables.Add(dtHouseK);

                DataTable dtSales = new DataTable("Sales");
				String sqlSelectSales = "call spHK_GetMinibarSalesInRange('" + from + "','" + to + "')";
                MySqlCommand cmdSales = new MySqlCommand(sqlSelectSales, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter daSales = new MySqlDataAdapter(cmdSales);
                daSales.Fill(dtSales);
                //set primary key
                DataColumn[] priSales = new DataColumn[1];
                priSales[0] = dtSales.Columns[0];
                dtSales.PrimaryKey = priSales;
                //----------------------------------
                //add to dataset
                ds.Tables.Add(dtSales);
                DataTable dtSalesDetails = new DataTable("SalesDetails");
				String sqlSelectSalesDetails = "call spHK_GetMinibarSalesDetailsInRange('" + from + "','" + to + "')";
                MySqlCommand cmdSalesDetails = new MySqlCommand(sqlSelectSalesDetails, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter daSalesSetails = new MySqlDataAdapter(cmdSalesDetails);
                daSalesSetails.Fill(dtSalesDetails);
                //set primary key
                DataColumn[] priSalesDet = new DataColumn[1];
                priSalesDet[0] = dtSalesDetails.Columns[0];
                dtSalesDetails.PrimaryKey = priSalesDet;
                //----------------------------------
                //add to dataset
                ds.Tables.Add(dtSalesDetails);

                //set relation
                DataColumn parent = dtSales.Columns[0];
                DataColumn child = dtSalesDetails.Columns["Sales No."];
                DataRelation HK_Sales = new DataRelation("Hk_Sales", dtHouseK.Columns["housekeeperid"], dtSales.Columns["Housekeeper"]);
                DataRelation Sales_SalesDet = new DataRelation("Sales_SalesDet", parent, child);
                ds.Relations.AddRange(new DataRelation[] { HK_Sales, Sales_SalesDet });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


		public string getFolioIdByRoomOccupied(string pRoomNo)
		{
			try
			{
				string _strCommand = "call spGetFolioIdFromRoomEventsByRoomId('" 
										   + pRoomNo + "')";

				MySqlCommand getCommand = new MySqlCommand(_strCommand, GlobalVariables.gPersistentConnection);
				object obj = getCommand.ExecuteScalar();

				string _folioId = obj.ToString();

				return _folioId;

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

        public object getRoomEventByRoom(string pRoomID)
        {
            try
            {
                string sql = "call spHK_CheckIfRoomIsOccupied('"
                                   + pRoomID + "')";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                object obj = cmd.ExecuteScalar();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
