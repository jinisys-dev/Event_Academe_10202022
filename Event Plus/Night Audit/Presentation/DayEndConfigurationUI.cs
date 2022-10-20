
using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.NightAudit.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.NightAudit.Presentation
{
	public class DayEndConfigurationUI : System.Windows.Forms.Form
	{


		#region " Windows Form Designer generated code "

		public DayEndConfigurationUI()
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call

			this.tvwDayEndReports.ExpandAll();
		}

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
		internal System.Windows.Forms.TreeView tvwDayEndReports;
		internal System.Windows.Forms.Button btnOk;
		internal System.Windows.Forms.Button btnClose;
		private GroupBox groupBox1;
		private Label label1;
		private ComboBox cboNightAuditProcessType;
		private Label label2;
		private DateTimePicker dtpScheduleTime;
		private Label label3;
		private ComboBox cboNotify;
		private GroupBox groupBox2;
		internal Button btnDefaults;
		private ComboBox cboTerminalNo;
		private Label label4;
		private Label label5;
		private Label label6;
		internal CheckBox chkBackupDB;
		internal CheckBox chkPrintNytAuditReports;
		internal System.Windows.Forms.CheckBox chkCheckAll;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Inhouse Guests");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Guest Arrivals");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Guest Departures");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Expected Guest Arrival");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Expected Guest Departure");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Cancelled Reservations");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Guest\'s Ledger");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Room Occupancy");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Room Availability");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Room Transfer Report");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Transactions Register");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Voided Transactions");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Sales Report");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Sales Summary");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("City Ledger");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("City Transfer Transactions");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Cashier Transactions per Shift");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Housekeeping Jobs");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Rooming List");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("DAY END CLOSING", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            this.tvwDayEndReports = new System.Windows.Forms.TreeView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNightAuditProcessType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNotify = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPrintNytAuditReports = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkBackupDB = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTerminalNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwDayEndReports
            // 
            this.tvwDayEndReports.CheckBoxes = true;
            this.tvwDayEndReports.Indent = 20;
            this.tvwDayEndReports.ItemHeight = 21;
            this.tvwDayEndReports.Location = new System.Drawing.Point(15, 55);
            this.tvwDayEndReports.Name = "tvwDayEndReports";
            treeNode1.Name = "Node0";
            treeNode1.Tag = "getInHouseGuests";
            treeNode1.Text = "Inhouse Guests";
            treeNode2.Name = "Node0";
            treeNode2.Tag = "getActualArrivalReport";
            treeNode2.Text = "Guest Arrivals";
            treeNode3.Name = "Node1";
            treeNode3.Tag = "getActualDepartureReport";
            treeNode3.Text = "Guest Departures";
            treeNode4.Name = "Node8";
            treeNode4.Tag = "getExpectedArrivalReport";
            treeNode4.Text = "Expected Guest Arrival";
            treeNode5.Name = "Node7";
            treeNode5.Tag = "getExpectedDepartureReport";
            treeNode5.Text = "Expected Guest Departure";
            treeNode6.Name = "Node2";
            treeNode6.Tag = "getCancelledReservation";
            treeNode6.Text = "Cancelled Reservations";
            treeNode7.Name = "Node3";
            treeNode7.Tag = "getGuestLedger";
            treeNode7.Text = "Guest\'s Ledger";
            treeNode8.Name = "Node6";
            treeNode8.Tag = "getRoomOccupancy";
            treeNode8.Text = "Room Occupancy";
            treeNode9.Name = "Node5";
            treeNode9.Tag = "getRoomAvailability";
            treeNode9.Text = "Room Availability";
            treeNode10.Name = "Node9";
            treeNode10.Tag = "getRoomTransferReport";
            treeNode10.Text = "Room Transfer Report";
            treeNode11.Name = "Node10";
            treeNode11.Tag = "getTransactionRegisterReport";
            treeNode11.Text = "Transactions Register";
            treeNode12.Name = "Node6";
            treeNode12.Tag = "getVoidedTransactionsReport";
            treeNode12.Text = "Voided Transactions";
            treeNode13.Name = "Node11";
            treeNode13.Tag = "getSalesReport";
            treeNode13.Text = "Sales Report";
            treeNode14.Name = "Node2";
            treeNode14.Tag = "getSalesSummary";
            treeNode14.Text = "Sales Summary";
            treeNode15.Name = "Node3";
            treeNode15.Tag = "getCityLedger";
            treeNode15.Text = "City Ledger";
            treeNode16.Name = "Node4";
            treeNode16.Tag = "getCityTransferTransactions";
            treeNode16.Text = "City Transfer Transactions";
            treeNode17.Name = "Node5";
            treeNode17.Tag = "getAllCashierShiftTransaction";
            treeNode17.Text = "Cashier Transactions per Shift";
            treeNode18.Name = "Node1";
            treeNode18.Tag = "getHousekeepingJobs";
            treeNode18.Text = "Housekeeping Jobs";
            treeNode19.Name = "Node0";
            treeNode19.Tag = "getRoomingList";
            treeNode19.Text = "Rooming List";
            treeNode20.Name = "";
            treeNode20.Text = "DAY END CLOSING";
            this.tvwDayEndReports.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20});
            this.tvwDayEndReports.Size = new System.Drawing.Size(245, 404);
            this.tvwDayEndReports.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(452, 517);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 31);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "&Save";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(524, 517);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.Location = new System.Drawing.Point(15, 29);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(80, 20);
            this.chkCheckAll.TabIndex = 3;
            this.chkCheckAll.Text = "Check &All";
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvwDayEndReports);
            this.groupBox1.Controls.Add(this.chkCheckAll);
            this.groupBox1.Location = new System.Drawing.Point(309, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 475);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Day-end Reports ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Process Night Audit : ";
            // 
            // cboNightAuditProcessType
            // 
            this.cboNightAuditProcessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNightAuditProcessType.FormattingEnabled = true;
            this.cboNightAuditProcessType.Items.AddRange(new object[] {
            "MANUAL",
            "SCHEDULED"});
            this.cboNightAuditProcessType.Location = new System.Drawing.Point(137, 41);
            this.cboNightAuditProcessType.Name = "cboNightAuditProcessType";
            this.cboNightAuditProcessType.Size = new System.Drawing.Size(129, 22);
            this.cboNightAuditProcessType.TabIndex = 6;
            this.cboNightAuditProcessType.SelectedIndexChanged += new System.EventHandler(this.cboNightAuditProcessType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Schedule Time :";
            // 
            // dtpScheduleTime
            // 
            this.dtpScheduleTime.Enabled = false;
            this.dtpScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpScheduleTime.Location = new System.Drawing.Point(137, 76);
            this.dtpScheduleTime.Name = "dtpScheduleTime";
            this.dtpScheduleTime.ShowUpDown = true;
            this.dtpScheduleTime.Size = new System.Drawing.Size(91, 20);
            this.dtpScheduleTime.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 41);
            this.label3.TabIndex = 9;
            this.label3.Text = "If unprocessed, show warning every :";
            // 
            // cboNotify
            // 
            this.cboNotify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotify.FormattingEnabled = true;
            this.cboNotify.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cboNotify.Location = new System.Drawing.Point(137, 155);
            this.cboNotify.Name = "cboNotify";
            this.cboNotify.Size = new System.Drawing.Size(60, 22);
            this.cboNotify.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPrintNytAuditReports);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkBackupDB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboTerminalNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboNotify);
            this.groupBox2.Controls.Add(this.cboNightAuditProcessType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpScheduleTime);
            this.groupBox2.Location = new System.Drawing.Point(12, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 475);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Schedule";
            // 
            // chkPrintNytAuditReports
            // 
            this.chkPrintNytAuditReports.Location = new System.Drawing.Point(23, 227);
            this.chkPrintNytAuditReports.Name = "chkPrintNytAuditReports";
            this.chkPrintNytAuditReports.Size = new System.Drawing.Size(205, 21);
            this.chkPrintNytAuditReports.TabIndex = 16;
            this.chkPrintNytAuditReports.Text = "Print Night Audit Reports";
            this.chkPrintNytAuditReports.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 43);
            this.label6.TabIndex = 15;
            this.label6.Text = "Check backup database if you want to automatically backup database before and aft" +
                "er night audit process.";
            // 
            // chkBackupDB
            // 
            this.chkBackupDB.Location = new System.Drawing.Point(23, 281);
            this.chkBackupDB.Name = "chkBackupDB";
            this.chkBackupDB.Size = new System.Drawing.Size(114, 21);
            this.chkBackupDB.TabIndex = 14;
            this.chkBackupDB.Text = "Backup Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "second(s)";
            // 
            // cboTerminalNo
            // 
            this.cboTerminalNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerminalNo.FormattingEnabled = true;
            this.cboTerminalNo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cboTerminalNo.Location = new System.Drawing.Point(137, 107);
            this.cboTerminalNo.Name = "cboTerminalNo";
            this.cboTerminalNo.Size = new System.Drawing.Size(60, 22);
            this.cboTerminalNo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Terminal No. :";
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(12, 523);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(94, 31);
            this.btnDefaults.TabIndex = 12;
            this.btnDefaults.Text = "Load Defaults";
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // DayEndConfigurationUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(604, 566);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DayEndConfigurationUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day-End Process Reports";
            this.Load += new System.EventHandler(this.DayEndConfigurationUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		#region " VARIABLES "

		//private ArrayList reportsList;

		#endregion

		#region " CONSTRUCTORS "

		//public DayEndConfigurationUI(ArrayList rptList)
		//{
		//    InitializeComponent();

		//    this.tvwDayEndReports.ExpandAll();
		//    reportsList = rptList;
		//}

		#endregion

		#region " EVENTS "

		private void chkCheckAll_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			bool stat;

			if (chkCheckAll.CheckState == CheckState.Checked)
			{
				stat = true;
			}
			else
			{
				stat = false;
			}

			TreeNode tNod;
			foreach (TreeNode tempLoopVar_tNod in this.tvwDayEndReports.Nodes)
			{
				tNod = tempLoopVar_tNod;
				tNod.Checked = stat;

				TreeNode cNod;
				foreach (TreeNode tempLoopVar_cNod in tNod.Nodes)
				{
					cNod = tempLoopVar_cNod;
					cNod.Checked = stat;

					TreeNode iNod;
					foreach (TreeNode tempLoopVar_iNod in cNod.Nodes)
					{
						iNod = tempLoopVar_iNod;
						iNod.Checked = stat;
					}
				}
			}

		}

		private void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(System.Object sender, System.EventArgs e)
		{

			DialogResult rsp = MessageBox.Show("Action will overwrite existing day-end process configuration.\r\n\r\nWould you like to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rsp == DialogResult.No)
				return;


			DayEndProcessConfig newDayEndProcessConfig = new DayEndProcessConfig();
			assignEntityValues(ref newDayEndProcessConfig);

			AuditFacade _oAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);


			if (_oAuditFacade.saveDayEndProcessConfig(newDayEndProcessConfig))
			{
				MessageBox.Show("Transaction successful.\r\n\r\nDay-end process configuration saved.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}

		}

		public void assignEntityValues(ref DayEndProcessConfig poDayEndProcessConfig)
		{
			poDayEndProcessConfig.ProcessType = this.cboNightAuditProcessType.Text;
			poDayEndProcessConfig.ScheduleTime = string.Format("{0:hh:mm:ss tt}", this.dtpScheduleTime.Value);
			poDayEndProcessConfig.TerminalNo = int.Parse(this.cboTerminalNo.Text);
			poDayEndProcessConfig.NotifySchedule = int.Parse(this.cboNotify.Text);


			string _reportsToGenerate = "";
			foreach (TreeNode tvwHead in this.tvwDayEndReports.Nodes)
			{
				foreach (TreeNode tvwChild in tvwHead.Nodes)
				{
					if (tvwChild.Checked)
					{
						_reportsToGenerate += tvwChild.Tag.ToString() + ", ";
					}
				}
			}
			poDayEndProcessConfig.ReportsToGenerate = _reportsToGenerate;

			poDayEndProcessConfig.BackupDatabase = this.chkBackupDB.Checked ? 1 : 0;
		}

		#endregion

		private void cboNightAuditProcessType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboNightAuditProcessType.SelectedIndex == 1) // for Scheduled Process
			{
				this.dtpScheduleTime.Enabled = true;
			}
			else // for MANUAL
			{
				this.dtpScheduleTime.Enabled = false;
			}
		}

		private void btnDefaults_Click(object sender, EventArgs e)
		{
			this.cboNightAuditProcessType.SelectedIndex = 0;
			this.dtpScheduleTime.Value = DateTime.Parse("2008-08-08 11:59:00 PM");
			this.cboNotify.SelectedIndex = 1;

			this.cboTerminalNo.SelectedIndex = 0;

			this.chkCheckAll.Checked = true;
		}

		private DayEndProcessConfig loDayEndProcessConfig;
		private AuditFacade loAuditFacade;
		private void DayEndConfigurationUI_Load(object sender, EventArgs e)
		{
			loAuditFacade = new AuditFacade(GlobalVariables.gPersistentConnection);
			loDayEndProcessConfig = loAuditFacade.getDayEndProcessConfig();

			this.cboNightAuditProcessType.Text = loDayEndProcessConfig.ProcessType;
			this.dtpScheduleTime.Value = DateTime.Parse(loDayEndProcessConfig.ScheduleTime);
			this.cboTerminalNo.Text = loDayEndProcessConfig.TerminalNo.ToString();

			this.cboNotify.Text = loDayEndProcessConfig.NotifySchedule.ToString();

			string[] _reports = loDayEndProcessConfig.ReportsToGenerate.Split(',');

			foreach (TreeNode tvwHead in this.tvwDayEndReports.Nodes)
			{
				foreach (TreeNode tvwChild in tvwHead.Nodes)
				{
					foreach (string _strReport in _reports)
					{
						string _reportName = _strReport;
						if (tvwChild.Tag.ToString().ToUpper() == _reportName.Trim().ToUpper())
						{
							tvwChild.Checked = true;
						}
					}
				}
			}

			this.chkBackupDB.Checked = loDayEndProcessConfig.BackupDatabase == 1? true : false;
		}


	}
}