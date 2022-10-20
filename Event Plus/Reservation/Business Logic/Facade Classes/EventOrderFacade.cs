using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;


using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

//added Apr. 25, 2008
namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class EventOrderFacade
    {
        public EventOrderFacade()
        { }

    
        public  void saveEventOrderView(string pFolioID, string pUserID, string pHotelID)
        {
                EventOrder _eventOrder = new EventOrder();
                _eventOrder.saveEventOrderView(pFolioID, pHotelID, pUserID);
        }
        public DataTable getEventOrderView(string pFolioID, string pHotelID)
        {
            EventOrder _eventOrder = new EventOrder();
            return _eventOrder.getEventOrderView(pFolioID, pHotelID);
        }
    }
}
