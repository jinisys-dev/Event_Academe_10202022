
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
    public class OpenShiftDAO
    {

        public OpenShiftDAO()
        {
        }

        private MySqlDataAdapter dataAdapter;
        private MySqlCommand sqlCommand;

        public CashTerminal GetCashierTerminals()
        {
            try
            {
                CashTerminal oCashTerminal = new CashTerminal();

                dataAdapter = new MySqlDataAdapter("call spSelectCashTerminals('"+ GlobalVariables.gHotelId +"')", GlobalVariables.gPersistentConnection);
                dataAdapter.Fill(oCashTerminal, "CashTerminal");

                return oCashTerminal;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
                return null;
            }
        }


        public bool OpenCashDrawer(ref CashTerminal a_CashTerminal)
        {
            MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            try
            {
                // insert in CASHIER_LOGS table
                sqlCommand = new MySqlCommand("call spInsertCashier_Logs('" + GlobalVariables.gAuditDate + "','OPEN','" + a_CashTerminal.TerminalId + "','" + a_CashTerminal.CashierId + "','" + a_CashTerminal.ShiftCode + "','" + a_CashTerminal.OpeningBalance + "','" + a_CashTerminal.OpeningAdjustment + "','" + a_CashTerminal.BeginningBalance + "','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "','" + a_CashTerminal.Remarks + "')", GlobalVariables.gPersistentConnection);
                sqlCommand.ExecuteNonQuery();

                // update Cashiers Table
                sqlCommand = new MySqlCommand("call spUpdateCashier('" + a_CashTerminal.TerminalId + "','" + a_CashTerminal.CashierId + "','" + a_CashTerminal.ShiftCode + "','" + a_CashTerminal.OpeningBalance + "','" + a_CashTerminal.OpeningAdjustment + "','" + a_CashTerminal.BeginningBalance + "','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','OPEN','" + GlobalVariables.gHotelId + "','" + GlobalVariables.gLoggedOnUser + "','" + a_CashTerminal.Remarks + "','" + GlobalVariables.gAuditDate + "')", GlobalVariables.gPersistentConnection);
                sqlCommand.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (MySqlException )
            {
                MessageBox.Show("Shift already closed this day.\r\nPlease choose a different shift", "Invalid Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trans.Rollback();
                return false;
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