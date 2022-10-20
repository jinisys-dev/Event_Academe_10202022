using System.Windows.Forms;
using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Reports.BusinessLayer;
using MySql.Data.MySqlClient;

using System.Reflection;

using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Cashier;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Reservation;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Housekeeping_and_Engineering;

using Jinisys.Hotel.BusinessSharedClasses;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;


namespace Jinisys.Hotel.Reports
{
    namespace Presentation
    {
        public class ReportGeneratorUI : Form
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

            private System.ComponentModel.IContainer components;

            //Required by the Windows Form Designer

            //NOTE: The following procedure is required by the Windows Form Designer
            //It can be modified using the Windows Form Designer.
            //Do not modify it using the code editor.
            internal System.Windows.Forms.TreeView tvwReportGenerator;
            internal System.Windows.Forms.ContextMenu PopUpMenu;
            internal System.Windows.Forms.MenuItem mnuPrint;
            internal System.Windows.Forms.MenuItem mnuPreview;
            internal System.Windows.Forms.MenuItem MenuItem3;
            internal System.Windows.Forms.MenuItem mnuRefresh;
            internal System.Windows.Forms.MenuItem MenuItem5;
            internal System.Windows.Forms.MenuItem mnuClose;
            internal System.Windows.Forms.Button btnPrint;
            internal System.Windows.Forms.Button btnClose;
            internal System.Windows.Forms.RadioButton rdoRange;
            internal System.Windows.Forms.RadioButton rdoMonth;
            internal System.Windows.Forms.RadioButton rdoYear;
            internal System.Windows.Forms.DateTimePicker dtpFrom;
            internal System.Windows.Forms.Label Label1;
            internal System.Windows.Forms.Label Label2;
            internal System.Windows.Forms.DateTimePicker dtpTo;
            internal System.Windows.Forms.ComboBox cboMonth;
            internal System.Windows.Forms.ComboBox cboYear;
            internal System.Windows.Forms.ImageList imgIcons;
            internal System.Windows.Forms.DateTimePicker dtpDate;
            private GroupBox groupBox1;
            private GroupBox groupBox2;
            internal ComboBox cboMonthYear;
            internal RadioButton rdoAll;
            internal TreeView treeView1;
            internal System.Windows.Forms.RadioButton rdoDate;
            [System.Diagnostics.DebuggerStepThrough()]
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Room Occupancy", 3, 2);
                System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Cancelled Reservations", 3, 2);
                System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Room Utilization", 3, 2);
                System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Reservation", 0, 1, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
                System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Actual Guest Arrivals", 3, 2);
                System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Actual Guest Departures", 3, 2);
                System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Expected Guest Arrivals", 3, 2);
                System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Expected Guest Departures", 3, 2);
                System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Front Desk", 0, 1, new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
                System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Cashier Shift Report", 3, 2);
                System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Transaction Register", 3, 2);
                System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Daily Transactions", 3, 2);
                System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Voided Transactions", 3, 2);
                System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("City Transfer Transactions", 3, 2);
                System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Cashier", 0, 1, new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
                System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Out Of Order Rooms", 3, 2);
                System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Housekeeping Jobs per Housekeeper", 3, 2);
                System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Room Status", 3, 2);
                System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Housekeeping / Engineering", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
                System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Sales Summary", 3, 3);
                System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Sales Report", 3, 2);
                System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Sales Executive", 3, 2);
                System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Sales Production", 3, 2);
                System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Driver\'s Commissions", 3, 2);
                System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Marketing & Sales", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24});
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportGeneratorUI));
                System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Room Occupancy", 3, 2);
                System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Cancelled Reservations", 3, 2);
                System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Reservation", 0, 1, new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27});
                System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Actual Guest Arrivals", 3, 2);
                System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Actual Guest Departures", 3, 2);
                System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Expected Guest Arrivals", 3, 2);
                System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Expected Guest Departures", 3, 2);
                System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Front Desk", 0, 1, new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32});
                System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Cashier Shift Report", 3, 2);
                System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Transaction Register", 3, 2);
                System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Daily Transactions", 3, 2);
                System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Voided Transactions", 3, 2);
                System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("City Transfer Transactions", 3, 2);
                System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Cashier", 0, 1, new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38});
                System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Individual Folios", 3, 2);
                System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Company Folios", 3, 2);
                System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Audit", new System.Windows.Forms.TreeNode[] {
            treeNode40,
            treeNode41});
                System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Out Of Order Rooms", 3, 2);
                System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Housekeeping Jobs per Housekeeper", 3, 2);
                System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Room Status", 3, 2);
                System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Housekeeping / Engineering", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode44,
            treeNode45});
                System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Sales Summary", 3, 3);
                System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Sales Report", 3, 2);
                System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Sales Executive", 3, 2);
                System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Sales Production", 3, 2);
                System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Driver\'s Commissions", 3, 2);
                System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Regular Customers", 3, 2);
                System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Corporate Accounts", 3, 2);
                System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Room Block", 3, 2);
                System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Agent\'s Sales", 3, 2);
                System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Marketing & Sales", new System.Windows.Forms.TreeNode[] {
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55});
                this.tvwReportGenerator = new System.Windows.Forms.TreeView();
                this.imgIcons = new System.Windows.Forms.ImageList(this.components);
                this.btnPrint = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.PopUpMenu = new System.Windows.Forms.ContextMenu();
                this.mnuPrint = new System.Windows.Forms.MenuItem();
                this.mnuPreview = new System.Windows.Forms.MenuItem();
                this.MenuItem3 = new System.Windows.Forms.MenuItem();
                this.mnuRefresh = new System.Windows.Forms.MenuItem();
                this.MenuItem5 = new System.Windows.Forms.MenuItem();
                this.mnuClose = new System.Windows.Forms.MenuItem();
                this.cboYear = new System.Windows.Forms.ComboBox();
                this.cboMonth = new System.Windows.Forms.ComboBox();
                this.rdoYear = new System.Windows.Forms.RadioButton();
                this.rdoMonth = new System.Windows.Forms.RadioButton();
                this.dtpDate = new System.Windows.Forms.DateTimePicker();
                this.rdoDate = new System.Windows.Forms.RadioButton();
                this.Label1 = new System.Windows.Forms.Label();
                this.dtpTo = new System.Windows.Forms.DateTimePicker();
                this.Label2 = new System.Windows.Forms.Label();
                this.rdoRange = new System.Windows.Forms.RadioButton();
                this.dtpFrom = new System.Windows.Forms.DateTimePicker();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.treeView1 = new System.Windows.Forms.TreeView();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.rdoAll = new System.Windows.Forms.RadioButton();
                this.cboMonthYear = new System.Windows.Forms.ComboBox();
                this.groupBox1.SuspendLayout();
                this.groupBox2.SuspendLayout();
                this.SuspendLayout();
                // 
                // tvwReportGenerator
                // 
                this.tvwReportGenerator.BackColor = System.Drawing.Color.White;
                this.tvwReportGenerator.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.tvwReportGenerator.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.tvwReportGenerator.ImageIndex = 0;
                this.tvwReportGenerator.ImageList = this.imgIcons;
                this.tvwReportGenerator.ImeMode = System.Windows.Forms.ImeMode.Alpha;
                this.tvwReportGenerator.Indent = 25;
                this.tvwReportGenerator.ItemHeight = 20;
                this.tvwReportGenerator.Location = new System.Drawing.Point(10, 17);
                this.tvwReportGenerator.Name = "tvwReportGenerator";
                treeNode1.ImageIndex = 3;
                treeNode1.Name = "";
                treeNode1.SelectedImageIndex = 2;
                treeNode1.Text = "Room Occupancy";
                treeNode2.ImageIndex = 3;
                treeNode2.Name = "";
                treeNode2.SelectedImageIndex = 2;
                treeNode2.Text = "Cancelled Reservations";
                treeNode3.ImageIndex = 3;
                treeNode3.Name = "";
                treeNode3.SelectedImageIndex = 2;
                treeNode3.Text = "Room Utilization";
                treeNode4.ImageIndex = 0;
                treeNode4.Name = "";
                treeNode4.SelectedImageIndex = 1;
                treeNode4.Text = "Reservation";
                treeNode5.ImageIndex = 3;
                treeNode5.Name = "";
                treeNode5.SelectedImageIndex = 2;
                treeNode5.Text = "Actual Guest Arrivals";
                treeNode6.ImageIndex = 3;
                treeNode6.Name = "";
                treeNode6.SelectedImageIndex = 2;
                treeNode6.Text = "Actual Guest Departures";
                treeNode7.ImageIndex = 3;
                treeNode7.Name = "";
                treeNode7.SelectedImageIndex = 2;
                treeNode7.Text = "Expected Guest Arrivals";
                treeNode8.ImageIndex = 3;
                treeNode8.Name = "";
                treeNode8.SelectedImageIndex = 2;
                treeNode8.Text = "Expected Guest Departures";
                treeNode9.ImageIndex = 0;
                treeNode9.Name = "";
                treeNode9.SelectedImageIndex = 1;
                treeNode9.Text = "Front Desk";
                treeNode10.ImageIndex = 3;
                treeNode10.Name = "Node0";
                treeNode10.SelectedImageIndex = 2;
                treeNode10.Text = "Cashier Shift Report";
                treeNode11.ImageIndex = 3;
                treeNode11.Name = "";
                treeNode11.SelectedImageIndex = 2;
                treeNode11.Text = "Transaction Register";
                treeNode12.ImageIndex = 3;
                treeNode12.Name = "";
                treeNode12.SelectedImageIndex = 2;
                treeNode12.Text = "Daily Transactions";
                treeNode13.ImageIndex = 3;
                treeNode13.Name = "Node1";
                treeNode13.SelectedImageIndex = 2;
                treeNode13.Text = "Voided Transactions";
                treeNode14.ImageIndex = 3;
                treeNode14.Name = "CityTransferTransactions";
                treeNode14.SelectedImageIndex = 2;
                treeNode14.Text = "City Transfer Transactions";
                treeNode15.ImageIndex = 0;
                treeNode15.Name = "";
                treeNode15.SelectedImageIndex = 1;
                treeNode15.Text = "Cashier";
                treeNode16.ImageIndex = 3;
                treeNode16.Name = "";
                treeNode16.SelectedImageIndex = 2;
                treeNode16.Text = "Out Of Order Rooms";
                treeNode17.ImageIndex = 3;
                treeNode17.Name = "";
                treeNode17.SelectedImageIndex = 2;
                treeNode17.Text = "Housekeeping Jobs per Housekeeper";
                treeNode18.ImageIndex = 3;
                treeNode18.Name = "";
                treeNode18.SelectedImageIndex = 2;
                treeNode18.Text = "Room Status";
                treeNode19.Name = "";
                treeNode19.Text = "Housekeeping / Engineering";
                treeNode20.ImageIndex = 3;
                treeNode20.Name = "Node0";
                treeNode20.SelectedImageIndex = 3;
                treeNode20.Text = "Sales Summary";
                treeNode21.ImageIndex = 3;
                treeNode21.Name = "";
                treeNode21.SelectedImageIndex = 2;
                treeNode21.Text = "Sales Report";
                treeNode22.ImageIndex = 3;
                treeNode22.Name = "";
                treeNode22.SelectedImageIndex = 2;
                treeNode22.Text = "Sales Executive";
                treeNode23.ImageIndex = 3;
                treeNode23.Name = "";
                treeNode23.SelectedImageIndex = 2;
                treeNode23.Text = "Sales Production";
                treeNode24.ImageIndex = 3;
                treeNode24.Name = "";
                treeNode24.SelectedImageIndex = 2;
                treeNode24.Text = "Driver\'s Commissions";
                treeNode25.Name = "";
                treeNode25.Text = "Marketing & Sales";
                this.tvwReportGenerator.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode9,
            treeNode15,
            treeNode19,
            treeNode25});
                this.tvwReportGenerator.SelectedImageIndex = 1;
                this.tvwReportGenerator.Size = new System.Drawing.Size(272, 437);
                this.tvwReportGenerator.TabIndex = 0;
                this.tvwReportGenerator.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwReportGenerator_NodeMouseClick);
                this.tvwReportGenerator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwReportGenerator_MouseDown);
                // 
                // imgIcons
                // 
                this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
                this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
                this.imgIcons.Images.SetKeyName(0, "");
                this.imgIcons.Images.SetKeyName(1, "");
                this.imgIcons.Images.SetKeyName(2, "txt.ico");
                this.imgIcons.Images.SetKeyName(3, "print.ico");
                // 
                // btnPrint
                // 
                this.btnPrint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnPrint.Location = new System.Drawing.Point(189, 416);
                this.btnPrint.Name = "btnPrint";
                this.btnPrint.Size = new System.Drawing.Size(66, 31);
                this.btnPrint.TabIndex = 1;
                this.btnPrint.Text = "&Preview";
                this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
                // 
                // btnClose
                // 
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(263, 416);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 3;
                this.btnClose.Text = "&Close";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // PopUpMenu
                // 
                this.PopUpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPrint,
            this.mnuPreview,
            this.MenuItem3,
            this.mnuRefresh,
            this.MenuItem5,
            this.mnuClose});
                // 
                // mnuPrint
                // 
                this.mnuPrint.DefaultItem = true;
                this.mnuPrint.Index = 0;
                this.mnuPrint.Text = "Print";
                // 
                // mnuPreview
                // 
                this.mnuPreview.Index = 1;
                this.mnuPreview.Text = "Preview";
                // 
                // MenuItem3
                // 
                this.MenuItem3.Index = 2;
                this.MenuItem3.Text = "-";
                // 
                // mnuRefresh
                // 
                this.mnuRefresh.Index = 3;
                this.mnuRefresh.Text = "Collapse All";
                this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
                // 
                // MenuItem5
                // 
                this.MenuItem5.Index = 4;
                this.MenuItem5.Text = "-";
                // 
                // mnuClose
                // 
                this.mnuClose.Index = 5;
                this.mnuClose.Text = "Close";
                // 
                // cboYear
                // 
                this.cboYear.Enabled = false;
                this.cboYear.Items.AddRange(new object[] {
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
                this.cboYear.Location = new System.Drawing.Point(130, 121);
                this.cboYear.Name = "cboYear";
                this.cboYear.Size = new System.Drawing.Size(115, 22);
                this.cboYear.TabIndex = 17;
                // 
                // cboMonth
                // 
                this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboMonth.Enabled = false;
                this.cboMonth.Items.AddRange(new object[] {
            "JANUARY",
            "FEBRUARY",
            "MARCH",
            "APRIL",
            "MAY",
            "JUNE",
            "JULY",
            "AUGUST",
            "SEPTEMBER",
            "OCTOBER",
            "NOVEMBER",
            "DECEMBER"});
                this.cboMonth.Location = new System.Drawing.Point(130, 82);
                this.cboMonth.Name = "cboMonth";
                this.cboMonth.Size = new System.Drawing.Size(115, 22);
                this.cboMonth.TabIndex = 16;
                // 
                // rdoYear
                // 
                this.rdoYear.Location = new System.Drawing.Point(28, 123);
                this.rdoYear.Name = "rdoYear";
                this.rdoYear.Size = new System.Drawing.Size(91, 19);
                this.rdoYear.TabIndex = 10;
                this.rdoYear.Text = "Year";
                this.rdoYear.CheckedChanged += new System.EventHandler(this.rdoYear_CheckedChanged);
                // 
                // rdoMonth
                // 
                this.rdoMonth.Location = new System.Drawing.Point(28, 83);
                this.rdoMonth.Name = "rdoMonth";
                this.rdoMonth.Size = new System.Drawing.Size(91, 19);
                this.rdoMonth.TabIndex = 8;
                this.rdoMonth.Text = "Month Of ";
                this.rdoMonth.CheckedChanged += new System.EventHandler(this.rdoMonth_CheckedChanged);
                // 
                // dtpDate
                // 
                this.dtpDate.CustomFormat = "dddd MMMM dd, yyyy";
                this.dtpDate.Enabled = false;
                this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpDate.Location = new System.Drawing.Point(130, 41);
                this.dtpDate.Name = "dtpDate";
                this.dtpDate.Size = new System.Drawing.Size(200, 20);
                this.dtpDate.TabIndex = 7;
                // 
                // rdoDate
                // 
                this.rdoDate.Location = new System.Drawing.Point(28, 42);
                this.rdoDate.Name = "rdoDate";
                this.rdoDate.Size = new System.Drawing.Size(59, 19);
                this.rdoDate.TabIndex = 4;
                this.rdoDate.Text = "Date";
                this.rdoDate.CheckedChanged += new System.EventHandler(this.rdoNow_CheckedChanged);
                // 
                // Label1
                // 
                this.Label1.Location = new System.Drawing.Point(80, 198);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(40, 18);
                this.Label1.TabIndex = 13;
                this.Label1.Text = "From";
                this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // dtpTo
                // 
                this.dtpTo.CustomFormat = "dd-MMM-yyyy";
                this.dtpTo.Enabled = false;
                this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpTo.Location = new System.Drawing.Point(130, 230);
                this.dtpTo.Name = "dtpTo";
                this.dtpTo.Size = new System.Drawing.Size(115, 20);
                this.dtpTo.TabIndex = 14;
                // 
                // Label2
                // 
                this.Label2.Location = new System.Drawing.Point(80, 229);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(40, 18);
                this.Label2.TabIndex = 15;
                this.Label2.Text = "To";
                this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // rdoRange
                // 
                this.rdoRange.Location = new System.Drawing.Point(28, 167);
                this.rdoRange.Name = "rdoRange";
                this.rdoRange.Size = new System.Drawing.Size(59, 19);
                this.rdoRange.TabIndex = 5;
                this.rdoRange.Text = "Range";
                this.rdoRange.CheckedChanged += new System.EventHandler(this.rdoRange_CheckedChanged);
                // 
                // dtpFrom
                // 
                this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
                this.dtpFrom.Enabled = false;
                this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpFrom.Location = new System.Drawing.Point(130, 199);
                this.dtpFrom.Name = "dtpFrom";
                this.dtpFrom.Size = new System.Drawing.Size(115, 20);
                this.dtpFrom.TabIndex = 12;
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.tvwReportGenerator);
                this.groupBox1.Controls.Add(this.treeView1);
                this.groupBox1.Location = new System.Drawing.Point(14, 12);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(292, 469);
                this.groupBox1.TabIndex = 7;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "Report Types";
                // 
                // treeView1
                // 
                this.treeView1.BackColor = System.Drawing.Color.White;
                this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.treeView1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.treeView1.ImageIndex = 0;
                this.treeView1.ImageList = this.imgIcons;
                this.treeView1.ImeMode = System.Windows.Forms.ImeMode.Alpha;
                this.treeView1.Indent = 25;
                this.treeView1.ItemHeight = 20;
                this.treeView1.Location = new System.Drawing.Point(10, 16);
                this.treeView1.Name = "treeView1";
                treeNode26.ImageIndex = 3;
                treeNode26.Name = "";
                treeNode26.SelectedImageIndex = 2;
                treeNode26.Text = "Room Occupancy";
                treeNode27.ImageIndex = 3;
                treeNode27.Name = "";
                treeNode27.SelectedImageIndex = 2;
                treeNode27.Text = "Cancelled Reservations";
                treeNode28.ImageIndex = 0;
                treeNode28.Name = "";
                treeNode28.SelectedImageIndex = 1;
                treeNode28.Text = "Reservation";
                treeNode29.ImageIndex = 3;
                treeNode29.Name = "";
                treeNode29.SelectedImageIndex = 2;
                treeNode29.Text = "Actual Guest Arrivals";
                treeNode30.ImageIndex = 3;
                treeNode30.Name = "";
                treeNode30.SelectedImageIndex = 2;
                treeNode30.Text = "Actual Guest Departures";
                treeNode31.ImageIndex = 3;
                treeNode31.Name = "";
                treeNode31.SelectedImageIndex = 2;
                treeNode31.Text = "Expected Guest Arrivals";
                treeNode32.ImageIndex = 3;
                treeNode32.Name = "";
                treeNode32.SelectedImageIndex = 2;
                treeNode32.Text = "Expected Guest Departures";
                treeNode33.ImageIndex = 0;
                treeNode33.Name = "";
                treeNode33.SelectedImageIndex = 1;
                treeNode33.Text = "Front Desk";
                treeNode34.ImageIndex = 3;
                treeNode34.Name = "Node0";
                treeNode34.SelectedImageIndex = 2;
                treeNode34.Text = "Cashier Shift Report";
                treeNode35.ImageIndex = 3;
                treeNode35.Name = "";
                treeNode35.SelectedImageIndex = 2;
                treeNode35.Text = "Transaction Register";
                treeNode36.ImageIndex = 3;
                treeNode36.Name = "";
                treeNode36.SelectedImageIndex = 2;
                treeNode36.Text = "Daily Transactions";
                treeNode37.ImageIndex = 3;
                treeNode37.Name = "Node1";
                treeNode37.SelectedImageIndex = 2;
                treeNode37.Text = "Voided Transactions";
                treeNode38.ImageIndex = 3;
                treeNode38.Name = "CityTransferTransactions";
                treeNode38.SelectedImageIndex = 2;
                treeNode38.Text = "City Transfer Transactions";
                treeNode39.ImageIndex = 0;
                treeNode39.Name = "";
                treeNode39.SelectedImageIndex = 1;
                treeNode39.Text = "Cashier";
                treeNode40.ImageIndex = 3;
                treeNode40.Name = "";
                treeNode40.SelectedImageIndex = 2;
                treeNode40.Text = "Individual Folios";
                treeNode41.ImageIndex = 3;
                treeNode41.Name = "";
                treeNode41.SelectedImageIndex = 2;
                treeNode41.Text = "Company Folios";
                treeNode42.ImageKey = "(default)";
                treeNode42.Name = "";
                treeNode42.Text = "Audit";
                treeNode43.ImageIndex = 3;
                treeNode43.Name = "";
                treeNode43.SelectedImageIndex = 2;
                treeNode43.Text = "Out Of Order Rooms";
                treeNode44.ImageIndex = 3;
                treeNode44.Name = "";
                treeNode44.SelectedImageIndex = 2;
                treeNode44.Text = "Housekeeping Jobs per Housekeeper";
                treeNode45.ImageIndex = 3;
                treeNode45.Name = "";
                treeNode45.SelectedImageIndex = 2;
                treeNode45.Text = "Room Status";
                treeNode46.Name = "";
                treeNode46.Text = "Housekeeping / Engineering";
                treeNode47.ImageIndex = 3;
                treeNode47.Name = "Node0";
                treeNode47.SelectedImageIndex = 3;
                treeNode47.Text = "Sales Summary";
                treeNode48.ImageIndex = 3;
                treeNode48.Name = "";
                treeNode48.SelectedImageIndex = 2;
                treeNode48.Text = "Sales Report";
                treeNode49.ImageIndex = 3;
                treeNode49.Name = "";
                treeNode49.SelectedImageIndex = 2;
                treeNode49.Text = "Sales Executive";
                treeNode50.ImageIndex = 3;
                treeNode50.Name = "";
                treeNode50.SelectedImageIndex = 2;
                treeNode50.Text = "Sales Production";
                treeNode51.ImageIndex = 3;
                treeNode51.Name = "";
                treeNode51.SelectedImageIndex = 2;
                treeNode51.Text = "Driver\'s Commissions";
                treeNode52.ImageIndex = 3;
                treeNode52.Name = "";
                treeNode52.SelectedImageIndex = 2;
                treeNode52.Text = "Regular Customers";
                treeNode53.ImageIndex = 3;
                treeNode53.Name = "";
                treeNode53.SelectedImageIndex = 2;
                treeNode53.Text = "Corporate Accounts";
                treeNode54.ImageIndex = 3;
                treeNode54.Name = "";
                treeNode54.SelectedImageIndex = 2;
                treeNode54.Text = "Room Block";
                treeNode55.ImageIndex = 3;
                treeNode55.Name = "";
                treeNode55.SelectedImageIndex = 2;
                treeNode55.Text = "Agent\'s Sales";
                treeNode56.Name = "";
                treeNode56.Text = "Marketing & Sales";
                this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode33,
            treeNode39,
            treeNode42,
            treeNode46,
            treeNode56});
                this.treeView1.SelectedImageIndex = 1;
                this.treeView1.Size = new System.Drawing.Size(272, 437);
                this.treeView1.TabIndex = 1;
                this.treeView1.Visible = false;
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.rdoAll);
                this.groupBox2.Controls.Add(this.cboMonthYear);
                this.groupBox2.Controls.Add(this.cboYear);
                this.groupBox2.Controls.Add(this.dtpDate);
                this.groupBox2.Controls.Add(this.cboMonth);
                this.groupBox2.Controls.Add(this.dtpFrom);
                this.groupBox2.Controls.Add(this.rdoYear);
                this.groupBox2.Controls.Add(this.rdoRange);
                this.groupBox2.Controls.Add(this.rdoMonth);
                this.groupBox2.Controls.Add(this.Label2);
                this.groupBox2.Controls.Add(this.dtpTo);
                this.groupBox2.Controls.Add(this.rdoDate);
                this.groupBox2.Controls.Add(this.Label1);
                this.groupBox2.Controls.Add(this.btnPrint);
                this.groupBox2.Controls.Add(this.btnClose);
                this.groupBox2.Location = new System.Drawing.Point(312, 12);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(350, 469);
                this.groupBox2.TabIndex = 8;
                this.groupBox2.TabStop = false;
                this.groupBox2.Text = "Report Preferences";
                // 
                // rdoAll
                // 
                this.rdoAll.Location = new System.Drawing.Point(28, 273);
                this.rdoAll.Name = "rdoAll";
                this.rdoAll.Size = new System.Drawing.Size(59, 19);
                this.rdoAll.TabIndex = 19;
                this.rdoAll.Text = "All";
                this.rdoAll.Visible = false;
                // 
                // cboMonthYear
                // 
                this.cboMonthYear.Enabled = false;
                this.cboMonthYear.Items.AddRange(new object[] {
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
                this.cboMonthYear.Location = new System.Drawing.Point(251, 82);
                this.cboMonthYear.Name = "cboMonthYear";
                this.cboMonthYear.Size = new System.Drawing.Size(79, 22);
                this.cboMonthYear.TabIndex = 18;
                // 
                // ReportGeneratorUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.BackColor = System.Drawing.SystemColors.Control;
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(681, 497);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.groupBox1);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "ReportGeneratorUI";
                this.Opacity = 0.6;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Report Generator";
                this.Load += new System.EventHandler(this.ReportGeneratorUI_Load);
                this.groupBox1.ResumeLayout(false);
                this.groupBox2.ResumeLayout(false);
                this.ResumeLayout(false);

            }

            #endregion

            #region " Events "

            public ReportGeneratorUI()
            {
                //This call is required by the Windows Form Designer.
                InitializeComponent();
            }

            private string rptToPrint = "";

            private void tvwReportGenerator_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);
                    PopUpMenu.Show(this.tvwReportGenerator, pos);

                }
            }

            private void mnuRefresh_Click(System.Object sender, System.EventArgs e)
            {
                this.tvwReportGenerator.CollapseAll();
            }

            private void ReportGeneratorUI_Load(object sender, System.EventArgs e)
            {
                this.tvwReportGenerator.CollapseAll();

				DateTime gAuditDate = DateTime.Parse(GlobalVariables.gAuditDate);
				this.dtpDate.Value = gAuditDate;
                //jlo 9-7-10
                if (ConfigVariables.gIsEMMOnly == "true")
                {
                    this.tvwReportGenerator.Nodes.RemoveAt(4);
                    //this.treeView1.Nodes[4].Nodes.RemoveAt(4);
                    this.tvwReportGenerator.Nodes[3].Nodes.RemoveAt(2);
                    //this.treeView1.Nodes[3].Nodes.RemoveAt(2);
                    this.tvwReportGenerator.Nodes[3].Nodes.RemoveAt(1);
                    this.treeView1.Nodes[3].Nodes.RemoveAt(1);
                    this.treeView1.Nodes.RemoveAt(2);
                    this.tvwReportGenerator.Nodes.RemoveAt(2);
                    this.treeView1.Nodes.RemoveAt(1);
                    this.tvwReportGenerator.Nodes.RemoveAt(1);
                    this.tvwReportGenerator.Nodes[0].Nodes.RemoveAt(0);
                }
            }

            private void btnClose_Click(System.Object sender, System.EventArgs e)
            {
                this.Close();
            }

            private ReportViewer frmReportViewer;
            private ReportFacade reportFacade;
            private void btnPrint_Click(System.Object sender, System.EventArgs e)
            {
                generateReport();
            }

            #endregion

            #region "Misc"

            enum ReportType { DAILY, MONTHLY, ANNUAL, OTHERS };
            ReportType mReportType = ReportType.DAILY;

            private void rdoNow_CheckedChanged(System.Object sender, System.EventArgs e)
            {
                if (rdoDate.Checked)
                {
                    this.dtpDate.Enabled = true;
                    mReportType = ReportType.DAILY;
                }
                else
                {
                    mReportType = ReportType.DAILY;
                    this.dtpDate.Enabled = false;
                }
            }

            private void rdoMonth_CheckedChanged(System.Object sender, System.EventArgs e)
            {
                if (rdoMonth.Checked)
                {
                    this.cboMonth.Enabled = true;
                    this.cboMonth.SelectedIndex = DateTime.Now.Month - 1;

                    this.cboMonthYear.Enabled = true;
                    this.cboMonthYear.Text = DateTime.Now.Year.ToString();

                    mReportType = ReportType.MONTHLY;
                }
                else
                {
                    this.cboMonth.Enabled = false;
                    this.cboMonthYear.Enabled = false;

                    mReportType = ReportType.DAILY;
                }
            }

            private void rdoYear_CheckedChanged(System.Object sender, System.EventArgs e)
            {
                if (rdoYear.Checked)
                {
                    this.cboYear.Enabled = true;
                    this.cboYear.Text = DateTime.Now.Year.ToString();

                    mReportType = ReportType.ANNUAL;
                }
                else
                {
                    this.cboYear.Enabled = false;
                    mReportType = ReportType.DAILY;
                }
            }

            private void rdoRange_CheckedChanged(System.Object sender, System.EventArgs e)
            {
                if (rdoRange.Checked)
                {
                    this.dtpFrom.Enabled = true;
                    this.dtpTo.Enabled = true;

                    mReportType = ReportType.OTHERS;
                }
                else
                {
                    this.dtpFrom.Enabled = false;
                    this.dtpTo.Enabled = false;

                    mReportType = ReportType.DAILY;
                }
            }

            private void tvwReportGenerator_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
            {
                if (e.Node.Text == "Cancelled Reservations")
                {
                    rdoAll.Visible = true;
                }
                else
                {
                    rdoAll.Visible = false;
                }

                foreach (TreeNode tvwNode in this.tvwReportGenerator.Nodes)
                {
                    foreach (TreeNode cNode in tvwNode.Nodes)
                    {
                        cNode.BackColor = System.Drawing.Color.White;
                        cNode.ForeColor = System.Drawing.Color.Black;
                    }
                    tvwNode.BackColor = System.Drawing.Color.White;
                    tvwNode.ForeColor = System.Drawing.Color.Black;
                }

                rptToPrint = e.Node.Text;
                e.Node.BackColor = System.Drawing.Color.Red;
                e.Node.ForeColor = System.Drawing.Color.White;

            }

            #endregion

            private bool generateReport()
            {
                //this.MdiParent.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                try
                {
                    frmReportViewer = new ReportViewer();
                    reportFacade = new ReportFacade();

                    string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);

                    switch (rptToPrint.ToUpper())
                    {
                        case "TRANSACTION REGISTER":

                            generateTransactionRegisterReport();
                            break;

                        case "CITY LEDGER":
                        case "CORPORATE ACCOUNTS":
                            if (generateCityLedgerReport() == 1)
                            { }     // do nothing 
                            else
                            {
                                return false;
                            }

                            break;

                        case "DAILY TRANSACTIONS":
                            
                            generateDailyTransactionsReport();
                           
                            break;

                        case "TRANSACTION SUMMARY":
                        case "SALES REPORT":
                            //generateTransactionSummaryReport();
                            generateSalesReport();
                            break;

                        case "CITY TRANSFER TRANSACTIONS":
                            generateCityTransferReports();
                            break;

                        case "CASHIER SHIFT REPORT":
                            generateCashierShiftReports();
                            break;

                        case "ACTUAL GUEST ARRIVALS":
                            generateActualGuestArrivalsReports();
                            break;

                        case "ACTUAL GUEST DEPARTURES":
                            generateActualGuestDepartureReports();
                            break;

                        case "EXPECTED GUEST ARRIVALS":
                            generateExpectedGuestArrivalReports();
                            break;

                        case "EXPECTED GUEST DEPARTURES":
                            generateExpectedGuestDepartureReports();
                            break;

                        case "CANCELLED RESERVATIONS":
                            generateCancelledReservationReports();
                            break;

                        case "VOIDED TRANSACTIONS":
                            generateVoidedTransactionsReport();
                            break;


                        case "ROOM AVAILABILITY":
                            generateRoomAvailabilityReports();
                            this.MdiParent.Cursor = System.Windows.Forms.Cursors.Default;
                            return true;


                        case "ROOM OCCUPANCY":
                            generateRoomOccupancyGraph();
                            break;

                        case "OUT OF ORDER ROOMS":
                            generateOutOfOrderRoomsReport();
                            break;

                        case "INDIVIDUAL FOLIOS":
                            getAllIndividualFolio();
                            break;
						case "SALES SUMMARY":
							generateTransactionSummaryReport();
							break;

                        case "SALES EXECUTIVE":
                            if (generateSalesExecutiveReport() == 0)
                                return false;
                            break;
                            
                        case "SALES PRODUCTION":
                            generateSalesProductionReport();
                            break;

                        case "DRIVER'S COMMISSIONS":
                            generateDriversCommissionReport();
                            break;

                        case "ROOM UTILIZATION" :
                            generateRoomUtilizationReport();
                            break;

                        default:
                            MessageBox.Show("Please select type of report.", "Report Generator", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.MdiParent.Cursor = System.Windows.Forms.Cursors.Arrow;
                            return false;



                    }

                    frmReportViewer.MdiParent = this.MdiParent;
                    frmReportViewer.Show();

                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    this.MdiParent.Cursor = System.Windows.Forms.Cursors.Default;
                }

            }

            private int generateTransactionRegisterReport()
            {
                DataTable dtTable = new DataTable("TransactionRegister");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                TransactionRegisterReport transactionRegister = new TransactionRegisterReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getTransactionRegisterReportDate(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        //transactionRegister.SetDataSource(reportFacade.getMonthlyTransactionRegisterReport(month, year));
                        //transactionRegister.SetParameterValue(0, "for the Month of  " + this.cboMonth.Text + " ,  " + year);
                        dtTable = reportFacade.getMonthlyTransactionRegisterReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        //transactionRegister.SetDataSource(reportFacade.getAnnualTransactionRegisterReport(year));
                        //transactionRegister.SetParameterValue(0, "for the Year   " + year);
                        dtTable = reportFacade.getAnnualTransactionRegisterReport(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        //transactionRegister.SetDataSource(reportFacade.getParamTransactionRegisterReport(startDate, endDate));
                        //transactionRegister.SetParameterValue(0, string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value));
                        dtTable = reportFacade.getParamTransactionRegisterReport(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);

                        break;
                }

                transactionRegister.Database.Tables[0].SetDataSource(dtTable);
                transactionRegister.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                transactionRegister.SetParameterValue(0 , reportParam);

                frmReportViewer.rptViewer.ReportSource = transactionRegister;

                return 1;
            }

            private int generateCityLedgerReport()
            {
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        //frmReportViewer.rptViewer.ReportSource = reportFacade.getCityLedgerDate(pDate);
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getCityLedger() ;
                        break;
                    
                    default:
                        MessageBox.Show("Report not available", "City Ledger Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return 0;
                    
                }

                return 1;
            }

            private int generateDailyTransactionsReport()
            {
                DataTable dtTable = new DataTable("TransactionRegister");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                DailyTransactionsReport dailyTransactionsReport = new DailyTransactionsReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getDailyTransactionsDate(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        //dailyTransactionsReport.SetDataSource( reportFacade.getMonthlyTransactionsReport(month, year) ); 
                        //dailyTransactionsReport.SetParameterValue(0, "for the Month of  " + this.cboMonth.Text + " ,  " + year);
                        dtTable = reportFacade.getMonthlyTransactionsReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year ;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        //dailyTransactionsReport.SetDataSource( reportFacade.getAnnualTransactions(year) );
                        //dailyTransactionsReport.SetParameterValue(0, "for the Year   " + year);
                        dtTable = reportFacade.getAnnualTransactions(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        //dailyTransactionsReport.SetDataSource( reportFacade.getTransactionsDateRange(startDate, endDate) );
                        //dailyTransactionsReport.SetParameterValue(0, string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value));
                        dtTable = reportFacade.getTransactionsDateRange(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }
                dailyTransactionsReport.Database.Tables[0].SetDataSource(dtTable);
                dailyTransactionsReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                dailyTransactionsReport.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = dailyTransactionsReport;

                return 1;
            }

            private int generateTransactionSummaryReport()
            {
                DataTable dtTable = new DataTable("TransactionRegister");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                SalesSummary salesSummary = new SalesSummary();

                switch (mReportType)
                {
                    case ReportType.DAILY:

						frmReportViewer.rptViewer.ReportSource = reportFacade.getSalesSummary(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        //salesSummary.SetDataSource(reportFacade.getMonthlySalesSummary(month, year));
                        //salesSummary.SetParameterValue(0, "for the Month of  " + this.cboMonth.Text + " ,  " + year);
                        dtTable = reportFacade.getMonthlySalesSummary(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        //salesSummary.SetDataSource(reportFacade.getAnnualSalesSummary(year));
                        //salesSummary.SetParameterValue(0, "for the Year   " + year);
                        dtTable = reportFacade.getAnnualSalesSummary(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        //salesSummary.SetDataSource(reportFacade.getDateRangeSalesSummary(startDate, endDate));
                        //salesSummary.SetParameterValue(0, string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value));
                        dtTable = reportFacade.getDateRangeSalesSummary(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                salesSummary.Database.Tables[0].SetDataSource(dtTable);
                salesSummary.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                salesSummary.SetParameterValue(0, reportParam);    
                
                frmReportViewer.rptViewer.ReportSource = salesSummary;

                return 1;

            }

            private int generateSalesExecutiveReport()
            {
                DataTable dtTable = new DataTable("SalesExecutive");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                SalesExecutiveReport salesExecutive = new SalesExecutiveReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:

                        MessageBox.Show("Report not available", "Sales Executive Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return 0;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlySalesExecutive(month, year, "ALL");
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualSalesExecutive(year, "ALL");
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeSalesExecutive(startDate, endDate, "ALL");
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                salesExecutive.Database.Tables[1].SetDataSource(dtTable);
                salesExecutive.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
                salesExecutive.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = salesExecutive;

                return 1;

            }

            private int generateSalesProductionReport()
            {
                DataTable dtTable = new DataTable("SalesProduction");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                SalesProductionReport salesProduction = new SalesProductionReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:

                        MessageBox.Show("Report not available", "Sales Production Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return 0;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlySalesProductionReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualSalesProductionReport(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeSalesProductionReport(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                salesProduction.Database.Tables[1].SetDataSource(dtTable);
                salesProduction.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
                salesProduction.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = salesProduction;

                return 1;

            }
            /// <summary>
            /// Gets the sum of hours in the roomutilization datatable
            /// </summary>
            /// <param name="pDt">datable containing roomutilization report</param>
            /// <returns>int : total number of hours</returns>
            private int getRoomUtilizationSum(DataTable pDt)
            {
                int _sum = 0;
                foreach (DataRow _dRow in pDt.Rows)
                {
                    _sum = _sum + int.Parse(_dRow["hours"].ToString());
                }
                return _sum;
            }

            /// <summary>
            /// Generates the roomutilizationreport
            /// </summary>
            /// <returns>int</returns>
            private int generateRoomUtilizationReport()
            {
                RoomUtilization roomUtilizationReport = new RoomUtilization();
                DataTable _dt = new DataTable();
                string reportParam = "";

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        _dt = reportFacade.getRoomUtilization(dtpDate.Value, dtpDate.Value);
                        reportParam = string.Format("{0:MMM dd, yyyy}", dtpDate.Value);
                        break;
                    case ReportType.MONTHLY:
                        int _month = this.cboMonth.SelectedIndex + 1;
                        int _year = int.Parse(this.cboMonthYear.Text);
                        _dt = reportFacade.getRoomUtilization(DateTime.Parse(_year.ToString() + "-" + _month.ToString() + "-01"), DateTime.Parse(_year.ToString() + "-" + _month.ToString() + "-" + DateTime.DaysInMonth(_year,_month)));
                        reportParam = "Month of " + this.cboMonth.Text + " " + this.cboMonthYear.Text;
                        break;
                    case ReportType.ANNUAL:
                        int _year2 = int.Parse(this.cboYear.Text);
                        _dt = reportFacade.getRoomUtilization(DateTime.Parse(_year2.ToString() + "-01-01"), DateTime.Parse(_year2.ToString() + "-12-31"));
                        reportParam = "Jan - Dec " + this.cboYear.Text;
                        break;
                    case ReportType.OTHERS:
                        _dt = reportFacade.getRoomUtilization(dtpFrom.Value, dtpTo.Value);
                        reportParam = string.Format("{0:MMM dd, yyyy}", dtpFrom.Value) + " - " + string.Format("{0:MMM dd, yyyy}", dtpTo.Value);
                        break;
                }

                roomUtilizationReport.Database.Tables[0].SetDataSource(_dt);
                roomUtilizationReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                roomUtilizationReport.SetParameterValue(0, reportParam);
                int _sum = getRoomUtilizationSum(_dt);
                if (_sum == 0) { _sum = 1; }
                roomUtilizationReport.SetParameterValue(1, _sum);

                frmReportViewer.rptViewer.ReportSource = roomUtilizationReport;

                return 1;
            }

            private int generateDriversCommissionReport()
            {
                DataTable dtTable = new DataTable("DriversCommission");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                DriverSales driverSalesReport = new DriverSales();

                switch (mReportType)
                {
                    case ReportType.DAILY:

                        MessageBox.Show("Report not available", "Driver's Commission Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return 0;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlyDriversCommissionReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualDriversCommissionReport(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeDriversCommissionsReport(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                driverSalesReport.Database.Tables[1].SetDataSource(dtTable);
                driverSalesReport.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
                driverSalesReport.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = driverSalesReport;

                return 1;

            }

            private int generateCityTransferReports()
            {
                DataTable dtTable = new DataTable("TransactionRegister");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                CityTransferTransactions cityTransfer = new CityTransferTransactions();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        //cityTransfer.SetDataSource(reportFacade.getParamCityTransferTransactions(pDate, pDate));
                        //cityTransfer.SetParameterValue(0, string.Format("{0:ddd. MMM. dd, yyyy}", this.dtpDate.Value));
                        dtTable = reportFacade.getParamCityTransferTransactions(pDate, pDate);
                        reportParam = string.Format("{0:ddd. MMM. dd, yyyy}", this.dtpDate.Value);
                        break;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        //cityTransfer.SetDataSource(reportFacade.getMonthlyCityTransferTransactions(month, year));
                        //cityTransfer.SetParameterValue(0, "for the Month of  " + this.cboMonth.Text + " ,  " + year);
                        dtTable = reportFacade.getMonthlyCityTransferTransactions(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        //cityTransfer.SetDataSource(reportFacade.getAnnualCityTransferTransactions(year));
                        //cityTransfer.SetParameterValue(0, "for the Year   " + year);
                        dtTable = reportFacade.getAnnualCityTransferTransactions(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        //cityTransfer.SetDataSource(reportFacade.getParamCityTransferTransactions(startDate, endDate));
                        //cityTransfer.SetParameterValue(0, string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value));
                        dtTable = reportFacade.getParamCityTransferTransactions(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }
                cityTransfer.Database.Tables[0].SetDataSource(dtTable);
                cityTransfer.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                cityTransfer.SetParameterValue(0, reportParam);    

                frmReportViewer.rptViewer.ReportSource = cityTransfer;

                return 1;



            }

            private int generateCashierShiftReports()
            {
                DataTable dtTable = new DataTable("TransactionRegister");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                CashierCheckOutReport cashierShiftReport = new CashierCheckOutReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getAllCashierShiftTransaction(pDate, "ALL");
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        //cashierShiftReport.SetDataSource(reportFacade.getMonthlyCashierShiftReport(month, year));
                        //cashierShiftReport.SetParameterValue(0, "for the Month of  " + this.cboMonth.Text + " ,  " + year);
                        dtTable = reportFacade.getMonthlyCashierShiftReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        //cashierShiftReport.SetDataSource(reportFacade.getAnnualCashierShiftReport(year));
                        //cashierShiftReport.SetParameterValue(0, "for the Year   " + year);
                        dtTable =reportFacade.getAnnualCashierShiftReport(year);
                        reportParam = "for the Year   " + year;

                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        //cashierShiftReport.SetDataSource(reportFacade.getDateRangeCashierShiftReport(startDate, endDate));
                        //cashierShiftReport.SetParameterValue(0, string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value));
                        dtTable = reportFacade.getDateRangeCashierShiftReport(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                cashierShiftReport.Database.Tables[0].SetDataSource(dtTable);
                cashierShiftReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                cashierShiftReport.SetParameterValue(0, reportParam);    

                frmReportViewer.rptViewer.ReportSource = cashierShiftReport;

                return 1;


            }

            private int generateActualGuestArrivalsReports()
            {
                DataTable dtTable = new DataTable("GuestArrivals");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                ActualGuestArrival actualGuestArrivalReport = new ActualGuestArrival();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getActualArrivalReport(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlyActualArrivalReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualActualArrivalReport(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeActualArrivalReport(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }
                actualGuestArrivalReport.Database.Tables[0].SetDataSource(dtTable);
                actualGuestArrivalReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                actualGuestArrivalReport.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = actualGuestArrivalReport;

                return 1;
            }

            private int generateActualGuestDepartureReports()
            {
                DataTable dtTable = new DataTable("GuestArrivals");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                ActualGuestDeparture actualGuestDeparture = new ActualGuestDeparture();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getActualDepartureReport(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlyActualDepartureReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualActualDepartureReport(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeActualDepartureReport(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }
                actualGuestDeparture.Database.Tables[0].SetDataSource(dtTable);
                actualGuestDeparture.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                actualGuestDeparture.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = actualGuestDeparture;

                return 1;
            }

            private int generateExpectedGuestArrivalReports()
            {
                DataTable dtTable = new DataTable("GuestArrivals");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                ExpectedArrivalReport expectedArrival = new ExpectedArrivalReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getExpectedArrivalReport(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        //dtTable = reportFacade.getMonthlyExpectedGuestArrivalReport(month, year);
                        //reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        //break;
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getMonthlyExpectedArrivalReport(month, year);
                        return 1;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        //dtTable = reportFacade.getAnnualExpectedGuestArrivalReport(year);
                        //reportParam = "for the Year   " + year;
                        //break;
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getAnnualExpectedGuestArrivalReport(year);
                        return 1;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        //dtTable = reportFacade.getDateRangeExpectedGuestArrivalReport(startDate, endDate);
                        //reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        //break;
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getDateRangeExpectedGuestArrivalReport(startDate, endDate);
                        return 1;
                }
                //expectedArrival.Database.Tables[0].SetDataSource(dtTable);
                //expectedArrival.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                //expectedArrival.SetParameterValue(0, reportParam);

                //frmReportViewer.rptViewer.ReportSource = expectedArrival;

                return 1;
            }

            private int generateExpectedGuestDepartureReports()
            {
                DataTable dtTable = new DataTable("GuestDepartures");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                ExpectedDepartureReport expectedDeparture = new ExpectedDepartureReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getExpectedDepartureReport(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        frmReportViewer.rptViewer.ReportSource = reportFacade.getMonthlyExpectedGuestDepartureReport(month, year);
                        return 1;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        frmReportViewer.rptViewer.ReportSource = reportFacade.getAnnualExpectedGuestDepartureReport(year);
                        return 1;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        frmReportViewer.rptViewer.ReportSource = reportFacade.getDateRangeExpectedGuestDepartureReport(startDate, endDate);
                        return 1;
                }
                return 1;

                //switch (mReportType)
                //{
                //    case ReportType.DAILY:
                //        frmReportViewer.rptViewer.ReportSource = reportFacade.getExpectedDepartureReport(pDate);
                //        return 1;

                //    case ReportType.MONTHLY:
                //        int month = this.cboMonth.SelectedIndex + 1;
                //        int year = int.Parse(this.cboMonthYear.Text);

                //        dtTable = reportFacade.getMonthlyExpectedGuestDepartureReport(month, year);
                //        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                //        break;

                //    case ReportType.ANNUAL:
                //        year = int.Parse(this.cboYear.Text);

                //        dtTable = reportFacade.getAnnualExpectedGuestDepartureReport(year);
                //        reportParam = "for the Year   " + year;
                //        break;

                //    case ReportType.OTHERS:
                //        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                //        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                //        dtTable = reportFacade.getDateRangeExpectedGuestDepartureReport(startDate, endDate);
                //        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                //        break;
                //}
                //expectedDeparture.Database.Tables[0].SetDataSource(dtTable);
                //expectedDeparture.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                //expectedDeparture.SetParameterValue(0, reportParam);

                //frmReportViewer.rptViewer.ReportSource = expectedDeparture;

                //return 1;
            }

            private int generateCancelledReservationReports()
            {
                DataTable dtTable = new DataTable("GuestArrivals");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                CancelledReservationReport cancelledReservations = new CancelledReservationReport();

                if (rdoAll.Checked)
                {
                    frmReportViewer.rptViewer.ReportSource = reportFacade.getCancelledReservation("");
                    return 1;
                }

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getCancelledReservation(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlyCancelledReservations(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualCancelledReservations(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeCancelledReservations(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }
                cancelledReservations.Database.Tables[0].SetDataSource(dtTable);
                cancelledReservations.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                try
                {
                    ReportDocument rpt = cancelledReservations;
                    reportFacade.setSubReport(ref rpt, reportFacade.getCancelledGroups(reportParam), true);

                    cancelledReservations.SetParameterValue(0, reportParam);
                }
                catch
                {
                    cancelledReservations.SetParameterValue(0, "");
                }

                frmReportViewer.rptViewer.ReportSource = cancelledReservations;

                return 1;

            }

            private int generateVoidedTransactionsReport()
            {
              
                DataTable dtTable = new DataTable("GuestArrivals");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                VoidedTransactionsReport voidTransactions = new VoidedTransactionsReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getVoidedTransactionsReport(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlyVoidTransactionsReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualVoidTransactionsReport(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeVoidTransactions(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }
                voidTransactions.Database.Tables[0].SetDataSource(dtTable);
                voidTransactions.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                voidTransactions.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = voidTransactions;

                return 1;
            }

            private int generateRoomAvailabilityReports()
            {
                try
                {
                    int weeks = 2;
                    DateTime startDate  = DateTime.Now;

                    switch(mReportType)
                    {
                        case ReportType.DAILY:
                            {
                                weeks = 2;
                                startDate = DateTime.Now;
                                break;
                            }

                        case ReportType.MONTHLY:
                            {
                                weeks = 5;
                                string strDate = this.cboMonth.Text + " 1, " + this.cboMonthYear.Text;
                                startDate = DateTime.Parse(strDate) ;
                                break;
                            }
                        case ReportType.ANNUAL:
                            {
                                weeks = 55;
                                string strDate = "January 1, " + this.cboYear.Text;
                                startDate = DateTime.Parse(strDate) ;
                                break;
                            }
                        case ReportType.OTHERS:
                            {
                                long dateDiff = 0;

                                dateDiff = (DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dtpFrom.Value, dtpTo.Value)/7) + 1;
                                startDate = this.dtpFrom.Value;
                                weeks = int.Parse(dateDiff.ToString());

                                break;
                            }
                    }

                    object[] obj = { weeks, startDate };
                    ConstructorInfo calendarUI;
                    Type[] paramTypes = { typeof(int), typeof(System.DateTime) };
                    Assembly assembly;
                    assembly = Assembly.LoadFrom("Reservation.dll");

                    Type type = assembly.GetType("Jinisys.Hotel.Reservation.Presentation.RoomCalendarUI");
                    calendarUI = type.GetConstructor(paramTypes);

                    Form frm = (Form)calendarUI.Invoke(obj);
                    object new_obj = frm.GetType().GetMethod("PrintGrid").Invoke(frm, null);
                 
                    return 1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }

            private int generateRoomOccupancyGraph()
            {
                DataTable dtTable = new DataTable("RoomOccupancy");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                RoomOccupancyGraph roomOccupancyGraph = new RoomOccupancyGraph();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        dtTable = reportFacade.getRoomOccupancyGraph(pDate);
                        reportParam = "for " + string.Format( "{0:dddd, MMMM dd, yyyy}",dtpDate.Value);
                        break ;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlyRoomOccupancyGraph(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualRoomOccupancyGraph(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeRoomOccupancyGraph(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                roomOccupancyGraph.Database.Tables[1].SetDataSource(dtTable);
                roomOccupancyGraph.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());
                roomOccupancyGraph.SetParameterValue(0, reportParam);
                
                frmReportViewer.rptViewer.ReportSource = roomOccupancyGraph;

                return 1;
            }

            private int generateSalesReport()
            {
                DataTable dtTable = new DataTable("TransactionRegister");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                SalesReport salesReport = new SalesReport();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getDailySalesReport(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlySalesReport(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualSalesReport(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeSalesReport(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                salesReport.Database.Tables[0].SetDataSource(dtTable);
                salesReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                salesReport.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = salesReport;

                return 1;

            }

            private int generateOutOfOrderRoomsReport()
            {
                DataTable dtTable = new DataTable("OutOfOrderRooms");
                string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                OutOfOrderRooms outOfOrderRooms = new OutOfOrderRooms();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getOutOfOrderRooms(pDate);
                        return 1;

                    case ReportType.MONTHLY:
                        int month = this.cboMonth.SelectedIndex + 1;
                        int year = int.Parse(this.cboMonthYear.Text);

                        dtTable = reportFacade.getMonthlyOutOfOrderRooms(month, year);
                        reportParam = "for the Month of  " + this.cboMonth.Text + " ,  " + year;
                        break;

                    case ReportType.ANNUAL:
                        year = int.Parse(this.cboYear.Text);

                        dtTable = reportFacade.getAnnualOutOfOrderRooms(year);
                        reportParam = "for the Year   " + year;
                        break;

                    case ReportType.OTHERS:
                        string startDate = string.Format("{0:yyyy-MM-dd}", this.dtpFrom.Value);
                        string endDate = string.Format("{0:yyyy-MM-dd}", this.dtpTo.Value);

                        dtTable = reportFacade.getDateRangeOutOfOrderRooms(startDate, endDate);
                        reportParam = string.Format("{0:MMM. dd, yyyy}", this.dtpFrom.Value) + "  to  " + string.Format("{0:MMM. dd, yyyy}", this.dtpTo.Value);
                        break;
                }

                outOfOrderRooms.Database.Tables[0].SetDataSource(dtTable);
                outOfOrderRooms.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                outOfOrderRooms.SetParameterValue(0, reportParam);

                frmReportViewer.rptViewer.ReportSource = outOfOrderRooms;

                return 1;

            }

            private int getAllIndividualFolio()
            {
                DataTable dtTable = new DataTable("AllIndividualFolio");
                //string reportParam = "";
                string pDate = string.Format("{0:yyyy-MM-dd}", dtpDate.Value);
                AllIndividualFolio allIndividualFolio = new AllIndividualFolio();

                switch (mReportType)
                {
                    case ReportType.DAILY:
                        frmReportViewer.rptViewer.ReportSource = reportFacade.getAllIndividualFolio();
                        return 1;

                    default:
                        return 1;
                }

                //allIndividualFolio.Database.Tables[0].SetDataSource(dtTable);
                //allIndividualFolio.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());
                //allIndividualFolio.SetParameterValue(0, reportParam);

                //frmReportViewer.rptViewer.ReportSource = allIndividualFolio;

                //return 1;
            
            }
        }   

    }
}