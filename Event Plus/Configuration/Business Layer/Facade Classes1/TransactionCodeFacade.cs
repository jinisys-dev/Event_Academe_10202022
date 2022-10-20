
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Configuration.DataAccessLayer;

namespace Jinisys.Hotel.Configuration.BusinessLayer
{
    public class TransactionCodeFacade
    {

        private TransactionCodeDAO oTransactionCodeDAO;

        public TransactionCodeFacade()
        {
        }

        public object loadObject()
        {
            oTransactionCodeDAO = new TransactionCodeDAO();
            return oTransactionCodeDAO.loadObject();
        }

        public int insertObject(ref TransactionCode a_TransactionCode)
        {
            int rowsAffected = 0;

            oTransactionCodeDAO = new TransactionCodeDAO();
            rowsAffected = oTransactionCodeDAO.insertObject(ref a_TransactionCode);

            return rowsAffected;
        }

        public int updateObject(ref TransactionCode a_TransactionCode)
        {
            int rowsAffected = 0;
            oTransactionCodeDAO = new TransactionCodeDAO();
            rowsAffected = oTransactionCodeDAO.updateObject(ref a_TransactionCode);
            return rowsAffected;

        }

        public int deleteObject(ref TransactionCode a_TransactionCode)
        {
            oTransactionCodeDAO = new TransactionCodeDAO();
            return oTransactionCodeDAO.deleteObject(ref a_TransactionCode);
        }

        public TransactionCode getTransactionCode(string a_TransactionCode)
        {
            oTransactionCodeDAO = new TransactionCodeDAO();
            return oTransactionCodeDAO.getTransactionCode(a_TransactionCode);
        }

        //public TransactionCode getTransactionCodes()
        //{
        //    oTransactionCodeDAO = new TransactionCodeDAO(localConnection);
        //    return oTransactionCodeDAO.getTransactionCodes();
        //}

        //public bool insertTransactionCode(ref TransactionCode oTransactionCode)
        //{
        //    oTransactionCodeDAO = new TransactionCodeDAO(localConnection);
        //    return oTransactionCodeDAO.insertTransactionCode(oTransactionCode);
        //}

        //public bool updateTransactionCode(ref TransactionCode oTransactioncode)
        //{
        //    oTransactionCodeDAO = new TransactionCodeDAO(localConnection);
        //    return oTransactionCodeDAO.updateTransactionCode(oTransactioncode);
        //}

        //public bool deleteTransactionCode(ref TransactionCode oTransactionCode)
        //{
        //    oTransactionCodeDAO = new TransactionCodeDAO(localConnection);
        //    return oTransactionCodeDAO.deleteTransactionCode(oTransactionCode);
        //}

        //public DataTable getCharges(int hotelID)
        //{
        //    oTransactionCodeDAO = new TransactionCodeDAO(localConnection);
        //    return oTransactionCodeDAO.getCharges(hotelID);
        //}

    }
}
