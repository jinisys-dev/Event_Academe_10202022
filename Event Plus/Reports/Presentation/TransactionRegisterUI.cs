using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Cashier;
using Jinisys.Hotel.BusinessSharedClasses;

using System.Collections;
using System.IO;

using System.Web.UI.WebControls;
using System.Web.UI;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class TransactionRegisterUI : Form
    {
        public TransactionRegisterUI()
        {
            InitializeComponent();
        }

        private ReportFacade oReportFacade;
        private TransactionRegisterReport oTransactionRegister;
        private ReportViewer oReportViewer;
        private DataTable dtTransactions = null;
        private void btnShow_Click(object sender, EventArgs e)
        {
            clearComboBox();

            dtTransactions = new DataTable();
            oReportFacade = new ReportFacade();

            string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpStartDate.Value);
            string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpEndDate.Value);

            dtTransactions = oReportFacade.getParamTransactionRegisterReport(startDate, endDate);

            this.grdTrans.Rows.Count = dtTransactions.Rows.Count + 1;

            int i = 1;
            foreach (DataRow dRow in dtTransactions.Rows)
            {
				this.grdTrans.SetData(i, 0, dRow["PostingDate"].ToString());
				this.grdTrans.SetData(i, 1, dRow["TransactionDate"].ToString());
				this.grdTrans.SetData(i, 2, dRow["RoomId"].ToString());
				this.grdTrans.SetData(i, 3, dRow["GuestName"].ToString());
				this.grdTrans.SetData(i, 4, dRow["FolioId"].ToString());
				this.grdTrans.SetData(i, 5, dRow["TransactionCode"].ToString());
				this.grdTrans.SetData(i, 6, dRow["Memo"].ToString());
				this.grdTrans.SetData(i, 7, dRow["ReferenceNo"].ToString());
				this.grdTrans.SetData(i, 8, dRow["ReferenceType"].ToString());
				this.grdTrans.SetData(i, 9, dRow["Debit"].ToString());
				this.grdTrans.SetData(i, 10, dRow["Credit"].ToString());
				this.grdTrans.SetData(i, 11, dRow["CreatedBy"].ToString());

                if (isDuplicateUser(dRow["CreatedBy"].ToString()) == false)
                {
                    this.cboUsers.Items.Add(dRow["CreatedBy"].ToString());
                }

                i++;
            }            
        }

        private bool isDuplicateUser(string pUser)
        {
            //>>check for duplicate entries in the combo box
            for (int ctr = 0; ctr < cboUsers.Items.Count; ctr++)
            {
                string user = cboUsers.Items[ctr].ToString();
                if (user == pUser)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtTransactions != null)
            {
                this.Cursor = Cursors.WaitCursor;

                string a_Startdate = string.Format("{0:MMM dd, yyyy}", this.dtpStartDate.Value);
                string a_EndDate = string.Format("{0:MMM dd, yyyy}", this.dtpEndDate.Value);

                oReportViewer = new ReportViewer();
                oTransactionRegister = new TransactionRegisterReport();
                //oTransactionRegister.SetDataSource(dtTransactions);
                oTransactionRegister.Database.Tables[0].SetDataSource(dtTransactions);
                oTransactionRegister.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                oTransactionRegister.SetParameterValue(0, "from " + a_Startdate + " to " + a_EndDate);

                oReportViewer.rptViewer.ReportSource = oTransactionRegister;
                oReportViewer.MdiParent = this.MdiParent;
                oReportViewer.Show();

                this.Cursor = Cursors.Default;
                this.Close();
            }

        }

		private void TransactionRegisterUI_Load(object sender, EventArgs e)
		{
			DateTime gAuditDate = DateTime.Parse(GlobalVariables.gAuditDate);

			this.dtpStartDate.Value = gAuditDate;
			this.dtpEndDate.Value = gAuditDate;

		}

		private void TransactionRegisterUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

        private void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.grdTrans.Rows.Count = 1;
                DataView dtView = new DataView();
                dtView = dtTransactions.DefaultView;
                dtView.RowStateFilter = DataViewRowState.OriginalRows;

                switch (cboUsers.Text)
                {
                    case "ALL USERS":
                        dtView.RowFilter = "";
                        break;

                    default:
                        dtView.RowFilter = "createdBy = '" + cboUsers.Text + "'";
                        break;
                }

                this.grdTrans.Rows.Count = dtView.Count + 1;
                int i = 1;
                foreach (DataRowView dRow in dtView)
                {
                    this.grdTrans.SetData(i, 0, dRow["PostingDate"].ToString());
                    this.grdTrans.SetData(i, 1, dRow["TransactionDate"].ToString());
                    this.grdTrans.SetData(i, 2, dRow["RoomId"].ToString());
                    this.grdTrans.SetData(i, 3, dRow["GuestName"].ToString());
                    this.grdTrans.SetData(i, 4, dRow["FolioId"].ToString());
                    this.grdTrans.SetData(i, 5, dRow["TransactionCode"].ToString());
                    this.grdTrans.SetData(i, 6, dRow["Memo"].ToString());
                    this.grdTrans.SetData(i, 7, dRow["ReferenceNo"].ToString());
                    this.grdTrans.SetData(i, 8, dRow["ReferenceType"].ToString());
                    this.grdTrans.SetData(i, 9, dRow["Debit"].ToString());
                    this.grdTrans.SetData(i, 10, dRow["Credit"].ToString());
                    this.grdTrans.SetData(i, 11, dRow["CreatedBy"].ToString());

                    i++;
                }
            }
            catch { }
        }

        private void clearComboBox()
        {
            cboUsers.Items.Clear();
            cboUsers.Items.Add("ALL USERS");
            cboUsers.Text = "ALL USERS";

            grdTrans.Rows.Count = 1;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            clearComboBox();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            clearComboBox();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (this.grdTrans.Rows.Count <= 1)
            {
                return;
            }

            try
            {
                string strFileName = "Transaction Register Report (" + this.dtpStartDate.Text + " to " + this.dtpEndDate.Text + ")";

                sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
                sfdExport.FileName = strFileName;

                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    string filelocation = sfdExport.FileName;

                    DataTable reportTable = new DataTable("Transaction Register Report");

                    //get column names
                    int totalCol = this.dtTransactions.Columns.Count;
                    int colIndex = 0;
                    for (int i = 0; i < totalCol; i++)
                    {
                        string columnName = dtTransactions.Columns[i].ColumnName;
                        DataColumn col = new DataColumn(columnName);
                        colIndex++;

                        reportTable.Columns.Add(col);
                    }

                    //get row values
                    int totalRow = dtTransactions.Rows.Count; ;

                    for (int r = 0; r < totalRow; r++)
                    {
                        DataRow newRow = reportTable.NewRow();
                        int tempTableCol = 0;
                        for (int c = 0; c < totalCol; c++)
                        {
                            //if (grdTrans.GetCellStyleDisplay(r, c).ForeColor == Color.Red)
                            //{
                            //    newRow[tempTableCol] = "-" + this.grdTrans.GetDataDisplay(r, c);
                            //}
                            //else
                            //{
                            //    newRow[tempTableCol] = this.grdTrans.GetDataDisplay(r, c);
                            //}

                            newRow[tempTableCol] = dtTransactions.Rows[r][c].ToString();
                            tempTableCol++;
                        }

                        reportTable.Rows.Add(newRow);
                    }

                    System.Web.UI.WebControls.DataGrid grid = new System.Web.UI.WebControls.DataGrid();
                    grid.HeaderStyle.Font.Bold = true;
                    grid.DataSource = reportTable;

                    grid.DataBind();

                    // render the DataGrid control to a file
                    using (StreamWriter sw = new StreamWriter(filelocation))
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            grid.RenderControl(hw);
                        }
                    }

                    MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}