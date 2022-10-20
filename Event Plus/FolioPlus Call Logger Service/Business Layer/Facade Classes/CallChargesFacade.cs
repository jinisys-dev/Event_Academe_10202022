
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Collections;

using MySql.Data.MySqlClient;

using Jinisys.FolioPlusCallLogger.DataAccessLayer;


namespace Jinisys.FolioPlusCallLogger.BusinessLayer
{
    public class CallChargesFacade : IDisposable
    {

        private static MySqlConnection localConnection;
        public CallChargesFacade(MySqlConnection connection)
        {
            localConnection = connection;

            Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gHotelId = 1;
            Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gLoggedOnUser = "ADMIN";
        }

        private CallChargesDAO CallChargesDAO = new CallChargesDAO();
        public CallCharge GetCallCharges()
        {
            CallChargesDAO = new CallChargesDAO(localConnection);
            return CallChargesDAO.GetCallCharges();
        }

        private CallCharge oCallCharge;
        public void InsertCallCharges()
        {
            oCallCharge = new CallCharge();
            oCallCharge = this.GetCallCharges();

            CallChargesDAO = new CallChargesDAO(localConnection);
            CallChargesDAO.InsertCallCharges(oCallCharge);

        }

        #region "iDisposable"
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //localconnection = Nothing
            }
            // Free your own state (unmanaged objects).
            // Set large fields to null.
        }

        ~CallChargesFacade()
        {
            // Simply call Dispose(False).
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}