using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.AccountingInterface.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class CityLedgerPaymentUI : Form
    {
        public CityLedgerPaymentUI()
        {
            InitializeComponent();
        }

		private double lAmount = 0;
		private double lWithHolding = 0;
		private double lTotalAmount = 0;

        public CityLedgerPaymentUI( string pCompanyId, 
									string pCompanyName, 
									double pRemainingBalance)
        {
            InitializeComponent();

            this.lblCompanyId.Text = pCompanyId;
            this.lblCompanyName.Text = pCompanyName;
			this.lblBalance.Text = pRemainingBalance.ToString("N");

        }

		private CityLedgerFacade loCityLedgerFacade;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                loCityLedgerFacade = new CityLedgerFacade();


                string _accountid = this.lblCompanyId.Text;
                string _date = string.Format("{0:yyyy-MM-dd}",this.dtpPaymentDate.Value);
                string _refNo = this.txtReferenceNo.Text;
                string _memo = this.txtMemo.Text;
                double _amountPaid = double.Parse(this.txtAmount.Text);
                double _withHoldingTax = lWithHolding;
                double _totalAmountPaid = lTotalAmount;


                double _debit = 0;
                double _credit = _totalAmountPaid;
               
				bool _isSucessful = loCityLedgerFacade.insertCityLedgerPayment( _accountid, 
																			    _date, 
																				_refNo, 
																				_memo, 
																				_amountPaid, 
																				_withHoldingTax, 
																				_debit, 
																				_credit
																			   );

                if ( _isSucessful )
                {
                    MessageBox.Show("Transaction sucessful","City Ledger Payment",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    CityLedgerUI _oCityLedger = new CityLedgerUI();
                    _oCityLedger.MdiParent = this.MdiParent;
                    _oCityLedger.Show();

                    this.Close();
                }

            }
            catch (Exception ex)
            {
				string _errMessage = "Transaction failed.\r\nException: " + ex.Message;
				MessageBox.Show(_errMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
             try
            {
                 lAmount = double.Parse(this.txtAmount.Text);

                 lTotalAmount = lAmount + lWithHolding;

				 this.txtTotalAmountPaid.Text = lTotalAmount.ToString("N");
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid payment amount.","Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtAmount.Text = "0.00";

            }

        }

        private void txtWithHoldingtax_TextChanged(object sender, EventArgs e)
        {
             try
            {
                lWithHolding = double.Parse(this.txtWithHoldingtax.Text);

                lTotalAmount = lAmount + lWithHolding;
                this.txtTotalAmountPaid.Text = lTotalAmount.ToString("N");
            }

            catch (Exception)
            {
                MessageBox.Show("Invalid amount for Withholding Tax.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtWithHoldingtax.Text = "0.00";
            }
        }

    }
}