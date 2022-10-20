
using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

using C1.Win.C1FlexGrid;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Cashier.Presentation;
using Jinisys.Hotel.Accounts.Presentation;

using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.Security.Presentation;

namespace Jinisys.Hotel.Reservation.Presentation
{
	public class ReservationFolioUI : Jinisys.Hotel.UIFramework.TransactionUI
	{

		#region " Windows Form Designer generated code "

		public ReservationFolioUI()
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call

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

		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the lCode editor.
		public System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.ColumnHeader headerRoomno;
		public System.Windows.Forms.ColumnHeader headerTo;
		public System.Windows.Forms.ColumnHeader headerRate;
		internal System.Windows.Forms.ComboBox cboSource;
		internal System.Windows.Forms.Button btnBrowseAgent;
		internal System.Windows.Forms.Button btnBrowseCompany;
		public System.Windows.Forms.TextBox txtAgentName;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Button btnConfirmed;
		public System.Windows.Forms.Button btnNoShow;
		public System.Windows.Forms.Button btnCheckedOut;
		public System.Windows.Forms.Button btnCheckedIn;
		public System.Windows.Forms.Button btnCancelReservation;
		public System.Windows.Forms.ColumnHeader headerType;
		public System.Windows.Forms.ColumnHeader headerDays;
		public System.Windows.Forms.ColumnHeader headerAmount;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Button btnBrowseAccount;
		public System.Windows.Forms.TextBox txtAccountID;
		public System.Windows.Forms.Label Label40;
		public System.Windows.Forms.PictureBox picGuestImage;
		internal System.Windows.Forms.TextBox txtGuestImage;
		public System.Windows.Forms.ColumnHeader headerFrom;
		internal System.Windows.Forms.Button btnFolio;
		public System.Windows.Forms.TabControl tabFolio;
		public System.Windows.Forms.TabPage tabBooking;
		internal System.Windows.Forms.Button btnBrowseHistory;
		public System.Windows.Forms.TabPage tabGuestInfo;
		public System.Windows.Forms.TextBox txtPassportid;
		public System.Windows.Forms.Label Label27;
		public System.Windows.Forms.TextBox txtCitizenship;
		internal System.Windows.Forms.ImageList imgIcon;
		//Friend WithEvents txtCompanyID As System.Windows.Forms.TextBox
		public System.Windows.Forms.Label Label45;
		public System.Windows.Forms.TextBox txtLastName;
		public System.Windows.Forms.TextBox txtFirstName;
		public System.Windows.Forms.Label Label41;
		public System.Windows.Forms.Label Label76;
		public System.Windows.Forms.Label Label20;
		public System.Windows.Forms.Label Label21;
		public System.Windows.Forms.Label Label42;
		internal System.Windows.Forms.Button btnViewGuestList;
		public System.Windows.Forms.Label Label44;
		public System.Windows.Forms.TextBox txtAccountName;
		public System.Windows.Forms.Label Label17;
		internal System.Windows.Forms.TextBox txtCompanyId;
		internal System.Windows.Forms.TextBox txtCompanyName;
		public System.Windows.Forms.TextBox txtzip;
		public System.Windows.Forms.TextBox txtStreet;
		public System.Windows.Forms.TextBox txtCity;
		public System.Windows.Forms.TextBox txtCountry;
		public System.Windows.Forms.TextBox txtTelephoneNo;
		public System.Windows.Forms.TextBox txtMobileNo;
		public System.Windows.Forms.TextBox txtFaxNo;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label22;
		public System.Windows.Forms.Label Label25;
		public System.Windows.Forms.TextBox txtEmailAddress;
		internal System.Windows.Forms.ComboBox cboSex;
		public System.Windows.Forms.Label Label14;
		public System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Button btnPrintInfo;
		internal System.Windows.Forms.ComboBox cboTitle;
		public System.Windows.Forms.Label Label30;
		internal System.Windows.Forms.TextBox txtStatus;
		public System.Windows.Forms.TextBox txtAgentId;
		internal System.Windows.Forms.Button btnShowMaster;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label19;
		public System.Windows.Forms.TextBox txtGuestRemarks;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button btnAddHotelPromo;
		public System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Button btnSetMasterFolio;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Button btnAddBillingInstruction;
		internal System.Windows.Forms.RadioButton rdoBIPercent;
		internal System.Windows.Forms.RadioButton rdoBIAmount;
		internal System.Windows.Forms.TabPage tabBilling;
		internal System.Windows.Forms.TabPage tabPrivilege;
		internal System.Windows.Forms.TabPage tabPackage;
		internal System.Windows.Forms.TabPage tabCharges;
		internal System.Windows.Forms.Label Label16;
		public System.Windows.Forms.TextBox txtTotalRateAmount;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.NumericUpDown nudNoOfChild;
		public System.Windows.Forms.NumericUpDown nudNoOfAdults;
		public System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label28;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.TextBox txtTotalDays;
		internal System.Windows.Forms.TextBox txtFromDate;
		public System.Windows.Forms.Label Label35;
		public System.Windows.Forms.Label Label37;
		internal System.Windows.Forms.TextBox txtToDate;
		public System.Windows.Forms.Label Label36;
		internal System.Windows.Forms.Button btnRemoveBillingInstruction;
		internal System.Windows.Forms.Button btnRemoveHotelPromo;
		internal System.Windows.Forms.TextBox dtpFromDate;
		internal System.Windows.Forms.GroupBox grbFolioInfo;
		internal System.Windows.Forms.Label Label18;
		internal System.Windows.Forms.TextBox dtpDepartureDate;
		internal System.Windows.Forms.Label labeldeparturedate;
		internal System.Windows.Forms.GroupBox grbActualGuestArrivalDeparture;
		public System.Windows.Forms.Label Label26;
		internal System.Windows.Forms.TextBox txtRemarks;
		internal System.Windows.Forms.GroupBox gbxApplyPrivileges;
		internal System.Windows.Forms.ToolTip tipSked;
		internal CheckBox chkApply;
		private RadioButton rdoApplyCompanyPrivileges;
		private RadioButton rdoApplyGuestPrivilege;
		private Button btnCalendarWizard;
		internal GroupBox grpCalendar;
		internal RadioButton RadioButton1;
		internal GroupBox grpAutoRoom;
		internal RadioButton radioButton2;
		internal DateTimePicker dtpAutoFromDate;
		internal DateTimePicker dtpAutoToDate;
		public Label label32;
		public Label label31;
		private RadioButton rdAutoRoom;
		private RadioButton rbCalendar;
		public Label label29;
		internal ComboBox cboRoomType;
		internal ColumnHeader columnHeader3;
		internal ColumnHeader columnHeader4;
		internal ColumnHeader columnHeader5;
		internal ListView lvwBrowseGuestName;
		internal ListView lvwBrowseCompany;
		internal ColumnHeader ColumnHeader1;
		internal ColumnHeader ColumnHeader2;
		private TabPage tabJoiners;
		public Label label49;
		private GroupBox groupBox10;
		public TextBox txtCreateTime;
		internal Label label51;
		internal Label label50;
		public TextBox txtTotal_Sales_Contribution;
		internal Label label53;
		public TextBox txtNoOfVisits;
		internal Label label52;
		public Label label54;
		internal Button btnRemoveDependentGuest;
		internal Button btnAddDependentGuest;
		private ComboBox cboSales_Executive;
		public Label label48;
		public TextBox txtCreatedBy;
		public Label label47;
		private ComboBox cboPayment_Mode;
		public Label label57;
		private ComboBox cboAccountType;
		public Label label56;
		private ComboBox cboPurpose;
		public Label label58;
		public TextBox txtAccount_Type;
		public TextBox txtCard_No;
		internal Label label59;
		private DateTimePicker dtpBirth_Date;
		internal Button btnGuestPrivilege_Add;
		internal Button btnGuestPrivileges_Remove;
		private ListView lvwGuestPrivileges;
		private ColumnHeader columnHeader6;
		private ListView lvwCompanyPrivileges;
		private ColumnHeader columnHeader7;
		public Label label23;
		internal ComboBox cboFolioType;
		internal Button btnClose;
		public TextBox txtCreditCardNo;
		public Label label61;
		public TextBox txtCreditCardType;
		public Label label67;
		private DateTimePicker dtpCreditCardExpiry;
		public Label label69;
		private GroupBox grbCreditCardInfo;
		private C1.Win.C1FlexGrid.C1FlexGrid grdFolioSchedule;
		private C1.Win.C1FlexGrid.C1FlexGrid grdBITransactionCodes;
		private C1.Win.C1FlexGrid.C1FlexGrid grdBillingInstruction;
		private C1.Win.C1FlexGrid.C1FlexGrid grdRecurringCharges;
		private C1.Win.C1FlexGrid.C1FlexGrid grdHotelPromos;
		private C1.Win.C1FlexGrid.C1FlexGrid grdFolioPackage;
		internal Label label4;
		private C1.Win.C1FlexGrid.C1FlexGrid grdFolioPrivileges;
		public Label label6;
		private CheckBox chkTaxExempted;
		public TextBox txtBIMemo;
		public TextBox txtBICode;
		internal Label label10;
		internal Label label1;
		internal Label label12;
		public Button btnRemoveRecurringCharge;
		public Button btnAddRecurringCharge;
		internal Label label24;
		internal Label label33;
		internal Label label39;
		internal Label label43;
		internal Label label38;
		internal Label label46;
		private ContextMenuStrip cmuSchedule;
		private ToolStripMenuItem addScheduleToolStripMenuItem;
		private ToolStripMenuItem refreshToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripMenuItem deleteScheduleToolStripMenuItem;
		internal DateTimePicker dtpFolioETA;
		public Label label55;
		internal DateTimePicker dtpFolioETD;
		public Label label60;
		public Label label62;
		internal Label label63;
		internal Label label64;
		internal TextBox txtFolioPackageDaysApplied;
		public Label label34;
		private Button btnAutoSeekRoom;
		internal DateTimePicker dtpArrivalTime;
		internal DateTimePicker dtpDepartureTime;
		internal Label label65;
		internal Label label66;
		public Label label70;
		internal GroupBox groupBox3;
		internal RadioButton radioButton3;
		internal Button btnCheckOutDependentGuest;
		private ToolStripMenuItem deAllocateRoom;
		public Label label68;
		public TextBox txtConcierge;
		public TextBox txtGuestMemo;
		public Label label71;
		internal TextBox txtActualETA;
		internal TextBox txtActualETD;
		internal DateTimePicker dtpActualETD;
        private DateTimePicker dtpPackageDateTo;
        public Label label72;
        private DateTimePicker dtpPackageDateFrom;
        public TextBox txtUpdatedby;
        public Label label73;
        private ContextMenuStrip cmuJoiner;
        private ToolStripMenuItem cmReplaceJoiner;
        private TabPage tabInclusions;
        internal Label label75;
        internal Label label77;
        internal Label label74;
        internal TextBox txtRequirementNote;
        public Button btnRemoveRequirements;
        public Button btnAddRequirements;
        private C1FlexGrid grdInclusions;
        private C1FlexGrid grdFolioInclusions;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmTransferRoom;
		private C1.Win.C1FlexGrid.C1FlexGrid grdDependentGuests;

		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationFolioUI));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.headerRoomno = new System.Windows.Forms.ColumnHeader();
            this.headerTo = new System.Windows.Forms.ColumnHeader();
            this.headerRate = new System.Windows.Forms.ColumnHeader();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyId = new System.Windows.Forms.TextBox();
            this.txtAgentId = new System.Windows.Forms.TextBox();
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label30 = new System.Windows.Forms.Label();
            this.btnBrowseHistory = new System.Windows.Forms.Button();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.btnConfirmed = new System.Windows.Forms.Button();
            this.btnNoShow = new System.Windows.Forms.Button();
            this.btnCheckedOut = new System.Windows.Forms.Button();
            this.btnCheckedIn = new System.Windows.Forms.Button();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.headerType = new System.Windows.Forms.ColumnHeader();
            this.headerDays = new System.Windows.Forms.ColumnHeader();
            this.headerAmount = new System.Windows.Forms.ColumnHeader();
            this.btnSetMasterFolio = new System.Windows.Forms.Button();
            this.btnShowMaster = new System.Windows.Forms.Button();
            this.grbFolioInfo = new System.Windows.Forms.GroupBox();
            this.cboFolioType = new System.Windows.Forms.ComboBox();
            this.btnBrowseAgent = new System.Windows.Forms.Button();
            this.btnBrowseCompany = new System.Windows.Forms.Button();
            this.txtCitizenship = new System.Windows.Forms.TextBox();
            this.txtGuestImage = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.picGuestImage = new System.Windows.Forms.PictureBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cboTitle = new System.Windows.Forms.ComboBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.Label40 = new System.Windows.Forms.Label();
            this.Label44 = new System.Windows.Forms.Label();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.btnViewGuestList = new System.Windows.Forms.Button();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.Label45 = new System.Windows.Forms.Label();
            this.Label41 = new System.Windows.Forms.Label();
            this.Label42 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnBrowseAccount = new System.Windows.Forms.Button();
            this.headerFrom = new System.Windows.Forms.ColumnHeader();
            this.btnFolio = new System.Windows.Forms.Button();
            this.tabFolio = new System.Windows.Forms.TabControl();
            this.tabBooking = new System.Windows.Forms.TabPage();
            this.txtUpdatedby = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudNoOfChild = new System.Windows.Forms.NumericUpDown();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.nudNoOfAdults = new System.Windows.Forms.NumericUpDown();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.rdAutoRoom = new System.Windows.Forms.RadioButton();
            this.rbCalendar = new System.Windows.Forms.RadioButton();
            this.grpAutoRoom = new System.Windows.Forms.GroupBox();
            this.btnAutoSeekRoom = new System.Windows.Forms.Button();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.dtpAutoFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpAutoToDate = new System.Windows.Forms.DateTimePicker();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cboPurpose = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.cboPayment_Mode = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.cboAccountType = new System.Windows.Forms.ComboBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label62 = new System.Windows.Forms.Label();
            this.txtTotalRateAmount = new System.Windows.Forms.TextBox();
            this.dtpFolioETD = new System.Windows.Forms.DateTimePicker();
            this.label60 = new System.Windows.Forms.Label();
            this.dtpFolioETA = new System.Windows.Forms.DateTimePicker();
            this.label55 = new System.Windows.Forms.Label();
            this.txtTotalDays = new System.Windows.Forms.TextBox();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.Label35 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.grbActualGuestArrivalDeparture = new System.Windows.Forms.GroupBox();
            this.dtpFromDate = new System.Windows.Forms.TextBox();
            this.dtpDepartureDate = new System.Windows.Forms.TextBox();
            this.labeldeparturedate = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.txtActualETA = new System.Windows.Forms.TextBox();
            this.dtpArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.txtActualETD = new System.Windows.Forms.TextBox();
            this.dtpActualETD = new System.Windows.Forms.DateTimePicker();
            this.dtpDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.grpCalendar = new System.Windows.Forms.GroupBox();
            this.btnCalendarWizard = new System.Windows.Forms.Button();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.label56 = new System.Windows.Forms.Label();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.cboSales_Executive = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.grdFolioSchedule = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmuSchedule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deAllocateRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTransferRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.label39 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtBIMemo = new System.Windows.Forms.TextBox();
            this.txtBICode = new System.Windows.Forms.TextBox();
            this.grdBillingInstruction = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grdBITransactionCodes = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnRemoveBillingInstruction = new System.Windows.Forms.Button();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.btnAddBillingInstruction = new System.Windows.Forms.Button();
            this.rdoBIAmount = new System.Windows.Forms.RadioButton();
            this.rdoBIPercent = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCharges = new System.Windows.Forms.TabPage();
            this.label43 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRemoveRecurringCharge = new System.Windows.Forms.Button();
            this.btnAddRecurringCharge = new System.Windows.Forms.Button();
            this.grdRecurringCharges = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabPackage = new System.Windows.Forms.TabPage();
            this.dtpPackageDateTo = new System.Windows.Forms.DateTimePicker();
            this.label72 = new System.Windows.Forms.Label();
            this.dtpPackageDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtFolioPackageDaysApplied = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.grdFolioPackage = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.grdHotelPromos = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnAddHotelPromo = new System.Windows.Forms.Button();
            this.btnRemoveHotelPromo = new System.Windows.Forms.Button();
            this.Label18 = new System.Windows.Forms.Label();
            this.tabPrivilege = new System.Windows.Forms.TabPage();
            this.label38 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grdFolioPrivileges = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnGuestPrivileges_Remove = new System.Windows.Forms.Button();
            this.btnGuestPrivilege_Add = new System.Windows.Forms.Button();
            this.chkApply = new System.Windows.Forms.CheckBox();
            this.gbxApplyPrivileges = new System.Windows.Forms.GroupBox();
            this.lvwCompanyPrivileges = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.lvwGuestPrivileges = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.rdoApplyCompanyPrivileges = new System.Windows.Forms.RadioButton();
            this.rdoApplyGuestPrivilege = new System.Windows.Forms.RadioButton();
            this.tabInclusions = new System.Windows.Forms.TabPage();
            this.grdInclusions = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label75 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.txtRequirementNote = new System.Windows.Forms.TextBox();
            this.btnRemoveRequirements = new System.Windows.Forms.Button();
            this.btnAddRequirements = new System.Windows.Forms.Button();
            this.grdFolioInclusions = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabGuestInfo = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.grbCreditCardInfo = new System.Windows.Forms.GroupBox();
            this.dtpCreditCardExpiry = new System.Windows.Forms.DateTimePicker();
            this.label69 = new System.Windows.Forms.Label();
            this.txtCreditCardType = new System.Windows.Forms.TextBox();
            this.txtCreditCardNo = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.txtCard_No = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtAccount_Type = new System.Windows.Forms.TextBox();
            this.txtTotal_Sales_Contribution = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtNoOfVisits = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label68 = new System.Windows.Forms.Label();
            this.chkTaxExempted = new System.Windows.Forms.CheckBox();
            this.dtpBirth_Date = new System.Windows.Forms.DateTimePicker();
            this.label54 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.txtPassportid = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtzip = new System.Windows.Forms.TextBox();
            this.txtTelephoneNo = new System.Windows.Forms.TextBox();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.txtGuestRemarks = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label76 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.txtConcierge = new System.Windows.Forms.TextBox();
            this.txtGuestMemo = new System.Windows.Forms.TextBox();
            this.tabJoiners = new System.Windows.Forms.TabPage();
            this.btnCheckOutDependentGuest = new System.Windows.Forms.Button();
            this.grdDependentGuests = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cmuJoiner = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmReplaceJoiner = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveDependentGuest = new System.Windows.Forms.Button();
            this.btnAddDependentGuest = new System.Windows.Forms.Button();
            this.btnPrintInfo = new System.Windows.Forms.Button();
            this.tipSked = new System.Windows.Forms.ToolTip(this.components);
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.lvwBrowseGuestName = new System.Windows.Forms.ListView();
            this.lvwBrowseCompany = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.grbFolioInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGuestImage)).BeginInit();
            this.tabFolio.SuspendLayout();
            this.tabBooking.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfAdults)).BeginInit();
            this.grpAutoRoom.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.grbActualGuestArrivalDeparture.SuspendLayout();
            this.grpCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioSchedule)).BeginInit();
            this.cmuSchedule.SuspendLayout();
            this.tabBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillingInstruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBITransactionCodes)).BeginInit();
            this.tabCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecurringCharges)).BeginInit();
            this.tabPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHotelPromos)).BeginInit();
            this.tabPrivilege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPrivileges)).BeginInit();
            this.gbxApplyPrivileges.SuspendLayout();
            this.tabInclusions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioInclusions)).BeginInit();
            this.tabGuestInfo.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.grbCreditCardInfo.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.tabJoiners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDependentGuests)).BeginInit();
            this.cmuJoiner.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(699, 607);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 31);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(627, 607);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 31);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Ca&ncel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // headerRoomno
            // 
            this.headerRoomno.Text = "Room#";
            this.headerRoomno.Width = 45;
            // 
            // headerTo
            // 
            this.headerTo.Text = "To";
            this.headerTo.Width = 150;
            // 
            // headerRate
            // 
            this.headerRate.Text = "Rate";
            this.headerRate.Width = 45;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyName.Location = new System.Drawing.Point(15, 114);
            this.txtCompanyName.MaxLength = 500;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(221, 20);
            this.txtCompanyName.TabIndex = 11;
            this.txtCompanyName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            // 
            // txtCompanyId
            // 
            this.txtCompanyId.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCompanyId.Location = new System.Drawing.Point(15, 114);
            this.txtCompanyId.Name = "txtCompanyId";
            this.txtCompanyId.Size = new System.Drawing.Size(68, 20);
            this.txtCompanyId.TabIndex = 14;
            this.txtCompanyId.TextChanged += new System.EventHandler(this.txtCompanyId_TextChanged);
            // 
            // txtAgentId
            // 
            this.txtAgentId.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtAgentId.Location = new System.Drawing.Point(15, 148);
            this.txtAgentId.Name = "txtAgentId";
            this.txtAgentId.Size = new System.Drawing.Size(74, 20);
            this.txtAgentId.TabIndex = 17;
            // 
            // imgIcon
            // 
            this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
            this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcon.Images.SetKeyName(0, "");
            this.imgIcon.Images.SetKeyName(1, "Find_ico_6.ico");
            // 
            // txtAgentName
            // 
            this.txtAgentName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgentName.Location = new System.Drawing.Point(15, 148);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(221, 20);
            this.txtAgentName.TabIndex = 13;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(27, 98);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(73, 14);
            this.Label5.TabIndex = 58;
            this.Label5.Text = "Company";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label30
            // 
            this.Label30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label30.Location = new System.Drawing.Point(28, 134);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(80, 14);
            this.Label30.TabIndex = 93;
            this.Label30.Text = "Travel Agent";
            this.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseHistory
            // 
            this.btnBrowseHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseHistory.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseHistory.Location = new System.Drawing.Point(703, 104);
            this.btnBrowseHistory.Name = "btnBrowseHistory";
            this.btnBrowseHistory.Size = new System.Drawing.Size(105, 23);
            this.btnBrowseHistory.TabIndex = 16;
            this.btnBrowseHistory.Text = "Folio &History";
            this.btnBrowseHistory.Click += new System.EventHandler(this.btnBrowseHistory_Click);
            // 
            // cboSource
            // 
            this.cboSource.BackColor = System.Drawing.SystemColors.Info;
            this.cboSource.Items.AddRange(new object[] {
            "ADVERTISEMENT",
            "FOREIGN",
            "TELEPHONE",
            "FAX",
            "WALK IN",
            "EMAIL",
            "TAXI CAB"});
            this.cboSource.Location = new System.Drawing.Point(553, 32);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(128, 22);
            this.cboSource.TabIndex = 24;
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(553, 17);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(127, 15);
            this.Label13.TabIndex = 62;
            this.Label13.Text = "Source";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirmed
            // 
            this.btnConfirmed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirmed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnConfirmed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConfirmed.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmed.Location = new System.Drawing.Point(521, 607);
            this.btnConfirmed.Name = "btnConfirmed";
            this.btnConfirmed.Size = new System.Drawing.Size(70, 31);
            this.btnConfirmed.TabIndex = 8;
            this.btnConfirmed.Text = "Confir&m";
            this.btnConfirmed.UseVisualStyleBackColor = false;
            this.btnConfirmed.Click += new System.EventHandler(this.btnConfirmed_Click);
            // 
            // btnNoShow
            // 
            this.btnNoShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNoShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNoShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNoShow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoShow.Location = new System.Drawing.Point(305, 607);
            this.btnNoShow.Name = "btnNoShow";
            this.btnNoShow.Size = new System.Drawing.Size(70, 31);
            this.btnNoShow.TabIndex = 5;
            this.btnNoShow.Text = "No Sho&w";
            this.btnNoShow.UseVisualStyleBackColor = false;
            this.btnNoShow.Click += new System.EventHandler(this.btnNoShow_Click);
            // 
            // btnCheckedOut
            // 
            this.btnCheckedOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCheckedOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCheckedOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCheckedOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckedOut.Location = new System.Drawing.Point(377, 607);
            this.btnCheckedOut.Name = "btnCheckedOut";
            this.btnCheckedOut.Size = new System.Drawing.Size(70, 31);
            this.btnCheckedOut.TabIndex = 6;
            this.btnCheckedOut.Text = "Check &Out";
            this.btnCheckedOut.UseVisualStyleBackColor = false;
            this.btnCheckedOut.Click += new System.EventHandler(this.btnCheckedOut_Click);
            // 
            // btnCheckedIn
            // 
            this.btnCheckedIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCheckedIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCheckedIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCheckedIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckedIn.Location = new System.Drawing.Point(449, 607);
            this.btnCheckedIn.Name = "btnCheckedIn";
            this.btnCheckedIn.Size = new System.Drawing.Size(70, 31);
            this.btnCheckedIn.TabIndex = 7;
            this.btnCheckedIn.Text = "Check &In";
            this.btnCheckedIn.UseVisualStyleBackColor = false;
            this.btnCheckedIn.Click += new System.EventHandler(this.btnCheckedIn_Click);
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelReservation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancelReservation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelReservation.Location = new System.Drawing.Point(184, 607);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(119, 31);
            this.btnCancelReservation.TabIndex = 4;
            this.btnCancelReservation.Text = "&Cancel Reservation";
            this.btnCancelReservation.UseVisualStyleBackColor = false;
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
            // 
            // headerType
            // 
            this.headerType.Text = "Type";
            this.headerType.Width = 50;
            // 
            // headerDays
            // 
            this.headerDays.Text = "Days";
            this.headerDays.Width = 45;
            // 
            // headerAmount
            // 
            this.headerAmount.Text = "Amount";
            // 
            // btnSetMasterFolio
            // 
            this.btnSetMasterFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetMasterFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetMasterFolio.Location = new System.Drawing.Point(703, 155);
            this.btnSetMasterFolio.Name = "btnSetMasterFolio";
            this.btnSetMasterFolio.Size = new System.Drawing.Size(106, 24);
            this.btnSetMasterFolio.TabIndex = 18;
            this.btnSetMasterFolio.Text = "Set Mas&ter";
            this.btnSetMasterFolio.Visible = false;
            this.btnSetMasterFolio.Click += new System.EventHandler(this.btnSetMasterFolio_Click);
            // 
            // btnShowMaster
            // 
            this.btnShowMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMaster.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowMaster.Location = new System.Drawing.Point(703, 129);
            this.btnShowMaster.Name = "btnShowMaster";
            this.btnShowMaster.Size = new System.Drawing.Size(106, 24);
            this.btnShowMaster.TabIndex = 17;
            this.btnShowMaster.Text = "Show Mas&ter";
            this.btnShowMaster.Visible = false;
            this.btnShowMaster.Click += new System.EventHandler(this.btnShowMaster_Click);
            // 
            // grbFolioInfo
            // 
            this.grbFolioInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFolioInfo.Controls.Add(this.txtCompanyName);
            this.grbFolioInfo.Controls.Add(this.btnSetMasterFolio);
            this.grbFolioInfo.Controls.Add(this.cboFolioType);
            this.grbFolioInfo.Controls.Add(this.btnBrowseAgent);
            this.grbFolioInfo.Controls.Add(this.btnBrowseHistory);
            this.grbFolioInfo.Controls.Add(this.btnBrowseCompany);
            this.grbFolioInfo.Controls.Add(this.btnShowMaster);
            this.grbFolioInfo.Controls.Add(this.txtAgentName);
            this.grbFolioInfo.Controls.Add(this.txtCitizenship);
            this.grbFolioInfo.Controls.Add(this.Label5);
            this.grbFolioInfo.Controls.Add(this.txtGuestImage);
            this.grbFolioInfo.Controls.Add(this.txtRemarks);
            this.grbFolioInfo.Controls.Add(this.picGuestImage);
            this.grbFolioInfo.Controls.Add(this.Label26);
            this.grbFolioInfo.Controls.Add(this.Label13);
            this.grbFolioInfo.Controls.Add(this.txtStatus);
            this.grbFolioInfo.Controls.Add(this.cboSource);
            this.grbFolioInfo.Controls.Add(this.Label3);
            this.grbFolioInfo.Controls.Add(this.cboTitle);
            this.grbFolioInfo.Controls.Add(this.Label17);
            this.grbFolioInfo.Controls.Add(this.cboSex);
            this.grbFolioInfo.Controls.Add(this.txtAccountName);
            this.grbFolioInfo.Controls.Add(this.Label40);
            this.grbFolioInfo.Controls.Add(this.Label44);
            this.grbFolioInfo.Controls.Add(this.txtAccountID);
            this.grbFolioInfo.Controls.Add(this.btnViewGuestList);
            this.grbFolioInfo.Controls.Add(this.Label9);
            this.grbFolioInfo.Controls.Add(this.txtLastName);
            this.grbFolioInfo.Controls.Add(this.Label45);
            this.grbFolioInfo.Controls.Add(this.Label41);
            this.grbFolioInfo.Controls.Add(this.Label42);
            this.grbFolioInfo.Controls.Add(this.txtFirstName);
            this.grbFolioInfo.Controls.Add(this.label23);
            this.grbFolioInfo.Controls.Add(this.txtAgentId);
            this.grbFolioInfo.Controls.Add(this.txtCompanyId);
            this.grbFolioInfo.Controls.Add(this.Label30);
            this.grbFolioInfo.Location = new System.Drawing.Point(12, 36);
            this.grbFolioInfo.Name = "grbFolioInfo";
            this.grbFolioInfo.Size = new System.Drawing.Size(829, 184);
            this.grbFolioInfo.TabIndex = 0;
            this.grbFolioInfo.TabStop = false;
            // 
            // cboFolioType
            // 
            this.cboFolioType.BackColor = System.Drawing.SystemColors.Info;
            this.cboFolioType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboFolioType.Items.AddRange(new object[] {
            "INDIVIDUAL",
            "DEPENDENT",
            "SHARE",
            "NON-STAYING"});
            this.cboFolioType.Location = new System.Drawing.Point(246, 32);
            this.cboFolioType.Name = "cboFolioType";
            this.cboFolioType.Size = new System.Drawing.Size(144, 22);
            this.cboFolioType.TabIndex = 22;
            this.cboFolioType.SelectedIndexChanged += new System.EventHandler(this.cboFolioType_SelectedIndexChanged);
            // 
            // btnBrowseAgent
            // 
            this.btnBrowseAgent.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.search_small;
            this.btnBrowseAgent.Location = new System.Drawing.Point(241, 146);
            this.btnBrowseAgent.Name = "btnBrowseAgent";
            this.btnBrowseAgent.Size = new System.Drawing.Size(25, 25);
            this.btnBrowseAgent.TabIndex = 14;
            this.btnBrowseAgent.Click += new System.EventHandler(this.btnBrowseAgent_Click);
            // 
            // btnBrowseCompany
            // 
            this.btnBrowseCompany.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.search_small;
            this.btnBrowseCompany.Location = new System.Drawing.Point(241, 112);
            this.btnBrowseCompany.Name = "btnBrowseCompany";
            this.btnBrowseCompany.Size = new System.Drawing.Size(25, 25);
            this.btnBrowseCompany.TabIndex = 12;
            this.btnBrowseCompany.Click += new System.EventHandler(this.btnBrowseCompany_Click);
            // 
            // txtCitizenship
            // 
            this.txtCitizenship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCitizenship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCitizenship.BackColor = System.Drawing.SystemColors.Info;
            this.txtCitizenship.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCitizenship.Location = new System.Drawing.Point(433, 72);
            this.txtCitizenship.MaxLength = 100;
            this.txtCitizenship.Name = "txtCitizenship";
            this.txtCitizenship.Size = new System.Drawing.Size(114, 20);
            this.txtCitizenship.TabIndex = 9;
            this.txtCitizenship.TextChanged += new System.EventHandler(this.txtCitizenship_TextChanged);
            // 
            // txtGuestImage
            // 
            this.txtGuestImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGuestImage.Location = new System.Drawing.Point(713, 51);
            this.txtGuestImage.Name = "txtGuestImage";
            this.txtGuestImage.Size = new System.Drawing.Size(86, 20);
            this.txtGuestImage.TabIndex = 19;
            this.txtGuestImage.Visible = false;
            this.txtGuestImage.TextChanged += new System.EventHandler(this.txtGuestImage_TextChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarks.Location = new System.Drawing.Point(284, 111);
            this.txtRemarks.MaxLength = 500;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(397, 60);
            this.txtRemarks.TabIndex = 15;
            // 
            // picGuestImage
            // 
            this.picGuestImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picGuestImage.BackColor = System.Drawing.SystemColors.Control;
            this.picGuestImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGuestImage.Location = new System.Drawing.Point(703, 11);
            this.picGuestImage.Name = "picGuestImage";
            this.picGuestImage.Size = new System.Drawing.Size(104, 86);
            this.picGuestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGuestImage.TabIndex = 0;
            this.picGuestImage.TabStop = false;
            // 
            // Label26
            // 
            this.Label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label26.Location = new System.Drawing.Point(301, 95);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(58, 15);
            this.Label26.TabIndex = 63;
            this.Label26.Text = "Remarks";
            this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Info;
            this.txtStatus.ForeColor = System.Drawing.Color.Red;
            this.txtStatus.Location = new System.Drawing.Point(433, 33);
            this.txtStatus.MaxLength = 20;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(114, 20);
            this.txtStatus.TabIndex = 23;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(247, 17);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(142, 15);
            this.Label3.TabIndex = 66;
            this.Label3.Text = "Folio Type";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboTitle
            // 
            this.cboTitle.BackColor = System.Drawing.SystemColors.Info;
            this.cboTitle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTitle.Items.AddRange(new object[] {
            "",
            "MR.",
            "MS.",
            "MRS.",
            "DR.",
            "ATTY.",
            "ENGR."});
            this.cboTitle.Location = new System.Drawing.Point(14, 71);
            this.cboTitle.Name = "cboTitle";
            this.cboTitle.Size = new System.Drawing.Size(75, 22);
            this.cboTitle.TabIndex = 25;
            // 
            // Label17
            // 
            this.Label17.BackColor = System.Drawing.SystemColors.Control;
            this.Label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(99, 17);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(142, 14);
            this.Label17.TabIndex = 88;
            this.Label17.Text = "Account Name";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSex
            // 
            this.cboSex.BackColor = System.Drawing.SystemColors.Info;
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Items.AddRange(new object[] {
            "",
            "MALE",
            "FEMALE"});
            this.cboSex.Location = new System.Drawing.Point(556, 71);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(125, 22);
            this.cboSex.TabIndex = 10;
            // 
            // txtAccountName
            // 
            this.txtAccountName.BackColor = System.Drawing.Color.White;
            this.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountName.Location = new System.Drawing.Point(97, 33);
            this.txtAccountName.MaxLength = 50;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.ReadOnly = true;
            this.txtAccountName.Size = new System.Drawing.Size(143, 20);
            this.txtAccountName.TabIndex = 21;
            // 
            // Label40
            // 
            this.Label40.BackColor = System.Drawing.SystemColors.Control;
            this.Label40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label40.Location = new System.Drawing.Point(433, 17);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(114, 15);
            this.Label40.TabIndex = 31;
            this.Label40.Text = "Status";
            this.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label44
            // 
            this.Label44.BackColor = System.Drawing.SystemColors.Control;
            this.Label44.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label44.Location = new System.Drawing.Point(14, 56);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(77, 14);
            this.Label44.TabIndex = 86;
            this.Label44.Text = "Title";
            this.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAccountID
            // 
            this.txtAccountID.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtAccountID.Location = new System.Drawing.Point(14, 33);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.ReadOnly = true;
            this.txtAccountID.Size = new System.Drawing.Size(74, 20);
            this.txtAccountID.TabIndex = 20;
            this.txtAccountID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccountID.TextChanged += new System.EventHandler(this.txtAccountID_TextChanged);
            // 
            // btnViewGuestList
            // 
            this.btnViewGuestList.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.search_small;
            this.btnViewGuestList.Location = new System.Drawing.Point(394, 70);
            this.btnViewGuestList.Name = "btnViewGuestList";
            this.btnViewGuestList.Size = new System.Drawing.Size(25, 25);
            this.btnViewGuestList.TabIndex = 8;
            this.btnViewGuestList.Click += new System.EventHandler(this.btnViewGuestList_Click);
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.SystemColors.Control;
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(14, 16);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(74, 16);
            this.Label9.TabIndex = 92;
            this.Label9.Text = "Account No.";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.SystemColors.Info;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(97, 72);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(144, 20);
            this.txtLastName.TabIndex = 6;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLastName_KeyDown);
            // 
            // Label45
            // 
            this.Label45.BackColor = System.Drawing.Color.Transparent;
            this.Label45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label45.Location = new System.Drawing.Point(553, 57);
            this.Label45.Name = "Label45";
            this.Label45.Size = new System.Drawing.Size(128, 12);
            this.Label45.TabIndex = 81;
            this.Label45.Text = "Gender";
            this.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label41
            // 
            this.Label41.BackColor = System.Drawing.SystemColors.Control;
            this.Label41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label41.ForeColor = System.Drawing.Color.Black;
            this.Label41.Location = new System.Drawing.Point(246, 57);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(143, 12);
            this.Label41.TabIndex = 79;
            this.Label41.Text = "First Name";
            this.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label42
            // 
            this.Label42.BackColor = System.Drawing.SystemColors.Control;
            this.Label42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label42.ForeColor = System.Drawing.Color.Black;
            this.Label42.Location = new System.Drawing.Point(97, 57);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(144, 12);
            this.Label42.TabIndex = 80;
            this.Label42.Text = "Last Name";
            this.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.SystemColors.Info;
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Location = new System.Drawing.Point(246, 72);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(144, 20);
            this.txtFirstName.TabIndex = 7;
            this.txtFirstName.Leave += new System.EventHandler(this.txtFirstName_Leave);
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirstName_KeyDown);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(433, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(114, 15);
            this.label23.TabIndex = 93;
            this.label23.Text = "Citizenship";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBrowseAccount
            // 
            this.btnBrowseAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBrowseAccount.Location = new System.Drawing.Point(664, 67);
            this.btnBrowseAccount.Name = "btnBrowseAccount";
            this.btnBrowseAccount.Size = new System.Drawing.Size(28, 17);
            this.btnBrowseAccount.TabIndex = 40;
            this.btnBrowseAccount.Text = "...";
            this.btnBrowseAccount.UseVisualStyleBackColor = false;
            // 
            // headerFrom
            // 
            this.headerFrom.Text = "From";
            this.headerFrom.Width = 150;
            // 
            // btnFolio
            // 
            this.btnFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolio.Location = new System.Drawing.Point(12, 607);
            this.btnFolio.Name = "btnFolio";
            this.btnFolio.Size = new System.Drawing.Size(70, 31);
            this.btnFolio.TabIndex = 2;
            this.btnFolio.Text = "&Folio";
            this.btnFolio.Click += new System.EventHandler(this.btnFolio_Click);
            // 
            // tabFolio
            // 
            this.tabFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFolio.Controls.Add(this.tabBooking);
            this.tabFolio.Controls.Add(this.tabBilling);
            this.tabFolio.Controls.Add(this.tabCharges);
            this.tabFolio.Controls.Add(this.tabPackage);
            this.tabFolio.Controls.Add(this.tabPrivilege);
            this.tabFolio.Controls.Add(this.tabInclusions);
            this.tabFolio.Controls.Add(this.tabGuestInfo);
            this.tabFolio.Controls.Add(this.tabJoiners);
            this.tabFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFolio.HotTrack = true;
            this.tabFolio.Location = new System.Drawing.Point(10, 225);
            this.tabFolio.Name = "tabFolio";
            this.tabFolio.SelectedIndex = 0;
            this.tabFolio.ShowToolTips = true;
            this.tabFolio.Size = new System.Drawing.Size(831, 373);
            this.tabFolio.TabIndex = 1;
            // 
            // tabBooking
            // 
            this.tabBooking.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabBooking.Controls.Add(this.txtUpdatedby);
            this.tabBooking.Controls.Add(this.label73);
            this.tabBooking.Controls.Add(this.groupBox3);
            this.tabBooking.Controls.Add(this.rdAutoRoom);
            this.tabBooking.Controls.Add(this.rbCalendar);
            this.tabBooking.Controls.Add(this.grpAutoRoom);
            this.tabBooking.Controls.Add(this.cboPurpose);
            this.tabBooking.Controls.Add(this.label58);
            this.tabBooking.Controls.Add(this.cboPayment_Mode);
            this.tabBooking.Controls.Add(this.label57);
            this.tabBooking.Controls.Add(this.cboAccountType);
            this.tabBooking.Controls.Add(this.GroupBox2);
            this.tabBooking.Controls.Add(this.grbActualGuestArrivalDeparture);
            this.tabBooking.Controls.Add(this.grpCalendar);
            this.tabBooking.Controls.Add(this.label56);
            this.tabBooking.Controls.Add(this.txtCreatedBy);
            this.tabBooking.Controls.Add(this.label47);
            this.tabBooking.Controls.Add(this.cboSales_Executive);
            this.tabBooking.Controls.Add(this.label48);
            this.tabBooking.Controls.Add(this.grdFolioSchedule);
            this.tabBooking.Location = new System.Drawing.Point(4, 23);
            this.tabBooking.Name = "tabBooking";
            this.tabBooking.Size = new System.Drawing.Size(823, 346);
            this.tabBooking.TabIndex = 0;
            this.tabBooking.Text = "Booking Information     ";
            this.tabBooking.UseVisualStyleBackColor = true;
            // 
            // txtUpdatedby
            // 
            this.txtUpdatedby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdatedby.BackColor = System.Drawing.Color.White;
            this.txtUpdatedby.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUpdatedby.Location = new System.Drawing.Point(654, 315);
            this.txtUpdatedby.Name = "txtUpdatedby";
            this.txtUpdatedby.ReadOnly = true;
            this.txtUpdatedby.Size = new System.Drawing.Size(75, 20);
            this.txtUpdatedby.TabIndex = 128;
            // 
            // label73
            // 
            this.label73.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label73.BackColor = System.Drawing.SystemColors.Control;
            this.label73.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.Location = new System.Drawing.Point(651, 294);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(79, 16);
            this.label73.TabIndex = 129;
            this.label73.Text = "Updated by";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.nudNoOfChild);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.nudNoOfAdults);
            this.groupBox3.Controls.Add(this.Label7);
            this.groupBox3.Controls.Add(this.Label8);
            this.groupBox3.Location = new System.Drawing.Point(421, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(103, 88);
            this.groupBox3.TabIndex = 127;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Occupancy";
            // 
            // nudNoOfChild
            // 
            this.nudNoOfChild.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNoOfChild.Location = new System.Drawing.Point(47, 54);
            this.nudNoOfChild.Name = "nudNoOfChild";
            this.nudNoOfChild.Size = new System.Drawing.Size(41, 20);
            this.nudNoOfChild.TabIndex = 4;
            this.nudNoOfChild.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(484, 384);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 24);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.Text = "Manual";
            // 
            // nudNoOfAdults
            // 
            this.nudNoOfAdults.BackColor = System.Drawing.SystemColors.Info;
            this.nudNoOfAdults.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNoOfAdults.Location = new System.Drawing.Point(47, 25);
            this.nudNoOfAdults.Name = "nudNoOfAdults";
            this.nudNoOfAdults.Size = new System.Drawing.Size(41, 20);
            this.nudNoOfAdults.TabIndex = 3;
            this.nudNoOfAdults.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNoOfAdults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoOfAdults.ValueChanged += new System.EventHandler(this.nudNoOfAdults_ValueChanged);
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(11, 57);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(32, 14);
            this.Label7.TabIndex = 50;
            this.Label7.Text = "Child";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(11, 28);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(37, 14);
            this.Label8.TabIndex = 51;
            this.Label8.Text = "Adult";
            // 
            // rdAutoRoom
            // 
            this.rdAutoRoom.AutoSize = true;
            this.rdAutoRoom.Location = new System.Drawing.Point(144, 9);
            this.rdAutoRoom.Name = "rdAutoRoom";
            this.rdAutoRoom.Size = new System.Drawing.Size(93, 18);
            this.rdAutoRoom.TabIndex = 1;
            this.rdAutoRoom.Text = "Auto-Rooming";
            this.rdAutoRoom.UseVisualStyleBackColor = true;
            // 
            // rbCalendar
            // 
            this.rbCalendar.AutoSize = true;
            this.rbCalendar.Checked = true;
            this.rbCalendar.Location = new System.Drawing.Point(19, 9);
            this.rbCalendar.Name = "rbCalendar";
            this.rbCalendar.Size = new System.Drawing.Size(105, 18);
            this.rbCalendar.TabIndex = 0;
            this.rbCalendar.TabStop = true;
            this.rbCalendar.Text = "Calendar Wizard";
            this.rbCalendar.UseVisualStyleBackColor = true;
            this.rbCalendar.CheckedChanged += new System.EventHandler(this.rbCalendar_CheckedChanged);
            // 
            // grpAutoRoom
            // 
            this.grpAutoRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAutoRoom.Controls.Add(this.btnAutoSeekRoom);
            this.grpAutoRoom.Controls.Add(this.cboRoomType);
            this.grpAutoRoom.Controls.Add(this.dtpAutoFromDate);
            this.grpAutoRoom.Controls.Add(this.dtpAutoToDate);
            this.grpAutoRoom.Controls.Add(this.radioButton2);
            this.grpAutoRoom.Controls.Add(this.label32);
            this.grpAutoRoom.Controls.Add(this.label31);
            this.grpAutoRoom.Controls.Add(this.label29);
            this.grpAutoRoom.Enabled = false;
            this.grpAutoRoom.Location = new System.Drawing.Point(133, 12);
            this.grpAutoRoom.Name = "grpAutoRoom";
            this.grpAutoRoom.Size = new System.Drawing.Size(674, 55);
            this.grpAutoRoom.TabIndex = 82;
            this.grpAutoRoom.TabStop = false;
            // 
            // btnAutoSeekRoom
            // 
            this.btnAutoSeekRoom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAutoSeekRoom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSeekRoom.ForeColor = System.Drawing.Color.Navy;
            this.btnAutoSeekRoom.Location = new System.Drawing.Point(622, 21);
            this.btnAutoSeekRoom.Name = "btnAutoSeekRoom";
            this.btnAutoSeekRoom.Size = new System.Drawing.Size(41, 24);
            this.btnAutoSeekRoom.TabIndex = 135;
            this.btnAutoSeekRoom.Text = "&Go";
            this.btnAutoSeekRoom.UseVisualStyleBackColor = false;
            this.btnAutoSeekRoom.Click += new System.EventHandler(this.btnAutoSeekRoom_Click);
            // 
            // cboRoomType
            // 
            this.cboRoomType.BackColor = System.Drawing.SystemColors.Info;
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoomType.ItemHeight = 14;
            this.cboRoomType.Location = new System.Drawing.Point(86, 24);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(138, 22);
            this.cboRoomType.TabIndex = 0;
            // 
            // dtpAutoFromDate
            // 
            this.dtpAutoFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpAutoFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAutoFromDate.Location = new System.Drawing.Point(307, 24);
            this.dtpAutoFromDate.Name = "dtpAutoFromDate";
            this.dtpAutoFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtpAutoFromDate.TabIndex = 1;
            // 
            // dtpAutoToDate
            // 
            this.dtpAutoToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpAutoToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAutoToDate.Location = new System.Drawing.Point(511, 24);
            this.dtpAutoToDate.Name = "dtpAutoToDate";
            this.dtpAutoToDate.Size = new System.Drawing.Size(98, 20);
            this.dtpAutoToDate.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(484, 384);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 24);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "Manual";
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(422, 27);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(88, 15);
            this.label32.TabIndex = 132;
            this.label32.Text = "Departure Date :";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(231, 27);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 15);
            this.label31.TabIndex = 131;
            this.label31.Text = "Arrival Date :";
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(14, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(69, 15);
            this.label29.TabIndex = 134;
            this.label29.Text = "Room Type :";
            // 
            // cboPurpose
            // 
            this.cboPurpose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPurpose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPurpose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPurpose.BackColor = System.Drawing.SystemColors.Info;
            this.cboPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPurpose.FormattingEnabled = true;
            this.cboPurpose.Items.AddRange(new object[] {
            "PERSONAL",
            "TOURIST",
            "BUSINESS",
            "CONVENTION",
            "BALIKBAYAN",
            "PARTY"});
            this.cboPurpose.Location = new System.Drawing.Point(305, 313);
            this.cboPurpose.Name = "cboPurpose";
            this.cboPurpose.Size = new System.Drawing.Size(134, 22);
            this.cboPurpose.TabIndex = 7;
            // 
            // label58
            // 
            this.label58.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label58.BackColor = System.Drawing.SystemColors.Control;
            this.label58.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Black;
            this.label58.Location = new System.Drawing.Point(305, 293);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(124, 16);
            this.label58.TabIndex = 97;
            this.label58.Text = "Purpose";
            // 
            // cboPayment_Mode
            // 
            this.cboPayment_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPayment_Mode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPayment_Mode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPayment_Mode.BackColor = System.Drawing.SystemColors.Info;
            this.cboPayment_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayment_Mode.FormattingEnabled = true;
            this.cboPayment_Mode.Items.AddRange(new object[] {
            "CASH",
            "CHARGE",
            "CREDIT CARD",
            "CHEQUE",
            "EX-DEAL",
            "OTHERS"});
            this.cboPayment_Mode.Location = new System.Drawing.Point(161, 313);
            this.cboPayment_Mode.Name = "cboPayment_Mode";
            this.cboPayment_Mode.Size = new System.Drawing.Size(134, 22);
            this.cboPayment_Mode.TabIndex = 6;
            // 
            // label57
            // 
            this.label57.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label57.BackColor = System.Drawing.SystemColors.Control;
            this.label57.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.Location = new System.Drawing.Point(161, 293);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(124, 16);
            this.label57.TabIndex = 95;
            this.label57.Text = "Payment Mode";
            // 
            // cboAccountType
            // 
            this.cboAccountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboAccountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAccountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccountType.BackColor = System.Drawing.SystemColors.Info;
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.Items.AddRange(new object[] {
            "PERSONAL",
            "CORPORATE"});
            this.cboAccountType.Location = new System.Drawing.Point(16, 313);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(134, 22);
            this.cboAccountType.TabIndex = 5;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox2.Controls.Add(this.label62);
            this.GroupBox2.Controls.Add(this.txtTotalRateAmount);
            this.GroupBox2.Controls.Add(this.dtpFolioETD);
            this.GroupBox2.Controls.Add(this.label60);
            this.GroupBox2.Controls.Add(this.dtpFolioETA);
            this.GroupBox2.Controls.Add(this.label55);
            this.GroupBox2.Controls.Add(this.txtTotalDays);
            this.GroupBox2.Controls.Add(this.txtFromDate);
            this.GroupBox2.Controls.Add(this.Label35);
            this.GroupBox2.Controls.Add(this.txtToDate);
            this.GroupBox2.Controls.Add(this.Label37);
            this.GroupBox2.Controls.Add(this.Label36);
            this.GroupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(14, 189);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(404, 88);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Schedule";
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label62.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(278, 58);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(39, 13);
            this.label62.TabIndex = 58;
            this.label62.Text = "Total :";
            // 
            // txtTotalRateAmount
            // 
            this.txtTotalRateAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalRateAmount.Location = new System.Drawing.Point(318, 54);
            this.txtTotalRateAmount.Name = "txtTotalRateAmount";
            this.txtTotalRateAmount.ReadOnly = true;
            this.txtTotalRateAmount.Size = new System.Drawing.Size(75, 20);
            this.txtTotalRateAmount.TabIndex = 25;
            this.txtTotalRateAmount.Text = "0.00";
            this.txtTotalRateAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFolioETD
            // 
            this.dtpFolioETD.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETD.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETD.CustomFormat = "hh:mm tt";
            this.dtpFolioETD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFolioETD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFolioETD.Location = new System.Drawing.Point(192, 54);
            this.dtpFolioETD.Name = "dtpFolioETD";
            this.dtpFolioETD.ShowUpDown = true;
            this.dtpFolioETD.Size = new System.Drawing.Size(75, 20);
            this.dtpFolioETD.TabIndex = 57;
            this.tipSked.SetToolTip(this.dtpFolioETD, "Actual Guest Arrival");
            this.dtpFolioETD.Value = new System.DateTime(2006, 5, 2, 18, 50, 39, 421);
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label60.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(158, 57);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(39, 14);
            this.label60.TabIndex = 56;
            this.label60.Text = "ETD :";
            // 
            // dtpFolioETA
            // 
            this.dtpFolioETA.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETA.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETA.CustomFormat = "hh:mm tt";
            this.dtpFolioETA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFolioETA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFolioETA.Location = new System.Drawing.Point(192, 25);
            this.dtpFolioETA.Name = "dtpFolioETA";
            this.dtpFolioETA.ShowUpDown = true;
            this.dtpFolioETA.Size = new System.Drawing.Size(75, 20);
            this.dtpFolioETA.TabIndex = 55;
            this.tipSked.SetToolTip(this.dtpFolioETA, "Actual Guest Arrival");
            this.dtpFolioETA.Value = new System.DateTime(2006, 5, 2, 18, 50, 39, 421);
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label55.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(158, 28);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(39, 14);
            this.label55.TabIndex = 53;
            this.label55.Text = "ETA :";
            // 
            // txtTotalDays
            // 
            this.txtTotalDays.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalDays.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDays.Location = new System.Drawing.Point(318, 25);
            this.txtTotalDays.Name = "txtTotalDays";
            this.txtTotalDays.ReadOnly = true;
            this.txtTotalDays.Size = new System.Drawing.Size(75, 20);
            this.txtTotalDays.TabIndex = 30;
            this.txtTotalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFromDate
            // 
            this.txtFromDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtFromDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(68, 25);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ReadOnly = true;
            this.txtFromDate.Size = new System.Drawing.Size(84, 20);
            this.txtFromDate.TabIndex = 28;
            this.txtFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFromDate.TextChanged += new System.EventHandler(this.txtFromDate_TextChanged);
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Label35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.Location = new System.Drawing.Point(278, 29);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(39, 13);
            this.Label35.TabIndex = 52;
            this.Label35.Text = "Days :";
            // 
            // txtToDate
            // 
            this.txtToDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtToDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Location = new System.Drawing.Point(68, 54);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ReadOnly = true;
            this.txtToDate.Size = new System.Drawing.Size(84, 20);
            this.txtToDate.TabIndex = 29;
            this.txtToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtToDate.TextChanged += new System.EventHandler(this.txtToDate_TextChanged);
            // 
            // Label37
            // 
            this.Label37.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Label37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label37.Location = new System.Drawing.Point(8, 29);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(62, 13);
            this.Label37.TabIndex = 25;
            this.Label37.Text = "Arrival :";
            // 
            // Label36
            // 
            this.Label36.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Label36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label36.Location = new System.Drawing.Point(8, 58);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(61, 13);
            this.Label36.TabIndex = 28;
            this.Label36.Text = "Departure :";
            // 
            // grbActualGuestArrivalDeparture
            // 
            this.grbActualGuestArrivalDeparture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbActualGuestArrivalDeparture.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grbActualGuestArrivalDeparture.Controls.Add(this.dtpFromDate);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.dtpDepartureDate);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.labeldeparturedate);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.Label28);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.txtActualETA);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.dtpArrivalTime);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.txtActualETD);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.dtpActualETD);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.dtpDepartureTime);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.label65);
            this.grbActualGuestArrivalDeparture.Controls.Add(this.label66);
            this.grbActualGuestArrivalDeparture.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbActualGuestArrivalDeparture.Location = new System.Drawing.Point(527, 189);
            this.grbActualGuestArrivalDeparture.Name = "grbActualGuestArrivalDeparture";
            this.grbActualGuestArrivalDeparture.Size = new System.Drawing.Size(281, 88);
            this.grbActualGuestArrivalDeparture.TabIndex = 126;
            this.grbActualGuestArrivalDeparture.TabStop = false;
            this.grbActualGuestArrivalDeparture.Text = "Actual";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Location = new System.Drawing.Point(76, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ReadOnly = true;
            this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtpFromDate.TabIndex = 31;
            this.tipSked.SetToolTip(this.dtpFromDate, "Actual Guest Arrival");
            // 
            // dtpDepartureDate
            // 
            this.dtpDepartureDate.Enabled = false;
            this.dtpDepartureDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDepartureDate.Location = new System.Drawing.Point(76, 54);
            this.dtpDepartureDate.Name = "dtpDepartureDate";
            this.dtpDepartureDate.ReadOnly = true;
            this.dtpDepartureDate.Size = new System.Drawing.Size(90, 20);
            this.dtpDepartureDate.TabIndex = 32;
            this.tipSked.SetToolTip(this.dtpDepartureDate, "Actual Guest Departure");
            this.dtpDepartureDate.TextChanged += new System.EventHandler(this.dtpDepartureDate_ValueChanged);
            // 
            // labeldeparturedate
            // 
            this.labeldeparturedate.Location = new System.Drawing.Point(15, 57);
            this.labeldeparturedate.Name = "labeldeparturedate";
            this.labeldeparturedate.Size = new System.Drawing.Size(61, 15);
            this.labeldeparturedate.TabIndex = 124;
            this.labeldeparturedate.Text = "Departure :";
            // 
            // Label28
            // 
            this.Label28.Location = new System.Drawing.Point(15, 28);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(61, 15);
            this.Label28.TabIndex = 56;
            this.Label28.Text = "Arrival :";
            // 
            // txtActualETA
            // 
            this.txtActualETA.BackColor = System.Drawing.SystemColors.Control;
            this.txtActualETA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualETA.Location = new System.Drawing.Point(205, 24);
            this.txtActualETA.Name = "txtActualETA";
            this.txtActualETA.ReadOnly = true;
            this.txtActualETA.Size = new System.Drawing.Size(70, 20);
            this.txtActualETA.TabIndex = 30;
            // 
            // dtpArrivalTime
            // 
            this.dtpArrivalTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpArrivalTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpArrivalTime.CustomFormat = "hh:mm tt";
            this.dtpArrivalTime.Enabled = false;
            this.dtpArrivalTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrivalTime.Location = new System.Drawing.Point(205, 25);
            this.dtpArrivalTime.Name = "dtpArrivalTime";
            this.dtpArrivalTime.Size = new System.Drawing.Size(70, 20);
            this.dtpArrivalTime.TabIndex = 125;
            this.tipSked.SetToolTip(this.dtpArrivalTime, "Actual Guest Arrival");
            this.dtpArrivalTime.Value = new System.DateTime(2006, 5, 2, 18, 50, 39, 421);
            this.dtpArrivalTime.ValueChanged += new System.EventHandler(this.dtpArrivalTime_ValueChanged);
            // 
            // txtActualETD
            // 
            this.txtActualETD.BackColor = System.Drawing.SystemColors.Control;
            this.txtActualETD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualETD.Location = new System.Drawing.Point(205, 53);
            this.txtActualETD.Name = "txtActualETD";
            this.txtActualETD.ReadOnly = true;
            this.txtActualETD.Size = new System.Drawing.Size(70, 20);
            this.txtActualETD.TabIndex = 30;
            // 
            // dtpActualETD
            // 
            this.dtpActualETD.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpActualETD.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpActualETD.CustomFormat = "hh:mm tt";
            this.dtpActualETD.Enabled = false;
            this.dtpActualETD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualETD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActualETD.Location = new System.Drawing.Point(205, 53);
            this.dtpActualETD.Name = "dtpActualETD";
            this.dtpActualETD.Size = new System.Drawing.Size(70, 20);
            this.dtpActualETD.TabIndex = 125;
            this.dtpActualETD.Value = new System.DateTime(2006, 5, 2, 18, 50, 39, 421);
            this.dtpActualETD.ValueChanged += new System.EventHandler(this.dtpActualETD_ValueChanged);
            // 
            // dtpDepartureTime
            // 
            this.dtpDepartureTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpDepartureTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpDepartureTime.CustomFormat = "hh:mm tt";
            this.dtpDepartureTime.Enabled = false;
            this.dtpDepartureTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDepartureTime.Location = new System.Drawing.Point(205, 54);
            this.dtpDepartureTime.Name = "dtpDepartureTime";
            this.dtpDepartureTime.Size = new System.Drawing.Size(70, 20);
            this.dtpDepartureTime.TabIndex = 126;
            this.tipSked.SetToolTip(this.dtpDepartureTime, "Actual Guest Departure");
            this.dtpDepartureTime.Value = new System.DateTime(2006, 5, 2, 18, 50, 39, 421);
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(168, 57);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(45, 15);
            this.label65.TabIndex = 128;
            this.label65.Text = "Time :";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(168, 28);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(45, 15);
            this.label66.TabIndex = 127;
            this.label66.Text = "Time :";
            // 
            // grpCalendar
            // 
            this.grpCalendar.Controls.Add(this.btnCalendarWizard);
            this.grpCalendar.Controls.Add(this.RadioButton1);
            this.grpCalendar.Location = new System.Drawing.Point(15, 12);
            this.grpCalendar.Name = "grpCalendar";
            this.grpCalendar.Size = new System.Drawing.Size(115, 55);
            this.grpCalendar.TabIndex = 79;
            this.grpCalendar.TabStop = false;
            // 
            // btnCalendarWizard
            // 
            this.btnCalendarWizard.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCalendarWizard.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalendarWizard.ForeColor = System.Drawing.Color.Navy;
            this.btnCalendarWizard.Location = new System.Drawing.Point(14, 23);
            this.btnCalendarWizard.Name = "btnCalendarWizard";
            this.btnCalendarWizard.Size = new System.Drawing.Size(90, 24);
            this.btnCalendarWizard.TabIndex = 21;
            this.btnCalendarWizard.Text = "&Launch";
            this.btnCalendarWizard.UseVisualStyleBackColor = false;
            this.btnCalendarWizard.Click += new System.EventHandler(this.btnCalendarWizard_Click);
            // 
            // RadioButton1
            // 
            this.RadioButton1.Location = new System.Drawing.Point(484, 384);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(65, 24);
            this.RadioButton1.TabIndex = 9;
            this.RadioButton1.Text = "Manual";
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label56.BackColor = System.Drawing.SystemColors.Control;
            this.label56.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(16, 293);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(124, 16);
            this.label56.TabIndex = 93;
            this.label56.Text = "Folio Account Type";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreatedBy.BackColor = System.Drawing.Color.White;
            this.txtCreatedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreatedBy.Location = new System.Drawing.Point(732, 315);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(75, 20);
            this.txtCreatedBy.TabIndex = 9;
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(729, 294);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(79, 16);
            this.label47.TabIndex = 92;
            this.label47.Text = "Reserved by";
            // 
            // cboSales_Executive
            // 
            this.cboSales_Executive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSales_Executive.FormattingEnabled = true;
            this.cboSales_Executive.Location = new System.Drawing.Point(526, 314);
            this.cboSales_Executive.Name = "cboSales_Executive";
            this.cboSales_Executive.Size = new System.Drawing.Size(124, 22);
            this.cboSales_Executive.TabIndex = 8;
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(526, 294);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(124, 16);
            this.label48.TabIndex = 89;
            this.label48.Text = "Sales Executive";
            // 
            // grdFolioSchedule
            // 
            this.grdFolioSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFolioSchedule.ColumnInfo = resources.GetString("grdFolioSchedule.ColumnInfo");
            this.grdFolioSchedule.ContextMenuStrip = this.cmuSchedule;
            this.grdFolioSchedule.ExtendLastCol = true;
            this.grdFolioSchedule.Location = new System.Drawing.Point(14, 72);
            this.grdFolioSchedule.Name = "grdFolioSchedule";
            this.grdFolioSchedule.Rows.Count = 2;
            this.grdFolioSchedule.Rows.DefaultSize = 17;
            this.grdFolioSchedule.Size = new System.Drawing.Size(794, 110);
            this.grdFolioSchedule.StyleInfo = resources.GetString("grdFolioSchedule.StyleInfo");
            this.grdFolioSchedule.TabIndex = 3;
            this.grdFolioSchedule.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFolioSchedule_AfterEdit);
            this.grdFolioSchedule.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grdFolioSchedule_AfterRowColChange);
            this.grdFolioSchedule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdFolioSchedule_MouseUp);
            this.grdFolioSchedule.Click += new System.EventHandler(this.grdFolioSchedule_Click);
            this.grdFolioSchedule.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFolioSchedule_BeforeEdit);
            this.grdFolioSchedule.RowColChange += new System.EventHandler(this.grdFolioSchedule_RowColChange);
            // 
            // cmuSchedule
            // 
            this.cmuSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScheduleToolStripMenuItem,
            this.deleteScheduleToolStripMenuItem,
            this.toolStripSeparator1,
            this.deAllocateRoom,
            this.tsmTransferRoom,
            this.toolStripMenuItem2,
            this.refreshToolStripMenuItem});
            this.cmuSchedule.Name = "cmuSchedule";
            this.cmuSchedule.Size = new System.Drawing.Size(166, 126);
            this.cmuSchedule.Opening += new System.ComponentModel.CancelEventHandler(this.cmuSchedule_Opening);
            // 
            // addScheduleToolStripMenuItem
            // 
            this.addScheduleToolStripMenuItem.Name = "addScheduleToolStripMenuItem";
            this.addScheduleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addScheduleToolStripMenuItem.Text = "Add Schedule";
            this.addScheduleToolStripMenuItem.Click += new System.EventHandler(this.addScheduleToolStripMenuItem_Click);
            // 
            // deleteScheduleToolStripMenuItem
            // 
            this.deleteScheduleToolStripMenuItem.Name = "deleteScheduleToolStripMenuItem";
            this.deleteScheduleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deleteScheduleToolStripMenuItem.Text = "Delete Schedule";
            this.deleteScheduleToolStripMenuItem.Click += new System.EventHandler(this.deleteScheduleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // deAllocateRoom
            // 
            this.deAllocateRoom.Name = "deAllocateRoom";
            this.deAllocateRoom.Size = new System.Drawing.Size(165, 22);
            this.deAllocateRoom.Text = "Deallocate Room";
            this.deAllocateRoom.Click += new System.EventHandler(this.deAllocateRoom_Click);
            // 
            // tsmTransferRoom
            // 
            this.tsmTransferRoom.Enabled = false;
            this.tsmTransferRoom.Name = "tsmTransferRoom";
            this.tsmTransferRoom.Size = new System.Drawing.Size(165, 22);
            this.tsmTransferRoom.Text = "Transfer Room";
            this.tsmTransferRoom.Click += new System.EventHandler(this.tsmTransferRoom_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // tabBilling
            // 
            this.tabBilling.Controls.Add(this.label39);
            this.tabBilling.Controls.Add(this.label33);
            this.tabBilling.Controls.Add(this.txtBIMemo);
            this.tabBilling.Controls.Add(this.txtBICode);
            this.tabBilling.Controls.Add(this.grdBillingInstruction);
            this.tabBilling.Controls.Add(this.grdBITransactionCodes);
            this.tabBilling.Controls.Add(this.btnRemoveBillingInstruction);
            this.tabBilling.Controls.Add(this.Label16);
            this.tabBilling.Controls.Add(this.Label11);
            this.tabBilling.Controls.Add(this.btnAddBillingInstruction);
            this.tabBilling.Controls.Add(this.rdoBIAmount);
            this.tabBilling.Controls.Add(this.rdoBIPercent);
            this.tabBilling.Controls.Add(this.label10);
            this.tabBilling.Controls.Add(this.label1);
            this.tabBilling.Location = new System.Drawing.Point(4, 23);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Size = new System.Drawing.Size(823, 346);
            this.tabBilling.TabIndex = 7;
            this.tabBilling.Text = "Billing Instruction ";
            this.tabBilling.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label39.Image = ((System.Drawing.Image)(resources.GetObject("label39.Image")));
            this.label39.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label39.Location = new System.Drawing.Point(516, 272);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 30);
            this.label39.TabIndex = 136;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label33.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label33.Location = new System.Drawing.Point(549, 272);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(255, 60);
            this.label33.TabIndex = 135;
            this.label33.Text = "Billing Instructions are special instructions telling the system where to post a " +
                "certain transaction in a guest sub-folio. A for Personal charge, B for Company, " +
                "etc.";
            // 
            // txtBIMemo
            // 
            this.txtBIMemo.BackColor = System.Drawing.SystemColors.Control;
            this.txtBIMemo.Location = new System.Drawing.Point(468, 91);
            this.txtBIMemo.Name = "txtBIMemo";
            this.txtBIMemo.ReadOnly = true;
            this.txtBIMemo.Size = new System.Drawing.Size(215, 20);
            this.txtBIMemo.TabIndex = 132;
            // 
            // txtBICode
            // 
            this.txtBICode.BackColor = System.Drawing.SystemColors.Control;
            this.txtBICode.Location = new System.Drawing.Point(468, 65);
            this.txtBICode.Name = "txtBICode";
            this.txtBICode.ReadOnly = true;
            this.txtBICode.Size = new System.Drawing.Size(82, 20);
            this.txtBICode.TabIndex = 131;
            // 
            // grdBillingInstruction
            // 
            this.grdBillingInstruction.ColumnInfo = resources.GetString("grdBillingInstruction.ColumnInfo");
            this.grdBillingInstruction.Location = new System.Drawing.Point(421, 155);
            this.grdBillingInstruction.Name = "grdBillingInstruction";
            this.grdBillingInstruction.Rows.Count = 5;
            this.grdBillingInstruction.Rows.DefaultSize = 17;
            this.grdBillingInstruction.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdBillingInstruction.Size = new System.Drawing.Size(362, 91);
            this.grdBillingInstruction.StyleInfo = resources.GetString("grdBillingInstruction.StyleInfo");
            this.grdBillingInstruction.TabIndex = 129;
            this.grdBillingInstruction.RowColChange += new System.EventHandler(this.grdBillingInstruction_RowColChange);
            // 
            // grdBITransactionCodes
            // 
            this.grdBITransactionCodes.AllowEditing = false;
            this.grdBITransactionCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBITransactionCodes.ColumnInfo = resources.GetString("grdBITransactionCodes.ColumnInfo");
            this.grdBITransactionCodes.Location = new System.Drawing.Point(6, 31);
            this.grdBITransactionCodes.Name = "grdBITransactionCodes";
            this.grdBITransactionCodes.Rows.DefaultSize = 17;
            this.grdBITransactionCodes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdBITransactionCodes.Size = new System.Drawing.Size(333, 301);
            this.grdBITransactionCodes.StyleInfo = resources.GetString("grdBITransactionCodes.StyleInfo");
            this.grdBITransactionCodes.TabIndex = 128;
            this.grdBITransactionCodes.RowColChange += new System.EventHandler(this.grdBITransactionCodes_RowColChange);
            // 
            // btnRemoveBillingInstruction
            // 
            this.btnRemoveBillingInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveBillingInstruction.Location = new System.Drawing.Point(741, 35);
            this.btnRemoveBillingInstruction.Name = "btnRemoveBillingInstruction";
            this.btnRemoveBillingInstruction.Size = new System.Drawing.Size(66, 31);
            this.btnRemoveBillingInstruction.TabIndex = 40;
            this.btnRemoveBillingInstruction.Text = "Remove";
            this.btnRemoveBillingInstruction.Click += new System.EventHandler(this.btnRemoveBillingInstruction_Click);
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(7, 11);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(126, 15);
            this.Label16.TabIndex = 83;
            this.Label16.Text = "Transaction Codes :";
            // 
            // Label11
            // 
            this.Label11.BackColor = System.Drawing.SystemColors.Control;
            this.Label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(598, 130);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(45, 16);
            this.Label11.TabIndex = 14;
            this.Label11.Text = "Basis :";
            // 
            // btnAddBillingInstruction
            // 
            this.btnAddBillingInstruction.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddBillingInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBillingInstruction.Location = new System.Drawing.Point(669, 35);
            this.btnAddBillingInstruction.Name = "btnAddBillingInstruction";
            this.btnAddBillingInstruction.Size = new System.Drawing.Size(66, 31);
            this.btnAddBillingInstruction.TabIndex = 39;
            this.btnAddBillingInstruction.Text = "Add";
            this.btnAddBillingInstruction.Click += new System.EventHandler(this.btnAddBillingInstruction_Click);
            // 
            // rdoBIAmount
            // 
            this.rdoBIAmount.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBIAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBIAmount.Location = new System.Drawing.Point(718, 128);
            this.rdoBIAmount.Name = "rdoBIAmount";
            this.rdoBIAmount.Size = new System.Drawing.Size(65, 20);
            this.rdoBIAmount.TabIndex = 43;
            this.rdoBIAmount.Text = "Amount";
            this.rdoBIAmount.UseVisualStyleBackColor = false;
            this.rdoBIAmount.CheckedChanged += new System.EventHandler(this.rdoBIAmount_CheckedChanged);
            // 
            // rdoBIPercent
            // 
            this.rdoBIPercent.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBIPercent.Checked = true;
            this.rdoBIPercent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBIPercent.Location = new System.Drawing.Point(646, 128);
            this.rdoBIPercent.Name = "rdoBIPercent";
            this.rdoBIPercent.Size = new System.Drawing.Size(64, 20);
            this.rdoBIPercent.TabIndex = 42;
            this.rdoBIPercent.TabStop = true;
            this.rdoBIPercent.Text = "Percent";
            this.rdoBIPercent.UseVisualStyleBackColor = false;
            this.rdoBIPercent.CheckedChanged += new System.EventHandler(this.rdoBIPercent_CheckedChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label10.Location = new System.Drawing.Point(422, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 134;
            this.label10.Text = "Memo :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label1.Location = new System.Drawing.Point(422, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 133;
            this.label1.Text = "Code :";
            // 
            // tabCharges
            // 
            this.tabCharges.Controls.Add(this.label43);
            this.tabCharges.Controls.Add(this.label24);
            this.tabCharges.Controls.Add(this.label12);
            this.tabCharges.Controls.Add(this.btnRemoveRecurringCharge);
            this.tabCharges.Controls.Add(this.btnAddRecurringCharge);
            this.tabCharges.Controls.Add(this.grdRecurringCharges);
            this.tabCharges.Location = new System.Drawing.Point(4, 23);
            this.tabCharges.Name = "tabCharges";
            this.tabCharges.Size = new System.Drawing.Size(823, 346);
            this.tabCharges.TabIndex = 8;
            this.tabCharges.Text = "Recurring Charges ";
            this.tabCharges.UseVisualStyleBackColor = true;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label43.Image = ((System.Drawing.Image)(resources.GetObject("label43.Image")));
            this.label43.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label43.Location = new System.Drawing.Point(516, 272);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 30);
            this.label43.TabIndex = 137;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label24.Location = new System.Drawing.Point(549, 272);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(259, 64);
            this.label24.TabIndex = 133;
            this.label24.Text = "Recurring charges will be posted once every night audit process. (e.g Extra Perso" +
                "n ). Instead of posting it manually, you can insert a recurring charge, and the " +
                "system will post it for you.";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 15);
            this.label12.TabIndex = 132;
            this.label12.Text = "Active Recurring Charges :";
            // 
            // btnRemoveRecurringCharge
            // 
            this.btnRemoveRecurringCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveRecurringCharge.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoveRecurringCharge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRecurringCharge.Location = new System.Drawing.Point(741, 17);
            this.btnRemoveRecurringCharge.Name = "btnRemoveRecurringCharge";
            this.btnRemoveRecurringCharge.Size = new System.Drawing.Size(66, 31);
            this.btnRemoveRecurringCharge.TabIndex = 131;
            this.btnRemoveRecurringCharge.Text = "&Remove";
            this.btnRemoveRecurringCharge.UseVisualStyleBackColor = false;
            this.btnRemoveRecurringCharge.Click += new System.EventHandler(this.btnRemoveRecurringCharge_Click);
            // 
            // btnAddRecurringCharge
            // 
            this.btnAddRecurringCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddRecurringCharge.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddRecurringCharge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRecurringCharge.Location = new System.Drawing.Point(669, 17);
            this.btnAddRecurringCharge.Name = "btnAddRecurringCharge";
            this.btnAddRecurringCharge.Size = new System.Drawing.Size(66, 31);
            this.btnAddRecurringCharge.TabIndex = 130;
            this.btnAddRecurringCharge.Text = "&Add";
            this.btnAddRecurringCharge.UseVisualStyleBackColor = false;
            this.btnAddRecurringCharge.Click += new System.EventHandler(this.btnAddRecurringCharge_Click);
            // 
            // grdRecurringCharges
            // 
            this.grdRecurringCharges.AllowEditing = false;
            this.grdRecurringCharges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRecurringCharges.ColumnInfo = resources.GetString("grdRecurringCharges.ColumnInfo");
            this.grdRecurringCharges.ExtendLastCol = true;
            this.grdRecurringCharges.Location = new System.Drawing.Point(16, 51);
            this.grdRecurringCharges.Name = "grdRecurringCharges";
            this.grdRecurringCharges.Rows.Count = 1;
            this.grdRecurringCharges.Rows.DefaultSize = 17;
            this.grdRecurringCharges.Size = new System.Drawing.Size(479, 285);
            this.grdRecurringCharges.StyleInfo = resources.GetString("grdRecurringCharges.StyleInfo");
            this.grdRecurringCharges.TabIndex = 129;
            this.grdRecurringCharges.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdRecurringCharges_StartEdit);
            this.grdRecurringCharges.Click += new System.EventHandler(this.grdRecurringCharges_Click);
            this.grdRecurringCharges.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdRecurringCharges_BeforeEdit);
            // 
            // tabPackage
            // 
            this.tabPackage.Controls.Add(this.dtpPackageDateTo);
            this.tabPackage.Controls.Add(this.label72);
            this.tabPackage.Controls.Add(this.dtpPackageDateFrom);
            this.tabPackage.Controls.Add(this.txtFolioPackageDaysApplied);
            this.tabPackage.Controls.Add(this.label34);
            this.tabPackage.Controls.Add(this.label63);
            this.tabPackage.Controls.Add(this.label64);
            this.tabPackage.Controls.Add(this.grdFolioPackage);
            this.tabPackage.Controls.Add(this.label4);
            this.tabPackage.Controls.Add(this.grdHotelPromos);
            this.tabPackage.Controls.Add(this.btnAddHotelPromo);
            this.tabPackage.Controls.Add(this.btnRemoveHotelPromo);
            this.tabPackage.Controls.Add(this.Label18);
            this.tabPackage.Location = new System.Drawing.Point(4, 23);
            this.tabPackage.Name = "tabPackage";
            this.tabPackage.Size = new System.Drawing.Size(823, 346);
            this.tabPackage.TabIndex = 5;
            this.tabPackage.Text = "Hotel Promos";
            this.tabPackage.UseVisualStyleBackColor = true;
            // 
            // dtpPackageDateTo
            // 
            this.dtpPackageDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpPackageDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPackageDateTo.Location = new System.Drawing.Point(693, 38);
            this.dtpPackageDateTo.Name = "dtpPackageDateTo";
            this.dtpPackageDateTo.Size = new System.Drawing.Size(103, 20);
            this.dtpPackageDateTo.TabIndex = 144;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.SystemColors.Control;
            this.label72.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label72.Location = new System.Drawing.Point(642, 41);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(53, 15);
            this.label72.TabIndex = 143;
            this.label72.Text = "Date To :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPackageDateFrom
            // 
            this.dtpPackageDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpPackageDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPackageDateFrom.Location = new System.Drawing.Point(521, 38);
            this.dtpPackageDateFrom.Name = "dtpPackageDateFrom";
            this.dtpPackageDateFrom.Size = new System.Drawing.Size(102, 20);
            this.dtpPackageDateFrom.TabIndex = 142;
            // 
            // txtFolioPackageDaysApplied
            // 
            this.txtFolioPackageDaysApplied.AutoCompleteCustomSource.AddRange(new string[] {
            "CONFIRMED",
            "ONGOING",
            "CLOSED",
            "NO SHOW",
            "CANCELLED",
            "WAIT LIST"});
            this.txtFolioPackageDaysApplied.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFolioPackageDaysApplied.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFolioPackageDaysApplied.BackColor = System.Drawing.Color.White;
            this.txtFolioPackageDaysApplied.ForeColor = System.Drawing.Color.Red;
            this.txtFolioPackageDaysApplied.Location = new System.Drawing.Point(532, 38);
            this.txtFolioPackageDaysApplied.MaxLength = 20;
            this.txtFolioPackageDaysApplied.Name = "txtFolioPackageDaysApplied";
            this.txtFolioPackageDaysApplied.ReadOnly = true;
            this.txtFolioPackageDaysApplied.Size = new System.Drawing.Size(91, 20);
            this.txtFolioPackageDaysApplied.TabIndex = 140;
            this.txtFolioPackageDaysApplied.Visible = false;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label34.Location = new System.Drawing.Point(458, 41);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(68, 15);
            this.label34.TabIndex = 141;
            this.label34.Text = "Date From :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label63.Image = ((System.Drawing.Image)(resources.GetObject("label63.Image")));
            this.label63.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label63.Location = new System.Drawing.Point(516, 272);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(29, 30);
            this.label63.TabIndex = 139;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label64.Location = new System.Drawing.Point(549, 272);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(259, 64);
            this.label64.TabIndex = 138;
            this.label64.Text = "Hotel Promos are special discounts.";
            // 
            // grdFolioPackage
            // 
            this.grdFolioPackage.ColumnInfo = resources.GetString("grdFolioPackage.ColumnInfo");
            this.grdFolioPackage.Location = new System.Drawing.Point(461, 64);
            this.grdFolioPackage.Name = "grdFolioPackage";
            this.grdFolioPackage.Rows.Count = 1;
            this.grdFolioPackage.Rows.DefaultSize = 17;
            this.grdFolioPackage.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdFolioPackage.Size = new System.Drawing.Size(335, 197);
            this.grdFolioPackage.StyleInfo = resources.GetString("grdFolioPackage.StyleInfo");
            this.grdFolioPackage.TabIndex = 132;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 18);
            this.label4.TabIndex = 131;
            this.label4.Text = "Applied Promo Discounts :";
            // 
            // grdHotelPromos
            // 
            this.grdHotelPromos.AllowEditing = false;
            this.grdHotelPromos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdHotelPromos.ColumnInfo = resources.GetString("grdHotelPromos.ColumnInfo");
            this.grdHotelPromos.ExtendLastCol = true;
            this.grdHotelPromos.Location = new System.Drawing.Point(10, 34);
            this.grdHotelPromos.Name = "grdHotelPromos";
            this.grdHotelPromos.Rows.DefaultSize = 17;
            this.grdHotelPromos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdHotelPromos.Size = new System.Drawing.Size(322, 291);
            this.grdHotelPromos.StyleInfo = resources.GetString("grdHotelPromos.StyleInfo");
            this.grdHotelPromos.TabIndex = 130;
            // 
            // btnAddHotelPromo
            // 
            this.btnAddHotelPromo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddHotelPromo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddHotelPromo.Location = new System.Drawing.Point(383, 94);
            this.btnAddHotelPromo.Name = "btnAddHotelPromo";
            this.btnAddHotelPromo.Size = new System.Drawing.Size(29, 25);
            this.btnAddHotelPromo.TabIndex = 47;
            this.btnAddHotelPromo.Text = ">";
            this.tipSked.SetToolTip(this.btnAddHotelPromo, "Apply hotel promo discounts");
            this.btnAddHotelPromo.Click += new System.EventHandler(this.btnAddHotelPromo_Click);
            // 
            // btnRemoveHotelPromo
            // 
            this.btnRemoveHotelPromo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveHotelPromo.Location = new System.Drawing.Point(383, 131);
            this.btnRemoveHotelPromo.Name = "btnRemoveHotelPromo";
            this.btnRemoveHotelPromo.Size = new System.Drawing.Size(29, 25);
            this.btnRemoveHotelPromo.TabIndex = 48;
            this.btnRemoveHotelPromo.Text = "<";
            this.tipSked.SetToolTip(this.btnRemoveHotelPromo, "Remove discounts");
            this.btnRemoveHotelPromo.Click += new System.EventHandler(this.btnRemoveHotelPromo_Click);
            // 
            // Label18
            // 
            this.Label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label18.Location = new System.Drawing.Point(10, 11);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(140, 18);
            this.Label18.TabIndex = 82;
            this.Label18.Text = "Active Hotel Promos :";
            // 
            // tabPrivilege
            // 
            this.tabPrivilege.Controls.Add(this.label38);
            this.tabPrivilege.Controls.Add(this.label46);
            this.tabPrivilege.Controls.Add(this.label6);
            this.tabPrivilege.Controls.Add(this.grdFolioPrivileges);
            this.tabPrivilege.Controls.Add(this.btnGuestPrivileges_Remove);
            this.tabPrivilege.Controls.Add(this.btnGuestPrivilege_Add);
            this.tabPrivilege.Controls.Add(this.chkApply);
            this.tabPrivilege.Controls.Add(this.gbxApplyPrivileges);
            this.tabPrivilege.Location = new System.Drawing.Point(4, 23);
            this.tabPrivilege.Name = "tabPrivilege";
            this.tabPrivilege.Size = new System.Drawing.Size(823, 346);
            this.tabPrivilege.TabIndex = 6;
            this.tabPrivilege.Text = "Guest Privilege ";
            this.tabPrivilege.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label38.Image = ((System.Drawing.Image)(resources.GetObject("label38.Image")));
            this.label38.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label38.Location = new System.Drawing.Point(516, 272);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(29, 30);
            this.label38.TabIndex = 139;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label46.Location = new System.Drawing.Point(549, 272);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(259, 64);
            this.label46.TabIndex = 138;
            this.label46.Text = "Folio Privileges are discounts (Percentage or Amount) given to Guest/Company. Dis" +
                "counts will be applied upon posting transactions.";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(389, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 16);
            this.label6.TabIndex = 132;
            this.label6.Text = "Folio Privileges :";
            // 
            // grdFolioPrivileges
            // 
            this.grdFolioPrivileges.ColumnInfo = resources.GetString("grdFolioPrivileges.ColumnInfo");
            this.grdFolioPrivileges.ExtendLastCol = true;
            this.grdFolioPrivileges.Location = new System.Drawing.Point(392, 57);
            this.grdFolioPrivileges.Name = "grdFolioPrivileges";
            this.grdFolioPrivileges.Rows.Count = 1;
            this.grdFolioPrivileges.Rows.DefaultSize = 17;
            this.grdFolioPrivileges.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdFolioPrivileges.Size = new System.Drawing.Size(415, 196);
            this.grdFolioPrivileges.StyleInfo = resources.GetString("grdFolioPrivileges.StyleInfo");
            this.grdFolioPrivileges.TabIndex = 131;
            this.grdFolioPrivileges.KeyPressEdit += new C1.Win.C1FlexGrid.KeyPressEditEventHandler(this.grdFolioPrivileges_KeyPressEdit);
            this.grdFolioPrivileges.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFolioPrivileges_AfterEdit);
            this.grdFolioPrivileges.RowColChange += new System.EventHandler(this.grdFolioPrivileges_RowColChange);
            // 
            // btnGuestPrivileges_Remove
            // 
            this.btnGuestPrivileges_Remove.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuestPrivileges_Remove.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnGuestPrivileges_Remove.Location = new System.Drawing.Point(741, 17);
            this.btnGuestPrivileges_Remove.Name = "btnGuestPrivileges_Remove";
            this.btnGuestPrivileges_Remove.Size = new System.Drawing.Size(66, 31);
            this.btnGuestPrivileges_Remove.TabIndex = 88;
            this.btnGuestPrivileges_Remove.Text = "Remove";
            this.btnGuestPrivileges_Remove.Click += new System.EventHandler(this.btnGuestPrivileges_Remove_Click);
            // 
            // btnGuestPrivilege_Add
            // 
            this.btnGuestPrivilege_Add.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuestPrivilege_Add.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnGuestPrivilege_Add.Location = new System.Drawing.Point(669, 17);
            this.btnGuestPrivilege_Add.Name = "btnGuestPrivilege_Add";
            this.btnGuestPrivilege_Add.Size = new System.Drawing.Size(66, 31);
            this.btnGuestPrivilege_Add.TabIndex = 87;
            this.btnGuestPrivilege_Add.Text = "&Add";
            this.btnGuestPrivilege_Add.Click += new System.EventHandler(this.btnGuestPrivilege_Add_Click);
            // 
            // chkApply
            // 
            this.chkApply.Checked = true;
            this.chkApply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApply.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApply.Location = new System.Drawing.Point(29, 21);
            this.chkApply.Name = "chkApply";
            this.chkApply.Size = new System.Drawing.Size(113, 22);
            this.chkApply.TabIndex = 52;
            this.chkApply.Text = " Apply Privilege";
            this.chkApply.CheckedChanged += new System.EventHandler(this.chkApply_CheckedChanged);
            // 
            // gbxApplyPrivileges
            // 
            this.gbxApplyPrivileges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxApplyPrivileges.Controls.Add(this.lvwCompanyPrivileges);
            this.gbxApplyPrivileges.Controls.Add(this.lvwGuestPrivileges);
            this.gbxApplyPrivileges.Controls.Add(this.rdoApplyCompanyPrivileges);
            this.gbxApplyPrivileges.Controls.Add(this.rdoApplyGuestPrivilege);
            this.gbxApplyPrivileges.Location = new System.Drawing.Point(16, 26);
            this.gbxApplyPrivileges.Name = "gbxApplyPrivileges";
            this.gbxApplyPrivileges.Size = new System.Drawing.Size(342, 308);
            this.gbxApplyPrivileges.TabIndex = 6;
            this.gbxApplyPrivileges.TabStop = false;
            // 
            // lvwCompanyPrivileges
            // 
            this.lvwCompanyPrivileges.BackColor = System.Drawing.SystemColors.Control;
            this.lvwCompanyPrivileges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwCompanyPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7});
            this.lvwCompanyPrivileges.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCompanyPrivileges.FullRowSelect = true;
            this.lvwCompanyPrivileges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwCompanyPrivileges.Location = new System.Drawing.Point(48, 194);
            this.lvwCompanyPrivileges.Name = "lvwCompanyPrivileges";
            this.lvwCompanyPrivileges.Size = new System.Drawing.Size(268, 97);
            this.lvwCompanyPrivileges.TabIndex = 56;
            this.lvwCompanyPrivileges.UseCompatibleStateImageBehavior = false;
            this.lvwCompanyPrivileges.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 253;
            // 
            // lvwGuestPrivileges
            // 
            this.lvwGuestPrivileges.BackColor = System.Drawing.SystemColors.Control;
            this.lvwGuestPrivileges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwGuestPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lvwGuestPrivileges.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGuestPrivileges.FullRowSelect = true;
            this.lvwGuestPrivileges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwGuestPrivileges.Location = new System.Drawing.Point(48, 63);
            this.lvwGuestPrivileges.Name = "lvwGuestPrivileges";
            this.lvwGuestPrivileges.Size = new System.Drawing.Size(268, 97);
            this.lvwGuestPrivileges.TabIndex = 55;
            this.lvwGuestPrivileges.UseCompatibleStateImageBehavior = false;
            this.lvwGuestPrivileges.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 253;
            // 
            // rdoApplyCompanyPrivileges
            // 
            this.rdoApplyCompanyPrivileges.AutoSize = true;
            this.rdoApplyCompanyPrivileges.Location = new System.Drawing.Point(29, 170);
            this.rdoApplyCompanyPrivileges.Name = "rdoApplyCompanyPrivileges";
            this.rdoApplyCompanyPrivileges.Size = new System.Drawing.Size(127, 18);
            this.rdoApplyCompanyPrivileges.TabIndex = 54;
            this.rdoApplyCompanyPrivileges.TabStop = true;
            this.rdoApplyCompanyPrivileges.Text = "Company Privilege(s)";
            this.rdoApplyCompanyPrivileges.UseVisualStyleBackColor = true;
            this.rdoApplyCompanyPrivileges.CheckedChanged += new System.EventHandler(this.rdoApplyCompanyPrivileges_CheckedChanged);
            // 
            // rdoApplyGuestPrivilege
            // 
            this.rdoApplyGuestPrivilege.AutoSize = true;
            this.rdoApplyGuestPrivilege.Checked = true;
            this.rdoApplyGuestPrivilege.Location = new System.Drawing.Point(29, 39);
            this.rdoApplyGuestPrivilege.Name = "rdoApplyGuestPrivilege";
            this.rdoApplyGuestPrivilege.Size = new System.Drawing.Size(111, 18);
            this.rdoApplyGuestPrivilege.TabIndex = 53;
            this.rdoApplyGuestPrivilege.TabStop = true;
            this.rdoApplyGuestPrivilege.Text = "Guest Privilege(s)";
            this.rdoApplyGuestPrivilege.UseVisualStyleBackColor = true;
            this.rdoApplyGuestPrivilege.CheckedChanged += new System.EventHandler(this.rdoApplyGuestPrivilege_CheckedChanged);
            // 
            // tabInclusions
            // 
            this.tabInclusions.Controls.Add(this.grdInclusions);
            this.tabInclusions.Controls.Add(this.label75);
            this.tabInclusions.Controls.Add(this.label77);
            this.tabInclusions.Controls.Add(this.label74);
            this.tabInclusions.Controls.Add(this.txtRequirementNote);
            this.tabInclusions.Controls.Add(this.btnRemoveRequirements);
            this.tabInclusions.Controls.Add(this.btnAddRequirements);
            this.tabInclusions.Controls.Add(this.grdFolioInclusions);
            this.tabInclusions.Location = new System.Drawing.Point(4, 23);
            this.tabInclusions.Name = "tabInclusions";
            this.tabInclusions.Padding = new System.Windows.Forms.Padding(3);
            this.tabInclusions.Size = new System.Drawing.Size(823, 346);
            this.tabInclusions.TabIndex = 11;
            this.tabInclusions.Text = "Inclusions   ";
            this.tabInclusions.UseVisualStyleBackColor = true;
            // 
            // grdInclusions
            // 
            this.grdInclusions.AllowEditing = false;
            this.grdInclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdInclusions.ColumnInfo = "1,0,0,0,0,85,Columns:";
            this.grdInclusions.ExtendLastCol = true;
            this.grdInclusions.Location = new System.Drawing.Point(29, 34);
            this.grdInclusions.Name = "grdInclusions";
            this.grdInclusions.Rows.Count = 0;
            this.grdInclusions.Rows.DefaultSize = 17;
            this.grdInclusions.Rows.Fixed = 0;
            this.grdInclusions.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdInclusions.Size = new System.Drawing.Size(221, 253);
            this.grdInclusions.StyleInfo = resources.GetString("grdInclusions.StyleInfo");
            this.grdInclusions.TabIndex = 189;
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label75.Image = ((System.Drawing.Image)(resources.GetObject("label75.Image")));
            this.label75.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label75.Location = new System.Drawing.Point(578, 176);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(29, 30);
            this.label75.TabIndex = 187;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label77.Location = new System.Drawing.Point(613, 164);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(204, 86);
            this.label77.TabIndex = 186;
            this.label77.Text = "Folio Inclusions are defined per folio. Each folio can have different room inclus" +
                "ions.";
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(348, 13);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(157, 18);
            this.label74.TabIndex = 185;
            this.label74.Text = "Folio Inclusions :";
            // 
            // txtRequirementNote
            // 
            this.txtRequirementNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRequirementNote.Location = new System.Drawing.Point(29, 293);
            this.txtRequirementNote.Multiline = true;
            this.txtRequirementNote.Name = "txtRequirementNote";
            this.txtRequirementNote.Size = new System.Drawing.Size(219, 38);
            this.txtRequirementNote.TabIndex = 184;
            // 
            // btnRemoveRequirements
            // 
            this.btnRemoveRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRequirements.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnRemoveRequirements.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRequirements.Location = new System.Drawing.Point(274, 153);
            this.btnRemoveRequirements.Name = "btnRemoveRequirements";
            this.btnRemoveRequirements.Size = new System.Drawing.Size(40, 34);
            this.btnRemoveRequirements.TabIndex = 183;
            this.btnRemoveRequirements.Text = "<";
            this.btnRemoveRequirements.Click += new System.EventHandler(this.btnRemoveRequirements_Click);
            // 
            // btnAddRequirements
            // 
            this.btnAddRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRequirements.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddRequirements.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRequirements.Location = new System.Drawing.Point(274, 96);
            this.btnAddRequirements.Name = "btnAddRequirements";
            this.btnAddRequirements.Size = new System.Drawing.Size(40, 34);
            this.btnAddRequirements.TabIndex = 182;
            this.btnAddRequirements.Text = ">";
            this.btnAddRequirements.Click += new System.EventHandler(this.btnAddRequirements_Click);
            // 
            // grdFolioInclusions
            // 
            this.grdFolioInclusions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFolioInclusions.ColumnInfo = "1,0,0,0,0,85,Columns:";
            this.grdFolioInclusions.ExtendLastCol = true;
            this.grdFolioInclusions.Location = new System.Drawing.Point(346, 34);
            this.grdFolioInclusions.Name = "grdFolioInclusions";
            this.grdFolioInclusions.Rows.Count = 0;
            this.grdFolioInclusions.Rows.DefaultSize = 17;
            this.grdFolioInclusions.Rows.Fixed = 0;
            this.grdFolioInclusions.Size = new System.Drawing.Size(219, 297);
            this.grdFolioInclusions.StyleInfo = resources.GetString("grdFolioInclusions.StyleInfo");
            this.grdFolioInclusions.TabIndex = 188;
            // 
            // tabGuestInfo
            // 
            this.tabGuestInfo.Controls.Add(this.groupBox10);
            this.tabGuestInfo.Controls.Add(this.GroupBox1);
            this.tabGuestInfo.Location = new System.Drawing.Point(4, 23);
            this.tabGuestInfo.Name = "tabGuestInfo";
            this.tabGuestInfo.Size = new System.Drawing.Size(823, 346);
            this.tabGuestInfo.TabIndex = 4;
            this.tabGuestInfo.Text = "Guest Information ";
            this.tabGuestInfo.UseVisualStyleBackColor = true;
            this.tabGuestInfo.Visible = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.grbCreditCardInfo);
            this.groupBox10.Controls.Add(this.txtCard_No);
            this.groupBox10.Controls.Add(this.label59);
            this.groupBox10.Controls.Add(this.txtAccount_Type);
            this.groupBox10.Controls.Add(this.txtTotal_Sales_Contribution);
            this.groupBox10.Controls.Add(this.label53);
            this.groupBox10.Controls.Add(this.txtNoOfVisits);
            this.groupBox10.Controls.Add(this.label52);
            this.groupBox10.Controls.Add(this.txtCreateTime);
            this.groupBox10.Controls.Add(this.label51);
            this.groupBox10.Controls.Add(this.label50);
            this.groupBox10.Location = new System.Drawing.Point(493, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(327, 337);
            this.groupBox10.TabIndex = 84;
            this.groupBox10.TabStop = false;
            // 
            // grbCreditCardInfo
            // 
            this.grbCreditCardInfo.Controls.Add(this.dtpCreditCardExpiry);
            this.grbCreditCardInfo.Controls.Add(this.label69);
            this.grbCreditCardInfo.Controls.Add(this.txtCreditCardType);
            this.grbCreditCardInfo.Controls.Add(this.txtCreditCardNo);
            this.grbCreditCardInfo.Controls.Add(this.label67);
            this.grbCreditCardInfo.Controls.Add(this.label61);
            this.grbCreditCardInfo.Location = new System.Drawing.Point(13, 189);
            this.grbCreditCardInfo.Name = "grbCreditCardInfo";
            this.grbCreditCardInfo.Size = new System.Drawing.Size(294, 133);
            this.grbCreditCardInfo.TabIndex = 159;
            this.grbCreditCardInfo.TabStop = false;
            this.grbCreditCardInfo.Text = "Credit Card Information";
            // 
            // dtpCreditCardExpiry
            // 
            this.dtpCreditCardExpiry.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpCreditCardExpiry.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpCreditCardExpiry.CustomFormat = "MMM. dd, yyyy";
            this.dtpCreditCardExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreditCardExpiry.Location = new System.Drawing.Point(104, 89);
            this.dtpCreditCardExpiry.Name = "dtpCreditCardExpiry";
            this.dtpCreditCardExpiry.Size = new System.Drawing.Size(82, 20);
            this.dtpCreditCardExpiry.TabIndex = 79;
            this.dtpCreditCardExpiry.Value = new System.DateTime(2008, 7, 2, 0, 0, 0, 0);
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.SystemColors.Control;
            this.label69.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.Location = new System.Drawing.Point(25, 92);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(76, 16);
            this.label69.TabIndex = 124;
            this.label69.Text = "Expiry Date :";
            // 
            // txtCreditCardType
            // 
            this.txtCreditCardType.AutoCompleteCustomSource.AddRange(new string[] {
            "VISA",
            "MASTERCARD",
            "AMERICAN EXPRESS",
            "DINERS CLUB",
            "JCB",
            "CARTE BLANCHE",
            "AUSTRALIAN BANKCARD",
            "DISCOVER",
            "SWITCH",
            "SOLO",
            "ENROUTE"});
            this.txtCreditCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCreditCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCreditCardType.BackColor = System.Drawing.SystemColors.Info;
            this.txtCreditCardType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditCardType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCreditCardType.Location = new System.Drawing.Point(104, 35);
            this.txtCreditCardType.MaxLength = 100;
            this.txtCreditCardType.Name = "txtCreditCardType";
            this.txtCreditCardType.Size = new System.Drawing.Size(103, 20);
            this.txtCreditCardType.TabIndex = 77;
            // 
            // txtCreditCardNo
            // 
            this.txtCreditCardNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtCreditCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditCardNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCreditCardNo.Location = new System.Drawing.Point(104, 62);
            this.txtCreditCardNo.MaxLength = 16;
            this.txtCreditCardNo.Name = "txtCreditCardNo";
            this.txtCreditCardNo.Size = new System.Drawing.Size(142, 20);
            this.txtCreditCardNo.TabIndex = 78;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.SystemColors.Control;
            this.label67.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(25, 38);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(76, 16);
            this.label67.TabIndex = 124;
            this.label67.Text = "Card Type :";
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.SystemColors.Control;
            this.label61.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.Location = new System.Drawing.Point(25, 65);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(73, 16);
            this.label61.TabIndex = 114;
            this.label61.Text = "Card No. :";
            // 
            // txtCard_No
            // 
            this.txtCard_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCard_No.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCard_No.Location = new System.Drawing.Point(91, 68);
            this.txtCard_No.MaxLength = 100;
            this.txtCard_No.Name = "txtCard_No";
            this.txtCard_No.ReadOnly = true;
            this.txtCard_No.Size = new System.Drawing.Size(176, 20);
            this.txtCard_No.TabIndex = 73;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(9, 70);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(80, 16);
            this.label59.TabIndex = 157;
            this.label59.Text = "Card No.";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccount_Type
            // 
            this.txtAccount_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccount_Type.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount_Type.Location = new System.Drawing.Point(91, 23);
            this.txtAccount_Type.MaxLength = 100;
            this.txtAccount_Type.Name = "txtAccount_Type";
            this.txtAccount_Type.ReadOnly = true;
            this.txtAccount_Type.Size = new System.Drawing.Size(176, 20);
            this.txtAccount_Type.TabIndex = 72;
            // 
            // txtTotal_Sales_Contribution
            // 
            this.txtTotal_Sales_Contribution.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal_Sales_Contribution.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal_Sales_Contribution.Location = new System.Drawing.Point(91, 151);
            this.txtTotal_Sales_Contribution.MaxLength = 100;
            this.txtTotal_Sales_Contribution.Name = "txtTotal_Sales_Contribution";
            this.txtTotal_Sales_Contribution.ReadOnly = true;
            this.txtTotal_Sales_Contribution.Size = new System.Drawing.Size(118, 20);
            this.txtTotal_Sales_Contribution.TabIndex = 76;
            this.txtTotal_Sales_Contribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(9, 153);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(80, 16);
            this.label53.TabIndex = 82;
            this.label53.Text = "Total Sales";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoOfVisits
            // 
            this.txtNoOfVisits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoOfVisits.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfVisits.Location = new System.Drawing.Point(91, 123);
            this.txtNoOfVisits.MaxLength = 100;
            this.txtNoOfVisits.Name = "txtNoOfVisits";
            this.txtNoOfVisits.ReadOnly = true;
            this.txtNoOfVisits.Size = new System.Drawing.Size(118, 20);
            this.txtNoOfVisits.TabIndex = 75;
            this.txtNoOfVisits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(9, 125);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(80, 16);
            this.label52.TabIndex = 80;
            this.label52.Text = "No. of Visit";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreateTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreateTime.Location = new System.Drawing.Point(91, 95);
            this.txtCreateTime.MaxLength = 100;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 74;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(9, 97);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(80, 16);
            this.label51.TabIndex = 78;
            this.label51.Text = "Guest Since";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(9, 25);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(79, 30);
            this.label50.TabIndex = 76;
            this.label50.Text = "Guest Account Type";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.label68);
            this.GroupBox1.Controls.Add(this.chkTaxExempted);
            this.GroupBox1.Controls.Add(this.dtpBirth_Date);
            this.GroupBox1.Controls.Add(this.label54);
            this.GroupBox1.Controls.Add(this.txtMobileNo);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtEmailAddress);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.Label25);
            this.GroupBox1.Controls.Add(this.txtPassportid);
            this.GroupBox1.Controls.Add(this.txtStreet);
            this.GroupBox1.Controls.Add(this.txtCity);
            this.GroupBox1.Controls.Add(this.txtCountry);
            this.GroupBox1.Controls.Add(this.txtzip);
            this.GroupBox1.Controls.Add(this.txtTelephoneNo);
            this.GroupBox1.Controls.Add(this.txtFaxNo);
            this.GroupBox1.Controls.Add(this.Label22);
            this.GroupBox1.Controls.Add(this.txtGuestRemarks);
            this.GroupBox1.Controls.Add(this.Label20);
            this.GroupBox1.Controls.Add(this.Label15);
            this.GroupBox1.Controls.Add(this.Label19);
            this.GroupBox1.Controls.Add(this.Label21);
            this.GroupBox1.Controls.Add(this.Label76);
            this.GroupBox1.Controls.Add(this.label49);
            this.GroupBox1.Controls.Add(this.Label27);
            this.GroupBox1.Controls.Add(this.txtConcierge);
            this.GroupBox1.Controls.Add(this.txtGuestMemo);
            this.GroupBox1.Location = new System.Drawing.Point(2, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(485, 337);
            this.GroupBox1.TabIndex = 83;
            this.GroupBox1.TabStop = false;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.Color.Black;
            this.label68.Location = new System.Drawing.Point(11, 248);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(129, 16);
            this.label68.TabIndex = 87;
            this.label68.Text = "Concierge";
            // 
            // chkTaxExempted
            // 
            this.chkTaxExempted.AutoSize = true;
            this.chkTaxExempted.Location = new System.Drawing.Point(364, 139);
            this.chkTaxExempted.Name = "chkTaxExempted";
            this.chkTaxExempted.Size = new System.Drawing.Size(94, 18);
            this.chkTaxExempted.TabIndex = 70;
            this.chkTaxExempted.Text = "Tax Exempted";
            this.chkTaxExempted.UseVisualStyleBackColor = true;
            // 
            // dtpBirth_Date
            // 
            this.dtpBirth_Date.CustomFormat = "dd-MMM-yyyy";
            this.dtpBirth_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirth_Date.Location = new System.Drawing.Point(84, 135);
            this.dtpBirth_Date.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirth_Date.Name = "dtpBirth_Date";
            this.dtpBirth_Date.Size = new System.Drawing.Size(125, 20);
            this.dtpBirth_Date.TabIndex = 69;
            this.dtpBirth_Date.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.Location = new System.Drawing.Point(11, 139);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(71, 16);
            this.label54.TabIndex = 85;
            this.label54.Text = "Birth Date";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(84, 110);
            this.txtMobileNo.MaxLength = 50;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(125, 20);
            this.txtMobileNo.TabIndex = 67;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(11, 112);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 16);
            this.Label2.TabIndex = 77;
            this.Label2.Text = "Mobile";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmailAddress.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(307, 110);
            this.txtEmailAddress.MaxLength = 100;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(154, 20);
            this.txtEmailAddress.TabIndex = 68;
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(11, 167);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(129, 16);
            this.Label14.TabIndex = 81;
            this.Label14.Text = "Remarks / Preferences";
            // 
            // Label25
            // 
            this.Label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label25.ForeColor = System.Drawing.Color.Black;
            this.Label25.Location = new System.Drawing.Point(233, 112);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(85, 16);
            this.Label25.TabIndex = 79;
            this.Label25.Text = "Email Address";
            this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassportid
            // 
            this.txtPassportid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportid.Location = new System.Drawing.Point(84, 22);
            this.txtPassportid.MaxLength = 30;
            this.txtPassportid.Name = "txtPassportid";
            this.txtPassportid.Size = new System.Drawing.Size(125, 20);
            this.txtPassportid.TabIndex = 60;
            // 
            // txtStreet
            // 
            this.txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStreet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.Location = new System.Drawing.Point(84, 61);
            this.txtStreet.MaxLength = 100;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(135, 20);
            this.txtStreet.TabIndex = 62;
            // 
            // txtCity
            // 
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(223, 61);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(135, 20);
            this.txtCity.TabIndex = 63;
            // 
            // txtCountry
            // 
            this.txtCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountry.Location = new System.Drawing.Point(307, 22);
            this.txtCountry.MaxLength = 100;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(154, 20);
            this.txtCountry.TabIndex = 61;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtCountry_TextChanged);
            // 
            // txtzip
            // 
            this.txtzip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtzip.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtzip.Location = new System.Drawing.Point(362, 61);
            this.txtzip.MaxLength = 10;
            this.txtzip.Name = "txtzip";
            this.txtzip.Size = new System.Drawing.Size(98, 20);
            this.txtzip.TabIndex = 64;
            // 
            // txtTelephoneNo
            // 
            this.txtTelephoneNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelephoneNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephoneNo.Location = new System.Drawing.Point(84, 86);
            this.txtTelephoneNo.MaxLength = 50;
            this.txtTelephoneNo.Name = "txtTelephoneNo";
            this.txtTelephoneNo.Size = new System.Drawing.Size(125, 20);
            this.txtTelephoneNo.TabIndex = 65;
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFaxNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaxNo.Location = new System.Drawing.Point(307, 86);
            this.txtFaxNo.MaxLength = 50;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(154, 20);
            this.txtFaxNo.TabIndex = 66;
            // 
            // Label22
            // 
            this.Label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(233, 88);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(75, 16);
            this.Label22.TabIndex = 78;
            this.Label22.Text = "Fax";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGuestRemarks
            // 
            this.txtGuestRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuestRemarks.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuestRemarks.Location = new System.Drawing.Point(9, 186);
            this.txtGuestRemarks.Multiline = true;
            this.txtGuestRemarks.Name = "txtGuestRemarks";
            this.txtGuestRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGuestRemarks.Size = new System.Drawing.Size(452, 59);
            this.txtGuestRemarks.TabIndex = 71;
            // 
            // Label20
            // 
            this.Label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.ForeColor = System.Drawing.Color.Black;
            this.Label20.Location = new System.Drawing.Point(394, 45);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(27, 16);
            this.Label20.TabIndex = 74;
            this.Label20.Text = "ZIP ";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label15
            // 
            this.Label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(113, 45);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(80, 16);
            this.Label15.TabIndex = 82;
            this.Label15.Text = "Street";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label19
            // 
            this.Label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(258, 24);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(48, 16);
            this.Label19.TabIndex = 75;
            this.Label19.Text = "Country ";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label21
            // 
            this.Label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.Location = new System.Drawing.Point(258, 46);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(44, 15);
            this.Label21.TabIndex = 76;
            this.Label21.Text = "City ";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label76
            // 
            this.Label76.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label76.ForeColor = System.Drawing.Color.Black;
            this.Label76.Location = new System.Drawing.Point(11, 88);
            this.Label76.Name = "Label76";
            this.Label76.Size = new System.Drawing.Size(71, 16);
            this.Label76.TabIndex = 63;
            this.Label76.Text = "Phone";
            this.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(11, 64);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(73, 14);
            this.label49.TabIndex = 83;
            this.label49.Text = "Address";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label27
            // 
            this.Label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label27.Location = new System.Drawing.Point(11, 25);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(73, 14);
            this.Label27.TabIndex = 43;
            this.Label27.Text = "Passport No.";
            this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConcierge
            // 
            this.txtConcierge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcierge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcierge.Location = new System.Drawing.Point(9, 267);
            this.txtConcierge.Multiline = true;
            this.txtConcierge.Name = "txtConcierge";
            this.txtConcierge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConcierge.Size = new System.Drawing.Size(452, 59);
            this.txtConcierge.TabIndex = 86;
            // 
            // txtGuestMemo
            // 
            this.txtGuestMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuestMemo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuestMemo.Location = new System.Drawing.Point(9, 267);
            this.txtGuestMemo.Multiline = true;
            this.txtGuestMemo.Name = "txtGuestMemo";
            this.txtGuestMemo.Size = new System.Drawing.Size(452, 59);
            this.txtGuestMemo.TabIndex = 88;
            // 
            // tabJoiners
            // 
            this.tabJoiners.Controls.Add(this.btnCheckOutDependentGuest);
            this.tabJoiners.Controls.Add(this.grdDependentGuests);
            this.tabJoiners.Controls.Add(this.btnRemoveDependentGuest);
            this.tabJoiners.Controls.Add(this.btnAddDependentGuest);
            this.tabJoiners.Location = new System.Drawing.Point(4, 23);
            this.tabJoiners.Name = "tabJoiners";
            this.tabJoiners.Padding = new System.Windows.Forms.Padding(3);
            this.tabJoiners.Size = new System.Drawing.Size(823, 346);
            this.tabJoiners.TabIndex = 10;
            this.tabJoiners.Text = "Joiners";
            this.tabJoiners.UseVisualStyleBackColor = true;
            // 
            // btnCheckOutDependentGuest
            // 
            this.btnCheckOutDependentGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckOutDependentGuest.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOutDependentGuest.Location = new System.Drawing.Point(739, 16);
            this.btnCheckOutDependentGuest.Name = "btnCheckOutDependentGuest";
            this.btnCheckOutDependentGuest.Size = new System.Drawing.Size(66, 28);
            this.btnCheckOutDependentGuest.TabIndex = 133;
            this.btnCheckOutDependentGuest.Text = "Check Out";
            this.btnCheckOutDependentGuest.Click += new System.EventHandler(this.btnCheckOutDependentGuest_Click);
            // 
            // grdDependentGuests
            // 
            this.grdDependentGuests.AllowEditing = false;
            this.grdDependentGuests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDependentGuests.ColumnInfo = resources.GetString("grdDependentGuests.ColumnInfo");
            this.grdDependentGuests.ContextMenuStrip = this.cmuJoiner;
            this.grdDependentGuests.ExtendLastCol = true;
            this.grdDependentGuests.Location = new System.Drawing.Point(6, 58);
            this.grdDependentGuests.Name = "grdDependentGuests";
            this.grdDependentGuests.Rows.Count = 1;
            this.grdDependentGuests.Rows.DefaultSize = 17;
            this.grdDependentGuests.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdDependentGuests.Size = new System.Drawing.Size(811, 278);
            this.grdDependentGuests.StyleInfo = resources.GetString("grdDependentGuests.StyleInfo");
            this.grdDependentGuests.TabIndex = 132;
            this.grdDependentGuests.RowColChange += new System.EventHandler(this.grdDependentGuests_RowColChange);
            // 
            // cmuJoiner
            // 
            this.cmuJoiner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmReplaceJoiner});
            this.cmuJoiner.Name = "cmuJoiner";
            this.cmuJoiner.Size = new System.Drawing.Size(156, 26);
            // 
            // cmReplaceJoiner
            // 
            this.cmReplaceJoiner.Name = "cmReplaceJoiner";
            this.cmReplaceJoiner.Size = new System.Drawing.Size(155, 22);
            this.cmReplaceJoiner.Text = "Replace Joiner";
            this.cmReplaceJoiner.Click += new System.EventHandler(this.cmReplaceJoiner_Click);
            // 
            // btnRemoveDependentGuest
            // 
            this.btnRemoveDependentGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveDependentGuest.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDependentGuest.Location = new System.Drawing.Point(671, 16);
            this.btnRemoveDependentGuest.Name = "btnRemoveDependentGuest";
            this.btnRemoveDependentGuest.Size = new System.Drawing.Size(66, 28);
            this.btnRemoveDependentGuest.TabIndex = 79;
            this.btnRemoveDependentGuest.Text = "Remove";
            this.btnRemoveDependentGuest.Click += new System.EventHandler(this.btnRemoveDependentGuest_Click);
            // 
            // btnAddDependentGuest
            // 
            this.btnAddDependentGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDependentGuest.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDependentGuest.Location = new System.Drawing.Point(603, 16);
            this.btnAddDependentGuest.Name = "btnAddDependentGuest";
            this.btnAddDependentGuest.Size = new System.Drawing.Size(66, 28);
            this.btnAddDependentGuest.TabIndex = 78;
            this.btnAddDependentGuest.Text = "Add";
            this.btnAddDependentGuest.Click += new System.EventHandler(this.btnAddDependentGuest_Click);
            // 
            // btnPrintInfo
            // 
            this.btnPrintInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInfo.Location = new System.Drawing.Point(84, 607);
            this.btnPrintInfo.Name = "btnPrintInfo";
            this.btnPrintInfo.Size = new System.Drawing.Size(70, 31);
            this.btnPrintInfo.TabIndex = 3;
            this.btnPrintInfo.Text = "&Print";
            this.tipSked.SetToolTip(this.btnPrintInfo, "Print Registration Info");
            this.btnPrintInfo.Click += new System.EventHandler(this.btnPrintInfo_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Account Id";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Name";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "First Name";
            this.columnHeader5.Width = 155;
            // 
            // lvwBrowseGuestName
            // 
            this.lvwBrowseGuestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwBrowseGuestName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwBrowseGuestName.FullRowSelect = true;
            this.lvwBrowseGuestName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwBrowseGuestName.Location = new System.Drawing.Point(-403, 7);
            this.lvwBrowseGuestName.Name = "lvwBrowseGuestName";
            this.lvwBrowseGuestName.Size = new System.Drawing.Size(409, 119);
            this.lvwBrowseGuestName.TabIndex = 4;
            this.lvwBrowseGuestName.UseCompatibleStateImageBehavior = false;
            this.lvwBrowseGuestName.View = System.Windows.Forms.View.Details;
            this.lvwBrowseGuestName.Visible = false;
            this.lvwBrowseGuestName.DoubleClick += new System.EventHandler(this.lvwBrowseGuestName_DoubleClick);
            this.lvwBrowseGuestName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseGuestName_KeyPress);
            // 
            // lvwBrowseCompany
            // 
            this.lvwBrowseCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwBrowseCompany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvwBrowseCompany.FullRowSelect = true;
            this.lvwBrowseCompany.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwBrowseCompany.Location = new System.Drawing.Point(-379, 141);
            this.lvwBrowseCompany.Name = "lvwBrowseCompany";
            this.lvwBrowseCompany.Size = new System.Drawing.Size(385, 87);
            this.lvwBrowseCompany.TabIndex = 6;
            this.lvwBrowseCompany.UseCompatibleStateImageBehavior = false;
            this.lvwBrowseCompany.View = System.Windows.Forms.View.Details;
            this.lvwBrowseCompany.Visible = false;
            this.lvwBrowseCompany.DoubleClick += new System.EventHandler(this.lvwBrowseCompany_DoubleClick);
            this.lvwBrowseCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseCompany_KeyPress);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Company Id";
            this.ColumnHeader1.Width = 88;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Company Name";
            this.ColumnHeader2.Width = 277;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(771, 607);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 31);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "C&lose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.EnabledChanged += new System.EventHandler(this.btnClose_EnabledChanged);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.SystemColors.Control;
            this.label71.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(12, 11);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(111, 22);
            this.label71.TabIndex = 93;
            this.label71.Text = "Reservation";
            // 
            // ReservationFolioUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(848, 646);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.btnConfirmed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNoShow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckedOut);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCheckedIn);
            this.Controls.Add(this.lvwBrowseCompany);
            this.Controls.Add(this.lvwBrowseGuestName);
            this.Controls.Add(this.btnCancelReservation);
            this.Controls.Add(this.tabFolio);
            this.Controls.Add(this.grbFolioInfo);
            this.Controls.Add(this.btnBrowseAccount);
            this.Controls.Add(this.btnFolio);
            this.Controls.Add(this.btnPrintInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ReservationFolioUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Folio";
            this.Activated += new System.EventHandler(this.ReservationFolioUI_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReservationFolioUI_FormClosing);
            this.TextChanged += new System.EventHandler(this.ReservationFolioUI_TextChanged);
            this.Load += new System.EventHandler(this.ReservationFolioUI_Load);
            this.grbFolioInfo.ResumeLayout(false);
            this.grbFolioInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGuestImage)).EndInit();
            this.tabFolio.ResumeLayout(false);
            this.tabBooking.ResumeLayout(false);
            this.tabBooking.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfAdults)).EndInit();
            this.grpAutoRoom.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.grbActualGuestArrivalDeparture.ResumeLayout(false);
            this.grbActualGuestArrivalDeparture.PerformLayout();
            this.grpCalendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioSchedule)).EndInit();
            this.cmuSchedule.ResumeLayout(false);
            this.tabBilling.ResumeLayout(false);
            this.tabBilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillingInstruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBITransactionCodes)).EndInit();
            this.tabCharges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecurringCharges)).EndInit();
            this.tabPackage.ResumeLayout(false);
            this.tabPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHotelPromos)).EndInit();
            this.tabPrivilege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPrivileges)).EndInit();
            this.gbxApplyPrivileges.ResumeLayout(false);
            this.gbxApplyPrivileges.PerformLayout();
            this.tabInclusions.ResumeLayout(false);
            this.tabInclusions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioInclusions)).EndInit();
            this.tabGuestInfo.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.grbCreditCardInfo.ResumeLayout(false);
            this.grbCreditCardInfo.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.tabJoiners.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDependentGuests)).EndInit();
            this.cmuJoiner.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		#region "VARIABLES/OBJECTS"

		private ControlListener loControlListener = new ControlListener();
		DateTime lAuditDate = DateTime.Parse(GlobalVariables.gAuditDate);

		private FolioFacade loFolioFacade = new FolioFacade();
		private Sequence loFolioSequence = new Sequence();

		// the current folio [only 1 folio per UI instance]
		private Folio loFolio = new Folio();

		private GuestFacade loGuestFacade;
		//private IList<Guest> loGuestList;
		// used in lookup
		//private DataTable loGuests;
		private DataView loDtViewGuest;

		private CompanyFacade loCompanyFacade;
		//private IList<Company> loCompanyList;

		//private DataTable loCompany;
		private DataView loDtViewCompany;


		//private Guest loFolioGuest;
		private TransactionCodeFacade loTransactionCodeFacade;
		private IList<TransactionCode> loTransactionCodeList;
		private ReservationOperationMode lOperationMode;

		private IList<RateType> loRateTypes;
		private string lStringRateTypeList = "";
		private IList<RoomType> loRoomTypes;
		private string lStringRoomTypeList = "";
		private IList<Room> loRooms;
		private string lStringRoomList = "";

		private PackageFacade loPackageFacade;
		private IList<PackageHeader> loPackages;

		private FolioLedgerUI lFolioLedgerUI;
		private ReportFacade loReportFacade;
		private ReportViewer loReportViewerUI;

		private RoomCalendarUI lRoomCalendarUI = null;

		private UserFacade loUserFacade;
		private IList<User> loSalesExecutive;

        private String[] aReservationStatus = { "TENTATIVE", "WAIT LIST", "CONFIRMED", "ONGOING", "CLOSED", "CANCELLED", "NO SHOW" };

		public enum UIMode
		{
			Add,
			Edit
		}
		private UIMode lUIMode;

		#endregion

		#region "CONSTRUCTORS"
		public ReservationFolioUI(ReservationOperationMode pOperationMode)
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
			lOperationMode = pOperationMode;

			loadRooms();
			loadRoomTypes();
			loadRateTypes();
			getTransactionCodes();
			loadGuestAccounts();
			loadHotelPackages();
			loadCompanyAccounts();
			loadSalesExecutives();
            loadInclusions();

			loadTransactionCodesToGrid(this.grdBITransactionCodes);

			switch (pOperationMode)
			{
				case ReservationOperationMode.NewGuestReservation:

					lUIMode = UIMode.Add;

					initializeNewGuestReservation();

					break;
				case ReservationOperationMode.NewShareFolio:
					lUIMode = UIMode.Add;

					initializeNewGuestReservation();
					this.cboFolioType.SelectedIndex = 2; // SHARE

					break;

				case ReservationOperationMode.NonStaying:
					lUIMode = UIMode.Add;
					this.lOperationMode = ReservationOperationMode.NewGuestReservation;

					initializeNewGuestReservation();
					this.cboFolioType.SelectedIndex = 3; // SHARE

					break;

				case ReservationOperationMode.WaitList:

					lUIMode = UIMode.Add;

					initializeNewGuestReservation();
					this.cboFolioType.SelectedIndex = 0;
					this.txtStatus.Text = "WAIT LIST";

					break;

				default:
					MessageBox.Show("Method not yet supported.\r\n\r\nOperation mode: " + pOperationMode.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
					break;
			}
		}

		/// <summary>
		/// ReservationFolioUI
		/// </summary>
		/// <param name="pOperationMode">View Folio Information, [DEPENDENT,SHARE,INDIVIDUAL]</param>
		/// <param name="pFolioId">Folio Id to view</param>
		public ReservationFolioUI(ReservationOperationMode pOperationMode, string pFolioId)
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
			lOperationMode = pOperationMode;

			loadRooms();
			loadRoomTypes();
			loadRateTypes();
			getTransactionCodes();
			loadHotelPackages();
			loadGuestAccounts();
			loadCompanyAccounts();
			loadSalesExecutives();
            loadInclusions();


			loadTransactionCodesToGrid(this.grdBITransactionCodes);

			lUIMode = UIMode.Edit;
			switch (pOperationMode)
			{

				case ReservationOperationMode.ViewFolioInformation:
				case ReservationOperationMode.ViewFolioFromCalendar:
					// load folio information only if valid Folio Id
					if (pFolioId.Trim().Length > 0)
					{
						loFolio = loFolioFacade.GetFolio(pFolioId);
					}

					// load folio information only if Folio is not null
					if (loFolio != null)
					{
						loadFolioInformation();
					}
					break;
				case ReservationOperationMode.ViewChildFolio:

					addAccountTypesForGroup();

					// load folio information only if valid Folio Id
					if (pFolioId.Trim().Length > 0)
					{
						loFolio = loFolioFacade.GetFolio(pFolioId);
					}

					// load folio information only if Folio is not null
					if (loFolio != null)
					{
						this.cboFolioType.Items.Clear();
						this.cboFolioType.Items.Add(loFolio.FolioType);
						loadFolioInformation();


						addRateTypeAppliedForGroup();


					}
					break;

			}

            //>>if adding of different rooms on different schedules is disabled
            if (cboFolioType.Text == "DEPENDENT")
            {
                addRateTypeAppliedForGroup();
                disableControlsForDependentFolio();
            }
		}

		// for QUICK CHECK IN
		public ReservationFolioUI(string pRoomNo)
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
			loadRooms();
			loadRoomTypes();
			loadRateTypes();
			getTransactionCodes();
			loadHotelPackages();
			loadGuestAccounts();
			loadCompanyAccounts();
			loadSalesExecutives();
			loadTransactionCodesToGrid(this.grdBITransactionCodes);
            loadInclusions();

			lOperationMode = ReservationOperationMode.QuickReservation;

			this.rdAutoRoom.Enabled = false;
			this.rbCalendar.Enabled = false;
			this.grpCalendar.Enabled = false;

			initializeNewGuestReservation();

			// override previous setting for QUICK CHECK IN
			this.cboSource.SelectedIndex = 4;
			this.txtStatus.Text = "ONGOING";
			this.grdFolioSchedule.SetData(1, 0, pRoomNo);
			this.grdFolioSchedule_AfterEdit(this, new RowColEventArgs(1, 0));
		}

		/// <summary>
		/// ReservationFolioUI
		/// </summary>
		/// <param name="pOperationMode">For Child Folio, [DEPENDENT]</param>
		/// <param name="pFolioId">Folio of New Dependent</param>
		public ReservationFolioUI(ReservationOperationMode pOperationMode, Folio pDependentFolio)
		{
			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
			lOperationMode = pOperationMode;

			loadRooms();
			loadRoomTypes();
			loadRateTypes();
			getTransactionCodes();
			loadHotelPackages();
            loadInclusions();

			loadGuestAccounts();
			loadCompanyAccounts();
			loadSalesExecutives();


			loadTransactionCodesToGrid(this.grdBITransactionCodes);
			addAccountTypesForGroup();

			switch (pOperationMode)
			{
				case ReservationOperationMode.NewChildFolio:
					// load folio information only if valid Folio Id

					// load folio information only if Folio is not null
					if (pDependentFolio != null)
					{
						this.cboFolioType.Items.Clear();
						this.cboFolioType.Items.Add(pDependentFolio.FolioType);
						loFolio = pDependentFolio;
						loadFolioInformation();
                        nudNoOfAdults.Value = 1;

						addRateTypeAppliedForGroup();
                        loadRoomInclusionsOfGroups();

                        //>> change package dates after change schedule
                        dtpPackageDateFrom.Value = DateTime.Parse(grdFolioSchedule.GetDataDisplay(1, 2));
                        dtpPackageDateTo.Value = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));					
                    }
					break;
			}

            //>>if adding of different rooms on different schedules is disabled
            disableControlsForDependentFolio();
            //txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
		}

        private void disableControlsForDependentFolio()
        {
            rbCalendar.Enabled = false;
            rdAutoRoom.Enabled = false;

            grdFolioSchedule.Cols[1].AllowEditing = false;
            if (txtStatus.Text != "ONGOING")
            {
                grdFolioSchedule.Cols[0].AllowEditing = false;
            }
            else
            {
                grdFolioSchedule.Cols[0].AllowEditing = true;
            }
        }

		#endregion

		#region "METHODS"

		/// <summary>
		/// Loads all Transaction codes to local variable
		/// </summary>
		private void getTransactionCodes()
		{
			loTransactionCodeFacade = new TransactionCodeFacade();
			loTransactionCodeList = loTransactionCodeFacade.getTransactionCodeList();
		}

		private void loadTransactionCodesToGrid(C1FlexGrid pGrid)
		{
			pGrid.Rows.Count = loTransactionCodeList.Count + 1;

			int i = 1;
			foreach (TransactionCode _TransactionCode in loTransactionCodeList)
			{
				if (_TransactionCode.AcctSide == "DEBIT")
				{
					pGrid.SetData(i, 0, _TransactionCode.TranCode);
					pGrid.SetData(i, 1, _TransactionCode.Memo);

					i++;
				}
				else
				{
					pGrid.Rows.Count -= 1;
				}
			}
		}

		private void loadRateTypes()
		{
			RateTypeFacade _oRateTypeFacade = new RateTypeFacade();
			loRateTypes = _oRateTypeFacade.getRateTypeList();
		}


		IList<EventAppliedRates> loEventAppliedRatesList;
		private void addRateTypeAppliedForGroup()
		{
            try
            {
                EventAppliedRatesFacade _oAppliedRatesFacade = new EventAppliedRatesFacade();
                loEventAppliedRatesList = _oAppliedRatesFacade.getAppliedRatesForEvents(loFolio.MasterFolio);
            }
            catch { }
		}

		private void loadRoomTypes()
		{
			string _whereCondition = "RoomTypeCode <> 'FUNCTION'";

			RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();

			loRoomTypes = _oRoomTypeFacade.getRoomTypesList(_whereCondition);

			lStringRoomTypeList = "";
			foreach (RoomType _oRoomType in loRoomTypes)
			{
				lStringRoomTypeList += _oRoomType.RoomTypeCode + "|";
			}

		}

		private void loadRooms()
		{
			string _whereCondition = "RoomTypeCode <> 'FUNCTION'";

			RoomFacade _oRoomFacade = new RoomFacade();
			loRooms = _oRoomFacade.getRoomList(_whereCondition);

			lStringRoomList = "";
			foreach (Room _oRoom in loRooms)
			{
				lStringRoomList += _oRoom.RoomId + "|";
			}

		}

		private void loadGuestAccounts()
		{
			loGuestFacade = new GuestFacade();

			// used in lookup
			//Guest _oGuest =
			//loGuests = loGuestFacade.getGuestsAsDataTable();
			
			//	loGuests = loFolioFacade.getGuestRecordAsDataTableByAccountID(loFolio.AccountID);
			

			//loGuests = loFolioFacade.getGuestsAsDataTable();
			
			// discarded due to MEMORY problem[Oct 13, 2008]
			//loGuestList = loGuestFacade.getGuestList();

			//load Counties & Nationalities list
			AutoCompleteStringCollection _counties = new AutoCompleteStringCollection();
			AutoCompleteStringCollection _nationalities = new AutoCompleteStringCollection();

			foreach (Country _oCountry in GlobalVariables.gCountryList)
			{
				_counties.Add(_oCountry.CountryName);
				_nationalities.Add(_oCountry.Nationality);
			}

			this.txtCountry.AutoCompleteCustomSource = _counties;
			this.txtCitizenship.AutoCompleteCustomSource = _nationalities;

		}

		private void loadCompanyAccounts()
		{
			loCompanyFacade = new CompanyFacade();

			// used in lookup
			//Company _Company = loCompanyFacade.getCompanyAccountsData();
			//loCompany = _Company.Tables[0];
			//loCompany = loFolioFacade.getCompanyAsDataTable();

			//loCompanyList = loCompanyFacade.getCompanyList();

		}

		public void removeAccountPrivileges()
		{
			this.grdFolioPrivileges.Rows.Count = 1;
		}

		private bool isBIPercentageCorrect()
		{
			decimal _totalPercent = 0;
			for (int i = 1; i < this.grdBillingInstruction.Rows.Count; i++)
			{
				try
				{
					_totalPercent += decimal.Parse(this.grdBillingInstruction.GetDataDisplay(i, 1));
				}
				catch { }
			}

			if (_totalPercent == 100)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool isBIAmountCorrect()
		{
			decimal _totalAmount = 0;
			for (int i = 1; i < this.grdBillingInstruction.Rows.Count; i++)
			{
				try
				{
					_totalAmount += decimal.Parse(this.grdBillingInstruction.GetDataDisplay(i, 2));
				}
				catch { }
			}

			if (_totalAmount > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void createNewFolioBillingInstruction(string pBasis)
		{
			string _subFolio = "";

			for (int i = 1; i < this.grdBillingInstruction.Rows.Count; i++)
			{
				FolioRouting _newFolioRouting = new FolioRouting();

				// to get SubFolio Letter(since we use long subfolio names in grid)
				switch (i)
				{
					case 1:
						_subFolio = "A";
						break;
					case 2:
						_subFolio = "B";
						break;
					case 3:
						_subFolio = "C";
						break;
					case 4:
						_subFolio = "D";
						break;
					default:
						_subFolio = "A";
						break;
				}

				_newFolioRouting.TransactionCode = this.txtBICode.Text;
				_newFolioRouting.Memo = this.txtBIMemo.Text;

				_newFolioRouting.SubFolio = _subFolio;

				_newFolioRouting.Basis = pBasis;
				if (pBasis == "P")
				{
					_newFolioRouting.PercentCharged = decimal.Parse(this.grdBillingInstruction.GetDataDisplay(i, 1));
					_newFolioRouting.AmountCharged = 0;
				}
				else
				{
					_newFolioRouting.PercentCharged = 0;
					_newFolioRouting.AmountCharged = decimal.Parse(this.grdBillingInstruction.GetDataDisplay(i, 2));
				}

				loFolio.FolioRouting.Add(_newFolioRouting);
			}

			this.grdBITransactionCodes.SetCellStyle(this.grdBITransactionCodes.Row, 0, "AddedRouting");
			this.grdBITransactionCodes.SetCellStyle(this.grdBITransactionCodes.Row, 1, "AddedRouting");

			try
			{
				this.grdBITransactionCodes.Row += 1;
			}
			catch
			{ }
		}

		public void initializeNewGuestReservation()
		{
			// to ensure there is always 1 row in folio schedule.
			if (this.grdFolioSchedule.Rows.Count == 1)
			{
				this.grdFolioSchedule.Rows.Count += 1;
				this.nudNoOfAdults.Focus();
			}

			this.cboFolioType.SelectedIndex = 0; // 0 for CONFIRMED
			
			//this.txtStatus.Text = "CONFIRMED";
			this.txtStatus.Text = ConfigVariables.gDefaultStatusForNewReservation;

			this.cboSource.SelectedIndex = 2;
			this.cboSex.SelectedIndex = 0;

			this.dtpFolioETA.Value = DateTime.Parse("02:00:00 PM");
			this.dtpFolioETD.Value = DateTime.Parse("12:00:00 PM");

			this.cboAccountType.SelectedIndex = 0;
			this.cboPayment_Mode.SelectedIndex = 0;
			this.cboPurpose.SelectedIndex = 0;

			this.cboSales_Executive.Text = "";
			// actual arrival time
			this.dtpArrivalTime.Value = DateTime.Parse("08/08/2008 02:00 PM");
			this.dtpDepartureTime.Value = DateTime.Parse("08/08/2008 12:00 PM");

            if (lAutoRooming == false)
            {
                // set folio schedule grid
                foreach (C1.Win.C1FlexGrid.Row _row in grdFolioSchedule.Rows)
                {
                    if (_row.Index != 0)
                    {
                        this.grdFolioSchedule.SetData(_row.Index, 0, ""); // room no
                        this.grdFolioSchedule.SetData(_row.Index, 6, "0.00"); // amount
                        this.grdFolioSchedule.SetData(_row.Index, 7, "0.00"); // total
                        this.grdFolioSchedule.SetData(_row.Index, 8, "Y"); // total
                    }
                }
                //this.grdFolioSchedule.Cols[0].ComboList = lStringRoomList; // room no
                this.grdFolioSchedule.Cols[1].ComboList = lStringRoomTypeList; // room type

                if (lOperationMode != ReservationOperationMode.WaitList)
                {
                    this.grdFolioSchedule.SetData(1, 2, lAuditDate.Date);
                    this.grdFolioSchedule.SetData(1, 3, lAuditDate.AddDays(1).Date);
                    this.grdFolioSchedule.SetData(1, 4, "1"); // days
                }

                //this.grdFolioSchedule.Cols[5].ComboList = lStringRateTypeList; // rate type

            }

			this.grdFolioSchedule_AfterEdit(this, new RowColEventArgs(1, 3)); // to update txtFromdate & toDate
			//setButtonState();

            this.txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;
		}

		private void setButtonState()
		{
			string _folioStatus = this.txtStatus.Text;

			switch (lOperationMode)
			{
				case ReservationOperationMode.NewGuestReservation:
				case ReservationOperationMode.NewChildFolio:
				case ReservationOperationMode.NewShareFolio:
				case ReservationOperationMode.WaitList:

					this.btnFolio.Enabled = false;
					this.btnPrintInfo.Enabled = false;
					this.btnCancelReservation.Enabled = false;
					this.btnNoShow.Enabled = false;
					this.btnCheckedOut.Enabled = false;
					this.btnCheckedIn.Enabled = false;
					this.btnConfirmed.Enabled = false;

					this.btnCancel.Enabled = true;
					this.btnSave.Enabled = true;
					this.btnClose.Enabled = false;
					break;

				case ReservationOperationMode.ViewChildFolio:
				case ReservationOperationMode.ViewFolioInformation:
				case ReservationOperationMode.ViewFolioFromCalendar:
					switch (_folioStatus)
					{
						case "TENTATIVE":
							this.btnFolio.Enabled = true;
							this.btnPrintInfo.Enabled = true;

							this.btnCancelReservation.Enabled = true;
							this.btnNoShow.Enabled = true;
							this.btnCheckedOut.Enabled = false;
							this.btnCheckedIn.Enabled = false;
							this.btnConfirmed.Enabled = true;

							this.btnCancel.Enabled = false;
							this.btnSave.Enabled = false;
							this.btnClose.Enabled = true;
							break;

						case "CONFIRMED":
							this.btnFolio.Enabled = true;
							this.btnPrintInfo.Enabled = true;

							this.btnCancelReservation.Enabled = true;
							this.btnNoShow.Enabled = true;
							this.btnCheckedOut.Enabled = false;
							this.btnCheckedIn.Enabled = true;
							this.btnConfirmed.Enabled = false;

							this.btnCancel.Enabled = false;
							this.btnSave.Enabled = false;
							this.btnClose.Enabled = true;
							break;

						case "ONGOING":
							this.btnFolio.Enabled = true;
							this.btnPrintInfo.Enabled = true;

							this.btnCancelReservation.Enabled = false;
							this.btnNoShow.Enabled = false;
							this.btnCheckedOut.Enabled = true;
							this.btnCheckedIn.Enabled = false;
							this.btnConfirmed.Enabled = false;

							this.btnCancel.Enabled = false;
							this.btnSave.Enabled = false;
							this.btnClose.Enabled = true;

							this.dtpFolioETA.Enabled = false;
							break;

						case "CLOSED":
						case "CANCELLED":
						case "NO SHOW":
							this.btnFolio.Enabled = false;

							this.btnCancelReservation.Enabled = false;
							this.btnNoShow.Enabled = false;
							this.btnCheckedOut.Enabled = false;
							this.btnCheckedIn.Enabled = false;
							this.btnConfirmed.Enabled = false;

							this.btnCancel.Enabled = false;
							this.btnSave.Enabled = false;

							this.grbFolioInfo.Enabled = false;
                            //this.tabFolio.Enabled = false;
                            disableControls(this);
                            this.btnClose.Enabled = true;
                            this.btnPrintInfo.Enabled = true;

							break;

						case "WAIT LIST":
							this.btnFolio.Enabled = false;
							this.btnPrintInfo.Enabled = false;

							this.btnCancelReservation.Enabled = true;
							this.btnNoShow.Enabled = true;
							this.btnCheckedOut.Enabled = false;
							this.btnCheckedIn.Enabled = false;
							this.btnConfirmed.Enabled = true;

							this.btnCancel.Enabled = false;
							this.btnSave.Enabled = false;
							this.btnClose.Enabled = true;

							this.grbFolioInfo.Enabled = true;
							this.tabFolio.Enabled = true;

							break;
					}
					break;

				case ReservationOperationMode.QuickReservation:

					this.btnFolio.Enabled = false;
					this.btnPrintInfo.Enabled = false;

					this.btnCancelReservation.Enabled = false;
					this.btnNoShow.Enabled = false;
					this.btnCheckedOut.Enabled = false;
					this.btnCheckedIn.Enabled = false;
					this.btnConfirmed.Enabled = false;

					this.btnCancel.Enabled = true;
					this.btnSave.Enabled = true;
					this.btnClose.Enabled = false;

					this.dtpFolioETA.Value = DateTime.Now;
					this.dtpArrivalTime.Value = DateTime.Now;
					this.dtpFolioETA.Enabled = false;
					break;

				default:
					this.btnFolio.Enabled = false;
					this.btnPrintInfo.Enabled = false;

					this.btnCancelReservation.Enabled = false;
					this.btnNoShow.Enabled = false;
					this.btnCheckedOut.Enabled = false;
					this.btnCheckedIn.Enabled = false;
					this.btnConfirmed.Enabled = false;

					this.btnCancel.Enabled = false;
					this.btnSave.Enabled = false;
					this.btnClose.Enabled = false;

					this.dtpFolioETA.Enabled = false;
					break;
			}
		}

        public void disableControls(Control pControl)
        {
            foreach (Control _ctrl in pControl.Controls)
            {
                if (_ctrl is TabControl || _ctrl is Panel || _ctrl is GroupBox || _ctrl is TabPage)
                {
                    _ctrl.Enabled = true;
                    disableControls(_ctrl);
                }
                else if (_ctrl is Button)
                {
                    _ctrl.Enabled = false;
                }
            }
        }

		private void computeTotalRoomRateAndDays()
		{
			DateTime _fromDate = this.lAuditDate;
			DateTime _toDate = _fromDate.AddDays(1);

			decimal _total = 0;
			int _totalDays = 0;
			for (int i = 1; i < this.grdFolioSchedule.Rows.Count; i++)
			{
				decimal _lineTotal = 0;

				int _days = int.Parse(this.grdFolioSchedule.GetDataDisplay(i, 4).ToString());
				_totalDays += _days;

				decimal _amount = 0;
				if (decimal.TryParse(this.grdFolioSchedule.GetDataDisplay(i, 6).ToString(), out _amount))
				{
					_lineTotal = _days * _amount;
				}

				this.grdFolioSchedule.SetData(i, 7, _lineTotal.ToString("N"));
				_total += _lineTotal;

				// schedule
				if (i == 1)
				{
					_fromDate = DateTime.Parse(this.grdFolioSchedule.GetDataDisplay(i, 2));
				}
				_toDate = DateTime.Parse(this.grdFolioSchedule.GetDataDisplay(i, 3));
			}

			this.txtFromDate.Text = string.Format(GlobalVariables.gDateFormat, _fromDate);
			this.txtToDate.Text = string.Format(GlobalVariables.gDateFormat, _toDate);

			this.txtTotalDays.Text = _totalDays.ToString();
			this.txtTotalRateAmount.Text = _total.ToString("N");

		}

        //jlo for alpa 6-9-10
        public int getIndex(string str, string[] aStr)
        {
            int index = -1;
            for (int i = 0; i < aStr.Length; i++)
            {
                if (aStr[i] == str)
                {
                    index = i;
                }
            }
            return index;
        }
        //jlo

        private bool assignFolioValues()
		{
			try
			{
                //jlo for alpa 6-9-10
                
                String _rStatus = "";
                if (lUIMode == UIMode.Edit)
                {
                    _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;
                }
                int _newStatus = getIndex(this.txtStatus.Text, aReservationStatus);
                int _dbStatus = getIndex(_rStatus, aReservationStatus);
                if (_newStatus < _dbStatus)
                {
                    txtStatus.Text = _rStatus;
                    if (_rStatus == "ONGOING")
                    {
                        txtFromDate.Text = loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString();
                        grdFolioSchedule.SetData(1,2,loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString());
                    }
                }
                //jlo

				//loFolio.Guest // already assigned
				if (loFolio.Guest == null)
				{
					createNewGuestAccount();
				}
				else
				{
					updateGuestInformation(); // update guest information
				}

				// assign new folio Id
				if (loFolio.FolioID == null)
				{
					loFolio.FolioID = loFolioSequence.getSequenceId("F-", 12, "seq_folio");
				}

				// if new company
				if (this.txtCompanyId.Text == "")
				{
					if (this.txtCompanyName.Text.Trim().Length > 0)
					{
						createNewCompanyAccount();
					}
				}

				loFolio.HotelID = GlobalVariables.gHotelId;
				loFolio.AccountID = loFolio.Guest.AccountId;
				loFolio.FolioType = this.cboFolioType.Text;
				//loFolio.GroupName = "";
				loFolio.AccountType = this.cboAccountType.Text;
				loFolio.NoOfChild = System.Convert.ToInt16(this.nudNoOfChild.Value);
				loFolio.NoofAdults = System.Convert.ToInt16(this.nudNoOfAdults.Value);
				//loFolio.MasterFolio = "";
				loFolio.CompanyID = this.txtCompanyId.Text;
				loFolio.AgentID = this.txtAgentId.Text;
				loFolio.Source = this.cboSource.Text;
                loFolio.FromDate = DateTime.Parse(this.txtFromDate.Text);
                loFolio.Todate = DateTime.Parse(this.txtToDate.Text);

				// check if Reserved a Past Date
				if (loFolio.Status != "ONGOING")
				{
					long _diff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, lAuditDate, loFolio.FromDate);
					if (_diff < 0)
					{
						throw (new Exception("Invalid reservation date.\r\nDate should be a future or current date."));
					}
				}
				// ----- end check

				// changed arrival date only if status is not ONGOING
				// but if Quick Check In, arrival date is now()
				if (lOperationMode == ReservationOperationMode.QuickReservation)
				{
					string _tempArrivalDate = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(this.dtpFromDate.Text)) + " " + string.Format("{0:HH:mm:ss}", dtpFolioETA.Value);

					loFolio.ArrivalDate = DateTime.Parse(_tempArrivalDate);
				}
				else if (lOperationMode == ReservationOperationMode.ViewFolioInformation &&
					this.txtStatus.Text == "ONGOING")
				{
					// do nothing
				}
				else
				{
					string _tempArrivalDate = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(this.dtpFromDate.Text)) + " " + string.Format("{0:HH:mm:ss}", dtpArrivalTime.Value);

					loFolio.ArrivalDate = DateTime.Parse(_tempArrivalDate);

					//loFolio.ArrivalDate = this.dtpArrivalDate.Value;
				}

				// change status to CONFIRM if previous status is WAIT LIST
				// and room has been assigned
				if (txtStatus.Text == "WAIT LIST")
				{
					foreach (C1.Win.C1FlexGrid.Row _row in grdFolioSchedule.Rows)
					{
						if (_row.Index != 0)
						{
							if (grdFolioSchedule.GetDataDisplay(_row.Index, 0) != "")
							{
								txtStatus.Text = "CONFIRMED";
							}
							else
							{
								txtStatus.Text = "WAIT LIST";
							}
						}
					}
				}


				loFolio.DepartureDate = DateTime.Parse(this.dtpDepartureDate.Text + " " + dtpFolioETD.Value.ToShortTimeString());

				try
				{
					loFolio.FolioETA = string.Format("{0:hh:mm tt}", this.dtpFolioETA.Value);
				}
				catch
				{ }
				try
				{
					loFolio.FolioETD = string.Format("{0:hh:mm tt}", this.dtpFolioETD.Value);
				}
				catch { }

				loFolio.PackageID = "";
				loFolio.Status = this.txtStatus.Text;
				loFolio.Remarks = this.txtRemarks.Text;
				loFolio.Sales_Executive = this.cboSales_Executive.Text;
				loFolio.Payment_Mode = this.cboPayment_Mode.Text;
				loFolio.Purpose = this.cboPurpose.Text;
				loFolio.REASON_FOR_CANCEL = "";
				loFolio.TerminalId = GlobalVariables.gTerminalID.ToString();
				loFolio.ShiftCode = GlobalVariables.gShiftCode.ToString();
				loFolio.SupervisorId = GlobalVariables.gLoggedSupervisor;
				loFolio.CreatedBy = txtCreatedBy.Text;
				loFolio.UpdatedBy = GlobalVariables.gLoggedOnUser;

				// creates SCHEDULE
                if (grdFolioSchedule.Rows.Count <= 1 && cboFolioType.Text != "NON-STAYING")
                {
                    throw (new Exception("Invalid folio schedule.\r\nThere should be at least one schedule for the folio."));
                }

                //>for room transfer, check whether room is dirty or not
                if (lOperationMode == ReservationOperationMode.ViewFolioInformation || lOperationMode == ReservationOperationMode.ViewFolioFromCalendar
                    || lOperationMode == ReservationOperationMode.ViewChildFolio)
                {
                    string _roomID = ""; //grdFolioSchedule.GetDataDisplay(1, 0);
                    DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    foreach (C1.Win.C1FlexGrid.Row _row in grdFolioSchedule.Rows)
                    {
                        if (_row.Index != 0)
                        {
                            DateTime _startDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(_row.Index, 2));
                            DateTime _endDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(_row.Index, 3));

                            if (_auditDate >= _startDate && _auditDate <= _endDate)
                            {
                                _roomID = grdFolioSchedule.GetDataDisplay(_row.Index, 0);
                                break;
                            }
                        }
                    }

                    foreach (Schedule _oSched in loFolio.Schedule)
                    {
                        if (_auditDate >= _oSched.FromDate && _auditDate <= _oSched.ToDate)
                        {
                            if (loFolio.Status == "ONGOING" && _oSched.RoomID != _roomID)
                            {
                                string _roomCleaningStatus = loFolioFacade.getRoomCleaningStatus(_roomID);
                                string _occupancyStatus = loFolioFacade.getRoomOccupancyStatus(_roomID);
                                string _reservationStatus = loFolioFacade.getRoomReservationStatus(_roomID, string.Format("{0:yyyy-MM-dd}", _oSched.ToDate));
                                
                                if (_occupancyStatus.ToUpper() == "OCCUPIED")
                                {
                                    throw (new Exception("Room is occupied on the schedule specified."));
                                }
                                if (_roomCleaningStatus == "DIRTY")
                                {
                                    throw (new Exception("Room is dirty"));
                                }
                                if (_reservationStatus != "VACANT")
                                {
                                    DialogResult _response = MessageBox.Show("Room is either occupied or blocked on the schedule specified.\r\n\r\nDo you want to continue saving schedule?", "Conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                    if (_response == DialogResult.No)
                                        return false;
                                }
                            }
                        }
                    }
                }

				switch (loFolio.FolioType)
				{
					case "INDIVIDUAL":
					case "DEPENDENT":
						loFolio.Schedule = createFolioSchedule();
						// disregard checking for CONFLICT ROOM EVENTS if FOLIO will be on WAIT LIST
						switch (loFolio.Status)
						{
							case "WAIT LIST":
								break;

							default:
								if (hasRoomEventConflict() == 1)
								{
									throw (new Exception("Room is either occupied or reserved on the schedule specified."));
								}
								break;
						}

						break;

					case "SHARE":
						//>> create folio schedule w/o checking for ROom Event conflict
						loFolio.Schedule = createFolioSchedule();
						break;

					case "NON-STAYING":
						loFolio.Schedule = new List<Schedule>();
						break;
				}


				loFolio.JoinerFolios = setUpJoinerFolios();

				loFolio.Package = setUpFolioPackage();
				loFolio.Privileges = setUpFolioPrivileges();
				loFolio.RecurringCharges = setUpFolioRecurringCharge();
                loFolio.Inclusions = setUpFolioInclusions();


				//checks if has Master Folio
				switch (loFolio.FolioType)
				{
					case "DEPENDENT":
						//case "SHARE":

						if (this.loFolio.MasterFolio == "")
						{
							throw (new Exception("Please set master folio.\r\n\r\nDependent or Share folio should have a master folio."));
						}
						break;
				}


				//checks PAYMENT MODE
				switch (loFolio.Payment_Mode)
				{
					case "EX-DEAL":
					//case "CHARGE":
						if (this.loFolio.CompanyID.Trim().Length <= 0)
						{
							this.txtCompanyName.Focus();
							throw (new Exception("Please input Company name."));
						}
						break;

					//case "CREDIT CARD":

					//    if (this.loFolio.Guest.CreditCardNo.Trim().Length <= 0)
					//    {
					//        throw (new Exception("Please input credit card information."));
					//    }
					//    break;

				}


				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\n\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
				return false;
			}
		}

		private bool createNewGuestAccount()
		{
			try
			{

				// first name & lastname are required fields
				if (this.txtLastName.Text.Trim().Length == 0)
				{
					this.txtLastName.Focus();
					throw (new Exception("Please input guest's last name."));
				}

				if (this.txtFirstName.Text.Trim().Length == 0)
				{
					this.txtFirstName.Focus();
					throw (new Exception("Please input guest's first name."));
				}


				// create new guest account
				loGuestFacade = new GuestFacade();
				Guest _newGuest = new Guest();

				_newGuest.AccountId = loFolioSequence.getSequenceId("I-", 12, "seq_guest");
				_newGuest.AccountName = this.txtLastName.Text + "_" + this.txtFirstName.Text;
				_newGuest.Title = this.cboTitle.Text;
				_newGuest.LastName = this.txtLastName.Text;
				_newGuest.FirstName = this.txtFirstName.Text;
				_newGuest.MiddleName = "";
				_newGuest.Sex = this.cboSex.Text;
				_newGuest.Citizenship = this.txtCitizenship.Text;

				if (_newGuest.Citizenship == "")
				{
					this.txtCitizenship.Focus();
					throw (new Exception("Please input guest's citizenship"));
				}

				_newGuest.PassportId = this.txtPassportid.Text;
				_newGuest.GuestImage = this.txtGuestImage.Text;
				_newGuest.TelephoneNo = this.txtTelephoneNo.Text;
				_newGuest.MobileNo = this.txtMobileNo.Text;
				_newGuest.FaxNo = this.txtFaxNo.Text;
				_newGuest.Street = this.txtStreet.Text;
				_newGuest.City = this.txtCity.Text;
				_newGuest.Country = this.txtCountry.Text;
				_newGuest.Zip = this.txtzip.Text;
				_newGuest.EmailAddress = this.txtEmailAddress.Text;

				_newGuest.Remark = this.txtGuestRemarks.Text;
				_newGuest.Concierge = this.txtConcierge.Text;
				_newGuest.Memo = this.txtGuestMemo.Text;
				_newGuest.BIRTH_DATE = this.dtpBirth_Date.Value;

				_newGuest.NoOfVisits = 0;
				_newGuest.TOTAL_SALES_CONTRIBUTION = 0;

				_newGuest.HotelID = GlobalVariables.gHotelId;
                _newGuest.CreateTime = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToLongTimeString());
				_newGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
				_newGuest.UpdatedBy = GlobalVariables.gLoggedOnUser;

				_newGuest.ACCOUNT_TYPE = this.txtAccount_Type.Text;
				_newGuest.CARD_NO = this.txtCard_No.Text;
				_newGuest.THRESHOLD_VALUE = double.Parse(ConfigVariables.gDefaultGuestThresholdValue);

				_newGuest.CreditCardNo = this.txtCreditCardNo.Text;
				_newGuest.CreditCardType = this.txtCreditCardType.Text;
				_newGuest.CreditCardExpiry = this.dtpCreditCardExpiry.Text;
				_newGuest.TaxExempted = this.chkTaxExempted.Checked ? 1 : 0;

				loGuestFacade.insertGuest(ref _newGuest);



				// assign new guest to current folio
				loFolio.Guest = _newGuest;

				//// add to local List of Guest
				////loGuestList.Add(_newGuest);
				//Guest _oGuest = loGuestFacade.getGuests();
				//loGuests = _oGuest.Tables[0];
				this.txtAccountID.Text = _newGuest.AccountId;

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private bool createNewCompanyAccount()
		{
			try
			{
				if (this.txtCompanyName.Text.Trim().Length > 0)
				{

					loCompanyFacade = new CompanyFacade();
					Company _newCompany = new Company();

					_newCompany.CompanyId = loFolioSequence.getSequenceId("G-", 12, "seq_company");
					_newCompany.CompanyName = this.txtCompanyName.Text;
                    _newCompany.CompanyCode = this.txtCompanyName.Text;
					_newCompany.HotelID = GlobalVariables.gHotelId;

					loCompanyFacade.insertCompanyGuest(ref _newCompany);

					//loCompany = loCompanyFacade.getCompanyAccountsData().Tables[0];

					this.txtCompanyId.Text = _newCompany.CompanyId;

				}

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		private IList<Schedule> createFolioSchedule()
		{
            //>>checking of schedules
            for (int _row = 2; _row < this.grdFolioSchedule.Rows.Count; _row++)
            {
                DateTime _newDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(_row, 2));
                DateTime _prevDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(_row - 1, 3));

                if (_newDate != _prevDate)
                {
                    throw (new Exception("Invalid schedule on Booking information"));
                }
            }

			IList<Schedule> _oScheduleList = new List<Schedule>();

			// assign folio schedules and add to FolioScheduleCollection
			for (int i = 1; i < this.grdFolioSchedule.Rows.Count; i++)
			{
				Schedule _newSchedule = new Schedule();

				_newSchedule.FolioID = loFolio.FolioID;
				_newSchedule.RoomID = this.grdFolioSchedule.GetDataDisplay(i, 0);
				_newSchedule.RoomType = this.grdFolioSchedule.GetDataDisplay(i, 1);
				_newSchedule.FromDate = DateTime.Parse(this.grdFolioSchedule.GetDataDisplay(i, 2));
				_newSchedule.ToDate = DateTime.Parse(this.grdFolioSchedule.GetDataDisplay(i, 3));


				if (_newSchedule.RoomType == "")
				{
					throw (new Exception("Invalid schedule on Booking information"));
				}

				long _dateDiff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _newSchedule.FromDate, _newSchedule.ToDate);
				if (_dateDiff < 1)
				{
					throw (new Exception("Invalid schedule for Room No. " + _newSchedule.RoomID));
				}

				_newSchedule.RateType = this.grdFolioSchedule.GetDataDisplay(i, 5);
				_newSchedule.Rate = decimal.Parse(this.grdFolioSchedule.GetDataDisplay(i, 6));
				_newSchedule.BreakFast = this.grdFolioSchedule.GetDataDisplay(i, 8);

				_newSchedule.HotelID = GlobalVariables.gHotelId;
				_newSchedule.CreatedBy = GlobalVariables.gLoggedOnUser;
				_newSchedule.UpdatedBy = GlobalVariables.gLoggedOnUser;

				_newSchedule.TerminalId = GlobalVariables.gTerminalID.ToString();
				_newSchedule.ShiftCode = GlobalVariables.gShiftCode.ToString();
				_newSchedule.SupervisorId = GlobalVariables.gLoggedSupervisor;

                //_newSchedule.HasTransfered = int.Parse(this.grdFolioSchedule.GetDataDisplay(i, 9));

				_oScheduleList.Add(_newSchedule);
			}

            // check number of pax
            foreach (RoomType _oRoomType in loRoomTypes)
            {
                if (_oRoomType.RoomTypeCode.ToUpper() == _oScheduleList[0].RoomType.ToUpper())
                {
                    if (_oRoomType.NoofAdult < loFolio.NoofAdults)
                    {
                        if (MessageBox.Show("Number of pax has already exceeded room capacity.\r\nRoom could only accomodate " + _oRoomType.NoofAdult + " adult pax. \r\n\r\nDo you wish to continue?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                        {
                            throw (new Exception("Invalid schedule for Room No. " + _oScheduleList[0].RoomID + "\r\nMaximum Adult pax exceeds room capacity.\r\n\r\nRoom could only accomodate " + _oRoomType.NoofAdult + " adult pax."));
                        }
                    }

                    if (_oRoomType.NoofChild < loFolio.NoOfChild)
                    {
                        if (MessageBox.Show("Number of pax has already exceeded room capacity.\r\nRoom could only accomodate " + _oRoomType.NoofChild + " child pax. \r\n\r\nDo you wish to continue?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                        {
                            throw (new Exception("Invalid schedule for Room No. " + _oScheduleList[0].RoomID + "\r\nMaximum Child pax exceeds room capacity.\r\n\r\nRoom could only accomodate " + _oRoomType.NoofChild + " child pax."));
                        }
                    }
                    break;
                }
            }

			// merge same Schedule to eliminate duplicate
			_oScheduleList = mergeSameFolioSchedule(_oScheduleList);

			return _oScheduleList;
			//this.loFolio.Schedule = _oScheduleList;
		}

		private IList<FolioPackage> setUpFolioPackage()
		{
			IList<FolioPackage> _oFolioPackage = new List<FolioPackage>();

			for (int i = 1; i < this.grdFolioPackage.Rows.Count; i++)
			{
				FolioPackage _newFolioPackage = new FolioPackage();

				_newFolioPackage.HotelID = loFolio.HotelID;
				_newFolioPackage.FolioID = loFolio.FolioID;
				_newFolioPackage.TransactionCode = this.grdFolioPackage.GetDataDisplay(i, 0);
				_newFolioPackage.Memo = this.grdFolioPackage.GetDataDisplay(i, 1);
				_newFolioPackage.Basis = this.grdFolioPackage.GetDataDisplay(i, 2);
				_newFolioPackage.PercentOff = decimal.Parse(this.grdFolioPackage.GetDataDisplay(i, 3));
				_newFolioPackage.AmountOff = decimal.Parse(this.grdFolioPackage.GetDataDisplay(i, 4));
				_newFolioPackage.DaysApplied = this.txtFolioPackageDaysApplied.Text;
                try
                {
                    _newFolioPackage.DateFrom = dtpPackageDateFrom.Value;
                }
                catch
                {
                    _newFolioPackage.DateFrom = DateTime.Parse(GlobalVariables.gAuditDate);
                }
                try
                {
                    _newFolioPackage.DateTo = dtpPackageDateTo.Value;
                }
                catch
                {
                    _newFolioPackage.DateTo = DateTime.Parse(GlobalVariables.gAuditDate);
                }

				_newFolioPackage.CreatedBy = GlobalVariables.gLoggedOnUser;
				_newFolioPackage.UpdatedBy = GlobalVariables.gLoggedOnUser;

				_oFolioPackage.Add(_newFolioPackage);
			}

			return _oFolioPackage;
		}

        //added by Genny: Alpa requirments - folio inclusions
        private IList<FolioInclusions> setUpFolioInclusions()
        {
            IList<FolioInclusions> _oFolioInclusions = new List<FolioInclusions>();

            for (int i = 0; i < this.grdFolioInclusions.Rows.Count; i++)
            {
                FolioInclusions _newFolioInclusions = new FolioInclusions();

                _newFolioInclusions.HotelID = loFolio.HotelID;
                _newFolioInclusions.FolioID = loFolio.FolioID;
                _newFolioInclusions.Memo = this.grdFolioInclusions.GetDataDisplay(i, 0);

                _newFolioInclusions.CreatedBy = GlobalVariables.gLoggedOnUser;
                _newFolioInclusions.UpdatedBy = GlobalVariables.gLoggedOnUser;

                _oFolioInclusions.Add(_newFolioInclusions);
            }

            return _oFolioInclusions;
        }

		private IList<Privilege> setUpFolioPrivileges()
		{
			IList<Privilege> _oFolioPrivileges = new List<Privilege>();

			for (int i = 1; i < this.grdFolioPrivileges.Rows.Count; i++)
			{
				Privilege _newFolioPrivilege = new Privilege();

				_newFolioPrivilege.HotelId = loFolio.HotelID;
				_newFolioPrivilege.FolioID = loFolio.FolioID;
				_newFolioPrivilege.TransactionCode = this.grdFolioPrivileges.GetDataDisplay(i, 0);
				_newFolioPrivilege.Memo = this.grdFolioPrivileges.GetDataDisplay(i, 1);
				_newFolioPrivilege.Basis = this.grdFolioPrivileges.GetDataDisplay(i, 2);
				_newFolioPrivilege.Percentoff = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(i, 3));
				_newFolioPrivilege.AmountOff = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(i, 4));

				_oFolioPrivileges.Add(_newFolioPrivilege);
			}

			return _oFolioPrivileges;
		}

        private ComboBox lRecurringCombo = new ComboBox();
		private IList<RecurringCharge> setUpFolioRecurringCharge()
		{
			IList<RecurringCharge> _oFolioRecurringCharges = new List<RecurringCharge>();

			for (int i = 1; i < this.grdRecurringCharges.Rows.Count; i++)
			{
				RecurringCharge _newFolioRecurringCharge = new RecurringCharge();

				_newFolioRecurringCharge.HotelID = loFolio.HotelID;
				_newFolioRecurringCharge.FolioID = loFolio.FolioID;
				_newFolioRecurringCharge.TransactionCode = this.grdRecurringCharges.GetDataDisplay(i, 0);
				_newFolioRecurringCharge.Memo = this.grdRecurringCharges.GetDataDisplay(i, 1);
                _newFolioRecurringCharge.SubAccount = this.grdRecurringCharges.GetDataDisplay(i, 5);
				try
				{
					_newFolioRecurringCharge.Amount = decimal.Parse(this.grdRecurringCharges.GetDataDisplay(i, 2));
					_newFolioRecurringCharge.FromDate = DateTime.Parse(this.grdRecurringCharges.GetDataDisplay(i, 3));

					_newFolioRecurringCharge.ToDate = DateTime.Parse(this.grdRecurringCharges.GetDataDisplay(i, 4));
					_newFolioRecurringCharge.SummaryFlag = 0;

					_oFolioRecurringCharges.Add(_newFolioRecurringCharge);

					if (_newFolioRecurringCharge.Amount <= 0)
					{
						throw new Exception();
					}
				}
				catch
				{
					this.tabFolio.SelectedTab = tabCharges;
					throw new Exception("Invalid amount on Recurring Charge transaction.");
				}

			}

			return _oFolioRecurringCharges;
		}

		/// <summary>
		/// Merge Folio Schedules
		/// </summary>
		/// <param name="poScheduleList"></param>
		/// <returns>new FolioScheduleList(merged)</returns>
		private IList<Schedule> mergeSameFolioSchedule(IList<Schedule> poScheduleList)
		{
			IList<Schedule> _newScheduleList = new List<Schedule>();

			foreach (Schedule oSchedule in poScheduleList)
			{
				bool isTheSame = false;

				foreach (Schedule newSchedule in _newScheduleList)
				{
					if (newSchedule.RoomID == oSchedule.RoomID &&
					   newSchedule.RoomType == oSchedule.RoomType &&
					   newSchedule.RateType == oSchedule.RateType &&
					   newSchedule.ToDate == oSchedule.FromDate &&
					   newSchedule.Rate == oSchedule.Rate &&
					   newSchedule.BreakFast == oSchedule.BreakFast)
					{
						isTheSame = true;

						// if thesame then Change Previous Schedule.ToDate
						newSchedule.ToDate = oSchedule.ToDate;
					}

				}

				if (!isTheSame)
				{
					_newScheduleList.Add(oSchedule);
				}

			}
			return _newScheduleList;
		}

		private IList<Folio> setUpJoinerFolios()
		{
			IList<Folio> newDependentFolios = new List<Folio>();

			int numOfDependents = this.grdDependentGuests.Rows.Count;
			for (int i = 1; i < numOfDependents; i++)
			{
				Folio newFolio = new Folio();

				string _accountID = this.grdDependentGuests.GetDataDisplay(i, 1);
                string _folioRemarks = this.grdDependentGuests.GetDataDisplay(i, 9);
                string _arrival = grdDependentGuests.GetDataDisplay(i, 8);

				// assign Folio ID only if new Guest
				string _newFolioId = this.grdDependentGuests.GetDataDisplay(i, 7);
                bool _newJoiner = false;
				if (_newFolioId == "")
				{
                    _newJoiner = true;
					_newFolioId = this.loFolioSequence.getSequenceId("F-", 12, "seq_folio");
					this.grdDependentGuests.SetData(i, 7, _newFolioId);
				}

				newFolio.HotelID = GlobalVariables.gHotelId;
				newFolio.FolioID = _newFolioId;
				newFolio.AccountID = _accountID;
				newFolio.FolioType = "JOINER";
				newFolio.AccountType = "PERSONAL";
				newFolio.NoOfChild = 0;
				newFolio.NoofAdults = 1;
				newFolio.MasterFolio = loFolio.FolioID;
				newFolio.CompanyID = loFolio.CompanyID;
				newFolio.AgentID = loFolio.AgentID;
				newFolio.Source = loFolio.Source;
				newFolio.FromDate = loFolio.FromDate;
				newFolio.Todate = loFolio.Todate;
                if (loFolio.Status == "ONGOING" && loFolio.ArrivalDate.Date < DateTime.Parse(GlobalVariables.gAuditDate).Date && _newJoiner == true)
                {
                    newFolio.ArrivalDate = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToLongTimeString());
                }
                else if (loFolio.Status == "ONGOING" && _newJoiner == false)
                {
                    newFolio.ArrivalDate = DateTime.Parse(_arrival);
                }
                else
                {
                    newFolio.ArrivalDate = loFolio.ArrivalDate;
                }
				newFolio.DepartureDate = loFolio.DepartureDate;
				newFolio.Remarks = _folioRemarks; //"JOINER GUEST - " + 
				newFolio.Status = loFolio.Status;
				newFolio.CreatedBy = GlobalVariables.gLoggedSupervisor;
				newFolio.UpdatedBy = GlobalVariables.gLoggedSupervisor;

				newFolio.FolioETA = loFolio.FolioETA;
				newFolio.FolioETD = loFolio.FolioETD;

				newFolio.Sales_Executive = loFolio.Sales_Executive;
				newFolio.Payment_Mode = loFolio.Payment_Mode;
				newFolio.Purpose = loFolio.Purpose;
				newFolio.REASON_FOR_CANCEL = "";
				newFolio.TerminalId = loFolio.TerminalId;
				newFolio.ShiftCode = loFolio.ShiftCode;
				newFolio.SupervisorId = loFolio.SupervisorId;
				newFolio.CreatedBy = loFolio.CreatedBy;

				// assign guest
				newFolio.Guest = loGuestFacade.getGuestRecord(_accountID);

				newDependentFolios.Add(newFolio);
			}

			return newDependentFolios;
		}

		// >> SHOW PRIVILEGES - GUEST
		public void showGuestPrivileges(IList<PrivilegeHeader> pAccountPrivileges)
		{
			this.grdFolioPrivileges.Rows.Count = 1;
			this.lvwGuestPrivileges.Items.Clear();

			if (pAccountPrivileges != null)
			{
				foreach (PrivilegeHeader _oPrivilegeHeader in pAccountPrivileges)
				{
					int i = this.grdFolioPrivileges.Rows.Count;

					this.grdFolioPrivileges.Rows.Count += _oPrivilegeHeader.PrivilegeDetails.Count;
					foreach (PrivilegeDetail _oPrivilegeDetail in _oPrivilegeHeader.PrivilegeDetails)
					{
						this.grdFolioPrivileges.SetData(i, 0, _oPrivilegeDetail.TransactionCode);
						this.grdFolioPrivileges.SetData(i, 1, _oPrivilegeDetail.Memo);
						this.grdFolioPrivileges.SetData(i, 2, _oPrivilegeDetail.Basis);
						this.grdFolioPrivileges.SetData(i, 3, _oPrivilegeDetail.PercentOff);
						this.grdFolioPrivileges.SetData(i, 4, _oPrivilegeDetail.AmountOff);

						i++;
					}// end inner foreach

					// add to Listview
					ListViewItem lvwItem = new ListViewItem(_oPrivilegeHeader.PrivilegeID);
					this.lvwGuestPrivileges.Items.Add(lvwItem);

					//assign guest's accountprivileges
					//loFolio.Guest.AccountPrivileges.Add(_oPrivilegeHeader);

				}//end foreach

			}//end if
		}

		// >> SHOW PRIVILEGES - COMPANY
		public void showCompanyPrivileges(IList<PrivilegeHeader> pAccountPrivileges)
		{
			//this.grdFolioPrivileges.Rows.Count = 1;
			this.lvwCompanyPrivileges.Items.Clear();

			foreach (PrivilegeHeader _oPrivilegeHeader in pAccountPrivileges)
			{
				int i = this.grdFolioPrivileges.Rows.Count;

				this.grdFolioPrivileges.Rows.Count += _oPrivilegeHeader.PrivilegeDetails.Count;
				foreach (PrivilegeDetail _oPrivilegeDetail in _oPrivilegeHeader.PrivilegeDetails)
				{
					this.grdFolioPrivileges.SetData(i, 0, _oPrivilegeDetail.TransactionCode);
					this.grdFolioPrivileges.SetData(i, 1, _oPrivilegeDetail.Memo);
					this.grdFolioPrivileges.SetData(i, 2, _oPrivilegeDetail.Basis);
					this.grdFolioPrivileges.SetData(i, 3, _oPrivilegeDetail.PercentOff);
					this.grdFolioPrivileges.SetData(i, 4, _oPrivilegeDetail.AmountOff);

					i++;
				}

				//add to Listview
				ListViewItem lvwItem = new ListViewItem(_oPrivilegeHeader.PrivilegeID);
				this.lvwCompanyPrivileges.Items.Add(lvwItem);

			}
		}

		private void displayGuestAccountInformation(string pAccountId)
		{
			try
			{
				Guest _oGuest = new Guest();

				DataTable tempGuestTable = loGuestFacade.getGuestRecordAsDataTableByAccountID(pAccountId);
				DataRow _dRow = tempGuestTable.Rows[0];
				
				//foreach (DataRow _dRow in loGuests.Rows)
				//{

				//    string accountID = _dRow["AccountID"].ToString();

				//    if (accountID == pAccountId)
				//    {
						

						_oGuest.AccountId = _dRow["AccountId"].ToString();
						_oGuest.AccountName = _dRow["AccountName"].ToString();
						_oGuest.Title = _dRow["Title"].ToString();
						_oGuest.LastName = _dRow["LastName"].ToString();
						_oGuest.FirstName = _dRow["FirstName"].ToString();
						_oGuest.MiddleName = _dRow["MiddleName"].ToString();
						_oGuest.Sex = _dRow["Sex"].ToString();
						_oGuest.Citizenship = _dRow["Citizenship"].ToString();
						_oGuest.PassportId = _dRow["PassportId"].ToString();
						_oGuest.GuestImage = _dRow["GuestImage"].ToString();
						_oGuest.TelephoneNo = _dRow["TelephoneNo"].ToString();
						_oGuest.MobileNo = _dRow["MobileNo"].ToString();
						_oGuest.FaxNo = _dRow["FaxNo"].ToString();
						_oGuest.Street = _dRow["Street"].ToString();
						_oGuest.City = _dRow["City"].ToString();
						_oGuest.Country = _dRow["Country"].ToString();
						_oGuest.Zip = _dRow["Zip"].ToString();
						_oGuest.EmailAddress = _dRow["EmailAddress"].ToString();
						_oGuest.Memo = _dRow["Memo"].ToString();
						_oGuest.Concierge = _dRow["Concierge"].ToString();
						_oGuest.Remark = _dRow["Remark"].ToString();
						_oGuest.NoOfVisits = int.Parse(_dRow["NoOfVisits"].ToString());
						_oGuest.HotelID = int.Parse(_dRow["HotelID"].ToString());
						_oGuest.CreateTime = DateTime.Parse(_dRow["CreateTime"].ToString());
						_oGuest.CreatedBy = _dRow["CreatedBy"].ToString();
						_oGuest.UpdateTime = DateTime.Parse(_dRow["UpdateTime"].ToString());
						_oGuest.UpdatedBy = _dRow["UpdatedBy"].ToString();
						_oGuest.TaxExempted = int.Parse(_dRow["taxExempted"].ToString());

						loGuestFacade.getAccountPrivileges(_oGuest.AccountId, ref _oGuest);

						_oGuest.BIRTH_DATE = DateTime.Parse(_dRow["BIRTH_DATE"].ToString());
						_oGuest.ACCOUNT_TYPE = _dRow["ACCOUNT_TYPE"].ToString();
						_oGuest.CARD_NO = _dRow["Card_No"].ToString();
						_oGuest.THRESHOLD_VALUE = double.Parse(_dRow["THRESHOLD_VALUE"].ToString());
						_oGuest.TOTAL_SALES_CONTRIBUTION = double.Parse(_dRow["TOTAL_SALES_CONTRIBUTION"].ToString());
						_oGuest.CreditCardType = _dRow["CreditCardType"].ToString();
						_oGuest.CreditCardNo = _dRow["CreditCardNo"].ToString();

						_oGuest.CreditCardExpiry = _dRow["CreditCardExpiry"].ToString();


				//        break;
				//    }
				//}

				//DataView _dtView = loGuests.DefaultView;

				//_dtView.RowStateFilter = DataViewRowState.OriginalRows;
				//_dtView.RowFilter = "AccountId = '" + pAccountId + "'";

				//DataRowView _dRow = _dtView[0];


				//Guest _oGuest = new Guest();


				//_oGuest.AccountId = _dRow["AccountId"].ToString();
				//_oGuest.AccountName = _dRow["AccountName"].ToString();
				//_oGuest.Title = _dRow["Title"].ToString();
				//_oGuest.LastName = _dRow["LastName"].ToString();
				//_oGuest.FirstName = _dRow["FirstName"].ToString();
				//_oGuest.MiddleName = _dRow["MiddleName"].ToString();
				//_oGuest.Sex = _dRow["Sex"].ToString();
				//_oGuest.Citizenship = _dRow["Citizenship"].ToString();
				//_oGuest.PassportId = _dRow["PassportId"].ToString();
				//_oGuest.GuestImage = _dRow["GuestImage"].ToString();
				//_oGuest.TelephoneNo = _dRow["TelephoneNo"].ToString();
				//_oGuest.MobileNo = _dRow["MobileNo"].ToString();
				//_oGuest.FaxNo = _dRow["FaxNo"].ToString();
				//_oGuest.Street = _dRow["Street"].ToString();
				//_oGuest.City = _dRow["City"].ToString();
				//_oGuest.Country = _dRow["Country"].ToString();
				//_oGuest.Zip = _dRow["Zip"].ToString();
				//_oGuest.EmailAddress = _dRow["EmailAddress"].ToString();
				//_oGuest.Memo = _dRow["Memo"].ToString();
				//_oGuest.Concierge = _dRow["Concierge"].ToString();
				//_oGuest.Remark = _dRow["Remark"].ToString();
				//_oGuest.NoOfVisits = int.Parse(_dRow["NoOfVisits"].ToString());
				//_oGuest.HotelID = int.Parse(_dRow["HotelID"].ToString());
				//_oGuest.CreateTime = DateTime.Parse(_dRow["CreateTime"].ToString());
				//_oGuest.CreatedBy = _dRow["CreatedBy"].ToString();
				//_oGuest.UpdateTime = DateTime.Parse(_dRow["UpdateTime"].ToString());
				//_oGuest.UpdatedBy = _dRow["UpdatedBy"].ToString();
				//_oGuest.TaxExempted = int.Parse(_dRow["taxExempted"].ToString());

				//loGuestFacade.getAccountPrivileges(_oGuest.AccountId, ref _oGuest);

				//_oGuest.BIRTH_DATE = DateTime.Parse(_dRow["BIRTH_DATE"].ToString());
				//_oGuest.ACCOUNT_TYPE = _dRow["ACCOUNT_TYPE"].ToString();
				//_oGuest.CARD_NO = _dRow["Card_No"].ToString();
				//_oGuest.THRESHOLD_VALUE = double.Parse(_dRow["THRESHOLD_VALUE"].ToString());
				//_oGuest.TOTAL_SALES_CONTRIBUTION = double.Parse(_dRow["TOTAL_SALES_CONTRIBUTION"].ToString());
				//_oGuest.CreditCardType = _dRow["CreditCardType"].ToString();
				//_oGuest.CreditCardNo = _dRow["CreditCardNo"].ToString();

				//_oGuest.CreditCardExpiry = _dRow["CreditCardExpiry"].ToString();


				//foreach (Guest _oGuest in loGuestList)
				//{
				//    if (_oGuest.AccountId == pAccountId)
				//    {

				//this.txtAccountID.Text = _oGuest.AccountId;// = _dRow["AccountId"].ToString();
				this.txtAccountName.Text = _oGuest.AccountName;
				this.cboTitle.Text = _oGuest.Title;
				this.txtLastName.Text = _oGuest.LastName;
				this.txtFirstName.Text = _oGuest.FirstName;
				//this.txtMiddleName.Text = _oGuest.MiddleName;
				this.cboSex.Text = _oGuest.Sex;
				this.txtCitizenship.Text = _oGuest.Citizenship;
				this.txtPassportid.Text = _oGuest.PassportId;
				this.txtGuestImage.Text = _oGuest.GuestImage;
				this.txtTelephoneNo.Text = _oGuest.TelephoneNo;
				this.txtMobileNo.Text = _oGuest.MobileNo;
				this.txtFaxNo.Text = _oGuest.FaxNo;
				this.txtStreet.Text = _oGuest.Street;
				this.txtCity.Text = _oGuest.City;
				this.txtCountry.Text = _oGuest.Country;
				this.txtzip.Text = _oGuest.Zip;
				this.txtEmailAddress.Text = _oGuest.EmailAddress;
				this.txtGuestRemarks.Text = _oGuest.Remark;
				this.txtConcierge.Text = _oGuest.Concierge;
				this.txtGuestMemo.Text = _oGuest.Memo;
				this.txtNoOfVisits.Text = _oGuest.NoOfVisits.ToString();
				this.dtpBirth_Date.Value = _oGuest.BIRTH_DATE;
				this.txtAccount_Type.Text = _oGuest.ACCOUNT_TYPE;
				this.txtCreditCardNo.Text = _oGuest.CreditCardNo;
				//_oGuest.THRESHOLD_VALUE = double.Parse(_dRow["THRESHOLD_VALUE"].ToString());
				this.txtTotal_Sales_Contribution.Text = _oGuest.TOTAL_SALES_CONTRIBUTION.ToString("N");
				this.txtCreditCardType.Text = _oGuest.CreditCardType;
				if (_oGuest.TaxExempted == 1)
					this.chkTaxExempted.Checked = true;
				else
					this.chkTaxExempted.Checked = false;


				this.txtCard_No.Text = _oGuest.CARD_NO;
				this.txtCreateTime.Text = _oGuest.CreateTime.ToString("dd-MMM-yyyy hh:mm");

				try
				{
					this.dtpCreditCardExpiry.Value = DateTime.Parse(_oGuest.CreditCardExpiry);
				}
				catch
				{
					this.dtpCreditCardExpiry.Value = this.dtpCreditCardExpiry.MinDate;
				}

				showGuestPrivileges(_oGuest.AccountPrivileges);

				loFolio.Guest = _oGuest;



				// Pops-up if Guest is an affiliate card holder
				if (_oGuest.CARD_NO.Trim().Length > 0)
				{
					if (lOperationMode == ReservationOperationMode.QuickReservation ||
						lOperationMode == ReservationOperationMode.NewGuestReservation)
					{
						this.lvwBrowseGuestName.Visible = false;
						MessageBox.Show("Guest is an affiliate card holder.\r\n\r\nThis message is intended to prevent taxi driver Paid-out.\r\n", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
					}
				}


				//return;
				//    }
				//}
			}
			catch { }
		}

		private void displayCompanyAccountInformation(string pCompanyId)
		{

			try
			{
                if (pCompanyId.StartsWith("G"))
                {
                    Company _oCompany = new Company();

                    DataTable tempTable = loCompanyFacade.getCompanyAsDataTableByCompanyID(pCompanyId);
                    DataRow _dRow = tempTable.Rows[0];

                    _oCompany.CompanyId = pCompanyId;
                    //_oCompany.CompanyId = pCompanyId;
                    //_oCompany.CompanyName = _dRow["CompanyName"].ToString();

                    _oCompany.AccountPrivileges = loCompanyFacade.getAccountPrivileges(pCompanyId);

                    this.lvwCompanyPrivileges.Items.Clear();
                    foreach (PrivilegeHeader _oPrivilege in _oCompany.AccountPrivileges)
                    {
                        this.lvwCompanyPrivileges.Items.Add(_oPrivilege.PrivilegeID);
                    }

                    this.txtCompanyName.Text = _dRow["CompanyName"].ToString();
                    this.loFolio.Company = _oCompany;
                }
                else
                {
                    Guest _oGuest = new Guest();
                    _oGuest = loGuestFacade.getGuestRecord(pCompanyId);
                    this.txtCompanyName.Text = _oGuest.LastName + ", " + _oGuest.FirstName;
                }
			}
			catch { }
		}

		private void loadFolioInformation()
		{
			this.Text = "Folio : " + loFolio.FolioID;
			this.cboFolioType.Text = loFolio.FolioType;
			this.txtStatus.Text = loFolio.Status;
			this.cboSource.Text = loFolio.Source;

			if (loFolio.AccountID == null)
			{
				this.txtAccountID.Text = "I-9999999999";
			}
			else
			{
				this.txtAccountID.Text = loFolio.AccountID;
			}
			//this.txtGuestImage.Text = loFolio.Guest.GuestImage;

			this.txtFromDate.Text = string.Format(GlobalVariables.gDateFormat, loFolio.FromDate);
			this.txtToDate.Text = string.Format(GlobalVariables.gDateFormat, loFolio.Todate);

			this.dtpFromDate.Text = loFolio.ArrivalDate.ToString("dd-MMM-yyyy");
			this.dtpDepartureDate.Text = loFolio.DepartureDate.ToString("dd-MMM-yyyy");
			this.dtpArrivalTime.Value = loFolio.ArrivalDate;
			this.dtpDepartureTime.Value = loFolio.DepartureDate;

			try
			{
                this.dtpFolioETA.Value = DateTime.Parse(loFolio.FolioETA);
			}
            catch
            {
                this.dtpFolioETA.Value = DateTime.Parse("02:00:00 PM");
            }
			try
			{
                this.dtpFolioETD.Value = DateTime.Parse(loFolio.FolioETD);
			}
            catch
            {
                this.dtpFolioETD.Value = DateTime.Parse("12:00:00 PM");
            }

			this.cboAccountType.Text = loFolio.AccountType;
			this.cboPayment_Mode.Text = loFolio.Payment_Mode;
			this.cboPurpose.Text = loFolio.Purpose;

			this.cboSales_Executive.Text = loFolio.Sales_Executive;
			this.txtCreatedBy.Text = loFolio.CreatedBy;
            this.txtUpdatedby.Text = loFolio.UpdatedBy;

			this.txtCompanyId.Text = loFolio.CompanyID;
			this.txtAgentId.Text = loFolio.AgentID;

            try
            {
                Agent _oAgent = new Agent();
                AgentFacade _oAgentFacade = new AgentFacade();
                _oAgent = _oAgentFacade.getAgentInfo(int.Parse(loFolio.AgentID));
                this.txtAgentName.Text = _oAgent.Agency;
            }
            catch { }

			this.nudNoOfAdults.Value = loFolio.NoofAdults;
			this.nudNoOfChild.Value = loFolio.NoOfChild;
            this.txtRemarks.Text = loFolio.Remarks;

			loadFolioSchedule();
			loadFolioRouting(); // billing instructions
			loadFolioRecurringCharges();
			loadFolioPrivileges();
			loadFolioPackage();
			loadJoinerFolios();
            loadFolioInclusions();
		}

		private void loadFolioSchedule()
		{
			// load folio schedules
			this.grdFolioSchedule.RowColChange -= new System.EventHandler(this.grdFolioSchedule_RowColChange);

			this.grdFolioSchedule.Rows.Count = loFolio.Schedule.Count + 1;
			int i = 1;
			foreach (Schedule _oSchedule in loFolio.Schedule)
			{

				this.grdFolioSchedule.SetData(i, 0, _oSchedule.RoomID);
				this.grdFolioSchedule.SetData(i, 1, _oSchedule.RoomType);
				this.grdFolioSchedule.SetData(i, 2, _oSchedule.FromDate);
				this.grdFolioSchedule.SetData(i, 3, _oSchedule.ToDate);
				this.grdFolioSchedule.SetData(i, 4, _oSchedule.Days);
				this.grdFolioSchedule.SetData(i, 5, _oSchedule.RateType);
				this.grdFolioSchedule.SetData(i, 6, _oSchedule.Rate);

				decimal _total = _oSchedule.Days * _oSchedule.Rate;
				this.grdFolioSchedule.SetData(i, 7, _total.ToString("N"));
				this.grdFolioSchedule.SetData(i, 8, _oSchedule.BreakFast);

                //this.grdFolioSchedule.SetData(i, 9, _oSchedule.HasTransfered);


				i++;
			}

			computeTotalRoomRateAndDays();
			//this.grdFolioSchedule.RowColChange += new System.EventHandler(this.grdFolioSchedule_RowColChange);
			// to update days and amount
			//this.grdFolioSchedule_RowColChange(this, new EventArgs());

		}

		private void loadFolioRouting()
		{
			foreach (FolioRouting _oFolioRouting in loFolio.FolioRouting)
			{
				for (int i = 1; i < this.grdBITransactionCodes.Rows.Count; i++)
				{
					string _code = this.grdBITransactionCodes.GetDataDisplay(i, 0);

					if (_code == _oFolioRouting.TransactionCode)
					{
						this.grdBITransactionCodes.SetCellStyle(i, 0, "AddedRouting");
						this.grdBITransactionCodes.SetCellStyle(i, 1, "AddedRouting");

					}
				}
			}
		}

		private void loadFolioRecurringCharges()
		{
			this.grdRecurringCharges.Rows.Count = loFolio.RecurringCharges.Count + 1;
			int i = 1;
			foreach (RecurringCharge _oRecurringCharge in loFolio.RecurringCharges)
			{
				this.grdRecurringCharges.SetData(i, 0, _oRecurringCharge.TransactionCode);
				this.grdRecurringCharges.SetData(i, 1, _oRecurringCharge.Memo);
				this.grdRecurringCharges.SetData(i, 2, _oRecurringCharge.Amount.ToString("N"));
				this.grdRecurringCharges.SetData(i, 3, _oRecurringCharge.FromDate);
				this.grdRecurringCharges.SetData(i, 4, _oRecurringCharge.ToDate);
                this.grdRecurringCharges.SetData(i, 5, _oRecurringCharge.SubAccount);
				i++;
			}
		}

		private void loadFolioPrivileges()
		{
			this.grdFolioPrivileges.Rows.Count = loFolio.Privileges.Count + 1;
			int i = 1;

			foreach (Privilege _oPrivilege in loFolio.Privileges)
			{
				this.grdFolioPrivileges.SetData(i, 0, _oPrivilege.TransactionCode);
				this.grdFolioPrivileges.SetData(i, 1, _oPrivilege.Memo);
				this.grdFolioPrivileges.SetData(i, 2, _oPrivilege.Basis);
				if (_oPrivilege.Percentoff < 1)
					this.grdFolioPrivileges.SetData(i, 3, _oPrivilege.Percentoff * 100);
				else
					this.grdFolioPrivileges.SetData(i, 3, _oPrivilege.Percentoff);
				this.grdFolioPrivileges.SetData(i, 4, _oPrivilege.AmountOff.ToString("N"));

				i++;
			}

		}

		private void loadFolioPackage()
		{

			this.grdFolioPackage.Rows.Count = loFolio.Package.Count + 1;
			int i = 1;
			foreach (FolioPackage _oFolioPackage in loFolio.Package)
			{
				this.grdFolioPackage.SetData(i, 0, _oFolioPackage.TransactionCode);
				this.grdFolioPackage.SetData(i, 1, _oFolioPackage.Memo);
				this.grdFolioPackage.SetData(i, 2, _oFolioPackage.Basis);
				if (_oFolioPackage.PercentOff >= 1)
					this.grdFolioPackage.SetData(i, 3, _oFolioPackage.PercentOff);
				else
					this.grdFolioPackage.SetData(i, 3, _oFolioPackage.PercentOff * 100);
				this.grdFolioPackage.SetData(i, 4, _oFolioPackage.AmountOff);
                dtpPackageDateFrom.Value = _oFolioPackage.DateFrom;
                dtpPackageDateTo.Value = _oFolioPackage.DateTo;

				i++;
			}
		}

		private void loadJoinerFolios()
		{
			this.grdDependentGuests.Rows.Count = loFolio.JoinerFolios.Count + 1;
			int i = 1;

			foreach (Folio _oJoinerFolio in loFolio.JoinerFolios)
			{
				this.grdDependentGuests.SetData(i, 0, i);
				this.grdDependentGuests.SetData(i, 1, _oJoinerFolio.Guest.AccountId);
				this.grdDependentGuests.SetData(i, 2, _oJoinerFolio.Guest.LastName);
				this.grdDependentGuests.SetData(i, 3, _oJoinerFolio.Guest.FirstName);
				this.grdDependentGuests.SetData(i, 4, _oJoinerFolio.Guest.Citizenship);
				this.grdDependentGuests.SetData(i, 5, _oJoinerFolio.Guest.PassportId);
				this.grdDependentGuests.SetData(i, 6, _oJoinerFolio.Guest.Street + ", " + _oJoinerFolio.Guest.City);

				this.grdDependentGuests.SetData(i, 7, _oJoinerFolio.FolioID);
                this.grdDependentGuests.SetData(i, 8, _oJoinerFolio.ArrivalDate);
				this.grdDependentGuests.SetData(i, 9, _oJoinerFolio.Remarks);

				i++;
			}
		}

		/// <summary>
		/// Updates Current Room Status on Main Form(MDIMain)
		/// </summary>
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
			catch { }

		}

		private void setUIMode(UIMode pUIMode)
		{
			this.lUIMode = pUIMode;
		}

		private void updateGuestInformation()
		{
			// create new guest account
			loGuestFacade = new GuestFacade();
			Guest _newGuest = new Guest();

			_newGuest.AccountId = this.txtAccountID.Text;
			_newGuest.AccountName = this.txtLastName.Text + "_" + this.txtFirstName.Text;
			_newGuest.Title = this.cboTitle.Text;
			_newGuest.LastName = this.txtLastName.Text;
			_newGuest.FirstName = this.txtFirstName.Text;
			_newGuest.MiddleName = loFolio.Guest.MiddleName;
			_newGuest.Sex = this.cboSex.Text;
			_newGuest.Citizenship = this.txtCitizenship.Text;

			if (_newGuest.Citizenship.Trim().Length <= 0)
			{
				this.txtCitizenship.Focus();
				throw (new Exception("Please input guest's citizenship."));
			}

			_newGuest.PassportId = this.txtPassportid.Text;
			_newGuest.GuestImage = this.txtGuestImage.Text;
			_newGuest.TelephoneNo = this.txtTelephoneNo.Text;
			_newGuest.MobileNo = this.txtMobileNo.Text;
			_newGuest.FaxNo = this.txtFaxNo.Text;
			_newGuest.Street = this.txtStreet.Text;
			_newGuest.City = this.txtCity.Text;
			_newGuest.Country = this.txtCountry.Text;
			_newGuest.Zip = this.txtzip.Text;
			_newGuest.EmailAddress = this.txtEmailAddress.Text;

			_newGuest.Remark = this.txtGuestRemarks.Text;
			_newGuest.Concierge = this.txtConcierge.Text;
			_newGuest.Memo = this.txtGuestMemo.Text;
			_newGuest.BIRTH_DATE = this.dtpBirth_Date.Value;

			_newGuest.NoOfVisits = 0;
			_newGuest.TOTAL_SALES_CONTRIBUTION = 0;

			_newGuest.HotelID = GlobalVariables.gHotelId;
			_newGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
			_newGuest.UpdatedBy = GlobalVariables.gLoggedOnUser;

			_newGuest.ACCOUNT_TYPE = this.txtAccount_Type.Text;
			_newGuest.CARD_NO = this.txtCard_No.Text;
			_newGuest.THRESHOLD_VALUE = double.Parse(ConfigVariables.gDefaultGuestThresholdValue);

			_newGuest.CreditCardNo = this.txtCreditCardNo.Text;
			_newGuest.CreditCardType = this.txtCreditCardType.Text;
			_newGuest.CreditCardExpiry = this.dtpCreditCardExpiry.Text;
			_newGuest.TaxExempted = this.chkTaxExempted.Checked ? 1 : 0;
			_newGuest.AccountPrivileges = loFolio.Guest.AccountPrivileges;

			loGuestFacade.updateGuest(ref _newGuest);

			this.loFolio.Guest = _newGuest;
		}

		public void loadCalendarUI(string pFolioID, string pMode, C1FlexGrid pGrdFolioSchedule, string pRoomType, DateTime pStartDate, int pNoOfWeeks)
		{
			lRoomCalendarUI = new RoomCalendarUI(pFolioID, pMode, pGrdFolioSchedule, pRoomType, pStartDate, pNoOfWeeks, this);
			lRoomCalendarUI.MdiParent = this.MdiParent;

			lRoomCalendarUI.Top = 0;
			lRoomCalendarUI.Left = 0;

			lRoomCalendarUI.Show();

		}

		/// <summary>
		/// Check roomevents conflict
		/// </summary>
		/// <returns>1 if Conflict, -1 for OK</returns>
		private int hasRoomEventConflict()
		{
			foreach (Schedule _oSchedule in loFolio.Schedule)
			{
				RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

				int ctr = 0;
				//check conflict for roomevents
				DateTime dateStart = _oSchedule.FromDate;
				DateTime dateEnd = _oSchedule.ToDate;

				int _dateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dateStart, dateEnd);

				for (int d = 0; d <= _dateDiff; d++)
				{
					string roomid = _oSchedule.RoomID;

					string EventDate;
					EventDate = string.Format("{0:yyyy-MM-dd}", dateStart.AddDays(ctr));
					int eventNo = 0;

					string lastRoomEventDate = string.Format("{0:yyyy-MM-dd}", dateEnd);
					if (loFolio.MasterFolio != null && loFolio.MasterFolio != "" && (loFolio.FolioType != "DEPENDENT"))
					{
						eventNo = _oRoomEventFacade.CheckConflict(roomid, EventDate, lastRoomEventDate, loFolio.FolioID);
					}
                    else if (loFolio.FolioType != "DEPENDENT" && (lOperationMode == ReservationOperationMode.NewGuestReservation || lOperationMode == ReservationOperationMode.NewChildFolio))
                    {
                        eventNo = _oRoomEventFacade.CheckConflict(roomid, EventDate, lastRoomEventDate, loFolio.FolioID);
                    }
                    else if ((loFolio.FolioType == "DEPENDENT" || loFolio.FolioType != "DEPENDENT") && (lOperationMode != ReservationOperationMode.NewGuestReservation && lOperationMode != ReservationOperationMode.NewChildFolio))
                    {
                        eventNo = _oRoomEventFacade.CheckConflict(roomid, EventDate, lastRoomEventDate, loFolio.FolioID);
                    }
                    else if (loFolio.MasterFolio != null && loFolio.MasterFolio != "" && (loFolio.FolioType == "DEPENDENT"))
                    {
                        eventNo = _oRoomEventFacade.CheckConflict(roomid, EventDate, lastRoomEventDate, loFolio.MasterFolio);
                    }
                    else
                    {
                        eventNo = _oRoomEventFacade.CheckConflict(roomid, EventDate, lastRoomEventDate, loFolio.MasterFolio);
                    }
					if (eventNo != 0)
					{
						return 1;
					}
					ctr++;
				}
			}
			//}
			return -1;
		}

        private void loadInclusions()
        {
            char[] _separator = { ',' };
            string[] fieldName = ConfigVariables.gFilteredHeadersForFolioInclusions.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            string[] dropDownValues = { "" };
            GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

            foreach (string _field in fieldName)
            {
                dropDownValues = oGroupBookingFacade.getByFieldName(_field.Replace(" ", ""));
                foreach (string str in dropDownValues)
                {
                    grdInclusions.AddItem(str);
                }
            }
        }

        private void loadRoomInclusionsOfGroups()
        {
            string pFilter = ConfigVariables.gRoomInclusionHeader;

            EventRequirementsFacade _oEventRequirementsFacade = new EventRequirementsFacade();
            GenericList<EventRequirements> _oEventRequirements = _oEventRequirementsFacade.getEventRequirements(loFolio.MasterFolio);

            _oEventRequirements.FindAll(delegate(EventRequirements _oRequirements) { return _oRequirements.RequirementCode.Equals(pFilter); });
            foreach (EventRequirements _requirements in _oEventRequirements)
            {
                grdFolioInclusions.AddItem(_requirements.Description);
            }
            _oEventRequirements = _oEventRequirementsFacade.getEventRequirements(loFolio.MasterFolio);
        }

		private void loadHotelPackages()
		{
            this.grdHotelPromos.Rows.Count = 1;
            DateTime _dateFrom;
            DateTime _dateTo;
            loPackageFacade = new PackageFacade();
            if (loPackages != null)
                loPackages.Clear();

            if (grdFolioSchedule.Rows.Count > 1)
            {
                try
                {
                    _dateFrom = DateTime.Parse(grdFolioSchedule.GetDataDisplay(1, 2));
                    _dateTo = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));

                    loPackages = loPackageFacade.getApplicablePackages(_dateFrom.ToString("yyyy-MM-dd"), _dateTo.ToString("yyyy-MM-dd"));
                }
                catch
                {
                    loPackages = loPackageFacade.getApplicablePackages();
                }
            }
            else
            {
                loPackages = loPackageFacade.getApplicablePackages();
            }

			int i = this.grdHotelPromos.Rows.Count;
			foreach (PackageHeader _PackageHeader in loPackages)
			{
				this.grdHotelPromos.Rows.Count += 1;

				this.grdHotelPromos.SetData(i, 0, _PackageHeader.PackageID);
				this.grdHotelPromos.SetData(i, 1, _PackageHeader.Description);
				this.grdHotelPromos.SetData(i, 2, _PackageHeader.FromDate);
				this.grdHotelPromos.SetData(i, 3, _PackageHeader.ToDate);

				i++;
			}
		}


		private void loadSalesExecutives()
		{
			loSalesExecutive = new List<User>();
			IList<User> _oUserList = new List<User>();

			loUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
			_oUserList = loUserFacade.getUsersList();

			foreach (User _oUser in _oUserList)
			{
				if (_oUser.Department == "100-SALES & MARKETING")
				{
					loSalesExecutive.Add(_oUser);
				}
			}

			this.cboSales_Executive.DataSource = loSalesExecutive;
			this.cboSales_Executive.DisplayMember = "UserId";
		}


		private void addAccountTypesForGroup()
		{
			this.cboAccountType.Items.Add("STUDENT");
			this.cboAccountType.Items.Add("SEMINAR");
			this.cboAccountType.Items.Add("GOVERNMENT");
			this.cboAccountType.Items.Add("TOURS");
		}


		#endregion

		#region "EVENTS"

		// add recurring charges
		private void btnAddRecurringCharge_Click(object sender, EventArgs e)
		{
			string currentTranCodes = "";

			for (int i = 1; i < this.grdRecurringCharges.Rows.Count; i++)
			{
				currentTranCodes += this.grdRecurringCharges.GetData(i, 0).ToString() + ",";
			}

			string addCond = "";
			if (currentTranCodes != "")
			{
				currentTranCodes = currentTranCodes.Substring(0, currentTranCodes.Length - 1);
				addCond = "and trancode not in (" + currentTranCodes + ")";
			}

			string whereCondition = "acctside = 'DEBIT' and trancode <> '3300' " + addCond;

			DateTime _fromDate = DateTime.Parse(this.txtFromDate.Text);
			DateTime _toDate = DateTime.Parse(this.txtToDate.Text);
			BrowseTransactionCodesUI transactionCodeUI = new BrowseTransactionCodesUI(ref grdRecurringCharges, whereCondition, _fromDate, _toDate);
			transactionCodeUI.ShowDialog();
		}

		private void grdRecurringCharges_Click(object sender, EventArgs e)
		{
			if (this.grdRecurringCharges.Col > 0 && this.grdRecurringCharges.Row > 0)
			{
				this.grdRecurringCharges.StartEditing(this.grdRecurringCharges.Row, this.grdRecurringCharges.Col);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		bool isFormLoaded = false;
		private void ReservationFolioUI_Load(object sender, EventArgs e)
		{
			this.Top = 0;
			this.Left = 0;
            
			this.dtpAutoFromDate.Value = lAuditDate;
			this.dtpAutoToDate.Value = lAuditDate.AddDays(1);

			// update Billing Instruction Tab
			grdBITransactionCodes_RowColChange(sender, e);
            grdDependentGuests.AutoSizeRows();

            //check whether auto rooming is enabled
            if (ConfigVariables.gAutoRoomingEnabled == "0")
            {
                rdAutoRoom.Enabled = false;
            }
            else
            {
                rdAutoRoom.Enabled = true;
            }

			switch (this.lOperationMode)
			{
				case ReservationOperationMode.ViewFolioFromCalendar:
				case ReservationOperationMode.ViewFolioInformation:
				case ReservationOperationMode.ViewChildFolio:
					// to avoid showing guest & company lookup
					this.lvwBrowseCompany.Visible = false;
					this.lvwBrowseGuestName.Visible = false;

					// to update folio routing grid
					grdFolioSchedule_Click(sender, e);

					loControlListener.Listen(this);

					break;
				case ReservationOperationMode.NewChildFolio:
					// to avoid showing guest & company lookup
					this.lvwBrowseCompany.Visible = false;
					this.lvwBrowseGuestName.Visible = false;

					// to update folio routing grid
					grdFolioSchedule_Click(sender, e);
					break;

				default:
					break;
			}


			isFormLoaded = true;
            loadHotelPackages();

            if (cboFolioType.Text == "DEPENDENT")
            {
                txtCompanyName.ReadOnly = true;
                btnBrowseCompany.Enabled = false;
            }
        }

		private void rdoApplyGuestPrivilege_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoApplyGuestPrivilege.Checked)
			{
				if (loFolio.Guest != null)
				{
					showGuestPrivileges(loFolio.Guest.AccountPrivileges);
				}

			}
			else
			{
				removeAccountPrivileges();
			}
		}

		private void btnGuestPrivilege_Add_Click(object sender, EventArgs e)
		{
			string currentTranCodes = "";
			// gets current transaction codes for it to be excluded 
			// in Browse Transaction Codes List
			// jrom, april 26, 2008
			for (int i = 1; i < this.grdFolioPrivileges.Rows.Count; i++)
			{
				currentTranCodes += this.grdFolioPrivileges.GetData(i, 0) + ",";
			}

			string addCond = "";
			if (currentTranCodes != "")
			{
				currentTranCodes = currentTranCodes.Substring(0, currentTranCodes.Length - 1);
				addCond = "and trancode not in (" + currentTranCodes + ")";
			}

			string whereCondition = "acctside = 'DEBIT' and trancode <> '3300' " + addCond;

			BrowseTransactionCodesUI transactionCodeUI = new BrowseTransactionCodesUI(ref grdFolioPrivileges, whereCondition, DateTime.Now, DateTime.Now);
			transactionCodeUI.ShowDialog();
		}

		private void grdBITransactionCodes_RowColChange(object sender, EventArgs e)
		{
			int row = this.grdBITransactionCodes.Row;

			this.txtBICode.Text = this.grdBITransactionCodes.GetDataDisplay(row, 0);
			this.txtBIMemo.Text = this.grdBITransactionCodes.GetDataDisplay(row, 1);

			// SUB FOLIO [A,B,C,D]
			this.grdBillingInstruction.SetData(1, 0, "A - Personal");
			this.grdBillingInstruction.SetData(2, 0, "B - Company");
			this.grdBillingInstruction.SetData(3, 0, "C - Others");
			this.grdBillingInstruction.SetData(4, 0, "D - Others");

			// PERCENT
			this.grdBillingInstruction.SetData(1, 1, "0.00");
			this.grdBillingInstruction.SetData(2, 1, "0.00");
			this.grdBillingInstruction.SetData(3, 1, "0.00");
			this.grdBillingInstruction.SetData(4, 1, "0.00");

			// AMOUNT
			this.grdBillingInstruction.SetData(1, 2, "0.00");
			this.grdBillingInstruction.SetData(2, 2, "0.00");
			this.grdBillingInstruction.SetData(3, 2, "0.00");
			this.grdBillingInstruction.SetData(4, 2, "0.00");

			// look up in current Billing Instruction
			foreach (FolioRouting _oFolioRouting in loFolio.FolioRouting)
			{
				if (_oFolioRouting.TransactionCode == this.txtBICode.Text)
				{
					switch (_oFolioRouting.SubFolio)
					{
						case "A":
							this.grdBillingInstruction.SetData(1, 1, _oFolioRouting.PercentCharged);
							this.grdBillingInstruction.SetData(1, 2, _oFolioRouting.AmountCharged);
							break;
						case "B":
							this.grdBillingInstruction.SetData(2, 1, _oFolioRouting.PercentCharged);
							this.grdBillingInstruction.SetData(2, 2, _oFolioRouting.AmountCharged);
							break;
						case "C":
							this.grdBillingInstruction.SetData(3, 1, _oFolioRouting.PercentCharged);
							this.grdBillingInstruction.SetData(3, 2, _oFolioRouting.AmountCharged);
							break;
						case "D":
							this.grdBillingInstruction.SetData(4, 1, _oFolioRouting.PercentCharged);
							this.grdBillingInstruction.SetData(4, 2, _oFolioRouting.AmountCharged);
							break;
					}
				}
			}
		}

		// save Billing Instruction to current folio
		private void btnAddBillingInstruction_Click(object sender, EventArgs e)
		{

			string _basis = this.rdoBIPercent.Checked ? "P" : "A";

			switch (_basis)
			{
				case "P": // percent
					if (!isBIPercentageCorrect())
					{
						MessageBox.Show("Invalid percentage total in Billing Instruction.\r\n\r\nTotal should be One hundred percent(100 %).", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
						return;
					}
					break;
				case "A": // amount
					if (!isBIAmountCorrect())
					{
						MessageBox.Show("Invalid amount total in Billing Instruction.\r\n\r\nTotal amount should be greater than zero.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
						return;
					}
					break;
				default:
					// do nothing
					break;
			}

			createNewFolioBillingInstruction(_basis);

		}

		// remove Billing Instruction
		private void btnRemoveBillingInstruction_Click(object sender, EventArgs e)
		{

			if (loFolio.FolioRouting != null)
			{
				DialogResult rsp = MessageBox.Show("Remove billing information?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (rsp == DialogResult.No)
				{
					return;
				}


				FolioRouting[] r = new FolioRouting[loFolio.FolioRouting.Count];
				loFolio.FolioRouting.CopyTo(r, 0);

				foreach (FolioRouting _oFolioRouting in r)
				{
					if (_oFolioRouting.TransactionCode == this.txtBICode.Text)
					{
						loFolio.FolioRouting.Remove(_oFolioRouting);

						int _row = this.grdBITransactionCodes.Row;
						this.grdBITransactionCodes.SetCellStyle(_row, 0, "Normal");
						this.grdBITransactionCodes.SetCellStyle(_row, 1, "Normal");

					}
				}


				try
				{
					this.grdBITransactionCodes.Row += 1;
				}
				catch
				{ }

			}

		}

		private void grdBillingInstruction_RowColChange(object sender, EventArgs e)
		{
			int _col = this.grdBillingInstruction.Col;

			string _basis = rdoBIPercent.Checked ? "PERCENT" : "AMOUNT";

			if (_col > 0)
			{
				if ((_col == 1 && _basis == "PERCENT") ||
					 (_col == 2 && _basis == "AMOUNT"))
				{
					this.grdBillingInstruction.StartEditing(this.grdBillingInstruction.Row, this.grdBillingInstruction.Col);
				}
				else
				{
					this.grdBillingInstruction.AllowEditing = false;
				}
			}
			else
			{
				this.grdBillingInstruction.AllowEditing = false;
			}
		}

		private void rdoBIPercent_CheckedChanged(object sender, EventArgs e)
		{
			grdBITransactionCodes_RowColChange(sender, e);
		}

		private void rdoBIAmount_CheckedChanged(object sender, EventArgs e)
		{
			grdBITransactionCodes_RowColChange(sender, e);
		}

		private void lvwBrowseGuestName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) // 13 = ENTER
			{
				lvwBrowseGuestName_DoubleClick(sender, new EventArgs());
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void grdFolioSchedule_Click(object sender, EventArgs e)
		{
			grdFolioSchedule_RowColChange(sender, e);
			//grdFolioSchedule_AfterEdit(sender, new RowColEventArgs(this.grdFolioSchedule.Row, this.grdFolioSchedule.Col));
		}

		bool lSelectedDifferentRoomType = false;
		public void grdFolioSchedule_AfterEdit(object sender, RowColEventArgs e)
		{
			try
			{
				int _col = e.Col; // this.grdFolioSchedule.Col;
				int _row = e.Row;// this.grdFolioSchedule.Row;

				if (_row < 1)
					return;

				switch (_col)
				{
					case 0: // ROOM NO COLUMN - to change Room Type column
						string _roomNo = grdFolioSchedule.GetData(_row, 0).ToString();//.GetData(e.Row,1).ToString();

						string _oldRoomType = this.grdFolioSchedule.GetDataDisplay(_row, 1);

                        //this.grdFolioSchedule.SetData(_row, 1, "");
						lStringRoomList = "";

						if (_roomNo == "")
							return;

						foreach (Room _oRoom in loRooms)
						{
							if (_oRoom.RoomId == _roomNo)
							{
                                if (_oldRoomType != _oRoom.RoomTypecode)
                                {
                                    if ((cboFolioType.Text == "DEPENDENT" /*|| ConfigVariables.gAutoRoomingEnabled == "0"*/) && grdFolioSchedule.GetDataDisplay(_row, 1) != "" && txtStatus.Text != "ONGOING")
                                    {
                                        MessageBox.Show("Transaction failed.\r\n\r\nCannot change to specified room and room type.", "Transaction failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.grdFolioSchedule.SetData(_row, 0, lOldRoomNumber);
                                        return;
                                    }
                                    else
                                    {
                                        lSelectedDifferentRoomType = true;
                                    }
                                }


								this.grdFolioSchedule.Cols[1].ComboList = null;
								this.grdFolioSchedule.SetData(_row, 1, _oRoom.RoomTypecode);

								// ROOM TYPE
								lStringRateTypeList = "";
								foreach (RateType _oRateType in loRateTypes)
								{
									if (_oRateType.RoomTypeCode == _oRoom.RoomTypecode)
									{
										lStringRateTypeList += _oRateType.RateCode + "|";

										//// only assign rate type if BLANK
										//if (this.grdFolioSchedule.GetDataDisplay(_row, 5) == "")
										if (lSelectedDifferentRoomType)
										{
											lSelectedDifferentRoomType = false;

											this.grdFolioSchedule.SetData(_row, 5, _oRateType.RateCode);
											this.grdFolioSchedule.SetData(_row, 6, _oRateType.RateAmount.ToString("N"));
											this.grdFolioSchedule.SetData(_row, 8, _oRateType.HasBreakfast);
										}
										//else
										//{
										//    this.grdFolioSchedule.StartEditing(_row, 6);
										//}

									}
								}
								this.grdFolioSchedule.Cols[5].ComboList = lStringRateTypeList;

								computeTotalRoomRateAndDays();
								return;
							}
						}

						// if room number not found
						MessageBox.Show("Transaction failed.\r\nRoom No. not found.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
						this.grdFolioSchedule.SetData(_row, 0, "");

						break;

					case 1: // for ROOM TYPE

						string _roomTypeCode = grdFolioSchedule.GetDataDisplay(_row, 1);//.GetData(e.Row,1).ToString();

						lStringRateTypeList = "";
						foreach (RateType _oRateType in loRateTypes)
						{
							if (_oRateType.RoomTypeCode == _roomTypeCode)
							{
								lStringRateTypeList += _oRateType.RateCode + "|";

								if (this.grdFolioSchedule.GetDataDisplay(_row, 5) == "")
								{
									this.grdFolioSchedule.SetData(_row, 5, _oRateType.RateCode);
									this.grdFolioSchedule.SetData(_row, 6, _oRateType.RateAmount.ToString("N"));
									this.grdFolioSchedule.SetData(_row, 8, _oRateType.HasBreakfast);
								}
							}

						}

						this.grdFolioSchedule.Cols[5].ComboList = lStringRateTypeList;
						break;

					case 2: // FROM DATE
					case 3: // TO DATE
						DateTime _fromDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(_row, 2));
						DateTime _toDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(_row, 3));

						long _dateDiff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _fromDate, _toDate);

						this.grdFolioSchedule.SetData(_row, 4, _dateDiff.ToString());

                        DateTime _lastDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));
                        dtpDepartureDate.Text = _lastDate.ToString("dd-MMM-yyyy");
                        txtToDate.Text = _lastDate.ToString("dd-MMM-yyyy");
						//computeTotalRoomRate();

                        loadHotelPackages();
						break;

					case 5: // RATE TYPE
						bool found = false;
						_roomTypeCode = grdFolioSchedule.GetDataDisplay(_row, 1);

						string _rateCode = grdFolioSchedule.GetDataDisplay(_row, 5);

						decimal _rateAmount = 0;
						decimal.TryParse(grdFolioSchedule.GetDataDisplay(_row, 6), out _rateAmount);


						if (_rateCode != "APPLIED")
						{


							foreach (RateType _oRateType in loRateTypes)
							{
								if (_oRateType.RoomTypeCode == _roomTypeCode
									&& _oRateType.RateCode == _rateCode)
								{

									if (_oRateType.RateCode != lOldRateType)
									{
										this.grdFolioSchedule.SetData(_row, 6, _oRateType.RateAmount.ToString("N"));
										this.grdFolioSchedule.SetData(_row, 8, _oRateType.HasBreakfast);
										found = true;
										break;
									}
								}
							}
						}
						else
						{
							if (loEventAppliedRatesList != null)
							{
								foreach (EventAppliedRates _oAppliedRate in loEventAppliedRatesList)
								{
									if (_oAppliedRate.NumberOfOccupants == this.nudNoOfAdults.Value)
									{

										this.grdFolioSchedule.SetData(_row, 6, _oAppliedRate.RateAmount);
                                        //this.grdFolioSchedule.SetData(_row, 8, "Y");
										break;
									}
								}
                                foreach (RateType _oRateType in loRateTypes)
                                {
                                    if (_oRateType.RoomTypeCode == _roomTypeCode
                                        && _oRateType.RateCode == _rateCode)
                                    {

                                        if (_oRateType.RateCode != lOldRateType)
                                        {
                                            this.grdFolioSchedule.SetData(_row, 8, _oRateType.HasBreakfast);
                                            found = true;
                                            break;
                                        }
                                    }
                                }
							}
						}

						break;

						//bool found = false;
						//_roomTypeCode = grdFolioSchedule.GetDataDisplay(_row, 1);
						//string _rateCode = grdFolioSchedule.GetDataDisplay(_row, 5);

						//if (_rateCode != "APPLIED")
						//{
						//    foreach (RateType _oRateType in loRateTypes)
						//    {
						//        if (_oRateType.RoomTypeCode == _roomTypeCode
						//            && _oRateType.RateCode == _rateCode)
						//        {
						//            this.grdFolioSchedule.SetData(_row, 6, _oRateType.RateAmount.ToString("N"));
						//            this.grdFolioSchedule.SetData(_row, 8, _oRateType.HasBreakfast);
						//            found = true;
						//            break;
						//        }
						//    }
						//}
						//else
						//{
						//    if (loEventAppliedRatesList != null)
						//    {
						//        foreach (EventAppliedRates _oAppliedRate in loEventAppliedRatesList)
						//        {
						//            if (_oAppliedRate.NumberOfOccupants == this.nudNoOfAdults.Value)
						//            {

						//                this.grdFolioSchedule.SetData(_row, 6, _oAppliedRate.RateAmount);
						//                this.grdFolioSchedule.SetData(_row, 8, "Y");
						//                break;
						//            }
						//        }
						//    }
						//}

						//break;

                    default:
                        computeTotalRoomRateAndDays();
                        break;

				}//end switch

				computeTotalRoomRateAndDays();

                //>> change package dates after change schedule
                dtpPackageDateFrom.Value = DateTime.Parse(grdFolioSchedule.GetDataDisplay(1, 2));
                dtpPackageDateTo.Value = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));

			}// end try
			catch
			{ }
		}


		private void addScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigVariables.gAutoRoomingEnabled == "0")
            {
                grdFolioSchedule.Cols[0].AllowEditing = false;
                grdFolioSchedule.Cols[1].AllowEditing = false;
            }
            else
            {
                grdFolioSchedule.Cols[0].AllowEditing = true;
                grdFolioSchedule.Cols[1].AllowEditing = true;
            }

            if (lUIMode != UIMode.Add)
            {
                this.Text = "Folio : " + loFolio.FolioID + "*";
            }

            DateTime fromDate = lAuditDate;
            DateTime toDate = fromDate.AddDays(1);

            int i = this.grdFolioSchedule.Rows.Count;
            this.grdFolioSchedule.Rows.Count += 1;

            // get previous schedule "TO DATE"
            if (i > 1)
            {
                fromDate = DateTime.Parse(this.grdFolioSchedule.GetDataDisplay(i - 1, 3));
                toDate = fromDate.AddDays(1);
            }

            this.grdFolioSchedule.SetData(i, 2, fromDate.Date);
            this.grdFolioSchedule.SetData(i, 3, toDate.Date);
            this.grdFolioSchedule.SetData(i, 4, "1"); // days

            //this.grdFolioSchedule.Cols[5].ComboList = lStringRateTypeList; // rate type

            this.grdFolioSchedule.SetData(i, 6, "0.00"); // amount
            this.grdFolioSchedule.SetData(i, 7, "0.00"); // total
            this.grdFolioSchedule.SetData(i, 8, "Y"); // total
            
            if (cboFolioType.Text != "DEPENDENT")
            {
                if (ConfigVariables.gAutoRoomingEnabled == "1")
                {
                    // set folio schedule grid
                    this.grdFolioSchedule.SetData(i, 0, ""); // room no
                    //this.grdFolioSchedule.Cols[0].ComboList = lStringRoomList; // room no
                    this.grdFolioSchedule.Cols[1].ComboList = lStringRoomTypeList; // room type
                }
                else
                {
                    grdFolioSchedule.Cols[0].AllowEditing = false;
                    grdFolioSchedule.Cols[1].AllowEditing = false;
                    this.grdFolioSchedule.SetData(i, 0, grdFolioSchedule.GetDataDisplay(i - 1, 0));
                    this.grdFolioSchedule_AfterEdit(sender, new RowColEventArgs(i, 0));
                }
            }
            else
            {
                this.grdFolioSchedule.SetData(i, 0, grdFolioSchedule.GetDataDisplay(i - 1, 0));
                this.grdFolioSchedule_AfterEdit(sender, new RowColEventArgs(i, 0));
            }
        }

		private void grdFolioSchedule_RowColChange(object sender, EventArgs e)
		{
			int _row = this.grdFolioSchedule.Row;
			int _col = this.grdFolioSchedule.Col;

			if (_row < 1)
				return;

			switch (_col)
			{
				case 0: // ROOM NO
					if (grdFolioSchedule.GetDataDisplay(_row, 0) != "" && txtStatus.Text != "WAIT LIST")
					{
                        //>>added by genny to disable editing of room number for dependents
                        if (cboFolioType.Text != "DEPENDENT")
                        {
                            this.grdFolioSchedule.StartEditing(_row, _col);
                        }
					}
					if (grdFolioSchedule.GetDataDisplay(_row, 0) != "")
						grdFolioSchedule_AfterEdit(sender, new RowColEventArgs(_row, _col));
					break;
				case 1: // ROOM TYPE
					this.grdFolioSchedule.Cols[1].ComboList = lStringRoomTypeList;
					string _roomNo = this.grdFolioSchedule.GetDataDisplay(_row, 0).ToString();

					// changed by Jrom
					// to handle choosing room type for wait list reservervations
					//if (_roomNo == "" && txtStatus.Text != "WAIT LIST")
					if (_roomNo == "" && txtStatus.Text == "WAIT LIST")
					{
						this.grdFolioSchedule.StartEditing(_row, _col);
					}
					else
					{
						this.grdFolioSchedule.AllowEditing = false;
					}
					break;
				// can't edit from date if ONGOING
				case 2: // FROM DATE
					if (this.txtStatus.Text == "ONGOING" && _row == 1)
					{
						this.grdFolioSchedule.AllowEditing = false;
					}
					else
					{
						this.grdFolioSchedule.AllowEditing = true;
					}

                    loadHotelPackages();
					break;

				case 3: // TO DATE
                    if (txtStatus.Text == "ONGOING" && _row < grdFolioSchedule.BottomRow && DateTime.Parse(grdFolioSchedule.GetDataDisplay(_row, _col)) <= DateTime.Parse(GlobalVariables.gAuditDate))
                    {
                        grdFolioSchedule.AllowEditing = false;
                    }
                    else
                    {
                        this.grdFolioSchedule.StartEditing(_row, _col);
                        loadHotelPackages();
                    }
					break;
				//case 4: // DAYS
				//	break;

				case 5: // RATE CODE
				case 6: // RATE AMOUNT
					this.grdFolioSchedule.StartEditing(_row, _col);
					break;
				//case 7:
				//	break;
				case 8:
					this.grdFolioSchedule.StartEditing(_row, _col);
					break;
				default:
					this.grdFolioSchedule.AllowEditing = false;
					break;
			}

		}

        private bool hasMultipleRooms()
        {
            foreach (C1.Win.C1FlexGrid.Row _row in grdFolioSchedule.Rows)
            {
                if (_row.Index > 1)
                {
                    string _prevRoom = grdFolioSchedule.GetDataDisplay(_row.Index - 1, 0);
                    string _curRoom = grdFolioSchedule.GetDataDisplay(_row.Index, 0);

                    if (_prevRoom != _curRoom)
                        return true;
                }
            }

            return false;
        }

		private void btnSave_Click(object sender, EventArgs e)
		{
            //if auto rooming is enabled, will not proceed saving if it has multiple different rooms
            if (ConfigVariables.gAutoRoomingEnabled == "0" && hasMultipleRooms())
            {
                MessageBox.Show("Error in saving folio.\r\nFolio has multiple rooms in its schedule.", "Multiple Rooms Disabled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

			DialogResult rsp = MessageBox.Show("Save folio changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (rsp == DialogResult.Yes)
			{
				//this.MdiParent.Cursor = Cursors.WaitCursor;

                //>>check for Pax and joiners if it synchronized...
                decimal _noOfJoiners = decimal.Parse(this.grdDependentGuests.Rows.Count.ToString());
                if (nudNoOfAdults.Value != _noOfJoiners)
                {
                    DialogResult _rspJoiner = MessageBox.Show("Total joiners does not match total adult pax.\r\n\r\nDo you want to continue saving folio?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (_rspJoiner == DialogResult.No)
                    {
                        this.MdiParent.Cursor = Cursors.Default;
                        return;
                    }
                }

				if (!assignFolioValues())
				{
					this.MdiParent.Cursor = Cursors.Default;
					return;
				}

				try
				{
					switch (lUIMode)
					{
						case UIMode.Add:

							loFolioFacade.SaveFolio(loFolio);

							//lOperationMode = ReservationOperationMode.ViewFolioInformation;
							//loadFolioInformation();
							break;

						case UIMode.Edit:

                            MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);
                            try
                            {
                                GlobalFunctions.protectFolioID(loFolio.FolioID.ToString(), ref _oTrans);           //jc 9.25.09
                                // update folio
                                loFolioFacade.updateFolio(loFolio);
                                this.Text = this.Text.Replace("*", "");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Transaction failed.\r\n\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                            }
                            finally
                            {
                                _oTrans.Commit();
                            }
                            break;


					}

					updateCurrentRoomStatus();
					MessageBox.Show("Transaction successful. Folio information saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

					switch (lOperationMode)
					{

						case ReservationOperationMode.NewChildFolio:
						case ReservationOperationMode.ViewChildFolio:
							this.MdiParent.Cursor = Cursors.Default;
							this.lOperationMode = ReservationOperationMode.ViewChildFolio;
							this.Close(); // exit to show Group Reservation screen
							break;

						case ReservationOperationMode.ViewFolioFromCalendar:
							this.MdiParent.Cursor = Cursors.Default;
							this.Close(); // exit to Calendar
							break;

						default:

							loControlListener.StopListen(this);
							// to set BUTTONS
							lOperationMode = ReservationOperationMode.ViewFolioInformation;
                            loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
							loadFolioInformation();

							lUIMode = UIMode.Add;
							this.txtStatus_TextChanged(this, new EventArgs());
							loControlListener.Listen(this);

							this.MdiParent.Cursor = Cursors.Default;
							break;
					}



				}
				catch (Exception ex)
				{
                    this.MdiParent.Cursor = Cursors.Default;
					MessageBox.Show("Transaction failed.\r\n\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
				}
			}


		}

		private void txtFromDate_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.dtpFromDate.Text = this.txtFromDate.Text;
				this.dtpArrivalTime.Value = this.dtpFolioETA.Value;
			}
			catch { }
		}

		private void txtToDate_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.dtpDepartureDate.Text = this.txtToDate.Text;
				this.dtpDepartureTime.Value = this.dtpFolioETD.Value;
			}
			catch { }
		}

		private void btnViewGuestList_Click(object sender, EventArgs e)
		{
			string _accountId = "";

			IndividualGuestLookUP _oGuestLookUp = new IndividualGuestLookUP();
			_accountId = _oGuestLookUp.showDialogID();


			this.txtAccountID.Text = _accountId;
			this.txtFirstName.Focus();
			this.lvwBrowseGuestName.Visible = false;
		}

		private void btnBrowseHistory_Click(object sender, EventArgs e)
		{

			if (loFolio.Guest != null)
			{
				string _guestName = loFolio.Guest.LastName + ", " + loFolio.Guest.FirstName;

				BrowseFolioHistoryUI _oBrowseHistoryUI = new BrowseFolioHistoryUI(loFolio.Guest.AccountId, _guestName);
				_oBrowseHistoryUI.ShowDialog();
			}
		}

		private void btnAddDependentGuest_Click(object sender, EventArgs e)
		{
			string _whereCondition = "AccountId <> '" + this.txtAccountID.Text + "' and ";
			for (int i = 1; i < this.grdDependentGuests.Rows.Count; i++)
			{
				_whereCondition += "AccountId <> '" + this.grdDependentGuests.GetDataDisplay(i, 1) + "' and ";
			}
			_whereCondition = _whereCondition.Substring(0, _whereCondition.Length - 4);

			GuestUI guestLookUp = new GuestUI(ref this.grdDependentGuests, "ADD");
			guestLookUp.showDialog(_whereCondition);

			if (txtAccountID.Text != ConfigVariables.gDefault_Guest)
				this.nudNoOfAdults.Value = this.grdDependentGuests.Rows.Count;
			else
				this.nudNoOfAdults.Value = grdDependentGuests.Rows.Count - 1;
		}

		private void txtStatus_TextChanged(object sender, EventArgs e)
		{
			setButtonState();
		}

		private void btnFolio_Click(object sender, EventArgs e)
		{
			// only RESERVED/ONGOING are allowed to view Folio Transactions
			if (loFolio.FolioID != "")
			{
                //jlo 8-9-10 forcibly set parameter constant to avoid possible errors
                //havent check for possible errors if not constant parameter is used because of lack of time
				string _currentRoomNo = loFolioFacade.GetCurrentRoomOccupied(loFolio.FolioID, "INDIVIDUAL");


				lFolioLedgerUI = new FolioLedgerUI(loFolio.FolioID, _currentRoomNo);
				lFolioLedgerUI.MdiParent = this.MdiParent;
				lFolioLedgerUI.Show();

				//close if status is Tentative
				if (this.txtStatus.Text == "TENTATIVE")
				{
					//disable formclosing event
					this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.ReservationFolioUI_FormClosing);

					this.Close();
				}

			}

		}

		private void btnPrintInfo_Click(object sender, EventArgs e)
		{
			if (loFolio.FolioID != "")
			{
				//this.MdiParent.Cursor = Cursors.WaitCursor;
				loReportFacade = new ReportFacade();

				loReportViewerUI = new ReportViewer();

                //jc 9.28.09
                MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    GlobalFunctions.protectFolioID(loFolio.FolioID.ToString(), ref _oTrans);           //jc 9.2.09
                    loReportViewerUI.rptViewer.ReportSource = loReportFacade.getGuestInformation(loFolio.FolioID);
                    loReportViewerUI.MdiParent = this.MdiParent;
                    loReportViewerUI.Show();

                    this.MdiParent.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Report failed.\r\nFolio has been used by another user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _oTrans.Commit();
			}
		}

		private void btnCheckedIn_Click(object sender, EventArgs e)
		{
            //jlo for apla 6-11-10
            String _rStatus = "";
            _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;

            int _newStatus = getIndex("ONGOING", aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                MessageBox.Show("Cannot check in reservation because it is already " + _rStatus + ".\nPlease close this reservation form for updates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //jlo

            if (bool.Parse(ConfigVariables.gAllowFullPaymentUponCheckIn) == true)
            {
                decimal totalPayables = decimal.Parse(grdFolioSchedule.GetDataDisplay(1, 7));
                FolioTransactionFacade _oFolioFacade = new FolioTransactionFacade();
                decimal totalPayment = _oFolioFacade.GetFolioPayments(loFolio.FolioID, "A");

                if (totalPayment < totalPayables)
                {
                    DialogResult rsp = MessageBox.Show("Transaction failed.\r\n\r\nFolio should have full payment before it can be ONGOING.\r\nDo you want to continue check-in process?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (rsp == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        string _priv = "Void Folio Transaction";
                        VerifyUserUI oVerifyUser = new VerifyUserUI(_priv);
                        if (!oVerifyUser.showDialog())
                        {
                            // exit if not authorized
                            return;
                        }
                    }
                }
            }

			if (!hasAtLeastOneRoomInSchedule())
			{
				MessageBox.Show("Transaction failed.\r\nInvalid schedule for this guest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// check if arrival date == audit date
			// if not UPDATE FOLIO first
			DateTime _fromDate = DateTime.Parse(this.txtFromDate.Text);
			if (_fromDate.Date != lAuditDate.Date)
			{
				DialogResult response = MessageBox.Show("Transaction failed.\r\n\r\nGuest's check in date is on " + string.Format("{0:ddd. MMM dd, yyyy}", _fromDate) + ".\r\n\r\n\r\nWould you like to change it to current date ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

				if (response == DialogResult.Yes)
				{
					// change from date
					if (this.grdFolioSchedule.Rows.Count > 1)
					{
						this.grdFolioSchedule.SetData(1, 2, lAuditDate);
						this.grdFolioSchedule_AfterEdit(sender, new RowColEventArgs(1, 3));

						// to check if has conflict on schedule
						if (!assignFolioValues())
						{ return; }

						return;
					}
					else
					{
						return;
					}
				}
				else
				{
					return;
				}
			} // end if


			DialogResult _response = MessageBox.Show("Folio will now be ONGOING.\r\n\r\nAre you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (_response == DialogResult.Yes)
			{
				if (!(loFolio.FolioID == null))
				{

					try
					{
						string _roomNo = "";

						foreach (Schedule _oSchedule in loFolio.Schedule)
						{
							_roomNo = _oSchedule.RoomID;
							break;
						}

						loControlListener.StopListen(this);

						bool isSucessfulUpdate = false;

                        //jc 9.28.09
                        MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);
                        try
                        {
                            GlobalFunctions.protectFolioID(loFolio.FolioID.ToString(), ref _oTrans);           //jc 9.2.09
                            isSucessfulUpdate = loFolioFacade.checkInFolio(loFolio.FolioID, _roomNo);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            _oTrans.Commit();
                        }

						if (isSucessfulUpdate)
						{
							// update folio status
							loFolio.Status = "ONGOING";

							loadFolioInformation();
							dtpArrivalTime.Value = DateTime.Now;

							loControlListener.Listen(this);

							updateCurrentRoomStatus();
						}

					}
					catch (Exception ex)
					{
						MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}

            loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
		}

		private void ReservationFolioUI_TextChanged(object sender, EventArgs e)
		{
			if (this.Text.IndexOf('*') > 0 && loFolio.Status != "CANCELLED" && loFolio.Status != "CLOSED" && loFolio.Status != "NO SHOW")
			{
				setUIMode(UIMode.Edit);

				this.btnSave.Enabled = true;
				this.btnCancel.Enabled = true;
				this.btnClose.Enabled = false;

				this.btnFolio.Enabled = false;
				this.btnPrintInfo.Enabled = false;
				this.btnCancelReservation.Enabled = false;
				this.btnConfirmed.Enabled = false;
				this.btnCheckedIn.Enabled = false;
				this.btnCheckedOut.Enabled = false;
				this.btnNoShow.Enabled = false;
			}
			else
			{
				this.btnSave.Enabled = false;
				this.btnCancel.Enabled = false;
				this.btnClose.Enabled = true;
			}
		}

		private void btnCheckedOut_Click(object sender, EventArgs e)
		{
			//disable formclosing event
			this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.ReservationFolioUI_FormClosing);

			CheckOutUI _oCheckOutUI = new CheckOutUI(loFolio.FolioID);
			_oCheckOutUI.MdiParent = this.MdiParent;

			this.lOperationMode = ReservationOperationMode.ViewFolioFromCalendar;

			_oCheckOutUI.Show();
			this.Close();
		}

		private void rbCalendar_CheckedChanged(object sender, EventArgs e)
		{
			if (rbCalendar.Checked)
			{
				this.grpCalendar.Enabled = true;

				this.grpAutoRoom.Enabled = false;
			}
			else
			{
				this.grpCalendar.Enabled = false;

				this.grpAutoRoom.Enabled = true;

				this.cboRoomType.DataSource = loRoomTypes;
				this.cboRoomType.DisplayMember = "RoomTypeCode";
			}
		}

		private void btnAutoSeekRoom_Click(object sender, EventArgs e)
		{
            //this.grdFolioSchedule.Rows.Count = 1;

			populateAutoRoom();
            lAutoRooming = false;
		}

		private void btnCalendarWizard_Click(object sender, EventArgs e)
		{
			//string _eventType = "";
			//if (this.txtStatus.Text == "ONGOING")
			//{
			//    _eventType = "IN HOUSE";
			//}
			//else
			//{
			//    _eventType = "RESERVATION";
			//}
			//loadCalendarUI(loFolio.FolioID, _eventType, this.grdFolioSchedule, "ALL", DateTime.Parse(GlobalVariables.gAuditDate), 5);

			DateTime _dtpStartDate = DateTime.Parse(GlobalVariables.gAuditDate);
			int _noOfWeeks = 5;
            string _roomType = "";
            if (grdFolioSchedule.Rows.Count > 1 && txtStatus.Text == "WAIT LIST")
            {
                _roomType = grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 1);
                _dtpStartDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 2));
            }
            else
            {
                _roomType = "ALL";
            }


			//>> check folio schedule
			//>> if has conflict set loFolio.Schedule = null since
			//>> this will be plotted in Calendar
			try
			{
				loFolio.Schedule = createFolioSchedule();
				if (hasRoomEventConflict() == 1)
				{
					loFolio.Schedule = null;
				}
			}
			catch { }


			loadCalendarWizard(_dtpStartDate, _noOfWeeks, _roomType, loFolio.Schedule);


		}

		public void loadCalendarWizard(DateTime pStartDate, int pNoOfWeeks, string pRoomType, IList<Schedule> folioSchedules)
		{

			string _operationMode = "";
			if (this.txtStatus.Text == "ONGOING")
			{
				_operationMode = "IN HOUSE";
			}
            else if (this.txtStatus.Text == "WAIT LIST")
            {
                _operationMode = "WAIT LIST";
            }
            else
            {
                _operationMode = "RESERVATION";
            }


			RoomCalendar_New oRoomCalendarUI = new RoomCalendar_New(_operationMode, pStartDate, pNoOfWeeks, pRoomType, folioSchedules);
			IList<Schedule> _oScheduleCollection = oRoomCalendarUI.launchCalendarWizard(this.label1);

			if (_oScheduleCollection == null)
			{
				return;
			}

			if (_oScheduleCollection.Count <= 0)
			{
				return;
			}

			//create Schedule from user input
			_oScheduleCollection = mergeSameFolioSchedule(_oScheduleCollection);
			loadNewFolioSchedulesToGrid(_oScheduleCollection);

			try
			{
				loFolio.Schedule = createFolioSchedule();
			}
			catch { }

			if (loFolio.Schedule == null)
			{
				return;
			}

			//>> load new schedule to Grid
			loadNewFolioSchedulesToGrid(loFolio.Schedule);


		}

		private void loadNewFolioSchedulesToGrid(IList<Schedule> _oScheduleCollection)
		{

			this.grdFolioSchedule.Rows.Count = 1;

			//load schedule to grid here
			foreach (Schedule _oSchedule in _oScheduleCollection)
			{
				this.grdFolioSchedule.Rows.Count++;
				int _rows = this.grdFolioSchedule.Rows.Count - 1;

				this.btnSave.Focus();

				this.grdFolioSchedule.SetData(_rows, 0, _oSchedule.RoomID);
				//this.grdFolioSchedule.SetData(_rows, 1, _oSchedule.RoomType);
				this.grdFolioSchedule.SetData(_rows, 2, _oSchedule.FromDate);
				this.grdFolioSchedule.SetData(_rows, 3, _oSchedule.ToDate);
				this.grdFolioSchedule.SetData(_rows, 4, _oSchedule.Days);

				this.grdFolioSchedule_AfterEdit(this, new RowColEventArgs(_rows, 3));
				this.grdFolioSchedule_AfterEdit(this, new RowColEventArgs(_rows, 0));

			}

			// remove rows having no Room No.
			for (int i = 1; i < this.grdFolioSchedule.Rows.Count; i++)
			{
				string _roomId = "";
				try
				{
					_roomId = this.grdFolioSchedule.GetDataDisplay(i, 0);
				}
				catch { }

				if (_roomId == "")
				{
					this.grdFolioSchedule.Rows.Remove(i);
					i--;
				}
			}


		}

		private void btnNoShow_Click(object sender, EventArgs e)
		{

			DialogResult rsp = MessageBox.Show("Are you sure you want to set this reservation to No Show?", "Folio Plus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rsp == DialogResult.No)
				return;

            //jc 9.28.09
            MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);

			try
			{
                GlobalFunctions.protectFolioID(loFolio.FolioID.ToString(), ref _oTrans);           //jc 9.2.09
				if (loFolioFacade.noShowFolio(loFolio.FolioID))
				{

					updateCurrentRoomStatus();

					MessageBox.Show("Transaction successful.\r\nReservation status has been set to No Show.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
                _oTrans.Commit();
			}
			catch (Exception ex)
			{
                _oTrans.Rollback();
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCancelReservation_Click(object sender, EventArgs e)
		{

			//Folio oFolio = oFolioFacade.GetFolio(this.txtFolioID.Text);

			bool hasBalance = false;

			//oFolio.CreateSubFolio();
			decimal balance = 0;
			foreach (SubFolio subF in loFolio.SubFolios)
			{
				subF.Ledger = loFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
				balance = subF.Ledger.BalanceNet;
				if (balance != 0)
				{
					hasBalance = true;
				}
			}
			if (hasBalance)
			{
				MessageBox.Show("Transaction failed.\r\n\r\nGuest still has unsettled account.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			// prompts for REASON for CANCEL
			ReasonForCancelUI reasonUI = new ReasonForCancelUI();
			string reason = reasonUI.showDialog();

			if (reason == "")
				return;


			if (MessageBox.Show("Are you sure you want to Cancel this Reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
                try
                {
                    MySqlTransaction _dbTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);
                    try
                    {
                        GlobalFunctions.protectFolioID(loFolio.FolioID, ref _dbTrans);
                        loFolioFacade.cancelFolio(loFolio.FolioID, reason);
                    }
                    catch (Exception ex)
                    {
                        _dbTrans.Commit();
                        throw ex;
                    }
                    // UPDATES CURRENT DAY ROOM STATUS
                    updateCurrentRoomStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }

			}
		}

		private void ReservationFolioUI_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool isEdited = this.Text.Contains("*");

			if (lOperationMode == ReservationOperationMode.QuickReservation ||
				lOperationMode == ReservationOperationMode.NewGuestReservation ||
				lOperationMode == ReservationOperationMode.NewChildFolio ||
				isEdited)
			{
				DialogResult rsp = MessageBox.Show("You are currently processing reservation.\r\n\r\nChanges will not be saved.\r\n\r\nClick Ok to exit without saving.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
				if (rsp == DialogResult.OK)
				{
					e.Cancel = false;
				}
				else
				{
					e.Cancel = true;
				}
			}


			if (!e.Cancel)
			{
				switch (lOperationMode)
				{
					case ReservationOperationMode.NewGuestReservation:
					case ReservationOperationMode.ViewFolioInformation:
						// open Reservation List
						foreach (Form _frmChild in this.MdiParent.MdiChildren)
						{
							if (_frmChild.Name == "ReservationListUI")
							{
								_frmChild.Focus();
								return;
							}
						}
						
						try
						{
							ReservationListUI _oReservationListUI = new ReservationListUI(this.txtStatus.Text);
							_oReservationListUI.MdiParent = this.MdiParent;
							_oReservationListUI.Show();
						}
						catch
						{ }

						break;

					case ReservationOperationMode.QuickReservation:
					case ReservationOperationMode.ViewChildFolio:
					case ReservationOperationMode.NewChildFolio:
					case ReservationOperationMode.ViewFolioFromCalendar:
						break;

				}
			}
		}

		private void btnClose_EnabledChanged(object sender, EventArgs e)
		{

			if (this.btnClose.Enabled)
			{
				this.CancelButton = this.btnClose;
			}
			else
			{
				this.CancelButton = this.btnCancel;
			}
		}

		private void btnAddHotelPromo_Click(object sender, EventArgs e)
		{
			int _row = this.grdHotelPromos.Row;
			if (_row <= 0)
			{
				return;
			}


			string _promoId = this.grdHotelPromos.GetDataDisplay(_row, 0);

			foreach (PackageHeader _oPackageHeader in loPackages)
			{
				if (_promoId == _oPackageHeader.PackageID)
				{
                    DateTime _dateFrom = DateTime.Parse(grdFolioSchedule.GetDataDisplay(1, 2));
                    DateTime _dateTo = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));

                    if (_dateFrom.Date < _oPackageHeader.FromDate.Date)
                    {
                        _dateFrom = _oPackageHeader.FromDate;
                    }
                    if (_dateTo.Date > _oPackageHeader.ToDate.Date)
                    {
                        _dateTo = _oPackageHeader.ToDate;
                    }

					// load details
					this.grdFolioPackage.Rows.Count = 1;
					int i = 1;
                    dtpPackageDateFrom.Value = _dateFrom;
                    dtpPackageDateTo.Value = _dateTo;

					foreach (PackageDetail _detail in _oPackageHeader.PackageDetails)
					{
						this.grdFolioPackage.Rows.Count += 1;

						this.grdFolioPackage.SetData(i, 0, _detail.TransactionCode);
						this.grdFolioPackage.SetData(i, 1, _detail.Memo);
						this.grdFolioPackage.SetData(i, 2, _detail.Basis);
						this.grdFolioPackage.SetData(i, 3, _detail.PercentOff);
						this.grdFolioPackage.SetData(i, 4, _detail.AmountOff);

						i++;
					}

					//>> to enable Save, Cancel buttons
					string _temp = this.txtRemarks.Text;
					this.txtRemarks.Text = "TEMP";
					this.txtRemarks.Text = _temp;
                    
					return;
				}
			}
		}

		private void btnRemoveHotelPromo_Click(object sender, EventArgs e)
		{
			if (this.grdFolioPackage.Rows.Count > 1)
			{

				DialogResult rsp = MessageBox.Show("Remove current folio package ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

				if (rsp == DialogResult.Yes)
				{
					this.grdFolioPackage.Rows.Count = 1;

					//>> to enable Save, Cancel buttons
					string _temp = this.txtRemarks.Text;
					this.txtRemarks.Text = "TEMP";
					this.txtRemarks.Text = _temp;
				}

			}
		}


		private void txtCitizenship_TextChanged(object sender, EventArgs e)
		{
			string _citizenship = this.txtCitizenship.Text;

			if (_citizenship.Trim().Length > 0)
			{

				foreach (Country _oCountry in GlobalVariables.gCountryList)
				{
					if (_oCountry.Nationality == _citizenship)
					{
						this.txtCountry.Text = _oCountry.CountryName;
						return;
					}
				}
			}
		}

		private void txtCountry_TextChanged(object sender, EventArgs e)
		{
			string _country = this.txtCountry.Text;

			if (_country.Trim().Length > 0)
			{

				foreach (Country _oCountry in GlobalVariables.gCountryList)
				{
					if (_oCountry.CountryName == _country)
					{
						this.txtCitizenship.Text = _oCountry.Nationality;
						return;
					}
				}
			}
		}



		private void btnShowMaster_Click(object sender, EventArgs e)
		{

			if (loFolio.MasterFolio != "")
			{
				switch (lOperationMode)
				{
					case ReservationOperationMode.ViewChildFolio:

						this.Close();

						break;

					case ReservationOperationMode.ViewFolioInformation:
						// load Reservation Folio UI with master folio information
						Folio oMasterFolio = new Folio();
						oMasterFolio = loFolioFacade.GetFolio(loFolio.MasterFolio);
						switch (oMasterFolio.FolioType)
						{
							case "GROUP":

								this.lOperationMode = ReservationOperationMode.ViewChildFolio;

								this.Close();

								GroupReservationUI _oGroupReservationUI = new GroupReservationUI(loFolio.MasterFolio, null);
								_oGroupReservationUI.MdiParent = (Form)GlobalVariables.gMDI;
								_oGroupReservationUI.Show();



								break;
							default:


								this.Close();

								ReservationFolioUI _oReservationFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioInformation, loFolio.MasterFolio);
								_oReservationFolioUI.MdiParent = (Form)GlobalVariables.gMDI;
								_oReservationFolioUI.Show();
								break;
						}


						break;

					default:
						MessageBox.Show("Folio type not supported.\r\n\r\nPlease select master folio first.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
						break;
				}
			}
			else
			{
				MessageBox.Show("Master folio not set.\r\n\r\nPlease contact system administrator.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
			}

		}

		private void btnSetMasterFolio_Click(object sender, EventArgs e)
		{

			bool proceed = false;

			if (loFolio.MasterFolio == "")
			{
				proceed = true;
			}
			else
			{
				// overwrite existing Master Folio
				DialogResult rsp = MessageBox.Show("Overwrite existing master folio ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (rsp == DialogResult.Yes)
				{
					proceed = true;
				}
				else
				{
					proceed = false;
				}

			}

			if (proceed)
			{
				try
				{
					Folio _oMasterFolio = new Folio();
					BrowseFolioUI browseFolio = new BrowseFolioUI();
					_oMasterFolio = browseFolio.showDialog(this);

					if (_oMasterFolio != null)
					{
						this.loFolio.MasterFolio = _oMasterFolio.FolioID;
					}
				}
				catch { }
			}

		}

        private void deleteScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cboFolioType.Text != "NON-STAYING")
            {
                if (lUIMode != UIMode.Add)
                {
                    this.Text = "Folio : " + loFolio.FolioID + "*";
                }

                int _row = this.grdFolioSchedule.Row;
                if (_row > 0)
                {
                    DialogResult rsp = MessageBox.Show("Delete selected schedule?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (rsp == DialogResult.Yes)
                    {
                        if (txtStatus.Text != "ONGOING")
                        {
                            this.grdFolioSchedule.Rows.Remove(_row);

                            if (_row > 1)
                            {
                                DateTime _lastDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));
                                dtpDepartureDate.Text = _lastDate.ToString("dd-MMM-yyyy");
                            }
                        }
                        else
                        {
                            if (grdFolioSchedule.Rows.Count <= 2 || 
                                (DateTime.Parse(GlobalVariables.gAuditDate) > DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Row, 2)) && 
                                DateTime.Parse(GlobalVariables.gAuditDate) <= DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Row, 3))))
                                MessageBox.Show("Cannot delete schedule! \r\nGuest is already ONGOING and \r\nsystem date falls within the schedule.", "Delete Schedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else
                            {
                                this.grdFolioSchedule.Rows.Remove(_row);

                                if (_row > 1)
                                {
                                    DateTime _lastDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));
                                    dtpDepartureDate.Text = _lastDate.ToString("dd-MMM-yyyy");
                                }
                            }
                        }
                    }
                }
            }
        }

		private void cboFolioType_SelectedIndexChanged(object sender, EventArgs e)
		{
			int _selected = this.cboFolioType.SelectedIndex;

			switch (_selected)
			{
				case 0: // individual
					//if (this.loFolio.MasterFolio == "")
					//{
					this.btnSetMasterFolio.Visible = false;
					this.btnShowMaster.Visible = false;

					this.grdFolioSchedule.ContextMenuStrip = this.cmuSchedule;
					deAllocateRoom.Enabled = true;
					//}
					//else
					//{
					//    DialogResult rsp = DialogResult.Yes;

					//    if (lOperationMode == ReservationOperationMode.ViewFolioInformation)
					//    {
					//        rsp = MessageBox.Show("Action would remove the link to its master folio.\r\n\r\nWould you like to continue ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					//    }

					//    if (rsp == DialogResult.Yes)
					//    {

					//        loFolio.MasterFolio = "";
					//        this.btnSetMasterFolio.Visible = false;
					//        this.btnShowMaster.Visible = false;

					//        this.grdFolioSchedule.ContextMenuStrip = this.cmuSchedule;
					//    }
					//}

					break;
				case 1: // dependent

					this.btnSetMasterFolio.Visible = true;
					this.btnShowMaster.Visible = true;

					this.grdFolioSchedule.ContextMenuStrip = this.cmuSchedule;
					deAllocateRoom.Enabled = false;
					break;
				case 2: // joiner
					this.btnSetMasterFolio.Visible = true;
					this.btnShowMaster.Visible = true;


					this.grdFolioSchedule.ContextMenuStrip = this.cmuSchedule;
					deAllocateRoom.Enabled = false;
					break;
				case 3: // non-staying
					this.grdFolioSchedule.Rows.Count = 1;
					this.grdFolioSchedule.ContextMenuStrip = null;

					// set schedule here
					this.txtFromDate.Text = string.Format(GlobalVariables.gDateFormat, lAuditDate);
					this.txtToDate.Text = this.txtFromDate.Text;

					this.btnCalendarWizard.Enabled = false;
					this.btnAutoSeekRoom.Enabled = false;

					break;
				default:
					break;
			}

		}

		private void nudNoOfAdults_ValueChanged(object sender, EventArgs e)
		{
			if (lOperationMode.ToString().ToUpper() == OperationMode.Edit.ToString().ToUpper())
			{
				nudNoOfAdults.Value = loFolio.NoofAdults;
			}

			//>>added for getting the rate amount if group has applied rates
			string _masterFolioID = "";
			if (loFolio.MasterFolio != "" && loFolio.MasterFolio != null)
			{
				_masterFolioID = loFolio.MasterFolio;
			}

			foreach (C1.Win.C1FlexGrid.Row _row in grdFolioSchedule.Rows)
			{
				string _roomTypeCode = grdFolioSchedule.GetDataDisplay(_row.Index, 1);
				string _rateCode = grdFolioSchedule.GetDataDisplay(_row.Index, 5);

				if (_rateCode != "APPLIED")
				{
                    //commented next line so that rate will not be changed
                    //foreach (RateType _oRateType in loRateTypes)
                    //{
                    //    if (_oRateType.RoomTypeCode == _roomTypeCode
                    //        && _oRateType.RateCode == _rateCode)
                    //    {
                    //        this.grdFolioSchedule.SetData(_row.Index, 6, _oRateType.RateAmount.ToString("N"));
                    //        this.grdFolioSchedule.SetData(_row.Index, 8, _oRateType.HasBreakfast);
                    //        break;
                    //    }
                    //}
				}
				else
				{
					if (loEventAppliedRatesList != null)
					{
						foreach (EventAppliedRates _oAppliedRate in loEventAppliedRatesList)
						{
							if (_oAppliedRate.NumberOfOccupants == this.nudNoOfAdults.Value)
							{

								this.grdFolioSchedule.SetData(_row.Index, 6, _oAppliedRate.RateAmount);
								this.grdFolioSchedule.SetData(_row.Index, 8, "Y");
								break;
							}
						}
					}
				}

			}
            try
            {
                computeTotalRoomRateAndDays();
            }
            catch { }
		}

		private void btnBrowseCompany_Click(object sender, EventArgs e)
		{
			GroupAccountLookUP _companyUI = new GroupAccountLookUP(this.txtCompanyId, this.txtCompanyName, this.txtCompanyId, "COMPANY");
			_companyUI.ShowDialog();

			this.lvwBrowseCompany.Visible = false;
		}

		private void btnBrowseAgent_Click(object sender, EventArgs e)
		{
			GroupAccountLookUP _companyUI = new GroupAccountLookUP(this.txtAgentId, this.txtAgentName, this.txtAgentId, "AGENT");
			_companyUI.ShowDialog();

			//this.lvwBrowseCompany.Visible = false;
        }

		private bool hasAtLeastOneRoomInSchedule()
		{
			int rows = this.grdFolioSchedule.Rows.Count;

			if (rows <= 1)
			{
				return false;
			}

			string roomNo = this.grdFolioSchedule.GetDataDisplay(1, 0);
			string roomType = this.grdFolioSchedule.GetDataDisplay(1, 1);

			if (roomNo == "" || roomType == "")
			{
				return false;
			}

			return true;
		}


		private void btnConfirmed_Click(object sender, EventArgs e)
		{
			if (!hasAtLeastOneRoomInSchedule())
			{
				MessageBox.Show("Transaction failed.\r\nInvalid schedule for this guest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            //jlo for apla 6-11-10
            String _rStatus = "";
            _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;

            int _newStatus = getIndex("CONFIRMED", aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                MessageBox.Show("Cannot confirmed reservation because it is already " + _rStatus + ".\nPlease close this reservation form for updates.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //jlo

			DialogResult rsp = MessageBox.Show("Are you sure you want to set this reservation to Confirmed?",
											   "Confirm", 
											   MessageBoxButtons.YesNo, 
											   MessageBoxIcon.Question, 
											   MessageBoxDefaultButton.Button2);
			if (rsp == DialogResult.No)
			{
				return;
			}

			MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);

			try
            {
                loControlListener.StopListen(this);
                GlobalFunctions.protectFolioID(loFolio.FolioID, ref _oDBTrans);           //jc 9.2.09
                loFolioFacade.confirmFolio(loFolio.FolioID, ref _oDBTrans);
                _oDBTrans.Commit();
                MessageBox.Show("Transaction successful.\r\nReservation status is now Confirmed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                this.txtStatus.Text = "CONFIRMED";
                loControlListener.Listen(this);
                //this.Close();
            }
			catch (Exception ex)
			{
				_oDBTrans.Rollback();

				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
			}
		}

		private void btnRemoveDependentGuest_Click(object sender, EventArgs e)
		{
			if (this.grdDependentGuests.Rows.Count > 1)
			{
				int _row = this.grdDependentGuests.Row;
				string _folioId = this.grdDependentGuests.GetDataDisplay(_row, 7);
				string _guestName = this.grdDependentGuests.GetDataDisplay(_row, 2) + ", " + this.grdDependentGuests.GetDataDisplay(_row, 3);


				//if (_folioId == "")
				//{
				DialogResult rsp = MessageBox.Show("Remove guest " + _guestName + " ?  ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (rsp == DialogResult.No)
					return;
				//}
				//else
				//{
				//    if (loFolio.Status == "ONGOING")
				//    {
				//        DialogResult rsp = MessageBox.Show("Check-out guest " + _guestName + " ?  ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				//        if (rsp == DialogResult.No)
				//            return;
				//    }
				//    else
				//    {
				//        DialogResult rsp = MessageBox.Show("Cancel reservation for guest " + _guestName + " ?  ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				//        if (rsp == DialogResult.No)
				//            return;
				//    }
				//}


				// if has folioId means Guest already reserved
				//if (_folioId != "")
				//{
				//    switch (loFolio.Status)
				//    {
				//        case "ONGOING":// check-out guest
				//            try
				//            {
				//                loControlListener.StopListen(this);

				//                loFolioFacade.checkOutFolio(_folioId, "", "SHARE GUEST-CLOSED");

				//                loControlListener.Listen(this);
				//            }
				//            catch (Exception ex)
				//            {
				//                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//                return;
				//            }
				//            break;

				//        case "CONFIRMED": // cancel reservation
				//        case "TENTATIVE": // cancel reservation
				//            try
				//            {
				//                loControlListener.StopListen(this);

				//                // prompts for REASON for CANCEL
				//                ReasonForCancelUI reasonUI = new ReasonForCancelUI();
				//                string _reason = reasonUI.showDialog();

				//                if (_reason == "")
				//                    return;

				//                loFolioFacade.cancelFolio(_folioId, _reason);

				//                loControlListener.Listen(this);
				//            }
				//            catch (Exception ex)
				//            {
				//                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//                return;
				//            }
				//            break;
				//    }
				//}

				this.grdDependentGuests.RemoveItem(_row);

				// Change numbering
				for (int i = 1; i < this.grdDependentGuests.Rows.Count; i++)
				{
					this.grdDependentGuests.SetData(i, 0, i);
				}

				// >> to update number of pax
				this.nudNoOfAdults.Value = this.grdDependentGuests.Rows.Count;

			}
		}

		private void btnRemoveRecurringCharge_Click(object sender, EventArgs e)
		{
			int _row = this.grdRecurringCharges.Row;

			if (_row <= 0)
			{
				return;
			}

			DialogResult rsp = MessageBox.Show("Remove recurring charge entry?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (rsp == DialogResult.Yes)
			{
				this.grdRecurringCharges.RemoveItem(_row);
			}

		}


		private void btnGuestPrivileges_Remove_Click(object sender, EventArgs e)
		{
			int _row = this.grdFolioPrivileges.Row;

			if (_row <= 0)
			{
				return;
			}

			DialogResult rsp = MessageBox.Show("Remove selected privilege?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (rsp == DialogResult.Yes)
			{
				this.grdFolioPrivileges.Rows.Remove(_row);

				if (!this.Text.Contains("*"))
				{
					this.Text += "*";
				}
			}

		}

		private void grdFolioPrivileges_RowColChange(object sender, EventArgs e)
		{
			int _col = grdFolioPrivileges.Col;
			int _row = grdFolioPrivileges.Row;

			if (_row <= 1)
				return;


			string _basis = this.grdFolioPrivileges.GetDataDisplay(_row, 2);


			switch (_col)
			{
				case 2:
					grdFolioPrivileges.AllowEditing = true;
					if (_basis == "A")
					{ this.grdFolioPrivileges.SetData(_row, 3, 0); }
					else
					{ this.grdFolioPrivileges.SetData(_row, 4, 0); }

					break;

				case 3:
					if (_basis == "A")
					{ grdFolioPrivileges.AllowEditing = false; }
					else
					{ grdFolioPrivileges.AllowEditing = true; }

					break;
				case 4:
					if (_basis == "A")
					{ grdFolioPrivileges.AllowEditing = true; }
					else
					{ grdFolioPrivileges.AllowEditing = false; }
					break;
				default:
					break;
			}
		}

		private void grdFolioPrivileges_KeyPressEdit(object sender, KeyPressEditEventArgs e)
		{
			int _col = e.Col;
			int _row = e.Row;

			string _basis = this.grdFolioPrivileges.GetDataDisplay(_row, 2);

			if (_basis == "")
			{
				e.Handled = true;
			}
			else
			{
				switch (_basis)
				{
					case "A":
						if (_col == 3)
							e.Handled = true;

						break;
					case "P":
						if (_col == 4)
							e.Handled = true;
						break;
				}
			}

		}

		private void grdFolioPrivileges_AfterEdit(object sender, RowColEventArgs e)
		{
			string _basis = this.grdFolioPrivileges.GetDataDisplay(e.Row, 2);

			if (_basis == "A")
			{ this.grdFolioPrivileges.SetData(e.Row, 3, 0); }
			else
			{
				this.grdFolioPrivileges.SetData(e.Row, 4, 0);

				// check if not greater 100 Percent
				decimal _percent = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(e.Row, 3));
				if (_percent > 100)
				{
					this.grdFolioPrivileges.SetData(e.Row, 3, 0);
				}

			}

		}


		#endregion

		#region "GUEST LOOKUP"


		private void showGuestLookUp(string pLastName, string pFirstName)
		{
			if (!isFormLoaded)
			{
				return;
			}

			try
			{
				pLastName = pLastName + "%";
				pFirstName = pFirstName + "%";

				DataTable tempGuestTable = loGuestFacade.getGuestsAsDataTableByNameUsingLike(
																					pLastName,
																					pFirstName);

				//loDtViewGuest = loGuests.DefaultView;
				loDtViewGuest = tempGuestTable.DefaultView;

				loDtViewGuest.RowStateFilter = DataViewRowState.OriginalRows;
				loDtViewGuest.RowFilter = "LastName like '" + pLastName + "%' and FirstName like '" + pFirstName + "%'";
                loDtViewGuest.Sort = "Lastname, Firstname";


				this.lvwBrowseGuestName.Items.Clear();
				foreach (DataRowView _dtRowView in loDtViewGuest)
				{
					ListViewItem _lvwItem = new ListViewItem();
					_lvwItem.Text = _dtRowView["AccountId"].ToString();

					_lvwItem.SubItems.Add(_dtRowView["LastName"].ToString());
					_lvwItem.SubItems.Add(_dtRowView["FirstName"].ToString());

					this.lvwBrowseGuestName.Items.Add(_lvwItem);
				}


				if (loDtViewGuest.Count <= 0)
				{
					this.lvwBrowseGuestName.Visible = false;
					this.txtAccountID.Text = "";
				}
				else
				{
					int _posX = this.txtLastName.Left + 15;
					int _posY = this.txtLastName.Top + 60;

					this.lvwBrowseGuestName.Left = _posX;
					this.lvwBrowseGuestName.Top = _posY;

					this.lvwBrowseGuestName.Visible = true;
					this.lvwBrowseGuestName.HeaderStyle = ColumnHeaderStyle.None;
				}

			}
			catch
			{ }

		}

		// LAST NAME
		private void txtLastName_TextChanged(object sender, EventArgs e)
		{
			if (this.txtLastName.Text.Trim().Length <= 0)
			{
				this.lvwBrowseGuestName.Visible = false;
			}
			else
			{
				showGuestLookUp(this.txtLastName.Text, "");
			}

		}

		// FIRST NAME
		private void txtFirstName_TextChanged(object sender, EventArgs e)
		{
			if (this.txtFirstName.Text.Trim().Length <= 0)
			{
				this.lvwBrowseGuestName.Visible = false;
			}
			else
			{
				showGuestLookUp(this.txtLastName.Text, this.txtFirstName.Text);
			}
		}

		private void txtLastName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (this.lvwBrowseGuestName.Visible && this.lvwBrowseGuestName.Items.Count > 0)
				{
					this.lvwBrowseGuestName.Focus();
					this.lvwBrowseGuestName.Items[0].Selected = true;
				}
			}
		}

		private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Down)
			{
				if (this.lvwBrowseGuestName.Visible && this.lvwBrowseGuestName.Items.Count > 0)
				{
					this.lvwBrowseGuestName.Focus();
					this.lvwBrowseGuestName.Items[0].Selected = true;
				}
			}
		}

		private void lvwBrowseGuestName_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				string _accountId = this.lvwBrowseGuestName.SelectedItems[0].Text;

				this.txtAccountID.Text = _accountId;
			}
			catch
			{ }

			this.lvwBrowseGuestName.Visible = false;
		}

		private void txtFirstName_Leave(object sender, EventArgs e)
		{

			if (!this.lvwBrowseGuestName.Focused)
			{
				this.lvwBrowseGuestName.Visible = false;
			}

			if (this.txtFirstName.Text.Trim().Length == 0 ||
				this.txtLastName.Text.Trim().Length == 0)
			{
				return;
			}


			// search guests FirstName & LastName in GuestList
			//foreach (Guest _oGuest in loGuestList)
			//{
			//    if (_oGuest.LastName == this.txtLastName.Text &&
			//        _oGuest.FirstName == this.txtFirstName.Text)
			//    {
			//        this.txtAccountID.Text = _oGuest.AccountId;
			//    }
			//}
			try
			{
				//DataView _dtView = loGuests.DefaultView;

				//_dtView.RowStateFilter = DataViewRowState.OriginalRows;
				//_dtView.RowFilter = "LastName = '" + this.txtLastName.Text + "' and FirstName = '" + this.txtFirstName.Text + "'";

				//DataRowView _dRow = _dtView[0];


				////Guest _oGuest = new Guest();

				//this.txtAccountID.Text = _dRow["AccountId"].ToString();
				////_oGuest.AccountId = _dRow["AccountId"].ToString();

				DataTable tempTable = loGuestFacade.getGuestRecordAsDataTableByName(this.txtLastName.Text, this.txtFirstName.Text);
				DataRow _dRow = tempTable.Rows[0];
				this.txtAccountID.Text = _dRow["AccountId"].ToString();
			
			}
			catch { }


		}

		private bool guestIsCheckedIn(string pAccountID, string pRoomNo)
		{
			FolioFacade _oFolioFacade = new FolioFacade();
			return _oFolioFacade.guestIsCheckedIn(pAccountID, pRoomNo);
		}

		private void txtAccountID_TextChanged(object sender, EventArgs e)
		{
			if (this.txtAccountID.Text != "")
			{
				string _roomNo = "";
				try
				{
					foreach (Schedule _oSched in loFolio.Schedule)
					{
						if (DateTime.Parse(GlobalVariables.gAuditDate) >= _oSched.FromDate && DateTime.Parse(GlobalVariables.gAuditDate) <= _oSched.ToDate)
						{
							_roomNo = _oSched.RoomID;
							break;
						}
					}
				}
				catch
				{
					_roomNo = "";
				}

				if (!guestIsCheckedIn(txtAccountID.Text, _roomNo))
				{
					displayGuestAccountInformation(this.txtAccountID.Text);
					if (txtAccountID.Text != ConfigVariables.gDefault_Guest)
					{
						nudNoOfAdults.Value = grdDependentGuests.Rows.Count;
					}
				}
				else
				{
					if (MessageBox.Show("Selected guest has already checked-in in another room. Do you want to continue selecting this guest?!", "Check-in Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
					{
						txtAccountID.Text = "";
						txtLastName.Text = "";
						txtFirstName.Text = "";
						txtAccountName.Text = "";
					}
					else
					{
						displayGuestAccountInformation(txtAccountID.Text);
						if (txtAccountID.Text != ConfigVariables.gDefault_Guest)
						{
							nudNoOfAdults.Value = grdDependentGuests.Rows.Count;
						}
					}
				}
			}
			else
			{
				loFolio.Guest = null;
			}
		}

		#endregion

		#region "COMPANY LOOK UP"

		private void showCompanyLookUp(string pCompanyName)
		{
			if (!isFormLoaded)
			{
				return;
			}

			try
			{
				pCompanyName = pCompanyName + "%";
				DataTable tempCompanyTable = loCompanyFacade.getCompanyInfoAsDataTableByNameUsingLike(pCompanyName);

                //loDtViewCompany = loCompany.DefaultView;

				//loDtViewCompany.RowStateFilter = DataViewRowState.OriginalRows;
				//loDtViewCompany.RowFilter = "CompanyName like '" + pCompanyName + "%'";


				this.lvwBrowseCompany.Items.Clear();
				foreach (DataRow _dtRowView in tempCompanyTable.Rows)
				{
					ListViewItem _lvwItem = new ListViewItem();
					_lvwItem.Text = _dtRowView["CompanyId"].ToString();

					_lvwItem.SubItems.Add(_dtRowView["CompanyName"].ToString());

					this.lvwBrowseCompany.Items.Add(_lvwItem);
				}


				if (tempCompanyTable.Rows.Count <= 0)
				{
					this.lvwBrowseCompany.Visible = false;
					this.txtCompanyId.Text = "";
				}
				else
				{
					int _posX = this.txtCompanyName.Left + 15;
					int _posY = this.txtCompanyName.Top + 60;

					this.lvwBrowseCompany.Left = _posX;
					this.lvwBrowseCompany.Top = _posY;

					this.lvwBrowseCompany.Visible = true;
					this.lvwBrowseCompany.HeaderStyle = ColumnHeaderStyle.None;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (this.lvwBrowseCompany.Visible && this.lvwBrowseCompany.Items.Count > 0)
				{
					this.lvwBrowseCompany.Focus();
					this.lvwBrowseCompany.Items[0].Selected = true;
				}
			}
		}

		private void txtCompanyName_TextChanged(object sender, EventArgs e)
		{
			if (this.txtCompanyName.Text.Trim().Length <= 0)
			{
				this.lvwBrowseCompany.Visible = false;
			}
			else
			{
				if (txtCompanyName.Focused == true)
				{
					showCompanyLookUp(this.txtCompanyName.Text);
				}
			}
		}

		private void txtCompanyName_Leave(object sender, EventArgs e)
		{

			if (!this.lvwBrowseCompany.Focused)
			{
				this.lvwBrowseCompany.Visible = false;
			}

			if (this.txtCompanyName.Text.Trim().Length == 0)
			{
				return;
			}

			// display Company Info
			try
			{

				DataTable tempCompanyTable = loCompanyFacade.getCompanyInfoAsDataTableByName(this.txtCompanyName.Text);
				DataRow _dRow = tempCompanyTable.Rows[0];

				//DataView _dtViewCompany = loCompany.DefaultView;

				//_dtViewCompany.RowStateFilter = DataViewRowState.OriginalRows;
				//_dtViewCompany.RowFilter = "CompanyName = '" + this.txtCompanyName.Text + "'";

				//DataRowView _dRow = _dtViewCompany[0];

				this.txtCompanyId.Text = _dRow["CompanyId"].ToString();
				

			}
			catch { }


		}

		private void lvwBrowseCompany_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				string _companyId = this.lvwBrowseCompany.SelectedItems[0].Text;

				this.txtCompanyId.Text = _companyId;
			}
			catch
			{ }

			this.lvwBrowseCompany.Visible = false;
		}

		private void lvwBrowseCompany_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) // 13 = ENTER
			{
				lvwBrowseCompany_DoubleClick(sender, new EventArgs());
			}
		}

		private void txtCompanyId_TextChanged(object sender, EventArgs e)
		{
			if (this.txtCompanyId.Text != "")
			{
				displayCompanyAccountInformation(this.txtCompanyId.Text);
			}
			else
			{
				loFolio.CompanyID = "";
				this.loFolio.Company = null;
			}
		}


		#endregion

		#region "AUTO ROOMING"

        private bool lAutoRooming = false;
		private void populateAutoRoom()
		{
            if (lUIMode != UIMode.Add)
            {
                this.Text = "Folio : " + loFolio.FolioID + "*";
            }

            lAutoRooming = true;
            initializeNewGuestReservation();

			this.Parent.Cursor = Cursors.WaitCursor;

			try
			{
				ArrayList AllroomDateCollections = this.fillRoomDateCollections(true, "");
				string str = this.getRoomId(AllroomDateCollections);
				if (AllroomDateCollections.Count < 1)
					str = "-ROOM";

				ArrayList roomDateCollections = this.fillRoomDateCollections(false, str);

				int size = (roomDateCollections.Count);
				//int sumOfAllDayDiff = 0;
                if (size <= 0)
                {
                    MessageBox.Show("No Rooms Available. Please select different room type.", "No Vacant Room", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    this.Parent.Cursor = Cursors.Default;
                    return;
                }

				for (int i = 0; i < size; i++)
				{
					if (i + 1 < size)
					{
						string[] _roomAndFromDate = roomDateCollections[i].ToString().Split(new char[] { '#' });
						string[] _roomAndToDate = roomDateCollections[i + 1].ToString().Split(new char[] { '#' });

                        DialogResult rsp = MessageBox.Show("Room " + _roomAndFromDate[0] + " is vacant from " + string.Format("{0:MMM. dd}", DateTime.Parse(_roomAndFromDate[1]).Date) +
                            " to " + string.Format("{0:MMM. dd}", DateTime.Parse(_roomAndToDate[1]).Date) + ". \r\nDo you want to continue selecting this room? \r\nClick on Ok to select the room, else click on Cancel.",
                            "Room Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                        if (rsp == DialogResult.Cancel)
                        {
                            this.Parent.Cursor = Cursors.Default;
                            return;
                        }

						if (i > 1)
						{
							this.grdFolioSchedule.Rows.Count += 1;
						}
						int _row = this.grdFolioSchedule.Rows.Count - 1;


						// ROOM NO on COL[0]
						string _roomFrom = _roomAndFromDate[0];
						this.grdFolioSchedule.SetData(_row, 0, _roomFrom);

						if (DateTime.Parse(_roomAndFromDate[1]).Date == DateTime.Parse(_roomAndToDate[1]).Date)
						{
							_roomAndToDate[1] = string.Format("{0:yyyy-MMM-dd}", DateTime.Parse(_roomAndToDate[1]).AddDays(1).Date);
						}
						_roomAndFromDate[1] = string.Format("{0:yyyy-MMM-dd}", DateTime.Parse(_roomAndFromDate[1]).Date);
						_roomAndToDate[1] = string.Format("{0:yyyy-MMM-dd}", DateTime.Parse(_roomAndToDate[1]).Date);

						DateTime _fromDate = DateTime.Parse(_roomAndFromDate[1]);
						DateTime _toDate = DateTime.Parse(_roomAndToDate[1]);

						// SCHEDULE DATES on COL[2] & COL[3]
						this.grdFolioSchedule.SetData(_row, 2, _fromDate);
						this.grdFolioSchedule.SetData(_row, 3, _toDate);

						// to update schedule on grid
						this.grdFolioSchedule_AfterEdit(this, new RowColEventArgs(_row, 3)); // todate
						this.grdFolioSchedule_AfterEdit(this, new RowColEventArgs(_row, 0)); // room no
						this.grdFolioSchedule_AfterEdit(this, new RowColEventArgs(_row, 5)); // rate type

						i = i + 1;
					}

				}

				int noOfDaysInDp = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dtpAutoFromDate.Value.Date, dtpAutoToDate.Value.Date);
				if (noOfDaysInDp == 0 || noOfDaysInDp == 1)
				{
					noOfDaysInDp = 1;
				}

				if (this.grdFolioSchedule.Rows.Count < 1 && noOfDaysInDp > 0)
				{
					MessageBox.Show("No Rooms Available. Please select different room type.", "No Vacant Room", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

				}
			}
			catch (Exception)
			{ }

			this.Parent.Cursor = Cursors.Default;
		}

		RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();

		ArrayList rDummy;
		private ArrayList fillRoomDateCollections(bool flagForGetRoom, string roomidPar)
		{
			RoomFacade oRoomFacade = new RoomFacade();
			ArrayList room = oRoomFacade.getRoomsByRoomType(this.cboRoomType.Text);
			DataTable dTable;
			DateTime dFrom = this.dtpAutoFromDate.Value;
			ArrayList roomDateCollections = new ArrayList();
			roomDateCollections.Clear();
			bool flag = false;
			int noOfDaysInDp = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dtpAutoFromDate.Value, dtpAutoToDate.Value);
			FolioFacade fFacade = new FolioFacade();
			int dCounter = 0;
			DateTime temp = DateTime.Parse(GlobalVariables.gAuditDate);
			DateTime dTime = dtpAutoFromDate.Value;
			string roomid = roomidPar;
			rDummy = new ArrayList();
			string dateStop;
			int idx = -1;

			if (roomid != "" && roomid != "-ROOM")
			{
				idx = room.IndexOf(roomid);

				for (int i = idx; i < room.Count; i++)
				{
					rDummy.Add(room[i]);

				}
				foreach (string val in room)
				{
					if (val == roomid)
						break;
					else
						rDummy.Add(val);
				}
			}

			if (flagForGetRoom == true)
			{
				dFrom = this.dtpAutoFromDate.Value;

			}
			int loopCount = 0;
			while (dTime.Date < dtpAutoToDate.Value.Date)
			{
				if (rDummy.Count > 0)
					room = rDummy;

				dateStop = dTime.Date.ToShortDateString();
				loopCount++;
				foreach (string str in room)
				{

					if (flagForGetRoom == false)
						dTime = dFrom;

					if (flagForGetRoom == true)
					{
						dFrom = this.dtpAutoFromDate.Value;

					}
					bool isFromDate = false;
					bool isToDate = false;
					bool isOkToReserve = false;
					string folio1 = "";
					string folio2 = "";
					flag = false;

					for (int i = -1; i <= noOfDaysInDp; i++)
					{

						bool inBlock = oRoomBlockFacade.CheckIfRoomIsBlock(str, string.Format("{0:yyyy-MM-dd}", dFrom), "");
						dTable = fFacade.checkAvailableRoom(str, this.cboRoomType.Text, string.Format("{0:yyyy-MM-dd}", dFrom.Date));
						//  if(flagForGetRoom==false)
						//      MessageBox.Show(string.Format("{0:yyyy-MM-dd}", dFrom.Date) + ":" + str);
						if (dTable.Rows.Count == 0)
							isOkToReserve = true;

						if (dTable.Rows.Count == 1)
						{
							if (string.Format("{0:yyyy-MM-dd}", dTable.Rows[0]["fromdate"]) == string.Format("{0:yyyy-MM-dd}", dFrom.Date))
							{
								folio1 = dTable.Rows[0]["folioid"].ToString();
								isFromDate = true;
							}
							if (string.Format("{0:yyyy-MM-dd}", dTable.Rows[0]["todate"]) == string.Format("{0:yyyy-MM-dd}", dFrom.Date))
							{
								folio2 = dTable.Rows[0]["folioid"].ToString();
								isToDate = true;
							}
						}
						if (dTable.Rows.Count > 1)
						{
							isOkToReserve = false;
							continue;
						}

						if (isToDate && flag == false)
						{
							isOkToReserve = true;
						}
						if (flag == true && isFromDate)
						{
							isOkToReserve = false;
							break;
						}
						if (isToDate == true && dFrom.Date == dtpAutoFromDate.Value.Date)
							isOkToReserve = true;

						if (isOkToReserve && dFrom.Date < this.dtpAutoToDate.Value.Date && !inBlock)
						{
							if (this.dtpAutoFromDate.Value == this.dtpAutoToDate.Value)
							{
								roomDateCollections.Add(str + "#" + string.Format("{0:yyyy-MMM-dd}", dFrom.Date));
								roomDateCollections.Add(str + "#" + string.Format("{0:yyyy-MMM-dd}", dFrom.Date));
								goto endLoop;
							}
							if (flag == false)
							{
								roomDateCollections.Add(str + "#" + string.Format("{0:yyyy-MM-dd}", dFrom.Date));
								flag = true;
							}

							temp = dFrom;
							dFrom = dFrom.AddDays(1);
							dCounter++;
						}
						else
						{
							dCounter--;
							break;
						}
					}
					if (flag == true)
					{
                        if (dFrom.Date > this.dtpAutoToDate.Value.Date)
                        {
                            roomDateCollections.Add(str + "#" + string.Format("{0:yyyy-MM-dd}", temp.Date));
                            goto endLoop;
                        }
                        else
                        {
                            roomDateCollections.Add(str + "#" + string.Format("{0:yyyy-MM-dd}", dFrom.Date));
                        }
					}
				}

				if (flagForGetRoom == true)
					dTime = dtpAutoToDate.Value;
				if (loopCount > 2 && dateStop == dTime.Date.ToShortDateString())
					goto endLoop;

			}
		endLoop:
			;
			return roomDateCollections;
		}

		string getRoomId(ArrayList arrList)
		{

			int size = arrList.Count;
			int val = 0, n1;

			string roomid = "";
			for (int i = 0; i < size; i++)
			{
				if (i == 0 && i < size)
				{
					string[] firstVal = arrList[i].ToString().Split(new char[] { '#' });
					string[] secVal = arrList[i + 1].ToString().Split(new char[] { '#' });

					if (firstVal.Length > 1 && secVal.Length > 0)
					{
						val = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(firstVal[1]), DateTime.Parse(secVal[1]));
						roomid = firstVal[0];
					}
					i += 1;
				}
				else if (i < size)
				{
					string[] firstVal = arrList[i].ToString().Split(new char[] { '#' });
					string[] secVal = arrList[i + 1].ToString().Split(new char[] { '#' });
					if (firstVal.Length > 1 && secVal.Length > 0)
					{
						n1 = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, DateTime.Parse(firstVal[1]), DateTime.Parse(secVal[1]));
						if (n1 > val)
						{
							val = n1;
							roomid = firstVal[0];
						}

					}
					i += 1;
				}

			}
			return roomid;
		}

		#endregion

		private void txtGuestImage_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.picGuestImage.Image = System.Drawing.Image.FromFile(this.txtGuestImage.Text);
			}
			catch { }
		}

		private void rdoApplyCompanyPrivileges_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoApplyCompanyPrivileges.Checked)
			{
				if (loFolio.Company != null)
				{
					showCompanyPrivileges(loFolio.Company.AccountPrivileges);
					//showGuestPrivileges(loFolio.Company.AccountPrivileges);
				}

			}
			else
			{
				removeAccountPrivileges();
			}
		}

		private void chkApply_CheckedChanged(object sender, EventArgs e)
		{
			if (chkApply.Checked == true)
			{
				gbxApplyPrivileges.Enabled = true;
			}
			else
			{
				gbxApplyPrivileges.Enabled = false;
				rdoApplyCompanyPrivileges.Checked = false;
				rdoApplyGuestPrivilege.Checked = false;
			}
		}

		private void btnCheckOutDependentGuest_Click(object sender, EventArgs e)
		{
			if (this.grdDependentGuests.Rows.Count > 1)
			{
				int _row = this.grdDependentGuests.Row;
				string _folioId = this.grdDependentGuests.GetDataDisplay(_row, 7);
				string _guestName = this.grdDependentGuests.GetDataDisplay(_row, 2) + ", " + this.grdDependentGuests.GetDataDisplay(_row, 3);

				if (loFolio.Status == "ONGOING")
				{
					DialogResult rsp = MessageBox.Show("Check-out guest " + _guestName + " ?  ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
					if (rsp == DialogResult.No)
						return;
				}
				else
				{
					DialogResult rsp = MessageBox.Show("Cancel reservation for guest " + _guestName + " ?  ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
					if (rsp == DialogResult.No)
						return;
				}

				//if has folioId means Guest already reserved
				if (_folioId != "")
				{
					switch (loFolio.Status)
					{
						case "ONGOING":// check-out guest
							try
							{
								loControlListener.StopListen(this);

								loFolioFacade.checkOutFolio(_folioId, "", "JOINER GUEST-CLOSED");

								loControlListener.Listen(this);
							}
							catch (Exception ex)
							{
								MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
								return;
							}
							break;

						case "CONFIRMED": // cancel reservation
						case "TENTATIVE": // cancel reservation
							try
							{
								loControlListener.StopListen(this);

								// prompts for REASON for CANCEL
								ReasonForCancelUI reasonUI = new ReasonForCancelUI();
								string _reason = reasonUI.showDialog();

								if (_reason == "")
									return;

								loFolioFacade.cancelFolio(_folioId, _reason);

								loControlListener.Listen(this);
							}
							catch (Exception ex)
							{
								MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
								return;
							}
							break;
					}
				}

				this.grdDependentGuests.RemoveItem(_row);

				// Change numbering
				for (int i = 1; i < this.grdDependentGuests.Rows.Count; i++)
				{
					this.grdDependentGuests.SetData(i, 0, i);
				}

                // >> to update number of pax
                //loControlListener.StopListen(this);
                this.nudNoOfAdults.Value = this.grdDependentGuests.Rows.Count;
                //loFolioFacade.updateFolioPax(loFolio.FolioID, nudNoOfAdults.Value);
                //loControlListener.Listen(this);

                ////>> update folio
                //loControlListener.StopListen(this);
                //this.nudNoOfAdults.Value = this.grdDependentGuests.Rows.Count;
                //if (!assignFolioValues())
                //{
                //    this.MdiParent.Cursor = Cursors.Default;
                //    return;
                //}

                //try
                //{
                //    switch (lUIMode)
                //    {
                //        case UIMode.Add:

                //            loFolioFacade.SaveFolio(loFolio);
                //            break;

                //        case UIMode.Edit:

                //            loFolioFacade.updateFolio(loFolio);
                //            this.Text = this.Text.Replace("*", "");
                //            break;
                //    }
                //}
                //catch { }
                //loControlListener.Listen(this);
			}
		}

		private void deAllocateRoom_Click(object sender, EventArgs e)
		{
			if (txtStatus.Text != "ONGOING")
			{
				if (MessageBox.Show("Are you sure you want to set this reservation to Wait List?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					bool hasBalance = false;

					decimal balance = 0;
					foreach (SubFolio subF in loFolio.SubFolios)
					{
						subF.Ledger = loFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
						balance = subF.Ledger.BalanceNet;
						if (balance != 0)
						{
							hasBalance = true;
						}
					}
					if (hasBalance)
					{
                        if (bool.Parse(ConfigVariables.gAllowDeAllocateWithBalance) == true)
                        {
                            DialogResult rsp = MessageBox.Show("Guest still has unsettled account.\r\nDo you want to continue?", "Folio Plus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rsp == DialogResult.No)
                            {
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot de-allocate room.\r\nGuest still has unsettled account.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
					}

					lOperationMode = ReservationOperationMode.WaitList;
					initializeNewGuestReservation();
					this.cboFolioType.SelectedIndex = 0;
					this.txtStatus.Text = "WAIT LIST";
				}
			}
			else
			{
				MessageBox.Show("Cannot de-allocate a room that is already checked-in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ReservationFolioUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void dtpArrivalTime_ValueChanged(object sender, EventArgs e)
		{
			txtActualETA.Text = dtpArrivalTime.Value.ToString("hh:mm tt");
		}

		private void grdDependentGuests_RowColChange(object sender, EventArgs e)
		{
			if (grdDependentGuests.Col == 9)
			{
				this.grdDependentGuests.AllowEditing = true;
			}
			else
			{
				this.grdDependentGuests.AllowEditing = false;
			}
		}

        private void cmuSchedule_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (loFolio.FolioID == null)
            {
                deAllocateRoom.Enabled = false;
            }
            else
            {
                deAllocateRoom.Enabled = true;
            }
        }

		string lOldRateType = "";
		string lOldRoomType = "";
        string lOldRoomNumber = "";
		private void grdFolioSchedule_BeforeEdit(object sender, RowColEventArgs e)
		{
			switch (e.Col)
			{
                case 3:
                    if (grdFolioSchedule.Rows.Count > 1)
                    {

                    }
                    else
                    {

                    }
                    break;
				case 5:
                    lOldRoomNumber = this.grdFolioSchedule.GetDataDisplay(e.Row, 0);
					lOldRateType = this.grdFolioSchedule.GetDataDisplay(e.Row, 5);
					lOldRoomType = this.grdFolioSchedule.GetDataDisplay(e.Row, 1);
					break;

                case 6:
                    string _priv = "Override pre-configured room rates";

                    VerifyUserUI _oVerifyUserUI = new VerifyUserUI(_priv);
                    if (!_oVerifyUserUI.showDialog(GlobalVariables.gLoggedOnUser))
                    {
                        if (!_oVerifyUserUI.showDialog())
                        {
                            //exit if not authorized to void
                            return;
                        }
                    }
                    break;
			}
		}

        private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
        {
            dtpActualETD.Value = DateTime.Parse(dtpDepartureDate.Text);
        }

        private void dtpActualETD_ValueChanged(object sender, EventArgs e)
        {
            txtActualETD.Text = dtpActualETD.Value.ToString("hh:mm tt");
        }

        private void grdFolioSchedule_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (cboFolioType.Text == "DEPENDENT")
                {
                    if (grdFolioSchedule.Rows.Count == 2)
                    {
                        deleteScheduleToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        deleteScheduleToolStripMenuItem.Enabled = true;
                    }

                    deAllocateRoom.Enabled = false;
                }
                else
                {
                    deleteScheduleToolStripMenuItem.Enabled = true;
                    deAllocateRoom.Enabled = true;
                }

                if (int.Parse(ConfigVariables.gAutoRoomingEnabled) == 1)
                {
                    tsmTransferRoom.Enabled = true;
                }
                else
                {
                    tsmTransferRoom.Enabled = false;
                }
            }
        }

        private void grdFolioSchedule_AfterRowColChange(object sender, RangeEventArgs e)
        {
            try
            {
                DateTime _lastDate = DateTime.Parse(grdFolioSchedule.GetDataDisplay(grdFolioSchedule.Rows.Count - 1, 3));
                dtpDepartureDate.Text = _lastDate.ToString("dd-MMM-yyyy");
                txtToDate.Text = _lastDate.ToString("dd-MMM-yyyy");

                loadHotelPackages();
            }
            catch { }
        }

        private void grdRecurringCharges_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 5)
            {
                IList<TransactionCode_SubAccount> _transSubAccounts;
                TransactionCode_SubAccountFacade _oTransFacade = new TransactionCode_SubAccountFacade();
                _transSubAccounts = _oTransFacade.loadTransactionCodeSubAccounts(grdRecurringCharges.GetDataDisplay(e.Row, 0));
                lRecurringCombo.DisplayMember = "SubAccountCode";
                lRecurringCombo.ValueMember = "SubAccountCode";
                lRecurringCombo.DataSource = _transSubAccounts;

                grdRecurringCharges.Cols[5].Editor = lRecurringCombo;
            }
        }

        private void grdRecurringCharges_StartEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 5)
            {
                IList<TransactionCode_SubAccount> _transSubAccounts;
                TransactionCode_SubAccountFacade _oTransFacade = new TransactionCode_SubAccountFacade();
                _transSubAccounts = _oTransFacade.loadTransactionCodeSubAccounts(grdRecurringCharges.GetDataDisplay(e.Row, 0));
                lRecurringCombo.DisplayMember = "SubAccountCode";
                lRecurringCombo.ValueMember = "SubAccountCode";
                lRecurringCombo.DataSource = _transSubAccounts;

                grdRecurringCharges.Cols[5].Editor = lRecurringCombo;
            }
        }

        private void cmReplaceJoiner_Click(object sender, EventArgs e)
        {
            string _FolioID = grdDependentGuests.GetDataDisplay(grdDependentGuests.Row, 7);
            string _arrival = (grdDependentGuests.GetDataDisplay(grdDependentGuests.Row, 9));
            if (MessageBox.Show("Are you sure you want to replace this joiner?", "Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string _whereCondition = "AccountId <> '" + this.txtAccountID.Text + "' and ";
                for (int i = 1; i < this.grdDependentGuests.Rows.Count; i++)
                {
                    _whereCondition += "AccountId <> '" + this.grdDependentGuests.GetDataDisplay(i, 1) + "' and ";
                }
                _whereCondition = _whereCondition.Substring(0, _whereCondition.Length - 4);

                GuestUI guestLookUp = new GuestUI(ref this.grdDependentGuests, "REPLACE");
                guestLookUp.showDialog(_whereCondition);

                if (txtAccountID.Text != ConfigVariables.gDefault_Guest)
                    this.nudNoOfAdults.Value = this.grdDependentGuests.Rows.Count;
                else
                    this.nudNoOfAdults.Value = grdDependentGuests.Rows.Count - 1;

                grdDependentGuests.SetData(grdDependentGuests.Row, 7, _FolioID);
                grdDependentGuests.SetData(grdDependentGuests.Row, 8, _arrival);
                txtRemarks.Text += " ";
            }
        }

        private void btnAddRequirements_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRequirementNote.Text == "")
                {
                    CellRange _range = grdInclusions.Selection;

                    for (int i = _range.r1; i <= _range.r2; i++)
                    {
                        grdFolioInclusions.AddItem(grdInclusions.GetDataDisplay(i, 0));
                    }
                }
                else
                {
                    grdFolioInclusions.AddItem(txtRequirementNote.Text);
                }

                txtRemarks.Text += " ";
                txtRequirementNote.Text = "";
            }
            catch { }
        }

        private void btnRemoveRequirements_Click(object sender, EventArgs e)
        {
            try
            {
                grdFolioInclusions.RemoveItem(grdFolioInclusions.Row);
                txtRemarks.Text += " ";
            }
            catch { }
        }

        private void loadFolioInclusions()
        {
            try
            {
                this.grdFolioInclusions.Rows.Count = loFolio.Inclusions.Count;
                int i = 0;
                foreach (FolioInclusions _oFolioInclusions in loFolio.Inclusions)
                {
                    this.grdFolioInclusions.SetData(i, 0, _oFolioInclusions.Memo);
                    i++;
                }
            }
            catch { }
        }

        private void tsmTransferRoom_Click(object sender, EventArgs e)
        {

        }
	}
}
