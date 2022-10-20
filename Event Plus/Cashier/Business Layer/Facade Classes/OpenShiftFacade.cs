
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.Cashier.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Cashier.BusinessLayer
{
    public class OpenShiftFacade
    {
        public OpenShiftFacade()
        { 
        }

        private OpenShiftDAO oOpenShiftDAO;

        public CashTerminal GetCashierTerminals()
        {
            oOpenShiftDAO = new OpenShiftDAO();
            return oOpenShiftDAO.GetCashierTerminals();
        }

        public bool OpenCashDrawer(ref CashTerminal a_CashTerminal)
        {
            oOpenShiftDAO = new OpenShiftDAO();
            return oOpenShiftDAO.OpenCashDrawer(ref a_CashTerminal);
        }

    }
}