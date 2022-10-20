using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Configuration.DataAccessLayer;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.Configuration.BusinessLayer
{
	
		public class FloorFacade 
		{
		
			public FloorFacade(){}
		    private FloorDAO oFloorDAO;
		
            public Floor getFloors()
			{
                oFloorDAO = new FloorDAO();
				return oFloorDAO.getFloors();
			}
			
			public string getFloorLayoutImage(string a_hotelId, string a_floor)
			{
                oFloorDAO = new FloorDAO();
				return oFloorDAO.getFloorLayoutImage(a_hotelId, a_floor);
			}
			
			public int insertFloor(ref Floor a_Floor)
			{
                int rowsAffected = 0;
                oFloorDAO = new FloorDAO();
				rowsAffected=oFloorDAO.insertFloor(a_Floor);
                return rowsAffected;
			}
			
			public void updateFloorLayoutImage(ref Floor a_Floor)
			{
                oFloorDAO = new FloorDAO();
				oFloorDAO.updateFloorLayoutImage(a_Floor);
			}
			
			public int deleteFloor(ref Floor a_Floor)
			{
                int rowsAffected = 0;
                oFloorDAO = new FloorDAO();
				rowsAffected=oFloorDAO.deleteFloor(a_Floor);
                return rowsAffected;
			}
			
		
		}
	
}
