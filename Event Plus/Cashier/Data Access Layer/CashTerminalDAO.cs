
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
    public class CashTerminalDAO
    {

        public CashTerminalDAO()
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


        
    }
}