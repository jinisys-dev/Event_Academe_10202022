using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Cashier.DataAccessLayer
{
    public class AccountingAdjustmentDAO
    {

        private MySqlConnection localConnection;
        private int hotelId;

        public AccountingAdjustmentDAO()
        {
            localConnection = GlobalVariables.gPersistentConnection;
            hotelId = GlobalVariables.gHotelId;
        }

        public DataTable getAccountingAdjustments()
        {
            DataTable dtTransactions = new DataTable();
            try
            {
                string strQuery = "call spSelectAccountingAdjustments()";

                MySqlDataAdapter dtaSelect = new MySqlDataAdapter(strQuery, localConnection);
                dtaSelect.Fill(dtTransactions);

                return dtTransactions;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string appendAccountingAdjustment(object newTransaction, ref MySqlTransaction trans)
        {
            string transactionId = "";

            try
            {
                string _hotelId = newTransaction.GetType().GetProperty("HotelID").GetValue(newTransaction, null).ToString();
                DateTime _transactionDate = DateTime.Parse(newTransaction.GetType().GetProperty("TransactionDate").GetValue(newTransaction, null).ToString());
                string _transactionCode = newTransaction.GetType().GetProperty("TransactionCode").GetValue(newTransaction, null).ToString();
                string _subAccount = newTransaction.GetType().GetProperty("SubAccount").GetValue(newTransaction, null).ToString();
                string _referenceNo = newTransaction.GetType().GetProperty("ReferenceNo").GetValue(newTransaction, null).ToString();
                string _transactionSource = newTransaction.GetType().GetProperty("TransactionSource").GetValue(newTransaction, null).ToString();
                string _memo = newTransaction.GetType().GetProperty("Memo").GetValue(newTransaction, null).ToString();
                string _acctSide = newTransaction.GetType().GetProperty("AcctSide").GetValue(newTransaction, null).ToString();
                string _currencyCode = newTransaction.GetType().GetProperty("CurrencyCode").GetValue(newTransaction, null).ToString();
                string _conversionRate = newTransaction.GetType().GetProperty("ConversionRate").GetValue(newTransaction, null).ToString();
                string _currencyAmount = newTransaction.GetType().GetProperty("CurrencyAmount").GetValue(newTransaction, null).ToString();
                string _baseAmount = newTransaction.GetType().GetProperty("BaseAmount").GetValue(newTransaction, null).ToString();
                string _grossAmount = newTransaction.GetType().GetProperty("GrossAmount").GetValue(newTransaction, null).ToString();
                string _discount = newTransaction.GetType().GetProperty("Discount").GetValue(newTransaction, null).ToString();
                string _serviceCharge = newTransaction.GetType().GetProperty("ServiceCharge").GetValue(newTransaction, null).ToString();
                string _serviceChargeInclusive = newTransaction.GetType().GetProperty("ServiceChargeInclusive").GetValue(newTransaction, null).ToString();
                string _governmentTax = newTransaction.GetType().GetProperty("GovernmentTax").GetValue(newTransaction, null).ToString();
                string _governmentTaxInclusive = newTransaction.GetType().GetProperty("GovernmentTaxInclusive").GetValue(newTransaction, null).ToString();
                string _localTax = newTransaction.GetType().GetProperty("LocalTax").GetValue(newTransaction, null).ToString();
                string _localTaxInclusive = newTransaction.GetType().GetProperty("LocalTaxInclusive").GetValue(newTransaction, null).ToString();
                string _netBaseAmount = newTransaction.GetType().GetProperty("NetBaseAmount").GetValue(newTransaction, null).ToString();
                string _netAmount = newTransaction.GetType().GetProperty("NetAmount").GetValue(newTransaction, null).ToString();
                string _referenceFolioId = newTransaction.GetType().GetProperty("ReferenceFolioId").GetValue(newTransaction, null).ToString();
                string _roomNumber = newTransaction.GetType().GetProperty("RoomNumber").GetValue(newTransaction, null).ToString();
                string _accountId = newTransaction.GetType().GetProperty("AccountId").GetValue(newTransaction, null).ToString();
                string _guestName = newTransaction.GetType().GetProperty("GuestName").GetValue(newTransaction, null).ToString();
                string _companyName = newTransaction.GetType().GetProperty("CompanyName").GetValue(newTransaction, null).ToString();
                DateTime _arrivalDate = DateTime.Parse(newTransaction.GetType().GetProperty("ArrivalDate").GetValue(newTransaction, null).ToString());
                DateTime _departureDate = DateTime.Parse(newTransaction.GetType().GetProperty("DepartureDate").GetValue(newTransaction, null).ToString());
                string _referenceDriverId = newTransaction.GetType().GetProperty("ReferenceDriverId").GetValue(newTransaction, null).ToString();
                string _carCompany = newTransaction.GetType().GetProperty("CarCompany").GetValue(newTransaction, null).ToString();
                string _makeModel = newTransaction.GetType().GetProperty("MakeModel").GetValue(newTransaction, null).ToString();
                string _plateNumber = newTransaction.GetType().GetProperty("PlateNumber").GetValue(newTransaction, null).ToString();

                string _creditCardNo = newTransaction.GetType().GetProperty("CreditCardNo").GetValue(newTransaction, null).ToString();
                string _chequeNo = newTransaction.GetType().GetProperty("ChequeNo").GetValue(newTransaction, null).ToString();
                string _accountName = newTransaction.GetType().GetProperty("AccountName").GetValue(newTransaction, null).ToString();
                string _bankName = newTransaction.GetType().GetProperty("BankName").GetValue(newTransaction, null).ToString();
                DateTime _chequeDate = DateTime.Parse(newTransaction.GetType().GetProperty("ChequeDate").GetValue(newTransaction, null).ToString());
                string _FOCGrantedBy = newTransaction.GetType().GetProperty("FOCGrantedBy").GetValue(newTransaction, null).ToString();
                string _creditCardType = newTransaction.GetType().GetProperty("CreditCardType").GetValue(newTransaction, null).ToString();
                string _approvalSlip = newTransaction.GetType().GetProperty("ApprovalSlip").GetValue(newTransaction, null).ToString();
                DateTime _creditCardExpiry = DateTime.Parse(newTransaction.GetType().GetProperty("CreditCardExpiry").GetValue(newTransaction, null).ToString());
                string _createdBy = GlobalVariables.gLoggedOnUser;

                string _terminalID = GlobalVariables.gTerminalID.ToString();
                string _shiftCode = GlobalVariables.gShiftCode.ToString();


                string strQuery = "call spInsertAccountingAdjustment('" +
                                                                _hotelId + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _transactionDate) + "','" +
                                                                _transactionCode + "','" +
                                                                _subAccount + "','" +
                                                                _referenceNo + "','" +
                                                                _transactionSource + "','" +
                                                                _memo + "','" +
                                                                _acctSide + "','" +
                                                                _currencyCode + "'," +
                                                                _conversionRate + "," +
                                                                _currencyAmount + "," +
                                                                _baseAmount + "," +
                                                                _grossAmount + "," +
                                                                _discount + "," +
                                                                _serviceCharge + "," +
                                                                _serviceChargeInclusive + "," +
                                                                _governmentTax + "," +
                                                                _governmentTaxInclusive + "," +
                                                                _localTax + "," +
                                                                _localTaxInclusive + "," +
                                                                _netBaseAmount + "," +
                                                                _netAmount + ",'" +
                                                                _referenceFolioId + "','" +
                                                                _roomNumber + "','" +
                                                                _accountId + "','" +
                                                                _guestName + "','" +
                                                                _companyName + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _arrivalDate) + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _departureDate) + "','" +
                                                                _referenceDriverId + "','" +
                                                                _carCompany + "','" +
                                                                _makeModel + "','" +
                                                                _plateNumber + "','" +
                                                                _creditCardNo + "','" +
                                                                _chequeNo + "','" +
                                                                _accountName + "','" +
                                                                _bankName + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _chequeDate) + "','" +
                                                                _FOCGrantedBy + "','" +
                                                                _creditCardType + "','" +
                                                                _approvalSlip + "','" +
                                                                string.Format("{0:yyyy-MM-dd hh:mm:ss}", _creditCardExpiry) + "','" +
                                                                _terminalID + "','" +
                                                                _shiftCode + "','" +
                                                                _createdBy + "')";


                MySqlCommand insertCommand = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
                insertCommand.Transaction = trans;

                transactionId = insertCommand.ExecuteScalar().ToString();



                //// UPDATE CASHIER SHIFT AMOUNT
                //string updateStr = "call spUpdateCashierShiftAmount('" +
                //                                _acctSide + "','" +
                //                                _transactionCode + "'," +
                //                                _netAmount + ",'" +
                //                                _terminalID + "','" +
                //                                _shiftCode + "','" +
                //                                string.Format("{0:yyyy-MM-dd}", _transactionDate) +
                //                                "')";

                //MySqlCommand updateCommand = new MySqlCommand(updateStr, GlobalVariables.gPersistentConnection);

                //updateCommand.Transaction = trans;

                //updateCommand.ExecuteNonQuery();

                return transactionId;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void voidAccountingAdjustment(object newTransaction, ref MySqlTransaction trans)
        {

            string transactionId = newTransaction.GetType().GetProperty("TransactionId").GetValue(newTransaction, null).ToString();
            string hotelID = newTransaction.GetType().GetProperty("HotelID").GetValue(newTransaction, null).ToString();
            string postingDate = newTransaction.GetType().GetProperty("PostingDate").GetValue(newTransaction, null).ToString();
            DateTime transactionDate = DateTime.Parse(newTransaction.GetType().GetProperty("TransactionDate").GetValue(newTransaction, null).ToString());
            string transactionCode = newTransaction.GetType().GetProperty("TransactionCode").GetValue(newTransaction, null).ToString();
            string subAccount = newTransaction.GetType().GetProperty("SubAccount").GetValue(newTransaction, null).ToString();
            string referenceNo = newTransaction.GetType().GetProperty("ReferenceNo").GetValue(newTransaction, null).ToString();
            string transactionSource = newTransaction.GetType().GetProperty("TransactionSource").GetValue(newTransaction, null).ToString();
            string memo = newTransaction.GetType().GetProperty("Memo").GetValue(newTransaction, null).ToString();
            string acctSide = newTransaction.GetType().GetProperty("AcctSide").GetValue(newTransaction, null).ToString();
            string currencyCode = newTransaction.GetType().GetProperty("CurrencyCode").GetValue(newTransaction, null).ToString();
            string conversionRate = newTransaction.GetType().GetProperty("ConversionRate").GetValue(newTransaction, null).ToString();
            string currencyAmount = newTransaction.GetType().GetProperty("CurrencyAmount").GetValue(newTransaction, null).ToString();
            string baseAmount = newTransaction.GetType().GetProperty("BaseAmount").GetValue(newTransaction, null).ToString();
            string discount = newTransaction.GetType().GetProperty("Discount").GetValue(newTransaction, null).ToString();
            string serviceCharge = newTransaction.GetType().GetProperty("ServiceCharge").GetValue(newTransaction, null).ToString();
            string governmentTax = newTransaction.GetType().GetProperty("GovernmentTax").GetValue(newTransaction, null).ToString();
            string localTax = newTransaction.GetType().GetProperty("LocalTax").GetValue(newTransaction, null).ToString();
            string netBaseAmount = newTransaction.GetType().GetProperty("NetBaseAmount").GetValue(newTransaction, null).ToString();
            string referenceFolioId = newTransaction.GetType().GetProperty("ReferenceFolioId").GetValue(newTransaction, null).ToString();
            string roomNumber = newTransaction.GetType().GetProperty("RoomNumber").GetValue(newTransaction, null).ToString();
            string accountId = newTransaction.GetType().GetProperty("AccountId").GetValue(newTransaction, null).ToString();
            string guestName = newTransaction.GetType().GetProperty("GuestName").GetValue(newTransaction, null).ToString();
            string companyName = newTransaction.GetType().GetProperty("CompanyName").GetValue(newTransaction, null).ToString();
            DateTime arrivalDate = DateTime.Parse(newTransaction.GetType().GetProperty("ArrivalDate").GetValue(newTransaction, null).ToString());
            DateTime departureDate = DateTime.Parse(newTransaction.GetType().GetProperty("DepartureDate").GetValue(newTransaction, null).ToString());
            string referenceDriverId = newTransaction.GetType().GetProperty("ReferenceDriverId").GetValue(newTransaction, null).ToString();
            string carCompany = newTransaction.GetType().GetProperty("CarCompany").GetValue(newTransaction, null).ToString();
            string makeModel = newTransaction.GetType().GetProperty("MakeModel").GetValue(newTransaction, null).ToString();
            string plateNumber = newTransaction.GetType().GetProperty("PlateNumber").GetValue(newTransaction, null).ToString();
            string terminalID = newTransaction.GetType().GetProperty("TerminalID").GetValue(newTransaction, null).ToString();
            string gShiftCode = newTransaction.GetType().GetProperty("ShiftCode").GetValue(newTransaction, null).ToString();
            //string statusFlag = newTransaction.GetType().GetProperty("StatusFlag").GetValue(newTransaction,null).ToString());
            //string postedToLedger = newTransaction.GetType().GetProperty("PostedToLedger").GetValue(newTransaction,null).ToString());
            //string auditFlag = newTransaction.GetType().GetProperty("AuditFlag").GetValue(newTransaction,null).ToString());
            string credit_Card_No = newTransaction.GetType().GetProperty("CreditCardNo").GetValue(newTransaction, null).ToString();
            string cheque_No = newTransaction.GetType().GetProperty("ChequeNo").GetValue(newTransaction, null).ToString();
            string account_Name = newTransaction.GetType().GetProperty("AccountName").GetValue(newTransaction, null).ToString();
            string bank_Name = newTransaction.GetType().GetProperty("BankName").GetValue(newTransaction, null).ToString();
            DateTime cheque_Date = DateTime.Parse(newTransaction.GetType().GetProperty("ChequeDate").GetValue(newTransaction, null).ToString());
            string FOC_Granted_By = newTransaction.GetType().GetProperty("FOCGrantedBy").GetValue(newTransaction, null).ToString();
            string credit_Card_Type = newTransaction.GetType().GetProperty("CreditCardType").GetValue(newTransaction, null).ToString();
            string approval_Slip = newTransaction.GetType().GetProperty("ApprovalSlip").GetValue(newTransaction, null).ToString();
            DateTime credit_Card_Expiry = DateTime.Parse(newTransaction.GetType().GetProperty("CreditCardExpiry").GetValue(newTransaction, null).ToString());

            string updatedBy = GlobalVariables.gLoggedOnUser;


            string strQuery = "call spVoidAccountingAdjustment('" + transactionId
                                                            + "','" + updatedBy
                                                            + "','" + hotelId
                                                            + "'," + baseAmount
                                                            + ",'" + referenceDriverId + "')";

            MySqlCommand voidCommand = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
            voidCommand.Transaction = trans;
            voidCommand.ExecuteNonQuery();


            //// UPDATE CASHIER SHIFT AMOUNT
            //string updateStr = "call spUpdateCashierShiftAmountVoid('" + acctSide
            //              + "','" + transactionCode
            //              + "'," + baseAmount
            //              + ",'" + terminalID
            //              + "','" + gShiftCode
            //              + "','" + string.Format("{0:yyyy-MM-dd}", transactionDate)
            //              + "')";
            //MySqlCommand updateCommand = new MySqlCommand(updateStr, GlobalVariables.gPersistentConnection);

            //updateCommand.Transaction = trans;

            //updateCommand.ExecuteNonQuery();
        }

        public string postToNonGuestTrans(object newTransaction, ref MySqlTransaction trans)
        {
            string transactionId = "";

            try
            {
                string _transactionID=newTransaction.GetType().GetProperty("TransactionId").GetValue(newTransaction,null).ToString();
                string _hotelId = newTransaction.GetType().GetProperty("HotelID").GetValue(newTransaction, null).ToString();
                DateTime _transactionDate = DateTime.Parse(newTransaction.GetType().GetProperty("TransactionDate").GetValue(newTransaction, null).ToString());
                string _transactionCode = newTransaction.GetType().GetProperty("TransactionCode").GetValue(newTransaction, null).ToString();
                string _subAccount = newTransaction.GetType().GetProperty("SubAccount").GetValue(newTransaction, null).ToString();
                string _referenceNo = newTransaction.GetType().GetProperty("ReferenceNo").GetValue(newTransaction, null).ToString();
                string _transactionSource = newTransaction.GetType().GetProperty("TransactionSource").GetValue(newTransaction, null).ToString();
                string _memo = newTransaction.GetType().GetProperty("Memo").GetValue(newTransaction, null).ToString();
                string _acctSide = newTransaction.GetType().GetProperty("AcctSide").GetValue(newTransaction, null).ToString();
                string _currencyCode = newTransaction.GetType().GetProperty("CurrencyCode").GetValue(newTransaction, null).ToString();
                string _conversionRate = newTransaction.GetType().GetProperty("ConversionRate").GetValue(newTransaction, null).ToString();
                string _currencyAmount = newTransaction.GetType().GetProperty("CurrencyAmount").GetValue(newTransaction, null).ToString();
                string _baseAmount = newTransaction.GetType().GetProperty("BaseAmount").GetValue(newTransaction, null).ToString();
                string _grossAmount = newTransaction.GetType().GetProperty("GrossAmount").GetValue(newTransaction, null).ToString();
                string _discount = newTransaction.GetType().GetProperty("Discount").GetValue(newTransaction, null).ToString();
                string _serviceCharge = newTransaction.GetType().GetProperty("ServiceCharge").GetValue(newTransaction, null).ToString();
                string _serviceChargeInclusive = newTransaction.GetType().GetProperty("ServiceChargeInclusive").GetValue(newTransaction, null).ToString();
                string _governmentTax = newTransaction.GetType().GetProperty("GovernmentTax").GetValue(newTransaction, null).ToString();
                string _governmentTaxInclusive = newTransaction.GetType().GetProperty("GovernmentTaxInclusive").GetValue(newTransaction, null).ToString();
                string _localTax = newTransaction.GetType().GetProperty("LocalTax").GetValue(newTransaction, null).ToString();
                string _localTaxInclusive = newTransaction.GetType().GetProperty("LocalTaxInclusive").GetValue(newTransaction, null).ToString();
                string _netBaseAmount = newTransaction.GetType().GetProperty("NetBaseAmount").GetValue(newTransaction, null).ToString();
                string _netAmount = newTransaction.GetType().GetProperty("NetAmount").GetValue(newTransaction, null).ToString();
                string _referenceFolioId = newTransaction.GetType().GetProperty("ReferenceFolioId").GetValue(newTransaction, null).ToString();
                string _roomNumber = newTransaction.GetType().GetProperty("RoomNumber").GetValue(newTransaction, null).ToString();
                string _accountId = newTransaction.GetType().GetProperty("AccountId").GetValue(newTransaction, null).ToString();
                string _guestName = newTransaction.GetType().GetProperty("GuestName").GetValue(newTransaction, null).ToString();
                string _companyName = newTransaction.GetType().GetProperty("CompanyName").GetValue(newTransaction, null).ToString();
                DateTime _arrivalDate = DateTime.Parse(newTransaction.GetType().GetProperty("ArrivalDate").GetValue(newTransaction, null).ToString());
                DateTime _departureDate = DateTime.Parse(newTransaction.GetType().GetProperty("DepartureDate").GetValue(newTransaction, null).ToString());
                string _referenceDriverId = newTransaction.GetType().GetProperty("ReferenceDriverId").GetValue(newTransaction, null).ToString();
                string _carCompany = newTransaction.GetType().GetProperty("CarCompany").GetValue(newTransaction, null).ToString();
                string _makeModel = newTransaction.GetType().GetProperty("MakeModel").GetValue(newTransaction, null).ToString();
                string _plateNumber = newTransaction.GetType().GetProperty("PlateNumber").GetValue(newTransaction, null).ToString();

                string _creditCardNo = newTransaction.GetType().GetProperty("CreditCardNo").GetValue(newTransaction, null).ToString();
                string _chequeNo = newTransaction.GetType().GetProperty("ChequeNo").GetValue(newTransaction, null).ToString();
                string _accountName = newTransaction.GetType().GetProperty("AccountName").GetValue(newTransaction, null).ToString();
                string _bankName = newTransaction.GetType().GetProperty("BankName").GetValue(newTransaction, null).ToString();
                DateTime _chequeDate = DateTime.Parse(newTransaction.GetType().GetProperty("ChequeDate").GetValue(newTransaction, null).ToString());
                string _FOCGrantedBy = newTransaction.GetType().GetProperty("FOCGrantedBy").GetValue(newTransaction, null).ToString();
                string _creditCardType = newTransaction.GetType().GetProperty("CreditCardType").GetValue(newTransaction, null).ToString();
                string _approvalSlip = newTransaction.GetType().GetProperty("ApprovalSlip").GetValue(newTransaction, null).ToString();
                DateTime _creditCardExpiry = DateTime.Parse(newTransaction.GetType().GetProperty("CreditCardExpiry").GetValue(newTransaction, null).ToString());
                string _createdBy = GlobalVariables.gLoggedOnUser;

                string _terminalID = GlobalVariables.gTerminalID.ToString();
                string _shiftCode = GlobalVariables.gShiftCode.ToString();


                string strQuery = "call spInsertNonGuestTransaction('" +
                                                                _hotelId + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _transactionDate) + "','" +
                                                                _transactionCode + "','" +
                                                                _subAccount + "','" +
                                                                _referenceNo + "','" +
                                                                _transactionSource + "','" +
                                                                _memo + "','" +
                                                                _acctSide + "','" +
                                                                _currencyCode + "'," +
                                                                _conversionRate + "," +
                                                                _currencyAmount + "," +
                                                                _baseAmount + "," +
                                                                _grossAmount + "," +
                                                                _discount + "," +
                                                                _serviceCharge + "," +
                                                                _serviceChargeInclusive + "," +
                                                                _governmentTax + "," +
                                                                _governmentTaxInclusive + "," +
                                                                _localTax + "," +
                                                                _localTaxInclusive + "," +
                                                                _netBaseAmount + "," +
                                                                _netAmount + ",'" +
                                                                _referenceFolioId + "','" +
                                                                _roomNumber + "','" +
                                                                _accountId + "','" +
                                                                _guestName + "','" +
                                                                _companyName + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _arrivalDate) + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _departureDate) + "','" +
                                                                _referenceDriverId + "','" +
                                                                _carCompany + "','" +
                                                                _makeModel + "','" +
                                                                _plateNumber + "','" +
                                                                _creditCardNo + "','" +
                                                                _chequeNo + "','" +
                                                                _accountName + "','" +
                                                                _bankName + "','" +
                                                                string.Format("{0:yyyy-MM-dd}", _chequeDate) + "','" +
                                                                _FOCGrantedBy + "','" +
                                                                _creditCardType + "','" +
                                                                _approvalSlip + "','" +
                                                                string.Format("{0:yyyy-MM-dd hh:mm:ss}", _creditCardExpiry) + "','" +
                                                                _terminalID + "','" +
                                                                _shiftCode + "','" +
                                                                _createdBy + "')";


                MySqlCommand insertCommand = new MySqlCommand(strQuery, GlobalVariables.gPersistentConnection);
                insertCommand.Transaction = trans;

                transactionId = insertCommand.ExecuteScalar().ToString();

                string strDelete = "delete from accountingAdjustments where transactionID='" + _transactionID + "'";
                MySqlCommand deleteCommand = new MySqlCommand(strDelete, GlobalVariables.gPersistentConnection);
                deleteCommand.Transaction = trans;
                deleteCommand.ExecuteNonQuery();

                return transactionId;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
}
