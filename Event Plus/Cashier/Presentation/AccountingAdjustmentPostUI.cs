using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Cashier.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Cashier.DataAccessLayer;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.BusinessLayer;

using C1.Win.C1FlexGrid;

namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class AccountingAdjustmentPostUI : Form
    {
        public AccountingAdjustmentPostUI()
        {
            InitializeComponent();
            loadDataInListView();
        }

        decimal _balanceAllTrans = 0;
        private IList<AccountingAdjustments> ilAccountingAdjustments = new List<AccountingAdjustments>();
        private AccountingAdjustmentFacade oAccountingAdjustmentFacade;
        private void loadDataInListView()
        {
            _balanceAllTrans = 0;
            oAccountingAdjustmentFacade = new AccountingAdjustmentFacade();

            try
            {

                this.grdAllTransactions.Rows.Count = 1;

                IList<AccountingAdjustments> _accountAdjTransactions = new List<AccountingAdjustments>();
                ilAccountingAdjustments = oAccountingAdjustmentFacade.getAccountingAdjustments();
                foreach (AccountingAdjustments _accountingAdjustment in ilAccountingAdjustments)
                {
                    _accountAdjTransactions.Add(_accountingAdjustment);
                }

                foreach (AccountingAdjustments accountingAdj in _accountAdjTransactions)
                {
                    Row _newRow = this.grdAllTransactions.Rows.Add();
                    _newRow[18] = accountingAdj.TransactionId;

                    _newRow[1] = accountingAdj.TransactionDate;
                    _newRow[2] = accountingAdj.PostingDate;
                    _newRow[3] = accountingAdj.TransactionCode;
                    _newRow[4] = accountingAdj.Memo;
                    _newRow[5] = accountingAdj.TransactionSource;
                    _newRow[6] = accountingAdj.ReferenceNo;
                    _newRow[7] = accountingAdj.BaseAmount;

                    decimal _totalTax = 0;
                    _totalTax = accountingAdj.GovernmentTax + accountingAdj.LocalTax;

                    _newRow[8] = _totalTax;
                    _newRow[9] = accountingAdj.ServiceCharge;
                    _newRow[10] = accountingAdj.GrossAmount;
                    _newRow[11] = accountingAdj.Discount;
                    _newRow[12] = accountingAdj.NetAmount;
                    _newRow[16] = accountingAdj.updatedBy;
                    _newRow[17] = accountingAdj.TransactionId;


                    if (accountingAdj.AcctSide == "DEBIT")
                    {
                        //for column debit and credit
                        _newRow[13] = accountingAdj.NetAmount;
                        _newRow[14] = 0;

                        _balanceAllTrans += accountingAdj.NetAmount;
                        _newRow[15] = _balanceAllTrans;
                    }
                    else
                    {
                        //for column debit and credit
                        _newRow[13] = 0;
                        _newRow[14] = accountingAdj.NetAmount;

                        _balanceAllTrans -= accountingAdj.NetAmount;
                        _newRow[15] = _balanceAllTrans;
                    }

                }// end foreach

            }//en try

            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AccountingAdjustmentPostUI_Load(object sender, EventArgs e)
        {
            loadDataInListView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            DialogResult rsp = MessageBox.Show("Are you sure you want to post these transactions ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsp == DialogResult.No)
            {
                return;
            }

            IList<NonGuestTransaction> _ilNonGuestTransactions = new List<NonGuestTransaction>();
            foreach (C1.Win.C1FlexGrid.Row _row in grdAllTransactions.Rows)
            {
                if (_row.Index > 0)
                {
                    if (grdAllTransactions.GetCellCheck(_row.Index, 0) == CheckEnum.Checked)
                    {
                        foreach (AccountingAdjustments _oAccountingAdj in ilAccountingAdjustments)
                        {
                            if (_oAccountingAdj.TransactionId == grdAllTransactions.GetDataDisplay(_row.Index, 18))
                            {
                                NonGuestTransaction _oNonGuestTrans = new NonGuestTransaction();
                                _oNonGuestTrans.AccountId = _oAccountingAdj.AccountId;
                                _oNonGuestTrans.AccountName = _oAccountingAdj.AccountName;
                                _oNonGuestTrans.AcctSide = _oAccountingAdj.AcctSide;
                                _oNonGuestTrans.ApprovalSlip = _oAccountingAdj.ApprovalSlip;
                                _oNonGuestTrans.ArrivalDate = _oAccountingAdj.ArrivalDate;
                                _oNonGuestTrans.AuditFlag = _oAccountingAdj.AuditFlag;
                                _oNonGuestTrans.BankName = _oAccountingAdj.BankName;
                                _oNonGuestTrans.BaseAmount = _oAccountingAdj.BaseAmount;
                                _oNonGuestTrans.CarCompany = _oAccountingAdj.CarCompany;
                                _oNonGuestTrans.ChequeDate = _oAccountingAdj.ChequeDate;
                                _oNonGuestTrans.ChequeNo = _oAccountingAdj.ChequeNo;
                                _oNonGuestTrans.CompanyName = _oAccountingAdj.CompanyName;
                                _oNonGuestTrans.ConversionRate = _oAccountingAdj.ConversionRate;
                                _oNonGuestTrans.createdBy = _oAccountingAdj.createdBy;
                                _oNonGuestTrans.createdDate = _oAccountingAdj.createdDate;
                                _oNonGuestTrans.CreditCardExpiry = _oAccountingAdj.CreditCardExpiry;
                                _oNonGuestTrans.CreditCardNo = _oAccountingAdj.CreditCardNo;
                                _oNonGuestTrans.CreditCardType = _oAccountingAdj.CreditCardType;
                                _oNonGuestTrans.CurrencyAmount = _oAccountingAdj.CurrencyAmount;
                                _oNonGuestTrans.CurrencyCode = _oAccountingAdj.CurrencyCode;
                                _oNonGuestTrans.DepartureDate = _oAccountingAdj.DepartureDate;
                                _oNonGuestTrans.Discount = _oAccountingAdj.Discount;
                                _oNonGuestTrans.DriverFirstName = _oAccountingAdj.DriverFirstName;
                                _oNonGuestTrans.DriverLastName = _oAccountingAdj.DriverLastName;
                                _oNonGuestTrans.FOCGrantedBy = _oAccountingAdj.FOCGrantedBy;
                                _oNonGuestTrans.GovernmentTax = _oAccountingAdj.GovernmentTax;
                                _oNonGuestTrans.GovernmentTaxInclusive = _oAccountingAdj.GovernmentTaxInclusive;
                                _oNonGuestTrans.GrossAmount = _oAccountingAdj.GrossAmount;
                                _oNonGuestTrans.GuestName = _oAccountingAdj.GuestName;
                                _oNonGuestTrans.HotelID = _oAccountingAdj.HotelID;
                                _oNonGuestTrans.LocalTax = _oAccountingAdj.LocalTax;
                                _oNonGuestTrans.LocalTaxInclusive = _oAccountingAdj.LocalTaxInclusive;
                                _oNonGuestTrans.MakeModel = _oAccountingAdj.MakeModel;
                                _oNonGuestTrans.Memo = _oAccountingAdj.Memo;
                                _oNonGuestTrans.NetAmount = _oAccountingAdj.NetAmount;
                                _oNonGuestTrans.NetBaseAmount = _oAccountingAdj.NetBaseAmount;
                                _oNonGuestTrans.PlateNumber = _oAccountingAdj.PlateNumber;
                                _oNonGuestTrans.PostedToLedger = _oAccountingAdj.PostedToLedger;
                                _oNonGuestTrans.PostingDate = _oAccountingAdj.PostingDate;
                                _oNonGuestTrans.ReferenceDriverId = _oAccountingAdj.ReferenceDriverId;
                                _oNonGuestTrans.ReferenceFolioId = _oAccountingAdj.ReferenceFolioId;
                                _oNonGuestTrans.ReferenceNo = _oAccountingAdj.ReferenceNo;
                                _oNonGuestTrans.RoomNumber = _oAccountingAdj.RoomNumber;
                                _oNonGuestTrans.ServiceCharge = _oAccountingAdj.ServiceCharge;
                                _oNonGuestTrans.ServiceChargeInclusive = _oAccountingAdj.ServiceChargeInclusive;
                                _oNonGuestTrans.ShiftCode = _oAccountingAdj.ShiftCode;
                                _oNonGuestTrans.StatusFlag = _oAccountingAdj.StatusFlag;
                                _oNonGuestTrans.SubAccount = _oAccountingAdj.SubAccount;
                                _oNonGuestTrans.TerminalID = _oAccountingAdj.TerminalID;
                                _oNonGuestTrans.TransactionCode = _oAccountingAdj.TransactionCode;
                                _oNonGuestTrans.TransactionDate = _oAccountingAdj.TransactionDate;
                                _oNonGuestTrans.TransactionId = _oAccountingAdj.TransactionId;
                                _oNonGuestTrans.TransactionSource = _oAccountingAdj.TransactionSource;
                                _oNonGuestTrans.updatedBy = _oAccountingAdj.updatedBy;
                                _oNonGuestTrans.updatedDate = _oAccountingAdj.updatedDate;

                                _ilNonGuestTransactions.Add(_oNonGuestTrans);
                            }
                        }
                    }
                }//end if(row index)
            }//end foreach

            oAccountingAdjustmentFacade = new AccountingAdjustmentFacade();
            oAccountingAdjustmentFacade.postAdjustmentsToNonGuestTransactions(_ilNonGuestTransactions);

            loadDataInListView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IList<AccountingAdjustments> newTrans = new List<AccountingAdjustments>();

            AddDirectPostTransactionUI postAccountingAdjustment = new AddDirectPostTransactionUI("ADJUSTMENT");
            newTrans = postAccountingAdjustment.showAdjustmentDialog(this);

            if (newTrans != null)
            {
                loadDataInListView();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string transactionId = "";
            try
            {
                transactionId = this.grdAllTransactions.GetDataDisplay(grdAllTransactions.Row, 18);
            }
            catch
            {

            }

            if (transactionId != "")
            {
                AccountingAdjustments voidAccountingAdj = null;

                DialogResult rsp = MessageBox.Show("Are you sure you want to void this transaction ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsp == DialogResult.Yes)
                {
                    foreach (AccountingAdjustments accountingAdj in ilAccountingAdjustments)
                    {
                        if (accountingAdj.TransactionId == transactionId)
                        {
                            voidAccountingAdj = accountingAdj;
                            break;
                        }
                    }
                    if (voidAccountingAdj != null)
                    {
                        oAccountingAdjustmentFacade = new AccountingAdjustmentFacade();

                        try
                        {
                            oAccountingAdjustmentFacade.voidAccountingAdjustment(voidAccountingAdj);
                            this.ilAccountingAdjustments.Remove(voidAccountingAdj);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    loadDataInListView();
                }

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.BusinessLayer.ReportFacade rptFacade = new ReportFacade();
            Reports.Presentation.Report_Documents.Cashier.AccountingAdjustmentsReport _oAdjustmentReport = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Cashier.AccountingAdjustmentsReport();
            _oAdjustmentReport = rptFacade.getAdjustmentTransactionsReport();

            Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            _oReportViewer.rptViewer.ReportSource = _oAdjustmentReport;

            _oReportViewer.MdiParent = this.MdiParent;
            _oReportViewer.Show();
        }
    }
}