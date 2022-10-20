
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.Reservation.DataAccessLayer;


namespace Jinisys.Hotel.Reservation.BusinessLayer
{
	public class FolioTransactionFacade
	{

		private FolioTransactionDAO oFolioTransDAO;

		public FolioTransactionFacade()
		{ }


		public FolioTransaction GetFolioTransactions(string folioID, string SubFolio, int hotelid)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.GetFolioTransactions(folioID, SubFolio, hotelid);
		}

		public bool RefNoIfExist(string TranCode, string refno)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.RefNoIfExist(TranCode, refno);
		}

		public FolioTransaction GetFolioTransactions(string folioID, DateTime tranDate, string TranCode)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.GetFolioTransactions(folioID, tranDate, TranCode);
		}

		public decimal GetCharges(string folioID)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.GetCharges(folioID);
		}

		public DataTable GetData(string Category)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.GetData(Category);
		}


		public bool UpdateFolioTransaction(FolioTransaction oFolioTransaction, ref MySqlTransaction myTransaction)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.UpdateFolioTransaction(oFolioTransaction, ref myTransaction);
		}

		public bool TransferFolioTransaction(string FromFolioID, string ToFolioID, string RoutCode, string trandate, ref MySqlTransaction myTransaction)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.TransferFolioTransaction(FromFolioID, ToFolioID, RoutCode, trandate, ref myTransaction);
		}

		public bool SetFolioTransactionStatus(DateTime tDate, string tranCode, string FolioID, string status, ref MySqlTransaction myTransaction)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.SetFolioTransactionStatus(tDate, tranCode, FolioID, status, ref myTransaction);
		}

		public bool DeleteFolioTransaction(DateTime tDate, string tranCode, string FolioID, ref MySqlTransaction myTransaction)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.DeleteFolioTransaction(tDate, tranCode, FolioID, ref myTransaction);
		}

		public void PostToLedger(Jinisys.Hotel.Reservation.BusinessLayer.Folio oFolio)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			oFolioTransDAO.PostToLedger(oFolio);
		}

        //for posting non guest city transfer transactions
        public void PostNonGuestTransCityLedger(string pAccountID, decimal pAmount, string pFolioID, ref MySqlTransaction myTransaction)
        {
            oFolioTransDAO = new FolioTransactionDAO();
            oFolioTransDAO.PostNonGuestTransCityLedger(pAccountID, pAmount, pFolioID, ref myTransaction);
        }

		// >> JEROME 29-Apr-2006
		// >> Used in FolioLedgerUI.GetIndividualFolio
		public decimal GetFolioCharges(string folioID, string subFolio)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.GetFolioCharges(folioID, subFolio);
		}

		public decimal GetFolioPayments(string folioID, string SubFolio)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.GetFolioPayments(folioID, SubFolio);
		}

		public bool InsertFolioTransaction(FolioTransaction oFolioTransaction, ref MySqlTransaction myTransaction)
		{

			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.InsertFolioTransaction(oFolioTransaction, ref myTransaction);

		}


		// for routing
		public bool InsertFolioTransactionsFromTransfer(FolioTransactions oFolioTransCollection, ref MySqlTransaction myTransaction)
		{
			FolioTransaction oFolioTrans;
			foreach (FolioTransaction tempLoopVar_oFolioTrans in oFolioTransCollection)
			{
				bool successful = false;

				oFolioTrans = tempLoopVar_oFolioTrans;
				successful = this.transferFolioTransaction(oFolioTrans, ref myTransaction);

				if (!successful)
				{
					return false;
				}

			}

			return true;
		}

		public bool transferFolioTransaction(FolioTransaction oFolioTransaction, ref MySqlTransaction myTransaction)
		{

			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.transferFolioTransaction(oFolioTransaction, ref myTransaction);

		}


		public bool InsertFolioTransaction(FolioTransactions oFolioTransCollection, ref MySqlTransaction myTransaction)
		{
			FolioTransaction oFolioTrans;
			foreach (FolioTransaction tempLoopVar_oFolioTrans in oFolioTransCollection)
			{
				bool successful = false;

				oFolioTrans = tempLoopVar_oFolioTrans;
				successful = this.InsertFolioTransaction(oFolioTrans, ref myTransaction);

				if (!successful)
				{
					return false;
				}
			}

			return true;
		}


		public bool VoidFolioTransaction(FolioTransaction poFolioTrans, ref MySqlTransaction myTransaction)
		{

			poFolioTrans = this.getFolioTransactionByTransactionNo(poFolioTrans.FolioTransactionNo);

			poFolioTrans.UpdatedBy = GlobalVariables.gLoggedOnUser;

			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.VoidFolioTransaction(poFolioTrans, ref myTransaction);

		}


		public string getTranCodeAccountSide(string tranCode)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.getTranCodeAccountSide(tranCode);
		}

		public FolioTransaction GetVoidedFolioTransactions(string folioID)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.GetVoidedFolioTransactions(folioID);
		}

		public bool RecallFolioTransaction(FolioTransaction oFolioTrans, ref MySqlTransaction myTransaction)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.RecallFolioTransaction(oFolioTrans, ref myTransaction);
		}

		public int getTransactionTerminalId(FolioTransaction a_FolioTransaction)
		{
			oFolioTransDAO = new FolioTransactionDAO();
			return oFolioTransDAO.getTransactionTerminalId(a_FolioTransaction);
		}


		public FolioTransaction getFolioTransactionByTransactionNo(int pFolioTransactionNo)
		{
			FolioTransaction _FolioTransaction = new FolioTransaction();

			DataTable _dtTemp;
			oFolioTransDAO = new FolioTransactionDAO();
			_dtTemp = oFolioTransDAO.getFolioTransactionByTransactionNo(pFolioTransactionNo);

			DataRow _dtRow = _dtTemp.Rows[0];
			_FolioTransaction.FolioTransactionNo = pFolioTransactionNo;
			_FolioTransaction.HotelID = int.Parse(_dtRow["HotelId"].ToString());
			_FolioTransaction.FolioID = _dtRow["FolioId"].ToString();
			_FolioTransaction.SubFolio = _dtRow["SubFolio"].ToString();
			_FolioTransaction.AccountID = _dtRow["AccountId"].ToString();
			_FolioTransaction.TransactionDate = DateTime.Parse(_dtRow["TransactionDate"].ToString());
			_FolioTransaction.PostingDate = DateTime.Parse(_dtRow["PostingDate"].ToString());
			_FolioTransaction.TransactionCode = _dtRow["TransactionCode"].ToString();
			_FolioTransaction.SubAccount = _dtRow["SubAccount"].ToString();
			_FolioTransaction.ReferenceNo = _dtRow["ReferenceNo"].ToString();
			_FolioTransaction.TransactionSource = _dtRow["TransactionSource"].ToString();
			_FolioTransaction.Memo = _dtRow["Memo"].ToString();
			_FolioTransaction.AcctSide = _dtRow["AcctSide"].ToString();
			_FolioTransaction.CurrencyCode = _dtRow["CurrencyCode"].ToString();
			_FolioTransaction.ConversionRate = decimal.Parse(_dtRow["conversionRate"].ToString());
			_FolioTransaction.CurrencyAmount = decimal.Parse(_dtRow["currencyAmount"].ToString());
			_FolioTransaction.BaseAmount = decimal.Parse(_dtRow["baseAmount"].ToString());
			_FolioTransaction.GrossAmount = decimal.Parse(_dtRow["grossAmount"].ToString());
			_FolioTransaction.Discount = decimal.Parse(_dtRow["discount"].ToString());
			_FolioTransaction.ServiceCharge = decimal.Parse(_dtRow["serviceCharge"].ToString());
			_FolioTransaction.ServiceChargeInclusive = int.Parse(_dtRow["serviceChargeInclusive"].ToString());
			_FolioTransaction.GovernmentTax = decimal.Parse(_dtRow["governmentTax"].ToString());
			_FolioTransaction.GovernmentTaxInclusive = int.Parse(_dtRow["governmentTaxInclusive"].ToString());
			_FolioTransaction.LocalTax = decimal.Parse(_dtRow["localTax"].ToString());
			_FolioTransaction.LocalTaxInclusive = int.Parse(_dtRow["localTaxInclusive"].ToString());
			_FolioTransaction.NetBaseAmount = decimal.Parse(_dtRow["netBaseAmount"].ToString());
			_FolioTransaction.NetAmount = decimal.Parse(_dtRow["netAmount"].ToString());
			_FolioTransaction.CreditCardNo = _dtRow["creditCardNo"].ToString();
			_FolioTransaction.ChequeNo = _dtRow["chequeNo"].ToString();
			_FolioTransaction.AccountName = _dtRow["accountName"].ToString();
			_FolioTransaction.BankName = _dtRow["bankName"].ToString();
			_FolioTransaction.ChequeDate = _dtRow["chequeDate"].ToString();
			_FolioTransaction.FOCGrantedBy = _dtRow["FOCGrantedBy"].ToString();
			_FolioTransaction.CreditCardType = _dtRow["creditCardType"].ToString();
			_FolioTransaction.ApprovalSlip = _dtRow["approvalSlip"].ToString();
			_FolioTransaction.CreditCardExpiry = _dtRow["creditCardExpiry"].ToString();
			_FolioTransaction.RouteSequence = _dtRow["routeSequence"].ToString();
			_FolioTransaction.SourceFolio = _dtRow["sourceFolio"].ToString();
			_FolioTransaction.SourceSubFolio = _dtRow["sourceSubFolio"].ToString();
			_FolioTransaction.TerminalID = _dtRow["terminalID"].ToString();
			_FolioTransaction.ShiftCode = _dtRow["shiftCode"].ToString();
			_FolioTransaction.Status = _dtRow["status"].ToString();
			_FolioTransaction.PostToLedger = _dtRow["postToLedger"].ToString();
			_FolioTransaction.CreateTime = DateTime.Parse(_dtRow["createTime"].ToString());
			_FolioTransaction.CreatedBy = _dtRow["createdBy"].ToString();
			_FolioTransaction.UpdateTime = DateTime.Parse(_dtRow["updateTime"].ToString());
			_FolioTransaction.UpdatedBy = _dtRow["updatedBy"].ToString();
			_FolioTransaction.AuditFlag = _dtRow["auditFlag"].ToString();
            _FolioTransaction.AdjustmentFlag = _dtRow["adjustmentFlag"].ToString();


			return _FolioTransaction;
		}

		public FolioTransaction getFolioTransactionByTransactionCodeAndReferenceNo(string pTransactionCode, string pReferenceNo)
		{
			FolioTransaction _FolioTransaction = new FolioTransaction();

			DataTable _dtTemp;
			oFolioTransDAO = new FolioTransactionDAO();
			_dtTemp = oFolioTransDAO.getFolioTransactionByTransactionCodeAndReferenceNo(pTransactionCode, pReferenceNo);

			DataRow _dtRow = _dtTemp.Rows[0];
			_FolioTransaction.FolioTransactionNo = int.Parse(_dtRow["folioTransactionNo"].ToString());
			_FolioTransaction.HotelID = int.Parse(_dtRow["HotelId"].ToString());
			_FolioTransaction.FolioID = _dtRow["FolioId"].ToString();
			_FolioTransaction.SubFolio = _dtRow["SubFolio"].ToString();
			_FolioTransaction.AccountID = _dtRow["AccountId"].ToString();
			_FolioTransaction.TransactionDate = DateTime.Parse(_dtRow["TransactionDate"].ToString());
			_FolioTransaction.PostingDate = DateTime.Parse(_dtRow["PostingDate"].ToString());
			_FolioTransaction.TransactionCode = _dtRow["TransactionCode"].ToString();
			_FolioTransaction.SubAccount = _dtRow["SubAccount"].ToString();
			_FolioTransaction.ReferenceNo = _dtRow["ReferenceNo"].ToString();
			_FolioTransaction.TransactionSource = _dtRow["TransactionSource"].ToString();
			_FolioTransaction.Memo = _dtRow["Memo"].ToString();
			_FolioTransaction.AcctSide = _dtRow["AcctSide"].ToString();
			_FolioTransaction.CurrencyCode = _dtRow["CurrencyCode"].ToString();
			_FolioTransaction.ConversionRate = decimal.Parse(_dtRow["conversionRate"].ToString());
			_FolioTransaction.CurrencyAmount = decimal.Parse(_dtRow["currencyAmount"].ToString());
			_FolioTransaction.BaseAmount = decimal.Parse(_dtRow["baseAmount"].ToString());
			_FolioTransaction.GrossAmount = decimal.Parse(_dtRow["grossAmount"].ToString());
			_FolioTransaction.Discount = decimal.Parse(_dtRow["discount"].ToString());
			_FolioTransaction.ServiceCharge = decimal.Parse(_dtRow["serviceCharge"].ToString());
			_FolioTransaction.ServiceChargeInclusive = int.Parse(_dtRow["serviceChargeInclusive"].ToString());
			_FolioTransaction.GovernmentTax = decimal.Parse(_dtRow["governmentTax"].ToString());
			_FolioTransaction.GovernmentTaxInclusive = int.Parse(_dtRow["governmentTaxInclusive"].ToString());
			_FolioTransaction.LocalTax = decimal.Parse(_dtRow["localTax"].ToString());
			_FolioTransaction.LocalTaxInclusive = int.Parse(_dtRow["localTaxInclusive"].ToString());
			_FolioTransaction.NetBaseAmount = decimal.Parse(_dtRow["netBaseAmount"].ToString());
			_FolioTransaction.NetAmount = decimal.Parse(_dtRow["netAmount"].ToString());
			_FolioTransaction.CreditCardNo = _dtRow["creditCardNo"].ToString();
			_FolioTransaction.ChequeNo = _dtRow["chequeNo"].ToString();
			_FolioTransaction.AccountName = _dtRow["accountName"].ToString();
			_FolioTransaction.BankName = _dtRow["bankName"].ToString();
			_FolioTransaction.ChequeDate = _dtRow["chequeDate"].ToString();
			_FolioTransaction.FOCGrantedBy = _dtRow["FOCGrantedBy"].ToString();
			_FolioTransaction.CreditCardType = _dtRow["creditCardType"].ToString();
			_FolioTransaction.ApprovalSlip = _dtRow["approvalSlip"].ToString();
			_FolioTransaction.CreditCardExpiry = _dtRow["creditCardExpiry"].ToString();
			_FolioTransaction.RouteSequence = _dtRow["routeSequence"].ToString();
			_FolioTransaction.SourceFolio = _dtRow["sourceFolio"].ToString();
			_FolioTransaction.SourceSubFolio = _dtRow["sourceSubFolio"].ToString();
			_FolioTransaction.TerminalID = _dtRow["terminalID"].ToString();
			_FolioTransaction.ShiftCode = _dtRow["shiftCode"].ToString();
			_FolioTransaction.Status = _dtRow["status"].ToString();
			_FolioTransaction.PostToLedger = _dtRow["postToLedger"].ToString();
			_FolioTransaction.CreateTime = DateTime.Parse(_dtRow["createTime"].ToString());
			_FolioTransaction.CreatedBy = _dtRow["createdBy"].ToString();
			_FolioTransaction.UpdateTime = DateTime.Parse(_dtRow["updateTime"].ToString());
			_FolioTransaction.UpdatedBy = _dtRow["updatedBy"].ToString();
			_FolioTransaction.AuditFlag = _dtRow["auditFlag"].ToString();
            _FolioTransaction.AdjustmentFlag = _dtRow["adjustmentFlag"].ToString();


			return _FolioTransaction;
		}

        //>>for checking if guest has already room charge for the day
        public bool checkIfRoomChargeExist(string pFolioID)
        {
            oFolioTransDAO = new FolioTransactionDAO();
            return oFolioTransDAO.checkIfRoomChargeExist(pFolioID);
        }

	}
}