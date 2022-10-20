using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using System.Data;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
	public class EventOrder
	{

		public EventOrder()
		{
		}
        public  void saveEventOrderView(string pFolioID, string pHotelID ,string pUserID)
        {
                EventOrderDAO _eventOrder = new EventOrderDAO();
                _eventOrder.saveEventOrderView(pFolioID, pHotelID, pUserID);
        }
        public DataTable getEventOrderView(string pFolioID, string pHotelID)
        {
            EventOrderDAO _eventOrder = new EventOrderDAO();
            return _eventOrder.getEventOrderView(pFolioID, pHotelID);
        }

		

	}
}
