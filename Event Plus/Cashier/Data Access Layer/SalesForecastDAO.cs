using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;
namespace Jinisys.Hotel.Cashier.DataAccessLayer
{
    class SalesForecastDAO
    {
        public DataTable getSalesForecast(string pFromDate, string pToDate)
        {
            DataTable dTable = new DataTable();
            try
            {
                string sql = "call spGetSalesForecast('" + pFromDate + "','" + pToDate + "',"+ GlobalVariables.gHotelId +")";
                MySqlDataAdapter dAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
               dAdapter.Fill(dTable);
               return dTable;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("EXCEPTION getSalesForecast():" + ex.Message);
                return null;
            }
        }



        // this is for the cityledger
        public DataTable getCityLedgerSummary()
        {
            DataTable dTable = new DataTable();
            try
            {
                string sql = "call spReportCityLedgerSummary()";
                MySqlDataAdapter dAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                dAdapter.Fill(dTable);
                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION getCityLedgerSummary():" + ex.Message);
                return null;
            }
        }
        public bool insertCityLedgerPayment(string a_Accountid, string a_Date, string a_RefNo, double a_Debit, double a_Credit)
        {
            try
            {
                string sql = "call spInsertCityLedgerPayment('" + a_Accountid + "','" + a_RefNo + "','" + a_Debit + "','" + a_Credit + "','','','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "')";
                MySqlCommand command = new MySqlCommand(sql, GlobalVariables.gPersistentConnection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION insertCityLedgerPayment():" + ex.Message);
                return false;
            }
        }



        // company GUEsts
        public DataTable getCompanyGuests(string a_CompanyId)
        {
            DataTable dTable = new DataTable();
            try
            {
                string sql = "call spGetCompanyGuests('"+ a_CompanyId +"','" + GlobalVariables.gHotelId + "')";
                MySqlDataAdapter dAdapter = new MySqlDataAdapter(sql, GlobalVariables.gPersistentConnection);
                dAdapter.Fill(dTable);
                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION getCompanyGuests():" + ex.Message);
                return null;
            }
        }
    }

    
}
