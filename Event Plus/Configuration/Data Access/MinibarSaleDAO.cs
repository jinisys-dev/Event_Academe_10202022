using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.DataAccessLayer
{
    //class MinibarSaleDAO
    //{

    //    public bool Save(MinibarSale sale)
    //    {
    //        MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
    //        try
    //        {
    //            String sqlInsert = "call spInsertSales('" + sale.HouseKeeper_ID + "','" + sale.Room_Id + "'," + sale.Amount + "," + sale.Total_Qty + ")";
    //            MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, GlobalVariables.gPersistentConnection);
    //            cmdInsert.Transaction = trans;
    //            sale.Id =int.Parse(cmdInsert.ExecuteScalar().ToString());
    //            for (int i = 0; i < sale.Details.Count; i++)
    //            {
    //                String sqlInsertDet = "call spInsertSales_Detail(" + sale.Id + "," + sale.Details[i].Item_Code + "," + sale.Details[i].Qty + ")";
    //                MySqlCommand cmdInsertDet = new MySqlCommand(sqlInsertDet, GlobalVariables.gPersistentConnection);
    //                cmdInsertDet.Transaction = trans;
    //                cmdInsertDet.ExecuteNonQuery();
    //            }
    //            trans.Commit();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            trans.Rollback();
    //            throw ex;
    //        }

    //    }

    //    public bool checkPinCode(String pincode)
    //    {
    //        try
    //        {
    //            string sql = "call spHK_CheckHousekeeperPinCode('" 
    //                               + pincode + "')";

    //            MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
    //            string hkID = cmd.ExecuteScalar().ToString();

    //            return true;
    //        }
    //        catch (Exception)
    //        {
    //            return false;
    //        }
            

    //    }

    //    public bool voidSaleDetail (int transId)
    //    {
    //        try
    //        {
    //            string sql = "call spHK_VoidMinibarSaleDetail(" 
    //                               + transId + ",'" 
    //                               + GlobalVariables.gLoggedOnUser + "')";

    //            MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
    //            int affctd = cmd.ExecuteNonQuery();

    //            if (affctd > 0)
    //                return true;
    //            else
    //                return false;
    //        }
    //        catch (Exception ex)
    //        {
    //           throw ex ;
    //        }
    //    }

    //    public bool voidSales(int salesID)
    //    {
    //        try
    //        {
    //            string sql = "call spHK_VoidMinibarSales(" 
    //                               + salesID + ",'" 
    //                               + GlobalVariables.gLoggedOnUser + "')";

    //            MySqlCommand cmd = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
    //            int affctd = cmd.ExecuteNonQuery();
    //            if (affctd > 0)
    //                return true;
    //            else
    //                return false;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    public DataSet getSales(DateTime fr, DateTime t)
    //    {
    //        DataSet ds = new DataSet("Sales");
    //        try
    //        {

    //            String from = String.Format("{0:yyyy-MM-dd}", fr);
    //            String to = String.Format("{0:yyyy-MM-dd}", t);
    //            //---for housekeepers-------------------------
    //            DataTable dtHouseK = new DataTable("Housekeepers");
    //            string sqlSelectHK = "call spHK_GetHouseKeepersWithSales('" + from + "','" + to + "')";
    //            MySqlCommand cmdHK = new MySqlCommand(sqlSelectHK, GlobalVariables.gPersistentConnection);
    //            MySqlDataAdapter daHk = new MySqlDataAdapter(cmdHK);
    //            daHk.Fill(dtHouseK);
    //            //set primary key
    //            DataColumn[] pri = new DataColumn[1];
    //            pri[0] = dtHouseK.Columns[0];
    //            dtHouseK.PrimaryKey = pri;
    //            //----------------------------------
    //            //add to dataset
    //            ds.Tables.Add(dtHouseK);

    //            DataTable dtSales = new DataTable("Sales");
    //            String sqlSelectSales = "call spHK_GetMinibarSalesInRange('" + from + "','" + to + "')";
    //            MySqlCommand cmdSales = new MySqlCommand(sqlSelectSales, GlobalVariables.gPersistentConnection);
    //            MySqlDataAdapter daSales = new MySqlDataAdapter(cmdSales);
    //            daSales.Fill(dtSales);
    //            //set primary key
    //            DataColumn[] priSales = new DataColumn[1];
    //            priSales[0] = dtSales.Columns[0];
    //            dtSales.PrimaryKey = priSales;
    //            //----------------------------------
    //            //add to dataset
    //            ds.Tables.Add(dtSales);
    //            DataTable dtSalesDetails = new DataTable("SalesDetails");
    //            String sqlSelectSalesDetails = "call spHK_GetMinibarSalesDetailsInRange('" + from + "','" + to + "')";
    //            MySqlCommand cmdSalesDetails = new MySqlCommand(sqlSelectSalesDetails, GlobalVariables.gPersistentConnection);
    //            MySqlDataAdapter daSalesSetails = new MySqlDataAdapter(cmdSalesDetails);
    //            daSalesSetails.Fill(dtSalesDetails);
    //            //set primary key
    //            DataColumn[] priSalesDet = new DataColumn[1];
    //            priSalesDet[0] = dtSalesDetails.Columns[0];
    //            dtSalesDetails.PrimaryKey = priSalesDet;
    //            //----------------------------------
    //            //add to dataset
    //            ds.Tables.Add(dtSalesDetails);

    //            //set relation
    //            DataColumn parent = dtSales.Columns[0];
    //            DataColumn child = dtSalesDetails.Columns["Sales No."];
    //            DataRelation HK_Sales = new DataRelation("Hk_Sales", dtHouseK.Columns["housekeeperid"], dtSales.Columns["Housekeeper"]);
    //            DataRelation Sales_SalesDet = new DataRelation("Sales_SalesDet", parent, child);
    //            ds.Relations.AddRange(new DataRelation[] { HK_Sales, Sales_SalesDet });

    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        return ds;
    //    }

    //}
}
