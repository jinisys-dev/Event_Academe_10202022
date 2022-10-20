using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.DataAccessLayer;


namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class CityLedgerDetailsUI : Form
    {
        public CityLedgerDetailsUI()
        {
            InitializeComponent();
        }

        private double total = 0;
        private ReportDAO oReportDAO;
        private DataTable dtTableCityLedgerSummary;
        public CityLedgerDetailsUI(string CompanyId, string companyName)
        {
            InitializeComponent();

            this.Text = "City Ledger Details [ " + companyName + " ]";
            this.lblCompanyId.Text = CompanyId;
            this.lblCompanyName.Text = companyName;

            total = 0;
            oReportDAO = new ReportDAO();
            dtTableCityLedgerSummary = new DataTable();
            dtTableCityLedgerSummary = oReportDAO.getCityLedger();

            foreach(DataRow dRow in dtTableCityLedgerSummary.Rows)
            {
                if (dRow["CompanyId"].ToString() == CompanyId )
                {
                    if (double.Parse( dRow["Debit"].ToString()) > 0)
                    {
                        ListViewItem lvwItem = new ListViewItem(dRow["refFolio"].ToString());
                        lvwItem.SubItems.Add(dRow["subFolio"].ToString());
                        lvwItem.SubItems.Add(dRow["GuestName"].ToString());
                        lvwItem.SubItems.Add(string.Format("{0:#,##0.00}",double.Parse( dRow["Debit"].ToString() )));

                        total += double.Parse(dRow["Debit"].ToString());

                        this.lvwCityLedgerSummary.Items.Add(lvwItem);
                    }
                }
            }

            this.lblTotal.Text = string.Format("{0:#,##0.00}", total);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}