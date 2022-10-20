
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Services.DataAccessLayer;



namespace Jinisys.Hotel.Services.BusinessLayer
{

		public class HousekeepingTypeFacade 
		{
            private HousekeepingTypeDAO oHousekeepingTypeDAO ;
			public HousekeepingTypeFacade()
			{
              
			}
		    
			public HousekeepingType getHousekeepingType()
			{
				oHousekeepingTypeDAO = new HousekeepingTypeDAO();
				return oHousekeepingTypeDAO.getHousekeepingType();
			}
            public DataTable getHousekeepingTypes()
            {
                oHousekeepingTypeDAO = new HousekeepingTypeDAO();
                return oHousekeepingTypeDAO.getHousekeepingTypes();
            }
            public int deleteHousekeepingType(ref HousekeepingType oHousekeepingType)
			{
                int rowsAffected = 0;
				oHousekeepingTypeDAO = new HousekeepingTypeDAO();
                rowsAffected = oHousekeepingTypeDAO.deleteHousekeepingType(oHousekeepingType);
                return rowsAffected;
			}
            public int insertHousekeepingType(HousekeepingType oHousekeepingType)
			{
                int rowsAffected = 0;
				oHousekeepingTypeDAO = new HousekeepingTypeDAO();
                rowsAffected = oHousekeepingTypeDAO.insertHousekeepingType(oHousekeepingType);
                return rowsAffected;
			}
			
			public int updateHousekeepingType(ref HousekeepingType oHousekeepingType)
			{
                int rowsAffected = 0;
				oHousekeepingTypeDAO = new HousekeepingTypeDAO();
                rowsAffected = oHousekeepingTypeDAO.updateHousekeepingType(oHousekeepingType);
                return rowsAffected;
			}
	    }
	}

