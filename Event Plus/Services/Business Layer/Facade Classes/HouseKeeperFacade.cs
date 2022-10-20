
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Services.DataAccessLayer;



namespace Jinisys.Hotel.Services.BusinessLayer
{

		public class HouseKeeperFacade 
		{
            private HouseKeeperDAO oHouseKeeperDAO ;
			public HouseKeeperFacade()
			{
              
			}
		    
			public HouseKeeper getHouseKeeper()
			{
				oHouseKeeperDAO = new HouseKeeperDAO();
				return oHouseKeeperDAO.getHouseKeeper();
			}

            public int deleteHouseKeeper(ref HouseKeeper oHouseKeeper)
			{
                int rowsAffected = 0;
				oHouseKeeperDAO = new HouseKeeperDAO();
                rowsAffected = oHouseKeeperDAO.deleteHouseKeeper(oHouseKeeper);
                return rowsAffected;
			}
            public int insertHouseKeeper(HouseKeeper oHouseKeeper)
			{
                int rowsAffected = 0;
				oHouseKeeperDAO = new HouseKeeperDAO();
                rowsAffected = oHouseKeeperDAO.insertHouseKeeper(oHouseKeeper);
                return rowsAffected;
			}
			
			public int updateHouseKeeper(ref HouseKeeper oHouseKeeper)
			{
                int rowsAffected = 0;
				oHouseKeeperDAO = new HouseKeeperDAO();
                rowsAffected = oHouseKeeperDAO.updateHouseKeeper(oHouseKeeper);
                return rowsAffected;
			}

			public string getSupervisorFullname(string hkID, string pin)
			{
				oHouseKeeperDAO = new HouseKeeperDAO();
				return oHouseKeeperDAO.getSupervisorFullname(hkID, pin);
			}
			public string getSupervisorFullname(string hkID, string pin, MySqlConnection con)
			{
				oHouseKeeperDAO = new HouseKeeperDAO();
				return oHouseKeeperDAO.getSupervisorFullname(hkID, pin, con);
			}



	    }
	}

