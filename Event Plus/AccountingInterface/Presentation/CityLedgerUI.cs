using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using C1.Common;
using MySql.Data.MySqlClient;
using System.Xml;
using AdvancedDataGridView;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.BusinessLayer;

using Jinisys.Hotel.AccountingInterface.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class CityLedgerUI : Form
    {
        public CityLedgerUI()
        {
            InitializeComponent();
        }

        private DataSet ldsCityLedger = null;
        private DataGridViewImageColumn lImgAttachmentColumn = new DataGridViewImageColumn();
        private CityLedgerFacade loCityLedgerFacade = null;
		ReportViewer loReportViewerUI = null;
		ReportFacade loReportFacade = null;

        private void CityLedgerUI_Load(object sender, EventArgs e)
        {
			loCityLedgerFacade = new CityLedgerFacade();

            lImgAttachmentColumn.DefaultCellStyle.NullValue = null;

            // load image strip
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Magenta;
            this.imageStrip.ImageSize = new Size(16, 16);
            this.imageStrip.Images.AddStrip(Properties.Resources.newGroupPostIconStrip);

            tgvCityLedger.ImageList = imageStrip;

            // attachment header cell
            this.lImgAttachmentColumn.HeaderCell = new AttachmentColumnHeader(imageStrip.Images[2]);

            getData();

        }

        private void getData()
        {
            BindingSource _bs = new BindingSource();
            ldsCityLedger = loCityLedgerFacade.populateCityLedgerDataset();

            populateGrid();
        }

		private void populateGrid()
		{
            tgvCityLedger.Nodes.Clear();
			DataRow[] _childRows;
			foreach (DataRow _row in ldsCityLedger.Tables[0].Rows)
			{
				Font _boldFont = new Font(tgvCityLedger.DefaultCellStyle.Font, FontStyle.Bold);

				TreeGridNode _treenode = this.tgvCityLedger.Nodes.Add(_row["AcctId"].ToString(),
																	  _row["AccountName"].ToString(),
																	  _row["Debit"],
																	  _row["Credit"],
																	  _row["Balance"]
																	  );
				_treenode.ImageIndex = 0;
				_treenode.DefaultCellStyle.Font = _boldFont;

				_childRows = _row.GetChildRows(ldsCityLedger.Relations["CityLedgerSummaryDetals"]);

				TreeGridNode _chilnode;
				if (_childRows.GetLength(0) > 0)
				{

					DataGridViewCellStyle _dtgStyle = new DataGridViewCellStyle();

					_dtgStyle.ForeColor = Color.Red;
					_dtgStyle.BackColor = Color.Gainsboro;
					_dtgStyle.Font = new Font("Arial", 8, FontStyle.Bold);

					_chilnode = _treenode.Nodes.Add("Check Out Date", "Ref Folio", "Debit", "Credit", "Sub-Folio");
					_chilnode.Cells[0].Style = _dtgStyle;
					_chilnode.Cells[1].Style = _dtgStyle;
					_chilnode.Cells[2].Style = _dtgStyle;
					_chilnode.Cells[3].Style = _dtgStyle;
					_chilnode.Cells[4].Style = _dtgStyle;

				}

				double _totalDebit = 0;

				foreach (DataRow _childRow in _childRows)
				{
					_totalDebit += double.Parse(_childRow["debit"].ToString());
					_chilnode = _treenode.Nodes.Add(string.Format("{0:MM/dd/yyyy}", DateTime.Parse(_childRow["date"].ToString())) + "(" + _childRow["Name"].ToString() + ")", _childRow["reffolio"].ToString(), _childRow["debit"], _childRow["credit"], _childRow["subfolio"]);

					DataGridViewCellStyle _dtgStyle = new DataGridViewCellStyle();
					_dtgStyle.Format = "#,##0.00";
					_dtgStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					_treenode.Cells[2].Style = _dtgStyle;
					_treenode.Cells[3].Style = _dtgStyle;

					DataGridViewCellStyle style1 = new DataGridViewCellStyle();
					style1.Format = "MM/dd/yyyy";
					_treenode.Cells[1].Style = style1;

					_chilnode.ImageIndex = 1;

				}
				_childRows = _row.GetChildRows(ldsCityLedger.Relations["CityLedgerPayments"]);

				double _totalCredit = 0;
				foreach (DataRow _childRow in _childRows)
				{
					_totalCredit += double.Parse(_childRow["credit"].ToString());
                    //orig>> _chilnode = _treenode.Nodes.Add(string.Format("{0:MM/dd/yyyy}", DateTime.Parse(_childRow["date"].ToString())) + "(" + _childRow["Name"].ToString() + ")", _childRow["acctid"].ToString(), _childRow["debit"].ToString(), _childRow["credit"].ToString(), null);
                    _chilnode = _treenode.Nodes.Add(string.Format("{0:MM/dd/yyyy}", DateTime.Parse(_childRow["date"].ToString())) + "(" + _childRow["Name"].ToString() + ")", "Ref.#: " + _childRow["refno"].ToString() + " [" + _childRow["memo"].ToString() + "]", _childRow["debit"].ToString(), _childRow["credit"].ToString(), null);

					DataGridViewCellStyle _dtgStyle = new DataGridViewCellStyle();
					_dtgStyle.Format = "#,##0.00";
					_dtgStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					_chilnode.Cells[2].Style = _dtgStyle;
					_chilnode.Cells[3].Style = _dtgStyle;

					_chilnode.ImageIndex = 1;

				}


				TreeGridNode TotalNode = _treenode.Nodes.Add("------------------------------------------", "Total", string.Format("{0:#,###,###,##0.00}", _totalDebit), string.Format("{0:#,###,###,##0.00}", _totalCredit), null);


				TreeGridNode LineNode = _treenode.Nodes.Add("--------------------", "---------", "---------", "---------", "---------");

			}

		}

        internal class AttachmentColumnHeader : DataGridViewColumnHeaderCell
        {
            public Image _image;
            public AttachmentColumnHeader(Image img)
                : base()
            {
                this._image = img;
            }
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                graphics.DrawImage(_image, cellBounds.X + 4, cellBounds.Y + 2);
            }
            protected override object GetValue(int rowIndex)
            {
                return null;
            }
        }

        private void tgvCityLedger_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string _folioId = this.tgvCityLedger.SelectedRows[0].Cells[1].Value.ToString();
                string _companyId = this.tgvCityLedger.SelectedRows[0].Cells[0].Value.ToString();

                if (_folioId.StartsWith("F-"))
                {
                    this.MdiParent.Cursor = Cursors.WaitCursor;

                    loReportViewerUI = new ReportViewer();
                    loReportFacade = new ReportFacade();

                    loReportViewerUI.rptViewer.ReportSource = loReportFacade.getIndividualGuestBill(_folioId, "ALL");
                    loReportViewerUI.MdiParent = this.MdiParent;
                    loReportViewerUI.Show();

                }
                else if (_companyId.StartsWith("G-"))
                { 
                    string _companyName = this.tgvCityLedger.SelectedRows[0].Cells[1].Value.ToString();

                    CityLedgerDetailsUI oCityLedgerDetailsUI = new CityLedgerDetailsUI(_companyId, _companyName, ldsCityLedger);
                    oCityLedgerDetailsUI.MdiParent = this.MdiParent;
                    oCityLedgerDetailsUI.Show();

                }

            }
            catch// (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewCityLederEntryUI oNewCityLedgerUI = new NewCityLederEntryUI();
            oNewCityLedgerUI.MdiParent = this.MdiParent;
            oNewCityLedgerUI.Show();

            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            tgvCityLedger_DoubleClick(sender, e);
        }

        private void btnCloseAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string _accountName = "";
                string _accountId = "";
                double _balance = 0;

                _accountId = this.tgvCityLedger.SelectedRows[0].Cells[0].Value.ToString();
                _accountName = this.tgvCityLedger.SelectedRows[0].Cells[1].Value.ToString();
                _balance = double.Parse(this.tgvCityLedger.SelectedRows[0].Cells[4].Value.ToString());

                if (_balance > 0)
                {
                    MessageBox.Show("You cannot close an account that has still balance.\r\nPlease settle balances first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_accountId.ToUpper().StartsWith("I-") || _accountId.ToUpper().StartsWith("G-"))
                {
                    if (MessageBox.Show("Are you sure you want to close account " + _accountName.ToUpper() + " ? ", "Close Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CityLedgerFacade oCityLedgerFacade = new CityLedgerFacade();
                        if (oCityLedgerFacade.closeAccount(_accountId) )
                        {
                            MessageBox.Show("Transaction successful.", "Close Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //this.Close();
                            CityLedgerUI_Load(this, new EventArgs());
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                
            }
            catch// (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInsertPayment_Click(object sender, EventArgs e)
        {
            try
            {
                string _accountId = "";

                _accountId = this.tgvCityLedger.SelectedRows[0].Cells[0].Value.ToString();

                if (_accountId.StartsWith("G-") || _accountId.StartsWith("I-"))
                {
                    string companyId = this.tgvCityLedger.SelectedRows[0].Cells[1].Value.ToString();
                    double balance = double.Parse(this.tgvCityLedger.SelectedRows[0].Cells[4].Value.ToString());

                    CityLedgerPaymentUI oCityLedgerPaymentUI = new CityLedgerPaymentUI(_accountId, companyId, balance);
                    oCityLedgerPaymentUI.MdiParent = this.MdiParent;
                    oCityLedgerPaymentUI.Show();

                    this.Close();
                }
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.ldsCityLedger != null)
            {
                this.MdiParent.Cursor = Cursors.WaitCursor;

                loReportViewerUI = new ReportViewer();
                CityLedgerReport oCityLedgerReport = new CityLedgerReport();
                

                //cityLedgerReport.SetDataSource(dsr.Tables[0]);
                oCityLedgerReport.Database.Tables[0].SetDataSource(ldsCityLedger.Tables[0]);
                oCityLedgerReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

                object _date = (object)string.Format("{0:ddd. MMM dd, yyyy}", DateTime.Now);
                oCityLedgerReport.SetParameterValue(0, _date);

                loReportViewerUI.rptViewer.ReportSource = oCityLedgerReport;
                loReportViewerUI.MdiParent = this.MdiParent;
                loReportViewerUI.Show();

                this.Close();
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();
            }
        }

        private void searchItem()
        {
            try
            {
                
                for (int i = this.tgvCityLedger.SelectedRows[0].Index; i <= this.tgvCityLedger.Rows.Count - 1; i++)
                {
                    string _compName = this.tgvCityLedger.Nodes[i].Cells[1].Value.ToString().ToUpper();

                    if (_compName.Contains(this.txtSearch.Text.ToUpper()))
                    {
                        this.tgvCityLedger.SelectedRows[0].Selected = false;
                        this.tgvCityLedger.Nodes[i].Selected = true;
                        //found = true;
                        return;
                    }
                }
            }
            catch// (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchItem();
        }

        private void btnPrintSOA_Click(object sender, EventArgs e)
        {
            string _folioId = this.tgvCityLedger.SelectedRows[0].Cells[1].Value.ToString();
            ReportFacade _oReportFacade = new ReportFacade();
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.rptViewer.ReportSource = _oReportFacade.getStatementOfAccount(_folioId);
            rptViewer.MdiParent = this.MdiParent;
            rptViewer.Show();
        }

    }
}