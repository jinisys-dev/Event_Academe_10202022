
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.Cashier.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Cashier.BusinessLayer
{
    public class CashTerminalFacade
    {
        public CashTerminalFacade()
        { 
        }

        private OpenShiftDAO oOpenShiftDAO;

        public CashTerminal GetCashierTerminals()
        {
            oOpenShiftDAO = new OpenShiftDAO();
            return oOpenShiftDAO.GetCashierTerminals();
        }

    }
}