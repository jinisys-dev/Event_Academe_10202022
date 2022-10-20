using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Cashier.BusinessLayer;

namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class CityLedgerPaymentUI : Form
    {
        public CityLedgerPaymentUI()
        {
            InitializeComponent();
        }

        public CityLedgerPaymentUI(string a_CompanyId, string a_CompanyName, double a_RemainingBalance)
        {
            InitializeComponent();

            this.lblCompanyId.Text = a_CompanyId;
            this.lblCompanyName.Text = a_CompanyName;
            this.lblBalance.Text = string.Format("{0:0,##0.00}",a_RemainingBalance);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SalesForecastFacade oSalesForecastFacade;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                oSalesForecastFacade = new SalesForecastFacade();


                string accountid = this.lblCompanyId.Text;
                string date = string.Format("{0:yyyy-MM-dd}",DateTime.Now);
                string refNo = string.Format("{0:MMddyyhhmm}", DateTime.Now);
                double debit = 0;
                double credit = double.Parse(this.txtAmountPaid.Text);
               
                if (oSalesForecastFacade.insertCityLedgerPayment(accountid, date, refNo, debit, credit))
                {
                    MessageBox.Show("Transaction sucessful","City Ledger Payment",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}