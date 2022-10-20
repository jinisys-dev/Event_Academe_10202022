using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Services.DataAccessLayer;
using System.Data;

namespace Jinisys.Hotel.Services.BusinessLayer
{
   
    class HouseKeepingLogFacade
    {
        HouseKeepingLogDAO oHouseKeepingLogDAO=null;

        public DataTable GetHouseKeepingLogs(string status,string date)
        {
            oHouseKeepingLogDAO = new HouseKeepingLogDAO();
            return oHouseKeepingLogDAO.GetHouseKeepingLogs(status, date);
        }
        public DataTable GetHouseKeepers()
        {
            oHouseKeepingLogDAO = new HouseKeepingLogDAO();
            return oHouseKeepingLogDAO.GetHouseKeepers();
        }
        public bool UpdateHouseKeepingLog(string roomId, string status, string hk_id, string sTime, string eTime, string duration)
        {
            oHouseKeepingLogDAO = new HouseKeepingLogDAO();
            return oHouseKeepingLogDAO.UpdateHouseKeepingLog( roomId,  status,  hk_id,  sTime,  eTime,  duration);
        }

		public DataTable GetHouseKeepingLogs(string date)
		{
			oHouseKeepingLogDAO = new HouseKeepingLogDAO();
			return oHouseKeepingLogDAO.GetHouseKeepingLogs(date);
		}
    }
}
