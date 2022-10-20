using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Services.DataAccessLayer;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.Services.BusinessLayer
{
        public class EngineeringJobFacade 
		{
            private EngineeringJobDAO oEngineeringJobDAO ;

			public EngineeringJobFacade()
			{
                oEngineeringJobDAO = new EngineeringJobDAO();
			}
		    
			public EngineeringJob getEngineeringJob()
			{
				oEngineeringJobDAO = new Jinisys.Hotel.Services.DataAccessLayer.EngineeringJobDAO();
				return oEngineeringJobDAO.getEngineeringJobs();
			}
			
			public int insertEngineeringJob(ref EngineeringJob oEngineeringJob)
			{
                int rowsAffected = 0;
				oEngineeringJobDAO = new Jinisys.Hotel.Services.DataAccessLayer.EngineeringJobDAO();
				rowsAffected=oEngineeringJobDAO.insertEngineeringJob(oEngineeringJob);
                
                return rowsAffected;
			}
			
			public int deleteEngineeringJob(ref EngineeringJob oEngineeringJob)
			{
				oEngineeringJobDAO = new Jinisys.Hotel.Services.DataAccessLayer.EngineeringJobDAO();
				return oEngineeringJobDAO.deleteEngineeringJob(oEngineeringJob);
			}
			
			public int updateEngineeringJob(ref EngineeringJob a_EngineeringJob)
			{
                int rowsAffected = 0;
				oEngineeringJobDAO = new Jinisys.Hotel.Services.DataAccessLayer.EngineeringJobDAO();
                rowsAffected=oEngineeringJobDAO.updateEngineeringJob(a_EngineeringJob);
                if (rowsAffected > 0)
				{
					oEngineeringJobDAO.deleteEngineeringJobRoomEvent(a_EngineeringJob.EnggJobNo);
                    return rowsAffected;
				}
				else
				{
					return 0;
				}
				
				
			}

            public DataTable getEngineeringJob(string Id)
            {
                oEngineeringJobDAO = new EngineeringJobDAO();
                return oEngineeringJobDAO.getEngineeringJob(Id);
            }
        }
	
}
