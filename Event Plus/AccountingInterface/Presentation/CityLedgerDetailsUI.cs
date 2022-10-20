using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Jinisys.Hotel.AccountingInterface.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class CityLedgerDetailsUI : Form
    {
        public CityLedgerDetailsUI()
        {
            InitializeComponent();
        }

		private ReportViewer loReportViewerUI;
		private ReportFacade loReportFacade;

        private double lTotalDebit = 0;
        private double lTotalCredit = 0;
        private DataSet lDataSetCompanyData;

        private DataRow[] lRowCityLedgerDetails;
        private DataRow[] lRowCityLedgerPayments;

        
        public CityLedgerDetailsUI( string pCompanyId, 
								    string pCompanyName, 
									DataSet poCompanyData)
        {
            InitializeComponent();

            lDataSetCompanyData = poCompanyData;

            this.Text = "City Ledger Details [ " + pCompanyName + " ]";
            this.lblCompanyId.Text = pCompanyId;
            this.lblCompanyName.Text = pCompanyName;

            DataRow[] _childRows;

            foreach(DataRow _dRow in poCompanyData.Tables[0].Rows)
            {
                if (_dRow["AcctId"].ToString() == pCompanyId)
                {
                    _childRows = _dRow.GetChildRows(poCompanyData.Relations["CityLedgerSummaryDetals"]);
                    this.lRowCityLedgerDetails = (DataRow[])_childRows.Clone();

                    foreach (DataRow childRow in _childRows)
                    {
                        ListViewItem _lvwItem = new ListViewItem(childRow["refFolio"].ToString());
                        _lvwItem.SubItems.Add(childRow["subFolio"].ToString());
                        _lvwItem.SubItems.Add(childRow["Name"].ToString());

						double _debit = 0;
						_debit = double.Parse(childRow["Debit"].ToString());
						lTotalDebit += _debit;

                        _lvwItem.SubItems.Add(_debit.ToString("N"));

                        this.lvwCityLedgerSummary.Items.Add(_lvwItem);

                    }
                    this.lblTotal.Text = lTotalDebit.ToString("N");

                    _childRows = _dRow.GetChildRows(poCompanyData.Relations["CityLedgerPayments"]);
                    lRowCityLedgerPayments = (DataRow[])_childRows.Clone();

                    foreach (DataRow childRow in _childRows)
                    {
                        ListViewItem _lvwItem = new ListViewItem(childRow["Date"].ToString());
                        _lvwItem.SubItems.Add(childRow["refNo"].ToString());
                        _lvwItem.SubItems.Add(childRow["Memo"].ToString());
                        _lvwItem.SubItems.Add("");

						double _credit = 0;
						_credit = double.Parse(childRow["Credit"].ToString());
						lTotalCredit += _credit;

                        _lvwItem.SubItems.Add(_credit.ToString("N"));

						lTotalCredit += _credit;

                        this.lvwCityLedgerSummary.Items.Add(_lvwItem);

                    }
                    this.lblTotalCredit.Text = lTotalCredit.ToString("N");

                }
            }

            

        }

        

        
        private void lvwCityLedgerSummary_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string _folioId = this.lvwCityLedgerSummary.SelectedItems[0].Text;

                this.MdiParent.Cursor = Cursors.WaitCursor;

                loReportViewerUI = new ReportViewer();
                loReportFacade = new ReportFacade();

                loReportViewerUI.rptViewer.ReportSource = loReportFacade.getIndividualGuestBill(_folioId, "ALL");
                loReportViewerUI.MdiParent = this.MdiParent;
                loReportViewerUI.Show();
            }
            catch
            {
                this.MdiParent.Cursor = Cursors.Default;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchItem();
        }


        private void searchItem()
        {
            //bool found = false;
            deselectAll();

            lvwCityLedgerSummary.Focus();

            for (int i = 0; i < this.lvwCityLedgerSummary.Items.Count; i++)
            {
                if (this.lvwCityLedgerSummary.Items[i].SubItems[2].Text.ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    lvwCityLedgerSummary.Items[i].Selected = true;
                    //found = true;
                    return;
                }
            }
        }

        public void deselectAll()
        {
            foreach (ListViewItem _lvwItem in this.lvwCityLedgerSummary.Items)
            {
                _lvwItem.Selected = false;   
            }
        }


        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!(this.lRowCityLedgerDetails == null || this.lRowCityLedgerPayments == null))
            {
               
                DataTable _dtCompanyLedger = new DataTable("CompanyLedger");
                _dtCompanyLedger.Columns.Add("CheckOutDate", System.Type.GetType("System.DateTime"));
                _dtCompanyLedger.Columns.Add("FolioId");
                _dtCompanyLedger.Columns.Add("Name");
                _dtCompanyLedger.Columns.Add("SubFolio");
                _dtCompanyLedger.Columns.Add("ReferenceNo");
                _dtCompanyLedger.Columns.Add("Debit", System.Type.GetType("System.Double") );
                _dtCompanyLedger.Columns.Add("Credit", System.Type.GetType("System.Double"));

                _dtCompanyLedger.Columns.Add("AmountPaid", System.Type.GetType("System.Double"));
                _dtCompanyLedger.Columns.Add("WithHoldingTax", System.Type.GetType("System.Double"));

                
                // for CityLedger Payables
                foreach (DataRow _row in lRowCityLedgerDetails)
                {
                    DataRow _newRow = _dtCompanyLedger.NewRow();
                    _newRow["CheckOutDate"] = DateTime.Parse( _row["Date"].ToString() );
                    _newRow["FolioId"] = _row["refFolio"];
                    _newRow["Name"] = _row["Name"];
                    _newRow["SubFolio"] = _row["SubFolio"];
                    _newRow["ReferenceNo"] = _row["refNo"];
                    _newRow["Debit"] = double.Parse( _row["Debit"].ToString() );
                    _newRow["Credit"] = double.Parse( _row["Credit"].ToString() );

                    _newRow["AmountPaid"] = 0;
                    _newRow["WithHoldingTax"] = 0;


                    _dtCompanyLedger.Rows.Add(_newRow);
                    _dtCompanyLedger.AcceptChanges();
                }

                // for CityLedger Payments
                foreach (DataRow _row in lRowCityLedgerPayments)
                {
                    DataRow _newRow = _dtCompanyLedger.NewRow();

                    _newRow["CheckOutDate"] = DateTime.Parse(_row["Date"].ToString() );
                    _newRow["FolioId"] = _row["Acctid"];
                    _newRow["Name"] = _row["Memo"];
                    _newRow["SubFolio"] = "";
                    _newRow["ReferenceNo"] = _row["refNo"];
                    _newRow["Debit"] = double.Parse( _row["Debit"].ToString() );
                    _newRow["Credit"] = double.Parse( _row["Credit"].ToString() );

                    _newRow["AmountPaid"] = double.Parse( _row["AmountPaid"].ToString() );
                    _newRow["WithHoldingTax"] = double.Parse( _row["WithHoldingTax"].ToString() );


                    _dtCompanyLedger.Rows.Add(_newRow);
                    _dtCompanyLedger.AcceptChanges();
                }

                this.MdiParent.Cursor = Cursors.WaitCursor;

                CompanyLedgerReport _companyLedger = new CompanyLedgerReport();
                //companyLedger.SetDataSource(dtCompanyLedger);

                _companyLedger.Database.Tables[0].SetDataSource(_dtCompanyLedger);
                _companyLedger.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                _companyLedger.SetParameterValue(0, this.lblCompanyId.Text);
                _companyLedger.SetParameterValue(1, this.lblCompanyName.Text);

                ReportViewer _rptViewer = new ReportViewer();
                _rptViewer.rptViewer.ReportSource = _companyLedger;

                _rptViewer.MdiParent = this.MdiParent;
                _rptViewer.Show();

            }
        }
    }
}