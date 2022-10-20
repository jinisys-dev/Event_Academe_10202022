
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Cashier.BusinessLayer;

namespace Jinisys.Hotel.Cashier.DataAccessLayer
{
    public class CloseShiftDAO
    {

        public CloseShiftDAO()
        {
        }

        private MySqlCommand sqlCommand;
        
        public bool CloseCashDrawer(ref CashTerminal a_CashTerminal)
        {
            MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            try
            {
                // insert in CASHIER_LOGS table
                sqlCommand = new MySqlCommand("call spInsertCashier_Logs('" + GlobalVariables.gAuditDate + "','CLOSE','" + a_CashTerminal.TerminalId + "','" + a_CashTerminal.CashierId + "','" + a_CashTerminal.ShiftCode + "','" + a_CashTerminal.OpeningBalance + "','" + a_CashTerminal.OpeningAdjustment + "','" + a_CashTerminal.BeginningBalance + "','" + a_CashTerminal.ChargeInAmount + "','" + a_CashTerminal.Cash + "','" + a_CashTerminal.CreditCard + "','" + a_CashTerminal.Cheque + "','" + a_CashTerminal.Others + "','" + a_CashTerminal.Adjustment + "','" + a_CashTerminal.AmountRemitted + "','" + a_CashTerminal.NetAmount + "','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "','" + a_CashTerminal.Remarks +"')", GlobalVariables.gPersistentConnection);
                sqlCommand.ExecuteNonQuery();

                // update Cashiers Table
                sqlCommand = new MySqlCommand("call spUpdateCashier('" + a_CashTerminal.TerminalId + "','" + a_CashTerminal.CashierId + "','" + a_CashTerminal.ShiftCode + "','" + (a_CashTerminal.NetAmount - a_CashTerminal.AmountRemitted) + "','0.00','" + (a_CashTerminal.NetAmount - a_CashTerminal.AmountRemitted) + "','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','CLOSE','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "','" + a_CashTerminal.Remarks + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
                sqlCommand.ExecuteNonQuery();

                trans.Commit();
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trans.Rollback();
                return false;
            }
        }
    }
}