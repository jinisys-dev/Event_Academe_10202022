using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reservation.BusinessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.AccountingInterface.BusinessLayer;

namespace Integrations.Presentation
{
    public partial class SyncSAP : Form
    {
        public SyncSAP()
        {
            loCompany = new SAPCompany();
            InitializeComponent();
        }

        string loEventID = "";
        SAPCompany loCompany;

        Jinisys.Hotel.Reservation.BusinessLayer.FolioTransactionFacade loFolioTransactionFacade = new Jinisys.Hotel.Reservation.BusinessLayer.FolioTransactionFacade();
        FolioTransaction loFolioTransaction;
        FolioFacade loFolioFacade = new FolioFacade();

        private void btnGetPayments_Click(object sender, EventArgs e)
        {
           // txtFolioID.Text = loEventID;
            if (txtFolioID.Text != "")
            {
                if (insertPaymentsFromSAP(txtFolioID.Text))
                {
                    MessageBox.Show("Payments succesfully posted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void setEventID(string pEventID)
        {
            txtFolioID.Text = pEventID;
            loEventID = pEventID;
           
        }

        private bool insertPaymentsFromSAP(string pEventID)
        {
            try
            {
                loFolioTransaction = new FolioTransaction();
                if (!GlobalVariables.goSAPCompany.Connected)
                {

                    MessageBox.Show("Unable to connect to SAP Server!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
                DataTable _dt;
                try
                {
                    _dt = loCompany.getIncomingPayments(pEventID);
                }

                catch
                {
                    _dt = null;
                }
                Folio _oFolio = new Folio();
                FolioTransactionFacade _oFolioTransactionFacade = new FolioTransactionFacade();


                ExactFacade _oExactFacade = new ExactFacade();
                DataSet objDataSet = _oExactFacade.getTransactionCodesWithGLAccounts();

                _oFolio = loFolioFacade.GetFolio(pEventID);

                if (_oFolio == null)
                {
                    MessageBox.Show("No record found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }

                Integrations.BusinessObjects.Facade_Layer.SAPFacade _oSapFacade = new Integrations.BusinessObjects.Facade_Layer.SAPFacade();
                DataTable _dtGLAccountsmapping = _oSapFacade.getGLAccountsMapping();
                DataView _dtViewMapping = _dtGLAccountsmapping.DefaultView;

                foreach (DataRow _row in _dt.Rows)
                {
                    if (_oFolioTransactionFacade.RefNoIfExist("OR", "SAP# " + _row["PaymentNum"].ToString()))
                    {
                        continue;
                    }
                    loFolioTransaction.AccountID = _oFolio.CompanyID;
                    loFolioTransaction.HotelID = GlobalVariables.gHotelId;
                    loFolioTransaction.TransactionDate = DateTime.Now;
                    loFolioTransaction.FolioID = pEventID;
                    loFolioTransaction.SubFolio = "A";

                    loFolioTransaction.TransactionDate = DateTime.Now;
                    loFolioTransaction.PostingDate = DateTime.Now;
                   
                    if (double.Parse(_row["CreditSum"].ToString())>0)
                    {
                        loFolioTransaction.TransactionCode = "2100";
                    }
                    else if (double.Parse(_row["TrsfrSum"].ToString())>0)
                    {
                        loFolioTransaction.TransactionCode = "2200";
                    }
                    else if (double.Parse(_row["CheckSum"].ToString()) > 0)
                    {
                        loFolioTransaction.TransactionCode = "2200";
                    }
                    else
                    {
                        loFolioTransaction.TransactionCode = "2000";
                    }

                    //_dtViewMapping.RowFilter = "GLAccountCode ="+;
                    ///loFolioTransaction.TransactionCode = _dtViewMapping.ToTable().Rows[0]["TransactionCode"].ToString();
                    //Kevin Oliveros
                    

                    loFolioTransaction.SubAccount = "";
                    loFolioTransaction.ReferenceNo = "SAP# "+_row["PaymentNum"].ToString();

                    loFolioTransaction.TransactionSource = "OR";
                    loFolioTransaction.Memo = "PAYMENT FROM SAP "+DateTime.Now; // _memo + " " + cboPaymentSubAccount.Text + _additionalMemo;
                    loFolioTransaction.AcctSide = "CREDIT";
                    loFolioTransaction.CurrencyCode = "PHP";
                    loFolioTransaction.ConversionRate = 1;
                    loFolioTransaction.CurrencyAmount = decimal.Parse(_row["DocTotal"].ToString()) ;//_amount;
                    loFolioTransaction.BaseAmount = decimal.Parse(_row["DocTotal"].ToString());//_amount;
                    loFolioTransaction.GrossAmount = decimal.Parse(_row["DocTotal"].ToString());//_amount;
                    loFolioTransaction.Discount = 0;

                    loFolioTransaction.ServiceCharge = 0;
                    loFolioTransaction.ServiceChargeInclusive = 0;
                    loFolioTransaction.GovernmentTax = 0;
                    loFolioTransaction.GovernmentTaxInclusive = 0;
                    loFolioTransaction.LocalTax = 0;
                    loFolioTransaction.LocalTaxInclusive = 0;

                    loFolioTransaction.NetBaseAmount = decimal.Parse(_row["DocTotal"].ToString());//_amount;
                    loFolioTransaction.NetAmount = decimal.Parse(_row["DocTotal"].ToString());//_amount;
                    loFolioTransaction.CreditCardNo = ""; //_row[""];//this.txtPayment_CardNo.Text;
                    loFolioTransaction.ChequeNo = "";// _row["CheckAcct"].ToString(); //this.txtPayment_Cheque.Text;
                    loFolioTransaction.AccountName = "";//_row[""];//this.txtPayment_Account.Text;
                    loFolioTransaction.BankName = "";//_row[""]; //this.txtPayment_Bank.Text;
                    loFolioTransaction.ChequeDate = string.Format("{0:yyyy-MM-dd}",DateTime.Parse(_row["PaymentDate"].ToString()));//string.Format("{0:yyyy-MM-dd}", this.dtpPayment_Date.Value);
                    loFolioTransaction.FOCGrantedBy = ""; //this.txtGrantedBy.Text;
                    loFolioTransaction.CreditCardType = "";//this.txtCardType.Text;
                    loFolioTransaction.ApprovalSlip = "";//this.txtCardApproval.Text;
                    loFolioTransaction.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(_row["PaymentDate"].ToString()));//string.Format("{0:yyyy-MM-dd}", this.dtpCardExpires.Value);

                    loFolioTransaction.RouteSequence = "";
                    loFolioTransaction.SourceFolio = "";
                    loFolioTransaction.SourceSubFolio = "";
                    loFolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
                    loFolioTransaction.ShiftCode = GlobalVariables.gShiftCode.ToString();
                    loFolioTransaction.CreatedBy = GlobalVariables.gLoggedOnUser;

                    loFolioTransaction.AuditFlag = "1";
                    
                    //for adjustments
                    loFolioTransaction.AdjustmentFlag = "0";
                    //loFolioTransation.AcctSide
                    MySqlTransaction myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
                    loFolioTransactionFacade.InsertFolioTransaction(loFolioTransaction, ref myTransaction);

                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured during getting payments. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        GLMapping lFrmGLMapping;
        private void btnGLAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                lFrmGLMapping = new GLMapping();
                lFrmGLMapping.Show();
            }
            catch
            {

            }
        }
      
    }
}