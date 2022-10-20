
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;


using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;



namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class RateCodeFacade
    {

        private RateCodeDAO oRateCodeDAO;

        public RateCodeFacade()
        {
        }

        // >> get RateAmount of a specific Room
        public decimal getRoomRate(string a_RoomId)
        {
            oRateCodeDAO = new RateCodeDAO();
            return oRateCodeDAO.getRoomRate( a_RoomId );
        }

        // >> Get RateCodesList for RateTypes
        public ArrayList getRateCodesList()
        {
            
            RateCode oRateCode = new RateCode();
            oRateCodeDAO = new RateCodeDAO();
            oRateCode = (RateCode)oRateCodeDAO.loadObject();

            ArrayList rateCodes = new ArrayList();
            foreach (DataRow dataRow in oRateCode.Tables[0].Rows)
            {
                rateCodes.Add(dataRow[0]);
            }

            return rateCodes;
        }

        public DataTable getRateCodes()
        {
            oRateCodeDAO = new RateCodeDAO();
            return oRateCodeDAO.getRateCodes();
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public object loadObject()
        {
            oRateCodeDAO = new RateCodeDAO();
            return oRateCodeDAO.loadObject();
        }

        public int insertObject(ref RateCode a_RateCode)
        {
            int rowsAffected = 0;

            oRateCodeDAO = new RateCodeDAO();
            rowsAffected = oRateCodeDAO.insertObject(ref a_RateCode);

            return rowsAffected;
        }

        public int updateObject(ref RateCode a_RateCode)
        {
            int rowsAffected = 0;
            oRateCodeDAO = new RateCodeDAO();
            rowsAffected = oRateCodeDAO.updateObject(ref a_RateCode);
            return rowsAffected;

        }

        public int deleteObject(ref RateCode a_RateCode)
        {
            oRateCodeDAO = new RateCodeDAO();
            return oRateCodeDAO.deleteObject(ref a_RateCode);
        }


    }
}