using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Cashier.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.Cashier
{
	namespace BusinessLayer
	{
		public class CallChargesFacade : IDisposable
		{
			
			
			
			private MySqlConnection localConnection;
			public CallChargesFacade()
			{
				localConnection = GlobalVariables.gCallAcctgConnection;
			}
			
			private Jinisys.Hotel.Cashier.DataAccessLayer.CallChargesDAO CallChargesDAO = new Jinisys.Hotel.Cashier.DataAccessLayer.CallChargesDAO();
			public CallCharge GetCallCharges()
			{
				CallChargesDAO = new Jinisys.Hotel.Cashier.DataAccessLayer.CallChargesDAO(localConnection);
				return CallChargesDAO.GetCallCharges();
			}
			
			private CallCharge oCallCharge;
			public void InsertCallCharges()
			{
				oCallCharge = new CallCharge();
				oCallCharge = this.GetCallCharges();
				
				CallChargesDAO = new Jinisys.Hotel.Cashier.DataAccessLayer.CallChargesDAO(GlobalVariables.gPersistentConnection);
				CallChargesDAO.InsertCallCharges(oCallCharge);
			}
			
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
			
		}
	}
}
