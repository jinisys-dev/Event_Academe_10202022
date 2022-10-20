using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.AccountingInterface.BusinessLayer;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class NewCityLederEntryUI : Form
    {

        Company loCompany = null;
        CompanyFacade loCompanyFacade = null;

		CityLeger loCityLedger = null;
		CityLedgerFacade loCityLedgerFacade = null;

        public NewCityLederEntryUI()
        {
            InitializeComponent();
            
			loCompany = new Company();
            loCompanyFacade = new CompanyFacade();
            loCompany = loCompanyFacade.getCompanyAccountsData();

            
            foreach(DataRow _dtRow in loCompany.Tables[0].Rows)
            {
                this.cboAccountId.Items.Add(_dtRow["CompanyId"]);    
                this.cboCompanyName.Items.Add(_dtRow["CompanyName"]);    
            }

            if (this.cboAccountId.Items.Count > 0)
            {
                this.cboAccountId.SelectedIndex = this.cboAccountId.Items.Count - 1;
            }

        }

        private void cboAccountId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cboCompanyName.SelectedIndex = cboAccountId.SelectedIndex;
            }
            catch
            { }

        }

        private void cboCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cboAccountId.SelectedIndex = cboCompanyName.SelectedIndex;
            }
            catch
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double _openingBalance = 0;

            try 
            {
                _openingBalance = double.Parse( this.txtOpeningBalance.Text );
            }
            catch (Exception ex)
            {
				string _errMessage = "Transaction failed.\r\nException: " + ex.Message;

				MessageBox.Show(_errMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            loCityLedgerFacade = new CityLedgerFacade();
            loCityLedger = new CityLeger();

            loCityLedger.AcctID = this.cboAccountId.Text;
            loCityLedger.Date = string.Format("{0:yyyy-MM-dd}",DateTime.Now);
            loCityLedger.Refno = "OPENING BALANCE";
            loCityLedger.Debit = _openingBalance;
            loCityLedger.Credit = 0;
            loCityLedger.RefFolio = "OPENING BALANCE";
            loCityLedger.SubFolio = "";

            if (loCityLedgerFacade.insertCityLedger(loCityLedger))
            {
                MessageBox.Show("Transaction successful.", "City Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}