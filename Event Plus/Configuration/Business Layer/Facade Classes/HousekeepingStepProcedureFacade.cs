
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;



namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{

    public class HousekeepingStepProcedureFacade
    {
        private HousekeepingStepProcedureDAO oStepProcedureDAO;
        public HousekeepingStepProcedureFacade()
        {

        }

		public HousekeepingStepProcedure getStepProcedure()
        {
            oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            return oStepProcedureDAO.getStepProcedure();
        }
        public DataTable getAfterStepProcedures()
        {
			oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            return oStepProcedureDAO.getAfterStepProcedures();
         
        }
        public DataTable getMiniBarSalesStepProcedures()
        {
			oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            return oStepProcedureDAO.getMiniBarSalesStepProcedures();
         
        }
        
        public DataTable getVerifyStepProcedures()
        {
			oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            return oStepProcedureDAO.getVerifyStepProcedures();
         
        }
        
        public DataTable getBeforeStepProcedures()
        {
			oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            return oStepProcedureDAO.getBeforeStepProcedures();

        }
		public int deleteStepProcedure(ref HousekeepingStepProcedure oStepProcedure)
        {
            int rowsAffected = 0;
			oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            rowsAffected = oStepProcedureDAO.deleteStepProcedure(oStepProcedure);
            return rowsAffected;
        }
		public int insertStepProcedure(HousekeepingStepProcedure oStepProcedure)
        {
            int rowsAffected = 0;
			oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            rowsAffected = oStepProcedureDAO.insertStepProcedure(oStepProcedure);
            return rowsAffected;
        }

		public int updateStepProcedure(ref HousekeepingStepProcedure oStepProcedure)
        {
            int rowsAffected = 0;
			oStepProcedureDAO = new HousekeepingStepProcedureDAO();
            rowsAffected = oStepProcedureDAO.updateStepProcedure(oStepProcedure);
            return rowsAffected;
        }
    }
}

