using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;

namespace Jinisys.Hotel.Reports.Presentation
{
	public class ReportDateParamUI : System.Windows.Forms.Form
	{

		#region " Windows Form Designer generated code "

		//Form overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnCreateReport;
		internal Button btnClose;
		internal System.Windows.Forms.DateTimePicker dtpDate;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.btnCreateReport = new System.Windows.Forms.Button();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtpDate
			// 
			this.dtpDate.CustomFormat = "dddd, MMMM dd, yyyy";
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDate.Location = new System.Drawing.Point(15, 55);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(232, 20);
			this.dtpDate.TabIndex = 0;
			// 
			// btnCreateReport
			// 
			this.btnCreateReport.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCreateReport.Location = new System.Drawing.Point(78, 112);
			this.btnCreateReport.Name = "btnCreateReport";
			this.btnCreateReport.Size = new System.Drawing.Size(97, 31);
			this.btnCreateReport.TabIndex = 1;
			this.btnCreateReport.Text = "&Create Report";
			this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.btnClose);
			this.GroupBox1.Controls.Add(this.btnCreateReport);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.dtpDate);
			this.GroupBox1.Location = new System.Drawing.Point(12, 11);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(264, 152);
			this.GroupBox1.TabIndex = 2;
			this.GroupBox1.TabStop = false;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(181, 112);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Cl&ose";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(14, 23);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(192, 18);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Choose a date for the Report";
			// 
			// ReportDateParamUI
			// 
			this.AcceptButton = this.btnCreateReport;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(290, 175);
			this.Controls.Add(this.GroupBox1);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ReportDateParamUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Report Date";
			this.Load += new System.EventHandler(this.ReportDateParamUI_Load);
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		string rptToPrint;
		public ReportDateParamUI(string pRptToPrint)
		{
			InitializeComponent();
			rptToPrint = pRptToPrint;
			this.Text = pRptToPrint;


			//if (rptToPrint == "GUEST LEDGER")
			//{
			//    this.dtpDate.CustomFormat = "MMMM dd, yyyy hh:mm:ss tt";
			//}

		}
		private ReportViewer frmReportViewer = new ReportViewer();
		private ReportFacade reportFacade = new ReportFacade();
		//Private GlobalVariables As New GlobalVariables
		private void btnCreateReport_Click(System.Object sender, System.EventArgs e)
		{
            //this.MdiParent.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			frmReportViewer = new ReportViewer();
			reportFacade = new ReportFacade();

			string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);

			switch (rptToPrint.ToUpper())
			{
				case "TRANSACTION REGISTER":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getTransactionRegisterReportDate(pDate);
					break;

				case "CITY LEDGER":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getCityLedgerDate(pDate);
					break;

				case "DAILY TRANSACTIONS":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getDailyTransactionsDate(pDate);
					break;

				case "TRANSACTION SUMMARY":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getSalesSummary(pDate);
					break;

				case "CITY TRANSFER":
					DataTable dtTable = new DataTable();

					CityTransferTransactions cityTransfer = new CityTransferTransactions();
					dtTable = reportFacade.getParamCityTransferTransactions(pDate, pDate);

					cityTransfer.Database.Tables[0].SetDataSource(dtTable);
					cityTransfer.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

					cityTransfer.SetParameterValue(0, string.Format("{0:ddd. MMM. dd, yyyy}", this.dtpDate.Value));

					frmReportViewer.rptViewer.ReportSource = cityTransfer;
					break;

				case "ALL CASHIER TRANSACTIONS":
					DialogResult rsp = MessageBox.Show("Would you like to print all cashier transactions for this shift?\r\n\r\nPress Yes to continue,\r\nNO if you want to show only the Payments.", "Cashier Shift Report", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

					if (rsp == DialogResult.Yes)
					{
						frmReportViewer.rptViewer.ReportSource = reportFacade.getAllCashierShiftTransaction(pDate, "ALL");
					}
					else if (rsp == DialogResult.No)
					{
						frmReportViewer.rptViewer.ReportSource = reportFacade.getAllCashierShiftTransaction(pDate, "PAYMENT");
					}
					else
					{
						return;
					}
					break;

				// guests reports
				case "ACTUAL GUEST ARRIVAL":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getActualArrivalReport(pDate);
					break;

				case "ACTUAL GUEST DEPARTURE":

					frmReportViewer.rptViewer.ReportSource = reportFacade.getActualDepartureReport(pDate);
					break;

				case "EXPECTED GUEST ARRIVAL":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getExpectedArrivalReport(pDate);
					break;

				case "EXPECTED GUEST DEPARTURE":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getExpectedDepartureReport(pDate);
					break;

				case "CANCELLED RESERVATION":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getCancelledReservation(pDate);
					break;

				case "VOIDED TRANSACTIONS":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getVoidedTransactionsReport(pDate);
					break;

				case "OUT OF ORDER ROOMS":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getOutOfOrderRooms(pDate);
					break;

				case "GUEST LEDGER":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getGuestLedger(this.dtpDate.Value);
					break;

				case "HOUSEKEEPING JOB":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getHousekeepingJobs(this.dtpDate.Value);
					break;

				case "ROOM OCCUPANCY":
					frmReportViewer.rptViewer.ReportSource = reportFacade.getRoomOccupancy(this.dtpDate.Value);
					break;
			}

			frmReportViewer.MdiParent = this.MdiParent;
			frmReportViewer.Show();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ReportDateParamUI_Load(object sender, EventArgs e)
		{
			DateTime gAuditDate = DateTime.Parse(GlobalVariables.gAuditDate + " 11:59:59 PM");

			this.dtpDate.Value = gAuditDate;
		}

	}
}
