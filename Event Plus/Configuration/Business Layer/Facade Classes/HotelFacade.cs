using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using MySql.Data.MySqlClient;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
		public class HotelFacade
		{
		
			private HotelDAO oHotelDAO;
			public HotelFacade()
			{

			}
		    public int insertObject(HotelClass a_Hotel)
            {
                int rowsAffected = 0;
                oHotelDAO = new HotelDAO();
                rowsAffected = oHotelDAO.insertObject(a_Hotel);
                return rowsAffected;
            }

            public int updateObject(ref HotelClass a_Hotel)
            {
                int rowsAffected = 0;
                oHotelDAO = new HotelDAO();
                rowsAffected = oHotelDAO.updateObject(a_Hotel);
                return rowsAffected;
            }

            public int deleteObject(HotelClass a_Hotel)
            {
                int rowsAffected = 0;
                oHotelDAO = new HotelDAO();
                rowsAffected= oHotelDAO.deleteObject(a_Hotel);
                return rowsAffected;
            }

            public object loadObject()
            {
                oHotelDAO = new HotelDAO();
                return oHotelDAO.loadObject();
            }
		
		}
	
}
