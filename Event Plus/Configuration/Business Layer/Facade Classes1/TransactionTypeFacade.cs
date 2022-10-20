using System;
using System.Data;
using System.Collections;
using System.Diagnostics;

using Jinisys.Hotel.Configuration.DataAccessLayer;

namespace Jinisys.Hotel.Configuration.BusinessLayer
{
    public class TransactionTypeFacade
    {
     
        public TransactionTypeFacade()
        {
        }

        private TransactionTypeDAO oTransactionTypeDAO;

        public object loadObject()
        {
            oTransactionTypeDAO = new TransactionTypeDAO();
            return oTransactionTypeDAO.loadObject();
        }

        public int insertObject(ref TransactionType a_TransactionType)
        {
            int rowsAffected = 0;

            oTransactionTypeDAO = new TransactionTypeDAO();
            rowsAffected = oTransactionTypeDAO.insertObject(ref a_TransactionType);

            return rowsAffected;
        }

        public int updateObject(ref TransactionType a_TransactionType)
        {
            int rowsAffected = 0;
            oTransactionTypeDAO = new TransactionTypeDAO();
            rowsAffected = oTransactionTypeDAO.updateObject(ref a_TransactionType);

            return rowsAffected;
        }

        public int deleteObject(ref TransactionType a_TransactionType)
        {
            oTransactionTypeDAO = new TransactionTypeDAO();
            return oTransactionTypeDAO.deleteObject(ref a_TransactionType);
        }

    }
}