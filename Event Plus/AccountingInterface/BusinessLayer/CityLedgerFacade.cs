using System;
using System.Collections.Generic;
using System.Text;

using Jinisys.Hotel.AccountingInterface.DataAccessLayer;
using System.Data;

namespace Jinisys.Hotel.AccountingInterface.BusinessLayer
{
    public class CityLedgerFacade
    {

        public CityLedgerFacade()
        { }

        CityLedgerDAO loCityLedgerDAO = null;
        public bool insertCityLedger(CityLeger poCityLedger)
        {
            loCityLedgerDAO = new CityLedgerDAO();
            return loCityLedgerDAO.insertCityLedger( poCityLedger );
        }

        
        public bool insertCityLedgerPayment(string pAccountid, 
											string pDate, 
											string pRefNo, 
											string pMemo,
											double pAmountPaid, 
											double pWithHoldingTax, 
											double pDebit, 
											double pCredit)
        {
            loCityLedgerDAO = new CityLedgerDAO();
            return loCityLedgerDAO.insertCityLedgerPayment(pAccountid, 
														  pDate, 
														  pRefNo,
														  pMemo,
														  pAmountPaid, 
														  pWithHoldingTax, 
														  pDebit, 
														  pCredit);
        }


        public DataTable getCityLedgerAccounts()
        {
            loCityLedgerDAO = new CityLedgerDAO();
            return loCityLedgerDAO.getCityLedgerAccounts();
        }


        public bool closeAccount(string pAccountId)
        {
            loCityLedgerDAO = new CityLedgerDAO();
            return loCityLedgerDAO.closeAccount(pAccountId);
        }

        public DataSet populateCityLedgerDataset()
        {
            loCityLedgerDAO = new CityLedgerDAO();
            return loCityLedgerDAO.populateCityLedgerDataset();
        }
    }
}
