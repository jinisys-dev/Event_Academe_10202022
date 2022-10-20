using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Cashier.BusinessLayer;

namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class CityLedgerUI : Form
    {
        public CityLedgerUI()
        {
            InitializeComponent();
        }

        
        private ReportFacade oReportFacade;
        private SalesForecastFacade oSalesForeCastFacade;
        private double totalDebits = 0;
        private double totalCredits = 0;
        private void CityLedgerUI_Load(object sender, EventArgs e)
        {
            oReportFacade = new ReportFacade();
            oSalesForeCastFacade = new SalesForecastFacade();

            DataTable dtCityLedgerSummary = new DataTable();
            dtCityLedgerSummary = oSalesForeCastFacade.getCityLedgerSummary();

            totalDebits = 0;
            totalCredits = 0;
            foreach (DataRow dRow in dtCityLedgerSummary.Rows)
            {
                ListViewItem lvwItem = new ListViewItem(dRow["CompanyId"].ToString());
                lvwItem.SubItems.Add(dRow["CompanyName"].ToString());
                lvwItem.SubItems.Add(string.Format("{0:#,##0.00}",double.Parse(dRow["Debit"].ToString())));
                lvwItem.SubItems.Add(string.Format("{0:#,##0.00}", double.Parse(dRow["Credit"].ToString())));

                totalDebits += double.Parse(dRow["Debit"].ToString());
                totalCredits += double.Parse(dRow["Credit"].ToString());

                lvwItem.SubItems.Add(string.Format("{0:#,##0.00}", double.Parse(dRow["Debit"].ToString()) - double.Parse(dRow["Credit"].ToString())));

                this.lvwCityLedgerSummary.Items.Add(lvwItem);
            }

            this.lblTotalCredits.Text = string.Format( "{0:#,##0.00}", totalCredits );
            this.lblTotalDebits.Text = string.Format("{0:#,##0.00}", totalDebits);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string compId = this.lvwCityLedgerSummary.SelectedItems[0].Text;
                string compName = this.lvwCityLedgerSummary.SelectedItems[0].SubItems[1].Text;

                CityLedgerDetailsUI oCityLedgerDetailsUI = new CityLedgerDetailsUI(compId,compName);
                oCityLedgerDetailsUI.MdiParent = this.MdiParent;
                oCityLedgerDetailsUI.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string compId = this.lvwCityLedgerSummary.SelectedItems[0].Text;
            string compName = this.lvwCityLedgerSummary.SelectedItems[0].SubItems[1].Text;
            double balance = Double.Parse( this.lvwCityLedgerSummary.SelectedItems[0].SubItems[2].Text );

            CityLedgerPaymentUI oCityLedgerPaymentUI = new CityLedgerPaymentUI(compId,compName,balance);
            oCityLedgerPaymentUI.MdiParent = this.MdiParent;
            oCityLedgerPaymentUI.Show();

            this.Close();
        }


    }
}