
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.BusinessLayer
{
    public class TransactionCodeFacade
    {

        private TransactionCodeDAO oTransactionCodeDAO;

        public TransactionCodeFacade()
        {
        }

        public TransactionCode loadObject()
        {
            oTransactionCodeDAO = new TransactionCodeDAO();
            return (TransactionCode)oTransactionCodeDAO.loadObject();
        }

        public DataTable getTransactionCodes()
        {
            oTransactionCodeDAO = new TransactionCodeDAO();
            return oTransactionCodeDAO.getTransactionCodes();
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


		public IList<TransactionCode> getTransactionCodeList()
		{
			TransactionCode _tempTransactionCode = (TransactionCode)this.loadObject();

			DataTable _tempDataTable = _tempTransactionCode.Tables[0];

			IList<TransactionCode> _oTransactionCodeList = new List<TransactionCode>();

			foreach (DataRow _dRow in _tempDataTable.Rows)
			{
				TransactionCode _oTransactionCode = new TransactionCode();
				_oTransactionCode.TranCode = _dRow["TranCode"].ToString();
				_oTransactionCode.TranTypeId = _dRow["TranTypeId"].ToString();
				_oTransactionCode.Memo = _dRow["Memo"].ToString();
				_oTransactionCode.AcctSide = _dRow["AcctSide"].ToString();
				_oTransactionCode.ServiceCharge = decimal.Parse(_dRow["ServiceCharge"].ToString());
				_oTransactionCode.ServiceChargeInclusive = int.Parse( _dRow["ServiceChargeInclusive"].ToString() );
				_oTransactionCode.GovtTax = decimal.Parse(_dRow["GovtTax"].ToString());
				_oTransactionCode.GovtTaxInclusive = int.Parse(_dRow["GovtTaxInclusive"].ToString());
				_oTransactionCode.LocalTax = decimal.Parse(_dRow["LocalTax"].ToString());
				_oTransactionCode.LocalTaxInclusive = int.Parse(_dRow["LocalTaxInclusive"].ToString());
				_oTransactionCode.DefaultTransactionSource = _dRow["DefaultTransactionSource"].ToString();
				_oTransactionCode.DefaultAmount = decimal.Parse(_dRow["DefaultAmount"].ToString());
				_oTransactionCode.WarningAmount = decimal.Parse(_dRow["WarningAmount"].ToString());
				_oTransactionCode.DepartmentId = _dRow["DepartmentId"].ToString();
				_oTransactionCode.Ledger = _dRow["Ledger"].ToString();
				_oTransactionCode.DebitSide = _dRow["DebitSide"].ToString();
				_oTransactionCode.CreditSide = _dRow["CreditSide"].ToString();
				_oTransactionCode.HotelID = int.Parse( _dRow["HotelID"].ToString() );
				_oTransactionCode.CreateTime = DateTime.Parse( _dRow["CreateTime"].ToString() );
				_oTransactionCode.CreatedBy = _dRow["CreatedBy"].ToString();
				_oTransactionCode.UpdateTime = DateTime.Parse( _dRow["UpdateTime"].ToString() );
				_oTransactionCode.UpdatedBy = _dRow["UpdatedBy"].ToString();
			
				_oTransactionCodeList.Add(_oTransactionCode);
			}

			return _oTransactionCodeList;
		}

    }
}
