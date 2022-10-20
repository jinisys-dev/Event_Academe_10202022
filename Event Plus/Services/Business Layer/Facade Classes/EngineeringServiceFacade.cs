using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Services.DataAccessLayer;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.Services.BusinessLayer
{
	
		public class EngineeringServiceFacade
		{

            private EngineeringServiceDAO oEngineeringServiceDAO ;
			public EngineeringServiceFacade()
			{
                oEngineeringServiceDAO = new EngineeringServiceDAO();
			}
		    
			public EngineeringService getEngineeringServices()
			{
				oEngineeringServiceDAO = new EngineeringServiceDAO();
				return oEngineeringServiceDAO.getEngineeringServices();
			}
			
			public int deteleEngineeringService(ref EngineeringService oEngineeringService)
			{
                 int rowsAffected = 0;
				 oEngineeringServiceDAO = new EngineeringServiceDAO();
                 rowsAffected = oEngineeringServiceDAO.deleteEngineeringService(oEngineeringService);
                 return rowsAffected;
			}
			
			public int insertEngineeringService(ref EngineeringService oEngineeringService)
			{
                int rowsAffected = 0;
				oEngineeringServiceDAO = new EngineeringServiceDAO();
				rowsAffected = oEngineeringServiceDAO.insertEngineeringService(oEngineeringService);
                return rowsAffected;
			}
			
			public int updateEngineeringService(ref EngineeringService oEngineeringService)
			{
                int rowsAffected = 0;
				oEngineeringServiceDAO = new EngineeringServiceDAO();
				rowsAffected = oEngineeringServiceDAO.updateEngineeringService(oEngineeringService);
                return rowsAffected;
			}
		}
	}

