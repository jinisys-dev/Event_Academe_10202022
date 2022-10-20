#region " REFERENCES "
using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.JScript;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.IO;
using SAP_SDK;
using Jinisys.Hotel.Cashier.Presentation;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Accounts.DataAccessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Security.BusinessLayer;
using Jinisys.Hotel.NightAudit.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;
using Jinisys.Hotel.Utilities.BusinessLayer;

using MySql.Data.MySqlClient;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
#endregion

using C1.Win.C1FlexGrid;

namespace Jinisys.Hotel.Reservation.Presentation
{
	public class GroupReservationUI : Jinisys.Hotel.UIFramework.TransactionUI
	{

		#region " Windows Form Designer generated lCode "

		public GroupReservationUI()
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
            loadGroupBookingDropDown();

            loSequence = new Sequence();
            loFolioFacade = new FolioFacade();
            loFolio = new Folio();
            //lFolioNo = loSequence.getSequenceId("F-", 12, "seq_folio");
            //txtFolioID.Text = lFolioNo;
            txtFolioID.Text = "AUTO";

            txtCreateTime.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Now);
            txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;

            cboStatus.Text = "TENTATIVE";
            cboAccountType.Text = AccountType.Corporate.ToString().ToUpper();
            cboPayment_Mode.Text = "CASH";
            cboPurpose.Text = "BUSINESS";
            rdbCompany.Checked = true;

            lGroupFolioStatus = "New";
            pnlNew.Visible = true;
            lFlag = "New";

            KeypressTextboxHandler(this, false);
            getCharges(grdRecurringCharges);
            getCharges(gridTransactionCodes);
            loadCountries();

            //by Genny: Apr. 30, 2008
            //get all Room Types
            RoomType _oRoomType = new RoomType();
            RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();
            _oRoomType = (RoomType)_oRoomTypeFacade.loadObject();

            DataView _dtvRoomTypes = _oRoomType.Tables[0].DefaultView;
            _dtvRoomTypes.RowStateFilter = DataViewRowState.OriginalRows;
            _dtvRoomTypes.RowFilter = "roomTypeCode not like '*FUNCTION*'";
            foreach (DataRowView _dRow in _dtvRoomTypes)
            {
                string[] items ={ _dRow["roomtypecode"].ToString(), "0", "0", "0", "0", "0", "0", "0" };
                gridRooms.AddItem(items);
            }
            grdFolio.Sort(SortFlags.Ascending, 2, 3);//<<
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

		//Required by the Windows Form Designer

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the lCode editor.
		public System.Windows.Forms.ColumnHeader headerType;
		public System.Windows.Forms.ColumnHeader headerRate;
		public System.Windows.Forms.ColumnHeader headerTo;
		public System.Windows.Forms.ColumnHeader headerDays;
		public System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.ComboBox cboStatus;
		public System.Windows.Forms.Button btnBrowseAccount;
		public System.Windows.Forms.Label Label43;
		public System.Windows.Forms.TextBox txtFolioID;
		public System.Windows.Forms.Label Label40;
		public System.Windows.Forms.ColumnHeader headerRoomno;
		internal System.Windows.Forms.Timer tmrFolio;
		public System.Windows.Forms.ColumnHeader headerAmount;
		public System.Windows.Forms.ColumnHeader headerFrom;
        internal System.Windows.Forms.ImageList imgIcon;
        internal System.Windows.Forms.TextBox txtbreakfast;
		internal System.Windows.Forms.Button btnCheckIN;
        public System.Windows.Forms.Button btnCheckOut;
		internal System.Windows.Forms.Panel pnlStatus;
		internal System.Windows.Forms.TextBox txtFolioTYpe;
		internal System.Windows.Forms.TextBox txtAccountType;
		internal System.Windows.Forms.TextBox txtcompanyid;
		internal System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Button btnBrowseAgent;
		internal System.Windows.Forms.TextBox txtAgentname;
		internal System.Windows.Forms.TextBox txtagentid;
		internal System.Windows.Forms.ContextMenu mnuOption;
		internal System.Windows.Forms.MenuItem mnuNew;
		internal System.Windows.Forms.MenuItem mnuEdit;
		internal System.Windows.Forms.MenuItem MenuItem1;
		internal System.Windows.Forms.MenuItem mnuConfirm;
		internal System.Windows.Forms.MenuItem mnuCheckin;
		internal System.Windows.Forms.MenuItem mnuCheckOut;
		internal System.Windows.Forms.MenuItem mnuNoShow;
		internal System.Windows.Forms.MenuItem mnuCancel;
		public System.Windows.Forms.Label Label21;
		internal System.Windows.Forms.ContextMenu mnulvwCommands;
		internal System.Windows.Forms.MenuItem mnuDeleteCharge;
		internal System.Windows.Forms.ToolTip tipGroup;
		internal TextBox txtCreateTime;
		public Label label34;
		internal TextBox txtTHRESHOLD_VALUE;
		public Label label36;
		internal TextBox txtTotal_Sales_Contribution;
		public Label label35;
		internal TextBox txtAccount_Type;
		public Label label15;
		private Panel pnlDate;
		public Label label38;
		private TabPage tabFoodBev_;
		internal Panel panel4;
		public Button btnSaveMeal;
		internal Panel panel6;
		internal Button btnNewMeal;
		internal Button btnAddDate;
		private TabPage tabRooms_;
		private TabPage tabWedding_;
        public Button btnSaveRequirements;
		private GroupBox grpRequirements;
		public Button btnRemoveRequirements;
		public Button btnAddRequirements;
		private TreeView treeRequirements;
		private ListView lvwDetails;
		public Label label45;
		internal ComboBox cboRequirementType;
		private GroupBox grpEventDetails;
		private C1.Win.C1FlexGrid.C1FlexGrid gridEventDetails;
		private TabPage tabEventDetails_;
		private GroupBox grpBillingDeposits;
		private C1.Win.C1FlexGrid.C1FlexGrid gridBilling;
		private ComboBox cboBillRates;
		private GroupBox grpNotesRemarks;
		internal TextBox txtLobbyPosting;
		public Label label65;
		internal TextBox txtSignatories;
		public Label label44;
		internal TextBox txtBillingArrangement;
		public Label label42;
        public NumericUpDown nudPaxGuaranteed;
		public NumericUpDown nudNumberOfPaxLiveOut;
		public Label lblLiveOut;
		public Label lblLiveIn;
		public NumericUpDown nudNumberOfPaxLiveIn;
		internal GroupBox groupBox11;
		private ComboBox cboEventType;
		public Label label37;
		internal RadioButton radioButton3;
		private GroupBox grpInfo;
		internal TextBox txtDesignation;
		public Label label27;
		internal TextBox txtContactNumber1;
        public Label label28;
		public Label label30;
		internal TextBox txtContactPerson;
		public Label label33;
		internal TabPage TabRecurringCharge;
		internal Button btnRemoveRecurringCharge;
		internal Button btnAddRecurringCharge;
		internal Button btnSaveRecurringCharge;
        internal TabPage tabPackage;
        internal TabPage tabPrivilege;
		public TabPage tabBooking;
		private ComboBox cboPurpose;
		public Label label58;
		private ComboBox cboPayment_Mode;
		public Label label57;
		private ComboBox cboAccountType;
		public Label label56;
		public TextBox txtCreatedBy;
		public Label label47;
		private ComboBox cboSales_Executive;
        public Label label48;
		public Label Label7;
		internal NumericUpDown nudNoofDays;
		public Label Label5;
		internal TextBox txtPromo;
		public Label Label9;
		public Label Label6;
		public TabControl tabFolio_;
		public Label label46;
		internal TextBox txtEventType;
        internal Label label49;
		private TabPage tabBillingInfo;
		internal Button btnRemoveCharge;
		internal Button btnSaveRouting;
		internal Label label52;
		internal C1.Win.C1FlexGrid.C1FlexGrid gridBillingInfo;
		internal RadioButton rdoAmount;
		internal RadioButton rdoPercent;
		internal Label label53;
		//internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdBillingCharge;
		internal Label label54;
		internal Label label55;
		internal Label label59;
		//internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic c1FlexGridClassic1;
		private ComboBox cboSource;
		public Label label63;
		private RadioButton rdbIndividual;
        private RadioButton rdbCompany;
		internal ListView lvwBrowseGuestName;
		internal ColumnHeader columnHeader38;
		internal ColumnHeader columnHeader39;
        internal ColumnHeader columnHeader40;
		private TreeView treeFoodBev;
		private GroupBox grpMealDetails;
		private ListView lvwMenus;
		private ColumnHeader Description;
		private ColumnHeader columnHeader25;
		private ColumnHeader columnHeader28;
		public Label label16;
		internal ComboBox cboMealType;
        private C1.Win.C1FlexGrid.C1FlexGrid gridMealItems;
        internal Label label31;
		internal Label label32;
		internal TextBox txtFoodOver;
		internal Label label95;
		internal Label label96;
		private DateTimePicker dtpFoodDate;
		internal TextBox txtFoodRemarks;
		internal Label label97;
		internal TextBox txtFoodSetup;
		internal Label label98;
		internal TextBox txtVenueFood;
        internal Label label99;
		public Button btnPostCharges;
		public Label label69;
		internal TextBox txtPackageAmount;
		internal TextBox txtRequirementNote;
		internal NumericUpDown txtTotalMealAmount;
		internal Label label71;
		public Button btnPrintContract;
		private NumericUpDown nudMealLiveIn;
		internal Label lblLiveInFood;
        private NumericUpDown nudMealLiveOut;
        internal Label lblLiveOutFood;
		internal TextBox txtTotalEstimatedCost;
        public Label label70;
		public Button btnBlock;
		internal Panel pnlNew;
		internal Button btnCancelReservation;
		public Button btnSave;
		public Button btnEdit;
		private C1.Win.C1FlexGrid.C1FlexGrid gridTransactionCodes;
		private C1.Win.C1FlexGrid.C1FlexGrid grdRecurringCharges;
        private C1.Win.C1FlexGrid.C1FlexGrid grdRecurredCharge;
		internal Label label41;
		internal ComboBox cboEventGrpPackage;
		internal TextBox txtContactNumber2;
		public Label label72;
        internal TextBox txtContactNumber3;
		public Label label68;
		private C1.Win.C1FlexGrid.C1FlexGrid grdDeposits;
		internal Label label51;
		internal ContextMenu mnuSchedule;
		internal MenuItem mnuAddItem;
		internal MenuItem mnuDelete;
		internal MenuItem menuItem2;
        internal MenuItem mnuRefreshSchedule;
        private GroupBox grpDependentsRoom;
		private C1.Win.C1FlexGrid.C1FlexGrid gridRooms;
        private C1.Win.C1FlexGrid.C1FlexGrid gridFunctionRooms;
		private GroupBox groupBox7;
        internal Label label87;
        internal TextBox txtRoomRemarks;
        public NumericUpDown nudGuaranteedRooms;
        public NumericUpDown nudRooms;
        public NumericUpDown nudGuaranteedPax;
        internal Label label91;
        internal Label label92;
        internal Label label93;
        internal Label label94;
        public NumericUpDown nudPax;
        private DateTimePicker dtpTime;
        private C1.Win.C1FlexGrid.C1FlexGrid gridBlockedRooms;
        internal Button btnFolio;
        public Button btnClose;
        internal Panel pnlFolio;
        public Button btnBookingSheet;
        public Button btnNewDeposit;
        private TextBox cboEventPackage;
        internal Button btnAddDateCancel;
        internal Button btnAddDateOK;
        internal TextBox txtDepartureDate;
        internal Label label76;
        internal Label label77;
        public Label label78;
        private C1.Win.C1FlexGrid.C1FlexGrid grdFolioPrivileges;
        internal Button btnGuestPrivileges_Remove;
        internal Button btnGuestPrivilege_Add;
        internal CheckBox chkApply;
        internal GroupBox gbxApplyPrivileges;
        private ListView lvwCompanyPrivileges;
        private ColumnHeader columnHeader7;
        private ListView lvwGuestPrivileges;
        private ColumnHeader columnHeader6;
        private RadioButton rdoApplyCompanyPrivileges;
		private RadioButton rdoApplyGuestPrivilege;
		public TextBox txtBIMemo;
		public TextBox txtBICode;
		internal Label label50;
		internal Label label62;
		private TabPage tabRoomRequirements;
		private GroupBox groupBox5;
		internal Label label79;
        internal Label label80;
        private GroupBox groupBox8;
		internal Label label67;
		private GroupBox groupBox9;
        private NumericUpDown nudMealPax;
        internal Label label26;
		private GroupBox groupBox10;
		public Label label29;
        private GroupBox groupBox12;
        internal GroupBox groupBox13;
		internal ComboBox cboMealGroups;
		internal Button btnAddMenu;
		internal Button btnRemoveMenu;
        internal Button btnRemoveFunctionSchedule;
        internal Button btnAddFunctionSchedule;
        internal DateTimePicker txtStartMealTime;
        internal ListView lvwBrowseCompany;
        internal ColumnHeader ColumnHeader1;
        internal ColumnHeader ColumnHeader2;
        internal TextBox txtFolioPackageDaysApplied;
        public Label label2;
        internal Label label8;
        internal Label label64;
        private C1.Win.C1FlexGrid.C1FlexGrid grdFolioPackage;
        internal Label label13;
        private C1.Win.C1FlexGrid.C1FlexGrid grdHotelPromos;
        internal Button btnAddHotelPromo;
        internal Button btnRemoveHotelPromo;
        internal Label label22;
        private ContextMenuStrip mnuDependents;
        private ToolStripMenuItem mnuUnblock;
        private ToolStripMenuItem mnuCancelBlock;
        private ToolStripMenuItem mnuCancelReservation;
        internal TextBox txtZip1;
        internal TextBox txtCountry1;
        internal TextBox txtCity1;
        internal TextBox txtStreet1;
        public Label label25;
        public Label label24;
        public Label label23;
        private TableLayoutPanel tableLayoutPanel1;
		public Label label39;
		public Button btnManualBlockRooms;
		private TextBox txtGroupRemarks;
		public Label label66;
        internal GroupBox GroupBox2;
        public Label label83;
        public Label label84;
        private DateTimePicker dtpTodate;
        private DateTimePicker dtpFromDate;
        internal TextBox txtArrivalDate;
        internal DateTimePicker dtpFolioETD;
        public Label label60;
        internal DateTimePicker dtpFolioETA;
        public Label label73;
        private DateTimePicker dtpEventTo;
        private DateTimePicker dtpEventFrom;
        public Label label81;
        public Label label82;
        public TextBox txtUpdatedBy;
        public Label label74;
        private DateTimePicker dtpPackageDateTo;
        public Label label75;
        private DateTimePicker dtpPackageDateFrom;
        public Label label85;
        public TextBox txtGroupName;
        internal GroupBox GroupBox1;
        internal TextBox txtGrpTotal;
        internal Label label88;
        internal Label Label10;
        internal Label lblOverStay;
        internal Label Label12;
        internal Label lblNoShow;
        internal Label Label14;
        internal Label lblCheckout;
        internal Label lblCheckIn;
        internal Label Label19;
        internal TextBox txtSearch;
        internal Label Label11;
        internal Label Label20;
        internal TextBox txtBalance;
        internal TextBox txtAmount;
        public CheckBox chkBreakFst;
        internal Label Label17;
        internal Label Label18;
        private C1FlexGrid grdFolio;
        private TabPage tabAmmendments;
        private GroupBox groupBox3;
        private C1FlexGrid grdAmmendments;
        private GroupBox grpNewAmendments;
        internal Button btnNewAmmendment;
        internal Button btnSaveAmmendment;
        internal Button btnPrintAmmendments;
        private Label label86;
        internal TextBox txtAmendmentNo;
        public Label label89;
        internal TextBox txtOldValue;
        public Label label90;
        internal TextBox txtNewValue;
        private Panel pnlAmendments;
        private TableLayoutPanel tblFoodBevOthers;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        internal Label lblPaxAmt;
        internal NumericUpDown nudPaxAmt;
        internal TextBox txtEmail1;
        public Label label100;
        private TabPage tabEventRequirements;
        private Label label101;
        private C1FlexGrid gridReqSchedules;
        private Panel panel2;
        private Panel panel3;
        private GroupBox groupBox4;
        private Button btnreinstate;
        private Button btnPrintEstimatedCharges;
        private GroupBox groupBox6;
        private C1FlexGrid grdSystemChanges;
        private TextBox txtReferenceNo;
        private Label label102;
        private Label label103;
        private GroupBox groupContacts;
        private C1FlexGrid gridContacts;
        private TextBox txtEventDate;
        private Label label106;
        private C1FlexGrid gridEventOfficer;
        private C1FlexGrid gridAmendmentSchedules;
        private Button btnAmendmentArrow;
        private TabPage tabEndorsement;
        private Label label107;
        private Label label108;
        private ComboBox cboLetterOfProposal;
        private Label label109;
        private TextBox txt25RF1;
        private TextBox txt25RF2;
        private Label label111;
        private TextBox txt50RF;
        private Label label110;
        private TextBox txtBalanceRF;
        private Label label112;
        private GroupBox groupReservationFee;
        private GroupBox groupBox14;
        private RadioButton rdoReturned;
        private RadioButton rdoSentToClient;
        private RadioButton rdoForPickup;
        private RadioButton rdoBeingProcessed;
        private DateTimePicker dtpForPickUp;
        private DateTimePicker dtpSentToClient;
        private DateTimePicker dtpSigned;
        private GroupBox groupForEMDAction;
        private C1FlexGrid gridEMDActions;
        private TabPage tabCancellation;
        private Label label114;
        private Label label113;
        private TextBox txtReasons;
        private TextBox txtFutureAction;
        private Button btnSaveCancellation;
        private DateTimePicker dtpBirthDate;
        private ContextMenuStrip mnuContactPerson;
        private ToolStripMenuItem mnuAddContact;
        private ToolStripMenuItem mnuRemoveContact;
        private ContextMenuStrip mnuEventOfficers;
        private ToolStripMenuItem mnuAddEventOfficer;
        private ToolStripMenuItem mnuRemoveEventOfficer;
        private DateTimePicker dtp25RF1;
        private Label label115;
        private DateTimePicker dtp25RF2;
        private DateTimePicker dtp50RF;
        internal DateTimePicker txtEndMealTime;
        private ContextMenuStrip mnuEMDActions;
        private ToolStripMenuItem mnuAddEMDAction;
        private ToolStripMenuItem mnuRemoveEMDAction;
        private C1FlexGrid gridPackageRoom;
        private ComboBox cboReqDate;
        private Panel pnlEstimateCharges;
        internal Button btnPrintEstimated;
        private TextBox txtContingencyDetails;
        private Label label117;
        internal ComboBox cboShowAmount;
        internal Button btnCancelEstimated;
        private Button btnPrintSystemChanges;
        private Label label116;
        private Label lbltest;
        private NumericUpDown nmcQty;
        private ComboBox cboDiscount;
        private ComboBox cboRateTypes;
        private TabPage tabEventAttendance;
        private Label label118;
        private ComboBox cboGeoEventType;
        private Label label119;
        private Label label122;
        private Label label121;
        private Label label120;
        private NumericUpDown nudTotal;
        private NumericUpDown nudLocal;
        private NumericUpDown nudForeign;
        private Label label123;
        private Label label124;
        private NumericUpDown nudForeignBased;
        private NumericUpDown nudLocalBased;
        private Label label125;
        private GroupBox groupBox15;
        private NumericUpDown nudVisitors;
        private Label label126;
        private GroupBox groupBox16;
        private Label label127;
        private Label label128;
        private NumericUpDown nudActualAttendees;
        private Label label129;
        private TextBox txtEventAttendanceRemarks;
        private Panel panel5;
        private Button btnPrintEventAttendance;
        private TextBox txtEventAttendanceNote;
        private Label label130;
        private ComboBox cboCancelBookingType;
        private Label label131;
        private ComboBox cboReason;
        private Label label132;
        private C1FlexGrid gridIncumbentOfficer;
        private ContextMenuStrip mnuIncumbentOfficers;
        private ToolStripMenuItem mnuIncumbentAdd;
        private ToolStripMenuItem mnuIncumbentRemove;
        private GroupBox groupBox17;
        private TextBox txtGiveaways;
        private TextBox txtDiscountConcessions;
        private Label label134;
        private Label label133;
        private NumericUpDown txtContractAmount;
        private TextBox test;
        private NumericUpDown nudTax;
        private Label label135;
        private ComboBox cboUsers;
        private Panel pnlContactList;
        private C1FlexGrid gridContactList;
        private ToolStripMenuItem mnuOpenListContact;
        private Label label136;
        private Button btnOk;
        private Button button2;
        private Label label137;
        private TextBox txtEstimatedBal;
        private GroupBox groupBox18;
        private Button btnExport;
        private SaveFileDialog sfdExport;
        private Button btnUploadLOP;
        private Button btnViewLOP;
        private OpenFileDialog ofdUpload;
        private Label label105;
        private Label label104;
        private Panel pnlCompany;
        internal TextBox txtCompanyName;
        internal TextBox txtCompanyCode;
        internal Label Label4;
        private Panel pnlIndividual;
        public TextBox txtLastName;
        public TextBox txtFirstName;
        public Label label61;
        private DateTimePicker dtpPostingDate;
        private Label label138;
        private Label lblTINNumber;
        private TextBox txtTIN;
        private Button btnUploadAttachments;
        private Button btnViewAttachments;
        private ContextMenuStrip mnuTreeRequirements;
        private ToolStripMenuItem copyToolStripMenuItem;
        internal Button btnConfirm;
        internal Button btnUnconfirm;
        private GroupBox groupBox20;
        private C1FlexGrid c1FlexGrid2;
        private GroupBox groupBox19;
        private Button button6;
        private C1FlexGrid c1FlexGrid1;
        public Label label139;
        internal TextBox textBox1;
        private Label label140;
        internal TextBox textBox2;
        internal TextBox textBox3;
        public Label label141;
        private Panel panel7;
        private Button button1;
        internal Button button3;
        internal Button button4;
        internal Button button5;
		private DateTimePicker dtpAddDate;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupReservationUI));
            this.headerType = new System.Windows.Forms.ColumnHeader();
            this.headerRate = new System.Windows.Forms.ColumnHeader();
            this.headerTo = new System.Windows.Forms.ColumnHeader();
            this.headerDays = new System.Windows.Forms.ColumnHeader();
            this.Label3 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.Label43 = new System.Windows.Forms.Label();
            this.txtFolioID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.headerRoomno = new System.Windows.Forms.ColumnHeader();
            this.tmrFolio = new System.Windows.Forms.Timer(this.components);
            this.headerAmount = new System.Windows.Forms.ColumnHeader();
            this.headerFrom = new System.Windows.Forms.ColumnHeader();
            this.rdbIndividual = new System.Windows.Forms.RadioButton();
            this.rdbCompany = new System.Windows.Forms.RadioButton();
            this.txtcompanyid = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.txtbreakfast = new System.Windows.Forms.TextBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnreinstate = new System.Windows.Forms.Button();
            this.btnCheckIN = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnPostCharges = new System.Windows.Forms.Button();
            this.btnUnconfirm = new System.Windows.Forms.Button();
            this.txtFolioTYpe = new System.Windows.Forms.TextBox();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.txtAgentname = new System.Windows.Forms.TextBox();
            this.txtagentid = new System.Windows.Forms.TextBox();
            this.mnuOption = new System.Windows.Forms.ContextMenu();
            this.mnuNew = new System.Windows.Forms.MenuItem();
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuConfirm = new System.Windows.Forms.MenuItem();
            this.mnuCheckin = new System.Windows.Forms.MenuItem();
            this.mnuCheckOut = new System.Windows.Forms.MenuItem();
            this.mnuNoShow = new System.Windows.Forms.MenuItem();
            this.mnuCancel = new System.Windows.Forms.MenuItem();
            this.mnulvwCommands = new System.Windows.Forms.ContextMenu();
            this.mnuDeleteCharge = new System.Windows.Forms.MenuItem();
            this.tipGroup = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddRecurringCharge = new System.Windows.Forms.Button();
            this.btnRemoveRecurringCharge = new System.Windows.Forms.Button();
            this.cboMealGroups = new System.Windows.Forms.ComboBox();
            this.lvwMenus = new System.Windows.Forms.ListView();
            this.Description = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.grdFolio = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnBrowseAgent = new System.Windows.Forms.Button();
            this.btnBrowseAccount = new System.Windows.Forms.Button();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtTHRESHOLD_VALUE = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtTotal_Sales_Contribution = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtAccount_Type = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.btnAddDateCancel = new System.Windows.Forms.Button();
            this.btnAddDateOK = new System.Windows.Forms.Button();
            this.dtpAddDate = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.tabFoodBev_ = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.treeFoodBev = new System.Windows.Forms.TreeView();
            this.grpMealDetails = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblFoodBevOthers = new System.Windows.Forms.TableLayoutPanel();
            this.txtFoodSetup = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.txtFoodOver = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label71 = new System.Windows.Forms.Label();
            this.nudMealPax = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPaxAmt = new System.Windows.Forms.Label();
            this.nudPaxAmt = new System.Windows.Forms.NumericUpDown();
            this.txtTotalMealAmount = new System.Windows.Forms.NumericUpDown();
            this.lblLiveInFood = new System.Windows.Forms.Label();
            this.nudMealLiveIn = new System.Windows.Forms.NumericUpDown();
            this.lblLiveOutFood = new System.Windows.Forms.Label();
            this.nudMealLiveOut = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.dtpFoodDate = new System.Windows.Forms.DateTimePicker();
            this.label96 = new System.Windows.Forms.Label();
            this.cboMealType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtEndMealTime = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.txtFoodRemarks = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.txtVenueFood = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.txtStartMealTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.btnRemoveMenu = new System.Windows.Forms.Button();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.gridMealItems = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSaveMeal = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnNewMeal = new System.Windows.Forms.Button();
            this.btnAddDate = new System.Windows.Forms.Button();
            this.tabRooms_ = new System.Windows.Forms.TabPage();
            this.btnRemoveFunctionSchedule = new System.Windows.Forms.Button();
            this.btnAddFunctionSchedule = new System.Windows.Forms.Button();
            this.gridFunctionRooms = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpFolioETD = new System.Windows.Forms.DateTimePicker();
            this.label60 = new System.Windows.Forms.Label();
            this.dtpFolioETA = new System.Windows.Forms.DateTimePicker();
            this.label73 = new System.Windows.Forms.Label();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.grpDependentsRoom = new System.Windows.Forms.GroupBox();
            this.dtpEventTo = new System.Windows.Forms.DateTimePicker();
            this.dtpEventFrom = new System.Windows.Forms.DateTimePicker();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.btnManualBlockRooms = new System.Windows.Forms.Button();
            this.label87 = new System.Windows.Forms.Label();
            this.txtRoomRemarks = new System.Windows.Forms.TextBox();
            this.gridRooms = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnBlock = new System.Windows.Forms.Button();
            this.nudGuaranteedRooms = new System.Windows.Forms.NumericUpDown();
            this.nudRooms = new System.Windows.Forms.NumericUpDown();
            this.nudPax = new System.Windows.Forms.NumericUpDown();
            this.label91 = new System.Windows.Forms.Label();
            this.nudGuaranteedPax = new System.Windows.Forms.NumericUpDown();
            this.label92 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gridBlockedRooms = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabWedding_ = new System.Windows.Forms.TabPage();
            this.grpNotesRemarks = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label42 = new System.Windows.Forms.Label();
            this.txtLobbyPosting = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtSignatories = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.txtBillingArrangement = new System.Windows.Forms.TextBox();
            this.grpEventDetails = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtEventType = new System.Windows.Forms.TextBox();
            this.gridEventDetails = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.txtUpdatedBy = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.cboPurpose = new System.Windows.Forms.ComboBox();
            this.cboAccountType = new System.Windows.Forms.ComboBox();
            this.cboSales_Executive = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.cboPayment_Mode = new System.Windows.Forms.ComboBox();
            this.grpRequirements = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSaveRequirements = new System.Windows.Forms.Button();
            this.label101 = new System.Windows.Forms.Label();
            this.gridReqSchedules = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtRequirementNote = new System.Windows.Forms.TextBox();
            this.btnRemoveRequirements = new System.Windows.Forms.Button();
            this.btnAddRequirements = new System.Windows.Forms.Button();
            this.treeRequirements = new System.Windows.Forms.TreeView();
            this.mnuTreeRequirements = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwDetails = new System.Windows.Forms.ListView();
            this.label45 = new System.Windows.Forms.Label();
            this.cboRequirementType = new System.Windows.Forms.ComboBox();
            this.cboReqDate = new System.Windows.Forms.ComboBox();
            this.tabEventDetails_ = new System.Windows.Forms.TabPage();
            this.groupContacts = new System.Windows.Forms.GroupBox();
            this.gridContacts = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtZip1 = new System.Windows.Forms.TextBox();
            this.txtCountry1 = new System.Windows.Forms.TextBox();
            this.txtCity1 = new System.Windows.Forms.TextBox();
            this.txtStreet1 = new System.Windows.Forms.TextBox();
            this.txtContactNumber2 = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.txtContactNumber3 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtContactNumber1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label137 = new System.Windows.Forms.Label();
            this.txtGroupRemarks = new System.Windows.Forms.TextBox();
            this.txtEstimatedBal = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.cboEventGrpPackage = new System.Windows.Forms.ComboBox();
            this.lblLiveOut = new System.Windows.Forms.Label();
            this.nudNumberOfPaxLiveOut = new System.Windows.Forms.NumericUpDown();
            this.label41 = new System.Windows.Forms.Label();
            this.txtTotalEstimatedCost = new System.Windows.Forms.TextBox();
            this.lblLiveIn = new System.Windows.Forms.Label();
            this.nudPaxGuaranteed = new System.Windows.Forms.NumericUpDown();
            this.nudNumberOfPaxLiveIn = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.cboEventType = new System.Windows.Forms.ComboBox();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.txtArrivalDate = new System.Windows.Forms.TextBox();
            this.grpBillingDeposits = new System.Windows.Forms.GroupBox();
            this.grdDeposits = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnNewDeposit = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.gridBilling = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cboBillRates = new System.Windows.Forms.ComboBox();
            this.TabRecurringCharge = new System.Windows.Forms.TabPage();
            this.label135 = new System.Windows.Forms.Label();
            this.gridPackageRoom = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label67 = new System.Windows.Forms.Label();
            this.grdRecurringCharges = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnSaveRecurringCharge = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnViewAttachments = new System.Windows.Forms.Button();
            this.btnUploadAttachments = new System.Windows.Forms.Button();
            this.label138 = new System.Windows.Forms.Label();
            this.dtpPostingDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrintEstimatedCharges = new System.Windows.Forms.Button();
            this.cboEventPackage = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.txtPackageAmount = new System.Windows.Forms.TextBox();
            this.grdRecurredCharge = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.nmcQty = new System.Windows.Forms.NumericUpDown();
            this.cboDiscount = new System.Windows.Forms.ComboBox();
            this.cboRateTypes = new System.Windows.Forms.ComboBox();
            this.test = new System.Windows.Forms.TextBox();
            this.nudTax = new System.Windows.Forms.NumericUpDown();
            this.label116 = new System.Windows.Forms.Label();
            this.lbltest = new System.Windows.Forms.Label();
            this.tabPackage = new System.Windows.Forms.TabPage();
            this.dtpPackageDateTo = new System.Windows.Forms.DateTimePicker();
            this.label75 = new System.Windows.Forms.Label();
            this.dtpPackageDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label85 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.grdFolioPackage = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label13 = new System.Windows.Forms.Label();
            this.grdHotelPromos = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnAddHotelPromo = new System.Windows.Forms.Button();
            this.btnRemoveHotelPromo = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFolioPackageDaysApplied = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPrivilege = new System.Windows.Forms.TabPage();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
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
            this.tabBooking = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGrpTotal = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblOverStay = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.lblNoShow = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.lblCheckout = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.chkBreakFst = new System.Windows.Forms.CheckBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.nudNoofDays = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtPromo = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.tabFolio_ = new System.Windows.Forms.TabControl();
            this.tabBillingInfo = new System.Windows.Forms.TabPage();
            this.txtBIMemo = new System.Windows.Forms.TextBox();
            this.txtBICode = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.gridBillingInfo = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnRemoveCharge = new System.Windows.Forms.Button();
            this.btnSaveRouting = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.rdoAmount = new System.Windows.Forms.RadioButton();
            this.rdoPercent = new System.Windows.Forms.RadioButton();
            this.gridTransactionCodes = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label52 = new System.Windows.Forms.Label();
            this.tabRoomRequirements = new System.Windows.Forms.TabPage();
            this.tabAmmendments = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.grdSystemChanges = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grpNewAmendments = new System.Windows.Forms.GroupBox();
            this.btnAmendmentArrow = new System.Windows.Forms.Button();
            this.gridAmendmentSchedules = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label90 = new System.Windows.Forms.Label();
            this.txtAmendmentNo = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.pnlAmendments = new System.Windows.Forms.Panel();
            this.btnPrintSystemChanges = new System.Windows.Forms.Button();
            this.btnNewAmmendment = new System.Windows.Forms.Button();
            this.btnPrintAmmendments = new System.Windows.Forms.Button();
            this.btnSaveAmmendment = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.c1FlexGrid2 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label139 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label141 = new System.Windows.Forms.Label();
            this.grdAmmendments = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabEventRequirements = new System.Windows.Forms.TabPage();
            this.tabEndorsement = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btnViewLOP = new System.Windows.Forms.Button();
            this.btnUploadLOP = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label107 = new System.Windows.Forms.Label();
            this.cboLetterOfProposal = new System.Windows.Forms.ComboBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtGiveaways = new System.Windows.Forms.TextBox();
            this.txtDiscountConcessions = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.groupForEMDAction = new System.Windows.Forms.GroupBox();
            this.gridEMDActions = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.dtpForPickUp = new System.Windows.Forms.DateTimePicker();
            this.dtpSentToClient = new System.Windows.Forms.DateTimePicker();
            this.dtpSigned = new System.Windows.Forms.DateTimePicker();
            this.rdoReturned = new System.Windows.Forms.RadioButton();
            this.rdoSentToClient = new System.Windows.Forms.RadioButton();
            this.rdoForPickup = new System.Windows.Forms.RadioButton();
            this.rdoBeingProcessed = new System.Windows.Forms.RadioButton();
            this.groupReservationFee = new System.Windows.Forms.GroupBox();
            this.txtContractAmount = new System.Windows.Forms.NumericUpDown();
            this.dtp25RF2 = new System.Windows.Forms.DateTimePicker();
            this.dtp50RF = new System.Windows.Forms.DateTimePicker();
            this.label115 = new System.Windows.Forms.Label();
            this.dtp25RF1 = new System.Windows.Forms.DateTimePicker();
            this.txtBalanceRF = new System.Windows.Forms.TextBox();
            this.label108 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.txt25RF2 = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.txt25RF1 = new System.Windows.Forms.TextBox();
            this.txt50RF = new System.Windows.Forms.TextBox();
            this.label110 = new System.Windows.Forms.Label();
            this.tabCancellation = new System.Windows.Forms.TabPage();
            this.cboCancelBookingType = new System.Windows.Forms.ComboBox();
            this.label131 = new System.Windows.Forms.Label();
            this.cboReason = new System.Windows.Forms.ComboBox();
            this.label130 = new System.Windows.Forms.Label();
            this.btnSaveCancellation = new System.Windows.Forms.Button();
            this.txtFutureAction = new System.Windows.Forms.TextBox();
            this.txtReasons = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.tabEventAttendance = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnPrintEventAttendance = new System.Windows.Forms.Button();
            this.label129 = new System.Windows.Forms.Label();
            this.txtEventAttendanceRemarks = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label128 = new System.Windows.Forms.Label();
            this.nudActualAttendees = new System.Windows.Forms.NumericUpDown();
            this.label127 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.txtEventAttendanceNote = new System.Windows.Forms.TextBox();
            this.nudVisitors = new System.Windows.Forms.NumericUpDown();
            this.label126 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.nudLocalBased = new System.Windows.Forms.NumericUpDown();
            this.cboGeoEventType = new System.Windows.Forms.ComboBox();
            this.label125 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.nudLocal = new System.Windows.Forms.NumericUpDown();
            this.nudForeignBased = new System.Windows.Forms.NumericUpDown();
            this.label119 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.nudForeign = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.lvwBrowseGuestName = new System.Windows.Forms.ListView();
            this.columnHeader38 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader39 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader40 = new System.Windows.Forms.ColumnHeader();
            this.btnPrintContract = new System.Windows.Forms.Button();
            this.pnlNew = new System.Windows.Forms.Panel();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.mnuSchedule = new System.Windows.Forms.ContextMenu();
            this.mnuAddItem = new System.Windows.Forms.MenuItem();
            this.mnuDelete = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuRefreshSchedule = new System.Windows.Forms.MenuItem();
            this.pnlFolio = new System.Windows.Forms.Panel();
            this.btnBookingSheet = new System.Windows.Forms.Button();
            this.btnFolio = new System.Windows.Forms.Button();
            this.txtDepartureDate = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label106 = new System.Windows.Forms.Label();
            this.gridEventOfficer = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label103 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.lblTINNumber = new System.Windows.Forms.Label();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.label105 = new System.Windows.Forms.Label();
            this.gridIncumbentOfficer = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label132 = new System.Windows.Forms.Label();
            this.txtEventDate = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.pnlIndividual = new System.Windows.Forms.Panel();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lvwBrowseCompany = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.mnuDependents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUnblock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancelBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancelReservation = new System.Windows.Forms.ToolStripMenuItem();
            this.label39 = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.mnuContactPerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenListContact = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddContact = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveContact = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEventOfficers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddEventOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveEventOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEMDActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddEMDAction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveEMDAction = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlEstimateCharges = new System.Windows.Forms.Panel();
            this.btnCancelEstimated = new System.Windows.Forms.Button();
            this.btnPrintEstimated = new System.Windows.Forms.Button();
            this.txtContingencyDetails = new System.Windows.Forms.TextBox();
            this.cboShowAmount = new System.Windows.Forms.ComboBox();
            this.label117 = new System.Windows.Forms.Label();
            this.mnuIncumbentOfficers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuIncumbentAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncumbentRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContactList = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label136 = new System.Windows.Forms.Label();
            this.gridContactList = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolio)).BeginInit();
            this.pnlDate.SuspendLayout();
            this.tabFoodBev_.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpMealDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tblFoodBevOthers.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMealPax)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaxAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMealAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMealLiveIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMealLiveOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMealItems)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabRooms_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFunctionRooms)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.grpDependentsRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuaranteedRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuaranteedPax)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlockedRooms)).BeginInit();
            this.tabWedding_.SuspendLayout();
            this.grpNotesRemarks.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpEventDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventDetails)).BeginInit();
            this.grpRequirements.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReqSchedules)).BeginInit();
            this.mnuTreeRequirements.SuspendLayout();
            this.tabEventDetails_.SuspendLayout();
            this.groupContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPaxLiveOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaxGuaranteed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPaxLiveIn)).BeginInit();
            this.grpBillingDeposits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeposits)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBilling)).BeginInit();
            this.TabRecurringCharge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackageRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecurringCharges)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecurredCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTax)).BeginInit();
            this.tabPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHotelPromos)).BeginInit();
            this.tabPrivilege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPrivileges)).BeginInit();
            this.gbxApplyPrivileges.SuspendLayout();
            this.tabBooking.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoofDays)).BeginInit();
            this.tabFolio_.SuspendLayout();
            this.tabBillingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBillingInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactionCodes)).BeginInit();
            this.tabRoomRequirements.SuspendLayout();
            this.tabAmmendments.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemChanges)).BeginInit();
            this.grpNewAmendments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAmendmentSchedules)).BeginInit();
            this.pnlAmendments.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid2)).BeginInit();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAmmendments)).BeginInit();
            this.panel7.SuspendLayout();
            this.tabEventRequirements.SuspendLayout();
            this.tabEndorsement.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupForEMDAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEMDActions)).BeginInit();
            this.groupBox14.SuspendLayout();
            this.groupReservationFee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractAmount)).BeginInit();
            this.tabCancellation.SuspendLayout();
            this.tabEventAttendance.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudActualAttendees)).BeginInit();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVisitors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalBased)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeignBased)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeign)).BeginInit();
            this.pnlNew.SuspendLayout();
            this.pnlFolio.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventOfficer)).BeginInit();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIncumbentOfficer)).BeginInit();
            this.pnlCompany.SuspendLayout();
            this.pnlIndividual.SuspendLayout();
            this.mnuDependents.SuspendLayout();
            this.mnuContactPerson.SuspendLayout();
            this.mnuEventOfficers.SuspendLayout();
            this.mnuEMDActions.SuspendLayout();
            this.pnlEstimateCharges.SuspendLayout();
            this.mnuIncumbentOfficers.SuspendLayout();
            this.pnlContactList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContactList)).BeginInit();
            this.SuspendLayout();
            // 
            // headerType
            // 
            this.headerType.Text = "Type";
            this.headerType.Width = 50;
            // 
            // headerRate
            // 
            this.headerRate.Text = "Rate";
            this.headerRate.Width = 45;
            // 
            // headerTo
            // 
            this.headerTo.Text = "To";
            this.headerTo.Width = 150;
            // 
            // headerDays
            // 
            this.headerDays.Text = "Days";
            this.headerDays.Width = 45;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(331, 53);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(10, 18);
            this.Label3.TabIndex = 66;
            this.Label3.Text = "Folio Type";
            this.Label3.Visible = false;
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStatus.BackColor = System.Drawing.SystemColors.Window;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboStatus.Enabled = false;
            this.cboStatus.ItemHeight = 14;
            this.cboStatus.Items.AddRange(new object[] {
            "TENTATIVE",
            "CONFIRMED"});
            this.cboStatus.Location = new System.Drawing.Point(666, 26);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(128, 22);
            this.cboStatus.TabIndex = 1;
            this.cboStatus.TabStop = false;
            this.cboStatus.SelectionChangeCommitted += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // imgIcon
            // 
            this.imgIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgIcon.ImageSize = new System.Drawing.Size(16, 16);
            this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Label43
            // 
            this.Label43.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label43.Location = new System.Drawing.Point(23, 29);
            this.Label43.Name = "Label43";
            this.Label43.Size = new System.Drawing.Size(72, 14);
            this.Label43.TabIndex = 33;
            this.Label43.Text = "Event Name";
            // 
            // txtFolioID
            // 
            this.txtFolioID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFolioID.Enabled = false;
            this.txtFolioID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolioID.Location = new System.Drawing.Point(140, 13);
            this.txtFolioID.Name = "txtFolioID";
            this.txtFolioID.Size = new System.Drawing.Size(127, 20);
            this.txtFolioID.TabIndex = 29;
            this.txtFolioID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolioID_KeyPress);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(18, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(114, 18);
            this.Label1.TabIndex = 28;
            this.Label1.Text = "Control Number";
            // 
            // Label40
            // 
            this.Label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label40.Location = new System.Drawing.Point(609, 29);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(51, 15);
            this.Label40.TabIndex = 31;
            this.Label40.Text = "Status";
            // 
            // headerRoomno
            // 
            this.headerRoomno.Text = "Room#";
            this.headerRoomno.Width = 45;
            // 
            // tmrFolio
            // 
            this.tmrFolio.Enabled = true;
            this.tmrFolio.Interval = 500;
            // 
            // headerAmount
            // 
            this.headerAmount.Text = "Amount";
            // 
            // headerFrom
            // 
            this.headerFrom.Text = "From";
            this.headerFrom.Width = 150;
            // 
            // rdbIndividual
            // 
            this.rdbIndividual.AutoSize = true;
            this.rdbIndividual.Location = new System.Drawing.Point(234, 29);
            this.rdbIndividual.Name = "rdbIndividual";
            this.rdbIndividual.Size = new System.Drawing.Size(69, 18);
            this.rdbIndividual.TabIndex = 4;
            this.rdbIndividual.Text = "Individual";
            this.rdbIndividual.UseVisualStyleBackColor = true;
            this.rdbIndividual.CheckedChanged += new System.EventHandler(this.rdbIndividual_CheckedChanged);
            // 
            // rdbCompany
            // 
            this.rdbCompany.AutoSize = true;
            this.rdbCompany.Location = new System.Drawing.Point(234, 9);
            this.rdbCompany.Name = "rdbCompany";
            this.rdbCompany.Size = new System.Drawing.Size(70, 18);
            this.rdbCompany.TabIndex = 3;
            this.rdbCompany.Text = "Company";
            this.rdbCompany.UseVisualStyleBackColor = true;
            this.rdbCompany.CheckedChanged += new System.EventHandler(this.rdbCompany_CheckedChanged);
            // 
            // txtcompanyid
            // 
            this.txtcompanyid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtcompanyid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcompanyid.Location = new System.Drawing.Point(91, 13);
            this.txtcompanyid.Name = "txtcompanyid";
            this.txtcompanyid.Size = new System.Drawing.Size(102, 20);
            this.txtcompanyid.TabIndex = 500;
            this.txtcompanyid.TabStop = false;
            this.txtcompanyid.TextChanged += new System.EventHandler(this.txtcompanyid_TextChanged);
            // 
            // Label21
            // 
            this.Label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.Location = new System.Drawing.Point(13, 16);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(72, 14);
            this.Label21.TabIndex = 93;
            this.Label21.Text = "Account ID";
            // 
            // txtbreakfast
            // 
            this.txtbreakfast.Location = new System.Drawing.Point(90, 451);
            this.txtbreakfast.Name = "txtbreakfast";
            this.txtbreakfast.Size = new System.Drawing.Size(100, 20);
            this.txtbreakfast.TabIndex = 102;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlStatus.Controls.Add(this.btnConfirm);
            this.pnlStatus.Controls.Add(this.btnreinstate);
            this.pnlStatus.Controls.Add(this.btnCheckIN);
            this.pnlStatus.Controls.Add(this.btnCheckOut);
            this.pnlStatus.Controls.Add(this.btnPostCharges);
            this.pnlStatus.Controls.Add(this.btnUnconfirm);
            this.pnlStatus.Location = new System.Drawing.Point(194, 539);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(439, 42);
            this.pnlStatus.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(290, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(66, 36);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "C&onfirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnreinstate
            // 
            this.btnreinstate.Location = new System.Drawing.Point(5, 3);
            this.btnreinstate.Name = "btnreinstate";
            this.btnreinstate.Size = new System.Drawing.Size(66, 36);
            this.btnreinstate.TabIndex = 15;
            this.btnreinstate.Text = "Reinstate";
            this.btnreinstate.UseVisualStyleBackColor = true;
            this.btnreinstate.Click += new System.EventHandler(this.btnreinstate_Click);
            // 
            // btnCheckIN
            // 
            this.btnCheckIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckIN.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIN.Location = new System.Drawing.Point(223, 3);
            this.btnCheckIN.Name = "btnCheckIN";
            this.btnCheckIN.Size = new System.Drawing.Size(66, 36);
            this.btnCheckIN.TabIndex = 14;
            this.btnCheckIN.Text = "&Start Event";
            this.btnCheckIN.Click += new System.EventHandler(this.btnCheckIN_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Location = new System.Drawing.Point(156, 3);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(66, 36);
            this.btnCheckOut.TabIndex = 13;
            this.btnCheckOut.Text = "&End Event";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOUt_Click);
            // 
            // btnPostCharges
            // 
            this.btnPostCharges.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPostCharges.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostCharges.Location = new System.Drawing.Point(72, 3);
            this.btnPostCharges.Name = "btnPostCharges";
            this.btnPostCharges.Size = new System.Drawing.Size(66, 36);
            this.btnPostCharges.TabIndex = 12;
            this.btnPostCharges.Text = "Post &Charges";
            this.btnPostCharges.Click += new System.EventHandler(this.btnPostCharges_Click);
            // 
            // btnUnconfirm
            // 
            this.btnUnconfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnconfirm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnconfirm.Location = new System.Drawing.Point(357, 3);
            this.btnUnconfirm.Name = "btnUnconfirm";
            this.btnUnconfirm.Size = new System.Drawing.Size(66, 36);
            this.btnUnconfirm.TabIndex = 17;
            this.btnUnconfirm.Text = "&Unconfirm";
            this.btnUnconfirm.Click += new System.EventHandler(this.btnUnconfirm_Click);
            // 
            // txtFolioTYpe
            // 
            this.txtFolioTYpe.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFolioTYpe.Location = new System.Drawing.Point(53, 49);
            this.txtFolioTYpe.Name = "txtFolioTYpe";
            this.txtFolioTYpe.Size = new System.Drawing.Size(10, 20);
            this.txtFolioTYpe.TabIndex = 112;
            this.txtFolioTYpe.Text = "GROUP";
            // 
            // txtAccountType
            // 
            this.txtAccountType.Location = new System.Drawing.Point(614, 60);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(123, 20);
            this.txtAccountType.TabIndex = 113;
            this.txtAccountType.Text = "Company";
            // 
            // txtAgentname
            // 
            this.txtAgentname.BackColor = System.Drawing.Color.White;
            this.txtAgentname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgentname.Location = new System.Drawing.Point(58, 24);
            this.txtAgentname.Name = "txtAgentname";
            this.txtAgentname.Size = new System.Drawing.Size(185, 20);
            this.txtAgentname.TabIndex = 7;
            this.txtAgentname.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // txtagentid
            // 
            this.txtagentid.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtagentid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtagentid.Location = new System.Drawing.Point(58, 24);
            this.txtagentid.Name = "txtagentid";
            this.txtagentid.Size = new System.Drawing.Size(89, 20);
            this.txtagentid.TabIndex = 7;
            // 
            // mnuOption
            // 
            this.mnuOption.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNew,
            this.mnuEdit,
            this.MenuItem1,
            this.mnuConfirm,
            this.mnuCheckin,
            this.mnuCheckOut,
            this.mnuNoShow,
            this.mnuCancel});
            // 
            // mnuNew
            // 
            this.mnuNew.Index = 0;
            this.mnuNew.Text = "New Reservation";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 1;
            this.mnuEdit.Text = "Edit/View";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 2;
            this.MenuItem1.Text = "-";
            // 
            // mnuConfirm
            // 
            this.mnuConfirm.Index = 3;
            this.mnuConfirm.Text = "Confirm";
            this.mnuConfirm.Click += new System.EventHandler(this.mnuConfirm_Click);
            // 
            // mnuCheckin
            // 
            this.mnuCheckin.Index = 4;
            this.mnuCheckin.Text = "Check In";
            // 
            // mnuCheckOut
            // 
            this.mnuCheckOut.Index = 5;
            this.mnuCheckOut.Text = "Check Out";
            this.mnuCheckOut.Click += new System.EventHandler(this.mnuCheckOut_Click);
            // 
            // mnuNoShow
            // 
            this.mnuNoShow.Index = 6;
            this.mnuNoShow.Text = "No Show";
            this.mnuNoShow.Click += new System.EventHandler(this.mnuNoShow_Click);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Index = 7;
            this.mnuCancel.Text = "Cancel Reservation";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // mnulvwCommands
            // 
            this.mnulvwCommands.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuDeleteCharge});
            // 
            // mnuDeleteCharge
            // 
            this.mnuDeleteCharge.Index = 0;
            this.mnuDeleteCharge.Text = "Delete Charge";
            this.mnuDeleteCharge.Click += new System.EventHandler(this.mnuDeleteCharge_Click);
            // 
            // btnAddRecurringCharge
            // 
            this.btnAddRecurringCharge.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddRecurringCharge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddRecurringCharge.Location = new System.Drawing.Point(300, 159);
            this.btnAddRecurringCharge.Name = "btnAddRecurringCharge";
            this.btnAddRecurringCharge.Size = new System.Drawing.Size(29, 25);
            this.btnAddRecurringCharge.TabIndex = 20;
            this.btnAddRecurringCharge.Text = ">";
            this.tipGroup.SetToolTip(this.btnAddRecurringCharge, "Add Recurring Charge");
            this.btnAddRecurringCharge.Click += new System.EventHandler(this.btnAddRecurringCharge_Click);
            // 
            // btnRemoveRecurringCharge
            // 
            this.btnRemoveRecurringCharge.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRemoveRecurringCharge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRemoveRecurringCharge.Location = new System.Drawing.Point(300, 195);
            this.btnRemoveRecurringCharge.Name = "btnRemoveRecurringCharge";
            this.btnRemoveRecurringCharge.Size = new System.Drawing.Size(29, 25);
            this.btnRemoveRecurringCharge.TabIndex = 24;
            this.btnRemoveRecurringCharge.Text = "<";
            this.tipGroup.SetToolTip(this.btnRemoveRecurringCharge, "Remove Recurring Charge");
            this.btnRemoveRecurringCharge.Click += new System.EventHandler(this.btnRemoveRecurringCharge_Click);
            // 
            // cboMealGroups
            // 
            this.cboMealGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMealGroups.BackColor = System.Drawing.SystemColors.Info;
            this.cboMealGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMealGroups.Items.AddRange(new object[] {
            "BREAKFAST",
            "AM SNACKS",
            "LUNCH",
            "PM SNACKS",
            "DINNER",
            "OTHERS",
            " "});
            this.cboMealGroups.Location = new System.Drawing.Point(531, 45);
            this.cboMealGroups.Name = "cboMealGroups";
            this.cboMealGroups.Size = new System.Drawing.Size(98, 22);
            this.cboMealGroups.TabIndex = 13;
            this.tipGroup.SetToolTip(this.cboMealGroups, "Choose Menu Group here...");
            this.cboMealGroups.SelectedIndexChanged += new System.EventHandler(this.cboMealGroups_SelectedIndexChanged);
            // 
            // lvwMenus
            // 
            this.lvwMenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMenus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Description,
            this.columnHeader25,
            this.columnHeader28});
            this.lvwMenus.Location = new System.Drawing.Point(531, 70);
            this.lvwMenus.Name = "lvwMenus";
            this.lvwMenus.Scrollable = false;
            this.lvwMenus.Size = new System.Drawing.Size(98, 415);
            this.lvwMenus.TabIndex = 14;
            this.tipGroup.SetToolTip(this.lvwMenus, "Double-click to Add Menu");
            this.lvwMenus.UseCompatibleStateImageBehavior = false;
            this.lvwMenus.View = System.Windows.Forms.View.Details;
            this.lvwMenus.SelectedIndexChanged += new System.EventHandler(this.lvwMenus_SelectedIndexChanged);
            this.lvwMenus.DoubleClick += new System.EventHandler(this.lvwMenus_DoubleClick);
            this.lvwMenus.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwMenus_ItemDrag);
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 135;
            // 
            // grdFolio
            // 
            this.grdFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFolio.ColumnInfo = resources.GetString("grdFolio.ColumnInfo");
            this.grdFolio.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdFolio.Location = new System.Drawing.Point(1, 67);
            this.grdFolio.Name = "grdFolio";
            this.grdFolio.Rows.Count = 1;
            this.grdFolio.Rows.DefaultSize = 17;
            this.grdFolio.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdFolio.Size = new System.Drawing.Size(760, 171);
            this.grdFolio.StyleInfo = resources.GetString("grdFolio.StyleInfo");
            this.grdFolio.TabIndex = 302;
            this.tipGroup.SetToolTip(this.grdFolio, "Double Click to Edit Folio");
            this.grdFolio.Click += new System.EventHandler(this.grdFolio_Click);
            this.grdFolio.DoubleClick += new System.EventHandler(this.lvwFolio_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(122, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(294, 20);
            this.txtSearch.TabIndex = 300;
            this.tipGroup.SetToolTip(this.txtSearch, "Search Dependent Folio Here");
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnBrowseAgent
            // 
            this.btnBrowseAgent.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowseAgent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBrowseAgent.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.search_small;
            this.btnBrowseAgent.Location = new System.Drawing.Point(249, 21);
            this.btnBrowseAgent.Name = "btnBrowseAgent";
            this.btnBrowseAgent.Size = new System.Drawing.Size(29, 26);
            this.btnBrowseAgent.TabIndex = 8;
            this.tipGroup.SetToolTip(this.btnBrowseAgent, "View Agents");
            this.btnBrowseAgent.UseVisualStyleBackColor = false;
            this.btnBrowseAgent.Click += new System.EventHandler(this.btnBrowseAgent_Click);
            // 
            // btnBrowseAccount
            // 
            this.btnBrowseAccount.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowseAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBrowseAccount.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.search_small;
            this.btnBrowseAccount.Location = new System.Drawing.Point(199, 10);
            this.btnBrowseAccount.Name = "btnBrowseAccount";
            this.btnBrowseAccount.Size = new System.Drawing.Size(29, 26);
            this.btnBrowseAccount.TabIndex = 4;
            this.tipGroup.SetToolTip(this.btnBrowseAccount, "View All Company");
            this.btnBrowseAccount.UseVisualStyleBackColor = false;
            this.btnBrowseAccount.Click += new System.EventHandler(this.btnBrowseAccount_Click);
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCreateTime.Location = new System.Drawing.Point(391, 13);
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.Size = new System.Drawing.Size(134, 20);
            this.txtCreateTime.TabIndex = 120;
            this.txtCreateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCreateTime.TextChanged += new System.EventHandler(this.txtCreateTime_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(310, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(79, 14);
            this.label34.TabIndex = 119;
            this.label34.Text = "Booking Date";
            // 
            // txtTHRESHOLD_VALUE
            // 
            this.txtTHRESHOLD_VALUE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTHRESHOLD_VALUE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTHRESHOLD_VALUE.Location = new System.Drawing.Point(116, 49);
            this.txtTHRESHOLD_VALUE.Name = "txtTHRESHOLD_VALUE";
            this.txtTHRESHOLD_VALUE.Size = new System.Drawing.Size(10, 20);
            this.txtTHRESHOLD_VALUE.TabIndex = 12;
            this.txtTHRESHOLD_VALUE.TabStop = false;
            this.txtTHRESHOLD_VALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(101, 52);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(10, 12);
            this.label36.TabIndex = 164;
            this.label36.Text = "Threshold";
            // 
            // txtTotal_Sales_Contribution
            // 
            this.txtTotal_Sales_Contribution.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTotal_Sales_Contribution.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal_Sales_Contribution.Location = new System.Drawing.Point(164, 46);
            this.txtTotal_Sales_Contribution.Name = "txtTotal_Sales_Contribution";
            this.txtTotal_Sales_Contribution.Size = new System.Drawing.Size(10, 20);
            this.txtTotal_Sales_Contribution.TabIndex = 11;
            this.txtTotal_Sales_Contribution.TabStop = false;
            this.txtTotal_Sales_Contribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(148, 49);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(10, 15);
            this.label35.TabIndex = 162;
            this.label35.Text = "Total Sales";
            // 
            // txtAccount_Type
            // 
            this.txtAccount_Type.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtAccount_Type.Location = new System.Drawing.Point(85, 51);
            this.txtAccount_Type.Name = "txtAccount_Type";
            this.txtAccount_Type.Size = new System.Drawing.Size(10, 20);
            this.txtAccount_Type.TabIndex = 10;
            this.txtAccount_Type.TabStop = false;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(69, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 16);
            this.label15.TabIndex = 160;
            this.label15.Text = "Guest Type";
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.btnAddDateCancel);
            this.pnlDate.Controls.Add(this.btnAddDateOK);
            this.pnlDate.Controls.Add(this.dtpAddDate);
            this.pnlDate.Controls.Add(this.label38);
            this.pnlDate.Location = new System.Drawing.Point(225, 56);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(200, 113);
            this.pnlDate.TabIndex = 122;
            // 
            // btnAddDateCancel
            // 
            this.btnAddDateCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddDateCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddDateCancel.Enabled = false;
            this.btnAddDateCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDateCancel.Location = new System.Drawing.Point(99, 75);
            this.btnAddDateCancel.Name = "btnAddDateCancel";
            this.btnAddDateCancel.Size = new System.Drawing.Size(50, 25);
            this.btnAddDateCancel.TabIndex = 162;
            this.btnAddDateCancel.Text = "Cancel";
            this.btnAddDateCancel.Click += new System.EventHandler(this.btnAddDateCancel_Click);
            // 
            // btnAddDateOK
            // 
            this.btnAddDateOK.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddDateOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddDateOK.Enabled = false;
            this.btnAddDateOK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDateOK.Location = new System.Drawing.Point(47, 75);
            this.btnAddDateOK.Name = "btnAddDateOK";
            this.btnAddDateOK.Size = new System.Drawing.Size(50, 25);
            this.btnAddDateOK.TabIndex = 161;
            this.btnAddDateOK.Text = "OK";
            this.btnAddDateOK.Click += new System.EventHandler(this.btnAddDateOK_Click);
            // 
            // dtpAddDate
            // 
            this.dtpAddDate.Location = new System.Drawing.Point(5, 38);
            this.dtpAddDate.Name = "dtpAddDate";
            this.dtpAddDate.Size = new System.Drawing.Size(188, 20);
            this.dtpAddDate.TabIndex = 160;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.SteelBlue;
            this.label38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(1, 1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(196, 18);
            this.label38.TabIndex = 159;
            this.label38.Text = "Select a Date :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabFoodBev_
            // 
            this.tabFoodBev_.Controls.Add(this.groupBox5);
            this.tabFoodBev_.Controls.Add(this.grpMealDetails);
            this.tabFoodBev_.Controls.Add(this.panel4);
            this.tabFoodBev_.Controls.Add(this.panel6);
            this.tabFoodBev_.Location = new System.Drawing.Point(4, 23);
            this.tabFoodBev_.Name = "tabFoodBev_";
            this.tabFoodBev_.Size = new System.Drawing.Size(776, 288);
            this.tabFoodBev_.TabIndex = 6;
            this.tabFoodBev_.Text = "Food & Beverage";
            this.tabFoodBev_.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.treeFoodBev);
            this.groupBox5.Location = new System.Drawing.Point(7, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(126, 490);
            this.groupBox5.TabIndex = 176;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Meal Dates";
            // 
            // treeFoodBev
            // 
            this.treeFoodBev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFoodBev.Location = new System.Drawing.Point(3, 16);
            this.treeFoodBev.Name = "treeFoodBev";
            this.treeFoodBev.Size = new System.Drawing.Size(120, 471);
            this.treeFoodBev.TabIndex = 159;
            this.treeFoodBev.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFoodBev_AfterSelect);
            this.treeFoodBev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeFoodBev_KeyDown);
            // 
            // grpMealDetails
            // 
            this.grpMealDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMealDetails.Controls.Add(this.panel1);
            this.grpMealDetails.Controls.Add(this.btnAddMenu);
            this.grpMealDetails.Controls.Add(this.btnRemoveMenu);
            this.grpMealDetails.Controls.Add(this.cboMealGroups);
            this.grpMealDetails.Controls.Add(this.label80);
            this.grpMealDetails.Controls.Add(this.label79);
            this.grpMealDetails.Controls.Add(this.lvwMenus);
            this.grpMealDetails.Controls.Add(this.gridMealItems);
            this.grpMealDetails.Location = new System.Drawing.Point(138, 3);
            this.grpMealDetails.Name = "grpMealDetails";
            this.grpMealDetails.Size = new System.Drawing.Size(632, 490);
            this.grpMealDetails.TabIndex = 158;
            this.grpMealDetails.TabStop = false;
            this.grpMealDetails.Text = "Meal Details";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblFoodBevOthers);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 471);
            this.panel1.TabIndex = 222;
            // 
            // tblFoodBevOthers
            // 
            this.tblFoodBevOthers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblFoodBevOthers.ColumnCount = 2;
            this.tblFoodBevOthers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.89394F));
            this.tblFoodBevOthers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.10606F));
            this.tblFoodBevOthers.Controls.Add(this.txtFoodSetup, 1, 0);
            this.tblFoodBevOthers.Controls.Add(this.label98, 0, 0);
            this.tblFoodBevOthers.Controls.Add(this.txtFoodOver, 1, 1);
            this.tblFoodBevOthers.Controls.Add(this.label95, 0, 1);
            this.tblFoodBevOthers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblFoodBevOthers.Location = new System.Drawing.Point(0, 405);
            this.tblFoodBevOthers.Name = "tblFoodBevOthers";
            this.tblFoodBevOthers.RowCount = 2;
            this.tblFoodBevOthers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFoodBevOthers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFoodBevOthers.Size = new System.Drawing.Size(264, 66);
            this.tblFoodBevOthers.TabIndex = 220;
            // 
            // txtFoodSetup
            // 
            this.txtFoodSetup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFoodSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFoodSetup.Location = new System.Drawing.Point(74, 3);
            this.txtFoodSetup.Multiline = true;
            this.txtFoodSetup.Name = "txtFoodSetup";
            this.txtFoodSetup.Size = new System.Drawing.Size(187, 31);
            this.txtFoodSetup.TabIndex = 10;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label98.Location = new System.Drawing.Point(3, 0);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(65, 37);
            this.label98.TabIndex = 152;
            this.label98.Text = "Setup";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFoodOver
            // 
            this.txtFoodOver.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFoodOver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFoodOver.Location = new System.Drawing.Point(74, 40);
            this.txtFoodOver.Multiline = true;
            this.txtFoodOver.Name = "txtFoodOver";
            this.txtFoodOver.Size = new System.Drawing.Size(187, 23);
            this.txtFoodOver.TabIndex = 12;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label95.Location = new System.Drawing.Point(3, 37);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(65, 29);
            this.label95.TabIndex = 162;
            this.label95.Text = "Over";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.89394F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.10606F));
            this.tableLayoutPanel3.Controls.Add(this.label71, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.nudMealPax, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.lblLiveInFood, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.nudMealLiveIn, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.lblLiveOutFood, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.nudMealLiveOut, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label26, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.dtpFoodDate, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label96, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboMealType, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label32, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtEndMealTime, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label31, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtFoodRemarks, 1, 9);
            this.tableLayoutPanel3.Controls.Add(this.label97, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.txtVenueFood, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.label99, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.txtStartMealTime, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.91956F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.21588F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.03679F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.36789F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.17057F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(264, 471);
            this.tableLayoutPanel3.TabIndex = 221;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label71.Location = new System.Drawing.Point(3, 171);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(65, 45);
            this.label71.TabIndex = 170;
            this.label71.Text = "Total Amt.";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMealPax
            // 
            this.nudMealPax.BackColor = System.Drawing.SystemColors.Info;
            this.nudMealPax.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudMealPax.Location = new System.Drawing.Point(74, 126);
            this.nudMealPax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMealPax.Name = "nudMealPax";
            this.nudMealPax.Size = new System.Drawing.Size(81, 20);
            this.nudMealPax.TabIndex = 5;
            this.nudMealPax.ValueChanged += new System.EventHandler(this.nudMealPax_ValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblPaxAmt, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudPaxAmt, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTotalMealAmount, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(74, 174);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(187, 39);
            this.tableLayoutPanel2.TabIndex = 223;
            // 
            // lblPaxAmt
            // 
            this.lblPaxAmt.AutoSize = true;
            this.lblPaxAmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPaxAmt.Location = new System.Drawing.Point(69, 0);
            this.lblPaxAmt.Name = "lblPaxAmt";
            this.lblPaxAmt.Size = new System.Drawing.Size(49, 39);
            this.lblPaxAmt.TabIndex = 171;
            this.lblPaxAmt.Text = "Pax Amt.";
            this.lblPaxAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPaxAmt
            // 
            this.nudPaxAmt.BackColor = System.Drawing.Color.White;
            this.nudPaxAmt.DecimalPlaces = 2;
            this.nudPaxAmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudPaxAmt.Location = new System.Drawing.Point(124, 3);
            this.nudPaxAmt.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            131072});
            this.nudPaxAmt.Name = "nudPaxAmt";
            this.nudPaxAmt.Size = new System.Drawing.Size(60, 20);
            this.nudPaxAmt.TabIndex = 10;
            this.nudPaxAmt.ThousandsSeparator = true;
            this.nudPaxAmt.ValueChanged += new System.EventHandler(this.nudPaxAmt_ValueChanged);
            // 
            // txtTotalMealAmount
            // 
            this.txtTotalMealAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalMealAmount.DecimalPlaces = 2;
            this.txtTotalMealAmount.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTotalMealAmount.Location = new System.Drawing.Point(3, 3);
            this.txtTotalMealAmount.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            131072});
            this.txtTotalMealAmount.Name = "txtTotalMealAmount";
            this.txtTotalMealAmount.Size = new System.Drawing.Size(59, 20);
            this.txtTotalMealAmount.TabIndex = 8;
            this.txtTotalMealAmount.ThousandsSeparator = true;
            // 
            // lblLiveInFood
            // 
            this.lblLiveInFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLiveInFood.Location = new System.Drawing.Point(3, 171);
            this.lblLiveInFood.Name = "lblLiveInFood";
            this.lblLiveInFood.Size = new System.Drawing.Size(65, 1);
            this.lblLiveInFood.TabIndex = 178;
            this.lblLiveInFood.Text = "Live In";
            this.lblLiveInFood.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMealLiveIn
            // 
            this.nudMealLiveIn.BackColor = System.Drawing.SystemColors.Info;
            this.nudMealLiveIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudMealLiveIn.Location = new System.Drawing.Point(74, 174);
            this.nudMealLiveIn.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudMealLiveIn.Name = "nudMealLiveIn";
            this.nudMealLiveIn.Size = new System.Drawing.Size(81, 20);
            this.nudMealLiveIn.TabIndex = 6;
            this.nudMealLiveIn.ValueChanged += new System.EventHandler(this.nudMealLiveIn_ValueChanged);
            // 
            // lblLiveOutFood
            // 
            this.lblLiveOutFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLiveOutFood.Location = new System.Drawing.Point(3, 171);
            this.lblLiveOutFood.Name = "lblLiveOutFood";
            this.lblLiveOutFood.Size = new System.Drawing.Size(65, 1);
            this.lblLiveOutFood.TabIndex = 174;
            this.lblLiveOutFood.Text = "Live Out";
            this.lblLiveOutFood.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMealLiveOut
            // 
            this.nudMealLiveOut.BackColor = System.Drawing.SystemColors.Info;
            this.nudMealLiveOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudMealLiveOut.Location = new System.Drawing.Point(74, 174);
            this.nudMealLiveOut.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudMealLiveOut.Name = "nudMealLiveOut";
            this.nudMealLiveOut.Size = new System.Drawing.Size(81, 20);
            this.nudMealLiveOut.TabIndex = 7;
            this.nudMealLiveOut.ValueChanged += new System.EventHandler(this.nudMealLiveOut_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Location = new System.Drawing.Point(3, 123);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 48);
            this.label26.TabIndex = 216;
            this.label26.Text = "No. of Pax";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFoodDate
            // 
            this.dtpFoodDate.CustomFormat = "ddd. MMM. dd, yyyy";
            this.dtpFoodDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFoodDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFoodDate.Location = new System.Drawing.Point(74, 3);
            this.dtpFoodDate.Name = "dtpFoodDate";
            this.dtpFoodDate.Size = new System.Drawing.Size(187, 20);
            this.dtpFoodDate.TabIndex = 1;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label96.Location = new System.Drawing.Point(3, 0);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(65, 74);
            this.label96.TabIndex = 156;
            this.label96.Text = "Date";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMealType
            // 
            this.cboMealType.BackColor = System.Drawing.SystemColors.Info;
            this.cboMealType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMealType.Enabled = false;
            this.cboMealType.Items.AddRange(new object[] {
            "BREAKFAST",
            "AM SNACKS",
            "LUNCH",
            "PM SNACKS",
            "DINNER",
            "OTHERS",
            " "});
            this.cboMealType.Location = new System.Drawing.Point(74, 77);
            this.cboMealType.Name = "cboMealType";
            this.cboMealType.Size = new System.Drawing.Size(187, 22);
            this.cboMealType.TabIndex = 2;
            this.cboMealType.SelectedValueChanged += new System.EventHandler(this.cboMealType_SelectedValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 49);
            this.label16.TabIndex = 172;
            this.label16.Text = "Meal Type";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label32.Location = new System.Drawing.Point(3, 123);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(65, 1);
            this.label32.TabIndex = 164;
            this.label32.Text = "Ready Time";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEndMealTime
            // 
            this.txtEndMealTime.BackColor = System.Drawing.SystemColors.Info;
            this.txtEndMealTime.CustomFormat = "HH:mm tt";
            this.txtEndMealTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtEndMealTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtEndMealTime.Location = new System.Drawing.Point(74, 126);
            this.txtEndMealTime.Name = "txtEndMealTime";
            this.txtEndMealTime.ShowUpDown = true;
            this.txtEndMealTime.Size = new System.Drawing.Size(81, 20);
            this.txtEndMealTime.TabIndex = 4;
            this.txtEndMealTime.Value = new System.DateTime(2009, 8, 26, 6, 0, 0, 0);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label31.Location = new System.Drawing.Point(3, 123);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 1);
            this.label31.TabIndex = 166;
            this.label31.Text = "Deliver Time";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFoodRemarks
            // 
            this.txtFoodRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFoodRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFoodRemarks.Location = new System.Drawing.Point(74, 245);
            this.txtFoodRemarks.Multiline = true;
            this.txtFoodRemarks.Name = "txtFoodRemarks";
            this.txtFoodRemarks.Size = new System.Drawing.Size(187, 223);
            this.txtFoodRemarks.TabIndex = 11;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label97.Location = new System.Drawing.Point(3, 242);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(65, 229);
            this.label97.TabIndex = 154;
            this.label97.Text = "Remarks";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVenueFood
            // 
            this.txtVenueFood.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVenueFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVenueFood.Location = new System.Drawing.Point(74, 219);
            this.txtVenueFood.Name = "txtVenueFood";
            this.txtVenueFood.Size = new System.Drawing.Size(187, 20);
            this.txtVenueFood.TabIndex = 9;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label99.Location = new System.Drawing.Point(3, 216);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(65, 26);
            this.label99.TabIndex = 150;
            this.label99.Text = "Meal Venue";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStartMealTime
            // 
            this.txtStartMealTime.BackColor = System.Drawing.SystemColors.Info;
            this.txtStartMealTime.CustomFormat = "HH:mm tt";
            this.txtStartMealTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtStartMealTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtStartMealTime.Location = new System.Drawing.Point(74, 126);
            this.txtStartMealTime.Name = "txtStartMealTime";
            this.txtStartMealTime.ShowUpDown = true;
            this.txtStartMealTime.Size = new System.Drawing.Size(81, 20);
            this.txtStartMealTime.TabIndex = 3;
            this.txtStartMealTime.Value = new System.DateTime(2009, 8, 26, 6, 0, 0, 0);
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddMenu.Enabled = false;
            this.btnAddMenu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMenu.Location = new System.Drawing.Point(430, 17);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(92, 23);
            this.btnAddMenu.TabIndex = 219;
            this.btnAddMenu.Text = "Add Menu";
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // btnRemoveMenu
            // 
            this.btnRemoveMenu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnRemoveMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveMenu.Enabled = false;
            this.btnRemoveMenu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveMenu.Location = new System.Drawing.Point(335, 17);
            this.btnRemoveMenu.Name = "btnRemoveMenu";
            this.btnRemoveMenu.Size = new System.Drawing.Size(92, 23);
            this.btnRemoveMenu.TabIndex = 218;
            this.btnRemoveMenu.Text = "Remove Menu";
            this.btnRemoveMenu.Click += new System.EventHandler(this.btnRemoveMenu_Click);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(533, 20);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(92, 14);
            this.label80.TabIndex = 214;
            this.label80.Text = "Available Menus :";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(281, 20);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(39, 14);
            this.label79.TabIndex = 213;
            this.label79.Text = "Menu :";
            // 
            // gridMealItems
            // 
            this.gridMealItems.AllowDelete = true;
            this.gridMealItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridMealItems.ColumnInfo = resources.GetString("gridMealItems.ColumnInfo");
            this.gridMealItems.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual;
            this.gridMealItems.ExtendLastCol = true;
            this.gridMealItems.Location = new System.Drawing.Point(273, 45);
            this.gridMealItems.Name = "gridMealItems";
            this.gridMealItems.Rows.Count = 1;
            this.gridMealItems.Rows.DefaultSize = 17;
            this.gridMealItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridMealItems.Size = new System.Drawing.Size(257, 440);
            this.gridMealItems.StyleInfo = resources.GetString("gridMealItems.StyleInfo");
            this.gridMealItems.TabIndex = 13;
            this.gridMealItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridMealItems_DragEnter);
            this.gridMealItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridMealItems_DragDrop);
            this.gridMealItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridMealItems_KeyPress);
            this.gridMealItems.RowColChange += new System.EventHandler(this.gridMealItems_RowColChange);
            this.gridMealItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridMealItems_KeyUp);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnSaveMeal);
            this.panel4.Location = new System.Drawing.Point(605, 494);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 37);
            this.panel4.TabIndex = 157;
            // 
            // btnSaveMeal
            // 
            this.btnSaveMeal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSaveMeal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMeal.Location = new System.Drawing.Point(83, 3);
            this.btnSaveMeal.Name = "btnSaveMeal";
            this.btnSaveMeal.Size = new System.Drawing.Size(75, 31);
            this.btnSaveMeal.TabIndex = 213;
            this.btnSaveMeal.Text = "Save Meals";
            this.btnSaveMeal.Click += new System.EventHandler(this.btnSaveMeal_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.Controls.Add(this.btnNewMeal);
            this.panel6.Controls.Add(this.btnAddDate);
            this.panel6.Location = new System.Drawing.Point(6, 494);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(230, 37);
            this.panel6.TabIndex = 155;
            // 
            // btnNewMeal
            // 
            this.btnNewMeal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnNewMeal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewMeal.Enabled = false;
            this.btnNewMeal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMeal.Location = new System.Drawing.Point(78, 3);
            this.btnNewMeal.Name = "btnNewMeal";
            this.btnNewMeal.Size = new System.Drawing.Size(70, 31);
            this.btnNewMeal.TabIndex = 208;
            this.btnNewMeal.Text = "New Meal";
            this.btnNewMeal.Click += new System.EventHandler(this.btnNewMeal_Click);
            // 
            // btnAddDate
            // 
            this.btnAddDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddDate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDate.Location = new System.Drawing.Point(6, 3);
            this.btnAddDate.Name = "btnAddDate";
            this.btnAddDate.Size = new System.Drawing.Size(70, 31);
            this.btnAddDate.TabIndex = 89;
            this.btnAddDate.Text = "Add Date";
            this.btnAddDate.Click += new System.EventHandler(this.btnAddDate_Click);
            // 
            // tabRooms_
            // 
            this.tabRooms_.Controls.Add(this.btnRemoveFunctionSchedule);
            this.tabRooms_.Controls.Add(this.btnAddFunctionSchedule);
            this.tabRooms_.Controls.Add(this.gridFunctionRooms);
            this.tabRooms_.Controls.Add(this.dtpTime);
            this.tabRooms_.Controls.Add(this.GroupBox2);
            this.tabRooms_.Location = new System.Drawing.Point(4, 23);
            this.tabRooms_.Name = "tabRooms_";
            this.tabRooms_.Size = new System.Drawing.Size(776, 288);
            this.tabRooms_.TabIndex = 10;
            this.tabRooms_.Text = "Event Schedules";
            this.tabRooms_.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFunctionSchedule
            // 
            this.btnRemoveFunctionSchedule.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFunctionSchedule.Location = new System.Drawing.Point(165, 24);
            this.btnRemoveFunctionSchedule.Name = "btnRemoveFunctionSchedule";
            this.btnRemoveFunctionSchedule.Size = new System.Drawing.Size(111, 31);
            this.btnRemoveFunctionSchedule.TabIndex = 182;
            this.btnRemoveFunctionSchedule.Text = "&Remove Schedule";
            this.btnRemoveFunctionSchedule.Click += new System.EventHandler(this.btnRemoveFunctionSchedule_Click);
            // 
            // btnAddFunctionSchedule
            // 
            this.btnAddFunctionSchedule.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFunctionSchedule.Location = new System.Drawing.Point(45, 24);
            this.btnAddFunctionSchedule.Name = "btnAddFunctionSchedule";
            this.btnAddFunctionSchedule.Size = new System.Drawing.Size(111, 31);
            this.btnAddFunctionSchedule.TabIndex = 181;
            this.btnAddFunctionSchedule.Text = "&Add Schedule";
            this.btnAddFunctionSchedule.Click += new System.EventHandler(this.btnAddFunctionSchedule_Click);
            // 
            // gridFunctionRooms
            // 
            this.gridFunctionRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFunctionRooms.ColumnInfo = resources.GetString("gridFunctionRooms.ColumnInfo");
            this.gridFunctionRooms.ExtendLastCol = true;
            this.gridFunctionRooms.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.gridFunctionRooms.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.gridFunctionRooms.Location = new System.Drawing.Point(9, 70);
            this.gridFunctionRooms.Name = "gridFunctionRooms";
            this.gridFunctionRooms.Rows.Count = 1;
            this.gridFunctionRooms.Rows.DefaultSize = 17;
            this.gridFunctionRooms.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridFunctionRooms.Size = new System.Drawing.Size(750, 460);
            this.gridFunctionRooms.StyleInfo = resources.GetString("gridFunctionRooms.StyleInfo");
            this.gridFunctionRooms.TabIndex = 177;
            this.gridFunctionRooms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridFunctionRooms_MouseUp);
            this.gridFunctionRooms.ChangeEdit += new System.EventHandler(this.gridFunctionRooms_ChangeEdit);
            this.gridFunctionRooms.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridFunctionRooms_StartEdit);
            this.gridFunctionRooms.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridFunctionRooms_AfterEdit);
            this.gridFunctionRooms.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.gridFunctionRooms_ValidateEdit);
            this.gridFunctionRooms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridFunctionRooms_MouseUp);
            this.gridFunctionRooms.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridFunctionRooms_BeforeEdit);
            this.gridFunctionRooms.GridChanged += new C1.Win.C1FlexGrid.GridChangedEventHandler(this.gridFunctionRooms_GridChanged);
            this.gridFunctionRooms.RowColChange += new System.EventHandler(this.gridFunctionRooms_RowColChange);
            this.gridFunctionRooms.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridFunctionRooms_CellChanged);
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "hh:mm tt";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(219, 138);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(81, 20);
            this.dtpTime.TabIndex = 178;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GroupBox2.Controls.Add(this.dtpFolioETD);
            this.GroupBox2.Controls.Add(this.label60);
            this.GroupBox2.Controls.Add(this.dtpFolioETA);
            this.GroupBox2.Controls.Add(this.label73);
            this.GroupBox2.Controls.Add(this.dtpTodate);
            this.GroupBox2.Controls.Add(this.dtpFromDate);
            this.GroupBox2.Controls.Add(this.label83);
            this.GroupBox2.Controls.Add(this.label84);
            this.GroupBox2.Enabled = false;
            this.GroupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(9, 454);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(750, 64);
            this.GroupBox2.TabIndex = 183;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Schedule";
            // 
            // dtpFolioETD
            // 
            this.dtpFolioETD.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETD.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETD.CustomFormat = "hh:mm tt";
            this.dtpFolioETD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFolioETD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFolioETD.Location = new System.Drawing.Point(684, 26);
            this.dtpFolioETD.Name = "dtpFolioETD";
            this.dtpFolioETD.ShowUpDown = true;
            this.dtpFolioETD.Size = new System.Drawing.Size(75, 20);
            this.dtpFolioETD.TabIndex = 61;
            this.dtpFolioETD.Value = new System.DateTime(2006, 5, 2, 14, 0, 0, 0);
            this.dtpFolioETD.ValueChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label60.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(625, 29);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(56, 14);
            this.label60.TabIndex = 60;
            this.label60.Text = "End Time :";
            // 
            // dtpFolioETA
            // 
            this.dtpFolioETA.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETA.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpFolioETA.CustomFormat = "hh:mm tt";
            this.dtpFolioETA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFolioETA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFolioETA.Location = new System.Drawing.Point(539, 26);
            this.dtpFolioETA.Name = "dtpFolioETA";
            this.dtpFolioETA.ShowUpDown = true;
            this.dtpFolioETA.Size = new System.Drawing.Size(75, 20);
            this.dtpFolioETA.TabIndex = 59;
            this.dtpFolioETA.Value = new System.DateTime(2009, 3, 24, 12, 0, 0, 0);
            this.dtpFolioETA.ValueChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label73.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(476, 29);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(61, 14);
            this.label73.TabIndex = 58;
            this.label73.Text = "Start Time :";
            // 
            // dtpTodate
            // 
            this.dtpTodate.CustomFormat = "MMM. dd, yyyy";
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTodate.Location = new System.Drawing.Point(298, 26);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(127, 20);
            this.dtpTodate.TabIndex = 31;
            this.dtpTodate.ValueChanged += new System.EventHandler(this.dtpTodate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MMM. dd, yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(85, 26);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(127, 20);
            this.dtpFromDate.TabIndex = 30;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label83.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.Location = new System.Drawing.Point(19, 30);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(62, 13);
            this.label83.TabIndex = 25;
            this.label83.Text = "Arrival :";
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label84.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.Location = new System.Drawing.Point(229, 30);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(61, 13);
            this.label84.TabIndex = 28;
            this.label84.Text = "Departure :";
            // 
            // grpDependentsRoom
            // 
            this.grpDependentsRoom.Controls.Add(this.dtpEventTo);
            this.grpDependentsRoom.Controls.Add(this.dtpEventFrom);
            this.grpDependentsRoom.Controls.Add(this.label81);
            this.grpDependentsRoom.Controls.Add(this.label82);
            this.grpDependentsRoom.Controls.Add(this.btnManualBlockRooms);
            this.grpDependentsRoom.Controls.Add(this.label87);
            this.grpDependentsRoom.Controls.Add(this.txtRoomRemarks);
            this.grpDependentsRoom.Controls.Add(this.gridRooms);
            this.grpDependentsRoom.Controls.Add(this.btnBlock);
            this.grpDependentsRoom.Controls.Add(this.nudGuaranteedRooms);
            this.grpDependentsRoom.Controls.Add(this.nudRooms);
            this.grpDependentsRoom.Controls.Add(this.nudPax);
            this.grpDependentsRoom.Controls.Add(this.label91);
            this.grpDependentsRoom.Controls.Add(this.nudGuaranteedPax);
            this.grpDependentsRoom.Controls.Add(this.label92);
            this.grpDependentsRoom.Controls.Add(this.label94);
            this.grpDependentsRoom.Controls.Add(this.label93);
            this.grpDependentsRoom.Location = new System.Drawing.Point(10, 6);
            this.grpDependentsRoom.Name = "grpDependentsRoom";
            this.grpDependentsRoom.Size = new System.Drawing.Size(545, 362);
            this.grpDependentsRoom.TabIndex = 182;
            this.grpDependentsRoom.TabStop = false;
            this.grpDependentsRoom.Text = "Required Rooms";
            // 
            // dtpEventTo
            // 
            this.dtpEventTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpEventTo.Enabled = false;
            this.dtpEventTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventTo.Location = new System.Drawing.Point(299, 22);
            this.dtpEventTo.Name = "dtpEventTo";
            this.dtpEventTo.Size = new System.Drawing.Size(127, 20);
            this.dtpEventTo.TabIndex = 184;
            this.dtpEventTo.CloseUp += new System.EventHandler(this.dtpEventTo_CloseUp);
            // 
            // dtpEventFrom
            // 
            this.dtpEventFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpEventFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventFrom.Location = new System.Drawing.Point(101, 23);
            this.dtpEventFrom.Name = "dtpEventFrom";
            this.dtpEventFrom.Size = new System.Drawing.Size(127, 20);
            this.dtpEventFrom.TabIndex = 183;
            this.dtpEventFrom.CloseUp += new System.EventHandler(this.dtpEventFrom_CloseUp);
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.Location = new System.Drawing.Point(38, 26);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(62, 13);
            this.label81.TabIndex = 181;
            this.label81.Text = "From Date:";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.Location = new System.Drawing.Point(236, 25);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(61, 13);
            this.label82.TabIndex = 182;
            this.label82.Text = "To Date:";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnManualBlockRooms
            // 
            this.btnManualBlockRooms.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnManualBlockRooms.Enabled = false;
            this.btnManualBlockRooms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualBlockRooms.Location = new System.Drawing.Point(305, 220);
            this.btnManualBlockRooms.Name = "btnManualBlockRooms";
            this.btnManualBlockRooms.Size = new System.Drawing.Size(80, 31);
            this.btnManualBlockRooms.TabIndex = 180;
            this.btnManualBlockRooms.Text = "Block Rooms";
            this.btnManualBlockRooms.Click += new System.EventHandler(this.btnManualBlockRooms_Click);
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(32, 280);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(49, 14);
            this.label87.TabIndex = 170;
            this.label87.Text = "Remarks";
            // 
            // txtRoomRemarks
            // 
            this.txtRoomRemarks.BackColor = System.Drawing.Color.White;
            this.txtRoomRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRoomRemarks.Location = new System.Drawing.Point(87, 280);
            this.txtRoomRemarks.Multiline = true;
            this.txtRoomRemarks.Name = "txtRoomRemarks";
            this.txtRoomRemarks.Size = new System.Drawing.Size(416, 71);
            this.txtRoomRemarks.TabIndex = 169;
            // 
            // gridRooms
            // 
            this.gridRooms.ColumnInfo = resources.GetString("gridRooms.ColumnInfo");
            this.gridRooms.Location = new System.Drawing.Point(35, 59);
            this.gridRooms.Name = "gridRooms";
            this.gridRooms.Rows.Count = 1;
            this.gridRooms.Rows.DefaultSize = 17;
            this.gridRooms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRooms.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridRooms.Size = new System.Drawing.Size(468, 155);
            this.gridRooms.StyleInfo = resources.GetString("gridRooms.StyleInfo");
            this.gridRooms.TabIndex = 176;
            this.gridRooms.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridRooms_AfterEdit);
            this.gridRooms.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.gridRooms_ValidateEdit);
            this.gridRooms.RowColChange += new System.EventHandler(this.gridRooms_RowColChange);
            this.gridRooms.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridRooms_CellChanged);
            // 
            // btnBlock
            // 
            this.btnBlock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnBlock.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlock.Location = new System.Drawing.Point(387, 220);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(116, 31);
            this.btnBlock.TabIndex = 179;
            this.btnBlock.Text = "Auto-Block Rooms";
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // nudGuaranteedRooms
            // 
            this.nudGuaranteedRooms.Enabled = false;
            this.nudGuaranteedRooms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGuaranteedRooms.Location = new System.Drawing.Point(231, 252);
            this.nudGuaranteedRooms.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGuaranteedRooms.Name = "nudGuaranteedRooms";
            this.nudGuaranteedRooms.ReadOnly = true;
            this.nudGuaranteedRooms.Size = new System.Drawing.Size(60, 20);
            this.nudGuaranteedRooms.TabIndex = 165;
            this.nudGuaranteedRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudRooms
            // 
            this.nudRooms.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRooms.Location = new System.Drawing.Point(87, 252);
            this.nudRooms.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRooms.Name = "nudRooms";
            this.nudRooms.Size = new System.Drawing.Size(55, 20);
            this.nudRooms.TabIndex = 164;
            this.nudRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudPax
            // 
            this.nudPax.Enabled = false;
            this.nudPax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPax.Location = new System.Drawing.Point(87, 225);
            this.nudPax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPax.Name = "nudPax";
            this.nudPax.ReadOnly = true;
            this.nudPax.Size = new System.Drawing.Size(55, 20);
            this.nudPax.TabIndex = 52;
            this.nudPax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(148, 255);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(81, 14);
            this.label91.TabIndex = 156;
            this.label91.Text = "Blocked Rooms";
            // 
            // nudGuaranteedPax
            // 
            this.nudGuaranteedPax.Enabled = false;
            this.nudGuaranteedPax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGuaranteedPax.InterceptArrowKeys = false;
            this.nudGuaranteedPax.Location = new System.Drawing.Point(231, 225);
            this.nudGuaranteedPax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGuaranteedPax.Name = "nudGuaranteedPax";
            this.nudGuaranteedPax.ReadOnly = true;
            this.nudGuaranteedPax.Size = new System.Drawing.Size(60, 20);
            this.nudGuaranteedPax.TabIndex = 163;
            this.nudGuaranteedPax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(32, 255);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(40, 14);
            this.label92.TabIndex = 154;
            this.label92.Text = "Rooms";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(32, 228);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(25, 14);
            this.label94.TabIndex = 150;
            this.label94.Text = "Pax";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(152, 228);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(77, 14);
            this.label93.TabIndex = 152;
            this.label93.Text = "Pax w/ Rooms";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gridBlockedRooms);
            this.groupBox7.Location = new System.Drawing.Point(565, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(242, 362);
            this.groupBox7.TabIndex = 183;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Blocked Rooms";
            // 
            // gridBlockedRooms
            // 
            this.gridBlockedRooms.AllowEditing = false;
            this.gridBlockedRooms.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            this.gridBlockedRooms.ColumnInfo = resources.GetString("gridBlockedRooms.ColumnInfo");
            this.gridBlockedRooms.ExtendLastCol = true;
            this.gridBlockedRooms.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.gridBlockedRooms.Location = new System.Drawing.Point(11, 25);
            this.gridBlockedRooms.Name = "gridBlockedRooms";
            this.gridBlockedRooms.Rows.Count = 1;
            this.gridBlockedRooms.Rows.DefaultSize = 17;
            this.gridBlockedRooms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridBlockedRooms.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridBlockedRooms.Size = new System.Drawing.Size(223, 328);
            this.gridBlockedRooms.StyleInfo = resources.GetString("gridBlockedRooms.StyleInfo");
            this.gridBlockedRooms.TabIndex = 177;
            // 
            // tabWedding_
            // 
            this.tabWedding_.Controls.Add(this.grpNotesRemarks);
            this.tabWedding_.Controls.Add(this.grpEventDetails);
            this.tabWedding_.Location = new System.Drawing.Point(4, 23);
            this.tabWedding_.Name = "tabWedding_";
            this.tabWedding_.Size = new System.Drawing.Size(776, 288);
            this.tabWedding_.TabIndex = 7;
            this.tabWedding_.Text = "Event Details";
            this.tabWedding_.UseVisualStyleBackColor = true;
            // 
            // grpNotesRemarks
            // 
            this.grpNotesRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNotesRemarks.Controls.Add(this.tableLayoutPanel1);
            this.grpNotesRemarks.Location = new System.Drawing.Point(416, 3);
            this.grpNotesRemarks.Name = "grpNotesRemarks";
            this.grpNotesRemarks.Size = new System.Drawing.Size(357, 527);
            this.grpNotesRemarks.TabIndex = 196;
            this.grpNotesRemarks.TabStop = false;
            this.grpNotesRemarks.Text = "Notes / Remarks";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.72464F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.27536F));
            this.tableLayoutPanel1.Controls.Add(this.label42, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLobbyPosting, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label44, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSignatories, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label65, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBillingArrangement, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 67);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 232);
            this.tableLayoutPanel1.TabIndex = 155;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Dock = System.Windows.Forms.DockStyle.Top;
            this.label42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(3, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(95, 28);
            this.label42.TabIndex = 150;
            this.label42.Text = "Billing Arrangement";
            this.label42.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtLobbyPosting
            // 
            this.txtLobbyPosting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLobbyPosting.BackColor = System.Drawing.Color.White;
            this.txtLobbyPosting.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLobbyPosting.Location = new System.Drawing.Point(104, 157);
            this.txtLobbyPosting.Multiline = true;
            this.txtLobbyPosting.Name = "txtLobbyPosting";
            this.txtLobbyPosting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLobbyPosting.Size = new System.Drawing.Size(224, 72);
            this.txtLobbyPosting.TabIndex = 23;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Dock = System.Windows.Forms.DockStyle.Top;
            this.label44.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(3, 77);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(95, 28);
            this.label44.TabIndex = 152;
            this.label44.Text = "Authorized Signatory";
            this.label44.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtSignatories
            // 
            this.txtSignatories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSignatories.BackColor = System.Drawing.Color.White;
            this.txtSignatories.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSignatories.Location = new System.Drawing.Point(104, 80);
            this.txtSignatories.Multiline = true;
            this.txtSignatories.Name = "txtSignatories";
            this.txtSignatories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSignatories.Size = new System.Drawing.Size(224, 71);
            this.txtSignatories.TabIndex = 22;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Dock = System.Windows.Forms.DockStyle.Top;
            this.label65.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(3, 154);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(95, 14);
            this.label65.TabIndex = 154;
            this.label65.Text = "Lobby Posting";
            this.label65.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtBillingArrangement
            // 
            this.txtBillingArrangement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBillingArrangement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBillingArrangement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBillingArrangement.BackColor = System.Drawing.Color.White;
            this.txtBillingArrangement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBillingArrangement.Location = new System.Drawing.Point(104, 3);
            this.txtBillingArrangement.Multiline = true;
            this.txtBillingArrangement.Name = "txtBillingArrangement";
            this.txtBillingArrangement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBillingArrangement.Size = new System.Drawing.Size(224, 71);
            this.txtBillingArrangement.TabIndex = 21;
            // 
            // grpEventDetails
            // 
            this.grpEventDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEventDetails.Controls.Add(this.label46);
            this.grpEventDetails.Controls.Add(this.txtEventType);
            this.grpEventDetails.Controls.Add(this.gridEventDetails);
            this.grpEventDetails.Location = new System.Drawing.Point(3, 3);
            this.grpEventDetails.Name = "grpEventDetails";
            this.grpEventDetails.Size = new System.Drawing.Size(410, 527);
            this.grpEventDetails.TabIndex = 1;
            this.grpEventDetails.TabStop = false;
            this.grpEventDetails.Text = "Event Details";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(23, 34);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(66, 14);
            this.label46.TabIndex = 159;
            this.label46.Text = "Event Type :";
            // 
            // txtEventType
            // 
            this.txtEventType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEventType.Enabled = false;
            this.txtEventType.Location = new System.Drawing.Point(90, 31);
            this.txtEventType.Name = "txtEventType";
            this.txtEventType.Size = new System.Drawing.Size(161, 20);
            this.txtEventType.TabIndex = 158;
            // 
            // gridEventDetails
            // 
            this.gridEventDetails.AllowAddNew = true;
            this.gridEventDetails.AllowDelete = true;
            this.gridEventDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEventDetails.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:142;Caption:\"Detail Header\";TextAlign:LeftCenter;Tex" +
                "tAlignFixed:CenterCenter;}\t1{Width:164;Caption:\"Value\";TextAlign:LeftCenter;Text" +
                "AlignFixed:CenterCenter;}\t";
            this.gridEventDetails.ExtendLastCol = true;
            this.gridEventDetails.Location = new System.Drawing.Point(9, 62);
            this.gridEventDetails.Name = "gridEventDetails";
            this.gridEventDetails.Rows.Count = 1;
            this.gridEventDetails.Rows.DefaultSize = 17;
            this.gridEventDetails.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridEventDetails.Size = new System.Drawing.Size(393, 459);
            this.gridEventDetails.StyleInfo = resources.GetString("gridEventDetails.StyleInfo");
            this.gridEventDetails.TabIndex = 1;
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreatedBy.BackColor = System.Drawing.Color.White;
            this.txtCreatedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreatedBy.Location = new System.Drawing.Point(377, 335);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(103, 20);
            this.txtCreatedBy.TabIndex = 310;
            // 
            // txtUpdatedBy
            // 
            this.txtUpdatedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdatedBy.BackColor = System.Drawing.Color.White;
            this.txtUpdatedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUpdatedBy.Location = new System.Drawing.Point(268, 335);
            this.txtUpdatedBy.Name = "txtUpdatedBy";
            this.txtUpdatedBy.ReadOnly = true;
            this.txtUpdatedBy.Size = new System.Drawing.Size(103, 20);
            this.txtUpdatedBy.TabIndex = 312;
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(382, 316);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(79, 16);
            this.label47.TabIndex = 192;
            this.label47.Text = "Reserved by";
            // 
            // label74
            // 
            this.label74.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label74.BackColor = System.Drawing.SystemColors.Control;
            this.label74.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(265, 316);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(79, 16);
            this.label74.TabIndex = 311;
            this.label74.Text = "Updated by";
            // 
            // cboPurpose
            // 
            this.cboPurpose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPurpose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPurpose.BackColor = System.Drawing.SystemColors.Info;
            this.cboPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPurpose.FormattingEnabled = true;
            this.cboPurpose.Location = new System.Drawing.Point(103, 58);
            this.cboPurpose.Name = "cboPurpose";
            this.cboPurpose.Size = new System.Drawing.Size(194, 22);
            this.cboPurpose.TabIndex = 308;
            this.cboPurpose.SelectionChangeCommitted += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // cboAccountType
            // 
            this.cboAccountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAccountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccountType.BackColor = System.Drawing.SystemColors.Info;
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.Location = new System.Drawing.Point(103, 8);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(194, 22);
            this.cboAccountType.TabIndex = 306;
            this.cboAccountType.SelectionChangeCommitted += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // cboSales_Executive
            // 
            this.cboSales_Executive.BackColor = System.Drawing.SystemColors.Info;
            this.cboSales_Executive.FormattingEnabled = true;
            this.cboSales_Executive.Location = new System.Drawing.Point(140, 65);
            this.cboSales_Executive.Name = "cboSales_Executive";
            this.cboSales_Executive.Size = new System.Drawing.Size(127, 22);
            this.cboSales_Executive.TabIndex = 39;
            this.cboSales_Executive.SelectionChangeCommitted += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.SystemColors.Control;
            this.label56.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(3, 10);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(94, 16);
            this.label56.TabIndex = 193;
            this.label56.Text = "Account Type";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.SystemColors.Control;
            this.label58.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Black;
            this.label58.Location = new System.Drawing.Point(3, 60);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(94, 16);
            this.label58.TabIndex = 197;
            this.label58.Text = "Market Segment";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(18, 67);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(124, 16);
            this.label48.TabIndex = 189;
            this.label48.Text = "Marketing Officer";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.SystemColors.Control;
            this.label57.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.Location = new System.Drawing.Point(5, 144);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(94, 16);
            this.label57.TabIndex = 195;
            this.label57.Text = "Payment Mode";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPayment_Mode
            // 
            this.cboPayment_Mode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPayment_Mode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPayment_Mode.BackColor = System.Drawing.SystemColors.Info;
            this.cboPayment_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayment_Mode.FormattingEnabled = true;
            this.cboPayment_Mode.Location = new System.Drawing.Point(103, 142);
            this.cboPayment_Mode.Name = "cboPayment_Mode";
            this.cboPayment_Mode.Size = new System.Drawing.Size(193, 22);
            this.cboPayment_Mode.TabIndex = 307;
            this.cboPayment_Mode.SelectionChangeCommitted += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // grpRequirements
            // 
            this.grpRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRequirements.Controls.Add(this.panel2);
            this.grpRequirements.Controls.Add(this.label101);
            this.grpRequirements.Controls.Add(this.gridReqSchedules);
            this.grpRequirements.Controls.Add(this.txtRequirementNote);
            this.grpRequirements.Controls.Add(this.btnRemoveRequirements);
            this.grpRequirements.Controls.Add(this.btnAddRequirements);
            this.grpRequirements.Controls.Add(this.treeRequirements);
            this.grpRequirements.Controls.Add(this.lvwDetails);
            this.grpRequirements.Controls.Add(this.label45);
            this.grpRequirements.Controls.Add(this.cboRequirementType);
            this.grpRequirements.Controls.Add(this.cboReqDate);
            this.grpRequirements.Location = new System.Drawing.Point(6, 6);
            this.grpRequirements.Name = "grpRequirements";
            this.grpRequirements.Size = new System.Drawing.Size(764, 516);
            this.grpRequirements.TabIndex = 2;
            this.grpRequirements.TabStop = false;
            this.grpRequirements.Text = "Requirements";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnSaveRequirements);
            this.panel2.Location = new System.Drawing.Point(615, 466);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 50);
            this.panel2.TabIndex = 183;
            // 
            // btnSaveRequirements
            // 
            this.btnSaveRequirements.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSaveRequirements.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRequirements.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.pastfile16;
            this.btnSaveRequirements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveRequirements.Location = new System.Drawing.Point(32, 8);
            this.btnSaveRequirements.Name = "btnSaveRequirements";
            this.btnSaveRequirements.Size = new System.Drawing.Size(96, 36);
            this.btnSaveRequirements.TabIndex = 89;
            this.btnSaveRequirements.Text = "Save\r\n     Requirements";
            this.btnSaveRequirements.Click += new System.EventHandler(this.btnSaveRequirements_Click);
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(8, 18);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(58, 14);
            this.label101.TabIndex = 182;
            this.label101.Text = "Schedules";
            // 
            // gridReqSchedules
            // 
            this.gridReqSchedules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridReqSchedules.ColumnInfo = resources.GetString("gridReqSchedules.ColumnInfo");
            this.gridReqSchedules.ExtendLastCol = true;
            this.gridReqSchedules.Location = new System.Drawing.Point(11, 38);
            this.gridReqSchedules.Name = "gridReqSchedules";
            this.gridReqSchedules.Rows.Count = 1;
            this.gridReqSchedules.Rows.DefaultSize = 17;
            this.gridReqSchedules.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridReqSchedules.Size = new System.Drawing.Size(265, 466);
            this.gridReqSchedules.StyleInfo = resources.GetString("gridReqSchedules.StyleInfo");
            this.gridReqSchedules.TabIndex = 181;
            this.gridReqSchedules.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridReqSchedules_BeforeEdit);
            // 
            // txtRequirementNote
            // 
            this.txtRequirementNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRequirementNote.Location = new System.Drawing.Point(293, 436);
            this.txtRequirementNote.Multiline = true;
            this.txtRequirementNote.Name = "txtRequirementNote";
            this.txtRequirementNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequirementNote.Size = new System.Drawing.Size(362, 68);
            this.txtRequirementNote.TabIndex = 179;
            // 
            // btnRemoveRequirements
            // 
            this.btnRemoveRequirements.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnRemoveRequirements.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRequirements.Location = new System.Drawing.Point(664, 172);
            this.btnRemoveRequirements.Name = "btnRemoveRequirements";
            this.btnRemoveRequirements.Size = new System.Drawing.Size(29, 25);
            this.btnRemoveRequirements.TabIndex = 178;
            this.btnRemoveRequirements.Text = "<";
            this.btnRemoveRequirements.Click += new System.EventHandler(this.btnRemoveRequirements_Click);
            // 
            // btnAddRequirements
            // 
            this.btnAddRequirements.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddRequirements.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRequirements.Location = new System.Drawing.Point(664, 140);
            this.btnAddRequirements.Name = "btnAddRequirements";
            this.btnAddRequirements.Size = new System.Drawing.Size(29, 25);
            this.btnAddRequirements.TabIndex = 177;
            this.btnAddRequirements.Text = ">";
            this.btnAddRequirements.Click += new System.EventHandler(this.btnAddRequirements_Click);
            // 
            // treeRequirements
            // 
            this.treeRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeRequirements.ContextMenuStrip = this.mnuTreeRequirements;
            this.treeRequirements.FullRowSelect = true;
            this.treeRequirements.HideSelection = false;
            this.treeRequirements.Location = new System.Drawing.Point(700, 36);
            this.treeRequirements.Name = "treeRequirements";
            this.treeRequirements.Size = new System.Drawing.Size(54, 394);
            this.treeRequirements.TabIndex = 176;
            // 
            // mnuTreeRequirements
            // 
            this.mnuTreeRequirements.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.mnuTreeRequirements.Name = "mnuTreeRequirements";
            this.mnuTreeRequirements.Size = new System.Drawing.Size(145, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // lvwDetails
            // 
            this.lvwDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwDetails.CheckBoxes = true;
            this.lvwDetails.LabelEdit = true;
            this.lvwDetails.Location = new System.Drawing.Point(293, 66);
            this.lvwDetails.Name = "lvwDetails";
            this.lvwDetails.Size = new System.Drawing.Size(362, 364);
            this.lvwDetails.TabIndex = 175;
            this.lvwDetails.UseCompatibleStateImageBehavior = false;
            this.lvwDetails.View = System.Windows.Forms.View.List;
            this.lvwDetails.DoubleClick += new System.EventHandler(this.lvwDetails_DoubleClick);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(290, 21);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(93, 14);
            this.label45.TabIndex = 174;
            this.label45.Text = "Requirement Type";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboRequirementType
            // 
            this.cboRequirementType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRequirementType.Location = new System.Drawing.Point(293, 38);
            this.cboRequirementType.Name = "cboRequirementType";
            this.cboRequirementType.Size = new System.Drawing.Size(362, 22);
            this.cboRequirementType.TabIndex = 173;
            this.cboRequirementType.SelectedIndexChanged += new System.EventHandler(this.cboRequirementType_SelectedIndexChanged);
            this.cboRequirementType.DropDownClosed += new System.EventHandler(this.cboRequirementType_DropDownClosed);
            // 
            // cboReqDate
            // 
            this.cboReqDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReqDate.FormattingEnabled = true;
            this.cboReqDate.Location = new System.Drawing.Point(141, 60);
            this.cboReqDate.Name = "cboReqDate";
            this.cboReqDate.Size = new System.Drawing.Size(121, 22);
            this.cboReqDate.TabIndex = 184;
            // 
            // tabEventDetails_
            // 
            this.tabEventDetails_.Controls.Add(this.groupContacts);
            this.tabEventDetails_.Controls.Add(this.grpInfo);
            this.tabEventDetails_.Controls.Add(this.groupBox4);
            this.tabEventDetails_.Controls.Add(this.grpBillingDeposits);
            this.tabEventDetails_.Controls.Add(this.groupBox11);
            this.tabEventDetails_.Controls.Add(this.groupBox8);
            this.tabEventDetails_.Location = new System.Drawing.Point(4, 23);
            this.tabEventDetails_.Name = "tabEventDetails_";
            this.tabEventDetails_.Size = new System.Drawing.Size(776, 288);
            this.tabEventDetails_.TabIndex = 5;
            this.tabEventDetails_.Text = "Booking Info ";
            this.tabEventDetails_.UseVisualStyleBackColor = true;
            // 
            // groupContacts
            // 
            this.groupContacts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupContacts.Controls.Add(this.gridContacts);
            this.groupContacts.Controls.Add(this.pnlDate);
            this.groupContacts.Location = new System.Drawing.Point(10, 6);
            this.groupContacts.Name = "groupContacts";
            this.groupContacts.Size = new System.Drawing.Size(763, 128);
            this.groupContacts.TabIndex = 166;
            this.groupContacts.TabStop = false;
            this.groupContacts.Text = "Contact Person/s";
            // 
            // gridContacts
            // 
            this.gridContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridContacts.ColumnInfo = resources.GetString("gridContacts.ColumnInfo");
            this.gridContacts.Location = new System.Drawing.Point(10, 23);
            this.gridContacts.Name = "gridContacts";
            this.gridContacts.Rows.Count = 1;
            this.gridContacts.Rows.DefaultSize = 17;
            this.gridContacts.Size = new System.Drawing.Size(746, 99);
            this.gridContacts.StyleInfo = resources.GetString("gridContacts.StyleInfo");
            this.gridContacts.TabIndex = 0;
            this.gridContacts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridContacts_MouseClick);
            this.gridContacts.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridContacts_AfterEdit);
            this.gridContacts.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridContacts_BeforeEdit);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtEmail1);
            this.grpInfo.Controls.Add(this.label100);
            this.grpInfo.Controls.Add(this.label25);
            this.grpInfo.Controls.Add(this.label24);
            this.grpInfo.Controls.Add(this.label23);
            this.grpInfo.Controls.Add(this.txtZip1);
            this.grpInfo.Controls.Add(this.txtCountry1);
            this.grpInfo.Controls.Add(this.txtCity1);
            this.grpInfo.Controls.Add(this.txtStreet1);
            this.grpInfo.Controls.Add(this.txtContactNumber2);
            this.grpInfo.Controls.Add(this.label72);
            this.grpInfo.Controls.Add(this.txtContactNumber3);
            this.grpInfo.Controls.Add(this.label68);
            this.grpInfo.Controls.Add(this.txtDesignation);
            this.grpInfo.Controls.Add(this.label27);
            this.grpInfo.Controls.Add(this.txtContactNumber1);
            this.grpInfo.Controls.Add(this.label28);
            this.grpInfo.Controls.Add(this.label30);
            this.grpInfo.Controls.Add(this.txtContactPerson);
            this.grpInfo.Controls.Add(this.label33);
            this.grpInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.Location = new System.Drawing.Point(467, 97);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(41, 28);
            this.grpInfo.TabIndex = 191;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Group Information";
            // 
            // txtEmail1
            // 
            this.txtEmail1.BackColor = System.Drawing.Color.White;
            this.txtEmail1.Location = new System.Drawing.Point(387, 75);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(122, 20);
            this.txtEmail1.TabIndex = 164;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.Location = new System.Drawing.Point(397, 60);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(56, 14);
            this.label100.TabIndex = 165;
            this.label100.Text = "Email Add.";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(397, 101);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 14);
            this.label25.TabIndex = 163;
            this.label25.Text = "Zip Code";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(274, 101);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 14);
            this.label24.TabIndex = 162;
            this.label24.Text = "Country";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(148, 102);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(25, 14);
            this.label23.TabIndex = 161;
            this.label23.Text = "City";
            // 
            // txtZip1
            // 
            this.txtZip1.BackColor = System.Drawing.Color.White;
            this.txtZip1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZip1.Location = new System.Drawing.Point(388, 118);
            this.txtZip1.Name = "txtZip1";
            this.txtZip1.Size = new System.Drawing.Size(121, 20);
            this.txtZip1.TabIndex = 17;
            // 
            // txtCountry1
            // 
            this.txtCountry1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCountry1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCountry1.BackColor = System.Drawing.Color.White;
            this.txtCountry1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry1.Location = new System.Drawing.Point(263, 118);
            this.txtCountry1.Name = "txtCountry1";
            this.txtCountry1.Size = new System.Drawing.Size(121, 20);
            this.txtCountry1.TabIndex = 16;
            // 
            // txtCity1
            // 
            this.txtCity1.BackColor = System.Drawing.Color.White;
            this.txtCity1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity1.Location = new System.Drawing.Point(137, 118);
            this.txtCity1.Name = "txtCity1";
            this.txtCity1.Size = new System.Drawing.Size(122, 20);
            this.txtCity1.TabIndex = 15;
            // 
            // txtStreet1
            // 
            this.txtStreet1.BackColor = System.Drawing.Color.White;
            this.txtStreet1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStreet1.Location = new System.Drawing.Point(12, 118);
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size(122, 20);
            this.txtStreet1.TabIndex = 14;
            // 
            // txtContactNumber2
            // 
            this.txtContactNumber2.BackColor = System.Drawing.Color.White;
            this.txtContactNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactNumber2.Location = new System.Drawing.Point(137, 75);
            this.txtContactNumber2.MaxLength = 15;
            this.txtContactNumber2.Name = "txtContactNumber2";
            this.txtContactNumber2.Size = new System.Drawing.Size(122, 20);
            this.txtContactNumber2.TabIndex = 12;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(151, 61);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(44, 14);
            this.label72.TabIndex = 156;
            this.label72.Text = "Fax No.";
            // 
            // txtContactNumber3
            // 
            this.txtContactNumber3.BackColor = System.Drawing.Color.White;
            this.txtContactNumber3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactNumber3.Location = new System.Drawing.Point(262, 75);
            this.txtContactNumber3.Name = "txtContactNumber3";
            this.txtContactNumber3.Size = new System.Drawing.Size(122, 20);
            this.txtContactNumber3.TabIndex = 13;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(272, 60);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(56, 14);
            this.label68.TabIndex = 154;
            this.label68.Text = "Mobile No.";
            // 
            // txtDesignation
            // 
            this.txtDesignation.BackColor = System.Drawing.Color.White;
            this.txtDesignation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesignation.Location = new System.Drawing.Point(356, 38);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(153, 20);
            this.txtDesignation.TabIndex = 10;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(367, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 14);
            this.label27.TabIndex = 152;
            this.label27.Text = "Position";
            // 
            // txtContactNumber1
            // 
            this.txtContactNumber1.BackColor = System.Drawing.Color.White;
            this.txtContactNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactNumber1.Location = new System.Drawing.Point(12, 76);
            this.txtContactNumber1.MaxLength = 15;
            this.txtContactNumber1.Name = "txtContactNumber1";
            this.txtContactNumber1.Size = new System.Drawing.Size(122, 20);
            this.txtContactNumber1.TabIndex = 11;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(21, 61);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(42, 14);
            this.label28.TabIndex = 150;
            this.label28.Text = "Tel. No.";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(21, 101);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(36, 14);
            this.label30.TabIndex = 148;
            this.label30.Text = "Street";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.BackColor = System.Drawing.Color.White;
            this.txtContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPerson.Location = new System.Drawing.Point(12, 38);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(339, 20);
            this.txtContactPerson.TabIndex = 9;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(21, 23);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(81, 14);
            this.label33.TabIndex = 146;
            this.label33.Text = "Contact Person";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.panel3);
            this.groupBox4.Location = new System.Drawing.Point(232, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 381);
            this.groupBox4.TabIndex = 199;
            this.groupBox4.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label137);
            this.panel3.Controls.Add(this.txtGroupRemarks);
            this.panel3.Controls.Add(this.txtEstimatedBal);
            this.panel3.Controls.Add(this.label66);
            this.panel3.Controls.Add(this.cboEventGrpPackage);
            this.panel3.Controls.Add(this.lblLiveOut);
            this.panel3.Controls.Add(this.nudNumberOfPaxLiveOut);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.txtTotalEstimatedCost);
            this.panel3.Controls.Add(this.lblLiveIn);
            this.panel3.Controls.Add(this.nudPaxGuaranteed);
            this.panel3.Controls.Add(this.txtCreatedBy);
            this.panel3.Controls.Add(this.label56);
            this.panel3.Controls.Add(this.nudNumberOfPaxLiveIn);
            this.panel3.Controls.Add(this.label70);
            this.panel3.Controls.Add(this.cboAccountType);
            this.panel3.Controls.Add(this.txtUpdatedBy);
            this.panel3.Controls.Add(this.label58);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.cboPayment_Mode);
            this.panel3.Controls.Add(this.cboEventType);
            this.panel3.Controls.Add(this.cboSource);
            this.panel3.Controls.Add(this.label74);
            this.panel3.Controls.Add(this.cboPurpose);
            this.panel3.Controls.Add(this.label37);
            this.panel3.Controls.Add(this.label57);
            this.panel3.Controls.Add(this.label63);
            this.panel3.Controls.Add(this.txtArrivalDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 362);
            this.panel3.TabIndex = 156;
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(303, 11);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(98, 14);
            this.label137.TabIndex = 314;
            this.label137.Text = "Estimated Balance:";
            // 
            // txtGroupRemarks
            // 
            this.txtGroupRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGroupRemarks.Location = new System.Drawing.Point(103, 196);
            this.txtGroupRemarks.Multiline = true;
            this.txtGroupRemarks.Name = "txtGroupRemarks";
            this.txtGroupRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroupRemarks.Size = new System.Drawing.Size(194, 245);
            this.txtGroupRemarks.TabIndex = 7;
            // 
            // txtEstimatedBal
            // 
            this.txtEstimatedBal.Enabled = false;
            this.txtEstimatedBal.Location = new System.Drawing.Point(407, 8);
            this.txtEstimatedBal.Name = "txtEstimatedBal";
            this.txtEstimatedBal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEstimatedBal.Size = new System.Drawing.Size(117, 20);
            this.txtEstimatedBal.TabIndex = 313;
            this.txtEstimatedBal.Text = "0.00";
            this.txtEstimatedBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label66
            // 
            this.label66.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label66.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(3, 199);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(72, 245);
            this.label66.TabIndex = 165;
            this.label66.Text = "Remarks";
            // 
            // cboEventGrpPackage
            // 
            this.cboEventGrpPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEventGrpPackage.Location = new System.Drawing.Point(103, 111);
            this.cboEventGrpPackage.Name = "cboEventGrpPackage";
            this.cboEventGrpPackage.Size = new System.Drawing.Size(194, 22);
            this.cboEventGrpPackage.TabIndex = 20;
            this.cboEventGrpPackage.SelectionChangeCommitted += new System.EventHandler(this.cboEventGrpPackage_SelectionChangeCommitted);
            this.cboEventGrpPackage.SelectedIndexChanged += new System.EventHandler(this.cboEventPackage_SelectionChangeCommitted);
            this.cboEventGrpPackage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboEventGrpPackage_KeyUp);
            // 
            // lblLiveOut
            // 
            this.lblLiveOut.AutoSize = true;
            this.lblLiveOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiveOut.Location = new System.Drawing.Point(419, 96);
            this.lblLiveOut.Name = "lblLiveOut";
            this.lblLiveOut.Size = new System.Drawing.Size(51, 14);
            this.lblLiveOut.TabIndex = 50;
            this.lblLiveOut.Text = "Max. Pax";
            // 
            // nudNumberOfPaxLiveOut
            // 
            this.nudNumberOfPaxLiveOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumberOfPaxLiveOut.Location = new System.Drawing.Point(313, 113);
            this.nudNumberOfPaxLiveOut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNumberOfPaxLiveOut.Name = "nudNumberOfPaxLiveOut";
            this.nudNumberOfPaxLiveOut.Size = new System.Drawing.Size(61, 20);
            this.nudNumberOfPaxLiveOut.TabIndex = 111;
            this.nudNumberOfPaxLiveOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNumberOfPaxLiveOut.ThousandsSeparator = true;
            this.nudNumberOfPaxLiveOut.ValueChanged += new System.EventHandler(this.nudNumberOfPaxLiveOut_ValueChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(5, 114);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(78, 14);
            this.label41.TabIndex = 208;
            this.label41.Text = "Event Package";
            // 
            // txtTotalEstimatedCost
            // 
            this.txtTotalEstimatedCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalEstimatedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalEstimatedCost.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalEstimatedCost.Location = new System.Drawing.Point(103, 170);
            this.txtTotalEstimatedCost.Name = "txtTotalEstimatedCost";
            this.txtTotalEstimatedCost.Size = new System.Drawing.Size(193, 20);
            this.txtTotalEstimatedCost.TabIndex = 109;
            this.txtTotalEstimatedCost.Text = "0.00";
            this.txtTotalEstimatedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalEstimatedCost.TextChanged += new System.EventHandler(this.txtTotalEstimatedCost_TextChanged_1);
            this.txtTotalEstimatedCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lblLiveIn
            // 
            this.lblLiveIn.AutoSize = true;
            this.lblLiveIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiveIn.Location = new System.Drawing.Point(314, 96);
            this.lblLiveIn.Name = "lblLiveIn";
            this.lblLiveIn.Size = new System.Drawing.Size(47, 14);
            this.lblLiveIn.TabIndex = 51;
            this.lblLiveIn.Text = "Min. Pax";
            // 
            // nudPaxGuaranteed
            // 
            this.nudPaxGuaranteed.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPaxGuaranteed.Location = new System.Drawing.Point(418, 112);
            this.nudPaxGuaranteed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPaxGuaranteed.Name = "nudPaxGuaranteed";
            this.nudPaxGuaranteed.Size = new System.Drawing.Size(61, 20);
            this.nudPaxGuaranteed.TabIndex = 112;
            this.nudPaxGuaranteed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPaxGuaranteed.ThousandsSeparator = true;
            // 
            // nudNumberOfPaxLiveIn
            // 
            this.nudNumberOfPaxLiveIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumberOfPaxLiveIn.Location = new System.Drawing.Point(313, 112);
            this.nudNumberOfPaxLiveIn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNumberOfPaxLiveIn.Name = "nudNumberOfPaxLiveIn";
            this.nudNumberOfPaxLiveIn.Size = new System.Drawing.Size(61, 20);
            this.nudNumberOfPaxLiveIn.TabIndex = 110;
            this.nudNumberOfPaxLiveIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudNumberOfPaxLiveIn.ValueChanged += new System.EventHandler(this.nudNumberOfPaxLiveIn_ValueChanged);
            // 
            // label70
            // 
            this.label70.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(2, 173);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(106, 14);
            this.label70.TabIndex = 208;
            this.label70.Text = "Total Estimated Cost:";
            // 
            // cboEventType
            // 
            this.cboEventType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEventType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEventType.BackColor = System.Drawing.SystemColors.Info;
            this.cboEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEventType.FormattingEnabled = true;
            this.cboEventType.Location = new System.Drawing.Point(103, 84);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.Size = new System.Drawing.Size(194, 22);
            this.cboEventType.TabIndex = 19;
            this.cboEventType.SelectedIndexChanged += new System.EventHandler(this.cboEventType_SelectedIndexChanged);
            // 
            // cboSource
            // 
            this.cboSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSource.BackColor = System.Drawing.SystemColors.Info;
            this.cboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Items.AddRange(new object[] {
            "PHONE",
            "FAX",
            "WALK-IN",
            "SALES"});
            this.cboSource.Location = new System.Drawing.Point(103, 33);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(194, 22);
            this.cboSource.TabIndex = 18;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(5, 87);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(60, 14);
            this.label37.TabIndex = 203;
            this.label37.Text = "Event Type";
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.SystemColors.Control;
            this.label63.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.Color.Black;
            this.label63.Location = new System.Drawing.Point(3, 36);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(84, 16);
            this.label63.TabIndex = 205;
            this.label63.Text = "Source";
            // 
            // txtArrivalDate
            // 
            this.txtArrivalDate.BackColor = System.Drawing.Color.White;
            this.txtArrivalDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArrivalDate.Location = new System.Drawing.Point(124, 12);
            this.txtArrivalDate.Name = "txtArrivalDate";
            this.txtArrivalDate.Size = new System.Drawing.Size(145, 20);
            this.txtArrivalDate.TabIndex = 131;
            // 
            // grpBillingDeposits
            // 
            this.grpBillingDeposits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBillingDeposits.Controls.Add(this.grdDeposits);
            this.grpBillingDeposits.Controls.Add(this.btnNewDeposit);
            this.grpBillingDeposits.Location = new System.Drawing.Point(5, 147);
            this.grpBillingDeposits.Name = "grpBillingDeposits";
            this.grpBillingDeposits.Size = new System.Drawing.Size(264, 381);
            this.grpBillingDeposits.TabIndex = 197;
            this.grpBillingDeposits.TabStop = false;
            this.grpBillingDeposits.Text = "Payments";
            // 
            // grdDeposits
            // 
            this.grdDeposits.AllowDelete = true;
            this.grdDeposits.AllowEditing = false;
            this.grdDeposits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDeposits.ColumnInfo = resources.GetString("grdDeposits.ColumnInfo");
            this.grdDeposits.ExtendLastCol = true;
            this.grdDeposits.Location = new System.Drawing.Point(3, 16);
            this.grdDeposits.Name = "grdDeposits";
            this.grdDeposits.Rows.Count = 1;
            this.grdDeposits.Rows.DefaultSize = 17;
            this.grdDeposits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdDeposits.Size = new System.Drawing.Size(258, 362);
            this.grdDeposits.StyleInfo = resources.GetString("grdDeposits.StyleInfo");
            this.grdDeposits.TabIndex = 210;
            // 
            // btnNewDeposit
            // 
            this.btnNewDeposit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnNewDeposit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDeposit.Location = new System.Drawing.Point(7, 169);
            this.btnNewDeposit.Name = "btnNewDeposit";
            this.btnNewDeposit.Size = new System.Drawing.Size(77, 28);
            this.btnNewDeposit.TabIndex = 156;
            this.btnNewDeposit.Text = "New Deposit";
            this.btnNewDeposit.Click += new System.EventHandler(this.btnNewDeposit_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.radioButton3);
            this.groupBox11.Location = new System.Drawing.Point(653, 40);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(0, 74);
            this.groupBox11.TabIndex = 193;
            this.groupBox11.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(484, 384);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 24);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.Text = "Manual";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.gridBilling);
            this.groupBox8.Controls.Add(this.cboBillRates);
            this.groupBox8.Location = new System.Drawing.Point(283, 157);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(253, 359);
            this.groupBox8.TabIndex = 198;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Billing Rates";
            // 
            // gridBilling
            // 
            this.gridBilling.AllowAddNew = true;
            this.gridBilling.AllowDelete = true;
            this.gridBilling.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.ColumnsUniform;
            this.gridBilling.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBilling.ColumnInfo = resources.GetString("gridBilling.ColumnInfo");
            this.gridBilling.ExtendLastCol = true;
            this.gridBilling.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.gridBilling.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.gridBilling.Location = new System.Drawing.Point(3, 16);
            this.gridBilling.Name = "gridBilling";
            this.gridBilling.Rows.Count = 1;
            this.gridBilling.Rows.DefaultSize = 17;
            this.gridBilling.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridBilling.Size = new System.Drawing.Size(247, 340);
            this.gridBilling.StyleInfo = resources.GetString("gridBilling.StyleInfo");
            this.gridBilling.TabIndex = 24;
            this.gridBilling.AfterAddRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridBilling_AfterAddRow);
            this.gridBilling.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridBilling_AfterAddRow);
            this.gridBilling.AfterDeleteRow += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridBilling_AfterAddRow);
            this.gridBilling.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridBilling_KeyUp);
            // 
            // cboBillRates
            // 
            this.cboBillRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillRates.FormattingEnabled = true;
            this.cboBillRates.Location = new System.Drawing.Point(11, 43);
            this.cboBillRates.Name = "cboBillRates";
            this.cboBillRates.Size = new System.Drawing.Size(121, 22);
            this.cboBillRates.TabIndex = 156;
            this.cboBillRates.SelectedValueChanged += new System.EventHandler(this.cboBillRates_SelectedValueChanged);
            // 
            // TabRecurringCharge
            // 
            this.TabRecurringCharge.Controls.Add(this.label135);
            this.TabRecurringCharge.Controls.Add(this.gridPackageRoom);
            this.TabRecurringCharge.Controls.Add(this.label67);
            this.TabRecurringCharge.Controls.Add(this.grdRecurringCharges);
            this.TabRecurringCharge.Controls.Add(this.btnRemoveRecurringCharge);
            this.TabRecurringCharge.Controls.Add(this.btnAddRecurringCharge);
            this.TabRecurringCharge.Controls.Add(this.btnSaveRecurringCharge);
            this.TabRecurringCharge.Controls.Add(this.groupBox9);
            this.TabRecurringCharge.Location = new System.Drawing.Point(4, 23);
            this.TabRecurringCharge.Name = "TabRecurringCharge";
            this.TabRecurringCharge.Size = new System.Drawing.Size(776, 288);
            this.TabRecurringCharge.TabIndex = 4;
            this.TabRecurringCharge.Text = "Hotel Package";
            this.TabRecurringCharge.UseVisualStyleBackColor = true;
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(4, 12);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(64, 14);
            this.label135.TabIndex = 183;
            this.label135.Text = "Schedules :";
            // 
            // gridPackageRoom
            // 
            this.gridPackageRoom.AllowEditing = false;
            this.gridPackageRoom.ColumnInfo = resources.GetString("gridPackageRoom.ColumnInfo");
            this.gridPackageRoom.ExtendLastCol = true;
            this.gridPackageRoom.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.gridPackageRoom.Location = new System.Drawing.Point(8, 29);
            this.gridPackageRoom.Name = "gridPackageRoom";
            this.gridPackageRoom.Rows.Count = 1;
            this.gridPackageRoom.Rows.DefaultSize = 17;
            this.gridPackageRoom.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridPackageRoom.Size = new System.Drawing.Size(286, 109);
            this.gridPackageRoom.StyleInfo = resources.GetString("gridPackageRoom.StyleInfo");
            this.gridPackageRoom.TabIndex = 182;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(5, 141);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(64, 14);
            this.label67.TabIndex = 180;
            this.label67.Text = "Particulars :";
            // 
            // grdRecurringCharges
            // 
            this.grdRecurringCharges.AllowEditing = false;
            this.grdRecurringCharges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRecurringCharges.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:64;Caption:\"Tran. Code\";Visible:False;DataType:Syste" +
                "m.String;TextAlign:LeftCenter;}\t1{Width:192;Caption:\"Particular\";DataType:System" +
                ".String;TextAlign:LeftCenter;}\t";
            this.grdRecurringCharges.ExtendLastCol = true;
            this.grdRecurringCharges.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdRecurringCharges.Location = new System.Drawing.Point(7, 158);
            this.grdRecurringCharges.Name = "grdRecurringCharges";
            this.grdRecurringCharges.Rows.Count = 1;
            this.grdRecurringCharges.Rows.DefaultSize = 17;
            this.grdRecurringCharges.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdRecurringCharges.Size = new System.Drawing.Size(287, 367);
            this.grdRecurringCharges.StyleInfo = resources.GetString("grdRecurringCharges.StyleInfo");
            this.grdRecurringCharges.TabIndex = 179;
            this.grdRecurringCharges.SelChange += new System.EventHandler(this.grdRecurringCharges_SelectedIndexChanged);
            // 
            // btnSaveRecurringCharge
            // 
            this.btnSaveRecurringCharge.Location = new System.Drawing.Point(238, 212);
            this.btnSaveRecurringCharge.Name = "btnSaveRecurringCharge";
            this.btnSaveRecurringCharge.Size = new System.Drawing.Size(48, 25);
            this.btnSaveRecurringCharge.TabIndex = 22;
            this.btnSaveRecurringCharge.Text = "Save";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.btnViewAttachments);
            this.groupBox9.Controls.Add(this.btnUploadAttachments);
            this.groupBox9.Controls.Add(this.label138);
            this.groupBox9.Controls.Add(this.dtpPostingDate);
            this.groupBox9.Controls.Add(this.btnPrintEstimatedCharges);
            this.groupBox9.Controls.Add(this.cboEventPackage);
            this.groupBox9.Controls.Add(this.label49);
            this.groupBox9.Controls.Add(this.label69);
            this.groupBox9.Controls.Add(this.txtPackageAmount);
            this.groupBox9.Controls.Add(this.grdRecurredCharge);
            this.groupBox9.Controls.Add(this.nmcQty);
            this.groupBox9.Controls.Add(this.cboDiscount);
            this.groupBox9.Controls.Add(this.cboRateTypes);
            this.groupBox9.Controls.Add(this.test);
            this.groupBox9.Controls.Add(this.nudTax);
            this.groupBox9.Location = new System.Drawing.Point(335, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(426, 509);
            this.groupBox9.TabIndex = 181;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Package Inclusions";
            // 
            // btnViewAttachments
            // 
            this.btnViewAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewAttachments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewAttachments.Location = new System.Drawing.Point(157, 479);
            this.btnViewAttachments.Name = "btnViewAttachments";
            this.btnViewAttachments.Size = new System.Drawing.Size(136, 25);
            this.btnViewAttachments.TabIndex = 190;
            this.btnViewAttachments.Text = "View Confidentials";
            this.btnViewAttachments.UseVisualStyleBackColor = true;
            this.btnViewAttachments.Click += new System.EventHandler(this.btnViewAttachments_Click);
            // 
            // btnUploadAttachments
            // 
            this.btnUploadAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUploadAttachments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUploadAttachments.Location = new System.Drawing.Point(12, 479);
            this.btnUploadAttachments.Name = "btnUploadAttachments";
            this.btnUploadAttachments.Size = new System.Drawing.Size(136, 25);
            this.btnUploadAttachments.TabIndex = 189;
            this.btnUploadAttachments.Text = "Upload Confidentials";
            this.btnUploadAttachments.UseVisualStyleBackColor = true;
            this.btnUploadAttachments.Click += new System.EventHandler(this.btnUploadAttachments_Click);
            // 
            // label138
            // 
            this.label138.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(206, 57);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(67, 14);
            this.label138.TabIndex = 188;
            this.label138.Text = "Posting Date";
            // 
            // dtpPostingDate
            // 
            this.dtpPostingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPostingDate.CustomFormat = "MMM dd, yyyy";
            this.dtpPostingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPostingDate.Location = new System.Drawing.Point(279, 54);
            this.dtpPostingDate.Name = "dtpPostingDate";
            this.dtpPostingDate.Size = new System.Drawing.Size(98, 20);
            this.dtpPostingDate.TabIndex = 187;
            // 
            // btnPrintEstimatedCharges
            // 
            this.btnPrintEstimatedCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintEstimatedCharges.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.Print_16x16;
            this.btnPrintEstimatedCharges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintEstimatedCharges.Location = new System.Drawing.Point(279, 24);
            this.btnPrintEstimatedCharges.Name = "btnPrintEstimatedCharges";
            this.btnPrintEstimatedCharges.Size = new System.Drawing.Size(98, 25);
            this.btnPrintEstimatedCharges.TabIndex = 181;
            this.btnPrintEstimatedCharges.Text = "Print Charges";
            this.btnPrintEstimatedCharges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintEstimatedCharges.UseVisualStyleBackColor = true;
            this.btnPrintEstimatedCharges.Click += new System.EventHandler(this.btnPrintEstimatedCharges_Click);
            // 
            // cboEventPackage
            // 
            this.cboEventPackage.Location = new System.Drawing.Point(100, 27);
            this.cboEventPackage.Name = "cboEventPackage";
            this.cboEventPackage.ReadOnly = true;
            this.cboEventPackage.Size = new System.Drawing.Size(181, 20);
            this.cboEventPackage.TabIndex = 180;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(13, 29);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(84, 18);
            this.label49.TabIndex = 176;
            this.label49.Text = "Package Name";
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(13, 57);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(83, 14);
            this.label69.TabIndex = 178;
            this.label69.Text = "Amount";
            // 
            // txtPackageAmount
            // 
            this.txtPackageAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPackageAmount.Location = new System.Drawing.Point(100, 54);
            this.txtPackageAmount.Name = "txtPackageAmount";
            this.txtPackageAmount.ReadOnly = true;
            this.txtPackageAmount.Size = new System.Drawing.Size(101, 20);
            this.txtPackageAmount.TabIndex = 177;
            this.txtPackageAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackageAmount.TextChanged += new System.EventHandler(this.txtPackageAmount_TextChanged);
            // 
            // grdRecurredCharge
            // 
            this.grdRecurredCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRecurredCharge.ColumnInfo = resources.GetString("grdRecurredCharge.ColumnInfo");
            this.grdRecurredCharge.ExtendLastCol = true;
            this.grdRecurredCharge.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdRecurredCharge.Location = new System.Drawing.Point(12, 80);
            this.grdRecurredCharge.Name = "grdRecurredCharge";
            this.grdRecurredCharge.Rows.Count = 1;
            this.grdRecurredCharge.Rows.DefaultSize = 17;
            this.grdRecurredCharge.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grdRecurredCharge.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdRecurredCharge.Size = new System.Drawing.Size(410, 393);
            this.grdRecurredCharge.StyleInfo = resources.GetString("grdRecurredCharge.StyleInfo");
            this.grdRecurredCharge.TabIndex = 180;
            this.grdRecurredCharge.EnterCell += new System.EventHandler(this.grdRecurredCharge_EnterCell);
            this.grdRecurredCharge.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdRecurredCharge_AfterEdit);
            this.grdRecurredCharge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwRecurredCharge_MouseUp);
            this.grdRecurredCharge.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdRecurredCharge_BeforeEdit);
            // 
            // nmcQty
            // 
            this.nmcQty.Location = new System.Drawing.Point(175, 115);
            this.nmcQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmcQty.Name = "nmcQty";
            this.nmcQty.Size = new System.Drawing.Size(37, 20);
            this.nmcQty.TabIndex = 183;
            // 
            // cboDiscount
            // 
            this.cboDiscount.FormattingEnabled = true;
            this.cboDiscount.Location = new System.Drawing.Point(237, 115);
            this.cboDiscount.Name = "cboDiscount";
            this.cboDiscount.Size = new System.Drawing.Size(44, 22);
            this.cboDiscount.TabIndex = 182;
            // 
            // cboRateTypes
            // 
            this.cboRateTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRateTypes.FormattingEnabled = true;
            this.cboRateTypes.Location = new System.Drawing.Point(310, 125);
            this.cboRateTypes.Name = "cboRateTypes";
            this.cboRateTypes.Size = new System.Drawing.Size(80, 22);
            this.cboRateTypes.TabIndex = 184;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(198, 135);
            this.test.Name = "test";
            this.test.ReadOnly = true;
            this.test.Size = new System.Drawing.Size(100, 20);
            this.test.TabIndex = 185;
            // 
            // nudTax
            // 
            this.nudTax.Location = new System.Drawing.Point(254, 175);
            this.nudTax.Name = "nudTax";
            this.nudTax.Size = new System.Drawing.Size(44, 20);
            this.nudTax.TabIndex = 186;
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(18, 12);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(46, 14);
            this.label116.TabIndex = 183;
            this.label116.Text = "Rooms :";
            // 
            // lbltest
            // 
            this.lbltest.AutoSize = true;
            this.lbltest.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltest.Location = new System.Drawing.Point(21, 39);
            this.lbltest.Name = "lbltest";
            this.lbltest.Size = new System.Drawing.Size(143, 14);
            this.lbltest.TabIndex = 193;
            this.lbltest.Text = "Show Amount in report?";
            // 
            // tabPackage
            // 
            this.tabPackage.Controls.Add(this.dtpPackageDateTo);
            this.tabPackage.Controls.Add(this.label75);
            this.tabPackage.Controls.Add(this.dtpPackageDateFrom);
            this.tabPackage.Controls.Add(this.label85);
            this.tabPackage.Controls.Add(this.label64);
            this.tabPackage.Controls.Add(this.grdFolioPackage);
            this.tabPackage.Controls.Add(this.label13);
            this.tabPackage.Controls.Add(this.grdHotelPromos);
            this.tabPackage.Controls.Add(this.btnAddHotelPromo);
            this.tabPackage.Controls.Add(this.btnRemoveHotelPromo);
            this.tabPackage.Controls.Add(this.label22);
            this.tabPackage.Controls.Add(this.txtFolioPackageDaysApplied);
            this.tabPackage.Controls.Add(this.label2);
            this.tabPackage.Controls.Add(this.label8);
            this.tabPackage.Location = new System.Drawing.Point(4, 23);
            this.tabPackage.Name = "tabPackage";
            this.tabPackage.Size = new System.Drawing.Size(776, 288);
            this.tabPackage.TabIndex = 3;
            this.tabPackage.Text = "Hotel Promo";
            this.tabPackage.UseVisualStyleBackColor = true;
            // 
            // dtpPackageDateTo
            // 
            this.dtpPackageDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpPackageDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPackageDateTo.Location = new System.Drawing.Point(691, 61);
            this.dtpPackageDateTo.Name = "dtpPackageDateTo";
            this.dtpPackageDateTo.Size = new System.Drawing.Size(103, 20);
            this.dtpPackageDateTo.TabIndex = 155;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.SystemColors.Control;
            this.label75.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label75.Location = new System.Drawing.Point(640, 64);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(53, 15);
            this.label75.TabIndex = 154;
            this.label75.Text = "Date To :";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPackageDateFrom
            // 
            this.dtpPackageDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpPackageDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPackageDateFrom.Location = new System.Drawing.Point(519, 61);
            this.dtpPackageDateFrom.Name = "dtpPackageDateFrom";
            this.dtpPackageDateFrom.Size = new System.Drawing.Size(102, 20);
            this.dtpPackageDateFrom.TabIndex = 153;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.SystemColors.Control;
            this.label85.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label85.Location = new System.Drawing.Point(456, 64);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(68, 15);
            this.label85.TabIndex = 152;
            this.label85.Text = "Date From :";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label64
            // 
            this.label64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label64.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label64.Location = new System.Drawing.Point(503, 459);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(247, 57);
            this.label64.TabIndex = 148;
            this.label64.Text = "Hotel Promos are special discounts.";
            // 
            // grdFolioPackage
            // 
            this.grdFolioPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFolioPackage.ColumnInfo = resources.GetString("grdFolioPackage.ColumnInfo");
            this.grdFolioPackage.Location = new System.Drawing.Point(459, 87);
            this.grdFolioPackage.Name = "grdFolioPackage";
            this.grdFolioPackage.Rows.Count = 1;
            this.grdFolioPackage.Rows.DefaultSize = 17;
            this.grdFolioPackage.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdFolioPackage.Size = new System.Drawing.Size(291, 354);
            this.grdFolioPackage.StyleInfo = resources.GetString("grdFolioPackage.StyleInfo");
            this.grdFolioPackage.TabIndex = 147;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(456, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 18);
            this.label13.TabIndex = 146;
            this.label13.Text = "Applied Promo Discounts :";
            // 
            // grdHotelPromos
            // 
            this.grdHotelPromos.AllowEditing = false;
            this.grdHotelPromos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdHotelPromos.ColumnInfo = resources.GetString("grdHotelPromos.ColumnInfo");
            this.grdHotelPromos.ExtendLastCol = true;
            this.grdHotelPromos.Location = new System.Drawing.Point(15, 57);
            this.grdHotelPromos.Name = "grdHotelPromos";
            this.grdHotelPromos.Rows.DefaultSize = 17;
            this.grdHotelPromos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdHotelPromos.Size = new System.Drawing.Size(322, 448);
            this.grdHotelPromos.StyleInfo = resources.GetString("grdHotelPromos.StyleInfo");
            this.grdHotelPromos.TabIndex = 145;
            // 
            // btnAddHotelPromo
            // 
            this.btnAddHotelPromo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAddHotelPromo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddHotelPromo.Location = new System.Drawing.Point(388, 117);
            this.btnAddHotelPromo.Name = "btnAddHotelPromo";
            this.btnAddHotelPromo.Size = new System.Drawing.Size(29, 25);
            this.btnAddHotelPromo.TabIndex = 142;
            this.btnAddHotelPromo.Text = ">";
            this.btnAddHotelPromo.Click += new System.EventHandler(this.btnAddHotelPromo_Click);
            // 
            // btnRemoveHotelPromo
            // 
            this.btnRemoveHotelPromo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveHotelPromo.Location = new System.Drawing.Point(388, 154);
            this.btnRemoveHotelPromo.Name = "btnRemoveHotelPromo";
            this.btnRemoveHotelPromo.Size = new System.Drawing.Size(29, 25);
            this.btnRemoveHotelPromo.TabIndex = 143;
            this.btnRemoveHotelPromo.Text = "<";
            this.btnRemoveHotelPromo.Click += new System.EventHandler(this.btnRemoveHotelPromo_Click);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(15, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(140, 18);
            this.label22.TabIndex = 144;
            this.label22.Text = "Active Hotel Promos :";
            // 
            // txtFolioPackageDaysApplied
            // 
            this.txtFolioPackageDaysApplied.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtFolioPackageDaysApplied.Location = new System.Drawing.Point(489, 114);
            this.txtFolioPackageDaysApplied.MaxLength = 20;
            this.txtFolioPackageDaysApplied.Name = "txtFolioPackageDaysApplied";
            this.txtFolioPackageDaysApplied.ReadOnly = true;
            this.txtFolioPackageDaysApplied.Size = new System.Drawing.Size(240, 20);
            this.txtFolioPackageDaysApplied.TabIndex = 150;
            this.txtFolioPackageDaysApplied.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label2.Location = new System.Drawing.Point(419, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 151;
            this.label2.Text = "Days applied :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label8.Location = new System.Drawing.Point(470, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 30);
            this.label8.TabIndex = 149;
            // 
            // tabPrivilege
            // 
            this.tabPrivilege.Controls.Add(this.label76);
            this.tabPrivilege.Controls.Add(this.label77);
            this.tabPrivilege.Controls.Add(this.label78);
            this.tabPrivilege.Controls.Add(this.grdFolioPrivileges);
            this.tabPrivilege.Controls.Add(this.btnGuestPrivileges_Remove);
            this.tabPrivilege.Controls.Add(this.btnGuestPrivilege_Add);
            this.tabPrivilege.Controls.Add(this.chkApply);
            this.tabPrivilege.Controls.Add(this.gbxApplyPrivileges);
            this.tabPrivilege.Location = new System.Drawing.Point(4, 23);
            this.tabPrivilege.Name = "tabPrivilege";
            this.tabPrivilege.Size = new System.Drawing.Size(776, 288);
            this.tabPrivilege.TabIndex = 2;
            this.tabPrivilege.Text = "Privileges";
            this.tabPrivilege.UseVisualStyleBackColor = true;
            // 
            // label76
            // 
            this.label76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label76.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label76.Image = ((System.Drawing.Image)(resources.GetObject("label76.Image")));
            this.label76.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label76.Location = new System.Drawing.Point(462, 469);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(29, 30);
            this.label76.TabIndex = 147;
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label77.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label77.Location = new System.Drawing.Point(495, 469);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(259, 49);
            this.label77.TabIndex = 146;
            this.label77.Text = "Folio Privileges are discounts (Percentage or Amount) given to Guest/Company. Dis" +
                "counts will be applied upon posting transactions.";
            // 
            // label78
            // 
            this.label78.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label78.BackColor = System.Drawing.SystemColors.Control;
            this.label78.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.Black;
            this.label78.Location = new System.Drawing.Point(335, 66);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(105, 16);
            this.label78.TabIndex = 145;
            this.label78.Text = "Folio Privileges :";
            // 
            // grdFolioPrivileges
            // 
            this.grdFolioPrivileges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFolioPrivileges.ColumnInfo = resources.GetString("grdFolioPrivileges.ColumnInfo");
            this.grdFolioPrivileges.ExtendLastCol = true;
            this.grdFolioPrivileges.Location = new System.Drawing.Point(338, 97);
            this.grdFolioPrivileges.Name = "grdFolioPrivileges";
            this.grdFolioPrivileges.Rows.Count = 1;
            this.grdFolioPrivileges.Rows.DefaultSize = 17;
            this.grdFolioPrivileges.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdFolioPrivileges.Size = new System.Drawing.Size(415, 353);
            this.grdFolioPrivileges.StyleInfo = resources.GetString("grdFolioPrivileges.StyleInfo");
            this.grdFolioPrivileges.TabIndex = 144;
            this.grdFolioPrivileges.KeyPressEdit += new C1.Win.C1FlexGrid.KeyPressEditEventHandler(this.grdFolioPrivileges_KeyPressEdit);
            this.grdFolioPrivileges.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdFolioPrivileges_AfterEdit);
            this.grdFolioPrivileges.RowColChange += new System.EventHandler(this.grdFolioPrivileges_RowColChange);
            // 
            // btnGuestPrivileges_Remove
            // 
            this.btnGuestPrivileges_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuestPrivileges_Remove.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuestPrivileges_Remove.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnGuestPrivileges_Remove.Location = new System.Drawing.Point(687, 57);
            this.btnGuestPrivileges_Remove.Name = "btnGuestPrivileges_Remove";
            this.btnGuestPrivileges_Remove.Size = new System.Drawing.Size(66, 31);
            this.btnGuestPrivileges_Remove.TabIndex = 143;
            this.btnGuestPrivileges_Remove.Text = "Remove";
            this.btnGuestPrivileges_Remove.Click += new System.EventHandler(this.btnGuestPrivileges_Remove_Click);
            // 
            // btnGuestPrivilege_Add
            // 
            this.btnGuestPrivilege_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuestPrivilege_Add.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuestPrivilege_Add.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnGuestPrivilege_Add.Location = new System.Drawing.Point(615, 57);
            this.btnGuestPrivilege_Add.Name = "btnGuestPrivilege_Add";
            this.btnGuestPrivilege_Add.Size = new System.Drawing.Size(66, 31);
            this.btnGuestPrivilege_Add.TabIndex = 142;
            this.btnGuestPrivilege_Add.Text = "&Add";
            this.btnGuestPrivilege_Add.Click += new System.EventHandler(this.btnGuestPrivilege_Add_Click);
            // 
            // chkApply
            // 
            this.chkApply.Checked = true;
            this.chkApply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApply.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApply.Location = new System.Drawing.Point(31, 61);
            this.chkApply.Name = "chkApply";
            this.chkApply.Size = new System.Drawing.Size(113, 22);
            this.chkApply.TabIndex = 141;
            this.chkApply.Text = " Apply Privilege";
            this.chkApply.CheckedChanged += new System.EventHandler(this.chkApply_CheckedChanged);
            // 
            // gbxApplyPrivileges
            // 
            this.gbxApplyPrivileges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxApplyPrivileges.Controls.Add(this.lvwCompanyPrivileges);
            this.gbxApplyPrivileges.Controls.Add(this.lvwGuestPrivileges);
            this.gbxApplyPrivileges.Controls.Add(this.rdoApplyCompanyPrivileges);
            this.gbxApplyPrivileges.Controls.Add(this.rdoApplyGuestPrivilege);
            this.gbxApplyPrivileges.Location = new System.Drawing.Point(18, 66);
            this.gbxApplyPrivileges.Name = "gbxApplyPrivileges";
            this.gbxApplyPrivileges.Size = new System.Drawing.Size(298, 452);
            this.gbxApplyPrivileges.TabIndex = 140;
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
            this.rdoApplyCompanyPrivileges.Text = "Company Privilege(s)";
            this.rdoApplyCompanyPrivileges.UseVisualStyleBackColor = true;
            this.rdoApplyCompanyPrivileges.CheckedChanged += new System.EventHandler(this.rdoApplyCompanyPrivileges_CheckedChanged);
            // 
            // rdoApplyGuestPrivilege
            // 
            this.rdoApplyGuestPrivilege.AutoSize = true;
            this.rdoApplyGuestPrivilege.Enabled = false;
            this.rdoApplyGuestPrivilege.Location = new System.Drawing.Point(29, 39);
            this.rdoApplyGuestPrivilege.Name = "rdoApplyGuestPrivilege";
            this.rdoApplyGuestPrivilege.Size = new System.Drawing.Size(111, 18);
            this.rdoApplyGuestPrivilege.TabIndex = 53;
            this.rdoApplyGuestPrivilege.Text = "Guest Privilege(s)";
            this.rdoApplyGuestPrivilege.UseVisualStyleBackColor = true;
            this.rdoApplyGuestPrivilege.CheckedChanged += new System.EventHandler(this.rdoApplyGuestPrivilege_CheckedChanged);
            // 
            // tabBooking
            // 
            this.tabBooking.Controls.Add(this.GroupBox1);
            this.tabBooking.Controls.Add(this.Label7);
            this.tabBooking.Controls.Add(this.nudNoofDays);
            this.tabBooking.Controls.Add(this.Label5);
            this.tabBooking.Controls.Add(this.txtPromo);
            this.tabBooking.Controls.Add(this.Label9);
            this.tabBooking.Controls.Add(this.Label6);
            this.tabBooking.Location = new System.Drawing.Point(4, 23);
            this.tabBooking.Name = "tabBooking";
            this.tabBooking.Size = new System.Drawing.Size(776, 288);
            this.tabBooking.TabIndex = 0;
            this.tabBooking.Text = "Folios";
            this.tabBooking.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.txtGrpTotal);
            this.GroupBox1.Controls.Add(this.label88);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.lblOverStay);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Controls.Add(this.lblNoShow);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.lblCheckout);
            this.GroupBox1.Controls.Add(this.lblCheckIn);
            this.GroupBox1.Controls.Add(this.Label19);
            this.GroupBox1.Controls.Add(this.txtSearch);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label20);
            this.GroupBox1.Controls.Add(this.txtBalance);
            this.GroupBox1.Controls.Add(this.txtAmount);
            this.GroupBox1.Controls.Add(this.chkBreakFst);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.Label18);
            this.GroupBox1.Controls.Add(this.grdFolio);
            this.GroupBox1.Location = new System.Drawing.Point(0, -1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(769, 280);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBox1_MouseMove);
            // 
            // txtGrpTotal
            // 
            this.txtGrpTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrpTotal.Enabled = false;
            this.txtGrpTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrpTotal.ForeColor = System.Drawing.Color.Black;
            this.txtGrpTotal.Location = new System.Drawing.Point(494, 246);
            this.txtGrpTotal.Name = "txtGrpTotal";
            this.txtGrpTotal.ReadOnly = true;
            this.txtGrpTotal.Size = new System.Drawing.Size(89, 20);
            this.txtGrpTotal.TabIndex = 307;
            this.txtGrpTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label88
            // 
            this.label88.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(400, 249);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(87, 14);
            this.label88.TabIndex = 306;
            this.label88.Text = "Group Folio Total";
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(499, 43);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(61, 14);
            this.Label10.TabIndex = 138;
            this.Label10.Text = "Overstay";
            // 
            // lblOverStay
            // 
            this.lblOverStay.BackColor = System.Drawing.Color.Red;
            this.lblOverStay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOverStay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverStay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblOverStay.Location = new System.Drawing.Point(462, 41);
            this.lblOverStay.Name = "lblOverStay";
            this.lblOverStay.Size = new System.Drawing.Size(31, 18);
            this.lblOverStay.TabIndex = 137;
            this.lblOverStay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(371, 43);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(95, 14);
            this.Label12.TabIndex = 136;
            this.Label12.Text = "For \'No Show\'";
            // 
            // lblNoShow
            // 
            this.lblNoShow.BackColor = System.Drawing.Color.Gainsboro;
            this.lblNoShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNoShow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoShow.Location = new System.Drawing.Point(331, 41);
            this.lblNoShow.Name = "lblNoShow";
            this.lblNoShow.Size = new System.Drawing.Size(32, 18);
            this.lblNoShow.TabIndex = 133;
            this.lblNoShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(206, 43);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(115, 14);
            this.Label14.TabIndex = 135;
            this.Label14.Text = "Expected Check-out";
            // 
            // lblCheckout
            // 
            this.lblCheckout.BackColor = System.Drawing.Color.PaleGreen;
            this.lblCheckout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCheckout.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckout.Location = new System.Drawing.Point(172, 41);
            this.lblCheckout.Name = "lblCheckout";
            this.lblCheckout.Size = new System.Drawing.Size(29, 18);
            this.lblCheckout.TabIndex = 132;
            this.lblCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblCheckIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCheckIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.Location = new System.Drawing.Point(12, 41);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(32, 18);
            this.lblCheckIn.TabIndex = 131;
            this.lblCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label19
            // 
            this.Label19.Location = new System.Drawing.Point(53, 43);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(103, 14);
            this.Label19.TabIndex = 134;
            this.Label19.Text = "Expected Check-in";
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(8, 12);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(119, 15);
            this.Label11.TabIndex = 130;
            this.Label11.Text = "Enter search string";
            // 
            // Label20
            // 
            this.Label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label20.Location = new System.Drawing.Point(6, 36);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(746, 27);
            this.Label20.TabIndex = 139;
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.ForeColor = System.Drawing.Color.Black;
            this.txtBalance.Location = new System.Drawing.Point(665, 246);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(89, 20);
            this.txtBalance.TabIndex = 305;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Location = new System.Drawing.Point(303, 246);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(89, 20);
            this.txtAmount.TabIndex = 304;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkBreakFst
            // 
            this.chkBreakFst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBreakFst.BackColor = System.Drawing.Color.Transparent;
            this.chkBreakFst.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBreakFst.Location = new System.Drawing.Point(4, 248);
            this.chkBreakFst.Name = "chkBreakFst";
            this.chkBreakFst.Size = new System.Drawing.Size(87, 17);
            this.chkBreakFst.TabIndex = 303;
            this.chkBreakFst.Text = "Breakfast";
            this.chkBreakFst.UseVisualStyleBackColor = false;
            this.chkBreakFst.Visible = false;
            // 
            // Label17
            // 
            this.Label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(216, 249);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(80, 14);
            this.Label17.TabIndex = 140;
            this.Label17.Text = "Child Folio Total";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label18
            // 
            this.Label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(588, 249);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(71, 14);
            this.Label18.TabIndex = 141;
            this.Label18.Text = "Total Balance";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(199, 16);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(37, 14);
            this.Label7.TabIndex = 108;
            this.Label7.Text = "Days";
            this.Label7.Visible = false;
            // 
            // nudNoofDays
            // 
            this.nudNoofDays.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNoofDays.Location = new System.Drawing.Point(197, 30);
            this.nudNoofDays.Name = "nudNoofDays";
            this.nudNoofDays.Size = new System.Drawing.Size(38, 20);
            this.nudNoofDays.TabIndex = 107;
            this.nudNoofDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNoofDays.Visible = false;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(105, 15);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(120, 14);
            this.Label5.TabIndex = 94;
            this.Label5.Text = "Departure";
            this.Label5.Visible = false;
            // 
            // txtPromo
            // 
            this.txtPromo.Location = new System.Drawing.Point(415, 31);
            this.txtPromo.Name = "txtPromo";
            this.txtPromo.Size = new System.Drawing.Size(240, 20);
            this.txtPromo.TabIndex = 103;
            this.txtPromo.Text = "0";
            this.txtPromo.Visible = false;
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(376, 32);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(42, 14);
            this.Label9.TabIndex = 104;
            this.Label9.Text = "Promo";
            this.Label9.Visible = false;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(6, 15);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(120, 14);
            this.Label6.TabIndex = 92;
            this.Label6.Text = "Arrival";
            this.Label6.Visible = false;
            // 
            // tabFolio_
            // 
            this.tabFolio_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFolio_.Controls.Add(this.tabBooking);
            this.tabFolio_.Controls.Add(this.tabBillingInfo);
            this.tabFolio_.Controls.Add(this.tabPrivilege);
            this.tabFolio_.Controls.Add(this.tabPackage);
            this.tabFolio_.Controls.Add(this.TabRecurringCharge);
            this.tabFolio_.Controls.Add(this.tabEventDetails_);
            this.tabFolio_.Controls.Add(this.tabWedding_);
            this.tabFolio_.Controls.Add(this.tabFoodBev_);
            this.tabFolio_.Controls.Add(this.tabRooms_);
            this.tabFolio_.Controls.Add(this.tabRoomRequirements);
            this.tabFolio_.Controls.Add(this.tabAmmendments);
            this.tabFolio_.Controls.Add(this.tabEventRequirements);
            this.tabFolio_.Controls.Add(this.tabEndorsement);
            this.tabFolio_.Controls.Add(this.tabCancellation);
            this.tabFolio_.Controls.Add(this.tabEventAttendance);
            this.tabFolio_.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFolio_.HotTrack = true;
            this.tabFolio_.Location = new System.Drawing.Point(10, 218);
            this.tabFolio_.Name = "tabFolio_";
            this.tabFolio_.SelectedIndex = 0;
            this.tabFolio_.ShowToolTips = true;
            this.tabFolio_.Size = new System.Drawing.Size(784, 315);
            this.tabFolio_.TabIndex = 1;
            this.tabFolio_.SelectedIndexChanged += new System.EventHandler(this.tabFolio__SelectedIndexChanged);
            // 
            // tabBillingInfo
            // 
            this.tabBillingInfo.Controls.Add(this.txtBIMemo);
            this.tabBillingInfo.Controls.Add(this.txtBICode);
            this.tabBillingInfo.Controls.Add(this.label50);
            this.tabBillingInfo.Controls.Add(this.label62);
            this.tabBillingInfo.Controls.Add(this.gridBillingInfo);
            this.tabBillingInfo.Controls.Add(this.btnRemoveCharge);
            this.tabBillingInfo.Controls.Add(this.btnSaveRouting);
            this.tabBillingInfo.Controls.Add(this.label51);
            this.tabBillingInfo.Controls.Add(this.rdoAmount);
            this.tabBillingInfo.Controls.Add(this.rdoPercent);
            this.tabBillingInfo.Controls.Add(this.gridTransactionCodes);
            this.tabBillingInfo.Controls.Add(this.label52);
            this.tabBillingInfo.Location = new System.Drawing.Point(4, 23);
            this.tabBillingInfo.Name = "tabBillingInfo";
            this.tabBillingInfo.Size = new System.Drawing.Size(776, 288);
            this.tabBillingInfo.TabIndex = 11;
            this.tabBillingInfo.Text = "Billing Info";
            this.tabBillingInfo.UseVisualStyleBackColor = true;
            // 
            // txtBIMemo
            // 
            this.txtBIMemo.BackColor = System.Drawing.SystemColors.Control;
            this.txtBIMemo.Location = new System.Drawing.Point(447, 123);
            this.txtBIMemo.Name = "txtBIMemo";
            this.txtBIMemo.ReadOnly = true;
            this.txtBIMemo.Size = new System.Drawing.Size(215, 20);
            this.txtBIMemo.TabIndex = 407;
            // 
            // txtBICode
            // 
            this.txtBICode.BackColor = System.Drawing.SystemColors.Control;
            this.txtBICode.Location = new System.Drawing.Point(447, 97);
            this.txtBICode.Name = "txtBICode";
            this.txtBICode.ReadOnly = true;
            this.txtBICode.Size = new System.Drawing.Size(82, 20);
            this.txtBICode.TabIndex = 406;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.SystemColors.Control;
            this.label50.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label50.Location = new System.Drawing.Point(401, 127);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(49, 16);
            this.label50.TabIndex = 409;
            this.label50.Text = "Memo :";
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.SystemColors.Control;
            this.label62.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label62.Location = new System.Drawing.Point(401, 100);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(38, 16);
            this.label62.TabIndex = 408;
            this.label62.Text = "Code :";
            // 
            // gridBillingInfo
            // 
            this.gridBillingInfo.ColumnInfo = resources.GetString("gridBillingInfo.ColumnInfo");
            this.gridBillingInfo.ExtendLastCol = true;
            this.gridBillingInfo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.gridBillingInfo.Location = new System.Drawing.Point(406, 193);
            this.gridBillingInfo.Name = "gridBillingInfo";
            this.gridBillingInfo.Rows.Count = 1;
            this.gridBillingInfo.Rows.DefaultSize = 17;
            this.gridBillingInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridBillingInfo.Size = new System.Drawing.Size(367, 128);
            this.gridBillingInfo.StyleInfo = resources.GetString("gridBillingInfo.StyleInfo");
            this.gridBillingInfo.TabIndex = 404;
            this.gridBillingInfo.Click += new System.EventHandler(this.gridBillingInfo_Click);
            this.gridBillingInfo.RowColChange += new System.EventHandler(this.gridBillingInfo_RowColChange);
            // 
            // btnRemoveCharge
            // 
            this.btnRemoveCharge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCharge.Location = new System.Drawing.Point(717, 48);
            this.btnRemoveCharge.Name = "btnRemoveCharge";
            this.btnRemoveCharge.Size = new System.Drawing.Size(66, 31);
            this.btnRemoveCharge.TabIndex = 91;
            this.btnRemoveCharge.Text = "&Remove";
            this.btnRemoveCharge.Click += new System.EventHandler(this.btnRemoveCharge_Click);
            // 
            // btnSaveRouting
            // 
            this.btnSaveRouting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRouting.Location = new System.Drawing.Point(645, 48);
            this.btnSaveRouting.Name = "btnSaveRouting";
            this.btnSaveRouting.Size = new System.Drawing.Size(66, 31);
            this.btnSaveRouting.TabIndex = 405;
            this.btnSaveRouting.Text = "&Add";
            this.btnSaveRouting.Click += new System.EventHandler(this.btnSaveRouting_Click);
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(24, 27);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(108, 15);
            this.label51.TabIndex = 96;
            this.label51.Text = "Charges :";
            // 
            // rdoAmount
            // 
            this.rdoAmount.BackColor = System.Drawing.SystemColors.Control;
            this.rdoAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAmount.Location = new System.Drawing.Point(688, 165);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(87, 18);
            this.rdoAmount.TabIndex = 402;
            this.rdoAmount.Text = "Amount (A)";
            this.rdoAmount.UseVisualStyleBackColor = false;
            this.rdoAmount.CheckedChanged += new System.EventHandler(this.rdoAmount_CheckedChanged);
            // 
            // rdoPercent
            // 
            this.rdoPercent.BackColor = System.Drawing.SystemColors.Control;
            this.rdoPercent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPercent.Location = new System.Drawing.Point(598, 165);
            this.rdoPercent.Name = "rdoPercent";
            this.rdoPercent.Size = new System.Drawing.Size(87, 18);
            this.rdoPercent.TabIndex = 401;
            this.rdoPercent.Text = "Percent (P)";
            this.rdoPercent.UseVisualStyleBackColor = false;
            this.rdoPercent.CheckedChanged += new System.EventHandler(this.rdoPercent_CheckedChanged);
            // 
            // gridTransactionCodes
            // 
            this.gridTransactionCodes.AllowEditing = false;
            this.gridTransactionCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridTransactionCodes.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:51;Caption:\"Code\";TextAlignFixed:CenterCenter;}\t1{Wi" +
                "dth:104;Caption:\"Memo\";TextAlign:LeftCenter;TextAlignFixed:CenterCenter;}\t";
            this.gridTransactionCodes.ExtendLastCol = true;
            this.gridTransactionCodes.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.gridTransactionCodes.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus;
            this.gridTransactionCodes.Location = new System.Drawing.Point(20, 52);
            this.gridTransactionCodes.Name = "gridTransactionCodes";
            this.gridTransactionCodes.Rows.Count = 10;
            this.gridTransactionCodes.Rows.DefaultSize = 17;
            this.gridTransactionCodes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridTransactionCodes.Size = new System.Drawing.Size(307, 472);
            this.gridTransactionCodes.StyleInfo = resources.GetString("gridTransactionCodes.StyleInfo");
            this.gridTransactionCodes.TabIndex = 403;
            this.gridTransactionCodes.Click += new System.EventHandler(this.gridTransactionCodes_Click);
            this.gridTransactionCodes.SelChange += new System.EventHandler(this.gridTransactionCodes_Click);
            this.gridTransactionCodes.RowColChange += new System.EventHandler(this.gridTransactionCodes_Click);
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.SystemColors.Control;
            this.label52.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(548, 165);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(87, 18);
            this.label52.TabIndex = 88;
            this.label52.Text = "Basis :";
            // 
            // tabRoomRequirements
            // 
            this.tabRoomRequirements.Controls.Add(this.grpDependentsRoom);
            this.tabRoomRequirements.Controls.Add(this.groupBox7);
            this.tabRoomRequirements.Location = new System.Drawing.Point(4, 23);
            this.tabRoomRequirements.Name = "tabRoomRequirements";
            this.tabRoomRequirements.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoomRequirements.Size = new System.Drawing.Size(776, 288);
            this.tabRoomRequirements.TabIndex = 12;
            this.tabRoomRequirements.Text = "Room Rqmts.";
            this.tabRoomRequirements.UseVisualStyleBackColor = true;
            // 
            // tabAmmendments
            // 
            this.tabAmmendments.Controls.Add(this.groupBox6);
            this.tabAmmendments.Controls.Add(this.grpNewAmendments);
            this.tabAmmendments.Controls.Add(this.pnlAmendments);
            this.tabAmmendments.Controls.Add(this.groupBox3);
            this.tabAmmendments.Location = new System.Drawing.Point(4, 23);
            this.tabAmmendments.Name = "tabAmmendments";
            this.tabAmmendments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAmmendments.Size = new System.Drawing.Size(776, 288);
            this.tabAmmendments.TabIndex = 13;
            this.tabAmmendments.Text = "Amendments";
            this.tabAmmendments.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.grdSystemChanges);
            this.groupBox6.Location = new System.Drawing.Point(6, 130);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(764, 245);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Reservation Changes";
            // 
            // grdSystemChanges
            // 
            this.grdSystemChanges.AllowEditing = false;
            this.grdSystemChanges.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            this.grdSystemChanges.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdSystemChanges.ColumnInfo = resources.GetString("grdSystemChanges.ColumnInfo");
            this.grdSystemChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSystemChanges.ExtendLastCol = true;
            this.grdSystemChanges.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdSystemChanges.Location = new System.Drawing.Point(3, 16);
            this.grdSystemChanges.Name = "grdSystemChanges";
            this.grdSystemChanges.Rows.Count = 1;
            this.grdSystemChanges.Rows.DefaultSize = 17;
            this.grdSystemChanges.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdSystemChanges.Size = new System.Drawing.Size(758, 226);
            this.grdSystemChanges.StyleInfo = resources.GetString("grdSystemChanges.StyleInfo");
            this.grdSystemChanges.TabIndex = 0;
            // 
            // grpNewAmendments
            // 
            this.grpNewAmendments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNewAmendments.Controls.Add(this.btnAmendmentArrow);
            this.grpNewAmendments.Controls.Add(this.gridAmendmentSchedules);
            this.grpNewAmendments.Controls.Add(this.label90);
            this.grpNewAmendments.Controls.Add(this.txtAmendmentNo);
            this.grpNewAmendments.Controls.Add(this.label86);
            this.grpNewAmendments.Controls.Add(this.txtNewValue);
            this.grpNewAmendments.Controls.Add(this.txtOldValue);
            this.grpNewAmendments.Controls.Add(this.label89);
            this.grpNewAmendments.Enabled = false;
            this.grpNewAmendments.Location = new System.Drawing.Point(7, 363);
            this.grpNewAmendments.Name = "grpNewAmendments";
            this.grpNewAmendments.Size = new System.Drawing.Size(763, 128);
            this.grpNewAmendments.TabIndex = 1;
            this.grpNewAmendments.TabStop = false;
            this.grpNewAmendments.Text = "New Amendment Request";
            // 
            // btnAmendmentArrow
            // 
            this.btnAmendmentArrow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmendmentArrow.Location = new System.Drawing.Point(530, 19);
            this.btnAmendmentArrow.Name = "btnAmendmentArrow";
            this.btnAmendmentArrow.Size = new System.Drawing.Size(30, 23);
            this.btnAmendmentArrow.TabIndex = 156;
            this.btnAmendmentArrow.Text = ">";
            this.btnAmendmentArrow.UseVisualStyleBackColor = true;
            this.btnAmendmentArrow.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridAmendmentSchedules
            // 
            this.gridAmendmentSchedules.AllowEditing = false;
            this.gridAmendmentSchedules.ColumnInfo = resources.GetString("gridAmendmentSchedules.ColumnInfo");
            this.gridAmendmentSchedules.ExtendLastCol = true;
            this.gridAmendmentSchedules.Location = new System.Drawing.Point(6, 19);
            this.gridAmendmentSchedules.Name = "gridAmendmentSchedules";
            this.gridAmendmentSchedules.Rows.Count = 1;
            this.gridAmendmentSchedules.Rows.DefaultSize = 17;
            this.gridAmendmentSchedules.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.gridAmendmentSchedules.Size = new System.Drawing.Size(518, 81);
            this.gridAmendmentSchedules.StyleInfo = resources.GetString("gridAmendmentSchedules.StyleInfo");
            this.gridAmendmentSchedules.TabIndex = 155;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(562, 76);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(67, 14);
            this.label90.TabIndex = 154;
            this.label90.Text = "New Entry : ";
            this.label90.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtAmendmentNo
            // 
            this.txtAmendmentNo.BackColor = System.Drawing.Color.White;
            this.txtAmendmentNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmendmentNo.Location = new System.Drawing.Point(102, 106);
            this.txtAmendmentNo.Name = "txtAmendmentNo";
            this.txtAmendmentNo.ReadOnly = true;
            this.txtAmendmentNo.Size = new System.Drawing.Size(205, 20);
            this.txtAmendmentNo.TabIndex = 8;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(10, 111);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(82, 14);
            this.label86.TabIndex = 9;
            this.label86.Text = "Amendment # : ";
            // 
            // txtNewValue
            // 
            this.txtNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewValue.BackColor = System.Drawing.Color.White;
            this.txtNewValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewValue.Location = new System.Drawing.Point(638, 75);
            this.txtNewValue.Multiline = true;
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewValue.Size = new System.Drawing.Size(115, 50);
            this.txtNewValue.TabIndex = 153;
            // 
            // txtOldValue
            // 
            this.txtOldValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldValue.BackColor = System.Drawing.Color.White;
            this.txtOldValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOldValue.Location = new System.Drawing.Point(638, 18);
            this.txtOldValue.Multiline = true;
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOldValue.Size = new System.Drawing.Size(115, 51);
            this.txtOldValue.TabIndex = 151;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(569, 16);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(57, 14);
            this.label89.TabIndex = 152;
            this.label89.Text = "Old Entry: ";
            this.label89.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlAmendments
            // 
            this.pnlAmendments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAmendments.Controls.Add(this.btnPrintSystemChanges);
            this.pnlAmendments.Controls.Add(this.btnNewAmmendment);
            this.pnlAmendments.Controls.Add(this.btnPrintAmmendments);
            this.pnlAmendments.Controls.Add(this.btnSaveAmmendment);
            this.pnlAmendments.Location = new System.Drawing.Point(3, 491);
            this.pnlAmendments.Name = "pnlAmendments";
            this.pnlAmendments.Size = new System.Drawing.Size(441, 41);
            this.pnlAmendments.TabIndex = 19;
            // 
            // btnPrintSystemChanges
            // 
            this.btnPrintSystemChanges.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.printer16;
            this.btnPrintSystemChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSystemChanges.Location = new System.Drawing.Point(132, 6);
            this.btnPrintSystemChanges.Name = "btnPrintSystemChanges";
            this.btnPrintSystemChanges.Size = new System.Drawing.Size(155, 31);
            this.btnPrintSystemChanges.TabIndex = 21;
            this.btnPrintSystemChanges.Text = "Print Schedule Changes";
            this.btnPrintSystemChanges.UseVisualStyleBackColor = true;
            this.btnPrintSystemChanges.Click += new System.EventHandler(this.btnPrintSystemChanges_Click);
            // 
            // btnNewAmmendment
            // 
            this.btnNewAmmendment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewAmmendment.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnNewAmmendment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewAmmendment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAmmendment.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.add16;
            this.btnNewAmmendment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewAmmendment.Location = new System.Drawing.Point(296, 5);
            this.btnNewAmmendment.Name = "btnNewAmmendment";
            this.btnNewAmmendment.Size = new System.Drawing.Size(70, 31);
            this.btnNewAmmendment.TabIndex = 17;
            this.btnNewAmmendment.Text = "    New";
            this.btnNewAmmendment.Click += new System.EventHandler(this.btnNewAmmendment_Click);
            // 
            // btnPrintAmmendments
            // 
            this.btnPrintAmmendments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintAmmendments.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPrintAmmendments.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrintAmmendments.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAmmendments.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.printer16;
            this.btnPrintAmmendments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintAmmendments.Location = new System.Drawing.Point(7, 6);
            this.btnPrintAmmendments.Name = "btnPrintAmmendments";
            this.btnPrintAmmendments.Size = new System.Drawing.Size(119, 31);
            this.btnPrintAmmendments.TabIndex = 18;
            this.btnPrintAmmendments.Text = "Print Amendments";
            this.btnPrintAmmendments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintAmmendments.Click += new System.EventHandler(this.btnPrintAmmendments_Click);
            // 
            // btnSaveAmmendment
            // 
            this.btnSaveAmmendment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAmmendment.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSaveAmmendment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveAmmendment.Enabled = false;
            this.btnSaveAmmendment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAmmendment.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.saveas16;
            this.btnSaveAmmendment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveAmmendment.Location = new System.Drawing.Point(366, 5);
            this.btnSaveAmmendment.Name = "btnSaveAmmendment";
            this.btnSaveAmmendment.Size = new System.Drawing.Size(66, 31);
            this.btnSaveAmmendment.TabIndex = 16;
            this.btnSaveAmmendment.Text = "    Save";
            this.btnSaveAmmendment.Click += new System.EventHandler(this.btnSaveAmmendment_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox20);
            this.groupBox3.Controls.Add(this.groupBox19);
            this.groupBox3.Controls.Add(this.grdAmmendments);
            this.groupBox3.Controls.Add(this.panel7);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 133);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Requested Amendments";
            // 
            // groupBox20
            // 
            this.groupBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox20.Controls.Add(this.c1FlexGrid2);
            this.groupBox20.Location = new System.Drawing.Point(0, 127);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(764, 245);
            this.groupBox20.TabIndex = 20;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Reservation Changes";
            // 
            // c1FlexGrid2
            // 
            this.c1FlexGrid2.AllowEditing = false;
            this.c1FlexGrid2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            this.c1FlexGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.c1FlexGrid2.ColumnInfo = resources.GetString("c1FlexGrid2.ColumnInfo");
            this.c1FlexGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid2.ExtendLastCol = true;
            this.c1FlexGrid2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.c1FlexGrid2.Location = new System.Drawing.Point(3, 16);
            this.c1FlexGrid2.Name = "c1FlexGrid2";
            this.c1FlexGrid2.Rows.Count = 1;
            this.c1FlexGrid2.Rows.DefaultSize = 17;
            this.c1FlexGrid2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.c1FlexGrid2.Size = new System.Drawing.Size(758, 226);
            this.c1FlexGrid2.StyleInfo = resources.GetString("c1FlexGrid2.StyleInfo");
            this.c1FlexGrid2.TabIndex = 0;
            // 
            // groupBox19
            // 
            this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox19.Controls.Add(this.button6);
            this.groupBox19.Controls.Add(this.c1FlexGrid1);
            this.groupBox19.Controls.Add(this.label139);
            this.groupBox19.Controls.Add(this.textBox1);
            this.groupBox19.Controls.Add(this.label140);
            this.groupBox19.Controls.Add(this.textBox2);
            this.groupBox19.Controls.Add(this.textBox3);
            this.groupBox19.Controls.Add(this.label141);
            this.groupBox19.Enabled = false;
            this.groupBox19.Location = new System.Drawing.Point(1, 360);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(763, 128);
            this.groupBox19.TabIndex = 1;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "New Amendment Request";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(530, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 23);
            this.button6.TabIndex = 156;
            this.button6.Text = ">";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button1_Click);
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowEditing = false;
            this.c1FlexGrid1.ColumnInfo = resources.GetString("c1FlexGrid1.ColumnInfo");
            this.c1FlexGrid1.ExtendLastCol = true;
            this.c1FlexGrid1.Location = new System.Drawing.Point(6, 19);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 1;
            this.c1FlexGrid1.Rows.DefaultSize = 17;
            this.c1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.c1FlexGrid1.Size = new System.Drawing.Size(518, 81);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 155;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.Location = new System.Drawing.Point(562, 76);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(67, 14);
            this.label139.TabIndex = 154;
            this.label139.Text = "New Entry : ";
            this.label139.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(102, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(10, 111);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(82, 14);
            this.label140.TabIndex = 9;
            this.label140.Text = "Amendment # : ";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(638, 75);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(115, 50);
            this.textBox2.TabIndex = 153;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(638, 18);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(115, 51);
            this.textBox3.TabIndex = 151;
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.Location = new System.Drawing.Point(569, 16);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(57, 14);
            this.label141.TabIndex = 152;
            this.label141.Text = "Old Entry: ";
            this.label141.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // grdAmmendments
            // 
            this.grdAmmendments.AllowEditing = false;
            this.grdAmmendments.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            this.grdAmmendments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAmmendments.ColumnInfo = resources.GetString("grdAmmendments.ColumnInfo");
            this.grdAmmendments.ExtendLastCol = true;
            this.grdAmmendments.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdAmmendments.Location = new System.Drawing.Point(6, 16);
            this.grdAmmendments.Name = "grdAmmendments";
            this.grdAmmendments.Rows.Count = 1;
            this.grdAmmendments.Rows.DefaultSize = 17;
            this.grdAmmendments.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdAmmendments.Size = new System.Drawing.Size(752, 111);
            this.grdAmmendments.StyleInfo = resources.GetString("grdAmmendments.StyleInfo");
            this.grdAmmendments.TabIndex = 0;
            this.grdAmmendments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdAmmendments_KeyDown);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.button1);
            this.panel7.Controls.Add(this.button3);
            this.panel7.Controls.Add(this.button4);
            this.panel7.Controls.Add(this.button5);
            this.panel7.Location = new System.Drawing.Point(-3, 488);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(441, 41);
            this.panel7.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.printer16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(132, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "Print Schedule Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnPrintSystemChanges_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.add16;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(296, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 31);
            this.button3.TabIndex = 17;
            this.button3.Text = "    New";
            this.button3.Click += new System.EventHandler(this.btnNewAmmendment_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.printer16;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(7, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 31);
            this.button4.TabIndex = 18;
            this.button4.Text = "Print Amendments";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Click += new System.EventHandler(this.btnPrintAmmendments_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.saveas16;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(366, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 31);
            this.button5.TabIndex = 16;
            this.button5.Text = "    Save";
            this.button5.Click += new System.EventHandler(this.btnSaveAmmendment_Click);
            // 
            // tabEventRequirements
            // 
            this.tabEventRequirements.Controls.Add(this.grpRequirements);
            this.tabEventRequirements.Location = new System.Drawing.Point(4, 23);
            this.tabEventRequirements.Name = "tabEventRequirements";
            this.tabEventRequirements.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventRequirements.Size = new System.Drawing.Size(776, 288);
            this.tabEventRequirements.TabIndex = 14;
            this.tabEventRequirements.Text = "Event Order";
            this.tabEventRequirements.UseVisualStyleBackColor = true;
            // 
            // tabEndorsement
            // 
            this.tabEndorsement.Controls.Add(this.groupBox18);
            this.tabEndorsement.Controls.Add(this.groupBox17);
            this.tabEndorsement.Controls.Add(this.groupForEMDAction);
            this.tabEndorsement.Controls.Add(this.groupBox14);
            this.tabEndorsement.Controls.Add(this.groupReservationFee);
            this.tabEndorsement.Location = new System.Drawing.Point(4, 23);
            this.tabEndorsement.Name = "tabEndorsement";
            this.tabEndorsement.Padding = new System.Windows.Forms.Padding(3);
            this.tabEndorsement.Size = new System.Drawing.Size(776, 288);
            this.tabEndorsement.TabIndex = 15;
            this.tabEndorsement.Text = "Endorsements";
            this.tabEndorsement.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.btnViewLOP);
            this.groupBox18.Controls.Add(this.btnUploadLOP);
            this.groupBox18.Controls.Add(this.btnExport);
            this.groupBox18.Controls.Add(this.label107);
            this.groupBox18.Controls.Add(this.cboLetterOfProposal);
            this.groupBox18.Location = new System.Drawing.Point(3, 156);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(765, 48);
            this.groupBox18.TabIndex = 17;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Letter of Proposal";
            // 
            // btnViewLOP
            // 
            this.btnViewLOP.Location = new System.Drawing.Point(458, 13);
            this.btnViewLOP.Name = "btnViewLOP";
            this.btnViewLOP.Size = new System.Drawing.Size(75, 23);
            this.btnViewLOP.TabIndex = 4;
            this.btnViewLOP.Text = "View LOP";
            this.btnViewLOP.UseVisualStyleBackColor = true;
            this.btnViewLOP.Click += new System.EventHandler(this.btnViewLOP_Click);
            // 
            // btnUploadLOP
            // 
            this.btnUploadLOP.Location = new System.Drawing.Point(377, 13);
            this.btnUploadLOP.Name = "btnUploadLOP";
            this.btnUploadLOP.Size = new System.Drawing.Size(75, 23);
            this.btnUploadLOP.TabIndex = 3;
            this.btnUploadLOP.Text = "Upload LOP";
            this.btnUploadLOP.UseVisualStyleBackColor = true;
            this.btnUploadLOP.Click += new System.EventHandler(this.btnUploadLOP_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(297, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export LOP";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label107.Location = new System.Drawing.Point(40, 17);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(93, 14);
            this.label107.TabIndex = 0;
            this.label107.Text = "Letter of Proposal";
            // 
            // cboLetterOfProposal
            // 
            this.cboLetterOfProposal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLetterOfProposal.FormattingEnabled = true;
            this.cboLetterOfProposal.Location = new System.Drawing.Point(157, 14);
            this.cboLetterOfProposal.Name = "cboLetterOfProposal";
            this.cboLetterOfProposal.Size = new System.Drawing.Size(134, 22);
            this.cboLetterOfProposal.TabIndex = 1;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtGiveaways);
            this.groupBox17.Controls.Add(this.txtDiscountConcessions);
            this.groupBox17.Controls.Add(this.label134);
            this.groupBox17.Controls.Add(this.label133);
            this.groupBox17.Location = new System.Drawing.Point(3, 210);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(525, 171);
            this.groupBox17.TabIndex = 16;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "For Account Management";
            // 
            // txtGiveaways
            // 
            this.txtGiveaways.Location = new System.Drawing.Point(9, 99);
            this.txtGiveaways.Multiline = true;
            this.txtGiveaways.Name = "txtGiveaways";
            this.txtGiveaways.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGiveaways.Size = new System.Drawing.Size(506, 66);
            this.txtGiveaways.TabIndex = 3;
            // 
            // txtDiscountConcessions
            // 
            this.txtDiscountConcessions.Location = new System.Drawing.Point(9, 33);
            this.txtDiscountConcessions.Multiline = true;
            this.txtDiscountConcessions.Name = "txtDiscountConcessions";
            this.txtDiscountConcessions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiscountConcessions.Size = new System.Drawing.Size(506, 46);
            this.txtDiscountConcessions.TabIndex = 2;
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(6, 82);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(140, 14);
            this.label134.TabIndex = 1;
            this.label134.Text = "Giveaways / Tokens Given:";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(6, 16);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(165, 14);
            this.label133.TabIndex = 0;
            this.label133.Text = "Discount / Concessions Offered:";
            // 
            // groupForEMDAction
            // 
            this.groupForEMDAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupForEMDAction.Controls.Add(this.gridEMDActions);
            this.groupForEMDAction.Location = new System.Drawing.Point(534, 210);
            this.groupForEMDAction.Name = "groupForEMDAction";
            this.groupForEMDAction.Size = new System.Drawing.Size(236, 317);
            this.groupForEMDAction.TabIndex = 15;
            this.groupForEMDAction.TabStop = false;
            this.groupForEMDAction.Text = "For EMDs Action";
            // 
            // gridEMDActions
            // 
            this.gridEMDActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEMDActions.ColumnInfo = "1,0,0,0,0,85,Columns:0{Width:763;Caption:\"Action\";TextAlignFixed:LeftCenter;}\t";
            this.gridEMDActions.Location = new System.Drawing.Point(17, 26);
            this.gridEMDActions.Name = "gridEMDActions";
            this.gridEMDActions.Rows.Count = 1;
            this.gridEMDActions.Rows.DefaultSize = 17;
            this.gridEMDActions.Size = new System.Drawing.Size(205, 285);
            this.gridEMDActions.StyleInfo = resources.GetString("gridEMDActions.StyleInfo");
            this.gridEMDActions.TabIndex = 0;
            this.gridEMDActions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridEMDActions_MouseClick);
            // 
            // groupBox14
            // 
            this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox14.Controls.Add(this.dtpForPickUp);
            this.groupBox14.Controls.Add(this.dtpSentToClient);
            this.groupBox14.Controls.Add(this.dtpSigned);
            this.groupBox14.Controls.Add(this.rdoReturned);
            this.groupBox14.Controls.Add(this.rdoSentToClient);
            this.groupBox14.Controls.Add(this.rdoForPickup);
            this.groupBox14.Controls.Add(this.rdoBeingProcessed);
            this.groupBox14.Location = new System.Drawing.Point(534, 6);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(236, 144);
            this.groupBox14.TabIndex = 14;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Letter of Agreement / Contract ";
            // 
            // dtpForPickUp
            // 
            this.dtpForPickUp.CustomFormat = "dd-MMM-yyyy";
            this.dtpForPickUp.Enabled = false;
            this.dtpForPickUp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForPickUp.Location = new System.Drawing.Point(170, 48);
            this.dtpForPickUp.Name = "dtpForPickUp";
            this.dtpForPickUp.Size = new System.Drawing.Size(96, 20);
            this.dtpForPickUp.TabIndex = 6;
            // 
            // dtpSentToClient
            // 
            this.dtpSentToClient.CustomFormat = "dd-MMM-yyyy";
            this.dtpSentToClient.Enabled = false;
            this.dtpSentToClient.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSentToClient.Location = new System.Drawing.Point(170, 73);
            this.dtpSentToClient.Name = "dtpSentToClient";
            this.dtpSentToClient.Size = new System.Drawing.Size(96, 20);
            this.dtpSentToClient.TabIndex = 5;
            // 
            // dtpSigned
            // 
            this.dtpSigned.CustomFormat = "dd-MMM-yyyy";
            this.dtpSigned.Enabled = false;
            this.dtpSigned.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSigned.Location = new System.Drawing.Point(170, 98);
            this.dtpSigned.Name = "dtpSigned";
            this.dtpSigned.Size = new System.Drawing.Size(96, 20);
            this.dtpSigned.TabIndex = 4;
            // 
            // rdoReturned
            // 
            this.rdoReturned.AutoSize = true;
            this.rdoReturned.Location = new System.Drawing.Point(22, 100);
            this.rdoReturned.Name = "rdoReturned";
            this.rdoReturned.Size = new System.Drawing.Size(142, 18);
            this.rdoReturned.TabIndex = 3;
            this.rdoReturned.Text = "Signed, returned to PICC";
            this.rdoReturned.UseVisualStyleBackColor = true;
            this.rdoReturned.CheckedChanged += new System.EventHandler(this.rdoReturned_CheckedChanged);
            // 
            // rdoSentToClient
            // 
            this.rdoSentToClient.AutoSize = true;
            this.rdoSentToClient.Location = new System.Drawing.Point(22, 74);
            this.rdoSentToClient.Name = "rdoSentToClient";
            this.rdoSentToClient.Size = new System.Drawing.Size(87, 18);
            this.rdoSentToClient.TabIndex = 2;
            this.rdoSentToClient.Text = "Sent to client";
            this.rdoSentToClient.UseVisualStyleBackColor = true;
            this.rdoSentToClient.CheckedChanged += new System.EventHandler(this.rdoSentToClient_CheckedChanged);
            // 
            // rdoForPickup
            // 
            this.rdoForPickup.AutoSize = true;
            this.rdoForPickup.Location = new System.Drawing.Point(22, 48);
            this.rdoForPickup.Name = "rdoForPickup";
            this.rdoForPickup.Size = new System.Drawing.Size(79, 18);
            this.rdoForPickup.TabIndex = 1;
            this.rdoForPickup.Text = "For Pick-up";
            this.rdoForPickup.UseVisualStyleBackColor = true;
            this.rdoForPickup.CheckedChanged += new System.EventHandler(this.rdoForPickup_CheckedChanged);
            // 
            // rdoBeingProcessed
            // 
            this.rdoBeingProcessed.AutoSize = true;
            this.rdoBeingProcessed.Location = new System.Drawing.Point(22, 20);
            this.rdoBeingProcessed.Name = "rdoBeingProcessed";
            this.rdoBeingProcessed.Size = new System.Drawing.Size(107, 18);
            this.rdoBeingProcessed.TabIndex = 0;
            this.rdoBeingProcessed.Text = "Being Processed";
            this.rdoBeingProcessed.UseVisualStyleBackColor = true;
            this.rdoBeingProcessed.CheckedChanged += new System.EventHandler(this.rdoBeingProcessed_CheckedChanged);
            // 
            // groupReservationFee
            // 
            this.groupReservationFee.Controls.Add(this.txtContractAmount);
            this.groupReservationFee.Controls.Add(this.dtp25RF2);
            this.groupReservationFee.Controls.Add(this.dtp50RF);
            this.groupReservationFee.Controls.Add(this.label115);
            this.groupReservationFee.Controls.Add(this.dtp25RF1);
            this.groupReservationFee.Controls.Add(this.txtBalanceRF);
            this.groupReservationFee.Controls.Add(this.label108);
            this.groupReservationFee.Controls.Add(this.label112);
            this.groupReservationFee.Controls.Add(this.txt25RF2);
            this.groupReservationFee.Controls.Add(this.label109);
            this.groupReservationFee.Controls.Add(this.label111);
            this.groupReservationFee.Controls.Add(this.txt25RF1);
            this.groupReservationFee.Controls.Add(this.txt50RF);
            this.groupReservationFee.Controls.Add(this.label110);
            this.groupReservationFee.Location = new System.Drawing.Point(3, 6);
            this.groupReservationFee.Name = "groupReservationFee";
            this.groupReservationFee.Size = new System.Drawing.Size(525, 144);
            this.groupReservationFee.TabIndex = 13;
            this.groupReservationFee.TabStop = false;
            this.groupReservationFee.Text = "Reservation Fee";
            // 
            // txtContractAmount
            // 
            this.txtContractAmount.DecimalPlaces = 2;
            this.txtContractAmount.Location = new System.Drawing.Point(157, 14);
            this.txtContractAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtContractAmount.Name = "txtContractAmount";
            this.txtContractAmount.Size = new System.Drawing.Size(134, 20);
            this.txtContractAmount.TabIndex = 16;
            this.txtContractAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContractAmount.ThousandsSeparator = true;
            this.txtContractAmount.ValueChanged += new System.EventHandler(this.txtContractAmount_TextChanged);
            // 
            // dtp25RF2
            // 
            this.dtp25RF2.CustomFormat = "dd-MMM-yyyy";
            this.dtp25RF2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp25RF2.Location = new System.Drawing.Point(297, 92);
            this.dtp25RF2.Name = "dtp25RF2";
            this.dtp25RF2.Size = new System.Drawing.Size(118, 20);
            this.dtp25RF2.TabIndex = 15;
            // 
            // dtp50RF
            // 
            this.dtp50RF.CustomFormat = "dd-MMM-yyyy";
            this.dtp50RF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp50RF.Location = new System.Drawing.Point(297, 66);
            this.dtp50RF.Name = "dtp50RF";
            this.dtp50RF.Size = new System.Drawing.Size(118, 20);
            this.dtp50RF.TabIndex = 14;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(297, 16);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(51, 14);
            this.label115.TabIndex = 13;
            this.label115.Text = "Due Date";
            // 
            // dtp25RF1
            // 
            this.dtp25RF1.CustomFormat = "dd-MMM-yyyy";
            this.dtp25RF1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp25RF1.Location = new System.Drawing.Point(297, 40);
            this.dtp25RF1.Name = "dtp25RF1";
            this.dtp25RF1.Size = new System.Drawing.Size(118, 20);
            this.dtp25RF1.TabIndex = 12;
            // 
            // txtBalanceRF
            // 
            this.txtBalanceRF.BackColor = System.Drawing.SystemColors.Window;
            this.txtBalanceRF.Enabled = false;
            this.txtBalanceRF.Location = new System.Drawing.Point(157, 118);
            this.txtBalanceRF.Name = "txtBalanceRF";
            this.txtBalanceRF.Size = new System.Drawing.Size(134, 20);
            this.txtBalanceRF.TabIndex = 11;
            this.txtBalanceRF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(16, 16);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(87, 14);
            this.label108.TabIndex = 2;
            this.label108.Text = "Contract Amount";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(40, 121);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(46, 14);
            this.label112.TabIndex = 10;
            this.label112.Text = "Balance";
            // 
            // txt25RF2
            // 
            this.txt25RF2.BackColor = System.Drawing.SystemColors.Window;
            this.txt25RF2.Enabled = false;
            this.txt25RF2.Location = new System.Drawing.Point(157, 92);
            this.txt25RF2.Name = "txt25RF2";
            this.txt25RF2.Size = new System.Drawing.Size(134, 20);
            this.txt25RF2.TabIndex = 9;
            this.txt25RF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(40, 44);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(111, 14);
            this.label109.TabIndex = 4;
            this.label109.Text = "25% Reservation Fee";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(40, 95);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(73, 14);
            this.label111.TabIndex = 8;
            this.label111.Text = "25% Payment";
            // 
            // txt25RF1
            // 
            this.txt25RF1.BackColor = System.Drawing.SystemColors.Window;
            this.txt25RF1.Enabled = false;
            this.txt25RF1.Location = new System.Drawing.Point(157, 40);
            this.txt25RF1.Name = "txt25RF1";
            this.txt25RF1.Size = new System.Drawing.Size(134, 20);
            this.txt25RF1.TabIndex = 5;
            this.txt25RF1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt50RF
            // 
            this.txt50RF.BackColor = System.Drawing.SystemColors.Window;
            this.txt50RF.Enabled = false;
            this.txt50RF.Location = new System.Drawing.Point(157, 66);
            this.txt50RF.Name = "txt50RF";
            this.txt50RF.Size = new System.Drawing.Size(134, 20);
            this.txt50RF.TabIndex = 7;
            this.txt50RF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(40, 69);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(73, 14);
            this.label110.TabIndex = 6;
            this.label110.Text = "50% Payment";
            // 
            // tabCancellation
            // 
            this.tabCancellation.Controls.Add(this.cboCancelBookingType);
            this.tabCancellation.Controls.Add(this.label131);
            this.tabCancellation.Controls.Add(this.cboReason);
            this.tabCancellation.Controls.Add(this.label130);
            this.tabCancellation.Controls.Add(this.btnSaveCancellation);
            this.tabCancellation.Controls.Add(this.txtFutureAction);
            this.tabCancellation.Controls.Add(this.txtReasons);
            this.tabCancellation.Controls.Add(this.label114);
            this.tabCancellation.Controls.Add(this.label113);
            this.tabCancellation.Location = new System.Drawing.Point(4, 23);
            this.tabCancellation.Name = "tabCancellation";
            this.tabCancellation.Padding = new System.Windows.Forms.Padding(3);
            this.tabCancellation.Size = new System.Drawing.Size(776, 288);
            this.tabCancellation.TabIndex = 16;
            this.tabCancellation.Text = "Cancellation";
            this.tabCancellation.UseVisualStyleBackColor = true;
            // 
            // cboCancelBookingType
            // 
            this.cboCancelBookingType.FormattingEnabled = true;
            this.cboCancelBookingType.Location = new System.Drawing.Point(521, 23);
            this.cboCancelBookingType.Name = "cboCancelBookingType";
            this.cboCancelBookingType.Size = new System.Drawing.Size(121, 22);
            this.cboCancelBookingType.TabIndex = 8;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(402, 26);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(71, 14);
            this.label131.TabIndex = 7;
            this.label131.Text = "Booking Type";
            // 
            // cboReason
            // 
            this.cboReason.FormattingEnabled = true;
            this.cboReason.Location = new System.Drawing.Point(170, 23);
            this.cboReason.Name = "cboReason";
            this.cboReason.Size = new System.Drawing.Size(121, 22);
            this.cboReason.TabIndex = 6;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(78, 26);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(44, 14);
            this.label130.TabIndex = 5;
            this.label130.Text = "Reason";
            // 
            // btnSaveCancellation
            // 
            this.btnSaveCancellation.Location = new System.Drawing.Point(609, 323);
            this.btnSaveCancellation.Name = "btnSaveCancellation";
            this.btnSaveCancellation.Size = new System.Drawing.Size(66, 36);
            this.btnSaveCancellation.TabIndex = 4;
            this.btnSaveCancellation.Text = "Save";
            this.btnSaveCancellation.UseVisualStyleBackColor = true;
            this.btnSaveCancellation.Click += new System.EventHandler(this.btnSaveCancellation_Click);
            // 
            // txtFutureAction
            // 
            this.txtFutureAction.Location = new System.Drawing.Point(170, 207);
            this.txtFutureAction.Multiline = true;
            this.txtFutureAction.Name = "txtFutureAction";
            this.txtFutureAction.Size = new System.Drawing.Size(505, 110);
            this.txtFutureAction.TabIndex = 3;
            // 
            // txtReasons
            // 
            this.txtReasons.Location = new System.Drawing.Point(170, 72);
            this.txtReasons.Multiline = true;
            this.txtReasons.Name = "txtReasons";
            this.txtReasons.Size = new System.Drawing.Size(505, 101);
            this.txtReasons.TabIndex = 2;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(78, 210);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(71, 14);
            this.label114.TabIndex = 1;
            this.label114.Text = "Future Action";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(77, 73);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(91, 14);
            this.label113.TabIndex = 0;
            this.label113.Text = "Narrative Reason";
            // 
            // tabEventAttendance
            // 
            this.tabEventAttendance.Controls.Add(this.panel5);
            this.tabEventAttendance.Controls.Add(this.label129);
            this.tabEventAttendance.Controls.Add(this.txtEventAttendanceRemarks);
            this.tabEventAttendance.Controls.Add(this.groupBox16);
            this.tabEventAttendance.Controls.Add(this.groupBox15);
            this.tabEventAttendance.Location = new System.Drawing.Point(4, 23);
            this.tabEventAttendance.Name = "tabEventAttendance";
            this.tabEventAttendance.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventAttendance.Size = new System.Drawing.Size(776, 288);
            this.tabEventAttendance.TabIndex = 17;
            this.tabEventAttendance.Text = "Event Attendance";
            this.tabEventAttendance.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnPrintEventAttendance);
            this.panel5.Location = new System.Drawing.Point(651, 342);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(119, 39);
            this.panel5.TabIndex = 20;
            // 
            // btnPrintEventAttendance
            // 
            this.btnPrintEventAttendance.Location = new System.Drawing.Point(41, 2);
            this.btnPrintEventAttendance.Name = "btnPrintEventAttendance";
            this.btnPrintEventAttendance.Size = new System.Drawing.Size(75, 34);
            this.btnPrintEventAttendance.TabIndex = 21;
            this.btnPrintEventAttendance.Text = "Print";
            this.btnPrintEventAttendance.UseVisualStyleBackColor = true;
            this.btnPrintEventAttendance.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(5, 342);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(52, 14);
            this.label129.TabIndex = 19;
            this.label129.Text = "Remarks:";
            // 
            // txtEventAttendanceRemarks
            // 
            this.txtEventAttendanceRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventAttendanceRemarks.Location = new System.Drawing.Point(65, 342);
            this.txtEventAttendanceRemarks.Multiline = true;
            this.txtEventAttendanceRemarks.Name = "txtEventAttendanceRemarks";
            this.txtEventAttendanceRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEventAttendanceRemarks.Size = new System.Drawing.Size(580, 245);
            this.txtEventAttendanceRemarks.TabIndex = 18;
            // 
            // groupBox16
            // 
            this.groupBox16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox16.Controls.Add(this.label128);
            this.groupBox16.Controls.Add(this.nudActualAttendees);
            this.groupBox16.Controls.Add(this.label127);
            this.groupBox16.Location = new System.Drawing.Point(3, 254);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(767, 82);
            this.groupBox16.TabIndex = 17;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "For non-meeting type events such as social functions, graduations, concerts, etc." +
                ":";
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.Location = new System.Drawing.Point(10, 52);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(427, 14);
            this.label128.TabIndex = 2;
            this.label128.Text = "Note: Based on seats taken (concert), F&B covers for social functions, attendance" +
                ", etc.";
            // 
            // nudActualAttendees
            // 
            this.nudActualAttendees.Location = new System.Drawing.Point(135, 24);
            this.nudActualAttendees.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudActualAttendees.Name = "nudActualAttendees";
            this.nudActualAttendees.Size = new System.Drawing.Size(86, 20);
            this.nudActualAttendees.TabIndex = 1;
            this.nudActualAttendees.ThousandsSeparator = true;
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(6, 26);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(122, 14);
            this.label127.TabIndex = 0;
            this.label127.Text = "Actual No. of Attendees";
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.txtEventAttendanceNote);
            this.groupBox15.Controls.Add(this.nudVisitors);
            this.groupBox15.Controls.Add(this.label126);
            this.groupBox15.Controls.Add(this.label118);
            this.groupBox15.Controls.Add(this.nudLocalBased);
            this.groupBox15.Controls.Add(this.cboGeoEventType);
            this.groupBox15.Controls.Add(this.label125);
            this.groupBox15.Controls.Add(this.label124);
            this.groupBox15.Controls.Add(this.nudLocal);
            this.groupBox15.Controls.Add(this.nudForeignBased);
            this.groupBox15.Controls.Add(this.label119);
            this.groupBox15.Controls.Add(this.label123);
            this.groupBox15.Controls.Add(this.label120);
            this.groupBox15.Controls.Add(this.nudTotal);
            this.groupBox15.Controls.Add(this.label121);
            this.groupBox15.Controls.Add(this.label122);
            this.groupBox15.Controls.Add(this.nudForeign);
            this.groupBox15.Location = new System.Drawing.Point(3, 6);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(767, 247);
            this.groupBox15.TabIndex = 16;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "For conventions, conferences, congresses, meetings, fora, symposia, workshops, se" +
                "minars and other meeting-type events:";
            // 
            // txtEventAttendanceNote
            // 
            this.txtEventAttendanceNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventAttendanceNote.BackColor = System.Drawing.SystemColors.Control;
            this.txtEventAttendanceNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEventAttendanceNote.Enabled = false;
            this.txtEventAttendanceNote.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventAttendanceNote.Location = new System.Drawing.Point(9, 56);
            this.txtEventAttendanceNote.Multiline = true;
            this.txtEventAttendanceNote.Name = "txtEventAttendanceNote";
            this.txtEventAttendanceNote.ReadOnly = true;
            this.txtEventAttendanceNote.Size = new System.Drawing.Size(752, 48);
            this.txtEventAttendanceNote.TabIndex = 19;
            // 
            // nudVisitors
            // 
            this.nudVisitors.Location = new System.Drawing.Point(216, 221);
            this.nudVisitors.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudVisitors.Name = "nudVisitors";
            this.nudVisitors.Size = new System.Drawing.Size(96, 20);
            this.nudVisitors.TabIndex = 18;
            this.nudVisitors.ThousandsSeparator = true;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(10, 223);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(200, 14);
            this.label126.TabIndex = 17;
            this.label126.Text = "No. of Visitors to Trade Fairs/Exhibitions";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(6, 31);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(176, 14);
            this.label118.TabIndex = 1;
            this.label118.Text = "Event Type by Geographical Scope";
            // 
            // nudLocalBased
            // 
            this.nudLocalBased.Location = new System.Drawing.Point(442, 185);
            this.nudLocalBased.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLocalBased.Name = "nudLocalBased";
            this.nudLocalBased.Size = new System.Drawing.Size(88, 20);
            this.nudLocalBased.TabIndex = 15;
            this.nudLocalBased.ThousandsSeparator = true;
            // 
            // cboGeoEventType
            // 
            this.cboGeoEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGeoEventType.FormattingEnabled = true;
            this.cboGeoEventType.Location = new System.Drawing.Point(189, 28);
            this.cboGeoEventType.Name = "cboGeoEventType";
            this.cboGeoEventType.Size = new System.Drawing.Size(152, 22);
            this.cboGeoEventType.TabIndex = 0;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(369, 187);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(67, 14);
            this.label125.TabIndex = 14;
            this.label125.Text = "Local-based";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(58, 187);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(77, 14);
            this.label124.TabIndex = 13;
            this.label124.Text = "Foreign-based";
            // 
            // nudLocal
            // 
            this.nudLocal.Location = new System.Drawing.Point(309, 128);
            this.nudLocal.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLocal.Name = "nudLocal";
            this.nudLocal.Size = new System.Drawing.Size(85, 20);
            this.nudLocal.TabIndex = 9;
            this.nudLocal.ThousandsSeparator = true;
            this.nudLocal.ValueChanged += new System.EventHandler(this.nudLocal_ValueChanged);
            // 
            // nudForeignBased
            // 
            this.nudForeignBased.Location = new System.Drawing.Point(141, 185);
            this.nudForeignBased.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudForeignBased.Name = "nudForeignBased";
            this.nudForeignBased.Size = new System.Drawing.Size(91, 20);
            this.nudForeignBased.TabIndex = 12;
            this.nudForeignBased.ThousandsSeparator = true;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(6, 107);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(148, 14);
            this.label119.TabIndex = 4;
            this.label119.Text = "No. of Participants/Attendees";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(6, 161);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(222, 14);
            this.label123.TabIndex = 11;
            this.label123.Text = "No. of Exhibitors (per company/organization)";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(58, 130);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(43, 14);
            this.label120.TabIndex = 5;
            this.label120.Text = "Foreign";
            // 
            // nudTotal
            // 
            this.nudTotal.Location = new System.Drawing.Point(515, 128);
            this.nudTotal.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.ReadOnly = true;
            this.nudTotal.Size = new System.Drawing.Size(101, 20);
            this.nudTotal.TabIndex = 10;
            this.nudTotal.ThousandsSeparator = true;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(270, 130);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(33, 14);
            this.label121.TabIndex = 6;
            this.label121.Text = "Local";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(479, 130);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(29, 14);
            this.label122.TabIndex = 7;
            this.label122.Text = "Total";
            // 
            // nudForeign
            // 
            this.nudForeign.Location = new System.Drawing.Point(107, 128);
            this.nudForeign.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudForeign.Name = "nudForeign";
            this.nudForeign.Size = new System.Drawing.Size(81, 20);
            this.nudForeign.TabIndex = 8;
            this.nudForeign.ThousandsSeparator = true;
            this.nudForeign.ValueChanged += new System.EventHandler(this.nudForeign_ValueChanged);
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.SystemColors.Info;
            this.label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label53.Location = new System.Drawing.Point(0, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(387, 24);
            this.label53.TabIndex = 86;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.SystemColors.Info;
            this.label54.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(42, 5);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(154, 15);
            this.label54.TabIndex = 15;
            this.label54.Text = "Charge";
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.SystemColors.Info;
            this.label55.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(6, 4);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(68, 17);
            this.label55.TabIndex = 16;
            this.label55.Text = "Code";
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.SystemColors.Info;
            this.label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label59.Location = new System.Drawing.Point(0, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(387, 24);
            this.label59.TabIndex = 86;
            // 
            // lvwBrowseGuestName
            // 
            this.lvwBrowseGuestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwBrowseGuestName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40});
            this.lvwBrowseGuestName.FullRowSelect = true;
            this.lvwBrowseGuestName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwBrowseGuestName.Location = new System.Drawing.Point(-406, 0);
            this.lvwBrowseGuestName.Name = "lvwBrowseGuestName";
            this.lvwBrowseGuestName.Size = new System.Drawing.Size(385, 122);
            this.lvwBrowseGuestName.TabIndex = 124;
            this.lvwBrowseGuestName.UseCompatibleStateImageBehavior = false;
            this.lvwBrowseGuestName.View = System.Windows.Forms.View.Details;
            this.lvwBrowseGuestName.Visible = false;
            this.lvwBrowseGuestName.DoubleClick += new System.EventHandler(this.lvwBrowseGuestName_DoubleClick);
            this.lvwBrowseGuestName.Leave += new System.EventHandler(this.lvwBrowseGuestName_Leave);
            this.lvwBrowseGuestName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseGuestName_KeyPress);
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Account Id";
            this.columnHeader38.Width = 93;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Last Name";
            this.columnHeader39.Width = 140;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "First Name";
            this.columnHeader40.Width = 155;
            // 
            // btnPrintContract
            // 
            this.btnPrintContract.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPrintContract.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintContract.Location = new System.Drawing.Point(73, 3);
            this.btnPrintContract.Name = "btnPrintContract";
            this.btnPrintContract.Size = new System.Drawing.Size(66, 36);
            this.btnPrintContract.TabIndex = 10;
            this.btnPrintContract.Text = "Contract";
            this.btnPrintContract.Click += new System.EventHandler(this.btnPrintContract_Click);
            // 
            // pnlNew
            // 
            this.pnlNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNew.Controls.Add(this.btnCancelReservation);
            this.pnlNew.Controls.Add(this.btnEdit);
            this.pnlNew.Controls.Add(this.btnSave);
            this.pnlNew.Location = new System.Drawing.Point(567, 535);
            this.pnlNew.Name = "pnlNew";
            this.pnlNew.Size = new System.Drawing.Size(153, 42);
            this.pnlNew.TabIndex = 5;
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancelReservation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelReservation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelReservation.Location = new System.Drawing.Point(4, 3);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(66, 36);
            this.btnCancelReservation.TabIndex = 15;
            this.btnCancelReservation.Text = "C&ancel";
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(71, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 36);
            this.btnEdit.TabIndex = 128;
            this.btnEdit.Text = "Edit Info";
            this.btnEdit.Visible = false;
            this.btnEdit.VisibleChanged += new System.EventHandler(this.btnEdit_VisibleChanged);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(71, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 36);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(723, 542);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 36);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // mnuSchedule
            // 
            this.mnuSchedule.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAddItem,
            this.mnuDelete,
            this.menuItem2,
            this.mnuRefreshSchedule});
            // 
            // mnuAddItem
            // 
            this.mnuAddItem.Enabled = false;
            this.mnuAddItem.Index = 0;
            this.mnuAddItem.Text = "Add Schedule";
            this.mnuAddItem.Click += new System.EventHandler(this.mnuAddItem_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Enabled = false;
            this.mnuDelete.Index = 1;
            this.mnuDelete.Text = "Delete Schedule";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // mnuRefreshSchedule
            // 
            this.mnuRefreshSchedule.Enabled = false;
            this.mnuRefreshSchedule.Index = 3;
            this.mnuRefreshSchedule.Text = "Refresh";
            this.mnuRefreshSchedule.Click += new System.EventHandler(this.mnuRefreshSchedule_Click);
            // 
            // pnlFolio
            // 
            this.pnlFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlFolio.Controls.Add(this.btnBookingSheet);
            this.pnlFolio.Controls.Add(this.btnPrintContract);
            this.pnlFolio.Controls.Add(this.btnFolio);
            this.pnlFolio.Location = new System.Drawing.Point(6, 539);
            this.pnlFolio.Name = "pnlFolio";
            this.pnlFolio.Size = new System.Drawing.Size(209, 42);
            this.pnlFolio.TabIndex = 3;
            this.pnlFolio.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // btnBookingSheet
            // 
            this.btnBookingSheet.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnBookingSheet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookingSheet.Location = new System.Drawing.Point(140, 3);
            this.btnBookingSheet.Name = "btnBookingSheet";
            this.btnBookingSheet.Size = new System.Drawing.Size(66, 36);
            this.btnBookingSheet.TabIndex = 11;
            this.btnBookingSheet.Text = "Booking Sheet";
            this.btnBookingSheet.Click += new System.EventHandler(this.btnBookingSheet_Click);
            // 
            // btnFolio
            // 
            this.btnFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolio.Location = new System.Drawing.Point(6, 3);
            this.btnFolio.Name = "btnFolio";
            this.btnFolio.Size = new System.Drawing.Size(66, 36);
            this.btnFolio.TabIndex = 9;
            this.btnFolio.Text = "Charges";
            this.btnFolio.Click += new System.EventHandler(this.btnFolio_Click);
            // 
            // txtDepartureDate
            // 
            this.txtDepartureDate.BackColor = System.Drawing.Color.White;
            this.txtDepartureDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepartureDate.Location = new System.Drawing.Point(456, 357);
            this.txtDepartureDate.Name = "txtDepartureDate";
            this.txtDepartureDate.Size = new System.Drawing.Size(145, 20);
            this.txtDepartureDate.TabIndex = 132;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnBrowseAgent);
            this.groupBox10.Controls.Add(this.txtAgentname);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Controls.Add(this.txtagentid);
            this.groupBox10.Location = new System.Drawing.Point(552, 153);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(286, 50);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Travel Agent";
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(10, 27);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 14);
            this.label29.TabIndex = 91;
            this.label29.Text = "Agent";
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.label106);
            this.groupBox12.Controls.Add(this.gridEventOfficer);
            this.groupBox12.Controls.Add(this.label103);
            this.groupBox12.Controls.Add(this.label102);
            this.groupBox12.Controls.Add(this.txtReferenceNo);
            this.groupBox12.Controls.Add(this.cboSales_Executive);
            this.groupBox12.Controls.Add(this.txtFolioID);
            this.groupBox12.Controls.Add(this.Label1);
            this.groupBox12.Controls.Add(this.label48);
            this.groupBox12.Controls.Add(this.cboUsers);
            this.groupBox12.Location = new System.Drawing.Point(439, 52);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(355, 160);
            this.groupBox12.TabIndex = 6;
            this.groupBox12.TabStop = false;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(18, 93);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(84, 14);
            this.label106.TabIndex = 192;
            this.label106.Text = "Event Officers";
            // 
            // gridEventOfficer
            // 
            this.gridEventOfficer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEventOfficer.ColumnInfo = "4,0,0,0,0,85,Columns:0{Width:150;Caption:\"Last Name\";}\t1{Width:150;Caption:\"First" +
                " Name\";}\t2{Caption:\"UserID\";Visible:False;}\t3{Caption:\"id\";Visible:False;}\t";
            this.gridEventOfficer.ExtendLastCol = true;
            this.gridEventOfficer.Location = new System.Drawing.Point(140, 93);
            this.gridEventOfficer.Name = "gridEventOfficer";
            this.gridEventOfficer.Rows.Count = 1;
            this.gridEventOfficer.Rows.DefaultSize = 17;
            this.gridEventOfficer.Size = new System.Drawing.Size(209, 61);
            this.gridEventOfficer.StyleInfo = resources.GetString("gridEventOfficer.StyleInfo");
            this.gridEventOfficer.TabIndex = 191;
            this.gridEventOfficer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridEventOfficer_MouseClick);
            this.gridEventOfficer.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridEventOfficer_AfterEdit);
            this.gridEventOfficer.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridEventOfficer_BeforeEdit);
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.ForeColor = System.Drawing.Color.Red;
            this.label103.Location = new System.Drawing.Point(18, 0);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(127, 14);
            this.label103.TabIndex = 190;
            this.label103.Text = "object is behid this group";
            this.label103.Visible = false;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label102.Location = new System.Drawing.Point(18, 42);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(111, 14);
            this.label102.TabIndex = 122;
            this.label102.Text = "Reference Number";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtReferenceNo.Location = new System.Drawing.Point(140, 39);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.ReadOnly = true;
            this.txtReferenceNo.Size = new System.Drawing.Size(127, 20);
            this.txtReferenceNo.TabIndex = 121;
            // 
            // cboUsers
            // 
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(163, 132);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(73, 22);
            this.cboUsers.TabIndex = 193;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.lblTINNumber);
            this.groupBox13.Controls.Add(this.txtTIN);
            this.groupBox13.Controls.Add(this.label105);
            this.groupBox13.Controls.Add(this.gridIncumbentOfficer);
            this.groupBox13.Controls.Add(this.label132);
            this.groupBox13.Controls.Add(this.txtEventDate);
            this.groupBox13.Controls.Add(this.label104);
            this.groupBox13.Controls.Add(this.txtCreateTime);
            this.groupBox13.Controls.Add(this.label34);
            this.groupBox13.Controls.Add(this.pnlCompany);
            this.groupBox13.Controls.Add(this.pnlIndividual);
            this.groupBox13.Controls.Add(this.rdbIndividual);
            this.groupBox13.Controls.Add(this.txtTHRESHOLD_VALUE);
            this.groupBox13.Controls.Add(this.rdbCompany);
            this.groupBox13.Controls.Add(this.btnBrowseAccount);
            this.groupBox13.Controls.Add(this.txtcompanyid);
            this.groupBox13.Controls.Add(this.label36);
            this.groupBox13.Controls.Add(this.txtTotal_Sales_Contribution);
            this.groupBox13.Controls.Add(this.txtFolioTYpe);
            this.groupBox13.Controls.Add(this.txtAccount_Type);
            this.groupBox13.Controls.Add(this.label15);
            this.groupBox13.Controls.Add(this.label35);
            this.groupBox13.Controls.Add(this.Label21);
            this.groupBox13.Controls.Add(this.Label3);
            this.groupBox13.Location = new System.Drawing.Point(10, 52);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(384, 160);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            // 
            // lblTINNumber
            // 
            this.lblTINNumber.AutoSize = true;
            this.lblTINNumber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTINNumber.Location = new System.Drawing.Point(13, 101);
            this.lblTINNumber.Name = "lblTINNumber";
            this.lblTINNumber.Size = new System.Drawing.Size(80, 14);
            this.lblTINNumber.TabIndex = 506;
            this.lblTINNumber.Text = "TIN Number : ";
            // 
            // txtTIN
            // 
            this.txtTIN.Location = new System.Drawing.Point(91, 98);
            this.txtTIN.MaxLength = 20;
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.Size = new System.Drawing.Size(228, 20);
            this.txtTIN.TabIndex = 507;
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(325, 43);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(64, 14);
            this.label105.TabIndex = 502;
            this.label105.Text = "Event Date";
            // 
            // gridIncumbentOfficer
            // 
            this.gridIncumbentOfficer.ColumnInfo = resources.GetString("gridIncumbentOfficer.ColumnInfo");
            this.gridIncumbentOfficer.Location = new System.Drawing.Point(126, 79);
            this.gridIncumbentOfficer.Name = "gridIncumbentOfficer";
            this.gridIncumbentOfficer.Rows.Count = 1;
            this.gridIncumbentOfficer.Rows.DefaultSize = 17;
            this.gridIncumbentOfficer.Size = new System.Drawing.Size(399, 72);
            this.gridIncumbentOfficer.StyleInfo = resources.GetString("gridIncumbentOfficer.StyleInfo");
            this.gridIncumbentOfficer.TabIndex = 505;
            this.gridIncumbentOfficer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridIncumbentOfficer_MouseClick);
            this.gridIncumbentOfficer.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridIncumbentOfficer_BeforeEdit);
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.Location = new System.Drawing.Point(13, 85);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(113, 14);
            this.label132.TabIndex = 504;
            this.label132.Text = "Incumbent Officers";
            // 
            // txtEventDate
            // 
            this.txtEventDate.Enabled = false;
            this.txtEventDate.Location = new System.Drawing.Point(391, 39);
            this.txtEventDate.Name = "txtEventDate";
            this.txtEventDate.Size = new System.Drawing.Size(134, 20);
            this.txtEventDate.TabIndex = 503;
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.ForeColor = System.Drawing.Color.Red;
            this.label104.Location = new System.Drawing.Point(330, 54);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(127, 14);
            this.label104.TabIndex = 501;
            this.label104.Text = "object is behid this group";
            this.label104.Visible = false;
            // 
            // pnlCompany
            // 
            this.pnlCompany.Controls.Add(this.txtCompanyName);
            this.pnlCompany.Controls.Add(this.txtCompanyCode);
            this.pnlCompany.Controls.Add(this.Label4);
            this.pnlCompany.Location = new System.Drawing.Point(11, 42);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(314, 30);
            this.pnlCompany.TabIndex = 5;
            this.pnlCompany.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCompany_Paint);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyName.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyName.Location = new System.Drawing.Point(79, 9);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(228, 20);
            this.txtCompanyName.TabIndex = 5;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            this.txtCompanyName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCompanyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyCode.Location = new System.Drawing.Point(79, 9);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(123, 20);
            this.txtCompanyCode.TabIndex = 6;
            this.txtCompanyCode.Visible = false;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(1, 9);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 17);
            this.Label4.TabIndex = 96;
            this.Label4.Text = "Company";
            // 
            // pnlIndividual
            // 
            this.pnlIndividual.Controls.Add(this.txtLastName);
            this.pnlIndividual.Controls.Add(this.txtFirstName);
            this.pnlIndividual.Controls.Add(this.label61);
            this.pnlIndividual.Location = new System.Drawing.Point(11, 43);
            this.pnlIndividual.Name = "pnlIndividual";
            this.pnlIndividual.Size = new System.Drawing.Size(315, 30);
            this.pnlIndividual.TabIndex = 129;
            this.pnlIndividual.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlIndividual_Paint);
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.SystemColors.Info;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(80, 9);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(110, 20);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLastName_KeyDown);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.SystemColors.Info;
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Location = new System.Drawing.Point(200, 9);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(108, 20);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirstName_KeyDown);
            this.txtFirstName.Leave += new System.EventHandler(this.txtFirstName_Leave);
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstName_KeyPress);
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.SystemColors.Control;
            this.label61.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.Location = new System.Drawing.Point(5, 12);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(69, 15);
            this.label61.TabIndex = 84;
            this.label61.Text = "Name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroupName.BackColor = System.Drawing.SystemColors.Info;
            this.txtGroupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroupName.Location = new System.Drawing.Point(101, 26);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(502, 20);
            this.txtGroupName.TabIndex = 1;
            // 
            // lvwBrowseCompany
            // 
            this.lvwBrowseCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwBrowseCompany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvwBrowseCompany.FullRowSelect = true;
            this.lvwBrowseCompany.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwBrowseCompany.Location = new System.Drawing.Point(-379, 113);
            this.lvwBrowseCompany.Name = "lvwBrowseCompany";
            this.lvwBrowseCompany.Size = new System.Drawing.Size(385, 87);
            this.lvwBrowseCompany.TabIndex = 136;
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
            // mnuDependents
            // 
            this.mnuDependents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUnblock,
            this.mnuCancelBlock,
            this.mnuCancelReservation});
            this.mnuDependents.Name = "mnuDependents";
            this.mnuDependents.Size = new System.Drawing.Size(175, 70);
            // 
            // mnuUnblock
            // 
            this.mnuUnblock.Name = "mnuUnblock";
            this.mnuUnblock.Size = new System.Drawing.Size(174, 22);
            this.mnuUnblock.Text = "Unblock Room";
            this.mnuUnblock.Click += new System.EventHandler(this.mnuUnblock_Click);
            // 
            // mnuCancelBlock
            // 
            this.mnuCancelBlock.Name = "mnuCancelBlock";
            this.mnuCancelBlock.Size = new System.Drawing.Size(174, 22);
            this.mnuCancelBlock.Text = "Cancel Blocking";
            this.mnuCancelBlock.Click += new System.EventHandler(this.mnuCancelBlock_Click);
            // 
            // mnuCancelReservation
            // 
            this.mnuCancelReservation.Name = "mnuCancelReservation";
            this.mnuCancelReservation.Size = new System.Drawing.Size(174, 22);
            this.mnuCancelReservation.Text = "Cancel Reservation";
            this.mnuCancelReservation.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.SystemColors.Control;
            this.label39.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(10, -2);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(169, 22);
            this.label39.TabIndex = 137;
            this.label39.Text = "Group Reservation";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CustomFormat = "MM/dd/yyyy";
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(407, 99);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(90, 20);
            this.dtpBirthDate.TabIndex = 138;
            // 
            // mnuContactPerson
            // 
            this.mnuContactPerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenListContact,
            this.mnuAddContact,
            this.mnuRemoveContact});
            this.mnuContactPerson.Name = "mnuContactPerson";
            this.mnuContactPerson.Size = new System.Drawing.Size(144, 70);
            // 
            // mnuOpenListContact
            // 
            this.mnuOpenListContact.Name = "mnuOpenListContact";
            this.mnuOpenListContact.Size = new System.Drawing.Size(143, 22);
            this.mnuOpenListContact.Text = "Add from list";
            this.mnuOpenListContact.Click += new System.EventHandler(this.mnuOpenListContact_Click);
            // 
            // mnuAddContact
            // 
            this.mnuAddContact.Name = "mnuAddContact";
            this.mnuAddContact.Size = new System.Drawing.Size(143, 22);
            this.mnuAddContact.Text = "Add New";
            this.mnuAddContact.Click += new System.EventHandler(this.mnuAddContact_Click);
            // 
            // mnuRemoveContact
            // 
            this.mnuRemoveContact.Name = "mnuRemoveContact";
            this.mnuRemoveContact.Size = new System.Drawing.Size(143, 22);
            this.mnuRemoveContact.Text = "Remove";
            this.mnuRemoveContact.Click += new System.EventHandler(this.mnuRemoveContact_Click);
            // 
            // mnuEventOfficers
            // 
            this.mnuEventOfficers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddEventOfficer,
            this.mnuRemoveEventOfficer});
            this.mnuEventOfficers.Name = "mnuEventOfficers";
            this.mnuEventOfficers.Size = new System.Drawing.Size(118, 48);
            // 
            // mnuAddEventOfficer
            // 
            this.mnuAddEventOfficer.Name = "mnuAddEventOfficer";
            this.mnuAddEventOfficer.Size = new System.Drawing.Size(117, 22);
            this.mnuAddEventOfficer.Text = "Add";
            this.mnuAddEventOfficer.Click += new System.EventHandler(this.mnuAddEventOfficer_Click);
            // 
            // mnuRemoveEventOfficer
            // 
            this.mnuRemoveEventOfficer.Name = "mnuRemoveEventOfficer";
            this.mnuRemoveEventOfficer.Size = new System.Drawing.Size(117, 22);
            this.mnuRemoveEventOfficer.Text = "Remove";
            this.mnuRemoveEventOfficer.Click += new System.EventHandler(this.mnuRemoveEventOfficer_Click);
            // 
            // mnuEMDActions
            // 
            this.mnuEMDActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddEMDAction,
            this.mnuRemoveEMDAction});
            this.mnuEMDActions.Name = "mnuEMDActions";
            this.mnuEMDActions.Size = new System.Drawing.Size(118, 48);
            // 
            // mnuAddEMDAction
            // 
            this.mnuAddEMDAction.Name = "mnuAddEMDAction";
            this.mnuAddEMDAction.Size = new System.Drawing.Size(117, 22);
            this.mnuAddEMDAction.Text = "Add";
            this.mnuAddEMDAction.Click += new System.EventHandler(this.mnuAddEMDAction_Click);
            // 
            // mnuRemoveEMDAction
            // 
            this.mnuRemoveEMDAction.Name = "mnuRemoveEMDAction";
            this.mnuRemoveEMDAction.Size = new System.Drawing.Size(117, 22);
            this.mnuRemoveEMDAction.Text = "Remove";
            this.mnuRemoveEMDAction.Click += new System.EventHandler(this.mnuRemoveEMDAction_Click);
            // 
            // pnlEstimateCharges
            // 
            this.pnlEstimateCharges.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlEstimateCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstimateCharges.Controls.Add(this.btnCancelEstimated);
            this.pnlEstimateCharges.Controls.Add(this.btnPrintEstimated);
            this.pnlEstimateCharges.Controls.Add(this.txtContingencyDetails);
            this.pnlEstimateCharges.Controls.Add(this.lbltest);
            this.pnlEstimateCharges.Controls.Add(this.cboShowAmount);
            this.pnlEstimateCharges.Controls.Add(this.label116);
            this.pnlEstimateCharges.Location = new System.Drawing.Point(246, 278);
            this.pnlEstimateCharges.Name = "pnlEstimateCharges";
            this.pnlEstimateCharges.Size = new System.Drawing.Size(410, 247);
            this.pnlEstimateCharges.TabIndex = 308;
            this.pnlEstimateCharges.Visible = false;
            this.pnlEstimateCharges.VisibleChanged += new System.EventHandler(this.pnlEstimateCharges_VisibleChanged);
            // 
            // btnCancelEstimated
            // 
            this.btnCancelEstimated.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelEstimated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelEstimated.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEstimated.Location = new System.Drawing.Point(248, 193);
            this.btnCancelEstimated.Name = "btnCancelEstimated";
            this.btnCancelEstimated.Size = new System.Drawing.Size(66, 36);
            this.btnCancelEstimated.TabIndex = 507;
            this.btnCancelEstimated.Text = "Cancel";
            this.btnCancelEstimated.UseVisualStyleBackColor = false;
            this.btnCancelEstimated.Click += new System.EventHandler(this.btnCancelEstimated_Click);
            // 
            // btnPrintEstimated
            // 
            this.btnPrintEstimated.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrintEstimated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintEstimated.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintEstimated.Location = new System.Drawing.Point(320, 193);
            this.btnPrintEstimated.Name = "btnPrintEstimated";
            this.btnPrintEstimated.Size = new System.Drawing.Size(66, 36);
            this.btnPrintEstimated.TabIndex = 506;
            this.btnPrintEstimated.Text = "OK";
            this.btnPrintEstimated.UseVisualStyleBackColor = false;
            this.btnPrintEstimated.Click += new System.EventHandler(this.btnPrintEstimated_Click);
            // 
            // txtContingencyDetails
            // 
            this.txtContingencyDetails.Enabled = false;
            this.txtContingencyDetails.Location = new System.Drawing.Point(172, 71);
            this.txtContingencyDetails.Multiline = true;
            this.txtContingencyDetails.Name = "txtContingencyDetails";
            this.txtContingencyDetails.Size = new System.Drawing.Size(214, 102);
            this.txtContingencyDetails.TabIndex = 505;
            // 
            // cboShowAmount
            // 
            this.cboShowAmount.BackColor = System.Drawing.SystemColors.Window;
            this.cboShowAmount.Enabled = false;
            this.cboShowAmount.ItemHeight = 14;
            this.cboShowAmount.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboShowAmount.Location = new System.Drawing.Point(172, 31);
            this.cboShowAmount.Name = "cboShowAmount";
            this.cboShowAmount.Size = new System.Drawing.Size(127, 22);
            this.cboShowAmount.TabIndex = 194;
            this.cboShowAmount.TabStop = false;
            this.cboShowAmount.Text = "True";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(24, 74);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(140, 14);
            this.label117.TabIndex = 504;
            this.label117.Text = "Contingency text details";
            // 
            // mnuIncumbentOfficers
            // 
            this.mnuIncumbentOfficers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIncumbentAdd,
            this.mnuIncumbentRemove});
            this.mnuIncumbentOfficers.Name = "mnuIncumbentOfficers";
            this.mnuIncumbentOfficers.Size = new System.Drawing.Size(118, 48);
            // 
            // mnuIncumbentAdd
            // 
            this.mnuIncumbentAdd.Name = "mnuIncumbentAdd";
            this.mnuIncumbentAdd.Size = new System.Drawing.Size(117, 22);
            this.mnuIncumbentAdd.Text = "Add";
            this.mnuIncumbentAdd.Click += new System.EventHandler(this.mnuIncumbentAdd_Click);
            // 
            // mnuIncumbentRemove
            // 
            this.mnuIncumbentRemove.Name = "mnuIncumbentRemove";
            this.mnuIncumbentRemove.Size = new System.Drawing.Size(117, 22);
            this.mnuIncumbentRemove.Text = "Remove";
            this.mnuIncumbentRemove.Click += new System.EventHandler(this.mnuIncumbentRemove_Click);
            // 
            // pnlContactList
            // 
            this.pnlContactList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContactList.Controls.Add(this.button2);
            this.pnlContactList.Controls.Add(this.btnOk);
            this.pnlContactList.Controls.Add(this.label136);
            this.pnlContactList.Controls.Add(this.gridContactList);
            this.pnlContactList.Location = new System.Drawing.Point(326, 44);
            this.pnlContactList.Name = "pnlContactList";
            this.pnlContactList.Size = new System.Drawing.Size(343, 247);
            this.pnlContactList.TabIndex = 1;
            this.pnlContactList.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(174, 206);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(13, 5);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(64, 14);
            this.label136.TabIndex = 1;
            this.label136.Text = "Contact List";
            // 
            // gridContactList
            // 
            this.gridContactList.ColumnInfo = resources.GetString("gridContactList.ColumnInfo");
            this.gridContactList.ExtendLastCol = true;
            this.gridContactList.Location = new System.Drawing.Point(15, 23);
            this.gridContactList.Name = "gridContactList";
            this.gridContactList.Rows.Count = 1;
            this.gridContactList.Rows.DefaultSize = 17;
            this.gridContactList.Size = new System.Drawing.Size(313, 177);
            this.gridContactList.StyleInfo = resources.GetString("gridContactList.StyleInfo");
            this.gridContactList.TabIndex = 0;
            this.gridContactList.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridContactList_BeforeEdit);
            // 
            // ofdUpload
            // 
            this.ofdUpload.FileName = "openFileDialog1";
            // 
            // GroupReservationUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(804, 582);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.lvwBrowseCompany);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.lvwBrowseGuestName);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.txtAccountType);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlFolio);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.Label43);
            this.Controls.Add(this.pnlNew);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.Label40);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtDepartureDate);
            this.Controls.Add(this.tabFolio_);
            this.Controls.Add(this.pnlEstimateCharges);
            this.Controls.Add(this.txtbreakfast);
            this.Controls.Add(this.pnlContactList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupReservationUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Group Folio";
            this.Load += new System.EventHandler(this.GroupReservationUI_Load);
            this.Activated += new System.EventHandler(this.GroupReservationUI_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GroupReservationUI_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupReservationUI_FormClosing);
            this.Resize += new System.EventHandler(this.GroupReservationUI_Resize);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupReservationUI_MouseMove);
            this.LocationChanged += new System.EventHandler(this.GroupReservationUI_LocationChanged);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFolio)).EndInit();
            this.pnlDate.ResumeLayout(false);
            this.tabFoodBev_.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.grpMealDetails.ResumeLayout(false);
            this.grpMealDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tblFoodBevOthers.ResumeLayout(false);
            this.tblFoodBevOthers.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMealPax)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaxAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMealAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMealLiveIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMealLiveOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMealItems)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabRooms_.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFunctionRooms)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.grpDependentsRoom.ResumeLayout(false);
            this.grpDependentsRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuaranteedRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuaranteedPax)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBlockedRooms)).EndInit();
            this.tabWedding_.ResumeLayout(false);
            this.grpNotesRemarks.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpEventDetails.ResumeLayout(false);
            this.grpEventDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventDetails)).EndInit();
            this.grpRequirements.ResumeLayout(false);
            this.grpRequirements.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReqSchedules)).EndInit();
            this.mnuTreeRequirements.ResumeLayout(false);
            this.tabEventDetails_.ResumeLayout(false);
            this.groupContacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPaxLiveOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaxGuaranteed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPaxLiveIn)).EndInit();
            this.grpBillingDeposits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDeposits)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBilling)).EndInit();
            this.TabRecurringCharge.ResumeLayout(false);
            this.TabRecurringCharge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPackageRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecurringCharges)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecurredCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTax)).EndInit();
            this.tabPackage.ResumeLayout(false);
            this.tabPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHotelPromos)).EndInit();
            this.tabPrivilege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioPrivileges)).EndInit();
            this.gbxApplyPrivileges.ResumeLayout(false);
            this.gbxApplyPrivileges.PerformLayout();
            this.tabBooking.ResumeLayout(false);
            this.tabBooking.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoofDays)).EndInit();
            this.tabFolio_.ResumeLayout(false);
            this.tabBillingInfo.ResumeLayout(false);
            this.tabBillingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBillingInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactionCodes)).EndInit();
            this.tabRoomRequirements.ResumeLayout(false);
            this.tabAmmendments.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemChanges)).EndInit();
            this.grpNewAmendments.ResumeLayout(false);
            this.grpNewAmendments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAmendmentSchedules)).EndInit();
            this.pnlAmendments.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid2)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAmmendments)).EndInit();
            this.panel7.ResumeLayout(false);
            this.tabEventRequirements.ResumeLayout(false);
            this.tabEndorsement.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupForEMDAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEMDActions)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupReservationFee.ResumeLayout(false);
            this.groupReservationFee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractAmount)).EndInit();
            this.tabCancellation.ResumeLayout(false);
            this.tabCancellation.PerformLayout();
            this.tabEventAttendance.ResumeLayout(false);
            this.tabEventAttendance.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudActualAttendees)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVisitors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalBased)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeignBased)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudForeign)).EndInit();
            this.pnlNew.ResumeLayout(false);
            this.pnlFolio.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventOfficer)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIncumbentOfficer)).EndInit();
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            this.pnlIndividual.ResumeLayout(false);
            this.pnlIndividual.PerformLayout();
            this.mnuDependents.ResumeLayout(false);
            this.mnuContactPerson.ResumeLayout(false);
            this.mnuEventOfficers.ResumeLayout(false);
            this.mnuEMDActions.ResumeLayout(false);
            this.pnlEstimateCharges.ResumeLayout(false);
            this.pnlEstimateCharges.PerformLayout();
            this.mnuIncumbentOfficers.ResumeLayout(false);
            this.pnlContactList.ResumeLayout(false);
            this.pnlContactList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContactList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		#region " VARIABLES "

        private bool lIsEventManagementDisabled = false;
		private bool lIsChildFolioViewed = false;
		private string lChildFolioStatus;
		private string lGroupFolioStatus;

		private string lFolioNo;
		private string lEventNo;
		private Company loCompany = new Company();
		private Agent loAgent = new Agent();
		private Folio loFolio;
		private DateTime lToDate;
		private DateTime lFromDate;
		private decimal lBalance;

		private RoomEventFacade loRoomEventFacade = new RoomEventFacade();
		private ScheduleFacade loScheduleFacade = new ScheduleFacade();
		private CompanyFacade loCompanyFacade = new CompanyFacade();
		private AgentFacade loAgentFacade;
		private FolioFacade loFolioFacade = new FolioFacade();
		private EventFacade loEventFacade = new EventFacade();

		private DataReaderBinder loDataReaderBinder = new DataReaderBinder();
		private FormToObjectInstanceBinder loFormToObjectInstance = new FormToObjectInstanceBinder();
		private Sequence loSequence = new Sequence();

		private C1.Win.C1FlexGrid.C1FlexGrid lSubFolioGrid;
		private string lFlag;


		private string lMessage;

		private string lCode;
		private string lCharge;

		private bool lEdit;

		private string lPackageID;
		private string lDaysApplied;
		private string lPackageName;


		private int lItemIndex;
		private string lTranCode;

		#endregion

		#region "Shared Variables/Methods"
		private static AccountType mAccountType;
        public static AccountType ACCOUNT_TYPE   
		{
			set
			{
				mAccountType = value;
			}
		}
		private static ArrayList tmpFolio = new ArrayList();
		public static void AddTempFolio(string val)
		{
			tmpFolio.Add(val);
		}
		private static string mcompanyid;
		public static string companyid
		{
			set
			{
				mcompanyid = value;
			}
		}
		#endregion

		#region "Constructors"

        //CONSTRUCTOR FOR REINSTATED RESERVATION
        private bool isReinstated = false;
        private String[] aReservationStatus = { "TENTATIVE", "WAIT LIST", "CONFIRMED", "ONGOING", "CLOSED", "CANCELLED", "NO SHOW" };
        public GroupReservationUI(Folio pFolio)
        {
            InitializeComponent();
            loadGroupBookingDropDown();
            isReinstated = true;

            lGroupFolioStatus = "Old";
            loFolio = pFolio;
            lFolioNo = pFolio.FolioID;
            loFolio.Status = "TENTATIVE";
            //lSubFolioGrid = pGridFolios;
            FacadeDeclarations();

            Control myForm = this;
            FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
            mcompanyid = loFolio.CompanyID;
            grdFolio.AllowEditing = false;
            txtGroupRemarks.Text = "Reinstated from " + loFolio.FolioID + " : " + loFolio.Remarks;

            //GetChildFolios();
            switch (mAccountType)
            {
                case AccountType.Corporate:
                case AccountType.Personal:

                    if (mcompanyid.StartsWith("G"))
                    {
                        loCompany = new Company();

                        rdbCompany.Checked = true;
                        loCompany = loCompanyFacade.getCompanyAccount(mcompanyid);
                        loFolio.Company = loCompany;
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    else
                    {
                        Guest _oGuest = new Guest();

                        rdbIndividual.Checked = true;
                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(mcompanyid);

                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    break;
                //case "AGENT":

                //    break;
            }
            loAgent = new Agent();

            if (txtagentid.Text != "" && txtagentid.Text != "FILLER")
            {
                loAgent = loAgentFacade.getAgentInfo(int.Parse(txtagentid.Text));
                txtAgentname.Text = loAgent.Tables[0].Rows[0]["AgentName"].ToString();
            }
            else
            {
                txtagentid.Text = "";
            }


            pnlNew.Visible = true;
            lFlag = "Edit";
            loadFolioRecurringCharges();
            loadEvent();
            lGroupFolioStatus = "New";
            lFlag = "New";

            KeypressTextboxHandler(this, false);
            txtCompanyId_TextChanged();

            loadPackages();

            loadCountries();
            //loadRooms();
            getCharges(grdRecurringCharges);
            getCharges(gridTransactionCodes);

            LoadFolioRouting(loFolio);
            loadFolioPrivileges();
            loadFolioPackage();
            //loadContractAmendments();

            grdFolio.Sort(SortFlags.Ascending, 2, 3);
            gridTransactionCodes_Click(this, new EventArgs());

            loSequence = new Sequence();
            //lFolioNo = loSequence.getSequenceId("F-", 12, "seq_folio");
            
            txtFolioID.Text = "AUTO";
            //loFolio.FolioID = lFolioNo;
            dtpFromDate.Text = GlobalVariables.gAuditDate;
            dtpTodate.Text = GlobalVariables.gAuditDate;
        
        }

		//CONSTRUCTOR FOR A NEW RESERVATION
		public GroupReservationUI(C1.Win.C1FlexGrid.C1FlexGrid pGridFolios)
		{
			InitializeComponent();

            loadGroupBookingDropDown();

			loSequence = new Sequence();
			loFolioFacade = new FolioFacade();
            loFolio = new Folio();
			// lFolioNo = loSequence.getSequenceId("F-", 12, "seq_folio");
			txtFolioID.Text = lFolioNo;

		
            txtCreateTime.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Now);
            txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;

			cboStatus.Text = "TENTATIVE";
            cboAccountType.Text = AccountType.Corporate.ToString().ToUpper();
			cboPayment_Mode.Text = "CASH";
			cboPurpose.Text = "BUSINESS";
            rdbCompany.Checked = true;

			lGroupFolioStatus = "New";
			lSubFolioGrid = pGridFolios;
			pnlNew.Visible = true;
			lFlag = "New";
			
            KeypressTextboxHandler(this, false);
            getCharges(grdRecurringCharges);
            getCharges(gridTransactionCodes);
            loadCountries();

            //>>by Genny: Apr. 30, 2008
            //get all Room Types
            RoomType _oRoomType = new RoomType();
            RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();
            _oRoomType = (RoomType)_oRoomTypeFacade.loadObject();

            DataView _dtvRoomTypes = _oRoomType.Tables[0].DefaultView;
            _dtvRoomTypes.RowStateFilter = DataViewRowState.OriginalRows;
            _dtvRoomTypes.RowFilter = "roomTypeCode not like '*FUNCTION*'";
            foreach (DataRowView _dRow in _dtvRoomTypes)
            {
                string[] items ={ _dRow["roomtypecode"].ToString(), "0", "0", "0", "0", "0", "0", "0" };
                gridRooms.AddItem(items);
            }
            grdFolio.Sort(SortFlags.Ascending, 2, 3);//<<
        }

		//CONSTRUCTOR FOR A PREVIOUSLY CREATED RESERVATION
		private void FacadeDeclarations()
		{
			loFolioFacade = new FolioFacade();
			loScheduleFacade = new ScheduleFacade();
			loRoomEventFacade = new RoomEventFacade();
			loCompanyFacade = new CompanyFacade();
			loAgentFacade = new AgentFacade();
		}

        //constructor from the Group List
		public GroupReservationUI(string pFolioID, C1.Win.C1FlexGrid.C1FlexGrid pGridFolios)
		{
			InitializeComponent();

            loadGroupBookingDropDown();

            lGroupFolioStatus = "Old";
            loFolio = new Folio();
			lFolioNo = pFolioID;
			lSubFolioGrid = pGridFolios;
			FacadeDeclarations();


			loFolio = loFolioFacade.GetFolio(pFolioID);
			Control myForm = this;
			FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
			mcompanyid = loFolio.CompanyID;
			grdFolio.AllowEditing = false;
            txtGroupRemarks.Text = loFolio.Remarks;

			GetChildFolios();
			switch (mAccountType)
			{
				case AccountType.Corporate:

					if (mcompanyid.StartsWith("G"))
					{
						loCompany = new Company();

                        rdbCompany.Checked = true;
                        loCompany = loCompanyFacade.getCompanyAccount(mcompanyid);
                        loFolio.Company = loCompany;
						Control frm = this;
						FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
					}
					else
					{
						Guest _oGuest = new Guest();

                        rdbIndividual.Checked = true;
                        loGuestFacade = new GuestFacade();
						_oGuest = loGuestFacade.getGuestRecord(mcompanyid);

						Control frm = this;
						FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
					}
					break;
                //case "AGENT":

                //    break;
			}
			loAgent = new Agent();

			if (txtagentid.Text != "" && txtagentid.Text != "FILLER")
			{
				loAgent = loAgentFacade.getAgentInfo(int.Parse(txtagentid.Text));
				txtAgentname.Text = loAgent.Tables[0].Rows[0]["AgentName"].ToString();
			}
			else
			{
				txtagentid.Text = "";
			}

			btnEdit.Visible = true;
			lFlag = "Edit";
			KeypressTextboxHandler(this, true);
			txtCompanyId_TextChanged();

            loadPackages();
            loadFolioRecurringCharges();
            loadCountries();
            loadContractAmendments();

            //loadRooms();
            getCharges(grdRecurringCharges);
            getCharges(gridTransactionCodes);
            LoadFolioRouting(loFolio);
            loadFolioPrivileges();
            loadFolioPackage();
            grdFolio.Sort(SortFlags.Ascending, 2, 3);
            gridTransactionCodes_Click(this, new EventArgs());
		}

        //constructor from the Guest List
        public GroupReservationUI(string pFolioID)
        {
            InitializeComponent();
            string test = cboSource.Text;
            loadGroupBookingDropDown();
      
            lGroupFolioStatus = "Old";
            loFolio = new Folio();
            lFolioNo = pFolioID;
            //lSubFolioGrid = pGridFolios;
            FacadeDeclarations();

            loFolio = loFolioFacade.GetFolio(pFolioID);
            Control myForm = this;
            FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
            mcompanyid = loFolio.CompanyID;
            grdFolio.AllowEditing = false;
            txtGroupRemarks.Text = loFolio.Remarks;

            GetChildFolios();
            switch (mAccountType)
            {
                case AccountType.Corporate:
                case AccountType.Personal:

                    if (mcompanyid.StartsWith("G"))
                    {

                        loCompany = new Company();
                        rdbCompany.Checked = true;
                        loCompany = loCompanyFacade.getCompanyAccount(mcompanyid);
                        loFolio.Company = loCompany;
                        cboAccountType.SelectedItem = loFolio.AccountType;
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    else
                    {
                        Guest _oGuest = new Guest();

                        rdbIndividual.Checked = true;
                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(mcompanyid);

                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    break;
                //case "AGENT":

                //    break;
            }
            loAgent = new Agent();

            if (txtagentid.Text != "" && txtagentid.Text != "FILLER")
            {
                loAgent = loAgentFacade.getAgentInfo(int.Parse(txtagentid.Text));
                txtAgentname.Text = loAgent.Tables[0].Rows[0]["AgentName"].ToString();
            }
            else
            {
                txtagentid.Text = "";
            }

            btnEdit.Visible = true;
            lFlag = "Edit";
            KeypressTextboxHandler(this, true);
            txtCompanyId_TextChanged();

            loadPackages();
            loadFolioRecurringCharges();
            loadCountries();
            //loadRooms();
            getCharges(grdRecurringCharges);
            getCharges(gridTransactionCodes);

            LoadFolioRouting(loFolio);
            loadFolioPrivileges();
            loadFolioPackage();
            loadContractAmendments();

            grdFolio.Sort(SortFlags.Ascending, 2, 3);
            gridTransactionCodes_Click(this, new EventArgs());
        }

        private void loadFolio()
        {
            loFolio = loFolioFacade.GetFolio(txtFolioID.Text);
            Control myForm = this;
            
            FormToObjectInstanceBinder.BindInputControlToObject(ref myForm, loFolio);
            mcompanyid = loFolio.CompanyID;
            grdFolio.AllowEditing = false;
            txtGroupRemarks.Text = loFolio.Remarks;

            GetChildFolios();

            lGroupFolioStatus = "Old";
            switch (mAccountType)
            {
                case AccountType.Corporate:

                    if (mcompanyid.StartsWith("G"))
                    {
                        loCompany = new Company();

                        loCompany = loCompanyFacade.getCompanyAccount(mcompanyid);
                        rdbCompany.Checked = true;
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);
                    }
                    else
                    {
                        Guest _oGuest = new Guest();

                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(mcompanyid);
                        rdbIndividual.Checked = true;

                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loGuestFacade);
                    }
                    break;
            }
            loAgent = new Agent();

            if (txtagentid.Text != "" && txtagentid.Text != "FILLER")
            {
                loAgent = loAgentFacade.getAgentInfo(int.Parse(txtagentid.Text));
                txtAgentname.Text = loAgent.Tables[0].Rows[0]["AgentName"].ToString();
            }
            else
            {
                txtagentid.Text = "";
            }

            btnEdit.Visible = true;
            lFlag = "Edit";
            KeypressTextboxHandler(this, true);
            txtCompanyId_TextChanged();

            loadPackages();
            loadFolioRecurringCharges();
            //loadRooms();
            getCharges(grdRecurringCharges);
            getCharges(gridTransactionCodes);
            LoadFolioRouting(loFolio);
            loadEventBookingInfo();
            loadFolioPackage();
            setButtons();
            txtGroupRemarks.Text = loFolio.Remarks;
            grdFolio.Sort(SortFlags.Ascending, 2, 3);
            
        }

		#endregion

        //Gene - 9/8/2011
        //private TextBox lSetup = new TextBox();
        //private TextBox lActivity = new TextBox();
        private ComboBox lSetup = new ComboBox();
        private ComboBox lActivity = new ComboBox();

        private ComboBox lPersonType = new ComboBox();
        private void loadGroupBookingDropDown()
        {
            try
            {
                AutoCompleteStringCollection values;
                GroupBookingDropDownFacade oGroupBookingFacade = new GroupBookingDropDownFacade();

                DataTable _oDtDropDownValues = oGroupBookingFacade.getDetailsForDropDown();
                DataView _oDataView = _oDtDropDownValues.DefaultView;

                //booking source
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'BookingSource'";

                if (_oDataView.Count > 0)
                {
                    this.cboSource.Items.Clear();
                    values = new AutoCompleteStringCollection();

                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                    this.cboSource.DataSource = values;
                }

                //setup
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'FoodSetup'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                }
                this.txtFoodSetup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.txtFoodSetup.AutoCompleteCustomSource = values;
                this.txtFoodSetup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.txtFoodSetup.Multiline = false;

                //Gene - 9/8/2011
                //this.lSetup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //this.lSetup.AutoCompleteCustomSource = values;
                //this.lSetup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.lSetup.DataSource = _oDataView.ToTable();
                this.lSetup.ValueMember = "Value";
                this.lSetup.DisplayMember = "Value";
                this.lSetup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.lSetup.AutoCompleteSource = AutoCompleteSource.ListItems;

                //persontype
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'PersonType'";
                lPersonType.DropDownStyle = ComboBoxStyle.DropDownList;
                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        lPersonType.Items.Add(_dRowView["Value"].ToString());
                    }
                }

                //letterOfProposal
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'LetterOfProposal'";
                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        cboLetterOfProposal.Items.Add(_dRowView["Value"].ToString());
                    }
                }

                //billing arrangement
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'BookingSource'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                }
                this.txtBillingArrangement.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.txtBillingArrangement.AutoCompleteCustomSource = values;
                this.txtBillingArrangement.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //if (values.Count > 0)
                //{
                //    txtBillingArrangement.Multiline = false;
                //}
                //else
                //{
                //    this.txtBillingArrangement.Multiline = true;
                //}

                /* FP-SCR-00140 #1 [07.23.2010]
                 * added for auto-complete of Activity field in the grid function room */
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'Activity'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                }

                //Gene - 9/8/2011
                //lActivity.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //lActivity.AutoCompleteCustomSource = values;
                //lActivity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                //Gene - 9/8/2011
                lActivity.DataSource = _oDataView.ToTable();
                lActivity.ValueMember = "Value";
                lActivity.DisplayMember = "Value";
                lActivity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                lActivity.AutoCompleteSource = AutoCompleteSource.ListItems;
                /* end of Activity auto complete */

                /* added for auto-complete of Account Type */
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'AccountType'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    cboAccountType.Items.Clear();
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                    cboAccountType.DataSource = values;
                }
                /* end of auto-complete of account type */

                /* added for auto-complete of Payment Mode */
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'PaymentMode'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    cboPayment_Mode.Items.Clear();
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                }
                cboPayment_Mode.DataSource = values;
                /* end of auto-complete of payment mode */

                /* added for auto-complete of Market Segment */
                _oDataView.RowStateFilter = DataViewRowState.OriginalRows;
                _oDataView.RowFilter = "fieldname = 'MarketSegment'";
                values = new AutoCompleteStringCollection();

                if (_oDataView.Count > 0)
                {
                    cboPurpose.Items.Clear();
                    foreach (DataRowView _dRowView in _oDataView)
                    {
                        values.Add(_dRowView["Value"].ToString());
                    }
                    cboPurpose.DataSource = values;
                }
                /* end of auto-complete of market segment */
            }
            catch
            {
            }
        }

		#region " METHODS "

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

        //load Counties & Nationalities list
        private void loadCountries()
        {
            AutoCompleteStringCollection _counties = new AutoCompleteStringCollection();
            AutoCompleteStringCollection _nationalities = new AutoCompleteStringCollection();

            foreach (Country _oCountry in GlobalVariables.gCountryList)
            {
                _counties.Add(_oCountry.CountryName);
            }

            this.txtCountry1.AutoCompleteCustomSource = _counties;
        }

		//private void GroupReservationUI_Closed()
		//{
		//    if (lSubFolioGrid != null)
		//    {
		//        //ReservationsFacade _oReservationFacade = new ReservationsFacade();
		//        //C1.Win.C1FlexGrid.C1FlexGrid _grid;
		//        //_grid = lSubFolioGrid ;

		//        //lSubFolioGrid.Rows.Count = 1;
		//        GroupReservationListUI _oGroupReservationList = new GroupReservationListUI();
		//        _oGroupReservationList.MdiParent = this.MdiParent;
		//        _oGroupReservationList.Show();
		//    }
		//}

		private void btnEdit_Click()
		{
			lEdit = true;
            //panelNew.Visible = true;
            //btnNew.Enabled = true;
            //btnEdit.SendToBack();
            btnEdit.Visible = false;
			KeypressTextboxHandler(this, false);
            txtCreateTime.Enabled = false;
			grdFolio.Enabled = true;
            //grdFolio.AllowEditing = true;
		}

		private void unselectListviewItems()
		{
			foreach (C1.Win.C1FlexGrid.Row _row in grdFolio.Rows)
			{
				if (_row.Index != 0)
				{
					grdFolio.Rows[_row.Index].Selected = false;
				}
			}
		}

		public void NewEntry()
		{
			newFolio();
		}

		public void SaveEntry()
		{
			btnSave_Click();
		}

		#endregion

		#region " EVENTS "

		private void btnBrowseAccount_Click(System.Object sender, System.EventArgs e)
		{
			browseAccount();
		}

		private void btnNew_Click(System.Object sender, System.EventArgs e)
		{
			newFolio();
		}

		private void lvwFolio_DoubleClick(object sender, System.EventArgs e)
		{
			lvwFolio_DoubleClick();
		}

		private void GroupBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (lChildFolioStatus == "")
			{
				buttonState(false, false, false, false, false);
			}
		}

		private void lvwFolio_Click(object sender, System.EventArgs e)
		{
			try
			{
				lFolioNo = grdFolio.GetDataDisplay(grdFolio.Row, 0);
				lChildFolioStatus = grdFolio.GetDataDisplay(grdFolio.Row, 7);
			}
			catch { }
		}

		private void btnSave_Click(System.Object sender, System.EventArgs e)
		{
            
            //jc 9.25.09
            MySqlTransaction _oTrans = GlobalVariables.gPersistentConnection.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                if (!string.IsNullOrEmpty(loFolio.FolioID))
                {
                    GlobalFunctions.protectFolioID(loFolio.FolioID, ref _oTrans);           //jc 9.25.09
                }
                btnSave_Click();
                //jc 9.25.09
                //edited
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in saving folio.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _oTrans.Commit(); //jc 9.5.09
            }

		}

		private void btnCheckIN_Click(System.Object sender, System.EventArgs e)
		{
			btnCheckIN_Click();
		}

		private void btnNoSHow_Click(System.Object sender, System.EventArgs e)
		{
		}

		private void btnConfirm_Click(System.Object sender, System.EventArgs e)
		{
            btnConfirm_Click();
		}

		private void btnCheckOUt_Click(System.Object sender, System.EventArgs e)
		{
			btnCheckOUt_Click();
		}

		private void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			btnCancel_Click();
		}

		private void btnDelete_Click(System.Object sender, System.EventArgs e)
		{
			btnDelete_Click();
		}

		private void btnCancelReservation_Click(System.Object sender, System.EventArgs e)
		{
			btnCancelReservation_Click();
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
                this.dtpPackageDateFrom.Value = _oFolioPackage.DateFrom;
                this.dtpPackageDateTo.Value = _oFolioPackage.DateTo;

                i++;
            }
        }

        IList<PackageHeader> loPackages;
        PackageFacade loPackageFacade;
		private void loadPackages()
		{
            loPackageFacade = new PackageFacade();
            loPackages = loPackageFacade.getApplicablePackages();

            this.grdHotelPromos.Rows.Count = 1;
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

            //FolioDAO _oFolioDAO = new FolioDAO();
            //DataTable _dt = _oFolioDAO.GetPackages();
            //DataRow _dr;
            //grdPackages.Rows.Count = 1;

            //foreach (DataRow _tempLoopVarDataRow in _dt.Rows)
            //{
            //    _dr = _tempLoopVarDataRow;
            //    grdPackages.Rows.Count++;
            //    grdPackages.SetData(grdPackages.Rows.Count - 1, 0, _dr["description"].ToString());
            //    grdPackages.SetData(grdPackages.Rows.Count - 1, 1, _dr["fromdate"].ToString());
            //    grdPackages.SetData(grdPackages.Rows.Count - 1, 2, _dr["todate"].ToString());
            //    grdPackages.SetData(grdPackages.Rows.Count - 1, 3, _dr[0]);
            //    grdPackages.SetData(grdPackages.Rows.Count - 1, 4, _dr["daysApplied"]);
            //}
		}

        DataTable loUserList;

		private void GroupReservationUI_Load()
		{
            DisableControls(this, true);
            
            switch (lGroupFolioStatus)
			{
				case "New":

                    //panelNew.Visible = true;
                    pnlAmendments.Enabled = false;
					pnlStatus.Visible = false;
                    grpMealDetails.Enabled = false;
                    grpNewAmendments.Enabled = false;
                    btnPrintEstimatedCharges.Enabled = false;
					break;

				case "Old":
					loadRoomRequirements();
                    grpNewAmendments.Enabled = false;
                    btnSaveAmmendment.Enabled = false;
					break;
			}

			KeypressTextboxHandler(this, true);
			this.Top = 0;
			this.Left = 0;

			//>>by Genny: Apr. 28, 2008
			// get all Sales Executive
			User _oSalesExecUser = new User();
			UserFacade _oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
            // Daniel Balagosa
            // June 21, 2012
            // Commented below line to replace query with user roles
			//_oSalesExecUser = _oUserFacade.GetUsers();
            _oSalesExecUser = _oUserFacade.GetUserRolesAll();
            
			DataView _dtvSalesExec = _oSalesExecUser.Tables[0].DefaultView;
			_dtvSalesExec.RowStateFilter = DataViewRowState.OriginalRows;
			_dtvSalesExec.RowFilter = "Department like '100%' and rolename like '%marketing%'";

			foreach (DataRowView dRow in _dtvSalesExec)
			{
				this.cboSales_Executive.Items.Add(dRow["UserId"].ToString());
			}

            txtCreateTime.Text = DateTime.Parse(txtCreateTime.Text).ToString("dd-MMM-yyyy");
            grdFolio.Sort(SortFlags.Ascending, 2, 3);


            //check if Food and Bev Other details are disabled or not
            if (bool.Parse(ConfigVariables.gDisableFoodOtherDetails) == true)
            {
                tblFoodBevOthers.Visible = false;
            }
        }

        private void txtCompanyId_TextChanged()
        {
            if (txtcompanyid.Text != "")
            {
                lvwBrowseCompany.Hide();
                lvwBrowseGuestName.Hide();
            }
            else
            {
                txtCompanyName.Text = "";
                txtLastName.Text = "";
                txtFirstName.Text = "";
            }

            //if (lFlag != "New")
            //{
            try
            {
                if (txtcompanyid.Text != "")
                {
                    EventContact oEventContact = new EventContact();
                    if (rdbCompany.Checked)
                    {
                        loCompanyFacade = new CompanyFacade();

                        loCompany = loCompanyFacade.getCompanyAccount(txtcompanyid.Text);
                        loCompany.CreateTime = DateTime.Parse(txtCreateTime.Text);
                        Control frm = this;
                        FormToObjectInstanceBinder.BindInputControlToObject(ref frm, loCompany);

                        loadCompanyPrivileges();
                        txtTotal_Sales_Contribution.Text = double.Parse(txtTotal_Sales_Contribution.Text).ToString("N");
                        txtTHRESHOLD_VALUE.Text = double.Parse(txtTHRESHOLD_VALUE.Text).ToString("N");
                        //txtCreatedBy.Text = GlobalVariables.gLoggedOnUser;

                    }
                    else
                    {
                        Guest _oGuest = new Guest();
                        loGuestFacade = new GuestFacade();
                        _oGuest = loGuestFacade.getGuestRecord(txtcompanyid.Text);
                        loadCompanyPrivileges();

                        txtLastName.Text = _oGuest.LastName;
                        txtFirstName.Text = _oGuest.FirstName;
                        //txtMiddleName.Text = _oGuest.MiddleName;
                        txtTHRESHOLD_VALUE.Text = _oGuest.THRESHOLD_VALUE.ToString("###,##0.#0");
                        txtTotal_Sales_Contribution.Text = _oGuest.TOTAL_SALES_CONTRIBUTION.ToString("###,##0.#0");
                        txtAccount_Type.Text = _oGuest.ACCOUNT_TYPE;
                        txtContactPerson.Text = _oGuest.Title + " " + _oGuest.FirstName + " " + _oGuest.LastName;
                        txtContactNumber1.Text = _oGuest.TelephoneNo;
                        txtContactNumber2.Text = _oGuest.FaxNo;
                        txtContactNumber3.Text = _oGuest.MobileNo;
                        txtStreet1.Text = _oGuest.Street;
                        txtCity1.Text = _oGuest.City;
                        txtCountry1.Text = _oGuest.Country;
                        txtZip1.Text = _oGuest.Zip;

                    }

                    loFolio.ContactPersons = oEventContact.getEventContacts(loFolio.FolioID, loFolio.CompanyID);
                    loadContactPersons();
                }
            }
            catch { }
            //}
            //else
            //{
            //if (txtcompanyid.Text != "")
            //{
            //    Guest _oGuest = new Guest();
            //    loGuestFacade = new GuestFacade();
            //    _oGuest = loGuestFacade.getGuestRecord(txtcompanyid.Text);

            //    txtLastName.Text = _oGuest.LastName;
            //    txtFirstName.Text = _oGuest.FirstName;
            //    //txtMiddleName.Text = _oGuest.MiddleName;
            //    txtTotal_Sales_Contribution.Text = _oGuest.TOTAL_SALES_CONTRIBUTION.ToString("###,##0.#0");
            //    txtAccount_Type.Text = _oGuest.ACCOUNT_TYPE;
            //}
            //loadCompanyPrivileges();
            //}
        }

		private GuestFacade loGuestFacade;
		private void loadCompanyPrivileges()
		{
			if (this.txtcompanyid.Text == "")
			{
				return;
			}

            //if checked is individual
            if (rdbIndividual.Checked == true)
            {
                loGuestFacade = new GuestFacade();
                loGuestFacade.getAccountPrivileges(txtcompanyid.Text, ref oGuest);

                foreach (PrivilegeHeader _oPrivilege in oGuest.AccountPrivileges)
                {
                    ListViewItem _lvwItem = new ListViewItem(_oPrivilege.PrivilegeID);
                    lvwGuestPrivileges.Items.Add(_lvwItem);
                }

                lvwCompanyPrivileges.Items.Clear();
            }
            else if (rdbCompany.Checked == true)
            {
                IList<PrivilegeHeader> _oPrivilegeList = loCompanyFacade.getAccountPrivileges(txtcompanyid.Text);
                PrivilegeHeader _oPrivilege;
                lvwCompanyPrivileges.Items.Clear();
                foreach (PrivilegeHeader _poPrivilege in _oPrivilegeList)
                {
                    _oPrivilege = _poPrivilege;
                    ListViewItem _lvwItem = new ListViewItem(_oPrivilege.PrivilegeID);
                    //_lvwItem.SubItems.Add(_oPrivilege.Description);
                    //_lvwItem.SubItems.Add(_oPrivilege.);
                    //_lvwItem.SubItems.Add(_oPrivilege["PercentOff"].ToString());
                    //_lvwItem.SubItems.Add(_oPrivilege["AmountOFf"].ToString());

                    lvwCompanyPrivileges.Items.Add(_lvwItem);
                }
                lvwGuestPrivileges.Items.Clear();
            }
		}

		//private DateTime lDateSched;
		private void GroupReservationUI_Load(object sender, System.EventArgs e)
		{
            lIsEventManagementDisabled = bool.Parse(ConfigVariables.gIsEventManagementDisabled);
			GroupReservationUI_Load();
            if (!isReinstated)
                loadEvent();

            if (loFolio.Status == "CANCELLED" || loFolio.Status == "NO SHOW" || loFolio.Status == "CLOSED")
            {
                disableControls(this);
                //btnFolio.Enabled = true;
                btnClose.Enabled = true;
                btnPrintContract.Enabled = true;
                if (loFolio.Status == "CANCELLED" || loFolio.Status == "NO SHOW")
                    btnreinstate.Enabled = true;
            }
            else
            {
                setButtons();
            }
            grdFolio.Sort(SortFlags.Ascending, 2, 3);

            //hide tabs for event management if disabled
            if (lIsEventManagementDisabled == true)
            {
                disableTabsForEventManagement();
            }

            if (groupBox13.ContainsFocus == false)
            {
                this.txtGroupName.Focus();
                this.txtGroupName.Select();
            }

            //jlo 8-27-10 hide cancellation
            if (loFolio.Status != "CANCELLED")
            {
                this.tabFolio_.Controls.Remove(this.tabCancellation);
            }
            else
            {
                cboReason.Text = loFolio.ReasonType;
                cboCancelBookingType.Text = loFolio.CancelBookingType;
                txtReasons.Text = loFolio.REASON_FOR_CANCEL;
                txtFutureAction.Text = loFolio.Future_Actions;
                setButtons();
            }
            //jlo

            //jlo 6-10-10 emm only config
            if (ConfigVariables.gIsEMMOnly == "true")
            {
                this.tabFolio_.Controls.Remove(this.tabRoomRequirements);
                this.tabFolio_.Controls.Remove(this.tabBooking);
                this.tabFolio_.Controls.Remove(this.tabPrivilege);
                this.tabFolio_.Controls.Remove(this.tabBillingInfo);
                this.tabFolio_.Controls.Remove(this.tabPackage);
                this.tabFolio_.Controls.Remove(this.tabWedding_);
                this.GroupBox1.Visible = false;
                //this.GroupBox2.Visible = false;
                this.label15.Visible = false;
                this.txtAccount_Type.Visible = false;
                this.label36.Visible = false;
                this.txtTHRESHOLD_VALUE.Visible = false;
                this.gridFunctionRooms.Cols[8].Visible = false;
                this.groupBox8.Visible = false;

                // Gene For Testing 2013-11-11
                this.tabFolio_.Controls.Remove(this.tabEndorsement);
                this.tabFolio_.Controls.Remove(this.TabRecurringCharge);
                this.tabFolio_.Controls.Remove(this.tabFoodBev_);
                this.tabFolio_.Controls.Remove(this.tabEventAttendance);
                //>>
            }
            //jlo

            //jlo 8-24-2010 translator
            this.label56.Text = Translator.getTranslation(this.label56.Text);
            //removed by Gene - 9/1/2011
            //this.TabRecurringCharge.Text = Translator.getTranslation(this.TabRecurringCharge.Text);  
            //added by Gene - 9/1/2011
            this.TabRecurringCharge.Text = "Actual Charges Report";
            this.label83.Text = Translator.getTranslation(this.label83.Text);
            this.label84.Text = Translator.getTranslation(this.label84.Text);
            this.lblLiveIn.Text = Translator.getTranslation(this.lblLiveIn.Text);
            this.lblLiveOut.Text = Translator.getTranslation(this.lblLiveOut.Text);
            this.Label3.Text = Translator.getTranslation(this.Label3.Text);
            this.label39.Text = Translator.getTranslation(this.label39.Text);
            this.Text = Translator.getTranslation(this.Text);
            this.btnPrintContract.Text = Translator.getTranslation(this.btnPrintContract.Text);
            this.btnBookingSheet.Text = Translator.getTranslation(this.btnBookingSheet.Text);
            //jlo

            //Gene - 9/8/2011
            //for word-wrap of grid function room
            //gridFunctionRooms.Styles.Normal.WordWrap = true;
            gridFunctionRooms.AutoSizeCol(1);
            gridFunctionRooms.AutoSizeCol(2);
            gridFunctionRooms.AutoSizeRows();

            if (loFolio.Status == "WAIT LIST")
            {
                this.btnConfirm.Text = "Set to Tentative";
            }

            string _strFile = Application.StartupPath + "\\eventAttendance.txt";
            StreamReader streamREader = new StreamReader(_strFile);
            string _eventAttendanceNote = streamREader.ReadToEnd();
            streamREader.Close();

            txtEventAttendanceNote.Text = _eventAttendanceNote;
            
            /* Gene
             * 01-Mar-12
             * Hide Incumbent Officers grid and label
             * Move and resize lblTin and txtTin
             * Rearrange the objects in groupBox13
             */
            label132.Visible = false;
            gridIncumbentOfficer.Visible = false;            
            // Relocate lblTin
            lblTINNumber.Left = label132.Left;
            lblTINNumber.Top = label132.Top;
            // Relocate txtTIN
            txtTIN.Left = txtcompanyid.Left;
            txtTIN.Top = lblTINNumber.Top;
            txtTIN.Width = txtCompanyName.Width;
            // Relocate the BookingDate label
            label34.Left = lblTINNumber.Left;
            label34.Top = lblTINNumber.Top + lblTINNumber.Height + 10;
            //label34.Left = label132.Left;
            //label34.Top = label132.Top;
            // Relocate txtCreateTime
            txtCreateTime.Left = txtTIN.Left;
            txtCreateTime.Top = txtTIN.Top + txtTIN.Height + 6;
            //txtCreateTime.Left = txtcompanyid.Left;
            //txtCreateTime.Top = lblTIN.Top;
            // Relocate Event Date label
            label105.Left = label34.Left;
            label105.Top = label34.Top + label34.Height + 10;
            // Relocate txtEventDate
            txtEventDate.Left = txtCreateTime.Left;
            txtEventDate.Top = txtCreateTime.Top + txtCreateTime.Height + 6;
        }

        private void loadEvent()
        {
            loadComboBoxes();
            checkSalesModule();
            rdoPercent.Checked = true;
            gridBilling.Cols[0].Editor = cboBillRates;

            if (lFlag == "Edit")
            {
                if(!isReinstated)
                    loadFoodRequirements();
                loadAppliedRates();
                loadFolioDeposits();
                loadRequirementDetails();
                getTotalEstimatedCost();
                loadEventBookingInfo();
                loadEventDetails();
                loadEventEndorsement();
                loadEventAttendance();
                loadEventOfficers();
                loadIncumbentOfficers();
            }
        }

		private void btnRefresh_Click(System.Object sender, System.EventArgs e)
		{
			grdFolio.Rows.Count = 1;
			GetChildFolios();
            grdFolio.Sort(SortFlags.Ascending, 2, 3);
        }

		private void txtcompanyid_TextChanged(System.Object sender, System.EventArgs e)
		{
			txtCompanyId_TextChanged();
		}  

		private void GroupReservationUI_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (lChildFolioStatus == "")
			{
				buttonState(false, false, false, false, false);
			}
		}

		//public void GroupReservationUI_Closed(object sender, System.EventArgs e)
		//{
		//    if (lSubFolioGrid != null)
		//    {
		//        //ReservationsFacade _oReservationFacade = new ReservationsFacade();
		//        //C1.Win.C1FlexGrid.C1FlexGrid _grid;
		//        //_grid = lSubFolioGrid ;

		//        //lSubFolioGrid.Rows.Count = 1;
		//        GroupReservationListUI _oGroupReservationList = new GroupReservationListUI();
		//        _oGroupReservationList.MdiParent = this.MdiParent;
		//        _oGroupReservationList.Show();
		//    }
		//}

		private void btnEdit_Click(System.Object sender, System.EventArgs e)
		{
			btnEdit_Click();
            this.Text = "Group Folio*";
		}

		private void GroupReservationUI_LocationChanged(object sender, System.EventArgs e)
		{
			Top = 0;
			Left = 0;
		}

		private void txtSearch_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				grdFolio.Focus();
				unselectListviewItems();
				foreach (C1.Win.C1FlexGrid.Row _row in grdFolio.Rows)
				{
					if (_row.Index != 0)
					{
						if (grdFolio.GetDataDisplay(_row.Index, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper())
							|| grdFolio.GetDataDisplay(_row.Index, 9).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
						{

							grdFolio.Rows[_row.Index].Selected = true;
							return;
						}
					}
				}
			}
		}

		private void mnuNew_Click(System.Object sender, System.EventArgs e)
		{
			btnNew_Click(sender, e);
		}

		private void mnuEdit_Click(System.Object sender, System.EventArgs e)
		{
			lvwFolio_DoubleClick(sender, e);
		}

		private void mnuConfirm_Click(System.Object sender, System.EventArgs e)
		{
			btnConfirm_Click(sender, e);
		}

		private void mnuCheckin_Click(System.Object sender, System.EventArgs e)
		{
			//MsgBox("FROM DATE:" & lFromDate & "NOW:" & Format(Date.Now, "M/dd/yyyy"))
			if (System.Convert.ToDateTime(string.Format("{0:M/dd/yyyy}", DateTime.Parse(GlobalVariables.gAuditDate))) != lFromDate)
			{
				if (MessageBox.Show("Check In Date for Guest is " + string.Format("{0:dd-MMM-yyyy}", lFromDate) + "\r\n" + "\r\n" + " It will bew changed to the Current date. Would you like to continue?    ", "Early Check In", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					////ReservationFolioUI.AccountType = "PERSONAL";
					////ReservationFolioUI.Flag = "Edit";
					////ReservationFolioUI.FolioType = "DEPENDENT";
					//Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI FolioUI = new Jinisys.Hotel.Reservation.Presentation.ReservationFolioUI("Early ONGOING", grdFolio.GetDataDisplay(grdFolio.Row, 1));
					//FolioUI.MdiParent = this.MdiParent;
					//FolioUI.Top = 0; 
					//FolioUI.Left = 0;
					//FolioUI.Show();
					this.Hide();
				}
			}
			else
			{
				btnCheckIN_Click(sender, e);
			}

		}

		private void mnuCheckOut_Click(System.Object sender, System.EventArgs e)
		{
			btnCheckOUt_Click(sender, e);
		}

		private void mnuNoShow_Click(System.Object sender, System.EventArgs e)
		{
			btnNoSHow_Click(sender, e);
		}

		private void mnuCancel_Click(System.Object sender, System.EventArgs e)
		{
			btnDelete_Click(sender, e);
		}

		private void lvwFOlio_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					System.Drawing.Point _point = new System.Drawing.Point(e.X, e.Y);

					lFolioNo = grdFolio.GetDataDisplay(grdFolio.Row, 0);
					lToDate = DateTime.Parse(grdFolio.GetDataDisplay(grdFolio.Row, 3));
					lFromDate = DateTime.Parse(grdFolio.GetDataDisplay(grdFolio.Row, 2));
					lChildFolioStatus = grdFolio.GetDataDisplay(grdFolio.Row, 7);
                    try
                    {
                        lBalance = decimal.Parse(grdFolio.GetDataDisplay(grdFolio.Row, 6));
                    }
                    catch
                    {
                        lBalance = 0;
                    }
					
                    //switch (lChildFolioStatus.ToUpper())
                    //{
                    //    case "ONGOING":

                    //        mnuState(false, true, false, false, false);
                    //        break;
                    //    case "CLOSED":

                    //        mnuState(false, false, false, false, false);
                    //        break;
                    //    case "CANCELLED":

                    //        mnuState(false, false, false, false, false);
                    //        break;
                    //    case "NO SHOW":
                    //        DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    //        if (System.Convert.ToDateTime(lFromDate) < _auditDate.Date)
                    //        {
                    //            mnuState(false, false, false, false, false);
                    //        }
                    //        else
                    //        {
                    //            mnuState(true, false, false, false, false);
                    //        }
                    //        break;
                    //    case "CONFIRMED":

                    //        mnuState(true, false, true, false, true);
                    //        break;
                    //    case "TENTATIVE":

                    //        mnuState(false, false, true, true, false);
                    //        break;
                    //}
                    //mnuOption.Show(this.grdFolio, _point);

                    if (lFolioNo == "")
                    {
                        mnuUnblock.Enabled = true;
                        mnuCancelBlock.Enabled = false;
                        mnuCancelReservation.Enabled = false;
                    }
                    else
                    {
                        mnuUnblock.Enabled = false;
                        mnuCancelReservation.Enabled = true;
                        mnuCancelBlock.Enabled = true;
                    }

                    string _status = grdFolio.GetDataDisplay(grdFolio.Row, 7).ToUpper();
                    if (_status == "ONGOING" || _status == "CLOSED" || _status == "CANCELLED")
                    {
                        mnuUnblock.Enabled = false;
                        mnuCancelBlock.Enabled = false;
                        mnuCancelReservation.Enabled = false;
                    }

                    mnuDependents.Show(this.grdFolio, _point);
				}
			}
			catch (Exception)
			{
				//  MsgBox(EX.Message)
			}
		}

		private void btnBrowseAgent_Click()
		{
			if (lEdit == true || lFlag == "New")
			{
				GroupAccountLookUP.AccountType = "AGENT";
				GroupAccountLookUP.Flag = "GroupReservation";

				GroupAccountLookUP _oGroupAccountLookUP = new GroupAccountLookUP(txtagentid, txtAgentname, txtCompanyCode, "AGENT");
				_oGroupAccountLookUP.MdiParent = this.MdiParent;
				_oGroupAccountLookUP.Show();
			}
			else
			{
                //MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnBrowseAgent_Click(System.Object sender, System.EventArgs e)
		{
            if (lEdit == false && lFlag == "Edit")
            {
                //MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
            btnBrowseAgent_Click();
		}

        //private void getPackageInfo()
        //{
        //    txtpackageID.Text = lPackageID != "" ? lPackageID : "";
        //    txtPackageName.Text = lPackageName != "" ? lPackageName : "";
        //    txtDaysApplied.Text = lDaysApplied != "" ? lDaysApplied : "";
        //}

		private void btnTransfer_Click(System.Object sender, System.EventArgs e)
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
                    // load details
                    this.grdFolioPackage.Rows.Count = 1;
                    int i = 1;

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


                    return;
                }
            }

            //if (lEdit == true || lFlag == "New")
            //{
            //    if (this.lvwPackageDetails.Items.Count <= 0)
            //    {
            //        getPackageInfo();
            //        loFolioFacade = new FolioFacade();
            //        loFolioFacade.UpdateFolioPackage(txtFolioID.Text, txtpackageID.Text);
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("Action will overwrite the current Package Applied, \r\n Do you want to continue?", "Package", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            getPackageInfo();
            //            loFolioFacade = new FolioFacade();
            //            loFolioFacade.UpdateFolioPackage(txtFolioID.Text, txtpackageID.Text);
            //        }
            //    }
            //}
            //else
            //{
            //    getPackageInfo();
            //}
		}

		private void txtpackageID_TextChanged(System.Object sender, System.EventArgs e)
		{
			//On Error Resume Next  - Cannot Convert to C#
            //loadPackageDetails();
		}

		private void txtFolioID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void txtcompanyid_TextChanged_1(System.Object sender, System.EventArgs e)
		{
			txtCompanyId_TextChanged();
		}

		private void trapLetters(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					e.Handled = false;
					break;

				case '\r':
					e.Handled = false;
					break;

				case '\b':
					e.Handled = false;
					break;

				case '.':

					e.Handled = false;
					break;
				default:

					e.Handled = true;
					break;
			}
		}

        private void GroupReservationUI_Activated(object sender, EventArgs e)
        {
			this.WindowState = FormWindowState.Maximized;

            grdFolio.Rows.Count = 1;
            GetChildFolios();
            grdFolio.Sort(SortFlags.Ascending, 2, 3);

            if (_fromChild == true)
            {
                txtTotalEstimatedCost_TextChanged(this, new EventArgs());
                _fromChild = false;
            }
        }

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
        }

        TableLogOnInfo logOnInfo;
        private void setDatabaseLogOn()
        {
            logOnInfo = new TableLogOnInfo();
            //TableLogOnInfo logOnInfo = new TableLogOnInfo();
            string con = ConfigurationManager.AppSettings.Get("connection");
            string[] split ={ ";", "=" };
            string[] strCon = con.Split(split, StringSplitOptions.RemoveEmptyEntries);

            logOnInfo.ConnectionInfo.ServerName = strCon[1];
            logOnInfo.ConnectionInfo.UserID = strCon[3];
            logOnInfo.ConnectionInfo.Password = strCon[5];
            logOnInfo.ConnectionInfo.DatabaseName = strCon[7];
            logOnInfo.ConnectionInfo.Type = ConnectionInfoType.CRQE;

            //logOnInfos.Add(logOnInfo);
        }

        private void btnPrintContract_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            if (btnPrintContract.Text == "Contract")
            {
                //this.MdiParent.Cursor = Cursors.WaitCursor;

                bool _isBanquet = false;
                EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
                _isBanquet = _oEventTypeFacade.isBanquetType(cboEventType.Text.ToUpper());

                string _isAlpa = ConfigVariables.gContractType;

                if (_isBanquet == true && _isAlpa == "STANDARD")
                {
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();

                    setDatabaseLogOn();
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract banquetContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.BanquetEventContract();
                    banquetContract = _oReportFacade.getBanquetEventContract(txtFolioID.Text);
                    banquetContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
                    oReportViewerUI.rptViewer.ReportSource = banquetContract;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }
                else if (_isBanquet == false && _isAlpa == "STANDARD")
                {
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();

                    setDatabaseLogOn();
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.RoomReservationContract roomContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.RoomReservationContract();
                    roomContract = _oReportFacade.getRoomReservationContract(txtFolioID.Text);
                    roomContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
                    oReportViewerUI.rptViewer.ReportSource = roomContract;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }
                else
                {
                    //if (_isBanquet == true)
                    //{
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getBanquetTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                    //}
                    //else
                    //{
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getRoomTermsAndConditions(txtFolioID.Text, txtGroupName.Text, ConfigVariables.gReportOrganization);
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                    //}

                    setDatabaseLogOn();
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.AlpaEventContract banquetContract = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.AlpaEventContract();
                    banquetContract = _oReportFacade.getAlpaEventContract(txtFolioID.Text);
                    banquetContract.Database.Tables[1].ApplyLogOnInfo(logOnInfo);
                    oReportViewerUI.rptViewer.ReportSource = banquetContract;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }

                this.MdiParent.Cursor = Cursors.Default;
            }
            else
            {
                try
                {
                    oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                    _oReportFacade = new ReportFacade();
                    loEventFacade = new EventFacade();
                    Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk.GroupRegistrationForm_PICC _groupReservation = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Front_Desk.GroupRegistrationForm_PICC();
                    //_groupReservation = _oReportFacade.getGroupRegistration(loFolio, loEventFacade.getEvent(loFolio.FolioID)[0]);
                    oReportViewerUI.rptViewer.ReportSource = _groupReservation;
                    oReportViewerUI.MdiParent = this.MdiParent;
                    oReportViewerUI.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Folio Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFolio_Click(object sender, EventArgs e)
        {
            if (loFolio.FolioID != "")
            {
                //jlo 8-9-10 forcibly set parameter constant to avoid possible errors
                //havent check for possible errors if not constant parameter is used because of lack of time
                string _currentRoomNo = loFolioFacade.GetCurrentRoomOccupied(loFolio.FolioID, "INDIVIDUAL");


                FolioLedgerUI lFolioLedgerUI = new FolioLedgerUI(loFolio.FolioID, _currentRoomNo, this);
                lFolioLedgerUI.MdiParent = this.MdiParent;
                lFolioLedgerUI.Show();
            }
        }

        #endregion
		
        #region CHILD FOLIO

        private void saveDependentFolios()
        {
            if (lEdit == true)
            {
                foreach (C1.Win.C1FlexGrid.Row _row in grdFolio.Rows)
                {
                    if (_row.Index != 0)
                    {
                        /*if no folio assigned yet, that means it is only room blocking.
                         *This will update the room blocking from and to date
                         */
                        if (grdFolio.GetDataDisplay(_row.Index, 0) == "")
                        {
                            RoomBlock _oRoomBlock = new RoomBlock();
                            _oRoomBlock.BlockID = int.Parse(grdFolio.GetDataDisplay(_row.Index, 9));
                            _oRoomBlock.BlockFrom = DateTime.Parse(grdFolio.GetDataDisplay(_row.Index, 2));
                            _oRoomBlock.BlockTo = DateTime.Parse(grdFolio.GetDataDisplay(_row.Index, 3));
                            _oRoomBlock.RoomID = grdFolio.GetDataDisplay(_row.Index, 4);
                            RoomBlockFacade _oRoomBlockFacade = new RoomBlockFacade();
                            _oRoomBlockFacade.updateBlockedRoomsForEvents(_oRoomBlock);
                        }//end if

                        //>>update the dependent's folios from and to date
                        else
                        {

                        }//end else
                    }
                }//end for count rows
            }//end edit mode = true
        }

        private void GetChildFolios()
        {
            try
            {
                DataTable _getChildData;
                loFolioFacade = new FolioFacade();
                _getChildData = loFolioFacade.GetChildFoliosTable(txtFolioID.Text);
                ScheduleFacade _oScheduleFacade = new ScheduleFacade();

                grdFolio.Rows.Count = 1;

                string _rno;
                DataRow _dtRow;
                int _noShow = 0;
                int _checkIn = 0;
                int _checkOut = 0;
                int _overStay = 0;
                decimal _totalAmount = 0;
                decimal _totalBalance = 0;
                FolioTransactionFacade _oFolioTransFacade = new FolioTransactionFacade();
                Folio _oFolio = new Folio();
                foreach (DataRow _tempLoopVarDtRow in _getChildData.Rows)
                {
                    _dtRow = _tempLoopVarDtRow;
                    _oFolio = new Folio();
                    if (_dtRow["foliotype"].ToString() != "JOINER" && _dtRow["status"].ToString() != "CANCELLED")
                    {
                        _oFolio = loFolioFacade.GetFolio(_dtRow["FolioID"].ToString());
                        DateTime _arrivalTime = DateTime.Parse(_dtRow["arrivalDate"].ToString());
                        string _status = _dtRow["status"].ToString();
                        string _noShowTime = string.Format("{0:hh:mm tt}", _arrivalTime.AddHours(2));
                        string _timeNow = string.Format("{0:hh:mm tt}", DateTime.Parse(DateTime.Parse(GlobalVariables.gAuditDate).TimeOfDay.ToString()));

                        Schedule _oSchedule = new Schedule();
                        string _rooms;
                        if (_dtRow["masterfolio"].ToString() == "" || _dtRow["masterfolio"].ToString() != "" && _dtRow["foliotype"].ToString() == "DEPENDENT")
                        {
                            _rooms = _oScheduleFacade.GetRoomAndRoomTypeFromSchedules(_dtRow["foLIOid"].ToString());
                        }
                        else
                        {
                            _rooms = _oScheduleFacade.GetRoomAndRoomTypeFromSchedules(_dtRow["masterfolio"].ToString());
                        }
                        if (_rooms == "")
                        {
                            _rooms = "";
                        }
                        else
                        {
                            _rooms = _rooms.Substring(0, _rooms.Length - 2);
                        }

                        _rno = _dtRow["FOlioID"].ToString();
                        grdFolio.Rows.Count++;

                        //-------------------------[ column 1 - ID   ]-----------------------------------'
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 0, _rno);

                        //-------------------------[ column 2 - Folio Owner]-----------------------------------'
                        Guest _oGuest = new Guest();
                        GuestFacade _oGuestFacade = new GuestFacade();
                        string _acctID = _dtRow["accountID"].ToString();
                        _oGuest = _oGuestFacade.getGuestRecord(_acctID);
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 1, _oGuest.LastName + ", " + _oGuest.FirstName);

                        //-------------------------[ column 3 - From Date]-----------------------------------'
                        string _fromDate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(_dtRow["Fromdate"].ToString()));
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 2, _fromDate);

                        //-------------------------[ column 4 - TO Date]-----------------------------------'
                        string _toDate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(_dtRow["todate"].ToString()));
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 3, _toDate);

                        //-------------------------[ column 5 - Rooms]-----------------------------------'
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 4, _rooms);

                        //-------------------------[ column 6 - Amount]-----------------------------------'

                        decimal totalSubFolioCharges = 0;
                        decimal totalSubFolioPayments = 0;
                        decimal totalSubFoliocurrentbalance = 0;
                        decimal totalSubFolioCashPayment = 0;
                        decimal totalSubFolioCardPayment = 0;
                        decimal totalSubFolioChequePayment = 0;
                        decimal totalSubFolioGiftChequePayment = 0;
                        decimal totalSubFolioBalanceForward = 0;


                        _oFolio.CreateSubFolio();
                        SubFolio subF = null;

                        decimal totalCharges = 0;
                        decimal totalPayments = 0;
                        decimal balance = 0;
                        foreach (SubFolio tempLoopVar_subF in _oFolio.SubFolios)
                        {
                            subF = tempLoopVar_subF;
                            //if (subF.SubFolio_Renamed == "B")
                            //{
                            subF.Ledger = loFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                            totalSubFolioCharges += subF.Ledger.Charges;
                            totalSubFolioCashPayment += subF.Ledger.PayCash;
                            totalSubFolioCardPayment += subF.Ledger.PayCard;
                            totalSubFolioChequePayment += subF.Ledger.PayCheque;
                            totalSubFolioGiftChequePayment += subF.Ledger.PayGiftCheque;
                            totalSubFolioBalanceForward += subF.Ledger.BalanceForwarded;
                            totalSubFolioPayments += subF.Ledger.PayCash + subF.Ledger.PayCard + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded;

                            totalCharges += subF.Ledger.Charges;
                            totalPayments += (subF.Ledger.PayCard + subF.Ledger.PayCash + subF.Ledger.PayCheque + subF.Ledger.PayGiftCheque + subF.Ledger.BalanceForwarded);
                            balance = totalCharges - totalPayments;

                            totalSubFoliocurrentbalance += balance;
                            //}

                        }
                        //}
                        //_balance += totalSubFoliocurrentbalance;

                        decimal _charges = totalCharges;
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 5, _charges.ToString("N"));

                        //-------------------------[ column 7 - Balance]------------------ -----------------'

                        _oFolio.FolioID = _rno;
                        _oFolio.FolioType = "INDIVIDUAL";

                        decimal _payment = totalPayments;
                        decimal _balance = balance;
                        _totalBalance += _balance;
                        _totalAmount += _charges - _payment;

                        grdFolio.SetData(grdFolio.Rows.Count - 1, 6, _balance.ToString("N"));

                        //-------------------------[ column 8 - Status]-----------------------------------'
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 7, _status);

                        //-------------------------[ column 9 - Time of Arrival]-----------------------------------'
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 8, string.Format("{0:hh:mm tt}", _arrivalTime));

                        //-------------------------[ column 10 - room#]-----------------------------------'
                        if (_dtRow["status"].ToString() == "ONGOING")
                        {
                            //jlo 8-9-10 forcibly set parameter constant to avoid possible errors
                            //havent check for possible errors if not constant parameter is used because of lack of time
                            string _roomNo = loFolioFacade.GetCurrentRoomOccupied(_rno,"INDIVIDUAL");
                            grdFolio.SetData(grdFolio.Rows.Count - 1, 9, _roomNo);
                        }
                        else
                        {
                            grdFolio.SetData(grdFolio.Rows.Count - 1, 9, "-");
                            //_listViewItem = new ListViewItem("-");
                        }

                        //-------------------------[ column 11 - number of pax]-----------------------------------'
                        string _numberOfPax = _dtRow["noOfAdults"].ToString();
                        grdFolio.SetData(grdFolio.Rows.Count - 1, 11, _dtRow["noOfAdults"].ToString());

                        //DateTime noshowdate;
                        if (string.Format("{0:hh:mm tt}", _arrivalTime) == "11:00 PM" || string.Format("{0:hh:mm tt}", _arrivalTime) == "10:00 PM")
                        {
                            _fromDate = System.Convert.ToDateTime(_fromDate).AddDays(1).ToString();
                        }
                        DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);

                        //if (DateTime.Today.Date == DateTime.Parse(_toDate) && _status == "ONGOING")
                        if (_auditDate.Date == DateTime.Parse(_toDate) && _status == "ONGOING")
                        {
                            grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.PaleGreen;
                            _checkOut++;
                            //-------------------------[ TODAYS CHECKIN  ]-----------------------------------'
                        }
                        else if (_status == "CONFIRMED" && DateTime.Parse(_fromDate) == _auditDate.Date)
                        {
                            grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.LightSkyBlue;
                            _checkIn++;
                            //-------------------------[ FOR OVERSTAY   ]-----------------------------------'
                        }
                        else if (_status == "ONGOING" && _auditDate.Date > DateTime.Parse(_toDate))
                        {
                            grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.ForeColor = System.Drawing.Color.White;
                            grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Red;
                            _overStay++;
                        }
                        if (DateTime.Parse(_fromDate) == _auditDate.Date && (_status == "CONFIRMED" || _status == "TENTATIVE") && System.Convert.ToDateTime(_timeNow) >= System.Convert.ToDateTime(_noShowTime))
                        {
                            grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Gainsboro;
                            _noShow++;
                        }
                        if (DateTime.Parse(_fromDate) < _auditDate.Date && (_status == "CONFIRMED" || _status == "TENTATIVE"))
                        {
                            grdFolio.Rows[grdFolio.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Gainsboro;
                            _noShow++;
                        }
                        lblCheckIn.Text = _checkIn.ToString();
                        lblCheckout.Text = _checkOut.ToString();
                        lblNoShow.Text = _noShow.ToString();
                        lblOverStay.Text = _overStay.ToString();
                    }
                }
                loadRooms();
                txtAmount.Text = _totalAmount.ToString("N");
                //txtBalance.Text = _totalBalance.ToString("N");

                decimal _totalGrpBalance = 0;
                foreach (SubFolio pSubFolio in loFolio.SubFolios)
                {
                    if (pSubFolio.SubFolio_Renamed == "A")
                    {
                        decimal _totalPayCash = pSubFolio.Ledger.PayCash;
                        decimal _totalPayCHarge = pSubFolio.Ledger.PayCard;
                        decimal _totalPayCheque = pSubFolio.Ledger.PayCheque;
                        decimal _totalPayGiftCheque = pSubFolio.Ledger.PayGiftCheque;
                        decimal _totalBalanceForward = pSubFolio.Ledger.BalanceForwarded;
                        decimal _totalCharges = pSubFolio.Ledger.Charges;

                        _totalGrpBalance += _totalCharges - (_totalPayCash + _totalPayCHarge + _totalPayCheque + _totalPayGiftCheque + _totalBalanceForward);
                    }
                }
                txtGrpTotal.Text = _totalGrpBalance.ToString("N");
                _totalGrpBalance = decimal.Parse(txtAmount.Text) + _totalGrpBalance;
                txtBalance.Text = _totalGrpBalance.ToString("N");
            }
            catch { }
        }

        private bool checkChildCheckIn()
        {
            bool _childCheckIn = false;
            foreach (C1.Win.C1FlexGrid.Row _row in grdFolio.Rows)
            {
                if (_row.Index != 0 && grdFolio.GetDataDisplay(_row.Index, 7) == "ONGOING")
                {
                    _childCheckIn = _childCheckIn || true;
                }
                else
                {
                    _childCheckIn = _childCheckIn || false;
                }
            }
            return _childCheckIn;
        }

        private bool CheckChildStatus()
        {
            int _statCounter = 0;
            foreach (C1.Win.C1FlexGrid.Row _row in grdFolio.Rows)
            {
                if (_row.Index != 0 && (grdFolio.GetDataDisplay(_row.Index, 6) == "CLOSED" || grdFolio.GetDataDisplay(_row.Index, 6) == "No Show" || grdFolio.GetDataDisplay(_row.Index, 6) == "Cancelled"))
                {
                    _statCounter++;
                }
            }
            if (_statCounter == grdFolio.Rows.Count - 1 && grdFolio.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void newReservation(IList<Schedule> _childFolioSchedule)
        {
            Folio _newChildFolio = new Folio();
            int _row = this.grdFolio.Row;

            _newChildFolio.Schedule = _childFolioSchedule;
            _newChildFolio.FolioRouting = loFolio.FolioRouting;
            _newChildFolio.MasterFolio = loFolio.FolioID;
            _newChildFolio.GroupName = loFolio.GroupName;
            _newChildFolio.FolioType = "DEPENDENT";
            _newChildFolio.Status = "CONFIRMED";
            _newChildFolio.Source = cboSource.Text;
            _newChildFolio.AccountType = cboAccountType.Text;
            _newChildFolio.Payment_Mode = cboPayment_Mode.Text;
            _newChildFolio.Purpose = cboPurpose.Text;
            _newChildFolio.CompanyID = loFolio.CompanyID;
            _newChildFolio.GroupName = loFolio.GroupName;
            _newChildFolio.CreatedBy = txtCreatedBy.Text;

            _newChildFolio.Sales_Executive = loFolio.Sales_Executive;


            try
            {
                _newChildFolio.FromDate = _childFolioSchedule[0].FromDate;
                _newChildFolio.Todate = _childFolioSchedule[_childFolioSchedule.Count - 1].ToDate;

            }
            catch
            {
                _newChildFolio.FromDate = DateTime.Parse(GlobalVariables.gAuditDate);
                _newChildFolio.Todate = DateTime.Parse(GlobalVariables.gAuditDate);
            }

            _newChildFolio.ArrivalDate = _newChildFolio.FromDate;
            _newChildFolio.DepartureDate = _newChildFolio.Todate;
            _newChildFolio.RecurringCharges = new List<RecurringCharge>();
            _newChildFolio.Privileges = loFolio.Privileges;
            _newChildFolio.Package = loFolio.Package;
            _newChildFolio.FolioRouting = loFolio.FolioRouting;
            _newChildFolio.JoinerFolios = new List<Folio>();

            ReservationFolioUI _oReservationFolioUI = new ReservationFolioUI();
            ReservationFolioUI _oReservationFolio = new ReservationFolioUI(ReservationOperationMode.NewChildFolio, _newChildFolio);
            _oReservationFolio.MdiParent = this.MdiParent;
            _oReservationFolio.Show();
        }


        #endregion

        #region FOR CONTROLS

        private void setButtons()
        {
            if (lGroupFolioStatus == "New")
            {
                btnBlock.Enabled = false;
                btnManualBlockRooms.Enabled = false;
                btnCheckIN.Enabled = false;
                btnCheckOut.Enabled = false;
                btnPrintContract.Enabled = false;
                btnFolio.Enabled = false;
                btnBookingSheet.Enabled = false;
                btnPostCharges.Enabled = false;
                btnNewDeposit.Enabled = false;
                btnreinstate.Enabled = false;
                btnConfirm.Enabled = false;
                btnSaveRequirements.Enabled = false;
                panel6.Enabled = false;
                panel4.Enabled = false;

                pnlAmendments.Enabled = false;
                grpMealDetails.Enabled = false;
                grpNewAmendments.Enabled = false;

                /* Gene
                 * 06-Mar-12
                 * Hide the Cancel Reservation button if it is a new reservation
                 * Disable the panel that contains btnPrintEventAttendance if it is a new reservation
                 */
                btnCancelReservation.Visible = false;
                panel5.Enabled = false;
            }
            else
            {
                btnBlock.Enabled = true;
                btnPrintContract.Enabled = true;
                btnFolio.Enabled = true;
                btnBookingSheet.Enabled = true;
                btnPostCharges.Enabled = true;
                btnNewDeposit.Enabled = true;
                btnConfirm.Enabled = true;
                btnManualBlockRooms.Enabled = true;
                btnreinstate.Enabled = true;
                btnSaveRequirements.Enabled = true;
                panel6.Enabled = true;
                panel4.Enabled = true;
                btnCancelReservation.Enabled = true;
                pnlAmendments.Enabled = true;
                grpMealDetails.Enabled = true;
                grpNewAmendments.Enabled = true;
                pnlStatus.Visible = true;
                if (loFolio.FromDate > DateTime.Now && loFolio.Status == "CONFIRMED")
                    btnCheckIN.Enabled = false;
            }

            switch (cboStatus.Text)
            {
                case "ONGOING":
                    btnreinstate.Enabled = false;
                    btnConfirm.Enabled = false;
                    btnCheckIN.Enabled = false;
                    btnCancelReservation.Enabled = false;

                    //Clark 10.05.2011
                    btnUnconfirm.Enabled = false;

                    break;

                case "TENTATIVE":
                case "WAIT LIST":
                    btnreinstate.Enabled = false;
                    btnCheckIN.Enabled = false;
                    btnCheckOut.Enabled = false;
                    btnPostCharges.Enabled = false;

                    //Clark 10.05.2011
                    btnUnconfirm.Enabled = false;

                    break;                    

                case "CONFIRMED":
                    btnreinstate.Enabled = false;
                    btnConfirm.Enabled = false;
                    btnCheckOut.Enabled = false;
                    btnreinstate.Enabled = false;
                    btnPostCharges.Enabled = false;

                    //Clark 10.05.2011
                    btnUnconfirm.Enabled = true;

                    if (loFolio.FromDate > DateTime.Now)
                        btnCheckIN.Enabled = true;
                    break;

                case "CANCELLED":
                    btnCheckOut.Enabled = false;
                    btnCheckIN.Enabled = false;
                    btnFolio.Enabled = false;
                    btnConfirm.Enabled = false;
                    btnPostCharges.Enabled = false;
                    pnlNew.Enabled = false;
                    btnCancelReservation.Enabled = false;
                    btnBookingSheet.Enabled = false;
                    btnPrintContract.Enabled = false;
                    btnSaveCancellation.Enabled = true;

                    //Clark 10.05.2011
                    btnUnconfirm.Enabled = false;

                    break;

                case "CLOSED":
                    btnreinstate.Enabled = false;
                    pnlStatus.Enabled = false;
                    pnlNew.Enabled = false;
                    btnFolio.Enabled = false;
                    btnCancelReservation.Enabled = false;

                    btnUnconfirm.Enabled = false;

                    break;
            }
        }

        private void mnuState(bool pBtnCheckedInState, bool pBtnCheckedOutState, bool pBtnCancelledState, bool pBtnConfirmedState, bool pBtnNoShowState)
        {

            mnuCheckin.Visible = pBtnCheckedInState;
            mnuCheckOut.Visible = pBtnCheckedOutState;
            mnuCancel.Visible = pBtnCancelledState;
            mnuConfirm.Visible = pBtnConfirmedState;
            mnuNoShow.Visible = pBtnNoShowState;

        }

        private void txtHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void noHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void KeypressTextboxHandler(Control ctrl, bool handle)
        {
            Control _ctrl1;
            foreach (Control _tempLoopVarCtrl1 in ctrl.Controls)
            {
                _ctrl1 = _tempLoopVarCtrl1;
                if (_ctrl1 is Panel || _ctrl1 is GroupBox)
                {
                    KeypressTextboxHandler(_ctrl1, handle);
                }
                else if (_ctrl1 is TextBox 
						 || _ctrl1 is NumericUpDown 
						 || _ctrl1 is ComboBox)
                {
                    if (_ctrl1.Name != "txtCharge" 
						&& _ctrl1.Name != "txtAmountRCharge" 
						&& _ctrl1.Name != "txtGroupName" 
						&& _ctrl1.Name != "txtSearch" 
						&& _ctrl1.Name != "txtLastName" 
						&& _ctrl1.Name != "txtFirstName" 
						&& _ctrl1.Name != "txtMiddleName" 
						&& _ctrl1.Name != "txtCompanyName"
                        && _ctrl1.Name != "txtRemarks"
                        /* Gene
                         * 02-Mar-12
                         * added TIN
                         */
                        && _ctrl1.Name != "txtTIN"
                        && _ctrl1.Name != "txtGroupRemarks" )
                    {

                        if (handle == true)
                        {
                            _ctrl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtHandle);
                        }
                        else
                        {
                            _ctrl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(noHandle);
                        }
                    }
                }
            }
        }

        private void loadComboBoxes()
        {
            //>>to display all event types in the combo box
            EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
            GenericList<EventType> _oEventTypeList = _oEventTypeFacade.getEventTypes();
            EventType _oEventType = new EventType();
            _oEventType.Event_Type = "";
            _oEventType.EventID = 0;
            _oEventTypeList.Insert(0, _oEventType);
            cboEventType.DisplayMember = "event_type";
            cboEventType.ValueMember = "eventid";
            cboEventType.DataSource = _oEventTypeList;

            //>>to display all requirements type in the combo box
            RequirementCodeFacade _oRequirementCodeFacade = new RequirementCodeFacade();
            GenericList<RequirementCode> _oRequirementCodeList = new GenericList<RequirementCode>();
            _oRequirementCodeList = _oRequirementCodeFacade.getRequirementCodes();
            RequirementCode _oRequirementCode = new RequirementCode();
            _oRequirementCode.Description = "";
            _oRequirementCode.Requirement_Code = "0";
            _oRequirementCodeList.Insert(0, _oRequirementCode);
            cboRequirementType.DisplayMember = "Description";
            cboRequirementType.ValueMember = "Requirement_Code";
            cboRequirementType.DataSource = _oRequirementCodeList;

            //>>to display all applied rates in the combo box
            AppliedRatesFacade _oAppliedRatesFacade = new AppliedRatesFacade();
            GenericList<AppliedRates> _oAppliedRatesList = _oAppliedRatesFacade.getAppliedRates();
            AppliedRates _oAppliedRates = new AppliedRates();
            cboBillRates.DisplayMember = "Description";
            cboBillRates.ValueMember = "NumberOfOccupants";
            cboBillRates.DataSource = _oAppliedRatesList;

            //>>to display all packages in the combo box
            EventPackageFacade _oEventPackageFacade = new EventPackageFacade();
            GenericList<EventPackageHeader> _oEventPackage = _oEventPackageFacade.getEventPackages();
            EventPackageHeader _oEventPackageHeader = new EventPackageHeader();
            _oEventPackageHeader.PackageID = 0;
            _oEventPackageHeader.Description = "";
            _oEventPackage.Insert(0, _oEventPackageHeader);
            cboEventGrpPackage.DisplayMember = "Description";
            cboEventGrpPackage.ValueMember = "PackageID";
            cboEventGrpPackage.DataSource = _oEventPackage;

            GroupBookingDropDownFacade _oGroupBookingDropDown = new GroupBookingDropDownFacade();
            DataTable _dt = _oGroupBookingDropDown.getSpecificFieldName("GeographicalScope");
            foreach (DataRow _dRow in _dt.Rows)
            {
                cboGeoEventType.Items.Add(_dRow["Value"].ToString());
            }

            cboGeoEventType.SelectedIndex = 0;
        }

        private ComboBox cboRateType = new ComboBox();
        private bool _canAddEventOfficer = false;
        //>>for disabling and arranging tabs for the Sales Module
        private void checkSalesModule()
        {
            tabFolio_.TabPages.Clear();
            bool _isSales = false;
            bool _isAdmin = false;

            User _oUser = new User();
            _oUser = (User)GlobalVariables.goUser;

            foreach (Role _oRole in _oUser.Roles)
            {
                if (_oRole.RoleName.ToUpper().Contains("SALES"))
                {
                    _isSales = true;
                }
                else if (_oRole.RoleName.ToUpper().Contains("ADMIN"))
                {
                    _isAdmin = true;
                }
                 
                foreach (Role_Privilege _oPrivilege in _oRole.Privileges)
                {
                    if (_oPrivilege.Privilege.ToUpper() == "ADD EVENT OFFICERS" && _oPrivilege.Allowed == 1)
                    {
                        _canAddEventOfficer = true;
                    }
                }
            }

            //>>rearrange tab pages for the Sales and others
            this.tabFolio_.Controls.Add(this.tabEventDetails_);
            this.tabFolio_.Controls.Add(this.tabRooms_);
            this.tabFolio_.Controls.Add(this.tabAmmendments);
            this.tabFolio_.Controls.Add(this.tabEndorsement);
            this.tabFolio_.Controls.Add(this.TabRecurringCharge);
            this.tabFolio_.Controls.Add(this.tabEventRequirements);
            this.tabFolio_.Controls.Add(this.tabFoodBev_);
            this.tabFolio_.Controls.Add(this.tabEventAttendance);
            this.tabFolio_.Controls.Add(this.tabCancellation);
            this.tabFolio_.Controls.Add(this.tabRoomRequirements);
            this.tabFolio_.Controls.Add(this.tabBillingInfo);         
            this.tabFolio_.Controls.Add(this.tabWedding_);
            this.tabFolio_.Controls.Add(this.tabBooking);
            this.tabFolio_.Controls.Add(this.tabPrivilege);
            this.tabFolio_.Controls.Add(this.tabPackage);
            


            if (_isSales == false && _isAdmin == false)
            {
                cboEventGrpPackage.Enabled = false;
                gridBilling.Enabled = false;
            }
            else
            {
                cboEventGrpPackage.Enabled = true;
                gridBilling.Enabled = true;
            }

            if (_isSales == true)
            {
                pnlStatus.Enabled = false;
            }
            else
            {
                pnlStatus.Enabled = true;
            }

            //>>for enabling and disabling tabs meant for the user
            //string[] _bookingTabs ={ "tabEventDetails_", "tabWedding_", "tabFoodBev_" };
            //foreach (TabPage _tabPage in tabFolio_.TabPages)
            //{
            //    foreach (string _str in _bookingTabs)
            //    {
            //        if (_tabPage.Name == _str && _isSales == false && _isAdmin == false)
            //        {
            //            foreach (Control _ctrl in _tabPage.Controls)
            //            {
            //                _ctrl.Enabled = false;
            //                if (_ctrl.Name == "treeFoodBev")
            //                    _ctrl.Enabled = true;
            //                if (_ctrl.Name == "btnNewDeposit")
            //                    _ctrl.Enabled = true;
            //            }
            //        }
            //    }
            //}
        }

        private void DisableControls(Control pControl, bool pTrueFalse)
        {
            Control pCntrol;
            foreach (Control _tempLoopVarCntrol in pControl.Controls)
            {
                pCntrol = _tempLoopVarCntrol;
                if (pCntrol is TabControl || pCntrol is Panel || pCntrol is GroupBox || pCntrol is ListView)
                {
                    if (pCntrol is TabPage && pCntrol.Name.Contains("_"))
                    {
                    }
                    else
                    {
                        pCntrol.Enabled = true;
                        DisableControls(pCntrol, pTrueFalse);
                    }
                }
                else
                {
                    if (pCntrol.Name != "btnNewMeal" || pCntrol.Name != "btnSaveMeal" )
                        pCntrol.Enabled = pTrueFalse;
                }
            }
        }

        private void buttonState(bool pBtnCheckedInState, bool pBtnCheckedOutState, bool pBtnCancelledState, bool pBtnConfirmedState, bool pBtnNoShowState)
        {    
            btnCheckIN.Enabled = pBtnCheckedInState;
            btnCheckOut.Enabled = pBtnCheckedOutState;
            btnCancelReservation.Enabled = pBtnCancelledState;
            if (string.Format("{0:MM-dd-yyyy}", loFolio.FromDate) != string.Format("{0:MM-dd-yyyy}", DateTime.Now) && loFolio.Status == "CONFIRMED")
                btnCheckIN.Enabled = false;
        }

        private void AfterSaveAction()
        {
            btnEdit.Visible = true;
            //btnNew.Enabled = false;
            //panelNew.Visible = false;
            KeypressTextboxHandler(this, true);
            lEdit = false;
        }

        #endregion

        #region FOLIO

        private void browseAccount()
        {
            if (rdbCompany.Checked)
            {
                if (lEdit == true || lFlag == "New")
                {
                    GroupAccountLookUP.AccountType = "COMPANY";
                    GroupAccountLookUP.Flag = "GroupReservation";

                    GroupAccountLookUP groupAccountLookUP = new GroupAccountLookUP(txtCompanyCode, txtCompanyName, txtcompanyid, "COMPANY", txtAccount_Type, txtTHRESHOLD_VALUE, txtTotal_Sales_Contribution);
                    groupAccountLookUP.MdiParent = this.MdiParent;
                    groupAccountLookUP.Show();
                }
                else
                {
                    //MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (lEdit == true || lFlag == "New")
                {
                    IndividualGuestLookUP guestAccountLookUp = new IndividualGuestLookUP();
                    this.txtcompanyid.Text = guestAccountLookUp.showDialogID();

                    //guestAccountLookUp.MdiParent = this.MdiParent;
                    //guestAccountLookUp.Show();
                }
                else
                {
                    //MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void newFolio()
        {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
            {
                if (lFlag == "New")
                {
                    if (MessageBox.Show("Parent Folio must first be saved, Do you want to Continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.cboAccountType.Text.Trim().Length <= 0)
                        {
                            MessageBox.Show("Please select account type.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tabFolio_.TabPages["tabBooking"].Select();
                            this.cboAccountType.Focus();
                            return;
                        }

                        if (this.cboPayment_Mode.Text.Trim().Length <= 0)
                        {

                            MessageBox.Show("Please select payment mode.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tabFolio_.TabPages["tabBooking"].Select();
                            this.cboPayment_Mode.Focus();
                            return;
                        }

                        if (this.cboPurpose.Text.Trim().Length <= 0)
                        {

                            MessageBox.Show("Please select purpose of booking.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tabFolio_.TabPages["tabBooking"].Select();
                            this.cboPurpose.Focus();
                            return;
                        }

                        //if (gridFunctionRooms.Rows.Count <= 1)
                        //{
                        //    MessageBox.Show("Group Reservation should have at least one(1) schedule.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    tabFolio_.TabPages["tabRooms_"].Select();
                        //    return;
                        //}

                        saveGroupFolio(ref _oTransaction);
                        saveBookingInfo(ref _oTransaction);

                        IList<Schedule> _childFolioSchedule = new List<Schedule>();
                        Schedule _newSchedule = new Schedule();

                        // if no FUNCTION ROOM defined
                        if (this.gridFunctionRooms.Rows.Count > 1)
                        {
                            _newSchedule.FromDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 3));
                            _newSchedule.ToDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 4));
                        }
                        else
                        {
                            _newSchedule.FromDate = dtpFromDate.Value;
                            _newSchedule.ToDate = dtpTodate.Value;
                        }
                        _newSchedule.RoomID = "";
                        _childFolioSchedule.Add(_newSchedule);

                        newReservation(_childFolioSchedule);
                        lFlag = "Edit";
                    }
                }
                else
                {
                    IList<Schedule> _childFolioSchedule = new List<Schedule>();
                    Schedule _newSchedule = new Schedule();

                    // if no FUNCTION ROOM defined
                    if (this.gridFunctionRooms.Rows.Count > 1)
                    {
                        _newSchedule.FromDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 3));
                        _newSchedule.ToDate = DateTime.Parse(this.gridFunctionRooms.GetDataDisplay(1, 4));
                    }
                    else
                    {
                        _newSchedule.FromDate = dtpFromDate.Value;
                        _newSchedule.ToDate = dtpTodate.Value;
                    }
                    _newSchedule.RoomID = "";
                    _childFolioSchedule.Add(_newSchedule);

                    newReservation(_childFolioSchedule);
                    lFlag = "Edit";
                }

                _oTransaction.Commit();
                //End If
            }
            catch
            {
                _oTransaction.Rollback();
            }
        }

        private bool _fromChild = false;
        private void lvwFolio_DoubleClick()
        {
            if (grdFolio.Rows.Count > 1)
            {
                if (grdFolio.GetDataDisplay(grdFolio.Row, 0) != "")
                {
                    string _folioID = grdFolio.GetDataDisplay(grdFolio.Row, 0);
                    Folio _oFolio = new Folio();
                    _oFolio = loFolioFacade.GetGuestFolioInfo(_folioID);

                    if (_oFolio.MasterFolio != txtFolioID.Text)
                    {
                        /* SCR-00101 , Line #4, 6
                         * Jerome, April 18, 2008
                         * Pass FolioID of masterFolio rather select folio since
                         * SHARE to another guest
                         */

                        _folioID = _oFolio.MasterFolio; // MASTER FOLIO ID

                        DialogResult rsp = MessageBox.Show("Guest type is share.\r\n\r\nShow Master Folio information?", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rsp == DialogResult.No)
                            return; // exit is no

                        /* END SCR-00101, Line # 4,6 */
                    }
                    else
                    {
                        _folioID = _oFolio.FolioID;
                    }

                    lIsChildFolioViewed = true;

                    ReservationFolioUI _oFolioUI = new ReservationFolioUI(ReservationOperationMode.ViewChildFolio, _folioID);
                    _oFolioUI.MdiParent = this.MdiParent;
                    _oFolioUI.Top = 0;
                    _oFolioUI.Left = 0;
                    _oFolioUI.Show();

                    _fromChild = true;
                }
                else
                {
                    string _roomID = grdFolio.GetDataDisplay(grdFolio.Row, 4).Substring(0, grdFolio.GetDataDisplay(grdFolio.Row, 4).IndexOf('-')); ;
                    lIsChildFolioViewed = true;

                    IList<Schedule> _childFolioSchedule = new List<Schedule>();
                    Schedule _newSchedule = new Schedule();

                    _newSchedule.FromDate = DateTime.Parse(this.grdFolio.GetDataDisplay(grdFolio.Row, 2));
                    _newSchedule.ToDate = DateTime.Parse(this.grdFolio.GetDataDisplay(grdFolio.Row, 3));
                    _newSchedule.RoomID = _roomID;
                    _childFolioSchedule.Add(_newSchedule);

                    newReservation(_childFolioSchedule);
                    _fromChild = true;
                }
            }
        }

        private void btnDelete_Click()
        {
            if (lFolioNo != "0")
            {
                FolioFacade oFolioFacade = new FolioFacade();
                Folio oFolio = oFolioFacade.GetFolio(lFolioNo);

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
                    MessageBox.Show("Transaction failed.\r\n\r\nGuest still has unsettled account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("This Action will Remove the Sub Folio in the list, \n Do you still want to continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    FacadeDeclarations();
                    RoomEvents _oRoomEvent = new RoomEvents();
                    //Folio _oFolio = new Folio();
                    oFolio.Status = "CANCELLED";
                    oFolio.FolioID = lFolioNo;
                    oFolio.UpdateTime = oFolio.UpdateTime;

                    ReasonForCancelUI _reasonForCancelUI = new ReasonForCancelUI();
                    oFolio.REASON_FOR_CANCEL = _reasonForCancelUI.showDialog();

                    loFolioFacade.cancelFolio(oFolio.FolioID, oFolio.REASON_FOR_CANCEL);
                    //loScheduleFacade.DeleteSchedules(CInt(lFolioNo))
                    loRoomEventFacade.CancelRoomEvents(lFolioNo, "RESERVATION", "CANCELLED");

                    ////>>for those rooms that are blocked by a group
                    ////>>if under a group, decrement the number of blocked rooms
                    //try
                    //{
                    //    string RoomID = grdFolio.GetDataDisplay(grdFolio.Row, 4);
                    //    RoomTypeFacade _oRoomFacade = new RoomTypeFacade();
                    //    string roomType = _oRoomFacade.getRoomType(RoomID.Substring(0, RoomID.IndexOf('-')));
                    //    EventRoomRequirementFacade _oRoomRequirementsFacade = new EventRoomRequirementFacade();
                    //    string folioID = txtFolioID.Text;
                    //    _oRoomRequirementsFacade.updateNumberOfBlockedRooms(folioID, roomType, 1);
                    //}
                    //catch { }
                    
                    updateCurrentDayStatusInMain();
                    loadFolio();
                    loadRoomRequirements();
                }
            }
            else
            {
                MessageBox.Show("No Sub Folio Selected");
            }
        }

        private bool isValidSchedule()
        {
            foreach (C1.Win.C1FlexGrid.Row _row in gridFunctionRooms.Rows)
            {
                if (_row.Index != 0)
                {
                    if (DateTime.Parse(gridFunctionRooms.GetDataDisplay(_row.Index, 3)) > DateTime.Parse(gridFunctionRooms.GetDataDisplay(_row.Index, 4)))
                    {
                        return false;
                    }

                    if (gridFunctionRooms.GetDataDisplay(_row.Index, 0).Trim().Equals(""))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnSave_Click()
        {
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

            //if (txtcompanyid.Text == "" && lFlag.ToUpper() != "NEW")
            //{
            //    MessageBox.Show("Invalid account id. Please select guest/company.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.btnBrowseAccount.Focus();
            //    return;
            //}

            if (gridFunctionRooms.Rows.Count <= 1)
            {
                MessageBox.Show("Group Reservation should have at least one(1) schedule.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabRooms_"].Select();
                return;
            }

            if (!(isValidSchedule()))
            {
                MessageBox.Show("Invalid schedule for function rooms.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lIsEventManagementDisabled == false)
            {
                if (this.cboSource.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select booking source.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabFolio_.TabPages["tabEventDetails_"].Select();
                    this.cboSource.SelectAll();
                    return;
                }

                if (this.cboEventType.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Please select type of event.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabFolio_.TabPages["tabEventDetails_"].Select();
                    this.cboEventType.SelectAll();
                    return;
                }
            }

            if (this.cboAccountType.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please select account type.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabBooking"].Select();
                this.cboAccountType.SelectAll();
                return;
            }

            if (this.cboPayment_Mode.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please select payment mode.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabBooking"].Select();
                this.cboPayment_Mode.SelectAll();
                return;
            }

            if (this.cboPurpose.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please select purpose of booking.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabBooking"].Select();
                this.cboPurpose.SelectAll();
                return;
            }

            if (this.cboSales_Executive.Text.Trim().Length <= 0 && cboSales_Executive.Text == "")
            {
                //DialogResult rsp = MessageBox.Show("This reservation has no Marketing Officer assigned. \r\nDo you want to continue saving this reservation?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (rsp == DialogResult.No)
                //    return;
                MessageBox.Show("Please select Marketing Officer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSales_Executive.Focus();
                return;
            }


            if (this.nudNumberOfPaxLiveOut.Value > this.nudPaxGuaranteed.Value)
            {
                MessageBox.Show("Minimum pax should be less than maximum pax.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudNumberOfPaxLiveOut.Focus();
                return;
            }

            foreach (C1.Win.C1FlexGrid.Row grdFolioRows in gridFunctionRooms.Rows)
            {
                if (grdFolioRows.Index != 0)
                {
                    DateTime _startDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 3));
                    string _room = gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 0);
                    DateTime _startTime = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 5));
                    DateTime _endDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 4));
                    DateTime _endTime = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 6));
                    for (DateTime _date = _startDate; _date <= _endDate; _date = _date.AddDays(1))
                    {
                        if ((_room != "" && _room != "  ") && (loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _startTime.ToString("HH:mm:ss"), txtFolioID.Text) == true || loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _endTime.ToString("HH:mm:ss"), txtFolioID.Text) == true) && cboStatus.Text != "WAIT LIST")
                        {
                            if (cboStatus.Text != "ONGOING")
                            {
                                if (MessageBox.Show("Conflict in function room schedule: " + _room.ToString() + "\r\nfor Date: " + _date.ToString("yyyy-MM-dd") + " andTime: " + _startTime.ToString("HH:mm") + "-" + _endTime.ToString("HH:mm") + ". \r\n\r\nWARNING: The ENTIRE EVENT ROOMS will be placed under WAIT LIST!! Recommend to delete conflict EVENT SCHEDULE!!\r\nDo you still want to continue and place EVENT in WAIT LIST?", "Conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    cboStatus.Text = "WAIT LIST";
                                    loFolio.Status = "WAIT LIST";
                                    this.btnConfirm.Text = "Set to Tentative";
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Conflict in function room schedule. \r\nPlease check Room Calendar to verify if room is available on that day and time.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    // August 8, 2012
                    // Daniel Balagosa
                    // Filters if wrong date/time heirarchy has been set. Will not save.
                    if (_endTime <= _startTime)
                    {
                        if (_endDate <= _startDate)
                        {
                            MessageBox.Show("Please review Event Schedule Date and Time!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    // End of Edit - August 8, 2012 - Daniel Balagosa
                }
            }

            foreach (C1.Win.C1FlexGrid.Row _row in grdFolioPrivileges.Rows)
            {
                if (_row.Index != 0)
                {
                    string _basis = this.grdFolioPrivileges.GetDataDisplay(_row.Index, 2);

                    if (_basis == "A")
                    {
                        decimal _amount = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(_row.Index, 4));
                        if (_amount <= 0)
                        {
                            MessageBox.Show("Please check amount in Folio Privileges. \nIt should be greater than 0.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    if (_basis == "P")
                    {
                        decimal _percent = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(_row.Index, 3));
                        if (_percent <= 0 || _percent > 100)
                        {
                            MessageBox.Show("Please check percentage amount in Folio Privileges. \nPercent off should be greater than 0 and less than or equal to 100.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                            //this.grdFolioPrivileges.SetData(e.Row, 3, 0);
                        }
                    }
                }
            }

            // DANIEL BALAGOSA 9-5-12
            // CODE BELOW IS START OF DATABASE INSERT/UPDATE TRANSACTIONS

            if ((txtCompanyName.Text != "" || txtLastName.Text != "") && txtGroupName.Text != "")
            {
                if (txtFolioID.Text == "AUTO")
                {
                    lFolioNo = loSequence.getSequenceId("F-", 12, "seq_folio");
                    txtFolioID.Text = lFolioNo;
                }

                if (isBlankAmountFromRecurringCharge() == false)
                {
                    if (checkChildCheckIn())
                    {
                        loFolio.Status = "ONGOING";
                    }
                    //commented next line for adding groups without child folios
                    //by Genny - Apr. 26, 2008
                    //MessageBox.Show("No guests in this group yet. Kindly add guests to this group.","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    //if (MessageBox.Show("Are you sure that you want to save this reservation without Dependent Folios?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    try
                    {
                        saveGroupFolio(ref _oTransaction);
                        if (lIsEventManagementDisabled == false)
                        {
                            saveBookingInfo(ref _oTransaction);
                            //saveDependentFolios();
                            saveEventDetails(ref _oTransaction);
                        }
                        saveChildRoomRequirements(ref _oTransaction);

                        _oTransaction.Commit();
                        
                        AfterSaveAction();
                        MessageBox.Show("Transaction successful. " + "\r\n" + "Event Reservation has been saved", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadFolio();

                        updateCurrentRoomStatus();
                        this.Text = "Group Folio";
                        lEdit = false;
                    }
                    catch (Exception ex)
                    {
                        _oTransaction.Rollback();
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }

                }
                else
                {
                    MessageBox.Show(lMessage, "Group Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No Company and Group name given", "Group Reservation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void updateCompanyInformation()
        {
            // create new guest account
            loCompanyFacade = new CompanyFacade();
            Company _newCompany = new Company();

            _newCompany.ACCOUNT_TYPE = loCompany.ACCOUNT_TYPE;
            _newCompany.CARD_NO = loCompany.CARD_NO;
            _newCompany.City1 = txtCity1.Text;
            _newCompany.City2 = loCompany.City2;
            _newCompany.City3 = loCompany.City3;
            _newCompany.CompanyCode = loCompany.CompanyCode;
            _newCompany.CompanyId = txtcompanyid.Text;
            _newCompany.CompanyName = txtCompanyName.Text;
            _newCompany.CompanyURL = loCompany.CompanyURL;
            _newCompany.ContactNumber1 = txtContactNumber1.Text;
            _newCompany.ContactNumber2 = txtContactNumber2.Text;
            _newCompany.ContactNumber3 = txtContactNumber3.Text;
            _newCompany.ContactPerson = txtContactPerson.Text;
            _newCompany.ContactType1 = "PHONE";
            _newCompany.ContactType2 = "FAX";
            _newCompany.ContactType3 = "MOBILE";
            _newCompany.Country1 = txtCountry1.Text;
            _newCompany.Country2 = loCompany.Country2;
            _newCompany.Country3 = loCompany.Country3;
            _newCompany.Designation = txtDesignation.Text;
            _newCompany.Email1 = txtEmail1.Text;
            _newCompany.Email2 = loCompany.Email2;
            _newCompany.Email3 = loCompany.Email3;
            _newCompany.NO_OF_VISIT = loCompany.NO_OF_VISIT;
            _newCompany.Remarks = loCompany.Remarks;
            _newCompany.Street1 = txtStreet1.Text;
            _newCompany.Street2 = loCompany.Street2;
            _newCompany.Street3 = loCompany.Street3;
            _newCompany.THRESHOLD_VALUE = loCompany.THRESHOLD_VALUE;
            _newCompany.TOTAL_SALES_CONTRIBUTION = loCompany.TOTAL_SALES_CONTRIBUTION;
            _newCompany.X_DEAL_AMOUNT = loCompany.X_DEAL_AMOUNT;
            _newCompany.Zip1 = txtZip1.Text;
            _newCompany.Zip2 = loCompany.Zip2;
            _newCompany.Zip3 = loCompany.Zip3;
            /* Gene
             * 01-Mar-12
             */
            _newCompany.TIN = txtTIN.Text;

            _newCompany.AccountPrivileges = loCompany.AccountPrivileges;

            AccountInformation _oAccountInformation = new AccountInformation();
            _oAccountInformation.AccountID = _newCompany.CompanyId;
            _oAccountInformation.HotelID = GlobalVariables.gHotelId;
            _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

            _newCompany.AccountInformation = _oAccountInformation;
            loCompanyFacade.updateCompanyAccount(txtcompanyid.Text, ref _newCompany);
            //loGuestFacade.updateGuest(ref _newCompany);

            this.loFolio.Company = _newCompany;
        }

        #endregion

        #region SETTING STATUS

        private void btnConfirm_Click()
        {
            // COMMENT 8-28-12
            // DANIEL BALAGOSA
            // Auto-Generate of Reference number in this function
            // Has bug when setting from Tentative to Confirmed in one setting
            // END OF COMMENT

            MySql.Data.MySqlClient.MySqlTransaction _oDBTrans = GlobalVariables.gPersistentConnection.BeginTransaction();
            //try
            //{
            //    FolioFacade _oFolioFacade = new FolioFacade();
            //    _oFolioFacade.confirmFolio(lFolioNo, ref _oDBTrans);

            //    _oDBTrans.Commit();
            //    //ReservationFolioUI.setConfirmed(lFolioNo);
            //    grdFolio.Rows.Count = 1;

            //    GetChildFolios();
            //    lChildFolioStatus = "";
            //    lFolioNo = "0";
            //}
            //catch (Exception ex)
            //{
            //    _oDBTrans.Rollback();
            //    throw new Exception("Transaction failed @ Confirm Folio.\r\n\r\nError message: " + ex.Message);
            //}

            //jlo for apla 6-11-10
            String _rStatus = "";
            _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;

            int _newStatus = getIndex("CONFIRMED", aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                MessageBox.Show("Cannot confirmed reservation because it is already " + _rStatus + ".\nPlease close this reservation form for updates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //jlo

            if (gridFunctionRooms.Rows.Count <= 1)
            {
                FolioFacade _oFolioFacade = new FolioFacade();
                _oFolioFacade.confirmFolio(lFolioNo, ref _oDBTrans);
                MessageBox.Show("Group Reservation should have at least one(1) schedule.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabRooms_"].Select();
                return;
            }

            if (!(isValidSchedule()))
            {
                MessageBox.Show("Invalid schedule for function rooms.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //>> check if there is conflict with other reservations
            foreach (C1.Win.C1FlexGrid.Row grdFolioRows in gridFunctionRooms.Rows)
            {
                if (grdFolioRows.Index != 0)
                {
                    DateTime _startDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 3));
                    string _room = gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 0);
                    DateTime _startTime = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 5));
                    DateTime _endDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 4));
                    DateTime _endTime = DateTime.Parse(gridFunctionRooms.GetDataDisplay(grdFolioRows.Index, 6));
                    for (DateTime _date = _startDate; _date <= _endDate; _date = _date.AddDays(1))
                    {
                        if ((_room != "" && _room != "  ") && (loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _startTime.ToString("HH:mm:ss"), txtFolioID.Text) == true || loFolioFacade.functionIsConflict(_room, _date.ToString("yyyy-MM-dd"), _endTime.ToString("HH:mm:ss"), txtFolioID.Text) == true))
                        {
                            MessageBox.Show("Cannot confirm reservation.\nConflict in function room schedule.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }
            

            //check if contract amount has been endorsed from marketing
            // Clark 08.10.2011
            if (txtContractAmount.Value <= 0)
            {
                MessageBox.Show("Reservation is not yet endorsed by Marketing!", "Endorsement Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult rsp;
            if (ConfigVariables.gDefaultStatusForNewReservation == "TENTATIVE" && loFolio.Status == "WAIT LIST")
            {
                rsp = MessageBox.Show("Are you sure you want to set this reservation to Tentative?",
                       "Confirm",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2);
            }
            else
            {
                rsp = MessageBox.Show("Are you sure you want to set this reservation to Confirmed?",
                                       "Confirm",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2);
            }
            if (rsp == DialogResult.No)
            {
                return;
            }
            
            try
            {
                if (ConfigVariables.gDefaultStatusForNewReservation == "TENTATIVE" && loFolio.Status == "WAIT LIST")
                {
                    GlobalFunctions.protectFolioID(loFolio.FolioID, ref _oDBTrans);           //jc 9.2.09
                    loFolioFacade.tentativeFolio(loFolio.FolioID, ref _oDBTrans);
                    _oDBTrans.Commit();
                    MessageBox.Show("Transaction successful.\r\nReservation status is now Tentative.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    this.cboStatus.Text = "TENTATIVE";
                    this.btnConfirm.Text = "C&onfirm";
                }
                else
                {
                    GlobalFunctions.protectFolioID(loFolio.FolioID, ref _oDBTrans);           //jc 9.2.09
                    loFolioFacade.confirmFolio(loFolio.FolioID, ref _oDBTrans);
                    loFolioFacade.setReferencNo(loFolio.FolioID, loFolio.FromDate.Month, loFolio.FromDate.Year, GlobalVariables.gHotelId);
                    _oDBTrans.Commit();
                    
                    loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                    txtReferenceNo.Text = loFolio.ReferenceNo;
                    this.cboStatus.Text = "CONFIRMED";

                    if (ConfigVariables.gSAPServer != "")
                    {
                        try
                        {
                            addon _integration;
                            if (ConfigVariables.gSAPDBUsername != "" && ConfigVariables.gSAPDBPassword != "" && ConfigVariables.gSAPCompanyDB != "" && ConfigVariables.gSAPUsername != "" && ConfigVariables.gSAPPassword != "")
                            {
                                _integration = new addon(ConfigVariables.gSAPServer, ConfigVariables.gSAPDBUsername, ConfigVariables.gSAPDBPassword, ConfigVariables.gSAPCompanyDB, ConfigVariables.gSAPUsername, ConfigVariables.gSAPPassword);
                            }
                            else
                            {
                                _integration = new addon(ConfigVariables.gSAPServer);
                            }
                            string _error = "";
                            try
                            {
                                string _cardCode = "";
                                if(rdbCompany.Checked)
                                {
                                    _error = "Integration.eventPlusToSAPB1_BP(" + txtCompanyName.Text + ");";
                                    //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    _cardCode = _integration.eventPlusToSAPB1_BP(txtCompanyName.Text);
                                    //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }else
                                {
                                    _error = "Integration.eventPlusToSAPB1_BP(" + txtLastName.Text + ", " + txtFirstName.Text + ");";
                                    //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    _cardCode = _integration.eventPlusToSAPB1_BP(txtLastName.Text + ", " + txtFirstName.Text);
                                    //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                if (_cardCode != "")
                                {
                                    _error = "Inegration.eventPlusToSAPB1_SO(" + _cardCode + ", " + DateTime.Parse(txtCreateTime.Text) + ", " + txtReferenceNo.Text + ", " + loFolio.FromDate + ", " + loFolio.Todate + ", " + txtFolioID.Text + ", " + txtGroupName.Text + ", " + txtcompanyid.Text + ", " + getRoomsForIntegration(0) + ", " + getRoomsForIntegration(2) + ", " + double.Parse(txtContractAmount.Value.ToString()) + ")";
                                    //MessageBox.Show("BEFORE : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if(!_integration.eventPlusToSAPB1_SO(_cardCode, DateTime.Parse(txtCreateTime.Text), txtReferenceNo.Text, loFolio.FromDate, loFolio.Todate, txtFolioID.Text, txtGroupName.Text, txtcompanyid.Text, getRoomsForIntegration(0), getRoomsForIntegration(2), double.Parse(txtContractAmount.Value.ToString())))
                                    {
                                        MessageBox.Show("Sales Order for SAP integration failed. Please check settings for integration." , "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    //MessageBox.Show("AFTER : " + _error, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("SAP Integration did not return a cardcode value.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                _integration.Dispose();
                            }
                            catch (Exception ex)
                            {
                                _integration.Dispose();
                                MessageBox.Show("There was a problem with SAP integration\r\nMethod: " + _error + "\r\nError: " + ex.Message, "Event Plus" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Unable to connect to SAP Server for integration.\r\n Please check the server IP settigns in Event Plus.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                MessageBox.Show("Transaction successful.\r\nReservation status is now Confirmed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                setButtons();

            }
            catch (Exception ex)
            {
                _oDBTrans.Rollback();

                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        private string getRoomsForIntegration(int pColumn)
        {
            string _rooms = "";
            for (int i = 1; i < gridFunctionRooms.Rows.Count; i++)
            {
                if (!_rooms.Contains(gridFunctionRooms.GetDataDisplay(i, pColumn)))
                {
                    _rooms = _rooms + gridFunctionRooms.GetDataDisplay(i, pColumn) + "/";
                }
            }
            if (_rooms != "")
            {
                _rooms = _rooms.Substring(0, _rooms.Length - 1);
            }
            return _rooms;
        }

        private void btnCheckOUt_Click()
        {
            FolioFacade _oFolioFacade = new FolioFacade();
            FolioTransactions _oFolioTransaction = new FolioTransactions();
            _oFolioTransaction = _oFolioFacade.GetFolioTransactions(txtFolioID.Text, "A");

            //if (_oFolioTransaction == null || _oFolioTransaction.Count == 0)
            //{
            //    if (MessageBox.Show("A guest has no posted transactions. Do you want to post transactions?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
            //        if (oPostRoomChargeFacade.initializePostRoomCharges(txtFolioID.Text) == true)
            //        {
            //            MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Transactions are already posted for the day. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            if (loEventFacade.isGroupPackagePosted(txtFolioID.Text) == false)
            {
                PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
                if (oPostRoomChargeFacade.initializePostRoomCharges(txtFolioID.Text) == true)
                {
                    MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Transactions are already posted for the day. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            CheckOutUI _oCheckOutUI = new CheckOutUI(lFolioNo, txtGroupName.Text);
            _oCheckOutUI.MdiParent = this.MdiParent;
            _oCheckOutUI.Show();
        }

        private void btnCancel_Click()
        {
            Folio _oFolio = new Folio();
            FolioFacade _oFolioFacade = new FolioFacade();
            _oFolio.Status = "CANCELLED";
            _oFolio.FolioID = lFolioNo;

            _oFolioFacade.updateFolio(_oFolio);
            loRoomEventFacade.CancelRoomEvents(lFolioNo, "RESERVATION", "CANCELLED");
            lChildFolioStatus = "";
            lFolioNo = "0";
        }

        private void btnCancelReservation_Click()
        {
            //if (MessageBox.Show("You have made changes to this reservation, \n Do you want to continue", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (btnCancelReservation.Text == "C&ancel")
            {
                //this.Close();
                if (MessageBox.Show("You have made changes to this reservation, \n Do you want to continue", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    AfterSaveAction();
                    loadFolio();

                    updateCurrentRoomStatus();
                    this.Text = "Group Folio";
                    lEdit = false;
                }
            }
            else if (btnCancelReservation.Text == "C&ancel Rsvn")
            {
                MySql.Data.MySqlClient.MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
                FolioFacade oFolioFacade = new FolioFacade();
                if (MessageBox.Show("Action will Cancel the Reservation including the Sub Folios,\n Do You want to continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oFolioFacade.CheckStatusToCancel(txtFolioID.Text) == true)
                    {
                        loFolio.Status = "CANCELLED";
                        //loFolio = oFolioFacade.GetFolio(folioID);

                        bool hasBalance = false;

                        loFolio.CreateSubFolio();
                        decimal balance = 0;
                        foreach (SubFolio subF in loFolio.SubFolios)
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
                            MessageBox.Show("Transaction failed.\r\n\r\nGuest still has unsettled account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        //>>by Genny: Apr. 29, 2008
                        //for cancellation purposes
                        ReasonForCancelUI reasonUI = new ReasonForCancelUI();
                        string reason = reasonUI.showDialog();
                        string reasonType = reasonUI.getReason();
                        string bookingType = reasonUI.getBookingType();

                        if (reason == "" && reasonType == "" && bookingType == "")
                            return;

                        //update folio status to cancelled
                        oFolioFacade.setFolioStatus(txtFolioID.Text, "CANCELLED", reason, reasonType, bookingType);
                        //oFolioFacade.updateFolio(oFolio);
                        //update group's dependent folios to cancelled
                        oFolioFacade.SetChildFolioStatus(txtFolioID.Text, "CANCELLED", reason);

                        //cancell group's room events and also its child's room events
                        RoomEventFacade oRoomEventFacade = new RoomEventFacade();
                        oRoomEventFacade.CancelRoomEvents(txtFolioID.Text, "RESERVATION", "CANCELLED");
                        DataTable getChildFolio = oFolioFacade.GetChildFoliosTable(txtFolioID.Text);
                        if (getChildFolio.Rows.Count > 0)
                        {
                            DataRow dtRows;
                            foreach (DataRow tempLoopVar_dtRows in getChildFolio.Rows)
                            {
                                dtRows = tempLoopVar_dtRows;
                                string foliono = dtRows["FolioID"].ToString();
                                oRoomEventFacade.CancelRoomEvents(foliono, "RESERVATION", "CANCELLED");

                                //jlo 6-9-2010 cancel joiners
                                oFolioFacade.updateJoinerAllFolioStatus("CANCELLED", foliono);
                                //jlo
                            }
                        }

                        //unblock rooms that are blocked for that group
                        RoomBlockFacade _oRoomBlockFacade = new RoomBlockFacade();
                        string _event = txtFolioID.Text;
                        GenericList<RoomBlock> _oRoomBlockList = _oRoomBlockFacade.getBlockedRoomsForEvent(_event);
                        foreach (RoomBlock _oRoomBlock in _oRoomBlockList)
                        {
                            _oRoomBlockFacade.deleteRoomBlockedByEvent(_oRoomBlock.RoomID, txtFolioID.Text, ref trans);
                        }
                        //<<

                        trans.Commit();
                        updateCurrentRoomStatus();
                        this.Close();
                    }
                }
            }
        }

        private void btnCheckIN_Click()
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

            if (cboStatus.Text == "WAIT LIST" || cboStatus.Text == "TENTATIVE")
            {
                MessageBox.Show("Cannot check-in reservation. \nStatus is " + cboStatus.Text + ".\n\nYou must confirm reservation first before checking-in.", "Check-In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DateTime.Parse(loFolio.FromDate.ToString("yyyy-MM-dd")) <= DateTime.Parse(GlobalVariables.gAuditDate))
            {
                DialogResult rsp = MessageBox.Show("Folio will now be ONGOING.\r\n\r\nAre you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool _isCheckedIn = false;

                if (rsp == DialogResult.Yes)
                {
                    FolioFacade _oFolioFacade = new FolioFacade();
                    string _folioNo = txtFolioID.Text;
                    Folio _oFolio = new Folio();
                    _oFolio = _oFolioFacade.GetFolio(_folioNo);

                    if (_oFolio.Schedule.Count <= 0)
                    {
                        if (_oFolioFacade.checkInFolio(_folioNo, ""))
                        {
                            _isCheckedIn = true;
                        }
                    }
                    else
                    {
                        foreach (Schedule _oSchedule in _oFolio.Schedule)
                        {
                            //operator changed from == to <= , to allow previous event to start
                            // Clark 08.10.2011
                            if (_oSchedule.FromDate <= DateTime.Parse(GlobalVariables.gAuditDate))
                            {
                                if (_oFolioFacade.checkInFolio(_folioNo, _oSchedule.RoomID))
                                {
                                    _isCheckedIn = true;
                                }
                            }
                            else if (_oSchedule.FromDate > DateTime.Parse(GlobalVariables.gAuditDate))
                            {
                                DialogResult response = MessageBox.Show("Transaction failed.\r\n\r\nScheduled date is on " + string.Format("{0:ddd. MMM dd, yyyy}", _oSchedule.FromDate) + ".\r\n\r\n\r\nWould you like to change it to current date ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                                if (response == DialogResult.Yes)
                                {
                                    foreach (Schedule _oSchedule2 in _oFolio.Schedule)
                                    {
                                        if (_oFolioFacade.checkInFolio(_folioNo, _oSchedule2.RoomID))
                                        {
                                            _isCheckedIn = true;
                                        }
                                    }

                                    break;
                                }
                            }
                        }
                    }
                }

                if (_isCheckedIn)
                {
                    MessageBox.Show("Transaction successful.\r\nEvent is now Ongoing", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //loadFolio();
                    lGroupFolioStatus = "Old";
                    loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                    GroupReservationUI_Load();
                    cboStatus.Text = "ONGOING";

                    updateCurrentRoomStatus();
                    setButtons();
                }
            }
            else
            {
                MessageBox.Show("Event date is greater than the current audit date.\r\n Change first the event dates of the group before check in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void setNOSHOW(string mfolioID)
        {
            FolioFacade _oFolioFacade = new FolioFacade();
            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
            ScheduleFacade _oSchedulefacade = new ScheduleFacade();
            Folio _oFolio = new Folio();
            RoomEvents _oRoomEvents = new RoomEvents();
            _oRoomEvents.EventType = "NO SHOW";
            _oFolio.Status = "NO SHOW";
            _oFolio.FolioID = mfolioID;
            _oFolioFacade.updateFolio(_oFolio);
            _oFolioFacade.SetRoomStatusAftertoVacant(ref mfolioID);
            _oRoomEventFacade.CancelRoomEvents(mfolioID, "RESERVATION", "NO SHOW");
            //MsgBox("Reservation NO. " & mfolioID & " has been set to NO SHOW")
            //GetListReservationList("where _status ='NO SHOW' and _fromDate='" & Format(_fromDate, "yyyy-MM-dd") & "' and foliotype='INDIVIDUAL'")
        }

        #endregion
        
        #region INDIVIDUAL ACCOUNT

        private void rdbCompany_CheckedChanged(object sender, EventArgs e)
		{
            if (lEdit == true)
            {
                if (rdbCompany.Checked)
                {
                    pnlIndividual.Visible = false;
                    pnlIndividual.SendToBack();

                    pnlCompany.Visible = true;
                    pnlCompany.BringToFront();
                    txtcompanyid.Text = "";
                    txtLastName.Text = "";
                    txtFirstName.Text = "";
                    txtCompanyName.Focus();
                    cboAccountType.Text = "CORPORATE";
                    cboPurpose.Text = "BUSINESS";

                    foreach (Control _ctrl in grpInfo.Controls)
                    {
                        if (_ctrl is TextBox)
                        {
                            _ctrl.Text = "";
                        }
                    }

                    lvwGuestPrivileges.Items.Clear();
                    grdFolioPrivileges.Rows.Count = 1;
                    rdoApplyGuestPrivilege.Checked = false;
                    rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && !loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get company privileges
                    //rdoApplyCompanyPrivileges.Checked = true;
                }
                else
                {
                    pnlCompany.Visible = false;
                    pnlCompany.SendToBack();

                    pnlIndividual.Visible = true;
                    pnlIndividual.BringToFront();
                    txtcompanyid.Text = "";
                    txtCompanyName.Text = "";
                    txtLastName.Focus();
                    cboAccountType.Text = "PERSONAL";
                    cboPurpose.Text = "PARTY";

                    foreach (Control _ctrl in grpInfo.Controls)
                    {
                        if (_ctrl is TextBox)
                        {
                            _ctrl.Text = "";
                        }
                    }

                    lvwCompanyPrivileges.Items.Clear();
                    grdFolioPrivileges.Rows.Count = 1;
                    rdoApplyGuestPrivilege.Checked = false;
                    rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get guest privileges
                    //rdoApplyGuestPrivilege.Checked = true;
                }
            }
            else
            {
                if (rdbCompany.Checked)
                {
                    pnlIndividual.Visible = false;
                    pnlIndividual.SendToBack();

                    pnlCompany.Visible = true;
                    pnlCompany.BringToFront();
                    txtcompanyid.Text = "";
                    txtLastName.Text = "";
                    txtFirstName.Text = "";
                    txtCompanyName.Focus();
                    cboAccountType.Text = "CORPORATE";
                    cboPurpose.Text = "BUSINESS";

                    foreach (Control _ctrl in grpInfo.Controls)
                    {
                        if (_ctrl is TextBox)
                        {
                            _ctrl.Text = "";
                        }
                    }

                    lvwGuestPrivileges.Items.Clear();
                    grdFolioPrivileges.Rows.Count = 1;
                    rdoApplyGuestPrivilege.Checked = false;
                    rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && !loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get company privileges
                    //rdoApplyCompanyPrivileges.Checked = true;
                }
                else
                {
                    pnlCompany.Visible = false;
                    pnlCompany.SendToBack();

                    pnlIndividual.Visible = true;
                    pnlIndividual.BringToFront();
                    txtcompanyid.Text = "";
                    txtCompanyName.Text = "";
                    txtLastName.Focus();
                    cboAccountType.Text = "PERSONAL";
                    cboPurpose.Text = "PARTY";

                    foreach (Control _ctrl in grpInfo.Controls)
                    {
                        if (_ctrl is TextBox)
                        {
                            _ctrl.Text = "";
                        }
                    }

                    lvwCompanyPrivileges.Items.Clear();
                    grdFolioPrivileges.Rows.Count = 1;
                    rdoApplyGuestPrivilege.Checked = false;
                    rdoApplyCompanyPrivileges.Checked = false;

                    if (loFolio.CompanyID != null && loFolio.CompanyID.StartsWith("G"))
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }
                    //get guest privileges
                    //rdoApplyGuestPrivilege.Checked = true;
                }
            }
		}

		private void txtLastName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (this.lvwBrowseGuestName.Visible)
				{
					this.lvwBrowseGuestName.Select();
				}
			}
		}

		private void txtLastName_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (this.txtLastName.Text.Trim().Length <= 0)
			{
				this.lvwBrowseGuestName.Visible = false;
                dtView = null;
				return;
			}
			else if (this.txtLastName.Text.Trim().Length > 0 && txtLastName.Focused == true)
			{
				loadList(GlobalFunctions.removeQuotes(this.txtLastName.Text), "");
			}
		}

		public DataView getRec()
		{
			try
			{
                //Guest oGuest = new Guest();
                //GuestFacade oGuestFacade = new GuestFacade();
                //oGuest = oGuestFacade.getGuests();

                //DataView dtView = oGuest.Tables[0].DefaultView;
                //return dtView;

                DataTable _oDataTable = new DataTable();
                GuestFacade oGuestFacade = new GuestFacade();

                //_oDataTable = oGuestFacade.getGuestAccounts();
                _oDataTable = oGuestFacade.getGuestAccount(txtFirstName.Text, txtLastName.Text);
                DataView dtView = _oDataTable.DefaultView;

                return dtView;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		DataView dtView;
		private object loadList(string a_LastName, string a_FirstName)
		{
			try
			{
                if (dtView == null)
                {
                    dtView = getRec();
                }

				dtView.RowStateFilter = DataViewRowState.OriginalRows;
                dtView.RowFilter = "LastName like '" + a_LastName + "%' and FirstName like '" + a_FirstName + "%'";
                dtView.Sort = "Lastname, Firstname";

				DataRowView dtr;
				this.lvwBrowseGuestName.Items.Clear();
				foreach (DataRowView tempLoopVar_dtr in dtView)
				{
					dtr = tempLoopVar_dtr;
					ListViewItem li = new ListViewItem(dtr["AccountId"].ToString());
					li.SubItems.Add(dtr["LastName"].ToString());
					li.SubItems.Add(dtr["FirstName"].ToString());
					this.lvwBrowseGuestName.Items.Add(li);
				}

				if (dtView.Count <= 0)
				{
					this.lvwBrowseGuestName.Visible = false;
					this.txtcompanyid.Text = "";
				}
				else
				{
                    this.lvwBrowseGuestName.Location = new System.Drawing.Point(txtLastName.Location.X, txtLastName.Location.Y + 125);
					this.lvwBrowseGuestName.Visible = true;
				}

				return null;
			}
			catch
			{
				return null;
			}
		}

		private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (this.lvwBrowseGuestName.Visible)
				{
					this.lvwBrowseGuestName.Select();
				}
			}
		}

		private void txtFirstName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				getGuest();
			}
		}

		private string mAccountID = "";
		private void assignGuestID()
		{
			Sequence sequence = new Sequence();
			string seqID = sequence.getSequenceId("I-", 12, "seq_guest");
			mAccountID = seqID;
		}

		private void confirmSaveGuest()
		{
			if (!(this.txtLastName.Text == "" || this.txtFirstName.Text == ""))
			{
				saveGuestConfirmation = "YES";
				assignGuestID();
				loGuestFacade = new GuestFacade();
				oGuest.AccountId = mAccountID; ;
				oGuest.LastName = this.txtLastName.Text;
				oGuest.FirstName = this.txtFirstName.Text;
                oGuest.MiddleName = "";
				oGuest.Title = "";
				oGuest.Sex = "";
				oGuest.Remark = "";
				oGuest.AccountName = this.txtLastName.Text + "_" + this.txtFirstName.Text;
				oGuest.TelephoneNo = "";
				oGuest.Street = "";
				oGuest.City = "";
				oGuest.Country = "";
				oGuest.Zip = "";
				oGuest.PassportId = "";
				oGuest.Citizenship = "";
				oGuest.MobileNo = "";
				oGuest.FaxNo = "";
				oGuest.EmailAddress = "";
				oGuest.Remark = "";
				oGuest.BIRTH_DATE = DateTime.Parse(txtCreateTime.Text);
				oGuest.THRESHOLD_VALUE = 0;
                oGuest.ACCOUNT_TYPE = "WALK-IN";
                oGuest.CARD_NO = "";
                oGuest.CompanyID = "";
                oGuest.Concierge = "";
                oGuest.CreditCardNo = "";
                oGuest.CreditCardType = "";
                oGuest.GuestImage = "";
                oGuest.Memo = "";
                oGuest.NoOfVisits = 0;
                oGuest.TaxExempted = 0;


				oGuest.HotelID = GlobalVariables.gHotelId;
				oGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
				oGuest.UpdatedBy = GlobalVariables.gLoggedOnUser;

                AccountInformation _oAccountInformation = new AccountInformation();
                _oAccountInformation.AccountID = oGuest.AccountId;
                _oAccountInformation.HotelID = GlobalVariables.gHotelId;
                _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

                oGuest.AccountInformation = _oAccountInformation;

				loGuestFacade.insertGuest(ref oGuest);
				this.txtcompanyid.Text = mAccountID;

				saveGuestConfirmation = "NO";
			}
		}

		private Guest oGuest = new Guest();
		private bool guestnotfound;
		private void getGuest()
		{
			if (lFlag == "New" || lFlag == "Edit")
			{
				if (checkGuestAvailability())
				{
					guestnotfound = false;
					loGuestFacade = new GuestFacade();
					this.txtcompanyid.Text = oGuest.Tables["Guests"].Rows[0]["AccountID"].ToString();
				}
				else
				{

					if (saveGuestConfirmation == "NO" && lvwBrowseGuestName.Visible == false)
					{
						confirmSaveGuest();
					}

				}
				//btnSaveGuest.Visible = true;
			}
			else
			{
				guestnotfound = true;
			}

		}

		private bool checkGuestAvailability()
		{
			if (countGuestRows() == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		private string saveGuestConfirmation = "NO";
		private int countGuestRows()
		{
			loGuestFacade = new GuestFacade();
			oGuest = loGuestFacade.filterGuestRecordRefName(GlobalFunctions.removeQuotes(this.txtLastName.Text), GlobalFunctions.removeQuotes(this.txtFirstName.Text), "");
			return oGuest.Tables["Guests"].Rows.Count;
		}

		private void txtFirstName_TextChanged(object sender, EventArgs e)
		{
			if (this.txtFirstName.Text.Trim().Length <= 0)
			{
				this.lvwBrowseGuestName.Visible = false;
                dtView = null;
				return;
			}
			else if (this.txtFirstName.Text.Trim().Length > 0 && txtFirstName.Focused == true)
			{
				loadList(GlobalFunctions.removeQuotes(this.txtLastName.Text), GlobalFunctions.removeQuotes(this.txtFirstName.Text));
			}
		}

		private void lvwBrowseGuestName_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				string accountId = this.lvwBrowseGuestName.SelectedItems[0].Text;

				if (accountId.Trim().Length > 0)
				{

					this.txtcompanyid.Text = accountId;
					this.lvwBrowseGuestName.Visible = false;
				}
			}
			catch { }
		}

		private void lvwBrowseGuestName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				lvwBrowseGuestName_DoubleClick(sender, new EventArgs());
			}
			else if (e.KeyChar == System.Convert.ToChar(Keys.Escape))
			{
				this.lvwBrowseGuestName.Visible = false;
			}
		}

		private void lvwBrowseGuestName_Leave(object sender, EventArgs e)
		{
			this.cboAccountType.Focus();
		}

		private void txtMiddleName_Enter(object sender, EventArgs e)
		{
			this.lvwBrowseGuestName.Visible = false;
		}

		private void txtFirstName_Leave(object sender, EventArgs e)
		{
			getGuest();
		}

		#endregion

		#region FOLIO PACKAGES

        // >> Assign FolioPackage
        private IList<FolioPackage> assignFolioPackage(Folio oFolio)
        {
            IList<FolioPackage> _oFolioPackage = new List<FolioPackage>();

            for (int i = 1; i < this.grdFolioPackage.Rows.Count; i++)
            {
                FolioPackage _newFolioPackage = new FolioPackage();

                _newFolioPackage.HotelID = loFolio.HotelID;
                _newFolioPackage.FolioID = loFolio.FolioID;
                _newFolioPackage.TransactionCode = this.grdFolioPackage.GetDataDisplay(i, 0);
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

        //private void loadPackageDetails()
        //{
        //    this.txtPackageName.Text = this.txtpackageID.Text;

        //    FolioDAO _oFolioDAO = new FolioDAO();
        //    DataTable dt = _oFolioDAO.GetPackageDetails(txtpackageID.Text);

        //    lvwPackageDetails.Items.Clear();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ListViewItem lvwItem = new ListViewItem(dr["transactionCode"].ToString());
        //        lvwItem.SubItems.Add(dr["memo"].ToString());
        //        lvwItem.SubItems.Add(dr["basis"].ToString());
        //        lvwItem.SubItems.Add(dr["percentoff"].ToString());
        //        lvwItem.SubItems.Add(dr["amountoff"].ToString());

        //        lvwPackageDetails.Items.Add(lvwItem);

        //        this.txtDaysApplied.Text = dr["daysApplied"].ToString();
        //    }
        //}

		//>>this is to compute the total package amount if a listview item is added into the lvwRecurredCharge
		private void computePackageAmount()
		{
			double _packageAmount = 0;

			foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
			{
				if (_row.Index != 0)
				{
                    DateTime _from = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 11));
                    DateTime _to = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 12));
                    TimeSpan _d = _to.Subtract(_from);
                    int _diff = _d.Days + 1;
					_packageAmount += (double.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 10)) * Math.Abs(_diff));
				}
			}

			txtPackageAmount.Text = string.Format("{0:###,##0.#0}", _packageAmount);
			getTotalEstimatedCost();
		}

		#endregion

		#region FUNCTION ROOMS

        private void gridFunctionRooms_GridChanged(object sender, C1.Win.C1FlexGrid.GridChangedEventArgs e)
        {
            try
            {
                dtpFromDate.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(1, 3));
                dtpTodate.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 4));
                txtArrivalDate.Text = dtpFromDate.Value.ToShortDateString();
                txtDepartureDate.Text = dtpTodate.Value.ToShortDateString();

                dtpFolioETA.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(1, 5));
                dtpFolioETD.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 6));
            }
            catch { }
        }

        private void gridFunctionRooms_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuDelete.Enabled = true;
                    this.mnuAddItem.Enabled = true;
                    mnuSchedule.Show(this.gridFunctionRooms, point);
                }
                //else
                //{
                //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode");
                //}
            }
            catch (Exception)
            {

            }
        }

        private void mnuAddItem_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            DateTime fromDate = DateTime.Parse(GlobalVariables.gAuditDate);
            DateTime toDate = fromDate.AddDays(1);

            int i = this.gridFunctionRooms.Rows.Count;
            this.gridFunctionRooms.Rows.Count += 1;

            //Gene - 9/8/2011
            this.gridFunctionRooms.Cols[9].Editor = lSetup;
            this.gridFunctionRooms.Cols[10].Editor = lActivity;

            // set folio schedule grid
            if (gridFunctionRooms.Rows.Count <= 2)
            {
                this.gridFunctionRooms.SetData(i, 0, ""); // room no
                this.gridFunctionRooms.SetData(i, 1, "FUNCTION"); //room type
                this.gridFunctionRooms.SetData(i, 2, ""); //room name
                this.gridFunctionRooms.SetData(i, 3, fromDate.Date); //from date
                this.gridFunctionRooms.SetData(i, 4, toDate.Date); //end date
                this.gridFunctionRooms.SetData(i, 5, "08:00 AM"); // time start
                this.gridFunctionRooms.SetData(i, 6, "05:00 PM"); // time end
                this.gridFunctionRooms.SetData(i, 7, "REGULAR"); // rate type
                this.gridFunctionRooms.SetData(i, 8, 0.00); // rate amount
                //this.gridFunctionRooms.SetData(i, 9, "");// venue

                //Gene - 9/8/2011
                //this.gridFunctionRooms.SetData(i, 9, "");// setup
                //this.gridFunctionRooms.SetData(i, 10, "");// remarks or activity

                this.gridFunctionRooms.SetData(i, 11, "0");// guaranteed pax
                this.gridFunctionRooms.SetData(i, 12, "");//remarks
            }
            else
            {
                this.gridFunctionRooms.SetData(i, 0, ""); // room no
                this.gridFunctionRooms.SetData(i, 1, "FUNCTION"); //room type
                this.gridFunctionRooms.SetData(i, 2, ""); //room name
                this.gridFunctionRooms.SetData(i, 3, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 3)); //from date
                this.gridFunctionRooms.SetData(i, 4, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 4)); //end date
                this.gridFunctionRooms.SetData(i, 5, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 5)); // time start
                this.gridFunctionRooms.SetData(i, 6, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 6)); // time end
                this.gridFunctionRooms.SetData(i, 7, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 7)); // rate type
                this.gridFunctionRooms.SetData(i, 8, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 8)); // rate amount
                //this.gridFunctionRooms.SetData(i, 9, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 9));// venue
                this.gridFunctionRooms.SetData(i, 9, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 9));// setup
                this.gridFunctionRooms.SetData(i, 10, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 10));// remarks or activity
                this.gridFunctionRooms.SetData(i, 11, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 11));// guaranteed pax
                this.gridFunctionRooms.SetData(i, 12, gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 2, 12));//remarks
            }
        }

        private void gridFunctionRooms_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            DateTime TimeTo = DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 6));
            if (e.Col == 3 || e.Col == 4)
            {
                if (DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, e.Col)) < DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    MessageBox.Show("Cannot change to selected date. \nEither date is already charged or is less than the current date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    gridFunctionRooms.SetData(e.Row, e.Col, DateTime.Parse(GlobalVariables.gAuditDate));
                }
                else
                {
                    dtpFromDate.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(1, 3));
                    dtpTodate.Value = DateTime.Parse(gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 4));
                    txtArrivalDate.Text = dtpFromDate.Value.ToShortDateString();
                    txtDepartureDate.Text = dtpTodate.Value.ToShortDateString();

                    //for changing of event package dates
                    foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
                    {
                        if (_row.Index != 0)
                        {
                            if (grdRecurredCharge.GetCellCheck(_row.Index, 0) == CheckEnum.Checked)
                            {
                                grdRecurredCharge.SetData(_row.Index, 11, dtpFromDate.Value);
                                grdRecurredCharge.SetData(_row.Index, 12, dtpFromDate.Value);
                            }
                        }
                    }
                }
            }
            if ((e.Col == 5 || e.Col == 6) && (DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 3)) == DateTime.Parse(GlobalVariables.gAuditDate) && DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 4)) == DateTime.Parse(GlobalVariables.gAuditDate)))
            {
                if (DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, e.Col)) < DateTime.Now)
                {
                    MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current date/time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    gridFunctionRooms.SetData(e.Row, e.Col, DateTime.Now.ToShortTimeString());
                }
            }
            else if (e.Col == 7)
            {
                RateTypeFacade _oRateTypeFacade = new RateTypeFacade();
                string _rateType = gridFunctionRooms.GetDataDisplay(e.Row, e.Col);
                decimal _amount = _oRateTypeFacade.getRateTypeAmount(_rateType, gridFunctionRooms.GetDataDisplay(e.Row, 12));
                gridFunctionRooms.SetData(e.Row, 8, _amount);
            }
            else if (e.Col == 0)
            {
                try
                {
                    Room _oRoom = new Room();
                    RoomFacade _oRoomFacade = new RoomFacade();
                    _oRoom = _oRoomFacade.getRoom(gridFunctionRooms.GetDataDisplay(e.Row, 0));
                    gridFunctionRooms.SetData(e.Row, 1, _oRoom.RoomTypecode);
                    gridFunctionRooms.SetData(e.Row, 2, _oRoom.RoomDescription);
                    //gridFunctionRooms.SetData(e.Row, 12, _oRoom.RoomTypecode);
                }
                catch { }
            }

            if (e.Col == 3)
            {
                try
                {
                    gridFunctionRooms.SetData(e.Row, 4, gridFunctionRooms.GetData(e.Row, e.Col));
                }
                catch { }
            }

			//addMeallDates();	

            //Gene - 9/8/2011
            gridFunctionRooms.AutoSizeCol(1);
            gridFunctionRooms.AutoSizeCol(2);
            gridFunctionRooms.AutoSizeRows();
        }

		private void addMeallDates()
		{
			//// THIS IS FOR MEAL REQUIREMENTS
			DateTime _startDate = DateTime.Parse(GlobalVariables.gAuditDate);
			DateTime _endDate = DateTime.Parse(GlobalVariables.gAuditDate);
            //for (int i = 1; i < this.gridFunctionRooms.Rows.Count; i++)
            //{
            //    try
            //    {
            //        if (i == 1)
            //        {
            //            _startDate = dtpFromDate.Value;
            //        }

            //        _endDate = dtpTodate.Value;
            //    }
            //    catch { }
            //}

            _startDate = dtpFromDate.Value;
            _endDate = dtpTodate.Value;

			long _days = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, _startDate, _endDate);
			for (int d = 0; d <= _days; d++)
			{
				bool isAdded = false;

				foreach (TreeNode tvwNode in treeFoodBev.Nodes)
				{
					if (tvwNode.Text == _startDate.AddDays(d).ToShortDateString())
					{
						isAdded = true;
						break;
					}
				}

				if (!isAdded)
				{
					this.treeFoodBev.Nodes.Add(_startDate.AddDays(d).ToShortDateString());
				}
			}
			//// end MEAL REQUIREMENTS
		}

		private void gridFunctionRooms_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            switch (e.Col)
            {
                case 5:
                    dtpTime.Value = DateTime.Parse("08/08/2008 08:00:00 AM");

                    gridFunctionRooms.Cols[e.Col].Editor = dtpTime;
                    break;
                case 6:
                    dtpTime.Value = DateTime.Parse("08/08/2008 05:00:00 PM");

                    gridFunctionRooms.Cols[e.Col].Editor = dtpTime;
                    break;

                case 9:
                    gridFunctionRooms.Cols[e.Col].Editor = lSetup;
                    break;
                    //Gene 9/8/2011
                //case 10:
                //    gridFunctionRooms.Cols[e.Col].Editor = lActivity;
                //    break;

                default:
                    break;
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lEdit == false && lFlag == "Edit")
                {
                    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (gridFunctionRooms.Rows.Count <= 2)
                {
                    MessageBox.Show("Reservation should have at least one schedule.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    gridFunctionRooms.Rows.Remove(gridFunctionRooms.Row);
                }
            }
            catch { }
        }

        ComboBox lCboFunctionRooms = new ComboBox();
		private void gridFunctionRooms_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			if (e.Col == 0)
			{
				RoomFacade _oRoomFacade = new RoomFacade();
				ArrayList _roomList = new ArrayList();
				_roomList = _oRoomFacade.getRoomsByRoomSuperType("FUNCTION");
                _roomList.Insert(0, "  ");
				lCboFunctionRooms.DisplayMember = "RoomID";
				lCboFunctionRooms.ValueMember = "RoomID";
				lCboFunctionRooms.DataSource = _roomList;
                lCboFunctionRooms.DropDownStyle = ComboBoxStyle.DropDownList;

				gridFunctionRooms.Cols[e.Col].Editor = lCboFunctionRooms;
			}
            else if (e.Col == 3 || e.Col == 4)
            {
                /*
                DateFrom = DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 3));
                DateTo = DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 4));
                */
            }
            else if (e.Col == 5 || e.Col == 6)
            {
                gridFunctionRooms.Cols[e.Col].Editor = dtpTime;
                /*
                TimeFrom = DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 5));
                TimeTo = DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 6));

                if (DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 6)) <= DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 5)))
                {
                    MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    e.Cancel = true;
                }
                */
            }
            else if (e.Col == 7)
            {
                cboRateType.Items.Clear();
                //>>to display all rate types
                RateTypeFacade _oRateTypeFacade = new RateTypeFacade();
                IList<RateType> _oRateTypeList = _oRateTypeFacade.getRateTypeList();
                //foreach (RateType _oRateType in _oRateTypeList)
                //{
                //    string type = gridFunctionRooms.GetDataDisplay(e.Row, 12);
                //    if (_oRateType.RoomTypeCode == gridFunctionRooms.GetDataDisplay(e.Row, 12))
                //    {
                //        cboRateType.Items.Add(_oRateType.RateCode);
                //    }
                //}

                gridFunctionRooms.Cols[7].Editor = cboRateType;
            }
            else if (e.Col == 9)
            {
                gridFunctionRooms.Cols[e.Col].Editor = lSetup;
            }
            //Gene - 9/8/2011
            else if (e.Col == 10)
            {
                gridFunctionRooms.Cols[e.Col].Editor = lActivity;
            }
		}

		#endregion

		#region FOLIO ROUTING

        private void btnRemoveCharge_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (mFolioRoutingCollection != null)
            {
                if (mFolioRoutingCollection.Count > 0)
                {
                    DialogResult rsp = MessageBox.Show("Remove billing information?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rsp == DialogResult.No)
                    {
                        return;
                    }

                    FolioRouting[] r = new FolioRouting[mFolioRoutingCollection.Count];
                    mFolioRoutingCollection.CopyTo(r, 0);

                    foreach (FolioRouting _oFolioRouting in r)
                    {
                        if (_oFolioRouting.TransactionCode == this.txtBICode.Text)
                        {
                            mFolioRoutingCollection.Remove(_oFolioRouting);

                            int _row = this.gridTransactionCodes.Row;
                            this.gridTransactionCodes.Rows[_row].Style = this.gridTransactionCodes.Styles["Normal"];

                        }
                    }

                    try
                    {
                        this.gridTransactionCodes.Row += 1;
                    }
                    catch
                    { }

                }

            }
        }
        
        private bool isBlankAmountFromRecurringCharge()
		{
			foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
			{
				if (_row.Index != 0)
				{
					string _amount = grdRecurredCharge.GetDataDisplay(_row.Index,10);
					if (_amount == "")
					{
						lMessage = "Please Check The Amount in Folio Recurring Charge";
						return true;
					}
				}
			}

			return false;
		}

		//>>for displaying all the transaction codes in gridTransactionCodes
		private void getCharges(C1.Win.C1FlexGrid.C1FlexGrid grid)
		{
			int i;
			TransactionCodeFacade oTransactionCodesDAO = new TransactionCodeFacade();
			DataSet ds = (DataSet)oTransactionCodesDAO.loadObject();
			DataTable dt = ds.Tables[0];

			grid.Rows.Count = 1;
			foreach (DataRow dRow in dt.Rows)
			{
				if (dRow["acctside"].ToString() == "DEBIT")
				{
					i = grid.Rows.Count;
					grid.Rows.Count++;

					grid.SetData(i, 0, dRow["trancode"].ToString());
					grid.SetData(i, 1, dRow["memo"].ToString());
				}
			}

		}

		private string code = "";
		private string charge = "";
		private void loadNewBillingInfo()
		{
			string[] x = new string[] { "A-Personal", "B-Company", "C-Others", "D-Others" };
			//lvwBillingCharge.Items.Clear()


			this.gridBillingInfo.Rows.Count = 1;

			string str;
			foreach (string tempLoopVar_str in x)
			{
				str = tempLoopVar_str;

				this.gridBillingInfo.Rows.Count++;

				this.gridBillingInfo.SetData(this.gridBillingInfo.Rows.Count - 1, 0, str);
				this.gridBillingInfo.SetData(this.gridBillingInfo.Rows.Count - 1, 1, "P");
				this.gridBillingInfo.SetData(this.gridBillingInfo.Rows.Count - 1, 2, "0");
				this.gridBillingInfo.SetData(this.gridBillingInfo.Rows.Count - 1, 3, "0");

			}
		}

		//>>for getting the billing charges for a specific transaction code
		private void loadBillingInstruction()
		{
            if (gridTransactionCodes.Rows.Count > 1)
            {
                code = this.gridTransactionCodes.GetDataDisplay(this.gridTransactionCodes.Row, 0);

                charge = this.gridTransactionCodes.GetDataDisplay(this.gridTransactionCodes.Row, 1);
                this.txtBICode.Text = code;
                this.txtBIMemo.Text = charge;

                getFolioRoutingDetails(txtFolioID.Text, code);
                //End If

                if (this.gridBillingInfo.Rows.Count == 1)
                {
                    loadNewBillingInfo();
                }
            }
		}

		private void gridTransactionCodes_Click(object sender, EventArgs e)
		{
			loadBillingInstruction();
		}

		private void getFolioRoutingDetails(string vfolioID, string tcode)
		{
			this.gridBillingInfo.Rows.Count = 1;

			FolioRouting oFolioRouting;
			foreach (FolioRouting tempLoopVar_oFolioRouting in mFolioRoutingCollection)
			{
				oFolioRouting = tempLoopVar_oFolioRouting;
				if (oFolioRouting.TransactionCode == this.gridTransactionCodes.GetDataDisplay(this.gridTransactionCodes.Row, 0))
				{
					int i = this.gridBillingInfo.Rows.Count;
					this.gridBillingInfo.Rows.Count++;
                    string code = "";
                    switch (i)
                    {
                        case 1:
                            code = "-Personal";
                            break;
                        case 2:
                            code = "-Company";
                            break;
                        default:
                            code = "-Others";
                            break;
                    }

					this.gridBillingInfo.SetData(i, 0, oFolioRouting.SubFolio + code);
					this.gridBillingInfo.SetData(i, 1, oFolioRouting.Basis);
					this.gridBillingInfo.SetData(i, 2, oFolioRouting.PercentCharged.ToString());
					this.gridBillingInfo.SetData(i, 3, oFolioRouting.AmountCharged.ToString());
				}
			}
		}

		private void btnSaveRouting_Click(object sender, EventArgs e)
		{
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //if (mode == "New Guest Reservation" || mode == "Quick Reservation" || mode == "New Child Folio" || mode == "NON-STAYING" || mode == "View Folio Information")
			//{
			if (this.rdoPercent.Checked == true)
			{
				if (!CheckIf100Percent() == true)
				{
					MessageBox.Show("Total percent charged must be equal to 100 percent only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if (this.gridBillingInfo.Rows.Count > 1)
			{
				int i;
				
				for (i = 1; i <= 4; i++)
				{
					FolioRouting mFolioRouting = new FolioRouting();
					mFolioRouting.TransactionCode = this.txtBICode.Text;
					mFolioRouting.SubFolio = this.gridBillingInfo.GetDataDisplay(i, 0).Substring(0, 1);
					mFolioRouting.Basis = this.gridBillingInfo.GetDataDisplay(i, 1);
					mFolioRouting.PercentCharged = decimal.Parse(this.gridBillingInfo.GetDataDisplay(i, 2));
					mFolioRouting.AmountCharged = decimal.Parse(this.gridBillingInfo.GetDataDisplay(i, 3));

					mFolioRoutingCollection.Add(mFolioRouting);
				}

				gridTransactionCodes.Select(gridTransactionCodes.Row, 0);
				gridTransactionCodes.Rows[gridTransactionCodes.Row].StyleNew.BackColor = System.Drawing.Color.MistyRose;
				
				try
				{
					this.gridTransactionCodes.Row += 1;

					gridTransactionCodes_Click(sender, e);
				}
				catch
				{ }

				this.gridBillingInfo.Select(0, 0);
			}
			
		}

		private bool CheckIf100Percent()
		{
			if (getTotalPercentCharged() > 100 || getTotalPercentCharged() < 100)
			{
				return false;
			}
			else if (getTotalPercentCharged() == 100)
			{
				return true;
			}
			return false;
		}

		private decimal getTotalPercentCharged()
		{

			decimal totPercent = 0;
			int i;
			for (i = 1; i <= this.gridBillingInfo.Rows.Count - 1; i++)
			{
				totPercent += decimal.Parse(this.gridBillingInfo.GetDataDisplay(i, 2));
			}
			return totPercent;
		}

		private IList<FolioRouting> mFolioRoutingCollection = new List<FolioRouting>();
		public void LoadFolioRouting(Folio ofolio)
		{
			this.mFolioRoutingCollection = ofolio.FolioRouting;
			foreach(C1.Win.C1FlexGrid.Row _row in gridTransactionCodes.Rows)
			{
                if (_row.Index != 0)
                {
                    foreach (FolioRouting oFolioRouting in ofolio.FolioRouting)
                    {
                        string str = gridTransactionCodes.GetDataDisplay(_row.Index, 0);
                        if (this.gridTransactionCodes.GetDataDisplay(_row.Index, 0) == oFolioRouting.TransactionCode)
                        {
                            gridTransactionCodes.Select(_row.Index, 0);
                            gridTransactionCodes.Rows[_row.Index].StyleNew.BackColor = System.Drawing.Color.MistyRose;
                        }
                    }
                }
			}
            gridTransactionCodes.Select(1, 0);
        }

		private void btnLoadCharge_Click(object sender, EventArgs e)
		{
			if (code != "")
			{
				loadNewBillingInfo();
				code = "";

				charge = "";
			}
		}

		private void rdoAmount_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoAmount.Checked == true)
			{
				foreach (C1.Win.C1FlexGrid.Row _row in gridBillingInfo.Rows)
				{
					if (_row.Index != 0)
					{
						gridBillingInfo.SetData(_row.Index, 1, "A");
					}
				}

				gridBillingInfo.Cols[2].AllowEditing = false;
				gridBillingInfo.Cols[3].AllowEditing = true;
			}
			else if (rdoPercent.Checked == true)
			{
				foreach (C1.Win.C1FlexGrid.Row _row in gridBillingInfo.Rows)
				{
					if (_row.Index != 0)
					{
						gridBillingInfo.SetData(_row.Index, 1, "P");
					}
				}

				gridBillingInfo.Cols[2].AllowEditing = true;
				gridBillingInfo.Cols[3].AllowEditing = false;
			}
		}

		private void rdoPercent_CheckedChanged(object sender, EventArgs e)
		{
			rdoAmount_CheckedChanged(sender, new EventArgs());
		}

		#endregion

		#region RECURRING CHARGES

		//>>assigning group's routing details
		private IList<FolioRouting> assignFolioRouting()
		{
			return mFolioRoutingCollection;
		}

		//>>assigning group's recurring charges
        private IList<RecurringCharge> assignRecurringCharges()
		{
			IList<RecurringCharge> oRecurringChargeCollection = new List<RecurringCharge>();
			try
			{
				foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
				{
					if (_row.Index != 0)
					{
						RecurringCharge oRecurringCharge = new RecurringCharge();

						oRecurringCharge.FolioID = txtFolioID.Text;
                        oRecurringCharge.RoomID = grdRecurredCharge.GetDataDisplay(_row.Index, 1);
                        oRecurringCharge.QtyHrs = int.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 7));
                        oRecurringCharge.Discount = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 9));
                        oRecurringCharge.BaseAmount = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 6));
                        oRecurringCharge.RateType = grdRecurredCharge.GetDataDisplay(_row.Index, 5);
						oRecurringCharge.TransactionCode = grdRecurredCharge.GetDataDisplay(_row.Index, 3);
						oRecurringCharge.Memo = grdRecurredCharge.GetDataDisplay(_row.Index, 4);
                        oRecurringCharge.Amount = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 10));
						oRecurringCharge.FromDate = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 11));
						oRecurringCharge.ToDate = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 12));
						oRecurringCharge.CreatedBy = GlobalVariables.gLoggedOnUser;
						oRecurringCharge.HotelID = GlobalVariables.gHotelId;
                        oRecurringCharge.Tax = decimal.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 8));
                        //oRecurringCharge.SubAccount = grdRecurredCharge.GetDataDisplay(_row.Index, 6);
						if (grdRecurredCharge.GetCellCheck(_row.Index, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
						{
							oRecurringCharge.SummaryFlag = 1;
                            oRecurringCharge.PackageID = int.Parse(cboEventGrpPackage.SelectedValue.ToString());
                        }
						else
						{
							oRecurringCharge.SummaryFlag = 0;
                            oRecurringCharge.PackageID = 0;
                        }
                        oRecurringCharge.RoomID = grdRecurredCharge.GetDataDisplay(_row.Index, 1);
                       
                        //if (oRecurringCharge.Amount > 0)
                        //{
							oRecurringChargeCollection.Add(oRecurringCharge);
                        //}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Save Recurring Charge Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
            return oRecurringChargeCollection;
        }

		//private void saveFolioRecurringCharge()
		//{
		//    try
		//    {
		//        RecurringChargeCollection _oRecurringChargeCollection = new RecurringChargeCollection();

		//        foreach (ListViewItem _listViewItem in this.lvwRecurredCharge.Items)
		//        {
		//            RecurringCharge _oRecurringCharge = new RecurringCharge();
		//            _oRecurringCharge.TransactionCode = _listViewItem.SubItems[0].Text;
		//            _oRecurringCharge.Memo = _listViewItem.SubItems[1].Text;
		//            _oRecurringCharge.Amount = decimal.Parse(_listViewItem.SubItems[2].Text);
		//            _oRecurringCharge.FromDate = DateTime.Parse(_listViewItem.SubItems[3].Text);
		//            _oRecurringCharge.ToDate = DateTime.Parse(_listViewItem.SubItems[4].Text);
		//            _oRecurringCharge.FolioID = loFolio.FolioID;
		//            _oRecurringCharge.HotelID = GlobalVariables.gHotelId;

		//            _oRecurringChargeCollection.Add(_oRecurringCharge);
		//        }

		//        this.loFolio.RecurringCharges = _oRecurringChargeCollection;
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show(ex.Message, "Save Recurring Charge Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		//    }
		//}


        //private void getRecurringCharges(string pFolioID)
        //{
        //    grdRecurredCharge.Rows.Count = 1;
        //    foreach (RecurringCharge _oRecurringCharge in loFolio.RecurringCharges)
        //    {
        //        grdRecurredCharge.Rows.Count++;
        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, _oRecurringCharge.SummaryFlag);
        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, _oRecurringCharge.TransactionCode);
        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, _oRecurringCharge.Memo);
        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 9, _oRecurringCharge.Amount.ToString());
        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, _oRecurringCharge.FromDate);
        //        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, _oRecurringCharge.ToDate);
        //        //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _oRecurringCharge.SubAccount);
        //    }
        //}

		private void loadRecurringCharge()
		{
			grdRecurredCharge.Rows.Count++;
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 1, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 0));
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 2, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 1));
			grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, lCode);
			
			grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, "0.00");
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, "0.00");
            
            
            decimal _amount = getTotalAmount(lCode, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 0), cboRateTypes.Text);
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _amount);
            
            if (lCode == ConfigVariables.gRoomChargeTransactionCode)
            {
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, lCharge + "/" + gridPackageRoom.GetDataDisplay(gridPackageRoom.Row,2));
                int _noOfHrs = getNoOfHrs(gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 2));
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, _noOfHrs );
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, (_amount*_noOfHrs*loTax/100) + (_amount*_noOfHrs));
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 5, cboRateTypes.Text);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 8, loTax);
            }
            else
            {
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, lCharge);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, "1");
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, (_amount*loTax/100) + _amount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 8, loTax);
            }
            grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 9, "0");
            
            if (gridFunctionRooms.Rows.Count > 1)
            {
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 3)));
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, DateTime.Parse(gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 4)));
                //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, DateTime.Parse(gridFunctionRooms.GetDataDisplay(1, 4)));
                //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 5)));
            }
            else
            {
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(GlobalVariables.gAuditDate));
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, DateTime.Parse(GlobalVariables.gAuditDate));
            }

            //added by genny for additional field:roomID
            //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, gridPackageRoom.GetDataDisplay(gridPackageRoom.Row, 0));
            computePackageAmount();
		}

        private int getNoOfHrs(string pTimeRange)
        {
            try
            {
                string[] _splitter = { "-" };
                string[] _times = pTimeRange.Split(_splitter, StringSplitOptions.RemoveEmptyEntries);

                if (_times.Length != 2)
                {
                    throw new Exception();
                }

                DateTime _startTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd ") + _times[0].ToString());
                DateTime _endTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd ") + _times[1].ToString());

                int _noOfHrs = _endTime.Hour - _startTime.Hour;

                if (_endTime.Hour == 0 && _startTime.Hour == 0)
                {
                    _noOfHrs = 24;
                }

                if (_noOfHrs < 0)
                {
                    _noOfHrs *= -1;
                }

                return _noOfHrs;
            }
            catch
            {
                return 1;
            }
        }

        DataTable loTransactionCodes = null;
        DataTable loRateTypes = null;
        decimal loTax = 0;
        private decimal getTotalAmount(string pCode, string pRoom, string pRateCode)
        {
            TransactionCodeFacade _transactionCodeFacade = new TransactionCodeFacade();
            RateTypeFacade _rateTypeFace = new RateTypeFacade();
            DataView _dv = new DataView();

            decimal _amount = 0;

            if (pCode == ConfigVariables.gRoomChargeTransactionCode)
            {
                if (loRateTypes == null)
                {
                    loRateTypes = _rateTypeFace.getRateTypes();
                }
                _dv = loRateTypes.DefaultView;
                _dv.RowFilter = "";
                _dv.RowFilter = "roomID = '" + pRoom + "' and ratecode = '" + pRateCode + "'";

                if (_dv.Count > 0)
                {
                    _amount = decimal.Parse(_dv[0]["rateamount"].ToString());
                }

                //get tax
                if (loTransactionCodes == null)
                {
                    loTransactionCodes = _transactionCodeFacade.getTransactionCodes();
                }
                _dv = loTransactionCodes.DefaultView;
                _dv.RowFilter = "";
                _dv.RowFilter = "tranCode = '" + pCode + "'";
                if (_dv.Count > 0)
                {
                    string tax = _dv[0]["govtTaxInclusive"].ToString();
                    if (tax == "0")
                        loTax = decimal.Parse(_dv[0]["govtTax"].ToString());
                    else
                        loTax = 0;
                }

            }
            else
            {
                if (loTransactionCodes == null)
                {
                    loTransactionCodes = _transactionCodeFacade.getTransactionCodes();
                }
                _dv = loTransactionCodes.DefaultView;
                _dv.RowFilter = "";
                _dv.RowFilter = "tranCode = '" + pCode + "'";

                if (_dv.Count > 0)
                {
                    _amount = decimal.Parse(_dv[0]["defaultAmount"].ToString());
                    string tax = _dv[0]["govtTaxInclusive"].ToString();
                    if (tax == "0")
                        loTax = decimal.Parse(_dv[0]["govtTax"].ToString());
                    else
                        loTax = 0;
                }
            }

            return _amount;
        }

		private void loadFolioRecurringCharges()
		{
			FolioDAO _oFolioDAO = new FolioDAO();
			IList<RecurringCharge> _dt = _oFolioDAO.getFolioRecurringCharges(txtFolioID.Text);
			RecurringCharge _dr;
			grdRecurredCharge.Rows.Count = 1;
            RoomFacade _roomFacade = new RoomFacade();
            Room _oRoom = new Room();
			foreach (RecurringCharge _tempLoopVarDataRow in _dt)
			{
				_dr = _tempLoopVarDataRow;
				grdRecurredCharge.Rows.Count++;

                if (_dr.SummaryFlag == 1)
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, true);
                else
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, false);

				grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, _dr.TransactionCode);
				grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, _dr.Memo);
				grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, _dr.Amount.ToString());
				grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, _dr.FromDate);
				grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, _dr.ToDate);
                //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _dr.SubAccount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 1, _dr.RoomID);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 5, _dr.RateType);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _dr.BaseAmount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 7, _dr.QtyHrs);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 9, _dr.Discount);
                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 8, _dr.Tax);

                _oRoom = _roomFacade.getRoom(_dr.RoomID);

                grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 2, _oRoom.RoomDescription);
			}
			computePackageAmount();
		}

        private ComboBox lRecurringCombo = new ComboBox();
		private void grdRecurringCharges_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				lCode = grdRecurringCharges.GetDataDisplay(grdRecurringCharges.Row, 0);
				lCharge = grdRecurringCharges.GetDataDisplay(grdRecurringCharges.Row, 1);
			}
			catch (Exception)
			{
			}
		}

		private void grdRecurredCharge_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{

            if (e.Col == 11 || e.Col == 12)
            {
                if (DateTime.Parse(grdRecurredCharge.GetDataDisplay(e.Row, e.Col)) < DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    MessageBox.Show("Selected date is less than the current audit date. Please select another date", "Select Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdRecurredCharge.SetData(e.Row, e.Col, DateTime.Parse(GlobalVariables.gAuditDate));
                    return;
                }
                if (DateTime.Parse(grdRecurredCharge.GetDataDisplay(e.Row, e.Col)) > dtpTodate.Value)
                {
                    MessageBox.Show("Selected date is greater than the event end date. Please select another date", "Select Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdRecurredCharge.SetData(e.Row, e.Col, DateTime.Parse(GlobalVariables.gAuditDate));
                    return;
                }
            }
            if (e.Col == 5)
            {
                decimal _amount = getTotalAmount(ConfigVariables.gRoomChargeTransactionCode, grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 1), grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 5));
                grdRecurredCharge.SetData(grdRecurredCharge.Row, 6, _amount);
            }

            decimal _total = 0;

            try
            {
                decimal _baseAmount = decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 6).ToString());
                //decimal _tax = _baseAmount * (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 8)) / 100);
                decimal _quantity = decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 7));
                decimal _discount = _baseAmount * _quantity * (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 9)) / 100);
                //_total = (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 6).ToString()) * decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 7))) * ((100 - decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 8))) / 100);

                _total = (_baseAmount * _quantity) - _discount;
                decimal _tax = _total * (decimal.Parse(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 8)) / 100);
                _total = _total + _tax;
            }
            catch
            {
                _total = 0;
            }

            grdRecurredCharge.SetData(grdRecurredCharge.Row, 10, _total);
			computePackageAmount();
		}

		private void btnAddRecurringCharge_Click(System.Object sender, System.EventArgs e)
		{
			if (lEdit == true || lFlag == "New")
			{
                if(gridPackageRoom.Rows.Count < 2)
                {
                    MessageBox.Show("No schedule has been set for this event!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else{
				    if (lCode != "")
				    {
					    loadRecurringCharge();
					    //lCode = "";

					    //lCharge = "";
				    }
                }

			}
			else
			{
				MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode","Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnRemoveRecurringCharge_Click(object sender, EventArgs e)
		{
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
            try
			{
				grdRecurredCharge.RemoveItem(grdRecurredCharge.Row);
			}
			catch
			{ }

			computePackageAmount();
		}

		private void lvwRecurredCharge_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			lvwRecurredChargeMouseUp(sender, e);
		}

		private void lvwRecurredChargeMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					System.Drawing.Point _point = new System.Drawing.Point(e.X, e.Y);
					lItemIndex = grdRecurredCharge.Row;
					lTranCode = grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 0);
					if (lEdit == true)
					{
						mnuDeleteCharge.Visible = true;
					}
					else
					{
						//mnuEdit.Visible = False
						mnuDeleteCharge.Visible = false;
					}
					//mnuEditRate.Visible = True
					mnulvwCommands.Show(this.grdRecurredCharge, _point);
				}
			}
			catch (Exception)
			{
			}
		}

		private void mnuDeleteCharge_Click(System.Object sender, System.EventArgs e)
		{
			grdRecurredCharge.RemoveItem(grdRecurredCharge.Row);

			FolioFacade _oFolioFacade = new FolioFacade();
			_oFolioFacade.DeleteFolioRecurringCharge(txtFolioID.Text, lTranCode);
		}

		#endregion

		#region EVENT BOOKING INFO

		//for getting the applied _oAppliedRates of an event
		private void loadAppliedRates()
		{
			gridBilling.Rows.Count = 1;

			EventAppliedRatesFacade _oRatesFacade = new EventAppliedRatesFacade();
			GenericList<EventAppliedRates> _oAppliedRatesList = new GenericList<EventAppliedRates>();
			_oAppliedRatesList = _oRatesFacade.getAppliedRatesForEvents(txtFolioID.Text);
			foreach (EventAppliedRates _oAppliedRates in _oAppliedRatesList)
			{
				string[] _items ={ _oAppliedRates.Description, string.Format("{0:###,##0.#0}", _oAppliedRates.RateAmount), _oAppliedRates.NumberOfOccupants.ToString(), _oAppliedRates.RateType.ToString() };
				gridBilling.AllowAddNew = false;
				gridBilling.AddItem(_items);
			}
			gridBilling.AllowAddNew = true;
		}

		private void btnSaveRates_Click(object sender, EventArgs e)
		{
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

            try
            {
                saveBookingInfo(ref _oTransaction);

                _oTransaction.Commit();

                MessageBox.Show("Transaction successful. " + "\r\n" + "Booking Information has been saved", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Text = "Group Folio";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving rates.\r\n" + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _oTransaction.Rollback();
            }

		}

		private void btnNewDeposit_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.gShiftCode <= 0 && GlobalVariables.gCashDrawerOpen == false)
			{
				MessageBox.Show("No Shift/Cash drawer open.\r\nCan't proceed transaction.", "Insert Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			AddTransactionUI _oAddTransaction = new AddTransactionUI(loFolio, this.txtFolioID, "A", "Payments");
			_oAddTransaction.ShowDialog();
			loadFolioDeposits();
		}

		//for displaying the deposits of a guest
        private decimal lTotalPayment = 0;
		public void loadFolioDeposits()
		{
			grdDeposits.Rows.Count = 1;
			FolioFacade _oFolioFacade = new FolioFacade();
			FolioTransactions _oFolioTransactions = new FolioTransactions();
			_oFolioTransactions = _oFolioFacade.GetFolioTransactions(txtFolioID.Text, "A");
			foreach (FolioTransaction _oFolioTrans in _oFolioTransactions)
			{
				if (_oFolioTrans.AcctSide == "CREDIT")
				{
					grdDeposits.Rows.Count++;
					grdDeposits.SetData(grdDeposits.Rows.Count - 1, 0, _oFolioTrans.TransactionDate);
					grdDeposits.SetData(grdDeposits.Rows.Count - 1, 1, _oFolioTrans.BaseAmount);
					grdDeposits.SetData(grdDeposits.Rows.Count - 1, 2, _oFolioTrans.ReferenceNo);
                    lTotalPayment += _oFolioTrans.BaseAmount;
				}
			}
            txtContractAmount_TextChanged(null, null);
            txtTotalEstimatedCost_TextChanged_1(null, null);
		}

		private void loadEventDetails()
		{
			gridEventDetails.AllowAddNew = false;
			gridEventDetails.Rows.Count = 1;
			EventFacade _oEventFacade = new EventFacade();
			GenericList<EventDetails> _oEventDetailList = _oEventFacade.getEventDetails(txtFolioID.Text);
			foreach (EventDetails _oEventDetail in _oEventDetailList)
			{
				string[] items ={ _oEventDetail.EventDetailHeader, _oEventDetail.Description };
				gridEventDetails.AddItem(items);
			}
			gridEventDetails.AllowAddNew = true;
		}

		private void cboEventType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboEventType.SelectedValue.ToString() != "")
			{
                bool _isBanquet = false;
                EventTypeFacade _oEventTypeFacade = new EventTypeFacade();
                _isBanquet = _oEventTypeFacade.isBanquetType(cboEventType.Text.ToUpper());

                if (_isBanquet == true)
                {
                    lblLiveIn.Text = "Min. Pax";
                    lblLiveOut.Text = "Max. Pax";
                    lblLiveInFood.Text = "Min. Pax";
                    lblLiveOutFood.Text = "Max. Pax";
                }
                else
                {
                    lblLiveIn.Text = "Live In";
                    lblLiveOut.Text = "Live Out";
                    lblLiveInFood.Text = "Live In";
                    lblLiveOutFood.Text = "Live Out";
                }

				_oEventTypeFacade = new EventTypeFacade();
				GenericList<EventType> _oEventTypeList = _oEventTypeFacade.getEventAttributes(cboEventType.SelectedValue.ToString());

				gridEventDetails.AllowAddNew = false;
				gridEventDetails.Rows.Count = 1;
				foreach (EventType _oEventType in _oEventTypeList)
				{
					string[] items ={ _oEventType.Key, "" };
					gridEventDetails.AddItem(items);
				}
				gridEventDetails.AllowAddNew = true;
			}

			txtEventType.Text = cboEventType.Text;
		}

		//>>by Genny: Apr. 28, 2008
		private void saveEventDetails(ref MySqlTransaction poTransaction)
		{
            //saveMeals();
            saveRequirements(ref poTransaction);

            //>>for event type details
            EventDetails _oEventDetails = new EventDetails();
            EventFacade _oEventDetailsFacade = new EventFacade();
            _oEventDetailsFacade.deleteEventDetails(txtFolioID.Text, ref poTransaction);

            int _counter = 1;
            int _rowCount = gridEventDetails.Rows.Count - 1;
            foreach (C1.Win.C1FlexGrid.Row _cntRow in gridEventDetails.Rows)
            {
                if (_cntRow.Index != 0 && _counter < _rowCount)
                {
                    _oEventDetails.FolioID = txtFolioID.Text;
                    _oEventDetails.EventDetailHeader = gridEventDetails.GetDataDisplay(_counter, 0);
                    _oEventDetails.Description = gridEventDetails.GetDataDisplay(_counter, 1);

                    try
                    {
                        // WHEN WILL PROGRAM ENTER HERE
                        _oEventDetailsFacade.saveEventDetails(_oEventDetails, ref poTransaction);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Transaction failed.\r\nError in saving event details.\r\n\r\nError message : " + ex.Message);
                    }
                    _counter++;
                }
            }//<<end event type details
		}

        public void saveBookingInfo(ref MySqlTransaction pTrans)
        {
            EventBookingInfo _oEventBookingInfo = new EventBookingInfo();
            _oEventBookingInfo.BookingDate = DateTime.Parse(txtCreateTime.Text);
            _oEventBookingInfo.EventType = cboEventType.Text;
            _oEventBookingInfo.NumberOfLiveIn = int.Parse(nudNumberOfPaxLiveIn.Value.ToString());
            _oEventBookingInfo.NumberOfLiveOut = int.Parse(nudNumberOfPaxLiveOut.Value.ToString());
            _oEventBookingInfo.FolioID = txtFolioID.Text;
            _oEventBookingInfo.NumberOfPaxGuaranteed = int.Parse(nudPaxGuaranteed.Value.ToString());
            _oEventBookingInfo.BillingArrangement = GlobalFunctions.addSlashes(txtBillingArrangement.Text);
            _oEventBookingInfo.AuthorizedSignatory = GlobalFunctions.addSlashes(txtSignatories.Text);
            _oEventBookingInfo.LobbyPosting = GlobalFunctions.addSlashes(txtLobbyPosting.Text);
            _oEventBookingInfo.CREATEDBY = GlobalVariables.gLoggedOnUser;
            _oEventBookingInfo.UPDATEDBY = GlobalVariables.gLoggedOnUser;
            _oEventBookingInfo.HotelID = GlobalVariables.gHotelId;
            _oEventBookingInfo.EventPackage = int.Parse(cboEventGrpPackage.SelectedValue.ToString());
            _oEventBookingInfo.PackageAmount = decimal.Parse(txtPackageAmount.Text);
            _oEventBookingInfo.ContactAddress = GlobalFunctions.addSlashes(txtStreet1.Text + ", " + txtCity1.Text + ", " + txtCountry1.Text + ", " + txtZip1.Text);
            _oEventBookingInfo.ContactNumber = txtContactNumber1.Text;
            _oEventBookingInfo.ContactPerson = txtContactPerson.Text;
            _oEventBookingInfo.ContactPosition = txtDesignation.Text;
            _oEventBookingInfo.MobileNumber = txtContactNumber2.Text;
            _oEventBookingInfo.FaxNumber = txtContactNumber3.Text;
            _oEventBookingInfo.EmailAddress = txtEmail1.Text;
            
            try
            {
                _oEventBookingInfo.EstimatedTotalCost = decimal.Parse(txtTotalEstimatedCost.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error in saving folio. \r\nPlease check the total estimated cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
                throw new Exception("Error in saving folio. \r\nPlease check the total estimated cost.\n\n" + ex.Message);
            }

            bool _isEventExist = loEventFacade.checkEventExists(txtFolioID.Text);

            if (_isEventExist == false)
            {
             
                loEventFacade.insertEvents(_oEventBookingInfo, ref pTrans);
            }//end of mflag=="new"

            else //if (lFlag == "New" && _isEventExist == true)
            {
           
                loEventFacade.updateEvents(_oEventBookingInfo, ref pTrans);
            }
            //else
            //{
            //    loEventFacade.updateEvents(_oEventBookingInfo);
            //}

            //>>applied _oAppliedRates
            EventAppliedRates _oEventAppliedRates = new EventAppliedRates();
            EventAppliedRatesFacade _oEventAppliedRatesFacade = new EventAppliedRatesFacade();
            _oEventAppliedRatesFacade.deleteAppliedRates(txtFolioID.Text, ref pTrans);

            int _counter = 1;
            int _rowCount = gridBilling.Rows.Count;
            foreach (C1.Win.C1FlexGrid.Row _cntRow in gridBilling.Rows)
            {
                try
                {
                    if (_cntRow.Index != 0 && gridBilling.GetDataDisplay(_counter, 0) != "") //_counter < _rowCount - 1)
                    {
                        _oEventAppliedRates.FolioID = txtFolioID.Text;
                        _oEventAppliedRates.Description = gridBilling.GetDataDisplay(_counter, 0);
                        _oEventAppliedRates.RateAmount = decimal.Parse(gridBilling.GetDataDisplay(_counter, 1));
                        _oEventAppliedRates.NumberOfOccupants = int.Parse(gridBilling.GetDataDisplay(_counter, 2));
                        _oEventAppliedRates.RateType = gridBilling.GetDataDisplay(_counter, 3);

                        _oEventAppliedRatesFacade = new EventAppliedRatesFacade();
                        _oEventAppliedRatesFacade.saveAppliedRates(_oEventAppliedRates, ref pTrans);
                        _counter++;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in saving applied rates. Please check details \r\n\r\nError message : " + ex.Message);
                }
            }//<<
        }

		#endregion //>>booking info

		#region EVENT MEAL REQUIREMENTS

        private void btnAddDateOK_Click(object sender, EventArgs e)
        {
            treeFoodBev.Nodes.Add(dtpAddDate.Value.ToShortDateString());
            pnlDate.Visible = false;
        }

        private void btnAddDateCancel_Click(object sender, EventArgs e)
        {
            pnlDate.Visible = false;
        }

        private bool _isNewMeal = false;
		//to add another date in the meals reservation
		private void btnAddDate_Click(object sender, EventArgs e)
		{
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 
            
            pnlDate.Visible = true;
			pnlDate.BringToFront();
			clearMeals();
            _isNewMeal = true;
		}

		//for saving the meals for a specific date
		private void btnSaveMeal_Click(object sender, EventArgs e)
		{
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 
            
            if (cboMealType.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please select meal type.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabFoodBev_"].Select();
                this.cboMealType.Focus();
                return;
            }

            if (txtStartMealTime.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please input ready time.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabFoodBev_"].Select();
                this.txtStartMealTime.Focus();
                return;
            }

            if (txtEndMealTime.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please input deliver time.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabFoodBev_"].Select();
                this.txtEndMealTime.Focus();
                return;
            }

            if (nudMealPax.Value <= 0)
            {
                MessageBox.Show("Number of pax should be greater than 0", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabFolio_.TabPages["tabFoodBev_"].Select();
                this.nudMealPax.Focus();
                return;
            }

            if (gridMealItems.Rows.Count <= 1)
            {
                MessageBox.Show("Meals should have at least one meal item.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

			if (saveMeals())
			{
				MessageBox.Show("Transaction successful. " + "\r\n" + "Meal Requirements has been saved", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			this.Text = "Group Folio";

			clearMeals();
			loadFoodRequirements();
			getTotalEstimatedCost();

            saveBookingInfo(ref _oTransaction);
            addMeallDates();
            cboMealType.Enabled = false;
            _oTransaction.Commit();
		}

		private bool saveMeals()
		{
            try
            {
                if (newMeal == true)
                {
                    //>>food requirements
                    EventFoodRequirementsFacade _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    EventFoodRequirements oMealHeader = new EventFoodRequirements();
                    bool _isExist = _oMealHeaderFacade.eventDateExists(dtpFoodDate.Value, txtFolioID.Text);

                    oMealHeader = new EventFoodRequirements();
                    oMealHeader.EventDate = dtpFoodDate.Value;
                    oMealHeader.Venue = txtVenueFood.Text;
                    oMealHeader.StartTime = DateTime.Parse(txtStartMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.EndTime = DateTime.Parse(txtEndMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.Over = txtFoodOver.Text;
                    oMealHeader.Setup = txtFoodSetup.Text;
                    oMealHeader.Remarks = txtFoodRemarks.Text;
                    oMealHeader.FolioID = txtFolioID.Text;
                    oMealHeader.TotalMealCost = 0;
                    oMealHeader.Pax = int.Parse(nudMealPax.Value.ToString());
                    oMealHeader.MealType = cboMealType.Text;
                    oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                    oMealHeader.PaxLiveIn = int.Parse(nudMealLiveIn.Value.ToString());
                    oMealHeader.PaxLiveOut = int.Parse(nudMealLiveOut.Value.ToString());

                    try
                    {
                        oMealHeader.TotalMealCost = decimal.Parse(txtTotalMealAmount.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Meal amount entered is incorrect. Please check input.", "Incorrect entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    _oMealHeaderFacade.saveFoodRequirements(oMealHeader);

                    //>>_oMealMenu details
                    foreach (C1.Win.C1FlexGrid.Row r in gridMealItems.Rows)
                    {
                        if (r.Index != 0)
                        {
                            oMealHeader = new EventFoodRequirements();
                            oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                            oMealHeader.MenuCode = gridMealItems.GetDataDisplay(r.Index, 0).ToString();
                            oMealHeader.MenuItemCode = gridMealItems.GetDataDisplay(r.Index, 1).ToString();
                            oMealHeader.Description = gridMealItems.GetDataDisplay(r.Index, 2).ToString();
                            oMealHeader.Remarks = gridMealItems.GetDataDisplay(r.Index, 3).ToString();
                            oMealHeader.Price = 0;

                            try
                            {
                                EventFoodRequirementsFacade mealDetailFacade = new EventFoodRequirementsFacade();
                                mealDetailFacade.saveMealDetails(oMealHeader);
                            }
                            catch { }
                        }//end foreach of _oMealMenu details
                    }//end of _oMealMenu header

                    return true;
                }//end if isNewMeal

                else
                {
                    EventFoodRequirementsFacade _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    EventFoodRequirements oMealHeader = new EventFoodRequirements();

                    oMealHeader = new EventFoodRequirements();
                    oMealHeader.EventDate = dtpFoodDate.Value;
                    oMealHeader.Venue = txtVenueFood.Text;
                    oMealHeader.StartTime = DateTime.Parse(txtStartMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.EndTime = DateTime.Parse(txtEndMealTime.Text).ToString("HH:mm:ss");
                    oMealHeader.Over = txtFoodOver.Text;
                    oMealHeader.Setup = txtFoodSetup.Text;
                    oMealHeader.Remarks = txtFoodRemarks.Text;
                    oMealHeader.FolioID = txtFolioID.Text;
                    oMealHeader.Pax = int.Parse(nudMealPax.Value.ToString());
                    oMealHeader.MealType = cboMealType.Text;
                    oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                    oMealHeader.PaxLiveIn = int.Parse(nudMealLiveIn.Value.ToString());
                    oMealHeader.PaxLiveOut = int.Parse(nudMealLiveOut.Value.ToString());

                    try
                    {
                        oMealHeader.TotalMealCost = decimal.Parse(txtTotalMealAmount.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Meal amount entered is incorrect. Please check input.", "Incorrect entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    _oMealHeaderFacade = new EventFoodRequirementsFacade();
                    _oMealHeaderFacade.updateFoodRequirements(oMealHeader);
                    _oMealHeaderFacade.deleteMealDetails(cboMealType.Tag.ToString());

                    //>>_oMealMenu details
                    foreach (C1.Win.C1FlexGrid.Row r in gridMealItems.Rows)
                    {
                        if (r.Index != 0)
                        {
                            oMealHeader = new EventFoodRequirements();
                            oMealHeader.MealID = int.Parse(cboMealType.Tag.ToString());
                            oMealHeader.MenuCode = gridMealItems.GetDataDisplay(r.Index, 0).ToString();
                            oMealHeader.MenuItemCode = gridMealItems.GetDataDisplay(r.Index, 1).ToString();
                            oMealHeader.Description = gridMealItems.GetDataDisplay(r.Index, 2).ToString();
                            oMealHeader.Remarks = gridMealItems.GetDataDisplay(r.Index, 3).ToString();
                            oMealHeader.Price = 0;

                            try
                            {
                                EventFoodRequirementsFacade mealDetailFacade = new EventFoodRequirementsFacade();
                                mealDetailFacade.saveMealDetails(oMealHeader);
                            }
                            catch { }
                        }//end foreach of _oMealMenu details
                    }//end of _oMealMenu header

                    return true;
                }//end else


                //return false;
            }//end try
            catch
            {
                return false;
            }
            finally
            {
                _isNewMeal = false;
            }
		}

		private bool newMeal = false;
		//for creating new meals/meal menu types 
		private void btnNewMeal_Click(object sender, EventArgs e)
		{
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 

            clearMeals();
			loadMenuItems();
			grpMealDetails.Enabled = true;
			loSequence = new Sequence();
			string mealID = loSequence.getSequenceId("", 5, "seq_mealid");
			cboMealType.Tag = mealID;
			btnSaveMeal.Enabled = true;
			newMeal = true;
            cboMealType.Enabled = true;
        }

		private decimal totalAmount;
		//for displaying details of food and beverage tab page
		private void loadFoodRequirements()
		{
            loadMenuItems();
			totalAmount = 0;
			treeFoodBev.Nodes.Clear();
			EventFoodRequirementsFacade _oFoodRequirementFacade = new EventFoodRequirementsFacade();
			GenericList<EventFoodRequirements> _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();

			//>>food requirements
			_oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();
			_oEventFoodRequirementsList = _oFoodRequirementFacade.getFoodDates(txtFolioID.Text);

            //get food dates
			foreach (EventFoodRequirements _oEventFoodRequirements in _oEventFoodRequirementsList)
			{
				TreeNode _eventDatesNode = new TreeNode(_oEventFoodRequirements.EventDate.ToShortDateString());

                //for getting meal types in a date
                EventFoodRequirementsFacade _oMealTypeFacade = new EventFoodRequirementsFacade();
                GenericList<EventFoodRequirements> _oEventMealTypeList = _oMealTypeFacade.getMealTypes(txtFolioID.Text, DateTime.Parse(_eventDatesNode.Text));
                foreach (EventFoodRequirements _mealTypes in _oEventMealTypeList)
                {
                    _eventDatesNode.Nodes.Add(_mealTypes.MealType);
                }
                
				treeFoodBev.Nodes.Add(_eventDatesNode);
			}
			treeFoodBev.ExpandAll();
			txtTotalMealAmount.Value = totalAmount;
			origAmt = txtTotalMealAmount.Text;
			//<<
		}

		//for displaying the details for a specific meal menu
		private void treeFoodBev_AfterSelect(object sender, TreeViewEventArgs e)
		{
            lblPaxAmt.Visible = true;
            nudPaxAmt.Visible = true;
            EventFoodRequirementsFacade _oEventFoodRequirementsFacade = new EventFoodRequirementsFacade();
			GenericList<EventFoodRequirements> _oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();

			if (treeFoodBev.Nodes.Count > 0)
			{
                btnNewMeal.Enabled = true;
                btnSaveMeal.Enabled = true;

				//>>_oMealMenu header
				if (treeFoodBev.SelectedNode.Parent != null && treeFoodBev.SelectedNode.Parent.Text != treeFoodBev.SelectedNode.Text)
				{
					clearMeals();
					_oEventFoodRequirementsList = _oEventFoodRequirementsFacade.getFoodRequirement(DateTime.Parse(treeFoodBev.SelectedNode.Parent.Text), txtFolioID.Text);
					foreach (EventFoodRequirements _oEventFoodRequirements in _oEventFoodRequirementsList)
					{
                        if (_oEventFoodRequirements.MealType == treeFoodBev.SelectedNode.Text)
                        {
                            cboMealType.Enabled = true;
                            dtpFoodDate.Text = _oEventFoodRequirements.EventDate.ToShortDateString();

                            txtStartMealTime.Value = DateTime.Parse(_oEventFoodRequirements.StartTime);
                            txtEndMealTime.Value = DateTime.Parse(_oEventFoodRequirements.EndTime);
                            txtVenueFood.Text = _oEventFoodRequirements.Venue;
                            txtFoodSetup.Text = _oEventFoodRequirements.Setup;
                            txtFoodRemarks.Text = _oEventFoodRequirements.Remarks;
                            txtFoodOver.Text = _oEventFoodRequirements.Over;

                            cboMealType.Text = _oEventFoodRequirements.MealType;
                            cboMealType.Tag = _oEventFoodRequirements.MealID.ToString();

                            nudMealPax.Value = decimal.Parse(_oEventFoodRequirements.Pax.ToString());
                            nudMealLiveOut.Value = decimal.Parse(_oEventFoodRequirements.PaxLiveOut.ToString());
                            nudMealLiveIn.Value = decimal.Parse(_oEventFoodRequirements.PaxLiveIn.ToString());
                            nudPaxAmt.Value = _oEventFoodRequirements.TotalMealCost / nudMealPax.Value;
                            txtTotalMealAmount.Value = _oEventFoodRequirements.TotalMealCost;

                            break;
                        }
                    }//end foreach

					//>>_oMealMenu details
					_oEventFoodRequirementsList = new GenericList<EventFoodRequirements>();
                    _oEventFoodRequirementsList = _oEventFoodRequirementsFacade.getMealDetails(cboMealType.Tag.ToString(), DateTime.Parse(treeFoodBev.SelectedNode.Parent.Text), txtFolioID.Text);
					foreach (EventFoodRequirements _oEventFoodRequirements in _oEventFoodRequirementsList)
					{
						string[] items ={ _oEventFoodRequirements.MenuCode, _oEventFoodRequirements.MenuItemCode, _oEventFoodRequirements.Description, _oEventFoodRequirements.Remarks };
						gridMealItems.AddItem(items);
					}//end foreach

				}//end if 

				else
				{
					try
					{
						this.dtpFoodDate.Value = DateTime.Parse(treeFoodBev.SelectedNode.Text);
                        clearMeals();
					}
					catch { }
				}//end if else
            }//end if treefoodbev.nodes.count

			else
			{
				btnNewMeal.Enabled = false;
				btnSaveMeal.Enabled = false;
			}
			newMeal = false;
		}

		//check whether the selected node is parent or a child node
		private void checkMealHeader()
		{
			bool _isExist = false;
			foreach (Control _ctrl in grpMealDetails.Controls)
			{
				if (_ctrl is TextBox && _ctrl.Text != "")
					_isExist = _isExist || true;
				else if (_ctrl is TextBox && _ctrl.Text == "")
					_isExist = _isExist || false;
			}
		}

		private void nudMealLiveIn_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				decimal totalMealCost = 0;

				EventAppliedRatesFacade _oAppliedRatesFacade = new EventAppliedRatesFacade();
				GenericList<EventAppliedRates> _oEventAppliedRatesList = _oAppliedRatesFacade.getAppliedRatesForEvents(txtFolioID.Text);

                if (_oEventAppliedRatesList.Count > 0)
                {
                    totalMealCost = 0;
                }
                else
                {
                    totalMealCost = txtTotalMealAmount.Value;
                }

				foreach (EventAppliedRates _oEventAppliedRates in _oEventAppliedRatesList)
				{
					decimal liveInCost = 0;
					decimal liveOutCost = 0;
					if (_oEventAppliedRates.Description.ToUpper().Contains(cboMealType.Text) && _oEventAppliedRates.Description.ToUpper().Contains("LIVE-OUT"))
					{
						liveInCost = _oEventAppliedRates.RateAmount * decimal.Parse(nudMealLiveOut.Value.ToString());
                        lblPaxAmt.Visible = false;
                        nudPaxAmt.Visible = false;
                    }
					if (_oEventAppliedRates.Description.ToUpper().Contains(cboMealType.Text) && _oEventAppliedRates.Description.ToUpper().Contains("LIVE-IN"))
					{
						liveOutCost = _oEventAppliedRates.RateAmount * decimal.Parse(nudMealLiveIn.Value.ToString());
                        lblPaxAmt.Visible = false;
                        nudPaxAmt.Visible = false;
                    }
					totalMealCost += liveInCost + liveOutCost;
				}

				txtTotalMealAmount.Text = string.Format("{0:###,##0.#0}", totalMealCost);
                nudMealPax.Value = nudMealLiveIn.Value + nudMealLiveOut.Value;
			}
			catch { }
		}

		//for displaying the menu meals or the items itself
		private void loadMenuItems()
		{
			//lvwMenus.Items.Clear();
			MealMenuItemFacade _oMealMenuItemFacade = new MealMenuItemFacade();
			//GenericList<MealMenu> _oMealMenuItemList = new GenericList<MealMenu>();
			//_oMealMenuItemList = _oMealMenuItemFacade.getMealMenus();
			//foreach (MealMenu _oMealMenu in _oMealMenuItemList)
			//{
			//    string[] items ={ _oMealMenu.Description, _oMealMenu.MenuID.ToString() };
			//    ListViewItem _listViewItem = new ListViewItem(items);
			//    lvwMenus.Items.Add(_listViewItem);
			//}

			//_oMealMenuItemFacade = new MealMenuItemFacade();
			//_oMealMenuItemList = new GenericList<MealMenu>();
			//_oMealMenuItemList = _oMealMenuItemFacade.getMealMenuItems();
			//foreach (MealMenu _oMealItem in _oMealMenuItemList)
			//{
			//    string[] item ={ _oMealItem.Description, _oMealItem.MealMenuItemID.ToString() };
			//    ListViewItem li = new ListViewItem(item);
			//    lvwMenus.Items.Add(li);
			//}


			IList<MealMenu> _oMealGroups = _oMealMenuItemFacade.getMealGroups();
			//this.cboMealGroups.Items.Clear();
			//this.cboMealGroups.Items.Add("ALL");
			//foreach (MealMenu _group in _oMealGroups)
			//{
			//    this.cboMealGroups.Items.Add(_group.Description);
			//}
			//this.cboMealGroups.SelectedIndex = 0;
            MealMenu _comboMeal = new MealMenu();
            _comboMeal.Description = "COMBO MEALS";
            _oMealGroups.Insert(0, _comboMeal);
			this.cboMealGroups.DataSource = _oMealGroups;
            this.cboMealGroups.DisplayMember = "Description";
			this.cboMealGroups.SelectedIndex = 0;


		}

		private void nudMealLiveOut_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				decimal totalMealCost = 0;

				EventAppliedRatesFacade _oAppliedRatesFacade = new EventAppliedRatesFacade();
				GenericList<EventAppliedRates> _oEventAppliedRatesList = _oAppliedRatesFacade.getAppliedRatesForEvents(txtFolioID.Text);
				foreach (EventAppliedRates _oEventAppliedRates in _oEventAppliedRatesList)
				{
					decimal liveInCost = 0;
					decimal liveOutCost = 0;
					if (_oEventAppliedRates.Description.ToUpper().Contains(cboMealType.Text) && _oEventAppliedRates.Description.ToUpper().Contains("LIVE-OUT"))
					{
						liveInCost = _oEventAppliedRates.RateAmount * decimal.Parse(nudMealLiveOut.Value.ToString());
                        lblPaxAmt.Visible = false;
                        nudPaxAmt.Visible = false;
                    }
					if (_oEventAppliedRates.Description.ToUpper().Contains(cboMealType.Text) && _oEventAppliedRates.Description.ToUpper().Contains("LIVE-IN"))
					{
						liveOutCost = _oEventAppliedRates.RateAmount * decimal.Parse(nudMealLiveIn.Value.ToString());
                        lblPaxAmt.Visible = false;
                        nudPaxAmt.Visible = false;
                    }
					totalMealCost += liveInCost + liveOutCost;
				}

				txtTotalMealAmount.Text = string.Format("{0:###,##0.#0}", totalMealCost);
                nudMealPax.Value = nudMealLiveOut.Value + nudMealLiveIn.Value;
			}
			catch { }
		}

		//to clear the text inside the groupboxes...
		private void clearMeals()
		{
            lblPaxAmt.Visible = true;
            nudPaxAmt.Visible = true;
            
            nudMealPax.Value = 0;
            nudMealLiveIn.Value = 0;
            nudMealLiveOut.Value = 0;
            txtTotalMealAmount.Value = 0;
            nudPaxAmt.Value = 0;
            txtVenueFood.Text = "";
            txtFoodRemarks.Text = "";
            txtFoodSetup.Text = "";
            txtFoodOver.Text = "";
			gridMealItems.Rows.Count = 1;
			cboMealType.Text = "";
            cboMealType.Enabled = false;
		}

		//if the selected item is a meal menu item, display the items of a meal menu
		//if it is a meal item, add it to the meal menu grid
		private void lvwMenus_DoubleClick(object sender, EventArgs e)
		{
            decimal _totalPrice = 0;
			try
			{
				MealMenuItemFacade _oMealMenuItemFacade = new MealMenuItemFacade();
				GenericList<MealMenu> _oMealMenuItemList = new GenericList<MealMenu>();
				_oMealMenuItemList = _oMealMenuItemFacade.getMealItemsForMenu(lvwMenus.SelectedItems[0].SubItems[1].Text);
				if (_oMealMenuItemList.Count > 0)
				{
                    txtTotalMealAmount.Value = 0;
					foreach (MealMenu _oMealMenuItems in _oMealMenuItemList)
					{
						string[] items ={ _oMealMenuItems.MenuID.ToString(), _oMealMenuItems.MealMenuItemID.ToString(), _oMealMenuItems.Description };
						gridMealItems.AddItem(items);
					}
                    _totalPrice += decimal.Parse(lvwMenus.SelectedItems[0].SubItems[2].Text);
                }
				else
				{
					string[] items ={ "", lvwMenus.SelectedItems[0].SubItems[1].Text, lvwMenus.SelectedItems[0].Text };
					gridMealItems.AddItem(items);
                    //_totalPrice += decimal.Parse(lvwMenus.SelectedItems[0].SubItems[2].Text);
                }
			}
			catch 
			{
				MessageBox.Show("Please select an item on the list.","Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.lvwMenus.Focus();
			}

            nudPaxAmt.Value = _totalPrice;
            txtTotalMealAmount.Value = nudPaxAmt.Value * nudMealPax.Value;

            //to check amount
            //nudMealLiveIn.Value += 1;
            //nudMealLiveIn.Value -= 1;

		}

		//for deleting selected node
		private void treeFoodBev_KeyDown(object sender, KeyEventArgs e)
		{
            MySqlTransaction _oTransactionCode = GlobalVariables.gPersistentConnection.BeginTransaction();
            try
			{
				if (e.KeyCode.ToString() == "Delete" && treeFoodBev.SelectedNode.Parent != null)
				{
                    DialogResult rsp = MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (rsp == DialogResult.Yes)
                    {
                        EventFoodRequirementsFacade _oEventRequirementsFacade = new EventFoodRequirementsFacade();
                        _oEventRequirementsFacade.deleteMealHeader(cboMealType.Tag.ToString());
                        treeFoodBev.SelectedNode.Remove();
                        
                        getTotalEstimatedCost();
                        saveBookingInfo(ref _oTransactionCode);
                    }
                }
                //else if (e.KeyCode.ToString() == "Delete" && treeFoodBev.SelectedNode.Parent == null)
                //{
                //    EventFoodRequirementsFacade _oEventFoodRequirementsFacade = new EventFoodRequirementsFacade();
                //    _oEventFoodRequirementsFacade.deleteMainMealHeader(txtFolioID.Text, treeFoodBev.SelectedNode.Text);
                //    treeFoodBev.SelectedNode.Remove();
                //}

				if (treeFoodBev.Nodes.Count <= 0)
				{
					btnNewMeal.Enabled = false;
					grpMealDetails.Enabled = false;
					btnSaveMeal.Enabled = false;
					clearMeals();
				}

                _oTransactionCode.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to delete item. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _oTransactionCode.Rollback();
			}
		}

		//for error trapping if meal menu type selected has already been added
		private void cboMealType_SelectedValueChanged(object sender, EventArgs e)
		{
			if (newMeal)
			{
				EventFoodRequirementsFacade _oEventFoodRequirementFacade = new EventFoodRequirementsFacade();
				bool _isNew = _oEventFoodRequirementFacade.mealHeaderExists(cboMealType.Text, dtpFoodDate.Value, txtFolioID.Text);
				if (_isNew)
				{
					MessageBox.Show("Meal type already exists for the day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					cboMealType.Text = " ";
				}
			}

            //to check total amount
            //nudMealLiveIn.Value += 1;
            //nudMealLiveIn.Value -= 1;
		}

		private void gridMealItems_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode.ToString() == "Delete")
				{
					gridMealItems.RemoveItem(gridMealItems.Row);
				}
			}
			catch { }
		}

		#endregion //>>meal requirements

		#region EVENT DETAILS / REQUIREMENTS

		//>>by Genny: Apr. 28, 2008
		//for getting event details
		public void loadEventBookingInfo()
		{
			GenericList<EventBookingInfo> _oEventBookingInfoList = new GenericList<EventBookingInfo>();
			_oEventBookingInfoList = loEventFacade.getEvent(txtFolioID.Text);
			foreach (EventBookingInfo _oEventBookingInfo in _oEventBookingInfoList)
			{
                //txtCreateTime.Text = _oEventBookingInfo.BookingDate.ToShortDateString();
				nudNumberOfPaxLiveIn.Value = int.Parse(_oEventBookingInfo.NumberOfLiveIn.ToString());
				nudNumberOfPaxLiveOut.Value = int.Parse(_oEventBookingInfo.NumberOfLiveOut.ToString());
				cboEventType.Text = _oEventBookingInfo.EventType;
				nudPaxGuaranteed.Value = int.Parse(_oEventBookingInfo.NumberOfPaxGuaranteed.ToString());
				txtBillingArrangement.Text = _oEventBookingInfo.BillingArrangement;
				txtSignatories.Text = _oEventBookingInfo.AuthorizedSignatory;
				txtLobbyPosting.Text = _oEventBookingInfo.LobbyPosting;
				cboEventGrpPackage.SelectedValue = _oEventBookingInfo.EventPackage;
				txtPackageAmount.Text = string.Format("{0:###,##0.#0}", _oEventBookingInfo.PackageAmount);
                txtTotalEstimatedCost.Text = string.Format("{0:###,##0.#0}", _oEventBookingInfo.EstimatedTotalCost);
				txtContactPerson.Text = _oEventBookingInfo.ContactPerson;
                txtDesignation.Text = _oEventBookingInfo.ContactPosition;
                txtCreateTime.Text = _oEventBookingInfo.BookingDate.ToString("dd-MMM-yyyy");
                txtGroupName.Tag = _oEventBookingInfo.PackagePosted.ToString();

                if (rdbIndividual.Checked == true)
                {
                    txtContactNumber1.Text = _oEventBookingInfo.ContactNumber;
                    //txtContactAddress.Text = _oEventBookingInfo.ContactAddress;
                    txtContactNumber2.Text = _oEventBookingInfo.MobileNumber;
                    txtContactNumber3.Text = _oEventBookingInfo.FaxNumber;
                    txtEmail1.Text = _oEventBookingInfo.EmailAddress;
                }
			}
		}//<<

		private void cboRequirementType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboRequirementType.SelectedValue.ToString() != "")
			{
				lvwDetails.Items.Clear();
				RequirementCodeFacade _oRequirementCodeFacade = new RequirementCodeFacade();
				GenericList<RequirementCode> _oRequirementCodeList = new GenericList<RequirementCode>();
				_oRequirementCodeList = _oRequirementCodeFacade.getDetailsForRequirements(cboRequirementType.SelectedValue.ToString());
				foreach (RequirementCode _oRequirementCode in _oRequirementCodeList)
				{
					lvwDetails.Items.Add(_oRequirementCode.Description); 
				}
                lvwDetails.LabelEdit = true;
			}
            txtRequirementNote.Text = "";
		}

        private void btnAddRequirements_Click(object sender, EventArgs e)
        {
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (cboRequirementType.Text.ToUpper().Contains("EVENT OFFICER") && _canAddEventOfficer == false)
            {
                MessageBox.Show("Sorry! You are not allowed to add Event Officers.\nPlease contact system administrator.\n\nThank you!", "Add Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboRequirementType.Text = "";
                txtRequirementNote.Text = "";
                return;
            }

            string _roomID = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 0);
            string _date = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 1);
            //string _toDate = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 2);
            //string _startTime = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 3);
            //string _endTime = gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 4);
            string _schedule = _roomID + " : " + _date;
            
            if (txtRequirementNote.Text == "")
            {
                if (cboRequirementType.Text != "")
                {
                    //TreeNode _node = new TreeNode(cboRequirementType.Text);
                    TreeNode _parentNode = new TreeNode(_schedule);
                    TreeNode _childNode = new TreeNode(cboRequirementType.Text);
                    bool _isChecked = false;
                    foreach (ListViewItem _listViewItem in lvwDetails.Items)
                    {
                        if (checkIfRequirementIsAdded(_schedule, cboRequirementType.Text, _listViewItem.SubItems[0].Text) == false)
                        {
                            if (_listViewItem.Checked == true)
                            {
                                _childNode.Nodes.Add(_listViewItem.SubItems[0].Text);
                                _isChecked = _isChecked || true;
                            }
                            else
                            {
                                _isChecked = _isChecked || false;
                            }
                        }
                    }

                    if (_isChecked == true)
                    {
                        _parentNode.Nodes.Add(_childNode);
                        treeRequirements.Nodes.Add(_parentNode);
                        treeRequirements.ExpandAll();
                    }
                }
            }
            else
            {
                if (cboRequirementType.Text != "")
                {
                    if (checkIfRequirementIsAdded(_schedule, cboRequirementType.Text, txtRequirementNote.Text) == false)
                    {
                        TreeNode _parentNode = new TreeNode(_schedule); //TreeNode(cboRequirementType.Text);
                        TreeNode _childNode = new TreeNode(cboRequirementType.Text);
                        _childNode.Nodes.Add(txtRequirementNote.Text);
                        _parentNode.Nodes.Add(_childNode);
                        treeRequirements.Nodes.Add(_parentNode);
                        treeRequirements.ExpandAll();

                        txtRequirementNote.Text = "";
                    }
                }
            }
        }

        private bool checkIfRequirementIsAdded(string pRequirementSchedule, string pRequirementCode, string pRequirementDescription)
        {
            //foreach (TreeNode _node in treeRequirements.Nodes)
            //{
            //    if (_node.Text == pRequirementSchedule)
            //        return true;

            //    foreach (TreeNode _childNode in _node.Nodes)
            //    {
            //        if (_childNode.Text == pRequirementSchedule)
            //            return true;
            //    }
            //}

            foreach (TreeNode _parentNode in treeRequirements.Nodes)
            {
                if (_parentNode.Text == pRequirementSchedule)
                {
                    foreach (TreeNode _childNode in _parentNode.Nodes)
                    {
                        if (_childNode.Text == pRequirementCode)
                        {
                            foreach (TreeNode _subNode in _childNode.Nodes)
                            {
                                if (_subNode.Text == pRequirementDescription)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void btnRemoveRequirements_Click(object sender, EventArgs e)
        {
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 
            
            try
            {
                treeRequirements.SelectedNode.Remove();
                this.Text = "Group Folio*";
            }
            catch { }
        }

		private void btnSaveRequirements_Click(object sender, EventArgs e)
		{
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
			if (saveRequirements(ref _oTransaction))
			{
				MessageBox.Show("Transaction successful. " + "\r\n" + "Event Requirements has been saved", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			this.Text = "Group Folio";
            _oTransaction.Commit();
		}

		private bool saveRequirements(ref MySqlTransaction pTrans)
		{
			try
			{
                txtRequirementNote.Text = "";

				//>>for other requirements
				EventRequirementsFacade _oEventRequirementsFacade = new EventRequirementsFacade();
				EventRequirements _oEventRequirements = new EventRequirements();
				_oEventRequirementsFacade.deleteEventsRequirements(txtFolioID.Text, ref pTrans);

				for (int _ctr = 0; _ctr < treeRequirements.Nodes.Count; _ctr++)
				{
					foreach (TreeNode _treeNode in treeRequirements.Nodes[_ctr].Nodes)
					{
                        //_oEventRequirements.FolioID = txtFolioID.Text;
                        //_oEventRequirements.RequirementCode = _treeNode.Parent.Text;
                        //_oEventRequirements.Description = _treeNode.Text;
                        _oEventRequirements.FolioID = txtFolioID.Text;
                        _oEventRequirements.Remarks = _treeNode.Parent.Text;

                        foreach (TreeNode _childNode in _treeNode.Nodes)
                        {
                            _oEventRequirements.RequirementCode = _childNode.Parent.Text;
                            _oEventRequirements.Description = _childNode.Text;

                            try
                            {
                                _oEventRequirementsFacade.saveEventsRequirements(_oEventRequirements, ref pTrans);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Transaction failed.\r\nError in saving event requirements.\r\n\r\nError message : " + ex.Message);
                            }
                        }
					}
				}//<<end other requirements
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void loadRequirementDetails()
		{
			EventRequirementsFacade _oEventRequirementFacade = new EventRequirementsFacade();
			GenericList<EventRequirements> _oEventRequirementList = _oEventRequirementFacade.getEventRequirements(txtFolioID.Text);
            //foreach (EventRequirements _oEventRequirement in _oEventRequirementList)
            //{
            //    if (treeRequirements.Nodes.Count > 0)
            //    {
            //        foreach (TreeNode _parentNode in treeRequirements.Nodes)
            //        {
            //            //if (_tNode.Text == _oEventRequirement.RequirementCode || (_tNode.Text == _oEventRequirement.RequirementCode && _tNode.Index == treeRequirements.Nodes.Count - 1))
            //            if (_parentNode.Text == _oEventRequirement.Remarks || (_parentNode.Text == _oEventRequirement.Remarks && _parentNode.Index == treeRequirements.Nodes.Count - 1))
            //            {
            //                //_parentNode.Nodes.Add(_oEventRequirement.Description);
            //                _parentNode.Nodes.Add(_oEventRequirement.RequirementCode);
            //            }
            //            else if ((_parentNode.Text != _oEventRequirement.Remarks && _parentNode.Index != treeRequirements.Nodes.Count - 1))
            //            { }
            //            else
            //            {
            //                TreeNode _node = new TreeNode(_oEventRequirement.RequirementCode);
            //                _node.Nodes.Add(_oEventRequirement.Description);
            //                treeRequirements.Nodes.Add(_node);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        TreeNode _parentNode = new TreeNode(_oEventRequirement.Remarks);
            //        TreeNode _childNode = new TreeNode(_oEventRequirement.RequirementCode);
            //        _childNode.Nodes.Add(_oEventRequirement.Description);
            //        _parentNode.Nodes.Add(_childNode);
            //        treeRequirements.Nodes.Add(_parentNode);
            //    }

            //    treeRequirements.ExpandAll();
            //}

            foreach (EventRequirements _oEventRequirements in _oEventRequirementList)
            {
                if (treeRequirements.Nodes.Count > 0)
                {
                    foreach (TreeNode _parentNode in treeRequirements.Nodes)
                    {
                        if (_parentNode.Text == _oEventRequirements.Remarks || (_parentNode.Text == _oEventRequirements.Remarks && _parentNode.Index == treeRequirements.Nodes.Count - 1))
                        {
                            foreach (TreeNode _childNode in _parentNode.Nodes)
                            {
                                if (_childNode.Text == _oEventRequirements.RequirementCode || (_childNode.Text == _oEventRequirements.RequirementCode && _childNode.Index == _parentNode.Nodes.Count - 1))
                                {
                                    _childNode.Nodes.Add(_oEventRequirements.Description);
                                }
                                else if (_childNode.Text != _oEventRequirements.RequirementCode && _childNode.Index != _parentNode.Nodes.Count - 1)
                                {
                                }
                                else
                                {
                                    TreeNode _newChildNode = new TreeNode(_oEventRequirements.RequirementCode);
                                    _newChildNode.Nodes.Add(_oEventRequirements.Description);
                                    _parentNode.Nodes.Add(_newChildNode);
                                }
                            }
                        }
                        else if (_parentNode.Text != _oEventRequirements.Remarks && _parentNode.Index != treeRequirements.Nodes.Count - 1)
                        {
                        }
                        else
                        {
                            TreeNode _newParentNode = new TreeNode(_oEventRequirements.Remarks);
                            TreeNode _newChildNode = new TreeNode(_oEventRequirements.RequirementCode);
                            _newChildNode.Nodes.Add(_oEventRequirements.Description);
                            _newParentNode.Nodes.Add(_newChildNode);
                            treeRequirements.Nodes.Add(_newParentNode);
                        }
                    }
                }
                else
                {
                    TreeNode _newParentNode = new TreeNode(_oEventRequirements.Remarks);
                    TreeNode _newChildNode = new TreeNode(_oEventRequirements.RequirementCode);
                    _newChildNode.Nodes.Add(_oEventRequirements.Description);
                    _newParentNode.Nodes.Add(_newChildNode);
                    treeRequirements.Nodes.Add(_newParentNode);
                }
            }
            treeRequirements.ExpandAll();
        }

		#endregion //>>event details / requirements

		#region EVENT PACKAGES

        private void cboEventGrpPackage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (lGroupFolioStatus != "New" && lEdit != true)
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEventGrpPackage.SelectedValue = loFolio.PackageID;
                txtFolioID.Focus();
            }
            else
            {
                loFolio.RecurringCharges = null;
                cboEventPackage.Text = cboEventGrpPackage.Text;
            }
        }

        private void deletePackageRecurringCharges()
        {
            foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
            {
                if (_row.Index > 0 && grdRecurredCharge.GetCellCheck(_row.Index, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    grdRecurredCharge.RemoveItem(_row.Index);
                    deletePackageRecurringCharges();
                    return;
                }
            }
        }

		private void cboEventPackage_SelectionChangeCommitted(object sender, EventArgs e)
		{
			grdRecurredCharge.Rows.Count = 1;
			loadFolioRecurringCharges();

			EventPackageFacade _oEventPackageFacade = new EventPackageFacade();
			//txtPackageAmount.Text = _oEventPackageFacade.getEventPackageAmount(cboEventPackage.SelectedValue.ToString()).ToString();

            if (lEdit == true || lGroupFolioStatus == "New")
            {
                deletePackageRecurringCharges();
                EventPackageDetailFacade _oEventPackageDetailFacade = new EventPackageDetailFacade();
                EventPackageHeader _oEventPackageHeader = _oEventPackageFacade.getEventPackage(cboEventGrpPackage.SelectedValue.ToString());
                GenericList<EventPackageDetail> _eventPackageDetailList = _oEventPackageDetailFacade.getEventPackageDetails(cboEventGrpPackage.SelectedValue.ToString());

                nudNumberOfPaxLiveIn.Value = decimal.Parse(_oEventPackageHeader.MinimumPax.ToString());
                nudNumberOfPaxLiveOut.Value = decimal.Parse(_oEventPackageHeader.MaximumPax.ToString());

                foreach (EventPackageDetail _oEventPackageDetail in _eventPackageDetailList)
                {
                    grdRecurredCharge.Rows.Count++;
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 0, true);
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 3, _oEventPackageDetail.TransactionCode.ToString());
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 4, _oEventPackageDetail.Description);
                    grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 10, _oEventPackageDetail.Amount);

                    try
                    {
                        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, gridFunctionRooms.GetData(1, 3));
                        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, gridFunctionRooms.GetData(1, 3));
                    }
                    catch
                    {
                        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 11, DateTime.Parse(GlobalVariables.gAuditDate));
                        grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 12, DateTime.Parse(GlobalVariables.gAuditDate));
                    }

                    //grdRecurredCharge.SetData(grdRecurredCharge.Rows.Count - 1, 6, _oEventPackageDetail.SubAccount);
                }

                EventPackageDetailFacade _oEventPackageRequirementFacade = new EventPackageDetailFacade();
                GenericList<EventPackageDetail> _oEventPackageRequirementList = _oEventPackageRequirementFacade.getEventPackageRequirements(cboEventGrpPackage.SelectedValue.ToString());
                treeRequirements.Nodes.Clear();
                foreach (EventPackageDetail _oEventPackageRequirement in _oEventPackageRequirementList)
                {
                    if (treeRequirements.Nodes.Count > 0)
                    {
                        foreach (TreeNode _tNode in treeRequirements.Nodes)
                        {
                            if (_tNode.Text == _oEventPackageRequirement.RequirementHeader || (_tNode.Text == _oEventPackageRequirement.RequirementHeader && _tNode.Index == treeRequirements.Nodes.Count - 1))
                            {
                                _tNode.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
                            }
                            else if ((_tNode.Text != _oEventPackageRequirement.RequirementHeader && _tNode.Index != treeRequirements.Nodes.Count - 1))
                            { }
                            else if (_tNode.Text == _oEventPackageRequirement.RequirementDetail)
                            { }
                            else
                            {
                                TreeNode _node = new TreeNode(_oEventPackageRequirement.RequirementHeader);
                                _node.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
                                treeRequirements.Nodes.Add(_node);
                            }
                        }
                    }
                    else
                    {
                        TreeNode _node = new TreeNode(_oEventPackageRequirement.RequirementHeader);
                        _node.Nodes.Add(_oEventPackageRequirement.RequirementDetail);
                        treeRequirements.Nodes.Add(_node);
                    }

                    treeRequirements.ExpandAll();
                }
                computePackageAmount();
            }
            cboEventPackage.Text = cboEventGrpPackage.Text;
        }

		#endregion //>>packages

		#region EVENT ROOM REQUIREMENTS

		private void btnSaveRooms_Click(object sender, EventArgs e)
		{
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
			if (saveChildRoomRequirements(ref _oTransaction))
			{
				MessageBox.Show("Transaction successful. " + "\r\n" + "Room Reservation has been saved", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			this.Text = "Group Folio";
            _oTransaction.Commit();
		}

		//for computation of _rooms
		private void gridRooms_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			decimal _pax = 0;
			decimal _rooms = 0;
            decimal _guaranteedRooms = 0;

			try
			{
				foreach (C1.Win.C1FlexGrid.Row r in gridRooms.Rows)
				{
                    if (r.Index != 0)
                    {
                        _pax += decimal.Parse(gridRooms.GetDataDisplay(r.Index, 2));
                        _rooms += decimal.Parse(gridRooms.GetDataDisplay(r.Index, 1));
                        _guaranteedRooms += decimal.Parse(gridRooms.GetDataDisplay(r.Index, 3));


                        if (decimal.Parse(gridRooms.GetDataDisplay(r.Index, 1)) > decimal.Parse(gridRooms.GetDataDisplay(r.Index, 3)))
                        {
                            gridRooms.Rows[r.Index].StyleNew.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            gridRooms.Rows[r.Index].StyleNew.BackColor = System.Drawing.Color.White;
                        }
                    }
				}
            }
			catch 
            {
                if (this.MdiParent != null)
                {
                    this.MdiParent.Cursor = Cursors.Default;
                }
            }

            nudPax.Value = _pax;

            try
            {
                nudGuaranteedPax.Value = _pax / _rooms * _guaranteedRooms;
            }
            catch
            {
                nudGuaranteedPax.Value = _pax;
            }

			nudRooms.Value = _rooms;
            nudGuaranteedRooms.Value = _guaranteedRooms;
		}

		private void nudNumberOfPaxLiveIn_ValueChanged(object sender, EventArgs e)
		{
			nudPax.Value = nudNumberOfPaxLiveIn.Value;
            nudPaxGuaranteed.Value = nudNumberOfPaxLiveIn.Value + nudNumberOfPaxLiveOut.Value;
		}

		//for updating the _rooms that has been blocked
		private void btnBlock_Click(object sender, EventArgs e)
		{
            MySqlTransaction _oTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

            try
            {
                string _folioID = this.txtFolioID.Text;

                string _eventName = txtGroupName.Text + " [" + txtFolioID.Text + "]";
                ArrayList _blockedRoomsArray = new ArrayList(10);
                ArrayList _roomsToBlockArray = new ArrayList(10);
                ArrayList _roomsNeededArray = new ArrayList(10);

                //for rooms to be blocked, needed and number of rooms blocked
                foreach (C1.Win.C1FlexGrid.Row _cntRows in gridRooms.Rows)
                {
                    if (_cntRows.Index != 0)
                    {
                        //for rooms blocked
                        _blockedRoomsArray.Add(gridRooms.GetDataDisplay(_cntRows.Index, 3));

                        //for rooms to be blocked
                        int _rooms = int.Parse(gridRooms.GetDataDisplay(_cntRows.Index, 1)) - int.Parse(gridRooms.GetDataDisplay(_cntRows.Index, 3));
                        _roomsToBlockArray.Add(_rooms);

                        //for rooms needed
                        _roomsNeededArray.Add(int.Parse(gridRooms.GetDataDisplay(_cntRows.Index, 1)) - int.Parse(gridRooms.GetDataDisplay(_cntRows.Index, 3)));
                    }
                }

                DateTime _startDate, _endDate;
                if (gridFunctionRooms.Rows.Count > 1)
                {
                    _startDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(1, 3));
                    _endDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 4));
                }
                else
                {
                    // to pass on FOlio Start Date if no Function Schedule
                    try
                    {
                        _startDate = loFolio.FromDate;
                        _endDate = loFolio.Todate;
                    }
                    catch
                    {
                        _startDate = DateTime.Parse(GlobalVariables.gAuditDate);
                        _endDate = DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1);
                    }
                }

                //check whether event date has passed
                if (_startDate < DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    _startDate = DateTime.Parse(GlobalVariables.gAuditDate);
                }
                if (_endDate <= DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    _endDate = DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1);
                }

                //GroupBlokingUI _oRoomBlock = new GroupBlokingUI(_eventName, _startDate, _endDate, _blockedRoomsArray, _roomsToBlockArray, _roomsNeededArray);

                GroupBlokingUI _oRoomBlock = new GroupBlokingUI(_eventName,
                                                                 _folioID,
                                                                 _startDate,
                                                                 _endDate,
                                                                 _blockedRoomsArray,
                                                                 _roomsToBlockArray,
                                                                 _roomsNeededArray);

                _oRoomBlock.ShowDialog();

                for (int _ctr = 0; _ctr < gridRooms.Rows.Count - 1; _ctr++)
                {
                    gridRooms.SetData(_ctr + 1, 3, _blockedRoomsArray[_ctr]);
                }
                saveChildRoomRequirements(ref _oTransaction);
                loadFolio();
                loadRoomRequirements();

                _oTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR @ Blocking Rooms: " + ex.Message);
                _oTransaction.Rollback();
            }
		}

		//for getting the _rooms blocked by the event
		private void loadRooms()
		{
            gridBlockedRooms.Rows.Count = 1;
			RoomBlockFacade _oRoomBlockFacade = new RoomBlockFacade();
			
            string _eventName = txtGroupName.Text + " [" + txtFolioID.Text + "]";
			//GenericList<RoomBlock> _oRoomBlockList = _oRoomBlockFacade.getBlockedRoomsForEvent(_eventName);

			//get Blocked Rooms by Folio Id[ added column folioID on table RoomBlock ]
			string _folioID = txtFolioID.Text;
			GenericList<RoomBlock> _oRoomBlockList = _oRoomBlockFacade.getBlockedRoomsForEventByFolioId(_folioID);


			foreach (RoomBlock _oRoomBlock in _oRoomBlockList)
			{
				RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();
				string _roomType = _oRoomTypeFacade.getRoomType(_oRoomBlock.RoomID.ToString());
                gridBlockedRooms.Rows.Count++;
                gridBlockedRooms.SetData(gridBlockedRooms.Rows.Count - 1, 0, _roomType);
                gridBlockedRooms.SetData(gridBlockedRooms.Rows.Count - 1, 1, _oRoomBlock.RoomID);

				grdFolio.Rows.Count++;
				grdFolio.SetData(grdFolio.Rows.Count - 1, 0, "");
				grdFolio.SetData(grdFolio.Rows.Count - 1, 1, txtGroupName.Text);
				grdFolio.SetData(grdFolio.Rows.Count - 1, 2, _oRoomBlock.BlockFrom);
				grdFolio.SetData(grdFolio.Rows.Count - 1, 3, _oRoomBlock.BlockTo);
				grdFolio.SetData(grdFolio.Rows.Count - 1, 4, _oRoomBlock.RoomID + "-" + _roomType);
				grdFolio.SetData(grdFolio.Rows.Count - 1, 5, "");
				grdFolio.SetData(grdFolio.Rows.Count - 1, 6, "");
				grdFolio.SetData(grdFolio.Rows.Count - 1, 7, "");
				grdFolio.SetData(grdFolio.Rows.Count - 1, 8, "");
				grdFolio.SetData(grdFolio.Rows.Count - 1, 9, _oRoomBlock.BlockID.ToString());
			}

            //for displaying in gridblocked rooms the reserved rooms
            DataTable _getChildData;
            loFolioFacade = new FolioFacade();
            _getChildData = loFolioFacade.GetChildFoliosTable(txtFolioID.Text);
            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            Folio _oFolio = new Folio();

            foreach (DataRow _tempLoopVarDtRow in _getChildData.Rows)
            {
                DataRow _dtRow = _tempLoopVarDtRow;
                if (_dtRow["foliotype"].ToString() != "JOINER" && _dtRow["status"].ToString() != "CANCELLED")
                {
                    Schedule _oSchedule = new Schedule();
                    string _rooms;
                    if (_dtRow["masterfolio"].ToString() == "" || _dtRow["masterfolio"].ToString() != "" && _dtRow["foliotype"].ToString() == "DEPENDENT")
                    {
                        _rooms = _oScheduleFacade.GetRoomFromSchedules(_dtRow["foLIOid"].ToString());
                    }
                    else
                    {
                        _rooms = _oScheduleFacade.GetRoomFromSchedules(_dtRow["masterfolio"].ToString());
                    }
                    if (_rooms == "")
                    {
                        _rooms = "";
                    }
                    else
                    {
                        _rooms = _rooms.Substring(0, _rooms.Length - 2);
                    }

                    RoomTypeFacade oRoomTypeFacade = new RoomTypeFacade();
                    string _roomType;
                    if (_rooms.Contains(","))
                    {
                        _rooms = _rooms.Substring(0, _rooms.IndexOf(","));
                    }
                    try
                    {
                        _roomType = oRoomTypeFacade.getRoomType(_rooms);
                    }
                    catch
                    {
                        _roomType = "";
                    }

                    gridBlockedRooms.Rows.Count++;
                    gridBlockedRooms.SetData(gridBlockedRooms.Rows.Count - 1, 0, _roomType);
                    gridBlockedRooms.SetData(gridBlockedRooms.Rows.Count - 1, 1, _rooms);
                }
            }

            gridBlockedRooms.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            gridBlockedRooms.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 0);
            for (int i = gridBlockedRooms.Cols.Fixed; i <= gridBlockedRooms.Cols.Count - 1; i++)
            {
                gridBlockedRooms.Cols[i].AllowMerging = true;
            }
		}

        //>>by Genny: Apr. 30, 2008
        //to display all Room Requirements
        private void loadRoomRequirements()
		{
			try
			{
				EventRoomRequirementFacade _oRoomRequirementFacade = new EventRoomRequirementFacade();
				GenericList<EventRoomRequirements> _oEventBookingInfoList = new GenericList<EventRoomRequirements>();
				_oEventBookingInfoList = _oRoomRequirementFacade.getRoomRequirements(txtFolioID.Text);
                gridRooms.Rows.Count = 1;
                int _rooms = 0;
                int _pax = 0;

				foreach (EventRoomRequirements _oEventRoomRequirement in _oEventBookingInfoList)
				{
                    gridRooms.Rows.Count++;

                    gridRooms.SetData(gridRooms.Rows.Count - 1, 0, _oEventRoomRequirement.RoomType);
					gridRooms.SetData(gridRooms.Rows.Count - 1, 1, _oEventRoomRequirement.NumberOfRooms.ToString());
                    gridRooms.SetData(gridRooms.Rows.Count - 1, 2, _oEventRoomRequirement.NumberOfPax.ToString());
                    nudGuaranteedRooms.Value = _oEventRoomRequirement.GuaranteedRooms;
                    //nudGuaranteedPax.Value = _oEventRoomRequirement.GuaranteedPax;
                    try
                    {
                        gridRooms.SetData(gridRooms.Rows.Count - 1, 3, _oEventRoomRequirement.BlockedRooms.ToString());
                    }
                    catch
                    {
                        gridRooms.SetData(gridRooms.Rows.Count - 1, 3, 0);
                    }
					txtRoomRemarks.Text = _oEventRoomRequirement.Remarks;

                    _rooms += _oEventRoomRequirement.NumberOfRooms;
                    _pax += _oEventRoomRequirement.NumberOfPax;

                    //if #of rooms blocked is less than #of rooms needed, backcolor will be red
                    if (_oEventRoomRequirement.BlockedRooms < _oEventRoomRequirement.NumberOfRooms) 
                    {
                        gridRooms.Rows[gridRooms.Rows.Count - 1].StyleNew.BackColor = System.Drawing.Color.Red;
                    }
				}

                nudRooms.Value = _rooms;
                nudPaxGuaranteed.Value = _pax;
                
                getFolioSchedules();
			}
			catch { }

            if (gridRooms.Rows.Count <= 1)
            {
                RoomType _oRoomType = new RoomType();
                RoomTypeFacade _oRoomTypeFacade = new RoomTypeFacade();
                _oRoomType = (RoomType)_oRoomTypeFacade.loadObject();

                DataView _dtvRoomTypes = _oRoomType.Tables[0].DefaultView;
                _dtvRoomTypes.RowStateFilter = DataViewRowState.OriginalRows;
                _dtvRoomTypes.RowFilter = "roomTypeCode not like '*FUNCTION*'";
                foreach (DataRowView _dRow in _dtvRoomTypes)
                {
                    string[] items ={ _dRow["roomtypecode"].ToString(), "0", "0", "0", "0", "0", "0", "0" };
                    gridRooms.AddItem(items);
                }
            }
		}//<<

		private bool saveChildRoomRequirements(ref MySqlTransaction pTrans)
		{
			try
			{
				//>>room requirements
				EventRoomRequirements _oEventRoomRequirements = new EventRoomRequirements();
				EventRoomRequirementFacade _oEventRoomRequirementFacade = new EventRoomRequirementFacade();
				_oEventRoomRequirementFacade.deleteRoomRequirements(txtFolioID.Text, ref pTrans);
				foreach (C1.Win.C1FlexGrid.Row _cntRow in gridRooms.Rows)
				{
					if (_cntRow.Index != 0)
					{
						_oEventRoomRequirements.FolioID = txtFolioID.Text;
						_oEventRoomRequirements.RoomType = gridRooms.GetDataDisplay(_cntRow.Index, 0);
						_oEventRoomRequirements.NumberOfPax = int.Parse(gridRooms.GetDataDisplay(_cntRow.Index, 2));
						_oEventRoomRequirements.NumberOfRooms = int.Parse(gridRooms.GetDataDisplay(_cntRow.Index, 1));
                        try
                        {
                            _oEventRoomRequirements.GuaranteedPax = (int)Math.Abs(nudGuaranteedPax.Value);
                        }
                        catch
                        {
                            _oEventRoomRequirements.GuaranteedPax = int.Parse(nudPax.Value.ToString());
                        }
						_oEventRoomRequirements.GuaranteedRooms = int.Parse(nudGuaranteedRooms.Value.ToString());
						_oEventRoomRequirements.Remarks = txtRoomRemarks.Text;
						int _blockedRooms = int.Parse(gridRooms.GetDataDisplay(_cntRow.Index, 3));

                        if (_blockedRooms >= 0)
                        {
                            _oEventRoomRequirements.BlockedRooms = _blockedRooms;
                        }
                        else
                        {
                            _oEventRoomRequirements.BlockedRooms = 0;
                        }

						try
						{
							_oEventRoomRequirementFacade.saveRoomRequirements(_oEventRoomRequirements, ref pTrans);
						}
						catch
						{
							MessageBox.Show("Event Room Requirements was not saved.", "Error in saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}//<<

				return true;
			}

			catch
			{
				return false;
			}
		}//<<end saveChildRoomRequirements

        private void saveFunctionRooms()
        {
            /* check first whether folio's status is already checked-in or not
             * if checked-in, update the folioschedules and roomevents with the correct schedules
             * if tentative, delete folioschedules and roomevents then save again
             */

            string _roomID = "";
            DateTime _startDate, _endDate, _startTime, _endTime;

            /*  for each row in the grid of function rooms
             *  save to folioschedules and roomevents
             */
            //if (cboStatus.Text == "TENTATIVE")
            //{
            lScheduleList = new GenericList<Schedule>();
            foreach (C1.Win.C1FlexGrid.Row _row in gridFunctionRooms.Rows)
            {
                if (_row.Index != 0)
                {
                    _roomID = gridFunctionRooms.GetDataDisplay(_row.Index, 0);
                    _startDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(_row.Index, 3));
                    _endDate = DateTime.Parse(gridFunctionRooms.GetDataDisplay(_row.Index, 4));
                    _startTime = DateTime.Parse(gridFunctionRooms.GetDataDisplay(_row.Index, 5));
                    _endTime = DateTime.Parse(gridFunctionRooms.GetDataDisplay(_row.Index, 6));

                    Schedule _oSchedule = new Schedule();
                    _oSchedule.RoomID = _roomID;
                    _oSchedule.RoomType = "FUNCTION";
                    _oSchedule.FromDate = _startDate;
                    _oSchedule.ToDate = _endDate;
                    _oSchedule.RateType = gridFunctionRooms.GetDataDisplay(_row.Index, 7);
                    _oSchedule.Rate = decimal.Parse(gridFunctionRooms.GetDataDisplay(_row.Index, 8));
                    _oSchedule.BreakFast = "N";
                    _oSchedule.FolioID = txtFolioID.Text;
                    _oSchedule.HotelID = GlobalVariables.gHotelId;
                    _oSchedule.CreatedBy = GlobalVariables.gLoggedOnUser;
                    _oSchedule.UpdatedBy = GlobalVariables.gLoggedOnUser;
                    _oSchedule.StartTime = _startTime;
                    _oSchedule.TerminalId = GlobalVariables.gTerminalID.ToString();
                    _oSchedule.ShiftCode = GlobalVariables.gShiftCode.ToString();
                    _oSchedule.EndTime = _endTime;
                    _oSchedule.Venue = gridFunctionRooms.GetDataDisplay(_row.Index, 2);
                    _oSchedule.Setup = gridFunctionRooms.GetDataDisplay(_row.Index, 9);
                    _oSchedule.Activity = gridFunctionRooms.GetDataDisplay(_row.Index, 10);
                    _oSchedule.Remarks = gridFunctionRooms.GetDataDisplay(_row.Index, 12);
                    _oSchedule.Id = gridFunctionRooms.GetDataDisplay(_row.Index, 13);
                    /* FP-SCR-00140 #1 [07.22.2010]
                     * added for guaranteed pax */
                    if (gridFunctionRooms.GetDataDisplay(_row.Index, 11) == "")
                        _oSchedule.GuaranteedPax = "0";
                    else
                        _oSchedule.GuaranteedPax = gridFunctionRooms.GetDataDisplay(_row.Index, 11);

                    lScheduleList.Add(_oSchedule);
                }
            }

            loFolio.Schedule = lScheduleList;
            //}//end if for tentative
            //else //for folios that have a status of ONGOING
            //{

            //}
        }

		#endregion  //>>room requirements

		#region ROOM EVENTS AND SCHEDULES

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

        private void updateGuestInformation()
        {
            // create new guest account
            loGuestFacade = new GuestFacade();
            Guest _newGuest = new Guest();
            loFolio.Guest = loGuestFacade.getGuestRecord(txtcompanyid.Text);

            _newGuest.AccountId = this.txtcompanyid.Text;
            _newGuest.AccountName = this.txtLastName.Text + "_" + this.txtFirstName.Text;
            _newGuest.Title = loFolio.Guest.Title;
            _newGuest.LastName = this.txtLastName.Text;
            _newGuest.FirstName = this.txtFirstName.Text;
            _newGuest.MiddleName = loFolio.Guest.MiddleName;
            _newGuest.Sex = loFolio.Guest.Sex;
            _newGuest.Citizenship = loFolio.Guest.Citizenship;
            _newGuest.PassportId = loFolio.Guest.PassportId;
            _newGuest.GuestImage = loFolio.Guest.GuestImage;
            _newGuest.TelephoneNo = txtContactNumber1.Text;
            _newGuest.MobileNo = this.txtContactNumber3.Text;
            _newGuest.FaxNo = this.txtContactNumber2.Text;
            _newGuest.Street = this.txtStreet1.Text;
            _newGuest.City = this.txtCity1.Text;
            _newGuest.Country = this.txtCountry1.Text;
            _newGuest.Zip = this.txtZip1.Text;
            _newGuest.EmailAddress = loFolio.Guest.EmailAddress;

            _newGuest.Remark = loFolio.Guest.Remark;
            _newGuest.Concierge = loFolio.Guest.Concierge;
            _newGuest.Memo = loFolio.Guest.Memo;
            _newGuest.BIRTH_DATE = loFolio.Guest.BIRTH_DATE;

            _newGuest.NoOfVisits = loFolio.Guest.NoOfVisits;
            _newGuest.TOTAL_SALES_CONTRIBUTION = loFolio.Guest.TOTAL_SALES_CONTRIBUTION;

            _newGuest.HotelID = GlobalVariables.gHotelId;
            _newGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
            _newGuest.UpdatedBy = GlobalVariables.gLoggedOnUser;

            _newGuest.ACCOUNT_TYPE = loFolio.Guest.ACCOUNT_TYPE;
            _newGuest.CARD_NO = loFolio.Guest.CARD_NO;
            _newGuest.THRESHOLD_VALUE = loFolio.Guest.THRESHOLD_VALUE;

            _newGuest.CreditCardNo = loFolio.Guest.CreditCardNo;
            _newGuest.CreditCardType = loFolio.Guest.CreditCardType;
            _newGuest.CreditCardExpiry = loFolio.Guest.CreditCardExpiry;
            _newGuest.TaxExempted = loFolio.TaxExempted;
            _newGuest.AccountPrivileges = loFolio.Guest.AccountPrivileges;

            AccountInformation _oAccountInformation = new AccountInformation();
            _oAccountInformation.AccountID = _newGuest.AccountId;
            _oAccountInformation.HotelID = GlobalVariables.gHotelId;
            _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");
            _newGuest.AccountInformation = _oAccountInformation;
            // Review to get SP
            loGuestFacade.updateGuest(ref _newGuest);

            this.loFolio.Guest = _newGuest;
        }

        private RoomEventCollection RoomeventsToRemove = new RoomEventCollection();
        private ArrayList NewRoomEventsCollection = new ArrayList();

        private void saveGroupFolio(ref MySqlTransaction pTrans)
        {
            loFolioFacade = new FolioFacade();

            txtAccountType.Text = cboAccountType.Text;
            txtGroupName.Text = txtGroupName.Text.Replace('\'', '`');
            //check if needs to change reference number
            bool _refNoChanged = false;
            if (string.Format("{0:MMM-yyyy}", loFolio.FromDate) != string.Format("{0:MMM-yyyy}", dtpFromDate.Value))
            {
                _refNoChanged = true;
            }
            FormToObjectInstanceBinder.BindObjectToInputControls(this, loFolio);
            if (rdbCompany.Checked == true)
            {
                // Insert/Update Company
                if (loFolio.Company == null && loFolio.CompanyID == "")
                {
                    createNewCompanyAccount();
                    loFolio.CompanyID = txtcompanyid.Text;
                }
                else
                {
                    
                    updateCompanyInformation(); // update guest information
                }
            }
            else if (rdbIndividual.Checked == true)
            {
                updateGuestInformation();
            }

            loFolio.UpdatedBy = GlobalVariables.gLoggedOnUser;
            loFolio.Remarks = txtGroupRemarks.Text;
            loFolio.Package = assignFolioPackage(loFolio);
            loFolio.RecurringCharges = assignRecurringCharges();
            loFolio.FolioRouting = assignFolioRouting();
            loFolio.Privileges = setUpFolioPrivileges();
            loFolio.TerminalId = GlobalVariables.gTerminalID.ToString();
            loFolio.ShiftCode = GlobalVariables.gShiftCode.ToString();
            loFolio.ContactPersons = assignContactPersons();
            loFolio.EventOfficers = assignEventOfficers();
            loFolio.IncumbentOfficers = assignIncumbentOfficers();
            loFolio.EventEndorsement = assignEventEndorsement();
            loFolio.EventAttendance = assignEventAttendance();
            if (gridFunctionRooms.Rows.Count > 1)
            {
                loFolio.FolioETA = gridFunctionRooms.GetDataDisplay(1, 5);
                loFolio.FolioETD = gridFunctionRooms.GetDataDisplay(gridFunctionRooms.Rows.Count - 1, 6);
            }
            else
            {
                loFolio.FolioETA = "12:00 PM";
                loFolio.FolioETD = "2:00 PM";
            }

            saveFunctionRooms();

            //jlo for alpa 6-9-10
            String _rStatus = "";
            if (lFlag == "Edit")
            {
                _rStatus = loFolioFacade.GetFolio(loFolio.FolioID).Status;
            }
            int _newStatus = getIndex(this.cboStatus.Text, aReservationStatus);
            int _dbStatus = getIndex(_rStatus, aReservationStatus);
            if (_newStatus < _dbStatus)
            {
                cboStatus.Text = _rStatus;
                if (_rStatus == "ONGOING")
                {
                    dtpFromDate.Text = loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString();
                    //grdFolioSchedule.SetData(1, 2, loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString());
                    gridFunctionRooms.SetData(1, 2, loFolioFacade.GetFolio(loFolio.FolioID).FromDate.ToString());
                }
            }
            //jlo

            if (lFlag == "New")
            {
                // Will enter here if new folio
                try
                {
                    loFolioFacade.SaveFolio(loFolio, ref pTrans);
                }
                catch (Exception ex)
                {
                    //loEventFacade.deleteEvents(loFolio.FolioID);
                    //MessageBox.Show("Transaction failed.\r\n\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;

                    throw new Exception("Transaction failed.\r\nError in saving new folio.\r\n\r\nError message: " + ex.Message);
                }
            }
            else
            {
                // Will enter here if update folio
                try
                {
                    loFolioFacade.updateFolio(loFolio, ref pTrans);
                    if (_refNoChanged && loFolio.Status == "CONFIRMED")
                    {
                        loFolioFacade.setReferencNo(loFolio.FolioID, loFolio.FromDate.Month, loFolio.FromDate.Year, GlobalVariables.gHotelId);
                        loFolio = loFolioFacade.GetFolio(loFolio.FolioID);
                        txtReferenceNo.Text = loFolio.ReferenceNo;
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Transaction failed.\r\nError in updating folio.\r\n\r\nError message: " + ex.Message);
                }
                //return true;
            }
            //return false;
        }

        private int IsConflict(ArrayList NewRoomEventColl) //Return 1 if conflict in roomevents 2 otherwise for blocking
        {

            RoomEventCollection rmEventColl;
            foreach (RoomEventCollection tempLoopVar_rmEventColl in NewRoomEventColl)
            {
                rmEventColl = tempLoopVar_rmEventColl;
                RoomEvents Rmevent;
                int i;
                if (rmEventColl.Count >= 1)
                {
                    for (i = 0; i < rmEventColl.Count; i++)
                    {
                        Rmevent = rmEventColl.Item(i);
                        //check conflict for roomevents
                        int eventNo = 0;
                        string roomEventRoomID = Rmevent.RoomID;
                        string roomEventDate = string.Format("{0:yyyy-MM-dd}", Rmevent.EventDate);
                        string lastRoomEventDate = string.Format("{0:yyyy-MM-dd}", rmEventColl.LastItem.EventDate);


                        eventNo = loRoomEventFacade.CheckConflict(roomEventRoomID, roomEventDate, lastRoomEventDate, Rmevent.Eventid);

                        if (eventNo != 0)
                        {
                            return eventNo;
                        }
                    }
                }
            }
            return -1;
        }

        private GenericList<Schedule> lScheduleList = new GenericList<Schedule>();
        //private void saveSchedules()
        //{
			
        //    ScheduleFacade _oScheduleFacade = new ScheduleFacade();
        //    MySqlTransaction _odbTrans = GlobalVariables.gPersistentConnection.BeginTransaction();

        //    _oScheduleFacade.deleteAllFolioSchedules(txtFolioID.Text, ref _odbTrans);
        //    RoomEventFacade _oRoomEventFacade = new RoomEventFacade();

        //    try
        //    {
        //        foreach (Schedule _oSchedule in lScheduleList)
        //        {
        //            _oScheduleFacade.InsertFolioSchedule(_oSchedule, "RESERVATION", ref _odbTrans);
        //        }
        //        _odbTrans.Commit();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Transaction failed.\r\nError in saving schedules.\r\n\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        _odbTrans.Rollback();
        //    }
        //}

		private void getFolioSchedules()
		{
			ScheduleFacade _oScheduleFacade = new ScheduleFacade();
			IList<Schedule> _oScheduleList = _oScheduleFacade.getFolioScheduleList(txtFolioID.Text);
			gridFunctionRooms.Rows.Count = 1;

			foreach (Schedule _oSchedule in _oScheduleList)
			{
				gridFunctionRooms.Rows.Count++;
				gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 0, _oSchedule.RoomID);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 1, _oSchedule.RoomType);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 2, _oSchedule.Venue);
				gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 3, _oSchedule.FromDate);
				gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 4, _oSchedule.ToDate);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 5, _oSchedule.StartTime);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 6, _oSchedule.EndTime);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 7, _oSchedule.RateType);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 8, _oSchedule.Rate);
                //gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 9, _oSchedule.Venue);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 9, _oSchedule.Setup);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 10, _oSchedule.Activity);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 12, _oSchedule.Remarks);
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 13, _oSchedule.Id);
                /* FP-SCR-00140 #1 [07.22.2010]
                 * added for getting guaranteed pax */
                gridFunctionRooms.SetData(gridFunctionRooms.Rows.Count - 1, 11, _oSchedule.GuaranteedPax);
			}
        }

		#endregion

		#region BILLING INFO

		private void gridBilling_AfterAddRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			this.Text = "Group Folio*";
		}

		private void gridBilling_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode.ToString() == "Delete")
				{
					gridBilling.RemoveItem(gridBilling.Row);
				}
			}
			catch { }
		}

		private void cboBillRates_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				gridBilling.SetData(gridBilling.Row, 2, cboBillRates.SelectedValue.ToString());
			}
			catch { }
		}

		private void gridBillingInfo_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.gridBillingInfo.Col == 2 && rdoPercent.Checked == true)
				{
					this.gridBillingInfo.Cols[2].AllowEditing = true;
					this.gridBillingInfo.SetData(this.gridBillingInfo.Row, 3, "0");
				}
				else if (this.gridBillingInfo.Col == 3 && rdoAmount.Checked == true)
				{
					this.gridBillingInfo.Cols[3].AllowEditing = true;
					this.gridBillingInfo.SetData(this.gridBillingInfo.Row, 2, "0");
				}
			}
			catch (Exception)
			{
			}
		}

		private void gridBillingInfo_RowColChange(object sender, EventArgs e)
		{
			gridBillingInfo_Click(sender, new EventArgs());
		}

		#endregion//billing info

        #region CHARGES

        private void getCharges(ListView pListView)
        {
            TransactionCodeFacade _oTransactionCodesDAO = new TransactionCodeFacade();
            DataSet _ds = (DataSet)_oTransactionCodesDAO.loadObject();
            DataTable _dt = _ds.Tables[0];

            pListView.Items.Clear();
            foreach (DataRow _dRow in _dt.Rows)
            {
                if (_dRow["acctside"].ToString() == "DEBIT")
                {
                    string _tranCode = _dRow["trancode"].ToString();
                    ListViewItem _lvwItem = new ListViewItem(_tranCode);

                    loFolioFacade = new FolioFacade();
                    DataTable _dtTable = loFolioFacade.GetRoutingDetails(txtFolioID.Text, _tranCode);

                    int rows = _dtTable.Rows.Count;
                    if (rows > 0) //And pListView Is lvwCharges Then
                    {
                        _lvwItem.BackColor = System.Drawing.Color.Beige;
                    }
                    _lvwItem.SubItems.Add(_dRow["memo"].ToString());
                    pListView.Items.Add(_lvwItem);
                }
            }
        }

        private bool validPostingDate()
        {
            bool valid = false;
            foreach (C1.Win.C1FlexGrid.Row _row in grdRecurredCharge.Rows)
            {
                if (_row.Index != 0)
                {
                    DateTime _postingDate = DateTime.Parse(grdRecurredCharge.GetDataDisplay(_row.Index, 11));
                    DateTime _auditDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    if (_postingDate.ToString("yyyy-MM-dd") == _auditDate.ToString("yyyy-MM-dd"))
                    {
                        valid = valid || true;
                    }
                }
            }

            return valid;
        }

        private void btnPostCharges_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Post Charges for this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //else if (loEventFacade.isGroupPackagePosted(txtFolioID.Text) == true)
            //{
            //    MessageBox.Show("Group packages are already posted.", "Post Charges", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////else if (loEventFacade.isGroupPackagePosted(txtFolioID.Text) == true)
            ////{
            ////    MessageBox.Show("Group packages are already posted.", "Post Charges", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            //    _oFolioLedgerUI.MdiParent = this.MdiParent;
            //    _oFolioLedgerUI.Show();
            ////    FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            ////    _oFolioLedgerUI.MdiParent = this.MdiParent;
            ////    _oFolioLedgerUI.Show();

            //    //CheckOutUI _oCheckOutUI = new CheckOutUI(txtFolioID.Text, txtGroupName.Text);
            //    //_oCheckOutUI.MdiParent = this.MdiParent;
            //    //_oCheckOutUI.Show();
            //}
            //else
            //{
            //    if (validPostingDate() == true)
            //    {
            //        PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
            //        if (oPostRoomChargeFacade.initializePostRoomCharges(txtFolioID.Text) == true)
            //        {
            //            MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            loEventFacade.updateGroupPackage(txtFolioID.Text);//<<to update the status of package whether it has been posted
            ////    //CheckOutUI _oCheckOutUI = new CheckOutUI(txtFolioID.Text, txtGroupName.Text);
            ////    //_oCheckOutUI.MdiParent = this.MdiParent;
            ////    //_oCheckOutUI.Show();
            ////}
            ////else
            ////{
            ////    if (validPostingDate() == true)
            ////    {
            ////        PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
            //        //if (oPostRoomChargeFacade.initializePostRoomCharges(txtFolioID.Text) == true)
            ////        {
            ////            MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////            loEventFacade.updateGroupPackage(txtFolioID.Text);//<<to update the status of package whether it has been posted

            //            FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            //            _oFolioLedgerUI.MdiParent = this.MdiParent;
            //            _oFolioLedgerUI.Show();
            ////            FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            ////            _oFolioLedgerUI.MdiParent = this.MdiParent;
            ////            _oFolioLedgerUI.Show();

            ////            //CheckOutUI _oCheckOutUI = new CheckOutUI(txtFolioID.Text, txtGroupName.Text);
            ////            //_oCheckOutUI.MdiParent = this.MdiParent;
            ////            //_oCheckOutUI.Show();
            ////        }
            ////        else
            ////        {
            ////            MessageBox.Show("Transactions are already posted for the day. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////        }
            ////    }
            ////    else
            ////    {
            ////        try
            ////        {
            ////            DateTime _postingDate = DateTime.Parse(grdRecurredCharge.GetDataDisplay(1, 4));
            ////            MessageBox.Show("Group packages are not posted.\r\nPosting date is on '" + _postingDate.ToString("MMM. dd, yyyy") + "'", "Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            //            _oFolioLedgerUI.MdiParent = this.MdiParent;
            //            _oFolioLedgerUI.Show();
            ////            FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            ////            _oFolioLedgerUI.MdiParent = this.MdiParent;
            ////            _oFolioLedgerUI.Show();
                        
            //            //CheckOutUI _oCheckOutUI = new CheckOutUI(txtFolioID.Text, txtGroupName.Text);
            //            //_oCheckOutUI.MdiParent = this.MdiParent;
            //            //_oCheckOutUI.Show();
            //        }
            //        catch
            //        {
            //            MessageBox.Show("No transactions to post.", "Post Charges", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////            //CheckOutUI _oCheckOutUI = new CheckOutUI(txtFolioID.Text, txtGroupName.Text);
            ////            //_oCheckOutUI.MdiParent = this.MdiParent;
            ////            //_oCheckOutUI.Show();
            ////        }
            ////        catch
            ////        {
            ////            MessageBox.Show("No transactions to post.", "Post Charges", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            //            _oFolioLedgerUI.MdiParent = this.MdiParent;
            //            _oFolioLedgerUI.Show();
            ////            FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
            ////            _oFolioLedgerUI.MdiParent = this.MdiParent;
            ////            _oFolioLedgerUI.Show();

            //            //CheckOutUI _oCheckOutUI = new CheckOutUI(txtFolioID.Text, txtGroupName.Text);
            //            //_oCheckOutUI.MdiParent = this.MdiParent;
            //            //_oCheckOutUI.Show();
            //        }
            //    }
            ////            //CheckOutUI _oCheckOutUI = new CheckOutUI(txtFolioID.Text, txtGroupName.Text);
            ////            //_oCheckOutUI.MdiParent = this.MdiParent;
            ////            //_oCheckOutUI.Show();
            ////        }
            ////    }
            ////}

            PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();

            // added dtpPostingDate to allow posting of charges for previous dates
            // Clark 08.10.2011
            if (oPostRoomChargeFacade.PostGroupCharges(dtpPostingDate.Value, txtFolioID.Text) == true)
            {
                MessageBox.Show("Posting transactions successful. ", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FolioLedgerUI _oFolioLedgerUI = new FolioLedgerUI(txtFolioID.Text);
                _oFolioLedgerUI.MdiParent = this.MdiParent;
                _oFolioLedgerUI.Show();
            }
        }

        private string origAmt = "0";
        //>>for getting the total estimated cost for the event
        //  this includes all the meals costing and the room rates and also the packages, if any
        private void getTotalEstimatedCost()
        {
            decimal _packageAmount = decimal.Parse(txtPackageAmount.Text);
            decimal _roomRatesAmount = 0;
            decimal _mealRatesAmount = 0;

            RoomEventFacade _oRoomEventFacade = new RoomEventFacade();
            GenericList<RoomEvents> _oRoomEventsList = _oRoomEventFacade.getChildFoliosRoomEvents(txtFolioID.Text);
            foreach (RoomEvents _oRoomEvent in _oRoomEventsList)
            {
                _roomRatesAmount += _oRoomEvent.RoomRate;
            }

            //foreach (TreeNode _treeNode in treeFoodBev.Nodes)
            //{
            //    if (_treeNode.Parent == null)
            //    {
            EventFoodRequirementsFacade _oFoodRequirementsFacade = new EventFoodRequirementsFacade();
            GenericList<EventFoodRequirements> _oFoodRequirementsList = _oFoodRequirementsFacade.getFoodRequirements(txtFolioID.Text);
            foreach (EventFoodRequirements _oEventFoodRequirements in _oFoodRequirementsList)
            {
                _mealRatesAmount += _oEventFoodRequirements.TotalMealCost;
            }
            //    }
            //}

            decimal _totalCost = _packageAmount + _roomRatesAmount + _mealRatesAmount;
            txtTotalEstimatedCost.Text = string.Format("{0:###,##0.#0}", _totalCost);
        }

        #endregion

        #region PRIVILEGES
        
        private void btnGuestPrivilege_Add_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
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

        public void removeAccountPrivileges()
        {
            this.grdFolioPrivileges.Rows.Count = 1;
        }

        private IList<Privilege> setUpFolioPrivileges()
        {
            IList<Privilege> _oFolioPrivileges = new List<Privilege>();

            for (int i = 1; i < this.grdFolioPrivileges.Rows.Count; i++)
            {
                Privilege _newFolioPrivilege = new Privilege();

                _newFolioPrivilege.HotelId = GlobalVariables.gHotelId;
                _newFolioPrivilege.FolioID = loFolio.FolioID;
                _newFolioPrivilege.TransactionCode = this.grdFolioPrivileges.GetDataDisplay(i, 0);
                _newFolioPrivilege.Basis = this.grdFolioPrivileges.GetDataDisplay(i, 2);
                _newFolioPrivilege.Percentoff = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(i, 3));
                _newFolioPrivilege.AmountOff = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(i, 4));

                _oFolioPrivileges.Add(_newFolioPrivilege);
            }

            return _oFolioPrivileges;
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
                this.grdFolioPrivileges.SetData(i, 3, _oPrivilege.Percentoff);
                this.grdFolioPrivileges.SetData(i, 4, _oPrivilege.AmountOff.ToString("N"));

                i++;
            }
        }


        #endregion	

		private void tabFolio__SelectedIndexChanged(object sender, EventArgs e)
		{
            if (tabFolio_.SelectedTab == tabFoodBev_ && !isReinstated)
			{
				addMeallDates();
			}
            if (tabFolio_.SelectedTab == TabRecurringCharge)
            {
                grdRecurringCharges.Row = 2;
                grdRecurringCharges.Row = 1;
                GroupBookingDropDownFacade _groupBookingDropDownFacade = new GroupBookingDropDownFacade();
                cboDiscount.DataSource = _groupBookingDropDownFacade.getGroupBooking("Discount");
                cboDiscount.DisplayMember = "Value";

                RateCodeFacade _rateCodeFacade = new RateCodeFacade();
                cboRateTypes.DataSource = _rateCodeFacade.getRateCodes();
                cboRateTypes.DisplayMember = "ratecode";
                grdRecurredCharge.Cols[5].Editor = cboRateTypes;
            }
		}

		private void pnlCompany_Paint(object sender, PaintEventArgs e)
		{

		}

		private void pnlIndividual_Paint(object sender, PaintEventArgs e)
		{

		}

        private void btnBookingSheet_Click(object sender, EventArgs e)
        {
            if (lEdit == true && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is in Edit Mode, Please save or cancel to proceed", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (btnBookingSheet.Text == "Booking Sheet")
            {
                Reports.Presentation.BookingSheetDepartment _oBookingSheetUI = new Jinisys.Hotel.Reports.Presentation.BookingSheetDepartment(txtFolioID.Text);
                _oBookingSheetUI.MdiParent = this.MdiParent;
                _oBookingSheetUI.Show();
            }
            else
            {
                IList<string> _oRooms = new List<string>();
                string _room = "";
                for(int _row = 1; _row < this.gridFunctionRooms.Rows.Count; _row++)
                {
                    _room = gridFunctionRooms.GetDataDisplay(_row, 0) + " [" + gridFunctionRooms.GetDataDisplay(_row, 2) + "]";
                    if(!_oRooms.Contains(_room))
                    {
                        _oRooms.Add(_room);
                    }
                }
                string _organizer = "";
                if (rdbCompany.Checked)
                {
                    _organizer = txtCompanyName.Text;
                }
                else
                {
                    _organizer = txtFirstName.Text + " " + txtLastName.Text;
                }

                Reports.Presentation.EventOrderUI _oEventOrderUI = new Jinisys.Hotel.Reports.Presentation.EventOrderUI(loFolio, _oRooms, loFolio.FromDate, loFolio.Todate, _organizer, this.nudPaxGuaranteed.Value, this.cboEventType.Text);
                //_oEventOrderUI.MdiParent = this.MdiParent;
                _oEventOrderUI.ShowDialog(this);
            }
            
        }


		private void btnAddFunctionSchedule_Click(object sender, EventArgs e)
		{
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
            mnuAddItem_Click(sender, e);
		}

		private void btnRemoveFunctionSchedule_Click(object sender, EventArgs e)
		{
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
            mnuDelete_Click(sender, e);
		}

		private void cboMealGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			MealMenu _oGroup = (MealMenu)cboMealGroups.SelectedValue;

			lvwMenus.Items.Clear();
			MealMenuItemFacade _oMealMenuItemFacade = new MealMenuItemFacade();
			GenericList<MealMenu> _oMealMenuItemList = new GenericList<MealMenu>();			
			_oMealMenuItemFacade = new MealMenuItemFacade();

            if (cboMealGroups.Text != "COMBO MEALS")
            {
                _oMealMenuItemList = new GenericList<MealMenu>();
                _oMealMenuItemList = _oMealMenuItemFacade.getMealMenuItems();
                foreach (MealMenu _oMealItem in _oMealMenuItemList)
                {
                    if (_oMealItem.GroupID == _oGroup.GroupID)
                    {
                        string[] item ={ _oMealItem.Description, _oMealItem.MealMenuItemID.ToString(), _oMealItem.Price.ToString() };
                        ListViewItem li = new ListViewItem(item);
                        lvwMenus.Items.Add(li);
                    }
                }
            }
            else
            {
                _oMealMenuItemList = new GenericList<MealMenu>();
                _oMealMenuItemList = _oMealMenuItemFacade.getMealMenus();
                foreach (MealMenu _oMealMenu in _oMealMenuItemList)
                {
                    string[] items ={ _oMealMenu.Description, _oMealMenu.MenuID.ToString(), _oMealMenu.Price.ToString() };
                    ListViewItem _listViewItem = new ListViewItem(items);
                    lvwMenus.Items.Add(_listViewItem);
                }
            }
		}

		private void btnRemoveMenu_Click(object sender, EventArgs e)
		{
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 
            
            int _row = this.gridMealItems.Row;
			if (_row < 0)
				return;

			this.gridMealItems.RemoveItem(_row);

		}

		private void btnAddMenu_Click(object sender, EventArgs e)
		{
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 
            
            lvwMenus_DoubleClick(sender, e);
		}

		private void lvwMenus_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvwMenus.Items.Count > 0)
			{
				this.btnAddMenu.Enabled = true;
			}
			else
			{
				this.btnAddMenu.Enabled = false;
			}
		}

		private void gridMealItems_RowColChange(object sender, EventArgs e)
		{
			int _row = this.gridMealItems.Row;

			if (_row < 0)
			{
				this.btnRemoveMenu.Enabled = false;
				return;
			}

			this.btnRemoveMenu.Enabled = true;
			
            //to check amount
            //nudMealLiveIn.Value += 1;
            //nudMealLiveIn.Value -= 1;
		}

		// FOR DRAG DROP function
		private void lvwMenus_ItemDrag(object sender, ItemDragEventArgs e)
		{
			lvwMenus.DoDragDrop(lvwMenus.SelectedItems, DragDropEffects.Move);
		}

		private void gridMealItems_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void gridMealItems_DragDrop(object sender, DragEventArgs e)
		{
            decimal _totalPrice = 0;
            int _count = this.lvwMenus.SelectedItems.Count;

			if (_count > 0)
			{
				ListView.SelectedListViewItemCollection selectedItems = this.lvwMenus.SelectedItems;

				MealMenuItemFacade _oMealMenuItemFacade = new MealMenuItemFacade();
				GenericList<MealMenu> _oMealMenuItemList;
				foreach (ListViewItem lvw in selectedItems)
				{
					_oMealMenuItemList = new GenericList<MealMenu>();
					_oMealMenuItemList = _oMealMenuItemFacade.getMealItemsForMenu(lvw.SubItems[1].Text);
					if (_oMealMenuItemList.Count > 0)
					{
						foreach (MealMenu _oMealMenuItems in _oMealMenuItemList)
						{
                            string[] items ={ _oMealMenuItems.MenuID.ToString(), _oMealMenuItems.MealMenuItemID.ToString(), _oMealMenuItems.Description };
                            gridMealItems.AddItem(items);
                        }
                        _totalPrice += decimal.Parse(lvwMenus.SelectedItems[0].SubItems[2].Text);
                    }
					else
					{
						string[] items ={ "", lvw.SubItems[1].Text, lvw.Text };
						gridMealItems.AddItem(items);
					}

				}

                nudPaxAmt.Value = _totalPrice;
                txtTotalMealAmount.Value = nudPaxAmt.Value * nudMealPax.Value;
			}

            //to check amount
            //nudMealLiveIn.Value += 1;
            //nudMealLiveIn.Value -= 1;

		}
        // END DRAG-DROP FUNCTION

        private void gridRooms_RowColChange(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuestPrivileges_Remove_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
            try
            {
                grdFolioPrivileges.RemoveItem(grdFolioPrivileges.Row);
            }
            catch { }
        }

        private void nudNumberOfPaxLiveOut_ValueChanged(object sender, EventArgs e)
        {
            nudPaxGuaranteed.Value = nudNumberOfPaxLiveIn.Value + nudNumberOfPaxLiveOut.Value;
        }

        private void rdoApplyGuestPrivilege_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbIndividual.Checked == true)
                {
                    GuestFacade _oGuestFacade = new GuestFacade();
                    Guest _oGuest = new Guest();

                    if (loFolio.CompanyID == null || loFolio.CompanyID == "")
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }

                    _oGuest = _oGuestFacade.getGuestRecord(loFolio.CompanyID);
                    _oGuestFacade.getAccountPrivileges(loFolio.CompanyID, ref _oGuest);
                    if (rdoApplyGuestPrivilege.Checked)
                    {
                        if (_oGuest != null)
                        {
                            showGuestPrivileges(_oGuest.AccountPrivileges, "guest");
                        }

                    }
                    else
                    {
                        removeAccountPrivileges();
                        //lvwGuestPrivileges.Items.Clear();
                    }
                }
            }
            catch { }
        }

        public void showGuestPrivileges(IList<PrivilegeHeader> pAccountPrivileges, string acctType)
        {
            this.grdFolioPrivileges.Rows.Count = 1;
            this.lvwGuestPrivileges.Items.Clear();
            this.lvwCompanyPrivileges.Items.Clear();

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
                    if (acctType == "guest")
                    {
                        ListViewItem lvwItem = new ListViewItem(_oPrivilegeHeader.PrivilegeID);
                        this.lvwGuestPrivileges.Items.Add(lvwItem);
                    }
                    else
                    {
                        ListViewItem lvwItem = new ListViewItem(_oPrivilegeHeader.PrivilegeID);
                        this.lvwCompanyPrivileges.Items.Add(lvwItem);
                    }

                }//end foreach

            }//end if
        }

        private void rdoApplyCompanyPrivileges_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbCompany.Checked == true)
                {
                    CompanyFacade _oCompanyFacade = new CompanyFacade();

                    if (loFolio.CompanyID == null || loFolio.CompanyID == "")
                    {
                        loFolio.CompanyID = txtcompanyid.Text;
                    }

                    loFolio.Company = _oCompanyFacade.getCompanyAccount(loFolio.CompanyID);
                    loFolio.Company.AccountPrivileges = _oCompanyFacade.getAccountPrivileges(loFolio.CompanyID);
                    if (rdoApplyCompanyPrivileges.Checked)
                    {
                        if (loFolio.Company != null && loFolio.CompanyID.StartsWith("G"))
                        {
                            showGuestPrivileges(loFolio.Company.AccountPrivileges, "company");
                        }

                    }
                    else
                    {
                        removeAccountPrivileges();
                        //lvwCompanyPrivileges.Items.Clear();
                    }
                }
            }
            catch { }
        }

        private void grdFolioPrivileges_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            string _basis = this.grdFolioPrivileges.GetDataDisplay(e.Row, 2);

            if (_basis == "A" && e.Col == 4)
            { 
                this.grdFolioPrivileges.SetData(e.Row, 3, 0);
                decimal _amount = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(e.Row, 4));
                if (_amount <= 0)
                {
                    MessageBox.Show("Amount should be greater than 0. \nPlease input correct amount.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if(_basis == "P" && e.Col == 3)
            {
                this.grdFolioPrivileges.SetData(e.Row, 4, 0);

                // check if not greater 100 Percent
                decimal _percent = decimal.Parse(this.grdFolioPrivileges.GetDataDisplay(e.Row, 3));
                if (_percent <= 0 || _percent > 100)
                {
                    MessageBox.Show("Percentage should be greater than 0 and less than or equal to 100. \nPlease input correct amount.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                    //this.grdFolioPrivileges.SetData(e.Row, 3, 0);
                }
            }
            if (e.Col == 2)
            {
                if (_basis == "P")
                {
                    grdFolioPrivileges.SetData(e.Row, 4, 0);
                }
                else if (_basis == "A")
                {
                    grdFolioPrivileges.SetData(e.Row, 3, 0);
                }
            }
        }

        private void grdFolioPrivileges_KeyPressEdit(object sender, C1.Win.C1FlexGrid.KeyPressEditEventArgs e)
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

        private void chkApply_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApply.Checked == false)
            {
                grdFolioPrivileges.Rows.Count = 1;
                gbxApplyPrivileges.Enabled = false;
                lvwGuestPrivileges.Items.Clear();
                lvwCompanyPrivileges.Items.Clear();
                rdoApplyCompanyPrivileges.Checked = false;
                rdoApplyGuestPrivilege.Checked = false;
            }
            else
            {
                gbxApplyPrivileges.Enabled = true;
            }
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "")
            {
                txtcompanyid.Text = "";
            }

            if ((lEdit == true || lFlag == "New") && txtcompanyid.Text == "")
            {
                if (this.txtCompanyName.Text.Trim().Length <= 0)
                {
                    this.lvwBrowseCompany.Visible = false;
                }
                else
                {
                    showCompanyLookUp(this.txtCompanyName.Text);
                }
            }
        }

        //private DataView loDtViewCompany;
        private void showCompanyLookUp(string pCompanyName)
        {
            try
            {
                CompanyFacade _oCompanyFacade = new CompanyFacade();
                
                //List<Company> _oCompanies = new List<Company>();
                //_oCompanies = _oCompanyFacade.getCompanyList();

                //_oCompanies = _oCompanies.FindAll(delegate(Company _oCompany) { return _oCompany.CompanyName.ToUpper().StartsWith(pCompanyName.ToUpper()); });

                //this.lvwBrowseCompany.Items.Clear();
                //foreach (Company pCompany in _oCompanies)
                //{
                //    ListViewItem _lvwItem = new ListViewItem();
                //    _lvwItem.Text = pCompany.CompanyId;

                //    _lvwItem.SubItems.Add(pCompany.CompanyName);

                //    this.lvwBrowseCompany.Items.Add(_lvwItem);
                //}

                DataTable _oCompany = new DataTable();
                _oCompany = _oCompanyFacade.getCompanies();
                DataView _dtViewCompany = _oCompany.DefaultView;

                _dtViewCompany.RowStateFilter = DataViewRowState.OriginalRows;
                _dtViewCompany.RowFilter = "CompanyName like '" + pCompanyName.ToUpper() + "%'";
                this.lvwBrowseCompany.Items.Clear();
                foreach (DataRowView dr in _dtViewCompany)
                {
                    ListViewItem _lvwItem = new ListViewItem();
                    _lvwItem.Text = dr[0].ToString();
                    _lvwItem.SubItems.Add(dr[2].ToString());
                    /* Gene
                     * 01-Mar-12
                     */
                    _lvwItem.SubItems.Add(dr["TIN"].ToString());

                    lvwBrowseCompany.Items.Add(_lvwItem);
                }


                //if (_oCompanies.Count <= 0)
                if(_dtViewCompany.Count <= 0)
                {
                    this.lvwBrowseCompany.Visible = false;
                    this.txtcompanyid.Text = "";
                }
                else
                {
                    //lvwBrowseCompany.Location = new System.Drawing.Point(390, 122);
                    lvwBrowseCompany.Location = new System.Drawing.Point(txtCompanyName.Location.X, txtCompanyName.Location.Y + 125);
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
            else if (e.KeyCode == Keys.Tab)
            {
                if (!this.lvwBrowseCompany.Focused)
                {
                    this.lvwBrowseCompany.Visible = false;
                }

                if (this.txtCompanyName.Text.Trim().Length == 0)
                {
                    return;
                }

                try
                {
                    DataTable _oCompany = loCompanyFacade.getCompanyAccountsData().Tables[0];
                    DataView _dtViewCompany = _oCompany.DefaultView;

                    _dtViewCompany.RowStateFilter = DataViewRowState.OriginalRows;
                    _dtViewCompany.RowFilter = "CompanyName = '" + this.txtCompanyName.Text + "'";

                    DataRowView _dRow = _dtViewCompany[0];
                    this.txtcompanyid.Text = _dRow["CompanyId"].ToString();
                }
                catch { }

                if (this.txtcompanyid.Text == "")
                {
                    if (this.txtCompanyName.Text.Trim().Length > 0)
                    {
                        createNewCompanyAccount();
                    }
                }
            }
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            txtCompanyName.Text = txtCompanyName.Text.Replace('\'', '`');
        }

        Sequence loFolioSequence = new Sequence();
        private bool createNewCompanyAccount()
        {
            try
            {
                if (this.txtCompanyName.Text.Trim().Length > 0 && txtcompanyid.Text == "")
                {

                    loCompanyFacade = new CompanyFacade();
                    Company _newCompany = new Company();

                    _newCompany.CompanyId = loFolioSequence.getSequenceId("G-", 12, "seq_company");
                    _newCompany.CompanyName = this.txtCompanyName.Text;
                    _newCompany.ContactNumber1 = txtContactNumber1.Text;
                    _newCompany.ContactNumber2 = txtContactNumber2.Text;
                    _newCompany.ContactNumber3 = txtContactNumber3.Text;
                    _newCompany.ContactPerson = txtContactPerson.Text;
                    _newCompany.Designation = txtDesignation.Text;
                    _newCompany.HotelID = GlobalVariables.gHotelId;
                    _newCompany.ACCOUNT_TYPE = "";
                    _newCompany.CARD_NO = "";
                    _newCompany.City1 = txtCity1.Text;
                    _newCompany.City2 = "";
                    _newCompany.City3 = "";
                    _newCompany.CompanyCode = this.txtCompanyCode.Text;
                    _newCompany.CompanyURL = "";
                    _newCompany.ContactType1 = "PHONE";
                    _newCompany.ContactType2 = "FAX";
                    _newCompany.ContactType3 = "MOBILE";
                    _newCompany.Country1 = txtCountry1.Text;
                    _newCompany.Country2 = "";
                    _newCompany.Country3 = "";
                    _newCompany.Email1 = "";
                    _newCompany.Email2 = "";
                    _newCompany.Email3 = "";
                    _newCompany.NO_OF_VISIT = 0;
                    _newCompany.Remarks = "";
                    _newCompany.Street1 = txtStreet1.Text;
                    _newCompany.Street2 = "";
                    _newCompany.Street3 = "";
                    _newCompany.THRESHOLD_VALUE = 0;
                    _newCompany.TOTAL_SALES_CONTRIBUTION = 0;
                    _newCompany.X_DEAL_AMOUNT = 0;
                    _newCompany.Zip1 = txtZip1.Text;
                    _newCompany.Zip2 = "";
                    _newCompany.Zip3 = "";
                    /* Gene
                     * 01-Mar-12
                     */
                    _newCompany.TIN = txtTIN.Text;

                    AccountInformation _oAccountInformation = new AccountInformation();
                    _oAccountInformation.AccountID = _newCompany.CompanyId;
                    _oAccountInformation.HotelID = GlobalVariables.gHotelId;
                    _oAccountInformation.Anniversary = DateTime.Parse("01-01-1900");

                    _newCompany.AccountInformation = _oAccountInformation;

                    loCompanyFacade.insertCompanyGuest(ref _newCompany);


                    this.txtcompanyid.Text = _newCompany.CompanyId;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in creating new company account.\r\n" + ex.Message);
            }
        }

        private void lvwBrowseCompany_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string _companyId = this.lvwBrowseCompany.SelectedItems[0].Text;
                string _companyName = this.lvwBrowseCompany.SelectedItems[0].SubItems[1].Text;
                /* Gene
                 * 01-Mar-12
                 */
                string _companyTIN = this.lvwBrowseCompany.SelectedItems[0].SubItems[2].Text;

                this.txtcompanyid.Text = _companyId;
                this.txtCompanyName.Text = _companyName;
                /* Gene
                 * 01-Mar-12
                 */
                this.txtTIN.Text = _companyTIN;
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

        private void btnRemoveHotelPromo_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
            if (this.grdFolioPackage.Rows.Count > 1)
            {

                DialogResult rsp = MessageBox.Show("Remove current folio package ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsp == DialogResult.Yes)
                {
                    this.grdFolioPackage.Rows.Count = 1;
                }

            }
        }

        private void btnAddHotelPromo_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            
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
                    DateTime _dateFrom = dtpFromDate.Value;
                    DateTime _dateTo = dtpTodate.Value;

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
                    return;
                }
            }
        }

        private void mnuCancelBlock_Click(object sender, EventArgs e)
        {
            FolioFacade oFolioFacade = new FolioFacade();
            Folio oFolio = oFolioFacade.GetFolio(lFolioNo);

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
                MessageBox.Show("Transaction failed.\r\n\r\nGuest still has unsettled account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("This Action will Remove the Sub Folio in the list, \n Do you still want to continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                FacadeDeclarations();
                RoomEvents _oRoomEvent = new RoomEvents();
                //Folio _oFolio = new Folio();
                oFolio.Status = "DELETED";
                oFolio.FolioID = lFolioNo;
                oFolio.UpdateTime = oFolio.UpdateTime;
                loFolioFacade.updateFolio(oFolio);
                //loScheduleFacade.DeleteSchedules(CInt(lFolioNo))
                loRoomEventFacade.CancelRoomEvents(lFolioNo, "RESERVATION", "CANCELLED");

                //>>for those rooms that are blocked by a group
                //>>if under a group, decrement the number of blocked rooms
                try
                {
                    string RoomID = grdFolio.GetDataDisplay(grdFolio.Row, 4);
                    RoomTypeFacade _oRoomFacade = new RoomTypeFacade();
                    string roomType = _oRoomFacade.getRoomType(RoomID.Substring(0, RoomID.IndexOf('-')));
                    EventRoomRequirementFacade _oRoomRequirementsFacade = new EventRoomRequirementFacade();
                    string folioID = txtFolioID.Text;
                    _oRoomRequirementsFacade.updateNumberOfBlockedRooms(folioID, roomType, 1);
                }
                catch { }

                updateCurrentDayStatusInMain();
                loadFolio();
                loadRoomRequirements();
            }
        }

        private void mnuUnblock_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Action will remove the Room Blocking for this group, \n Do you still want to continue?", "Group Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CellRange _range = grdFolio.Selection;

                for (int i = _range.r1; i <= _range.r2; i++)
                {
                    int BlockId = int.Parse(grdFolio.GetDataDisplay(i, 9));
                    string RoomID = grdFolio.GetDataDisplay(i, 4).Substring(0, grdFolio.GetDataDisplay(i, 4).IndexOf('-'));

                    RoomBlockFacade oRoomBlockFacade = new RoomBlockFacade();
                    oRoomBlockFacade.DeleteRoomBlock(BlockId, RoomID);

                    updateCurrentDayStatusInMain();

                    //>>for those rooms that are blocked by a group
                    //>>if under a group, decrement the number of blocked rooms
                    try
                    {
                        RoomTypeFacade _oRoomFacade = new RoomTypeFacade();
                        string roomType = _oRoomFacade.getRoomType(RoomID);
                        EventRoomRequirementFacade _oRoomRequirementsFacade = new EventRoomRequirementFacade();
                        string folioID = txtFolioID.Text;
                        _oRoomRequirementsFacade.updateNumberOfBlockedRooms(folioID, roomType, 1);
                    }
                    catch { }
                }

                loadFolio();
                loadRoomRequirements();
            }
        }

        public void updateCurrentDayStatusInMain()
        {

            Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
            MethodInfo objMethod = objectType.GetMethod("plotCurrentDayRoomStatus");
            objMethod.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);

        }

        private void txtCreateTime_TextChanged(object sender, EventArgs e)
        {
            txtCreateTime.Text = string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(txtCreateTime.Text));
        }
        private void disableTextBoxes()
        {
            this.txtFolioID.ReadOnly = true;
            this.cboStatus.Enabled = false;
            this.txtEventDate.ReadOnly = true;
            this.txtReferenceNo.ReadOnly = true;
            this.txt25RF1.ReadOnly = true;
            this.txt25RF2.ReadOnly = true;
            this.txt50RF.ReadOnly = true;
            this.txtBalanceRF.ReadOnly = true;
        }

        private void btnEdit_VisibleChanged(object sender, EventArgs e)
        {
            disableTextBoxes();
            if (btnEdit.Visible == true)
            {
                if (loFolio.Status == "CONFIRMED" || loFolio.Status == "WAITLIST" || loFolio.Status == "TENTATIVE")
                    btnCancelReservation.Enabled = true;
                else
                    btnCancelReservation.Enabled = false;
                //btnCancelReservation.Enabled = false;
                btnCancelReservation.Text = "C&ancel Rsvn";
                pnlStatus.Enabled = true;
                pnlFolio.Enabled = true;
            }
            else
            {
                btnCancelReservation.Enabled = true;
                //btnCancelReservation.Enabled = true;
                btnCancelReservation.Text = "C&ancel";
                pnlStatus.Enabled = false;
                pnlFolio.Enabled = false;
            }
        }

        private void rdbIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIndividual.Checked == true)
            {
                pnlIndividual.BringToFront();
            }
        }

        private void gridRooms_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (int.Parse(gridRooms.GetDataDisplay(e.Row, 1)) < int.Parse(gridRooms.GetDataDisplay(e.Row, 3)))
            {
                MessageBox.Show("Number of rooms required is lesser than the number of rooms already blocked.\r\n Unblock rooms first before changing the number of rooms required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridRooms.SetData(e.Row, 1, lOrigRoomCount);
            }

            if (int.Parse(gridRooms.GetDataDisplay(e.Row, 1)) == 0)
            {
                gridRooms.SetData(e.Row, 2, 0);
            }
        }

        private int lOrigRoomCount = 0;
        private void gridRooms_ValidateEdit(object sender, C1.Win.C1FlexGrid.ValidateEditEventArgs e)
        {
            lOrigRoomCount = int.Parse(gridRooms.GetDataDisplay(e.Row, 1));
        }

		private void btnManualBlockRooms_Click(object sender, EventArgs e)
		{
            //if (lEdit == false && lFlag == "Edit")
            //{
            //    MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //} 
            
            if (this.gridRooms.Rows.Count > 1)
			{
				int row = this.gridRooms.Row;
				CellStyle style = this.gridRooms.Rows[row].Style;
				
				int _noOfWeeks = 5;
				string _roomType = "";

				//if selected room type is RED then show selected room type on Grid
				if (style.BackColor == Color.Red)
				{
					_roomType = this.gridRooms.GetDataDisplay(row, 0);
				}
				else //show all roomtype if not
				{
					_roomType = "ALL";
				}

				string _folioID = this.txtFolioID.Text;
				Folio oGroupFolio = loFolioFacade.GetFolio(_folioID);

                //DateTime _startDate = oGroupFolio.FromDate;
                //DateTime _endDate = oGroupFolio.Todate;
                DateTime _startDate = dtpEventFrom.Value;
                DateTime _endDate = dtpEventTo.Value;

                //check whether event date has passed
                if (_startDate < DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    _startDate = DateTime.Parse(GlobalVariables.gAuditDate);
                }
                if (_endDate <= DateTime.Parse(GlobalVariables.gAuditDate))
                {
                    _endDate = DateTime.Parse(GlobalVariables.gAuditDate).AddDays(1);
                }

				loadCalendarForBlocking(_startDate, _endDate, _noOfWeeks, _roomType, _folioID);
			}

			
			loadFolio();
			loadRoomRequirements();
		}

		public void loadCalendarForBlocking(DateTime pStartDate, DateTime pEndDate, int pNoOfWeeks, string pRoomType, string pFolioID)
		{
			
			string lReservationMode = "GROUP_BLOCKING";

			RoomCalendar_New oRoomCalendar = new RoomCalendar_New(
												 lReservationMode,
												 pStartDate, 
                                                 pEndDate,
												 pNoOfWeeks,
												 pRoomType,
												 pFolioID);


			oRoomCalendar.launchCalendarForGroupBlocking(this.Label1);

		}

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                //MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        public void GroupReservationUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text.Contains("*"))
            {
                DialogResult rsp = MessageBox.Show("You are currently processing reservation.\r\n\r\nChanges will not be saved.\r\n\r\nClick Ok to exit without saving.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (rsp == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

		public void GroupReservationUI_FormClosed(object sender, FormClosedEventArgs e)
		{
            //if (lSubFolioGrid != null && cboStatus.Text != "ONGOING")
            //{
            //    GroupReservationListUI _oGroupReservationList = new GroupReservationListUI();
            //    _oGroupReservationList.MdiParent = this.MdiParent;
            //    _oGroupReservationList.Show();
            //}
            //else if (cboStatus.Text == "ONGOING")
            //{
            //    ReservationListUI _oReservationList = new ReservationListUI();
            //    _oReservationList.MdiParent = this.MdiParent;
            //    _oReservationList.Show();
            //}
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
                else if(_ctrl is Button)
                {
                    _ctrl.Enabled = false;
                }
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEventFrom.Text = dtpFromDate.Value.ToString("dd-MMM-yy");
            this.txtEventDate.Text = string.Format("{0:MMMM dd, yyyy}", dtpFromDate.Value) + " - " + string.Format("{0:MMMM dd, yyyy}", dtpTodate.Value);
        }

        private void dtpTodate_ValueChanged(object sender, EventArgs e)
        {
            dtpEventTo.Text = dtpTodate.Value.ToString("dd-MMM-yy");
            this.txtEventDate.Text = string.Format("{0:MMMM dd, yyyy}", dtpFromDate.Value) + " - " + string.Format("{0:MMMM dd, yyyy}", dtpTodate.Value);
        }

        private void grdRecurredCharge_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 0)
            {
                if (grdRecurredCharge.GetCellCheck(e.Row, e.Col) == CheckEnum.Checked)
                {
                    grdRecurredCharge.Cols[11].AllowEditing = false;
                    grdRecurredCharge.Cols[12].AllowEditing = false;
                }
                else
                {
                    grdRecurredCharge.Cols[11].AllowEditing = true;
                    grdRecurredCharge.Cols[12].AllowEditing = true;
                }
            }
            else if (e.Col == 11 || e.Col == 12)
            {
                if (grdRecurredCharge.GetCellCheck(e.Row, 0) == CheckEnum.Checked)
                {
                    grdRecurredCharge.Cols[11].AllowEditing = false;
                    grdRecurredCharge.Cols[12].AllowEditing = false;
                }
                else
                {
                    grdRecurredCharge.Cols[11].AllowEditing = true;
                    grdRecurredCharge.Cols[12].AllowEditing = true;
                }
            }

            if (e.Col == 7)
            {
                if (grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 3).ToString() == ConfigVariables.gRoomChargeTransactionCode)
                {
                    nmcQty.Minimum = 2;
                    nmcQty.Maximum = 24;
                    nmcQty.Value = 2;
                }
                else
                {
                    nmcQty.Minimum = 1;
                    nmcQty.Maximum = 1000;
                    nmcQty.Value = 1;
                }
                if (grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 3).ToString() == ConfigVariables.gContingencyCode)
                {
                    grdRecurredCharge.Cols[7].Editor = test;
                }
                else
                {
                    grdRecurredCharge.Cols[7].Editor = nmcQty;
                }
            }

            if (e.Col == 9)
            {
                grdRecurredCharge.Cols[9].Editor = cboDiscount;
            }

            if (e.Col == 5)
            {
                
                if (grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 3).ToString() == ConfigVariables.gRoomChargeTransactionCode)
                //if(grdRecurredCharge.GetDataDisplay(grdRecurredCharge.Row, 5)!= "")
                {
                    //grdRecurredCharge.Cols[5].AllowEditing = true;
                    grdRecurredCharge.Cols[5].Editor = cboRateTypes;
                }
                else
                {
                    //grdRecurredCharge.Cols[5].AllowEditing = false;
                    grdRecurredCharge.Cols[5].Editor = test;
                }
            }

            if (e.Col == 8)
            {
                grdRecurredCharge.Cols[8].Editor = nudTax;
            }

            //else if (e.Col == 6)
            //{
            //    IList<TransactionCode_SubAccount> _transSubAccounts;
            //    TransactionCode_SubAccountFacade _oTransFacade = new TransactionCode_SubAccountFacade();
            //    _transSubAccounts = _oTransFacade.loadTransactionCodeSubAccounts(grdRecurredCharge.GetDataDisplay(e.Row, 1));
            //    lRecurringCombo.DisplayMember = "SubAccountCode";
            //    lRecurringCombo.ValueMember = "SubAccountCode";
            //    lRecurringCombo.DataSource = _transSubAccounts;

            //    grdRecurredCharge.Cols[6].Editor = lRecurringCombo;
            //}


        }

        private void txtTotalEstimatedCost_TextChanged(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                computePackageAmount();
                btnEdit_Click();
                this.Text = "Group Folio*";
            }
        }

        private void disableTabsForEventManagement()
        {
            tabFolio_.TabPages.Remove(TabRecurringCharge);
            tabFolio_.TabPages.Remove(tabEventDetails_);
            tabFolio_.TabPages.Remove(tabWedding_);
            tabFolio_.TabPages.Remove(tabFoodBev_);

            btnPrintContract.Visible = false;
            btnBookingSheet.Visible = false;
            btnPostCharges.Visible = false;
        }

        private void dtpEventFrom_CloseUp(object sender, EventArgs e)
        {
            if (dtpEventFrom.Value < DateTime.Parse(GlobalVariables.gAuditDate))
            {
                dtpEventFrom.Value = DateTime.Parse(GlobalVariables.gAuditDate);
                MessageBox.Show("Cannot navigate to date. Selected date is less than the current audit date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpEventTo_CloseUp(object sender, EventArgs e)
        {
            if (dtpEventTo.Value < DateTime.Parse(GlobalVariables.gAuditDate))
            {
                dtpEventTo.Value = dtpEventFrom.Value.AddDays(1);
                MessageBox.Show("Cannot navigate to date. Selected date is less than the current audit date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboEventGrpPackage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cboEventGrpPackage.SelectedValue = 0;
            }
        }

        private void btnNewAmmendment_Click(object sender, EventArgs e)
        {
            if (btnNewAmmendment.Text.ToUpper().Trim() == "NEW")
            {
                btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.close16;
                grpNewAmendments.Enabled = true;
                this.btnNewAmmendment.Text = "    Cancel";
                pnlNew.Enabled = false;
                pnlStatus.Enabled = false;
                pnlFolio.Enabled = false;
                btnPrintAmmendments.Enabled = false;
                btnSaveAmmendment.Enabled = true;
                txtAmendmentNo.Text = "TO BE AMENDED";
            }
            else
            {
                btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.add16;
                grpNewAmendments.Enabled = false;
                pnlNew.Enabled = true;
                pnlStatus.Enabled = true;
                pnlFolio.Enabled = true;
                btnPrintAmmendments.Enabled = true;
                this.btnNewAmmendment.Text = "    New";
                btnSaveAmmendment.Enabled = false;

                //clear text
                txtAmendmentNo.Text = "";
                txtOldValue.Text = "";
                txtNewValue.Text = "";
            }
        }

        private void btnSaveAmmendment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this contract amendment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ContractAmendments _oAmendment = new ContractAmendments();
                ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();

                _oAmendment.AmendmentID = txtAmendmentNo.Text;
                _oAmendment.FolioID = txtFolioID.Text;
                _oAmendment.NewValue = txtNewValue.Text;
                _oAmendment.OldValue = txtOldValue.Text;
                _oAmendmentFacade.saveAmendment(ref _oAmendment);

                //add to grid amendments
                grdAmmendments.Rows.Count++;
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 0, _oAmendment.AmendmentID);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 1, _oAmendment.OldValue);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 2, _oAmendment.NewValue);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 3, _oAmendment.ID);
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 4, GlobalVariables.gLoggedOnUser);

                //disable/enable controls
                grpNewAmendments.Enabled = false;
                pnlNew.Enabled = true;
                pnlStatus.Enabled = true;
                pnlFolio.Enabled = true;
                btnPrintAmmendments.Enabled = true;
                this.btnNewAmmendment.Text = "    New";
                btnSaveAmmendment.Enabled = false;

                //clear text
                txtAmendmentNo.Text = "";
                txtOldValue.Text = "";
                txtNewValue.Text = "";

                //sort by amendment id ascending
                grdAmmendments.Sort(SortFlags.Ascending, 0);
                grdAmmendments.AutoSizeRows();

                btnNewAmmendment.Image = Jinisys.Hotel.Reservation.Properties.Resources.add16;
            }
            else
            {
                return;
            }
        }

        private void loadContractAmendments()
        {
            ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();
            DataTable dtTable = _oAmendmentFacade.getAmendments(txtFolioID.Text);

            foreach (DataRow dtRow in dtTable.Rows)
            {
                grdAmmendments.Rows.Count++;

                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 0, dtRow["AmmendmentID"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 1, dtRow["OldValue"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 2, dtRow["NewValue"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 3, dtRow["ID"].ToString());
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 4, dtRow["CreatedBy"].ToString());
                /* Gene
                 * 01-Mar-12
                 */
                grdAmmendments.SetData(grdAmmendments.Rows.Count - 1, 5, dtRow["CreateTime"].ToString());
            }

            //sort by amendment id ascending
            grdAmmendments.Sort(SortFlags.Ascending, 0);
            grdAmmendments.AutoSizeRows();
            grdAmmendments.AutoSizeCols();
            loadSystemAmendments();
        }

        /* FP-SCR-00140 #7 [07.28.2010]
         * added for showing the changes/amendments of the system */
        private void loadSystemAmendments()
        {
            ReportFacade _oReportFacade = new ReportFacade();
            DataTable _dtTable = _oReportFacade.searchChangesLog(txtFolioID.Text, "remarks");
            DataView _dtView = _dtTable.DefaultView;
            string[] _changesLogTables = ConfigVariables.gAmendmentsChangesLogTables.Split(',');

            _dtView.RowStateFilter = DataViewRowState.OriginalRows;
            _dtView.Sort = "DATE_CHANGED ASC";

            if (_changesLogTables.Length > 1)
            {
                string _filter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
                for (int i = 1; i < _changesLogTables.Length; i++)
                {
                    _filter = _filter + " or TABLE_NAME = '" + _changesLogTables[i] + "'";
                }
                _dtView.RowFilter = _filter;
            }
            else if(_changesLogTables.Length == 1)
            {
                _dtView.RowFilter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
            }
            foreach (DataRowView dtRowView in _dtView)
            {
                grdSystemChanges.Rows.Count++;

                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 0, dtRowView["Remarks"].ToString().Split(':')[0]);
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 1, dtRowView["Old_Value"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 2, dtRowView["New_Value"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 3, dtRowView["User_ID"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 4, dtRowView["Date_Changed"].ToString());
            }
            grdSystemChanges.AutoSizeRows();
            grdSystemChanges.AutoSizeCols();
        }

        private void grdAmmendments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().ToUpper() == "DELETE" && grdAmmendments.GetDataDisplay(grdAmmendments.Row, 0) == "TO BE AMENDED")
            {
                if (MessageBox.Show("Are you sure you want to delete this amendment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ContractAmendmentFacade _oAmendmentFacade = new ContractAmendmentFacade();
                    string pID = grdAmmendments.GetDataDisplay(grdAmmendments.Row, 3);
                    if (_oAmendmentFacade.deleteAmendment(pID) == true)
                    {
                        grdAmmendments.RemoveItem(grdAmmendments.Row);
                        MessageBox.Show("Successfully deleted.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnPrintAmmendments_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getContractAmendments(txtFolioID.Text);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
        }

        private void nudMealPax_ValueChanged(object sender, EventArgs e)
        {
            if (nudMealPax.Value >= nudMealPax.Maximum)
            {
                MessageBox.Show("The limit for this item has been reached!", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (nudPaxAmt.Visible == true)
            {
                txtTotalMealAmount.Value = nudPaxAmt.Value * nudMealPax.Value;
            }
        }

        private void gridMealItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridMealItems.Col == 2)
            {
                if (bool.Parse(ConfigVariables.gAllowEditMealItems) == true)
                {
                    gridMealItems.Cols[2].AllowEditing = true;
                }
                else
                {
                    gridMealItems.Cols[2].AllowEditing = false;
                }
            }
            else
            {
                gridMealItems.Cols[2].AllowEditing = false;
            }
        }

        private void nudPaxAmt_ValueChanged(object sender, EventArgs e)
        {
            if (nudPaxAmt.Value >= nudPaxAmt.Maximum)
            {
                MessageBox.Show("The limit for this item has been reached!", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            txtTotalMealAmount.Value = nudPaxAmt.Value * nudMealPax.Value;
            //try
            //{
            //    nudMealLiveIn.Value += 1;
            //    nudMealLiveIn.Value -= 1;
            //}
            //catch { }
        }

        private void gridFunctionRooms_ChangeEdit(object sender, EventArgs e)
        {
            using (Graphics _oGraphics = gridFunctionRooms.CreateGraphics())
            {
                // measure text height
                StringFormat _stringFormat = new StringFormat();
                int _width = gridFunctionRooms.Cols[gridFunctionRooms.Col].WidthDisplay - 2;
                string _text = gridFunctionRooms.Editor.Text;
                SizeF _sizeF = _oGraphics.MeasureString(_text, gridFunctionRooms.Font, _width, _stringFormat);

                // adjust row height if necessary
                C1.Win.C1FlexGrid.Row _oC1Row = gridFunctionRooms.Rows[gridFunctionRooms.Row];
                if (_sizeF.Height + 4 > _oC1Row.HeightDisplay)
                    _oC1Row.HeightDisplay = (int)_sizeF.Height + 4;
            }
        }

        private void gridFunctionRooms_RowColChange(object sender, EventArgs e)
        {
            gridFunctionRooms.AutoSizeRows();
        }

        private void setReqDateDropDown(DateTime pStart, DateTime pEnd)
        {
            cboReqDate.Items.Clear();
            TimeSpan _span = pEnd.Subtract(pStart);
            int _diff = System.Convert.ToInt32(Math.Floor(_span.TotalDays));
            for (int i = 0; i <= _diff; i++)
            {
                cboReqDate.Items.Add(string.Format("{0:dd-MMM-yyyy}", pStart.AddDays(i)));
            }
            cboReqDate.SelectedIndex = 0;
        }

        
        private void gridFunctionRooms_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
            /*
            if (TimeTo <= TimeFrom)
            {
                if (DateTo <= DateFrom)
                {
                    e.Cancel = true;
                }

            }

            //if(DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 6)) <= DateTime.Parse(gridFunctionRooms.GetDataDisplay(e.Row, 5)))
            //{
            //    MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    gridFunctionRooms.SetData(e.Row, 5, TimeFrom.ToString());
            //    gridFunctionRooms.SetData(e.Row, 6, TimeTo.ToString());
            //    //e.Cancel = true;
            //}
            */
        }
        

        DateTime DateFrom = DateTime.Now;
        DateTime DateTo = DateTime.Now.AddDays(1);

        DateTime TimeTo = DateTime.Now.AddHours(1);
        DateTime TimeFrom = DateTime.Now;
        private void gridFunctionRooms_CellChanged(object sender, RowColEventArgs e)
        {
            /* FP-SCR-00140 #2 [07.24.2010]
             * added for event requirements that needs each schedule
             * of the function room */
            try
            {
                gridReqSchedules.Rows.Count = 1;
                gridAmendmentSchedules.Rows.Count = 1;
                gridPackageRoom.Rows.Count = 1;
                foreach (C1.Win.C1FlexGrid.Row _oRow in gridFunctionRooms.Rows)
                {
                    if (_oRow.Index > 0)
                    {
                        string _roomID = gridFunctionRooms.GetDataDisplay(_oRow.Index, 0) + " [" + gridFunctionRooms.GetDataDisplay(_oRow.Index, 2) + "]";
                        string _fromDate = gridFunctionRooms.GetDataDisplay(_oRow.Index, 3);
                        string _toDate = gridFunctionRooms.GetDataDisplay(_oRow.Index, 4);
                        string _startTime = gridFunctionRooms.GetDataDisplay(_oRow.Index, 5);
                        string _endTime = gridFunctionRooms.GetDataDisplay(_oRow.Index, 6);

                        if (DateTime.Parse(_endTime) <= DateTime.Parse(_startTime))
                        {
                            if (DateTime.Parse(_toDate) <= DateTime.Parse(_fromDate))
                            {
                                MessageBox.Show("Cannot change to selected time. \nTime selected is less than the current time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        //setReqDateDropDown(DateTime.Parse(_fromDate), DateTime.Parse(_toDate));

                        gridReqSchedules.Rows.Count++;
                        gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 0, _roomID);
                        gridReqSchedules[gridReqSchedules.Rows.Count - 1, 1] = cboReqDate;
                        //gridReqSchedules.Cols[1].Editor = cboReqDate;
                        gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 1, string.Format("{0:dd-MMM-yyyy}",DateTime.Parse(_fromDate)));

                        gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 2, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_fromDate)));
                        gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 3, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_toDate)));
                        //gridReqSchedules.SetData(gridReqSchedules.Rows.Count - 1, 4, _endTime);

                        gridAmendmentSchedules.Rows.Count++;
                        gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 0, _roomID);
                        gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 1, _fromDate);
                        gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 2, _toDate);
                        gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 3, _startTime);
                        gridAmendmentSchedules.SetData(gridAmendmentSchedules.Rows.Count - 1, 4, _endTime);

                            gridPackageRoom.Rows.Count++;
                        gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 0, gridFunctionRooms.GetDataDisplay(_oRow.Index, 0));
                        gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 1, gridFunctionRooms.GetDataDisplay(_oRow.Index, 2));
                        gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 2, gridFunctionRooms.GetDataDisplay(_oRow.Index, 5) + "-" + gridFunctionRooms.GetDataDisplay(_oRow.Index, 6));
                        gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 3, gridFunctionRooms.GetDataDisplay(_oRow.Index, 3));
                        gridPackageRoom.SetData(gridPackageRoom.Rows.Count - 1, 4, gridFunctionRooms.GetDataDisplay(_oRow.Index, 4));
                        gridPackageRoom.AutoSizeCols();
                    }
                }
            }
            catch { }

            if (e.Col == 0)
            {
                try
                {
                    Room _oRoom = new Room();
                    RoomFacade _oRoomFacade = new RoomFacade();
                    _oRoom = _oRoomFacade.getRoom(gridFunctionRooms.GetDataDisplay(e.Row, 0));
                    //gridFunctionRooms.SetData(e.Row, 12, _oRoom.RoomTypecode);
                }
                catch { }
            }
        }

        private void btnreinstate_Click(object sender, EventArgs e)
        {
            GroupReservationUI.ACCOUNT_TYPE = AccountType.Corporate;
            //GroupReservationUI.Flag = "New";
           
            GroupReservationUI groupReservationsUI = new GroupReservationUI(loFolio);
            groupReservationsUI.MdiParent = this.MdiParent;
            groupReservationsUI.Show();
            this.Close();
        }

        private void cboRequirementType_DropDownClosed(object sender, EventArgs e)
        {
            if (cboRequirementType.Text.ToUpper().Contains("EVENT OFFICER") && _canAddEventOfficer == false)
            {
                MessageBox.Show("Sorry! You are not allowed to add Event Officers.\nPlease contact system administrator.\n\nThank you!", "Add Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboRequirementType.Text = "";
                txtRequirementNote.Text = "";
            }
        }


        ReportViewer rptViewer;
        private EstimatedChargesReport oGroupEstimatedCharge;
        private void btnPrintEstimatedCharges_Click(object sender, EventArgs e)
        {
            pnlEstimateCharges.BringToFront();
            pnlEstimateCharges.Visible = true;
        }

        private void grdRecurredCharge_EnterCell(object sender, EventArgs e)
        {
            try
            {
                if (grdRecurredCharge.Col == 11 || grdRecurredCharge.Col == 12)
                {
                    if (grdRecurredCharge.GetCellCheck(grdRecurredCharge.Row, 0) == CheckEnum.Checked)
                    {
                        grdRecurredCharge.Cols[11].AllowEditing = false;
                        grdRecurredCharge.Cols[12].AllowEditing = false;
                    }
                    else
                    {
                        grdRecurredCharge.Cols[11].AllowEditing = true;
                        grdRecurredCharge.Cols[12].AllowEditing = true;
                    }
                }
            }
            catch { }
        }

        private IList<EventContact> assignContactPersons()
        {
            IList<EventContact> _contactPersons = new List<EventContact>();
            try
            {
                EventContact _oContactPerson;
                for (int row = 1; row < gridContacts.Rows.Count; row++)
                {
                    _oContactPerson = new EventContact();
                    if (gridContacts.GetDataDisplay(row, 11).ToString() != "")
                    {
                        _oContactPerson.ContactID = gridContacts.GetDataDisplay(row, 11).ToString();
                    }
                    else
                    {
                        _oContactPerson.ContactID = "AUTO";
                    }
                    _oContactPerson.FolioID = loFolio.FolioID;
                    _oContactPerson.AccountID = loFolio.CompanyID;
                    _oContactPerson.HotelID = GlobalVariables.gHotelId.ToString();
                    _oContactPerson.LastName = gridContacts.GetDataDisplay(row, 0).ToString();
                    _oContactPerson.FirstName = gridContacts.GetDataDisplay(row, 1).ToString();
                    _oContactPerson.MiddleName = gridContacts.GetDataDisplay(row, 2).ToString();
                    _oContactPerson.Designation = gridContacts.GetDataDisplay(row, 3).ToString();
                    _oContactPerson.PersonType = gridContacts.GetDataDisplay(row, 4).ToString();
                    _oContactPerson.Address = gridContacts.GetDataDisplay(row, 5).ToString();
                    _oContactPerson.TelNo = gridContacts.GetDataDisplay(row, 6).ToString();
                    _oContactPerson.MobileNo = gridContacts.GetDataDisplay(row, 7).ToString();
                    _oContactPerson.FaxNo = gridContacts.GetDataDisplay(row, 8).ToString();
                    _oContactPerson.Email = gridContacts.GetDataDisplay(row, 9).ToString();
                    try
                    {
                        _oContactPerson.BirthDate = DateTime.Parse(gridContacts.GetDataDisplay(row, 10).ToString());
                    }
                    catch
                    {
                        _oContactPerson.BirthDate = DateTime.Parse("01-01-1900");
                    }

                    _contactPersons.Add(_oContactPerson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @assignContactPersons\r\n" + ex.Message);
            }
            return _contactPersons;
        }

        private IList<EventOfficer> assignEventOfficers()
        {
            IList<EventOfficer> _eventOfficers = new List<EventOfficer>();
            try
            {
                EventOfficer _oEventOfficer;
                for (int row = 1; row < gridEventOfficer.Rows.Count; row++)
                {
                    _oEventOfficer = new EventOfficer();
                    if (gridEventOfficer.GetDataDisplay(row, 3).ToString() == "")
                    {
                        _oEventOfficer.ID = "AUTO";
                    }
                    else
                    {
                        _oEventOfficer.ID = gridEventOfficer.GetDataDisplay(row, 3).ToString();
                    }
                    _oEventOfficer.LastName = gridEventOfficer.GetDataDisplay(row, 0).ToString();
                    _oEventOfficer.FirstName = gridEventOfficer.GetDataDisplay(row, 1).ToString();
                    _oEventOfficer.UserID = gridEventOfficer.GetDataDisplay(row, 2).ToString();
                    _oEventOfficer.FolioID = loFolio.FolioID;
                    _oEventOfficer.HotelID = GlobalVariables.gHotelId.ToString();
                    _eventOfficers.Add(_oEventOfficer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @assignEventOfficers\r\n" + ex.Message);
            }
            return _eventOfficers;
        }

        private IList<IncumbentOfficer> assignIncumbentOfficers()
        {
            IList<IncumbentOfficer> _incumbentOfficers = new List<IncumbentOfficer>();
            try
            {
                IncumbentOfficer _oIncumbentOfficer;
                for (int row = 1; row < gridIncumbentOfficer.Rows.Count; row++)
                {
                    _oIncumbentOfficer = new IncumbentOfficer();
                    _oIncumbentOfficer.ContactID = gridIncumbentOfficer.GetDataDisplay(row, 0).ToString();
                    if (_oIncumbentOfficer.ContactID == null || _oIncumbentOfficer.ContactID == "") { _oIncumbentOfficer.ContactID = "AUTO"; }
                    _oIncumbentOfficer.LastName = gridIncumbentOfficer.GetDataDisplay(row, 1).ToString();
                    _oIncumbentOfficer.FirstName = gridIncumbentOfficer.GetDataDisplay(row, 2).ToString();
                    _oIncumbentOfficer.Designation = gridIncumbentOfficer.GetDataDisplay(row, 3).ToString();
                    _oIncumbentOfficer.MobileNo = gridIncumbentOfficer.GetDataDisplay(row, 5).ToString();
                    _oIncumbentOfficer.Email = gridIncumbentOfficer.GetDataDisplay(row, 7).ToString();
                    _oIncumbentOfficer.TelNo = gridIncumbentOfficer.GetDataDisplay(row, 4).ToString();
                    _oIncumbentOfficer.FaxNo = gridIncumbentOfficer.GetDataDisplay(row, 6).ToString();
                    try
                    {
                        _oIncumbentOfficer.BirthDate = DateTime.Parse(gridIncumbentOfficer.GetDataDisplay(row, 8).ToString());
                    }
                    catch
                    {
                        _oIncumbentOfficer.BirthDate = DateTime.Parse("01-01-1900");
                    }
                    _oIncumbentOfficer.FolioID = loFolio.FolioID;
                    _oIncumbentOfficer.HotelID = GlobalVariables.gHotelId;
                    _incumbentOfficers.Add(_oIncumbentOfficer);
                }
                
                return _incumbentOfficers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @assignIncumbentOfficers\r\n" + ex.Message);       
            }
            return null;
        }

        private void loadIncumbentOfficers()
        {
            if (loFolio.IncumbentOfficers != null)
            {
                try
                {
                    gridIncumbentOfficer.Rows.Count = 1;
                    int _row = 1;
                    foreach (IncumbentOfficer _oIncumbentOfficer in loFolio.IncumbentOfficers)
                    {
                        gridIncumbentOfficer.Rows.Count++;
                        _row = gridIncumbentOfficer.Rows.Count - 1;

                        gridIncumbentOfficer.SetData(_row, 0, _oIncumbentOfficer.ContactID);
                        gridIncumbentOfficer.SetData(_row, 1, _oIncumbentOfficer.LastName);
                        gridIncumbentOfficer.SetData(_row, 2, _oIncumbentOfficer.FirstName);
                        gridIncumbentOfficer.SetData(_row, 3, _oIncumbentOfficer.Designation);
                        gridIncumbentOfficer.SetData(_row, 4, _oIncumbentOfficer.TelNo);
                        gridIncumbentOfficer.SetData(_row, 5, _oIncumbentOfficer.MobileNo);
                        gridIncumbentOfficer.SetData(_row, 6, _oIncumbentOfficer.FaxNo);
                        gridIncumbentOfficer.SetData(_row, 7, _oIncumbentOfficer.Email);
                        gridIncumbentOfficer.SetData(_row, 8, string.Format("{0:MM/dd/yyyy}", _oIncumbentOfficer.BirthDate));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @loading Incumbent Officers\r\n" + ex.Message);
                }
            }
        }

        private EventEndorsement assignEventEndorsement()
        {
            EventEndorsement oEventEndorsement = new EventEndorsement();
            oEventEndorsement.FolioID = loFolio.FolioID;
            oEventEndorsement.ContractAmount = txtContractAmount.Value;
            oEventEndorsement.LetterOfProposal = cboLetterOfProposal.Text;
            oEventEndorsement.DueDate1 = dtp25RF1.Value;
            oEventEndorsement.DueDate2 = dtp50RF.Value;
            oEventEndorsement.DueDate3 = dtp25RF2.Value;
            if (rdoBeingProcessed.Checked)
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.BEING_PROCESSED;
            }
            else if (rdoForPickup.Checked)
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.FOR_PICKUP;
            }
            else if (rdoSentToClient.Checked)
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.SENT_TO_CLIENT;
            }
            else
            {
                oEventEndorsement.LetterOfAgreement = EventEndorsement.SIGNED_RETURNED_TO_PICC;
            }
            oEventEndorsement.PickupDate = dtpForPickUp.Value;
            oEventEndorsement.SentToClientDate = dtpSentToClient.Value;
            oEventEndorsement.SignedDate = dtpSigned.Value;
            oEventEndorsement.HotelID = GlobalVariables.gHotelId;
            oEventEndorsement.Concessions = txtDiscountConcessions.Text;
            oEventEndorsement.Giveaways = txtGiveaways.Text;
            string[] _actions = new string[gridEMDActions.Rows.Count-1];
            for (int _row = 1; _row < gridEMDActions.Rows.Count; _row++)
            {
                _actions[_row-1] = gridEMDActions.GetDataDisplay(_row, 0);
            }
            oEventEndorsement.EMDActions = _actions;

            return oEventEndorsement;
        }

        private void loadEventEndorsement()
        {
            if (loFolio.EventEndorsement != null && loFolio.EventEndorsement.FolioID!=null)
            {
                try
                {
                    EventEndorsement _oEventEndorsement = loFolio.EventEndorsement;
                    cboLetterOfProposal.Text = _oEventEndorsement.LetterOfProposal;
                    txtContractAmount.Value = _oEventEndorsement.ContractAmount;
                    dtp25RF1.Value = _oEventEndorsement.DueDate1;
                    dtp50RF.Value = _oEventEndorsement.DueDate2;
                    dtp25RF2.Value = _oEventEndorsement.DueDate3;
                    dtpForPickUp.Value = _oEventEndorsement.PickupDate;
                    dtpSentToClient.Value = _oEventEndorsement.SentToClientDate;
                    dtpSigned.Value = _oEventEndorsement.SignedDate;
                    txtDiscountConcessions.Text = _oEventEndorsement.Concessions;
                    txtGiveaways.Text = _oEventEndorsement.Giveaways;
                    if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.BEING_PROCESSED)
                    {
                        rdoBeingProcessed.Checked = true;
                    }
                    else if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.FOR_PICKUP)
                    {
                        rdoForPickup.Checked = true;
                    }
                    else if (_oEventEndorsement.LetterOfAgreement == EventEndorsement.SENT_TO_CLIENT)
                    {
                        rdoSentToClient.Checked = true;
                    }
                    else
                    {
                        rdoReturned.Checked = true;
                    }

                    if (_oEventEndorsement.EMDActions!=null && _oEventEndorsement.EMDActions.Length > 0)
                    {
                        gridEMDActions.Rows.Count = 1;
                        int _row = gridEMDActions.Rows.Count;
                        foreach (string _actions in _oEventEndorsement.EMDActions)
                        {
                            gridEMDActions.Rows.Count++;
                            gridEMDActions.SetData(_row, 0, _actions);
                            _row++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @loadEventEndorsement\r\n" + ex.Message);
                }
            }
        }

        private void loadEventAttendance()
        {
            if (loFolio.EventAttendance != null)
            {
                try
                {
                    cboGeoEventType.Text = loFolio.EventAttendance.GeographicalScope;
                    nudForeign.Value = loFolio.EventAttendance.ForeignParticipants;
                    nudLocal.Value = loFolio.EventAttendance.LocalParticipants;
                    nudForeignBased.Value = loFolio.EventAttendance.ForeignBased;
                    nudLocalBased.Value = loFolio.EventAttendance.LocalBased;
                    nudVisitors.Value = loFolio.EventAttendance.NoOfVisitors;
                    nudActualAttendees.Value = loFolio.EventAttendance.ActualAttendees;
                    txtEventAttendanceRemarks.Text = loFolio.EventAttendance.Remarks;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @loadEventAttendance\r\n" + ex.Message);
                }
            }
        }

        private EventAttendance assignEventAttendance()
        {
            EventAttendance _oEventAttendance = new EventAttendance();
            _oEventAttendance.FolioID = loFolio.FolioID;
            _oEventAttendance.HotelID = GlobalVariables.gHotelId;
            _oEventAttendance.GeographicalScope = cboGeoEventType.Text;
            _oEventAttendance.ForeignParticipants = int.Parse(nudForeign.Value.ToString());
            _oEventAttendance.LocalParticipants = int.Parse(nudLocal.Value.ToString());
            _oEventAttendance.ForeignBased = int.Parse(nudForeignBased.Value.ToString());
            _oEventAttendance.LocalBased = int.Parse(nudLocalBased.Value.ToString());
            _oEventAttendance.NoOfVisitors = int.Parse(nudVisitors.Value.ToString());
            _oEventAttendance.ActualAttendees = int.Parse(nudActualAttendees.Value.ToString());
            _oEventAttendance.Remarks = txtEventAttendanceRemarks.Text;
            return _oEventAttendance;
        }

        private void loadContactPersons()
        {
            if (loFolio.ContactPersons != null && loFolio.ContactPersons.Count > 0)
            {
                try
                {
                    this.gridContacts.Rows.Count = 1;
                    int _row = this.gridContacts.Rows.Count - 1;
                    foreach (ContactPerson _contactPerson in loFolio.ContactPersons)
                    {
                        this.gridContacts.Rows.Count += 1;
                        _row = this.gridContacts.Rows.Count - 1;
                        /**
                         * 0 - lastname
                         * 1 - firstname
                         * 2 - middlename
                         * 3 - designation
                         * 4 - persontype
                         * 5 - address
                         * 6 - telno
                         * 7 - mobile no
                         * 8 - fax no
                         * 9 - email
                         * 10 - birthdate
                         * */
                        this.gridContacts.SetData(_row, 0, _contactPerson.LastName);
                        this.gridContacts.SetData(_row, 1, _contactPerson.FirstName);
                        this.gridContacts.SetData(_row, 2, _contactPerson.MiddleName);
                        this.gridContacts.SetData(_row, 3, _contactPerson.Designation);
                        this.gridContacts.SetData(_row, 4, _contactPerson.PersonType);
                        this.gridContacts.SetData(_row, 5, _contactPerson.Address);
                        this.gridContacts.SetData(_row, 6, _contactPerson.TelNo);
                        this.gridContacts.SetData(_row, 7, _contactPerson.MobileNo);
                        this.gridContacts.SetData(_row, 8, _contactPerson.FaxNo);
                        this.gridContacts.SetData(_row, 9, _contactPerson.Email);
                        this.gridContacts.SetData(_row, 10, _contactPerson.BirthDate);
                        this.gridContacts.SetData(_row, 11, _contactPerson.ContactID);
                        if (_contactPerson.PersonType == "Decision Maker")
                        {
                            this.gridContacts.Rows[_row].Style = this.gridContacts.Styles["decisionmaker"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @ loadContactPersons\r\n" + ex.Message);
                }
            }
            //else
            //{
            //    this.gridContacts.Rows.Count = 1;
            //}
        }

        private void loadEventOfficers()
        {
            if (loFolio.EventOfficers != null)
            {
                try
                {
                    int _row = this.gridEventOfficer.Rows.Count;
                    this.gridEventOfficer.Rows.Count = 1;
                    foreach (EventOfficer _eventOfficer in loFolio.EventOfficers)
                    {
                        _row = this.gridEventOfficer.Rows.Count;
                        this.gridEventOfficer.Rows.Count++;

                        /**
                         * 0 - lastname
                         * 1 - firstname
                         * */
                        this.gridEventOfficer.SetData(_row, 0, _eventOfficer.LastName);
                        this.gridEventOfficer.SetData(_row, 1, _eventOfficer.FirstName);
                        this.gridEventOfficer.SetData(_row, 2, _eventOfficer.UserID);
                        this.gridEventOfficer.SetData(_row, 3, _eventOfficer.ID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error @ loadEventOfficers\r\n" + ex.Message);
                }
            }
        }

        private void gridContacts_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuAddContact.Enabled = true;
                    this.mnuRemoveContact.Enabled = true;
                    mnuContactPerson.Show(this.gridContacts, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void mnuAddContact_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = this.gridContacts.Rows.Count;
            this.gridContacts.Rows.Count += 1;

            this.gridContacts.SetData(i, 0, "");
            this.gridContacts.SetData(i, 1, "");
            this.gridContacts.SetData(i, 2, "");
            this.gridContacts.SetData(i, 3, "");
            this.gridContacts.SetData(i, 4, "Contact Person");
            this.gridContacts.SetData(i, 5, "");
            this.gridContacts.SetData(i, 6, "");
            this.gridContacts.SetData(i, 7, "");
            this.gridContacts.SetData(i, 8, "");
            this.gridContacts.SetData(i, 9, "");
            this.gridContacts.SetData(i, 10, "01-01-1900");
            this.gridContacts.SetData(i, 11, "AUTO");
            this.gridContacts.Cols[4].Editor = lPersonType;
            this.gridContacts.Cols[10].Editor = dtpBirthDate;
        }

        private void mnuRemoveContact_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.gridContacts.Rows.Remove(this.gridContacts.Row);
            }
            catch { }
        }

        private void gridEventOfficer_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    if (_canAddEventOfficer)
                    {
                        this.mnuAddEventOfficer.Enabled = true;
                        this.mnuRemoveEventOfficer.Enabled = true;
                    }
                    else
                    {
                        this.mnuAddEventOfficer.Enabled = false;
                        this.mnuRemoveEventOfficer.Enabled = false;
                    }
                    mnuEventOfficers.Show(this.gridEventOfficer, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void mnuAddEventOfficer_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = gridEventOfficer.Rows.Count;
            gridEventOfficer.Rows.Count++;

            this.gridEventOfficer.SetData(i, 0, "");
            this.gridEventOfficer.SetData(i, 1, "");
            this.gridEventOfficer.SetData(i, 2, "");
            this.gridEventOfficer.SetData(i, 3, "");
        }

        private void mnuRemoveEventOfficer_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.gridEventOfficer.Rows.Remove(this.gridEventOfficer.Row);
            }
            catch { }
        }

        private void gridContacts_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 4)
            {
                if (gridContacts.GetDataDisplay(gridContacts.Row,4) == "Decision Maker")
                {
                    this.gridContacts.Rows[gridContacts.Row].Style = this.gridContacts.Styles["decisionmaker"];
                }
            }
        }

        private void txtContractAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtContractAmount.Value > 0)
                {
                    decimal percent25 = txtContractAmount.Value / 4;
                    this.txt25RF1.Text = string.Format("{0:###,##0.#0}", percent25);
                    this.txt50RF.Text = string.Format("{0:###,##0.#0}", (percent25 * 2));
                    this.txt25RF2.Text = string.Format("{0:###,##0.#0}",(txtContractAmount.Value - decimal.Parse(txt25RF1.Text) - decimal.Parse(txt50RF.Text)));
                    this.txtBalanceRF.Text = string.Format("{0:###,##0.#0}", (txtContractAmount.Value - lTotalPayment));
                }
                else if (txtContractAmount.Value == 0)
                {
                    this.txt25RF1.Text = "0";
                    this.txt50RF.Text = "0";
                    this.txt25RF2.Text = "0";
                    this.txtBalanceRF.Text = "0";
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error : contract amount should be a valid value\r\n" + ex.Message);
                tabFolio_.TabPages["tabEndorsement"].Select();
                this.txtContractAmount.Focus();
            }
        }

        private void rdoBeingProcessed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBeingProcessed.Checked)
            {
                dtpForPickUp.Enabled = false;
                dtpSentToClient.Enabled = false;
                dtpSigned.Enabled = false;
            }
        }

        private void rdoForPickup_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoForPickup.Checked)
            {
                dtpForPickUp.Enabled = true;
                dtpSentToClient.Enabled = false;
                dtpSigned.Enabled = false;
            }
        }

        private void rdoSentToClient_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSentToClient.Checked)
            {
                dtpForPickUp.Enabled = false;
                dtpSentToClient.Enabled = true;
                dtpSigned.Enabled = false;
            }
        }

        private void rdoReturned_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReturned.Checked)
            {
                dtpForPickUp.Enabled = false;
                dtpSentToClient.Enabled = false;
                dtpSigned.Enabled = true;
            }
        }

        private void mnuAddEMDAction_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = gridEMDActions.Rows.Count;
            gridEMDActions.Rows.Count++;

            this.gridEMDActions.SetData(i, 0, "");
        }

        private void mnuRemoveEMDAction_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.gridEMDActions.Rows.Remove(this.gridEMDActions.Row);
            }
            catch { }
        }

        private void gridEMDActions_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuAddEMDAction.Enabled = true;
                    this.mnuRemoveEMDAction.Enabled = true;
                    mnuEMDActions.Show(this.gridEMDActions, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnNewAmmendment.Text.ToUpper().Trim() == "NEW")
            {
                MessageBox.Show("Please create a new amendment first", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try {
                int _row = gridAmendmentSchedules.Row;
                string _sched = gridAmendmentSchedules.GetDataDisplay(_row, 0) + " (" + gridAmendmentSchedules.GetDataDisplay(_row, 1) + " - " + gridAmendmentSchedules.GetDataDisplay(_row, 2) + ")";
                txtOldValue.AppendText(_sched);

            }catch{}
        }

        private void gridReqSchedules_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                gridReqSchedules.Cols[0].AllowEditing = false;
                DateTime _startDate = DateTime.Parse(gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 2).ToString());
                DateTime _endDate = DateTime.Parse(gridReqSchedules.GetDataDisplay(gridReqSchedules.Row, 3).ToString());
                setReqDateDropDown(_startDate, _endDate);
                gridReqSchedules.Cols[1].Editor = cboReqDate;
            }
            catch
            {
            }
        }

        private void btnPrintEstimated_Click(object sender, EventArgs e)
        {
            DataTable _printableCharges = new DataTable();
            _printableCharges.Columns.Add("Header");
            _printableCharges.Columns.Add("TransactionCode");
            _printableCharges.Columns.Add("FromDate", typeof(DateTime));
            _printableCharges.Columns.Add("Memo");
            _printableCharges.Columns.Add("Amount", typeof(double));
            _printableCharges.Columns.Add("RoomTypeCode");
            _printableCharges.Columns.Add("RoomDescription");

            decimal _totalTax = 0;
            foreach (RecurringCharge _oRecurringCharge in loFolio.RecurringCharges)
            {
                TimeSpan _span = _oRecurringCharge.ToDate.Subtract(_oRecurringCharge.FromDate);
                int _difference = System.Convert.ToInt32(Math.Floor(_span.TotalDays));

                _difference++;
                for (int i = 0; i < _difference; i++)
                {
                    DataRow _row = _printableCharges.NewRow();
                    if (_oRecurringCharge.TransactionCode == ConfigVariables.gContingencyCode)
                    {
                        _row["Header"] = "II. CONTINGENCY FOR ADDITIONAL REQUIREMENTS";
                    }
                    else
                    {
                        _row["Header"] = "I. EVENT AREAS";
                    }

                    //_row["Memo"] = _oRecurringCharge.FromDate.AddDays(i).ToString("MMMM dd, yyyy") + "\n" + _oRecurringCharge.Memo;
                    string[] _subMemo = _oRecurringCharge.Memo.Split('/');
                    if (_subMemo.Length > 1 && _oRecurringCharge.TransactionCode == ConfigVariables.gRoomChargeTransactionCode)
                    {
                        _row["Memo"] = _oRecurringCharge.FromDate.AddDays(i).ToString("MMMM dd, yyyy") + " / " + _subMemo[1] + "\n" + _subMemo[0];
                    }
                    else
                    {
                        _row["Memo"] = _oRecurringCharge.FromDate.AddDays(i).ToString("MMMM dd, yyyy") + "\n" + _oRecurringCharge.Memo;
                    }
                    _row["TransactionCode"] = _oRecurringCharge.TransactionCode;
                    //_row["Amount"] = _oRecurringCharge.Amount;
                    _row["FromDate"] = _oRecurringCharge.FromDate.AddDays(i);

                    Room _oRoom = new Room();
                    RoomFacade _oRoomFacade = new RoomFacade();
                    _oRoom = _oRoomFacade.getRoom(_oRecurringCharge.RoomID);

                    _row["RoomTypeCode"] = _oRoom.RoomTypecode;
                    //_row["RoomDescription"] = _oRoom.RoomDescription;
                    decimal _amount = _oRecurringCharge.BaseAmount * ((100 - _oRecurringCharge.Discount) / 100);
                    _totalTax = _totalTax + (_oRecurringCharge.BaseAmount * _oRecurringCharge.Tax/100 * _oRecurringCharge.QtyHrs);
                    if (_oRecurringCharge.TransactionCode == ConfigVariables.gRoomChargeTransactionCode)
                    {
                        _row["RoomDescription"] = _oRoom.RoomDescription + " on...\nP" + (_amount * 4) + " (4 hrs.) P" + _amount + " (extra hour)";
                    }
                    else
                    {
                        _row["RoomDescription"] = _oRoom.RoomDescription + "...";
                    }
                    _row["Amount"] = _amount * _oRecurringCharge.QtyHrs;
                    _printableCharges.Rows.Add(_row);
                }
            }
            
            if (_printableCharges != null)
            {

                oGroupEstimatedCharge = new EstimatedChargesReport();

                oGroupEstimatedCharge.Database.Tables[1].SetDataSource(_printableCharges);
                oGroupEstimatedCharge.Database.Tables[0].SetDataSource(CrystalReportAddons.reportHeader());

                oGroupEstimatedCharge.SetParameterValue(0, cboShowAmount.Text);
                oGroupEstimatedCharge.SetParameterValue(1, txtContingencyDetails.Text);
                oGroupEstimatedCharge.SetParameterValue(2, _totalTax);
                oGroupEstimatedCharge.SetParameterValue(3, loFolio.ReferenceNo);
                oGroupEstimatedCharge.SetParameterValue(4, loFolio.GroupName);
                oGroupEstimatedCharge.SetParameterValue(5, loFolio.FromDate);
                if (rdbCompany.Checked)
                {
                    oGroupEstimatedCharge.SetParameterValue(6, txtCompanyName.Text);
                }
                else
                {
                    oGroupEstimatedCharge.SetParameterValue(6, txtLastName.Text + ", " + txtFirstName.Text);
                }

                oGroupEstimatedCharge.SetParameterValue(7, loFolio.FolioID);

                rptViewer = new ReportViewer();
                rptViewer.rptViewer.ReportSource = oGroupEstimatedCharge;
                rptViewer.MdiParent = this.MdiParent;
                rptViewer.Show();


                this.MdiParent.Cursor = Cursors.Default;

                //this.Close();
            }

            this.pnlEstimateCharges.SendToBack();
            this.pnlEstimateCharges.Visible = false;
        }

        private void btnCancelEstimated_Click(object sender, EventArgs e)
        {
            this.pnlEstimateCharges.Visible = false;
        }

        private void pnlEstimateCharges_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlEstimateCharges.Visible == true)
            {
                txtContingencyDetails.Text = "(Alloted for possible extension of hire period," +
                    " power charges for any technical equipment to be brought inside " + ConfigVariables.gReportOrganization +
                    ", charges for possible damages and for additional requirement that may be incurred, etc.)";

               tabFolio_.Enabled = false;
            }
            else
            {
                txtContingencyDetails.Text = "";
                tabFolio_.Enabled = true;
            }
        }

        private void btnPrintSystemChanges_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getSystemChanges(txtFolioID.Text);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
        }

        private void nudForeign_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = nudForeign.Value + nudLocal.Value;
        }

        private void nudLocal_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = nudForeign.Value + nudLocal.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();

            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getEventAttendance(txtFolioID.Text);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
        }

        private void btnSaveCancellation_Click(object sender, EventArgs e)
        {
            loFolioFacade.updateCancellation(loFolio.FolioID, cboReason.Text, txtReasons.Text, cboCancelBookingType.Text, txtFutureAction.Text);
        }

        private void mnuIncumbentRemove_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.gridIncumbentOfficer.Rows.Remove(this.gridIncumbentOfficer.Row);
            }
            catch { }
        }

        private void mnuIncumbentAdd_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int i = gridIncumbentOfficer.Rows.Count;
            gridIncumbentOfficer.Rows.Count++;

            this.gridIncumbentOfficer.SetData(i, 0, "");
            this.gridIncumbentOfficer.SetData(i, 1, "");
            this.gridIncumbentOfficer.SetData(i, 2, "");
            this.gridIncumbentOfficer.SetData(i, 3, "");
            this.gridIncumbentOfficer.SetData(i, 4, "");
            this.gridIncumbentOfficer.SetData(i, 5, "");
            this.gridIncumbentOfficer.SetData(i, 6, "");
            this.gridIncumbentOfficer.SetData(i, 7, "");
            this.gridIncumbentOfficer.SetData(i, 8, "01-01-1900");
            this.gridIncumbentOfficer.Cols[8].Editor = dtpBirthDate;
        }

        private void gridIncumbentOfficer_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);
                    this.mnuIncumbentAdd.Enabled = true;
                    this.mnuIncumbentRemove.Enabled = true;
                    mnuIncumbentOfficers.Show(this.gridIncumbentOfficer, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void gridContacts_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 10)
            {
                gridContacts.Cols[10].Editor = dtpBirthDate;
            }
            if (e.Col == 4)
            {
                this.gridContacts.Cols[4].Editor = lPersonType;
            }
        }

        private void gridIncumbentOfficer_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 8)
            {
                gridIncumbentOfficer.Cols[8].Editor = dtpBirthDate;
            }
        }

        private void lvwDetails_DoubleClick(object sender, EventArgs e)
        {
            if (lvwDetails.SelectedItems.Count > 0)
            {
                lvwDetails.SelectedItems[0].BeginEdit();
            }
        }

        private void txtPackageAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtContractAmount.Value = decimal.Parse(txtPackageAmount.Text);
            }
            catch { }
        }

        private void gridEventOfficer_BeforeEdit(object sender, RowColEventArgs e)
        {
            string _filter = "";
            for (int i = 1; i < gridEventOfficer.Rows.Count; i++)
            {
                if (i != gridEventOfficer.Row)
                {
                    _filter = _filter + "UserId <> '" + gridEventOfficer.GetDataDisplay(i, 2).ToString() + "' and ";
                }
            }
            if (_filter.Length > 0)
            {
                _filter = _filter.Substring(0, _filter.Length - 4);
            }

            DataView _dv = loUserList.DefaultView;
            _dv.RowFilter = "";
            _dv.RowFilter = _filter;

            cboUsers.DataSource = _dv.ToTable();

            if (e.Col == 0)
            {
                cboUsers.DisplayMember = "LastName";
                gridEventOfficer.Cols[0].Editor = cboUsers;
            }
            if (e.Col == 1)
            {
                cboUsers.DisplayMember = "FirstName";
                gridEventOfficer.Cols[1].Editor = cboUsers;
            }
            
        }

        private void gridEventOfficer_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 0)
            {
                DataRowView _dRow = (DataRowView)cboUsers.SelectedItem;
                gridEventOfficer.SetData(gridEventOfficer.Row, 1, _dRow["FirstName"].ToString());
                gridEventOfficer.SetData(gridEventOfficer.Row, 2, _dRow["UserId"].ToString());
            }
            if (e.Col == 1)
            {
                DataRowView _dRow = (DataRowView)cboUsers.SelectedItem;
                gridEventOfficer.SetData(gridEventOfficer.Row, 0, _dRow["LastName"].ToString());
                gridEventOfficer.SetData(gridEventOfficer.Row, 2, _dRow["UserId"].ToString());
            }
        }

        private void mnuOpenListContact_Click(object sender, EventArgs e)
        {
            if (lEdit == false && lFlag == "Edit")
            {
                MessageBox.Show("Reservation is not in Edit Mode, Click Edit Info to Activate Edit Mode", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ContactPerson _oContactPerson = new ContactPerson();
            DataTable _dt = _oContactPerson.getContactPersons(txtcompanyid.Text, GlobalVariables.gHotelId);
            gridContactList.Rows.Count = 1;
            int _row = 1;
            bool _found = false;
            foreach (DataRow _dRow in _dt.Rows)
            {
                for (int i = 1; i < gridContacts.Rows.Count; i++)
                {
                    if(_dRow["contactID"].ToString() == gridContacts.GetDataDisplay(i,11).ToString())
                    {
                        _found = true;
                        break;
                    }
                }
                if (_found)
                {
                    _found = false;
                    continue;
                }
                gridContactList.Rows.Count++;
                gridContactList.SetData(_row, 1, _dRow["contactID"]);
                gridContactList.SetData(_row, 2, _dRow["lastName"]);
                gridContactList.SetData(_row, 3, _dRow["firstName"]);
                gridContactList.SetData(_row, 4, _dRow["middleName"]);
                gridContactList.SetData(_row, 5, _dRow["designation"]);
                gridContactList.SetData(_row, 6, _dRow["personType"]);
                gridContactList.SetData(_row, 7, _dRow["address"]);
                gridContactList.SetData(_row, 8, _dRow["telNo"]);
                gridContactList.SetData(_row, 9, _dRow["mobileNo"]);
                gridContactList.SetData(_row, 10, _dRow["faxNo"]);
                gridContactList.SetData(_row, 11, _dRow["email"]);
                gridContactList.SetData(_row, 12, _dRow["birthdate"]);
                _row++;
            }
            pnlContactList.BringToFront();
            pnlContactList.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlContactList.Visible = false;
            pnlContactList.SendToBack();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int _row = 1; _row < gridContactList.Rows.Count; _row++)
            {
                if (gridContactList.GetCellCheck(_row, 0) == C1.Win.C1FlexGrid.CheckEnum.Checked)
                {
                    gridContacts.Rows.Count++;
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 11, gridContactList.GetDataDisplay(_row, 1));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 0, gridContactList.GetDataDisplay(_row, 2));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 1, gridContactList.GetDataDisplay(_row, 3));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 2, gridContactList.GetDataDisplay(_row, 4));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 3, gridContactList.GetDataDisplay(_row, 5));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 4, gridContactList.GetDataDisplay(_row, 6));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 5, gridContactList.GetDataDisplay(_row, 7));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 6, gridContactList.GetDataDisplay(_row, 8));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 7, gridContactList.GetDataDisplay(_row, 9));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 8, gridContactList.GetDataDisplay(_row, 10));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 9, gridContactList.GetDataDisplay(_row, 11));
                    gridContacts.SetData(gridContacts.Rows.Count - 1, 10, gridContactList.GetDataDisplay(_row, 12));
                    
                }
            }

            pnlContactList.Visible = false;
            pnlContactList.SendToBack();
        }

        private void gridContactList_BeforeEdit(object sender, RowColEventArgs e)
        {

        }

        private void txtTotalEstimatedCost_TextChanged_1(object sender, EventArgs e)
        {
            decimal _totaldeposit = 0;
            decimal _totalbal = 0;
            if (grdDeposits.Rows.Count > 1)
            {
                for (int _row = 1; _row < grdDeposits.Rows.Count; _row++)
                {
                    decimal _temp;
                    try
                    {
                        string str = grdDeposits.GetDataDisplay(_row, 1).ToString();
                        _temp = decimal.Parse(str);
                    }
                    catch
                    {
                        _temp = 0;
                    }
                    _totaldeposit = _totaldeposit + _temp;
                }
            }

            try 
            {
                _totalbal = decimal.Parse(txtTotalEstimatedCost.Text);
            }
            catch
            {
                _totalbal = 0;
            }

            _totalbal = _totalbal - _totaldeposit;
            txtEstimatedBal.Text = string.Format("{0:###,##0.#0}",_totalbal);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (loFolio != null)
            {
                string strFileName = "LOP - " + txtGroupName.Text;

                sfdExport.Filter = "Word Files (*.doc)|*.doc";
                sfdExport.FileName = strFileName;
                DialogResult _result = sfdExport.ShowDialog();

                if (_result == DialogResult.OK)
                {
                    DataTable _dt = new DataTable();
                    _dt.Columns.Add("individual");
                    _dt.Columns.Add("designation");
                    _dt.Columns.Add("company");
                    _dt.Columns.Add("address1");
                    _dt.Columns.Add("address2");
                    _dt.Columns.Add("telephone");
                    _dt.Columns.Add("email");
                    _dt.Columns.Add("dear");
                    _dt.Columns.Add("event");
                    _dt.Columns.Add("wordamount");
                    _dt.Columns.Add("contractamount");
                    _dt.Columns.Add("50%Date");
                    _dt.Columns.Add("lastDate");
                    _dt.Columns.Add("conforme");

                    DataRow _dRow = _dt.NewRow();
                    if(loFolio.CompanyID.StartsWith("G-"))
                    {
                        Company _company = loCompanyFacade.getCompanyAccount(txtcompanyid.Text);

                        _dRow["company"] = _company.CompanyName;
                        EventContact _decisionmaker = getDecisionMaker();
                        _dRow["address1"] = _company.Street1 + ", " + _company.City1;
                        _dRow["address2"] = _company.Country1 + " " + _company.Zip1;
                        _dRow["telephone"] = _company.ContactNumber1;
                        _dRow["email"] = _company.Email1;

                        if (_decisionmaker != null)
                        {
                            _dRow["individual"] = "MR./MS. " + _decisionmaker.FirstName + " " + _decisionmaker.LastName;
                            _dRow["designation"] = _decisionmaker.Designation;
                            _dRow["conforme"] = _decisionmaker.FirstName + " " + _decisionmaker.LastName;
                            _dRow["dear"] = "MR./MS. " + _decisionmaker.LastName;
                        }
                        else
                        {
                            _dRow["individual"] = "";
                            _dRow["designation"] = "";
                            _dRow["conforme"] = "";
                            _dRow["dear"] = "";
                        }
                    }
                    else
                    {
                        Guest _guest = loGuestFacade.getGuestRecord(txtcompanyid.Text);
                        _dRow["individual"] = "MR./MS. " + _guest.FirstName + " " + _guest.LastName;
                        _dRow["designation"] = "Organizer";
                        EventContact _decisionmaker = getDecisionMaker();
                        if (_decisionmaker != null)
                        {
                            _dRow["company"] = "MR./MS. " + _decisionmaker.FirstName + " " + _decisionmaker.LastName;
                            _dRow["address1"] = "Decision Maker";
                            _dRow["address2"] = _decisionmaker.Address;
                            _dRow["telephone"] = _decisionmaker.TelNo;
                            _dRow["email"] = _decisionmaker.Email;
                            _dRow["conforme"] = _guest.FirstName + " " + _guest.LastName;
                            _dRow["dear"] = "MR./MS. " + _guest.LastName;
                        }
                        else
                        {
                            _dRow["company"] = "";
                            _dRow["address1"] = "";
                            _dRow["address2"] = "";
                            _dRow["telephone"] = "";
                            _dRow["email"] = "";
                            _dRow["conforme"] = "";
                            _dRow["dear"] = "";
                        }
                    }

                    _dRow["event"] = loFolio.GroupName;
                    decimal _25 = loFolio.EventEndorsement.ContractAmount/4;
                    string _numbertoword = string.Format("{0:######0.#0}",  _25.ToString());
                    string _cents = "";
                    if(_numbertoword.Contains("."))
                    {
                        string[] _numSplit = _numbertoword.Split('.');
                        _numbertoword = _numSplit[0];
                        _cents = " and " + _numSplit[1] + "/" + "100";
                    }
                    _dRow["wordamount"] = NumberToText(int.Parse(_numbertoword)) + _cents + " PESOS";
                    _dRow["contractamount"] = string.Format("{0:###,##0.#0}", _25);
                    _dRow["50%Date"] = string.Format("{0:MMMM dd, yyyy (dddd)}", loFolio.EventEndorsement.DueDate2);
                    _dRow["lastDate"] = string.Format("{0:MMMM dd, yyyy (dddd)}", loFolio.EventEndorsement.DueDate3);

                    _dt.Rows.Add(_dRow);

                    ReportFacade _rptFacade = new ReportFacade();
                    if(_rptFacade.exportLetterOfProposal(sfdExport.FileName, loFolio.FolioID ,_dt,"",""))
                    {
                        MessageBox.Show("Export successful!" , "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Event is still not saved.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }



        private EventContact getDecisionMaker()
        {
            foreach (EventContact _eventContact in loFolio.ContactPersons)
            {
                if (_eventContact.PersonType == "Decision Maker")
                {
                    return _eventContact;
                }
            }
            return null;
        }

        public string NumberToText(int number)
        {
            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ","Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            //num[1] = num[1] - 100 * num[2]; // thousands
            num[1] = num[1] - (num[2] * 1000);
            num[3] = number / 1000000000; // crores
            //num[2] = num[2] - 100 * num[3]; // lakhs
            num[2] = num[2] - (num[3] * 1000);
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - (10 * h); // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    //if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd().ToUpper();
        }

        private void btnUploadLOP_Click(object sender, EventArgs e)
        {
            if (loFolio != null)
            {
                //string strFileName = "LOP - " + txtGroupName.Text;

                ofdUpload.Filter = "Word Files (*.doc)|*.doc";
                ofdUpload.FileName = "";
                DialogResult _result = ofdUpload.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(ofdUpload.FileName, ConfigVariables.gServerUploadPath + loFolio.FolioID + ".doc", true);
                        MessageBox.Show("Upload successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a problem uploading the document!\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnViewLOP_Click(object sender, EventArgs e)
        {
            // Try catch added by Gene - 9/1/2011
            try
            {
                if (loFolio != null)
                {
                    string _file = ConfigVariables.gServerUploadPath + loFolio.FolioID + ".doc";
                    _file = _file.Replace("\\\\", "\\");
                    Process.Start(_file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem viewing the LOP.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFolio_Click(object sender, EventArgs e)
        {

        }

        private void btnUnconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboStatus.Text.Trim().ToUpper().Equals("CONFIRMED"))
                {
                    return;
                }

                loEventFacade = new EventFacade();
                
                if (loEventFacade.unconfirmEventReservation(txtFolioID.Text))
                {
                    MessageBox.Show("Unconfirm successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboStatus.Text = "TENTATIVE";
                    txtReferenceNo.Text = "";
                    setButtons();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem unconfirming the Event Reservation.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gene
        /// 01-Mar-12
        /// Limits the form size to 864x784
        /// The minimum size of the form that will not show the objects hidden at the back of groupBox13 and groupBox12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupReservationUI_Resize(object sender, EventArgs e)
        {
            if (this.Width < 864)
                this.Width = 864;
            if (this.Height < 784)
                this.Height = 784;
        }

        /// <summary>
        /// Gene
        /// 02-Mar-12
        /// Copies an excel file to gServerUploadPath
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadAttachments_Click(object sender, EventArgs e)
        {
            if (loFolio != null)
            {                
                ofdUpload.Filter = "Excel Files (*.xls)|*.xls";
                ofdUpload.FileName = "";
                DialogResult _result = ofdUpload.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(ofdUpload.FileName, ConfigVariables.gServerUploadPath + loFolio.FolioID + ".xls", true);
                        MessageBox.Show("Upload successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a problem uploading the document!\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Gene
        /// 02-Mar-12
        /// Opens the excel file found in gServerUploadPath
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                if (loFolio != null)
                {
                    string _file = ConfigVariables.gServerUploadPath + loFolio.FolioID + ".xls";
                    _file = _file.Replace("\\\\", "\\");
                    Process.Start(_file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem viewing the Excel file.\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Gene
        /// 02-Mar-12
        /// Copies the selected node in treeRequirements to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeRequirements.SelectedNode.Index >= 0)
            {
                Clipboard.SetDataObject(treeRequirements.SelectedNode.Text);
            }
        }

        private void mnuRefreshSchedule_Click(object sender, EventArgs e)
        {

        }

        
    }
}
