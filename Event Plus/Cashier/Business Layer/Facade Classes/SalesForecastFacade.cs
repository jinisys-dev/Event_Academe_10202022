using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Cashier.DataAccessLayer;
using System.Data;

namespace Jinisys.Hotel.Cashier.BusinessLayer
{
    class SalesForecastFacade
    {
        SalesForecastDAO salesForecastDAO;
        public DataTable getSalesForecast(string pFromDate, string pToDate)
        {
            salesForecastDAO = new SalesForecastDAO();
            return salesForecastDAO.getSalesForecast(pFromDate, pToDate);
        }

        // this is for the cityledger
        public DataTable getCityLedgerSummary()
        {
            salesForecastDAO = new SalesForecastDAO();
            return salesForecastDAO.getCityLedgerSummary();
        }

        public bool insertCityLedgerPayment(string a_Accountid, string a_Date, string a_RefNo, double a_Debit, double a_Credit)
        {
            salesForecastDAO = new SalesForecastDAO();
            return salesForecastDAO.insertCityLedgerPayment(a_Accountid, a_Date, a_RefNo, a_Debit, a_Credit);
        }


        // this is for FOLIO HISTORY of company GUESTS
        public DataTable getCompanyGuests(string a_CompanyId)
        {
            salesForecastDAO = new SalesForecastDAO();
            return salesForecastDAO.getCompanyGuests(a_CompanyId);
        }

    }
}
