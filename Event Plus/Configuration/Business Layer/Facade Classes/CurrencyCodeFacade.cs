using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using System.Windows.Forms;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
		public class CurrencyCodeFacade
		{
			
			
			public CurrencyCodeFacade()
			{
			}
			
			private CurrencyCodeDAO oCurrencyCodeDAO;

            public object loadObject()
			{
                oCurrencyCodeDAO = new CurrencyCodeDAO();
				return oCurrencyCodeDAO.loadObject();
			}

			public int insertObject(ref CurrencyCode oCurrencyCode)
			{
                int rowsAffected = 0;

                oCurrencyCodeDAO = new CurrencyCodeDAO();
                rowsAffected = oCurrencyCodeDAO.insertObject(ref oCurrencyCode) ;

                return rowsAffected;
             }
            
			public int updateObject(ref CurrencyCode oCurrencyCode)
			{
                int rowsAffected = 0;
                oCurrencyCodeDAO = new CurrencyCodeDAO();
                rowsAffected=oCurrencyCodeDAO.updateObject(ref oCurrencyCode);
                return rowsAffected;

			}
			public int deleteObject(CurrencyCode oCurrencyCode)
			{
                oCurrencyCodeDAO = new CurrencyCodeDAO();
				return oCurrencyCodeDAO.deleteObject(oCurrencyCode);
			}
    }
}
