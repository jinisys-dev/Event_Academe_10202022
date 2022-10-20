
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;

using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using System.Collections.Generic;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
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

        public decimal getRateTypeAmount(string a_RateTypeCode, string a_RoomtypeCode)
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
        public String getRateType(String pRoomType)
        {
            oRateTypeDAO = new RateTypeDAO();
            return oRateTypeDAO.getRateType(pRoomType);
        }

		public RateType getRateType(string pRoomType, string pRateCode)
		{
			RateType oRateTypes = (RateType)this.loadObject();

			DataTable dtRates = oRateTypes.Tables[0];

			foreach (DataRow dRow in dtRates.Rows)
			{
				if (dRow["RoomTypeCode"].ToString() == pRoomType && dRow["RateCode"].ToString() == pRateCode)
				{
					RateType oRateType = new RateType();

					oRateType.RoomTypeCode = dRow["RoomTypeCode"].ToString();
					oRateType.RateCode = dRow["RateCode"].ToString();
					oRateType.RateAmount = decimal.Parse(dRow["RateAmount"].ToString());
					oRateType.HasBreakfast = dRow["HasBreakfast"].ToString();
					oRateType.BreakfastAmount = decimal.Parse(dRow["BreakfastAmount"].ToString());

					return oRateType;
				}
			}

			return null;
		}

        public DataTable getRateTypes()
        {
            oRateTypeDAO = new RateTypeDAO();
            return oRateTypeDAO.getRateTypes();     
        }

		public IList<RateType> getRateTypeList()
		{
			IList<RateType> _oRateTypeList = new List<RateType>();

			RateType _oRateType = (RateType)this.loadObject();
			DataTable _dtRateType = _oRateType.Tables[0];

			foreach (DataRow dRow in _dtRateType.Rows)
			{ 
				RateType _newRateType = new RateType();

				_newRateType.RoomTypeCode = dRow["RoomTypeCode"].ToString();
				_newRateType.RateCode = dRow["RateCode"].ToString();
				_newRateType.RateAmount = decimal.Parse( dRow["RateAmount"].ToString() );
				_newRateType.StatusFlag = dRow["StatusFlag"].ToString();
				//_newRateType.HotelID = int.Parse( dRow["HotelId"].ToString() );
				_newRateType.CreateTime = DateTime.Parse( dRow["CreateTime"].ToString() );
				_newRateType.CreatedBy = dRow["CreatedBy"].ToString();
				_newRateType.UpdateTime = DateTime.Parse( dRow["UpdateTime"].ToString() );
				_newRateType.UpdatedBy = dRow["UpdatedBy"].ToString();
				_newRateType.HasBreakfast = dRow["HasBreakfast"].ToString();
				_newRateType.BreakfastAmount = decimal.Parse( dRow["BreakfastAmount"].ToString() );

				_oRateTypeList.Add(_newRateType);
			}

			return _oRateTypeList;
		}

    }
}