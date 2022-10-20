
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.Configuration.DataAccessLayer;

namespace Jinisys.Hotel.Configuration.BusinessLayer
{
    public class RateTypeFacade
    {

        private RateTypeDAO oRateTypeDAO;

        public RateTypeFacade()
        {
        }


        public object loadObject()
        {
            oRateTypeDAO = new RateTypeDAO();
            return oRateTypeDAO.loadObject();
        }

        public ArrayList getRateType()
        {
            oRateTypeDAO = new RateTypeDAO();
            return oRateTypeDAO.getRateType();
        }

        public double getRateTypeAmount(string a_RateTypeCode, string a_RoomtypeCode)
        {
            oRateTypeDAO = new RateTypeDAO();
            return oRateTypeDAO.getRateTypeAmount(a_RateTypeCode, a_RoomtypeCode);
        }

        public int insertObject(ref RateType a_RateType)
        {
            int rowsAffected = 0;

            oRateTypeDAO = new RateTypeDAO();
            rowsAffected = oRateTypeDAO.insertObject(ref a_RateType);

            return rowsAffected;
        }

        public int updateObject(ref RateType a_RateType)
        {
            int rowsAffected = 0;
            oRateTypeDAO = new RateTypeDAO();
            rowsAffected = oRateTypeDAO.updateObject(ref a_RateType);
            return rowsAffected;

        }

        public int deleteObject(ref RateType a_RateType)
        {
            oRateTypeDAO = new RateTypeDAO();
            return oRateTypeDAO.deleteObject(a_RateType);
        }

    }
}