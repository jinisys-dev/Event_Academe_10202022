
using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using SAP_SDK;
using Jinisys.Hotel.Cashier.Presentation;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Security.BusinessLayer;

using MySql.Data.MySqlClient;
using C1.Win.C1FlexGrid;
using System.Text;

namespace Jinisys.Hotel.Reservation
{
	namespace Presentation
	{
		public class ReservationListUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
		{
			//private string lDefaultSelectedFoliotype = ConfigVariables.gDefaultGuestListFolioTypeSelected;
			#region " Windows Form Designer generated lCode "


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
				//base.Hide();
			}

			private System.ComponentModel.IContainer components;

			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the lCode editor.
			internal System.Windows.Forms.TextBox txtfname;
			internal System.Windows.Forms.TextBox txtlname;
			public System.Windows.Forms.Button btnCancelReservation;
			public System.Windows.Forms.Button btnCheckedIn;
			public System.Windows.Forms.Button btnCheckedOut;
			public System.Windows.Forms.Button btnNoShow;
			public System.Windows.Forms.Button btnConfirmed;
			private ContextMenuStrip cmuPopUp;
			private ToolStripMenuItem cmuAddNewReservation;
			private ToolStripMenuItem cmuEditReservation;
			private ToolStripSeparator toolStripMenuItem1;
			private ToolStripMenuItem cmuNowShow;
			private ToolStripMenuItem cmuCancel;
			private ToolStripSeparator toolStripMenuItem3;
			private ToolStripMenuItem cmdRefresh;
			private ToolStripSeparator toolStripMenuItem4;
			private ToolStripMenuItem cmuCheckIn;
			private ToolStripMenuItem cmuCheckOut;
			internal Button btnClose;
			public Label Label2;
			public Label Label3;
			internal Label Label1;
			private Panel pnlSetMaster;
			public Button btnSelectMaster;
			internal TextBox txtSearch;
			private Panel panel1;
			internal Label label14;
			internal Label lblTotalNoShow;
			internal Label label9;
			internal Label lblTotalCancelled;
			internal Label lblTotalCheckedOut;
			internal Label lblTotalCheckedIn;
			internal Label label12;
			internal Label Label6;
			internal Label lblTotalExpectedCheckIn;
			internal Label label5;
			internal Label lblTotalExpectedCheckOut;
			internal Label Label7;
			internal Label Label10;
			internal Label lblTotalForNoShow;
			internal Label lblTotalOverstaying;
			internal Label Label8;
			public ComboBox cboReservationStatus;
			internal ComboBox cboFolioType;
			internal GroupBox GroupBox1;
			public Button btnInsert;
			internal Label label4;
			internal Label lblTotalReservations;
			internal Label lbl13;
			internal Label lblHighBalance;
			public Button btnCreateLetter;
			private ToolStripMenuItem cmuConfirmed;
			internal Label label11;
			internal Label lblTotalWaitList;
			public Button btnPrintRegCard;
			internal Label label13;
			private PictureBox pctBell;
			internal Label label15;
			internal Label lblTotalGroupWaitList;
			private System.ComponentModel.BackgroundWorker bgwLoadAllFolio;
			private System.ComponentModel.BackgroundWorker bgwLegendValues;
            private TextBox txtFilter;
            private Label label16;
            private Label label17;
            private ComboBox cboCategory;
            internal GroupBox groupBox2;
            private PictureBox pctBell2;
            private PictureBox pctCombined;
            private Label label18;
            private Label label19;
            private Label label20;
            private Panel panel2;
            public Button btnExportToExcel;
            private Label label22;
            private Label label21;
            private ComboBox cboMarketingOfficer;
            private ComboBox cboEventOfficer;
            private Label label23;
            private DateTimePicker dtpTo;
            private Label label24;
            private DateTimePicker dtpFrom;
            private Label label25;
            private CheckBox chkDateFilter;
            private ToolStripMenuItem cmuMarketing;
            private ToolStripMenuItem cmuEvent;
            private Button btnShow;
			private C1FlexGrid grdFolio;
            private bool lCanAddEventOfficer = false;
            private TextBox txtNumAmended;
            private TextBox txtNumRemarks;
            private bool lCanAddMarketingOfficer = false;
			[System.Diagnostics.DebuggerStepThrough()]
			private void InitializeComponent()
			{
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationListUI));
                this.btnCancelReservation = new System.Windows.Forms.Button();
                this.txtfname = new System.Windows.Forms.TextBox();
                this.txtlname = new System.Windows.Forms.TextBox();
                this.cmuPopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.cmuEditReservation = new System.Windows.Forms.ToolStripMenuItem();
                this.cmuMarketing = new System.Windows.Forms.ToolStripMenuItem();
                this.cmuEvent = new System.Windows.Forms.ToolStripMenuItem();
                this.cmuAddNewReservation = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
                this.cmuConfirmed = new System.Windows.Forms.ToolStripMenuItem();
                this.cmuNowShow = new System.Windows.Forms.ToolStripMenuItem();
                this.cmuCancel = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
                this.cmdRefresh = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
                this.cmuCheckIn = new System.Windows.Forms.ToolStripMenuItem();
                this.cmuCheckOut = new System.Windows.Forms.ToolStripMenuItem();
                this.btnCheckedIn = new System.Windows.Forms.Button();
                this.btnCheckedOut = new System.Windows.Forms.Button();
                this.btnNoShow = new System.Windows.Forms.Button();
                this.btnConfirmed = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                this.Label2 = new System.Windows.Forms.Label();
                this.Label3 = new System.Windows.Forms.Label();
                this.Label1 = new System.Windows.Forms.Label();
                this.pnlSetMaster = new System.Windows.Forms.Panel();
                this.btnSelectMaster = new System.Windows.Forms.Button();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.panel1 = new System.Windows.Forms.Panel();
                this.label15 = new System.Windows.Forms.Label();
                this.lblTotalGroupWaitList = new System.Windows.Forms.Label();
                this.label11 = new System.Windows.Forms.Label();
                this.lblTotalWaitList = new System.Windows.Forms.Label();
                this.lbl13 = new System.Windows.Forms.Label();
                this.lblHighBalance = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.lblTotalReservations = new System.Windows.Forms.Label();
                this.label14 = new System.Windows.Forms.Label();
                this.lblTotalNoShow = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.lblTotalCancelled = new System.Windows.Forms.Label();
                this.lblTotalCheckedOut = new System.Windows.Forms.Label();
                this.lblTotalCheckedIn = new System.Windows.Forms.Label();
                this.label12 = new System.Windows.Forms.Label();
                this.Label6 = new System.Windows.Forms.Label();
                this.lblTotalExpectedCheckIn = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.lblTotalExpectedCheckOut = new System.Windows.Forms.Label();
                this.Label7 = new System.Windows.Forms.Label();
                this.Label10 = new System.Windows.Forms.Label();
                this.lblTotalForNoShow = new System.Windows.Forms.Label();
                this.lblTotalOverstaying = new System.Windows.Forms.Label();
                this.Label8 = new System.Windows.Forms.Label();
                this.cboReservationStatus = new System.Windows.Forms.ComboBox();
                this.cboFolioType = new System.Windows.Forms.ComboBox();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.btnInsert = new System.Windows.Forms.Button();
                this.grdFolio = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.btnCreateLetter = new System.Windows.Forms.Button();
                this.btnPrintRegCard = new System.Windows.Forms.Button();
                this.label13 = new System.Windows.Forms.Label();
                this.bgwLoadAllFolio = new System.ComponentModel.BackgroundWorker();
                this.bgwLegendValues = new System.ComponentModel.BackgroundWorker();
                this.txtFilter = new System.Windows.Forms.TextBox();
                this.label16 = new System.Windows.Forms.Label();
                this.label17 = new System.Windows.Forms.Label();
                this.cboCategory = new System.Windows.Forms.ComboBox();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.label18 = new System.Windows.Forms.Label();
                this.label19 = new System.Windows.Forms.Label();
                this.label20 = new System.Windows.Forms.Label();
                this.panel2 = new System.Windows.Forms.Panel();
                this.txtNumAmended = new System.Windows.Forms.TextBox();
                this.txtNumRemarks = new System.Windows.Forms.TextBox();
                this.label22 = new System.Windows.Forms.Label();
                this.pctBell = new System.Windows.Forms.PictureBox();
                this.pctBell2 = new System.Windows.Forms.PictureBox();
                this.btnExportToExcel = new System.Windows.Forms.Button();
                this.pctCombined = new System.Windows.Forms.PictureBox();
                this.label21 = new System.Windows.Forms.Label();
                this.cboMarketingOfficer = new System.Windows.Forms.ComboBox();
                this.cboEventOfficer = new System.Windows.Forms.ComboBox();
                this.label23 = new System.Windows.Forms.Label();
                this.dtpTo = new System.Windows.Forms.DateTimePicker();
                this.label24 = new System.Windows.Forms.Label();
                this.dtpFrom = new System.Windows.Forms.DateTimePicker();
                this.label25 = new System.Windows.Forms.Label();
                this.chkDateFilter = new System.Windows.Forms.CheckBox();
                this.btnShow = new System.Windows.Forms.Button();
                this.cmuPopUp.SuspendLayout();
                this.pnlSetMaster.SuspendLayout();
                this.panel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdFolio)).BeginInit();
                this.panel2.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pctBell)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pctBell2)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pctCombined)).BeginInit();
                this.SuspendLayout();
                // 
                // btnCancelReservation
                // 
                this.btnCancelReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCancelReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnCancelReservation.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCancelReservation.Enabled = false;
                this.btnCancelReservation.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnCancelReservation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCancelReservation.Location = new System.Drawing.Point(738, 601);
                this.btnCancelReservation.Name = "btnCancelReservation";
                this.btnCancelReservation.Size = new System.Drawing.Size(112, 31);
                this.btnCancelReservation.TabIndex = 6;
                this.btnCancelReservation.Text = "C&ancel Reservation";
                this.btnCancelReservation.UseVisualStyleBackColor = false;
                this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
                // 
                // txtfname
                // 
                this.txtfname.Location = new System.Drawing.Point(160, 298);
                this.txtfname.Name = "txtfname";
                this.txtfname.Size = new System.Drawing.Size(100, 20);
                this.txtfname.TabIndex = 16;
                // 
                // txtlname
                // 
                this.txtlname.Location = new System.Drawing.Point(274, 298);
                this.txtlname.Name = "txtlname";
                this.txtlname.Size = new System.Drawing.Size(100, 20);
                this.txtlname.TabIndex = 17;
                // 
                // cmuPopUp
                // 
                this.cmuPopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmuEditReservation,
            this.cmuMarketing,
            this.cmuEvent,
            this.cmuAddNewReservation,
            this.toolStripMenuItem1,
            this.cmuConfirmed,
            this.cmuNowShow,
            this.cmuCancel,
            this.toolStripMenuItem3,
            this.cmdRefresh,
            this.toolStripMenuItem4,
            this.cmuCheckIn,
            this.cmuCheckOut});
                this.cmuPopUp.Name = "cmuPopUp";
                this.cmuPopUp.Size = new System.Drawing.Size(226, 242);
                // 
                // cmuEditReservation
                // 
                this.cmuEditReservation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.cmuEditReservation.Name = "cmuEditReservation";
                this.cmuEditReservation.Size = new System.Drawing.Size(225, 22);
                this.cmuEditReservation.Text = "Edit/View Reservation Info";
                this.cmuEditReservation.Click += new System.EventHandler(this.cmuEditReservation_Click);
                // 
                // cmuMarketing
                // 
                this.cmuMarketing.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.cmuMarketing.Name = "cmuMarketing";
                this.cmuMarketing.Size = new System.Drawing.Size(225, 22);
                this.cmuMarketing.Text = "Edit/View Market Info";
                this.cmuMarketing.Click += new System.EventHandler(this.cmuMarketing_Click);
                // 
                // cmuEvent
                // 
                this.cmuEvent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.cmuEvent.Name = "cmuEvent";
                this.cmuEvent.Size = new System.Drawing.Size(225, 22);
                this.cmuEvent.Text = "Edit/View Event";
                this.cmuEvent.Click += new System.EventHandler(this.cmuEvent_Click);
                // 
                // cmuAddNewReservation
                // 
                this.cmuAddNewReservation.Name = "cmuAddNewReservation";
                this.cmuAddNewReservation.Size = new System.Drawing.Size(225, 22);
                this.cmuAddNewReservation.Text = "Add New Reservation";
                this.cmuAddNewReservation.Click += new System.EventHandler(this.cmuAddNewReservation_Click);
                // 
                // toolStripMenuItem1
                // 
                this.toolStripMenuItem1.Name = "toolStripMenuItem1";
                this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 6);
                // 
                // cmuConfirmed
                // 
                this.cmuConfirmed.Enabled = false;
                this.cmuConfirmed.Name = "cmuConfirmed";
                this.cmuConfirmed.Size = new System.Drawing.Size(225, 22);
                this.cmuConfirmed.Text = "Set as \"Confirmed\"";
                this.cmuConfirmed.Click += new System.EventHandler(this.cmuConfirmed_Click);
                // 
                // cmuNowShow
                // 
                this.cmuNowShow.Enabled = false;
                this.cmuNowShow.Name = "cmuNowShow";
                this.cmuNowShow.Size = new System.Drawing.Size(225, 22);
                this.cmuNowShow.Text = "Set as \"No Show\"";
                this.cmuNowShow.Click += new System.EventHandler(this.cmuNowShow_Click);
                // 
                // cmuCancel
                // 
                this.cmuCancel.Enabled = false;
                this.cmuCancel.Name = "cmuCancel";
                this.cmuCancel.Size = new System.Drawing.Size(225, 22);
                this.cmuCancel.Text = "Cancel Reservation";
                this.cmuCancel.Click += new System.EventHandler(this.cmuCancel_Click);
                // 
                // toolStripMenuItem3
                // 
                this.toolStripMenuItem3.Name = "toolStripMenuItem3";
                this.toolStripMenuItem3.Size = new System.Drawing.Size(222, 6);
                // 
                // cmdRefresh
                // 
                this.cmdRefresh.Name = "cmdRefresh";
                this.cmdRefresh.Size = new System.Drawing.Size(225, 22);
                this.cmdRefresh.Text = "Refresh";
                this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
                // 
                // toolStripMenuItem4
                // 
                this.toolStripMenuItem4.Name = "toolStripMenuItem4";
                this.toolStripMenuItem4.Size = new System.Drawing.Size(222, 6);
                // 
                // cmuCheckIn
                // 
                this.cmuCheckIn.Enabled = false;
                this.cmuCheckIn.Name = "cmuCheckIn";
                this.cmuCheckIn.Size = new System.Drawing.Size(225, 22);
                this.cmuCheckIn.Text = "Check In";
                this.cmuCheckIn.Click += new System.EventHandler(this.cmuCheckIn_Click);
                // 
                // cmuCheckOut
                // 
                this.cmuCheckOut.Enabled = false;
                this.cmuCheckOut.Name = "cmuCheckOut";
                this.cmuCheckOut.Size = new System.Drawing.Size(225, 22);
                this.cmuCheckOut.Text = "Check Out";
                this.cmuCheckOut.Click += new System.EventHandler(this.cmuCheckOut_Click);
                // 
                // btnCheckedIn
                // 
                this.btnCheckedIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCheckedIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnCheckedIn.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCheckedIn.Enabled = false;
                this.btnCheckedIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnCheckedIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCheckedIn.Location = new System.Drawing.Point(997, 601);
                this.btnCheckedIn.Name = "btnCheckedIn";
                this.btnCheckedIn.Size = new System.Drawing.Size(66, 31);
                this.btnCheckedIn.TabIndex = 9;
                this.btnCheckedIn.Text = "Start Event";
                this.btnCheckedIn.UseVisualStyleBackColor = false;
                this.btnCheckedIn.Click += new System.EventHandler(this.btnCheckIn_Click);
                // 
                // btnCheckedOut
                // 
                this.btnCheckedOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCheckedOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnCheckedOut.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCheckedOut.Enabled = false;
                this.btnCheckedOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnCheckedOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCheckedOut.Location = new System.Drawing.Point(926, 601);
                this.btnCheckedOut.Name = "btnCheckedOut";
                this.btnCheckedOut.Size = new System.Drawing.Size(66, 31);
                this.btnCheckedOut.TabIndex = 8;
                this.btnCheckedOut.Text = "End Event";
                this.btnCheckedOut.UseVisualStyleBackColor = false;
                this.btnCheckedOut.Click += new System.EventHandler(this.btnCheckOUt_Click);
                // 
                // btnNoShow
                // 
                this.btnNoShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnNoShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnNoShow.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnNoShow.Enabled = false;
                this.btnNoShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnNoShow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnNoShow.Location = new System.Drawing.Point(855, 601);
                this.btnNoShow.Name = "btnNoShow";
                this.btnNoShow.Size = new System.Drawing.Size(66, 31);
                this.btnNoShow.TabIndex = 7;
                this.btnNoShow.Text = "&No Show";
                this.btnNoShow.UseVisualStyleBackColor = false;
                this.btnNoShow.Click += new System.EventHandler(this.btnNoSHow_Click);
                // 
                // btnConfirmed
                // 
                this.btnConfirmed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnConfirmed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnConfirmed.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnConfirmed.Enabled = false;
                this.btnConfirmed.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnConfirmed.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnConfirmed.Location = new System.Drawing.Point(1068, 601);
                this.btnConfirmed.Name = "btnConfirmed";
                this.btnConfirmed.Size = new System.Drawing.Size(66, 31);
                this.btnConfirmed.TabIndex = 10;
                this.btnConfirmed.Text = "&Confirm";
                this.btnConfirmed.UseVisualStyleBackColor = false;
                this.btnConfirmed.Click += new System.EventHandler(this.btnConfirm_Click);
                // 
                // btnClose
                // 
                this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(1139, 601);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 191;
                this.btnClose.Text = "C&lose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // Label2
                // 
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.Location = new System.Drawing.Point(199, 58);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(40, 14);
                this.Label2.TabIndex = 13;
                this.Label2.Text = "Status";
                // 
                // Label3
                // 
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label3.Location = new System.Drawing.Point(532, 59);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(57, 14);
                this.Label3.TabIndex = 13;
                this.Label3.Text = "Folio Type";
                // 
                // Label1
                // 
                this.Label1.Location = new System.Drawing.Point(5, 59);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(52, 15);
                this.Label1.TabIndex = 2;
                this.Label1.Text = "Search:";
                // 
                // pnlSetMaster
                // 
                this.pnlSetMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.pnlSetMaster.Controls.Add(this.btnSelectMaster);
                this.pnlSetMaster.Location = new System.Drawing.Point(938, 42);
                this.pnlSetMaster.Name = "pnlSetMaster";
                this.pnlSetMaster.Size = new System.Drawing.Size(120, 36);
                this.pnlSetMaster.TabIndex = 0;
                this.pnlSetMaster.Visible = false;
                // 
                // btnSelectMaster
                // 
                this.btnSelectMaster.BackColor = System.Drawing.SystemColors.GrayText;
                this.btnSelectMaster.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnSelectMaster.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnSelectMaster.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSelectMaster.ForeColor = System.Drawing.Color.White;
                this.btnSelectMaster.Location = new System.Drawing.Point(26, 4);
                this.btnSelectMaster.Name = "btnSelectMaster";
                this.btnSelectMaster.Size = new System.Drawing.Size(66, 26);
                this.btnSelectMaster.TabIndex = 5;
                this.btnSelectMaster.Text = "&Select";
                this.btnSelectMaster.UseVisualStyleBackColor = false;
                this.btnSelectMaster.Click += new System.EventHandler(this.btnSelectMaster_Click);
                // 
                // txtSearch
                // 
                this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSearch.Location = new System.Drawing.Point(59, 58);
                this.txtSearch.Name = "txtSearch";
                this.txtSearch.Size = new System.Drawing.Size(134, 20);
                this.txtSearch.TabIndex = 1;
                this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
                this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
                // 
                // panel1
                // 
                this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel1.Controls.Add(this.label15);
                this.panel1.Controls.Add(this.lblTotalGroupWaitList);
                this.panel1.Controls.Add(this.label11);
                this.panel1.Controls.Add(this.lblTotalWaitList);
                this.panel1.Controls.Add(this.lbl13);
                this.panel1.Controls.Add(this.lblHighBalance);
                this.panel1.Controls.Add(this.label4);
                this.panel1.Controls.Add(this.lblTotalReservations);
                this.panel1.Controls.Add(this.label14);
                this.panel1.Controls.Add(this.lblTotalNoShow);
                this.panel1.Controls.Add(this.label9);
                this.panel1.Controls.Add(this.lblTotalCancelled);
                this.panel1.Controls.Add(this.lblTotalCheckedOut);
                this.panel1.Controls.Add(this.lblTotalCheckedIn);
                this.panel1.Controls.Add(this.label12);
                this.panel1.Controls.Add(this.Label6);
                this.panel1.Controls.Add(this.lblTotalExpectedCheckIn);
                this.panel1.Controls.Add(this.label5);
                this.panel1.Controls.Add(this.lblTotalExpectedCheckOut);
                this.panel1.Controls.Add(this.Label7);
                this.panel1.Controls.Add(this.Label10);
                this.panel1.Controls.Add(this.lblTotalForNoShow);
                this.panel1.Controls.Add(this.lblTotalOverstaying);
                this.panel1.Controls.Add(this.Label8);
                this.panel1.Location = new System.Drawing.Point(6, 143);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(1198, 60);
                this.panel1.TabIndex = 1;
                this.panel1.Visible = false;
                // 
                // label15
                // 
                this.label15.ForeColor = System.Drawing.Color.Red;
                this.label15.Location = new System.Drawing.Point(652, 35);
                this.label15.Name = "label15";
                this.label15.Size = new System.Drawing.Size(117, 14);
                this.label15.TabIndex = 52;
                this.label15.Text = "Total Group Wait List";
                // 
                // lblTotalGroupWaitList
                // 
                this.lblTotalGroupWaitList.BackColor = System.Drawing.Color.PapayaWhip;
                this.lblTotalGroupWaitList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalGroupWaitList.Cursor = System.Windows.Forms.Cursors.Default;
                this.lblTotalGroupWaitList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalGroupWaitList.ForeColor = System.Drawing.Color.Red;
                this.lblTotalGroupWaitList.Location = new System.Drawing.Point(611, 32);
                this.lblTotalGroupWaitList.Name = "lblTotalGroupWaitList";
                this.lblTotalGroupWaitList.Size = new System.Drawing.Size(35, 20);
                this.lblTotalGroupWaitList.TabIndex = 51;
                this.lblTotalGroupWaitList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblTotalGroupWaitList.Click += new System.EventHandler(this.lblTotalGroupWaitList_Click);
                this.lblTotalGroupWaitList.MouseHover += new System.EventHandler(this.lblTotalGroupWaitList_MouseHover);
                // 
                // label11
                // 
                this.label11.ForeColor = System.Drawing.Color.Red;
                this.label11.Location = new System.Drawing.Point(652, 9);
                this.label11.Name = "label11";
                this.label11.Size = new System.Drawing.Size(86, 14);
                this.label11.TabIndex = 50;
                this.label11.Text = "Total Wait List";
                // 
                // lblTotalWaitList
                // 
                this.lblTotalWaitList.BackColor = System.Drawing.Color.White;
                this.lblTotalWaitList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalWaitList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalWaitList.ForeColor = System.Drawing.Color.Red;
                this.lblTotalWaitList.Location = new System.Drawing.Point(611, 6);
                this.lblTotalWaitList.Name = "lblTotalWaitList";
                this.lblTotalWaitList.Size = new System.Drawing.Size(35, 20);
                this.lblTotalWaitList.TabIndex = 49;
                this.lblTotalWaitList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // lbl13
                // 
                this.lbl13.Location = new System.Drawing.Point(882, 9);
                this.lbl13.Name = "lbl13";
                this.lbl13.Size = new System.Drawing.Size(86, 14);
                this.lbl13.TabIndex = 48;
                this.lbl13.Text = "High Balance";
                // 
                // lblHighBalance
                // 
                this.lblHighBalance.BackColor = System.Drawing.Color.White;
                this.lblHighBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblHighBalance.Cursor = System.Windows.Forms.Cursors.Hand;
                this.lblHighBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblHighBalance.ForeColor = System.Drawing.Color.Red;
                this.lblHighBalance.Location = new System.Drawing.Point(841, 6);
                this.lblHighBalance.Name = "lblHighBalance";
                this.lblHighBalance.Size = new System.Drawing.Size(35, 20);
                this.lblHighBalance.TabIndex = 47;
                this.lblHighBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblHighBalance.Click += new System.EventHandler(this.lblHighBalance_Click);
                // 
                // label4
                // 
                this.label4.Location = new System.Drawing.Point(374, 9);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(97, 14);
                this.label4.TabIndex = 46;
                this.label4.Text = "Total Reservations";
                // 
                // lblTotalReservations
                // 
                this.lblTotalReservations.BackColor = System.Drawing.Color.White;
                this.lblTotalReservations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalReservations.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalReservations.Location = new System.Drawing.Point(335, 6);
                this.lblTotalReservations.Name = "lblTotalReservations";
                this.lblTotalReservations.Size = new System.Drawing.Size(35, 20);
                this.lblTotalReservations.TabIndex = 45;
                this.lblTotalReservations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // label14
                // 
                this.label14.Location = new System.Drawing.Point(514, 35);
                this.label14.Name = "label14";
                this.label14.Size = new System.Drawing.Size(86, 14);
                this.label14.TabIndex = 44;
                this.label14.Text = "Total No Show";
                // 
                // lblTotalNoShow
                // 
                this.lblTotalNoShow.BackColor = System.Drawing.Color.White;
                this.lblTotalNoShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalNoShow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalNoShow.Location = new System.Drawing.Point(473, 32);
                this.lblTotalNoShow.Name = "lblTotalNoShow";
                this.lblTotalNoShow.Size = new System.Drawing.Size(35, 20);
                this.lblTotalNoShow.TabIndex = 43;
                this.lblTotalNoShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // label9
                // 
                this.label9.Location = new System.Drawing.Point(374, 35);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(86, 14);
                this.label9.TabIndex = 42;
                this.label9.Text = "Total Cancelled";
                // 
                // lblTotalCancelled
                // 
                this.lblTotalCancelled.BackColor = System.Drawing.Color.White;
                this.lblTotalCancelled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalCancelled.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalCancelled.Location = new System.Drawing.Point(335, 32);
                this.lblTotalCancelled.Name = "lblTotalCancelled";
                this.lblTotalCancelled.Size = new System.Drawing.Size(35, 20);
                this.lblTotalCancelled.TabIndex = 41;
                this.lblTotalCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // lblTotalCheckedOut
                // 
                this.lblTotalCheckedOut.BackColor = System.Drawing.Color.White;
                this.lblTotalCheckedOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalCheckedOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalCheckedOut.Location = new System.Drawing.Point(167, 32);
                this.lblTotalCheckedOut.Name = "lblTotalCheckedOut";
                this.lblTotalCheckedOut.Size = new System.Drawing.Size(35, 20);
                this.lblTotalCheckedOut.TabIndex = 39;
                this.lblTotalCheckedOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // lblTotalCheckedIn
                // 
                this.lblTotalCheckedIn.BackColor = System.Drawing.Color.White;
                this.lblTotalCheckedIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalCheckedIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalCheckedIn.Location = new System.Drawing.Point(9, 32);
                this.lblTotalCheckedIn.Name = "lblTotalCheckedIn";
                this.lblTotalCheckedIn.Size = new System.Drawing.Size(35, 20);
                this.lblTotalCheckedIn.TabIndex = 37;
                this.lblTotalCheckedIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // label12
                // 
                this.label12.Location = new System.Drawing.Point(207, 35);
                this.label12.Name = "label12";
                this.label12.Size = new System.Drawing.Size(102, 14);
                this.label12.TabIndex = 40;
                this.label12.Text = "Total closed";
                // 
                // Label6
                // 
                this.Label6.Location = new System.Drawing.Point(48, 9);
                this.Label6.Name = "Label6";
                this.Label6.Size = new System.Drawing.Size(108, 14);
                this.Label6.TabIndex = 27;
                this.Label6.Text = "Expected Event";
                // 
                // lblTotalExpectedCheckIn
                // 
                this.lblTotalExpectedCheckIn.BackColor = System.Drawing.Color.LightSkyBlue;
                this.lblTotalExpectedCheckIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalExpectedCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
                this.lblTotalExpectedCheckIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalExpectedCheckIn.Location = new System.Drawing.Point(9, 6);
                this.lblTotalExpectedCheckIn.Name = "lblTotalExpectedCheckIn";
                this.lblTotalExpectedCheckIn.Size = new System.Drawing.Size(35, 20);
                this.lblTotalExpectedCheckIn.TabIndex = 24;
                this.lblTotalExpectedCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblTotalExpectedCheckIn.Click += new System.EventHandler(this.lblTotalExpectedCheckIn_Click);
                // 
                // label5
                // 
                this.label5.Location = new System.Drawing.Point(48, 35);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(91, 14);
                this.label5.TabIndex = 38;
                this.label5.Text = "Total Ongoing";
                // 
                // lblTotalExpectedCheckOut
                // 
                this.lblTotalExpectedCheckOut.BackColor = System.Drawing.Color.PaleGreen;
                this.lblTotalExpectedCheckOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalExpectedCheckOut.Cursor = System.Windows.Forms.Cursors.Hand;
                this.lblTotalExpectedCheckOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalExpectedCheckOut.Location = new System.Drawing.Point(167, 6);
                this.lblTotalExpectedCheckOut.Name = "lblTotalExpectedCheckOut";
                this.lblTotalExpectedCheckOut.Size = new System.Drawing.Size(35, 20);
                this.lblTotalExpectedCheckOut.TabIndex = 25;
                this.lblTotalExpectedCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblTotalExpectedCheckOut.Click += new System.EventHandler(this.lblTotalExpectedCheckOut_Click);
                // 
                // Label7
                // 
                this.Label7.Location = new System.Drawing.Point(207, 9);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(112, 14);
                this.Label7.TabIndex = 28;
                this.Label7.Text = "Expected Close";
                // 
                // Label10
                // 
                this.Label10.Location = new System.Drawing.Point(883, 34);
                this.Label10.Name = "Label10";
                this.Label10.Size = new System.Drawing.Size(61, 14);
                this.Label10.TabIndex = 32;
                this.Label10.Text = "Overstay";
                this.Label10.Visible = false;
                // 
                // lblTotalForNoShow
                // 
                this.lblTotalForNoShow.BackColor = System.Drawing.Color.Gainsboro;
                this.lblTotalForNoShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalForNoShow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalForNoShow.Location = new System.Drawing.Point(473, 6);
                this.lblTotalForNoShow.Name = "lblTotalForNoShow";
                this.lblTotalForNoShow.Size = new System.Drawing.Size(35, 20);
                this.lblTotalForNoShow.TabIndex = 26;
                this.lblTotalForNoShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // lblTotalOverstaying
                // 
                this.lblTotalOverstaying.BackColor = System.Drawing.Color.Red;
                this.lblTotalOverstaying.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.lblTotalOverstaying.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblTotalOverstaying.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                this.lblTotalOverstaying.Location = new System.Drawing.Point(842, 31);
                this.lblTotalOverstaying.Name = "lblTotalOverstaying";
                this.lblTotalOverstaying.Size = new System.Drawing.Size(35, 20);
                this.lblTotalOverstaying.TabIndex = 31;
                this.lblTotalOverstaying.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblTotalOverstaying.Visible = false;
                // 
                // Label8
                // 
                this.Label8.Location = new System.Drawing.Point(514, 9);
                this.Label8.Name = "Label8";
                this.Label8.Size = new System.Drawing.Size(79, 14);
                this.Label8.TabIndex = 29;
                this.Label8.Text = "For No Show";
                // 
                // cboReservationStatus
                // 
                this.cboReservationStatus.Items.AddRange(new object[] {
            "ALL",
            "ONGOING",
            "CONFIRMED",
            "TENTATIVE",
            "WAIT LIST",
            "ALL RESERVATIONS",
            "CLOSED",
            "NO SHOW",
            "CANCELLED"});
                this.cboReservationStatus.Location = new System.Drawing.Point(256, 57);
                this.cboReservationStatus.MaxDropDownItems = 10;
                this.cboReservationStatus.Name = "cboReservationStatus";
                this.cboReservationStatus.Size = new System.Drawing.Size(122, 22);
                this.cboReservationStatus.TabIndex = 2;
                this.cboReservationStatus.Text = "ONGOING";
                this.cboReservationStatus.SelectedIndexChanged += new System.EventHandler(this.cboReservationStatus_SelectedIndexChanged);
                this.cboReservationStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboReservationStatus_KeyPress);
                // 
                // cboFolioType
                // 
                this.cboFolioType.Items.AddRange(new object[] {
            "ALL",
            "INDIVIDUAL",
            "GROUP",
            "DEPENDENT",
            "SHARE",
            "JOINER",
            "INDIVIDUAL + DEPENDENT"});
                this.cboFolioType.Location = new System.Drawing.Point(595, 56);
                this.cboFolioType.Name = "cboFolioType";
                this.cboFolioType.Size = new System.Drawing.Size(127, 22);
                this.cboFolioType.TabIndex = 3;
                this.cboFolioType.Text = "ALL";
                this.cboFolioType.SelectedIndexChanged += new System.EventHandler(this.cboFolioType_SelectedIndexChanged);
                this.cboFolioType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboFolioType_KeyPress);
                // 
                // GroupBox1
                // 
                this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.GroupBox1.Location = new System.Drawing.Point(6, 33);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(1198, 7);
                this.GroupBox1.TabIndex = 0;
                this.GroupBox1.TabStop = false;
                // 
                // btnInsert
                // 
                this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.btnInsert.BackColor = System.Drawing.SystemColors.GrayText;
                this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnInsert.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnInsert.ForeColor = System.Drawing.Color.White;
                this.btnInsert.Location = new System.Drawing.Point(942, 50);
                this.btnInsert.Name = "btnInsert";
                this.btnInsert.Size = new System.Drawing.Size(111, 22);
                this.btnInsert.TabIndex = 4;
                this.btnInsert.Text = "&New Reservation";
                this.btnInsert.UseVisualStyleBackColor = false;
                this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
                // 
                // grdFolio
                // 
                this.grdFolio.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
                this.grdFolio.AllowEditing = false;
                this.grdFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.grdFolio.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
                this.grdFolio.ColumnInfo = resources.GetString("grdFolio.ColumnInfo");
                this.grdFolio.ContextMenuStrip = this.cmuPopUp;
                this.grdFolio.Location = new System.Drawing.Point(6, 143);
                this.grdFolio.Name = "grdFolio";
                this.grdFolio.Rows.Count = 1;
                this.grdFolio.Rows.DefaultSize = 17;
                this.grdFolio.Rows.MinSize = 20;
                this.grdFolio.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
                this.grdFolio.Size = new System.Drawing.Size(1198, 450);
                this.grdFolio.StyleInfo = resources.GetString("grdFolio.StyleInfo");
                this.grdFolio.TabIndex = 6;
                this.grdFolio.Click += new System.EventHandler(this.grdFolio_Click);
                this.grdFolio.DoubleClick += new System.EventHandler(this.grdFolio_DoubleClick);
                this.grdFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFolio_KeyPress);
                this.grdFolio.RowColChange += new System.EventHandler(this.grdFolio_RowColChange);
                // 
                // btnCreateLetter
                // 
                this.btnCreateLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnCreateLetter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnCreateLetter.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCreateLetter.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnCreateLetter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCreateLetter.Location = new System.Drawing.Point(5, 601);
                this.btnCreateLetter.Name = "btnCreateLetter";
                this.btnCreateLetter.Size = new System.Drawing.Size(90, 31);
                this.btnCreateLetter.TabIndex = 192;
                this.btnCreateLetter.Text = "Create Le&tter";
                this.btnCreateLetter.UseVisualStyleBackColor = false;
                this.btnCreateLetter.Click += new System.EventHandler(this.btnCreateLetter_Click);
                // 
                // btnPrintRegCard
                // 
                this.btnPrintRegCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnPrintRegCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnPrintRegCard.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnPrintRegCard.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnPrintRegCard.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnPrintRegCard.Location = new System.Drawing.Point(98, 601);
                this.btnPrintRegCard.Name = "btnPrintRegCard";
                this.btnPrintRegCard.Size = new System.Drawing.Size(115, 31);
                this.btnPrintRegCard.TabIndex = 193;
                this.btnPrintRegCard.Text = "Print &Registration Card";
                this.btnPrintRegCard.UseVisualStyleBackColor = false;
                this.btnPrintRegCard.Click += new System.EventHandler(this.btnPrintRegCard_Click);
                // 
                // label13
                // 
                this.label13.AutoSize = true;
                this.label13.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label13.Location = new System.Drawing.Point(10, 11);
                this.label13.Name = "label13";
                this.label13.Size = new System.Drawing.Size(96, 22);
                this.label13.TabIndex = 194;
                this.label13.Text = "Guest List";
                // 
                // bgwLoadAllFolio
                // 
                this.bgwLoadAllFolio.WorkerReportsProgress = true;
                // 
                // bgwLegendValues
                // 
                this.bgwLegendValues.WorkerReportsProgress = true;
                // 
                // txtFilter
                // 
                this.txtFilter.Location = new System.Drawing.Point(59, 109);
                this.txtFilter.Name = "txtFilter";
                this.txtFilter.Size = new System.Drawing.Size(134, 20);
                this.txtFilter.TabIndex = 196;
                this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
                // 
                // label16
                // 
                this.label16.AutoSize = true;
                this.label16.Location = new System.Drawing.Point(12, 112);
                this.label16.Name = "label16";
                this.label16.Size = new System.Drawing.Size(33, 14);
                this.label16.TabIndex = 197;
                this.label16.Text = "Filter:";
                // 
                // label17
                // 
                this.label17.AutoSize = true;
                this.label17.Location = new System.Drawing.Point(199, 112);
                this.label17.Name = "label17";
                this.label17.Size = new System.Drawing.Size(51, 14);
                this.label17.TabIndex = 198;
                this.label17.Text = "Category";
                // 
                // cboCategory
                // 
                this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboCategory.FormattingEnabled = true;
                this.cboCategory.Location = new System.Drawing.Point(256, 107);
                this.cboCategory.Name = "cboCategory";
                this.cboCategory.Size = new System.Drawing.Size(122, 22);
                this.cboCategory.TabIndex = 199;
                this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
                // 
                // groupBox2
                // 
                this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.groupBox2.Location = new System.Drawing.Point(8, 89);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(1198, 7);
                this.groupBox2.TabIndex = 200;
                this.groupBox2.TabStop = false;
                // 
                // label18
                // 
                this.label18.AutoSize = true;
                this.label18.Location = new System.Drawing.Point(3, 1);
                this.label18.Name = "label18";
                this.label18.Size = new System.Drawing.Size(49, 14);
                this.label18.TabIndex = 203;
                this.label18.Text = "Legend :";
                // 
                // label19
                // 
                this.label19.AutoSize = true;
                this.label19.Location = new System.Drawing.Point(105, 19);
                this.label19.Name = "label19";
                this.label19.Size = new System.Drawing.Size(49, 14);
                this.label19.TabIndex = 204;
                this.label19.Text = "Remarks";
                // 
                // label20
                // 
                this.label20.AutoSize = true;
                this.label20.Location = new System.Drawing.Point(267, 19);
                this.label20.Name = "label20";
                this.label20.Size = new System.Drawing.Size(80, 14);
                this.label20.TabIndex = 205;
                this.label20.Text = "To be amended";
                // 
                // panel2
                // 
                this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel2.Controls.Add(this.txtNumAmended);
                this.panel2.Controls.Add(this.txtNumRemarks);
                this.panel2.Controls.Add(this.label22);
                this.panel2.Controls.Add(this.label19);
                this.panel2.Controls.Add(this.label20);
                this.panel2.Controls.Add(this.pctBell);
                this.panel2.Controls.Add(this.label18);
                this.panel2.Controls.Add(this.pctBell2);
                this.panel2.Location = new System.Drawing.Point(474, 42);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(589, 46);
                this.panel2.TabIndex = 206;
                // 
                // txtNumAmended
                // 
                this.txtNumAmended.Enabled = false;
                this.txtNumAmended.Location = new System.Drawing.Point(353, 15);
                this.txtNumAmended.Name = "txtNumAmended";
                this.txtNumAmended.Size = new System.Drawing.Size(58, 20);
                this.txtNumAmended.TabIndex = 211;
                this.txtNumAmended.Text = "00";
                // 
                // txtNumRemarks
                // 
                this.txtNumRemarks.Enabled = false;
                this.txtNumRemarks.Location = new System.Drawing.Point(160, 15);
                this.txtNumRemarks.Name = "txtNumRemarks";
                this.txtNumRemarks.Size = new System.Drawing.Size(58, 20);
                this.txtNumRemarks.TabIndex = 210;
                this.txtNumRemarks.Text = "00";
                // 
                // label22
                // 
                this.label22.AutoSize = true;
                this.label22.ForeColor = System.Drawing.Color.Red;
                this.label22.Location = new System.Drawing.Point(174, -3);
                this.label22.Name = "label22";
                this.label22.Size = new System.Drawing.Size(123, 14);
                this.label22.TabIndex = 209;
                this.label22.Text = "Object are hidden under";
                this.label22.Visible = false;
                // 
                // pctBell
                // 
                this.pctBell.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.Clipboard_Information;
                this.pctBell.Location = new System.Drawing.Point(81, 17);
                this.pctBell.Name = "pctBell";
                this.pctBell.Size = new System.Drawing.Size(18, 18);
                this.pctBell.TabIndex = 195;
                this.pctBell.TabStop = false;
                // 
                // pctBell2
                // 
                this.pctBell2.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.bell_png;
                this.pctBell2.Location = new System.Drawing.Point(243, 17);
                this.pctBell2.Name = "pctBell2";
                this.pctBell2.Size = new System.Drawing.Size(18, 18);
                this.pctBell2.TabIndex = 201;
                this.pctBell2.TabStop = false;
                // 
                // btnExportToExcel
                // 
                this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.btnExportToExcel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnExportToExcel.Location = new System.Drawing.Point(215, 601);
                this.btnExportToExcel.Name = "btnExportToExcel";
                this.btnExportToExcel.Size = new System.Drawing.Size(100, 31);
                this.btnExportToExcel.TabIndex = 207;
                this.btnExportToExcel.Text = "&Export To Excel";
                this.btnExportToExcel.UseVisualStyleBackColor = false;
                this.btnExportToExcel.Visible = false;
                this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
                // 
                // pctCombined
                // 
                this.pctCombined.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.combined;
                this.pctCombined.Location = new System.Drawing.Point(415, 411);
                this.pctCombined.Name = "pctCombined";
                this.pctCombined.Size = new System.Drawing.Size(36, 18);
                this.pctCombined.TabIndex = 202;
                this.pctCombined.TabStop = false;
                // 
                // label21
                // 
                this.label21.AutoSize = true;
                this.label21.Location = new System.Drawing.Point(384, 110);
                this.label21.Name = "label21";
                this.label21.Size = new System.Drawing.Size(90, 14);
                this.label21.TabIndex = 208;
                this.label21.Text = "Marketing Officer";
                // 
                // cboMarketingOfficer
                // 
                this.cboMarketingOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboMarketingOfficer.FormattingEnabled = true;
                this.cboMarketingOfficer.Location = new System.Drawing.Point(480, 107);
                this.cboMarketingOfficer.Name = "cboMarketingOfficer";
                this.cboMarketingOfficer.Size = new System.Drawing.Size(134, 22);
                this.cboMarketingOfficer.TabIndex = 209;
                this.cboMarketingOfficer.SelectedIndexChanged += new System.EventHandler(this.cboMarketingOfficer_SelectedIndexChanged);
                // 
                // cboEventOfficer
                // 
                this.cboEventOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboEventOfficer.FormattingEnabled = true;
                this.cboEventOfficer.Location = new System.Drawing.Point(697, 107);
                this.cboEventOfficer.Name = "cboEventOfficer";
                this.cboEventOfficer.Size = new System.Drawing.Size(142, 22);
                this.cboEventOfficer.TabIndex = 210;
                this.cboEventOfficer.SelectedIndexChanged += new System.EventHandler(this.cboEventOfficer_SelectedIndexChanged);
                // 
                // label23
                // 
                this.label23.AutoSize = true;
                this.label23.Location = new System.Drawing.Point(620, 112);
                this.label23.Name = "label23";
                this.label23.Size = new System.Drawing.Size(71, 14);
                this.label23.TabIndex = 211;
                this.label23.Text = "Event Officer";
                // 
                // dtpTo
                // 
                this.dtpTo.CustomFormat = "MMM dd, yyyy";
                this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpTo.Location = new System.Drawing.Point(913, 119);
                this.dtpTo.Name = "dtpTo";
                this.dtpTo.Size = new System.Drawing.Size(120, 20);
                this.dtpTo.TabIndex = 214;
                this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
                // 
                // label24
                // 
                this.label24.AutoSize = true;
                this.label24.Location = new System.Drawing.Point(870, 103);
                this.label24.Name = "label24";
                this.label24.Size = new System.Drawing.Size(37, 14);
                this.label24.TabIndex = 213;
                this.label24.Text = "From: ";
                // 
                // dtpFrom
                // 
                this.dtpFrom.CustomFormat = "MMM dd, yyyy";
                this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpFrom.Location = new System.Drawing.Point(913, 98);
                this.dtpFrom.Name = "dtpFrom";
                this.dtpFrom.Size = new System.Drawing.Size(121, 20);
                this.dtpFrom.TabIndex = 212;
                this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
                // 
                // label25
                // 
                this.label25.AutoSize = true;
                this.label25.Location = new System.Drawing.Point(870, 123);
                this.label25.Name = "label25";
                this.label25.Size = new System.Drawing.Size(21, 14);
                this.label25.TabIndex = 215;
                this.label25.Text = "To:";
                // 
                // chkDateFilter
                // 
                this.chkDateFilter.AutoSize = true;
                this.chkDateFilter.Location = new System.Drawing.Point(855, 107);
                this.chkDateFilter.Name = "chkDateFilter";
                this.chkDateFilter.Size = new System.Drawing.Size(15, 14);
                this.chkDateFilter.TabIndex = 216;
                this.chkDateFilter.UseVisualStyleBackColor = true;
                this.chkDateFilter.CheckedChanged += new System.EventHandler(this.chkDateFilter_CheckedChanged);
                // 
                // btnShow
                // 
                this.btnShow.Location = new System.Drawing.Point(1040, 101);
                this.btnShow.Name = "btnShow";
                this.btnShow.Size = new System.Drawing.Size(60, 33);
                this.btnShow.TabIndex = 217;
                this.btnShow.Text = "Show";
                this.btnShow.UseVisualStyleBackColor = true;
                this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
                // 
                // ReservationListUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.BackColor = System.Drawing.SystemColors.Control;
                this.ClientSize = new System.Drawing.Size(1211, 645);
                this.Controls.Add(this.panel2);
                this.Controls.Add(this.btnShow);
                this.Controls.Add(this.chkDateFilter);
                this.Controls.Add(this.label25);
                this.Controls.Add(this.dtpTo);
                this.Controls.Add(this.label24);
                this.Controls.Add(this.dtpFrom);
                this.Controls.Add(this.pnlSetMaster);
                this.Controls.Add(this.btnInsert);
                this.Controls.Add(this.label23);
                this.Controls.Add(this.cboEventOfficer);
                this.Controls.Add(this.btnExportToExcel);
                this.Controls.Add(this.grdFolio);
                this.Controls.Add(this.cboMarketingOfficer);
                this.Controls.Add(this.label21);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.label16);
                this.Controls.Add(this.txtFilter);
                this.Controls.Add(this.label13);
                this.Controls.Add(this.label17);
                this.Controls.Add(this.cboFolioType);
                this.Controls.Add(this.cboCategory);
                this.Controls.Add(this.GroupBox1);
                this.Controls.Add(this.txtSearch);
                this.Controls.Add(this.btnPrintRegCard);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.btnCreateLetter);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.cboReservationStatus);
                this.Controls.Add(this.Label1);
                this.Controls.Add(this.Label3);
                this.Controls.Add(this.btnConfirmed);
                this.Controls.Add(this.btnNoShow);
                this.Controls.Add(this.btnCheckedOut);
                this.Controls.Add(this.Label2);
                this.Controls.Add(this.btnCheckedIn);
                this.Controls.Add(this.btnCancelReservation);
                this.Controls.Add(this.txtfname);
                this.Controls.Add(this.txtlname);
                this.Controls.Add(this.pctCombined);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                this.Name = "ReservationListUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Guests List";
                this.Load += new System.EventHandler(this.ReservationListUI_Load);
                this.Activated += new System.EventHandler(this.ReservationListUI_Activated);
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReservationListUI_KeyDown);
                this.cmuPopUp.ResumeLayout(false);
                this.pnlSetMaster.ResumeLayout(false);
                this.panel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.grdFolio)).EndInit();
                this.panel2.ResumeLayout(false);
                this.panel2.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pctBell)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pctBell2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pctCombined)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

			}

			#endregion

			//static ReservationListUI myInstance = null;

			//public static ReservationListUI getInstance(string pStatus)
			//{
			//    if (myInstance == null)
			//    {
			//        if (pStatus == "")
			//        {
			//            myInstance = new ReservationListUI();
			//        }
			//        else
			//        {
			//            myInstance = new ReservationListUI(pStatus);
			//        }
			//    }

			//    myInstance.loadAllFolio();
			//    myInstance.cboReservationStatus_SelectedIndexChanged(myInstance, new EventArgs());
			//    myInstance.Focus();
			//    return myInstance;
			//}

			#region "OBJECTS/VARIABLES/CONSTANTS"
			//private ListViewItemComparer ListViewItemComparer = new ListViewItemComparer();

			private string lReservationStatus;
			private FormToObjectInstanceBinder oFormtoObjectBinder = new FormToObjectInstanceBinder();
			private ReservationsFacade ReservationsFacade = new ReservationsFacade();
			private RoomEventFacade oRoomEventFacade = new RoomEventFacade();
			private FolioFacade oFolioFacade = new FolioFacade();
			private ScheduleFacade _oScheduleFacade = new ScheduleFacade();

			//private string lCurrentRoom;
			//private string lBookedBy;
			//private string lCompany;
			//private string lEventName;
			//private DateTime lFromDate;
			//private DateTime lToDate;
			//private string lFolioID;
			//private decimal lFolioBalance;
			private string lFolioStatus;
			//private string lFolioType;
			//private string lAccountType;
			//private string lMasterFolio;
			//private string lPaxChild;
			//private string lTime;
			//private string lRoomsRented;
			//private string lReason;
			//private string lSalesExecutive;
			//private string lAccountId;


			private string lMode;

			#endregion

			#region "Constructors"

			public ReservationListUI()
			{
				InitializeComponent();

				loadGuestListDefaults();
				/* */
				//loadAllFolio();
				//this.picProgress.Visible = true;
				//bgwLoadAllFolio.RunWorkerAsync();
				
				//bgwLegendValues.RunWorkerAsync();

				//loadAllFolio();

				updateLegendValues();

				//cboFolioType.Text = lDefaultSelectedFoliotype;
				


				lMode = "Reservation";

				//cboRecordFilter(this.cboReservationStatus.Text);
				cboReservationStatus_SelectedIndexChanged(this, new EventArgs());
			}

		

			public ReservationListUI(string status)
			{
				InitializeComponent();

				loadGuestListDefaults();

				//bgwLoadAllFolio.RunWorkerAsync();
				//bgwLegendValues.RunWorkerAsync();
				//loadAllFolio();

				

				//cboFolioType.Text = lDefaultSelectedFoliotype;
				//cboRecordFilter(this.cboReservationStatus.Text);
				
				//this.picProgress.Visible = true;
				


				lMode = "Reservation";

				// this is to avoid re-loading of Guest
				// since "cboReservationStatus.SelectedIndexChanged" triggers
				// loading of guests
				this.cboReservationStatus.SelectedIndexChanged -= new System.EventHandler(this.cboReservationStatus_SelectedIndexChanged);
				cboReservationStatus.Text = status;
				this.cboReservationStatus.SelectedIndexChanged += new System.EventHandler(this.cboReservationStatus_SelectedIndexChanged);

				//cboRecordFilter(this.cboReservationStatus.Text);
				cboReservationStatus_SelectedIndexChanged(this, new EventArgs());

				updateLegendValues();
			}

			#endregion

			private ReservationFolioUI loFolioUI;
			private ReservationsFacade loReservationFacade = new ReservationsFacade();

			#region "Private Methods/Procedures"

			//private void mnuParent_click()
			//{
			//    // GroupReservationUI.Flag = "Edit"
			//    GroupReservationUI.ACCOUNT_TYPE = AccountType.Corporate;
			//    GroupReservationUI GroupReservationsUI = new GroupReservationUI(lMasterFolio, null);
			//    GroupReservationsUI.MdiParent = this.MdiParent;
			//    GroupReservationsUI.Top = 0;
			//    GroupReservationsUI.Left = 0;
			//    GroupReservationsUI.Show();
			//    // Me.Close()
			//}


			//private DataTable getFolio;
			//private DataTable dtAllFolio;



			private void GetListReservationList(string whrcond)
			{  
				int highBalanceCount = 0;

				// gets Current Audit Date
				DateTime auditDate = DateTime.Parse(GlobalVariables.gAuditDate);

				//DataView dtvGetFolio = getFolio.DefaultView;
				//dtvGetFolio.RowStateFilter = DataViewRowState.OriginalRows;

				//dtvGetFolio.RowFilter = whrcond;
				//getFolio = loReservationFacade.GetGuestsList(whrcond);
				DataTable dtAllFolio = loReservationFacade.GetGuestsList(whrcond);
                if ((cboCategory.Text != "" && txtFilter.Text != "") || cboMarketingOfficer.Text!="" || cboEventOfficer.Text!="")
                {
                    dtAllFolio = filterGuestList(dtAllFolio);
                }

                if (chkDateFilter.Checked)
                {
                    dtAllFolio = filterDateRange(dtAllFolio);
                }

				//if (whrcond.Contains("CONFIRMED"))
				//{
				//    dtvGetFolio.Sort = "FromDate ASC";
				//}

				FolioFacade _oFolioFacade = new FolioFacade();
				
				this.grdFolio.Rows.Count = 1;
				int curProgress = 0;
				if (dtAllFolio.Rows.Count > 0)
				{
					//this.grdFolio.Rows.Count = dtvGetFolio.Count + 1;
					this.grdFolio.Rows.Count = dtAllFolio.Rows.Count + 1;
				}

				ProgressForm progress = new ProgressForm();
				if (dtAllFolio.Rows.Count > 0)
				{
					int count = dtAllFolio.Rows.Count + 1;
					progress = new ProgressForm(count, "Loading Guests......");
					progress.Height = 27;
					progress.Show();
				}

				int i = 1;

                int _cntRemarks = 0;
                int _cntAmmended = 0;


				//foreach (DataRowView dtRow in dtvGetFolio)
				foreach (DataRow dtRow in dtAllFolio.Rows)
				{

					string _folioId = dtRow["folioID"].ToString();
					string _folioType = dtRow["foliotype"].ToString().ToUpper();
					string _companyName = dtRow["CompanyName"].ToString();
					string _eventName = dtRow["groupName"].ToString();
					string _masterFolioID = dtRow["masterFolio"].ToString();
					
					DateTime _fromDate = DateTime.Parse(dtRow["fromdate"].ToString());
					DateTime _todate = DateTime.Parse(dtRow["todate"].ToString());
					DateTime _arrivalTime = DateTime.Parse(dtRow["folioETA"].ToString());
                    DateTime _departureTime = DateTime.Parse(dtRow["folioETD"].ToString());

					string _folioStatus = dtRow["status"].ToString();
					string _folioRemarks = dtRow["remarks"].ToString();
					string _pax = dtRow["pax"].ToString();

					string _guestAccountID = dtRow["accountID"].ToString();
					string _guestName = dtRow["GuestName"].ToString();
					string _guestAccountType = dtRow["account_type"].ToString();
					string _guestConcierge = dtRow["concierge"].ToString();
					string _guestRemarks = dtRow["remark"].ToString();
					decimal _guestThreshold = 0;
                    string _timeOfEvent = dtRow["TimeOfEvent"].ToString();
					decimal.TryParse(dtRow["THRESHOLD_VALUE"].ToString(), out _guestThreshold);

                    //DateTime _noShowTime = _arrivalTime.AddHours(2);
                    string time = _arrivalTime.Date.ToString("MM/dd/yyyy") + " " + ConfigVariables.gNoShowTime;
                    DateTime _noShowTime = DateTime.Parse(time);
					
					string _rooms = "";
					switch(_folioType)
					{
						case "JOINER":
                            _rooms = _oScheduleFacade.GetRoomFromSchedules(_masterFolioID);
							break;
						default:
                            _rooms = _oScheduleFacade.GetRoomFromSchedules(_folioId);
							break;
					}

					
					string roomno = "";
					if (_folioStatus == "ONGOING")
					{
						switch (_folioType)
						{
							case "JOINER":
                                roomno = _oFolioFacade.GetCurrentRoomOccupied(_masterFolioID, _folioType).ToString();
								break;
							default:
                                roomno = _oFolioFacade.GetCurrentRoomOccupied(_folioId, _folioType).ToString();
								break;
						}

					}
					else
					{
						roomno = _rooms;
					}



					/*0 ROOM
					 *1 BOOKED BY
					 *2 COMPANY
					 *3 EVENT NAME
                     *4 Days Left
					 *5 FROM 
					 *6 TO
					 *7 Balance
                     *8 Reference No.
                     *9 Event Officers
					 *10 Folio Type
					 *11 Status
					 *12 Account Type
					 *13 Folio ID
					 *14 Parent
					 *15 Pax/Child
					 *16 Time
					 *17 Rooms Rented
					 *18 Reason
					 *19 Sales Exec
					 *20 Account Id
					 *21 Reserved By
					 */

                    
					//-------------------------[ column 0 - Room No ]-----------------------------------'
                    //checks amendments
                    ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();
                    DataTable _dtAmendments = _oAmendmentFacade.getAmendments(_folioId);
                    bool _hasRemarks = false;
                    bool _hasAmendments = false;
                    if (_dtAmendments.Rows.Count != 0)
                    {
                        DataView _dtv = _dtAmendments.DefaultView;
                        //_dtv.RowFilter = "AmmendmentID like 'TO BE AMENDED%'";
                        if (_dtv.Count != 0)
                        {
                            _hasAmendments = true;
                        }
                    }
					this.grdFolio.SetData(i,"Room", roomno);
                    //checks remarks
					if ((_folioRemarks != "" || _guestConcierge != "" || _guestRemarks != "")
						&& (_folioType != "JOINER"))
					{
                        _hasRemarks = true;
					}

                    //sets proper image
                    if (_hasRemarks && _hasAmendments)
                    {
                        this.grdFolio.SetCellImage(i, 6, pctCombined.Image);
                        _cntRemarks++;
                        _cntAmmended++;
                    }
                    else if (_hasRemarks)
                    {
                        this.grdFolio.SetCellImage(i, 6, pctBell.Image);
                        _cntRemarks++;
                    }
                    else if (_hasAmendments)
                    {
                        this.grdFolio.SetCellImage(i, 6, pctBell2.Image);
                        _cntAmmended++;
                    }

                    ////-------------------------[ column 1 - Booked To]-----------------------------------'
                    //this.grdFolio.SetData(i, 1, _guestName);


                    ////-------------------------[ column 2 - Compay Name ]-----------------------------------'
                    //if (_companyName == "" || _companyName == "0")
                    //{
                    //    this.grdFolio.SetData(i, 2, "");
                    //}
                    //else
                    //{
                    //    this.grdFolio.SetData(i, 2, _companyName);
                    //}

                    if (_guestName != "")
                    {
                        this.grdFolio.SetData(i, "Organizer", _guestName);
                    }
                    else
                    {
                        this.grdFolio.SetData(i, "Organizer", _companyName);
                    }

					//-------------------------[ column 3 - Event Name ]-----------------------------------'
					this.grdFolio.SetData(i, "Event", _eventName);

                    //-------------------------[ column 4 - Days Left ]------------------------------------'
                    if (_folioStatus == "CONFIRMED" || _folioStatus == "TENTATIVE" || _folioStatus == "WAIT LIST")
                    {
                        TimeSpan _span = _fromDate.Subtract(DateTime.Parse(GlobalVariables.gAuditDate));
                        int _daysLeft = Convert.ToInt32(Math.Floor(_span.TotalDays));
                        if(_daysLeft >= 0)
                            this.grdFolio.SetData(i, "DaysLeft", _daysLeft);
                    }

					//-------------------------[ column 5 - From Date ]-----------------------------------'
					this.grdFolio.SetData(i, "StartDate", _fromDate.ToString());


					//-------------------------[ column 6 - To Date  ]-----------------------------------'
					this.grdFolio.SetData(i, "EndDate", _todate.ToString());


					//-------------------------[ column 13 - Folio ID ]-----------------------------------'
					string _strFolioId = dtRow["FolioId"].ToString();
					this.grdFolio.SetData(i, "ControlNo", _strFolioId);

                    //-------------------------[ column 8 - reference]-----------------------------------------------'
                    this.grdFolio.SetData(i, "ReferenceNo",  dtRow["referenceNo"].ToString());

                    //-------------------------[ column 9 -EventOfficer ]-----------------------------------------------'
                    this.grdFolio.SetData(i, "EventOfficer", dtRow["eventOfficers"].ToString());

					//-------------------------[ column 7 - Balance   ]-----------------------------------'
					FolioTransactionFacade oFolioTransFacade = new FolioTransactionFacade();
					Folio oFolio = new Folio();

                    decimal _balance = 0;
                    decimal.TryParse(dtRow["Balance"].ToString(), out _balance);
                    if (_folioType == "GROUP")
                    {
                        oFolio.ChildFolios = _oFolioFacade.GetChildFolios(_folioId);
                        Jinisys.Hotel.Reservation.BusinessLayer.Folio childFolio;

                        decimal totalSubFolioCharges = 0;
                        decimal totalSubFolioPayments = 0;
                        decimal totalSubFoliocurrentbalance = 0;
                        decimal totalSubFolioCashPayment = 0;
                        decimal totalSubFolioCardPayment = 0;
                        decimal totalSubFolioChequePayment = 0;
                        decimal totalSubFolioGiftChequePayment = 0;
                        decimal totalSubFolioBalanceForward = 0;


                        foreach (Folio tempLoopVar_childFolio in oFolio.ChildFolios)
                        {
                            childFolio = tempLoopVar_childFolio;
                            childFolio.CreateSubFolio();
                            SubFolio subF = null;

                            decimal totalCharges = 0;
                            decimal totalPayments = 0;
                            decimal balance = 0;
                            foreach (SubFolio tempLoopVar_subF in childFolio.SubFolios)
                            {
                                subF = tempLoopVar_subF;
                                //if (subF.SubFolio_Renamed == "B")
                                //{
                                subF.Ledger = _oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                                totalSubFolioCharges += subF.Ledger.Charges;
                                totalSubFolioCashPayment += subF.Ledger.PayCash;
                                totalSubFolioCardPayment += subF.Ledger.PayCard;
                                totalSubFolioChequePayment += subF.Ledger.PayCheque;
                                totalSubFolioGiftChequePayment += subF.Ledger.PayGiftCheque;
                                totalSubFolioBalanceForward += subF.Ledger.BalanceForwarded;
                                totalSubFolioPayments += subF.Ledger.PayCash + subF.Ledger.PayCard + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded;

                                totalCharges = subF.Ledger.Charges;
                                totalPayments = (subF.Ledger.PayCard + subF.Ledger.PayCash + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded);
                                balance = totalCharges - totalPayments;

                                totalSubFoliocurrentbalance += balance;
                                //}

                            }
                        }
                        _balance += totalSubFoliocurrentbalance;
                    }

					oFolio.FolioID = _folioId;
					oFolio.AccountID = _guestAccountID;
					oFolio.FolioType = _folioType;

					this.grdFolio.SetData(i, "Balance", _balance);

					//-------------------------[ column 11 - Status   ]-----------------------------------'
					this.grdFolio.SetData(i, "Status", _folioStatus);

					//-------------------------[ column 12 - Account Type   ]-----------------------------------'
					this.grdFolio.SetData(i, "AccountType", _guestAccountType);

					//-------------------------[ column 10 - Folio Type   ]-----------------------------------'
					this.grdFolio.SetData(i, "FolioType", _folioType);


					//-------------------------[ column 14 - Parent Folio No.  ]-----------------------------------'
					this.grdFolio.SetData(i, "Parent", _masterFolioID); //<< PARENT FOLIO ID

					//-------------------------[ column 15 - No of Pax / Child  ]-----------------------------------'
					this.grdFolio.SetData(i, "PaxChild", _pax);

                    //Kevin Oliveros 2014-01-22
                    string _setUpStart = "";
                    string _setUpEnd = "";
                    string _setUp = "";
                    try
                     {
                        DataRow _dataRow = _oFolioFacade.getSetUpTime(_folioId).Rows[0];
                       _setUp = new string(Encoding.ASCII.GetChars((byte[])_dataRow["SetUp"])); 
                    }
                    catch
                    {

                    }
                    //this.grdFolio.SetData(i, 16, string.Format("{0:hh:mm tt}", '') + " - " + string.Format("{0:hh:mm tt}",_departureTime)); //<< TIME
                    this.grdFolio.SetData(i, "SetUpTime", _setUp);//_SetUpStart + " - "+ _SetUpEnd); //<< TIME
	                
                   
					//-------------------------[ column 17 - Time ]-----------------------------------'
					switch (_folioStatus)
					{

						case "WAIT LIST":
							_arrivalTime = DateTime.Parse(dtRow["createTime"].ToString());
							this.grdFolio.SetData(0, "Time", "Time Reserved"); //<< TIME
                            this.grdFolio.SetData(i, "Time", string.Format("{0:MM/dd hh:mm tt}", _timeOfEvent)); //<< TIME
							break;

						case "CONFIRMED":
						case "TENTATIVE":
							_arrivalTime = DateTime.Parse(dtRow["folioETA"].ToString());

                            this.grdFolio.SetData(0, "Time", "Time of Event");//"ETA"); //<< TIME
                            this.grdFolio.SetData(i, "Time", string.Format("{0:hh:mm tt}", _timeOfEvent)); //+ " - " + string.Format("{0:hh:mm tt}", _departureTime)); //<< TIME
							break;

						case "ONGOING":
                            try
                            {
                                //_arrivalTime = DateTime.Parse(dtRow["folioETD"].ToString());
                                _arrivalTime = DateTime.Parse(dtRow["folioETA"].ToString());
                            }
                            catch
                            {
                                //_arrivalTime = DateTime.Parse(DateTime.Now.ToShortDateString() + " 12:00 PM");
                                _arrivalTime = DateTime.Parse(DateTime.Now.ToShortDateString() + " 08:00 AM");
                            }
                            //this.grdFolio.SetData(0, 16, "ETD"); //<< TIME
                            //this.grdFolio.SetData(i, 16, string.Format("{0:hh:mm tt}", _arrivalTime)); //<< TIME
                            this.grdFolio.SetData(0, "Time", "Time of Event");//"ETA"); //<< TIME
                            this.grdFolio.SetData(i, "Time", string.Format("{0:hh:mm tt}", _timeOfEvent)); //+ " - " + string.Format("{0:hh:mm tt}", _departureTime)); //<< TIME
							break;
						case "CANCELLED":
						case "NO SHOW":
							_arrivalTime = DateTime.Parse(dtRow["updateTime"].ToString());

                            this.grdFolio.SetData(0, "Time", "Time Cancelled"); //<< TIME
                            this.grdFolio.SetData(i, "Time", string.Format("{0:hh:mm tt}", _arrivalTime)); //<< TIME
                            //this.grdFolio.SetData(i, 16, string.Format("{0:hh:mm tt}", _arrivalTime) + " - " + string.Format("{0:hh:mm tt}", _departureTime)); //<< TIME
							break;

						default:

							_arrivalTime = DateTime.Parse(dtRow["createTime"].ToString());

                            this.grdFolio.SetData(0, "Time", "Time of Event"); //<< TIME
							//this.grdFolio.SetData(i, 16, string.Format("{0:hh:mm tt}", _arrivalTime)); //<< TIME
                            this.grdFolio.SetData(i, "Time", string.Format("{0:hh:mm tt}", _timeOfEvent)) ;//+ " - " + string.Format("{0:hh:mm tt}", _departureTime)); //<< TIME
						
							break;

					}


					//-------------------------[ column 18 - Rooms Rented   ]-----------------------------------'
					if (_rooms == "")
					{
						_rooms = "";
					}
					else
					{
						_rooms = _rooms.Substring(0, _rooms.Length - 2);
					}
					this.grdFolio.SetData(i, "RoomRented", _rooms);

					//-------------------------[ column 19 - Reason For Cancel   ]-----------------------------------'
					this.grdFolio.SetData(i, "Reason", dtRow["reason_For_Cancel"].ToString());

					//-------------------------[ column 20 - Sales Executive   ]-----------------------------------'
					this.grdFolio.SetData(i, "MarketingOfficer", dtRow["sales_Executive"].ToString());

					//-------------------------[ column 21 - Sales Executive   ]-----------------------------------'
					this.grdFolio.SetData(i, "AccountID", _guestAccountID); //<< new

					//-------------------------[ column 22 - Reserved By   ]-----------------------------------'
					this.grdFolio.SetData(i, "ReservedBy", dtRow["createdBy"].ToString()); //<< new


                    // ******************** FOR EXPECTED CHECK OUT **************************** //
					if (auditDate.Date == _todate.Date && _folioStatus == "ONGOING")
					{
						this.grdFolio.Rows[i].Style = this.grdFolio.Styles["expectedDeparture"];
					}

					// ******************** FOR EXPECTED ARRIVAL **************************** //
					else if ((_folioStatus == "CONFIRMED" || _folioStatus == "TENTATIVE") && _fromDate.Date == auditDate.Date)
					{
						this.grdFolio.Rows[i].Style = this.grdFolio.Styles["expectedArrival"];
					}

					// ******************** FOR OVERSTAYING **************************** //
                    //else if (_folioStatus == "ONGOING" && auditDate.Date > _todate.Date && dtRow["folioType"].ToString() != "GROUP")
                    //{
                    //    this.grdFolio.Rows[i].Style = this.grdFolio.Styles["overstaying"];
                    //}

					// ******************** FOR "SUBJECT FOR NO SHOW" **************************** //
                    if (_fromDate == auditDate.Date && (_folioStatus == "CONFIRMED" || _folioStatus == "TENTATIVE") && DateTime.Now >= _noShowTime)
					{
						this.grdFolio.Rows[i].Style = this.grdFolio.Styles["forNoShow"];
					}
					if (_fromDate < auditDate.Date && (_folioStatus == "CONFIRMED"))
					{
						this.grdFolio.Rows[i].Style = this.grdFolio.Styles["forNoShow"];
                    }

                    // ******************** FOR HIGH BALANCE **************************** //
                    if (_balance >= _guestThreshold && _balance > 0)
                    {
                        C1.Win.C1FlexGrid.CellRange range = this.grdFolio.GetCellRange(i, 0, i, this.grdFolio.Cols.Count - 1);
                        range.StyleNew.ForeColor = System.Drawing.Color.Red;
                        highBalanceCount++;
                    }


                    try
                    {
                        if (int.Parse(dtRow["RequiredRooms"].ToString()) > int.Parse(dtRow["BlockedRooms"].ToString()))
                        {
                            this.grdFolio.Rows[i].Style = this.grdFolio.Styles["groupWaitList"];
                        }
                    }
                    catch { }

					i++;
					curProgress++;
					progress.updateProgress(i);
				}

                txtNumAmended.Text = _cntAmmended.ToString();
                txtNumRemarks.Text = _cntRemarks.ToString();
                


				// Show/Hide REASON FOR CANCEL/NO SHOW column
				if (whrcond.Contains("CANCELLED") || whrcond.Contains("NO SHOW"))
				{
					this.grdFolio.Cols["Reason"].Width = 100;
				}
				else
				{
					this.grdFolio.Cols["Reason"].Width = 0;
				}
				// Show/Hide


				if (this.grdFolio.Rows.Count == 1)
				{
					buttonState(false, false, false, false, false, false, false);
				}
				else
				{
					this.grdFolio.Select(1, 0);
				}
				this.lblHighBalance.Text = highBalanceCount.ToString();

				progress.Close();

				if (cboReservationStatus.Text == "ONGOING")
				{
					grdFolio.Sort(SortFlags.Ascending, 6);
				}
				else// if (whrcond.Contains("CONFIRMED"))
				{
					grdFolio.Sort(SortFlags.Ascending, 5);
				}

                grdFolio.AutoSizeCols();

			}

            public void CheckUserRoles()
            {
                this.cmuMarketing.Enabled = false;
                this.cmuEditReservation.Enabled = false;
                this.cmuEvent.Enabled = false;
                this.cmuAddNewReservation.Enabled = false;

                User _oUser = (User)GlobalVariables.goUser;
                foreach (Role _oRole in _oUser.Roles)
                {
                    foreach (RoleUIPrivilege _RoleUIPrivilege in _oRole.RoleUIPrivileges)
                    {
                        if (_RoleUIPrivilege.FormName.ToUpper() == "RESERVATIONUI" && _RoleUIPrivilege.IsVisible ==1)
                        {
                            this.cmuEditReservation.Enabled = true;
                            this.cmuAddNewReservation.Enabled = true;
                        }
                        if (_RoleUIPrivilege.FormName.ToUpper() == "MARKETINGUI" && _RoleUIPrivilege.IsVisible == 1)
                        {
                            this.cmuMarketing.Enabled = true;
                        }
                        if (_RoleUIPrivilege.FormName.ToUpper() == "EVENTSUI" && _RoleUIPrivilege.IsVisible == 1)
                        {
                            this.cmuEvent.Enabled = true;
                        }
                    }

                    foreach (Role_Privilege _oPrivilege in _oRole.Privileges)
                    {
                        if (_oPrivilege.Privilege.ToUpper() == "ADD EVENT OFFICERS" && _oPrivilege.Allowed == 1)
                        {
                            lCanAddEventOfficer = true;
                        }
                        if (_oPrivilege.Privilege.ToUpper() == "ASSIGN MARKETING OFFICER" && _oPrivilege.Allowed == 1)
                        {
                            lCanAddMarketingOfficer = true;
                        }

                    }
                }
            }

			private void cboRecordFilter(string pReservationStatus)
			{
				try
				{
                    // COMMENT Daniel Balagosa
                    // August 22, 2012
                    // Static assign of filter conditions below
                    // END
					DateTime auditDate = DateTime.Parse(GlobalVariables.gAuditDate);

					lReservationStatus = pReservationStatus;

					string _folioType = cboFolioType.Text;
					string whereCondition = "";


					switch (lReservationStatus)
					{
						case "ALL":
							switch (_folioType)
							{
								case "ALL":
                                    //jlo 7-23-2010
                                    //removed for PICC
                                    //whereCondition = "((status ='ONGOING' or status='CONFIRMED' or status='TENTATIVE' or status='WAIT LIST' or (status='CLOSED' and date(folio.updateTime)='" + GlobalVariables.gAuditDate + "') or (status='CANCELLED' and date(folio.updateTime)='" + GlobalVariables.gAuditDate + "') or (status='NO SHOW' and date(folio.updateTime)='" + GlobalVariables.gAuditDate + "')) AND foliotype<>'GROUP')";
                                    whereCondition = "((status ='ONGOING' or status='CONFIRMED' or status='TENTATIVE' or status='WAIT LIST' or (status='CLOSED' and date(folio.updateTime)='" + GlobalVariables.gAuditDate + "') or (status='CANCELLED' and date(folio.updateTime)='" + GlobalVariables.gAuditDate + "') or (status='NO SHOW' and date(folio.updateTime)='" + GlobalVariables.gAuditDate + "')))";
									break;
								case "INDIVIDUAL + DEPENDENT":
                                    //whereCondition = "(status ='ONGOING' or status='CONFIRMED') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT')";
                                    whereCondition = "(folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT')";
                                    break;
                                case "INDIVIDUAL + DEPENDENT + GROUP":
                                    //whereCondition = "(status ='ONGOING' or status='CONFIRMED') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT' or folioType = 'GROUP')";
                                    whereCondition = "(folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT' or folioType = 'GROUP')";
									break;
                                case "ALL MASTER FOLIOS":
                                    //whereCondition = "(status ='ONGOING' or status='CONFIRMED') and (foliotype <> 'JOINER')";
                                    whereCondition = "(foliotype <> 'JOINER')";
                                    break;
                                default:
                                    //whereCondition = "(status ='ONGOING' or status='CONFIRMED') and folioType = '" + _folioType + "'";
                                    whereCondition = "folioType = '" + _folioType + "'";
									break;
							}
							break;

						case "ONGOING":
							switch (_folioType)
							{
								case "ALL":
									whereCondition = "(status ='" + lReservationStatus + "')";
									break;
								case "INDIVIDUAL + DEPENDENT":
                                    whereCondition = "(status ='" + lReservationStatus + "') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT')";
                                    break;
                                case "INDIVIDUAL + DEPENDENT + GROUP":
									whereCondition = "(status ='" + lReservationStatus + "') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT' or folioType = 'GROUP')";
									break;
                                case "ALL MASTER FOLIOS":
                                    whereCondition = "(status ='" + lReservationStatus + "') and (foliotype <> 'JOINER')";
                                    break;
                                default:
									whereCondition = "status ='" + lReservationStatus + "' and folioType = '" + _folioType + "'";
									break;
							}
							break;
						case "CONFIRMED":
						case "TENTATIVE":
							switch (_folioType)
							{
								case "ALL":
                                    //jlo 7-23-2010
                                    //removed for PICC
									//whereCondition = "(status ='" + lReservationStatus + "') and folioType <> 'GROUP'";
                                    whereCondition = "(status ='" + lReservationStatus + "')";
									break;
								case "INDIVIDUAL + DEPENDENT":
								case "INDIVIDUAL + DEPENDENT + GROUP":
									whereCondition = "(status ='" + lReservationStatus + "') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT')";
									break;
                                case "ALL MASTER FOLIOS":
                                    //jlo 7-23-2010
                                    //removed for PICC
                                    //whereCondition = "(status ='" + lReservationStatus + "') and (foliotype <> 'GROUP' and foliotype <> 'JOINER')";
                                    whereCondition = "(status ='" + lReservationStatus + "') and foliotype <> 'JOINER'";
                                    break;
								default:
									whereCondition = "status ='" + lReservationStatus + "' and folioType = '" + _folioType + "'";
									break;
							}
							break;

						case "CLOSED":
                            switch (_folioType)
                            {
                                case "ALL":
                                    whereCondition = "(status ='" + lReservationStatus + "' and date(folio.departuredate) = '" + GlobalVariables.gAuditDate + "' ) ";
                                    break;
                                case "INDIVIDUAL + DEPENDENT":
                                    whereCondition = "(status ='" + lReservationStatus + "' and date(folio.departuredate) = '" + GlobalVariables.gAuditDate + "' ) and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT') ";
                                    break;
                                case "INDIVIDUAL + DEPENDENT + GROUP":
                                    whereCondition = "(status ='" + lReservationStatus + "' and date(folio.departuredate) = '" + GlobalVariables.gAuditDate + "' ) and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT' or foliotype = 'GROUP') ";
                                    break;
                                case "ALL MASTER FOLIOS":
                                    whereCondition = "(status ='" + lReservationStatus + "' and date(folio.departuredate) = '" + GlobalVariables.gAuditDate + "' ) and (foliotype <> 'JOINER') ";
                                    break;
                                default:
                                    whereCondition = "status ='" + lReservationStatus + "' and folioType = '" + _folioType + "' and date(folio.departuredate) = '" + GlobalVariables.gAuditDate + "' ";
                                    break;
                            }
                            break;

                        case "NO SHOW":
						case "CANCELLED":
							switch (_folioType)
							{
								case "ALL":
									whereCondition = "(status ='" + lReservationStatus + "' and date(folio.updatetime) = '" + GlobalVariables.gAuditDate + "' ) ";
									break;
								case "INDIVIDUAL + DEPENDENT":
                                    whereCondition = "(status ='" + lReservationStatus + "' and date(folio.updatetime) = '" + GlobalVariables.gAuditDate + "' ) and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT') ";
                                    break;
                                case "INDIVIDUAL + DEPENDENT + GROUP":
                                    whereCondition = "(status ='" + lReservationStatus + "' and date(folio.updatetime) = '" + GlobalVariables.gAuditDate + "' ) and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT' or foliotype = 'GROUP') ";
									break;
                                case "ALL MASTER FOLIOS":
                                    whereCondition = "(status ='" + lReservationStatus + "' and date(folio.updatetime) = '" + GlobalVariables.gAuditDate + "' ) and (foliotype <> 'JOINER') ";
                                    break;
								default:
									whereCondition = "status ='" + lReservationStatus + "' and folioType = '" + _folioType + "' and date(folio.updatetime) = '" + GlobalVariables.gAuditDate + "' ";
									break;
							}
							break;

						case "WAIT LIST":
							switch (_folioType)
							{
								case "ALL":
                                    //jlo 7-23-2010
                                    //removed for PICC
									//whereCondition = "(status ='" + lReservationStatus + "') and folioType <> 'GROUP'";
                                    whereCondition = "(status ='" + lReservationStatus + "')";
									break;
								case "INDIVIDUAL + DEPENDENT":
                                    whereCondition = "(status ='" + lReservationStatus + "') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT')";
                                    break;
                                case "INDIVIDUAL + DEPENDENT + GROUP":
									whereCondition = "(status ='" + lReservationStatus + "') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT' or foliotype = 'GROUP')";
									break;
                                case "ALL MASTER FOLIOS":
                                    //jlo 7-23-2010
                                    //removed for PICC
                                    //whereCondition = "(status ='" + lReservationStatus + "') and (foliotype <> 'JOINER' AND foliotype <> 'GROUP')";
                                    whereCondition = "(status ='" + lReservationStatus + "') and foliotype <> 'JOINER'";
                                    break;
								default:
									whereCondition = "status ='" + lReservationStatus + "' and folioType = '" + _folioType + "'";
									break;
							}
							break;

						case "CONFIRMED + WAIT LIST":
							switch (_folioType)
							{
								case "ALL":
                                    //jlo 7-23-2010
                                    //removed for PICC
									//whereCondition = "(status ='CONFIRMED' or status='WAIT LIST') and folioType <> 'GROUP'";
                                    whereCondition = "(status ='CONFIRMED' or status='WAIT LIST')";
									break;
								case "INDIVIDUAL + DEPENDENT":
								case "INDIVIDUAL + DEPENDENT + GROUP":
									whereCondition = "(status ='CONFIRMED' or status='WAIT LIST') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT')";
									break;
                                case "ALL MASTER FOLIOS":
                                    whereCondition = "(status ='CONFIRMED' or status='WAIT LIST') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT' or foliotype = 'SHARE')";
                                    break;
								default:
									whereCondition = "(status ='CONFIRMED' or status='WAIT LIST') and folioType = '" + _folioType + "'";
									break;
							}
							break;

						case "ALL RESERVATIONS":
							switch (_folioType)
							{
								case "ALL":
                                    //jlo 7-23-2010
                                    //removed for PICC
									//whereCondition = "(status ='CONFIRMED' or status='WAIT LIST' or status='TENTATIVE') and folioType <> 'GROUP'";
                                    whereCondition = "(status ='CONFIRMED' or status='WAIT LIST' or status='TENTATIVE')";
									break;
								case "INDIVIDUAL + DEPENDENT":
								case "INDIVIDUAL + DEPENDENT + GROUP":
									whereCondition = "(status ='CONFIRMED' or status='WAIT LIST' or status='TENTATIVE') and (folioType = 'INDIVIDUAL' or folioType = 'DEPENDENT')";
									break;
                                case "ALL MASTER FOLIOS":
                                    whereCondition = "(status ='CONFIRMED' or status='WAIT LIST' or status='TENTATIVE') and (folioType <> 'JOINER')";
                                    break;
								default:
									whereCondition = "(status ='CONFIRMED' or status='WAIT LIST' or status='TENTATIVE') and folioType = '" + _folioType + "'";
									break;
							}
							break;
						default:
							switch (_folioType)
							{
								case "SHARE":
									cboReservationStatus.Text = "ONGOING";
									whereCondition = "status ='ONGOING' and foliotype='SHARE'";

									break;
							}
							return;
					}

					//>> load Reservation List base on where condition
					GetListReservationList(whereCondition);
					//this.picProgress.Visible = true;
					//bgwLoadAllFolio.RunWorkerAsync(whereCondition);


				}
				catch (Exception ex)
				{
					MessageBox.Show("Error loading guest list.\r\nError message: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

            // Daniel Balagosa
            // 8-24-12
            // Edit added filter Date
            private DataTable filterDateRange(DataTable pGuestList)
            {
                DataView _dView = pGuestList.DefaultView;
                _dView.RowFilter = "";
                //string _strFilter = "fromdate>='" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "' and todate<='" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "'";
                //Kevin Oliveros 2014-07-14
                string _strFilter = "fromdate>='" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "' and fromdate<='" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "' OR " +
                                    "todate>='" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "' and todate<='" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "'";
                _dView.RowFilter = _strFilter;
                

                return _dView.ToTable();
            }

            //jlo 7-24-2010
            //for picc
            private DataTable filterGuestList(DataTable pGuestList)
            {
                DataView _dView = pGuestList.DefaultView;
                _dView.RowFilter = "";
                string _strFilter = "";
                switch (cboCategory.Text)
                {
                    case "Head Marketing Officer":
                        _strFilter = "sales_executive";
                        break;
                    case "Guest":
                        _strFilter = "guestName";
                        break;
                    case "Event":
                        _strFilter = "groupName";
                        break;
                    case "Company":
                        _strFilter = "companyName";
                        break;
                    case "Event Officer":
                        _strFilter = "eventOfficers";
                        break;
                    case "Reference No.":
                        _strFilter = "referenceNo";
                        break;
                    default:
                        _strFilter = "";
                        break;
                }
                if (_strFilter != "")
                {
                    _dView.RowFilter = _strFilter + " like '%" + txtFilter.Text + "%'";
                }

                if (cboMarketingOfficer.Text != "")
                {
                    _dView.RowFilter = "sales_executive like '%" + cboMarketingOfficer.Text + "%'";
                }

                if (cboEventOfficer.Text != "")
                {
                    _dView.RowFilter = "eventOfficers like '%" + cboEventOfficer.Text + "%'";
                }

                return _dView.ToTable();
            }

			private void buttonState(bool btnCheckedInState, bool btnCheckedOutState, bool btnCancelledState, bool btnConfirmedState, bool btnNoShowState, bool btnCreateLetterState, bool btnPrintRegCardState)
			{
				btnConfirmed.Enabled = btnConfirmedState;
				cmuConfirmed.Enabled = btnConfirmedState;
				btnNoShow.Enabled = btnNoShowState;
				cmuNowShow.Enabled = btnNoShowState;


				btnCancelReservation.Enabled = btnCancelledState;
				cmuCancel.Enabled = btnCancelledState;


				btnCheckedIn.Enabled = btnCheckedInState;
				cmuCheckIn.Enabled = btnCheckedInState;

				btnCheckedOut.Enabled = btnCheckedOutState;
				cmuCheckOut.Enabled = btnCheckedOutState;

				this.btnCreateLetter.Enabled = btnCreateLetterState;

				this.btnPrintRegCard.Enabled = btnPrintRegCardState;
			}

			private void assignFolioValues()
			{
				try
				{
					int _row = this.grdFolio.Row;

					if (_row <= 0)
						return;

					//lCurrentRoom = this.grdFolio.GetDataDisplay(_row, 0);
					//lBookedBy = this.grdFolio.GetDataDisplay(_row, 1);
					//lCompany = this.grdFolio.GetDataDisplay(_row, 2);
					//lEventName = this.grdFolio.GetDataDisplay(_row, 3);
					//lFromDate = DateTime.Parse(this.grdFolio.GetDataDisplay(_row, 4));
					//lToDate = DateTime.Parse(this.grdFolio.GetDataDisplay(_row, 5));
					//lFolioID = this.grdFolio.GetDataDisplay(_row, 6);
					//lFolioBalance = decimal.Parse(this.grdFolio.GetDataDisplay(_row, 7));
					lFolioStatus = this.grdFolio.GetDataDisplay(_row, "Status");
					//lAccountType = this.grdFolio.GetDataDisplay(_row, 9);
					//lFolioType = this.grdFolio.GetDataDisplay(_row, 10);
					//lMasterFolio = this.grdFolio.GetDataDisplay(_row, 11);
					//lPaxChild = this.grdFolio.GetDataDisplay(_row, 12);
					//lTime = this.grdFolio.GetDataDisplay(_row, 13);
					//lRoomsRented = this.grdFolio.GetDataDisplay(_row, 14);
					//lReason = this.grdFolio.GetDataDisplay(_row, 15);
					//lSalesExecutive = this.grdFolio.GetDataDisplay(_row, 16);
					//lAccountId = this.grdFolio.GetDataDisplay(_row, 17);
                    
					switch (lFolioStatus.ToUpper())
					{
						case "ONGOING":

							buttonState(false, true, false, false, false, true, true);
							break;
						case "CLOSED":

							buttonState(false, false, false, false, false, true, true);
							break;
						case "CANCELLED":

							buttonState(false, false, false, false, false, false, true);
							break;
						case "NO SHOW":

							buttonState(true, false, false, false, false, false, true);
							break;
						case "CONFIRMED":

							buttonState(true, false, true, false, true, false, true);
							break;

						case "TENTATIVE":

							buttonState(false, false, true, true, false, false, true);
							break;

						case "WAIT LIST":
							buttonState(false, false, true, true, true, false, false);
							break;
					}

					this.btnSelectMaster.Enabled = true;
				}
				catch (Exception)
				{
					buttonState(false, false, false, false, false, false, false);
				}
			}

			//private void setNOSHOW(int mfolioID)
			//{
			//    FolioFacade oFOlioFacade = new FolioFacade();
			//    RoomEventFacade oRoomEventFacade = new RoomEventFacade();
			//    ScheduleFacade oSchedulefacade = new ScheduleFacade();
			//    Folio oFOlio = new Folio();
			//    RoomEvents oRoomEvents = new RoomEvents();
			//    oRoomEvents.EventType = "NO SHOW";
			//    oFOlio.Status = "NO SHOW";
			//    oFOlio.FolioID = mfolioID.ToString();
			//    oFOlioFacade.updateFolio(oFOlio);
			//    oRoomEventFacade.CancelRoomEvents(mfolioID.ToString(), "RESERVATION", "NO SHOW");
			//}

			private void searchItem()
			{

				bool found = false;
				int _rows = this.grdFolio.Rows.Count;
				int _currentRow = this.grdFolio.Row;

				if (_currentRow < 0)
					return;

				_currentRow++; // start Next Row to Current Selected
				for (int i = _currentRow; i < _rows; i++)
				{
					if (this.grdFolio.GetDataDisplay(i,"Room").ToUpper().Contains(txtSearch.Text.ToUpper())
						|| this.grdFolio.GetDataDisplay(i, "Individual").ToUpper().Contains(txtSearch.Text.ToUpper())
						|| this.grdFolio.GetDataDisplay(i, "Organizer").ToUpper().Contains(txtSearch.Text.ToUpper())
						|| this.grdFolio.GetDataDisplay(i, "Event").ToUpper().Contains(txtSearch.Text.ToUpper())
						|| this.grdFolio.GetDataDisplay(i, "StartDate").ToUpper().Contains(txtSearch.Text.ToUpper())
						|| this.grdFolio.GetDataDisplay(i, "EndDate").ToUpper().Contains(txtSearch.Text.ToUpper())
						|| this.grdFolio.GetDataDisplay(i, "ControlNo").ToUpper().Contains(txtSearch.Text.ToUpper()))
					{
						this.grdFolio.Row = i;
						found = true;
						break;
					}
				}

				if (!found)
				{
					for (int i = 1; i <= this.grdFolio.Rows.Count - 1; i++)
					{
                        if (this.grdFolio.GetDataDisplay(i, "Room").ToUpper().Contains(txtSearch.Text.ToUpper())
                        || this.grdFolio.GetDataDisplay(i, "Individual").ToUpper().Contains(txtSearch.Text.ToUpper())
                        || this.grdFolio.GetDataDisplay(i, "Organizer").ToUpper().Contains(txtSearch.Text.ToUpper())
                        || this.grdFolio.GetDataDisplay(i, "Event").ToUpper().Contains(txtSearch.Text.ToUpper())
                        || this.grdFolio.GetDataDisplay(i, "StartDate").ToUpper().Contains(txtSearch.Text.ToUpper())
                        || this.grdFolio.GetDataDisplay(i, "EndDate").ToUpper().Contains(txtSearch.Text.ToUpper())
                        || this.grdFolio.GetDataDisplay(i, "ControlNo").ToUpper().Contains(txtSearch.Text.ToUpper()))
						{
							this.grdFolio.Row = i;
							return;
						}
					}
				}
				else
				{
					return;
				}


				//reach here if not found
				string message = "Search criteria does not match any record from '" + this.cboReservationStatus.Text + "' Guests.\r\n";
				int selectedIndex = this.cboReservationStatus.SelectedIndex;
				if (selectedIndex < this.cboReservationStatus.Items.Count)
				{
					message += "Would you like to search on '" + this.cboReservationStatus.Items[selectedIndex + 1].ToString() + "' ? ";

					DialogResult rsp  =MessageBox.Show(message, "Event Plus", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

					if (rsp == DialogResult.Yes)
					{
						this.cboReservationStatus.SelectedIndex = selectedIndex + 1;
						searchItem();
					}

				}
				else
				{
					MessageBox.Show(message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			#endregion

			#region "Form Events"

			private void btnInsert_Click(System.Object sender, System.EventArgs e)
			{
                //ReservationFolioUI _oReservationUI = new ReservationFolioUI(ReservationOperationMode.NewGuestReservation);
                //_oReservationUI.MdiParent = this.MdiParent;
                //_oReservationUI.Show();

                //this.Close();
                ReservationUI _ReservationUI = new ReservationUI();
                _ReservationUI.MdiParent = this.MdiParent;
                _ReservationUI.Show();
            }

			private void btnCheckOUt_Click(System.Object sender, System.EventArgs e)
			{

				int row = this.grdFolio.Row;
				string _folioID = this.grdFolio.GetDataDisplay(row, "ControlNo");
				string _folioType = this.grdFolio.GetDataDisplay(row, "FolioType");
				string _eventName = this.grdFolio.GetDataDisplay(row, "Event");


				if (_folioType != "GROUP")
				{
					CheckOutUI CheckOutUI = new CheckOutUI(_folioID);
					CheckOutUI.MdiParent = this.MdiParent;
					CheckOutUI.Show();
					this.Close();
				}
				else
				{
					CheckOutUI frmCheckOut = new CheckOutUI(_folioID, _eventName);
					frmCheckOut.MdiParent = this.MdiParent;
					frmCheckOut.Show();
				}

                updateLegendValues();
			}

			private void btnNoSHow_Click(System.Object sender, System.EventArgs e)
			{


				FolioFacade oFolioFacade = new FolioFacade();
				DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate).Date;


				CellRange _range = this.grdFolio.Selection;

				int _count = _range.r2 - _range.r1;
				_count += 1;
				//int curProgress = 0;

				//ProgressForm progress = new ProgressForm(_count, "Loading Registration Card for " + _count + " guest/s.");
				//progress.Height = 27;
				//progress.Show(this.MdiParent);

				for (int i = _range.r1; i <= _range.r2; i++)
				{
					// check Folio Balance
					// exit if Has balance
                    string _guestName = "";
                    string _folioId = "";
                    try
                    {
                       _folioId = this.grdFolio.Rows[i]["ControlNo"].ToString();
                       _guestName = this.grdFolio.Rows[i]["Individual"].ToString();
                    }
                    catch
                    {
                        _guestName = "";
                    }
					DateTime _arrivalDate = DateTime.Parse(this.grdFolio.Rows[i]["StartDate"].ToString());

					if (_auditDate.Date != _arrivalDate.Date)
					{
						MessageBox.Show("Transaction failed.\r\nNo Show status can only be applied to guest that are suppose to arrive today.\r\nPlease check guest '" + _guestName + "'", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

                    if (grdFolio.GetDataDisplay(i, 11) == "WAIT LIST")
                    {
                        MessageBox.Show("Transaction failed.\r\nNo Show status can only be applied to guest that are Confirmed.\r\nPlease check guest '" + _guestName + "'", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


					Folio oFolio = oFolioFacade.GetFolio(_folioId);
					bool hasBalance = false;

					oFolio.CreateSubFolio();
					decimal balance = 0;
					foreach (SubFolio subF in oFolio.SubFolios)
					{
						subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
						balance = subF.Ledger.BalanceNet;
						if (balance != 0)
						{
							hasBalance = true;
						}
					}

					if (hasBalance)
					{
						MessageBox.Show("Transaction failed.\r\n\r\nGuest '" + _guestName + "' still has unsettled account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

				}


				if (MessageBox.Show("Are you sure you want to cancel " + _count + " Reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{

					for (int i = _range.r1; i <= _range.r2; i++)
					{

						string _folioId = this.grdFolio.Rows[i]["ControlNo"].ToString();
						string _folioType = this.grdFolio.Rows[i]["FolioType"].ToString();


						MySqlTransaction _dbTrans = GlobalVariables.gPersistentConnection.BeginTransaction();
						if (_folioType != "JOINER")
						{

							try
							{


								oFolioFacade.noShowFolio(_folioId);

								_dbTrans.Commit();

							}
							catch (Exception ex)
							{
								_dbTrans.Rollback();
								MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}
					}


					// UPDATES CURRENT DAY ROOM STATUS
					updateCurrentRoomStatus();
					updateLegendValues();

					MessageBox.Show("Transaction successful.\r\nReservation status has been set to No Show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//loadAllFolio();

					cboRecordFilter(this.cboReservationStatus.Text);
					buttonState(false, false, false, false, false, false, false);
				}



				//DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate).Date;
				//if (_auditDate.Date != lFromDate.Date)
				//{
				//    MessageBox.Show("Transaction failed.\r\nNo Show status can only be applied to guest that are suppose to arrive today.\r\n", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				//    return;
				//}

				//DialogResult rsp = MessageBox.Show("Are you sure you want to set this reservation to No Show?", "Folio Plus - Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				//if (rsp == DialogResult.No)
				//    return;


				////MySqlTransaction _dbTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

				//try
				//{
				//    FolioFacade _oFolioFacade = new FolioFacade();

				//    _oFolioFacade.noShowFolio(lFolioID);
				//    //_dbTrans.Commit();

				//    loadAllFolio();

				//    //this.cboReservationStatus_SelectedIndexChanged(this, new EventArgs());
				//    cboRecordFilter(this.cboReservationStatus.Text);

				//    updateCurrentRoomStatus();
				//    buttonState(false, false, false, false, false, false);

				//    MessageBox.Show("Transaction successful.\r\nReservation status has been set to No Show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//}
				//catch (Exception ex)
				//{
				//    //_dbTrans.Rollback();
				//    MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//}
                updateLegendValues();
			}

			private void updateCurrentRoomStatus()
			{
				try
				{
					Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
					MethodInfo[] objMethods = objectType.GetMethods();
					MethodInfo method;
					foreach (MethodInfo tempLoopVar_method in objMethods)
					{
						method = tempLoopVar_method;
						if (method.Name.ToUpper() == "plotCurrentDayRoomStatus".ToUpper())
						{
							method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message + "@ btnNOShow_click()", "Reservation ListUI Exception");
				}

			}

            private void btnConfirm_Click(System.Object sender, System.EventArgs e)
            {
                int _row = this.grdFolio.Row;
                if (_row <= 0)
                    return;

                string _roomID = this.grdFolio.GetDataDisplay(_row, "Room");
                string _guestName = this.grdFolio.GetDataDisplay(_row, "Individual");
                string _folioID = this.grdFolio.GetDataDisplay(_row, "ControlNo");
                DateTime _arrivalDate ;
                try 
                {
                    _arrivalDate = DateTime.Parse(this.grdFolio.GetDataDisplay(_row, "StartDate"));
                }catch
                {
                    _arrivalDate = DateTime.Parse("01-01-1900");
                }
                //if (grdFolio.GetDataDisplay(_row, 9) == "WAIT LIST")
                //{
                //    MessageBox.Show("Transaction failed.\r\nNo Show status can only be applied to guest that are Tentative.\r\nPlease check guest '" + _guestName + "'", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}

                //>> check if there is conflict with other reservations
                //..........//

                DialogResult rsp = MessageBox.Show("Room No. : " + _roomID
                                                 + "\r\nGuest Name: " + _guestName
                                                 + "\r\n\r\nAre you sure you want to set this reservation to Confirmed?",
                                                      "Event Plus",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Exclamation);

                if (rsp == DialogResult.No)
                {
                    return;
                }

                if (grdFolio.GetDataDisplay(grdFolio.Row, "FolioType") != "GROUP")
                {
                    MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();
                    oFolioFacade = new FolioFacade();
                    try
                    {


                        oFolioFacade.confirmFolio(_folioID, ref _oDBTrans);
                        _oDBTrans.Commit();

                        // refresh DataView
                        //loadAllFolio();

                        this.cboReservationStatus_SelectedIndexChanged(sender, e);
                    }
                    catch (Exception ex)
                    {
                        _oDBTrans.Rollback();

                        MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ////>> check if there is conflict with other reservations
                    Folio _oFolio = new Folio();
                    _oFolio = oFolioFacade.GetFolio(_folioID);

                    foreach (Schedule _oSchedule in _oFolio.Schedule)
                    {
                        DateTime _startDate = _oSchedule.FromDate;
                        string _room = _oSchedule.RoomID;
                        DateTime _startTime = _oSchedule.StartTime;
                        DateTime _endDate = _oSchedule.ToDate;
                        DateTime _endTime = _oSchedule.EndTime;
                        for (DateTime _date = _startDate; _date <= _endDate; _date = _date.AddDays(1))
                        {
                            if ((_room != "" && _room != "  ") && (oFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _startTime.ToString("HH:mm:ss"), _folioID) == true || oFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _endTime.ToString("HH:mm:ss"), _folioID) == true))
                            {
                                MessageBox.Show("Cannot confirm reservation.\nConflict in function room schedule.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }

                    //foreach (C1.Win.C1FlexGrid.Row grdFolioRows in gridFunctionRooms.Rows)
                    //{
                    //    if (grdFolioRows.Index != 0)
                    //    {
                    //        DateTime _startDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 3));
                    //        string _room = gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 0);
                    //        DateTime _startTime = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 5));
                    //        DateTime _endDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 4));

                    //        for (DateTime _date = _startDate; _date <= _endDate; _date = _date.AddDays(1))
                    //        {
                    //            if ((_room != "" && _room != "  ") && loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _startTime.ToString("HH:mm:ss"), txtFolioID.Text) == true)
                    //            {
                    //                MessageBox.Show("Cannot confirm reservation.\nConflict in function room schedule.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                return;
                    //            }
                    //        }
                    //    }
                    //}

                    MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();
                    oFolioFacade = new FolioFacade();
                    try
                    {
                        oFolioFacade.confirmFolio(_folioID, ref _oDBTrans);
                        oFolioFacade.setReferencNo(_folioID, _arrivalDate.Month, _arrivalDate.Year, GlobalVariables.gHotelId);
                        _oDBTrans.Commit();

                        // refresh DataView
                        //loadAllFolio();

                        if (ConfigVariables.gSAPServer != "")
                        {
                            try
                            {
                                addon _integration = new addon(ConfigVariables.gSAPServer);
                                try
                                {
                                    string _cardCode = "";
                                    _cardCode = grdFolio.GetDataDisplay(grdFolio.Row, "Organizer");
                                    if (_cardCode != "")
                                    {
                                        Folio _folio = oFolioFacade.GetFolio(_folioID);
                                        if (!_integration.eventPlusToSAPB1_SO(_cardCode, _folio.CreateTime, grdFolio.GetDataDisplay(grdFolio.Row, "ReferenceNo"), _folio.FromDate, _folio.Todate, grdFolio.GetDataDisplay(grdFolio.Row, "ControlNo"), grdFolio.GetDataDisplay(grdFolio.Row, "Event"), _folio.AccountID, grdFolio.GetDataDisplay(grdFolio.Row, "Time").Replace(",", "/").Replace(" ", ""), "", double.Parse(_folio.EventEndorsement.ContractAmount.ToString())))
                                        {
                                            MessageBox.Show("Sales Order for SAP integration failed. Please check settings for integration.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("SAP Integration did not return a cardcode value.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("There was a problem with SAP integration\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Unable to connect to SAP Server for integration.\r\n Please check the server IP settigns in Event Plus.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        this.cboReservationStatus_SelectedIndexChanged(sender, e);

                    }
                    catch (Exception ex)
                    {
                        _oDBTrans.Rollback();

                        MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                updateLegendValues();
            }

			private void btnCheckIn_Click(System.Object sender, System.EventArgs e)
			{

				DateTime auditDate = DateTime.Parse(GlobalVariables.gAuditDate);

				/* SCR-00101 , Line #4, 6
				* Jerome, April 18, 2008
				* Pass FolioID of masterFolio rather select folio since
				* SHARE to another guest
				*/
				int row = this.grdFolio.Row;
				string _guestName = this.grdFolio.GetDataDisplay(row, "Individual");
				DateTime _fromDate = DateTime.Parse(this.grdFolio.GetDataDisplay(row, "StartDate"));
				string _folioID = this.grdFolio.GetDataDisplay(row, "ControlNo");
				string _folioType = this.grdFolio.GetDataDisplay(row, "FolioType");
				string _masterFolio = this.grdFolio.GetDataDisplay(row, "Parent");
				string _roomsRented = this.grdFolio.GetDataDisplay(row, "RoomRented");

				

				if (_folioType == "SHARE")
				{
					if (_masterFolio == "" || _masterFolio == "0")
					{
						// do nothing
					}
					else
					{
						DialogResult rsp = MessageBox.Show("Guest type is Share.\r\n\r\nShow Master Folio information?", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
						if (rsp == DialogResult.No)
							return; // exit is no
						else
						{
							//ReservationFolioUI.AccountType = "PERSONAL";
							//ReservationFolioUI.Flag = "Edit";
							//ReservationFolioUI.FolioType = lFolioType;
							////Dim _oFolioUI As New Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI( , "View Folio Information", lvwList.SelectedItems(0).SubItems(4).Text)
							//loFolioUI = new ReservationFolioUI("View Folio Information", lMasterFolio);
							loFolioUI = new ReservationFolioUI();


							loFolioUI.MdiParent = this.MdiParent;
							loFolioUI.Top = 0;
							loFolioUI.Left = 0;
							loFolioUI.Show();
							this.Close();

							return;
						}
					}
				}
				/* end SCR-00101, Line#4, 6*/

                //operator changed from == to >= , to allow previous event to start
                // Clark 08.10.2011                            
				if (auditDate.Date >= _fromDate.Date)
				{

					string _room = "";
					if (_roomsRented.IndexOf(",") >= 0)
					{
						_room = _roomsRented.Substring(0, _roomsRented.IndexOf(","));
					}
					else
					{
						_room = _roomsRented;
					}
                    if (ConfigVariables.gIsEMMOnly == "true")
                    {
                        if (MessageBox.Show("Start Event " + _guestName +
                            " at room " + _room + " ? ", "Confirm",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Check In Guest " + _guestName +
                            " at room " + _room + " ? ", "Confirm",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }

					//ReservationFolioUI.setCheckedIN(folioID, _masterFolio, _accountId);
					oFolioFacade = new FolioFacade();
					try
					{
						oFolioFacade.checkInFolio(_folioID, _room);

                        if (ConfigVariables.gIsEMMOnly == "true")
                        {
                            MessageBox.Show("Transaction successful.\r\nEvent has started.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Transaction successful.\r\nGuest status is now Check In.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
					}
					catch (Exception ex)
					{
						MessageBox.Show("Transaction failed.\r\nError Message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					// update CURRENT ROOM STATUS
					updateCurrentRoomStatus();

					// refresh DataView
					//loadAllFolio();

					lReservationStatus = "ONGOING";
                    //jlo 7-23-2010
                    //removed for PICC
					//GetListReservationList("status ='" + lReservationStatus + "' and foliotype <> 'GROUP'");
                    GetListReservationList("status ='" + lReservationStatus + "'");
					this.cboReservationStatus.Text = lReservationStatus;


					buttonState(false, false, false, false, false, false, false);

					// >> early check-in
				}
				else if ((DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, auditDate.Date, _fromDate) > 0))
				{
					if (MessageBox.Show("\r\nStart date for Event is " + string.Format("{0:dd-MMM-yyyy}", _fromDate) + "\r\n" + "\r\n" + "Would you like to edit event's reservation info ?    ", "Event Plus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
                        if (_folioType == "GROUP")
                        {
                            //GroupReservationUI _GroupReservationUI = new GroupReservationUI(_folioID);
                            //_GroupReservationUI.MdiParent = this.MdiParent;
                            //_GroupReservationUI.Top = 0;
                            //_GroupReservationUI.Left = 0;
                            //_GroupReservationUI.Show();
                            ReservationUI _oReservationUI = new ReservationUI(_folioID);
                            _oReservationUI.MdiParent = this.MdiParent;
                            _oReservationUI.Show();

                        }
                        else
                        {
                            ReservationUI _oReservationUI = new ReservationUI(_folioID);
                            _oReservationUI.MdiParent = this.MdiParent;
                            _oReservationUI.Show();
                            //ReservationFolioUI _ReservationFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioInformation, _folioID);
                            //_ReservationFolioUI.MdiParent = this.MdiParent;
                            //_ReservationFolioUI.Top = 0;
                            //_ReservationFolioUI.Left = 0;
                            //_ReservationFolioUI.Show();
                        }
						this.Close();
					}
				}
				// this is for invalid FROM DATE ( less than AuditDate )
				else
				{
					MessageBox.Show("Invalid Guest Arrival date.\r\nPlease check Guest's schedule.", "Invalid Check In", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}

                updateLegendValues();
			}

			private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					searchItem();
				}
			}

			private void ReservationListUI_Load(object sender, System.EventArgs e)
			{
				this.txtSearch.Focus();
                this.loadComboBoxes();
				this.grdFolio_Click(sender, e);
                UserFacade _oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);

                // Added Daniel Balagosa
                // August 24, 2012
                dtpFrom.Value = DateTime.Now.AddYears(-1);
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                // END of ADD

                //jlo 6-10-10 emm only config
                if (ConfigVariables.gIsEMMOnly == "true")
                {
                    this.btnInsert.Visible = false;
                    this.cboFolioType.Visible = false;
                    this.Label3.Visible = false;
                    this.btnPrintRegCard.Hide();
                    this.label13.Text = "Event List";
                    this.Text = "Event List";
                }
                DataTable _DataTableBuffer = _oUserFacade.GetUserRolesAll().Tables[0];
                //jlo
                // Daniel Balagosa
                // June 21, 2012
                // Commented below line to replace query with user roles. Is now dependent on
                // User roles instead of assigning from Even Reservation
                // DataTable _dt = oFolioFacade.getMarketingOfficers(); 
                cboMarketingOfficer.Items.Add("");
                foreach (DataRow _dRow in _DataTableBuffer.Select("Department like '100%' and rolename like '%marketing%'"))
                {
                    cboMarketingOfficer.Items.Add(_dRow["sales_Executive"]);
                }

                // Daniel Balagosa
                // June 21, 2012
                // Commented below line to replace query with user roles. Is now dependent on
                // User roles instead of assigning from Even Reservation
                // DataTable _eo = oFolioFacade.getEventOfficers();
                cboEventOfficer.Items.Add("");
                foreach (DataRow _dRow in _DataTableBuffer.Select("Department like '100%' and rolename like '%event%'"))
                {
                    cboEventOfficer.Items.Add(_dRow["FullName"]);
                }
                CheckUserRoles();
                
			}


            public void loadComboBoxes()
            {
                GroupBookingDropDownFacade _oGroupBookingDropDownFacade = new GroupBookingDropDownFacade();
                DataTable _dt = _oGroupBookingDropDownFacade.getSpecificFieldName("EventListFilter");
                cboCategory.Items.Clear();
                foreach (DataRow _dRow in _dt.Rows)
                {
                    cboCategory.Items.Add(_dRow["Value"]);
                }
            }

			private void cboReservationStatus_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}

			private void cboFolioType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				cboRecordFilter(this.cboReservationStatus.Text);
			}

			private void grdFolio_Click(System.Object sender, System.EventArgs e)
			{
				assignFolioValues();
			}

			private void grdFolio_RowColChange(object sender, System.EventArgs e)
			{
				assignFolioValues();
			}
			private void grdFolio_DoubleClick(object sender, System.EventArgs e)
			{
				if (this.grdFolio.Rows.Count <= 1)
				{
					return;
				}
				try
				{
					//loads all selected FOLIO
					CellRange _range = this.grdFolio.Selection;

					int _diff = _range.r2 - _range.r1;
					if (_diff > 0)
					{
						_diff = _diff + 1;
						DialogResult rsp = MessageBox.Show("You are about to view '" + _diff + "' Reservation info.\r\n\r\nWould you like to continue?" , "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (rsp == DialogResult.No)
						{
							return;
						}
					}

					//this.MdiParent.Cursor = Cursors.WaitCursor;
					for (int i = _range.r1; i <= _range.r2; i++)
					{
						string _folioID = this.grdFolio.Rows[i]["ControlNo"].ToString();
						string _folioType = this.grdFolio.Rows[i]["FolioType"].ToString();
						string _masterFolioID = this.grdFolio.Rows[i]["Parent"].ToString();


						if (_folioType == "JOINER")
						{

							if (_masterFolioID == "" || _masterFolioID == "0")
							{
								// do nothing
							}
							else
							{
								/* Pass FolioID of masterFolio since
								* SHARE to another guest
								*/
								//lFolioID = lMasterFolio;
								_folioID = _masterFolioID;

								DialogResult rsp = MessageBox.Show("Guest type is joiner.\r\n\r\nShow Master Folio information?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rsp == DialogResult.No)
                                {
                                    this.MdiParent.Cursor = Cursors.Default;
                                    return;
                                }
							}
						}
						else if (_folioType == "GROUP")
						{
                            ReservationUI _oReservationUI = new ReservationUI(_folioID);
                            _oReservationUI.MdiParent = this.MdiParent;
                            _oReservationUI.Show();
                            //GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_folioID);
                            //_oGroupReservationUI.MdiParent = this.MdiParent;
                            //_oGroupReservationUI.Show();

							//this.Close();

							return;
						}
                        else if (_folioType == "MARKETING")
                        {
                            MarketingUI _MarketingUI = new MarketingUI(_folioID);
                            _MarketingUI.MdiParent = this.MdiParent;
                            _MarketingUI.Show();
                            //GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_folioID);
                            //_oGroupReservationUI.MdiParent = this.MdiParent;
                            //_oGroupReservationUI.Show();
                            //this.Close();
                            return;
                        }


						loFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioInformation, _folioID);
						loFolioUI.MdiParent = this.MdiParent;
						loFolioUI.Show();

					}//end for
					this.MdiParent.Cursor = Cursors.Default;
					this.Close();

				}//end try

				catch (Exception ex)
				{
					this.MdiParent.Cursor = Cursors.Default;
					MessageBox.Show("Transaction failed @ grdFolio_DoubleClick().\r\nError message: " + ex.Message, "Reservation List Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			#endregion

			private void btnSelectMaster_Click(object sender, EventArgs e)
			{
				this.grdFolio_DoubleClick(sender, e);
			}

			private void cmdRefresh_Click(object sender, EventArgs e)
			{
				cboRecordFilter(this.cboReservationStatus.Text);
			}

			private void grdFolio_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					grdFolio_DoubleClick(sender, new EventArgs());
				}
			}

			private void cboFolioType_KeyPress(object sender, KeyPressEventArgs e)
			{
				e.Handled = true;
			}

			private void updateLegendValues()
			{

				DataTable folioSummary = loReservationFacade.GetGuestsListForLegend();

			
				int totalCheckIn = 0;
				int totalCheckedOut = 0;
				int totalNoShow = 0;
				int totalCancelled = 0;
				int totalReservations = 0;
				int totalExpectedCheckIn = 0;
				int totalExpectedCheckOut = 0;
				int totalForNoShow = 0;
				int totalOverstaying = 0;
				int totalWaitList = 0;

				foreach (DataRow row in folioSummary.Rows)
				{
					string status = row["Status"].ToString();
					switch (status)
					{ 
						case "CONFIRMED":
						case "TENTATIVE":
							totalReservations += int.Parse(row["Total"].ToString());
							break;
						case "WAIT LIST":
							totalWaitList += int.Parse(row["Total"].ToString());
							break;

						case "EXPECTED CHECK-IN":
							totalExpectedCheckIn += int.Parse(row["Total"].ToString());
							break;

						case "EXPECTED CHECK-OUT":
							totalExpectedCheckOut += int.Parse(row["Total"].ToString());
							break;

						case "ONGOING":
							totalCheckIn += int.Parse(row["Total"].ToString());
							break;

						case "CLOSED":
							totalCheckedOut += int.Parse(row["Total"].ToString());
							break;
						case "CANCELLED":
							totalCancelled += int.Parse(row["Total"].ToString());
							break;
						case "NO SHOW":
							totalNoShow += int.Parse(row["Total"].ToString());
							break;


					}
					
				}
				totalReservations += totalWaitList;

				if (DateTime.Now.Hour > DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy") + " " + ConfigVariables.gNoShowTime).Hour)
				{
					totalForNoShow = totalExpectedCheckIn;
				}
				
				this.lblTotalExpectedCheckIn.Text = totalExpectedCheckIn.ToString();
				this.lblTotalExpectedCheckOut.Text = totalExpectedCheckOut.ToString();
				this.lblTotalForNoShow.Text = totalForNoShow.ToString();
				this.lblTotalOverstaying.Text = totalOverstaying.ToString();

				this.lblTotalCheckedIn.Text = totalCheckIn.ToString();
				this.lblTotalCheckedOut.Text = totalCheckedOut.ToString();
				this.lblTotalReservations.Text = totalReservations.ToString();
				this.lblTotalCancelled.Text = totalCancelled.ToString();
				this.lblTotalNoShow.Text = totalNoShow.ToString();
				this.lblTotalWaitList.Text = totalWaitList.ToString();


				this.lblTotalGroupWaitList.Text = oFolioFacade.getTotalGroupWaitList().ToString();

			}

			private void btnCreateLetter_Click(object sender, EventArgs e)
			{
				//this.MdiParent.Cursor = Cursors.WaitCursor;
				try
				{
					int row = this.grdFolio.Row;

					string accountId = this.grdFolio.GetDataDisplay(row,"AccountID");

					Guest oGuest = new Guest();
					GuestFacade oGuestFacade = new GuestFacade();
					oGuest = oGuestFacade.getGuestRecord(accountId);

					string _roomNo = this.grdFolio.GetDataDisplay(row, "Room");
					string _name = oGuest.LastName + ", " + oGuest.FirstName;
					string _address = oGuest.Street + " " + oGuest.City + ", " + oGuest.Country;
					string _telephone = oGuest.TelephoneNo;
					string _salesExec = this.grdFolio.GetDataDisplay(row, "MarketingOfficer");

					decimal balance = decimal.Parse(this.grdFolio.GetDataDisplay(row, "Balance"));



					DataTable dtReport = new DataTable("Report");
					dtReport.Columns.Add("room", typeof(System.String));
					dtReport.Columns.Add("name", typeof(System.String));
					dtReport.Columns.Add("address", typeof(System.String));
					dtReport.Columns.Add("telephone", typeof(System.String));
					dtReport.Columns.Add("salesExecutive", typeof(System.String));
					dtReport.Columns.Add("balance", typeof(System.Double));

					DataRow newRow = dtReport.NewRow();

					newRow["room"] = "Room " + _roomNo;
					newRow["name"] = _name;
					newRow["address"] = _address;
					newRow["telephone"] = _telephone;
					newRow["salesExecutive"] = _salesExec;
					newRow["balance"] = balance;

					dtReport.Rows.Add(newRow);

					Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales.HighBalanceLetter highBalanceLetter = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Marketing_And_Sales.HighBalanceLetter();
					highBalanceLetter.Database.Tables[1].SetDataSource(dtReport);
					highBalanceLetter.Database.Tables[0].SetDataSource(Jinisys.Hotel.Reports.BusinessLayer.CrystalReportAddons.reportHeader());

					ReportViewer rptViewer = new ReportViewer();
					rptViewer.rptViewer.ReportSource = highBalanceLetter;

					rptViewer.MdiParent = this.MdiParent;
					rptViewer.Show();
				}
				catch
				{ }

				this.MdiParent.Cursor = Cursors.Default;
			}

			private void cboReservationStatus_SelectedIndexChanged(object sender, EventArgs e)
			{
				if (this.cboReservationStatus.SelectedIndex != -1)
				{
					string _status = this.cboReservationStatus.Text;

					if (guestListDefaults != null)
					{
						foreach (clsGuestListDefaults listDefault in guestListDefaults)
						{
							if (_status == listDefault.FolioStatusSelected)
							{
								cboFolioType.Items.Clear();

								foreach (string strType in listDefault.AvailableFolioTypes)
								{
									cboFolioType.Items.Add(strType);
								}

								this.cboFolioType.Text = listDefault.FolioTypeSelected;
								break;	
							}
						}
					}
				}
			}

			#region "CONTEXT MENU ACTIONS"

			private void cmuEditReservation_Click(object sender, EventArgs e)
			{
				this.grdFolio_DoubleClick(sender, e);
			}

			private void cmuAddNewReservation_Click(object sender, EventArgs e)
			{
				this.btnInsert_Click(sender, e);
			}

			private void cmuConfirmed_Click(object sender, EventArgs e)
			{
				this.btnConfirm_Click(sender, e);
			}

			private void cmuNowShow_Click(object sender, EventArgs e)
			{
				this.btnNoSHow_Click(sender, e);
			}

			//private void cmuCancel_Click(object sender, EventArgs e)
			//{
			//    btnCanceReservation_Click(sender, e);
			//}


			private void cmuCheckIn_Click(object sender, EventArgs e)
			{
				this.btnCheckIn_Click(sender, e);
			}

			private void cmuCheckOut_Click(object sender, EventArgs e)
			{
				this.btnCheckOUt_Click(sender, e);
			}


			#endregion

			/// <summary>
			/// Public Method NewEntry()
			/// used in MDIMain upon clicking InsertButton[ToolBar Buttom]
			/// </summary>
			/// 
			public void NewEntry()
			{
				this.btnInsert_Click(this, new EventArgs());
			}

			private void btnClose_Click(object sender, EventArgs e)
			{
				this.Close();
			}

			private void btnCancelReservation_Click(object sender, EventArgs e)
			{

				FolioFacade oFolioFacade = new FolioFacade();


				CellRange _range = this.grdFolio.Selection;

				int _count = _range.r2 - _range.r1;
				_count += 1;
				//int curProgress = 0;

				//ProgressForm progress = new ProgressForm(_count, "Loading Registration Card for " + _count + " guest/s.");
				//progress.Height = 27;
				//progress.Show(this.MdiParent);

				for (int i = _range.r1; i <= _range.r2; i++)
				{
					// check Folio Balance
					// exit if Has balance
					string _folioId = this.grdFolio.Rows[i]["ControlNo"].ToString();
                    string _guestName = "";
                    try
                    {
                        _guestName = this.grdFolio.Rows[i]["Organizer"].ToString();
                    }
                    catch
                    {
                        _guestName = this.grdFolio.Rows[i]["Organizer"].ToString();
                    }

					Folio oFolio = oFolioFacade.GetFolio(_folioId);
					bool hasBalance = false;

					oFolio.CreateSubFolio();
					decimal balance = 0;
					foreach (SubFolio subF in oFolio.SubFolios)
					{
						subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
						balance = subF.Ledger.BalanceNet;
						if (balance != 0)
						{
							hasBalance = true;
						}
					}

					if (hasBalance)
					{
						MessageBox.Show("Transaction failed.\r\n\r\nGuest '" + _guestName + "' still has unsettled account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

				}

				// prompts for REASON for CANCEL
				ReasonForCancelUI reasonUI = new ReasonForCancelUI();
				string reason = reasonUI.showDialog();

				if (reason == "")
					return;



				if (MessageBox.Show("Are you sure you want to cancel " + _count + " Reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{

					for (int i = _range.r1; i <= _range.r2; i++)
					{
						string _folioId = this.grdFolio.Rows[i]["ControlNo"].ToString();
						string _folioType = this.grdFolio.Rows[i]["FolioType"].ToString();

						if (_folioType != "JOINER")
						{
							MySqlTransaction _dbTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

							try
							{

								oFolioFacade.cancelFolio(_folioId, reason);
								
								_dbTrans.Commit();


							}
							catch (Exception ex)
							{
								_dbTrans.Rollback();
								MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}

					}


					// UPDATES CURRENT DAY ROOM STATUS
					updateCurrentRoomStatus();
					updateLegendValues();

					MessageBox.Show("Transaction successful.\r\nReservation Status is now cancelled.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//loadAllFolio();

					cboRecordFilter(this.cboReservationStatus.Text);

				}
                updateLegendValues();
			}

			private void lblTotalExpectedCheckOut_Click(object sender, EventArgs e)
			{
				this.grdFolio.Sort(SortFlags.Ascending, 6);
			}

			private void lblTotalExpectedCheckIn_Click(object sender, EventArgs e)
			{
				this.grdFolio.Sort(SortFlags.Ascending, 5);
			}

			private void lblHighBalance_Click(object sender, EventArgs e)
			{
				this.grdFolio.Sort(SortFlags.Descending, 7);
			}

			private void ReservationListUI_Activated(object sender, EventArgs e)
			{
				//loadAllFolio();
				//cboFolioType.Text = lDefaultSelectedFoliotype;
				//cboRecordFilter(this.cboReservationStatus.Text);


				this.WindowState = FormWindowState.Maximized;
				this.txtSearch.Focus();


				//add KeyCode Listener for each control for shortcuts
				addKeyCodeListenerForShortCuts(this);
			}

			private void btnPrintRegCard_Click(object sender, EventArgs e)
			{
				ReportFacade _oReportFacade = new ReportFacade();
				ReportViewer _oReportViewerUI = new ReportViewer();

				//>> for Multiple Row Selection
				CellRange _range = this.grdFolio.Selection;

				int _count = _range.r2 - _range.r1;
				_count += 1;
				int curProgress = 0;

				ProgressForm progress = new ProgressForm(_count, "Loading Registration Card for " + _count + " guest/s.");
				progress.Height = 27;
				progress.Show(this.MdiParent);

				for (int i = _range.r1; i <= _range.r2; i++)
				{
					string _folioId = this.grdFolio.Rows[i]["ControlNo"].ToString();
					string _folioType = this.grdFolio.Rows[i]["FolioType"].ToString();


					if (_folioId != "")
					{

						//this.MdiParent.Cursor = Cursors.WaitCursor;

						_oReportViewerUI = new ReportViewer();

						_oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getGuestInformation(_folioId);
						_oReportViewerUI.MdiParent = this.MdiParent;
						_oReportViewerUI.Show();

						this.MdiParent.Cursor = Cursors.Default;

					}

					curProgress++;
					progress.updateProgress(curProgress);

				}

				progress.Close();

			}

			private void lblTotalGroupWaitList_Click(object sender, EventArgs e)
			{
				if (lblTotalGroupWaitList.Text != "0")
				{
					GroupReservationListUI _oGroupList = new GroupReservationListUI();
					_oGroupList.MdiParent = this.MdiParent;
					_oGroupList.Show();
				}
			}

			private void lblTotalGroupWaitList_MouseHover(object sender, EventArgs e)
			{
				if (lblTotalGroupWaitList.Text != "0")
				{
					lblTotalGroupWaitList.Cursor = Cursors.Hand;
				}
			}

			private void addKeyCodeListenerForShortCuts(Control ctrl)
			{
				foreach (Control control in ctrl.Controls)
				{
					if (control.HasChildren)
					{
						addKeyCodeListenerForShortCuts(control);
					}
					else
					{
						control.KeyDown += new KeyEventHandler(this.ReservationListUI_KeyDown);
					}
				}
			}

			private void ReservationListUI_KeyDown(object sender, KeyEventArgs e)
			{
				try
				{
					
					if (e.Control)
					{
						if (e.Control && e.Shift) //change Selected Folio Type
						{
							switch (e.KeyCode)
							{
								case Keys.D1:
									this.cboFolioType.SelectedIndex = 0;
									break;
								case Keys.D2:
									this.cboFolioType.SelectedIndex = 1;
									break;
								case Keys.D3:
									this.cboFolioType.SelectedIndex = 2;
									break;
								case Keys.D4:
									this.cboFolioType.SelectedIndex = 3;
									break;
								case Keys.D5:
									this.cboFolioType.SelectedIndex = 4;
									break;
								case Keys.D6:
									this.cboFolioType.SelectedIndex = 5;
									break;
								case Keys.D7:
									this.cboFolioType.SelectedIndex = 6;
									break;
							}

						}
						else //change Selected Reservation Status
						{
							switch (e.KeyCode)
							{
								case Keys.D1:
									this.cboReservationStatus.SelectedIndex = 0;
									break;
								case Keys.D2:
									this.cboReservationStatus.SelectedIndex = 1;
									break;
								case Keys.D3:
									this.cboReservationStatus.SelectedIndex = 2;
									break;
								case Keys.D4:
									this.cboReservationStatus.SelectedIndex = 3;
									break;
								case Keys.D5:
									this.cboReservationStatus.SelectedIndex = 4;
									break;
								case Keys.D6:
									this.cboReservationStatus.SelectedIndex = 5;
									break;
								case Keys.D7:
									this.cboReservationStatus.SelectedIndex = 6;
									break;
								case Keys.D8:
									this.cboReservationStatus.SelectedIndex = 7;
									break;
								case Keys.D9:
									this.cboReservationStatus.SelectedIndex = 8;
									break;

							}
						}
					}
				}
				catch
				{ }
				//MessageBox.Show(e.KeyCode.ToString());
			}

			ArrayList guestListDefaults = null;
			private void loadGuestListDefaults()
			{
				try
				{
					guestListDefaults = new ArrayList();

					DataTable tempTable = loReservationFacade.GetGuestListDefaults();
					foreach (DataRow row in tempTable.Rows)
					{
						clsGuestListDefaults listDefault = new clsGuestListDefaults();
						listDefault.FolioStatusSelected = row["folioStatusSelected"].ToString();

						listDefault.FolioTypeSelected = row["folioTypeSelected"].ToString();
						listDefault.setAvailableFolioTypes(row["availableFolioTypes"].ToString());

						guestListDefaults.Add(listDefault);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Transaction failed. Error loading guest list defaults.\r\nError Message: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			private void cmuCancel_Click(object sender, EventArgs e)
			{
				this.btnCancelReservation_Click(sender, e);
			}
            private void cmuMarketing_Click(object sender, EventArgs e)
            {
                CellRange _range = this.grdFolio.Selection;

                int _diff = _range.r2 - _range.r1;
                if (_diff > 0)
                {
                    _diff = _diff + 1;
                    DialogResult rsp = MessageBox.Show("You are about to view '" + _diff + "' Reservation info.\r\n\r\nWould you like to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rsp == DialogResult.No)
                    {
                        return;
                    }
                }

                //this.MdiParent.Cursor = Cursors.WaitCursor;
                for (int i = _range.r1; i <= _range.r2; i++)
                {
                    //Kevin Oliveros 2014-02-20
                    //if (this.grdFolio.Rows[i]["Status"].ToString() != "TENTATIVE")
                    //{
                        string _folioID = this.grdFolio.Rows[i]["ControlNo"].ToString();
                        string _folioType = this.grdFolio.Rows[i]["FolioType"].ToString();
                        string _masterFolioID = this.grdFolio.Rows[i]["Parent"].ToString();

                        MarketingUI _MarketingUI = new MarketingUI(_folioID);
                        _MarketingUI.MdiParent = this.MdiParent;
                        _MarketingUI.Show();

                        //GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_folioID);
                        //_oGroupReservationUI.MdiParent = this.MdiParent;
                        //_oGroupReservationUI.Show();
                        //this.Close();
                        return;
                        loFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioInformation, _folioID);
                        loFolioUI.MdiParent = this.MdiParent;
                        loFolioUI.Show();
                    //}
                    //else
                    //{
                    //     MessageBox.Show("This event is not yet CONFIRMED.\n Please contact your Reservation Officer!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         
                    //}
                    
                }//end for
                this.MdiParent.Cursor = Cursors.Default;
                //this.Close();
            }

            private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
            {
                cboRecordFilter(this.cboReservationStatus.Text);
            }

            private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    this.cboRecordFilter(cboReservationStatus.Text);
                }
            }

            private void btnExportToExcel_Click(object sender, EventArgs e)
            {
                string _filePath = @"..\Excel Caledar\Template\CALSKED.csv";

                StreamWriter strWrite = new StreamWriter(_filePath);

                strWrite.WriteLine("DATE_FROM,DATE_TO,ACTIVITY,STATUS,WHOLE_DAY_EVENT,TIME_START,TIME_END,ROOMID,COLOR_INDEX");


                FolioFacade _oFolioFacade = new FolioFacade();
                DataTable _tempData = _oFolioFacade.getGroupBookingForExportToExcel();

                foreach (DataRow _dRow in _tempData.Rows)
                {
                    string _lineStr = "";

                    _lineStr += _dRow["FromDate"].ToString() + ", ";
                    _lineStr += _dRow["ToDate"].ToString() + ", ";
                    _lineStr += _dRow["EventType"].ToString() + ", ";
                    _lineStr += _dRow["Status"].ToString() + ", ";
                    _lineStr += ", ";
                    _lineStr += _dRow["startTime"].ToString() + ", ";
                    _lineStr += _dRow["endTime"].ToString() + ", ";
                    _lineStr += _dRow["RoomID"].ToString() + ", ";

                    switch (_dRow["Status"].ToString())
                    {
                        case "ONGOING":
                            _lineStr += Color.Cyan.ToKnownColor();
                            break;

                        case "TENTATIVE":
                            _lineStr += Color.DeepSkyBlue.ToKnownColor();
                            break;

                        case "CONFIRMED":
                            _lineStr += Color.DodgerBlue.ToKnownColor() ;
                            break;

                        case "WAIT LIST":
                            _lineStr += Color.LightBlue.ToKnownColor();
                            break;
                    }

                    strWrite.WriteLine(_lineStr);
                }

                strWrite.Close();

                string _batchFile = @"..\Excel Caledar\startExcel.bat";
                System.Diagnostics.Process.Start(_batchFile);


                this.MdiParent.Cursor = Cursors.Default;
            }

            private void cboMarketingOfficer_SelectedIndexChanged(object sender, EventArgs e)
            {
                cboRecordFilter(this.cboReservationStatus.Text);
            }

            private void cboEventOfficer_SelectedIndexChanged(object sender, EventArgs e)
            {
                cboRecordFilter(this.cboReservationStatus.Text);
            }

            private void txtSearch_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    searchItem();
                }
            }

            private void dtpFrom_ValueChanged(object sender, EventArgs e)
            {
                dtpTo.MinDate = dtpFrom.Value;
                dtpTo.MaxDate = dtpFrom.Value.AddYears(1);
            }

            private void dtpTo_ValueChanged(object sender, EventArgs e)
            {
                if (dtpTo.Value < dtpFrom.Value)
                {
                    dtpTo.MinDate = dtpFrom.Value;
                    dtpTo.MaxDate = dtpFrom.Value.AddYears(1);                    
                }
                this.cboRecordFilter(cboReservationStatus.Text);
            }

            private void chkDateFilter_CheckedChanged(object sender, EventArgs e)
            {
                if (chkDateFilter.Checked)
                {
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                }
                else
                {
                    dtpFrom.Enabled = false;
                    dtpTo.Enabled = false;
                }
            }

            private void cmuEvent_Click(object sender, EventArgs e)
            {
                CellRange _range = this.grdFolio.Selection;

                int _diff = _range.r2 - _range.r1;
                if (_diff > 0)
                {
                    _diff = _diff + 1;
                    DialogResult rsp = MessageBox.Show("You are about to view '" + _diff + "' Reservation info.\r\n\r\nWould you like to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rsp == DialogResult.No)
                    {
                        return;
                    }
                }

                //this.MdiParent.Cursor = Cursors.WaitCursor;
                for (int i = _range.r1; i <= _range.r2; i++)
                {
                    //if (this.grdFolio.Rows[i]["Status"].ToString() != "TENTATIVE")
                    //{
                        string _folioID = this.grdFolio.Rows[i]["ControlNo"].ToString();
                        string _folioType = this.grdFolio.Rows[i]["FolioType"].ToString();
                        string _masterFolioID = this.grdFolio.Rows[i]["Parent"].ToString();

                        EventsUI _EventsUI = new EventsUI(_folioID);
                        _EventsUI.MdiParent = this.MdiParent;
                        _EventsUI.Show();


                        //GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_folioID);
                        //_oGroupReservationUI.MdiParent = this.MdiParent;
                        //_oGroupReservationUI.Show();
                        //this.Close();
                        return;



                        loFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioInformation, _folioID);
                        loFolioUI.MdiParent = this.MdiParent;
                        loFolioUI.Show();

                    //}
                    //else
                    //{
                    //     MessageBox.Show("This event is not yet CONFIRMED.\n Please contact your Reservation Officer!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     
                    //}

                }//end for
                this.MdiParent.Cursor = Cursors.Default;
                //this.Close();
            }

            private void btnShow_Click(object sender, EventArgs e)
            {
                cboRecordFilter(this.cboReservationStatus.Text);
            }

            private void label26_Click(object sender, EventArgs e)
            {

            }

          
		}
	}

}

