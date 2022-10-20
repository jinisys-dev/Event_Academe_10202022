
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.Cashier.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Cashier.BusinessLayer
{
    public class CloseShiftFacade
    {
        public CloseShiftFacade()
        { 
        }

        private CloseShiftDAO oCloseShiftDAO;

        public bool CloseCashDrawer(ref CashTerminal a_CashTerminal)
        {
            oCloseShiftDAO = new CloseShiftDAO();
            return oCloseShiftDAO.CloseCashDrawer(ref a_CashTerminal);
        }

    }
}