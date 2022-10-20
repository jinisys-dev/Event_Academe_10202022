using System;
using System.Collections.Generic;
using System.Text;
using Jinisys.Hotel.Cashier.DataAccessLayer;

using System.Data;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Cashier.BusinessLayer
{
    public class AccountingAdjustmentFacade
    {

        private AccountingAdjustmentDAO oAccountingAdjustmentDAO;

        public AccountingAdjustmentFacade()
        {
        }

        public IList<AccountingAdjustments> getAccountingAdjustments()
        {
            oAccountingAdjustmentDAO = new AccountingAdjustmentDAO();
            IList<AccountingAdjustments> ilAccountingAdjustments = new List<AccountingAdjustments>();

            DataTable dtTransactions = oAccountingAdjustmentDAO.getAccountingAdjustments();

            foreach (DataRow dRow in dtTransactions.Rows)
            {
                AccountingAdjustments newTrans = new AccountingAdjustments();

                newTrans.TransactionId = dRow["transactionId"].ToString();
                newTrans.HotelID = int.Parse(dRow["hotelID"].ToString());
                newTrans.PostingDate = DateTime.Parse(dRow["postingDate"].ToString());
                newTrans.TransactionDate = DateTime.Parse(dRow["transactionDate"].ToString());
                newTrans.TransactionCode = dRow["transactionCode"].ToString();
                newTrans.SubAccount = dRow["subAccount"].ToString();
                newTrans.ReferenceNo = dRow["referenceNo"].ToString();
                newTrans.TransactionSource = dRow["transactionSource"].ToString();
                newTrans.Memo = dRow["memo"].ToString();
                newTrans.AcctSide = dRow["acctSide"].ToString();
                newTrans.CurrencyCode = dRow["currencyCode"].ToString();
                newTrans.ConversionRate = decimal.Parse(dRow["conversionRate"].ToString());
                newTrans.CurrencyAmount = decimal.Parse(dRow["currencyAmount"].ToString());
                newTrans.BaseAmount = decimal.Parse(dRow["baseAmount"].ToString());
                newTrans.GrossAmount = decimal.Parse(dRow["grossAmount"].ToString());
                newTrans.Discount = decimal.Parse(dRow["discount"].ToString());
                newTrans.ServiceCharge = decimal.Parse(dRow["serviceCharge"].ToString());
                newTrans.ServiceChargeInclusive = int.Parse(dRow["serviceChargeInclusive"].ToString());

                newTrans.GovernmentTax = decimal.Parse(dRow["governmentTax"].ToString());
                newTrans.GovernmentTaxInclusive = int.Parse(dRow["governmentTaxInclusive"].ToString());

                newTrans.LocalTax = decimal.Parse(dRow["localTax"].ToString());
                newTrans.LocalTaxInclusive = int.Parse(dRow["localTaxInclusive"].ToString());

                newTrans.NetBaseAmount = decimal.Parse(dRow["NetBaseAmount"].ToString());
                newTrans.NetAmount = decimal.Parse(dRow["netAmount"].ToString());

                newTrans.ReferenceFolioId = dRow["referenceFolioId"].ToString();
                newTrans.RoomNumber = dRow["roomNumber"].ToString();
                newTrans.AccountId = dRow["accountId"].ToString();
                newTrans.GuestName = dRow["guestName"].ToString();
                newTrans.CompanyName = dRow["companyName"].ToString();
                newTrans.ArrivalDate = DateTime.Parse(dRow["arrivalDate"].ToString());
                newTrans.DepartureDate = DateTime.Parse(dRow["departureDate"].ToString());
                newTrans.ReferenceDriverId = dRow["referenceDriverId"].ToString();
                newTrans.CarCompany = dRow["carCompany"].ToString();
                newTrans.MakeModel = dRow["makeModel"].ToString();
                newTrans.PlateNumber = dRow["plateNumber"].ToString();
                newTrans.StatusFlag = dRow["StatusFlag"].ToString();
                newTrans.PostedToLedger = int.Parse(dRow["PostedToLedger"].ToString());
                newTrans.AuditFlag = int.Parse(dRow["AuditFlag"].ToString());
                newTrans.CreditCardNo = dRow["creditCardNo"].ToString();
                newTrans.ChequeNo = dRow["chequeNo"].ToString();
                newTrans.AccountName = dRow["accountName"].ToString();
                newTrans.BankName = dRow["bankName"].ToString();
                newTrans.ChequeDate = DateTime.Parse(dRow["chequeDate"].ToString());
                newTrans.FOCGrantedBy = dRow["FOCGrantedBy"].ToString();
                newTrans.CreditCardType = dRow["creditCardType"].ToString();
                newTrans.ApprovalSlip = dRow["approvalSlip"].ToString();
                newTrans.CreditCardExpiry = DateTime.Parse(dRow["creditCardExpiry"].ToString());

                newTrans.DriverFirstName = dRow["firstName"].ToString();
                newTrans.DriverLastName = dRow["lastName"].ToString();
                newTrans.TerminalID = dRow["terminalID"].ToString();
                newTrans.ShiftCode = int.Parse(dRow["shiftCode"].ToString());
                newTrans.createdDate = DateTime.Parse(dRow["createdDate"].ToString());
                newTrans.createdBy = dRow["createdBy"].ToString(); ;
                newTrans.updatedDate = DateTime.Parse(dRow["updatedDate"].ToString());
                newTrans.updatedBy = dRow["updatedBy"].ToString();

                ilAccountingAdjustments.Add(newTrans);
            }


            return ilAccountingAdjustments;

        }

        public bool appendAccountingAdjustment(IList<AccountingAdjustments> ilTransactions)
        {
            MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            oAccountingAdjustmentDAO = new AccountingAdjustmentDAO();

            try
            {
                foreach (AccountingAdjustments newTransaction in ilTransactions)
                {
                    newTransaction.TransactionId = oAccountingAdjustmentDAO.appendAccountingAdjustment(newTransaction, ref trans);

                    //added for city transfer transactions
                    if (newTransaction.TransactionCode == "4200")
                    {
                        FolioTransactionFacade _ofTransFacade = new FolioTransactionFacade();
                        _ofTransFacade.PostNonGuestTransCityLedger(newTransaction.AccountId, newTransaction.NetBaseAmount, newTransaction.ReferenceFolioId, ref trans);
                    }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw (ex);
            }



        }

        public bool voidAccountingAdjustment(AccountingAdjustments voidNonGuestTrans)
        {
            MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            try
            {
                oAccountingAdjustmentDAO = new AccountingAdjustmentDAO();

                oAccountingAdjustmentDAO.voidAccountingAdjustment((object)voidNonGuestTrans, ref trans);

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw (ex);
            }


        }

        public AccountingAdjustments getDriverCarInformation(string a_DriverId)
        {
            AccountingAdjustments newTrans = new AccountingAdjustments();
            oAccountingAdjustmentDAO = new AccountingAdjustmentDAO();
            DataTable dtTransactions = oAccountingAdjustmentDAO.getAccountingAdjustments();

            DataView dtvTrans = dtTransactions.DefaultView;
            dtvTrans.RowStateFilter = DataViewRowState.OriginalRows;
            dtvTrans.RowFilter = "referenceDriverId = '" + a_DriverId + "'";

            if (dtvTrans.Count > 0)
            {
                newTrans.CarCompany = dtvTrans[0]["carCompany"].ToString();
                newTrans.MakeModel = dtvTrans[0]["makeModel"].ToString();
                newTrans.PlateNumber = dtvTrans[0]["plateNumber"].ToString();

                return newTrans;
            }
            else
            {
                return null;
            }

        }

        public bool postAdjustmentsToNonGuestTransactions(IList<NonGuestTransaction> _ilNonGuestTrans)
        {
            MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();

            try
            {
                foreach (NonGuestTransaction _oNonGuestTrans in _ilNonGuestTrans)
                {
                    oAccountingAdjustmentDAO = new AccountingAdjustmentDAO();

                    oAccountingAdjustmentDAO.postToNonGuestTrans((object)_oNonGuestTrans, ref trans);
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw (ex);
            }
        }
    }
}
